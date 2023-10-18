<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOldCheckMail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOldCheckMail))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.TabMain = New System.Windows.Forms.TabControl
        Me.tbProd = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTotOrdiniVal = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTotOrdini = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.progressBarMail = New System.Windows.Forms.ProgressBar
        Me.lblCurrentMail = New System.Windows.Forms.Label
        Me.lblTotMail = New System.Windows.Forms.Label
        Me.pctTipo = New System.Windows.Forms.PictureBox
        Me.lblTipo = New System.Windows.Forms.Label
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(9, 268)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(602, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources.icoCancel
        Me.btnCancel.Location = New System.Drawing.Point(566, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Image = Global.Former.My.Resources.Resources.icoOk
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(64, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(129, 30)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Scarica ordini..."
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(9, 12)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(602, 256)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.lblTotOrdiniVal)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.lblTotOrdini)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.progressBarMail)
        Me.tbProd.Controls.Add(Me.lblCurrentMail)
        Me.tbProd.Controls.Add(Me.lblTotMail)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(594, 228)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Controllo ordini email"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 15)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Ordini validi:"
        '
        'lblTotOrdiniVal
        '
        Me.lblTotOrdiniVal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotOrdiniVal.Location = New System.Drawing.Point(285, 174)
        Me.lblTotOrdiniVal.Name = "lblTotOrdiniVal"
        Me.lblTotOrdiniVal.Size = New System.Drawing.Size(94, 15)
        Me.lblTotOrdiniVal.TabIndex = 55
        Me.lblTotOrdiniVal.Text = "0"
        Me.lblTotOrdiniVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Ordini trovati:"
        '
        'lblTotOrdini
        '
        Me.lblTotOrdini.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotOrdini.Location = New System.Drawing.Point(285, 150)
        Me.lblTotOrdini.Name = "lblTotOrdini"
        Me.lblTotOrdini.Size = New System.Drawing.Size(94, 15)
        Me.lblTotOrdini.TabIndex = 53
        Me.lblTotOrdini.Text = "0"
        Me.lblTotOrdini.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 15)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Messaggio attualmente in download:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(57, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 15)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Messaggi totali nella casella email:"
        '
        'progressBarMail
        '
        Me.progressBarMail.Location = New System.Drawing.Point(60, 60)
        Me.progressBarMail.Name = "progressBarMail"
        Me.progressBarMail.Size = New System.Drawing.Size(496, 23)
        Me.progressBarMail.TabIndex = 50
        '
        'lblCurrentMail
        '
        Me.lblCurrentMail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentMail.Location = New System.Drawing.Point(285, 125)
        Me.lblCurrentMail.Name = "lblCurrentMail"
        Me.lblCurrentMail.Size = New System.Drawing.Size(94, 15)
        Me.lblCurrentMail.TabIndex = 49
        Me.lblCurrentMail.Text = "0"
        Me.lblCurrentMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotMail
        '
        Me.lblTotMail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotMail.Location = New System.Drawing.Point(285, 101)
        Me.lblTotMail.Name = "lblTotMail"
        Me.lblTotMail.Size = New System.Drawing.Size(94, 15)
        Me.lblTotMail.TabIndex = 48
        Me.lblTotMail.Text = "0"
        Me.lblTotMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.icoEmail
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(102, 22)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Ordini FTP"
        '
        'frmCheckMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(621, 326)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCheckMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - "
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblCurrentMail As System.Windows.Forms.Label
    Friend WithEvents lblTotMail As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents progressBarMail As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotOrdiniVal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotOrdini As System.Windows.Forms.Label
End Class
