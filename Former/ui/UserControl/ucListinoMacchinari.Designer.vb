<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoMacchinari
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgMacchinari = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lnkModFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkDelFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkAddFormato = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.btnOrdineMacchinari = New System.Windows.Forms.Button()
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoStr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepartoDefault = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ordinamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MinutiAvv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostoMinAvv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostoSingCopia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostoMensile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaricoMensile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CopieOra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgMacchinari, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgMacchinari
        '
        Me.dgMacchinari.AllowUserToAddRows = False
        Me.dgMacchinari.AllowUserToDeleteRows = False
        Me.dgMacchinari.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgMacchinari.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMacchinari.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMacchinari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgMacchinari.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgMacchinari.BackgroundColor = System.Drawing.Color.White
        Me.dgMacchinari.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMacchinari.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMacchinari.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgMacchinari.ColumnHeadersHeight = 20
        Me.dgMacchinari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMacchinari.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Img, Me.DataGridViewTextBoxColumn6, Me.TipoStr, Me.RepartoDefault, Me.Ordinamento, Me.MinutiAvv, Me.CostoMinAvv, Me.CostoSingCopia, Me.CostoMensile, Me.CaricoMensile, Me.CopieOra})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMacchinari.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgMacchinari.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgMacchinari.EnableHeadersVisualStyles = False
        Me.dgMacchinari.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgMacchinari.Location = New System.Drawing.Point(3, 40)
        Me.dgMacchinari.MultiSelect = False
        Me.dgMacchinari.Name = "dgMacchinari"
        Me.dgMacchinari.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMacchinari.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgMacchinari.RowHeadersVisible = False
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        Me.dgMacchinari.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgMacchinari.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgMacchinari.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgMacchinari.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgMacchinari.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMacchinari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMacchinari.Size = New System.Drawing.Size(997, 519)
        Me.dgMacchinari.TabIndex = 81
        Me.dgMacchinari.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Macchinari
        Me.PictureBox1.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 82
        Me.PictureBox1.TabStop = False
        '
        'lnkModFormato
        '
        Me.lnkModFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkModFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModFormato.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkModFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModFormato.Location = New System.Drawing.Point(827, 5)
        Me.lnkModFormato.Name = "lnkModFormato"
        Me.lnkModFormato.Size = New System.Drawing.Size(83, 32)
        Me.lnkModFormato.TabIndex = 88
        Me.lnkModFormato.TabStop = True
        Me.lnkModFormato.Text = "Modifica"
        Me.lnkModFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDelFormato
        '
        Me.lnkDelFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDelFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelFormato.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelFormato.Location = New System.Drawing.Point(916, 5)
        Me.lnkDelFormato.Name = "lnkDelFormato"
        Me.lnkDelFormato.Size = New System.Drawing.Size(84, 32)
        Me.lnkDelFormato.TabIndex = 87
        Me.lnkDelFormato.TabStop = True
        Me.lnkDelFormato.Text = "Rimuovi"
        Me.lnkDelFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAddFormato
        '
        Me.lnkAddFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAddFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAddFormato.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAddFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAddFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAddFormato.Location = New System.Drawing.Point(735, 5)
        Me.lnkAddFormato.Name = "lnkAddFormato"
        Me.lnkAddFormato.Size = New System.Drawing.Size(86, 32)
        Me.lnkAddFormato.TabIndex = 86
        Me.lnkAddFormato.TabStop = True
        Me.lnkAddFormato.Text = "Aggiungi"
        Me.lnkAddFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(43, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 21)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Macchinari"
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiorna.Location = New System.Drawing.Point(163, 5)
        Me.btnAggiorna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(95, 32)
        Me.btnAggiorna.TabIndex = 106
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'btnOrdineMacchinari
        '
        Me.btnOrdineMacchinari.BackColor = System.Drawing.Color.White
        Me.btnOrdineMacchinari.FlatAppearance.BorderSize = 0
        Me.btnOrdineMacchinari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrdineMacchinari.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnOrdineMacchinari.Image = Global.Former.My.Resources.Resources._Ordinamento
        Me.btnOrdineMacchinari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOrdineMacchinari.Location = New System.Drawing.Point(264, 5)
        Me.btnOrdineMacchinari.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOrdineMacchinari.Name = "btnOrdineMacchinari"
        Me.btnOrdineMacchinari.Size = New System.Drawing.Size(210, 32)
        Me.btnOrdineMacchinari.TabIndex = 107
        Me.btnOrdineMacchinari.Text = "Ordine Esecuzione Macchinari"
        Me.btnOrdineMacchinari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOrdineMacchinari.UseVisualStyleBackColor = False
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
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Descrizione"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Descrizione"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 91
        '
        'TipoStr
        '
        Me.TipoStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TipoStr.DataPropertyName = "TipoStr"
        Me.TipoStr.HeaderText = "Tipo"
        Me.TipoStr.Name = "TipoStr"
        Me.TipoStr.ReadOnly = True
        Me.TipoStr.Width = 55
        '
        'RepartoDefault
        '
        Me.RepartoDefault.DataPropertyName = "RepartoDefaultStr"
        Me.RepartoDefault.HeaderText = "Reparto Default"
        Me.RepartoDefault.Name = "RepartoDefault"
        Me.RepartoDefault.ReadOnly = True
        Me.RepartoDefault.Width = 113
        '
        'Ordinamento
        '
        Me.Ordinamento.DataPropertyName = "Ordinamento"
        Me.Ordinamento.HeaderText = "Ordinamento"
        Me.Ordinamento.Name = "Ordinamento"
        Me.Ordinamento.ReadOnly = True
        Me.Ordinamento.Width = 102
        '
        'MinutiAvv
        '
        Me.MinutiAvv.DataPropertyName = "MinutiAvv"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.MinutiAvv.DefaultCellStyle = DataGridViewCellStyle3
        Me.MinutiAvv.HeaderText = "Minuti Avviamento"
        Me.MinutiAvv.Name = "MinutiAvv"
        Me.MinutiAvv.ReadOnly = True
        Me.MinutiAvv.Width = 133
        '
        'CostoMinAvv
        '
        Me.CostoMinAvv.DataPropertyName = "CostoMinAvv"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "0.00"
        Me.CostoMinAvv.DefaultCellStyle = DataGridViewCellStyle4
        Me.CostoMinAvv.HeaderText = "Costo Minimo Avviamento"
        Me.CostoMinAvv.Name = "CostoMinAvv"
        Me.CostoMinAvv.ReadOnly = True
        Me.CostoMinAvv.Width = 174
        '
        'CostoSingCopia
        '
        Me.CostoSingCopia.DataPropertyName = "CostoSingCopia"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "0.0000"
        Me.CostoSingCopia.DefaultCellStyle = DataGridViewCellStyle5
        Me.CostoSingCopia.HeaderText = "Costo Singola Copia"
        Me.CostoSingCopia.Name = "CostoSingCopia"
        Me.CostoSingCopia.ReadOnly = True
        Me.CostoSingCopia.Width = 138
        '
        'CostoMensile
        '
        Me.CostoMensile.DataPropertyName = "CostoMensile"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "0.00"
        Me.CostoMensile.DefaultCellStyle = DataGridViewCellStyle6
        Me.CostoMensile.HeaderText = "Costo Mensile"
        Me.CostoMensile.Name = "CostoMensile"
        Me.CostoMensile.ReadOnly = True
        Me.CostoMensile.Width = 106
        '
        'CaricoMensile
        '
        Me.CaricoMensile.DataPropertyName = "CaricoPrevistoMensile"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CaricoMensile.DefaultCellStyle = DataGridViewCellStyle7
        Me.CaricoMensile.HeaderText = "Carico Mensile"
        Me.CaricoMensile.Name = "CaricoMensile"
        Me.CaricoMensile.ReadOnly = True
        Me.CaricoMensile.Width = 109
        '
        'CopieOra
        '
        Me.CopieOra.DataPropertyName = "CopieOra"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CopieOra.DefaultCellStyle = DataGridViewCellStyle8
        Me.CopieOra.HeaderText = "Copie Ora"
        Me.CopieOra.Name = "CopieOra"
        Me.CopieOra.ReadOnly = True
        Me.CopieOra.Width = 84
        '
        'ucListinoMacchinari
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnOrdineMacchinari)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lnkModFormato)
        Me.Controls.Add(Me.lnkDelFormato)
        Me.Controls.Add(Me.lnkAddFormato)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgMacchinari)
        Me.Name = "ucListinoMacchinari"
        Me.Size = New System.Drawing.Size(1004, 563)
        CType(Me.dgMacchinari, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgMacchinari As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lnkModFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDelFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAddFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents btnOrdineMacchinari As Button
    Friend WithEvents Img As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents TipoStr As DataGridViewTextBoxColumn
    Friend WithEvents RepartoDefault As DataGridViewTextBoxColumn
    Friend WithEvents Ordinamento As DataGridViewTextBoxColumn
    Friend WithEvents MinutiAvv As DataGridViewTextBoxColumn
    Friend WithEvents CostoMinAvv As DataGridViewTextBoxColumn
    Friend WithEvents CostoSingCopia As DataGridViewTextBoxColumn
    Friend WithEvents CostoMensile As DataGridViewTextBoxColumn
    Friend WithEvents CaricoMensile As DataGridViewTextBoxColumn
    Friend WithEvents CopieOra As DataGridViewTextBoxColumn
End Class
