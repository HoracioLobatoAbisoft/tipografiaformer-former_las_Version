<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDocumentiStato
    Inherits ucFormerUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.chkTutti = New System.Windows.Forms.CheckBox()
        Me.chkRegistrato = New System.Windows.Forms.CheckBox()
        Me.chkPagatoInParte = New System.Windows.Forms.CheckBox()
        Me.chkPagatoTutto = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel
        '
        Me.FlowLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel.Controls.Add(Me.chkTutti)
        Me.FlowLayoutPanel.Controls.Add(Me.chkRegistrato)
        Me.FlowLayoutPanel.Controls.Add(Me.chkPagatoInParte)
        Me.FlowLayoutPanel.Controls.Add(Me.chkPagatoTutto)
        Me.FlowLayoutPanel.Location = New System.Drawing.Point(1, 1)
        Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
        Me.FlowLayoutPanel.Size = New System.Drawing.Size(400, 29)
        Me.FlowLayoutPanel.TabIndex = 11
        '
        'chkTutti
        '
        Me.chkTutti.AutoSize = True
        Me.chkTutti.Location = New System.Drawing.Point(3, 3)
        Me.chkTutti.Name = "chkTutti"
        Me.chkTutti.Size = New System.Drawing.Size(49, 19)
        Me.chkTutti.TabIndex = 9
        Me.chkTutti.Text = "Tutti"
        Me.chkTutti.UseVisualStyleBackColor = True
        '
        'chkRegistrato
        '
        Me.chkRegistrato.AutoSize = True
        Me.chkRegistrato.Checked = True
        Me.chkRegistrato.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRegistrato.Location = New System.Drawing.Point(58, 3)
        Me.chkRegistrato.Name = "chkRegistrato"
        Me.chkRegistrato.Size = New System.Drawing.Size(83, 19)
        Me.chkRegistrato.TabIndex = 0
        Me.chkRegistrato.Text = "Registrato"
        Me.chkRegistrato.UseVisualStyleBackColor = True
        '
        'chkPagatoInParte
        '
        Me.chkPagatoInParte.AutoSize = True
        Me.chkPagatoInParte.Location = New System.Drawing.Point(147, 3)
        Me.chkPagatoInParte.Name = "chkPagatoInParte"
        Me.chkPagatoInParte.Size = New System.Drawing.Size(110, 19)
        Me.chkPagatoInParte.TabIndex = 1
        Me.chkPagatoInParte.Text = "Pagato Acconto"
        Me.chkPagatoInParte.UseVisualStyleBackColor = True
        '
        'chkPagatoTutto
        '
        Me.chkPagatoTutto.AutoSize = True
        Me.chkPagatoTutto.Location = New System.Drawing.Point(263, 3)
        Me.chkPagatoTutto.Name = "chkPagatoTutto"
        Me.chkPagatoTutto.Size = New System.Drawing.Size(134, 19)
        Me.chkPagatoTutto.TabIndex = 10
        Me.chkPagatoTutto.Text = "Pagato Interamente"
        Me.chkPagatoTutto.UseVisualStyleBackColor = True
        '
        'ucStatoDocumenti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.FlowLayoutPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucStatoDocumenti"
        Me.Size = New System.Drawing.Size(405, 31)
        Me.FlowLayoutPanel.ResumeLayout(False)
        Me.FlowLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents chkTutti As System.Windows.Forms.CheckBox
    Friend WithEvents chkRegistrato As System.Windows.Forms.CheckBox
    Friend WithEvents chkPagatoInParte As System.Windows.Forms.CheckBox
    Friend WithEvents chkPagatoTutto As System.Windows.Forms.CheckBox

End Class
