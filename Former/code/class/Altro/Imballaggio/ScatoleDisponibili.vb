Public Class ScatoleDisponibili

    Public Property ScatoleDisponibili As List(Of TipoScatola)

    Public Sub New(Cubetto As Cubetto)

        'CREO LA COLLEZIONE DI TUTTE LE SCATOLE DISPONIBILI grandi almeno le dimensioni di un singolo cubetto 
        Dim S1 As New TipoScatola(225, 310, 130, FormerLib.FormerEnum.enTipologiaScatola.Scatola)
        Dim S2 As New TipoScatola(225, 310, 290, FormerLib.FormerEnum.enTipologiaScatola.Scatola)
        Dim S3 As New TipoScatola(225, 310, 230, FormerLib.FormerEnum.enTipologiaScatola.Scatola)
        Dim S4 As New TipoScatola(225, 310, 350, FormerLib.FormerEnum.enTipologiaScatola.Scatola)
        Dim S5 As New TipoScatola(180, 220, 65, FormerLib.FormerEnum.enTipologiaScatola.Busta)
        Dim S6 As New TipoScatola(180, 220, 130, FormerLib.FormerEnum.enTipologiaScatola.Busta)
        Dim S7 As New TipoScatola(250, 360, 310, FormerLib.FormerEnum.enTipologiaScatola.Scatola)

        Dim S99 As New TipoScatola(Cubetto.Lunghezza, Cubetto.Larghezza, Cubetto.Profondita, FormerLib.FormerEnum.enTipologiaScatola.ImballoPersonalizzato)
        S99.Custom = True

        ScatoleDisponibili = New List(Of TipoScatola)

        'se il volume della scatola contiene almeno un cubetto 
        Dim Aggiunto As Boolean = False
        If AggiungiScatola(S1, Cubetto) Then Aggiunto = True
        If AggiungiScatola(S2, Cubetto) Then Aggiunto = True
        If AggiungiScatola(S3, Cubetto) Then Aggiunto = True
        If AggiungiScatola(S4, Cubetto) Then Aggiunto = True
        If AggiungiScatola(S5, Cubetto) Then Aggiunto = True
        If AggiungiScatola(S6, Cubetto) Then Aggiunto = True
        If AggiungiScatola(S7, Cubetto) Then Aggiunto = True

        'la quinta custom la aggiungo solo se non entra nelle altre 
        If Aggiunto = False Then AggiungiScatola(S99, Cubetto)

    End Sub

    Private Function AggiungiScatola(Scatola As TipoScatola, Cubetto As Cubetto) As Boolean
        Dim Ris As Boolean = False
        If Scatola.Volume >= Cubetto.Volume Then
            If Scatola.Lunghezza >= Cubetto.Lunghezza And Scatola.Larghezza >= Cubetto.Larghezza And Scatola.Profondita >= Cubetto.Profondita Then
                Scatola.CalcolaParametriRiempimento(Cubetto)
                ScatoleDisponibili.Add(Scatola)
                Ris = True
            End If
        End If
        Return Ris
    End Function

End Class
