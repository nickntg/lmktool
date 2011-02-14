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

Imports System.Data.SqlClient

''' <summary>
''' This is a helper class for Jint scripts. An instance of this object
''' is passed as a parameter to Jint scripts to achieve interoperability.
''' </summary>
''' <remarks></remarks>
Public Class JintHelper

    ''' <summary>
    ''' Sql connection to database.
    ''' </summary>
    ''' <remarks></remarks>
    Public sqlCon As SqlConnection

    ''' <summary>
    ''' If an active transaction takes place, its
    ''' value is assigned to this variable.
    ''' </summary>
    ''' <remarks></remarks>
    Public sqlTrans As SqlTransaction

    ''' <summary>
    ''' Keys to be migrated.
    ''' </summary>
    ''' <remarks></remarks>
    Public Keys As List(Of ThalesKey)

    ''' <summary>
    ''' Dataset with key information read from the database.
    ''' </summary>
    ''' <remarks></remarks>
    Public KeysDS As DataSet

    ''' <summary>
    ''' Clears all keys to be migrated.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearKeys()
        Keys = New List(Of ThalesKey)
    End Sub

    ''' <summary>
    ''' Executes a stored procedure without parameters 
    ''' to read keys from a database.
    ''' </summary>
    ''' <param name="sprocName"></param>
    ''' <remarks></remarks>
    Public Sub ExecuteSproc(ByVal sprocName As String)
        Using scmd As SqlCommand = New SqlCommand(sprocName, sqlCon)
            scmd.CommandType = CommandType.StoredProcedure
            Using sda As SqlDataAdapter = New SqlDataAdapter(scmd)
                KeysDS = New DataSet
                sda.Fill(KeysDS)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Executes a select statement to read keys from a database.
    ''' </summary>
    ''' <param name="sqlStmt"></param>
    ''' <remarks></remarks>
    Public Sub ExecuteSelect(ByVal sqlStmt As String)
        Using scmd As SqlCommand = New SqlCommand(sqlStmt, sqlCon)
            scmd.CommandType = CommandType.Text
            Using sda As SqlDataAdapter = New SqlDataAdapter(scmd)
                KeysDS = New DataSet
                sda.Fill(KeysDS)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Executes an update statement against a database.
    ''' </summary>
    ''' <param name="sqlStmt"></param>
    ''' <remarks></remarks>
    Public Sub ExecuteUpdate(ByVal sqlStmt As String)
        Using scmd As SqlCommand = New SqlCommand(sqlStmt, sqlCon)
            scmd.Transaction = sqlTrans
            scmd.CommandType = CommandType.Text
            scmd.ExecuteNonQuery()
        End Using
    End Sub

    ''' <summary>
    ''' Returns the number of keys to be migrated.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecCount() As Integer
        Return KeysDS.Tables(0).Rows.Count
    End Function

    ''' <summary>
    ''' Returns an item from the dataset of keys.
    ''' </summary>
    ''' <param name="colName"></param>
    ''' <param name="idx"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Item(ByVal colName As String, ByVal idx As Integer) As String
        Return Convert.ToString(KeysDS.Tables(0).Rows(idx).Item(colName))
    End Function

    ''' <summary>
    ''' Adds a new key to the database.
    ''' </summary>
    ''' <param name="keyName"></param>
    ''' <param name="keyValue"></param>
    ''' <param name="keyType"></param>
    ''' <remarks></remarks>
    Public Sub AddKey(ByVal keyName As String, ByVal keyValue As String, ByVal keyType As String)
        Dim k As New ThalesKey
        k.KeyName = keyName
        k.KeyValue = keyValue
        k.KeyType = keyType
        Keys.Add(k)
    End Sub

End Class
