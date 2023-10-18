Imports FormerDALSql
Imports FormerBusinessLogic

Friend Class frmSelectDefaultFP
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0

    Private Sub CaricaCombo()

        Using mgr As New FormatiProdottoDAO

            cmbFP.ValueMember = "IdFormatoProdotto"
            cmbFP.DisplayMember = "Formato"
            cmbFP.DataSource = mgr.FindAll(LFM.FormatoProdotto.Formato,
                                           New LUNA.LunaSearchParameter(LFM.FormatoProdotto.IdCatFormatoProdotto, _IdCat))

        End Using

        Using mgr As New PreventivazioniDAO

            cmbP.ValueMember = "IdPrev"
            cmbP.DisplayMember = "Descrizione"
            cmbP.DataSource = mgr.FindAll(LFM.Preventivazione.Descrizione,
                                           New LUNA.LunaSearchParameter(LFM.Preventivazione.IdPrev, "(Select IdPreventivazione from TR_DefaultFormatoPrev)", "NOT IN"))

        End Using

    End Sub

    Private _IdCat As Integer = 0

    Friend Function Carica(IdCat As Integer) As Integer

        _IdCat = IdCat

        CaricaCombo()

        ShowDialog()

        Return _Ris

    End Function

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

        If MessageBox.Show("Confermi la scelta del default selezionato?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'qui controllo se c'e' gia e avviso 

            Dim GiaInCat As Boolean = True

            Dim fp As FormatoProdotto = DirectCast(cmbFP.SelectedItem, FormatoProdotto)
            Dim p As Preventivazione = DirectCast(cmbP.SelectedItem, Preventivazione)

            If GiaInCat Then

                Using dfp As New DefaultFormatoProdotto
                    dfp.IdPreventivazione = p.IdPrev
                    dfp.IdFormatoProdotto = fp.IdFormProd
                    dfp.IdCatFormatoProdotto = _IdCat
                    dfp.Save()

                    _Ris = dfp.IdDefaultFormatoPrev
                End Using
                Close()
            End If

        End If

    End Sub

End Class