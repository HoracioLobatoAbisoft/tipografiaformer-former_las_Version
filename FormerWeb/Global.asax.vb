Imports System.Web.SessionState
Imports System.Web.Routing
Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerLib

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        RegisterRoutes(RouteTable.Routes)

        Dim Pericoli As New List(Of String)
        Application("Pericoli") = Pericoli

        If LUNA.LunaContext.IsOkDbConnection Then
            'Dim lP As List(Of PreventivazioneW) = Nothing
            'Using mgr As New PreventivazioniWDAO
            '    lP = mgr.FindAll("IdReparto, Descrizione",
            '                     New LUNA.LunaSearchParameter("DispOnline", enSiNo.Si))
            '    'Application.Lock()
            '    'Application("ListaPreventivazioni") = lP
            '    'Application.UnLock()
            'End Using

            Dim lLb As List(Of ListinoBaseW) = Nothing
            If FormerWebApp.UseStaticCollection = enSiNo.Si Then
                lLb = FormerWebApp.StaticListiniBase
            Else
                Using mgr As New ListinoBaseWDAO
                    lLb = mgr.ListiniUtilizzabili
                End Using
            End If

            'KEYWORD PER LE PAGINE
            Dim buffer As String = String.Empty

            Dim lP As List(Of PreventivazioneW) = Nothing
            If FormerWebApp.UseStaticCollection = enSiNo.Si Then
                lP = FormerWebApp.StaticPreventivazioni
            Else
                Using mgr As New PreventivazioniWDAO
                    lP = mgr.FindAll("IdReparto, Descrizione",
                                     New LUNA.LunaSearchParameter("DispOnline", enSiNo.Si))
                End Using
            End If

            For Each p As PreventivazioneW In lP
                buffer &= p.Descrizione & ", "
            Next

            buffer = buffer.TrimEnd(" ", ",")

            Application.Lock()
            Application("SpecificKeywords") = buffer
            Application.UnLock()

            'BUFFER AUTO COMPLETE PER IL CERCA
            Dim bufferAC As String = String.Empty
            'lLb.Sort(Function(x, y) x.Nome.CompareTo(y.Nome))

            For Each li As ListinoBaseW In lLb
                Dim NomeVoce As String = String.Empty
                Dim UrlVoce As String = String.Empty
                Dim imgPrev As String = String.Empty

                NomeVoce = li.Nome
                UrlVoce = FormerUrlCreator.GetUrl(li.IdPrev, li.IdFormProd, li.IdTipoCarta, li.IdColoreStampa) '"/" & li.IdPrev & "/" & li.IdFormProd & "/" & li.IdTipoCarta & "/" & li.IdColoreStampa & "/" & li.NomeInUrl
                imgPrev = FormerWebApp.PathListinoImg & li.GetImgFormato
                bufferAC &= "{ value: """ & NomeVoce & """, url: """ & UrlVoce & """, img: """ & imgPrev & """},"
            Next
            bufferAC = bufferAC.TrimEnd(",")

            Application.Lock()
            Application("BufferAutoComplete") = bufferAC
            Application.UnLock()

            Using mgr As New PreventivazioniWDAO
                Dim l As List(Of PreventivazioneW) = mgr.FindAll(New LUNA.LunaSearchParameter("DispOnline", enSiNo.Si),
                                                                 New LUNA.LunaSearchParameter("PercCoupon", 0, "<>"))
                Application.Lock()
                If l.Count Then
                    Application("MostraOfferte") = True
                Else
                    Application("MostraOfferte") = False
                End If
                Application.UnLock()
            End Using

            ''LISTINI BASE RANDOM
            'Dim lRandom As List(Of ListinoBaseW) = lLb.FindAll(Function(x) x.FormatoProdotto.ProdottoFinito = True)

            'Application.Lock()
            'Application("ListiniBaseRandom") = lRandom
            'Application.UnLock()

            lP = Nothing
            lLb = Nothing
        Else
            HttpContext.Current.Response.Redirect("/manutenzione")
        End If

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
        If LUNA.LunaContext.IsOkDbConnection = False Then
            '    Dim Buffer As String = String.Empty
            '    Dim PathFileBanner As String = AppDomain.CurrentDomain.BaseDirectory & "banner.inc"

            '    If File.Exists(PathFileBanner) Then
            '        Using reader As New StreamReader(PathFileBanner)
            '            Buffer = reader.ReadToEnd
            '            If Buffer.IndexOf(FormerLib.FormerHelper.Security.GetSecurityCheckForExternalResources) Then
            '                'file ok
            '                Buffer = Buffer.Replace(FormerLib.FormerHelper.Security.GetSecurityCheckForExternalResources, String.Empty)
            '            Else
            '                Buffer = String.Empty
            '            End If
            '        End Using
            '    End If
            '    Session("GetBannerRotazione") = Buffer
            'Else
            Response.Redirect("/manutenzione")
        End If

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        If FormerWebApp.IsDebug = False Then
            Dim redirectUrl As String = "/"
            Try
                Dim err As Exception = Server.GetLastError()
                Dim hErr As HttpUnhandledException = New HttpUnhandledException(err.Message, err)

                Dim Pericolo As Boolean = False

                If hErr.Message.ToLower.IndexOf("dangerous") <> -1 OrElse
                    hErr.Message.ToLower.IndexOf("maxurllength") <> -1 Then
                    Pericolo = True
                End If

                Dim IpRiferimento As String = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
                'PREPARO IL LOG 
                Dim LogErrore As String = Now.ToString("HH:mm.ss") & ";" &
                IpRiferimento & ";" & hErr.GetHttpCode & ":" & hErr.Message & ";"
                If Not HttpContext.Current.Request.Browser Is Nothing Then
                    LogErrore &= HttpContext.Current.Request.Browser.Browser & "_" &
                        HttpContext.Current.Request.Browser.MajorVersion & "." &
                        HttpContext.Current.Request.Browser.MinorVersion & ";"
                Else
                    LogErrore &= "{nobrowser};"
                End If

                LogErrore &= "<br>PATH: " & HttpContext.Current.Request.FilePath
                LogErrore &= "<br>EXCEPTION: " & hErr.Message
                LogErrore &= "<br>EXCEPTION STACKTRACE: " & hErr.StackTrace

                Dim except As System.Exception = hErr.InnerException
                Dim countEx As Integer = 1

                Try
                    Do Until except Is Nothing

                        LogErrore &= "<br>INNER EXCEPTION (" & countEx & "): " & except.Message
                        LogErrore &= "<br>INNER EXCEPTION (" & countEx & ") STACKTRACE: " & except.StackTrace.Replace(" in ", "<br>in ")

                        except = except.InnerException

                        countEx += 1
                    Loop
                Catch ex As Exception

                End Try

                FormerWebApp.LogSuFileErrore(LogErrore, hErr.GetHttpCode)

                'FormerWebApp.DbError = False

                'Session("DbError") = False
                If LUNA.LunaContext.IsOkDbConnection = False Then
                    'FormerWebApp.DbError = True
                    redirectUrl = "/manutenzione"
                    Dim Subject As String = "Eccezione dal sito DB non raggiungibile"
                    FormerLib.FormerHelper.Mail.InviaMail(Subject, LogErrore, FormerConst.EmailAssistenzaTecnica)
                Else
                    If hErr.GetHttpCode <> 404 Then
                        redirectUrl = "/opsss"

                        If FormerWebApp.IsCrawler(Request.UserAgent.ToLower) = False Then
                            Try
                                'MI INVIO UNA MAIL 
                                Dim Subject As String = "Eccezione dal sito"
                                If FormerWebApp.IsServerDiProduzione = False Then
                                    Subject = "Errore Tipografiaformer.it SERVER INTERNO"
                                End If

                                FormerLib.FormerHelper.Mail.InviaMail(Subject, LogErrore, FormerConst.EmailAssistenzaTecnica)

                            Catch ex As Exception

                            End Try
                        End If

                        If Pericolo Then

                            Try

                                If Application("Pericoli") Is Nothing Then
                                    Dim Pericoli As New List(Of String)
                                    Application("Pericoli") = Pericoli
                                End If
                            Catch ex As Exception

                            End Try

                            DirectCast(Application("Pericoli"), List(Of String)).Add(IpRiferimento)

                            If DirectCast(Application("Pericoli"), List(Of String)).FindAll(Function(x) x = IpRiferimento).Count > 5 Then
                                'BANNO L'IP 
                                Using b As New IpBan
                                    b.IpToBan = IpRiferimento
                                    b.Quando = Now
                                    b.Save()
                                End Using 'BYE BYE

                                Try
                                    DirectCast(Application("Pericoli"), List(Of String)).RemoveAll(Function(x) x = IpRiferimento)
                                    FormerLib.FormerHelper.Mail.InviaMail("Bannato IP " & IpRiferimento, LogErrore, FormerConst.EmailAssistenzaTecnica)
                                Catch ex As Exception

                                End Try

                            End If
                        End If

                    End If

                End If

                Server.ClearError()

                Try
                    HttpContext.Current.Session.Abandon()
                Catch ex As Exception

                End Try

                'disattivato per non resettare l'application pool di tutti
                Try
                    'HttpRuntime.Close()

                Catch ex As Exception

                End Try

            Catch ex As Exception

                Dim message As String = ex.Message

            End Try

            HttpContext.Current.Response.Redirect(redirectUrl)
        End If
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

    Shared Sub RegisterRoutes(routes As RouteCollection)

        routes.Ignore("{*allaspx}", New With {Key .allaspx = ".*\.aspx(/.*)?"})

        'GENERICS
        routes.MapPageRoute("WebFormDefault", "", "~/default.aspx")
        routes.MapPageRoute("errore", "opsss", "~/error.aspx")
        routes.MapPageRoute("manutenzione", "manutenzione", "~/manutenzione.aspx")
        'routes.MapPageRoute("guidanuovosito", "dal-vecchio-al-nuovo-sito", "~/pagetext/guidanuovosito/guidanuovosito.aspx")
        routes.MapPageRoute("parcomacchine", "il-nostro-parco-macchine", "~/page/parcomacchine.aspx")
        routes.MapPageRoute("comeinviarcifile", "suggerimenti-per-inviarci-i-file", "~/pagetext/inviofile/inviofile.aspx")

        'UNSUBSCRIBE
        routes.MapPageRoute("unsubscribe", "unsubscribe/{email}", "~/page/unsubscribe.aspx")
        routes.MapPageRoute("unsubscribeOK", "unsubscribe-registrato", "~/page/unsubscribeOk.aspx")

        'NEWSLETTER
        routes.MapPageRoute("RegistrazioneNewsletter", "richiesta-iscrizione-newsletter", "~/page/registrazionenewsletter.aspx")
        routes.MapPageRoute("RegistrazioneNewsletterEsito", "iscrizione-newsletter/{email}", "~/page/regNewsletter.aspx")

        'AREA RISERVATA
        routes.MapPageRoute("Login", "login", "~/page/login.aspx")
        routes.MapPageRoute("Registrati", "registrati", "~/page/register.aspx")
        routes.MapPageRoute("Privacy", "privacy", "~/pagetext/privacy.aspx")
        routes.MapPageRoute("RegistrazioneOk", "registrazione-effettuata", "~/page/registrazioneok.aspx")
        routes.MapPageRoute("rigenera-pwd", "rigenera-password/{email}", "~/page/rigpwd.aspx")

        routes.MapPageRoute("area-riservata", "area-riservata", "~/page/areariservata.aspx")
        routes.MapPageRoute("i-tuoi-dati", "i-tuoi-dati", "~/page/datiutente.aspx")
        routes.MapPageRoute("aggiorna-dati-fiscali", "aggiorna-dati-fiscali", "~/page/datifiscali.aspx")
        routes.MapPageRoute("Webmaster", "webmaster", "~/page/webmaster.aspx")
        routes.MapPageRoute("le-tuoe-fatture", "le-tue-fatture", "~/page/fatture.aspx")

        routes.MapPageRoute("i-tuoi-lavori", "i-tuoi-lavori", "~/page/lavori.aspx")
        routes.MapPageRoute("i-tuoi-ordini", "i-tuoi-ordini", "~/page/ordini.aspx")
        routes.MapPageRoute("ordine-confermato", "ordine-confermato", "~/page/ordineconfermato.aspx")
        routes.MapPageRoute("i-tuoi-coupon-di-sconto", "i-tuoi-coupon-di-sconto", "~/page/ituoicoupon.aspx")
        routes.MapPageRoute("offerte-e-promozioni", "offerte-e-promozioni", "~/page/offerte.aspx")
        routes.MapPageRoute("offerte-e-promozioni-in-corso", "offerte-e-promozioni-in-corso", "~/pagetext/offerteepromozioni.aspx")

        routes.MapPageRoute("le-tue-recensioni", "le-tue-recensioni", "~/page/letuerecensioni.aspx")
        routes.MapPageRoute("recensioni", "recensioni", "~/page/recensioni.aspx")

        routes.MapPageRoute("indirizzi-spedizione", "indirizzi-spedizione", "~/page/indirizzosped.aspx")
        routes.MapPageRoute("aggiungi-indirizzo", "aggiungi-indirizzo", "~/page/newInd.aspx")
        routes.MapPageRoute("richiedi-campione", "richiedi-un-campione-gratuito", "~/page/richiediCampione.aspx")
        routes.MapPageRoute("campione-ok", "richiesta-campione-gratuito-registrata", "~/page/CampioneOk.aspx")
        routes.MapPageRoute("dettagliolavoro", "{idl}/dettaglio-lavoro", "~/page/dettaglioLavoro.aspx", True, New RouteValueDictionary() From {{"idl", "\d{1,}"}})
        routes.MapPageRoute("dettaglioordine", "{ido}/dettaglio-ordine", "~/page/dettaglioOrdine.aspx", True, New RouteValueDictionary() From {{"ido", "\d{1,}"}})

        'PREVENTIVI
        routes.MapPageRoute("richiedi-preventivo", "{idl}/richiedi-preventivo", "~/page/richiedipreventivo.aspx", True, New RouteValueDictionary() From {{"idl", "\d{1,}"}})
        routes.MapPageRoute("richiesta-di-preventivo-presa-in-carico", "richiesta-di-preventivo-presa-in-carico", "~/page/richiestapreventivoOk.aspx")

        'MONDO FORMER
        routes.MapPageRoute("ilmondoformer", "il-mondo-former", "~/pagetext/ilmondoformer.aspx")
        routes.MapPageRoute("nostraazienda", "la-nostra-azienda", "~/pagetext/lanostraazienda.aspx")
        routes.MapPageRoute("mondoformer1", "mondo-former/stampa-tipografica-offset", "~/pagetext/mondoformer/stampatipografica.aspx")
        routes.MapPageRoute("mondoformer2", "mondo-former/ricamo", "~/pagetext/mondoformer/ricamo.aspx")
        routes.MapPageRoute("mondoformer3", "mondo-former/stampa-digitale", "~/pagetext/mondoformer/stampadigitale.aspx")
        routes.MapPageRoute("mondoformer4", "mondo-former/packaging", "~/pagetext/mondoformer/packaging.aspx")

        routes.MapPageRoute("lavorazioni", "le-nostre-lavorazioni", "~/pagetext/elencolavorazioni.aspx")
        routes.MapPageRoute("carte", "i-tipi-di-carta", "~/pagetext/elencocarte.aspx")
        routes.MapPageRoute("diventa-rivenditore", "diventa-rivenditore", "~/pagetext/diventariv.aspx")

        'ASSISTENZA
        routes.MapPageRoute("assistenza", "assistenza-clienti", "~/assistenza/faq.aspx")

        'routes.MapPageRoute("contattaci", "{ida}/{idd}/contattaci", "~/assistenza/contattaci.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"ida", "\d{1,}"}}, New RouteValueDictionary() From {{"idd", "\d{1,}"}})
        'routes.MapPageRoute("esitoAssistenza", "{ris}-esito-richiesta/", "~/assistenza/ris.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"ris", "\d{1,}"}})
        routes.MapPageRoute("guida-ordine", "come-effettuare-un-ordine", "~/pagetext/guidaOrdine.aspx")
        Dim RGloss As New Route("glossario-tipografico", New PageRouteHandler("~/assistenza/faq.aspx"))
        RGloss.DataTokens = New RouteValueDictionary() From {{"isGlossario", True}}
        routes.Add(RGloss)

        Dim RFaq As New Route("domande-e-risposte-frequenti", New PageRouteHandler("~/assistenza/faq.aspx"))
        RFaq.DataTokens = New RouteValueDictionary() From {{"isFaq", True}}
        routes.Add(RFaq)

        'WIZARD
        routes.MapPageRoute("wizardFormato", "{idp}/{descrizione}", "~/formatoW.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}})
        routes.MapPageRoute("wizardCarta", "{idp}/{idf}/{descrizione}", "~/cartaW.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}, {"idf", "\d{1,}"}})
        routes.MapPageRoute("wizardColori", "{idp}/{idf}/{idc}/{descrizione}", "~/coloriW.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}, {"idf", "\d{1,}"}, {"idc", "\d{1,}"}})
        routes.MapPageRoute("wizardFogli", "{idp}/{idf}/{idc}/{ids}/{descrizione}", "~/fogliW.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}, {"idf", "\d{1,}"}, {"idc", "\d{1,}"}, {"ids", "\d{1,}"}})
        routes.MapPageRoute("wizardProdotto", "{idp}/{idf}/{idc}/{ids}/{nfogli}/{descrizione}", "~/prodotto.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}, {"idf", "\d{1,}"}, {"idc", "\d{1,}"}, {"ids", "\d{1,}"}, {"nfogli", "\d{1,}"}})
        routes.MapPageRoute("wizardCategoriaFormato", "scegli-formato/{idp}/{idc}/{descrizione}", "~/selFormato.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}, {"idc", "\d{1,}"}})
        routes.MapPageRoute("wizardCategoriaVirtuale", "in-evidenza/{idc}/{descrizione}", "~/selCatVirtuale.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idc", "\d{1,}"}})
        'CERCA
        'routes.MapPageRoute("cerca", "cerca", "~/page/search.aspx")
        routes.MapPageRoute("cercaRis", "cerca/{keywords}", "~/page/searchRis.aspx")

        'DOCUMENTO FISCALE scarica-documento-fiscale
        routes.MapPageRoute("scaricaDocFisc", "scarica-documento-fiscale/{chiave}", "~/page/scaricaDocFisc.aspx")

        'PLUGIN
        routes.MapPageRoute("crea-ricamo", "ricamo/crea-ricamo", "~/pageplugin/crearicamo.aspx")
        routes.MapPageRoute("pluginPackaging", "packaging/{idp}/inserisci-dimensioni", "~/pageplugin/packaging/misurepackaging.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}})
        routes.MapPageRoute("pluginEtichetteStep1", "etichette/{idp}/scegli-categoria-etichette", "~/pageplugin/etichette/etichetteCat.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}})
        routes.MapPageRoute("pluginEtichetteStep2", "etichette/{idp}/{idc}/inserisci-dimensioni", "~/pageplugin/etichette/etichette.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}}, New RouteValueDictionary() From {{"idc", "\d{1,}"}})
        routes.MapPageRoute("pluginEtichetteCm", "etichette-cm/{idp}/scegli-categoria-etichette", "~/pageplugin/etichette/etichetteCm.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}})
        routes.MapPageRoute("pluginPackagingCuscino", "packaging-a-cuscino/{idp}/inserisci-dimensioni", "~/pageplugin/packagingEx1/misurepackaging.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}})

        'CARRELLO
        routes.MapPageRoute("carrello1Click", "compra-1-click", "~/page/carrello/carrelloRiepilogo.aspx")
        routes.MapPageRoute("carrello", "carrello", "~/page/carrello/carrello.aspx")
        routes.MapPageRoute("carrelloConsegna", "carrello-consegna", "~/page/carrello/carrelloConsegna.aspx")
        routes.MapPageRoute("carrelloFile", "carrello-file", "~/page/carrello/carrelloFile.aspx")
        routes.MapPageRoute("carrelloPagamento", "carrello-pagamento", "~/page/carrello/carrelloPagamento.aspx")
        routes.MapPageRoute("carrelloRiepilogo", "carrello-riepilogo", "~/page/carrello/carrelloRiepilogo.aspx")

        'PAYPAL
        routes.MapPageRoute("ppOk", "pagamento-confermato-paypal", "~/page/paypal/ppEndOK.aspx")
        routes.MapPageRoute("ppKo", "pagamento-non-confermato-paypal", "~/page/paypal/ppEndKO.aspx")

        'BANCASELLA
        routes.MapPageRoute("bsOk", "pagamento-confermato-carta-di-credito", "~/page/gestpay/bsEndOK.aspx")
        routes.MapPageRoute("bsKo", "pagamento-non-confermato-carta-di-credito", "~/page/gestpay/bsEndKO.aspx")

        'GOTO
        routes.MapPageRoute("goto", "goto/{id}", "~/page/goto.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"id", "\d{1,}"}})

        'REPARTI HOME

        routes.MapPageRoute("promo", "promo", "~/page/promo.aspx")
        routes.MapPageRoute("appIframe", "appIframe", "~/page/appIframe.aspx")

        Dim ROff As New Route("stampa-offset", New PageRouteHandler("~/default.aspx"))
        ROff.DataTokens = New RouteValueDictionary() From {{"idR", enRepartoWeb.StampaOffset}}
        routes.Add(ROff)

        Dim RDig As New Route("stampa-digitale", New PageRouteHandler("~/default.aspx"))
        RDig.DataTokens = New RouteValueDictionary() From {{"idR", enRepartoWeb.StampaDigitale}}
        routes.Add(RDig)

        Dim Rpack As New Route("packaging", New PageRouteHandler("~/default.aspx"))
        Rpack.DataTokens = New RouteValueDictionary() From {{"idR", enRepartoWeb.Packaging}}
        routes.Add(Rpack)

        Dim REtich As New Route("etichette", New PageRouteHandler("~/default.aspx"))
        REtich.DataTokens = New RouteValueDictionary() From {{"idR", enRepartoWeb.Etichette}}
        routes.Add(REtich)

        Dim RRicamo As New Route("ricamo", New PageRouteHandler("~/default.aspx"))
        RRicamo.DataTokens = New RouteValueDictionary() From {{"idR", enRepartoWeb.Ricamo}}
        routes.Add(RRicamo)

        'routes.MapPageRoute("ricamo", "ricamo", "~/pagetext/mondoformer/ricamo.aspx")

        'ROTTA DISATTIVATA PERCHE PER ORA NON GESTIAMO IL RICAMO
        'Dim RRic As New Route("ricamo", New PageRouteHandler("~/default.aspx"))
        'RRic.DataTokens = New RouteValueDictionary() From {{"idR", enRepartoWeb.Ricamo}}
        'routes.Add(RRic)

        'routes.MapPageRoute("repartoHome", "{reparto}", "~/default.aspx")

        'routes.Ignore("{*allpdf}", New With {Key .allpdf = ".*\.pdf(/.*)?"})

        'RSS

        'MOBILE

        If FormerConfig.FConfiguration.Environment.EnableMobile Then
            FormerWeb.FormerWebApp.MobileRouteRegeX.Add("^\/m\/$")
            routes.MapPageRoute("mobile", "m", "~/mobile/default.m.aspx")
            FormerWeb.FormerWebApp.MobileRouteRegeX.Add("^\/m\/([0-9]){1,6}\/([0-9]){1,6}\/([0-9]){1,6}\/([0-9]){1,6}\/([0-9]){1,6}\/(([A-Za-z0-9\-]){1,100})$")
            routes.MapPageRoute("wizardProdottoM", "m/{idp}/{idf}/{idc}/{ids}/{nfogli}/{descrizione}", "~/mobile/prodotto.m.aspx", True, New RouteValueDictionary() From {}, New RouteValueDictionary() From {{"idp", "\d{1,}"}, {"idf", "\d{1,}"}, {"idc", "\d{1,}"}, {"ids", "\d{1,}"}, {"nfogli", "\d{1,}"}})
            FormerWeb.FormerWebApp.MobileRouteRegeX.Add("^\/m\/i-tuoi-ordini$")
            routes.MapPageRoute("ordiniM", "m/i-tuoi-ordini", "~/mobile/ordini.m.aspx")
            FormerWeb.FormerWebApp.MobileRouteRegeX.Add("^\/m\/login$")
            routes.MapPageRoute("loginM", "m/login", "~/mobile/login.m.aspx")
        End If

        routes.MapPageRoute("rss", "rss", "~/pagerss/getRssPreventivazioni.aspx")
        routes.MapPageRoute("rssOfferte", "rss-offerte", "~/pagerss/getRssOfferte.aspx")

    End Sub

End Class