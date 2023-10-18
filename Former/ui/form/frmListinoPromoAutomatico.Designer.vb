<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmListinoPromoAutomatico
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
        Me.chkAttivo = New System.Windows.Forms.CheckBox()
        Me.txtPercFatturatoMax = New Former.ucNumericTextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.txtPercPromo = New Former.ucNumericTextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.cmbLB = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 265)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(565, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(523, 12)
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
        Me.btnOk.Location = New System.Drawing.Point(489, 12)
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
        Me.TabMain.Size = New System.Drawing.Size(565, 265)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.chkAttivo)
        Me.tbProd.Controls.Add(Me.txtPercFatturatoMax)
        Me.tbProd.Controls.Add(Me.Label66)
        Me.tbProd.Controls.Add(Me.txtPercPromo)
        Me.tbProd.Controls.Add(Me.Label63)
        Me.tbProd.Controls.Add(Me.Label39)
        Me.tbProd.Controls.Add(Me.cmbLB)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(557, 239)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Promo automatico"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'chkAttivo
        '
        Me.chkAttivo.AutoSize = True
        Me.chkAttivo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkAttivo.Location = New System.Drawing.Point(445, 196)
        Me.chkAttivo.Name = "chkAttivo"
        Me.chkAttivo.Size = New System.Drawing.Size(68, 19)
        Me.chkAttivo.TabIndex = 197
        Me.chkAttivo.Text = "ATTIVO"
        Me.chkAttivo.UseVisualStyleBackColor = True
        '
        'txtPercFatturatoMax
        '
        Me.txtPercFatturatoMax.Location = New System.Drawing.Point(296, 148)
        Me.txtPercFatturatoMax.MaxLength = 2
        Me.txtPercFatturatoMax.My_AccettaNegativi = False
        Me.txtPercFatturatoMax.My_AllowOnlyInteger = True
        Me.txtPercFatturatoMax.My_DefaultValue = 0
        Me.txtPercFatturatoMax.My_MaxValue = 99.0!
        Me.txtPercFatturatoMax.My_MinValue = 0!
        Me.txtPercFatturatoMax.My_ReplaceWithDefaultValue = True
        Me.txtPercFatturatoMax.Name = "txtPercFatturatoMax"
        Me.txtPercFatturatoMax.Size = New System.Drawing.Size(45, 20)
        Me.txtPercFatturatoMax.TabIndex = 194
        Me.txtPercFatturatoMax.Text = "0"
        Me.txtPercFatturatoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label66.ForeColor = System.Drawing.Color.Black
        Me.Label66.Location = New System.Drawing.Point(17, 151)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(277, 15)
        Me.Label66.TabIndex = 195
        Me.Label66.Text = "% Percentuale massima sul fatturato mensile (0-99)"
        '
        'txtPercPromo
        '
        Me.txtPercPromo.Location = New System.Drawing.Point(296, 113)
        Me.txtPercPromo.MaxLength = 2
        Me.txtPercPromo.My_AccettaNegativi = False
        Me.txtPercPromo.My_AllowOnlyInteger = True
        Me.txtPercPromo.My_DefaultValue = 0
        Me.txtPercPromo.My_MaxValue = 99.0!
        Me.txtPercPromo.My_MinValue = 0!
        Me.txtPercPromo.My_ReplaceWithDefaultValue = True
        Me.txtPercPromo.Name = "txtPercPromo"
        Me.txtPercPromo.Size = New System.Drawing.Size(45, 20)
        Me.txtPercPromo.TabIndex = 191
        Me.txtPercPromo.Text = "0"
        Me.txtPercPromo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(17, 116)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(229, 15)
        Me.Label63.TabIndex = 192
        Me.Label63.Text = "% Percentuale di sconto del promo  (0-99)"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.Label39.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label39.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(3, 3)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(551, 34)
        Me.Label39.TabIndex = 190
        Me.Label39.Text = "PROMO AUTOMATICO"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbLB
        '
        Me.cmbLB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbLB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLB.FormattingEnabled = True
        Me.cmbLB.Location = New System.Drawing.Point(94, 63)
        Me.cmbLB.Name = "cmbLB"
        Me.cmbLB.Size = New System.Drawing.Size(419, 21)
        Me.cmbLB.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Listino Base"
        '
        'frmListinoPromoAutomatico
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(565, 313)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoPromoAutomatico"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Promo Automatico"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents cmbLB As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPercFatturatoMax As ucNumericTextBox
    Friend WithEvents Label66 As Label
    Friend WithEvents txtPercPromo As ucNumericTextBox
    Friend WithEvents Label63 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents chkAttivo As CheckBox
End Class
