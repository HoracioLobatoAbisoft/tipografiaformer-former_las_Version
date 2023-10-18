<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazioneOrdiniBonifico
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucAmministrazioneOrdiniBonifico))
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.DgOrdini = New System.Windows.Forms.DataGridView()
        Me.IdOrdLista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataIns = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Com = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkRegistraPagam = New System.Windows.Forms.LinkLabel()
        Me.lnkSitoBanca = New System.Windows.Forms.LinkLabel()
        Me.tbBonifici = New System.Windows.Forms.TabControl()
        Me.tpBonifici = New System.Windows.Forms.TabPage()
        Me.tpStorico = New System.Windows.Forms.TabPage()
        Me.DGOrdiniStorico = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkCercaStorico = New System.Windows.Forms.LinkLabel()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbBonifici.SuspendLayout()
        Me.tpBonifici.SuspendLayout()
        Me.tpStorico.SuspendLayout()
        CType(Me.DGOrdiniStorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkCerca
        '
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(6, 3)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(109, 27)
        Me.lnkCerca.TabIndex = 55
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Avvia ricerca..."
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgOrdini
        '
        Me.DgOrdini.AllowUserToAddRows = False
        Me.DgOrdini.AllowUserToDeleteRows = False
        Me.DgOrdini.AllowUserToOrderColumns = True
        Me.DgOrdini.AllowUserToResizeRows = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DgOrdini.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgOrdini.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.DgOrdini.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgOrdini.BackgroundColor = System.Drawing.Color.White
        Me.DgOrdini.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgOrdini.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgOrdini.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DgOrdini.ColumnHeadersHeight = 20
        Me.DgOrdini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgOrdini.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOrdLista, Me.DataIns, Me.Com, Me.QtaOrd})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.DefaultCellStyle = DataGridViewCellStyle15
        Me.DgOrdini.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgOrdini.EnableHeadersVisualStyles = False
        Me.DgOrdini.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgOrdini.Location = New System.Drawing.Point(6, 33)
        Me.DgOrdini.MultiSelect = False
        Me.DgOrdini.Name = "DgOrdini"
        Me.DgOrdini.ReadOnly = True
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.DgOrdini.RowHeadersVisible = False
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowsDefaultCellStyle = DataGridViewCellStyle17
        Me.DgOrdini.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgOrdini.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgOrdini.Size = New System.Drawing.Size(975, 400)
        Me.DgOrdini.TabIndex = 56
        Me.DgOrdini.TabStop = False
        '
        'IdOrdLista
        '
        Me.IdOrdLista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IdOrdLista.DataPropertyName = "IdConsegna"
        Me.IdOrdLista.HeaderText = "Ordine"
        Me.IdOrdLista.Name = "IdOrdLista"
        Me.IdOrdLista.ReadOnly = True
        Me.IdOrdLista.Width = 45
        '
        'DataIns
        '
        Me.DataIns.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataIns.DataPropertyName = "DataInserimentoStr"
        Me.DataIns.HeaderText = "Data"
        Me.DataIns.Name = "DataIns"
        Me.DataIns.ReadOnly = True
        '
        'Com
        '
        Me.Com.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Com.DataPropertyName = "NomeCliente"
        Me.Com.HeaderText = "Cliente"
        Me.Com.MinimumWidth = 500
        Me.Com.Name = "Com"
        Me.Com.ReadOnly = True
        Me.Com.Width = 500
        '
        'QtaOrd
        '
        Me.QtaOrd.DataPropertyName = "ImportoTotStr"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.QtaOrd.DefaultCellStyle = DataGridViewCellStyle14
        Me.QtaOrd.HeaderText = "Importo"
        Me.QtaOrd.MinimumWidth = 100
        Me.QtaOrd.Name = "QtaOrd"
        Me.QtaOrd.ReadOnly = True
        '
        'lnkRegistraPagam
        '
        Me.lnkRegistraPagam.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkRegistraPagam.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRegistraPagam.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkRegistraPagam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRegistraPagam.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRegistraPagam.Location = New System.Drawing.Point(855, 3)
        Me.lnkRegistraPagam.Name = "lnkRegistraPagam"
        Me.lnkRegistraPagam.Size = New System.Drawing.Size(126, 27)
        Me.lnkRegistraPagam.TabIndex = 60
        Me.lnkRegistraPagam.TabStop = True
        Me.lnkRegistraPagam.Text = "Registra Bonifico"
        Me.lnkRegistraPagam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkSitoBanca
        '
        Me.lnkSitoBanca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkSitoBanca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkSitoBanca.Image = Global.Former.My.Resources.Resources._bank
        Me.lnkSitoBanca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSitoBanca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSitoBanca.Location = New System.Drawing.Point(703, 3)
        Me.lnkSitoBanca.Name = "lnkSitoBanca"
        Me.lnkSitoBanca.Size = New System.Drawing.Size(146, 27)
        Me.lnkSitoBanca.TabIndex = 61
        Me.lnkSitoBanca.TabStop = True
        Me.lnkSitoBanca.Text = "Vai al sito della Banca"
        Me.lnkSitoBanca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBonifici
        '
        Me.tbBonifici.Controls.Add(Me.tpBonifici)
        Me.tbBonifici.Controls.Add(Me.tpStorico)
        Me.tbBonifici.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbBonifici.ImageList = Me.imlTab
        Me.tbBonifici.Location = New System.Drawing.Point(0, 0)
        Me.tbBonifici.Name = "tbBonifici"
        Me.tbBonifici.SelectedIndex = 0
        Me.tbBonifici.Size = New System.Drawing.Size(995, 470)
        Me.tbBonifici.TabIndex = 62
        '
        'tpBonifici
        '
        Me.tpBonifici.Controls.Add(Me.lnkCerca)
        Me.tpBonifici.Controls.Add(Me.DgOrdini)
        Me.tpBonifici.Controls.Add(Me.lnkRegistraPagam)
        Me.tpBonifici.Controls.Add(Me.lnkSitoBanca)
        Me.tpBonifici.ImageKey = "ico_BO_R.png"
        Me.tpBonifici.Location = New System.Drawing.Point(4, 27)
        Me.tpBonifici.Name = "tpBonifici"
        Me.tpBonifici.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBonifici.Size = New System.Drawing.Size(987, 439)
        Me.tpBonifici.TabIndex = 0
        Me.tpBonifici.Text = "Bonifici da registrare"
        Me.tpBonifici.UseVisualStyleBackColor = True
        '
        'tpStorico
        '
        Me.tpStorico.Controls.Add(Me.DGOrdiniStorico)
        Me.tpStorico.Controls.Add(Me.lnkCercaStorico)
        Me.tpStorico.ImageKey = "ico_SB_R.png"
        Me.tpStorico.Location = New System.Drawing.Point(4, 27)
        Me.tpStorico.Name = "tpStorico"
        Me.tpStorico.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStorico.Size = New System.Drawing.Size(987, 439)
        Me.tpStorico.TabIndex = 1
        Me.tpStorico.Text = "Storico Bonifici"
        Me.tpStorico.UseVisualStyleBackColor = True
        '
        'DGOrdiniStorico
        '
        Me.DGOrdiniStorico.AllowUserToAddRows = False
        Me.DGOrdiniStorico.AllowUserToDeleteRows = False
        Me.DGOrdiniStorico.AllowUserToOrderColumns = True
        Me.DGOrdiniStorico.AllowUserToResizeRows = False
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdiniStorico.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle18
        Me.DGOrdiniStorico.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGOrdiniStorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.DGOrdiniStorico.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGOrdiniStorico.BackgroundColor = System.Drawing.Color.White
        Me.DGOrdiniStorico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGOrdiniStorico.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGOrdiniStorico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.DGOrdiniStorico.ColumnHeadersHeight = 20
        Me.DGOrdiniStorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGOrdiniStorico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdiniStorico.DefaultCellStyle = DataGridViewCellStyle20
        Me.DGOrdiniStorico.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGOrdiniStorico.EnableHeadersVisualStyles = False
        Me.DGOrdiniStorico.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGOrdiniStorico.Location = New System.Drawing.Point(6, 33)
        Me.DGOrdiniStorico.MultiSelect = False
        Me.DGOrdiniStorico.Name = "DGOrdiniStorico"
        Me.DGOrdiniStorico.ReadOnly = True
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdiniStorico.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.DGOrdiniStorico.RowHeadersVisible = False
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdiniStorico.RowsDefaultCellStyle = DataGridViewCellStyle22
        Me.DGOrdiniStorico.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DGOrdiniStorico.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DGOrdiniStorico.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdiniStorico.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdiniStorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGOrdiniStorico.Size = New System.Drawing.Size(975, 400)
        Me.DGOrdiniStorico.TabIndex = 57
        Me.DGOrdiniStorico.TabStop = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Giorno"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Data"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "RagSoc"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cliente"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 500
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 500
        '
        'lnkCercaStorico
        '
        Me.lnkCercaStorico.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCercaStorico.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCercaStorico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCercaStorico.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCercaStorico.Location = New System.Drawing.Point(6, 3)
        Me.lnkCercaStorico.Name = "lnkCercaStorico"
        Me.lnkCercaStorico.Size = New System.Drawing.Size(109, 27)
        Me.lnkCercaStorico.TabIndex = 56
        Me.lnkCercaStorico.TabStop = True
        Me.lnkCercaStorico.Text = "Avvia ricerca..."
        Me.lnkCercaStorico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "ico_BO_R.png")
        Me.imlTab.Images.SetKeyName(1, "ico_SB_R.png")
        '
        'ucAmministrazioneOrdiniBonifico
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tbBonifici)
        Me.Name = "ucAmministrazioneOrdiniBonifico"
        Me.Size = New System.Drawing.Size(995, 470)
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbBonifici.ResumeLayout(False)
        Me.tpBonifici.ResumeLayout(False)
        Me.tpStorico.ResumeLayout(False)
        CType(Me.DGOrdiniStorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lnkCerca As System.Windows.Forms.LinkLabel
    Friend WithEvents DgOrdini As System.Windows.Forms.DataGridView
    Friend WithEvents lnkRegistraPagam As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSitoBanca As System.Windows.Forms.LinkLabel
    Friend WithEvents tbBonifici As TabControl
    Friend WithEvents tpBonifici As TabPage
    Friend WithEvents tpStorico As TabPage
    Friend WithEvents imlTab As ImageList
    Friend WithEvents DGOrdiniStorico As DataGridView
    Friend WithEvents lnkCercaStorico As LinkLabel
    Friend WithEvents QtaOrd As DataGridViewTextBoxColumn
    Friend WithEvents Com As DataGridViewTextBoxColumn
    Friend WithEvents DataIns As DataGridViewTextBoxColumn
    Friend WithEvents IdOrdLista As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
End Class
