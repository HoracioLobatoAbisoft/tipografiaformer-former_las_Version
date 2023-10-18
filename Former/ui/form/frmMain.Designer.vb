<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits baseFormInterna

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        'Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        'Me.tmrOra = New System.Windows.Forms.Timer(Me.components)
        'Me.ToolTipHelp = New System.Windows.Forms.ToolTip(Me.components)
        'Me.imlFunz = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainerPrincipale = New System.Windows.Forms.SplitContainer()
        Me.dateMain = New System.Windows.Forms.DateTimePicker()
        Me.lblOra = New System.Windows.Forms.Label()
        Me.pctLogo = New System.Windows.Forms.PictureBox()
        Me.gbPostazione = New System.Windows.Forms.GroupBox()
        Me.pctMonitor = New System.Windows.Forms.PictureBox()
        Me.lnkImpostazioni = New System.Windows.Forms.LinkLabel()
        Me.pctAgg = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRilascio = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblVersione = New System.Windows.Forms.Label()
        Me.lblUtConn = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.UcPostitMain = New Former.ucMessaggiInterniSmall()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.UcToolbarMain = New Former.ucMainToolbar()
        Me.UcMain = New Former.ucMain()
        Me.lnkMaxSpace = New System.Windows.Forms.LinkLabel()
        Me.lblUsbLogin = New System.Windows.Forms.Label()
        Me.lblClassicLogin = New System.Windows.Forms.Label()
        CType(Me.SplitContainerPrincipale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerPrincipale.Panel1.SuspendLayout()
        Me.SplitContainerPrincipale.Panel2.SuspendLayout()
        Me.SplitContainerPrincipale.SuspendLayout()
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPostazione.SuspendLayout()
        CType(Me.pctMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctAgg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrOra
        '
        'Me.tmrOra.Interval = 30000
        '
        'tmrAgg
        '
        'Me.tmrAgg.Interval = 3600000
        '
        'imlFunz
        '
        'Me.imlFunz.ImageStream = CType(resources.GetObject("imlFunz.ImageStream"), System.Windows.Forms.ImageListStreamer)
        'Me.imlFunz.TransparentColor = System.Drawing.Color.Transparent
        'Me.imlFunz.Images.SetKeyName(0, "icoRub.jpg")
        'Me.imlFunz.Images.SetKeyName(1, "icoMagaz.jpg")
        'Me.imlFunz.Images.SetKeyName(2, "icoProd.jpg")
        'Me.imlFunz.Images.SetKeyName(3, "icoOrder.jpg")
        'Me.imlFunz.Images.SetKeyName(4, "icoCom.jpg")
        'Me.imlFunz.Images.SetKeyName(5, "icoMoney.jpg")
        'Me.imlFunz.Images.SetKeyName(6, "icoPc.jpg")
        'Me.imlFunz.Images.SetKeyName(7, "icoParam.jpg")
        '
        'SplitContainerPrincipale
        '
        Me.SplitContainerPrincipale.BackColor = System.Drawing.Color.White
        Me.SplitContainerPrincipale.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainerPrincipale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerPrincipale.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerPrincipale.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerPrincipale.Name = "SplitContainerPrincipale"
        '
        'SplitContainerPrincipale.Panel1
        '
        Me.SplitContainerPrincipale.Panel1.Controls.Add(Me.dateMain)
        Me.SplitContainerPrincipale.Panel1.Controls.Add(Me.lblOra)
        Me.SplitContainerPrincipale.Panel1.Controls.Add(Me.pctLogo)
        Me.SplitContainerPrincipale.Panel1.Controls.Add(Me.gbPostazione)
        Me.SplitContainerPrincipale.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainerPrincipale.Panel1MinSize = 0
        '
        'SplitContainerPrincipale.Panel2
        '
        Me.SplitContainerPrincipale.Panel2.Controls.Add(Me.btnMinimize)
        Me.SplitContainerPrincipale.Panel2.Controls.Add(Me.btnClose)
        Me.SplitContainerPrincipale.Panel2.Controls.Add(Me.UcToolbarMain)
        Me.SplitContainerPrincipale.Panel2.Controls.Add(Me.UcMain)
        Me.SplitContainerPrincipale.Panel2.Controls.Add(Me.lnkMaxSpace)
        Me.SplitContainerPrincipale.Panel2.Controls.Add(Me.lblUsbLogin)
        Me.SplitContainerPrincipale.Panel2.Controls.Add(Me.lblClassicLogin)
        Me.SplitContainerPrincipale.Size = New System.Drawing.Size(1124, 711)
        Me.SplitContainerPrincipale.SplitterDistance = 260
        Me.SplitContainerPrincipale.SplitterWidth = 10
        Me.SplitContainerPrincipale.TabIndex = 9
        Me.SplitContainerPrincipale.TabStop = False
        '
        'dateMain
        '
        Me.dateMain.CustomFormat = "dddd dd MMMM "
        Me.dateMain.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateMain.Location = New System.Drawing.Point(83, 50)
        Me.dateMain.Name = "dateMain"
        Me.dateMain.Size = New System.Drawing.Size(174, 21)
        Me.dateMain.TabIndex = 8
        '
        'lblOra
        '
        Me.lblOra.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOra.ForeColor = System.Drawing.Color.Black
        Me.lblOra.Location = New System.Drawing.Point(0, 40)
        Me.lblOra.Name = "lblOra"
        Me.lblOra.Size = New System.Drawing.Size(80, 40)
        Me.lblOra.TabIndex = 7
        Me.lblOra.Text = "11:00"
        Me.lblOra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctLogo
        '
        Me.pctLogo.Image = Global.Former.My.Resources.logo1
        Me.pctLogo.Location = New System.Drawing.Point(3, 3)
        Me.pctLogo.Name = "pctLogo"
        Me.pctLogo.Size = New System.Drawing.Size(230, 36)
        Me.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogo.TabIndex = 1
        Me.pctLogo.TabStop = False
        '
        'gbPostazione
        '
        Me.gbPostazione.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPostazione.Controls.Add(Me.pctMonitor)
        Me.gbPostazione.Controls.Add(Me.lnkImpostazioni)
        Me.gbPostazione.Controls.Add(Me.pctAgg)
        Me.gbPostazione.Controls.Add(Me.Label2)
        Me.gbPostazione.Controls.Add(Me.lblRilascio)
        Me.gbPostazione.Controls.Add(Me.Label4)
        Me.gbPostazione.Controls.Add(Me.Label1)
        Me.gbPostazione.Controls.Add(Me.lblVersione)
        Me.gbPostazione.Controls.Add(Me.lblUtConn)
        Me.gbPostazione.Controls.Add(Me.PictureBox1)
        Me.gbPostazione.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPostazione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.gbPostazione.Location = New System.Drawing.Point(4, 77)
        Me.gbPostazione.Name = "gbPostazione"
        Me.gbPostazione.Size = New System.Drawing.Size(253, 125)
        Me.gbPostazione.TabIndex = 5
        Me.gbPostazione.TabStop = False
        Me.gbPostazione.Text = "Postazione"
        '
        'pctMonitor
        '
        Me.pctMonitor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctMonitor.Image = Global.Former.My.Resources.monitor
        Me.pctMonitor.Location = New System.Drawing.Point(8, 71)
        Me.pctMonitor.Name = "pctMonitor"
        Me.pctMonitor.Size = New System.Drawing.Size(32, 32)
        Me.pctMonitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctMonitor.TabIndex = 51
        Me.pctMonitor.TabStop = False
        '
        'lnkImpostazioni
        '
        Me.lnkImpostazioni.AutoSize = True
        Me.lnkImpostazioni.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkImpostazioni.Location = New System.Drawing.Point(124, 93)
        Me.lnkImpostazioni.Name = "lnkImpostazioni"
        Me.lnkImpostazioni.Size = New System.Drawing.Size(127, 15)
        Me.lnkImpostazioni.TabIndex = 6
        Me.lnkImpostazioni.TabStop = True
        Me.lnkImpostazioni.Text = "Imposta preferenze..."
        '
        'pctAgg
        '
        Me.pctAgg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctAgg.Image = Global.Former.My.Resources.warning_shield
        Me.pctAgg.Location = New System.Drawing.Point(219, 42)
        Me.pctAgg.Name = "pctAgg"
        Me.pctAgg.Size = New System.Drawing.Size(26, 26)
        Me.pctAgg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctAgg.TabIndex = 5
        Me.pctAgg.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Rilascio"
        '
        'lblRilascio
        '
        Me.lblRilascio.AutoSize = True
        Me.lblRilascio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRilascio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblRilascio.Location = New System.Drawing.Point(122, 71)
        Me.lblRilascio.Name = "lblRilascio"
        Me.lblRilascio.Size = New System.Drawing.Size(52, 15)
        Me.lblRilascio.TabIndex = 1
        Me.lblRilascio.Text = "Rilascio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Operatore"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Versione"
        '
        'lblVersione
        '
        Me.lblVersione.AutoSize = True
        Me.lblVersione.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblVersione.Location = New System.Drawing.Point(122, 45)
        Me.lblVersione.Name = "lblVersione"
        Me.lblVersione.Size = New System.Drawing.Size(57, 15)
        Me.lblVersione.TabIndex = 1
        Me.lblVersione.Text = "Versione"
        '
        'lblUtConn
        '
        Me.lblUtConn.AutoSize = True
        Me.lblUtConn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUtConn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblUtConn.Location = New System.Drawing.Point(122, 20)
        Me.lblUtConn.Name = "lblUtConn"
        Me.lblUtConn.Size = New System.Drawing.Size(44, 15)
        Me.lblUtConn.TabIndex = 1
        Me.lblUtConn.Text = "Utente"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.settings
        Me.PictureBox1.Location = New System.Drawing.Point(6, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.UcPostitMain)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 491)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Messaggi"
        '
        'UcPostitMain
        '
        Me.UcPostitMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcPostitMain.BackColor = System.Drawing.Color.White
        Me.UcPostitMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcPostitMain.ForeColor = System.Drawing.Color.Black
        Me.UcPostitMain.Location = New System.Drawing.Point(6, 20)
        Me.UcPostitMain.Name = "UcPostitMain"
        Me.UcPostitMain.Size = New System.Drawing.Size(241, 465)
        Me.UcPostitMain.TabIndex = 2
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnMinimize.BackColor = System.Drawing.Color.LightGray
        Me.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMinimize.FlatAppearance.BorderSize = 0
        Me.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimize.Image = Global.Former.My.Resources.minimize
        Me.btnMinimize.Location = New System.Drawing.Point(777, 0)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(32, 32)
        Me.btnMinimize.TabIndex = 66
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.BackColor = System.Drawing.Color.LightGray
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = Global.Former.My.Resources.shutdown
        Me.btnClose.Location = New System.Drawing.Point(809, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(32, 32)
        Me.btnClose.TabIndex = 65
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'UcToolbarMain
        '
        Me.UcToolbarMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        'Me.UcToolbarMain.BonusMaturato = "0"
        Me.UcToolbarMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcToolbarMain.Location = New System.Drawing.Point(134, 0)
        Me.UcToolbarMain.Name = "UcToolbarMain"
        Me.UcToolbarMain.Size = New System.Drawing.Size(499, 32)
        Me.UcToolbarMain.TabIndex = 64
        '
        'UcMain
        '
        Me.UcMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UcMain.BackColor = System.Drawing.Color.White
        Me.UcMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMain.Location = New System.Drawing.Point(0, 35)
        Me.UcMain.Name = "UcMain"
        Me.UcMain.Size = New System.Drawing.Size(845, 676)
        Me.UcMain.TabIndex = 0
        '
        'lnkMaxSpace
        '
        Me.lnkMaxSpace.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkMaxSpace.Image = Global.Former.My.Resources.begin
        Me.lnkMaxSpace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkMaxSpace.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkMaxSpace.Location = New System.Drawing.Point(0, 0)
        Me.lnkMaxSpace.Name = "lnkMaxSpace"
        Me.lnkMaxSpace.Size = New System.Drawing.Size(119, 32)
        Me.lnkMaxSpace.TabIndex = 63
        Me.lnkMaxSpace.TabStop = True
        Me.lnkMaxSpace.Text = "Ottimizza Spazio"
        Me.lnkMaxSpace.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUsbLogin
        '
        Me.lblUsbLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUsbLogin.BackColor = System.Drawing.Color.LightGray
        Me.lblUsbLogin.Image = Global.Former.My.Resources.usb_connected
        Me.lblUsbLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUsbLogin.Location = New System.Drawing.Point(647, 0)
        Me.lblUsbLogin.Name = "lblUsbLogin"
        Me.lblUsbLogin.Size = New System.Drawing.Size(130, 32)
        Me.lblUsbLogin.TabIndex = 69
        Me.lblUsbLogin.Text = "FormerKey Login"
        Me.lblUsbLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblUsbLogin.Visible = False
        '
        'lblClassicLogin
        '
        Me.lblClassicLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblClassicLogin.BackColor = System.Drawing.Color.LightGray
        Me.lblClassicLogin.Image = Global.Former.My.Resources.user
        Me.lblClassicLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblClassicLogin.Location = New System.Drawing.Point(647, 0)
        Me.lblClassicLogin.Name = "lblClassicLogin"
        Me.lblClassicLogin.Size = New System.Drawing.Size(130, 32)
        Me.lblClassicLogin.TabIndex = 70
        Me.lblClassicLogin.Text = "Standard Login"
        Me.lblClassicLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblClassicLogin.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1124, 711)
        Me.Controls.Add(Me.SplitContainerPrincipale)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None

        Me.Name = "frmMain"
        Me.Text = "Former - Gestionale Tipografia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerPrincipale.Panel1.ResumeLayout(False)
        Me.SplitContainerPrincipale.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerPrincipale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerPrincipale.ResumeLayout(False)
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPostazione.ResumeLayout(False)
        Me.gbPostazione.PerformLayout()
        CType(Me.pctMonitor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctAgg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


    Friend WithEvents pctLogo As System.Windows.Forms.PictureBox
    Friend WithEvents gbPostazione As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblUtConn As System.Windows.Forms.Label
    Friend WithEvents pctAgg As System.Windows.Forms.PictureBox
    Friend WithEvents lblRilascio As System.Windows.Forms.Label
    Friend WithEvents lblVersione As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UcPostitMain As Former.ucMessaggiInterniSmall
    'Friend WithEvents tmrOra As System.Windows.Forms.Timer
    Friend WithEvents lblOra As System.Windows.Forms.Label
    'Friend WithEvents tmrAgg As System.Windows.Forms.Timer
    Friend WithEvents lnkImpostazioni As System.Windows.Forms.LinkLabel
    'Friend WithEvents ToolTipHelp As System.Windows.Forms.ToolTip
    Friend WithEvents SplitContainerPrincipale As SplitContainer
    Friend WithEvents lnkMaxSpace As System.Windows.Forms.LinkLabel
    'Friend WithEvents imlFunz As System.Windows.Forms.ImageList
    Friend WithEvents UcToolbarMain As Former.ucMainToolbar
    Friend WithEvents UcMain As Former.ucMain
    Friend WithEvents dateMain As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents pctMonitor As System.Windows.Forms.PictureBox
    Friend WithEvents lblClassicLogin As System.Windows.Forms.Label
    Friend WithEvents lblUsbLogin As System.Windows.Forms.Label

End Class
