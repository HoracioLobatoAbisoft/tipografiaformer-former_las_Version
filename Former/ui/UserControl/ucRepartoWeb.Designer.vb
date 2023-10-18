<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucRepartoWeb
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
        Me.chkEtichette = New System.Windows.Forms.CheckBox()
        Me.chkRicamo = New System.Windows.Forms.CheckBox()
        Me.chkPackaging = New System.Windows.Forms.CheckBox()
        Me.chkStampaDigitale = New System.Windows.Forms.CheckBox()
        Me.chkStampaOffset = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'chkEtichette
        '
        Me.chkEtichette.AutoSize = True
        Me.chkEtichette.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.chkEtichette.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkEtichette.ForeColor = System.Drawing.Color.White
        Me.chkEtichette.Location = New System.Drawing.Point(405, 3)
        Me.chkEtichette.Name = "chkEtichette"
        Me.chkEtichette.Size = New System.Drawing.Size(76, 19)
        Me.chkEtichette.TabIndex = 71
        Me.chkEtichette.Text = "Etichette"
        Me.chkEtichette.UseVisualStyleBackColor = False
        '
        'chkRicamo
        '
        Me.chkRicamo.AutoSize = True
        Me.chkRicamo.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.chkRicamo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkRicamo.ForeColor = System.Drawing.Color.Black
        Me.chkRicamo.Location = New System.Drawing.Point(330, 3)
        Me.chkRicamo.Name = "chkRicamo"
        Me.chkRicamo.Size = New System.Drawing.Size(69, 19)
        Me.chkRicamo.TabIndex = 70
        Me.chkRicamo.Text = "Ricamo"
        Me.chkRicamo.UseVisualStyleBackColor = False
        '
        'chkPackaging
        '
        Me.chkPackaging.AutoSize = True
        Me.chkPackaging.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.chkPackaging.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkPackaging.ForeColor = System.Drawing.Color.White
        Me.chkPackaging.Location = New System.Drawing.Point(238, 3)
        Me.chkPackaging.Name = "chkPackaging"
        Me.chkPackaging.Size = New System.Drawing.Size(86, 19)
        Me.chkPackaging.TabIndex = 69
        Me.chkPackaging.Text = "Packaging"
        Me.chkPackaging.UseVisualStyleBackColor = False
        '
        'chkStampaDigitale
        '
        Me.chkStampaDigitale.AutoSize = True
        Me.chkStampaDigitale.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.chkStampaDigitale.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkStampaDigitale.ForeColor = System.Drawing.Color.White
        Me.chkStampaDigitale.Location = New System.Drawing.Point(117, 3)
        Me.chkStampaDigitale.Name = "chkStampaDigitale"
        Me.chkStampaDigitale.Size = New System.Drawing.Size(115, 19)
        Me.chkStampaDigitale.TabIndex = 68
        Me.chkStampaDigitale.Text = "Stampa Digitale"
        Me.chkStampaDigitale.UseVisualStyleBackColor = False
        '
        'chkStampaOffset
        '
        Me.chkStampaOffset.AutoSize = True
        Me.chkStampaOffset.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.chkStampaOffset.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkStampaOffset.ForeColor = System.Drawing.Color.White
        Me.chkStampaOffset.Location = New System.Drawing.Point(3, 3)
        Me.chkStampaOffset.Name = "chkStampaOffset"
        Me.chkStampaOffset.Size = New System.Drawing.Size(108, 19)
        Me.chkStampaOffset.TabIndex = 67
        Me.chkStampaOffset.Text = "Stampa Offset"
        Me.chkStampaOffset.UseVisualStyleBackColor = False
        '
        'ucRepartoWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.chkEtichette)
        Me.Controls.Add(Me.chkRicamo)
        Me.Controls.Add(Me.chkPackaging)
        Me.Controls.Add(Me.chkStampaDigitale)
        Me.Controls.Add(Me.chkStampaOffset)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucRepartoWeb"
        Me.Size = New System.Drawing.Size(484, 25)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkEtichette As CheckBox
    Friend WithEvents chkRicamo As CheckBox
    Friend WithEvents chkPackaging As CheckBox
    Friend WithEvents chkStampaDigitale As CheckBox
    Friend WithEvents chkStampaOffset As CheckBox
End Class
