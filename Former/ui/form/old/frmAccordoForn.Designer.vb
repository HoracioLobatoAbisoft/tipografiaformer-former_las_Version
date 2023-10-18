<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccordoForn
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
        Me.lblDataAccordo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtannotazioni = New System.Windows.Forms.TextBox()
        Me.txtCodiceForn = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDetCli = New System.Windows.Forms.Button()
        Me.txtPrezzo = New System.Windows.Forms.TextBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPrezzo = New System.Windows.Forms.Label()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 315)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(540, 48)
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
        Me.btnCancel.Image = Global.Former.My.Resources.Resources.icoCancel
        Me.btnCancel.Location = New System.Drawing.Point(504, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.icoOk
        Me.btnOk.Location = New System.Drawing.Point(468, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 3
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(540, 315)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblDataAccordo)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtannotazioni)
        Me.tbProd.Controls.Add(Me.txtCodiceForn)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.btnDetCli)
        Me.tbProd.Controls.Add(Me.txtPrezzo)
        Me.tbProd.Controls.Add(Me.cmbCliente)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.lblPrezzo)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(532, 289)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Accordi Fornitore"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblDataAccordo
        '
        Me.lblDataAccordo.AutoSize = True
        Me.lblDataAccordo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDataAccordo.ForeColor = System.Drawing.Color.Black
        Me.lblDataAccordo.Location = New System.Drawing.Point(149, 50)
        Me.lblDataAccordo.Name = "lblDataAccordo"
        Me.lblDataAccordo.Size = New System.Drawing.Size(79, 15)
        Me.lblDataAccordo.TabIndex = 57
        Me.lblDataAccordo.Text = "Data Accordo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Data Accordo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Note"
        '
        'txtannotazioni
        '
        Me.txtannotazioni.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtannotazioni.Location = New System.Drawing.Point(152, 168)
        Me.txtannotazioni.MaxLength = 50
        Me.txtannotazioni.Multiline = True
        Me.txtannotazioni.Name = "txtannotazioni"
        Me.txtannotazioni.Size = New System.Drawing.Size(320, 109)
        Me.txtannotazioni.TabIndex = 54
        '
        'txtCodiceForn
        '
        Me.txtCodiceForn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodiceForn.Location = New System.Drawing.Point(152, 106)
        Me.txtCodiceForn.MaxLength = 50
        Me.txtCodiceForn.Name = "txtCodiceForn"
        Me.txtCodiceForn.Size = New System.Drawing.Size(320, 23)
        Me.txtCodiceForn.TabIndex = 54
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(50, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 15)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Codice Fornitore"
        '
        'btnDetCli
        '
        Me.btnDetCli.Location = New System.Drawing.Point(478, 77)
        Me.btnDetCli.Name = "btnDetCli"
        Me.btnDetCli.Size = New System.Drawing.Size(24, 23)
        Me.btnDetCli.TabIndex = 53
        Me.btnDetCli.Text = "..."
        Me.btnDetCli.UseVisualStyleBackColor = True
        '
        'txtPrezzo
        '
        Me.txtPrezzo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrezzo.Location = New System.Drawing.Point(152, 133)
        Me.txtPrezzo.MaxLength = 50
        Me.txtPrezzo.Name = "txtPrezzo"
        Me.txtPrezzo.Size = New System.Drawing.Size(183, 32)
        Me.txtPrezzo.TabIndex = 1
        Me.txtPrezzo.Text = "0"
        Me.txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCliente
        '
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(152, 77)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(320, 21)
        Me.cmbCliente.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Fornitore"
        '
        'lblPrezzo
        '
        Me.lblPrezzo.AutoSize = True
        Me.lblPrezzo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPrezzo.ForeColor = System.Drawing.Color.Black
        Me.lblPrezzo.Location = New System.Drawing.Point(50, 142)
        Me.lblPrezzo.Name = "lblPrezzo"
        Me.lblPrezzo.Size = New System.Drawing.Size(89, 15)
        Me.lblPrezzo.TabIndex = 17
        Me.lblPrezzo.Text = "Prezzo riservato"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.icoForn
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
        Me.lblTipo.Size = New System.Drawing.Size(166, 25)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Accordi Fornitore"
        '
        'frmAccordoForn
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(540, 363)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmAccordoForn"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Listino Personale"
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
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPrezzo As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtPrezzo As System.Windows.Forms.TextBox
    Friend WithEvents btnDetCli As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtannotazioni As System.Windows.Forms.TextBox
    Friend WithEvents txtCodiceForn As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDataAccordo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
