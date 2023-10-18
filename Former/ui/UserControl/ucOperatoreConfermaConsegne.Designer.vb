<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucOperatoreConfermaConsegne
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucOperatoreConfermaConsegne))
        Me.tvwConsegne = New System.Windows.Forms.TreeView()
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.btnConsegnaEffettuata = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tvwConsegne
        '
        Me.tvwConsegne.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwConsegne.FullRowSelect = True
        Me.tvwConsegne.ImageIndex = 0
        Me.tvwConsegne.ImageList = Me.imlCli
        Me.tvwConsegne.Indent = 20
        Me.tvwConsegne.ItemHeight = 25
        Me.tvwConsegne.Location = New System.Drawing.Point(3, 51)
        Me.tvwConsegne.Name = "tvwConsegne"
        Me.tvwConsegne.SelectedImageIndex = 0
        Me.tvwConsegne.Size = New System.Drawing.Size(1075, 636)
        Me.tvwConsegne.TabIndex = 142
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "_Calendario.png")
        Me.imlCli.Images.SetKeyName(1, "_user.png")
        Me.imlCli.Images.SetKeyName(2, "_Ordine.png")
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.Location = New System.Drawing.Point(3, 3)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(42, 42)
        Me.btnAggiorna.TabIndex = 143
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'btnConsegnaEffettuata
        '
        Me.btnConsegnaEffettuata.BackColor = System.Drawing.Color.White
        Me.btnConsegnaEffettuata.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnConsegnaEffettuata.Image = Global.Former.My.Resources.Resources._PrendiInCarico
        Me.btnConsegnaEffettuata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsegnaEffettuata.Location = New System.Drawing.Point(51, 3)
        Me.btnConsegnaEffettuata.Name = "btnConsegnaEffettuata"
        Me.btnConsegnaEffettuata.Size = New System.Drawing.Size(185, 42)
        Me.btnConsegnaEffettuata.TabIndex = 144
        Me.btnConsegnaEffettuata.Text = "Consegna Effettuata"
        Me.btnConsegnaEffettuata.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsegnaEffettuata.UseVisualStyleBackColor = False
        '
        'ucOperatoreConfermaConsegne
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnConsegnaEffettuata)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.tvwConsegne)
        Me.Name = "ucOperatoreConfermaConsegne"
        Me.Size = New System.Drawing.Size(1081, 690)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tvwConsegne As TreeView
    Friend WithEvents imlCli As ImageList
    Friend WithEvents btnAggiorna As Button
    Friend WithEvents btnConsegnaEffettuata As Button
End Class
