<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucListinoFormatoMacchina
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucListinoFormatoMacchina))
        Me.dgFormatoMacchina = New System.Windows.Forms.DataGridView()
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoStr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MinutiAvv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaricoMensile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostoSingCopia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CopieOra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lnkModFormato = New System.Windows.Forms.LinkLabel()
        Me.imlPuls = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkDelFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkAddFormato = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        CType(Me.dgFormatoMacchina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgFormatoMacchina
        '
        Me.dgFormatoMacchina.AllowUserToAddRows = False
        Me.dgFormatoMacchina.AllowUserToDeleteRows = False
        Me.dgFormatoMacchina.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgFormatoMacchina.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgFormatoMacchina.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgFormatoMacchina.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgFormatoMacchina.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgFormatoMacchina.BackgroundColor = System.Drawing.Color.White
        Me.dgFormatoMacchina.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgFormatoMacchina.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgFormatoMacchina.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgFormatoMacchina.ColumnHeadersHeight = 20
        Me.dgFormatoMacchina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgFormatoMacchina.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Img, Me.DataGridViewTextBoxColumn6, Me.TipoStr, Me.MinutiAvv, Me.CaricoMensile, Me.CostoSingCopia, Me.CopieOra})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgFormatoMacchina.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgFormatoMacchina.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgFormatoMacchina.EnableHeadersVisualStyles = False
        Me.dgFormatoMacchina.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgFormatoMacchina.Location = New System.Drawing.Point(3, 38)
        Me.dgFormatoMacchina.MultiSelect = False
        Me.dgFormatoMacchina.Name = "dgFormatoMacchina"
        Me.dgFormatoMacchina.ReadOnly = True
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgFormatoMacchina.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgFormatoMacchina.RowHeadersVisible = False
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black
        Me.dgFormatoMacchina.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.dgFormatoMacchina.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgFormatoMacchina.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgFormatoMacchina.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgFormatoMacchina.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgFormatoMacchina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFormatoMacchina.Size = New System.Drawing.Size(997, 521)
        Me.dgFormatoMacchina.TabIndex = 81
        Me.dgFormatoMacchina.TabStop = False
        '
        'Img
        '
        Me.Img.DataPropertyName = "Img"
        Me.Img.HeaderText = "Img"
        Me.Img.Name = "Img"
        Me.Img.ReadOnly = True
        Me.Img.Width = 33
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Formato"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Formato"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 76
        '
        'TipoStr
        '
        Me.TipoStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TipoStr.DataPropertyName = "DivisioneFoglio"
        Me.TipoStr.HeaderText = "Divisione Foglio"
        Me.TipoStr.Name = "TipoStr"
        Me.TipoStr.ReadOnly = True
        Me.TipoStr.Width = 115
        '
        'MinutiAvv
        '
        Me.MinutiAvv.DataPropertyName = "Altezza"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.MinutiAvv.DefaultCellStyle = DataGridViewCellStyle12
        Me.MinutiAvv.HeaderText = "Altezza"
        Me.MinutiAvv.Name = "MinutiAvv"
        Me.MinutiAvv.ReadOnly = True
        Me.MinutiAvv.Width = 68
        '
        'CaricoMensile
        '
        Me.CaricoMensile.DataPropertyName = "Larghezza"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CaricoMensile.DefaultCellStyle = DataGridViewCellStyle13
        Me.CaricoMensile.HeaderText = "Larghezza"
        Me.CaricoMensile.Name = "CaricoMensile"
        Me.CaricoMensile.ReadOnly = True
        Me.CaricoMensile.Width = 83
        '
        'CostoSingCopia
        '
        Me.CostoSingCopia.DataPropertyName = "CostoLastra"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "0.00"
        Me.CostoSingCopia.DefaultCellStyle = DataGridViewCellStyle14
        Me.CostoSingCopia.HeaderText = "Costo Lastra"
        Me.CostoSingCopia.Name = "CostoSingCopia"
        Me.CostoSingCopia.ReadOnly = True
        Me.CostoSingCopia.Width = 96
        '
        'CopieOra
        '
        Me.CopieOra.DataPropertyName = "MacchinarioStr"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CopieOra.DefaultCellStyle = DataGridViewCellStyle15
        Me.CopieOra.HeaderText = "Macchinario"
        Me.CopieOra.Name = "CopieOra"
        Me.CopieOra.ReadOnly = True
        Me.CopieOra.Width = 97
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._FormatoMacchina
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 82
        Me.PictureBox1.TabStop = False
        '
        'lnkModFormato
        '
        Me.lnkModFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkModFormato.AutoSize = True
        Me.lnkModFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModFormato.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkModFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModFormato.Location = New System.Drawing.Point(827, 5)
        Me.lnkModFormato.Name = "lnkModFormato"
        Me.lnkModFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkModFormato.Size = New System.Drawing.Size(84, 27)
        Me.lnkModFormato.TabIndex = 88
        Me.lnkModFormato.TabStop = True
        Me.lnkModFormato.Text = "Modifica"
        Me.lnkModFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.lnkDelFormato.Location = New System.Drawing.Point(916, 5)
        Me.lnkDelFormato.Name = "lnkDelFormato"
        Me.lnkDelFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDelFormato.Size = New System.Drawing.Size(81, 27)
        Me.lnkDelFormato.TabIndex = 87
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
        Me.lnkAddFormato.Location = New System.Drawing.Point(735, 5)
        Me.lnkAddFormato.Name = "lnkAddFormato"
        Me.lnkAddFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAddFormato.Size = New System.Drawing.Size(86, 27)
        Me.lnkAddFormato.TabIndex = 86
        Me.lnkAddFormato.TabStop = True
        Me.lnkAddFormato.Text = "Aggiungi"
        Me.lnkAddFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(41, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(215, 21)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Formato Carta in Macchina"
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiorna.AutoSize = True
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(643, 5)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAggiorna.Size = New System.Drawing.Size(86, 27)
        Me.lnkAggiorna.TabIndex = 107
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucListinoFormatoMacchina
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkAggiorna)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lnkModFormato)
        Me.Controls.Add(Me.lnkDelFormato)
        Me.Controls.Add(Me.lnkAddFormato)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgFormatoMacchina)
        Me.Name = "ucListinoFormatoMacchina"
        Me.Size = New System.Drawing.Size(1004, 563)
        CType(Me.dgFormatoMacchina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgFormatoMacchina As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lnkModFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents imlPuls As System.Windows.Forms.ImageList
    Friend WithEvents lnkDelFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAddFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoStr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinutiAvv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaricoMensile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostoSingCopia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CopieOra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkAggiorna As LinkLabel
End Class
