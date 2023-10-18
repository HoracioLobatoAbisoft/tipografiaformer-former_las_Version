<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMessaggiInterni
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabMess = New System.Windows.Forms.TabControl()
        Me.tpRic = New System.Windows.Forms.TabPage()
        Me.dgMessRic = New Former.ucDataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Anteprima = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Commessa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ordine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mittente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destinatario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titolo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Testo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpInv = New System.Windows.Forms.TabPage()
        Me.dgMessInv = New Former.ucDataGridView()
        Me.TipoInv = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuMessaggi = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelezionaTuttoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ModificaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pctMonitor = New System.Windows.Forms.PictureBox()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.tabMess.SuspendLayout()
        Me.tpRic.SuspendLayout()
        CType(Me.dgMessRic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInv.SuspendLayout()
        CType(Me.dgMessInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuMessaggi.SuspendLayout()
        CType(Me.pctMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabMess
        '
        Me.tabMess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMess.Controls.Add(Me.tpRic)
        Me.tabMess.Controls.Add(Me.tpInv)
        Me.tabMess.Location = New System.Drawing.Point(0, 38)
        Me.tabMess.Name = "tabMess"
        Me.tabMess.SelectedIndex = 0
        Me.tabMess.Size = New System.Drawing.Size(937, 340)
        Me.tabMess.TabIndex = 51
        '
        'tpRic
        '
        Me.tpRic.Controls.Add(Me.dgMessRic)
        Me.tpRic.Location = New System.Drawing.Point(4, 24)
        Me.tpRic.Name = "tpRic"
        Me.tpRic.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRic.Size = New System.Drawing.Size(929, 312)
        Me.tpRic.TabIndex = 0
        Me.tpRic.Text = "Ricevuti"
        Me.tpRic.UseVisualStyleBackColor = True
        '
        'dgMessRic
        '
        Me.dgMessRic.AllowUserToAddRows = False
        Me.dgMessRic.AllowUserToDeleteRows = False
        Me.dgMessRic.AllowUserToOrderColumns = True
        Me.dgMessRic.AllowUserToResizeRows = False
        Me.dgMessRic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgMessRic.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgMessRic.BackgroundColor = System.Drawing.Color.White
        Me.dgMessRic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMessRic.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgMessRic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMessRic.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Anteprima, Me.Commessa, Me.Ordine, Me.Data, Me.Mittente, Me.Destinatario, Me.Titolo, Me.Testo})
        Me.dgMessRic.CustomVirtualMode = False
        Me.dgMessRic.DataSourceVirtual = Nothing
        Me.dgMessRic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMessRic.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgMessRic.Location = New System.Drawing.Point(3, 3)
        Me.dgMessRic.Name = "dgMessRic"
        Me.dgMessRic.RowHeadersVisible = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgMessRic.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMessRic.RowTemplate.Height = 30
        Me.dgMessRic.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMessRic.ScrollManuale = False
        Me.dgMessRic.ScrollValue = 0
        Me.dgMessRic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMessRic.ShowEditingIcon = False
        Me.dgMessRic.Size = New System.Drawing.Size(923, 306)
        Me.dgMessRic.TabIndex = 27
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Tipo.DataPropertyName = "icoTipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 37
        '
        'Anteprima
        '
        Me.Anteprima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Anteprima.DataPropertyName = "Anteprima"
        Me.Anteprima.HeaderText = "Anteprima"
        Me.Anteprima.Name = "Anteprima"
        Me.Anteprima.Width = 69
        '
        'Commessa
        '
        Me.Commessa.DataPropertyName = "Commessa"
        Me.Commessa.HeaderText = "Commessa"
        Me.Commessa.Name = "Commessa"
        Me.Commessa.Width = 91
        '
        'Ordine
        '
        Me.Ordine.DataPropertyName = "Ordine"
        Me.Ordine.HeaderText = "Ordine"
        Me.Ordine.Name = "Ordine"
        Me.Ordine.Width = 68
        '
        'Data
        '
        Me.Data.DataPropertyName = "DataInsFormat"
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.Width = 56
        '
        'Mittente
        '
        Me.Mittente.DataPropertyName = "NomeMitt"
        Me.Mittente.HeaderText = "Mittente"
        Me.Mittente.Name = "Mittente"
        Me.Mittente.Width = 77
        '
        'Destinatario
        '
        Me.Destinatario.DataPropertyName = "NomeDest"
        Me.Destinatario.HeaderText = "Destinatario"
        Me.Destinatario.Name = "Destinatario"
        Me.Destinatario.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Destinatario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Destinatario.Width = 76
        '
        'Titolo
        '
        Me.Titolo.DataPropertyName = "Titolo"
        Me.Titolo.HeaderText = "Titolo"
        Me.Titolo.Name = "Titolo"
        Me.Titolo.Width = 63
        '
        'Testo
        '
        Me.Testo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Testo.DataPropertyName = "Riassunto"
        Me.Testo.HeaderText = "Testo"
        Me.Testo.Name = "Testo"
        Me.Testo.Width = 200
        '
        'tpInv
        '
        Me.tpInv.Controls.Add(Me.dgMessInv)
        Me.tpInv.Location = New System.Drawing.Point(4, 22)
        Me.tpInv.Name = "tpInv"
        Me.tpInv.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInv.Size = New System.Drawing.Size(929, 314)
        Me.tpInv.TabIndex = 1
        Me.tpInv.Text = "Inviati"
        Me.tpInv.UseVisualStyleBackColor = True
        '
        'dgMessInv
        '
        Me.dgMessInv.AllowUserToAddRows = False
        Me.dgMessInv.AllowUserToDeleteRows = False
        Me.dgMessInv.AllowUserToOrderColumns = True
        Me.dgMessInv.AllowUserToResizeRows = False
        Me.dgMessInv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgMessInv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgMessInv.BackgroundColor = System.Drawing.Color.White
        Me.dgMessInv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMessInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgMessInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMessInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoInv, Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.dgMessInv.CustomVirtualMode = False
        Me.dgMessInv.DataSourceVirtual = Nothing
        Me.dgMessInv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMessInv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgMessInv.Location = New System.Drawing.Point(3, 3)
        Me.dgMessInv.Name = "dgMessInv"
        Me.dgMessInv.RowHeadersVisible = False
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgMessInv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgMessInv.RowTemplate.Height = 30
        Me.dgMessInv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMessInv.ScrollManuale = False
        Me.dgMessInv.ScrollValue = 0
        Me.dgMessInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMessInv.ShowEditingIcon = False
        Me.dgMessInv.Size = New System.Drawing.Size(923, 308)
        Me.dgMessInv.TabIndex = 27
        '
        'TipoInv
        '
        Me.TipoInv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TipoInv.DataPropertyName = "icoTipo"
        Me.TipoInv.HeaderText = "Tipo"
        Me.TipoInv.Name = "TipoInv"
        Me.TipoInv.Width = 37
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn1.DataPropertyName = "Anteprima"
        Me.DataGridViewImageColumn1.HeaderText = "Anteprima"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 69
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Commessa"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Commessa"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 91
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Ordine"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ordine"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 68
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DataInsFormat"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Data"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 56
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "NomeMitt"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Mittente"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 77
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "NomeDest"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Destinatario"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 76
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Titolo"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Titolo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 63
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Riassunto"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Testo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 200
        '
        'mnuMessaggi
        '
        Me.mnuMessaggi.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelezionaTuttoToolStripMenuItem, Me.ToolStripSeparator1, Me.ModificaToolStripMenuItem, Me.EliminaToolStripMenuItem})
        Me.mnuMessaggi.Name = "mnuMessaggi"
        Me.mnuMessaggi.Size = New System.Drawing.Size(204, 76)
        '
        'SelezionaTuttoToolStripMenuItem
        '
        Me.SelezionaTuttoToolStripMenuItem.Name = "SelezionaTuttoToolStripMenuItem"
        Me.SelezionaTuttoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelezionaTuttoToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SelezionaTuttoToolStripMenuItem.Text = "Seleziona tutto"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(200, 6)
        '
        'ModificaToolStripMenuItem
        '
        Me.ModificaToolStripMenuItem.Name = "ModificaToolStripMenuItem"
        Me.ModificaToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ModificaToolStripMenuItem.Text = "Modifica"
        '
        'EliminaToolStripMenuItem
        '
        Me.EliminaToolStripMenuItem.Name = "EliminaToolStripMenuItem"
        Me.EliminaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.EliminaToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.EliminaToolStripMenuItem.Text = "Elimina"
        '
        'pctMonitor
        '
        Me.pctMonitor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctMonitor.Image = Global.Former.My.Resources.Resources._Postazione
        Me.pctMonitor.Location = New System.Drawing.Point(3, 3)
        Me.pctMonitor.Name = "pctMonitor"
        Me.pctMonitor.Size = New System.Drawing.Size(32, 32)
        Me.pctMonitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctMonitor.TabIndex = 50
        Me.pctMonitor.TabStop = False
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(41, 3)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(83, 32)
        Me.lnkAggiorna.TabIndex = 49
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNew
        '
        Me.lnkNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Messaggio
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(866, 3)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(71, 32)
        Me.lnkNew.TabIndex = 48
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ucMessaggiInterni
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tabMess)
        Me.Controls.Add(Me.pctMonitor)
        Me.Controls.Add(Me.lnkAggiorna)
        Me.Controls.Add(Me.lnkNew)
        Me.Name = "ucMessaggiInterni"
        Me.Size = New System.Drawing.Size(940, 378)
        Me.tabMess.ResumeLayout(False)
        Me.tpRic.ResumeLayout(False)
        CType(Me.dgMessRic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInv.ResumeLayout(False)
        CType(Me.dgMessInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuMessaggi.ResumeLayout(False)
        CType(Me.pctMonitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pctMonitor As System.Windows.Forms.PictureBox
    Friend WithEvents lnkAggiorna As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents tabMess As System.Windows.Forms.TabControl
    Friend WithEvents tpRic As System.Windows.Forms.TabPage
    Friend WithEvents tpInv As System.Windows.Forms.TabPage
    Friend WithEvents dgMessRic As ucDataGridView
    Friend WithEvents dgMessInv As ucDataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents TipoInv As DataGridViewImageColumn
    Friend WithEvents Testo As DataGridViewTextBoxColumn
    Friend WithEvents Titolo As DataGridViewTextBoxColumn
    Friend WithEvents Destinatario As DataGridViewTextBoxColumn
    Friend WithEvents Mittente As DataGridViewTextBoxColumn
    Friend WithEvents Data As DataGridViewTextBoxColumn
    Friend WithEvents Ordine As DataGridViewTextBoxColumn
    Friend WithEvents Commessa As DataGridViewTextBoxColumn
    Friend WithEvents Anteprima As DataGridViewImageColumn
    Friend WithEvents Tipo As DataGridViewImageColumn
    Friend WithEvents mnuMessaggi As ContextMenuStrip
    Friend WithEvents SelezionaTuttoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ModificaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminaToolStripMenuItem As ToolStripMenuItem
End Class
