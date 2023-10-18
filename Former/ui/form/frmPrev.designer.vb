<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrev
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrev))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.txtSconto = New Former.ucCTRNumericTextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTot = New Former.ucCTRNumericTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtIva = New Former.ucCTRNumericTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPrezzo = New Former.ucCTRNumericTextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbCli = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.pctAnte = New System.Windows.Forms.PictureBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtLavoraz = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCarta = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFormatoCh = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFormatoAp = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStampa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPag = New Former.ucCTRNumericTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQta = New Former.ucCTRNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodice = New System.Windows.Forms.TextBox()
        Me.txtTipoLav = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCorr = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSfogliaSorg4 = New System.Windows.Forms.Button()
        Me.txtSorg4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSfogliaSorg3 = New System.Windows.Forms.Button()
        Me.txtSorg3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSfogliaAnte = New System.Windows.Forms.Button()
        Me.txtAnteprima = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.OpenFileDialogAnte = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogSorg = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctAnte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 587)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(750, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources.cancel
        Me.btnCancel.Location = New System.Drawing.Point(708, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 36)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark2
        Me.btnOk.Location = New System.Drawing.Point(674, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
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
        Me.TabMain.Size = New System.Drawing.Size(750, 587)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.txtSconto)
        Me.tbProd.Controls.Add(Me.Label24)
        Me.tbProd.Controls.Add(Me.txtTot)
        Me.tbProd.Controls.Add(Me.Label23)
        Me.tbProd.Controls.Add(Me.txtIva)
        Me.tbProd.Controls.Add(Me.Label22)
        Me.tbProd.Controls.Add(Me.txtPrezzo)
        Me.tbProd.Controls.Add(Me.Label21)
        Me.tbProd.Controls.Add(Me.Label20)
        Me.tbProd.Controls.Add(Me.cmbCli)
        Me.tbProd.Controls.Add(Me.Label19)
        Me.tbProd.Controls.Add(Me.pctAnte)
        Me.tbProd.Controls.Add(Me.Label18)
        Me.tbProd.Controls.Add(Me.Label17)
        Me.tbProd.Controls.Add(Me.Label16)
        Me.tbProd.Controls.Add(Me.Label15)
        Me.tbProd.Controls.Add(Me.Label14)
        Me.tbProd.Controls.Add(Me.txtLavoraz)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.txtCarta)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.txtFormatoCh)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.txtFormatoAp)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.txtStampa)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.txtPag)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtQta)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtCodice)
        Me.tbProd.Controls.Add(Me.txtTipoLav)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtNumero)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.cmbCorr)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.Label35)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(742, 559)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Preventivo"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'txtSconto
        '
        Me.txtSconto.BackColor = System.Drawing.Color.White
        Me.txtSconto.DefaultValue = 0
        Me.txtSconto.Location = New System.Drawing.Point(122, 421)
        Me.txtSconto.MaxValue = 1.0E+10!
        Me.txtSconto.MinValue = -1.0E+9!
        Me.txtSconto.Name = "txtSconto"
        Me.txtSconto.OnlyInteger = False
        Me.txtSconto.Size = New System.Drawing.Size(85, 21)
        Me.txtSconto.TabIndex = 69
        Me.txtSconto.Text = "0"
        Me.txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(21, 424)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(45, 15)
        Me.Label24.TabIndex = 68
        Me.Label24.Text = "Sconto"
        '
        'txtTot
        '
        Me.txtTot.BackColor = System.Drawing.Color.White
        Me.txtTot.DefaultValue = 0
        Me.txtTot.Location = New System.Drawing.Point(122, 475)
        Me.txtTot.MaxValue = 1.0E+10!
        Me.txtTot.MinValue = -1.0E+9!
        Me.txtTot.Name = "txtTot"
        Me.txtTot.OnlyInteger = False
        Me.txtTot.ReadOnly = True
        Me.txtTot.Size = New System.Drawing.Size(85, 21)
        Me.txtTot.TabIndex = 67
        Me.txtTot.Text = "0"
        Me.txtTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(21, 478)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 15)
        Me.Label23.TabIndex = 66
        Me.Label23.Text = "Totale"
        '
        'txtIva
        '
        Me.txtIva.BackColor = System.Drawing.Color.White
        Me.txtIva.DefaultValue = 0
        Me.txtIva.Location = New System.Drawing.Point(122, 448)
        Me.txtIva.MaxValue = 1.0E+10!
        Me.txtIva.MinValue = -1.0E+9!
        Me.txtIva.Name = "txtIva"
        Me.txtIva.OnlyInteger = False
        Me.txtIva.ReadOnly = True
        Me.txtIva.Size = New System.Drawing.Size(85, 21)
        Me.txtIva.TabIndex = 65
        Me.txtIva.Text = "0"
        Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(21, 451)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(22, 15)
        Me.Label22.TabIndex = 64
        Me.Label22.Text = "Iva"
        '
        'txtPrezzo
        '
        Me.txtPrezzo.BackColor = System.Drawing.Color.White
        Me.txtPrezzo.DefaultValue = 0
        Me.txtPrezzo.Location = New System.Drawing.Point(122, 394)
        Me.txtPrezzo.MaxValue = 1.0E+10!
        Me.txtPrezzo.MinValue = -1.0E+9!
        Me.txtPrezzo.Name = "txtPrezzo"
        Me.txtPrezzo.OnlyInteger = False
        Me.txtPrezzo.ReadOnly = True
        Me.txtPrezzo.Size = New System.Drawing.Size(85, 21)
        Me.txtPrezzo.TabIndex = 63
        Me.txtPrezzo.Text = "0"
        Me.txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(21, 397)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 15)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Prezzo"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(21, 125)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 15)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Codice"
        '
        'cmbCli
        '
        Me.cmbCli.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCli.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCli.FormattingEnabled = True
        Me.cmbCli.Location = New System.Drawing.Point(122, 66)
        Me.cmbCli.Name = "cmbCli"
        Me.cmbCli.Size = New System.Drawing.Size(460, 23)
        Me.cmbCli.TabIndex = 60
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(21, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 15)
        Me.Label19.TabIndex = 59
        Me.Label19.Text = "Cliente"
        '
        'pctAnte
        '
        Me.pctAnte.Location = New System.Drawing.Point(605, 6)
        Me.pctAnte.Name = "pctAnte"
        Me.pctAnte.Size = New System.Drawing.Size(129, 156)
        Me.pctAnte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnte.TabIndex = 57
        Me.pctAnte.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(367, 344)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 15)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "(es. piega)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(367, 260)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 15)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "(es. 5,5cm x 8,5cm)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(367, 233)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 15)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "(es. 4+0 o 4+4)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(213, 179)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 15)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "(es. 1000)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(367, 152)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(122, 15)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "(es. biglietti da visita)"
        '
        'txtLavoraz
        '
        Me.txtLavoraz.BackColor = System.Drawing.Color.White
        Me.txtLavoraz.Location = New System.Drawing.Point(122, 338)
        Me.txtLavoraz.Name = "txtLavoraz"
        Me.txtLavoraz.Size = New System.Drawing.Size(239, 21)
        Me.txtLavoraz.TabIndex = 55
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(21, 341)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 15)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Lavorazioni"
        '
        'txtCarta
        '
        Me.txtCarta.BackColor = System.Drawing.Color.White
        Me.txtCarta.Location = New System.Drawing.Point(122, 311)
        Me.txtCarta.Name = "txtCarta"
        Me.txtCarta.Size = New System.Drawing.Size(239, 21)
        Me.txtCarta.TabIndex = 53
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(21, 314)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 15)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Carta *"
        '
        'txtFormatoCh
        '
        Me.txtFormatoCh.BackColor = System.Drawing.Color.White
        Me.txtFormatoCh.Location = New System.Drawing.Point(122, 284)
        Me.txtFormatoCh.Name = "txtFormatoCh"
        Me.txtFormatoCh.Size = New System.Drawing.Size(239, 21)
        Me.txtFormatoCh.TabIndex = 51
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(21, 287)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 15)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Formato chiuso"
        '
        'txtFormatoAp
        '
        Me.txtFormatoAp.BackColor = System.Drawing.Color.White
        Me.txtFormatoAp.Location = New System.Drawing.Point(122, 257)
        Me.txtFormatoAp.Name = "txtFormatoAp"
        Me.txtFormatoAp.Size = New System.Drawing.Size(239, 21)
        Me.txtFormatoAp.TabIndex = 49
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 260)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 15)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Formato aperto *"
        '
        'txtStampa
        '
        Me.txtStampa.BackColor = System.Drawing.Color.White
        Me.txtStampa.Location = New System.Drawing.Point(122, 230)
        Me.txtStampa.Name = "txtStampa"
        Me.txtStampa.Size = New System.Drawing.Size(239, 21)
        Me.txtStampa.TabIndex = 47
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(21, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 15)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Stampa *"
        '
        'txtPag
        '
        Me.txtPag.BackColor = System.Drawing.Color.White
        Me.txtPag.DefaultValue = 0
        Me.txtPag.Location = New System.Drawing.Point(122, 203)
        Me.txtPag.MaxValue = 1.0E+10!
        Me.txtPag.MinValue = -1.0E+9!
        Me.txtPag.Name = "txtPag"
        Me.txtPag.OnlyInteger = True
        Me.txtPag.Size = New System.Drawing.Size(85, 21)
        Me.txtPag.TabIndex = 45
        Me.txtPag.Text = "0"
        Me.txtPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(21, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Pagine"
        '
        'txtQta
        '
        Me.txtQta.BackColor = System.Drawing.Color.White
        Me.txtQta.DefaultValue = 0
        Me.txtQta.Location = New System.Drawing.Point(122, 176)
        Me.txtQta.MaxValue = 1.0E+10!
        Me.txtQta.MinValue = -1.0E+9!
        Me.txtQta.Name = "txtQta"
        Me.txtQta.OnlyInteger = True
        Me.txtQta.Size = New System.Drawing.Size(85, 21)
        Me.txtQta.TabIndex = 43
        Me.txtQta.Text = "0"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(21, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Q.ta *"
        '
        'txtCodice
        '
        Me.txtCodice.BackColor = System.Drawing.Color.White
        Me.txtCodice.Location = New System.Drawing.Point(122, 122)
        Me.txtCodice.Name = "txtCodice"
        Me.txtCodice.ReadOnly = True
        Me.txtCodice.Size = New System.Drawing.Size(239, 21)
        Me.txtCodice.TabIndex = 41
        '
        'txtTipoLav
        '
        Me.txtTipoLav.BackColor = System.Drawing.Color.White
        Me.txtTipoLav.Location = New System.Drawing.Point(122, 149)
        Me.txtTipoLav.Name = "txtTipoLav"
        Me.txtTipoLav.Size = New System.Drawing.Size(239, 21)
        Me.txtTipoLav.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Tipo lavoro *"
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.Location = New System.Drawing.Point(122, 95)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(239, 21)
        Me.txtNumero.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(21, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 15)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Preventivo N°"
        '
        'cmbCorr
        '
        Me.cmbCorr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorr.FormattingEnabled = True
        Me.cmbCorr.Location = New System.Drawing.Point(122, 365)
        Me.cmbCorr.Name = "cmbCorr"
        Me.cmbCorr.Size = New System.Drawing.Size(239, 23)
        Me.cmbCorr.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(21, 368)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 15)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Consegna"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnSfogliaSorg4)
        Me.GroupBox1.Controls.Add(Me.txtSorg4)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnSfogliaSorg3)
        Me.GroupBox1.Controls.Add(Me.txtSorg3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnSfogliaAnte)
        Me.GroupBox1.Controls.Add(Me.txtAnteprima)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 502)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(726, 51)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File allegati al preventivo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 15)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Sorgente Retro"
        Me.Label5.Visible = False
        '
        'btnSfogliaSorg4
        '
        Me.btnSfogliaSorg4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnSfogliaSorg4.ForeColor = System.Drawing.Color.Black
        Me.btnSfogliaSorg4.Location = New System.Drawing.Point(592, 139)
        Me.btnSfogliaSorg4.Name = "btnSfogliaSorg4"
        Me.btnSfogliaSorg4.Size = New System.Drawing.Size(27, 23)
        Me.btnSfogliaSorg4.TabIndex = 34
        Me.btnSfogliaSorg4.Text = "..."
        Me.btnSfogliaSorg4.UseVisualStyleBackColor = True
        Me.btnSfogliaSorg4.Visible = False
        '
        'txtSorg4
        '
        Me.txtSorg4.Location = New System.Drawing.Point(107, 140)
        Me.txtSorg4.Name = "txtSorg4"
        Me.txtSorg4.ReadOnly = True
        Me.txtSorg4.Size = New System.Drawing.Size(479, 21)
        Me.txtSorg4.TabIndex = 33
        Me.txtSorg4.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 15)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Sorgente Fronte"
        Me.Label4.Visible = False
        '
        'btnSfogliaSorg3
        '
        Me.btnSfogliaSorg3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnSfogliaSorg3.ForeColor = System.Drawing.Color.Black
        Me.btnSfogliaSorg3.Location = New System.Drawing.Point(592, 112)
        Me.btnSfogliaSorg3.Name = "btnSfogliaSorg3"
        Me.btnSfogliaSorg3.Size = New System.Drawing.Size(27, 23)
        Me.btnSfogliaSorg3.TabIndex = 31
        Me.btnSfogliaSorg3.Text = "..."
        Me.btnSfogliaSorg3.UseVisualStyleBackColor = True
        Me.btnSfogliaSorg3.Visible = False
        '
        'txtSorg3
        '
        Me.txtSorg3.Location = New System.Drawing.Point(107, 113)
        Me.txtSorg3.Name = "txtSorg3"
        Me.txtSorg3.ReadOnly = True
        Me.txtSorg3.Size = New System.Drawing.Size(479, 21)
        Me.txtSorg3.TabIndex = 30
        Me.txtSorg3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(13, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Anteprima"
        '
        'btnSfogliaAnte
        '
        Me.btnSfogliaAnte.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnSfogliaAnte.ForeColor = System.Drawing.Color.Black
        Me.btnSfogliaAnte.Location = New System.Drawing.Point(693, 19)
        Me.btnSfogliaAnte.Name = "btnSfogliaAnte"
        Me.btnSfogliaAnte.Size = New System.Drawing.Size(27, 21)
        Me.btnSfogliaAnte.TabIndex = 22
        Me.btnSfogliaAnte.Text = "..."
        Me.btnSfogliaAnte.UseVisualStyleBackColor = True
        '
        'txtAnteprima
        '
        Me.txtAnteprima.Location = New System.Drawing.Point(114, 19)
        Me.txtAnteprima.Name = "txtAnteprima"
        Me.txtAnteprima.ReadOnly = True
        Me.txtAnteprima.Size = New System.Drawing.Size(573, 21)
        Me.txtAnteprima.TabIndex = 21
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(154, 18)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(540, 22)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Richiesta di un preventivo."
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.icoPrev
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
        Me.lblTipo.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(99, 22)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Preventivo"
        '
        'OpenFileDialogAnte
        '
        Me.OpenFileDialogAnte.Filter = "File JPG|*.jpg|File EML|*.eml"
        '
        'OpenFileDialogSorg
        '
        Me.OpenFileDialogSorg.Filter = "Tutti i file|*.*"
        '
        'frmPrev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(750, 635)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPrev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former Clienti - Ordine"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctAnte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSfogliaAnte As System.Windows.Forms.Button
    Friend WithEvents txtAnteprima As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSfogliaSorg4 As System.Windows.Forms.Button
    Friend WithEvents txtSorg4 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSfogliaSorg3 As System.Windows.Forms.Button
    Friend WithEvents txtSorg3 As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialogAnte As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialogSorg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmbCorr As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLavoraz As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCarta As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFormatoCh As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFormatoAp As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStampa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTipoLav As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pctAnte As System.Windows.Forms.PictureBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbCli As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCodice As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPag As Former.ucCTRNumericTextBox
    Friend WithEvents txtQta As Former.ucCTRNumericTextBox
    Friend WithEvents txtSconto As Former.ucCTRNumericTextBox
    Friend WithEvents txtTot As Former.ucCTRNumericTextBox
    Friend WithEvents txtIva As Former.ucCTRNumericTextBox
    Friend WithEvents txtPrezzo As Former.ucCTRNumericTextBox
End Class
