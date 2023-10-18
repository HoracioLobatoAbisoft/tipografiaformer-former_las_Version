Friend Class frmCalcNumerazioneDuplicato
    'Inherits baseFormInternaFixed

    Private _D As NumerazioneDuplicato = Nothing

    Friend Function Carica(Optional D As NumerazioneDuplicato = Nothing) As NumerazioneDuplicato

        Dim objFontCollection As System.Drawing.Text.FontCollection
        objFontCollection = New System.Drawing.Text.InstalledFontCollection()
        For Each objFontFamily In objFontCollection.Families
            cmbFont.Items.Add(objFontFamily.Name)
        Next


        If D Is Nothing Then
            _D = New NumerazioneDuplicato
        Else
            _D = D


            txtPrefisso.Text = D.Prefisso
            txtSuffisso.Text = D.Suffisso
            txtBassoX.Text = D.PrimoAngoloBassoSx_X
            txtBassoY.Text = D.PrimoAngoloBassoSx_Y

            txtGrandezzaFont.Text = D.FontGrandezza
            MgrControl.SelectIndexCombo(cmbFont, D.FontNome)

            chkRuota.Checked = D.Rotazione
            lblOrient.Text = D.RotazioneGradi

        End If

        ShowDialog()

        Return _D

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _D = Nothing
        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi i dati inseriti?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _D.FontNome = cmbFont.Text
            _D.FontGrandezza = txtGrandezzaFont.Text

            _D.PrimoAngoloBassoSx_X = txtBassoX.Text
            _D.PrimoAngoloBassoSx_Y = txtBassoY.Text

            _D.Prefisso = txtPrefisso.Text
            _D.Suffisso = txtSuffisso.Text
            _D.Rotazione = chkRuota.Checked
            _D.RotazioneGradi = lblOrient.Text

            Close()

        End If
    End Sub

    Private Sub lblOrient_Click(sender As Object, e As EventArgs) Handles lblOrient.Click
        If sender.text = 90 Then
            sender.text = 180
        ElseIf sender.text = 180 Then
            sender.text = 270
        Else
            sender.text = 90
        End If
    End Sub
End Class