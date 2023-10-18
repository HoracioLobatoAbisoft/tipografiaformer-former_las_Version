<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAnteprimaOperatore
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbAnteprima = New System.Windows.Forms.TabPage()
        Me.WebPreview = New System.Windows.Forms.WebBrowser()
        Me.tbMain = New System.Windows.Forms.TabControl()
        Me.tpModelloCommessa = New System.Windows.Forms.TabPage()
        Me.lblRetro = New System.Windows.Forms.Label()
        Me.lblFronte = New System.Windows.Forms.Label()
        Me.pctRetro = New System.Windows.Forms.PictureBox()
        Me.pctFronte = New System.Windows.Forms.PictureBox()
        Me.tpCronologico = New System.Windows.Forms.TabPage()
        Me.DgLavori = New System.Windows.Forms.DataGridView()
        Me.imgLavorazione = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Lavorazione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Note = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpMessaggi = New System.Windows.Forms.TabPage()
        Me.UcAllegati = New Former.ucAllegati()
        Me.tbAnteprima.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.tpModelloCommessa.SuspendLayout()
        CType(Me.pctRetro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctFronte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCronologico.SuspendLayout()
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMessaggi.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbAnteprima
        '
        Me.tbAnteprima.Controls.Add(Me.WebPreview)
        Me.tbAnteprima.Location = New System.Drawing.Point(4, 24)
        Me.tbAnteprima.Name = "tbAnteprima"
        Me.tbAnteprima.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAnteprima.Size = New System.Drawing.Size(330, 585)
        Me.tbAnteprima.TabIndex = 0
        Me.tbAnteprima.Text = "Anteprima"
        Me.tbAnteprima.UseVisualStyleBackColor = True
        '
        'WebPreview
        '
        Me.WebPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebPreview.Location = New System.Drawing.Point(3, 3)
        Me.WebPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebPreview.Name = "WebPreview"
        Me.WebPreview.Size = New System.Drawing.Size(324, 577)
        Me.WebPreview.TabIndex = 0
        '
        'tbMain
        '
        Me.tbMain.Controls.Add(Me.tbAnteprima)
        Me.tbMain.Controls.Add(Me.tpModelloCommessa)
        Me.tbMain.Controls.Add(Me.tpCronologico)
        Me.tbMain.Controls.Add(Me.tpMessaggi)
        Me.tbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbMain.Location = New System.Drawing.Point(0, 0)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.SelectedIndex = 0
        Me.tbMain.Size = New System.Drawing.Size(338, 613)
        Me.tbMain.TabIndex = 0
        '
        'tpModelloCommessa
        '
        Me.tpModelloCommessa.Controls.Add(Me.lblRetro)
        Me.tpModelloCommessa.Controls.Add(Me.lblFronte)
        Me.tpModelloCommessa.Controls.Add(Me.pctRetro)
        Me.tpModelloCommessa.Controls.Add(Me.pctFronte)
        Me.tpModelloCommessa.Location = New System.Drawing.Point(4, 24)
        Me.tpModelloCommessa.Name = "tpModelloCommessa"
        Me.tpModelloCommessa.Padding = New System.Windows.Forms.Padding(3)
        Me.tpModelloCommessa.Size = New System.Drawing.Size(330, 585)
        Me.tpModelloCommessa.TabIndex = 3
        Me.tpModelloCommessa.Text = "Modello Commessa"
        Me.tpModelloCommessa.UseVisualStyleBackColor = True
        '
        'lblRetro
        '
        Me.lblRetro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblRetro.AutoSize = True
        Me.lblRetro.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRetro.Location = New System.Drawing.Point(15, 248)
        Me.lblRetro.Name = "lblRetro"
        Me.lblRetro.Size = New System.Drawing.Size(38, 15)
        Me.lblRetro.TabIndex = 3
        Me.lblRetro.Text = "Retro"
        '
        'lblFronte
        '
        Me.lblFronte.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFronte.AutoSize = True
        Me.lblFronte.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFronte.Location = New System.Drawing.Point(15, 7)
        Me.lblFronte.Name = "lblFronte"
        Me.lblFronte.Size = New System.Drawing.Size(43, 15)
        Me.lblFronte.TabIndex = 2
        Me.lblFronte.Text = "Fronte"
        '
        'pctRetro
        '
        Me.pctRetro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pctRetro.Location = New System.Drawing.Point(15, 266)
        Me.pctRetro.Name = "pctRetro"
        Me.pctRetro.Size = New System.Drawing.Size(300, 220)
        Me.pctRetro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctRetro.TabIndex = 1
        Me.pctRetro.TabStop = False
        '
        'pctFronte
        '
        Me.pctFronte.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pctFronte.Location = New System.Drawing.Point(15, 25)
        Me.pctFronte.Name = "pctFronte"
        Me.pctFronte.Size = New System.Drawing.Size(300, 220)
        Me.pctFronte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctFronte.TabIndex = 0
        Me.pctFronte.TabStop = False
        '
        'tpCronologico
        '
        Me.tpCronologico.Controls.Add(Me.DgLavori)
        Me.tpCronologico.Location = New System.Drawing.Point(4, 24)
        Me.tpCronologico.Name = "tpCronologico"
        Me.tpCronologico.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCronologico.Size = New System.Drawing.Size(330, 585)
        Me.tpCronologico.TabIndex = 2
        Me.tpCronologico.Text = "Avanzamento"
        Me.tpCronologico.UseVisualStyleBackColor = True
        '
        'DgLavori
        '
        Me.DgLavori.AllowUserToAddRows = False
        Me.DgLavori.AllowUserToDeleteRows = False
        Me.DgLavori.AllowUserToOrderColumns = True
        Me.DgLavori.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLavori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgLavori.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgLavori.BackgroundColor = System.Drawing.Color.White
        Me.DgLavori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLavori.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavori.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLavori.ColumnHeadersHeight = 20
        Me.DgLavori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLavori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.imgLavorazione, Me.Lavorazione, Me.Note})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgLavori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgLavori.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavori.EnableHeadersVisualStyles = False
        Me.DgLavori.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavori.Location = New System.Drawing.Point(3, 3)
        Me.DgLavori.MultiSelect = False
        Me.DgLavori.Name = "DgLavori"
        Me.DgLavori.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgLavori.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgLavori.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLavori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavori.Size = New System.Drawing.Size(324, 579)
        Me.DgLavori.TabIndex = 107
        Me.DgLavori.TabStop = False
        '
        'imgLavorazione
        '
        Me.imgLavorazione.DataPropertyName = "ImgIcoLavoro"
        Me.imgLavorazione.Frozen = True
        Me.imgLavorazione.HeaderText = ""
        Me.imgLavorazione.Name = "imgLavorazione"
        Me.imgLavorazione.ReadOnly = True
        Me.imgLavorazione.Width = 5
        '
        'Lavorazione
        '
        Me.Lavorazione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Lavorazione.DataPropertyName = "Descrizione"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Lavorazione.DefaultCellStyle = DataGridViewCellStyle3
        Me.Lavorazione.HeaderText = "Lavorazione"
        Me.Lavorazione.Name = "Lavorazione"
        Me.Lavorazione.ReadOnly = True
        Me.Lavorazione.Width = 97
        '
        'Note
        '
        Me.Note.DataPropertyName = "PrendibileDa"
        Me.Note.HeaderText = "Prendibile da "
        Me.Note.Name = "Note"
        Me.Note.ReadOnly = True
        Me.Note.Width = 107
        '
        'tpMessaggi
        '
        Me.tpMessaggi.Controls.Add(Me.UcAllegati)
        Me.tpMessaggi.Location = New System.Drawing.Point(4, 24)
        Me.tpMessaggi.Name = "tpMessaggi"
        Me.tpMessaggi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMessaggi.Size = New System.Drawing.Size(330, 585)
        Me.tpMessaggi.TabIndex = 1
        Me.tpMessaggi.Text = "Messaggi"
        Me.tpMessaggi.UseVisualStyleBackColor = True
        '
        'UcAllegati
        '
        Me.UcAllegati.BackColor = System.Drawing.Color.White
        Me.UcAllegati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAllegati.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAllegati.FromOperatore = False
        Me.UcAllegati.Location = New System.Drawing.Point(3, 3)
        Me.UcAllegati.Name = "UcAllegati"
        Me.UcAllegati.Size = New System.Drawing.Size(324, 579)
        Me.UcAllegati.TabIndex = 0
        '
        'ucAnteprimaOperatore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tbMain)
        Me.Name = "ucAnteprimaOperatore"
        Me.Size = New System.Drawing.Size(338, 613)
        Me.tbAnteprima.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.tpModelloCommessa.ResumeLayout(False)
        Me.tpModelloCommessa.PerformLayout()
        CType(Me.pctRetro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctFronte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCronologico.ResumeLayout(False)
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMessaggi.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbAnteprima As System.Windows.Forms.TabPage
    Friend WithEvents tbMain As System.Windows.Forms.TabControl
    Friend WithEvents WebPreview As System.Windows.Forms.WebBrowser
    Friend WithEvents tpMessaggi As System.Windows.Forms.TabPage
    Friend WithEvents UcAllegati As Former.ucAllegati
    Friend WithEvents tpCronologico As TabPage
    Friend WithEvents DgLavori As DataGridView
    Friend WithEvents Note As DataGridViewTextBoxColumn
    Friend WithEvents Lavorazione As DataGridViewTextBoxColumn
    Friend WithEvents imgLavorazione As DataGridViewImageColumn
    Friend WithEvents tpModelloCommessa As TabPage
    Friend WithEvents pctRetro As PictureBox
    Friend WithEvents pctFronte As PictureBox
    Friend WithEvents lblRetro As Label
    Friend WithEvents lblFronte As Label
End Class
