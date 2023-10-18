Imports FormerDALSql
Public Class ucStoricoAcquisti
    Inherits ucFormerUserControl
    Private _IdFat As Integer
    Public Property IdFat() As Integer
        Get
            Return _IdFat
        End Get
        Set(ByVal value As Integer)
            _IdFat = value
        End Set
    End Property

    Private _IdForn As Integer
    Public Property IdForn() As Integer
        Get
            Return _IdForn
        End Get
        Set(ByVal value As Integer)
            _IdForn = value
        End Set
    End Property

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""
        Titolo = "Storico acquisti fornitore"
        StampaGlobale(Titolo, DgLavori)
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub Mostradati()

        Dim x As New cMagazColl

        Dim dt As DataTable

        dt = x.ListaRisFornitore(_IdForn)


        DgLavori.DataSource = dt
        DgLavori.Columns(0).Visible = False

    End Sub


    Private Sub DgLavori_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLavori.CellContentDoubleClick

        Dim RigaSel As Integer = e.RowIndex

        If RigaSel <> -1 Then
            Dim IdVoce As Integer = CType(DgLavori.Rows(RigaSel).Cells(0).FormattedValue, Integer)
            ParentFormEx.Sottofondo()
            Using x As New frmContabilitaRicavo
                x.Carica(IdVoce)
            End Using
            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        Mostradati()
    End Sub
End Class
