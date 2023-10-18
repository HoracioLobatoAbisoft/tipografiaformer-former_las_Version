Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerGraphics

Public Class pEtichette
    Inherits FormerPluginPage

    Private _ValoreMinAltezza As Integer = 20
    Private _ValoreMinBase As Integer = 20

    Private _idP As Integer = 0
    Public ReadOnly Property IdP As Integer
        Get
            Return _idP
        End Get
    End Property

    Private _idC As Integer = 0
    Public ReadOnly Property IdC As Integer
        Get
            Return _idC
        End Get
    End Property

    Public P As PreventivazioneW

    Private Sub CaricaMinimali()

        Using mgr As New TipiFustellaWDAO
            _ValoreMinAltezza = mgr.GetValoreMinAltezza()
            _ValoreMinBase = mgr.GetValoreMinBase()
        End Using

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("PageTitle") = "Inserisci le misure dell' etichetta"

        _idP = Convert.ToInt32(Page.RouteData.Values("idp"))
        _idC = Convert.ToInt32(Page.RouteData.Values("idc"))

        P = New PreventivazioneW
        P.Read(_idP)

        CaricaMinimali()

        If Not IsPostBack Then

            CaricaCatFustelle()

            If IdC Then
                Using mgr As New CatFustelleWDAO
                    Dim fust As CatFustellaW = mgr.Find(New LUNA.LunaSearchParameter("IdCatFustella", IdC))
                    If Not fust Is Nothing Then
                        cmbCat.SelectedValue = IdC
                    End If
                End Using
            End If
            Dim titoloPagina As String = "Tipografia Former Online: Realizzazione "

            If P.DispOnline = False Then
                Response.Redirect("/")
            ElseIf MgrPlugin.GetIdPluginToUse(P) <> enPluginOnline.Etichette Then
                Response.Redirect("/")
            End If

            titoloPagina &= P.Descrizione
            titoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
            Title = titoloPagina

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
        End Select

        Try
            If Dimensione.Trim.Length Then
                If IsNumeric(Dimensione) Then

                    Dim Dimens As Integer = Math.Abs(Convert.ToInt32(Dimensione))
                    Dimensione = Math.Abs(Dimens)
                    If Dimensione >= ValoreMin Then
                        Ris = Dimensione
                    Else
                        Ris = ValoreMin
                    End If
                Else
                    Ris = ValoreMin
                End If
            End If

        Catch ex As Exception

        End Try

        Return Ris

    End Function

    Private Function FustelleCompatibili(P As PreventivazioneW, _
                                         Base As Integer, _
                                         Altezza As Integer, _
                                         lst As List(Of TipoFustellaW)) As List(Of TipoFustellaW)
        Dim DiffMax As Integer = 5
        Dim ris As New List(Of TipoFustellaW)

        For Each F As TipoFustellaW In lst
            Dim Compatibile As Boolean = True
            If Altezza Then
                If Math.Abs(F.Altezza - Altezza) > DiffMax Then
                    Compatibile = False
                End If
            End If
            If Base Then
                If Math.Abs(F.Base - Base) > DiffMax Then
                    Compatibile = False
                End If
            End If
            If Compatibile Then
                Dim Buffer As String = String.Empty
                Buffer = "<img src=""" & FormerWebApp.PathListinoImg & F.ImgRif & """ class=""svgRend"">"
                F.SvgRender = Buffer
                ris.Add(F)
            End If
        Next

        Dim AggiungiPersonalizzata As Boolean = False

        If Altezza Then
            If ris.FindAll(Function(x) x.Altezza = Altezza).Count = 0 Then
                AggiungiPersonalizzata = True
            End If
        End If

        If Base Then
            If ris.FindAll(Function(x) x.Base = Base).Count = 0 Then
                AggiungiPersonalizzata = True
            End If
        End If

        'prima di aggiuyngere la personalizzata se ho tuitti e tre i valori vedo se entra
        If AggiungiPersonalizzata AndAlso (Base <> 0 And Altezza <> 0) Then
            Dim ListiniBase As List(Of IListinoBaseB) = MgrPluginEtichette.GetListiniBaseCompatibili(P, Altezza, Base)

            If ListiniBase.Count = 0 Then
                AggiungiPersonalizzata = False
            End If

        End If

        If AggiungiPersonalizzata Then
            Dim F As New TipoFustellaW
            'F.Profondita = Profondita
            F.Base = Base
            F.Altezza = Altezza
            F.IdCatFustella = cmbCat.SelectedValue
            Dim Buffer As String = String.Empty
            If Base <> 0 And Altezza <> 0 Then
                Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgEtichetteSteso(P,
                                                                                        F.Altezza,
                                                                                        F.Base,
                                                                                        F.Categoria.TipoForma)
                If FormerWebApp.BrowserCompatibileSVG Then
                    Buffer = Rsteso.BufferSVG
                Else
                    Buffer = "<img src=""/img/etichettemisure.png"" class=""svgRend"">"
                End If
                F.RisultatoStesoAltezza = Rsteso.Heigth
                F.RisultatoStesoBase = Rsteso.Width

            Else
                Buffer = "<img src=""/img/etichettemisure.png"" class=""svgRend"">"
            End If

            F.SvgRender = Buffer
            ris.Add(F)
        End If

        'ora qui ho tutte le compatibili, le ordini sempre per base che e' il primo parametro
        ris.Sort(AddressOf Comparer)

        Return ris

    End Function

    Private Sub CaricaCatFustelle()

        Using mgr As New CatFustelleWDAO
            Dim l As List(Of CatFustellaW) = mgr.GetCatWithFustelle(_idP)
            cmbCat.DataSource = l
            cmbCat.DataValueField = "IdCatFustella"
            cmbCat.DataTextField = "Categoria"
            cmbCat.DataBind()
        End Using

    End Sub

    Private Function Comparer(ByVal x As TipoFustellaW, ByVal y As TipoFustellaW) As Integer

        Dim result As Integer = x.Base.CompareTo(y.Base)
        If result = 0 Then result = x.Altezza.CompareTo(y.Altezza)
        Return result

    End Function

    Private Sub CaricaCompatibili()

        pnlTutteMis.Visible = False

        Dim P As New PreventivazioneW
        P.Read(IdP)

        Dim lstFustelle As List(Of TipoFustellaW) = Nothing
        Dim lstFustelleScremata As New List(Of TipoFustellaW)

        'qui devo prendere in considerazione solo le fustelle a tre misure
        Dim IdCatFustella As Integer = cmbCat.SelectedValue
        Using mgr As New TipiFustellaWDAO

            Dim LCat As LUNA.LunaSearchParameter = Nothing

            If IdCatFustella Then

                'qui devo caricare tutte le fustelle di quella categoria
                Dim l As List(Of TipoFustellaSuCatW) = Nothing
                Dim IdFustelle As String = String.Empty
                Using mgrTF As New TipoFustellaSuCatWDAO
                    l = mgrTF.FindAll(New LUNA.LunaSearchParameter("IdCat", IdCatFustella))
                End Using

                For Each sing As TipoFustellaSuCatW In l
                    IdFustelle &= sing.IdTipo & ","
                Next

                IdFustelle = IdFustelle.TrimEnd(",")

                If IdFustelle.Length = 0 Then IdFustelle = 0

                LCat = New LUNA.LunaSearchParameter("IdTipoFustella", "(" & IdFustelle & ")", "IN")
            End If

            lstFustelle = mgr.FindAll("Base", New LUNA.LunaSearchParameter("IdPrev", IdP),
                                              New LUNA.LunaSearchParameter("Disponibile", enSiNo.Si),
                                              New LUNA.LunaSearchParameter("Profondita", 0),
                                              LCat)

            For Each fust As TipoFustellaW In lstFustelle
                Dim ris As List(Of IListinoBaseB) = MgrPluginEtichette.GetListiniBaseCompatibili(P, fust.Altezza, fust.Base)

                If ris.Count Then
                    lstFustelleScremata.Add(fust)
                End If

            Next
        End Using

        Dim Base As Integer = 0
        Dim Altezza As Integer = 0

        If IsNumeric(txtBase.Text) Then
            Base = txtBase.Text
        End If

        If IsNumeric(txtAltezza.Text) Then
            Altezza = txtAltezza.Text
        End If

        lstFustelleScremata = FustelleCompatibili(P, Base, Altezza, lstFustelleScremata)

        lstFustelleScremata.Sort(AddressOf Comparer)

        rdoFustelle.Items.Clear()

        Dim CatScelta As New CatFustellaW
        CatScelta.Read(IdCatFustella)
        If lstFustelleScremata.Count > 12 Then
            lnkProsegui.Visible = True
        Else
            lnkProsegui.Visible = False
        End If

        If lstFustelleScremata.Count Then

            Dim TrovataOttimale As Boolean = False
            For Each F As TipoFustellaW In lstFustelleScremata

                Dim listSing As New ListItem
                Dim Testo As String = String.Empty
                Testo = "<div "
                If F.IdTipoFustella = 0 Then
                    Testo &= "class = ""Fust newFust"""
                Else
                    Testo &= "class = ""hasTooltip """
                End If
                Testo &= ">"
                Testo &= IIf(F.Base, F.Base, "? ") & "mm x " & IIf(F.Altezza, F.Altezza, " ?") & "mm"
                'Testo &= F.Base & "mm x " & F.Altezza & "mm"
                Testo &= F.SvgRender
                If F.IdTipoFustella = 0 Then
                    Testo &= " <br><b class=""notaFust"">* Sovrapprezzo Creazione Fustella</b>"
                End If
                Testo &= "</div>"
                Testo &= "<div class=""hidden tooltiptext""><img src=""/img/icoInformation.png"" class=""imgSx"" /><h4>" & CatScelta.Categoria & "</h4><i>Misure: " & F.Base & "x" & F.Altezza & " mm</i><br>" & P.DescrizioneEstesa
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
            pnlFuoriMis.Visible = True
        End If

    End Sub

    Private Sub Prosegui()

        Dim Base As Integer = 0
        Dim Altezza As Integer = 0
        Dim ImgFustellaScelta As String = String.Empty

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
            ImgFustellaScelta = f.ImgRif
        Else
            Base = ValidaDimensione(txtBase.Text, enAsseXYZ.Base)
            Altezza = ValidaDimensione(txtAltezza.Text, enAsseXYZ.Altezza)
            Using cat As New CatFustellaW
                cat.Read(cmbCat.SelectedValue)
                ImgFustellaScelta = cat.ImgRif
            End Using
        End If

        If Base <> 0 And Altezza <> 0 Then

            Dim P As New PreventivazioneW
            P.Read(IdP)

            Dim ris As List(Of IListinoBaseB) = MgrPluginEtichette.GetListiniBaseCompatibili(P, Altezza, Base)

            If ris.Count Then
                'qui salvo il risultato in sessione e rientro nel wizard
                Dim IdFormatoProdotto As Integer = ris(0).IdFormProd
                If IdFormatoProdotto Then
                    Dim R As New RisultatoPluginEtichette

                    R.Altezza = ValidaDimensione(Altezza, enAsseXYZ.Altezza)
                    R.Base = ValidaDimensione(Base, enAsseXYZ.Base)
                    R.IdFormatoProdottoScelto = IdFormatoProdotto
                    R.IdTipoFustella = IdTipoFustella
                    R.ImgFustellaScelta = ImgFustellaScelta
                    R.NomeInUrl = "Misure-" & R.Base & "x" & R.Altezza
                    R.Categoria = cmbCat.SelectedItem.Text
                    Dim Cat As New CatFustellaW
                    Cat.Read(cmbCat.SelectedValue)
                    Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgEtichetteSteso(P, R.Altezza, R.Base, Cat.TipoForma, 128)

                    R.BufferSVG = Rsteso.BufferSVG
                    Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette)) = R

                    'redirect alla pagina del wizard dove rientro
                    Dim newUrl As String = FormerUrlCreator.GetUrl(P.IdPrev, IdFormatoProdotto) '"/" & P.IdPrev & "/" & IdFormatoProdotto & "/" & P.NomeInUrl & "_Misure_" & R.Base & "x" & R.Altezza

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

    Private Sub txtAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza.TextChanged

        If txtAltezza.Text.Length Then txtAltezza.Text = ValidaDimensione(txtAltezza.Text, enAsseXYZ.Altezza)
        CaricaCompatibili()

    End Sub

    Private Sub cmbCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCat.SelectedIndexChanged
        CaricaCompatibili()
    End Sub

    Private Sub lnkProsegui_Click(sender As Object, e As EventArgs) Handles lnkProsegui.Click
        Prosegui()
    End Sub

    Private Sub lnkProseguiTop_Click(sender As Object, e As EventArgs) Handles lnkProseguiTop.Click
        Prosegui()
    End Sub
End Class