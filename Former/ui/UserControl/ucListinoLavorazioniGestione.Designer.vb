<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoLavorazioniGestione
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucListinoLavorazioniGestione))
        Me.cmbMacchinari = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lnkModLav = New System.Windows.Forms.LinkLabel()
        Me.lnkDelLav = New System.Windows.Forms.LinkLabel()
        Me.lnkAggiungiLav = New System.Windows.Forms.LinkLabel()
        Me.DgLavorazioni = New System.Windows.Forms.DataGridView()
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoriaLav = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuCommessa = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SuProdotto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Macchinario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.imlTvw = New System.Windows.Forms.ImageList(Me.components)
        Me.tvwCat = New System.Windows.Forms.TreeView()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.lnkEditCatLav = New System.Windows.Forms.LinkLabel()
        Me.lnkNewCatLav = New System.Windows.Forms.LinkLabel()
        Me.lnkDuplica = New System.Windows.Forms.LinkLabel()
        CType(Me.DgLavorazioni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbMacchinari
        '
        Me.cmbMacchinari.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMacchinari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMacchinari.FormattingEnabled = True
        Me.cmbMacchinari.Location = New System.Drawing.Point(415, 9)
        Me.cmbMacchinari.Name = "cmbMacchinari"
        Me.cmbMacchinari.Size = New System.Drawing.Size(155, 23)
        Me.cmbMacchinari.TabIndex = 111
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(348, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Macchinari"
        '
        'lnkModLav
        '
        Me.lnkModLav.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkModLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModLav.Image = Global.Former.My.Resources._Modifica
        Me.lnkModLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModLav.Location = New System.Drawing.Point(764, 3)
        Me.lnkModLav.Name = "lnkModLav"
        Me.lnkModLav.Size = New System.Drawing.Size(82, 32)
        Me.lnkModLav.TabIndex = 106
        Me.lnkModLav.TabStop = True
        Me.lnkModLav.Text = "Modifica"
        Me.lnkModLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDelLav
        '
        Me.lnkDelLav.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDelLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelLav.Image = Global.Former.My.Resources._Elimina
        Me.lnkDelLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelLav.Location = New System.Drawing.Point(852, 3)
        Me.lnkDelLav.Name = "lnkDelLav"
        Me.lnkDelLav.Size = New System.Drawing.Size(82, 32)
        Me.lnkDelLav.TabIndex = 105
        Me.lnkDelLav.TabStop = True
        Me.lnkDelLav.Text = "Rimuovi"
        Me.lnkDelLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAggiungiLav
        '
        Me.lnkAggiungiLav.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiungiLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiungiLav.Image = Global.Former.My.Resources._Aggiungi
        Me.lnkAggiungiLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiungiLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiungiLav.Location = New System.Drawing.Point(676, 3)
        Me.lnkAggiungiLav.Name = "lnkAggiungiLav"
        Me.lnkAggiungiLav.Size = New System.Drawing.Size(82, 32)
        Me.lnkAggiungiLav.TabIndex = 104
        Me.lnkAggiungiLav.TabStop = True
        Me.lnkAggiungiLav.Text = "Aggiungi"
        Me.lnkAggiungiLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgLavorazioni
        '
        Me.DgLavorazioni.AllowUserToAddRows = False
        Me.DgLavorazioni.AllowUserToDeleteRows = False
        Me.DgLavorazioni.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLavorazioni.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLavorazioni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgLavorazioni.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgLavorazioni.BackgroundColor = System.Drawing.Color.White
        Me.DgLavorazioni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLavorazioni.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavorazioni.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLavorazioni.ColumnHeadersHeight = 20
        Me.DgLavorazioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLavorazioni.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Img, Me.DataGridViewTextBoxColumn5, Me.CategoriaLav, Me.Descrizione, Me.SuCommessa, Me.SuProdotto, Me.Macchinario})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavorazioni.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgLavorazioni.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavorazioni.EnableHeadersVisualStyles = False
        Me.DgLavorazioni.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavorazioni.Location = New System.Drawing.Point(447, 41)
        Me.DgLavorazioni.MultiSelect = False
        Me.DgLavorazioni.Name = "DgLavorazioni"
        Me.DgLavorazioni.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavorazioni.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgLavorazioni.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgLavorazioni.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLavorazioni.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavorazioni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavorazioni.Size = New System.Drawing.Size(487, 349)
        Me.DgLavorazioni.TabIndex = 102
        Me.DgLavorazioni.TabStop = False
        '
        'Img
        '
        Me.Img.DataPropertyName = "Img"
        Me.Img.HeaderText = "Img"
        Me.Img.Name = "Img"
        Me.Img.ReadOnly = True
        Me.Img.Width = 33
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Sigla"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Sigla"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 59
        '
        'CategoriaLav
        '
        Me.CategoriaLav.DataPropertyName = "CatLav"
        Me.CategoriaLav.HeaderText = "Categoria"
        Me.CategoriaLav.Name = "CategoriaLav"
        Me.CategoriaLav.ReadOnly = True
        Me.CategoriaLav.Width = 85
        '
        'Descrizione
        '
        Me.Descrizione.DataPropertyName = "Descrizione"
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        Me.Descrizione.Width = 96
        '
        'SuCommessa
        '
        Me.SuCommessa.DataPropertyName = "Accorpabile"
        Me.SuCommessa.HeaderText = "Accorpabile"
        Me.SuCommessa.Name = "SuCommessa"
        Me.SuCommessa.ReadOnly = True
        Me.SuCommessa.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SuCommessa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SuCommessa.Width = 95
        '
        'SuProdotto
        '
        Me.SuProdotto.DataPropertyName = "Esclusiva"
        Me.SuProdotto.HeaderText = "Esclusiva"
        Me.SuProdotto.Name = "SuProdotto"
        Me.SuProdotto.ReadOnly = True
        Me.SuProdotto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SuProdotto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SuProdotto.Width = 84
        '
        'Macchinario
        '
        Me.Macchinario.DataPropertyName = "Macchinario"
        Me.Macchinario.HeaderText = "Macchinario"
        Me.Macchinario.Name = "Macchinario"
        Me.Macchinario.ReadOnly = True
        Me.Macchinario.Width = 97
        '
        'imlTvw
        '
        Me.imlTvw.ImageStream = CType(resources.GetObject("imlTvw.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTvw.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTvw.Images.SetKeyName(0, "Entry Feed.png")
        Me.imlTvw.Images.SetKeyName(1, "File New.png")
        Me.imlTvw.Images.SetKeyName(2, "Auction.png")
        '
        'tvwCat
        '
        Me.tvwCat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvwCat.ImageIndex = 0
        Me.tvwCat.ImageList = Me.imlTvw
        Me.tvwCat.Location = New System.Drawing.Point(3, 41)
        Me.tvwCat.Name = "tvwCat"
        Me.tvwCat.SelectedImageIndex = 0
        Me.tvwCat.Size = New System.Drawing.Size(438, 349)
        Me.tvwCat.TabIndex = 112
        '
        'btnAggiorna
        '
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggiorna.Image = Global.Former.My.Resources._Aggiorna
        Me.btnAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiorna.Location = New System.Drawing.Point(3, 3)
        Me.btnAggiorna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(95, 32)
        Me.btnAggiorna.TabIndex = 113
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'lnkEditCatLav
        '
        Me.lnkEditCatLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkEditCatLav.Image = Global.Former.My.Resources._Modifica
        Me.lnkEditCatLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkEditCatLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkEditCatLav.Location = New System.Drawing.Point(192, 3)
        Me.lnkEditCatLav.Name = "lnkEditCatLav"
        Me.lnkEditCatLav.Size = New System.Drawing.Size(82, 32)
        Me.lnkEditCatLav.TabIndex = 115
        Me.lnkEditCatLav.TabStop = True
        Me.lnkEditCatLav.Text = "Modifica"
        Me.lnkEditCatLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNewCatLav
        '
        Me.lnkNewCatLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNewCatLav.Image = Global.Former.My.Resources._Aggiungi
        Me.lnkNewCatLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNewCatLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNewCatLav.Location = New System.Drawing.Point(104, 3)
        Me.lnkNewCatLav.Name = "lnkNewCatLav"
        Me.lnkNewCatLav.Size = New System.Drawing.Size(82, 32)
        Me.lnkNewCatLav.TabIndex = 114
        Me.lnkNewCatLav.TabStop = True
        Me.lnkNewCatLav.Text = "Aggiungi"
        Me.lnkNewCatLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDuplica
        '
        Me.lnkDuplica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDuplica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDuplica.Image = Global.Former.My.Resources._Duplica
        Me.lnkDuplica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDuplica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDuplica.Location = New System.Drawing.Point(591, 3)
        Me.lnkDuplica.Name = "lnkDuplica"
        Me.lnkDuplica.Size = New System.Drawing.Size(79, 32)
        Me.lnkDuplica.TabIndex = 116
        Me.lnkDuplica.TabStop = True
        Me.lnkDuplica.Text = "Duplica"
        Me.lnkDuplica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucListinoLavorazioniGestione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkDuplica)
        Me.Controls.Add(Me.lnkEditCatLav)
        Me.Controls.Add(Me.lnkNewCatLav)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.tvwCat)
        Me.Controls.Add(Me.cmbMacchinari)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lnkModLav)
        Me.Controls.Add(Me.lnkDelLav)
        Me.Controls.Add(Me.lnkAggiungiLav)
        Me.Controls.Add(Me.DgLavorazioni)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucListinoLavorazioniGestione"
        Me.Size = New System.Drawing.Size(937, 393)
        CType(Me.DgLavorazioni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMacchinari As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lnkModLav As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDelLav As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAggiungiLav As System.Windows.Forms.LinkLabel
    Friend WithEvents DgLavorazioni As System.Windows.Forms.DataGridView
    Friend WithEvents imlTvw As System.Windows.Forms.ImageList
    Friend WithEvents tvwCat As System.Windows.Forms.TreeView
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents Img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategoriaLav As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuCommessa As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SuProdotto As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Macchinario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkEditCatLav As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNewCatLav As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDuplica As System.Windows.Forms.LinkLabel

End Class
