<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSituazioneClientiOLD
    Inherits ucFormerUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgSituazClienti = New System.Windows.Forms.DataGridView()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.lblClienti = New System.Windows.Forms.Label()
        Me.SplitContainerGenerale = New System.Windows.Forms.SplitContainer()
        Me.UcSituazContabEx = New Former.ucAmministrazioneSituazioneContabileEx()
        Me.RagioneSociale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumOrdini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotOrdini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataMinOrdini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataMaxOrdini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DaIncassare = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataUltPag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotScoperto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgSituazClienti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerGenerale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerGenerale.Panel1.SuspendLayout()
        Me.SplitContainerGenerale.Panel2.SuspendLayout()
        Me.SplitContainerGenerale.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgSituazClienti
        '
        Me.DgSituazClienti.AllowUserToAddRows = False
        Me.DgSituazClienti.AllowUserToDeleteRows = False
        Me.DgSituazClienti.AllowUserToOrderColumns = True
        Me.DgSituazClienti.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgSituazClienti.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgSituazClienti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgSituazClienti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgSituazClienti.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgSituazClienti.BackgroundColor = System.Drawing.Color.White
        Me.DgSituazClienti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgSituazClienti.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgSituazClienti.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgSituazClienti.ColumnHeadersHeight = 20
        Me.DgSituazClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgSituazClienti.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RagioneSociale, Me.Tel, Me.Cel, Me.Email, Me.NumOrdini, Me.TotOrdini, Me.DataMinOrdini, Me.DataMaxOrdini, Me.DaIncassare, Me.DataUltPag, Me.TotScoperto})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSituazClienti.DefaultCellStyle = DataGridViewCellStyle10
        Me.DgSituazClienti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgSituazClienti.EnableHeadersVisualStyles = False
        Me.DgSituazClienti.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgSituazClienti.Location = New System.Drawing.Point(0, 34)
        Me.DgSituazClienti.MultiSelect = False
        Me.DgSituazClienti.Name = "DgSituazClienti"
        Me.DgSituazClienti.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSituazClienti.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DgSituazClienti.RowHeadersVisible = False
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.DgSituazClienti.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DgSituazClienti.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgSituazClienti.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgSituazClienti.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgSituazClienti.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSituazClienti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgSituazClienti.Size = New System.Drawing.Size(969, 92)
        Me.DgSituazClienti.TabIndex = 50
        Me.DgSituazClienti.TabStop = False
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(55, 4)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(799, 24)
        Me.cmbCliente.TabIndex = 98
        '
        'lnkCerca
        '
        Me.lnkCerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCerca.BackColor = System.Drawing.Color.Transparent
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.search
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(860, 2)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(109, 27)
        Me.lnkCerca.TabIndex = 97
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Avvia ricerca..."
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClienti
        '
        Me.lblClienti.AutoSize = True
        Me.lblClienti.BackColor = System.Drawing.Color.Transparent
        Me.lblClienti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblClienti.ForeColor = System.Drawing.Color.Black
        Me.lblClienti.Location = New System.Drawing.Point(3, 8)
        Me.lblClienti.Name = "lblClienti"
        Me.lblClienti.Size = New System.Drawing.Size(46, 15)
        Me.lblClienti.TabIndex = 96
        Me.lblClienti.Text = "Cliente"
        '
        'SplitContainerGenerale
        '
        Me.SplitContainerGenerale.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainerGenerale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerGenerale.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerGenerale.Name = "SplitContainerGenerale"
        Me.SplitContainerGenerale.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerGenerale.Panel1
        '
        Me.SplitContainerGenerale.Panel1.Controls.Add(Me.lblClienti)
        Me.SplitContainerGenerale.Panel1.Controls.Add(Me.cmbCliente)
        Me.SplitContainerGenerale.Panel1.Controls.Add(Me.DgSituazClienti)
        Me.SplitContainerGenerale.Panel1.Controls.Add(Me.lnkCerca)
        '
        'SplitContainerGenerale.Panel2
        '
        Me.SplitContainerGenerale.Panel2.Controls.Add(Me.UcSituazContabEx)
        Me.SplitContainerGenerale.Size = New System.Drawing.Size(972, 465)
        Me.SplitContainerGenerale.SplitterDistance = 128
        Me.SplitContainerGenerale.TabIndex = 100
        '
        'UcSituazContabEx
        '
        Me.UcSituazContabEx.BackColor = System.Drawing.Color.White
        Me.UcSituazContabEx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSituazContabEx.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcSituazContabEx.IdRub = 0
        Me.UcSituazContabEx.Location = New System.Drawing.Point(0, 0)
        Me.UcSituazContabEx.Name = "UcSituazContabEx"
        Me.UcSituazContabEx.Size = New System.Drawing.Size(972, 333)
        Me.UcSituazContabEx.TabIndex = 99
        '
        'RagioneSociale
        '
        Me.RagioneSociale.DataPropertyName = "RagSoc"
        Me.RagioneSociale.HeaderText = "Ragione Sociale"
        Me.RagioneSociale.Name = "RagioneSociale"
        Me.RagioneSociale.ReadOnly = True
        Me.RagioneSociale.Width = 122
        '
        'Tel
        '
        Me.Tel.DataPropertyName = "Tel"
        Me.Tel.HeaderText = "Tel"
        Me.Tel.Name = "Tel"
        Me.Tel.ReadOnly = True
        Me.Tel.Width = 47
        '
        'Cel
        '
        Me.Cel.DataPropertyName = "Cel"
        Me.Cel.HeaderText = "Cel"
        Me.Cel.Name = "Cel"
        Me.Cel.ReadOnly = True
        Me.Cel.Width = 50
        '
        'Email
        '
        Me.Email.DataPropertyName = "mail"
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 63
        '
        'NumOrdini
        '
        Me.NumOrdini.DataPropertyName = "NumOrd"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumOrdini.DefaultCellStyle = DataGridViewCellStyle3
        Me.NumOrdini.HeaderText = "N° Ordini"
        Me.NumOrdini.Name = "NumOrdini"
        Me.NumOrdini.ReadOnly = True
        Me.NumOrdini.ToolTipText = "Numero Ordini attualmente in lavorazione"
        Me.NumOrdini.Width = 81
        '
        'TotOrdini
        '
        Me.TotOrdini.DataPropertyName = "TotOrdStr"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TotOrdini.DefaultCellStyle = DataGridViewCellStyle4
        Me.TotOrdini.HeaderText = "€ Ordini"
        Me.TotOrdini.Name = "TotOrdini"
        Me.TotOrdini.ReadOnly = True
        Me.TotOrdini.Width = 74
        '
        'DataMinOrdini
        '
        Me.DataMinOrdini.DataPropertyName = "DataMinOrd"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataMinOrdini.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataMinOrdini.HeaderText = "Ordine meno recente"
        Me.DataMinOrdini.Name = "DataMinOrdini"
        Me.DataMinOrdini.ReadOnly = True
        Me.DataMinOrdini.ToolTipText = "La data dell'ordine meno recente non fatturato"
        Me.DataMinOrdini.Width = 147
        '
        'DataMaxOrdini
        '
        Me.DataMaxOrdini.DataPropertyName = "DataMaxOrd"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataMaxOrdini.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataMaxOrdini.HeaderText = "Ordine più recente"
        Me.DataMaxOrdini.Name = "DataMaxOrdini"
        Me.DataMaxOrdini.ReadOnly = True
        Me.DataMaxOrdini.ToolTipText = "La data dell'ordine più recente non fatturato"
        Me.DataMaxOrdini.Width = 132
        '
        'DaIncassare
        '
        Me.DaIncassare.DataPropertyName = "EuroDaIncassareStr"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DaIncassare.DefaultCellStyle = DataGridViewCellStyle7
        Me.DaIncassare.HeaderText = "€ da incassare"
        Me.DaIncassare.Name = "DaIncassare"
        Me.DaIncassare.ReadOnly = True
        Me.DaIncassare.Width = 113
        '
        'DataUltPag
        '
        Me.DataUltPag.DataPropertyName = "DataUltPag"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataUltPag.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataUltPag.HeaderText = "Ultimo Pagamento"
        Me.DataUltPag.Name = "DataUltPag"
        Me.DataUltPag.ReadOnly = True
        Me.DataUltPag.Width = 134
        '
        'TotScoperto
        '
        Me.TotScoperto.DataPropertyName = "EuroScopertoStr"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TotScoperto.DefaultCellStyle = DataGridViewCellStyle9
        Me.TotScoperto.HeaderText = "€ Scoperto"
        Me.TotScoperto.Name = "TotScoperto"
        Me.TotScoperto.ReadOnly = True
        Me.TotScoperto.Width = 90
        '
        'ucSituazioneClienti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Red
        Me.Controls.Add(Me.SplitContainerGenerale)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucSituazioneClienti"
        Me.Size = New System.Drawing.Size(972, 465)
        CType(Me.DgSituazClienti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerGenerale.Panel1.ResumeLayout(False)
        Me.SplitContainerGenerale.Panel1.PerformLayout()
        Me.SplitContainerGenerale.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerGenerale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerGenerale.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgSituazClienti As System.Windows.Forms.DataGridView
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents lnkCerca As System.Windows.Forms.LinkLabel
    Friend WithEvents lblClienti As System.Windows.Forms.Label
    Friend WithEvents UcSituazContabEx As Former.ucAmministrazioneSituazioneContabileEx
    Friend WithEvents SplitContainerGenerale As System.Windows.Forms.SplitContainer
    Friend WithEvents RagioneSociale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumOrdini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotOrdini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataMinOrdini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataMaxOrdini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DaIncassare As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataUltPag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotScoperto As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
