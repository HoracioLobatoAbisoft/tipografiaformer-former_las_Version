#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient


''' <summary>
'''DAO Class for table Faq
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class FaqDAO
    Inherits _FaqDAO
    Public Function GetTopN(IdArgomento As Integer, Optional Top As Integer = 3) As IEnumerable(Of Faq)
        Dim Ls As New List(Of Faq)
        Try

            Using myCommand As SqlCommand = _cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT top " & Top & " * from Faq "
                sql &= " where IDArgomento = " & IdArgomento
                sql &= " ORDER BY ORDINE "

                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New Faq(CType(myReader, IDataRecord))
                        'If Not myReader("IDFaq") Is DBNull.Value Then classe.IDFaq = myReader("IDFaq")
                        'If Not myReader("IDArgomento") Is DBNull.Value Then classe.IDArgomento = myReader("IDArgomento")
                        'If Not myReader("Domanda") Is DBNull.Value Then classe.Domanda = myReader("Domanda")
                        'If Not myReader("Risposta") Is DBNull.Value Then classe.Risposta = myReader("Risposta")
                        Ls.Add(classe)
                    End While
                    'Ls.Add(New Faq() With {.IDFaq = 0, .IDArgomento = IdArgomento, .Domanda = "Altro...", .Risposta = "", .Ordine = Top + 1})

                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function
End Class