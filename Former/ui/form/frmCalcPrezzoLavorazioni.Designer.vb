<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCalcPrezzoLavorazioni
    Inherits baseFormInternaFixed

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lnkMacchinario = New System.Windows.Forms.LinkLabel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblLavSel = New System.Windows.Forms.LinkLabel()
        Me.lblGrammMax = New System.Windows.Forms.Label()
        Me.lblDimensMax = New System.Windows.Forms.Label()
        Me.lblGrammMin = New System.Windows.Forms.Label()
        Me.lblDimensMin = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGrammatura = New Former.ucNumericTextBox()
        Me.txtLarghezza = New Former.ucNumericTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLunghezza = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumFacciate = New Former.ucNumericTextBox()
        Me.txtQuantita = New Former.ucNumericTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPrezzo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DgLavorazioni = New System.Windows.Forms.DataGridView()
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoriaLav = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Macchinario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tvwCatLavoraz = New System.Windows.Forms.TreeView()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblPrezzoCalcolato = New System.Windows.Forms.Label()
        Me.lblAvviamento = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgLavorazioni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 738)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1048, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
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
        Me.btnCancel.Location = New System.Drawing.Point(964, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
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
        Me.TabMain.Size = New System.Drawing.Size(1048, 738)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblAvviamento)
        Me.tbProd.Controls.Add(Me.lblPrezzoCalcolato)
        Me.tbProd.Controls.Add(Me.Label16)
        Me.tbProd.Controls.Add(Me.Label15)
        Me.tbProd.Controls.Add(Me.GroupBox2)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.txtQuantita)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.lblPrezzo)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.DgLavorazioni)
        Me.tbProd.Controls.Add(Me.tvwCatLavoraz)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1040, 712)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Calcolo Prezzo Lavorazione"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lnkMacchinario)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lblLavSel)
        Me.GroupBox2.Controls.Add(Me.lblGrammMax)
        Me.GroupBox2.Controls.Add(Me.lblDimensMax)
        Me.GroupBox2.Controls.Add(Me.lblGrammMin)
        Me.GroupBox2.Controls.Add(Me.lblDimensMin)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(53, 477)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(979, 136)
        Me.GroupBox2.TabIndex = 167
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lavorazione selezionata"
        '
        'lnkMacchinario
        '
        Me.lnkMacchinario.AutoSize = True
        Me.lnkMacchinario.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkMacchinario.LinkColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.lnkMacchinario.Location = New System.Drawing.Point(139, 96)
        Me.lnkMacchinario.Name = "lnkMacchinario"
        Me.lnkMacchinario.Size = New System.Drawing.Size(15, 20)
        Me.lnkMacchinario.TabIndex = 170
        Me.lnkMacchinario.TabStop = True
        Me.lnkMacchinario.Text = "-"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(7, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 15)
        Me.Label14.TabIndex = 169
        Me.Label14.Text = "Macchinario:"
        '
        'lblLavSel
        '
        Me.lblLavSel.AutoSize = True
        Me.lblLavSel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLavSel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.lblLavSel.Location = New System.Drawing.Point(6, 19)
        Me.lblLavSel.Name = "lblLavSel"
        Me.lblLavSel.Size = New System.Drawing.Size(16, 21)
        Me.lblLavSel.TabIndex = 168
        Me.lblLavSel.TabStop = True
        Me.lblLavSel.Text = "-"
        '
        'lblGrammMax
        '
        Me.lblGrammMax.AutoSize = True
        Me.lblGrammMax.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrammMax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblGrammMax.Location = New System.Drawing.Point(614, 69)
        Me.lblGrammMax.Name = "lblGrammMax"
        Me.lblGrammMax.Size = New System.Drawing.Size(15, 20)
        Me.lblGrammMax.TabIndex = 167
        Me.lblGrammMax.Text = "-"
        '
        'lblDimensMax
        '
        Me.lblDimensMax.AutoSize = True
        Me.lblDimensMax.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDimensMax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblDimensMax.Location = New System.Drawing.Point(614, 44)
        Me.lblDimensMax.Name = "lblDimensMax"
        Me.lblDimensMax.Size = New System.Drawing.Size(15, 20)
        Me.lblDimensMax.TabIndex = 166
        Me.lblDimensMax.Text = "-"
        '
        'lblGrammMin
        '
        Me.lblGrammMin.AutoSize = True
        Me.lblGrammMin.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrammMin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblGrammMin.Location = New System.Drawing.Point(139, 70)
        Me.lblGrammMin.Name = "lblGrammMin"
        Me.lblGrammMin.Size = New System.Drawing.Size(15, 20)
        Me.lblGrammMin.TabIndex = 165
        Me.lblGrammMin.Text = "-"
        '
        'lblDimensMin
        '
        Me.lblDimensMin.AutoSize = True
        Me.lblDimensMin.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDimensMin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblDimensMin.Location = New System.Drawing.Point(139, 45)
        Me.lblDimensMin.Name = "lblDimensMin"
        Me.lblDimensMin.Size = New System.Drawing.Size(15, 20)
        Me.lblDimensMin.TabIndex = 164
        Me.lblDimensMin.Text = "-"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(482, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 15)
        Me.Label10.TabIndex = 163
        Me.Label10.Text = "Grammatura massima:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(7, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 15)
        Me.Label13.TabIndex = 162
        Me.Label13.Text = "Grammatura minima:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(482, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 15)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "Dimensioni massime:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(7, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 15)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "Dimensioni minime:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtGrammatura)
        Me.GroupBox1.Controls.Add(Me.txtLarghezza)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtLunghezza)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNumFacciate)
        Me.GroupBox1.Location = New System.Drawing.Point(51, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(981, 45)
        Me.GroupBox1.TabIndex = 166
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Specifiche oggetto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Larghezza"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(633, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 15)
        Me.Label11.TabIndex = 165
        Me.Label11.Text = "grammi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(231, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Lunghezza"
        '
        'txtGrammatura
        '
        Me.txtGrammatura.Location = New System.Drawing.Point(545, 16)
        Me.txtGrammatura.MaxLength = 5
        Me.txtGrammatura.My_AccettaNegativi = False
        Me.txtGrammatura.My_AllowOnlyInteger = True
        Me.txtGrammatura.My_DefaultValue = 0
        Me.txtGrammatura.My_MaxValue = 99999.0!
        Me.txtGrammatura.My_MinValue = 0!
        Me.txtGrammatura.My_ReplaceWithDefaultValue = True
        Me.txtGrammatura.Name = "txtGrammatura"
        Me.txtGrammatura.Size = New System.Drawing.Size(82, 20)
        Me.txtGrammatura.TabIndex = 164
        Me.txtGrammatura.Text = "0"
        Me.txtGrammatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLarghezza
        '
        Me.txtLarghezza.Location = New System.Drawing.Point(71, 16)
        Me.txtLarghezza.MaxLength = 5
        Me.txtLarghezza.My_AccettaNegativi = False
        Me.txtLarghezza.My_AllowOnlyInteger = True
        Me.txtLarghezza.My_DefaultValue = 0
        Me.txtLarghezza.My_MaxValue = 99999.0!
        Me.txtLarghezza.My_MinValue = 1.0!
        Me.txtLarghezza.My_ReplaceWithDefaultValue = True
        Me.txtLarghezza.Name = "txtLarghezza"
        Me.txtLarghezza.Size = New System.Drawing.Size(82, 20)
        Me.txtLarghezza.TabIndex = 30
        Me.txtLarghezza.Text = "0"
        Me.txtLarghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(465, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 15)
        Me.Label12.TabIndex = 163
        Me.Label12.Text = "Grammatura"
        '
        'txtLunghezza
        '
        Me.txtLunghezza.Location = New System.Drawing.Point(300, 16)
        Me.txtLunghezza.MaxLength = 5
        Me.txtLunghezza.My_AccettaNegativi = False
        Me.txtLunghezza.My_AllowOnlyInteger = True
        Me.txtLunghezza.My_DefaultValue = 0
        Me.txtLunghezza.My_MaxValue = 99999.0!
        Me.txtLunghezza.My_MinValue = 1.0!
        Me.txtLunghezza.My_ReplaceWithDefaultValue = True
        Me.txtLunghezza.Name = "txtLunghezza"
        Me.txtLunghezza.Size = New System.Drawing.Size(82, 20)
        Me.txtLunghezza.TabIndex = 31
        Me.txtLunghezza.Text = "0"
        Me.txtLunghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(159, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "millimetri"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(388, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "millimetri"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(707, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "N° Facciate"
        '
        'txtNumFacciate
        '
        Me.txtNumFacciate.Location = New System.Drawing.Point(780, 16)
        Me.txtNumFacciate.MaxLength = 4
        Me.txtNumFacciate.My_AccettaNegativi = False
        Me.txtNumFacciate.My_AllowOnlyInteger = True
        Me.txtNumFacciate.My_DefaultValue = 2
        Me.txtNumFacciate.My_MaxValue = 9999.0!
        Me.txtNumFacciate.My_MinValue = 2.0!
        Me.txtNumFacciate.My_ReplaceWithDefaultValue = True
        Me.txtNumFacciate.Name = "txtNumFacciate"
        Me.txtNumFacciate.Size = New System.Drawing.Size(82, 20)
        Me.txtNumFacciate.TabIndex = 35
        Me.txtNumFacciate.Text = "2"
        Me.txtNumFacciate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantita
        '
        Me.txtQuantita.Location = New System.Drawing.Point(122, 97)
        Me.txtQuantita.MaxLength = 7
        Me.txtQuantita.My_AccettaNegativi = False
        Me.txtQuantita.My_AllowOnlyInteger = True
        Me.txtQuantita.My_DefaultValue = 1
        Me.txtQuantita.My_MaxValue = 9999999.0!
        Me.txtQuantita.My_MinValue = 1.0!
        Me.txtQuantita.My_ReplaceWithDefaultValue = True
        Me.txtQuantita.Name = "txtQuantita"
        Me.txtQuantita.Size = New System.Drawing.Size(82, 20)
        Me.txtQuantita.TabIndex = 157
        Me.txtQuantita.Text = "1"
        Me.txtQuantita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(57, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "Quantità"
        '
        'lblPrezzo
        '
        Me.lblPrezzo.AutoEllipsis = True
        Me.lblPrezzo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrezzo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblPrezzo.Location = New System.Drawing.Point(195, 661)
        Me.lblPrezzo.Name = "lblPrezzo"
        Me.lblPrezzo.Size = New System.Drawing.Size(843, 48)
        Me.lblPrezzo.TabIndex = 155
        Me.lblPrezzo.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(57, 661)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "Prezzo Totale"
        '
        'DgLavorazioni
        '
        Me.DgLavorazioni.AllowUserToAddRows = False
        Me.DgLavorazioni.AllowUserToDeleteRows = False
        Me.DgLavorazioni.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLavorazioni.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLavorazioni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgLavorazioni.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgLavorazioni.BackgroundColor = System.Drawing.Color.White
        Me.DgLavorazioni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLavorazioni.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavorazioni.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLavorazioni.ColumnHeadersHeight = 20
        Me.DgLavorazioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLavorazioni.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Img, Me.DataGridViewTextBoxColumn5, Me.CategoriaLav, Me.Descrizione, Me.Macchinario})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavorazioni.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgLavorazioni.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavorazioni.EnableHeadersVisualStyles = False
        Me.DgLavorazioni.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavorazioni.Location = New System.Drawing.Point(303, 125)
        Me.DgLavorazioni.MultiSelect = False
        Me.DgLavorazioni.Name = "DgLavorazioni"
        Me.DgLavorazioni.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavorazioni.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgLavorazioni.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgLavorazioni.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLavorazioni.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavorazioni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavorazioni.Size = New System.Drawing.Size(729, 346)
        Me.DgLavorazioni.TabIndex = 153
        Me.DgLavorazioni.TabStop = False
        '
        'Img
        '
        Me.Img.DataPropertyName = "Img"
        Me.Img.HeaderText = "Img"
        Me.Img.Name = "Img"
        Me.Img.ReadOnly = True
        Me.Img.Width = 33
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Sigla"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Sigla"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 56
        '
        'CategoriaLav
        '
        Me.CategoriaLav.DataPropertyName = "CatLav"
        Me.CategoriaLav.HeaderText = "Categoria"
        Me.CategoriaLav.Name = "CategoriaLav"
        Me.CategoriaLav.ReadOnly = True
        Me.CategoriaLav.Width = 82
        '
        'Descrizione
        '
        Me.Descrizione.DataPropertyName = "Descrizione"
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        Me.Descrizione.Width = 91
        '
        'Macchinario
        '
        Me.Macchinario.DataPropertyName = "Macchinario"
        Me.Macchinario.HeaderText = "Macchinario"
        Me.Macchinario.Name = "Macchinario"
        Me.Macchinario.ReadOnly = True
        Me.Macchinario.Width = 97
        '
        'tvwCatLavoraz
        '
        Me.tvwCatLavoraz.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvwCatLavoraz.Location = New System.Drawing.Point(51, 125)
        Me.tvwCatLavoraz.Name = "tvwCatLavoraz"
        Me.tvwCatLavoraz.Size = New System.Drawing.Size(246, 346)
        Me.tvwCatLavoraz.TabIndex = 152
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Prezzo
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 28
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(219, 21)
        Me.lblTipo.TabIndex = 27
        Me.lblTipo.Text = "Calcolo Prezzo Lavorazione"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(57, 616)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 15)
        Me.Label15.TabIndex = 168
        Me.Label15.Text = "Prezzo Calcolato"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(57, 639)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 15)
        Me.Label16.TabIndex = 169
        Me.Label16.Text = "Avviamento"
        '
        'lblPrezzoCalcolato
        '
        Me.lblPrezzoCalcolato.AutoSize = True
        Me.lblPrezzoCalcolato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrezzoCalcolato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblPrezzoCalcolato.Location = New System.Drawing.Point(195, 616)
        Me.lblPrezzoCalcolato.Name = "lblPrezzoCalcolato"
        Me.lblPrezzoCalcolato.Size = New System.Drawing.Size(12, 15)
        Me.lblPrezzoCalcolato.TabIndex = 170
        Me.lblPrezzoCalcolato.Text = "-"
        '
        'lblAvviamento
        '
        Me.lblAvviamento.AutoSize = True
        Me.lblAvviamento.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAvviamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblAvviamento.Location = New System.Drawing.Point(195, 639)
        Me.lblAvviamento.Name = "lblAvviamento"
        Me.lblAvviamento.Size = New System.Drawing.Size(12, 15)
        Me.lblAvviamento.TabIndex = 171
        Me.lblAvviamento.Text = "-"
        '
        'frmCalcPrezzoLavorazioni
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1048, 786)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCalcPrezzoLavorazioni"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Calcolo Prezzo Lavorazione"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgLavorazioni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As PictureBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents txtNumFacciate As ucNumericTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLunghezza As ucNumericTextBox
    Friend WithEvents txtLarghezza As ucNumericTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblPrezzo As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DgLavorazioni As DataGridView
    Friend WithEvents Img As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents CategoriaLav As DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As DataGridViewTextBoxColumn
    Friend WithEvents Macchinario As DataGridViewTextBoxColumn
    Friend WithEvents tvwCatLavoraz As TreeView
    Friend WithEvents txtQuantita As ucNumericTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblGrammMax As Label
    Friend WithEvents lblDimensMax As Label
    Friend WithEvents lblGrammMin As Label
    Friend WithEvents lblDimensMin As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtGrammatura As ucNumericTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lblLavSel As LinkLabel
    Friend WithEvents Label14 As Label
    Friend WithEvents lnkMacchinario As LinkLabel
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblAvviamento As Label
    Friend WithEvents lblPrezzoCalcolato As Label
End Class
