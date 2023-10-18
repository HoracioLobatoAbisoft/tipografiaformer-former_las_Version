Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrMagazzinoBusiness

    Public Shared Function LegaCostoACarico(ByRef C As Costo,
                                            Optional CaricoDaCollegare As CaricoDiMagazzino = Nothing,
                                            Optional CreaNuovoCaricoMagazzinoSeMancante As Boolean = False,
                                            Optional CreaNuoveRisorseSeMancanti As Boolean = False,
                                            Optional CreaNuoviMovimentiMagazzinoSeMancanti As Boolean = False) As CaricoDiMagazzino

        Dim cm As CaricoDiMagazzino = Nothing

        If CaricoDaCollegare Is Nothing Then
            cm = CaricoMagazzinoDaCosto(C, CreaNuovoCaricoMagazzinoSeMancante)
        Else
            cm = CaricoDaCollegare
            cm.TipoDocRiferimento = C.Tipo
            cm.DataCarico = C.DataCosto
            cm.NumeroDocRiferimento = C.Numero
            cm.IdCosto = C.IdCosto
        End If

        If Not cm Is Nothing Then
            C.IdCaricoMagazzino = cm.IdCaricoMagazzino
            cm.IdStatoInterno = enStatoFEInterno.Collegato
            C.StatoFEInterno = enStatoFEInterno.Collegato

            For Each movmagaz In cm.ListaMovimenti
                If movmagaz.IdVoceCosto = 0 Then

                    Dim riga As VoceCosto = C.ListaVociFatturaOnlyThis.Find(Function(x) x.Codice = movmagaz.CodiceForn And x.Qta = movmagaz.Qta And cm.ListaMovimenti.FindAll(Function(z) z.IdVoceCosto = x.IdVoceCosto).Count = 0)

                    If Not riga Is Nothing Then
                        'qui va agganciata
                        movmagaz.IdVoceCosto = riga.IdVoceCosto
                        riga.IdMovMagaz = movmagaz.IdCarMag
                        movmagaz.IdFat = C.IdCosto
                        movmagaz.Save()
                        riga.Save()

                    Else
                        'qui non c'e' una riga nella fattura a cui agganciare questo movimento di carico

                        cm.IdStatoInterno = enStatoFEInterno.Anomalia
                        C.StatoFEInterno = enStatoFEInterno.Anomalia
                    End If
                End If
            Next

            Dim CounterRigheDaValutare As Integer = 0
            Dim CounterRigheAgganciate As Integer = 0

            For Each riga In C.ListaVociFatturaOnlyThis

                If MgrFormerException.ValutareRigaFatturaComeRisorsa(riga) Then
                    CounterRigheDaValutare += 1
                    If cm.ListaMovimenti.FindAll(Function(x) x.IdVoceCosto = riga.IdVoceCosto).Count <> 0 Then
                        CounterRigheAgganciate += 1
                    Else
                        If CreaNuoviMovimentiMagazzinoSeMancanti Then
                            'questa riga va completamente creata e aggiunta al documento di carico
                            'devo prima cercarela risorsa 
                            'se non la trovo devo crearla e poi metterla nel carico di magazzino

                            Using mgr As New MagazzinoDAO
                                Dim MovCampione As MovimentoMagazzino = Nothing
                                Dim lMov As List(Of MovimentoMagazzino) = Nothing

                                If riga.Codice.Trim.Length Then

                                    Dim TrovatiSoloZeri As Boolean = True

                                    For Each singchar In riga.Codice
                                        If singchar.ToString.ToLower <> "0" Then
                                            TrovatiSoloZeri = False
                                            Exit For
                                        End If
                                    Next

                                    If TrovatiSoloZeri = False Then
                                        lMov = mgr.FindAll(New LUNA.LunaSearchOption() With {.Top = 1, .OrderBy = ""},
                                                            New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.CodiceForn, riga.Codice),
                                                            New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdForn, C.IdRub))
                                        If lMov.Count Then MovCampione = lMov(0)
                                    End If

                                End If

                                If MovCampione Is Nothing Then
                                    'tento per descrizione
                                    If riga.Descrizione.Trim.Length AndAlso riga.Descrizione.Trim.Length > 9 Then
                                        lMov = mgr.FindAll(New LUNA.LunaSearchOption() With {.Top = 1, .OrderBy = ""},
                                                                                                                  New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.DescrForn, riga.Descrizione),
                                                                                                                  New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdForn, C.IdRub))
                                        If lMov.Count Then MovCampione = lMov(0)
                                    End If
                                End If

                                If MovCampione Is Nothing Then
                                    'tento per descrizione
                                    If riga.Descrizione.Trim.Length AndAlso riga.Descrizione.Trim.Length > 9 Then

                                        MovCampione = mgr.getMovCampioneByVoceCosto(riga.Descrizione.Trim, C.IdRub)

                                    End If
                                End If

                                If Not MovCampione Is Nothing Then
                                    'qui l'ho trovata 

                                    Using v As New MovimentoMagazzino
                                        v.IdRis = MovCampione.IdRis
                                        v.DataMov = C.DataCosto
                                        v.CodiceForn = MovCampione.CodiceForn
                                        v.DescrForn = riga.Descrizione
                                        v.TipoMov = enTipoMovMagaz.Carico
                                        v.IdForn = MovCampione.IdForn
                                        v.IdVoceCosto = riga.IdVoceCosto
                                        v.IdFat = C.IdCosto
                                        v.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
                                        v.Qta = riga.Qta
                                        v.Prezzo = riga.Totale
                                        v.PrezzoUnit = riga.PrezzoUnit
                                        v.IdCaricoMagazzino = cm.IdCaricoMagazzino

                                        v.Save()
                                        riga.IdMovMagaz = v.IdCarMag
                                        riga.Save()

                                    End Using
                                    CounterRigheAgganciate += 1

                                Else
                                    'qui devo proprio creare la risorsa
                                    If CreaNuoveRisorseSeMancanti Then
                                        Using r As New Risorsa
                                            r.TipoRis = enTipoProdCom.NonSpecificato
                                            r.Codice = riga.Codice
                                            r.Descrizione = riga.Descrizione
                                            r.Stato = enStato.Attivo
                                            r.Save()

                                            Using v As New MovimentoMagazzino
                                                v.IdRis = r.IdRis
                                                v.DataMov = C.DataCosto
                                                v.CodiceForn = riga.Codice
                                                v.DescrForn = riga.Descrizione
                                                v.TipoMov = enTipoMovMagaz.Carico
                                                v.IdForn = C.IdRub
                                                v.IdVoceCosto = riga.IdVoceCosto
                                                v.IdFat = C.IdCosto
                                                v.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
                                                v.Qta = riga.Qta
                                                v.Prezzo = riga.Totale
                                                v.PrezzoUnit = riga.PrezzoUnit
                                                v.IdCaricoMagazzino = cm.IdCaricoMagazzino

                                                v.Save()
                                                riga.IdMovMagaz = v.IdCarMag
                                                riga.Save()
                                                CounterRigheAgganciate += 1
                                            End Using
                                        End Using
                                    End If

                                End If

                            End Using
                        End If
                    End If
                End If
            Next

            If CounterRigheDaValutare Then
                If CounterRigheAgganciate <> CounterRigheDaValutare Then
                    C.StatoFEInterno = enStatoFEInterno.Anomalia
                    cm.IdStatoInterno = enStatoFEInterno.Anomalia
                Else
                    
                    C.StatoFEInterno = enStatoFEInterno.Collegato
                    cm.IdStatoInterno = enStatoFEInterno.Collegato
                End If
            End If


            If cm.ListaMovimenti.Count Then
                'qui in ogni caso salvo solo se il documento di carico ha qualcosa dentro 
                'vuoto non serve a niente
                If C.IsChanged Then C.Save()
                If cm.IsChanged Then cm.Save()
            Else
                'cancello il documento di carico appena creato
                Using mgr As New CarichiDiMagazzinoDAO
                    mgr.Delete(cm.IdCaricoMagazzino)
                End Using
            End If
        Else
            'qui non ho un carico di magazzino 
            'vado a creare i movimetni di magazzino direttamente pe ril costo senza creare carichi 
            'automatici
            Dim CounterRigheDaValutare As Integer = 0
            Dim CounterRigheAgganciate As Integer = 0

            For Each riga In C.ListaVociFatturaOnlyThis

                If MgrFormerException.ValutareRigaFatturaComeRisorsa(riga) Then
                    CounterRigheDaValutare += 1
                    If riga.IdMovMagaz = 0 Then


                        If CreaNuoviMovimentiMagazzinoSeMancanti Then
                            'questa riga va completamente creata e aggiunta al documento di carico
                            'devo prima cercarela risorsa 
                            'se non la trovo devo crearla e poi metterla nel carico di magazzino

                            Using mgr As New MagazzinoDAO
                                Dim MovCampione As MovimentoMagazzino = Nothing
                                Dim lMov As List(Of MovimentoMagazzino) = Nothing

                                If riga.Codice.Trim.Length Then
                                    lMov = mgr.FindAll(New LUNA.LunaSearchOption() With {.Top = 1, .OrderBy = ""},
                                                                                                                      New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.CodiceForn, riga.Codice),
                                                                                                                      New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdForn, C.IdRub))
                                    If lMov.Count Then MovCampione = lMov(0)
                                End If

                                If MovCampione Is Nothing Then
                                    'tento per descrizione
                                    If riga.Descrizione.Trim.Length AndAlso riga.Descrizione.Trim.Length > 9 Then
                                        lMov = mgr.FindAll(New LUNA.LunaSearchOption() With {.Top = 1, .OrderBy = ""},
                                                                                                                      New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.DescrForn, riga.Descrizione),
                                                                                                                      New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdForn, C.IdRub))
                                        If lMov.Count Then MovCampione = lMov(0)
                                    End If
                                End If

                                If MovCampione Is Nothing Then
                                    'tento per descrizione
                                    If riga.Descrizione.Trim.Length AndAlso riga.Descrizione.Trim.Length > 9 Then

                                        MovCampione = mgr.getMovCampioneByVoceCosto(riga.Descrizione.Trim, C.IdRub)

                                    End If
                                End If

                                If Not MovCampione Is Nothing Then
                                    'qui l'ho trovata 

                                    Using v As New MovimentoMagazzino
                                        v.IdRis = MovCampione.IdRis
                                        v.DataMov = C.DataCosto
                                        v.CodiceForn = MovCampione.CodiceForn
                                        v.DescrForn = riga.Descrizione
                                        v.TipoMov = enTipoMovMagaz.Carico
                                        v.IdForn = MovCampione.IdForn
                                        v.IdVoceCosto = riga.IdVoceCosto
                                        v.IdFat = C.IdCosto
                                        v.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
                                        v.Qta = riga.Qta
                                        v.Prezzo = riga.Totale
                                        v.PrezzoUnit = riga.PrezzoUnit
                                        'v.IdCaricoMagazzino = cm.IdCaricoMagazzino

                                        v.Save()
                                        riga.IdMovMagaz = v.IdCarMag
                                        riga.Save()

                                    End Using
                                    CounterRigheAgganciate += 1

                                Else
                                    'qui devo proprio creare la risorsa
                                    If CreaNuoveRisorseSeMancanti Then
                                        Using r As New Risorsa
                                            r.TipoRis = enTipoProdCom.NonSpecificato
                                            r.Codice = riga.Codice
                                            r.Descrizione = riga.Descrizione
                                            r.Stato = enStato.Attivo
                                            r.Save()

                                            Using v As New MovimentoMagazzino
                                                v.IdRis = r.IdRis
                                                v.DataMov = C.DataCosto
                                                v.CodiceForn = riga.Codice
                                                v.DescrForn = riga.Descrizione
                                                v.TipoMov = enTipoMovMagaz.Carico
                                                v.IdForn = C.IdRub
                                                v.IdVoceCosto = riga.IdVoceCosto
                                                v.IdFat = C.IdCosto
                                                v.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
                                                v.Qta = riga.Qta
                                                v.Prezzo = riga.Totale
                                                v.PrezzoUnit = riga.PrezzoUnit
                                                'v.IdCaricoMagazzino = cm.IdCaricoMagazzino

                                                v.Save()
                                                riga.IdMovMagaz = v.IdCarMag
                                                riga.Save()
                                                CounterRigheAgganciate += 1
                                            End Using
                                        End Using
                                    End If

                                End If

                            End Using
                        End If
                    Else
                        CounterRigheAgganciate += 1
                    End If

                End If
            Next

            If CounterRigheDaValutare Then
                If C.Tipo <> enTipoDocumento.FatturaRiepilogativa Then
                    If CounterRigheAgganciate <> CounterRigheDaValutare Then
                        C.StatoFEInterno = enStatoFEInterno.Anomalia
                    Else
                        C.StatoFEInterno = enStatoFEInterno.Collegato
                    End If
                End If

            End If

            If C.IsChanged Then C.Save()

        End If

        Return cm
    End Function

    Public Shared Function CaricoMagazzinoDaCosto(C As Costo,
                                                  Optional CreaNuovoInCaso As Boolean = False) As CaricoDiMagazzino

        Dim ris As CaricoDiMagazzino = Nothing

        Using mgr As New CarichiDiMagazzinoDAO
            Dim l As List(Of CaricoDiMagazzino) = Nothing

            l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdCosto, C.IdCosto))

            If l.Count = 0 Then
                l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.NumeroDocRiferimento, C.Numero),
                                                              New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdRub, C.IdRub),
                                                              New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.TipoDocRiferimento, C.Tipo),
                                                              New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdAzienda, C.IdAzienda))

            End If

            If l.Count Then
                'qui lo lego 

                ris = l(0)

                If ris.IdCosto <> C.IdCosto Then
                    ris.IdCosto = C.IdCosto
                End If

                If ris.IdCaricoMagazzino <> C.IdCaricoMagazzino Then
                    C.IdCaricoMagazzino = ris.IdCaricoMagazzino
                End If

                ris.IdStatoInterno = enStatoFEInterno.Collegato
                ris.Save()

            Else
                If CreaNuovoInCaso Then

                    'qui lo creo
                    ris = New CaricoDiMagazzino
                    ris.IdAzienda = C.IdAzienda
                    ris.DataCarico = C.DataCosto
                    ris.IdUtCarico = FormerConst.UtentiSpecifici.IdUtenteAdmin
                    ris.IdRub = C.IdRub
                    ris.NumeroDocRiferimento = C.Numero
                    Dim TipoDoc As enTipoDocumento
                    If C.Tipo = enTipoDocumento.FatturaRiepilogativa OrElse C.Tipo = enTipoDocumento.Fattura Then
                        TipoDoc = enTipoDocumento.Fattura
                    ElseIf C.Tipo = enTipoDocumento.DDT Then
                        TipoDoc = enTipoDocumento.DDT
                    End If
                    ris.TipoDocRiferimento = TipoDoc
                    ris.IdCosto = C.IdCosto
                    ris.IdStatoInterno = enStatoFEInterno.Collegato
                    ris.Save()
                End If

            End If

        End Using

        Return ris

    End Function

End Class
