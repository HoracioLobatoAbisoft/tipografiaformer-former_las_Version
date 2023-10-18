<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMagazzinoAddRichiesta
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
        Me.txtQta = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFornitore = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbRichieste = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 170)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(516, 48)
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
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(432, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Annulla"
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
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(350, 12)
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
        Me.TabMain.Size = New System.Drawing.Size(516, 170)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.txtQta)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.cmbFornitore)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbRichieste)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(508, 144)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Aggiungi richiesta a ordine"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'txtQta
        '
        Me.txtQta.My_AccettaNegativi = False
        Me.txtQta.My_DefaultValue = 1
        Me.txtQta.Location = New System.Drawing.Point(124, 98)
        Me.txtQta.My_MaxValue = 1.0E+10!
        Me.txtQta.My_MinValue = 1.0!
        Me.txtQta.Name = "txtQta"
        Me.txtQta.My_AllowOnlyInteger = True
        Me.txtQta.My_ReplaceWithDefaultValue = True
        Me.txtQta.Size = New System.Drawing.Size(115, 20)
        Me.txtQta.TabIndex = 122
        Me.txtQta.Text = "1"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Quantità"
        '
        'cmbFornitore
        '
        Me.cmbFornitore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFornitore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFornitore.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFornitore.FormattingEnabled = True
        Me.cmbFornitore.Location = New System.Drawing.Point(124, 54)
        Me.cmbFornitore.Name = "cmbFornitore"
        Me.cmbFornitore.Size = New System.Drawing.Size(364, 23)
        Me.cmbFornitore.TabIndex = 120
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Fornitore"
        '
        'cmbRichieste
        '
        Me.cmbRichieste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRichieste.FormattingEnabled = True
        Me.cmbRichieste.Location = New System.Drawing.Point(124, 14)
        Me.cmbRichieste.Name = "cmbRichieste"
        Me.cmbRichieste.Size = New System.Drawing.Size(364, 21)
        Me.cmbRichieste.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Richieste in sospeso"
        '
        'frmMagazzinoAddRichiesta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(516, 218)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMagazzinoAddRichiesta"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Aggiungi richiesta a ordine"
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
    Friend WithEvents cmbRichieste As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtQta As ucNumericTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbFornitore As ComboBox
End Class
