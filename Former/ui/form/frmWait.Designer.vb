<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWait
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.WaitingBar = New Telerik.WinControls.UI.RadWaitingBar()
        Me.WaitingBarIndicatorElement2 = New Telerik.WinControls.UI.WaitingBarIndicatorElement()
        Me.WaitingBarIndicatorElement1 = New Telerik.WinControls.UI.WaitingBarIndicatorElement()
        Me.tmrWait = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        CType(Me.WaitingBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.AutoEllipsis = True
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(52, 63)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(375, 43)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Attendere prego, operazione in corso..."
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMessage.UseWaitCursor = True
        '
        'WaitingBar
        '
        Me.WaitingBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.WaitingBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.WaitingBar.Location = New System.Drawing.Point(69, 28)
        Me.WaitingBar.Name = "WaitingBar"
        Me.WaitingBar.Size = New System.Drawing.Size(340, 21)
        Me.WaitingBar.TabIndex = 3
        Me.WaitingBar.Text = "RadWaitingBar1"
        Me.WaitingBar.UseWaitCursor = True
        Me.WaitingBar.WaitingIndicators.Add(Me.WaitingBarIndicatorElement2)
        Me.WaitingBar.WaitingIndicators.Add(Me.WaitingBarIndicatorElement1)
        Me.WaitingBar.WaitingIndicatorSize = New System.Drawing.Size(50, 12)
        Me.WaitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Throbber
        CType(Me.WaitingBar.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingIndicatorSize = New System.Drawing.Size(50, 12)
        CType(Me.WaitingBar.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Throbber
        CType(Me.WaitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        CType(Me.WaitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(0, Byte), Integer))
        CType(Me.WaitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        CType(Me.WaitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        CType(Me.WaitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'WaitingBarIndicatorElement2
        '
        Me.WaitingBarIndicatorElement2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.WaitingBarIndicatorElement2.BackColor3 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.WaitingBarIndicatorElement2.Name = "WaitingBarIndicatorElement2"
        Me.WaitingBarIndicatorElement2.StretchHorizontally = False
        '
        'WaitingBarIndicatorElement1
        '
        Me.WaitingBarIndicatorElement1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.WaitingBarIndicatorElement1.BackColor3 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.WaitingBarIndicatorElement1.Name = "WaitingBarIndicatorElement1"
        Me.WaitingBarIndicatorElement1.StretchHorizontally = False
        '
        'tmrWait
        '
        Me.tmrWait.Enabled = True
        Me.tmrWait.Interval = 1000
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.Former.My.Resources.Resources._Wait48
        Me.PictureBox7.Location = New System.Drawing.Point(8, 12)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox7.TabIndex = 43
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.UseWaitCursor = True
        '
        'frmWait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 113)
        Me.ControlBox = False
        Me.Controls.Add(Me.WaitingBar)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.lblMessage)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWait"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Former Gestionale"
        Me.TopMost = True
        Me.UseWaitCursor = True
        CType(Me.WaitingBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMessage As Label
    Friend WithEvents WaitingBar As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents tmrWait As Timer
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents WaitingBarIndicatorElement2 As Telerik.WinControls.UI.WaitingBarIndicatorElement
    Friend WithEvents WaitingBarIndicatorElement1 As Telerik.WinControls.UI.WaitingBarIndicatorElement
End Class
