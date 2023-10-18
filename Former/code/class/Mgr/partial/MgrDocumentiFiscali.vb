Imports FormerBusinessLogic
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrDocumentiFiscali
    Inherits FormerBusinessLogic.MgrDocumentiFiscali



    Public Shared Function SetStatoIncasso(IdDocSel As Integer,
                                      Stato As enStatoIncasso) As Integer

        Dim Ris As Integer = 0

        If IdDocSel Then
            'If IdTipoDocSel = enTipoVoceContab.VoceVendita Then
            If MessageBox.Show("Confermi il cambio stato di incasso a " & FormerEnumHelper.GetStatoIncassoStr(Stato).ToUpper & " per il documento selezionato?", "Stato Incasso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'qui devo salvare il passaggio di stato con delle eventuali note 
                Using R As New Ricavo
                    R.Read(IdDocSel)

                    If R.Stato <> enStatoDocumentoFiscale.PagatoInteramente Then
                        If R.StatoIncasso <> Stato Then

                            Dim RisNota As Integer = 0
                            Dim Buffer As String = String.Empty
                            'ParentFormEx.Sottofondo()
                            Using f As New frmTextGet
                                RisNota = f.Carica("Inserisci se vuoi una annotazione riguardante il cambio di stato di incasso di questo documento", Buffer)
                            End Using
                            'ParentFormEx.Sottofondo()

                            If RisNota Then

                                R.StatoIncasso = Stato
                                R.Save()

                                Using lR As New LogRicavo
                                    lR.IdRicavo = IdDocSel
                                    lR.IdOperatore = PostazioneCorrente.UtenteConnesso.IdUt
                                    lR.Quando = Now
                                    lR.Annotazioni = Buffer
                                    lR.StatoIncasso = Stato
                                    lR.Save()
                                End Using

                                For Each O As Ordine In R.ListaOrdini

                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "Il documento fiscale in cui l'ordine è contenuto ha cambiato stato di incasso a " & FormerEnumHelper.GetStatoIncassoStr(Stato).ToUpper)

                                Next

                                Ris = 1

                            End If
                        Else
                            MessageBox.Show("Il documento selezionato è gia nello stato di incasso " & FormerEnumHelper.GetStatoIncassoStr(Stato).ToUpper)
                        End If

                    Else
                        MessageBox.Show("Il documento fiscale risulta interamente pagato")

                    End If

                End Using

            End If
            'Else
            'MessageBox.Show("Lo stato di incasso si può impostare solo per i documenti di vendita")
            'End If
        End If

        Return Ris

    End Function

    Public Shared Sub MessaggioModuloFattura(R As Ricavo, NumCopie As Integer)
        Dim MostraMessaggio As Boolean = False

        If MostraMessaggio Then
            If R.Tipo <> enTipoDocumento.Preventivo And R.IdAzienda = MgrAziende.IdAziende.AziendaSnc Then
                MessageBox.Show("Per la stampa del documento fiscale " & R.Numero & " di '" & R.pRagSoc & "' inserire " & NumCopie & " copie del modulo fattura " & MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSnc))
            End If
        End If

    End Sub

    Public Shared Function CheckNumeroDocumentiFiscali(Optional AnnoRif As Integer = 0) As RisCheckNumeroDocumentiFiscali
        Dim ris As New RisCheckNumeroDocumentiFiscali

        ris.BufferErrori = MgrDocumentiFiscali.DocumentNumber.GetNumberError(AnnoRif)

        If ris.Errori Then
            Using f As New frmTextShow
                f.Carica("Sono stati rilevati degli errori nella seguenza di numerazione dei documenti fiscali. Risolvere i problemi manualmente." & ControlChars.NewLine & "Elenco errori: " & ControlChars.NewLine & ControlChars.NewLine & ris.BufferErrori)
            End Using
        End If

        Return ris
    End Function

    Public Shared Function EliminaDocumentoFiscaleVendita(R As RicavoEx)

        Dim IdVoce As Integer = R.IdRicavo
        Dim IdCons As Integer = 0

        For Each o As Ordine In R.ListaOrdini
            IdCons = o.IdCons

            If o.Stato > enStatoOrdine.UscitoMagazzino Then
                Using mO As New OrdiniDAO
                    mO.InserisciLog(o.IdOrd, enStatoOrdine.UscitoMagazzino)
                End Using
            End If
        Next

        Using C As New ConsegnaProgrammata
            C.Read(IdCons)
            If C.IdStatoConsegna <> enStatoConsegna.RegistrataCorriere Then
                C.IdStatoConsegna = enStatoConsegna.InLavorazione
                C.Save()
            Else
                MessageBox.Show("La fattura è stata eliminata ma la consegna era già registrata con il corriere. Se necessario cancellare la registrazione con il corriere manualmente")
            End If

        End Using

        Using mgr As New VociFatturaDAO
            mgr.DeleteByIdRicavo(IdVoce)
        End Using

        Using mgr As New OrdiniDAO
            mgr.ResetIdDoc(IdVoce)
        End Using

        If R.Tipo = enTipoDocumento.NotaDiCredito Then
            'qui devo eliminare il pagamento automatico emesso per la nota di credito

            Dim IdPagam As Integer = 0
            If Not R.RicavoRiferimentoNotadiCredito Is Nothing AndAlso
                R.RicavoRiferimentoNotadiCredito.ListaPagamenti.FindAll(Function(x) x.IdTipoPagamento = enMetodoPagamento.StornoDaNotaDiCredito).Count Then
                Using p As Pagamento = R.RicavoRiferimentoNotadiCredito.ListaPagamenti.Find(Function(x) x.IdTipoPagamento = enMetodoPagamento.StornoDaNotaDiCredito)
                    IdPagam = p.IdPag
                    Using mgr As New PagamentiDAO
                        mgr.Delete(IdPagam)
                    End Using
                    MgrDocumentiFiscali.AggiornaStatoRicavoDopoPagamento(R.RicavoRiferimentoNotadiCredito.IdRicavo) ', True)
                End Using

            End If


        End If

        Using c As cContabRicaviColl = New cContabRicaviColl
            c.ResetIdDocRifByIdDoc(IdVoce)
            c.Delete(IdVoce)
        End Using

    End Function

End Class
