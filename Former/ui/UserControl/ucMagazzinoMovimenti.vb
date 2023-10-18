Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucMagazzinoMovimenti
    Inherits ucFormerUserControl
    Private _IdRis As Integer

    Public Event AggiornataQta()

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        lnkNew.Visible = False

    End Sub

    Public Property IdRis() As Integer
        Get
            Return _IdRis
        End Get
        Set(ByVal value As Integer)
            _IdRis = value
        End Set
    End Property

    Public Sub CaricaMov()
        'carico i movimenti di magazzino della risorsa selezionata
        Cursor = Cursors.WaitCursor

        Using x As New cMagazColl

            DgMovimenti.DataSource = x.Lista(_IdRis)
            DgMovimenti.Columns(0).Visible = False

            DgMovimenti.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgMovimenti.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgMovimenti.Columns(4).DefaultCellStyle.Format = "0.000000"

        End Using

        Cursor = Cursors.Default

    End Sub

    Private Sub NuovoMovimento(Optional PrimoInserimento As Boolean = False)
        ParentFormEx.Sottofondo()

        Dim x As New frmMagazzinoMovimento, Ris As Integer

        x.IdRis = _IdRis

        Ris = x.Carica(,, IIf(PrimoInserimento, enTipoMovMagaz.Inserimento, 0), False)

        If Ris Then

            CaricaMov()
            RaiseEvent AggiornataQta()

        End If

        x = Nothing

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        NuovoMovimento()


    End Sub

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""

        Titolo = "Movimenti magazzino"

        StampaGlobale(Titolo, DgMovimenti)
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        CaricaMov()
    End Sub

    Private Sub DgMovimenti_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMovimenti.CellContentClick

    End Sub

    Private Sub DgMovimenti_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMovimenti.CellDoubleClick
        RiapriVoce()
    End Sub

    Private Sub RiapriVoce()

        If DgMovimenti.SelectedRows.Count Then

            Dim IdVoce As Integer
            IdVoce = DgMovimenti.SelectedRows(0).Cells(0).Value

            Dim Ris As Integer

            Dim IdFat As Integer = DgMovimenti.SelectedRows(0).Cells(5).Value

            'If IdFat Then
            '    Using frmFatt As New frmMagazzinoCarico
            '        ParentFormEx.Sottofondo()
            '        Ris = frmFatt.Carica(IdVoce)
            '        ParentFormEx.Sottofondo()
            '    End Using
            'Else
            Using frmRif As New frmMagazzinoMovimento
                ParentFormEx.Sottofondo()
                frmRif.IdRis = _IdRis
                Ris = frmRif.Carica(IdVoce)
                ParentFormEx.Sottofondo()
            End Using
            'End If

            If Ris Then
                CaricaMov()
                RaiseEvent AggiornataQta()
                'RaiseEvent RicalcolataGiacenza(Ris)
            End If

        End If
    End Sub

    Private Sub lnkRicalcola_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRicalcola.LinkClicked

        RicalcolaGiacenza()

    End Sub

    Private Sub RicalcolaGiacenza()

        'ricalcolo la giacenza della risorsa selezionata
        If MessageBox.Show("Confermi il ricalcolo della giacenza della risorsa in base ai movimenti di magazzino presenti?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim NewGiacenza As Integer = 0

            NewGiacenza = MgrMagazzino.RicalcolaGiacenza(IdRis)

            RaiseEvent RicalcolataGiacenza(NewGiacenza)

            MessageBox.Show("Giacenza ricalcolata. Nuova giacenza: " & NewGiacenza)

        End If

    End Sub

    Public Event RicalcolataGiacenza(NuovaGiacenza As Integer)

End Class
