Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerPrinter

Friend Class frmDaemonMonitor
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        'RefreshLog()

        ShowDialog()

        Return _Ris

    End Function

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

        If MessageBox.Show("Confermi qualcosa?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtCerca.Text = String.Empty
    End Sub
    Private Sub RefreshLog()
        Cursor.Current = Cursors.WaitCursor
        Using mgr As New DaemonLogDAO

            Dim Lp As LUNA.LunaSearchParameter = Nothing

            If txtCerca.Text.Trim.Length Then
                Lp = New LUNA.LunaSearchParameter(LFM.DaemonLog.Descrizione, "%" & txtCerca.Text.Trim & "%", "LIKE")
            End If

            Dim L As List(Of DaemonLog) = mgr.FindAll(New LUNA.LunaSearchOption With {.Top = 100, .OrderBy = LFM.DaemonLog.Quando.Name & " DESC"},
                                                      Lp)

            DgLog.AutoGenerateColumns = False
            DgLog.DataSource = L
        End Using
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub btnRefreshLog_Click(sender As Object, e As EventArgs) Handles btnRefreshLog.Click
        RefreshLog()
    End Sub

    Private Sub DgLog_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLog.CellDoubleClick

        If DgLog.SelectedRows.Count Then
            Dim Riga As DataGridViewRow = DgLog.SelectedRows(0)
            Dim Log As DaemonLog = Riga.DataBoundItem
            Dim Testo As String = Log.QuandoStr & " - " & Log.ServizioStr & ControlChars.NewLine & Log.Descrizione

            MessageBox.Show(Testo)
        End If

    End Sub

    Private Sub DgLog_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgLog.RowPostPaint

        Dim R As DataGridViewRow = DgLog.Rows(e.RowIndex)

        Dim D As DaemonLog = R.DataBoundItem
        If D.Tipo = enDaemonLogType.Exception Then
            R.DefaultCellStyle.BackColor = Color.Red
        Else
            R.DefaultCellStyle.BackColor = Color.White
        End If

    End Sub

    Private Sub btnPrinterServer_Click(sender As Object, e As EventArgs) Handles btnPrinterServer.Click
        If ProxyStampa.OkDemoneDiStampa = True Then
            MessageBox.Show("Demone di stampa ATTIVO")
        Else
            MessageBox.Show("Demone di stampa NON ATTIVO")
        End If
    End Sub
End Class