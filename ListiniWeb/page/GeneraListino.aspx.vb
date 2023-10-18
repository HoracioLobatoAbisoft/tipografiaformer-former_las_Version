Imports System.IO
Imports System.Threading
Imports FormerListiniLib
Imports FormerDALWeb

Public Class GeneraListino
    Inherits FormerSecurePage


    Public Function ListinoDisponibile() As Boolean
        Dim ris As Boolean = False

        Dim PathFileDest As String = PathListino & "listino.pdf"
        Dim OkGenera As Boolean = True

        If File.Exists(PathFileDest) Then
            If FormerLib.FormerHelper.File.IsFileLocked(PathFileDest) = False Then
                ris = True
            End If
        End If

        Return ris
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            FormerWebApp.LogMe("Accesso alla pagina GENERA LISTINO", UtenteConnesso)

            'carico l'ultima data di pubblicazione dal sito ufficiale

            Dim PathFileDest As String = PathListino & "timestamp.txt"
            Dim DataUltimaGenerazione As Date = Date.MinValue
            Dim DataUltimaPubblicazione As Date = Date.MinValue

            If File.Exists(PathFileDest) Then
                Dim Buffer As String = String.Empty
                Using r As New StreamReader(PathFileDest)
                    Buffer = r.ReadToEnd
                End Using

                lblLastGen.Text = "Il tuo ultimo listino è stato generato il " & Buffer

                DataUltimaGenerazione = CDate(Buffer)

            End If

            Try
                Dim PathLocale As String = PathListino & "lastpublish.txt"
                'provo a scaricare il file dell'ultima pubblicazione
                Using client As New System.Net.WebClient
                    Dim UrlTimeStamp As String = "http://www.tipografiaformer.it/lastpublish.txt"
                    client.DownloadFile(UrlTimeStamp, PathLocale)
                End Using

                'qui provo ad accedere al file locale per trovare il file stamp
                Dim Buffer As String = String.Empty
                Using r As New StreamReader(PathLocale)
                    Buffer = r.ReadToEnd
                End Using

                If Buffer.Length Then

                    'If UtenteConnesso.IdUtente = 3 Then
                    '    Response.Write(Buffer)
                    'End If

                    Dim gg As String = Buffer.Substring(0, 2)
                    Dim mm As String = Buffer.Substring(3, 2)
                    Dim aa As String = Buffer.Substring(6, 4)
                    Dim hh As String = Buffer.Substring(11, 2)
                    Dim mn As String = Buffer.Substring(14, 2)

                    DataUltimaPubblicazione = New Date(aa, mm, gg, hh, mn, 0)

                    'DataUltimaPubblicazione = CDate(Buffer)
                    Dim Differenza As Integer = DateDiff(DateInterval.Minute, DataUltimaGenerazione, DataUltimaPubblicazione)
                    If Differenza > 0 Then
                        pnlLastVersion.Visible = True
                        lnkScarica.Visible = False
                        'lblLastVersion.Text = Buffer
                    End If
                End If

            Catch ex As Exception
                'If UtenteConnesso.IdUtente = 3 Then
                '    Response.Write(ex.Message)
                'End If
            End Try

            pnlScarica.Visible = ListinoDisponibile()

            If File.Exists(PathListino & "listino.pdf") Then
                If FormerLib.FormerHelper.File.IsFileLocked(PathListino & "Listino.pdf") Then
                    lblStato.Text = "Stiamo generando il tuo listino, sarai avvisato tramite email quando sarà disponibile per il download in questa pagina."
                    '                    btnGenera.Enabled = False
                End If
            End If

            'GeneraListino()

            Using mgr As New ListiniUtenteWDAO
                Dim lu As List(Of ListinoUtenteW) = mgr.FindAll(New LUNA.LunaSearchParameter("IdUt", UtenteConnesso.IdUtente))
                If lu.Count Then
                    Dim lisUt As ListinoUtenteW = lu(0)
                    lblPerc.Text = lisUt.PercDefault
                Else
                    lblPerc.Text = FormerWebApp.PercDefaultRicarico
                End If

            End Using

        End If

    End Sub

    Public ReadOnly Property PathListino As String
        Get
            Dim ris As String = Server.MapPath("/output")

            ris &= "\" & UtenteConnesso.IdUtente & "\"

            Return ris

        End Get
    End Property

    Private Sub btnGenera_Click(sender As Object, e As EventArgs) Handles btnGenera.Click

        Dim PathFileDest As String = PathListino & "listino.pdf"
        Dim OkGenera As Boolean = True

        If File.Exists(PathFileDest) Then
            If FormerLib.FormerHelper.File.IsFileLocked(PathFileDest) Then
                OkGenera = False
            End If
        End If

        If OkGenera Then

            'FormerWebApp.LogMe("Richiesta Generazione Listino", UtenteConnesso)
            FormerWebApp.LogMe("Generazione Listino Avviata", UtenteConnesso)

            'GeneraListino()

            Dim childthreat As New ThreadStart(AddressOf GeneraListino)

            Dim child As Thread = New Thread(childthreat)

            child.Start()

            pnlScarica.Visible = False

            lblStato.Text = "Stiamo generando il tuo listino, sarai avvisato tramite email quando sarà disponibile per il download in questa pagina."
        Else
            lblStato.Text = "Stiamo generando il tuo listino, sarai avvisato tramite email quando sarà disponibile per il download in questa pagina."
        End If

    End Sub

    Private Sub GeneraListino()

        Try
            Dim L As New ListinoUtente
            L.IdUt = UtenteConnesso.IdUtente
            L.Nominativo = UtenteConnesso.Nominativo
            'L.ColoreSfondo = lblColSfondo.BackColor
            'L.ColoreContrasto = lblColPrimoPiano.BackColor

            Using mgr As New ListiniUtenteWDAO
                Dim lu As List(Of ListinoUtenteW) = mgr.FindAll(New LUNA.LunaSearchParameter("IdUt", UtenteConnesso.IdUtente))
                If lu.Count Then
                    Dim lisUt As ListinoUtenteW = lu(0)
                    L.PercRicarico = lisUt.PercDefault
                    lisUt.UltimaGenerazione = Now
                    lisUt.Save()
                Else
                    L.PercRicarico = FormerWebApp.PercDefaultRicarico
                End If

            End Using

            'FormerWebApp.LogMe("GENERAZIONE LISTINO - Percentuale Ricarico: " & L.PercRicarico, UtenteConnesso)

            'Dim PathFileDest As String = Server.MapPath("/output") ' & "\listino.pdf"
            Dim PathTimeStamp As String = String.Empty
            Dim PathFileDest As String = String.Empty

            'PathFileDest &= "\" & UtenteConnesso.IdUtente & "\"

            If Directory.Exists(PathListino) = False Then
                Directory.CreateDirectory(PathListino)
            End If

            'FormerLib.FormerHelper.File.CreateLongPath(PathListino)

            ' FormerWebApp.LogMe("GENERAZIONE LISTINO - Creata Cartella: " & PathListino, UtenteConnesso)

            PathTimeStamp = PathListino & "timestamp.txt"

            PathFileDest = PathListino & "listino.pdf"

            If File.Exists(PathFileDest) Then
                Try
                    File.Delete(PathFileDest)
                Catch ex As Exception

                End Try
            End If

            MGRListini.CreaCatalogo(PathFileDest, L)

            Using w As New StreamWriter(PathTimeStamp)
                w.Write(Now.ToString)
            End Using

            Dim TestoMail As String = String.Empty

            TestoMail = "Gentile cliente<br><br>il tuo listino personalizzato è stato generato e è pronto per essere scaricato.<br><br>"

            TestoMail &= "Lo puoi scaricare dalla tua area riservata (http://listini.tipografiaformer.it/area-riservata) oppure cliccando <a href=""http://listini.tipografiaformer.it/area-riservata"">qui</a><br>"

            'qui mando una mail di conferma
            FormerLib.FormerHelper.Mail.InviaMail("Il tuo listino personalizzato è pronto",
                                                  TestoMail,
                                                  UtenteConnesso.Utente.Email)
        Catch ex As Exception
            FormerWebApp.LogMe("Errore in Generazione listino: " & ex.Message, UtenteConnesso)
        End Try

    End Sub

    Private Sub lnkScarica_Click(sender As Object, e As EventArgs) Handles lnkScarica.Click

        If FormerLib.FormerHelper.File.IsFileLocked(PathListino & "Listino.pdf") = False Then
            Response.ContentType = "application/pdf"
            Response.AppendHeader("Content-Disposition", "attachment; filename=Listino.pdf")
            Response.TransmitFile("/output/" & UtenteConnesso.IdUtente & "/listino.pdf")
            Response.End()
        End If

    End Sub
End Class