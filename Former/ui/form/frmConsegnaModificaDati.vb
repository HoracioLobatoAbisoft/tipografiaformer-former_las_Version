Imports FormerDALSql
Imports FormerLib.FormerEnum
Friend Class frmConsegnaModificaDati
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0
    Private _C As ConsegnaProgrammata

    Private _IdCorr As Integer = 0
    Private _IdIndirizzo As Integer = 0
    Private _Giorno As Date = Date.MinValue

    Friend Function Carica(IdCons As Integer) As Integer

        _C = New ConsegnaProgrammata
        _C.Read(IdCons)

        _Giorno = _C.Giorno
        _IdCorr = _C.IdCorr
        _IdIndirizzo = _C.IdIndirizzo

        If _C.Giorno < Now.Date Then
            mcDataScelta.MinDate = _C.Giorno
        Else
            mcDataScelta.MinDate = Now.Date
        End If

        If _C.Diritti.PossoAnticipareGiorno.Esito Then
            'qui posso anticipare il giorno
            'controllo se lo posso posticipare
            If _C.Diritti.PossoPosticipareGiorno.Esito = False Then
                mcDataScelta.MaxDate = _C.Giorno
            End If
        Else
            'se non posso anticiparlo di certo non posso posticiparlo
            mcDataScelta.MaxDate = _C.Giorno
            mcDataScelta.Enabled = False
        End If

        mcDataScelta.SelectionStart = _C.Giorno
        lblCliente.Text = _C.Cliente.RagSocNome
        SetDataSel()

        CaricaCombo()

        MgrControl.SelectIndexCombo(cmbCorriere, _C.IdCorr)
        MgrControl.SelectIndexCombo(cmbIndirizzo, _C.IdIndirizzo)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        cmbIndirizzo.ValueMember = "IdIndirizzo"
        cmbIndirizzo.DisplayMember = "RiassuntoEx"
        cmbIndirizzo.DataSource = _C.Cliente.Indirizzi

        Using Corriere As New CorrieriDAO

            cmbCorriere.ValueMember = "IdCorriere"
            cmbCorriere.DisplayMember = "Descrizione"
            cmbCorriere.DataSource = Corriere.GetListaCorrieri() ' .FindAll("Descrizione", New LUNA.LunaSearchParameter("DisponibileOnline", enSiNo.Si))

        End Using

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi la modifica dei dati della Consegna? (In caso sarà possibile la consegna verrà agganciata a un altra esistente se presente)", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim RiportaOrdiniImballaggio As Boolean = False
            Dim CambiatoQualcosa As Boolean = False
            If _IdCorr <> cmbCorriere.SelectedValue Then
                CambiatoQualcosa = True

                If _IdCorr = enCorriere.GLS OrElse
                    _IdCorr = enCorriere.GLSIsole OrElse
                    _IdCorr = enCorriere.PortoAssegnatoGLS OrElse
                    cmbCorriere.SelectedValue = enCorriere.GLS OrElse
                    cmbCorriere.SelectedValue = enCorriere.GLSIsole OrElse
                    cmbCorriere.SelectedValue = enCorriere.PortoAssegnatoGLS Then

                    RiportaOrdiniImballaggio = True
                End If
            End If
            If _Giorno <> mcDataScelta.SelectionStart Then
                CambiatoQualcosa = True
            End If

            If _IdIndirizzo <> cmbIndirizzo.SelectedValue Then
                CambiatoQualcosa = True
            End If

            If CambiatoQualcosa Then
                Using TB As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Try
                        'qui per ogni ordine contenuto nelal consegna faccio il giro che li sposta e li aggancia o ricrea la consegna
                        Dim NuovaConsegna As ConsegnaProgrammata = Nothing
                        Using mgr As New ConsegneProgrammateDAO
                            TB.TransactionBegin()
                            For Each O As Ordine In _C.ListaOrdini
                                'TOLTO IL 08/04/2015
                                'mgr.EliminaOrdineDaConsegna(_C.IdCons, O.IdOrd)
                                Dim SalvaOrdine As Boolean = False
                                If O.IdIndirizzo <> cmbIndirizzo.SelectedValue Then
                                    O.IdIndirizzo = cmbIndirizzo.SelectedValue
                                    SalvaOrdine = True
                                End If
                                If O.IdCorriere <> cmbCorriere.SelectedValue Then
                                    O.IdCorriere = cmbCorriere.SelectedValue
                                    SalvaOrdine = True
                                End If

                                If SalvaOrdine Then
                                    O.Save()
                                End If

                                NuovaConsegna = mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd, cmbCorriere.SelectedValue, mcDataScelta.SelectionStart, _C.IdRub, enMomentoConsegna.Pomeriggio, cmbIndirizzo.SelectedValue, NuovaConsegna)
                            Next

                            If RiportaOrdiniImballaggio Then

                                Dim PortaIndietroUscitiMagazzino As Boolean = False

                                If NuovaConsegna.PresentiOrdiniUscitiDaMagazzino Then

                                    If MessageBox.Show("Sono presenti ordini in stato 'Uscito da Magazzino', vuoi riportarli a 'Imballaggio'?", "Stato ordini", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        PortaIndietroUscitiMagazzino = True
                                    End If

                                End If

                                For Each O As Ordine In NuovaConsegna.ListaOrdini
                                    If O.Stato = enStatoOrdine.ImballaggioCorriere Or O.Stato = enStatoOrdine.ProntoRitiro Or (O.Stato = enStatoOrdine.UscitoMagazzino And PortaIndietroUscitiMagazzino = True) Then
                                        Using mgrO As New OrdiniDAO
                                            mgrO.InserisciLog(O, enStatoOrdine.Imballaggio)
                                        End Using
                                    End If
                                Next
                                MessageBox.Show("E' stato modificato il Corriere della consegna, gli ordini in 'Imballaggio Corriere' e 'Pronto Ritiro' sono stati riportati a 'Imballaggio'")
                            End If

                            'mgr.EliminaConsegnaSeVuota(_C.IdCons)
                            TB.TransactionCommit()
                        End Using
                        _Ris = NuovaConsegna.IdCons 'in ris devo mettere l'id della consegna nuova a cui tutta questa roba si aggancia
                        Close()
                    Catch ex As Exception
                        TB.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nella modifica della consegna: " & ex.Message)
                    End Try

                End Using
            Else
                _Ris = _C.IdCons
                Close()
            End If

        End If
    End Sub

    Private Sub SetDataSel()
        lblDataSel.Text = mcDataScelta.SelectionStart.ToString("dddd dd/MM/yyyy")
    End Sub

    Private Sub mcDataScelta_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mcDataScelta.DateChanged
        SetDataSel()
    End Sub
End Class