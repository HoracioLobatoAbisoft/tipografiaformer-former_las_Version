Imports FormerLib.FormerEnum
Imports FormerLib
Public Class cRepartoOperatore
    Inherits CollectionBase

    Public Sub New()

        Dim StatoComm As cEnum

        StatoComm = New cEnum
        StatoComm.Id = enRepartoOperatore.StampaOffset
        StatoComm.Descrizione = "Stampa"
        InnerList.Add(StatoComm)

        StatoComm = New cEnum
        StatoComm.Id = enRepartoOperatore.FinituraSuCommessa
        StatoComm.Descrizione = "Finitura su Commessa"
        InnerList.Add(StatoComm)

        StatoComm = New cEnum
        StatoComm.Id = enRepartoOperatore.FinituraSuProdotto
        StatoComm.Descrizione = "Finitura su Prodotto"
        InnerList.Add(StatoComm)

        StatoComm = New cEnum
        StatoComm.Id = enRepartoOperatore.Imballaggio
        StatoComm.Descrizione = "Imballaggio"
        InnerList.Add(StatoComm)

        StatoComm = New cEnum
        StatoComm.Id = enRepartoOperatore.ImballaggioCorriere
        StatoComm.Descrizione = "Imballaggio Corriere"
        InnerList.Add(StatoComm)

        StatoComm = New cEnum
        StatoComm.Id = enRepartoOperatore.Consegne
        StatoComm.Descrizione = "Consegne"
        InnerList.Add(StatoComm)

    End Sub

End Class