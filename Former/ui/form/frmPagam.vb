Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmPagam

    Public formSopra As cFormSopra
    Private _Ris As Integer
    Private _IdRub As Integer
    Private _Pagam As New Pagamento
    Private _IdTipoDoc As Integer
    Private _Differenza As Single

    Private Sub CaricaCombo()

        Using cli As New VociRubricaDAO
            cmbCliente.ValueMember = "IdRub"
            cmbCliente.DisplayMember = "Nominativo"

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, False)
        End Using
    End Sub

    Private Sub CaricaDocumenti()

        If _IdTipoDoc = enTipoVoceContab.enTipoVoceAcquisto Then
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

    Friend Function Carica(Optional ByVal IdPagam As Integer = 0, _
                           Optional ByVal IdRub As Integer = 0, _
                           Optional ByVal IdDoc As Integer = 0, _
                           Optional ByVal IdTipoDoc As Integer = 0, _
                           Optional ByVal PagamentoAnticipato As Boolean = False) As Integer

        CaricaCombo()
        _IdRub = IdRub

        If _IdRub Then
            cmbCliente.Enabled = False
            SelectIndexCombo(cmbCliente, _IdRub)
        End If

        Dim Voce

        Dim GiaPagato As Boolean = False

        If IdPagam Then
            _Pagam.Read(IdPagam)
            _IdTipoDoc = _Pagam.Tipo
            dtPagam.Value = _Pagam.DataPag
            SelectIndexCombo(cmbCliente, _Pagam.IdRub)
            If _Pagam.IdFat Then SelectIndexCombo(cmbFat, _Pagam.IdFat)
            txtDescr.Text = _Pagam.Descrizione
            txtImporto.Text = _Pagam.Importo
            txtNote.Text = _Pagam.NotePag

        ElseIf IdDoc Then

            If IdTipoDoc = enTipoVoceContab.enTipoVoceAcquisto Then
                Using Costo As New cContabCosti
                    Costo.Read(IdDoc)
                    Voce = Costo
                End Using
            Else
                Using Ricavo As New cContabRicavi
                    Ricavo.Read(IdDoc)
                    Voce = Ricavo
                End Using
            End If
            _IdTipoDoc = IdTipoDoc

            _Differenza = 0
            Dim TotGiaPagato As Single = 0
            Using mgr As New PagamentiDAO
                Dim lP As List(Of Pagamento) = mgr.FindAll(New LUNA.LunaSearchParameter("IdFat", IdDoc), _
                                                           New LUNA.LunaSearchParameter("Tipo", IdTipoDoc))

                For Each singP As Pagamento In lP
                    TotGiaPagato += singP.Importo
                Next

            End Using

            _Differenza = Math.Round(Voce.totale - TotGiaPagato, 2)

            If _Differenza <> 0 Then
                txtImporto.Text = _Differenza
            ElseIf TotGiaPagato <> 0 Then
                txtImporto.Text = 0
                GiaPagato = True
                MessageBox.Show("Il documento risulta già interamente pagato!")
            Else
                txtImporto.Text = Voce.totale
            End If
            Try
                SelectIndexCombo(cmbCliente, Voce.idrub)
                SelectIndexCombo(cmbFat, IdDoc)
            Catch ex As Exception

            End Try


            txtDescr.Focus()

        End If

        cmbCliente.Enabled = False
        cmbFat.Enabled = False

        If PagamentoAnticipato Then

            dtPagam.Enabled = False
            cmbCliente.Enabled = False
            cmbFat.Enabled = False
            btnDettFatt.Enabled = False
            txtDescr.ReadOnly = True
            txtImporto.ReadOnly = True
            txtNote.ReadOnly = True
            btnOk.Visible = False
        End If

        If GiaPagato = False Then
            ShowDialog()
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
        _IdRub = cmbCliente.SelectedValue
        CaricaDocumenti()
    End Sub

    Private Sub txtImporto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImporto.KeyPress
        ControlloNumerico(sender, e, False)
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim Imp As Single = 0
        Try
            Imp = txtImporto.Text
        Catch ex As Exception

        End Try

        If Math.Round(Imp, 2) > Math.Round(_Differenza, 2) And _Differenza <> 0 Then
            MessageBox.Show("L'importo residuo massimo registrabile per questo documento è di " & _Differenza & " euro!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtImporto.Text = _Differenza
        Else
            If MessageBox.Show("Confermi il salvataggio del pagamento?", "Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtDescr.Text.Length <> 0 And txtImporto.Text.Length <> 0 And cmbCliente.SelectedValue <> 0 And cmbFat.SelectedValue <> 0 Then
                    _Pagam.DataPag = dtPagam.Value
                    _Pagam.Descrizione = txtDescr.Text
                    _Pagam.Importo = txtImporto.Text
                    _Pagam.IdRub = cmbCliente.SelectedValue
                    _Pagam.IdFat = cmbFat.SelectedValue
                    _Pagam.NotePag = txtNote.Text
                    _Pagam.Tipo = _IdTipoDoc
                    _Pagam.Save()
                    _Ris = 1

                    If _IdTipoDoc = enTipoVoceContab.enTipoVoceVendita Then
                        If Math.Round(Imp, 2) = Math.Round(_Differenza, 2) Then

                            'If MessageBox.Show("L'importo totale del documento risulta incassato, passare tutti gli ordini relativi allo stato di Pagato?", "Pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Using doc As New cContabRicaviColl
                                doc.PassaA(cmbFat.SelectedValue, enStatoOrdine.PagatoInteramente)
                            End Using
                            MessageBox.Show("Gli ordini sono passati allo stato di Pagato!", "Consegna ordini", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Dim D As New Ricavo
                            D.Read(cmbFat.SelectedValue)
                            D.idstato = enStatoDocumentoFiscale.PagatoInteramente
                            D.Save()

                            'End If
                        Else
                            Dim D As New Ricavo
                            D.Read(cmbFat.SelectedValue)
                            D.idstato = enStatoDocumentoFiscale.PagatoAcconto
                            D.Save()
                        End If
                    End If


                    Close()
                Else
                    MessageBox.Show("I campi descrizione, importo, cliente e fattura sono obbligatori!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
        End If
        End If


    End Sub

    Private Sub btnDettFatt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDettFatt.Click

        Dim IdFat As Integer = 0

        If cmbFat.SelectedValue Then
            IdFat = cmbFat.SelectedValue

            Sottofondo(Me)

            Dim x As New frmDocumentoContabile
            x.Carica(IdFat, _IdTipoDoc)
            x = Nothing
            Sottofondo(Me)

        End If

    End Sub
End Class