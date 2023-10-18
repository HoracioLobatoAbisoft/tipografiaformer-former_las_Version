<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmContabilitaEditIntestazioneDocumento
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIndirizzo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCitta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCap = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPiva = New System.Windows.Forms.TextBox()
        Me.cmbRagSoc = New System.Windows.Forms.ComboBox()
        Me.txtpRagSoc = New System.Windows.Forms.TextBox()
        Me.gbPulsanti.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(12, 186)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(631, 57)
        Me.gbPulsanti.TabIndex = 6
        Me.gbPulsanti.TabStop = False
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
        Me.btnCancel.Location = New System.Drawing.Point(465, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(158, 36)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi senza salvare"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(8, 15)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(128, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Salva modifiche"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Ragione Sociale/Nominativo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Indirizzo"
        '
        'txtIndirizzo
        '
        Me.txtIndirizzo.Location = New System.Drawing.Point(12, 70)
        Me.txtIndirizzo.MaxLength = 250
        Me.txtIndirizzo.Name = "txtIndirizzo"
        Me.txtIndirizzo.Size = New System.Drawing.Size(631, 20)
        Me.txtIndirizzo.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Città"
        '
        'txtCitta
        '
        Me.txtCitta.Location = New System.Drawing.Point(12, 112)
        Me.txtCitta.MaxLength = 50
        Me.txtCitta.Name = "txtCitta"
        Me.txtCitta.Size = New System.Drawing.Size(283, 20)
        Me.txtCitta.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(298, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "CAP"
        '
        'txtCap
        '
        Me.txtCap.Location = New System.Drawing.Point(301, 112)
        Me.txtCap.MaxLength = 5
        Me.txtCap.Name = "txtCap"
        Me.txtCap.Size = New System.Drawing.Size(76, 20)
        Me.txtCap.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "P.Iva /Cod. Fiscale"
        '
        'txtPiva
        '
        Me.txtPiva.Location = New System.Drawing.Point(12, 154)
        Me.txtPiva.MaxLength = 16
        Me.txtPiva.Name = "txtPiva"
        Me.txtPiva.Size = New System.Drawing.Size(283, 20)
        Me.txtPiva.TabIndex = 15
        '
        'cmbRagSoc
        '
        Me.cmbRagSoc.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbRagSoc.FormattingEnabled = True
        Me.cmbRagSoc.Location = New System.Drawing.Point(12, 24)
        Me.cmbRagSoc.Name = "cmbRagSoc"
        Me.cmbRagSoc.Size = New System.Drawing.Size(631, 23)
        Me.cmbRagSoc.TabIndex = 17
        '
        'txtpRagSoc
        '
        Me.txtpRagSoc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtpRagSoc.Location = New System.Drawing.Point(12, 24)
        Me.txtpRagSoc.Name = "txtpRagSoc"
        Me.txtpRagSoc.Size = New System.Drawing.Size(613, 23)
        Me.txtpRagSoc.TabIndex = 18
        '
        'frmContabilitaEditIntestazioneDocumento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(655, 261)
        Me.Controls.Add(Me.txtpRagSoc)
        Me.Controls.Add(Me.cmbRagSoc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPiva)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCap)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCitta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIndirizzo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbPulsanti)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmContabilitaEditIntestazioneDocumento"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Intestazione Documento Contabile"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbPulsanti As GroupBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtIndirizzo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCitta As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCap As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPiva As TextBox
    Friend WithEvents cmbRagSoc As ComboBox
    Friend WithEvents txtpRagSoc As TextBox
End Class
