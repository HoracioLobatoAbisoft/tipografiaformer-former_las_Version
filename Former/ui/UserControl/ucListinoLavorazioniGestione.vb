Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib

Public Class ucListinoLavorazioniGestione
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        CaricaCombo()

    End Sub

    Private Sub CaricaCat()

        Using C As New CatLavDAO

            tvwCat.Nodes.Clear()


            Dim Node As TreeNode = tvwCat.Nodes.Add("R" & enRepartoWeb.Tutto, "TUTTO")
            Node.BackColor = Color.White
            Node.ForeColor = Color.Black

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.StampaOffset, "OFFSET")
            Node.BackColor = FormerColori.ColoreRepartoOffset
            Node.ForeColor = Color.White

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.StampaDigitale, "DIGITALE")
            Node.BackColor = FormerColori.ColoreRepartoDigitale
            Node.ForeColor = Color.White

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.Packaging, "PACKAGING")
            Node.BackColor = FormerColori.ColoreRepartoPackaging
            Node.ForeColor = Color.White

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.Ricamo, "RICAMO")
            Node.BackColor = FormerColori.ColoreRepartoRicamo
            Node.ForeColor = Color.White

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.Etichette, "ETICHETTE")
            Node.BackColor = FormerColori.ColoreRepartoEtichette
            Node.ForeColor = Color.White

            tvwCat.Nodes.Add("C0", "Senza categoria", 0, 0)

            For Each Cat As CatLav In C.GetAll("OrdineEsecuzione,Descrizione")
                Dim ChiavePadre As String = "C" & Cat.IdCatLav

                Dim ChiaveReparto As String = "R" & Cat.RepartoAppartenenza

                tvwCat.Nodes(ChiaveReparto).Nodes.Add(ChiavePadre, Cat.Descrizione & " (Ord. " & Cat.OrdineEsecuzione & ")", 0, 0)

                'qui devo caricare tutti i singoli formati prodotto che sono linkati in tutte le lavorazioni di questa categoria
                'chiamo un metodo specifico che mi torna una serie di IdFormatoProdotto
                Using mgr As New FormatiProdottoDAO
                    For Each IdCl As Integer In mgr.ListaIdFormatoByIdCatLav(Cat.IdCatLav)
                        Dim ChiaveNodo As String = ChiavePadre & "F" & IdCl
                        Dim TextNodo As String = String.Empty
                        If IdCl Then
                            Dim fp As New FormatoProdotto
                            fp.Read(IdCl)
                            TextNodo = fp.Formato
                        Else
                            TextNodo = " * - Tutti i formati"
                        End If
                        tvwCat.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes.Add(ChiaveNodo, TextNodo, 1, 1)

                        Using mgrL As New LavorazioniDAO
                            For Each IdL As Integer In mgrL.ListaIdLavorazioniByFormatoProdotto(IdCl, Cat.IdCatLav)
                                Dim ChiaveNodoL As String = ChiaveNodo & "L" & IdL
                                Dim TextNodoL As String = String.Empty

                                Dim L As New Lavorazione
                                L.Read(IdL)
                                TextNodo = L.Sigla & " - " & L.Descrizione

                                tvwCat.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes(ChiaveNodo).Nodes.Add(ChiaveNodoL, TextNodo, 2, 2)

                            Next
                        End Using

                    Next
                End Using

            Next

            tvwCat.Nodes("R" & enRepartoWeb.Tutto).Expand()
            tvwCat.Nodes("R" & enRepartoWeb.StampaOffset).Expand()
            tvwCat.Nodes("R" & enRepartoWeb.StampaDigitale).Expand()
            tvwCat.Nodes("R" & enRepartoWeb.Ricamo).Expand()
            tvwCat.Nodes("R" & enRepartoWeb.Packaging).Expand()
            tvwCat.Nodes("R" & enRepartoWeb.Etichette).Expand()

        End Using

    End Sub

    Private Sub lnkAggiungiLav_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiungiLav.LinkClicked
        ParentFormEx.Sottofondo()

        Dim x As New frmListinoLavorazione, Ris As Integer

        Ris = x.Carica()

        If Ris Then CaricaLavorazioni()
        x = Nothing

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub CaricaCombo()

        Try
            Using M As New MacchinariDAO

                cmbMacchinari.ValueMember = "IdMacchinario"
                cmbMacchinari.DisplayMember = "Descrizione"
                cmbMacchinari.DataSource = M.GetAll(LFM.Macchinario.Descrizione, True)
            End Using
            'Dim C As New CatLavDAO

            'cmbCategoria.ValueMember = "IdCatLav"
            'cmbCategoria.DisplayMember = "Descrizione"
            'cmbCategoria.DataSource = C.GetAll("Descrizione", True)

        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CaricaLavorazioni()

        'carico la lista delle lavorazioni 

        Using mgr As New LavorazioniDAO


            Dim IdCat As Integer = 0

            If Not tvwCat.SelectedNode Is Nothing Then

                If tvwCat.SelectedNode.Name.StartsWith("C") Then
                    Dim PosizF As Integer = tvwCat.SelectedNode.Name.IndexOf("F")
                    If PosizF <> -1 Then
                        IdCat = tvwCat.SelectedNode.Name.Substring(1, PosizF - 1)
                    Else
                        IdCat = tvwCat.SelectedNode.Name.Substring(1)
                    End If

                End If

                Dim l As List(Of LavorazioneEx) = mgr.ListaLavorazioni(cmbMacchinari.SelectedValue, IdCat) ',cmbCategoria.SelectedValue)
                DgLavorazioni.AutoGenerateColumns = False
                DgLavorazioni.DataSource = l

                'qui se possibile selelziono una voce nella lista
                Dim PosizL As Integer = tvwCat.SelectedNode.Name.IndexOf("L")
                If PosizL <> -1 Then
                    Dim IdL As Integer = tvwCat.SelectedNode.Name.Substring(PosizL + 1)
                    'qui lo devo selezionare nella lista 
                    For Each r As DataGridViewRow In DgLavorazioni.Rows
                        If DirectCast(r.DataBoundItem, LavorazioneEx).IdLavoro = IdL Then
                            r.Selected = True

                        End If
                    Next

                End If

            End If
        End Using

        'Dim x As New cLavoriColl
        'Dim dtLista As DataTable

        'dtLista = x.ListaLavorazioni

        'DgLavorazioni.DataSource = dtLista

        'DgLavorazioni.Columns(0).Visible = False
        'DgLavorazioni.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"

        'x = Nothing

    End Sub
    Private Sub lnkModLav_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModLav.LinkClicked
        ModificaLavorazioni()
    End Sub

    Private Sub DgLavorazioni_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLavorazioni.CellDoubleClick
        ModificaLavorazioni()
    End Sub

    Private Sub ModificaLavorazioni()
        If DgLavorazioni.SelectedRows.Count Then

            Dim v As Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem

            Dim IdRif As Integer = 0
            IdRif = v.IdLavoro
            ParentFormEx.Sottofondo()

            Dim Ris As Integer = 0, x As New frmListinoLavorazione
            Ris = x.Carica(IdRif)
            If Ris Then CaricaLavorazioni()
            x = Nothing
            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub cmbMacchinari_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMacchinari.SelectedIndexChanged
        If sender.focused Then
            CaricaLavorazioni()
        End If
    End Sub

    Private Sub tvwCat_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwCat.AfterSelect
        CaricaLavorazioni()
    End Sub

    Private Sub tvwCat_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwCat.NodeMouseDoubleClick

        Dim PosizL As Integer = e.Node.Name.IndexOf("L")
        If PosizL <> -1 Then
            Dim IdL As Integer = e.Node.Name.Substring(PosizL + 1)

            ParentFormEx.Sottofondo()

            Dim f As New frmListinoLavorazione
            If f.Carica(IdL) Then
                CaricaCat()
            End If

            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        CaricaCat()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNewCatLav.LinkClicked

        ParentFormEx.Sottofondo()
        Using x As New frmListinoCatLav

            If x.Carica() Then
                CaricaCat()
            End If

        End Using
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEditCatLav.LinkClicked
        Dim IdCat As Integer = 0
        If Not tvwCat.SelectedNode Is Nothing Then

            If tvwCat.SelectedNode.Name.StartsWith("C") Then
                Dim PosizF As Integer = tvwCat.SelectedNode.Name.IndexOf("F")
                If PosizF <> -1 Then
                    IdCat = tvwCat.SelectedNode.Name.Substring(1, PosizF - 1)
                Else
                    IdCat = tvwCat.SelectedNode.Name.Substring(1)
                End If
            End If

        End If

        If IdCat Then
            ParentFormEx.Sottofondo()
            Using x As New frmListinoCatLav

                If x.Carica(IdCat) Then
                    CaricaCat()
                End If

            End Using
            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("Selezionare una Categoria di Lavorazioni")
        End If

    End Sub

    Private Sub DuplicaLavorazione()

        If DgLavorazioni.SelectedRows.Count Then

            Dim v As Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi la duplicazione di '" & v.Descrizione & "'?", "Duplicazione Lavorazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'qui devo duplicare la lavorazione chiamandola Copia di 

                Dim Lavoro As New Lavorazione
                Lavoro.Read(v.IdLavoro)
                Lavoro.IdLavoro = 0
                Lavoro.Descrizione &= " Copia"
                Lavoro.Sigla &= "-Copia"
                If Lavoro.IsValid Then
                    Lavoro.Save()

                    CaricaLavorazioni()
                Else
                    MessageBox.Show("Duplicazione non effettuata! Ci sono dei dati nel oggetto selezionato per la duplicazione che non sono validi.")
                End If
                
            End If
        End If

    End Sub

    Private Sub lnkDuplica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDuplica.LinkClicked
        DuplicaLavorazione()
    End Sub

    Private Sub lnkDelLav_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelLav.LinkClicked

        'qui elimino una lavorazione, per ora posso eliminare solo lavorazioni che non sono incluse in nessun listino base e in nessun lavlog
        'per le altre metto lo status a eliminato e non le carico piu 

        If DgLavorazioni.SelectedRows.Count Then
            Dim v As Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem
            If MessageBox.Show("Confermi la cancellazione di '" & v.Descrizione & "'?", "Cancellazione Lavorazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Using mgr As New LavorazSuPreventivazDAO
                    Dim L As List(Of LavorazSuPreventivaz) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.LavorazSuPreventivaz.IdLavoro, v.IdLavoro))

                    If L.Count = 0 Then
                        'qui la posso sicuramente cambiare di status ma ora vedo se la posso eliminare fisicamente
                        Using mgrLav As New LavLogDAO
                            Dim lLavlog As List(Of LavLog) = mgrLav.FindAll(New LUNA.LunaSearchParameter(LFM.LavLog.Idlav, v.IdLavoro))

                            If lLavlog.Count = 0 Then
                                'qui cancellazione fisica
                                Using mgrLavoraz As New LavorazioniDAO
                                    mgrLavoraz.Delete(v.IdLavoro)
                                End Using
                            Else

                                Using mgrLavoraz As New LavorazioniDAO
                                    mgrLavoraz.updateStato(v.IdLavoro, enStato.NonAttivo)
                                End Using
                            End If

                        End Using

                        CaricaLavorazioni()
                    Else
                        Dim Buffer As String = String.Empty

                        For Each singL As LavorazSuPreventivaz In L
                            Buffer &= singL.ListinoBase.NomeEx & ", "
                        Next
                        Buffer = Buffer.TrimEnd(" ", ",")
                        MessageBox.Show("Impossibile eliminare la lavorazione perchè attualmente utilizzata nei seguenti listini base: " & Buffer)
                    End If

                End Using

            End If

        Else

            MessageBox.Show("Selezionare una lavorazione!")

        End If

    End Sub

End Class
