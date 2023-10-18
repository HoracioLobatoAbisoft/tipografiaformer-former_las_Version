Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Friend Class frmListPers
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _Prezzo As Decimal

    Private _IdProd As Integer
    Private _IdCli As Integer
    Private _IdListPers As Integer

    Private Sub CaricaCombo()

        CaricaCli()

        CaricaTipoProd()

    End Sub

    Friend Function Carica(Optional ByVal IdListPers As Integer = 0, Optional ByVal IdCli As Integer = 0) As Integer

        CaricaCombo()

        If IdCli Then MgrControl.SelectIndexCombo(cmbCliente, IdCli)

        _IdListPers = IdListPers

        If _IdListPers Then

            'ricarico le voci 
            Dim x As New ListinoClienti, p As New Prodotto

            x.Read(_IdListPers)
            p.Read(x.IdProd)

            MgrControl.SelectIndexCombo(cmbTipoProd, p.TipoProd)
            MgrControl.SelectIndexCombo(cmbProdotto, x.IdProd)
            txtPrezzo.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(x.PrezzoRis)
            p = Nothing
            x = Nothing

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
        If cmbProdotto.SelectedValue <> 0 And cmbCliente.SelectedValue <> 0 And txtPrezzo.Text <> 0 Then

            If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim X As New ListinoClienti
                X.IdList = _IdListPers
                X.IdProd = cmbProdotto.SelectedValue
                X.IdRub = cmbCliente.SelectedValue
                X.PrezzoRis = txtPrezzo.Text

                X.Save()

                _Ris = 1
                Close()

            End If
        Else

            MessageBox.Show("Inserire tutti i dati!", "Listino Personale", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub btnDetProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetProd.Click

        If cmbProdotto.SelectedIndex <> -1 Then
            ApriProd(cmbProdotto.SelectedValue)
        End If
    End Sub

    Private Sub ApriProd(Optional ByVal IdProd As Integer = 0)

        Dim frmRif As New frmListinoProdotto
        Dim ObjRif As New Prodotto
        Dim Ris As Integer = 0

        Sottofondo()

        If IdProd Then ObjRif.Read(IdProd)

        Ris = frmRif.Carica(ObjRif)
        Sottofondo()

        If Ris Then
            'aggiorno la combo
            CaricaProd()
        End If

        frmRif.Dispose()
        ObjRif = Nothing

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

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, False)
        End Using
    End Sub

    Private Sub CaricaProd()

        If cmbTipoProd.SelectedIndex <> -1 Then

            Dim voce As cEnum = cmbTipoProd.SelectedItem
            Dim TipoProd As Integer = voce.Id

            Using x As New cProdottiColl
                cmbProdotto.ValueMember = "IdProd"
                cmbProdotto.DisplayMember = "Descr"

                cmbProdotto.DataSource = x.ListaPerCombo(TipoProd)
            End Using
        End If

    End Sub

    Private Sub CaricaTipoProd()

        Dim TipoProd As New cTipoProdCom(False)
        cmbTipoProd.DataSource = TipoProd
        cmbTipoProd.ValueMember = "Id"
        cmbTipoProd.DisplayMember = "Descrizione"

    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoProd.SelectedIndexChanged
        CaricaProd()
    End Sub
End Class