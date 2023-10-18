Imports FormerDALSql
Imports FormerLib.FormerEnum
Friend Class frmListinoComposizioneCarta
    'Inherits baseFormInternaFixed
    Private _Ris As ComposizioneCarta = Nothing

    Private Sub CaricaCombo()

        Dim lFm2 As List(Of TipoCarta) = Nothing
        Using mgr As New TipiCartaDAO
            lFm2 = mgr.FindAll(LFM.TipoCarta.Tipologia,
                              New LUNA.LunaSearchParameter(LFM.TipoCarta.TipoCarta, CInt(enTipoCarta.Semplice)))
        End Using

        cmbTipoCarta.DataSource = lFm2
        cmbTipoCarta.ValueMember = "IdTipoCarta"
        cmbTipoCarta.DisplayMember = "Riassunto"

    End Sub

    Private _t As TipoCarta

    Friend Function Carica(T As TipoCarta) As ComposizioneCarta

        _t = T

        CaricaCombo()

        ShowDialog()

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

        If MessageBox.Show("Confermi la combinazione inserita?", "Composizione Carta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'qui devo controllare che non ci sia gia una coppia per quel formato carta e formato macchina 

            Dim Exist As Boolean = False

            If _t.ComposizioniCarta.FindAll(Function(x) x.IdCartaSingola = cmbTipoCarta.SelectedValue).Count = 0 Then
                'qui ci sono gia combinazioni per questo formato 
                _Ris = New ComposizioneCarta
                _Ris.IdCartaSingola = cmbTipoCarta.SelectedValue
                _Ris.NumFogli = txtNumFogli.Text
                _Ris.IdCartaPadre = _t.IdTipoCarta

                If _Ris.IsValid Then
                    Close()
                Else
                    MessageBox.Show("Inserire un valore valido per i campi obbligatori!")
                End If
                Close()

            Else
                MessageBox.Show("E' già presente una combinazione di carta per la carta selezionata!")
            End If

        End If

    End Sub

End Class