Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucAmministrazioneRubricaGruppi
    Inherits ucFormerUserControl

    Public Sub Carica()
        CaricaGruppi()

    End Sub

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        BackColor = Color.White
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

    End Sub

    Private Sub CaricaGruppi()

        'carico la lista delle lavorazioni 

        Using x As New cGruppiColl
            Dim dtLista As DataTable

            dtLista = x.Lista

            lstGruppi.DisplayMember = "Nome"
            lstGruppi.ValueMember = "IdGruppo"
            lstGruppi.DataSource = dtLista

        End Using

    End Sub

    Private Sub CaricaTipoCommesse()

        'carico la lista dei tipi di Commessa

        Using x As New cTipoCommessaColl
            Dim dtLista As DataTable

            dtLista = x.Lista

            dgContatti.DataSource = dtLista

            dgContatti.Columns(0).Visible = False
            '        DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '        DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"

        End Using

    End Sub

    Private Sub RiapriVoce()

        If dgContatti.SelectedRows.Count Then

            Dim IdVoce As Integer
            IdVoce = dgContatti.SelectedRows(0).Cells(0).Value

            Dim Ris As Integer = 0

            Dim frmRif As New frmVoceRubrica
            ParentFormEx.Sottofondo()
            Dim x As New VoceRubrica
            x.Read(IdVoce)

            Ris = frmRif.Carica(x)
            x = Nothing
            ParentFormEx.Sottofondo()

            If Ris Then CaricaTipoCommesse()
            frmRif.Dispose()

        End If

    End Sub

    Private Sub dgTipoCom_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RiapriVoce()
    End Sub

    Private Sub lnkAggiungiLav_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiungiLav.LinkClicked

        ParentFormEx.Sottofondo()

        Dim x As New frmGruppo

        x.Carica()
        CaricaGruppi()

        x = Nothing

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub CaricaRubGruppo()

        Cursor = Cursors.WaitCursor
        Dim IdGruppoSel As Integer = 0
        If lstGruppi.SelectedIndex <> -1 Then

            IdGruppoSel = lstGruppi.SelectedValue

            Cursor.Current = Cursors.WaitCursor
            'qui effettuo la ricerca in base ai parametri selezionati

            Using G As New Gruppo
                G.Read(IdGruppoSel)
                Dim l As List(Of IVoceRubricaG)
                Using mgr As New VociRubGDAO

                    l = mgr.GetAllVoceRubG(G)
                    l = mgr.ApplicaFiltro(l, G)

                    lblRis.Text = "Risultati: - " & l.Count
                    dgContatti.AutoGenerateColumns = False
                    dgContatti.DataSource = l
                End Using
            End Using

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub lnkDelLav_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDelLav.LinkClicked
        EliminaGruppo()
    End Sub

    'Private Sub lnkModTipoCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    If dgContatti.SelectedRows.Count Then

    '        Dim IdRif As Integer = 0
    '        IdRif = dgContatti.SelectedRows(0).Cells(0).Value
    '        ParentFormEx.Sottofondo()

    '        Dim Ris As Integer = 0, x As New frmCommessaTipo
    '        Ris = x.Carica(IdRif)
    '        If Ris Then CaricaTipoCommesse()
    '        x = Nothing
    '        ParentFormEx.Sottofondo()

    '    End If
    'End Sub

    'Private Sub lnkNewTipoCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    ParentFormEx.Sottofondo()

    '    Dim Ris As Integer = 0, x As New frmCommessaTipo
    '    Ris = x.Carica()
    '    If Ris Then CaricaTipoCommesse()
    '    x = Nothing
    '    ParentFormEx.Sottofondo()

    'End Sub

    Private Sub lnkDelTipoCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub lstGruppi_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstGruppi.DoubleClick
        ModificaGruppo()
    End Sub

    Private Sub lstGruppi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGruppi.SelectedIndexChanged



    End Sub

    Private Sub lnkModLav_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkModLav.LinkClicked
        ModificaGruppo()
    End Sub

    Private Sub dgContatti_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DuplicaGruppo()

        If MessageBox.Show("Confermi la duplicazione del gruppo selezionato?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If lstGruppi.SelectedIndex <> -1 Then

                Dim IdRif As Integer = 0
                IdRif = lstGruppi.SelectedValue

                Using x As New cGruppiColl
                    x.DuplicaGruppo(IdRif)
                End Using

                MessageBox.Show("Il gruppo è stato duplicato correttamente!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub ModificaGruppo()

        If lstGruppi.SelectedIndex <> -1 Then

            Dim IdRif As Integer = 0
            IdRif = lstGruppi.SelectedValue
            ParentFormEx.Sottofondo()

            Dim Ris As Integer = 0, x As New frmGruppo
            Ris = x.Carica(IdRif)
            If Ris Then CaricaGruppi()
            x = Nothing
            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub EliminaGruppo()

        If lstGruppi.SelectedIndex <> -1 Then

            Dim IdRif As Integer = 0
            IdRif = lstGruppi.SelectedValue
            If MessageBox.Show("Confermi la cancellazione del gruppo selezionato?", "Cancellazione Gruppo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using G As New Gruppo
                    G.Read(IdRif)
                    G.Stato = enStato.NonAttivo
                    G.Save()

                End Using
                CaricaGruppi()
            End If

        End If

    End Sub


    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        CaricaGruppi()
    End Sub


    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""

        Titolo = "Contatti del gruppo"

        StampaGlobale(Titolo, dgContatti)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkPrintEtich_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrintEtich.LinkClicked

        If lstGruppi.SelectedIndex <> -1 Then
            Dim IdGruppoSel As Integer = 0
            IdGruppoSel = lstGruppi.SelectedValue

            Cursor.Current = Cursors.WaitCursor
            'qui effettuo la ricerca in base ai parametri selezionati

            Using G As New Gruppo
                G.Read(IdGruppoSel)
                Dim l As List(Of IVoceRubricaG)
                Using mgr As New VociRubGDAO

                    l = mgr.GetAllVoceRubG(G)
                    l = mgr.ApplicaFiltro(l, G)

                    Dim p As New myPrinter, PrinterName As String = String.Empty

                    Dim prin As New System.Windows.Forms.PrintDialog
                    prin.ShowDialog()
                    If prin.PrinterSettings.PrinterName.Length Then PrinterName = prin.PrinterSettings.PrinterName

                    p.PrinterName = PrinterName
                    p.StampaEtichettaBusta(l)

                    p = Nothing
                End Using
            End Using

            'Dim IdRif As Integer = 0
            'IdRif = lstGruppi.SelectedValue
            'Using x As New VociRubricaDAO
            '    Dim dt As DataTable = x.ListaGruppo(IdRif)

            '    dgContatti.DataSource = dt

            '    Dim p As New myPrinter, PrinterName As String = String.Empty

            '    Dim prin As New System.Windows.Forms.PrintDialog
            '    prin.ShowDialog()
            '    If prin.PrinterSettings.PrinterName.Length Then PrinterName = prin.PrinterSettings.PrinterName

            '    p.PrinterName = PrinterName
            '    p.StampaEtichettaBusta(dt)


            '    p = Nothing
            'End Using
            'MessageBox.Show("Stampa terminata")
        End If

    End Sub

    Private Sub lstGruppi_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstGruppi.MouseDoubleClick

    End Sub

    Private Sub lnkShowRis_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkShowRis.LinkClicked
        If MessageBox.Show("Vuoi caricare i contatti del gruppo nella lista? (Può richiedere qualche secondo)", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CaricaRubGruppo()
        End If
    End Sub
End Class
