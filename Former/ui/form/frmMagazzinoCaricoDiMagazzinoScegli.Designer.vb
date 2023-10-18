<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMagazzinoCaricoDiMagazzinoScegli
    Inherits baseFormInternaRedim

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lnkScollega = New System.Windows.Forms.Button()
        Me.lnkNewCaricoMagazzino = New System.Windows.Forms.Button()
        Me.btnCreaAutomatico = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lnkDocContabile = New System.Windows.Forms.LinkLabel()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.lnkDocCarico = New System.Windows.Forms.LinkLabel()
        Me.lblAttualmenteCollegato = New System.Windows.Forms.Label()
        Me.lblCurrent = New System.Windows.Forms.Label()
        Me.lnkNext = New System.Windows.Forms.LinkLabel()
        Me.lnkPrev = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblDocRiferimento = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoSRL = New System.Windows.Forms.RadioButton()
        Me.rdoSNC = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumeroDoc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rdoFattura = New System.Windows.Forms.RadioButton()
        Me.rdoDDT = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTipoCli = New System.Windows.Forms.Label()
        Me.cmbFornitore = New System.Windows.Forms.ComboBox()
        Me.btnDetCli = New System.Windows.Forms.Button()
        Me.DgMovimenti = New Telerik.WinControls.UI.RadGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtDataDoc = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DgMovimenti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgMovimenti.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lnkScollega)
        Me.gbPulsanti.Controls.Add(Me.lnkNewCaricoMagazzino)
        Me.gbPulsanti.Controls.Add(Me.btnCreaAutomatico)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 727)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lnkScollega
        '
        Me.lnkScollega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkScollega.AutoSize = True
        Me.lnkScollega.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.lnkScollega.FlatAppearance.BorderSize = 0
        Me.lnkScollega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkScollega.ForeColor = System.Drawing.Color.Black
        Me.lnkScollega.Image = Global.Former.My.Resources.Resources._remove
        Me.lnkScollega.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkScollega.Location = New System.Drawing.Point(95, 12)
        Me.lnkScollega.Name = "lnkScollega"
        Me.lnkScollega.Size = New System.Drawing.Size(86, 32)
        Me.lnkScollega.TabIndex = 19
        Me.lnkScollega.Text = "Scollega"
        Me.lnkScollega.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkScollega.UseVisualStyleBackColor = True
        '
        'lnkNewCaricoMagazzino
        '
        Me.lnkNewCaricoMagazzino.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNewCaricoMagazzino.AutoSize = True
        Me.lnkNewCaricoMagazzino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.lnkNewCaricoMagazzino.FlatAppearance.BorderSize = 0
        Me.lnkNewCaricoMagazzino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkNewCaricoMagazzino.ForeColor = System.Drawing.Color.Black
        Me.lnkNewCaricoMagazzino.Image = Global.Former.My.Resources.Resources._CaricoDiMagazzino24
        Me.lnkNewCaricoMagazzino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNewCaricoMagazzino.Location = New System.Drawing.Point(451, 12)
        Me.lnkNewCaricoMagazzino.Name = "lnkNewCaricoMagazzino"
        Me.lnkNewCaricoMagazzino.Size = New System.Drawing.Size(201, 32)
        Me.lnkNewCaricoMagazzino.TabIndex = 18
        Me.lnkNewCaricoMagazzino.Text = "Inserisci Documento di Carico"
        Me.lnkNewCaricoMagazzino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkNewCaricoMagazzino.UseVisualStyleBackColor = True
        '
        'btnCreaAutomatico
        '
        Me.btnCreaAutomatico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreaAutomatico.AutoSize = True
        Me.btnCreaAutomatico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCreaAutomatico.FlatAppearance.BorderSize = 0
        Me.btnCreaAutomatico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreaAutomatico.ForeColor = System.Drawing.Color.Black
        Me.btnCreaAutomatico.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnCreaAutomatico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreaAutomatico.Location = New System.Drawing.Point(187, 12)
        Me.btnCreaAutomatico.Name = "btnCreaAutomatico"
        Me.btnCreaAutomatico.Size = New System.Drawing.Size(258, 32)
        Me.btnCreaAutomatico.TabIndex = 17
        Me.btnCreaAutomatico.Text = "Crea Documento di Carico in automatico"
        Me.btnCreaAutomatico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreaAutomatico.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(871, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(6, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(83, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Collega"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lnkDocContabile
        '
        Me.lnkDocContabile.AutoSize = True
        Me.lnkDocContabile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDocContabile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDocContabile.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkDocContabile.Location = New System.Drawing.Point(634, 78)
        Me.lnkDocContabile.Name = "lnkDocContabile"
        Me.lnkDocContabile.Size = New System.Drawing.Size(38, 15)
        Me.lnkDocContabile.TabIndex = 25
        Me.lnkDocContabile.TabStop = True
        Me.lnkDocContabile.Text = "Apri..."
        Me.lnkDocContabile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 727)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lnkDocCarico)
        Me.tbProd.Controls.Add(Me.lblAttualmenteCollegato)
        Me.tbProd.Controls.Add(Me.lblCurrent)
        Me.tbProd.Controls.Add(Me.lnkNext)
        Me.tbProd.Controls.Add(Me.lnkPrev)
        Me.tbProd.Controls.Add(Me.lnkDocContabile)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.PictureBox2)
        Me.tbProd.Controls.Add(Me.lblDocRiferimento)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.Panel1)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtNumeroDoc)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.rdoFattura)
        Me.tbProd.Controls.Add(Me.rdoDDT)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.lblTipoCli)
        Me.tbProd.Controls.Add(Me.cmbFornitore)
        Me.tbProd.Controls.Add(Me.btnDetCli)
        Me.tbProd.Controls.Add(Me.DgMovimenti)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.dtDataDoc)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 701)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Seleziona Carico di Magazzino"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lnkDocCarico
        '
        Me.lnkDocCarico.AutoSize = True
        Me.lnkDocCarico.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDocCarico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDocCarico.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkDocCarico.Location = New System.Drawing.Point(634, 168)
        Me.lnkDocCarico.Name = "lnkDocCarico"
        Me.lnkDocCarico.Size = New System.Drawing.Size(38, 15)
        Me.lnkDocCarico.TabIndex = 127
        Me.lnkDocCarico.TabStop = True
        Me.lnkDocCarico.Text = "Apri..."
        Me.lnkDocCarico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAttualmenteCollegato
        '
        Me.lblAttualmenteCollegato.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.lblAttualmenteCollegato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAttualmenteCollegato.ForeColor = System.Drawing.Color.White
        Me.lblAttualmenteCollegato.Location = New System.Drawing.Point(689, 162)
        Me.lblAttualmenteCollegato.Name = "lblAttualmenteCollegato"
        Me.lblAttualmenteCollegato.Size = New System.Drawing.Size(172, 26)
        Me.lblAttualmenteCollegato.TabIndex = 126
        Me.lblAttualmenteCollegato.Text = "ATTUALMENTE COLLEGATO"
        Me.lblAttualmenteCollegato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAttualmenteCollegato.Visible = False
        '
        'lblCurrent
        '
        Me.lblCurrent.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrent.ForeColor = System.Drawing.Color.Black
        Me.lblCurrent.Location = New System.Drawing.Point(269, 668)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(464, 21)
        Me.lblCurrent.TabIndex = 125
        Me.lblCurrent.Text = "-"
        Me.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkNext
        '
        Me.lnkNext.AutoSize = True
        Me.lnkNext.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNext.Image = Global.Former.My.Resources.Resources._Next
        Me.lnkNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNext.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkNext.Location = New System.Drawing.Point(739, 668)
        Me.lnkNext.Name = "lnkNext"
        Me.lnkNext.Padding = New System.Windows.Forms.Padding(6, 6, 30, 0)
        Me.lnkNext.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lnkNext.Size = New System.Drawing.Size(100, 21)
        Me.lnkNext.TabIndex = 124
        Me.lnkNext.TabStop = True
        Me.lnkNext.Text = "Successivo"
        Me.lnkNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkPrev
        '
        Me.lnkPrev.AutoSize = True
        Me.lnkPrev.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkPrev.Image = Global.Former.My.Resources.Resources._previous
        Me.lnkPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPrev.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkPrev.Location = New System.Drawing.Point(161, 668)
        Me.lnkPrev.Name = "lnkPrev"
        Me.lnkPrev.Padding = New System.Windows.Forms.Padding(30, 6, 6, 0)
        Me.lnkPrev.Size = New System.Drawing.Size(102, 21)
        Me.lnkPrev.TabIndex = 123
        Me.lnkPrev.TabStop = True
        Me.lnkPrev.Text = "Precedente"
        Me.lnkPrev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(71, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(612, 26)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "DOCUMENTI DI CARICO DEL FORNITORE"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._CaricoDiMagazzino24
        Me.PictureBox2.Location = New System.Drawing.Point(39, 162)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 121
        Me.PictureBox2.TabStop = False
        '
        'lblDocRiferimento
        '
        Me.lblDocRiferimento.AutoSize = True
        Me.lblDocRiferimento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDocRiferimento.ForeColor = System.Drawing.Color.Black
        Me.lblDocRiferimento.Location = New System.Drawing.Point(71, 110)
        Me.lblDocRiferimento.Name = "lblDocRiferimento"
        Me.lblDocRiferimento.Size = New System.Drawing.Size(12, 15)
        Me.lblDocRiferimento.TabIndex = 120
        Me.lblDocRiferimento.Text = "-"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(71, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(612, 26)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "DOCUMENTO FISCALE RIFERIMENTO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.PictureBox1.Location = New System.Drawing.Point(39, 72)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 118
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.rdoSRL)
        Me.Panel1.Controls.Add(Me.rdoSNC)
        Me.Panel1.Location = New System.Drawing.Point(164, 200)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(425, 28)
        Me.Panel1.TabIndex = 117
        '
        'rdoSRL
        '
        Me.rdoSRL.AutoSize = True
        Me.rdoSRL.Checked = True
        Me.rdoSRL.Enabled = False
        Me.rdoSRL.Location = New System.Drawing.Point(3, 4)
        Me.rdoSRL.Name = "rdoSRL"
        Me.rdoSRL.Size = New System.Drawing.Size(135, 19)
        Me.rdoSRL.TabIndex = 116
        Me.rdoSRL.TabStop = True
        Me.rdoSRL.Text = "Tipografia Former srl"
        Me.rdoSRL.UseVisualStyleBackColor = True
        '
        'rdoSNC
        '
        Me.rdoSNC.AutoSize = True
        Me.rdoSNC.Enabled = False
        Me.rdoSNC.Location = New System.Drawing.Point(144, 4)
        Me.rdoSNC.Name = "rdoSNC"
        Me.rdoSNC.Size = New System.Drawing.Size(84, 19)
        Me.rdoSNC.TabIndex = 115
        Me.rdoSNC.Text = "Former snc"
        Me.rdoSNC.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(36, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 15)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "Riferimento"
        '
        'txtNumeroDoc
        '
        Me.txtNumeroDoc.Enabled = False
        Me.txtNumeroDoc.Location = New System.Drawing.Point(164, 309)
        Me.txtNumeroDoc.MaxLength = 20
        Me.txtNumeroDoc.Name = "txtNumeroDoc"
        Me.txtNumeroDoc.Size = New System.Drawing.Size(213, 20)
        Me.txtNumeroDoc.TabIndex = 113
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(36, 312)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 15)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Numero Documento"
        '
        'rdoFattura
        '
        Me.rdoFattura.AutoSize = True
        Me.rdoFattura.Enabled = False
        Me.rdoFattura.Location = New System.Drawing.Point(217, 284)
        Me.rdoFattura.Name = "rdoFattura"
        Me.rdoFattura.Size = New System.Drawing.Size(62, 19)
        Me.rdoFattura.TabIndex = 111
        Me.rdoFattura.Text = "Fattura"
        Me.rdoFattura.UseVisualStyleBackColor = True
        '
        'rdoDDT
        '
        Me.rdoDDT.AutoSize = True
        Me.rdoDDT.Checked = True
        Me.rdoDDT.Enabled = False
        Me.rdoDDT.Location = New System.Drawing.Point(164, 284)
        Me.rdoDDT.Name = "rdoDDT"
        Me.rdoDDT.Size = New System.Drawing.Size(47, 19)
        Me.rdoDDT.TabIndex = 110
        Me.rdoDDT.TabStop = True
        Me.rdoDDT.Text = "DDT"
        Me.rdoDDT.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(36, 286)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Tipo Documento"
        '
        'lblTipoCli
        '
        Me.lblTipoCli.AutoSize = True
        Me.lblTipoCli.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipoCli.ForeColor = System.Drawing.Color.Black
        Me.lblTipoCli.Location = New System.Drawing.Point(36, 232)
        Me.lblTipoCli.Name = "lblTipoCli"
        Me.lblTipoCli.Size = New System.Drawing.Size(59, 15)
        Me.lblTipoCli.TabIndex = 108
        Me.lblTipoCli.Text = "Fornitore"
        '
        'cmbFornitore
        '
        Me.cmbFornitore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbFornitore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFornitore.Enabled = False
        Me.cmbFornitore.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFornitore.FormattingEnabled = True
        Me.cmbFornitore.Location = New System.Drawing.Point(164, 229)
        Me.cmbFornitore.Name = "cmbFornitore"
        Me.cmbFornitore.Size = New System.Drawing.Size(467, 23)
        Me.cmbFornitore.TabIndex = 106
        '
        'btnDetCli
        '
        Me.btnDetCli.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDetCli.Location = New System.Drawing.Point(637, 228)
        Me.btnDetCli.Name = "btnDetCli"
        Me.btnDetCli.Size = New System.Drawing.Size(24, 23)
        Me.btnDetCli.TabIndex = 107
        Me.btnDetCli.Text = "..."
        Me.btnDetCli.UseVisualStyleBackColor = True
        '
        'DgMovimenti
        '
        Me.DgMovimenti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgMovimenti.AutoScroll = True
        Me.DgMovimenti.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.DgMovimenti.EnableGestures = False
        Me.DgMovimenti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgMovimenti.Location = New System.Drawing.Point(164, 335)
        '
        '
        '
        Me.DgMovimenti.MasterTemplate.AllowAddNewRow = False
        Me.DgMovimenti.MasterTemplate.AllowCellContextMenu = False
        Me.DgMovimenti.MasterTemplate.AllowColumnChooser = False
        Me.DgMovimenti.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.DgMovimenti.MasterTemplate.AllowDeleteRow = False
        Me.DgMovimenti.MasterTemplate.AllowDragToGroup = False
        Me.DgMovimenti.MasterTemplate.AllowEditRow = False
        Me.DgMovimenti.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.DgMovimenti.MasterTemplate.AllowRowResize = False
        Me.DgMovimenti.MasterTemplate.AllowSearchRow = True
        Me.DgMovimenti.MasterTemplate.AutoGenerateColumns = False
        GridViewTextBoxColumn1.FieldName = "RisorsaStr"
        GridViewTextBoxColumn1.HeaderText = "Risorsa"
        GridViewTextBoxColumn1.Name = "Risorsa"
        GridViewTextBoxColumn1.Width = 300
        GridViewTextBoxColumn2.FieldName = "Qta"
        GridViewTextBoxColumn2.HeaderText = "Q.ta"
        GridViewTextBoxColumn2.Name = "Qta"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn2.Width = 70
        GridViewTextBoxColumn3.FieldName = "CodiceForn"
        GridViewTextBoxColumn3.HeaderText = "Codice Fornitore"
        GridViewTextBoxColumn3.MinWidth = 100
        GridViewTextBoxColumn3.Name = "CodiceForn"
        GridViewTextBoxColumn3.Width = 100
        GridViewTextBoxColumn4.FieldName = "DescrForn"
        GridViewTextBoxColumn4.HeaderText = "Descrizione Fornitore"
        GridViewTextBoxColumn4.MinWidth = 200
        GridViewTextBoxColumn4.Name = "DescrForn"
        GridViewTextBoxColumn4.Width = 200
        Me.DgMovimenti.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.DgMovimenti.MasterTemplate.EnableAlternatingRowColor = True
        Me.DgMovimenti.MasterTemplate.EnableGrouping = False
        Me.DgMovimenti.MasterTemplate.MultiSelect = True
        Me.DgMovimenti.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgMovimenti.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.DgMovimenti.Name = "DgMovimenti"
        Me.DgMovimenti.ReadOnly = True
        Me.DgMovimenti.ShowGroupPanel = False
        Me.DgMovimenti.ShowGroupPanelScrollbars = False
        Me.DgMovimenti.ShowNoDataText = False
        Me.DgMovimenti.Size = New System.Drawing.Size(775, 330)
        Me.DgMovimenti.TabIndex = 85
        Me.DgMovimenti.ThemeName = "VisualStudio2012Light"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(36, 335)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Risorse"
        '
        'dtDataDoc
        '
        Me.dtDataDoc.Enabled = False
        Me.dtDataDoc.Location = New System.Drawing.Point(164, 258)
        Me.dtDataDoc.Name = "dtDataDoc"
        Me.dtDataDoc.Size = New System.Drawing.Size(213, 20)
        Me.dtDataDoc.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(36, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Data Documento"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._LinkOk48
        Me.pctTipo.Location = New System.Drawing.Point(8, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(48, 48)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 16
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(62, 6)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(462, 22)
        Me.lblTipo.TabIndex = 15
        Me.lblTipo.Text = "Seleziona Carico di Magazzino da Documento Fiscale"
        '
        'frmMagazzinoCaricoDiMagazzinoScegli
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 775)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMagazzinoCaricoDiMagazzinoScegli"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Seleziona Carico di Magazzino"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgMovimenti.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgMovimenti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As PictureBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtDataDoc As DateTimePicker
    Friend WithEvents DgMovimenti As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblTipoCli As Label
    Friend WithEvents cmbFornitore As ComboBox
    Friend WithEvents btnDetCli As Button
    Friend WithEvents txtNumeroDoc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents rdoFattura As RadioButton
    Friend WithEvents rdoDDT As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdoSRL As RadioButton
    Friend WithEvents rdoSNC As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents lnkDocContabile As LinkLabel
    Friend WithEvents lblDocRiferimento As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lnkPrev As LinkLabel
    Friend WithEvents lnkNext As LinkLabel
    Friend WithEvents lblCurrent As Label
    Friend WithEvents btnCreaAutomatico As Button
    Friend WithEvents lblAttualmenteCollegato As Label
    Friend WithEvents lnkNewCaricoMagazzino As Button
    Friend WithEvents lnkScollega As Button
    Friend WithEvents lnkDocCarico As LinkLabel
End Class
