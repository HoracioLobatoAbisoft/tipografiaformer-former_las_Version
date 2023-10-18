<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmListinoPrezzoLavorazione
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListinoPrezzoLavorazione))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblRisOltre2 = New System.Windows.Forms.Label()
        Me.txtPrezzo2 = New Former.ucNumericTextBox()
        Me.lblRisMin2 = New System.Windows.Forms.Label()
        Me.lblRispz2 = New System.Windows.Forms.Label()
        Me.txtPrezzoOltre2 = New Former.ucNumericTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPrezzoMin2 = New Former.ucNumericTextBox()
        Me.txtPezziRif2 = New Former.ucNumericTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRisOltre = New System.Windows.Forms.Label()
        Me.txtPrezzo = New Former.ucNumericTextBox()
        Me.lblRisMin = New System.Windows.Forms.Label()
        Me.lblRispz = New System.Windows.Forms.Label()
        Me.txtPrezzoOltre = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPrezzoMin = New Former.ucNumericTextBox()
        Me.txtPezziRif = New Former.ucNumericTextBox()
        Me.UcInfoBox = New Former.ucInfoBox()
        Me.cmbFormatoProdotto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 605)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(628, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(586, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 36)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.Location = New System.Drawing.Point(552, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 0
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
        Me.TabMain.Size = New System.Drawing.Size(628, 605)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.GroupBox2)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.UcInfoBox)
        Me.tbProd.Controls.Add(Me.cmbFormatoProdotto)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(620, 579)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Prezzo Lavorazione"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblRisOltre2)
        Me.GroupBox2.Controls.Add(Me.txtPrezzo2)
        Me.GroupBox2.Controls.Add(Me.lblRisMin2)
        Me.GroupBox2.Controls.Add(Me.lblRispz2)
        Me.GroupBox2.Controls.Add(Me.txtPrezzoOltre2)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtPrezzoMin2)
        Me.GroupBox2.Controls.Add(Me.txtPezziRif2)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(563, 130)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Macchinario Secondario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 15)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Prezzo cad. minimo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Orange
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Prezzo cad. riferimento"
        '
        'lblRisOltre2
        '
        Me.lblRisOltre2.AutoSize = True
        Me.lblRisOltre2.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblRisOltre2.ForeColor = System.Drawing.Color.Red
        Me.lblRisOltre2.Location = New System.Drawing.Point(281, 100)
        Me.lblRisOltre2.Name = "lblRisOltre2"
        Me.lblRisOltre2.Size = New System.Drawing.Size(29, 15)
        Me.lblRisOltre2.TabIndex = 29
        Me.lblRisOltre2.Text = "(0€)"
        '
        'txtPrezzo2
        '
        Me.txtPrezzo2.Location = New System.Drawing.Point(143, 58)
        Me.txtPrezzo2.My_AccettaNegativi = False
        Me.txtPrezzo2.My_AllowOnlyInteger = False
        Me.txtPrezzo2.My_DefaultValue = 0
        Me.txtPrezzo2.My_MaxValue = 1.0E+10!
        Me.txtPrezzo2.My_MinValue = 0!
        Me.txtPrezzo2.My_ReplaceWithDefaultValue = True
        Me.txtPrezzo2.Name = "txtPrezzo2"
        Me.txtPrezzo2.Size = New System.Drawing.Size(93, 20)
        Me.txtPrezzo2.TabIndex = 2
        Me.txtPrezzo2.Text = "0"
        Me.txtPrezzo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRisMin2
        '
        Me.lblRisMin2.AutoSize = True
        Me.lblRisMin2.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblRisMin2.ForeColor = System.Drawing.Color.Red
        Me.lblRisMin2.Location = New System.Drawing.Point(281, 21)
        Me.lblRisMin2.Name = "lblRisMin2"
        Me.lblRisMin2.Size = New System.Drawing.Size(29, 15)
        Me.lblRisMin2.TabIndex = 28
        Me.lblRisMin2.Text = "(0€)"
        '
        'lblRispz2
        '
        Me.lblRispz2.AutoSize = True
        Me.lblRispz2.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblRispz2.ForeColor = System.Drawing.Color.Red
        Me.lblRispz2.Location = New System.Drawing.Point(488, 61)
        Me.lblRispz2.Name = "lblRispz2"
        Me.lblRispz2.Size = New System.Drawing.Size(29, 15)
        Me.lblRispz2.TabIndex = 21
        Me.lblRispz2.Text = "(0€)"
        '
        'txtPrezzoOltre2
        '
        Me.txtPrezzoOltre2.Location = New System.Drawing.Point(143, 97)
        Me.txtPrezzoOltre2.My_AccettaNegativi = False
        Me.txtPrezzoOltre2.My_AllowOnlyInteger = False
        Me.txtPrezzoOltre2.My_DefaultValue = 0
        Me.txtPrezzoOltre2.My_MaxValue = 1.0E+10!
        Me.txtPrezzoOltre2.My_MinValue = 0!
        Me.txtPrezzoOltre2.My_ReplaceWithDefaultValue = True
        Me.txtPrezzoOltre2.Name = "txtPrezzoOltre2"
        Me.txtPrezzoOltre2.Size = New System.Drawing.Size(93, 20)
        Me.txtPrezzoOltre2.TabIndex = 4
        Me.txtPrezzoOltre2.Text = "0"
        Me.txtPrezzoOltre2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Orange
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(281, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 15)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Pezzi Riferimento"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(6, 100)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 15)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Prezzo cad. oltre soglia"
        '
        'txtPrezzoMin2
        '
        Me.txtPrezzoMin2.Location = New System.Drawing.Point(143, 18)
        Me.txtPrezzoMin2.My_AccettaNegativi = False
        Me.txtPrezzoMin2.My_AllowOnlyInteger = False
        Me.txtPrezzoMin2.My_DefaultValue = 0
        Me.txtPrezzoMin2.My_MaxValue = 1.0E+10!
        Me.txtPrezzoMin2.My_MinValue = 0!
        Me.txtPrezzoMin2.My_ReplaceWithDefaultValue = True
        Me.txtPrezzoMin2.Name = "txtPrezzoMin2"
        Me.txtPrezzoMin2.Size = New System.Drawing.Size(93, 20)
        Me.txtPrezzoMin2.TabIndex = 1
        Me.txtPrezzoMin2.Text = "0"
        Me.txtPrezzoMin2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPezziRif2
        '
        Me.txtPezziRif2.Location = New System.Drawing.Point(389, 58)
        Me.txtPezziRif2.My_AccettaNegativi = False
        Me.txtPezziRif2.My_AllowOnlyInteger = True
        Me.txtPezziRif2.My_DefaultValue = 1000
        Me.txtPezziRif2.My_MaxValue = 1.0E+10!
        Me.txtPezziRif2.My_MinValue = 0!
        Me.txtPezziRif2.My_ReplaceWithDefaultValue = True
        Me.txtPezziRif2.Name = "txtPezziRif2"
        Me.txtPezziRif2.ReadOnly = True
        Me.txtPezziRif2.Size = New System.Drawing.Size(93, 20)
        Me.txtPezziRif2.TabIndex = 3
        Me.txtPezziRif2.Text = "1000"
        Me.txtPezziRif2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblRisOltre)
        Me.GroupBox1.Controls.Add(Me.txtPrezzo)
        Me.GroupBox1.Controls.Add(Me.lblRisMin)
        Me.GroupBox1.Controls.Add(Me.lblRispz)
        Me.GroupBox1.Controls.Add(Me.txtPrezzoOltre)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPrezzoMin)
        Me.GroupBox1.Controls.Add(Me.txtPezziRif)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(563, 130)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Macchinario Principale"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Prezzo cad. minimo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Orange
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Prezzo cad. riferimento"
        '
        'lblRisOltre
        '
        Me.lblRisOltre.AutoSize = True
        Me.lblRisOltre.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblRisOltre.ForeColor = System.Drawing.Color.Red
        Me.lblRisOltre.Location = New System.Drawing.Point(281, 100)
        Me.lblRisOltre.Name = "lblRisOltre"
        Me.lblRisOltre.Size = New System.Drawing.Size(29, 15)
        Me.lblRisOltre.TabIndex = 29
        Me.lblRisOltre.Text = "(0€)"
        '
        'txtPrezzo
        '
        Me.txtPrezzo.Location = New System.Drawing.Point(143, 58)
        Me.txtPrezzo.My_AccettaNegativi = False
        Me.txtPrezzo.My_AllowOnlyInteger = False
        Me.txtPrezzo.My_DefaultValue = 0
        Me.txtPrezzo.My_MaxValue = 1.0E+10!
        Me.txtPrezzo.My_MinValue = 0!
        Me.txtPrezzo.My_ReplaceWithDefaultValue = True
        Me.txtPrezzo.Name = "txtPrezzo"
        Me.txtPrezzo.Size = New System.Drawing.Size(93, 20)
        Me.txtPrezzo.TabIndex = 2
        Me.txtPrezzo.Text = "0"
        Me.txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRisMin
        '
        Me.lblRisMin.AutoSize = True
        Me.lblRisMin.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblRisMin.ForeColor = System.Drawing.Color.Red
        Me.lblRisMin.Location = New System.Drawing.Point(281, 21)
        Me.lblRisMin.Name = "lblRisMin"
        Me.lblRisMin.Size = New System.Drawing.Size(29, 15)
        Me.lblRisMin.TabIndex = 28
        Me.lblRisMin.Text = "(0€)"
        '
        'lblRispz
        '
        Me.lblRispz.AutoSize = True
        Me.lblRispz.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblRispz.ForeColor = System.Drawing.Color.Red
        Me.lblRispz.Location = New System.Drawing.Point(488, 61)
        Me.lblRispz.Name = "lblRispz"
        Me.lblRispz.Size = New System.Drawing.Size(29, 15)
        Me.lblRispz.TabIndex = 21
        Me.lblRispz.Text = "(0€)"
        '
        'txtPrezzoOltre
        '
        Me.txtPrezzoOltre.Location = New System.Drawing.Point(143, 97)
        Me.txtPrezzoOltre.My_AccettaNegativi = False
        Me.txtPrezzoOltre.My_AllowOnlyInteger = False
        Me.txtPrezzoOltre.My_DefaultValue = 0
        Me.txtPrezzoOltre.My_MaxValue = 1.0E+10!
        Me.txtPrezzoOltre.My_MinValue = 0!
        Me.txtPrezzoOltre.My_ReplaceWithDefaultValue = True
        Me.txtPrezzoOltre.Name = "txtPrezzoOltre"
        Me.txtPrezzoOltre.Size = New System.Drawing.Size(93, 20)
        Me.txtPrezzoOltre.TabIndex = 4
        Me.txtPrezzoOltre.Text = "0"
        Me.txtPrezzoOltre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Orange
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(281, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Pezzi Riferimento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Prezzo cad. oltre soglia"
        '
        'txtPrezzoMin
        '
        Me.txtPrezzoMin.Location = New System.Drawing.Point(143, 18)
        Me.txtPrezzoMin.My_AccettaNegativi = False
        Me.txtPrezzoMin.My_AllowOnlyInteger = False
        Me.txtPrezzoMin.My_DefaultValue = 0
        Me.txtPrezzoMin.My_MaxValue = 1.0E+10!
        Me.txtPrezzoMin.My_MinValue = 0!
        Me.txtPrezzoMin.My_ReplaceWithDefaultValue = True
        Me.txtPrezzoMin.Name = "txtPrezzoMin"
        Me.txtPrezzoMin.Size = New System.Drawing.Size(93, 20)
        Me.txtPrezzoMin.TabIndex = 1
        Me.txtPrezzoMin.Text = "0"
        Me.txtPrezzoMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPezziRif
        '
        Me.txtPezziRif.Location = New System.Drawing.Point(389, 58)
        Me.txtPezziRif.My_AccettaNegativi = False
        Me.txtPezziRif.My_AllowOnlyInteger = True
        Me.txtPezziRif.My_DefaultValue = 1000
        Me.txtPezziRif.My_MaxValue = 1.0E+10!
        Me.txtPezziRif.My_MinValue = 0!
        Me.txtPezziRif.My_ReplaceWithDefaultValue = True
        Me.txtPezziRif.Name = "txtPezziRif"
        Me.txtPezziRif.Size = New System.Drawing.Size(93, 20)
        Me.txtPezziRif.TabIndex = 3
        Me.txtPezziRif.Text = "1000"
        Me.txtPezziRif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UcInfoBox
        '
        Me.UcInfoBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.UcInfoBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcInfoBox.HelpText = resources.GetString("UcInfoBox.HelpText")
        Me.UcInfoBox.Location = New System.Drawing.Point(32, 368)
        Me.UcInfoBox.Name = "UcInfoBox"
        Me.UcInfoBox.Size = New System.Drawing.Size(561, 196)
        Me.UcInfoBox.TabIndex = 30
        '
        'cmbFormatoProdotto
        '
        Me.cmbFormatoProdotto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFormatoProdotto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFormatoProdotto.FormattingEnabled = True
        Me.cmbFormatoProdotto.Location = New System.Drawing.Point(166, 61)
        Me.cmbFormatoProdotto.Name = "cmbFormatoProdotto"
        Me.cmbFormatoProdotto.Size = New System.Drawing.Size(339, 21)
        Me.cmbFormatoProdotto.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Orange
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Formato Prodotto"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Prezzo
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(48, 48)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(60, 18)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(158, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Prezzo Lavorazione"
        '
        'frmListinoPrezzoLavorazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(628, 653)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoPrezzoLavorazione"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Prezzo Lavorazione"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbFormatoProdotto As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPrezzo As ucNumericTextBox
    Friend WithEvents lblRispz As System.Windows.Forms.Label
    Friend WithEvents txtPezziRif As ucNumericTextBox
    Friend WithEvents txtPrezzoMin As ucNumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrezzoOltre As ucNumericTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblRisOltre As System.Windows.Forms.Label
    Friend WithEvents lblRisMin As System.Windows.Forms.Label
    Friend WithEvents UcInfoBox As ucInfoBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblRisOltre2 As Label
    Friend WithEvents txtPrezzo2 As ucNumericTextBox
    Friend WithEvents lblRisMin2 As Label
    Friend WithEvents lblRispz2 As Label
    Friend WithEvents txtPrezzoOltre2 As ucNumericTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtPrezzoMin2 As ucNumericTextBox
    Friend WithEvents txtPezziRif2 As ucNumericTextBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
