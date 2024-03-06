Imports System.Net.Mail
Imports System.IO
Imports FormerDALWeb
Imports System.Drawing
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class FormerWebApp

    'Private Shared _PercIva As Integer = 21

    Shared Sub New()

        'inizializzo la static class

    End Sub

    ' Public Shared Property DbError As Boolean = False

    Public Shared ReadOnly Property MetaTitle As String
        Get
            'modificated-dev-last
            Return "Stampa Offset, Stampa Digitale Grande Formato, Packaging Personalizzato, Ricamo, Etichette---review"
        End Get
    End Property

    Public Shared ReadOnly Property MetaDescription As String
        Get
            Return "Tipografiaformer.it, il tuo mondo della stampa a Roma. Dal 1996 la Tipografia Former opera a Roma nel settore della stampa tipografica e, cresciuta nel corso degli anni, ha esteso la propria attività in tutta Italia."
        End Get
    End Property

    Public Shared ReadOnly Property IsCrawler(UserAgent As String) As Boolean
        Get
            Dim ris As Boolean = False
            Try
                Dim Crawlers As List(Of String) = FormerLib.FormerConst.Web.CrawlersList

                Dim ua As String = UserAgent.ToLower
                ris = Crawlers.Exists(Function(x) ua.Contains(x))

            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property MostraOfferte As Boolean
        Get
            Dim ris As Boolean = False

            ris = HttpContext.Current.Application("MostraOfferte")

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property MostraPromo(Optional SoloAttivi As Boolean = True) As Boolean
        Get
            Dim ris As Boolean = False

            Using p As New PromoWDAO
                Dim l As List(Of PromoW) = p.GetPromoDisponibili(SoloAttivi)

                If l.Count Then
                    ris = True
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared Property MobileRouteRegeX As New List(Of String)

    Private Shared _MostraCatVirtuali As enSiNo = enSiNo.NonDefinito
    Public Shared ReadOnly Property MostraCatVirtuali As enSiNo
        Get
            If _MostraCatVirtuali = enSiNo.NonDefinito Then
                Using p As New CatVirtualiWDAO
                    Dim l As List(Of CatVirtualeW) = p.GetAll()

                    If l.Count Then
                        _MostraCatVirtuali = enSiNo.Si
                    Else
                        _MostraCatVirtuali = enSiNo.No
                    End If
                End Using
            End If

            Return _MostraCatVirtuali
        End Get
    End Property

    'Public Shared Property FormerScriptManager As ScriptManager = Nothing

    Private Shared _DataUltimaPubblicazioneListino As Date = Date.MinValue
    Public Shared ReadOnly Property DataUltimaPubblicazioneListino As Date
        Get
            If _DataUltimaPubblicazioneListino = Date.MinValue Then
                Try


                    Dim PathLocale As String = HttpContext.Current.Server.MapPath("/") & "lastpublish.txt"

                    'qui provo ad accedere al file locale per trovare il file stamp
                    Dim Buffer As String = String.Empty
                    Using r As New StreamReader(PathLocale)
                        Buffer = r.ReadToEnd
                    End Using

                    If Buffer.Length Then

                        Dim gg As String = Buffer.Substring(0, 2)
                        Dim mm As String = Buffer.Substring(3, 2)
                        Dim aa As String = Buffer.Substring(6, 4)
                        Dim hh As String = Buffer.Substring(11, 2)
                        Dim mn As String = Buffer.Substring(14, 2)

                        _DataUltimaPubblicazioneListino = New Date(aa, mm, gg, hh, mn, 0)

                    End If

                Catch ex As Exception

                End Try
            End If
            Return _DataUltimaPubblicazioneListino
        End Get
    End Property

    Public Shared ReadOnly Property IsDebug As Boolean
        Get
            Dim ris As Boolean = False
            If Not ConfigurationManager.AppSettings("IsDebug") Is Nothing Then
                ris = Convert.ToBoolean(ConfigurationManager.AppSettings("IsDebug"))
            End If
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property NonPrendereInConsiderazioneCorriereFormer As Boolean
        Get
            Dim ris As Boolean = False

            If Not ConfigurationManager.AppSettings("NonPrendereInConsiderazioneCorriereFormer") Is Nothing Then
                ris = Convert.ToBoolean(ConfigurationManager.AppSettings("NonPrendereInConsiderazioneCorriereFormer"))
            End If

            Return ris
        End Get
    End Property

    Private Shared _PathLog As String = "/public/log/"
    Public Shared ReadOnly Property PhisicalPathLog() As String
        Get
            Return HttpContext.Current.Server.MapPath(_PathLog)
        End Get
    End Property

    Private Shared _PathOrdini As String = "/ordini/"
    Public Shared ReadOnly Property PathOrdini As String
        Get
            Return HttpContext.Current.Server.MapPath(_PathOrdini)
        End Get
    End Property

    Private Shared _PathPreventivi As String = "/preventivi/"
    Public Shared ReadOnly Property PathPreventivi As String
        Get
            Return HttpContext.Current.Server.MapPath(_PathPreventivi)
        End Get
    End Property

    Private Shared _PathLogPP As String = "/public/log/paypal/"
    Public Shared ReadOnly Property PathLogPP As String
        Get
            Return HttpContext.Current.Server.MapPath(_PathLogPP)
        End Get
    End Property

    Private Shared _PathConsegne As String = "/consegne/"
    Public Shared ReadOnly Property PathConsegne As String
        Get
            Return HttpContext.Current.Server.MapPath(_PathConsegne)
        End Get
    End Property

    Public Shared ReadOnly Property OreDurataCookie As Integer
        Get
            Return 168 'DURATA COOKIE IMPOSTATA A 7 GIORNI
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

    Public Shared ReadOnly Property NomeCookieOkCookies As String
        Get
            Return "FormerCookieOk"
        End Get
    End Property

    Public Shared ReadOnly Property IsServerDiProduzione As Boolean
        Get
            Dim ris As Boolean = True
            Try
                Dim StringaConnessione As String = ConfigurationManager.ConnectionStrings(0).ConnectionString
                If StringaConnessione.IndexOf("former-server") <> -1 Then
                    ris = False
                End If
                'former-server

            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

    Public Shared Sub LogMe(Url As String, ExtraInfo As String)

        Try

            Dim Path As String = HttpContext.Current.Server.MapPath(_PathLog)
            Dim NomeFile As String = Now.Date.ToString("yyyyMMdd") & ".txt"
            Path &= NomeFile
            Dim Linea As String = Now.ToString("HH:mm.ss") & ";" & _
                HttpContext.Current.Request.ServerVariables("REMOTE_ADDR") & ";" & _
                HttpContext.Current.Session.SessionID & ";0(0);" & Url & ";" & ExtraInfo & ";"
            If Not HttpContext.Current.Request.Browser Is Nothing Then
                Linea &= HttpContext.Current.Request.Browser.Browser & "_" & _
                    HttpContext.Current.Request.Browser.MajorVersion & "." & _
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

    Public Shared Sub LogMe(UtenteConnesso As UtenteSito)

        Try

            Dim Path As String = HttpContext.Current.Server.MapPath(_PathLog)
            Dim NomeFile As String = Now.Date.ToString("yyyyMMdd") & ".txt"
            Path &= NomeFile
            Dim Linea As String = Now.ToString("HH:mm.ss") & ";" & _
                HttpContext.Current.Request.ServerVariables("REMOTE_ADDR") & ";" & _
                HttpContext.Current.Session.SessionID & ";" & _
                UtenteConnesso.IdUtente & "(" & UtenteConnesso.IdRubricaInt & ");" & _
                UtenteConnesso.LastPageVisited & ";" & HttpContext.Current.Request.UserAgent & ";"
            'If Not HttpContext.Current.Request.Browser Is Nothing Then
            '    Linea &= HttpContext.Current.Request.Browser.Browser & "_" & _
            '        HttpContext.Current.Request.Browser.MajorVersion & "." & _
            '        HttpContext.Current.Request.Browser.MinorVersion & ";"
            'Else
            '    Linea &= "{nobrowser};"
            'End If

            Using w As New StreamWriter(Path, True)
                w.WriteLine(Linea)
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub LogSuFileErrore(buffer As String, ErrorCode As Integer)

        Try

            Dim Path As String = HttpContext.Current.Server.MapPath(_PathLog)
            Dim NomeFile As String = Now.ToString("yyyyMMddHHmmssffff") & "-err." & ErrorCode & ".htm"
            Path &= NomeFile
            Using w As New StreamWriter(Path, True)
                w.Write(buffer)
            End Using

            'Dim Path As String = HttpContext.Current.Server.MapPath(_PathLog)
            'Dim NomeFile As String = Now.ToString("yyyyMMddHHmmssffff") & "-err.txt"
            'Path &= NomeFile
            'Using w As New StreamWriter(Path, True)
            '    w.WriteLine("#########INIZIO-ERRORE#########")
            '    Dim LineaTesta As String = Now.ToString("HH:mm.ss") & ";" & _
            '        HttpContext.Current.Request.ServerVariables("REMOTE_ADDR") & ";" & _
            '        Err.GetHttpCode & ":" & _
            '        Err.Message & ";"
            '    If Not HttpContext.Current.Request.Browser Is Nothing Then
            '        LineaTesta &= HttpContext.Current.Request.Browser.Browser & "_" & _
            '            HttpContext.Current.Request.Browser.MajorVersion & "." & _
            '            HttpContext.Current.Request.Browser.MinorVersion & ";"
            '    Else
            '        LineaTesta &= "{nobrowser};"
            '    End If
            '    w.WriteLine(LineaTesta)
            '    w.WriteLine("PATH: " & HttpContext.Current.Request.FilePath)
            '    w.Write("INNEREXCEPTION: " & Err.InnerException.Message)
            '    w.Write("STACKTRACE: " & Err.InnerException.StackTrace)
            'End Using

            ''una volta creato l'errore invio la mail
            'Try

            '    If FormerWebApp.IsDebug = False Then
            '        Dim exErr As Exception = HttpContext.Current.Session("ERROR")

            '        Dim S As String = "ATTENZIONE Errore Tipografiaformer.it"

            '        If IsServerDiProduzione = False Then
            '            S = "Errore Tipografiaformer.it SERVER INTERNO"
            '        End If

            '        Dim T As String = "<center><h4>" & HttpContext.Current.Request.FilePath & "</h4><br><a href=""https://www.tipografiaformer.it/public/log/" & NomeFile & """><b>CLICCA QUI PER IL DETTAGLIO</b></a></center><br><br>" 'exErr.ToString

            '        Dim hERr As HttpUnhandledException = New HttpUnhandledException(exErr.Message, exErr)
            '        T &= hERr.GetHtmlErrorMessage

            '        FormerHelper.Mail.InviaMail(S, T, "soft@tipografiaformer.it")

            '    End If

            'Catch ex As Exception

            'End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Shared ReadOnly Property PathListinoImg() As String
        Get
            Dim ris As String = String.Empty

            ris = ConfigurationManager.AppSettings("pathListinoImg").ToString()

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property UrlTraceGLS() As String
        Get
            Dim ris As String = String.Empty

            ris = ConfigurationManager.AppSettings("urlTraceGLS").ToString()

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property UrlTraceBartolini() As String
        Get
            Dim ris As String = String.Empty

            ris = ConfigurationManager.AppSettings("urlTraceBartolini").ToString()

            Return ris
        End Get
    End Property

    Public Shared Function GetPercIva() As Integer

        Dim ris As Integer = FormerLib.FormerHelper.Finanziarie.GetPercentualeIva '.ToInt32(ConfigurationManager.AppSettings("percIva"))
        Return ris

    End Function

    Public Shared Function GetPrezzoVerificaFile() As Decimal
        Dim ris As Decimal = Convert.ToSingle(ConfigurationManager.AppSettings("prezzoVerificaFile"))
        Return ris
    End Function



    Public Shared ReadOnly Property PathListinoTemplate() As String
        Get
            Dim ris As String = String.Empty

            ris = ConfigurationManager.AppSettings("pathListinoTemplate").ToString()

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathListinoFoto() As String
        Get
            Dim ris As String = String.Empty

            ris = ConfigurationManager.AppSettings("pathListinoFoto").ToString()

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathImgCaptcha() As String
        Get
            Dim ris As String = String.Empty

            ris = ConfigurationManager.AppSettings("pathImgCaptcha").ToString()

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathImgTemp() As String
        Get
            Dim ris As String = String.Empty

            ris = ConfigurationManager.AppSettings("pathImgTemp").ToString()

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFisicoPreventivi As String
        Get
            Dim ris As String = String.Empty
            ris = AppDomain.CurrentDomain.BaseDirectory & "\preventivi\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFisicoImg As String
        Get
            Dim ris As String = String.Empty
            ris = AppDomain.CurrentDomain.BaseDirectory & "\Img\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PresenteFileDiBlocco As Boolean
        Get

            Dim TrovatoFileBlocco As Boolean = False

            Try
                Dim PathFileBlocco As String = AppDomain.CurrentDomain.BaseDirectory & "stop.listino"
                TrovatoFileBlocco = File.Exists(PathFileBlocco)

            Catch ex As Exception

            End Try

            Return TrovatoFileBlocco

        End Get
    End Property

    Public Shared ReadOnly Property SitoInManutenzione() As Boolean
        Get
            Dim ris As Boolean = False

            ris = ConfigurationManager.AppSettings("SitoInManutenzione")

            Return ris
        End Get
    End Property
    Public Shared ReadOnly Property ClearCacheSitio() As Boolean
        Get
            Dim ris As Boolean = False

            ris = ConfigurationManager.AppSettings("ClearCache")

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property DimensioneMassimaDigitale() As Integer
        Get
            Return 150
        End Get
    End Property

    Public Shared ReadOnly Property PPSeller() As String
        Get
            Dim ris As String = String.Empty

            ris = ConfigurationManager.AppSettings("PPSeller").ToString()

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PPEntryPoint() As String
        Get
            Dim ris As String = String.Empty

            ris = ConfigurationManager.AppSettings("PPEntryPoint").ToString()

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PPOkUrl() As String
        Get
            Dim Ris As String = "https://www.tipografiaformer.it/pagamento-confermato-paypal"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PPKoUrl() As String
        Get
            Dim Ris As String = "https://www.tipografiaformer.it/pagamento-non-confermato-paypal"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IsInternetExplorer As Boolean
        Get
            Dim ris As Boolean = False
            Dim B As System.Web.HttpBrowserCapabilities = HttpContext.Current.Request.Browser
            If B.Browser = "InternetExplorer" OrElse B.Browser = "IE" Then
                ris = True
            End If
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property BrowserCompatibileSVG As Boolean
        Get
            Dim ris As Boolean = True
            Dim B As System.Web.HttpBrowserCapabilities = HttpContext.Current.Request.Browser
            If B.Browser = "InternetExplorer" Or B.Browser = "IE" Then
                If B.MajorVersion < 9 Then
                    ris = False
                End If
            End If
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property BrowserInUso As System.Web.HttpBrowserCapabilities
        Get
            Return HttpContext.Current.Request.Browser
        End Get
    End Property

    'Public Shared Function FormattaPrezzo(ByVal Val) As String
    '    Dim ris As String = Val.ToString()
    '    If Val.ToString.Length = 0 Then
    '        Val = 0
    '    Else
    '        Val = CDbl(Val)
    '    End If

    '    Try
    '        ris = Format(Val, "#,##0.00")
    '        'Return String.Format("{0:F2}", Val)
    '    Catch ex As Exception

    '    End Try

    '    Return ris
    'End Function

    'Public Shared Function FormattaNumero(ByVal Val) As String
    '    Dim ris As String = Val.ToString()
    '    If Val.ToString.Length = 0 Then
    '        Val = 0
    '    Else
    '        Val = CDbl(Val)
    '    End If

    '    Try
    '        ris = Format(Val, "#,##0")
    '        'Return String.Format("{0:F2}", Val)
    '    Catch ex As Exception

    '    End Try

    '    Return ris
    'End Function

    'Public Shared Function GetBannerRotazione() As String
    '    Dim ris As String = String.Empty

    '    'Dim l As List(Of Banner) = (New BannerDAO).Find(New LUNA.LunaSearchParameter("Attivo", 1))
    '    Dim B As New My.Templates.BannerRotazione
    '    'B.ListBanner = l
    '    ris = B.TransformText

    '    Return ris
    'End Function

    Public Class Liste
        Public Shared Function Shuffle(Of T)(collection As IEnumerable(Of T)) As List(Of T)
            Dim r As Random = New Random()
            Shuffle = collection.OrderBy(Function(a) r.Next()).ToList()
        End Function
    End Class

    Private Shared _StaticPreventivazioni As List(Of PreventivazioneW)
    Public Shared ReadOnly Property StaticPreventivazioni As List(Of PreventivazioneW)
        Get
            If _StaticPreventivazioni Is Nothing Then
                Using mgr As New PreventivazioniWDAO
                    _StaticPreventivazioni = mgr.FindAll("IdReparto, Descrizione", New LUNA.LunaSearchParameter("DispOnline", enSiNo.Si))
                End Using
            End If
            Return _StaticPreventivazioni
        End Get
    End Property

    Private Shared _StaticListiniBase As List(Of ListinoBaseW)
    Public Shared ReadOnly Property StaticListiniBase As List(Of ListinoBaseW)
        Get
            If _StaticListiniBase Is Nothing Then
                Using mgr As New ListinoBaseWDAO
                    _StaticListiniBase = mgr.ListiniUtilizzabili
                End Using
            End If
            Return _StaticListiniBase
        End Get
    End Property


    Private Shared _UseStaticCollection As enSiNo = enSiNo.NonDefinito
    Public Shared ReadOnly Property UseStaticCollection As enSiNo
        Get
            If _UseStaticCollection = enSiNo.NonDefinito Then
                Dim UseStatic As Boolean = False
                Try
                    UseStatic = ConfigurationManager.AppSettings("UseStaticCollection")
                Catch ex As Exception

                End Try

                If UseStatic Then
                    _UseStaticCollection = enSiNo.Si
                Else
                    _UseStaticCollection = enSiNo.No
                End If

            End If
            Return _UseStaticCollection
        End Get
    End Property

End Class
