<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarketingEffettivo
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
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbGruppo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtQuando = New System.Windows.Forms.DateTimePicker()
        Me.cmbAzione = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 452)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(711, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(675, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.Location = New System.Drawing.Point(639, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 4
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(711, 452)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.txtNote)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.cmbGruppo)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.dtQuando)
        Me.tbProd.Controls.Add(Me.cmbAzione)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(703, 426)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Marketing Effettivo"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(154, 143)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(521, 223)
        Me.txtNote.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Note"
        '
        'cmbGruppo
        '
        Me.cmbGruppo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGruppo.FormattingEnabled = True
        Me.cmbGruppo.Location = New System.Drawing.Point(154, 113)
        Me.cmbGruppo.Name = "cmbGruppo"
        Me.cmbGruppo.Size = New System.Drawing.Size(200, 21)
        Me.cmbGruppo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 15)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Contatto"
        '
        'dtQuando
        '
        Me.dtQuando.Location = New System.Drawing.Point(154, 54)
        Me.dtQuando.Name = "dtQuando"
        Me.dtQuando.Size = New System.Drawing.Size(200, 20)
        Me.dtQuando.TabIndex = 0
        '
        'cmbAzione
        '
        Me.cmbAzione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAzione.FormattingEnabled = True
        Me.cmbAzione.Items.AddRange(New Object() {"Inviata Mail", "Telefonato", "Spedito Materiale", "Visitato"})
        Me.cmbAzione.Location = New System.Drawing.Point(154, 84)
        Me.cmbAzione.Name = "cmbAzione"
        Me.cmbAzione.Size = New System.Drawing.Size(200, 21)
        Me.cmbAzione.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Azione"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Quando"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Marketing
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
        Me.lblTipo.Size = New System.Drawing.Size(159, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Marketing Effettivo"
        '
        'frmMarketingEffettivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(711, 500)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMarketingEffettivo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Marketing Programmato"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.gbPulsanti.ResumeLayout(False)
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
    Friend WithEvents cmbAzione As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents dtQuando As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbGruppo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
