Imports System.IO

Public Class PostazioneDiLavoro

    Public Sub New(Path As String)

        Try
            Nome = FormerLib.FormerHelper.File.EstraiNomeFile(Path)
            Nome = Nome.Replace(".log.txt", String.Empty)

            Using r As New StreamReader(Path)

                Dim buffer As String = r.ReadToEnd

                Dim Campi() As String = buffer.Split(";")
                UltimoAccesso = Campi(0)
                Versione = Campi(1)
                Utente = Campi(2)

                Dim f As New FileInfo(Path)

                UltimaModificaFile = f.LastWriteTime

                f = Nothing

            End Using
        Catch ex As Exception

        End Try

    End Sub

    Public Property UltimaModificaFile As Date

    Public Property UltimoAccesso As String

    Public Property Nome As String

    Public Property Versione As String

    Public Property Utente As String

End Class
