<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMagazzinoOrdiniAcquisto
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.DgOrdini = New Telerik.WinControls.UI.RadGridView()
        Me.lnkNuovo = New System.Windows.Forms.LinkLabel()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lblClienti = New System.Windows.Forms.Label()
        Me.cmbFornitore = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbRisorsa = New System.Windows.Forms.ComboBox()
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgOrdini.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkDel
        '
        Me.lnkDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDel.AutoSize = True
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(724, 7)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDel.Size = New System.Drawing.Size(76, 27)
        Me.lnkDel.TabIndex = 115
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Elimina"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAll
        '
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(1, 2)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Size = New System.Drawing.Size(101, 37)
        Me.lnkAll.TabIndex = 114
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Mostra tutto"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgOrdini
        '
        Me.DgOrdini.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgOrdini.AutoScroll = True
        Me.DgOrdini.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.DgOrdini.EnableGestures = False
        Me.DgOrdini.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgOrdini.Location = New System.Drawing.Point(1, 71)
        '
        '
        '
        Me.DgOrdini.MasterTemplate.AllowAddNewRow = False
        Me.DgOrdini.MasterTemplate.AllowCellContextMenu = False
        Me.DgOrdini.MasterTemplate.AllowColumnChooser = False
        Me.DgOrdini.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.DgOrdini.MasterTemplate.AllowDeleteRow = False
        Me.DgOrdini.MasterTemplate.AllowDragToGroup = False
        Me.DgOrdini.MasterTemplate.AllowEditRow = False
        Me.DgOrdini.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.DgOrdini.MasterTemplate.AllowRowResize = False
        Me.DgOrdini.MasterTemplate.AllowSearchRow = True
        Me.DgOrdini.MasterTemplate.AutoGenerateColumns = False
        GridViewTextBoxColumn1.FieldName = "DataMov"
        GridViewTextBoxColumn1.HeaderText = "Data"
        GridViewTextBoxColumn1.Name = "Data"
        GridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn1.Width = 120
        GridViewTextBoxColumn2.FieldName = "OperatoreStr"
        GridViewTextBoxColumn2.HeaderText = "Operatore"
        GridViewTextBoxColumn2.Name = "OperatoreStr"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.FieldName = "Annotazioni"
        GridViewTextBoxColumn3.HeaderText = "Annotazioni"
        GridViewTextBoxColumn3.Name = "Risorsa"
        GridViewTextBoxColumn3.Width = 300
        Me.DgOrdini.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3})
        Me.DgOrdini.MasterTemplate.EnableAlternatingRowColor = True
        Me.DgOrdini.MasterTemplate.EnableGrouping = False
        Me.DgOrdini.MasterTemplate.MultiSelect = True
        Me.DgOrdini.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgOrdini.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.DgOrdini.Name = "DgOrdini"
        Me.DgOrdini.ReadOnly = True
        Me.DgOrdini.ShowGroupPanel = False
        Me.DgOrdini.ShowGroupPanelScrollbars = False
        Me.DgOrdini.ShowNoDataText = False
        Me.DgOrdini.Size = New System.Drawing.Size(802, 468)
        Me.DgOrdini.TabIndex = 113
        Me.DgOrdini.ThemeName = "VisualStudio2012Light"
        '
        'lnkNuovo
        '
        Me.lnkNuovo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNuovo.AutoSize = True
        Me.lnkNuovo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNuovo.Image = Global.Former.My.Resources.Resources._OrdineAcquisto
        Me.lnkNuovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNuovo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNuovo.Location = New System.Drawing.Point(560, 7)
        Me.lnkNuovo.Name = "lnkNuovo"
        Me.lnkNuovo.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkNuovo.Size = New System.Drawing.Size(73, 27)
        Me.lnkNuovo.TabIndex = 117
        Me.lnkNuovo.TabStop = True
        Me.lnkNuovo.Text = "Nuovo"
        Me.lnkNuovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(638, 2)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 37)
        Me.lnkStampa.TabIndex = 116
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClienti
        '
        Me.lblClienti.AutoSize = True
        Me.lblClienti.BackColor = System.Drawing.Color.Transparent
        Me.lblClienti.ForeColor = System.Drawing.Color.Black
        Me.lblClienti.Location = New System.Drawing.Point(3, 45)
        Me.lblClienti.Name = "lblClienti"
        Me.lblClienti.Size = New System.Drawing.Size(55, 15)
        Me.lblClienti.TabIndex = 118
        Me.lblClienti.Text = "Fornitore"
        '
        'cmbFornitore
        '
        Me.cmbFornitore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFornitore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFornitore.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFornitore.FormattingEnabled = True
        Me.cmbFornitore.Location = New System.Drawing.Point(64, 42)
        Me.cmbFornitore.Name = "cmbFornitore"
        Me.cmbFornitore.Size = New System.Drawing.Size(285, 23)
        Me.cmbFornitore.TabIndex = 119
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(355, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Risorsa"
        '
        'cmbRisorsa
        '
        Me.cmbRisorsa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRisorsa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRisorsa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbRisorsa.FormattingEnabled = True
        Me.cmbRisorsa.Location = New System.Drawing.Point(405, 42)
        Me.cmbRisorsa.Name = "cmbRisorsa"
        Me.cmbRisorsa.Size = New System.Drawing.Size(395, 23)
        Me.cmbRisorsa.TabIndex = 121
        '
        'ucMagazzinoOrdiniAcquisto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.cmbRisorsa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblClienti)
        Me.Controls.Add(Me.cmbFornitore)
        Me.Controls.Add(Me.lnkNuovo)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.lnkDel)
        Me.Controls.Add(Me.lnkAll)
        Me.Controls.Add(Me.DgOrdini)
        Me.Name = "ucMagazzinoOrdiniAcquisto"
        Me.Size = New System.Drawing.Size(805, 540)
        CType(Me.DgOrdini.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lnkDel As LinkLabel
    Friend WithEvents lnkAll As LinkLabel
    Friend WithEvents DgOrdini As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lnkNuovo As LinkLabel
    Friend WithEvents lnkStampa As LinkLabel
    Friend WithEvents lblClienti As Label
    Friend WithEvents cmbFornitore As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbRisorsa As ComboBox
End Class
