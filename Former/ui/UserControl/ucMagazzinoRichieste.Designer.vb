<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMagazzinoRichieste
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
        Dim GridViewImageColumn1 As Telerik.WinControls.UI.GridViewImageColumn = New Telerik.WinControls.UI.GridViewImageColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.DgMovimenti = New Telerik.WinControls.UI.RadGridView()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lnkNuovo = New System.Windows.Forms.LinkLabel()
        CType(Me.DgMovimenti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgMovimenti.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgMovimenti
        '
        Me.DgMovimenti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgMovimenti.AutoScroll = True
        Me.DgMovimenti.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.DgMovimenti.EnableGestures = False
        Me.DgMovimenti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgMovimenti.Location = New System.Drawing.Point(3, 40)
        '
        '
        '
        Me.DgMovimenti.MasterTemplate.AllowAddNewRow = False
        Me.DgMovimenti.MasterTemplate.AllowCellContextMenu = False
        Me.DgMovimenti.MasterTemplate.AllowColumnChooser = False
        Me.DgMovimenti.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.DgMovimenti.MasterTemplate.AllowDeleteRow = False
        Me.DgMovimenti.MasterTemplate.AllowDragToGroup = False
        Me.DgMovimenti.MasterTemplate.AllowEditRow = False
        Me.DgMovimenti.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.DgMovimenti.MasterTemplate.AllowRowResize = False
        Me.DgMovimenti.MasterTemplate.AllowSearchRow = True
        Me.DgMovimenti.MasterTemplate.AutoGenerateColumns = False
        GridViewImageColumn1.FieldName = "ImageRif"
        GridViewImageColumn1.HeaderText = ""
        GridViewImageColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        GridViewImageColumn1.MaxWidth = 64
        GridViewImageColumn1.MinWidth = 64
        GridViewImageColumn1.Name = "ImageRif"
        GridViewImageColumn1.StretchVertically = False
        GridViewImageColumn1.Width = 64
        GridViewTextBoxColumn1.FieldName = "DataMov"
        GridViewTextBoxColumn1.HeaderText = "Data"
        GridViewTextBoxColumn1.Name = "Data"
        GridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn1.Width = 120
        GridViewTextBoxColumn2.FieldName = "RisorsaStr"
        GridViewTextBoxColumn2.HeaderText = "Risorsa"
        GridViewTextBoxColumn2.Name = "Risorsa"
        GridViewTextBoxColumn2.Width = 300
        GridViewTextBoxColumn3.FieldName = "Qta"
        GridViewTextBoxColumn3.HeaderText = "Q.ta"
        GridViewTextBoxColumn3.Name = "Qta"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 100
        GridViewTextBoxColumn4.FieldName = "OperatoreStr"
        GridViewTextBoxColumn4.HeaderText = "Operatore"
        GridViewTextBoxColumn4.Name = "OperatoreStr"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn4.Width = 100
        GridViewTextBoxColumn5.FieldName = "UltimoFornStr"
        GridViewTextBoxColumn5.HeaderText = "Ultimo Fornitore"
        GridViewTextBoxColumn5.MinWidth = 200
        GridViewTextBoxColumn5.Name = "FornitoreStr"
        GridViewTextBoxColumn5.Width = 200
        Me.DgMovimenti.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewImageColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5})
        Me.DgMovimenti.MasterTemplate.EnableAlternatingRowColor = True
        Me.DgMovimenti.MasterTemplate.EnableGrouping = False
        Me.DgMovimenti.MasterTemplate.MultiSelect = True
        Me.DgMovimenti.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgMovimenti.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.DgMovimenti.Name = "DgMovimenti"
        Me.DgMovimenti.ReadOnly = True
        Me.DgMovimenti.ShowGroupPanel = False
        Me.DgMovimenti.ShowGroupPanelScrollbars = False
        Me.DgMovimenti.ShowNoDataText = False
        Me.DgMovimenti.Size = New System.Drawing.Size(802, 497)
        Me.DgMovimenti.TabIndex = 64
        Me.DgMovimenti.ThemeName = "VisualStudio2012Light"
        '
        'lnkAll
        '
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(3, 0)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Size = New System.Drawing.Size(101, 37)
        Me.lnkAll.TabIndex = 65
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Mostra tutto"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDel
        '
        Me.lnkDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDel.AutoSize = True
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(726, 5)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDel.Size = New System.Drawing.Size(76, 27)
        Me.lnkDel.TabIndex = 112
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Elimina"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(640, 5)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 27)
        Me.lnkStampa.TabIndex = 113
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNuovo
        '
        Me.lnkNuovo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNuovo.AutoSize = True
        Me.lnkNuovo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNuovo.Image = Global.Former.My.Resources.Resources._OrdineAcquisto
        Me.lnkNuovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNuovo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNuovo.Location = New System.Drawing.Point(522, 5)
        Me.lnkNuovo.Name = "lnkNuovo"
        Me.lnkNuovo.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkNuovo.Size = New System.Drawing.Size(112, 27)
        Me.lnkNuovo.TabIndex = 118
        Me.lnkNuovo.TabStop = True
        Me.lnkNuovo.Text = "Nuovo Ordine"
        Me.lnkNuovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucMagazzinoRichieste
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkNuovo)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.lnkDel)
        Me.Controls.Add(Me.lnkAll)
        Me.Controls.Add(Me.DgMovimenti)
        Me.Name = "ucMagazzinoRichieste"
        Me.Size = New System.Drawing.Size(805, 540)
        CType(Me.DgMovimenti.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgMovimenti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DgMovimenti As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lnkAll As LinkLabel
    Friend WithEvents lnkDel As LinkLabel
    Friend WithEvents lnkStampa As LinkLabel
    Friend WithEvents lnkNuovo As LinkLabel
End Class
