Imports Fw = FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerLib

Friend Class frmRecensione
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0
    Private _Review As Fw.Review

    Friend Function Carica(ByRef Review As Fw.Review) As Integer

        _Review = Review

        lblCliente.Text = _Review.UtenteStr

        lblProdotto.Text = _Review.ListinoBase.Nome

        If _Review.Voto >= 1 Then
            pctStarFull1.Visible = True
        End If
        If _Review.Voto >= 2 Then
            pctStarFull2.Visible = True
        End If
        If _Review.Voto >= 3 Then
            pctStarFull3.Visible = True
        End If
        If _Review.Voto >= 4 Then
            pctStarFull4.Visible = True
        End If
        If _Review.Voto = 5 Then
            pctStarFull5.Visible = True
        End If

        lblVoto.Text = _Review.Voto & " su 5 stelle"

        lblPro.Text = _Review.Pregi
        lblContro.Text = _Review.Difetti

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'Dim x As Char = vbCr
        'If e.KeyChar = x Then
        '    e.Handled = True
        '    SendKeys.Send(vbTab)

        'End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object,
                                ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object,
                            e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi l' APPROVAZIONE della recensione? La recensione sarà conteggiata e, se previsto, verrà emesso un coupon di sconto in favore dell'utente del valore di " & FormerHelper.Stringhe.FormattaPrezzo(FormerConst.Coupon.ImportoCouponScontoPerRecensione) & " €.", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                _Review.Stato = enStatoReview.Approvata
                _Review.Risposta = txtRisposta.Text
                _Review.Save()

                Dim CouponEmesso As Boolean = False

                'qui se la risposta e' stata data va inviata tramite email a chi aveva inserito la recensione
                'If _Review.Risposta.Trim.Length Then
                '    InviaMailRispostaReview(_Review.Utente.Email)
                'End If

                If _Review.PrevedeCoupon = enSiNo.Si Then
                    If FormerConst.Coupon.ImportoCouponScontoPerRecensione Then
                        'qui vado a creare il coupon
                        Using C As New Fw.CouponW
                            C.IdLavoro = _Review.IdLavoro

                            Dim CodiceCoupon As String = String.Empty
                            Using mgr As New Fw.CouponWDAO
                                CodiceCoupon = mgr.GetCodiceCoupon(_Review.ListinoBase.Preventivazione.Prefisso.ToUpper, _Review.IdUt)
                            End Using
                            Dim ggValid As Integer = 30

                            If _Review.Utente.TipoRub = enTipoRubrica.Cliente Then ggValid = 90

                            C.VisibileOnline = enSiNo.No
                            C.Riservato = _Review.IdUt
                            C.RiservatoATipoUtente = _Review.Utente.TipoRub
                            C.QtaSpecifica = 0
                            C.IdListinoBase = 0
                            C.DataInizioValidita = Now
                            C.DataFineValidita = Now.AddDays(ggValid)
                            C.MaxVolte = 1
                            C.Stato = enStato.Attivo
                            C.ImportoFisso = FormerConst.Coupon.ImportoCouponScontoPerRecensione
                            C.Nome = "Coupon automatico Rif. Recensione " & _Review.IdReview
                            C.Codice = CodiceCoupon
                            C.IdLavoro = _Review.IdLavoro
                            C.Save()
                            CouponEmesso = True
                            Try
                                InviaMailCoupon(C, _Review.Utente.Email)
                            Catch ex As Exception

                            End Try
                        End Using
                    End If
                End If

                MessageBox.Show("Recensione approvata. " & IIf(CouponEmesso, " E' stato emesso un Coupon in favore del Cliente", ""))

                _Ris = 1
                Close()

            Catch ex As Exception
                ManageError(ex)
            End Try

        End If

    End Sub

    Private Sub txtCodice_TextChanged(sender As Object,
                                      e As EventArgs) Handles txtRisposta.TextChanged
        lblCounter.Text = "(" & (500 - txtRisposta.Text.Length) & "/500)"
    End Sub

    'Private Sub InviaMailRispostaReview(Email As String)

    '    'INVIO MAIL DI CONFERMA DELL'ORDINE RICEVUTO

    '    Dim Buffer As String = "Gentile Cliente<br><br>Grazie per la tua recensione, hai ricevuto la seguente risposta: "

    '    Try
    '        FormerHelper.Mail.InviaMail("Grazie per la tua recensione, hai ricevuto una Risposta", Buffer, Email)
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub InviaMailCoupon(C As Fw.CouponW,
                                Email As String)

        'INVIO MAIL DI CONFERMA DELL'ORDINE RICEVUTO

        Dim Pt As New My.Templates.MailCoupon
        Pt.C = C
        Dim Buffer As String = Pt.TransformText

        Try
            FormerHelper.Mail.InviaMail("Grazie per la tua recensione, hai ricevuto un Coupon di Sconto", Buffer, Email)
        Catch ex As Exception

        End Try

    End Sub

End Class