Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogicInterface

Friend Class frmMagazzinoMovimento
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _IdMov As Integer
    Private _Mov As New MovimentoMagazzino

    Private _QtaDisp As Integer
    Private _OldQta As Integer = 0

    Private _IdRis As Integer
    Public Property IdRis() As Integer
        Get
            Return _IdRis
        End Get
        Set(ByVal value As Integer)
            _IdRis = value
        End Set
    End Property

    Private _IdFat As Integer
    Public Property IDFat() As Integer
        Get
            Return _IdFat
        End Get
        Set(ByVal value As Integer)
            _IdFat = value
        End Set
    End Property

    Private _IdForn As Integer
    Public Property IDForn() As Integer
        Get
            Return _IdForn
        End Get
        Set(ByVal value As Integer)
            _IdForn = value
        End Set
    End Property

    Private _OnlyManual As Boolean = True
    Public Property OnlyManual() As Boolean
        Get
            Return _OnlyManual
        End Get
        Set(ByVal value As Boolean)
            _OnlyManual = value
        End Set
    End Property

    Private _IdCom As Integer
    Public Property IdCom() As Integer
        Get
            Return _IdCom
        End Get
        Set(ByVal value As Integer)
            _IdCom = value
        End Set
    End Property

    Private _TipoMov As enTipoMovMagaz = enTipoMovMagaz.Carico
    Public Property TipoMov() As enTipoMovMagaz
        Get
            Return _TipoMov
        End Get
        Set(ByVal value As enTipoMovMagaz)
            _TipoMov = value
        End Set
    End Property

    Private _MaxQta As Single
    Public Property MaxQta() As Single
        Get
            Return _MaxQta
        End Get
        Set(ByVal value As Single)
            _MaxQta = value
        End Set
    End Property

    Private Sub CaricaCombo()

        Dim TipoProd As New cTipoMovMagaz(False) '(_OnlyManual)
        cmbTipoMov.DataSource = TipoProd
        cmbTipoMov.ValueMember = "Id"
        cmbTipoMov.DisplayMember = "Descrizione"

        Using cli As New VociRubricaDAO
            cmbFornitore.ValueMember = "IdRub"
            cmbFornitore.DisplayMember = "Nominativo"

            cmbFornitore.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, True,,,,,, True)
        End Using
    End Sub

    Private Sub CaricamentoInterno(Optional ByVal IdMov As Integer = 0,
                           Optional ByRef Mag As MovimentoMagazzino = Nothing,
                           Optional ByVal SelezionaTipo As enTipoMovMagaz = enTipoMovMagaz.Carico,
                           Optional ByVal BloccaTipoMov As Boolean = True)
        _IdMov = IdMov

        CaricaCombo()

        If _IdFat Then
            ' se carico una fattura faccio di sicuro un carico e quindi disattivo la combo 
            cmbTipoMov.Enabled = False
            cmbTipoMov.BackColor = Color.White
            MgrControl.SelectIndexCombo(cmbTipoMov, enTipoMovMagaz.Carico)

        End If

        If _IdMov Then

            _Mov.Read(_IdMov)

            lblDataMov.Text = _Mov.DataMov.ToString("dd/MM/yyyy")

            _IdRis = _Mov.IdRis
            MgrControl.SelectIndexCombo(cmbTipoMov, _Mov.TipoMov)
            _OldQta = _Mov.Qta
            txtQta.Text = _Mov.Qta
            txtPrezzo.Text = _Mov.Prezzo

            If _Mov.TipoMov <> enTipoMovMagaz.Scarico Then
                CommessaToolStripMenuItem.Visible = False
                'lnkApriCommessa.Visible = True
            End If

            If _Mov.IdCom = 0 Then
                CommessaToolStripMenuItem.Enabled = False
            End If

            If _Mov.IdCaricoMagazzino = 0 Then
                CaricoDiMagazzinoAnticipatoToolStripMenuItem.Enabled = False
            End If

            CalcolaPrezzoKg()

            If _Mov.TipoMov = enTipoMovMagaz.Inserimento Then
                txtCodiceForn.Text = _Mov.CodiceForn
                txtDescrForn.Text = _Mov.DescrForn
                txtNota.Text = _Mov.Nota
                MgrControl.SelectIndexCombo(cmbFornitore, _Mov.IdForn)
            End If

        Else
            If SelezionaTipo Then
                MgrControl.SelectIndexCombo(cmbTipoMov, SelezionaTipo)
                If BloccaTipoMov Then cmbTipoMov.Enabled = False
            Else
                MgrControl.SelectIndexCombo(cmbTipoMov, _TipoMov)
            End If

            If _MaxQta Then
                txtQta.Text = _MaxQta
            End If

        End If

        If _TipoMov = enTipoMovMagaz.Prenotazione Or
            SelezionaTipo = enTipoMovMagaz.Prenotazione Or
            _Mov.TipoMov = enTipoMovMagaz.Prenotazione Then
            cmbTipoMov.Enabled = False
            pnlRisorsa.Enabled = False
            btnSostituisci.Enabled = False
        End If


        If _IdRis Then
            'qui mi passa l'id risorsa e quindi la blocco a quella impostata
            Using ris As New Risorsa
                cmbRis.DataSource = Nothing

                ris.Read(_IdRis)
                cmbRis.ValueMember = "IdRis"
                cmbRis.DisplayMember = "DescrizioneWithId"

                _QtaDisp = ris.Giacenza
                cmbRis.Items.Clear()

                cmbRis.Items.Add(ris)

                pnlRisorsa.HeaderText = "(" & ris.IdRis & ") " & ris.Descrizione

            End Using
            MgrControl.SelectIndexCombo(cmbRis, _IdRis)
            'grpRisorsa.Enabled = False

        End If
    End Sub

    Friend Function Carica(Optional ByVal IdMov As Integer = 0,
                           Optional ByRef Mag As MovimentoMagazzino = Nothing,
                           Optional ByVal SelezionaTipo As enTipoMovMagaz = enTipoMovMagaz.Carico,
                           Optional ByVal BloccaTipoMov As Boolean = True) As Integer

        CaricamentoInterno(IdMov, Mag, SelezionaTipo, BloccaTipoMov)

        ShowDialog()

        Mag = _Mov

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Close()

    End Sub

    Private Sub txtPrezzo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrezzo.KeyPress
        MgrControl.ControlloNumerico(sender, e)
    End Sub

    Private Sub txtPrezzo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrezzo.TextChanged,
                                                                                                            txtQta.TextChanged

        If sender.text.length = 0 Then
            sender.text = "0"
        End If

        CalcolaPrezzoKg()

    End Sub

    Private Sub CalcolaPrezzoKg()

        If txtPrezzo.Text.Length Then
            If txtQta.Text.Length Then
                If IdRis Then
                    Using R As New Risorsa
                        R.Read(IdRis)
                        Dim ris As Decimal = 0

                        Try
                            ris = MgrPreventivazioneB.CalcolaPrezzoAlKgCarta(R.Lunghezza,
                                                                                     R.Larghezza,
                                                                                     R.Grammatura,
                                                                                     txtQta.Text,
                                                                                     txtPrezzo.Text)

                        Catch ex As Exception

                        End Try

                        lblPrezzoKg.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ris)
                    End Using

                End If

            End If
        End If

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Mov.TipoMov = cmbTipoMov.SelectedItem.id
            If _IdFat Then _Mov.IdFat = _IdFat
            If _IdCom Then _Mov.IdCom = _IdCom

            If _IdRis = 0 Then _IdRis = cmbRis.SelectedValue

            _Mov.IdRis = _IdRis
            _Mov.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
            _Mov.Prezzo = txtPrezzo.Text
            _Mov.Qta = txtQta.Text
            If _Mov.DataMov = Date.MinValue Then _Mov.DataMov = Date.Now
            Dim Err As Boolean = False

            If _MaxQta Then

                If _Mov.Qta > Math.Ceiling(_MaxQta) Then

                    MessageBox.Show("La quantità impostata è superiore al necessario! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Err = True

                End If

            End If

            If _Mov.Qta = 0 Then
                MessageBox.Show("Non si può inserire un movimento con quantità 0. Eliminare il movimento")
                Err = True
            End If

            'TODO:RIATTIVARE QUANDO CI SARA' LA GIUSTA GIACENZA DI MAGAZZINO
            'If _QtaDisp <> 0 And (_TipoMov = enTipoMovMagaz.Prenotazione Or _TipoMov = enTipoMovMagaz.Scarico) Then
            '    If _Mov.Qta > _QtaDisp And Err = False Then
            '        MessageBox.Show("La quantità impostata è superiore alla giacenza della risorsa! ", Postazione.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Err = True

            '    End If
            'End If

            If _Mov.TipoMov = enTipoMovMagaz.Inserimento Then

                If cmbFornitore.SelectedValue <> 0 Then ' And txtCodiceForn.Text.Trim.Length <> 0 And txtDescrForn.Text.Trim.Length <> 0 Then
                    _Mov.IdForn = cmbFornitore.SelectedValue
                    _Mov.CodiceForn = txtCodiceForn.Text
                    _Mov.DescrForn = txtDescrForn.Text
                    _Mov.Nota = txtNota.Text
                Else
                    MessageBox.Show("Il fornitore è obbligatorio! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Err = True
                End If

            End If

            If Err = False Then
                If _Mov.IsValid Then
                    If _Mov.TipoMov <> enTipoMovMagaz.Prenotazione Then

                        Dim IdIns As Integer = 0
                        Dim IdIniz As Integer = _Mov.IdCarMag

                        IdIns = _Mov.Save()

                        'If IdIniz <> 0 Then
                        '    Using M As New MagazzinoDAO
                        '        M.AggiornaQta(_Mov, _OldQta, _Mov.Qta)
                        '    End Using
                        'End If

                    End If
                    _Ris = 1
                    Close()
                Else
                    MessageBox.Show("La quantità è obbligatoria! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If

    End Sub

    Private Sub cmbTipoMov_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoMov.SelectedIndexChanged
        If cmbTipoMov.SelectedIndex <> -1 Then

            Dim x As cEnum = cmbTipoMov.SelectedItem
            If x.Id = enTipoMovMagaz.Carico Or
               x.Id = enTipoMovMagaz.RichiestaAcquisto Or
               x.Id = enTipoMovMagaz.Inserimento Then

                lblPrezzo.Visible = True
                txtPrezzo.Visible = True

            Else

                lblPrezzo.Visible = False
                txtPrezzo.Visible = False

            End If

            If x.Id = enTipoMovMagaz.Inserimento Then
                grpFornitore.Visible = True
            Else
                grpFornitore.Visible = False
            End If

            If x.Id = enTipoMovMagaz.Storno Then
                txtQta.My_AccettaNegativi = True
            Else
                txtQta.My_AccettaNegativi = False
            End If



        End If
    End Sub

    Private Sub txtCerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCerca.TextChanged
        'qui devo cercare tra le risorse per descrizione, codice a barre associato o codice interno

        Dim TestoDaCercare As String = txtCerca.Text

        If TestoDaCercare.Length Then

            Using mgr As New RisorseDAO
                Dim l As List(Of Risorsa) = mgr.Cerca(TestoDaCercare)

                cmbRis.DataSource = l
                cmbRis.ValueMember = "IdRis"
                cmbRis.DisplayMember = "DescrizioneWithId"
            End Using




            'Using RisorseColl As New cRisorseColl
            '    Dim DT As DataTable
            '    DT = RisorseColl.Cerca(TestoDaCercare)

            '    cmbRis.DataSource = DT
            '    cmbRis.ValueMember = "IdRis"
            '    cmbRis.DisplayMember = "Descr"
            'End Using
        End If

    End Sub

    Private Sub lnkPeso_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Sottofondo()
        Using x As New frmCalcPeso
            x.Carica()
        End Using
        Sottofondo()
    End Sub

    Private Sub lnkRisorsa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Sottofondo()
        Using f As New frmMagazzinoRisorsa
            f.Carica(_Mov.IdRis)
        End Using
        Sottofondo()
    End Sub

    Private Sub lnkApriCommessa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        If _Mov.IdCom Then
            Using mgr As New CommesseDAO
                Dim l As List(Of Commessa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Commessa.IdCom, _Mov.IdCom))
                If l.Count Then
                    Sottofondo()
                    Using f As New frmCommessa
                        f.Carica(_Mov.IdCom)
                    End Using
                    Sottofondo()
                Else
                    MessageBox.Show("Commessa non disponibile")
                End If
            End Using

        Else
            MessageBox.Show("Commessa non disponibile")
        End If

    End Sub

    Private Sub btnDettRis_Click(sender As Object, e As EventArgs) Handles btnDettRis.Click
        If cmbRis.SelectedValue Then
            Sottofondo()
            Using f As New frmMagazzinoRisorsa
                f.Carica(cmbRis.SelectedValue)
            End Using
            Sottofondo()
        End If
    End Sub

    Private Sub btnSostituisci_Click(sender As Object, e As EventArgs) Handles btnSostituisci.Click

        If cmbRis.SelectedValue <> _IdRis Then
            If _Mov.IdCarMag Then
                If MessageBox.Show("Confermi la sostituzione della risorsa con questa selezionata in questo movimento? ATTENZIONE NON REVERSIBILE", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim IdOldRis As Integer = _Mov.IdRis

                    _Mov.IdRis = cmbRis.SelectedValue
                    _Mov.Save()

                    Using mgr As New MagazzinoDAO
                        mgr.AggiornaQta(IdOldRis)
                        mgr.AggiornaQta(_Mov.IdRis)
                    End Using
                    CaricamentoInterno(_Mov.IdCarMag)
                    pnlRisorsa.Collapse()
                End If
            Else
                MessageBox.Show("Impossibile effettuare la sostituzione")
            End If
        Else
            MessageBox.Show("Selezionare una risorsa differente da quella in uso")
        End If

    End Sub

    Private Sub PesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesoToolStripMenuItem.Click
        Sottofondo()
        Using x As New frmCalcPeso
            x.Carica()
        End Using
        Sottofondo()
    End Sub

    Private Sub ApriRisorsaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ApriCommessaToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub SalvaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvaToolStripMenuItem.Click

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Mov.TipoMov = cmbTipoMov.SelectedItem.id
            If _IdFat Then _Mov.IdFat = _IdFat
            If _IdCom Then _Mov.IdCom = _IdCom

            If _IdRis = 0 Then _IdRis = cmbRis.SelectedValue

            _Mov.IdRis = _IdRis
            _Mov.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
            _Mov.Prezzo = txtPrezzo.Text
            _Mov.Qta = txtQta.Text
            If _Mov.DataMov = Date.MinValue Then _Mov.DataMov = Date.Now
            Dim Err As Boolean = False

            If _MaxQta Then

                If _Mov.Qta > Math.Ceiling(_MaxQta) Then

                    MessageBox.Show("La quantità impostata è superiore al necessario! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Err = True

                End If

            End If

            If _Mov.Qta = 0 Then
                MessageBox.Show("Non si può inserire un movimento con quantità 0. Eliminare il movimento")
                Err = True
            End If

            'TODO:RIATTIVARE QUANDO CI SARA' LA GIUSTA GIACENZA DI MAGAZZINO
            'If _QtaDisp <> 0 And (_TipoMov = enTipoMovMagaz.Prenotazione Or _TipoMov = enTipoMovMagaz.Scarico) Then
            '    If _Mov.Qta > _QtaDisp And Err = False Then
            '        MessageBox.Show("La quantità impostata è superiore alla giacenza della risorsa! ", Postazione.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Err = True

            '    End If
            'End If

            If _Mov.TipoMov = enTipoMovMagaz.Inserimento Then

                If cmbFornitore.SelectedValue <> 0 Then ' And txtCodiceForn.Text.Trim.Length <> 0 And txtDescrForn.Text.Trim.Length <> 0 Then
                    _Mov.IdForn = cmbFornitore.SelectedValue
                    _Mov.CodiceForn = txtCodiceForn.Text
                    _Mov.DescrForn = txtDescrForn.Text
                    _Mov.Nota = txtNota.Text
                Else
                    MessageBox.Show("Il fornitore è obbligatorio! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Err = True
                End If

            End If

            If Err = False Then
                If _Mov.IsValid Then
                    If _Mov.TipoMov <> enTipoMovMagaz.Prenotazione Then

                        Dim IdIns As Integer = 0
                        Dim IdIniz As Integer = _Mov.IdCarMag

                        IdIns = _Mov.Save()

                        'If IdIniz <> 0 Then
                        '    Using M As New MagazzinoDAO
                        '        M.AggiornaQta(_Mov, _OldQta, _Mov.Qta)
                        '    End Using
                        'End If

                    End If
                    _Ris = 1
                    Close()
                Else
                    MessageBox.Show("La quantità è obbligatoria! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If

    End Sub

    Private Sub ChiudiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChiudiToolStripMenuItem.Click

        Close()

    End Sub

    Private Sub RisorsaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RisorsaToolStripMenuItem.Click
        Sottofondo()
        Using f As New frmMagazzinoRisorsa
            f.Carica(_Mov.IdRis)
        End Using
        Sottofondo()
    End Sub

    Private Sub CommessaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommessaToolStripMenuItem.Click

        If _Mov.IdCom Then
            Using mgr As New CommesseDAO
                Dim l As List(Of Commessa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Commessa.IdCom, _Mov.IdCom))
                If l.Count Then
                    Sottofondo()
                    Using f As New frmCommessa
                        f.Carica(_Mov.IdCom)
                    End Using
                    Sottofondo()
                Else
                    MessageBox.Show("Commessa non disponibile")
                End If
            End Using

        Else
            MessageBox.Show("Commessa non disponibile")
        End If
    End Sub

    Private Sub CaricoDiMagazzinoAnticipatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaricoDiMagazzinoAnticipatoToolStripMenuItem.Click

        If _Mov.IdCaricoMagazzino Then
            Using mgr As New CarichiDiMagazzinoDAO
                Dim l As List(Of CaricoDiMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdCaricoMagazzino, _Mov.IdCaricoMagazzino))
                If l.Count Then
                    Sottofondo()
                    Using f As New frmMagazzinoCaricoDiMagazzino
                        f.Carica(_Mov.IdCaricoMagazzino)
                    End Using
                    Sottofondo()
                Else
                    MessageBox.Show("Carico di Magazzino non disponibile")
                End If
            End Using

        Else
            MessageBox.Show("Carico di Magazzino non disponibile")
        End If
    End Sub
End Class