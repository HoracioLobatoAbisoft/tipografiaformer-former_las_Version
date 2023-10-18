<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStampaEtichette
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.txtQta = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRiga3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRiga2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRiga1 = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblEtichetteStampate = New System.Windows.Forms.Label()
        Me.txtNumeroPacchi = New Former.ucNumericTextBox()
        Me.txtFineNumerazione = New Former.ucNumericTextBox()
        Me.txtInizioNumerazione = New Former.ucNumericTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnStampa = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbStampanti = New System.Windows.Forms.ComboBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPulsanti.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(449, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.TabPage1)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(533, 212)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.BackColor = System.Drawing.Color.White
        Me.tbProd.Controls.Add(Me.txtQta)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.txtRiga3)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtRiga2)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtRiga1)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(525, 186)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Stampa Etichette"
        '
        'txtQta
        '
        Me.txtQta.Location = New System.Drawing.Point(109, 149)
        Me.txtQta.MaxLength = 4
        Me.txtQta.My_AccettaNegativi = False
        Me.txtQta.My_AllowOnlyInteger = False
        Me.txtQta.My_DefaultValue = 1
        Me.txtQta.My_MaxValue = 9999.0!
        Me.txtQta.My_MinValue = 1.0!
        Me.txtQta.My_ReplaceWithDefaultValue = True
        Me.txtQta.Name = "txtQta"
        Me.txtQta.Size = New System.Drawing.Size(45, 20)
        Me.txtQta.TabIndex = 23
        Me.txtQta.Text = "1"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(10, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Quantità"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(10, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Riga 3"
        '
        'txtRiga3
        '
        Me.txtRiga3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtRiga3.Location = New System.Drawing.Point(109, 111)
        Me.txtRiga3.MaxLength = 200
        Me.txtRiga3.Name = "txtRiga3"
        Me.txtRiga3.Size = New System.Drawing.Size(303, 20)
        Me.txtRiga3.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Riga 2"
        '
        'txtRiga2
        '
        Me.txtRiga2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtRiga2.Location = New System.Drawing.Point(109, 84)
        Me.txtRiga2.MaxLength = 200
        Me.txtRiga2.Name = "txtRiga2"
        Me.txtRiga2.Size = New System.Drawing.Size(303, 20)
        Me.txtRiga2.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(10, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Riga 1"
        '
        'txtRiga1
        '
        Me.txtRiga1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtRiga1.Location = New System.Drawing.Point(109, 57)
        Me.txtRiga1.MaxLength = 200
        Me.txtRiga1.Name = "txtRiga1"
        Me.txtRiga1.Size = New System.Drawing.Size(303, 20)
        Me.txtRiga1.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Etichetta
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
        Me.lblTipo.Size = New System.Drawing.Size(140, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Stampa Etichette"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PictureBox3)
        Me.TabPage1.Controls.Add(Me.lblEtichetteStampate)
        Me.TabPage1.Controls.Add(Me.txtNumeroPacchi)
        Me.TabPage1.Controls.Add(Me.txtFineNumerazione)
        Me.TabPage1.Controls.Add(Me.txtInizioNumerazione)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.PictureBox2)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(525, 186)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Stampa Etichette Collo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblEtichetteStampate
        '
        Me.lblEtichetteStampate.AutoSize = True
        Me.lblEtichetteStampate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblEtichetteStampate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblEtichetteStampate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEtichetteStampate.Location = New System.Drawing.Point(43, 155)
        Me.lblEtichetteStampate.Name = "lblEtichetteStampate"
        Me.lblEtichetteStampate.Size = New System.Drawing.Size(165, 15)
        Me.lblEtichetteStampate.TabIndex = 30
        Me.lblEtichetteStampate.Text = "Verranno stampate - etichette"
        '
        'txtNumeroPacchi
        '
        Me.txtNumeroPacchi.Location = New System.Drawing.Point(176, 111)
        Me.txtNumeroPacchi.MaxLength = 6
        Me.txtNumeroPacchi.My_AccettaNegativi = False
        Me.txtNumeroPacchi.My_AllowOnlyInteger = False
        Me.txtNumeroPacchi.My_DefaultValue = 1
        Me.txtNumeroPacchi.My_MaxValue = 999999.0!
        Me.txtNumeroPacchi.My_MinValue = 1.0!
        Me.txtNumeroPacchi.My_ReplaceWithDefaultValue = True
        Me.txtNumeroPacchi.Name = "txtNumeroPacchi"
        Me.txtNumeroPacchi.Size = New System.Drawing.Size(99, 20)
        Me.txtNumeroPacchi.TabIndex = 29
        Me.txtNumeroPacchi.Text = "1"
        Me.txtNumeroPacchi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFineNumerazione
        '
        Me.txtFineNumerazione.Location = New System.Drawing.Point(176, 84)
        Me.txtFineNumerazione.MaxLength = 8
        Me.txtFineNumerazione.My_AccettaNegativi = False
        Me.txtFineNumerazione.My_AllowOnlyInteger = False
        Me.txtFineNumerazione.My_DefaultValue = 1
        Me.txtFineNumerazione.My_MaxValue = 1.0E+8!
        Me.txtFineNumerazione.My_MinValue = 1.0!
        Me.txtFineNumerazione.My_ReplaceWithDefaultValue = True
        Me.txtFineNumerazione.Name = "txtFineNumerazione"
        Me.txtFineNumerazione.Size = New System.Drawing.Size(99, 20)
        Me.txtFineNumerazione.TabIndex = 28
        Me.txtFineNumerazione.Text = "1"
        Me.txtFineNumerazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInizioNumerazione
        '
        Me.txtInizioNumerazione.Location = New System.Drawing.Point(176, 57)
        Me.txtInizioNumerazione.MaxLength = 8
        Me.txtInizioNumerazione.My_AccettaNegativi = False
        Me.txtInizioNumerazione.My_AllowOnlyInteger = False
        Me.txtInizioNumerazione.My_DefaultValue = 1
        Me.txtInizioNumerazione.My_MaxValue = 1.0E+8!
        Me.txtInizioNumerazione.My_MinValue = 1.0!
        Me.txtInizioNumerazione.My_ReplaceWithDefaultValue = True
        Me.txtInizioNumerazione.Name = "txtInizioNumerazione"
        Me.txtInizioNumerazione.Size = New System.Drawing.Size(99, 20)
        Me.txtInizioNumerazione.TabIndex = 27
        Me.txtInizioNumerazione.Text = "1"
        Me.txtInizioNumerazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(10, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 15)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Numeri contenuti in un collo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(10, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 15)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Fine numerazione a"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(10, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 15)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Inizio numerazione da"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._Etichetta
        Me.PictureBox2.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(49, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 21)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Stampa Etichette Collo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(14, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Seleziona stampante"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Stampa
        Me.PictureBox1.Location = New System.Drawing.Point(135, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnStampa)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 271)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(533, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnStampa
        '
        Me.btnStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStampa.AutoSize = True
        Me.btnStampa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnStampa.FlatAppearance.BorderSize = 0
        Me.btnStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStampa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.btnStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampa.Location = New System.Drawing.Point(353, 12)
        Me.btnStampa.Name = "btnStampa"
        Me.btnStampa.Size = New System.Drawing.Size(90, 32)
        Me.btnStampa.TabIndex = 24
        Me.btnStampa.Text = "Stampa"
        Me.btnStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStampa.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbStampanti)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 214)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(533, 57)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stampa su..."
        '
        'cmbStampanti
        '
        Me.cmbStampanti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStampanti.FormattingEnabled = True
        Me.cmbStampanti.Location = New System.Drawing.Point(165, 22)
        Me.cmbStampanti.Name = "cmbStampanti"
        Me.cmbStampanti.Size = New System.Drawing.Size(362, 21)
        Me.cmbStampanti.TabIndex = 44
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources.info24
        Me.PictureBox3.Location = New System.Drawing.Point(13, 150)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 31
        Me.PictureBox3.TabStop = False
        '
        'frmStampaEtichette
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(533, 319)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Name = "frmStampaEtichette"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Stampa Etichette/Etichette Pacco"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRiga1 As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents btnStampa As Button
    Friend WithEvents txtQta As ucNumericTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRiga3 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRiga2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbStampanti As ComboBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNumeroPacchi As ucNumericTextBox
    Friend WithEvents txtFineNumerazione As ucNumericTextBox
    Friend WithEvents txtInizioNumerazione As ucNumericTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblEtichetteStampate As Label
    Friend WithEvents PictureBox3 As PictureBox
End Class
