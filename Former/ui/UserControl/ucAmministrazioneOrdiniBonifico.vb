Imports fw = FormerDALWeb
Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucAmministrazioneOrdiniBonifico
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        tbBonifici.TabPages.Remove(tpStorico)

    End Sub

    Public Sub CaricaDati()

        'carico da online gli ordini in attesa di pagamento
        Using mgr As New fw.ConsegneDAO
            Dim l As List(Of fw.Consegna) = mgr.FindAll(New fw.LUNA.LunaSearchOption With {.OrderBy = "DataInserimento"},
                                                        New fw.LUNA.LunaSearchParameter(fw.LFM.Consegna.IdStatoConsegna, CInt(enStatoConsegna.InAttesaDiPagamento)),
                                                        New fw.LUNA.LunaSearchParameter(fw.LFM.Consegna.IdPagam, enMetodoPagamento.BonificoBancarioAnticipato))

            DgOrdini.DataSource = Nothing
            DgOrdini.AutoGenerateColumns = False
            DgOrdini.DataSource = l

        End Using

    End Sub

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        If MessageBox.Show("Confermi il caricamento degli ordini in attesa di pagamento con bonifico bancario anticipato dal sito?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CaricaDati()
        End If

    End Sub

    Private Sub lnkRegistraPagam_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRegistraPagam.LinkClicked

        If DgOrdini.SelectedRows.Count Then

            ParentFormEx.Sottofondo()
            Dim Ris As Integer = 0
            Dim C As fw.Consegna = DgOrdini.SelectedRows(0).DataBoundItem
            Dim f As New frmContabilitaPagamentoOnlineBonifico

            Ris = f.Carica(C)

            If Ris Then CaricaDati()
            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub lnkSitoBanca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSitoBanca.LinkClicked

        FormerLib.FormerHelper.File.ShellExtended("https://www.relaxbanking.it")

    End Sub

    Private Sub CaricaStorico()

        Using mgr As New ConsegneProgrammateDAO

            Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Giorno Desc"},
                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdPagam, enMetodoPagamento.BonificoBancarioAnticipato))

            DGOrdiniStorico.AutoGenerateColumns = False
            DGOrdiniStorico.DataSource = l

        End Using

    End Sub

    Private Sub lnkCercaStorico_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCercaStorico.LinkClicked
        If MessageBox.Show("Confermi il caricamento dello storico degli ordini pagati con bonifico bancario anticipato?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CaricaStorico
        End If
    End Sub

    Private Sub DGOrdiniStorico_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGOrdiniStorico.CellContentClick

    End Sub

    Private Sub DGOrdiniStorico_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGOrdiniStorico.CellContentDoubleClick



    End Sub
End Class
