Namespace FormerEnum

    Public Class FormerEnumHelper
        Public Shared Function TipoSorgenteStr(TipoSorgente As enFronteRetro) As String
            Dim ris As String = String.Empty

            Select Case TipoSorgente
                Case enFronteRetro.Fronte
                    ris = "Fronte"
                Case enFronteRetro.Retro
                    ris = "Retro"
                Case enFronteRetro.Copertina
                    ris = "Copertina"
            End Select

            Return ris
        End Function

        Public Shared Function TipoUnitaDiMisura(Tipo As enUnitaDiMisura) As String
            Dim ris As String = String.Empty

            Select Case Tipo
                Case enUnitaDiMisura.Pezzi
                    ris = "Pezzi"
                Case enUnitaDiMisura.kg
                    ris = "Kg"
                Case enUnitaDiMisura.l
                    ris = "litri"
                Case enUnitaDiMisura.m
                    ris = "m"
                Case enUnitaDiMisura.m2
                    ris = "m2"
                Case enUnitaDiMisura.m3
                    ris = "m3"
                Case enUnitaDiMisura.cm
                    ris = "cm"
                Case enUnitaDiMisura.cm2
                    ris = "cm2"
                Case enUnitaDiMisura.cm3
                    ris = "cm3"
                Case enUnitaDiMisura.mm
                    ris = "mm"
                Case enUnitaDiMisura.bobina
                    ris = "Bobina"
                Case enUnitaDiMisura.lastra
                    ris = "Lastra"
            End Select

            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.Pezzi, .Descrizione = "Pezzi"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.kg, .Descrizione = "Kg"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.l, .Descrizione = "litri"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.m, .Descrizione = "m"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.m2, .Descrizione = "m2"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.m3, .Descrizione = "m3"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.cm, .Descrizione = "cm"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.cm2, .Descrizione = "cm2"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.cm3, .Descrizione = "cm3"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.mm, .Descrizione = "mm"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.bobina, .Descrizione = "Bobina"})
            'lUM.Add(New cEnum With {.Id = enUnitaDiMisura.lastra, .Descrizione = "Lastra"})


            Return ris
        End Function

        Public Shared Function TipoDecodificaVoceCostoStr(TipoDecodificaVoce As enTipoDecodificaVoceCosto) As String
            Dim ris As String = String.Empty

            Select Case TipoDecodificaVoce
                Case enTipoDecodificaVoceCosto.Interpretazione
                    ris = "Interpreta"
                Case enTipoDecodificaVoceCosto.Esclusione
                    ris = "Escludi"
            End Select

            Return ris
        End Function

        Public Shared Function GetStatoFEStr(Stato As enStatoFatturaFE) As String
            Dim ris As String = String.Empty

            Select Case Stato
                Case enStatoFatturaFE.Tutti
                    ris = "Tutti"
                Case enStatoFatturaFE.DaInviare
                    ris = "NON in coda per Invio"
                Case enStatoFatturaFE.InCodaInvio
                    ris = "In coda per Invio"
                Case enStatoFatturaFE.InviatoXML
                    ris = "Inviato XML"
                Case enStatoFatturaFE.ScartataSDI
                    ris = "Scartata da SDI"
                Case enStatoFatturaFE.AccettataPEC
                    ris = "Accettata PEC"
                Case enStatoFatturaFE.ConsegnataPEC
                    ris = "Consegnata PEC"
                Case enStatoFatturaFE.ConsegnataDestinatario
                    ris = "Consegnata Destinatario"
                Case enStatoFatturaFE.NonConsegnataDestinatario
                    ris = "NON Consegnata Destinatario"
                Case enStatoFatturaFE.RicevutoEsito
                    ris = "Ricevuto Esito"
                Case enStatoFatturaFE.DecorsiTerminiEsito
                    ris = "Decorsi Termini Esito"
                Case enStatoFatturaFE.TrasmessaSenzaRecapito
                    ris = "Trasmessa Senza Recapito"
                Case enStatoFatturaFE.Archiviata
                    ris = "Archiviata"
                Case enStatoFatturaFE.AllegatoXMLRicevuto
                    ris = "Allegato XML Ricevuto"
            End Select

            Return ris
        End Function

        Public Shared Function GetStatoIncassoStr(Stato As enStatoIncasso) As String
            Dim ris As String = String.Empty

            Select Case Stato
                Case enStatoIncasso.Tutto
                    ris = "-"
                Case enStatoIncasso.Normale
                    ris = "Normale"
                Case enStatoIncasso.Problematico
                    ris = "Problematico"
                Case enStatoIncasso.Difficile
                    ris = "Difficile"
                Case enStatoIncasso.Impossibile
                    ris = "Impossibile"
            End Select

            Return ris
        End Function


        Public Shared Function StatoString(Stato As enStato) As String
            Dim ris As String = String.Empty

            Select Case Stato
                Case enStato.Attivo
                    ris = "Attivo"
                Case enStato.NonAttivo
                    ris = "NON Attivo"
            End Select

            Return ris
        End Function

        Public Shared Function GetFunctionLock(IdFunction As enFunctionLock) As String
            Dim ris As String = String.Empty

            Select Case IdFunction
                Case enFunctionLock.CreazioneCommesse
                    ris = "Creazione commessa da calcolo soluzioni"
                Case enFunctionLock.PreRefine
                    ris = "Pre-Refine"
                Case enFunctionLock.CreazioneCommesseFromGanging
                    ris = "Creazione commessa da Ganging"
                Case Else
                    ris = "Non specificato"
            End Select

            Return ris
        End Function

        Public Shared Function TipoRetroStr(TipoRetro As enTipoRetro) As String
            Dim ris As String = String.Empty

            Select Case TipoRetro
                Case enTipoRetro.RetroBianco
                    ris = "Retro Bianco"
                Case enTipoRetro.RetroDifferente
                    ris = "Retro Differente dal fronte"
                Case enTipoRetro.RetroNelFileFronte
                    ris = "Retro contenuto nel file fronte"
                Case enTipoRetro.RetroUgualeFronte
                    ris = "Retro uguale al fronte"
            End Select

            Return ris
        End Function

        Public Shared Function OrientamentoStr(Orientamento As enTipoOrientamento) As String
            Dim ris As String = String.Empty

            If Orientamento = enTipoOrientamento.Orizzontale Then
                ris = "Orizzontale"
            ElseIf Orientamento = enTipoOrientamento.Verticale Then
                ris = "Verticale"
            ElseIf Orientamento = enTipoOrientamento.Neutro Then
                ris = "Neutro"
            ElseIf Orientamento = enTipoOrientamento.NonSpecificato Then
                ris = "Non specificato"
            End If

            Return ris
        End Function

        Public Shared Function TipoControlloString(tipo As enTipoControllo) As String
            Dim ris As String = String.Empty

            Select Case tipo
                Case enTipoControllo.RadioButton
                    ris = "Pallino con Immagine"
                Case enTipoControllo.CheckBox
                    ris = "Segno di spunta"
                Case enTipoControllo.ComboBox
                    ris = "Casella a discesa"
            End Select

            Return ris
        End Function

        Public Shared Function StatoCommessaString(stCom As enStatoCommessa) As String
            Dim Ris As String = ""

            Select Case stCom
                Case enStatoCommessa.Preinserito
                    Ris = "Preinserita"

                Case enStatoCommessa.Pronto
                    Ris = "Pronta"

                Case enStatoCommessa.Stampa
                    Ris = "In stampa"

                Case enStatoCommessa.FinituraSuCommessa
                    Ris = "Finitura su commessa"

                Case enStatoCommessa.FinituraSuProdotti
                    Ris = "Finitura su prodotto"

                Case enStatoCommessa.Completata
                    Ris = "Completata"

            End Select
            Return Ris
        End Function

        Public Shared Function StatoConsegnaString(stCons As enStatoConsegna, _
                                                 Optional FromWeb As Boolean = False) As String

            Dim Ris As String = String.Empty

            Select Case stCons
                Case enStatoConsegna.Inserito
                    Ris = "Inserito"
                Case enStatoConsegna.InAttesaDiPagamento
                    Ris = "In attesa di Pagamento"
                Case enStatoConsegna.InLavorazione
                    Ris = "In Lavorazione"
                Case enStatoConsegna.RegistrataCorriere
                    If FromWeb Then
                        Ris = "In Lavorazione"
                    Else
                        Ris = "Registrata con Corriere"
                    End If
                Case enStatoConsegna.InConsegna
                    Ris = "In Consegna"
                Case enStatoConsegna.Consegnata
                    Ris = "Consegnato"
                Case enStatoConsegna.Eliminata
                    Ris = "Eliminata"
                Case enStatoConsegna.Pagato
                    Ris = "Pagato"
                Case enStatoConsegna.Sospesa
                    Ris = "Sospeso"
            End Select

            Return Ris

        End Function

        Public Shared Function StatoOrdineString(stOrd As Integer, _
                                                 Optional FromWeb As Boolean = False, _
                                                 Optional IdCorriere As enCorriere = enCorriere.RitiroCliente) As String
            Dim Ris As String = ""
            Select Case stOrd
                Case enStatoOrdine.InAttesaAllegati
                    Ris = "In attesa Invio File"
                Case enStatoOrdine.RefineAutomatico
                    If FromWeb Then
                        Ris = "In attesa di Verifica File"
                    Else
                        Ris = "Refine Automatico"
                    End If
                Case enStatoOrdine.Preinserito
                    If FromWeb Then
                        Ris = "In attesa di Verifica File"
                    Else
                        Ris = "Preinserito"
                    End If
                Case enStatoOrdine.InAttesaPagamento
                    Ris = "In attesa di Pagamento"
                Case enStatoOrdine.Registrato
                    'If FromWeb Then
                    '    Ris = "In Lavorazione"
                    'Else
                    Ris = "Registrato"
                    'End If
                Case enStatoOrdine.InSospeso
                    Ris = "In sospeso"
                Case enStatoOrdine.InCodaDiStampa
                    Ris = "In coda di stampa"
                Case enStatoOrdine.StampaInizio
                    Ris = "In stampa"
                Case enStatoOrdine.StampaFine
                    Ris = "In attesa di finitura"
                Case enStatoOrdine.FinituraCommessaInizio
                    Ris = "Iniziata finitura su commessa"
                Case enStatoOrdine.FinituraCommessaFine
                    Ris = "Terminata finitura su commessa"
                Case enStatoOrdine.FinituraProdottoInizio
                    Ris = "Iniziata finitura su prodotto"
                Case enStatoOrdine.FinituraProdottoFine
                    Ris = "Terminata finitura su prodotto"
                Case enStatoOrdine.Imballaggio
                    Ris = "In imballaggio"
                Case enStatoOrdine.ImballaggioCorriere
                    Ris = "In imballaggio Corriere"
                Case enStatoOrdine.ProntoRitiro
                    If IdCorriere = enCorriere.RitiroCliente Then
                        Ris = "Pronto per il ritiro"
                    Else
                        Ris = "Pronto per la consegna"
                    End If
                Case enStatoOrdine.UscitoMagazzino
                    Ris = "Uscito dal magazzino"
                Case enStatoOrdine.InConsegna
                    Ris = "In consegna"
                Case enStatoOrdine.Consegnato
                    Ris = "Consegnato"
                Case enStatoOrdine.PagatoAcconto
                    Ris = "Acconto"
                Case enStatoOrdine.PagatoInteramente
                    Ris = "Pagato"
                Case enStatoOrdine.Rifiutato
                    Ris = "Rifiutato"
                Case enStatoOrdine.Eliminato
                    Ris = "Eliminato"
            End Select
            Return Ris
        End Function

        Public Shared Function TipoDocumentoFiscaleStr(TipoDocFiscale As enTipoDocumento) As String
            Dim Ris As String = String.Empty
            Select Case TipoDocFiscale
                Case enTipoDocumento.DDT
                    Ris = "D.D.T."
                Case enTipoDocumento.Fattura
                    Ris = "Fattura"
                Case enTipoDocumento.FatturaRiepilogativa
                    Ris = "Fattura Riepilogativa"
                Case enTipoDocumento.Preventivo
                    Ris = "Preventivo"
                Case enTipoDocumento.NotaDiCredito
                    Ris = "Nota di Credito"
                Case enTipoDocumento.NotaDiDebito
                    Ris = "Nota di Debito"
                Case enTipoDocumento.AccontoAnticipoSuFattura
                    Ris = "Acconto/Anticipo su Fattura"
            End Select
            Return Ris
        End Function

        Public Shared Function TipoProdComStr(IdTipoProdCom As enTipoProdCom) As String
            Dim Ris As String = String.Empty
            Select Case IdTipoProdCom
                Case enTipoProdCom.StampaOffSet
                    Ris = "Stampa Offset"
                Case enTipoProdCom.StampaDigitale
                    Ris = "Stampa Digitale"
                Case enTipoProdCom.Packaging
                    Ris = "Packaging"
                Case enTipoProdCom.Ricamo
                    Ris = "Ricamo"
                Case enTipoProdCom.Etichette
                    Ris = "Etichette"
                Case enTipoProdCom.Consumo
                    Ris = "Materiale di Consumo"
            End Select
            Return Ris
        End Function

        Public Shared Function RepartoStr(IdReparto As enRepartoWeb) As String
            Dim Ris As String = String.Empty
            Select Case IdReparto
                Case enRepartoWeb.StampaOffset
                    Ris = "Stampa Offset"
                Case enRepartoWeb.StampaDigitale
                    Ris = "Stampa Digitale"
                Case enRepartoWeb.Packaging
                    Ris = "Packaging"
                Case enRepartoWeb.Ricamo
                    Ris = "Ricamo"
                Case enRepartoWeb.Etichette
                    Ris = "Etichette"
            End Select
            Return Ris
        End Function

        Public Shared Function GetIconaStato(stOrd As enStatoOrdine) As String

            Dim Ris As String = "/img/icoAttach16.png"

            If stOrd = enStatoOrdine.InAttesaAllegati Then
                Ris = "/img/icoBianco.png"
            ElseIf stOrd = enStatoOrdine.Preinserito Then
                Ris = "/img/icoAttach16Ko.png"
            ElseIf stOrd = enStatoOrdine.Registrato Then
                Ris = "/img/icoAttach16Ok.png"
            End If
            
            Return Ris

        End Function

        Public Shared Function TipoRubricaStr(TipoRubrica As enTipoRubrica,
                                              IsFornitore As Integer) As String

            Dim ris As String = String.Empty
            If IsFornitore = enSiNo.Si Then
                ris = "Fornitore"
            Else
                Select Case TipoRubrica
                    Case enTipoRubrica.Cliente
                        ris = "Cliente"
                'Case enTipoRubrica.Agente
                '    ris = "Agente"
                    Case enTipoRubrica.Rivenditore
                        ris = "Rivenditore"
                'Case enTipoRubrica.Fornitore
                '    ris = "Fornitore"
                    Case enTipoRubrica.Tutto
                        ris = "Tutti"
                End Select
            End If


            Return ris

        End Function

        Public Shared Function GetRepartoMacro(RepartoWeb As enRepartoWeb) As enRepartoMacro
            Dim ris As enRepartoMacro = enRepartoMacro.OffSet

            Select Case RepartoWeb
                Case enRepartoWeb.StampaOffset
                    ris = enRepartoMacro.OffSet
                Case enRepartoWeb.Packaging
                    ris = enRepartoMacro.OffSet
                Case enRepartoWeb.StampaDigitale
                    ris = enRepartoMacro.Digitale
                Case enRepartoWeb.Etichette
                    ris = enRepartoMacro.Digitale
                Case enRepartoWeb.Ricamo
                    ris = enRepartoMacro.Digitale
                Case enRepartoWeb.ProdottoFinito
                    ris = enRepartoMacro.ProdottoFinito
            End Select

            Return ris
        End Function
        Public Shared Function TipoPagamentoStr(TipoPagamento As enMetodoPagamento) As String

            Dim Ris As String = String.Empty

            Select Case TipoPagamento
                Case enMetodoPagamento.BonificoBancarioAnticipato
                    Ris = "Bonifico Bancario Anticipato"
                Case enMetodoPagamento.PayPal
                    Ris = "Pay Pal"
                Case enMetodoPagamento.CartaDiCredito
                    Ris = "Carta di Credito"
                Case Else
                    Ris = String.Empty
            End Select

            Return Ris

        End Function

        Public Shared Function TipoMovimentoMagazzinoStr(TipoMov As enTipoMovMagaz) As String

            Dim Ris As String = String.Empty

            Select Case TipoMov
                Case enTipoMovMagaz.Carico
                    Ris = "Carico"
                Case enTipoMovMagaz.Inserimento
                    Ris = "Inserimento"
                Case enTipoMovMagaz.RichiestaAcquisto
                    Ris = "Richiesta di acquisto"
                Case enTipoMovMagaz.Prenotazione
                    Ris = "Prenotazione"
                Case enTipoMovMagaz.Scarico
                    Ris = "Scarico"
                Case enTipoMovMagaz.Storno
                    Ris = "Storno"
                Case enTipoMovMagaz.Tutto
                    Ris = "Tutto"
            End Select

            Return Ris

        End Function

        Public Shared Function TipoImballoStr(TipoImballo As enTipoImballo) As String

            Dim Ris As String = String.Empty

            Select Case TipoImballo
                Case enTipoImballo.Fascette
                    Ris = "Fascette"
                Case enTipoImballo.Termoretraibile
                    Ris = "Termo Retraibile"
                Case enTipoImballo.Scatola
                    Ris = "Scatolone"
            End Select

            Return Ris

        End Function

        Public Shared Function PeriodoRiferimentoStr(PeriodoMesi As enPeriodoRiferimento) As String

            Dim Ris As String = String.Empty
            Select Case PeriodoMesi
                Case enPeriodoRiferimento.UnMese
                    Ris = "Un mese"
                Case enPeriodoRiferimento.TreMesi
                    Ris = "Tre mesi"
                Case enPeriodoRiferimento.SeiMesi
                    Ris = "Sei mesi"
                Case enPeriodoRiferimento.UnAnno
                    Ris = "Un anno"
                Case enPeriodoRiferimento.Ieri
                    Ris = "Ieri"
                Case enPeriodoRiferimento.UnGiorno
                    Ris = "Oggi"
                Case enPeriodoRiferimento.UnaSettimana
                    Ris = "Una settimana"
            End Select
            Return Ris

        End Function

    End Class

End Namespace

