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
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table Td_coloristampa
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ColoriStampaWDAO
    Inherits _ColoriStampaWDAO

    Public Function GetbyIdReparto(IdReparto As Integer) As List(Of ColoreStampaW)
        Dim ris As New List(Of ColoreStampaW)

        Dim IdRepartoSel As String = String.Empty

        If IdReparto = enRepartoWeb.StampaOffset Or IdReparto = enRepartoWeb.Packaging Then
            IdRepartoSel = enRepartoWeb.StampaOffset & "," & enRepartoWeb.Packaging
        Else
            IdRepartoSel = IdReparto
        End If

        Dim Sql As String = "SELECT * FROM TD_COLORISTAMPA WHERE IdColoreStampa IN (SELECT DISTINCT IdColoreStampa from T_listinobase L, T_preventivazione P WHERE L.idprev = p.idprev and p.TipoProd IN (" & IdRepartoSel & "))order by descrizione"

        ris = GetData(Sql)

        Return ris
    End Function


    Public Function GetColoriStampa(IdPrev As Integer,
                                    IdFormatoProdotto As Integer,
                                    IdTipoCarta As Integer) As List(Of ColoreStampaW)
        Dim ris As New List(Of ColoreStampaW)

        Dim Sql As String = "SELECT * from TD_COloriStampa where IdColoreStampa in (select distinct IdColoreStampa from T_LISTINOBASE  where idprev = " &
            IdPrev & " and idformprod = " & IdFormatoProdotto & " and idTipoCarta = " & IdTipoCarta & ") order by descrizione"

        ris = GetData(Sql)

        Return ris
    End Function

End Class