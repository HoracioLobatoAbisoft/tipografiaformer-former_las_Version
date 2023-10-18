<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazioneParametri
    Inherits ucFormerUserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucAmministrazioneParametri))
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpOperatori = New System.Windows.Forms.TabPage()
        Me.UcOperatori = New Former.ucAmministrazioneOperatori()
        Me.tpBarCode = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnQrCode = New System.Windows.Forms.Button()
        Me.txtQrCode = New System.Windows.Forms.TextBox()
        Me.pctQrCode = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBarCode = New System.Windows.Forms.Button()
        Me.txtBarCode = New Former.ucNumericTextBox()
        Me.txtBarcodeForCheck = New Former.ucNumericTextBox()
        Me.btnCalcola = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lnkCercaBarCode = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lnkCreaNuovaScatola = New System.Windows.Forms.LinkLabel()
        Me.tpProcedura = New System.Windows.Forms.TabPage()
        Me.UcAmministrazioneProcedure = New Former.ucAmministrazioneProcedure()
        Me.imlMain = New System.Windows.Forms.ImageList(Me.components)
        Me.tabMain.SuspendLayout()
        Me.tpOperatori.SuspendLayout()
        Me.tpBarCode.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pctQrCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpProcedura.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tpOperatori)
        Me.tabMain.Controls.Add(Me.tpBarCode)
        Me.tabMain.Controls.Add(Me.tpProcedura)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.ImageList = Me.imlMain
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(925, 454)
        Me.tabMain.TabIndex = 84
        '
        'tpOperatori
        '
        Me.tpOperatori.Controls.Add(Me.UcOperatori)
        Me.tpOperatori.ImageKey = "user.png"
        Me.tpOperatori.Location = New System.Drawing.Point(4, 31)
        Me.tpOperatori.Name = "tpOperatori"
        Me.tpOperatori.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOperatori.Size = New System.Drawing.Size(917, 419)
        Me.tpOperatori.TabIndex = 2
        Me.tpOperatori.Text = "Operatori"
        Me.tpOperatori.UseVisualStyleBackColor = True
        '
        'UcOperatori
        '
        Me.UcOperatori.BackColor = System.Drawing.Color.White
        Me.UcOperatori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOperatori.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOperatori.Location = New System.Drawing.Point(3, 3)
        Me.UcOperatori.Name = "UcOperatori"
        Me.UcOperatori.Size = New System.Drawing.Size(911, 413)
        Me.UcOperatori.TabIndex = 0
        '
        'tpBarCode
        '
        Me.tpBarCode.Controls.Add(Me.GroupBox3)
        Me.tpBarCode.Controls.Add(Me.GroupBox2)
        Me.tpBarCode.Controls.Add(Me.GroupBox1)
        Me.tpBarCode.ImageKey = "_barcode.png"
        Me.tpBarCode.Location = New System.Drawing.Point(4, 31)
        Me.tpBarCode.Name = "tpBarCode"
        Me.tpBarCode.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBarCode.Size = New System.Drawing.Size(917, 419)
        Me.tpBarCode.TabIndex = 6
        Me.tpBarCode.Text = "Barcode"
        Me.tpBarCode.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnQrCode)
        Me.GroupBox3.Controls.Add(Me.txtQrCode)
        Me.GroupBox3.Controls.Add(Me.pctQrCode)
        Me.GroupBox3.Location = New System.Drawing.Point(78, 249)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(764, 87)
        Me.GroupBox3.TabIndex = 78
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Stampa QR Code"
        '
        'btnQrCode
        '
        Me.btnQrCode.Location = New System.Drawing.Point(324, 39)
        Me.btnQrCode.Name = "btnQrCode"
        Me.btnQrCode.Size = New System.Drawing.Size(144, 23)
        Me.btnQrCode.TabIndex = 77
        Me.btnQrCode.Text = "Crea QR Code"
        Me.btnQrCode.UseVisualStyleBackColor = True
        '
        'txtQrCode
        '
        Me.txtQrCode.Location = New System.Drawing.Point(75, 41)
        Me.txtQrCode.Name = "txtQrCode"
        Me.txtQrCode.Size = New System.Drawing.Size(243, 23)
        Me.txtQrCode.TabIndex = 76
        '
        'pctQrCode
        '
        Me.pctQrCode.Image = Global.Former.My.Resources.Resources.qrcode
        Me.pctQrCode.Location = New System.Drawing.Point(13, 25)
        Me.pctQrCode.Name = "pctQrCode"
        Me.pctQrCode.Size = New System.Drawing.Size(50, 50)
        Me.pctQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctQrCode.TabIndex = 75
        Me.pctQrCode.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBarCode)
        Me.GroupBox2.Controls.Add(Me.txtBarCode)
        Me.GroupBox2.Controls.Add(Me.txtBarcodeForCheck)
        Me.GroupBox2.Controls.Add(Me.btnCalcola)
        Me.GroupBox2.Location = New System.Drawing.Point(78, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(764, 96)
        Me.GroupBox2.TabIndex = 77
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stampa Barcode"
        '
        'btnBarCode
        '
        Me.btnBarCode.Location = New System.Drawing.Point(174, 29)
        Me.btnBarCode.Name = "btnBarCode"
        Me.btnBarCode.Size = New System.Drawing.Size(144, 23)
        Me.btnBarCode.TabIndex = 69
        Me.btnBarCode.Text = "Stampa BarCode"
        Me.btnBarCode.UseVisualStyleBackColor = True
        '
        'txtBarCode
        '
        Me.txtBarCode.My_AccettaNegativi = False
        Me.txtBarCode.My_DefaultValue = 0
        Me.txtBarCode.Location = New System.Drawing.Point(14, 30)
        Me.txtBarCode.MaxLength = 13
        Me.txtBarCode.My_MaxValue = 1.0E+10!
        Me.txtBarCode.My_MinValue = 0!
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.My_AllowOnlyInteger = True
        Me.txtBarCode.My_ReplaceWithDefaultValue = True
        Me.txtBarCode.Size = New System.Drawing.Size(154, 23)
        Me.txtBarCode.TabIndex = 70
        Me.txtBarCode.Text = "0"
        Me.txtBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBarcodeForCheck
        '
        Me.txtBarcodeForCheck.My_AccettaNegativi = False
        Me.txtBarcodeForCheck.My_DefaultValue = 0
        Me.txtBarcodeForCheck.Location = New System.Drawing.Point(14, 59)
        Me.txtBarcodeForCheck.MaxLength = 12
        Me.txtBarcodeForCheck.My_MaxValue = 1.0E+10!
        Me.txtBarcodeForCheck.My_MinValue = 0!
        Me.txtBarcodeForCheck.Name = "txtBarcodeForCheck"
        Me.txtBarcodeForCheck.My_AllowOnlyInteger = True
        Me.txtBarcodeForCheck.My_ReplaceWithDefaultValue = True
        Me.txtBarcodeForCheck.Size = New System.Drawing.Size(154, 23)
        Me.txtBarcodeForCheck.TabIndex = 72
        Me.txtBarcodeForCheck.Text = "0"
        Me.txtBarcodeForCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCalcola
        '
        Me.btnCalcola.Location = New System.Drawing.Point(174, 58)
        Me.btnCalcola.Name = "btnCalcola"
        Me.btnCalcola.Size = New System.Drawing.Size(144, 23)
        Me.btnCalcola.TabIndex = 71
        Me.btnCalcola.Text = "Calcola CheckBarcode"
        Me.btnCalcola.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lnkCercaBarCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lnkCreaNuovaScatola)
        Me.GroupBox1.Location = New System.Drawing.Point(78, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(764, 115)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stampa Barcode Speciali"
        '
        'lnkCercaBarCode
        '
        Me.lnkCercaBarCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lnkCercaBarCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCercaBarCode.Image = Global.Former.My.Resources.Resources.barcode1
        Me.lnkCercaBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCercaBarCode.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCercaBarCode.Location = New System.Drawing.Point(15, 28)
        Me.lnkCercaBarCode.Name = "lnkCercaBarCode"
        Me.lnkCercaBarCode.Size = New System.Drawing.Size(160, 32)
        Me.lnkCercaBarCode.TabIndex = 67
        Me.lnkCercaBarCode.TabStop = True
        Me.lnkCercaBarCode.Text = "Fine caricamento colli"
        Me.lnkCercaBarCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(271, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(440, 15)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Permette di completare l'operazione di caricamento colli e terminare l'inseriment" &
    "o"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(271, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(253, 15)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Chiude la scatola corrente e ne crea una nuova"
        '
        'lnkCreaNuovaScatola
        '
        Me.lnkCreaNuovaScatola.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lnkCreaNuovaScatola.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCreaNuovaScatola.Image = Global.Former.My.Resources.Resources.barcode1
        Me.lnkCreaNuovaScatola.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCreaNuovaScatola.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCreaNuovaScatola.Location = New System.Drawing.Point(15, 68)
        Me.lnkCreaNuovaScatola.Name = "lnkCreaNuovaScatola"
        Me.lnkCreaNuovaScatola.Size = New System.Drawing.Size(240, 32)
        Me.lnkCreaNuovaScatola.TabIndex = 73
        Me.lnkCreaNuovaScatola.TabStop = True
        Me.lnkCreaNuovaScatola.Text = "Chiudi scatola corrente e crea nuova"
        Me.lnkCreaNuovaScatola.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpProcedura
        '
        Me.tpProcedura.Controls.Add(Me.UcAmministrazioneProcedure)
        Me.tpProcedura.ImageKey = "_Procedura.png"
        Me.tpProcedura.Location = New System.Drawing.Point(4, 31)
        Me.tpProcedura.Name = "tpProcedura"
        Me.tpProcedura.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProcedura.Size = New System.Drawing.Size(917, 419)
        Me.tpProcedura.TabIndex = 7
        Me.tpProcedura.Text = "Procedure"
        Me.tpProcedura.UseVisualStyleBackColor = True
        '
        'UcAmministrazioneProcedure
        '
        Me.UcAmministrazioneProcedure.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneProcedure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneProcedure.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneProcedure.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneProcedure.Name = "UcAmministrazioneProcedure"
        Me.UcAmministrazioneProcedure.Size = New System.Drawing.Size(911, 413)
        Me.UcAmministrazioneProcedure.TabIndex = 0
        '
        'imlMain
        '
        Me.imlMain.ImageStream = CType(resources.GetObject("imlMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMain.Images.SetKeyName(0, "user.png")
        Me.imlMain.Images.SetKeyName(1, "_barcode.png")
        Me.imlMain.Images.SetKeyName(2, "_Procedura.png")
        '
        'ucAmministrazioneParametri
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tabMain)
        Me.Name = "ucAmministrazioneParametri"
        Me.Size = New System.Drawing.Size(925, 454)
        Me.tabMain.ResumeLayout(False)
        Me.tpOperatori.ResumeLayout(False)
        Me.tpBarCode.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.pctQrCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpProcedura.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpOperatori As System.Windows.Forms.TabPage
    Friend WithEvents UcOperatori As Former.ucAmministrazioneOperatori
    Friend WithEvents tpBarCode As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lnkCercaBarCode As System.Windows.Forms.LinkLabel
    Friend WithEvents txtBarCode As ucNumericTextBox
    Friend WithEvents btnBarCode As System.Windows.Forms.Button
    Friend WithEvents txtBarcodeForCheck As ucNumericTextBox
    Friend WithEvents btnCalcola As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lnkCreaNuovaScatola As System.Windows.Forms.LinkLabel
    Friend WithEvents imlMain As ImageList
    Friend WithEvents pctQrCode As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnQrCode As Button
    Friend WithEvents txtQrCode As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tpProcedura As TabPage
    Friend WithEvents UcAmministrazioneProcedure As ucAmministrazioneProcedure
End Class
