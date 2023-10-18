#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient


''' <summary>
'''DAO Class for table Td_tipocommessa
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class TipoCommesseDAO
    Inherits _TipoCommesseDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function LeggiNumSpazi(ByVal Id As Integer) As Integer
        Dim Ris As Integer = 1

        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = "SELECT NumSpazi FROM TD_TipoCommessa where IdTipoCom = " & Id
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            myReader.Read()
            If myReader.HasRows Then
                If Not myReader("NumSpazi") Is DBNull.Value Then
                    Ris = myReader("NumSpazi").ToString
                End If
            End If
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Public Function SalvaLavorazioni(Tc As TipoCommessa, ByVal ListaIdSelezionati As Integer()) As Integer

        Dim Ris As Integer = 0
        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _Cn
            Dim Sql As String = "DELETE FROM TR_Lavori where idtipocom = " & Tc.IdTipoCom
            UpdateCommand.CommandText = Sql
            UpdateCommand.ExecuteNonQuery()
            Dim I As Integer = 0
            For I = 0 To ListaIdSelezionati.GetUpperBound(0)
                Sql = "INSERT INTO TR_LAVORI (IdLav,IdTipoCom,Ordine) VALUES(" & ListaIdSelezionati(I) & "," & Tc.IdTipoCom & "," & I & ")"
                UpdateCommand.CommandText = Sql
                UpdateCommand.ExecuteNonQuery()
            Next
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try

        Return Ris

    End Function
End Class