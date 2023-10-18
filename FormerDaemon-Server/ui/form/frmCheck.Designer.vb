<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheck
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheck))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.imgServerInterno = New System.Windows.Forms.PictureBox()
        Me.imgConnInternet = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.imgSito = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.imgServer = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.imgDBRemoto = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tmrCheck = New System.Windows.Forms.Timer(Me.components)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.imgDBInterno = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tmrAutoChiusura = New System.Windows.Forms.Timer(Me.components)
        CType(Me.imgServerInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgConnInternet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgSito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgServer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgDBRemoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgDBInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(95, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Interno..."
        '
        'imgServerInterno
        '
        Me.imgServerInterno.Image = Global.FormerDaemon_Server.My.Resources.Resources.icoBoh
        Me.imgServerInterno.Location = New System.Drawing.Point(41, 26)
        Me.imgServerInterno.Name = "imgServerInterno"
        Me.imgServerInterno.Size = New System.Drawing.Size(48, 48)
        Me.imgServerInterno.TabIndex = 1
        Me.imgServerInterno.TabStop = False
        '
        'imgConnInternet
        '
        Me.imgConnInternet.Image = Global.FormerDaemon_Server.My.Resources.Resources.icoBoh
        Me.imgConnInternet.Location = New System.Drawing.Point(41, 134)
        Me.imgConnInternet.Name = "imgConnInternet"
        Me.imgConnInternet.Size = New System.Drawing.Size(48, 48)
        Me.imgConnInternet.TabIndex = 3
        Me.imgConnInternet.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(95, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Connessione Internet..."
        '
        'imgSito
        '
        Me.imgSito.Image = Global.FormerDaemon_Server.My.Resources.Resources.icoBoh
        Me.imgSito.Location = New System.Drawing.Point(41, 188)
        Me.imgSito.Name = "imgSito"
        Me.imgSito.Size = New System.Drawing.Size(48, 48)
        Me.imgSito.TabIndex = 5
        Me.imgSito.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(95, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sito Internet..."
        '
        'imgServer
        '
        Me.imgServer.Image = Global.FormerDaemon_Server.My.Resources.Resources.icoBoh
        Me.imgServer.Location = New System.Drawing.Point(41, 242)
        Me.imgServer.Name = "imgServer"
        Me.imgServer.Size = New System.Drawing.Size(48, 48)
        Me.imgServer.TabIndex = 7
        Me.imgServer.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(95, 257)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(193, 21)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Server Virtuale"
        '
        'imgDBRemoto
        '
        Me.imgDBRemoto.Image = Global.FormerDaemon_Server.My.Resources.Resources.icoBoh
        Me.imgDBRemoto.Location = New System.Drawing.Point(41, 296)
        Me.imgDBRemoto.Name = "imgDBRemoto"
        Me.imgDBRemoto.Size = New System.Drawing.Size(48, 48)
        Me.imgDBRemoto.TabIndex = 9
        Me.imgDBRemoto.TabStop = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(95, 311)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 21)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Database Remoto..."
        '
        'tmrCheck
        '
        Me.tmrCheck.Enabled = True
        Me.tmrCheck.Interval = 1000
        '
        'btnClose
        '
        Me.btnClose.Enabled = False
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(88, 359)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(122, 23)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Chiudi il demone"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'imgDBInterno
        '
        Me.imgDBInterno.Image = Global.FormerDaemon_Server.My.Resources.Resources.icoBoh
        Me.imgDBInterno.Location = New System.Drawing.Point(41, 80)
        Me.imgDBInterno.Name = "imgDBInterno"
        Me.imgDBInterno.Size = New System.Drawing.Size(48, 48)
        Me.imgDBInterno.TabIndex = 12
        Me.imgDBInterno.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(95, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(193, 21)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Database Interno..."
        '
        'tmrAutoChiusura
        '
        Me.tmrAutoChiusura.Interval = 60000
        '
        'frmCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(307, 394)
        Me.ControlBox = False
        Me.Controls.Add(Me.imgDBInterno)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.imgDBRemoto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.imgServer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.imgSito)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.imgConnInternet)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.imgServerInterno)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormerDaemon - Check..."
        CType(Me.imgServerInterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgConnInternet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgSito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgServer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgDBRemoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgDBInterno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents imgServerInterno As System.Windows.Forms.PictureBox
    Friend WithEvents imgConnInternet As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imgSito As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents imgServer As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents imgDBRemoto As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tmrCheck As System.Windows.Forms.Timer
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents imgDBInterno As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tmrAutoChiusura As Timer
End Class
