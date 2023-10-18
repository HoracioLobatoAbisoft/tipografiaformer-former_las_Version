<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContabilitaEmissioneDocumenti
    Inherits baseFormInternaRedim

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblRighe = New System.Windows.Forms.Label()
        Me.lblPagine = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkEmettiPagam = New System.Windows.Forms.CheckBox()
        Me.lblDataPrevPagam = New System.Windows.Forms.Label()
        Me.cmbPagam = New System.Windows.Forms.ComboBox()
        Me.chkRiapri = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblTotDocum = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTotIva = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotImp = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCostoCorr = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblNumDoc = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnAddOrder = New System.Windows.Forms.Button()
        Me.txtPagamento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIndCons = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumColli = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCorriere = New System.Windows.Forms.ComboBox()
        Me.lblCorr1 = New System.Windows.Forms.Label()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRimuovi = New System.Windows.Forms.Button()
        Me.DgLavori = New System.Windows.Forms.DataGridView()
        Me.Anteprima = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Ordine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prodotto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColliCaricati = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColliTotali = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prezzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Preventivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.UcComboCliente = New Former.ucComboRubrica()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(959, 780)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.UcComboCliente)
        Me.tbProd.Controls.Add(Me.GroupBox3)
        Me.tbProd.Controls.Add(Me.chkEmettiPagam)
        Me.tbProd.Controls.Add(Me.lblDataPrevPagam)
        Me.tbProd.Controls.Add(Me.cmbPagam)
        Me.tbProd.Controls.Add(Me.chkRiapri)
        Me.tbProd.Controls.Add(Me.GroupBox2)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.btnAddOrder)
        Me.tbProd.Controls.Add(Me.txtPagamento)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtIndCons)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtPeso)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.txtNumColli)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbCorriere)
        Me.tbProd.Controls.Add(Me.lblCorr1)
        Me.tbProd.Controls.Add(Me.btnSalva)
        Me.tbProd.Controls.Add(Me.btnCancel)
        Me.tbProd.Controls.Add(Me.btnAdd)
        Me.tbProd.Controls.Add(Me.btnRimuovi)
        Me.tbProd.Controls.Add(Me.DgLavori)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(951, 754)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Emissione Documenti"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblRighe)
        Me.GroupBox3.Controls.Add(Me.lblPagine)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(398, 601)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 42)
        Me.GroupBox3.TabIndex = 117
        Me.GroupBox3.TabStop = False
        '
        'lblRighe
        '
        Me.lblRighe.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRighe.ForeColor = System.Drawing.Color.Black
        Me.lblRighe.Location = New System.Drawing.Point(58, 17)
        Me.lblRighe.Name = "lblRighe"
        Me.lblRighe.Size = New System.Drawing.Size(71, 15)
        Me.lblRighe.TabIndex = 98
        Me.lblRighe.Text = "0"
        Me.lblRighe.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPagine
        '
        Me.lblPagine.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPagine.ForeColor = System.Drawing.Color.Black
        Me.lblPagine.Location = New System.Drawing.Point(223, 18)
        Me.lblPagine.Name = "lblPagine"
        Me.lblPagine.Size = New System.Drawing.Size(71, 15)
        Me.lblPagine.TabIndex = 97
        Me.lblPagine.Text = "1"
        Me.lblPagine.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(171, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "Pagine"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 15)
        Me.Label9.TabIndex = 96
        Me.Label9.Text = "Righe"
        '
        'chkEmettiPagam
        '
        Me.chkEmettiPagam.AutoSize = True
        Me.chkEmettiPagam.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkEmettiPagam.ForeColor = System.Drawing.Color.Red
        Me.chkEmettiPagam.Location = New System.Drawing.Point(398, 697)
        Me.chkEmettiPagam.Name = "chkEmettiPagam"
        Me.chkEmettiPagam.Size = New System.Drawing.Size(216, 19)
        Me.chkEmettiPagam.TabIndex = 116
        Me.chkEmettiPagam.Text = "Registra direttamente Pagamento"
        Me.chkEmettiPagam.UseVisualStyleBackColor = True
        '
        'lblDataPrevPagam
        '
        Me.lblDataPrevPagam.ForeColor = System.Drawing.Color.Black
        Me.lblDataPrevPagam.Location = New System.Drawing.Point(704, 519)
        Me.lblDataPrevPagam.Name = "lblDataPrevPagam"
        Me.lblDataPrevPagam.Size = New System.Drawing.Size(239, 15)
        Me.lblDataPrevPagam.TabIndex = 114
        Me.lblDataPrevPagam.Text = "-"
        '
        'cmbPagam
        '
        Me.cmbPagam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPagam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPagam.BackColor = System.Drawing.Color.White
        Me.cmbPagam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPagam.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPagam.ForeColor = System.Drawing.Color.Black
        Me.cmbPagam.FormattingEnabled = True
        Me.cmbPagam.Location = New System.Drawing.Point(206, 516)
        Me.cmbPagam.Name = "cmbPagam"
        Me.cmbPagam.Size = New System.Drawing.Size(492, 23)
        Me.cmbPagam.TabIndex = 113
        '
        'chkRiapri
        '
        Me.chkRiapri.Location = New System.Drawing.Point(8, 121)
        Me.chkRiapri.Name = "chkRiapri"
        Me.chkRiapri.Size = New System.Drawing.Size(69, 20)
        Me.chkRiapri.TabIndex = 112
        Me.chkRiapri.Text = "Riapri"
        Me.chkRiapri.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTotDocum)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lblTotIva)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lblTotImp)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtCostoCorr)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(81, 601)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(311, 115)
        Me.GroupBox2.TabIndex = 111
        Me.GroupBox2.TabStop = False
        '
        'lblTotDocum
        '
        Me.lblTotDocum.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotDocum.Location = New System.Drawing.Point(156, 79)
        Me.lblTotDocum.Name = "lblTotDocum"
        Me.lblTotDocum.Size = New System.Drawing.Size(140, 24)
        Me.lblTotDocum.TabIndex = 113
        Me.lblTotDocum.Text = "0"
        Me.lblTotDocum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(10, 81)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 21)
        Me.Label14.TabIndex = 112
        Me.Label14.Text = "Tot. Documento"
        '
        'lblTotIva
        '
        Me.lblTotIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotIva.Location = New System.Drawing.Point(156, 64)
        Me.lblTotIva.Name = "lblTotIva"
        Me.lblTotIva.Size = New System.Drawing.Size(137, 15)
        Me.lblTotIva.TabIndex = 111
        Me.lblTotIva.Text = "0"
        Me.lblTotIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(11, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 15)
        Me.Label12.TabIndex = 110
        Me.Label12.Text = "Tot. Iva"
        '
        'lblTotImp
        '
        Me.lblTotImp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotImp.Location = New System.Drawing.Point(156, 46)
        Me.lblTotImp.Name = "lblTotImp"
        Me.lblTotImp.Size = New System.Drawing.Size(138, 15)
        Me.lblTotImp.TabIndex = 109
        Me.lblTotImp.Text = "0"
        Me.lblTotImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(11, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 15)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "Tot. Imponibile"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(11, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 15)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "Costo spedizioni"
        '
        'txtCostoCorr
        '
        Me.txtCostoCorr.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCostoCorr.Location = New System.Drawing.Point(156, 20)
        Me.txtCostoCorr.Name = "txtCostoCorr"
        Me.txtCostoCorr.Size = New System.Drawing.Size(138, 23)
        Me.txtCostoCorr.TabIndex = 96
        Me.txtCostoCorr.Text = "0"
        Me.txtCostoCorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.lblNumDoc)
        Me.GroupBox1.Controls.Add(Me.cmbTipo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(81, 440)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(864, 43)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(317, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Numero"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(492, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Data"
        '
        'lblDate
        '
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDate.Location = New System.Drawing.Point(531, 17)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(120, 15)
        Me.lblDate.TabIndex = 109
        Me.lblDate.Text = "0"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumDoc
        '
        Me.lblNumDoc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumDoc.Location = New System.Drawing.Point(375, 17)
        Me.lblNumDoc.Name = "lblNumDoc"
        Me.lblNumDoc.Size = New System.Drawing.Size(111, 15)
        Me.lblNumDoc.TabIndex = 108
        Me.lblNumDoc.Text = "0"
        Me.lblNumDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(108, 12)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(203, 28)
        Me.cmbTipo.TabIndex = 91
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(6, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 15)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Tipo documento"
        '
        'btnAddOrder
        '
        Me.btnAddOrder.BackColor = System.Drawing.Color.White
        Me.btnAddOrder.Image = Global.Former.My.Resources.Resources._Ordine
        Me.btnAddOrder.Location = New System.Drawing.Point(6, 147)
        Me.btnAddOrder.Name = "btnAddOrder"
        Me.btnAddOrder.Size = New System.Drawing.Size(69, 69)
        Me.btnAddOrder.TabIndex = 105
        Me.btnAddOrder.UseVisualStyleBackColor = False
        '
        'txtPagamento
        '
        Me.txtPagamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPagamento.Location = New System.Drawing.Point(539, 574)
        Me.txtPagamento.Name = "txtPagamento"
        Me.txtPagamento.Size = New System.Drawing.Size(159, 23)
        Me.txtPagamento.TabIndex = 104
        Me.txtPagamento.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(87, 519)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 15)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Pagamento"
        '
        'txtIndCons
        '
        Me.txtIndCons.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIndCons.Location = New System.Drawing.Point(206, 489)
        Me.txtIndCons.Name = "txtIndCons"
        Me.txtIndCons.Size = New System.Drawing.Size(737, 23)
        Me.txtIndCons.TabIndex = 102
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(87, 492)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 15)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Indirizzo consegna"
        '
        'txtPeso
        '
        Me.txtPeso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPeso.Location = New System.Drawing.Point(398, 574)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(135, 23)
        Me.txtPeso.TabIndex = 100
        Me.txtPeso.Text = "0"
        Me.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(352, 577)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Peso"
        '
        'txtNumColli
        '
        Me.txtNumColli.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNumColli.Location = New System.Drawing.Point(206, 574)
        Me.txtNumColli.Name = "txtNumColli"
        Me.txtNumColli.Size = New System.Drawing.Size(140, 23)
        Me.txtNumColli.TabIndex = 98
        Me.txtNumColli.Text = "0"
        Me.txtNumColli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(87, 577)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Numero Colli"
        '
        'cmbCorriere
        '
        Me.cmbCorriere.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCorriere.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCorriere.BackColor = System.Drawing.Color.White
        Me.cmbCorriere.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCorriere.ForeColor = System.Drawing.Color.Black
        Me.cmbCorriere.FormattingEnabled = True
        Me.cmbCorriere.Location = New System.Drawing.Point(206, 543)
        Me.cmbCorriere.Name = "cmbCorriere"
        Me.cmbCorriere.Size = New System.Drawing.Size(492, 23)
        Me.cmbCorriere.TabIndex = 93
        '
        'lblCorr1
        '
        Me.lblCorr1.AutoSize = True
        Me.lblCorr1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCorr1.ForeColor = System.Drawing.Color.Black
        Me.lblCorr1.Location = New System.Drawing.Point(87, 548)
        Me.lblCorr1.Name = "lblCorr1"
        Me.lblCorr1.Size = New System.Drawing.Size(57, 15)
        Me.lblCorr1.TabIndex = 94
        Me.lblCorr1.Text = "Trasporto"
        '
        'btnSalva
        '
        Me.btnSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalva.BackColor = System.Drawing.Color.White
        Me.btnSalva.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnSalva.Location = New System.Drawing.Point(799, 677)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(69, 69)
        Me.btnSalva.TabIndex = 88
        Me.btnSalva.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(874, 677)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 69)
        Me.btnCancel.TabIndex = 87
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAdd.Location = New System.Drawing.Point(6, 46)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(69, 69)
        Me.btnAdd.TabIndex = 86
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnRimuovi
        '
        Me.btnRimuovi.BackColor = System.Drawing.Color.White
        Me.btnRimuovi.Image = Global.Former.My.Resources.Resources._Rimuovi
        Me.btnRimuovi.Location = New System.Drawing.Point(6, 365)
        Me.btnRimuovi.Name = "btnRimuovi"
        Me.btnRimuovi.Size = New System.Drawing.Size(69, 69)
        Me.btnRimuovi.TabIndex = 85
        Me.btnRimuovi.UseVisualStyleBackColor = False
        '
        'DgLavori
        '
        Me.DgLavori.AllowUserToAddRows = False
        Me.DgLavori.AllowUserToDeleteRows = False
        Me.DgLavori.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLavori.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLavori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgLavori.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgLavori.BackgroundColor = System.Drawing.Color.White
        Me.DgLavori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLavori.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavori.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLavori.ColumnHeadersHeight = 20
        Me.DgLavori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLavori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Anteprima, Me.Ordine, Me.Prodotto, Me.Cliente, Me.ColliCaricati, Me.ColliTotali, Me.Prezzo, Me.Preventivo})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgLavori.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavori.EnableHeadersVisualStyles = False
        Me.DgLavori.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavori.Location = New System.Drawing.Point(81, 46)
        Me.DgLavori.MultiSelect = False
        Me.DgLavori.Name = "DgLavori"
        Me.DgLavori.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgLavori.RowHeadersVisible = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DgLavori.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.DgLavori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.Height = 150
        Me.DgLavori.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavori.Size = New System.Drawing.Size(864, 388)
        Me.DgLavori.TabIndex = 79
        Me.DgLavori.TabStop = False
        '
        'Anteprima
        '
        Me.Anteprima.HeaderText = "Anteprima"
        Me.Anteprima.Name = "Anteprima"
        Me.Anteprima.ReadOnly = True
        '
        'Ordine
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Ordine.DefaultCellStyle = DataGridViewCellStyle3
        Me.Ordine.HeaderText = "Ordine"
        Me.Ordine.Name = "Ordine"
        Me.Ordine.ReadOnly = True
        '
        'Prodotto
        '
        Me.Prodotto.HeaderText = "Prodotto"
        Me.Prodotto.Name = "Prodotto"
        Me.Prodotto.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'ColliCaricati
        '
        Me.ColliCaricati.HeaderText = "Colli Caricati"
        Me.ColliCaricati.Name = "ColliCaricati"
        Me.ColliCaricati.ReadOnly = True
        '
        'ColliTotali
        '
        Me.ColliTotali.HeaderText = "Colli Totali"
        Me.ColliTotali.Name = "ColliTotali"
        Me.ColliTotali.ReadOnly = True
        '
        'Prezzo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Prezzo.DefaultCellStyle = DataGridViewCellStyle4
        Me.Prezzo.HeaderText = "Prezzo"
        Me.Prezzo.Name = "Prezzo"
        Me.Prezzo.ReadOnly = True
        '
        'Preventivo
        '
        Me.Preventivo.DataPropertyName = "PreventivoStr"
        Me.Preventivo.HeaderText = "Preventivo"
        Me.Preventivo.Name = "Preventivo"
        Me.Preventivo.ReadOnly = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(176, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Emissione Documenti"
        '
        'UcComboCliente
        '
        Me.UcComboCliente.BackColor = System.Drawing.Color.White
        Me.UcComboCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcComboCliente.IdRubSelezionato = 0
        Me.UcComboCliente.Location = New System.Drawing.Point(241, 10)
        Me.UcComboCliente.Name = "UcComboCliente"
        Me.UcComboCliente.Size = New System.Drawing.Size(704, 26)
        Me.UcComboCliente.TabIndex = 118
        '
        'frmContabilitaEmissioneDocumenti
        '
        Me.AcceptButton = Me.btnSalva
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(959, 780)
        Me.Controls.Add(Me.TabMain)
        Me.MinimumSize = New System.Drawing.Size(0, 726)
        Me.Name = "frmContabilitaEmissioneDocumenti"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Emissione documenti"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents DgLavori As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRimuovi As System.Windows.Forms.Button
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cmbCorriere As System.Windows.Forms.ComboBox
    Friend WithEvents lblCorr1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCostoCorr As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumColli As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIndCons As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPagamento As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAddOrder As System.Windows.Forms.Button
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblNumDoc As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotDocum As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTotIva As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTotImp As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkRiapri As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPagam As System.Windows.Forms.ComboBox
    Friend WithEvents lblDataPrevPagam As System.Windows.Forms.Label
    Friend WithEvents chkEmettiPagam As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRighe As System.Windows.Forms.Label
    Friend WithEvents lblPagine As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Anteprima As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Ordine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prodotto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColliCaricati As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColliTotali As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prezzo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Preventivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UcComboCliente As ucComboRubrica
End Class
