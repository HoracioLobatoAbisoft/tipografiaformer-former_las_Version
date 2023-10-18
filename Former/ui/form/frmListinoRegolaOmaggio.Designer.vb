<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoRegolaOmaggio
    Inherits baseFormInternaFixed

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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.lblRiassunto = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbPreventivazione = New System.Windows.Forms.ComboBox()
        Me.txtImportoMin = New Former.ucNumericTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipoCliente = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQta = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbListiniOmaggio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipologia = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 366)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(678, 48)
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
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(596, 12)
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
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(516, 13)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(74, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Salva"
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
        Me.TabMain.Size = New System.Drawing.Size(678, 366)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblRiassunto)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.cmbTipoCliente)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtQta)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.cmbListiniOmaggio)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbTipologia)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(670, 340)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Regola Omaggio"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblRiassunto
        '
        Me.lblRiassunto.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.lblRiassunto.ForeColor = System.Drawing.Color.White
        Me.lblRiassunto.Location = New System.Drawing.Point(38, 295)
        Me.lblRiassunto.Name = "lblRiassunto"
        Me.lblRiassunto.Size = New System.Drawing.Size(621, 30)
        Me.lblRiassunto.TabIndex = 32
        Me.lblRiassunto.Text = "-"
        Me.lblRiassunto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbPreventivazione)
        Me.GroupBox1.Controls.Add(Me.txtImportoMin)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 193)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(621, 90)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criteri"
        '
        'cmbPreventivazione
        '
        Me.cmbPreventivazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPreventivazione.FormattingEnabled = True
        Me.cmbPreventivazione.Location = New System.Drawing.Point(101, 24)
        Me.cmbPreventivazione.Name = "cmbPreventivazione"
        Me.cmbPreventivazione.Size = New System.Drawing.Size(483, 21)
        Me.cmbPreventivazione.TabIndex = 27
        Me.toolTipHelp.SetToolTip(Me.cmbPreventivazione, "OPZIONALE, abilitando una preventivazione l'omaggio sarà disponibile solo se si a" &
        "cquisterà un listino base contenuto nella preventivazione indicata")
        '
        'txtImportoMin
        '
        Me.txtImportoMin.My_AccettaNegativi = False
        Me.txtImportoMin.My_DefaultValue = 0
        Me.txtImportoMin.Location = New System.Drawing.Point(101, 53)
        Me.txtImportoMin.MaxLength = 5
        Me.txtImportoMin.My_MaxValue = 10000.0!
        Me.txtImportoMin.My_MinValue = 0!
        Me.txtImportoMin.Name = "txtImportoMin"
        Me.txtImportoMin.My_AllowOnlyInteger = True
        Me.txtImportoMin.My_ReplaceWithDefaultValue = True
        Me.txtImportoMin.Size = New System.Drawing.Size(82, 20)
        Me.txtImportoMin.TabIndex = 30
        Me.txtImportoMin.Text = "0"
        Me.txtImportoMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.toolTipHelp.SetToolTip(Me.txtImportoMin, "OPZIONALE, l'importo minimo da spendere per avere l'omaggio. Può essere combinato" &
        " con la Preventivazione")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 15)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Preventivazione"
        Me.toolTipHelp.SetToolTip(Me.Label5, "OPZIONALE, abilitando una preventivazione l'omaggio sarà disponibile solo se si a" &
        "cquisterà un listino base contenuto nella preventivazione indicata")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 15)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Importo Min"
        Me.toolTipHelp.SetToolTip(Me.Label6, "OPZIONALE, l'importo minimo da spendere per avere l'omaggio. Può essere combinato" &
        " con la Preventivazione")
        '
        'cmbTipoCliente
        '
        Me.cmbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCliente.FormattingEnabled = True
        Me.cmbTipoCliente.Location = New System.Drawing.Point(148, 135)
        Me.cmbTipoCliente.Name = "cmbTipoCliente"
        Me.cmbTipoCliente.Size = New System.Drawing.Size(157, 21)
        Me.cmbTipoCliente.TabIndex = 25
        Me.toolTipHelp.SetToolTip(Me.cmbTipoCliente, "Il tipo di cliente a cui si applica questa regola omaggio")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(44, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Tipo Cliente"
        Me.toolTipHelp.SetToolTip(Me.Label4, "Il tipo di cliente a cui si applica questa regola omaggio")
        '
        'txtQta
        '
        Me.txtQta.My_AccettaNegativi = False
        Me.txtQta.My_DefaultValue = 1
        Me.txtQta.Location = New System.Drawing.Point(148, 108)
        Me.txtQta.MaxLength = 5
        Me.txtQta.My_MaxValue = 10000.0!
        Me.txtQta.My_MinValue = 1.0!
        Me.txtQta.Name = "txtQta"
        Me.txtQta.My_AllowOnlyInteger = True
        Me.txtQta.My_ReplaceWithDefaultValue = True
        Me.txtQta.Size = New System.Drawing.Size(82, 20)
        Me.txtQta.TabIndex = 24
        Me.txtQta.Text = "1"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.toolTipHelp.SetToolTip(Me.txtQta, "La quantità dell'omaggio deve essere minimo di 1")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(44, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Quantità"
        Me.toolTipHelp.SetToolTip(Me.Label3, "La quantità dell'omaggio deve essere minimo di 1")
        '
        'cmbListiniOmaggio
        '
        Me.cmbListiniOmaggio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListiniOmaggio.FormattingEnabled = True
        Me.cmbListiniOmaggio.Location = New System.Drawing.Point(148, 79)
        Me.cmbListiniOmaggio.Name = "cmbListiniOmaggio"
        Me.cmbListiniOmaggio.Size = New System.Drawing.Size(511, 21)
        Me.cmbListiniOmaggio.TabIndex = 21
        Me.toolTipHelp.SetToolTip(Me.cmbListiniOmaggio, "L'omaggio oggetto della regola")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(44, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Listino Omaggio"
        Me.toolTipHelp.SetToolTip(Me.Label1, "L'omaggio oggetto della regola")
        '
        'cmbTipologia
        '
        Me.cmbTipologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipologia.FormattingEnabled = True
        Me.cmbTipologia.Location = New System.Drawing.Point(148, 164)
        Me.cmbTipologia.Name = "cmbTipologia"
        Me.cmbTipologia.Size = New System.Drawing.Size(157, 21)
        Me.cmbTipologia.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(44, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipologia"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Omaggio
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
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(81, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Omaggio"
        '
        'frmListinoRegolaOmaggio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(678, 414)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmListinoRegolaOmaggio"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Regola Omaggio"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents cmbTipologia As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbListiniOmaggio As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtQta As ucNumericTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTipoCliente As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtImportoMin As ucNumericTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbPreventivazione As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblRiassunto As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
