<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoProdotti
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucListinoProdotti))
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.DgListino = New System.Windows.Forms.DataGridView()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.txtCercaCli = New System.Windows.Forms.TextBox()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.mnuVoce = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EliminaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lnkExport = New System.Windows.Forms.LinkLabel()
        Me.tvwCat = New System.Windows.Forms.TreeView()
        Me.imlTvw = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkNewCat = New System.Windows.Forms.LinkLabel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lnkModifica = New System.Windows.Forms.LinkLabel()
        Me.btnEspandi = New System.Windows.Forms.Button()
        Me.btnRiduci = New System.Windows.Forms.Button()
        Me.lnkPubblico = New System.Windows.Forms.LinkLabel()
        Me.FormatoProdotto = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TipoCarta = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Codice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prezzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrezzoPubbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PzFat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Spazi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duplicati = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGNorm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGFast = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercFast = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgListino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuVoce.SuspendLayout()
        Me.SuspendLayout()
        '
        'lnkNew
        '
        Me.lnkNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.icoProdNew
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(905, 0)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(86, 35)
        Me.lnkNew.TabIndex = 43
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo..."
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgListino
        '
        Me.DgListino.AllowUserToAddRows = False
        Me.DgListino.AllowUserToDeleteRows = False
        Me.DgListino.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgListino.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgListino.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgListino.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgListino.BackgroundColor = System.Drawing.Color.White
        Me.DgListino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgListino.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgListino.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgListino.ColumnHeadersHeight = 20
        Me.DgListino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgListino.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FormatoProdotto, Me.TipoCarta, Me.Codice, Me.Descrizione, Me.Prezzo, Me.PrezzoPubbl, Me.PzFat, Me.Spazi, Me.Duplicati, Me.GGNorm, Me.GGFast, Me.PercFast})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgListino.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgListino.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgListino.EnableHeadersVisualStyles = False
        Me.DgListino.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgListino.Location = New System.Drawing.Point(270, 36)
        Me.DgListino.MultiSelect = False
        Me.DgListino.Name = "DgListino"
        Me.DgListino.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgListino.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgListino.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgListino.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgListino.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgListino.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgListino.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgListino.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgListino.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgListino.Size = New System.Drawing.Size(721, 346)
        Me.DgListino.TabIndex = 41
        Me.DgListino.TabStop = False
        '
        'lnkStampa
        '
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.icoPrint1
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(628, 5)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(79, 24)
        Me.lnkStampa.TabIndex = 40
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
        Me.lnkAll.Location = New System.Drawing.Point(548, 3)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Size = New System.Drawing.Size(74, 30)
        Me.lnkAll.TabIndex = 39
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Mostra"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCercaCli
        '
        Me.txtCercaCli.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCercaCli.Location = New System.Drawing.Point(270, 7)
        Me.txtCercaCli.Name = "txtCercaCli"
        Me.txtCercaCli.Size = New System.Drawing.Size(198, 21)
        Me.txtCercaCli.TabIndex = 44
        Me.txtCercaCli.Text = "{inserire qui il codice o la descrizione da cercare}"
        '
        'lnkCerca
        '
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.icoCerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(474, 2)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(68, 30)
        Me.lnkCerca.TabIndex = 45
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Cerca"
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnuVoce
        '
        Me.mnuVoce.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaToolStripMenuItem, Me.ToolStripSeparator1, Me.EliminaToolStripMenuItem})
        Me.mnuVoce.Name = "mnuVoce"
        Me.mnuVoce.Size = New System.Drawing.Size(120, 54)
        '
        'ModificaToolStripMenuItem
        '
        Me.ModificaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ModificaToolStripMenuItem.Name = "ModificaToolStripMenuItem"
        Me.ModificaToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ModificaToolStripMenuItem.Text = "Modifica"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(116, 6)
        '
        'EliminaToolStripMenuItem
        '
        Me.EliminaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.EliminaToolStripMenuItem.Name = "EliminaToolStripMenuItem"
        Me.EliminaToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.EliminaToolStripMenuItem.Text = "Elimina"
        '
        'lnkExport
        '
        Me.lnkExport.Enabled = False
        Me.lnkExport.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkExport.Image = Global.Former.My.Resources.icoGiu
        Me.lnkExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkExport.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkExport.Location = New System.Drawing.Point(713, 6)
        Me.lnkExport.Name = "lnkExport"
        Me.lnkExport.Size = New System.Drawing.Size(79, 24)
        Me.lnkExport.TabIndex = 46
        Me.lnkExport.TabStop = True
        Me.lnkExport.Text = "Esporta"
        Me.lnkExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tvwCat
        '
        Me.tvwCat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvwCat.ImageIndex = 0
        Me.tvwCat.ImageList = Me.imlTvw
        Me.tvwCat.Location = New System.Drawing.Point(3, 35)
        Me.tvwCat.Name = "tvwCat"
        Me.tvwCat.SelectedImageIndex = 0
        Me.tvwCat.ShowRootLines = False
        Me.tvwCat.Size = New System.Drawing.Size(261, 347)
        Me.tvwCat.TabIndex = 48
        '
        'imlTvw
        '
        Me.imlTvw.ImageStream = CType(resources.GetObject("imlTvw.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTvw.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTvw.Images.SetKeyName(0, "icoProd.jpg")
        '
        'lnkNewCat
        '
        Me.lnkNewCat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNewCat.Image = Global.Former.My.Resources.icoProdNew
        Me.lnkNewCat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNewCat.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkNewCat.Location = New System.Drawing.Point(99, 1)
        Me.lnkNewCat.Name = "lnkNewCat"
        Me.lnkNewCat.Size = New System.Drawing.Size(78, 35)
        Me.lnkNewCat.TabIndex = 49
        Me.lnkNewCat.TabStop = True
        Me.lnkNewCat.Text = "Nuova"
        Me.lnkNewCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = Global.Former.My.Resources.icoRefresh
        Me.btnRefresh.Location = New System.Drawing.Point(9, 1)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(24, 27)
        Me.btnRefresh.TabIndex = 51
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lnkModifica
        '
        Me.lnkModifica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModifica.Image = Global.Former.My.Resources.icoProd
        Me.lnkModifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModifica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkModifica.Location = New System.Drawing.Point(183, 1)
        Me.lnkModifica.Name = "lnkModifica"
        Me.lnkModifica.Size = New System.Drawing.Size(81, 35)
        Me.lnkModifica.TabIndex = 49
        Me.lnkModifica.TabStop = True
        Me.lnkModifica.Text = "Modifica"
        Me.lnkModifica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnEspandi
        '
        Me.btnEspandi.FlatAppearance.BorderSize = 0
        Me.btnEspandi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEspandi.Image = Global.Former.My.Resources.icoAdd
        Me.btnEspandi.Location = New System.Drawing.Point(39, 1)
        Me.btnEspandi.Name = "btnEspandi"
        Me.btnEspandi.Size = New System.Drawing.Size(24, 27)
        Me.btnEspandi.TabIndex = 52
        Me.btnEspandi.UseVisualStyleBackColor = True
        '
        'btnRiduci
        '
        Me.btnRiduci.FlatAppearance.BorderSize = 0
        Me.btnRiduci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRiduci.Image = Global.Former.My.Resources.icoDel
        Me.btnRiduci.Location = New System.Drawing.Point(69, 1)
        Me.btnRiduci.Name = "btnRiduci"
        Me.btnRiduci.Size = New System.Drawing.Size(24, 27)
        Me.btnRiduci.TabIndex = 53
        Me.btnRiduci.UseVisualStyleBackColor = True
        '
        'lnkPubblico
        '
        Me.lnkPubblico.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkPubblico.Image = Global.Former.My.Resources.icoOrder
        Me.lnkPubblico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPubblico.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkPubblico.Location = New System.Drawing.Point(798, 6)
        Me.lnkPubblico.Name = "lnkPubblico"
        Me.lnkPubblico.Size = New System.Drawing.Size(79, 24)
        Me.lnkPubblico.TabIndex = 54
        Me.lnkPubblico.TabStop = True
        Me.lnkPubblico.Text = "Pubblico"
        Me.lnkPubblico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormatoProdotto
        '
        Me.FormatoProdotto.DataPropertyName = "FormatoAnteprima32"
        Me.FormatoProdotto.HeaderText = "Formato"
        Me.FormatoProdotto.Name = "FormatoProdotto"
        Me.FormatoProdotto.ReadOnly = True
        Me.FormatoProdotto.Width = 70
        '
        'TipoCarta
        '
        Me.TipoCarta.DataPropertyName = "TipoCartaAnteprima32"
        Me.TipoCarta.HeaderText = "TipoCarta"
        Me.TipoCarta.Name = "TipoCarta"
        Me.TipoCarta.ReadOnly = True
        Me.TipoCarta.Width = 70
        '
        'Codice
        '
        Me.Codice.DataPropertyName = "Codice"
        Me.Codice.HeaderText = "Codice"
        Me.Codice.Name = "Codice"
        Me.Codice.ReadOnly = True
        '
        'Descrizione
        '
        Me.Descrizione.DataPropertyName = "Descrizione"
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        Me.Descrizione.Width = 200
        '
        'Prezzo
        '
        Me.Prezzo.DataPropertyName = "Prezzo"
        Me.Prezzo.HeaderText = "€"
        Me.Prezzo.Name = "Prezzo"
        Me.Prezzo.ReadOnly = True
        Me.Prezzo.Width = 70
        '
        'PrezzoPubbl
        '
        Me.PrezzoPubbl.DataPropertyName = "PrezzoPubbl"
        Me.PrezzoPubbl.HeaderText = "€ Pub."
        Me.PrezzoPubbl.Name = "PrezzoPubbl"
        Me.PrezzoPubbl.ReadOnly = True
        Me.PrezzoPubbl.Width = 70
        '
        'PzFat
        '
        Me.PzFat.DataPropertyName = "NumPezzi"
        Me.PzFat.HeaderText = "Pz Fat."
        Me.PzFat.Name = "PzFat"
        Me.PzFat.ReadOnly = True
        Me.PzFat.Width = 50
        '
        'Spazi
        '
        Me.Spazi.DataPropertyName = "NumSpazi"
        Me.Spazi.HeaderText = "Spazi"
        Me.Spazi.Name = "Spazi"
        Me.Spazi.ReadOnly = True
        Me.Spazi.Width = 50
        '
        'Duplicati
        '
        Me.Duplicati.DataPropertyName = "NumDuplic"
        Me.Duplicati.HeaderText = "Duplic"
        Me.Duplicati.Name = "Duplicati"
        Me.Duplicati.ReadOnly = True
        Me.Duplicati.Width = 50
        '
        'GGNorm
        '
        Me.GGNorm.DataPropertyName = "GGNormale"
        Me.GGNorm.HeaderText = "GGNorm"
        Me.GGNorm.Name = "GGNorm"
        Me.GGNorm.ReadOnly = True
        Me.GGNorm.Width = 60
        '
        'GGFast
        '
        Me.GGFast.DataPropertyName = "GGFast"
        Me.GGFast.HeaderText = "GGFast"
        Me.GGFast.Name = "GGFast"
        Me.GGFast.ReadOnly = True
        Me.GGFast.Width = 60
        '
        'PercFast
        '
        Me.PercFast.DataPropertyName = "PercFast"
        Me.PercFast.HeaderText = "% Fast"
        Me.PercFast.Name = "PercFast"
        Me.PercFast.ReadOnly = True
        Me.PercFast.Width = 50
        '
        'ucProdotti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lnkPubblico)
        Me.Controls.Add(Me.btnRiduci)
        Me.Controls.Add(Me.btnEspandi)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.tvwCat)
        Me.Controls.Add(Me.lnkNewCat)
        Me.Controls.Add(Me.DgListino)
        Me.Controls.Add(Me.lnkModifica)
        Me.Controls.Add(Me.txtCercaCli)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.lnkExport)
        Me.Controls.Add(Me.lnkCerca)
        Me.Controls.Add(Me.lnkAll)
        Me.Controls.Add(Me.lnkStampa)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucProdotti"
        Me.Size = New System.Drawing.Size(997, 388)
        CType(Me.DgListino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuVoce.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents DgListino As System.Windows.Forms.DataGridView
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAll As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCercaCli As System.Windows.Forms.TextBox
    Friend WithEvents lnkCerca As System.Windows.Forms.LinkLabel
    Friend WithEvents mnuVoce As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EliminaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lnkExport As System.Windows.Forms.LinkLabel
    Friend WithEvents tvwCat As System.Windows.Forms.TreeView
    Friend WithEvents imlTvw As System.Windows.Forms.ImageList
    Friend WithEvents lnkNewCat As System.Windows.Forms.LinkLabel
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lnkModifica As System.Windows.Forms.LinkLabel
    Friend WithEvents btnEspandi As System.Windows.Forms.Button
    Friend WithEvents btnRiduci As System.Windows.Forms.Button
    Friend WithEvents lnkPubblico As System.Windows.Forms.LinkLabel
    Friend WithEvents FormatoProdotto As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents TipoCarta As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Codice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prezzo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrezzoPubbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PzFat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Spazi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Duplicati As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GGNorm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GGFast As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PercFast As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
