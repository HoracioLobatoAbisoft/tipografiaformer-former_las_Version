Imports FormerDALSql
Imports FormerLib
Imports Microsoft.Win32

Friend Class frmStampaMassivaCosti
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _ListaCosti As List(Of Costo) = Nothing
    Friend Function Carica(ListaCosti As List(Of Costo)) As Integer
        _ListaCosti = ListaCosti

        lblDocCount.Text = _ListaCosti.Count

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi la stampa massiva dei documenti in coda?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Cursor.Current = Cursors.WaitCursor
            btnOk.Enabled = False
            Dim Counter As Integer = 1
            '_ListaCosti.Sort(Function(x, y) y.IdCosto.CompareTo(x.IdCosto))

            Dim okey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Internet Explorer\PageSetup", True)

            okey.SetValue("footer", "")
            okey.SetValue("header", "")
            okey.SetValue("Shrink_To_Fit", "yes")

            Try
                IO.File.Copy(FormerConst.Ambiente.PathFoglioStileFatturaElettronica & FormerConst.Ambiente.NomeFoglioStileFatturaElettronica, FormerConfig.FormerPath.PathTempLocale & FormerConst.Ambiente.NomeFoglioStileFatturaElettronica)
            Catch ex As Exception

            End Try
            lblCurrent.Visible = True

            For Each C As Costo In _ListaCosti
                okey.SetValue("footer", Counter)
                lblCurrent.Text = "Stampa " & Counter & " di " & _ListaCosti.Count
                'okey.SetValue("footer", Counter)
                UcDocumentiFiscaliXMLCosto.Carica(C, False)
                Application.DoEvents()

                Do

                    Threading.Thread.Sleep(2000)
                    Application.DoEvents()

                Loop Until UcDocumentiFiscaliXMLCosto.CaricamentoCompletato = True

                Refresh()

                UcDocumentiFiscaliXMLCosto.StampaFattura()

                Threading.Thread.Sleep(1000)
                'Threading.Thread.Sleep(5000)
                Counter += 1
                'If Counter = 3 Then Exit For

            Next

            okey.SetValue("footer", "")

            Cursor.Current = Cursors.Default
            lblCurrent.Visible = False
            '_Ris = 1
            'Close()
            'MessageBox.Show("Stampa completata")
            btnOk.Enabled = True
        End If
    End Sub

    Private Sub UcDocumentiFiscaliXMLCosto1_Load(sender As Object, e As EventArgs) Handles UcDocumentiFiscaliXMLCosto.Load

    End Sub

    'Private Sub UcDocumentiFiscaliXMLCosto1_CaricamentoCompletato() Handles UcDocumentiFiscaliXMLCosto.CaricamentoCompletato
    '    UcDocumentiFiscaliXMLCosto.StampaFattura()
    'End Sub
End Class