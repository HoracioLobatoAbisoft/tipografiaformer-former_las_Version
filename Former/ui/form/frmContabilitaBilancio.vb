Imports System.IO
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmContabilitaBilancio
    'Inherits baseFormInternaFixed

    Private _Ris As Integer
    Private _PathCsv As String = String.Empty

    Private _TipoReport As enTipoReportEconomico = enTipoReportEconomico.BilancioEsercizio
    Friend Function Carica(Optional TipoReport As enTipoReportEconomico = enTipoReportEconomico.BilancioEsercizio) As Integer

        _TipoReport = TipoReport

        If _TipoReport = enTipoReportEconomico.BilancioEsercizio Then
            lblTipo.Text = "Bilancio Annuale"
        ElseIf _TipoReport = enTipoReportEconomico.ReportIVA Then
            lblTipo.Text = "Conteggi Mensili IVA"
        ElseIf _TipoReport = enTipoReportEconomico.InventarioMagazzino Then
            lblTipo.Text = "Inventario Magazzino"
            lnkDownloadCSV.Visible = True
            'cmbAzienda.Visible = False
            'lblAzienda.Visible = False
        End If

        CaricaCombo()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Dim laz As New List(Of cEnum)
        Dim az1 As New cEnum(MgrAziende.IdAziende.AziendaSnc, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSnc))
        laz.Add(az1)
        Dim az2 As New cEnum(MgrAziende.IdAziende.AziendaSrl, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSrl))
        laz.Add(az2)

        cmbAzienda.ValueMember = "Id"
        cmbAzienda.DisplayMember = "Descrizione"
        cmbAzienda.DataSource = laz

        Dim lAnni As New List(Of cEnum)

        For i As Integer = 2019 To Now.Year
            Dim anno As New cEnum(i, i)
            lAnni.Add(anno)
        Next

        cmbAnno.ValueMember = "Id"
        cmbAnno.DisplayMember = "Descrizione"
        cmbAnno.DataSource = lAnni

        MgrControl.SelectIndexCombo(cmbAnno, Now.Year)

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

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)

        'If MessageBox.Show("Confermi qualcosa?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '_Ris = 1
        Close()

        'End If
    End Sub

    Private Sub lnkGenera_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGenera.LinkClicked

        'mgrbilancioAnnuale
        'Cursor.Current

        Dim Path As String = FormerConfig.FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")
        Dim ris As String = String.Empty
        If _TipoReport = enTipoReportEconomico.BilancioEsercizio Then
            ris = MgrReport.GetBilancioAziendaleAnnuale(cmbAnno.SelectedValue, cmbAzienda.SelectedValue)
        ElseIf _TipoReport = enTipoReportEconomico.ReportIVA Then
            ris = MgrReport.ReportFatture(cmbAnno.SelectedValue, cmbAzienda.SelectedValue)
        ElseIf _TipoReport = enTipoReportEconomico.InventarioMagazzino Then
            ris = MgrReport.GetInventarioMagazzinoCSV(cmbAnno.SelectedValue, cmbAzienda.SelectedValue)

            _PathCsv = Path.Replace(".htm", ".csv")
            Using w As New StreamWriter(_PathCsv)
                w.Write(ris)
            End Using
            ris = MgrReport.GetInventarioMagazzinoCSV(cmbAnno.SelectedValue, cmbAzienda.SelectedValue, True)
        End If

        Using w As New StreamWriter(Path)
            w.Write(ris)
        End Using

        webBilancio.Navigate(Path)


    End Sub

    Private Sub lnkStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        Sottofondo()

        Using x As New frmStampa

            x.Carica(webBilancio)

        End Using

        Sottofondo()
    End Sub

    Private Sub lnkDownloadCSV_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDownloadCSV.LinkClicked

        Dim NewPath As String = String.Empty
        If dlgFileSave.ShowDialog = DialogResult.OK Then
            NewPath = dlgFileSave.FileName
            MgrIO.FileCopia(Me, _PathCsv, NewPath)
            FormerLib.FormerHelper.File.ShellExtended(FormerLib.FormerHelper.File.GetFolder(NewPath))
            Close()
        End If

    End Sub
End Class