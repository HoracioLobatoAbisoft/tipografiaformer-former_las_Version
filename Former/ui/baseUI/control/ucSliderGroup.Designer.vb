<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSliderGroup
    Inherits System.Windows.Forms.UserControl

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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucSliderGroup))
        Me.pnlMain = New System.Windows.Forms.FlowLayoutPanel()
        Me.UcLabelSlider1 = New Former.ucLabelSlider()
        Me.ToolMain = New System.Windows.Forms.ToolStrip()
        Me.btnRiassunto = New System.Windows.Forms.ToolStripButton()
        Me.btnExpandAll = New System.Windows.Forms.ToolStripButton()
        Me.pnlMain.SuspendLayout()
        Me.ToolMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.AutoSize = True
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.UcLabelSlider1)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlMain.Location = New System.Drawing.Point(0, 25)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(83, 205)
        Me.pnlMain.TabIndex = 108
        Me.pnlMain.WrapContents = False
        '
        'UcLabelSlider1
        '
        Me.UcLabelSlider1.AutoSize = True
        Me.UcLabelSlider1.BackColor = System.Drawing.Color.White
        Me.UcLabelSlider1.CustomBackColor = System.Drawing.Color.White
        Me.UcLabelSlider1.CustomIcon = Nothing
        Me.UcLabelSlider1.CustomLongMessage = ""
        Me.UcLabelSlider1.CustomSigla = "-"
        Me.UcLabelSlider1.CustomSiglaForeColor = System.Drawing.SystemColors.ControlText
        Me.UcLabelSlider1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcLabelSlider1.Location = New System.Drawing.Point(3, 3)
        Me.UcLabelSlider1.Margin = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.UcLabelSlider1.Name = "UcLabelSlider1"
        Me.UcLabelSlider1.Size = New System.Drawing.Size(78, 28)
        Me.UcLabelSlider1.TabIndex = 0
        '
        'ToolMain
        '
        Me.ToolMain.BackColor = System.Drawing.Color.Gray
        Me.ToolMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRiassunto, Me.btnExpandAll})
        Me.ToolMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolMain.Name = "ToolMain"
        Me.ToolMain.Size = New System.Drawing.Size(83, 25)
        Me.ToolMain.TabIndex = 109
        Me.ToolMain.Text = "ToolStrip1"
        '
        'btnRiassunto
        '
        Me.btnRiassunto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRiassunto.Image = Global.Former.My.Resources.Resources._stop
        Me.btnRiassunto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRiassunto.Name = "btnRiassunto"
        Me.btnRiassunto.Size = New System.Drawing.Size(23, 22)
        Me.btnRiassunto.Text = "-"
        Me.btnRiassunto.ToolTipText = "Riassunto"
        '
        'btnExpandAll
        '
        Me.btnExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExpandAll.Image = CType(resources.GetObject("btnExpandAll.Image"), System.Drawing.Image)
        Me.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExpandAll.Name = "btnExpandAll"
        Me.btnExpandAll.Size = New System.Drawing.Size(23, 22)
        Me.btnExpandAll.Text = "-"
        Me.btnExpandAll.ToolTipText = "Espandi"
        '
        'ucSliderGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.ToolMain)
        Me.Name = "ucSliderGroup"
        Me.Size = New System.Drawing.Size(83, 230)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ToolMain.ResumeLayout(False)
        Me.ToolMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlMain As FlowLayoutPanel
    Friend WithEvents ToolMain As ToolStrip
    Friend WithEvents btnRiassunto As ToolStripButton
    Friend WithEvents btnExpandAll As ToolStripButton
    Friend WithEvents UcLabelSlider1 As ucLabelSlider
End Class
