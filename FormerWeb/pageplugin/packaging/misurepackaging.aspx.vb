Imports FormerDALWeb
Imports FormerLib.FormerEnum

Imports FormerBusinessLogicInterface
Imports FormerGraphics

Public Class pMisurePackaging
    Inherits FormerPluginPage

    Private _ValoreMinAltezza As Integer = 0
    Private _ValoreMinBase As Integer = 0
    Private _ValoreMinProfondita As Integer = 0

    Private _idP As Integer = 0

    Public ReadOnly Property IdP As Integer
        Get
            Return _idP
        End Get
    End Property

    Public P As PreventivazioneW = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("PageTitle") = "Inserisci le misure del tuo Prodotto"

        _idP = Convert.ToInt32(Page.RouteData.Values("idp"))
        P = New PreventivazioneW
        P.Read(_idP)

        _ValoreMinAltezza = MgrPluginPackaging.GetMinimoAltezza(P)
        _ValoreMinBase = MgrPluginPackaging.GetMinimoBase(P)
        _ValoreMinProfondita = MgrPluginPackaging.GetMinimoProfondita(P)

        If Not IsPostBack Then

            Dim titoloPagina As String = "Tipografia Former Online: Realizzazione "

            If P.DispOnline = False Then
                Response.Redirect("/")
            ElseIf MgrPlugin.GetIdPluginToUse(P) <> enPluginOnline.Packaging Then
                Response.Redirect("/")
            End If

            titoloPagina &= P.Descrizione
            titoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
            Title = titoloPagina

            'txtAltezza.Text = ValidaDimensione("105", enAsseXYZ.Altezza)
            'txtBase.Text = ValidaDimensione("70", enAsseXYZ.Base)
            'txtProfondita.Text = ValidaDimensione("25", enAsseXYZ.Profondita)
            If P.IdFunzionePack = enFunzionePackaging.FunzioneECMA3 Then
                txtProfondita.Enabled = False
            End If
            CaricaCompatibili()

        End If

    End Sub

    Private Function ValidaDimensione(Dimensione As String, Asse As enAsseXYZ) As Integer

        Dim Ris As Integer = 0
        Dim ValoreMin As Integer = 0

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
    Private Function FustelleCompatibili(P As PreventivazioneW,
                                         Base As Integer,
                                         Profondita As Integer,
                                         Altezza As Integer,
                                         lst As List(Of TipoFustellaW)) As List(Of TipoFustellaW)

        'Dim ris As List(Of TipoFustellaW) = MgrPlugin.FustelleCompatibili(P,
        '                                                                  Base,
        '                                                                  Profondita,
        '                                                                  Altezza,
        '                                                                  lst)

        Dim ris As List(Of TipoFustellaW) = Nothing

        Using mgr As New TipiFustellaWDAO
            ris = mgr.FustelleCompatibili(P,
                                            Base,
                                            Profondita,
                                            Altezza,
                                            lst,
                                            FormerWebApp.BrowserCompatibileSVG)
        End Using

        'Dim TipoFustella As String = P.IdFunzionePack
        'If TipoFustella = enFunzionePackaging.FunzioneECMA4 Then

        'Else

        'End If


        'Dim DiffMax As Integer = 5
        'Dim ris As New List(Of TipoFustellaW)

        'For Each F As TipoFustellaW In lst
        '    Dim Compatibile As Boolean = True
        '    If Profondita Then
        '        If Math.Abs(F.Profondita - Profondita) > DiffMax Then
        '            Compatibile = False
        '        End If
        '    End If
        '    If Altezza Then
        '        If Math.Abs(F.Altezza - Altezza) > DiffMax Then
        '            Compatibile = False
        '        End If
        '    End If
        '    If Base Then
        '        If Math.Abs(F.Base - Base) > DiffMax Then
        '            Compatibile = False
        '        End If
        '    End If
        '    If Compatibile Then
        '        Dim mgr As New MgrPackagingDraw
        '        Dim Buffer As String = String.Empty
        '        Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P, F.Altezza, F.Base, F.Profondita)
        '        If FormerWebApp.BrowserCompatibileSVG Then
        '            Buffer = Rsteso.BufferSVG
        '        Else
        '            Buffer = "<img src=""" & GetImgMisure() & """ class=""svgRend"">"
        '        End If
        '        F.RisultatoStesoAltezza = Rsteso.Heigth
        '        F.RisultatoStesoBase = Rsteso.Width
        '        F.SvgRender = Buffer
        '        ris.Add(F)
        '    End If
        'Next

        'Dim AggiungiPersonalizzata As Boolean = False

        'If Profondita <> 0 Then
        '    If ris.FindAll(Function(x) x.Profondita = Profondita).Count = 0 Then
        '        AggiungiPersonalizzata = True
        '    End If
        'End If

        'If AggiungiPersonalizzata = False AndAlso Altezza <> 0 Then
        '    If ris.FindAll(Function(x) x.Altezza = Altezza).Count = 0 Then
        '        AggiungiPersonalizzata = True
        '    End If
        'End If

        'If AggiungiPersonalizzata = False AndAlso Base <> 0 Then
        '    If ris.FindAll(Function(x) x.Base = Base).Count = 0 Then
        '        AggiungiPersonalizzata = True
        '    End If
        'End If

        ''prima di aggiuyngere la personalizzata se ho tuitti e tre i valori vedo se entra
        'If AggiungiPersonalizzata AndAlso (Base <> 0 And Altezza <> 0 And Profondita <> 0) Then
        '    Dim r As RisPackaging = MgrPluginPackaging.GetListiniBaseCompatibili(P, Altezza, Base, Profondita)

        '    If r.ListiniBase.Count = 0 Then
        '        AggiungiPersonalizzata = False
        '    End If

        'End If

        'If AggiungiPersonalizzata Then
        '    Dim F As New TipoFustellaW
        '    F.Profondita = Profondita
        '    F.Base = Base
        '    F.Altezza = Altezza
        '    Dim Buffer As String = String.Empty
        '    If Base <> 0 And Altezza <> 0 And Profondita <> 0 Then
        '        Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P, F.Altezza, F.Base, F.Profondita)
        '        If FormerWebApp.BrowserCompatibileSVG Then
        '            Buffer = Rsteso.BufferSVG
        '        Else
        '            Buffer = "<img src=""" & GetImgMisure() & """ class=""svgRend"">"
        '        End If
        '        F.RisultatoStesoAltezza = Rsteso.Heigth
        '        F.RisultatoStesoBase = Rsteso.Width
        '    Else
        '        Buffer = "<img src=""" & GetImgMisure() & """ class=""svgRend"">"
        '    End If

        '    F.SvgRender = Buffer
        '    ris.Add(F)
        'End If

        ''ora qui ho tutte le compatibili, le ordini sempre per base che e' il primo parametro
        'ris.Sort(AddressOf Comparer)

        Return ris

    End Function

    'Public Function GetImgMisure() As String

    '    Return MgrPlugin.GetImgMisure(P)

    '    'Dim ris As String = "/img/packagingmisure.png"

    '    'If P.IdFunzionePack = enFunzionePackaging.FunzioneECMA3 Then
    '    '    ris = "/img/packagingmisureCuscino.png"
    '    'End If

    '    'Return ris
    'End Function

    Private Function Comparer(ByVal x As TipoFustellaW, ByVal y As TipoFustellaW) As Integer
        Dim result As Integer = x.IdTipoFustella.CompareTo(y.IdTipoFustella)
        If result = 0 Then result = x.Base.CompareTo(y.Base)
        If result = 0 Then result = x.Profondita.CompareTo(y.Profondita)
        If result = 0 Then result = x.Altezza.CompareTo(y.Altezza)
        Return result
    End Function

    Private Sub CaricaCompatibili()

        pnlTutteMis.Visible = False

        Dim P As New PreventivazioneW
        P.Read(IdP)

        Dim lstFustelle As List(Of TipoFustellaW) = Nothing

        'qui devo prendere in considerazione solo le fustelle a tre misure

        Using mgr As New TipiFustellaWDAO
            lstFustelle = mgr.FindAll("Base", New LUNA.LunaSearchParameter("IdPrev", IdP),
                                      New LUNA.LunaSearchParameter("Disponibile", enSiNo.Si),
                                      New LUNA.LunaSearchParameter("Profondita", 0, "<>"))
        End Using

        Dim Base As Integer = 0
        Dim Altezza As Integer = 0
        Dim Profondita As Integer = 0

        If IsNumeric(txtBase.Text) Then
            Base = txtBase.Text
        End If

        If IsNumeric(txtAltezza.Text) Then
            Altezza = txtAltezza.Text
        End If

        If txtProfondita.Enabled = False Then
            txtProfondita.Text = MgrPluginPackaging.GetProfonditaCalcolataPackagingCuscino(P, Base)
        End If

        If IsNumeric(txtProfondita.Text) Then
            Profondita = txtProfondita.Text
        End If

        lstFustelle = FustelleCompatibili(P, Base, Profondita, Altezza, lstFustelle)

        rdoFustelle.Items.Clear()

        If lstFustelle.Count > 12 Then
            lnkProsegui.Visible = True
        Else
            lnkProsegui.Visible = False
        End If

        If lstFustelle.Count Then

            Dim TrovataOttimale As Boolean = False
            For Each F As TipoFustellaW In lstFustelle

                Dim listSing As New ListItem
                Dim Testo As String = String.Empty
                Testo = "<div "
                If F.IdTipoFustella = 0 Then
                    Testo &= "class = ""hasTooltip newFust"""
                Else
                    Testo &= "class = ""hasTooltip """
                End If
                Testo &= ">"
                Testo &= IIf(F.Base, F.Base, "? ") & "x" & IIf(F.Altezza, F.Altezza, " ?") & "x" & IIf(F.Profondita, F.Profondita, " ? ")
                Testo &= F.SvgRender
                If F.IdTipoFustella = 0 Then
                    Testo &= " <br><b class=""notaFust"">* Sovrapprezzo Creazione Fustella</b>"
                End If
                Testo &= "</div>"
                Testo &= "<div class=""hidden tooltiptext""><img src=""/img/icoInformation.png"" class=""imgSx"" /><h4>" & P.Descrizione & "</h4>Chiuso: " & F.Base & "x" & F.Altezza & "x" & F.Profondita & " mm<br>"
                Testo &= "Steso: " & F.RisultatoStesoAltezza & "x" & F.RisultatoStesoBase & " mm"
                Testo &= "</div>" 'chiudo il div dell'hover

                listSing.Text = Testo

                listSing.Value = F.IdTipoFustella
                If F.IdTipoFustella = 0 Then
                    listSing.Selected = True
                Else
                    If TrovataOttimale = False Then
                        Dim ToCheck As Boolean = True
                        If Base Then
                            If F.Base <> Base Then
                                ToCheck = False
                            End If
                        End If
                        If Profondita AndAlso ToCheck = True Then
                            If F.Profondita <> Profondita Then
                                ToCheck = False
                            End If
                        End If
                        If Altezza AndAlso ToCheck = True Then
                            If F.Altezza <> Altezza Then
                                ToCheck = False
                            End If
                        End If
                        If ToCheck Then
                            listSing.Selected = True
                            TrovataOttimale = True
                        End If
                    End If

                End If

                rdoFustelle.Items.Add(listSing)

            Next

            rdoFustelle.Attributes.Add("onclick", "JavaScript: highlightRadioButtonList(this);")

            'call onclick 
            ScriptManager.RegisterStartupScript(Me.PannelloDinamico, Me.PannelloDinamico.GetType, "test", "highlightRadioButtonList(" & rdoFustelle.ClientID & ");", True)
            pnlFuoriMis.Visible = False
        Else
            If IsPostBack Then pnlFuoriMis.Visible = True
        End If

    End Sub

    Private Sub Prosegui()

        Dim Base As Integer = 0
        Dim Altezza As Integer = 0
        Dim Profondita As Integer = 0
        Dim IdTipoFustella As Integer = 0
        If rdoFustelle.SelectedValue.Length Then
            IdTipoFustella = rdoFustelle.SelectedValue
        End If

        If IdTipoFustella Then
            'qui ha selezionato una fustella
            Dim f As New TipoFustellaW
            f.Read(IdTipoFustella)
            Base = f.Base
            Altezza = f.Altezza
            Profondita = f.Profondita

        Else
            'qui ha un modello personalizzato
            Base = ValidaDimensione(txtBase.Text, enAsseXYZ.Base)
            Altezza = ValidaDimensione(txtAltezza.Text, enAsseXYZ.Altezza)
            Profondita = ValidaDimensione(txtProfondita.Text, enAsseXYZ.Profondita)

        End If

        If Base <> 0 And Altezza <> 0 And Profondita <> 0 Then

            Dim P As New PreventivazioneW
            P.Read(IdP)

            Dim ris As RisPackaging = MgrPluginPackaging.GetListiniBaseCompatibili(P, Altezza, Base, Profondita)

            If ris.ListiniBase.Count Then
                'qui salvo il risultato in sessione e rientro nel wizard
                Dim IdFormatoProdotto As Integer = ris.ListiniBase(0).IdFormProd
                If IdFormatoProdotto Then
                    Dim R As New RisultatoPluginPackaging

                    R.Altezza = ValidaDimensione(Altezza, enAsseXYZ.Altezza)
                    R.Base = ValidaDimensione(Base, enAsseXYZ.Base)
                    R.Profondita = ValidaDimensione(Profondita, enAsseXYZ.Profondita)
                    R.IdFormatoProdottoScelto = IdFormatoProdotto
                    R.IdTipoFustella = IdTipoFustella
                    R.NomeInUrl = "Misure-" & R.Base & "x" & R.Profondita & "x" & R.Altezza

                    Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P, R.Altezza, R.Base, R.Profondita, 128)

                    R.BufferSVG = Rsteso.BufferSVG

                    Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging)) = R

                    'redirect alla pagina del wizard dove rientro
                    Dim newUrl As String = FormerUrlCreator.GetUrl(P.IdPrev, IdFormatoProdotto) '"/" & P.IdPrev & "/" & IdFormatoProdotto & "/" & P.NomeInUrl & "_Misure_" & R.Base & "x" & R.Profondita & "x" & R.Altezza

                    Response.Redirect(newUrl)

                End If
            End If
        Else
            'qui ha per forza selezionato un modello personalizzato senza inserire tutte le misure
            pnlTutteMis.Visible = True
        End If
    End Sub

    Private Sub txtBase_TextChanged(sender As Object, e As EventArgs) Handles txtBase.TextChanged
        If txtBase.Text.Length Then txtBase.Text = ValidaDimensione(txtBase.Text, enAsseXYZ.Base)
        CaricaCompatibili()
        txtAltezza.Focus()
    End Sub

    Private Sub txtProfondita_TextChanged(sender As Object, e As EventArgs) Handles txtProfondita.TextChanged
        If txtProfondita.Text.Length Then txtProfondita.Text = ValidaDimensione(txtProfondita.Text, enAsseXYZ.Profondita)
        CaricaCompatibili()

    End Sub


    Private Sub txtAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza.TextChanged

        If txtAltezza.Text.Length Then txtAltezza.Text = ValidaDimensione(txtAltezza.Text, enAsseXYZ.Altezza)
        CaricaCompatibili()
        txtProfondita.Focus()
    End Sub

    Private Sub lnkProsegui_Click(sender As Object, e As EventArgs) Handles lnkProsegui.Click
        Prosegui()
    End Sub

    Private Sub lnkProseguiTop_Click(sender As Object, e As EventArgs) Handles lnkProseguiTop.Click
        Prosegui()
    End Sub
End Class