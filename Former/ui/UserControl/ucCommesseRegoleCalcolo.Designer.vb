<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucCommesseRegoleCalcolo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgRegole = New System.Windows.Forms.DataGridView()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoRegola = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ambito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.lnkEdit = New System.Windows.Forms.LinkLabel()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        CType(Me.DgRegole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgRegole
        '
        Me.DgRegole.AllowUserToAddRows = False
        Me.DgRegole.AllowUserToDeleteRows = False
        Me.DgRegole.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRegole.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgRegole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgRegole.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgRegole.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgRegole.BackgroundColor = System.Drawing.Color.White
        Me.DgRegole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgRegole.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgRegole.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgRegole.ColumnHeadersHeight = 20
        Me.DgRegole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgRegole.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nome, Me.TipoRegola, Me.Ambito, Me.Stato, Me.Valore})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRegole.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgRegole.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgRegole.EnableHeadersVisualStyles = False
        Me.DgRegole.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgRegole.Location = New System.Drawing.Point(3, 33)
        Me.DgRegole.MultiSelect = False
        Me.DgRegole.Name = "DgRegole"
        Me.DgRegole.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRegole.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgRegole.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRegole.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgRegole.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgRegole.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgRegole.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRegole.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRegole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgRegole.Size = New System.Drawing.Size(799, 504)
        Me.DgRegole.TabIndex = 61
        Me.DgRegole.TabStop = False
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Nome"
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 64
        '
        'TipoRegola
        '
        Me.TipoRegola.DataPropertyName = "TipoRegolaStr"
        Me.TipoRegola.HeaderText = "Tipo Regola"
        Me.TipoRegola.Name = "TipoRegola"
        Me.TipoRegola.ReadOnly = True
        Me.TipoRegola.Width = 94
        '
        'Ambito
        '
        Me.Ambito.DataPropertyName = "AmbitoStr"
        Me.Ambito.HeaderText = "Si applica a"
        Me.Ambito.Name = "Ambito"
        Me.Ambito.ReadOnly = True
        Me.Ambito.Width = 90
        '
        'Stato
        '
        Me.Stato.DataPropertyName = "StatoStr"
        Me.Stato.HeaderText = "Stato"
        Me.Stato.Name = "Stato"
        Me.Stato.ReadOnly = True
        Me.Stato.Width = 58
        '
        'Valore
        '
        Me.Valore.DataPropertyName = "Valore"
        Me.Valore.HeaderText = "Valore"
        Me.Valore.Name = "Valore"
        Me.Valore.ReadOnly = True
        Me.Valore.Width = 63
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(92, 3)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(71, 27)
        Me.lnkNew.TabIndex = 63
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAll
        '
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(3, 3)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Size = New System.Drawing.Size(83, 26)
        Me.lnkAll.TabIndex = 62
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Aggiorna"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkEdit
        '
        Me.lnkEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkEdit.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkEdit.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkEdit.Location = New System.Drawing.Point(169, 3)
        Me.lnkEdit.Name = "lnkEdit"
        Me.lnkEdit.Size = New System.Drawing.Size(82, 27)
        Me.lnkEdit.TabIndex = 82
        Me.lnkEdit.TabStop = True
        Me.lnkEdit.Text = "Modifica"
        Me.lnkEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDel
        '
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(257, 3)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Size = New System.Drawing.Size(77, 27)
        Me.lnkDel.TabIndex = 81
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Elimina"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucCommesseRegoleCalcolo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkEdit)
        Me.Controls.Add(Me.lnkDel)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.lnkAll)
        Me.Controls.Add(Me.DgRegole)
        Me.Name = "ucCommesseRegoleCalcolo"
        Me.Size = New System.Drawing.Size(805, 540)
        CType(Me.DgRegole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgRegole As DataGridView
    Friend WithEvents lnkNew As LinkLabel
    Friend WithEvents lnkAll As LinkLabel
    Friend WithEvents Nome As DataGridViewTextBoxColumn
    Friend WithEvents TipoRegola As DataGridViewTextBoxColumn
    Friend WithEvents Ambito As DataGridViewTextBoxColumn
    Friend WithEvents Stato As DataGridViewTextBoxColumn
    Friend WithEvents Valore As DataGridViewTextBoxColumn
    Friend WithEvents lnkEdit As LinkLabel
    Friend WithEvents lnkDel As LinkLabel
End Class
