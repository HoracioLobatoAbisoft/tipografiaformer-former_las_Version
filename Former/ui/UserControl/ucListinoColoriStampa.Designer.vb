<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoColoriStampa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucListinoColoriStampa))
        Me.dgColori = New System.Windows.Forms.DataGridView()
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormatoMacchina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Scarto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.imlPuls = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkDelFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkAddFormato = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkModFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkDuplica = New System.Windows.Forms.LinkLabel()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        CType(Me.dgColori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgColori
        '
        Me.dgColori.AllowUserToAddRows = False
        Me.dgColori.AllowUserToDeleteRows = False
        Me.dgColori.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgColori.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgColori.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgColori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgColori.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgColori.BackgroundColor = System.Drawing.Color.White
        Me.dgColori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgColori.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgColori.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgColori.ColumnHeadersHeight = 20
        Me.dgColori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgColori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Img, Me.DataGridViewTextBoxColumn2, Me.FormatoMacchina, Me.DataGridViewTextBoxColumn6, Me.Scarto})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgColori.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgColori.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgColori.EnableHeadersVisualStyles = False
        Me.dgColori.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgColori.Location = New System.Drawing.Point(3, 38)
        Me.dgColori.MultiSelect = False
        Me.dgColori.Name = "dgColori"
        Me.dgColori.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgColori.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgColori.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgColori.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgColori.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgColori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgColori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgColori.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgColori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgColori.Size = New System.Drawing.Size(879, 305)
        Me.dgColori.TabIndex = 81
        Me.dgColori.TabStop = False
        '
        'Img
        '
        Me.Img.DataPropertyName = "Img"
        Me.Img.HeaderText = "Img"
        Me.Img.Name = "Img"
        Me.Img.ReadOnly = True
        Me.Img.Width = 33
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Sigla"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Sigla"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 56
        '
        'FormatoMacchina
        '
        Me.FormatoMacchina.DataPropertyName = "Descrizione"
        Me.FormatoMacchina.HeaderText = "Descrizione"
        Me.FormatoMacchina.Name = "FormatoMacchina"
        Me.FormatoMacchina.ReadOnly = True
        Me.FormatoMacchina.Width = 91
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "FR"
        Me.DataGridViewTextBoxColumn6.HeaderText = "F/R"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 49
        '
        'Scarto
        '
        Me.Scarto.DataPropertyName = "NLastre"
        Me.Scarto.HeaderText = "Lastre"
        Me.Scarto.Name = "Scarto"
        Me.Scarto.ReadOnly = True
        Me.Scarto.Width = 62
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._ColoreStampa
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 83
        Me.PictureBox1.TabStop = False
        '
        'imlPuls
        '
        Me.imlPuls.ImageStream = CType(resources.GetObject("imlPuls.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPuls.TransparentColor = System.Drawing.Color.Transparent
        Me.imlPuls.Images.SetKeyName(0, "Button Delete.png")
        Me.imlPuls.Images.SetKeyName(1, "Button Add.png")
        Me.imlPuls.Images.SetKeyName(2, "Edit.png")
        '
        'lnkDelFormato
        '
        Me.lnkDelFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDelFormato.AutoSize = True
        Me.lnkDelFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelFormato.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelFormato.Location = New System.Drawing.Point(798, 3)
        Me.lnkDelFormato.Name = "lnkDelFormato"
        Me.lnkDelFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDelFormato.Size = New System.Drawing.Size(81, 27)
        Me.lnkDelFormato.TabIndex = 89
        Me.lnkDelFormato.TabStop = True
        Me.lnkDelFormato.Text = "Rimuovi"
        Me.lnkDelFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAddFormato
        '
        Me.lnkAddFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAddFormato.AutoSize = True
        Me.lnkAddFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAddFormato.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAddFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAddFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAddFormato.Location = New System.Drawing.Point(616, 3)
        Me.lnkAddFormato.Name = "lnkAddFormato"
        Me.lnkAddFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAddFormato.Size = New System.Drawing.Size(86, 27)
        Me.lnkAddFormato.TabIndex = 88
        Me.lnkAddFormato.TabStop = True
        Me.lnkAddFormato.Text = "Aggiungi"
        Me.lnkAddFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(41, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 21)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Colori di Stampa"
        '
        'lnkModFormato
        '
        Me.lnkModFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkModFormato.AutoSize = True
        Me.lnkModFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModFormato.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkModFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModFormato.Location = New System.Drawing.Point(710, 3)
        Me.lnkModFormato.Name = "lnkModFormato"
        Me.lnkModFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkModFormato.Size = New System.Drawing.Size(84, 27)
        Me.lnkModFormato.TabIndex = 91
        Me.lnkModFormato.TabStop = True
        Me.lnkModFormato.Text = "Modifica"
        Me.lnkModFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDuplica
        '
        Me.lnkDuplica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDuplica.AutoSize = True
        Me.lnkDuplica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDuplica.Image = Global.Former.My.Resources.Resources._Duplica
        Me.lnkDuplica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDuplica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDuplica.Location = New System.Drawing.Point(531, 3)
        Me.lnkDuplica.Name = "lnkDuplica"
        Me.lnkDuplica.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDuplica.Size = New System.Drawing.Size(77, 27)
        Me.lnkDuplica.TabIndex = 108
        Me.lnkDuplica.TabStop = True
        Me.lnkDuplica.Text = "Duplica"
        Me.lnkDuplica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiorna.AutoSize = True
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(204, 3)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAggiorna.Size = New System.Drawing.Size(86, 27)
        Me.lnkAggiorna.TabIndex = 109
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucListinoColoriStampa
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkAggiorna)
        Me.Controls.Add(Me.lnkDuplica)
        Me.Controls.Add(Me.lnkModFormato)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lnkDelFormato)
        Me.Controls.Add(Me.lnkAddFormato)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgColori)
        Me.Name = "ucListinoColoriStampa"
        Me.Size = New System.Drawing.Size(885, 346)
        CType(Me.dgColori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgColori As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents imlPuls As System.Windows.Forms.ImageList
    Friend WithEvents lnkDelFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAddFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lnkModFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents Img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormatoMacchina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Scarto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkDuplica As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAggiorna As LinkLabel
End Class
