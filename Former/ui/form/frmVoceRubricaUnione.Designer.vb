<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVoceRubricaUnione
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
        Me.components = New System.ComponentModel.Container()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnSfoglia2 = New System.Windows.Forms.Button()
        Me.btnSfoglia1 = New System.Windows.Forms.Button()
        Me.lblIdSeconda = New System.Windows.Forms.Label()
        Me.lblIdPrima = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSeconda = New Former.ucComboRubrica()
        Me.cmbPrima = New Former.ucComboRubrica()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 358)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(838, 48)
        Me.gbPulsanti.TabIndex = 5
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
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(754, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Merge
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(672, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(76, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Unisci"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(838, 358)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnSfoglia2)
        Me.tbProd.Controls.Add(Me.btnSfoglia1)
        Me.tbProd.Controls.Add(Me.lblIdSeconda)
        Me.tbProd.Controls.Add(Me.lblIdPrima)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbSeconda)
        Me.tbProd.Controls.Add(Me.cmbPrima)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(830, 332)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Unione Voce Rubrica"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnSfoglia2
        '
        Me.btnSfoglia2.Location = New System.Drawing.Point(797, 129)
        Me.btnSfoglia2.Name = "btnSfoglia2"
        Me.btnSfoglia2.Size = New System.Drawing.Size(25, 23)
        Me.btnSfoglia2.TabIndex = 112
        Me.btnSfoglia2.Text = "..."
        Me.btnSfoglia2.UseVisualStyleBackColor = True
        '
        'btnSfoglia1
        '
        Me.btnSfoglia1.Location = New System.Drawing.Point(797, 55)
        Me.btnSfoglia1.Name = "btnSfoglia1"
        Me.btnSfoglia1.Size = New System.Drawing.Size(25, 23)
        Me.btnSfoglia1.TabIndex = 111
        Me.btnSfoglia1.Text = "..."
        Me.btnSfoglia1.UseVisualStyleBackColor = True
        '
        'lblIdSeconda
        '
        Me.lblIdSeconda.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSeconda.Location = New System.Drawing.Point(723, 157)
        Me.lblIdSeconda.Name = "lblIdSeconda"
        Me.lblIdSeconda.Size = New System.Drawing.Size(41, 13)
        Me.lblIdSeconda.TabIndex = 27
        Me.lblIdSeconda.Text = "-"
        Me.lblIdSeconda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIdPrima
        '
        Me.lblIdPrima.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdPrima.Location = New System.Drawing.Point(723, 84)
        Me.lblIdPrima.Name = "lblIdPrima"
        Me.lblIdPrima.Size = New System.Drawing.Size(41, 13)
        Me.lblIdPrima.TabIndex = 26
        Me.lblIdPrima.Text = "-"
        Me.lblIdPrima.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(183, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(370, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "(questa sarà la voce che verrà mantenuta al termine della procedura)"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.PictureBox1.Location = New System.Drawing.Point(144, 194)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(176, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(483, 94)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Attenzione! L'operazione non è reversibile." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Al termine della procedura sarà ma" &
    "ntenuta solo la PRIMA VOCE RUBRICA selezionata." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "La seconda verrà eliminata."
        '
        'cmbSeconda
        '
        Me.cmbSeconda.BackColor = System.Drawing.Color.White
        Me.cmbSeconda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbSeconda.IdRubSelezionato = 0
        Me.cmbSeconda.Location = New System.Drawing.Point(186, 129)
        Me.cmbSeconda.Name = "cmbSeconda"
        Me.cmbSeconda.Size = New System.Drawing.Size(605, 25)
        Me.cmbSeconda.TabIndex = 22
        '
        'cmbPrima
        '
        Me.cmbPrima.BackColor = System.Drawing.Color.White
        Me.cmbPrima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPrima.IdRubSelezionato = 0
        Me.cmbPrima.Location = New System.Drawing.Point(186, 55)
        Me.cmbPrima.Name = "cmbPrima"
        Me.cmbPrima.Size = New System.Drawing.Size(605, 25)
        Me.cmbPrima.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Seconda Voce Rubrica"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Prima Voce Rubrica"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.user_1_
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
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(169, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Unione Voce Rubrica"
        '
        'frmVoceRubricaUnione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(838, 406)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmVoceRubricaUnione"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Unione Voce Rubrica"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSeconda As ucComboRubrica
    Friend WithEvents cmbPrima As ucComboRubrica
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblIdSeconda As Label
    Friend WithEvents lblIdPrima As Label
    Friend WithEvents btnSfoglia2 As Button
    Friend WithEvents btnSfoglia1 As Button
End Class
