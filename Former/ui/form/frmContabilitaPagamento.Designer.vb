<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContabilitaPagamento
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
        Me.lblPagamDaInternet = New System.Windows.Forms.Label()
        Me.cmbTipoPagamento = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDettFatt = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.cmbFat = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtPagam = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtImporto = New Former.ucNumericTextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.MainBar = New System.Windows.Forms.MenuStrip()
        Me.ChiudiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalvaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainBar.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(586, 313)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblPagamDaInternet)
        Me.tbProd.Controls.Add(Me.cmbTipoPagamento)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.btnDettFatt)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtNote)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtDescr)
        Me.tbProd.Controls.Add(Me.cmbFat)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.dtPagam)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbCliente)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtImporto)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(578, 287)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Pagamento"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblPagamDaInternet
        '
        Me.lblPagamDaInternet.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblPagamDaInternet.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPagamDaInternet.ForeColor = System.Drawing.Color.Black
        Me.lblPagamDaInternet.Image = Global.Former.My.Resources.Resources._PubblicazioneWeb
        Me.lblPagamDaInternet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPagamDaInternet.Location = New System.Drawing.Point(400, 6)
        Me.lblPagamDaInternet.Name = "lblPagamDaInternet"
        Me.lblPagamDaInternet.Size = New System.Drawing.Size(170, 34)
        Me.lblPagamDaInternet.TabIndex = 32
        Me.lblPagamDaInternet.Text = "Dal sito Internet"
        Me.lblPagamDaInternet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPagamDaInternet.Visible = False
        '
        'cmbTipoPagamento
        '
        Me.cmbTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPagamento.FormattingEnabled = True
        Me.cmbTipoPagamento.Location = New System.Drawing.Point(155, 127)
        Me.cmbTipoPagamento.Name = "cmbTipoPagamento"
        Me.cmbTipoPagamento.Size = New System.Drawing.Size(410, 21)
        Me.cmbTipoPagamento.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(50, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Tipologia"
        '
        'btnDettFatt
        '
        Me.btnDettFatt.Location = New System.Drawing.Point(540, 99)
        Me.btnDettFatt.Name = "btnDettFatt"
        Me.btnDettFatt.Size = New System.Drawing.Size(25, 23)
        Me.btnDettFatt.TabIndex = 29
        Me.btnDettFatt.Text = "..."
        Me.btnDettFatt.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(50, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 15)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Note"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(155, 206)
        Me.txtNote.MaxLength = 50
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(410, 71)
        Me.txtNote.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Descrizione"
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(155, 154)
        Me.txtDescr.MaxLength = 255
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(410, 20)
        Me.txtDescr.TabIndex = 3
        '
        'cmbFat
        '
        Me.cmbFat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFat.FormattingEnabled = True
        Me.cmbFat.Location = New System.Drawing.Point(155, 100)
        Me.cmbFat.Name = "cmbFat"
        Me.cmbFat.Size = New System.Drawing.Size(379, 21)
        Me.cmbFat.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Riferimento"
        '
        'dtPagam
        '
        Me.dtPagam.Location = New System.Drawing.Point(155, 47)
        Me.dtPagam.Name = "dtPagam"
        Me.dtPagam.Size = New System.Drawing.Size(410, 20)
        Me.dtPagam.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Data pagamento"
        '
        'cmbCliente
        '
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(155, 73)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(410, 21)
        Me.cmbCliente.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Cliente"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Importo"
        '
        'txtImporto
        '
        Me.txtImporto.Location = New System.Drawing.Point(155, 180)
        Me.txtImporto.MaxLength = 50
        Me.txtImporto.My_AccettaNegativi = False
        Me.txtImporto.My_AllowOnlyInteger = False
        Me.txtImporto.My_DefaultValue = 0
        Me.txtImporto.My_MaxValue = 1.0E+10!
        Me.txtImporto.My_MinValue = 0!
        Me.txtImporto.My_ReplaceWithDefaultValue = True
        Me.txtImporto.Name = "txtImporto"
        Me.txtImporto.Size = New System.Drawing.Size(157, 20)
        Me.txtImporto.TabIndex = 4
        Me.txtImporto.Text = "0"
        Me.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Pagamento
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
        Me.lblTipo.Size = New System.Drawing.Size(98, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Pagamento"
        '
        'MainBar
        '
        Me.MainBar.AutoSize = False
        Me.MainBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MainBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChiudiToolStripMenuItem, Me.SalvaToolStripMenuItem})
        Me.MainBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MainBar.Location = New System.Drawing.Point(0, 313)
        Me.MainBar.Name = "MainBar"
        Me.MainBar.Size = New System.Drawing.Size(586, 44)
        Me.MainBar.TabIndex = 8
        Me.MainBar.Text = "MenuStrip1"
        '
        'ChiudiToolStripMenuItem
        '
        Me.ChiudiToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ChiudiToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChiudiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Annulla
        Me.ChiudiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ChiudiToolStripMenuItem.Name = "ChiudiToolStripMenuItem"
        Me.ChiudiToolStripMenuItem.Size = New System.Drawing.Size(80, 40)
        Me.ChiudiToolStripMenuItem.Text = "Chiudi"
        '
        'SalvaToolStripMenuItem
        '
        Me.SalvaToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SalvaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SalvaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Ok
        Me.SalvaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalvaToolStripMenuItem.Name = "SalvaToolStripMenuItem"
        Me.SalvaToolStripMenuItem.Size = New System.Drawing.Size(72, 40)
        Me.SalvaToolStripMenuItem.Text = "Salva"
        '
        'frmContabilitaPagamento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(586, 357)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.MainBar)
        Me.Name = "frmContabilitaPagamento"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Pagamento"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainBar.ResumeLayout(False)
        Me.MainBar.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtImporto As ucNumericTextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents dtPagam As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFat As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents btnDettFatt As System.Windows.Forms.Button
    Friend WithEvents cmbTipoPagamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPagamDaInternet As System.Windows.Forms.Label
    Friend WithEvents MainBar As MenuStrip
    Friend WithEvents ChiudiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalvaToolStripMenuItem As ToolStripMenuItem
End Class
