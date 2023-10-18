Imports System.IO
Imports FormerBusinessLogicInterface
Imports FormerBusinessLogic
Imports FormerConfig
Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerWebLabeling
Imports FD = FormerDALSql
Imports FormerIO
Imports System.ComponentModel
Imports FormerGraphics
Imports Telerik.WinControls.Primitives

Friend Class frmOrdineCreaOnline
    'Inherits baseFormInternaFixed
    Public Function ShowBloccoMisure() As Boolean
        Dim ris As Boolean = False
        If Not P Is Nothing AndAlso P.IdPluginToUse = enPluginOnline.Packaging Then
            ris = True
        ElseIf Not LRif Is Nothing Then
            If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse
           LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                ris = True
            End If
        End If

        Return ris
    End Function
    Private Sub SetMisureStatus(Stato As Boolean)

        txtAltezza.Enabled = Stato
        txtLarghezza.Enabled = Stato
        txtProfondita.Enabled = Stato

        If Stato = False Then
            txtAltezza.Text = 0
            txtLarghezza.Text = 0
            txtProfondita.Text = 0
        Else
            'qui controllo cmq profondita a prescindere 
            If Not P Is Nothing AndAlso P.IdPluginToUse = enPluginOnline.Packaging Then
                txtProfondita.Enabled = True
            Else
                txtProfondita.Enabled = False
            End If

        End If

    End Sub

    Private Sub SalvaAppunti()

        Dim Path As String = PathCartellaDiLavoro & "appunti.txt"

        Using f As New StreamWriter(Path)
            f.Write(txtAppunti.Text)
        End Using
    End Sub

    Private Sub CaricaAppunti()

        Dim Path As String = PathCartellaDiLavoro & "appunti.txt"
        If File.Exists(Path) Then
            Using f As New StreamReader(Path)
                txtAppunti.Text = f.ReadToEnd
            End Using
        End If

    End Sub

    Private _Ris As Integer
    Private Sub CaricaCli()

        'Using cli As New FD.VociRubricaDAO
        '    cmbCliente.ValueMember = "IdRub"
        '    cmbCliente.DisplayMember = "Nominativo"

        '    cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, True,
        ''                                           ,
        '                                           ,
        '                                           ,
        '                                           ,
        '                                           True)

        cmbSelCliente.Carica(enTipoRubrica.Cliente, True,, True)

        'End Using

    End Sub

    Private Sub CaricaCat()
        DgLavorazioni.DataSource = Nothing

        If Not LRif Is Nothing Then
            Using C As New FD.CatLavDAO

                tvwCatLavoraz.Nodes.Clear()
                txtOpzioniDisp.Text = String.Empty

                If rdoLavOnlyPreviste.Checked Then
                    'qui devo caricare solo le lavorazioni previste 
                    For Each Lav As LavorazioneW In LRif.LavorazioniOpz

                        Dim ChiavePadre As String = "C" & Lav.IdCatLav

                        If tvwCatLavoraz.Nodes.Find(ChiavePadre, True).Count = 0 Then
                            tvwCatLavoraz.Nodes.Add(ChiavePadre, Lav.CatLav.Descrizione, 0, 0)
                            txtOpzioniDisp.AppendText(Lav.CatLav.Descrizione & "; ")
                        End If

                    Next

                Else
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

                    For Each Cat As FD.CatLav In C.GetAll("OrdineEsecuzione,Descrizione")
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
                End If

            End Using
        End If

    End Sub

    Private Sub CaricaCombo()

        CaricaCli()
        'CaricaCat()

        cmbTipoRetro.ValueMember = "Id"
        cmbTipoRetro.DisplayMember = "Descrizione"

        Dim Voce As New cEnum
        Voce.Id = enTipoRetro.RetroDifferente
        Voce.Descrizione = "Fronte e Retro differenti"
        cmbTipoRetro.Items.Add(Voce)

        Voce = New cEnum
        Voce.Id = enTipoRetro.RetroUgualeFronte
        Voce.Descrizione = "Fronte e Retro uguali"
        cmbTipoRetro.Items.Add(Voce)

        Voce = New cEnum
        Voce.Id = enTipoRetro.RetroBianco
        Voce.Descrizione = "Retro Bianco"
        cmbTipoRetro.Items.Add(Voce)

        Voce = New cEnum
        Voce.Id = enTipoRetro.RetroNelFileFronte
        Voce.Descrizione = "Retro contenuto nel file Fronte"
        cmbTipoRetro.Items.Add(Voce)

        cmbTipoRetro.SelectedIndex = 0

        Using Corriere As New FD.CorrieriDAO

            cmbCorriere.ValueMember = "IdCorriere"
            cmbCorriere.DisplayMember = "Descrizione"
            cmbCorriere.DataSource = Corriere.GetListaCorrieri() ' .FindAll("Descrizione", New LUNA.LunaSearchParameter("DisponibileOnline", enSiNo.Si))

        End Using

        Using PM As New FD.TipoPagamentiDAO
            cmbTipoPagamento.DataSource = PM.GetAll(FD.LFM.TipoPagamento.IdTipoPagam, False)
            cmbTipoPagamento.ValueMember = "IdTipoPagam"
            cmbTipoPagamento.DisplayMember = "TipoPagam"
        End Using


    End Sub

    Private Sub CaricaCartellaDiLavoro()
        Cursor.Current = Cursors.WaitCursor
        lvwAllegati.Items.Clear()

        Dim d As New DirectoryInfo(PathCartellaDiLavoro)

        For Each file As FileInfo In d.GetFiles()

            If file.Extension.ToLower = ".jpg" OrElse
                file.Extension.ToLower = ".jpeg" OrElse
                file.Extension.ToLower = ".png" OrElse
                file.Extension.ToLower = ".pdf" OrElse
                file.Extension.ToLower = ".zip" OrElse
                file.Extension.ToLower = ".rar" Then

                Dim ImgIndex As Integer = 0
                Select Case file.Extension.ToLower
                    Case ".jpg", ".jpeg", ".png"
                        ImgIndex = 2
                    Case ".zip", ".rar"
                        ImgIndex = 0
                    Case ".pdf"
                        ImgIndex = 1
                End Select

                Dim lv As New ListViewItem
                lv.ImageIndex = ImgIndex
                lv.Text = file.Name
                lv.Tag = file.FullName

                lvwAllegati.Items.Add(lv)
            End If

        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private PathCartellaDiLavoro As String = String.Empty

    Private _IdMailRif As Integer = 0

    Friend Function Carica() As Integer

        If FormerDebug.DebugAttivo = False Then LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin

        CaricamentoIniziale()

        Show()

    End Function

    Private Sub CaricamentoIniziale()

        CaricaCombo()

        SetMisureStatus(False)

        CaricaPrev()

        Using M As New FD.PreventivoMail
            M.Read(_IdMailRif)
            UcMailPreview.Carica(M)

            If M.IdRub Then
                cmbSelCliente.IdRubSelezionato = M.IdRub
                cmbSelCliente.Enabled = False
            Else
                cmbSelCliente.IdRubSelezionato = FormerConst.UtentiSpecifici.IdRubricaInternaFormer
            End If

            PathCartellaDiLavoro = FormerPath.PathTempLocale & M.IdRub & "\" & M.IdMailPreventivo & "\"

            FormerLib.FormerHelper.File.CreateLongPath(PathCartellaDiLavoro)

            For Each F As FD.AttachPreventivoMail In M.Allegati
                Dim pathFile As String = PathCartellaDiLavoro & FormerHelper.File.EstraiNomeFile(F.Path)
                If File.Exists(pathFile) = False Then
                    MgrIO.FileCopia(Me, F.Path, pathFile)
                End If
            Next

            lblPath.Text = PathCartellaDiLavoro

            If M.Allegati(True).Count = 1 Then
                Using f As FD.AttachPreventivoMail = M.Allegati(True)(0)
                    txtFronte.Text = PathCartellaDiLavoro & FormerHelper.File.EstraiNomeFile(f.Path)
                End Using
            ElseIf M.Allegati(True).Count = 2 Then
                Using f As FD.AttachPreventivoMail = M.Allegati(True)(0)
                    txtFronte.Text = PathCartellaDiLavoro & FormerHelper.File.EstraiNomeFile(f.Path)
                End Using
                Using f As FD.AttachPreventivoMail = M.Allegati(True)(1)
                    txtRetro.Text = PathCartellaDiLavoro & FormerHelper.File.EstraiNomeFile(f.Path)
                End Using
            End If

            CaricaCartellaDiLavoro()

        End Using

        CaricaAppunti()

        If _IdMailRif = 0 Then
            tabOrdine.TabPages.Remove(tpMailRiferimento)
        End If
    End Sub

    Friend Function Carica(IdMailRif As Integer) As Integer

        _IdMailRif = IdMailRif

        LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin

        CaricamentoIniziale()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaPrev()

        Using mgr As New PreventivazioniWDAO
            Dim l As List(Of PreventivazioneW) = mgr.GetForHome(FormerLib.FormerEnum.enRepartoWeb.Tutto)

            '"Selezionare una voce"
            'New  PreventivazioneW() With {.IdPrev = 0 ,.Descrizione = EmptyItemDescription,.DescrizioneEstesa = "" ,.DispOnline = False ,.ggFast = 0 ,.ggNorm = 0 ,.ggSlow = 0 ,.GoogleDescr = "" ,.GraficaPerFacciata = 0 ,.GruppoVariante = 0 ,.IdColoreStampaDefault = 0 ,.IdFunzionePack = 0 ,.IdMacchinario = 0 ,.IdMacchinarioTaglio = 0 ,.IdPluginToUse = 0 ,.IdReparto = 0 ,.ImgRif = "" ,.ImgSito = "" ,.Linguetta = 0 ,.NascondiAlbero = 0 ,.PercCoupon = 0 ,.PercFast = 0 ,.PercSlow = 0 ,.Prefisso = "" ,.RicaricoPubblico = 0 ,.SaltaCS = 0 ,.SaltaFP = 0 ,.SaltaTC = 0 ,.TipoProd = 0 ,.UrlVideo = ""  })

            'QUESTO VA RIATTIVATO PER NON CARICARE LE PREVENTIVAZIONI CON PLUGIN
            '*******************************************************************
            l = l.FindAll(Function(x) x.IdPluginToUse = 0 Or
                                      x.IdPluginToUse = enPluginOnline.Packaging)

            Dim lFin As New List(Of PreventivazioneW)
            lFin.Add(New PreventivazioneW() With {.IdPrev = 0, .Descrizione = "Selezionare una voce", .DescrizioneEstesa = "", .DispOnline = False, .ggFast = 0, .ggNorm = 0, .ggSlow = 0, .GoogleDescr = "", .GraficaPerFacciata = 0, .GruppoVariante = 0, .IdColoreStampaDefault = 0, .IdFunzionePack = 0, .IdMacchinario = 0, .IdMacchinarioTaglio = 0, .IdPluginToUse = 0, .IdReparto = 0, .ImgRif = "", .ImgSito = "", .Linguetta = 0, .NascondiAlbero = 0, .PercCoupon = 0, .PercFast = 0, .PercSlow = 0, .Prefisso = "", .RicaricoPubblico = 0, .SaltaCS = 0, .SaltaFP = 0, .SaltaTC = 0, .TipoProd = 0, .UrlVideo = ""})

            Dim OldIdReparto As Integer = 0

            For Each voce In l

                If OldIdReparto <> voce.IdReparto Then
                    lFin.Add(New PreventivazioneW() With {.IdPrev = 0, .Descrizione = "*** " & FormerEnumHelper.RepartoStr(voce.IdReparto).ToUpper & " ***", .DescrizioneEstesa = "", .DispOnline = False, .ggFast = 0, .ggNorm = 0, .ggSlow = 0, .GoogleDescr = "", .GraficaPerFacciata = 0, .GruppoVariante = 0, .IdColoreStampaDefault = 0, .IdFunzionePack = 0, .IdMacchinario = 0, .IdMacchinarioTaglio = 0, .IdPluginToUse = 0, .IdReparto = 0, .ImgRif = "", .ImgSito = "", .Linguetta = 0, .NascondiAlbero = 0, .PercCoupon = 0, .PercFast = 0, .PercSlow = 0, .Prefisso = "", .RicaricoPubblico = 0, .SaltaCS = 0, .SaltaFP = 0, .SaltaTC = 0, .TipoProd = 0, .UrlVideo = ""})
                    OldIdReparto = voce.IdReparto
                End If

                lFin.Add(voce)

            Next


            cmbPrev.DisplayMember = "Descrizione"
            cmbPrev.ValueMember = "IdPrev"
            cmbPrev.DataSource = lFin

        End Using

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        WindowState = FormWindowState.Maximized

    End Sub

    Private Function GetPesoCalcolato() As Integer
        Dim ris As Integer = 0

        'calcolo il piu alto tra peso normale e peso volumetrico 
        Dim NumeroPezziScelti As Integer = GetQtaSelezionata()
        Dim QtaRichiesta As Single = NumeroPezziScelti
        Dim QtaSecondaria As Single = 0

        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            QtaRichiesta = CalcolaMq().Mq
        End If
        ris = MgrPreventivazioneB.CalcolaKgCarta(QtaRichiesta,
                                                 LRif,
                                                 False)

        Return ris
    End Function

    Private Function GetImportoSpedizioni() As Decimal
        Dim ris As Decimal = 0

        Dim PesoKg As Integer = GetPesoCalcolato()
        Dim PesoVolumetrico As Integer = 0
        Dim PrezzoTotaleOrdini As Decimal = 0
        Dim Corriere As ICorriereBusiness = cmbCorriere.SelectedItem

        ris = MgrCorriere.CalcolaTariffa(Corriere, PesoVolumetrico, PesoKg, PrezzoTotaleOrdini, cmbTipoPagamento.SelectedItem)

        Return ris
    End Function

    Private Sub SpostaGiu()
        If DgLavorazioniSel.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavorazioniSel.SelectedRows(0)
            Dim lavorazione As FD.Lavorazione = riga.DataBoundItem

            'If lavorazione.IdLavoro <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then
            If (riga.Index + 1) < DgLavorazioniSel.Rows.Count Then
                Dim RigaDopo As DataGridViewRow = DgLavorazioniSel.Rows(riga.Index + 1)
                Dim lavDopo As FD.Lavorazione = RigaDopo.DataBoundItem

                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavorazione.IdLavoro & ",", "," & lavorazione.IdLavoro & "$,")
                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavDopo.IdLavoro & ",", "," & lavorazione.IdLavoro & ",")
                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavorazione.IdLavoro & "$,", "," & lavDopo.IdLavoro & ",")

                CaricaLavorazioniSelezionate()

                For Each r As DataGridViewRow In DgLavorazioniSel.Rows
                    If r.DataBoundItem.idlavoro = lavorazione.IdLavoro Then
                        r.Selected = True
                        Exit For
                    End If
                Next

            End If
            'Else
            '    MessageBox.Show("La lavorazione non può essere spostata")
            'End If

            'riga.
        End If
    End Sub

    Private Sub SpostaSu()
        If DgLavorazioniSel.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavorazioniSel.SelectedRows(0)
            Dim lavorazione As FD.Lavorazione = riga.DataBoundItem
            If (riga.Index - 1) >= 0 Then
                Dim RigaVecchia As DataGridViewRow = DgLavorazioniSel.Rows(riga.Index - 1)
                Dim LavVecchia As FD.Lavorazione = RigaVecchia.DataBoundItem

                'If LavVecchia.IdLavoro <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then

                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavorazione.IdLavoro & ",", "," & lavorazione.IdLavoro & "$,")
                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & LavVecchia.IdLavoro & ",", "," & lavorazione.IdLavoro & ",")
                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavorazione.IdLavoro & "$,", "," & LavVecchia.IdLavoro & ",")
                CaricaLavorazioniSelezionate()

                For Each r As DataGridViewRow In DgLavorazioniSel.Rows
                    If r.DataBoundItem.idlavoro = lavorazione.IdLavoro Then
                        r.Selected = True
                        Exit For
                    End If
                Next

                'Else
                'MessageBox.Show("La lavorazione non può essere spostata in quella posizione")
                'End If
            End If
            'riga.
        End If
    End Sub

    Private _LavorazioniSelezionate As String = String.Empty

    Private Function CreaOrdineDaInserire() As OrdineDaInserire

        Dim Ris As New OrdineDaInserire

        Dim Utente As FD.VoceRubrica = cmbSelCliente.RubSelezionato 'cmbCliente.SelectedItem
        Dim GuidOrd As Guid = Guid.NewGuid()
        Dim GuidToSave As String = Utente.IdUtOnline & "-" & GuidOrd.ToString

        Dim IdIndirizzoScelto As Integer = 0

        If Not cmbIndirizzo.SelectedItem Is Nothing Then
            Dim I As FD.Indirizzo = cmbIndirizzo.SelectedItem
            IdIndirizzoScelto = I.IdIndOnline
        End If

        Dim ImportoSpedizioni As Decimal = GetImportoSpedizioni()
        Dim PesoCalcolato As Integer = GetPesoCalcolato()
        Dim TipoRetroScelto As enTipoRetro = DirectCast(cmbTipoRetro.SelectedItem, cEnum).Id
        Dim Mq As Integer = 0

        If LRif.Preventivazione.IdReparto = enRepartoWeb.StampaDigitale Then
            Mq = CalcolaMq().Mq
        End If

        Dim TipoConsegna As Integer = 0
        If lblFast.Visible Then
            TipoConsegna = enTipoConsegna.Fast
        ElseIf lblNormale.Visible Then
            TipoConsegna = enTipoConsegna.Normale
        ElseIf lblSlow.Visible Then
            TipoConsegna = enTipoConsegna.Slow
        End If

        Dim NumeroColli As Integer = 0
        Dim Qta As Integer = GetQtaSelezionata()
        If LRif.Preventivazione.IdReparto = enRepartoWeb.StampaDigitale Then
            'O.Colli = Convert.ToInt32(ddlQta.SelectedValue)
            NumeroColli = Qta
        Else
            NumeroColli = MgrPreventivazioneB.CalcolaColli(Qta, LRif)
        End If

        Dim NFogli As Integer = 0

        If LRif.ShowLabelFogli Then
            NFogli = GetNFogli()
        Else
            NFogli = LRif.NumFacciate / 2
        End If

        Dim ElencoLavorazioni As String = _LavorazioniSelezionate.Trim(",")

        Dim DataPrevistaProduzione As Date = dtDataConsegna.Value
        Dim DataPrevistaConsegna As Date = CalcolaDataPrevistaConsegna()

        DataPrevistaProduzione = DataPrevistaProduzione.Date
        DataPrevistaConsegna = DataPrevistaConsegna.Date

        Using C As New Consegna
            C.DataInserimento = Now
            C.Giorno = DataPrevistaProduzione
            C.IdUt = Utente.IdUtOnline
            C.IdIndirizzo = IdIndirizzoScelto
            C.IdCorriere = cmbCorriere.SelectedValue
            C.Peso = PesoCalcolato
            C.IdPagam = cmbTipoPagamento.SelectedValue
            If chkNoCartaceo.Checked Then
                C.Blocco = enSiNo.Si
                C.NoCartaceo = enSiNo.Si
                C.IdStatoConsegna = enStatoConsegna.InLavorazione
            Else
                C.NoCartaceo = enSiNo.No
                C.Blocco = enSiNo.No
                C.IdStatoConsegna = enStatoConsegna.InLavorazione
            End If

            C.TipoDoc = enTipoDocumento.Fattura
            C.DataPrevistaOriginale = DataPrevistaConsegna
            C.GuidTransazione = GuidToSave
            C.ImportoNetto = ImportoSpedizioni  'salvo l'importo calcolato netto 

            'qui mi preparo anche l'ordine da salvare

            Dim O As New OrdineWeb
            O.Altezza = txtAltezza.Text
            O.Larghezza = txtLarghezza.Text
            O.Profondita = txtProfondita.Text

            If O.Profondita Then
                'vado a cercare le fustelle

                Dim lstFustelle As List(Of TipoFustellaW) = Nothing

                lstFustelle = New List(Of TipoFustellaW)
                Using mgr As New TipiFustellaWDAO
                    lstFustelle = mgr.FindAll(LFM.TipoFustellaW.Base,
                                                New LUNA.LunaSearchParameter(LFM.TipoFustellaW.IdPrev, LRif.Preventivazione.IdPrev),
                                                New LUNA.LunaSearchParameter(LFM.TipoFustellaW.Disponibile, enSiNo.Si),
                                                New LUNA.LunaSearchParameter(LFM.TipoFustellaW.Profondita, 0, "<>"))

                    lstFustelle = mgr.FustelleCompatibili(LRif.Preventivazione,
                                                                O.Larghezza,
                                                                O.Profondita,
                                                                O.Altezza,
                                                                lstFustelle,
                                                                False)
                End Using

                If lstFustelle.Count Then
                    For Each singTipo As TipoFustellaW In lstFustelle
                        If singTipo.IdTipoFustella = 0 Then
                            'questa e' la personalizzata e quindi vuoldire che non ci sono fustelle compatibili
                            O.IdTipoFustella = 0
                            Exit For
                        Else

                            Dim ToCheck As Boolean = True
                            If singTipo.Base <> O.Larghezza Then
                                ToCheck = False
                            End If
                            If ToCheck = True AndAlso singTipo.Profondita <> O.Profondita Then
                                ToCheck = False
                            End If

                            If ToCheck = True AndAlso singTipo.Altezza <> O.Altezza Then
                                ToCheck = False
                            End If

                            If ToCheck Then
                                O.IdTipoFustella = singTipo.IdTipoFustella
                                Exit For
                            End If

                        End If
                    Next
                End If

            End If

            'O.IdTipoFustella = 0 'disattivato da quando metto le fustelle
            O.IdListinoBase = LRif.IdListinoBase
            O.IdCorriere = C.IdCorriere
            O.Peso = PesoCalcolato
            O.NumeroColli = NumeroColli
            O.Lavorazioni = ElencoLavorazioni
            O.IdUt = C.IdUt
            O.Annotazioni = txtNote.Text
            O.DataIns = Now
            O.Stato = enStatoOrdine.InSospeso
            O.DataPrevProduzione = C.Giorno
            O.DataPrevConsegna = C.DataPrevistaOriginale
            O.IdIndirizzo = C.IdIndirizzo
            O.Mq = Mq
            O.Nfogli = NFogli
            O.Preventivo = IIf(chkPreventivo.Checked, enSiNo.Si, enSiNo.No)
            'O.PrezzoCalcolatoNetto = PrezzoCalcolatoNettoOriginale
            'O.Sconto = Sconto
            'O.Ricarico = ricarico
            O.IdCoupon = 0
            O.Qta = txtQtaReale.Text 'Qta
            O.NomeLavoro = txtNomeLavoro.Text
            O.OrdineInOmaggio = 0
            O.IdPromo = 0

            O.TipoRetro = TipoRetroScelto
            O.Orientamento = enTipoOrientamento.Orizzontale
            O.StatoWeb = enStato.Attivo
            O.TipoConsegna = TipoConsegna
            O.ExtraData = String.Empty
            O.OrdineWeb = False
            O.IdMailPreventivo = _IdMailRif
            O.Sconto = txtSconto.Text
            O.Ricarico = txtRicarico.Text
            O.PrezzoCalcolatoNetto = _TotaleFornitura
            O.UsaNomeLavoroInFattura = IIf(chkUsaNomeLavoro.Checked, enSiNo.Si, enSiNo.No)

            If chkConsegnaGarantita.Checked Then
                O.ConsegnaGarantita = O.DataPrevProduzione
                O.ConsegnaGarantitaDa = PostazioneCorrente.UtenteConnesso.IdUt
            End If

            O.InseritoDa = PostazioneCorrente.UtenteConnesso.IdUt

            Ris.O = O
            Ris.C = C

        End Using

        Return Ris

    End Function

    Private Function SalvaOrdine() As Integer

        Dim Ris As Integer = 0

        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
            Try
                Dim OtoIns As OrdineDaInserire = CreaOrdineDaInserire()

                tb.TransactionBegin()
                OtoIns.C.Save()
                OtoIns.O.IdCons = OtoIns.C.IdConsegna
                OtoIns.O.Save()
                tb.TransactionCommit()

                Ris = OtoIns.O.IdOrdine

            Catch ex As Exception
                tb.TransactionRollBack()
                'Throw ex
            End Try

        End Using

        Return Ris

    End Function
    Public Function MisureObbligatorie() As Boolean
        Dim ris As Boolean = False
        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse
            LRif.TipoPrezzo = enTipoPrezzo.SuFoglio OrElse
            LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
            ris = True
        End If
        Return ris
    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        Dim OkPrezzo As Boolean = True

        If _TotaleFornitura = 0 Then
            If MessageBox.Show("Sembrano esserci delle anomalie nella creazione del prezzo, vuoi continuare?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                OkPrezzo = False
            End If
        End If

        If OkPrezzo Then

            Dim ErrMsg As String = String.Empty
            If Not LRif Is Nothing Then
                Dim TipoRetroScelto As enTipoRetro = enTipoRetro.RetroDifferente ' 

                If Not cmbTipoRetro.SelectedItem Is Nothing Then
                    TipoRetroScelto = DirectCast(cmbTipoRetro.SelectedItem, cEnum).Id
                End If

                Dim OkFile As Boolean = True

                If txtFronte.Text.Length = 0 Then
                    OkFile = False
                End If

                If LRif.ColoreStampa.FR Then
                    If TipoRetroScelto = enTipoRetro.RetroDifferente Then
                        If txtRetro.Text.Length = 0 Then
                            OkFile = False
                        End If
                    End If
                End If

                If OkFile Or LRif.NoAttachFile = enSiNo.Si Then
                    Dim OkValidazione As Boolean = True
                    'qui passo la validazione di entrambi

                    Dim risVal As String = String.Empty

                    If LRif.NoAttachFile <> enSiNo.Si Then
                        risVal = ValidaFileFronteInIns()

                        If LRif.ColoreStampa.FR Then
                            Dim risValR As String = ValidaFileRetroInIns()

                            If risValR.Length Then
                                If risVal.Length Then risVal &= ControlChars.NewLine
                                risVal &= risValR
                            End If
                        End If

                        If risVal.Length Then
                            OkValidazione = False
                        End If
                    End If

                    If OkValidazione Then
                        Dim OkMisure As Boolean = True

                        If MisureObbligatorie() Then

                            If txtAltezza.Value = 0 Then OkMisure = False
                            If txtLarghezza.Value = 0 Then OkMisure = False
                            If LRif.Preventivazione.IdPluginToUse = enPluginOnline.Packaging Then
                                If txtProfondita.Value = 0 Then OkMisure = False
                            End If

                        End If

                        If OkMisure Then
                            Dim OkDimensioni As Boolean = True
                            If LRif.NoAttachFile <> enSiNo.Si Then
                                If txtFronte.Text.Length Then

                                    If FormerHelper.File.GetMB(txtFronte.Text) > 100 Then
                                        OkDimensioni = False
                                        If MessageBox.Show("Il file Fronte che stai allegando pesa piu di 100 Megabyte, questo può creare problemi e si consiglia di ottimizzarlo prima di allegarlo. Vuoi continuare?", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                            OkDimensioni = True

                                        End If
                                    End If
                                End If

                                If txtRetro.Text.Length Then

                                    If FormerHelper.File.GetMB(txtRetro.Text) > 100 Then
                                        OkDimensioni = False
                                        If MessageBox.Show("Il file Retro che stai allegando pesa piu di 100 Megabyte, questo può creare problemi e si consiglia di ottimizzarlo prima di allegarlo. Vuoi continuare?", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                            OkDimensioni = True

                                        End If
                                    End If
                                End If
                            End If

                            'If LRif.Preventivazione.IdReparto = enRepartoWeb.StampaDigitale Then
                            '    If txtAltezza.Value = 0 OrElse txtLarghezza.Value = 0 Then
                            '        MessageBox.Show("Inserire le misure di ALTEZZA e LARGHEZZA")
                            '        OkDimensioni = False
                            '    End If
                            'End If

                            If OkDimensioni Then

                                Dim dataScelta As Date = dtDataConsegna.Value

                                If dataScelta = Date.MinValue Then
                                    ErrMsg &= "La data selezionata non è valida" & ControlChars.NewLine
                                End If

                                If dataScelta.DayOfWeek = DayOfWeek.Sunday Then
                                    ErrMsg &= "Non è possibile selezionare la domenica come giorno di ritiro/spedizione" & ControlChars.NewLine
                                End If

                                If dataScelta.DayOfWeek = DayOfWeek.Saturday And cmbCorriere.SelectedValue <> enCorriere.RitiroCliente Then
                                    ErrMsg &= "Non è possibile selezionare il sabato come giorno di ritiro/spedizione per il corriere scelto" & ControlChars.NewLine
                                End If

                                If txtFronte.Text.Length = 0 Then
                                    If LRif.NoAttachFile <> enSiNo.Si Then
                                        ErrMsg &= "Indicare il file Fronte" & ControlChars.NewLine
                                    End If
                                Else
                                    If txtFronte.Text.ToLower.EndsWith("pdf") = False Then
                                        ErrMsg &= "Si possono scegliere solo file pdf;"
                                    End If
                                End If

                                If chkUsaNomeLavoro.Checked And txtNomeLavoro.Text.Trim.Length = 0 Then
                                    ErrMsg &= "Per forzare il nome lavoro in fattura il campo deve essere valorizzato" & ControlChars.NewLine
                                End If

                                If LRif.ColoreStampa.FR Then
                                    If TipoRetroScelto = enTipoRetro.RetroDifferente Then
                                        If txtRetro.Text.Length = 0 Then
                                            ErrMsg &= "Indicare il file Retro" & ControlChars.NewLine
                                        Else
                                            If txtRetro.Text.ToLower.EndsWith("pdf") = False Then
                                                ErrMsg &= "Si possono scegliere solo file pdf;" & ControlChars.NewLine
                                            End If
                                        End If
                                    End If
                                End If

                                If txtQtaReale.Text.Length = 0 OrElse txtQtaReale.Value = 0 Then
                                    ErrMsg &= "Indicare la quantità reale" & ControlChars.NewLine
                                End If

                                If cmbTipoPagamento.SelectedItem Is Nothing Then
                                    ErrMsg &= "Selezionare un metodo di pagamento" & ControlChars.NewLine
                                End If

                                If ErrMsg.Length Then
                                    MessageBox.Show(ErrMsg)
                                Else
                                    Dim IndirizzoOk As Boolean = False
                                    Dim vr As FD.VoceRubrica = DirectCast(cmbSelCliente.RubSelezionato, FD.VoceRubrica)

                                    Dim IsOltreScopertoMax As Boolean = False

                                    'CHECK SU SCOPERTOMAX

                                    Using MgrR As New FD.VociRubricaDAO
                                        IsOltreScopertoMax = MgrR.OltreScopertoMax(vr)
                                    End Using

                                    If IsOltreScopertoMax Then
                                        Dim MessaggioSM As String = "Il cliente selezionato ha attualmente uno scoperto complessivo di € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(FD.MgrSituazioneCliente.GetSituazioneCliente(vr.IdRub).TotaleScopertoComplessivo) & " che supera il suo limite di scoperto massimo (" & vr.ScopertoMax & "). Vuoi inserire comunque l'ordine?"

                                        If MessageBox.Show(MessaggioSM, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                            IsOltreScopertoMax = False
                                        End If

                                    End If

                                    If IsOltreScopertoMax = False Then
                                        Dim IndSel As FD.Indirizzo = DirectCast(cmbIndirizzo.SelectedItem, FD.Indirizzo)

                                        Dim risValidazione As RisValidazioneIndirizzo = Nothing

                                        risValidazione = FormerWebLabeling.MgrWebLabelingGls.CheckAddress(IndSel.Provincia,
                                                                                        IndSel.Cap,
                                                                                        IndSel.Comune,
                                                                                        IndSel.Indirizzo,
                                                                                        IndSel.IdNazione)
                                        IndirizzoOk = risValidazione.Valido
                                        If IndirizzoOk = False Then
                                            If MessageBox.Show("L'indirizzo selezionato non ha passato la validazione GLS. Si vuole continuare comunque?", "Validazione Indirizzo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                                IndirizzoOk = True
                                            End If
                                        End If

                                        If IndirizzoOk Then

                                            'qui devo fare un anteprima dell'ordine e vedere se viene inserito 

                                            If MessageBox.Show("Confermi l'inserimento dell'ordine online?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                                LUNA.LunaContext.ConnectionString = String.Empty
                                                Dim Posizione As String = "SALVATAGGIO ORDINE"
                                                Try
                                                    'inserisco l'ordine online
                                                    Dim IdLavoroOnline As Integer = SalvaOrdine()

                                                    If IdLavoroOnline Then
                                                        'qui lavoro sui file
                                                        Posizione = "ORDINE SALVATO"

                                                        If chkRendiPagamentoDefault.Checked Then
                                                            If vr.IdPagamento <> cmbTipoPagamento.SelectedValue Then
                                                                vr.IdPagamento = cmbTipoPagamento.SelectedValue
                                                                vr.LastUpdate = Now
                                                                vr.Save()
                                                            End If
                                                        End If

                                                        Dim NomeFileF As String = String.Empty
                                                        Dim NomeFileR As String = String.Empty

                                                        If LRif.NoAttachFile <> enSiNo.Si Then
                                                            Dim FOrig As New FileInfo(txtFronte.Text)
                                                            Dim ROrig As FileInfo = Nothing
                                                            NomeFileF = "F_" & FormerLib.FormerHelper.Web.NormalizzaNomeFile(FOrig.Name)

                                                            If LRif.ColoreStampa.FR Then

                                                                If TipoRetroScelto = enTipoRetro.RetroDifferente Then
                                                                    ROrig = New FileInfo(txtRetro.Text)
                                                                    NomeFileR = "R_" & FormerLib.FormerHelper.Web.NormalizzaNomeFile(ROrig.Name)
                                                                End If

                                                            End If

                                                            'qui devo lavorare su nomefileR e nomefileF

                                                            Dim PathOrdineF As String = FormerPath.PathTemp & IdLavoroOnline & "_" & NomeFileF

                                                            MgrIO.FileCopia(Me, FOrig.FullName, PathOrdineF)
                                                            Posizione = "COPIATO FILE FRONTE"

                                                            If NomeFileR.Length Then
                                                                Dim PathOrdineR As String = FormerPath.PathTemp & IdLavoroOnline & "_" & NomeFileR

                                                                MgrIO.FileCopia(Me, ROrig.FullName, PathOrdineR)
                                                                Posizione = "COPIATO FILE RETRO"
                                                            End If
                                                        End If

                                                        Using O As New OrdineWeb
                                                            O.Read(IdLavoroOnline)
                                                            O.SorgenteFronte = NomeFileF
                                                            If NomeFileR.Length Then
                                                                If TipoRetroScelto = enTipoRetro.RetroDifferente Then
                                                                    O.SorgenteRetro = NomeFileR
                                                                End If
                                                            End If
                                                            O.Stato = enStatoOrdine.Preinserito
                                                            O.Save()
                                                            Posizione = "ORDINE ONLINE AGGIORNATO"

                                                            Try
                                                                Dim PathOrdine As String = "tipografiaformer.it/ordini/" & O.IdOrdine & "/"
                                                                Dim Ftp As New FTPclient(FConfiguration.Ftp.ServerNameProduzione,
                                                                                         FConfiguration.Ftp.ServerLoginProduzione,
                                                                                         FConfiguration.Ftp.ServerPwdProduzione)

                                                                Ftp.FtpCreateDirectory(PathOrdine)

                                                                PathOrdine &= O.IdOrdine & ".xml"
                                                                Dim PathLocale As String = FormerPath.PathTempLocale & O.IdOrdine & ".xml"

                                                                Dim buffer As String = FormerSerializator.SerializeObjectToFile(O,
                                                                                                                         PathLocale)

                                                                MgrIO.FtpTransfer(Me, Ftp, PathLocale, PathOrdine, enTipoOpFTP.Upload)
                                                                Ftp = Nothing
                                                                'Using mgr As New OrdiniWebDAO
                                                                '    mgr.SaveSerialize(O, PathOrdine)
                                                                'End Using

                                                            Catch ex As Exception
                                                                MessageBox.Show("Si è verificato un errore nella creazione del LOG XML Online, l'ordine è stato comunque salvato correttamente")
                                                            End Try

                                                        End Using

                                                        If _IdMailRif Then
                                                            Using M As New FD.PreventivoMail
                                                                M.Read(_IdMailRif)
                                                                If M.IdRub = 0 Then M.IdRub = vr.IdRub
                                                                M.Stato = enStatoPreventivoMail.Lavorata
                                                                M.Save()
                                                            End Using
                                                        Else
                                                            'qui devo cancellare tutta la cartella di lavoro 
                                                            Try

                                                                For Each F As FileInfo In New DirectoryInfo(PathCartellaDiLavoro).GetFiles
                                                                    MgrFormerIO.FileDelete(F.FullName)
                                                                Next

                                                                'System.IO.Directory.Delete(PathCartellaDiLavoro)
                                                            Catch ex As Exception
                                                                MessageBox.Show("Si è verificato un errore nella cancellazione della cartella di lavoro, eliminare i file manualmente")
                                                            End Try

                                                        End If

                                                        _Ris = 1
                                                        Close()
                                                    Else
                                                        LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin
                                                        MessageBox.Show("Si è verificato un errore nel salvataggio dell'ordine. L'ordine non e' stato salvato.")
                                                    End If
                                                Catch ex As Exception
                                                    LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin
                                                    ManageError(ex, Posizione)
                                                End Try
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            MessageBox.Show("Inserire le misure")
                        End If
                    Else
                        MessageBox.Show(risVal)
                    End If
                Else
                    MessageBox.Show("Selezionare il file sorgente fronte e retro se previsto dal prodotto")
                End If
            Else
                MessageBox.Show("Selezionare un prodotto")
            End If
        End If

    End Sub

    Private Sub cmbPrev_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrev.SelectedIndexChanged

        PreventivazioneSelezionata()

    End Sub

    Private _DataRif As Date = Date.MinValue

    Private _LRif As ListinoBaseW = Nothing
    Private ReadOnly Property LRif As ListinoBaseW
        Get
            Dim _IdP As Integer = cmbPrev.SelectedValue
            Dim _idFormatoSel As Integer = cmbFormato.SelectedValue
            Dim _IdTCSel As Integer = cmbTipoCarta.SelectedValue
            Dim _IdCSSel As Integer = cmbColoreStampa.SelectedValue

            If _IdP <> 0 And _idFormatoSel <> 0 And _IdTCSel <> 0 And _IdCSSel <> 0 Then
                'qui posso trovare il listinobase
                Dim Carica As Boolean = True

                If Not _LRif Is Nothing Then
                    If _LRif.IdPrev = _IdP And
                       _LRif.IdFormProd = _idFormatoSel And
                       _LRif.IdTipoCarta = _IdTCSel And
                       _LRif.IdColoreStampa = _IdCSSel Then
                        Carica = False
                    End If
                End If
                If Carica Then
                    Using mgr As New ListinoBaseWDAO
                        _LRif = mgr.Find(New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdP),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdFormProd, _idFormatoSel),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdTipoCarta, _IdTCSel),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdColoreStampa, _IdCSSel),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                                         New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
                        If Not _LRif Is Nothing Then
                            _LRif.CaricaLavorazioniBase()
                            _LRif.CaricaLavorazioniOpz()
                        End If

                    End Using
                End If

            Else
                _LRif = Nothing
            End If
            Return _LRif
        End Get
    End Property

    Private Sub LBSelezionato()

        If Not LRif Is Nothing Then
            'If LRif.ImgSito.Length Then
            '    Try
            '        Dim img As Image = Image.FromFile(FormerPath.PathListinoImg & LRif.ImgSito)
            '        pctTestata.Image = img
            '    Catch ex As Exception

            '    End Try
            'Else
            '    pctTestata.Image = Nothing
            'End If
            SetMisureStatus(ShowBloccoMisure)

            Try
                Dim img As Image = Image.FromFile(FormerPath.PathListinoImg & LRif.GetImgFormato)
                pctIco.Image = img
            Catch ex As Exception

            End Try

            lblNome.Text = LRif.Nome

            _LavorazioniSelezionate = String.Empty

            If MgrFormerException.AggiungereLavorazioneInserimentoNelSistema Then
                'qui aggiungo la lavorazione di inserimento nel sistema che costa x una tantum 
                _LavorazioniSelezionate = FormerConst.Lavorazioni.InserimentoNelSistema & ","
            End If

            For Each Lav As LavorazioneW In LRif.LavorazioniBase
                _LavorazioniSelezionate &= Lav.IdLavoro & ","
            Next

            If _LavorazioniSelezionate.Length Then
                _LavorazioniSelezionate = "," & _LavorazioniSelezionate
            End If

            If LRif.NoAttachFile = enSiNo.Si Then
                btnFronte.Enabled = False
                btnRetro.Enabled = False
            Else
                btnFronte.Enabled = True
                btnRetro.Enabled = True
            End If

            CaricaCat()
            CaricaQTA()
            CaricaPagineFogli()
            CaricaOpzioniObbligatorie()
            CaricaLavorazioniSelezionate()
            CaricaDateConsegna()
            CalcolaTotaleFornitura()
            AggiornaTotDaRicavare()

            'Else

            SetUnitaMisura(LRif.TipoUnitaMisuraInInput)

        End If

    End Sub

    Private Sub SetUnitaMisura(Scala As enUnitaDiMisura)
        Select Case Scala
            Case enUnitaDiMisura.cm
                lblAltezza.Text = "Altezza (cm)"
                lblLarghezza.Text = "Base (cm)"
                lblProfondita.Text = "Profondità (cm)"
            Case enUnitaDiMisura.mm
                lblAltezza.Text = "Altezza (mm)"
                lblLarghezza.Text = "Base (mm)"
                lblProfondita.Text = "Profondità (mm)"
            Case enUnitaDiMisura.Pezzi
                lblAltezza.Text = "-"
                lblLarghezza.Text = "-"
                lblProfondita.Text = "-"


        End Select
    End Sub

    Private Function CalcolaMq() As RisCalcoloMq

        Dim Ris As New RisCalcoloMq
        Dim QtaToConsider As Integer = GetQtaSelezionata()

        'Ris = MgrCalcoliTecnici.CalcolaMq(LRif.FormatoProdotto.Fc.Larghezza,
        Dim AltezzaValidata As Integer = ValidaDimensione(txtAltezza.Text)
        Dim LarghezzaValidata As Integer = ValidaDimensione(txtLarghezza.Text)

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

        lblInfoGrandezza.Text = "mq " & Ris.Mq

        Return Ris
    End Function

    Private Function GetQtaSelezionata() As Integer
        Dim ris As Integer = 1

        Try
            ris = DirectCast(cmbQta.SelectedItem, cEnum).Id
        Catch ex As Exception

        End Try
        Return ris
    End Function

    Private Function ValidaDimensione(Dimensione As String,
                                      Asse As enAsseXYZ) As Integer

        Dim Ris As Integer = 0
        Dim ValoreMin As Integer = 0

        Dim _IdP As Integer = cmbPrev.SelectedValue

        If _IdP Then
            Using P As New PreventivazioneW
                P.Read(_IdP)

                If P.IdPluginToUse = enPluginOnline.Packaging Then
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
                End If

            End Using

        End If

        Return Ris

    End Function
    Private Function ValidaDimensione(Dimensione As String,
                                      Optional DefaultValue As Integer = 1) As Integer
        Dim Ris As Integer = DefaultValue
        Try
            If IsNumeric(Dimensione) Then
                Ris = Dimensione
                'Dim Dimens As Integer = Convert.ToInt32(Dimensione)
                'Dimensione = Math.Abs(Dimens)
                'If Dimensione Then
                '    Ris = Dimensione
                'End If

            End If
        Catch ex As Exception

        End Try
        Return Ris
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

        Dim LarghezzaRif As Integer = LRif.FormatoProdotto.Larghezza 'Cm
        Dim AltezzaRif As Integer = LRif.FormatoProdotto.Lunghezza 'Cm

        'sviluppo i fogli che escono come sviluppo i metri quadri 
        Ris.NumeroFogli = MgrCalcoliTecnici.CalcolaFogli(LarghezzaRif,
                                                         AltezzaRif,
                                                         QtaToConsider,
                                                         AltezzaValidata,
                                                         LarghezzaValidata,
                                                         Scarto)

        Return Ris
    End Function

    Private Sub CalcolaTotaleFornitura()

        If Not LRif Is Nothing Then

            Dim NumeroPezziScelti As Integer = GetQtaSelezionata()
            Dim QtaRichiesta As Single = NumeroPezziScelti
            Dim QtaSecondaria As Single = QtaRichiesta

            If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                QtaRichiesta = CalcolaMq().Mq
                If LRif.ConSoggettiDuplicati = enSiNo.Si Then
                    QtaSecondaria = NumeroPezziScelti
                End If
            ElseIf LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                QtaRichiesta = CalcolaFogli.NumeroFogli
                If LRif.ConSoggettiDuplicati = enSiNo.Si Then
                    QtaSecondaria = NumeroPezziScelti
                End If
            Else
                lblInfoGrandezza.Text = "mq -"
            End If

            Dim PrezzoCalcolatoNetto As Decimal = 0
            Dim PrezzoPubblico As Decimal = 0
            Dim PrezzoRiv As Decimal = 0

            Dim R As RisPrezzoIntermedio = CalcolaPrezzi(QtaRichiesta,
                                                               QtaSecondaria,
                                                               NumeroPezziScelti)
            Dim RCons As RisPrezzoIntermedio = CalcolaPrezzi(QtaRichiesta,
                                                               QtaSecondaria,
                                                               NumeroPezziScelti,
                                                               True)
            'Using C As New FD.VoceRubrica
            '    C.Read(cmbSelCliente.IdRubSelezionato)

            If cmbSelCliente.RubSelezionato.Tipo = enTipoRubrica.Rivenditore Then
                _TotaleFornitura = R.PrezzoRiv
                _TotaleFornituraConsigliato = RCons.PrezzoRiv
            Else
                _TotaleFornitura = R.PrezzoPubbl
                _TotaleFornituraConsigliato = RCons.PrezzoPubbl
            End If

            'End Using

            If R.RichiestaCalcoloPrezzo.AnomaliaPrezzoCalcolato = True OrElse
               RCons.RichiestaCalcoloPrezzo.AnomaliaPrezzoCalcolato = True Then
                _TotaleFornitura = 0
                _TotaleFornituraConsigliato = 0
            End If

            Dim ValInt As Decimal = 0
            Dim ValIntCons As Decimal = 0

            If lblFast.Visible = True Then 'FAST
                ValInt = _TotaleFornitura * MgrPercentualiDay.PercentualeFast(LRif.Preventivazione)
                _TotaleFornitura = Math.Ceiling(ValInt)
                ValIntCons = _TotaleFornituraConsigliato * MgrPercentualiDay.PercentualeFast(LRif.Preventivazione)
                _TotaleFornituraConsigliato = Math.Ceiling(ValIntCons)

                '_TotaleFornitura = Math.Ceiling(_TotaleFornitura * FormerPricingHelper.PercentualeFast(LRif.Preventivazione))
            ElseIf lblNormale.Visible = True Then 'NORMAL
                _TotaleFornitura = _TotaleFornitura * MgrPercentualiDay.PercentualeNormale
                _TotaleFornituraConsigliato = _TotaleFornituraConsigliato * MgrPercentualiDay.PercentualeNormale
            ElseIf lblSlow.Visible = True Then 'SLOW
                ValInt = _TotaleFornitura * MgrPercentualiDay.PercentualeSlow(LRif.Preventivazione)
                _TotaleFornitura = Math.Floor(ValInt)
                ValIntCons = _TotaleFornituraConsigliato * MgrPercentualiDay.PercentualeSlow(LRif.Preventivazione)
                _TotaleFornituraConsigliato = Math.Floor(ValIntCons)
                '_TotaleFornitura = Math.Floor(_TotaleFornitura * FormerPricingHelper.PercentualeSlow(LRif.Preventivazione))
            End If

            lblTotForn.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_TotaleFornitura)
            txtTotConsigliato.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_TotaleFornituraConsigliato)

            CalcolaTotali()

        End If

    End Sub

    Private Function GetLavorazioniSelezionate() As List(Of LavorazioneW)
        Dim ris As New List(Of LavorazioneW)

        For Each id As String In _LavorazioniSelezionate.Split(",")
            If id.Length Then
                Dim L As New LavorazioneW
                L.Read(id)
                ris.Add(L)
            End If
        Next

        Return ris
    End Function

    Private Sub CaricaLavorazioniSelezionate()

        Dim l As New List(Of FD.Lavorazione)

        txtOpzioniScelte.Text = String.Empty

        Dim lInt() As String = _LavorazioniSelezionate.Split(",")

        For Each SingId As String In lInt
            If SingId.Length Then
                Dim singL As New FD.Lavorazione
                singL.Read(SingId)
                l.Add(singL)
            End If
        Next

        For Each lav In l
            If LRif.LavorazioniBase.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count = 0 Then
                txtOpzioniScelte.AppendText(lav.Descrizione & "; ")
            End If
        Next

        'l.Sort(Function(x, y) x.Ordine.CompareTo(y.Ordine))
        DgLavorazioniSel.DataSource = Nothing
        DgLavorazioniSel.AutoGenerateColumns = False
        DgLavorazioniSel.DataSource = l

    End Sub
    Private Function GetNFogli() As Integer
        Dim Ris As Integer = 1
        If LRif.ShowLabelFogli Then
            If Not cmbFacciate.SelectedItem Is Nothing Then Ris = DirectCast(cmbFacciate.SelectedItem, cEnum).Id
        Else
            Ris = 1
        End If
        Return Ris
    End Function

    Private Function CalcolaPrezzi(Qta As Single,
                                   QtaSecondaria As Single,
                                   NumeroPezzi As Integer,
                                   Optional Consigliato As Boolean = False) As RisPrezzoIntermedio
        'Dim QtaRichiesta As Integer = Convert.ToInt32(ddlQta.SelectedValue)
        'LRif.CaricaLavorazioniBase()

        Dim listaBaseB As List(Of ILavorazioneB) = LRif.LavorazioniBaseB

        Dim listaOpz As List(Of LavorazioneW) = GetLavorazioniSelezionate()
        Dim listaOpzB As New List(Of ILavorazioneB)

        For Each L As LavorazioneW In listaOpz
            listaOpzB.Add(L)
        Next

        LRif.NumFacciate = GetNFogli() * 2

        Dim Altezza As Single = 0
        Dim Larghezza As Single = 0

        If LRif.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            Altezza = ValidaDimensione(txtAltezza.Text)
            Larghezza = ValidaDimensione(txtLarghezza.Text)

            'QtaRichiesta = CalcolaMq.Mq

            'Qta = QtaRichiesta * Qta
        ElseIf LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then
            Altezza = ValidaDimensione(txtAltezza.Text)
            Larghezza = ValidaDimensione(txtLarghezza.Text)



            'QtaRichiesta = CalcolaMq.Mq

        End If

        If LRif.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
            Altezza = Altezza / 10
            Larghezza = Larghezza / 10
        End If

        'Dim _Risultato As RisultatoListinoBase
        '_Risultato = MgrPreventivazioneB.CalcolaPrezzi(LRif, listaBaseB, listaOpzB, False,, Altezza, Larghezza)

        'Dim R As RisultatoPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoIntermedio(Qta,
        '                                                                                 QtaSecondaria,
        '                                                                                 _Risultato,
        '                                                                                 LRif,
        '                                                                                 listaBaseB,
        'listaOpzB)
        Dim R As RisPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoFinale(LRif,
                                                                                Qta,
                                                                                listaBaseB,
                                                                                QtaSecondaria,
                                                                                listaOpzB,
                                                                                False,,
                                                                                Altezza,
                                                                                Larghezza,
                                                                                NumeroPezzi,
                                                                                Consigliato)


        Return R

    End Function

    Private Sub CaricaDateConsegna()

        Dim C As ICorriereBusiness = cmbCorriere.SelectedItem

        Dim DateConsegna As RisDataConsegna = MgrDataConsegna.CalcolaDateConsegna(LRif.Preventivazione,
                                                                                    C,
                                                                                    New List(Of ILavorazioneB))

        _DataRif = DateConsegna.DataNormaleProduzione
        dtDataConsegna.Value = _DataRif

        lblFast.Visible = False
        lblSlow.Visible = False
        lblNormale.Visible = True

    End Sub

    Private Sub CaricaOpzioniObbligatorie()

        Dim L As List(Of LavorazioneW) = LRif.LavorazioniBase
        Dim LObbligate As New List(Of LavorazioneW)
        Dim buffer As String = String.Empty

        For Each singL In L
            'If LRif.LavorazioniOpz.FindAll(Function(x) x.IdCatLav = singL.IdCatLav).Count = 0 Then
            If singL.LavorazioneInterna = enSiNo.No Then
                buffer &= "- " & singL.Descrizione & ControlChars.NewLine
            End If
            'End If
        Next

        txtOpzioni.Text = buffer
        'L = L.FindAll(Function(sing) sing.CatLav.TipoControllo <> enTipoControllo.ComboBox)

        'carico le lavorazioni nella lista 

    End Sub

    Private Sub CaricaPagineFogli()

        cmbFacciate.Items.Clear()

        If LRif.ShowLabelFogli() Then
            cmbFacciate.Enabled = True
            lblFacciate.Text = LRif.GetLabelFogli
            If LRif.faccmin = LRif.faccmax Then
                'qui devo dividere per due 
                Dim ValoreRif As Integer = LRif.faccmin / 2
                Dim VoceTxt As String = TrasformaNFogli(ValoreRif) & LRif.LabelCopertina
                Dim VoceFissa As New cEnum(ValoreRif, VoceTxt)
                cmbFacciate.Items.Add(VoceFissa)
            Else
                Dim ValMin = LRif.faccmin / 2
                Dim ValMax = LRif.faccmax / 2

                Do
                    Dim VoceTxt As String = TrasformaNFogli(ValMin) & LRif.LabelCopertina
                    Dim VoceFissa As New cEnum(ValMin, VoceTxt)
                    cmbFacciate.Items.Add(VoceFissa)
                    ValMin += LRif.MultiploQta
                Loop Until ValMin > ValMax

            End If
            cmbFacciate.SelectedIndex = 0
        Else
            cmbFacciate.Enabled = False
            lblFacciate.Text = "-"
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

    Private Sub CaricaQTA()

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

        cmbQta.Items.Clear()
        cmbQta.DisplayMember = "Descrizione"
        cmbQta.ValueMember = "Id"
        Using mgr As New MgrQtaListinoBase
            Dim lQta As List(Of Integer) = mgr.GetElencoQtaEx(LRif)

            For Each ValQta As Integer In lQta
                Dim QtaS As String = FormerLib.FormerHelper.Stringhe.FormattaNumero(ValQta)

                cmbQta.Items.Add(New cEnum With {.Id = ValQta, .Descrizione = QtaS})
            Next
        End Using

        MgrControl.SelectIndexComboEnum(cmbQta, QtaDaSelezionare)

    End Sub

    Private Sub TCSelezionato()
        Dim _IdP As Integer = cmbPrev.SelectedValue
        Dim _idFormatoSel As Integer = cmbFormato.SelectedValue
        Dim _IdTCSel As Integer = cmbTipoCarta.SelectedValue

        If _IdP <> 0 And _idFormatoSel <> 0 And _IdTCSel <> 0 Then

            Dim lst As List(Of ListinoBaseW)
            Using L As New ListinoBaseWDAO
                lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "idFormato"},
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdP),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdFormProd, _idFormatoSel),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdTipoCarta, _IdTCSel),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
            End Using

            'carico i listini base correlati
            If CaricaLBLinkati Then
                Using Pl As New PrevLinkListinoDAO
                    Dim lstPL As List(Of PrevLinkListino) = Pl.FindAll(New LUNA.LunaSearchParameter(LFM.PrevLinkListino.IdPreventivazione, _IdP))
                    For Each SingPl As PrevLinkListino In lstPL
                        Dim singL As New ListinoBaseW
                        singL.Read(SingPl.IdListinoBase)
                        If singL.NascondiOnline <> enSiNo.Si And singL.Disattivo <> enSiNo.Si Then
                            singL.Linkato = True
                            lst.Add(singL)
                        End If
                    Next
                End Using
            End If

            Using P As New PreventivazioniWDAO
                P.OrdinaListinoPerGrammaturaCarta(lst)
            End Using

            Dim lstF As New List(Of ColoreStampaW)

            For Each L As ListinoBaseW In lst
                If lstF.FindAll(Function(x) x.IdColoreStampa = L.IdColoreStampa).Count = 0 Then lstF.Add(L.ColoreStampa)
            Next

            If lstF.Count > 1 Then
                lstF.Insert(0, New ColoreStampaW With {.Descrizione = " - Selezionare una voce"})
            End If

            cmbColoreStampa.DisplayMember = "Descrizione"
            cmbColoreStampa.ValueMember = "IdColoreStampa"
            cmbColoreStampa.DataSource = lstF

            If lstF.Count = 1 Then
                CSSelezionato()
            End If

        Else
            'resetto tutto
            'cmbFormato.Items.Clear()
            cmbColoreStampa.DataSource = Nothing
            cmbColoreStampa.Refresh()

        End If
    End Sub

    Private Sub CSSelezionato()

        Dim IdCs As Integer = cmbColoreStampa.SelectedValue

        If IdCs Then

            Using C As New ColoreStampaW
                C.Read(IdCs)
                If C.FR Then
                    pnlRetro.Visible = True
                Else
                    pnlRetro.Visible = False
                End If
            End Using

            LBSelezionato()
        Else
            ResetField()
        End If

    End Sub

    Private Sub ResetField()

    End Sub

    Private Sub FPSelezionato()
        Dim _IdP As Integer = cmbPrev.SelectedValue
        Dim _idFormatoSel As Integer = cmbFormato.SelectedValue

        If _IdP <> 0 And _idFormatoSel <> 0 Then

            Dim lst As List(Of ListinoBaseW)
            Using L As New ListinoBaseWDAO
                lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "idFormato"},
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdP),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdFormProd, _idFormatoSel),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
            End Using

            'carico i listini base correlati
            If CaricaLBLinkati Then
                Using Pl As New PrevLinkListinoDAO
                    Dim lstPL As List(Of PrevLinkListino) = Pl.FindAll(New LUNA.LunaSearchParameter(LFM.PrevLinkListino.IdPreventivazione, _IdP))
                    For Each SingPl As PrevLinkListino In lstPL
                        Dim singL As New ListinoBaseW
                        singL.Read(SingPl.IdListinoBase)
                        If singL.NascondiOnline <> enSiNo.Si And singL.Disattivo <> enSiNo.Si Then
                            singL.Linkato = True
                            lst.Add(singL)
                        End If
                    Next
                End Using
            End If

            Using P As New PreventivazioniWDAO
                P.OrdinaListinoPerGrammaturaCarta(lst)
            End Using

            Dim lstF As New List(Of TipoCartaW)

            For Each L As ListinoBaseW In lst
                If lstF.FindAll(Function(x) x.IdTipoCarta = L.IdTipoCarta).Count = 0 Then lstF.Add(L.TipoCarta)
            Next

            If lstF.Count > 1 Then
                lstF.Insert(0, New TipoCartaW With {.Tipologia = " - Selezionare una voce"})
            End If

            cmbTipoCarta.DisplayMember = "Tipologia"
            cmbTipoCarta.ValueMember = "IdTipoCarta"
            cmbTipoCarta.DataSource = lstF

            cmbColoreStampa.DataSource = Nothing
            cmbColoreStampa.Refresh()

            If lstF.Count = 1 Then
                TCSelezionato()
            End If

        Else
            'resetto tutto
            'cmbFormato.Items.Clear()
            cmbTipoCarta.DataSource = Nothing
            cmbTipoCarta.Refresh()

        End If


    End Sub

    Private _P As PreventivazioneW = Nothing
    Public ReadOnly Property P As PreventivazioneW
        Get
            Dim _IdP As Integer = cmbPrev.SelectedValue
            If _IdP Then
                If _P Is Nothing OrElse _P.IdPrev <> _IdP Then
                    _P = New PreventivazioneW
                    _P.Read(_IdP)
                End If
            Else
                _P = Nothing
            End If
            Return _P
        End Get
    End Property

    Private CaricaLBLinkati As Boolean = False
    Private Sub PreventivazioneSelezionata()
        Cursor.Current = Cursors.WaitCursor

        If Not P Is Nothing Then

            SetMisureStatus(ShowBloccoMisure)

            Dim lstF As New List(Of FormatoProdottoW)
            Dim lst As List(Of ListinoBaseW) = Nothing
            Dim UnitToSel As enUnitaDiMisura = enUnitaDiMisura.Pezzi

            If P.IdPluginToUse = enPluginOnline.Packaging Then
                UnitToSel = enUnitaDiMisura.mm

                If P.IdFunzionePack = enFunzionePackaging.FunzioneECMA3 Then
                    Dim MinimoP As Integer = MgrPluginPackaging.GetMinimoProfondita(P)
                    txtProfondita.Text = MinimoP
                    txtProfondita.Enabled = False
                Else
                    txtProfondita.Enabled = True
                End If

                'in caso di packaging aspetto le misure
                If txtAltezza.Value <> 0 AndAlso txtLarghezza.Value <> 0 AndAlso txtProfondita.Value <> 0 Then
                    Dim risRice As RisPackaging = MgrPluginPackaging.GetListiniBaseCompatibili(P,
                txtAltezza.Value,
                txtLarghezza.Value,
                txtProfondita.Value)

                    If risRice.ListiniBase.Count Then
                        Dim lbSel As IListinoBaseB = risRice.ListiniBase(0)
                        lst = New List(Of ListinoBaseW)
                        Using lbW As New ListinoBaseW
                            lbW.Read(lbSel.IdListinoBase)
                            lst.Add(lbW)
                            lstF.Add(lbW.FormatoProdotto)
                        End Using

                    Else
                        lstF.Insert(0, New FormatoProdottoW With {.Formato = " - Misure inserite NON VALIDE"})
                    End If
                Else
                    lstF.Insert(0, New FormatoProdottoW With {.Formato = " - Inserire le misure"})
                End If
            Else

                Using L As New ListinoBaseWDAO
                    lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "idFormato"},
                                    New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, P.IdPrev),
                                    New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                                    New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
                End Using

                'carico i listini base correlati
                If CaricaLBLinkati Then
                    Using Pl As New PrevLinkListinoDAO
                        Dim lstPL As List(Of PrevLinkListino) = Pl.FindAll(New LUNA.LunaSearchParameter(LFM.PrevLinkListino.IdPreventivazione, P.IdPrev))
                        For Each SingPl As PrevLinkListino In lstPL
                            Dim singL As New ListinoBaseW
                            singL.Read(SingPl.IdListinoBase)
                            If singL.NascondiOnline <> enSiNo.Si And singL.Disattivo <> enSiNo.Si Then
                                singL.Linkato = True
                                lst.Add(singL)
                            End If
                        Next
                    End Using
                End If


                Using mgr As New PreventivazioniWDAO
                    mgr.OrdinaListinoPerFormatoProd(lst)
                End Using


                For Each L As ListinoBaseW In lst
                    If lstF.FindAll(Function(x) x.IdFormProd = L.IdFormProd).Count = 0 Then lstF.Add(L.FormatoProdotto)
                Next

                If lstF.Count > 1 Then
                    lstF.Insert(0, New FormatoProdottoW With {.Formato = " - Selezionare una voce"})
                End If
            End If

            SetUnitaMisura(UnitToSel)

            cmbFormato.DisplayMember = "Formato"
            cmbFormato.ValueMember = "IdFormProd"
            cmbFormato.DataSource = lstF

            cmbTipoCarta.DataSource = Nothing
            cmbTipoCarta.Refresh()

            cmbColoreStampa.DataSource = Nothing
            cmbColoreStampa.Refresh()

            If Not lst Is Nothing AndAlso lst.Count = 1 Then
                FPSelezionato()
            End If

        Else
            'resetto tutto
            'cmbFormato.Items.Clear()
            cmbFormato.DataSource = Nothing
            cmbFormato.Refresh()

        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmbFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormato.SelectedIndexChanged
        If sender.focused Then FPSelezionato()
    End Sub

    Private Sub cmbTipoCarta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCarta.SelectedIndexChanged
        If sender.focused Then TCSelezionato()
    End Sub

    Private Sub cmbColoreStampa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColoreStampa.SelectedIndexChanged
        CSSelezionato()
    End Sub

    Private Sub CaricaDefaultCliente()

        Using R As FD.VoceRubrica = DirectCast(cmbSelCliente.RubSelezionato, FD.VoceRubrica)

            If Not R Is Nothing Then
                'in r.idcorriere ho il metodo di consegna , poi devo chiedere al mgr dei metodi di consegna in base al cap del cliente il default

                Dim l As New List(Of ICorriereBusiness)

                Using mgr As New FD.CorrieriDAO
                    For Each singCorr As FD.Corriere In mgr.FindAll(FD.LFM.Corriere.IdCorriere,
                                                                    New FD.LUNA.LunaSearchParameter(FD.LFM.Corriere.DisponibileOnline, enSiNo.Si))
                        l.Add(singCorr)
                    Next
                End Using

                Dim met As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(R.IdCorriere)
                Dim iCorr As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(met, l, R.DefaultCAP)
                Dim IdCorrPredef As Integer = iCorr.IdCorriere

                MgrControl.SelectIndexCombo(cmbCorriere, IdCorrPredef)

                cmbIndirizzo.ValueMember = "IdIndOnline"
                cmbIndirizzo.DisplayMember = "RiassuntoEx"
                cmbIndirizzo.DataSource = R.Indirizzi

                If R.Indirizzi.FindAll(Function(x) x.IdIndOnline = R.DefaultIndirizzo.IdIndOnline).Count = 0 Then
                    MessageBox.Show("Il cliente selezionato ha un indirizzo di default che ancora non è presente nel nostro database. Riprovare tra 5 minuti")
                    Close()
                Else
                    MgrControl.SelectIndexCombo(cmbIndirizzo, R.DefaultIndirizzo.IdIndOnline)
                End If

                If R.TipoDoc = enTipoDocumento.Preventivo Then
                    chkPreventivo.Checked = True
                Else
                    chkPreventivo.Checked = False
                End If

                Dim IdPagamToSel As Integer = R.IdPagamento

                Using Mp As New FD.TipoPagamento
                    Mp.Read(IdPagamToSel)

                    If Mp.PeriodoPagam = enPeriodoPagamento.Anticipato Then
                        If cmbCorriere.SelectedValue = enCorriere.GLS OrElse
                           cmbCorriere.SelectedValue = enCorriere.GLSIsole OrElse
                           cmbCorriere.SelectedValue = enCorriere.PortoAssegnatoGLS Then
                            IdPagamToSel = enMetodoPagamento.ContrassegnoAlRitiro
                        Else
                            IdPagamToSel = enMetodoPagamento.BonificoBancario
                        End If
                    End If

                End Using

                MgrControl.SelectIndexCombo(cmbTipoPagamento, IdPagamToSel)
            End If

        End Using

    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs)

        CaricaDefaultCliente()
        If sender.focused Then CalcolaTotaleFornitura()

    End Sub

    Private Sub dtDataConsegna_ValueChanged(sender As Object, e As EventArgs) Handles dtDataConsegna.ValueChanged
        If sender.focused Then
            If Not LRif Is Nothing Then
                If dtDataConsegna.Value > _DataRif Then
                    lblFast.Visible = False
                    lblSlow.Visible = True
                    lblNormale.Visible = False

                ElseIf dtDataConsegna.Value < _DataRif Then
                    lblFast.Visible = True
                    lblSlow.Visible = False
                    lblNormale.Visible = False

                ElseIf dtDataConsegna.Value = _DataRif Then
                    lblFast.Visible = False
                    lblSlow.Visible = False
                    lblNormale.Visible = True
                End If
            Else
                dtDataConsegna.Value = Now.Date
            End If

            CalcolaTotaleFornitura()
        End If

        lblDataPrevistaConsegna.Text = CalcolaDataPrevistaConsegna().ToString("dd/MM/yyyy")

    End Sub

    Private Function CalcolaDataPrevistaConsegna() As Date

        Dim DataPrevistaProduzione As Date = dtDataConsegna.Value
        Dim DataPrevistaConsegna As Date = Date.MinValue
        Dim IdCorriere As Integer = cmbCorriere.SelectedValue
        Using C As New FD.Corriere
            C.Read(IdCorriere)
            DataPrevistaConsegna = MgrDataConsegna.CalcolaDataConsegna(DataPrevistaProduzione, C)
        End Using

        Return DataPrevistaConsegna

    End Function

    Private _TotaleFornitura As Decimal = 0
    Private _TotaleFornituraConsigliato As Decimal = 0

    Private Sub AggiornaTotDaRicavare()
        Dim ValoreScelto As Decimal = txtTotDaRicavare.Value

        If ValoreScelto = 0 Then
            txtSconto.Text = 0
            txtRicarico.Text = 0
        Else
            If ValoreScelto > _TotaleFornitura Then
                txtRicarico.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((ValoreScelto - _TotaleFornitura), 2)
                txtSconto.Text = 0
            ElseIf ValoreScelto < _TotaleFornitura Then
                txtSconto.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((_TotaleFornitura - ValoreScelto), 2)
                txtRicarico.Text = 0
            ElseIf ValoreScelto = _TotaleFornitura Then
                txtSconto.Text = 0
                txtRicarico.Text = 0
            End If
        End If
    End Sub

    Private Sub txtTotDaRicavare_TextChanged(sender As Object, e As EventArgs) Handles txtTotDaRicavare.TextChanged

        AggiornaTotDaRicavare()

    End Sub

    Private Sub lnkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReset.LinkClicked
        ResetTxtTotDaRicavare()
        txtSconto.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(0)
        txtRicarico.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(0)
    End Sub

    Private Sub txtTotDaRicavare_LostFocus(sender As Object, e As EventArgs) Handles txtTotDaRicavare.LostFocus
        If txtTotDaRicavare.Value = 0 Then ResetTxtTotDaRicavare()
    End Sub

    Private Sub ResetTxtTotDaRicavare()
        'MARCO: IL RESET DEVE RIPORTARE IL CAMPO AL VALORE DELL'IMPONIBILE (INCLUSI QUINDI EVENTUALI RICARICHI O SCONTI GIA' PRESENTI)
        'O A QUELLO DELLA FORNITURA, AZZERANDO SCONTO E RICARICO? CHIEDERE AD ANTONIO
        txtTotDaRicavare.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_TotaleFornitura)
        txtTotConsigliato.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_TotaleFornituraConsigliato)
    End Sub

    Private Sub CalcolaTotali()
        '' calcolo iva e totale
        Dim TotaleFornitura As Decimal = _TotaleFornitura

        Dim Sconto As Decimal = 0
        Try
            Sconto = CDec(txtSconto.Text)
        Catch ex As Exception

        End Try
        Dim Ricarico As Decimal = 0
        Try
            Ricarico = CDec(txtRicarico.Text)
        Catch ex As Exception

        End Try

        Dim TotImponibile As Decimal = TotaleFornitura - Sconto + Ricarico
        Dim Iva As Decimal = FormerHelper.Finanziarie.CalcolaIva(TotImponibile)

        lblTotImp.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotImponibile)
        lblIva.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Iva)
    End Sub

    Private Sub txtSconto_TextChanged(sender As Object, e As EventArgs) Handles txtSconto.TextChanged
        CalcolaTotali()
    End Sub

    Private Sub txtRicarico_TextChanged(sender As Object, e As EventArgs) Handles txtRicarico.TextChanged
        CalcolaTotali()
    End Sub

    Private Sub cmbQta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbQta.SelectedIndexChanged
        txtQtaReale.Text = CInt(cmbQta.Text)
        If sender.focused Then CalcolaTotaleFornitura()
    End Sub

    Private Sub cmbFacciate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFacciate.SelectedIndexChanged
        If sender.focused Then CalcolaTotaleFornitura()
    End Sub

    'Private Sub txtAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza.TextChanged,
    '                                                                                txtLarghezza.TextChanged,
    '                                                                                txtProfondita.TextChanged

    '    'se listinobase di tipo packaging vado a provare a disegnare la fustella
    '    If Not LRif Is Nothing Then
    '        If LRif.Preventivazione.IdReparto = enRepartoWeb.Packaging Then
    '            DisegnaFustella()
    '        End If
    '    End If

    'End Sub

    'Private Sub DisegnaFustella()

    '    Try
    '        Dim H As Integer = 0
    '        Dim P As Integer = 0
    '        Dim W As Integer = 0

    '        H = txtAltezza.Value
    '        W = txtLarghezza.Value
    '        P = txtProfondita.Value

    '        If H <> 0 AndAlso W <> 0 AndAlso P <> 0 Then
    '            Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(LRif.Preventivazione,
    '                                                                                                H,
    '                                                                                                W,
    '                                                                                                P, 128)

    '        End If



    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub txtLarghezza_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezza.TextChanged


    End Sub

    Private Sub tvwCatLavoraz_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwCatLavoraz.AfterSelect
        CaricaLavInCat()
    End Sub
    Private Sub CaricaLavInCat()

        'carico la lista delle lavorazioni 

        Using mgr As New FD.LavorazioniDAO


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
                Dim IdListinoBase As Integer = 0

                If rdoLavOnlyPreviste.Checked Then
                    IdListinoBase = LRif.IdListinoBase
                End If

                Dim l As List(Of FD.LavorazioneEx) = mgr.ListaLavorazioni(0, IdCat, IdListinoBase) ',cmbCategoria.SelectedValue)
                DgLavorazioni.AutoGenerateColumns = False
                DgLavorazioni.DataSource = l

            End If
        End Using

        'Dim x As New cLavoriColl
        'Dim dtLista As DataTable

        'dtLista = x.ListaLavorazioni

        'DgLavorazioni.DataSource = dtLista

        'DgLavorazioni.Columns(0).Visible = False
        'DgLavorazioni.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"

        'x = Nothing

    End Sub

    Private Sub pctChange_Click(sender As Object, e As EventArgs) Handles pctChange.Click

        Dim OldFronte As String = txtFronte.Text
        txtFronte.Text = txtRetro.Text
        txtRetro.Text = OldFronte

    End Sub

    Private Sub lnkOpenFoldSorg_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOpenFoldSorg.LinkClicked

        FormerHelper.File.ShellExtended(PathCartellaDiLavoro)

    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked

        CaricaCartellaDiLavoro()

    End Sub

    Private Sub btnFronte_Click(sender As Object, e As EventArgs) Handles btnFronte.Click
        If Not LRif Is Nothing Then

            Using f As New frmOpenPDF
                Sottofondo()
                f.Carica(PathCartellaDiLavoro)
                Sottofondo()
                If f.SelectedFile.Length Then
                    Dim FileName As String = f.SelectedFile '.FileName

                    If FileName.ToLower.EndsWith(".pdf") Then
                        'qui devo effettuare la validazione del file e se il livello e' sotto errore inserirlo comunque
                        Using L As New FD.ListinoBase
                            L.Read(LRif.IdListinoBase)
                            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
                                                                                                                    FileName,
                                                                                                                    txtLarghezza.Text,
                                                                                                                    txtAltezza.Text,
                                                                                                                    enTipoOrientamento.NonSpecificato)

                            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
                                MessageBox.Show("Il file non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & risValidazioneFile.ErrorBuffer(True))
                            ElseIf risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Attenzione Then
                                If MessageBox.Show("Il file presenta i seguenti problemi NON BLOCCANTI: " & risValidazioneFile.ErrorBuffer(True) &
                                                   "Si vuole comunque allegarlo all'ordine? ", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    txtFronte.Text = FileName
                                End If
                            Else
                                txtFronte.Text = FileName
                            End If
                        End Using
                    Else
                        MessageBox.Show("Si possono allegare solo file PDF agli ordini")
                    End If
                End If
            End Using

            'OpenFileImg.InitialDirectory = PathCartellaDiLavoro
            'OpenFileImg.ShowDialog()

            'If OpenFileImg.FileName.Length Then

            '    Dim FileName As String = OpenFileImg.FileName

            '    If FileName.ToLower.EndsWith(".pdf") Then
            '        'qui devo effettuare la validazione del file e se il livello e' sotto errore inserirlo comunque
            '        Using L As New FD.ListinoBase
            '            L.Read(LRif.IdListinoBase)
            '            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
            '                                                                                                    FileName,
            '                                                                                                    txtLarghezza.Text,
            '                                                                                                    txtAltezza.Text,
            '                                                                                                    enTipoOrientamento.NonSpecificato)

            '            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
            '                MessageBox.Show("Il file non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & risValidazioneFile.ErrorBuffer(True))
            '            ElseIf risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Attenzione Then
            '                If MessageBox.Show("Il file presenta i seguenti problemi NON BLOCCANTI: " & risValidazioneFile.ErrorBuffer(True) &
            '                                   "Si vuole comunque allegarlo all'ordine? ", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '                    txtFronte.Text = FileName
            '                End If
            '            Else
            '                txtFronte.Text = FileName
            '            End If
            '        End Using
            '    Else
            '        MessageBox.Show("Si possono allegare solo file PDF agli ordini")
            '    End If
            'End If
        Else
            MessageBox.Show("Selezionare prima un prodotto")
        End If

    End Sub

    Private Function ValidaFileFronteInIns() As String
        Dim Ris As String = String.Empty

        Using L As New FD.ListinoBase
            L.Read(LRif.IdListinoBase)
            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
                                                                                                    txtFronte.Text,
                                                                                                    txtLarghezza.Text,
                                                                                                    txtAltezza.Text,
                                                                                                    enTipoOrientamento.NonSpecificato)

            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
                Ris = "Il file FRONTE non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True)
            End If
        End Using
        Return Ris
    End Function

    Private Function ValidaFileRetroInIns() As String
        Dim Ris As String = String.Empty

        Using L As New FD.ListinoBase
            L.Read(LRif.IdListinoBase)
            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
                                                                                                                 txtRetro.Text,
                                                                                                                 txtLarghezza.Text,
                                                                                                                 txtAltezza.Text,
                                                                                                                 enTipoOrientamento.NonSpecificato)

            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
                Ris = "Il file RETRO non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True)
            End If
        End Using
        Return Ris
    End Function

    Private Sub btnRetro_Click(sender As Object, e As EventArgs) Handles btnRetro.Click
        If Not LRif Is Nothing Then

            Using f As New frmOpenPDF
                Sottofondo()
                f.Carica(PathCartellaDiLavoro)
                Sottofondo()

                If f.SelectedFile.Length Then
                    Dim FileName As String = f.SelectedFile

                    If FileName.ToLower.EndsWith(".pdf") Then

                        'qui devo effettuare la validazione del file e se il livello e' sotto errore inserirlo comunque
                        Using L As New FD.ListinoBase
                            L.Read(LRif.IdListinoBase)
                            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
                                                                                                                    FileName,
                                                                                                                    txtLarghezza.Text,
                                                                                                                    txtAltezza.Text,
                                                                                                                    enTipoOrientamento.NonSpecificato)

                            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
                                MessageBox.Show("Il file non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True))
                            ElseIf risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Attenzione Then
                                If MessageBox.Show("Il file presenta i seguenti problemi NON BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True) &
                                                   "Si vuole comunque allegarlo all'ordine? ", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    txtRetro.Text = FileName
                                End If
                            Else
                                txtRetro.Text = FileName
                            End If
                        End Using
                    Else
                        MessageBox.Show("Si possono allegare solo file PDF agli ordini")
                    End If
                End If

            End Using

            'OpenFileImg.ShowDialog()

            'If OpenFileImg.FileName.Length Then
            '    Dim FileName As String = OpenFileImg.FileName

            '    If FileName.ToLower.EndsWith(".pdf") Then

            '        'qui devo effettuare la validazione del file e se il livello e' sotto errore inserirlo comunque
            '        Using L As New FD.ListinoBase
            '            L.Read(LRif.IdListinoBase)
            '            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
            '                                                                                                                 FileName,
            '                                                                                                                 txtLarghezza.Text,
            '                                                                                                                 txtAltezza.Text,
            '                                                                                                                 enTipoOrientamento.NonSpecificato)

            '            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
            '                MessageBox.Show("Il file non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True))
            '            ElseIf risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Attenzione Then
            '                If MessageBox.Show("Il file presenta i seguenti problemi NON BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True) &
            '                                   "Si vuole comunque allegarlo all'ordine? ", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '                    txtRetro.Text = FileName
            '                End If
            '            Else
            '                txtRetro.Text = FileName
            '            End If
            '        End Using
            '    Else
            '        MessageBox.Show("Si possono allegare solo file PDF agli ordini")
            '    End If
            'End If
        Else
            MessageBox.Show("Selezionare prima un prodotto")
        End If

    End Sub

    Private Sub RiapriFile()
        If lvwAllegati.SelectedItems.Count Then
            Dim lv As ListViewItem = lvwAllegati.SelectedItems(0)

            FormerHelper.File.ShellExtended(lv.Tag)

        End If

    End Sub

    Private Sub lnkOpenFileSorg_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOpenFileSorg.LinkClicked

        RiapriFile()

    End Sub

    Private Sub lvwAllegati_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvwAllegati.MouseDoubleClick

        RiapriFile()

    End Sub

    Private Sub lnkUseFront_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUseFront.LinkClicked

        If lvwAllegati.SelectedItems.Count Then
            Dim lv As ListViewItem = lvwAllegati.SelectedItems(0)

            If lv.Text.ToLower.EndsWith(".pdf") Then
                If MessageBox.Show("Confermi di voler utilizzare il file '" & lv.Text & "' come sorgente Fronte?", "Sorgente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    txtFronte.Text = lv.Tag
                End If
            Else
                MessageBox.Show("Si possono usare solo file in formato PDF come sorgenti")
            End If

        End If

    End Sub

    Private Sub lnkUseRear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUseRear.LinkClicked
        If lvwAllegati.SelectedItems.Count Then
            Dim lv As ListViewItem = lvwAllegati.SelectedItems(0)

            If lv.Text.ToLower.EndsWith(".pdf") Then
                If MessageBox.Show("Confermi di voler utilizzare il file '" & lv.Text & "' come sorgente Retro?", "Sorgente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    txtRetro.Text = lv.Tag
                End If
            Else
                MessageBox.Show("Si possono usare solo file in formato PDF come sorgenti")
            End If

        End If
    End Sub

    Private Sub lnkConvertiPDF_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkConvertiPDF.LinkClicked

        If lvwAllegati.SelectedItems.Count Then
            Dim lv As ListViewItem = lvwAllegati.SelectedItems(0)

            If lv.Text.ToLower.EndsWith(".jpg") OrElse
               lv.Text.ToLower.EndsWith(".jpeg") OrElse
               lv.Text.ToLower.EndsWith(".png") Then

                Dim NomeNuovo As String = lv.Text & ".pdf"
                Dim PathCompleto As String = PathCartellaDiLavoro & NomeNuovo
                Cursor.Current = Cursors.WaitCursor
                FormerHelper.PDF.ConvertImgToPDF(lv.Tag, PathCompleto)
                Cursor.Current = Cursors.Default

                CaricaCartellaDiLavoro()

            End If
        End If

    End Sub

    Private Sub lnkUnisciPDF_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUnisciPDF.LinkClicked

        If ListaPDFSelezionati.Count > 1 Then

            'Dim ListaPdf(lvwAllegati.SelectedItems.Count) As String

            'For i = 0 To lvwAllegati.SelectedItems.Count - 1
            '    Dim t As String = lvwAllegati.SelectedItems.ToString()
            '    ListaPdf(i) = lvwAllegati.SelectedItems(i).Tag

            'Next

            Dim ListaPdf(ListaPDFSelezionati.Count) As String
            Dim I As Integer = 0
            For Each Sing As String In ListaPDFSelezionati
                ListaPdf(I) = Sing
                I += 1
            Next

            'For i = 0 To lvwAllegati.SelectedItems.Count - 1
            '    Dim t As String = lvwAllegati.SelectedItems.ToString()
            '    ListaPdf(i) = lvwAllegati.SelectedItems(i).Tag

            'Next

            Dim R As New Random
            Dim Casuale As Integer = R.Next(0, 1000)
            Dim NomeFile As String = "FileCombinato." & Casuale & ".pdf"

            NomeFile = InputBox("Inserisci il nome del file che sarà creato unendo i file PDF selezionati", "Nome File Combinato", NomeFile)

            If NomeFile.Length Then
                If NomeFile.EndsWith(".pdf") = False Then NomeFile &= ".pdf"

                Dim PathEnd As String = PathCartellaDiLavoro & NomeFile

                FormerHelper.PDF.MergePdfFiles(ListaPdf, PathEnd)
                CaricaCartellaDiLavoro()
            End If
            ListaPDFSelezionati.Clear()

        Else
            MessageBox.Show("Selezionare almeno 2 file da combinare")
        End If

    End Sub

    Private Sub lnkEstraiPagine_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEstraiPagine.LinkClicked

        If lvwAllegati.SelectedItems.Count Then
            Dim lv As ListViewItem = lvwAllegati.SelectedItems(0)

            If lv.Text.ToLower.EndsWith(".pdf") Then
                Dim NumeroPagine As Integer = FormerHelper.PDF.GetNumeroPagine(lv.Tag)
                If NumeroPagine > 1 Then
                    For i As Integer = 1 To NumeroPagine

                        Dim PathEnd As String = lv.Tag.ToLower.Replace(".pdf", ".p" & i.ToString("0000") & ".pdf")

                        FormerHelper.PDF.EstraiPaginaFromPdf(lv.Tag, PathEnd, i)
                    Next
                Else
                    MessageBox.Show("Il file PDF selezionato contiene una sola pagina")
                End If
                CaricaCartellaDiLavoro()

            End If
        End If

    End Sub

    Private Sub lnkEstraiZip_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEstraiZip.LinkClicked

        If lvwAllegati.SelectedItems.Count Then
            Dim lv As ListViewItem = lvwAllegati.SelectedItems(0)

            If lv.Text.ToLower.EndsWith(".rar") OrElse
                lv.Text.ToLower.EndsWith(".zip") Then

                FormerHelper.File.UncompressFile(lv.Tag, PathCartellaDiLavoro, False)

                MessageBox.Show("Estrazione file terminata")

                CaricaCartellaDiLavoro()

            End If
        End If
    End Sub

    Private Sub txtAppunti_LostFocus(sender As Object, e As EventArgs) Handles txtAppunti.LostFocus
        SalvaAppunti()
    End Sub

    Private Sub lnkSu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSu.LinkClicked
        If Not LRif Is Nothing Then
            SpostaSu()
        End If

    End Sub

    Private Sub lnkGiu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGiu.LinkClicked
        If Not LRif Is Nothing Then
            SpostaGiu()
        End If

    End Sub

    Private Sub lnkDelLavoraz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelLavoraz.LinkClicked
        If Not LRif Is Nothing Then
            If DgLavorazioniSel.SelectedRows.Count Then

                If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim l As FD.Lavorazione = DgLavorazioniSel.SelectedRows(0).DataBoundItem

                    _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & l.IdLavoro & ",", ",")

                    CaricaLavorazioniSelezionate()
                    CalcolaTotaleFornitura()

                End If

            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If
        End If

    End Sub

    Private ListaPDFSelezionati As New List(Of String)

    Private Sub lnkAddLavoraz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddLavoraz.LinkClicked
        If Not LRif Is Nothing Then
            If DgLavorazioni.SelectedRows.Count Then
                Dim l As FD.Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem

                'check se la lavorazione è realizzabile sul prodotto scelto
                Dim BufferError As String = String.Empty

                If l.GrammiMin <> 0 Then
                    If LRif.TipoCarta.Grammi < l.GrammiMin Then
                        BufferError &= " - La lavorazione prevede minimo " & l.GrammiMin & "gr di carta" & ControlChars.NewLine
                    End If
                End If

                If l.GrammiMax <> 0 Then
                    If LRif.TipoCarta.Grammi > l.GrammiMax Then
                        BufferError &= " - La lavorazione prevede massimo " & l.GrammiMin & "gr di carta" & ControlChars.NewLine
                    End If
                End If

                If l.DimensMinW <> 0 And l.DimensMinH <> 0 Then
                    If (LRif.FormatoProdotto.Larghezza < l.DimensMinW Or LRif.FormatoProdotto.Lunghezza < l.DimensMinH) And
                       (LRif.FormatoProdotto.Larghezza < l.DimensMinH Or LRif.FormatoProdotto.Lunghezza < l.DimensMinW) Then
                        BufferError &= " - La lavorazione prevede un formato minimo " & l.DimensMinW & "x" & l.DimensMinH & " di carta" & ControlChars.NewLine
                    End If
                End If

                If l.DimensMaxW <> 0 And l.DimensMaxH <> 0 Then
                    If (LRif.FormatoProdotto.Larghezza > l.DimensMaxW Or LRif.FormatoProdotto.Lunghezza > l.DimensMaxH) And
                       (LRif.FormatoProdotto.Larghezza > l.DimensMaxH Or LRif.FormatoProdotto.Lunghezza > l.DimensMaxW) Then
                        BufferError &= " - La lavorazione prevede un formato massimo " & l.DimensMaxW & "x" & l.DimensMaxH & " di carta" & ControlChars.NewLine
                    End If
                End If

                If BufferError.Length Then
                    BufferError = "Attenzione! " & ControlChars.NewLine & BufferError
                End If

                If _LavorazioniSelezionate.IndexOf("," & l.IdLavoro & ",") = -1 Then
                    If MessageBox.Show("Confermi la modifica? " & BufferError, "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        For Each Id As String In _LavorazioniSelezionate.Split(",")
                            If Id.Length Then
                                Using LV As New FD.Lavorazione
                                    LV.Read(Id)
                                    If Not (LV.Categoria.TipoCaratteristica = enSiNo.Si And LV.Categoria.TipoControllo = enTipoControllo.CheckBox) Then
                                        If LV.IdCatLav = l.IdCatLav Then
                                            _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & LV.IdLavoro, String.Empty)
                                            Exit For
                                        End If
                                    End If
                                End Using
                            End If
                        Next
                        _LavorazioniSelezionate = _LavorazioniSelezionate & l.IdLavoro & ","

                        CaricaLavorazioniSelezionate()
                        CalcolaTotaleFornitura()
                    End If
                Else
                    MessageBox.Show("La lavorazione è gia presente nell'ordine!")
                End If

            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If
        End If

    End Sub

    Private Sub rdoLavOnlyPreviste_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLavOnlyPreviste.CheckedChanged
        CaricaCat()
    End Sub

    Private Sub rdoLavMostraAltre_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLavMostraAltre.CheckedChanged
        CaricaCat()
    End Sub

    Private Sub lnkApriCon_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApriCon.LinkClicked

        If lvwAllegati.SelectedItems.Count Then
            Dim lv As ListViewItem = lvwAllegati.SelectedItems(0)

            FormerLib.FormerHelper.File.OpenWithDialog(lv.Tag)

        End If

    End Sub

    Private Sub lnkElimina_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkElimina.LinkClicked

        If lvwAllegati.SelectedItems.Count Then
            Dim lv As ListViewItem = lvwAllegati.SelectedItems(0)

            If MessageBox.Show("Confermi l'eliminazione del file selezionato?", "Eliminazione File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MgrFormerIO.FileDelete(lv.Tag)
                MessageBox.Show("File eliminato")
                CaricaCartellaDiLavoro()
            End If

        End If

    End Sub

    Private Sub lvwAllegati_MouseClick(sender As Object, e As MouseEventArgs) Handles lvwAllegati.MouseClick

        Dim voce As ListViewItem = lvwAllegati.GetItemAt(e.Location.X, e.Location.Y)

        If voce Is Nothing Then
            If lvwAllegati.Items.Count = 0 Then
                ListaPDFSelezionati.Clear()
            End If
        Else
            If voce.Selected Then
                If My.Computer.Keyboard.CtrlKeyDown = False Then
                    ListaPDFSelezionati.Clear()
                End If
                ListaPDFSelezionati.Add(voce.Tag)
            Else
                ListaPDFSelezionati.Remove(voce.Tag)
            End If
        End If

    End Sub

    Private Sub lvwAllegati_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwAllegati.SelectedIndexChanged

    End Sub

    Private Sub cmbTipoRetro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoRetro.SelectedIndexChanged
        Try
            Dim tipoR As cEnum = cmbTipoRetro.SelectedItem
            If tipoR.Id <> enTipoRetro.RetroDifferente Then
                txtRetro.Text = String.Empty
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lvwAllegati_MouseDown(sender As Object, e As MouseEventArgs) Handles lvwAllegati.MouseDown

    End Sub

    Private Sub lnkAddFileToCart_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFileToCart.LinkClicked

        OpenFileAdd.ShowDialog()

        If OpenFileAdd.FileName.Length Then
            Dim FileName As String = OpenFileAdd.FileName

            Dim FileDest = PathCartellaDiLavoro & FormerHelper.File.EstraiNomeFile(FileName)

            File.Copy(FileName, FileDest)
            CaricaCartellaDiLavoro()

        End If

    End Sub

    Private Sub lnkAddFileToCart_Click(sender As Object, e As EventArgs) Handles lnkAddFileToCart.Click

    End Sub

    Private Sub lblPath_Click(sender As Object, e As EventArgs) Handles lblPath.Click

    End Sub

    Private Sub pctTipo_Click(sender As Object, e As EventArgs) Handles pctTipo.Click
        If FormerDebug.DebugAttivo Then
            CreaOrdineDaInserire()
        End If
    End Sub

    Private Sub txtNomeLavoro_TextChanged(sender As Object, e As EventArgs) Handles txtNomeLavoro.TextChanged
        If sender.focused Then
            If txtNomeLavoro.Text.Trim.Length Then
                chkUsaNomeLavoro.Checked = True
            Else
                chkUsaNomeLavoro.Checked = False
            End If
        End If
    End Sub

    Private Sub chkUsaNomeLavoro_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsaNomeLavoro.CheckedChanged
        If sender.checked Then
            sender.backcolor = Color.Green
            sender.forecolor = Color.White
        Else
            sender.backcolor = Color.White
            sender.forecolor = Color.Black
        End If
    End Sub

    Private Sub cmbSelCliente_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbSelCliente.SelectedIndexChanged
        CaricaDefaultCliente()
        CalcolaTotaleFornitura()
    End Sub

    Private Sub cmbSelCliente_Load(sender As Object, e As EventArgs) Handles cmbSelCliente.Load

    End Sub

    Private Sub lnkDettaglioDisp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDettaglioDisp.LinkClicked
        If DgLavorazioni.SelectedRows.Count Then
            Dim l As FD.Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem
            Sottofondo()
            Using f As New frmListinoLavorazione
                f.Carica(l.IdLavoro)
            End Using
            Sottofondo()
        End If
    End Sub

    Private Sub lnkDettaglioSel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDettaglioSel.LinkClicked
        If DgLavorazioniSel.SelectedRows.Count Then
            Dim l As FD.Lavorazione = DgLavorazioniSel.SelectedRows(0).DataBoundItem
            Sottofondo()
            Using f As New frmListinoLavorazione
                f.Carica(l.IdLavoro)
            End Using
            Sottofondo()
        End If

    End Sub

    Private Sub frmOrdineCreaOnline_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        LUNA.LunaContext.ConnectionString = String.Empty

    End Sub

    Private Sub CmbCorriere_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCorriere.SelectedIndexChanged

        lblDataPrevistaConsegna.Text = CalcolaDataPrevistaConsegna().ToString("dd/MM/yyyy")

    End Sub

    Private Sub txtTotConsigliato_TextChanged(sender As Object, e As EventArgs) Handles txtTotConsigliato.TextChanged
        AggiornaTotDaRicavare()
    End Sub

    Private Sub btnOk_ClientSizeChanged(sender As Object, e As EventArgs) Handles btnOk.ClientSizeChanged

    End Sub

    Private _LastAltezza As Integer = 0
    Private _LastBase As Integer = 0
    Private _LastProfondita As Integer = 0

    Private Sub txtAltezza_LostFocus(sender As Object, e As EventArgs) Handles txtAltezza.LostFocus

        Dim DimensioneValidata As Integer = ValidaDimensione(txtAltezza.Text, 0)
        If DimensioneValidata <> _LastAltezza Then
            _LastAltezza = DimensioneValidata

            Dim EffettuaCalcolo As Boolean = False

            If Not P Is Nothing AndAlso P.IdPluginToUse = enPluginOnline.Packaging Then
                DimensioneValidata = ValidaDimensione(txtAltezza.Text, enAsseXYZ.Altezza)
                txtAltezza.Text = DimensioneValidata
                SelezionaFormatoProdottoDaDimensioni()
                'qui devo andare a selezionare il formato prodotto corretto in caso di packaging 
                EffettuaCalcolo = True
            End If

            If Not LRif Is Nothing Then

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
                    txtAltezza.Text = DimensioneValidata

                End If
                EffettuaCalcolo = True
            End If

            If EffettuaCalcolo = True Then
                CalcolaTotaleFornitura()
                MgrControl.ShowTooltipMqFromCm(txtAltezza, toolTipHelp)
            End If
        End If


    End Sub

    Private Sub txtLarghezza_LostFocus(sender As Object, e As EventArgs) Handles txtLarghezza.LostFocus

        Dim DimensioneValidata As Integer = ValidaDimensione(txtLarghezza.Text, 0)

        If DimensioneValidata <> _LastBase Then
            _LastBase = DimensioneValidata
            Dim EffettuaCalcolo As Boolean = False

            If Not P Is Nothing AndAlso P.IdPluginToUse = enPluginOnline.Packaging Then
                DimensioneValidata = ValidaDimensione(txtLarghezza.Text, enAsseXYZ.Base)
                txtLarghezza.Text = DimensioneValidata
                SelezionaFormatoProdottoDaDimensioni()
                'qui devo andare a selezionare il formato prodotto corretto in caso di packaging 
                EffettuaCalcolo = True
            End If

            If Not LRif Is Nothing Then

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
                    txtLarghezza.Text = DimensioneValidata

                End If
                EffettuaCalcolo = True
            End If

            If EffettuaCalcolo = True Then
                CalcolaTotaleFornitura()
                MgrControl.ShowTooltipMqFromCm(txtLarghezza, toolTipHelp)
            End If
        End If

    End Sub

    Private Sub SelezionaFormatoProdottoDaDimensioni()

        PreventivazioneSelezionata()

    End Sub

    Private Sub txtProfondita_LostFocus(sender As Object, e As EventArgs) Handles txtProfondita.LostFocus

        Dim DimensioneValidata As Integer = ValidaDimensione(txtProfondita.Text, 0)

        If DimensioneValidata <> _LastProfondita Then
            _LastProfondita = DimensioneValidata

            Dim EffettuaCalcolo As Boolean = False

            If Not P Is Nothing AndAlso P.IdPluginToUse = enPluginOnline.Packaging Then
                DimensioneValidata = ValidaDimensione(txtProfondita.Text, enAsseXYZ.Profondita)
                txtProfondita.Text = DimensioneValidata
                SelezionaFormatoProdottoDaDimensioni()
                'qui devo andare a selezionare il formato prodotto corretto in caso di packaging 
                EffettuaCalcolo = True
            End If

            If EffettuaCalcolo = True Then
                CalcolaTotaleFornitura()
            End If
        End If



    End Sub

    Private Sub txtNote_TextChanged(sender As Object, e As EventArgs) Handles txtNote.TextChanged

    End Sub

    Private Sub txtAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza.TextChanged

    End Sub

    Private Sub txtProfondita_TextChanged(sender As Object, e As EventArgs) Handles txtProfondita.TextChanged

    End Sub
End Class