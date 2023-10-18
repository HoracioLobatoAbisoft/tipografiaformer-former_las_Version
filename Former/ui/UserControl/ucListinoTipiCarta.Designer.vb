<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoTipiCarta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucListinoTipiCarta))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbFinitura = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lnkModTipol = New System.Windows.Forms.LinkLabel()
        Me.imlPuls = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkDelTipol = New System.Windows.Forms.LinkLabel()
        Me.lnkAddTipol = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgTipologie = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipologia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostoCarta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AltezzaMicron = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCarta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RisorseAssociate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.lnkDuplica = New System.Windows.Forms.LinkLabel()
        Me.chkOnlyOrder = New System.Windows.Forms.CheckBox()
        Me.chkNoRisorse = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTipologie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbFinitura
        '
        Me.cmbFinitura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFinitura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFinitura.FormattingEnabled = True
        Me.cmbFinitura.Location = New System.Drawing.Point(679, 9)
        Me.cmbFinitura.Name = "cmbFinitura"
        Me.cmbFinitura.Size = New System.Drawing.Size(185, 23)
        Me.cmbFinitura.TabIndex = 105
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(626, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 15)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "Finitura"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._TipoCarta
        Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 103
        Me.PictureBox2.TabStop = False
        '
        'lnkModTipol
        '
        Me.lnkModTipol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkModTipol.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModTipol.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkModTipol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModTipol.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModTipol.Location = New System.Drawing.Point(1056, 3)
        Me.lnkModTipol.Name = "lnkModTipol"
        Me.lnkModTipol.Size = New System.Drawing.Size(79, 32)
        Me.lnkModTipol.TabIndex = 102
        Me.lnkModTipol.TabStop = True
        Me.lnkModTipol.Text = "Modifica"
        Me.lnkModTipol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imlPuls
        '
        Me.imlPuls.ImageStream = CType(resources.GetObject("imlPuls.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPuls.TransparentColor = System.Drawing.Color.Transparent
        Me.imlPuls.Images.SetKeyName(0, "Button Delete.png")
        Me.imlPuls.Images.SetKeyName(1, "Button Add.png")
        Me.imlPuls.Images.SetKeyName(2, "Edit.png")
        '
        'lnkDelTipol
        '
        Me.lnkDelTipol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDelTipol.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelTipol.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelTipol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelTipol.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelTipol.Location = New System.Drawing.Point(1141, 3)
        Me.lnkDelTipol.Name = "lnkDelTipol"
        Me.lnkDelTipol.Size = New System.Drawing.Size(79, 32)
        Me.lnkDelTipol.TabIndex = 101
        Me.lnkDelTipol.TabStop = True
        Me.lnkDelTipol.Text = "Rimuovi"
        Me.lnkDelTipol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAddTipol
        '
        Me.lnkAddTipol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAddTipol.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAddTipol.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAddTipol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAddTipol.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAddTipol.Location = New System.Drawing.Point(968, 3)
        Me.lnkAddTipol.Name = "lnkAddTipol"
        Me.lnkAddTipol.Size = New System.Drawing.Size(82, 32)
        Me.lnkAddTipol.TabIndex = 100
        Me.lnkAddTipol.TabStop = True
        Me.lnkAddTipol.Text = "Aggiungi"
        Me.lnkAddTipol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(41, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 21)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Tipologie Carta"
        '
        'dgTipologie
        '
        Me.dgTipologie.AllowUserToAddRows = False
        Me.dgTipologie.AllowUserToDeleteRows = False
        Me.dgTipologie.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgTipologie.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgTipologie.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTipologie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgTipologie.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgTipologie.BackgroundColor = System.Drawing.Color.White
        Me.dgTipologie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgTipologie.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTipologie.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgTipologie.ColumnHeadersHeight = 20
        Me.dgTipologie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgTipologie.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn2, Me.DataGridViewTextBoxColumn1, Me.Tipologia, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.CostoCarta, Me.AltezzaMicron, Me.TipoCarta, Me.RisorseAssociate})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTipologie.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgTipologie.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgTipologie.EnableHeadersVisualStyles = False
        Me.dgTipologie.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgTipologie.Location = New System.Drawing.Point(3, 38)
        Me.dgTipologie.MultiSelect = False
        Me.dgTipologie.Name = "dgTipologie"
        Me.dgTipologie.ReadOnly = True
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTipologie.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgTipologie.RowHeadersVisible = False
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black
        Me.dgTipologie.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.dgTipologie.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgTipologie.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgTipologie.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgTipologie.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTipologie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTipologie.Size = New System.Drawing.Size(1217, 476)
        Me.dgTipologie.TabIndex = 98
        Me.dgTipologie.TabStop = False
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.DataPropertyName = "Img"
        Me.DataGridViewImageColumn2.HeaderText = "Img"
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Width = 33
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Sigla"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Sigla"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 56
        '
        'Tipologia
        '
        Me.Tipologia.DataPropertyName = "Tipologia"
        Me.Tipologia.HeaderText = "Tipologia"
        Me.Tipologia.Name = "Tipologia"
        Me.Tipologia.ReadOnly = True
        Me.Tipologia.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Finitura"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Finitura"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 71
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Grammi"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn4.HeaderText = "Grammi"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 74
        '
        'CostoCarta
        '
        Me.CostoCarta.DataPropertyName = "CostoCartaKg"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CostoCarta.DefaultCellStyle = DataGridViewCellStyle13
        Me.CostoCarta.HeaderText = "Prezzo/kg"
        Me.CostoCarta.Name = "CostoCarta"
        Me.CostoCarta.ReadOnly = True
        Me.CostoCarta.Width = 83
        '
        'AltezzaMicron
        '
        Me.AltezzaMicron.DataPropertyName = "Spessore"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.AltezzaMicron.DefaultCellStyle = DataGridViewCellStyle14
        Me.AltezzaMicron.HeaderText = "Altezza Micron"
        Me.AltezzaMicron.Name = "AltezzaMicron"
        Me.AltezzaMicron.ReadOnly = True
        Me.AltezzaMicron.Width = 109
        '
        'TipoCarta
        '
        Me.TipoCarta.DataPropertyName = "TipoCartaStr"
        Me.TipoCarta.HeaderText = "Tipo Carta"
        Me.TipoCarta.Name = "TipoCarta"
        Me.TipoCarta.ReadOnly = True
        Me.TipoCarta.Width = 85
        '
        'RisorseAssociate
        '
        Me.RisorseAssociate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.RisorseAssociate.DataPropertyName = "RisorseAssociateStr"
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RisorseAssociate.DefaultCellStyle = DataGridViewCellStyle15
        Me.RisorseAssociate.HeaderText = "Risorse Associate"
        Me.RisorseAssociate.Name = "RisorseAssociate"
        Me.RisorseAssociate.ReadOnly = True
        Me.RisorseAssociate.Width = 300
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiorna.Location = New System.Drawing.Point(174, 3)
        Me.btnAggiorna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(95, 32)
        Me.btnAggiorna.TabIndex = 106
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'lnkDuplica
        '
        Me.lnkDuplica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDuplica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDuplica.Image = Global.Former.My.Resources.Resources._Duplica
        Me.lnkDuplica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDuplica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDuplica.Location = New System.Drawing.Point(883, 3)
        Me.lnkDuplica.Name = "lnkDuplica"
        Me.lnkDuplica.Size = New System.Drawing.Size(79, 32)
        Me.lnkDuplica.TabIndex = 108
        Me.lnkDuplica.TabStop = True
        Me.lnkDuplica.Text = "Duplica"
        Me.lnkDuplica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkOnlyOrder
        '
        Me.chkOnlyOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOnlyOrder.AutoSize = True
        Me.chkOnlyOrder.Location = New System.Drawing.Point(494, 11)
        Me.chkOnlyOrder.Name = "chkOnlyOrder"
        Me.chkOnlyOrder.Size = New System.Drawing.Size(126, 19)
        Me.chkOnlyOrder.TabIndex = 109
        Me.chkOnlyOrder.Text = "Con Ordini in coda"
        Me.chkOnlyOrder.UseVisualStyleBackColor = True
        '
        'chkNoRisorse
        '
        Me.chkNoRisorse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNoRisorse.AutoSize = True
        Me.chkNoRisorse.Location = New System.Drawing.Point(344, 11)
        Me.chkNoRisorse.Name = "chkNoRisorse"
        Me.chkNoRisorse.Size = New System.Drawing.Size(144, 19)
        Me.chkNoRisorse.TabIndex = 110
        Me.chkNoRisorse.Text = "Senza risorse associate"
        Me.chkNoRisorse.UseVisualStyleBackColor = True
        '
        'ucListinoTipiCarta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.chkNoRisorse)
        Me.Controls.Add(Me.chkOnlyOrder)
        Me.Controls.Add(Me.lnkDuplica)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.cmbFinitura)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lnkModTipol)
        Me.Controls.Add(Me.lnkDelTipol)
        Me.Controls.Add(Me.lnkAddTipol)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgTipologie)
        Me.Name = "ucListinoTipiCarta"
        Me.Size = New System.Drawing.Size(1223, 517)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTipologie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbFinitura As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lnkModTipol As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDelTipol As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAddTipol As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgTipologie As System.Windows.Forms.DataGridView
    Friend WithEvents imlPuls As System.Windows.Forms.ImageList
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents lnkDuplica As System.Windows.Forms.LinkLabel
    Friend WithEvents RisorseAssociate As DataGridViewTextBoxColumn
    Friend WithEvents TipoCarta As DataGridViewTextBoxColumn
    Friend WithEvents AltezzaMicron As DataGridViewTextBoxColumn
    Friend WithEvents CostoCarta As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Tipologia As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents chkOnlyOrder As CheckBox
    Friend WithEvents chkNoRisorse As CheckBox
End Class
