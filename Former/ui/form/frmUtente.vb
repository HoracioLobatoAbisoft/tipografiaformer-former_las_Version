Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmUtente
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private Operatore As New Utente
    Private _IdOper As Integer = 0

    Friend Function Carica(Optional ByRef IdOper As Integer = 0) As Integer

        _IdOper = IdOper
        CaricaCombo()

        If IdOper Then
            Operatore.Read(IdOper)
            txtLogin.Text = Operatore.Login
            txtPassword.Text = Operatore.Pwd
            txtNomeReale.Text = Operatore.NomeReale
            MgrControl.SelectIndexCombo(cmbTipo, Operatore.Tipo)
            chkAttivo.Checked = Operatore.Attivo
            chkRepImballaggio.Checked = IIf(Operatore.AbilitaRepartoImballaggio = enSiNo.Si, True, False)
            txtFoto.Text = Operatore.PathFoto

            txtStipendio.Text = Operatore.RedditoLordoMese

            Try
                cmbMensilita.Text = Operatore.NumeroMensilita
                'MgrControl.SelectIndexCombo(cmbMensilita, Operatore.NumeroMensilita)
            Catch ex As Exception

            End Try

            Try
                pctOperatore.Image = Image.FromFile(txtFoto.Text)
            Catch ex As Exception

            End Try

            MgrControl.SelectIndexComboEnum(cmbAzienda, Operatore.idAzienda)
        Else
            chkAttivo.Checked = True
        End If
        CaricaMacchinari()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaMacchinari()
        Using MgrCarat As New MacchinariDAO()
            Dim LstCarat As List(Of Macchinario) = MgrCarat.GetAll("Tipo,Descrizione")

            For Each caratt As Macchinario In LstCarat
                Dim Selezionato As Boolean = False

                If _IdOper Then
                    Using MgrCaratCat As New UtMacDAO()
                        Dim Par1 As New LUNA.LunaSearchParameter(LFM.UtMac.IdUt, _IdOper)
                        Dim Par2 As New LUNA.LunaSearchParameter(LFM.UtMac.IdMac, caratt.IdMacchinario)
                        Dim NumTrov As Integer = MgrCaratCat.FindAll(Par1, Par2).Count
                        If NumTrov Then Selezionato = True
                    End Using

                End If

                chkMacchinari.Items.Add(caratt, Selezionato)

            Next
        End Using
    End Sub

    Private Sub CaricaCombo()

        Dim TipoOper As New cTipoOper
        cmbTipo.DataSource = TipoOper
        cmbTipo.ValueMember = "Id"
        cmbTipo.DisplayMember = "Descrizione"

        Dim laz As New List(Of cEnum)
        Dim az1 As New cEnum(MgrAziende.IdAziende.AziendaSnc, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSnc))
        laz.Add(az1)
        Dim az2 As New cEnum(MgrAziende.IdAziende.AziendaSrl, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSrl))
        laz.Add(az2)

        cmbAzienda.ValueMember = "Id"
        cmbAzienda.DisplayMember = "Descrizione"
        cmbAzienda.DataSource = laz

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If cmbTipo.SelectedValue = enTipoUtente.Admin Or
            (chkRepImballaggio.Checked = True Or chkMacchinari.CheckedItems.Count > 0) Then

            Operatore.Login = txtLogin.Text
            Operatore.Pwd = txtPassword.Text
            Operatore.NomeReale = txtNomeReale.Text
            Operatore.Tipo = cmbTipo.SelectedValue
            Operatore.RepDefault = 0
            Operatore.Attivo = chkAttivo.Checked
            Operatore.AbilitaRepartoImballaggio = IIf(chkRepImballaggio.Checked, enSiNo.Si, enSiNo.No)
            Operatore.PathFoto = txtFoto.Text

            If txtStipendio.Text.Length Then
                Operatore.RedditoLordoMese = txtStipendio.Text
            Else
                Operatore.RedditoLordoMese = 0
            End If

            Operatore.NumeroMensilita = cmbMensilita.Text
            Operatore.idAzienda = DirectCast(cmbAzienda.SelectedItem, cEnum).Id

            Dim GiaTrovato As Boolean = False
            Using mgr As New UtentiDAO
                Dim l As List(Of Utente) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Utente.IdUt, Operatore.IdUt, "<>"),
                                                       New LUNA.LunaSearchParameter(LFM.Utente.Login, Operatore.Login))

                If l.Count Then GiaTrovato = True
            End Using
            If Operatore.IsValid = True And GiaTrovato = False Then
                Operatore.Save()

                Using M As New UtMacDAO()
                    M.DeleteByIdOper(Operatore.IdUt)
                End Using
                For Each C As Macchinario In chkMacchinari.CheckedItems
                    Dim MSing As New UtMac With {.IdUt = _IdOper, .IdMac = C.IdMacchinario}
                    MSing.Save()
                Next
                _Ris = 1
                Close()
            Else
                MessageBox.Show("Controllare i dati inseriti, la Login deve essere univoca e la password non può essere vuota!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Selezionare almeno un macchinario di produzione o abilitare il reparto di imballaggio!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub txtLogin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLogin.TextChanged

        Operatore.Login = txtLogin.Text
        Using mgr As New UtentiDAO

            If mgr.NotUnique(Operatore) Then
                pctAlertCodice.Visible = True
            Else
                pctAlertCodice.Visible = False
            End If
        End Using
    End Sub

    Private Sub chkMacchinari_SelectedValueChanged(sender As Object, e As EventArgs) Handles chkMacchinari.SelectedValueChanged

        Dim Counter As Integer = chkMacchinari.CheckedItems.Count

        grpMacchinari.Text = grpMacchinari.Tag & " (" & Counter & ")"

    End Sub

    Private Sub btnSfoglia_Click(sender As Object, e As EventArgs) Handles btnSfoglia.Click
        dlgFoto.ShowDialog()

        If dlgFoto.FileName.Length Then
            txtFoto.Text = dlgFoto.FileName
            pctOperatore.Image = Image.FromFile(txtFoto.Text)
        End If
    End Sub

End Class