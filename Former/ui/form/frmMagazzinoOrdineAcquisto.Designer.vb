<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMagazzinoOrdineAcquisto
    Inherits baseFormInternaRedim

    'Form overrides dispose to clean up the component list.
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
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnStampa = New Former.ucLinkLabel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnAddRichiesta = New System.Windows.Forms.Button()
        Me.btnDelRichiesta = New System.Windows.Forms.Button()
        Me.DgMovimenti = New Telerik.WinControls.UI.RadGridView()
        Me.txtAnnotazioni = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtQuando = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.DgMovimenti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgMovimenti.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnStampa)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 611)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnStampa
        '
        Me.btnStampa.BackColor = System.Drawing.Color.White
        Me.btnStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnStampa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampa.Image = Global.Former.My.Resources.Resources.print
        Me.btnStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampa.Location = New System.Drawing.Point(6, 11)
        Me.btnStampa.Name = "btnStampa"
        Me.btnStampa.RoundedBorder = False
        Me.btnStampa.Size = New System.Drawing.Size(78, 34)
        Me.btnStampa.TabIndex = 22
        Me.btnStampa.TabStop = True
        Me.btnStampa.Text = "Stampa"
        Me.btnStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(871, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(789, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(76, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 611)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnAddRichiesta)
        Me.tbProd.Controls.Add(Me.btnDelRichiesta)
        Me.tbProd.Controls.Add(Me.DgMovimenti)
        Me.tbProd.Controls.Add(Me.txtAnnotazioni)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.dtQuando)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 585)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Ordine di acquisto"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnAddRichiesta
        '
        Me.btnAddRichiesta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddRichiesta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAddRichiesta.FlatAppearance.BorderSize = 0
        Me.btnAddRichiesta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddRichiesta.ForeColor = System.Drawing.Color.Black
        Me.btnAddRichiesta.Image = Global.Former.My.Resources.Resources.plus
        Me.btnAddRichiesta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddRichiesta.Location = New System.Drawing.Point(758, 540)
        Me.btnAddRichiesta.Name = "btnAddRichiesta"
        Me.btnAddRichiesta.Size = New System.Drawing.Size(91, 30)
        Me.btnAddRichiesta.TabIndex = 104
        Me.btnAddRichiesta.Text = "Aggiungi"
        Me.btnAddRichiesta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddRichiesta.UseVisualStyleBackColor = True
        '
        'btnDelRichiesta
        '
        Me.btnDelRichiesta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelRichiesta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDelRichiesta.FlatAppearance.BorderSize = 0
        Me.btnDelRichiesta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelRichiesta.ForeColor = System.Drawing.Color.Black
        Me.btnDelRichiesta.Image = Global.Former.My.Resources.Resources.minus
        Me.btnDelRichiesta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelRichiesta.Location = New System.Drawing.Point(855, 540)
        Me.btnDelRichiesta.Name = "btnDelRichiesta"
        Me.btnDelRichiesta.Size = New System.Drawing.Size(84, 30)
        Me.btnDelRichiesta.TabIndex = 105
        Me.btnDelRichiesta.Text = "Elimina"
        Me.btnDelRichiesta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelRichiesta.UseVisualStyleBackColor = True
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
        Me.DgMovimenti.Location = New System.Drawing.Point(140, 254)
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
        GridViewTextBoxColumn1.FieldName = "DataMov"
        GridViewTextBoxColumn1.HeaderText = "Data Richiesta"
        GridViewTextBoxColumn1.Name = "Data"
        GridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn1.Width = 120
        GridViewTextBoxColumn2.FieldName = "UrgenteStr"
        GridViewTextBoxColumn2.HeaderText = "Urgente"
        GridViewTextBoxColumn2.Name = "Urgente"
        GridViewTextBoxColumn3.FieldName = "Qta"
        GridViewTextBoxColumn3.HeaderText = "Q.ta"
        GridViewTextBoxColumn3.Name = "Qta"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 70
        GridViewTextBoxColumn4.FieldName = "RisorsaStr"
        GridViewTextBoxColumn4.HeaderText = "Risorsa"
        GridViewTextBoxColumn4.Name = "Risorsa"
        GridViewTextBoxColumn4.Width = 300
        GridViewTextBoxColumn5.FieldName = "FornitoreStr"
        GridViewTextBoxColumn5.HeaderText = "Fornitore Scelto"
        GridViewTextBoxColumn5.Name = "Fornitore"
        GridViewTextBoxColumn5.Width = 150
        GridViewTextBoxColumn6.FieldName = "UltimoFornStr"
        GridViewTextBoxColumn6.HeaderText = "Ultimo Fornitore"
        GridViewTextBoxColumn6.Name = "UltimoForn"
        GridViewTextBoxColumn6.Width = 150
        GridViewTextBoxColumn7.FieldName = "OperatoreStr"
        GridViewTextBoxColumn7.HeaderText = "Operatore"
        GridViewTextBoxColumn7.Name = "OperatoreStr"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn7.Width = 100
        Me.DgMovimenti.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7})
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
        Me.DgMovimenti.Size = New System.Drawing.Size(799, 280)
        Me.DgMovimenti.TabIndex = 85
        Me.DgMovimenti.ThemeName = "VisualStudio2012Light"
        '
        'txtAnnotazioni
        '
        Me.txtAnnotazioni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAnnotazioni.Location = New System.Drawing.Point(140, 104)
        Me.txtAnnotazioni.Multiline = True
        Me.txtAnnotazioni.Name = "txtAnnotazioni"
        Me.txtAnnotazioni.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAnnotazioni.Size = New System.Drawing.Size(799, 129)
        Me.txtAnnotazioni.TabIndex = 84
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(52, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Annotazioni"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(52, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Richieste"
        '
        'dtQuando
        '
        Me.dtQuando.Location = New System.Drawing.Point(140, 66)
        Me.dtQuando.Name = "dtQuando"
        Me.dtQuando.Size = New System.Drawing.Size(213, 20)
        Me.dtQuando.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(52, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Data"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._OrdineAcquisto
        Me.pctTipo.Location = New System.Drawing.Point(8, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 16
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(51, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(163, 22)
        Me.lblTipo.TabIndex = 15
        Me.lblTipo.Text = "Ordine di acquisto"
        '
        'frmMagazzinoOrdineAcquisto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 659)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMagazzinoOrdineAcquisto"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Ordine di acquisto"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.DgMovimenti.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgMovimenti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As PictureBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtQuando As DateTimePicker
    Friend WithEvents txtAnnotazioni As TextBox
    Friend WithEvents DgMovimenti As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnStampa As ucLinkLabel
    Friend WithEvents btnAddRichiesta As Button
    Friend WithEvents btnDelRichiesta As Button
End Class
