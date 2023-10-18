Imports FormerDALWeb
Imports FormerListiniLib

Friend Class frmCreaListinoPDF
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin

        ShowDialog()

        LUNA.LunaContext.ConnectionString = String.Empty

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

    Private Sub btnGenera_Click(sender As Object, e As EventArgs) Handles btnGenera.Click

        If MessageBox.Show("Confermi la generazione del listino PDF?", "Genera listino", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Cursor.Current = Cursors.WaitCursor
            'Application.DoEvents()
            Sottofondo()

            Dim L As New ListinoUtente
            L.IdUt = FormerLib.FormerConst.UtentiSpecifici.IdRubricaInternaFormer
            L.Nominativo = "Tipografia Former"

            Dim PathFileDest As String = FormerConfig.FormerPath.PathTempLocale & "listino-" & Now.ToString("yyyyMMdd") & ".pdf"
            MGRListini.CreaCatalogo(PathFileDest, L,, rdoListinoFornitori.Checked)

            Sottofondo()
            Cursor.Current = Cursors.Default

            FormerLib.FormerHelper.File.ShellExtended(PathFileDest)

            Close()


        End If

    End Sub
End Class