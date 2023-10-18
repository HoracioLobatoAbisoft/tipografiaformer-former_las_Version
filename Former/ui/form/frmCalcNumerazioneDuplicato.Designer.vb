<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCalcNumerazioneDuplicato
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblOrient = New System.Windows.Forms.Label()
        Me.chkRuota = New System.Windows.Forms.CheckBox()
        Me.cmbFont = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtGrandezzaFont = New Former.ucNumericTextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtSuffisso = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPrefisso = New System.Windows.Forms.TextBox()
        Me.txtBassoX = New Former.ucNumericTextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtBassoY = New Former.ucNumericTextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 286)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(662, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(578, 12)
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
        Me.btnOk.Location = New System.Drawing.Point(496, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(76, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.TabMain.Size = New System.Drawing.Size(662, 286)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblY)
        Me.tbProd.Controls.Add(Me.lblX)
        Me.tbProd.Controls.Add(Me.PictureBox2)
        Me.tbProd.Controls.Add(Me.lblOrient)
        Me.tbProd.Controls.Add(Me.chkRuota)
        Me.tbProd.Controls.Add(Me.cmbFont)
        Me.tbProd.Controls.Add(Me.Label39)
        Me.tbProd.Controls.Add(Me.txtGrandezzaFont)
        Me.tbProd.Controls.Add(Me.Label40)
        Me.tbProd.Controls.Add(Me.Label35)
        Me.tbProd.Controls.Add(Me.txtSuffisso)
        Me.tbProd.Controls.Add(Me.Label21)
        Me.tbProd.Controls.Add(Me.txtPrefisso)
        Me.tbProd.Controls.Add(Me.txtBassoX)
        Me.tbProd.Controls.Add(Me.Label28)
        Me.tbProd.Controls.Add(Me.txtBassoY)
        Me.tbProd.Controls.Add(Me.Label30)
        Me.tbProd.Controls.Add(Me.Label31)
        Me.tbProd.Controls.Add(Me.Label32)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(654, 260)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Duplicato Numerazione"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblY.ForeColor = System.Drawing.Color.Red
        Me.lblY.Location = New System.Drawing.Point(104, 236)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(14, 15)
        Me.lblY.TabIndex = 172
        Me.lblY.Text = "Y"
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX.ForeColor = System.Drawing.Color.Red
        Me.lblX.Location = New System.Drawing.Point(41, 197)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(15, 15)
        Me.lblX.TabIndex = 171
        Me.lblX.Text = "X"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources.biglietti
        Me.PictureBox2.Location = New System.Drawing.Point(53, 57)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(255, 182)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 90
        Me.PictureBox2.TabStop = False
        '
        'lblOrient
        '
        Me.lblOrient.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOrient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrient.Location = New System.Drawing.Point(484, 206)
        Me.lblOrient.Name = "lblOrient"
        Me.lblOrient.Size = New System.Drawing.Size(47, 19)
        Me.lblOrient.TabIndex = 89
        Me.lblOrient.Text = "90"
        Me.lblOrient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkRuota
        '
        Me.chkRuota.AutoSize = True
        Me.chkRuota.Location = New System.Drawing.Point(328, 207)
        Me.chkRuota.Name = "chkRuota"
        Me.chkRuota.Size = New System.Drawing.Size(104, 19)
        Me.chkRuota.TabIndex = 88
        Me.chkRuota.Text = "Ruota Verticale"
        Me.chkRuota.UseVisualStyleBackColor = True
        '
        'cmbFont
        '
        Me.cmbFont.FormattingEnabled = True
        Me.cmbFont.Location = New System.Drawing.Point(397, 57)
        Me.cmbFont.Name = "cmbFont"
        Me.cmbFont.Size = New System.Drawing.Size(134, 21)
        Me.cmbFont.TabIndex = 87
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(538, 61)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(61, 15)
        Me.Label39.TabIndex = 86
        Me.Label39.Text = "Grandezza"
        '
        'txtGrandezzaFont
        '
        Me.txtGrandezzaFont.My_AccettaNegativi = False
        Me.txtGrandezzaFont.My_DefaultValue = 100
        Me.txtGrandezzaFont.Location = New System.Drawing.Point(609, 58)
        Me.txtGrandezzaFont.MaxLength = 2
        Me.txtGrandezzaFont.My_MaxValue = 99.0!
        Me.txtGrandezzaFont.My_MinValue = 1.0!
        Me.txtGrandezzaFont.Name = "txtGrandezzaFont"
        Me.txtGrandezzaFont.My_AllowOnlyInteger = True
        Me.txtGrandezzaFont.My_ReplaceWithDefaultValue = True
        Me.txtGrandezzaFont.Size = New System.Drawing.Size(20, 20)
        Me.txtGrandezzaFont.TabIndex = 84
        Me.txtGrandezzaFont.Text = "12"
        Me.txtGrandezzaFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(323, 60)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(67, 15)
        Me.Label40.TabIndex = 85
        Me.Label40.Text = "Nome Font"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(325, 181)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(48, 15)
        Me.Label35.TabIndex = 83
        Me.Label35.Text = "Suffisso"
        '
        'txtSuffisso
        '
        Me.txtSuffisso.Location = New System.Drawing.Point(484, 178)
        Me.txtSuffisso.Name = "txtSuffisso"
        Me.txtSuffisso.Size = New System.Drawing.Size(47, 20)
        Me.txtSuffisso.TabIndex = 69
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(325, 154)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 15)
        Me.Label21.TabIndex = 82
        Me.Label21.Text = "Prefisso"
        '
        'txtPrefisso
        '
        Me.txtPrefisso.Location = New System.Drawing.Point(484, 151)
        Me.txtPrefisso.Name = "txtPrefisso"
        Me.txtPrefisso.Size = New System.Drawing.Size(47, 20)
        Me.txtPrefisso.TabIndex = 68
        Me.txtPrefisso.Text = "N° "
        '
        'txtBassoX
        '
        Me.txtBassoX.My_AccettaNegativi = False
        Me.txtBassoX.My_DefaultValue = 100
        Me.txtBassoX.Location = New System.Drawing.Point(484, 92)
        Me.txtBassoX.My_MaxValue = 1.0E+10!
        Me.txtBassoX.My_MinValue = 1.0!
        Me.txtBassoX.Name = "txtBassoX"
        Me.txtBassoX.My_AllowOnlyInteger = False
        Me.txtBassoX.My_ReplaceWithDefaultValue = True
        Me.txtBassoX.Size = New System.Drawing.Size(47, 20)
        Me.txtBassoX.TabIndex = 64
        Me.txtBassoX.Text = "70"
        Me.txtBassoX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(325, 95)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(140, 15)
        Me.Label28.TabIndex = 74
        Me.Label28.Text = "Primo Angolo Basso SX X"
        '
        'txtBassoY
        '
        Me.txtBassoY.My_AccettaNegativi = False
        Me.txtBassoY.My_DefaultValue = 100
        Me.txtBassoY.Location = New System.Drawing.Point(484, 119)
        Me.txtBassoY.My_MaxValue = 1.0E+10!
        Me.txtBassoY.My_MinValue = 1.0!
        Me.txtBassoY.Name = "txtBassoY"
        Me.txtBassoY.My_AllowOnlyInteger = False
        Me.txtBassoY.My_ReplaceWithDefaultValue = True
        Me.txtBassoY.Size = New System.Drawing.Size(47, 20)
        Me.txtBassoY.TabIndex = 65
        Me.txtBassoY.Text = "30"
        Me.txtBassoY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Red
        Me.Label30.Location = New System.Drawing.Point(325, 122)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(140, 15)
        Me.Label30.TabIndex = 75
        Me.Label30.Text = "Primo Angolo Basso SX Y"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(537, 122)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(92, 15)
        Me.Label31.TabIndex = 77
        Me.Label31.Text = "(mm) dal basso "
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(537, 95)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(92, 15)
        Me.Label32.TabIndex = 76
        Me.Label32.Text = "(mm) dal basso "
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.calendar2
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
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(193, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Duplicato Numerazione"
        '
        'frmCalcNumerazioneDuplicato
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(662, 334)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCalcNumerazioneDuplicato"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Duplicato Numerazione"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblOrient As Label
    Friend WithEvents chkRuota As CheckBox
    Friend WithEvents cmbFont As ComboBox
    Friend WithEvents Label39 As Label
    Friend WithEvents txtGrandezzaFont As ucNumericTextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents txtSuffisso As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtPrefisso As TextBox
    Friend WithEvents txtBassoX As ucNumericTextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtBassoY As ucNumericTextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblY As Label
    Friend WithEvents lblX As Label
End Class
