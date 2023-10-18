Imports FormerDALSql

Friend Class frmFormatoProdsuModCom
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0
    Private _ModComFormProd As ModComFormProd = Nothing
    Private _IdModCom As Integer = 0
    Private _lst As List(Of ModComFormProd)

    Private Sub CaricaCombo()

        Dim lFm2 As List(Of FormatoProdotto) = Nothing

        Using mgr As New FormatiProdottoDAO
            lFm2 = mgr.GetAll(LFM.FormatoProdotto.Formato)
        End Using

        cmbFormatoProdotto.DataSource = lFm2
        cmbFormatoProdotto.ValueMember = "IdFormProd"
        cmbFormatoProdotto.DisplayMember = "Formato"

    End Sub

    Friend Function Carica(IdModCom As Integer,
                           lst As List(Of ModComFormProd),
                           ByRef ModComFormProd As ModComFormProd) As Integer

        CaricaCombo()
        _IdModCom = IdModCom
        _ModComFormProd = ModComFormProd
        _lst = lst

        If Not _ModComFormProd Is Nothing Then

            'qui ricarico
            MgrControl.SelectIndexCombo(cmbFormatoProdotto, _ModComFormProd.IdFormProd)
            txtNumSpazi.Text = _ModComFormProd.Spazi
            txtRangeMin.Text = _ModComFormProd.RangeMin
            txtRangeMax.Text = _ModComFormProd.RangeMax

            cmbOrientamento.SelectedIndex = _ModComFormProd.Orientamento

        Else
            cmbOrientamento.SelectedIndex = 0
        End If

        ShowDialog()
        ModComFormProd = _ModComFormProd
        Return _Ris

    End Function

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        Dim Err As Boolean = False
        If _ModComFormProd Is Nothing Then
            For Each m As ModComFormProd In _lst
                If m.IdFormProd = cmbFormatoProdotto.SelectedValue Then
                    Err = True
                End If
            Next
        End If

        If Err Then
            MessageBox.Show("Il formato prodotto selezionato è già presente nel modello commessa selezionato!")
        Else
            If MessageBox.Show("Confermi il salvataggio?", "Formato Prodotto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _ModComFormProd Is Nothing Then
                    _ModComFormProd = New ModComFormProd
                End If
                _ModComFormProd.IdFormProd = cmbFormatoProdotto.SelectedValue
                _ModComFormProd.IdModCom = _IdModCom
                _ModComFormProd.Spazi = txtNumSpazi.Text
                _ModComFormProd.RangeMin = txtRangeMin.Text
                _ModComFormProd.RangeMax = txtRangeMax.Text
                _ModComFormProd.Orientamento = cmbOrientamento.SelectedIndex
                If _ModComFormProd.IsValid Then
                    _Ris = 1
                    Close()
                Else
                    MessageBox.Show("Inserire tutti i valori! Gli spazi non possono essere 0 e il campo posizioni Max deve essere maggiore o uguale del campo posizioni Min!")
                End If

            End If
        End If

    End Sub
End Class