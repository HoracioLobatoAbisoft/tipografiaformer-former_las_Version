<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazioneCoupon
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgCoupon = New System.Windows.Forms.DataGridView()
        Me.IcoTipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Percentuale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportoFisso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prodotto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValidoDal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValidoAl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaxVolte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SoloPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pubblicato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.lnkRefresh = New System.Windows.Forms.LinkLabel()
        Me.lnkRigenera = New System.Windows.Forms.LinkLabel()
        CType(Me.DgCoupon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgCoupon
        '
        Me.DgCoupon.AllowUserToAddRows = False
        Me.DgCoupon.AllowUserToDeleteRows = False
        Me.DgCoupon.AllowUserToOrderColumns = True
        Me.DgCoupon.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgCoupon.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgCoupon.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgCoupon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.DgCoupon.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgCoupon.BackgroundColor = System.Drawing.Color.White
        Me.DgCoupon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgCoupon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgCoupon.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgCoupon.ColumnHeadersHeight = 20
        Me.DgCoupon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgCoupon.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IcoTipo, Me.Nome, Me.Codice, Me.Percentuale, Me.ImportoFisso, Me.Prodotto, Me.Cliente, Me.ValidoDal, Me.ValidoAl, Me.MaxVolte, Me.SoloPer, Me.Pubblicato})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgCoupon.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgCoupon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgCoupon.EnableHeadersVisualStyles = False
        Me.DgCoupon.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgCoupon.Location = New System.Drawing.Point(3, 33)
        Me.DgCoupon.MultiSelect = False
        Me.DgCoupon.Name = "DgCoupon"
        Me.DgCoupon.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgCoupon.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgCoupon.RowHeadersVisible = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.DgCoupon.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DgCoupon.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgCoupon.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgCoupon.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgCoupon.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgCoupon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgCoupon.Size = New System.Drawing.Size(1123, 746)
        Me.DgCoupon.TabIndex = 49
        Me.DgCoupon.TabStop = False
        '
        'IcoTipo
        '
        Me.IcoTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IcoTipo.DataPropertyName = "ImgRif"
        Me.IcoTipo.HeaderText = ""
        Me.IcoTipo.Name = "IcoTipo"
        Me.IcoTipo.ReadOnly = True
        Me.IcoTipo.Width = 48
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Nome"
        Me.Nome.HeaderText = "Nome"
        Me.Nome.MinimumWidth = 100
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        '
        'Codice
        '
        Me.Codice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Codice.DataPropertyName = "Codice"
        Me.Codice.HeaderText = "Codice"
        Me.Codice.MinimumWidth = 100
        Me.Codice.Name = "Codice"
        Me.Codice.ReadOnly = True
        '
        'Percentuale
        '
        Me.Percentuale.DataPropertyName = "Percentuale"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Percentuale.DefaultCellStyle = DataGridViewCellStyle3
        Me.Percentuale.HeaderText = "Percentuale"
        Me.Percentuale.MinimumWidth = 100
        Me.Percentuale.Name = "Percentuale"
        Me.Percentuale.ReadOnly = True
        '
        'ImportoFisso
        '
        Me.ImportoFisso.DataPropertyName = "ImportoFisso"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ImportoFisso.DefaultCellStyle = DataGridViewCellStyle4
        Me.ImportoFisso.HeaderText = "ImportoFisso"
        Me.ImportoFisso.MinimumWidth = 100
        Me.ImportoFisso.Name = "ImportoFisso"
        Me.ImportoFisso.ReadOnly = True
        '
        'Prodotto
        '
        Me.Prodotto.DataPropertyName = "ProdottoRif"
        Me.Prodotto.HeaderText = "Prodotto"
        Me.Prodotto.MinimumWidth = 100
        Me.Prodotto.Name = "Prodotto"
        Me.Prodotto.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "ClienteRif"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.MinimumWidth = 100
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'ValidoDal
        '
        Me.ValidoDal.DataPropertyName = "DataInizioValiditaStr"
        Me.ValidoDal.HeaderText = "Valido Dal"
        Me.ValidoDal.MinimumWidth = 100
        Me.ValidoDal.Name = "ValidoDal"
        Me.ValidoDal.ReadOnly = True
        '
        'ValidoAl
        '
        Me.ValidoAl.DataPropertyName = "DataFineValiditaStr"
        Me.ValidoAl.HeaderText = "Valido Fino"
        Me.ValidoAl.MinimumWidth = 100
        Me.ValidoAl.Name = "ValidoAl"
        Me.ValidoAl.ReadOnly = True
        '
        'MaxVolte
        '
        Me.MaxVolte.DataPropertyName = "MaxVolte"
        Me.MaxVolte.HeaderText = "MaxVolte"
        Me.MaxVolte.MinimumWidth = 100
        Me.MaxVolte.Name = "MaxVolte"
        Me.MaxVolte.ReadOnly = True
        '
        'SoloPer
        '
        Me.SoloPer.DataPropertyName = "SoloPer"
        Me.SoloPer.HeaderText = "Solo Per"
        Me.SoloPer.MinimumWidth = 100
        Me.SoloPer.Name = "SoloPer"
        Me.SoloPer.ReadOnly = True
        '
        'Pubblicato
        '
        Me.Pubblicato.DataPropertyName = "Pubblicato"
        Me.Pubblicato.HeaderText = "Pubblicato"
        Me.Pubblicato.MinimumWidth = 100
        Me.Pubblicato.Name = "Pubblicato"
        Me.Pubblicato.ReadOnly = True
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(94, 3)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(114, 27)
        Me.lnkNew.TabIndex = 55
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo Coupon"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkRefresh
        '
        Me.lnkRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRefresh.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRefresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRefresh.Location = New System.Drawing.Point(3, 3)
        Me.lnkRefresh.Name = "lnkRefresh"
        Me.lnkRefresh.Size = New System.Drawing.Size(85, 27)
        Me.lnkRefresh.TabIndex = 55
        Me.lnkRefresh.TabStop = True
        Me.lnkRefresh.Text = "Aggiorna"
        Me.lnkRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkRigenera
        '
        Me.lnkRigenera.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRigenera.Image = Global.Former.My.Resources.Resources._RigeneraCoupon
        Me.lnkRigenera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRigenera.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRigenera.Location = New System.Drawing.Point(214, 3)
        Me.lnkRigenera.Name = "lnkRigenera"
        Me.lnkRigenera.Size = New System.Drawing.Size(132, 27)
        Me.lnkRigenera.TabIndex = 56
        Me.lnkRigenera.TabStop = True
        Me.lnkRigenera.Text = "Rigenera Coupon"
        Me.lnkRigenera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucAmministrazioneCoupon
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkRigenera)
        Me.Controls.Add(Me.lnkRefresh)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.DgCoupon)
        Me.Name = "ucAmministrazioneCoupon"
        Me.Size = New System.Drawing.Size(1129, 782)
        CType(Me.DgCoupon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgCoupon As System.Windows.Forms.DataGridView
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkRefresh As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkRigenera As System.Windows.Forms.LinkLabel
    Friend WithEvents IcoTipo As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Percentuale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImportoFisso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prodotto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValidoDal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValidoAl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxVolte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoloPer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pubblicato As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
