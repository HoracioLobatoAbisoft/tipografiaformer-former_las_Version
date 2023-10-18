

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMessaggiInterniSmall
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMessaggiInterniSmall))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.imlPostit = New System.Windows.Forms.ImageList(Me.components)
        Me.imlPostitBig = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.tmrAggiorna = New System.Windows.Forms.Timer(Me.components)
        Me.dgMessRic = New Former.ucDataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mittente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titolo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabMess = New System.Windows.Forms.TabControl()
        Me.tpRic = New System.Windows.Forms.TabPage()
        Me.tpInv = New System.Windows.Forms.TabPage()
        Me.dgMessInv = New Former.ucDataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pctMonitor = New System.Windows.Forms.PictureBox()
        CType(Me.dgMessRic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMess.SuspendLayout()
        Me.tpRic.SuspendLayout()
        Me.tpInv.SuspendLayout()
        CType(Me.dgMessInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkNew
        '
        Me.lnkNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Messaggio
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(285, 0)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(73, 32)
        Me.lnkNew.TabIndex = 22
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'imlPostit
        '
        Me.imlPostit.ImageStream = CType(resources.GetObject("imlPostit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPostit.TransparentColor = System.Drawing.Color.Transparent
        Me.imlPostit.Images.SetKeyName(0, "postit.jpg")
        '
        'imlPostitBig
        '
        Me.imlPostitBig.ImageStream = CType(resources.GetObject("imlPostitBig.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPostitBig.TransparentColor = System.Drawing.Color.White
        Me.imlPostitBig.Images.SetKeyName(0, "postit.jpg")
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(38, 0)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(83, 32)
        Me.lnkAggiorna.TabIndex = 24
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmrAggiorna
        '
        Me.tmrAggiorna.Interval = 60000
        '
        'dgMessRic
        '
        Me.dgMessRic.AllowUserToAddRows = False
        Me.dgMessRic.AllowUserToDeleteRows = False
        Me.dgMessRic.AllowUserToOrderColumns = True
        Me.dgMessRic.AllowUserToResizeRows = False
        Me.dgMessRic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgMessRic.BackgroundColor = System.Drawing.Color.White
        Me.dgMessRic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMessRic.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgMessRic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMessRic.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Data, Me.Mittente, Me.Titolo})
        Me.dgMessRic.CustomVirtualMode = False
        Me.dgMessRic.DataSourceVirtual = Nothing
        Me.dgMessRic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMessRic.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgMessRic.Location = New System.Drawing.Point(3, 3)
        Me.dgMessRic.MultiSelect = False
        Me.dgMessRic.Name = "dgMessRic"
        Me.dgMessRic.RowHeadersVisible = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgMessRic.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMessRic.ScrollManuale = False
        Me.dgMessRic.ScrollValue = 0
        Me.dgMessRic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMessRic.ShowEditingIcon = False
        Me.dgMessRic.Size = New System.Drawing.Size(341, 282)
        Me.dgMessRic.TabIndex = 25
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Tipo.DataPropertyName = "icoTipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 37
        '
        'Data
        '
        Me.Data.DataPropertyName = "DataInsFormat"
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.Width = 56
        '
        'Mittente
        '
        Me.Mittente.DataPropertyName = "NomeMitt"
        Me.Mittente.HeaderText = "Mittente"
        Me.Mittente.Name = "Mittente"
        Me.Mittente.Width = 77
        '
        'Titolo
        '
        Me.Titolo.DataPropertyName = "Titolo"
        Me.Titolo.HeaderText = "Titolo"
        Me.Titolo.Name = "Titolo"
        Me.Titolo.Width = 63
        '
        'tabMess
        '
        Me.tabMess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMess.Controls.Add(Me.tpRic)
        Me.tabMess.Controls.Add(Me.tpInv)
        Me.tabMess.Location = New System.Drawing.Point(3, 35)
        Me.tabMess.Name = "tabMess"
        Me.tabMess.SelectedIndex = 0
        Me.tabMess.Size = New System.Drawing.Size(355, 316)
        Me.tabMess.TabIndex = 26
        '
        'tpRic
        '
        Me.tpRic.Controls.Add(Me.dgMessRic)
        Me.tpRic.Location = New System.Drawing.Point(4, 24)
        Me.tpRic.Name = "tpRic"
        Me.tpRic.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRic.Size = New System.Drawing.Size(347, 288)
        Me.tpRic.TabIndex = 0
        Me.tpRic.Text = "Ricevuti"
        Me.tpRic.UseVisualStyleBackColor = True
        '
        'tpInv
        '
        Me.tpInv.Controls.Add(Me.dgMessInv)
        Me.tpInv.Location = New System.Drawing.Point(4, 24)
        Me.tpInv.Name = "tpInv"
        Me.tpInv.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInv.Size = New System.Drawing.Size(347, 288)
        Me.tpInv.TabIndex = 1
        Me.tpInv.Text = "Inviati"
        Me.tpInv.UseVisualStyleBackColor = True
        '
        'dgMessInv
        '
        Me.dgMessInv.AllowUserToAddRows = False
        Me.dgMessInv.AllowUserToDeleteRows = False
        Me.dgMessInv.AllowUserToOrderColumns = True
        Me.dgMessInv.AllowUserToResizeRows = False
        Me.dgMessInv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgMessInv.BackgroundColor = System.Drawing.Color.White
        Me.dgMessInv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMessInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgMessInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMessInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn2})
        Me.dgMessInv.CustomVirtualMode = False
        Me.dgMessInv.DataSourceVirtual = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMessInv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgMessInv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMessInv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgMessInv.Location = New System.Drawing.Point(3, 3)
        Me.dgMessInv.MultiSelect = False
        Me.dgMessInv.Name = "dgMessInv"
        Me.dgMessInv.RowHeadersVisible = False
        Me.dgMessInv.ScrollManuale = False
        Me.dgMessInv.ScrollValue = 0
        Me.dgMessInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMessInv.ShowEditingIcon = False
        Me.dgMessInv.Size = New System.Drawing.Size(341, 282)
        Me.dgMessInv.TabIndex = 26
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn1.DataPropertyName = "icoTipo"
        Me.DataGridViewImageColumn1.HeaderText = "Tipo"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 37
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DataInsFormat"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Data"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 56
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NomeDest"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Destinatario"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 95
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Titolo"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Titolo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 63
        '
        'pctMonitor
        '
        Me.pctMonitor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctMonitor.Image = Global.Former.My.Resources.Resources._Postazione
        Me.pctMonitor.Location = New System.Drawing.Point(0, 0)
        Me.pctMonitor.Name = "pctMonitor"
        Me.pctMonitor.Size = New System.Drawing.Size(32, 32)
        Me.pctMonitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctMonitor.TabIndex = 27
        Me.pctMonitor.TabStop = False
        '
        'ucMessaggiInterniSmall
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pctMonitor)
        Me.Controls.Add(Me.tabMess)
        Me.Controls.Add(Me.lnkAggiorna)
        Me.Controls.Add(Me.lnkNew)
        Me.Name = "ucMessaggiInterniSmall"
        Me.Size = New System.Drawing.Size(361, 351)
        CType(Me.dgMessRic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMess.ResumeLayout(False)
        Me.tpRic.ResumeLayout(False)
        Me.tpInv.ResumeLayout(False)
        CType(Me.dgMessInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctMonitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents imlPostit As System.Windows.Forms.ImageList
    Friend WithEvents imlPostitBig As System.Windows.Forms.ImageList
    Friend WithEvents lnkAggiorna As System.Windows.Forms.LinkLabel
    Friend WithEvents tmrAggiorna As System.Windows.Forms.Timer
    Friend WithEvents dgMessRic As ucDataGridView
    Friend WithEvents tabMess As System.Windows.Forms.TabControl
    Friend WithEvents tpRic As System.Windows.Forms.TabPage
    Friend WithEvents tpInv As System.Windows.Forms.TabPage
    Friend WithEvents dgMessInv As ucDataGridView
    Friend WithEvents pctMonitor As System.Windows.Forms.PictureBox
    Friend WithEvents Tipo As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Titolo As DataGridViewTextBoxColumn
    Friend WithEvents Mittente As DataGridViewTextBoxColumn
    Friend WithEvents Data As DataGridViewTextBoxColumn


End Class
