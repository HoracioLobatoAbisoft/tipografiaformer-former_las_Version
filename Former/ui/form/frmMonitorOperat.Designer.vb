<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitorOperatore
    Inherits baseFormInternaFixed

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitorOperatore))
        Me.tmrOper = New System.Windows.Forms.Timer(Me.components)
        Me.webMonitor = New System.Windows.Forms.WebBrowser()
        Me.lblOperatore = New System.Windows.Forms.Label()
        Me.lblNotWork = New System.Windows.Forms.Label()
        Me.lblLavAperte = New System.Windows.Forms.Label()
        Me.lblDettAnteprima = New System.Windows.Forms.Label()
        Me.lblReparto = New System.Windows.Forms.Label()
        Me.pnlAnteprima = New System.Windows.Forms.Panel()
        Me.pctAnteprima = New System.Windows.Forms.PictureBox()
        Me.lblOperatAnte = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.tmrAnteprima = New System.Windows.Forms.Timer(Me.components)
        Me.tmrLabel = New System.Windows.Forms.Timer(Me.components)
        Me.tmrOraCorrente = New System.Windows.Forms.Timer(Me.components)
        Me.lblLavorazDisp = New System.Windows.Forms.Label()
        Me.DgLavoriAperti = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgLavoriInCoda = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlAnteprima.SuspendLayout()
        CType(Me.pctAnteprima, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgLavoriAperti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgLavoriInCoda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrOper
        '
        Me.tmrOper.Interval = 300000
        '
        'webMonitor
        '
        Me.webMonitor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webMonitor.Location = New System.Drawing.Point(193, 43)
        Me.webMonitor.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webMonitor.Name = "webMonitor"
        Me.webMonitor.Size = New System.Drawing.Size(615, 305)
        Me.webMonitor.TabIndex = 1
        Me.webMonitor.TabStop = False
        '
        'lblOperatore
        '
        Me.lblOperatore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOperatore.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOperatore.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblOperatore.ForeColor = System.Drawing.Color.Black
        Me.lblOperatore.Location = New System.Drawing.Point(193, 0)
        Me.lblOperatore.Name = "lblOperatore"
        Me.lblOperatore.Size = New System.Drawing.Size(615, 43)
        Me.lblOperatore.TabIndex = 2
        Me.lblOperatore.Text = "-"
        Me.lblOperatore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNotWork
        '
        Me.lblNotWork.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotWork.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblNotWork.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblNotWork.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.lblNotWork.Location = New System.Drawing.Point(0, 405)
        Me.lblNotWork.Name = "lblNotWork"
        Me.lblNotWork.Size = New System.Drawing.Size(1003, 39)
        Me.lblNotWork.TabIndex = 3
        Me.lblNotWork.Text = "-"
        Me.lblNotWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLavAperte
        '
        Me.lblLavAperte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLavAperte.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblLavAperte.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblLavAperte.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.lblLavAperte.Location = New System.Drawing.Point(808, 0)
        Me.lblLavAperte.Name = "lblLavAperte"
        Me.lblLavAperte.Size = New System.Drawing.Size(195, 43)
        Me.lblLavAperte.TabIndex = 4
        Me.lblLavAperte.Text = "Lavorazioni Aperte: - "
        Me.lblLavAperte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDettAnteprima
        '
        Me.lblDettAnteprima.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDettAnteprima.AutoEllipsis = True
        Me.lblDettAnteprima.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDettAnteprima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDettAnteprima.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.lblDettAnteprima.Location = New System.Drawing.Point(497, 4)
        Me.lblDettAnteprima.Name = "lblDettAnteprima"
        Me.lblDettAnteprima.Size = New System.Drawing.Size(119, 50)
        Me.lblDettAnteprima.TabIndex = 30
        Me.lblDettAnteprima.Text = "-"
        Me.lblDettAnteprima.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReparto
        '
        Me.lblReparto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblReparto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReparto.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.lblReparto.Location = New System.Drawing.Point(128, 4)
        Me.lblReparto.Name = "lblReparto"
        Me.lblReparto.Size = New System.Drawing.Size(292, 50)
        Me.lblReparto.TabIndex = 31
        Me.lblReparto.Text = "FINITURA SU COMMESSA"
        Me.lblReparto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAnteprima
        '
        Me.pnlAnteprima.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAnteprima.BackColor = System.Drawing.Color.White
        Me.pnlAnteprima.Controls.Add(Me.pctAnteprima)
        Me.pnlAnteprima.Controls.Add(Me.lblOperatAnte)
        Me.pnlAnteprima.Controls.Add(Me.lblTime)
        Me.pnlAnteprima.Controls.Add(Me.PictureBox1)
        Me.pnlAnteprima.Controls.Add(Me.PictureBox2)
        Me.pnlAnteprima.Controls.Add(Me.lblDettAnteprima)
        Me.pnlAnteprima.Controls.Add(Me.lblReparto)
        Me.pnlAnteprima.Location = New System.Drawing.Point(0, 348)
        Me.pnlAnteprima.Name = "pnlAnteprima"
        Me.pnlAnteprima.Size = New System.Drawing.Size(1003, 57)
        Me.pnlAnteprima.TabIndex = 32
        '
        'pctAnteprima
        '
        Me.pctAnteprima.Location = New System.Drawing.Point(424, 4)
        Me.pctAnteprima.Name = "pctAnteprima"
        Me.pctAnteprima.Size = New System.Drawing.Size(67, 50)
        Me.pctAnteprima.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnteprima.TabIndex = 36
        Me.pctAnteprima.TabStop = False
        '
        'lblOperatAnte
        '
        Me.lblOperatAnte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOperatAnte.AutoEllipsis = True
        Me.lblOperatAnte.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOperatAnte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOperatAnte.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.lblOperatAnte.Image = Global.Former.My.Resources.user
        Me.lblOperatAnte.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblOperatAnte.Location = New System.Drawing.Point(622, 4)
        Me.lblOperatAnte.Name = "lblOperatAnte"
        Me.lblOperatAnte.Size = New System.Drawing.Size(186, 50)
        Me.lblOperatAnte.TabIndex = 35
        Me.lblOperatAnte.Text = "-"
        Me.lblOperatAnte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTime
        '
        Me.lblTime.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(37, 12)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(85, 37)
        Me.lblTime.TabIndex = 34
        Me.lblTime.Text = "00:00"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.clock
        Me.PictureBox1.Location = New System.Drawing.Point(3, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.Former.My.Resources.logo
        Me.PictureBox2.Location = New System.Drawing.Point(814, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(185, 46)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 32
        Me.PictureBox2.TabStop = False
        '
        'tmrAnteprima
        '
        Me.tmrAnteprima.Interval = 30000
        '
        'tmrLabel
        '
        Me.tmrLabel.Interval = 5000
        '
        'tmrOraCorrente
        '
        Me.tmrOraCorrente.Interval = 1000
        '
        'lblLavorazDisp
        '
        Me.lblLavorazDisp.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblLavorazDisp.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblLavorazDisp.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.lblLavorazDisp.Location = New System.Drawing.Point(0, 0)
        Me.lblLavorazDisp.Name = "lblLavorazDisp"
        Me.lblLavorazDisp.Size = New System.Drawing.Size(193, 43)
        Me.lblLavorazDisp.TabIndex = 33
        Me.lblLavorazDisp.Text = "Lavori In Coda: 0"
        Me.lblLavorazDisp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DgLavoriAperti
        '
        Me.DgLavoriAperti.AllowUserToAddRows = False
        Me.DgLavoriAperti.AllowUserToDeleteRows = False
        Me.DgLavoriAperti.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavoriAperti.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLavoriAperti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLavoriAperti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgLavoriAperti.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgLavoriAperti.BackgroundColor = System.Drawing.Color.White
        Me.DgLavoriAperti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLavoriAperti.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavoriAperti.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLavoriAperti.ColumnHeadersHeight = 20
        Me.DgLavoriAperti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLavoriAperti.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavoriAperti.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgLavoriAperti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavoriAperti.EnableHeadersVisualStyles = False
        Me.DgLavoriAperti.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavoriAperti.Location = New System.Drawing.Point(808, 43)
        Me.DgLavoriAperti.MultiSelect = False
        Me.DgLavoriAperti.Name = "DgLavoriAperti"
        Me.DgLavoriAperti.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavoriAperti.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgLavoriAperti.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavoriAperti.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgLavoriAperti.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.DgLavoriAperti.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavoriAperti.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavoriAperti.RowTemplate.Height = 150
        Me.DgLavoriAperti.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavoriAperti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavoriAperti.Size = New System.Drawing.Size(195, 305)
        Me.DgLavoriAperti.TabIndex = 89
        Me.DgLavoriAperti.TabStop = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.FillWeight = 56.79696!
        Me.DataGridViewImageColumn1.HeaderText = "Anteprima"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 110.203!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Descrizione"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'dgLavoriInCoda
        '
        Me.dgLavoriInCoda.AllowUserToAddRows = False
        Me.dgLavoriInCoda.AllowUserToDeleteRows = False
        Me.dgLavoriInCoda.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLavoriInCoda.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgLavoriInCoda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgLavoriInCoda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgLavoriInCoda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgLavoriInCoda.BackgroundColor = System.Drawing.Color.White
        Me.dgLavoriInCoda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLavoriInCoda.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLavoriInCoda.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgLavoriInCoda.ColumnHeadersHeight = 20
        Me.dgLavoriInCoda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgLavoriInCoda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn2, Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLavoriInCoda.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgLavoriInCoda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgLavoriInCoda.EnableHeadersVisualStyles = False
        Me.dgLavoriInCoda.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgLavoriInCoda.Location = New System.Drawing.Point(0, 43)
        Me.dgLavoriInCoda.MultiSelect = False
        Me.dgLavoriInCoda.Name = "dgLavoriInCoda"
        Me.dgLavoriInCoda.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLavoriInCoda.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgLavoriInCoda.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgLavoriInCoda.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgLavoriInCoda.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.dgLavoriInCoda.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgLavoriInCoda.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgLavoriInCoda.RowTemplate.Height = 150
        Me.dgLavoriInCoda.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLavoriInCoda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLavoriInCoda.Size = New System.Drawing.Size(193, 305)
        Me.dgLavoriInCoda.TabIndex = 90
        Me.dgLavoriInCoda.TabStop = False
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.FillWeight = 56.79696!
        Me.DataGridViewImageColumn2.HeaderText = "Anteprima"
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 110.203!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descrizione"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'frmMonitorOperatore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.DarkRed
        Me.ClientSize = New System.Drawing.Size(1003, 444)
        Me.Controls.Add(Me.dgLavoriInCoda)
        Me.Controls.Add(Me.DgLavoriAperti)
        Me.Controls.Add(Me.lblLavorazDisp)
        Me.Controls.Add(Me.pnlAnteprima)
        Me.Controls.Add(Me.lblLavAperte)
        Me.Controls.Add(Me.lblNotWork)
        Me.Controls.Add(Me.webMonitor)
        Me.Controls.Add(Me.lblOperatore)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        
        Me.KeyPreview = True
        Me.Name = "frmMonitorOperatore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Monitor Operatore"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlAnteprima.ResumeLayout(False)
        CType(Me.pctAnteprima, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgLavoriAperti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgLavoriInCoda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcLabelScrolling1 As ucLabelScrolling
    Friend WithEvents tmrOper As System.Windows.Forms.Timer
    Friend WithEvents webMonitor As System.Windows.Forms.WebBrowser
    Friend WithEvents lblOperatore As System.Windows.Forms.Label
    Friend WithEvents lblNotWork As System.Windows.Forms.Label
    Friend WithEvents lblLavAperte As System.Windows.Forms.Label
    Friend WithEvents lblDettAnteprima As System.Windows.Forms.Label
    Friend WithEvents lblReparto As System.Windows.Forms.Label
    Friend WithEvents pnlAnteprima As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents tmrAnteprima As System.Windows.Forms.Timer
    Friend WithEvents tmrLabel As System.Windows.Forms.Timer
    Friend WithEvents tmrOraCorrente As System.Windows.Forms.Timer
    Friend WithEvents lblOperatAnte As System.Windows.Forms.Label
    Friend WithEvents pctAnteprima As System.Windows.Forms.PictureBox
    Friend WithEvents lblLavorazDisp As System.Windows.Forms.Label
    Friend WithEvents DgLavoriAperti As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgLavoriInCoda As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
