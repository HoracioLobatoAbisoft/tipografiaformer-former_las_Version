<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTextGet
    Inherits baseFormInternaFixed

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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnConferma = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tpHelp = New System.Windows.Forms.TabPage()
        Me.txtBuffer = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tpHelp.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnConferma)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 376)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(909, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnConferma
        '
        Me.btnConferma.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConferma.AutoSize = True
        Me.btnConferma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnConferma.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnConferma.FlatAppearance.BorderSize = 0
        Me.btnConferma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConferma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnConferma.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnConferma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConferma.Location = New System.Drawing.Point(727, 12)
        Me.btnConferma.Name = "btnConferma"
        Me.btnConferma.Size = New System.Drawing.Size(92, 32)
        Me.btnConferma.TabIndex = 17
        Me.btnConferma.Text = "Conferma"
        Me.btnConferma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConferma.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(825, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Annulla"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tpHelp)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(909, 376)
        Me.TabMain.TabIndex = 6
        '
        'tpHelp
        '
        Me.tpHelp.Controls.Add(Me.txtBuffer)
        Me.tpHelp.Controls.Add(Me.lblMessage)
        Me.tpHelp.Location = New System.Drawing.Point(4, 22)
        Me.tpHelp.Name = "tpHelp"
        Me.tpHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHelp.Size = New System.Drawing.Size(901, 350)
        Me.tpHelp.TabIndex = 1
        Me.tpHelp.Text = "Former - Inserisci le informazioni richieste"
        Me.tpHelp.UseVisualStyleBackColor = True
        '
        'txtBuffer
        '
        Me.txtBuffer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBuffer.Location = New System.Drawing.Point(3, 36)
        Me.txtBuffer.Multiline = True
        Me.txtBuffer.Name = "txtBuffer"
        Me.txtBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBuffer.Size = New System.Drawing.Size(895, 311)
        Me.txtBuffer.TabIndex = 0
        '
        'lblMessage
        '
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblMessage.Location = New System.Drawing.Point(3, 3)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(895, 33)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "-"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmTextGet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(909, 424)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTextGet"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - "
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tpHelp.ResumeLayout(False)
        Me.tpHelp.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpHelp As System.Windows.Forms.TabPage
    Friend WithEvents txtBuffer As TextBox
    Friend WithEvents btnConferma As Button
    Friend WithEvents lblMessage As Label
End Class
