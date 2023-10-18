#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.11.31 
'Author: Diego Lunadei
'Date: 11/04/2016 
#End Region


Imports System.Data.Common
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table T_omaggi
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class OmaggiWDAO
    Inherits _OmaggiWDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function GetOmaggiDisponibili(Optional Tipologia As enTipologiaOmaggio = enTipologiaOmaggio.Tutto) As List(Of OmaggioW)
        Dim Ls As New List(Of OmaggioW)
        Try

            Dim SqlQuery As String = "SELECT * FROM t_omaggi WHERE idlistinoomaggio IN (SELECT DISTINCT idlistinobase FROM t_listinobase WHERE idprev = " & FormerLib.FormerConst.ProdottiParticolari.IdPreventivazioneOmaggi & ")"

            If Tipologia <> enTipologiaOmaggio.Tutto Then
                SqlQuery &= " AND tipologia = " & Tipologia
            End If

            Ls = GetData(SqlQuery)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

End Class