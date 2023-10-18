<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormatoProdsuModCom
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
        Me.cmbOrientamento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRangeMax = New Former.ucNumericTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRangeMin = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumSpazi = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFormatoProdotto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 215)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(414, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(372, 12)
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
        Me.btnOk.Location = New System.Drawing.Point(338, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(414, 215)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.cmbOrientamento)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtRangeMax)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtRangeMin)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtNumSpazi)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.cmbFormatoProdotto)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(406, 189)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Formato Prodotto su Modello Commessa"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'cmbOrientamento
        '
        Me.cmbOrientamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrientamento.FormattingEnabled = True
        Me.cmbOrientamento.Items.AddRange(New Object() {"Orizzontale", "Verticale", "Neutro"})
        Me.cmbOrientamento.Location = New System.Drawing.Point(143, 151)
        Me.cmbOrientamento.Name = "cmbOrientamento"
        Me.cmbOrientamento.Size = New System.Drawing.Size(249, 21)
        Me.cmbOrientamento.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(29, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 15)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Orientamento"
        '
        'txtRangeMax
        '
        Me.txtRangeMax.My_AccettaNegativi = False
        Me.txtRangeMax.My_DefaultValue = 1
        Me.txtRangeMax.Location = New System.Drawing.Point(330, 124)
        Me.txtRangeMax.My_MaxValue = 1.0E+9!
        Me.txtRangeMax.My_MinValue = 1.0!
        Me.txtRangeMax.Name = "txtRangeMax"
        Me.txtRangeMax.My_AllowOnlyInteger = True
        Me.txtRangeMax.My_ReplaceWithDefaultValue = True
        Me.txtRangeMax.Size = New System.Drawing.Size(62, 20)
        Me.txtRangeMax.TabIndex = 25
        Me.txtRangeMax.Text = "1"
        Me.txtRangeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(216, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Posizioni Max"
        '
        'txtRangeMin
        '
        Me.txtRangeMin.My_AccettaNegativi = False
        Me.txtRangeMin.My_DefaultValue = 1
        Me.txtRangeMin.Location = New System.Drawing.Point(143, 124)
        Me.txtRangeMin.My_MaxValue = 1.0E+9!
        Me.txtRangeMin.My_MinValue = 1.0!
        Me.txtRangeMin.Name = "txtRangeMin"
        Me.txtRangeMin.My_AllowOnlyInteger = True
        Me.txtRangeMin.My_ReplaceWithDefaultValue = True
        Me.txtRangeMin.Size = New System.Drawing.Size(62, 20)
        Me.txtRangeMin.TabIndex = 23
        Me.txtRangeMin.Text = "1"
        Me.txtRangeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(29, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Posizioni Min"
        '
        'txtNumSpazi
        '
        Me.txtNumSpazi.My_AccettaNegativi = False
        Me.txtNumSpazi.My_DefaultValue = 1
        Me.txtNumSpazi.Location = New System.Drawing.Point(143, 97)
        Me.txtNumSpazi.My_MaxValue = 1.0E+9!
        Me.txtNumSpazi.My_MinValue = 1.0!
        Me.txtNumSpazi.Name = "txtNumSpazi"
        Me.txtNumSpazi.My_AllowOnlyInteger = True
        Me.txtNumSpazi.My_ReplaceWithDefaultValue = True
        Me.txtNumSpazi.Size = New System.Drawing.Size(62, 20)
        Me.txtNumSpazi.TabIndex = 21
        Me.txtNumSpazi.Text = "1"
        Me.txtNumSpazi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Spazi"
        '
        'cmbFormatoProdotto
        '
        Me.cmbFormatoProdotto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormatoProdotto.FormattingEnabled = True
        Me.cmbFormatoProdotto.Location = New System.Drawing.Point(143, 68)
        Me.cmbFormatoProdotto.Name = "cmbFormatoProdotto"
        Me.cmbFormatoProdotto.Size = New System.Drawing.Size(249, 21)
        Me.cmbFormatoProdotto.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Formato Prodotto"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.File_New
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(48, 48)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
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
        Me.lblTipo.Size = New System.Drawing.Size(146, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Formato Prodotto"
        '
        'frmFormatoProdsuModCom
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(419, 268)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFormatoProdsuModCom"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
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
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbFormatoProdotto As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumSpazi As ucNumericTextBox
    Friend WithEvents txtRangeMax As ucNumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRangeMin As ucNumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbOrientamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
