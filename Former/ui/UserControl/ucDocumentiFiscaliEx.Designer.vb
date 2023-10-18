<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDocumentiFiscaliEx
    Inherits System.Windows.Forms.UserControl

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.UcStatoDocumenti = New Former.ucDocumentiStato()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbAnnoRif = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbMese = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdoUscita = New System.Windows.Forms.RadioButton()
        Me.rdoEntrata = New System.Windows.Forms.RadioButton()
        Me.DgOrdini = New System.Windows.Forms.DataGridView()
        Me.IcoMsg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IcoTipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IdOrdLista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataIns = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Com = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdottoDescrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClienteRagSoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Totale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Corriere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Consegna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.UcStatoDocumenti)
        Me.GroupBox1.Location = New System.Drawing.Point(567, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 50)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stato Documento"
        '
        'UcStatoDocumenti
        '
        Me.UcStatoDocumenti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcStatoDocumenti.BackColor = System.Drawing.Color.White
        Me.UcStatoDocumenti.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.UcStatoDocumenti.Location = New System.Drawing.Point(1, 20)
        Me.UcStatoDocumenti.Name = "UcStatoDocumenti"
        Me.UcStatoDocumenti.Size = New System.Drawing.Size(406, 28)
        Me.UcStatoDocumenti.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 59)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(558, 50)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Documento"
        '
        'cmbAnnoRif
        '
        Me.cmbAnnoRif.DisplayMember = "AnnoRif"
        Me.cmbAnnoRif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnnoRif.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cmbAnnoRif.FormattingEnabled = True
        Me.cmbAnnoRif.Location = New System.Drawing.Point(450, 20)
        Me.cmbAnnoRif.Name = "cmbAnnoRif"
        Me.cmbAnnoRif.Size = New System.Drawing.Size(108, 23)
        Me.cmbAnnoRif.TabIndex = 43
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label36.Location = New System.Drawing.Point(331, 23)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(113, 15)
        Me.Label36.TabIndex = 42
        Me.Label36.Text = "Anno di riferimento:"
        '
        'cmbMese
        '
        Me.cmbMese.DisplayMember = "AnnoRif"
        Me.cmbMese.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMese.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cmbMese.FormattingEnabled = True
        Me.cmbMese.Location = New System.Drawing.Point(685, 20)
        Me.cmbMese.Name = "cmbMese"
        Me.cmbMese.Size = New System.Drawing.Size(287, 23)
        Me.cmbMese.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(564, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 15)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Mese di riferimento:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rdoUscita)
        Me.GroupBox3.Controls.Add(Me.rdoEntrata)
        Me.GroupBox3.Controls.Add(Me.cmbAnnoRif)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label36)
        Me.GroupBox3.Controls.Add(Me.cmbMese)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(977, 50)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        '
        'rdoUscita
        '
        Me.rdoUscita.AutoSize = True
        Me.rdoUscita.BackColor = System.Drawing.Color.Red
        Me.rdoUscita.ForeColor = System.Drawing.Color.White
        Me.rdoUscita.Location = New System.Drawing.Point(153, 21)
        Me.rdoUscita.Name = "rdoUscita"
        Me.rdoUscita.Size = New System.Drawing.Size(147, 19)
        Me.rdoUscita.TabIndex = 47
        Me.rdoUscita.Text = "Documenti di Acquisto"
        Me.rdoUscita.UseVisualStyleBackColor = False
        '
        'rdoEntrata
        '
        Me.rdoEntrata.AutoSize = True
        Me.rdoEntrata.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdoEntrata.Checked = True
        Me.rdoEntrata.ForeColor = System.Drawing.Color.White
        Me.rdoEntrata.Location = New System.Drawing.Point(6, 21)
        Me.rdoEntrata.Name = "rdoEntrata"
        Me.rdoEntrata.Size = New System.Drawing.Size(141, 19)
        Me.rdoEntrata.TabIndex = 46
        Me.rdoEntrata.TabStop = True
        Me.rdoEntrata.Text = "Documenti di Vendita"
        Me.rdoEntrata.UseVisualStyleBackColor = False
        '
        'DgOrdini
        '
        Me.DgOrdini.AllowUserToAddRows = False
        Me.DgOrdini.AllowUserToDeleteRows = False
        Me.DgOrdini.AllowUserToOrderColumns = True
        Me.DgOrdini.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgOrdini.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgOrdini.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgOrdini.BackgroundColor = System.Drawing.Color.White
        Me.DgOrdini.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgOrdini.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgOrdini.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgOrdini.ColumnHeadersHeight = 20
        Me.DgOrdini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgOrdini.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IcoMsg, Me.IcoTipo, Me.IdOrdLista, Me.DataIns, Me.Com, Me.ProdottoDescrizione, Me.ClienteRagSoc, Me.Stato, Me.Totale, Me.Corriere, Me.Consegna})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgOrdini.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgOrdini.EnableHeadersVisualStyles = False
        Me.DgOrdini.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgOrdini.Location = New System.Drawing.Point(3, 266)
        Me.DgOrdini.MultiSelect = False
        Me.DgOrdini.Name = "DgOrdini"
        Me.DgOrdini.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgOrdini.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgOrdini.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.DgOrdini.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgOrdini.Size = New System.Drawing.Size(977, 178)
        Me.DgOrdini.TabIndex = 49
        Me.DgOrdini.TabStop = False
        '
        'IcoMsg
        '
        Me.IcoMsg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IcoMsg.DataPropertyName = "IcoMsg"
        Me.IcoMsg.HeaderText = ""
        Me.IcoMsg.Name = "IcoMsg"
        Me.IcoMsg.ReadOnly = True
        Me.IcoMsg.Width = 16
        '
        'IcoTipo
        '
        Me.IcoTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IcoTipo.DataPropertyName = "IcoTipo"
        Me.IcoTipo.HeaderText = ""
        Me.IcoTipo.Name = "IcoTipo"
        Me.IcoTipo.ReadOnly = True
        Me.IcoTipo.Width = 16
        '
        'IdOrdLista
        '
        Me.IdOrdLista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IdOrdLista.DataPropertyName = "IdOrd"
        Me.IdOrdLista.HeaderText = "Ordine"
        Me.IdOrdLista.Name = "IdOrdLista"
        Me.IdOrdLista.ReadOnly = True
        Me.IdOrdLista.Width = 45
        '
        'DataIns
        '
        Me.DataIns.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataIns.DataPropertyName = "DataInsStr"
        Me.DataIns.HeaderText = "Data"
        Me.DataIns.Name = "DataIns"
        Me.DataIns.ReadOnly = True
        '
        'Com
        '
        Me.Com.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Com.DataPropertyName = "IdComStr"
        Me.Com.HeaderText = "Commessa"
        Me.Com.Name = "Com"
        Me.Com.ReadOnly = True
        Me.Com.Width = 80
        '
        'ProdottoDescrizione
        '
        Me.ProdottoDescrizione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ProdottoDescrizione.DataPropertyName = "ProdottoDescrizione"
        Me.ProdottoDescrizione.HeaderText = "Prodotto"
        Me.ProdottoDescrizione.Name = "ProdottoDescrizione"
        Me.ProdottoDescrizione.ReadOnly = True
        Me.ProdottoDescrizione.Width = 150
        '
        'ClienteRagSoc
        '
        Me.ClienteRagSoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ClienteRagSoc.DataPropertyName = "ClienteNominativo"
        Me.ClienteRagSoc.HeaderText = "Cliente"
        Me.ClienteRagSoc.Name = "ClienteRagSoc"
        Me.ClienteRagSoc.ReadOnly = True
        Me.ClienteRagSoc.Width = 150
        '
        'Stato
        '
        Me.Stato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Stato.DataPropertyName = "StatoStr"
        Me.Stato.HeaderText = "Stato"
        Me.Stato.Name = "Stato"
        Me.Stato.ReadOnly = True
        Me.Stato.Width = 150
        '
        'Totale
        '
        Me.Totale.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Totale.DataPropertyName = "TotaleStr"
        Me.Totale.HeaderText = "Totale"
        Me.Totale.Name = "Totale"
        Me.Totale.ReadOnly = True
        Me.Totale.Width = 80
        '
        'Corriere
        '
        Me.Corriere.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Corriere.DataPropertyName = "CorriereStr"
        Me.Corriere.HeaderText = "Corriere"
        Me.Corriere.Name = "Corriere"
        Me.Corriere.ReadOnly = True
        Me.Corriere.Width = 50
        '
        'Consegna
        '
        Me.Consegna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Consegna.DataPropertyName = "DataConsProgrStr"
        Me.Consegna.HeaderText = "Consegna"
        Me.Consegna.Name = "Consegna"
        Me.Consegna.ReadOnly = True
        Me.Consegna.Width = 110
        '
        'ucDocumentiFiscaliEx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DgOrdini)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Name = "ucDocumentiFiscaliEx"
        Me.Size = New System.Drawing.Size(983, 447)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcStatoDocumenti As Former.ucDocumentiStato
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAnnoRif As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbMese As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoUscita As System.Windows.Forms.RadioButton
    Friend WithEvents rdoEntrata As System.Windows.Forms.RadioButton
    Friend WithEvents DgOrdini As System.Windows.Forms.DataGridView
    Friend WithEvents IcoMsg As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents IcoTipo As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents IdOrdLista As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataIns As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Com As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdottoDescrizione As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClienteRagSoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Totale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Corriere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consegna As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
