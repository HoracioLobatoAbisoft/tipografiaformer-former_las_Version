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
Imports FormerLib.FormerEnum


''' <summary>
'''DAO Class for table T_pagamenti
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class PagamentiDAO
    Inherits _PagamentiDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    'CONTROLLO SE UN DOCUMENTO E' INTERAMENTE PAGATO
    'LO METTO QUI PERCHE NON ESISTE UNA CLASSE A CAVALLO SIA DI COSTI CHE DI RICAVI

    Public Function GetLastByIdRub(IdRub) As Pagamento
        Dim ris As Pagamento = Nothing

        Dim l As List(Of Pagamento) = FindAll(LFM.Pagamento.DataPag.Name & " DESC",
                                              New LUNA.LunaSearchParameter(LFM.Pagamento.IdRub, IdRub))

        If l.Count Then ris = l(0)

        Return ris
    End Function

    Public Function ImportoAncoraDaPagareDocumento(IdDoc As Integer, IdTipoDoc As enTipoVoceContab) As Decimal

        Dim ris As Decimal = 0
        'Dim Voce

        If IdTipoDoc = enTipoVoceContab.VoceAcquisto Then
            Using Costo As New Costo
                Costo.Read(IdDoc)
                ris = Costo.TotaleAncoraDaPagare
            End Using
        Else
            Using Ricavo As New Ricavo
                Ricavo.Read(IdDoc)
                ris = Ricavo.TotaleAncoraDaPagare
            End Using
        End If

        'Dim TotGiaPagato As Decimal = 0
        'Using mgr As New PagamentiDAO
        '    Dim lP As List(Of Pagamento) = mgr.FindAll(New LUNA.LunaSearchParameter("IdFat", IdDoc), _
        '                                               New LUNA.LunaSearchParameter("Tipo", IdTipoDoc))

        '    For Each singP As Pagamento In lP
        '        TotGiaPagato += singP.Importo
        '    Next

        'End Using
        'Dim TotaleDaConfrontare As Decimal = Voce.totale

        'If TypeOf (Voce) Is cContabRicavi Then
        '    If Voce.esigibilitaiva = enEsigibilitaIVA.SplitPayment Then
        '        TotaleDaConfrontare = Voce.importo
        '    End If
        'End If
        'Dim c As New Costo
        'c.totalea
        'ris = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Voce.totale - TotGiaPagato, 2)

        If ris < 0 Then ris = 0 'aggiunto per risolvere il problema degli importi negativi

        Return ris

    End Function


End Class