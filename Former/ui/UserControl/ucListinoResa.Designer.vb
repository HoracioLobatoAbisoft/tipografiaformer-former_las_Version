<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoResa
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgResa = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormatoMacchina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Scarto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lnkDelFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkAddFormato = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.lnkMod = New System.Windows.Forms.LinkLabel()
        CType(Me.dgResa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgResa
        '
        Me.dgResa.AllowUserToAddRows = False
        Me.dgResa.AllowUserToDeleteRows = False
        Me.dgResa.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgResa.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgResa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgResa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgResa.BackgroundColor = System.Drawing.Color.White
        Me.dgResa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgResa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgResa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgResa.ColumnHeadersHeight = 20
        Me.dgResa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgResa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.FormatoMacchina, Me.DataGridViewTextBoxColumn6, Me.Scarto})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgResa.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgResa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgResa.EnableHeadersVisualStyles = False
        Me.dgResa.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgResa.Location = New System.Drawing.Point(3, 38)
        Me.dgResa.MultiSelect = False
        Me.dgResa.Name = "dgResa"
        Me.dgResa.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgResa.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgResa.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgResa.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgResa.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgResa.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgResa.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgResa.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgResa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgResa.Size = New System.Drawing.Size(879, 305)
        Me.dgResa.TabIndex = 81
        Me.dgResa.TabStop = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "FcStr"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Formato Carta"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 107
        '
        'FormatoMacchina
        '
        Me.FormatoMacchina.DataPropertyName = "FmStr"
        Me.FormatoMacchina.HeaderText = "Formato Macchina"
        Me.FormatoMacchina.Name = "FormatoMacchina"
        Me.FormatoMacchina.ReadOnly = True
        Me.FormatoMacchina.Width = 131
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Resa"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Resa"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 55
        '
        'Scarto
        '
        Me.Scarto.DataPropertyName = "PercScarto"
        Me.Scarto.HeaderText = "Scarto"
        Me.Scarto.Name = "Scarto"
        Me.Scarto.ReadOnly = True
        Me.Scarto.Width = 64
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Resa
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 83
        Me.PictureBox1.TabStop = False
        '
        'lnkDelFormato
        '
        Me.lnkDelFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDelFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelFormato.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelFormato.Location = New System.Drawing.Point(804, 3)
        Me.lnkDelFormato.Name = "lnkDelFormato"
        Me.lnkDelFormato.Size = New System.Drawing.Size(78, 32)
        Me.lnkDelFormato.TabIndex = 89
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
        Me.lnkAddFormato.Location = New System.Drawing.Point(627, 3)
        Me.lnkAddFormato.Name = "lnkAddFormato"
        Me.lnkAddFormato.Size = New System.Drawing.Size(83, 32)
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
        Me.Label4.Size = New System.Drawing.Size(45, 21)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Resa"
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiorna.Location = New System.Drawing.Point(111, 3)
        Me.btnAggiorna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(95, 32)
        Me.btnAggiorna.TabIndex = 106
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'lnkMod
        '
        Me.lnkMod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkMod.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkMod.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkMod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkMod.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkMod.Location = New System.Drawing.Point(716, 3)
        Me.lnkMod.Name = "lnkMod"
        Me.lnkMod.Size = New System.Drawing.Size(82, 32)
        Me.lnkMod.TabIndex = 107
        Me.lnkMod.TabStop = True
        Me.lnkMod.Text = "Modifica"
        Me.lnkMod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucListinoResa
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkMod)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lnkDelFormato)
        Me.Controls.Add(Me.lnkAddFormato)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgResa)
        Me.Name = "ucListinoResa"
        Me.Size = New System.Drawing.Size(885, 346)
        CType(Me.dgResa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgResa As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lnkDelFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAddFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormatoMacchina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Scarto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents lnkMod As System.Windows.Forms.LinkLabel

End Class
