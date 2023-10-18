<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcPesoConsegna
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
        Me.lblRis = New System.Windows.Forms.Label()
        Me.dgScatole = New System.Windows.Forms.DataGridView()
        Me.Altezza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Larghezza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Profondita = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoVol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.dgScatole, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 506)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(763, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(679, 12)
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
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(577, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(96, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Conferma"
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
        Me.TabMain.Size = New System.Drawing.Size(763, 506)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblRis)
        Me.tbProd.Controls.Add(Me.dgScatole)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(755, 480)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Calcolo Peso Consegna"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblRis
        '
        Me.lblRis.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblRis.ForeColor = System.Drawing.Color.Green
        Me.lblRis.Location = New System.Drawing.Point(53, 398)
        Me.lblRis.Name = "lblRis"
        Me.lblRis.Size = New System.Drawing.Size(632, 44)
        Me.lblRis.TabIndex = 16
        Me.lblRis.Text = "Inserisci i dati di ogni scatola nella lista"
        Me.lblRis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgScatole
        '
        Me.dgScatole.AllowUserToResizeRows = False
        Me.dgScatole.BackgroundColor = System.Drawing.Color.White
        Me.dgScatole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgScatole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgScatole.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Altezza, Me.Larghezza, Me.Profondita, Me.Peso, Me.PesoVol})
        Me.dgScatole.Location = New System.Drawing.Point(53, 59)
        Me.dgScatole.Name = "dgScatole"
        Me.dgScatole.Size = New System.Drawing.Size(694, 305)
        Me.dgScatole.TabIndex = 15
        '
        'Altezza
        '
        Me.Altezza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Altezza.HeaderText = "Altezza (cm)"
        Me.Altezza.Name = "Altezza"
        Me.Altezza.Width = 130
        '
        'Larghezza
        '
        Me.Larghezza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Larghezza.HeaderText = "Larghezza (cm)"
        Me.Larghezza.Name = "Larghezza"
        Me.Larghezza.Width = 130
        '
        'Profondita
        '
        Me.Profondita.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Profondita.HeaderText = "Profondita (cm)"
        Me.Profondita.Name = "Profondita"
        Me.Profondita.Width = 130
        '
        'Peso
        '
        Me.Peso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Peso.HeaderText = "Peso (Kg)"
        Me.Peso.Name = "Peso"
        Me.Peso.Width = 130
        '
        'PesoVol
        '
        Me.PesoVol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PesoVol.HeaderText = "Peso Volumetrico"
        Me.PesoVol.Name = "PesoVol"
        Me.PesoVol.ReadOnly = True
        Me.PesoVol.Width = 130
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.scale
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
        Me.lblTipo.Size = New System.Drawing.Size(186, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Calcolo Peso Consegna"
        '
        'frmCalcPesoConsegna
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(763, 554)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmCalcPesoConsegna"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Calcolo Peso Consegna"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.dgScatole, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgScatole As DataGridView
    Friend WithEvents lblRis As Label
    Friend WithEvents Altezza As DataGridViewTextBoxColumn
    Friend WithEvents Larghezza As DataGridViewTextBoxColumn
    Friend WithEvents Profondita As DataGridViewTextBoxColumn
    Friend WithEvents Peso As DataGridViewTextBoxColumn
    Friend WithEvents PesoVol As DataGridViewTextBoxColumn
End Class
