#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 15/02/2019 
#End Region


Imports System.Data.Common
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table T_vocicosto
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class VociCostoDAO
    Inherits _VociCostoDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function ValutareRigaFatturaComeRisorsa(ByRef Riga As VoceCosto)
        Dim Ris As Boolean = True
        If Riga.Descrizione.ToLower().IndexOf("trasport") <> -1 Then
            Ris = False
        End If
        If Ris Then
            If Riga.Descrizione.ToLower().IndexOf("contribut") <> -1 Then
                Ris = False
            End If
        End If

        If Ris Then
            If Riga.Descrizione.ToLower().IndexOf("incasso") <> -1 Then
                Ris = False
            End If
        End If

        If Ris Then
            If Riga.Descrizione.ToLower().IndexOf("spese") = 0 Then
                Ris = False
            End If
        End If

        If Ris Then
            'qui devo andare a controllare le esclusioni specifiche
            Using mgr As New DecodificaVociCostoDAO
                Dim l As List(Of DecodificaVoceCosto) = mgr.FindAll(New LUNA.LSP(LFM.DecodificaVoceCosto.IdFornitore, Riga.CostoRiferimento.IdRub),
                                                                    New LUNA.LSP(LFM.DecodificaVoceCosto.TipoDecodifica, enTipoDecodificaVoceCosto.Esclusione),
                                                                    New LUNA.LSP(LFM.DecodificaVoceCosto.TextToSearch, Riga.Descrizione))
                If l.Count Then
                    Ris = False
                End If
            End Using
        End If

        Return Ris
    End Function

    Public Function DeleteByIdCosto(ByVal IdCosto As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "DELETE FROM T_VociCosto WHERE IdCosto = " & IdCosto
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function
End Class