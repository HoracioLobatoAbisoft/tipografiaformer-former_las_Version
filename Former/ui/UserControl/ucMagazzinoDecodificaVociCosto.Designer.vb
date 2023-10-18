<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMagazzinoDecodificaVociCosto
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
        Dim GridViewImageColumn3 As Telerik.WinControls.UI.GridViewImageColumn = New Telerik.WinControls.UI.GridViewImageColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewImageColumn4 As Telerik.WinControls.UI.GridViewImageColumn = New Telerik.WinControls.UI.GridViewImageColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.DgDecodifiche = New Telerik.WinControls.UI.RadGridView()
        CType(Me.DgDecodifiche, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgDecodifiche.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lnkDel.Location = New System.Drawing.Point(940, 0)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDel.Size = New System.Drawing.Size(76, 27)
        Me.lnkDel.TabIndex = 121
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Elimina"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAll
        '
        Me.lnkAll.AutoSize = True
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(3, 0)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAll.Size = New System.Drawing.Size(103, 27)
        Me.lnkAll.TabIndex = 120
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Mostra tutto"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgDecodifiche
        '
        Me.DgDecodifiche.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgDecodifiche.AutoScroll = True
        Me.DgDecodifiche.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.DgDecodifiche.EnableGestures = False
        Me.DgDecodifiche.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgDecodifiche.Location = New System.Drawing.Point(3, 30)
        '
        '
        '
        Me.DgDecodifiche.MasterTemplate.AllowAddNewRow = False
        Me.DgDecodifiche.MasterTemplate.AllowCellContextMenu = False
        Me.DgDecodifiche.MasterTemplate.AllowColumnChooser = False
        Me.DgDecodifiche.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.DgDecodifiche.MasterTemplate.AllowDeleteRow = False
        Me.DgDecodifiche.MasterTemplate.AllowDragToGroup = False
        Me.DgDecodifiche.MasterTemplate.AllowEditRow = False
        Me.DgDecodifiche.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.DgDecodifiche.MasterTemplate.AllowRowResize = False
        Me.DgDecodifiche.MasterTemplate.AllowSearchRow = True
        Me.DgDecodifiche.MasterTemplate.AutoGenerateColumns = False
        GridViewImageColumn3.FieldName = "ImageRif"
        GridViewImageColumn3.HeaderText = ""
        GridViewImageColumn3.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        GridViewImageColumn3.MaxWidth = 64
        GridViewImageColumn3.MinWidth = 64
        GridViewImageColumn3.Name = "ImageRif"
        GridViewImageColumn3.StretchVertically = False
        GridViewImageColumn3.Width = 64
        GridViewTextBoxColumn6.FieldName = "FornitoreStr"
        GridViewTextBoxColumn6.HeaderText = "Fornitore"
        GridViewTextBoxColumn6.MinWidth = 200
        GridViewTextBoxColumn6.Name = "Fornitore"
        GridViewTextBoxColumn6.Width = 200
        GridViewImageColumn4.FieldName = "TipoRegolaIMG"
        GridViewImageColumn4.HeaderText = ""
        GridViewImageColumn4.MinWidth = 30
        GridViewImageColumn4.Name = "TipoRegolaIMG"
        GridViewImageColumn4.Width = 30
        GridViewTextBoxColumn7.FieldName = "TipoDecodificaStr"
        GridViewTextBoxColumn7.HeaderText = "Tipo"
        GridViewTextBoxColumn7.Name = "Data"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn7.Width = 120
        GridViewTextBoxColumn8.FieldName = "RisorsaStr"
        GridViewTextBoxColumn8.HeaderText = "Risorsa/Descrizione"
        GridViewTextBoxColumn8.Name = "Risorsa"
        GridViewTextBoxColumn8.Width = 300
        GridViewTextBoxColumn9.FieldName = "UM"
        GridViewTextBoxColumn9.HeaderText = "U.M."
        GridViewTextBoxColumn9.Name = "Um"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn9.Width = 100
        GridViewTextBoxColumn10.FieldName = "QtaMoltiplicatore"
        GridViewTextBoxColumn10.HeaderText = "Moltiplicatore"
        GridViewTextBoxColumn10.Name = "QtaMoltiplicatore"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn10.Width = 100
        Me.DgDecodifiche.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewImageColumn3, GridViewTextBoxColumn6, GridViewImageColumn4, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10})
        Me.DgDecodifiche.MasterTemplate.EnableAlternatingRowColor = True
        Me.DgDecodifiche.MasterTemplate.EnableGrouping = False
        Me.DgDecodifiche.MasterTemplate.MultiSelect = True
        Me.DgDecodifiche.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgDecodifiche.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.DgDecodifiche.Name = "DgDecodifiche"
        Me.DgDecodifiche.ReadOnly = True
        Me.DgDecodifiche.ShowGroupPanel = False
        Me.DgDecodifiche.ShowGroupPanelScrollbars = False
        Me.DgDecodifiche.ShowNoDataText = False
        Me.DgDecodifiche.Size = New System.Drawing.Size(1013, 510)
        Me.DgDecodifiche.TabIndex = 119
        Me.DgDecodifiche.ThemeName = "VisualStudio2012Light"
        '
        'ucMagazzinoDecodificaVociCosto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkDel)
        Me.Controls.Add(Me.lnkAll)
        Me.Controls.Add(Me.DgDecodifiche)
        Me.Name = "ucMagazzinoDecodificaVociCosto"
        Me.Size = New System.Drawing.Size(1019, 540)
        CType(Me.DgDecodifiche.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgDecodifiche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lnkDel As LinkLabel
    Friend WithEvents lnkAll As LinkLabel
    Friend WithEvents DgDecodifiche As Telerik.WinControls.UI.RadGridView
End Class
