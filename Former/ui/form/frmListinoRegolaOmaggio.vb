Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmListinoRegolaOmaggio
    'Inherits baseFormInternaFixed

    Private _Ris As Integer = 0

    Private _IdRegolaOmaggio As Integer = 0

    Private Sub RiassuntoParziale()
        Try
            Using O As New Omaggio
                O.Tipologia = DirectCast(cmbTipologia.SelectedItem, cEnum).Id
                O.TipoCliente = DirectCast(cmbTipoCliente.SelectedItem, cEnum).Id
                O.QtaOmaggio = txtQta.Text
                O.ImportoMin = txtImportoMin.Text
                O.IdListinoOmaggio = cmbListiniOmaggio.SelectedValue
                O.IdPreventivazione = cmbPreventivazione.SelectedValue

                lblRiassunto.Text = O.CondizioneStr

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Friend Function Carica(Optional IdRegolaOmaggio As Integer = 0) As Integer

        _IdRegolaOmaggio = IdRegolaOmaggio

        CaricaCombo()

        If IdRegolaOmaggio Then
            Using r As New Omaggio
                r.Read(IdRegolaOmaggio)

                MgrControl.SelectIndexComboEnum(cmbTipologia, r.Tipologia)
                MgrControl.SelectIndexComboEnum(cmbTipoCliente, r.TipoCliente)
                MgrControl.SelectIndexCombo(cmbPreventivazione, r.IdPreventivazione)
                MgrControl.SelectIndexCombo(cmbListiniOmaggio, r.IdListinoOmaggio)

                txtQta.Text = r.QtaOmaggio
                txtImportoMin.Text = CInt(r.ImportoMin)

            End Using
        Else
            MgrControl.SelectIndexComboEnum(cmbTipologia, enTipologiaOmaggio.AlPrimoOrdine)
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Dim l As New List(Of cEnum)

        Dim p As New cEnum
        p.Id = enTipologiaOmaggio.AlPrimoOrdine
        p.Descrizione = "Al primo Ordine"
        l.Add(p)

        Dim p2 As New cEnum
        p2.Id = enTipologiaOmaggio.ConCriteri
        p2.Descrizione = "Con criteri"
        l.Add(p2)

        cmbTipologia.ValueMember = "Id"
        cmbTipologia.DisplayMember = "Descrizione"
        cmbTipologia.DataSource = l

        Using mgr As New ListinoBaseDAO
            Dim lLb As List(Of ListinoBase) = mgr.FindAll(LFM.ListinoBase.Nome,
                                                          New LUNA.LunaSearchParameter(LFM.ListinoBase.IdPrev, FormerConst.ProdottiParticolari.IdPreventivazioneOmaggi),
                                                          New LUNA.LunaSearchParameter(LFM.ListinoBase.Disattivo, enSiNo.No),
                                                          New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0, "<>"))
            cmbListiniOmaggio.DisplayMember = "Nome"
            cmbListiniOmaggio.ValueMember = "IdListinoBase"
            cmbListiniOmaggio.DataSource = lLb
        End Using

        Dim lTipo As New List(Of cEnum)
        Dim p3 As New cEnum
        p3.Id = enTipoRubrica.Tutto
        p3.Descrizione = "Tutti"

        lTipo.Add(p3)

        Dim p4 As New cEnum
        p4.Id = enTipoRubrica.Cliente
        p4.Descrizione = "Clienti"

        lTipo.Add(p4)

        Dim p5 As New cEnum
        p5.Id = enTipoRubrica.Rivenditore
        p5.Descrizione = "Rivenditori"

        lTipo.Add(p5)

        cmbTipoCliente.DisplayMember = "Descrizione"
        cmbTipoCliente.ValueMember = "Id"
        cmbTipoCliente.DataSource = lTipo

        Using mgr As New PreventivazioniDAO
            Dim lLb As List(Of Preventivazione) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Descrizione", .AddEmptyItem = True},
                                                              New LUNA.LunaSearchParameter(LFM.Preventivazione.IdPrev, FormerConst.ProdottiParticolari.IdPreventivazioneOmaggi, "<>"))
            cmbPreventivazione.DisplayMember = "Descrizione"
            cmbPreventivazione.ValueMember = "IdPrev"
            cmbPreventivazione.DataSource = lLb
        End Using

    End Sub

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio della regola omaggio?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Using O As New Omaggio
                If _IdRegolaOmaggio Then
                    O.Read(_IdRegolaOmaggio)
                End If

                O.Tipologia = DirectCast(cmbTipologia.SelectedItem, cEnum).Id
                O.TipoCliente = DirectCast(cmbTipoCliente.SelectedItem, cEnum).Id
                O.QtaOmaggio = txtQta.Text
                O.ImportoMin = txtImportoMin.Text
                O.IdListinoOmaggio = cmbListiniOmaggio.SelectedValue
                O.IdPreventivazione = cmbPreventivazione.SelectedValue

                O.Save()

            End Using

            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub cmbTipologia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipologia.SelectedIndexChanged
        RiassuntoParziale()
    End Sub

    Private Sub cmbPreventivazione_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPreventivazione.SelectedIndexChanged
        RiassuntoParziale()
    End Sub

    Private Sub txtImportoMin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImportoMin.KeyPress
        RiassuntoParziale()
    End Sub

End Class