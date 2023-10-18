Imports System.IO
Imports FormerDALWeb

Public Class FormerWebApp

    'Private Shared _PercIva As Integer = 21

    Shared Sub New()

        'inizializzo la static class

    End Sub

    Public Shared ReadOnly Property OreDurataCookie As Integer
        Get
            Return 168 'DURATA COOKIE IMPOSTATA A 7 GIORNI
        End Get
    End Property

    Public Shared ReadOnly Property SitoInManutenzione() As Boolean
        Get
            Dim ris As Boolean = False
            'qui in realta dovrei andare a vedere cosa succede sul main site 

            ris = ConfigurationManager.AppSettings("SitoInManutenzione")

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PercMinimaRicarico As Integer
        Get
            Return 0
        End Get
    End Property

    Public Shared ReadOnly Property PercDefaultRicarico As Integer
        Get
            Return 20
        End Get
    End Property

    Public Shared ReadOnly Property NomeCookieLogin As String
        Get
            Return "FormerLoginName"
        End Get
    End Property

    Public Shared ReadOnly Property NomeCookieIdUtente As String
        Get
            Return "FormerAuth"
        End Get
    End Property

    Public Shared Sub LogMe(Stringa As String, Utente As UtenteSito)

        Try

            Dim Path As String = HttpContext.Current.Server.MapPath("/public/log/")
            Dim NomeFile As String = Now.Date.ToString("yyyyMMdd") & ".txt"
            Path &= NomeFile
            Dim Linea As String = Now.ToString("HH:mm.ss") & ";" &
                HttpContext.Current.Request.ServerVariables("REMOTE_ADDR") & ";" &
                HttpContext.Current.Session.SessionID & ";" & Utente.IdUtente & " (" & Utente.IdRubricaInt & ");" & Stringa & ";"
            If Not HttpContext.Current.Request.Browser Is Nothing Then
                Linea &= HttpContext.Current.Request.Browser.Browser & "_" &
                    HttpContext.Current.Request.Browser.MajorVersion & "." &
                    HttpContext.Current.Request.Browser.MinorVersion & ";"
            Else
                Linea &= "{nobrowser};"
            End If

            Using w As New StreamWriter(Path, True)
                w.WriteLine(Linea)
            End Using

        Catch ex As Exception

        End Try

    End Sub

End Class
