<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoModelloCubetto
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
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProfondita = New Former.ucNumericTextBox()
        Me.txtLarghezza = New Former.ucNumericTextBox()
        Me.txtLunghezza = New Former.ucNumericTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pctPreview = New System.Windows.Forms.PictureBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpImpatto = New System.Windows.Forms.TabPage()
        Me.UcListinoImpatto = New Former.ucListinoImpatto()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpImpatto.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 583)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(646, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(604, 12)
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
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.Location = New System.Drawing.Point(570, 12)
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
        Me.TabMain.Controls.Add(Me.tpImpatto)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(646, 583)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.txtNome)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtProfondita)
        Me.tbProd.Controls.Add(Me.txtLarghezza)
        Me.tbProd.Controls.Add(Me.txtLunghezza)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.pctPreview)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(638, 557)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Modello Cubetto"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(113, 51)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(304, 20)
        Me.txtNome.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 15)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Nome Modello"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(226, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "(lato lungo)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "(lato corto)"
        '
        'txtProfondita
        '
        Me.txtProfondita.My_AccettaNegativi = False
        Me.txtProfondita.My_DefaultValue = 1
        Me.txtProfondita.Location = New System.Drawing.Point(525, 79)
        Me.txtProfondita.My_MaxValue = 1.0E+10!
        Me.txtProfondita.My_MinValue = 1.0!
        Me.txtProfondita.Name = "txtProfondita"
        Me.txtProfondita.My_AllowOnlyInteger = True
        Me.txtProfondita.My_ReplaceWithDefaultValue = True
        Me.txtProfondita.Size = New System.Drawing.Size(98, 20)
        Me.txtProfondita.TabIndex = 23
        Me.txtProfondita.Text = "1"
        Me.txtProfondita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLarghezza
        '
        Me.txtLarghezza.My_AccettaNegativi = False
        Me.txtLarghezza.My_DefaultValue = 1
        Me.txtLarghezza.Location = New System.Drawing.Point(319, 78)
        Me.txtLarghezza.My_MaxValue = 1.0E+10!
        Me.txtLarghezza.My_MinValue = 1.0!
        Me.txtLarghezza.Name = "txtLarghezza"
        Me.txtLarghezza.My_AllowOnlyInteger = True
        Me.txtLarghezza.My_ReplaceWithDefaultValue = True
        Me.txtLarghezza.Size = New System.Drawing.Size(98, 20)
        Me.txtLarghezza.TabIndex = 22
        Me.txtLarghezza.Text = "1"
        Me.txtLarghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLunghezza
        '
        Me.txtLunghezza.My_AccettaNegativi = False
        Me.txtLunghezza.My_DefaultValue = 1
        Me.txtLunghezza.Location = New System.Drawing.Point(113, 78)
        Me.txtLunghezza.My_MaxValue = 1.0E+10!
        Me.txtLunghezza.My_MinValue = 1.0!
        Me.txtLunghezza.Name = "txtLunghezza"
        Me.txtLunghezza.My_AllowOnlyInteger = True
        Me.txtLunghezza.My_ReplaceWithDefaultValue = True
        Me.txtLunghezza.Size = New System.Drawing.Size(98, 20)
        Me.txtLunghezza.TabIndex = 21
        Me.txtLunghezza.Text = "1"
        Me.txtLunghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(423, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Profondità (mm)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(217, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 15)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Larghezza (mm)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(17, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Anteprima"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Lunghezza (mm)"
        '
        'pctPreview
        '
        Me.pctPreview.Location = New System.Drawing.Point(20, 149)
        Me.pctPreview.Name = "pctPreview"
        Me.pctPreview.Size = New System.Drawing.Size(600, 400)
        Me.pctPreview.TabIndex = 16
        Me.pctPreview.TabStop = False
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.icoImballoScatola
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
        Me.lblTipo.Size = New System.Drawing.Size(139, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Modello Cubetto"
        '
        'tpImpatto
        '
        Me.tpImpatto.Controls.Add(Me.UcListinoImpatto)
        Me.tpImpatto.Location = New System.Drawing.Point(4, 22)
        Me.tpImpatto.Name = "tpImpatto"
        Me.tpImpatto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpImpatto.Size = New System.Drawing.Size(638, 557)
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
        Me.UcListinoImpatto.Size = New System.Drawing.Size(632, 551)
        Me.UcListinoImpatto.TabIndex = 0
        '
        'frmListinoModelloCubetto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(646, 631)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoModelloCubetto"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Modello Cubetto"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpImpatto.ResumeLayout(False)
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
    Friend WithEvents pctPreview As System.Windows.Forms.PictureBox
    Friend WithEvents txtProfondita As ucNumericTextBox
    Friend WithEvents txtLarghezza As ucNumericTextBox
    Friend WithEvents txtLunghezza As ucNumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tpImpatto As System.Windows.Forms.TabPage
    Friend WithEvents UcListinoImpatto As Former.ucListinoImpatto
End Class
