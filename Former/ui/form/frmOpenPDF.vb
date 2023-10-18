Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports System.Data.SqlClient
Imports FormerPrinter
Imports FormerConfig
Imports FormerBusinessLogic
Imports Telerik.WinControls.UI
Imports System.IO

Public Class frmOpenPDF

    Private _Ris As DialogResult = DialogResult.Abort
    Public Function Carica(Optional InitialDirectory As String = "C:\",
                           Optional ForzaPathParametro As Boolean = False) As DialogResult

        If PostazioneCorrente.UltimaDirectoryAperta <> String.Empty Then
            If ForzaPathParametro = False Then InitialDirectory = PostazioneCorrente.UltimaDirectoryAperta
        End If

        If InitialDirectory.Length = 0 Then
            InitialDirectory = "C:\"
        End If

        If InitialDirectory.EndsWith("\") Then InitialDirectory = InitialDirectory.TrimEnd("\")

        'DirectoryTreeView.InitialPath = InitialDirectory
        SelezionaDir(InitialDirectory)

        If PostazioneCorrente.DialogSortColumn <> -1 Then

            FileListView.ListViewItemSorter = New ListViewItemComparer(PostazioneCorrente.DialogSortColumn, PostazioneCorrente.DialogSortOrder)
            FileListView.Sort()

        End If

        ShowDialog()

        Return _Ris
    End Function

    Private Sub SelezionaDir(Path As String,
                             Optional StartNode As TreeNode = Nothing)
        Cursor.Current = Cursors.WaitCursor

        Dim Start As TreeNodeCollection = DirectoryTreeView.Nodes

        If Not StartNode Is Nothing Then
            Start = StartNode.Nodes
        End If

        For Each Node As TreeNode In Start
            Dim PathNodo As String = Node.FullPath.ToUpper.Replace("\\", "\")
            If Path.ToUpper.StartsWith(PathNodo) Then
                Node.Expand()
                Node.EnsureVisible()
                'AddDirectories(Node, value)
                If Path.ToUpper = PathNodo Then
                    'qui l'ho trovato
                    DirectoryTreeView.SelectedNode = Node
                Else
                    SelezionaDir(Path, Node)
                End If

                If Not DirectoryTreeView.SelectedNode Is Nothing AndAlso Path.ToUpper = DirectoryTreeView.SelectedNode.FullPath.ToUpper.Replace("\\", "\") Then Exit For
                'Node.EnsureVisible()
            End If
        Next

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnAnnulla_Click(sender As Object, e As EventArgs) Handles btnAnnulla.Click

        Close()

    End Sub

    Private Sub DirectoryTreeView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles DirectoryTreeView.AfterSelect

        Try
            txtCurrentPath.Text = DirectoryTreeView.SelectedNode.FullPath.Replace("\\", "\")

            PostazioneCorrente.UltimaDirectoryAperta = txtCurrentPath.Text

            FileListView.ShowFiles(DirectoryTreeView.SelectedNode.FullPath)

        Catch ex As Exception
            FileListView.Items.Clear()
        End Try


    End Sub

    Private Sub FileListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FileListView.SelectedIndexChanged

    End Sub

    Public Property SelectedFile As String = String.Empty

    Private Sub CaricaAnteprimaInControl(Path As String)

        'AxAcroPDF.LoadFile(Path)
        'AxAcroPDF.src = Path
        'AxAcroPDF.setShowToolbar(False)
        'AxAcroPDF.setView("FitH")
        'AxAcroPDF.setLayoutMode("SinglePage")
        'AxAcroPDF.Show()
        'Dim PathS As String = FormerPath.PathTempLocale & "anteprimaopen.htm"
        'Dim Buffer As String = String.Empty

        'Buffer &= "<html><body>"
        'Buffer &= "<object data=""file://" & Path.Replace("\", "/") & """ type=""application/pdf"" width=""100%"" height=""100%"">"
        'Buffer &= "</body></html>"

        'Using w As New StreamWriter(PathS)
        '    w.Write(Buffer)
        'End Using

        'WebBrowser.Navigate(PathS)

        RadPreview.LoadDocument(Path)
        RadPdfViewerNavigator.OpenButton.Enabled = False

    End Sub

    Private Sub CaricaAnteprima()
        Try

            If chkAnteprima.Checked Then
                If FileListView.SelectedItems.Count Then

                    Dim Item As ListViewItem = FileListView.SelectedItems(0)

                    If Item.Tag = "F" Then
                        Cursor.Current = Cursors.WaitCursor

                        Dim name As String = FileListView.SelectedItems(0).Text
                        name = DirectoryTreeView.SelectedNode.FullPath & "\" & name
                        name = name.Replace("\\", "\")

                        If name.StartsWith("Desktop") Then
                            name = name.Replace("Desktop", Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
                        End If

                        'RadPreview.LoadDocument(name)

                        'AxAcroPDF.LoadFile(name)

                        CaricaAnteprimaInControl(name)

                        'webPDF.Navigate(name)

                        Cursor.Current = Cursors.Default
                    Else
                        'If Not RadPreview.Document Is Nothing Then RadPreview.UnloadDocument()
                        'webPDF.Navigate("about:blank")

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FileListView_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles FileListView.ItemSelectionChanged

        CaricaAnteprima()

    End Sub

    Private Sub ScegliFile()
        If FileListView.SelectedItems.Count Then
            'Cursor.Current = Cursors.WaitCursor
            Dim Item As ListViewItem = FileListView.SelectedItems(0)

            If Item.Tag = "F" Then
                Dim name As String = FileListView.SelectedItems(0).Text
                name = DirectoryTreeView.SelectedNode.FullPath & "\" & name
                name = name.Replace("\\", "\")
                'RadPreview.LoadDocument(name)
                'Cursor.Current = Cursors.Default
                If name.StartsWith("Desktop") Then
                    name = name.Replace("Desktop", Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
                End If
                SelectedFile = name
                _Ris = DialogResult.OK
                Close()
            Else
                MessageBox.Show("Selezionare un file PDF")
            End If

        Else
            MessageBox.Show("Selezionare un file PDF")
        End If
    End Sub

    Private Sub btnConferma_Click(sender As Object, e As EventArgs) Handles btnConferma.Click

        ScegliFile()

    End Sub

    Private Sub lnkUp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUp.LinkClicked

    End Sub

    Private Sub SelezionatoFile()
        If FileListView.SelectedItems.Count Then
            'Cursor.Current = Cursors.WaitCursor
            Dim Item As ListViewItem = FileListView.SelectedItems(0)

            If Item.Tag = "F" Then
                ScegliFile()
            ElseIf Item.Tag = "D" Then
                'qui cambio la directory corrente
                Dim name As String = Item.Text
                name = DirectoryTreeView.SelectedNode.FullPath & "\" & name
                name = name.Replace("\\", "\")
                SelezionaDir(name, DirectoryTreeView.SelectedNode)
            End If
        End If
    End Sub

    Private Sub FileListView_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles FileListView.MouseDoubleClick

        SelezionatoFile()

    End Sub

    Private Sub lnkUp_MouseClick(sender As Object, e As MouseEventArgs) Handles lnkUp.MouseClick

        Dim Node As TreeNode = DirectoryTreeView.SelectedNode
        If Not Node Is Nothing Then
            If Not Node.Parent Is Nothing Then
                DirectoryTreeView.SelectedNode = Node.Parent
            End If
        End If

    End Sub

    Private Sub FileListView_KeyDown(sender As Object, e As KeyEventArgs) Handles FileListView.KeyDown

        If e.KeyCode = Keys.Enter Then
            SelezionatoFile()
        End If

    End Sub

    'Dim sortColumn As Integer = -1
    'Dim sortOrder As SortOrder = SortOrder.Ascending

    Private Sub FileListView_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles FileListView.ColumnClick

        If e.Column <> PostazioneCorrente.DialogSortColumn Then
            ' Set the sort column to the new column.
            PostazioneCorrente.DialogSortColumn = e.Column
            ' Set the sort order to ascending by default.
            PostazioneCorrente.DialogSortOrder = SortOrder.Ascending
        Else
            ' Determine what the last sort order was and change it.
            If PostazioneCorrente.DialogSortOrder = SortOrder.Ascending Then
                PostazioneCorrente.DialogSortOrder = SortOrder.Descending
            Else
                PostazioneCorrente.DialogSortOrder = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.

        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        FileListView.ListViewItemSorter = New ListViewItemComparer(e.Column, PostazioneCorrente.DialogSortOrder)
        FileListView.Sort()

    End Sub

    Class ListViewItemComparer

        Implements IComparer

        Private m_ColumnNumber As Integer

        Private m_SortOrder As SortOrder

        Public Sub New(ByVal column_number As Integer, ByVal sort_order As SortOrder)

            m_ColumnNumber = column_number

            m_SortOrder = sort_order

        End Sub

        ' Compare the items in the appropriate column

        ' for objects x and y.

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

            Dim item_x As ListViewItem = DirectCast(x, ListViewItem)

            Dim item_y As ListViewItem = DirectCast(y, ListViewItem)

            ' Get the sub-item values.

            Dim string_x As String

            If item_x.SubItems.Count <= m_ColumnNumber Then

                string_x = ""

            Else

                string_x = item_x.SubItems(m_ColumnNumber).Text

            End If

            Dim string_y As String

            If item_y.SubItems.Count <= m_ColumnNumber Then

                string_y = ""

            Else

                string_y = item_y.SubItems(m_ColumnNumber).Text

            End If

            ' Compare them.

            If m_SortOrder = SortOrder.Ascending Then

                If IsNumeric(string_x) And IsNumeric(string_y) Then



                    Return Val(string_x.Replace(".", "")).CompareTo(Val(string_y.Replace(".", "")))

                ElseIf IsDate(string_x) And IsDate(string_y) Then



                    Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))

                Else

                    Return String.Compare(string_x, string_y)

                End If

            Else

                If IsNumeric(string_x) And IsNumeric(string_y) Then



                    Return Val(string_y).CompareTo(Val(string_x))

                ElseIf IsDate(string_x) And IsDate(string_y) Then


                    Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))

                Else

                    Return String.Compare(string_y, string_x)

                End If

            End If

        End Function

    End Class

End Class