Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmAccordoForn
    'Inherits baseFormInternaFixed

    Private _Ris As Integer = 0

    Private _Prezzo As Decimal

    Private _IdProd As Integer = 0
    Private _IdCli As Integer = 0
    Private _IdFornAcc As Integer = 0

    Private Sub CaricaCombo()

        CaricaCli()

    End Sub

    Friend Function Carica(Optional ByVal IdFornAcc As Integer = 0, Optional ByVal IdCli As Integer = 0) As Integer

        CaricaCombo()

        If IdCli Then
            MgrControl.SelectIndexCombo(cmbCliente, IdCli)
            cmbCliente.Enabled = False
        End If

        _IdFornAcc = IdFornAcc

        If IdFornAcc Then

            'ricarico le voci 
            Dim x As New ListinoFornitori

            x.Read(IdFornAcc)
            'MgrControl.SelectIndexCombo(cmbCliente, x.IdRub)
            'cmbCliente.Enabled = False
            txtCodiceForn.Text = x.Codice
            txtannotazioni.Text = x.Annotazioni
            lblDataAccordo.Text = x.DataAcc
            txtPrezzo.Text = x.Prezzo

            'txtPrezzo.Text = FormattaPrezzo(x.Prezzo)

            x = Nothing
        Else
            lblDataAccordo.Text = Now.Date
        End If

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

    Private Sub txtPrezzo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrezzo.KeyPress
        MgrControl.ControlloNumerico(sender, e)
    End Sub

    Private Sub txtPrezzo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrezzo.TextChanged
        If sender.text.length = 0 Then
            sender.text = "0"
        End If
    End Sub

    Private Sub txtQta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrezzo.KeyPress
        MgrControl.ControlloNumerico(sender, e)
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If cmbCliente.SelectedValue <> 0 And txtPrezzo.Text <> 0 Then

            If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Using X As New ListinoFornitori
                    X.IdListinoForn = _IdFornAcc
                    X.IdRub = cmbCliente.SelectedValue
                    X.Prezzo = txtPrezzo.Text
                    X.Codice = txtCodiceForn.Text
                    X.Annotazioni = txtannotazioni.Text
                    X.DataAcc = Now.Date

                    X.Save()
                End Using
                _Ris = 1
                Close()

            End If
        Else

            MessageBox.Show("Inserire tutti i dati!", "Listino Personale", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub btnDetCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetCli.Click

        If cmbCliente.SelectedIndex <> -1 Then
            ApriCli(cmbCliente.SelectedValue)
        End If
    End Sub

    Private Sub ApriCli(Optional ByVal IdRub As Integer = 0)

        Dim frmRif As New frmVoceRubrica
        Dim ObjRif As New VoceRubrica
        Dim Ris As Integer = 0
        ObjRif.Tipo = enTipoRubrica.Cliente

        If IdRub Then
            ObjRif.Read(IdRub)
        End If

        Sottofondo()
        Ris = frmRif.Carica(ObjRif)
        Sottofondo()
        If Ris Then CaricaCli()
        frmRif.Dispose()
        ObjRif = Nothing

    End Sub

    Private Sub CaricaCli()

        Using cli As New VociRubricaDAO
            cmbCliente.ValueMember = "IdRub"
            cmbCliente.DisplayMember = "Nominativo"

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, False,,,,,, True)
        End Using
    End Sub

End Class