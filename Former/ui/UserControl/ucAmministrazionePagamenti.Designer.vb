<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazionePagamenti
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.ContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminaToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RiapriDocumentoFiscaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DgPagamentiEx = New Telerik.WinControls.UI.RadGridView()
        Me.dtDataSelFine = New System.Windows.Forms.DateTimePicker()
        Me.chkOnlyDataSel = New System.Windows.Forms.CheckBox()
        Me.lblNumEuro = New System.Windows.Forms.Label()
        Me.dtDataSelInizio = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenu.SuspendLayout()
        CType(Me.DgPagamentiEx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgPagamentiEx.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(826, 0)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 26)
        Me.lnkStampa.TabIndex = 58
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAll
        '
        Me.lnkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(748, 0)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Size = New System.Drawing.Size(72, 26)
        Me.lnkAll.TabIndex = 57
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Mostra"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContextMenu
        '
        Me.ContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaToolStripMenuItem, Me.EliminaToolStripMenu, Me.ToolStripSeparator1, Me.RiapriDocumentoFiscaleToolStripMenuItem})
        Me.ContextMenu.Name = "ContextMenu"
        Me.ContextMenu.Size = New System.Drawing.Size(209, 76)
        '
        'ModificaToolStripMenuItem
        '
        Me.ModificaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Modifica
        Me.ModificaToolStripMenuItem.Name = "ModificaToolStripMenuItem"
        Me.ModificaToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ModificaToolStripMenuItem.Text = "Modifica"
        '
        'EliminaToolStripMenu
        '
        Me.EliminaToolStripMenu.Image = Global.Former.My.Resources.Resources._Elimina
        Me.EliminaToolStripMenu.Name = "EliminaToolStripMenu"
        Me.EliminaToolStripMenu.Size = New System.Drawing.Size(208, 22)
        Me.EliminaToolStripMenu.Text = "Elimina"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(205, 6)
        '
        'RiapriDocumentoFiscaleToolStripMenuItem
        '
        Me.RiapriDocumentoFiscaleToolStripMenuItem.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.RiapriDocumentoFiscaleToolStripMenuItem.Name = "RiapriDocumentoFiscaleToolStripMenuItem"
        Me.RiapriDocumentoFiscaleToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.RiapriDocumentoFiscaleToolStripMenuItem.Text = "Riapri Documento Fiscale"
        '
        'DgPagamentiEx
        '
        Me.DgPagamentiEx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgPagamentiEx.AutoScroll = True
        Me.DgPagamentiEx.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.DgPagamentiEx.EnableGestures = False
        Me.DgPagamentiEx.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgPagamentiEx.Location = New System.Drawing.Point(3, 29)
        '
        '
        '
        Me.DgPagamentiEx.MasterTemplate.AllowAddNewRow = False
        Me.DgPagamentiEx.MasterTemplate.AllowCellContextMenu = False
        Me.DgPagamentiEx.MasterTemplate.AllowColumnChooser = False
        Me.DgPagamentiEx.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.DgPagamentiEx.MasterTemplate.AllowDeleteRow = False
        Me.DgPagamentiEx.MasterTemplate.AllowDragToGroup = False
        Me.DgPagamentiEx.MasterTemplate.AllowEditRow = False
        Me.DgPagamentiEx.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.DgPagamentiEx.MasterTemplate.AllowRowResize = False
        Me.DgPagamentiEx.MasterTemplate.AllowSearchRow = True
        Me.DgPagamentiEx.MasterTemplate.AutoGenerateColumns = False
        GridViewTextBoxColumn1.FieldName = "ClienteNominativo"
        GridViewTextBoxColumn1.HeaderText = "Cliente"
        GridViewTextBoxColumn1.Name = "Cliente"
        GridViewTextBoxColumn1.Width = 150
        GridViewTextBoxColumn2.FieldName = "RiferitoA"
        GridViewTextBoxColumn2.HeaderText = "Riferito a:"
        GridViewTextBoxColumn2.Name = "Riferito A"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn2.Width = 150
        GridViewTextBoxColumn3.FieldName = "NumeroDocStr"
        GridViewTextBoxColumn3.HeaderText = "Numero"
        GridViewTextBoxColumn3.Name = "IdOrdine"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 70
        GridViewTextBoxColumn4.FieldName = "DataPag"
        GridViewTextBoxColumn4.HeaderText = "Data Pagamento"
        GridViewTextBoxColumn4.Name = "Data"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 100
        GridViewTextBoxColumn5.FieldName = "TipoPagamentoStr"
        GridViewTextBoxColumn5.HeaderText = "Tipo Pagamento"
        GridViewTextBoxColumn5.Name = "Prodotto"
        GridViewTextBoxColumn5.Width = 150
        GridViewTextBoxColumn6.FieldName = "Importo"
        GridViewTextBoxColumn6.FormatInfo = New System.Globalization.CultureInfo("it-IT")
        GridViewTextBoxColumn6.FormatString = "{0:C}"
        GridViewTextBoxColumn6.HeaderText = "Importo"
        GridViewTextBoxColumn6.Name = "Totale"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 80
        Me.DgPagamentiEx.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.DgPagamentiEx.MasterTemplate.EnableAlternatingRowColor = True
        Me.DgPagamentiEx.MasterTemplate.EnableGrouping = False
        Me.DgPagamentiEx.MasterTemplate.MultiSelect = True
        Me.DgPagamentiEx.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgPagamentiEx.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.DgPagamentiEx.Name = "DgPagamentiEx"
        Me.DgPagamentiEx.ReadOnly = True
        Me.DgPagamentiEx.ShowGroupPanel = False
        Me.DgPagamentiEx.ShowGroupPanelScrollbars = False
        Me.DgPagamentiEx.ShowNoDataText = False
        Me.DgPagamentiEx.Size = New System.Drawing.Size(903, 678)
        Me.DgPagamentiEx.TabIndex = 63
        Me.DgPagamentiEx.ThemeName = "VisualStudio2012Light"
        '
        'dtDataSelFine
        '
        Me.dtDataSelFine.Location = New System.Drawing.Point(407, 3)
        Me.dtDataSelFine.Name = "dtDataSelFine"
        Me.dtDataSelFine.Size = New System.Drawing.Size(200, 23)
        Me.dtDataSelFine.TabIndex = 64
        '
        'chkOnlyDataSel
        '
        Me.chkOnlyDataSel.AutoSize = True
        Me.chkOnlyDataSel.Checked = True
        Me.chkOnlyDataSel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOnlyDataSel.Location = New System.Drawing.Point(3, 5)
        Me.chkOnlyDataSel.Name = "chkOnlyDataSel"
        Me.chkOnlyDataSel.Size = New System.Drawing.Size(174, 19)
        Me.chkOnlyDataSel.TabIndex = 65
        Me.chkOnlyDataSel.Text = "Solo nel periodo selezionato"
        Me.chkOnlyDataSel.UseVisualStyleBackColor = True
        '
        'lblNumEuro
        '
        Me.lblNumEuro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumEuro.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblNumEuro.Location = New System.Drawing.Point(778, 710)
        Me.lblNumEuro.Name = "lblNumEuro"
        Me.lblNumEuro.Size = New System.Drawing.Size(131, 13)
        Me.lblNumEuro.TabIndex = 66
        Me.lblNumEuro.Text = "€ 0,00"
        Me.lblNumEuro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtDataSelInizio
        '
        Me.dtDataSelInizio.Location = New System.Drawing.Point(183, 3)
        Me.dtDataSelInizio.Name = "dtDataSelInizio"
        Me.dtDataSelInizio.Size = New System.Drawing.Size(200, 23)
        Me.dtDataSelInizio.TabIndex = 67
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(389, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "-"
        '
        'ucAmministrazionePagamenti
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtDataSelInizio)
        Me.Controls.Add(Me.lblNumEuro)
        Me.Controls.Add(Me.chkOnlyDataSel)
        Me.Controls.Add(Me.dtDataSelFine)
        Me.Controls.Add(Me.DgPagamentiEx)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.lnkAll)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucAmministrazionePagamenti"
        Me.Size = New System.Drawing.Size(909, 723)
        Me.ContextMenu.ResumeLayout(False)
        CType(Me.DgPagamentiEx.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgPagamentiEx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAll As System.Windows.Forms.LinkLabel
    Friend WithEvents ContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminaToolStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents RiapriDocumentoFiscaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DgPagamentiEx As Telerik.WinControls.UI.RadGridView
    Friend WithEvents dtDataSelFine As DateTimePicker
    Friend WithEvents chkOnlyDataSel As CheckBox
    Friend WithEvents lblNumEuro As Label
    Friend WithEvents dtDataSelInizio As DateTimePicker
    Friend WithEvents Label1 As Label
End Class
