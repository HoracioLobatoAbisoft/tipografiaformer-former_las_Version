<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndirizzo
    Inherits baseFormInternaRedim

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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbIndirizzo = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbNazione = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDestinatario = New System.Windows.Forms.TextBox()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkFermoDeposito = New System.Windows.Forms.LinkLabel()
        Me.chkDisattiva = New System.Windows.Forms.CheckBox()
        Me.chkPredefinito = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCAP = New Former.ucNumericTextBox()
        Me.txtIndirizzo = New System.Windows.Forms.TextBox()
        Me.cmbLocalita = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRiferimento = New System.Windows.Forms.TextBox()
        Me.lblTitolo = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pctCheck = New System.Windows.Forms.PictureBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbIndirizzo.SuspendLayout()
        CType(Me.pctCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 321)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(529, 44)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbIndirizzo)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(529, 321)
        Me.TabMain.TabIndex = 6
        '
        'tbIndirizzo
        '
        Me.tbIndirizzo.Controls.Add(Me.Label6)
        Me.tbIndirizzo.Controls.Add(Me.cmbNazione)
        Me.tbIndirizzo.Controls.Add(Me.pctCheck)
        Me.tbIndirizzo.Controls.Add(Me.Label5)
        Me.tbIndirizzo.Controls.Add(Me.txtDestinatario)
        Me.tbIndirizzo.Controls.Add(Me.txtTel)
        Me.tbIndirizzo.Controls.Add(Me.Label4)
        Me.tbIndirizzo.Controls.Add(Me.lnkFermoDeposito)
        Me.tbIndirizzo.Controls.Add(Me.chkDisattiva)
        Me.tbIndirizzo.Controls.Add(Me.chkPredefinito)
        Me.tbIndirizzo.Controls.Add(Me.Label3)
        Me.tbIndirizzo.Controls.Add(Me.Label1)
        Me.tbIndirizzo.Controls.Add(Me.txtCAP)
        Me.tbIndirizzo.Controls.Add(Me.txtIndirizzo)
        Me.tbIndirizzo.Controls.Add(Me.cmbLocalita)
        Me.tbIndirizzo.Controls.Add(Me.Label2)
        Me.tbIndirizzo.Controls.Add(Me.Label7)
        Me.tbIndirizzo.Controls.Add(Me.txtRiferimento)
        Me.tbIndirizzo.Controls.Add(Me.pctTipo)
        Me.tbIndirizzo.Controls.Add(Me.lblTitolo)
        Me.tbIndirizzo.Location = New System.Drawing.Point(4, 22)
        Me.tbIndirizzo.Name = "tbIndirizzo"
        Me.tbIndirizzo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbIndirizzo.Size = New System.Drawing.Size(521, 295)
        Me.tbIndirizzo.TabIndex = 0
        Me.tbIndirizzo.Text = "Former - Indirizzo"
        Me.tbIndirizzo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(50, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 15)
        Me.Label6.TabIndex = 145
        Me.Label6.Text = "Nazione"
        '
        'cmbNazione
        '
        Me.cmbNazione.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNazione.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNazione.BackColor = System.Drawing.Color.White
        Me.cmbNazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNazione.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbNazione.ForeColor = System.Drawing.Color.Black
        Me.cmbNazione.FormattingEnabled = True
        Me.cmbNazione.Location = New System.Drawing.Point(154, 144)
        Me.cmbNazione.Name = "cmbNazione"
        Me.cmbNazione.Size = New System.Drawing.Size(197, 23)
        Me.cmbNazione.TabIndex = 146
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(50, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 15)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Destinatario"
        '
        'txtDestinatario
        '
        Me.txtDestinatario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDestinatario.Location = New System.Drawing.Point(154, 86)
        Me.txtDestinatario.MaxLength = 100
        Me.txtDestinatario.Name = "txtDestinatario"
        Me.txtDestinatario.Size = New System.Drawing.Size(306, 23)
        Me.txtDestinatario.TabIndex = 2
        '
        'txtTel
        '
        Me.txtTel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTel.Location = New System.Drawing.Point(154, 202)
        Me.txtTel.MaxLength = 50
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(85, 23)
        Me.txtTel.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 15)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Telefono"
        '
        'lnkFermoDeposito
        '
        Me.lnkFermoDeposito.AutoSize = True
        Me.lnkFermoDeposito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkFermoDeposito.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkFermoDeposito.Location = New System.Drawing.Point(357, 60)
        Me.lnkFermoDeposito.Name = "lnkFermoDeposito"
        Me.lnkFermoDeposito.Size = New System.Drawing.Size(96, 15)
        Me.lnkFermoDeposito.TabIndex = 1
        Me.lnkFermoDeposito.TabStop = True
        Me.lnkFermoDeposito.Text = "Fermo Deposito?"
        '
        'chkDisattiva
        '
        Me.chkDisattiva.AutoSize = True
        Me.chkDisattiva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkDisattiva.Location = New System.Drawing.Point(154, 256)
        Me.chkDisattiva.Name = "chkDisattiva"
        Me.chkDisattiva.Size = New System.Drawing.Size(71, 19)
        Me.chkDisattiva.TabIndex = 8
        Me.chkDisattiva.Text = "Disattiva"
        Me.chkDisattiva.UseVisualStyleBackColor = True
        '
        'chkPredefinito
        '
        Me.chkPredefinito.AutoSize = True
        Me.chkPredefinito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkPredefinito.Location = New System.Drawing.Point(154, 231)
        Me.chkPredefinito.Name = "chkPredefinito"
        Me.chkPredefinito.Size = New System.Drawing.Size(84, 19)
        Me.chkPredefinito.TabIndex = 7
        Me.chkPredefinito.Text = "Predefinito"
        Me.chkPredefinito.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Indirizzo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(245, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Località"
        '
        'txtCAP
        '
        Me.txtCAP.My_AccettaNegativi = False
        Me.txtCAP.My_DefaultValue = 0
        Me.txtCAP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCAP.Location = New System.Drawing.Point(154, 173)
        Me.txtCAP.MaxLength = 5
        Me.txtCAP.My_MaxValue = 99999.0!
        Me.txtCAP.My_MinValue = 0!
        Me.txtCAP.Name = "txtCAP"
        Me.txtCAP.My_AllowOnlyInteger = True
        Me.txtCAP.My_ReplaceWithDefaultValue = True
        Me.txtCAP.Size = New System.Drawing.Size(85, 23)
        Me.txtCAP.TabIndex = 4
        Me.txtCAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIndirizzo
        '
        Me.txtIndirizzo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIndirizzo.Location = New System.Drawing.Point(154, 115)
        Me.txtIndirizzo.MaxLength = 100
        Me.txtIndirizzo.Name = "txtIndirizzo"
        Me.txtIndirizzo.Size = New System.Drawing.Size(306, 23)
        Me.txtIndirizzo.TabIndex = 3
        '
        'cmbLocalita
        '
        Me.cmbLocalita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocalita.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbLocalita.FormattingEnabled = True
        Me.cmbLocalita.Location = New System.Drawing.Point(301, 173)
        Me.cmbLocalita.Name = "cmbLocalita"
        Me.cmbLocalita.Size = New System.Drawing.Size(159, 23)
        Me.cmbLocalita.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "CAP"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Riferimento"
        '
        'txtRiferimento
        '
        Me.txtRiferimento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRiferimento.Location = New System.Drawing.Point(154, 57)
        Me.txtRiferimento.MaxLength = 50
        Me.txtRiferimento.Name = "txtRiferimento"
        Me.txtRiferimento.Size = New System.Drawing.Size(197, 23)
        Me.txtRiferimento.TabIndex = 0
        '
        'lblTitolo
        '
        Me.lblTitolo.AutoSize = True
        Me.lblTitolo.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.lblTitolo.Location = New System.Drawing.Point(48, 15)
        Me.lblTitolo.Name = "lblTitolo"
        Me.lblTitolo.Size = New System.Drawing.Size(20, 25)
        Me.lblTitolo.TabIndex = 13
        Me.lblTitolo.Text = "-"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(487, 13)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 27)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pctCheck
        '
        Me.pctCheck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctCheck.Image = Global.Former.My.Resources.Resources._test
        Me.pctCheck.Location = New System.Drawing.Point(462, 115)
        Me.pctCheck.Name = "pctCheck"
        Me.pctCheck.Size = New System.Drawing.Size(23, 23)
        Me.pctCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctCheck.TabIndex = 129
        Me.pctCheck.TabStop = False
        Me.toolTipHelp.SetToolTip(Me.pctCheck, "Controlla la validita dell'indirizzo")
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Indirizzo
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.Location = New System.Drawing.Point(453, 13)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 25)
        Me.btnOk.TabIndex = 9
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmIndirizzo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(529, 365)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmIndirizzo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbIndirizzo.ResumeLayout(False)
        Me.tbIndirizzo.PerformLayout()
        CType(Me.pctCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbIndirizzo As System.Windows.Forms.TabPage
    Friend WithEvents cmbLocalita As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRiferimento As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitolo As System.Windows.Forms.Label
    Friend WithEvents txtCAP As Former.ucNumericTextBox
    Friend WithEvents txtIndirizzo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkPredefinito As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisattiva As System.Windows.Forms.CheckBox
    Friend WithEvents lnkFermoDeposito As System.Windows.Forms.LinkLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pctCheck As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbNazione As ComboBox
End Class
