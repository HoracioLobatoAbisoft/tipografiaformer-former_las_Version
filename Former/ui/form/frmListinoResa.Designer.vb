<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoResa
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtScarto = New Former.ucNumericTextBox()
        Me.txtResa = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFormatoMacchina = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFormatoCarta = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 239)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(421, 48)
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
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(379, 12)
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
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.Location = New System.Drawing.Point(345, 12)
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
        Me.TabMain.Size = New System.Drawing.Size(421, 239)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtScarto)
        Me.tbProd.Controls.Add(Me.txtResa)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.cmbFormatoMacchina)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbFormatoCarta)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(413, 213)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Resa"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(29, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Scarto (%)"
        '
        'txtScarto
        '
        Me.txtScarto.My_AccettaNegativi = False
        Me.txtScarto.My_DefaultValue = 0
        Me.txtScarto.Location = New System.Drawing.Point(143, 140)
        Me.txtScarto.MaxLength = 2
        Me.txtScarto.My_MaxValue = 99.0!
        Me.txtScarto.My_MinValue = 0!
        Me.txtScarto.Name = "txtScarto"
        Me.txtScarto.My_AllowOnlyInteger = True
        Me.txtScarto.My_ReplaceWithDefaultValue = True
        Me.txtScarto.Size = New System.Drawing.Size(75, 20)
        Me.txtScarto.TabIndex = 22
        Me.txtScarto.Text = "0"
        Me.txtScarto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtResa
        '
        Me.txtResa.My_AccettaNegativi = False
        Me.txtResa.My_DefaultValue = 0
        Me.txtResa.Location = New System.Drawing.Point(143, 113)
        Me.txtResa.MaxLength = 3
        Me.txtResa.My_MaxValue = 100.0!
        Me.txtResa.My_MinValue = 0!
        Me.txtResa.Name = "txtResa"
        Me.txtResa.My_AllowOnlyInteger = True
        Me.txtResa.My_ReplaceWithDefaultValue = True
        Me.txtResa.Size = New System.Drawing.Size(75, 20)
        Me.txtResa.TabIndex = 21
        Me.txtResa.Text = "0"
        Me.txtResa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Resa"
        '
        'cmbFormatoMacchina
        '
        Me.cmbFormatoMacchina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormatoMacchina.FormattingEnabled = True
        Me.cmbFormatoMacchina.Location = New System.Drawing.Point(143, 84)
        Me.cmbFormatoMacchina.Name = "cmbFormatoMacchina"
        Me.cmbFormatoMacchina.Size = New System.Drawing.Size(262, 21)
        Me.cmbFormatoMacchina.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Formato Macchina"
        '
        'cmbFormatoCarta
        '
        Me.cmbFormatoCarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormatoCarta.FormattingEnabled = True
        Me.cmbFormatoCarta.Location = New System.Drawing.Point(143, 55)
        Me.cmbFormatoCarta.Name = "cmbFormatoCarta"
        Me.cmbFormatoCarta.Size = New System.Drawing.Size(262, 21)
        Me.cmbFormatoCarta.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(29, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Formato Carta"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Resa
        Me.pctTipo.Location = New System.Drawing.Point(19, 14)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(26, 26)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(60, 18)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(45, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Resa"
        '
        'frmListinoResa
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(421, 287)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoResa"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Resa"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
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
    Friend WithEvents cmbFormatoCarta As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbFormatoMacchina As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtScarto As ucNumericTextBox
    Friend WithEvents txtResa As ucNumericTextBox
End Class
