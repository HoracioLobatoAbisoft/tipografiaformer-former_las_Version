Imports FormerBusinessLogic
Imports FormerBusinessLogicInterface
Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class prodotto_m
    Inherits FormerPage


    Private _IdPrev As Integer = 0
    Private _IdFormato As Integer = 0
    Private _IdTipoCarta As Integer = 0
    Private _IdColori As Integer = 0
    Private _DescrizioneUrl As String = ""
    Private _Nfogli As Integer = 0

    Private KeyQtaSelezionata As String = "QtaSelezionata"
    Private _QuandoSelected As String = ""

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

    Protected ListaCombo As New List(Of DropDownList)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PageLoad()
    End Sub

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

            Dim cmb As DropDownList = ListaCombo.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
            If Not cmb Is Nothing Then
                If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
                    Dim lav As New LavorazioneW
                    lav.Read(Convert.ToInt32(cmb.SelectedValue))
                    listaOpz.Add(lav)
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


    Public Function ShowSviluppo() As Boolean

        Dim ris As Boolean = False

        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
            ris = True
        End If

        Return ris

    End Function

    Public Function ShowProfondita() As Boolean
        Dim ris As Boolean = False
        If MgrPlugin.GetIdPluginToUse(P) = enPluginOnline.Packaging Then
            ris = True
        End If
        Return ris
    End Function

    Public Function ShowBloccoMisure() As Boolean
        Dim ris As Boolean = False
        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse
           LRif.TipoPrezzo = enTipoPrezzo.SuFoglio OrElse
           LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
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

        If ShowMisureQta() Then ris = True

        Return ris
    End Function

    Public Function ShowQtaCustom() As Boolean
        Dim ris As Boolean = False

        If LRif.AbilitaQtaSottoColonna1 = enSiNo.Si OrElse
           LRif.AbilitaQtaIntermedie = enSiNo.Si Then
            ris = True
        End If

        Return ris
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

    '    Dim Altezza As Integer = 0
    '    Dim Larghezza As Integer = 0
    '    Dim QtaRichiesta As Single = 0

    '    If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
    '        'RIATTIVARE SU ALTRI MODELLI DIGITALI
    '        Altezza = ValidaDimensione(txtAltezza.Text)
    '        Larghezza = ValidaDimensione(txtLarghezza.Text)
    '        QtaRichiesta = CalcolaMq.Mq

    '        If txtAltezza.Text.Trim.Length = 0 Or txtLarghezza.Text.Trim.Length = 0 Then
    '            lblInfoDim.Text = ""
    '            'QtaRichiesta = 0
    '        Else
    '            lblInfoDim.Text = QtaRichiesta & " m^2"
    '        End If

    '        Qta = QtaRichiesta * Qta

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

    '    CalcolareLavorazioniNonPreviste = True

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

    'Private Function CreaRigaTabella(Qta As Integer,
    '                                 QtaCouponDisp As List(Of Integer),
    '                                 SelectedVal As Integer,
    '                                 D As RisDataConsegna,
    '                                 ByRef ElencoPrezzi As List(Of Decimal)) As TableRow

    '    '_QtaCaricate.Add(Qta)

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

    '    Dim RPI As RisPrezzoIntermedio = CalcolaPrezzi(Qta,
    '                                                    0,
    '                                                    Qta)

    '    If UtenteConnesso.Tipo = enTipoRubrica.Cliente Then
    '        PrezzoCalcolatoNetto = RPI.PrezzoPubbl
    '    Else
    '        PrezzoCalcolatoNetto = RPI.PrezzoRiv
    '    End If

    '    If ElencoPrezzi.FindAll(Function(x) x = PrezzoCalcolatoNetto).Count = 0 Then
    '        ElencoPrezzi.Add(PrezzoCalcolatoNetto)
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

    '                lblQta.Text = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoFast) & "</b>"
    '                lblQta.Enabled = False
    '                'AddHandler lblQta.Click, AddressOf ClickQtaLabel
    '                C.Controls.Add(lblQta)
    '            End If

    '            R.Cells.Add(C)
    '        End If

    '        If P.ggNorm Then
    '            C = New TableCell
    '            If Qta = SelectedVal AndAlso TipoDataSelezionata.StartsWith("N") Then
    '                C.CssClass = "CellaPrezzo bkgSelected"
    '                C.Text = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard) & "</b>"
    '            Else

    '                C.CssClass = "CellaPrezzo bkgNormal"

    '                Dim lblQta As New LinkButton
    '                lblQta.ID = "lblQtaN" & Qta
    '                lblQta.CssClass = "lblQta"
    '                lblQta.CommandArgument = "N" & D.DataNormale.ToString("ddMMyyyy") & "§" & Qta

    '                lblQta.Text = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard) & "</b>"
    '                lblQta.Enabled = False
    '                C.Controls.Add(lblQta)
    '                'AddHandler lblQta.Click, AddressOf ClickQtaLabel
    '            End If

    '            R.Cells.Add(C)

    '        End If

    '        If P.ggSlow Then
    '            C = New TableCell
    '            Dim Etichetta As String = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoSlow) & "</b>"

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
    '                lblQta.Enabled = False
    '                lblQta.Text = Etichetta
    '                'AddHandler lblQta.Click, AddressOf ClickQtaLabel
    '                C.Controls.Add(lblQta)
    '            End If

    '            R.Cells.Add(C)
    '        End If
    '    Else
    '        R = Nothing
    '    End If

    '    Return R

    'End Function
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


    Private Function QtaDefaultDaSelezionare() As Integer

        Dim QtaDaSelezionare As Integer = 0
        Select Case LRif.TipoPrezzo
            Case enTipoPrezzo.SuQuantita, enTipoPrezzo.SuFoglio  'default 

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

            'Case enTipoPrezzo.SuCopie'TODO:MODIFICATOTIPOPREZZO

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

    Private Property QtaSelezionata As Integer
        Get
            Return ViewState("QtaSelezionata")
        End Get
        Set(value As Integer)
            ViewState("QtaSelezionata") = value
        End Set
    End Property

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

    Private Function CalcolaMq() As RisCalcoloMq

        Dim Ris As New RisCalcoloMq
        'Ris = MgrCalcoliTecnici.CalcolaMq(LRif.FormatoProdotto.Fc.Larghezza,
        Dim AltezzaValidata As Integer = ValidaDimensione(txtAltezza.Text)
        Dim LarghezzaValidata As Integer = ValidaDimensione(txtLarghezza.Text)

        Dim LatoFissoRiferimento As Single = LRif.LatoFissoRiferimento(AltezzaValidata, LarghezzaValidata, GetQtaSelezionata).LatoFissoPrincipale

        Dim Scarto As Integer = 0

        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri AndAlso LRif.ConSoggettiDuplicati = enSiNo.Si Then
            Scarto = 4 '2mm per lato per ogni misura (altezza,larghezza)
        End If

        Dim AltezzaFissaRiferimento As Integer = 0

        If LRif.FormatoProdotto.IsRotolo <> enSiNo.Si Then
            'qui non e' un rotolo devo calcolarlo a fogli sani
            AltezzaFissaRiferimento = LRif.FormatoProdotto.LunghezzaCm
        End If

        Ris.Mq = MgrCalcoliTecnici.CalcolaMq(LatoFissoRiferimento,
                                                   GetQtaSelezionata,
                                                   AltezzaValidata,
                                                   LarghezzaValidata,,
                                                   Scarto,
                                                   AltezzaFissaRiferimento).AreaCalcolata

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
        Dim AltezzaValidata As Integer = ValidaDimensione(txtAltezza.Text)
        Dim LarghezzaValidata As Integer = ValidaDimensione(txtLarghezza.Text)

        Dim Scarto As Integer = 0

        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri AndAlso LRif.ConSoggettiDuplicati = enSiNo.Si Then
            Scarto = FormerConst.ProdottiCaratteristiche.ScartoMMLatoSoggetto  '2mm per lato per ogni misura (altezza,larghezza)
        End If


        Dim RisLatoFisso As RisLatoFissoRiferimento = LRif.LatoFissoRiferimento(AltezzaValidata, LarghezzaValidata, QtaToConsider, Scarto)

        Dim LatoFissoRiferimento As Single = RisLatoFisso.LatoFissoPrincipale

        Dim AltezzaFissaRiferimento As Integer = 0

        AltezzaFissaRiferimento = LRif.FormatoProdotto.LunghezzaCm

        If LRif.FormatoProdotto.IsRotolo = enSiNo.Si Then
            'qui non e' un rotolo devo calcolarlo a fogli sani
            AltezzaFissaRiferimento = 0
        ElseIf LRif.FormatoProdotto.IsLastra = enSiNo.Si Then
            AltezzaFissaRiferimento = RisLatoFisso.LatoFissoSecondario
        End If

        Ris.Mq = MgrCalcoliTecnici.CalcolaMq(LatoFissoRiferimento,
                                                   QtaToConsider,
                                                   AltezzaValidata,
                                                   LarghezzaValidata,,
                                                   Scarto,
                                                   AltezzaFissaRiferimento).AreaCalcolata

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

    Public CouponDisponibili As New List(Of CouponW)


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

        Dim Altezza As Integer = 0
        Dim Larghezza As Integer = 0
        'Dim QtaRichiesta As Single = 0

        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            Altezza = ValidaDimensione(txtAltezza.Text)
            Larghezza = ValidaDimensione(txtLarghezza.Text)

            'QtaRichiesta = CalcolaMq.Mq

            'Qta = QtaRichiesta * Qta
        ElseIf LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
            Altezza = ValidaDimensione(txtAltezza.Text)
            Larghezza = ValidaDimensione(txtLarghezza.Text)

            If LRif.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
                Altezza = Altezza / 10
                Larghezza = Larghezza / 10
            End If
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

    Private Sub CaricaQtaTabella()

        'If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.Tabella Then

        '_QtaCaricate.Clear()

        Dim OldVal As Integer = 0
        'If ddlQta.SelectedValue.Length <> 0 Then
        '    OldVal = ddlQta.SelectedValue
        'End If
        'OldVal = GetQtaSelezionata()

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

            Dim Etichetta As String = "<div class=""calendarioMobile""><div class=""giornoTxt"">" & StrConv(RisDate.DataFast.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNumMobile"">" & RisDate.DataFast.ToString("dd") & "</div><div class=""mese"">" & RisDate.DataFast.ToString("MMMM") & "</div></div>"
            Dim cData As New TableCell
            cData.Text = Etichetta
            cData.CssClass = "CellaData bkgFast"
            RDate.Cells.Add(cData)
        End If

        If P.ggNorm Then
            'metto la if solo per dare uno scope alle variabili
            Dim Etichetta As String = "<div class=""calendarioMobile""><div class=""giornoTxt"">" & StrConv(RisDate.DataNormale.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNumMobile"">" & RisDate.DataNormale.ToString("dd") & "</div><div class=""mese"">" & RisDate.DataNormale.ToString("MMMM") & "</div></div>"
            Dim cData As New TableCell
            cData.Text = Etichetta
            cData.CssClass = "CellaData bkgNormal"
            RDate.Cells.Add(cData)

        End If

        If P.ggSlow Then
            Dim Etichetta As String = String.Empty
            Dim Pr As PromoW = LRif.Promo
            If Not Pr Is Nothing Then
                Etichetta = "<div class=""calendarioMobilePromo""><div class=""giornoTxtPromo"">" & StrConv(RisDate.DataSlow.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNumMobile"">" & RisDate.DataSlow.ToString("dd") & "</div><div class=""mese"">" & RisDate.DataSlow.ToString("MMMM") & "</div></div><div class='labelPromo'>Promo</div>"
            Else
                Etichetta = "<div class=""calendarioMobile""><div class=""giornoTxt"">" & StrConv(RisDate.DataSlow.ToString("dddd"), VbStrConv.ProperCase) & "</div><div class=""giornoNumMobile"">" & RisDate.DataSlow.ToString("dd") & "</div><div class=""mese"">" & RisDate.DataSlow.ToString("MMMM") & "</div></div>"
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

                    'If LRif.ConSoggettiDuplicati = enSiNo.Si Then
                    '    r.QtaDaUsareNelCalcoloLavorazioni = ValQta
                    'End If

                    If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                        r.QtaRichiesta = CalcolaMq(ValQta).Mq
                    End If

                    If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                        r.QtaRichiesta = CalcolaFogli(ValQta).NumeroFogli
                    End If
                    ListaRichiestePrezzo.Add(r)
                Next

                Dim ListaPrezziFinali As List(Of RisPrezzoIntermedio) = CalcolaPrezzi(ListaRichiestePrezzo)
                Dim ElencoPrezzi As New List(Of Decimal)

                For Each risultato In ListaPrezziFinali
                    Dim IncludiPrezzo As Boolean = True
                    If ElencoPrezzi.FindAll(Function(x) x = risultato.PrezzoRiv).Count <> 0 Then
                        If LRif.TipoPrezzo <> enTipoPrezzo.SuMetriQuadri AndAlso
                                LRif.TipoPrezzo <> enTipoPrezzo.SuFoglio Then
                            IncludiPrezzo = False
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

                'Dim ListaPrezzi As New List(Of Decimal)
                'For Each ValQta As Integer In lQta
                '    'Dim QtaS As String = FormerLib.FormerHelper.Stringhe.FormattaNumero(ValQta)
                '    'If QtaCouponDisp.FindAll(Function(x) x = LRif.qta1).Count <> 0 Then QtaS &= " *"
                '    'ddlQta.Items.Add(New ListItem(ValQta, ValQta))

                '    Dim rigaDaAggiungere As TableRow = CreaRigaTabella(ValQta, QtaCouponDisp, OldVal, RisDate, ListaPrezzi)
                '    If Not rigaDaAggiungere Is Nothing Then tblPrezzi.Rows.Add(rigaDaAggiungere)
                'Next
            End Using
        Else
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

        'End If

    End Sub

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

        If UtenteConnesso.Tipo = enTipoRubrica.Cliente Then
            PrezzoCalcolatoNetto = RPI.PrezzoPubbl
        Else
            PrezzoCalcolatoNetto = RPI.PrezzoRiv
        End If


        Dim PrezzoFast As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeFast(P)
        Dim PrezzoStandard As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeNormale
        Dim PrezzoSlow As Decimal = PrezzoCalcolatoNetto * MgrPercentualiDay.PercentualeSlow(P)

        PrezzoFast = Math.Ceiling(PrezzoFast)
        PrezzoStandard = Math.Round(PrezzoStandard)
        PrezzoSlow = Math.Floor(PrezzoSlow)

        If P.ggFast Then
            C = New TableCell

            If NumeroPezziScelti = SelectedVal AndAlso TipoDataSelezionata.StartsWith("F") Then
                C.CssClass = "CellaPrezzo bkgSelected"
                C.Text = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoFast) & "</b>"
            Else
                C.CssClass = "CellaPrezzo bkgFast"
                C.Text = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoFast) & "</b>"
                'Dim lblQta As New LinkButton
                'lblQta.CssClass = "lblQta"
                'lblQta.ID = "lblQtaF" & NumeroPezziScelti
                'lblQta.CommandArgument = "F" & D.DataFast.ToString("ddMMyyyy") & "§" & NumeroPezziScelti

                'lblQta.Text = 
                ''AddHandler lblQta.Click, AddressOf ClickQtaLabel
                'C.Controls.Add(lblQta)
            End If

            R.Cells.Add(C)
        End If

        If P.ggNorm Then
            C = New TableCell
            If NumeroPezziScelti = SelectedVal AndAlso TipoDataSelezionata.StartsWith("N") Then
                C.CssClass = "CellaPrezzo bkgSelected"
                C.Text = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard) & "</b>"
            Else

                C.CssClass = "CellaPrezzo bkgNormal"
                C.Text = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard) & "</b>"
                'Dim lblQta As New LinkButton
                'lblQta.ID = "lblQtaN" & NumeroPezziScelti
                'lblQta.CssClass = "lblQta"
                'lblQta.CommandArgument = "N" & D.DataNormale.ToString("ddMMyyyy") & "§" & NumeroPezziScelti

                'lblQta.Text = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoStandard) & "</b>"
                'C.Controls.Add(lblQta)
                'AddHandler lblQta.Click, AddressOf ClickQtaLabel
            End If

            R.Cells.Add(C)

        End If

        If P.ggSlow Then
            C = New TableCell
            Dim Etichetta As String = "<b>&euro; " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoSlow) & "</b>"

            Dim PrezzoPromo As Decimal = PrezzoSlow

            'qui controllo se per caso c'è un promo
            Dim Pr As PromoW = LRif.Promo
            If Not Pr Is Nothing Then
                PrezzoPromo = Pr.GetPrezzoPromo(PrezzoSlow)
                Etichetta = "<div class=""prezzoBarrato"">" & Etichetta & "</div>"
                Etichetta &= "<div class=""prezzoPromo"">" & FormerHelper.Stringhe.FormattaPrezzo(PrezzoPromo) & "</div>"

            End If

            If NumeroPezziScelti = SelectedVal AndAlso TipoDataSelezionata.StartsWith("S") Then
                C.CssClass = "CellaPrezzo bkgSelected"
                C.Text = Etichetta
            Else

                C.CssClass = "CellaPrezzo bkgSlow"
                C.Text = Etichetta
                'Dim lblQta As New LinkButton
                'lblQta.ID = "lblQtaS" & NumeroPezziScelti
                'lblQta.CssClass = "lblQta"
                'lblQta.CommandArgument = "S" & D.DataSlow.ToString("ddMMyyyy") & "§" & NumeroPezziScelti

                'lblQta.Text = Etichetta
                ''AddHandler lblQta.Click, AddressOf ClickQtaLabel
                'C.Controls.Add(lblQta)
            End If

            R.Cells.Add(C)
        End If

        Return R

    End Function
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

    Private Property AlterateMisure As Integer
        Get
            Return ViewState("AlterateMisure")
        End Get
        Set(value As Integer)
            ViewState("AlterateMisure") = value
        End Set
    End Property

    Private Sub PageLoad()


        _IdPrev = Convert.ToInt32(Page.RouteData.Values("idp"))
        _IdFormato = Convert.ToInt32(Page.RouteData.Values("idf"))
        _IdTipoCarta = Convert.ToInt32(Page.RouteData.Values("idc"))
        _IdColori = Convert.ToInt32(Page.RouteData.Values("ids"))
        _DescrizioneUrl = Convert.ToString(Page.RouteData.Values("descrizione"))
        _Nfogli = Convert.ToInt32(Page.RouteData.Values("nfogli"))

        If P.DispOnline = False Then
            Response.Redirect("/")
        End If

        MgrPlugin.CheckNeedPlugin(P, enStepWizard.Prodotto)

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

        If Not IsPostBack Then

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


            CaricaFormatiProdotto()
            ddlFormato.SelectedValue = _IdFormato
            'MostraMisureFormatoScelto()
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

        End If

        CaricaLavorazioni()

        If Not IsPostBack Then

            _TitoloPagina = "Tipografia Former Online, il tuo mondo della stampa a Roma - Stampa "
            _TitoloPagina &= P.Descrizione & " "
            _TitoloPagina &= LRif.FormatoProdotto.Formato & " "
            _TitoloPagina &= LRif.TipoCarta.Tipologia & " "
            _TitoloPagina &= LRif.ColoreStampa.Descrizione & " "
            If LRif.ShowLabelFogli() Then
                _TitoloPagina &= GetNFogli() & " " & LRif.GetLabelFogli() & " "
            End If

            '_TitoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
            Title = _TitoloPagina

            CaricaQTA()

            CaricaQtaTabella()
            CalcolaPersonalizzato()
        Else

            CaricaHandlerTabella()

        End If

        'If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
        '    pnlMisure.Visible = True
        'End If

    End Sub


    Private _TitoloPagina As String = String.Empty
    Protected ReadOnly Property TitoloPagina As String
        Get
            Return _TitoloPagina
        End Get
    End Property
    Public Function GetEtichettaMisure() As String
        Dim ris As String = String.Empty
        ris = FormerEnumHelper.TipoUnitaDiMisura(LRif.TipoUnitaMisuraInInput)
        Return ris
    End Function
    Private Sub CaricaHandlerTabella()

        'If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.Tabella Then

        'qui devo rimuovere i vecchi handler

        Dim RisDate As RisDataConsegna = GetDateConsegna()

        If LRif.TipoPrezzo = enTipoPrezzo.SuQuantita Then 'default 
            'ddlQta.Items.Add("Selezionare una quantità")
            Using mgr As New MgrQtaListinoBase
                Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                'Dim QtaAggiunta As Integer = QtaCustomValidata()

                'If QtaAggiunta <> 0 Then

                '    For Each qtaC As Integer In GetListaQtaCustom(QtaAggiunta)
                '        If lQta.FindAll(Function(x) x = qtaC).Count = 0 Then
                '            lQta.Add(qtaC)
                '        End If
                '    Next
                '    lQta.Sort(Function(x, y) x.CompareTo(y))
                'End If

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
        End If

        'End If

    End Sub
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
    Private Function CreaHandlerTabella(Qta As Integer,
                                        D As RisDataConsegna) As TableRow

        Dim R As New TableRow

        If P.ggFast Then
            Dim C As New TableCell

            Dim lblQta As New LinkButton
            lblQta.ID = "lblQtaF" & Qta
            lblQta.CommandArgument = "F" & D.DataFast.ToString("ddMMyyyy") & "§" & Qta
            'AddHandler lblQta.Click, AddressOf ClickQtaLabel
            C.Controls.Add(lblQta)
            R.Cells.Add(C)
        End If

        If P.ggNorm Then
            Dim C As New TableCell

            Dim lblQta As New LinkButton
            lblQta.ID = "lblQtaN" & Qta
            lblQta.CommandArgument = "N" & D.DataNormale.ToString("ddMMyyyy") & "§" & Qta
            'AddHandler lblQta.Click, AddressOf ClickQtaLabel
            C.Controls.Add(lblQta)
            R.Cells.Add(C)
        End If

        If P.ggSlow Then
            Dim C As New TableCell

            Dim lblQta As New LinkButton
            lblQta.ID = "lblQtaS" & Qta
            lblQta.CommandArgument = "S" & D.DataSlow.ToString("ddMMyyyy") & "§" & Qta
            'AddHandler lblQta.Click, AddressOf ClickQtaLabel
            C.Controls.Add(lblQta)
            R.Cells.Add(C)
        End If

        Return R

    End Function
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
    Protected ReadOnly Property OgTitle As String
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = LRif.Nome
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

    Protected ReadOnly Property OgDescription As String
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = LRif.DescrSitoGoogleFormattedInLine

            Return ris
        End Get
    End Property

    Public ReadOnly Property GetImgTestata As String
        Get

            Dim ris As String = String.Empty

            If LRif.Preventivazione.ImgRif.Length Then

                ris = FormerWeb.FormerWebApp.PathListinoImg & LRif.Preventivazione.ImgRif 'LRif.ImgSito
            Else
                ris = FormerWeb.FormerWebApp.PathListinoImg & LRif.Preventivazione.ImgSito

            End If

            Return ris
        End Get
    End Property


    Private Sub CaricaQTA()

        'qui prima guardo per vedere se per caso ci sta un valore gia selezionato 
        Dim OldVal As Integer = 0
        'If ddlQta.SelectedValue.Length <> 0 Then
        '    OldVal = ddlQta.SelectedValue
        'End If
        'OldVal = GetQtaSelezionata()

        If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.ComboBox Then

            ddlQta.Items.Clear()

            Dim QtaCouponDisp As New List(Of Integer)

            For Each SingC As CouponW In CouponDisponibili
                If QtaCouponDisp.FindAll(Function(x) x = SingC.QtaSpecifica).Count = 0 Then QtaCouponDisp.Add(SingC.QtaSpecifica)
            Next

            Select Case LRif.TipoPrezzo
                Case enTipoPrezzo.SuQuantita, enTipoPrezzo.SuFoglio  'default 

                    'ddlQta.Items.Add("Selezionare una quantità")
                    'qui sulla voce da selezionare devo prendere il default in base al reparto

                    Dim VoceDaSelezionare As Integer = 3

                    If LRif.Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
                        VoceDaSelezionare = 0
                    End If

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
                    ddlQta.SelectedIndex = 0

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
                    Dim LatoFisso As Single = LRif.LatoFissoRiferimento.LatoFissoPrincipale

                    If LRif.LargRotolo.IndexOf("100") <> -1 Then
                        LatoFisso = 100
                    End If

                    'da riattivare
                    txtLarghezza.Text = LatoFisso 'LRif.FormatoProdotto.Fc.Larghezza
                    txtAltezza.Text = Math.Round(10000 / LatoFisso) 'F.Fc.Larghezza

            End Select

        ElseIf LRif.TipoControlloPrezzo = enTipoControlloPrezzo.TextBox Then

            txtQtaUser.Text = String.Empty

            Dim QtaCouponDisp As New List(Of Integer)

            For Each SingC As CouponW In CouponDisponibili
                If QtaCouponDisp.FindAll(Function(x) x = SingC.QtaSpecifica).Count = 0 Then QtaCouponDisp.Add(SingC.QtaSpecifica)
            Next

            Select Case LRif.TipoPrezzo
                Case enTipoPrezzo.SuQuantita, enTipoPrezzo.SuFoglio 'default 

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

                Case enTipoPrezzo.SuMetriQuadri
                    Using mgr As New MgrQtaListinoBase
                        Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                        txtQtaUser.Text = lQta(0)

                    End Using

                    Dim LatoFisso As Single = LRif.LatoFissoRiferimento.LatoFissoPrincipale

                    If LRif.LargRotolo.IndexOf("100") <> -1 Then
                        LatoFisso = 100
                    End If

                    'DA RIATTIVARE
                    'txtLarghezza.Text = LatoFisso 'LRif.FormatoProdotto.Fc.Larghezza
                    'txtAltezza.Text = Math.Round(10000 / LatoFisso) 'F.Fc.Larghezza

            End Select
        End If


    End Sub
    Private Function Comparer(ByVal x As CatLavW, ByVal y As CatLavW) As Integer

        Dim result As Integer = x.NumeroLavorazioni(LRif.IdListinoBase).CompareTo(y.NumeroLavorazioni(LRif.IdListinoBase))
        If result = 0 Then result = x.Descrizione.CompareTo(y.Descrizione)
        Return result

    End Function

    Private Sub SelezioneVoceCombo(sender As Object, e As EventArgs)
        CaricaQtaTabella()
    End Sub

    Private Sub CaricaLavorazioni()

        LRif.CaricaLavorazioniBase()
        LRif.CaricaLavorazioniOpz()

        Dim Rp As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
        If Not Rp Is Nothing Then
            'qui va aggiunto il taglio a misura
            'la lavorazione nn è piu fissa ma variabile

            Dim IdLavTaglioAMisura As Integer = FormerConst.Lavorazioni.TaglioAMisura
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
                    Dim LFust As New LavorazioneW
                    LFust.Read(FormerConst.Lavorazioni.CreazioneFustella) ' LUNA.LunaContext.IdLavCreazioneFustella)
                    LRif.LavorazioniBase.Insert(0, LFust)
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

        Dim L As List(Of LavorazioneW) = LRif.LavorazioniBase
        Dim LObbligate As New List(Of LavorazioneW)

        For Each singL In L
            If LRif.LavorazioniOpz.FindAll(Function(x) x.IdCatLav = singL.IdCatLav).Count = 0 Then
                LObbligate.Add(singL)
            End If
        Next

        'L = L.FindAll(Function(sing) sing.CatLav.TipoControllo <> enTipoControllo.ComboBox)

        rptOpzioni.DataSource = LObbligate.FindAll(Function(x) x.LavorazioneInterna = enSiNo.No)
        rptOpzioni.DataBind()

    End Sub

    Public ReadOnly Property EtichettaFormato As String
        Get
            Dim ris As String = "Formato"

            If LRif.Preventivazione.IdReparto = enRepartoWeb.Ricamo Then
                ris = "Categoria"
            End If

            Return ris
        End Get
    End Property
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
        'FINE AGGIUNTA
        'txtLarghezza.Focus()

        'AGGIUNTO ORA 
        'CalcolaTutto()
        'CaricaHandlerTabella()
        CaricaQtaTabella()
        'SetTxtFocus(txtLarghezza)

        If ShowProfondita() Then
            SetTxtFocus(txtProfondita)
        Else
            SetTxtFocus(txtQtaCustom)
        End If
    End Sub

    Private Sub SetTxtFocus(ByRef txt As TextBox)
        Dim scriptstring As String = "$get('" & txt.ClientID & "').focus()"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "setFocus", scriptstring, True)
    End Sub

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
        'FINE AGGIUNTA
        'If ddlQta.Visible Then ddlQta.Focus()
        'txtAltezza.Focus()

        'AGGIUNTO ORA 
        'CalcolaTutto()
        CaricaQtaTabella()
        'SetTxtFocus(txtProfondita)
        SetTxtFocus(txtAltezza)
    End Sub
    Private Sub SelezionatoFormatoProdotto()

        'MostraMisureFormatoScelto()

        CaricaTipiDiCarta()
        CaricaColoriDiStampa()
        CaricaFogliPagine()
        CaricaQTA()
        CaricaLavorazioni()
        CaricaQtaTabella()
        'SelezionaDefaultLavorazioni()
        'CaricaOrientamento()
        'CalcolaTutto()
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
        'SelezionaDefaultLavorazioni()
        'CalcolaTutto()
    End Sub

    Private Sub ddlFogliPagine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFogliPagine.SelectedIndexChanged
        'CalcolaTutto()
        CaricaQtaTabella()
    End Sub

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

    Private Sub ddlColoreStampa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlColoreStampa.SelectedIndexChanged
        CaricaFogliPagine()
        CaricaQTA()
        CaricaLavorazioni()
        CaricaQtaTabella()
        'SelezionaDefaultLavorazioni()
        'CalcolaTutto()
    End Sub

    Private Sub CaricaLavorazioniDisponibili()

        'tableLav.CssClass = "tableLav"
        'tableLav.Rows.Clear()

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

        Dim lcDDL As List(Of CatLavW) = lc 'lc.FindAll(Function(cX) cX.TipoControllo = enTipoControllo.ComboBox)

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
            'Dim misura As New WebControls.Unit(300, UnitType.Pixel)
            'ddl.Width = misura

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

            'If CreareIcoInfo Then CreaInfoImg(ddl)

        Next



    End Sub

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

    Private Sub btnCalcola_Click(sender As Object, e As EventArgs) Handles btnCalcola.Click
        CalcolaPersonalizzato()
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
    Private Function QtaCustomValidata() As Integer

        Dim Ris As Integer = 0

        Dim Val As String = txtQtaCustom.Text
        Val = Val.Replace(".", ",")

        If IsNumeric(Val) Then
            Dim ValInterm As Single = CSng(Val)
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
            'Else
            '    QtaSelezionata = QtaDefaultDaSelezionare()

            'CaricaHandlerTabella()
        End If

        AlterateMisure = False
        Dim IdNewLb As Integer = ResetListinoBase()

        If IdNewLb <> 0 Or ResettaTipoFustella() = enSiNo.Si Then
            'LRif.Read(IdNewLb)
            'LRif.Read(IdNewLb)
            CaricaFormatiProdotto()
            CaricaLavorazioni()
        End If
        CaricaQTA()
        'CaricaLavorazioniObbligatorie()
        CaricaQtaTabella()

        'CaricaOrientamento()



        'CalcolaTutto()

        'AlterateMisure = True

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
        'FINE AGGIUNTA
        'If ddlQta.Visible Then ddlQta.Focus()
        'txtAltezza.Focus()

        'AGGIUNTO ORA 
        'CalcolaTutto()
        CaricaQtaTabella()

        If ShowQtaCustom() Then

            SetTxtFocus(txtQtaCustom)

        End If

    End Sub

    Private Sub btnCalcola_Command(sender As Object, e As CommandEventArgs) Handles btnCalcola.Command

    End Sub
End Class