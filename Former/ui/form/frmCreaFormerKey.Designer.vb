<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreaFormerKey
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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnAggiornaDischi = New System.Windows.Forms.Button()
        Me.btnChiudi = New System.Windows.Forms.Button()
        Me.btnCrea = New System.Windows.Forms.Button()
        Me.cmbDrive = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUtente = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.TabMain.Size = New System.Drawing.Size(485, 261)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnAggiornaDischi)
        Me.tbProd.Controls.Add(Me.btnChiudi)
        Me.tbProd.Controls.Add(Me.btnCrea)
        Me.tbProd.Controls.Add(Me.cmbDrive)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbUtente)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(477, 235)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Creazione FormerKey"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnAggiornaDischi
        '
        Me.btnAggiornaDischi.FlatAppearance.BorderSize = 0
        Me.btnAggiornaDischi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiornaDischi.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiornaDischi.Location = New System.Drawing.Point(429, 108)
        Me.btnAggiornaDischi.Name = "btnAggiornaDischi"
        Me.btnAggiornaDischi.Size = New System.Drawing.Size(31, 30)
        Me.btnAggiornaDischi.TabIndex = 26
        Me.btnAggiornaDischi.UseVisualStyleBackColor = True
        '
        'btnChiudi
        '
        Me.btnChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChiudi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChiudi.FlatAppearance.BorderSize = 0
        Me.btnChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChiudi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnChiudi.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnChiudi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChiudi.Location = New System.Drawing.Point(274, 169)
        Me.btnChiudi.Name = "btnChiudi"
        Me.btnChiudi.Size = New System.Drawing.Size(84, 32)
        Me.btnChiudi.TabIndex = 25
        Me.btnChiudi.Text = "Chiudi"
        Me.btnChiudi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChiudi.UseVisualStyleBackColor = True
        '
        'btnCrea
        '
        Me.btnCrea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCrea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCrea.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCrea.FlatAppearance.BorderSize = 0
        Me.btnCrea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrea.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCrea.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnCrea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCrea.Location = New System.Drawing.Point(117, 169)
        Me.btnCrea.Name = "btnCrea"
        Me.btnCrea.Size = New System.Drawing.Size(133, 32)
        Me.btnCrea.TabIndex = 24
        Me.btnCrea.Text = "Crea FormerKey"
        Me.btnCrea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCrea.UseVisualStyleBackColor = True
        '
        'cmbDrive
        '
        Me.cmbDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDrive.FormattingEnabled = True
        Me.cmbDrive.Location = New System.Drawing.Point(332, 113)
        Me.cmbDrive.Name = "cmbDrive"
        Me.cmbDrive.Size = New System.Drawing.Size(90, 21)
        Me.cmbDrive.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(262, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Seleziona l'unità USB che identifica la FormerKey"
        '
        'cmbUtente
        '
        Me.cmbUtente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUtente.FormattingEnabled = True
        Me.cmbUtente.Location = New System.Drawing.Point(332, 62)
        Me.cmbUtente.Name = "cmbUtente"
        Me.cmbUtente.Size = New System.Drawing.Size(128, 21)
        Me.cmbUtente.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Seleziona l'utente da associare alla FormerKey"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._UsbKey
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
        Me.lblTipo.Size = New System.Drawing.Size(92, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "FormerKey"
        '
        'frmCreaFormerKey
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(493, 298)
        Me.Controls.Add(Me.TabMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCreaFormerKey"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - "
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents cmbUtente As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbDrive As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnChiudi As System.Windows.Forms.Button
    Friend WithEvents btnCrea As System.Windows.Forms.Button
    Friend WithEvents btnAggiornaDischi As System.Windows.Forms.Button
End Class
