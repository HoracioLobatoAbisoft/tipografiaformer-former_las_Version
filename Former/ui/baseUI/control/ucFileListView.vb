' Copyright (c) Microsoft Corporation. All rights reserved.
Imports System.Diagnostics ' For Process.Start
Imports System.IO

Class FileListView
    Inherits ListView
    Private strDirectory As String

    Public Sub New()
        ' Set the default View enumeration to Details.
        Me.View = System.Windows.Forms.View.Details

        ' Get images as icons for some of the common file types.
        Dim img As New ImageList()
        With img.Images
            .Add(My.Resources._IcoPdfColor)
            .Add(My.Resources.CLSDFOLD)
        End With

        ' The Small and Large image lists for the ListView use the same set of
        ' images.
        Me.SmallImageList = img
        Me.LargeImageList = img

        ' Create the columns.
        With Columns
            .Add("Name", 240, HorizontalAlignment.Left)
            .Add("Size", 80, HorizontalAlignment.Right)
            .Add("Modified", 80, HorizontalAlignment.Left)
            .Add("Attribute", 30, HorizontalAlignment.Left)
        End With
    End Sub

    ''' <summary>
    ''' Overrides the base class OnItemActivate event handler. Extends the base
    ''' class implementation to run any .exe or file with an associated executable.
    ''' </summary>
    'Protected Overrides Sub OnItemActivate(ByVal ea As EventArgs)
    '    MyBase.OnItemActivate(ea)

    '    Dim lvi As ListViewItem
    '    For Each lvi In SelectedItems
    '        Process.Start(Path.Combine(strDirectory, lvi.Text))
    '    Next lvi
    'End Sub

    ''' <summary>
    ''' This subroutine is used to display a list of all files in the directory
    ''' currently selected by the user from the custom TreeView control.
    ''' </summary>
    Public Sub ShowFiles(ByVal strDirectory As String)
        ' Save the directory name as a field.
        Me.strDirectory = strDirectory

        Items.Clear()

        If strDirectory.StartsWith("Desktop") Then
            strDirectory = strDirectory.Replace("Desktop", Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        End If

        Dim diDirectories As New DirectoryInfo(strDirectory)
        Dim adiDirectory() As DirectoryInfo = Nothing

        Try
            adiDirectory = diDirectories.GetDirectories
        Catch ex As Exception

        End Try

        For Each di As DirectoryInfo In adiDirectory
            Dim lvi As New ListViewItem(di.Name)
            lvi.ImageIndex = 1
            lvi.Tag = "D"
            Items.Add(lvi)
        Next


        Dim afiFiles() As FileInfo

        Try
            ' Call the convenient GetFiles method to get an array of all files
            ' in the directory.
            afiFiles = diDirectories.GetFiles()
        Catch
            Return
        End Try

        Dim fi As FileInfo
        For Each fi In afiFiles
            ' Create ListViewItem.
            Dim lvi As New ListViewItem(fi.Name)
            Dim Extension As String = Path.GetExtension(fi.Name).ToUpper()
            lvi.Tag = "F"
            If Extension = ".PDF" Then
                ' Assign ImageIndex based on filename extension.
                'Select Case Path.GetExtension(fi.Name).ToUpper()
                '    Case ".EXE"
                '        lvi.ImageIndex = 1
                '    Case Else
                '        lvi.ImageIndex = 0
                'End Select
                lvi.ImageIndex = 0
                ' Add file length and last modified time sub-items.
                lvi.SubItems.Add(fi.Length.ToString("N0"))
                lvi.SubItems.Add(fi.LastWriteTime.ToString())

                ' Add attribute subitem.
                Dim strAttr As String = ""

                If (fi.Attributes And FileAttributes.Archive) <> 0 Then
                    strAttr += "A"
                End If
                If (fi.Attributes And FileAttributes.Hidden) <> 0 Then
                    strAttr += "H"
                End If
                If (fi.Attributes And FileAttributes.ReadOnly) <> 0 Then
                    strAttr += "R"
                End If
                If (fi.Attributes And FileAttributes.System) <> 0 Then
                    strAttr += "S"
                End If
                lvi.SubItems.Add(strAttr)

                ' Add completed ListViewItem to FileListView.
                Items.Add(lvi)
            End If

        Next fi
    End Sub

    Private Sub FileListView_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub
End Class