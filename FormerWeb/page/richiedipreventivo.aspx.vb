Imports FormerBusinessLogic
Imports FormerBusinessLogicInterface
Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class pRichiediPreventivo
    Inherits FormerSecurePage
    Private _IdListinoBase As Integer = 0
    Private _BufferTipoCarta As String = String.Empty
    Protected ReadOnly Property BufferTipoCarta As String
        Get
            CaricaTipiCarta()
            Return _BufferTipoCarta
        End Get
    End Property

    Private Sub CaricamentoPagina()

        _IdListinoBase = Convert.ToInt32(Page.RouteData.Values("idl"))

        If _IdListinoBase = 0 Then
            Response.Redirect("/")
        End If

        If Not IsPostBack Then

            CaricaReparti()
            CaricaOrientamento()

            If LRif.IdListinoBase Then

                txtLarghezza.Text = LRif.FormatoProdotto.Fc.Larghezza * 10
                txtLunghezza.Text = LRif.FormatoProdotto.Fc.Altezza * 10

                ddlOrientamento.SelectedValue = LRif.FormatoProdotto.Orientamento

                ddlReparto.SelectedValue = LRif.Preventivazione.IdReparto
                ddlReparto.Enabled = False

                'CaricaFiniture()
                CaricaColoriStampa()

                'ddlTipologia.SelectedValue = LRif.TipoCarta.Finitura

                'txtTipoCarta.Text = LRif.TipoCarta.Tipologia

                CaricaTipiCarta()

                'ddlTipoCarta.SelectedValue = LRif.IdTipoCarta
                ddlColoreStampa.SelectedValue = LRif.IdColoreStampa

                Dim QtaDaSelezionare As Integer = 0

                Select Case LRif.TipoPrezzo
                    Case enTipoPrezzo.SuQuantita, enTipoPrezzo.SuFoglio  'default 

                        'ddlQta.Items.Add("Selezionare una quantità")

                        Dim VoceDaSelezionare As Integer = 3
                        If LRif.QtaDefault <> 0 Then
                            VoceDaSelezionare = LRif.QtaDefault
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

                    Case enTipoPrezzo.SuCmQuadri
                        Using mgr As New MgrQtaListinoBase
                            Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                            QtaDaSelezionare = lQta(1)
                        End Using

                    Case enTipoPrezzo.SuMetriQuadri
                        Using mgr As New MgrQtaListinoBase
                            Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)
                            QtaDaSelezionare = lQta(0)

                        End Using

                End Select
                txtQtaUser.Text = QtaDaSelezionare

                If LRif.ShowLabelFogli Then
                    chkMultipagina.Checked = True
                    txtNumFacciate.Text = LRif.faccmin
                    'autocopertinato? 
                End If

            End If

        End If

        CaricaLavorazioni()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CaricamentoPagina()

    End Sub

    Private _LPart As ListinoBaseW = Nothing
    Public ReadOnly Property LPart As ListinoBaseW
        Get

            If _LPart Is Nothing Then
                If _IdListinoBase Then

                    Using mgr As New ListinoBaseWDAO
                        _LPart = mgr.Find(New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdListinoBase, _IdListinoBase))
                        _LPart.CaricaLavorazioniBase()
                        _LPart.CaricaLavorazioniOpz()
                    End Using

                End If
            End If

            If _LPart Is Nothing Then
                _LPart = New ListinoBaseW
            End If

            Return _LPart
        End Get
    End Property

    'Private _L As ListinoBaseW = Nothing
    Private _LRif As ListinoBaseW = Nothing
    Public ReadOnly Property LRif As ListinoBaseW
        Get

            If _LRif Is Nothing Then
                If _IdListinoBase Then

                    Using mgr As New ListinoBaseWDAO
                        _LRif = mgr.Find(New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdListinoBase, _IdListinoBase))
                        _LRif.CaricaLavorazioniBase()
                        _LRif.CaricaLavorazioniOpz()
                    End Using

                End If
            End If

            If _LRif Is Nothing Then
                _LRif = New ListinoBaseW
            End If

            Return _LRif
        End Get
    End Property

    Private Sub CaricaTipiCarta()
        Using mgr As New TipiCartaWDAO
            Dim l As List(Of TipoCartaW) = Nothing
            Dim TrovatiInGV As Boolean = False

            If LRif.Preventivazione.GruppoVariante Then
                Using gv As New GruppoVarianteW
                    gv.Read(LRif.Preventivazione.GruppoVariante)

                    l = gv.GetTipiCartabyGruppoVariante
                End Using
                If l.Count Then
                    TrovatiInGV = True
                    If l.FindAll(Function(x) x.IdTipoCarta = LRif.IdTipoCarta).Count = 0 Then l.Add(LRif.TipoCarta)
                    l.Sort(Function(x, y) x.Tipologia.CompareTo(y.Tipologia))
                End If

            End If

            If TrovatiInGV = False Then
                l = mgr.FindAll(LFM.TipoCartaW.Tipologia) ', New LUNA.LunaSearchParameter(LFM.TipoCartaW.Finitura, ddlTipologia.SelectedValue))
            End If

            ddlTipoCarta.DataValueField = "IdTipoCarta"
            ddlTipoCarta.DataTextField = "Tipologia"
            ddlTipoCarta.DataSource = l
            ddlTipoCarta.DataBind()

            ddlTipoCarta.SelectedValue = LRif.IdTipoCarta

            Dim bufferAC As String = String.Empty
            'lLb.Sort(Function(x, y) x.Nome.CompareTo(y.Nome))

            For Each tc As TipoCartaW In l
                Dim NomeVoce As String = String.Empty
                Dim UrlVoce As String = String.Empty
                Dim imgPrev As String = String.Empty

                NomeVoce = tc.Tipologia
                bufferAC &= "{ value: """ & NomeVoce & """, url: """ & NomeVoce & """},"
            Next
            bufferAC = bufferAC.TrimEnd(",")

            _BufferTipoCarta = bufferAC

            'ddlTipoCarta.DataValueField = "IdTipoCarta"
            'ddlTipoCarta.DataTextField = "Tipologia"
            'ddlTipoCarta.DataSource = l
            'ddlTipoCarta.DataBind()
        End Using
    End Sub

    'Private Sub CaricaFiniture()
    '    Using mgr As New TipiCartaWDAO
    '        Dim l As List(Of String) = mgr.GetFiniture(False, ddlReparto.SelectedValue)
    '        ddlTipologia.DataSource = l
    '        ddlTipologia.DataBind()

    '    End Using
    'End Sub

    Private Sub CaricaReparti()

        ddlReparto.Items.Clear()
        Dim ListReparto As New ListItem
        ListReparto.Text = FormerLib.FormerEnum.FormerEnumHelper.RepartoStr(enRepartoWeb.StampaOffset)
        ListReparto.Value = enRepartoWeb.StampaOffset
        ddlReparto.Items.Add(ListReparto)

        ListReparto = New ListItem
        ListReparto.Text = FormerLib.FormerEnum.FormerEnumHelper.RepartoStr(enRepartoWeb.StampaDigitale)
        ListReparto.Value = enRepartoWeb.StampaDigitale
        ddlReparto.Items.Add(ListReparto)

        ListReparto = New ListItem
        ListReparto.Text = FormerLib.FormerEnum.FormerEnumHelper.RepartoStr(enRepartoWeb.Packaging)
        ListReparto.Value = enRepartoWeb.Packaging
        ddlReparto.Items.Add(ListReparto)

        ListReparto = New ListItem
        ListReparto.Text = FormerLib.FormerEnum.FormerEnumHelper.RepartoStr(enRepartoWeb.Ricamo)
        ListReparto.Value = enRepartoWeb.Ricamo
        ddlReparto.Items.Add(ListReparto)

        ListReparto = New ListItem
        ListReparto.Text = FormerLib.FormerEnum.FormerEnumHelper.RepartoStr(enRepartoWeb.Etichette)
        ListReparto.Value = enRepartoWeb.Etichette
        ddlReparto.Items.Add(ListReparto)

    End Sub

    Private Sub CaricaOrientamento()

        ddlOrientamento.Items.Clear()

        Dim ListNeutro As New ListItem
        ListNeutro.Text = "-"
        ListNeutro.Value = enTipoOrientamento.NonSpecificato
        ddlOrientamento.Items.Add(ListNeutro)

        Dim ListOrizzontale As New ListItem
        ListOrizzontale.Text = "Orizzontale"
        ListOrizzontale.Value = enTipoOrientamento.Orizzontale
        ddlOrientamento.Items.Add(ListOrizzontale)

        Dim ListVerticale As New ListItem
        ListVerticale.Text = "Verticale"
        ListVerticale.Value = enTipoOrientamento.Verticale
        ddlOrientamento.Items.Add(ListVerticale)

    End Sub

    Private Sub CaricaColoriStampa()

        Dim IdReparto As Integer = ddlReparto.SelectedValue

        Using mgr As New ColoriStampaWDAO
            Dim l As List(Of ColoreStampaW) = mgr.GetbyIdReparto(IdReparto)
            ddlColoreStampa.DataValueField = "IdColoreStampa"
            ddlColoreStampa.DataTextField = "Descrizione"
            ddlColoreStampa.DataSource = l
            ddlColoreStampa.DataBind()
        End Using

    End Sub

    'Private Sub CaricaLavorazioni()
    '    Using mgr As New CatLavWDAO

    '        Dim RepartiDisp As String = enRepartoWeb.Tutto

    '        If LRif.IdListinoBase Then
    '            RepartiDisp &= "," & LRif.Preventivazione.IdReparto
    '        End If

    '        Dim l As List(Of CatLavW) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "RepartoAppartenenza,Descrizione"},
    '                                                New LUNA.LunaSearchParameter(LFM.CatLavW.RepartoAppartenenza, "(" & RepartiDisp & ")", "IN"),
    '                                                New LUNA.LunaSearchParameter(LFM.CatLavW.VisibilePreventivo, enSiNo.Si))

    '        'rptOpzioni.DataSource = l
    '        'rptOpzioni.DataBind()

    '    End Using
    'End Sub

    Private Function Comparer(ByVal x As CatLavW, ByVal y As CatLavW) As Integer

        Dim result As Integer = x.NumeroLavorazioni(LRif.IdListinoBase).CompareTo(y.NumeroLavorazioni(LRif.IdListinoBase))
        If result = 0 Then result = x.Descrizione.CompareTo(y.Descrizione)
        Return result

    End Function

    Protected ListaCombo As New List(Of DropDownList)
    Protected ListaRDO As New List(Of RadioButtonList)
    Protected ListaCheckbox As New List(Of CheckBoxList)

    Public ReadOnly Property GetUrlListino As String
        Get
            Dim ris As String = "/"

            If LRif.IdListinoBase Then
                ris = FormerUrlCreator.GetUrlLb(LRif)
            End If

            Return ris
        End Get
    End Property

    Private Sub CreaInfoImg(ddl As DropDownList)
        Dim InfoCreata As Boolean = False
        Dim NewTag As String = ddl.ID.Replace("lav", "lavInfo")

        For Each row As TableRow In tableLav.Rows

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

    Private Sub CaricaLavorazioni()

        tableLav.CssClass = "tableFull"
        'tableLav.BorderWidth = 1
        'tableLav.Width = 100%
        tableLav.Rows.Clear()

        Dim lcFin As New List(Of CatLavW)
        Dim lc As List(Of CatLavW) = Nothing

        Dim TrovatiInGV As Boolean = False

        If LRif.Preventivazione.GruppoVariante Then
            Using gv As New GruppoVarianteW
                gv.Read(LRif.Preventivazione.GruppoVariante)

                lc = gv.GeCatLavbyGruppoVariante
            End Using
            If lc.Count Then
                TrovatiInGV = True
                lc.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))
            End If

        End If

        If TrovatiInGV = False Then
            Using mgr As New CatLavWDAO

                Dim RepartiDisp As String = enRepartoWeb.Tutto

                If LRif.IdListinoBase Then
                    RepartiDisp &= "," & LRif.Preventivazione.IdReparto
                End If

                lc = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Descrizione"},
                                New LUNA.LunaSearchParameter(LFM.CatLavW.RepartoAppartenenza, "(" & RepartiDisp & ")", "IN"),
                                New LUNA.LunaSearchParameter(LFM.CatLavW.VisibilePreventivo, enSiNo.Si))

                Dim lTemp As List(Of CatLavW) = lc.FindAll(Function(x) LRif.LavorazioniBase.FindAll(Function(y) y.IdCatLav = x.IdCatLav).Count)

                lTemp = lTemp.FindAll(Function(x) x.GetLavorazioni.FindAll(Function(y) y.LavorazioneInterna = enSiNo.Si).Count = 0)

                lTemp.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))

                lcFin.AddRange(lTemp)

                lTemp = lc.FindAll(Function(x) LRif.LavorazioniBase.FindAll(Function(y) y.IdCatLav = x.IdCatLav).Count = 0)

                lTemp = lTemp.FindAll(Function(x) x.GetLavorazioni.FindAll(Function(y) y.LavorazioneInterna = enSiNo.Si).Count = 0)

                lTemp.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))

                lcFin.AddRange(lTemp)

            End Using

        Else
            lcFin.AddRange(lc)
        End If




        Dim posiz As Integer = 1

        For Each Cat As CatLavW In lcFin

            Dim tr As New TableRow
            tr.BorderWidth = 1

            Dim tc As New TableCell
            'tc.CssClass = "PrevCatLav"
            Dim lLav As List(Of LavorazioneW) = Cat.GetLavorazioni(True)

            Dim lab As New Label
            'lab.CssClass = "labelCombo"

            Dim Descrizione As String = Cat.Descrizione

            If LRif.LavorazioniBase.FindAll(Function(x) x.IdCatLav = Cat.IdCatLav).Count Then
                Descrizione = "<b>" & Descrizione & " (OBBLIGATORIA)</b>"
            End If

            lab.Text = "<div class='PrevCatLav'><h3>" & Descrizione & "</h3><div>"
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
                    chkB.AutoPostBack = False
                    chkB.CssClass = "bloccoLav"
                    'AddHandler chkB.SelectedIndexChanged, AddressOf SelezioneVoceCombo
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

                    Using lav As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdCatLav = Cat.IdCatLav)
                        If Not lav Is Nothing Then
                            'qui tra le lavorazioni base ho una di questa categoria 
                            'la isolo e la seleziono
                            chkB.SelectedValue = lav.IdLavoro
                        Else
                            chkB.SelectedValue = 0
                        End If
                    End Using

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

                    rdo.AutoPostBack = False
                    rdo.RepeatDirection = RepeatDirection.Horizontal
                    rdo.CssClass = "bloccoLav"
                    'AddHandler rdo.SelectedIndexChanged, AddressOf SelezioneVoceCombo
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

                    Using lav As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdCatLav = Cat.IdCatLav)
                        If Not lav Is Nothing Then
                            'qui tra le lavorazioni base ho una di questa categoria 
                            'la isolo e la seleziono
                            rdo.SelectedValue = lav.IdLavoro
                        Else
                            rdo.SelectedValue = 0
                        End If
                    End Using


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
                    ddl.AutoPostBack = False
                    ddl.Width = 270
                    'AddHandler ddl.SelectedIndexChanged, AddressOf SelezioneVoceCombo

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
                    Using lav As LavorazioneW = LRif.LavorazioniBase.Find(Function(x) x.IdCatLav = Cat.IdCatLav)
                        If Not lav Is Nothing Then
                            'qui tra le lavorazioni base ho una di questa categoria 
                            'la isolo e la seleziono
                            ddl.SelectedValue = lav.IdLavoro
                        Else
                            ddl.SelectedValue = 0
                        End If
                    End Using

                    ListaCombo.Add(ddl)
                    tc.Controls.Add(ddl)

            End Select

            Dim labClose As New Label
            labClose.Text = "</div></div>"
            tc.Controls.Add(labClose)
            '            tc.CssClass = "cellLav"
            tr.Cells.Add(tc)
            tableLav.Rows.Add(tr)
        Next

    End Sub

    Private Sub ddlReparto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReparto.SelectedIndexChanged
        CaricaLavorazioni()
        CaricaColoriStampa()
    End Sub

    'Private Sub ddlTipologia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipologia.SelectedIndexChanged
    '    'CaricaTipiCarta()
    'End Sub

    Private Sub lnkRichiedi_Click(sender As Object, e As EventArgs) Handles lnkRichiedi.Click

        SalvaPreventivo()

    End Sub

    Private Sub SalvaPreventivo()

        Dim UrlOk As String = "/richiesta-di-preventivo-presa-in-carico"

        'Try
        'qui vado a prendere i dati della pagina li trasformo in una mail e la invio insieme a un xml che allego 

        'la prima cosa che devo fare è vedere se esiste un listinobase che ha le stesse caratteristiche delle opzioni scelte in caso sianodiverse da quello di riferimento

        Dim QtaUser As String = Server.HtmlEncode(txtQtaUser.Text)
        Dim LarghezzaUser As String = Server.HtmlEncode(txtLarghezza.Text)
        Dim LunghezzaUser As String = Server.HtmlEncode(txtLunghezza.Text)
        'Dim TipoCartaUser As String = Server.HtmlEncode(txtTipoCarta.Text)
        Dim NoteUser As String = Server.HtmlEncode(txtNote.Text)

        Dim lIdLavOpz As New List(Of Integer)

        Dim lc As List(Of CatLavW) = Nothing
        'qui vado a riempire la lista delle catlav

        Dim TrovataVariante As Boolean = False


        If LRif.Preventivazione.GruppoVariante Then
            Using gv As New GruppoVarianteW
                gv.Read(LRif.Preventivazione.GruppoVariante)

                lc = gv.GeCatLavbyGruppoVariante
            End Using
            If lc.Count Then
                TrovataVariante = True
                lc.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))
            End If


        End If

        If TrovataVariante = False Then
            Using mgr As New CatLavWDAO

                Dim RepartiDisp As String = enRepartoWeb.Tutto

                If LRif.IdListinoBase Then
                    RepartiDisp &= "," & LRif.Preventivazione.IdReparto
                End If

                lc = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Descrizione"},
                                New LUNA.LunaSearchParameter(LFM.CatLavW.RepartoAppartenenza, "(" & RepartiDisp & ")", "IN"),
                                New LUNA.LunaSearchParameter(LFM.CatLavW.VisibilePreventivo, enSiNo.Si))

            End Using
        End If




        'Using mgr As New CatLavWDAO

        '    Dim RepartiDisp As String = enRepartoWeb.Tutto

        '    'If ListinoRiferimento.IdListinoBase Then
        '    '    RepartiDisp &= "," & ListinoRiferimento.Preventivazione.IdReparto
        '    'End If

        '    lc = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Descrizione"},
        '                    New LUNA.LunaSearchParameter(LFM.CatLavW.VisibilePreventivo, enSiNo.Si))

        '    For Each cat As CatLavW In lc
        '        If LRif.LavorazioniOpz Then
        '    Next

        'End Using

        '*****************************************************************
        '*****************************************************************
        '*****************************************************************
        For Each catsi As CatLavW In lc
            If catsi.TipoControllo = enTipoControllo.RadioButton Then
                Dim cmb As RadioButtonList = ListaRDO.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
                If Not cmb Is Nothing Then
                    If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
                        Dim lav As New LavorazioneW
                        lav.Read(Convert.ToInt32(cmb.SelectedValue))
                        If lIdLavOpz.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavOpz.Add(lav.IdLavoro)
                    End If
                End If
            ElseIf catsi.TipoControllo = enTipoControllo.ComboBox Then
                Dim cmb As DropDownList = ListaCombo.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
                If Not cmb Is Nothing Then
                    If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
                        Dim lav As New LavorazioneW
                        lav.Read(Convert.ToInt32(cmb.SelectedValue))
                        If lIdLavOpz.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavOpz.Add(lav.IdLavoro)
                    End If
                End If
            ElseIf catsi.TipoControllo = enTipoControllo.CheckBox Then
                Dim cmb As CheckBoxList = ListaCheckbox.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
                If Not cmb Is Nothing Then
                    'se nessuno e' selezionato controllo se era in quelel base e selezion cmq la prima voce
                    For Each valore As ListItem In cmb.Items
                        If valore.Selected Then
                            Dim lav As New LavorazioneW
                            lav.Read(Convert.ToInt32(valore.Value))
                            If lIdLavOpz.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavOpz.Add(lav.IdLavoro)
                        End If
                    Next
                End If
            End If
        Next

        Dim PathXML As String = FormerWebApp.PathPreventivi

        Dim R As RichiestaPreventivoLogica = MgrPreventivi.SalvaPreventivo(_IdListinoBase,
                                                                    UtenteConnesso.IdUtente,
                                                                    UtenteConnesso.Nominativo,
                                                                    UtenteConnesso.Utente.Email,
                                                                    txtNome.Text,
                                                                    ddlReparto.SelectedValue,
                                                                    QtaUser,
                                                                    LarghezzaUser,
                                                                    LunghezzaUser,
                                                                    ddlOrientamento.SelectedValue,
                                                                    String.Empty,
                                                                    ddlTipoCarta.SelectedValue,
                                                                    ddlColoreStampa.SelectedValue,
                                                                    LRif,
                                                                    LPart,
                                                                    chkMultipagina.Checked,
                                                                    chkAutocopertinato.Checked,
                                                                    txtNumFacciate.Text,
                                                                    lIdLavOpz,
                                                                    NoteUser,
                                                                    PathXML,
                                                                    False)

        '*****************************************************************
        '*****************************************************************
        '*****************************************************************

        'Dim ListinoRiferimento As ListinoBaseW = Nothing

        'Dim R As New RichiestaPreventivo
        ''il guid è valorizzato automaticamente

        'R.Quando = Now
        'R.IdListinoBasePartenza = _IdListinoBase
        'R.IdCliente = UtenteConnesso.IdUtente
        'R.RagioneSocialeNome = UtenteConnesso.Nominativo
        'R.Email = UtenteConnesso.Utente.Email
        'R.NomeLavoro = txtNome.Text
        'R.Reparto = ddlReparto.SelectedValue
        'R.Qta = Server.HtmlEncode(txtQtaUser.Text)
        'R.Larghezza = Server.HtmlEncode(txtLarghezza.Text)
        'R.Lunghezza = Server.HtmlEncode(txtLunghezza.Text)
        'R.Orientamento = ddlOrientamento.SelectedValue
        'R.Finitura = ddlTipologia.SelectedValue
        'R.TipoCarta = Server.HtmlEncode(txtTipoCarta.Text)
        'R.ColoreStampa = ddlColoreStampa.SelectedValue

        'R.DataIndicativaConsegna = Date.Now

        'If Not R.TipoCartaRif Is Nothing Then
        '    'DA QUI SI PARLA DI LISTINOBASE
        '    If (LRif.FormatoCarta.LarghezzaMM = CInt(R.Larghezza) AndAlso LRif.FormatoCarta.AltezzaMM = CInt(R.Lunghezza)) OrElse
        '        (LRif.FormatoCarta.LarghezzaMM = CInt(R.Lunghezza) AndAlso LRif.FormatoCarta.AltezzaMM = CInt(R.Larghezza)) Then
        '        'qui il formato prodtto del listino riferimento va bene

        '        If R.TipoCartaRif.IdTipoCarta = LRif.IdTipoCarta AndAlso R.ColoreStampa = LRif.ColoreStampa.IdColoreStampa Then
        '            'qui il listinobase e' rimasto identico
        '            ListinoRiferimento = LRif
        '        End If
        '    End If

        '    If ListinoRiferimento Is Nothing Then
        '        'qui qualcosa è diverso devo capire se fare una variante di questo listino base o se esiste gia una combinazione 
        '        Using Mgr As New ListinoBaseWDAO
        '            Dim LLib As List(Of ListinoBaseW) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdTipoCarta, R.TipoCartaRif.IdTipoCarta),
        '                                                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, LPart.IdPrev))

        '            For Each Lb As ListinoBaseW In LLib
        '                If (Lb.FormatoCarta.LarghezzaMM = CInt(R.Larghezza) AndAlso Lb.FormatoCarta.AltezzaMM = CInt(R.Lunghezza)) OrElse
        '                    (Lb.FormatoCarta.LarghezzaMM = CInt(R.Lunghezza) AndAlso Lb.FormatoCarta.AltezzaMM = CInt(R.Larghezza)) Then
        '                    'qui il formato prodtto del listino riferimento va bene

        '                    If R.TipoCartaRif.IdTipoCarta = Lb.IdTipoCarta AndAlso R.ColoreStampa = Lb.ColoreStampa.IdColoreStampa Then
        '                        'qui il listinobase e' rimasto identico
        '                        ListinoRiferimento = Lb
        '                        ListinoRiferimento.CaricaLavorazioniBase()
        '                        ListinoRiferimento.CaricaLavorazioniOpz()
        '                        Exit For
        '                    End If
        '                End If
        '            Next
        '            If ListinoRiferimento Is Nothing Then
        '                'se qui non ho trovato niente vuoldire che non c'e' niente cerco il formato in cui entra 
        '                LLib.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))
        '                For Each Lb As ListinoBaseW In LLib
        '                    If (Lb.FormatoCarta.LarghezzaMM >= CInt(R.Larghezza) AndAlso Lb.FormatoCarta.AltezzaMM >= CInt(R.Lunghezza)) OrElse
        '                    (Lb.FormatoCarta.LarghezzaMM >= CInt(R.Lunghezza) AndAlso Lb.FormatoCarta.AltezzaMM >= CInt(R.Larghezza)) Then
        '                        'qui il formato prodtto del listino riferimento va bene

        '                        If R.TipoCartaRif.IdTipoCarta = Lb.IdTipoCarta AndAlso R.ColoreStampa = Lb.ColoreStampa.IdColoreStampa Then
        '                            'qui il listinobase e' rimasto identico
        '                            ListinoRiferimento = Lb
        '                            ListinoRiferimento.CaricaLavorazioniBase()
        '                            ListinoRiferimento.CaricaLavorazioniOpz()
        '                            Exit For
        '                        End If
        '                    End If
        '                Next
        '            End If
        '        End Using
        '    End If
        'End If

        'If ListinoRiferimento Is Nothing Then
        '    'se qui ancora è nothing non c'è niente di gia pronto che va bene e neanche di adattabile
        '    'quindi per ora lascio quello che trovo ma segnalo che non c'e' possibilita di adattare
        '    R.NessunFormatoAdattabile = True
        '    ListinoRiferimento = LRif
        'End If

        'Dim lIdLavBase As New List(Of Integer)
        'Dim lIdLavOpz As New List(Of Integer)

        ''If Not ((ListinoRiferimento.FormatoCarta.LarghezzaMM = CInt(R.Larghezza) AndAlso ListinoRiferimento.FormatoCarta.AltezzaMM = CInt(R.Lunghezza)) OrElse
        ''        (ListinoRiferimento.FormatoCarta.LarghezzaMM = CInt(R.Lunghezza) AndAlso ListinoRiferimento.FormatoCarta.AltezzaMM = CInt(R.Larghezza))) Then
        ''    'qui devo aggiungere il taglio a formato specifico 
        ''    lIdLavOpz.Add(FormerLib.FormerConst.Lavorazioni.TaglioAMisura)
        ''End If

        ''R.IdListinoBaseRif = ListinoRiferimento.IdListinoBase
        ''R.NumeroFacciate = ListinoRiferimento.faccmin

        ''If chkMultipagina.Checked Then
        ''    R.MultiPagina = True
        ''    If chkAutocopertinato.Checked Then
        ''        R.Autocopertinato = True
        ''    End If
        ''    R.NumeroFacciate = txtNumFacciate.Text
        ''End If

        'Dim lc As List(Of CatLavW) = Nothing

        'Using mgr As New CatLavWDAO

        '    Dim RepartiDisp As String = enRepartoWeb.Tutto

        '    If ListinoRiferimento.IdListinoBase Then
        '        RepartiDisp &= "," & ListinoRiferimento.Preventivazione.IdReparto
        '    End If

        '    lc = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Descrizione"},
        '                    New LUNA.LunaSearchParameter(LFM.CatLavW.RepartoAppartenenza, "(" & RepartiDisp & ")", "IN"),
        '                    New LUNA.LunaSearchParameter(LFM.CatLavW.VisibilePreventivo, enSiNo.Si))

        'End Using

        ''prima carico tutte le opzioni base non selezionabili 

        ''qui ora devo riempire gli id delle opzioni sel 
        ''For Each lav As LavorazioneW In ListinoRiferimento.LavorazioniBase.FindAll(Function(x) x.LavorazioneInterna = enSiNo.Si Or x.CatLav.VisibilePreventivo = enSiNo.No)
        ''    If lIdLavBase.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavBase.Add(lav.IdLavoro)
        ''Next

        'For Each catsi As CatLavW In lc
        '    If catsi.TipoControllo = enTipoControllo.RadioButton Then
        '        Dim cmb As RadioButtonList = ListaRDO.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
        '        If Not cmb Is Nothing Then
        '            If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
        '                Dim lav As New LavorazioneW
        '                lav.Read(Convert.ToInt32(cmb.SelectedValue))
        '                If lIdLavOpz.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavOpz.Add(lav.IdLavoro)
        '            End If
        '        End If
        '    ElseIf catsi.TipoControllo = enTipoControllo.ComboBox Then
        '        Dim cmb As DropDownList = ListaCombo.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
        '        If Not cmb Is Nothing Then
        '            If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
        '                Dim lav As New LavorazioneW
        '                lav.Read(Convert.ToInt32(cmb.SelectedValue))
        '                If lIdLavOpz.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavOpz.Add(lav.IdLavoro)
        '            End If
        '        End If
        '    ElseIf catsi.TipoControllo = enTipoControllo.CheckBox Then
        '        Dim cmb As CheckBoxList = ListaCheckbox.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
        '        If Not cmb Is Nothing Then
        '            'se nessuno e' selezionato controllo se era in quelel base e selezion cmq la prima voce
        '            If ListinoRiferimento.LavorazioniBase.FindAll(Function(x) x.IdCatLav = catsi.IdCatLav).Count <> 0 Then
        '                'qui almeno una voce deve essere selezionata
        '                If cmb.SelectedItem Is Nothing Then
        '                    cmb.Items(0).Selected = True
        '                End If
        '            End If

        '            For Each valore As ListItem In cmb.Items
        '                If valore.Selected Then
        '                    Dim lav As New LavorazioneW
        '                    lav.Read(Convert.ToInt32(valore.Value))
        '                    If lIdLavOpz.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavOpz.Add(lav.IdLavoro)
        '                End If
        '            Next
        '        End If
        '    End If
        'Next

        'R.ElencoIdOpzioniBase = lIdLavBase
        'R.ElencoIdOpzioniSel = lIdLavOpz
        'R.Annotazioni = txtNote.Text

        'Dim m As New My.Templates.MailRichiestaPreventivo
        'm.R = R
        'Dim Buffer As String = m.TransformText
        'Dim Titolo As String = "Richiesta di Preventivo per variante di " & ListinoRiferimento.Preventivazione.Descrizione

        'FormerLib.FormerHelper.Mail.InviaMail(Titolo, Buffer, "soft@tipografiaformer.it")

        'Catch ex As Exception

        'End Try
        'Response.Write(R.BufferCalcolo)
        'Response.Redirect(UrlOk)

        lblBufferPreventivo.Text = R.BufferCalcolo
        pnlPreventivo.Visible = True

    End Sub

End Class