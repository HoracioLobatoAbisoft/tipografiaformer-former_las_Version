Imports FormerDALSql
Friend Class frmListinoResa
    'Inherits baseFormInternaFixed
    Private _Ris As Integer


    Private Sub CaricaCombo()

        Dim lFmX As List(Of Formato) = Nothing

        Using mgr As New FormatiDAO
            lFmX = mgr.GetAll(LFM.Formato.Formato)
        End Using

        cmbFormatoMacchina.DataSource = lFmX
        cmbFormatoMacchina.ValueMember = "IdFormato"
        cmbFormatoMacchina.DisplayMember = "Formato"

        Dim lFC As List(Of FormatoCarta) = Nothing

        Using mgr As New FormatiCartaDAO
            lFC = mgr.GetAll(LFM.FormatoCarta.FormatoCarta)
        End Using

        cmbFormatoCarta.DataSource = lFC
        cmbFormatoCarta.ValueMember = "IdFormCarta"
        cmbFormatoCarta.DisplayMember = "FormatoCarta"

    End Sub

    Private _IdResa As Integer = 0

    Friend Function Carica(Optional IdResa As Integer = 0) As Integer
        _IdResa = IdResa

        CaricaCombo()

        If _IdResa Then
            Using r As New Resa
                r.Read(_IdResa)

                txtResa.Text = r.Resa
                txtScarto.Text = r.PercScarto
                MgrControl.SelectIndexCombo(cmbFormatoCarta, r.IdFormCarta)
                MgrControl.SelectIndexCombo(cmbFormatoMacchina, r.IdFormato)

            End Using
        End If

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

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub txtCodice_TextChanged(sender As Object, e As EventArgs) Handles txtResa.TextChanged, txtScarto.KeyPress
        If sender.text.length = 0 Then
            sender.text = "0"
        End If

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio della combinazione di resa inserita?", "Resa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'qui devo controllare che non ci sia gia una coppia per quel formato carta e formato macchina 

            Dim Exist As Boolean = False

            Dim l As List(Of Resa) = Nothing
            Using mgr As New ResaDAO
                l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Resa.IdFormato, cmbFormatoMacchina.SelectedValue),
                                New LUNA.LunaSearchParameter(LFM.Resa.IdFormCarta, cmbFormatoCarta.SelectedValue),
                                New LUNA.LunaSearchParameter(LFM.Resa.IDFormatoResa, _IdResa, "<>"))

            End Using

            If l.Count Then Exist = True
            If Exist = False Then

                Dim R As New Resa

                If _IdResa Then
                    R.Read(_IdResa)
                End If

                R.IdFormato = cmbFormatoMacchina.SelectedValue
                R.IdFormCarta = cmbFormatoCarta.SelectedValue
                R.Resa = txtResa.Text
                R.PercScarto = txtScarto.Text
                If R.IsValid Then
                    R.Save()

                    _Ris = 1
                    Close()
                Else
                    MessageBox.Show("Inserire tutti i valori")
                End If

            Else
                MessageBox.Show("E' già presente una combinazione di resa per il formato carta e il formato macchina selezionati")
            End If


        End If


    End Sub
End Class