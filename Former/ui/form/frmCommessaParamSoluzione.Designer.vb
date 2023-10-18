<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCommessaParamSoluzione
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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbModello = New Telerik.WinControls.UI.RadDropDownList()
        Me.rdoTuttiMacch = New System.Windows.Forms.RadioButton()
        Me.rdoMacchDefault = New System.Windows.Forms.RadioButton()
        Me.rdoMacchinarioSpecifico = New System.Windows.Forms.RadioButton()
        Me.cmbMacchinari = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkFormatiCarta = New System.Windows.Forms.CheckBox()
        Me.chkScegliMacchinarioInBaseAcosti = New System.Windows.Forms.CheckBox()
        Me.rdoCloseAll = New System.Windows.Forms.RadioButton()
        Me.rdoOnlyOptimal = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMaxDuplicaz = New Former.ucNumericTextBox()
        Me.grpDebug = New System.Windows.Forms.GroupBox()
        Me.chkAccorpaCommesse = New System.Windows.Forms.CheckBox()
        Me.chkSoloFormatoCarta = New System.Windows.Forms.CheckBox()
        Me.chkEscludiDoppioni = New System.Windows.Forms.CheckBox()
        Me.chkCreazioneAutomatica = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoMotoreStabile = New System.Windows.Forms.RadioButton()
        Me.rdoMotoreBeta = New System.Windows.Forms.RadioButton()
        Me.btnCalcola = New System.Windows.Forms.Button()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cmbModello, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.grpDebug.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 667)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(585, 48)
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
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(543, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 36)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
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
        Me.TabMain.Size = New System.Drawing.Size(585, 667)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.GroupBox2)
        Me.tbProd.Controls.Add(Me.GroupBox4)
        Me.tbProd.Controls.Add(Me.grpDebug)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.btnCalcola)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(577, 641)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Parametri Creazione Soluzioni"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbModello)
        Me.GroupBox2.Controls.Add(Me.rdoTuttiMacch)
        Me.GroupBox2.Controls.Add(Me.rdoMacchDefault)
        Me.GroupBox2.Controls.Add(Me.rdoMacchinarioSpecifico)
        Me.GroupBox2.Controls.Add(Me.cmbMacchinari)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 120)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(540, 196)
        Me.GroupBox2.TabIndex = 120
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Macchinario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label2.Location = New System.Drawing.Point(47, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 15)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "e se vuoi un modello commessa"
        '
        'cmbModello
        '
        Me.cmbModello.AutoSize = False
        Me.cmbModello.AutoSizeItems = True
        Me.cmbModello.DropDownAnimationEnabled = False
        Me.cmbModello.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbModello.EnableAlternatingItemColor = True
        Me.cmbModello.Location = New System.Drawing.Point(218, 99)
        Me.cmbModello.Name = "cmbModello"
        Me.cmbModello.Size = New System.Drawing.Size(316, 80)
        Me.cmbModello.TabIndex = 125
        '
        'rdoTuttiMacch
        '
        Me.rdoTuttiMacch.AutoSize = True
        Me.rdoTuttiMacch.Checked = True
        Me.rdoTuttiMacch.Location = New System.Drawing.Point(9, 20)
        Me.rdoTuttiMacch.Name = "rdoTuttiMacch"
        Me.rdoTuttiMacch.Size = New System.Drawing.Size(179, 19)
        Me.rdoTuttiMacch.TabIndex = 124
        Me.rdoTuttiMacch.TabStop = True
        Me.rdoTuttiMacch.Text = "Utilizza qualsiasi macchinario"
        Me.rdoTuttiMacch.UseVisualStyleBackColor = True
        '
        'rdoMacchDefault
        '
        Me.rdoMacchDefault.AutoSize = True
        Me.rdoMacchDefault.Location = New System.Drawing.Point(9, 45)
        Me.rdoMacchDefault.Name = "rdoMacchDefault"
        Me.rdoMacchDefault.Size = New System.Drawing.Size(272, 19)
        Me.rdoMacchDefault.TabIndex = 123
        Me.rdoMacchDefault.Text = "Utilizza il macchinario di default per il prodotto"
        Me.rdoMacchDefault.UseVisualStyleBackColor = True
        '
        'rdoMacchinarioSpecifico
        '
        Me.rdoMacchinarioSpecifico.AutoSize = True
        Me.rdoMacchinarioSpecifico.Location = New System.Drawing.Point(9, 70)
        Me.rdoMacchinarioSpecifico.Name = "rdoMacchinarioSpecifico"
        Me.rdoMacchinarioSpecifico.Size = New System.Drawing.Size(198, 19)
        Me.rdoMacchinarioSpecifico.TabIndex = 122
        Me.rdoMacchinarioSpecifico.Text = "Utilizza un macchinario specifico"
        Me.rdoMacchinarioSpecifico.UseVisualStyleBackColor = True
        '
        'cmbMacchinari
        '
        Me.cmbMacchinari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMacchinari.FormattingEnabled = True
        Me.cmbMacchinari.Items.AddRange(New Object() {"Orizzontale", "Verticale"})
        Me.cmbMacchinari.Location = New System.Drawing.Point(218, 69)
        Me.cmbMacchinari.Name = "cmbMacchinari"
        Me.cmbMacchinari.Size = New System.Drawing.Size(316, 21)
        Me.cmbMacchinari.TabIndex = 110
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkFormatiCarta)
        Me.GroupBox4.Controls.Add(Me.chkScegliMacchinarioInBaseAcosti)
        Me.GroupBox4.Controls.Add(Me.rdoCloseAll)
        Me.GroupBox4.Controls.Add(Me.rdoOnlyOptimal)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.txtMaxDuplicaz)
        Me.GroupBox4.Location = New System.Drawing.Point(29, 322)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(540, 134)
        Me.GroupBox4.TabIndex = 119
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Opzioni di calcolo"
        '
        'chkFormatiCarta
        '
        Me.chkFormatiCarta.AutoSize = True
        Me.chkFormatiCarta.BackColor = System.Drawing.Color.White
        Me.chkFormatiCarta.Checked = True
        Me.chkFormatiCarta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFormatiCarta.Location = New System.Drawing.Point(20, 109)
        Me.chkFormatiCarta.Name = "chkFormatiCarta"
        Me.chkFormatiCarta.Size = New System.Drawing.Size(169, 19)
        Me.chkFormatiCarta.TabIndex = 124
        Me.chkFormatiCarta.Text = "Utilizza anche formati carta"
        Me.chkFormatiCarta.UseVisualStyleBackColor = False
        '
        'chkScegliMacchinarioInBaseAcosti
        '
        Me.chkScegliMacchinarioInBaseAcosti.AutoSize = True
        Me.chkScegliMacchinarioInBaseAcosti.BackColor = System.Drawing.Color.White
        Me.chkScegliMacchinarioInBaseAcosti.Checked = True
        Me.chkScegliMacchinarioInBaseAcosti.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScegliMacchinarioInBaseAcosti.Location = New System.Drawing.Point(20, 55)
        Me.chkScegliMacchinarioInBaseAcosti.Name = "chkScegliMacchinarioInBaseAcosti"
        Me.chkScegliMacchinarioInBaseAcosti.Size = New System.Drawing.Size(282, 19)
        Me.chkScegliMacchinarioInBaseAcosti.TabIndex = 123
        Me.chkScegliMacchinarioInBaseAcosti.Text = "Scegli macchinario in base ai costi di produzione"
        Me.chkScegliMacchinarioInBaseAcosti.UseVisualStyleBackColor = False
        '
        'rdoCloseAll
        '
        Me.rdoCloseAll.AutoSize = True
        Me.rdoCloseAll.Location = New System.Drawing.Point(246, 30)
        Me.rdoCloseAll.Name = "rdoCloseAll"
        Me.rdoCloseAll.Size = New System.Drawing.Size(261, 19)
        Me.rdoCloseAll.TabIndex = 122
        Me.rdoCloseAll.Text = "Tenta di chiudere tutte le commesse possibili"
        Me.rdoCloseAll.UseVisualStyleBackColor = True
        '
        'rdoOnlyOptimal
        '
        Me.rdoOnlyOptimal.AutoSize = True
        Me.rdoOnlyOptimal.Checked = True
        Me.rdoOnlyOptimal.Location = New System.Drawing.Point(20, 30)
        Me.rdoOnlyOptimal.Name = "rdoOnlyOptimal"
        Me.rdoOnlyOptimal.Size = New System.Drawing.Size(198, 19)
        Me.rdoOnlyOptimal.TabIndex = 121
        Me.rdoOnlyOptimal.TabStop = True
        Me.rdoOnlyOptimal.Text = "Proponi solo le soluzioni ottimali"
        Me.rdoOnlyOptimal.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(309, 15)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Quante volte può essere duplicato al massimo un ordine?"
        '
        'txtMaxDuplicaz
        '
        Me.txtMaxDuplicaz.Location = New System.Drawing.Point(348, 79)
        Me.txtMaxDuplicaz.MaxLength = 2
        Me.txtMaxDuplicaz.My_AccettaNegativi = False
        Me.txtMaxDuplicaz.My_AllowOnlyInteger = True
        Me.txtMaxDuplicaz.My_DefaultValue = 6
        Me.txtMaxDuplicaz.My_MaxValue = 99.0!
        Me.txtMaxDuplicaz.My_MinValue = 1.0!
        Me.txtMaxDuplicaz.My_ReplaceWithDefaultValue = True
        Me.txtMaxDuplicaz.Name = "txtMaxDuplicaz"
        Me.txtMaxDuplicaz.Size = New System.Drawing.Size(29, 20)
        Me.txtMaxDuplicaz.TabIndex = 120
        Me.txtMaxDuplicaz.Text = "10"
        Me.txtMaxDuplicaz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpDebug
        '
        Me.grpDebug.Controls.Add(Me.chkAccorpaCommesse)
        Me.grpDebug.Controls.Add(Me.chkSoloFormatoCarta)
        Me.grpDebug.Controls.Add(Me.chkEscludiDoppioni)
        Me.grpDebug.Controls.Add(Me.chkCreazioneAutomatica)
        Me.grpDebug.Location = New System.Drawing.Point(31, 462)
        Me.grpDebug.Name = "grpDebug"
        Me.grpDebug.Size = New System.Drawing.Size(540, 99)
        Me.grpDebug.TabIndex = 118
        Me.grpDebug.TabStop = False
        Me.grpDebug.Text = "Debug"
        Me.grpDebug.Visible = False
        '
        'chkAccorpaCommesse
        '
        Me.chkAccorpaCommesse.AutoSize = True
        Me.chkAccorpaCommesse.BackColor = System.Drawing.Color.White
        Me.chkAccorpaCommesse.Checked = True
        Me.chkAccorpaCommesse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAccorpaCommesse.Location = New System.Drawing.Point(194, 26)
        Me.chkAccorpaCommesse.Name = "chkAccorpaCommesse"
        Me.chkAccorpaCommesse.Size = New System.Drawing.Size(132, 19)
        Me.chkAccorpaCommesse.TabIndex = 124
        Me.chkAccorpaCommesse.Text = "Accorpa Commesse"
        Me.chkAccorpaCommesse.UseVisualStyleBackColor = False
        '
        'chkSoloFormatoCarta
        '
        Me.chkSoloFormatoCarta.AutoSize = True
        Me.chkSoloFormatoCarta.BackColor = System.Drawing.Color.White
        Me.chkSoloFormatoCarta.Location = New System.Drawing.Point(6, 76)
        Me.chkSoloFormatoCarta.Name = "chkSoloFormatoCarta"
        Me.chkSoloFormatoCarta.Size = New System.Drawing.Size(284, 19)
        Me.chkSoloFormatoCarta.TabIndex = 123
        Me.chkSoloFormatoCarta.Text = "Utilizza solo formati carta e non formati prodotto"
        Me.chkSoloFormatoCarta.UseVisualStyleBackColor = False
        '
        'chkEscludiDoppioni
        '
        Me.chkEscludiDoppioni.AutoSize = True
        Me.chkEscludiDoppioni.BackColor = System.Drawing.Color.White
        Me.chkEscludiDoppioni.Location = New System.Drawing.Point(6, 51)
        Me.chkEscludiDoppioni.Name = "chkEscludiDoppioni"
        Me.chkEscludiDoppioni.Size = New System.Drawing.Size(289, 19)
        Me.chkEscludiDoppioni.TabIndex = 121
        Me.chkEscludiDoppioni.Text = "Mostra tutte le combinazioni che riesci a calcolare"
        Me.chkEscludiDoppioni.UseVisualStyleBackColor = False
        '
        'chkCreazioneAutomatica
        '
        Me.chkCreazioneAutomatica.AutoSize = True
        Me.chkCreazioneAutomatica.BackColor = System.Drawing.Color.White
        Me.chkCreazioneAutomatica.Location = New System.Drawing.Point(6, 26)
        Me.chkCreazioneAutomatica.Name = "chkCreazioneAutomatica"
        Me.chkCreazioneAutomatica.Size = New System.Drawing.Size(182, 19)
        Me.chkCreazioneAutomatica.TabIndex = 122
        Me.chkCreazioneAutomatica.Text = "Simula Creazione Automatica"
        Me.chkCreazioneAutomatica.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoMotoreStabile)
        Me.GroupBox1.Controls.Add(Me.rdoMotoreBeta)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 67)
        Me.GroupBox1.TabIndex = 114
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Scegli Motore di Calcolo"
        '
        'rdoMotoreStabile
        '
        Me.rdoMotoreStabile.AutoSize = True
        Me.rdoMotoreStabile.BackColor = System.Drawing.Color.LightGreen
        Me.rdoMotoreStabile.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.rdoMotoreStabile.Location = New System.Drawing.Point(20, 29)
        Me.rdoMotoreStabile.Name = "rdoMotoreStabile"
        Me.rdoMotoreStabile.Size = New System.Drawing.Size(127, 23)
        Me.rdoMotoreStabile.TabIndex = 117
        Me.rdoMotoreStabile.Text = "Motore Stabile"
        Me.rdoMotoreStabile.UseVisualStyleBackColor = False
        '
        'rdoMotoreBeta
        '
        Me.rdoMotoreBeta.AutoSize = True
        Me.rdoMotoreBeta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdoMotoreBeta.Checked = True
        Me.rdoMotoreBeta.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.rdoMotoreBeta.Location = New System.Drawing.Point(317, 29)
        Me.rdoMotoreBeta.Name = "rdoMotoreBeta"
        Me.rdoMotoreBeta.Size = New System.Drawing.Size(111, 23)
        Me.rdoMotoreBeta.TabIndex = 114
        Me.rdoMotoreBeta.TabStop = True
        Me.rdoMotoreBeta.Text = "Motore Beta"
        Me.rdoMotoreBeta.UseVisualStyleBackColor = False
        '
        'btnCalcola
        '
        Me.btnCalcola.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCalcola.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnCalcola.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCalcola.Location = New System.Drawing.Point(208, 578)
        Me.btnCalcola.Name = "btnCalcola"
        Me.btnCalcola.Size = New System.Drawing.Size(167, 55)
        Me.btnCalcola.TabIndex = 15
        Me.btnCalcola.Text = "Calcola"
        Me.btnCalcola.UseVisualStyleBackColor = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Opzioni
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
        Me.lblTipo.Size = New System.Drawing.Size(300, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Parametri di Creazione delle soluzioni"
        '
        'frmCommessaParamSoluzione
        '
        Me.AcceptButton = Me.btnCalcola
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(585, 715)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmCommessaParamSoluzione"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Parametri Creazione Soluzioni"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cmbModello, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.grpDebug.ResumeLayout(False)
        Me.grpDebug.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents btnCalcola As System.Windows.Forms.Button
    Friend WithEvents cmbMacchinari As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxDuplicaz As ucNumericTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkEscludiDoppioni As System.Windows.Forms.CheckBox
    Friend WithEvents chkCreazioneAutomatica As CheckBox
    Friend WithEvents rdoMotoreBeta As RadioButton
    Friend WithEvents rdoMotoreStabile As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents grpDebug As GroupBox
    Friend WithEvents rdoCloseAll As RadioButton
    Friend WithEvents rdoOnlyOptimal As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdoTuttiMacch As RadioButton
    Friend WithEvents rdoMacchDefault As RadioButton
    Friend WithEvents rdoMacchinarioSpecifico As RadioButton
    Friend WithEvents chkSoloFormatoCarta As CheckBox
    Friend WithEvents chkAccorpaCommesse As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbModello As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents chkScegliMacchinarioInBaseAcosti As CheckBox
    Friend WithEvents chkFormatiCarta As CheckBox
End Class
