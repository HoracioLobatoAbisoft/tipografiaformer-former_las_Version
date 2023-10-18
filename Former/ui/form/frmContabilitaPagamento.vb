Imports FormerBusinessLogic
Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmContabilitaPagamento
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _IdRub As Integer
    Private _Pagam As New Pagamento
    Private _IdTipoDoc As Integer
    Private _Differenza As Decimal

    Private Sub CaricaCombo()

        Using cli As New VociRubricaDAO
            cmbCliente.ValueMember = "IdRub"
            cmbCliente.DisplayMember = "Nominativo"

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, False)
        End Using

        Using mgr As New TipoPagamentiDAO
            cmbTipoPagamento.ValueMember = "IdTipoPagam"
            cmbTipoPagamento.DisplayMember = "TipoPagam"
            cmbTipoPagamento.DataSource = mgr.GetAll(LFM.TipoPagamento.TipoPagam)
        End Using

    End Sub

    Private Sub CaricaDocumenti()

        If _IdTipoDoc = enTipoVoceContab.VoceAcquisto Then
            Using cli As New cContabCostiColl
                cmbFat.ValueMember = "IdFat"
                cmbFat.DisplayMember = "Descr"

                cmbFat.DataSource = cli.ListaComboSpese(_IdRub)
            End Using
        Else
            Using cli As New cContabRicaviColl
                cmbFat.ValueMember = "IdFat"
                cmbFat.DisplayMember = "Descr"

                cmbFat.DataSource = cli.ListaCombo(_IdRub)
            End Using
        End If

    End Sub

    Friend Function Carica(Optional ByVal IdPagamento As Integer = 0,
                           Optional ByVal IdRub As Integer = 0,
                           Optional ByVal IdDoc As Integer = 0,
                           Optional ByVal IdTipoDoc As enTipoVoceContab = 0) As Integer

        CaricaCombo()
        _IdRub = IdRub
        _IdTipoDoc = IdTipoDoc

        If _IdRub Then
            cmbCliente.Enabled = False
            MgrControl.SelectIndexCombo(cmbCliente, _IdRub)
        End If

        Dim Voce

        Dim GiaPagato As Boolean = False

        If IdPagamento Then
            _Pagam.Read(IdPagamento)
            _IdTipoDoc = _Pagam.Tipo
            dtPagam.Value = _Pagam.DataPag
            MgrControl.SelectIndexCombo(cmbCliente, _Pagam.IdRub)
            If _Pagam.IdFat Then MgrControl.SelectIndexCombo(cmbFat, _Pagam.IdFat)
            txtDescr.Text = _Pagam.Descrizione
            txtImporto.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Pagam.Importo, 2)
            txtNote.Text = _Pagam.NotePag
            If _Pagam.IdTipoPagamento Then MgrControl.SelectIndexCombo(cmbTipoPagamento, _Pagam.IdTipoPagamento)

            If _Pagam.IdConsegna OrElse _Pagam.IdTipoPagamento = enMetodoPagamento.StornoDaNotaDiCredito Then
                dtPagam.Enabled = False
                cmbCliente.Enabled = False
                cmbFat.Enabled = False
                cmbTipoPagamento.Enabled = False
                btnDettFatt.Enabled = False
                txtDescr.ReadOnly = True
                txtImporto.ReadOnly = True
                txtNote.ReadOnly = True
                SalvaToolStripMenuItem.Visible = False

                If _Pagam.IdTipoPagamento <> enMetodoPagamento.StornoDaNotaDiCredito Then lblPagamDaInternet.Visible = True
            End If
            Me.Text &= " - " & IdPagamento
        ElseIf IdDoc Then
            Dim IdTipoPagam As Integer = 0

            If IdTipoDoc = enTipoVoceContab.VoceAcquisto Then
                Using Costo As New Costo
                    Dim DataPrevistoPagamento As Date = Date.Now
                    Costo.Read(IdDoc)

                    If Costo.DocXML.Length Then
                        Dim f As FatturaElettronica = MgrFattureFE.GetFatturaFromXMLBuffer(Costo.DocXML)
                        If Not f.FatturaElettronicaBody.DatiPagamento Is Nothing AndAlso
                           Not f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento Is Nothing AndAlso
                           Not f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento Is Nothing Then
                            IdTipoPagam = MgrFattureFE.GetIdTipoPagamento(f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento)

                        End If


                    End If
                    If IdTipoPagam = 0 Then IdTipoPagam = Costo.Fornitore.IdPagamento ' enMetodoPagamento.BonificoBancario

                    If IdTipoPagam = enMetodoPagamento.Contanti OrElse
                           IdTipoPagam = enMetodoPagamento.CartaDiCredito OrElse
                           IdTipoPagam = enMetodoPagamento.PayPal Then
                        DataPrevistoPagamento = Costo.DataCosto
                    Else
                        DataPrevistoPagamento = Costo.DataPrevPagam
                    End If

                    dtPagam.Value = DataPrevistoPagamento

                    Voce = Costo
                End Using
            Else
                Using Ricavo As New Ricavo
                    Ricavo.Read(IdDoc)
                    IdTipoPagam = Ricavo.Idpagamento
                    Voce = Ricavo
                End Using
            End If
            _IdTipoDoc = IdTipoDoc

            Using mgr As New PagamentiDAO
                _Differenza = mgr.ImportoAncoraDaPagareDocumento(IdDoc, IdTipoDoc)
            End Using
            '_Differenza = 0
            'Dim TotGiaPagato As Single = 0
            'Using mgr As New PagamentiDAO
            '    Dim lP As List(Of Pagamento) = mgr.FindAll(New LUNA.LunaSearchParameter("IdFat", IdDoc), _
            '                                               New LUNA.LunaSearchParameter("Tipo", IdTipoDoc))

            '    For Each singP As Pagamento In lP
            '        TotGiaPagato += singP.Importo
            '    Next

            'End Using

            '_Differenza = Math.Round(Voce.totale - TotGiaPagato, 2)

            If Voce.Tipo = enTipoDocumento.Preventivo Then
                txtDescr.Text = "NA"
            End If

            If _Differenza <> 0 Then
                txtImporto.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Differenza, 2)
            Else
                GiaPagato = True
            End If

            Try
                MgrControl.SelectIndexCombo(cmbCliente, Voce.idrub)
                MgrControl.SelectIndexCombo(cmbFat, IdDoc)
            Catch ex As Exception

            End Try

            If IdDoc Then

            End If

            MgrControl.SelectIndexCombo(cmbTipoPagamento, IdTipoPagam)

            txtDescr.Focus()

        End If

        cmbCliente.Enabled = False
        cmbFat.Enabled = False

        If GiaPagato = False Then
            ShowDialog()
        Else
            Beep()
            Beep()
            'Else
            '    MessageBox.Show("Il documento risulta già interamente pagato!", "Già Pagato", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged

        Dim VoceRub As VoceRubrica = Nothing

        If _IdRub = 0 Then
            _IdRub = cmbCliente.SelectedValue
            VoceRub = cmbCliente.SelectedItem
        Else
            VoceRub = New VoceRubrica
            VoceRub.Read(_IdRub)
        End If

        MgrControl.SelectIndexCombo(cmbTipoPagamento, VoceRub.IdPagamento)

        CaricaDocumenti()
    End Sub

    Private Sub txtImporto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImporto.KeyPress
        MgrControl.ControlloNumerico(sender, e, False)
    End Sub

    Private Sub SalvaPagamento()

        Dim Imp As Decimal = 0
        Try
            Imp = txtImporto.Text
        Catch ex As Exception

        End Try

        If FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Imp, 2) > FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Differenza, 2) And _Differenza <> 0 Then
            MessageBox.Show("L'importo residuo massimo registrabile per questo documento è di " & _Differenza & " euro!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtImporto.Text = _Differenza
        Else
            If MessageBox.Show("Confermi il salvataggio del pagamento?", "Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtImporto.Text.Length <> 0 And cmbCliente.SelectedValue <> 0 And cmbFat.SelectedValue <> 0 Then
                    _Pagam.DataPag = dtPagam.Value
                    _Pagam.Descrizione = txtDescr.Text
                    _Pagam.Importo = CDec(txtImporto.Text)
                    _Pagam.IdRub = cmbCliente.SelectedValue
                    _Pagam.IdFat = cmbFat.SelectedValue
                    _Pagam.NotePag = txtNote.Text
                    _Pagam.Tipo = _IdTipoDoc
                    _Pagam.IdTipoPagamento = cmbTipoPagamento.SelectedValue
                    _Pagam.Save()
                    _Ris = 1

                    If _IdTipoDoc = enTipoVoceContab.VoceVendita Then
                        MgrDocumentiFiscali.AggiornaStatoRicavoDopoPagamento(_Pagam.IdFat)
                    ElseIf _IdTipoDoc = enTipoVoceContab.VoceAcquisto Then
                        MgrDocumentiFiscali.AggiornaStatoCostoDopoPagamento(_Pagam.IdFat)
                    End If

                    Close()
                Else
                    MessageBox.Show("I campi importo, cliente e fattura sono obbligatori!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SalvaPagamento()

    End Sub

    Private Sub btnDettFatt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDettFatt.Click

        Dim IdFat As Integer = 0

        If cmbFat.SelectedValue Then
            IdFat = cmbFat.SelectedValue

            Sottofondo()

            Dim x As New frmContabilitaRicavo
            x.Carica(IdFat, _IdTipoDoc)
            x = Nothing
            Sottofondo()

        End If

    End Sub

    Private Sub cmbFat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFat.SelectedIndexChanged

    End Sub

    Private Sub SalvaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvaToolStripMenuItem.Click
        SalvaPagamento()
    End Sub

    Private Sub ChiudiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChiudiToolStripMenuItem.Click
        Close()

    End Sub
End Class