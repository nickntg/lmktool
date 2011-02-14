<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdSelectConfigScript = New System.Windows.Forms.Button
        Me.cmdSelectKeySelectionScript = New System.Windows.Forms.Button
        Me.cmdSelectKeyUpdateScript = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkDoNotUpdateDB = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdTranslateFromOldLMK = New System.Windows.Forms.Button
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.OFD = New System.Windows.Forms.OpenFileDialog
        Me.chkJintDebug = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.nudThalesHeaderLength = New System.Windows.Forms.NumericUpDown
        Me.chkIgnoreLMKTranslateErrors = New System.Windows.Forms.CheckBox
        Me.txtSleepInterval = New System.Windows.Forms.TextBox
        Me.txtThalesPort = New System.Windows.Forms.TextBox
        Me.txtThalesIP = New System.Windows.Forms.TextBox
        Me.txtDBConfigScript = New System.Windows.Forms.TextBox
        Me.txtKeyUpdateScript = New System.Windows.Forms.TextBox
        Me.txtKeySelectScript = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudThalesHeaderLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Database config script:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Key selection script:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Key update script:"
        '
        'cmdSelectConfigScript
        '
        Me.cmdSelectConfigScript.Location = New System.Drawing.Point(431, 21)
        Me.cmdSelectConfigScript.Name = "cmdSelectConfigScript"
        Me.cmdSelectConfigScript.Size = New System.Drawing.Size(24, 23)
        Me.cmdSelectConfigScript.TabIndex = 1
        Me.cmdSelectConfigScript.Text = "..."
        Me.cmdSelectConfigScript.UseVisualStyleBackColor = True
        '
        'cmdSelectKeySelectionScript
        '
        Me.cmdSelectKeySelectionScript.Location = New System.Drawing.Point(431, 50)
        Me.cmdSelectKeySelectionScript.Name = "cmdSelectKeySelectionScript"
        Me.cmdSelectKeySelectionScript.Size = New System.Drawing.Size(24, 23)
        Me.cmdSelectKeySelectionScript.TabIndex = 3
        Me.cmdSelectKeySelectionScript.Text = "..."
        Me.cmdSelectKeySelectionScript.UseVisualStyleBackColor = True
        '
        'cmdSelectKeyUpdateScript
        '
        Me.cmdSelectKeyUpdateScript.Location = New System.Drawing.Point(431, 78)
        Me.cmdSelectKeyUpdateScript.Name = "cmdSelectKeyUpdateScript"
        Me.cmdSelectKeyUpdateScript.Size = New System.Drawing.Size(24, 23)
        Me.cmdSelectKeyUpdateScript.TabIndex = 5
        Me.cmdSelectKeyUpdateScript.Text = "..."
        Me.cmdSelectKeyUpdateScript.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDBConfigScript)
        Me.GroupBox1.Controls.Add(Me.cmdSelectKeyUpdateScript)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdSelectKeySelectionScript)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmdSelectConfigScript)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtKeyUpdateScript)
        Me.GroupBox1.Controls.Add(Me.txtKeySelectScript)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(468, 115)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Script configuration"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nudThalesHeaderLength)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.chkJintDebug)
        Me.GroupBox2.Controls.Add(Me.chkDoNotUpdateDB)
        Me.GroupBox2.Controls.Add(Me.chkIgnoreLMKTranslateErrors)
        Me.GroupBox2.Controls.Add(Me.txtSleepInterval)
        Me.GroupBox2.Controls.Add(Me.txtThalesPort)
        Me.GroupBox2.Controls.Add(Me.txtThalesIP)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(468, 207)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thales configuration"
        '
        'chkDoNotUpdateDB
        '
        Me.chkDoNotUpdateDB.AutoSize = True
        Me.chkDoNotUpdateDB.Checked = True
        Me.chkDoNotUpdateDB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDoNotUpdateDB.Location = New System.Drawing.Point(128, 159)
        Me.chkDoNotUpdateDB.Name = "chkDoNotUpdateDB"
        Me.chkDoNotUpdateDB.Size = New System.Drawing.Size(140, 17)
        Me.chkDoNotUpdateDB.TabIndex = 5
        Me.chkDoNotUpdateDB.Text = "Do not update database"
        Me.chkDoNotUpdateDB.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(47, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Sleep interval:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(59, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Thales port:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Thales HSM IP:"
        '
        'cmdTranslateFromOldLMK
        '
        Me.cmdTranslateFromOldLMK.Location = New System.Drawing.Point(157, 346)
        Me.cmdTranslateFromOldLMK.Name = "cmdTranslateFromOldLMK"
        Me.cmdTranslateFromOldLMK.Size = New System.Drawing.Size(176, 23)
        Me.cmdTranslateFromOldLMK.TabIndex = 0
        Me.cmdTranslateFromOldLMK.Text = "Translate from old LMK"
        Me.cmdTranslateFromOldLMK.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(12, 375)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(468, 138)
        Me.txtLog.TabIndex = 1
        '
        'OFD
        '
        Me.OFD.Filter = "Script files|*.js"
        '
        'chkJintDebug
        '
        Me.chkJintDebug.AutoSize = True
        Me.chkJintDebug.Checked = True
        Me.chkJintDebug.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkJintDebug.Location = New System.Drawing.Point(128, 182)
        Me.chkJintDebug.Name = "chkJintDebug"
        Me.chkJintDebug.Size = New System.Drawing.Size(168, 17)
        Me.chkJintDebug.TabIndex = 6
        Me.chkJintDebug.Text = "Log diagnostic Jint information"
        Me.chkJintDebug.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Thales header length:"
        '
        'nudThalesHeaderLength
        '
        Me.nudThalesHeaderLength.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.LMKTool.My.MySettings.Default, "ThalesHeader", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.nudThalesHeaderLength.Location = New System.Drawing.Point(128, 105)
        Me.nudThalesHeaderLength.Name = "nudThalesHeaderLength"
        Me.nudThalesHeaderLength.Size = New System.Drawing.Size(73, 21)
        Me.nudThalesHeaderLength.TabIndex = 3
        Me.nudThalesHeaderLength.Value = Global.LMKTool.My.MySettings.Default.ThalesHeader
        '
        'chkIgnoreLMKTranslateErrors
        '
        Me.chkIgnoreLMKTranslateErrors.AutoSize = True
        Me.chkIgnoreLMKTranslateErrors.Checked = Global.LMKTool.My.MySettings.Default.IgnoreLMKErrors
        Me.chkIgnoreLMKTranslateErrors.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIgnoreLMKTranslateErrors.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.LMKTool.My.MySettings.Default, "IgnoreLMKErrors", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkIgnoreLMKTranslateErrors.Location = New System.Drawing.Point(128, 136)
        Me.chkIgnoreLMKTranslateErrors.Name = "chkIgnoreLMKTranslateErrors"
        Me.chkIgnoreLMKTranslateErrors.Size = New System.Drawing.Size(155, 17)
        Me.chkIgnoreLMKTranslateErrors.TabIndex = 4
        Me.chkIgnoreLMKTranslateErrors.Text = "Ignore LMK translate errors"
        Me.chkIgnoreLMKTranslateErrors.UseVisualStyleBackColor = True
        '
        'txtSleepInterval
        '
        Me.txtSleepInterval.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LMKTool.My.MySettings.Default, "ThalesDelay", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtSleepInterval.Location = New System.Drawing.Point(128, 78)
        Me.txtSleepInterval.Name = "txtSleepInterval"
        Me.txtSleepInterval.Size = New System.Drawing.Size(297, 21)
        Me.txtSleepInterval.TabIndex = 2
        Me.txtSleepInterval.Text = Global.LMKTool.My.MySettings.Default.ThalesDelay
        '
        'txtThalesPort
        '
        Me.txtThalesPort.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LMKTool.My.MySettings.Default, "ThalesPort", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtThalesPort.Location = New System.Drawing.Point(128, 50)
        Me.txtThalesPort.Name = "txtThalesPort"
        Me.txtThalesPort.Size = New System.Drawing.Size(297, 21)
        Me.txtThalesPort.TabIndex = 1
        Me.txtThalesPort.Text = Global.LMKTool.My.MySettings.Default.ThalesPort
        '
        'txtThalesIP
        '
        Me.txtThalesIP.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LMKTool.My.MySettings.Default, "ThalesIP", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtThalesIP.Location = New System.Drawing.Point(128, 23)
        Me.txtThalesIP.Name = "txtThalesIP"
        Me.txtThalesIP.Size = New System.Drawing.Size(297, 21)
        Me.txtThalesIP.TabIndex = 0
        Me.txtThalesIP.Text = Global.LMKTool.My.MySettings.Default.ThalesIP
        '
        'txtDBConfigScript
        '
        Me.txtDBConfigScript.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LMKTool.My.MySettings.Default, "DBScript", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtDBConfigScript.Location = New System.Drawing.Point(128, 20)
        Me.txtDBConfigScript.Name = "txtDBConfigScript"
        Me.txtDBConfigScript.Size = New System.Drawing.Size(297, 21)
        Me.txtDBConfigScript.TabIndex = 0
        Me.txtDBConfigScript.Text = Global.LMKTool.My.MySettings.Default.DBScript
        '
        'txtKeyUpdateScript
        '
        Me.txtKeyUpdateScript.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LMKTool.My.MySettings.Default, "UpdateScript", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtKeyUpdateScript.Location = New System.Drawing.Point(128, 78)
        Me.txtKeyUpdateScript.Name = "txtKeyUpdateScript"
        Me.txtKeyUpdateScript.Size = New System.Drawing.Size(297, 21)
        Me.txtKeyUpdateScript.TabIndex = 4
        Me.txtKeyUpdateScript.Text = Global.LMKTool.My.MySettings.Default.UpdateScript
        '
        'txtKeySelectScript
        '
        Me.txtKeySelectScript.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LMKTool.My.MySettings.Default, "SelectScript", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtKeySelectScript.Location = New System.Drawing.Point(128, 50)
        Me.txtKeySelectScript.Name = "txtKeySelectScript"
        Me.txtKeySelectScript.Size = New System.Drawing.Size(297, 21)
        Me.txtKeySelectScript.TabIndex = 2
        Me.txtKeySelectScript.Text = Global.LMKTool.My.MySettings.Default.SelectScript
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 521)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.cmdTranslateFromOldLMK)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LMK Tool"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudThalesHeaderLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDBConfigScript As System.Windows.Forms.TextBox
    Friend WithEvents txtKeySelectScript As System.Windows.Forms.TextBox
    Friend WithEvents txtKeyUpdateScript As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectConfigScript As System.Windows.Forms.Button
    Friend WithEvents cmdSelectKeySelectionScript As System.Windows.Forms.Button
    Friend WithEvents cmdSelectKeyUpdateScript As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSleepInterval As System.Windows.Forms.TextBox
    Friend WithEvents txtThalesPort As System.Windows.Forms.TextBox
    Friend WithEvents txtThalesIP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkIgnoreLMKTranslateErrors As System.Windows.Forms.CheckBox
    Friend WithEvents cmdTranslateFromOldLMK As System.Windows.Forms.Button
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkDoNotUpdateDB As System.Windows.Forms.CheckBox
    Friend WithEvents chkJintDebug As System.Windows.Forms.CheckBox
    Friend WithEvents nudThalesHeaderLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
