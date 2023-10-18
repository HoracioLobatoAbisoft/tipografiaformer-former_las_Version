<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsegnaGLSReportContrassegno
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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.dtDataPagamento = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBuffer = New System.Windows.Forms.TextBox()
        Me.btnSalva = New Former.ucButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnInterpreta = New Former.ucButton()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFileResoconto = New System.Windows.Forms.TextBox()
        Me.btnFileResoConto = New System.Windows.Forms.Button()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 559)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1062, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(978, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
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
        Me.TabMain.Size = New System.Drawing.Size(1062, 559)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.dtDataPagamento)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtBuffer)
        Me.tbProd.Controls.Add(Me.btnSalva)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.btnInterpreta)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.txtFileResoconto)
        Me.tbProd.Controls.Add(Me.btnFileResoConto)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1054, 533)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Resoconto Contrassegno GLS"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'dtDataPagamento
        '
        Me.dtDataPagamento.Location = New System.Drawing.Point(330, 400)
        Me.dtDataPagamento.Name = "dtDataPagamento"
        Me.dtDataPagamento.Size = New System.Drawing.Size(252, 20)
        Me.dtDataPagamento.TabIndex = 177
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(45, 405)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(268, 18)
        Me.Label3.TabIndex = 176
        Me.Label3.Text = "3) Seleziona la data in cui registrare i pagamenti"
        '
        'txtBuffer
        '
        Me.txtBuffer.BackColor = System.Drawing.Color.White
        Me.txtBuffer.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuffer.Location = New System.Drawing.Point(48, 182)
        Me.txtBuffer.Multiline = True
        Me.txtBuffer.Name = "txtBuffer"
        Me.txtBuffer.ReadOnly = True
        Me.txtBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBuffer.Size = New System.Drawing.Size(993, 208)
        Me.txtBuffer.TabIndex = 175
        '
        'btnSalva
        '
        Me.btnSalva.Image = Global.Former.My.Resources.Resources._Save
        Me.btnSalva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalva.Location = New System.Drawing.Point(455, 462)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Radius = 5
        Me.btnSalva.RoundedButton = False
        Me.btnSalva.Size = New System.Drawing.Size(176, 43)
        Me.btnSalva.TabIndex = 174
        Me.btnSalva.Text = "Salva il Pagamento"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(50, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 18)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "2) Controlla le consegne contenute"
        '
        'btnInterpreta
        '
        Me.btnInterpreta.Location = New System.Drawing.Point(507, 116)
        Me.btnInterpreta.Name = "btnInterpreta"
        Me.btnInterpreta.Radius = 5
        Me.btnInterpreta.RoundedButton = False
        Me.btnInterpreta.Size = New System.Drawing.Size(75, 23)
        Me.btnInterpreta.TabIndex = 171
        Me.btnInterpreta.Text = "Interpreta"
        Me.btnInterpreta.UseVisualStyleBackColor = True
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 13)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(230, 21)
        Me.lblTipo.TabIndex = 167
        Me.lblTipo.Text = "Resoconto Contrassegno GLS"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(50, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 18)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "1) Seleziona file PDF GLS"
        '
        'txtFileResoconto
        '
        Me.txtFileResoconto.Location = New System.Drawing.Point(205, 64)
        Me.txtFileResoconto.MaxLength = 50
        Me.txtFileResoconto.Name = "txtFileResoconto"
        Me.txtFileResoconto.ReadOnly = True
        Me.txtFileResoconto.Size = New System.Drawing.Size(809, 20)
        Me.txtFileResoconto.TabIndex = 168
        '
        'btnFileResoConto
        '
        Me.btnFileResoConto.Location = New System.Drawing.Point(1020, 63)
        Me.btnFileResoConto.Name = "btnFileResoConto"
        Me.btnFileResoConto.Size = New System.Drawing.Size(26, 22)
        Me.btnFileResoConto.TabIndex = 169
        Me.btnFileResoConto.Text = "..."
        Me.btnFileResoConto.UseVisualStyleBackColor = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._GLS
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "File PDF|*.pdf"
        '
        'frmConsegnaGLSReportContrassegno
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1062, 607)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConsegnaGLSReportContrassegno"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Resoconto Contrassegno GLS"
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
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFileResoconto As TextBox
    Friend WithEvents btnFileResoConto As Button
    Friend WithEvents OpenFileImg As OpenFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents btnInterpreta As ucButton
    Friend WithEvents btnSalva As ucButton
    Friend WithEvents txtBuffer As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtDataPagamento As DateTimePicker
End Class
