<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMagazzinoMgrMovimenti
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
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.DgMovimenti = New Telerik.WinControls.UI.RadGridView()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblClienti = New System.Windows.Forms.Label()
        Me.cmbFornitore = New System.Windows.Forms.ComboBox()
        Me.cmbTipoRisorsa = New System.Windows.Forms.ComboBox()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.lnkStorno = New System.Windows.Forms.LinkLabel()
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
        Me.DgMovimenti.Location = New System.Drawing.Point(3, 50)
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
        GridViewTextBoxColumn2.FieldName = "TipoStr"
        GridViewTextBoxColumn2.HeaderText = "Tipo"
        GridViewTextBoxColumn2.Name = "Tipo"
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.FieldName = "RisorsaStr"
        GridViewTextBoxColumn3.HeaderText = "Risorsa"
        GridViewTextBoxColumn3.Name = "Risorsa"
        GridViewTextBoxColumn3.Width = 300
        GridViewTextBoxColumn4.FieldName = "Qta"
        GridViewTextBoxColumn4.HeaderText = "Q.ta"
        GridViewTextBoxColumn4.Name = "Qta"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 100
        GridViewTextBoxColumn5.FieldName = "Totale"
        GridViewTextBoxColumn5.FormatInfo = New System.Globalization.CultureInfo("it-IT")
        GridViewTextBoxColumn5.FormatString = "{0:C}"
        GridViewTextBoxColumn5.HeaderText = "Totale"
        GridViewTextBoxColumn5.Name = "Totale"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 100
        GridViewTextBoxColumn6.FieldName = "FatturaStr"
        GridViewTextBoxColumn6.HeaderText = "Fattura"
        GridViewTextBoxColumn6.Name = "Fattura"
        GridViewTextBoxColumn6.Width = 100
        GridViewTextBoxColumn7.FieldName = "UltimoFornStr"
        GridViewTextBoxColumn7.HeaderText = "Ultimo Fornitore"
        GridViewTextBoxColumn7.MinWidth = 100
        GridViewTextBoxColumn7.Name = "UltimoForn"
        GridViewTextBoxColumn7.Width = 100
        GridViewTextBoxColumn8.FieldName = "IdComStr"
        GridViewTextBoxColumn8.HeaderText = "Commessa"
        GridViewTextBoxColumn8.IsVisible = False
        GridViewTextBoxColumn8.Name = "Commessa"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 100
        GridViewTextBoxColumn9.FieldName = "OperatoreStr"
        GridViewTextBoxColumn9.HeaderText = "Operatore"
        GridViewTextBoxColumn9.Name = "OperatoreStr"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn9.Width = 100
        GridViewTextBoxColumn10.FieldName = "UrgenteStr"
        GridViewTextBoxColumn10.HeaderText = "Urgente"
        GridViewTextBoxColumn10.Name = "Urgente"
        GridViewTextBoxColumn11.FieldName = "Nota"
        GridViewTextBoxColumn11.HeaderText = "Note"
        GridViewTextBoxColumn11.MinWidth = 300
        GridViewTextBoxColumn11.Name = "Note"
        GridViewTextBoxColumn11.Width = 300
        Me.DgMovimenti.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewImageColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11})
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
        Me.DgMovimenti.Size = New System.Drawing.Size(1125, 487)
        Me.DgMovimenti.TabIndex = 63
        Me.DgMovimenti.ThemeName = "VisualStudio2012Light"
        '
        'lnkCerca
        '
        Me.lnkCerca.AutoSize = True
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(488, 18)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkCerca.Size = New System.Drawing.Size(67, 27)
        Me.lnkCerca.TabIndex = 64
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Cerca"
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Tipologia"
        '
        'lblClienti
        '
        Me.lblClienti.AutoSize = True
        Me.lblClienti.BackColor = System.Drawing.Color.Transparent
        Me.lblClienti.ForeColor = System.Drawing.Color.Black
        Me.lblClienti.Location = New System.Drawing.Point(138, 3)
        Me.lblClienti.Name = "lblClienti"
        Me.lblClienti.Size = New System.Drawing.Size(55, 15)
        Me.lblClienti.TabIndex = 107
        Me.lblClienti.Text = "Fornitore"
        '
        'cmbFornitore
        '
        Me.cmbFornitore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFornitore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFornitore.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFornitore.FormattingEnabled = True
        Me.cmbFornitore.Location = New System.Drawing.Point(141, 21)
        Me.cmbFornitore.Name = "cmbFornitore"
        Me.cmbFornitore.Size = New System.Drawing.Size(341, 23)
        Me.cmbFornitore.TabIndex = 108
        '
        'cmbTipoRisorsa
        '
        Me.cmbTipoRisorsa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoRisorsa.FormattingEnabled = True
        Me.cmbTipoRisorsa.Location = New System.Drawing.Point(3, 21)
        Me.cmbTipoRisorsa.Name = "cmbTipoRisorsa"
        Me.cmbTipoRisorsa.Size = New System.Drawing.Size(132, 23)
        Me.cmbTipoRisorsa.TabIndex = 106
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.AutoSize = True
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(966, 18)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkStampa.Size = New System.Drawing.Size(77, 27)
        Me.lnkStampa.TabIndex = 110
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDel
        '
        Me.lnkDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDel.AutoSize = True
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(1052, 18)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDel.Size = New System.Drawing.Size(76, 27)
        Me.lnkDel.TabIndex = 111
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Elimina"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkStorno
        '
        Me.lnkStorno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStorno.AutoSize = True
        Me.lnkStorno.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStorno.Image = Global.Former.My.Resources.Resources.do_not_mix24
        Me.lnkStorno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStorno.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStorno.Location = New System.Drawing.Point(879, 18)
        Me.lnkStorno.Name = "lnkStorno"
        Me.lnkStorno.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkStorno.Size = New System.Drawing.Size(72, 27)
        Me.lnkStorno.TabIndex = 112
        Me.lnkStorno.TabStop = True
        Me.lnkStorno.Text = "Storno"
        Me.lnkStorno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkStorno.Visible = False
        '
        'ucMagazzinoMgrMovimenti
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkStorno)
        Me.Controls.Add(Me.lnkDel)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblClienti)
        Me.Controls.Add(Me.cmbFornitore)
        Me.Controls.Add(Me.cmbTipoRisorsa)
        Me.Controls.Add(Me.lnkCerca)
        Me.Controls.Add(Me.DgMovimenti)
        Me.Name = "ucMagazzinoMgrMovimenti"
        Me.Size = New System.Drawing.Size(1131, 540)
        CType(Me.DgMovimenti.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgMovimenti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DgMovimenti As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lnkCerca As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents lblClienti As Label
    Friend WithEvents cmbFornitore As ComboBox
    Friend WithEvents cmbTipoRisorsa As ComboBox
    Friend WithEvents lnkStampa As LinkLabel
    Friend WithEvents lnkDel As LinkLabel
    Friend WithEvents lnkStorno As LinkLabel
End Class
