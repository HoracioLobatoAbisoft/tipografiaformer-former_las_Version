<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAmministrazioneProcedure
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
        Me.lnkRefresh = New System.Windows.Forms.LinkLabel()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.dgProcedure = New System.Windows.Forms.DataGridView()
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Lavorazione = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RiferitaA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkModFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkDelFormato = New System.Windows.Forms.LinkLabel()
        CType(Me.dgProcedure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkRefresh
        '
        Me.lnkRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRefresh.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRefresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRefresh.Location = New System.Drawing.Point(3, 3)
        Me.lnkRefresh.Name = "lnkRefresh"
        Me.lnkRefresh.Size = New System.Drawing.Size(85, 27)
        Me.lnkRefresh.TabIndex = 56
        Me.lnkRefresh.TabStop = True
        Me.lnkRefresh.Text = "Aggiorna"
        Me.lnkRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Procedura1
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(94, 3)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(131, 27)
        Me.lnkNew.TabIndex = 57
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuova Procedura"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgProcedure
        '
        Me.dgProcedure.AllowUserToAddRows = False
        Me.dgProcedure.AllowUserToDeleteRows = False
        Me.dgProcedure.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgProcedure.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgProcedure.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProcedure.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgProcedure.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgProcedure.BackgroundColor = System.Drawing.Color.White
        Me.dgProcedure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgProcedure.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProcedure.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgProcedure.ColumnHeadersHeight = 20
        Me.dgProcedure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgProcedure.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Img, Me.Lavorazione, Me.Nome, Me.Descrizione, Me.RiferitaA})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProcedure.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgProcedure.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgProcedure.EnableHeadersVisualStyles = False
        Me.dgProcedure.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgProcedure.Location = New System.Drawing.Point(6, 33)
        Me.dgProcedure.MultiSelect = False
        Me.dgProcedure.Name = "dgProcedure"
        Me.dgProcedure.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProcedure.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgProcedure.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgProcedure.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgProcedure.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgProcedure.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgProcedure.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgProcedure.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProcedure.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProcedure.Size = New System.Drawing.Size(796, 504)
        Me.dgProcedure.TabIndex = 82
        Me.dgProcedure.TabStop = False
        '
        'Img
        '
        Me.Img.DataPropertyName = "ImgMacchinario"
        Me.Img.HeaderText = "Macchinario"
        Me.Img.Name = "Img"
        Me.Img.ReadOnly = True
        Me.Img.Width = 78
        '
        'Lavorazione
        '
        Me.Lavorazione.DataPropertyName = "ImgLavorazione"
        Me.Lavorazione.HeaderText = "Lavorazione"
        Me.Lavorazione.Name = "Lavorazione"
        Me.Lavorazione.ReadOnly = True
        Me.Lavorazione.Width = 75
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Nome"
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 64
        '
        'Descrizione
        '
        Me.Descrizione.DataPropertyName = "Descrizione"
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        Me.Descrizione.Width = 91
        '
        'RiferitaA
        '
        Me.RiferitaA.DataPropertyName = "RiferitoA"
        Me.RiferitaA.HeaderText = "Riferita a"
        Me.RiferitaA.Name = "RiferitaA"
        Me.RiferitaA.ReadOnly = True
        Me.RiferitaA.Width = 77
        '
        'lnkModFormato
        '
        Me.lnkModFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModFormato.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkModFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModFormato.Location = New System.Drawing.Point(231, 0)
        Me.lnkModFormato.Name = "lnkModFormato"
        Me.lnkModFormato.Size = New System.Drawing.Size(83, 32)
        Me.lnkModFormato.TabIndex = 89
        Me.lnkModFormato.TabStop = True
        Me.lnkModFormato.Text = "Modifica"
        Me.lnkModFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDelFormato
        '
        Me.lnkDelFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelFormato.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelFormato.Location = New System.Drawing.Point(320, 0)
        Me.lnkDelFormato.Name = "lnkDelFormato"
        Me.lnkDelFormato.Size = New System.Drawing.Size(84, 32)
        Me.lnkDelFormato.TabIndex = 90
        Me.lnkDelFormato.TabStop = True
        Me.lnkDelFormato.Text = "Rimuovi"
        Me.lnkDelFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucAmministrazioneProcedure
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkDelFormato)
        Me.Controls.Add(Me.lnkModFormato)
        Me.Controls.Add(Me.dgProcedure)
        Me.Controls.Add(Me.lnkRefresh)
        Me.Controls.Add(Me.lnkNew)
        Me.Name = "ucAmministrazioneProcedure"
        Me.Size = New System.Drawing.Size(805, 540)
        CType(Me.dgProcedure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lnkRefresh As LinkLabel
    Friend WithEvents lnkNew As LinkLabel
    Friend WithEvents dgProcedure As DataGridView
    Friend WithEvents lnkModFormato As LinkLabel
    Friend WithEvents lnkDelFormato As LinkLabel
    Friend WithEvents Img As DataGridViewImageColumn
    Friend WithEvents Lavorazione As DataGridViewImageColumn
    Friend WithEvents Nome As DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As DataGridViewTextBoxColumn
    Friend WithEvents RiferitaA As DataGridViewTextBoxColumn
End Class
