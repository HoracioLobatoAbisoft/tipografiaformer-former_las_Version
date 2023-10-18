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
'''DAO Class for table T_prodotti
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ProdottiDAO
    Inherits _ProdottiDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function Exists(ByVal Codice As String, ByVal IdRif As Integer) As Boolean
        Dim Ris As Boolean = False

        If Codice.Trim.Length Then

            Try

                Dim myCommand As SqlCommand = _cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT IdProd from t_prodotti "
                sql &= " WHERE "
                sql &= " Codice = " & Ap(Codice)
                sql &= " AND IdProd<>" & IdRif

                myCommand.CommandText = sql
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()

                myReader.Read()

                Ris = myReader.HasRows

                myReader.Close()
                myCommand.Dispose()

            Catch ex As Exception
                ManageError(ex)
            End Try

        End If

        Return Ris

    End Function

    Public Function ReadEx(Optional ByVal Id As Integer = 0, Optional ByVal CodiceProd As String = "", Optional ByVal IdRub As Integer = 0) As Prodotto
        Dim P As Prodotto = Nothing

        If Id Then
            P = New Prodotto
            P.Read(Id)
        Else
            Dim l As List(Of Prodotto) = Nothing
            Using mgr As New ProdottiDAO
                l = mgr.FindAll(New LUNA.LunaSearchParameter("Codice", CodiceProd))
            End Using
            If l.Count Then
                P = l(0)
            End If
        End If

        If Not P Is Nothing Then
            If IdRub Then
                Dim l As List(Of ListinoClienti) = Nothing

                Using mgr As New ListinoClientiDAO
                    l = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", IdRub), _
                                                                                New LUNA.LunaSearchParameter("IdProd", P.IdProd))
                End Using
                If l.Count Then
                    P.Prezzo = l(0).PrezzoRis
                End If
            End If
        End If

        Return P
    End Function

    Public Function SalvaLavorazioni(P As Prodotto, ByVal ListaIdSelezionati As Integer()) As Integer

        Dim Ris As Integer = 0
        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _cn
            Dim Sql As String = "DELETE FROM TR_Lavori where idprod = " & P.IdProd

            UpdateCommand.CommandText = Sql
            UpdateCommand.ExecuteNonQuery()

            Dim I As Integer = 0

            For I = 0 To ListaIdSelezionati.GetUpperBound(0)

                Sql = "INSERT INTO TR_LAVORI (IdLav,IdProd,Ordine) VALUES(" & ListaIdSelezionati(I) & "," & P.IdProd & "," & I & ")"
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