Imports FormerBusinessLogicInterface
Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class MgrMagazzino

    Public Shared Function GetStatisticheUtilizzo(L As List(Of MovimentoMagazzino)) As List(Of RisUtilizzoRisorsa)

        Dim Ris As New List(Of RisUtilizzoRisorsa)

        For Each mov In L

            Dim risMov As RisUtilizzoRisorsa = Ris.Find(Function(x) x.Risorsa.IdRis = mov.IdRis)

            If risMov Is Nothing Then
                risMov = New RisUtilizzoRisorsa
                risMov.Risorsa = mov.Risorsa
                'risMov.Giorno = mov.DataMov.Date
                Ris.Add(risMov)
            End If

            risMov.Movimenti.Add(mov)
        Next

        Ris.Sort(AddressOf ComparerStat)

        Return Ris

    End Function

    Private Shared Function ComparerStat(x As RisUtilizzoRisorsa, y As RisUtilizzoRisorsa) As Integer
        Dim ris As Integer = x.Risorsa.IsLastra.CompareTo(y.Risorsa.IsLastra)

        If ris = 0 Then
            ris = x.Risorsa.TipoCarta.Tipologia.CompareTo(y.Risorsa.TipoCarta.Tipologia)
            If ris = 0 Then
                ris = x.Risorsa.Descrizione.CompareTo(y.Risorsa.Descrizione)
            End If
        End If

        Return ris
    End Function

    Public Shared Function RicalcolaGiacenza(IdRis As Integer,
                                            Optional AggiornaRisorsa As Boolean = True) As Single
        Dim NewGiacenza As Single = 0
        Using mgr As New MagazzinoDAO
            If AggiornaRisorsa Then
                NewGiacenza = mgr.AggiornaQta(IdRis)
            Else
                NewGiacenza = mgr.GetGiacenzaAggiornata(IdRis)
            End If

        End Using

        Return NewGiacenza

    End Function

    Public Shared Function GetQtaScarico(C As Commessa,
                                         R As Risorsa,
                                         Optional QtaForzata As Single = 0,
                                         Optional AltezzaForzata As Single = 0,
                                         Optional LarghezzaForzata As Single = 0) As Single
        Dim ris As Single = C.Copie

        'If QtaForzata <> 0 Then ris = QtaForzata
        Dim QtaRis As Single = C.Copie
        Dim AltezzaRis As Single = C.Lungo
        Dim LarghezzaRis As Single = C.Largo

        If QtaForzata Then QtaRis = QtaForzata
        If AltezzaForzata Then AltezzaRis = AltezzaForzata
        If LarghezzaForzata Then LarghezzaRis = LarghezzaForzata


        If C.IdReparto = enRepartoWeb.StampaDigitale Then
            'qui vado a fare il calcolo

            'If R.IdUnitaMisura = enUnitaDiMisura.lastra Then

            '    Dim CmQRisorsa As Single = R.Larghezza * R.Lunghezza

            '    Dim CmQLavoro As Single = C.Largo * C.Lungo * C.Copie

            '    Dim QtaProporzione As Single = Math.Round(CmQLavoro / CmQRisorsa, 4)

            '    ris = QtaProporzione

            'ElseIf R.IdUnitaMisura = enUnitaDiMisura.bobina Then
            '    If C.ListaOrdini.Count = 1 Then
            '        Dim Ordine As Ordine = C.ListaOrdini()(0)

            '    End If
            'End If

            Dim DivisibileAPezzi As Boolean = False
            If C.ListaOrdini.Count = 1 Then
                Dim Ordine As Ordine = C.ListaOrdini()(0)

                If Ordine.ListinoBase.FormatoProdotto.IsRotolo = enSiNo.Si Then
                    'può essere diviso
                    DivisibileAPezzi = True
                End If

                If R.IdUnitaMisura = enUnitaDiMisura.lastra OrElse DivisibileAPezzi = True Then
                    'qui devo andare a fare il calcolo per capire quanto ne usa di risorsa
                    Dim LatoFissoRiferimento As Single = 0 'Ordine.ListinoBase.LatoFissoRiferimento(AltezzaValidata, LarghezzaValidata, GetQtaSelezionata)
                    If R.IdUnitaMisura = enUnitaDiMisura.lastra Then
                        'qui vedo quante lastre servono
                        Dim CmQRisorsa As Single = R.Larghezza * R.Lunghezza
                        Dim CmQLavoro As Single = LarghezzaRis * AltezzaRis * QtaRis ' C.Largo * C.Lungo * C.Copie

                        Dim QtaProporzione As Single = Math.Round(CmQLavoro / CmQRisorsa, 2)

                        ris = QtaProporzione

                    Else
                        ris = MgrCalcoliTecnici.CalcolaMq(R.Larghezza,
                                                   QtaRis,
                                                   AltezzaRis,
                                                   LarghezzaRis).AreaCalcolata

                    End If
                End If
            End If


        ElseIf C.IdReparto = enRepartoWeb.Etichette Then
            'qui per ora non faccio niente poi andra' calcolato 

        End If

        Return Math.Round(ris, 2)
    End Function

    Public Shared Function GetQtaCarico(V As VoceFattura) As Single
        Dim ris As Single = 0

        Return ris
    End Function

End Class
