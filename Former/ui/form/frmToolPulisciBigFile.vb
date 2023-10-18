Imports System.IO
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmToolPulisciBigFile
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        lblPath.Text = FormerConfig.FormerPath.PathCommesse

        'CARICO I REPARTI
        Dim Campo As FormerLib.cEnum

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Tutto)
        Campo.Descrizione = "-"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.StampaOffset)
        Campo.Descrizione = "Stampa OffSet"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.StampaDigitale)
        Campo.Descrizione = "Stampa Digitale"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Packaging)
        Campo.Descrizione = "Packaging"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Ricamo)
        Campo.Descrizione = "Ricamo"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Etichette)
        Campo.Descrizione = "Etichette"
        cmbReparto.Items.Add(Campo)


        Show()

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

    Dim StopSearch As Boolean = False

    Private Sub CercaInPath(Path As String,
                            MinMega As Integer,
                            ByRef LRis As List(Of cEnum))

        Dim d As New DirectoryInfo(Path)

        For Each f As FileInfo In d.GetFiles()
            Dim Dimensione As Integer = (f.Length / (1024 * 1024))
            If Dimensione >= MinMega Then


                Dim AggiungiACollezione As Boolean = True

                If cmbReparto.SelectedIndex <> 0 OrElse
                    chkDataInsAl.Checked OrElse
                    chkDataInsDal.Checked Then

                    Dim IdReparto As enRepartoWeb = cmbReparto.SelectedValue

                    Using mgr As New FileSorgentiDAO
                        Dim l As List(Of FileSorgente) = mgr.FindAll(New LUNA.LSP(LFM.FileSorgente.FilePath, f.FullName))

                        If l.Count Then
                            Using o As New Ordine
                                o.Read(l(0).IdOrd)

                                If IdReparto <> enRepartoWeb.Tutto AndAlso
                                   o.IdTipoProd <> IdReparto Then
                                    AggiungiACollezione = False
                                End If

                                If AggiungiACollezione AndAlso
                                   chkDataInsDal.Checked Then
                                    If o.DataIns < dtDataInsDal.Value Then
                                        AggiungiACollezione = False
                                    End If
                                End If

                                If AggiungiACollezione AndAlso
                                   chkDataInsDal.Checked Then
                                    If o.DataIns < dtDataInsDal.Value Then
                                        AggiungiACollezione = False
                                    End If
                                End If

                            End Using
                        End If

                    End Using
                End If
                If AggiungiACollezione Then
                    Dim val As New cEnum
                    val.Id = Dimensione
                    val.Descrizione = f.FullName
                    LRis.Add(val)
                End If

            End If
            If StopSearch Then Exit For
            Application.DoEvents()
        Next

        For Each dir As DirectoryInfo In d.GetDirectories
            CercaInPath(dir.FullName, MinMega, LRis)
            If StopSearch Then Exit For
            Application.DoEvents()
        Next

    End Sub

    Private Sub CercaBigFile()

        Dim PathStart As String = FormerConfig.FormerPath.PathCommesse
        Dim MinMega As Integer = txtMinSize.Text
        Dim Lris As New List(Of cEnum)

        CercaInPath(PathStart, MinMega, Lris)

        dgRis.DataSource = Lris

    End Sub

    Private Sub btnCerca_Click(sender As Object, e As EventArgs) Handles btnCerca.Click
        StopSearch = False
        btnStop.Enabled = True
        btnCerca.Enabled = False
        Cursor.Current = Cursors.WaitCursor
        CercaBigFile()
        Cursor.Current = Cursors.Default
        btnStop.Enabled = False
        btnCerca.Enabled = True
        MessageBox.Show("Ricerca completata. Trovati " & dgRis.Rows.Count & " files")
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Cursor.Current = Cursors.Default
        StopSearch = True
        btnStop.Enabled = False
        btnCerca.Enabled = True

    End Sub

    Private Sub lnkOpenFoldSorg_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApriFile.LinkClicked

        If dgRis.SelectedRows.Count Then
            Dim val As cEnum = dgRis.SelectedRows(0).DataBoundItem

            FormerHelper.File.ShellExtended(val.Descrizione)

        End If

    End Sub

    Private Sub lnkApriCon_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApriCon.LinkClicked

        If dgRis.SelectedRows.Count Then
            Dim val As cEnum = dgRis.SelectedRows(0).DataBoundItem

            FormerLib.FormerHelper.File.OpenWithDialog(val.Descrizione)

        End If

    End Sub

    Private Sub lnkOpenFoldSorg_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOpenFoldSorg.LinkClicked

        If dgRis.SelectedRows.Count Then
            Dim val As cEnum = dgRis.SelectedRows(0).DataBoundItem

            FormerHelper.File.ShellExtended(FormerLib.FormerHelper.File.GetFolder(val.Descrizione))

        End If
    End Sub
End Class