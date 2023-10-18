<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucOperatoreImballaggioCorriere
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucOperatoreImballaggioCorriere))
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.chkSoloDaImballCorr = New System.Windows.Forms.CheckBox()
        Me.chkSoloProntiRitiroCorr = New System.Windows.Forms.CheckBox()
        Me.tvClienti = New System.Windows.Forms.TreeView()
        Me.UcFiltroCorriereImballoCorriere = New Former.ucFiltroCorriere()
        Me.btnGestCons = New System.Windows.Forms.Button()
        Me.btnForzaChiusuraCons = New System.Windows.Forms.Button()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "icoCli.jpg")
        Me.imlCli.Images.SetKeyName(1, "icoOrder.jpg")
        Me.imlCli.Images.SetKeyName(2, "icoPrint.jpg")
        Me.imlCli.Images.SetKeyName(3, "icoMoney.jpg")
        Me.imlCli.Images.SetKeyName(4, "icoRubRed.jpg")
        Me.imlCli.Images.SetKeyName(5, "icoParamRed.jpg")
        Me.imlCli.Images.SetKeyName(6, "Corriere.png")
        Me.imlCli.Images.SetKeyName(7, "icoCal.jpg")
        Me.imlCli.Images.SetKeyName(8, "IcoFast.png")
        Me.imlCli.Images.SetKeyName(9, "IcoLow.png")
        Me.imlCli.Images.SetKeyName(10, "Box.bmp")
        Me.imlCli.Images.SetKeyName(11, "Clock.png")
        Me.imlCli.Images.SetKeyName(12, "Home.png")
        '
        'cmbZona
        '
        Me.cmbZona.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(650, 3)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(167, 23)
        Me.cmbZona.TabIndex = 146
        '
        'chkSoloDaImballCorr
        '
        Me.chkSoloDaImballCorr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSoloDaImballCorr.AutoSize = True
        Me.chkSoloDaImballCorr.Location = New System.Drawing.Point(658, 30)
        Me.chkSoloDaImballCorr.Name = "chkSoloDaImballCorr"
        Me.chkSoloDaImballCorr.Size = New System.Drawing.Size(160, 19)
        Me.chkSoloDaImballCorr.TabIndex = 145
        Me.chkSoloDaImballCorr.Text = "Solo da imballare corriere"
        Me.chkSoloDaImballCorr.UseVisualStyleBackColor = True
        '
        'chkSoloProntiRitiroCorr
        '
        Me.chkSoloProntiRitiroCorr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSoloProntiRitiroCorr.AutoSize = True
        Me.chkSoloProntiRitiroCorr.Location = New System.Drawing.Point(825, 30)
        Me.chkSoloProntiRitiroCorr.Name = "chkSoloProntiRitiroCorr"
        Me.chkSoloProntiRitiroCorr.Size = New System.Drawing.Size(141, 19)
        Me.chkSoloProntiRitiroCorr.TabIndex = 143
        Me.chkSoloProntiRitiroCorr.Text = "Solo pronti per il ritiro"
        Me.chkSoloProntiRitiroCorr.UseVisualStyleBackColor = True
        '
        'tvClienti
        '
        Me.tvClienti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvClienti.ImageIndex = 0
        Me.tvClienti.ImageList = Me.imlCli
        Me.tvClienti.Indent = 20
        Me.tvClienti.ItemHeight = 25
        Me.tvClienti.Location = New System.Drawing.Point(3, 51)
        Me.tvClienti.Name = "tvClienti"
        Me.tvClienti.SelectedImageIndex = 0
        Me.tvClienti.Size = New System.Drawing.Size(963, 570)
        Me.tvClienti.TabIndex = 139
        '
        'UcFiltroCorriereImballoCorriere
        '
        Me.UcFiltroCorriereImballoCorriere.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcFiltroCorriereImballoCorriere.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UcFiltroCorriereImballoCorriere.BackColor = System.Drawing.Color.White
        Me.UcFiltroCorriereImballoCorriere.CorriereSelezionatoEnum = 0
        Me.UcFiltroCorriereImballoCorriere.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcFiltroCorriereImballoCorriere.Location = New System.Drawing.Point(820, 3)
        Me.UcFiltroCorriereImballoCorriere.Margin = New System.Windows.Forms.Padding(0)
        Me.UcFiltroCorriereImballoCorriere.Name = "UcFiltroCorriereImballoCorriere"
        Me.UcFiltroCorriereImballoCorriere.Size = New System.Drawing.Size(146, 27)
        Me.UcFiltroCorriereImballoCorriere.TabIndex = 144
        '
        'btnGestCons
        '
        Me.btnGestCons.BackColor = System.Drawing.Color.White
        Me.btnGestCons.Image = Global.Former.My.Resources.Resources._ManageConsegna
        Me.btnGestCons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGestCons.Location = New System.Drawing.Point(51, 3)
        Me.btnGestCons.Name = "btnGestCons"
        Me.btnGestCons.Size = New System.Drawing.Size(150, 42)
        Me.btnGestCons.TabIndex = 142
        Me.btnGestCons.Text = "Gestisci Consegna"
        Me.btnGestCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGestCons.UseVisualStyleBackColor = False
        '
        'btnForzaChiusuraCons
        '
        Me.btnForzaChiusuraCons.BackColor = System.Drawing.Color.White
        Me.btnForzaChiusuraCons.FlatAppearance.BorderSize = 0
        Me.btnForzaChiusuraCons.Image = Global.Former.My.Resources.Resources._ClosedBox
        Me.btnForzaChiusuraCons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnForzaChiusuraCons.Location = New System.Drawing.Point(207, 3)
        Me.btnForzaChiusuraCons.Name = "btnForzaChiusuraCons"
        Me.btnForzaChiusuraCons.Size = New System.Drawing.Size(174, 42)
        Me.btnForzaChiusuraCons.TabIndex = 141
        Me.btnForzaChiusuraCons.Text = "Forza chiusura Consegna"
        Me.btnForzaChiusuraCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnForzaChiusuraCons.UseVisualStyleBackColor = False
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.Location = New System.Drawing.Point(3, 3)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(42, 42)
        Me.btnAggiorna.TabIndex = 140
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'ucOperatoreImballaggioCorriere
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.cmbZona)
        Me.Controls.Add(Me.chkSoloDaImballCorr)
        Me.Controls.Add(Me.chkSoloProntiRitiroCorr)
        Me.Controls.Add(Me.btnGestCons)
        Me.Controls.Add(Me.btnForzaChiusuraCons)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.tvClienti)
        Me.Controls.Add(Me.UcFiltroCorriereImballoCorriere)
        Me.Name = "ucOperatoreImballaggioCorriere"
        Me.Size = New System.Drawing.Size(969, 624)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkSoloDaImballCorr As CheckBox
    Friend WithEvents chkSoloProntiRitiroCorr As CheckBox
    Friend WithEvents btnGestCons As Button
    Friend WithEvents btnForzaChiusuraCons As Button
    Friend WithEvents btnAggiorna As Button
    Friend WithEvents tvClienti As TreeView
    Friend WithEvents UcFiltroCorriereImballoCorriere As ucFiltroCorriere
    Friend WithEvents cmbZona As ComboBox
    Friend WithEvents imlCli As ImageList
End Class
