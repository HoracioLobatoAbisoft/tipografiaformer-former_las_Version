<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucOperatoreCodaLavori
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.rdoStampa = New System.Windows.Forms.RadioButton()
        Me.rdoFinituraCommessa = New System.Windows.Forms.RadioButton()
        Me.rdoFinituraProdotto = New System.Windows.Forms.RadioButton()
        Me.DgLavori = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn5 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.imgLavorazione = New System.Windows.Forms.DataGridViewImageColumn()
        Me.msg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.P = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ordine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Copie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RagSoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lavorazione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NLastre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Risorsa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InCarico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnPrendiInCarico = New System.Windows.Forms.Button()
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdoStampa
        '
        Me.rdoStampa.Checked = True
        Me.rdoStampa.Location = New System.Drawing.Point(3, 3)
        Me.rdoStampa.Name = "rdoStampa"
        Me.rdoStampa.Size = New System.Drawing.Size(68, 37)
        Me.rdoStampa.TabIndex = 0
        Me.rdoStampa.TabStop = True
        Me.rdoStampa.Text = "Stampa"
        Me.rdoStampa.UseVisualStyleBackColor = True
        '
        'rdoFinituraCommessa
        '
        Me.rdoFinituraCommessa.Location = New System.Drawing.Point(77, 3)
        Me.rdoFinituraCommessa.Name = "rdoFinituraCommessa"
        Me.rdoFinituraCommessa.Size = New System.Drawing.Size(152, 37)
        Me.rdoFinituraCommessa.TabIndex = 1
        Me.rdoFinituraCommessa.TabStop = True
        Me.rdoFinituraCommessa.Text = "Finitura su Commessa"
        Me.rdoFinituraCommessa.UseVisualStyleBackColor = True
        '
        'rdoFinituraProdotto
        '
        Me.rdoFinituraProdotto.Location = New System.Drawing.Point(235, 3)
        Me.rdoFinituraProdotto.Name = "rdoFinituraProdotto"
        Me.rdoFinituraProdotto.Size = New System.Drawing.Size(132, 37)
        Me.rdoFinituraProdotto.TabIndex = 2
        Me.rdoFinituraProdotto.TabStop = True
        Me.rdoFinituraProdotto.Text = "Finitura su Prodotto"
        Me.rdoFinituraProdotto.UseVisualStyleBackColor = True
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
        Me.DgLavori.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.DgLavori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn5, Me.imgLavorazione, Me.msg, Me.P, Me.Ordine, Me.num, Me.Data, Me.Copie, Me.Tipo, Me.RagSoc, Me.Lavorazione, Me.NLastre, Me.FR, Me.Risorsa, Me.Qta, Me.InCarico})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.DefaultCellStyle = DataGridViewCellStyle15
        Me.DgLavori.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavori.EnableHeadersVisualStyles = False
        Me.DgLavori.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavori.Location = New System.Drawing.Point(3, 46)
        Me.DgLavori.MultiSelect = False
        Me.DgLavori.Name = "DgLavori"
        Me.DgLavori.ReadOnly = True
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.DgLavori.RowHeadersVisible = False
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowsDefaultCellStyle = DataGridViewCellStyle17
        Me.DgLavori.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLavori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavori.Size = New System.Drawing.Size(703, 429)
        Me.DgLavori.TabIndex = 106
        Me.DgLavori.TabStop = False
        '
        'DataGridViewImageColumn5
        '
        Me.DataGridViewImageColumn5.DataPropertyName = "imgAnteprima"
        Me.DataGridViewImageColumn5.Frozen = True
        Me.DataGridViewImageColumn5.HeaderText = ""
        Me.DataGridViewImageColumn5.Name = "DataGridViewImageColumn5"
        Me.DataGridViewImageColumn5.ReadOnly = True
        Me.DataGridViewImageColumn5.Width = 5
        '
        'imgLavorazione
        '
        Me.imgLavorazione.DataPropertyName = "imgLavorazione"
        Me.imgLavorazione.Frozen = True
        Me.imgLavorazione.HeaderText = ""
        Me.imgLavorazione.Name = "imgLavorazione"
        Me.imgLavorazione.ReadOnly = True
        Me.imgLavorazione.Width = 5
        '
        'msg
        '
        Me.msg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.msg.DataPropertyName = "Icomsg"
        Me.msg.Frozen = True
        Me.msg.HeaderText = ""
        Me.msg.Name = "msg"
        Me.msg.ReadOnly = True
        Me.msg.Width = 16
        '
        'P
        '
        Me.P.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.P.DataPropertyName = "Priorita"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.P.DefaultCellStyle = DataGridViewCellStyle3
        Me.P.Frozen = True
        Me.P.HeaderText = "P!"
        Me.P.Name = "P"
        Me.P.ReadOnly = True
        Me.P.Width = 20
        '
        'Ordine
        '
        Me.Ordine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Ordine.DataPropertyName = "IdOrdineStr"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Ordine.DefaultCellStyle = DataGridViewCellStyle4
        Me.Ordine.Frozen = True
        Me.Ordine.HeaderText = "Ordine"
        Me.Ordine.Name = "Ordine"
        Me.Ordine.ReadOnly = True
        Me.Ordine.Width = 55
        '
        'num
        '
        Me.num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.num.DataPropertyName = "IdCommessaStr"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.num.DefaultCellStyle = DataGridViewCellStyle5
        Me.num.Frozen = True
        Me.num.HeaderText = "Commessa"
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.Width = 85
        '
        'Data
        '
        Me.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Data.DataPropertyName = "DataInserimentoStr"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Data.DefaultCellStyle = DataGridViewCellStyle6
        Me.Data.HeaderText = "Data Ins"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 73
        '
        'Copie
        '
        Me.Copie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Copie.DataPropertyName = "Copie"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Copie.DefaultCellStyle = DataGridViewCellStyle7
        Me.Copie.HeaderText = "Copie"
        Me.Copie.Name = "Copie"
        Me.Copie.ReadOnly = True
        Me.Copie.Width = 62
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Tipo.DataPropertyName = "Tipo"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle8
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 180
        '
        'RagSoc
        '
        Me.RagSoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.RagSoc.DataPropertyName = "RagSocNome"
        Me.RagSoc.HeaderText = "Cliente"
        Me.RagSoc.Name = "RagSoc"
        Me.RagSoc.ReadOnly = True
        Me.RagSoc.Width = 180
        '
        'Lavorazione
        '
        Me.Lavorazione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Lavorazione.DataPropertyName = "LavorazioneStr"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Lavorazione.DefaultCellStyle = DataGridViewCellStyle9
        Me.Lavorazione.HeaderText = "Lavorazione"
        Me.Lavorazione.Name = "Lavorazione"
        Me.Lavorazione.ReadOnly = True
        Me.Lavorazione.Width = 180
        '
        'NLastre
        '
        Me.NLastre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.NLastre.DataPropertyName = "NLastreStr"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NLastre.DefaultCellStyle = DataGridViewCellStyle10
        Me.NLastre.HeaderText = "N° Lastre"
        Me.NLastre.Name = "NLastre"
        Me.NLastre.ReadOnly = True
        Me.NLastre.Width = 5
        '
        'FR
        '
        Me.FR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FR.DataPropertyName = "FronteRetro"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FR.DefaultCellStyle = DataGridViewCellStyle11
        Me.FR.HeaderText = "F/R"
        Me.FR.Name = "FR"
        Me.FR.ReadOnly = True
        Me.FR.Width = 49
        '
        'Risorsa
        '
        Me.Risorsa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Risorsa.DataPropertyName = "RisorsaStr"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Risorsa.DefaultCellStyle = DataGridViewCellStyle12
        Me.Risorsa.HeaderText = "Risorsa"
        Me.Risorsa.Name = "Risorsa"
        Me.Risorsa.ReadOnly = True
        Me.Risorsa.Width = 150
        '
        'Qta
        '
        Me.Qta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Qta.DataPropertyName = "QtaStr"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Qta.DefaultCellStyle = DataGridViewCellStyle13
        Me.Qta.HeaderText = "Q.ta"
        Me.Qta.Name = "Qta"
        Me.Qta.ReadOnly = True
        Me.Qta.Width = 53
        '
        'InCarico
        '
        Me.InCarico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.InCarico.DataPropertyName = "InCaricoA"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.InCarico.DefaultCellStyle = DataGridViewCellStyle14
        Me.InCarico.HeaderText = "In Carico a "
        Me.InCarico.Name = "InCarico"
        Me.InCarico.ReadOnly = True
        Me.InCarico.Width = 80
        '
        'btnPrendiInCarico
        '
        Me.btnPrendiInCarico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrendiInCarico.BackColor = System.Drawing.Color.White
        Me.btnPrendiInCarico.FlatAppearance.BorderSize = 0
        Me.btnPrendiInCarico.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrendiInCarico.ForeColor = System.Drawing.Color.Green
        Me.btnPrendiInCarico.Image = Global.Former.My.Resources.Resources._PrendiInCarico
        Me.btnPrendiInCarico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrendiInCarico.Location = New System.Drawing.Point(591, 3)
        Me.btnPrendiInCarico.Name = "btnPrendiInCarico"
        Me.btnPrendiInCarico.Size = New System.Drawing.Size(115, 37)
        Me.btnPrendiInCarico.TabIndex = 142
        Me.btnPrendiInCarico.TabStop = False
        Me.btnPrendiInCarico.Text = "Lo faccio io"
        Me.btnPrendiInCarico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrendiInCarico.UseVisualStyleBackColor = False
        '
        'ucOperatoreCodaLavori
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnPrendiInCarico)
        Me.Controls.Add(Me.DgLavori)
        Me.Controls.Add(Me.rdoFinituraProdotto)
        Me.Controls.Add(Me.rdoFinituraCommessa)
        Me.Controls.Add(Me.rdoStampa)
        Me.Name = "ucOperatoreCodaLavori"
        Me.Size = New System.Drawing.Size(709, 478)
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rdoStampa As RadioButton
    Friend WithEvents rdoFinituraCommessa As RadioButton
    Friend WithEvents rdoFinituraProdotto As RadioButton
    Friend WithEvents DgLavori As DataGridView
    Friend WithEvents btnPrendiInCarico As Button
    Friend WithEvents DataGridViewImageColumn5 As DataGridViewImageColumn
    Friend WithEvents imgLavorazione As DataGridViewImageColumn
    Friend WithEvents msg As DataGridViewImageColumn
    Friend WithEvents P As DataGridViewTextBoxColumn
    Friend WithEvents Ordine As DataGridViewTextBoxColumn
    Friend WithEvents num As DataGridViewTextBoxColumn
    Friend WithEvents Data As DataGridViewTextBoxColumn
    Friend WithEvents Copie As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents RagSoc As DataGridViewTextBoxColumn
    Friend WithEvents Lavorazione As DataGridViewTextBoxColumn
    Friend WithEvents NLastre As DataGridViewTextBoxColumn
    Friend WithEvents FR As DataGridViewTextBoxColumn
    Friend WithEvents Risorsa As DataGridViewTextBoxColumn
    Friend WithEvents Qta As DataGridViewTextBoxColumn
    Friend WithEvents InCarico As DataGridViewTextBoxColumn
End Class
