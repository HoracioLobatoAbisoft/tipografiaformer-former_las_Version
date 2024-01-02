Imports System.IO
Imports FormerBusinessLogic
Imports FormerBusinessLogicInterface
Imports FormerDALWeb
Imports FormerGraphics
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class pProdotto
    Inherits FormerPage
    Implements IFormerWizardPage

    Private _IdPrev As Integer = 0
    Private _IdFormato As Integer = 0
    Private _IdTipoCarta As Integer = 0
    Private _IdColori As Integer = 0
    Private _DescrizioneUrl As String = ""
    Private _Nfogli As Integer = 0

    Private KeyQtaSelezionata As String = "QtaSelezionata"

    'Variables Creadas Nuevas para el frame
    Private _idFustela As Integer = 0
    Private _categoria As String = "0"
    Private _BaseEtiquete As String = "0"
    Private _AltezzaEqitquete As String = "0"

    'Private F As FormatoProdottoW
    'Private TC As TipoCartaW
    'Private C As ColoreStampaW

    'Private ReviewRowCount As Integer = 0
    'Private ReviewRecordPerPage As Integer = 2

    Public CouponDisponibili As New List(Of CouponW)

    Private Sub CaricaOmaggi()

        Dim L As List(Of OmaggioW) = MgrOmaggi.GetOmaggi(UtenteConnesso)

        L = L.FindAll(Function(x) x.Tipologia = enTipologiaOmaggio.ConCriteri And x.IdPreventivazione = LRif.IdPrev)

        rptOmaggi.DataSource = L
        rptOmaggi.DataBind()

    End Sub

    Private _SovrapprezzoInserimento As Integer = -1

    Public ReadOnly Property GetSovrapprezzoInserimento As Integer
        Get
            If _SovrapprezzoInserimento = -1 Then
                Try
                    Using L As New LavorazioneW
                        L.Read(FormerConst.Lavorazioni.InserimentoNelSistema)

                        If L.Prezzi.Count Then
                            _SovrapprezzoInserimento = L.Prezzi(0).Prezzo
                        Else
                            _SovrapprezzoInserimento = 0
                        End If
                    End Using
                Catch ex As Exception

                End Try
            End If
            Return _SovrapprezzoInserimento
        End Get
    End Property

    Public Function AbilitaRichiestaPreventivo() As Boolean

        Dim ris As Boolean = False

        If LRif.Preventivazione.GruppoVariante Then
            ris = True
        End If

        Return ris

    End Function

    Public Function MostraOmaggi() As Boolean

        Dim ris As Boolean = True

        'se non ha gia in carrello un omaggio puo avere un omaggio
        'se ci sono omaggi puo avere un omaggio

        Using p As New PreventivazioneW
            p.Read(FormerConst.ProdottiParticolari.IdPreventivazioneOmaggi)
            Dim l As List(Of ListinoBaseW) = p.GetListiniBase

            If l.FindAll(Function(x) x.Disattivo = enSiNo.No).Count = 0 Then
                ris = False
            End If

        End Using

        If ris Then
            'qui vado a valutare quali omaggi mostrare
            Dim l As List(Of OmaggioW) = MgrOmaggi.GetOmaggi(UtenteConnesso)

            l = l.FindAll(Function(x) x.Tipologia = enTipologiaOmaggio.ConCriteri And x.IdPreventivazione = LRif.IdPrev)

            If l.Count = 0 Then
                ris = False
            End If
        End If

        Return ris

    End Function

    Public ReadOnly Property TipoCarta As String
        Get
            Dim ris As String = "Tipo di Carta"

            Select Case P.IdReparto
                Case enRepartoWeb.Ricamo
                    ris = "Prodotto"
                Case enRepartoWeb.StampaDigitale
                    ris = "Materiale"
            End Select

            Return ris
        End Get
    End Property

    'Private _QtaCoupon As Integer = 0
    Public Function QtaCoupon() As String

        Dim Ris As String = ", "

        For Each SingC As CouponW In CouponDisponibili
            If Ris.IndexOf(", " & SingC.QtaSpecifica & ", ") = -1 Then Ris &= SingC.QtaSpecifica & ", "
        Next

        Ris = Ris.Substring(2)

        Dim PosVirg As Integer = Ris.LastIndexOf(",")

        If PosVirg <> -1 Then
            Ris = Ris.Substring(0, PosVirg)
        End If

        Return Ris

    End Function

    Private _P As PreventivazioneW = Nothing
    Public ReadOnly Property P As PreventivazioneW
        Get
            If _P Is Nothing Then
                _P = New PreventivazioneW
                _P.Read(_IdPrev)
            End If
            Return _P
        End Get
    End Property

    Public Function GetDescrizioneDinamicaLav() As String
        Dim ris As String = String.Empty

        Dim OldCat As String = String.Empty

        For Each lav As FormerDALWeb.LavorazioneW In GetElencoCompletoLavorazioniSelezionate()
            Dim Prefisso As String = String.Empty

            If LRif.LavorazioniBase.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count Then
                Prefisso = "Opzione inclusa "
            Else
                Prefisso = "Opzione scelta "
            End If

            If OldCat <> lav.CatLav.Descrizione Then
                OldCat = lav.CatLav.Descrizione
                ris &= "<h2>" & Prefisso & StrConv(OldCat, VbStrConv.ProperCase) & "</h2>"
            End If
            ris &= "<p><b>" & lav.Descrizione & "</b>, " & lav.DescrizioneEstesaEx & "</p>"
        Next

        Return ris
    End Function

    'Private _L As ListinoBaseW = Nothing
    Private _LRif As ListinoBaseW = Nothing
    Public ReadOnly Property LRif As ListinoBaseW
        Get

            Dim ris As ListinoBaseW = Nothing

            If ddlFormato.SelectedValue.Length <> 0 And
               ddlTipoCarta.SelectedValue.Length <> 0 And
               ddlColoreStampa.SelectedValue.Length <> 0 Then

                Dim IdFormProd As Integer = ddlFormato.SelectedValue
                Dim IdTipoCarta As Integer = ddlTipoCarta.SelectedValue
                Dim IdColoreStampa As Integer = ddlColoreStampa.SelectedValue

                If IdFormProd <> 0 And IdTipoCarta <> 0 And IdColoreStampa <> 0 Then
                    If IdFormProd <> _IdFormato Or
                                IdTipoCarta <> _IdTipoCarta Or
                                IdColoreStampa <> _IdColori Then

                        If Not _LRif Is Nothing Then

                            If _LRif.IdFormProd <> IdFormProd OrElse _LRif.IdTipoCarta <> IdTipoCarta OrElse _LRif.IdColoreStampa <> IdColoreStampa Then
                                _LRif = Nothing
                            End If

                        End If

                        If _LRif Is Nothing Then
                            Using mgr As New ListinoBaseWDAO
                                _LRif = mgr.Find(New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdPrev),
                                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdFormProd, IdFormProd),
                                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdTipoCarta, IdTipoCarta),
                                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdColoreStampa, IdColoreStampa),
                                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))

                            End Using
                        End If

                        If Not _LRif Is Nothing Then
                            ris = _LRif
                        End If
                    End If
                End If

            End If

            If ris Is Nothing Then
                If _LRif Is Nothing Then
                    Using Mgr As New ListinoBaseWDAO
                        _LRif = Mgr.Find(New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdPrev),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdTipoCarta, _IdTipoCarta),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdColoreStampa, _IdColori),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdFormProd, _IdFormato),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
                    End Using
                End If
                ris = _LRif
            End If

            Return ris
        End Get
    End Property

    Private Sub CaricaCouponDisponibili()

        If Not UtenteConnesso Is Nothing AndAlso UtenteConnesso.IdUtente <> 0 Then

            'qui controllo se c'e' un coupon disponibile e che tu non l'abbia gia usato
            Using mgr As New CouponWDAO
                Dim L As List(Of CouponW) = mgr.FindAll(New LUNA.LunaSearchParameter("Stato", enStato.Attivo),
                                                        New LUNA.LunaSearchParameter("datediff(""d"",DataInizioValidita,getdate())", 0, ">="),
                                                        New LUNA.LunaSearchParameter("datediff(""d"",DataFineValidita,getdate())", 0, "<="),
                                                        New LUNA.LunaSearchParameter("IdListinoBase", LRif.IdListinoBase),
                                                        New LUNA.LunaSearchParameter("Riservato", "(0," & UtenteConnesso.IdUtente & ")", " IN "))

                L.Sort(Function(x, y) x.QtaSpecifica.CompareTo(y.QtaSpecifica))

                For Each singC As CouponW In L
                    If singC.RiservatoATipoUtente = UtenteConnesso.Tipo Then
                        'cerco che non sia stato gia usato
                        Using mgrO As New OrdiniWebDAO
                            Dim lo As List(Of OrdineWeb) = mgrO.FindAll(New LUNA.LunaSearchParameter("IdCoupon", singC.IdCoupon))
                            If lo.Count = 0 Then
                                CouponDisponibili.Add(singC)
                            End If
                        End Using
                    End If
                Next
            End Using
        End If

    End Sub

    Public Function ShowIcoDigitale() As Boolean
        Dim ris As Boolean = False
        Try
            Dim IdMacchinarioAttuale As Integer = ViewState(KeyIdMacchinarioStampa)

            If IdMacchinarioAttuale Then
                ris = True
            End If
        Catch ex As Exception

        End Try

        Return ris
    End Function
    Public Function ShowCouponIco() As Boolean

        Dim Ris As Boolean = False

        For Each singC As CouponW In CouponDisponibili
            'If singC.QtaSpecifica = ddlQta.SelectedValue Then
            If singC.QtaSpecifica = GetQtaSelezionata() Then
                Ris = True
                Exit For
            End If
        Next

        Return Ris

    End Function

    Public Property Espandi As Boolean
        Get
            Dim Ris As Boolean = False

            If Not Session("Espandi") Is Nothing Then
                Ris = Session("Espandi")
            End If

            Return Session("Espandi")
        End Get
        Set(value As Boolean)
            Session("Espandi") = value
        End Set
    End Property

    Private Property QtaSelezionata As Integer
        Get
            Return ViewState("QtaSelezionata")
        End Get
        Set(value As Integer)
            ViewState("QtaSelezionata") = value
        End Set
    End Property

    Private Property TipoDataSelezionata As String
        Get
            Dim Val As String = String.Empty

            If Not ViewState("TipoDataSelezionata") Is Nothing Then
                Val = ViewState("TipoDataSelezionata")
            End If

            If Val.Length = 0 Then
                Dim d As RisDataConsegna = GetDateConsegna()
                Val = "N" & d.DataNormale.ToString("ddMMyyyy")
            End If

            Return Val
        End Get
        Set(value As String)
            ViewState("TipoDataSelezionata") = value
        End Set
    End Property

    Private Function GetDataSelezionata() As String

        Dim ris As String = String.Empty

        If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.Tabella Then
            '    ris = datasel
            ris = TipoDataSelezionata
        Else
            If rdoQuando.SelectedValue.Length Then
                ris = rdoQuando.SelectedValue
            Else
                ris = _QuandoSelected
            End If
        End If
        Return ris

    End Function

    Private Function GetQtaSelezionata() As Integer

        Dim ris As Integer = 0

        If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.Tabella Then
            ris = QtaSelezionata
            'ris = ViewState(KeyQtaSelezionata)
        ElseIf LRif.TipoControlloPrezzo = enTipoControlloPrezzo.ComboBox Then
            If ddlQta.SelectedValue.Length <> 0 Then
                ris = ddlQta.SelectedValue
            End If
        ElseIf LRif.TipoControlloPrezzo = enTipoControlloPrezzo.TextBox Then

            ris = QtaUserValidata()

        End If

        Return ris

    End Function

    Private Property InseritaQtaCustom As Boolean = False

    Private Function QtaCustomValidata() As Integer

        Dim Ris As Integer = 0

        Dim Val As String = txtQtaCustom.Text
        Val = Val.Replace(".", ",")

        If IsNumeric(Val) Then
            Dim ValInterm As Single = CSng(Val)

            ValInterm = Math.Abs(ValInterm)

            Ris = Math.Floor(ValInterm)

            Dim QtaValidata As Integer = 0
            QtaValidata = MgrPreventivazioneB.ArrotondaQtaConMoltiplicatore(Ris, LRif)
            If Ris <> QtaValidata Then
                Ris = QtaValidata
                txtQtaCustom.Text = Ris
            End If
            'Else
            '    Ris = QtaDefaultDaSelezionare()
            '    txtQtaCustom.Text = Ris
        Else
            If Val.Length Then
                Ris = QtaDefaultDaSelezionare()
            End If
        End If

        Return Ris

    End Function

    Private Function QtaDefaultDaSelezionare() As Integer

        Dim QtaDaSelezionare As Integer = 0
        Select Case LRif.TipoPrezzo
            Case enTipoPrezzo.SuQuantita, enTipoPrezzo.SuFoglio 'default
                'TODO: MODIFICATOTIPOPREZZO

                Dim VoceDaSelezionare As Integer = 3
                If LRif.QtaDefault <> 0 Then
                    VoceDaSelezionare = LRif.QtaDefault
                End If

                If LRif.MoltiplicatoreQta Or Not LRif.Promo Is Nothing Then
                    VoceDaSelezionare = 1
                End If

                Select Case VoceDaSelezionare
                    Case 1
                        QtaDaSelezionare = LRif.qta1
                    Case 2
                        QtaDaSelezionare = LRif.qta2
                    Case 3
                        QtaDaSelezionare = LRif.qta3
                    Case 4
                        QtaDaSelezionare = LRif.qta4
                    Case 5
                        QtaDaSelezionare = LRif.qta5
                    Case 6
                        QtaDaSelezionare = LRif.qta6

                End Select

            'Case enTipoPrezzo.SuCopie 'TODO: MODIFICATOTIPOPREZZO

            '    Using mgr As New MgrQtaListinoBase
            '        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
            '        QtaDaSelezionare = lQta(0)

            '    End Using

                    'For I As Integer = 1 To LRif.qta6 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
                    'ddlQta.SelectedIndex = 0

            Case enTipoPrezzo.SuCmQuadri
                Using mgr As New MgrQtaListinoBase
                    Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                    QtaDaSelezionare = lQta(1)
                End Using
                    'ddlQta.Items.Add(New ListItem(500, 500))
                    'For I As Integer = 1000 To 10000 Step 1000 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
                    'For I As Integer = 15000 To 50000 Step 5000 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
'                    ddlQta.SelectedIndex = 1

            Case enTipoPrezzo.SuMetriQuadri
                Using mgr As New MgrQtaListinoBase
                    Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                    QtaDaSelezionare = lQta(0)

                End Using

        End Select
        Return QtaDaSelezionare
    End Function

    Private Function QtaUserValidata() As Integer

        Dim Ris As Integer = 0

        Dim Val As String = txtQtaUser.Text
        Val = Val.Replace(".", ",")

        If IsNumeric(Val) Then
            Dim ValInterm As Single = CSng(Val)
            Ris = Math.Floor(ValInterm)
            Dim LimiteMin As Integer = QtaLimiteMinVal
            Dim LimiteMax As Integer = QtaLimiteMaxVal
            If Ris < LimiteMin Then
                Ris = LimiteMin
                txtQtaUser.Text = Ris
            ElseIf Ris > LimiteMax Then
                Ris = LimiteMax
                txtQtaUser.Text = Ris
            End If
        Else
            Ris = QtaDefaultDaSelezionare()
            txtQtaUser.Text = Ris
        End If
        Return Ris
    End Function

    Private Function SetQtaSelezionata(Optional Qta As Integer = 0,
                                       Optional Posizione As Integer = 0) As Integer

        Dim ris As Integer = 0

        If Qta Then
            ddlQta.SelectedValue = Qta
        Else
            ddlQta.SelectedIndex = Posizione
        End If

        Return ris

    End Function

    Private _CouponConsigliato As CouponW = Nothing
    Public Function CouponConsigliato() As CouponW

        If _CouponConsigliato Is Nothing Then
            CouponDisponibili.Sort(Function(x, y) y.ImportoFisso.CompareTo(x.ImportoFisso))
            'Dim ValCoup As Single = 0
            For Each singC As CouponW In CouponDisponibili
                If singC.QtaSpecifica = GetQtaSelezionata() Then
                    _CouponConsigliato = singC
                    Exit For
                End If
            Next
        End If
        Return _CouponConsigliato
    End Function

    Public Function GetImportoSenzaCoupon() As String

        Dim ris As String = String.Empty

        Dim val As Decimal = CDec(ViewState(KeyPrezzoCalcolatoNetto)) 'CDec(lblPrezzoValue.Text)

        If Not CouponConsigliato() Is Nothing Then

            If CouponConsigliato.ImportoFisso Then
                val = val - CouponConsigliato.ImportoFisso
            ElseIf CouponConsigliato.Percentuale Then
                val = val - (val * CouponConsigliato.Percentuale / 100)
            End If
            If val < 0 Then val = 0
        End If

        ris = FormerHelper.Stringhe.FormattaPrezzo(val)

        Return ris

    End Function

    Public Function ShowLavorazioniWithImg() As Boolean

        Dim ris As Boolean = False

        For Each singlav As LavorazioneW In LRif.LavorazioniOpz
            If singlav.CatLav.TipoControllo <> enTipoControllo.ComboBox Then
                ris = True
                Exit For
            End If
        Next

        'If LRif.LavorazioniOpz.Count Then
        '    ris = True
        'End If

        'If LRif.LavorazioniOpz.FindAll(Function(x) x.IdCatLav <> LUNA.LunaContext.IdCatPieghe).Count Then
        '    ris = True
        'End If

        Return ris

    End Function

    Public Function ShowPiega() As Boolean

        Dim ris As Boolean = False

        'If LRif.LavorazioniOpz.FindAll(Function(x) x.IdCatLav = LUNA.LunaContext.IdCatPieghe).Count Then
        '    ris = True
        'End If

        Return ris

    End Function

    Public Function ShowOrientamento() As Boolean

        Dim ris As Boolean = False 'basta metterlo a false per evitare che venga chiesto l'orientamento a prescindere dal formato prodotto

        If LRif.FormatoProdotto.Orientabile = enSiNo.Si Then
            ris = True
        End If

        Return ris

    End Function

    Public Function ShowLavorazOpz() As Boolean

        Dim ris As Boolean = False
        If LRif.LavorazioniOpz.Count Then
            ris = True
        End If
        Return ris

    End Function

    Public Function ShowSviluppo() As Boolean

        Dim ris As Boolean = False

        'If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
        '    ris = True
        'End If

        Return ris

    End Function

    Public Function ShowProfondita() As Boolean
        Dim ris As Boolean = False
        If MgrPlugin.GetIdPluginToUse(P) = enPluginOnline.Packaging Then
            ris = True
        End If
        Return ris
    End Function

    Public Function ShowMisureQta() As Boolean
        Dim ris As Boolean = False
        If ShowQtaCustom() Or ShowBloccoMisure() Then
            ris = True
        End If
        Return ris
    End Function

    Public Function ShowPulsanteCalcola() As Boolean
        Dim ris As Boolean = False

        'If ShowMisureQta() Then ris = True

        Return ris
    End Function

    Public Function ShowQtaCustom() As Boolean
        Dim ris As Boolean = False

        'mantengo le if separate per poterlo disattivare faiclmente in futuro in caso 

        If LRif.AbilitaQtaSottoColonna1 = enSiNo.Si OrElse
           LRif.AbilitaQtaIntermedie = enSiNo.Si Then
            ris = True
        ElseIf LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Or
               LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            ris = True
        End If

        Return ris
    End Function

    Public Function ShowCoupon() As Boolean

        Dim ris As Boolean = False

        If CouponDisponibili.Count Then
            ris = True
        End If

        Return ris
    End Function

    Protected ListaCombo As New List(Of DropDownList)
    Protected ListaRDO As New List(Of RadioButtonList)
    Protected ListaCheckbox As New List(Of CheckBoxList)
    'Protected ListaLblPrezzi As New List(Of LinkButton)
    'Protected ListaLbl As New List(Of Label)

    Private PathFotoListinoBase As String = Server.MapPath("~/listino/foto") & "\"
    Private _QuandoSelected As String = ""

    Public ReadOnly Property MostraMessaggioPrezzo As Boolean
        Get
            Dim ris As Boolean = True

            If UtenteConnesso.IdUtente Then
                ris = False
            Else
                Dim MyUrl As Uri = Request.UrlReferrer

                If Not MyUrl Is Nothing Then
                    If Session("MostratoMessaggioPrezzo") = True Then
                        ris = False
                    Else
                        Session("MostratoMessaggioPrezzo") = True
                    End If
                Else
                    ris = False
                End If
            End If

            Return ris
        End Get
    End Property

    Public Function getNominativoUtente() As String
        Dim ris As String = String.Empty

        ris = Server.HtmlEncode(UtenteConnesso.Nominativo)

        If ris.Length > 25 Then
            ris = ris.Substring(0, 25) & "..."
        End If

        Return ris.ToUpper
    End Function

    'Public ReadOnly Property GetImgFormato As String
    '    Get
    '        Dim Ris As String = String.Empty

    '        Select Case LRif.PrendiIcoDa
    '            Case enPrendiIcoDa.FormatoProdotto
    '                Ris = LRif.FormatoProdotto.ImgRif
    '            Case enPrendiIcoDa.ColoreDiStampa
    '                Ris = LRif.ColoreStampa.imgrif
    '            Case enPrendiIcoDa.Preventivazione
    '                Ris = P.ImgRif
    '            Case enPrendiIcoDa.TipoCarta
    '                Ris = LRif.TipoCarta.ImgRif
    '        End Select

    '        Return Ris
    '    End Get
    'End Property

    Public Function PrimoPrezzo() As String
        Dim ris As String = String.Empty

        Using mgr As New IndiciRicercaDAO
            Dim L As List(Of IndiceRicerca) = mgr.FindAll(New LUNA.LunaSearchParameter("IdListinoBase", LRif.IdListinoBase))

            If L.Count Then
                Dim singInd As IndiceRicerca = L(0)
                ris = singInd.Prezzo1Str
            End If

        End Using

        Return ris
    End Function
    Public Function BufferFotoEx() As String

        Dim ris As String = String.Empty

        Dim PathRes As String = PathFotoListinoBase & LRif.IdListinoBase

        Dim D As New DirectoryInfo(PathRes)

        If D.Exists Then
            For Each F As FileInfo In D.GetFiles("*.png")
                ris &= "<a href=""/listino/foto/" & LRif.IdListinoBase & "/" & F.Name & """ data-lightbox=""roadtrip""><img src=""/listino/foto/" & LRif.IdListinoBase & "/" & F.Name & """ class=""fotoProd""/></a><br /><br />"
            Next
            For Each F As FileInfo In D.GetFiles("*.jpg")
                ris &= "<a href=""/listino/foto/" & LRif.IdListinoBase & "/" & F.Name & """ data-lightbox=""roadtrip""><img src=""/listino/foto/" & LRif.IdListinoBase & "/" & F.Name & """ class=""fotoProd""/></a><br /><br />"
            Next

        End If

        Return ris

    End Function

    Public Function BufferFoto() As String

        Dim ris As String = String.Empty

        Dim PathRes As String = PathFotoListinoBase & LRif.IdListinoBase

        Dim D As New DirectoryInfo(PathRes)
        ris &= "<li><img src=""" & GetImgTestata & """ class=""bannerSchedaProdotto""/></li>"

        If D.Exists Then
            For Each F As FileInfo In D.GetFiles("*.png")
                ris &= "<li><img src=""/listino/foto/" & LRif.IdListinoBase & "/" & F.Name & """ class=""bannerSchedaProdotto""/></li>"
            Next
            For Each F As FileInfo In D.GetFiles("*.jpg")
                'ris &= "<li data-thumb=""/listino/foto/" & LRif.IdListinoBase & "/" & F.Name & """><img src=""/listino/foto/" & LRif.IdListinoBase & "/" & F.Name & """ class=""fotoProd""/></a></li>"
                ris &= "<li><img src=""/listino/foto/" & LRif.IdListinoBase & "/" & F.Name & """ class=""bannerSchedaProdotto""/></li>"
            Next

        End If

        Return ris

    End Function

    Public Function ShowFoto() As Boolean
        Dim ris As Boolean = False

        Dim PathRes As String = PathFotoListinoBase & LRif.IdListinoBase

        Dim D As New DirectoryInfo(PathRes)
        If D.Exists Then
            If D.GetFiles("*.png").Count > 0 Or D.GetFiles("*.jpg").Count > 0 Then
                ris = True
            End If
        End If
        Return ris
    End Function

    Public Function UrlVideo() As String
        Dim ris As String = P.UrlVideo
        'es. http://www.youtube.com/watch?v=0Zh5_PVtKr8&dsannodsanda
        'trasf in 0Zh5_PVtKr8

        ris = ris.Substring((ris.IndexOf("v=") + 2))
        Dim Posiz As Integer = ris.IndexOf("&")
        If Posiz Then
            ris = ris.Substring(0, Posiz)
        End If
        Return ris
    End Function

    Public Function ShowVideo() As Boolean

        Dim ris As Boolean = False

        If P.UrlVideo.Length Then
            ris = True
        End If

        Return ris

    End Function
    Public Function ShowFustelleSuggerite() As Boolean
        Dim ris As Boolean = False
        If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
            ris = True
        End If
        Return ris
    End Function

    Public Function GetUrlFustellePresenti() As String
        Dim ris As String = String.Empty

        If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
            Dim fp As FormerPlugin = MgrPlugin.GetPlugin(LRif.Preventivazione)
            ris = "/" & fp.Route.Url.Replace("{idp}", P.IdPrev)
        End If

        Return ris
    End Function

    Public Function ShowTemplate() As Boolean
        Dim ris As Boolean = False

        If ShowTemplate2D() Then
            ris = True
        End If

        If ShowTemplate3D() Then
            ris = True
        End If

        Return ris
    End Function

    Public Function ShowTemplate3D() As Boolean
        Dim ris As Boolean = False

        If LRif.FormatoProdotto.PdfTemplate3d.Length Then
            ris = True
        End If

        Return ris
    End Function

    Public Function GetTemplatePDF2D() As String
        Dim ris As String = String.Empty

        If LRif.FormatoProdotto.PdfTemplate.Length Then
            ris = FormerWeb.FormerWebApp.PathListinoTemplate & LRif.FormatoProdotto.PdfTemplate
        Else
            If P.IdPluginToUse Then
                Dim IdTipoFustella As Integer = 0
                Select Case DirectCast(P.IdPluginToUse, enPluginOnline)

                    Case enPluginOnline.Packaging
                        Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
                        If Not R Is Nothing Then
                            'qui sono passato per il plugin
                            IdTipoFustella = R.IdTipoFustella
                        End If
                    Case enPluginOnline.Etichette
                        Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
                        If Not R Is Nothing Then
                            'qui sono passato per il plugin
                            IdTipoFustella = R.IdTipoFustella
                        End If
                End Select
                If IdTipoFustella Then
                    Using tf As New TipoFustellaW
                        tf.Read(IdTipoFustella)
                        If tf.TEMPLATEPDF.Length Then
                            ris = FormerWeb.FormerWebApp.PathListinoTemplate & tf.TEMPLATEPDF
                        End If
                    End Using
                End If
            End If
        End If

        Return ris
    End Function

    Public Function ShowTemplate2D() As Boolean
        Dim ris As Boolean = False

        If LRif.FormatoProdotto.PdfTemplate.Length Then
            ris = True
        Else
            If P.IdPluginToUse Then
                Dim IdTipoFustella As Integer = 0
                Select Case DirectCast(P.IdPluginToUse, enPluginOnline)

                    Case enPluginOnline.Packaging
                        Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
                        If Not R Is Nothing Then
                            'qui sono passato per il plugin
                            IdTipoFustella = R.IdTipoFustella
                        End If
                    Case enPluginOnline.Etichette
                        Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
                        If Not R Is Nothing Then
                            'qui sono passato per il plugin
                            IdTipoFustella = R.IdTipoFustella
                        End If
                End Select
                If IdTipoFustella Then
                    Using tf As New TipoFustellaW
                        tf.Read(IdTipoFustella)
                        If tf.TEMPLATEPDF.Length Then
                            ris = True
                        End If
                    End Using
                End If
            End If

        End If

        Return ris
    End Function

    'Private Sub CaricaCorriere()

    '    ddlCorriere.DataTextField = "Riassunto"
    '    ddlCorriere.DataValueField = "IdCorriere"
    '    Using C As New CorrieriWDAO
    '        ddlCorriere.DataSource = C.FindAll("IdCorriere", New LUNA.LunaSearchParameter("DisponibileOnline", 1))
    '    End Using

    '    ddlCorriere.DataBind()


    '    'ddlCorriere.Attributes("onChange") = "SetQuandoDefault();"

    'End Sub

    Protected ReadOnly Property OgTitle As String Implements IFormerWizardPage.OgTitle
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = LRif.Nome
            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgCategory As String
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = LRif.Preventivazione.Descrizione

            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgDescriptionSEO As String
        Get
            Dim ris As String = String.Empty

            ris = LRif.DescrSitoSEOFormatted

            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgDescription As String Implements IFormerWizardPage.OgDescription
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = LRif.DescrSitoGoogleFormattedInLine

            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgKeywords As String Implements IFormerWizardPage.OgKeywords
        Get
            Dim ris As String = String.Empty

            ris = IIf(OgTitle.ToLower.StartsWith("stampa"), "", "Stampa ") & OgTitle & " online a Roma, " & OgTitle & ", Tipografia Former"

            Return ris
        End Get
    End Property

    Private _TitoloPagina As String = String.Empty
    Protected ReadOnly Property TitoloPagina As String
        Get
            Return _TitoloPagina
        End Get
    End Property

    Public ReadOnly Property GetImgTestata As String
        Get

            Dim ris As String = String.Empty

            ris = FormerWeb.FormerWebApp.PathListinoImg & LRif.ImgSito

            Return ris
        End Get
    End Property

    Public ReadOnly Property GetFormatoProdotto As String
        Get
            Dim ris As String = String.Empty

            If P.IdPluginToUse Then
                Select Case P.IdPluginToUse
                    Case enPluginOnline.EtichetteCm
                        Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm))
                        If Not R Is Nothing Then
                            ris = R.Base & " x " & R.Altezza & " (" & R.Categoria & ")"
                        End If
                    Case enPluginOnline.Etichette
                        Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
                        If Not R Is Nothing Then
                            ris = R.Base & " x " & R.Altezza & " (" & R.Categoria & ")"
                        End If
                    Case enPluginOnline.Packaging
                        Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
                        If Not R Is Nothing Then
                            ris = R.Base & " x " & R.Profondita & " x " & R.Altezza & " (Chiuso)"
                        Else
                            ris = LRif.FormatoProdotto.Formato & " " & IIf(LRif.FormatoProdotto.ProdottoFinito, "", " " & LRif.FormatoProdotto.OrientamentoStr)
                        End If
                End Select
            Else
                ris = LRif.FormatoProdotto.Formato & IIf(LRif.FormatoProdotto.ProdottoFinito, "", " " & LRif.FormatoProdotto.OrientamentoStr)
            End If

            Return ris
        End Get
    End Property

    Public Function ShowSVG() As Boolean
        Dim ris As Boolean = False
        If P.IdPluginToUse = enPluginOnline.Packaging Then
            Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
            If Not R Is Nothing Then
                ris = True
            End If
        ElseIf P.IdPluginToUse = enPluginOnline.Etichette Then
            Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
            If Not R Is Nothing Then
                If R.IdTipoFustella = 0 Then
                    ris = True
                End If

            End If
        ElseIf P.IdPluginToUse = enPluginOnline.EtichetteCm Then
            Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm))
            If Not R Is Nothing Then
                If R.IdTipoFustella = 0 Then
                    ris = True
                End If
            End If
        ElseIf LRif.idGruppoLogico <> 0 Or LRif.AllowCustomSize = enSiNo.Si Then
            Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
            If Not R Is Nothing Then
                ris = True
            End If
        End If
        Return ris
    End Function

    Public Function GetImgFormatoSVG() As String
        Dim ris As String = String.Empty
        If P.IdPluginToUse = enPluginOnline.Packaging Then
            Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
            If Not R Is Nothing Then
                ris = R.BufferSVG
            End If
        ElseIf P.IdPluginToUse = enPluginOnline.Etichette OrElse P.IdPluginToUse = enPluginOnline.EtichetteCm Then
            Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
            If Not R Is Nothing Then
                ris = R.BufferSVG
            End If
        ElseIf LRif.idGruppoLogico <> 0 Or LRif.AllowCustomSize = enSiNo.Si Then
            Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
            If Not R Is Nothing Then
                ris = R.BufferSVG
            End If
        End If
        Return ris
    End Function

    Public Function GetImgFormato() As String
        Dim ris As String = String.Empty

        If P.IdPluginToUse = enPluginOnline.Etichette Then
            Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
            If Not R Is Nothing Then
                ris = R.ImgFustellaScelta
            End If
        End If

        If ris.Length = 0 Then
            'qui devo controllare se e' presente una categoria con sovrascrivi
            Dim IdLavOverwrite As Integer = 0

            For Each cat In LRif.GetCatLav
                If cat.SovrascriviImgScheda = enSiNo.Si Then
                    'qui devo prendere la voce selezionata se esiste e in caso sovrascriverla 
                    Select Case cat.TipoControllo
                        Case enTipoControllo.CheckBox
                            Dim cmb As CheckBoxList = ListaCheckbox.Find(Function(x) x.ID = "lav" & cat.IdCatLav)
                            If Not cmb.SelectedItem Is Nothing Then
                                IdLavOverwrite = cmb.Items(0).Value
                            End If
                        Case enTipoControllo.ComboBox
                            Dim cmb As DropDownList = ListaCombo.Find(Function(x) x.ID = "lav" & cat.IdCatLav)
                            If Not cmb.SelectedItem Is Nothing Then
                                IdLavOverwrite = cmb.SelectedValue
                            End If
                        Case enTipoControllo.RadioButton
                            Dim cmb As RadioButtonList = ListaRDO.Find(Function(x) x.ID = "lav" & cat.IdCatLav)
                            If Not cmb.SelectedItem Is Nothing Then
                                IdLavOverwrite = cmb.SelectedValue
                            End If
                    End Select
                    If IdLavOverwrite = 0 Then
                        'qui devo controllare se per case e' comunque contenuta nelle lavorazioni base e allora la devo caricare comunque
                        Dim LavBase As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdCatLav = cat.IdCatLav)
                        If Not LavBase Is Nothing Then
                            IdLavOverwrite = LavBase.IdLavoro
                        End If
                    End If
                End If
            Next
            If IdLavOverwrite Then
                Using L As New LavorazioneW
                    L.Read(IdLavOverwrite)
                    ris = L.ImgRif
                End Using
            Else
                ris = LRif.GetImgFormato
            End If

        End If

        Return ris
    End Function

    Public Function GetImportoSpedizioni() As String

        Dim ris As String = String.Empty

        Dim mgr As New MGRSpedizioniCumulative

        Using tp As New TipoPagamentoW
            tp.Read(UtenteConnesso.Utente.IdPagamento)

            Dim Op As ProdottoInCarrello = GetProdottoScelto()

            Dim l As New List(Of ProdottoInCarrello)
            l.Add(Op)

            Dim sp As SpedizioneCumulativa = mgr.CalcolaSpedizioneCumulativa(l, tp)

            ris = FormerHelper.Stringhe.FormattaPrezzo(sp.Importo)

        End Using

        Return ris

    End Function

    Public Function GetImportoCoupon() As String
        Dim ris As String = String.Empty

        If P.PercCoupon Then

            Dim val As Decimal = CDec(ViewState(KeyPrezzoCalcolatoNetto)) 'CDec(lblPrezzoValue.Text)
            val = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((val * P.PercCoupon) / 100, 2)
            ris = FormerHelper.Stringhe.FormattaPrezzo(val)

        End If

        Return ris
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        PageLoad()

    End Sub

    Private Sub CaricaFogliPagine()

        ddlFogliPagine.Items.Clear()

        If LRif.ShowLabelFogli() Then
            If LRif.faccmin = LRif.faccmax Then
                'qui devo dividere per due 
                Dim ValoreRif As Integer = LRif.faccmin / 2
                Dim VoceTxt As String = TrasformaNFogli(ValoreRif) & LRif.LabelCopertina
                Dim VoceFissa As New ListItem(VoceTxt, ValoreRif)
                ddlFogliPagine.Items.Add(VoceFissa)
            Else
                Dim ValMin = LRif.faccmin / 2
                Dim ValMax = LRif.faccmax / 2

                Do
                    Dim VoceTxt As String = TrasformaNFogli(ValMin) & LRif.LabelCopertina
                    Dim VoceFissa As New ListItem(VoceTxt, ValMin)
                    ddlFogliPagine.Items.Add(VoceFissa)
                    ValMin += LRif.MultiploQta
                Loop Until ValMin > ValMax

            End If

            If _Nfogli <> 1 Then

                Try
                    ddlFogliPagine.SelectedValue = _Nfogli
                Catch ex As Exception
                    If LRif.DefaultNFogli Then
                        ddlFogliPagine.SelectedValue = LRif.DefaultNFogli
                    Else
                        ddlFogliPagine.SelectedIndex = 0
                    End If
                End Try


                'If Not ddlFogliPagine.Items.FindByValue(_Nfogli) Is Nothing Then
                '    ddlFogliPagine.SelectedValue = _Nfogli
                'Else
                '    ddlFogliPagine.SelectedValue = LRif.DefaultNFogli
                'End If

            End If

        End If

    End Sub

    Private Function TrasformaNFogli(NumFogli As Integer) As String

        Dim ris As String = String.Empty

        If LRif.Target = enTargetListinoBase.Foglio Then
            ris = NumFogli
        Else
            If LRif.ColoreStampa.FR Then
                ris = NumFogli * 2
            Else
                ris = NumFogli
            End If
        End If

        Return ris

    End Function

    Private Sub PageLoad()

        _IdPrev = Convert.ToInt32(Page.RouteData.Values("idp"))
        _IdFormato = Convert.ToInt32(Page.RouteData.Values("idf"))
        _IdTipoCarta = Convert.ToInt32(Page.RouteData.Values("idc"))
        _IdColori = Convert.ToInt32(Page.RouteData.Values("ids"))
        _DescrizioneUrl = Convert.ToString(Page.RouteData.Values("descrizione"))
        _Nfogli = Convert.ToInt32(Page.RouteData.Values("nfogli"))

        If P.DispOnline = False Then
            Response.Redirect("/")
        Else
            If P.PercCoupon Then
                PrevPromo.WithHeader = True
                PrevPromo.WithFooter = False
                PrevPromo.Preventivazione = P
                PrevPromo.Visible = True
            Else
                pnlPromo.Visible = False
            End If
        End If

        'controllo se e' passato per il plugin
        MgrPlugin.CheckNeedPlugin(P, enStepWizard.Prodotto)


        'lst = DirectCast(Application("ListaListiniBase"), List(Of ListinoBaseW)).FindAll(Function(x) x.IdPrev = _IdPrev And _
        '                                                                                     x.IdTipoCarta = _IdTipoCarta And _
        '                                                                                     x.IdColoreStampa = _IdColori And _
        '                                                                                     x.IdFormProd = _IdFormato
        '                                                                                     )

        Using mgr As New ListinoBaseWDAO
            Dim LCheck As ListinoBaseW = mgr.Find(New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdPrev),
                                                  New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdTipoCarta, _IdTipoCarta),
                                                  New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdColoreStampa, _IdColori),
                                                  New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdFormProd, _IdFormato),
                                                  New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                                                  New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
            If LCheck Is Nothing Then
                Response.Redirect("~/")
            End If
        End Using

        Try
            ScriptManager.GetCurrent(Me).RegisterPostBackControl(lnkPreventivoPDF)
        Catch ex As Exception

        End Try

        If Not IsPostBack Then

            If UtenteConnesso.IdUtente Then
                MgrTrack.SaveTrackOnline(UtenteConnesso.IdUtente, LRif.IdListinoBase)
            End If

            If ShowBloccoMisure() Then
                AlterateMisure = True
            Else
                AlterateMisure = False
            End If

            'Dim ResettaPlugin As Boolean = False

            Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
            If Not R Is Nothing Then
                'ResettaPlugin = True
                Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = Nothing
            End If

            If P.IdPluginToUse = enPluginOnline.Packaging Then
                '    ResettaPlugin = True
                Dim Rp As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
                If Not Rp Is Nothing Then
                    'qui sono passato per il plugin
                    'ris.IdTipoFustella = R.IdTipoFustella
                    If Rp.Altezza Then
                        txtAltezza.Text = Rp.Altezza
                        'Else
                        '    rfvTAltezza.Visible = True
                    End If
                    If Rp.Base Then
                        txtLarghezza.Text = Rp.Base
                        'Else
                        '    rfvTBase.Visible = True
                    End If
                    If Rp.Profondita Then
                        txtProfondita.Text = Rp.Profondita
                        'Else
                        '    rfvTProfondita.Visible = True
                    End If

                    If P.IdFunzionePack = enFunzionePackaging.FunzioneECMA3 Then
                        Dim MinimoP As Integer = MgrPluginPackaging.GetMinimoProfondita(P)
                        txtProfondita.Text = MinimoP
                        MgrPlugin.EditPluginRis(LRif.Preventivazione, MinimoP, enAsseXYZ.Profondita)
                        txtProfondita.Enabled = False
                        rfvTProfondita.Visible = False
                    End If

                End If
            End If

            'If ResettaPlugin Then
            '    MgrPlugin.ClearPlugin()
            'End If

            Espandi = False
            TipoDataSelezionata = ""

            If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.Tabella Then
                If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                    Using mgr As New MgrQtaListinoBase
                        Dim lQta As List(Of Integer) = mgr.GetElencoQtaReverse(LRif)

                        QtaSelezionata = lQta(0)
                    End Using
                Else
                    Dim VoceDaSelezionare As Integer = 3

                    If LRif.QtaDefault <> 0 Then
                        VoceDaSelezionare = LRif.QtaDefault
                    End If

                    If LRif.MoltiplicatoreQta Or Not LRif.Promo Is Nothing Then
                        VoceDaSelezionare = 1
                    End If

                    Dim QtaDaSelezionare As Integer = 0
                    Select Case VoceDaSelezionare
                        Case 1
                            QtaDaSelezionare = LRif.qta1
                        Case 2
                            QtaDaSelezionare = LRif.qta2
                        Case 3
                            QtaDaSelezionare = LRif.qta3
                        Case 4
                            QtaDaSelezionare = LRif.qta4
                        Case 5
                            QtaDaSelezionare = LRif.qta5
                        Case 6
                            QtaDaSelezionare = LRif.qta6
                    End Select

                    QtaSelezionata = QtaDaSelezionare
                End If

            ElseIf LRif.TipoControlloPrezzo = enTipoControlloPrezzo.ComboBox Then
                Dim VoceDaSelezionare As Integer = 3

                If LRif.QtaDefault <> 0 Then
                    VoceDaSelezionare = LRif.QtaDefault
                End If

                Dim QtaDaSelezionare As Integer = 0
                Select Case VoceDaSelezionare
                    Case 1
                        QtaDaSelezionare = LRif.qta1
                    Case 2
                        QtaDaSelezionare = LRif.qta2
                    Case 3
                        QtaDaSelezionare = LRif.qta3
                    Case 4
                        QtaDaSelezionare = LRif.qta4
                    Case 5
                        QtaDaSelezionare = LRif.qta5
                    Case 6
                        QtaDaSelezionare = LRif.qta6
                End Select

                QtaSelezionata = QtaDaSelezionare
            ElseIf LRif.TipoControlloPrezzo = enTipoControlloPrezzo.TextBox Then
                Dim VoceDaSelezionare As Integer = 3

                If LRif.QtaDefault <> 0 Then
                    VoceDaSelezionare = LRif.QtaDefault
                End If

                Dim QtaDaSelezionare As Integer = 0
                Select Case VoceDaSelezionare
                    Case 1
                        QtaDaSelezionare = LRif.qta1
                    Case 2
                        QtaDaSelezionare = LRif.qta2
                    Case 3
                        QtaDaSelezionare = LRif.qta3
                    Case 4
                        QtaDaSelezionare = LRif.qta4
                    Case 5
                        QtaDaSelezionare = LRif.qta5
                    Case 6
                        QtaDaSelezionare = LRif.qta6
                End Select

                QtaSelezionata = QtaDaSelezionare
            End If

            CaricaFormatiProdotto()
            ddlFormato.SelectedValue = _IdFormato
            MostraMisureFormatoScelto()
            CaricaTipiDiCarta()
            ddlTipoCarta.SelectedValue = _IdTipoCarta
            CaricaColoriDiStampa()
            ddlColoreStampa.SelectedValue = _IdColori
            CaricaFogliPagine()

            If ShowBloccoMisure() Then
                If txtAltezza.Text.Length = 0 Then
                    rfvTAltezza.Visible = True
                End If
                If txtLarghezza.Text.Length = 0 Then
                    rfvTBase.Visible = True
                End If
                If ShowProfondita() Then
                    If txtProfondita.Text.Length = 0 Then
                        rfvTProfondita.Visible = True
                    End If
                End If

            End If



        Else
            'azzero il plugin misure se necessario
            If LRif.idGruppoLogico = 0 And LRif.AllowCustomSize <> enSiNo.Si Then
                'controllo se è stato utilizzato un plugin
                Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
                If Not R Is Nothing Then
                    Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = Nothing
                End If
            Else
                If pnlMisurePersonalizzate.Visible = False Then
                    Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = Nothing
                End If
            End If
        End If

        'qui devo vedere come gestire le selezioni delle combo 

        'F = New FormatoProdottoW
        'F.Read(LRif.IdFormProd)

        'TC = New TipoCartaW
        'TC.Read(LRif.IdTipoCarta)

        CaricaCouponDisponibili()

        'qui alle lavorazioni base in caso di plugin devo aggiungere il risultato del plugin
        'If P.IdPluginToUse = enPluginOnline.Packaging Then
        '    Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
        '    If Not R Is Nothing Then
        '        If R.IdTipoFustella = 0 Then
        '            'qui devo aggiungere la lavorazione per la creazione fustella
        '            Dim LFust As New LavorazioneW
        '            LFust.Read(LUNA.LunaContext.IdLavCreazioneFustella)
        '            LRif.LavorazioniBase.Add(LFust)
        '        End If
        '    End If

        'End If

        CaricaLavorazioni()

        ' CaricaQTA()



        If Not IsPostBack Then

            _TitoloPagina = "Tipografia Former Online, il tuo mondo della stampa a Roma mod- Stampa "
            _TitoloPagina &= P.Descrizione & " "
            _TitoloPagina &= LRif.FormatoProdotto.Formato & " "
            _TitoloPagina &= LRif.TipoCarta.Tipologia & " "
            _TitoloPagina &= LRif.ColoreStampa.Descrizione & " "
            If LRif.ShowLabelFogli() Then
                _TitoloPagina &= GetNFogli() & " " & LRif.GetLabelFogli() & " "
            End If

            '_TitoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
            Title = _TitoloPagina

            ' CaricaPieghe()

            CaricaQTA()
            'CaricaCorriere()
            ''qui seleziono il corriere di default in baso al profilo utente
            'ddlCorriere.SelectedValue = UtenteConnesso.Utente.IdCorriereDef

            CaricaQtaTabella()

            CaricaOrientamento()

            CalcolaTutto()

        Else

            CaricaHandlerTabella()

        End If

        AggiornaReview()
        CaricaProdottoConsigliato()
        CaricaOmaggi()

        'AggiornaReview(ReviewRecordPerPage, 0)
        'ReviewRowCount = ViewState("RowCountReview")
        'CreatePagingControl()

        'If rdoPiega.Items.Count Then
        '    PannelloDinamico.Triggers.Add(New AsyncPostBackTrigger With {.ControlID = "rdoPiega", .EventName = "SelectedIndexChanged"})
        'End If

        'ciclo per tutte le catlav e vedo se esiste il controllo

        For Each catsi As CatLavW In LRif.GetCatLav

            PannelloDinamico.Triggers.Add(New AsyncPostBackTrigger With {.ControlID = "lav" & catsi.IdCatLav, .EventName = "SelectedIndexChanged"})

        Next

        Session("UltimoProdottoVisitato") = Request.Url.AbsolutePath

        'DIGITALE
        If P.IdReparto = enRepartoWeb.StampaDigitale Then
            lblTipoQta.Text = "Copie"
        End If
        Dim UrlProdottoEnviroment As String = UtenteConnesso.UrlIframe & "/form-prodotto-v2/"
        Dim Eviroment As Boolean = UtenteConnesso.Eviroment

        'If Eviroment Then
        '    UrlProdottoEnviroment = "https://react.tipografiaformertest.it:6060/#/form-prodotto-v2/"
        'Else
        '    UrlProdottoEnviroment = "http://localhost:5173/#/form-prodotto-v2/"
        'End If

        Dim UrlProdotto2 = UrlProdottoEnviroment & _IdPrev & "/" & _IdFormato & "/" & _IdTipoCarta & "/" & _IdColori & "/" & _Nfogli & "/" & Convert.ToInt32(UtenteConnesso.IdUtente) & "/" & _idFustela & "/" & _categoria & "/" & _BaseEtiquete & "/" & _AltezzaEqitquete
        If UtenteConnesso.UtenteAutorizato Then
            iframeRefactor.Text = "<iframe id='frameId' style='width:100%; height: 4080px;border: none;' src=" & UrlProdotto2 & " ></iframe>"
        End If


    End Sub

    Public Function ShowBloccoMisure() As Boolean
        Dim ris As Boolean = False
        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse
           LRif.TipoPrezzo = enTipoPrezzo.SuFoglio OrElse
           LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
            ris = True
        End If
        Return ris
    End Function

    'Private Sub lnk_ClickPage(ByVal sender As Object, ByVal e As EventArgs)

    '    Dim lnk As LinkButton = TryCast(sender, LinkButton)
    '    Dim currentPage As Integer = Integer.Parse(lnk.Text)
    '    Dim take As Integer = currentPage * ReviewRecordPerPage
    '    Dim skip As Integer = If(currentPage = 1, 0, take - ReviewRecordPerPage)
    '    AggiornaReview(take, skip)

    'End Sub

    'Private Sub CreatePagingControl()

    '    For i As Integer = 0 To (Math.Ceiling(ReviewRowCount / ReviewRecordPerPage)) - 1
    '        Dim lnk As New LinkButton()
    '        AddHandler lnk.Click, AddressOf lnk_ClickPage
    '        lnk.ID = "lnkPage" & (i + 1).ToString()
    '        lnk.Text = (i + 1).ToString()
    '        lnk.CssClass = "pagerItem"
    '        plcPaging.Controls.Add(lnk)
    '        Dim spacer As New Label()
    '        spacer.Text = "&nbsp;"
    '        plcPaging.Controls.Add(spacer)
    '    Next

    'End Sub

    Private Sub CaricaLavorazioni()

        'ResetListinoBase()
        'ResettaTipoFustella()

        LRif.CaricaLavorazioniBase()
        LRif.CaricaLavorazioniOpz()

        'ResetFustellaSelezionata()

        Dim Rp As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
        If Not Rp Is Nothing Then
            'qui va aggiunto il taglio a misura
            'la lavorazione nn è piu fissa ma variabile

            Dim IdLavTaglioAMisura As Integer = FormerConst.Lavorazioni.TaglioAMisuraOffset
            If LRif.IdLavTaglioDuplicati Then
                IdLavTaglioAMisura = LRif.IdLavTaglioDuplicati
            End If

            If LRif.LavorazioniBase.FindAll(Function(x) x.IdLavoro = IdLavTaglioAMisura).Count = 0 Then
                Dim lavTaglioMisura As New LavorazioneW
                lavTaglioMisura.Read(IdLavTaglioAMisura)

                LRif.LavorazioniBase.Add(lavTaglioMisura)
                'CaricaLavorazioniDisponibili()
            End If
        End If

        If P.IdPluginToUse = enPluginOnline.Packaging Then
            Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
            If Not R Is Nothing Then
                If R.IdTipoFustella = 0 Then
                    'qui devo aggiungere la lavorazione per la creazione fustella
                    If LRif.LavorazioniBase.FindAll(Function(x) x.IdLavoro = FormerConst.Lavorazioni.CreazioneFustella).Count = 0 Then
                        Dim LFust As New LavorazioneW
                        LFust.Read(FormerConst.Lavorazioni.CreazioneFustella) ' LUNA.LunaContext.IdLavCreazioneFustella)
                        LRif.LavorazioniBase.Insert(0, LFust)
                    End If
                Else

                    Dim LavFust As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdLavoro = FormerConst.Lavorazioni.CreazioneFustella)
                    If Not LavFust Is Nothing Then
                        LRif.LavorazioniBase.Remove(LavFust)
                    End If
                End If
            End If
        ElseIf P.IdPluginToUse = enPluginOnline.Etichette Then
            Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
            If Not R Is Nothing Then
                If R.IdTipoFustella = 0 Then
                    'qui devo aggiungere la lavorazione per la creazione fustella
                    Dim LFust As New LavorazioneW
                    LFust.Read(FormerConst.Lavorazioni.CreazioneFustella) 'LUNA.LunaContext.IdLavCreazioneFustella)
                    LRif.LavorazioniBase.Insert(0, LFust)
                End If
            End If
        End If

        If LRif.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            If P.IdPluginToUse = enPluginOnline.EtichetteCm Then
                'qui controllo se l'orientamento in caso fosse disponibile deve essere bloccato a verticale
                Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm))
                If Not R Is Nothing Then
                    Dim LatoFisso As Integer = (LRif.LatoFissoRiferimento(R.Altezza, R.Base).LatoFissoPrincipale * 10) ' (LRif.FormatoProdotto.Fc.Larghezza * 10)
                    Dim ValoreMax As Integer = LatoFisso - (FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato * 2)
                    If R.Altezza > ValoreMax Or R.Base > ValoreMax Then
                        'qui puo essere orientato solo in verticale
                        'devo cancellare la possibilita di scelta e aggiungere la lavorazione verticale come obbligatoria
                        LRif.LavorazioniBase.RemoveAll(Function(x) x.IdCatLav = FormerLib.FormerConst.ProdottiParticolari.IdCatOrientamentoEtichette)
                        Using mgr As New LavorazioniWDAO
                            Dim lLav As List(Of LavorazioneW) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.LavorazioneW.IdCatLav,
                                                                                                         FormerLib.FormerConst.ProdottiParticolari.IdCatOrientamentoEtichette))

                            lLav = lLav.FindAll(Function(x) x.ExtraData.IndexOf(FormerLib.FormerConst.ExtraDataKey.OrientamentoEtichette & ":  " & enTipoOrientamento.Verticale) <> -1)

                            For Each lav As LavorazioneW In lLav

                                If LRif.LavorazioniOpz.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count Then
                                    LRif.LavorazioniBase.Insert(0, lav)
                                    Exit For
                                End If

                            Next
                        End Using
                        LRif.LavorazioniOpz.RemoveAll(Function(x) x.IdCatLav = FormerLib.FormerConst.ProdottiParticolari.IdCatOrientamentoEtichette)
                    End If
                End If
            End If
        End If

        CaricaLavorazioniDisponibili()

        CaricaLavorazioniObbligatorie()

    End Sub

    Private Sub CaricaLavorazioniObbligatorie()
        Dim L As List(Of LavorazioneW) = LRif.LavorazioniBase

        Dim LObbligate As New List(Of LavorazioneW)

        For Each singL In L
            If LRif.LavorazioniOpz.FindAll(Function(x) x.IdCatLav = singL.IdCatLav).Count = 0 Then
                LObbligate.Add(singL)
            End If
        Next

        If P.IdPluginToUse = enPluginOnline.Packaging Then
            Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
            If Not R Is Nothing Then
                If R.IdTipoFustella = 0 Then
                    'qui devo aggiungere la lavorazione per la creazione fustella
                    If LRif.LavorazioniBase.FindAll(Function(x) x.IdLavoro = FormerConst.Lavorazioni.CreazioneFustella).Count = 0 Then
                        Dim LFust As New LavorazioneW
                        LFust.Read(FormerConst.Lavorazioni.CreazioneFustella) ' LUNA.LunaContext.IdLavCreazioneFustella)
                        LRif.LavorazioniBase.Insert(0, LFust)
                    End If
                Else

                    Dim LavFust As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdLavoro = FormerConst.Lavorazioni.CreazioneFustella)
                    If Not LavFust Is Nothing Then
                        LRif.LavorazioniBase.Remove(LavFust)
                    End If
                End If
            End If
            'ElseIf P.IdPluginToUse = enPluginOnline.Etichette Then
            '    Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
            '    If Not R Is Nothing Then
            '        If R.IdTipoFustella = 0 Then
            '            'qui devo aggiungere la lavorazione per la creazione fustella
            '            Dim LFust As New LavorazioneW
            '            LFust.Read(FormerConst.Lavorazioni.CreazioneFustella) 'LUNA.LunaContext.IdLavCreazioneFustella)
            '            LRif.LavorazioniBase.Insert(0, LFust)
            '        End If
            '    End If
        End If
        rptOpzioni.DataSource = Nothing
        rptOpzioni.DataSource = LObbligate.FindAll(Function(x) x.LavorazioneInterna = enSiNo.No)
        rptOpzioni.DataBind()
    End Sub

    'Private _QtaCaricate As New List(Of Integer)

    Private Sub ClickQtaLabel(sender As Object, e As EventArgs)

        '        ViewState(KeyQtaSelezionata) = sender.CommandArgument

        Dim Param As String = sender.commandargument

        'Dim Separatore As Integer = Param.IndexOf("§")

        'Dim TipoData As String = Param.Substring(0, Separatore)
        'Dim Qta As Integer = Param.Substring(Separatore + 1)

        'TipoDataSelezionata = TipoData
        'QtaSelezionata = Qta
        'CalcolaTutto()
        'CaricaQtaTabella()

        SelezionataData(Param)

    End Sub

    Private Sub SelezionataData(Param As String)

        Dim Separatore As Integer = Param.IndexOf("§")

        Dim TipoData As String = Param.Substring(0, Separatore)
        Dim Qta As Integer = Param.Substring(Separatore + 1)

        TipoDataSelezionata = TipoData
        QtaSelezionata = Qta
        CaricaQtaTabella()
        CalcolaTutto()

    End Sub

    Private Function CreaHandlerTabella(Qta As Integer,
                                        D As RisDataConsegna) As TableRow

        Dim R As New TableRow

        If P.ggFast Then
            Dim C As New TableCell

            Dim lblQta As New LinkButton
            lblQta.ID = "lblQtaF" & Qta
            lblQta.CommandArgument = "F" & D.DataFast.ToString("ddMMyyyy") & "§" & Qta
            AddHandler lblQta.Click, AddressOf ClickQtaLabel
            C.Controls.Add(lblQta)


            R.Cells.Add(C)
        End If

        If P.ggNorm Then
            Dim C As New TableCell

            Dim lblQta As New LinkButton
            lblQta.ID = "lblQtaN" & Qta
            lblQta.CommandArgument = "N" & D.DataNormale.ToString("ddMMyyyy") & "§" & Qta
            AddHandler lblQta.Click, AddressOf ClickQtaLabel
            C.Controls.Add(lblQta)
            R.Cells.Add(C)
        End If

        If P.ggSlow Then
            Dim C As New TableCell

            Dim lblQta As New LinkButton
            lblQta.ID = "lblQtaS" & Qta
            lblQta.CommandArgument = "S" & D.DataSlow.ToString("ddMMyyyy") & "§" & Qta
            AddHandler lblQta.Click, AddressOf ClickQtaLabel
            C.Controls.Add(lblQta)
            R.Cells.Add(C)
        End If

        Return R

    End Function

    Private Function CreaRigaTabellaEx(RPI As RisPrezzoIntermedio,
                                       QtaCouponDisp As List(Of Integer),
                                       SelectedVal As Integer,
                                       D As RisDataConsegna) As TableRow

        '_QtaCaricate.Add(Qta)

        Dim NumeroPezziScelti As Integer = RPI.RichiestaCalcoloPrezzo.QtaDaUsareNelCalcoloLavorazioni
        'Dim NumeroPezziScelti As Single = RPI.RichiestaCalcoloPrezzo.QtaRichiesta

        Dim R As New TableRow
        Dim EtichettaQta As String = FormerLib.FormerHelper.Stringhe.FormattaNumero(NumeroPezziScelti)
        If QtaCouponDisp.FindAll(Function(x) x = NumeroPezziScelti).Count <> 0 Then EtichettaQta &= " *"

        Dim C As New TableCell
        If NumeroPezziScelti = SelectedVal Then
            C.CssClass = "CellaQta bkgSelected"
        Else
            C.CssClass = "CellaQta bkgQta"
        End If
        C.Text = EtichettaQta

        R.Cells.Add(C)

        Dim PrezzoCalcolatoNetto As Decimal = 0
        Dim NumeroDecimali As Integer = 2

        If UtenteConnesso.Tipo = enTipoRubrica.Cliente Then
            PrezzoCalcolatoNetto = RPI.PrezzoPubbl
        Else
            PrezzoCalcolatoNetto = RPI.PrezzoRiv
        End If


        Dim PrezzoFast As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeFast(P)
        Dim PrezzoStandard As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeNormale
        Dim PrezzoSlow As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeSlow(P)

        Dim PrezzoFastOrig As Decimal = PrezzoFast
        Dim PrezzoStandardOrig As Decimal = PrezzoStandard
        Dim PrezzoSlowOrig As Decimal = PrezzoSlow

        PrezzoFast = Math.Ceiling(PrezzoFast)
        PrezzoStandard = Math.Round(PrezzoStandard)
        PrezzoSlow = Math.Floor(PrezzoSlow)

        Dim TipoPrezzoToShow As enTipoPrezzoToShow = enTipoPrezzoToShow.TotaleNetto

        Try
            TipoPrezzoToShow = rdoOpzioniPrezzo.SelectedValue
        Catch ex As Exception

        End Try

        If TipoPrezzoToShow = enTipoPrezzoToShow.CadNetto Then
            NumeroDecimali = 4
        End If

        'per avere piu precisione calcolo l'iva sul mucchio
        'e poi in caso divido per la quantità
        If TipoPrezzoToShow = enTipoPrezzoToShow.TotaleIVACompresa Then
            PrezzoFast = PrezzoFast + FormerLib.FormerHelper.Finanziarie.CalcolaIva(PrezzoFast)
            PrezzoStandard = PrezzoStandard + FormerLib.FormerHelper.Finanziarie.CalcolaIva(PrezzoStandard)
            PrezzoSlow = PrezzoSlow + FormerLib.FormerHelper.Finanziarie.CalcolaIva(PrezzoSlow)
        ElseIf TipoPrezzoToShow = enTipoPrezzoToShow.CadNetto Then

            PrezzoFast = Math.Round(PrezzoFast / NumeroPezziScelti, NumeroDecimali)
            PrezzoStandard = Math.Round(PrezzoStandard / NumeroPezziScelti, NumeroDecimali)
            PrezzoSlow = Math.Round(PrezzoSlow / NumeroPezziScelti, NumeroDecimali)

        End If

        If P.ggFast Then
            C = New TableCell

            If PrezzoFastOrig <= FormerConst.MassimaliPrezzi.Fast Then

                'Dim PrezzoEtichetta As Decimal = PrezzoFast

                'ìPrezzoEtichetta = 521

                If NumeroPezziScelti = SelectedVal AndAlso TipoDataSelezionata.StartsWith("F") Then
                    C.CssClass = "CellaPrezzo bkgSelected"
                    C.Text = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoFast, NumeroDecimali)
                Else
                    C.CssClass = "CellaPrezzo bkgFast"
                    Dim lblQta As New LinkButton
                    lblQta.CssClass = "lblQta"
                    lblQta.ID = "lblQtaF" & NumeroPezziScelti
                    lblQta.CommandArgument = "F" & D.DataFast.ToString("ddMMyyyy") & "§" & NumeroPezziScelti

                    lblQta.Text = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoFast, NumeroDecimali)
                    AddHandler lblQta.Click, AddressOf ClickQtaLabel
                    C.Controls.Add(lblQta)
                End If

                R.Cells.Add(C)

            Else
                C.CssClass = "CellaPrezzo"
                C.Text = "-"
                R.Cells.Add(C)
                If NumeroPezziScelti = SelectedVal AndAlso TipoDataSelezionata.StartsWith("F") Then
                    Dim NuovaEtichetta As String = "N" & D.DataNormale.ToString("ddMMyyyy") & "§" & NumeroPezziScelti
                    TipoDataSelezionata = NuovaEtichetta
                End If

            End If
        End If

        If P.ggNorm Then
            C = New TableCell

            'Dim PrezzoEtichetta As Decimal = PrezzoStandard

            Dim ShowPrice As Boolean = True

            If PrezzoStandardOrig > FormerConst.MassimaliPrezzi.Normal Then

                If P.ggSlow Then
                    ShowPrice = False
                    If NumeroPezziScelti = SelectedVal AndAlso TipoDataSelezionata.StartsWith("N") Then
                        Dim NuovaEtichetta As String = "S" & D.DataSlow.ToString("ddMMyyyy") & "§" & NumeroPezziScelti
                        TipoDataSelezionata = NuovaEtichetta
                    End If
                End If

            End If

            If ShowPrice Then
                If NumeroPezziScelti = SelectedVal AndAlso TipoDataSelezionata.StartsWith("N") Then
                    C.CssClass = "CellaPrezzo bkgSelected"
                    C.Text = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard, NumeroDecimali)
                Else

                    C.CssClass = "CellaPrezzo bkgNormal"

                    Dim lblQta As New LinkButton
                    lblQta.ID = "lblQtaN" & NumeroPezziScelti
                    lblQta.CssClass = "lblQta"
                    lblQta.CommandArgument = "N" & D.DataNormale.ToString("ddMMyyyy") & "§" & NumeroPezziScelti

                    lblQta.Text = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard, NumeroDecimali)
                    C.Controls.Add(lblQta)
                    AddHandler lblQta.Click, AddressOf ClickQtaLabel
                End If
            Else
                C.CssClass = "CellaPrezzo"
                C.Text = "-"
            End If

            R.Cells.Add(C)

        End If

        If P.ggSlow Then

            'Dim PrezzoEtichetta As Decimal = PrezzoSlow

            C = New TableCell
            Dim Etichetta As String = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoSlow, NumeroDecimali)

            Dim PrezzoPromo As Decimal = 0 'PrezzoSlow

            'qui controllo se per caso c'è un promo
            Dim Pr As PromoW = LRif.Promo
            If Not Pr Is Nothing Then

                Select Case TipoPrezzoToShow
                    Case enTipoPrezzoToShow.TotaleNetto
                        PrezzoPromo = Pr.GetPrezzoPromo(PrezzoSlow)
                    Case enTipoPrezzoToShow.CadNetto
                        PrezzoPromo = Pr.GetPrezzoPromo(PrezzoSlow, True)
                    Case enTipoPrezzoToShow.TotaleIVACompresa
                        PrezzoPromo = Pr.GetPrezzoPromo(PrezzoSlowOrig)
                        PrezzoPromo = PrezzoPromo + FormerLib.FormerHelper.Finanziarie.CalcolaIva(PrezzoPromo)


                End Select

                'PrezzoPromo = Pr.GetPrezzoPromo(PrezzoSlow, IIf(TipoPrezzoToShow <> enTipoPrezzoToShow.TotaleNetto, True, False))

                Etichetta = "<div class=""prezzoBarrato"">" & Etichetta & "</div>"
                Etichetta &= "<div class=""prezzoPromo"">" & FormerHelper.Stringhe.FormattaPrezzo(PrezzoPromo, NumeroDecimali) & "</div>"

            End If

            If NumeroPezziScelti = SelectedVal AndAlso TipoDataSelezionata.StartsWith("S") Then
                C.CssClass = "CellaPrezzo bkgSelected"
                C.Text = Etichetta
            Else

                C.CssClass = "CellaPrezzo bkgSlow"

                Dim lblQta As New LinkButton
                lblQta.ID = "lblQtaS" & NumeroPezziScelti
                lblQta.CssClass = "lblQta"
                lblQta.CommandArgument = "S" & D.DataSlow.ToString("ddMMyyyy") & "§" & NumeroPezziScelti

                lblQta.Text = Etichetta
                AddHandler lblQta.Click, AddressOf ClickQtaLabel
                C.Controls.Add(lblQta)
            End If

            R.Cells.Add(C)
        End If

        Return R

    End Function

    'Private Function CreaRigaTabella(Qta As Integer,
    '                                 QtaCouponDisp As List(Of Integer),
    '                                 SelectedVal As Integer,
    '                                 D As RisDataConsegna,
    '                                 ByRef ElencoPrezzi As List(Of Decimal)) As TableRow

    '    '_QtaCaricate.Add(Qta)

    '    Dim NumeroPezziScelti As Integer = Qta
    '    Dim QtaSecondaria As Single = 0
    '    Dim R As New TableRow
    '    Dim EtichettaQta As String = FormerLib.FormerHelper.Stringhe.FormattaNumero(Qta)
    '    If QtaCouponDisp.FindAll(Function(x) x = Qta).Count <> 0 Then EtichettaQta &= " *"

    '    Dim C As New TableCell
    '    If Qta = SelectedVal Then
    '        C.CssClass = "CellaQta bkgSelected"
    '    Else
    '        C.CssClass = "CellaQta bkgQta"
    '    End If
    '    C.Text = EtichettaQta

    '    R.Cells.Add(C)

    '    Dim PrezzoCalcolatoNetto As Decimal = 0

    '    Dim NumeroPezzi As Integer = Qta
    '    Dim QtaToCalc As Single = Qta

    '    If LRif.ConSoggettiDuplicati = enSiNo.Si Then
    '        QtaSecondaria = NumeroPezziScelti
    '    End If

    '    If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
    '        QtaToCalc = CalcolaMq(Qta).Mq
    '    End If

    '    If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
    '        QtaToCalc = CalcolaFogli(Qta).NumeroFogli
    '    End If

    '    Dim RPI As RisPrezzoIntermedio = CalcolaPrezzi(QtaToCalc,
    '                                                    QtaSecondaria,
    '                                                    NumeroPezzi)

    '    If UtenteConnesso.Tipo = enTipoRubrica.Cliente Then
    '        PrezzoCalcolatoNetto = RPI.PrezzoPubbl
    '    Else
    '        PrezzoCalcolatoNetto = RPI.PrezzoRiv
    '    End If

    '    Dim IncludiPrezzo As Boolean = True

    '    If ElencoPrezzi.FindAll(Function(x) x = PrezzoCalcolatoNetto).Count Then
    '        If LRif.TipoPrezzo <> enTipoPrezzo.SuMetriQuadri AndAlso LRif.TipoPrezzo <> enTipoPrezzo.SuFoglio Then
    '            IncludiPrezzo = False
    '        End If
    '    End If
    '    If IncludiPrezzo Then
    '        If ElencoPrezzi.FindAll(Function(x) x = PrezzoCalcolatoNetto).Count = 0 Then ElencoPrezzi.Add(PrezzoCalcolatoNetto)
    '        'qui devo calcolare i tre prezzi e aggiungere le 3 celle

    '        Dim PrezzoFast As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeFast(P)
    '        Dim PrezzoStandard As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeNormale
    '        Dim PrezzoSlow As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeSlow(P)

    '        PrezzoFast = Math.Ceiling(PrezzoFast)
    '        PrezzoStandard = Math.Round(PrezzoStandard)
    '        PrezzoSlow = Math.Floor(PrezzoSlow)

    '        If P.ggFast Then
    '            C = New TableCell

    '            If Qta = SelectedVal AndAlso TipoDataSelezionata.StartsWith("F") Then
    '                C.CssClass = "CellaPrezzo bkgSelected"
    '                C.Text = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoFast)
    '            Else
    '                C.CssClass = "CellaPrezzo bkgFast"
    '                Dim lblQta As New LinkButton
    '                lblQta.CssClass = "lblQta"
    '                lblQta.ID = "lblQtaF" & Qta
    '                lblQta.CommandArgument = "F" & D.DataFast.ToString("ddMMyyyy") & "§" & Qta

    '                lblQta.Text = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoFast)
    '                AddHandler lblQta.Click, AddressOf ClickQtaLabel
    '                C.Controls.Add(lblQta)
    '            End If

    '            R.Cells.Add(C)
    '        End If

    '        If P.ggNorm Then
    '            C = New TableCell
    '            If Qta = SelectedVal AndAlso TipoDataSelezionata.StartsWith("N") Then
    '                C.CssClass = "CellaPrezzo bkgSelected"
    '                C.Text = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard)
    '            Else

    '                C.CssClass = "CellaPrezzo bkgNormal"

    '                Dim lblQta As New LinkButton
    '                lblQta.ID = "lblQtaN" & Qta
    '                lblQta.CssClass = "lblQta"
    '                lblQta.CommandArgument = "N" & D.DataNormale.ToString("ddMMyyyy") & "§" & Qta

    '                lblQta.Text = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard)
    '                C.Controls.Add(lblQta)
    '                AddHandler lblQta.Click, AddressOf ClickQtaLabel
    '            End If

    '            R.Cells.Add(C)

    '        End If

    '        If P.ggSlow Then
    '            C = New TableCell
    '            Dim Etichetta As String = "&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoSlow)

    '            Dim PrezzoPromo As Decimal = PrezzoSlow

    '            'qui controllo se per caso c'è un promo
    '            Dim Pr As PromoW = LRif.Promo
    '            If Not Pr Is Nothing Then
    '                PrezzoPromo = Pr.GetPrezzoPromo(PrezzoSlow)
    '                Etichetta = "<div class=""prezzoBarrato"">" & Etichetta & "</div>"
    '                Etichetta &= "<div class=""prezzoPromo"">" & FormerHelper.Stringhe.FormattaPrezzo(PrezzoPromo) & "</div>"

    '            End If

    '            If Qta = SelectedVal AndAlso TipoDataSelezionata.StartsWith("S") Then
    '                C.CssClass = "CellaPrezzo bkgSelected"
    '                C.Text = Etichetta
    '            Else

    '                C.CssClass = "CellaPrezzo bkgSlow"

    '                Dim lblQta As New LinkButton
    '                lblQta.ID = "lblQtaS" & Qta
    '                lblQta.CssClass = "lblQta"
    '                lblQta.CommandArgument = "S" & D.DataSlow.ToString("ddMMyyyy") & "§" & Qta

    '                lblQta.Text = Etichetta
    '                AddHandler lblQta.Click, AddressOf ClickQtaLabel
    '                C.Controls.Add(lblQta)
    '            End If

    '            R.Cells.Add(C)
    '        End If
    '    Else
    '        R = Nothing
    '    End If

    '    Return R

    'End Function

    Private Sub CaricaHandlerTabella()

        If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.Tabella Then

            'qui devo rimuovere i vecchi handler

            Dim RisDate As RisDataConsegna = GetDateConsegna()

            'TOLTO OGGI
            'If LRif.TipoPrezzo = enTipoPrezzo.SuQuantita Then 'default 
            'ddlQta.Items.Add("Selezionare una quantità")
            Using mgr As New MgrQtaListinoBase
                Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                Dim QtaAggiunta As Integer = QtaCustomValidata()

                If QtaAggiunta <> 0 Then

                    For Each qtaC As Integer In GetListaQtaCustom(QtaAggiunta)
                        If lQta.FindAll(Function(x) x = qtaC).Count = 0 Then
                            lQta.Add(qtaC)
                        End If
                    Next
                    lQta.Sort(Function(x, y) x.CompareTo(y))
                End If

                If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio OrElse
                       LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                    'creo una vista di soli sei valori 
                    Dim lqtaVista As New List(Of Integer)
                    Dim ValorePrima As Integer = 0
                    For i = 0 To lQta.Count - 1

                        If lQta(i) = QtaAggiunta Then
                            If i > 0 Then
                                lqtaVista.Add(lQta(i - 1))
                            End If
                            lqtaVista.Add(lQta(i))
                        ElseIf lQta(i) > QtaAggiunta Then
                            lqtaVista.Add(lQta(i))
                        End If
                        If lqtaVista.Count > 8 Then Exit For
                    Next
                    lqtaVista.Sort(Function(x, y) x.CompareTo(y))
                    lQta = lqtaVista
                End If

                For Each ValQta As Integer In lQta
                    'Dim QtaS As String = FormerLib.FormerHelper.Stringhe.FormattaNumero(ValQta)
                    'If QtaCouponDisp.FindAll(Function(x) x = LRif.qta1).Count <> 0 Then QtaS &= " *"
                    'ddlQta.Items.Add(New ListItem(ValQta, ValQta))
                    'qui devo se possibile rimuovere i vecchi handler 
                    Try
                        tblPrezzi.Rows.Add(CreaHandlerTabella(ValQta, RisDate))
                    Catch ex As Exception

                    End Try

                Next
            End Using
            'Dim QtaS As String = LRif.qta1

            'tblPrezzi.Rows.Add(CreaHandlerTabella(LRif.qta1, RisDate))
            ''lPrezzi.Add(New RigaTabellaPrezzi With {.Qta = LRif.qta1})

            'If LRif.MoltiplicatoreQta Then
            '    Dim QtaIniziale As Integer = LRif.qta1 + LRif.MoltiplicatoreQta
            '    Dim QtaFinale As Integer = LRif.qta2 - LRif.MoltiplicatoreQta
            '    For valore As Integer = QtaIniziale To QtaFinale Step LRif.MoltiplicatoreQta
            '        Dim ValoreInt As Integer = valore
            '        '                        ddlQta.Items.Add(New ListItem(QtaS, ValoreInt))
            '        tblPrezzi.Rows.Add(CreaHandlerTabella(ValoreInt, RisDate))
            '        'lPrezzi.Add(New RigaTabellaPrezzi With {.Qta = ValoreInt})
            '    Next
            'End If

            ''If LRif.qta1 = 100 And LRif.qta2 = 1000 Then
            ''    Dim QtaSpec As Integer = 200
            ''    QtaS = QtaSpec
            ''    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
            ''    ddlQta.Items.Add(New ListItem(QtaS, 200))
            ''    QtaSpec = 300
            ''    QtaS = QtaSpec
            ''    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
            ''    ddlQta.Items.Add(New ListItem(QtaS, 300))
            ''    QtaSpec = 500
            ''    QtaS = QtaSpec
            ''    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
            ''    ddlQta.Items.Add(New ListItem(QtaS, 500))
            ''    VoceDaSelezionare = 4
            ''End If

            'For I As Integer = LRif.qta2 To LRif.qta6 Step LRif.qta2
            '    Dim VarI As Integer = I
            '    If _QtaCaricate.FindAll(Function(x) x = VarI).Count = 0 Then
            '        tblPrezzi.Rows.Add(CreaHandlerTabella(VarI, RisDate))
            '        'lPrezzi.Add(New RigaTabellaPrezzi With {.Qta = VarI})
            '        'ddlQta.Items.Add(New ListItem(QtaS, I))
            '    End If
            'Next
            'End If

        End If

    End Sub

    Private Function GetListaQtaCustom(QtaAggiunta As Integer) As List(Of Integer)

        Dim LQtaCustom As New List(Of Integer)
        LQtaCustom.Add(QtaAggiunta)

        If QtaAggiunta < LRif.qta1 Then
            'qui aggiungo 2 qta calcolate come intermedi se disponibili

            Dim Diff As Integer = LRif.qta1 - QtaAggiunta
            Dim Moltiplicatore As Integer = Math.Floor(Diff / 4)
            Dim PrimoStep As Integer = Moltiplicatore 'Diff / 2 'Moltiplicatore 'Diff / 2
            Dim SecondoStep As Integer = Moltiplicatore * 2 'PrimoStep / 2 'Moltiplicatore * 3 'PrimoStep / 2
            Dim TerzoStep As Integer = Moltiplicatore * 3

            PrimoStep += QtaAggiunta
            SecondoStep += QtaAggiunta
            TerzoStep += QtaAggiunta

            Dim Arrotondamento As Integer = 0

            If Diff < 25 Then
                Arrotondamento = 5
            ElseIf Diff >= 25 And Diff <= 50 Then
                Arrotondamento = 10
            Else
                Arrotondamento = 25
            End If

            PrimoStep = MgrPreventivazioneB.ArrotondaQtaConMoltiplicatore(PrimoStep, LRif, Arrotondamento)
            If LQtaCustom.FindAll(Function(x) x = PrimoStep).Count = 0 Then LQtaCustom.Add(PrimoStep)
            SecondoStep = MgrPreventivazioneB.ArrotondaQtaConMoltiplicatore(SecondoStep, LRif, Arrotondamento)
            If LQtaCustom.FindAll(Function(x) x = SecondoStep).Count = 0 Then LQtaCustom.Add(SecondoStep)
            TerzoStep = MgrPreventivazioneB.ArrotondaQtaConMoltiplicatore(TerzoStep, LRif, Arrotondamento)
            If LQtaCustom.FindAll(Function(x) x = TerzoStep).Count = 0 Then LQtaCustom.Add(TerzoStep)
        End If

        Return LQtaCustom
    End Function


    Private Property AlterateMisure As Integer
        Get
            Return ViewState("AlterateMisure")
        End Get
        Set(value As Integer)
            ViewState("AlterateMisure") = value
        End Set
    End Property

    Private ReadOnly Property MisureInseriteValide As Boolean
        Get
            Dim ris As Boolean = True

            If ShowBloccoMisure() Then
                Try
                    If IsNumeric(txtAltezza.Text) Then
                        If Val(txtAltezza.Text) = 0 Then
                            ris = False
                        End If
                    Else
                        ris = False
                    End If
                Catch ex As Exception

                End Try

                Try
                    If IsNumeric(txtLarghezza.Text) Then
                        If Val(txtLarghezza.Text) = 0 Then
                            ris = False
                        End If
                    Else
                        ris = False
                    End If
                Catch ex As Exception

                End Try

                If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
                    Try
                        If IsNumeric(txtProfondita.Text) Then
                            If Val(txtProfondita.Text) = 0 Then
                                ris = False
                            End If
                        Else
                            ris = False
                        End If
                    Catch ex As Exception

                    End Try
                End If

            End If


            Return ris
        End Get
    End Property

    Private Sub CaricaQtaTabella()

        If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.Tabella Then

            '_QtaCaricate.Clear()

            Dim OldVal As Integer = 0
            'If ddlQta.SelectedValue.Length <> 0 Then
            '    OldVal = ddlQta.SelectedValue
            'End If
            OldVal = GetQtaSelezionata()

            'calcolo sempre che alla prima riga ci stanno le date 
            'Dim Counter As Integer = 0

            'Dim lPrezzi As New List(Of RigaTabellaPrezzi)

            tblPrezzi.Rows.Clear()

            'qui devo aggiungere le 3 date

            Dim RDate As New TableRow

            Dim CLblQta As New TableCell
            CLblQta.Text = "Quantità"
            CLblQta.CssClass = "CellaLblQta"

            RDate.Cells.Add(CLblQta) 'cella vuota corrispondente alla colonna quantità

            Dim RisDate As RisDataConsegna = GetDateConsegna()

            If Not IsPostBack Then _QuandoSelected = "N" & RisDate.DataNormale.ToString("ddMMyyyy")

            If P.ggFast Then

                Dim Etichetta As String = "<div class=""calendarioTbl""><div class=""giornoTxt"">" & StrConv(RisDate.DataFast.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNum"">" & RisDate.DataFast.ToString("dd") & "</div><div class=""mese"">" & RisDate.DataFast.ToString("MMMM") & "</div></div>"
                Dim cData As New TableCell
                cData.Text = Etichetta
                cData.CssClass = "CellaData bkgFast"
                RDate.Cells.Add(cData)
            End If

            If P.ggNorm Then
                'metto la if solo per dare uno scope alle variabili
                Dim Etichetta As String = "<div class=""calendarioTbl""><div class=""giornoTxt"">" & StrConv(RisDate.DataNormale.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNum"">" & RisDate.DataNormale.ToString("dd") & "</div><div class=""mese"">" & RisDate.DataNormale.ToString("MMMM") & "</div></div>"
                Dim cData As New TableCell
                cData.Text = Etichetta
                cData.CssClass = "CellaData bkgNormal"
                RDate.Cells.Add(cData)

            End If

            If P.ggSlow Then
                Dim Etichetta As String = String.Empty
                Dim Pr As PromoW = LRif.Promo
                If Not Pr Is Nothing Then
                    Etichetta = "<div class=""calendarioPromoTbl""><div class=""giornoTxtPromo"">" & StrConv(RisDate.DataSlow.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNum"">" & RisDate.DataSlow.ToString("dd") & "</div><div class=""mese"">" & RisDate.DataSlow.ToString("MMMM") & "</div></div><div class='labelPromo'>Promo</div>"
                Else
                    Etichetta = "<div class=""calendarioTbl""><div class=""giornoTxt"">" & StrConv(RisDate.DataSlow.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNum"">" & RisDate.DataSlow.ToString("dd") & "</div><div class=""mese"">" & RisDate.DataSlow.ToString("MMMM") & "</div></div>"
                End If

                Dim cData As New TableCell
                cData.Text = Etichetta
                cData.CssClass = "CellaData bkgSlow"
                RDate.Cells.Add(cData)

            End If

            tblPrezzi.Rows.Add(RDate)

            'For Each r As TableRow In tblPrezzi.Rows

            '    If Counter > 0 Then
            '        tblPrezzi.Rows.Remove(r)
            '    End If

            '    Counter += 1

            'Next

            Dim CaricaPrezzi As Boolean = True

            If AlterateMisure OrElse MisureInseriteValide = False Then
                CaricaPrezzi = False
            End If

            If CaricaPrezzi Then

                Dim QtaCouponDisp As New List(Of Integer)

                For Each SingC As CouponW In CouponDisponibili
                    If QtaCouponDisp.FindAll(Function(x) x = SingC.QtaSpecifica).Count = 0 Then QtaCouponDisp.Add(SingC.QtaSpecifica)
                Next


                'TOLTO OGGI
                'If LRif.TipoPrezzo = enTipoPrezzo.SuQuantita Then 'default 
                'ddlQta.Items.Add("Selezionare una quantità")

                Dim VoceDaSelezionare As Integer = 3
                'Dim VoceDaSelezionare As Integer = 3

                If LRif.QtaDefault <> 0 Then
                    VoceDaSelezionare = LRif.QtaDefault
                End If

                If LRif.MoltiplicatoreQta Then
                    VoceDaSelezionare = 1
                End If

                Dim QtaDaSelezionare As Integer = 0
                Select Case VoceDaSelezionare
                    Case 1
                        QtaDaSelezionare = LRif.qta1
                    Case 2
                        QtaDaSelezionare = LRif.qta2
                    Case 3
                        QtaDaSelezionare = LRif.qta3
                    Case 4
                        QtaDaSelezionare = LRif.qta4
                    Case 5
                        QtaDaSelezionare = LRif.qta5
                    Case 6
                        QtaDaSelezionare = LRif.qta6
                End Select

                If QtaSelezionata = 0 Then
                    QtaSelezionata = QtaDaSelezionare
                End If

                Using mgr As New MgrQtaListinoBase
                    Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                    Dim QtaAggiunta As Integer = QtaCustomValidata()

                    If QtaAggiunta <> 0 Then

                        For Each qtaC As Integer In GetListaQtaCustom(QtaAggiunta)
                            If lQta.FindAll(Function(x) x = qtaC).Count = 0 Then
                                lQta.Add(qtaC)
                            End If
                        Next
                        lQta.Sort(Function(x, y) x.CompareTo(y))
                    End If

                    Dim ListaRichiestePrezzo As New List(Of RichiestaCalcoloPrezzo)

                    If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio OrElse
                       LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                        Dim MaxValoriDaMostrare As Integer = 8
                        'creo una vista di soli sei valori 
                        Dim lqtaVista As New List(Of Integer)
                        Dim ValorePrima As Integer = 0
                        For i = 0 To lQta.Count - 1

                            If lQta(i) = QtaAggiunta Then
                                If i > 0 Then
                                    lqtaVista.Add(lQta(i - 1))
                                End If
                                lqtaVista.Add(lQta(i))
                            ElseIf lQta(i) > QtaAggiunta Then
                                lqtaVista.Add(lQta(i))
                            End If
                            If lqtaVista.Count > MaxValoriDaMostrare Then Exit For
                        Next
                        lqtaVista.Sort(Function(x, y) x.CompareTo(y))
                        lQta = lqtaVista
                    End If

                    For Each ValQta As Integer In lQta
                        Dim r As New RichiestaCalcoloPrezzo
                        r.QtaRichiesta = ValQta
                        r.QtaDaUsareNelCalcoloLavorazioni = ValQta

                        If r.QtaRichiesta = LRif.qta1 OrElse
                                r.QtaRichiesta = LRif.qta2 OrElse
                                r.QtaRichiesta = LRif.qta3 OrElse
                                r.QtaRichiesta = LRif.qta4 OrElse
                                r.QtaRichiesta = LRif.qta5 OrElse
                                r.QtaRichiesta = LRif.qta6 OrElse
                                r.QtaRichiesta Mod 500 = 0 OrElse
                                r.QtaRichiesta = QtaSelezionata Then
                            r.QtaDaInserireObbligatoriamenteInElenco = True
                            'favorisco le quantita impostate nel listino e quelle divisibili per 500
                        End If


                        'If LRif.ConSoggettiDuplicati = enSiNo.Si Then
                        '    r.QtaDaUsareNelCalcoloLavorazioni = ValQta
                        'End If

                        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                            r.QtaRichiesta = CalcolaMq(ValQta).Mq
                        End If

                        If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                            r.QtaRichiesta = CalcolaFogli(ValQta).NumeroFogli
                        End If
                        If r.QtaRichiesta = -1 Then r.AnomaliaPrezzoCalcolato = True
                        ListaRichiestePrezzo.Add(r)
                    Next

                    Dim ListaPrezziFinali As List(Of RisPrezzoIntermedio) = CalcolaPrezzi(ListaRichiestePrezzo)

                    If ListaPrezziFinali.FindAll(Function(x) x.RichiestaCalcoloPrezzo.AnomaliaPrezzoCalcolato = True).Count Then
                        CaricaPrezzi = False
                    Else
                        Dim ElencoPrezzi As New List(Of Decimal)

                        For Each risultato In ListaPrezziFinali.FindAll(Function(x) x.RichiestaCalcoloPrezzo.QtaDaInserireObbligatoriamenteInElenco)
                            ElencoPrezzi.Add(risultato.PrezzoRiv)
                        Next

                        For Each risultato In ListaPrezziFinali
                            Dim IncludiPrezzo As Boolean = True
                            If ElencoPrezzi.FindAll(Function(x) x = risultato.PrezzoRiv).Count <> 0 Then
                                If LRif.TipoPrezzo <> enTipoPrezzo.SuMetriQuadri AndAlso
                                LRif.TipoPrezzo <> enTipoPrezzo.SuFoglio Then
                                    If risultato.RichiestaCalcoloPrezzo.QtaDaInserireObbligatoriamenteInElenco = False Then
                                        IncludiPrezzo = False
                                    End If

                                End If
                            Else
                                ElencoPrezzi.Add(risultato.PrezzoRiv)
                            End If

                            If IncludiPrezzo Then
                                Dim rigaDaAggiungere As TableRow = CreaRigaTabellaEx(risultato,
                                                                                 QtaCouponDisp,
                                                                                 OldVal,
                                                                                 RisDate)
                                If Not rigaDaAggiungere Is Nothing Then tblPrezzi.Rows.Add(rigaDaAggiungere)

                            End If
                        Next

                        '    Dim ListaPrezzi As New List(Of Decimal)
                        '    For Each ValQta As Integer In lQta
                        '        'Dim QtaS As String = FormerLib.FormerHelper.Stringhe.FormattaNumero(ValQta)
                        '        'If QtaCouponDisp.FindAll(Function(x) x = LRif.qta1).Count <> 0 Then QtaS &= " *"
                        '        'ddlQta.Items.Add(New ListItem(ValQta, ValQta))

                        '        Dim rigaDaAggiungere As TableRow = CreaRigaTabella(ValQta, QtaCouponDisp, OldVal, RisDate, ListaPrezzi)
                        '        If Not rigaDaAggiungere Is Nothing Then tblPrezzi.Rows.Add(rigaDaAggiungere)
                        '    Next
                    End If


                End Using

            End If

            'lo faccio cosi perche caricaprezzi potrebbe cambiare anche dentro la funzione di caricamento una volta fatti i calcoli 
            If CaricaPrezzi = False Then
                'carico la riga vuota 
                Dim R As New TableRow
                Dim EtichettaQta As String = "-"

                Dim C As New TableCell
                C.CssClass = "CellaQta bkgQta"
                C.Text = EtichettaQta

                R.Cells.Add(C)

                If P.ggFast Then
                    C = New TableCell

                    C.CssClass = "CellaPrezzo bkgFast"
                    C.Text = "-"
                    R.Cells.Add(C)
                End If

                If P.ggNorm Then
                    C = New TableCell

                    C.CssClass = "CellaPrezzo bkgFast"
                    C.Text = "-"
                    R.Cells.Add(C)

                End If

                If P.ggSlow Then
                    C = New TableCell

                    C.CssClass = "CellaPrezzo bkgFast"
                    C.Text = "-"
                    R.Cells.Add(C)
                End If

                tblPrezzi.Rows.Add(R)

            End If



            'Dim QtaS As String = LRif.qta1
            'QtaS = FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaS)
            'If QtaCouponDisp.FindAll(Function(x) x = LRif.qta1).Count <> 0 Then QtaS &= " *"
            ''ddlQta.Items.Add(New ListItem(QtaS, LRif.qta1))

            'tblPrezzi.Rows.Add(CreaRigaTabella(LRif.qta1, QtaCouponDisp, OldVal, RisDate))
            ''lPrezzi.Add(New RigaTabellaPrezzi With {.Qta = LRif.qta1})

            'If LRif.MoltiplicatoreQta Then
            '    Dim QtaIniziale As Integer = LRif.qta1 + LRif.MoltiplicatoreQta
            '    Dim QtaFinale As Integer = LRif.qta2 - LRif.MoltiplicatoreQta
            '    For valore As Integer = QtaIniziale To QtaFinale Step LRif.MoltiplicatoreQta
            '        Dim ValoreInt As Integer = valore
            '        QtaS = ValoreInt
            '        QtaS = FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaS)
            '        If QtaCouponDisp.FindAll(Function(x) x = ValoreInt).Count <> 0 Then QtaS &= " *"
            '        '                        ddlQta.Items.Add(New ListItem(QtaS, ValoreInt))
            '        tblPrezzi.Rows.Add(CreaRigaTabella(ValoreInt, QtaCouponDisp, OldVal, RisDate))
            '        'lPrezzi.Add(New RigaTabellaPrezzi With {.Qta = ValoreInt})
            '    Next
            'End If

            'If LRif.qta1 = 100 And LRif.qta2 = 1000 Then
            '    Dim QtaSpec As Integer = 200
            '    QtaS = QtaSpec
            '    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
            '    ddlQta.Items.Add(New ListItem(QtaS, 200))
            '    QtaSpec = 300
            '    QtaS = QtaSpec
            '    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
            '    ddlQta.Items.Add(New ListItem(QtaS, 300))
            '    QtaSpec = 500
            '    QtaS = QtaSpec
            '    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
            '    ddlQta.Items.Add(New ListItem(QtaS, 500))
            '    VoceDaSelezionare = 4
            'End If

            'For I As Integer = LRif.qta2 To LRif.qta6 Step LRif.qta2
            '    Dim VarI As Integer = I
            '    If _QtaCaricate.FindAll(Function(x) x = VarI).Count = 0 Then
            '        tblPrezzi.Rows.Add(CreaRigaTabella(VarI, QtaCouponDisp, OldVal, RisDate))
            '        'lPrezzi.Add(New RigaTabellaPrezzi With {.Qta = VarI})
            '        'ddlQta.Items.Add(New ListItem(QtaS, I))
            '    End If
            'Next

            'Dim SelezionataVocePrecedente As Boolean = False
            'If OldVal Then
            '    If _QtaCaricate.FindAll(Function(x) x = OldVal).Count Then
            '        ' ddlQta.SelectedValue = OldVal
            '        SelezionataVocePrecedente = True
            '    End If
            'End If

            ''If SelezionataVocePrecedente = False Then ddlQta.SelectedIndex = (VoceDaSelezionare - 1)
            'If SelezionataVocePrecedente = False Then

            '    Try
            '        'ddlQta.SelectedValue = QtaDaSelezionare
            '    Catch ex As Exception
            '        'ddlQta.SelectedIndex = (VoceDaSelezionare - 1)
            '    End Try

            'End If

            'Case enTipoPrezzo.SuCopie
            '    For I As Integer = 1 To LRif.qta6 '100
            '        tblPrezzi.Rows.Add(CreaRiga(I, QtaCouponDisp))
            '        'ddlQta.Items.Add(New ListItem(I, I))
            '    Next
            '    'ddlQta.SelectedIndex = 0

            'Case enTipoPrezzo.SuCmQuadri
            '    'ddlQta.Items.Add(New ListItem(500, 500))
            '    tblPrezzi.Rows.Add(CreaRiga(500, QtaCouponDisp))
            '    For I As Integer = 1000 To 10000 Step 1000 '100
            '        tblPrezzi.Rows.Add(CreaRiga(I, QtaCouponDisp))
            '        'ddlQta.Items.Add(New ListItem(I, I))
            '    Next
            '    For I As Integer = 15000 To 50000 Step 5000 '100
            '        tblPrezzi.Rows.Add(CreaRiga(I, QtaCouponDisp))
            '        'ddlQta.Items.Add(New ListItem(I, I))
            '    Next
            '    'ddlQta.SelectedIndex = 1

            'Case enTipoPrezzo.SuMetriQuadri
            '    For I As Integer = 1 To LRif.qta6 '100
            '        tblPrezzi.Rows.Add(CreaRiga(I, QtaCouponDisp))
            '        'ddlQta.Items.Add(New ListItem(I, I))
            '    Next
            '    'ddlQta.SelectedIndex = 0
            '    txtLarghezza.Text = LRif.FormatoProdotto.Fc.Larghezza
            '    txtAltezza.Text = 100 'F.Fc.Larghezza

            'End If

            'tblPrezzi.ClientIDMode = ClientIDMode.Static
            'tblPrezzi.ViewStateMode = ViewStateMode.Enabled

        End If

    End Sub

    Private Sub CaricaQTA()

        'qui prima guardo per vedere se per caso ci sta un valore gia selezionato 
        Dim OldVal As Integer = 0
        'If ddlQta.SelectedValue.Length <> 0 Then
        '    OldVal = ddlQta.SelectedValue
        'End If
        OldVal = GetQtaSelezionata()

        If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.ComboBox Then

            ddlQta.Items.Clear()

            Dim QtaCouponDisp As New List(Of Integer)

            For Each SingC As CouponW In CouponDisponibili
                If QtaCouponDisp.FindAll(Function(x) x = SingC.QtaSpecifica).Count = 0 Then QtaCouponDisp.Add(SingC.QtaSpecifica)
            Next

            Select Case LRif.TipoPrezzo
                Case enTipoPrezzo.SuQuantita, enTipoPrezzo.SuFoglio  'default 

                    'ddlQta.Items.Add("Selezionare una quantità")

                    Dim VoceDaSelezionare As Integer = 3
                    If LRif.QtaDefault <> 0 Then
                        VoceDaSelezionare = LRif.QtaDefault
                    End If
                    Dim QtaDaSelezionare As Integer = 0
                    Select Case VoceDaSelezionare
                        Case 1
                            QtaDaSelezionare = LRif.qta1
                        Case 2
                            QtaDaSelezionare = LRif.qta2
                        Case 3
                            QtaDaSelezionare = LRif.qta3
                        Case 4
                            QtaDaSelezionare = LRif.qta4
                        Case 5
                            QtaDaSelezionare = LRif.qta5
                        Case 6
                            QtaDaSelezionare = LRif.qta6

                    End Select

                    Using mgr As New MgrQtaListinoBase
                        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)

                        For Each ValQta As Integer In lQta
                            Dim QtaS As String = FormerLib.FormerHelper.Stringhe.FormattaNumero(ValQta)
                            If QtaCouponDisp.FindAll(Function(x) x = LRif.qta1).Count <> 0 Then QtaS &= " *"
                            ddlQta.Items.Add(New ListItem(QtaS, ValQta))
                        Next
                    End Using

                    'Dim QtaS As String = LRif.qta1
                    'QtaS = FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaS)
                    'If QtaCouponDisp.FindAll(Function(x) x = LRif.qta1).Count <> 0 Then QtaS &= " *"
                    'ddlQta.Items.Add(New ListItem(QtaS, LRif.qta1))

                    'If LRif.MoltiplicatoreQta Then
                    '    Dim QtaIniziale As Integer = LRif.qta1 + LRif.MoltiplicatoreQta
                    '    Dim QtaFinale As Integer = LRif.qta2 - LRif.MoltiplicatoreQta
                    '    For valore As Integer = QtaIniziale To QtaFinale Step LRif.MoltiplicatoreQta
                    '        Dim ValoreInt As Integer = valore
                    '        QtaS = ValoreInt
                    '        QtaS = FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaS)
                    '        If QtaCouponDisp.FindAll(Function(x) x = ValoreInt).Count <> 0 Then QtaS &= " *"
                    '        ddlQta.Items.Add(New ListItem(QtaS, ValoreInt))
                    '    Next
                    'End If

                    'If LRif.qta1 = 100 And LRif.qta2 = 1000 Then
                    '    Dim QtaSpec As Integer = 200
                    '    QtaS = QtaSpec
                    '    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
                    '    ddlQta.Items.Add(New ListItem(QtaS, 200))
                    '    QtaSpec = 300
                    '    QtaS = QtaSpec
                    '    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
                    '    ddlQta.Items.Add(New ListItem(QtaS, 300))
                    '    QtaSpec = 500
                    '    QtaS = QtaSpec
                    '    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
                    '    ddlQta.Items.Add(New ListItem(QtaS, 500))
                    '    VoceDaSelezionare = 4
                    'End If

                    'For I As Integer = LRif.qta2 To LRif.qta6 Step LRif.qta2
                    '    If ddlQta.Items.FindByValue(I) Is Nothing Then
                    '        QtaS = I
                    '        Dim Indice As Integer = I
                    '        QtaS = FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaS)
                    '        If QtaCouponDisp.FindAll(Function(x) x = Indice).Count <> 0 Then QtaS &= " *"
                    '        ddlQta.Items.Add(New ListItem(QtaS, I))
                    '    End If
                    'Next

                    Dim SelezionataVocePrecedente As Boolean = False
                    If OldVal Then
                        If Not ddlQta.Items.FindByValue(OldVal) Is Nothing Then
                            ddlQta.SelectedValue = OldVal
                            SelezionataVocePrecedente = True
                        End If
                    End If

                    'If SelezionataVocePrecedente = False Then ddlQta.SelectedIndex = (VoceDaSelezionare - 1)
                    If SelezionataVocePrecedente = False Then

                        Try
                            ddlQta.SelectedValue = QtaDaSelezionare
                        Catch ex As Exception
                            ddlQta.SelectedIndex = (VoceDaSelezionare - 1)
                        End Try

                    End If

                'Case enTipoPrezzo.SuCopie'TODO:MODIFICATOTIPOPREZZO

                '    Using mgr As New MgrQtaListinoBase
                '        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                '        For Each ValQta As Integer In lQta
                '            ddlQta.Items.Add(New ListItem(ValQta, ValQta))
                '        Next
                '    End Using

                    'For I As Integer = 1 To LRif.qta6 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
                    'ddlQta.SelectedIndex = 0

                Case enTipoPrezzo.SuCmQuadri
                    Using mgr As New MgrQtaListinoBase
                        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                        For Each ValQta As Integer In lQta
                            ddlQta.Items.Add(New ListItem(ValQta, ValQta))
                        Next
                    End Using
                    'ddlQta.Items.Add(New ListItem(500, 500))
                    'For I As Integer = 1000 To 10000 Step 1000 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
                    'For I As Integer = 15000 To 50000 Step 5000 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
                    ddlQta.SelectedIndex = 1

                Case enTipoPrezzo.SuMetriQuadri
                    Using mgr As New MgrQtaListinoBase
                        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                        For Each ValQta As Integer In lQta
                            ddlQta.Items.Add(New ListItem(ValQta, ValQta))
                        Next
                    End Using
                    'For I As Integer = 1 To LRif.qta6 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
                    ddlQta.SelectedIndex = 0

                    'DISABILITATO PER NON FAR APPARIRE PIU LE MISURE
                    'Dim LatoFisso As Single = LRif.LatoFissoRiferimento

                    'If LRif.LargRotolo.IndexOf("100") <> -1 Then
                    '    LatoFisso = 100
                    'End If

                    'txtLarghezza.Text = LatoFisso 'LRif.FormatoProdotto.Fc.Larghezza
                    'txtAltezza.Text = Math.Round(10000 / LatoFisso) 'F.Fc.Larghezza

            End Select

        ElseIf LRif.TipoControlloPrezzo = enTipoControlloPrezzo.TextBox Then

            txtQtaUser.Text = String.Empty

            Dim QtaCouponDisp As New List(Of Integer)

            For Each SingC As CouponW In CouponDisponibili
                If QtaCouponDisp.FindAll(Function(x) x = SingC.QtaSpecifica).Count = 0 Then QtaCouponDisp.Add(SingC.QtaSpecifica)
            Next

            Select Case LRif.TipoPrezzo
                Case enTipoPrezzo.SuQuantita, enTipoPrezzo.SuFoglio  'default 

                    'ddlQta.Items.Add("Selezionare una quantità")

                    Dim VoceDaSelezionare As Integer = 3
                    If LRif.QtaDefault <> 0 Then
                        VoceDaSelezionare = LRif.QtaDefault
                    End If
                    Dim QtaDaSelezionare As Integer = 0
                    Select Case VoceDaSelezionare
                        Case 1
                            QtaDaSelezionare = LRif.qta1
                        Case 2
                            QtaDaSelezionare = LRif.qta2
                        Case 3
                            QtaDaSelezionare = LRif.qta3
                        Case 4
                            QtaDaSelezionare = LRif.qta4
                        Case 5
                            QtaDaSelezionare = LRif.qta5
                        Case 6
                            QtaDaSelezionare = LRif.qta6

                    End Select



                    'Using mgr As New MgrQtaListinoBase
                    '    Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)

                    '    For Each ValQta As Integer In lQta
                    '        Dim QtaS As String = FormerLib.FormerHelper.Stringhe.FormattaNumero(ValQta)
                    '        If QtaCouponDisp.FindAll(Function(x) x = LRif.qta1).Count <> 0 Then QtaS &= " *"
                    '        ddlQta.Items.Add(New ListItem(QtaS, ValQta))
                    '    Next
                    'End Using

                    'Dim QtaS As String = LRif.qta1
                    'QtaS = FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaS)
                    'If QtaCouponDisp.FindAll(Function(x) x = LRif.qta1).Count <> 0 Then QtaS &= " *"
                    'ddlQta.Items.Add(New ListItem(QtaS, LRif.qta1))

                    'If LRif.MoltiplicatoreQta Then
                    '    Dim QtaIniziale As Integer = LRif.qta1 + LRif.MoltiplicatoreQta
                    '    Dim QtaFinale As Integer = LRif.qta2 - LRif.MoltiplicatoreQta
                    '    For valore As Integer = QtaIniziale To QtaFinale Step LRif.MoltiplicatoreQta
                    '        Dim ValoreInt As Integer = valore
                    '        QtaS = ValoreInt
                    '        QtaS = FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaS)
                    '        If QtaCouponDisp.FindAll(Function(x) x = ValoreInt).Count <> 0 Then QtaS &= " *"
                    '        ddlQta.Items.Add(New ListItem(QtaS, ValoreInt))
                    '    Next
                    'End If

                    'If LRif.qta1 = 100 And LRif.qta2 = 1000 Then
                    '    Dim QtaSpec As Integer = 200
                    '    QtaS = QtaSpec
                    '    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
                    '    ddlQta.Items.Add(New ListItem(QtaS, 200))
                    '    QtaSpec = 300
                    '    QtaS = QtaSpec
                    '    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
                    '    ddlQta.Items.Add(New ListItem(QtaS, 300))
                    '    QtaSpec = 500
                    '    QtaS = QtaSpec
                    '    If QtaCouponDisp.FindAll(Function(x) x = QtaSpec).Count <> 0 Then QtaS &= " *"
                    '    ddlQta.Items.Add(New ListItem(QtaS, 500))
                    '    VoceDaSelezionare = 4
                    'End If

                    'For I As Integer = LRif.qta2 To LRif.qta6 Step LRif.qta2
                    '    If ddlQta.Items.FindByValue(I) Is Nothing Then
                    '        QtaS = I
                    '        Dim Indice As Integer = I
                    '        QtaS = FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaS)
                    '        If QtaCouponDisp.FindAll(Function(x) x = Indice).Count <> 0 Then QtaS &= " *"
                    '        ddlQta.Items.Add(New ListItem(QtaS, I))
                    '    End If
                    'Next

                    Dim SelezionataVocePrecedente As Boolean = False
                    If OldVal Then
                        txtQtaUser.Text = OldVal
                        SelezionataVocePrecedente = True
                    End If

                    'If SelezionataVocePrecedente = False Then ddlQta.SelectedIndex = (VoceDaSelezionare - 1)
                    If SelezionataVocePrecedente = False Then

                        txtQtaUser.Text = QtaDaSelezionare

                    End If

                'Case enTipoPrezzo.SuCopie'TODO:MODIFICATOTIPOPREZZO

                '    Using mgr As New MgrQtaListinoBase
                '        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                '        txtQtaUser.Text = lQta(0)

                '    End Using

                    'For I As Integer = 1 To LRif.qta6 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
                    'ddlQta.SelectedIndex = 0

                Case enTipoPrezzo.SuCmQuadri
                    Using mgr As New MgrQtaListinoBase
                        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                        txtQtaUser.Text = lQta(1)
                    End Using
                    'ddlQta.Items.Add(New ListItem(500, 500))
                    'For I As Integer = 1000 To 10000 Step 1000 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
                    'For I As Integer = 15000 To 50000 Step 5000 '100
                    '    ddlQta.Items.Add(New ListItem(I, I))
                    'Next
'                    ddlQta.SelectedIndex = 1

'COMMENTATO PER NON AVERE DEFAULT AL CARICAMENTO INIZIALE
                'Case enTipoPrezzo.SuFoglio
                '    txtLarghezza.Text = 5
                '    txtAltezza.Text = 5

                Case enTipoPrezzo.SuMetriQuadri
                    Using mgr As New MgrQtaListinoBase
                        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                        txtQtaUser.Text = lQta(0)

                    End Using

                    'disabilitato per evitare calcolo automatico prezzi
                    'Dim LatoFisso As Single = LRif.LatoFissoRiferimento

                    'If LRif.LargRotolo.IndexOf("100") <> -1 Then
                    '    LatoFisso = 100
                    'End If

                    'txtLarghezza.Text = LatoFisso 'LRif.FormatoProdotto.Fc.Larghezza
                    'txtAltezza.Text = Math.Round(10000 / LatoFisso) 'F.Fc.Larghezza

            End Select

        ElseIf LRif.TipoControlloPrezzo = enTipoControlloPrezzo.Tabella Then
            Select Case LRif.TipoPrezzo
                Case enTipoPrezzo.SuMetriQuadri
                    Using mgr As New MgrQtaListinoBase
                        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                        txtQtaUser.Text = lQta(0)

                    End Using
                    'disabilitato per eliminare calcolautomatico prezzo 
                    'Dim LatoFisso As Single = LRif.LatoFissoRiferimento

                    'If LRif.LargRotolo.IndexOf("100") <> -1 Then
                    '    LatoFisso = 100
                    'End If

                    'txtLarghezza.Text = LatoFisso 'LRif.FormatoProdotto.Fc.Larghezza
                    'txtAltezza.Text = Math.Round(10000 / LatoFisso) 'F.Fc.Larghezza

                    'COMMENTATO PER NON AVERE MISURE AL CARICAMENTO INIZIALE
                    'Case enTipoPrezzo.SuFoglio
                    '    txtLarghezza.Text = 5
                    '    txtAltezza.Text = 5

            End Select
        End If


    End Sub

    Private Sub CaricaColoriDiStampa()

        Dim ListaIdColoriStampa As String = ","

        Dim IdFormProd As Integer = ddlFormato.SelectedValue
        Dim IdTipoCarta As Integer = ddlTipoCarta.SelectedValue

        Dim IdColoreStampaSel As Integer = 0

        Try
            IdColoreStampaSel = ddlColoreStampa.SelectedValue
        Catch ex As Exception

        End Try

        Dim lCS As New List(Of ColoreStampaW)

        Using L As New ListinoBaseWDAO
            Dim lst As List(Of ListinoBaseW)
            lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "idFormato"},
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdPrev),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdTipoCarta, IdTipoCarta),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdFormProd, IdFormProd),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))

            Using mgrP As New PreventivazioniWDAO
                mgrP.OrdinaListinoPerFormatoProd(lst)
            End Using

            For Each singL In lst
                If lCS.FindAll(Function(x) x.IdColoreStampa = singL.IdColoreStampa).Count = 0 Then
                    lCS.Add(singL.ColoreStampa)
                End If
            Next

        End Using

        'ListaIdColoriStampa = "(" & ListaIdColoriStampa.Trim(",") & ")"

        'Using mgr As New ColoriStampaWDAO

        '= mgr.FindAll("Descrizione", New LUNA.LunaSearchParameter("IdColoreStampa", ListaIdColoriStampa, " IN "))

        ddlColoreStampa.DataValueField = "IdColoreStampa"
        ddlColoreStampa.DataTextField = "Descrizione"
        ddlColoreStampa.DataSource = lCS
        ddlColoreStampa.DataBind()

        'End Using

        Try
            If IdColoreStampaSel Then
                ddlColoreStampa.SelectedValue = IdColoreStampaSel
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaTipiDiCarta()

        Dim ListaIdTipoCarta As String = ","
        Dim IdFormProd As Integer = ddlFormato.SelectedValue
        Dim IdTipoCartaSel As Integer = 0

        Try
            IdTipoCartaSel = ddlTipoCarta.SelectedValue
        Catch ex As Exception

        End Try

        Dim lTC As New List(Of TipoCartaW)

        Using L As New ListinoBaseWDAO
            Dim lst As List(Of ListinoBaseW)
            lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "idFormato"},
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdPrev),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdFormProd, IdFormProd),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))

            Using mgrP As New PreventivazioniWDAO
                'mgrP.OrdinaListinoPerFormatoProd(lst)
                mgrP.OrdinaListinoPerGrammaturaCarta(lst)
            End Using

            For Each singL In lst
                If lTC.FindAll(Function(x) x.IdTipoCarta = singL.IdTipoCarta).Count = 0 Then
                    lTC.Add(singL.TipoCarta)
                End If
            Next

        End Using

        'ListaIdTipoCarta = "(" & ListaIdTipoCarta.Trim(",") & ")"

        'Using mgr As New TipiCartaWDAO
        '= mgr.FindAll(New LUNA.LunaSearchParameter("IdTipoCarta", ListaIdTipoCarta, " IN "))

        'l.Sort(Function(x, y) x.Grammi.CompareTo(y.Grammi))

        ddlTipoCarta.DataValueField = "IdTipoCarta"
        ddlTipoCarta.DataTextField = "Tipologia"
        ddlTipoCarta.DataSource = lTC
        ddlTipoCarta.DataBind()
        'End Using

        Try
            If IdTipoCartaSel Then
                ddlTipoCarta.SelectedValue = IdTipoCartaSel
            End If
        Catch ex As Exception

        End Try


    End Sub

    Public Function GetEtichettaMisure() As String
        Dim ris As String = String.Empty
        ris = FormerEnumHelper.TipoUnitaDiMisura(LRif.TipoUnitaMisuraInInput)
        Return ris
    End Function

    Private Sub CaricaFormatiProdotto()

        Dim RisultatoPlugin As cEnum = Nothing

        Dim IdVoceVecchia As Integer = 0

        Try
            IdVoceVecchia = ddlFormato.SelectedValue
        Catch ex As Exception

        End Try

        If P.IdPluginToUse Then
            Select Case P.IdPluginToUse
                Case enPluginOnline.Etichette
                    Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
                    If Not R Is Nothing Then
                        _idFustela = R.IdTipoFustella
                        If R.Categoria.Contains(" ") Then
                            _categoria = R.Categoria.Substring(0, R.Categoria.IndexOf(" "))
                        Else _categoria = R.Categoria
                        End If
                        _BaseEtiquete = R.Base
                        _AltezzaEqitquete = R.Altezza
                        RisultatoPlugin = New cEnum
                        RisultatoPlugin.Id = _IdFormato
                        RisultatoPlugin.Descrizione = R.Base & " x " & R.Altezza & " (" & R.Categoria & ")"
                    End If
                Case enPluginOnline.Packaging
                    Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
                    If Not R Is Nothing Then
                        RisultatoPlugin = New cEnum
                        RisultatoPlugin.Id = IIf(R.IdFormatoProdottoScelto, R.IdFormatoProdottoScelto, _IdFormato) '_IdFormato
                        RisultatoPlugin.Descrizione = R.Base & " x " & R.Altezza & " x " & R.Profondita & " (Chiuso)"
                    End If
                Case enPluginOnline.EtichetteCm
                    Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm))
                    If Not R Is Nothing Then
                        RisultatoPlugin = New cEnum
                        RisultatoPlugin.Id = _IdFormato
                        RisultatoPlugin.Descrizione = R.Base & " x " & R.Altezza & " (" & R.Categoria & ")"
                    End If
            End Select
        Else
            If LRif.idGruppoLogico <> 0 Or LRif.AllowCustomSize = enSiNo.Si Then
                'controllo se è stato utilizzato un plugin
                Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
                If Not R Is Nothing Then
                    RisultatoPlugin = New cEnum
                    RisultatoPlugin.Id = R.IdFormatoProdottoScelto
                    RisultatoPlugin.Descrizione = "Formato personalizzato " & R.Base & " x " & R.Altezza
                End If
            End If
        End If
        If RisultatoPlugin Is Nothing Then
            Dim ListaIdFormatoProdotto As String = ","

            Dim lst As List(Of ListinoBaseW) = Nothing
            Dim lFP As New List(Of FormatoProdottoW)

            Using L As New ListinoBaseWDAO

                lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdFormato"},
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdPrev),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))

                Using mgrP As New PreventivazioniWDAO
                    mgrP.OrdinaListinoPerFormatoProd(lst)
                End Using

                For Each singL In lst
                    If lFP.FindAll(Function(x) x.IdFormProd = singL.IdFormProd).Count = 0 Then
                        lFP.Add(singL.FormatoProdotto)
                    End If
                    '    If ListaIdFormatoProdotto.IndexOf("," & singL.IdFormProd & ",") = -1 Then
                    '        ListaIdFormatoProdotto &= singL.IdFormProd & ","
                    '    End If
                Next

            End Using

            'ListaIdFormatoProdotto = "(" & ListaIdFormatoProdotto.Trim(",") & ")"

            'Using mgr As New FormatiProdottoWDAO
            '    Dim l As List(Of FormatoProdottoW) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FormatoProdottoW.IdFormProd, ListaIdFormatoProdotto, " IN "))
            '    Dim lNew As New List(Of FormatoProdottoW)

            '    Dim Posizione As Integer = 0
            '    For Each Lb As ListinoBaseW In lst

            '        If lNew.FindAll(Function(x) x.IdFormProd = Lb.IdFormProd).Count = 0 Then

            '        End If

            '        Posizione += 1

            '    Next

            '    'l.Sort(AddressOf mgr.OrdinaFormatiProdotto)


            'End Using

            ddlFormato.DataValueField = "IdFormProd"
            ddlFormato.DataTextField = "Formato"
            ddlFormato.DataSource = lFP
            ddlFormato.DataBind()

            If IdVoceVecchia Then
                ddlFormato.SelectedValue = IdVoceVecchia
            End If
        Else
            ddlFormato.Items.Clear()
            ddlFormato.Items.Add(New ListItem(RisultatoPlugin.Descrizione, RisultatoPlugin.Id))
            ddlFormato.DataBind()
        End If

    End Sub

    Public ReadOnly Property ProdottoSceltoStr As String
        Get
            Dim ris As String = String.Empty
            If LRif.FormatoProdotto.ProdottoFinito = False Then
                ris = LRif.Nome
            Else
                ris = P.Descrizione
            End If
            Return ris
        End Get
    End Property
    Private ReadOnly Property QtaLimiteMinVal As Integer
        Get
            Dim Ris As Integer = 1
            If P.IdReparto <> enRepartoWeb.StampaDigitale Then
                If P.IdPluginToUse = enPluginOnline.EtichetteCm Then
                    Ris = FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.QtaMin
                Else
                    Ris = LRif.qta1
                End If
            End If
            Return Ris
        End Get
    End Property
    Public ReadOnly Property QtaLimiteMin As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaLimiteMinVal)
        End Get
    End Property

    Private ReadOnly Property QtaLimiteMaxVal As Integer
        Get
            Dim Ris As Integer = LRif.qta6 ' 100 ' tolto per non avere le 100 copie fisse per il digitale

            If P.IdPluginToUse = enPluginOnline.EtichetteCm OrElse
               LRif.ConSoggettiDuplicati = enSiNo.Si Then
                Ris = FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.QtaMax
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property QtaLimiteMax As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaLimiteMaxVal)
        End Get
    End Property

    Public ReadOnly Property EtichettaFormato As String
        Get
            Dim ris As String = "Formato"

            If LRif.Preventivazione.IdReparto = enRepartoWeb.Ricamo Then
                ris = "Categoria"
            End If

            Return ris
        End Get
    End Property

    Private Function Comparer(ByVal x As CatLavW, ByVal y As CatLavW) As Integer

        Dim result As Integer = x.NumeroLavorazioni(LRif.IdListinoBase).CompareTo(y.NumeroLavorazioni(LRif.IdListinoBase))
        If result = 0 Then result = x.Descrizione.CompareTo(y.Descrizione)
        Return result

    End Function

    Private Sub CaricaLavorazioniDisponibili()

        tableLav.CssClass = "tableLav"
        tableLav.Rows.Clear()

        tblDDL.Rows.Clear()
        tblDDL.Height = 10

        Dim lc As List(Of CatLavW) = LRif.GetCatLav()
        Dim posiz As Integer = 1

        For Each lavorazione In LRif.LavorazioniBase
            If lc.FindAll(Function(x) x.IdCatLav = lavorazione.IdCatLav).Count = 0 And LRif.LavorazioniOpz.FindAll(Function(x) x.IdCatLav = lavorazione.IdCatLav).Count <> 0 Then
                If lavorazione.IdCatLav AndAlso lavorazione.LavorazioneInterna = enSiNo.No Then
                    lc.Add(lavorazione.CatLav)
                End If
            End If
        Next

        For Each lavorazione In LRif.LavorazioniOpz
            If lc.FindAll(Function(x) x.IdCatLav = lavorazione.IdCatLav).Count = 0 Then
                If lavorazione.IdCatLav AndAlso lavorazione.LavorazioneInterna = enSiNo.No Then
                    lc.Add(lavorazione.CatLav)
                End If
            End If
        Next

        'lc.Sort(Function(x, y) x.NumeroLavorazioni(LRif.IdListinoBase).CompareTo(y.NumeroLavorazioni(LRif.IdListinoBase)))
        lc.Sort(AddressOf Comparer)

        Dim lcDDL As List(Of CatLavW) = lc.FindAll(Function(cX) cX.TipoControllo = enTipoControllo.ComboBox)

        For Each Cat As CatLavW In lcDDL
            Dim trDDL As New TableRow

            tblDDL.Rows.Add(trDDL)

            Dim tc As New TableCell
            tc.Text = Cat.Descrizione
            tc.CssClass = "cellaEtichetta"
            trDDL.Cells.Add(tc)

            tc = New TableCell
            tc.CssClass = "cellaValore"

            Dim lLav As List(Of LavorazioneW) = Cat.GetLavorazioniOpzionaliByListinoBase(LRif)

            Dim ddl As New DropDownList
            ddl.ID = "lav" & Cat.IdCatLav
            ddl.Font.Size = 11
            'ddl.Font.Name = "Arial"
            ddl.Font.Bold = False
            ddl.DataValueField = "IdLavoro"
            ddl.DataTextField = "Descrizione"
            ddl.ClientIDMode = UI.ClientIDMode.Inherit ' Static
            ddl.AutoPostBack = True
            Dim misura As New WebControls.Unit(300, UnitType.Pixel)
            ddl.Width = misura

            AddHandler ddl.SelectedIndexChanged, AddressOf SelezioneVoceCombo
            Dim CreareIcoInfo As Boolean = False
            For Each singLav In lLav
                Dim listSing As New ListItem
                If singLav.IdLavoro Then
                    listSing.Attributes("tag") = singLav.Descrizione
                    'listSing.Text = "<div class='imgCheck hasTooltip' style='background: url(" & FormerWebApp.PathListinoImg & singLav.ImgRif & ") no-repeat top left;background-size:48px 48px;'></div><div class=""hidden tooltiptext""><img class=""imgSx"" src=""" & FormerWebApp.PathListinoImg & singLav.ImgRif & """><h4>" & singLav.Descrizione & "</h4>" & singLav.DescrizioneEstesaEx & "</div>"
                    listSing.Text = singLav.Descrizione
                    listSing.Value = singLav.IdLavoro
                Else
                    'qui devo vedere
                    'se esiste una lav della stessa cat tra le base devo aggiungerla e metterla selezionata
                    'altrimenti metto il formato steso
                    'bisogna gestire la descrizione della categoria di lavoro
                    Dim LavBase As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdCatLav = Cat.IdCatLav)

                    If LavBase Is Nothing Then
                        'If Cat.IdCatLav = LUNA.LunaContext.IdCatPieghe Then
                        listSing.Text = "-" '"Non selezionato"
                        'Else
                        '    listSing.Text = "<img class='imgCheck' src='/img/divieto.gif' alt='" & singLav.Descrizione & "'>"
                        'End If
                        'listSing.Text = "<img src='" & FormerWebApp.PathListinoImg & F.ImgRif & "' alt='" & singLav.Descrizione & "'>"
                        'listSing.Text = "<img src='/img/divieto.gif' alt='" & singLav.Descrizione & "'>"
                        'listSing.Selected = True
                        'DescrBase = "Non selezionato"
                        listSing.Value = singLav.IdLavoro
                    Else
                        listSing.Text = LavBase.Descrizione '& "</h4>" & LavBase.DescrizioneEstesaEx & "</div>"
                        'listSing.Selected = True
                        listSing.Value = LavBase.IdLavoro
                        CreareIcoInfo = True
                    End If
                    'listSing.Attributes("tag") = DescrBase
                End If
                ddl.Items.Add(listSing)
            Next

            'ddl.DataSource = lLav
            'ddl.DataBind()

            ListaCombo.Add(ddl)
            tc.Controls.Add(ddl)
            trDDL.Cells.Add(tc)

            tc = New TableCell
            tc.ID = "lavInfo" & Cat.IdCatLav
            trDDL.Cells.Add(tc)

            If CreareIcoInfo Then CreaInfoImg(ddl)

        Next

        If tblDDL.Rows.Count Then
            tblDDL.Visible = True
        Else
            tblDDL.Visible = False
        End If

        Dim tr As New TableRow

        Dim lcNoDDL As List(Of CatLavW) = lc.FindAll(Function(cX) cX.TipoControllo <> enTipoControllo.ComboBox)

        For Each Cat As CatLavW In lcNoDDL
            Dim tc As New TableCell
            Dim lLav As List(Of LavorazioneW) = Cat.GetLavorazioniOpzionaliByListinoBase(LRif)

            If lLav.Count < 4 OrElse Cat.TipoControllo = enTipoControllo.ComboBox Then
                Dim CountPos As Integer = 0
                For Each singCell As TableCell In tr.Cells
                    CountPos += singCell.ColumnSpan
                Next
                If posiz = lc.Count Then
                    tc.ColumnSpan = 2 'va in doppia colonna
                Else
                    tc.ColumnSpan = 1 'posso metterlo in una colonna piccola
                    tc.Width = 280 '255
                End If

                If CountPos >= 2 Then
                    tableLav.Rows.Add(tr)
                    tr = New TableRow
                End If
            Else
                If tr.Cells.Count Then
                    tableLav.Rows.Add(tr)
                    tr = New TableRow
                End If
                tc.ColumnSpan = 2 'devo metterlo in una riga
            End If

            Dim lab As New Label
            'lab.CssClass = "labelCombo"
            lab.Text = "<h4>" & Cat.Descrizione & "</h4>"
            lab.Font.Italic = False
            lab.Font.Bold = True
            'lab.Font.Name = "Tahoma"
            lab.ForeColor = Drawing.Color.FromArgb(11, 11, 11)
            lab.Font.Size = 10
            tc.Controls.Add(lab)

            Select Case Cat.TipoControllo

                Case enTipoControllo.CheckBox
                    Dim DescrBase As String = ""
                    Dim chkB As New CheckBoxList
                    chkB.ID = "lav" & Cat.IdCatLav
                    chkB.RepeatLayout = RepeatLayout.Table
                    'rdo.ClientIDMode = UI.ClientIDMode.Static
                    chkB.RepeatDirection = RepeatDirection.Horizontal
                    chkB.AutoPostBack = True
                    chkB.CssClass = "bloccoLav"
                    AddHandler chkB.SelectedIndexChanged, AddressOf SelezioneVoceCombo
                    ListaCheckbox.Add(chkB)

                    For Each singLav In lLav
                        Dim listSing As ListItem = Nothing
                        If singLav.IdLavoro Then
                            listSing = New ListItem
                            listSing.Attributes("tag") = singLav.Descrizione
                            'listSing.Text = "<div class='imgCheck hasTooltip' style='background: url(" & FormerWebApp.PathListinoImg & singLav.ImgRif & ") no-repeat top left;background-size:48px 48px;'></div><div class=""hidden tooltiptext""><img class=""imgSx"" src=""" & FormerWebApp.PathListinoImg & singLav.ImgRif & """><h4>" & singLav.Descrizione & "</h4>" & singLav.DescrizioneEstesaEx & "</div>"
                            listSing.Text = "<img src='" & FormerWebApp.PathListinoImg & singLav.ImgRif & "' class='imgCheck hasTooltip'><div class=""hidden tooltiptext""><img class=""imgSx"" src=""" & FormerWebApp.PathListinoImg & IIf(singLav.ImgZoom.Length, singLav.ImgZoom, singLav.ImgRif) & """><h4>" & singLav.Descrizione & "</h4>" & singLav.DescrizioneEstesaEx & "</div>"
                            listSing.Value = singLav.IdLavoro
                        Else
                            'qui devo vedere
                            'se esiste una lav della stessa cat tra le base devo aggiungerla e metterla selezionata
                            'altrimenti metto il formato steso
                            'bisogna gestire la descrizione della categoria di lavoro
                            Dim LavBase As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdCatLav = Cat.IdCatLav)

                            If LavBase Is Nothing Then
                                ''If Cat.IdCatLav = LUNA.LunaContext.IdCatPieghe Then
                                'Dim PathImgBase As String = FormerWebApp.PathListinoImg & LRif.FormatoProdotto.ImgRif

                                ''qui devo vedere se per la catlav c'e' un img di riferimento e in caso montarla al posto del formato steso

                                'If Cat.FileLavNonSelezionata.Length Then
                                '    PathImgBase = FormerWebApp.PathListinoImg & Cat.FileLavNonSelezionata
                                'End If

                                'listSing.Text = "<img class='imgCheck' src='" & PathImgBase & "'>"
                                ''Else
                                ''    listSing.Text = "<img class='imgCheck' src='/img/divieto.gif' alt='" & singLav.Descrizione & "'>"
                                ''End If
                                ''listSing.Text = "<img src='" & FormerWebApp.PathListinoImg & F.ImgRif & "' alt='" & singLav.Descrizione & "'>"
                                ''listSing.Text = "<img src='/img/divieto.gif' alt='" & singLav.Descrizione & "'>"
                                ''listSing.Selected = True
                                'DescrBase = "Non selezionato"
                                'listSing.Value = singLav.IdLavoro
                            Else
                                listSing = New ListItem
                                Dim PathImgBase As String = FormerWebApp.PathListinoImg & IIf(LavBase.ImgZoom.Length, LavBase.ImgZoom, LavBase.ImgRif)

                                listSing.Text = "<img src='" & PathImgBase & "' class='imgCheck hasTooltip'><div class=""hidden tooltiptext""><img class=""imgSx"" src=""" & PathImgBase & """><h4>" & LavBase.Descrizione & "</h4>" & LavBase.DescrizioneEstesaEx & "</div>"
                                listSing.Selected = True
                                listSing.Value = LavBase.IdLavoro
                                DescrBase = LavBase.Descrizione
                                listSing.Attributes("tag") = DescrBase
                            End If

                        End If
                        If Not listSing Is Nothing Then chkB.Items.Add(listSing)
                    Next

                    tc.Controls.Add(chkB)

                    'Dim lbl As New Label
                    'lbl.ID = "lblLav" & Cat.IdCatLav
                    'lbl.CssClass = "lblLav"
                    'lbl.Font.Size = 9
                    'lbl.Font.Bold = True
                    'lbl.Font.Italic = False

                    'lbl.Text = DescrBase
                    'lbl.Visible = True
                    ''ListaLbl.Add(lbl)

                    'tc.Controls.Add(lbl)


                Case enTipoControllo.RadioButton
                    Dim DescrBase As String = ""
                    Dim rdo As New RadioButtonList
                    rdo.ID = "lav" & Cat.IdCatLav
                    rdo.RepeatLayout = RepeatLayout.Table
                    'rdo.ClientIDMode = UI.ClientIDMode.Static

                    rdo.AutoPostBack = True
                    rdo.RepeatDirection = RepeatDirection.Horizontal
                    rdo.CssClass = "bloccoLav"
                    AddHandler rdo.SelectedIndexChanged, AddressOf SelezioneVoceCombo
                    ListaRDO.Add(rdo)

                    For Each singLav In lLav
                        Dim listSing As New ListItem
                        If singLav.IdLavoro Then
                            listSing.Attributes("tag") = singLav.Descrizione
                            'listSing.Text = "<div class='imgCheck hasTooltip' style='background: url(" & FormerWebApp.PathListinoImg & singLav.ImgRif & ") no-repeat top left;background-size:48px 48px;'></div><div class=""hidden tooltiptext""><img class=""imgSx"" src=""" & FormerWebApp.PathListinoImg & singLav.ImgRif & """><h4>" & singLav.Descrizione & "</h4>" & singLav.DescrizioneEstesaEx & "</div>"
                            listSing.Text = "<img src='" & FormerWebApp.PathListinoImg & singLav.ImgRif & "' class='imgCheck hasTooltip'><div class=""hidden tooltiptext""><img class=""imgSx"" src=""" & FormerWebApp.PathListinoImg & IIf(singLav.ImgZoom.Length, singLav.ImgZoom, singLav.ImgRif) & """><h4>" & singLav.Descrizione & "</h4>" & singLav.DescrizioneEstesaEx & "</div>"
                            listSing.Value = singLav.IdLavoro
                        Else
                            'qui devo vedere
                            'se esiste una lav della stessa cat tra le base devo aggiungerla e metterla selezionata
                            'altrimenti metto il formato steso
                            'bisogna gestire la descrizione della categoria di lavoro
                            Dim LavBase As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdCatLav = Cat.IdCatLav)

                            If LavBase Is Nothing Then
                                'If Cat.IdCatLav = LUNA.LunaContext.IdCatPieghe Then
                                Dim PathImgBase As String = FormerWebApp.PathListinoImg & LRif.FormatoProdotto.ImgRif

                                'qui devo vedere se per la catlav c'e' un img di riferimento e in caso montarla al posto del formato steso

                                If Cat.FileLavNonSelezionata.Length Then
                                    PathImgBase = FormerWebApp.PathListinoImg & Cat.FileLavNonSelezionata
                                End If

                                listSing.Text = "<img class='imgCheck' src='" & PathImgBase & "'>"
                                'Else
                                '    listSing.Text = "<img class='imgCheck' src='/img/divieto.gif' alt='" & singLav.Descrizione & "'>"
                                'End If
                                'listSing.Text = "<img src='" & FormerWebApp.PathListinoImg & F.ImgRif & "' alt='" & singLav.Descrizione & "'>"
                                'listSing.Text = "<img src='/img/divieto.gif' alt='" & singLav.Descrizione & "'>"
                                'listSing.Selected = True
                                DescrBase = "Non selezionato"
                                listSing.Value = singLav.IdLavoro
                            Else

                                Dim PathImgBase As String = FormerWebApp.PathListinoImg & IIf(LavBase.ImgZoom.Length, LavBase.ImgZoom, LavBase.ImgRif)

                                listSing.Text = "<img src='" & PathImgBase & "' class='imgCheck hasTooltip'><div class=""hidden tooltiptext""><img class=""imgSx"" src=""" & PathImgBase & """><h4>" & LavBase.Descrizione & "</h4>" & LavBase.DescrizioneEstesaEx & "</div>"
                                'listSing.Selected = True
                                listSing.Value = LavBase.IdLavoro
                                DescrBase = LavBase.Descrizione
                            End If
                            listSing.Attributes("tag") = DescrBase
                        End If
                        rdo.Items.Add(listSing)
                    Next

                    tc.Controls.Add(rdo)

                    'Dim lbl As New Label
                    'lbl.ID = "lblLav" & Cat.IdCatLav
                    'lbl.CssClass = "lblLav"
                    'lbl.Font.Size = 9
                    'lbl.Font.Bold = True
                    'lbl.Font.Italic = False

                    'lbl.Text = DescrBase
                    'lbl.Visible = True
                    ''ListaLbl.Add(lbl)

                    'tc.Controls.Add(lbl)

                Case enTipoControllo.ComboBox

                    Dim ddl As New DropDownList
                    ddl.ID = "lav" & Cat.IdCatLav
                    ddl.Font.Size = 11
                    'ddl.Font.Name = "Arial"
                    ddl.Font.Bold = False
                    ddl.CssClass = "comboBoxLav"
                    ddl.DataValueField = "IdLavoro"
                    ddl.DataTextField = "Descrizione"
                    ddl.ClientIDMode = UI.ClientIDMode.Static
                    ddl.AutoPostBack = True
                    ddl.Width = 270
                    AddHandler ddl.SelectedIndexChanged, AddressOf SelezioneVoceCombo

                    'Dim up As New AsyncPostBackTrigger
                    'up.ControlID = ddl.ID
                    'up.EventName = "SelectedIndexChanged"
                    'PannelloDinamico.Triggers.Add(up)

                    For Each singLav In lLav
                        Dim listSing As New ListItem
                        If singLav.IdLavoro Then
                            listSing.Attributes("tag") = singLav.Descrizione
                            'listSing.Text = "<div class='imgCheck hasTooltip' style='background: url(" & FormerWebApp.PathListinoImg & singLav.ImgRif & ") no-repeat top left;background-size:48px 48px;'></div><div class=""hidden tooltiptext""><img class=""imgSx"" src=""" & FormerWebApp.PathListinoImg & singLav.ImgRif & """><h4>" & singLav.Descrizione & "</h4>" & singLav.DescrizioneEstesaEx & "</div>"
                            listSing.Text = singLav.Descrizione
                            listSing.Value = singLav.IdLavoro
                        Else
                            'qui devo vedere
                            'se esiste una lav della stessa cat tra le base devo aggiungerla e metterla selezionata
                            'altrimenti metto il formato steso
                            'bisogna gestire la descrizione della categoria di lavoro
                            Dim LavBase As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdCatLav = Cat.IdCatLav)

                            If LavBase Is Nothing Then
                                'If Cat.IdCatLav = LUNA.LunaContext.IdCatPieghe Then
                                listSing.Text = "Non selezionato"
                                'Else
                                '    listSing.Text = "<img class='imgCheck' src='/img/divieto.gif' alt='" & singLav.Descrizione & "'>"
                                'End If
                                'listSing.Text = "<img src='" & FormerWebApp.PathListinoImg & F.ImgRif & "' alt='" & singLav.Descrizione & "'>"
                                'listSing.Text = "<img src='/img/divieto.gif' alt='" & singLav.Descrizione & "'>"
                                'listSing.Selected = True
                                'DescrBase = "Non selezionato"
                                listSing.Value = singLav.IdLavoro
                            Else
                                listSing.Text = LavBase.Descrizione '& "</h4>" & LavBase.DescrizioneEstesaEx & "</div>"
                                'listSing.Selected = True
                                listSing.Value = LavBase.IdLavoro
                            End If
                            'listSing.Attributes("tag") = DescrBase
                        End If
                        ddl.Items.Add(listSing)
                    Next

                    'ddl.DataSource = lLav
                    'ddl.DataBind()

                    ListaCombo.Add(ddl)
                    tc.Controls.Add(ddl)

            End Select

            tc.CssClass = "cellLav"
            tr.Cells.Add(tc)
            posiz += 1
        Next
        If tr.Cells.Count Then
            tableLav.Rows.Add(tr)
        End If

    End Sub

    Private Sub CaricaOrientamento()

        ddlOrientamento.Items.Clear()

        If LRif.FormatoProdotto.Orientabile Then
            'qui carico l'orientamento
            'Dim ListOrizzontale As New ListItem
            'ListOrizzontale.Text = "<img src='/img/orientamentoOrizzontale.jpg' class='imgCheck hasTooltip'><div class=""hidden tooltiptext""><img class=""imgSx"" src=""/img/orientamentoOrizzontale.jpg""><h4>Orientamento Orizzontale</h4></div>"
            'ListOrizzontale.Value = enTipoOrientamento.Orizzontale
            'rdoOrientamento.Items.Add(ListOrizzontale)

            'Dim ListVerticale As New ListItem
            'ListVerticale.Text = "<img src='/img/orientamentoVerticale.jpg' class='imgCheck hasTooltip'><div class=""hidden tooltiptext""><img class=""imgSx"" src=""/img/orientamentoVerticale.jpg""><h4>Orientamento Verticale</h4></div>"
            'ListVerticale.Value = enTipoOrientamento.Verticale
            'rdoOrientamento.Items.Add(ListVerticale)
            Dim ListOrizzontale As New ListItem
            ListOrizzontale.Text = "Orizzontale"
            ListOrizzontale.Value = enTipoOrientamento.Orizzontale
            ddlOrientamento.Items.Add(ListOrizzontale)

            Dim ListVerticale As New ListItem
            ListVerticale.Text = "Verticale"
            ListVerticale.Value = enTipoOrientamento.Verticale
            ddlOrientamento.Items.Add(ListVerticale)

            ddlOrientamento.SelectedValue = LRif.FormatoProdotto.Orientamento
        End If

    End Sub

    Private _LabelRiepilogoPrezzo As String = String.Empty
    Public Function LabelRiepilogoPrezzo() As String

        Return _LabelRiepilogoPrezzo

    End Function

    Private _LabelRiepilogoConsegna As String = String.Empty
    Public Function LabelRiepilogoConsegna() As String

        Return _LabelRiepilogoConsegna

    End Function

    Public Function MostraInfoMisure() As Boolean
        Dim ris As Boolean = False

        If (LRif.ConSoggettiDuplicati = enSiNo.Si AndAlso (LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse LRif.TipoPrezzo = enTipoPrezzo.SuFoglio)) OrElse LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
            ris = True
        End If

        Return ris
    End Function

    Private _LabelRiepilogoQta As String = String.Empty
    Public Function LabelRiepilogoQta() As String
        Return _LabelRiepilogoQta
    End Function

    Private Function GetDateConsegna() As RisDataConsegna

        Dim LCorr As New List(Of ICorriereBusiness)
        Using mgrC As New CorrieriWDAO
            LCorr = mgrC.GetListaCorrieri
        End Using

        Dim C As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(UtenteConnesso.Utente.Corriere, LCorr, UtenteConnesso.DefaultCAP, FormerWebApp.NonPrendereInConsiderazioneCorriereFormer)

        Dim listaLavB As List(Of ILavorazioneB) = LRif.LavorazioniBaseB

        Dim listaOpz As List(Of LavorazioneW) = CaricaLavorazioniSelezionate()
        For Each L As LavorazioneW In listaOpz
            listaLavB.Add(L)
        Next

        Dim DateConsegna As RisDataConsegna = MgrDataConsegna.CalcolaDateConsegna(P, C, listaLavB)

        Return DateConsegna

    End Function


    Private Sub CaricaDateConsegna(R As RisPrezzoIntermedio,
                                   Optional SelectDefault As Boolean = False)

        'Dim _GGCorr As Integer = 0

        'Dim LCorr As New List(Of ICorriereBusiness)
        'Using mgrC As New CorrieriWDAO
        '    LCorr = mgrC.GetListaCorrieri
        'End Using

        'Dim C As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(UtenteConnesso.Utente.Corriere, LCorr, UtenteConnesso.DefaultCAP)

        'Dim listaLavB As List(Of ILavorazioneB) = LRif.LavorazioniBaseB

        'Dim listaOpz As List(Of LavorazioneW) = CaricaLavorazioniSelezionate()
        'For Each L As LavorazioneW In listaOpz
        '    listaLavB.Add(L)
        'Next

        Dim DateConsegna As RisDataConsegna = GetDateConsegna() 'MgrDataConsegna.CalcolaDateConsegna(P, C, listaLavB)
        '_GGCorr = C.GGConsegna

        'Dim DataPrevConsegna As Date = Now.AddDays(_GGCorr)
        'If Now.Hour >= 13 Then DataPrevConsegna = DataPrevConsegna.AddDays(1)

        Dim SelectedDateValue As String = ""

        If rdoQuando.SelectedValue.Length Then
            SelectedDateValue = rdoQuando.SelectedValue.Substring(0, 1)
        End If

        rdoQuando.Items.Clear()
        'qui controllo se c'e' una data gia selezionata e riseleziono quella dopo se ancora presente 

        'qui aggiungo i giorni corretti NORMALE FAST SLOW
        rdoQuando.ValidationGroup = "quando"

        'Dim DataFast As Date = Date.MinValue
        'Dim DataNorm As Date = Date.MinValue
        'Dim DataSlow As Date = Date.MinValue
        Dim LisFast As ListItem = Nothing
        Dim LisNorm As ListItem = Nothing
        Dim LisSlow As ListItem = Nothing
        Dim PrezzoCalcolatoNetto As Decimal = 0

        'Dim R As RisultatoPrezzoIntermedioW = CalcolaPrezzi()

        Dim PrezzoPubblico As Decimal = R.PrezzoPubbl
        Dim PrezzoRiv As Decimal = R.PrezzoRiv

        'MODIFICA FATTA PER I PREZZI APERTI AL PUBBLICO DATA 28/04/2014
        'If UtenteConnesso.IdUtente Then
        If UtenteConnesso.Tipo = enTipoRubrica.Cliente Then
            PrezzoCalcolatoNetto = PrezzoPubblico
        Else
            PrezzoCalcolatoNetto = PrezzoRiv
        End If
        'End If

        Dim PrezzoFast As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeFast(P)
        Dim PrezzoStandard As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeNormale
        Dim PrezzoSlow As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeSlow(P)

        PrezzoFast = Math.Ceiling(PrezzoFast)
        PrezzoStandard = Math.Round(PrezzoStandard)
        PrezzoSlow = Math.Floor(PrezzoSlow)

        If P.ggFast Then
            'DataFast = DataPrevConsegna.AddDays(P.ggFast)
            'Dim DayToAdd As Integer = 0
            'If C.IdCorriere <> enCorriere.RitiroCliente Then
            '    If DataFast.DayOfWeek = DayOfWeek.Saturday Then DayToAdd = 2
            'End If
            'If DataFast.DayOfWeek = DayOfWeek.Sunday Then DayToAdd = 1
            'If DayToAdd Then DataFast = DataFast.AddDays(DayToAdd)
            Dim Etichetta As String = "<div class=""calendario""><div class=""giornoTxt"">" & StrConv(DateConsegna.DataFast.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNum"">" & DateConsegna.DataFast.ToString("dd") & "</div><div class=""mese"">" & DateConsegna.DataFast.ToString("MMMM") & "</div></div>"
            Etichetta &= "<div class=""prezzo""><img src=""/img/icoPrezzo16.png"" heigth=""16""> " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoFast) & "</div>"
            LisFast = New ListItem(Etichetta, "F" & DateConsegna.DataFast.ToString("ddMMyyyy"))
        End If

        If P.ggNorm Then
            'DataNorm = DataPrevConsegna.AddDays(P.ggNorm)
            'Dim DayToAdd As Integer = 0
            'If C.IdCorriere <> enCorriere.RitiroCliente Then
            '    If DataNorm.DayOfWeek = DayOfWeek.Saturday Then DayToAdd = 2
            'End If
            'If DataNorm.DayOfWeek = DayOfWeek.Sunday Then DayToAdd = 1
            'If DayToAdd Then DataNorm = DataNorm.AddDays(DayToAdd)
            Dim Etichetta As String = "<div class=""calendario""><div class=""giornoTxt"">" & StrConv(DateConsegna.DataNormale.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNum"">" & DateConsegna.DataNormale.ToString("dd") & "</div><div class=""mese"">" & DateConsegna.DataNormale.ToString("MMMM") & "</div></div>"
            Etichetta &= "<div class=""prezzo""><img src=""/img/icoPrezzo16.png"" heigth=""16""> " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard) & "</div>"
            LisNorm = New ListItem(Etichetta, "N" & DateConsegna.DataNormale.ToString("ddMMyyyy"))
        End If

        If P.ggSlow Then
            'DataSlow = DataPrevConsegna.AddDays(P.ggSlow)
            'Dim DayToAdd As Integer = 0
            'If C.IdCorriere <> enCorriere.RitiroCliente Then
            '    If DataSlow.DayOfWeek = DayOfWeek.Saturday Then DayToAdd = 2
            'End If
            'If DataSlow.DayOfWeek = DayOfWeek.Sunday Then DayToAdd = 1
            'If DayToAdd Then DataSlow = DataSlow.AddDays(DayToAdd)

            Dim Etichetta As String = String.Empty
            Dim PrezzoPromo As Decimal = PrezzoSlow

            'qui controllo se per caso c'è un promo
            Dim Pr As PromoW = LRif.Promo
            If Not Pr Is Nothing Then
                PrezzoPromo = Pr.GetPrezzoPromo(PrezzoSlow)
            End If

            If Pr Is Nothing Then
                Etichetta = "<div class=""calendario""><div class=""giornoTxt"">" & StrConv(DateConsegna.DataSlow.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNum"">" & DateConsegna.DataSlow.ToString("dd") & "</div><div class=""mese"">" & DateConsegna.DataSlow.ToString("MMMM") & "</div></div>"
                Etichetta &= "<div class=""prezzo""><img src=""/img/icoPrezzo16.png"" heigth=""16""> " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoSlow) & "</div>"
            Else
                Etichetta = "<div class=""calendarioPromo""><div class=""giornoTxtPromo"">" & StrConv(DateConsegna.DataSlow.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNum"">" & DateConsegna.DataSlow.ToString("dd") & "</div><div class=""mese"">" & DateConsegna.DataSlow.ToString("MMMM") & "</div></div>"
                Etichetta &= "<div class=""prezzoBarrato""><img src=""/img/icoPrezzo16.png"" heigth=""16""> " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoSlow) & "</div>"
                Etichetta &= "<div class=""prezzoPromo"">" & FormerHelper.Stringhe.FormattaPrezzo(PrezzoPromo) & " <div class='labelPromo'>Promo</div></div>"
            End If
            LisSlow = New ListItem(Etichetta, "S" & DateConsegna.DataSlow.ToString("ddMMyyyy"))
        End If

        If DateConsegna.DataFast <> DateConsegna.DataNormale Then
            If Not LisFast Is Nothing Then
                rdoQuando.Items.Add(LisFast)
            End If
        End If

        rdoQuando.Items.Add(LisNorm)
        If DateConsegna.DataSlow <> DateConsegna.DataNormale Then
            If Not LisSlow Is Nothing Then
                rdoQuando.Items.Add(LisSlow)
            End If
        End If

        If rdoQuando.Items.Count = 1 Then
            rdoQuando.Items(0).Selected = True
        Else
            Select Case SelectedDateValue
                Case "F"
                    If Not LisFast Is Nothing And DateConsegna.DataFast <> DateConsegna.DataNormale Then
                        LisFast.Selected = True
                    Else
                        LisNorm.Selected = True
                    End If
                Case "N"
                    LisNorm.Selected = True
                Case "S"
                    If Not LisSlow Is Nothing And DateConsegna.DataSlow <> DateConsegna.DataNormale Then
                        LisSlow.Selected = True
                    Else
                        LisNorm.Selected = True
                    End If
                Case Else
                    LisNorm.Selected = True
            End Select

        End If

        _QuandoSelected = rdoQuando.SelectedValue

        If _QuandoSelected.Length = 0 Then
            _LabelRiepilogoConsegna = DateConsegna.DataNormale.ToString("dd MMM")
        End If

    End Sub

    'Public ReadOnly Property ExistPromo As Boolean
    '    Get
    '        Dim ris As Boolean = False

    '        If Not GetPromo() Is Nothing Then
    '            ris = True
    '        End If

    '        Return ris
    '    End Get
    'End Property

    'Private _Pr As PromoW = Nothing
    'Public Function GetPromo() As PromoW

    '    'qui controllo se per caso c'è un promo
    '    If _Pr Is Nothing Then
    '        Using mgr As New PromoWDAO
    '            _Pr = mgr.GetPromo(LRif.IdListinoBase)
    '        End Using
    '    End If

    '    Return _Pr

    'End Function

    Private Function CalcolaPrezzi(Richieste As List(Of RichiestaCalcoloPrezzo)) As List(Of RisPrezzoIntermedio)

        Dim Ris As List(Of RisPrezzoIntermedio) = Nothing

        Dim listaBaseB As List(Of ILavorazioneB) = LRif.LavorazioniBaseB

        Dim listaOpz As List(Of LavorazioneW) = CaricaLavorazioniSelezionate()
        Dim listaOpzB As New List(Of ILavorazioneB)

        For Each L As LavorazioneW In listaOpz
            listaOpzB.Add(L)
        Next

        LRif.NumFacciate = GetNFogli() * 2

        If LRif.NumFacciate > LRif.faccmax Then LRif.NumFacciate = LRif.faccmax
        If LRif.NumFacciate < LRif.faccmin Then LRif.NumFacciate = LRif.faccmin

        Dim Altezza As Single = 0
        Dim Larghezza As Single = 0
        'Dim QtaRichiesta As Single = 0

        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            Altezza = ValidaDimensione(txtAltezza.Text)
            Larghezza = ValidaDimensione(txtLarghezza.Text)

            'QtaRichiesta = CalcolaMq.Mq

            'Qta = QtaRichiesta * Qta
        ElseIf LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
            Altezza = ValidaDimensione(txtAltezza.Text)
            Larghezza = ValidaDimensione(txtLarghezza.Text)


            'QtaRichiesta = CalcolaMq.Mq

        ElseIf LRif.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            Altezza = 1
            Larghezza = 1
            If P.IdPluginToUse = enPluginOnline.EtichetteCm Then
                Dim Rp As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm))
                If Not Rp Is Nothing Then
                    Altezza = Rp.Altezza
                    Larghezza = Rp.Base
                End If
            End If
        End If

        If LRif.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
            Altezza = Altezza / 10
            Larghezza = Larghezza / 10
        End If

        Dim IRp As IRisultatoPlugin = Nothing

        If P.IdPluginToUse Then
            IRp = Session(MgrPlugin.GetFirmaPlugin(P.IdPluginToUse))
        End If

        'Dim _Risultato As RisultatoListinoBase
        '_Risultato = MgrPreventivazioneB.CalcolaPrezzi(LRif, listaBaseB, listaOpzB, False,, Altezza, Larghezza)

        'Dim R As RisultatoPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoIntermedio(Qta,
        '                                                                                 QtaSecondaria,
        '                                                                                 _Risultato,
        '                                                                                 LRif,
        '                                                                                 listaBaseB,
        Dim CalcolareLavorazioniNonPreviste As Boolean = False

        CalcolareLavorazioniNonPreviste = True

        'listaOpzB)
        Ris = MgrPreventivazioneB.CalcolaPrezzoFinale(LRif,
                                                        Richieste,
                                                        listaBaseB,
                                                        listaOpzB,
                                                        False,
                                                        Altezza,
                                                        Larghezza,
                                                        CalcolareLavorazioniNonPreviste,
                                                        IRp)

        Return Ris

    End Function

    'Private Function CalcolaPrezzi(Qta As Single,
    '                               QtaSecondaria As Single,
    '                               NumeroPezzi As Integer) As RisPrezzoIntermedio
    '    'Dim QtaRichiesta As Integer = Convert.ToInt32(ddlQta.SelectedValue)
    '    'LRif.CaricaLavorazioniBase()

    '    Dim listaBaseB As List(Of ILavorazioneB) = LRif.LavorazioniBaseB

    '    Dim listaOpz As List(Of LavorazioneW) = CaricaLavorazioniSelezionate()
    '    Dim listaOpzB As New List(Of ILavorazioneB)

    '    For Each L As LavorazioneW In listaOpz
    '        listaOpzB.Add(L)
    '    Next

    '    LRif.NumFacciate = GetNFogli() * 2

    '    If LRif.NumFacciate > LRif.faccmax Then LRif.NumFacciate = LRif.faccmax
    '    If LRif.NumFacciate < LRif.faccmin Then LRif.NumFacciate = LRif.faccmin

    '    Dim Altezza As Single = 0
    '    Dim Larghezza As Single = 0
    '    'Dim QtaRichiesta As Single = 0

    '    If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
    '        Altezza = ValidaDimensione(txtAltezza.Text)
    '        Larghezza = ValidaDimensione(txtLarghezza.Text)

    '        'QtaRichiesta = CalcolaMq.Mq

    '        'Qta = QtaRichiesta * Qta
    '    ElseIf LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
    '        Altezza = ValidaDimensione(txtAltezza.Text)
    '        Larghezza = ValidaDimensione(txtLarghezza.Text)

    '        If LRif.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
    '            Altezza = Altezza / 10
    '            Larghezza = Larghezza / 10
    '        End If

    '        'QtaRichiesta = CalcolaMq.Mq

    '    ElseIf LRif.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
    '        Altezza = 1
    '        Larghezza = 1
    '        If P.IdPluginToUse = enPluginOnline.EtichetteCm Then
    '            Dim Rp As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm))
    '            If Not Rp Is Nothing Then
    '                Altezza = Rp.Altezza
    '                Larghezza = Rp.Base
    '            End If
    '        End If
    '    End If

    '    Dim IRp As IRisultatoPlugin = Nothing

    '    If P.IdPluginToUse Then
    '        IRp = Session(MgrPlugin.GetFirmaPlugin(P.IdPluginToUse))
    '    End If

    '    'Dim _Risultato As RisultatoListinoBase
    '    '_Risultato = MgrPreventivazioneB.CalcolaPrezzi(LRif, listaBaseB, listaOpzB, False,, Altezza, Larghezza)

    '    'Dim R As RisultatoPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoIntermedio(Qta,
    '    '                                                                                 QtaSecondaria,
    '    '                                                                                 _Risultato,
    '    '                                                                                 LRif,
    '    '                                                                                 listaBaseB,
    '    Dim CalcolareLavorazioniNonPreviste As Boolean = False

    '    CalcolareLavorazioniNonPreviste = True 'SERVE SOLO PER FORZARLO SCRIVERLO COSI, INVECE DI PASSARE DIRETTAMENTE IL PARAMETRO

    '    'listaOpzB)
    '    Dim R As RisPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoFinale(LRif,
    '                                                                            Qta,
    '                                                                            listaBaseB,
    '                                                                            QtaSecondaria,
    '                                                                            listaOpzB,
    '                                                                            False,,
    '                                                                            Altezza,
    '                                                                            Larghezza,
    '                                                                            NumeroPezzi,
    '                                                                            CalcolareLavorazioniNonPreviste,
    '                                                                            IRp)

    '    Return R

    'End Function

    Public Function GetLarghezzaMaxLato() As String
        Dim ris As String = String.Empty

        'qui devo tornare anche è
        'oppure può essere di 
        ris = LRif.LatoFissoRiferimento.LatoFissoPrincipale

        If LRif.LargRotolo.Length AndAlso LRif.LargRotolo.IndexOf(",") <> -1 Then
            'piu di una misura

            Dim LargStr As String = LRif.LargRotolo.Trim.TrimEnd(",")

            Dim posiz As Integer = LargStr.LastIndexOf(",")

            If posiz <> -1 Then
                LargStr = LargStr.Substring(0, posiz) & " o " & LargStr.Substring(posiz + 1)
            End If

            ris = "può essere di " & LargStr
        Else
            'una sola misura
            ris = "è " & ris
        End If

        Return ris
    End Function

    Private Sub CaricaProdottoConsigliato()

        Dim l As List(Of ListinoBaseW) = Nothing

        'qui vedo se devo estrarre solo quelli di un gruppo prodotti consigliati o tutti

        'poi ne estraggo uno casuale

        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            l = FormerWebApp.StaticListiniBase.FindAll(Function(x) x.IdListinoBase <> LRif.IdListinoBase)
        Else
            Using mgr As New ListinoBaseWDAO
                l = mgr.ListiniUtilizzabili.FindAll(Function(x) x.IdListinoBase <> LRif.IdListinoBase)
            End Using
        End If

        If LRif.IdGruppoListiniConsigliati Then
            If l.FindAll(Function(x) x.IdGruppoLCAppartenenza = LRif.IdGruppoListiniConsigliati).Count Then
                'qui ha un listino consigliato e ci sono dentro listinibase
                l = l.FindAll(Function(x) x.IdGruppoLCAppartenenza = LRif.IdGruppoListiniConsigliati)
            End If
        End If

        Dim lb As ListinoBaseW = Nothing
        If l.Count Then
            Dim Quale As Integer = 0
            Dim rnd As New Random
            Randomize()

            Quale = rnd.Next(0, l.Count - 1)
            lb = l(Quale)
            lbConsigliato.IdListinoBase = lb.IdListinoBase
            'lb = New ListinoBaseW

            If l.Count > 1 Then
                Quale = rnd.Next(0, l.Count - 1)
                lb = l(Quale)
                lbConsigliato1.IdListinoBase = lb.IdListinoBase
                If lbConsigliato1.Visible = False Then lbConsigliato1.Visible = True
                If l.Count > 2 Then
                    Quale = rnd.Next(0, l.Count - 1)
                    lb = l(Quale)
                    lbConsigliato2.IdListinoBase = lb.IdListinoBase
                    If lbConsigliato2.Visible = False Then lbConsigliato2.Visible = True
                End If
            Else
                lbConsigliato1.Visible = False
                lbConsigliato2.Visible = False
            End If
        End If

    End Sub

    Private Sub AggiornaReview() 'ByVal take As Integer, ByVal pageSize As Integer)

        AggregateReview.IdListinoBase = LRif.IdListinoBase

        Dim L As List(Of Review) = Nothing
        Using mgr As New ReviewDAO
            L = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "Quando Desc", .Top = 10},
                            New LUNA.LunaSearchParameter(LFM.Review.IdListinoBase, LRif.IdListinoBase),
                            New LUNA.LunaSearchParameter(LFM.Review.Stato, enStatoReview.Approvata))
        End Using

        If L.Count Then
            rptReview.DataSource = L
            rptReview.DataBind()
            rptReview.Visible = True
        Else
            rptReview.Visible = False
            ' plcPaging.Visible = False
        End If

    End Sub

    Private KeyPrezzoCalcolatoNetto As String = "PrezzoCalcolatoNetto"
    Private KeyIdMacchinarioStampa As String = "IdMacchinarioStampa"

    Private Function CalcolaTutto(Optional SelectDefault As Boolean = False) As Decimal

        Dim Ris As Decimal = 0
        'AggiornaReview(ReviewRecordPerPage, 0)
        'ReviewRowCount = ViewState("RowCountReview")
        'CreatePagingControl()

        'Threading.Thread.Sleep(2000)
        'Dim NumeroPezziScelti As Integer = Convert.ToInt32(ddlQta.SelectedValue)

        Dim CalcolarePrezzi As Boolean = True

        If AlterateMisure OrElse MisureInseriteValide = False Then
            CalcolarePrezzi = False
        End If

        If CalcolarePrezzi Then
            Dim NumeroPezziScelti As Integer = GetQtaSelezionata()
            Dim QtaRichiesta As Single = NumeroPezziScelti
            Dim QtaSecondaria As Single = QtaRichiesta '0
            Dim Altezza As Integer = 1
            Dim Larghezza As Integer = 1
            Dim Orientamento As enTipoOrientamento = enTipoOrientamento.Verticale
            Dim LatoFisso As Integer = (LRif.LatoFissoRiferimento.LatoFissoPrincipale * 10) ' (LRif.FormatoProdotto.Fc.Larghezza * 10)

            'If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            '    QtaRichiesta = CalcolaMq.Mq
            '    'Dim QtaLabel As Single = CalcolaMq(1).Mq
            '    'If txtAltezza.Text.Trim.Length = 0 Or txtLarghezza.Text.Trim.Length = 0 Then
            '    '    lblInfoDim.Text = ""
            '    '    QtaRichiesta = 0
            '    'Else
            '    '    lblInfoDim.Text = QtaLabel & " m^2"
            '    'End If

            '    If LRif.ConSoggettiDuplicati = enSiNo.Si Then
            '        QtaSecondaria = NumeroPezziScelti
            '    End If
            'ElseIf LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
            '    QtaRichiesta = CalcolaFogli.NumeroFogli
            '    'Dim QtaLabel As Single = CalcolaFogli(1).NumeroFogli
            '    'If txtAltezza.Text.Trim.Length = 0 Or txtLarghezza.Text.Trim.Length = 0 Then
            '    '    lblInfoDim.Text = ""
            '    '    QtaRichiesta = 0
            '    'Else
            '    '    lblInfoDim.Text = QtaRichiesta & " foglio/i"
            '    'End If

            '    If LRif.ConSoggettiDuplicati = enSiNo.Si Then
            '        QtaSecondaria = NumeroPezziScelti
            '    End If
            'Else
            If LRif.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
                    If P.IdPluginToUse = enPluginOnline.EtichetteCm Then
                        Dim Rp As RisultatoPluginEtichette = Nothing
                        Rp = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm))
                        If Not Rp Is Nothing Then
                            Altezza = Rp.Altezza
                            Larghezza = Rp.Base
                        End If
                    End If

                    'qui calcolo i centimetri quadri in base al lato corto del prodotto e all'orientamento
                    Dim ValoreMax As Integer = LatoFisso - (FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato * 2)

                    If Altezza > ValoreMax Or Larghezza > ValoreMax Then
                        'qui puo essere orientato solo in verticale 
                        Orientamento = enTipoOrientamento.Verticale
                    Else
                        'qui se disponibile la lavorazione devo prendere l'orientamento che seleziona il cliente dalla pagina
                        Dim cmb As RadioButtonList = ListaRDO.Find(Function(x) x.ID = "lav" & FormerLib.FormerConst.ProdottiParticolari.IdCatOrientamentoEtichette)
                        If Not cmb Is Nothing Then
                            If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
                                Dim lav As New LavorazioneW
                                lav.Read(Convert.ToInt32(cmb.SelectedValue))
                                'qui ho la lav scelta e vedo nelle extra info l'orientamento

                                Dim ed As ExtraData = lav.ListExtraData.Find(Function(x) x.Chiave = FormerLib.FormerConst.ExtraDataKey.OrientamentoEtichette)

                                If Not ed Is Nothing Then
                                    Orientamento = ed.Valore
                                End If

                            End If
                        Else
                            'qui provo se si tratta di una combo 
                            Dim ddl As DropDownList = ListaCombo.Find(Function(x) x.ID = "lav" & FormerLib.FormerConst.ProdottiParticolari.IdCatOrientamentoEtichette)
                            If Not ddl Is Nothing Then
                                If ddl.SelectedValue <> String.Empty AndAlso ddl.SelectedValue <> "0" Then
                                    Dim lav As New LavorazioneW
                                    lav.Read(Convert.ToInt32(ddl.SelectedValue))
                                    Dim ed As ExtraData = lav.ListExtraData.Find(Function(x) x.Chiave = FormerLib.FormerConst.ExtraDataKey.OrientamentoEtichette)

                                    If Not ed Is Nothing Then
                                        Orientamento = ed.Valore
                                    End If
                                End If
                            End If
                        End If
                    End If

                    QtaSecondaria = (Altezza / 10) * (Larghezza / 10) * NumeroPezziScelti

                    QtaRichiesta = MgrCalcoliTecnici.CalcolaCmQuadri(Altezza,
                                                                    Larghezza,
                                                                    Orientamento,
                                                                    LatoFisso,
                                                                    QtaRichiesta)

                End If

                Dim PrezzoCalcolatoNetto As Decimal = 0
            Dim PrezzoPubblico As Decimal = 0
            Dim PrezzoRiv As Decimal = 0

            Dim Richp As New RichiestaCalcoloPrezzo
            Richp.QtaRichiesta = QtaRichiesta
            Richp.QtaDaUsareNelCalcoloLavorazioni = QtaSecondaria
            Richp.QtaDaInserireObbligatoriamenteInElenco = True

            If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                Richp.QtaRichiesta = CalcolaMq.Mq
            End If

            If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                Richp.QtaRichiesta = CalcolaFogli.NumeroFogli
            End If

            Dim lP As New List(Of RichiestaCalcoloPrezzo)
            lP.Add(Richp)

            'Dim R As RisPrezzoIntermedio = CalcolaPrezzi(QtaRichiesta,
            '                                                   QtaSecondaria,
            '                                                   NumeroPezziScelti)

            Dim RisR As List(Of RisPrezzoIntermedio) = CalcolaPrezzi(lP)




            Dim R As RisPrezzoIntermedio = RisR(0)

            If R.RichiestaCalcoloPrezzo.AnomaliaPrezzoCalcolato Then
                'qui devo trovare tra tutte le lavorazioni quella piu piccola per il formato minimo e la
                'meno grande per il formato massimo 

                Dim listalavSel As New List(Of LavorazioneW)

                listalavSel.AddRange(LRif.LavorazioniBase)
                listalavSel.AddRange(CaricaLavorazioniSelezionate())

                Dim LavorazioneMinima As LavorazioneW = Nothing
                Dim LavorazioneMassima As LavorazioneW = Nothing

                For Each lav In listalavSel
                    If LavorazioneMinima Is Nothing Then
                        If lav.DimensMinH <> 0 And lav.DimensMinW <> 0 Then
                            LavorazioneMinima = lav
                        End If
                    Else
                        'qui devo vedere se e' piu piccola della lavorazione minima
                        If lav.DimensMinH <> 0 And lav.DimensMinW <> 0 Then
                            If (lav.DimensMinH <= LavorazioneMinima.DimensMinH And lav.DimensMinW <= LavorazioneMinima.DimensMinW) OrElse
                                (lav.DimensMinH <= LavorazioneMinima.DimensMinW And lav.DimensMinW <= LavorazioneMinima.DimensMinH) Then
                                LavorazioneMinima = lav
                            End If
                        End If
                    End If
                    If LavorazioneMassima Is Nothing Then
                        If lav.DimensMaxH <> 0 And lav.DimensMaxW <> 0 Then
                            LavorazioneMassima = lav
                        End If
                    Else
                        'qui devo vedere se e' meno grande della lavorazione massima
                        If lav.DimensMaxH <> 0 And lav.DimensMaxW <> 0 Then
                            If (lav.DimensMaxH >= LavorazioneMinima.DimensMaxH And lav.DimensMaxW >= LavorazioneMinima.DimensMaxW) OrElse
                                (lav.DimensMaxH >= LavorazioneMinima.DimensMaxW And lav.DimensMaxW >= LavorazioneMinima.DimensMaxH) Then
                                LavorazioneMassima = lav
                            End If
                        End If
                    End If
                Next
                If Not LavorazioneMinima Is Nothing And Not LavorazioneMassima Is Nothing Then
                    lblErroreMisure.Text = "<br>(Min. " & LavorazioneMinima.DimensMinW & "x" & LavorazioneMinima.DimensMinH & "mm - Max. " & LavorazioneMassima.DimensMaxW & "x" & LavorazioneMassima.DimensMaxH & "mm)"
                Else
                    lblErroreMisure.Text = String.Empty
                End If
                CalcolarePrezzi = False
                pnlErrore.Visible = True
            Else

                'If LRif.TipoControlloPrezzo <> enTipoControlloPrezzo.Tabella Then
                CaricaDateConsegna(R, SelectDefault)
                'End If

                'If LRif.MostraPrezziTabella = enSiNo.No Then

                'End If

                'PrezzoPubblico = R.PrezzoPubbl
                'PrezzoRiv = R.PrezzoRiv

                If UtenteConnesso.Tipo = enTipoRubrica.Cliente Then
                    PrezzoCalcolatoNetto = R.PrezzoPubbl
                Else
                    PrezzoCalcolatoNetto = R.PrezzoRiv
                End If

                PrezzoPubblico = R.PrezzoConsigliatoPubbl

                Dim DataConsRif As String = String.Empty

                Dim IdPromo As Integer = 0
                Dim DataSelezionata As String = GetDataSelezionata()

                Dim valInt As Decimal = 0

                If DataSelezionata.Length Then
                    Dim ValoreQuando As String = DataSelezionata
                    If ValoreQuando.StartsWith("F") Then 'FAST
                        valInt = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeFast(LRif.Preventivazione)
                        PrezzoCalcolatoNetto = Math.Ceiling(valInt)

                        valInt = PrezzoPubblico * MgrPercentualiDay.PercentualeFast(LRif.Preventivazione)
                        PrezzoPubblico = Math.Ceiling(valInt)

                    ElseIf ValoreQuando.StartsWith("N") Then 'NORMAL
                        PrezzoCalcolatoNetto = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeNormale
                        PrezzoPubblico = PrezzoPubblico * MgrPercentualiDay.PercentualeNormale
                    ElseIf ValoreQuando.StartsWith("S") Then 'SLOW
                        valInt = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeSlow(LRif.Preventivazione)
                        PrezzoCalcolatoNetto = Math.Floor(valInt)

                        valInt = PrezzoPubblico * MgrPercentualiDay.PercentualeSlow(LRif.Preventivazione)
                        PrezzoPubblico = Math.Floor(valInt)

                        ''qui controllo se per caso c'è un promo
                        Dim Pr As PromoW = LRif.Promo

                        If Not Pr Is Nothing Then
                            PrezzoCalcolatoNetto = Pr.GetPrezzoPromo(PrezzoCalcolatoNetto)
                            IdPromo = Pr.Percentuale
                        End If

                    End If

                    DataConsRif = ValoreQuando

                Else
                    DataConsRif = _QuandoSelected
                End If

                If DataConsRif.Length Then
                    Dim DataCons As Date = Date.MinValue

                    Dim Giorno As String = DataConsRif.Substring(1, 2)
                    Dim Mese As String = DataConsRif.Substring(3, 2)
                    Dim Anno As String = DataConsRif.Substring(5, 4)

                    DataCons = New Date(Anno, Mese, Giorno)

                    _LabelRiepilogoConsegna = DataCons.ToString("dd MMM")
                End If

                'PrezzoCalcolatoNetto = Math.Round(PrezzoCalcolatoNetto)

                If chkVerificaFile.Checked Then
                    PrezzoCalcolatoNetto += FormerWebApp.GetPrezzoVerificaFile
                    PrezzoPubblico += FormerWebApp.GetPrezzoVerificaFile
                End If

                'PrezzoPubblico = Math.Round(PrezzoPubblico)
                Dim O As ProdottoInCarrello = CreaOrdineDaModulo()
                O.Altezza = Altezza
                O.Larghezza = Larghezza

                O.IdPromo = IdPromo

                O.PrezzoCalcolatoNettoOriginale = PrezzoCalcolatoNetto

                If LRif.TipoPrezzo = enTipoPrezzo.SuCmQuadri OrElse (LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri And LRif.ConSoggettiDuplicati = enSiNo.Si) Then
                    'O.Colli = MgrPreventivazioneB.CalcolaColli(Convert.ToInt32(ddlQta.SelectedValue), LRif)
                    O.Colli = MgrPreventivazioneB.CalcolaColli(GetQtaSelezionata, LRif)
                    Dim LatoIpotetico As Single = Math.Sqrt(QtaRichiesta)

                    'O.Peso = MgrPreventivazioneB.CalcolaKgCarta(LatoIpotetico, LatoIpotetico, LRif.TipoCarta.Grammi, 1)
                    O.Peso = MgrPreventivazioneB.CalcolaPesoLavoro(LatoIpotetico, LatoIpotetico, 1, O.Colli, LRif, False)
                    O.OrientamentoScelto = Orientamento

                Else
                    If P.IdReparto = enRepartoWeb.StampaDigitale Then

                        'O.Colli = Convert.ToInt32(ddlQta.SelectedValue)
                        O.Colli = GetQtaSelezionata()
                        Dim AltezzaInserita As Integer = 1
                        Try
                            AltezzaInserita = txtAltezza.Text.Trim
                        Catch ex As Exception

                        End Try

                        Dim LarghezzaInserita As Integer = 1
                        Try
                            LarghezzaInserita = txtAltezza.Text.Trim
                        Catch ex As Exception

                        End Try

                        O.Peso = MgrPreventivazioneB.CalcolaPesoLavoro(AltezzaInserita, LarghezzaInserita, QtaRichiesta, O.Colli, LRif, False)
                    Else
                        O.Colli = MgrPreventivazioneB.CalcolaColli(QtaRichiesta, LRif)
                        O.Peso = MgrPreventivazioneB.CalcolaPesoLavoro(Altezza, Larghezza, QtaRichiesta, O.Colli, LRif, False)
                    End If
                    'O.Peso = MgrPreventivazioneB.CalcolaKgCarta(QtaRichiesta, LRif, False)


                End If

                lblPeso.Text = O.PesoStr
                ViewState(KeyPrezzoCalcolatoNetto) = PrezzoCalcolatoNetto
                ViewState(KeyIdMacchinarioStampa) = R.IdMacchinarioStampa
                'lblPrezzoValue.Text = PrezzoCalcolatoNetto
                'lblIdMacchinarioProduzione.Text = R.IdMacchinarioStampa

                _LabelRiepilogoQta = O.QtaStr
                _LabelRiepilogoPrezzo = FormerHelper.Stringhe.FormattaPrezzo(PrezzoCalcolatoNetto)

                lblColli.Text = O.Colli
                lblPeso.Text = O.PesoStr

                'lblConsegna.Text = O.Corriere.Descrizione

                'lblRiepilogoData.Text = StrConv(O.DataConsegnaStr, vbProperCase)

                lblPrezzo.Text = "€ " & FormerHelper.Stringhe.FormattaPrezzo(O.PrezzoCalcolatoNetto) & " + iva"
                lblPrezzoConsigliato.Text = "€ " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoPubblico) & " + iva"
                'lblTotIva.Text = FormerHelper.Stringhe.FormattaPrezzo(O.TotaleIva)
                'lblSpeseTrasp.Text = FormerHelper.Stringhe.FormattaPrezzo(O.SpeseDiTrasporto)
                'lblTotOrdine.Text = FormerHelper.Stringhe.FormattaPrezzo(O.TotaleOrdine)

                'Threading.Thread.Sleep(3000)
                Ris = PrezzoCalcolatoNetto
            End If

        End If
        'lo faccio cosi perche calcolare prezzi puo cambiare anche all'interno del blocco precedente
        If CalcolarePrezzi = False Then
            lblPeso.Text = "-"
            ViewState(KeyPrezzoCalcolatoNetto) = 0
            ViewState(KeyIdMacchinarioStampa) = 0

            _LabelRiepilogoQta = 0
            _LabelRiepilogoPrezzo = "-"

            lblColli.Text = "-"
            lblPeso.Text = "-"

            lblPrezzo.Text = "-"
            lblPrezzoConsigliato.Text = "-"

            Ris = 0
        End If

        'CaricaQtaTabella()

        Return Ris
    End Function

    Public Function LabelTrasporto() As String
        Dim ris As String = ""
        ris = UtenteConnesso.Utente.Corriere.Descrizione
        Return ris

    End Function

    Public Function LabelDataConsegna() As String
        Dim Ris As String = ""

        Dim LCorr As New List(Of ICorriereBusiness)
        Using mgrC As New CorrieriWDAO
            LCorr = mgrC.GetListaCorrieri
        End Using

        Dim C As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(UtenteConnesso.Utente.Corriere, LCorr, UtenteConnesso.Utente.Cap, FormerWebApp.NonPrendereInConsiderazioneCorriereFormer)

        Ris = C.LabelDataConsegna
        C = Nothing
        Return Ris
    End Function
    Private Function CaricaLavorazioniSelezionate() As List(Of LavorazioneW)

        Dim listaOpz As New List(Of LavorazioneW)

        ''qui devo prendere la piega se selezionata 
        'If rdoPiega.Items.Count Then
        '    If rdoPiega.SelectedValue.Length And rdoPiega.SelectedValue <> "0" Then
        '        Dim lav As New LavorazioneW
        '        lav.Read(Convert.ToInt32(rdoPiega.SelectedValue))
        '        listaOpz.Add(lav)
        '    End If
        'End If
        For Each catsi As CatLavW In LRif.GetCatLav
            If catsi.TipoControllo = enTipoControllo.RadioButton Then
                Dim cmb As RadioButtonList = ListaRDO.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
                If Not cmb Is Nothing Then
                    If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
                        Dim lav As New LavorazioneW
                        lav.Read(Convert.ToInt32(cmb.SelectedValue))
                        If listaOpz.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count = 0 Then listaOpz.Add(lav)
                    End If
                End If
            ElseIf catsi.TipoControllo = enTipoControllo.ComboBox Then
                Dim cmb As DropDownList = ListaCombo.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
                If Not cmb Is Nothing Then
                    If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
                        Dim lav As New LavorazioneW
                        lav.Read(Convert.ToInt32(cmb.SelectedValue))
                        If listaOpz.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count = 0 Then listaOpz.Add(lav)
                    End If
                End If
            ElseIf catsi.TipoControllo = enTipoControllo.CheckBox Then
                Dim cmb As CheckBoxList = ListaCheckbox.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
                If Not cmb Is Nothing Then
                    'se nessuno e' selezionato controllo se era in quelel base e selezion cmq la prima voce
                    If LRif.LavorazioniBase.FindAll(Function(x) x.IdCatLav = catsi.IdCatLav).Count <> 0 Then
                        'qui almeno una voce deve essere selezionata
                        If cmb.SelectedItem Is Nothing Then
                            cmb.Items(0).Selected = True
                        End If
                    End If

                    For Each valore As ListItem In cmb.Items
                        If valore.Selected Then
                            Dim lav As New LavorazioneW
                            lav.Read(Convert.ToInt32(valore.Value))
                            If listaOpz.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count = 0 Then listaOpz.Add(lav)
                        End If
                    Next
                End If
            End If
        Next

        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri AndAlso LRif.ConSoggettiDuplicati = enSiNo.Si Then

            If LRif.IdLavTaglioDuplicati Then
                Dim LTaglio As New LavorazioneW
                LTaglio.Read(LRif.IdLavTaglioDuplicati)
                If listaOpz.FindAll(Function(x) x.IdLavoro = LTaglio.IdLavoro).Count = 0 Then listaOpz.Add(LTaglio)
            End If


        End If

        Return listaOpz

    End Function
    Private Sub SelezioneVoceCombo(sender As Object, e As EventArgs)

        'If TypeOf (sender) Is System.Web.UI.WebControls.RadioButtonList Then
        '    Dim rdo As RadioButtonList = sender

        '    Dim lblNameLav As String = "lblLav" & rdo.ID.Substring(3)
        '    Dim lbl As Label = ListaLbl.Find(Function(x) x.ID = lblNameLav)

        '    If Not lbl Is Nothing Then
        '        If rdo.SelectedValue Then
        '            Dim voce As ListItem = rdo.SelectedItem
        '            lbl.Text = voce.Attributes("Tag")
        '        Else
        '            lbl.Text = "Non selezionato"
        '        End If
        '    End If

        '    'NEL CASO DELLA COMBO NON DEVO FARE NIENTE 
        '    'ElseIf TypeOf (sender) Is System.Web.UI.WebControls.DropDownList Then
        '    '    Dim ddl As DropDownList = sender

        '    '    Dim lblNameLav As String = "lblLav" & ddl.ID.Substring(3)
        '    '    Dim lbl As Label = ListaLbl.Find(Function(x) x.ID = lblNameLav)

        '    '    If Not lbl Is Nothing Then
        '    '        If ddl.SelectedValue Then
        '    '            Dim voce As ListItem = ddl.SelectedItem
        '    '            lbl.Text = voce.Attributes("Tag")
        '    '        Else
        '    '            lbl.Text = "Non selezionato"
        '    '        End If
        '    '    End If

        'End If

        If TypeOf (sender) Is System.Web.UI.WebControls.DropDownList Then
            Dim ddl As DropDownList = sender

            CreaInfoImg(ddl)

        End If

        CaricaQtaTabella()
        CalcolaTutto()


    End Sub
    Private Sub CreaInfoImg(ddl As DropDownList)
        Dim InfoCreata As Boolean = False
        Dim NewTag As String = ddl.ID.Replace("lav", "lavInfo")

        For Each row As TableRow In tblDDL.Rows

            For Each cell As TableCell In row.Cells
                If cell.ID = NewTag Then
                    cell.Text = String.Empty
                    If ddl.SelectedValue Then
                        Using singlav As New LavorazioneW
                            singlav.Read(ddl.SelectedValue)
                            Dim bufferH As String = "<img src=""/img/icoInfo20.png"" class='hasTooltip'><div class=""hidden tooltiptext""><img class=""imgSx"" src=""" & FormerWebApp.PathListinoImg & IIf(singlav.ImgZoom.Length, singlav.ImgZoom, singlav.ImgRif) & """><h4>" & singlav.Descrizione & "</h4>" & singlav.DescrizioneEstesaEx & "</div>"
                            cell.Text = bufferH
                        End Using

                    End If
                    InfoCreata = True
                    Exit For
                End If
            Next

            If InfoCreata Then Exit For
        Next
    End Sub


    'Private Sub CaricaPieghe()
    '    Exit Sub
    '    If LRif.LavorazioniBase.FindAll(Function(x) x.IdCatLav = LUNA.LunaContext.IdCatPieghe).Count = 0 Then
    '        Dim listSing As New ListItem
    '        listSing.Text = "<img src='" & FormerWebApp.PathListinoImg & F.ImgRif & "'>"
    '        listSing.Value = 0
    '        'listSing.Selected = True
    '        rdoPiega.Items.Add(listSing)
    '    End If

    '    For Each Lav As LavorazioneW In LRif.LavorazioniBase
    '        If Lav.IdCatLav = LUNA.LunaContext.IdCatPieghe Then
    '            Dim listSing As New ListItem
    '            listSing.Text = "<img src='" & FormerWebApp.PathListinoImg & Lav.ImgRif & "'>"
    '            listSing.Value = Lav.IdLavoro
    '            'listSing.Selected = True

    '            rdoPiega.Items.Add(listSing)
    '        End If
    '    Next

    '    For Each Lav As LavorazioneW In LRif.LavorazioniOpz
    '        If Lav.IdCatLav = LUNA.LunaContext.IdCatPieghe Then
    '            Dim listSing As New ListItem
    '            listSing.Text = "<img src='" & FormerWebApp.PathListinoImg & Lav.ImgRif & "'>"
    '            listSing.Value = Lav.IdLavoro
    '            rdoPiega.Items.Add(listSing)
    '        End If
    '    Next

    '    'If lst.Count Then
    '    '    rptLav.DataSource = lst
    '    '    rptLav.DataBind()
    '    'End If

    'End Sub

    Protected Sub ddlQta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlQta.SelectedIndexChanged
        CalcolaTutto()
    End Sub

    'Private Sub rptCatLav_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptCatLav.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
    '        Dim rp As Repeater = CType(e.Item.FindControl("rptLav"), Repeater)
    '        rp.DataSource = e.Item.DataItem.GetLavorazioniOpzionaliByListinoBase(L)
    '        rp.DataBind()
    '    End If
    'End Sub


    'Protected Sub rdoPiega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdoPiega.SelectedIndexChanged
    '    CalcolaTutto()
    'End Sub

    Protected ReadOnly Property IdVoceDefaultQuando() As String
        Get
            Dim Index As Integer = 0
            Try
                For Each L As ListItem In rdoQuando.Items
                    If L.Value.StartsWith("N") Then
                        Exit For
                    End If
                    Index += 1
                Next

            Catch ex As Exception

            End Try

            Return Index
        End Get
    End Property

    Private Sub rdoQuando_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdoQuando.SelectedIndexChanged
        CalcolaTutto()
    End Sub

    Private Function CreaOrdineDaModulo() As ProdottoInCarrello

        Dim O As ProdottoInCarrello = New ProdottoInCarrello()
        O.L = LRif
        O.C = LRif.ColoreStampa
        O.F = LRif.FormatoProdotto
        O.P = P

        O.ConVerificaFile = chkVerificaFile.Checked

        Dim LCorr As New List(Of ICorriereBusiness)
        Using mgrC As New CorrieriWDAO
            LCorr = mgrC.GetListaCorrieri
        End Using

        Dim Cap As String = UtenteConnesso.Utente.Cap

        'ERRORE QUI IL CAP DEVO PRENDERLO DALL'INDIRIZZO PREDEFINITO DELL'UTENTE NON DA QUELLO DEL SUO CAP
        'Dim Cs As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(UtenteConnesso.Utente.Corriere, LCorr, UtenteConnesso.Utente.Cap)
        'se non ha ancora scelto niente nel carrello prendo il cap dell'indirizzo predefinito, senno prendo il cap scelto 
        'ammenoche non sia 0 e quindi prendo il cap di registrazione

        If Carrello.IdIndirizzoScelto = -1 Then
            If UtenteConnesso.DefaultIdIndirizzoPredefinito Then
                Using i As New Indirizzo
                    i.Read(UtenteConnesso.DefaultIdIndirizzoPredefinito)
                    Cap = i.Cap
                End Using
            End If
        Else
            If Carrello.IdIndirizzoScelto <> 0 Then
                Using i As New Indirizzo
                    i.Read(Carrello.IdIndirizzoScelto)
                    Cap = i.Cap
                End Using
            End If
        End If

        Dim Cs As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(UtenteConnesso.Utente.Corriere, LCorr, Cap, FormerWebApp.NonPrendereInConsiderazioneCorriereFormer)

        Dim Corr As New CorriereW
        Corr.Read(Cs.IdCorriere)

        O.Corriere = Corr
        O.TC = LRif.TipoCarta
        O.Qta = GetQtaSelezionata()
        ' O.Qta = Convert.ToInt32(ddlQta.SelectedValue)

        Dim DataSelezionata As String = GetDataSelezionata()

        If DataSelezionata.Length Then
            O.Quando = DataSelezionata
        Else
            O.Quando = _QuandoSelected
        End If

        'qui controllo se e' stato utilizzato un promo
        If LRif.ExistPromo Then
            'qui se e' stata utilizzata la data slow hanno preso il promo
            If O.Quando.StartsWith("S") Then
                O.IdPromo = LRif.Promo.Percentuale
                O.ApplicaPromo(LRif.Promo)
            End If
        End If

        'qui calcolo 
        Dim ListaFinale As List(Of LavorazioneW) = CaricaLavorazioniSelezionate()
        For Each singLav As LavorazioneW In LRif.LavorazioniBase
            If ListaFinale.Find(Function(x) x.IdCatLav = singLav.IdCatLav) Is Nothing Then
                ListaFinale.Add(singLav)
            End If
        Next

        'Dim ListaFinale As List(Of LavorazioneW) = GetElencoCompletoLavorazioniSelezionate()

        O.LavorazioniIncluse = ListaFinale

        O.NFogli = GetNFogli()
        O.NFogliVis = TrasformaNFogli(O.NFogli)

        O.NomeLavoro = txtNomeLavoro.Text

        If ddlOrientamento.SelectedValue.Length Then
            O.OrientamentoScelto = ddlOrientamento.SelectedValue
        Else
            O.OrientamentoScelto = enTipoOrientamento.NonSpecificato
        End If

        Return O

    End Function

    Public Function GetElencoCompletoLavorazioniSelezionate() As List(Of LavorazioneW)
        'qui calcolo 
        Dim ListaFinale As List(Of LavorazioneW) = CaricaLavorazioniSelezionate()
        For Each singLav As LavorazioneW In LRif.LavorazioniBase
            If ListaFinale.Find(Function(x) x.IdCatLav = singLav.IdCatLav) Is Nothing Then
                ListaFinale.Add(singLav)
            End If
        Next

        ListaFinale = ListaFinale.FindAll(Function(x) x.LavorazioneInterna = enSiNo.No)

        Return ListaFinale
    End Function

    Private Function GetNFogli() As Integer
        Dim Ris As Integer = 1
        If LRif.ShowLabelFogli Then
            Ris = ddlFogliPagine.SelectedValue
        Else
            Ris = _Nfogli
        End If
        Return Ris
    End Function

    Private Function GetProdottoScelto() As ProdottoInCarrello
        Dim ris As ProdottoInCarrello = CreaOrdineDaModulo()

        ris.PathSchedaProdotto = Request.Url.AbsolutePath

        ris.IdMacchinarioProduzione = ViewState(KeyIdMacchinarioStampa)
        ris.PrezzoCalcolatoNettoOriginale = ViewState(KeyPrezzoCalcolatoNetto)

        'ris.IdMacchinarioProduzione = Convert.ToInt32(lblIdMacchinarioProduzione.Text)
        'ris.PrezzoCalcolatoNettoOriginale = Convert.ToDecimal(lblPrezzoValue.Text)
        If IsNumeric(lblColli.Text) Then
            ris.Colli = Convert.ToInt32(lblColli.Text)
        Else
            lblInfoDim.Text = "-"
        End If
        If IsNumeric(lblPeso.Text) Then ris.Peso = Convert.ToInt32(lblPeso.Text)
        ris.Note = txtNote.Text

        If LRif.AllowCustomSize = enSiNo.Si OrElse LRif.idGruppoLogico Then

            Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
            If Not R Is Nothing Then
                ris.Altezza = R.Altezza
                ris.Larghezza = R.Base
                ris.BufferSVG = R.BufferSVG
            End If

        Else
            ris.Altezza = IIf(txtAltezza.Text.Trim.Length, txtAltezza.Text, 0)
            ris.Larghezza = IIf(txtLarghezza.Text.Trim.Length, txtLarghezza.Text, 0)
        End If


        If P.IdReparto = enRepartoWeb.StampaDigitale Then
            Dim RisCalcoloMq As RisCalcoloMq = CalcolaMq()
            ris.Mq = RisCalcoloMq.Mq
            ris.ExtraData &= "LatoFissoRiferimento:" & RisCalcoloMq.Lato1FissoRiferimento & ";"
        End If

        If P.IdPluginToUse Then

            Select Case DirectCast(P.IdPluginToUse, enPluginOnline)
                Case enPluginOnline.Packaging
                    Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
                    If Not R Is Nothing Then
                        'qui sono passato per il plugin
                        ris.IdTipoFustella = R.IdTipoFustella
                        ris.Altezza = R.Altezza
                        ris.Larghezza = R.Base
                        ris.Profondita = R.Profondita
                        ris.BufferSVG = R.BufferSVG
                    End If
                Case enPluginOnline.Etichette
                    Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
                    If Not R Is Nothing Then
                        'qui sono passato per il plugin
                        ris.IdTipoFustella = R.IdTipoFustella
                        ris.Altezza = R.Altezza
                        ris.Larghezza = R.Base
                        ris.ExtraData &= "Categoria:" & R.Categoria & ";"
                        ris.Profondita = 0
                        ris.BufferSVG = R.BufferSVG
                    End If
                Case enPluginOnline.EtichetteCm
                    Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm))
                    If Not R Is Nothing Then
                        'qui sono passato per il plugin
                        ris.IdTipoFustella = R.IdTipoFustella
                        ris.Altezza = R.Altezza
                        ris.Larghezza = R.Base
                        ris.ExtraData &= "Categoria:" & R.Categoria & ";"
                        ris.Profondita = 0
                        ris.BufferSVG = R.BufferSVG

                        Dim Orientamento As enTipoOrientamento = enTipoOrientamento.Verticale
                        Dim LatoFisso As Integer = (LRif.LatoFissoRiferimento(R.Altezza, R.Base).LatoFissoPrincipale * 10) '(LRif.FormatoProdotto.Fc.Larghezza * 10)
                        Dim ValoreMax As Integer = LatoFisso - (FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato * 2)

                        If R.Altezza > ValoreMax Or R.Base > ValoreMax Then
                            'qui puo essere orientato solo in verticale 
                            Orientamento = enTipoOrientamento.Verticale
                        Else
                            'qui se disponibile la lavorazione devo prendere l'orientamento che seleziona il cliente dalla pagina
                            Dim cmb As RadioButtonList = ListaRDO.Find(Function(x) x.ID = "lav" & FormerLib.FormerConst.ProdottiParticolari.IdCatOrientamentoEtichette)
                            If Not cmb Is Nothing Then
                                If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
                                    Dim lav As New LavorazioneW
                                    lav.Read(Convert.ToInt32(cmb.SelectedValue))
                                    'qui ho la lav scelta e vedo nelle extra info l'orientamento

                                    Dim ed As ExtraData = lav.ListExtraData.Find(Function(x) x.Chiave = FormerLib.FormerConst.ExtraDataKey.OrientamentoEtichette)

                                    If Not ed Is Nothing Then
                                        Orientamento = ed.Valore
                                    End If

                                End If
                            Else
                                'qui provo se si tratta di una combo 
                                Dim ddl As DropDownList = ListaCombo.Find(Function(x) x.ID = "lav" & FormerLib.FormerConst.ProdottiParticolari.IdCatOrientamentoEtichette)
                                If Not ddl Is Nothing Then
                                    If ddl.SelectedValue <> String.Empty AndAlso ddl.SelectedValue <> "0" Then
                                        Dim lav As New LavorazioneW
                                        lav.Read(Convert.ToInt32(ddl.SelectedValue))
                                        Dim ed As ExtraData = lav.ListExtraData.Find(Function(x) x.Chiave = FormerLib.FormerConst.ExtraDataKey.OrientamentoEtichette)

                                        If Not ed Is Nothing Then
                                            Orientamento = ed.Valore
                                        End If
                                    End If
                                End If
                            End If
                        End If
                        ris.OrientamentoScelto = Orientamento

                    End If
            End Select

        End If

        Return ris
    End Function

    Private Sub AggiungiACarrello(Optional Compra1Click As Boolean = False)
        If UtenteConnesso.IdUtente Then
            Try
                Dim O As ProdottoInCarrello = GetProdottoScelto()

                If O.PrezzoCalcolatoNetto Then
                    'qui tutto ok 

                    Carrello.AggiungiOrdine(O)

                    MgrPlugin.ClearPlugin()

                    If Compra1Click Then
                        Response.Redirect("/compra-1-click")
                    Else
                        Response.Redirect("/carrello")
                    End If

                Else
                    'qui non ho un prodotto configurato
                    CaricaQTA()
                    CaricaLavorazioniObbligatorie()
                    CaricaQtaTabella()
                    SelezionaDefaultLavorazioni()
                    'CalcolaTutto()
                End If

            Catch ex As Exception

            End Try
        Else
            Response.Redirect(FormerRouting.GetLoginPage) '"/login")
        End If
    End Sub

    'Protected Sub btnRiepilogo_Click(sender As Object, e As ImageClickEventArgs) Handles btnRiepilogo.Click
    '    AggiungiACarrello()
    'End Sub

    Private Sub chkVerificaFile_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerificaFile.CheckedChanged
        CalcolaTutto()
    End Sub

    Private Function ValidaDimensione(Dimensione As String,
                                      Optional DefaultValue As Integer = 1) As Integer
        Dim Ris As Integer = DefaultValue
        Try
            If IsNumeric(Dimensione) Then

                Dim Dimens As Integer = Convert.ToInt32(Dimensione)
                Dimensione = Math.Abs(Dimens)
                If Dimensione Then
                    Ris = Dimensione
                End If

            End If
        Catch ex As Exception

        End Try
        Return Ris
    End Function

    Private Function ValidaDimensione(Dimensione As String,
                                      Asse As enAsseXYZ) As Integer



        Dim Ris As Integer = 0
        Dim ValoreMin As Integer = 0

        Dim _ValoreMinAltezza As Integer = 0
        Dim _ValoreMinBase As Integer = 0
        Dim _ValoreMinProfondita As Integer = 0

        _ValoreMinAltezza = MgrPluginPackaging.GetMinimoAltezza(P)
        _ValoreMinBase = MgrPluginPackaging.GetMinimoBase(P)
        _ValoreMinProfondita = MgrPluginPackaging.GetMinimoProfondita(P)

        Select Case Asse
            Case enAsseXYZ.Altezza
                ValoreMin = _ValoreMinAltezza
            Case enAsseXYZ.Base
                ValoreMin = _ValoreMinBase
            Case enAsseXYZ.Profondita
                ValoreMin = _ValoreMinProfondita
        End Select

        Try
            If Dimensione.Trim.Length Then
                If IsNumeric(Dimensione) Then

                    If P.IdFunzionePack = enFunzionePackaging.FunzioneECMA3 Then
                        'qui devo arrotondare la dimensione 
                        Select Case Asse
                            Case enAsseXYZ.Altezza
                                Dimensione = MgrPluginPackaging.ArrotondaA10mm(Dimensione)
                            Case enAsseXYZ.Base
                                Dimensione = MgrPluginPackaging.ArrotondaA10mm(Dimensione)
                            Case enAsseXYZ.Profondita
                                Dimensione = MgrPluginPackaging.ArrotondaA5mm(Dimensione)
                        End Select
                    End If

                    Dim Dimens As Integer = Math.Abs(Convert.ToInt32(Dimensione))

                    If Dimens >= ValoreMin Then
                        Ris = Dimens
                    Else
                        Ris = ValoreMin
                    End If
                Else
                    Ris = ValoreMin
                End If
            Else
                Ris = ValoreMin
            End If

        Catch ex As Exception

        End Try

        Return Ris

    End Function

    Private Function CalcolaCmLineari() As Integer
        Dim ris As Integer = 0

        ris = MgrCalcoliTecnici.CalcolaCmLineari(ValidaDimensione(txtAltezza.Text),
                                                   ValidaDimensione(txtLarghezza.Text))

        Return ris
    End Function

    Private Function CalcolaFogli(Optional QtaForzata As Integer = 0) As RisCalcoloFogli

        Dim Ris As New RisCalcoloFogli

        Dim QtaToConsider As Integer = GetQtaSelezionata()
        If QtaForzata Then
            QtaToConsider = QtaForzata
        End If

        Dim AltezzaValidata As Integer = ValidaDimensione(txtAltezza.Text)
        Dim LarghezzaValidata As Integer = ValidaDimensione(txtLarghezza.Text)

        Dim Scarto As Integer = 0

        If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio AndAlso LRif.ConSoggettiDuplicati = enSiNo.Si Then
            Scarto = FormerConst.ProdottiCaratteristiche.ScartoMMLatoSoggetto '2mm per lato per ogni misura (altezza,larghezza)
        End If

        Dim LarghezzaRif As Integer = LRif.FormatoProdotto.Larghezza
        Dim AltezzaRif As Integer = LRif.FormatoProdotto.Lunghezza

        'sviluppo i fogli che escono come sviluppo i metri quadri 
        Ris.NumeroFogli = MgrCalcoliTecnici.CalcolaFogli(LarghezzaRif,
                                                         AltezzaRif,
                                                         QtaToConsider,
                                                         AltezzaValidata,
                                                         LarghezzaValidata,
                                                         Scarto)

        Return Ris
    End Function

    Private Function CalcolaMq(Optional QtaForzata As Integer = 0) As RisCalcoloMq

        Dim Ris As New RisCalcoloMq
        Dim QtaToConsider As Integer = GetQtaSelezionata()
        If QtaForzata Then
            QtaToConsider = QtaForzata
        End If
        'Ris = MgrCalcoliTecnici.CalcolaMq(LRif.FormatoProdotto.Fc.Larghezza,
        Dim AltezzaValidata As Single = ValidaDimensione(txtAltezza.Text)
        Dim LarghezzaValidata As Single = ValidaDimensione(txtLarghezza.Text)

        Dim Scarto As Integer = 0

        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri AndAlso LRif.ConSoggettiDuplicati = enSiNo.Si Then
            Scarto = FormerConst.ProdottiCaratteristiche.ScartoMMLatoSoggetto  '2mm per lato per ogni misura (altezza,larghezza)
        End If

        If LRif.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
            AltezzaValidata = AltezzaValidata / 10
            LarghezzaValidata = LarghezzaValidata / 10
        End If

        Dim RisLatoFisso As RisLatoFissoRiferimento = LRif.LatoFissoRiferimento(AltezzaValidata,
                                                                                LarghezzaValidata,
                                                                                QtaToConsider,
                                                                                Scarto)

        Dim LatoFissoRiferimento As Single = RisLatoFisso.LatoFissoPrincipale

        Dim AltezzaFissaRiferimento As Integer = 0


        AltezzaFissaRiferimento = LRif.FormatoProdotto.LunghezzaCm



        Dim QtaToUse As Integer = QtaToConsider

        If LRif.FormatoProdotto.IsRotolo = enSiNo.Si Then
            'qui non e' un rotolo devo calcolarlo a fogli sani
            AltezzaFissaRiferimento = 0
        ElseIf LRif.FormatoProdotto.IsLastra = enSiNo.Si Then
            AltezzaFissaRiferimento = RisLatoFisso.LatoFissoSecondario
            QtaToUse = 1

        End If

        Ris.Mq = MgrCalcoliTecnici.CalcolaMq(LatoFissoRiferimento,
                                             QtaToUse,
                                             AltezzaValidata,
                                             LarghezzaValidata,,
                                             Scarto,
                                             AltezzaFissaRiferimento).AreaCalcolata

        If LRif.FormatoProdotto.IsLastra = enSiNo.Si Then
            Ris.Mq = Ris.Mq * QtaToConsider
        End If

        Ris.Lato1FissoRiferimento = LatoFissoRiferimento
        'If Ris < 1 Then Ris = 1
        'Dim LatoRiferimento As Single = LRif.FormatoProdotto.Fc.Larghezza + ((LRif.FormatoProdotto.Fc.Larghezza * 2) / 100)

        'Dim LatoMinimo As Integer = 100
        'Dim Scarto As Integer = 1
        'Dim Copie As Integer = ddlQta.SelectedValue

        'Dim Altezza As Integer = ValidaDimensione(txtAltezza.Text)
        'Dim Larghezza As Integer = ValidaDimensione(txtLarghezza.Text)

        'Dim AltezzaConScarto As Integer = Altezza + Scarto
        'Dim LarghezzaConScarto As Integer = Larghezza + Scarto

        'Dim AreaSuAltezza As Single = 0
        'Dim AreaSuLarghezza As Single = 0

        'If Altezza <= LatoRiferimento Then
        '    Dim QuantiSuRiga As Integer = LatoRiferimento \ AltezzaConScarto
        '    Dim QuanteRighe As Integer = Math.Ceiling(Copie / QuantiSuRiga)

        '    Dim AltezzaRif As Integer = QuanteRighe * LarghezzaConScarto
        '    If AltezzaRif < LatoMinimo Then
        '        AltezzaRif = LatoMinimo
        '    End If
        '    'ora calcolo i centimetri quadrati del pezzo che uso 
        '    AreaSuAltezza = LatoRiferimento * AltezzaRif
        'End If

        'If Larghezza <= LatoRiferimento Then
        '    Dim QuantiSuRiga As Integer = LatoRiferimento \ LarghezzaConScarto
        '    Dim QuanteRighe As Integer = Math.Ceiling(Copie / QuantiSuRiga)

        '    Dim AltezzaRif As Integer = QuanteRighe * AltezzaConScarto
        '    If AltezzaRif < LatoMinimo Then
        '        AltezzaRif = LatoMinimo
        '    End If
        '    'ora calcolo i centimetri quadrati del pezzo che uso 
        '    AreaSuLarghezza = LatoRiferimento * AltezzaRif

        'End If

        'Dim AreaConPannelli As Integer = 0
        'If AreaSuAltezza = 0 And AreaSuLarghezza = 0 Then
        '    'qui devo pannellizzare
        '    Dim LatoPiuCorto As Integer = 0
        '    Dim LatoMoltiplicatore As Integer = 0
        '    If Larghezza < Altezza Then
        '        LatoPiuCorto = Larghezza
        '        LatoMoltiplicatore = AltezzaConScarto
        '    Else
        '        LatoPiuCorto = Altezza
        '        LatoMoltiplicatore = LarghezzaConScarto
        '    End If

        '    Dim QuantiPannelli As Integer = Math.Ceiling(LatoPiuCorto / LatoRiferimento)
        '    AreaConPannelli = (QuantiPannelli * LatoRiferimento) * LatoMoltiplicatore * Copie

        'End If

        'Dim mqH As Single = Math.Round((AreaSuAltezza / 10000), 2)
        'Dim mqW As Single = Math.Round((AreaSuLarghezza / 10000), 2)
        'Dim mqP As Single = Math.Round((AreaConPannelli / 10000), 2)

        'If mqH > 0 Or mqW > 0 Then
        '    If mqW > 0 Then
        '        If (mqH < mqW) And mqH > 0 Then
        '            Ris = mqH
        '        Else
        '            Ris = mqW
        '        End If
        '    Else
        '        Ris = mqH
        '    End If
        'Else
        '    Ris = mqP
        'End If

        Return Ris

    End Function

    Private Sub txtAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza.TextChanged

        If txtAltezza.Text.Length Then
            rfvTAltezza.Visible = False
            'txtAltezza.BorderColor = Drawing.Color.Transparent
            Dim DimensioneValidata As Single = 0
            DimensioneValidata = ValidaDimensione(txtAltezza.Text)

            If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                Dim AltraDimensione As Single = ValidaDimensione(txtLarghezza.Text)

                If LRif.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
                    DimensioneValidata = DimensioneValidata / 10
                    AltraDimensione = AltraDimensione / 10
                End If

                DimensioneValidata = MgrCalcoliTecnici.ValidaDimensioneInBaseAFormatoProdotto(DimensioneValidata,
                                                                                              AltraDimensione,
                                                                                              LRif.FormatoProdotto)
                If LRif.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
                    DimensioneValidata = DimensioneValidata * 10
                End If
            ElseIf LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
                DimensioneValidata = ValidaDimensione(txtAltezza.Text, enAsseXYZ.Altezza)
                'Else
                '    DimensioneValidata = ValidaDimensione(txtAltezza.Text)
            End If

            txtAltezza.Text = DimensioneValidata

            If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
                MgrPlugin.EditPluginRis(LRif.Preventivazione, DimensioneValidata, enAsseXYZ.Altezza)
                ''ResetFustellaSelezionata
                ResetListinoBase()
                ResettaTipoFustella()
                CaricaFormatiProdotto()
                'If ResetListinoBase() <> 0 Or ResettaTipoFustella() = enSiNo.Si Then
                '    CaricaFormatiProdotto()
                'End If
                'ResettaFustella()
                ''If tblPrezzi.Rows.Count Then tblPrezzi.Rows.Clear()
            End If
        Else
            rfvTAltezza.Visible = True
            'txtAltezza.BorderColor = Drawing.Color.Red
        End If

        AlterateMisure = True

        If OldCalcMethod Then
            'FINE AGGIUNTA
            'txtLarghezza.Focus()

            'AGGIUNTO ORA 
            CaricaQtaTabella()
            CalcolaTutto()
            'CaricaHandlerTabella()
            'CaricaQtaTabella()
            'SetTxtFocus(txtLarghezza)
        Else
            CalcolaPersonalizzato()
        End If

        If ShowQtaCustom() Then

            SetTxtFocus(txtQtaCustom)

        End If

    End Sub

    Private OldCalcMethod As Boolean = False

    '<System.Web.Services.WebMethod>
    'Public Shared Function CalcoloClient() As String
    '    'AlterateMisure = True
    '    'FINE AGGIUNTA
    '    'txtLarghezza.Focus()

    '    'AGGIUNTO ORA 
    '    'CalcolaTutto()
    '    'CaricaHandlerTabella()
    '    'CaricaQtaTabella()
    '    'Return "ciao diego"
    '    txtAltezza.Text = "diego"
    'End Function

    Private Sub SetTxtFocus(ByRef txt As TextBox)
        Dim scriptstring As String = "$get('" & txt.ClientID & "').focus()"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "setFocus", scriptstring, True)
    End Sub

    'Private Sub ResetFustellaSelezionata()

    '    Dim lstFustelle As List(Of TipoFustellaW) = Nothing
    '    Dim fp As FormerPlugin = Nothing
    '    If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
    '        Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))

    '        If Not R Is Nothing Then
    '            Dim OldIdTipoFustella As Integer = R.IdTipoFustella
    '            If R.Altezza = 0 Or R.Base = 0 Or R.Profondita = 0 Then
    '                R.IdTipoFustella = 0
    '            Else
    '                Using mgr As New TipiFustellaWDAO
    '                    lstFustelle = mgr.FindAll("Base",
    '                                              New LUNA.LunaSearchParameter("IdPrev", P.IdPrev),
    '                                              New LUNA.LunaSearchParameter("Disponibile", enSiNo.Si),
    '                                              New LUNA.LunaSearchParameter("Profondita", 0, "<>"))

    '                    lstFustelle = MgrPlugin.FustelleCompatibili(P,
    '                                                                R.Base,
    '                                                                R.Profondita,
    '                                                                R.Altezza,
    '                                                                lstFustelle)


    '                    If lstFustelle.Count Then
    '                        For Each singTipo As TipoFustellaW In lstFustelle
    '                            If singTipo.IdTipoFustella = 0 Then
    '                                'questa e' la personalizzata e quindi vuoldire che non ci sono fustelle compatibili
    '                                R.IdTipoFustella = 0
    '                                Exit For
    '                            Else

    '                                Dim ToCheck As Boolean = True
    '                                If singTipo.Base <> R.Base Then
    '                                    ToCheck = False
    '                                End If
    '                                If ToCheck = True AndAlso singTipo.Profondita <> R.Profondita Then
    '                                    ToCheck = False
    '                                End If

    '                                If ToCheck = True AndAlso singTipo.Altezza <> R.Altezza Then
    '                                    ToCheck = False
    '                                End If

    '                                If ToCheck Then
    '                                    R.IdTipoFustella = singTipo.IdTipoFustella
    '                                    Exit For
    '                                End If

    '                            End If
    '                        Next
    '                    End If

    '                End Using
    '            End If
    '            If R.IdTipoFustella <> OldIdTipoFustella Then
    '                MgrPlugin.EditPluginRis(P, R.IdTipoFustella)
    '                CaricaLavorazioniObbligatorie()
    '            End If


    '        End If
    '    End If


    'End Sub

    Private Sub txtLarghezza_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezza.TextChanged

        If txtLarghezza.Text.Length Then
            rfvTBase.Visible = False
            Dim DimensioneValidata As Single = 0
            DimensioneValidata = ValidaDimensione(txtLarghezza.Text)

            If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                Dim AltraDimensione As Single = ValidaDimensione(txtAltezza.Text)

                If LRif.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
                    DimensioneValidata = DimensioneValidata / 10
                    AltraDimensione = AltraDimensione / 10
                End If

                DimensioneValidata = MgrCalcoliTecnici.ValidaDimensioneInBaseAFormatoProdotto(DimensioneValidata,
                                                                                              AltraDimensione,
                                                                                              LRif.FormatoProdotto)
                If LRif.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
                    DimensioneValidata = DimensioneValidata * 10
                End If
            ElseIf LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
                DimensioneValidata = ValidaDimensione(txtLarghezza.Text, enAsseXYZ.Base)
            Else
                DimensioneValidata = ValidaDimensione(txtLarghezza.Text)
            End If

            txtLarghezza.Text = DimensioneValidata

            If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
                MgrPlugin.EditPluginRis(LRif.Preventivazione, DimensioneValidata, enAsseXYZ.Base)
                'ResetFustellaSelezionata()
                'CaricaFormatiProdotto()
                ResetListinoBase()
                ResettaTipoFustella()
                CaricaFormatiProdotto()
                'If ResetListinoBase() <> 0 Or ResettaTipoFustella() = enSiNo.Si Then
                '    CaricaFormatiProdotto()
                'End If
                'ResettaFustella()
                'If tblPrezzi.Rows.Count Then tblPrezzi.Rows.Clear()
            End If
        Else
            rfvTBase.Visible = True
        End If

        AlterateMisure = True

        If OldCalcMethod Then

            CaricaQtaTabella()
            CalcolaTutto()
        Else
            CalcolaPersonalizzato()
        End If



        'SetTxtFocus(txtProfondita)
        If ShowProfondita() Then
            SetTxtFocus(txtProfondita)
        Else
            SetTxtFocus(txtAltezza)
        End If


    End Sub

    Private Sub txtProfondita_TextChanged(sender As Object, e As EventArgs) Handles txtProfondita.TextChanged
        If txtProfondita.Text.Length Then
            rfvTProfondita.Visible = False
            Dim DimensioneValidata As Single = 0

            DimensioneValidata = ValidaDimensione(txtProfondita.Text)

            If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
                DimensioneValidata = ValidaDimensione(txtProfondita.Text, enAsseXYZ.Profondita)
            Else
                DimensioneValidata = ValidaDimensione(txtProfondita.Text)
            End If

            txtProfondita.Text = DimensioneValidata

            If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
                MgrPlugin.EditPluginRis(LRif.Preventivazione, DimensioneValidata, enAsseXYZ.Profondita)
                'ResetFustellaSelezionata()
                'CaricaFormatiProdotto()
                ResetListinoBase()
                ResettaTipoFustella()
                CaricaFormatiProdotto()
                'If ResetListinoBase() <> 0 Or ResettaTipoFustella() = enSiNo.Si Then
                '    CaricaFormatiProdotto()
                'End If
                'ResettaFustella()
                'If tblPrezzi.Rows.Count Then tblPrezzi.Rows.Clear()
            End If
        Else
            rfvTProfondita.Visible = True
        End If

        AlterateMisure = True

        If OldCalcMethod Then
            'AGGIUNTO ORA 
            CaricaQtaTabella()
            CalcolaTutto()

        Else
            CalcolaPersonalizzato()
        End If

        'If ShowQtaCustom() Then

        '    SetTxtFocus(txtQtaCustom)

        'End If
        SetTxtFocus(txtAltezza)

    End Sub

    Private Sub RichiediCampioneGratuito()

        'qui prima mi salvo da dove vieni 
        Session("CampioneRichiesto") = LRif.Nome

        Response.Redirect("/richiedi-un-campione-gratuito")


    End Sub

    'Private Sub imgCampione_Click(sender As Object, e As ImageClickEventArgs) Handles imgCampione.Click

    '    RichiediCampioneGratuito()

    'End Sub

    'Private Sub lnkScarica3d_Click(sender As Object, e As EventArgs) Handles lnkScarica3d.Click
    '    ScaricaTemplate3d()
    'End Sub
    'Private Sub btnScarica3D_Click(sender As Object, e As ImageClickEventArgs) Handles btnScarica3D.Click
    '    ScaricaTemplate3d()
    'End Sub

    Private Sub lnkAddCart_ServerClick(sender As Object, e As EventArgs) Handles lnkAddCart.ServerClick
        AggiungiACarrello()
    End Sub

    Private Sub lnkDownloadModello3d_Click(sender As Object, e As EventArgs) Handles lnkDownloadModello3d.Click
        If LRif.FormatoProdotto.PdfTemplate3d.Length Then

            Dim NomeFile As String = "Template3D.pdf"
            Dim PathFisico As String = FormerWeb.FormerWebApp.PathListinoTemplate & LRif.FormatoProdotto.PdfTemplate3d

            Dim EsisteTemplateFisico As Boolean = False

            If File.Exists(Server.MapPath(PathFisico)) Then EsisteTemplateFisico = True
            If EsisteTemplateFisico Then
                If FormerWebApp.IsInternetExplorer Then
                    Response.Redirect(PathFisico)
                Else
                    'qui lo faccio scaricare
                    Response.ContentType = "application/pdf"
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" & NomeFile)
                    Response.TransmitFile(PathFisico)
                    Response.End()

                End If
            Else
                Response.Redirect("/")
            End If

        Else
            Response.Redirect("/")
        End If
    End Sub

    Private Sub lnkCampGrat_Click(sender As Object, e As EventArgs) Handles lnkCampGrat.Click
        RichiediCampioneGratuito()
    End Sub

    Private Sub lnkPreventivoPDF_Click(sender As Object, e As EventArgs) Handles lnkPreventivoPDF.Click

        Dim O As ProdottoInCarrello = GetProdottoScelto()

        Dim NomePdfGenerato As String = FormerPDFMgr.CreaPreventivoWeb(O)

        'Response.Redirect("/preventivi/" & NomePdfGenerato)

        Response.ContentType = "application/pdf"
        Response.AppendHeader("Content-Disposition", "attachment; filename=Preventivo_" & NomePdfGenerato)
        Response.TransmitFile("/preventivi/" & NomePdfGenerato)
        Response.End()

    End Sub

    Private Sub SelezionaDefaultLavorazioni()
        For Each rdo In ListaRDO
            rdo.SelectedIndex = 0
        Next

        For Each chk In ListaCheckbox
            chk.SelectedIndex = 0
        Next
    End Sub

    Private Sub MostraMisureFormatoScelto()
        If pnlMisurePersonalizzate.Visible And
           (chkMisurePersonalizzate.Checked = False Or
           (txtMisurePersBase.Text = String.Empty Or txtMisurePersAltezza.Text = String.Empty)) Then
            'mostro le misure del formato scelto

            Using f As New FormatoProdottoW
                f.Read(ddlFormato.SelectedValue)
                txtMisurePersBase.Text = f.Larghezza
                txtMisurePersAltezza.Text = f.Lunghezza
            End Using

        End If
    End Sub

    Private Sub SelezionatoFormatoProdotto()

        MostraMisureFormatoScelto()

        CaricaTipiDiCarta()
        CaricaColoriDiStampa()
        CaricaFogliPagine()
        CaricaQTA()
        CaricaLavorazioni()
        CaricaQtaTabella()
        SelezionaDefaultLavorazioni()
        CaricaOrientamento()
        CalcolaTutto()
    End Sub

    Private Sub ddlFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFormato.SelectedIndexChanged
        SelezionatoFormatoProdotto()
    End Sub

    Private Sub ddlTipoCarta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoCarta.SelectedIndexChanged
        CaricaColoriDiStampa()
        CaricaFogliPagine()
        CaricaQTA()
        CaricaLavorazioni()
        CaricaQtaTabella()
        SelezionaDefaultLavorazioni()
        CalcolaTutto()
    End Sub

    Private Sub ddlFogliPagine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFogliPagine.SelectedIndexChanged
        CaricaQtaTabella()
        CalcolaTutto()
    End Sub

    Private Sub ddlColoreStampa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlColoreStampa.SelectedIndexChanged
        CaricaFogliPagine()
        CaricaQTA()
        CaricaLavorazioni()
        CaricaQtaTabella()
        SelezionaDefaultLavorazioni()
        CalcolaTutto()
    End Sub

    Private Sub lnkCompra1Click_ServerClick(sender As Object, e As EventArgs) Handles lnkCompra1Click.ServerClick
        AggiungiACarrello(True)
    End Sub

    Private Sub rptReview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptReview.ItemDataBound
        Dim R As Review = e.Item.DataItem
        Dim ucR As ucReview = e.Item.FindControl("SingReview")
        If Not ucR Is Nothing Then
            ucR.Review = R
        End If
    End Sub

    Private Sub lnkAddCartRiepilogo_ServerClick(sender As Object, e As EventArgs) Handles lnkAddCartRiepilogo.ServerClick
        AggiungiACarrello(True)
    End Sub

    Private Sub txtQtaUser_TextChanged(sender As Object, e As EventArgs) Handles txtQtaUser.TextChanged
        CalcolaTutto()
    End Sub

    'Private Sub btnCalcolaQtaCustom_Click(sender As Object, e As EventArgs) Handles btnCalcolaQtaCustom.Click

    '    If txtQtaCustom.Text.Length Then
    '        'If IsNumeric(txtQtaCustom.Text) Then
    '        'Espandi = True
    '        'QtaAggiunta = QtaCustomValidata()
    '        'CaricaQtaTabella() b v 
    '        'CaricaHandlerTabella()
    '        'End If
    '        QtaSelezionata = QtaCustomValidata()
    '    Else
    '        QtaSelezionata = QtaDefaultDaSelezionare()

    '        'CaricaHandlerTabella()
    '    End If
    '    CalcolaTutto()
    '    CaricaQtaTabella()
    'End Sub

    'Private Sub lnkFormatoPersonalizzato_Click(sender As Object, e As EventArgs) Handles lnkFormatoPersonalizzato.Click
    '    If pnlMisurePersonalizzate.Visible = False Then
    '        'txtMisurePersBase.Text = LRif.FormatoProdotto.Larghezza
    '        'txtMisurePersAltezza.Text = LRif.FormatoProdotto.Lunghezza
    '        pnlMisurePersonalizzate.Visible = True
    '        lnkFormatoPersonalizzato.Text = "Torna ai formati standard"
    '        AggiornaPluginMisure()
    '    Else
    '        pnlMisurePersonalizzate.Visible = False
    '        lnkFormatoPersonalizzato.Text = "Formato personalizzato..."
    '        Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
    '        If Not R Is Nothing Then
    '            Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = Nothing
    '        End If
    '        AggiornaPluginMisure()
    '    End If

    'End Sub

    Private Sub AggiornaPluginMisure()

        Dim Base As Integer = ValidaDimensione(txtMisurePersBase.Text, 0)
        Dim Altezza As Integer = ValidaDimensione(txtMisurePersAltezza.Text, 0)
        lblMisurePersWrong.Visible = False

        If Base = 0 OrElse
            Altezza = 0 Then
            Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = Nothing
            MostraMisureFormatoScelto()
            If IsNumeric(txtMisurePersAltezza.Text) = False OrElse IsNumeric(txtMisurePersBase.Text) = False Then
                lblMisurePersWrong.Visible = True
                lblMisurePersWrong.Text = "Le misure inserite non sono valide"
            End If
        Else

            Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
            If R Is Nothing Then
                R = New RisultatoPluginMisurePersonalizzate
            End If

            R.Base = Base
            R.Altezza = Altezza

            Dim EffettuareCalcolo As Boolean = True

            If (R.Base = LRif.FormatoProdotto.Larghezza And R.Altezza = LRif.FormatoProdotto.Lunghezza) Or
                (R.Altezza = LRif.FormatoProdotto.Larghezza And R.Base = LRif.FormatoProdotto.Lunghezza) Then
                EffettuareCalcolo = False
            End If

            If EffettuareCalcolo Then
                'vado a selezionare dal gruppo il formato giusto

                Dim lst As List(Of ListinoBaseW) = Nothing
                'Dim ListinoScelto As ListinoBaseW = Nothing
                If LRif.idGruppoLogico Then
                    If FormerWebApp.UseStaticCollection = enSiNo.Si Then
                        lst = FormerWebApp.StaticListiniBase.FindAll(Function(x) x.idGruppoLogico = LRif.idGruppoLogico)
                    Else
                        Using L As New ListinoBaseWDAO
                            lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "idFormato"},
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.idGruppoLogico, LRif.idGruppoLogico),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
                        End Using
                    End If

                    lst = lst.FindAll(Function(x) x.IdTipoCarta = LRif.IdTipoCarta And x.IdColoreStampa = LRif.IdColoreStampa)

                Else
                    If LRif.AllowCustomSize = enSiNo.Si Then
                        lst = New List(Of ListinoBaseW)
                        lst.Add(LRif)
                    End If
                End If

                lst.Sort(Function(x, y) x.FormatoProdotto.AreaCmQuadrati.CompareTo(y.FormatoProdotto.AreaCmQuadrati))
                Dim IdFormProdScelto As Integer = 0

                Dim FirstLB As ListinoBaseW = Nothing
                Dim IdFirstLb As Integer = 0
                Dim MisureFirstH As Integer = 0
                Dim MisureFirstW As Integer = 0

                Dim MisureLastH As Integer = 0
                Dim MisureLastW As Integer = 0

                If lst.Count Then
                    FirstLB = lst(0)
                    IdFirstLb = FirstLB.IdListinoBase
                    MisureFirstH = Math.Ceiling(FirstLB.FormatoProdotto.Lunghezza * FormerConst.ProdottiCaratteristiche.PercentualeMassimaRiduzioneFormato / 100)
                    MisureFirstW = Math.Ceiling(FirstLB.FormatoProdotto.Larghezza * FormerConst.ProdottiCaratteristiche.PercentualeMassimaRiduzioneFormato / 100)

                    FirstLB = lst(lst.Count - 1)
                    MisureLastH = FirstLB.FormatoProdotto.Lunghezza
                    MisureLastW = FirstLB.FormatoProdotto.Larghezza


                    'End If

                    MisureFirstH = Arrotonda5Inferiore(MisureFirstH)
                    MisureFirstW = Arrotonda5Inferiore(MisureFirstW)

                    Dim IdFormProdSceltoV As Integer = 0
                    Dim IdFormProdSceltoO As Integer = 0
                    'testo entrambi i versi
                    For Each singL In lst
                        If singL.FormatoProdotto.Larghezza >= R.Base AndAlso singL.FormatoProdotto.Lunghezza >= R.Altezza Then
                            'trovato
                            'If singL.IdListinoBase = IdFirstLb Then
                            If (R.Base >= MisureFirstW And R.Altezza >= MisureFirstH) Or
                               (R.Altezza >= MisureFirstW And R.Base >= MisureFirstH) Then
                                IdFormProdSceltoO = singL.FormatoProdotto.IdFormProd
                                Exit For
                                '  Else
                                'IdFormProdSceltoO = 0
                                ' Exit For
                            End If
                            ' Else
                            'IdFormProdSceltoO = singL.FormatoProdotto.IdFormProd
                            'Exit For
                            'End If


                        End If
                    Next

                    For Each singL In lst
                        If singL.FormatoProdotto.Larghezza >= R.Altezza AndAlso singL.FormatoProdotto.Lunghezza >= R.Base Then
                            'trovato
                            'If singL.IdListinoBase = IdFirstLb Then
                            If (R.Base >= MisureFirstW And R.Altezza >= MisureFirstH) Or
                               (R.Altezza >= MisureFirstW And R.Base >= MisureFirstH) Then
                                IdFormProdSceltoV = singL.FormatoProdotto.IdFormProd
                                Exit For
                                '  Else
                                'IdFormProdSceltoO = 0
                                ' Exit For
                            End If
                            ' Else
                            'IdFormProdSceltoO = singL.FormatoProdotto.IdFormProd
                            'Exit For
                            'End If
                        End If
                    Next

                    Dim AreaO As Integer = 0
                    Dim AreaV As Integer = 0
                    If IdFormProdSceltoO Then
                        Using f As New FormatoProdottoW
                            f.Read(IdFormProdSceltoO)
                            AreaO = f.AreaCmQuadrati
                        End Using
                    End If

                    If IdFormProdSceltoV Then
                        Using f As New FormatoProdottoW
                            f.Read(IdFormProdSceltoV)
                            AreaV = f.AreaCmQuadrati
                        End Using
                    End If

                    If IdFormProdSceltoO <> 0 And IdFormProdSceltoV <> 0 And IdFormProdSceltoO <> IdFormProdSceltoV Then
                        'qui devo scegliere tra i due quello piu piccolo
                        If AreaO <= AreaV Then
                            IdFormProdScelto = IdFormProdSceltoO
                        Else
                            IdFormProdScelto = IdFormProdSceltoV
                        End If
                    Else
                        If IdFormProdSceltoO Then
                            IdFormProdScelto = IdFormProdSceltoO
                        ElseIf IdFormProdSceltoV Then
                            IdFormProdScelto = IdFormProdSceltoV
                        End If
                    End If
                End If

                If IdFormProdScelto = 0 Then
                    'trovato 'mostro la misure non utilizzabili
                    Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = Nothing
                    lblMisurePersWrong.Text = "Le misure inserite non sono valide <br>(min " & MisureFirstH & "x" & MisureFirstW & "mm - max  " & MisureLastH & "x" & MisureLastW & "mm)"
                    lblMisurePersWrong.Visible = True
                Else
                    R.IdFormatoProdottoScelto = IdFormProdScelto
                    Dim TestoToPrint As String = R.Base & "x" & R.Altezza

                    Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgEtichetteSteso(P,
                                                                                            R.Altezza,
                                                                                            R.Base,
                                                                                            enTipoFormaEtichetta.Custom,
                                                                                            128)

                    R.BufferSVG = Rsteso.BufferSVG

                    Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = R
                    'If LRif.LavorazioniBase.FindAll(Function(x) x.IdLavoro = FormerConst.Lavorazioni.TaglioAMisura).Count = 0 Then
                    '    Dim lavTaglioMisura As New LavorazioneW
                    '    lavTaglioMisura.Read(FormerConst.Lavorazioni.TaglioAMisura)

                    '    LRif.LavorazioniOpz.Add(lavTaglioMisura)
                    '    'CaricaLavorazioniDisponibili()
                    'End If
                End If

            Else
                Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = Nothing
            End If

        End If
        CaricaFormatiProdotto()
        SelezionatoFormatoProdotto()
    End Sub

    Private Function Arrotonda5Inferiore(ValIn As Integer) As Integer

        Dim Ris As Integer = ValIn
        Dim Resto As Integer = 0

        Resto = Ris Mod 5

        While Resto <> 0

            Ris -= 1

            If Ris > 0 Then
                Resto = Ris Mod 5
            Else
                Exit While
            End If

        End While

        Return Ris

    End Function

    'Private Sub txtMisurePersAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtMisurePersAltezza.TextChanged,
    '                                                                                       txtMisurePersBase.TextChanged
    '    AggiornaPluginMisure
    'End Sub

    Private Sub lnkCalcolaFormatoPersonalizzato_Click(sender As Object, e As EventArgs) Handles lnkCalcolaFormatoPersonalizzato.Click
        AggiornaPluginMisure()
    End Sub

    'Private Sub lnkAnnullaFormatoPersonalizzato_Click(sender As Object, e As EventArgs) Handles lnkAnnullaFormatoPersonalizzato.Click
    '    Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
    '    If Not R Is Nothing Then
    '        Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = Nothing
    '        txtMisurePersAltezza.Text = String.Empty
    '        txtMisurePersBase.Text = String.Empty
    '    End If
    '    AggiornaPluginMisure()
    'End Sub

    Private Sub chkMisurePersonalizzate_CheckedChanged(sender As Object, e As EventArgs) Handles chkMisurePersonalizzate.CheckedChanged

        If chkMisurePersonalizzate.Checked Then
            txtMisurePersAltezza.Enabled = True
            txtMisurePersBase.Enabled = True
            ddlFormato.Enabled = False
        Else
            Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
            If Not R Is Nothing Then
                Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate)) = Nothing
                txtMisurePersAltezza.Text = String.Empty
                txtMisurePersBase.Text = String.Empty
            End If

            txtMisurePersAltezza.Enabled = False
            txtMisurePersBase.Enabled = False
            ddlFormato.Enabled = True
        End If
        AggiornaPluginMisure()

    End Sub

    Private Sub txtMisurePersAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtMisurePersAltezza.TextChanged
        'AggiornaPluginMisure()
    End Sub

    Private Sub txtMisurePersBase_TextChanged(sender As Object, e As EventArgs) Handles txtMisurePersBase.TextChanged
        'AggiornaPluginMisure()
    End Sub

    Private Sub txtQtaUser_PreRender(sender As Object, e As EventArgs) Handles txtQtaUser.PreRender

    End Sub

    Private Sub btnCalcola_Click(sender As Object, e As EventArgs) Handles btnCalcola.Click
        CalcolaPersonalizzato()
    End Sub

    Private Sub CalcolaPersonalizzato()
        'qui devo capre se devo calcolare le cose cn la quantita e validare le dimensioni
        'If txtAltezza.Text.Length Then ValidaDimensione(txtAltezza.Text)
        pnlErrore.Visible = False
        If txtQtaCustom.Text.Length Then
            'If IsNumeric(txtQtaCustom.Text) Then
            'Espandi = True
            'QtaAggiunta = QtaCustomValidata()
            'CaricaQtaTabella() b v 
            'CaricaHandlerTabella()
            'End If
            QtaSelezionata = QtaCustomValidata()

            If txtQtaCustom.Text <> QtaSelezionata Then
                txtQtaCustom.Text = QtaSelezionata
            End If
            'Else
            '    QtaSelezionata = QtaDefaultDaSelezionare()

            'CaricaHandlerTabella()
        End If

        AlterateMisure = False
        Dim IdNewLb As Integer = ResetListinoBase()

        If IdNewLb <> 0 Or ResettaTipoFustella() = enSiNo.Si Then
            'LRif.Read(IdNewLb)
            CaricaFormatiProdotto()
            '_LRif = Nothing
        End If

        CaricaLavorazioni()

        CaricaQTA()
        'CaricaLavorazioniObbligatorie()
        CaricaQtaTabella()
        'SelezionaDefaultLavorazioni()
        'CaricaOrientamento()
        CalcolaTutto()

        'AlterateMisure = True

    End Sub

    Private Function ResetListinoBase() As Integer
        Dim ris As Integer
        'se resetto il listino torno idlistinobasenuovo alltrimenti torno no

        If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
            Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
            Dim RicaricaFP As Boolean = False
            If Not R Is Nothing Then
                If R.Altezza <> 0 And
                   R.Base <> 0 And
                   R.Profondita <> 0 Then
                    Dim risRice As RisPackaging = MgrPluginPackaging.GetListiniBaseCompatibili(LRif.Preventivazione,
                                                                                                   R.Altezza,
                                                                                                   R.Base,
                                                                                                   R.Profondita)

                    If risRice.ListiniBase.Count Then
                        'devo editare il formato prodotto dentro la combo
                        Dim PrimoFP As Integer = risRice.ListiniBase(0).IdFormProd
                        If LRif.IdFormProd <> PrimoFP Then
                            MgrPlugin.EditPluginRisFP(LRif.Preventivazione, PrimoFP)

                            ris = risRice.ListiniBase(0).IdListinoBase
                            'CaricaFormatiProdotto()
                            'RicaricareLavorazioni = True
                            'CaricaLavorazioni()
                        End If
                        pnlErrore.Visible = False
                    Else
                        AlterateMisure = True
                        pnlErrore.Visible = True
                    End If
                End If
            End If
        End If
        If ris Then
            _LRif = Nothing
        End If
        Return ris
    End Function

    Private Function ResettaTipoFustella() As enSiNo
        Dim ris As enSiNo = enSiNo.No

        'qui devo andare a rieditare il formato prodotto scelto
        If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then

            Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))

            If Not R Is Nothing Then
                Dim OldIdTipoFustella As Integer = R.IdTipoFustella
                If R.Altezza = 0 Or
                   R.Base = 0 Or
                   R.Profondita = 0 Then
                    R.IdTipoFustella = 0
                    ris = enSiNo.Si
                Else
                    Using mgr As New TipiFustellaWDAO
                        Dim lstFustelle As List(Of TipoFustellaW) = Nothing
                        lstFustelle = mgr.FindAll("Base",
                                                  New LUNA.LunaSearchParameter("IdPrev", LRif.Preventivazione.IdPrev),
                                                  New LUNA.LunaSearchParameter("Disponibile", enSiNo.Si),
                                                  New LUNA.LunaSearchParameter("Profondita", 0, "<>"))

                        lstFustelle = mgr.FustelleCompatibili(LRif.Preventivazione,
                                                                    R.Base,
                                                                    R.Profondita,
                                                                    R.Altezza,
                                                                    lstFustelle,
                                                                    FormerWebApp.BrowserCompatibileSVG)


                        If lstFustelle.Count Then
                            For Each singTipo As TipoFustellaW In lstFustelle
                                If singTipo.IdTipoFustella = 0 Then
                                    'questa e' la personalizzata e quindi vuoldire che non ci sono fustelle compatibili
                                    R.IdTipoFustella = 0
                                    Exit For
                                Else

                                    Dim ToCheck As Boolean = True
                                    If singTipo.Base <> R.Base Then
                                        ToCheck = False
                                    End If
                                    If ToCheck = True AndAlso singTipo.Profondita <> R.Profondita Then
                                        ToCheck = False
                                    End If

                                    If ToCheck = True AndAlso singTipo.Altezza <> R.Altezza Then
                                        ToCheck = False
                                    End If

                                    If ToCheck Then
                                        R.IdTipoFustella = singTipo.IdTipoFustella
                                        Exit For
                                    End If

                                End If
                            Next
                        End If

                    End Using

                End If
                If R.IdTipoFustella <> OldIdTipoFustella Then
                    MgrPlugin.EditPluginRis(LRif.Preventivazione, R.IdTipoFustella)
                    'CaricaLavorazioniObbligatorie()
                    ris = enSiNo.Si
                End If

            End If

        End If

        Return ris

    End Function

    Private Sub txtQtaCustom_TextChanged(sender As Object, e As EventArgs) Handles txtQtaCustom.TextChanged

        'qui valido la quantità perche se Lrif non prevede qta sotto colonna1 

        If OldCalcMethod = False Then
            CalcolaPersonalizzato()
        End If

    End Sub

    Private Sub rdoOpzioniPrezzo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdoOpzioniPrezzo.SelectedIndexChanged
        CalcolaPersonalizzato()
    End Sub

    'Private Sub lblPrezziShower_ServerClick(sender As Object, e As EventArgs) Handles lblPrezziShower.ServerClick

    '    Dim Attuale As Boolean = Espandi

    '    Espandi = Not Attuale

    '    If Attuale = False Then
    '        lblPrezziShower.InnerText = "▲ Mostra meno quantità ▲"
    '    Else
    '        lblPrezziShower.InnerText = "▼ Mostra più quantità ▼"
    '    End If

    '    CaricaQtaTabella()
    'End Sub

End Class
