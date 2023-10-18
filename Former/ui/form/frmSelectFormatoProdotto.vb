Imports FormerDALSql
Imports FormerBusinessLogic

Friend Class frmSelectFormatoProdotto
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0

    Private Sub CaricaCombo()

        Using mgr As New FormatiProdottoDAO

            cmbLB.ValueMember = "IdFormatoProdotto"
            cmbLB.DisplayMember = "RiassuntoConLB"

            Dim l As List(Of FormatoProdotto) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdCatFormatoProdotto,Formato"},
                                           New LUNA.LunaSearchParameter(LFM.FormatoProdotto.IdCatFormatoProdotto, _IdCat, "<>"))

            l = l.FindAll(Function(x) x.ListiniBaseCheLoUsano.Count)

            cmbLB.DataSource = l

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

        If MessageBox.Show("Confermi la scelta del formato prodotto selezionato?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'qui controllo se c'e' gia e avviso 

            Dim GiaInCat As Boolean = True

            Dim fp As FormatoProdotto = DirectCast(cmbLB.SelectedItem, FormatoProdotto)

            If fp.IdCatFormatoProdotto Then
                If MessageBox.Show("Questo FormatoProdotto e' già inserito nella categoria '" & fp.CategoriaStr & "'. Confermi il salvataggio?", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    GiaInCat = False
                End If
            End If

            If GiaInCat Then

                fp.IdCatFormatoProdotto = _IdCat
                fp.Save()

                _Ris = fp.IdFormProd

                Close()
            End If

        End If

    End Sub

End Class