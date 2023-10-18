Imports FormerLib.FormerEnum
Public Class cTipoMovMagaz
    Inherits CollectionBase

    Public Sub New(Optional ByVal OnlyManual As Boolean = True)

        Dim StatoComm As FormerLib.cEnum

        StatoComm = New FormerLib.cEnum
        StatoComm.Id = enTipoMovMagaz.Carico
        StatoComm.Descrizione = "Carico"
        InnerList.Add(StatoComm)

        'If Not OnlyManual Then

        StatoComm = New FormerLib.cEnum
        StatoComm.Id = enTipoMovMagaz.Scarico
        StatoComm.Descrizione = "Scarico"
        InnerList.Add(StatoComm)

        ' End If

        StatoComm = New FormerLib.cEnum
        StatoComm.Id = enTipoMovMagaz.Storno
        StatoComm.Descrizione = "Storno"
        InnerList.Add(StatoComm)

        If Not OnlyManual Then
            StatoComm = New FormerLib.cEnum
            StatoComm.Id = enTipoMovMagaz.Prenotazione
            StatoComm.Descrizione = "Prenotazione"
            InnerList.Add(StatoComm)
        End If

        StatoComm = New FormerLib.cEnum
        StatoComm.Id = enTipoMovMagaz.RichiestaAcquisto
        StatoComm.Descrizione = "Richiesta di acquisto"
        InnerList.Add(StatoComm)

        'StatoComm = New FormerLib.cEnum
        'StatoComm.Id = enTipoMovMagaz.Inserimento
        'StatoComm.Descrizione = "Registrazione"
        'InnerList.Add(StatoComm)

    End Sub

End Class