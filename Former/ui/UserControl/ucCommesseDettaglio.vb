Imports FormerLib.FormerEnum
Imports FormerDALSql
Imports FormerLib
Imports FormerConfig
Imports FormerBusinessLogic

Public Class ucCommesseDettaglio
    Inherits ucFormerUserControl

    Private _ComSel As Commessa
    Private _SolaLettura As Boolean

    Public Property SolaLettura() As Boolean
        Get
            Return _SolaLettura
        End Get

        Set(ByVal value As Boolean)

            _SolaLettura = value

            'PreparaControlli()

        End Set
    End Property

    Private Sub CaricaLavInCat()

        'carico la lista delle lavorazioni 

        Using mgr As New LavorazioniDAO

            Dim IdCat As Integer = 0

            If Not tvwCatLavoraz.SelectedNode Is Nothing Then

                If tvwCatLavoraz.SelectedNode.Name.StartsWith("C") Then
                    Dim PosizF As Integer = tvwCatLavoraz.SelectedNode.Name.IndexOf("F")
                    If PosizF <> -1 Then
                        IdCat = tvwCatLavoraz.SelectedNode.Name.Substring(1, PosizF - 1)
                    Else
                        IdCat = tvwCatLavoraz.SelectedNode.Name.Substring(1)
                    End If
                End If

                Dim l As List(Of LavorazioneEx) = mgr.ListaLavorazioni(0, IdCat) ',cmbCategoria.SelectedValue)
                DgLavorazioni.AutoGenerateColumns = False
                DgLavorazioni.DataSource = l

            End If
        End Using

    End Sub

    Private Sub CaricaLavorazioniSelezionate()

        Dim l As New List(Of LavLog)

        For Each ll As LavLog In _ComSel.ListaLavLog
            l.Add(ll)
        Next

        l.Sort(Function(x, y) x.Ordine.CompareTo(y.Ordine))

        DgLavorazioniSel.AutoGenerateColumns = False
        DgLavorazioniSel.DataSource = l

    End Sub

    Friend Function SalvaFile(ByRef Com As Commessa) As Integer

        'devo salvare il file della commessa e i file di tutti gli ordini

        Dim Ris As Integer = 0
        'Try

        '    'salvo le immagini degli ordini

        '    Dim NuovoNomeFile As String = ""
        '    Dim PathCom As String = FormerPath.PathCommesse & Com.IdCom & "\"
        '    FormerHelper.File.CreateLongPath(PathCom) 'creo la cartella della commessa

        '    'NuovoNomeFile = PathCom & Com.IdCom & ".jpg"
        '    'FileCopy(txtFile.Text, NuovoNomeFile)
        '    'Com.FilePath = NuovoNomeFile
        '    'Com.Save()

        '    'qui copio i file delle anteprime degli ordini

        '    Dim I As Integer

        '    For I = 0 To Com.ListaIdOrdini.GetUpperBound(0)
        '        Using Ord As New Ordine
        '            Ord.Read(Com.ListaIdOrdini(I))

        '            If Ord.FilePath.StartsWith(PathCom) = False Then 'copia solo i file che gia non sono li 
        '                'NuovoNomeFile = PathCom & Com.IdCom & "-" & I + 1 & ".jpg"
        '                'MODIFICA EFFETTUATA IL 29 SETTEMBRE 2011 PER EVITARE IL PROBLEMA DI NON VISUALIZZAZIONE ANTEPRIMA
        '                NuovoNomeFile = PathCom & FormerLib.FormerHelper.File.EstraiNomeFile(Ord.FilePath)
        '                'FileCopy(Ord.FilePath, NuovoNomeFile)
        '                MgrIO.FileSposta(Me.ParentForm, Ord.FilePath, NuovoNomeFile)
        '                Ord.FilePath = NuovoNomeFile
        '                Using mO As New OrdiniDAO
        '                    mO.SalvaFile(Ord)
        '                End Using
        '                'qui copio i file dei sorgenti degli ordini

        '                Dim sorg As FileSorgente

        '                For Each sorg In Ord.ListaSorgenti

        '                    'Dim Estensione As String = ""

        '                    'Estensione = sorg.FilePath.Substring(sorg.FilePath.Length - 4)
        '                    Dim NomeFileOriginale As String = FormerLib.FormerHelper.File.EstraiNomeFile(sorg.FilePath)

        '                    Dim Posizione As Integer = NomeFileOriginale.IndexOf("-")

        '                    If Posizione <> -1 AndAlso Posizione < 7 Then
        '                        NomeFileOriginale = NomeFileOriginale.Substring(Posizione + 1)
        '                    End If

        '                    NuovoNomeFile = PathCom & Com.IdCom & "-" & NomeFileOriginale
        '                    'FileCopy(sorg.FilePath, NuovoNomeFile)
        '                    MgrIO.FileSposta(Me.ParentForm, sorg.FilePath, NuovoNomeFile)
        '                    sorg.FilePath = NuovoNomeFile
        '                    sorg.Save()
        '                Next
        '            End If

        '        End Using
        '    Next

        'Catch ex As Exception

        '    Ris = ex.GetHashCode
        '    ManageError(ex)

        'End Try

        Ris = MgrCommesse.SalvaFile(Com)

        Return Ris

    End Function

    Friend Sub RiempiCommessaDaControlli(ByRef Com As Commessa)

        Com.IdCom = _ComSel.IdCom
        Com.CreataAutomaticamente = _ComSel.CreataAutomaticamente
        Com.Stato = _ComSel.Stato
        Com.IdReparto = _ComSel.IdReparto
        Com.ListaIdOrdini = UcOrdiniCom.ListaIdSelezionati

        Com.MovMagaz = UcRisorseCom.ListaMovMagaz

        Com.TipoCom = cmbTipoProd.SelectedValue
        'Com.IdTipoCom = cmbTipoCom.SelectedValue

        Com.IdFormato = cmbFormato.SelectedValue
        Com.FronteRetro = IIf(chkFronteRetro.Checked, enSiNo.Si, enSiNo.No)

        Com.Copie = txtQta.Text
        Com.Segnature = txtSegnature.Text

        Using mgr As New CommesseDAO
            Com.Riassunto = mgr.GetNomeRiassuntivo(Com.ListaIdOrdini)
        End Using

        Dim ModelloCommessa As ModelloCommessa = DirectCast(cmbModelloCommessa.SelectedItem, ModelloCommessa)

        If Com.IdRis = 0 Then
            'Dim IdRis As Integer = 0
            Using mgr As New RisorseDAO

                Dim risLastra As Risorsa = mgr.GetLastraPerMacchinario(ModelloCommessa.IdMacchinarioDef)

                If Not risLastra Is Nothing Then
                    Com.IdRis = risLastra.IdRis
                End If

                'Dim l As List(Of Risorsa) = mgr.FindAll("Giacenza Desc", New LUNA.LunaSearchParameter("IsLastra", enSiNo.Si))
                'For Each singRis As Risorsa In l
                '    If singRis.ListaMacchinari.FindAll(Function(x) x.IdMacchinario = ModelloCommessa.IdMacchinarioDef).Count Then
                '        IdRis = singRis.IdRis
                '        Exit For
                '    End If
                'Next
            End Using
            'Com.IdRis = IdRis
        End If

        Com.NLastreNecessarie = txtNLastre.Text

        Com.Lungo = txtLunghezza.Text
        Com.Largo = txtLarghezza.Text

        'Com.FilePath = txtFile.Text

        Com.Annotazioni = txtNote.Text

        Com.IdModelloCommessa = ModelloCommessa.IdModello
        Com.ModificataListaLav = _ModificataListaLav
        Com.ListaLavLog = _ComSel.ListaLavLog

        If _CommessaProposta Is Nothing Then

            If Com.IdReparto = Com.ListaOrdini()(0).ListinoBase.Preventivazione.IdReparto Then
                Com.MacchinaStampa = ModelloCommessa.MacchinarioNome
                Com.IdMacchinario = ModelloCommessa.IdMacchinarioDef

                If Com.IdReparto <> enRepartoWeb.StampaOffset And Com.IdReparto <> enRepartoWeb.Packaging Then
                    'qui cerco la lavorazione di stampa su che macchinario viene inserita 
                    If Com.ListaOrdini.Count = 1 Then
                        Dim O As Ordine = Com.ListaOrdini()(0)
                        If O.ListinoBase.IdMacchinarioProduzione Then
                            Using m As New Macchinario
                                m.Read(O.ListinoBase.IdMacchinarioProduzione)
                                Com.IdMacchinario = m.IdMacchinario
                                Com.MacchinaStampa = m.Descrizione
                            End Using
                        End If
                    End If
                End If
            End If

        Else
            Com.MacchinaStampa = _CommessaProposta.ModelloCommessa.MacchinarioNome
            Com.IdMacchinario = _CommessaProposta.ModelloCommessa.IdMacchinarioDef
        End If

        Com.SoggettiFoglio = txtSoggFoglio.Text
        Com.SchemaTaglio = txtSchemaTaglio.Text

        If Com.IdCom = 0 Then Com.IdUtCreatore = PostazioneCorrente.UtenteConnesso.IdUt

    End Sub

    Private Sub CaricaFormatiMacchina()
        'FormerDebug.Traccia()
        Using mgr As New FormatiDAO
            Dim l As List(Of Formato) = mgr.GetAll(LFM.Formato.Formato)
            cmbFormato.DataSource = l
            cmbFormato.ValueMember = "IdFormato"
            cmbFormato.DisplayMember = "Formato"
        End Using
        'Using FormatoCommessa As New cFormatoCommessa
        '    cmbFormato.DataSource = FormatoCommessa.Lista
        '    cmbFormato.ValueMember = "IdFormato"
        '    cmbFormato.DisplayMember = "Formato"
        'End Using
    End Sub

    Public Sub CaricaCombo()

        CaricaFormatiMacchina()

        Dim TipoProd As New cTipoProdCom(False)
        cmbTipoProd.DataSource = TipoProd
        cmbTipoProd.ValueMember = "Id"
        cmbTipoProd.DisplayMember = "Descrizione"

        'Using Risorse As New cRisorseColl
        '    cmbImpianti.DataSource = Risorse.ListaComboOffSet(True)
        '    cmbImpianti.ValueMember = "IdRis"
        '    cmbImpianti.DisplayMember = "Descrizione"
        'End Using

        CaricaModelliCommessa()

    End Sub

    Private Sub CaricaRis()

        If cmbTipoProd.SelectedIndex <> -1 Then

            Dim x As Integer = cmbTipoProd.SelectedItem.id

            'Dim Risorse As New cRisorseColl

            'cmbRisorsa.DataSource = Risorse.ListaCombo(x)
            'cmbRisorsa.ValueMember = "IdRis"
            'cmbRisorsa.DisplayMember = "Descrizione
            If _CommessaProposta Is Nothing Then
                If _ComSel.IdReparto = enRepartoWeb.StampaDigitale AndAlso _ComSel.ListaOrdini().Count Then
                    Dim FirstO As Ordine = _ComSel.ListaOrdini()(0)

                    If FirstO.IdTipoProd = enRepartoWeb.StampaOffset Then
                        UcRisorseCom.IdTipoCom = FirstO.IdTipoProd
                    Else
                        UcRisorseCom.IdTipoCom = x
                    End If
                    'UcRisorseCom.IdTipoCom = _ComSel.ListaOrdini()(0).IdTipoProd
                Else
                    UcRisorseCom.IdTipoCom = x
                End If

                UcRisorseCom.CaricaDaCommessa()

                UcOrdiniCom.IdTipoCom = x
                UcOrdiniCom.Carica(_ListaIdOrd)
            Else
                If _CommessaProposta.ModelloCommessa.IdReparto = enRepartoWeb.StampaDigitale AndAlso _CommessaProposta.Ordini.Count Then
                    Dim firstO As OrdineRicerca = _CommessaProposta.Ordini(0).Ordine

                    If firstO.IdTipoProd = enRepartoWeb.StampaOffset Then
                        UcRisorseCom.IdTipoCom = firstO.IdTipoProd
                    Else
                        UcRisorseCom.IdTipoCom = x
                    End If
                Else
                    UcRisorseCom.IdTipoCom = x
                End If

                UcRisorseCom.CaricaDaCommessa()

                UcOrdiniCom.IdTipoCom = _CommessaProposta.Ordini(0).Ordine.IdTipoProd
                UcOrdiniCom.Carica(_ListaIdOrd)
            End If
        End If

    End Sub

    'Friend Sub CaricaEx(Optional Com As Commessa = Nothing, _
    '                  Optional ByVal ListaIdOrd As String = "", _
    '                  Optional ByVal IdTipoCom As Integer = 0)

    '    If Com Is Nothing Then
    '        _CommessaSel = New Commessa
    '    Else
    '        _CommessaSel = Com
    '    End If

    '    CaricaCombo()

    '    PreparaControlli()

    '    UcRisorseCom.IdCom = _ComSel.IdCom

    '    UcOrdiniCom.IdCom = _ComSel.IdCom

    '    If _ComSel.IdCom Then
    '        lnkCTP.Enabled = True

    '        'riapertura

    '        pctPreview.Visible = True

    '        UcOrdiniCom.CaricaxCom()
    '        UcRisorseCom.CaricaxCom()
    '        CaricaCommessa()
    '        CreaRiepilogoCom(_ComSel, webRiepilogo)

    '        If TabCommessa.TabPages.Contains(tbRiepilogo) = False Then
    '            TabCommessa.TabPages.Insert(0, tbRiepilogo)
    '            TabCommessa.SelectedTab = tbRiepilogo
    '        End If
    '        If _ComSel.Stato > enStatoCommessa.Pronto Then DisattivaControlli()
    '        UcAllegati.Carica(_ComSel.IdCom)
    '    Else
    '        Dim LDisp As List(Of Ordine) = Nothing

    '        Using mgr As New OrdiniDAO

    '            LDisp = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", "(" & ListaIdOrd & ")", " IN "), _
    '                                New LUNA.LunaSearchParameter("IdCom", 0), _
    '                                New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Registrato))

    '        End Using

    '        For Each singO As Ordine In LDisp
    '            If singO.Prodotto.FronteRetro Then
    '                chkFronteRetro.Checked = True
    '            End If
    '        Next
    '        txtQta.Text = 100
    '        pctPreview.Visible = False
    '        grpAvanzamento.Visible = False
    '        UcOrdiniCom.CaricaxCom(ListaIdOrd)

    '        'nuovo
    '        TabCommessa.TabPages.Remove(tbRiepilogo)
    '        TabCommessa.TabPages.Remove(tbImmagine)
    '        TabCommessa.TabPages.Remove(tpMessaggi)

    '        If SolaLettura = False Then
    '            TabCommessa.TabPages.Remove(tbLog)
    '        End If

    '        If IdTipoCom Then
    '            MgrControl.SelectIndexCombo(cmbTipoCom, IdTipoCom)
    '            SelectDefaultInBaseATipo()
    '        End If


    '    End If

    'End Sub

    Private Sub CaricaIco()

        lnkPreinserito.Image = MgrIcons.GetIconCommessa(enStatoCommessa.Preinserito)
        lnkInserito.Image = MgrIcons.GetIconCommessa(enStatoCommessa.Pronto)

    End Sub

    Private Sub tvwCat_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwCatLavoraz.AfterSelect

        CaricaLavInCat()

    End Sub

    Private Sub CaricaCat()

        Using C As New CatLavDAO

            tvwCatLavoraz.Nodes.Clear()


            Dim Node As TreeNode = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Tutto, "TUTTO")
            Node.BackColor = Color.White
            Node.ForeColor = Color.Black

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.StampaOffset, "OFFSET")
            Node.BackColor = FormerColori.ColoreRepartoOffset
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.StampaDigitale, "DIGITALE")
            Node.BackColor = FormerColori.ColoreRepartoDigitale
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Packaging, "PACKAGING")
            Node.BackColor = FormerColori.ColoreRepartoPackaging
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Ricamo, "RICAMO")
            Node.BackColor = FormerColori.ColoreRepartoRicamo
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Etichette, "ETICHETTE")
            Node.BackColor = FormerColori.ColoreRepartoEtichette
            Node.ForeColor = Color.White

            tvwCatLavoraz.Nodes.Add("C0", "Senza categoria", 0, 0)

            For Each Cat As CatLav In C.GetAll("OrdineEsecuzione,Descrizione")
                Dim ChiavePadre As String = "C" & Cat.IdCatLav

                Dim ChiaveReparto As String = "R" & Cat.RepartoAppartenenza

                tvwCatLavoraz.Nodes(ChiaveReparto).Nodes.Add(ChiavePadre, Cat.Descrizione, 0, 0)

                'qui devo caricare tutti i singoli formati prodotto che sono linkati in tutte le lavorazioni di questa categoria
                'chiamo un metodo specifico che mi torna una serie di IdFormatoProdotto
                'Using mgr As New FormatiProdottoDAO
                '    For Each IdCl As Integer In mgr.ListaIdFormatoByIdCatLav(Cat.IdCatLav)
                '        Dim ChiaveNodo As String = ChiavePadre & "F" & IdCl
                '        Dim TextNodo As String = String.Empty
                '        If IdCl Then
                '            Dim fp As New FormatoProdotto
                '            fp.Read(IdCl)
                '            TextNodo = fp.Formato
                '        Else
                '            TextNodo = " * - Tutti i formati"
                '        End If
                '        tvwCatLavoraz.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes.Add(ChiaveNodo, TextNodo, 1, 1)

                '        Using mgrL As New LavorazioniDAO
                '            For Each IdL As Integer In mgrL.ListaIdLavorazioniByFormatoProdotto(IdCl, Cat.IdCatLav)
                '                Dim ChiaveNodoL As String = ChiaveNodo & "L" & IdL
                '                Dim TextNodoL As String = String.Empty

                '                Dim L As New Lavorazione
                '                L.Read(IdL)
                '                TextNodo = L.Sigla & " - " & L.Descrizione

                '                tvwCatLavoraz.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes(ChiaveNodo).Nodes.Add(ChiaveNodoL, TextNodo, 2, 2)

                '            Next
                '        End Using



                '    Next
                'End Using

            Next

            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Tutto).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.StampaOffset).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.StampaDigitale).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Ricamo).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Packaging).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Etichette).Expand()

        End Using

    End Sub

    Private _ListaIdOrd As String = String.Empty

    Private _CommessaProposta As CommessaProposta = Nothing

    Friend Sub Carica(Optional ByVal ComSel As Commessa = Nothing,
                      Optional ByVal ListaIdOrd As String = "",
                      Optional CommessaProposta As CommessaProposta = Nothing)

        _CommessaProposta = CommessaProposta

        _ListaIdOrd = ListaIdOrd
        'FormerDebug.Traccia()
        If ComSel Is Nothing Then
            _ComSel = New Commessa
            If Not CommessaProposta Is Nothing Then
                _ComSel.IdReparto = CommessaProposta.ModelloCommessa.IdReparto
            End If
        Else
            _ComSel = ComSel
        End If

        UcRisorseCom.IdCom = _ComSel.IdCom

        If Not CommessaProposta Is Nothing Then
            UcRisorseCom.IdTipoCartaToShow = CommessaProposta.Ordini(0).IDTipoCartaRif
        Else
            If _ComSel.IdCom Then

                UcRisorseCom.IdTipoCartaToShow = _ComSel.ListaOrdini()(0).ListinoBase.IdTipoCarta

                'Dim l As DataTable
                'Using mgr As New cRisorseColl
                '    l = mgr.ListaComSel(_ComSel.IdCom, _ComSel.IdReparto)

                '    If l.Rows.Count Then
                '        UcRisorseCom.IdTipoCartaToShow = l.Rows(0)("IdTipoCarta")
                '    End If

                'End Using

            End If
        End If

        CaricaIco()

        CaricaCombo()
        CaricaCat()
        PreparaControlli()

        UcOrdiniCom.IdCom = _ComSel.IdCom
        UcOrdiniCom.RepartoCom = _ComSel.IdReparto
        UcOrdiniCom.Carica(_ListaIdOrd)

        If _ComSel.IdCom Then
            lnkCTP.Enabled = True

            'riapertura

            pctPreview.Visible = True

            CaricaRisorseDefault()
            'CalcolaSoggetti()
            AggiornaQtaNeces()
            UcRisorseCom.CaricaDaCommessa()

            CaricaCommessa()
            '    UcOrdiniCom.CaricaxCom()

            CaricaLavorazioniSelezionate()

            MgrAnteprime.CreaRiepilogoCom(_ComSel, webRiepilogo)

            If TabCommessa.TabPages.Contains(tbRiepilogo) = False Then
                TabCommessa.TabPages.Insert(0, tbRiepilogo)
                TabCommessa.SelectedTab = tbRiepilogo
            End If
            If _ComSel.Stato > enStatoCommessa.Pronto Then DisattivaControlli()
            UcAllegati.Carica(_ComSel.IdCom)
            If _ComSel.IdModelloCommessa Then
                MgrControl.SelectIndexCombo(cmbModelloCommessa, _ComSel.IdModelloCommessa)

            End If

            SelezionaDefaultInBaseAModello()
            txtNLastre.Text = _ComSel.NLastreNecessarie
            txtSegnature.Text = _ComSel.Segnature
            MgrControl.SelectIndexCombo(cmbFormato, _ComSel.IdFormato)



            If Not _ComSel.LavLogRealizzazione Is Nothing AndAlso _ComSel.LavLogRealizzazione.IdMacchinario <> _ComSel.IdMacchinario Then
                Using M As New Macchinario
                    M.Read(_ComSel.LavLogRealizzazione.IdMacchinario)
                    lblMacchinario.Text = M.Descrizione
                End Using
            Else
                lblMacchinario.Text = _ComSel.MacchinaStampa
            End If

        Else

            If ListaIdOrd.Length Then
                Dim LDisp As List(Of Ordine) = Nothing

                Using mgr As New OrdiniDAO

                    LDisp = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "(" & ListaIdOrd & ")", " IN "),
                                        New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, 0),
                                        New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Registrato))

                End Using

                Dim NoteGenerali As String = String.Empty

                For Each singO As Ordine In LDisp
                    If singO.Annotazioni.Length Then
                        NoteGenerali &= "Ordine: " & singO.IdOrd & " - " & singO.Annotazioni & ";" & ControlChars.NewLine
                    End If
                    If singO.ListinoBase.ColoreStampa.FR Then
                        chkFronteRetro.Checked = True
                    End If
                Next

                If NoteGenerali.Length Then txtNote.Text = NoteGenerali

            End If

            Dim Tiratura As Integer = 100
            If Not CommessaProposta Is Nothing Then

                Tiratura = CommessaProposta.TiraturaEffettiva
                MgrControl.SelectIndexCombo(cmbModelloCommessa, CommessaProposta.ModelloCommessa.IdModello)
                MgrControl.SelectIndexCombo(cmbTipoProd, CommessaProposta.ModelloCommessa.IdReparto)
                'If CommessaProposta.ModelloCommessa.FRSuSeStessa Then
                '    Tiratura = Tiratura / 2
                'End If

            End If

            txtQta.Text = Tiratura

            pctPreview.Visible = False
            grpAvanzamento.Visible = False

            'nuovo
            TabCommessa.TabPages.Remove(tbRiepilogo)
            TabCommessa.TabPages.Remove(tbImmagine)
            TabCommessa.TabPages.Remove(tpMessaggi)

            If SolaLettura = False Then
                TabCommessa.TabPages.Remove(tbLog)
            End If

            SelezionaDefaultInBaseAModello()
            'qui vado a caricare le risorse predefinite per gli ordini che sono stati inseriti            

            If Not CommessaProposta Is Nothing Then
                lblMacchinario.Text = CommessaProposta.ModelloCommessa.MacchinarioNome
            End If

            CaricaRisorseDefault()
            CalcolaSoggetti()
            AggiornaQtaNeces()
            CalcolaTotali()

        End If

        lblReparto.BackColor = FormerColori.GetColoreReparto(_ComSel.IdReparto)
        lblReparto.Text = FormerEnumHelper.RepartoStr(_ComSel.IdReparto)
        If _ComSel.IdReparto <> enRepartoWeb.Ricamo Then
            lblReparto.ForeColor = Color.White
        End If

        'If ApriAutoExportCTP Then
        '    ExportCTP()
        'End If

    End Sub

    Private Sub CaricaRisorseDefault()

        Dim ListaIdOrdini As Integer() = UcOrdiniCom.ListaIdSelezionati

        Dim Ris As List(Of Risorsa) = Nothing

        Using mgr As New CommesseDAO
            Ris = mgr.GetRisorsaDefault(ListaIdOrdini, cmbModelloCommessa.SelectedItem)
        End Using

        UcRisorseCom.AddRisPredef(Ris)

        'Dim ListaIdOrdStr As String = String.Empty

        'For Each SingId In ListaIdOrdini
        '    ListaIdOrdStr &= SingId & ","
        'Next

        'ListaIdOrdStr = ListaIdOrdStr.TrimEnd(",")

        'Dim TipoCartaTrovata As New List(Of TipoCarta)

        'If ListaIdOrdStr.Length Then
        '    Dim LDisp As List(Of Ordine) = Nothing

        '    Using mgr As New OrdiniDAO
        '        LDisp = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", "(" & ListaIdOrdStr & ")", " IN "),
        '                            New LUNA.LunaSearchParameter("IdCom", 0),
        '                            New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Registrato))

        '    End Using

        '    For Each singO As Ordine In LDisp
        '        If TipoCartaTrovata.FindAll(Function(x) x.IdTipoCarta = singO.Prodotto.ListinoBase.IdTipoCarta).Count = 0 Then
        '            TipoCartaTrovata.Add(singO.Prodotto.ListinoBase.TipoCarta)
        '        End If
        '    Next
        'End If

        'If TipoCartaTrovata.Count Then
        '    'qui posso tirare fuori la risorsa predefinita 
        '    If TipoCartaTrovata.Count = 1 Then
        '        'TODO:QUI VA AGGIUNTO IL CONTROLLO SULLA GIACENZA
        '        Dim tc As TipoCarta = TipoCartaTrovata(0)
        '        Using mgr As New RisorseDAO
        '            Dim l As List(Of Risorsa) = mgr.FindAll(New LUNA.LunaSearchParameter("IdTipoCarta", tc.IdTipoCarta))
        '            If l.Count Then
        '                UcRisorseCom.AddRisPredef(l(0))
        '            End If
        '        End Using
        '    Else
        '        'QUI IN TEORIA NON DEVE MAI ENTRARE POI VEDIAMO PER ORA NON FACCIO NIENTE

        '    End If

        'End If

        'CalcolaQtaNeces()

    End Sub

    Private Sub AttivaControlli()
        'lnkNewCli.Visible = True

        'cmbTipoCom.Enabled = True
        cmbTipoProd.Enabled = True

        btnScegliFile.Visible = True

        txtNote.ReadOnly = False

        UcOrdiniCom.SolaLettura = False
        UcRisorseCom.Enabled = True

        lnkAnnulla.Enabled = True


        txtSegnature.Enabled = True
        'txtSoggFoglio.Enabled = True

    End Sub

    Private Sub DisattivaControlli()

        'mette in sola lettura il componente
        'lnkNewCli.Visible = False

        'cmbTipoCom.Enabled = False
        'cmbTipoCom.BackColor = Color.White
        'cmbTipoCom.ForeColor = Color.Black
        cmbTipoProd.Enabled = False
        cmbTipoProd.BackColor = Color.White
        cmbTipoProd.ForeColor = Color.Black

        cmbFormato.Enabled = False
        txtNLastre.Enabled = False
        chkFronteRetro.Enabled = False
        txtQta.Enabled = False

        txtLunghezza.ReadOnly = True
        txtLunghezza.BackColor = Color.White
        txtLarghezza.ReadOnly = True
        txtLarghezza.BackColor = Color.White

        btnScegliFile.Visible = False

        txtNote.ReadOnly = True
        txtNote.BackColor = Color.White

        pctSblocco.Visible = True

        UcOrdiniCom.SolaLettura = True
        UcRisorseCom.Enabled = False

        lnkAnnulla.Enabled = False

        txtSegnature.Enabled = False
        'txtSoggFoglio.Enabled = False

    End Sub

    Private Sub PreparaControlli()
        'FormerDebug.Traccia()
        If _SolaLettura Then

            DisattivaControlli()
            If Not _ComSel Is Nothing Then
                If _ComSel.IdCom Then
                    Select Case _ComSel.Stato
                        Case enStatoCommessa.Preinserito
                            lnkPreinserito.Enabled = False
                            lnkInserito.Enabled = True


                        Case enStatoCommessa.Pronto

                            lnkPreinserito.Enabled = True
                            lnkInserito.Enabled = False

                    End Select
                End If
            End If

        Else
            If _ComSel Is Nothing Then
                DisattivaControlli()
            Else

                Select Case _ComSel.Stato
                    Case enStatoCommessa.Preinserito
                        lnkPreinserito.Enabled = False
                        lnkInserito.Enabled = True
                        AttivaControlli()
                    Case enStatoCommessa.Pronto

                        lnkPreinserito.Enabled = True
                        lnkInserito.Enabled = False
                        DisattivaControlli()

                End Select

            End If

        End If

    End Sub

    Private Sub CaricaCronologico()
        'FormerDebug.Traccia()
        DGCrono.DataSource = Nothing
        If Not _ComSel Is Nothing Then

            If _ComSel.IdCom Then
                Using M As New CommesseDAO
                    DGCrono.DataSource = M.AvanzamentoLavori(_ComSel)
                End Using
            End If
        End If

    End Sub

    Private Sub TabCommessa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCommessa.SelectedIndexChanged

        Select Case TabCommessa.SelectedIndex
            Case 2 'tblog
                CaricaCronologico()
            Case 4 ' riepilogo commessa
                MgrAnteprime.CreaRiepilogoCom(_ComSel, webRiepilogo)
        End Select


    End Sub

    Private Sub CaricaCommessa()
        'FormerDebug.Traccia()



        If _ComSel.IdCom Then

            txtComCod.Text = _ComSel.IdCom
            txtStato.Text = _ComSel.StatoStr
            txtStato.BackColor = _ComSel.Colore
            ' MgrControl.SelectIndexCombo(cmbTipoCom, _ComSel.IdTipoCom)
            MgrControl.SelectIndexCombo(cmbTipoProd, _ComSel.TipoCom)

            chkFronteRetro.Checked = IIf(_ComSel.FronteRetro = enSiNo.Si, True, False)

            MgrControl.SelectIndexCombo(cmbFormato, _ComSel.IdFormato)
            txtLarghezza.Text = _ComSel.Largo
            txtLunghezza.Text = _ComSel.Lungo
            txtNLastre.Text = _ComSel.NLastreNecessarie
            txtQta.Text = _ComSel.Copie

            txtSegnature.Text = _ComSel.Segnature

            txtFile.Text = FormerPathCreator.GetAnteprima(_ComSel)
            txtNote.Text = _ComSel.Annotazioni
            CaricaFile(FormerPathCreator.GetAnteprima(_ComSel))

            If _ComSel.CreataAutomaticamente = enSiNo.Si Then
                lblCreataAutomatico.Visible = True
            End If

            lblMacchinario.Text = _ComSel.MacchinaStampa



            txtSoggFoglio.Text = _ComSel.SoggettiFoglio
            txtSchemaTaglio.Text = _ComSel.SchemaTaglio

            If _ComSel.IdRis Then
                Using r As New Risorsa
                    r.Read(_ComSel.IdRis)
                    lblLastre.Text = r.Descrizione
                End Using
            End If
            AggiornaQtaNeces()
            'txtQta.Refresh()
        Else

            txtComCod.Text = ""

        End If

        CaricaCronologico()

    End Sub

    Private Sub CaricaFile(ByVal Path As String)

        Try
            pctMain.Load(Path)
            pctPreview.Load(Path)

        Catch ex As Exception
            pctMain.Image = Nothing
            pctPreview.Image = Nothing

        End Try

        pctMain.Left = 0
        pctMain.Top = 0

        VScrollBar.SmallChange = 1
        VScrollBar.LargeChange = 100

        Dim DiffV As Integer

        DiffV = pctMain.Height - MainPanel.Height
        If DiffV < 0 Then DiffV = 0

        VScrollBar.Minimum = 0
        VScrollBar.Maximum = DiffV

        HScrollBar.SmallChange = 1
        HScrollBar.LargeChange = 100

        Dim DiffH As Integer = 0

        DiffH = pctMain.Width - MainPanel.Width

        If DiffH < 0 Then DiffH = 0

        HScrollBar.Minimum = 0
        HScrollBar.Maximum = DiffH

    End Sub

    Private Sub VScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar.Scroll
        pctMain.Top = -VScrollBar.Value
    End Sub

    Private Sub HScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar.Scroll
        pctMain.Left = -HScrollBar.Value
    End Sub

    Private Sub lnkOpenFile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOpenFile.LinkClicked

        If txtFile.TextLength Then
            Try

                Dim PathMOd As String = txtFile.Text

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If

    End Sub

    Private Sub btnScegliFile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnScegliFile.LinkClicked




        OpenImg.ShowDialog()

        If OpenImg.FileName.Length Then
            'qui ha scelto un file
            CaricaFile(OpenImg.FileName)
            txtFile.Text = OpenImg.FileName

        End If

    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoProd.SelectedIndexChanged

        AbilitaControlli()

        CaricaRis()
        'CaricaTipoCommesse()
        CalcolaQtaNeces()

    End Sub

    Private Sub AbilitaControlli()

        pnlDigitale.Left = pnlOffSet.Left

        If cmbTipoProd.SelectedIndex <> -1 Then

            Dim x As enRepartoWeb

            x = cmbTipoProd.SelectedItem.id

            Select Case x

                Case enRepartoWeb.StampaDigitale

                    lblLunghezza.Visible = True
                    lblLarghezza.Visible = True
                    txtLunghezza.Visible = True
                    txtLarghezza.Visible = True
                    pnlDigitale.Visible = True
                    pnlOffSet.Visible = False

                Case enRepartoWeb.StampaOffset

                    lblLunghezza.Visible = False
                    lblLarghezza.Visible = False
                    txtLunghezza.Visible = False
                    txtLarghezza.Visible = False
                    pnlDigitale.Visible = False
                    pnlOffSet.Visible = True

            End Select

            cmbFormato.Enabled = True
            txtNLastre.Enabled = True
            chkFronteRetro.Enabled = True
            txtQta.Enabled = True

        End If

    End Sub

    Private Sub CaricaModelliCommessa()
        Using mgr As New ModelliCommessaDAO

            Dim p As New LUNA.LunaSearchParameter(LFM.ModelloCommessa.IdReparto, _ComSel.IdReparto)

            Dim p2 As LUNA.LunaSearchParameter = Nothing

            If _ComSel.IdCom = 0 Then
                p2 = New LUNA.LunaSearchParameter(LFM.ModelloCommessa.FromGanging, enSiNo.Si, "<>")
            End If

            cmbModelloCommessa.DataSource = mgr.FindAll(LFM.ModelloCommessa.Nome, p, p2)
            cmbModelloCommessa.DisplayMember = "Text"
            cmbModelloCommessa.ValueMember = "Id"
        End Using
    End Sub

    'Private Sub SelectDefaultInBaseATipo()

    '    ''seleziona la risorsa predefinita per quel tipo di commessa
    '    If cmbTipoCom.SelectedIndex <> -1 Then

    '        Dim x As New TipoCommessa
    '        x.Read(cmbTipoCom.SelectedValue)
    '        'qui ho la commessa , carico i default in base al tipocommessa

    '        'chkFronteRetro.Checked = x.FronteRetro
    '        ' If txtQta.SelectedIndex <> 0 Then txtQta.Text = x.Quantita

    '        If cmbTipoProd.SelectedIndex <> -1 Then

    '            Dim tip As enRepartoWeb

    '            tip = cmbTipoProd.SelectedItem.id
    '            'CaricaModelliCommessa(x.IdCatModelli)
    '            If tip = enRepartoWeb.StampaOffset Then

    '                MgrControl.SelectIndexCombo(cmbFormato, x.IdFormato)

    '            End If

    '        End If

    '        'qui carico la risorsa predefinita e la seleziono in automatico se si tratta di una commessa in stato preinserito
    '        If _ComSel.Stato = enStatoCommessa.Preinserito And _SolaLettura = False Then

    '            Dim rispre As New Risorsa

    '            rispre.Read(x.IdRis)

    '            UcRisorseCom.AddRisPredef(rispre)

    '            rispre = Nothing


    '            'pulisco la lista delle risorse selezionate e aggiungo la predefinita


    '        End If



    '    End If

    'End Sub

    'Private Sub ApriTipoCom(Optional ByVal IdTipoCom As Integer = 0)

    '    ParentFormerForm.Sottofondo 

    '    Dim x As New frmCommessaTipo, Ris As Integer

    '    Ris = x.Carica(IdTipoCom)

    '    If Ris Then CaricaTipoCommesse()
    '    x = Nothing

    '    ParentFormerForm.Sottofondo 

    'End Sub

    'Private Sub CaricaTipoCommesse()

    '    If cmbTipoProd.SelectedIndex <> -1 Then
    '        Using TipoCom As New cTipoCommessaColl
    '            cmbTipoCom.ValueMember = "IdTipoCom"
    '            cmbTipoCom.DisplayMember = "Descrizione"


    '            Dim x As Integer = cmbTipoProd.SelectedItem.id


    '            cmbTipoCom.DataSource = TipoCom.ListaCombo(x)
    '        End Using
    '    End If

    'End Sub

    Private Sub CalcolaTotali()
        AggiornaQtaNeces()
    End Sub

    Private Sub ApriRis(Optional ByVal IdRis As Integer = 0)

        Dim frmRif As New frmMagazzinoRisorsa
        Dim ObjRif As New Risorsa
        Dim Ris As Integer = 0

        ParentFormEx.Sottofondo()

        If IdRis Then ObjRif.Read(IdRis)

        Ris = frmRif.Carica(ObjRif)
        ParentFormEx.Sottofondo()

        If Ris Then
            'aggiorno la combo
            CaricaRis()
        End If

        frmRif.Dispose()
        ObjRif = Nothing

    End Sub

    Private Sub lnkNewProd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        ApriRis()
    End Sub

    Private Sub txtQta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtSconto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MgrControl.ControlloNumerico(sender, e)
    End Sub

    Private Sub txtLarghezza_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.text.length = 0 Then
            sender.text = "0"
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ' TabCommessa.TabPages.Remove(tbNote)
        'SplitContainerImg.DefaultWidth = 150
        lnkPreinserito.BackColor = FormerColori.ColoreStatoCommessaPreinserito
        lnkInserito.BackColor = FormerColori.ColoreStatoCommessaPronto

    End Sub

    Public Event CambioStato()

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        If _ComSel.IdCom Then

            ParentFormEx.Sottofondo()

            'Dim PathMOd As String = webRiepilogo.Url.ToString 'FormerPath.PathLocale & "riepCom.htm"

            Using x As New frmStampa

                x.Carica(webRiepilogo)

            End Using

            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub txtLarghezza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLarghezza.KeyPress, txtLunghezza.KeyPress
        MgrControl.ControlloNumerico(sender, e, True)
    End Sub

    Private Sub txtLarghezza_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLarghezza.TextChanged, txtLunghezza.TextChanged
        AggMQ()
        If sender.focus Then AggiornaQtaNeces()
    End Sub

    Private Sub AggMQ()

        Try
            Dim x As Single = txtLarghezza.Text
            Dim y As Single = txtLunghezza.Text
            Dim Tot As Single

            If x <> 0 And y <> 0 Then

                Tot = (x * y) / 10000
            Else
                Tot = 0
            End If
            lblMQ.Text = "MQ: " & Tot

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtQta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQta.TextChanged
        ' If sender.focus Then
        'ControlloMinUno(sender)
        If sender.focus Then AggiornaQtaNeces()
        ' End If
    End Sub

    Private Sub AggiornaQtaNeces(Optional UpdateRis As Boolean = True)

        'If _SolaLettura = False Then
        If Not _ComSel Is Nothing Then
            'If _ComSel.Stato <= enStatoCommessa.Preinserito Then

            Dim Qta As Double = CalcolaQtaNeces()

            UcRisorseCom.SetQtaNeces(Qta, UpdateRis)

            'End If
        End If

        'End If

    End Sub

    'Private Function CalcolaQtaNeces() As Single

    '    Dim QtaNeces As Single = 0

    '    Using mgr As New CommesseDAO
    '        QtaNeces = mgr.CalcolaQtaRisorsaNecessaria()
    '    End Using

    '    If cmbTipoProd.SelectedIndex <> -1 Then

    '        Dim tip As enRepartoWeb

    '        tip = cmbTipoProd.SelectedItem.id

    '        If tip = enRepartoWeb.StampaOffset Then
    '            Dim qtaStampa As Single = 1
    '            If txtQta.Text.Length Then
    '                Try
    '                    qtaStampa = txtQta.Text
    '                Catch ex As Exception

    '                End Try

    '            End If

    '            Dim DivFoglio As Single = 1
    '            Dim form As New cFormatoCommessa

    '            If cmbFormato.SelectedIndex <> -1 Then

    '                Dim IdFormato As Integer = 0

    '                IdFormato = cmbFormato.SelectedValue

    '                form.Read(IdFormato)
    '                DivFoglio = form.DivisioneFoglio

    '            End If

    '            QtaNeces = qtaStampa / DivFoglio

    '        Else

    '            QtaNeces = txtQta.Text

    '        End If

    '    End If

    '    'UcRisorseCom.QtaNeces = QtaNeces
    '    'UcRisorseCom.QtaNeces = QtaNeces

    '    Return Math.Ceiling(QtaNeces)

    'End Function

    Private Function CalcolaQtaNeces() As Single

        Dim QtaNeces As Single = 0

        If cmbTipoProd.SelectedIndex <> -1 Then

            Dim tip As enRepartoWeb
            Dim IdFormato As Integer = 0
            Dim QtaRif As Integer = 0

            If txtQta.Text.Length Then
                QtaRif = txtQta.Text
            End If
            tip = cmbTipoProd.SelectedItem.id
            If cmbFormato.SelectedIndex <> -1 Then
                IdFormato = cmbFormato.SelectedValue
            End If

            Using mgr As New CommesseDAO
                Dim RisorsaPredef As Risorsa = Nothing

                Dim L As List(Of Risorsa) = Nothing

                L = UcRisorseCom.RisorseSelezionate

                If L.Count = 0 Then
                    L = mgr.GetRisorsaDefault(UcOrdiniCom.ListaIdSelezionati,
                                             cmbModelloCommessa.SelectedItem,
                                             IIf(_ComSel.IdCom, False, True))
                    If L.Count > 1 Then
                        UcRisorseCom.CartaComposta = True
                    Else
                        UcRisorseCom.CartaComposta = False
                    End If

                End If

                If L.Count Then RisorsaPredef = L(0)

                Dim NumSoggetti As Integer = 1

                Try
                    NumSoggetti = CalcolaSoggetti(RisorsaPredef) 'txtSoggFoglio.Text
                Catch ex As Exception

                End Try

                If Not RisorsaPredef Is Nothing Then
                    'Dim qtaNeces As Single = QtaComm
                    QtaNeces = QtaRif


                    If _ComSel.IdReparto = enRepartoWeb.StampaDigitale Then

                        Using O As Ordine = _ComSel.ListaOrdini()(0)
                            If O.ListinoBase.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse
                               O.ListinoBase.FormatoProdotto.IsRotolo = enSiNo.Si Then
                                'qui invece devo sviluppare i metri quadri 
                                '_ComSel.Copie = QtaNeces
                                '_ComSel.Largo = txtLarghezza.Text
                                '_ComSel.Lungo = txtLunghezza.Text

                                If RisorsaPredef.IdUnitaMisura = enUnitaDiMisura.m2 Then ' OrElse O.ListinoBase.FormatoProdotto.IsRotolo = enSiNo.Si Then
                                    'qui non cambia niente, lo mantengo per ricordarmelo
                                    'Else
                                    QtaNeces = FormerBusinessLogicInterface.MgrCalcoliTecnici.CalcolaMq(O.ListinoBase.FormatoProdotto.FormatoCarta.Larghezza,
                                                                       QtaNeces,
                                                                       txtLunghezza.Text,' O.Lungo,
                                                                       txtLarghezza.Text).AreaCalcolata 'O.Largo) 'o.qta
                                Else
                                    QtaNeces = MgrMagazzino.GetQtaScarico(_ComSel, RisorsaPredef, QtaNeces, txtLunghezza.Text, txtLarghezza.Text)
                                End If

                            End If
                        End Using

                    Else

                        QtaNeces = QtaRif / NumSoggetti
                        QtaNeces = mgr.CalcolaQtaRisorsaNecessaria(tip,
                                                                   IdFormato,
                                                                   QtaRif,
                                                                   RisorsaPredef.IdRis)
                    End If

                Else
                    QtaNeces = QtaRif
                End If
            End Using

            If UcRisorseCom.RisorseSelezionate.Count = 0 And QtaNeces = 0 Then
                QtaNeces = QtaRif
            End If
        End If

        If Single.IsInfinity(QtaNeces) Then
            QtaNeces = 1
        End If

        Return QtaNeces

    End Function

    Private Function CalcolaSoggetti(Optional RisorsaPredefinita As Risorsa = Nothing) As Integer
        Dim Ris As Integer = 0
        'qui calcolo i soggetti sul foglio
        Dim TotSoggetti As Integer = 1
        If Not cmbFormato.SelectedItem Is Nothing Then
            Dim F As Formato = cmbFormato.SelectedItem
            Dim R As Risorsa = Nothing

            If Not RisorsaPredefinita Is Nothing Then
                R = RisorsaPredefinita
            Else
                Dim listaRis As List(Of Risorsa) = UcRisorseCom.RisorseSelezionate

                If listaRis.Count Then
                    R = listaRis(0)
                End If

            End If

            If Not R Is Nothing Then
                Using Mgr As New RisorseDAO

                    If _ComSel.IdReparto = enRepartoWeb.StampaDigitale Then
                        Dim FFly As New Formato

                        FFly.Larghezza = _ComSel.Largo
                        FFly.Altezza = _ComSel.Lungo


                        TotSoggetti = Mgr.GetSoggetti(FFly, R)
                    Else
                        TotSoggetti = Mgr.GetSoggetti(F, R)
                    End If


                End Using
            End If



            'If listaRis.Count Then
            '    Dim R As Risorsa = listaRis(0)

            '    Dim TotVerticale As Integer = 0
            '    Dim TotOrizzontale As Integer = 0

            '    Dim Colonne As Integer = 0
            '    Dim Righe As Integer = 0

            '    Colonne = Math.Floor(R.Larghezza / F.Larghezza)
            '    Righe = Math.Floor(R.Lunghezza / F.Altezza)

            '    If Colonne > 0 And Righe > 0 Then
            '        TotOrizzontale = Colonne * Righe
            '    End If

            '    Colonne = Math.Floor(R.Larghezza / F.Altezza)
            '    Righe = Math.Floor(R.Lunghezza / F.Larghezza)

            '    If Colonne > 0 And Righe > 0 Then
            '        TotVerticale = Colonne * Righe
            '    End If

            '    If TotOrizzontale > TotVerticale Then
            '        TotSoggetti = TotOrizzontale
            '    Else
            '        TotSoggetti = TotVerticale
            '    End If

            'End If



            'Dim IdForm As Integer = cmbFormato.SelectedValue

            'Using f As New Formato
            '    f.Read(IdForm)

            '    Dim QtaNeces As Integer = 1

            '    'Dim Ris As Risorsa = UcRisorseCom.DgRisorseSelezionate




            '    UcRisorseCom.QtaNeces = QtaNeces

            'End Using

        End If

            'If TotSoggetti = 0 Then TotSoggetti = 1

            Ris = TotSoggetti
        txtSoggFoglio.Text = Ris

        Return Ris

    End Function


    Private Sub cmbFormato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormato.SelectedIndexChanged
        If Not cmbFormato.SelectedItem Is Nothing Then
            Dim F As Formato = cmbFormato.SelectedItem
            UcRisorseCom.Formato = F
        End If

        CalcolaSoggetti()
        If sender.focused Then AggiornaQtaNeces()

    End Sub

    Private Sub lnkPreinserito_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPreinserito.LinkClicked
        If MessageBox.Show("Confermi il cambiamento di stato della commessa?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Using mC As New CommesseDAO
                mC.InserisciLog(_ComSel, enStatoCommessa.Preinserito, PostazioneCorrente.UtenteConnesso.IdUt)
            End Using
            CaricaCronologico()
            PreparaControlli()
            RaiseEvent CambioStato()
        End If
    End Sub

    Private Sub lnkInserito_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkInserito.LinkClicked

        Dim OkMovMagaz As Boolean = False

        _ComSel.CaricaMovimentiMagazzino()

        If _ComSel.IdReparto <> enRepartoWeb.Ricamo Then
            If _ComSel.MovMagaz.Count Then
                OkMovMagaz = True
            End If
        Else
            OkMovMagaz = True
        End If

        If OkMovMagaz Then
            If MessageBox.Show("Confermi il cambiamento di stato della commessa?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mC As New CommesseDAO
                    mC.InserisciLog(_ComSel, enStatoCommessa.Pronto, PostazioneCorrente.UtenteConnesso.IdUt)
                End Using
                'qui se per caso e' la prima volta che la commessa passa a pronta devo mandare la mail confermando tutti gli ordini inseriti all'interno

                'TOLTO PER NON MANDARE PIU LA MAIL ALLA PRESA IN CARICO
                'Using mgr As New CronoCommesseDAO
                '    Dim l As List(Of CronoCommessa) = mgr.FindAll(New LUNA.LunaSearchParameter("IdCom", _ComSel.IdCom),
                '                                                      New LUNA.LunaSearchParameter("IdStato", enStatoCommessa.Pronto))
                '    If l.Count = 1 Then
                '        'qui posso mandare la mail di conferma dei lavori, e' la prima volta che passa a pronta la commessa
                '        For Each SingOrd As Ordine In _ComSel.ListaOrdini
                '            SingOrd.InviaMailPresoInCarico()
                '        Next
                '    End If
                'End Using

                CaricaCronologico()
                PreparaControlli()
                RaiseEvent CambioStato()

                'qui vedo se mandare in stampa diretta il modello commessa pdf

                Dim M As ModelloCommessa = DirectCast(cmbModelloCommessa.SelectedItem, ModelloCommessa)

                Dim IdModelloCommessa As Integer = M.IdModello

                If M.IdReparto = enRepartoWeb.StampaOffset Then

                    If FormerHelper.Printer.IsInstalled(FConfiguration.Printer.InfoLavori) Then
                        If _ComSel.SchemaTaglio.Length Then
                            'qui stampo in automatico lo schemna di taglio sulal stampante indicata 
                            MgrPDF.StampaPDF(_ComSel.SchemaTaglio, FConfiguration.Printer.InfoLavori)

                        Else
                            M.CaricaFormatiCarta()
                            If M.FormatiCarta.Count > 1 Then
                                'qui mando in stampa diretta il modello commessa PDF

                                MgrPDF.StampaPDF(M.PDF, FConfiguration.Printer.InfoLavori)

                            End If

                        End If
                    Else
                        MessageBox.Show("La stampante '" & FConfiguration.Printer.InfoLavori & "' per la stampa automatica di schemi di taglio e modelli commessa non risulta installata!")
                    End If

                End If

            End If
        Else
            MessageBox.Show("Per mandare avanti una commessa devono essere selezionate le risorse da utilizzare")
        End If



    End Sub

    Private Sub lnkOpenFolder_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOpenFolder.LinkClicked
        'apro il path delle immagini

        If txtFile.TextLength Then
            Try

                Dim PathMOd As String = FormerLib.FormerHelper.File.GetFolder(txtFile.Text)

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If

    End Sub

    Private Sub ExportCTP()
        'Dim collOrd As New cCTPOrdini
        ''carico la lista di ordini in base agli ordini presenti nella commessa

        'collOrd.IdCom = _ComSel.IdCom
        'collOrd.CopieDiStampa = _ComSel.Copie
        'Dim dr As DataGridViewRow
        'Dim M As New ModelloCommessa

        'M.Read(_ComSel.IdModelloCommessa)

        'For Each dr In UcOrdiniCom.DGOrdiniSel.Rows
        '    Dim Ord As New cCTPOrdine
        '    Ord.IdOrd = dr.Cells(0).Value

        '    Using o As New Ordine
        '        o.Read(Ord.IdOrd)
        '        Ord.Duplicati = Math.Ceiling(o.Prodotto.NumPezzi / collOrd.CopieDiStampa)

        '        If M.FRSuSeStessa = enSiNo.Si Then
        '            Ord.Duplicati /= 2
        '        End If

        '        If o.IdListinoBase Then
        '            Dim FormatoTrovato As ModComFormProd = M.FormatiProdotto.Find(Function(x) x.IdFormProd = o.ListinoBase.IdFormProd)

        '            If FormatoTrovato Is Nothing Then
        '                'prvo con il formato carta
        '                FormatoTrovato = M.FormatiProdotto.Find(Function(x) x.FormatoProdotto.IdFormCarta = o.ListinoBase.FormatoProdotto.IdFormCarta)
        '            End If
        '            If Not FormatoTrovato Is Nothing Then
        '                Ord.OrdinamentoDaFormato = FormatoTrovato.RangeMin
        '            End If
        '        End If

        '    End Using

        '    collOrd.ListaOrdini.Add(Ord)
        'Next

        Dim collOrd As OrdiniCTP = MgrCTP.GetListaOrdiniCTP(_ComSel)

        Using X As New frmCommessaExportCTP
            ParentFormEx.Sottofondo()
            X.Carica(collOrd, _ComSel.IdCom)
            ParentFormEx.Sottofondo()
        End Using

    End Sub

    Private Sub lnkCTP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCTP.LinkClicked

        If _ComSel.FromJob Then
            MessageBox.Show("Questa commessa è stata creata da un file JOB. Impossibile utilizzare la funzione Export CTP")
        Else
            ExportCTP()
        End If

    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        UcAllegati.Carica(_ComSel.IdCom)
    End Sub

    Private Sub lnkNew_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        ParentFormEx.Sottofondo()
        Dim f As New frmPostit, Ris As Integer = 0
        Ris = f.Carica(, _ComSel.IdCom)
        If Ris Then UcAllegati.Carica(_ComSel.IdCom)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub cmbModelloCommessa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbModelloCommessa.SelectedIndexChanged

        If sender.focus Then SelezionaDefaultInBaseAModello()

    End Sub

    Private Sub SelezionaDefaultInBaseAModello()

        Dim m As ModelloCommessa = DirectCast(cmbModelloCommessa.SelectedItem, ModelloCommessa)

        lblMacchinario.Text = m.MacchinarioNome

        'qui devo calcolare il numero corretto di lastre

        MgrControl.SelectIndexCombo(cmbFormato, m.IdFormatoMacchina)
        UcRisorseCom.SetQtaNeces(CalcolaQtaNeces())

        Dim NumLastreNecessarie As Integer = 0
        Dim NumSegnatureNecessarie As Integer = 0

        Using mgr As New CommesseDAO
            NumLastreNecessarie = mgr.GetLastreNecessarie(m, UcOrdiniCom.ListaIdSelezionati)
            NumSegnatureNecessarie = mgr.CalcolaSegnature(UcOrdiniCom.ListaOrdiniSelezionati, m)
        End Using

        txtNLastre.Text = NumLastreNecessarie

        Dim SingRis As Risorsa = Nothing
        Using mgr As New RisorseDAO
            SingRis = mgr.GetLastraPerMacchinario(m.IdMacchinarioDef)
            If Not SingRis Is Nothing Then
                lblLastre.Text = SingRis.Descrizione
            End If
        End Using

        txtSegnature.Text = NumSegnatureNecessarie

        'CalcolaTotali()

    End Sub

    Private Sub lnkModModelloCommessa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModModelloCommessa.LinkClicked

        ParentFormEx.Sottofondo()

        Using f As New frmCommessaModello
            Dim IdModelloCommessa As Integer = DirectCast(cmbModelloCommessa.SelectedItem, ModelloCommessa).IdModello
            Dim ris As Integer = f.Carica(IdModelloCommessa)
            If ris Then
                If MessageBox.Show("Il modello commessa e' stato modificato, vuoi ricaricare i modelli commessa nella casella a discesa?", "Modello Commessa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    CaricaModelliCommessa()
                End If
            End If
        End Using

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub pctSblocco_Click(sender As Object, e As EventArgs) Handles pctSblocco.Click

        txtNote.ReadOnly = False
        txtNote.BackColor = Color.White
        btnSalvaNote.Visible = True

    End Sub

    Private Sub btnSalvaNote_Click(sender As Object, e As EventArgs) Handles btnSalvaNote.Click

        Dim MsgExtra As String = String.Empty
        Dim SincroNote As Boolean = MgrFormerException.SincronizzareNoteOrdine(_ComSel)

        If SincroNote Then
            MsgExtra = " Le note sovrascriveranno anche le note dell'ordine inserito in commessa"
        End If

        If MessageBox.Show("Confermi il salvataggio delle note?" & MsgExtra, "Salvataggio note", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _ComSel.Refresh()
            _ComSel.Annotazioni = txtNote.Text
            _ComSel.Save()

            If SincroNote Then
                For Each o As Ordine In _ComSel.ListaOrdini
                    o.Annotazioni = _ComSel.Annotazioni
                    o.Save()

                Next
            End If

            MessageBox.Show("Note salvate correttamente")
        End If

    End Sub

    Private Sub lnkAnnulla_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAnnulla.LinkClicked

        If MessageBox.Show("Confermi l'annullamento della commessa? Tutti gli ordini saranno riportati nella condizione precedente", "Annullamento Commessa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            'quando annullo la commessa
            'cancello le lavorazioni su commessa e le rimetto su ogni singolo ordine
            'risposto i file nella cartella temp
            'elimino la commessa
            'elimino idcom dagli ordini
            If MgrCommesse.AnnullaCommessa(Me.ParentForm,
                                        _ComSel) = 0 Then
                RaiseEvent CommessaCancellata()
            End If

        End If

    End Sub

    Public Event CommessaCancellata()

    Private _ModificataListaLav As Boolean = False

    Private Sub lnkAddLavoraz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddLavoraz.LinkClicked
        If SolaLettura = False Then

            If DgLavorazioni.SelectedRows.Count Then
                Dim l As Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem

                If _ComSel.ListaLavLog.FindAll(Function(x) x.Idlav = l.IdLavoro).Count = 0 Then
                    If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        _ModificataListaLav = True

                        Dim llast As LavLog = Nothing

                        Dim Ordine As Integer = 0
                        If DgLavorazioniSel.Rows.Count Then
                            llast = DgLavorazioniSel.Rows(DgLavorazioniSel.Rows.Count - 1).DataBoundItem
                        Else
                            llast = New LavLog
                        End If

                        Ordine = llast.Ordine + 1
                        Dim IdMacchinario As Integer = l.IdMacchinario
                        Dim Macchinario As String = l.Macchinario

                        If l.IdLavoro = FormerConst.Lavorazioni.StampaRealizzazione Then
                            If _ComSel.ListaOrdini.Count = 1 AndAlso
                                _ComSel.IdReparto <> enRepartoWeb.StampaOffset AndAlso
                                _ComSel.IdReparto <> enRepartoWeb.Packaging Then
                                Dim O As Ordine = _ComSel.ListaOrdini()(0)
                                Dim IdMaccToUse As Integer = 0
                                If O.ListinoBase.IdMacchinarioProduzione Then
                                    IdMaccToUse = O.ListinoBase.IdMacchinarioProduzione
                                Else
                                    If _ComSel.ModelloCommessa.IdMacchinarioDef Then
                                        IdMaccToUse = _ComSel.ModelloCommessa.IdMacchinarioDef
                                    End If
                                End If

                                If IdMaccToUse Then
                                    Using m As New Macchinario
                                        m.Read(IdMaccToUse)
                                        IdMacchinario = m.IdMacchinario
                                        Macchinario = m.Descrizione
                                    End Using
                                End If

                            End If
                        End If

                        Dim ll As New LavLog
                        ll.Idlav = l.IdLavoro
                        ll.Descrizione = l.Descrizione
                        ll.Macchinario = Macchinario
                        ll.IdMacchinario = IdMacchinario
                        ll.Tempo = l.TempoRif
                        ll.Premio = l.Premio
                        ll.IdCom = _ComSel.IdCom
                        ll.Ordine = Ordine

                        _ComSel.ListaLavLog.Add(ll)

                        CaricaLavorazioniSelezionate()
                    End If
                Else
                    MessageBox.Show("La lavorazione è gia presente nella commessa!")
                End If

            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If

        Else
            MessageBox.Show("Non è possibile modificare la commessa in questo stato")
        End If
    End Sub

    Private Sub lnkSu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSu.LinkClicked
        If SolaLettura = False Then
            If DgLavorazioniSel.SelectedRows.Count Then
                'If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _ModificataListaLav = True
                SpostaSu()
                'End If
            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If
        Else
            MessageBox.Show("Non è possibile modificare la commessa in questo stato")
        End If
    End Sub

    Private Sub lnkGiu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGiu.LinkClicked
        If SolaLettura = False Then
            If DgLavorazioniSel.SelectedRows.Count Then
                'If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _ModificataListaLav = True
                SpostaGiu()
                'End If
            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If
        Else
            MessageBox.Show("Non è possibile modificare la commessa in questo stato")
        End If
    End Sub

    Private Sub lnkDelLavoraz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelLavoraz.LinkClicked
        If SolaLettura = False Then
            If DgLavorazioniSel.SelectedRows.Count Then

                If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _ModificataListaLav = True

                    Dim l As LavLog = DgLavorazioniSel.SelectedRows(0).DataBoundItem

                    Dim Indice As Integer = DgLavorazioniSel.SelectedRows(0).Index

                    _ComSel.ListaLavLog.Remove(l)

                    For Each row As DataGridViewRow In DgLavorazioniSel.Rows

                        If row.Index > Indice Then
                            row.DataBoundItem.ordine -= 1
                        End If

                    Next

                    CaricaLavorazioniSelezionate()
                End If

            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If
        Else
            MessageBox.Show("Non è possibile modificare la commessa in questo stato")
        End If
    End Sub

    Private Sub SpostaSu()
        If DgLavorazioniSel.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavorazioniSel.SelectedRows(0)
            Dim lavorazione As LavLog = riga.DataBoundItem
            If (riga.Index - 1) >= 0 Then
                Dim RigaVecchia As DataGridViewRow = DgLavorazioniSel.Rows(riga.Index - 1)
                Dim LavVecchia As LavLog = RigaVecchia.DataBoundItem

                If LavVecchia.Idlav <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then
                    lavorazione.Ordine -= 1
                    LavVecchia.Ordine += 1
                    riga.Selected = True

                    CaricaLavorazioniSelezionate()
                    For Each r As DataGridViewRow In DgLavorazioniSel.Rows
                        If r.DataBoundItem.idlavoro = lavorazione.IdLavoro Then
                            r.Selected = True
                            Exit For
                        End If
                    Next
                Else
                    MessageBox.Show("La lavorazione non può essere spostata in quella posizione")
                End If
            End If
            'riga.
        End If
    End Sub

    Private Sub SpostaGiu()

        If DgLavorazioniSel.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavorazioniSel.SelectedRows(0)
            Dim lavorazione As LavLog = riga.DataBoundItem

            If lavorazione.Idlav <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then
                If (riga.Index + 1) < DgLavorazioniSel.Rows.Count Then
                    Dim RigaDopo As DataGridViewRow = DgLavorazioniSel.Rows(riga.Index + 1)
                    Dim lavDopo As LavLog = RigaDopo.DataBoundItem
                    lavorazione.Ordine += 1
                    lavDopo.Ordine -= 1
                    riga.Selected = True

                    CaricaLavorazioniSelezionate()
                    For Each r As DataGridViewRow In DgLavorazioniSel.Rows
                        If r.DataBoundItem.idlavoro = lavorazione.IdLavoro Then
                            r.Selected = True
                            Exit For
                        End If
                    Next
                End If
            Else
                MessageBox.Show("La lavorazione non può essere spostata")
            End If

            'riga.
        End If
    End Sub

    Private Sub txtSegnature_TextChanged(sender As Object, e As EventArgs) Handles txtSegnature.TextChanged

        'PRENDO IL NUMERO DELLE LASTRE CHE MI ESCE DAL CALCOLO 
        'LO MOLTIPLICO PER IL NUMERO DI SEGNATURE
        'LO MOLTIPLICO PER DUE SE FRONTE RETRO
        'Try
        '    Dim NumLastreNecessarie As Integer = 0
        '    Using m As ModelloCommessa = DirectCast(cmbModelloCommessa.SelectedItem, ModelloCommessa)
        '        Using mgr As New CommesseDAO
        '            NumLastreNecessarie = mgr.GetLastreNecessarie(m, UcOrdiniCom.ListaIdSelezionati)
        '        End Using

        '        If txtSegnature.Value <> 1 Then
        '            NumLastreNecessarie = txtSegnature.Value * NumLastreNecessarie
        '        End If

        '        If m.FronteRetro = enSiNo.Si Then
        '            NumLastreNecessarie *= 2
        '        End If

        '    End Using

        '    txtNLastre.Text = NumLastreNecessarie
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub lnkNewFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNewFormato.LinkClicked
        ParentFormEx.Sottofondo()
        Dim ris As Integer = 0
        Using f As New frmListinoFormatoMacchina

            Dim IdMacchinario As Integer = 0

            If _ComSel.IdCom Then
                IdMacchinario = _ComSel.IdMacchinario
            Else
                IdMacchinario = _CommessaProposta.ModelloCommessa.IdMacchinarioDef
            End If

            ris = f.Carica(, IdMacchinario)
        End Using
        ParentFormEx.Sottofondo()

        If ris Then CaricaFormatiMacchina()

    End Sub

    Private Sub btnFronte_Click(sender As Object, e As EventArgs) Handles btnFronte.Click

        Using f As New frmOpenPDF
            ParentFormEx.Sottofondo()
            f.Carica()
            ParentFormEx.Sottofondo()

            If f.SelectedFile.Length Then
                txtSchemaTaglio.Text = f.SelectedFile
            End If
        End Using


    End Sub

    Private Sub txtSoggFoglio_TextChanged(sender As Object, e As EventArgs) Handles txtSoggFoglio.TextChanged
        'UcRisorseCom.QtaNeces = CalcolaQtaNeces()

        'If sender.focused Then AggiornaQtaNeces()
        If sender.focused Then AggiornaQtaNeces()
    End Sub

    Private Sub UcRisorseCom_Load(sender As Object, e As EventArgs) Handles UcRisorseCom.Load

    End Sub

    Private Sub UcRisorseCom_CambiataRisorsa() Handles UcRisorseCom.CambiataRisorsa
        If UcRisorseCom.RisorseSelezionate.Count = 0 Then CaricaRisorseDefault()
        CalcolaSoggetti()
        AggiornaQtaNeces(False)
    End Sub
End Class
