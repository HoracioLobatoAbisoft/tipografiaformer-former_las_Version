<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAllegati
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
        Me.dgMessRic = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Anteprima = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Commessa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ordine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mittente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destinatario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titolo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Testo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgMessRic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgMessRic
        '
        Me.dgMessRic.AllowUserToAddRows = False
        Me.dgMessRic.AllowUserToDeleteRows = False
        Me.dgMessRic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgMessRic.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgMessRic.BackgroundColor = System.Drawing.Color.White
        Me.dgMessRic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMessRic.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgMessRic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMessRic.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Anteprima, Me.Commessa, Me.Ordine, Me.Data, Me.Mittente, Me.Destinatario, Me.Titolo, Me.Testo})
        Me.dgMessRic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMessRic.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgMessRic.Location = New System.Drawing.Point(0, 0)
        Me.dgMessRic.MultiSelect = False
        Me.dgMessRic.Name = "dgMessRic"
        Me.dgMessRic.RowHeadersVisible = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgMessRic.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMessRic.RowTemplate.Height = 30
        Me.dgMessRic.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMessRic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMessRic.ShowEditingIcon = False
        Me.dgMessRic.Size = New System.Drawing.Size(688, 306)
        Me.dgMessRic.TabIndex = 26
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Tipo.DataPropertyName = "icoTipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 35
        '
        'Anteprima
        '
        Me.Anteprima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Anteprima.DataPropertyName = "Anteprima"
        Me.Anteprima.HeaderText = "Anteprima"
        Me.Anteprima.Name = "Anteprima"
        Me.Anteprima.Width = 66
        '
        'Commessa
        '
        Me.Commessa.DataPropertyName = "Commessa"
        Me.Commessa.HeaderText = "Commessa"
        Me.Commessa.Name = "Commessa"
        Me.Commessa.Width = 86
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
        Me.Mittente.Width = 76
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
        Me.Titolo.Width = 61
        '
        'Testo
        '
        Me.Testo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Testo.DataPropertyName = "Riassunto"
        Me.Testo.HeaderText = "Testo"
        Me.Testo.Name = "Testo"
        Me.Testo.Width = 200
        '
        'ucAllegati
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.dgMessRic)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucAllegati"
        Me.Size = New System.Drawing.Size(688, 306)
        CType(Me.dgMessRic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgMessRic As System.Windows.Forms.DataGridView
    Friend WithEvents Testo As DataGridViewTextBoxColumn
    Friend WithEvents Titolo As DataGridViewTextBoxColumn
    Friend WithEvents Destinatario As DataGridViewTextBoxColumn
    Friend WithEvents Mittente As DataGridViewTextBoxColumn
    Friend WithEvents Data As DataGridViewTextBoxColumn
    Friend WithEvents Ordine As DataGridViewTextBoxColumn
    Friend WithEvents Commessa As DataGridViewTextBoxColumn
    Friend WithEvents Anteprima As DataGridViewImageColumn
    Friend WithEvents Tipo As DataGridViewImageColumn
End Class
