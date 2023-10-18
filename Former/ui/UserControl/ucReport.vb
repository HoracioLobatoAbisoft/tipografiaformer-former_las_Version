Imports FormerDALSql
Imports FormerLib.FormerEnum
Public Class ucReport
    Inherits ucFormerUserControl
    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

    End Sub

    Public Sub CaricaDati()

        Dim x As New cReportColl

        cmbReport.DisplayMember = "NomeReport"
        cmbReport.ValueMember = "IdTipo"
        cmbReport.DataSource = x

        'carico la combo dei giorni
        Dim I As Integer = 0

        For I = 1 To 31
            cmbGiornoFine.Items.Add(I)
            cmbGiornoInizio.Items.Add(I)
        Next
        cmbGiornoFine.SelectedIndex = 0
        cmbGiornoInizio.SelectedIndex = 0

        'Dim cli As New VociRubricaDAO
        'cmbCli.ValueMember = "IdRub"
        'cmbCli.DisplayMember = "Nominativo"

        'cmbCli.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, False, "ORD")

        'Dim xP As New cProdottiColl
        'cmbProd.ValueMember = "Codice"
        'cmbProd.DisplayMember = "Descr"

        'cmbProd.DataSource = xP.ListaPerReport


    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked

        If cmbReport.SelectedIndex <> -1 Then

            Dim x As New cReportColl
            Dim dt As DataTable = Nothing
            Try
                dt = x.EseguiReport(CInt(cmbReport.SelectedValue.idtipo), cmbGiornoInizio.Text, cmbGiornoFine.Text)

            Catch ex As Exception

            End Try

            dgReport.Columns.Clear()

            dgReport.DataSource = dt
            dgReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Select Case cmbReport.SelectedValue.idtipo

                'Case cReportColl.enTipoReport.enTipRepFatturatoCliente
                '    dgReport.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '    dgReport.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '    dgReport.Columns(2).DefaultCellStyle.Format = "0.00"
                '    dgReport.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Case cReportColl.enTipoReport.enTipRepFatturatoMensile
                    dgReport.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(1).DefaultCellStyle.Format = "0.00"

                    'Case cReportColl.enTipoReport.enTipRepFatturatoMeseCategoria
                    '    dgReport.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '    dgReport.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '    dgReport.Columns(2).DefaultCellStyle.Format = "0.00"
                    '    dgReport.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    'Case cReportColl.enTipoReport.enTipRepFatturatoClientiMeseCategoria
                    '    dgReport.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '    dgReport.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '    dgReport.Columns(2).DefaultCellStyle.Format = "0.00"
                    '    dgReport.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    'Case cReportColl.enTipoReport.enTipRepProdottoMese
                    '    dgReport.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '    dgReport.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '    dgReport.Columns(3).DefaultCellStyle.Format = "0.00"
                    '    dgReport.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '    dgReport.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Case cReportColl.enTipoReport.enTipRepSituazGenerale
                    dgReport.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(3).DefaultCellStyle.Format = "0.00"
                    dgReport.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(6).DefaultCellStyle.Format = "0.00"
                    dgReport.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(8).DefaultCellStyle.Format = "0.00"

                Case cReportColl.enTipoReport.enTipRepCostiRicaviMese
                    dgReport.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgReport.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                    dgReport.Columns(1).DefaultCellStyle.Format = "0.00"
                    dgReport.Columns(2).DefaultCellStyle.Format = "0.00"
                    dgReport.Columns(4).DefaultCellStyle.Format = "0.00"



            End Select


        End If

    End Sub

    Private Sub cmbReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReport.SelectedIndexChanged

        pnlFatturatoMensile.Visible = False
        'pnlCliente.Visible = False
        'pnlProdotto.Visible = False

        Select Case cmbReport.SelectedValue.idtipo
            Case cReportColl.enTipoReport.enTipRepFatturatoMensile
                pnlFatturatoMensile.Visible = True
                'Case cReportColl.enTipoReport.enTipRepFatturatoClientiMeseCategoria
                '    pnlCliente.Visible = True

                'Case cReportColl.enTipoReport.enTipRepProdottoMese
                '    pnlProdotto.Visible = True

        End Select
    End Sub

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""

        Titolo = cmbReport.Text

        StampaGlobale(Titolo, dgReport)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub dgReport_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReport.CellContentClick

    End Sub

    Private Sub dgReport_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReport.CellContentDoubleClick
        If cmbReport.SelectedValue.idtipo = cReportColl.enTipoReport.enTipRepSituazGenerale Then
            'qui carico il dettaglio cliente
            If dgReport.SelectedRows.Count Then
                Dim iDCli As Integer = dgReport.SelectedRows(0).Cells(0).Value
                Dim x As New frmVoceRubrica, Cli As New VoceRubrica
                Cli.Read(iDCli)
                ParentFormEx.Sottofondo()
                x.Carica(Cli)
                ParentFormEx.Sottofondo()
                x = Nothing
                Cli = Nothing
            End If

        End If
    End Sub
End Class
