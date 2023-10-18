<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMarketingProgrammato
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMarketingProgrammato))
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.DgMarketing = New System.Windows.Forms.DataGridView()
        Me.ContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminaToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EseguiAzioneDiMarketingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.tvCont = New System.Windows.Forms.TreeView()
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkComple = New System.Windows.Forms.LinkLabel()
        Me.lblAzione = New System.Windows.Forms.Label()
        Me.lblGruppo = New System.Windows.Forms.Label()
        Me.contCli = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lnkEsegAll = New System.Windows.Forms.LinkLabel()
        Me.lnkEsegSing = New System.Windows.Forms.LinkLabel()
        Me.rdoTutti = New System.Windows.Forms.RadioButton()
        Me.rdoNonComp = New System.Windows.Forms.RadioButton()
        CType(Me.DgMarketing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenu.SuspendLayout()
        Me.contCli.SuspendLayout()
        Me.SuspendLayout()
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(978, 0)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 26)
        Me.lnkStampa.TabIndex = 58
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAll
        '
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(3, 0)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Size = New System.Drawing.Size(72, 26)
        Me.lnkAll.TabIndex = 57
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Mostra"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgMarketing
        '
        Me.DgMarketing.AllowUserToAddRows = False
        Me.DgMarketing.AllowUserToDeleteRows = False
        Me.DgMarketing.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgMarketing.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgMarketing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgMarketing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgMarketing.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgMarketing.BackgroundColor = System.Drawing.Color.White
        Me.DgMarketing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgMarketing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMarketing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgMarketing.ColumnHeadersHeight = 20
        Me.DgMarketing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMarketing.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgMarketing.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgMarketing.EnableHeadersVisualStyles = False
        Me.DgMarketing.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgMarketing.Location = New System.Drawing.Point(3, 29)
        Me.DgMarketing.MultiSelect = False
        Me.DgMarketing.Name = "DgMarketing"
        Me.DgMarketing.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMarketing.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgMarketing.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgMarketing.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgMarketing.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgMarketing.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgMarketing.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgMarketing.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMarketing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgMarketing.Size = New System.Drawing.Size(388, 385)
        Me.DgMarketing.TabIndex = 60
        Me.DgMarketing.TabStop = False
        '
        'ContextMenu
        '
        Me.ContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaToolStripMenuItem, Me.EliminaToolStripMenu, Me.ToolStripSeparator1, Me.EseguiAzioneDiMarketingToolStripMenuItem})
        Me.ContextMenu.Name = "ContextMenu"
        Me.ContextMenu.Size = New System.Drawing.Size(163, 76)
        '
        'ModificaToolStripMenuItem
        '
        Me.ModificaToolStripMenuItem.Name = "ModificaToolStripMenuItem"
        Me.ModificaToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ModificaToolStripMenuItem.Text = "Modifica"
        '
        'EliminaToolStripMenu
        '
        Me.EliminaToolStripMenu.Name = "EliminaToolStripMenu"
        Me.EliminaToolStripMenu.Size = New System.Drawing.Size(162, 22)
        Me.EliminaToolStripMenu.Text = "Elimina"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(159, 6)
        '
        'EseguiAzioneDiMarketingToolStripMenuItem
        '
        Me.EseguiAzioneDiMarketingToolStripMenuItem.Name = "EseguiAzioneDiMarketingToolStripMenuItem"
        Me.EseguiAzioneDiMarketingToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.EseguiAzioneDiMarketingToolStripMenuItem.Text = "Voce completata"
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(81, 0)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(71, 27)
        Me.lnkNew.TabIndex = 61
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tvCont
        '
        Me.tvCont.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvCont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvCont.ImageIndex = 0
        Me.tvCont.ImageList = Me.imlCli
        Me.tvCont.Location = New System.Drawing.Point(397, 56)
        Me.tvCont.Name = "tvCont"
        Me.tvCont.SelectedImageIndex = 0
        Me.tvCont.Size = New System.Drawing.Size(661, 358)
        Me.tvCont.TabIndex = 62
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "icoCli.jpg")
        Me.imlCli.Images.SetKeyName(1, "icoMail.jpg")
        Me.imlCli.Images.SetKeyName(2, "icoOk.jpg")
        Me.imlCli.Images.SetKeyName(3, "icoCancel.jpg")
        Me.imlCli.Images.SetKeyName(4, "fast_forward.png")
        Me.imlCli.Images.SetKeyName(5, "mail.png")
        Me.imlCli.Images.SetKeyName(6, "sound.png")
        Me.imlCli.Images.SetKeyName(7, "documents.png")
        '
        'lnkComple
        '
        Me.lnkComple.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkComple.Image = Global.Former.My.Resources.Resources.icoOk
        Me.lnkComple.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkComple.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkComple.Location = New System.Drawing.Point(158, 0)
        Me.lnkComple.Name = "lnkComple"
        Me.lnkComple.Size = New System.Drawing.Size(99, 27)
        Me.lnkComple.TabIndex = 63
        Me.lnkComple.TabStop = True
        Me.lnkComple.Text = "Completata"
        Me.lnkComple.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkComple.Visible = False
        '
        'lblAzione
        '
        Me.lblAzione.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAzione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAzione.Location = New System.Drawing.Point(237, 31)
        Me.lblAzione.Name = "lblAzione"
        Me.lblAzione.Size = New System.Drawing.Size(154, 22)
        Me.lblAzione.TabIndex = 64
        Me.lblAzione.Text = "Azione: -"
        Me.lblAzione.Visible = False
        '
        'lblGruppo
        '
        Me.lblGruppo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblGruppo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblGruppo.Location = New System.Drawing.Point(397, 29)
        Me.lblGruppo.Name = "lblGruppo"
        Me.lblGruppo.Size = New System.Drawing.Size(661, 24)
        Me.lblGruppo.TabIndex = 64
        Me.lblGruppo.Text = "Gruppo: -"
        '
        'contCli
        '
        Me.contCli.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripSeparator2, Me.ToolStripMenuItem3})
        Me.contCli.Name = "ContextMenu"
        Me.contCli.Size = New System.Drawing.Size(163, 76)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(162, 22)
        Me.ToolStripMenuItem1.Text = "Modifica"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(162, 22)
        Me.ToolStripMenuItem2.Text = "Elimina"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(159, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(162, 22)
        Me.ToolStripMenuItem3.Text = "Voce completata"
        '
        'lnkEsegAll
        '
        Me.lnkEsegAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkEsegAll.Image = Global.Former.My.Resources.Resources._Mail
        Me.lnkEsegAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkEsegAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkEsegAll.Location = New System.Drawing.Point(394, 0)
        Me.lnkEsegAll.Name = "lnkEsegAll"
        Me.lnkEsegAll.Size = New System.Drawing.Size(246, 27)
        Me.lnkEsegAll.TabIndex = 65
        Me.lnkEsegAll.TabStop = True
        Me.lnkEsegAll.Text = "Manda email al GRUPPO SELEZIONATO"
        Me.lnkEsegAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkEsegSing
        '
        Me.lnkEsegSing.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkEsegSing.Image = Global.Former.My.Resources.Resources.icoCli
        Me.lnkEsegSing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkEsegSing.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkEsegSing.Location = New System.Drawing.Point(883, 26)
        Me.lnkEsegSing.Name = "lnkEsegSing"
        Me.lnkEsegSing.Size = New System.Drawing.Size(175, 27)
        Me.lnkEsegSing.TabIndex = 66
        Me.lnkEsegSing.TabStop = True
        Me.lnkEsegSing.Text = "Esegui azione su singolo"
        Me.lnkEsegSing.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkEsegSing.Visible = False
        '
        'rdoTutti
        '
        Me.rdoTutti.AutoSize = True
        Me.rdoTutti.Checked = True
        Me.rdoTutti.Location = New System.Drawing.Point(796, 4)
        Me.rdoTutti.Name = "rdoTutti"
        Me.rdoTutti.Size = New System.Drawing.Size(49, 19)
        Me.rdoTutti.TabIndex = 67
        Me.rdoTutti.TabStop = True
        Me.rdoTutti.Text = "Tutti"
        Me.rdoTutti.UseVisualStyleBackColor = True
        Me.rdoTutti.Visible = False
        '
        'rdoNonComp
        '
        Me.rdoNonComp.AutoSize = True
        Me.rdoNonComp.Location = New System.Drawing.Point(850, 4)
        Me.rdoNonComp.Name = "rdoNonComp"
        Me.rdoNonComp.Size = New System.Drawing.Size(110, 19)
        Me.rdoNonComp.TabIndex = 68
        Me.rdoNonComp.Text = "Non Completati"
        Me.rdoNonComp.UseVisualStyleBackColor = True
        Me.rdoNonComp.Visible = False
        '
        'ucMarketingProgrammato
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lnkEsegSing)
        Me.Controls.Add(Me.rdoNonComp)
        Me.Controls.Add(Me.rdoTutti)
        Me.Controls.Add(Me.lnkEsegAll)
        Me.Controls.Add(Me.lblGruppo)
        Me.Controls.Add(Me.lblAzione)
        Me.Controls.Add(Me.lnkComple)
        Me.Controls.Add(Me.tvCont)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.DgMarketing)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.lnkAll)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucMarketingProgrammato"
        Me.Size = New System.Drawing.Size(1061, 417)
        CType(Me.DgMarketing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenu.ResumeLayout(False)
        Me.contCli.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAll As System.Windows.Forms.LinkLabel
    Friend WithEvents DgMarketing As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminaToolStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EseguiAzioneDiMarketingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tvCont As System.Windows.Forms.TreeView
    Friend WithEvents imlCli As System.Windows.Forms.ImageList
    Friend WithEvents lnkComple As System.Windows.Forms.LinkLabel
    Friend WithEvents lblAzione As System.Windows.Forms.Label
    Friend WithEvents lblGruppo As System.Windows.Forms.Label
    Friend WithEvents contCli As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lnkEsegAll As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkEsegSing As System.Windows.Forms.LinkLabel
    Friend WithEvents rdoTutti As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNonComp As System.Windows.Forms.RadioButton

End Class
