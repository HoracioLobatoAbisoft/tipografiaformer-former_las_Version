Imports System.IO
Imports FormerDALWeb
Imports FormerBusinessLogic
Imports FormerLib
Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Data
Imports iTextSharp.testutils
Imports System.Globalization

Public Class pSiteMasterPage
    Inherits FormerMasterPage


    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Xml)>
    Public Shared Function cercaFunction(ByVal userText As String) As String
        Try

            'qui mi dovrebbe arrivare il cerca da parte dell'utente
            Dim valoreUtente As String = userText


            Dim tb As DataTable = New DataTable("Table")
            tb.Columns.Add("descrizione")
            tb.Columns.Add("url")
            tb.Columns.Add("img")

            tb.Rows.Add("test", "/cerca/ciao")
            tb.Rows.Add("test2", "/cerca/ciao2")
            tb.Rows.Add("test3", "/cerca/ciao3")

            Dim setR As DataSet = New DataSet("ricerca")
            setR.Tables.Add(tb)
            Dim ris As String = setR.GetXml
            Return ris
            'Return (ds.GetXml())
        Catch
            Return Nothing
        End Try
    End Function


    Public Function getNominativoUtente() As String

        Dim ris As String = String.Empty

        ris = Server.HtmlEncode(UtenteConnesso.Nominativo)

        If ris.Length > 25 Then
            ris = ris.Substring(0, 25) & "..."
        End If

        Return ris

    End Function

    Public Function GetSpecificDescription(Optional ConVirgolette As Boolean = True) As String

        Dim Ris As String = String.Empty
        Dim InsideContent As Boolean = False

        If TypeOf body.Page Is IFormerWizardPage Then

            Dim P As IFormerWizardPage = body.Page
            Ris = P.OgDescription
            If Ris.Length Then InsideContent = True

        End If

        If InsideContent = False Then
            Ris = FormerWebApp.MetaDescription
        End If

        If ConVirgolette Then
            Ris = """" & Ris & """"
        End If

        Return Ris

    End Function

    Public Function GetSpecificKeywords(Optional ConVirgolette As Boolean = True) As String

        Dim ris As String = String.Empty
        Dim InsideContent As Boolean = False


        If TypeOf body.Page Is IFormerWizardPage Then

            Dim P As IFormerWizardPage = body.Page
            ris = P.OgKeywords
            If ris.Length Then
                InsideContent = True
            End If

        End If

        If InsideContent = False Then
            ris = "Tipografia Former,Tipografia, Tipografia Roma, Stampa Offset, Stampa Digitale, Packaging, Ricamo"

            'ora se qui la content page mi fornisce keyword specifiche prendo le sue altrimenti aggiungo i  nomi di tutte le preventivazioni 

            ris &= ", " & Application("SpecificKeywords")

        End If

        If ConVirgolette Then
            ris = """" & ris & """"
        End If

        Return ris

    End Function

    Public ReadOnly Property ShowCookieMessage As Boolean
        Get
            Dim ris As Boolean = True
            If Not Request.Cookies(FormerWebApp.NomeCookieOkCookies) Is Nothing Then
                ris = False
            End If
            Return ris
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'cercaFunction("ITextTest")
        'Response.Cache.SetExpires(DateTime.Now.AddSeconds(1))
        'Response.Cache.SetCacheability(HttpCacheability.Public)
        'Response.Cache.SetValidUntilExpires(True)

        If Not Session("Carrello") Is Nothing Then
            Dim C As Carrello = Session("Carrello")

            If C.Ordini.Count Then
                lblTotOrdCarrello.Text = C.Ordini.Count
                lblTotOrdCarrello.Visible = True
            Else
                lblTotOrdCarrello.Visible = False
            End If
        End If

        If Not IsPostBack Then
            'carico le notifiche 
            If UtenteConnesso.IdUtente Then



                Dim TotOrd As Integer = Notifica.NumeroNotifiche
                If TotOrd Then
                    lblNotifiche.Text = TotOrd
                    lblNotifiche.Visible = True
                Else
                    lblNotifiche.Visible = False
                End If
            End If
        End If
        Dim UrlIndex As String = "http://localhost:5173/#/"
        'Dim UrlIndex As String = "https://react.tipografiaformertest.it:6060/#/form-prodotto-v2/2/131/72/1/1/1684/0/0/0/0"
        iframeIndexReact.Text = "<iframe id='iframeIndex2' src=" & UrlIndex & " hidden></iframe>"
        'If UtenteConnesso.IdUtente = 1684 Then
        '    Dim Differenza As Integer
        '    Using mgr As New ListiniUtenteWDAO
        '        Dim lLis As List(Of ListinoUtenteW) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoUtenteW.IdUt, UtenteConnesso.IdUtente))
        '        Dim ListinoUtente As ListinoUtenteW = lLis(0)
        '        Differenza = DateDiff(DateInterval.Minute, ListinoUtente.UltimaGenerazione, FormerWebApp.DataUltimaPubblicazioneListino)
        '    End Using
        '    Dim UrlCerca As String = "http://localhost:5173/#/cerca/" & UtenteConnesso.IdUtente & "/" & Differenza
        '    iframeCerca.Text = "<iframe  style='width:100%; height:100%;border: none;overflow-y:hidden;position:relative;' src=" & UrlCerca & " ></iframe>"
        'End If

        'FormerWebApp.FormerScriptManager = ScriptManagerFormer

    End Sub

    Protected Sub lnkEsci_Click(sender As Object, e As EventArgs) Handles lnkEsci.Click
        DirectCast(Page, FormerPage).TerminaSessioneLavoro()
    End Sub

    Protected ReadOnly Property BufferAutoComplete As String

        '    {
        '        value: "registrati",
        '        url: "/registrati"
        '    },
        '    {
        '        value: "login",
        '        url: "/login"
        '    },
        '    {
        '        value: "area riservata",
        '        url: "/area-riservata"
        '    }

        Get
            Dim ris As String = ""

            If FormerWebApp.SitoInManutenzione = False Then
                If Request.Url.AbsolutePath.IndexOf("manutenzione") = -1 Then
                    ris = Application("BufferAutoComplete")
                    'If Application("BufferAutoComplete") Is Nothing Then
                    '    'qui lo calcolo e lo valorizzo

                    '    Dim lstL As List(Of ListinoBaseW)

                    '    Using LMgr As New ListinoBaseWDAO

                    '        lstL = LMgr.ListiniPerCerca()
                    '        lstL.Sort(Function(x, y) x.Nome.CompareTo(y.Nome))

                    '        For Each li As ListinoBaseW In lstL
                    '            Dim NomeVoce As String = String.Empty
                    '            Dim UrlVoce As String = String.Empty
                    '            Dim imgPrev As String = String.Empty

                    '            NomeVoce = li.Nome
                    '            UrlVoce = "/" & li.IdPrev & "/" & li.IdFormProd & "/" & li.IdTipoCarta & "/" & li.IdColoreStampa & "/" & li.NomeInUrl

                    '            'Dim P As New PreventivazioneW
                    '            'P.Read(li.IdPrev)
                    '            'imgPrev = "<img src=""" & FormerWebApp.PathListinoImg & P.ImgRif & """ width=16 />"
                    '            'P = Nothing


                    '            ris &= "{ value: """ & NomeVoce & """, url: """ & UrlVoce & """, img: """ & imgPrev & """},"
                    '        Next
                    '        ris = ris.TrimEnd(",")
                    '        Application.Lock()
                    '        Application("BufferAutoComplete") = ris
                    '        Application.UnLock()

                    '    End Using

                    'Else
                    '    ris = Application("BufferAutoComplete")
                    'End If
                End If

            End If

            Return ris

        End Get
    End Property

    Private Sub btnCerca_Click(sender As Object, e As ImageClickEventArgs) Handles btnCerca.Click

        'eseguoo il cerca

        Dim TestoToSearch As String = txtCerca.Text
        If TestoToSearch.Trim.Length > 1 Then

            TestoToSearch = FormerSearchEngine.EncryptRichiesta(TestoToSearch)

            Response.Redirect("/cerca/" & TestoToSearch)
        Else
            Response.Redirect("/")
        End If

    End Sub

    Private Sub lnkRegisterNewsletter_Click(sender As Object, e As EventArgs) Handles lnkRegisterNewsletter.Click

        Dim Ris As String = String.Empty
        Dim EmailRif As String = txtRegisterNewsletter.Text

        If txtRegisterNewsletter.Text.Trim.Length = 0 Then
            Ris = "Inserire l'indirizzo Email!"
        Else
            If FormerHelper.Mail.IsValidEmailAddress(EmailRif) = False Then
                Ris = "L'indirizzo Email non sembra corretto!"
            Else
                If chkNewsletter.Checked = False Then
                    Ris = "Consentire il trattamento dei dati!"
                End If
            End If
        End If

        If Ris.Length Then
            'Ris = "<b style=""color:red;"">ATTENZIONE</b> " & Ris & "" '
            'qui c'e' stato un errore di validazione 

            lblErrore.Text = Ris

            'qui devo fare una insert nella page per chiamare la funzione 
            ScriptManager.RegisterStartupScript(UpdpnlNewsl, UpdpnlNewsl.GetType(), "ShowNewsletter", "NewsletterFissa();", True)

        Else
            lblErrore.Text = String.Empty

            Dim Pt As New My.Templates.MailIscrizioneNewsletter
            Pt.Email = EmailRif
            Dim Buffer As String = Pt.TransformText

            Try
                FormerHelper.Mail.InviaMail("Richiesta di iscrizione alla Newsletter", Buffer, EmailRif)
            Catch ex As Exception

            End Try

            'inviare mail di registrazione newsletter

            Response.Redirect("/richiesta-iscrizione-newsletter")
        End If


    End Sub

    Public ReadOnly Property MostraNewsletter As Boolean
        Get
            Dim ris As Boolean = False

            If UtenteConnesso.IdUtente = 0 Then
                'qui controllo le pagine in cui non voglio che appaia
                If Request.Url.ToString().IndexOf("iscrizione-newsletter") = -1 And _
                    Request.Url.ToString().EndsWith("/registrati") = False Then

                    ris = True

                End If

            End If

            Return ris
        End Get
    End Property

    Private Sub lnkCookieOk_Click(sender As Object, e As EventArgs) Handles lnkCookieOk.Click

        'qui salvo il cookie e rivado in home page
        Dim myCookie As HttpCookie = New HttpCookie(FormerWebApp.NomeCookieOkCookies)
        myCookie.Value = "ok"
        myCookie.Expires = Now.AddYears(1)
        Response.Cookies.Add(myCookie)

        Response.Redirect("/")

    End Sub
End Class