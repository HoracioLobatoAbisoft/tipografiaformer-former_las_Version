<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmContabilitaBilancio
    Inherits baseFormInternaRedim

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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.webBilancio = New System.Windows.Forms.WebBrowser()
        Me.lnkGenera = New System.Windows.Forms.LinkLabel()
        Me.cmbAzienda = New System.Windows.Forms.ComboBox()
        Me.lblAzienda = New System.Windows.Forms.Label()
        Me.cmbAnno = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lnkDownloadCSV = New System.Windows.Forms.LinkLabel()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.dlgFileSave = New System.Windows.Forms.SaveFileDialog()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPulsanti.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnCancel.Location = New System.Drawing.Point(871, 12)
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
        Me.TabMain.Size = New System.Drawing.Size(955, 627)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.webBilancio)
        Me.tbProd.Controls.Add(Me.lnkGenera)
        Me.tbProd.Controls.Add(Me.cmbAzienda)
        Me.tbProd.Controls.Add(Me.lblAzienda)
        Me.tbProd.Controls.Add(Me.cmbAnno)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 601)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Report Contabile"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'webBilancio
        '
        Me.webBilancio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webBilancio.Location = New System.Drawing.Point(9, 61)
        Me.webBilancio.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webBilancio.Name = "webBilancio"
        Me.webBilancio.Size = New System.Drawing.Size(930, 534)
        Me.webBilancio.TabIndex = 56
        '
        'lnkGenera
        '
        Me.lnkGenera.AutoSize = True
        Me.lnkGenera.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkGenera.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkGenera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkGenera.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkGenera.Location = New System.Drawing.Point(663, 20)
        Me.lnkGenera.Name = "lnkGenera"
        Me.lnkGenera.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkGenera.Size = New System.Drawing.Size(74, 27)
        Me.lnkGenera.TabIndex = 55
        Me.lnkGenera.TabStop = True
        Me.lnkGenera.Text = "Genera"
        Me.lnkGenera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbAzienda
        '
        Me.cmbAzienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAzienda.FormattingEnabled = True
        Me.cmbAzienda.Location = New System.Drawing.Point(540, 23)
        Me.cmbAzienda.Name = "cmbAzienda"
        Me.cmbAzienda.Size = New System.Drawing.Size(94, 21)
        Me.cmbAzienda.TabIndex = 21
        '
        'lblAzienda
        '
        Me.lblAzienda.AutoSize = True
        Me.lblAzienda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAzienda.ForeColor = System.Drawing.Color.Black
        Me.lblAzienda.Location = New System.Drawing.Point(485, 26)
        Me.lblAzienda.Name = "lblAzienda"
        Me.lblAzienda.Size = New System.Drawing.Size(49, 15)
        Me.lblAzienda.TabIndex = 22
        Me.lblAzienda.Text = "Azienda"
        '
        'cmbAnno
        '
        Me.cmbAnno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnno.FormattingEnabled = True
        Me.cmbAnno.Location = New System.Drawing.Point(374, 23)
        Me.cmbAnno.Name = "cmbAnno"
        Me.cmbAnno.Size = New System.Drawing.Size(94, 21)
        Me.cmbAnno.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(332, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Anno"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Bilancio48
        Me.pctTipo.Location = New System.Drawing.Point(8, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(48, 48)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(62, 21)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(140, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Bilancio Annuale"
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lnkDownloadCSV)
        Me.gbPulsanti.Controls.Add(Me.lnkStampa)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 627)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lnkDownloadCSV
        '
        Me.lnkDownloadCSV.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDownloadCSV.Image = Global.Former.My.Resources.Resources._ExportCSV
        Me.lnkDownloadCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDownloadCSV.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDownloadCSV.Location = New System.Drawing.Point(92, 15)
        Me.lnkDownloadCSV.Name = "lnkDownloadCSV"
        Me.lnkDownloadCSV.Size = New System.Drawing.Size(114, 26)
        Me.lnkDownloadCSV.TabIndex = 57
        Me.lnkDownloadCSV.TabStop = True
        Me.lnkDownloadCSV.Text = "Download CSV"
        Me.lnkDownloadCSV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkDownloadCSV.Visible = False
        '
        'lnkStampa
        '
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(6, 15)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 26)
        Me.lnkStampa.TabIndex = 56
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dlgFileSave
        '
        Me.dlgFileSave.DefaultExt = "csv"
        Me.dlgFileSave.Filter = "File CSV|*.csv"
        '
        'frmContabilitaBilancio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 675)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmContabilitaBilancio"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Report Contabile"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents cmbAnno As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbAzienda As ComboBox
    Friend WithEvents lblAzienda As Label
    Friend WithEvents lnkGenera As LinkLabel
    Friend WithEvents webBilancio As WebBrowser
    Friend WithEvents lnkStampa As LinkLabel
    Friend WithEvents lnkDownloadCSV As LinkLabel
    Friend WithEvents dlgFileSave As SaveFileDialog
End Class
