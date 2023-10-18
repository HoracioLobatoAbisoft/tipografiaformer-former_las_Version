Imports FormerDALSql
Public Class ucAmministrazioneOperatori
    Inherits ucFormerUserControl

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

    End Sub
    Private Sub ucOperatori_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub CaricaDati()
        ' Debug.Traccia()
        CaricaComboPeriodo()
        CaricaOperatori()
        'Debug.Traccia(False)
    End Sub

    Private Sub NewOper()
        Dim frmRif As New frmUtente
        Dim Ris As Integer = 0

        ParentFormEx.Sottofondo()
        Ris = frmRif.Carica()
        ParentFormEx.Sottofondo()
        If Ris Then CaricaOperatori()
        frmRif.Dispose()

    End Sub

    Private Sub CaricaOperatori()

        'carico gli operatori che possono accedere all'applicazione
        Using x As New UtentiDAO
            DGOperat.AutoGenerateColumns = False
            DGOperat.DataSource = x.GetAll(LFM.Utente.Login)
        End Using
        'DGOperat.Columns(0).Visible = False

    End Sub

    Private Sub StampaOperatori()
        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""
        Titolo = "Lista Operatori"

        StampaGlobale(Titolo, DGOperat)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        NewOper()
    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        CaricaOperatori()
    End Sub

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        StampaOperatori()
    End Sub

    Private Sub CaricaComboPeriodo()

        'carico l'anno
        cmbAnno.Items.Clear()
        Dim I As Integer

        For I = Date.Now.Year - 1 To Date.Now.Year

            cmbAnno.Items.Add(I)

        Next

        MgrControl.SelectIndexCombo(cmbAnno, Date.Now.Year.ToString)

        'carico i mesi
        cmbMese.Items.Clear()
        For I = 1 To 12

            cmbMese.Items.Add(FormerLib.FormerHelper.Calendario.MeseToString(I))

        Next
        MgrControl.SelectIndexCombo(cmbMese, FormerLib.FormerHelper.Calendario.MeseToString(Date.Now.Month))

    End Sub

    Private Sub SelOper()

        Dim IdVoce As Integer
        IdVoce = DirectCast(DGOperat.SelectedRows(0).DataBoundItem, Utente).IdUt

        Dim X As New Utente
        X.Read(IdVoce)

        Using mU As New UtentiDAO

            If cmbAnno.Text.Length <> 0 And cmbMese.SelectedIndex <> -1 Then

                'lblBonusRiep.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(mU.CalcolaBonus(X.IdUt, cmbMese.SelectedIndex + 1, cmbAnno.Text))

                dgLogOperat.DataSource = mU.ElencoLavori(X.IdUt, cmbMese.SelectedIndex + 1, cmbAnno.Text)

                dgLogOperat.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgLogOperat.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgLogOperat.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgLogOperat.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dgLogOperat.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgLogOperat.Columns(6).DefaultCellStyle.Format = "0.00"

            Else

                lblBonusRiep.Text = "0,00"

            End If

        End Using

    End Sub

    Private Sub RiapriOper()
        Dim IdVoce As Integer
        IdVoce = DirectCast(DGOperat.SelectedRows(0).DataBoundItem, Utente).IdUt

        Dim Ris As Integer = 0

        Dim frmRif As New frmUtente
        ParentFormEx.Sottofondo()
        Ris = frmRif.Carica(IdVoce)
        ParentFormEx.Sottofondo()

        If Ris Then CaricaOperatori()
        frmRif.Dispose()

    End Sub

    Private Sub StampaLogOper()

        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""
        Titolo = "Lista Lavorazioni Operatore"

        StampaGlobale(Titolo, dgLogOperat)
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub DGOperat_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOperat.CellClick
        SelOper()
    End Sub

    Private Sub DGOperat_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOperat.CellContentClick

    End Sub

    Private Sub DGOperat_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOperat.CellDoubleClick
        RiapriOper()
    End Sub

    Private Sub lnStampaLog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnStampaLog.LinkClicked
        StampaLogOper()
    End Sub

    Private Sub lnkAggLog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggLog.LinkClicked
        SelOper()
    End Sub

    Private Sub lnkUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUser.LinkClicked
        Dim F As New frmCreaFormerKey
        ParentFormEx.Sottofondo()
        F.Carica()
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub lnkReport_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReport.LinkClicked

        ParentFormEx.Sottofondo()

        Using F As New frmReportOperatori
            F.Carica()
        End Using

        ParentFormEx.Sottofondo()

    End Sub

End Class
