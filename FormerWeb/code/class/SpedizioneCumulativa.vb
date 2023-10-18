Imports FormerDALWeb
Imports FormerBusinessLogicInterface

Public Class MGRSpedizioniCumulative

    Public Function CalcolaSpedizioniCumulative(ListO As List(Of ProdottoInCarrello)) As List(Of SpedizioneCumulativa)

        Dim ListSped As New List(Of SpedizioneCumulativa)

        'qui accorpo le spedizioni
        For Each O As ProdottoInCarrello In ListO
            Dim sped As SpedizioneCumulativa = ListSped.Find(Function(x) x.Quando = O.DataConsegna And x.Corriere.IdCorriere = O.Corriere.IdCorriere And x.IdIndirizzo = O.IdIndirizzoSped)
            If sped Is Nothing Then
                'la aggiungo 
                sped = New SpedizioneCumulativa(O.DataConsegna)
                sped.IdIndirizzo = O.IdIndirizzoSped
                sped.Corriere = O.Corriere
                sped.Ordini.Add(O)
                ListSped.Add(sped)
            Else
                sped.Ordini.Add(O)
            End If
        Next
        Return ListSped

    End Function

    Public Function CalcolaSpedizioneCumulativa(ListO As List(Of ProdottoInCarrello),
                                                MetodoPagamento As TipoPagamentoW) As SpedizioneCumulativa

        Dim Ris As SpedizioneCumulativa = Nothing

        'qui accorpo le spedizioni

        For Each O As ProdottoInCarrello In ListO
            If Ris Is Nothing Then
                Ris = New SpedizioneCumulativa(O.DataConsegna)
                Ris.MetodoPagamento = MetodoPagamento
                Ris.Corriere = O.Corriere
            Else
                Dim Differenza As Integer = DateDiff(DateInterval.Day, Ris.Quando, O.DataConsegna)
                If Differenza > 0 Then
                    Ris.Quando = O.DataConsegna
                End If
            End If
            Ris.Ordini.Add(O)
        Next
        Return Ris

    End Function

    Public Function RiCalcolaImportoConsegnaOrdini(Ordini As List(Of OrdineWeb), MetodoPagamento As TipoPagamentoW) As SpedizioneCumulativa

        Dim ris As SpedizioneCumulativa = Nothing

        Dim PesoKg As Integer = 0
        Dim PesoVolumetrico As Integer = 0
        Dim PrezzoTotaleOrdini As Decimal = 0
        Dim Corriere As CorriereW = Nothing
        For Each O As OrdineWeb In Ordini
            If ris Is Nothing Then
                ris = New SpedizioneCumulativa(O.DataPrevProduzione)
                Corriere = New CorriereW
                Corriere.Read(O.IdCorriere)
            Else
                Dim Differenza As Integer = DateDiff(DateInterval.Day, ris.Quando, O.DataPrevProduzione)
                If Differenza > 0 Then
                    ris.Quando = O.DataPrevProduzione
                End If
            End If
            PesoKg += O.Peso
            PesoVolumetrico += O.PesoVolumetrico
            PrezzoTotaleOrdini += O.PrezzoCalcolatoNetto
        Next

        ris.ImportoRicalcolato = MgrCorriere.CalcolaTariffa(Corriere, PesoVolumetrico, PesoKg, PrezzoTotaleOrdini, MetodoPagamento)

        Return ris

    End Function

End Class

Public Class SpedizioneCumulativa

    Public Sub New(Data As Date)
        Quando = Data
    End Sub

    Public Property Corriere As CorriereW
    Public Property IdIndirizzo As Integer
    Public Property Quando As Date
    Public Property MetodoPagamento As TipoPagamentoW
    Public ReadOnly Property QuandoStr As String
        Get
            Return Quando.ToString("yyyyMMdd")
        End Get
    End Property

    Public Property ImportoRicalcolato As Decimal = 0

    Public ReadOnly Property Importo As Decimal
        Get
            Dim ris As Decimal = 0
            'qui devo sommare il peso dei vari ordini inclusi nella spedizione cumulativa

            Dim PesoKg As Integer = 0
            Dim PesoVolumetrico As Integer = 0
            Dim PrezzoTotaleOrdini As Decimal = 0
            For Each O As ProdottoInCarrello In Ordini
                PesoKg += O.Peso
                PesoVolumetrico += O.PesoVolumetrico
                PrezzoTotaleOrdini += O.PrezzoCalcolatoNetto
            Next

            ris = MgrCorriere.CalcolaTariffa(Corriere, PesoVolumetrico, PesoKg, PrezzoTotaleOrdini, MetodoPagamento)

            Return ris
        End Get
    End Property

    Public Property Ordini As New List(Of ProdottoInCarrello)

End Class
