<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazionePreventivi
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgOrdini = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbRisposto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkDataInsDal = New System.Windows.Forms.CheckBox()
        Me.chkDataInsAl = New System.Windows.Forms.CheckBox()
        Me.dtDataInsDal = New System.Windows.Forms.DateTimePicker()
        Me.dtDataInsAl = New System.Windows.Forms.DateTimePicker()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.lblClienti = New System.Windows.Forms.Label()
        Me.lnkOrdMail = New System.Windows.Forms.LinkLabel()
        Me.MenuOrd = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuInviaMail = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicaOrdineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegnaComePagatoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFiltraCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiltraProdotto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ModificaDatiEconomiciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificaOrdineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.EmettiDocumentoFiscaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiapriDocumentoFiscaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.EliminaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.contextMenuPrev = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RispondiAlPreventivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CreaProdottoSuPreventivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UcAnteprimaPrev = New Former.ucAnteprima()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuOrd.SuspendLayout()
        Me.contextMenuPrev.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgOrdini
        '
        Me.DgOrdini.AllowUserToAddRows = False
        Me.DgOrdini.AllowUserToDeleteRows = False
        Me.DgOrdini.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgOrdini.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgOrdini.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgOrdini.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgOrdini.BackgroundColor = System.Drawing.Color.White
        Me.DgOrdini.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgOrdini.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgOrdini.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgOrdini.ColumnHeadersHeight = 20
        Me.DgOrdini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgOrdini.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgOrdini.EnableHeadersVisualStyles = False
        Me.DgOrdini.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgOrdini.Location = New System.Drawing.Point(3, 120)
        Me.DgOrdini.MultiSelect = False
        Me.DgOrdini.Name = "DgOrdini"
        Me.DgOrdini.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgOrdini.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgOrdini.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.DgOrdini.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgOrdini.Size = New System.Drawing.Size(688, 302)
        Me.DgOrdini.TabIndex = 48
        Me.DgOrdini.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbRisposto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.cmbCliente)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCerca)
        Me.GroupBox1.Controls.Add(Me.lnkCerca)
        Me.GroupBox1.Controls.Add(Me.lblClienti)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1020, 84)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cerca"
        '
        'cmbRisposto
        '
        Me.cmbRisposto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRisposto.FormattingEnabled = True
        Me.cmbRisposto.Items.AddRange(New Object() {"Indifferente", "No", "Si"})
        Me.cmbRisposto.Location = New System.Drawing.Point(65, 50)
        Me.cmbRisposto.Name = "cmbRisposto"
        Me.cmbRisposto.Size = New System.Drawing.Size(129, 23)
        Me.cmbRisposto.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Risposto"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel2.Controls.Add(Me.chkDataInsDal)
        Me.Panel2.Controls.Add(Me.chkDataInsAl)
        Me.Panel2.Controls.Add(Me.dtDataInsDal)
        Me.Panel2.Controls.Add(Me.dtDataInsAl)
        Me.Panel2.Location = New System.Drawing.Point(252, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(713, 31)
        Me.Panel2.TabIndex = 101
        '
        'chkDataInsDal
        '
        Me.chkDataInsDal.AutoSize = True
        Me.chkDataInsDal.ForeColor = System.Drawing.Color.Black
        Me.chkDataInsDal.Location = New System.Drawing.Point(3, 9)
        Me.chkDataInsDal.Name = "chkDataInsDal"
        Me.chkDataInsDal.Size = New System.Drawing.Size(141, 19)
        Me.chkDataInsDal.TabIndex = 98
        Me.chkDataInsDal.Text = "Data inserimento dal"
        Me.chkDataInsDal.UseVisualStyleBackColor = True
        '
        'chkDataInsAl
        '
        Me.chkDataInsAl.AutoSize = True
        Me.chkDataInsAl.ForeColor = System.Drawing.Color.Black
        Me.chkDataInsAl.Location = New System.Drawing.Point(360, 9)
        Me.chkDataInsAl.Name = "chkDataInsAl"
        Me.chkDataInsAl.Size = New System.Drawing.Size(134, 19)
        Me.chkDataInsAl.TabIndex = 100
        Me.chkDataInsAl.Text = "Data inserimento al"
        Me.chkDataInsAl.UseVisualStyleBackColor = True
        '
        'dtDataInsDal
        '
        Me.dtDataInsDal.Location = New System.Drawing.Point(150, 5)
        Me.dtDataInsDal.Name = "dtDataInsDal"
        Me.dtDataInsDal.Size = New System.Drawing.Size(200, 21)
        Me.dtDataInsDal.TabIndex = 97
        '
        'dtDataInsAl
        '
        Me.dtDataInsAl.Location = New System.Drawing.Point(507, 5)
        Me.dtDataInsAl.Name = "dtDataInsAl"
        Me.dtDataInsAl.Size = New System.Drawing.Size(200, 21)
        Me.dtDataInsAl.TabIndex = 99
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(252, 15)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(621, 23)
        Me.cmbCliente.TabIndex = 95
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 15)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Numero"
        '
        'txtCerca
        '
        Me.txtCerca.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtCerca.Location = New System.Drawing.Point(65, 14)
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(129, 21)
        Me.txtCerca.TabIndex = 50
        Me.txtCerca.Text = "{inserire qui il codice}"
        '
        'lnkCerca
        '
        Me.lnkCerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCerca.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources.icoCerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(879, 12)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(109, 27)
        Me.lnkCerca.TabIndex = 54
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Avvia ricerca..."
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClienti
        '
        Me.lblClienti.AutoSize = True
        Me.lblClienti.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblClienti.ForeColor = System.Drawing.Color.Black
        Me.lblClienti.Location = New System.Drawing.Point(200, 17)
        Me.lblClienti.Name = "lblClienti"
        Me.lblClienti.Size = New System.Drawing.Size(46, 15)
        Me.lblClienti.TabIndex = 52
        Me.lblClienti.Text = "Cliente"
        '
        'lnkOrdMail
        '
        Me.lnkOrdMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkOrdMail.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lnkOrdMail.Image = Global.Former.My.Resources.Resources.icoEmail
        Me.lnkOrdMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkOrdMail.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkOrdMail.Location = New System.Drawing.Point(538, 90)
        Me.lnkOrdMail.Name = "lnkOrdMail"
        Me.lnkOrdMail.Size = New System.Drawing.Size(153, 27)
        Me.lnkOrdMail.TabIndex = 55
        Me.lnkOrdMail.TabStop = True
        Me.lnkOrdMail.Text = "Scarica preventivi FTP"
        Me.lnkOrdMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuOrd
        '
        Me.MenuOrd.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInviaMail, Me.DuplicaOrdineToolStripMenuItem, Me.ToolStripSeparator1, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.SegnaComePagatoToolStripMenuItem, Me.ToolStripSeparator2, Me.mnuFiltraCliente, Me.mnuFiltraProdotto, Me.ToolStripSeparator3, Me.ModificaDatiEconomiciToolStripMenuItem, Me.ModificaOrdineToolStripMenuItem, Me.ToolStripSeparator4, Me.EmettiDocumentoFiscaleToolStripMenuItem, Me.RiapriDocumentoFiscaleToolStripMenuItem, Me.ToolStripMenuItem3, Me.ToolStripSeparator5, Me.EliminaToolStripMenuItem})
        Me.MenuOrd.Name = "MenuOrd"
        Me.MenuOrd.Size = New System.Drawing.Size(267, 320)
        '
        'mnuInviaMail
        '
        Me.mnuInviaMail.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mnuInviaMail.Name = "mnuInviaMail"
        Me.mnuInviaMail.Size = New System.Drawing.Size(266, 22)
        Me.mnuInviaMail.Text = "Invia mail..."
        '
        'DuplicaOrdineToolStripMenuItem
        '
        Me.DuplicaOrdineToolStripMenuItem.Name = "DuplicaOrdineToolStripMenuItem"
        Me.DuplicaOrdineToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.DuplicaOrdineToolStripMenuItem.Text = "Duplica Ordine"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(263, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(266, 22)
        Me.ToolStripMenuItem1.Text = "Segna come In Consegna"
        Me.ToolStripMenuItem1.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(266, 22)
        Me.ToolStripMenuItem2.Text = "Segna come Pronto per la Consegna"
        '
        'SegnaComePagatoToolStripMenuItem
        '
        Me.SegnaComePagatoToolStripMenuItem.Name = "SegnaComePagatoToolStripMenuItem"
        Me.SegnaComePagatoToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.SegnaComePagatoToolStripMenuItem.Text = "Segna come Pagato"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(263, 6)
        '
        'mnuFiltraCliente
        '
        Me.mnuFiltraCliente.Name = "mnuFiltraCliente"
        Me.mnuFiltraCliente.Size = New System.Drawing.Size(266, 22)
        Me.mnuFiltraCliente.Text = "Filtra con questo cliente"
        '
        'mnuFiltraProdotto
        '
        Me.mnuFiltraProdotto.Name = "mnuFiltraProdotto"
        Me.mnuFiltraProdotto.Size = New System.Drawing.Size(266, 22)
        Me.mnuFiltraProdotto.Text = "Filtra con questo prodotto"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(263, 6)
        '
        'ModificaDatiEconomiciToolStripMenuItem
        '
        Me.ModificaDatiEconomiciToolStripMenuItem.Name = "ModificaDatiEconomiciToolStripMenuItem"
        Me.ModificaDatiEconomiciToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.ModificaDatiEconomiciToolStripMenuItem.Text = "Modifica importi"
        '
        'ModificaOrdineToolStripMenuItem
        '
        Me.ModificaOrdineToolStripMenuItem.Name = "ModificaOrdineToolStripMenuItem"
        Me.ModificaOrdineToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.ModificaOrdineToolStripMenuItem.Text = "Modifica ordine"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(263, 6)
        '
        'EmettiDocumentoFiscaleToolStripMenuItem
        '
        Me.EmettiDocumentoFiscaleToolStripMenuItem.Name = "EmettiDocumentoFiscaleToolStripMenuItem"
        Me.EmettiDocumentoFiscaleToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.EmettiDocumentoFiscaleToolStripMenuItem.Text = "Emetti Documento Fiscale"
        '
        'RiapriDocumentoFiscaleToolStripMenuItem
        '
        Me.RiapriDocumentoFiscaleToolStripMenuItem.Name = "RiapriDocumentoFiscaleToolStripMenuItem"
        Me.RiapriDocumentoFiscaleToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.RiapriDocumentoFiscaleToolStripMenuItem.Text = "Riapri Documento Fiscale "
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(266, 22)
        Me.ToolStripMenuItem3.Text = "Riapri Consegna Programmata"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(263, 6)
        '
        'EliminaToolStripMenuItem
        '
        Me.EliminaToolStripMenuItem.Name = "EliminaToolStripMenuItem"
        Me.EliminaToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.EliminaToolStripMenuItem.Text = "Elimina"
        '
        'lnkStampa
        '
        Me.lnkStampa.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources.icoPrint1
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(146, 90)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 27)
        Me.lnkStampa.TabIndex = 53
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'contextMenuPrev
        '
        Me.contextMenuPrev.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RispondiAlPreventivoToolStripMenuItem, Me.ToolStripSeparator6, Me.CreaProdottoSuPreventivoToolStripMenuItem})
        Me.contextMenuPrev.Name = "contextMenuPrev"
        Me.contextMenuPrev.Size = New System.Drawing.Size(223, 76)
        '
        'RispondiAlPreventivoToolStripMenuItem
        '
        Me.RispondiAlPreventivoToolStripMenuItem.Name = "RispondiAlPreventivoToolStripMenuItem"
        Me.RispondiAlPreventivoToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.RispondiAlPreventivoToolStripMenuItem.Text = "Rispondi al preventivo"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(219, 6)
        '
        'CreaProdottoSuPreventivoToolStripMenuItem
        '
        Me.CreaProdottoSuPreventivoToolStripMenuItem.Name = "CreaProdottoSuPreventivoToolStripMenuItem"
        Me.CreaProdottoSuPreventivoToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.CreaProdottoSuPreventivoToolStripMenuItem.Text = "Crea prodotto su preventivo"
        '
        'UcAnteprimaPrev
        '
        Me.UcAnteprimaPrev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcAnteprimaPrev.BackColor = System.Drawing.Color.White
        Me.UcAnteprimaPrev.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.UcAnteprimaPrev.Location = New System.Drawing.Point(697, 90)
        Me.UcAnteprimaPrev.Name = "UcAnteprimaPrev"
        Me.UcAnteprimaPrev.Size = New System.Drawing.Size(326, 332)
        Me.UcAnteprimaPrev.TabIndex = 56
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources.icoOrderNew
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(3, 90)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(137, 27)
        Me.lnkNew.TabIndex = 57
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo Preventivo"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucPreventivi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.UcAnteprimaPrev)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DgOrdini)
        Me.Controls.Add(Me.lnkOrdMail)
        Me.Controls.Add(Me.lnkStampa)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Name = "ucPreventivi"
        Me.Size = New System.Drawing.Size(1026, 425)
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuOrd.ResumeLayout(False)
        Me.contextMenuPrev.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgOrdini As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCerca As System.Windows.Forms.TextBox
    Friend WithEvents lblClienti As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lnkCerca As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkOrdMail As System.Windows.Forms.LinkLabel
    Friend WithEvents MenuOrd As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DuplicaOrdineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SegnaComePagatoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ModificaDatiEconomiciToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInviaMail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFiltraCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFiltraProdotto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ModificaOrdineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EmettiDocumentoFiscaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RiapriDocumentoFiscaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EliminaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkDataInsDal As System.Windows.Forms.CheckBox
    Friend WithEvents chkDataInsAl As System.Windows.Forms.CheckBox
    Friend WithEvents dtDataInsDal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDataInsAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbRisposto As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UcAnteprimaPrev As Former.ucAnteprima
    Friend WithEvents contextMenuPrev As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RispondiAlPreventivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CreaProdottoSuPreventivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel

End Class
