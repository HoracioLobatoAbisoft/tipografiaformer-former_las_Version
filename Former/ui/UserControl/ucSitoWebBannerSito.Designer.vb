<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSitoWebBannerSito
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgBanner = New System.Windows.Forms.DataGridView()
        Me.Banner = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Url = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alternate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.lnkPubblica = New System.Windows.Forms.LinkLabel()
        Me.lnkSu = New System.Windows.Forms.LinkLabel()
        Me.lnkGiu = New System.Windows.Forms.LinkLabel()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.lnkModifica = New System.Windows.Forms.LinkLabel()
        CType(Me.DgBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgBanner
        '
        Me.DgBanner.AllowUserToAddRows = False
        Me.DgBanner.AllowUserToDeleteRows = False
        Me.DgBanner.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgBanner.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgBanner.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgBanner.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgBanner.BackgroundColor = System.Drawing.Color.White
        Me.DgBanner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgBanner.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgBanner.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DgBanner.ColumnHeadersHeight = 20
        Me.DgBanner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgBanner.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Banner, Me.Url, Me.Alternate, Me.Stato})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgBanner.DefaultCellStyle = DataGridViewCellStyle8
        Me.DgBanner.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgBanner.EnableHeadersVisualStyles = False
        Me.DgBanner.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgBanner.Location = New System.Drawing.Point(3, 35)
        Me.DgBanner.MultiSelect = False
        Me.DgBanner.Name = "DgBanner"
        Me.DgBanner.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgBanner.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DgBanner.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DgBanner.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DgBanner.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgBanner.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgBanner.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgBanner.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgBanner.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgBanner.Size = New System.Drawing.Size(884, 414)
        Me.DgBanner.TabIndex = 42
        Me.DgBanner.TabStop = False
        '
        'Banner
        '
        Me.Banner.DataPropertyName = "Img400"
        Me.Banner.FillWeight = 400.0!
        Me.Banner.HeaderText = "Banner"
        Me.Banner.Name = "Banner"
        Me.Banner.ReadOnly = True
        Me.Banner.Width = 400
        '
        'Url
        '
        Me.Url.DataPropertyName = "Url"
        Me.Url.HeaderText = "Url"
        Me.Url.Name = "Url"
        Me.Url.ReadOnly = True
        '
        'Alternate
        '
        Me.Alternate.DataPropertyName = "Alternate"
        Me.Alternate.HeaderText = "Alternate"
        Me.Alternate.Name = "Alternate"
        Me.Alternate.ReadOnly = True
        '
        'Stato
        '
        Me.Stato.DataPropertyName = "StatoStr"
        Me.Stato.HeaderText = "Stato"
        Me.Stato.Name = "Stato"
        Me.Stato.ReadOnly = True
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.sinchronize2
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(3, 0)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(83, 32)
        Me.lnkAggiorna.TabIndex = 50
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkPubblica
        '
        Me.lnkPubblica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkPubblica.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkPubblica.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkPubblica.Image = Global.Former.My.Resources._upload
        Me.lnkPubblica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPubblica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkPubblica.Location = New System.Drawing.Point(803, 0)
        Me.lnkPubblica.Name = "lnkPubblica"
        Me.lnkPubblica.Size = New System.Drawing.Size(84, 32)
        Me.lnkPubblica.TabIndex = 51
        Me.lnkPubblica.TabStop = True
        Me.lnkPubblica.Text = "Pubblica"
        Me.lnkPubblica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkSu
        '
        Me.lnkSu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkSu.Image = Global.Former.My.Resources._Su
        Me.lnkSu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSu.Location = New System.Drawing.Point(295, 0)
        Me.lnkSu.Name = "lnkSu"
        Me.lnkSu.Size = New System.Drawing.Size(51, 32)
        Me.lnkSu.TabIndex = 56
        Me.lnkSu.TabStop = True
        Me.lnkSu.Text = "Su"
        Me.lnkSu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkGiu
        '
        Me.lnkGiu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkGiu.Image = Global.Former.My.Resources._Giu
        Me.lnkGiu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkGiu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkGiu.Location = New System.Drawing.Point(352, 0)
        Me.lnkGiu.Name = "lnkGiu"
        Me.lnkGiu.Size = New System.Drawing.Size(54, 32)
        Me.lnkGiu.TabIndex = 57
        Me.lnkGiu.TabStop = True
        Me.lnkGiu.Text = "Giù"
        Me.lnkGiu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNew
        '
        Me.lnkNew.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources._Aggiungi
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(529, 0)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(82, 32)
        Me.lnkNew.TabIndex = 58
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Aggiungi"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkModifica
        '
        Me.lnkModifica.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkModifica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModifica.Image = Global.Former.My.Resources._Modifica
        Me.lnkModifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModifica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModifica.Location = New System.Drawing.Point(617, 0)
        Me.lnkModifica.Name = "lnkModifica"
        Me.lnkModifica.Size = New System.Drawing.Size(82, 32)
        Me.lnkModifica.TabIndex = 59
        Me.lnkModifica.TabStop = True
        Me.lnkModifica.Text = "Modifica"
        Me.lnkModifica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucListinoBannerSito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkModifica)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.lnkSu)
        Me.Controls.Add(Me.lnkGiu)
        Me.Controls.Add(Me.lnkPubblica)
        Me.Controls.Add(Me.lnkAggiorna)
        Me.Controls.Add(Me.DgBanner)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucListinoBannerSito"
        Me.Size = New System.Drawing.Size(890, 452)
        CType(Me.DgBanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgBanner As System.Windows.Forms.DataGridView
    Friend WithEvents Banner As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Url As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Alternate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkAggiorna As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkPubblica As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSu As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkGiu As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkModifica As System.Windows.Forms.LinkLabel

End Class
