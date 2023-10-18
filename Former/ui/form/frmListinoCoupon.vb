Imports FormerDALSql
Imports FormerLib.FormerEnum
Friend Class frmListinoCoupon
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _IdCoupon As Integer = 0
    Private _IdRub As Integer = 0

    Friend Function Carica(Optional IdCoupon As Integer = 0, Optional IdRub As Integer = 0) As Integer

        _IdCoupon = IdCoupon
        _IdRub = IdRub
        CaricaCombo()

        If IdCoupon Then

            'riapro
            Dim C As New Coupon
            C.Read(IdCoupon)
            txtCodice.Text = C.Codice
            txtNome.Text = C.Nome
            dtStart.Value = C.DataInizioValidita
            dtEnd.Value = C.DataFineValidita
            txtPerc.Text = C.Percentuale
            txtImportoFisso.Text = C.ImportoFisso
            txtMinimoDiSpesa.Text = C.ImportoMinimoSpesa
            If C.Riservato Then MgrControl.SelectIndexCombo(cmbCli, C.Riservato)
            If C.IdListinoBase Then MgrControl.SelectIndexCombo(cmbTipoProd, C.IdListinoBase)
            txtQtaSpec.Text = C.QtaSpecifica
            txtMaxVolte.Text = C.MaxVolte

            If C.RiservatoATipoUtente = enTipoRubrica.Cliente Then
                rdoCli.Checked = True
            ElseIf C.RiservatoATipoUtente = enTipoRubrica.Rivenditore Then
                rdoRiv.Checked = True
            End If

            If C.IdCouponOnline Then
                lblStato.BackColor = Color.Green
                lblStato.Text = "Pubblicato"
            End If

            If C.VisibileOnline = enSiNo.Si Then
                chkVisibOnline.Checked = True
            End If

            txtCodice.ReadOnly = True
        Else
            'nuovo

            dtStart.Value = Now
            dtEnd.Value = Now.AddMonths(1)

        End If

        If IdRub Then
            MgrControl.SelectIndexCombo(cmbCli, _IdRub)
            cmbCli.Enabled = False
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.FindAll(New LUNA.LSO() With {.OrderBy = "IdPrev,Nome", .AddEmptyItem = True},
                                                        New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No),
                                                        New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0, "<>"))
            l.Sort(Function(x, y) x.RiassuntoConPreventivazione.CompareTo(y.RiassuntoConPreventivazione))
            cmbTipoProd.DisplayMember = "RiassuntoConPreventivazione"
            cmbTipoProd.ValueMember = "IdListinoBase"
            cmbTipoProd.DataSource = l
        End Using

        Using mgr As New VociRubricaDAO
            Dim l As List(Of VoceRubrica) = mgr.GetAll(LFM.VoceRubrica.RagSoc, True)
            cmbCli.DisplayMember = "RagSocNome"
            cmbCli.ValueMember = "IdRub"
            cmbCli.DataSource = l
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

        Dim CheckOk As String = String.Empty
        If txtNome.Text.Length = 0 Then
            CheckOk = "Inserire un nome; "
        End If

        If txtPerc.Text = "0" And txtImportoFisso.Text = "0" Then
            CheckOk &= "Inserire una percentuale o un importo fisso; "
        End If

        If txtPerc.Text <> "0" And txtImportoFisso.Text <> "0" Then
            CheckOk &= "Inserire una percentuale o un importo fisso; "
        End If

        If CheckOk.Length Then
            MessageBox.Show("Attenzione: " & CheckOk)
        Else
            If MessageBox.Show("Confermi il salvataggio del coupon?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim C As New Coupon
                If _IdCoupon Then
                    C.Read(_IdCoupon)
                End If
                Dim IdUtOnline As Integer = 0

                C.Codice = txtCodice.Text
                C.Nome = txtNome.Text
                C.IdListinoBase = cmbTipoProd.SelectedValue
                C.Riservato = cmbCli.SelectedValue
                C.Percentuale = txtPerc.Text
                C.ImportoFisso = txtImportoFisso.Text
                C.ImportoMinimoSpesa = txtMinimoDiSpesa.Text
                C.QtaSpecifica = txtQtaSpec.Text
                C.MaxVolte = txtMaxVolte.Text
                C.DataInizioValidita = dtStart.Value
                C.DataFineValidita = dtEnd.Value

                C.VisibileOnline = IIf(chkVisibOnline.Checked, enSiNo.Si, enSiNo.No)
                If rdoCli.Checked Then
                    C.RiservatoATipoUtente = enTipoRubrica.Cliente
                ElseIf rdoRiv.Checked Then
                    C.RiservatoATipoUtente = enTipoRubrica.Rivenditore
                ElseIf rdoTutti.Checked Then
                    C.RiservatoATipoUtente = 0
                End If

                C.Save()

                If C.Riservato Then
                    Dim V As New VoceRubrica
                    V.Read(cmbCli.SelectedValue)
                    IdUtOnline = V.IdUtOnline
                End If

                Dim CheckOkPubbl As Boolean = True

                If C.Riservato Then
                    If IdUtOnline = 0 Then CheckOkPubbl = False
                End If

                If CheckOkPubbl Then
                    If MessageBox.Show("Vuoi pubblicare il coupon inserendolo o aggiornandolo online?", "Pubblicazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        'qui lo pubblico/aggiorno online

                        Using tb As FormerDALWeb.LUNA.LunaTransactionBox = FormerDALWeb.LUNA.LunaContext.CreateTransactionBox()
                            Try
                                Using mgr As New FormerDALWeb.CouponWDAO
                                    Dim Conl As FormerDALWeb.CouponW
                                    If C.IdCouponOnline Then
                                        Conl = mgr.Read(C.IdCouponOnline)
                                    Else
                                        Conl = New FormerDALWeb.CouponW
                                    End If
                                    Conl.Codice = C.Codice
                                    Conl.Nome = C.Nome
                                    Conl.IdListinoBase = C.IdListinoBase
                                    'quando lo porto online devo salvare l'id del cliente online non qui
                                    Conl.Riservato = IdUtOnline
                                    Conl.Percentuale = C.Percentuale
                                    Conl.ImportoFisso = C.ImportoFisso
                                    Conl.ImportoMinimoSpesa = C.ImportoMinimoSpesa
                                    Conl.QtaSpecifica = C.QtaSpecifica
                                    Conl.MaxVolte = C.MaxVolte
                                    Conl.DataInizioValidita = C.DataInizioValidita
                                    Conl.DataFineValidita = C.DataFineValidita
                                    Conl.RiservatoATipoUtente = C.RiservatoATipoUtente
                                    Conl.IdCouponInt = C.IdCoupon
                                    tb.TransactionBegin()
                                    mgr.Save(Conl)
                                    If Conl.IdCoupon = 0 Then
                                        Throw New Exception("IdCouponOnline non inserito")
                                    End If
                                    C.IdCouponOnline = Conl.IdCoupon
                                    C.Save()
                                    tb.TransactionCommit()

                                End Using
                            Catch ex As Exception
                                tb.TransactionRollBack()
                                MessageBox.Show("Si è verificato un errore nella pubblicazione del Coupon, riprovare. Errore " & ex.Message, "Errore")
                            End Try
                        End Using

                    End If
                Else
                    MessageBox.Show("Il coupon inserito è riservato a un cliente non ancora presente sul sito")
                End If

                _Ris = 1
                Close()
            End If
        End If

    End Sub

    Private Sub cmbCli_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCli.SelectedIndexChanged

        If cmbCli.SelectedValue Then
            Dim V As New VoceRubrica
            V.Read(cmbCli.SelectedValue)
            If V.Tipo = enTipoRubrica.Cliente Then
                rdoCli.Checked = True
            Else
                rdoRiv.Checked = True
            End If
            rdoRiv.Enabled = False
            rdoCli.Enabled = False
            rdoTutti.Enabled = False
        Else
            rdoTutti.Checked = True
            rdoRiv.Enabled = True
            rdoCli.Enabled = True
            rdoTutti.Enabled = True
        End If

        GeneraCodice()

    End Sub

    Private Sub GeneraCodice()

        Dim Pref As String = ""
        Dim IdUtente As Integer = 0

        If cmbTipoProd.SelectedValue Then
            Dim L As New ListinoBase
            L.Read(cmbTipoProd.SelectedValue)
            Pref = L.Preventivazione.Prefisso
        End If

        If cmbCli.SelectedValue Then
            Dim V As New VoceRubrica
            V.Read(cmbCli.SelectedValue)
            IdUtente = V.IdUtOnline
        End If

        Using mgr As New CouponDAO
            txtCodice.Text = mgr.GetCodiceCoupon(Pref, IdUtente)
        End Using
    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoProd.SelectedIndexChanged
        GeneraCodice()
    End Sub
End Class