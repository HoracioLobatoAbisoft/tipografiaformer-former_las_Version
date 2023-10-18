<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMagazzinoStatistiche
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
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.WebStat = New System.Windows.Forms.WebBrowser()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbGruppo = New System.Windows.Forms.ComboBox()
        Me.cmbTipoCarta = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtDataInsAl = New System.Windows.Forms.DateTimePicker()
        Me.dtDataInsDal = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbPeriodoRif = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiorna.AutoSize = True
        Me.lnkAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(1057, 1)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Padding = New System.Windows.Forms.Padding(28, 5, 0, 5)
        Me.lnkAggiorna.Size = New System.Drawing.Size(84, 25)
        Me.lnkAggiorna.TabIndex = 51
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WebStat
        '
        Me.WebStat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebStat.Location = New System.Drawing.Point(0, 61)
        Me.WebStat.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebStat.Name = "WebStat"
        Me.WebStat.Size = New System.Drawing.Size(1144, 479)
        Me.WebStat.TabIndex = 53
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbGruppo)
        Me.Panel1.Controls.Add(Me.cmbTipoCarta)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtDataInsAl)
        Me.Panel1.Controls.Add(Me.dtDataInsDal)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cmbPeriodoRif)
        Me.Panel1.Controls.Add(Me.lnkAggiorna)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1144, 61)
        Me.Panel1.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(768, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 15)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Gruppo"
        '
        'cmbGruppo
        '
        Me.cmbGruppo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGruppo.FormattingEnabled = True
        Me.cmbGruppo.Location = New System.Drawing.Point(821, 3)
        Me.cmbGruppo.Name = "cmbGruppo"
        Me.cmbGruppo.Size = New System.Drawing.Size(220, 23)
        Me.cmbGruppo.TabIndex = 109
        '
        'cmbTipoCarta
        '
        Me.cmbTipoCarta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipoCarta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoCarta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbTipoCarta.FormattingEnabled = True
        Me.cmbTipoCarta.Items.AddRange(New Object() {"Orizzontale", "Verticale"})
        Me.cmbTipoCarta.Location = New System.Drawing.Point(119, 32)
        Me.cmbTipoCarta.Name = "cmbTipoCarta"
        Me.cmbTipoCarta.Size = New System.Drawing.Size(643, 23)
        Me.cmbTipoCarta.TabIndex = 106
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(3, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 15)
        Me.Label16.TabIndex = 107
        Me.Label16.Text = "Tipo Carta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(530, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 15)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Al"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(286, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 15)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Dal"
        '
        'dtDataInsAl
        '
        Me.dtDataInsAl.Location = New System.Drawing.Point(554, 2)
        Me.dtDataInsAl.Name = "dtDataInsAl"
        Me.dtDataInsAl.Size = New System.Drawing.Size(208, 23)
        Me.dtDataInsAl.TabIndex = 103
        '
        'dtDataInsDal
        '
        Me.dtDataInsDal.Location = New System.Drawing.Point(316, 2)
        Me.dtDataInsDal.Name = "dtDataInsDal"
        Me.dtDataInsDal.Size = New System.Drawing.Size(208, 23)
        Me.dtDataInsDal.TabIndex = 101
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(3, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 15)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "Periodo riferimento"
        '
        'cmbPeriodoRif
        '
        Me.cmbPeriodoRif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoRif.FormattingEnabled = True
        Me.cmbPeriodoRif.Location = New System.Drawing.Point(119, 3)
        Me.cmbPeriodoRif.Name = "cmbPeriodoRif"
        Me.cmbPeriodoRif.Size = New System.Drawing.Size(161, 23)
        Me.cmbPeriodoRif.TabIndex = 98
        '
        'ucMagazzinoStatistiche
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.WebStat)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucMagazzinoStatistiche"
        Me.Size = New System.Drawing.Size(1144, 540)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lnkAggiorna As LinkLabel
    Friend WithEvents WebStat As WebBrowser
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbPeriodoRif As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtDataInsAl As DateTimePicker
    Friend WithEvents dtDataInsDal As DateTimePicker
    Friend WithEvents cmbTipoCarta As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbGruppo As ComboBox
End Class
