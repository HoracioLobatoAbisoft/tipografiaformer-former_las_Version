<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoBanner
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnTestUrl = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rdoNonAttivo = New System.Windows.Forms.RadioButton()
        Me.rdoAttivo = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAlternate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtImgRif = New System.Windows.Forms.TextBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pctImgRif = New System.Windows.Forms.PictureBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctImgRif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 410)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(873, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
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
        Me.TabMain.Size = New System.Drawing.Size(873, 410)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnTestUrl)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.rdoNonAttivo)
        Me.tbProd.Controls.Add(Me.rdoAttivo)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtAlternate)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.txtUrl)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.btnSearch)
        Me.tbProd.Controls.Add(Me.pctImgRif)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtImgRif)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(865, 384)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Banner Sito Web"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnTestUrl
        '
        Me.btnTestUrl.Location = New System.Drawing.Point(762, 270)
        Me.btnTestUrl.Name = "btnTestUrl"
        Me.btnTestUrl.Size = New System.Drawing.Size(55, 21)
        Me.btnTestUrl.TabIndex = 72
        Me.btnTestUrl.Text = "Test"
        Me.btnTestUrl.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(507, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(342, 21)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "(dimensioni 800x200px, peso massimo 55kb)"
        '
        'rdoNonAttivo
        '
        Me.rdoNonAttivo.AutoSize = True
        Me.rdoNonAttivo.BackColor = System.Drawing.Color.Red
        Me.rdoNonAttivo.ForeColor = System.Drawing.Color.White
        Me.rdoNonAttivo.Location = New System.Drawing.Point(192, 354)
        Me.rdoNonAttivo.Name = "rdoNonAttivo"
        Me.rdoNonAttivo.Size = New System.Drawing.Size(83, 19)
        Me.rdoNonAttivo.TabIndex = 70
        Me.rdoNonAttivo.Text = "Non Attivo"
        Me.rdoNonAttivo.UseVisualStyleBackColor = False
        '
        'rdoAttivo
        '
        Me.rdoAttivo.AutoSize = True
        Me.rdoAttivo.BackColor = System.Drawing.Color.Green
        Me.rdoAttivo.Checked = True
        Me.rdoAttivo.ForeColor = System.Drawing.Color.White
        Me.rdoAttivo.Location = New System.Drawing.Point(133, 354)
        Me.rdoAttivo.Name = "rdoAttivo"
        Me.rdoAttivo.Size = New System.Drawing.Size(57, 19)
        Me.rdoAttivo.TabIndex = 70
        Me.rdoAttivo.TabStop = True
        Me.rdoAttivo.Text = "Attivo"
        Me.rdoAttivo.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(46, 356)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 15)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Stato"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(130, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(506, 15)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "(testo alternativo che appare quando si passa sopra l'immagine. Non usare caratte" &
    "ri speciali!!!)"
        '
        'txtAlternate
        '
        Me.txtAlternate.Location = New System.Drawing.Point(133, 312)
        Me.txtAlternate.MaxLength = 255
        Me.txtAlternate.Name = "txtAlternate"
        Me.txtAlternate.Size = New System.Drawing.Size(684, 20)
        Me.txtAlternate.TabIndex = 67
        Me.txtAlternate.Tag = "Tipografia Former - Il tuo mondo della stampa"
        Me.txtAlternate.Text = "Tipografia Former - Il tuo mondo della stampa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(46, 315)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Alternate"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(130, 294)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(673, 15)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "(senza http://www.tipografiaformer.it - ad esempio: /4/110/3/1/1/Volantini_A4_Ori" &
    "zzontale_115_gr__4_4 - Prendendolo dal sito)"
        '
        'txtUrl
        '
        Me.txtUrl.Location = New System.Drawing.Point(133, 270)
        Me.txtUrl.MaxLength = 255
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(623, 20)
        Me.txtUrl.TabIndex = 64
        Me.txtUrl.Tag = "/"
        Me.txtUrl.Text = "/"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(46, 273)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Url link"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(791, 243)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 21)
        Me.btnSearch.TabIndex = 62
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(46, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Immagine"
        '
        'txtImgRif
        '
        Me.txtImgRif.Location = New System.Drawing.Point(133, 243)
        Me.txtImgRif.MaxLength = 50
        Me.txtImgRif.Name = "txtImgRif"
        Me.txtImgRif.ReadOnly = True
        Me.txtImgRif.Size = New System.Drawing.Size(652, 20)
        Me.txtImgRif.TabIndex = 0
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(137, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Banner Sito Web"
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini JPG|*.jpg"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(831, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 34)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pctImgRif
        '
        Me.pctImgRif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgRif.Location = New System.Drawing.Point(49, 37)
        Me.pctImgRif.Name = "pctImgRif"
        Me.pctImgRif.Size = New System.Drawing.Size(800, 200)
        Me.pctImgRif.TabIndex = 21
        Me.pctImgRif.TabStop = False
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._BannerSIto
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.Location = New System.Drawing.Point(797, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmListinoBanner
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(873, 458)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoBanner"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Banner Sito Web"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctImgRif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtImgRif As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents pctImgRif As System.Windows.Forms.PictureBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents OpenFileImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents rdoNonAttivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAttivo As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAlternate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnTestUrl As Button
End Class
