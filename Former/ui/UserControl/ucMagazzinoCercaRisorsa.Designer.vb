<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMagazzinoCercaRisorsa
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdoEtichette = New System.Windows.Forms.RadioButton()
        Me.rdoPackaging = New System.Windows.Forms.RadioButton()
        Me.rdoRicamo = New System.Windows.Forms.RadioButton()
        Me.rdoDigitale = New System.Windows.Forms.RadioButton()
        Me.rdoOffset = New System.Windows.Forms.RadioButton()
        Me.rdoTutto = New System.Windows.Forms.RadioButton()
        Me.cmbMacchinarioSel = New Telerik.WinControls.UI.RadDropDownList()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.dgRisorseEx = New Telerik.WinControls.UI.RadGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkOnlyRisMovimentate = New System.Windows.Forms.CheckBox()
        Me.cmbUtenti = New System.Windows.Forms.ComboBox()
        CType(Me.cmbMacchinarioSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRisorseEx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRisorseEx.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbCategoria
        '
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(100, 175)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(570, 33)
        Me.cmbCategoria.TabIndex = 126
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Categoria"
        '
        'rdoEtichette
        '
        Me.rdoEtichette.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.rdoEtichette.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoEtichette.ForeColor = System.Drawing.Color.White
        Me.rdoEtichette.Location = New System.Drawing.Point(580, 39)
        Me.rdoEtichette.Name = "rdoEtichette"
        Me.rdoEtichette.Size = New System.Drawing.Size(90, 44)
        Me.rdoEtichette.TabIndex = 120
        Me.rdoEtichette.Text = "Etichette"
        Me.rdoEtichette.UseVisualStyleBackColor = False
        '
        'rdoPackaging
        '
        Me.rdoPackaging.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdoPackaging.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPackaging.Location = New System.Drawing.Point(484, 39)
        Me.rdoPackaging.Name = "rdoPackaging"
        Me.rdoPackaging.Size = New System.Drawing.Size(90, 44)
        Me.rdoPackaging.TabIndex = 119
        Me.rdoPackaging.Text = "Packaging"
        Me.rdoPackaging.UseVisualStyleBackColor = False
        '
        'rdoRicamo
        '
        Me.rdoRicamo.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.rdoRicamo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoRicamo.Location = New System.Drawing.Point(388, 39)
        Me.rdoRicamo.Name = "rdoRicamo"
        Me.rdoRicamo.Size = New System.Drawing.Size(90, 44)
        Me.rdoRicamo.TabIndex = 118
        Me.rdoRicamo.Text = "Ricamo"
        Me.rdoRicamo.UseVisualStyleBackColor = False
        '
        'rdoDigitale
        '
        Me.rdoDigitale.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.rdoDigitale.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoDigitale.ForeColor = System.Drawing.Color.White
        Me.rdoDigitale.Location = New System.Drawing.Point(292, 39)
        Me.rdoDigitale.Name = "rdoDigitale"
        Me.rdoDigitale.Size = New System.Drawing.Size(90, 44)
        Me.rdoDigitale.TabIndex = 117
        Me.rdoDigitale.Text = "Digitale"
        Me.rdoDigitale.UseVisualStyleBackColor = False
        '
        'rdoOffset
        '
        Me.rdoOffset.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.rdoOffset.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoOffset.ForeColor = System.Drawing.Color.White
        Me.rdoOffset.Location = New System.Drawing.Point(196, 39)
        Me.rdoOffset.Name = "rdoOffset"
        Me.rdoOffset.Size = New System.Drawing.Size(90, 44)
        Me.rdoOffset.TabIndex = 115
        Me.rdoOffset.Text = "Offset"
        Me.rdoOffset.UseVisualStyleBackColor = False
        '
        'rdoTutto
        '
        Me.rdoTutto.BackColor = System.Drawing.Color.Gainsboro
        Me.rdoTutto.Checked = True
        Me.rdoTutto.Location = New System.Drawing.Point(99, 39)
        Me.rdoTutto.Name = "rdoTutto"
        Me.rdoTutto.Size = New System.Drawing.Size(90, 44)
        Me.rdoTutto.TabIndex = 114
        Me.rdoTutto.TabStop = True
        Me.rdoTutto.Text = "Tutto"
        Me.rdoTutto.UseVisualStyleBackColor = False
        '
        'cmbMacchinarioSel
        '
        Me.cmbMacchinarioSel.AutoSize = False
        Me.cmbMacchinarioSel.AutoSizeItems = True
        Me.cmbMacchinarioSel.DropDownAnimationEnabled = False
        Me.cmbMacchinarioSel.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbMacchinarioSel.EnableAlternatingItemColor = True
        Me.cmbMacchinarioSel.Location = New System.Drawing.Point(99, 89)
        Me.cmbMacchinarioSel.Name = "cmbMacchinarioSel"
        Me.cmbMacchinarioSel.Size = New System.Drawing.Size(571, 80)
        Me.cmbMacchinarioSel.TabIndex = 121
        '
        'lnkCerca
        '
        Me.lnkCerca.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(602, 4)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(68, 33)
        Me.lnkCerca.TabIndex = 116
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Cerca"
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgRisorseEx
        '
        Me.dgRisorseEx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRisorseEx.AutoScroll = True
        Me.dgRisorseEx.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.dgRisorseEx.EnableGestures = False
        Me.dgRisorseEx.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgRisorseEx.Location = New System.Drawing.Point(99, 243)
        '
        '
        '
        Me.dgRisorseEx.MasterTemplate.AllowAddNewRow = False
        Me.dgRisorseEx.MasterTemplate.AllowCellContextMenu = False
        Me.dgRisorseEx.MasterTemplate.AllowColumnChooser = False
        Me.dgRisorseEx.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.dgRisorseEx.MasterTemplate.AllowDeleteRow = False
        Me.dgRisorseEx.MasterTemplate.AllowDragToGroup = False
        Me.dgRisorseEx.MasterTemplate.AllowEditRow = False
        Me.dgRisorseEx.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.dgRisorseEx.MasterTemplate.AllowRowResize = False
        Me.dgRisorseEx.MasterTemplate.AllowSearchRow = True
        Me.dgRisorseEx.MasterTemplate.AutoGenerateColumns = False
        GridViewImageColumn1.FieldName = "ImageRif"
        GridViewImageColumn1.HeaderText = ""
        GridViewImageColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Stretch
        GridViewImageColumn1.MaxWidth = 64
        GridViewImageColumn1.MinWidth = 64
        GridViewImageColumn1.Name = "image"
        GridViewImageColumn1.StretchVertically = False
        GridViewImageColumn1.Width = 64
        GridViewTextBoxColumn1.FieldName = "TipologiaStr"
        GridViewTextBoxColumn1.HeaderText = "Tipologia"
        GridViewTextBoxColumn1.Name = "Tipologia"
        GridViewTextBoxColumn1.Width = 150
        GridViewTextBoxColumn2.FieldName = "Descrizione"
        GridViewTextBoxColumn2.HeaderText = "Descrizione"
        GridViewTextBoxColumn2.Name = "Descrizione"
        GridViewTextBoxColumn2.Width = 200
        GridViewTextBoxColumn3.FieldName = "FornitoreStr"
        GridViewTextBoxColumn3.HeaderText = "Fornitore"
        GridViewTextBoxColumn3.Name = "RagSoc"
        GridViewTextBoxColumn3.Width = 200
        GridViewTextBoxColumn4.FieldName = "Giacenza"
        GridViewTextBoxColumn4.HeaderText = "Giacenza"
        GridViewTextBoxColumn4.MinWidth = 80
        GridViewTextBoxColumn4.Name = "Giacenza"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 80
        Me.dgRisorseEx.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewImageColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.dgRisorseEx.MasterTemplate.EnableAlternatingRowColor = True
        Me.dgRisorseEx.MasterTemplate.EnableGrouping = False
        Me.dgRisorseEx.MasterTemplate.MultiSelect = True
        Me.dgRisorseEx.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgRisorseEx.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgRisorseEx.Name = "dgRisorseEx"
        Me.dgRisorseEx.ReadOnly = True
        Me.dgRisorseEx.ShowGroupPanel = False
        Me.dgRisorseEx.ShowGroupPanelScrollbars = False
        Me.dgRisorseEx.ShowNoDataText = False
        Me.dgRisorseEx.Size = New System.Drawing.Size(571, 227)
        Me.dgRisorseEx.TabIndex = 122
        Me.dgRisorseEx.ThemeName = "VisualStudio2012Light"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 15)
        Me.Label8.TabIndex = 123
        Me.Label8.Text = "Macchinario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Descrizione"
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(99, 10)
        Me.txtDescr.MaxLength = 100
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(497, 23)
        Me.txtDescr.TabIndex = 113
        Me.toolTipHelp.SetToolTip(Me.txtDescr, "Indicare marca - grammatura - dimensioni")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "Reparto"
        '
        'chkOnlyRisMovimentate
        '
        Me.chkOnlyRisMovimentate.AutoSize = True
        Me.chkOnlyRisMovimentate.Location = New System.Drawing.Point(99, 216)
        Me.chkOnlyRisMovimentate.Name = "chkOnlyRisMovimentate"
        Me.chkOnlyRisMovimentate.Size = New System.Drawing.Size(198, 19)
        Me.chkOnlyRisMovimentate.TabIndex = 128
        Me.chkOnlyRisMovimentate.Text = "Solo Risorse già movimentate da"
        Me.chkOnlyRisMovimentate.UseVisualStyleBackColor = True
        '
        'cmbUtenti
        '
        Me.cmbUtenti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUtenti.FormattingEnabled = True
        Me.cmbUtenti.Location = New System.Drawing.Point(303, 214)
        Me.cmbUtenti.Name = "cmbUtenti"
        Me.cmbUtenti.Size = New System.Drawing.Size(175, 23)
        Me.cmbUtenti.TabIndex = 129
        '
        'ucMagazzinoCercaRisorsa
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.cmbUtenti)
        Me.Controls.Add(Me.chkOnlyRisMovimentate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lnkCerca)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rdoEtichette)
        Me.Controls.Add(Me.rdoPackaging)
        Me.Controls.Add(Me.rdoRicamo)
        Me.Controls.Add(Me.rdoDigitale)
        Me.Controls.Add(Me.rdoOffset)
        Me.Controls.Add(Me.rdoTutto)
        Me.Controls.Add(Me.cmbMacchinarioSel)
        Me.Controls.Add(Me.dgRisorseEx)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescr)
        Me.Name = "ucMagazzinoCercaRisorsa"
        Me.Size = New System.Drawing.Size(676, 472)
        CType(Me.cmbMacchinarioSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRisorseEx.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRisorseEx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbCategoria As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents rdoEtichette As RadioButton
    Friend WithEvents rdoPackaging As RadioButton
    Friend WithEvents rdoRicamo As RadioButton
    Friend WithEvents rdoDigitale As RadioButton
    Friend WithEvents rdoOffset As RadioButton
    Friend WithEvents rdoTutto As RadioButton
    Friend WithEvents cmbMacchinarioSel As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lnkCerca As LinkLabel
    Friend WithEvents dgRisorseEx As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescr As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkOnlyRisMovimentate As CheckBox
    Friend WithEvents cmbUtenti As ComboBox
End Class
