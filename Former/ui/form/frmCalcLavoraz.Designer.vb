<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcLavoraz
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtMinFogli = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQ6 = New Former.ucNumericTextBox()
        Me.txtQ5 = New Former.ucNumericTextBox()
        Me.txtQ4 = New Former.ucNumericTextBox()
        Me.txtQ3 = New Former.ucNumericTextBox()
        Me.txtQ2 = New Former.ucNumericTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtQ1 = New Former.ucNumericTextBox()
        Me.txtV6 = New Former.ucNumericTextBox()
        Me.txtV5 = New Former.ucNumericTextBox()
        Me.txtV4 = New Former.ucNumericTextBox()
        Me.txtV3 = New Former.ucNumericTextBox()
        Me.txtV2 = New Former.ucNumericTextBox()
        Me.txtV1 = New Former.ucNumericTextBox()
        Me.tvwListLavOpz = New System.Windows.Forms.TreeView()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 496)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(913, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 34)
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
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.Location = New System.Drawing.Point(879, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 496)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label20)
        Me.tbProd.Controls.Add(Me.txtMinFogli)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtQ6)
        Me.tbProd.Controls.Add(Me.txtQ5)
        Me.tbProd.Controls.Add(Me.txtQ4)
        Me.tbProd.Controls.Add(Me.txtQ3)
        Me.tbProd.Controls.Add(Me.txtQ2)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.txtQ1)
        Me.tbProd.Controls.Add(Me.txtV6)
        Me.tbProd.Controls.Add(Me.txtV5)
        Me.tbProd.Controls.Add(Me.txtV4)
        Me.tbProd.Controls.Add(Me.txtV3)
        Me.tbProd.Controls.Add(Me.txtV2)
        Me.tbProd.Controls.Add(Me.txtV1)
        Me.tbProd.Controls.Add(Me.tvwListLavOpz)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 470)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Calcolo Lavorazioni"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Orange
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(50, 54)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 15)
        Me.Label20.TabIndex = 159
        Me.Label20.Text = "Min Fogli"
        '
        'txtMinFogli
        '
        Me.txtMinFogli.My_AccettaNegativi = False
        Me.txtMinFogli.My_DefaultValue = 1
        Me.txtMinFogli.Location = New System.Drawing.Point(112, 51)
        Me.txtMinFogli.MaxLength = 5
        Me.txtMinFogli.My_MaxValue = 10000.0!
        Me.txtMinFogli.My_MinValue = 1.0!
        Me.txtMinFogli.Name = "txtMinFogli"
        Me.txtMinFogli.My_AllowOnlyInteger = True
        Me.txtMinFogli.My_ReplaceWithDefaultValue = True
        Me.txtMinFogli.Size = New System.Drawing.Size(66, 20)
        Me.txtMinFogli.TabIndex = 158
        Me.txtMinFogli.Text = "1"
        Me.txtMinFogli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(219, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Prezzo mercato"
        '
        'txtQ6
        '
        Me.txtQ6.My_AccettaNegativi = False
        Me.txtQ6.My_DefaultValue = 1
        Me.txtQ6.Location = New System.Drawing.Point(815, 51)
        Me.txtQ6.MaxLength = 50
        Me.txtQ6.My_MaxValue = 1.0E+10!
        Me.txtQ6.My_MinValue = 1.0!
        Me.txtQ6.Name = "txtQ6"
        Me.txtQ6.My_AllowOnlyInteger = True
        Me.txtQ6.ReadOnly = True
        Me.txtQ6.My_ReplaceWithDefaultValue = True
        Me.txtQ6.Size = New System.Drawing.Size(69, 20)
        Me.txtQ6.TabIndex = 149
        Me.txtQ6.Text = "50000"
        Me.txtQ6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQ5
        '
        Me.txtQ5.My_AccettaNegativi = False
        Me.txtQ5.My_DefaultValue = 1
        Me.txtQ5.Location = New System.Drawing.Point(727, 51)
        Me.txtQ5.MaxLength = 50
        Me.txtQ5.My_MaxValue = 1.0E+10!
        Me.txtQ5.My_MinValue = 1.0!
        Me.txtQ5.Name = "txtQ5"
        Me.txtQ5.My_AllowOnlyInteger = True
        Me.txtQ5.ReadOnly = True
        Me.txtQ5.My_ReplaceWithDefaultValue = True
        Me.txtQ5.Size = New System.Drawing.Size(69, 20)
        Me.txtQ5.TabIndex = 148
        Me.txtQ5.Text = "10000"
        Me.txtQ5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQ4
        '
        Me.txtQ4.My_AccettaNegativi = False
        Me.txtQ4.My_DefaultValue = 1
        Me.txtQ4.Location = New System.Drawing.Point(639, 51)
        Me.txtQ4.MaxLength = 50
        Me.txtQ4.My_MaxValue = 1.0E+10!
        Me.txtQ4.My_MinValue = 1.0!
        Me.txtQ4.Name = "txtQ4"
        Me.txtQ4.My_AllowOnlyInteger = True
        Me.txtQ4.ReadOnly = True
        Me.txtQ4.My_ReplaceWithDefaultValue = True
        Me.txtQ4.Size = New System.Drawing.Size(69, 20)
        Me.txtQ4.TabIndex = 147
        Me.txtQ4.Text = "5000"
        Me.txtQ4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQ3
        '
        Me.txtQ3.My_AccettaNegativi = False
        Me.txtQ3.My_DefaultValue = 1
        Me.txtQ3.Location = New System.Drawing.Point(551, 51)
        Me.txtQ3.MaxLength = 50
        Me.txtQ3.My_MaxValue = 1.0E+10!
        Me.txtQ3.My_MinValue = 1.0!
        Me.txtQ3.Name = "txtQ3"
        Me.txtQ3.My_AllowOnlyInteger = True
        Me.txtQ3.ReadOnly = True
        Me.txtQ3.My_ReplaceWithDefaultValue = True
        Me.txtQ3.Size = New System.Drawing.Size(69, 20)
        Me.txtQ3.TabIndex = 146
        Me.txtQ3.Text = "2000"
        Me.txtQ3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQ2
        '
        Me.txtQ2.My_AccettaNegativi = False
        Me.txtQ2.My_DefaultValue = 1
        Me.txtQ2.Location = New System.Drawing.Point(463, 51)
        Me.txtQ2.MaxLength = 50
        Me.txtQ2.My_MaxValue = 1.0E+10!
        Me.txtQ2.My_MinValue = 1.0!
        Me.txtQ2.Name = "txtQ2"
        Me.txtQ2.My_AllowOnlyInteger = True
        Me.txtQ2.ReadOnly = True
        Me.txtQ2.My_ReplaceWithDefaultValue = True
        Me.txtQ2.Size = New System.Drawing.Size(69, 20)
        Me.txtQ2.TabIndex = 145
        Me.txtQ2.Text = "1000"
        Me.txtQ2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(219, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 15)
        Me.Label12.TabIndex = 156
        Me.Label12.Text = "Quantità"
        '
        'txtQ1
        '
        Me.txtQ1.My_AccettaNegativi = False
        Me.txtQ1.My_DefaultValue = 1
        Me.txtQ1.Location = New System.Drawing.Point(374, 51)
        Me.txtQ1.MaxLength = 50
        Me.txtQ1.My_MaxValue = 1.0E+10!
        Me.txtQ1.My_MinValue = 1.0!
        Me.txtQ1.Name = "txtQ1"
        Me.txtQ1.My_AllowOnlyInteger = True
        Me.txtQ1.ReadOnly = True
        Me.txtQ1.My_ReplaceWithDefaultValue = True
        Me.txtQ1.Size = New System.Drawing.Size(69, 20)
        Me.txtQ1.TabIndex = 144
        Me.txtQ1.Text = "500"
        Me.txtQ1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtV6
        '
        Me.txtV6.My_AccettaNegativi = False
        Me.txtV6.My_DefaultValue = 0
        Me.txtV6.Location = New System.Drawing.Point(815, 78)
        Me.txtV6.MaxLength = 50
        Me.txtV6.My_MaxValue = 1.0E+10!
        Me.txtV6.My_MinValue = 0!
        Me.txtV6.Name = "txtV6"
        Me.txtV6.My_AllowOnlyInteger = False
        Me.txtV6.ReadOnly = True
        Me.txtV6.My_ReplaceWithDefaultValue = True
        Me.txtV6.Size = New System.Drawing.Size(69, 20)
        Me.txtV6.TabIndex = 155
        Me.txtV6.Text = "0"
        Me.txtV6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtV5
        '
        Me.txtV5.My_AccettaNegativi = False
        Me.txtV5.My_DefaultValue = 0
        Me.txtV5.Location = New System.Drawing.Point(727, 78)
        Me.txtV5.MaxLength = 50
        Me.txtV5.My_MaxValue = 1.0E+10!
        Me.txtV5.My_MinValue = 0!
        Me.txtV5.Name = "txtV5"
        Me.txtV5.My_AllowOnlyInteger = False
        Me.txtV5.ReadOnly = True
        Me.txtV5.My_ReplaceWithDefaultValue = True
        Me.txtV5.Size = New System.Drawing.Size(69, 20)
        Me.txtV5.TabIndex = 154
        Me.txtV5.Text = "0"
        Me.txtV5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtV4
        '
        Me.txtV4.My_AccettaNegativi = False
        Me.txtV4.My_DefaultValue = 0
        Me.txtV4.Location = New System.Drawing.Point(639, 78)
        Me.txtV4.MaxLength = 50
        Me.txtV4.My_MaxValue = 1.0E+10!
        Me.txtV4.My_MinValue = 0!
        Me.txtV4.Name = "txtV4"
        Me.txtV4.My_AllowOnlyInteger = False
        Me.txtV4.ReadOnly = True
        Me.txtV4.My_ReplaceWithDefaultValue = True
        Me.txtV4.Size = New System.Drawing.Size(69, 20)
        Me.txtV4.TabIndex = 153
        Me.txtV4.Text = "0"
        Me.txtV4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtV3
        '
        Me.txtV3.My_AccettaNegativi = False
        Me.txtV3.My_DefaultValue = 0
        Me.txtV3.Location = New System.Drawing.Point(551, 78)
        Me.txtV3.MaxLength = 50
        Me.txtV3.My_MaxValue = 1.0E+10!
        Me.txtV3.My_MinValue = 0!
        Me.txtV3.Name = "txtV3"
        Me.txtV3.My_AllowOnlyInteger = False
        Me.txtV3.ReadOnly = True
        Me.txtV3.My_ReplaceWithDefaultValue = True
        Me.txtV3.Size = New System.Drawing.Size(69, 20)
        Me.txtV3.TabIndex = 152
        Me.txtV3.Text = "0"
        Me.txtV3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtV2
        '
        Me.txtV2.My_AccettaNegativi = False
        Me.txtV2.My_DefaultValue = 0
        Me.txtV2.Location = New System.Drawing.Point(463, 78)
        Me.txtV2.MaxLength = 50
        Me.txtV2.My_MaxValue = 1.0E+10!
        Me.txtV2.My_MinValue = 0!
        Me.txtV2.Name = "txtV2"
        Me.txtV2.My_AllowOnlyInteger = False
        Me.txtV2.ReadOnly = True
        Me.txtV2.My_ReplaceWithDefaultValue = True
        Me.txtV2.Size = New System.Drawing.Size(69, 20)
        Me.txtV2.TabIndex = 151
        Me.txtV2.Text = "0"
        Me.txtV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtV1
        '
        Me.txtV1.My_AccettaNegativi = False
        Me.txtV1.My_DefaultValue = 0
        Me.txtV1.Location = New System.Drawing.Point(374, 78)
        Me.txtV1.MaxLength = 50
        Me.txtV1.My_MaxValue = 1.0E+10!
        Me.txtV1.My_MinValue = 0!
        Me.txtV1.Name = "txtV1"
        Me.txtV1.My_AllowOnlyInteger = False
        Me.txtV1.ReadOnly = True
        Me.txtV1.My_ReplaceWithDefaultValue = True
        Me.txtV1.Size = New System.Drawing.Size(69, 20)
        Me.txtV1.TabIndex = 150
        Me.txtV1.Text = "0"
        Me.txtV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tvwListLavOpz
        '
        Me.tvwListLavOpz.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwListLavOpz.CheckBoxes = True
        Me.tvwListLavOpz.Location = New System.Drawing.Point(53, 105)
        Me.tvwListLavOpz.Name = "tvwListLavOpz"
        Me.tvwListLavOpz.ShowNodeToolTips = True
        Me.tvwListLavOpz.Size = New System.Drawing.Size(886, 357)
        Me.tvwListLavOpz.TabIndex = 143
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Lavorazione
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
        Me.lblTipo.Size = New System.Drawing.Size(160, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Calcolo Lavorazioni"
        '
        'frmCalcLavoraz
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 544)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmCalcLavoraz"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Calcolo Lavorazioni"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
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
    Friend WithEvents tvwListLavOpz As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQ6 As ucNumericTextBox
    Friend WithEvents txtQ5 As ucNumericTextBox
    Friend WithEvents txtQ4 As ucNumericTextBox
    Friend WithEvents txtQ3 As ucNumericTextBox
    Friend WithEvents txtQ2 As ucNumericTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtQ1 As ucNumericTextBox
    Friend WithEvents txtV6 As ucNumericTextBox
    Friend WithEvents txtV5 As ucNumericTextBox
    Friend WithEvents txtV4 As ucNumericTextBox
    Friend WithEvents txtV3 As ucNumericTextBox
    Friend WithEvents txtV2 As ucNumericTextBox
    Friend WithEvents txtV1 As ucNumericTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtMinFogli As ucNumericTextBox
End Class
