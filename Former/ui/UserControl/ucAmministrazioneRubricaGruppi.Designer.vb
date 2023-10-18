<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazioneRubricaGruppi
    Inherits ucFormerUserControl


    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lnkModLav = New System.Windows.Forms.LinkLabel()
        Me.lnkDelLav = New System.Windows.Forms.LinkLabel()
        Me.lnkAggiungiLav = New System.Windows.Forms.LinkLabel()
        Me.lstGruppi = New System.Windows.Forms.ListBox()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lnkPrintEtich = New System.Windows.Forms.LinkLabel()
        Me.lblRis = New System.Windows.Forms.Label()
        Me.dgContatti = New System.Windows.Forms.DataGridView()
        Me.ProvenienzaVoceExt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nominativo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Citta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkShowRis = New System.Windows.Forms.LinkLabel()
        CType(Me.dgContatti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label26.Location = New System.Drawing.Point(3, 43)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(105, 15)
        Me.Label26.TabIndex = 71
        Me.Label26.Text = "Gruppi Disponibili"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label27.Location = New System.Drawing.Point(277, 43)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 15)
        Me.Label27.TabIndex = 74
        Me.Label27.Text = "Contatti"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.Location = New System.Drawing.Point(334, 43)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(405, 15)
        Me.Label28.TabIndex = 73
        Me.Label28.Text = "(Selezionando un gruppo vengono visualizzati i contatti che ne fanno parte)"
        '
        'lnkModLav
        '
        Me.lnkModLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModLav.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkModLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModLav.Location = New System.Drawing.Point(172, 0)
        Me.lnkModLav.Name = "lnkModLav"
        Me.lnkModLav.Size = New System.Drawing.Size(82, 37)
        Me.lnkModLav.TabIndex = 79
        Me.lnkModLav.TabStop = True
        Me.lnkModLav.Text = "Modifica"
        Me.lnkModLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDelLav
        '
        Me.lnkDelLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelLav.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelLav.Location = New System.Drawing.Point(260, 0)
        Me.lnkDelLav.Name = "lnkDelLav"
        Me.lnkDelLav.Size = New System.Drawing.Size(82, 37)
        Me.lnkDelLav.TabIndex = 78
        Me.lnkDelLav.TabStop = True
        Me.lnkDelLav.Text = "Rimuovi"
        Me.lnkDelLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAggiungiLav
        '
        Me.lnkAggiungiLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiungiLav.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAggiungiLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiungiLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiungiLav.Location = New System.Drawing.Point(94, 0)
        Me.lnkAggiungiLav.Name = "lnkAggiungiLav"
        Me.lnkAggiungiLav.Size = New System.Drawing.Size(72, 37)
        Me.lnkAggiungiLav.TabIndex = 77
        Me.lnkAggiungiLav.TabStop = True
        Me.lnkAggiungiLav.Text = "Nuovo"
        Me.lnkAggiungiLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstGruppi
        '
        Me.lstGruppi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstGruppi.FormattingEnabled = True
        Me.lstGruppi.ItemHeight = 15
        Me.lstGruppi.Location = New System.Drawing.Point(6, 66)
        Me.lstGruppi.Name = "lstGruppi"
        Me.lstGruppi.Size = New System.Drawing.Size(259, 394)
        Me.lstGruppi.TabIndex = 84
        '
        'lnkAll
        '
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(3, 5)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Size = New System.Drawing.Size(85, 26)
        Me.lnkAll.TabIndex = 85
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Aggiorna"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkStampa
        '
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(606, 0)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(109, 37)
        Me.lnkStampa.TabIndex = 87
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa Lista"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkPrintEtich
        '
        Me.lnkPrintEtich.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkPrintEtich.Image = Global.Former.My.Resources.Resources._Etichetta
        Me.lnkPrintEtich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPrintEtich.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkPrintEtich.Location = New System.Drawing.Point(481, 5)
        Me.lnkPrintEtich.Name = "lnkPrintEtich"
        Me.lnkPrintEtich.Size = New System.Drawing.Size(119, 27)
        Me.lnkPrintEtich.TabIndex = 88
        Me.lnkPrintEtich.TabStop = True
        Me.lnkPrintEtich.Text = "Stampa Etichette"
        Me.lnkPrintEtich.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRis
        '
        Me.lblRis.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRis.Location = New System.Drawing.Point(783, 40)
        Me.lblRis.Name = "lblRis"
        Me.lblRis.Size = New System.Drawing.Size(139, 21)
        Me.lblRis.TabIndex = 89
        Me.lblRis.Text = "Risultati: -"
        Me.lblRis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgContatti
        '
        Me.dgContatti.AllowUserToAddRows = False
        Me.dgContatti.AllowUserToDeleteRows = False
        Me.dgContatti.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgContatti.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgContatti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgContatti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgContatti.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgContatti.BackgroundColor = System.Drawing.Color.White
        Me.dgContatti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgContatti.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContatti.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgContatti.ColumnHeadersHeight = 20
        Me.dgContatti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgContatti.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProvenienzaVoceExt, Me.Nominativo, Me.EmailG, Me.Citta})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgContatti.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgContatti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgContatti.EnableHeadersVisualStyles = False
        Me.dgContatti.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgContatti.Location = New System.Drawing.Point(271, 66)
        Me.dgContatti.MultiSelect = False
        Me.dgContatti.Name = "dgContatti"
        Me.dgContatti.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgContatti.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgContatti.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgContatti.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgContatti.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgContatti.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgContatti.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgContatti.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgContatti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgContatti.Size = New System.Drawing.Size(651, 394)
        Me.dgContatti.TabIndex = 90
        Me.dgContatti.TabStop = False
        '
        'ProvenienzaVoceExt
        '
        Me.ProvenienzaVoceExt.DataPropertyName = "ProvenienzaVoceExt"
        Me.ProvenienzaVoceExt.HeaderText = "Provenienza"
        Me.ProvenienzaVoceExt.Name = "ProvenienzaVoceExt"
        Me.ProvenienzaVoceExt.ReadOnly = True
        Me.ProvenienzaVoceExt.Width = 95
        '
        'Nominativo
        '
        Me.Nominativo.DataPropertyName = "NominativoG"
        Me.Nominativo.HeaderText = "Nominativo"
        Me.Nominativo.Name = "Nominativo"
        Me.Nominativo.ReadOnly = True
        Me.Nominativo.Width = 94
        '
        'EmailG
        '
        Me.EmailG.DataPropertyName = "EmailG"
        Me.EmailG.HeaderText = "Email"
        Me.EmailG.Name = "EmailG"
        Me.EmailG.ReadOnly = True
        Me.EmailG.Width = 60
        '
        'Citta
        '
        Me.Citta.DataPropertyName = "Citta"
        Me.Citta.HeaderText = "Citta"
        Me.Citta.Name = "Citta"
        Me.Citta.ReadOnly = True
        Me.Citta.Width = 56
        '
        'lnkShowRis
        '
        Me.lnkShowRis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkShowRis.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkShowRis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkShowRis.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkShowRis.Location = New System.Drawing.Point(357, 5)
        Me.lnkShowRis.Name = "lnkShowRis"
        Me.lnkShowRis.Size = New System.Drawing.Size(118, 27)
        Me.lnkShowRis.TabIndex = 91
        Me.lnkShowRis.TabStop = True
        Me.lnkShowRis.Text = "Mostra risultati"
        Me.lnkShowRis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucAmministrazioneRubricaGruppi
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkShowRis)
        Me.Controls.Add(Me.dgContatti)
        Me.Controls.Add(Me.lblRis)
        Me.Controls.Add(Me.lnkPrintEtich)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.lnkAll)
        Me.Controls.Add(Me.lstGruppi)
        Me.Controls.Add(Me.lnkModLav)
        Me.Controls.Add(Me.lnkDelLav)
        Me.Controls.Add(Me.lnkAggiungiLav)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label26)
        Me.Name = "ucAmministrazioneRubricaGruppi"
        Me.Size = New System.Drawing.Size(925, 463)
        CType(Me.dgContatti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lnkModLav As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDelLav As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAggiungiLav As System.Windows.Forms.LinkLabel
    Friend WithEvents lstGruppi As System.Windows.Forms.ListBox
    Friend WithEvents lnkAll As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkPrintEtich As System.Windows.Forms.LinkLabel
    Friend WithEvents lblRis As System.Windows.Forms.Label
    Friend WithEvents dgContatti As DataGridView
    Friend WithEvents ProvenienzaVoceExt As DataGridViewTextBoxColumn
    Friend WithEvents Nominativo As DataGridViewTextBoxColumn
    Friend WithEvents EmailG As DataGridViewTextBoxColumn
    Friend WithEvents Citta As DataGridViewTextBoxColumn
    Friend WithEvents lnkShowRis As LinkLabel
End Class
