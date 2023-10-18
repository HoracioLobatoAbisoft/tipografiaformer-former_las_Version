Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerLib
Imports FormerConfig
Imports FormerBusinessLogicInterface
Imports Fw = FormerDALWeb

Friend Class ucListinoPreventivazione
    Inherits ucFormerUserControl

    Private _IdRub As Integer = 0
    Friend Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
        End Set
    End Property

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

    End Sub

    Private Sub CaricaCat()

        CaricaNodi()

        'tvwCat.ExpandAll()


        'Dim mgr As New CatProdDAO()


        'Dim Lst As List(Of CatProd) = mgr.GetAll("Descrizione", True)
        'lstCat.DataSource = Lst

    End Sub

    Private Sub CaricaNodi(Optional SoloNascosti As Boolean = False,
                           Optional SoloConVarianti As Boolean = False)

        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()

        Dim ChiaveSelezionata As String = String.Empty

        If Not tvwCat.SelectedNode Is Nothing Then
            ChiaveSelezionata = tvwCat.SelectedNode.Name
        End If

        tvwCat.Nodes.Clear()

        Using mgr As New PreventivazioniDAO()

            Dim Lst As List(Of Preventivazione) = mgr.GetAll("IdReparto,Descrizione")

            tvwCat.Nodes.Add("C0", "*** BOZZE ***", 0, 0)
            Dim Node As TreeNode = tvwCat.Nodes.Add("V0", "CATEGORIE VIRTUALI", 2, 2)
            Node.BackColor = FormerColori.ColoreRepartoDigitale
            Node.ForeColor = Color.White

            'qui carico le categorie virtuali
            If SoloNascosti = False Then
                Using mgrCat As New CatVirtualiDAO
                    Dim l As List(Of CatVirtuale) = mgrCat.GetAll(LFM.CatVirtuale.Nome)
                    For Each singCat As CatVirtuale In l
                        Dim ChiaveCat As String = "V" & singCat.IdCatVirtuale
                        tvwCat.Nodes("V0").Nodes.Add(ChiaveCat, singCat.Nome, 3, 3)

                        Using mgrl As New ListinoBaseDAO
                            Dim lstL As List(Of ListinoBase) = mgrl.ListiniByCatVirtuale(singCat.IdCatVirtuale, enTipoListiniBase.Sorgente)
                            For Each Lb As ListinoBase In lstL
                                tvwCat.Nodes("V0").Nodes(ChiaveCat).Nodes.Add("L" & Lb.IdListinoBase, Lb.NomeEx, 1, 1)
                            Next

                        End Using
                    Next

                End Using
                Node.Expand()
            End If

            Dim parHidden As LUNA.LunaSearchParameter = Nothing
            If SoloNascosti = True Then
                parHidden = New LUNA.LunaSearchParameter(LFM.ListinoBase.NascondiOnline, enSiNo.Si)
            Else
                parHidden = New LUNA.LunaSearchParameter(LFM.ListinoBase.NascondiOnline, enSiNo.Si, "<>")
            End If

            Dim parsource As LUNA.LunaSearchParameter = Nothing
            parsource = New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0)

            'qui carico i listini base nell'albero
            Using mgrl As New ListinoBaseDAO
                Dim lstL As List(Of ListinoBase) = mgrl.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Nome"},
                                                                New LUNA.LunaSearchParameter(LFM.ListinoBase.IdPrev, 0),
                                                                parHidden,
                                                                parsource)
                For Each L As ListinoBase In lstL

                    tvwCat.Nodes("C0").Nodes.Add("L" & L.IdListinoBase, L.NomeEx, 1, 1)

                Next
            End Using

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.StampaOffset, "OFFSET")
            Node.BackColor = FormerColori.ColoreRepartoOffset
            Node.ForeColor = Color.White

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.StampaDigitale, "DIGITALE")
            Node.BackColor = FormerColori.ColoreRepartoDigitale
            Node.ForeColor = Color.White

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.Packaging, "PACKAGING")
            Node.BackColor = FormerColori.ColoreRepartoPackaging
            Node.ForeColor = Color.White

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.Ricamo, "RICAMO")
            Node.BackColor = FormerColori.ColoreRepartoRicamo
            Node.ForeColor = Color.White

            Node = tvwCat.Nodes.Add("R" & enRepartoWeb.Etichette, "ETICHETTE")
            Node.BackColor = FormerColori.ColoreRepartoEtichette
            Node.ForeColor = Color.White

            For Each CategProd As Preventivazione In Lst

                CategProd.CaricaListinoBase(, enTipoListiniBase.Sorgente)

                Dim MostraPrev As Boolean = False

                Dim ListaLb As List(Of ListinoBase) = Nothing

                If SoloNascosti Then
                    listalb = CategProd.ListiniBaseNascosti
                    If CategProd.ListiniBase.Count = 0 OrElse ListaLb.Count <> 0 Then
                        MostraPrev = True
                    End If
                Else
                    ListaLb = CategProd.ListiniBase
                    If CategProd.ListiniBase.Count <> 0 Then
                        MostraPrev = True
                    End If
                End If

                If MostraPrev Then
                    Dim NodoPadre As TreeNode = tvwCat.Nodes("R" & CategProd.IdReparto)

                    Dim LU As String = String.Empty

                    If ListaLb.FindAll(Function(x) x.LastUpdate = enSiNo.Si).Count Then
                        LU = " (New)"
                    End If

                    Dim NodoCat As TreeNode = Nothing

                    'If CategProd.ListiniBase.Count Then
                    NodoCat = NodoPadre.Nodes.Add("C" & CategProd.IdPrev, CategProd.Descrizione & LU, 0, 0)
                    'End If

                    'qui carico i listini base nell'albero
                    For Each L As ListinoBase In ListaLb
                        Dim NodoPadreLB As TreeNode = NodoCat
                        Using fp As New FormatoProdotto
                            fp.Read(L.IdFormProd)
                            If Not fp.Categoria Is Nothing Then
                                Dim NodoCategoriaFP As TreeNode = NodoPadreLB.Nodes("G" & fp.Categoria.IdCatFormatoProdotto)
                                If NodoCategoriaFP Is Nothing Then
                                    NodoCategoriaFP = NodoPadreLB.Nodes.Add("G" & fp.Categoria.IdCatFormatoProdotto, fp.Categoria.Nome, 5, 5)
                                End If
                                NodoPadreLB = NodoCategoriaFP
                            End If
                        End Using

                        Dim NodoFormato As TreeNode = NodoPadreLB.Nodes("F" & L.IdFormProd)
                        If NodoFormato Is Nothing Then
                            NodoFormato = NodoPadreLB.Nodes.Add("F" & L.IdFormProd, L.FormatoProdotto.Formato)
                        End If
                        NodoFormato.Expand()
                        'NodoFormato.Nodes.Add("L" & L.IdListinoBase, L.Riassunto & IIf(L.InEvidenza = enSiNo.Si, " (Evi)", ""), 1, 1)
                        Dim IcoToUse As Integer = 1
                        If L.IsFormerChoice Then
                            IcoToUse = 4
                        End If
                        Dim NodoLb As TreeNode = NodoFormato.Nodes.Add("L" & L.IdListinoBase, L.NomeEx, IcoToUse, IcoToUse)
                        If L.IsFormerChoice Then
                            NodoLb.BackColor = Color.Orange
                        End If

                        If L.ListaVarianti.Count Then

                            Dim NodoVarianti As TreeNode = NodoLb.Nodes.Add("N" & L.IdListinoBase, "Varianti", 6, 6)
                            NodoLb.ExpandAll()
                            For Each Variante In L.ListaVarianti
                                Dim IcoVariante As Integer = 0
                                Dim Descrizione As String = String.Empty

                                Select Case Variante.TipoRiferimento
                                    Case enTipoOggettoListino.ColoreStampa
                                        IcoVariante = 7
                                        Using cs As New ColoreStampa
                                            cs.Read(Variante.IdRiferimento)
                                            Descrizione = cs.Descrizione & IIf(Variante.PercDiminuzione, " (-" & Variante.PercDiminuzione & "%)", "")
                                        End Using
                                    Case enTipoOggettoListino.TipoCarta
                                        IcoVariante = 8
                                        Using cs As New TipoCarta
                                            cs.Read(Variante.IdRiferimento)
                                            Descrizione = cs.Tipologia & IIf(Variante.PercDiminuzione, " (" & Variante.PercDiminuzione & "%)", "")
                                        End Using
                                    Case enTipoOggettoListino.CatLav
                                        IcoVariante = 9
                                        Using cs As New CatLav
                                            cs.Read(Variante.IdRiferimento)
                                            Descrizione = cs.Descrizione
                                        End Using
                                End Select

                                Dim NodoVariante As TreeNode = NodoVarianti.Nodes.Add("D" & Variante.IdGruppoVarianteDett, Descrizione, IcoVariante, IcoVariante)

                            Next
                            NodoVarianti.Expand()

                        End If

                    Next

                    NodoPadre.Expand()

                    'tvwCat.Nodes("C" & CategProd.IdPrev).Expand()
                End If


            Next
        End Using

        If ChiaveSelezionata.Length Then
            Try
                Dim NodoToSel As TreeNode = tvwCat.Nodes.Find(ChiaveSelezionata, True)(0)
                NodoToSel.EnsureVisible()
                tvwCat.SelectedNode = NodoToSel
                tvwCat.Select()
            Catch ex As Exception

            End Try
        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub mnuItem_Clicked(sender As Object, e As EventArgs)
        mnuVoce.Hide() 'Sometimes the menu items can remain open.  May not be necessary for you.
        If tvwCat.SelectedNode.Name.StartsWith("L") Then
            Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
            If item IsNot Nothing Then
                If MessageBox.Show("Confermi lo spostamento del ListinoBase """ & tvwCat.SelectedNode.Text & """ in """ & item.Text & """?", "Spostamento ListinoBase", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim IdRel As Integer = item.Name.Substring(4)
                    Dim IdListinoBase As Integer = tvwCat.SelectedNode.Name.Substring(1)
                    Dim L As New ListinoBase
                    L.Read(IdListinoBase)

                    'qui controllo la tripletta dentro la preventivazione di arrivo

                    Dim OkSpostamento As Boolean = True

                    Using mgr As New ListinoBaseDAO
                        Dim lista As List(Of ListinoBase) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdPrev, IdRel),
                                                                        New LUNA.LunaSearchParameter(LFM.ListinoBase.IdFormProd, L.IdFormProd),
                                                                        New LUNA.LunaSearchParameter(LFM.ListinoBase.IdTipoCarta, L.IdTipoCarta),
                                                                        New LUNA.LunaSearchParameter(LFM.ListinoBase.IdColoreStampa, L.IdColoreStampa))
                        If lista.Count Then OkSpostamento = False
                    End Using

                    If OkSpostamento Then
                        L.IdPrev = IdRel
                        L.CaricaLavorazioni()
                        L.Save()
                        CaricaCat()
                    Else
                        MessageBox.Show("Il listino base non può essere spostato perche nella preventivazione di destinazione è già presente un ListinoBase con stesso Formato Prodotto, Tipo Carta e Colore di Stampa")
                    End If
                End If
            End If
        Else
            Beep()
        End If


    End Sub

    'Private Sub CaricaNodi(ByVal IdPadre As Integer)

    '    Dim mgr As New CatProdDAO()
    '    Dim par1 As New LUNA.LunaSearchParameter("IdCatPadre", IdPadre)
    '    Dim Lst As List(Of CatProd) = mgr.Find("Descrizione", par1)

    '    For Each CategProd As CatProd In Lst
    '        If IdPadre Then
    '            If tvwCat.Nodes.Find("C" & IdPadre, True) Is Nothing Then
    '                tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione, 0, 0)
    '            Else

    '                Dim N2 As TreeNode = tvwCat.Nodes.Find("C" & IdPadre, True)(0)

    '                N2.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione, 0, 0)
    '            End If
    '        Else
    '            tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione, 0, 0)
    '        End If
    '        'tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione)
    '        CaricaNodi(CategProd.IdCatProd)

    '    Next
    'End Sub

    Public Sub Carica()
        Try
            CaricaCat()
        Catch ex As Exception
            '   MessageBox.Show(ex.Message)
        End Try
        'MostraDati()

    End Sub

    'Private Sub MostraDati(Optional ByVal Cerca As String = "")

    '    Dim CatSel As Integer = 0

    '    If Not tvwCat.SelectedNode Is Nothing Then
    '        CatSel = tvwCat.SelectedNode.Name.Substring(1)
    '    End If

    '    If Cerca = "{inserire qui il codice o la descrizione da cercare}" Then Cerca = ""

    '    Dim Prod As New cProdottiColl, dt As DataTable

    '    Dim P1 As New LUNA.LunaSearchParameter("status", 1, "<>")
    '    Dim P2 As New LUNA.LunaSearchParameter("idcatprod", CatSel)
    '    Dim P3 As LUNA.LunaSearchParameter = Nothing
    '    If Cerca.Length Then
    '        P3 = New LUNA.LunaSearchParameter("Codice", Cerca)
    '    End If
    '    Dim P As List(Of Prodotto) = Nothing
    '    If _IdRub Then
    '        dt = Prod.Lista(Cerca, CatSel)
    '    Else
    '        P = (New ProdottiDao).Find("NumPezzi, Codice", P1, P2, P3)
    '    End If

    '    DgListino.AutoGenerateColumns = False
    '    DgListino.DataSource = P

    '    DgListino.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '    DgListino.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgListino.Columns(4).DefaultCellStyle.Format = "0.00"
    '    DgListino.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgListino.Columns(5).DefaultCellStyle.Format = "0.00"
    '    DgListino.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '    DgListino.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgListino.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgListino.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgListino.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgListino.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    'End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        CaricaCat()
    End Sub

    'Private Sub lnkAllarga_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    If DgListino.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells Then
    '        DgListino.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    '        lnkAllarga.Text = "Espandi"
    '    Else
    '        DgListino.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '        lnkAllarga.Text = "Adatta"
    '    End If
    '    DgListino.AutoResizeColumns()
    'End Sub

    'Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    ParentFormerForm.Sottofondo 
    '    Dim Titolo As String = ""
    '    If _IdRub Then
    '        Titolo = "Listino Personale"
    '    Else
    '        Titolo = "Listino"
    '    End If
    '    StampaGlobale(Titolo, DgListino)
    '    ParentFormerForm.Sottofondo 
    'End Sub

    'Private Sub lnkCerca_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    Cerca()

    'End Sub
    'Private Sub Cerca()

    '    If txtCercaCli.Text = "{inserire qui il codice o la descrizione da cercare}" Then
    '        MessageBox.Show("Inserire il codice del prodotto o parte della descrizione per effettuare la ricerca", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    Else
    '        MostraDati(txtCercaCli.Text)
    '    End If
    'End Sub
    'Private Sub txtCercaCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim c As Char = vbCr
    '    If e.KeyChar = c Then Cerca()
    'End Sub

    'Private Sub txtCercaCli_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If txtCercaCli.Text = "{inserire qui il codice o la descrizione da cercare}" Then

    '        txtCercaCli.Text = ""

    '    End If
    'End Sub

    'Private Sub NewVoce()
    '    Dim frmRif As New frmProdotto
    '    Dim ObjRif As New Prodotto
    '    Dim Ris As Integer = 0

    '    ParentFormerForm.Sottofondo 
    '    Ris = frmRif.Carica(ObjRif)
    '    ParentFormerForm.Sottofondo 
    '    If Ris Then MostraDati(txtCercaCli.Text)
    '    frmRif.Dispose()
    '    ObjRif = Nothing
    'End Sub

    'Private Sub NewListino()
    '    Dim frmRif As New frmListPers

    '    Dim Ris As Integer = 0

    '    ParentFormerForm.Sottofondo 
    '    Ris = frmRif.Carica(, _IdRub)
    '    ParentFormerForm.Sottofondo 
    '    If Ris Then MostraDati(txtCercaCli.Text)
    '    frmRif.Dispose()

    'End Sub


    'Private Sub RiapriVoce()

    '    Dim IdVoce As Integer
    '    IdVoce = DirectCast(DgListino.SelectedRows(0).DataBoundItem, Prodotto).IdProd

    '    If _IdRub Then

    '        Dim frmRif As New frmListPers

    '        Dim Ris As Integer = 0

    '        ParentFormerForm.Sottofondo 
    '        Ris = frmRif.Carica(IdVoce, _IdRub)
    '        ParentFormerForm.Sottofondo 
    '        If Ris Then MostraDati(txtCercaCli.Text)
    '        frmRif.Dispose()

    '    Else
    '        Dim OggRif As New Prodotto, Ris As Integer = 0

    '        OggRif.Read(IdVoce)

    '        Dim frmRif As New frmProdotto
    '        ParentFormerForm.Sottofondo 
    '        Ris = frmRif.Carica(OggRif)
    '        ParentFormerForm.Sottofondo 

    '        If Ris Then MostraDati(txtCercaCli.Text)
    '        frmRif.Dispose()
    '        OggRif = Nothing
    '    End If
    'End Sub

    'Private Sub EliminaVoce()
    '    Dim IdVoce As Integer
    '    IdVoce = DirectCast(DgListino.SelectedRows(0).DataBoundItem, Prodotto).IdProd


    '    If MessageBox.Show("Confermi l'eliminazione della voce selezionata?", Postazione.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

    '        Dim OggRif As New ProdottiDAO

    '        OggRif.Delete(IdVoce)
    '        MostraDati(txtCercaCli.Text)

    '        OggRif = Nothing


    '    End If

    'End Sub

    'Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    If _IdRub Then
    '        NewListino()
    '    Else
    '        NewVoce()
    '    End If


    'End Sub

    'Private Sub DgListino_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    RiapriVoce()
    'End Sub

    'Private Sub DgListino_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    '    If e.Button = Windows.Forms.MouseButtons.Right Then

    '        Dim x As System.Drawing.Point = MousePosition
    '        'btnNuovoCliente.ContextMenu = menuNuovo.
    '        x = MousePosition
    '        'x = lnkNew.PointToClient(x)

    '        Dim rig As DataGridViewRow
    '        Dim RigaSel As Integer = e.RowIndex

    '        If RigaSel <> -1 Then
    '            rig = DgListino.Rows(RigaSel)
    '            rig.Selected = True
    '            DgListino.Select()
    '            mnuVoce.Show(x)
    '        End If

    '    End If

    'End Sub

    'Private Sub ModificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaToolStripMenuItem.Click
    '    RiapriVoce()
    'End Sub

    'Private Sub EliminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaToolStripMenuItem.Click
    '    EliminaVoce()
    'End Sub

    'Private Sub txtCercaCli_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub DgListino_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    'End Sub

    'Private Sub lnkExport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    Try

    '        Dim Dt As DataTable
    '        Dim Prod As New cProdottiColl
    '        Dt = Prod.ListaExport
    '        Prod = Nothing

    '        Dim Cat As New CatProdDAO(), dtCat As DataTable

    '        dtCat = Cat.ElencoExport

    '        Dim PathLocaleListino As String = FormerPath.PathLocale & "listino.xml"
    '        Dim PathLocaleListinoCat As String = FormerPath.PathLocale & "listinocat.xml"
    '        Dim PathRemotoListino As String = "tipografiaformer.com/listino/listino.xml"

    '        Dim xmlSWCat As System.IO.StreamWriter = New System.IO.StreamWriter(PathLocaleListinoCat)
    '        dtCat.WriteXml(xmlSWCat, XmlWriteMode.WriteSchema)
    '        xmlSWCat.Close()

    '        Dim xmlSW As System.IO.StreamWriter = New System.IO.StreamWriter(PathLocaleListino)
    '        Dt.WriteXml(xmlSW, XmlWriteMode.WriteSchema)
    '        xmlSW.Close()

    '        Dim Corr As New CorrieriDAO
    '        Dt = Corr.ListaCorrieriPerListino
    '        Corr = Nothing

    '        Dim PathLocaleCorriere As String = FormerPath.PathLocale & "corriere.xml"
    '        Dim PathRemotoCorriere As String = "tipografiaformer.com/listino/corriere.xml"

    '        Dim xmlSWCorr As System.IO.StreamWriter = New System.IO.StreamWriter(PathLocaleCorriere)
    '        Dt.WriteXml(xmlSWCorr, XmlWriteMode.WriteSchema)
    '        xmlSWCorr.Close()

    '        'ora lo pubblico su internet
    '        'DISATTIVO PUBBLICAZIONE SU INTERNET 
    '        'If FormerDebug.DebugAttivo = False Then

    '        Dim Ftp As New FTPclient(Postazione.FTPServer, Postazione.FTPLogin, Postazione.FTPPwd)

    '        MgrIO.FtpTransfer(Me.ParentForm, Ftp, PathLocaleListino, PathRemotoListino, enTipoOpFTP.Upload)
    '        MgrIO.FtpTransfer(Me.ParentForm, Ftp, PathLocaleCorriere, PathRemotoCorriere, enTipoOpFTP.Upload)

    '        Ftp = Nothing

    '        'End If

    '        'qui faccio l'export html del listino clienti e rivenditori e lo pubblico su internet

    '        EsportaListinoHtml(False)
    '        EsportaListinoHtml(False, "aspx")
    '        EsportaListinoHtml(True)
    '        EsportaListinoHtml(True, "aspx")

    '        'pubblico il listino su web
    '        Dim PathListinoWebLocale As String = FormerPath.PathLocale & "listino\listinoriv.aspx"
    '        Dim PathListinoWebRemoto As String = "tipografiaformer.it/listino/listinoriv.aspx"
    '        Dim PathListinoWebLocaleC As String = FormerPath.PathLocale & "listino\listinocli.aspx"
    '        Dim PathListinoWebRemotoC As String = "tipografiaformer.it/listino/listinocli.aspx"

    '        Dim PathListinoWebLocaleCli As String = FormerPath.PathLocale & "listino\listinoriv.html"
    '        Dim PathListinoWebRemotoCli As String = "tipografiaformer.it/listino/listinoriv.html"
    '        Dim PathListinoWebLocaleCliC As String = FormerPath.PathLocale & "listino\listinocli.html"
    '        Dim PathListinoWebRemotoCliC As String = "tipografiaformer.it/listino/listinocli.html"

    '        Dim PathListinoWebRemotoXml As String = "tipografiaformer.it/listino/listino.xml"
    '        Dim PathListinoCatWebRemotoXml As String = "tipografiaformer.it/listino/listinocat.xml"
    '        Dim PathCorriereWebRemotoXml As String = "tipografiaformer.it/listino/corriere.xml"

    '        Dim Ftp2 As New FTPclient(Postazione.FTPServer2, Postazione.FTPLogin, Postazione.FTPPwd)

    '        MgrIO.FtpTransfer(Me.ParentForm, Ftp2, PathListinoWebLocale, PathListinoWebRemoto, enTipoOpFTP.Upload)
    '        MgrIO.FtpTransfer(Me.ParentForm, Ftp2, PathListinoWebLocaleC, PathListinoWebRemotoC, enTipoOpFTP.Upload)

    '        MgrIO.FtpTransfer(Me.ParentForm, Ftp2, PathListinoWebLocaleCli, PathListinoWebRemotoCli, enTipoOpFTP.Upload)
    '        MgrIO.FtpTransfer(Me.ParentForm, Ftp2, PathListinoWebLocaleCliC, PathListinoWebRemotoCliC, enTipoOpFTP.Upload)

    '        MgrIO.FtpTransfer(Me.ParentForm, Ftp2, PathLocaleListino, PathListinoWebRemotoXml, enTipoOpFTP.Upload)
    '        MgrIO.FtpTransfer(Me.ParentForm, Ftp2, PathLocaleListinoCat, PathListinoCatWebRemotoXml, enTipoOpFTP.Upload)
    '        MgrIO.FtpTransfer(Me.ParentForm, Ftp2, PathLocaleCorriere, PathCorriereWebRemotoXml, enTipoOpFTP.Upload)

    '        Ftp2 = Nothing

    '        Dim x As New Process

    '        x.StartInfo.FileName = "http://www.tipografiaformer.it/listino/listinoriv.aspx"
    '        x.Start()


    '        ' MessageBox.Show("Listino pubblicato correttamente!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    Catch ex As Exception
    '        ManageError(ex, "Pubblicazione listino aggiornato")
    '    End Try


    'End Sub

    'Private Sub EsportaListinoHtml(ByVal Riv As Boolean, Optional ByVal extension As String = "html")

    '    Dim PathLocale As String = FormerPath.PathLocale & "listino\"

    '    If Riv Then
    '        PathLocale &= "listinoriv." & extension
    '    Else
    '        PathLocale &= "listinocli." & extension
    '    End If

    '    Dim Buffer As String = ""

    '    Buffer &= "<HTML><HEAD><TITLE>Listino Aggiornato al " & Now.Date.ToLongDateString & "</TITLE></HEAD>"
    '    Buffer &= "<BODY BGCOLOR=""e1e1e1"">"

    '    Buffer &= "<CENTER><TABLE BGCOLOR=""WHITE"" WIDTH=1000 BORDER=0 CELLPADDING=0 CELLSPACING=0>"
    '    Buffer &= "<TR><TD COLSPAN=2><IMG SRC=""Header.png"" BORDER=0></TD></TR>"
    '    Buffer &= "<TR BGCOLOR=""#116118"" height=100><TD COLSPAN=2 align=Right><FONT SIZE=6 face=""Segoe UI"" COLOR=""WHITE"">listino <FONT SIZE=7>20<FONT COLOR=""ORANGE"">" & Now.Year.ToString.Substring(2) & "</FONT><BR><FONT SIZE=4 face=""Segoe UI"" COLOR=""WHITE"">Listino Riservato" & IIf(Riv, " Rivenditori&nbsp;&nbsp;", " Clienti&nbsp;&nbsp;") & "</TD></TR>"
    '    Buffer &= "<TR BGCOLOR=""#acf62c""><TD COLSPAN=2><FONT SIZE=6 face=""Segoe UI"" COLOR=""WHITE"">Indice<BR><BR>"


    '    Dim mgr As New CatProdDAO()
    '    Dim par1 As New LUNA.LunaSearchParameter("IdCatPadre", 0)
    '    Dim Lst As List(Of CatProd) = mgr.Find("Descrizione", par1)

    '    For Each CategProd As CatProd In Lst
    '        Buffer &= "<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0>"
    '        Buffer &= "<TR><TD style=""border-bottom:1px dotted black;""><FONT SIZE=3 face=""Segoe UI"" COLOR=""BLACK"">" & CategProd.Descrizione & " <A HREF=""#A" & CategProd.IdCatProd & """><IMG SRC=""arrow.png"" border=0></A></TD>"
    '        Buffer &= "<TD align=right style=""border-bottom:1px dotted black;""><A HREF=""#A" & CategProd.IdCatProd & """><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">clicca qui</A></TD></TR>"

    '        Buffer &= "</TABLE>"
    '    Next

    '    Buffer &= "</TD></TR>"
    '    For Each CategProd As CatProd In Lst
    '        Buffer &= "<TR><TD><BR></TD></TR><TR BGCOLOR=""#116118""><TD COLSPAN=2><CENTER><FONT SIZE=4 FACE=""Segoe UI"" COLOR=""WHITE""><A NAME=""A" & CategProd.IdCatProd & """>" & CategProd.Descrizione & "</A></CENTER></FONT></TD></TR>"
    '        If CategProd.ImgCat.Length Then
    '            Buffer &= "<TR><TD COLSPAN=2><IMG SRC=""" & CategProd.ImgCat & """ BORDER=0></TD></TR>"
    '        End If

    '        Dim par2 As New LUNA.LunaSearchParameter("IdCatPadre", CategProd.IdCatProd)
    '        Dim LstFigli As List(Of CatProd) = mgr.Find("Descrizione", par2)
    '        For Each CategProdFiglio As CatProd In LstFigli
    '            Buffer &= "<TR><TD COLSPAN=2><FONT SIZE=2 FACE=""Segoe UI"" COLOR=""BLACK""><BR><B>" & CategProdFiglio.Descrizione.ToUpper & "</B><BR>" & CategProdFiglio.DescrizioneLunga & "</CENTER></FONT></TD></TR>"
    '            'qui carico le caratteristiche e i dettagli
    '            Buffer &= "<TR><TD valign=TOP align=center width=200><BR>"
    '            Dim mgrCaratProd As New CatCaratDAO()
    '            Dim Par4 As New LUNA.LunaSearchParameter("IdCatProd", CategProdFiglio.IdCatProd)
    '            Dim LstCatCarat As List(Of CatCarat) = mgrCaratProd.Find(Par4)
    '            For Each CarattProd As CatCarat In LstCatCarat
    '                Dim mgrCarat As New CaratProdDAO()
    '                Dim caratt As CaratProd = mgrCarat.Read(CarattProd.IdCaratProd)

    '                Buffer &= "<IMG SRC=""" & caratt.ImgCarat & """ BORDER=0 ALT=""" & caratt.NomeCarat & """ width=" & caratt.Width & "><BR>"

    '            Next

    '            Buffer &= "</TD><TD valign=TOP ><BR>"
    '            Buffer &= "<TABLE WIDTH=""100%"" CELLPADDING=0 CELLSPACING=0 BORDER=0>"
    '            Buffer &= "<TR bgcolor=""adadad""><TD><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">Cod.</TD>"
    '            Buffer &= "<TD><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">Q.ta</TD>"
    '            Buffer &= "<TD><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">Tipo prodotto</TD>"
    '            Buffer &= "<TD><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">formato</TD>"
    '            Buffer &= "<TD align=""right""><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK""><B>Prezzo</B></TD>"
    '            If extension = "aspx" Then Buffer &= "<TD>&nbsp;</TD>"
    '            Buffer &= "</TR>"
    '            Dim mgrProd As New ProdottiDAO()
    '            Dim Par3 As New LUNA.LunaSearchParameter("IdCatProd", CategProdFiglio.IdCatProd)
    '            Dim LstProd As List(Of Prodotto) = mgrProd.Find("NumPezzi", Par3)
    '            For Each Prodotto As Prodotto In LstProd
    '                Buffer &= "<TR><TD style=""border-bottom:1px dotted #e1e1e1;""><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">" & Prodotto.Codice & "</TD>"
    '                Buffer &= "<TD style=""border-bottom:1px dotted #e1e1e1;""><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">" & Prodotto.NumPezzi & "</TD>"
    '                Buffer &= "<TD style=""border-bottom:1px dotted #e1e1e1;""><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">" & Prodotto.Descrizione & "</TD>"
    '                Buffer &= "<TD style=""border-bottom:1px dotted #e1e1e1;""><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">" & "" & "</TD>"
    '                Buffer &= "<TD  style=""border-bottom:1px dotted #e1e1e1;"" bgcolor=""adadad"" align=""right""><FONT SIZE=3 face=""Segoe UI"" COLOR=""BLACK""><B>&euro; " & FormattaPrezzo(IIf(Riv, Prodotto.Prezzo, Prodotto.PrezzoPubbl)) & "</TD>"
    '                If extension = "aspx" Then Buffer &= "<TD width=""30"" style=""border-bottom:1px dotted #e1e1e1;""><A HREF=""../neworder.aspx?id=" & Prodotto.Codice & """><IMG width=""30"" SRC=""../img/carrello.gif"" border=0></A></TD>"
    '                Buffer &= "</TR>"
    '            Next

    '            Buffer &= "<TR><TD colspan=" & IIf(extension = "aspx", "6", "5")
    '            Buffer &= " align=right><A HREF=""#""><IMG SRC=""tornasu.png"" BORDER=0><FONT SIZE=2 face=""Segoe UI"" COLOR=""BLACK"">torna all'indice</A></TD></TR>"
    '            Buffer &= "</TABLE>"
    '            Buffer &= "</TD></TR>"

    '        Next

    '    Next

    '    Buffer &= "</TABLE></CENTER>"
    '    Buffer &= "</BODY></HTML>"

    '    Dim xmlSWCorr As System.IO.StreamWriter = New System.IO.StreamWriter(PathLocale)
    '    xmlSWCorr.Write(Buffer)
    '    xmlSWCorr.Close()


    'End Sub

    'Private Sub tvwCat_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwCat.AfterSelect
    '    MostraDati()
    'End Sub

    Private Sub lnkNewCat_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Dim Ris As Integer = 0

        Using n As New frmListinoPreventivazione
            ParentFormEx.Sottofondo()
            Ris = n.Carica()
            ParentFormEx.Sottofondo()
        End Using

        If Ris Then CaricaCat()

    End Sub

    Private Sub AggiungiListinoBase()

        If Not tvwCat.SelectedNode Is Nothing Then

            Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

            If tvwCat.SelectedNode.Name.StartsWith("C") Then
                ParentFormEx.Sottofondo()
                Dim a As New frmListinoBase
                Dim L As New ListinoBase

                Dim P As New Preventivazione

                If IdRel Then
                    P.Read(IdRel)
                End If

                Dim Ris As Integer = a.Carica(L, P)

                If Ris Then CaricaCat()

                ParentFormEx.Sottofondo()
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub ModificaVoce()

        'riapro la voce

        If Not tvwCat.SelectedNode Is Nothing Then

            Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

            If tvwCat.SelectedNode.Name.StartsWith("C") Then
                If IdRel Then
                    ParentFormEx.Sottofondo()
                    Dim f As New frmListinoPreventivazione
                    Dim Ris As Integer = f.Carica(IdRel)
                    ParentFormEx.Sottofondo()
                    'If Ris Then
                    '    CaricaCat()
                    'End If

                Else
                    Beep()
                End If
            ElseIf tvwCat.SelectedNode.Name.StartsWith("L") Then
                Dim L As New ListinoBase
                L.Read(IdRel)
                L.CaricaLavorazioni()
                'L.CaricaLavorazioniBase()
                'L.CaricaLavorazioniOpz()
                ParentFormEx.Sottofondo()
                Dim a As New frmListinoBase

                If a.Carica(L) Then
                    ' CaricaCat()
                End If

                L = Nothing
                ParentFormEx.Sottofondo()
            ElseIf tvwCat.SelectedNode.Name.StartsWith("V") Then

                ParentFormEx.Sottofondo()
                Using a As New frmListinoCatVirtuale

                    If a.Carica(IdRel) Then
                        'CaricaCat()
                    End If

                End Using
                ParentFormEx.Sottofondo()
            ElseIf tvwCat.SelectedNode.Name.StartsWith("G") Then

                ParentFormEx.Sottofondo()
                Using a As New frmListinoCatFormato

                    If a.Carica(IdRel) Then
                        'CaricaCat()
                    End If

                End Using
                ParentFormEx.Sottofondo()
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub lnkModifica_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        'Dim n As New frmWizCat
        'ParentFormerForm.Sottofondo 
        'n.Carica()
        'ParentFormerForm.Sottofondo 
        'n = Nothing


        'Exit Sub
        ''TODO: RIATTIVARE
        ''riapro la categoria selezionata
        'If Not tvwCat.SelectedNode Is Nothing Then


        '    Dim IdCatSel As Integer = 0
        '    IdCatSel = tvwCat.SelectedNode.Name.Substring(1)

        '    Dim frmCat As New frmCatProd
        '    ParentFormerForm.Sottofondo 
        '    frmCat.Carica(IdCatSel)
        '    ParentFormerForm.Sottofondo 
        'End If

    End Sub

    'Private Sub btnEspandi_Click(sender As System.Object, e As System.EventArgs) Handles btnEspandi.Click
    '    tvwCat.ExpandAll()
    'End Sub

    'Private Sub btnRiduci_Click(sender As System.Object, e As System.EventArgs) Handles btnRiduci.Click
    '    tvwCat.CollapseAll()
    'End Sub

    'Private Sub lnkPubblico_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    ParentFormerForm.Sottofondo 
    '    Dim x As New frmListinoCli
    '    x.Carica()
    '    ParentFormerForm.Sottofondo 

    '    x = Nothing
    'End Sub

    Private Sub tvwCat_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwCat.AfterSelect
        'anteprima

        AnteprimaVoce()

    End Sub

    Private Sub AnteprimaVoce()

        'Exit Sub
        'cancello la preventivazione selezionata
        If Not tvwCat.SelectedNode Is Nothing Then
            If tvwCat.SelectedNode.Name.StartsWith("L") Then
                Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

                Dim L As New ListinoBase
                L.Read(IdRel)

                Dim Url As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")

                Dim buffer As String = "<center>"
                Dim bufferRiga As String = "<img src=""$"" style='border:3px solid #d6e03d;'><br/>Dimensioni <b>?kb</b><br/><br/>"
                Dim Dimensione As String = String.Empty

                Try
                    Dim fFirst As New FileInfo(L.ImgSito)

                    Dimensione = Math.Ceiling(fFirst.Length / 1024)

                    buffer &= bufferRiga.Replace("$", L.ImgSito).Replace("?", Dimensione)
                Catch ex As Exception

                End Try


                Dim PathFotoHd As String = FormerPath.PathListinoFoto & L.IdListinoBase

                If Directory.Exists(PathFotoHd) = False Then
                    FormerLib.FormerHelper.File.CreateLongPath(PathFotoHd)
                    '            Directory.CreateDirectory(PathFotoHd)
                End If

                Try
                    Dim dHD As New DirectoryInfo(PathFotoHd)
                    For Each fileImg In dHD.GetFiles
                        If fileImg.Extension.ToLower = ".jpg" OrElse
                   fileImg.Extension.ToLower = ".png" Then
                            Dim bufferrigasing As String = bufferRiga.Replace("$", fileImg.FullName)

                            dimensione = Math.Ceiling(fileImg.Length / 1024)
                            bufferrigasing = bufferrigasing.Replace("?", Dimensione)

                            buffer &= bufferrigasing

                        End If
                    Next
                Catch ex As Exception

                End Try

                buffer &= "</center>"

                Using w As New StreamWriter(Url)
                    w.Write(buffer)
                End Using


                'Url = "http://former-server/" & L.IdPrev & "/" & L.IdFormProd & "/" & L.IdTipoCarta & "/" & L.IdColoreStampa & "/" & (L.FaccMin / 2) & "/Server-Di-Test"

                UcAnteprima.Carica(Url)
            Else
                UcAnteprima.Carica("about:blank")
            End If

            'If tvwCat.SelectedNode.Name.StartsWith("C") Then
            '    Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

            '    Dim P As New Preventivazione
            '    P.Read(IdRel)

            '    Dim PathAnte As String = P.Anteprima()

            '    UcAnteprima.Carica(PathAnte)
            'ElseIf tvwCat.SelectedNode.Name.StartsWith("L") Then
            '    Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

            '    Dim L As New ListinoBase
            '    L.Read(IdRel)

            '    Dim Url As String = ""


            '    Url = "http://former-server/" & L.IdPrev & "/" & L.IdFormProd & "/" & L.IdTipoCarta & "/" & L.IdColoreStampa & "/" & (L.FaccMin / 2) & "/Server-Di-Test"

            '    UcAnteprima.Carica(Url)
            'End If

        End If

    End Sub

    Private Sub AddFotoHD()

        Dim Node As TreeNode = tvwCat.SelectedNode

        If Node Is Nothing Then
            MessageBox.Show("Seleziona un Listino Base dall'albero", "Foto HD", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            'qui semplicemente apro la cartella e se non c'e' la creo 
            Dim IdL As Integer = Node.Name.Substring(1)
            Dim PathFotoHd As String = FormerPath.PathListinoFoto & IdL

            If Directory.Exists(PathFotoHd) = False Then
                Directory.CreateDirectory(PathFotoHd)
            End If

            'FormerHelper.File.ShellExtended(PathFotoHd)

            Dim Ris As String = String.Empty

            ParentFormEx.Sottofondo()
            Using f As New frmOpenIMG
                Ris = f.Carica(800, 267)
            End Using
            ParentFormEx.Sottofondo()

            If Ris.Length Then

                MgrIO.FileCopia(Me.ParentFormEx, Ris, PathFotoHd & "\" & FormerLib.FormerHelper.File.EstraiNomeFile(Ris))

            End If

        End If

    End Sub

    Private Sub ManageFotoHD()
        Dim Node As TreeNode = tvwCat.SelectedNode

        If Node Is Nothing Then
            MessageBox.Show("Seleziona un Listino Base dall'albero", "Foto HD", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            'qui semplicemente apro la cartella e se non c'e' la creo 
            Dim IdL As Integer = Node.Name.Substring(1)
            Dim PathFotoHd As String = FormerPath.PathListinoFoto & IdL

            If Directory.Exists(PathFotoHd) = False Then
                Directory.CreateDirectory(PathFotoHd)
            End If

            FormerHelper.File.ShellExtended(PathFotoHd)

        End If
    End Sub

    Private Sub lnkDatWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub DatiWeb()

        Dim Node As TreeNode = tvwCat.SelectedNode

        If Node Is Nothing Then
            MessageBox.Show("Seleziona un Listino Base dall'albero", "Dati Web", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If Node.Name.StartsWith("L") Then
                'qui semplicemente apro la cartella e se non c'e' la creo 
                Dim IdL As Integer = Node.Name.Substring(1)
                ParentFormEx.Sottofondo()

                Using fr As New frmListinoDatiWebLB
                    fr.Carica(IdL)
                End Using
                ParentFormEx.Sottofondo()
            Else
                MessageBox.Show("Seleziona un Listino Base dall'albero", "Dati Web", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

    End Sub


    Private Sub CheckDati()
        Dim Buffer As String = String.Empty
        Dim PathTxt As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".txt")

        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.ListiniUtilizzabili(True)
            For Each lb As ListinoBase In l
                Dim ListaErr As String = String.Empty

                lb.CaricaLavorazioni()

                Dim ListL As New List(Of ILavorazioneB)

                For Each Lav As Lavorazione In lb.LavorazioniBase
                    ListL.Add(Lav)
                Next

                Dim p1 As Single = lb.p1
                Dim p2 As Single = lb.p2
                Dim p3 As Single = lb.p3
                Dim p4 As Single = lb.p4
                Dim p5 As Single = lb.p5
                Dim p6 As Single = lb.p6

                lb.NumFacciate = lb.FaccMin

                Dim _RisultatoCalcolo As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(lb, ListL)

                If lb.p1 <> p1 Or lb.p2 <> p2 Or lb.p3 <> p3 Or lb.p4 <> p4 Or lb.p5 <> p5 Or lb.p6 <> p6 Then
                    ListaErr &= " - Percentuali di attenuazione non congruenti" & ControlChars.NewLine
                    ListaErr &= "   Salvate: (" & p1 & ")(" & p2 & ")(" & p3 & ")(" & p4 & ")(" & p5 & ")(" & p6 & ")" & ControlChars.NewLine
                    ListaErr &= "   Calcolate: (" & lb.p1 & ")(" & lb.p2 & ")(" & lb.p3 & ")(" & lb.p4 & ")(" & lb.p5 & ")(" & lb.p6 & ")" & ControlChars.NewLine
                End If

                If lb.Preventivazione.DescrizioneEstesa.Trim.Length = 0 Then
                    ListaErr &= " - Preventivazione, Manca descrizione estesa" & ControlChars.NewLine
                End If

                If lb.DescrSito.Trim.Length = 0 Then
                    ListaErr &= " - Listino Base, Manca descrizione sito" & ControlChars.NewLine
                End If

                If lb.GoogleSEO.Trim.Length = 0 Then
                    ListaErr &= " - Listino Base, Manca descrizione SEO" & ControlChars.NewLine
                End If

                If lb.GoogleDescr.Trim.Length = 0 Then
                    ListaErr &= " - Listino Base, Manca descrizione Google" & ControlChars.NewLine
                End If

                If lb.FormatoProdotto.PdfTemplate.Trim.Length = 0 Then
                    ListaErr &= " - Formato Prodotto, Manca template PDF" & ControlChars.NewLine
                End If

                'qui devo controllare le foto HD

                'qui semplicemente apro la cartella e se non c'e' la creo 
                Dim PathFotoHd As String = FormerPath.PathListinoFoto & lb.IdListinoBase
                Dim direc As New DirectoryInfo(PathFotoHd)

                If Directory.Exists(PathFotoHd) = False OrElse direc.GetFiles.Count = 0 Then
                    ListaErr &= " - Listino Base, Mancano Foto HD" & ControlChars.NewLine
                End If

                If ListaErr.Length Then
                    Buffer &= "*** " & lb.NomeEx & ControlChars.NewLine
                    Buffer &= ListaErr & ControlChars.NewLine & ControlChars.NewLine
                End If

            Next

        End Using

        If Buffer.Length Then
            Using w As New StreamWriter(PathTxt)
                w.Write(Buffer)
            End Using

            FormerHelper.File.ShellExtended(PathTxt)
        Else
            MessageBox.Show("Tutto il listino risulta correttamente compilato")
        End If

    End Sub


    Private Sub ModificaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaToolStripMenuItem.Click

        ModificaVoce()

    End Sub

    Private Sub AggiungiPreventivazioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggiungiPreventivazioneToolStripMenuItem.Click
        Dim Ris As Integer = 0
        Using n As New frmListinoPreventivazione
            ParentFormEx.Sottofondo()
            Ris = n.Carica()
            ParentFormEx.Sottofondo()
        End Using

        If Ris Then CaricaCat()

    End Sub

    Private Sub AggiungiListinoBaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggiungiListinoBaseToolStripMenuItem.Click
        AggiungiListinoBase()
    End Sub

    Private Sub ApriCartellaAppuntiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriCartellaAppuntiToolStripMenuItem.Click
        ApriCartellaAppunti()
    End Sub

    Private Sub ApriCartellaAppunti()

        If Not tvwCat.SelectedNode Is Nothing Then

            Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

            If tvwCat.SelectedNode.Name.StartsWith("L") Then
                If tvwCat.SelectedNode.Parent.Name.Substring(1) = "0" Then
                    Dim L As New ListinoBase
                    L.Read(IdRel)

                    Dim Path As String = FormerPath.PathLocale & "appunti\" & FormerHelper.Web.NormalizzaUrl(L.Nome) & "\"

                    FormerHelper.File.CreateLongPath(Path)

                    FormerHelper.File.ShellExtended(Path)
                    L = Nothing
                End If
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub tvwCat_MouseDown(sender As Object, e As MouseEventArgs) Handles tvwCat.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim NodoSel As TreeNode = tvwCat.GetNodeAt(e.X, e.Y)

            If Not NodoSel Is Nothing Then

                If NodoSel.Name.StartsWith("C") = True OrElse
                    NodoSel.Name.StartsWith("L") = True OrElse
                    NodoSel.Name.StartsWith("V") = True OrElse
                    NodoSel.Name.StartsWith("G") = True Then
                    tvwCat.SelectedNode = NodoSel

                    'We have a reference to menu1 already, but here's how you can find the menu item by name...
                    SpostaListinoBaseInToolStripMenuItem.DropDownItems.Clear()

                    Dim ChiavePrev As String = String.Empty
                    If NodoSel.Name.StartsWith("C") Then
                        ChiavePrev = NodoSel.Name
                    ElseIf NodoSel.Name.StartsWith("V") = False Then
                        ChiavePrev = NodoSel.Parent.Name
                    End If

                    For Each nodoP As TreeNode In tvwCat.Nodes
                        If nodoP.Name = "C0" Then
                            Dim menu2 As New ToolStripMenuItem() With {.Text = nodoP.Text, .Name = "mnu" & nodoP.Name}
                            SpostaListinoBaseInToolStripMenuItem.DropDownItems.Add(menu2)
                            AddHandler menu2.Click, AddressOf mnuItem_Clicked
                        Else
                            For Each nodo As TreeNode In tvwCat.Nodes(nodoP.Name).Nodes
                                If nodo.Name <> ChiavePrev Then
                                    Dim menu2 As New ToolStripMenuItem() With {.Text = nodoP.Text & "\" & nodo.Text, .Name = "mnu" & nodo.Name}
                                    SpostaListinoBaseInToolStripMenuItem.DropDownItems.Add(menu2)
                                    AddHandler menu2.Click, AddressOf mnuItem_Clicked
                                End If
                            Next
                        End If
                    Next
                    NodoSel.ContextMenuStrip = mnuVoce
                    mnuVoce.Show()
                End If

            End If
        End If
    End Sub

    Private Sub ImpostaOrdineLavorazioniToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpostaOrdineLavorazioniToolStripMenuItem.Click

        If Not tvwCat.SelectedNode Is Nothing Then

            Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

            If tvwCat.SelectedNode.Name.StartsWith("L") Then
                ParentFormEx.Sottofondo()
                Using a As New frmListinoOrdineLavorazioni

                    a.Carica(IdRel)

                End Using
                ParentFormEx.Sottofondo()
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub lnkImgTemp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub toolStripAggiungiCat_Click(sender As Object, e As EventArgs) Handles toolStripAggiungiCat.Click

        ParentFormEx.Sottofondo()
        Using f As New frmListinoCatVirtuale

            Dim Ris As Integer = f.Carica

            If Ris Then CaricaNodi()

        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub toolStripElimina_Click(sender As Object, e As EventArgs) Handles toolStripElimina.Click

        Dim Node As TreeNode = tvwCat.SelectedNode

        If Not Node Is Nothing AndAlso Node.Name.StartsWith("V") Then

            Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

            If IdRel <> 0 Then
                If MessageBox.Show("Confermi l'eliminazione della categoria virtuale '" & Node.Text & " '?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Using mgr As New ListiniSuCatVirtualeDAO
                        mgr.DeleteByIdCat(IdRel)
                    End Using

                    Using mgr As New CatVirtualiDAO
                        mgr.Delete(IdRel)
                    End Using

                    CaricaNodi()

                End If
            Else
                MessageBox.Show("Selezionare una categoria virtuale dall'albero")
            End If

        Else

            MessageBox.Show("Selezionare una categoria virtuale dall'albero")

        End If

    End Sub

    Private Sub StampaRiassuntoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StampaRiassuntoToolStripMenuItem.Click

        If Not tvwCat.SelectedNode Is Nothing Then

            Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

            If tvwCat.SelectedNode.Name.StartsWith("C") Then
                ParentFormEx.Sottofondo()
                Using f As New frmStampa
                    f.Carica(MgrReport.RiassuntoPreventivazione(IdRel))
                End Using

                ParentFormEx.Sottofondo()
            End If
        Else
            Beep()
        End If

    End Sub


    Private Sub ImpostaFormerChoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpostaFormerChoiceToolStripMenuItem.Click
        ImpostaFormerChoice()
    End Sub

    Private Sub AzzeraFormerChoice(Nodo As TreeNode)
        If Nodo.Name.StartsWith("L") Then
            Nodo.ImageIndex = 1
            Nodo.SelectedImageIndex = 1
            Nodo.BackColor = Color.White
        Else
            For Each node In Nodo.Nodes
                AzzeraFormerChoice(node)
            Next
        End If
    End Sub

    Private Sub ImpostaFormerChoice()
        If Not tvwCat.SelectedNode Is Nothing Then

            Dim IdRel As Integer = tvwCat.SelectedNode.Name.Substring(1)

            If tvwCat.SelectedNode.Name.StartsWith("L") Then
                If MessageBox.Show("Confermi questo listinobase come FormerChoice per questa preventivazione?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Using mgr As New ListinoBaseDAO
                        Using L As New ListinoBase
                            L.Read(IdRel)
                            mgr.SetFormerChoice(L.IdListinoBase, L.IdPrev)


                            Dim NodoPrev As TreeNode = tvwCat.Nodes.Find("C" & L.IdPrev, True)(0)

                            AzzeraFormerChoice(NodoPrev)
                            'For Each nodo As TreeNode In tvwCat.SelectedNode.Parent.Nodes
                            '    nodo.ImageIndex = 1
                            '    nodo.SelectedImageIndex = 4
                            '    nodo.BackColor = Color.White
                            'Next

                            tvwCat.SelectedNode.BackColor = Color.Orange
                            tvwCat.SelectedNode.ImageIndex = 4
                            tvwCat.SelectedNode.SelectedImageIndex = 4
                        End Using
                    End Using
                End If
            Else
                Beep()
            End If
        Else
            Beep()
        End If
    End Sub

    Private Sub CaricaListinoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaricaListinoToolStripMenuItem.Click
        CaricaNodi()
    End Sub

    Private Sub AggiungiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggiungiToolStripMenuItem.Click
        AddFotoHD()
    End Sub

    Private Sub GestisciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestisciToolStripMenuItem.Click

        ManageFotoHD()
    End Sub

    Private Sub ModificaDatiWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaDatiWebToolStripMenuItem.Click
        DatiWeb()
    End Sub

    Private Sub ImgTemporaneeInUsoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImgTemporaneeInUsoToolStripMenuItem.Click
        ParentFormEx.Sottofondo()
        Using f As New frmListinoListaImgTemporanee
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub CheckCongruenzaDatiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckCongruenzaDatiToolStripMenuItem.Click
        CheckDati()
    End Sub

    Private Sub EliminaListinoBaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminaListinoBaseToolStripMenuItem.Click
        EliminaLB()
    End Sub

    Private Sub EliminaLB()
        Dim OkDel As Boolean = False
        Dim IdRel As Integer = 0
        If Not tvwCat.SelectedNode Is Nothing Then

            IdRel = tvwCat.SelectedNode.Name.Substring(1)

            If tvwCat.SelectedNode.Name.StartsWith("L") Then
                OkDel = True
            End If
        End If

        If OkDel Then
            If MessageBox.Show("Vuoi eliminare il listinobase selezionato '" & tvwCat.SelectedNode.Text & "'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New ListinoBaseDAO
                    mgr.DeleteOrDeactivate(IdRel, True)
                End Using
                tvwCat.Nodes.Remove(tvwCat.SelectedNode)
            End If
        End If


    End Sub

    Private Sub MostraSoloNascostiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostraSoloNascostiToolStripMenuItem.Click
        CaricaNodi(True)
    End Sub

    Private Sub MostraSoloConVariantiToolStripMenuItem_Click(sender As Object, e As EventArgs)
        CaricaNodi(, True)
    End Sub

    Private Sub btnPronteChiudi_Click(sender As Object, e As EventArgs) Handles btnPronteChiudi.Click
        tvwCat.CollapseAll()
    End Sub

    Private Sub btnPronteApri_Click(sender As Object, e As EventArgs) Handles btnPronteApri.Click
        tvwCat.ExpandAll()
    End Sub

    Private Sub CheckDifferenzeListinoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckDifferenzeListinoToolStripMenuItem.Click
        Cursor.Current = Cursors.WaitCursor
        CheckDifferenze()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CheckDifferenze()

        Dim Buffer As String = String.Empty
        'Dim PathTxt As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")



        Fw.LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin

        Using Mgr As New Fw.ListinoBaseWDAO
                Dim l As List(Of Fw.ListinoBaseW) = Mgr.FindAll(New Fw.LUNA.LunaSearchParameter(Fw.LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"),
                                                                 New Fw.LUNA.LunaSearchParameter(Fw.LFM.ListinoBaseW.IdListinoBaseSource, 0, "<>"))
                'qui ho tutti i listini base produzione

                Using MgrD As New ListinoBaseDAO

                Dim lD As List(Of ListinoBase) = MgrD.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.Disattivo, enSiNo.Si, "<>"),
                                                                  New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                                  New LUNA.LunaSearchParameter(LFM.ListinoBase.IdPrev, 0, "<>"))

                'qui ho tutti i listini base source ocn le loro varianti 
                Dim Combinazioni As New List(Of String)

                    For Each lb In lD

                        Dim CombinazionePrincipale As String = lb.IdFormProd & "#" & lb.IdTipoCarta & "#" & lb.IdColoreStampa

                        Combinazioni.Add(CombinazionePrincipale)

                        Dim VarianteCS As GruppoVarianteRif = lb.ListaVarianti.Find(Function(x) x.TipoRiferimento = enTipoOggettoListino.ColoreStampa)

                        If Not VarianteCS Is Nothing Then
                            'aggiungo la variante principale
                            Dim CombinazioneCorrente As String = lb.IdFormProd & "#" & lb.IdTipoCarta & "#" & VarianteCS.IdRiferimento

                            Dim ltent As List(Of ListinoBase) = MgrD.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdFormProd, lb.IdFormProd),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, lb.IdTipoCarta),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, VarianteCS.IdRiferimento),
                                                                            New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))

                            If ltent.Count = 0 Then
                                'qui posso aggiungere la combinazione
                                If Combinazioni.FindAll(Function(x) x = CombinazioneCorrente).Count = 0 Then Combinazioni.Add(CombinazioneCorrente)
                            End If

                        End If

                        For Each var In lb.ListaVarianti.FindAll(Function(x) x.TipoRiferimento = enTipoOggettoListino.TipoCarta)

                            Dim CombinazioneCorrente As String = lb.IdFormProd & "#" & var.IdRiferimento & "#" & lb.IdColoreStampa

                            'ora vedo se esitono gia
                            Dim ltent As List(Of ListinoBase) = MgrD.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdFormProd, lb.IdFormProd),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, var.IdRiferimento),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, lb.IdColoreStampa),
                                                                            New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))

                            If ltent.Count = 0 Then
                                'qui posso aggiungere la combinazione
                                If Combinazioni.FindAll(Function(x) x = CombinazioneCorrente).Count = 0 Then Combinazioni.Add(CombinazioneCorrente)
                            End If

                            If Not VarianteCS Is Nothing Then
                                ltent = MgrD.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                    New LUNA.LSP(LFM.ListinoBase.IdFormProd, lb.IdFormProd),
                                                    New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, var.IdRiferimento),
                                                    New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, VarianteCS.IdRiferimento),
                                                    New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))
                                If ltent.Count = 0 Then
                                    CombinazioneCorrente = lb.IdFormProd & "#" & var.IdRiferimento & "#" & VarianteCS.IdRiferimento
                                    If Combinazioni.FindAll(Function(x) x = CombinazioneCorrente).Count = 0 Then Combinazioni.Add(CombinazioneCorrente)
                                End If
                            End If
                        Next
                    Next

                Buffer &= "<h2 style='color:red;'>Listini Base SORGENTE e varianti non ancora presenti in produzione</h2>"

                For Each Combinazione In Combinazioni

                        Dim Valori() As String = Combinazione.Split("#")

                        Dim IdFP As Integer = Valori(0)
                        Dim IdTC As Integer = Valori(1)
                        Dim IdCS As Integer = Valori(2)

                        If l.FindAll(Function(x) x.IdFormProd = IdFP And x.IdTipoCarta = IdTC And x.IdColoreStampa = IdCS).Count = 0 Then
                            Dim ltent As List(Of ListinoBase) = MgrD.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdFormProd, IdFP),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, IdTC),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, IdCS),
                                                                            New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))
                            If ltent.Count Then
                                Dim lb As ListinoBase = ltent(0)
                                Buffer &= "<li>" & lb.Nome & "</li>"
                            End If
                        End If
                    Next

                Buffer &= "<h2 style='color:red;'>Listini Base PRODUZIONE non presenti nei sorgente e varianti</h2>"

                For Each lb In l
                        Dim CombinazionePrincipale As String = lb.IdFormProd & "#" & lb.IdTipoCarta & "#" & lb.IdColoreStampa
                        If Combinazioni.FindAll(Function(x) x = CombinazionePrincipale).Count = 0 Then
                            Buffer &= "<li>" & lb.Nome & "</li>"
                        End If
                    Next

                Buffer &= "<h2 style='color:red;'>Listini Base DIFFERENTI tra SORGENTE e PRODUZIONE</h2>"
                Buffer &= "<table>"
                Buffer &= "<tr><td><b>PROPERTY</b></td><td><b>SORGENTE</b></td><td><b>PRODUZIONE</b></td></tr>"
                For Each lb In lD
                    Dim BufferSingolo As String = String.Empty
                    Dim lRis As Fw.ListinoBaseW = l.Find(Function(x) x.IdFormProd = lb.IdFormProd And x.IdTipoCarta = lb.IdTipoCarta And x.IdColoreStampa = lb.IdColoreStampa)
                    'Dim lRis As Fw.ListinoBaseW = l.Find(Function(x) x.IdListinoBaseSource = lb.IdListinoBase And x.IdFormProd = lb.IdFormProd And x.IdTipoCarta = lb.IdTipoCarta And x.IdColoreStampa = lb.IdColoreStampa)
                    If Not lRis Is Nothing Then
                        'controllo solo i modificati

                        Dim Tipo As Type = GetType(ListinoBase)
                        Dim TipoR As Type = GetType(Fw.ListinoBaseW)

                        For Each prop In Tipo.GetProperties
                            Try
                                If prop.Name.ToLower <> "idlistinobase" AndAlso
                                    prop.Name.ToLower <> "idlistinobasesource" AndAlso
                                   (prop.PropertyType.Name.ToLower = "int32" OrElse
                                   prop.PropertyType.Name.ToLower = "string" OrElse
                                   prop.PropertyType.Name.ToLower = "decimal" OrElse
                                   prop.PropertyType.Name.ToLower = "single") Then

                                    Dim propR As Reflection.PropertyInfo = TipoR.GetProperty(prop.Name)
                                    If Not propR Is Nothing Then

                                        Dim ValueS = prop.GetValue(lb)
                                        Dim ValueP = propR.GetValue(lRis)

                                        If prop.Name.ToLower.IndexOf("img") <> -1 Then
                                            'levo il path dal nome interno
                                            ValueS = FormerLib.FormerHelper.File.EstraiNomeFile(ValueS)
                                        End If

                                        If ValueS <> ValueP Then
                                            BufferSingolo &= "<tr><td><b>" & prop.Name & "</b></td><td>" & ValueS & "</td><td>" & ValueP & "</td></tr>"
                                        End If
                                    End If
                                End If
                            Catch ex As Exception

                            End Try
                        Next

                        'lavorazioni
                    End If

                    If BufferSingolo.Length Then
                        Buffer &= "<tr><td colspan=3><h3 style='color:green;'><br>" & lb.Nome.ToUpper & "</td></tr>" & BufferSingolo
                    End If

                Next
                Buffer &= "</table>"
            End Using

            End Using

            Fw.LUNA.LunaContext.ConnectionString = String.Empty
        If Buffer.Length Then

            Buffer = "<font face=Arial>" & Buffer
            ParentFormEx.Sottofondo()
            Dim PathBuffer As String = FormerConfig.FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")
            Using w As New StreamWriter(PathBuffer)
                w.Write(Buffer)
            End Using

            Using f As New frmBrowser
                f.Carica(PathBuffer)
            End Using

            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("Non risultano differenze nei listini source, sviluppo e produzione")
        End If

    End Sub

End Class
