<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazioneSituazioneContabileEx
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpRiassunto = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotProntoStampa = New System.Windows.Forms.Label()
        Me.lblTotIncassato = New System.Windows.Forms.Label()
        Me.lblTotDaIncassareScaduto = New System.Windows.Forms.Label()
        Me.lblTotScopComples = New System.Windows.Forms.Label()
        Me.lblTotDaIncassare = New System.Windows.Forms.Label()
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
        Me.grpRiassunto.Controls.Add(Me.Label7)
        Me.grpRiassunto.Controls.Add(Me.Label3)
        Me.grpRiassunto.Controls.Add(Me.Label1)
        Me.grpRiassunto.Controls.Add(Me.Label5)
        Me.grpRiassunto.Controls.Add(Me.lblTotProntoStampa)
        Me.grpRiassunto.Controls.Add(Me.lblTotIncassato)
        Me.grpRiassunto.Controls.Add(Me.lblTotDaIncassareScaduto)
        Me.grpRiassunto.Controls.Add(Me.lblTotScopComples)
        Me.grpRiassunto.Controls.Add(Me.lblTotDaIncassare)
        Me.grpRiassunto.Controls.Add(Me.lblTotDoc)
        Me.grpRiassunto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grpRiassunto.Location = New System.Drawing.Point(3, 376)
        Me.grpRiassunto.Name = "grpRiassunto"
        Me.grpRiassunto.Size = New System.Drawing.Size(1140, 39)
        Me.grpRiassunto.TabIndex = 69
        Me.grpRiassunto.TabStop = False
        Me.grpRiassunto.Text = "Riepilogo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(958, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(157, 15)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Totale scoperto complessivo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Totale Documenti:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(766, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 15)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Totale da fatturare"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(386, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Totale da Incassare:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(588, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Totale Scaduto:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(199, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Totale Incassato:"
        '
        'lblTotProntoStampa
        '
        Me.lblTotProntoStampa.BackColor = System.Drawing.Color.Transparent
        Me.lblTotProntoStampa.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotProntoStampa.ForeColor = System.Drawing.Color.Red
        Me.lblTotProntoStampa.Location = New System.Drawing.Point(877, 17)
        Me.lblTotProntoStampa.Name = "lblTotProntoStampa"
        Me.lblTotProntoStampa.Size = New System.Drawing.Size(75, 16)
        Me.lblTotProntoStampa.TabIndex = 6
        Me.lblTotProntoStampa.Text = "0,00"
        Me.lblTotProntoStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotIncassato
        '
        Me.lblTotIncassato.BackColor = System.Drawing.Color.Transparent
        Me.lblTotIncassato.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotIncassato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotIncassato.Location = New System.Drawing.Point(305, 15)
        Me.lblTotIncassato.Name = "lblTotIncassato"
        Me.lblTotIncassato.Size = New System.Drawing.Size(75, 16)
        Me.lblTotIncassato.TabIndex = 3
        Me.lblTotIncassato.Text = "0,00"
        Me.lblTotIncassato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotDaIncassareScaduto
        '
        Me.lblTotDaIncassareScaduto.BackColor = System.Drawing.Color.Transparent
        Me.lblTotDaIncassareScaduto.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDaIncassareScaduto.ForeColor = System.Drawing.Color.Red
        Me.lblTotDaIncassareScaduto.Location = New System.Drawing.Point(685, 16)
        Me.lblTotDaIncassareScaduto.Name = "lblTotDaIncassareScaduto"
        Me.lblTotDaIncassareScaduto.Size = New System.Drawing.Size(75, 16)
        Me.lblTotDaIncassareScaduto.TabIndex = 4
        Me.lblTotDaIncassareScaduto.Text = "0,00"
        Me.lblTotDaIncassareScaduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotScopComples
        '
        Me.lblTotScopComples.BackColor = System.Drawing.Color.Transparent
        Me.lblTotScopComples.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotScopComples.ForeColor = System.Drawing.Color.Red
        Me.lblTotScopComples.Location = New System.Drawing.Point(1128, 16)
        Me.lblTotScopComples.Name = "lblTotScopComples"
        Me.lblTotScopComples.Size = New System.Drawing.Size(75, 16)
        Me.lblTotScopComples.TabIndex = 6
        Me.lblTotScopComples.Text = "0,00"
        Me.lblTotScopComples.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotDaIncassare
        '
        Me.lblTotDaIncassare.BackColor = System.Drawing.Color.Transparent
        Me.lblTotDaIncassare.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDaIncassare.ForeColor = System.Drawing.Color.Red
        Me.lblTotDaIncassare.Location = New System.Drawing.Point(507, 16)
        Me.lblTotDaIncassare.Name = "lblTotDaIncassare"
        Me.lblTotDaIncassare.Size = New System.Drawing.Size(75, 16)
        Me.lblTotDaIncassare.TabIndex = 4
        Me.lblTotDaIncassare.Text = "0,00"
        Me.lblTotDaIncassare.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotDoc
        '
        Me.lblTotDoc.BackColor = System.Drawing.Color.Transparent
        Me.lblTotDoc.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotDoc.Location = New System.Drawing.Point(118, 15)
        Me.lblTotDoc.Name = "lblTotDoc"
        Me.lblTotDoc.Size = New System.Drawing.Size(75, 16)
        Me.lblTotDoc.TabIndex = 7
        Me.lblTotDoc.Text = "0,00"
        Me.lblTotDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgSituazNonScad
        '
        Me.DgSituazNonScad.AllowUserToAddRows = False
        Me.DgSituazNonScad.AllowUserToDeleteRows = False
        Me.DgSituazNonScad.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgSituazNonScad.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgSituazNonScad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgSituazNonScad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgSituazNonScad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgSituazNonScad.BackgroundColor = System.Drawing.Color.White
        Me.DgSituazNonScad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgSituazNonScad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgSituazNonScad.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgSituazNonScad.ColumnHeadersHeight = 20
        Me.DgSituazNonScad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSituazNonScad.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgSituazNonScad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgSituazNonScad.EnableHeadersVisualStyles = False
        Me.DgSituazNonScad.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgSituazNonScad.Location = New System.Drawing.Point(6, 42)
        Me.DgSituazNonScad.MultiSelect = False
        Me.DgSituazNonScad.Name = "DgSituazNonScad"
        Me.DgSituazNonScad.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSituazNonScad.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgSituazNonScad.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgSituazNonScad.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgSituazNonScad.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgSituazNonScad.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgSituazNonScad.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgSituazNonScad.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgSituazNonScad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgSituazNonScad.Size = New System.Drawing.Size(1126, 117)
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
        Me.lnkStampa.Location = New System.Drawing.Point(1054, 13)
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
        Me.menuVoce.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaToolStripMenuItem, Me.EliminaToolStripMenuItem, Me.ToolStripSeparator2, Me.RegistraPagamentoToolStripMenuItem, Me.ToolStripSeparator3, Me.PassaAlloStatoDiConsegnatoToolStripMenuItem, Me.SegnaComePagatoToolStripMenuItem})
        Me.menuVoce.Name = "menuVoce"
        Me.menuVoce.Size = New System.Drawing.Size(205, 126)
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
        Me.SplitContainerDoc.Size = New System.Drawing.Size(1140, 353)
        Me.SplitContainerDoc.SplitterDistance = 184
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
        Me.gpScaduti.Size = New System.Drawing.Size(1140, 184)
        Me.gpScaduti.TabIndex = 74
        Me.gpScaduti.TabStop = False
        Me.gpScaduti.Text = "Documenti scaduti"
        '
        'DgScad
        '
        Me.DgScad.AllowUserToAddRows = False
        Me.DgScad.AllowUserToDeleteRows = False
        Me.DgScad.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgScad.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgScad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgScad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgScad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgScad.BackgroundColor = System.Drawing.Color.White
        Me.DgScad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgScad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgScad.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DgScad.ColumnHeadersHeight = 20
        Me.DgScad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgScad.DefaultCellStyle = DataGridViewCellStyle8
        Me.DgScad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgScad.EnableHeadersVisualStyles = False
        Me.DgScad.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgScad.Location = New System.Drawing.Point(6, 42)
        Me.DgScad.MultiSelect = False
        Me.DgScad.Name = "DgScad"
        Me.DgScad.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgScad.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DgScad.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DgScad.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DgScad.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgScad.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgScad.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgScad.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgScad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgScad.Size = New System.Drawing.Size(1128, 136)
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
        Me.GroupBoxDocNonScaduti.Size = New System.Drawing.Size(1140, 165)
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
        'ucAmministrazioneSituazioneContabileEx
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gray
        Me.Controls.Add(Me.lblLastEmail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SplitContainerDoc)
        Me.Controls.Add(Me.grpRiassunto)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucAmministrazioneSituazioneContabileEx"
        Me.Size = New System.Drawing.Size(1146, 418)
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

End Class
