<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucReport
    Inherits ucFormerUserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.cmbReport = New System.Windows.Forms.ComboBox()
        Me.pnlFatturatoMensile = New System.Windows.Forms.Panel()
        Me.cmbGiornoFine = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbGiornoInizio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgReport = New System.Windows.Forms.DataGridView()
        Me.pnlFatturatoMensile.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.icoPrint1
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(672, 0)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(78, 30)
        Me.lnkStampa.TabIndex = 60
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAll
        '
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.icoShowAll
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(558, -2)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Size = New System.Drawing.Size(74, 30)
        Me.lnkAll.TabIndex = 59
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Esegui"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbReport
        '
        Me.cmbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReport.FormattingEnabled = True
        Me.cmbReport.Location = New System.Drawing.Point(3, 3)
        Me.cmbReport.Name = "cmbReport"
        Me.cmbReport.Size = New System.Drawing.Size(549, 23)
        Me.cmbReport.TabIndex = 54
        '
        'pnlFatturatoMensile
        '
        Me.pnlFatturatoMensile.AutoSize = True
        Me.pnlFatturatoMensile.Controls.Add(Me.cmbGiornoFine)
        Me.pnlFatturatoMensile.Controls.Add(Me.Label2)
        Me.pnlFatturatoMensile.Controls.Add(Me.cmbGiornoInizio)
        Me.pnlFatturatoMensile.Controls.Add(Me.Label1)
        Me.pnlFatturatoMensile.Location = New System.Drawing.Point(3, 39)
        Me.pnlFatturatoMensile.Name = "pnlFatturatoMensile"
        Me.pnlFatturatoMensile.Size = New System.Drawing.Size(322, 30)
        Me.pnlFatturatoMensile.TabIndex = 61
        '
        'cmbGiornoFine
        '
        Me.cmbGiornoFine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGiornoFine.FormattingEnabled = True
        Me.cmbGiornoFine.Location = New System.Drawing.Point(255, 4)
        Me.cmbGiornoFine.Name = "cmbGiornoFine"
        Me.cmbGiornoFine.Size = New System.Drawing.Size(64, 23)
        Me.cmbGiornoFine.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(164, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Giorno Finale"
        '
        'cmbGiornoInizio
        '
        Me.cmbGiornoInizio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGiornoInizio.FormattingEnabled = True
        Me.cmbGiornoInizio.Location = New System.Drawing.Point(94, 4)
        Me.cmbGiornoInizio.Name = "cmbGiornoInizio"
        Me.cmbGiornoInizio.Size = New System.Drawing.Size(64, 23)
        Me.cmbGiornoInizio.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Giorno Iniziale"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlFatturatoMensile)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(762, 72)
        Me.FlowLayoutPanel1.TabIndex = 62
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.cmbReport)
        Me.Panel1.Controls.Add(Me.lnkAll)
        Me.Panel1.Controls.Add(Me.lnkStampa)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 30)
        Me.Panel1.TabIndex = 65
        '
        'dgReport
        '
        Me.dgReport.AllowUserToAddRows = False
        Me.dgReport.AllowUserToDeleteRows = False
        Me.dgReport.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgReport.BackgroundColor = System.Drawing.Color.White
        Me.dgReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgReport.ColumnHeadersHeight = 20
        Me.dgReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReport.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgReport.EnableHeadersVisualStyles = False
        Me.dgReport.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgReport.Location = New System.Drawing.Point(0, 72)
        Me.dgReport.MultiSelect = False
        Me.dgReport.Name = "dgReport"
        Me.dgReport.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReport.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgReport.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgReport.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgReport.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgReport.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgReport.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgReport.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReport.Size = New System.Drawing.Size(762, 635)
        Me.dgReport.TabIndex = 65
        Me.dgReport.TabStop = False
        '
        'ucReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.dgReport)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucReport"
        Me.Size = New System.Drawing.Size(762, 707)
        Me.pnlFatturatoMensile.ResumeLayout(False)
        Me.pnlFatturatoMensile.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAll As System.Windows.Forms.LinkLabel
    Friend WithEvents cmbReport As System.Windows.Forms.ComboBox
    Friend WithEvents pnlFatturatoMensile As System.Windows.Forms.Panel
    Friend WithEvents cmbGiornoFine As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbGiornoInizio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgReport As System.Windows.Forms.DataGridView

End Class
