Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib

Public Class ucAmministrazioneEmailAvviso
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If LUNA.LunaContext.TotConnAttive Then
            Dim L As New List(Of cEnum)
            Dim C1 As New cEnum
            C1.Id = -1
            C1.Descrizione = "Tutti"
            L.Add(C1)

            Dim C2 As New cEnum
            C2.Id = enEmailStato.InCoda
            C2.Descrizione = "In coda"
            L.Add(C2)

            Dim C3 As New cEnum
            C3.Id = enEmailStato.DaInviare
            C3.Descrizione = "Da inviare"
            L.Add(C3)

            Dim C4 As New cEnum
            C4.Id = enEmailStato.DaNonInviare
            C4.Descrizione = "Da non inviare"
            L.Add(C4)

            Dim C5 As New cEnum
            C5.Id = enEmailStato.Inviata
            C5.Descrizione = "Inviata"
            L.Add(C5)

            cmbStato.DataSource = L


            CaricaCli()

            MgrControl.SelectIndexCombo(cmbStato, enEmailStato.DaInviare)
        End If

    End Sub

    Private Sub CaricaCli()

        'carico la combo dei clienti
        Using cli As New VociRubricaDAO
            cmbCliente.ValueMember = "IdRub"
            cmbCliente.DisplayMember = "Nominativo"

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, True)
        End Using
    End Sub

    Private Sub Mostradati()
        Cursor.Current = Cursors.WaitCursor
        Using Emgr As New EmailDAO
            Dim l As List(Of EmailRis)

            Dim P2 As Integer = 0

            If rdoLiv1.Checked Then
                P2 = 1
            ElseIf rdoLiv2.Checked Then
                P2 = 2
            ElseIf rdoLiv3.Checked Then
                P2 = 3
            ElseIf rdoLiv4.Checked Then
                P2 = 4
            End If

            Dim P3 As Integer = -1

            If Not cmbStato.SelectedItem Is Nothing Then
                Dim c As cEnum = cmbStato.SelectedItem
                If c.Id <> -1 Then
                    P3 = c.Id
                End If
            End If

            Dim P4 As Integer = 0

            If Not cmbCliente.SelectedItem Is Nothing Then
                If cmbCliente.SelectedValue <> 0 Then
                    P4 = cmbCliente.SelectedValue
                End If

            End If

            l = Emgr.ListaEmail(P2, P3, P4)

            DgEmail.AutoGenerateColumns = False
            DgEmail.DataSource = l
        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub Carica()
        Mostradati()
    End Sub

    Private Sub rdoLivTutti_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLivTutti.CheckedChanged,
        rdoLiv1.CheckedChanged,
        rdoLiv2.CheckedChanged,
        rdoLiv3.CheckedChanged,
        rdoLiv4.CheckedChanged
        If sender.focused Then
            If LUNA.LunaContext.TotConnAttive Then

                Mostradati()

            End If
        End If

    End Sub

    Private Sub DgEmail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgEmail.CellContentClick

    End Sub

    Private Sub DgEmail_CellDoubleClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles DgEmail.CellDoubleClick

        If DgEmail.SelectedRows.Count Then

            Dim em As Email = DgEmail.Rows(e.RowIndex).DataBoundItem
            Dim fr As New frmMarketingEmail
            ParentFormEx.Sottofondo()

            fr.Riapri(em)

            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub lnkCoda_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCoda.LinkClicked

        If DgEmail.SelectedRows.Count Then

            Dim R As DataGridViewRow = DgEmail.SelectedRows(0)

            Dim em As Email = R.DataBoundItem
            em.DaInviare = enEmailStato.InCoda
            em.Save()
            DgEmail.Refresh()
        End If

    End Sub

    Private Sub lnkNoInvio_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNoInvio.LinkClicked
        If DgEmail.SelectedRows.Count Then

            Dim R As DataGridViewRow = DgEmail.SelectedRows(0)

            Dim em As Email = R.DataBoundItem
            em.DaInviare = enEmailStato.DaNonInviare
            em.Save()
            DgEmail.Refresh()
        End If
    End Sub

    Private Sub cmbStato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStato.SelectedIndexChanged
        If sender.focused Then
            Mostradati()
        End If

    End Sub

    Private Sub cmbCliente_MouseClick(sender As Object, e As MouseEventArgs) Handles cmbCliente.MouseClick

    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged
        If sender.focused Then
            Mostradati()
        End If

    End Sub

    Private Sub lnkCli_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCli.LinkClicked
        If DgEmail.SelectedRows.Count Then

            Dim R As DataGridViewRow = DgEmail.SelectedRows(0)

            Dim em As Email = R.DataBoundItem
            ParentFormEx.Sottofondo()
            Dim f As New frmVoceRubrica
            f.Carica(em.IdRubDest)
            f = Nothing
            ParentFormEx.Sottofondo()
        End If
    End Sub
End Class
