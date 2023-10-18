Imports FormerControl

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMainToolbar
    Inherits ucFormerUserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMainToolbar))
        Me.tmrConnAtt = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPulisciMemoria = New System.Windows.Forms.Timer(Me.components)
        Me.toolTipMsg = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrConnDemone = New System.Windows.Forms.Timer(Me.components)
        Me.FlowLayoutPanelToolbar = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblConn = New System.Windows.Forms.Label()
        Me.lnkChiamate = New System.Windows.Forms.LinkLabel()
        Me.lblNotifiche = New System.Windows.Forms.LinkLabel()
        Me.lblNewVer = New Former.ucLabel()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.StrumentiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalcolatriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalcolatriceDigitaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CalcolatricePesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalcoloPrezzoLavorazioneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CercaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LogOperatoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MagazzinoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegnalazioneAcquistoRisorsaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.StornoRisorsaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScaricoMaterialeDiConsumoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.DocumentoDiCaricoDiMagazzinoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StrumentiToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolstripInserisciOrdine = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllegaFileOnlineMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.NumerazioneAutomaticaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcedimentoFustelleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AiutoProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.GeneraListinoPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.StampaComandaOperatoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StampaEtichettaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SegnalazioneAnomaliaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InviaSchermataCorrenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.CercaFileSorgentiGrandiDimensioniToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.VediLultimoReleaseNoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HotFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PubblicazioneListinoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FunctionLockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreRefineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreazioneCommesseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbUtenteLoggato = New System.Windows.Forms.ComboBox()
        Me.lblCounter = New Former.ucLabel()
        Me.RadNotification = New Telerik.WinControls.UI.RadDesktopAlert(Me.components)
        Me.tmrReminder = New System.Windows.Forms.Timer(Me.components)
        Me.RadCentrale = New Telerik.WinControls.UI.RadDesktopAlert(Me.components)
        Me.FlowLayoutPanelToolbar.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolTipHelp
        '
        Me.toolTipHelp.AutomaticDelay = 250
        Me.toolTipHelp.AutoPopDelay = 20000
        Me.toolTipHelp.InitialDelay = 0
        Me.toolTipHelp.ReshowDelay = 0
        '
        'tmrConnAtt
        '
        Me.tmrConnAtt.Enabled = True
        Me.tmrConnAtt.Interval = 1000
        '
        'tmrPulisciMemoria
        '
        Me.tmrPulisciMemoria.Enabled = True
        Me.tmrPulisciMemoria.Interval = 900000
        '
        'tmrConnDemone
        '
        Me.tmrConnDemone.Interval = 3000
        '
        'FlowLayoutPanelToolbar
        '
        Me.FlowLayoutPanelToolbar.Controls.Add(Me.lblConn)
        Me.FlowLayoutPanelToolbar.Controls.Add(Me.lnkChiamate)
        Me.FlowLayoutPanelToolbar.Controls.Add(Me.lblNotifiche)
        Me.FlowLayoutPanelToolbar.Controls.Add(Me.lblNewVer)
        Me.FlowLayoutPanelToolbar.Controls.Add(Me.MenuStripMain)
        Me.FlowLayoutPanelToolbar.Controls.Add(Me.cmbUtenteLoggato)
        Me.FlowLayoutPanelToolbar.Controls.Add(Me.lblCounter)
        Me.FlowLayoutPanelToolbar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanelToolbar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FlowLayoutPanelToolbar.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanelToolbar.Name = "FlowLayoutPanelToolbar"
        Me.FlowLayoutPanelToolbar.Size = New System.Drawing.Size(1293, 35)
        Me.FlowLayoutPanelToolbar.TabIndex = 0
        '
        'lblConn
        '
        Me.lblConn.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.lblConn.Image = Global.Former.My.Resources.Resources._ConnessioneServer
        Me.lblConn.Location = New System.Drawing.Point(3, 0)
        Me.lblConn.Name = "lblConn"
        Me.lblConn.Size = New System.Drawing.Size(32, 32)
        Me.lblConn.TabIndex = 74
        Me.lblConn.Text = "32"
        Me.lblConn.Visible = False
        '
        'lnkChiamate
        '
        Me.lnkChiamate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lnkChiamate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChiamate.Image = Global.Former.My.Resources.Resources.icoNotificheTel1
        Me.lnkChiamate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkChiamate.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lnkChiamate.LinkColor = System.Drawing.Color.White
        Me.lnkChiamate.Location = New System.Drawing.Point(41, 0)
        Me.lnkChiamate.Name = "lnkChiamate"
        Me.lnkChiamate.Size = New System.Drawing.Size(47, 31)
        Me.lnkChiamate.TabIndex = 75
        Me.lnkChiamate.TabStop = True
        Me.lnkChiamate.Text = "0"
        Me.lnkChiamate.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblNotifiche
        '
        Me.lblNotifiche.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotifiche.ForeColor = System.Drawing.Color.White
        Me.lblNotifiche.Image = Global.Former.My.Resources.Resources.IcoNotifyBkg2
        Me.lblNotifiche.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNotifiche.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblNotifiche.LinkColor = System.Drawing.Color.White
        Me.lblNotifiche.Location = New System.Drawing.Point(94, 0)
        Me.lblNotifiche.Name = "lblNotifiche"
        Me.lblNotifiche.Size = New System.Drawing.Size(47, 31)
        Me.lblNotifiche.TabIndex = 77
        Me.lblNotifiche.TabStop = True
        Me.lblNotifiche.Text = "0"
        Me.lblNotifiche.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.toolTipHelp.SetToolTip(Me.lblNotifiche, "Non ci sono notifiche da visualizzare.")
        '
        'lblNewVer
        '
        Me.lblNewVer.BackColor = System.Drawing.Color.White
        Me.lblNewVer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.lblNewVer.Image = Global.Former.My.Resources.Resources._NewVersionOffB
        Me.lblNewVer.Location = New System.Drawing.Point(147, 0)
        Me.lblNewVer.Name = "lblNewVer"
        Me.lblNewVer.RoundedBorder = False
        Me.lblNewVer.Size = New System.Drawing.Size(47, 31)
        Me.lblNewVer.TabIndex = 81
        Me.lblNewVer.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.toolTipHelp.SetToolTip(Me.lblNewVer, "La tua versione del gestionale Former è aggiornata!")
        '
        'MenuStripMain
        '
        Me.MenuStripMain.BackColor = System.Drawing.Color.Transparent
        Me.MenuStripMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStripMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStripMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StrumentiToolStripMenuItem, Me.CercaToolStripMenuItem, Me.BarcodeToolStripMenuItem, Me.MagazzinoToolStripMenuItem, Me.StrumentiToolStripMenuItem1, Me.HotFolderToolStripMenuItem, Me.PubblicazioneListinoToolStripMenuItem, Me.FunctionLockToolStripMenuItem})
        Me.MenuStripMain.Location = New System.Drawing.Point(197, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(727, 35)
        Me.MenuStripMain.TabIndex = 80
        Me.MenuStripMain.Text = "MenuStrip1"
        '
        'StrumentiToolStripMenuItem
        '
        Me.StrumentiToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.StrumentiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalcolatriceToolStripMenuItem, Me.CalcolatriceDigitaleToolStripMenuItem, Me.ToolStripSeparator1, Me.CalcolatricePesoToolStripMenuItem, Me.CalcoloPrezzoLavorazioneToolStripMenuItem})
        Me.StrumentiToolStripMenuItem.Image = CType(resources.GetObject("StrumentiToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StrumentiToolStripMenuItem.Name = "StrumentiToolStripMenuItem"
        Me.StrumentiToolStripMenuItem.Size = New System.Drawing.Size(105, 31)
        Me.StrumentiToolStripMenuItem.Text = "Calcolatrice"
        '
        'CalcolatriceToolStripMenuItem
        '
        Me.CalcolatriceToolStripMenuItem.Image = CType(resources.GetObject("CalcolatriceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CalcolatriceToolStripMenuItem.Name = "CalcolatriceToolStripMenuItem"
        Me.CalcolatriceToolStripMenuItem.Size = New System.Drawing.Size(225, 30)
        Me.CalcolatriceToolStripMenuItem.Text = "Calcolatrice"
        '
        'CalcolatriceDigitaleToolStripMenuItem
        '
        Me.CalcolatriceDigitaleToolStripMenuItem.Image = CType(resources.GetObject("CalcolatriceDigitaleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CalcolatriceDigitaleToolStripMenuItem.Name = "CalcolatriceDigitaleToolStripMenuItem"
        Me.CalcolatriceDigitaleToolStripMenuItem.Size = New System.Drawing.Size(225, 30)
        Me.CalcolatriceDigitaleToolStripMenuItem.Text = "Calcolatrice Digitale"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(222, 6)
        '
        'CalcolatricePesoToolStripMenuItem
        '
        Me.CalcolatricePesoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Peso
        Me.CalcolatricePesoToolStripMenuItem.Name = "CalcolatricePesoToolStripMenuItem"
        Me.CalcolatricePesoToolStripMenuItem.Size = New System.Drawing.Size(225, 30)
        Me.CalcolatricePesoToolStripMenuItem.Text = "Calcolatrice Peso"
        '
        'CalcoloPrezzoLavorazioneToolStripMenuItem
        '
        Me.CalcoloPrezzoLavorazioneToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Prezzo
        Me.CalcoloPrezzoLavorazioneToolStripMenuItem.Name = "CalcoloPrezzoLavorazioneToolStripMenuItem"
        Me.CalcoloPrezzoLavorazioneToolStripMenuItem.Size = New System.Drawing.Size(225, 30)
        Me.CalcoloPrezzoLavorazioneToolStripMenuItem.Text = "Calcolo Prezzo Lavorazione"
        '
        'CercaToolStripMenuItem
        '
        Me.CercaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConBarcodeToolStripMenuItem, Me.ToolStripSeparator2, Me.LogOperatoreToolStripMenuItem})
        Me.CercaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Cerca
        Me.CercaToolStripMenuItem.Name = "CercaToolStripMenuItem"
        Me.CercaToolStripMenuItem.Size = New System.Drawing.Size(82, 31)
        Me.CercaToolStripMenuItem.Text = "Cerca..."
        '
        'ConBarcodeToolStripMenuItem
        '
        Me.ConBarcodeToolStripMenuItem.Image = Global.Former.My.Resources.Resources._barcode
        Me.ConBarcodeToolStripMenuItem.Name = "ConBarcodeToolStripMenuItem"
        Me.ConBarcodeToolStripMenuItem.Size = New System.Drawing.Size(158, 30)
        Me.ConBarcodeToolStripMenuItem.Text = "Con Barcode"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(155, 6)
        '
        'LogOperatoreToolStripMenuItem
        '
        Me.LogOperatoreToolStripMenuItem.Image = Global.Former.My.Resources.Resources.user_1_
        Me.LogOperatoreToolStripMenuItem.Name = "LogOperatoreToolStripMenuItem"
        Me.LogOperatoreToolStripMenuItem.Size = New System.Drawing.Size(158, 30)
        Me.LogOperatoreToolStripMenuItem.Text = "Log Operatore"
        '
        'BarcodeToolStripMenuItem
        '
        Me.BarcodeToolStripMenuItem.Image = Global.Former.My.Resources.Resources._barcode
        Me.BarcodeToolStripMenuItem.Name = "BarcodeToolStripMenuItem"
        Me.BarcodeToolStripMenuItem.Size = New System.Drawing.Size(86, 31)
        Me.BarcodeToolStripMenuItem.Text = "Barcode"
        '
        'MagazzinoToolStripMenuItem
        '
        Me.MagazzinoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SegnalazioneAcquistoRisorsaToolStripMenuItem, Me.ToolStripSeparator7, Me.StornoRisorsaToolStripMenuItem, Me.ScaricoMaterialeDiConsumoToolStripMenuItem, Me.ToolStripSeparator9, Me.DocumentoDiCaricoDiMagazzinoToolStripMenuItem})
        Me.MagazzinoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Magazzino
        Me.MagazzinoToolStripMenuItem.Name = "MagazzinoToolStripMenuItem"
        Me.MagazzinoToolStripMenuItem.Size = New System.Drawing.Size(100, 31)
        Me.MagazzinoToolStripMenuItem.Text = "Magazzino"
        '
        'SegnalazioneAcquistoRisorsaToolStripMenuItem
        '
        Me.SegnalazioneAcquistoRisorsaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._RisorsaRichiesta
        Me.SegnalazioneAcquistoRisorsaToolStripMenuItem.Name = "SegnalazioneAcquistoRisorsaToolStripMenuItem"
        Me.SegnalazioneAcquistoRisorsaToolStripMenuItem.Size = New System.Drawing.Size(268, 30)
        Me.SegnalazioneAcquistoRisorsaToolStripMenuItem.Text = "Richiesta acquisto risorsa"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(265, 6)
        '
        'StornoRisorsaToolStripMenuItem
        '
        Me.StornoRisorsaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._RisorsaStorno
        Me.StornoRisorsaToolStripMenuItem.Name = "StornoRisorsaToolStripMenuItem"
        Me.StornoRisorsaToolStripMenuItem.Size = New System.Drawing.Size(268, 30)
        Me.StornoRisorsaToolStripMenuItem.Text = "Storno risorsa"
        '
        'ScaricoMaterialeDiConsumoToolStripMenuItem
        '
        Me.ScaricoMaterialeDiConsumoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._MaterialeConsumo
        Me.ScaricoMaterialeDiConsumoToolStripMenuItem.Name = "ScaricoMaterialeDiConsumoToolStripMenuItem"
        Me.ScaricoMaterialeDiConsumoToolStripMenuItem.Size = New System.Drawing.Size(268, 30)
        Me.ScaricoMaterialeDiConsumoToolStripMenuItem.Text = "Scarico materiale di consumo"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(265, 6)
        '
        'DocumentoDiCaricoDiMagazzinoToolStripMenuItem
        '
        Me.DocumentoDiCaricoDiMagazzinoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._CaricoDiMagazzino24
        Me.DocumentoDiCaricoDiMagazzinoToolStripMenuItem.Name = "DocumentoDiCaricoDiMagazzinoToolStripMenuItem"
        Me.DocumentoDiCaricoDiMagazzinoToolStripMenuItem.Size = New System.Drawing.Size(268, 30)
        Me.DocumentoDiCaricoDiMagazzinoToolStripMenuItem.Text = "Documento di Carico di magazzino"
        '
        'StrumentiToolStripMenuItem1
        '
        Me.StrumentiToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolstripInserisciOrdine, Me.AllegaFileOnlineMenuItem, Me.ToolStripMenuItem1, Me.ToolStripSeparator4, Me.NumerazioneAutomaticaToolStripMenuItem, Me.ProcedimentoFustelleToolStripMenuItem, Me.AiutoProcedureToolStripMenuItem, Me.PDFToolsToolStripMenuItem, Me.ToolStripSeparator3, Me.GeneraListinoPDFToolStripMenuItem, Me.ToolStripSeparator5, Me.StampaComandaOperatoreToolStripMenuItem, Me.StampaEtichettaToolStripMenuItem, Me.ToolStripSeparator6, Me.SegnalazioneAnomaliaToolStripMenuItem, Me.InviaSchermataCorrenteToolStripMenuItem, Me.ToolStripSeparator8, Me.CercaFileSorgentiGrandiDimensioniToolStripMenuItem, Me.ToolStripSeparator10, Me.VediLultimoReleaseNoteToolStripMenuItem, Me.ToolStripSeparator11, Me.SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem})
        Me.StrumentiToolStripMenuItem1.Image = Global.Former.My.Resources.Resources._Strumenti
        Me.StrumentiToolStripMenuItem1.Name = "StrumentiToolStripMenuItem1"
        Me.StrumentiToolStripMenuItem1.Size = New System.Drawing.Size(95, 31)
        Me.StrumentiToolStripMenuItem1.Text = "Strumenti"
        '
        'toolstripInserisciOrdine
        '
        Me.toolstripInserisciOrdine.Image = CType(resources.GetObject("toolstripInserisciOrdine.Image"), System.Drawing.Image)
        Me.toolstripInserisciOrdine.Name = "toolstripInserisciOrdine"
        Me.toolstripInserisciOrdine.Size = New System.Drawing.Size(291, 30)
        Me.toolstripInserisciOrdine.Text = "Inserisci Ordine"
        '
        'AllegaFileOnlineMenuItem
        '
        Me.AllegaFileOnlineMenuItem.Image = CType(resources.GetObject("AllegaFileOnlineMenuItem.Image"), System.Drawing.Image)
        Me.AllegaFileOnlineMenuItem.Name = "AllegaFileOnlineMenuItem"
        Me.AllegaFileOnlineMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.AllegaFileOnlineMenuItem.Text = "Allega file a Ordine online"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(291, 30)
        Me.ToolStripMenuItem1.Text = "Forza scaricamento Ordini Demone"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(288, 6)
        '
        'NumerazioneAutomaticaToolStripMenuItem
        '
        Me.NumerazioneAutomaticaToolStripMenuItem.Image = Global.Former.My.Resources.Resources.calendar2
        Me.NumerazioneAutomaticaToolStripMenuItem.Name = "NumerazioneAutomaticaToolStripMenuItem"
        Me.NumerazioneAutomaticaToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.NumerazioneAutomaticaToolStripMenuItem.Text = "Numerazione Automatica"
        '
        'ProcedimentoFustelleToolStripMenuItem
        '
        Me.ProcedimentoFustelleToolStripMenuItem.Image = Global.Former.My.Resources.Resources._FustellaTemplate
        Me.ProcedimentoFustelleToolStripMenuItem.Name = "ProcedimentoFustelleToolStripMenuItem"
        Me.ProcedimentoFustelleToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.ProcedimentoFustelleToolStripMenuItem.Text = "Procedimento Fustelle"
        '
        'AiutoProcedureToolStripMenuItem
        '
        Me.AiutoProcedureToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Procedura
        Me.AiutoProcedureToolStripMenuItem.Name = "AiutoProcedureToolStripMenuItem"
        Me.AiutoProcedureToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.AiutoProcedureToolStripMenuItem.Text = "Aiuto Procedure"
        '
        'PDFToolsToolStripMenuItem
        '
        Me.PDFToolsToolStripMenuItem.Image = Global.Former.My.Resources.Resources._pdf
        Me.PDFToolsToolStripMenuItem.Name = "PDFToolsToolStripMenuItem"
        Me.PDFToolsToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.PDFToolsToolStripMenuItem.Text = "PDF Tools"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(288, 6)
        '
        'GeneraListinoPDFToolStripMenuItem
        '
        Me.GeneraListinoPDFToolStripMenuItem.Image = Global.Former.My.Resources.Resources._pdf
        Me.GeneraListinoPDFToolStripMenuItem.Name = "GeneraListinoPDFToolStripMenuItem"
        Me.GeneraListinoPDFToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.GeneraListinoPDFToolStripMenuItem.Text = "Genera Listino PDF"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(288, 6)
        '
        'StampaComandaOperatoreToolStripMenuItem
        '
        Me.StampaComandaOperatoreToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Stampa
        Me.StampaComandaOperatoreToolStripMenuItem.Name = "StampaComandaOperatoreToolStripMenuItem"
        Me.StampaComandaOperatoreToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.StampaComandaOperatoreToolStripMenuItem.Text = "Stampa Comanda Operatore"
        '
        'StampaEtichettaToolStripMenuItem
        '
        Me.StampaEtichettaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Etichetta
        Me.StampaEtichettaToolStripMenuItem.Name = "StampaEtichettaToolStripMenuItem"
        Me.StampaEtichettaToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.StampaEtichettaToolStripMenuItem.Text = "Stampa Etichetta"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(288, 6)
        '
        'SegnalazioneAnomaliaToolStripMenuItem
        '
        Me.SegnalazioneAnomaliaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._002_27
        Me.SegnalazioneAnomaliaToolStripMenuItem.Name = "SegnalazioneAnomaliaToolStripMenuItem"
        Me.SegnalazioneAnomaliaToolStripMenuItem.ShortcutKeyDisplayString = "F10"
        Me.SegnalazioneAnomaliaToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.SegnalazioneAnomaliaToolStripMenuItem.Text = "Segnalazione Anomalia"
        '
        'InviaSchermataCorrenteToolStripMenuItem
        '
        Me.InviaSchermataCorrenteToolStripMenuItem.Image = Global.Former.My.Resources.Resources.switch_camera24
        Me.InviaSchermataCorrenteToolStripMenuItem.Name = "InviaSchermataCorrenteToolStripMenuItem"
        Me.InviaSchermataCorrenteToolStripMenuItem.ShortcutKeyDisplayString = "F12"
        Me.InviaSchermataCorrenteToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.InviaSchermataCorrenteToolStripMenuItem.Text = "Invia schermata corrente"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(288, 6)
        '
        'CercaFileSorgentiGrandiDimensioniToolStripMenuItem
        '
        Me.CercaFileSorgentiGrandiDimensioniToolStripMenuItem.Image = Global.Former.My.Resources.Resources.folder_open
        Me.CercaFileSorgentiGrandiDimensioniToolStripMenuItem.Name = "CercaFileSorgentiGrandiDimensioniToolStripMenuItem"
        Me.CercaFileSorgentiGrandiDimensioniToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.CercaFileSorgentiGrandiDimensioniToolStripMenuItem.Text = "Cerca file sorgenti di grandi dimensioni"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(288, 6)
        '
        'VediLultimoReleaseNoteToolStripMenuItem
        '
        Me.VediLultimoReleaseNoteToolStripMenuItem.Image = Global.Former.My.Resources.Resources._help
        Me.VediLultimoReleaseNoteToolStripMenuItem.Name = "VediLultimoReleaseNoteToolStripMenuItem"
        Me.VediLultimoReleaseNoteToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.VediLultimoReleaseNoteToolStripMenuItem.Text = "Vedi l'ultimo Release Note"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(288, 6)
        '
        'SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem
        '
        Me.SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._LucchettoAperto
        Me.SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem.Name = "SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem"
        Me.SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
        Me.SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem.Text = "Sblocca ordini locked da più di 5 minuti"
        '
        'HotFolderToolStripMenuItem
        '
        Me.HotFolderToolStripMenuItem.Image = Global.Former.My.Resources.Resources._HotFolder
        Me.HotFolderToolStripMenuItem.Name = "HotFolderToolStripMenuItem"
        Me.HotFolderToolStripMenuItem.Size = New System.Drawing.Size(96, 31)
        Me.HotFolderToolStripMenuItem.Text = "HotFolder"
        '
        'PubblicazioneListinoToolStripMenuItem
        '
        Me.PubblicazioneListinoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._internet
        Me.PubblicazioneListinoToolStripMenuItem.Name = "PubblicazioneListinoToolStripMenuItem"
        Me.PubblicazioneListinoToolStripMenuItem.Size = New System.Drawing.Size(155, 31)
        Me.PubblicazioneListinoToolStripMenuItem.Text = "Pubblicazione Listino"
        '
        'FunctionLockToolStripMenuItem
        '
        Me.FunctionLockToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreRefineToolStripMenuItem, Me.CreazioneCommesseToolStripMenuItem})
        Me.FunctionLockToolStripMenuItem.Image = Global.Former.My.Resources.Resources._IcoLock
        Me.FunctionLockToolStripMenuItem.Name = "FunctionLockToolStripMenuItem"
        Me.FunctionLockToolStripMenuItem.Size = New System.Drawing.Size(118, 31)
        Me.FunctionLockToolStripMenuItem.Text = "Function Lock"
        Me.FunctionLockToolStripMenuItem.Visible = False
        '
        'PreRefineToolStripMenuItem
        '
        Me.PreRefineToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.PreRefineToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.PreRefineToolStripMenuItem.Image = Global.Former.My.Resources.Resources._DaVerificareLock
        Me.PreRefineToolStripMenuItem.Name = "PreRefineToolStripMenuItem"
        Me.PreRefineToolStripMenuItem.Size = New System.Drawing.Size(194, 30)
        Me.PreRefineToolStripMenuItem.Text = "Pre refine"
        '
        'CreazioneCommesseToolStripMenuItem
        '
        Me.CreazioneCommesseToolStripMenuItem.Image = Global.Former.My.Resources.Resources._CommessaLock
        Me.CreazioneCommesseToolStripMenuItem.Name = "CreazioneCommesseToolStripMenuItem"
        Me.CreazioneCommesseToolStripMenuItem.Size = New System.Drawing.Size(194, 30)
        Me.CreazioneCommesseToolStripMenuItem.Text = "Creazione commesse"
        '
        'cmbUtenteLoggato
        '
        Me.cmbUtenteLoggato.BackColor = System.Drawing.Color.Green
        Me.cmbUtenteLoggato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUtenteLoggato.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbUtenteLoggato.ForeColor = System.Drawing.Color.White
        Me.cmbUtenteLoggato.FormattingEnabled = True
        Me.cmbUtenteLoggato.Location = New System.Drawing.Point(927, 3)
        Me.cmbUtenteLoggato.Name = "cmbUtenteLoggato"
        Me.cmbUtenteLoggato.Size = New System.Drawing.Size(156, 29)
        Me.cmbUtenteLoggato.TabIndex = 76
        '
        'lblCounter
        '
        Me.lblCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCounter.AutoSize = True
        Me.lblCounter.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.lblCounter.Location = New System.Drawing.Point(1089, 8)
        Me.lblCounter.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.lblCounter.Name = "lblCounter"
        Me.lblCounter.RoundedBorder = False
        Me.lblCounter.Size = New System.Drawing.Size(17, 19)
        Me.lblCounter.TabIndex = 70
        Me.lblCounter.Text = "0"
        Me.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCounter.Visible = False
        '
        'RadNotification
        '
        Me.RadNotification.CanMove = False
        Me.RadNotification.Opacity = 0.9!
        Me.RadNotification.ShowOptionsButton = False
        Me.RadNotification.ShowPinButton = False
        '
        'tmrReminder
        '
        '
        'RadCentrale
        '
        Me.RadCentrale.AutoClose = False
        Me.RadCentrale.AutoCloseDelay = 3
        Me.RadCentrale.AutoSize = True
        Me.RadCentrale.CaptionText = "ATTENZIONE"
        Me.RadCentrale.ContentImage = Global.Former.My.Resources.Resources.AttenzioneCommessa481
        Me.RadCentrale.FadeAnimationType = Telerik.WinControls.UI.FadeAnimationType.None
        Me.RadCentrale.Opacity = 1.0!
        Me.RadCentrale.PopupAnimation = False
        Me.RadCentrale.ScreenPosition = Telerik.WinControls.UI.AlertScreenPosition.TopRight
        Me.RadCentrale.ShowOptionsButton = False
        Me.RadCentrale.ShowPinButton = False
        Me.RadCentrale.ThemeName = "VisualStudio2012Dark"
        '
        'ucMainToolbar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.FlowLayoutPanelToolbar)
        Me.Name = "ucMainToolbar"
        Me.Size = New System.Drawing.Size(1293, 35)
        Me.FlowLayoutPanelToolbar.ResumeLayout(False)
        Me.FlowLayoutPanelToolbar.PerformLayout()
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanelToolbar As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tmrConnAtt As System.Windows.Forms.Timer
    Friend WithEvents lblCounter As ucLabel
    Friend WithEvents tmrPulisciMemoria As System.Windows.Forms.Timer
    Friend WithEvents lblConn As System.Windows.Forms.Label
    Friend WithEvents toolTipMsg As System.Windows.Forms.ToolTip
    Friend WithEvents tmrConnDemone As System.Windows.Forms.Timer
    Friend WithEvents lnkChiamate As LinkLabel
    Friend WithEvents cmbUtenteLoggato As ComboBox
    Friend WithEvents lblNotifiche As LinkLabel
    Friend WithEvents MenuStripMain As MenuStrip
    Friend WithEvents StrumentiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalcolatriceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalcolatriceDigitaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalcolatricePesoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CercaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConBarcodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents LogOperatoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StrumentiToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents NumerazioneAutomaticaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcedimentoFustelleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HotFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarcodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolstripInserisciOrdine As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents lblNewVer As ucLabel
    Friend WithEvents PubblicazioneListinoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FunctionLockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreRefineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreazioneCommesseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StampaComandaOperatoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents AiutoProcedureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StampaEtichettaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RadNotification As Telerik.WinControls.UI.RadDesktopAlert
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents SegnalazioneAnomaliaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneraListinoPDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PDFToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents MagazzinoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ScaricoMaterialeDiConsumoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SegnalazioneAcquistoRisorsaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents StornoRisorsaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InviaSchermataCorrenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalcoloPrezzoLavorazioneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents CercaFileSorgentiGrandiDimensioniToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tmrReminder As Timer
    Friend WithEvents AllegaFileOnlineMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents DocumentoDiCaricoDiMagazzinoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents VediLultimoReleaseNoteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RadCentrale As Telerik.WinControls.UI.RadDesktopAlert
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem As ToolStripMenuItem
End Class
