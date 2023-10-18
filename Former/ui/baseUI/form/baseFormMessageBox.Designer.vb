<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class baseFormMessageBox
    Inherits baseFormInterna

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(baseFormMessageBox))
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnConferma = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlOk = New System.Windows.Forms.Panel()
        Me.pnlConfirmCancel = New System.Windows.Forms.Panel()
        Me.PnlSiNo = New System.Windows.Forms.Panel()
        Me.btnSi = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.pctMsg = New System.Windows.Forms.PictureBox()
        Me.pnlOk.SuspendLayout()
        Me.pnlConfirmCancel.SuspendLayout()
        Me.PnlSiNo.SuspendLayout()
        CType(Me.pctMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(66, 12)
        Me.lblMessage.MaximumSize = New System.Drawing.Size(882, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(15, 19)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "-"
        '
        'btnOk
        '
        Me.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnOk.FlatAppearance.BorderSize = 2
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Location = New System.Drawing.Point(101, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(90, 32)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnConferma
        '
        Me.btnConferma.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnConferma.FlatAppearance.BorderSize = 2
        Me.btnConferma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConferma.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnConferma.ForeColor = System.Drawing.Color.White
        Me.btnConferma.Location = New System.Drawing.Point(31, 0)
        Me.btnConferma.Name = "btnConferma"
        Me.btnConferma.Size = New System.Drawing.Size(90, 32)
        Me.btnConferma.TabIndex = 2
        Me.btnConferma.Text = "Conferma"
        Me.btnConferma.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(175, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Annulla"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlOk
        '
        Me.pnlOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlOk.Controls.Add(Me.btnOk)
        Me.pnlOk.Location = New System.Drawing.Point(331, 90)
        Me.pnlOk.Name = "pnlOk"
        Me.pnlOk.Size = New System.Drawing.Size(297, 32)
        Me.pnlOk.TabIndex = 4
        '
        'pnlConfirmCancel
        '
        Me.pnlConfirmCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlConfirmCancel.Controls.Add(Me.btnConferma)
        Me.pnlConfirmCancel.Controls.Add(Me.btnCancel)
        Me.pnlConfirmCancel.Location = New System.Drawing.Point(331, 90)
        Me.pnlConfirmCancel.Name = "pnlConfirmCancel"
        Me.pnlConfirmCancel.Size = New System.Drawing.Size(297, 32)
        Me.pnlConfirmCancel.TabIndex = 5
        Me.pnlConfirmCancel.Visible = False
        '
        'PnlSiNo
        '
        Me.PnlSiNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PnlSiNo.Controls.Add(Me.btnSi)
        Me.PnlSiNo.Controls.Add(Me.btnNo)
        Me.PnlSiNo.Location = New System.Drawing.Point(332, 90)
        Me.PnlSiNo.Name = "PnlSiNo"
        Me.PnlSiNo.Size = New System.Drawing.Size(297, 32)
        Me.PnlSiNo.TabIndex = 6
        Me.PnlSiNo.Visible = False
        '
        'btnSi
        '
        Me.btnSi.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnSi.FlatAppearance.BorderSize = 2
        Me.btnSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSi.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSi.ForeColor = System.Drawing.Color.White
        Me.btnSi.Location = New System.Drawing.Point(31, 0)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(90, 32)
        Me.btnSi.TabIndex = 2
        Me.btnSi.Text = "Si"
        Me.btnSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnNo.FlatAppearance.BorderSize = 2
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNo.ForeColor = System.Drawing.Color.White
        Me.btnNo.Location = New System.Drawing.Point(175, 0)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(90, 32)
        Me.btnNo.TabIndex = 3
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'pctMsg
        '
        Me.pctMsg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pctMsg.Image = Global.Former.My.Resources.Resources.warningscudo
        Me.pctMsg.Location = New System.Drawing.Point(12, 12)
        Me.pctMsg.Name = "pctMsg"
        Me.pctMsg.Size = New System.Drawing.Size(48, 48)
        Me.pctMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctMsg.TabIndex = 0
        Me.pctMsg.TabStop = False
        '
        'baseFormMessageBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(961, 130)
        Me.Controls.Add(Me.PnlSiNo)
        Me.Controls.Add(Me.pnlConfirmCancel)
        Me.Controls.Add(Me.pnlOk)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.pctMsg)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "baseFormMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Former - Alert"
        Me.pnlOk.ResumeLayout(False)
        Me.pnlConfirmCancel.ResumeLayout(False)
        Me.PnlSiNo.ResumeLayout(False)
        CType(Me.pctMsg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pctMsg As System.Windows.Forms.PictureBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnConferma As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlOk As System.Windows.Forms.Panel
    Friend WithEvents pnlConfirmCancel As System.Windows.Forms.Panel
    Friend WithEvents PnlSiNo As System.Windows.Forms.Panel
    Friend WithEvents btnSi As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
End Class
