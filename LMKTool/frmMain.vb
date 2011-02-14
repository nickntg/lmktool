''
'' This program is free software; you can redistribute it and/or modify
'' it under the terms of the GNU General Public License as published by
'' the Free Software Foundation; either version 2 of the License, or
'' (at your option) any later version.
''
'' This program is distributed in the hope that it will be useful,
'' but WITHOUT ANY WARRANTY; without even the implied warranty of
'' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'' GNU General Public License for more details.
''
'' You should have received a copy of the GNU General Public License
'' along with this program; if not, write to the Free Software
'' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'' 
Imports ThalesSim.Core

Public Class frmMain

    'Delegate to log information from cross-threaded calls.
    Delegate Sub LogMessage(ByVal msg As String)

    'Socket to Thales HSM.
    Dim WithEvents WC As ThalesSim.Core.TCP.WorkerClient

    'Thales response to host commands.
    Dim thalesResponse As String

    ''' <summary>
    ''' Select the Database Config script.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdSelectConfigScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectConfigScript.Click
        OFD.Title = "Select the database config script"
        OFD.InitialDirectory = System.IO.Directory.GetCurrentDirectory
        OFD.ShowDialog(Me)
        If OFD.FileName <> "" Then
            txtDBConfigScript.Text = OFD.FileName
        End If
    End Sub

    ''' <summary>
    ''' Select the Key Selection script.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdSelectKeySelectionScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectKeySelectionScript.Click
        OFD.Title = "Select the key selection script"
        OFD.InitialDirectory = System.IO.Directory.GetCurrentDirectory
        OFD.ShowDialog(Me)
        If OFD.FileName <> "" Then
            txtKeySelectScript.Text = OFD.FileName
        End If
    End Sub

    ''' <summary>
    ''' Select the Key Update script.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdSelectKeyUpdateScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectKeyUpdateScript.Click
        OFD.Title = "Select the key update script"
        OFD.InitialDirectory = System.IO.Directory.GetCurrentDirectory
        OFD.ShowDialog(Me)
        If OFD.FileName <> "" Then
            txtKeyUpdateScript.Text = OFD.FileName
        End If
    End Sub

    ''' <summary>
    ''' Main method, do the translation of keys from the old LMKs to the new LMKs.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>All-in-one method. Not too pretty but nothing more fancy is required here.</remarks>
    Private Sub cmdTranslateFromOldLMK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTranslateFromOldLMK.Click

        'Connect to the Thales HSM.
        Try
            WC = New TCP.WorkerClient(New System.Net.Sockets.TcpClient(txtThalesIP.Text, Convert.ToInt32(txtThalesPort.Text)))
            WC.InitOps()
            doLog("Connected to Thales")
        Catch ex As Exception
            WC = Nothing
            MessageBox.Show(Me, "Error connecting to Thales." + vbCrLf + ex.Message, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim sqlCon As String = ""

        'Retrieve the sql connection string from the script.
        Try
            doLog("Retrieving config...")
            Dim engine As Jint.JintEngine = GetEngine()
            sqlCon = Convert.ToString(engine.Run(GetScriptContents(txtDBConfigScript.Text)))
            ClearEngine(engine)
        Catch ex As Exception
            DisconnectThales()
            MessageBox.Show(Me, "Error running DB config script." + vbCrLf + ex.Message, "Script error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim helper As New JintHelper

        'Open a connection to the database.
        Try
            doLog("Opening db connection...")
            helper.sqlCon = New SqlClient.SqlConnection(sqlCon)
            helper.sqlCon.Open()
        Catch ex As Exception
            DisconnectThales()
            MessageBox.Show(Me, "Error connecting to the database." + vbCrLf + ex.Message, "DB error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'Run the key select script to retrieve the keys under the old LMKs.
        Try
            doLog("Retrieving keys under old LMKs...")
            Dim engine As Jint.JintEngine = GetEngine()
            engine.SetParameter("helper", helper)
            engine.Run(GetScriptContents(txtKeySelectScript.Text))
        Catch ex As Exception
            helper.sqlCon.Dispose()
            helper.sqlCon = Nothing
            DisconnectThales()
            MessageBox.Show(Me, "Error running DB select script." + vbCrLf + ex.Message, "Script error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        doLog("Number of keys found: " + helper.Keys.Count.ToString)
        Dim LMKTranslate As Integer = 0, LMKTranslateErrors As Integer = 0, Updates As Integer = 0

        'If we have keys, migrate them.
        If helper.Keys.Count <> 0 Then
            Try
                'For all keys...
                For i As Integer = 0 To helper.Keys.Count - 1

                    'Run the BW translate command.
                    doLog("Translating " + helper.Keys(i).KeyValue + "...")
                    thalesResponse = ""
                    WC.send(New String("0"c, Convert.ToInt32(nudThalesHeaderLength.Value)) + "BWFF" + helper.Keys(i).KeyLength() + helper.Keys(i).KeyValue + ";" + helper.Keys(i).KeyType)

                    'Wait for a reply.
                    While thalesResponse = "" AndAlso WC.IsConnected
                        Threading.Thread.Sleep(5)
                    End While

                    'Check if the HSM didn't like this.
                    If Not WC.IsConnected Then
                        Throw New Exception("Lost connection to HSM")
                    End If

                    'Check the response. A 00 indicates success.
                    Dim thalesError As String = thalesResponse.Substring(6, 2)

                    If thalesError <> "00" Then
                        'Error, do we continue?
                        doLog("Translation error (" + thalesError + ")")
                        LMKTranslateErrors += 1
                        If Not chkIgnoreLMKTranslateErrors.Checked Then
                            Throw New Exception("LMK translate error")
                        End If
                    Else
                        'Success, keep this value.
                        Dim newValue As String = thalesResponse.Substring(8)
                        If newValue.StartsWith("U") Then newValue = newValue.Substring(1)
                        doLog("New LMK value: " + newValue)
                        LMKTranslate += 1
                        helper.Keys(i).TranslatedValue = newValue
                    End If
                Next

                'If configured, don't perform database updates.
                If Not chkDoNotUpdateDB.Checked Then

                    'Do all in a transaction. Every successful conversion or none at all should go in the database.
                    Using sqlTrans As SqlClient.SqlTransaction = helper.sqlCon.BeginTransaction()
                        helper.sqlTrans = sqlTrans
                        Try
                            For i As Integer = 0 To helper.Keys.Count - 1
                                'Successful conversions only.
                                If helper.Keys(i).TranslatedValue <> "" Then
                                    'Update this key.
                                    doLog("Updating key " + helper.Keys(i).KeyName + "...")
                                    Dim engine As Jint.JintEngine = GetEngine()
                                    engine.SetParameter("helper", helper)
                                    engine.SetParameter("key", helper.Keys(i))
                                    engine.Run(GetScriptContents(txtKeyUpdateScript.Text))
                                    Updates += 1
                                Else
                                    doLog("Skipping key " + helper.Keys(i).KeyName + "...")
                                End If
                            Next
                            'All done, commit this.
                            sqlTrans.Commit()
                        Catch ex As Exception
                            'Error, rollback and rethrow.
                            sqlTrans.Rollback()
                            Throw ex
                        End Try
                    End Using
                End If
            Catch ex As Exception
                'An error occured with some part of the process.
                helper.sqlCon.Dispose()
                helper.sqlCon = Nothing
                DisconnectThales()
                MessageBox.Show(Me, "Error translating from old to new LMK." + vbCrLf + ex.Message, "Translate error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'We're done. Show info and end this.
        DisconnectThales()
        doLog("Keys translated: " + LMKTranslate.ToString)
        doLog("Translation errors: " + LMKTranslateErrors.ToString)
        doLog("Keys updated: " + Updates.ToString)
        doLog("End")
    End Sub

    ''' <summary>
    ''' Disconnects from the Thales HSM.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisconnectThales()
        WC.TermClient()
        WC = Nothing
    End Sub

    ''' <summary>
    ''' Creates a new instance of a Jint engine.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetEngine() As Jint.JintEngine
        Dim engine As Jint.JintEngine = New Jint.JintEngine
        engine.AllowClr = True
        engine.DisableSecurity()

        If chkJintDebug.Checked Then
            AddHandler engine.Break, AddressOf j_Break
            AddHandler engine.Step, AddressOf j_Step
            engine.SetDebugMode(True)
        End If

        Return engine
    End Function

    ''' <summary>
    ''' Clears the instance of a Jint engine.
    ''' </summary>
    ''' <param name="engine"></param>
    ''' <remarks></remarks>
    Private Sub ClearEngine(ByVal engine As Jint.JintEngine)
        If chkJintDebug.Checked Then
            RemoveHandler engine.Break, AddressOf j_Break
            RemoveHandler engine.Step, AddressOf j_Step
        End If

        engine = Nothing
    End Sub

    ''' <summary>
    ''' Reads the contents of a javascript file.
    ''' </summary>
    ''' <param name="scriptFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetScriptContents(ByVal scriptFile As String) As String
        Using SR As IO.StreamReader = New IO.StreamReader(scriptFile, System.Text.Encoding.Default)
            Return SR.ReadToEnd()
        End Using
    End Function

    ''' <summary>
    ''' Handles disconnects from the Thales HSM.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub WC_Disconnected(ByVal sender As ThalesSim.Core.TCP.WorkerClient) Handles WC.Disconnected
        threadDoLog("Disconnected from Thales")
    End Sub

    ''' <summary>
    ''' Handles responses from the Thales HSM.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="b"></param>
    ''' <param name="len"></param>
    ''' <remarks></remarks>
    Private Sub WC_MessageArrived(ByVal sender As ThalesSim.Core.TCP.WorkerClient, ByRef b() As Byte, ByVal len As Integer) Handles WC.MessageArrived
        thalesResponse = System.Text.ASCIIEncoding.GetEncoding(Globalization.CultureInfo.CurrentCulture.TextInfo.ANSICodePage).GetChars(b, 0, len)
    End Sub

    ''' <summary>
    ''' (Cross-thread) Logs info to the log text box.
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <remarks></remarks>
    Private Sub threadDoLog(ByVal msg As String)
        Me.Invoke(New LogMessage(AddressOf doLog), New Object() {msg})
    End Sub

    ''' <summary>
    ''' Logs info to the log text box.
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <remarks></remarks>
    Private Sub doLog(ByVal msg As String)
        txtLog.AppendText(msg + vbCrLf)
        txtLog.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' Event handler that receives events when Jint encounters a breakpoint.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub j_Break(ByVal sender As Object, ByVal e As Jint.Debugger.DebugInformation)
        threadDoLog(e.CurrentStatement.Source.ToString)
        threadDoLog(e.CurrentStatement.Source.Code)
    End Sub

    ''' <summary>
    ''' Event handler that receives events when Jint steps over a javascript statement.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub j_Step(ByVal sender As Object, ByVal e As Jint.Debugger.DebugInformation)
        threadDoLog(e.CurrentStatement.Source.ToString)
        threadDoLog(e.CurrentStatement.Source.Code)
    End Sub
End Class