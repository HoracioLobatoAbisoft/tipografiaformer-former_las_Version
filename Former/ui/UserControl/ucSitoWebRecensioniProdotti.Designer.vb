<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSitoWebRecensioniProdotti
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
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.DgReview = New System.Windows.Forms.DataGridView()
        Me.Quando = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Utente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Voto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkNonApprovare = New System.Windows.Forms.LinkLabel()
        Me.lnkApprova = New System.Windows.Forms.LinkLabel()
        CType(Me.DgReview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.lnkAggiorna.Size = New System.Drawing.Size(209, 32)
        Me.lnkAggiorna.TabIndex = 52
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Carica recensioni da approvare"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgReview
        '
        Me.DgReview.AllowUserToAddRows = False
        Me.DgReview.AllowUserToDeleteRows = False
        Me.DgReview.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgReview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgReview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgReview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DgReview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgReview.BackgroundColor = System.Drawing.Color.White
        Me.DgReview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgReview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgReview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgReview.ColumnHeadersHeight = 20
        Me.DgReview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgReview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Quando, Me.Utente, Me.Pro, Me.Contro, Me.Voto})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgReview.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgReview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgReview.EnableHeadersVisualStyles = False
        Me.DgReview.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgReview.Location = New System.Drawing.Point(3, 35)
        Me.DgReview.MultiSelect = False
        Me.DgReview.Name = "DgReview"
        Me.DgReview.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgReview.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgReview.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgReview.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgReview.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgReview.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgReview.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgReview.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgReview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgReview.Size = New System.Drawing.Size(1073, 440)
        Me.DgReview.TabIndex = 51
        Me.DgReview.TabStop = False
        '
        'Quando
        '
        Me.Quando.DataPropertyName = "Quando"
        Me.Quando.HeaderText = "Quando"
        Me.Quando.Name = "Quando"
        Me.Quando.ReadOnly = True
        Me.Quando.Width = 75
        '
        'Utente
        '
        Me.Utente.DataPropertyName = "UtenteStr"
        Me.Utente.HeaderText = "Utente"
        Me.Utente.Name = "Utente"
        Me.Utente.ReadOnly = True
        Me.Utente.Width = 67
        '
        'Pro
        '
        Me.Pro.DataPropertyName = "Pregi"
        Me.Pro.HeaderText = "Pro"
        Me.Pro.Name = "Pro"
        Me.Pro.ReadOnly = True
        Me.Pro.Width = 50
        '
        'Contro
        '
        Me.Contro.DataPropertyName = "Difetti"
        Me.Contro.HeaderText = "Contro"
        Me.Contro.Name = "Contro"
        Me.Contro.ReadOnly = True
        Me.Contro.Width = 68
        '
        'Voto
        '
        Me.Voto.DataPropertyName = "Voto"
        Me.Voto.HeaderText = "Voto"
        Me.Voto.Name = "Voto"
        Me.Voto.ReadOnly = True
        Me.Voto.Width = 54
        '
        'lnkNonApprovare
        '
        Me.lnkNonApprovare.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNonApprovare.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkNonApprovare.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNonApprovare.Image = Global.Former.My.Resources._Elimina
        Me.lnkNonApprovare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNonApprovare.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNonApprovare.Location = New System.Drawing.Point(961, 0)
        Me.lnkNonApprovare.Name = "lnkNonApprovare"
        Me.lnkNonApprovare.Size = New System.Drawing.Size(115, 32)
        Me.lnkNonApprovare.TabIndex = 61
        Me.lnkNonApprovare.TabStop = True
        Me.lnkNonApprovare.Text = "Non Approvare"
        Me.lnkNonApprovare.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkApprova
        '
        Me.lnkApprova.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkApprova.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkApprova.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkApprova.Image = Global.Former.My.Resources._Ok
        Me.lnkApprova.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkApprova.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApprova.Location = New System.Drawing.Point(877, 0)
        Me.lnkApprova.Name = "lnkApprova"
        Me.lnkApprova.Size = New System.Drawing.Size(78, 32)
        Me.lnkApprova.TabIndex = 60
        Me.lnkApprova.TabStop = True
        Me.lnkApprova.Text = "Approva"
        Me.lnkApprova.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucSitoWebRecensioniProdotti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkNonApprovare)
        Me.Controls.Add(Me.lnkApprova)
        Me.Controls.Add(Me.lnkAggiorna)
        Me.Controls.Add(Me.DgReview)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucSitoWebRecensioniProdotti"
        Me.Size = New System.Drawing.Size(1079, 478)
        CType(Me.DgReview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lnkAggiorna As LinkLabel
    Friend WithEvents DgReview As DataGridView
    Friend WithEvents Quando As DataGridViewTextBoxColumn
    Friend WithEvents Utente As DataGridViewTextBoxColumn
    Friend WithEvents Pro As DataGridViewTextBoxColumn
    Friend WithEvents Contro As DataGridViewTextBoxColumn
    Friend WithEvents Voto As DataGridViewTextBoxColumn
    Friend WithEvents lnkNonApprovare As LinkLabel
    Friend WithEvents lnkApprova As LinkLabel
End Class
