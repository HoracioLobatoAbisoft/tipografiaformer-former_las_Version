<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMail))
        Me.tabMail = New System.Windows.Forms.TabControl()
        Me.tpPreventiviNew = New System.Windows.Forms.TabPage()
        Me.UcMailManager = New Former.ucMailManager()
        Me.tpPreventivi = New System.Windows.Forms.TabPage()
        Me.UcMailPreventivi = New Former.ucMailPreventivi()
        Me.tpOrdini = New System.Windows.Forms.TabPage()
        Me.UcMailOrdini = New Former.ucMailOrdini()
        Me.imlMail = New System.Windows.Forms.ImageList(Me.components)
        Me.tabMail.SuspendLayout()
        Me.tpPreventiviNew.SuspendLayout()
        Me.tpPreventivi.SuspendLayout()
        Me.tpOrdini.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMail
        '
        Me.tabMail.Controls.Add(Me.tpPreventiviNew)
        Me.tabMail.Controls.Add(Me.tpPreventivi)
        Me.tabMail.Controls.Add(Me.tpOrdini)
        Me.tabMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMail.ImageList = Me.imlMail
        Me.tabMail.Location = New System.Drawing.Point(0, 0)
        Me.tabMail.Name = "tabMail"
        Me.tabMail.SelectedIndex = 0
        Me.tabMail.Size = New System.Drawing.Size(1186, 728)
        Me.tabMail.TabIndex = 0
        '
        'tpPreventiviNew
        '
        Me.tpPreventiviNew.Controls.Add(Me.UcMailManager)
        Me.tpPreventiviNew.ImageKey = "_Risposta.png"
        Me.tpPreventiviNew.Location = New System.Drawing.Point(4, 33)
        Me.tpPreventiviNew.Name = "tpPreventiviNew"
        Me.tpPreventiviNew.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPreventiviNew.Size = New System.Drawing.Size(1178, 691)
        Me.tpPreventiviNew.TabIndex = 2
        Me.tpPreventiviNew.Text = "Preventivi"
        Me.tpPreventiviNew.UseVisualStyleBackColor = True
        '
        'UcMailManager
        '
        Me.UcMailManager.BackColor = System.Drawing.Color.White
        Me.UcMailManager.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMailManager.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMailManager.Location = New System.Drawing.Point(3, 3)
        Me.UcMailManager.Name = "UcMailManager"
        Me.UcMailManager.Size = New System.Drawing.Size(1172, 685)
        Me.UcMailManager.TabIndex = 0
        Me.UcMailManager.TipoMailDaCaricare = FormerLib.FormerEnum.enTipoMail.Preventivo
        '
        'tpPreventivi
        '
        Me.tpPreventivi.Controls.Add(Me.UcMailPreventivi)
        Me.tpPreventivi.ImageKey = "_Risposta.png"
        Me.tpPreventivi.Location = New System.Drawing.Point(4, 33)
        Me.tpPreventivi.Name = "tpPreventivi"
        Me.tpPreventivi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPreventivi.Size = New System.Drawing.Size(1178, 691)
        Me.tpPreventivi.TabIndex = 0
        Me.tpPreventivi.Text = "Preventivi OLD"
        Me.tpPreventivi.UseVisualStyleBackColor = True
        '
        'UcMailPreventivi
        '
        Me.UcMailPreventivi.BackColor = System.Drawing.Color.White
        Me.UcMailPreventivi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMailPreventivi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMailPreventivi.IdRub = 0
        Me.UcMailPreventivi.Location = New System.Drawing.Point(3, 3)
        Me.UcMailPreventivi.Name = "UcMailPreventivi"
        Me.UcMailPreventivi.Size = New System.Drawing.Size(1172, 685)
        Me.UcMailPreventivi.TabIndex = 0
        '
        'tpOrdini
        '
        Me.tpOrdini.Controls.Add(Me.UcMailOrdini)
        Me.tpOrdini.ImageKey = "_Ordine.png"
        Me.tpOrdini.Location = New System.Drawing.Point(4, 33)
        Me.tpOrdini.Name = "tpOrdini"
        Me.tpOrdini.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrdini.Size = New System.Drawing.Size(1178, 691)
        Me.tpOrdini.TabIndex = 1
        Me.tpOrdini.Text = "Ordini"
        Me.tpOrdini.UseVisualStyleBackColor = True
        '
        'UcMailOrdini
        '
        Me.UcMailOrdini.BackColor = System.Drawing.Color.White
        Me.UcMailOrdini.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMailOrdini.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMailOrdini.IdRub = 0
        Me.UcMailOrdini.Location = New System.Drawing.Point(3, 3)
        Me.UcMailOrdini.Name = "UcMailOrdini"
        Me.UcMailOrdini.Size = New System.Drawing.Size(1172, 685)
        Me.UcMailOrdini.TabIndex = 0
        '
        'imlMail
        '
        Me.imlMail.ImageStream = CType(resources.GetObject("imlMail.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMail.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMail.Images.SetKeyName(0, "_Ordine.png")
        Me.imlMail.Images.SetKeyName(1, "_Risposta.png")
        '
        'ucMail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tabMail)
        Me.Name = "ucMail"
        Me.Size = New System.Drawing.Size(1186, 728)
        Me.tabMail.ResumeLayout(False)
        Me.tpPreventiviNew.ResumeLayout(False)
        Me.tpPreventivi.ResumeLayout(False)
        Me.tpOrdini.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabMail As TabControl
    Friend WithEvents tpPreventivi As TabPage
    Friend WithEvents tpOrdini As TabPage
    Friend WithEvents imlMail As ImageList
    Friend WithEvents UcMailPreventivi As ucMailPreventivi
    Friend WithEvents UcMailOrdini As ucMailOrdini
    Friend WithEvents tpPreventiviNew As TabPage
    Friend WithEvents UcMailManager As ucMailManager
End Class
