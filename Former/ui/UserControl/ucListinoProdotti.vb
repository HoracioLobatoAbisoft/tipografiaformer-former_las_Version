Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib

Friend Class ucListinoProdotti
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

        tvwCat.Nodes.Clear()

        CaricaNodi(0)

        'tvwCat.ExpandAll()


        'Dim mgr As New CatProdDAO()


        'Dim Lst As List(Of CatProd) = mgr.GetAll("Descrizione", True)
        'lstCat.DataSource = Lst

    End Sub

    Private Sub CaricaNodi(ByVal IdPadre As Integer)

        Using mgr As New CatProdDAO()
            Dim par1 As New LUNA.LunaSearchParameter(LFM.CatProd.IdCatPadre, IdPadre)
            Dim Lst As List(Of CatProd) = mgr.FindAll(LFM.CatProd.Descrizione, par1)

            For Each CategProd As CatProd In Lst
                If IdPadre Then
                    If tvwCat.Nodes.Find("C" & IdPadre, True) Is Nothing Then
                        tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione, 0, 0)
                    Else

                        Dim N2 As TreeNode = tvwCat.Nodes.Find("C" & IdPadre, True)(0)

                        N2.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione, 0, 0)
                    End If
                Else
                    tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione, 0, 0)
                End If
                'tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione)
                CaricaNodi(CategProd.IdCatProd)

            Next
        End Using
    End Sub

    Public Sub Carica()
        Try
            CaricaCat()

            MostraDati()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub MostraDati(Optional ByVal Cerca As String = "")

        Dim CatSel As Integer = 0

        If Not tvwCat.SelectedNode Is Nothing Then
            CatSel = tvwCat.SelectedNode.Name.Substring(1)
        End If

        If Cerca = "{inserire qui il codice o la descrizione da cercare}" Then Cerca = ""

        Dim dt As DataTable


        Dim P1 As New LUNA.LunaSearchParameter(LFM.Prodotto.Status, 1, "<>")
        Dim P2 As New LUNA.LunaSearchParameter(LFM.Prodotto.IdCatProd, CatSel)
        Dim P3 As LUNA.LunaSearchParameter = Nothing
        If Cerca.Length Then
            P3 = New LUNA.LunaSearchParameter(LFM.Prodotto.Codice, Cerca)
        End If
        Dim P As List(Of Prodotto) = Nothing
        If _IdRub Then
            Using Prod As New cProdottiColl
                dt = Prod.Lista(Cerca, CatSel)
            End Using
        Else
            Using mgr As New ProdottiDAO
                P = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "NumPezzi,Codice"},
                                P1,
                                P2,
                                P3)
            End Using

        End If

        DgListino.AutoGenerateColumns = False
        DgListino.DataSource = P

        DgListino.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DgListino.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgListino.Columns(4).DefaultCellStyle.Format = "0.00"
        DgListino.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgListino.Columns(5).DefaultCellStyle.Format = "0.00"
        DgListino.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DgListino.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgListino.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgListino.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgListino.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgListino.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub
    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
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

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""
        If _IdRub Then
            Titolo = "Listino Personale"
        Else
            Titolo = "Listino"
        End If
        StampaGlobale(Titolo, DgListino)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkCerca_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        Cerca()

    End Sub
    Private Sub Cerca()

        If txtCercaCli.Text = "{inserire qui il codice o la descrizione da cercare}" Then
            MessageBox.Show("Inserire il codice del prodotto o parte della descrizione per effettuare la ricerca", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MostraDati(txtCercaCli.Text)
        End If
    End Sub
    Private Sub txtCercaCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCercaCli.KeyPress
        Dim c As Char = vbCr
        If e.KeyChar = c Then Cerca()
    End Sub

    Private Sub txtCercaCli_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCercaCli.MouseClick
        If txtCercaCli.Text = "{inserire qui il codice o la descrizione da cercare}" Then

            txtCercaCli.Text = ""

        End If
    End Sub

    Private Sub NewVoce()
        Dim frmRif As New frmListinoProdotto
        Dim ObjRif As New Prodotto
        Dim Ris As Integer = 0

        ParentFormEx.Sottofondo()
        Ris = frmRif.Carica(ObjRif)
        ParentFormEx.Sottofondo()
        If Ris Then MostraDati(txtCercaCli.Text)
        frmRif.Dispose()
        ObjRif = Nothing
    End Sub

    Private Sub NewListino()
        Dim frmRif As New frmListPers

        Dim Ris As Integer = 0

        ParentFormEx.Sottofondo()
        Ris = frmRif.Carica(, _IdRub)
        ParentFormEx.Sottofondo()
        If Ris Then MostraDati(txtCercaCli.Text)
        frmRif.Dispose()

    End Sub


    Private Sub RiapriVoce()

        Dim IdVoce As Integer
        IdVoce = DirectCast(DgListino.SelectedRows(0).DataBoundItem, Prodotto).IdProd

        If _IdRub Then

            Dim frmRif As New frmListPers

            Dim Ris As Integer = 0

            ParentFormEx.Sottofondo()
            Ris = frmRif.Carica(IdVoce, _IdRub)
            ParentFormEx.Sottofondo()
            If Ris Then MostraDati(txtCercaCli.Text)
            frmRif.Dispose()

        Else
            Dim OggRif As New Prodotto, Ris As Integer = 0

            OggRif.Read(IdVoce)

            Dim frmRif As New frmListinoProdotto
            ParentFormEx.Sottofondo()
            Ris = frmRif.Carica(OggRif)
            ParentFormEx.Sottofondo()

            If Ris Then MostraDati(txtCercaCli.Text)
            frmRif.Dispose()
            OggRif = Nothing
        End If
    End Sub

    Private Sub EliminaVoce()
        Dim IdVoce As Integer
        IdVoce = DirectCast(DgListino.SelectedRows(0).DataBoundItem, Prodotto).IdProd

        If MessageBox.Show("Confermi l'eliminazione della voce selezionata?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Using OggRif As New ProdottiDAO

                OggRif.Delete(IdVoce)
                MostraDati(txtCercaCli.Text)

            End Using

        End If

    End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        If _IdRub Then
            NewListino()
        Else
            NewVoce()
        End If

    End Sub

    Private Sub DgListino_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgListino.CellDoubleClick
        RiapriVoce()
    End Sub

    Private Sub DgListino_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgListino.CellMouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim x As System.Drawing.Point = MousePosition
            'btnNuovoCliente.ContextMenu = menuNuovo.
            x = MousePosition
            'x = lnkNew.PointToClient(x)

            Dim rig As DataGridViewRow
            Dim RigaSel As Integer = e.RowIndex

            If RigaSel <> -1 Then
                rig = DgListino.Rows(RigaSel)
                rig.Selected = True
                DgListino.Select()
                mnuVoce.Show(x)
            End If

        End If

    End Sub

    Private Sub ModificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaToolStripMenuItem.Click
        RiapriVoce()
    End Sub

    Private Sub EliminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaToolStripMenuItem.Click
        EliminaVoce()
    End Sub

    Private Sub txtCercaCli_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCercaCli.TextChanged

    End Sub

    Private Sub DgListino_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgListino.CellContentClick

    End Sub

    'Private Sub lnkExport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkExport.LinkClicked

    '    Try

    '        Dim Dt As DataTable
    '        Using Prod As New cProdottiColl
    '            Dt = Prod.ListaExport
    '        End Using

    '        Dim dtCat As DataTable
    '        Using Cat As New CatProdDAO()
    '            dtCat = Cat.ElencoExport
    '        End Using

    '        Dim PathLocaleListino As String = FormerPath.PathLocale & "listino.xml"
    '        Dim PathLocaleListinoCat As String = FormerPath.PathLocale & "listinocat.xml"
    '        Dim PathRemotoListino As String = "tipografiaformer.com/listino/listino.xml"

    '        Dim xmlSWCat As System.IO.StreamWriter = New System.IO.StreamWriter(PathLocaleListinoCat)
    '        dtCat.WriteXml(xmlSWCat, XmlWriteMode.WriteSchema)
    '        xmlSWCat.Close()

    '        Dim xmlSW As System.IO.StreamWriter = New System.IO.StreamWriter(PathLocaleListino)
    '        Dt.WriteXml(xmlSW, XmlWriteMode.WriteSchema)
    '        xmlSW.Close()

    '        Using Corr As New CorrieriDAO
    '            Dt = Corr.ListaCorrieriPerListino
    '        End Using

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

    '        'EsportaListinoHtml(False)
    '        'EsportaListinoHtml(False, "aspx")
    '        'EsportaListinoHtml(True)
    '        'EsportaListinoHtml(True, "aspx")

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
    '    Dim Lst As List(Of CatProd) = mgr.FindAll("Descrizione", par1)

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
    '        Dim LstFigli As List(Of CatProd) = mgr.FindAll("Descrizione", par2)
    '        For Each CategProdFiglio As CatProd In LstFigli
    '            Buffer &= "<TR><TD COLSPAN=2><FONT SIZE=2 FACE=""Segoe UI"" COLOR=""BLACK""><BR><B>" & CategProdFiglio.Descrizione.ToUpper & "</B><BR>" & CategProdFiglio.DescrizioneLunga & "</CENTER></FONT></TD></TR>"
    '            'qui carico le caratteristiche e i dettagli
    '            Buffer &= "<TR><TD valign=TOP align=center width=200><BR>"
    '            Dim mgrCaratProd As New CatCaratDAO()
    '            Dim Par4 As New LUNA.LunaSearchParameter("IdCatProd", CategProdFiglio.IdCatProd)
    '            Dim LstCatCarat As List(Of CatCarat) = mgrCaratProd.FindAll(Par4)
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
    '            Dim LstProd As List(Of Prodotto) = mgrProd.FindAll("NumPezzi", Par3)
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

    Private Sub tvwCat_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwCat.AfterSelect
        MostraDati()
    End Sub

    Private Sub lnkNewCat_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNewCat.LinkClicked

        Dim frmCat As New frmCatProd
        ParentFormEx.Sottofondo()
        'Dim N As TreeNode = tvwCat.SelectedNode
        'Dim IDSel As Integer = 0
        'If Not N Is Nothing Then
        '    IDSel = N.Name.Substring(1)
        'End If
        Dim Ris As Integer = frmCat.Carica()
        If Ris Then CaricaCat()
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub tvwCat_DoubleClick(sender As Object, e As EventArgs) Handles tvwCat.DoubleClick

    End Sub

    Private Sub tvwCat_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvwCat.NodeMouseDoubleClick
        Dim N As TreeNode = e.Node

        N.ExpandAll()
    End Sub

    Private Sub lnkRefresh_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        CaricaCat()
    End Sub

    Private Sub lnkModifica_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkModifica.LinkClicked
        'riapro la categoria selezionata
        If Not tvwCat.SelectedNode Is Nothing Then


            Dim IdCatSel As Integer = 0
            IdCatSel = tvwCat.SelectedNode.Name.Substring(1)

            Dim frmCat As New frmCatProd
            ParentFormEx.Sottofondo()
            frmCat.Carica(IdCatSel)
            ParentFormEx.Sottofondo()
        End If

    End Sub

    Private Sub btnEspandi_Click(sender As System.Object, e As System.EventArgs) Handles btnEspandi.Click
        tvwCat.ExpandAll()
    End Sub

    Private Sub btnRiduci_Click(sender As System.Object, e As System.EventArgs) Handles btnRiduci.Click
        tvwCat.CollapseAll()
    End Sub

    Private Sub lnkPubblico_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPubblico.LinkClicked
        ParentFormEx.Sottofondo()
        Dim x As New frmListinoCli
        x.Carica()
        ParentFormEx.Sottofondo()

        x = Nothing
    End Sub
End Class
