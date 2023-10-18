<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCommessaFromJob
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
        Me.btnCrea = New Former.ucButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnInterpreta = New Former.ucButton()
        Me.txtNLastre = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMacchinari = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtQta = New Former.ucNumericTextBox()
        Me.lblQta = New System.Windows.Forms.Label()
        Me.btnJob = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFileJob = New System.Windows.Forms.TextBox()
        Me.lblReparto = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.dlgFile = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 375)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(604, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(520, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.TabMain.Size = New System.Drawing.Size(604, 375)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnCrea)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.btnInterpreta)
        Me.tbProd.Controls.Add(Me.txtNLastre)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.cmbMacchinari)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.txtQta)
        Me.tbProd.Controls.Add(Me.lblQta)
        Me.tbProd.Controls.Add(Me.btnJob)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.txtFileJob)
        Me.tbProd.Controls.Add(Me.lblReparto)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(596, 349)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Crea Commessa da file JOB"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnCrea
        '
        Me.btnCrea.Location = New System.Drawing.Point(279, 287)
        Me.btnCrea.Name = "btnCrea"
        Me.btnCrea.Radius = 5
        Me.btnCrea.RoundedButton = False
        Me.btnCrea.Size = New System.Drawing.Size(75, 23)
        Me.btnCrea.TabIndex = 136
        Me.btnCrea.Text = "Crea"
        Me.btnCrea.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(44, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(346, 15)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Step 2 - Inserisci le seguenti informazioni e crea la commessa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(44, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(487, 15)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "Step 1 - Seleziona il file JOB e interpretalo per effettuare controlli formali e " &
    "sostanziali"
        '
        'btnInterpreta
        '
        Me.btnInterpreta.Location = New System.Drawing.Point(279, 118)
        Me.btnInterpreta.Name = "btnInterpreta"
        Me.btnInterpreta.Radius = 5
        Me.btnInterpreta.RoundedButton = False
        Me.btnInterpreta.Size = New System.Drawing.Size(75, 23)
        Me.btnInterpreta.TabIndex = 133
        Me.btnInterpreta.Text = "Interpreta"
        Me.btnInterpreta.UseVisualStyleBackColor = True
        '
        'txtNLastre
        '
        Me.txtNLastre.My_AccettaNegativi = False
        Me.txtNLastre.My_DefaultValue = 1
        Me.txtNLastre.Location = New System.Drawing.Point(152, 259)
        Me.txtNLastre.MaxLength = 3
        Me.txtNLastre.My_MaxValue = 999.0!
        Me.txtNLastre.My_MinValue = 1.0!
        Me.txtNLastre.Name = "txtNLastre"
        Me.txtNLastre.My_AllowOnlyInteger = True
        Me.txtNLastre.My_ReplaceWithDefaultValue = True
        Me.txtNLastre.Size = New System.Drawing.Size(94, 20)
        Me.txtNLastre.TabIndex = 4
        Me.txtNLastre.Text = "1"
        Me.txtNLastre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(44, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "N° Lastre"
        '
        'cmbMacchinari
        '
        Me.cmbMacchinari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMacchinari.FormattingEnabled = True
        Me.cmbMacchinari.Items.AddRange(New Object() {"Orizzontale", "Verticale"})
        Me.cmbMacchinari.Location = New System.Drawing.Point(152, 203)
        Me.cmbMacchinari.Name = "cmbMacchinari"
        Me.cmbMacchinari.Size = New System.Drawing.Size(358, 21)
        Me.cmbMacchinari.TabIndex = 1
        Me.toolTipHelp.SetToolTip(Me.cmbMacchinari, "Il macchinario da utilizzare nella realizzazione del prodotto (Stampa, RIcamo, ec" &
        "c...)")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(44, 206)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 15)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "Macchinario"
        Me.toolTipHelp.SetToolTip(Me.Label9, "Il macchinario da utilizzare nella realizzazione del prodotto (Stampa, RIcamo, ec" &
        "c...)")
        '
        'txtQta
        '
        Me.txtQta.My_AccettaNegativi = False
        Me.txtQta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtQta.BackColor = System.Drawing.Color.White
        Me.txtQta.My_DefaultValue = 0
        Me.txtQta.ForeColor = System.Drawing.Color.Black
        Me.txtQta.Location = New System.Drawing.Point(152, 232)
        Me.txtQta.My_MaxValue = 1.0E+10!
        Me.txtQta.My_MinValue = 0!
        Me.txtQta.Name = "txtQta"
        Me.txtQta.My_AllowOnlyInteger = True
        Me.txtQta.My_ReplaceWithDefaultValue = True
        Me.txtQta.Size = New System.Drawing.Size(94, 20)
        Me.txtQta.TabIndex = 2
        Me.txtQta.Text = "0"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblQta
        '
        Me.lblQta.AutoSize = True
        Me.lblQta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQta.ForeColor = System.Drawing.Color.Black
        Me.lblQta.Location = New System.Drawing.Point(44, 235)
        Me.lblQta.Name = "lblQta"
        Me.lblQta.Size = New System.Drawing.Size(93, 15)
        Me.lblQta.TabIndex = 125
        Me.lblQta.Text = "Copie di stampa"
        '
        'btnJob
        '
        Me.btnJob.Location = New System.Drawing.Point(516, 90)
        Me.btnJob.Name = "btnJob"
        Me.btnJob.Size = New System.Drawing.Size(27, 23)
        Me.btnJob.TabIndex = 120
        Me.btnJob.Text = "..."
        Me.btnJob.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(44, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "File JOB"
        '
        'txtFileJob
        '
        Me.txtFileJob.Location = New System.Drawing.Point(152, 91)
        Me.txtFileJob.MaxLength = 50
        Me.txtFileJob.Name = "txtFileJob"
        Me.txtFileJob.ReadOnly = True
        Me.txtFileJob.Size = New System.Drawing.Size(358, 20)
        Me.txtFileJob.TabIndex = 0
        '
        'lblReparto
        '
        Me.lblReparto.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblReparto.Location = New System.Drawing.Point(48, 6)
        Me.lblReparto.Name = "lblReparto"
        Me.lblReparto.Size = New System.Drawing.Size(540, 34)
        Me.lblReparto.TabIndex = 117
        Me.lblReparto.Text = "Stampa Offset"
        Me.lblReparto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._FileJOB
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 116
        Me.pctTipo.TabStop = False
        '
        'dlgFile
        '
        Me.dlgFile.FileName = "OpenFileDialog1"
        '
        'frmCommessaFromJob
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(604, 423)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCommessaFromJob"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Crea Commessa da file JOB"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents lblReparto As Label
    Friend WithEvents pctTipo As PictureBox
    Friend WithEvents btnJob As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFileJob As TextBox
    Friend WithEvents txtQta As ucNumericTextBox
    Friend WithEvents lblQta As Label
    Friend WithEvents cmbMacchinari As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNLastre As ucNumericTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dlgFile As OpenFileDialog
    Friend WithEvents btnCrea As ucButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnInterpreta As ucButton
End Class
