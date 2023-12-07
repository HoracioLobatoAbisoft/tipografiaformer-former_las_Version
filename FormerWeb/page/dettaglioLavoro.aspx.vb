Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports CuteWebUI
Imports System.IO
Imports FormerLib

Public Class pDettaglioLavoro
    Inherits FormerSecurePage
    Protected NextUrl As String = "/"
    Private _IdOrdine As Integer = 0
    Private _O As OrdineWeb = Nothing

    Protected ReadOnly Property O As OrdineWeb
        Get
            If _O Is Nothing Then
                _O = New OrdineWeb
                _O.Read(_IdOrdine)
            End If
            Return _O
        End Get
    End Property

    Public Function GetIdOrdView() As String
        Dim ris As String = String.Empty

        If O.IdOrdineInt Then
            ris = O.IdOrdineInt
        Else
            ris = "PROVVISORIO " & O.IdOrdine
        End If

        Return ris
    End Function

    Private Function ShowTemplate() As Boolean
        Dim ris As Boolean = False

        If _O.L.FormatoProdotto.PdfTemplate.Length Then
            ris = True
        End If

        If _O.L.FormatoProdotto.PdfTemplate3D.Length Then
            ris = True
        End If

        Return ris
    End Function

    Public ReadOnly Property OrdineReadOnly As Boolean
        Get
            Dim ris As Boolean = False
            If O.Stato >= enStatoOrdine.Registrato Or O.IdOrdineInt <> 0 Then
                ris = True
            End If
            Return ris
        End Get
    End Property

    Protected ReadOnly Property FronteRetro As Boolean
        Get
            Return O.C.FR
        End Get
    End Property

    Protected ReadOnly Property FileDaInviare As Boolean
        Get
            Dim ris As Boolean = False

            If O.Stato = enStatoOrdine.InAttesaAllegati Then

                If O.SorgenteFronte.Length = 0 Then
                    ris = True
                End If

            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property GetImgFormato As String
        Get
            Dim Ris As String = String.Empty

            Select Case O.L.PrendiIcoDa
                Case enPrendiIcoDa.FormatoProdotto
                    Ris = O.L.FormatoProdotto.ImgRif
                Case enPrendiIcoDa.ColoreDiStampa
                    Ris = O.L.ColoreStampa.imgrif
                Case enPrendiIcoDa.Preventivazione
                    Ris = O.P.ImgRif
                Case enPrendiIcoDa.TipoCarta
                    Ris = O.L.TipoCarta.ImgRif
            End Select

            Return Ris
        End Get
    End Property

    Private Sub IframeRender(_IdOrdine As Integer)
        Dim Eviroment As Boolean = UtenteConnesso.Eviroment
        Dim UrlProdottoEnviroment As String = ""
        If Eviroment Then
            UrlProdottoEnviroment = "https://react.tipografiaformertest.it:6060/#/" & _IdOrdine & "/dettaglio-lavoro"
        Else
            UrlProdottoEnviroment = "http://localhost:5173/#/" & _IdOrdine & "/dettaglio-lavoro"
        End If

        If UtenteConnesso.UtenteAutorizato Then
            Dim UrlIndex As String = UrlProdottoEnviroment
            IframeDetaglioLavoro.Text = "<iframe id='IFrameOrdini' src=" & UrlIndex & " style = 'width:100%;height:100vh;border:none;'></iframe>"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _IdOrdine = Convert.ToInt32(Page.RouteData.Values("idl"))

        'qui devo controllare che l'ordine sia tuo e che puoi gestire i file 
        IframeRender(_IdOrdine)
        Dim CheckVisOrd As Boolean = False
        If _IdOrdine Then

            Using Mgr As New OrdiniWebDAO
                Dim l As List(Of OrdineWeb) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.OrdineWeb.IdOrdine, _IdOrdine),
                                                          New LUNA.LunaSearchParameter(LFM.OrdineWeb.IdUt, UtenteConnesso.IdUtente),
                                                          New LUNA.LunaSearchParameter(LFM.OrdineWeb.Stato, enStatoOrdine.Eliminato, "<>"),
                                                          New LUNA.LunaSearchParameter(LFM.OrdineWeb.OrdineInOmaggio, enSiNo.Si, "<>"))
                If l.Count Then
                    CheckVisOrd = True
                End If

            End Using
        End If
        If CheckVisOrd = False Then
            Response.Redirect("/i-tuoi-lavori")
        Else

            If Not IsPostBack Then

                CaricaTipoRetro()
                'CaricaIndirizzi()

                If O.Nfogli > 2 Then
                    'qui è un multipagina 
                    ddlTipoRetro.SelectedValue = enTipoRetro.RetroNelFileFronte
                    ddlTipoRetro.Enabled = False
                Else
                    ddlTipoRetro.SelectedValue = O.TipoRetro
                    'ddlIndirizzo.SelectedValue = O.IdIndirizzo
                End If
                
                'txtNote.Text = O.NoteOrd
                If O.Preventivo = enSiNo.Si Then
                    chkPreventivo.Checked = True
                Else
                    chkPreventivo.Checked = False
                End If

                If OrdineReadOnly Then
                    'ddlIndirizzo.Enabled = False
                    ddlTipoRetro.Enabled = False
                    chkPreventivo.Enabled = False
                    txtNote.ReadOnly = True
                    lnkEditNote.Visible = False
                    lnkEditNome.Visible = False
                    lnkSaveNote.Visible = False
                    UploaderF.Visible = False
                    UploaderR.Visible = False
                    'lnkAddInd.Visible = False
                    lnkCarica.Visible = False
                    'pnlInviaEmail.Visible = False
                End If

                If O.Stato = enStatoOrdine.Preinserito Then
                    ddlTipoRetro.Enabled = False
                End If

                If O.SorgenteFronte.Length Then

                    Dim FileSorg As String = "/ordini/" & O.IdOrdine & "/" & O.SorgenteFronte

                    If File.Exists(Server.MapPath(FileSorg)) Then
                        HrefFronte.HRef = FileSorg
                        HrefFronte.InnerHtml = "<img src=""/img/icoDown16.png"" /> Scarica <b>" & O.SorgenteFronte & "</b>"
                        HrefFronte.Target = "_blank"
                    Else
                        HrefFronte.InnerText = "<b>" & O.SorgenteFronte & "</b>"
                        HrefFronte.HRef = Request.Url.AbsolutePath
                    End If
                    HrefFronte.Visible = True
                    UploaderF.Visible = False
                    lnkCarica.Visible = False
                    'pnlInviaEmail.Visible = False
                Else
                    If OrdineReadOnly Then
                        HrefFronte.InnerText = "Il file sorgente non è disponibile"
                        HrefFronte.HRef = Request.Url.AbsolutePath
                        HrefFronte.Visible = True
                    End If
                End If

                If FronteRetro Then
                    If O.TipoRetro = enTipoRetro.RetroDifferente Then
                        If O.SorgenteRetro.Length Then
                            Dim FileSorg As String = "/ordini/" & O.IdOrdine & "/" & O.SorgenteRetro
                            If File.Exists(Server.MapPath(FileSorg)) Then
                                HrefRetro.HRef = FileSorg
                                HrefRetro.InnerHtml = "<img src=""/img/icoDown16.png"" /> Scarica <b>" & O.SorgenteRetro & "</b>"
                                HrefRetro.Target = "_blank"
                            Else
                                HrefRetro.InnerText = "<b>" & O.SorgenteRetro & "</b>"
                                HrefRetro.HRef = Request.Url.AbsolutePath
                            End If
                            HrefRetro.Visible = True
                            UploaderR.Visible = False
                            If O.SorgenteFronte.Length Then lnkCarica.Visible = False 'qui c'e' l'errore
                        Else
                            If OrdineReadOnly Then
                                HrefRetro.InnerText = "Il file sorgente non è disponibile"
                                HrefRetro.HRef = Request.Url.AbsolutePath
                                HrefRetro.Visible = True
                            Else
                                UploaderR.Visible = True
                                lnkCarica.Visible = True
                            End If
                        End If
                    ElseIf O.TipoRetro = enTipoRetro.RetroBianco Then
                        lblRetro.Text = "Hai scelto il Retro Bianco"
                        lblRetro.Visible = True
                    ElseIf O.TipoRetro = enTipoRetro.RetroUgualeFronte Then
                        lblRetro.Text = "Hai scelto il Retro uguale al Fronte"
                        lblRetro.Visible = True
                    ElseIf O.TipoRetro = enTipoRetro.RetroNelFileFronte Then
                        lblRetro.Text = "Hai scelto il Retro contenuto nel file Fronte"
                        lblRetro.Visible = True
                    End If
                End If

            End If

        End If


    End Sub

    Public Function ShowTemplate3D() As Boolean
        Dim ris As Boolean = False

        'If _O.L.FormatoProdotto.PdfTemplate3D.Length Then
        '    ris = True
        'End If

        Return ris
    End Function

    Public Function GetTemplatePDF2D() As String
        Dim ris As String = String.Empty

        If _O.L.FormatoProdotto.PdfTemplate.Length Then
            ris = FormerWeb.FormerWebApp.PathListinoTemplate & _O.L.FormatoProdotto.PdfTemplate
        Else
            If _O.IdTipoFustella Then
                Using tf As New TipoFustellaW
                    tf.Read(_O.IdTipoFustella)
                    If tf.TEMPLATEPDF.Length Then
                        ris = FormerWeb.FormerWebApp.PathListinoTemplate & tf.TEMPLATEPDF
                    End If
                End Using
            End If
        End If

        Return ris
    End Function

    Public Function ShowTemplate2D() As Boolean
        Dim ris As Boolean = False

        If _O.L.FormatoProdotto.PdfTemplate.Length Then
            ris = True
        Else
            If _O.IdTipoFustella Then
                Using tf As New TipoFustellaW
                    tf.Read(_O.IdTipoFustella)
                    If tf.TEMPLATEPDF.Length Then
                        ris = True
                    End If
                End Using
            End If
        End If

        Return ris
    End Function

    Private Sub SalvaAllegatoReal(LatoCaricamento As Integer, args As CuteWebUI.UploaderEventArgs)

        Dim NomeFile As String = args.FileName
        NomeFile = FormerLib.FormerHelper.Web.NormalizzaNomeFile(NomeFile)
        If LatoCaricamento = enFronteRetro.Fronte Then
            NomeFile = "F_" & NomeFile
        ElseIf LatoCaricamento = enFronteRetro.Retro Then
            NomeFile = "R_" & NomeFile
        End If

        Dim DirOrdine As String = FormerWebApp.PathOrdini & O.IdOrdine & "\"

        Try
            If Directory.Exists(DirOrdine) = False Then
                Directory.CreateDirectory(DirOrdine)
            End If
            args.CopyTo(DirOrdine & NomeFile)

            If LatoCaricamento = enFronteRetro.Fronte Then
                O.SorgenteFronte = NomeFile
                If O.C.FR Then
                    If O.TipoRetro <> enTipoRetro.RetroDifferente Then
                        O.SorgenteRetro = String.Empty
                        O.Stato = enStatoOrdine.Preinserito
                        O.DataCambioStato = Now
                    End If
                Else
                    O.DataCambioStato = Now
                    O.Stato = enStatoOrdine.Preinserito
                End If
            ElseIf LatoCaricamento = enFronteRetro.Retro Then
                O.SorgenteRetro = NomeFile
                If O.SorgenteFronte.Length Then
                    O.Stato = enStatoOrdine.Preinserito
                    O.DataCambioStato = Now
                End If
            End If

            'qui posso salvare le note insieme all'ordine
            'DISATTIVATO IN DATA 20/04/2015 per problema annotazioni vuote
            'O.Annotazioni = txtNote.Text

            O.Save()

            'qui inserisco il coupon se previsto
            If O.Stato = enStatoOrdine.Preinserito Then

                'qui modifico la consegna e la porto a in lavorazione se arriva da inserito 
                If O.ConsegnaAssociata.IdStatoConsegna = enStatoConsegna.Inserito Then
                    O.ConsegnaAssociata.IdStatoConsegna = enStatoConsegna.InLavorazione
                    O.ConsegnaAssociata.Save()
                End If

                'VADO A SALVARE IL COUPON SE PREVISTO 
                If UtenteConnesso.IsAdmin = False Then
                    'solo se non e' un uno di noi
                    If O.L.Preventivazione.PercCoupon Then
                        'se c'e' una percentuale di coupon vado a inserire il nuovo coupon per questo utente

                        'prima di creare il coupon controllo che sul lavoro non ci sia stato applicato gia un coupon creato da noi e non dal sito
                        Dim CheckCouponNostro As Boolean = True
                        If O.IdCoupon Then
                            Dim C As New CouponW
                            C.Read(O.IdCoupon)
                            If C.IdCouponInt Then
                                CheckCouponNostro = False
                            End If
                        End If

                        If CheckCouponNostro Then
                            Dim CodiceCoupon As String = String.Empty
                            Using mgr As New CouponWDAO
                                CodiceCoupon = mgr.GetCodiceCoupon(O.L.Preventivazione.Prefisso.ToUpper, UtenteConnesso.IdUtente)
                            End Using
                            Dim ggValid As Integer = 30
                            Dim ImportoCoup As Decimal = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(((O.PrezzoCalcolatoNetto * O.L.Preventivazione.PercCoupon) / 100), 2)
                            If UtenteConnesso.Tipo = enTipoRubrica.Cliente Then ggValid = 90
                            Dim Coup As New CouponW
                            Coup.VisibileOnline = enSiNo.No
                            Coup.Riservato = UtenteConnesso.IdUtente
                            Coup.RiservatoATipoUtente = UtenteConnesso.Tipo
                            Coup.QtaSpecifica = O.Qta
                            Coup.IdListinoBase = O.L.IdListinoBase
                            Coup.DataInizioValidita = Now
                            Coup.DataFineValidita = Now.AddDays(ggValid)
                            Coup.MaxVolte = 1
                            Coup.Stato = enStato.Attivo
                            Coup.ImportoFisso = ImportoCoup
                            Coup.Nome = "Coupon automatico Rif. Lavoro " & O.IdOrdine
                            Coup.Codice = CodiceCoupon
                            Coup.IdLavoro = O.IdOrdine
                            Coup.Save()

                            Try
                                InviaMailCoupon(Coup)
                            Catch ex As Exception

                            End Try
                        End If

                    End If
                End If

            End If
        Catch ex As Exception
            Dim LogErrore As String = ex.Source & "<br><br>" & ex.Message & "<br><br>Ordine " & O.IdOrdine & "<br><br>Nome file " & NomeFile
            FormerLib.FormerHelper.Mail.InviaMail("Errore Upload File", LogErrore, FormerConst.EmailAssistenzaTecnica)
        End Try

    End Sub

    Private Sub InviaMailCoupon(C As CouponW)

        'INVIO MAIL DI CONFERMA DELL'ORDINE RICEVUTO

        Dim Pt As New My.Templates.MailCoupon
        Pt.C = C
        Dim Buffer As String = Pt.TransformText

        Try
            FormerHelper.Mail.InviaMail("Grazie per il tuo ordine, hai ricevuto un Coupon di Sconto", Buffer, UtenteConnesso.Utente.Email)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub SalvaAllegatoFronte(args As CuteWebUI.UploaderEventArgs)

        SalvaAllegatoReal(1, args)
    End Sub

    Public Sub SalvaAllegatoRetro(args As CuteWebUI.UploaderEventArgs)

        SalvaAllegatoReal(2, args)
    End Sub

    Protected ReadOnly Property TargetEmailFronte As String
        Get
            Dim ris As String = "mailto:allegati.former+F" & _IdOrdine & "@gmail.com?subject=Invio%20File%20Fronte"
            Return ris
        End Get
    End Property

    Protected ReadOnly Property TargetEmailRetro As String
        Get
            Dim ris As String = "mailto:allegati.former+R" & _IdOrdine & "@gmail.com?subject=Invio%20File%20Retro"
            Return ris
        End Get
    End Property

    Private Sub ddlTipoRetro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoRetro.SelectedIndexChanged

        O.TipoRetro = ddlTipoRetro.SelectedValue
        O.Save()

        Select Case ddlTipoRetro.SelectedValue
            Case enTipoRetro.RetroBianco
                UploaderR.Visible = False
                lblRetro.Text = "Hai scelto il Retro Bianco"
                lblRetro.Visible = True
            Case enTipoRetro.RetroDifferente
                If O.SorgenteRetro.Length Then
                    HrefRetro.HRef = "/ordini/" & O.IdOrdine & "/" & O.SorgenteRetro
                    HrefRetro.Visible = True
                    UploaderR.Visible = False
                Else
                    UploaderR.Visible = True
                End If
                lblRetro.Visible = False
            Case enTipoRetro.RetroUgualeFronte
                UploaderR.Visible = False
                lblRetro.Text = "Hai scelto il Retro uguale al Fronte"
                lblRetro.Visible = True
            Case enTipoRetro.RetroNelFileFronte
                UploaderR.Visible = False
                lblRetro.Text = "Hai scelto il Retro contenuto nel file Fronte"
                lblRetro.Visible = True

        End Select
    End Sub

    'Private Sub CaricaIndirizzi()

    '    ddlIndirizzo.Items.Clear()
    '    Dim IdPredef As Integer = 0
    '    Dim l As New ListItem
    '    Dim lst As List(Of Indirizzo) = Nothing

    '    Using Mgr As New IndirizziDAO
    '        lst = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "citta"}, _
    '                                                 New LUNA.LunaSearchParameter("Idut", UtenteConnesso.IdUtente), _
    '                                                 New LUNA.LunaSearchParameter("Status", CInt(enStato.Attivo)))
    '    End Using

    '    Dim PrimoInd As String = UtenteConnesso.Utente.Indirizzo & " - " & UtenteConnesso.Utente.Cap & " " & UtenteConnesso.Utente.Citta & " (" & UtenteConnesso.Utente.ProvinciaSel.PROVINCIA & ")"

    '    If lst.Find(Function(x) x.Predefinito = True) Is Nothing Then
    '        PrimoInd &= " (predefinito)"
    '    End If

    '    l.Text = PrimoInd
    '    l.Value = 0

    '    ddlIndirizzo.Items.Add(l)

    '    For Each I As Indirizzo In lst
    '        l = New ListItem
    '        l.Text = I.Nome & ": " & I.Riassunto
    '        l.Value = I.IdIndirizzo

    '        If I.Predefinito Then
    '            l.Text &= " (predefinito)"
    '            IdPredef = I.IdIndirizzo
    '        End If

    '        ddlIndirizzo.Items.Add(l)
    '    Next

    '    ddlIndirizzo.SelectedValue = IdPredef

    'End Sub

    Private Sub CaricaTipoRetro()
        ddlTipoRetro.Items.Clear()

        Dim l As New ListItem
        l.Selected = True
        l.Text = "Fronte e Retro differenti"
        l.Value = enTipoRetro.RetroDifferente
        ddlTipoRetro.Items.Add(l)

        l = New ListItem
        l.Selected = False
        l.Text = "Fronte e Retro uguali"
        l.Value = enTipoRetro.RetroUgualeFronte
        ddlTipoRetro.Items.Add(l)

        l = New ListItem
        l.Selected = False
        l.Text = "Retro contenuto nel file Fronte"
        l.Value = enTipoRetro.RetroNelFileFronte
        ddlTipoRetro.Items.Add(l)

        l = New ListItem
        l.Selected = False
        l.Text = "Retro Bianco"
        l.Value = enTipoRetro.RetroBianco
        ddlTipoRetro.Items.Add(l)

    End Sub

    Private Sub chkPreventivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPreventivo.CheckedChanged

        O.Preventivo = IIf(chkPreventivo.Checked, enSiNo.Si, enSiNo.No)
        O.Save()

    End Sub

    Private Sub lnkCarica_Click(sender As Object, e As EventArgs) Handles lnkCarica.Click

        'TERMINATO IL CARICAMENTO LO INVIO AL DETTAGLIO DELL'ORDINE
        Dim UrlOrdine As String = "/" & O.IdCons & "/dettaglio-ordine"
        Response.Redirect(UrlOrdine)

    End Sub

    'Private Sub ddlIndirizzo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlIndirizzo.SelectedIndexChanged
    '    O.IdIndirizzo = ddlIndirizzo.SelectedValue
    '    O.Save()
    'End Sub

    Public ReadOnly Property ShowPreventivo As Boolean
        Get
            Dim ris As Boolean = True

            Dim P As New TipoPagamentoW
            P.Read(O.ConsegnaAssociata.IdPagam)

            If P.PeriodoPagam = enPeriodoPagamento.Anticipato Then
                ris = False
            End If
            'qui controllo se ha scelto il pagamento anticipato non potra mai avere preventivo

            Return ris
        End Get
    End Property

    Private Sub lnkSaveNote_Click(sender As Object, e As EventArgs) Handles lnkSaveNote.Click
        Dim newVal As String = txtNote.Text

        If ViewState("EditMode") = "Nome" Then
            If newVal.Length > 30 Then
                newVal = newVal.Substring(0, 30)
            End If
            newVal = Server.HtmlEncode(newVal)
            O.NomeLavoro = newVal
        ElseIf ViewState("EditMode") = "Note" Then
            If newVal.Length > 255 Then
                newVal = newVal.Substring(0, 255)
            End If
            newVal = Server.HtmlEncode(newVal)
            O.Annotazioni = newVal
        End If

        O.Save()
        pnlNote.Visible = False

    End Sub

    Private Sub lnkEditNote_Click(sender As Object, e As EventArgs) Handles lnkEditNote.Click
        ViewState("EditMode") = "Note"
        txtNote.Text = Server.HtmlDecode(O.NoteOrd)
        txtNote.MaxLength = 255
        pnlNote.Visible = True
    End Sub

    Private Sub lnkChiudi_Click(sender As Object, e As EventArgs) Handles lnkChiudi.Click

        pnlNote.Visible = False

    End Sub

    Private Sub lnkEditNome_Click(sender As Object, e As EventArgs) Handles lnkEditNome.Click

        ViewState("EditMode") = "Nome"
        txtNote.MaxLength = 30
        txtNote.Text = Server.HtmlDecode(O.NomeLavoro)
        pnlNote.Visible = True

    End Sub

End Class