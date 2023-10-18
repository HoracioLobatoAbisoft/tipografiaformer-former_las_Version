<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAmministrazioneSituazioneClienti
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
        Me.components = New System.ComponentModel.Container()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucAmministrazioneSituazioneClienti))
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.DgClienti = New Telerik.WinControls.UI.RadGridView()
        Me.TabAnteprima = New System.Windows.Forms.TabControl()
        Me.tpContabile = New System.Windows.Forms.TabPage()
        Me.UcSituazPagam = New Former.ucSituazPagam()
        Me.tpDocumenti = New System.Windows.Forms.TabPage()
        Me.UcDocumentiFiscali = New Former.ucDocumentiFiscali()
        Me.tpLavori = New System.Windows.Forms.TabPage()
        Me.UcOrdini = New Former.ucOrdini()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbStatoIncasso = New System.Windows.Forms.ComboBox()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        CType(Me.DgClienti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgClienti.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAnteprima.SuspendLayout()
        Me.tpContabile.SuspendLayout()
        Me.tpDocumenti.SuspendLayout()
        Me.tpLavori.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.AutoSize = True
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(231, 3)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAggiorna.Size = New System.Drawing.Size(86, 27)
        Me.lnkAggiorna.TabIndex = 63
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgClienti
        '
        Me.DgClienti.AutoScroll = True
        Me.DgClienti.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.DgClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgClienti.EnableGestures = False
        Me.DgClienti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgClienti.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.DgClienti.MasterTemplate.AllowAddNewRow = False
        Me.DgClienti.MasterTemplate.AllowCellContextMenu = False
        Me.DgClienti.MasterTemplate.AllowColumnChooser = False
        Me.DgClienti.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.DgClienti.MasterTemplate.AllowDeleteRow = False
        Me.DgClienti.MasterTemplate.AllowDragToGroup = False
        Me.DgClienti.MasterTemplate.AllowEditRow = False
        Me.DgClienti.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.DgClienti.MasterTemplate.AllowRowResize = False
        Me.DgClienti.MasterTemplate.AllowSearchRow = True
        Me.DgClienti.MasterTemplate.AutoGenerateColumns = False
        Me.DgClienti.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewTextBoxColumn1.FieldName = "RagSocNome"
        GridViewTextBoxColumn1.HeaderText = "Cliente"
        GridViewTextBoxColumn1.MaxWidth = 500
        GridViewTextBoxColumn1.Name = "Cliente"
        GridViewTextBoxColumn1.Width = 146
        GridViewTextBoxColumn2.FieldName = "TotaleDocumenti"
        GridViewTextBoxColumn2.FormatInfo = New System.Globalization.CultureInfo("it-IT")
        GridViewTextBoxColumn2.FormatString = "{0:C}"
        GridViewTextBoxColumn2.HeaderText = "Totale Documenti"
        GridViewTextBoxColumn2.MaxWidth = 128
        GridViewTextBoxColumn2.MinWidth = 128
        GridViewTextBoxColumn2.Name = "TotaleDocumenti"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn2.Width = 128
        GridViewTextBoxColumn3.FieldName = "TotaleProntoStampa"
        GridViewTextBoxColumn3.FormatInfo = New System.Globalization.CultureInfo("it-IT")
        GridViewTextBoxColumn3.FormatString = "{0:C}"
        GridViewTextBoxColumn3.HeaderText = "Totale Pronto Stampa"
        GridViewTextBoxColumn3.MaxWidth = 128
        GridViewTextBoxColumn3.MinWidth = 128
        GridViewTextBoxColumn3.Name = "TotaleProntoStampa"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 128
        GridViewTextBoxColumn4.FieldName = "DataUltimoLavoro"
        GridViewTextBoxColumn4.FormatInfo = New System.Globalization.CultureInfo("it-IT")
        GridViewTextBoxColumn4.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn4.HeaderText = "Ultimo Lavoro"
        GridViewTextBoxColumn4.MaxWidth = 128
        GridViewTextBoxColumn4.MinWidth = 128
        GridViewTextBoxColumn4.Name = "DataUltimoLavoro"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 128
        GridViewTextBoxColumn5.FieldName = "DataUltimoPagamento"
        GridViewTextBoxColumn5.FormatInfo = New System.Globalization.CultureInfo("it-IT")
        GridViewTextBoxColumn5.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn5.HeaderText = "Ultimo Pagamento"
        GridViewTextBoxColumn5.MaxWidth = 128
        GridViewTextBoxColumn5.MinWidth = 128
        GridViewTextBoxColumn5.Name = "DataUltimoPagamento"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 128
        GridViewTextBoxColumn6.FieldName = "TotaleScopertoComplessivo"
        GridViewTextBoxColumn6.FormatInfo = New System.Globalization.CultureInfo("it-IT")
        GridViewTextBoxColumn6.FormatString = "{0:C}"
        GridViewTextBoxColumn6.HeaderText = "Scoperto Complessivo"
        GridViewTextBoxColumn6.MaxWidth = 128
        GridViewTextBoxColumn6.MinWidth = 128
        GridViewTextBoxColumn6.Name = "TotaleScopertoComplessivo"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 128
        Me.DgClienti.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.DgClienti.MasterTemplate.EnableAlternatingRowColor = True
        Me.DgClienti.MasterTemplate.EnableGrouping = False
        Me.DgClienti.MasterTemplate.MultiSelect = True
        Me.DgClienti.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgClienti.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.DgClienti.Name = "DgClienti"
        Me.DgClienti.ReadOnly = True
        Me.DgClienti.ShowGroupPanel = False
        Me.DgClienti.ShowGroupPanelScrollbars = False
        Me.DgClienti.ShowNoDataText = False
        Me.DgClienti.Size = New System.Drawing.Size(780, 551)
        Me.DgClienti.TabIndex = 64
        Me.DgClienti.ThemeName = "VisualStudio2012Light"
        '
        'TabAnteprima
        '
        Me.TabAnteprima.Controls.Add(Me.tpContabile)
        Me.TabAnteprima.Controls.Add(Me.tpDocumenti)
        Me.TabAnteprima.Controls.Add(Me.tpLavori)
        Me.TabAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabAnteprima.ImageList = Me.imlTab
        Me.TabAnteprima.Location = New System.Drawing.Point(0, 0)
        Me.TabAnteprima.Name = "TabAnteprima"
        Me.TabAnteprima.SelectedIndex = 0
        Me.TabAnteprima.Size = New System.Drawing.Size(356, 551)
        Me.TabAnteprima.TabIndex = 65
        '
        'tpContabile
        '
        Me.tpContabile.Controls.Add(Me.UcSituazPagam)
        Me.tpContabile.ImageKey = "_Billing.png"
        Me.tpContabile.Location = New System.Drawing.Point(4, 27)
        Me.tpContabile.Name = "tpContabile"
        Me.tpContabile.Padding = New System.Windows.Forms.Padding(3)
        Me.tpContabile.Size = New System.Drawing.Size(348, 520)
        Me.tpContabile.TabIndex = 0
        Me.tpContabile.Text = "Contabile"
        Me.tpContabile.UseVisualStyleBackColor = True
        '
        'UcSituazPagam
        '
        Me.UcSituazPagam.BackColor = System.Drawing.Color.White
        Me.UcSituazPagam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSituazPagam.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcSituazPagam.IdRub = 0
        Me.UcSituazPagam.Location = New System.Drawing.Point(3, 3)
        Me.UcSituazPagam.Name = "UcSituazPagam"
        Me.UcSituazPagam.Size = New System.Drawing.Size(342, 514)
        Me.UcSituazPagam.TabIndex = 0
        '
        'tpDocumenti
        '
        Me.tpDocumenti.Controls.Add(Me.UcDocumentiFiscali)
        Me.tpDocumenti.ImageKey = "_DocumentoFiscale.png"
        Me.tpDocumenti.Location = New System.Drawing.Point(4, 22)
        Me.tpDocumenti.Name = "tpDocumenti"
        Me.tpDocumenti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDocumenti.Size = New System.Drawing.Size(192, 74)
        Me.tpDocumenti.TabIndex = 1
        Me.tpDocumenti.Text = "Documenti"
        Me.tpDocumenti.UseVisualStyleBackColor = True
        '
        'UcDocumentiFiscali
        '
        Me.UcDocumentiFiscali.BackColor = System.Drawing.Color.White
        Me.UcDocumentiFiscali.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcDocumentiFiscali.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcDocumentiFiscali.IdRub = 0
        Me.UcDocumentiFiscali.Location = New System.Drawing.Point(3, 3)
        Me.UcDocumentiFiscali.Name = "UcDocumentiFiscali"
        Me.UcDocumentiFiscali.Size = New System.Drawing.Size(186, 68)
        Me.UcDocumentiFiscali.TabIndex = 0
        '
        'tpLavori
        '
        Me.tpLavori.Controls.Add(Me.UcOrdini)
        Me.tpLavori.ImageKey = "_Ordine.png"
        Me.tpLavori.Location = New System.Drawing.Point(4, 22)
        Me.tpLavori.Name = "tpLavori"
        Me.tpLavori.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLavori.Size = New System.Drawing.Size(192, 74)
        Me.tpLavori.TabIndex = 2
        Me.tpLavori.Text = "Lavori"
        Me.tpLavori.UseVisualStyleBackColor = True
        '
        'UcOrdini
        '
        Me.UcOrdini.BackColor = System.Drawing.Color.White
        Me.UcOrdini.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrdini.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdini.IdRub = 0
        Me.UcOrdini.Location = New System.Drawing.Point(3, 3)
        Me.UcOrdini.Name = "UcOrdini"
        Me.UcOrdini.Size = New System.Drawing.Size(186, 68)
        Me.UcOrdini.TabIndex = 0
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "_Billing.png")
        Me.imlTab.Images.SetKeyName(1, "_DocumentoFiscale.png")
        Me.imlTab.Images.SetKeyName(2, "_Ordine.png")
        '
        'SplitContainer
        '
        Me.SplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer.Location = New System.Drawing.Point(3, 33)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.DgClienti)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.TabAnteprima)
        Me.SplitContainer.Size = New System.Drawing.Size(1140, 551)
        Me.SplitContainer.SplitterDistance = 780
        Me.SplitContainer.TabIndex = 66
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(3, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Stato Incasso"
        '
        'cmbStatoIncasso
        '
        Me.cmbStatoIncasso.DisplayMember = "AnnoRif"
        Me.cmbStatoIncasso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatoIncasso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbStatoIncasso.FormattingEnabled = True
        Me.cmbStatoIncasso.Location = New System.Drawing.Point(85, 6)
        Me.cmbStatoIncasso.Name = "cmbStatoIncasso"
        Me.cmbStatoIncasso.Size = New System.Drawing.Size(131, 23)
        Me.cmbStatoIncasso.TabIndex = 72
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.AutoSize = True
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(1066, 3)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkStampa.Size = New System.Drawing.Size(77, 27)
        Me.lnkStampa.TabIndex = 109
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucAmministrazioneSituazioneClienti
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbStatoIncasso)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.lnkAggiorna)
        Me.Name = "ucAmministrazioneSituazioneClienti"
        Me.Size = New System.Drawing.Size(1146, 587)
        CType(Me.DgClienti.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgClienti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAnteprima.ResumeLayout(False)
        Me.tpContabile.ResumeLayout(False)
        Me.tpDocumenti.ResumeLayout(False)
        Me.tpLavori.ResumeLayout(False)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lnkAggiorna As LinkLabel
    Friend WithEvents DgClienti As Telerik.WinControls.UI.RadGridView
    Friend WithEvents TabAnteprima As TabControl
    Friend WithEvents tpContabile As TabPage
    Friend WithEvents tpDocumenti As TabPage
    Friend WithEvents imlTab As ImageList
    Friend WithEvents UcSituazPagam As ucSituazPagam
    Friend WithEvents UcDocumentiFiscali As ucDocumentiFiscali
    Friend WithEvents tpLavori As TabPage
    Friend WithEvents UcOrdini As ucOrdini
    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbStatoIncasso As ComboBox
    Friend WithEvents lnkStampa As LinkLabel
End Class
