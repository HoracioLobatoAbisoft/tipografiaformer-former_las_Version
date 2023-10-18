Imports System.IO
Imports FormerConfig
Friend Class MGRPostazioni
    Inherits BaseService

    Public Shared Property tvw As TreeView = Nothing
    Public Shared Property lblLastVer As Label = Nothing
    Public Shared Property lblLastCheckPostazioni As Label = Nothing

    Public Shared ReadOnly Property ListaPostazioni() As List(Of PostazioneDiLavoro)
        Get
            Dim ris As New List(Of PostazioneDiLavoro)
            Try
                Dim direc As New DirectoryInfo(FormerPath.PathLogPostazioni)

                For Each f In direc.GetFiles("*.log.txt")
                    Dim P As New PostazioneDiLavoro(f.FullName)

                    ris.Add(P)
                Next

                ris.Sort(Function(x, y) y.UltimaModificaFile.CompareTo(x.UltimaModificaFile))
            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

End Class
