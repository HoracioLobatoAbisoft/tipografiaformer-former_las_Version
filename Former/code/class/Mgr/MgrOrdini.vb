Imports FormerBusinessLogic
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrOrdini

    Public Shared Sub ForzaEsecuzioneRefineAutomaticoDemone()
        FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_RefineAutomatico, "REFINE")
    End Sub

    Public Shared Sub RiapriCartellaSorgenti(O As Ordine)

        If O.ListaSorgenti.Count Then
            Dim PathFirst As String = O.ListaSorgenti(0).FilePath
            PathFirst = FormerLib.FormerHelper.File.GetFolder(PathFirst)
            FormerLib.FormerHelper.File.ShellExtended(PathFirst)
        End If

    End Sub

    Public Shared Function ForzaStatoOrdineARegistrato(O As Ordine) As Integer
        Dim Ris As Integer = 0

        If PostazioneCorrente.ScaricamentoOrdiniInCorso Then
            MessageBox.Show("Il Demone sta scaricando i nuovi ordini, attendere il termine dell'operazione e riprovare")
        Else
            If MessageBox.Show("Confermi il passaggio manuale a " & FormerEnumHelper.StatoOrdineString(enStatoOrdine.Registrato).ToUpper & " dell'ordine " & O.IdOrd & "?", "Forza stato ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New OrdiniDAO

                    O.Read(O.IdOrd) ' lo rileggo per sicurezza
                    Dim ErrorCommessa As Boolean = False
                    If O.IdTipoProd = enRepartoWeb.StampaOffset And O.IdCom <> 0 Then
                        ErrorCommessa = True
                    End If
                    If O.Stato <> enStatoOrdine.Registrato Then
                        If O.Stato <= enStatoOrdine.InSospeso AndAlso ErrorCommessa = False Then
                            mgr.InserisciLog(O, enStatoOrdine.Registrato, PostazioneCorrente.UtenteConnesso.IdUt)
                        Else
                            MessageBox.Show("Si possono forzare gli stati solo degli ordini che sono in uno stato precedente a IN CODA DI STAMPA. Gli ordini offset non devono essere stati inseriti in una commessa.")
                        End If
                    End If
                End Using
                Ris = 1
            End If
        End If

        Return Ris
    End Function

    Public Shared Function ForzaStatoOrdineAPreinserito(O As Ordine) As Integer
        Dim Ris As Integer = 0

        If PostazioneCorrente.ScaricamentoOrdiniInCorso Then
            MessageBox.Show("Il Demone sta scaricando i nuovi ordini, attendere il termine dell'operazione e riprovare")
        Else
            If MessageBox.Show("Confermi il passaggio manuale a " & FormerEnumHelper.StatoOrdineString(enStatoOrdine.Preinserito).ToUpper & " dell'ordine " & O.IdOrd & "?", "Forza stato ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New OrdiniDAO

                    O.Read(O.IdOrd) ' lo rileggo per sicurezza
                    Dim ErrorCommessa As Boolean = False
                    If O.IdTipoProd = enRepartoWeb.StampaOffset And O.IdCom <> 0 Then
                        ErrorCommessa = True
                    End If
                    If O.Stato <> enStatoOrdine.Preinserito Then
                        If (O.Stato <= enStatoOrdine.InSospeso Or O.Stato = enStatoOrdine.Eliminato) AndAlso ErrorCommessa = False Then

                            If O.ConsegnaAssociata Is Nothing OrElse O.ConsegnaAssociata.IdCons = 0 Then
                                'qui devo rimetterlo in consegna
                                Using mgrC As New ConsegneProgrammateDAO
                                    mgrC.RegistraConsegnaOrdineSuGiorno(O.IdOrd, O.IdCorriere, O.CalcolaDataConsegna, O.IdRub, enMomentoConsegna.Mattina, O.IdIndirizzo)
                                End Using
                            End If
                            mgr.InserisciLog(O, enStatoOrdine.Preinserito, PostazioneCorrente.UtenteConnesso.IdUt)
                        Else
                            MessageBox.Show("Si possono forzare gli stati solo degli ordini che sono in uno stato precedente a IN CODA DI STAMPA. Gli ordini offset non devono essere stati inseriti in una commessa.")
                        End If
                    End If
                End Using
                Ris = 1
            End If
        End If

        Return Ris
    End Function

    Public Shared Function ForzaStatoOrdineAInSospeso(O As Ordine,
                                                      Sender As Object) As Integer
        Dim Ris As Integer = 0

        Dim L As New List(Of OrdineRicerca)
        L.Add(O)
        Dim Check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, L)

        If Check.ICan Then
            If MessageBox.Show("Confermi il cambiamento di stato dell'ordine " & O.IdOrd & " a IN SOSPESO?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim Modificabi As Boolean = False
                If Not O.ConsegnaAssociata Is Nothing Then
                    Modificabi = O.ConsegnaAssociata.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito 'ModificabileEx(False, False, True, True, False, False).Modificabile
                Else
                    Modificabi = True
                End If
                If Modificabi Then
                    If O.Stato <> enStatoOrdine.InSospeso Then
                        Dim ErrorCommessa As Boolean = False
                        If O.IdTipoProd = enRepartoWeb.StampaOffset And O.IdCom <> 0 Then
                            ErrorCommessa = True
                        End If
                        If O.Stato <= enStatoOrdine.InSospeso AndAlso ErrorCommessa = False Then
                            Dim IdCons As Integer = O.IdCons
                            If IdCons Then
                                Using mgr As New ConsegneProgrammateDAO
                                    'OK
                                    mgr.EliminaOrdineDaConsegna(IdCons, O.IdOrd)
                                    Using C As New ConsegnaProgrammata
                                        C.Read(IdCons)
                                        C.AggiornaColliPeso()
                                    End Using
                                    mgr.EliminaConsegnaSeVuota(IdCons)
                                End Using
                            End If

                            Dim IdCommessa As Integer = O.IdCom

                            Using mgr As New OrdiniDAO
                                mgr.InserisciLog(O, enStatoOrdine.InSospeso, PostazioneCorrente.UtenteConnesso.IdUt)
                            End Using

                            If IdCommessa Then

                                MgrCommesse.RimuoviOrdineDaCommessa(Sender,
                                                                    O.IdOrd)

                            End If

                        Else
                            MessageBox.Show("Si possono forzare gli stati solo degli ordini che sono in uno stato precedente a IN CODA DI STAMPA. Gli ordini offset non devono essere stati inseriti in una commessa.")
                        End If
                    End If

                Else
                    MessageBox.Show("Consegna non modificabile")
                End If
            End If
        Else
            MessageBox.Show(MgrOrderLock.GetMessageLocked(Check))
        End If

        Return Ris
    End Function

    Public Shared Function ForzaStatoOrdineARifiutato(O As Ordine) As Integer
        Dim Ris As Integer = 0

        Dim L As New List(Of OrdineRicerca)
        L.Add(O)
        Dim Check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, L)

        If Check.ICan Then
            If MessageBox.Show("Confermi il cambiamento di stato dell'ordine " & O.IdOrd & " a RIFIUTATO?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim Modificabi As Boolean = False
                If Not O.ConsegnaAssociata Is Nothing Then
                    Modificabi = O.ConsegnaAssociata.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito 'O.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, False).Modificabile
                Else
                    Modificabi = True
                End If
                If Modificabi Then
                    If O.Stato <> enStatoOrdine.Rifiutato Then
                        Dim ErrorCommessa As Boolean = False
                        If O.IdTipoProd = enRepartoWeb.StampaOffset And O.IdCom <> 0 Then
                            ErrorCommessa = True
                        End If
                        If O.Stato <= enStatoOrdine.InSospeso AndAlso ErrorCommessa = False Then
                            Dim IdCons As Integer = O.IdCons
                            If IdCons Then
                                Using mgr As New ConsegneProgrammateDAO
                                    'OK
                                    mgr.EliminaOrdineDaConsegna(IdCons, O.IdOrd)
                                    Using C As New ConsegnaProgrammata
                                        C.Read(IdCons)
                                        C.AggiornaColliPeso()
                                    End Using
                                    mgr.EliminaConsegnaSeVuota(IdCons)
                                End Using
                            End If
                            Using mgr As New OrdiniDAO
                                mgr.InserisciLog(O, enStatoOrdine.Rifiutato, PostazioneCorrente.UtenteConnesso.IdUt)
                            End Using

                            If Not O.Commessa Is Nothing AndAlso
                                O.Commessa.ListaOrdini.Count = 1 Then
                                'qui devo eliminare anche la commessa
                                Using mgr As New CommesseDAO
                                    mgr.Delete(O.IdCom)
                                End Using

                                O.IdCom = 0
                                O.Save()

                            End If

                        Else
                            MessageBox.Show("Si possono forzare gli stati solo degli ordini che sono in uno stato precedente a IN CODA DI STAMPA. Gli ordini offset non devono essere stati inseriti in una commessa.")
                        End If
                    End If

                Else
                    MessageBox.Show("Consegna non modificabile")
                End If
            End If
        Else
            MessageBox.Show(MgrOrderLock.GetMessageLocked(Check))
        End If


        Return Ris
    End Function
    Public Shared Function GarantisciDataConsegna(O As Ordine,
                                                  Optional FormChiamante As IFormWithSottofondo = Nothing) As Integer

        Dim ris As Integer = 0

        If O.Stato < enStatoOrdine.UscitoMagazzino Then
            If O.ConsegnaGarantita <> Date.MinValue Then
                MessageBox.Show("L'ordine ha gia una data di consegna garantita")
            Else
                If Not O.ConsegnaAssociata Is Nothing Then

                    If O.ConsegnaAssociata.Diritti.PossoPosticipareGiorno.Esito = True OrElse
                       O.ConsegnaAssociata.Diritti.PossoAnticipareGiorno.Esito = True Then
                        FormChiamante.Sottofondo()
                        Using f As New frmOrdineCambiaDataConsegna
                            If f.Carica(O) Then
                                'qui dovro ricaricare
                                ris = 1
                            End If
                        End Using
                        FormChiamante.Sottofondo()
                    Else

                        MessageBox.Show("Il giorno di consegna non si può modificare")

                    End If

                    'If O.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, True).Modificabile Then
                    '    FormChiamante.Sottofondo()
                    '    Using f As New frmOrdineCambiaDataConsegna
                    '        If f.Carica(O) Then
                    '            'qui dovro ricaricare
                    '            ris = 1
                    '        End If
                    '    End Using
                    '    FormChiamante.Sottofondo()
                    'Else

                    '    MessageBox.Show("La consegna associata all'ordine non è modificabile")

                    'End If

                Else
                    MessageBox.Show("L'ordine selezionato non ha una consegna associata")
                End If
            End If

        Else
            MessageBox.Show("L'ordine risulta già uscito da magazzino")
        End If
        Return ris
    End Function

    Public Shared Function ModificaDatiEconomici(O As Ordine,
                                            Optional FormChiamante As IFormWithSottofondo = Nothing) As Integer
        Dim Ris As Integer = 0

        If O.ConsegnaAssociata.HaUnPagamentoAnticipato = False Then
            If O.DocumentoFiscale Is Nothing Then '  ConsegnaAssociata.HaDocumentiFiscali = False Then
                If O.Stato <> enStatoOrdine.InConsegna Then
                    Using frmMod As New frmOrdineModificaImporti
                        If Not FormChiamante Is Nothing Then FormChiamante.Sottofondo()

                        Ris = frmMod.Carica(O.IdOrd)

                        If Not FormChiamante Is Nothing Then FormChiamante.Sottofondo()
                    End Using
                Else
                    MessageBox.Show("L'ordine non può essere modificato perchè è gia stato messo in consegna!", "Modifica ordine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("L'ordine non può essere modificato perchè inserito in un Documento Fiscale", "Modifica ordine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("L'ordine non può essere modificato perchè associato a una consegna con un pagamento", "Modifica ordine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return Ris
    End Function

End Class
