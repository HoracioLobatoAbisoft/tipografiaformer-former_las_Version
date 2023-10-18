Imports System.IO
Imports FormerLib
Imports FormerConfig

Public Class ServerSito

    Public Sub New(Nome As String)
        NomeServer = Nome
        DataUltimaPubbl = GetUltimaPubblicazione()
    End Sub

    Public Property NomeServer As String
    Public Property FTPHost As String
    Public Property FTPLogin As String
    Public Property FTPPwd As String

    Public Property SQLConnectionString As String

    Public Property DataUltimaPubbl As Date = Date.MinValue

    Public ReadOnly Property IsProduzione As Boolean
        Get
            Dim ris As Boolean = False
            If NomeServer = "Produzione" Then
                ris = True
            End If
            Return ris
        End Get
    End Property

    Private Function GetUltimaPubblicazione() As Date

        Dim ris As Date = Date.MinValue
        Try
            Dim nomeFileUltPubbl As String = FormerPath.PathCentralizzato & "\" & NomeServer & "-ultpubbl.dat"
            If File.Exists(nomeFileUltPubbl) Then
                Dim strUlt As String = String.Empty
                Using r As New StreamReader(nomeFileUltPubbl)
                    strUlt = r.ReadToEnd
                End Using
                'qui la data è in formato ddMMyyyyHHmmss
                'la riscorporo
                Dim dd As String = strUlt.Substring(0, 2)
                Dim MM As String = strUlt.Substring(2, 2)
                Dim yyyy As String = strUlt.Substring(4, 4)
                Dim HH As String = strUlt.Substring(8, 2)
                Dim m As String = strUlt.Substring(10, 2)
                Dim ss As String = strUlt.Substring(12, 2)
                ris = New Date(yyyy, MM, dd, HH, m, ss)
            End If
        Catch ex As Exception
            Dim Err As String = ex.Message
        End Try

        Return ris

    End Function

    Public Sub SetUltimaPubblicazione()
        DataUltimaPubbl = Now
        Dim nomeFileUltPubbl As String = FormerPath.PathCentralizzato & "\" & NomeServer & "-ultpubbl.dat"

        Using w As New StreamWriter(nomeFileUltPubbl, False)
            w.Write(DataUltimaPubbl.ToString("ddMMyyyyHHmmss"))
        End Using

    End Sub

End Class
