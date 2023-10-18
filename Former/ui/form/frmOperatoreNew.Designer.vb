<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOperatoreNew
    Inherits baseFormInternaFixed
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lnkChiudi = New System.Windows.Forms.LinkLabel()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.UcSliderGroup = New Former.ucSliderGroup()
        Me.WebPreview = New System.Windows.Forms.WebBrowser()
        Me.pctMessaggi = New System.Windows.Forms.PictureBox()
        Me.lblMessaggi = New System.Windows.Forms.Label()
        Me.lblLavoraz = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpMessaggi = New System.Windows.Forms.TabPage()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.UcAllegati = New Former.ucAllegati()
        Me.tpProcedure = New System.Windows.Forms.TabPage()
        Me.dgProcedure = New System.Windows.Forms.DataGridView()
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Lavorazione = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RiferitaA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lnkCopyAllegati = New System.Windows.Forms.LinkLabel()
        Me.lnkPanel = New System.Windows.Forms.LinkLabel()
        Me.lblStatoLavorazione = New System.Windows.Forms.Label()
        Me.lnkFinished = New System.Windows.Forms.LinkLabel()
        Me.lnkIniziaLav = New System.Windows.Forms.LinkLabel()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctMessaggi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMessaggi.SuspendLayout()
        Me.tpProcedure.SuspendLayout()
        CType(Me.dgProcedure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPulsanti.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkChiudi
        '
        Me.lnkChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkChiudi.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkChiudi.Image = Global.Former.My.Resources.Resources._Annulla
        Me.lnkChiudi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkChiudi.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChiudi.Location = New System.Drawing.Point(936, 17)
        Me.lnkChiudi.Name = "lnkChiudi"
        Me.lnkChiudi.Size = New System.Drawing.Size(81, 24)
        Me.lnkChiudi.TabIndex = 84
        Me.lnkChiudi.TabStop = True
        Me.lnkChiudi.Text = "Chiudi"
        Me.lnkChiudi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpMessaggi)
        Me.TabMain.Controls.Add(Me.tpProcedure)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TabMain.ItemSize = New System.Drawing.Size(125, 40)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1024, 666)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.UcSliderGroup)
        Me.tbProd.Controls.Add(Me.WebPreview)
        Me.tbProd.Controls.Add(Me.pctMessaggi)
        Me.tbProd.Controls.Add(Me.lblMessaggi)
        Me.tbProd.Controls.Add(Me.lblLavoraz)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.ImageKey = "Lavorazione"
        Me.tbProd.Location = New System.Drawing.Point(4, 44)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1016, 618)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Lavorazione in corso"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'UcSliderGroup
        '
        Me.UcSliderGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UcSliderGroup.AutoSize = True
        Me.UcSliderGroup.Location = New System.Drawing.Point(3, 3)
        Me.UcSliderGroup.Name = "UcSliderGroup"
        Me.UcSliderGroup.Size = New System.Drawing.Size(83, 544)
        Me.UcSliderGroup.TabIndex = 89
        '
        'WebPreview
        '
        Me.WebPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebPreview.Location = New System.Drawing.Point(87, 3)
        Me.WebPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebPreview.Name = "WebPreview"
        Me.WebPreview.Size = New System.Drawing.Size(926, 544)
        Me.WebPreview.TabIndex = 88
        '
        'pctMessaggi
        '
        Me.pctMessaggi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pctMessaggi.Image = Global.Former.My.Resources.Resources._Messaggio
        Me.pctMessaggi.Location = New System.Drawing.Point(6, 580)
        Me.pctMessaggi.Name = "pctMessaggi"
        Me.pctMessaggi.Size = New System.Drawing.Size(32, 32)
        Me.pctMessaggi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctMessaggi.TabIndex = 87
        Me.pctMessaggi.TabStop = False
        '
        'lblMessaggi
        '
        Me.lblMessaggi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMessaggi.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.lblMessaggi.Location = New System.Drawing.Point(38, 580)
        Me.lblMessaggi.Name = "lblMessaggi"
        Me.lblMessaggi.Size = New System.Drawing.Size(195, 32)
        Me.lblMessaggi.TabIndex = 86
        Me.lblMessaggi.Text = "0 Messaggi allegati"
        Me.lblMessaggi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLavoraz
        '
        Me.lblLavoraz.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLavoraz.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLavoraz.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLavoraz.ForeColor = System.Drawing.Color.Black
        Me.lblLavoraz.Location = New System.Drawing.Point(233, 550)
        Me.lblLavoraz.Name = "lblLavoraz"
        Me.lblLavoraz.Size = New System.Drawing.Size(780, 62)
        Me.lblLavoraz.TabIndex = 85
        Me.lblLavoraz.Text = "TEST"
        Me.lblLavoraz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctTipo
        '
        Me.pctTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pctTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Lavorazione
        Me.pctTipo.Location = New System.Drawing.Point(6, 550)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(32, 32)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(38, 550)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(195, 32)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Lavorazione in corso:"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tpMessaggi
        '
        Me.tpMessaggi.Controls.Add(Me.lnkAggiorna)
        Me.tpMessaggi.Controls.Add(Me.lnkNew)
        Me.tpMessaggi.Controls.Add(Me.UcAllegati)
        Me.tpMessaggi.ImageKey = "Messaggio"
        Me.tpMessaggi.Location = New System.Drawing.Point(4, 44)
        Me.tpMessaggi.Name = "tpMessaggi"
        Me.tpMessaggi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMessaggi.Size = New System.Drawing.Size(1016, 618)
        Me.tpMessaggi.TabIndex = 1
        Me.tpMessaggi.Text = "Messaggi"
        Me.tpMessaggi.UseVisualStyleBackColor = True
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources.sinchronize2
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(8, 3)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(83, 32)
        Me.lnkAggiorna.TabIndex = 51
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNew
        '
        Me.lnkNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Messaggio
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(939, 3)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(71, 32)
        Me.lnkNew.TabIndex = 50
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UcAllegati
        '
        Me.UcAllegati.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcAllegati.BackColor = System.Drawing.Color.White
        Me.UcAllegati.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAllegati.FromOperatore = True
        Me.UcAllegati.Location = New System.Drawing.Point(3, 38)
        Me.UcAllegati.Name = "UcAllegati"
        Me.UcAllegati.Size = New System.Drawing.Size(1010, 577)
        Me.UcAllegati.TabIndex = 0
        '
        'tpProcedure
        '
        Me.tpProcedure.Controls.Add(Me.dgProcedure)
        Me.tpProcedure.ImageKey = "Procedura"
        Me.tpProcedure.Location = New System.Drawing.Point(4, 44)
        Me.tpProcedure.Name = "tpProcedure"
        Me.tpProcedure.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProcedure.Size = New System.Drawing.Size(1016, 618)
        Me.tpProcedure.TabIndex = 2
        Me.tpProcedure.Text = "Procedure"
        Me.tpProcedure.UseVisualStyleBackColor = True
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
        Me.dgProcedure.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgProcedure.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgProcedure.BackgroundColor = System.Drawing.Color.White
        Me.dgProcedure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgProcedure.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
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
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProcedure.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgProcedure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgProcedure.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgProcedure.EnableHeadersVisualStyles = False
        Me.dgProcedure.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgProcedure.Location = New System.Drawing.Point(3, 3)
        Me.dgProcedure.MultiSelect = False
        Me.dgProcedure.Name = "dgProcedure"
        Me.dgProcedure.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
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
        Me.dgProcedure.Size = New System.Drawing.Size(1010, 612)
        Me.dgProcedure.TabIndex = 84
        Me.dgProcedure.TabStop = False
        '
        'Img
        '
        Me.Img.DataPropertyName = "ImgMacchinario"
        Me.Img.HeaderText = "Macchinario"
        Me.Img.Name = "Img"
        Me.Img.ReadOnly = True
        Me.Img.Width = 110
        '
        'Lavorazione
        '
        Me.Lavorazione.DataPropertyName = "ImgLavorazione"
        Me.Lavorazione.HeaderText = "Lavorazione"
        Me.Lavorazione.Name = "Lavorazione"
        Me.Lavorazione.ReadOnly = True
        Me.Lavorazione.Width = 108
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Nome"
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 81
        '
        'Descrizione
        '
        Me.Descrizione.DataPropertyName = "Descrizione"
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        Me.Descrizione.Width = 123
        '
        'RiferitaA
        '
        Me.RiferitaA.DataPropertyName = "RiferitoA"
        Me.RiferitaA.HeaderText = "Riferita a"
        Me.RiferitaA.Name = "RiferitaA"
        Me.RiferitaA.ReadOnly = True
        Me.RiferitaA.Width = 103
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lnkCopyAllegati)
        Me.gbPulsanti.Controls.Add(Me.lnkPanel)
        Me.gbPulsanti.Controls.Add(Me.lblStatoLavorazione)
        Me.gbPulsanti.Controls.Add(Me.lnkChiudi)
        Me.gbPulsanti.Controls.Add(Me.lnkFinished)
        Me.gbPulsanti.Controls.Add(Me.lnkIniziaLav)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 666)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1024, 83)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lnkCopyAllegati
        '
        Me.lnkCopyAllegati.BackColor = System.Drawing.Color.White
        Me.lnkCopyAllegati.Enabled = False
        Me.lnkCopyAllegati.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkCopyAllegati.Image = Global.Former.My.Resources.Resources._UsbKey
        Me.lnkCopyAllegati.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCopyAllegati.LinkColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.lnkCopyAllegati.Location = New System.Drawing.Point(620, 14)
        Me.lnkCopyAllegati.Name = "lnkCopyAllegati"
        Me.lnkCopyAllegati.Size = New System.Drawing.Size(186, 27)
        Me.lnkCopyAllegati.TabIndex = 86
        Me.lnkCopyAllegati.TabStop = True
        Me.lnkCopyAllegati.Text = "Copia Allegati su USB"
        Me.lnkCopyAllegati.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkPanel
        '
        Me.lnkPanel.BackColor = System.Drawing.Color.White
        Me.lnkPanel.Enabled = False
        Me.lnkPanel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkPanel.Image = Global.Former.My.Resources.Resources._pdf
        Me.lnkPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPanel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.lnkPanel.Location = New System.Drawing.Point(444, 16)
        Me.lnkPanel.Name = "lnkPanel"
        Me.lnkPanel.Size = New System.Drawing.Size(170, 27)
        Me.lnkPanel.TabIndex = 86
        Me.lnkPanel.TabStop = True
        Me.lnkPanel.Text = "Creazione Pannelli"
        Me.lnkPanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStatoLavorazione
        '
        Me.lblStatoLavorazione.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatoLavorazione.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatoLavorazione.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatoLavorazione.Location = New System.Drawing.Point(4, 46)
        Me.lblStatoLavorazione.Name = "lblStatoLavorazione"
        Me.lblStatoLavorazione.Size = New System.Drawing.Size(1016, 31)
        Me.lblStatoLavorazione.TabIndex = 85
        Me.lblStatoLavorazione.Text = "-"
        Me.lblStatoLavorazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkFinished
        '
        Me.lnkFinished.BackColor = System.Drawing.Color.White
        Me.lnkFinished.Enabled = False
        Me.lnkFinished.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkFinished.Image = Global.Former.My.Resources.Resources.checkmark2
        Me.lnkFinished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkFinished.LinkColor = System.Drawing.Color.Green
        Me.lnkFinished.Location = New System.Drawing.Point(180, 17)
        Me.lnkFinished.Name = "lnkFinished"
        Me.lnkFinished.Size = New System.Drawing.Size(258, 24)
        Me.lnkFinished.TabIndex = 83
        Me.lnkFinished.TabStop = True
        Me.lnkFinished.Text = "Registra lavorazione Terminata"
        Me.lnkFinished.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkIniziaLav
        '
        Me.lnkIniziaLav.BackColor = System.Drawing.Color.White
        Me.lnkIniziaLav.Enabled = False
        Me.lnkIniziaLav.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkIniziaLav.Image = Global.Former.My.Resources.Resources._Lavorazione
        Me.lnkIniziaLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkIniziaLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkIniziaLav.Location = New System.Drawing.Point(12, 17)
        Me.lnkIniziaLav.Name = "lnkIniziaLav"
        Me.lnkIniziaLav.Size = New System.Drawing.Size(162, 24)
        Me.lnkIniziaLav.TabIndex = 82
        Me.lnkIniziaLav.TabStop = True
        Me.lnkIniziaLav.Text = "Inizia lavorazione"
        Me.lnkIniziaLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmOperatoreNew
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.lnkChiudi
        Me.ClientSize = New System.Drawing.Size(1024, 749)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmOperatoreNew"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Operatore"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctMessaggi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMessaggi.ResumeLayout(False)
        Me.tpProcedure.ResumeLayout(False)
        CType(Me.dgProcedure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPulsanti.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lnkFinished As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkIniziaLav As System.Windows.Forms.LinkLabel
    Friend WithEvents lblLavoraz As System.Windows.Forms.Label
    Friend WithEvents lnkChiudi As System.Windows.Forms.LinkLabel
    Friend WithEvents lblStatoLavorazione As System.Windows.Forms.Label
    Friend WithEvents tpMessaggi As System.Windows.Forms.TabPage
    Friend WithEvents pctMessaggi As System.Windows.Forms.PictureBox
    Friend WithEvents lblMessaggi As System.Windows.Forms.Label
    Friend WithEvents UcAllegati As Former.ucAllegati
    Friend WithEvents lnkAggiorna As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkPanel As LinkLabel
    Friend WithEvents WebPreview As WebBrowser
    Friend WithEvents tpProcedure As TabPage
    Friend WithEvents dgProcedure As DataGridView
    Friend WithEvents Img As DataGridViewImageColumn
    Friend WithEvents Lavorazione As DataGridViewImageColumn
    Friend WithEvents Nome As DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As DataGridViewTextBoxColumn
    Friend WithEvents RiferitaA As DataGridViewTextBoxColumn
    Friend WithEvents UcSliderGroup As ucSliderGroup
    Friend WithEvents lnkCopyAllegati As LinkLabel
End Class
