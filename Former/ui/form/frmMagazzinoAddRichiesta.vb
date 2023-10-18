Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmMagazzinoAddRichiesta
    'Inherits baseFormInternaFixed

    Private _Ris As Integer
    Private _O As OrdineAcquisto = Nothing
    Private _IdMovimentoMagazzino As Integer = 0
    Private _IdOrdineAcquisto As Integer = 0
    Private _ListaIdMovimentiGiaInLista As String = String.Empty

    Friend Function Carica(IdOrdineAcquisto As Integer,
                           Optional IdMovimentoMagazzino As Integer = 0,
                           Optional ListaIdMovimentiGiaInLista As String = "") As Integer

        _IdOrdineAcquisto = IdOrdineAcquisto
        _IdMovimentoMagazzino = IdMovimentoMagazzino
        _ListaIdMovimentiGiaInLista = ListaIdMovimentiGiaInLista

        CaricaCombo()

        cmbRichieste.ValueMember = LFM.MovimentoMagazzino.IdCarMag.Name
        cmbRichieste.DisplayMember = "Riassunto"

        If _IdMovimentoMagazzino Then
            Dim l As New List(Of MovimentoMagazzino)
            Using m As New MovimentoMagazzino
                m.Read(_IdMovimentoMagazzino)
                l.Add(m)
            End Using
            cmbRichieste.DataSource = l
            MgrControl.SelectIndexCombo(cmbRichieste, _IdMovimentoMagazzino)
            cmbRichieste.Enabled = False
        Else
            Using mgr As New MagazzinoDAO

                Dim PTipo As LUNA.LunaSearchParameter = Nothing
                Dim POrdAcq As LUNA.LunaSearchParameter = Nothing

                PTipo = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.RichiestaAcquisto)
                POrdAcq = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdOrdineAcquisto, 0)

                Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = LFM.MovimentoMagazzino.DataMov.Name & " DESC", .AddEmptyItem = True},
                                                                PTipo,
                                                                POrdAcq)

                l = l.FindAll(Function(x) _ListaIdMovimentiGiaInLista.IndexOf(x.IdCarMag & ",") = -1)
                cmbRichieste.DataSource = l
            End Using

        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        'carico la combo dei fornitori
        Using cli As New VociRubricaDAO
            cmbFornitore.ValueMember = "IdRub"
            cmbFornitore.DisplayMember = "RagSocNome"

            cmbFornitore.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, True,,,,,, True)

            ''carico la combo dei clienti
            'cmbAgente.ValueMember = "IdRub"
            'cmbAgente.DisplayMember = "Nominativo"

            'cmbAgente.DataSource = cli.ListaCombo(enTipoRubrica.Agente, True)
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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If cmbRichieste.SelectedValue Then
                If cmbFornitore.SelectedValue Then
                    Using M As New MovimentoMagazzino
                        M.Read(cmbRichieste.SelectedValue)
                        M.IdOrdineAcquisto = _IdOrdineAcquisto
                        M.IdForn = cmbFornitore.SelectedValue
                        M.Qta = txtQta.Text
                        M.Save()
                        _Ris = M.IdCarMag
                    End Using

                    Close()
                Else
                    MessageBox.Show("Selezionare un fornitore")
                End If
            Else
                MessageBox.Show("Selezionare una richiesta")
            End If

        End If

    End Sub

    Private Sub cmbRichieste_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRichieste.SelectedIndexChanged

        Try
            If cmbRichieste.SelectedValue Then
                Using O As MovimentoMagazzino = cmbRichieste.SelectedItem
                    If O.IdForn Then MgrControl.SelectIndexCombo(cmbFornitore, O.IdForn)
                    txtQta.Text = O.Qta
                End Using
            End If
        Catch ex As Exception

        End Try

    End Sub

End Class