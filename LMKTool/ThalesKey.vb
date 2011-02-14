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

''' <summary>
''' This class represents a Thales key.
''' </summary>
''' <remarks></remarks>
Public Class ThalesKey

    ''' <summary>
    ''' Unique key name.
    ''' </summary>
    ''' <remarks></remarks>
    Public KeyName As String

    ''' <summary>
    ''' Current key value (under the old LMK).
    ''' </summary>
    ''' <remarks></remarks>
    Public KeyValue As String

    ''' <summary>
    ''' Key type (per Thales key type table).
    ''' </summary>
    ''' <remarks></remarks>
    Public KeyType As String

    ''' <summary>
    ''' New key value (under current LMK).
    ''' </summary>
    ''' <remarks></remarks>
    Public TranslatedValue As String = ""

    ''' <summary>
    ''' Returns the key length based on key contents.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Key schemes are taken into account.</remarks>
    Public Function KeyLength() As String
        Select Case KeyValue.Length
            Case 16, 17
                'Single length.
                Return "0"
            Case 32, 33
                'Double length.
                Return "1"
            Case Else
                'Triple length.
                Return "2"
        End Select
    End Function

End Class
