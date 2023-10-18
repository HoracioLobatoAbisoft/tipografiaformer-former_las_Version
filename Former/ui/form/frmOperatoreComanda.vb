Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmOperatoreComanda
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        CaricaCombo()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using Ut As New UtentiDAO

            Dim l As List(Of Utente) = Ut.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "Login", .AddEmptyItem = False},
                                                  New LUNA.LunaSearchParameter(LFM.Utente.Tipo, enTipoUtente.Operatore),
                                                  New LUNA.LunaSearchParameter(LFM.Utente.Attivo, enSiNo.Si))
            cmbDest.ValueMember = "IdUt"
            cmbDest.DisplayMember = "Login"
            cmbDest.DataSource = l
        End Using

    End Sub

    'Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    Dim x As Char = vbCr

    '    If e.KeyChar = x Then
    '        e.Handled = True
    '        SendKeys.Send(vbTab)

    '    End If
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtContenuto.Text.Trim.Length Then
            If MessageBox.Show("Confermi la stampa della comanda?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim UtSel As Utente = cmbDest.SelectedItem
                'Dim Messaggio As String = ""

                'Messaggio = "per " & UtSel
                Dim IdComanda As Integer = 0
                Using P As New Messaggio
                    P.IdMitt = PostazioneCorrente.UtenteConnesso.IdUt
                    P.IdDest = UtSel.IdUt
                    P.TipoMsg = enTipoMessaggio.Messaggio
                    P.DataIns = Now
                    P.Titolo = "Stampa comanda da " & PostazioneCorrente.UtenteConnesso.Login
                    P.Testo = txtContenuto.Text
                    P.Save()
                    IdComanda = P.IdPostit
                End Using

                If IdComanda Then FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_PrinterComanda, IdComanda)

                _Ris = 1
                Close()

            End If
        Else
            MessageBox.Show("Inserire il testo della comanda")
        End If

    End Sub

    Private Sub pctTipo_Click(sender As Object, e As EventArgs) Handles pctTipo.Click

        'If FormerDebug.DebugAttivo Then
        '    Using M As New Messaggio
        '        M.Read(38707)
        '        FormerPrinter.ProxyStampa.StampaComandaOperatore(M)
        '    End Using
        'End If

    End Sub

End Class