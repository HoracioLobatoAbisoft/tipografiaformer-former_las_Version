Imports FormerControl

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form
    'Inherits MaterialSkin.Controls.MaterialForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnMessage = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.btnReconnect = New System.Windows.Forms.Button()
        Me.btnCaller = New System.Windows.Forms.Button()
        Me.btnTestPerformance = New System.Windows.Forms.Button()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbTipoUDP = New System.Windows.Forms.ComboBox()
        Me.btnTestSvls = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tpAltro = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnImportContacts = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnStopSearch = New System.Windows.Forms.Button()
        Me.txtDebug = New System.Windows.Forms.TextBox()
        Me.btnGetChiave = New System.Windows.Forms.Button()
        Me.btnStampaCodiceBarre = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.btnEventViewer = New System.Windows.Forms.Button()
        Me.tpOrdini = New System.Windows.Forms.TabPage()
        Me.btnRicreaConsegna = New System.Windows.Forms.Button()
        Me.btnLogOrdOnline = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btnRegistraPagamento = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtIdConsOnline = New System.Windows.Forms.TextBox()
        Me.btnLogOrdineInt = New System.Windows.Forms.Button()
        Me.btnRiportaIndietroConsegna = New System.Windows.Forms.Button()
        Me.lblIdConsFromIdOrd = New System.Windows.Forms.Label()
        Me.btnIdConsFromIdOrd = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIdOrdine = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnRigeneraAnteprima = New System.Windows.Forms.Button()
        Me.cmbStato = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCambiaStato = New System.Windows.Forms.Button()
        Me.txtOrdCambioStato = New System.Windows.Forms.TextBox()
        Me.lblRisDup = New System.Windows.Forms.Label()
        Me.lblRisDup2 = New System.Windows.Forms.Label()
        Me.btnLega = New System.Windows.Forms.Button()
        Me.btnDuplicaConsFromOrd = New System.Windows.Forms.Button()
        Me.btnDuplicaCons = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdConsegna = New System.Windows.Forms.TextBox()
        Me.tpBug = New System.Windows.Forms.TabPage()
        Me.btnDelBug = New System.Windows.Forms.Button()
        Me.btnBugLavorato = New System.Windows.Forms.Button()
        Me.lblBugTitolo = New System.Windows.Forms.Label()
        Me.txtBug = New System.Windows.Forms.TextBox()
        Me.btnAggiornaBug = New System.Windows.Forms.Button()
        Me.tvBug = New System.Windows.Forms.TreeView()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.pctBug = New System.Windows.Forms.PictureBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnGeneraReport = New System.Windows.Forms.Button()
        Me.webReport = New System.Windows.Forms.WebBrowser()
        Me.tpUdp = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtUtConnection = New System.Windows.Forms.TextBox()
        Me.tpCosaVedono = New System.Windows.Forms.TabPage()
        Me.btnLoadCosaVede = New System.Windows.Forms.Button()
        Me.txtIdUtOnline = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgLavori = New System.Windows.Forms.DataGridView()
        Me.IdOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataIns = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgConsegne = New System.Windows.Forms.DataGridView()
        Me.IdCons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Giorno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpBan = New System.Windows.Forms.TabPage()
        Me.btnBan = New System.Windows.Forms.Button()
        Me.btnGeo = New System.Windows.Forms.Button()
        Me.btnMalicious = New System.Windows.Forms.Button()
        Me.txtIp = New System.Windows.Forms.TextBox()
        Me.webBan = New System.Windows.Forms.WebBrowser()
        Me.tpPassword = New System.Windows.Forms.TabPage()
        Me.txtPwdOrig = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCriptaPwd = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPwdCriptata = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdoOrange = New System.Windows.Forms.RadioButton()
        Me.cmbColoreStatoOrd = New System.Windows.Forms.ComboBox()
        Me.rdoStatoOrdine = New System.Windows.Forms.RadioButton()
        Me.rdoCustom = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoBianca = New System.Windows.Forms.RadioButton()
        Me.rdoNera = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoRect = New System.Windows.Forms.RadioButton()
        Me.rdoCerchio = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCreaIcona = New System.Windows.Forms.Button()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lblVerDemone = New System.Windows.Forms.Label()
        Me.lblVerGest = New System.Windows.Forms.Label()
        Me.btnRilascioSitoProduzione = New System.Windows.Forms.Button()
        Me.btnRilascioGestionale = New FormerLab.RoundedButton()
        Me.btnRilascioSito = New System.Windows.Forms.Button()
        Me.btnRilascioDemone = New System.Windows.Forms.Button()
        Me.CircleShape1 = New Telerik.WinControls.CircleShape()
        Me.lblConnStringWeb = New System.Windows.Forms.Label()
        Me.lblConnStringSql = New System.Windows.Forms.Label()
        Me.tpTestWeb = New System.Windows.Forms.TabPage()
        Me.brwTestWeb = New System.Windows.Forms.WebBrowser()
        Me.GroupBox1.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tpAltro.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.tpOrdini.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tpBug.SuspendLayout()
        CType(Me.pctBug, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.tpUdp.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tpCosaVedono.SuspendLayout()
        CType(Me.dgLavori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgConsegne, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpBan.SuspendLayout()
        Me.tpPassword.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.tpTestWeb.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMessage
        '
        Me.btnMessage.ForeColor = System.Drawing.Color.Black
        Me.btnMessage.Location = New System.Drawing.Point(7, 22)
        Me.btnMessage.Name = "btnMessage"
        Me.btnMessage.Size = New System.Drawing.Size(281, 27)
        Me.btnMessage.TabIndex = 0
        Me.btnMessage.Text = "UDP Message"
        Me.btnMessage.UseVisualStyleBackColor = True
        '
        'btnDisconnect
        '
        Me.btnDisconnect.ForeColor = System.Drawing.Color.Black
        Me.btnDisconnect.Location = New System.Drawing.Point(7, 20)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(281, 27)
        Me.btnDisconnect.TabIndex = 1
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'btnReconnect
        '
        Me.btnReconnect.ForeColor = System.Drawing.Color.Black
        Me.btnReconnect.Location = New System.Drawing.Point(294, 20)
        Me.btnReconnect.Name = "btnReconnect"
        Me.btnReconnect.Size = New System.Drawing.Size(281, 27)
        Me.btnReconnect.TabIndex = 2
        Me.btnReconnect.Text = "Reconnect"
        Me.btnReconnect.UseVisualStyleBackColor = True
        '
        'btnCaller
        '
        Me.btnCaller.Location = New System.Drawing.Point(6, 136)
        Me.btnCaller.Name = "btnCaller"
        Me.btnCaller.Size = New System.Drawing.Size(281, 27)
        Me.btnCaller.TabIndex = 3
        Me.btnCaller.Text = "CallerId"
        Me.btnCaller.UseVisualStyleBackColor = True
        '
        'btnTestPerformance
        '
        Me.btnTestPerformance.Enabled = False
        Me.btnTestPerformance.Location = New System.Drawing.Point(6, 170)
        Me.btnTestPerformance.Name = "btnTestPerformance"
        Me.btnTestPerformance.Size = New System.Drawing.Size(281, 27)
        Me.btnTestPerformance.TabIndex = 3
        Me.btnTestPerformance.Text = "Test Insert Con TransactionBox"
        Me.btnTestPerformance.UseVisualStyleBackColor = True
        '
        'txtMsg
        '
        Me.txtMsg.ForeColor = System.Drawing.Color.Black
        Me.txtMsg.Location = New System.Drawing.Point(547, 25)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(504, 21)
        Me.txtMsg.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbTipoUDP)
        Me.GroupBox1.Controls.Add(Me.btnMessage)
        Me.GroupBox1.Controls.Add(Me.txtMsg)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1057, 55)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Messaggio Broadcast"
        '
        'cmbTipoUDP
        '
        Me.cmbTipoUDP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoUDP.FormattingEnabled = True
        Me.cmbTipoUDP.Location = New System.Drawing.Point(294, 25)
        Me.cmbTipoUDP.Name = "cmbTipoUDP"
        Me.cmbTipoUDP.Size = New System.Drawing.Size(247, 23)
        Me.cmbTipoUDP.TabIndex = 5
        '
        'btnTestSvls
        '
        Me.btnTestSvls.Enabled = False
        Me.btnTestSvls.Location = New System.Drawing.Point(7, 203)
        Me.btnTestSvls.Name = "btnTestSvls"
        Me.btnTestSvls.Size = New System.Drawing.Size(280, 27)
        Me.btnTestSvls.TabIndex = 7
        Me.btnTestSvls.Text = "testSvls"
        Me.btnTestSvls.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tpAltro)
        Me.TabMain.Controls.Add(Me.tpOrdini)
        Me.TabMain.Controls.Add(Me.tpBug)
        Me.TabMain.Controls.Add(Me.TabPage4)
        Me.TabMain.Controls.Add(Me.tpUdp)
        Me.TabMain.Controls.Add(Me.tpCosaVedono)
        Me.TabMain.Controls.Add(Me.tpBan)
        Me.TabMain.Controls.Add(Me.tpPassword)
        Me.TabMain.Controls.Add(Me.TabPage3)
        Me.TabMain.Controls.Add(Me.tpTestWeb)
        Me.TabMain.ImageList = Me.imlTab
        Me.TabMain.Location = New System.Drawing.Point(0, 63)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1230, 476)
        Me.TabMain.TabIndex = 8
        '
        'tpAltro
        '
        Me.tpAltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.tpAltro.Controls.Add(Me.GroupBox4)
        Me.tpAltro.Controls.Add(Me.GroupBox6)
        Me.tpAltro.Location = New System.Drawing.Point(4, 24)
        Me.tpAltro.Name = "tpAltro"
        Me.tpAltro.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAltro.Size = New System.Drawing.Size(1222, 448)
        Me.tpAltro.TabIndex = 5
        Me.tpAltro.Text = "Home"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.btnImportContacts)
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(8, 382)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1206, 57)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Import Eventi"
        '
        'btnImportContacts
        '
        Me.btnImportContacts.ForeColor = System.Drawing.Color.Black
        Me.btnImportContacts.Location = New System.Drawing.Point(9, 20)
        Me.btnImportContacts.Name = "btnImportContacts"
        Me.btnImportContacts.Size = New System.Drawing.Size(91, 23)
        Me.btnImportContacts.TabIndex = 0
        Me.btnImportContacts.Text = "Import"
        Me.btnImportContacts.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.btnStopSearch)
        Me.GroupBox6.Controls.Add(Me.txtDebug)
        Me.GroupBox6.Controls.Add(Me.btnGetChiave)
        Me.GroupBox6.Controls.Add(Me.btnStampaCodiceBarre)
        Me.GroupBox6.Controls.Add(Me.btnTest)
        Me.GroupBox6.Controls.Add(Me.btnEventViewer)
        Me.GroupBox6.ForeColor = System.Drawing.Color.White
        Me.GroupBox6.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1206, 289)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Altro"
        '
        'btnStopSearch
        '
        Me.btnStopSearch.ForeColor = System.Drawing.Color.Black
        Me.btnStopSearch.Location = New System.Drawing.Point(9, 169)
        Me.btnStopSearch.Name = "btnStopSearch"
        Me.btnStopSearch.Size = New System.Drawing.Size(172, 23)
        Me.btnStopSearch.TabIndex = 5
        Me.btnStopSearch.Text = "Stop Search"
        Me.btnStopSearch.UseVisualStyleBackColor = True
        '
        'txtDebug
        '
        Me.txtDebug.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDebug.Location = New System.Drawing.Point(187, 21)
        Me.txtDebug.Multiline = True
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDebug.Size = New System.Drawing.Size(1013, 262)
        Me.txtDebug.TabIndex = 4
        '
        'btnGetChiave
        '
        Me.btnGetChiave.ForeColor = System.Drawing.Color.Black
        Me.btnGetChiave.Location = New System.Drawing.Point(8, 83)
        Me.btnGetChiave.Name = "btnGetChiave"
        Me.btnGetChiave.Size = New System.Drawing.Size(172, 23)
        Me.btnGetChiave.TabIndex = 3
        Me.btnGetChiave.Text = "Get Chiave Default"
        Me.btnGetChiave.UseVisualStyleBackColor = True
        '
        'btnStampaCodiceBarre
        '
        Me.btnStampaCodiceBarre.ForeColor = System.Drawing.Color.Black
        Me.btnStampaCodiceBarre.Location = New System.Drawing.Point(7, 141)
        Me.btnStampaCodiceBarre.Name = "btnStampaCodiceBarre"
        Me.btnStampaCodiceBarre.Size = New System.Drawing.Size(173, 23)
        Me.btnStampaCodiceBarre.TabIndex = 0
        Me.btnStampaCodiceBarre.Text = "Stampa Codice a Barre"
        Me.btnStampaCodiceBarre.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.ForeColor = System.Drawing.Color.Black
        Me.btnTest.Location = New System.Drawing.Point(8, 20)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(172, 51)
        Me.btnTest.TabIndex = 2
        Me.btnTest.Text = "Esegui Azione di Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'btnEventViewer
        '
        Me.btnEventViewer.ForeColor = System.Drawing.Color.Black
        Me.btnEventViewer.Location = New System.Drawing.Point(8, 112)
        Me.btnEventViewer.Name = "btnEventViewer"
        Me.btnEventViewer.Size = New System.Drawing.Size(172, 23)
        Me.btnEventViewer.TabIndex = 2
        Me.btnEventViewer.Text = "Errore Nel Registro"
        Me.btnEventViewer.UseVisualStyleBackColor = True
        '
        'tpOrdini
        '
        Me.tpOrdini.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.tpOrdini.Controls.Add(Me.btnRicreaConsegna)
        Me.tpOrdini.Controls.Add(Me.btnLogOrdOnline)
        Me.tpOrdini.Controls.Add(Me.GroupBox8)
        Me.tpOrdini.Controls.Add(Me.btnLogOrdineInt)
        Me.tpOrdini.Controls.Add(Me.btnRiportaIndietroConsegna)
        Me.tpOrdini.Controls.Add(Me.lblIdConsFromIdOrd)
        Me.tpOrdini.Controls.Add(Me.btnIdConsFromIdOrd)
        Me.tpOrdini.Controls.Add(Me.Label8)
        Me.tpOrdini.Controls.Add(Me.txtIdOrdine)
        Me.tpOrdini.Controls.Add(Me.GroupBox3)
        Me.tpOrdini.Controls.Add(Me.lblRisDup)
        Me.tpOrdini.Controls.Add(Me.lblRisDup2)
        Me.tpOrdini.Controls.Add(Me.btnLega)
        Me.tpOrdini.Controls.Add(Me.btnDuplicaConsFromOrd)
        Me.tpOrdini.Controls.Add(Me.btnDuplicaCons)
        Me.tpOrdini.Controls.Add(Me.Label1)
        Me.tpOrdini.Controls.Add(Me.txtIdConsegna)
        Me.tpOrdini.Location = New System.Drawing.Point(4, 24)
        Me.tpOrdini.Name = "tpOrdini"
        Me.tpOrdini.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrdini.Size = New System.Drawing.Size(1222, 448)
        Me.tpOrdini.TabIndex = 1
        Me.tpOrdini.Text = "Procedure su Ordini e Consegne"
        '
        'btnRicreaConsegna
        '
        Me.btnRicreaConsegna.Location = New System.Drawing.Point(425, 50)
        Me.btnRicreaConsegna.Name = "btnRicreaConsegna"
        Me.btnRicreaConsegna.Size = New System.Drawing.Size(309, 27)
        Me.btnRicreaConsegna.TabIndex = 26
        Me.btnRicreaConsegna.Text = "Ricrea Consegna Nuova da IdOrdine"
        Me.btnRicreaConsegna.UseVisualStyleBackColor = True
        '
        'btnLogOrdOnline
        '
        Me.btnLogOrdOnline.ForeColor = System.Drawing.Color.Black
        Me.btnLogOrdOnline.Location = New System.Drawing.Point(12, 246)
        Me.btnLogOrdOnline.Name = "btnLogOrdOnline"
        Me.btnLogOrdOnline.Size = New System.Drawing.Size(309, 27)
        Me.btnLogOrdOnline.TabIndex = 25
        Me.btnLogOrdOnline.Text = "Apri Log Ordine Online"
        Me.btnLogOrdOnline.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnRegistraPagamento)
        Me.GroupBox8.Controls.Add(Me.Label16)
        Me.GroupBox8.Controls.Add(Me.txtIdConsOnline)
        Me.GroupBox8.ForeColor = System.Drawing.Color.White
        Me.GroupBox8.Location = New System.Drawing.Point(12, 364)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(1002, 51)
        Me.GroupBox8.TabIndex = 24
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Registra manualmente pagamento Paypal"
        '
        'btnRegistraPagamento
        '
        Me.btnRegistraPagamento.ForeColor = System.Drawing.Color.Black
        Me.btnRegistraPagamento.Location = New System.Drawing.Point(204, 18)
        Me.btnRegistraPagamento.Name = "btnRegistraPagamento"
        Me.btnRegistraPagamento.Size = New System.Drawing.Size(256, 23)
        Me.btnRegistraPagamento.TabIndex = 25
        Me.btnRegistraPagamento.Text = "Registra Pagamento"
        Me.btnRegistraPagamento.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(6, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 15)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Id Cons Onl."
        '
        'txtIdConsOnline
        '
        Me.txtIdConsOnline.Location = New System.Drawing.Point(93, 20)
        Me.txtIdConsOnline.Name = "txtIdConsOnline"
        Me.txtIdConsOnline.Size = New System.Drawing.Size(96, 21)
        Me.txtIdConsOnline.TabIndex = 2
        '
        'btnLogOrdineInt
        '
        Me.btnLogOrdineInt.ForeColor = System.Drawing.Color.Black
        Me.btnLogOrdineInt.Location = New System.Drawing.Point(12, 213)
        Me.btnLogOrdineInt.Name = "btnLogOrdineInt"
        Me.btnLogOrdineInt.Size = New System.Drawing.Size(309, 27)
        Me.btnLogOrdineInt.TabIndex = 24
        Me.btnLogOrdineInt.Text = "Apri Log Ordine Interno"
        Me.btnLogOrdineInt.UseVisualStyleBackColor = True
        '
        'btnRiportaIndietroConsegna
        '
        Me.btnRiportaIndietroConsegna.Location = New System.Drawing.Point(12, 178)
        Me.btnRiportaIndietroConsegna.Name = "btnRiportaIndietroConsegna"
        Me.btnRiportaIndietroConsegna.Size = New System.Drawing.Size(309, 27)
        Me.btnRiportaIndietroConsegna.TabIndex = 22
        Me.btnRiportaIndietroConsegna.Text = "Riporta consegna a In Lavorazione da Id Ordine"
        Me.btnRiportaIndietroConsegna.UseVisualStyleBackColor = True
        '
        'lblIdConsFromIdOrd
        '
        Me.lblIdConsFromIdOrd.Location = New System.Drawing.Point(327, 56)
        Me.lblIdConsFromIdOrd.Name = "lblIdConsFromIdOrd"
        Me.lblIdConsFromIdOrd.Size = New System.Drawing.Size(92, 13)
        Me.lblIdConsFromIdOrd.TabIndex = 19
        Me.lblIdConsFromIdOrd.Text = "-"
        '
        'btnIdConsFromIdOrd
        '
        Me.btnIdConsFromIdOrd.Location = New System.Drawing.Point(12, 50)
        Me.btnIdConsFromIdOrd.Name = "btnIdConsFromIdOrd"
        Me.btnIdConsFromIdOrd.Size = New System.Drawing.Size(309, 27)
        Me.btnIdConsFromIdOrd.TabIndex = 18
        Me.btnIdConsFromIdOrd.Text = "Recupera Id Consegna da Id Ordine"
        Me.btnIdConsFromIdOrd.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Id Ordine"
        '
        'txtIdOrdine
        '
        Me.txtIdOrdine.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.txtIdOrdine.Location = New System.Drawing.Point(105, 15)
        Me.txtIdOrdine.Name = "txtIdOrdine"
        Me.txtIdOrdine.Size = New System.Drawing.Size(96, 29)
        Me.txtIdOrdine.TabIndex = 16
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnRigeneraAnteprima)
        Me.GroupBox3.Controls.Add(Me.cmbStato)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.btnCambiaStato)
        Me.GroupBox3.Controls.Add(Me.txtOrdCambioStato)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(12, 279)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1202, 79)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Procedure batch"
        '
        'btnRigeneraAnteprima
        '
        Me.btnRigeneraAnteprima.ForeColor = System.Drawing.Color.Black
        Me.btnRigeneraAnteprima.Location = New System.Drawing.Point(1002, 14)
        Me.btnRigeneraAnteprima.Name = "btnRigeneraAnteprima"
        Me.btnRigeneraAnteprima.Size = New System.Drawing.Size(188, 27)
        Me.btnRigeneraAnteprima.TabIndex = 16
        Me.btnRigeneraAnteprima.Text = "Rigenera Anteprima"
        Me.btnRigeneraAnteprima.UseVisualStyleBackColor = True
        '
        'cmbStato
        '
        Me.cmbStato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStato.FormattingEnabled = True
        Me.cmbStato.Location = New System.Drawing.Point(522, 17)
        Me.cmbStato.Name = "cmbStato"
        Me.cmbStato.Size = New System.Drawing.Size(278, 23)
        Me.cmbStato.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Id Ordini"
        '
        'btnCambiaStato
        '
        Me.btnCambiaStato.ForeColor = System.Drawing.Color.Black
        Me.btnCambiaStato.Location = New System.Drawing.Point(808, 14)
        Me.btnCambiaStato.Name = "btnCambiaStato"
        Me.btnCambiaStato.Size = New System.Drawing.Size(188, 27)
        Me.btnCambiaStato.TabIndex = 14
        Me.btnCambiaStato.Text = "Cambia Stato"
        Me.btnCambiaStato.UseVisualStyleBackColor = True
        '
        'txtOrdCambioStato
        '
        Me.txtOrdCambioStato.ForeColor = System.Drawing.Color.Black
        Me.txtOrdCambioStato.Location = New System.Drawing.Point(65, 17)
        Me.txtOrdCambioStato.Name = "txtOrdCambioStato"
        Me.txtOrdCambioStato.Size = New System.Drawing.Size(448, 21)
        Me.txtOrdCambioStato.TabIndex = 12
        '
        'lblRisDup
        '
        Me.lblRisDup.Location = New System.Drawing.Point(327, 89)
        Me.lblRisDup.Name = "lblRisDup"
        Me.lblRisDup.Size = New System.Drawing.Size(92, 13)
        Me.lblRisDup.TabIndex = 11
        Me.lblRisDup.Text = "-"
        '
        'lblRisDup2
        '
        Me.lblRisDup2.Location = New System.Drawing.Point(327, 122)
        Me.lblRisDup2.Name = "lblRisDup2"
        Me.lblRisDup2.Size = New System.Drawing.Size(92, 13)
        Me.lblRisDup2.TabIndex = 11
        Me.lblRisDup2.Text = "-"
        '
        'btnLega
        '
        Me.btnLega.Location = New System.Drawing.Point(12, 149)
        Me.btnLega.Name = "btnLega"
        Me.btnLega.Size = New System.Drawing.Size(309, 23)
        Me.btnLega.TabIndex = 10
        Me.btnLega.Text = "Lega ID Ordine a ID Consegna"
        Me.btnLega.UseVisualStyleBackColor = True
        '
        'btnDuplicaConsFromOrd
        '
        Me.btnDuplicaConsFromOrd.Location = New System.Drawing.Point(12, 116)
        Me.btnDuplicaConsFromOrd.Name = "btnDuplicaConsFromOrd"
        Me.btnDuplicaConsFromOrd.Size = New System.Drawing.Size(309, 27)
        Me.btnDuplicaConsFromOrd.TabIndex = 5
        Me.btnDuplicaConsFromOrd.Text = "Duplica Consegna da Ordine (Incluso nella nuova)"
        Me.btnDuplicaConsFromOrd.UseVisualStyleBackColor = True
        '
        'btnDuplicaCons
        '
        Me.btnDuplicaCons.Location = New System.Drawing.Point(12, 83)
        Me.btnDuplicaCons.Name = "btnDuplicaCons"
        Me.btnDuplicaCons.Size = New System.Drawing.Size(309, 27)
        Me.btnDuplicaCons.TabIndex = 2
        Me.btnDuplicaCons.Text = "Duplica Consegna"
        Me.btnDuplicaCons.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(236, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID Consegna"
        '
        'txtIdConsegna
        '
        Me.txtIdConsegna.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.txtIdConsegna.Location = New System.Drawing.Point(325, 15)
        Me.txtIdConsegna.Name = "txtIdConsegna"
        Me.txtIdConsegna.Size = New System.Drawing.Size(96, 29)
        Me.txtIdConsegna.TabIndex = 0
        '
        'tpBug
        '
        Me.tpBug.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.tpBug.Controls.Add(Me.btnDelBug)
        Me.tpBug.Controls.Add(Me.btnBugLavorato)
        Me.tpBug.Controls.Add(Me.lblBugTitolo)
        Me.tpBug.Controls.Add(Me.txtBug)
        Me.tpBug.Controls.Add(Me.btnAggiornaBug)
        Me.tpBug.Controls.Add(Me.tvBug)
        Me.tpBug.Controls.Add(Me.pctBug)
        Me.tpBug.ImageKey = "002_27.png"
        Me.tpBug.Location = New System.Drawing.Point(4, 24)
        Me.tpBug.Name = "tpBug"
        Me.tpBug.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBug.Size = New System.Drawing.Size(1222, 448)
        Me.tpBug.TabIndex = 8
        Me.tpBug.Text = "Bug"
        '
        'btnDelBug
        '
        Me.btnDelBug.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelBug.BackColor = System.Drawing.Color.Red
        Me.btnDelBug.ForeColor = System.Drawing.Color.White
        Me.btnDelBug.Location = New System.Drawing.Point(813, 6)
        Me.btnDelBug.Name = "btnDelBug"
        Me.btnDelBug.Size = New System.Drawing.Size(75, 23)
        Me.btnDelBug.TabIndex = 6
        Me.btnDelBug.Text = "Elimina"
        Me.btnDelBug.UseVisualStyleBackColor = False
        '
        'btnBugLavorato
        '
        Me.btnBugLavorato.BackColor = System.Drawing.Color.Green
        Me.btnBugLavorato.ForeColor = System.Drawing.Color.White
        Me.btnBugLavorato.Location = New System.Drawing.Point(309, 6)
        Me.btnBugLavorato.Name = "btnBugLavorato"
        Me.btnBugLavorato.Size = New System.Drawing.Size(75, 23)
        Me.btnBugLavorato.TabIndex = 5
        Me.btnBugLavorato.Text = "Lavorato"
        Me.btnBugLavorato.UseVisualStyleBackColor = False
        '
        'lblBugTitolo
        '
        Me.lblBugTitolo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBugTitolo.BackColor = System.Drawing.Color.LightGray
        Me.lblBugTitolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBugTitolo.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblBugTitolo.Location = New System.Drawing.Point(310, 35)
        Me.lblBugTitolo.Name = "lblBugTitolo"
        Me.lblBugTitolo.Size = New System.Drawing.Size(578, 35)
        Me.lblBugTitolo.TabIndex = 3
        Me.lblBugTitolo.Text = "-"
        Me.lblBugTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBug
        '
        Me.txtBug.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBug.Location = New System.Drawing.Point(309, 73)
        Me.txtBug.Multiline = True
        Me.txtBug.Name = "txtBug"
        Me.txtBug.ReadOnly = True
        Me.txtBug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBug.Size = New System.Drawing.Size(579, 381)
        Me.txtBug.TabIndex = 2
        '
        'btnAggiornaBug
        '
        Me.btnAggiornaBug.Location = New System.Drawing.Point(9, 6)
        Me.btnAggiornaBug.Name = "btnAggiornaBug"
        Me.btnAggiornaBug.Size = New System.Drawing.Size(75, 23)
        Me.btnAggiornaBug.TabIndex = 1
        Me.btnAggiornaBug.Text = "Aggiorna"
        Me.btnAggiornaBug.UseVisualStyleBackColor = True
        '
        'tvBug
        '
        Me.tvBug.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvBug.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.tvBug.ImageIndex = 0
        Me.tvBug.ImageList = Me.imlTab
        Me.tvBug.Location = New System.Drawing.Point(9, 35)
        Me.tvBug.Name = "tvBug"
        Me.tvBug.SelectedImageIndex = 0
        Me.tvBug.Size = New System.Drawing.Size(294, 419)
        Me.tvBug.TabIndex = 0
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "002_27.png")
        '
        'pctBug
        '
        Me.pctBug.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctBug.Location = New System.Drawing.Point(894, 35)
        Me.pctBug.Name = "pctBug"
        Me.pctBug.Size = New System.Drawing.Size(320, 180)
        Me.pctBug.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctBug.TabIndex = 4
        Me.pctBug.TabStop = False
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.btnPrint)
        Me.TabPage4.Controls.Add(Me.btnGeneraReport)
        Me.TabPage4.Controls.Add(Me.webReport)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1222, 448)
        Me.TabPage4.TabIndex = 13
        Me.TabPage4.Text = "Report"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(84, 6)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Stampa"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnGeneraReport
        '
        Me.btnGeneraReport.Location = New System.Drawing.Point(3, 6)
        Me.btnGeneraReport.Name = "btnGeneraReport"
        Me.btnGeneraReport.Size = New System.Drawing.Size(75, 23)
        Me.btnGeneraReport.TabIndex = 2
        Me.btnGeneraReport.Text = "Aggiorna"
        Me.btnGeneraReport.UseVisualStyleBackColor = True
        '
        'webReport
        '
        Me.webReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webReport.Location = New System.Drawing.Point(3, 35)
        Me.webReport.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webReport.Name = "webReport"
        Me.webReport.Size = New System.Drawing.Size(1216, 422)
        Me.webReport.TabIndex = 0
        '
        'tpUdp
        '
        Me.tpUdp.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.tpUdp.Controls.Add(Me.GroupBox2)
        Me.tpUdp.Controls.Add(Me.GroupBox1)
        Me.tpUdp.Controls.Add(Me.btnTestSvls)
        Me.tpUdp.Controls.Add(Me.btnCaller)
        Me.tpUdp.Controls.Add(Me.btnTestPerformance)
        Me.tpUdp.Location = New System.Drawing.Point(4, 24)
        Me.tpUdp.Name = "tpUdp"
        Me.tpUdp.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUdp.Size = New System.Drawing.Size(1222, 448)
        Me.tpUdp.TabIndex = 0
        Me.tpUdp.Text = "UDP"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtUtConnection)
        Me.GroupBox2.Controls.Add(Me.btnDisconnect)
        Me.GroupBox2.Controls.Add(Me.btnReconnect)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(7, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(814, 62)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DB Connection"
        '
        'txtUtConnection
        '
        Me.txtUtConnection.Location = New System.Drawing.Point(581, 20)
        Me.txtUtConnection.Name = "txtUtConnection"
        Me.txtUtConnection.Size = New System.Drawing.Size(219, 21)
        Me.txtUtConnection.TabIndex = 3
        '
        'tpCosaVedono
        '
        Me.tpCosaVedono.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.tpCosaVedono.Controls.Add(Me.btnLoadCosaVede)
        Me.tpCosaVedono.Controls.Add(Me.txtIdUtOnline)
        Me.tpCosaVedono.Controls.Add(Me.Label15)
        Me.tpCosaVedono.Controls.Add(Me.Label14)
        Me.tpCosaVedono.Controls.Add(Me.dgLavori)
        Me.tpCosaVedono.Controls.Add(Me.Label13)
        Me.tpCosaVedono.Controls.Add(Me.dgConsegne)
        Me.tpCosaVedono.Location = New System.Drawing.Point(4, 24)
        Me.tpCosaVedono.Name = "tpCosaVedono"
        Me.tpCosaVedono.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCosaVedono.Size = New System.Drawing.Size(1222, 448)
        Me.tpCosaVedono.TabIndex = 6
        Me.tpCosaVedono.Text = "Cosa vedono gli utenti"
        '
        'btnLoadCosaVede
        '
        Me.btnLoadCosaVede.Location = New System.Drawing.Point(1100, 10)
        Me.btnLoadCosaVede.Name = "btnLoadCosaVede"
        Me.btnLoadCosaVede.Size = New System.Drawing.Size(114, 23)
        Me.btnLoadCosaVede.TabIndex = 67
        Me.btnLoadCosaVede.Text = "Carica"
        Me.btnLoadCosaVede.UseVisualStyleBackColor = True
        '
        'txtIdUtOnline
        '
        Me.txtIdUtOnline.Location = New System.Drawing.Point(998, 11)
        Me.txtIdUtOnline.Name = "txtIdUtOnline"
        Me.txtIdUtOnline.Size = New System.Drawing.Size(96, 21)
        Me.txtIdUtOnline.TabIndex = 66
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(925, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 15)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Id ut online"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(8, 260)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 15)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "Lavori"
        '
        'dgLavori
        '
        Me.dgLavori.AllowUserToAddRows = False
        Me.dgLavori.AllowUserToDeleteRows = False
        Me.dgLavori.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgLavori.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLavori.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLavori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgLavori.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgLavori.BackgroundColor = System.Drawing.Color.White
        Me.dgLavori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLavori.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLavori.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgLavori.ColumnHeadersHeight = 20
        Me.dgLavori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgLavori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOrd, Me.DataGridViewTextBoxColumn1, Me.DataIns})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLavori.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgLavori.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgLavori.EnableHeadersVisualStyles = False
        Me.dgLavori.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgLavori.Location = New System.Drawing.Point(11, 278)
        Me.dgLavori.MultiSelect = False
        Me.dgLavori.Name = "dgLavori"
        Me.dgLavori.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLavori.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgLavori.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgLavori.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgLavori.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dgLavori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgLavori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgLavori.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLavori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLavori.Size = New System.Drawing.Size(1205, 176)
        Me.dgLavori.TabIndex = 63
        Me.dgLavori.TabStop = False
        '
        'IdOrd
        '
        Me.IdOrd.DataPropertyName = "IdOrdine"
        Me.IdOrd.HeaderText = "IdOrd"
        Me.IdOrd.Name = "IdOrd"
        Me.IdOrd.ReadOnly = True
        Me.IdOrd.Width = 61
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IdCons"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdCons"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 71
        '
        'DataIns
        '
        Me.DataIns.DataPropertyName = "DataIns"
        Me.DataIns.HeaderText = "DataIns"
        Me.DataIns.Name = "DataIns"
        Me.DataIns.ReadOnly = True
        Me.DataIns.Width = 74
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(8, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 15)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Consegne"
        '
        'dgConsegne
        '
        Me.dgConsegne.AllowUserToAddRows = False
        Me.dgConsegne.AllowUserToDeleteRows = False
        Me.dgConsegne.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.dgConsegne.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgConsegne.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgConsegne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgConsegne.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgConsegne.BackgroundColor = System.Drawing.Color.White
        Me.dgConsegne.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgConsegne.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgConsegne.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgConsegne.ColumnHeadersHeight = 20
        Me.dgConsegne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgConsegne.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCons, Me.Giorno})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgConsegne.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgConsegne.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgConsegne.EnableHeadersVisualStyles = False
        Me.dgConsegne.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgConsegne.Location = New System.Drawing.Point(11, 32)
        Me.dgConsegne.MultiSelect = False
        Me.dgConsegne.Name = "dgConsegne"
        Me.dgConsegne.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgConsegne.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgConsegne.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgConsegne.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgConsegne.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dgConsegne.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgConsegne.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgConsegne.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgConsegne.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgConsegne.Size = New System.Drawing.Size(1203, 224)
        Me.dgConsegne.TabIndex = 61
        Me.dgConsegne.TabStop = False
        '
        'IdCons
        '
        Me.IdCons.DataPropertyName = "IdConsegna"
        Me.IdCons.HeaderText = "IDCons"
        Me.IdCons.Name = "IdCons"
        Me.IdCons.ReadOnly = True
        Me.IdCons.Width = 73
        '
        'Giorno
        '
        Me.Giorno.DataPropertyName = "Giorno"
        Me.Giorno.HeaderText = "Giorno"
        Me.Giorno.Name = "Giorno"
        Me.Giorno.ReadOnly = True
        Me.Giorno.Width = 68
        '
        'tpBan
        '
        Me.tpBan.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.tpBan.Controls.Add(Me.btnBan)
        Me.tpBan.Controls.Add(Me.btnGeo)
        Me.tpBan.Controls.Add(Me.btnMalicious)
        Me.tpBan.Controls.Add(Me.txtIp)
        Me.tpBan.Controls.Add(Me.webBan)
        Me.tpBan.Location = New System.Drawing.Point(4, 24)
        Me.tpBan.Name = "tpBan"
        Me.tpBan.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBan.Size = New System.Drawing.Size(1222, 448)
        Me.tpBan.TabIndex = 7
        Me.tpBan.Text = "Ban"
        '
        'btnBan
        '
        Me.btnBan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBan.Location = New System.Drawing.Point(1123, 5)
        Me.btnBan.Name = "btnBan"
        Me.btnBan.Size = New System.Drawing.Size(91, 23)
        Me.btnBan.TabIndex = 4
        Me.btnBan.Text = "Ban"
        Me.btnBan.UseVisualStyleBackColor = True
        '
        'btnGeo
        '
        Me.btnGeo.Location = New System.Drawing.Point(287, 5)
        Me.btnGeo.Name = "btnGeo"
        Me.btnGeo.Size = New System.Drawing.Size(91, 23)
        Me.btnGeo.TabIndex = 3
        Me.btnGeo.Text = "Geo Location"
        Me.btnGeo.UseVisualStyleBackColor = True
        '
        'btnMalicious
        '
        Me.btnMalicious.Location = New System.Drawing.Point(207, 5)
        Me.btnMalicious.Name = "btnMalicious"
        Me.btnMalicious.Size = New System.Drawing.Size(74, 23)
        Me.btnMalicious.TabIndex = 2
        Me.btnMalicious.Text = "Malicious?"
        Me.btnMalicious.UseVisualStyleBackColor = True
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(8, 6)
        Me.txtIp.MaxLength = 15
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(193, 21)
        Me.txtIp.TabIndex = 1
        '
        'webBan
        '
        Me.webBan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webBan.Location = New System.Drawing.Point(6, 33)
        Me.webBan.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webBan.Name = "webBan"
        Me.webBan.ScriptErrorsSuppressed = True
        Me.webBan.Size = New System.Drawing.Size(1210, 421)
        Me.webBan.TabIndex = 0
        '
        'tpPassword
        '
        Me.tpPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.tpPassword.Controls.Add(Me.txtPwdOrig)
        Me.tpPassword.Controls.Add(Me.Label3)
        Me.tpPassword.Controls.Add(Me.btnCriptaPwd)
        Me.tpPassword.Controls.Add(Me.Label4)
        Me.tpPassword.Controls.Add(Me.txtPwdCriptata)
        Me.tpPassword.Location = New System.Drawing.Point(4, 24)
        Me.tpPassword.Name = "tpPassword"
        Me.tpPassword.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPassword.Size = New System.Drawing.Size(1222, 448)
        Me.tpPassword.TabIndex = 11
        Me.tpPassword.Text = "Password"
        '
        'txtPwdOrig
        '
        Me.txtPwdOrig.Location = New System.Drawing.Point(30, 33)
        Me.txtPwdOrig.Name = "txtPwdOrig"
        Me.txtPwdOrig.Size = New System.Drawing.Size(181, 21)
        Me.txtPwdOrig.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(310, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Password Criptata"
        '
        'btnCriptaPwd
        '
        Me.btnCriptaPwd.Location = New System.Drawing.Point(217, 27)
        Me.btnCriptaPwd.Name = "btnCriptaPwd"
        Me.btnCriptaPwd.Size = New System.Drawing.Size(87, 27)
        Me.btnCriptaPwd.TabIndex = 8
        Me.btnCriptaPwd.Text = "Cripta"
        Me.btnCriptaPwd.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(26, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Password Originale"
        '
        'txtPwdCriptata
        '
        Me.txtPwdCriptata.Location = New System.Drawing.Point(313, 33)
        Me.txtPwdCriptata.Name = "txtPwdCriptata"
        Me.txtPwdCriptata.Size = New System.Drawing.Size(181, 21)
        Me.txtPwdCriptata.TabIndex = 9
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1222, 448)
        Me.TabPage3.TabIndex = 12
        Me.TabPage3.Text = "Creazione Icone"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.Panel3)
        Me.GroupBox5.Controls.Add(Me.Panel2)
        Me.GroupBox5.Controls.Add(Me.Panel1)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.btnCreaIcona)
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(529, 448)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Creazione Icone"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rdoOrange)
        Me.Panel3.Controls.Add(Me.cmbColoreStatoOrd)
        Me.Panel3.Controls.Add(Me.rdoStatoOrdine)
        Me.Panel3.Controls.Add(Me.rdoCustom)
        Me.Panel3.Location = New System.Drawing.Point(55, 86)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(468, 106)
        Me.Panel3.TabIndex = 12
        '
        'rdoOrange
        '
        Me.rdoOrange.AutoSize = True
        Me.rdoOrange.Checked = True
        Me.rdoOrange.Location = New System.Drawing.Point(3, 5)
        Me.rdoOrange.Name = "rdoOrange"
        Me.rdoOrange.Size = New System.Drawing.Size(66, 19)
        Me.rdoOrange.TabIndex = 13
        Me.rdoOrange.TabStop = True
        Me.rdoOrange.Text = "Arancio"
        Me.rdoOrange.UseVisualStyleBackColor = True
        '
        'cmbColoreStatoOrd
        '
        Me.cmbColoreStatoOrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColoreStatoOrd.FormattingEnabled = True
        Me.cmbColoreStatoOrd.Location = New System.Drawing.Point(102, 29)
        Me.cmbColoreStatoOrd.Name = "cmbColoreStatoOrd"
        Me.cmbColoreStatoOrd.Size = New System.Drawing.Size(152, 23)
        Me.cmbColoreStatoOrd.TabIndex = 12
        '
        'rdoStatoOrdine
        '
        Me.rdoStatoOrdine.AutoSize = True
        Me.rdoStatoOrdine.Location = New System.Drawing.Point(3, 30)
        Me.rdoStatoOrdine.Name = "rdoStatoOrdine"
        Me.rdoStatoOrdine.Size = New System.Drawing.Size(93, 19)
        Me.rdoStatoOrdine.TabIndex = 8
        Me.rdoStatoOrdine.Text = "Stato Ordine"
        Me.rdoStatoOrdine.UseVisualStyleBackColor = True
        '
        'rdoCustom
        '
        Me.rdoCustom.AutoSize = True
        Me.rdoCustom.Location = New System.Drawing.Point(3, 55)
        Me.rdoCustom.Name = "rdoCustom"
        Me.rdoCustom.Size = New System.Drawing.Size(69, 19)
        Me.rdoCustom.TabIndex = 11
        Me.rdoCustom.Text = "Custom"
        Me.rdoCustom.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoBianca)
        Me.Panel2.Controls.Add(Me.rdoNera)
        Me.Panel2.Location = New System.Drawing.Point(55, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(468, 27)
        Me.Panel2.TabIndex = 12
        '
        'rdoBianca
        '
        Me.rdoBianca.AutoSize = True
        Me.rdoBianca.Checked = True
        Me.rdoBianca.Location = New System.Drawing.Point(3, 3)
        Me.rdoBianca.Name = "rdoBianca"
        Me.rdoBianca.Size = New System.Drawing.Size(63, 19)
        Me.rdoBianca.TabIndex = 8
        Me.rdoBianca.TabStop = True
        Me.rdoBianca.Text = "Bianca"
        Me.rdoBianca.UseVisualStyleBackColor = True
        '
        'rdoNera
        '
        Me.rdoNera.AutoSize = True
        Me.rdoNera.Location = New System.Drawing.Point(94, 3)
        Me.rdoNera.Name = "rdoNera"
        Me.rdoNera.Size = New System.Drawing.Size(52, 19)
        Me.rdoNera.TabIndex = 9
        Me.rdoNera.Text = "Nera"
        Me.rdoNera.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoRect)
        Me.Panel1.Controls.Add(Me.rdoCerchio)
        Me.Panel1.Location = New System.Drawing.Point(55, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(468, 27)
        Me.Panel1.TabIndex = 12
        '
        'rdoRect
        '
        Me.rdoRect.AutoSize = True
        Me.rdoRect.Checked = True
        Me.rdoRect.Location = New System.Drawing.Point(3, 3)
        Me.rdoRect.Name = "rdoRect"
        Me.rdoRect.Size = New System.Drawing.Size(85, 19)
        Me.rdoRect.TabIndex = 4
        Me.rdoRect.TabStop = True
        Me.rdoRect.Text = "Rettangolo"
        Me.rdoRect.UseVisualStyleBackColor = True
        '
        'rdoCerchio
        '
        Me.rdoCerchio.AutoSize = True
        Me.rdoCerchio.Location = New System.Drawing.Point(94, 3)
        Me.rdoCerchio.Name = "rdoCerchio"
        Me.rdoCerchio.Size = New System.Drawing.Size(68, 19)
        Me.rdoCerchio.TabIndex = 5
        Me.rdoCerchio.Text = "Cerchio"
        Me.rdoCerchio.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label12.Location = New System.Drawing.Point(6, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 15)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Sfondo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label11.Location = New System.Drawing.Point(6, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 15)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Scritta"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label10.Location = New System.Drawing.Point(6, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Forma"
        '
        'btnCreaIcona
        '
        Me.btnCreaIcona.ForeColor = System.Drawing.Color.Black
        Me.btnCreaIcona.Location = New System.Drawing.Point(218, 198)
        Me.btnCreaIcona.Name = "btnCreaIcona"
        Me.btnCreaIcona.Size = New System.Drawing.Size(91, 23)
        Me.btnCreaIcona.TabIndex = 3
        Me.btnCreaIcona.Text = "Crea Icona"
        Me.btnCreaIcona.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.lblVerDemone)
        Me.GroupBox7.Controls.Add(Me.lblVerGest)
        Me.GroupBox7.Controls.Add(Me.btnRilascioSitoProduzione)
        Me.GroupBox7.Controls.Add(Me.btnRilascioGestionale)
        Me.GroupBox7.Controls.Add(Me.btnRilascioSito)
        Me.GroupBox7.Controls.Add(Me.btnRilascioDemone)
        Me.GroupBox7.ForeColor = System.Drawing.Color.White
        Me.GroupBox7.Location = New System.Drawing.Point(4, 545)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(1222, 107)
        Me.GroupBox7.TabIndex = 9
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Rilasci"
        '
        'lblVerDemone
        '
        Me.lblVerDemone.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblVerDemone.Location = New System.Drawing.Point(322, 80)
        Me.lblVerDemone.Name = "lblVerDemone"
        Me.lblVerDemone.Size = New System.Drawing.Size(286, 18)
        Me.lblVerDemone.TabIndex = 5
        Me.lblVerDemone.Text = "-"
        '
        'lblVerGest
        '
        Me.lblVerGest.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblVerGest.Location = New System.Drawing.Point(30, 80)
        Me.lblVerGest.Name = "lblVerGest"
        Me.lblVerGest.Size = New System.Drawing.Size(286, 18)
        Me.lblVerGest.TabIndex = 4
        Me.lblVerGest.Text = "-"
        '
        'btnRilascioSitoProduzione
        '
        Me.btnRilascioSitoProduzione.ForeColor = System.Drawing.Color.Black
        Me.btnRilascioSitoProduzione.Image = Global.FormerLab.My.Resources.Resources.ico_WE_R
        Me.btnRilascioSitoProduzione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRilascioSitoProduzione.Location = New System.Drawing.Point(906, 20)
        Me.btnRilascioSitoProduzione.Name = "btnRilascioSitoProduzione"
        Me.btnRilascioSitoProduzione.Size = New System.Drawing.Size(286, 57)
        Me.btnRilascioSitoProduzione.TabIndex = 3
        Me.btnRilascioSitoProduzione.Text = "Rilascio Sito in Produzione"
        Me.btnRilascioSitoProduzione.UseVisualStyleBackColor = True
        '
        'btnRilascioGestionale
        '
        Me.btnRilascioGestionale.ForeColor = System.Drawing.Color.Black
        Me.btnRilascioGestionale.Image = Global.FormerLab.My.Resources.Resources.ico_RG_R
        Me.btnRilascioGestionale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRilascioGestionale.Location = New System.Drawing.Point(30, 20)
        Me.btnRilascioGestionale.Name = "btnRilascioGestionale"
        Me.btnRilascioGestionale.Radius = 5
        Me.btnRilascioGestionale.Size = New System.Drawing.Size(286, 57)
        Me.btnRilascioGestionale.TabIndex = 0
        Me.btnRilascioGestionale.Text = "Rilascio Gestionale"
        Me.btnRilascioGestionale.UseVisualStyleBackColor = True
        '
        'btnRilascioSito
        '
        Me.btnRilascioSito.ForeColor = System.Drawing.Color.Black
        Me.btnRilascioSito.Image = Global.FormerLab.My.Resources.Resources.ico_WC_R
        Me.btnRilascioSito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRilascioSito.Location = New System.Drawing.Point(614, 20)
        Me.btnRilascioSito.Name = "btnRilascioSito"
        Me.btnRilascioSito.Size = New System.Drawing.Size(286, 57)
        Me.btnRilascioSito.TabIndex = 2
        Me.btnRilascioSito.Text = "Rilascio Sito in Collaudo"
        Me.btnRilascioSito.UseVisualStyleBackColor = True
        '
        'btnRilascioDemone
        '
        Me.btnRilascioDemone.ForeColor = System.Drawing.Color.Black
        Me.btnRilascioDemone.Image = Global.FormerLab.My.Resources.Resources.ico_RD_R
        Me.btnRilascioDemone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRilascioDemone.Location = New System.Drawing.Point(322, 20)
        Me.btnRilascioDemone.Name = "btnRilascioDemone"
        Me.btnRilascioDemone.Size = New System.Drawing.Size(286, 57)
        Me.btnRilascioDemone.TabIndex = 1
        Me.btnRilascioDemone.Text = "Rilascio Demone"
        Me.btnRilascioDemone.UseVisualStyleBackColor = True
        '
        'CircleShape1
        '
        Me.CircleShape1.IsRightToLeft = False
        '
        'lblConnStringWeb
        '
        Me.lblConnStringWeb.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblConnStringWeb.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblConnStringWeb.ForeColor = System.Drawing.Color.White
        Me.lblConnStringWeb.Image = Global.FormerLab.My.Resources.Resources.world
        Me.lblConnStringWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblConnStringWeb.Location = New System.Drawing.Point(0, 30)
        Me.lblConnStringWeb.Name = "lblConnStringWeb"
        Me.lblConnStringWeb.Size = New System.Drawing.Size(1230, 30)
        Me.lblConnStringWeb.TabIndex = 10
        Me.lblConnStringWeb.Text = "-"
        Me.lblConnStringWeb.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblConnStringSql
        '
        Me.lblConnStringSql.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblConnStringSql.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblConnStringSql.ForeColor = System.Drawing.Color.White
        Me.lblConnStringSql.Image = Global.FormerLab.My.Resources.Resources.monitor
        Me.lblConnStringSql.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblConnStringSql.Location = New System.Drawing.Point(0, 0)
        Me.lblConnStringSql.Name = "lblConnStringSql"
        Me.lblConnStringSql.Size = New System.Drawing.Size(1230, 30)
        Me.lblConnStringSql.TabIndex = 3
        Me.lblConnStringSql.Text = "-"
        Me.lblConnStringSql.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tpTestWeb
        '
        Me.tpTestWeb.Controls.Add(Me.brwTestWeb)
        Me.tpTestWeb.Location = New System.Drawing.Point(4, 24)
        Me.tpTestWeb.Name = "tpTestWeb"
        Me.tpTestWeb.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTestWeb.Size = New System.Drawing.Size(1222, 448)
        Me.tpTestWeb.TabIndex = 14
        Me.tpTestWeb.Text = "TestWeb"
        Me.tpTestWeb.UseVisualStyleBackColor = True
        '
        'brwTestWeb
        '
        Me.brwTestWeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.brwTestWeb.Location = New System.Drawing.Point(3, 3)
        Me.brwTestWeb.MinimumSize = New System.Drawing.Size(20, 20)
        Me.brwTestWeb.Name = "brwTestWeb"
        Me.brwTestWeb.Size = New System.Drawing.Size(1216, 442)
        Me.brwTestWeb.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1230, 664)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.lblConnStringWeb)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.lblConnStringSql)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Former Lab"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tpAltro.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.tpOrdini.ResumeLayout(False)
        Me.tpOrdini.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tpBug.ResumeLayout(False)
        Me.tpBug.PerformLayout()
        CType(Me.pctBug, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.tpUdp.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tpCosaVedono.ResumeLayout(False)
        Me.tpCosaVedono.PerformLayout()
        CType(Me.dgLavori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgConsegne, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpBan.ResumeLayout(False)
        Me.tpBan.PerformLayout()
        Me.tpPassword.ResumeLayout(False)
        Me.tpPassword.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.tpTestWeb.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMessage As System.Windows.Forms.Button
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents btnReconnect As System.Windows.Forms.Button
    Friend WithEvents btnCaller As System.Windows.Forms.Button
    Friend WithEvents btnTestPerformance As System.Windows.Forms.Button
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTestSvls As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpUdp As System.Windows.Forms.TabPage
    Friend WithEvents tpOrdini As System.Windows.Forms.TabPage
    Friend WithEvents btnDuplicaCons As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdConsegna As System.Windows.Forms.TextBox
    Friend WithEvents lblConnStringSql As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDuplicaConsFromOrd As System.Windows.Forms.Button
    Friend WithEvents btnLega As System.Windows.Forms.Button
    Friend WithEvents lblRisDup As System.Windows.Forms.Label
    Friend WithEvents lblRisDup2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbStato As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCambiaStato As System.Windows.Forms.Button
    Friend WithEvents txtOrdCambioStato As System.Windows.Forms.TextBox
    Friend WithEvents lblIdConsFromIdOrd As System.Windows.Forms.Label
    Friend WithEvents btnIdConsFromIdOrd As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIdOrdine As System.Windows.Forms.TextBox
    Friend WithEvents btnStampaCodiceBarre As System.Windows.Forms.Button
    Friend WithEvents btnRiportaIndietroConsegna As System.Windows.Forms.Button
    Friend WithEvents btnEventViewer As System.Windows.Forms.Button
    Friend WithEvents btnLogOrdOnline As System.Windows.Forms.Button
    Friend WithEvents btnLogOrdineInt As System.Windows.Forms.Button
    Friend WithEvents tpAltro As TabPage
    Friend WithEvents btnCreaIcona As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents rdoCerchio As RadioButton
    Friend WithEvents rdoRect As RadioButton
    Friend WithEvents rdoNera As RadioButton
    Friend WithEvents rdoBianca As RadioButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents rdoCustom As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents rdoStatoOrdine As RadioButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dlgColor As ColorDialog
    Friend WithEvents cmbColoreStatoOrd As ComboBox
    Friend WithEvents rdoOrange As RadioButton
    Friend WithEvents tpCosaVedono As TabPage
    Friend WithEvents btnLoadCosaVede As Button
    Friend WithEvents txtIdUtOnline As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dgLavori As DataGridView
    Friend WithEvents Label13 As Label
    Friend WithEvents dgConsegne As DataGridView
    Friend WithEvents DataIns As DataGridViewTextBoxColumn
    Friend WithEvents Giorno As DataGridViewTextBoxColumn
    Friend WithEvents IdCons As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents IdOrd As DataGridViewTextBoxColumn
    Friend WithEvents btnTest As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents btnRilascioSitoProduzione As Button
    Friend WithEvents btnRilascioSito As Button
    Friend WithEvents btnRilascioDemone As Button
    Friend WithEvents btnRilascioGestionale As RoundedButton
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents lblVerGest As Label
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents btnRegistraPagamento As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents txtIdConsOnline As TextBox
    Friend WithEvents btnGetChiave As Button
    Friend WithEvents tpBan As TabPage
    Friend WithEvents btnBan As Button
    Friend WithEvents btnGeo As Button
    Friend WithEvents btnMalicious As Button
    Friend WithEvents txtIp As TextBox
    Friend WithEvents webBan As WebBrowser
    Friend WithEvents lblVerDemone As Label
    Friend WithEvents btnRicreaConsegna As Button
    Friend WithEvents txtDebug As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnImportContacts As Button
    Friend WithEvents txtUtConnection As TextBox
    Friend WithEvents tpBug As TabPage
    Friend WithEvents imlTab As ImageList
    Friend WithEvents btnAggiornaBug As Button
    Friend WithEvents tvBug As TreeView
    Friend WithEvents lblBugTitolo As Label
    Friend WithEvents txtBug As TextBox
    Friend WithEvents pctBug As PictureBox
    Friend WithEvents btnBugLavorato As Button
    Friend WithEvents btnRigeneraAnteprima As Button
    Friend WithEvents cmbTipoUDP As ComboBox
    Friend WithEvents CircleShape1 As Telerik.WinControls.CircleShape
    Friend WithEvents btnDelBug As Button
    Friend WithEvents lblConnStringWeb As Label
    Friend WithEvents btnStopSearch As Button
    Friend WithEvents tpPassword As TabPage
    Friend WithEvents txtPwdOrig As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCriptaPwd As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPwdCriptata As TextBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents webReport As WebBrowser
    Friend WithEvents btnGeneraReport As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents tpTestWeb As TabPage
    Friend WithEvents brwTestWeb As WebBrowser
End Class
