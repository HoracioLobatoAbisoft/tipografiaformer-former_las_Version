Imports FormerDALSql
Imports FormerLib.FormerEnum
Friend Class frmListinoPromo
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _IdPromo As Integer = 0
    Private _P As Promo = Nothing

    Friend Function Carica(Optional IdPromo As Integer = 0) As Integer

        _IdPromo = IdPromo

        _P = New Promo
        If IdPromo Then
            _P.Read(IdPromo)
        End If

        CaricaCombo()

        If IdPromo Then

            'riapro
            dtEnd.Value = _P.DataFineValidita
            txtPerc.Text = _P.Percentuale
            MgrControl.SelectIndexCombo(cmbTipoProd, _P.IdListinoBase)
            If _P.IdPromoOnline Then
                lblStato.BackColor = Color.Green
                lblStato.Text = "Pubblicato"
            End If
        Else
            'nuovo
            dtEnd.Value = Now.Date.AddMonths(1)
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using mgr As New ListinoBaseDAO

            Dim l As List(Of ListinoBase) = mgr.ListiniValidiPerPromo(enTipoListiniBase.Produzione, _P.IdListinoBase)
            l.Sort(Function(x, y) x.RiassuntoConPreventivazione.CompareTo(y.RiassuntoConPreventivazione))

            cmbTipoProd.DisplayMember = "NomeEx"
            cmbTipoProd.ValueMember = "IdListinoBase"
            cmbTipoProd.DataSource = l
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

        If cmbTipoProd.SelectedValue = 0 Then
            CheckOk &= "Selezionare un listino base; "
        End If

        If txtPerc.Text = "0" Then
            CheckOk &= "Inserire una percentuale di sconto; "
        End If

        If CheckOk.Length Then
            MessageBox.Show("Attenzione: " & CheckOk)
        Else
            If MessageBox.Show("Confermi il salvataggio del PROMO?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim C As New Promo
                If _IdPromo Then
                    C.Read(_IdPromo)
                End If

                Dim DataFine As New Date(dtEnd.Value.Date.Year, dtEnd.Value.Date.Month, dtEnd.Value.Date.Day, 23, 59, 0)

                C.IdListinoBase = cmbTipoProd.SelectedValue
                C.Percentuale = txtPerc.Text
                C.DataFineValidita = DataFine
                C.Stato = enStato.Attivo

                C.Save()

                If MessageBox.Show("Vuoi pubblicare il PROMO inserendolo o aggiornandolo online?", "Pubblicazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    'qui lo pubblico/aggiorno online

                    Dim i As Integer = 0

                    For i = 0 To 1

                        If i = 1 Then
                            FormerDALWeb.LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin
                        End If

                        Using tb As FormerDALWeb.LUNA.LunaTransactionBox = FormerDALWeb.LUNA.LunaContext.CreateTransactionBox()
                            Try
                                Using mgr As New FormerDALWeb.PromoWDAO
                                    Dim Conl As FormerDALWeb.PromoW
                                    If C.IdPromoOnline Then
                                        Conl = mgr.Read(C.IdPromoOnline)
                                    Else
                                        Conl = New FormerDALWeb.PromoW
                                    End If
                                    Conl.IdListinoBase = C.IdListinoBase
                                    'quando lo porto online devo salvare l'id del cliente online non qui
                                    Conl.Percentuale = C.Percentuale
                                    Conl.QtaSpecifica = C.QtaSpecifica
                                    Conl.DataFineValidita = C.DataFineValidita
                                    Conl.IdPromoInt = C.IdPromo
                                    tb.TransactionBegin()
                                    mgr.Save(Conl)
                                    If Conl.IdPromo = 0 Then
                                        Throw New Exception("IdCouponOnline non inserito")
                                    End If
                                    If i = 0 Then C.IdPromoOnline = Conl.IdPromo
                                    C.Save()
                                    tb.TransactionCommit()

                                End Using
                            Catch ex As Exception
                                tb.TransactionRollBack()
                                MessageBox.Show("Si è verificato un errore nella pubblicazione del Coupon " & IIf(i = 0, "online", " sul server web interno") & ", riprovare. Errore " & ex.Message, "Errore")
                            End Try
                        End Using
                    Next
                    FormerDALWeb.LUNA.LunaContext.ConnectionString = String.Empty

                End If

                _Ris = 1
                Close()
            End If
        End If

    End Sub

End Class