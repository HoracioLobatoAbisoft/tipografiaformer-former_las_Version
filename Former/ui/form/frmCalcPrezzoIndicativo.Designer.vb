<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcPrezzoIndicativo
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFileDiversi = New System.Windows.Forms.CheckBox()
        Me.cmbLavorazioni = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rdoColori = New System.Windows.Forms.RadioButton()
        Me.rdoBiancoNero = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPagineIns = New Former.ucNumericTextBox()
        Me.chkRiv = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbCarta = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkFR = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPagine = New Former.ucNumericTextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cmbFormato = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCopie = New Former.ucNumericTextBox()
        Me.lblPrezzoCalc = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 342)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(513, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(453, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.TabStop = False
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.Location = New System.Drawing.Point(417, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 15
        Me.btnOk.TabStop = False
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.chkFileDiversi)
        Me.GroupBox1.Controls.Add(Me.cmbLavorazioni)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.rdoColori)
        Me.GroupBox1.Controls.Add(Me.rdoBiancoNero)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPagineIns)
        Me.GroupBox1.Controls.Add(Me.chkRiv)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbCarta)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkFR)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPagine)
        Me.GroupBox1.Controls.Add(Me.pctTipo)
        Me.GroupBox1.Controls.Add(Me.lblTipo)
        Me.GroupBox1.Controls.Add(Me.cmbFormato)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCopie)
        Me.GroupBox1.Controls.Add(Me.lblPrezzoCalc)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(513, 342)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Calcolo prezzo"
        '
        'chkFileDiversi
        '
        Me.chkFileDiversi.AutoSize = True
        Me.chkFileDiversi.Checked = True
        Me.chkFileDiversi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFileDiversi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkFileDiversi.ForeColor = System.Drawing.Color.Black
        Me.chkFileDiversi.Location = New System.Drawing.Point(155, 126)
        Me.chkFileDiversi.Name = "chkFileDiversi"
        Me.chkFileDiversi.Size = New System.Drawing.Size(82, 19)
        Me.chkFileDiversi.TabIndex = 56
        Me.chkFileDiversi.Text = "File Diversi"
        Me.chkFileDiversi.UseVisualStyleBackColor = True
        '
        'cmbLavorazioni
        '
        Me.cmbLavorazioni.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLavorazioni.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLavorazioni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLavorazioni.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbLavorazioni.FormattingEnabled = True
        Me.cmbLavorazioni.Location = New System.Drawing.Point(155, 240)
        Me.cmbLavorazioni.Name = "cmbLavorazioni"
        Me.cmbLavorazioni.Size = New System.Drawing.Size(328, 23)
        Me.cmbLavorazioni.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(50, 243)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Lavorazioni"
        '
        'rdoColori
        '
        Me.rdoColori.AutoSize = True
        Me.rdoColori.Checked = True
        Me.rdoColori.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoColori.Location = New System.Drawing.Point(262, 101)
        Me.rdoColori.Name = "rdoColori"
        Me.rdoColori.Size = New System.Drawing.Size(68, 19)
        Me.rdoColori.TabIndex = 53
        Me.rdoColori.TabStop = True
        Me.rdoColori.Text = "A Colori"
        Me.rdoColori.UseVisualStyleBackColor = True
        '
        'rdoBiancoNero
        '
        Me.rdoBiancoNero.AutoSize = True
        Me.rdoBiancoNero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoBiancoNero.Location = New System.Drawing.Point(155, 101)
        Me.rdoBiancoNero.Name = "rdoBiancoNero"
        Me.rdoBiancoNero.Size = New System.Drawing.Size(99, 19)
        Me.rdoBiancoNero.TabIndex = 52
        Me.rdoBiancoNero.Text = "Bianco e Nero"
        Me.rdoBiancoNero.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(318, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Fogli stesi"
        '
        'txtPagineIns
        '
        Me.txtPagineIns.My_AccettaNegativi = False
        Me.txtPagineIns.My_DefaultValue = 1
        Me.txtPagineIns.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPagineIns.Location = New System.Drawing.Point(155, 155)
        Me.txtPagineIns.MaxLength = 3
        Me.txtPagineIns.My_MaxValue = 100.0!
        Me.txtPagineIns.My_MinValue = 1.0!
        Me.txtPagineIns.Name = "txtPagineIns"
        Me.txtPagineIns.My_AllowOnlyInteger = True
        Me.txtPagineIns.My_ReplaceWithDefaultValue = True
        Me.txtPagineIns.Size = New System.Drawing.Size(111, 23)
        Me.txtPagineIns.TabIndex = 50
        Me.txtPagineIns.Text = "1"
        Me.txtPagineIns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkRiv
        '
        Me.chkRiv.AutoSize = True
        Me.chkRiv.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkRiv.ForeColor = System.Drawing.Color.Black
        Me.chkRiv.Location = New System.Drawing.Point(53, 102)
        Me.chkRiv.Name = "chkRiv"
        Me.chkRiv.Size = New System.Drawing.Size(92, 19)
        Me.chkRiv.TabIndex = 49
        Me.chkRiv.Text = "Rivista/Libro"
        Me.chkRiv.UseVisualStyleBackColor = True
        Me.chkRiv.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(49, 289)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 28)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Totale"
        '
        'cmbCarta
        '
        Me.cmbCarta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCarta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCarta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCarta.FormattingEnabled = True
        Me.cmbCarta.Location = New System.Drawing.Point(155, 211)
        Me.cmbCarta.Name = "cmbCarta"
        Me.cmbCarta.Size = New System.Drawing.Size(328, 23)
        Me.cmbCarta.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 15)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Carta"
        '
        'chkFR
        '
        Me.chkFR.AutoSize = True
        Me.chkFR.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkFR.ForeColor = System.Drawing.Color.Black
        Me.chkFR.Location = New System.Drawing.Point(318, 77)
        Me.chkFR.Name = "chkFR"
        Me.chkFR.Size = New System.Drawing.Size(85, 19)
        Me.chkFR.TabIndex = 2
        Me.chkFR.Text = "Fronteretro"
        Me.chkFR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Pagine/Facciate"
        '
        'txtPagine
        '
        Me.txtPagine.My_AccettaNegativi = False
        Me.txtPagine.My_DefaultValue = 1
        Me.txtPagine.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPagine.Location = New System.Drawing.Point(272, 155)
        Me.txtPagine.MaxLength = 6
        Me.txtPagine.My_MaxValue = 1000000.0!
        Me.txtPagine.My_MinValue = 1.0!
        Me.txtPagine.Name = "txtPagine"
        Me.txtPagine.My_AllowOnlyInteger = True
        Me.txtPagine.ReadOnly = True
        Me.txtPagine.My_ReplaceWithDefaultValue = True
        Me.txtPagine.Size = New System.Drawing.Size(40, 23)
        Me.txtPagine.TabIndex = 1
        Me.txtPagine.Text = "1"
        Me.txtPagine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Prezzo
        Me.pctTipo.Location = New System.Drawing.Point(6, 20)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 26
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 26)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(122, 21)
        Me.lblTipo.TabIndex = 25
        Me.lblTipo.Text = "Calcolo Prezzo"
        '
        'cmbFormato
        '
        Me.cmbFormato.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFormato.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFormato.FormattingEnabled = True
        Me.cmbFormato.Location = New System.Drawing.Point(155, 182)
        Me.cmbFormato.Name = "cmbFormato"
        Me.cmbFormato.Size = New System.Drawing.Size(328, 23)
        Me.cmbFormato.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Formato Finito"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 15)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Copie"
        '
        'txtCopie
        '
        Me.txtCopie.My_AccettaNegativi = False
        Me.txtCopie.My_DefaultValue = 1
        Me.txtCopie.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCopie.Location = New System.Drawing.Point(155, 75)
        Me.txtCopie.MaxLength = 6
        Me.txtCopie.My_MaxValue = 1000000.0!
        Me.txtCopie.My_MinValue = 1.0!
        Me.txtCopie.Name = "txtCopie"
        Me.txtCopie.My_AllowOnlyInteger = True
        Me.txtCopie.My_ReplaceWithDefaultValue = True
        Me.txtCopie.Size = New System.Drawing.Size(157, 23)
        Me.txtCopie.TabIndex = 0
        Me.txtCopie.Text = "1"
        Me.txtCopie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrezzoCalc
        '
        Me.lblPrezzoCalc.Font = New System.Drawing.Font("Segoe UI", 15.0!)
        Me.lblPrezzoCalc.ForeColor = System.Drawing.Color.Black
        Me.lblPrezzoCalc.Location = New System.Drawing.Point(151, 289)
        Me.lblPrezzoCalc.Name = "lblPrezzoCalc"
        Me.lblPrezzoCalc.Size = New System.Drawing.Size(183, 23)
        Me.lblPrezzoCalc.TabIndex = 0
        Me.lblPrezzoCalc.Text = "0"
        Me.lblPrezzoCalc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCalcPrezzoIndicativo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(513, 390)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmCalcPrezzoIndicativo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Calcolo prezzo carta"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.gbPulsanti.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPrezzoCalc As System.Windows.Forms.Label
    Friend WithEvents cmbFormato As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCopie As ucNumericTextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPagine As ucNumericTextBox
    Friend WithEvents chkFR As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCarta As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkRiv As System.Windows.Forms.CheckBox
    Friend WithEvents txtPagineIns As ucNumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdoColori As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBiancoNero As System.Windows.Forms.RadioButton
    Friend WithEvents cmbLavorazioni As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkFileDiversi As System.Windows.Forms.CheckBox
End Class
