Imports FormerDALSql
Imports FormerLib
Imports System.IO
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum
Imports FormerConfig
Imports FormerBusinessLogic

Friend Class frmListinoBase
    'Inherits baseFormInternaRedim

    Private _Ris As Integer
    'Private _LavObbl As New List(Of Lavorazione)
    Private _L As ListinoBase
    Private _RisultatoCalcolo As New RisListinoBase((New ListinoBase))
    Private _P As Preventivazione

    'Private Sub AnteprimaPreventivazione()

    '    Dim PathAnte As String = _P.Anteprima()

    '    webAnteprima.Navigate(PathAnte)

    'End Sub

    Private Sub CalcolaPeso()

        Dim Risultato As Double = 0
        Dim PrezzoCarta As Decimal = 0

        Dim Risultato2 As Double = 0
        Dim PrezzoCarta2 As Decimal = 0
        Try
            Risultato = (CDbl(txtAltezza.Text) * CDbl(txtLarghezza.Text) * CDbl(txtGrammatura.Text) * CDbl(txtFogli.Text)) / 10000000

            PrezzoCarta = Risultato * txtPrezzoKg.Text

            Risultato2 = (CDbl(txtAltezza2.Text) * CDbl(txtLarghezza2.Text) * CDbl(txtGrammatura2.Text) * CDbl(TxtFogli2.Text)) / 10000000

            PrezzoCarta2 = Risultato2 * txtPrezzoKg2.Text

        Catch ex As Exception

        End Try

        lblKilogrammi.Text = Risultato
        lblPrezzoCarta.Text = PrezzoCarta

        lblKilogrammi2.Text = Risultato2
        lblPrezzoCarta2.Text = PrezzoCarta2

        Try
            lblDiffKg.Text = Risultato2 - Risultato
            lblDiffPrezzoCarta.Text = PrezzoCarta2 - PrezzoCarta

        Catch ex As Exception

        End Try

    End Sub

    Private Sub valori_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAltezza.TextChanged,
       txtFogli.TextChanged,
       txtGrammatura.TextChanged,
       txtLarghezza.TextChanged,
       txtPrezzoKg.KeyPress,
       txtLarghezza2.TextChanged,
       txtGrammatura2.TextChanged,
       TxtFogli2.TextChanged,
       txtAltezza2.TextChanged,
       txtPrezzoKg.TextChanged,
       txtPrezzoKg2.TextChanged

        CalcolaPeso()

    End Sub

    Private Sub CaricaFormatiMacchina()

        'carico solo i formati macchina compatibili con quel formato prodotto selezionato

        Dim lstFM As List(Of Formato) = Nothing

        Using mgr As New FormatiDAO
            lstFM = mgr.GetbyIdFormatoProdotto(cmbFormatoProd.SelectedValue)
        End Using
        cmbFormatoMacchina.ValueMember = "IdFormato"
        cmbFormatoMacchina.DisplayMember = "Riassunto"
        cmbFormatoMacchina.DataSource = lstFM

        Dim lstFM2 As List(Of Formato) = Nothing

        Using mgr As New FormatiDAO
            lstFM2 = mgr.GetbyIdFormatoProdotto(cmbFormatoProd.SelectedValue, True)
        End Using
        cmbFormatoMacchina2.ValueMember = "IdFormato"
        cmbFormatoMacchina2.DisplayMember = "Riassunto"
        cmbFormatoMacchina2.DataSource = lstFM2

    End Sub

    Private Sub CaricaFinitura()

        Using t As New TipiCartaDAO
            cmbFinit.DataSource = t.ListaFiniture(True)
        End Using

        Using t As New TipiCartaDAO
            cmbFinitCop.DataSource = t.ListaFiniture(True)
        End Using

        Using t As New TipiCartaDAO
            cmbFinitDor.DataSource = t.ListaFiniture(True)
        End Using

    End Sub

    Private Sub CaricaTipoImballo()

        Dim N As New cEnum
        N.Id = enTipoImballo.Fascette
        N.Descrizione = FormerEnumHelper.TipoImballoStr(enTipoImballo.Fascette)
        cmbTipoImballo.Items.Add(N)

        N = New cEnum
        N.Id = enTipoImballo.Termoretraibile
        N.Descrizione = FormerEnumHelper.TipoImballoStr(enTipoImballo.Termoretraibile)
        cmbTipoImballo.Items.Add(N)

        N = New cEnum
        N.Id = enTipoImballo.Scatola
        N.Descrizione = FormerEnumHelper.TipoImballoStr(enTipoImballo.Scatola)
        cmbTipoImballo.Items.Add(N)

        cmbTipoImballo.SelectedIndex = 0

    End Sub

    Private Sub CaricaTipoPrezzo()

        Dim N As New cEnum
        N.Id = enTipoPrezzo.SuQuantita
        N.Descrizione = "Su Quantità"
        cmbTipoPrezzo.Items.Add(N)

        'N = New cEnum 'TODO:MODIFICATOTIPOPREZZO
        'N.Id = enTipoPrezzo.SuCopie
        'N.Descrizione = "Su Copie"
        'cmbTipoPrezzo.Items.Add(N)

        N = New cEnum
        N.Id = enTipoPrezzo.SuMetriQuadri
        N.Descrizione = "Su Metri Quadri"
        cmbTipoPrezzo.Items.Add(N)

        N = New cEnum
        N.Id = enTipoPrezzo.SuCmQuadri
        N.Descrizione = "Su Centimetri Quadri"
        cmbTipoPrezzo.Items.Add(N)

        N = New cEnum
        N.Id = enTipoPrezzo.SuFoglio
        N.Descrizione = "Su Foglio"
        cmbTipoPrezzo.Items.Add(N)

        cmbPrendiIco.SelectedIndex = 0

    End Sub

    'Private Sub CaricaImgPrendiIcoDa()

    '    Select Case cmbPrendiIco.SelectedItem.id
    '        Case enPrendiIcoDa.TipoCarta
    '            Try
    '                Dim TC As New TipoCarta
    '                TC.Read(cmbTipoCarta.SelectedValue)
    '                pctPrendiIco.Image = Image.FromFile(TC.ImgRif)
    '            Catch ex As Exception

    '            End Try
    '        Case enPrendiIcoDa.Preventivazione
    '            Try
    '                pctPrendiIco.Image = Image.FromFile(_P.ImgRif)
    '            Catch ex As Exception

    '            End Try
    '        Case enPrendiIcoDa.FormatoProdotto
    '            Try
    '                Dim FP As New FormatoProdotto
    '                FP.Read(cmbFormatoProd.SelectedValue)
    '                pctPrendiIco.Image = Image.FromFile(FP.ImgRif)
    '            Catch ex As Exception

    '            End Try
    '        Case enPrendiIcoDa.ColoreDiStampa
    '            Try
    '                Dim CS As New ColoreStampa
    '                CS.Read(cmbColoriStampa.SelectedValue)
    '                pctPrendiIco.Image = Image.FromFile(CS.imgrif)
    '            Catch ex As Exception

    '            End Try

    '    End Select

    'End Sub

    Private Sub CaricaPrendiIcoDa()

        Dim N As New cEnum
        N.Id = enPrendiIcoDa.FormatoProdotto
        N.Descrizione = "Formato Prodotto"
        cmbPrendiIco.Items.Add(N)

        N = New cEnum
        N.Id = enPrendiIcoDa.Preventivazione
        N.Descrizione = "Preventivazione"
        cmbPrendiIco.Items.Add(N)

        N = New cEnum
        N.Id = enPrendiIcoDa.TipoCarta
        N.Descrizione = "Tipo Carta"
        cmbPrendiIco.Items.Add(N)

        N = New cEnum
        N.Id = enPrendiIcoDa.ColoreDiStampa
        N.Descrizione = "Colore di Stampa"
        cmbPrendiIco.Items.Add(N)

        cmbPrendiIco.SelectedIndex = 0

    End Sub
    Private Sub CaricaHotFolder()

        Using mgr As New HotFolderDAO
            Dim l As List(Of HotFolder) = mgr.GetAll(LFM.HotFolder.Nome, True)

            cmbHotFolder.ValueMember = LFM.HotFolder.IdHotFolder.Name
            cmbHotFolder.DisplayMember = LFM.HotFolder.Nome.Name
            cmbHotFolder.DataSource = l

        End Using
    End Sub
    Private Sub CaricaMacchinariProduzione()

        Using mgr As New MacchinariDAO

            Dim l As List(Of Macchinario) = mgr.GetMacchinariByFormatoMacchina(cmbFormatoMacchina.SelectedValue)

            cmbMacchinarioDef.DisplayMember = "Riassunto"
            cmbMacchinarioDef.ValueMember = "IdMacchinario"
            cmbMacchinarioDef.DataSource = l

            Try
                cmbMacchinarioDef.SelectedIndex = 0
            Catch ex As Exception

            End Try

        End Using

    End Sub

    Private Sub CaricaMacchinariProduzione2()

        If cmbFormatoMacchina2.SelectedValue Then
            Using mgr As New MacchinariDAO

                Dim l As List(Of Macchinario) = mgr.GetMacchinariByFormatoMacchina(cmbFormatoMacchina2.SelectedValue)

                cmbMacchinarioDef2.DisplayMember = "Riassunto"
                cmbMacchinarioDef2.ValueMember = "IdMacchinario"
                cmbMacchinarioDef2.DataSource = l

                cmbMacchinarioDef2.SelectedIndex = 0

            End Using
        Else
            cmbMacchinarioDef2.DataSource = Nothing
        End If

    End Sub

    Private Sub CaricaMacchinariTaglio()
        Using mgr As New MacchinariDAO

            Dim l As List(Of Macchinario) = mgr.FindAll(New LUNA.LunaSearchOption With {.AddEmptyItem = True, .OrderBy = "Descrizione"},
                                                        New LUNA.LunaSearchParameter(LFM.Macchinario.Tipo, enTipoMacchinario.Allestimento))
            cmbMacchinarioTaglioDef.DisplayMember = "Riassunto"
            cmbMacchinarioTaglioDef.ValueMember = "IdMacchinario"
            cmbMacchinarioTaglioDef.DataSource = l

        End Using
    End Sub

    Private Sub CaricaGruppiLBLogici()
        Using mgr As New GruppiLBLogiciDAO
            Dim l As List(Of GruppoLBLogico) = mgr.FindAll(New LUNA.LSO With {.OrderBy = LFM.GruppoLBLogico.Nome.Name, .AddEmptyItem = True})
            cmbGruppoLogico.DisplayMember = LFM.GruppoLBLogico.Nome.Name
            cmbGruppoLogico.ValueMember = LFM.GruppoLBLogico.IdGruppoLBLogico.Name
            cmbGruppoLogico.DataSource = l
        End Using
    End Sub

    Private Sub CaricaGruppiLBConsigliati()
        Using mgr As New GruppiLBConsigliatiDAO
            Dim l As List(Of GruppoLBConsigliato) = mgr.FindAll(New LUNA.LSO With {.OrderBy = LFM.GruppoLBConsigliato.Nome.Name, .AddEmptyItem = True})
            cmbGruppoDaConsigliare.DisplayMember = LFM.GruppoLBConsigliato.Nome.Name
            cmbGruppoDaConsigliare.ValueMember = LFM.GruppoLBConsigliato.IdGC.Name
            cmbGruppoDaConsigliare.DataSource = l
        End Using
    End Sub

    Private Sub CaricaGruppiLBAppartenenza()
        Using mgr As New GruppiLBConsigliatiDAO
            Dim l As List(Of GruppoLBConsigliato) = mgr.FindAll(New LUNA.LSO With {.OrderBy = LFM.GruppoLBConsigliato.Nome.Name, .AddEmptyItem = True})
            cmbGruppoConsigliato.DisplayMember = LFM.GruppoLBConsigliato.Nome.Name
            cmbGruppoConsigliato.ValueMember = LFM.GruppoLBConsigliato.IdGC.Name
            cmbGruppoConsigliato.DataSource = l
        End Using
    End Sub

    Private Sub CaricaCombo()

        CaricaMacchinariTaglio()

        CaricaPrendiIcoDa()

        CaricaTipoImballo()

        CaricaTipoPrezzo()

        CaricaHotFolder()

        CaricaGruppiLBLogici()

        CaricaGruppiLBConsigliati()

        CaricaGruppiLBAppartenenza()

        Dim lstC As List(Of CurvaAtt) = Nothing

        Using mgr As New CurvaAttDAO
            lstC = mgr.GetAll(LFM.CurvaAtt.NomeCurva)
        End Using

        cmbCurva.ValueMember = "IdCurvaAtt"
        cmbCurva.DisplayMember = "Riassunto"
        cmbCurva.DataSource = lstC

        Dim lstCP As List(Of CurvaAtt) = Nothing

        Using mgr As New CurvaAttDAO
            lstCP = mgr.GetAll(LFM.CurvaAtt.NomeCurva)
        End Using

        cmbAttPubbl.ValueMember = "IdCurvaAtt"
        cmbAttPubbl.DisplayMember = "Riassunto"
        cmbAttPubbl.DataSource = lstCP

        CaricaFinitura()

        CaricaFormatiProdotto()

        CaricaTC()

        CaricaCS()

        CaricaTCCopertina()

        CaricaTCDorso()

        CaricaListe()

        CaricaModelliCubetti()

        CaricaTipoControlloPrezzo()

        CaricaLavorazioniTaglioDuplicati()

        'CaricaListiniAlternativi()

    End Sub

    Private Sub CaricaLavorazioniTaglioDuplicati()

        Dim lstL As List(Of Lavorazione) = Nothing
        Using mgr As New LavorazioniDAO
            lstL = mgr.FindAll(New LUNA.LSO() With {.OrderBy = LFM.Lavorazione.Descrizione.Name, .AddEmptyItem = True},
                               New LUNA.LunaSearchParameter(LFM.Lavorazione.Stato, enStato.NonAttivo, "<>"),
                               New LUNA.LunaSearchParameter(LFM.Lavorazione.SePresenteCalcolaSuSoggetti, enSiNo.Si))
            cmbTaglioDuplicati.DataSource = lstL
            cmbTaglioDuplicati.DisplayMember = LFM.Lavorazione.Descrizione.Name
            cmbTaglioDuplicati.ValueMember = LFM.Lavorazione.IdLavoro.Name

        End Using

    End Sub

    Private Sub CaricaListiniAlternativi(Lb As ListinoBase)
        Try
            Using mgr As New ListinoBaseDAO
                Dim l As List(Of ListinoBase) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = LFM.ListinoBase.Nome.Name},
                                                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdPrev, Lb.IdPrev),
                                                            New LUNA.LunaSearchParameter(LFM.ListinoBase.Disattivo, enSiNo.No),
                                                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0))
                For Each singlb In l
                    singlb.CaricaLavorazioni()
                Next

                cmbAltriListiniBase.DisplayMember = "Riassunto"
                cmbAltriListiniBase.ValueMember = LFM.ListinoBase.IdListinoBase.Name
                cmbAltriListiniBase.DataSource = l
            End Using

            MgrControl.SelectIndexCombo(cmbAltriListiniBase, Lb.IdListinoBase)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaTipoControlloPrezzo()
        Dim l As New List(Of cEnum)

        Dim c As New cEnum
        c.Id = enTipoControlloPrezzo.ComboBox
        c.Descrizione = "Combobox"
        l.Add(c)

        c = New cEnum
        c.Id = enTipoControlloPrezzo.Tabella
        c.Descrizione = "Tabella"
        l.Add(c)

        'DISATTIVATO PER DISABILITARE LA TEXTBOX
        'c = New cEnum
        'c.Id = enTipoControlloPrezzo.TextBox
        'c.Descrizione = "Textbox"
        'l.Add(c)

        cmbTipoControlloPrezzo.ValueMember = "Id"
        cmbTipoControlloPrezzo.DisplayMember = "Descrizione"
        cmbTipoControlloPrezzo.DataSource = l

    End Sub

    Private Sub CaricaModelliCubetti()

        Dim lstCS As List(Of ModelloCubetto) = Nothing
        Using mgr As New ModelliCubettiDAO
            lstCS = mgr.GetAll(LFM.ModelloCubetto.IDModelloCubetto, True)
        End Using

        lstCS.Sort(Function(x, y) x.Volume.CompareTo(y.Volume))

        cmbTipoCubetto.ValueMember = "IdModelloCubetto"
        cmbTipoCubetto.DisplayMember = "Riassunto"
        cmbTipoCubetto.DataSource = lstCS

    End Sub

    Private Sub CaricaCS()

        Dim lstCS As List(Of ColoreStampa) = Nothing
        Using mgr As New ColoriStampaDAO
            lstCS = mgr.GetAll(LFM.ColoreStampa.Descrizione)
        End Using
        cmbColoriStampa.ValueMember = "IdColoreStampa"
        cmbColoriStampa.DisplayMember = "Riassunto"
        cmbColoriStampa.DataSource = lstCS

    End Sub

    Private Sub CaricaTC()

        Dim lstT
        If cmbFinit.Text.Length Then
            Using mgr As New TipiCartaDAO
                lstT = mgr.ListaTipi(cmbFinit.Text)
            End Using

        Else
            Using mgr As New TipiCartaDAO
                lstT = mgr.GetAll(LFM.TipoCarta.Tipologia, True)
            End Using

        End If

        cmbTipoCarta.ValueMember = "IdTipoCarta"
        cmbTipoCarta.DisplayMember = "Tipologia"
        cmbTipoCarta.DataSource = lstT

    End Sub

    Private Sub CaricaTCDorso()

        Dim lstTDorso
        If cmbFinitDor.Text.Length Then
            Using mgr As New TipiCartaDAO
                lstTDorso = mgr.ListaTipi(cmbFinitDor.Text)
            End Using
        Else
            Using mgr As New TipiCartaDAO
                lstTDorso = mgr.GetAll(LFM.TipoCarta.Tipologia, True)
            End Using
        End If
        cmbTipoCartaDorso.ValueMember = "IdTipoCarta"
        cmbTipoCartaDorso.DisplayMember = "Tipologia"
        cmbTipoCartaDorso.DataSource = lstTDorso

    End Sub

    Private Sub CaricaTCCopertina()

        Dim lstTCop
        If cmbFinitCop.Text.Length Then
            Using mgr As New TipiCartaDAO
                lstTCop = mgr.ListaTipi(cmbFinitCop.Text)
            End Using
        Else
            Using mgr As New TipiCartaDAO
                lstTCop = mgr.GetAll(LFM.TipoCarta.Tipologia, True)
            End Using
        End If

        cmbTipoCartaCopertina.ValueMember = "IdTipoCarta"
        cmbTipoCartaCopertina.DisplayMember = "Tipologia"
        cmbTipoCartaCopertina.DataSource = lstTCop

    End Sub

    Private Sub CaricaFormatiProdotto()

        Dim lstF As List(Of FormatoProdotto) = Nothing
        Using mgr As New FormatiProdottoDAO
            lstF = mgr.GetAll(LFM.FormatoProdotto.Formato)
        End Using
        cmbFormatoProd.ValueMember = "IdFormProd"
        cmbFormatoProd.DisplayMember = "Riassunto"
        cmbFormatoProd.DataSource = lstF

    End Sub

    Private Sub CaricaListe()

        Dim lstC As List(Of CatLav) = Nothing
        Using mgr As New CatLavDAO
            lstC = mgr.FindAll(LFM.CatLav.Descrizione) ', New LUNA.LunaSearchParameter(LFM.CatLav.RepartoAppartenenza, "(0," & _P.IdReparto & ")", "IN"))
        End Using

        Dim baseC As New CatLav With {.IdCatLav = 0, .Descrizione = " - Senza categoria"}

        lstC.Add(baseC)
        lstC.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))

        tvwListLav.Nodes.Clear()
        tvwListLavOpz.Nodes.Clear()

        Dim Node As TreeNode = tvwListLav.Nodes.Add("R" & enRepartoWeb.Tutto, "TUTTO")
        Node.BackColor = Color.White
        Node.ForeColor = Color.Black

        tvwListLavOpz.Nodes.Add(Node.Clone)

        Node = tvwListLav.Nodes.Add("R" & enRepartoWeb.StampaOffset, "OFFSET")
        Node.BackColor = FormerColori.ColoreRepartoOffset
        Node.ForeColor = Color.White
        tvwListLavOpz.Nodes.Add(Node.Clone)

        Node = tvwListLav.Nodes.Add("R" & enRepartoWeb.StampaDigitale, "DIGITALE")
        Node.BackColor = FormerColori.ColoreRepartoDigitale
        Node.ForeColor = Color.White
        tvwListLavOpz.Nodes.Add(Node.Clone)

        Node = tvwListLav.Nodes.Add("R" & enRepartoWeb.Packaging, "PACKAGING")
        Node.BackColor = FormerColori.ColoreRepartoPackaging
        Node.ForeColor = Color.White
        tvwListLavOpz.Nodes.Add(Node.Clone)

        Node = tvwListLav.Nodes.Add("R" & enRepartoWeb.Ricamo, "RICAMO")
        Node.BackColor = FormerColori.ColoreRepartoRicamo
        Node.ForeColor = Color.White
        tvwListLavOpz.Nodes.Add(Node.Clone)

        Node = tvwListLav.Nodes.Add("R" & enRepartoWeb.Etichette, "ETICHETTE")
        Node.BackColor = FormerColori.ColoreRepartoEtichette
        Node.ForeColor = Color.White
        tvwListLavOpz.Nodes.Add(Node.Clone)

        tvwListLav.Nodes("R" & _P.IdReparto).Expand()

        For Each c As CatLav In lstC
            Dim N As New TreeNode
            N.Name = "C" & c.IdCatLav
            N.Text = c.Descrizione
            Dim ChiavePadre As String = "R" & c.RepartoAppartenenza
            tvwListLav.Nodes(ChiavePadre).Nodes.Add(N)

            Dim N2 As TreeNode = N.Clone()

            tvwListLavOpz.Nodes(ChiavePadre).Nodes.Add(N2)
        Next

        Dim lstL As List(Of Lavorazione) = Nothing
        Using mgr As New LavorazioniDAO
            lstL = mgr.FindAll(LFM.Lavorazione.Descrizione,
                               New LUNA.LunaSearchParameter(LFM.Lavorazione.Stato, enStato.NonAttivo, "<>"))
        End Using

        Dim strIdL As String = ""
        For Each f As Lavorazione In lstL
            ' If strIdL.IndexOf(f.IdLavoro & ",") = -1 Then
            'strIdL &= f.IdLavoro & ","

            Dim N As New TreeNode
            N.Name = "L" & f.IdLavoro
            Dim TestoNodo As String = f.Riassunto

            'qui devo andare a mettere quale prezzo verra' preso in considerazione tra quelli della lavorazion eper il formato
            'del listino base

            Dim P As PrezzoLavoro = Nothing

            'If FormatoWForzato = 0 Then
            f.CaricaPrezzi()
            P = f.Prezzi.Find(Function(x) x.IdFormProd = _L.IdFormProd)
            'End If

            If Not P Is Nothing Then
                TestoNodo &= " -> " & _L.FormatoProdotto.Formato
            Else
                P = f.Prezzi.Find(Function(x) x.IdFormCarta = _L.FormatoProdotto.IdFormCarta)
                If Not P Is Nothing Then
                    TestoNodo &= " -> " & P.FormatoProdotto.Formato
                Else
                    Dim DimensiToFind As enTipoGrandezzaPrezzoLavorazione = enTipoGrandezzaPrezzoLavorazione.Medio

                    Dim FormatoWForzato As Integer = _L.FormatoProdotto.Larghezza
                    Dim FormatoHForzato As Integer = _L.FormatoProdotto.Lunghezza

                    If (FormatoWForzato < f.DimensMedieMinW And FormatoHForzato < f.DimensMedieMinH) OrElse
                       (FormatoHForzato < f.DimensMedieMinW And FormatoWForzato < f.DimensMedieMinH) Then
                        'qui parliamo del prezzo per il formato minimo
                        DimensiToFind = enTipoGrandezzaPrezzoLavorazione.Piccolo
                    ElseIf (FormatoWForzato > f.DimensMedieMaxW Or FormatoHForzato > f.DimensMedieMaxH) And
                       (FormatoHForzato > f.DimensMedieMaxW Or FormatoWForzato > f.DimensMedieMaxH) Then
                        'qui parlaimo del prezzo per il formato max 
                        DimensiToFind = enTipoGrandezzaPrezzoLavorazione.Grande
                    End If

                    P = f.Prezzi.Find(Function(x) x.IdFormProd = 0 And x.TipoGrandezza = DimensiToFind)

                    If Not P Is Nothing Then 'alla fine se non ho trovato un formato generico specifico cerco il generico standard
                        TestoNodo &= " -> Generico "

                        If P.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Piccolo Then
                            TestoNodo &= "Piccolo"
                        ElseIf P.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Grande Then
                            TestoNodo &= "Grande"
                        End If
                    Else
                        P = f.Prezzi.Find(Function(x) x.IdFormProd = 0 And x.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Medio) 'qui devo prendere il generico medio
                        TestoNodo &= " -> Generico Medio"
                    End If

                End If

            End If

            N.Text = TestoNodo

            Dim ChiavePadre As String = "C" & f.IdCatLav
            Dim NodoTrovato As Integer = tvwListLav.Nodes.Find(ChiavePadre, True).Count
            If NodoTrovato Then
                tvwListLav.Nodes.Find(ChiavePadre, True)(0).Nodes.Add(N)

                Dim N2 As TreeNode = N.Clone
                tvwListLavOpz.Nodes.Find(ChiavePadre, True)(0).Nodes.Add(N2)
            End If
            'End If
        Next

        'tvwListLav.ExpandAll()
        'tvwListLavOpz.ExpandAll()

    End Sub

    Private Function CheckNode(Node As TreeNode,
                               Chiave As String) As Integer
        Dim Ris As Integer = 0
        If Node.Name = Chiave Then
            Node.Checked = True
            Node.Parent.Checked = True
            Node.EnsureVisible()
            Ris = 1
        Else
            For Each N As TreeNode In Node.Nodes
                Ris = CheckNode(N, Chiave)
                If Ris Then Exit For
            Next
        End If
        Return Ris
    End Function

    Private AvvisoCambioLavorazioniDato As Boolean = False

    Private Sub CaricamentoInterno(ByRef L As ListinoBase,
                           Optional ByVal P As Preventivazione = Nothing,
                           Optional ByVal Duplica As Boolean = False,
                           Optional ByVal Importa As Boolean = False)

        AvvisoCambioLavorazioniDato = False

        If P Is Nothing Then
            _P = New Preventivazione
            If L.IdPrev Then
                _P.Read(L.IdPrev)
            End If
        Else
            _P = P
        End If

        If _P.IdPrev = 0 Then
            lblPreventivazione.Text = "*** BOZZE ***"
            lblTipo.BackColor = Color.White
            lblTipo.ForeColor = Color.Black
        Else
            lblPreventivazione.Text = _P.Descrizione

            Try
                lblTipo.BackColor = FormerColori.GetColoreReparto(_P.IdReparto)

                Dim ColoreTesto As Color = Color.Black

                If _P.IdReparto = enRepartoWeb.StampaOffset Or _P.IdReparto = enRepartoWeb.Etichette Then
                    ColoreTesto = Color.White
                End If

                lblTipo.ForeColor = ColoreTesto
            Catch ex As Exception

            End Try
        End If



        If Duplica Then
            rdoPercAdattamento.Checked = True
        End If

        'qui se mi viene passato un oggetto lo precarico altrimenti no
        ' AnteprimaPreventivazione()
        '_LavObbl = LstLavObbl
        _L = L
        '_L.CaricaLavorazioni()
        CaricaCombo()

        If _L.IdListinoBase Then

            Me.Text = "Former - Listino base - " & _L.IdListinoBase & IIf(_L.IdListinoBaseSource, " PRODUZIONE", " SORGENTE")

            If _L.Disattivo = enSiNo.Si Then
                lblDisattivato.Visible = True
            Else
                lblDisattivato.Visible = False
            End If

            'qui precarico i valori 
            lblAzione.Text = "Modifica"
            lblAzione.ForeColor = Color.Orange

            txtPrefissoNomeVarianti.Text = _L.PrefissoVarianti

            UcListinoGruppoVariante.IdListinoBase = _L.IdListinoBase
            UcListinoGruppoVariante.CaricaVarianti()

            For Each lis As Lavorazione In _L.LavorazioniBase
                Dim Chiave As String = "L" & lis.IdLavoro
                For Each N As TreeNode In tvwListLav.Nodes
                    If CheckNode(N, Chiave) Then Exit For
                Next

            Next

            For Each lis As Lavorazione In _L.LavorazioniOpz
                Dim Chiave As String = "L" & lis.IdLavoro
                For Each N As TreeNode In tvwListLavOpz.Nodes
                    If CheckNode(N, Chiave) Then Exit For
                Next
            Next

            MgrControl.SelectIndexCombo(cmbColoriStampa, _L.IdColoreStampa)
            MgrControl.SelectIndexCombo(cmbCurva, _L.IdCurvaAtt)

            MgrControl.SelectIndexCombo(cmbFormatoProd, _L.IdFormProd)
            CaricaFormatiMacchina()
            MgrControl.SelectIndexCombo(cmbFormatoMacchina, _L.IdFormato)
            MgrControl.SelectIndexCombo(cmbFormatoMacchina2, _L.IdFormatoMacchina2)
            MgrControl.SelectIndexCombo(cmbTipoCarta, _L.IdTipoCarta)

            MgrControl.SelectIndexCombo(cmbTipoCartaCopertina, _L.IdTipoCartaCop)
            MgrControl.SelectIndexCombo(cmbTipoCartaDorso, _L.IdTipoCartaDorso)

            MgrControl.SelectIndexCombo(cmbAttPubbl, _L.IdCurvaPubbl)

            MgrControl.SelectIndexComboEnum(cmbPrendiIco, _L.PrendiIcoDa)
            MgrControl.SelectIndexComboEnum(cmbTipoPrezzo, _L.TipoPrezzo)
            MgrControl.SelectIndexComboEnum(cmbTipoImballo, _L.IdTipoImballo)

            MgrControl.SelectIndexCombo(cmbTipoCubetto, _L.IdModelloCubetto)

            MgrControl.SelectIndexCombo(cmbHotFolder, _L.IdHotFolderPostRefine)

            MgrControl.SelectIndexCombo(cmbMacchinarioDef, _L.IdMacchinarioProduzione)
            MgrControl.SelectIndexCombo(cmbMacchinarioDef2, _L.IdMacchinarioProduzione2)
            MgrControl.SelectIndexCombo(cmbMacchinarioTaglioDef, _L.IdMacchinarioTaglio)
            MgrControl.SelectIndexComboEnum(cmbTipoControlloPrezzo, _L.TipoControlloPrezzo)

            MgrControl.SelectIndexCombo(cmbGruppoLogico, _L.idGruppoLogico)
            MgrControl.SelectIndexCombo(cmbGruppoConsigliato, _L.IdGruppoLCAppartenenza)
            MgrControl.SelectIndexCombo(cmbGruppoDaConsigliare, _L.IdGruppoListiniConsigliati)

            MgrControl.SelectIndexCombo(cmbTaglioDuplicati, _L.IdLavTaglioDuplicati)

            txtNome.Text = _L.Nome
            txtNomeInterno.Text = _L.NomeInterno

            txtQ1.Text = _L.qta1
            txtQ2.Text = _L.qta2
            txtQ3.Text = _L.qta3
            txtQ4.Text = _L.qta4
            txtQ5.Text = _L.qta5
            txtQ6.Text = _L.qta6

            If _L.CalcolaAncheDaSolo = enSiNo.Si Then chkCalcolaSolo.Checked = True

            Select Case _L.QtaDefault
                Case 1
                    rdoQtaDefault1.Checked = True
                Case 2
                    rdoQtaDefault2.Checked = True
                Case 3
                    rdoQtaDefault3.Checked = True
                Case 4
                    rdoQtaDefault4.Checked = True
                Case 5
                    rdoQtaDefault5.Checked = True
                Case 6
                    rdoQtaDefault6.Checked = True
            End Select

            txtV1.Text = _L.v1
            txtV2.Text = _L.v2
            txtV3.Text = _L.v3
            txtV4.Text = _L.v4
            txtV5.Text = _L.v5
            txtV6.Text = _L.v6

            lblr1.Text = _L.p1
            lblr2.Text = _L.p2
            lblr3.Text = _L.p3
            lblr4.Text = _L.p4
            lblr5.Text = _L.p5
            lblr6.Text = _L.p6

            txtMultiplo.Text = _L.MultiploQta

            txtMoltiplQTA.Text = _L.MoltiplicatoreQta
            txtMoltiplQTA2.Text = _L.MoltiplicatoreQta2
            txtMoltiplQTA3.Text = _L.MoltiplicatoreQta3
            txtMoltiplQTA4.Text = _L.MoltiplicatoreQta4
            txtMoltiplQTA5.Text = _L.MoltiplicatoreQta5
            txtMoltiplQta0.Text = _L.MoltiplicatoreQta0
            txtMoltiplicatIntermedio.Text = _L.MoltiplicatoreQtaIntermedia

            chkQtaSottoColonna1.Checked = IIf(_L.AbilitaQtaSottoColonna1 = enSiNo.Si, True, False)
            chkQtaIntermedie.Checked = IIf(_L.AbilitaQtaIntermedie = enSiNo.Si, True, False)

            chkNoFileAllegati.Checked = IIf(_L.NoAttachFile = enSiNo.Si, True, False)

            chkSoggDupl.Checked = IIf(_L.ConSoggettiDuplicati = enSiNo.Si, True, False)

            chkAllowCustomSize.Checked = IIf(_L.AllowCustomSize = enSiNo.Si, True, False)

            txtMaxFacc.Text = _L.FaccMax
            txtMinFacc.Text = _L.FaccMin

            txtDefaultNFogli.Text = _L.DefaultNFogli

            txtPercCostoCopia.Text = _L.PercAdatCostoCopia
            txtAvviamStampa.Text = _L.AvviamStampa
            txtMinimStampa.Text = _L.MinimaleStampa

            txtMinFogli.Text = _L.FaccMin / 2
            txtMaxFogli.Text = _L.FaccMax / 2
            If txtMaxFogli.Text <> txtMinFogli.Text Then
                txtMultiplo.Enabled = True
            Else
                txtMultiplo.Enabled = False
            End If
            txtqtaCollo.Text = _L.QtaCollo

            'chkMostraPrezziTabella.Checked = IIf(_L.MostraPrezziTabella = enSiNo.Si, True, False)

            chkNoFaccImp.Checked = _L.NoFaccSuImpianti
            chkNoResa.Checked = _L.noResa

            UcListinoBaseDatiWeb.Carica(_L.IdListinoBase)

            'txtPercFatturatoMax.Text = _L.PercMaxPromoFatturato
            'txtPercPromo.Text = _L.PercPromoAutomatico

            'If _L.AttivaPromoAutomatico = enSiNo.Si Then
            '    chkAttivaPromoAutomatico.Checked = True
            'Else
            '    chkAttivaPromoAutomatico.Checked = False
            'End If

            If _L.InEvidenza = enSiNo.Si Then
                chkInEvidenza.Checked = True
            Else
                chkInEvidenza.Checked = False
            End If

            If _L.NascondiOnline = enSiNo.Si Then
                chkNascondiOnline.Checked = True
            Else
                chkNascondiOnline.Checked = False
            End If

            'txtDescrSito.Text = _L.DescrSito
            'rdoPercAdattamento.Checked = True
            CalcolaValoriRif()
            'rdoPercAdattamento.Checked = False
            'rdoPrezzoMercato.Checked = True
            CaricaIconeLav()

            'txtV1.Text = Math.Round(_L.v1)
            'txtV2.Text = Math.Round(_L.v2)
            'txtV3.Text = Math.Round(_L.v3)
            'txtV4.Text = Math.Round(_L.v4)
            'txtV5.Text = Math.Round(_L.v5)
            'txtV6.Text = Math.Round(_L.v6)

            'CaricaAnteprima()
            'CaricaImgPrendiIcoDa()
            'CaricaIcone()

            If _L.LargRotolo.IndexOf("20,") <> -1 Then
                chkRot20.Checked = True
            End If

            If _L.LargRotolo.IndexOf("60,") <> -1 Then
                chkRot60.Checked = True
            End If
            If _L.LargRotolo.IndexOf("100, ") <> -1 Then
                chkRot100.Checked = True
            End If
            If _L.LargRotolo.IndexOf("130, ") <> -1 Then
                chkRot130.Checked = True
            End If
            If _L.LargRotolo.IndexOf("150, ") <> -1 Then
                chkRot150.Checked = True
            End If

            If _L.LargRotolo.IndexOf("200, ") <> -1 Then
                chkRot200.Checked = True
            End If


            Dim DimensioneMax As Single = _L.FormatoProdotto.FormatoCarta.Larghezza * 10
            lblLatoRif.Text = DimensioneMax

            txtAltezzaEtichette.My_MinValue = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin
            txtAltezzaEtichette.My_DefaultValue = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin
            txtLarghezzaEtichette.My_MinValue = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin
            txtLarghezzaEtichette.My_DefaultValue = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin
            txtLarghezzaEtichette.Text = txtLarghezzaEtichette.My_MinValue
            txtAltezzaEtichette.Text = txtAltezzaEtichette.My_MinValue
            txtLarghezzaEtichette.My_MaxValue = DimensioneMax - (FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato * 2)

        Else

            TabMain.TabPages.Remove(tpGruppoVariante)

            lblAzione.Text = "Nuovo"
            lblAzione.ForeColor = Color.Green

            _L.qta1 = 500
            _L.qta2 = 1000
            _L.qta3 = 2000
            _L.qta4 = 5000
            _L.qta5 = 10000
            _L.qta6 = 50000

            cmbTipoPrezzo.SelectedIndex = 0

            CaricaFormatiMacchina()

        End If

        'CalcolaValoriRif()
        CheckCurve()

        If Duplica Then
            _L.IdListinoBase = 0
            _L.IdPrev = _P.IdPrev
            lblAzione.Text = "Duplica"
            lblAzione.ForeColor = Color.Red
        ElseIf Importa Then
            _L.IdListinoBase = 0
            _L.IdPrev = _P.IdPrev
            lblAzione.Text = "Importa"
            lblAzione.ForeColor = Color.Red
        End If

    End Sub

    Friend Function Carica(ByVal L As ListinoBase,
                           Optional ByVal P As Preventivazione = Nothing,
                           Optional ByVal Duplica As Boolean = False,
                           Optional ByVal Importa As Boolean = False) As Integer

        CaricaListiniAlternativi(L)

        CaricamentoInterno(L, P, Duplica, Importa)

        ShowDialog()

        L = _L

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub txtQ1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQ1.KeyPress,
        txtQ2.KeyPress,
        txtQ3.KeyPress,
        txtQ4.KeyPress,
        txtQ5.KeyPress,
        txtQ6.KeyPress
        MgrControl.ControlloNumerico(sender, e, True)
    End Sub

    Private Sub txtV1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtV1.KeyPress,
    txtV2.KeyPress,
    txtV3.KeyPress,
    txtV4.KeyPress,
    txtV5.KeyPress,
    txtV6.KeyPress
        MgrControl.ControlloNumerico(sender, e)
    End Sub

    Private Sub txtQ1_TextChanged(sender As Object, e As EventArgs) Handles txtQ1.TextChanged
        If sender.focused Then
            CalcolaValoriRif()
        End If
    End Sub

    Private Sub SalvaListinoBase(Optional EChiudi As Boolean = False)

        Dim trovataAltra As Boolean = False
        Dim NecessitaPlugin As Boolean = False

        'qui devo evitare che si salvi un listinobase con tipocalcolo su centimetri quadri su preventivazione che non prevede il plugin 
        If DirectCast(cmbTipoPrezzo.SelectedItem, cEnum).Id = enTipoPrezzo.SuCmQuadri Then
            If _P.IdPluginToUse <> enPluginOnline.EtichetteCm Then
                NecessitaPlugin = True
            End If
        Else
            If _P.IdPluginToUse = enPluginOnline.EtichetteCm Then
                NecessitaPlugin = True
            End If
        End If

        Dim lista As List(Of ListinoBase) = Nothing
        Using mgr As New ListinoBaseDAO
            lista = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdPrev, _P.IdPrev),
                                                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdFormProd, cmbFormatoProd.SelectedValue),
                                                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdTipoCarta, cmbTipoCarta.SelectedValue),
                                                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdColoreStampa, cmbColoriStampa.SelectedValue),
                                                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBase, _L.IdListinoBase, "<>"),
                                                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                            New LUNA.LunaSearchParameter(LFM.ListinoBase.Disattivo, enSiNo.No))

        End Using

        Dim OkDefaultFogli As Boolean = True

        If txtMinFogli.Text <> txtMaxFogli.Text Then
            If txtDefaultNFogli.Text <> 0 Then
                'qui devo controllare che la quantità di default inserita è valida
                Dim LQta As New List(Of Integer)
                For i As Integer = txtMinFogli.Text To txtMaxFogli.Text Step txtMultiplo.Text

                    LQta.Add(i)

                Next

                If LQta.FindAll(Function(x) x = txtDefaultNFogli.Text).Count = 0 Then
                    OkDefaultFogli = False
                End If

            End If
        End If

        If OkDefaultFogli = False Then
            MessageBox.Show("ATTENZIONE! La quantità di default per il numero fogli inserita non è valida!", "Listino Base")
            TabMain.SelectedTab = tbProd
            txtDefaultNFogli.Focus()
        Else

            'If txtPercPromo.Value <> 0 And txtPercFatturatoMax.Value = 0 Then
            '    MessageBox.Show("Impostare entrambe le percentuali del promo automatico")
            'Else
            If lista.Count Then
                    MessageBox.Show("ATTENZIONE! Esiste già un listino base con FORMATO PRODOTTO, TIPO CARTA e COLORI DI STAMPA selezionati!", "Listino Base")
                Else
                    If OkCheckTabella() = False Then
                        MessageBox.Show("ATTENZIONE! I prezzi in formato tabellare possono essere inseriti solo su listini base con tipo prezzo a Quantità o a Metri Quadri", "Listino Base")
                    Else
                        If NecessitaPlugin Then
                            MessageBox.Show("ATTENZIONE! Il listino base che prevede prezzo SU CM QUADRI può essere associato solo a una preventivazione che prevede il plugin ETICHETTE CM QUADRI!", "Listino Base")
                        Else

                            Dim IdTaglioDupl As Integer = 0

                            Try
                                IdTaglioDupl = cmbTaglioDuplicati.SelectedValue
                            Catch ex As Exception

                            End Try


                            If (chkSoggDupl.Checked And IdTaglioDupl = 0) Then
                                MessageBox.Show("Se il ListinoBase prevede soggetti duplicati si deve selezionare la lavorazione specifica di taglio!", "Listino Base")
                            Else


                                Dim Msg As String = String.Empty
                                Dim OkLavObbl As Boolean = True

                                If _L.LavorazioniBase.FindAll(Function(x) x.IdLavoro = FormerConst.Lavorazioni.StampaRealizzazione).Count = 0 Then
                                    Msg = "Stampa"
                                End If

                                If _L.LavorazioniBase.FindAll(Function(x) x.IdLavoro = FormerConst.Lavorazioni.Taglio).Count = 0 Then
                                    If Msg.Length Then Msg &= ", "
                                    Msg &= "Taglio"
                                End If

                                If Msg.Length Then
                                    If MessageBox.Show("In questo Listino Base mancano le seguenti lavorazioni: " & Msg & ", vuoi salvare comunque?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                        OkLavObbl = False
                                    End If
                                End If

                                If OkLavObbl Then
                                    Dim IdGruppoConsigliato As Integer = cmbGruppoConsigliato.SelectedValue
                                    Dim IdGruppoProdottiConsigliati As Integer = cmbGruppoDaConsigliare.SelectedValue

                                    If IdGruppoConsigliato <> 0 AndAlso (IdGruppoConsigliato = IdGruppoProdottiConsigliati) Then
                                        MessageBox.Show("Non si può selezionare lo stesso gruppo per il gruppo consigliato e il gruppo da consigliare")
                                    Else
                                        If MessageBox.Show("Confermi i valori inseriti per il listino base?", "Listino Base", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                            'qui ci carico dentro i valori 
                                            _L.IdPrev = _P.IdPrev
                                            '_L.IdListinoBase = -1
                                            _L.Nome = txtNome.Text
                                            _L.NomeInterno = txtNomeInterno.Text

                                            _L.IdCurvaPubbl = cmbAttPubbl.SelectedValue
                                            _L.IdColoreStampa = cmbColoriStampa.SelectedValue
                                            _L.IdCurvaAtt = cmbCurva.SelectedValue
                                            _L.IdFormato = cmbFormatoMacchina.SelectedValue
                                            _L.IdFormatoMacchina2 = cmbFormatoMacchina2.SelectedValue
                                            _L.IdFormProd = cmbFormatoProd.SelectedValue
                                            _L.IdTipoCarta = cmbTipoCarta.SelectedValue
                                            _L.IdTipoCartaCop = cmbTipoCartaCopertina.SelectedValue
                                            _L.IdTipoCartaDorso = cmbTipoCartaDorso.SelectedValue
                                            _L.idGruppoLogico = cmbGruppoLogico.SelectedValue
                                            _L.IdGruppoListiniConsigliati = cmbGruppoDaConsigliare.SelectedValue
                                            _L.IdGruppoLCAppartenenza = cmbGruppoConsigliato.SelectedValue
                                        '_L.AttivaPromoAutomatico = IIf(chkAttivaPromoAutomatico.Checked, enSiNo.Si, enSiNo.No)
                                        _L.qta1 = txtQ1.Text
                                            _L.qta2 = txtQ2.Text
                                            _L.qta3 = txtQ3.Text
                                            _L.qta4 = txtQ4.Text
                                            _L.qta5 = txtQ5.Text
                                            _L.qta6 = txtQ6.Text
                                            _L.v1 = txtV1.Text
                                            _L.v2 = txtV2.Text
                                            _L.v3 = txtV3.Text
                                            _L.v4 = txtV4.Text
                                            _L.v5 = txtV5.Text
                                            _L.v6 = txtV6.Text

                                            _L.PrefissoVarianti = txtPrefissoNomeVarianti.Text

                                            _L.CalcolaAncheDaSolo = IIf(chkCalcolaSolo.Checked, enSiNo.Si, enSiNo.No)

                                            _L.MultiploQta = txtMultiplo.Text
                                            _L.MoltiplicatoreQta = txtMoltiplQTA.Text
                                            _L.MoltiplicatoreQta2 = txtMoltiplQTA2.Text
                                            _L.MoltiplicatoreQta3 = txtMoltiplQTA3.Text
                                            _L.MoltiplicatoreQta4 = txtMoltiplQTA4.Text
                                            _L.MoltiplicatoreQta5 = txtMoltiplQTA5.Text
                                            _L.MoltiplicatoreQta0 = txtMoltiplQta0.Text
                                            _L.MoltiplicatoreQtaIntermedia = txtMoltiplicatIntermedio.Text

                                            _L.AbilitaQtaIntermedie = IIf(chkQtaIntermedie.Checked, enSiNo.Si, enSiNo.No)
                                            _L.AbilitaQtaSottoColonna1 = IIf(chkQtaSottoColonna1.Checked, enSiNo.Si, enSiNo.No)
                                            _L.NoAttachFile = IIf(chkNoFileAllegati.Checked, enSiNo.Si, enSiNo.No)
                                            _L.AllowCustomSize = IIf(chkAllowCustomSize.Checked, enSiNo.Si, enSiNo.No)

                                            _L.DefaultNFogli = txtDefaultNFogli.Text

                                            _L.p1 = lblr1.Text
                                            _L.p2 = lblr2.Text
                                            _L.p3 = lblr3.Text
                                            _L.p4 = lblr4.Text
                                            _L.p5 = lblr5.Text
                                            _L.p6 = lblr6.Text

                                        '_L.PercPromoAutomatico = txtPercPromo.Text
                                        '_L.PercMaxPromoFatturato = txtPercFatturatoMax.Text

                                        _L.QtaCollo = txtqtaCollo.Text
                                            _L.FaccMin = txtMinFacc.Text
                                            _L.FaccMax = txtMaxFacc.Text
                                            _L.NoFaccSuImpianti = chkNoFaccImp.Checked
                                            _L.noResa = chkNoResa.Checked
                                            _L.MinimaleStampa = txtMinimStampa.Text
                                            _L.MinimaleStampa2 = txtMinimStampa2.Text

                                            _L.PercAdatCostoCopia = txtPercCostoCopia.Text
                                            _L.AvviamStampa = txtAvviamStampa.Text
                                            _L.AvviamStampa2 = txtAvviamStampa2.Text

                                            _L.PrendiIcoDa = DirectCast(cmbPrendiIco.SelectedItem, cEnum).Id
                                            _L.TipoPrezzo = DirectCast(cmbTipoPrezzo.SelectedItem, cEnum).Id
                                            _L.IdTipoImballo = DirectCast(cmbTipoImballo.SelectedItem, cEnum).Id
                                            ' _L.DescrSito = txtDescrSito.Text.Trim
                                            _L.IdModelloCubetto = DirectCast(cmbTipoCubetto.SelectedItem, ModelloCubetto).IDModelloCubetto

                                            '_L.MostraPrezziTabella = IIf(chkMostraPrezziTabella.Checked, enSiNo.Si, enSiNo.No)
                                            _L.TipoControlloPrezzo = DirectCast(cmbTipoControlloPrezzo.SelectedItem, cEnum).Id
                                            _L.InEvidenza = IIf(chkInEvidenza.Checked, enSiNo.Si, enSiNo.No)
                                            _L.ConSoggettiDuplicati = IIf(chkSoggDupl.Checked, enSiNo.Si, enSiNo.No)
                                            _L.NascondiOnline = IIf(chkNascondiOnline.Checked, enSiNo.Si, enSiNo.No)
                                            _L.DescrSito = UcListinoBaseDatiWeb.txtDescrSito.Text
                                            _L.GoogleDescr = UcListinoBaseDatiWeb.txtRicercaGoogle.Text
                                            _L.GoogleSEO = UcListinoBaseDatiWeb.txtSEO.Text

                                            _L.IdHotFolderPostRefine = cmbHotFolder.SelectedValue

                                            _L.IdMacchinarioProduzione = cmbMacchinarioDef.SelectedValue

                                            Try
                                                _L.IdMacchinarioProduzione2 = cmbMacchinarioDef2.SelectedValue
                                            Catch ex As Exception

                                            End Try

                                            Try
                                                _L.IdLavTaglioDuplicati = cmbTaglioDuplicati.SelectedValue
                                            Catch ex As Exception

                                            End Try

                                            _L.IdMacchinarioTaglio = cmbMacchinarioTaglioDef.SelectedValue

                                            Dim QtaDefault As Integer = 0

                                            If rdoQtaDefault1.Checked Then QtaDefault = 1
                                            If rdoQtaDefault2.Checked Then QtaDefault = 2
                                            If rdoQtaDefault3.Checked Then QtaDefault = 3
                                            If rdoQtaDefault4.Checked Then QtaDefault = 4
                                            If rdoQtaDefault5.Checked Then QtaDefault = 5
                                            If rdoQtaDefault6.Checked Then QtaDefault = 6

                                            _L.QtaDefault = QtaDefault

                                            Dim LarghezzeRotolo As String = String.Empty

                                            If chkRot20.Checked Then
                                                LarghezzeRotolo &= 20 & ", "
                                            End If
                                            If chkRot60.Checked Then
                                                LarghezzeRotolo &= 60 & ", "
                                            End If
                                            If chkRot100.Checked Then
                                                LarghezzeRotolo &= 100 & ", "
                                            End If
                                            If chkRot130.Checked Then
                                                LarghezzeRotolo &= 130 & ", "
                                            End If
                                            If chkRot150.Checked Then
                                                LarghezzeRotolo &= 150 & ", "
                                            End If
                                            If chkRot200.Checked Then
                                                LarghezzeRotolo &= 200 & ", "
                                            End If

                                            _L.LargRotolo = LarghezzeRotolo

                                            If _L.IsValid Then

                                                'qui controllo che esista un prezzo per ogni formatoprodotto specifico presente nel listino base o 
                                                'almeno per ogni formato carta base di riferimento a quelli inseriti nel listino base
                                                Dim LavConFormatiProdottoMancanti As String = String.Empty
                                                Dim LavConSoloPrezzoGenerico As String = String.Empty
                                                Dim CatConSovrascriviImg As String = String.Empty
                                                Dim ErroreCatSovrascriviImg As Boolean = False
                                                Dim PresentiSoloPrezziGenerici As Boolean = False

                                                For Each singlav As Lavorazione In _L.LavorazioniBase

                                                    If singlav.Categoria.SovrascriviImgScheda = enSiNo.Si Then
                                                        If CatConSovrascriviImg.Length Then
                                                            If singlav.Categoria.Descrizione <> CatConSovrascriviImg Then
                                                                ErroreCatSovrascriviImg = True
                                                                CatConSovrascriviImg &= ", " & singlav.Categoria.Descrizione
                                                            End If
                                                        Else
                                                            CatConSovrascriviImg = singlav.Categoria.Descrizione
                                                        End If
                                                    End If
                                                    'If singlav.Prezzi.FindAll(Function(x) x.IdFormCarta = _L.FormatoProdotto.IdFormCarta And x.PrezzoSuProdottoFinito = False).Count = 0 Then
                                                    If singlav.Prezzi.FindAll(Function(x) x.IdFormProd = _L.IdFormProd).Count = 0 Then
                                                        If singlav.Prezzi.FindAll(Function(x) x.IdFormCarta = _L.FormatoProdotto.IdFormCarta).Count = 0 Then
                                                            If singlav.Prezzi.FindAll(Function(x) x.IdFormProd = 0).Count = 0 Then
                                                                LavConFormatiProdottoMancanti &= singlav.Descrizione & ", "
                                                            Else
                                                                If singlav.LavorazioneInterna = enSiNo.No AndAlso singlav.Categoria.TipoCaratteristica = enSiNo.No Then
                                                                    PresentiSoloPrezziGenerici = True
                                                                    LavConSoloPrezzoGenerico &= singlav.Descrizione & ", "
                                                                End If
                                                            End If
                                                        Else
                                                            If singlav.LavorazioneInterna = enSiNo.No AndAlso singlav.Categoria.TipoCaratteristica = enSiNo.No Then
                                                                PresentiSoloPrezziGenerici = True
                                                                LavConSoloPrezzoGenerico &= singlav.Descrizione & ", "
                                                            End If
                                                        End If
                                                        'End If
                                                    End If
                                                Next

                                                For Each singlav As Lavorazione In _L.LavorazioniOpz
                                                    If singlav.Categoria.SovrascriviImgScheda = enSiNo.Si Then
                                                        If CatConSovrascriviImg.Length Then
                                                            If singlav.Categoria.Descrizione <> CatConSovrascriviImg Then
                                                                ErroreCatSovrascriviImg = True
                                                                CatConSovrascriviImg &= ", " & singlav.Categoria.Descrizione
                                                            End If
                                                        Else
                                                            CatConSovrascriviImg = singlav.Categoria.Descrizione
                                                        End If
                                                    End If

                                                    'If singlav.Prezzi.FindAll(Function(x) x.IdFormCarta = _L.FormatoProdotto.IdFormCarta And x.PrezzoSuProdottoFinito = False).Count = 0 Then
                                                    If singlav.Prezzi.FindAll(Function(x) x.IdFormProd = _L.IdFormProd).Count = 0 Then
                                                        If singlav.Prezzi.FindAll(Function(x) x.IdFormCarta = _L.FormatoProdotto.IdFormCarta).Count = 0 Then
                                                            If singlav.Prezzi.FindAll(Function(x) x.IdFormProd = 0).Count = 0 Then
                                                                LavConFormatiProdottoMancanti &= singlav.Descrizione & ", "
                                                            Else
                                                                If singlav.LavorazioneInterna = enSiNo.No AndAlso singlav.Categoria.TipoCaratteristica = enSiNo.No Then
                                                                    PresentiSoloPrezziGenerici = True
                                                                    LavConSoloPrezzoGenerico &= singlav.Descrizione & ", "
                                                                End If
                                                            End If
                                                        Else
                                                            If singlav.LavorazioneInterna = enSiNo.No AndAlso singlav.Categoria.TipoCaratteristica = enSiNo.No Then
                                                                PresentiSoloPrezziGenerici = True
                                                                LavConSoloPrezzoGenerico &= singlav.Descrizione & ", "
                                                            End If
                                                        End If
                                                        'End If
                                                    End If
                                                    'If singlav.Prezzi.FindAll(Function(x) x.IdFormProd = _L.IdFormProd Or x.IdFormProd = 0).Count = 0 Then
                                                    '    'If singlav.Prezzi.FindAll(Function(x) x.IdFormCarta = _L.FormatoProdotto.IdFormCarta And x.PrezzoSuProdottoFinito = False).Count = 0 Then
                                                    '    LavConFormatiProdottoMancanti &= singlav.Descrizione & ", "
                                                    '    'End If
                                                    'End If
                                                Next

                                                If LavConFormatiProdottoMancanti.Length = 0 Or _L.Preventivazione.IdReparto = enRepartoWeb.Ricamo Then
                                                    If ErroreCatSovrascriviImg = False Then
                                                        'qui lo torno 
                                                        'copio l'immagine nella cartella centralizzata
                                                        If UcListinoBaseDatiWeb.txtImgSito.Text.Length Then
                                                            If UcListinoBaseDatiWeb.txtImgSito.Text <> _L.ImgSito Then
                                                                Dim nuovoNome As String = String.Empty
                                                                If UcListinoBaseDatiWeb.txtImgSito.Text.StartsWith(FormerPath.PathListinoImg) Then
                                                                    'non devo copiare
                                                                    nuovoNome = UcListinoBaseDatiWeb.txtImgSito.Text
                                                                Else
                                                                    'devo copiare 
                                                                    Dim F As New FileInfo(UcListinoBaseDatiWeb.txtImgSito.Text)
                                                                    nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(UcListinoBaseDatiWeb.txtImgSito.Text))
                                                                    MgrIO.FileCopia(Me, UcListinoBaseDatiWeb.txtImgSito.Text, nuovoNome)
                                                                End If
                                                                _L.ImgSito = nuovoNome
                                                            End If

                                                        End If

                                                        Dim OkPrezziGenerici As Boolean = True

                                                        If PresentiSoloPrezziGenerici Then
                                                            If MessageBox.Show("Sono state selezionate le seguenti lavorazioni '" & LavConSoloPrezzoGenerico & "' che hanno solo un prezzo generico o un prezzo sul formato carta ma non specifico per il formato prodotto di questo listino base. Salvare comunque?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                                OkPrezziGenerici = False
                                                            End If
                                                        End If

                                                        If OkPrezziGenerici Then

                                                            Using LOrig As New ListinoBase
                                                                LOrig.Read(_L.IdListinoBase)
                                                                LOrig.CaricaLavorazioni()
                                                                _L.VMotoreCalcolo = MgrPreventivazioneB.VMotoreCalcolo
                                                                _L.LastUpdate = enSiNo.Si
                                                                _L.Save()

                                                                UcListinoGruppoVariante.SaveVarianti()

                                                                If LOrig.FirmaLavorazioni <> _L.FirmaLavorazioni Then
                                                                    Sottofondo()
                                                                    Using f As New frmListinoOrdineLavorazioni
                                                                        f.Carica(_L.IdListinoBase)
                                                                    End Using
                                                                    Sottofondo()
                                                                End If

                                                            End Using

                                                            _Ris = 1
                                                            If EChiudi Then Close()
                                                        End If

                                                    Else
                                                        MessageBox.Show("Si Può scegliere una sola categoria con Sovrascrivi Immagine Formato attivo. Sono invece presenti le seguenti categorie con questa opzione attiva: " & CatConSovrascriviImg)

                                                    End If

                                                Else
                                                    MessageBox.Show("Si deve inserire un prezzo per questo formato prodotto o un formato prodotto generico con lo stesso formato carta per le seguenti lavorazioni: " & LavConFormatiProdottoMancanti)
                                                End If
                                            Else
                                                MessageBox.Show("ATTENZIONE! Tutti i campi sono obbligatori!", "Listino Base")
                                            End If

                                        End If
                                    End If


                                End If
                            End If

                        End If

                    End If
                End If


            End If

    End Sub

    Private Function OkCheckTabella() As Boolean

        Dim ris As Boolean = True

        'Dim val As cEnum = cmbTipoControlloPrezzo.SelectedItem

        'If val.Id = enTipoControlloPrezzo.Tabella Then
        '    Dim ValSel As Integer = DirectCast(cmbTipoPrezzo.SelectedItem, cEnum).Id
        '    If ValSel <> enTipoPrezzo.SuQuantita And ValSel <> enTipoPrezzo.SuMetriQuadri Then
        '        ris = False
        '    End If
        'End If

        Return ris

    End Function

    Private Function CalcolaPercSuCarta(PrezzoCalcolato As Decimal, CostoCarta As Decimal) As Single

        Dim ris As Single = 0

        If PrezzoCalcolato <> 0 And CostoCarta <> 0 Then

            ris = Math.Round((((PrezzoCalcolato * 100) / CostoCarta)))
        End If

        Return ris

    End Function

    Private Sub txtV1_TextChanged(sender As Object, e As EventArgs) Handles txtV1.TextChanged

        Try
            If sender.focused Then
                CalcolaValoriRif()
            End If


            lblPerc1.Text = CalcolaPercSuCarta(txtV1.Text, lblPc1.Text) & "%"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtV2_TextChanged(sender As Object, e As EventArgs) Handles txtV2.TextChanged

        Try
            If sender.focused Then
                CalcolaValoriRif()
            End If

            lblPerc2.Text = CalcolaPercSuCarta(txtV2.Text, lblPc2.Text) & "%"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtV3_TextChanged(sender As Object, e As EventArgs) Handles txtV3.TextChanged

        Try
            If sender.focused Then
                CalcolaValoriRif()
            End If


            lblPerc3.Text = CalcolaPercSuCarta(txtV3.Text, lblPc3.Text) & "%"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtV4_TextChanged(sender As Object, e As EventArgs) Handles txtV4.TextChanged
        Try
            If sender.focused Then
                CalcolaValoriRif()
            End If


            lblPerc4.Text = CalcolaPercSuCarta(txtV4.Text, lblPc4.Text) & "%"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtV5_TextChanged(sender As Object, e As EventArgs) Handles txtV5.TextChanged
        Try
            If sender.focused Then
                CalcolaValoriRif()
            End If

            lblPerc5.Text = CalcolaPercSuCarta(txtV5.Text, lblPc5.Text) & "%"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtV6_TextChanged(sender As Object, e As EventArgs) Handles txtV6.TextChanged
        Try
            If sender.focused Then
                CalcolaValoriRif()
            End If

            lblPerc6.Text = CalcolaPercSuCarta(txtV6.Text, lblPc6.Text) & "%"

        Catch ex As Exception

        End Try

    End Sub

    Private Function GetLBfromModulo() As ListinoBase
        Dim Lb As ListinoBase = Nothing
        Dim Check As Boolean = True

        If cmbColoriStampa.SelectedItem Is Nothing Then Check = False
        If cmbCurva.SelectedItem Is Nothing Then Check = False
        If cmbAttPubbl.SelectedItem Is Nothing Then Check = False
        If cmbFormatoMacchina.SelectedItem Is Nothing Then Check = False
        If cmbFormatoProd.SelectedItem Is Nothing Then Check = False
        If cmbTipoCarta.SelectedItem Is Nothing Then Check = False

        If Check Then
            Try
                Lb = New ListinoBase

                Lb.IdListinoBase = _L.IdListinoBase
                Lb.IdPrev = _P.IdPrev
                'Lb.IdListinoBase = -1
                Lb.Nome = txtNome.Text
                Lb.NomeInterno = txtNomeInterno.Text

                Lb.IdCurvaPubbl = cmbAttPubbl.SelectedValue
                Lb.IdColoreStampa = cmbColoriStampa.SelectedValue
                Lb.IdCurvaAtt = cmbCurva.SelectedValue
                Lb.IdFormato = cmbFormatoMacchina.SelectedValue
                Lb.IdFormatoMacchina2 = cmbFormatoMacchina2.SelectedValue
                Lb.IdFormProd = cmbFormatoProd.SelectedValue
                Lb.IdTipoCarta = cmbTipoCarta.SelectedValue
                Lb.IdTipoCartaCop = cmbTipoCartaCopertina.SelectedValue
                Lb.IdTipoCartaDorso = cmbTipoCartaDorso.SelectedValue
                Lb.qta1 = txtQ1.Text
                Lb.qta2 = txtQ2.Text
                Lb.qta3 = txtQ3.Text
                Lb.qta4 = txtQ4.Text
                Lb.qta5 = txtQ5.Text
                Lb.qta6 = txtQ6.Text
                Lb.v1 = txtV1.Text
                Lb.v2 = txtV2.Text
                Lb.v3 = txtV3.Text
                Lb.v4 = txtV4.Text
                Lb.v5 = txtV5.Text
                Lb.v6 = txtV6.Text
                Lb.CalcolaAncheDaSolo = IIf(chkCalcolaSolo.Checked, enSiNo.Si, enSiNo.No)

                Lb.MultiploQta = txtMultiplo.Text
                Lb.MoltiplicatoreQta = txtMoltiplQTA.Text
                Lb.MoltiplicatoreQta2 = txtMoltiplQTA2.Text
                Lb.MoltiplicatoreQta3 = txtMoltiplQTA3.Text
                Lb.MoltiplicatoreQta4 = txtMoltiplQTA4.Text
                Lb.MoltiplicatoreQta5 = txtMoltiplQTA5.Text
                Lb.MoltiplicatoreQta0 = txtMoltiplQta0.Text
                Lb.MoltiplicatoreQtaIntermedia = txtMoltiplicatIntermedio.Text

                Lb.AbilitaQtaIntermedie = IIf(chkQtaIntermedie.Checked, enSiNo.Si, enSiNo.No)
                Lb.AbilitaQtaSottoColonna1 = IIf(chkQtaSottoColonna1.Checked, enSiNo.Si, enSiNo.No)

                Lb.DefaultNFogli = txtDefaultNFogli.Text

                Lb.p1 = lblr1.Text
                Lb.p2 = lblr2.Text
                Lb.p3 = lblr3.Text
                Lb.p4 = lblr4.Text
                Lb.p5 = lblr5.Text
                Lb.p6 = lblr6.Text

                'Lb.PercPromoAutomatico = txtPercPromo.Text
                'Lb.PercMaxPromoFatturato = txtPercFatturatoMax.Text

                Lb.QtaCollo = txtqtaCollo.Text
                Lb.FaccMin = txtMinFacc.Text
                Lb.FaccMax = txtMaxFacc.Text
                Lb.NoFaccSuImpianti = chkNoFaccImp.Checked
                Lb.noResa = chkNoResa.Checked
                Lb.MinimaleStampa = txtMinimStampa.Text
                Lb.MinimaleStampa2 = txtMinimStampa2.Text

                Lb.PercAdatCostoCopia = txtPercCostoCopia.Text
                Lb.AvviamStampa = txtAvviamStampa.Text
                Lb.AvviamStampa2 = txtAvviamStampa2.Text

                Lb.PrendiIcoDa = DirectCast(cmbPrendiIco.SelectedItem, cEnum).Id
                Lb.TipoPrezzo = DirectCast(cmbTipoPrezzo.SelectedItem, cEnum).Id
                Lb.IdTipoImballo = DirectCast(cmbTipoImballo.SelectedItem, cEnum).Id
                ' Lb.DescrSito = txtDescrSito.Text.Trim
                Lb.IdModelloCubetto = DirectCast(cmbTipoCubetto.SelectedItem, ModelloCubetto).IDModelloCubetto

                'Lb.MostraPrezziTabella = IIf(chkMostraPrezziTabella.Checked, enSiNo.Si, enSiNo.No)
                Lb.TipoControlloPrezzo = DirectCast(cmbTipoControlloPrezzo.SelectedItem, cEnum).Id
                Lb.InEvidenza = IIf(chkInEvidenza.Checked, enSiNo.Si, enSiNo.No)
                Lb.NascondiOnline = IIf(chkNascondiOnline.Checked, enSiNo.Si, enSiNo.No)
                Lb.DescrSito = UcListinoBaseDatiWeb.txtDescrSito.Text
                Lb.GoogleDescr = UcListinoBaseDatiWeb.txtRicercaGoogle.Text
                Lb.GoogleSEO = UcListinoBaseDatiWeb.txtSEO.Text

                Lb.IdHotFolderPostRefine = cmbHotFolder.SelectedValue

                Lb.IdMacchinarioProduzione = cmbMacchinarioDef.SelectedValue

                Try
                    Lb.IdMacchinarioProduzione2 = cmbMacchinarioDef2.SelectedValue
                Catch ex As Exception

                End Try
                Lb.IdMacchinarioTaglio = cmbMacchinarioTaglioDef.SelectedValue

                Dim QtaDefault As Integer = 0

                If rdoQtaDefault1.Checked Then QtaDefault = 1
                If rdoQtaDefault2.Checked Then QtaDefault = 2
                If rdoQtaDefault3.Checked Then QtaDefault = 3
                If rdoQtaDefault4.Checked Then QtaDefault = 4
                If rdoQtaDefault5.Checked Then QtaDefault = 5
                If rdoQtaDefault6.Checked Then QtaDefault = 6

                Lb.QtaDefault = QtaDefault

                Dim LarghezzeRotolo As String = String.Empty

                If chkRot60.Checked Then
                    LarghezzeRotolo &= 60 & ", "
                End If
                If chkRot100.Checked Then
                    LarghezzeRotolo &= 100 & ", "
                End If
                If chkRot130.Checked Then
                    LarghezzeRotolo &= 130 & ", "
                End If
                If chkRot150.Checked Then
                    LarghezzeRotolo &= 150 & ", "
                End If
                If chkRot200.Checked Then
                    LarghezzeRotolo &= 200 & ", "
                End If

                Lb.LargRotolo = LarghezzeRotolo

            Catch ex As Exception
                Lb = Nothing
            End Try
        End If

        Return Lb
    End Function

    Private Sub CalcolaValoriRif()
        Try

            If cmbColoriStampa.SelectedItem Is Nothing Then Exit Sub
            If cmbCurva.SelectedItem Is Nothing Then Exit Sub
            If cmbAttPubbl.SelectedItem Is Nothing Then Exit Sub
            If cmbFormatoMacchina.SelectedItem Is Nothing Then Exit Sub
            If cmbFormatoProd.SelectedItem Is Nothing Then Exit Sub
            If cmbTipoCarta.SelectedItem Is Nothing Then Exit Sub

            Dim Lb As New ListinoBase
            Lb.IdColoreStampa = DirectCast(cmbColoriStampa.SelectedItem, ColoreStampa).IdColoreStampa

            Dim CurvaAtt As CurvaAtt = DirectCast(cmbCurva.SelectedItem, CurvaAtt)
            Dim CurvaAttP As CurvaAtt = DirectCast(cmbAttPubbl.SelectedItem, CurvaAtt)

            '07/03/2016 - modifica fatta per calcolare la curva sempre su base 1 
            Lb.IdCurvaAtt = 1 'DirectCast(cmbCurva.SelectedItem, CurvaAtt).IdCurvaAtt

            Lb.IdCurvaPubbl = CurvaAttP.IdCurvaAtt
            Lb.IdFormato = DirectCast(cmbFormatoMacchina.SelectedItem, Formato).IdFormato
            Lb.IdFormProd = DirectCast(cmbFormatoProd.SelectedItem, FormatoProdotto).IdFormProd
            Lb.IdTipoCarta = DirectCast(cmbTipoCarta.SelectedItem, TipoCarta).IdTipoCarta
            Lb.IdTipoCartaCop = DirectCast(cmbTipoCartaCopertina.SelectedItem, TipoCarta).IdTipoCarta
            Lb.IdTipoCartaDorso = DirectCast(cmbTipoCartaDorso.SelectedItem, TipoCarta).IdTipoCarta
            Lb.IdMacchinarioProduzione = DirectCast(cmbMacchinarioDef.SelectedItem, Macchinario).IdMacchinario
            Lb.IdMacchinarioTaglio = DirectCast(cmbMacchinarioTaglioDef.SelectedItem, Macchinario).IdMacchinario
            Lb.qta1 = txtQ1.Text
            Lb.qta2 = txtQ2.Text
            Lb.qta3 = txtQ3.Text
            Lb.qta4 = txtQ4.Text
            Lb.qta5 = txtQ5.Text
            Lb.qta6 = txtQ6.Text

            If rdoPrezzoMercato.Checked Then
                Lb.v1 = txtV1.Text
                Lb.v2 = txtV2.Text
                Lb.v3 = txtV3.Text
                Lb.v4 = txtV4.Text
                Lb.v5 = txtV5.Text
                Lb.v6 = txtV6.Text
            ElseIf rdoPercAdattamento.Checked Then
                Lb.p1 = lblr1.Text
                Lb.p2 = lblr2.Text
                Lb.p3 = lblr3.Text
                Lb.p4 = lblr4.Text
                Lb.p5 = lblr5.Text
                Lb.p6 = lblr6.Text
            End If

            Lb.MinimaleStampa = txtMinimStampa.Text
            Lb.PercAdatCostoCopia = txtPercCostoCopia.Text
            Lb.AvviamStampa = txtAvviamStampa.Text

            If IsNumeric(Lb.p1) = False Then Lb.p1 = 1
            If IsNumeric(Lb.p2) = False Then Lb.p2 = 1
            If IsNumeric(Lb.p3) = False Then Lb.p3 = 1
            If IsNumeric(Lb.p4) = False Then Lb.p4 = 1
            If IsNumeric(Lb.p5) = False Then Lb.p5 = 1
            If IsNumeric(Lb.p6) = False Then Lb.p6 = 1

            Dim err As Boolean = False

            If Lb.IdColoreStampa = 0 Then err = True
            If Lb.IdCurvaAtt = 0 Then err = True
            If Lb.IdFormato = 0 Then err = True
            If Lb.IdFormProd = 0 Then err = True
            If Lb.IdTipoCarta = 0 Then err = True
            If Lb.qta1 = 0 Then err = True
            If Lb.qta2 = 0 Then err = True
            If Lb.qta3 = 0 Then err = True
            If Lb.qta4 = 0 Then err = True
            If Lb.qta5 = 0 Then err = True
            If Lb.qta6 = 0 Then err = True

            Lb.NumFacciate = txtMinFacc.Text
            Lb.NoFaccSuImpianti = chkNoFaccImp.Checked
            Lb.noResa = chkNoResa.Checked
            Lb.TipoPrezzo = DirectCast(cmbTipoPrezzo.SelectedItem, cEnum).Id

            If err = False Then
                _RisultatoCalcolo = MgrPreventivazioneB.CalcolaPrezzi(Lb,
                                                                      _L.LavorazioniBaseB,
                                                                      ,
                                                                      rdoPrezzoMercato.Checked) 'mgr.CalcolaListinoBase(Lb, _L.LavorazioniBase)
            Else
                _RisultatoCalcolo = New RisListinoBase((New ListinoBase))
            End If

            lblC1.Text = _RisultatoCalcolo.PrezzoRivCalc1 + _RisultatoCalcolo.PrezzoLavObbl1
            lblC1.Tag = "Impianti: " & _RisultatoCalcolo.CostoImpianti & vbNewLine & _
                         " Carta: " & _RisultatoCalcolo.PrezzoCarta1 & vbNewLine & _
                         " Stampa: " & _RisultatoCalcolo.PrezzoStampa1 & vbNewLine & _
                         " Lavorazioni Obbl: " & _RisultatoCalcolo.PrezzoLavObbl1
            lblC2.Text = _RisultatoCalcolo.PrezzoRivCalc2 + _RisultatoCalcolo.PrezzoLavObbl2
            lblC2.Tag = "Impianti: " & _RisultatoCalcolo.CostoImpianti & vbNewLine & _
                         " Carta: " & _RisultatoCalcolo.PrezzoCarta2 & vbNewLine & _
                         " Stampa: " & _RisultatoCalcolo.PrezzoStampa2 & vbNewLine & _
                         " Lavorazioni Obbl: " & _RisultatoCalcolo.PrezzoLavObbl2
            lblC3.Text = _RisultatoCalcolo.PrezzoRivCalc3 + _RisultatoCalcolo.PrezzoLavObbl3
            lblC3.Tag = "Impianti: " & _RisultatoCalcolo.CostoImpianti & vbNewLine & _
                         " Carta: " & _RisultatoCalcolo.PrezzoCarta3 & vbNewLine & _
                         " Stampa: " & _RisultatoCalcolo.PrezzoStampa3 & vbNewLine & _
                         " Lavorazioni Obbl: " & _RisultatoCalcolo.PrezzoLavObbl3
            lblC4.Text = _RisultatoCalcolo.PrezzoRivCalc4 + _RisultatoCalcolo.PrezzoLavObbl4
            lblC4.Tag = "Impianti: " & _RisultatoCalcolo.CostoImpianti & vbNewLine & _
                         " Carta: " & _RisultatoCalcolo.PrezzoCarta4 & vbNewLine & _
                         " Stampa: " & _RisultatoCalcolo.PrezzoStampa4 & vbNewLine & _
                         " Lavorazioni Obbl: " & _RisultatoCalcolo.PrezzoLavObbl4
            lblC5.Text = _RisultatoCalcolo.PrezzoRivCalc5 + _RisultatoCalcolo.PrezzoLavObbl5
            lblC5.Tag = "Impianti: " & _RisultatoCalcolo.CostoImpianti & vbNewLine & _
                         " Carta: " & _RisultatoCalcolo.PrezzoCarta5 & vbNewLine & _
                         " Stampa: " & _RisultatoCalcolo.PrezzoStampa5 & vbNewLine & _
                         " Lavorazioni Obbl: " & _RisultatoCalcolo.PrezzoLavObbl5
            lblC6.Text = _RisultatoCalcolo.PrezzoRivCalc6 + _RisultatoCalcolo.PrezzoLavObbl6
            lblC6.Tag = "Impianti: " & _RisultatoCalcolo.CostoImpianti & vbNewLine & _
                         " Carta: " & _RisultatoCalcolo.PrezzoCarta6 & vbNewLine & _
                         " Stampa: " & _RisultatoCalcolo.PrezzoStampa6 & vbNewLine & _
                         " Lavorazioni Obbl: " & _RisultatoCalcolo.PrezzoLavObbl6

            lblPc1.Text = _RisultatoCalcolo.PrezzoTotCartaImpianti1
            lblPc2.Text = _RisultatoCalcolo.PrezzoTotCartaImpianti2
            lblPc3.Text = _RisultatoCalcolo.PrezzoTotCartaImpianti3
            lblPc4.Text = _RisultatoCalcolo.PrezzoTotCartaImpianti4
            lblPc5.Text = _RisultatoCalcolo.PrezzoTotCartaImpianti5
            lblPc6.Text = _RisultatoCalcolo.PrezzoTotCartaImpianti6

            'Dim pReale1 As Decimal = MgrPreventivazioneB.ApplicaCurva(_RisultatoCalcolo.PrezzoRivFinale1, CurvaAtt.v1)
            'Dim pReale2 As Decimal = MgrPreventivazioneB.ApplicaCurva(_RisultatoCalcolo.PrezzoRivFinale2, CurvaAtt.v2)
            'Dim pReale3 As Decimal = MgrPreventivazioneB.ApplicaCurva(_RisultatoCalcolo.PrezzoRivFinale3, CurvaAtt.v3)
            'Dim pReale4 As Decimal = MgrPreventivazioneB.ApplicaCurva(_RisultatoCalcolo.PrezzoRivFinale4, CurvaAtt.v4)
            'Dim pReale5 As Decimal = MgrPreventivazioneB.ApplicaCurva(_RisultatoCalcolo.PrezzoRivFinale5, CurvaAtt.v5)
            'Dim pReale6 As Decimal = MgrPreventivazioneB.ApplicaCurva(_RisultatoCalcolo.PrezzoRivFinale6, CurvaAtt.v6)

            Dim pReale1 As Decimal = _RisultatoCalcolo.PrezzoRivFinale1
            Dim pReale2 As Decimal = _RisultatoCalcolo.PrezzoRivFinale2
            Dim pReale3 As Decimal = _RisultatoCalcolo.PrezzoRivFinale3
            Dim pReale4 As Decimal = _RisultatoCalcolo.PrezzoRivFinale4
            Dim pReale5 As Decimal = _RisultatoCalcolo.PrezzoRivFinale5
            Dim pReale6 As Decimal = _RisultatoCalcolo.PrezzoRivFinale6

            'lblCsr1.Text = (Lb.v1 - (_RisultatoCalcolo.PrezzoRivCalc1 + _RisultatoCalcolo.PrezzoLavObbl1)) ' pReale1
            'lblCsr2.Text = (Lb.v2 - (_RisultatoCalcolo.PrezzoRivCalc2 + _RisultatoCalcolo.PrezzoLavObbl2))
            'lblCsr3.Text = (Lb.v3 - (_RisultatoCalcolo.PrezzoRivCalc3 + _RisultatoCalcolo.PrezzoLavObbl3))
            'lblCsr4.Text = (Lb.v4 - (_RisultatoCalcolo.PrezzoRivCalc4 + _RisultatoCalcolo.PrezzoLavObbl4))
            'lblCsr5.Text = (Lb.v5 - (_RisultatoCalcolo.PrezzoRivCalc5 + _RisultatoCalcolo.PrezzoLavObbl5))
            'lblCsr6.Text = (Lb.v6 - (_RisultatoCalcolo.PrezzoRivCalc6 + _RisultatoCalcolo.PrezzoLavObbl6))

            lblPubbl1.Text = MgrPreventivazioneB.ApplicaCurva(pReale1, CurvaAtt.v1) '_RisultatoCalcolo.PrezzoPubblFinale1
            lblPubbl2.Text = MgrPreventivazioneB.ApplicaCurva(pReale2, CurvaAtt.v2) '_RisultatoCalcolo.PrezzoPubblFinale2
            lblPubbl3.Text = MgrPreventivazioneB.ApplicaCurva(pReale3, CurvaAtt.v3) '_RisultatoCalcolo.PrezzoPubblFinale3
            lblPubbl4.Text = MgrPreventivazioneB.ApplicaCurva(pReale4, CurvaAtt.v4) '_RisultatoCalcolo.PrezzoPubblFinale4
            lblPubbl5.Text = MgrPreventivazioneB.ApplicaCurva(pReale5, CurvaAtt.v5) '_RisultatoCalcolo.PrezzoPubblFinale5
            lblPubbl6.Text = MgrPreventivazioneB.ApplicaCurva(pReale6, CurvaAtt.v6) '_RisultatoCalcolo.PrezzoPubblFinale6

            lblr1.Text = Lb.p1
            lblr2.Text = Lb.p2
            lblr3.Text = Lb.p3
            lblr4.Text = Lb.p4
            lblr5.Text = Lb.p5
            lblr6.Text = Lb.p6

            If rdoPercAdattamento.Checked Then
                txtV1.Text = _RisultatoCalcolo.PrezzoRivFinale1
                txtV2.Text = _RisultatoCalcolo.PrezzoRivFinale2
                txtV3.Text = _RisultatoCalcolo.PrezzoRivFinale3
                txtV4.Text = _RisultatoCalcolo.PrezzoRivFinale4
                txtV5.Text = _RisultatoCalcolo.PrezzoRivFinale5
                txtV6.Text = _RisultatoCalcolo.PrezzoRivFinale6
            End If

        Catch ex As Exception

        End Try

    End Sub

    'Private Sub CaricaIcone()

    '    Try
    '        pctIcoP.Image = Image.FromFile(_P.ImgRif)
    '    Catch ex As Exception

    '    End Try

    '    Dim Fp As New FormatoProdotto
    '    Fp.Read(cmbFormatoProd.SelectedValue)

    '    Try
    '        pctIcoFp.Image = Image.FromFile(Fp.ImgRif)
    '    Catch ex As Exception

    '    End Try

    '    Dim TC As New TipoCarta
    '    TC.Read(cmbTipoCarta.SelectedValue)

    '    Try
    '        pctIcoTc.Image = Image.FromFile(TC.ImgRif)
    '    Catch ex As Exception

    '    End Try

    '    Dim CS As New ColoreStampa
    '    CS.Read(cmbColoriStampa.SelectedValue)

    '    Try
    '        pctIcoCs.Image = Image.FromFile(CS.imgrif)
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub CheckCurve()
        If cmbAttPubbl.SelectedValue = cmbCurva.SelectedValue Then
            pctAlertCurva.Visible = True
        Else
            pctAlertCurva.Visible = False
        End If
    End Sub

    Private Sub cmbCurva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCurva.SelectedIndexChanged,
            cmbColoriStampa.SelectedIndexChanged,
            cmbFormatoMacchina.SelectedIndexChanged,
            cmbFormatoProd.SelectedIndexChanged,
            cmbTipoCarta.SelectedIndexChanged,
            cmbAttPubbl.SelectedIndexChanged,
            cmbTipoCartaCopertina.SelectedIndexChanged,
            cmbTipoCartaDorso.SelectedIndexChanged,
            cmbFormatoMacchina2.SelectedIndexChanged

        If sender Is cmbAttPubbl Or sender Is cmbCurva Then
            CheckCurve()
        ElseIf sender Is cmbFormatoProd Then
            If sender.focused Then
                CaricaFormatiMacchina()
            End If
        ElseIf sender Is cmbFormatoMacchina Then
            CaricaMacchinariProduzione()
        ElseIf sender Is cmbFormatoMacchina2 Then
            CaricaMacchinariProduzione2()
        End If

        If sender.focused Then
            CalcolaValoriRif()
            'CalcolaPrezziPubbl()
        End If
        CaricaSigla()
        'CaricaIcone()
        If sender Is cmbFormatoProd Then
            If sender.focused Then
                AggiornaDescrizioneLav(tvwListLav)
                AggiornaDescrizioneLav(tvwListLavOpz)
            End If
        End If
    End Sub

    Private Sub AggiornaDescrizioneLav(ByRef tvw As TreeView)

        Dim lstL As List(Of Lavorazione) = Nothing
        Using mgr As New LavorazioniDAO
            lstL = mgr.FindAll(LFM.Lavorazione.Descrizione,
                               New LUNA.LunaSearchParameter(LFM.Lavorazione.Stato, enStato.NonAttivo, "<>"))
        End Using

        Dim strIdL As String = ""
        For Each f As Lavorazione In lstL

            Dim NList As TreeNode() = tvw.Nodes.Find("L" & f.IdLavoro, True)

            If NList.Count Then

                Dim N As TreeNode = NList(0)
                Dim TestoNodo As String = f.Riassunto

                'qui devo andare a mettere quale prezzo verra' preso in considerazione tra quelli della lavorazion eper il formato
                'del listino base

                Dim P As PrezzoLavoro = Nothing

                'If FormatoWForzato = 0 Then
                f.CaricaPrezzi()

                Dim IdFP As Integer = cmbFormatoProd.SelectedValue

                Dim NewFP As New FormatoProdotto
                NewFP.Read(IdFP)

                P = f.Prezzi.Find(Function(x) x.IdFormProd = IdFP)
                'End If

                If Not P Is Nothing Then
                    TestoNodo &= " -> " & NewFP.Formato
                Else
                    P = f.Prezzi.Find(Function(x) x.IdFormCarta = NewFP.IdFormCarta)
                    If Not P Is Nothing Then
                        TestoNodo &= " -> " & P.FormatoProdotto.Formato
                    Else
                        Dim DimensiToFind As enTipoGrandezzaPrezzoLavorazione = enTipoGrandezzaPrezzoLavorazione.Medio

                        Dim FormatoWForzato As Integer = NewFP.Larghezza
                        Dim FormatoHForzato As Integer = NewFP.Lunghezza

                        If (FormatoWForzato < f.DimensMedieMinW And FormatoHForzato < f.DimensMedieMinH) OrElse
                       (FormatoHForzato < f.DimensMedieMinW And FormatoWForzato < f.DimensMedieMinH) Then
                            'qui parliamo del prezzo per il formato minimo
                            DimensiToFind = enTipoGrandezzaPrezzoLavorazione.Piccolo
                        ElseIf (FormatoWForzato > f.DimensMedieMaxW Or FormatoHForzato > f.DimensMedieMaxH) And
                       (FormatoHForzato > f.DimensMedieMaxW Or FormatoWForzato > f.DimensMedieMaxH) Then
                            'qui parlaimo del prezzo per il formato max 
                            DimensiToFind = enTipoGrandezzaPrezzoLavorazione.Grande
                        End If

                        P = f.Prezzi.Find(Function(x) x.IdFormProd = 0 And x.TipoGrandezza = DimensiToFind)

                        If Not P Is Nothing Then 'alla fine se non ho trovato un formato generico specifico cerco il generico standard
                            TestoNodo &= " -> Generico "

                            If P.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Piccolo Then
                                TestoNodo &= "Piccolo"
                            ElseIf P.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Grande Then
                                TestoNodo &= "Grande"
                            End If
                        Else
                            P = f.Prezzi.Find(Function(x) x.IdFormProd = 0 And x.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Medio) 'qui devo prendere il generico medio
                            TestoNodo &= " -> Generico Medio"
                        End If

                    End If

                End If

                N.Text = TestoNodo

            End If

        Next

    End Sub

    Private Sub CaricaSigla()

        lblSigla.Text = _L.CreaCodProd(txtQ1.Text, txtMinFacc.Text, _L.ShowLabelFogli)

    End Sub

    Private Function TrovaIndice(l As Lavorazione, chk As CheckedListBox) As Integer

        Dim Index As Integer = 0
        For Each lav As Lavorazione In chk.Items

            If lav.IdLavoro = l.IdLavoro Then Exit For

            Index += 1
        Next
        Return Index

    End Function

    Private Sub CaricaIconeLav()

        UcIcoLav.Carica(_L.LavorazioniBase, _L.LavorazioniOpz)

    End Sub

    Private Sub CaricaListeLav()

        _L.LavorazioniBase.Clear()
        For Each N As TreeNode In tvwListLav.Nodes
            'il primo livello lo salto sono le categorie
            For Each Nc As TreeNode In N.Nodes
                For Each NcI As TreeNode In Nc.Nodes
                    If NcI.Checked Then

                        Dim L As New Lavorazione
                        Dim IdLav As Integer = NcI.Name.Substring(1)
                        L.Read(IdLav)
                        _L.LavorazioniBase.Add(L)
                    End If

                Next

            Next

        Next

        _L.LavorazioniOpz.Clear()
        For Each N As TreeNode In tvwListLavOpz.Nodes
            For Each Nc As TreeNode In N.Nodes
                For Each NcI As TreeNode In Nc.Nodes
                    If NcI.Checked Then

                        Dim L As New Lavorazione
                        Dim IdLav As Integer = NcI.Name.Substring(1)
                        L.Read(IdLav)
                        _L.LavorazioniOpz.Add(L)
                    End If
                Next


            Next

        Next

    End Sub

    Private Sub txtNumFacciate_TextChanged(sender As Object, e As EventArgs) Handles txtMinFacc.TextChanged
        If sender.focused Then
            CalcolaValoriRif()
            If Val(txtMinFacc.Text) > Val(txtMaxFacc.Text) Then txtMaxFacc.Text = txtMinFacc.Text
        End If

    End Sub

    Private Sub lblC1_Click(sender As Object, e As EventArgs) Handles lblC1.Click, _
        lblC2.Click, _
        lblC3.Click, _
        lblC4.Click, _
        lblC5.Click, _
        lblC6.Click

        MessageBox.Show(sender.tag)

    End Sub

    Private Sub chkNoFaccImp_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoFaccImp.CheckedChanged
        If sender.focused Then CalcolaValoriRif()
        'CalcolaValoriRif()
    End Sub

    Private Sub txtMaxFacc_LostFocus(sender As Object, e As EventArgs) Handles txtMaxFacc.LostFocus
        If Val(txtMinFacc.Text) > Val(txtMaxFacc.Text) Then txtMaxFacc.Text = txtMinFacc.Text
    End Sub

    Private Sub txtMinFogli_TextChanged(sender As Object, e As EventArgs) Handles txtMinFogli.TextChanged
        If sender.focused Then
            Dim Fogli As Integer = 1
            If txtMinFogli.Text.Length Then
                Fogli = txtMinFogli.Text
            End If
            txtMinFacc.Text = Fogli * 2
            If txtMaxFogli.Text < txtMinFogli.Text Then txtMaxFogli.Text = txtMinFogli.Text
            If txtMaxFogli.Text <> txtMinFogli.Text Then
                txtMultiplo.Enabled = True
            Else
                txtMultiplo.Enabled = False
            End If
            CalcolaValoriRif()
        End If

    End Sub

    Private Sub txtMaxFogli_TextChanged(sender As Object, e As EventArgs) Handles txtMaxFogli.TextChanged

        If sender.focused Then
            Dim Fogli As Integer = 1
            If txtMaxFogli.Text.Length Then
                Fogli = txtMaxFogli.Text
            End If
            If txtMaxFogli.Text <> txtMinFogli.Text Then
                txtMultiplo.Enabled = True
            Else
                txtMultiplo.Enabled = False
            End If
            txtMaxFacc.Text = Fogli * 2
            CalcolaValoriRif()
        End If

    End Sub

    Private Sub txtQ2_TextChanged(sender As Object, e As EventArgs) Handles txtQ2.TextChanged
        If sender.focused Then
            CalcolaValoriRif()
            'lblr2.Text = CalcolaPercScarto(txtV2.Text, lblC2.Text)
            ' AggiornaPrezziPubblici()
        End If
    End Sub

    Private Sub txtQ3_TextChanged(sender As Object, e As EventArgs) Handles txtQ3.TextChanged
        If sender.focused Then
            CalcolaValoriRif()
            'lblr3.Text = CalcolaPercScarto(txtV3.Text, lblC3.Text)
            'AggiornaPrezziPubblici()
        End If
    End Sub

    Private Sub txtQ4_TextChanged(sender As Object, e As EventArgs) Handles txtQ4.TextChanged
        If sender.focused Then
            CalcolaValoriRif()
            'lblr4.Text = CalcolaPercScarto(txtV4.Text, lblC4.Text)
            'AggiornaPrezziPubblici()
        End If
    End Sub

    Private Sub txtQ5_TextChanged(sender As Object, e As EventArgs) Handles txtQ5.TextChanged

        If sender.focused Then
            CalcolaValoriRif()
            ' lblr5.Text = CalcolaPercScarto(txtV5.Text, lblC5.Text)
            ' AggiornaPrezziPubblici()
        End If
    End Sub

    Private Sub txtQ6_TextChanged(sender As Object, e As EventArgs) Handles txtQ6.TextChanged
        If sender.focused Then
            CalcolaValoriRif()
            'lblr6.Text = CalcolaPercScarto(txtV6.Text, lblC6.Text)
            'AggiornaPrezziPubblici()
        End If
    End Sub

    Private Sub btnFormatoMacchina_Click(sender As Object, e As EventArgs) Handles btnFormatoMacchina.Click

        Dim IdRif As Integer = cmbFormatoMacchina.SelectedValue

        Sottofondo()
        Dim frmRif As New frmListinoFormatoMacchina
        'If frmRif.Carica(IdRif) Then CaricaCombo()
        frmRif.Carica(IdRif)
        frmRif = Nothing
        Sottofondo()

    End Sub

    Private Sub btnFormatoProdotto_Click(sender As Object, e As EventArgs) Handles btnFormatoProdotto.Click
        Dim IdRif As Integer = cmbFormatoProd.SelectedValue

        Sottofondo()
        Using frmRif As New frmListinoFormatoProdotto
            'If frmRif.Carica(IdRif) Then CaricaCombo()
            If frmRif.Carica(IdRif) Then
                CaricaFormatiMacchina()
                CaricaMacchinariProduzione()
                CaricaMacchinariProduzione2()

                If MgrControl.SelectIndexCombo(cmbFormatoMacchina, _L.IdFormato) = -1 Then cmbFormatoMacchina.SelectedIndex = 0
                If MgrControl.SelectIndexCombo(cmbFormatoMacchina2, _L.IdFormatoMacchina2) Then cmbFormatoMacchina2.SelectedIndex = 0

                If MgrControl.SelectIndexCombo(cmbMacchinarioDef, _L.IdMacchinarioProduzione) AndAlso cmbMacchinarioDef.Items.Count > 0 Then cmbMacchinarioDef.SelectedIndex = 0
                If MgrControl.SelectIndexCombo(cmbMacchinarioDef2, _L.IdMacchinarioProduzione2) AndAlso cmbMacchinarioDef2.Items.Count > 0 Then cmbMacchinarioDef2.SelectedIndex = 0
            End If
        End Using
        Sottofondo()

    End Sub

    Private Sub btnTipoCarta_Click(sender As Object, e As EventArgs) Handles btnTipoCarta.Click
        Dim IdRif As Integer = cmbTipoCarta.SelectedValue

        Sottofondo()
        Dim frmRif As New frmListinoTipoCarta
        'If frmRif.Carica(IdRif) Then CaricaCombo()
        frmRif.Carica(IdRif)
        frmRif = Nothing
        Sottofondo()

    End Sub

    Private Sub btnColoriStampa_Click(sender As Object, e As EventArgs) Handles btnColoriStampa.Click
        Dim IdRif As Integer = cmbColoriStampa.SelectedValue

        Sottofondo()
        Dim frmRif As New frmListinoColoreStampa
        'If frmRif.Carica(IdRif) Then CaricaCombo()
        frmRif.Carica(IdRif)
        frmRif = Nothing
        Sottofondo()

    End Sub

    Private Sub tvwListLavOpz_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwListLavOpz.NodeMouseClick
        If e.Node.Name.StartsWith("L") Then
            'Dim OkVaiAvanti As Boolean = True

            'If rdoPercAdattamento.Checked Then
            '    If AvvisoCambioLavorazioniDato = False Then
            '        If MessageBox.Show("ATTENZIONE! Stai modificando delle lavorazioni base con il blocco della percentuale adattamento. Vuoi continuare?", "Modifica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            '            OkVaiAvanti = False
            '        Else
            '            AvvisoCambioLavorazioniDato = True
            '        End If
            '    End If
            'End If

            'If OkVaiAvanti Then
            Dim Chiave As String = e.Node.Name
            Dim OkVaiAvanti As Boolean = True
            Dim ChiavePadre As String = e.Node.Parent.Name

            If tvwListLav.Nodes.Find(ChiavePadre, True)(0).Nodes(Chiave).Checked Then
                If rdoPercAdattamento.Checked Then
                    If AvvisoCambioLavorazioniDato = False Then
                        If MessageBox.Show("ATTENZIONE! Stai modificando delle lavorazioni base con il blocco della percentuale adattamento. Vuoi continuare?", "Modifica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            OkVaiAvanti = False
                        Else
                            AvvisoCambioLavorazioniDato = True
                        End If
                    End If
                End If
                If OkVaiAvanti Then tvwListLav.Nodes.Find(ChiavePadre, True)(0).Nodes(Chiave).Checked = False
            End If
            If OkVaiAvanti Then
                e.Node.Checked = Not e.Node.Checked

                e.Node.Parent.Checked = e.Node.Checked

                'ora deseleziono tutti gli altri nodi della stessa categoria tranne questo
                'For Each N As TreeNode In tvwListLavOpz.Nodes(ChiavePadre).Nodes
                '    If N.Name <> Chiave Then
                '        N.Checked = False
                '    Else
                '        N.Checked = Not N.Checked
                '    End If
                'Next
                CaricaListeLav()
                CaricaIconeLav()
                CalcolaValoriRif()
                'End If
            End If



        End If

    End Sub

    Private Sub tvwListLav_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwListLav.NodeMouseClick
        If e.Node.Name.StartsWith("L") Then

            Dim OkVaiAvanti As Boolean = True

            If rdoPercAdattamento.Checked Then
                If AvvisoCambioLavorazioniDato = False Then
                    If MessageBox.Show("ATTENZIONE! Stai modificando delle lavorazioni base con il blocco della percentuale adattamento. Vuoi continuare?", "Modifica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        OkVaiAvanti = False
                    Else
                        AvvisoCambioLavorazioniDato = True
                    End If
                End If
            End If

            If OkVaiAvanti Then
                Dim Chiave As String = e.Node.Name
                Dim ChiavePadre As String = e.Node.Parent.Name
                tvwListLavOpz.Nodes.Find(ChiavePadre, True)(0).Checked = False

                tvwListLavOpz.Nodes.Find(Chiave, True)(0).Checked = False

                'ora deseleziono tutti gli altri nodi della stessa categoria tranne questo
                For Each N As TreeNode In tvwListLav.Nodes.Find(ChiavePadre, True)(0).Nodes
                    If N.Name <> Chiave Then
                        N.Checked = False
                    Else
                        N.Checked = Not N.Checked
                    End If
                Next

                e.Node.Parent.Checked = e.Node.Checked

                CaricaListeLav()
                CaricaIconeLav()
                CalcolaValoriRif()
            End If


        End If

    End Sub

    Private Sub tvwListLav_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwListLav.NodeMouseDoubleClick, tvwListLavOpz.NodeMouseDoubleClick
        If e.Node.Name.StartsWith("L") Then
            Dim IdLav As Integer = e.Node.Name.Substring(1)

            If IdLav Then
                Sottofondo()
                Dim f As New frmListinoLavorazione
                If f.Carica(IdLav) Then
                    Dim L As New Lavorazione
                    L.Read(IdLav)
                    'qui devo aggiornare la voc
                    e.Node.Text = L.Riassunto
                    L = Nothing
                End If
                f = Nothing
                Sottofondo()
            End If
        End If


    End Sub

    Private Sub btnCostoLav_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub lblPc1_TextChanged(sender As Object, e As EventArgs) Handles lblPc1.TextChanged
        Dim Val As Decimal = 0

        Try
            Val = txtV1.Text
        Catch ex As Exception

        End Try

        lblPerc1.Text = CalcolaPercSuCarta(Val, lblPc1.Text) & "%"
    End Sub

    Private Sub lblPc2_TextChanged(sender As Object, e As EventArgs) Handles lblPc2.TextChanged
        Dim Val As Decimal = 0

        Try
            Val = txtV2.Text
        Catch ex As Exception

        End Try
        lblPerc2.Text = CalcolaPercSuCarta(Val, lblPc2.Text) & "%"
    End Sub

    Private Sub lblPc3_TextChanged(sender As Object, e As EventArgs) Handles lblPc3.TextChanged
        Dim Val As Decimal = 0

        Try
            Val = txtV3.Text
        Catch ex As Exception

        End Try
        lblPerc3.Text = CalcolaPercSuCarta(Val, lblPc3.Text) & "%"
    End Sub

    Private Sub lblPc4_TextChanged(sender As Object, e As EventArgs) Handles lblPc4.TextChanged
        Dim Val As Decimal = 0

        Try
            Val = txtV4.Text
        Catch ex As Exception

        End Try
        lblPerc4.Text = CalcolaPercSuCarta(Val, lblPc4.Text) & "%"
    End Sub

    Private Sub lblPc5_TextChanged(sender As Object, e As EventArgs) Handles lblPc5.TextChanged
        Dim Val As Decimal = 0

        Try
            Val = txtV5.Text
        Catch ex As Exception

        End Try
        lblPerc5.Text = CalcolaPercSuCarta(Val, lblPc5.Text) & "%"
    End Sub

    Private Sub lblPc6_TextChanged(sender As Object, e As EventArgs) Handles lblPc6.TextChanged
        Dim Val As Decimal = 0

        Try
            Val = txtV6.Text
        Catch ex As Exception

        End Try
        lblPerc6.Text = CalcolaPercSuCarta(Val, lblPc6.Text) & "%"
    End Sub

    Private Sub chkNoResa_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoResa.CheckedChanged
        If sender.focused Then CalcolaValoriRif()
        'CalcolaValoriRif()

    End Sub

    Private Sub txtPercCostoCopia_TextChanged(sender As Object, e As EventArgs) Handles txtPercCostoCopia.TextChanged,
                                                                                        txtAvviamStampa.TextChanged,
                                                                                        txtMinimStampa.TextChanged
        If sender.focused Then CalcolaValoriRif()
    End Sub

    'Private Sub CaricaAnteprima()
    '    Try
    '        If txtImgSito.Text.Length Then
    '            Dim i As Image = Image.FromFile(txtImgSito.Text)
    '            pctAnteprima.Image = i
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub TabMain_TabIndexChanged(sender As Object, e As EventArgs) Handles TabMain.TabIndexChanged
    '    If TabMain.SelectedTab Is tpAnteprima Then
    '        CreaAnteprima()
    '    End If


    'End Sub

    'Public Sub CreaAnteprima()

    '    Dim Url As String = ""

    '    Dim IdColoreStampa As Integer = DirectCast(cmbColoriStampa.SelectedItem, ColoreStampa).IdColoreStampa
    '    Dim IdFormProd As Integer = DirectCast(cmbFormatoProd.SelectedItem, FormatoProdotto).IdFormProd
    '    Dim IdTipoCarta As Integer = DirectCast(cmbTipoCarta.SelectedItem, TipoCarta).IdTipoCarta

    '    Url = "http://former-server/" & _P.IdPrev & "/" & IdFormProd & "/" & IdTipoCarta & "/" & IdColoreStampa & "/" & (txtMinFacc.Text / 2) & "/Pippo"

    '    UcAnteprimaLB.Carica(Url)

    'End Sub

    Private Sub btnNewFP_Click(sender As Object, e As EventArgs) Handles btnNewFP.Click
        Sottofondo()

        Dim f As New frmListinoFormatoProdotto

        Dim ris As Integer = f.Carica()
        f = Nothing

        If ris Then
            CaricaFormatiProdotto()
        End If

        Sottofondo()
    End Sub

    Private Sub btnNewMac_Click(sender As Object, e As EventArgs) Handles btnNewMac.Click
        Sottofondo()

        Dim ris As Integer = (New frmListinoFormatoMacchina).Carica()

        If ris Then CaricaFormatiMacchina()

        Sottofondo()
    End Sub

    Private Sub btnNewCop_Click(sender As Object, e As EventArgs)
        Sottofondo()

        Dim f As New frmListinoTipoCarta

        Dim ris As Integer = f.Carica()
        f = Nothing

        If ris Then
            CaricaTCCopertina()
        End If

        Sottofondo()
    End Sub

    Private Sub btnNewCarta_Click(sender As Object, e As EventArgs) Handles btnNewCarta.Click
        Sottofondo()

        Dim f As New frmListinoTipoCarta

        Dim ris As Integer = f.Carica()
        f = Nothing

        If ris Then
            CaricaTC()
            CaricaTCCopertina()
            CaricaTCDorso()
        End If

        Sottofondo()
    End Sub

    Private Sub btnNewDor_Click(sender As Object, e As EventArgs)
        Sottofondo()

        Dim f As New frmListinoTipoCarta

        Dim ris As Integer = f.Carica()
        f = Nothing

        If ris Then
            CaricaTCDorso()
        End If

        Sottofondo()
    End Sub

    Private Sub btnNewColore_Click(sender As Object, e As EventArgs) Handles btnNewColore.Click
        Sottofondo()

        Dim ris As Integer = (New frmListinoColoreStampa).Carica()

        If ris Then CaricaCS()

        Sottofondo()
    End Sub

    Private Sub cmbFinitCop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFinitCop.SelectedIndexChanged
        CaricaTCCopertina()
    End Sub

    Private Sub cmbFinit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFinit.SelectedIndexChanged
        CaricaTC()
    End Sub

    Private Sub cmbFinitDor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFinitDor.SelectedIndexChanged
        CaricaTCDorso()
    End Sub

    'Private Sub txtNome_TextChanged(sender As Object, e As EventArgs) Handles txtNome.TextChanged
    '    lblNomeListinoBase.Text = txtNome.Text
    'End Sub

    'Private Sub txtDescrSito_TextChanged(sender As Object, e As EventArgs)
    '    lblInfoDescr.Text = "Caratteri restanti descrizione sito: " & txtDescrSito.MaxLength - txtDescrSito.Text.Length
    'End Sub

    'Private Sub cmbPrendiIco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrendiIco.SelectedIndexChanged
    '    CaricaImgPrendiIcoDa()
    'End Sub

    Private Sub btnDettCubetto_Click(sender As Object, e As EventArgs) Handles btnDettCubetto.Click
        If cmbTipoCubetto.SelectedValue Then
            Sottofondo()
            Dim frm As New frmListinoModelloCubetto

            Dim ris As Integer = frm.Carica(cmbTipoCubetto.SelectedItem)

            If ris Then CaricaModelliCubetti()
            frm = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btnNewCubetto_Click(sender As Object, e As EventArgs) Handles btnNewCubetto.Click

        Sottofondo()
        Dim frm As New frmListinoModelloCubetto
        Dim Cub As New ModelloCubetto With {.Profondita = 100, .Larghezza = 200, .Lunghezza = 150}

        Dim ris As Integer = frm.Carica(Cub)

        If ris Then CaricaModelliCubetti()

        frm = Nothing
        Sottofondo()

    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

    End Sub

    Private Sub lnkOrdineLavorazioni_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOrdineLavorazioni.LinkClicked

        If _L.IdListinoBase Then
            Dim Ris As Integer = 0
            Sottofondo()
            Using f As New frmListinoOrdineLavorazioni
                Ris = f.Carica(_L.IdListinoBase)
            End Using

            Sottofondo()
        Else
            MessageBox.Show("Salvare prima il listino base")
        End If

    End Sub

    Private Sub cmbTipoPrezzo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPrezzo.SelectedIndexChanged

        Dim ValSel As enTipoPrezzo
        Dim OggSel As cEnum = cmbTipoPrezzo.SelectedItem
        ValSel = OggSel.Id

        If ValSel = enTipoPrezzo.SuMetriQuadri Then
            grpLarghezza.Enabled = True
            chkRot60.Enabled = True
            chkRot100.Enabled = True
            chkRot130.Enabled = True
            chkRot150.Enabled = True
        Else
            grpLarghezza.Enabled = False
            chkRot60.Enabled = False
            chkRot100.Enabled = False
            chkRot130.Enabled = False
            chkRot150.Enabled = False
        End If

    End Sub

    Private Sub txtAltezzaEtichette_TextChanged(sender As Object, e As EventArgs) Handles txtAltezzaEtichette.TextChanged
        CalcolaCmQuadri()
    End Sub

    Private Sub txtLarghezzaEtichette_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezzaEtichette.TextChanged
        CalcolaCmQuadri()
    End Sub

    Private Sub CalcolaCmQuadri()
        Try
            lblRis.Text = MgrCalcoliTecnici.CalcolaCmQuadri(txtAltezzaEtichette.Text,
                                                            txtLarghezzaEtichette.Text,
                                                            enTipoOrientamento.Orizzontale,
                                                            (_L.FormatoProdotto.FormatoCarta.Larghezza * 10),
                                                            txtQuantitaEtichette.Text)
        Catch ex As Exception
            lblRis.Text = 0
        End Try

    End Sub

    Private Sub txtQuantitaEtichette_TextChanged(sender As Object, e As EventArgs) Handles txtQuantitaEtichette.TextChanged
        CalcolaCmQuadri()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Close()

    End Sub

    Private Sub Prosegui()
        Try
            TabMain.SelectedIndex += 1
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnProsegui_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSalva_Click(sender As Object, e As EventArgs)
        SalvaListinoBase()
    End Sub

    Private Sub PreviewTabellaPrezzi()

        Dim buffer As String = "<table border=1>"

        buffer &= "<tr><td>Quantita'</td></tr>"

        Dim mgr As New MgrQtaListinoBase
        Dim lrif As New ListinoBase

        lrif.qta1 = txtQ1.Text
        lrif.qta2 = txtQ2.Text
        lrif.qta3 = txtQ3.Text
        lrif.qta4 = txtQ4.Text
        lrif.qta5 = txtQ5.Text
        lrif.qta6 = txtQ6.Text

        Try
            lrif.MoltiplicatoreQta = txtMoltiplQTA.Text
            lrif.MoltiplicatoreQta2 = txtMoltiplQTA2.Text
            lrif.MoltiplicatoreQta3 = txtMoltiplQTA3.Text
            lrif.MoltiplicatoreQta4 = txtMoltiplQTA4.Text
            lrif.MoltiplicatoreQta5 = txtMoltiplQTA5.Text

        Catch ex As Exception

        End Try

        Dim l As List(Of Integer) = mgr.GetElencoQtaReverse(lrif)

        For Each val As Integer In l
            buffer &= "<tr><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(val) & "</td></tr>"
        Next

        'Dim Q1 As Integer = txtQ1.Text
        'Dim Q2 As Integer = txtQ2.Text
        'Dim Q3 As Integer = txtQ3.Text
        'Dim Q4 As Integer = txtQ4.Text
        'Dim Q5 As Integer = txtQ5.Text
        'Dim Q6 As Integer = txtQ6.Text

        'Dim Moltiplicatore As Integer = 0
        'Dim QtaCaricate As New List(Of Integer)
        'Try
        '    Moltiplicatore = txtMoltiplQTA.Text
        'Catch ex As Exception

        'End Try

        'buffer &= "<tr><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(Q1) & "</td></tr>"

        'QtaCaricate.Add(Q1)

        'If Moltiplicatore Then
        '    Dim QtaIniziale As Integer = Q1 + Moltiplicatore
        '    Dim QtaFinale As Integer = Q2 - Moltiplicatore
        '    For valore As Integer = QtaIniziale To QtaFinale Step Moltiplicatore
        '        buffer &= "<tr><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(valore) & "</td></tr>"
        '        QtaCaricate.Add(valore)
        '    Next
        'End If

        'For I As Integer = Q2 To Q6 Step Q2
        '    Dim VarI As Integer = I
        '    If QtaCaricate.FindAll(Function(x) x = VarI).Count = 0 Then
        '        QtaCaricate.Add(VarI)
        '        buffer &= "<tr><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(VarI) & "</td></tr>"

        '    End If
        'Next

        buffer &= "</table>"

        Dim NomeFile As String = FormerPath.PathTempLocale & FormerHelper.File.GetNomeFileTemp(".htm")
        Using w As New StreamWriter(NomeFile)
            w.Write(buffer)
        End Using


        Sottofondo()
        Using f As New frmStampa

            f.Carica(NomeFile)

        End Using
        Sottofondo()

    End Sub

    Private Sub lnkAnteprimaPrezzi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAnteprimaPrezzi.LinkClicked

        PreviewTabellaPrezzi()

    End Sub

    Private Sub btnHotFolder_Click(sender As Object, e As EventArgs) Handles btnHotFolder.Click

        'carico la gestione hotfolder
        Sottofondo()
        Using f As New frmHotFolderMgr
            f.Carica()
        End Using
        Sottofondo()

    End Sub

    Private Sub tpImpostazioniInterne_Click(sender As Object, e As EventArgs) Handles tpImpostazioniInterne.Click

    End Sub

    'Private Sub txtPercPromo_TextChanged(sender As Object, e As EventArgs)
    '    If txtPercPromo.Value = 0 Then txtPercFatturatoMax.Text = 0
    'End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs)
        SalvaListinoBase(True)
    End Sub

    Private Sub cmbAltriListiniBase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAltriListiniBase.SelectedIndexChanged
        If sender.focused Then

            'qui vado a ricarcare il nuovo listinobase
            Cursor.Current = Cursors.WaitCursor
            Dim l As ListinoBase = cmbAltriListiniBase.SelectedItem
            CaricamentoInterno(l)
            Cursor.Current = Cursors.Default

        End If
    End Sub

    Private Sub btnMaccProdDett_Click(sender As Object, e As EventArgs) Handles btnMaccProdDett.Click
        Dim IdRif As Integer = cmbMacchinarioDef.SelectedValue
        If IdRif Then
            Sottofondo()
            Dim frmRif As New frmListinoMacchinario
            If frmRif.Carica(IdRif) Then CaricaMacchinariProduzione()
            frmRif = Nothing
            Sottofondo()

        End If
    End Sub

    Private Sub btnMaccTaglioDett_Click(sender As Object, e As EventArgs) Handles btnMaccTaglioDett.Click
        Dim IdRif As Integer = cmbMacchinarioTaglioDef.SelectedValue
        If IdRif Then
            Sottofondo()
            Dim frmRif As New frmListinoMacchinario
            If frmRif.Carica(IdRif) Then CaricaMacchinariTaglio()
            frmRif = Nothing
            Sottofondo()
        End If

    End Sub

    Private Sub btnMaccProdDett2_Click(sender As Object, e As EventArgs) Handles btnMaccProdDett2.Click
        Dim IdRif As Integer = cmbMacchinarioDef2.SelectedValue
        If IdRif Then
            Sottofondo()
            Dim frmRif As New frmListinoMacchinario
            If frmRif.Carica(IdRif) Then CaricaMacchinariProduzione()
            frmRif = Nothing
            Sottofondo()

        End If
    End Sub

    Private Sub btnFormatoMacchina2_Click(sender As Object, e As EventArgs) Handles btnFormatoMacchina2.Click

        Dim IdRif As Integer = cmbFormatoMacchina2.SelectedValue

        Sottofondo()
        Dim frmRif As New frmListinoFormatoMacchina
        'If frmRif.Carica(IdRif) Then CaricaCombo()
        frmRif.Carica(IdRif)
        frmRif = Nothing
        Sottofondo()
    End Sub

    Private Sub btnNewMacch2_Click(sender As Object, e As EventArgs) Handles btnNewMacch2.Click
        Sottofondo()

        Dim ris As Integer = (New frmListinoFormatoMacchina).Carica()

        If ris Then CaricaFormatiMacchina()

        Sottofondo()
    End Sub

    Private Sub txtTestQta_TextChanged(sender As Object, e As EventArgs) Handles txtTestQta.TextChanged

    End Sub

    Private Sub TestQta()

        Dim lb As ListinoBase = GetLBfromModulo()

        If lb Is Nothing Then
            txtTestQta.Text = String.Empty
            lblTestQtaCalcolata.Text = String.Empty
        Else

            Dim Qta As Single = txtTestQta.Text
            lb.NumFacciate = lb.FaccMin
            Qta = MgrPreventivazioneB.ArrotondaQtaConMoltiplicatore(Qta, lb)

            lblTestQtaCalcolata.Text = Qta

            Dim R As RisPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoFinale(lb, Qta, _L.LavorazioniBaseB,,, False)

            lblTestPrezzoCalcolato.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(R.PrezzoRiv)
        End If

    End Sub

    Private Sub btnTestCalcola_Click(sender As Object, e As EventArgs) Handles btnTestCalcola.Click
        TestQta()
    End Sub

    Private Sub lnkCostoLav_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCostoLav.LinkClicked

        Sottofondo()

        Dim f As New frmCalcLavoraz

        Dim Lb As New ListinoBase
        Lb.IdColoreStampa = DirectCast(cmbColoriStampa.SelectedItem, ColoreStampa).IdColoreStampa
        Lb.IdCurvaAtt = DirectCast(cmbCurva.SelectedItem, CurvaAtt).IdCurvaAtt
        Lb.IdCurvaPubbl = DirectCast(cmbAttPubbl.SelectedItem, CurvaAtt).IdCurvaAtt
        Lb.IdFormato = DirectCast(cmbFormatoMacchina.SelectedItem, Formato).IdFormato
        Lb.IdFormProd = DirectCast(cmbFormatoProd.SelectedItem, FormatoProdotto).IdFormProd
        Lb.IdTipoCarta = DirectCast(cmbTipoCarta.SelectedItem, TipoCarta).IdTipoCarta

        Lb.qta1 = txtQ1.Text
        Lb.qta2 = txtQ2.Text
        Lb.qta3 = txtQ3.Text
        Lb.qta4 = txtQ4.Text
        Lb.qta5 = txtQ5.Text
        Lb.qta6 = txtQ6.Text

        Lb.v1 = txtV1.Text
        Lb.v2 = txtV2.Text
        Lb.v3 = txtV3.Text
        Lb.v4 = txtV4.Text
        Lb.v5 = txtV5.Text
        Lb.v6 = txtV6.Text

        If f.Carica(Lb) Then
            'TODO: SELEZIONARE LE LAVORAZIONI SCELTE NELLA FORM 

        End If
        f = Nothing
        Sottofondo()
    End Sub

    Private Sub tvwListLav_HandleCreated(sender As Object, e As EventArgs) Handles tvwListLav.HandleCreated

    End Sub

    Private Sub tvwListLav_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvwListLav.AfterCheck, tvwListLavOpz.AfterCheck



    End Sub

    Private Sub rdoPercAdattamento_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPercAdattamento.CheckedChanged
        If rdoPercAdattamento.Checked Then
            rdoPercAdattamento.BackColor = Color.Red
            rdoPercAdattamento.ForeColor = Color.White
        Else
            rdoPercAdattamento.BackColor = Color.Transparent
            rdoPercAdattamento.ForeColor = Color.Black
        End If
    End Sub

    Private Sub rdoPrezzoMercato_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPrezzoMercato.CheckedChanged
        If rdoPrezzoMercato.Checked Then
            rdoPrezzoMercato.BackColor = Color.Green
            rdoPrezzoMercato.ForeColor = Color.White
        Else
            rdoPrezzoMercato.BackColor = Color.Transparent
            rdoPrezzoMercato.ForeColor = Color.Black
        End If
    End Sub

    Private Sub tvwListLav_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwListLav.AfterSelect

    End Sub

    Private Sub ChkQtaSottoColonna1_CheckedChanged(sender As Object, e As EventArgs) Handles chkQtaSottoColonna1.CheckedChanged
        MgrControl.SelectIndexComboEnum(cmbTipoControlloPrezzo, enTipoControlloPrezzo.Tabella)
    End Sub

    Private Sub ChkQtaIntermedie_CheckedChanged(sender As Object, e As EventArgs) Handles chkQtaIntermedie.CheckedChanged
        MgrControl.SelectIndexComboEnum(cmbTipoControlloPrezzo, enTipoControlloPrezzo.Tabella)
    End Sub

    Private Sub BtnTipoCartaDorso_Click(sender As Object, e As EventArgs) Handles btnTipoCartaDorso.Click
        Dim IdRif As Integer = cmbTipoCartaDorso.SelectedValue

        Sottofondo()
        Dim frmRif As New frmListinoTipoCarta
        'If frmRif.Carica(IdRif) Then CaricaCombo()
        frmRif.Carica(IdRif)
        frmRif = Nothing
        Sottofondo()

    End Sub

    Private Sub BtnTipoCartaCopertina_Click(sender As Object, e As EventArgs) Handles btnTipoCartaCopertina.Click
        Dim IdRif As Integer = cmbTipoCartaCopertina.SelectedValue

        Sottofondo()
        Dim frmRif As New frmListinoTipoCarta
        'If frmRif.Carica(IdRif) Then CaricaCombo()
        frmRif.Carica(IdRif)
        frmRif = Nothing
        Sottofondo()

    End Sub

    Private Sub btnClose2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ChiudiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChiudiToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub SalvaEChiudiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvaEChiudiToolStripMenuItem.Click
        SalvaListinoBase(True)
    End Sub

    Private Sub SalvaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvaToolStripMenuItem.Click
        SalvaListinoBase()
    End Sub

    Private Sub ProseguiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProseguiToolStripMenuItem.Click
        Prosegui()
    End Sub

    Private Sub btnNewGruppoLogico_Click(sender As Object, e As EventArgs) Handles btnNewGruppoLogico.Click

        Dim Nome As String = String.Empty
        Nome = InputBox("Inserisci il nome del Gruppo Logico che vuoi creare", "Nuovo")
        Nome = Nome.Trim()

        If Nome.Length Then
            Using mgr As New GruppiLBLogiciDAO
                Dim l As List(Of GruppoLBLogico) = mgr.FindAll(New LUNA.LSP(LFM.GruppoLBLogico.Nome, Nome))
                Dim IdInserito As Integer = 0
                If l.Count = 0 Then

                    Using g As New GruppoLBLogico
                        g.Nome = Nome
                        IdInserito = g.Save()
                    End Using

                    CaricaGruppiLBLogici()

                Else
                    Using g As GruppoLBLogico = l(0)
                        IdInserito = g.IdGruppoLBLogico
                    End Using
                End If
                MgrControl.SelectIndexCombo(cmbGruppoLogico, IdInserito)
            End Using
        End If


    End Sub

    Private Sub btnNewGruppoConsigliato_Click(sender As Object, e As EventArgs) Handles btnNewGruppoConsigliato.Click
        Dim Nome As String = String.Empty
        Nome = InputBox("Inserisci il nome del Gruppo di Prodotti Consigliati che vuoi creare", "Nuovo")
        Nome = Nome.Trim()

        If Nome.Length Then
            Using mgr As New GruppiLBConsigliatiDAO
                Dim l As List(Of GruppoLBConsigliato) = mgr.FindAll(New LUNA.LSP(LFM.GruppoLBConsigliato.Nome, Nome))
                Dim IdInserito As Integer = 0
                If l.Count = 0 Then

                    Using g As New GruppoLBConsigliato
                        g.Nome = Nome
                        IdInserito = g.Save()
                    End Using

                    CaricaGruppiLBAppartenenza()

                Else
                    Using g As GruppoLBConsigliato = l(0)
                        IdInserito = g.IdGC
                    End Using
                End If
                MgrControl.SelectIndexCombo(cmbGruppoConsigliato, IdInserito)
            End Using
        End If
    End Sub

    Private Sub cmbMacchinarioDef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMacchinarioDef.SelectedIndexChanged
        'seleziono automaticamente la stampa generica

        If cmbMacchinarioDef.SelectedItem Is Nothing Then

        Else

        End If


    End Sub


    Private Sub SelezionaStampa()

        Dim IdLavToSearch As Integer = FormerConst.Lavorazioni.StampaRealizzazione

        Dim ChiavePadre As String = "L" & IdLavToSearch

        For Each N As TreeNode In tvwListLav.Nodes.Find(ChiavePadre, True)(0).Nodes
            If N.Name = ChiavePadre Then
                N.Checked = True
            End If
        Next

    End Sub

    Private Sub btnLavTaglio_Click(sender As Object, e As EventArgs) Handles btnLavTaglio.Click
        Dim IdRif As Integer = cmbTaglioDuplicati.SelectedValue
        If IdRif Then
            Sottofondo()
            Using frmRif As New frmListinoLavorazione
                If frmRif.Carica(IdRif) Then CaricaLavorazioniTaglioDuplicati()
            End Using
            Sottofondo()
        End If
    End Sub

    Private Sub cmbTaglioDuplicati_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTaglioDuplicati.SelectedIndexChanged

        'seleziono in automaticola stessa lavorazione dentro la lista delle lavorazioni
        'Dim IdLavSel As Integer = cmbTaglioDuplicati.SelectedValue
        'Dim IdLavSel As Integer = 0
        'Try
        '    IdLavSel = cmbTaglioDuplicati.SelectedValue
        'Catch ex As Exception

        'End Try

        'If IdLavSel Then
        '    Dim ChiavePadre As String = "L" & IdLavSel
        '    Dim nodo As TreeNode = tvwListLav.Nodes.Find(ChiavePadre, True)(0)

        '    If Not nodo Is Nothing Then
        '        nodo.Checked = True
        '    End If

        'End If



    End Sub

    Private Sub txtNomeInterno_TextChanged(sender As Object, e As EventArgs) Handles txtNomeInterno.TextChanged

    End Sub

    Private Sub txtNome_TextChanged(sender As Object, e As EventArgs) Handles txtNome.TextChanged
        lblTipo.Text = txtNome.Text
    End Sub
End Class