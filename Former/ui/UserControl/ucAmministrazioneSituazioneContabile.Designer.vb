<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSituazPagam
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
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpRiassunto = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotProntoStampa = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotIncassato = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotDaIncassareScaduto = New System.Windows.Forms.Label()
        Me.lblTotScopComples = New System.Windows.Forms.Label()
        Me.lblTotDaIncassare = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotDoc = New System.Windows.Forms.Label()
        Me.DgSituazNonScad = New System.Windows.Forms.DataGridView()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.chkOnlyNotPayd = New System.Windows.Forms.CheckBox()
        Me.menuVoce = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RegistraPagamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PassaAlloStatoDiConsegnatoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegnaComePagatoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatoIncassoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProblematicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DifficileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpossibileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkOnlyInCons = New System.Windows.Forms.CheckBox()
        Me.SplitContainerDoc = New System.Windows.Forms.SplitContainer()
        Me.gpScaduti = New System.Windows.Forms.GroupBox()
        Me.DgScad = New System.Windows.Forms.DataGridView()
        Me.GroupBoxDocNonScaduti = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLastEmail = New System.Windows.Forms.Label()
        Me.grpRiassunto.SuspendLayout()
        CType(Me.DgSituazNonScad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuVoce.SuspendLayout()
        CType(Me.SplitContainerDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerDoc.Panel1.SuspendLayout()
        Me.SplitContainerDoc.Panel2.SuspendLayout()
        Me.SplitContainerDoc.SuspendLayout()
        Me.gpScaduti.SuspendLayout()
        CType(Me.DgScad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxDocNonScaduti.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRiassunto
        '
        Me.grpRiassunto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpRiassunto.Controls.Add(Me.Label8)
        Me.grpRiassunto.Controls.Add(Me.Label6)
        Me.grpRiassunto.Controls.Add(Me.lblTotProntoStampa)
        Me.grpRiassunto.Controls.Add(Me.Label7)
        Me.grpRiassunto.Controls.Add(Me.Label3)
        Me.grpRiassunto.Controls.Add(Me.lblTotIncassato)
        Me.grpRiassunto.Controls.Add(Me.Label1)
        Me.grpRiassunto.Controls.Add(Me.lblTotDaIncassareScaduto)
        Me.grpRiassunto.Controls.Add(Me.lblTotScopComples)
        Me.grpRiassunto.Controls.Add(Me.lblTotDaIncassare)
        Me.grpRiassunto.Controls.Add(Me.Label5)
        Me.grpRiassunto.Controls.Add(Me.lblTotDoc)
        Me.grpRiassunto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grpRiassunto.Location = New System.Drawing.Point(3, 304)
        Me.grpRiassunto.Name = "grpRiassunto"
        Me.grpRiassunto.Size = New System.Drawing.Size(539, 111)
        Me.grpRiassunto.TabIndex = 69
        Me.grpRiassunto.TabStop = False
        Me.grpRiassunto.Text = "Riepilogo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(156, 15)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Totale scoperto complessivo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Totale Documenti:"
        '
        'lblTotProntoStampa
        '
        Me.lblTotProntoStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotProntoStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotProntoStampa.ForeColor = System.Drawing.Color.Red
        Me.lblTotProntoStampa.Location = New System.Drawing.Point(421, 77)
        Me.lblTotProntoStampa.Name = "lblTotProntoStampa"
        Me.lblTotProntoStampa.Size = New System.Drawing.Size(112, 15)
        Me.lblTotProntoStampa.TabIndex = 6
        Me.lblTotProntoStampa.Text = "0"
        Me.lblTotProntoStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolTipHelp.SetToolTip(Me.lblTotProntoStampa, "Totale Pronti Ritiro + Uscito da magazzino")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(5, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 15)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Totale Pronto Stampa"
        Me.toolTipHelp.SetToolTip(Me.Label7, "Totale Pronto Ritiro + Uscito Magazzino + In Consegna + Consegnato")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Totale da Incassare Documenti:"
        '
        'lblTotIncassato
        '
        Me.lblTotIncassato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotIncassato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotIncassato.ForeColor = System.Drawing.Color.Green
        Me.lblTotIncassato.Location = New System.Drawing.Point(421, 32)
        Me.lblTotIncassato.Name = "lblTotIncassato"
        Me.lblTotIncassato.Size = New System.Drawing.Size(112, 15)
        Me.lblTotIncassato.TabIndex = 3
        Me.lblTotIncassato.Text = "0"
        Me.lblTotIncassato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolTipHelp.SetToolTip(Me.lblTotIncassato, "Totale Incassato Documenti")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Totale da Incassare Documenti scaduto:"
        '
        'lblTotDaIncassareScaduto
        '
        Me.lblTotDaIncassareScaduto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotDaIncassareScaduto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDaIncassareScaduto.ForeColor = System.Drawing.Color.Red
        Me.lblTotDaIncassareScaduto.Location = New System.Drawing.Point(421, 62)
        Me.lblTotDaIncassareScaduto.Name = "lblTotDaIncassareScaduto"
        Me.lblTotDaIncassareScaduto.Size = New System.Drawing.Size(112, 15)
        Me.lblTotDaIncassareScaduto.TabIndex = 4
        Me.lblTotDaIncassareScaduto.Text = "0"
        Me.lblTotDaIncassareScaduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolTipHelp.SetToolTip(Me.lblTotDaIncassareScaduto, "Totale da Incassare Documenti scaduto")
        '
        'lblTotScopComples
        '
        Me.lblTotScopComples.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotScopComples.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotScopComples.ForeColor = System.Drawing.Color.Red
        Me.lblTotScopComples.Location = New System.Drawing.Point(421, 92)
        Me.lblTotScopComples.Name = "lblTotScopComples"
        Me.lblTotScopComples.Size = New System.Drawing.Size(112, 15)
        Me.lblTotScopComples.TabIndex = 6
        Me.lblTotScopComples.Text = "0"
        Me.lblTotScopComples.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolTipHelp.SetToolTip(Me.lblTotScopComples, "Totale scoperto complessivo")
        '
        'lblTotDaIncassare
        '
        Me.lblTotDaIncassare.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotDaIncassare.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDaIncassare.ForeColor = System.Drawing.Color.Red
        Me.lblTotDaIncassare.Location = New System.Drawing.Point(421, 47)
        Me.lblTotDaIncassare.Name = "lblTotDaIncassare"
        Me.lblTotDaIncassare.Size = New System.Drawing.Size(112, 15)
        Me.lblTotDaIncassare.TabIndex = 4
        Me.lblTotDaIncassare.Text = "0"
        Me.lblTotDaIncassare.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolTipHelp.SetToolTip(Me.lblTotDaIncassare, "Totale da Incassare Documenti")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(5, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Totale Incassato Documenti:"
        '
        'lblTotDoc
        '
        Me.lblTotDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotDoc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDoc.ForeColor = System.Drawing.Color.Green
        Me.lblTotDoc.Location = New System.Drawing.Point(421, 17)
        Me.lblTotDoc.Name = "lblTotDoc"
        Me.lblTotDoc.Size = New System.Drawing.Size(112, 15)
        Me.lblTotDoc.TabIndex = 7
        Me.lblTotDoc.Text = "0"
        Me.lblTotDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolTipHelp.SetToolTip(Me.lblTotDoc, "Totale Documenti")
        '
        'DgSituazNonScad
        '
        Me.DgSituazNonScad.AllowUserToAddRows = False
        Me.DgSituazNonScad.AllowUserToDeleteRows = False
        Me.DgSituazNonScad.AllowUserToResizeRows = False
        DataGridViewCellStyle31.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle31.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.Color.Black
        Me.DgSituazNonScad.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle31
        Me.DgSituazNonScad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgSituazNonScad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgSituazNonScad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgSituazNonScad.BackgroundColor = System.Drawing.Color.White
        Me.DgSituazNonScad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgSituazNonScad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgSituazNonScad.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle32
        Me.DgSituazNonScad.ColumnHeadersHeight = 20
        Me.DgSituazNonScad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSituazNonScad.DefaultCellStyle = DataGridViewCellStyle33
        Me.DgSituazNonScad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgSituazNonScad.EnableHeadersVisualStyles = False
        Me.DgSituazNonScad.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgSituazNonScad.Location = New System.Drawing.Point(6, 42)
        Me.DgSituazNonScad.MultiSelect = False
        Me.DgSituazNonScad.Name = "DgSituazNonScad"
        Me.DgSituazNonScad.ReadOnly = True
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSituazNonScad.RowHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.DgSituazNonScad.RowHeadersVisible = False
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle35.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.Color.Black
        Me.DgSituazNonScad.RowsDefaultCellStyle = DataGridViewCellStyle35
        Me.DgSituazNonScad.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgSituazNonScad.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgSituazNonScad.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgSituazNonScad.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSituazNonScad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgSituazNonScad.Size = New System.Drawing.Size(527, 88)
        Me.DgSituazNonScad.TabIndex = 68
        Me.DgSituazNonScad.TabStop = False
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(453, 13)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 26)
        Me.lnkStampa.TabIndex = 67
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkOnlyNotPayd
        '
        Me.chkOnlyNotPayd.AutoSize = True
        Me.chkOnlyNotPayd.BackColor = System.Drawing.Color.Red
        Me.chkOnlyNotPayd.Checked = True
        Me.chkOnlyNotPayd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOnlyNotPayd.ForeColor = System.Drawing.Color.White
        Me.chkOnlyNotPayd.Location = New System.Drawing.Point(6, 20)
        Me.chkOnlyNotPayd.Name = "chkOnlyNotPayd"
        Me.chkOnlyNotPayd.Size = New System.Drawing.Size(196, 19)
        Me.chkOnlyNotPayd.TabIndex = 70
        Me.chkOnlyNotPayd.Text = "Solo non completamente pagati"
        Me.chkOnlyNotPayd.UseVisualStyleBackColor = False
        '
        'menuVoce
        '
        Me.menuVoce.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaToolStripMenuItem, Me.EliminaToolStripMenuItem, Me.ToolStripSeparator2, Me.RegistraPagamentoToolStripMenuItem, Me.ToolStripSeparator3, Me.PassaAlloStatoDiConsegnatoToolStripMenuItem, Me.SegnaComePagatoToolStripMenuItem, Me.ToolStripSeparator1, Me.StatoIncassoToolStripMenuItem})
        Me.menuVoce.Name = "menuVoce"
        Me.menuVoce.Size = New System.Drawing.Size(205, 176)
        '
        'ModificaToolStripMenuItem
        '
        Me.ModificaToolStripMenuItem.Name = "ModificaToolStripMenuItem"
        Me.ModificaToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ModificaToolStripMenuItem.Text = "Modifica"
        '
        'EliminaToolStripMenuItem
        '
        Me.EliminaToolStripMenuItem.Name = "EliminaToolStripMenuItem"
        Me.EliminaToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.EliminaToolStripMenuItem.Text = "Elimina"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(201, 6)
        '
        'RegistraPagamentoToolStripMenuItem
        '
        Me.RegistraPagamentoToolStripMenuItem.Name = "RegistraPagamentoToolStripMenuItem"
        Me.RegistraPagamentoToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.RegistraPagamentoToolStripMenuItem.Text = "Registra pagamento"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(201, 6)
        '
        'PassaAlloStatoDiConsegnatoToolStripMenuItem
        '
        Me.PassaAlloStatoDiConsegnatoToolStripMenuItem.Name = "PassaAlloStatoDiConsegnatoToolStripMenuItem"
        Me.PassaAlloStatoDiConsegnatoToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.PassaAlloStatoDiConsegnatoToolStripMenuItem.Text = "Segna come consegnato"
        '
        'SegnaComePagatoToolStripMenuItem
        '
        Me.SegnaComePagatoToolStripMenuItem.Name = "SegnaComePagatoToolStripMenuItem"
        Me.SegnaComePagatoToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.SegnaComePagatoToolStripMenuItem.Text = "Segna come pagato"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(201, 6)
        '
        'StatoIncassoToolStripMenuItem
        '
        Me.StatoIncassoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NormaleToolStripMenuItem, Me.ProblematicoToolStripMenuItem, Me.DifficileToolStripMenuItem, Me.ImpossibileToolStripMenuItem})
        Me.StatoIncassoToolStripMenuItem.Image = Global.Former.My.Resources.Resources.coins
        Me.StatoIncassoToolStripMenuItem.Name = "StatoIncassoToolStripMenuItem"
        Me.StatoIncassoToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.StatoIncassoToolStripMenuItem.Text = "Stato Incasso"
        '
        'NormaleToolStripMenuItem
        '
        Me.NormaleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NormaleToolStripMenuItem.Name = "NormaleToolStripMenuItem"
        Me.NormaleToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.NormaleToolStripMenuItem.Text = "Normale"
        '
        'ProblematicoToolStripMenuItem
        '
        Me.ProblematicoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ProblematicoToolStripMenuItem.Name = "ProblematicoToolStripMenuItem"
        Me.ProblematicoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ProblematicoToolStripMenuItem.Text = "Problematico"
        '
        'DifficileToolStripMenuItem
        '
        Me.DifficileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DifficileToolStripMenuItem.Name = "DifficileToolStripMenuItem"
        Me.DifficileToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DifficileToolStripMenuItem.Text = "Difficile"
        '
        'ImpossibileToolStripMenuItem
        '
        Me.ImpossibileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ImpossibileToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.ImpossibileToolStripMenuItem.Name = "ImpossibileToolStripMenuItem"
        Me.ImpossibileToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ImpossibileToolStripMenuItem.Text = "Impossibile"
        '
        'chkOnlyInCons
        '
        Me.chkOnlyInCons.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkOnlyInCons.ForeColor = System.Drawing.Color.White
        Me.chkOnlyInCons.Location = New System.Drawing.Point(6, 18)
        Me.chkOnlyInCons.Name = "chkOnlyInCons"
        Me.chkOnlyInCons.Size = New System.Drawing.Size(125, 19)
        Me.chkOnlyInCons.TabIndex = 71
        Me.chkOnlyInCons.Text = "Solo in consegna"
        Me.chkOnlyInCons.UseVisualStyleBackColor = False
        '
        'SplitContainerDoc
        '
        Me.SplitContainerDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainerDoc.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainerDoc.Location = New System.Drawing.Point(3, 20)
        Me.SplitContainerDoc.Name = "SplitContainerDoc"
        Me.SplitContainerDoc.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerDoc.Panel1
        '
        Me.SplitContainerDoc.Panel1.Controls.Add(Me.gpScaduti)
        '
        'SplitContainerDoc.Panel2
        '
        Me.SplitContainerDoc.Panel2.Controls.Add(Me.GroupBoxDocNonScaduti)
        Me.SplitContainerDoc.Size = New System.Drawing.Size(539, 278)
        Me.SplitContainerDoc.SplitterDistance = 138
        Me.SplitContainerDoc.TabIndex = 72
        '
        'gpScaduti
        '
        Me.gpScaduti.BackColor = System.Drawing.Color.Transparent
        Me.gpScaduti.Controls.Add(Me.chkOnlyNotPayd)
        Me.gpScaduti.Controls.Add(Me.DgScad)
        Me.gpScaduti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpScaduti.Location = New System.Drawing.Point(0, 0)
        Me.gpScaduti.Name = "gpScaduti"
        Me.gpScaduti.Size = New System.Drawing.Size(539, 138)
        Me.gpScaduti.TabIndex = 74
        Me.gpScaduti.TabStop = False
        Me.gpScaduti.Text = "Documenti scaduti"
        '
        'DgScad
        '
        Me.DgScad.AllowUserToAddRows = False
        Me.DgScad.AllowUserToDeleteRows = False
        Me.DgScad.AllowUserToResizeRows = False
        DataGridViewCellStyle36.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle36.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.Black
        Me.DgScad.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle36
        Me.DgScad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgScad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgScad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgScad.BackgroundColor = System.Drawing.Color.White
        Me.DgScad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgScad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle37.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle37.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgScad.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle37
        Me.DgScad.ColumnHeadersHeight = 20
        Me.DgScad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle38.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle38.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle38.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle38.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgScad.DefaultCellStyle = DataGridViewCellStyle38
        Me.DgScad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgScad.EnableHeadersVisualStyles = False
        Me.DgScad.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgScad.Location = New System.Drawing.Point(6, 42)
        Me.DgScad.MultiSelect = False
        Me.DgScad.Name = "DgScad"
        Me.DgScad.ReadOnly = True
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle39.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle39.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgScad.RowHeadersDefaultCellStyle = DataGridViewCellStyle39
        Me.DgScad.RowHeadersVisible = False
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle40.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle40.SelectionForeColor = System.Drawing.Color.Black
        Me.DgScad.RowsDefaultCellStyle = DataGridViewCellStyle40
        Me.DgScad.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgScad.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgScad.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgScad.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgScad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgScad.Size = New System.Drawing.Size(527, 90)
        Me.DgScad.TabIndex = 68
        Me.DgScad.TabStop = False
        '
        'GroupBoxDocNonScaduti
        '
        Me.GroupBoxDocNonScaduti.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxDocNonScaduti.Controls.Add(Me.lnkStampa)
        Me.GroupBoxDocNonScaduti.Controls.Add(Me.chkOnlyInCons)
        Me.GroupBoxDocNonScaduti.Controls.Add(Me.DgSituazNonScad)
        Me.GroupBoxDocNonScaduti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxDocNonScaduti.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxDocNonScaduti.Name = "GroupBoxDocNonScaduti"
        Me.GroupBoxDocNonScaduti.Size = New System.Drawing.Size(539, 136)
        Me.GroupBoxDocNonScaduti.TabIndex = 73
        Me.GroupBoxDocNonScaduti.TabStop = False
        Me.GroupBoxDocNonScaduti.Text = "Documenti non scaduti"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(223, 15)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Ultimo resoconto inviato tramite email il "
        '
        'lblLastEmail
        '
        Me.lblLastEmail.BackColor = System.Drawing.Color.White
        Me.lblLastEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEmail.Location = New System.Drawing.Point(241, 2)
        Me.lblLastEmail.Name = "lblLastEmail"
        Me.lblLastEmail.Size = New System.Drawing.Size(112, 15)
        Me.lblLastEmail.TabIndex = 73
        Me.lblLastEmail.Text = "-"
        Me.lblLastEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ucSituazPagam
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gray
        Me.Controls.Add(Me.lblLastEmail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SplitContainerDoc)
        Me.Controls.Add(Me.grpRiassunto)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucSituazPagam"
        Me.Size = New System.Drawing.Size(545, 418)
        Me.grpRiassunto.ResumeLayout(False)
        Me.grpRiassunto.PerformLayout()
        CType(Me.DgSituazNonScad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuVoce.ResumeLayout(False)
        Me.SplitContainerDoc.Panel1.ResumeLayout(False)
        Me.SplitContainerDoc.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerDoc.ResumeLayout(False)
        Me.gpScaduti.ResumeLayout(False)
        Me.gpScaduti.PerformLayout()
        CType(Me.DgScad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxDocNonScaduti.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpRiassunto As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotDoc As System.Windows.Forms.Label
    Friend WithEvents lblTotScopComples As System.Windows.Forms.Label
    Friend WithEvents lblTotProntoStampa As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTotDaIncassare As System.Windows.Forms.Label
    Friend WithEvents lblTotIncassato As System.Windows.Forms.Label
    Friend WithEvents DgSituazNonScad As System.Windows.Forms.DataGridView
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents chkOnlyNotPayd As System.Windows.Forms.CheckBox
    Friend WithEvents menuVoce As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RegistraPagamentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PassaAlloStatoDiConsegnatoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SegnaComePagatoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkOnlyInCons As System.Windows.Forms.CheckBox
    Friend WithEvents SplitContainerDoc As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBoxDocNonScaduti As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotDaIncassareScaduto As System.Windows.Forms.Label
    Friend WithEvents gpScaduti As System.Windows.Forms.GroupBox
    Friend WithEvents DgScad As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLastEmail As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents StatoIncassoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NormaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProblematicoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DifficileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImpossibileToolStripMenuItem As ToolStripMenuItem
End Class
