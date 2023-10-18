<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAmministrazioneF24
    Inherits ucFormerUserControl


    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgF24 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkDelFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkModFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkRefresh = New System.Windows.Forms.LinkLabel()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.txtTesto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgF24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgF24
        '
        Me.dgF24.AllowUserToAddRows = False
        Me.dgF24.AllowUserToDeleteRows = False
        Me.dgF24.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.dgF24.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgF24.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgF24.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgF24.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgF24.BackgroundColor = System.Drawing.Color.White
        Me.dgF24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgF24.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgF24.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgF24.ColumnHeadersHeight = 20
        Me.dgF24.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgF24.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column4, Me.Column5})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgF24.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgF24.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgF24.EnableHeadersVisualStyles = False
        Me.dgF24.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgF24.Location = New System.Drawing.Point(6, 35)
        Me.dgF24.MultiSelect = False
        Me.dgF24.Name = "dgF24"
        Me.dgF24.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgF24.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgF24.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgF24.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgF24.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgF24.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgF24.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgF24.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgF24.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgF24.Size = New System.Drawing.Size(796, 504)
        Me.dgF24.TabIndex = 93
        Me.dgF24.TabStop = False
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "AziendaStr"
        Me.Column1.HeaderText = "Azienda"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 73
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Descrizione"
        Me.Column3.HeaderText = "Descrizione"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 91
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "ImportoStr"
        Me.Column4.HeaderText = "Importo"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 74
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "PagatoIlStr"
        Me.Column5.HeaderText = "Pagato il"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 77
        '
        'lnkDelFormato
        '
        Me.lnkDelFormato.AutoSize = True
        Me.lnkDelFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelFormato.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelFormato.Location = New System.Drawing.Point(193, 5)
        Me.lnkDelFormato.Name = "lnkDelFormato"
        Me.lnkDelFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDelFormato.Size = New System.Drawing.Size(81, 27)
        Me.lnkDelFormato.TabIndex = 95
        Me.lnkDelFormato.TabStop = True
        Me.lnkDelFormato.Text = "Rimuovi"
        Me.lnkDelFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkModFormato
        '
        Me.lnkModFormato.AutoSize = True
        Me.lnkModFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModFormato.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkModFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModFormato.Location = New System.Drawing.Point(103, 5)
        Me.lnkModFormato.Name = "lnkModFormato"
        Me.lnkModFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkModFormato.Size = New System.Drawing.Size(84, 27)
        Me.lnkModFormato.TabIndex = 94
        Me.lnkModFormato.TabStop = True
        Me.lnkModFormato.Text = "Modifica"
        Me.lnkModFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkRefresh
        '
        Me.lnkRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkRefresh.AutoSize = True
        Me.lnkRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRefresh.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRefresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRefresh.Location = New System.Drawing.Point(735, 5)
        Me.lnkRefresh.Name = "lnkRefresh"
        Me.lnkRefresh.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkRefresh.Size = New System.Drawing.Size(67, 27)
        Me.lnkRefresh.TabIndex = 91
        Me.lnkRefresh.TabStop = True
        Me.lnkRefresh.Text = "Cerca"
        Me.lnkRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNew
        '
        Me.lnkNew.AutoSize = True
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._F24
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(3, 5)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkNew.Size = New System.Drawing.Size(94, 27)
        Me.lnkNew.TabIndex = 92
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo F24"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTesto
        '
        Me.txtTesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTesto.Location = New System.Drawing.Point(637, 8)
        Me.txtTesto.Name = "txtTesto"
        Me.txtTesto.Size = New System.Drawing.Size(92, 23)
        Me.txtTesto.TabIndex = 96
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(547, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Codice Tributo"
        '
        'ucAmministrazioneF24
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTesto)
        Me.Controls.Add(Me.lnkDelFormato)
        Me.Controls.Add(Me.lnkModFormato)
        Me.Controls.Add(Me.dgF24)
        Me.Controls.Add(Me.lnkRefresh)
        Me.Controls.Add(Me.lnkNew)
        Me.Name = "ucAmministrazioneF24"
        Me.Size = New System.Drawing.Size(805, 540)
        CType(Me.dgF24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lnkDelFormato As LinkLabel
    Friend WithEvents lnkModFormato As LinkLabel
    Friend WithEvents dgF24 As DataGridView
    Friend WithEvents lnkRefresh As LinkLabel
    Friend WithEvents lnkNew As LinkLabel
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents txtTesto As TextBox
    Friend WithEvents Label1 As Label
End Class
