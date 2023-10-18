Imports FormerDALWeb
Imports FormerLib.FormerEnum

Imports FormerBusinessLogicInterface
Imports FormerGraphics

Public Class pEtichetteCm
    Inherits FormerPluginPage

    Private _ValoreMinAltezza As Integer = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin
    Private _ValoreMinBase As Integer = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin

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

        If Not IsPostBack Then

            Dim titoloPagina As String = "Tipografia Former Online: Realizzazione "

            If P.DispOnline = False Then
                Response.Redirect("/")
            ElseIf MgrPlugin.GetIdPluginToUse(P) <> enPluginOnline.EtichetteCm Then
                Response.Redirect("/")
            End If

            titoloPagina &= P.Descrizione
            titoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
            Title = titoloPagina

            'txtAltezza.Text = ValidaDimensione("105", enAsseXYZ.Altezza)
            'txtBase.Text = ValidaDimensione("70", enAsseXYZ.Base)
            'txtProfondita.Text = ValidaDimensione("25", enAsseXYZ.Profondita)

            Dim l As New List(Of CatFustellaW)
            Dim c As New CatFustellaW

            c.Categoria = "Rettangolare"
            c.TipoForma = enTipoFormaEtichetta.Rettangolare
            l.Add(c)

            c = New CatFustellaW
            c.TipoForma = enTipoFormaEtichetta.Cerchio
            c.Categoria = "Tonda"
            l.Add(c)

            c = New CatFustellaW
            c.TipoForma = enTipoFormaEtichetta.Ellisse
            c.Categoria = "Ovale"
            l.Add(c)

            c = New CatFustellaW
            c.TipoForma = enTipoFormaEtichetta.Custom
            c.Categoria = "Sagomata"
            l.Add(c)

            cmbCat.DataTextField = "Categoria"
            cmbCat.DataValueField = "Tipoforma"
            cmbCat.DataSource = l
            cmbCat.DataBind()

            CaricaCompatibili()

        End If

    End Sub

    Private Function ValidaDimensione(Dimensione As String,
                                      Asse As enAsseXYZ) As Integer

        Dim Ris As Integer = 0
        Dim ValoreMin As Integer = 0
        Dim ValoreMax As Integer = 0
        Dim AltroValore As Integer = 0

        Dim ListiniBase As List(Of IListinoBaseB) = MgrPluginEtichetteCm.GetListiniBaseCompatibili(P)

        If ListiniBase.Count Then
            ValoreMax = ListiniBase(0).FormatoCarta.Larghezza * 10 - (FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato * 2)
        End If

        Select Case Asse
            Case enAsseXYZ.Altezza
                ValoreMin = _ValoreMinAltezza
                Try
                    AltroValore = txtBase.Text
                Catch ex As Exception

                End Try
            Case enAsseXYZ.Base
                ValoreMin = _ValoreMinBase
                Try
                    AltroValore = txtAltezza.Text
                Catch ex As Exception

                End Try
        End Select

        Try
            If Dimensione.Trim.Length Then
                If IsNumeric(Dimensione) Then

                    Dim Dimens As Integer = Math.Abs(Convert.ToInt32(Dimensione))
                    Dimensione = Math.Abs(Dimens)
                    If Dimensione >= ValoreMin Then
                        Ris = Dimensione
                        If Dimensione > ValoreMax Then
                            'qui devo controllare se uno solo dei due valori è superiore ok,
                            'se entrambi questo lo riporto indietro
                            If AltroValore > ValoreMax Then
                                Ris = ValoreMax
                            End If
                            'Ris = ValoreMax
                        End If
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

    Private Function EtichetteCompatibili(P As PreventivazioneW,
                                         Base As Integer,
                                         Altezza As Integer,
                                         TipoFormaEtichetta As enTipoFormaEtichetta) As List(Of TipoFustellaW)
        Dim ris As New List(Of TipoFustellaW)

        Dim F As New TipoFustellaW
        F.Base = Base
        F.Altezza = Altezza
        Dim Buffer As String = String.Empty
        If Base <> 0 And Altezza <> 0 Then
            Dim C As New CatFustellaW
            C.TipoForma = TipoFormaEtichetta
            Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgEtichetteSteso(P, F.Altezza, F.Base, C.TipoForma)
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

        Return ris

    End Function

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

        Dim Base As Integer = 0
        Dim Altezza As Integer = 0

        If IsNumeric(txtBase.Text) Then
            Base = txtBase.Text
        End If

        If IsNumeric(txtAltezza.Text) Then
            Altezza = txtAltezza.Text
        End If

        'If IsNumeric(txtProfondita.Text) Then
        '    Profondita = txtProfondita.Text
        'End If
        Dim TipoFormaEtichetta As enTipoFormaEtichetta = enTipoFormaEtichetta.Custom

        TipoFormaEtichetta = cmbCat.SelectedValue

        lstFustelle = EtichetteCompatibili(P, Base, Altezza, TipoFormaEtichetta)

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
                Testo &= IIf(F.Base, F.Base, "? ") & "x" & IIf(F.Altezza, F.Altezza, " ?")
                Testo &= F.SvgRender
                Testo &= "</div>"
                Testo &= "<div class=""hidden tooltiptext""><img src=""/img/icoInformation.png"" class=""imgSx"" /><h4>" & P.Descrizione & "</h4><i>Misure: " & F.Base & "x" & F.Altezza & " mm</i><br>"
                Testo &= "</div>" 'chiudo il div dell'hover

                listSing.Text = Testo

                listSing.Value = F.IdTipoFustella
                listSing.Selected = True

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


        'qui ha un modello personalizzato
        Base = ValidaDimensione(txtBase.Text, enAsseXYZ.Base)
        Altezza = ValidaDimensione(txtAltezza.Text, enAsseXYZ.Altezza)

        If Base <> 0 And Altezza <> 0 Then

            Dim P As New PreventivazioneW
            P.Read(IdP)

            Dim ListiniBase As List(Of IListinoBaseB) = MgrPluginEtichetteCm.GetListiniBaseCompatibili(P)

            If ListiniBase.Count Then
                'qui salvo il risultato in sessione e rientro nel wizard
                Dim IdFormatoProdotto As Integer = ListiniBase(0).IdFormProd
                If IdFormatoProdotto Then
                    Dim R As New RisultatoPluginEtichette

                    R.Altezza = ValidaDimensione(Altezza, enAsseXYZ.Altezza)
                    R.Base = ValidaDimensione(Base, enAsseXYZ.Base)
                    R.Categoria = cmbCat.SelectedItem.Text
                    R.IdFormatoProdottoScelto = IdFormatoProdotto
                    'R.IdTipoFustella = IdTipoFustella
                    R.NomeInUrl = "Misure-" & R.Base & "x" & R.Altezza

                    Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm)) = R

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

    Private Sub txtAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza.TextChanged

        If txtAltezza.Text.Length Then txtAltezza.Text = ValidaDimensione(txtAltezza.Text, enAsseXYZ.Altezza)
        CaricaCompatibili()

    End Sub

    Private Sub lnkProsegui_Click(sender As Object, e As EventArgs) Handles lnkProsegui.Click
        Prosegui()
    End Sub

    Private Sub lnkProseguiTop_Click(sender As Object, e As EventArgs) Handles lnkProseguiTop.Click
        Prosegui()
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCat.SelectedIndexChanged
        'qui se ho scelto tonda devo bloccare le misure di altezza e prendere solo la larghezza

        If cmbCat.SelectedValue = enTipoFormaEtichetta.Cerchio Then
            txtAltezza.Text = ValidaDimensione(txtBase.Text, enAsseXYZ.Altezza)
            txtAltezza.Enabled = False
        Else
            If txtAltezza.Enabled = False Then txtAltezza.Enabled = True
        End If

        CaricaCompatibili()
    End Sub
End Class