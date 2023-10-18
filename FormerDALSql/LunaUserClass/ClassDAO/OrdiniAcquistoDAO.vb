#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 30/08/2018 
#End Region


Imports System.Data.Common
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table T_ordiniacquisto
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class OrdiniAcquistoDAO
    Inherits _OrdiniAcquistoDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function Cerca(Optional IdFornitore As Integer = 0,
                          Optional IdRisorsa As Integer = 0) As List(Of OrdineAcquisto)

        Dim Ls As New List(Of OrdineAcquisto)
        Try

            Dim sql As String = ""
            sql = "SELECT * from T_OrdiniAcquisto "

            If IdFornitore Then
                sql &= " WHERE IdOrdineAcquisto in (SELECT Distinct IdOrdineAcquisto FROM t_magaz WHERE idforn = " & IdFornitore & " and tipomov = " & enTipoMovMagaz.RichiestaAcquisto & ")"
            End If

            If IdRisorsa Then

                If sql.IndexOf("WHERE") <> -1 Then
                    sql &= " AND "
                Else
                    sql &= " WHERE "
                End If

                sql &= " IdOrdineAcquisto in (SELECT Distinct IdOrdineAcquisto FROM t_magaz WHERE idforn = " & IdFornitore & " and tipomov = " & enTipoMovMagaz.RichiestaAcquisto & ")"
            End If

            sql &= " ORDER BY Quando Desc"

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls

    End Function



End Class