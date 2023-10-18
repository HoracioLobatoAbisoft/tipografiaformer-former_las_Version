<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoFormatoMacchina
    Inherits baseFormInternaFixed

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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UcPictureWizard = New Former.ucPictureWizard()
        Me.pctImgLav = New System.Windows.Forms.PictureBox()
        Me.txtImgLav = New System.Windows.Forms.TextBox()
        Me.grpMacchinari = New System.Windows.Forms.GroupBox()
        Me.chkMacchinari = New System.Windows.Forms.CheckedListBox()
        Me.btmMacch = New System.Windows.Forms.Button()
        Me.cmbMacchinari = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCostoLastra = New Former.ucNumericTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLarghezza = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDivisioneFoglio = New Former.ucNumericTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtLunghezza = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFormato = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpImpatto = New System.Windows.Forms.TabPage()
        Me.UcListinoImpatto = New Former.ucListinoImpatto()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMacchinari.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpImpatto.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 559)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(726, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(690, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnOk.Location = New System.Drawing.Point(654, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 6
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpImpatto)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(726, 559)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.UcPictureWizard)
        Me.tbProd.Controls.Add(Me.grpMacchinari)
        Me.tbProd.Controls.Add(Me.btmMacch)
        Me.tbProd.Controls.Add(Me.cmbMacchinari)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtCostoLastra)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtLarghezza)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.txtDivisioneFoglio)
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.txtLunghezza)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtFormato)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.btnSearch)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.txtImgLav)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.pctImgLav)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(718, 533)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former -Formato Macchina"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(50, 506)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(532, 15)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "* Il costo lastra è espresso per il calcolo dei costi di produzione ma non è lega" &
    "to al costo delle risorse"
        '
        'UcPictureWizard
        '
        Me.UcPictureWizard.AutoSize = True
        Me.UcPictureWizard.ImgHeight = 128
        Me.UcPictureWizard.ImgWidth = 128
        Me.UcPictureWizard.Location = New System.Drawing.Point(469, 107)
        Me.UcPictureWizard.Name = "UcPictureWizard"
        Me.UcPictureWizard.PrefissoDaApplicare = ""
        Me.UcPictureWizard.RifPictureBox = Me.pctImgLav
        Me.UcPictureWizard.RifTextBoxPath = Me.txtImgLav
        Me.UcPictureWizard.Size = New System.Drawing.Size(77, 23)
        Me.UcPictureWizard.TabIndex = 5
        '
        'pctImgLav
        '
        Me.pctImgLav.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctImgLav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgLav.Location = New System.Drawing.Point(569, 32)
        Me.pctImgLav.Name = "pctImgLav"
        Me.pctImgLav.Size = New System.Drawing.Size(128, 128)
        Me.pctImgLav.TabIndex = 57
        Me.pctImgLav.TabStop = False
        '
        'txtImgLav
        '
        Me.txtImgLav.Location = New System.Drawing.Point(164, 109)
        Me.txtImgLav.MaxLength = 50
        Me.txtImgLav.Name = "txtImgLav"
        Me.txtImgLav.ReadOnly = True
        Me.txtImgLav.Size = New System.Drawing.Size(267, 20)
        Me.txtImgLav.TabIndex = 59
        '
        'grpMacchinari
        '
        Me.grpMacchinari.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMacchinari.Controls.Add(Me.chkMacchinari)
        Me.grpMacchinari.Location = New System.Drawing.Point(53, 136)
        Me.grpMacchinari.Name = "grpMacchinari"
        Me.grpMacchinari.Size = New System.Drawing.Size(509, 358)
        Me.grpMacchinari.TabIndex = 105
        Me.grpMacchinari.TabStop = False
        Me.grpMacchinari.Tag = "Macchinari assegnati"
        Me.grpMacchinari.Text = "Macchinari assegnati (0)"
        '
        'chkMacchinari
        '
        Me.chkMacchinari.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMacchinari.CheckOnClick = True
        Me.chkMacchinari.FormattingEnabled = True
        Me.chkMacchinari.Location = New System.Drawing.Point(6, 20)
        Me.chkMacchinari.Name = "chkMacchinari"
        Me.chkMacchinari.Size = New System.Drawing.Size(497, 328)
        Me.chkMacchinari.TabIndex = 56
        '
        'btmMacch
        '
        Me.btmMacch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btmMacch.Location = New System.Drawing.Point(681, 478)
        Me.btmMacch.Name = "btmMacch"
        Me.btmMacch.Size = New System.Drawing.Size(26, 23)
        Me.btmMacch.TabIndex = 104
        Me.btmMacch.Text = "..."
        Me.btmMacch.UseVisualStyleBackColor = True
        Me.btmMacch.Visible = False
        '
        'cmbMacchinari
        '
        Me.cmbMacchinari.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMacchinari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMacchinari.FormattingEnabled = True
        Me.cmbMacchinari.Items.AddRange(New Object() {"Orizzontale", "Verticale"})
        Me.cmbMacchinari.Location = New System.Drawing.Point(628, 479)
        Me.cmbMacchinari.Name = "cmbMacchinari"
        Me.cmbMacchinari.Size = New System.Drawing.Size(50, 21)
        Me.cmbMacchinari.TabIndex = 103
        Me.cmbMacchinari.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(583, 479)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 15)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "Macchinario"
        Me.Label5.Visible = False
        '
        'txtCostoLastra
        '
        Me.txtCostoLastra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCostoLastra.Location = New System.Drawing.Point(381, 52)
        Me.txtCostoLastra.MaxLength = 6
        Me.txtCostoLastra.My_AccettaNegativi = False
        Me.txtCostoLastra.My_AllowOnlyInteger = False
        Me.txtCostoLastra.My_DefaultValue = 0
        Me.txtCostoLastra.My_MaxValue = 1000.0!
        Me.txtCostoLastra.My_MinValue = 0!
        Me.txtCostoLastra.My_ReplaceWithDefaultValue = True
        Me.txtCostoLastra.Name = "txtCostoLastra"
        Me.txtCostoLastra.Size = New System.Drawing.Size(82, 20)
        Me.txtCostoLastra.TabIndex = 1
        Me.txtCostoLastra.Text = "0"
        Me.txtCostoLastra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(288, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Costo Lastra *"
        '
        'txtLarghezza
        '
        Me.txtLarghezza.Location = New System.Drawing.Point(381, 82)
        Me.txtLarghezza.My_AccettaNegativi = False
        Me.txtLarghezza.My_AllowOnlyInteger = False
        Me.txtLarghezza.My_DefaultValue = 1
        Me.txtLarghezza.My_MaxValue = 1.0E+10!
        Me.txtLarghezza.My_MinValue = -1.0E+9!
        Me.txtLarghezza.My_ReplaceWithDefaultValue = True
        Me.txtLarghezza.Name = "txtLarghezza"
        Me.txtLarghezza.Size = New System.Drawing.Size(82, 20)
        Me.txtLarghezza.TabIndex = 3
        Me.txtLarghezza.Text = "1"
        Me.txtLarghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(288, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 15)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Larghezza (cm)"
        '
        'txtDivisioneFoglio
        '
        Me.txtDivisioneFoglio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDivisioneFoglio.Location = New System.Drawing.Point(625, 451)
        Me.txtDivisioneFoglio.My_AccettaNegativi = False
        Me.txtDivisioneFoglio.My_AllowOnlyInteger = True
        Me.txtDivisioneFoglio.My_DefaultValue = 0
        Me.txtDivisioneFoglio.My_MaxValue = 1.0E+10!
        Me.txtDivisioneFoglio.My_MinValue = -1.0E+9!
        Me.txtDivisioneFoglio.My_ReplaceWithDefaultValue = True
        Me.txtDivisioneFoglio.Name = "txtDivisioneFoglio"
        Me.txtDivisioneFoglio.Size = New System.Drawing.Size(82, 20)
        Me.txtDivisioneFoglio.TabIndex = 84
        Me.txtDivisioneFoglio.Text = "0"
        Me.txtDivisioneFoglio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDivisioneFoglio.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._FormatoMacchina
        Me.PictureBox1.Location = New System.Drawing.Point(17, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 83
        Me.PictureBox1.TabStop = False
        '
        'txtLunghezza
        '
        Me.txtLunghezza.Location = New System.Drawing.Point(164, 82)
        Me.txtLunghezza.My_AccettaNegativi = False
        Me.txtLunghezza.My_AllowOnlyInteger = False
        Me.txtLunghezza.My_DefaultValue = 1
        Me.txtLunghezza.My_MaxValue = 1.0E+10!
        Me.txtLunghezza.My_MinValue = -1.0E+9!
        Me.txtLunghezza.My_ReplaceWithDefaultValue = True
        Me.txtLunghezza.Name = "txtLunghezza"
        Me.txtLunghezza.Size = New System.Drawing.Size(82, 20)
        Me.txtLunghezza.TabIndex = 2
        Me.txtLunghezza.Text = "1"
        Me.txtLunghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Formato"
        '
        'txtFormato
        '
        Me.txtFormato.Location = New System.Drawing.Point(164, 55)
        Me.txtFormato.MaxLength = 50
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.Size = New System.Drawing.Size(82, 20)
        Me.txtFormato.TabIndex = 0
        Me.txtFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Lunghezza (cm)"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(437, 109)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 21)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(50, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Immagine"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(583, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 18)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "(128px - 128px)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(580, 433)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Divisione Foglio"
        Me.Label7.Visible = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(152, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Formato Macchina"
        '
        'tpImpatto
        '
        Me.tpImpatto.Controls.Add(Me.UcListinoImpatto)
        Me.tpImpatto.Location = New System.Drawing.Point(4, 22)
        Me.tpImpatto.Name = "tpImpatto"
        Me.tpImpatto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpImpatto.Size = New System.Drawing.Size(718, 533)
        Me.tpImpatto.TabIndex = 1
        Me.tpImpatto.Text = "Influisce su..."
        Me.tpImpatto.UseVisualStyleBackColor = True
        '
        'UcListinoImpatto
        '
        Me.UcListinoImpatto.BackColor = System.Drawing.Color.White
        Me.UcListinoImpatto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcListinoImpatto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcListinoImpatto.Location = New System.Drawing.Point(3, 3)
        Me.UcListinoImpatto.Name = "UcListinoImpatto"
        Me.UcListinoImpatto.Size = New System.Drawing.Size(712, 527)
        Me.UcListinoImpatto.TabIndex = 0
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'frmListinoFormatoMacchina
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(726, 607)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoFormatoMacchina"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Formato Macchina"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMacchinari.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpImpatto.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pctImgLav As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtImgLav As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFormato As System.Windows.Forms.TextBox
    Friend WithEvents txtLunghezza As ucNumericTextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtDivisioneFoglio As ucNumericTextBox
    Friend WithEvents txtLarghezza As ucNumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCostoLastra As ucNumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMacchinari As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btmMacch As System.Windows.Forms.Button
    Friend WithEvents tpImpatto As System.Windows.Forms.TabPage
    Friend WithEvents UcListinoImpatto As Former.ucListinoImpatto
    Friend WithEvents grpMacchinari As GroupBox
    Friend WithEvents chkMacchinari As CheckedListBox
    Friend WithEvents UcPictureWizard As ucPictureWizard
    Friend WithEvents Label6 As Label
End Class
