
Imports System.IO

Public Class FormerFileWatcher

    Public Sub New(FilePath As String)

        _FilePath = FilePath

        Dim PathFolder As String = String.Empty
        Dim FileName As String = String.Empty

        Dim f As New FileInfo(FilePath)
        PathFolder = FormerHelper.File.GetFolder(FilePath)
        FileName = f.Name

        Dim watcher As New IO.FileSystemWatcher()
        watcher.Path = PathFolder
        watcher.NotifyFilter = IO.NotifyFilters.LastWrite
        watcher.Filter = FileName

        AddHandler watcher.Changed, AddressOf OnChanged

        watcher.EnableRaisingEvents = True

    End Sub

    Private _FilePath As String = String.Empty

    Private Sub OnChanged(ByVal source As Object, ByVal e As IO.FileSystemEventArgs)
        RaiseEvent FileCambiato(e)
    End Sub

    Public Event FileCambiato(ByVal e As IO.FileSystemEventArgs)

End Class
