Imports FormerDALSql
Public Class ucAmministrazioneRubricaMarketing
    Inherits ucFormerUserControl


    Private _IdRub As Integer
    Public Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
        End Set
    End Property

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""
        Titolo = "Storico azioni di marketing"
        StampaGlobale(Titolo, DgLavori)
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub Mostradati()

        Dim Mgr As New EmailDAO()
        Dim Par1 As New LUNA.LunaSearchParameter(LFM.Email.IdRubDest, _IdRub)

        Dim Lst As List(Of Email) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Quando desc"},
                                                Par1)
        DgLavori.AutoGenerateColumns = False
        DgLavori.DataSource = Lst

        'Dim x As New cMagazColl

        'Dim dt As DataTable

        'dt = x.ListaRisFornitore(_IdForn)


        'DgLavori.DataSource = dt
        'DgLavori.Columns(0).Visible = False

    End Sub

    Private Sub DgLavori_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLavori.CellContentDoubleClick

        Dim RigaSel As Integer = e.RowIndex

        If RigaSel <> -1 Then
            Dim email As Email = DgLavori.Rows(RigaSel).DataBoundItem
            ParentFormEx.Sottofondo()
            Using x As New frmMarketingEmail
                x.Riapri(email)
            End Using
            ParentFormEx.Sottofondo()
            email = Nothing
            '    Dim IdVoce As Integer = CType(DgLavori.Rows(RigaSel).Cells(0).FormattedValue, Integer)
            '    ParentFormerForm.Sottofondo 
            '    Dim x As New frmContab
            '    x.Carica(IdVoce)
            '    x = Nothing
            '    ParentFormerForm.Sottofondo 

        End If
    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        Mostradati()
    End Sub

    Private Sub DgLavori_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLavori.CellContentClick

    End Sub
End Class
