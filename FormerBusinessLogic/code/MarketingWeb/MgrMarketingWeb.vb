Imports System.IO
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerConfig

Public Class MgrMarketingWeb

    Public Shared Property PathTarget As String = String.Empty
    Public Shared Property NomeFile As String = String.Empty

    Public Shared Function CreaNewsletterSuFileHtml(PathHtmlSource As String,
                                                    Optional CreateGoto As Boolean = False) As String

        Dim RisPath As String = String.Empty

        Try
            Dim PathRis As String = PathTarget

            If NomeFile.Length Then
                PathRis &= NomeFile
            Else
                PathRis &= FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")
            End If

            Dim risFinale As String = String.Empty

            Using r As New StreamReader(PathHtmlSource)
                risFinale = r.ReadToEnd()
            End Using

            Dim posiz As Integer = 0
            Dim posizFine As Integer = 0

            posiz = risFinale.IndexOf("<body")

            posizFine = risFinale.IndexOf(">", posiz)

            risFinale = risFinale.Substring(posizFine + 1)

            posiz = risFinale.IndexOf("</body>")

            risFinale = risFinale.Substring(0, posiz)

            risFinale = risFinale.Replace("<TABLE", "<table")
            risFinale = risFinale.Replace("<TR", "<tr")
            risFinale = risFinale.Replace("<TD", "<td")
            risFinale = risFinale.Replace("<DIV", "<div")
            risFinale = risFinale.Replace("<P ", "<p ")
            risFinale = risFinale.Replace("<A ", "<a ")
            risFinale = risFinale.Replace("<STRONG>", "<strong>")
            risFinale = risFinale.Replace("<IMG", "<img")
            risFinale = risFinale.Replace("</TABLE", "</table")
            risFinale = risFinale.Replace("</TR", "</tr")
            risFinale = risFinale.Replace("</TD", "</td")
            risFinale = risFinale.Replace("</DIV", "</div")
            risFinale = risFinale.Replace("</P>", "</p>")
            risFinale = risFinale.Replace("</A>", "</a>")
            risFinale = risFinale.Replace("</STRONG>", "</strong>")

            'qui vanno riviste le immagini 
            Dim TagImg As String = "src=""http://www.tipografiaformer.it/emailattach/"
            risFinale = risFinale.Replace("src=""./", TagImg)

            posiz = risFinale.IndexOf(TagImg)

            Dim ImgList As New List(Of String)

            While posiz <> -1

                Dim posizFineJpg As Integer = risFinale.ToLower.IndexOf("jpg", posiz)
                Dim posizFinePng As Integer = risFinale.ToLower.IndexOf("png", posiz)

                If posizFineJpg < posizFinePng AndAlso posizFineJpg <> -1 Then
                    posizFine = posizFineJpg + 3
                Else
                    posizFine = posizFinePng + 3
                End If

                Dim NomeImg As String = risFinale.Substring(posiz + TagImg.Length, posizFine - (posiz + TagImg.Length))

                'risFinale &= "#" & NomeImg & "#"

                ImgList.Add(NomeImg)

                posiz = risFinale.IndexOf(TagImg, posiz + 1)

            End While

            'qui devo aggiungere header and footer 
            Dim Header As String = "<table style=""WIDTH: 616px; MARGIN: 0px auto"" cellSpacing=0 cellPadding=0 width=616 align=center border=0><tr><td style=""BORDER-TOP: #dbdbdb 1px solid; BORDER-BOTTOM: #dbdbdb 1px solid; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; BORDER-LEFT: #dbdbdb 1px solid; PADDING-RIGHT: 0px; BACKGROUND-COLOR: #feffff""><a href=""http://www.tipografiaformer.it""><img src=""http://www.tipografiaformer.it/img/logo.png"" style=""padding:10px;"" border=0></a></td>"
            Header &= "<td style=""BORDER-TOP: #dbdbdb 1px solid; BORDER-RIGHT: #dbdbdb 1px solid; BORDER-BOTTOM: #dbdbdb 1px solid; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BACKGROUND-COLOR: #feffff"">"
            Header &= "<a href=""http://www.facebook.com/tipografiaformer.it""><img src=""http://www.tipografiaformer.it/img/btnFacebook.png"" style=""padding-right:5px;"" border=0></a>"
            Header &= "<a href=""https://twitter.com/FormerOfficial""><img src=""http://www.tipografiaformer.it/img/btnTwitter.png"" style=""padding-right:5px;"" border=0></a>"
            Header &= "<a href=""http://www.youtube.com/user/tipografiaformer""><img src=""http://www.tipografiaformer.it/img/btnYoutube.png"" border=0></a></td>"
            Header &= "</tr></table><br>"

            posiz = risFinale.IndexOf("<table")

            If posiz <> -1 Then
                Dim PosizTrovata As Integer = posiz
                posiz = risFinale.IndexOf("<table", posiz + 1)
                If posiz = -1 Then
                    posiz = PosizTrovata
                End If
            Else
                posiz = 0
            End If

            'risFinale = risFinale.Insert(posiz, Header)
            risFinale = risFinale.Substring(0, posiz) & Header & risFinale.Substring(posiz)

            'risFinale &= Header
            Using w As New StreamWriter(PathRis)
                w.Write(risFinale)
            End Using

            Dim FolderToCreate As String = String.Empty
            Dim RemotePath As String = String.Empty

            Dim Ftp As New FTPclient(FConfiguration.Ftp.ServerNameProduzione,
                                     FConfiguration.Ftp.ServerLoginProduzione,
                                     FConfiguration.Ftp.ServerPwdProduzione)

            Dim FolderLocale As String = FormerLib.FormerHelper.File.GetFolder(PathHtmlSource)

            For Each ImgPath In ImgList

                If FolderToCreate.Length = 0 Then

                    FolderToCreate = ImgPath.Substring(0, ImgPath.LastIndexOf("/"))

                    RemotePath = "tipografiaformer.it/emailattach/" & FolderToCreate
                    'qui devo creare la cartella
                    Ftp.FtpCreateDirectory(RemotePath)

                End If

                Dim NomeImg As String = ImgPath.Substring(ImgPath.LastIndexOf("/") + 1)
                Dim PathLocale As String = FolderLocale & "\" & FolderToCreate & "\" & NomeImg

                Dim PathRemoto As String = String.Empty

                PathRemoto = "tipografiaformer.it/emailattach/" & FolderToCreate & "/" & NomeImg

                Ftp.Upload(PathLocale, PathRemoto)

            Next

            Ftp = Nothing

            RisPath = PathRis
        Catch ex As Exception

        End Try

        Return RisPath

    End Function

    Public Shared Function CreaNewsletterSuListiniBase(ListaOfferte As List(Of ListinoBaseInTemplate),
                                                       Tm As TMO,
                                                       Optional CreateGoto As Boolean = False) As String
        Dim RisPath As String = String.Empty

        If PathTarget.Length Then
            Dim PathRis As String = PathTarget

            If NomeFile.Length Then
                PathRis &= NomeFile
            Else
                PathRis &= FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")
            End If

            Dim tableMark As String = ""

            tableMark = "	<table width=""602"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"">"
            tableMark &= "	  <tr>"
            tableMark &= "        <td colspan=""2"" align=""center"" style=""font-family: arial;""><h4><##MONTH##> <##YEAR##>, se ancora non conosci alcuni dei nostri prodotti...</h4>"
            tableMark &= "		</td>"
            tableMark &= "      </tr>"
            tableMark &= "      <tr>"
            tableMark &= "        <td colspan=""2""><font style=""font-family: arial; font-size: 15pt; color: #000000;""><b>Scegli Tipografia Former<br />...e cogli al volo le imperdibili offerte!<br><br>"
            If Tm.FiltroMarketing.TipoRub = enTipoRubrica.Rivenditore Then
                tableMark &= "		<center>PREZZI RISERVATI SOLO AI RIVENDITORI<br>AGENZIE PUBBLICITARIE, TIPOGRAFIE</center>"
            End If
            tableMark &= "</b></font></td>"
            tableMark &= "      </tr>"
            tableMark &= "      <tr>"
            tableMark &= "        <td colspan=""2"" bgcolor=""#f58220"" align=""center"" height=""30""><font style=""font-family: arial, verdana, sans-serif; font-size: 9pt; color: #ffffff;""><b>prezzi validi a <##MESEVALIDITA##> per ordini effettuati da <a href=""http://www.tipografiaformer.it/"" style=""color: #ffffff;"">www.tipografiaformer.it</a> e riservati ai nostri clienti</b></font></td>"
            tableMark &= "      </tr>"
            tableMark &= "      <tr>"
            tableMark &= "        <td colspan=""2""><font style=""font-family: arial, verdana, sans-serif; font-size: 11pt; color: #000000;"">entra nel mondo Former e inizia il tuo viaggio alla scoperta della convenienza<br /><b>Controlla sempre nella tua area personale i tuoi coupons di sconto</b></font></td>"
            tableMark &= "      </tr>"
            tableMark &= "      <tr>"
            tableMark &= "        <td colspan=""2"">"
            tableMark &= "		<##OFFERTE##>"
            tableMark &= "		</td>"
            tableMark &= "      </tr>"
            tableMark &= "	  <tr>"
            tableMark &= "        <td colspan=""2"" align=""center""><a href=""http://www.tipografiaformer.it/"" style=""border: none;""><img border=""0"" src=""http://www.tipografiaformer.it/goto/<##GOTOIMG##>"" /></a><br>"
            tableMark &= "	  </td>"
            tableMark &= "      </tr>"
            tableMark &= "	  <tr>"
            tableMark &= "	  <td colspan=""2""><font style=""font-family: arial, verdana, sans-serif; font-size: 9pt; color: #000000;"">Se ancora non sei registrato ricordati di accedere come <b>Rivenditore</b> e troverai prezzi e offerte riservate per gli operatori del settore delle arti grafiche.</font></td>"
            tableMark &= "	  </tr>"
            tableMark &= "	  </table>"

            Dim TemplSing As String = " 	        <table width=""600"" cellpadding=""2"" cellspacing=""0"" align=""center"" style=""border-width:1px; border-color:#BBB; border-style:solid; background-color: #EEE;"">"
            TemplSing &= "			  <tr>"
            TemplSing &= "				<td valign=""top"" style=""border-width:10px 0px 10px 10px; border-color:#EEE; border-style:solid; background-color: #ffffff;"" width=""20%"">" &
                "<a href=""http://www.tipografiaformer.it/goto/<##GOTOPRODOTTO##>"" style=""border: none;""><img border=""0"" src=""http://www.tipografiaformer.it/listino/img/<##IMG##>"" /></a></td>" &
                "<td style=""border-width:10px 0px 10px 0px; border-color:#EEE; border-style:solid; background-color: #ffffff;"" valign=""top"" width=""60%"">" &
                "<font style=""font-family: arial, verdana, sans-serif; font-size: 11pt; color: #000000;""><b><a href=""http://www.tipografiaformer.it/goto/<##GOTOPRODOTTO##>"" style=""color: #000000;""><br />" &
                "<##TITOLO##></a></b></font><br /><br /><font style=""font-family: arial, verdana, sans-serif; font-size: 9pt; color: #000000;""><##DESCRIZIONE##></font></td><td valign=""bottom"" align=""right"" style=""border-width:0px; border-color:#EEE; border-style:solid;"" width=""20%"">" &
                "<font style=""font-family: arial, verdana, sans-serif; font-size: 9pt; color: #000000;""><b><##QTA##></b><br><br>a soli<br> <span style=""color: #CB0012; font-size: 14pt; font-weight:bold;"">&euro; <##PREZZO##></span><br>  + iva e consegna<br><br><span style=""font-family: arial, verdana, sans-serif; font-size: 7pt;"">" &
                "(<##INVECEDI##>grafica da Voi fornita)<br /><br /></span></b></font></td>"
            TemplSing &= "			  </tr>"
            TemplSing &= "			</table>"

            Dim risFinale As String = tableMark

            risFinale = risFinale.Replace("<##MONTH##>", StrConv(Now.ToString("MMMM"), VbStrConv.ProperCase))
            risFinale = risFinale.Replace("<##YEAR##>", Now.Year)
            risFinale = risFinale.Replace("<##MESEVALIDITA##>", StrConv(Tm.DataInizio.ToString("MMMM yyyy"), VbStrConv.ProperCase))

            If CreateGoto Then
                'qui devo andare a creare un goto per l'immagine che fa da trace
                Dim IdGoto As Integer = 0
                Dim t As New FormerDALWeb.TraceSource
                t.TargetUrl = "/img/logopiccolo.png"
                t.Nome = "VIEW " & NomeFile
                IdGoto = t.Save
                t.Dispose()
                risFinale = risFinale.Replace("<##GOTOIMG##>", IdGoto)
            End If

            Dim buffOfferte As String = ""

            For Each L As ListinoBaseInTemplate In ListaOfferte

                Dim ris As String = TemplSing

                ris = ris.Replace("<##TITOLO##>", L.ListinoBase.Nome)
                ris = ris.Replace("<##PREZZO##>", FormerLib.FormerHelper.Stringhe.FormattaPrezzo(L.Prezzo))
                ris = ris.Replace("<##QTA##>", L.Qta & " " & FormerLib.FormerHelper.Stringhe.GetEtichettaPerTipoPrezzo(L.ListinoBase.TipoPrezzo))

                ris = ris.Replace("<##IMG##>", FormerLib.FormerHelper.File.EstraiNomeFile(L.ListinoBase.GetImgFormato))

                Dim prezzoInveceDi As String = ""
                If L.PrezzoInveceDi Then

                    If L.InPromo Then
                        prezzoInveceDi = "In <b style=""font-weight: normal;padding:2px;border-radius:2px;background-color:#009ec9;color:white;"">Promo</b> invece di &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(L.PrezzoInveceDi) & "</b> - "
                    Else
                        prezzoInveceDi = "Invece di &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(L.PrezzoInveceDi) & "</b> - "
                    End If
                End If
                ris = ris.Replace("<##INVECEDI##>", prezzoInveceDi)

                Dim Descrizione As String = String.Empty
                Descrizione &= "Formato: " & L.ListinoBase.FormatoProdotto.Formato & IIf(L.ListinoBase.FormatoProdotto.ProdottoFinito, "", " " & L.ListinoBase.FormatoProdotto.OrientamentoStr) & "<br>"
                Descrizione &= "Tipo di Carta: " & L.ListinoBase.TipoCarta.Tipologia & "<br>"
                Descrizione &= "Colori di stampa: " & L.ListinoBase.ColoreStampa.Descrizione

                Dim NFogli As Integer = L.ListinoBase.faccmin
                If NFogli <> 2 Then
                    Descrizione &= "<br>" & L.ListinoBase.GetLabelFogli & ": "

                    Dim NfogliVis As Integer = 0
                    If L.ListinoBase.Target = enTargetListinoBase.Foglio Then
                        NfogliVis = NFogli / 2
                    Else
                        NfogliVis = NFogli
                        If L.ListinoBase.ColoreStampa.FR Then
                            NfogliVis = NFogli
                        Else
                            NfogliVis = NFogli / 2
                        End If
                    End If
                    Descrizione &= NfogliVis
                End If
                ris = ris.Replace("<##DESCRIZIONE##>", Descrizione)

                If CreateGoto Then
                    'qui devo andare a creare un goto per il prodotto
                    Dim IdGoto As Integer = 0
                    Dim t As New FormerDALWeb.TraceSource
                    t.TargetUrl = "/" & L.ListinoBase.IdPrev & "/" & L.ListinoBase.IdFormProd & "/" & L.ListinoBase.IdTipoCarta & "/" & L.ListinoBase.IdColoreStampa & "/" & L.ListinoBase.NomeInUrl 'TODO: INSERIRE URL DEL LISTINOBASE
                    t.Nome = "GOTO " & NomeFile
                    IdGoto = t.Save
                    t.Dispose()
                    ris = ris.Replace("<##GOTOPRODOTTO##>", IdGoto)
                End If

                buffOfferte &= ris
            Next

            risFinale = risFinale.Replace("<##OFFERTE##>", buffOfferte)

            Using w As New StreamWriter(PathRis)
                w.Write(risFinale)
            End Using

            RisPath = PathRis

        Else
            Throw New Exception("FormerInterop - PathTarget non specificato")
        End If

        Return RisPath

    End Function

End Class
