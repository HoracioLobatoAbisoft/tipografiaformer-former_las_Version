<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCalcPeso
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
        Me.lblColli2 = New System.Windows.Forms.Label()
        Me.lblColli = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNumPezzi2 = New Former.ucNumericTextBox()
        Me.txtNumPezzi = New Former.ucNumericTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrezzoKg2 = New System.Windows.Forms.TextBox()
        Me.txtPrezzoKg = New System.Windows.Forms.TextBox()
        Me.lblDiffPrezzoCarta = New System.Windows.Forms.Label()
        Me.lblPrezzoCarta2 = New System.Windows.Forms.Label()
        Me.lblPrezzoCarta = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblDiffKg = New System.Windows.Forms.Label()
        Me.lblKilogrammi2 = New System.Windows.Forms.Label()
        Me.lblKilogrammi = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtFogli2 = New System.Windows.Forms.TextBox()
        Me.txtFogli = New System.Windows.Forms.TextBox()
        Me.txtGrammatura2 = New System.Windows.Forms.TextBox()
        Me.txtGrammatura = New System.Windows.Forms.TextBox()
        Me.txtLarghezza2 = New System.Windows.Forms.TextBox()
        Me.txtLarghezza = New System.Windows.Forms.TextBox()
        Me.txtAltezza2 = New System.Windows.Forms.TextBox()
        Me.txtAltezza = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 410)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(725, 48)
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
        Me.btnCancel.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnCancel.Location = New System.Drawing.Point(682, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(32, 32)
        Me.btnCancel.TabIndex = 4
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
        Me.TabMain.Size = New System.Drawing.Size(725, 410)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblColli2)
        Me.tbProd.Controls.Add(Me.lblColli)
        Me.tbProd.Controls.Add(Me.Label15)
        Me.tbProd.Controls.Add(Me.txtNumPezzi2)
        Me.tbProd.Controls.Add(Me.txtNumPezzi)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.txtPrezzoKg2)
        Me.tbProd.Controls.Add(Me.txtPrezzoKg)
        Me.tbProd.Controls.Add(Me.lblDiffPrezzoCarta)
        Me.tbProd.Controls.Add(Me.lblPrezzoCarta2)
        Me.tbProd.Controls.Add(Me.lblPrezzoCarta)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.lblDiffKg)
        Me.tbProd.Controls.Add(Me.lblKilogrammi2)
        Me.tbProd.Controls.Add(Me.lblKilogrammi)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.TxtFogli2)
        Me.tbProd.Controls.Add(Me.txtFogli)
        Me.tbProd.Controls.Add(Me.txtGrammatura2)
        Me.tbProd.Controls.Add(Me.txtGrammatura)
        Me.tbProd.Controls.Add(Me.txtLarghezza2)
        Me.tbProd.Controls.Add(Me.txtLarghezza)
        Me.tbProd.Controls.Add(Me.txtAltezza2)
        Me.tbProd.Controls.Add(Me.txtAltezza)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(717, 384)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Calcolo PESO e COLLI"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblColli2
        '
        Me.lblColli2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblColli2.ForeColor = System.Drawing.Color.Red
        Me.lblColli2.Location = New System.Drawing.Point(375, 311)
        Me.lblColli2.Name = "lblColli2"
        Me.lblColli2.Size = New System.Drawing.Size(157, 29)
        Me.lblColli2.TabIndex = 27
        Me.lblColli2.Text = "0"
        Me.lblColli2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblColli
        '
        Me.lblColli.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblColli.ForeColor = System.Drawing.Color.Red
        Me.lblColli.Location = New System.Drawing.Point(174, 311)
        Me.lblColli.Name = "lblColli"
        Me.lblColli.Size = New System.Drawing.Size(157, 29)
        Me.lblColli.TabIndex = 28
        Me.lblColli.Text = "0"
        Me.lblColli.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(50, 321)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 15)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "COLLI PREVISTI"
        '
        'txtNumPezzi2
        '
        Me.txtNumPezzi2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumPezzi2.Location = New System.Drawing.Point(375, 222)
        Me.txtNumPezzi2.MaxLength = 6
        Me.txtNumPezzi2.My_AccettaNegativi = False
        Me.txtNumPezzi2.My_AllowOnlyInteger = True
        Me.txtNumPezzi2.My_DefaultValue = 1
        Me.txtNumPezzi2.My_MaxValue = 999999.0!
        Me.txtNumPezzi2.My_MinValue = 1.0!
        Me.txtNumPezzi2.My_ReplaceWithDefaultValue = True
        Me.txtNumPezzi2.Name = "txtNumPezzi2"
        Me.txtNumPezzi2.Size = New System.Drawing.Size(157, 27)
        Me.txtNumPezzi2.TabIndex = 26
        Me.txtNumPezzi2.Text = "1"
        Me.txtNumPezzi2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumPezzi
        '
        Me.txtNumPezzi.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumPezzi.Location = New System.Drawing.Point(174, 222)
        Me.txtNumPezzi.MaxLength = 6
        Me.txtNumPezzi.My_AccettaNegativi = False
        Me.txtNumPezzi.My_AllowOnlyInteger = True
        Me.txtNumPezzi.My_DefaultValue = 1
        Me.txtNumPezzi.My_MaxValue = 999999.0!
        Me.txtNumPezzi.My_MinValue = 1.0!
        Me.txtNumPezzi.My_ReplaceWithDefaultValue = True
        Me.txtNumPezzi.Name = "txtNumPezzi"
        Me.txtNumPezzi.Size = New System.Drawing.Size(157, 27)
        Me.txtNumPezzi.TabIndex = 26
        Me.txtNumPezzi.Text = "1"
        Me.txtNumPezzi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(50, 229)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 15)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Pezzi"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(50, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 15)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Prezzo al Kg"
        '
        'txtPrezzoKg2
        '
        Me.txtPrezzoKg2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrezzoKg2.Location = New System.Drawing.Point(375, 189)
        Me.txtPrezzoKg2.MaxLength = 50
        Me.txtPrezzoKg2.Name = "txtPrezzoKg2"
        Me.txtPrezzoKg2.Size = New System.Drawing.Size(157, 27)
        Me.txtPrezzoKg2.TabIndex = 9
        Me.txtPrezzoKg2.Text = "1,00"
        Me.txtPrezzoKg2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrezzoKg
        '
        Me.txtPrezzoKg.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrezzoKg.Location = New System.Drawing.Point(174, 189)
        Me.txtPrezzoKg.MaxLength = 50
        Me.txtPrezzoKg.Name = "txtPrezzoKg"
        Me.txtPrezzoKg.Size = New System.Drawing.Size(157, 27)
        Me.txtPrezzoKg.TabIndex = 4
        Me.txtPrezzoKg.Text = "1,00"
        Me.txtPrezzoKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiffPrezzoCarta
        '
        Me.lblDiffPrezzoCarta.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiffPrezzoCarta.ForeColor = System.Drawing.Color.Green
        Me.lblDiffPrezzoCarta.Location = New System.Drawing.Point(541, 252)
        Me.lblDiffPrezzoCarta.Name = "lblDiffPrezzoCarta"
        Me.lblDiffPrezzoCarta.Size = New System.Drawing.Size(158, 29)
        Me.lblDiffPrezzoCarta.TabIndex = 21
        Me.lblDiffPrezzoCarta.Text = "0"
        Me.lblDiffPrezzoCarta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPrezzoCarta2
        '
        Me.lblPrezzoCarta2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrezzoCarta2.ForeColor = System.Drawing.Color.Red
        Me.lblPrezzoCarta2.Location = New System.Drawing.Point(375, 252)
        Me.lblPrezzoCarta2.Name = "lblPrezzoCarta2"
        Me.lblPrezzoCarta2.Size = New System.Drawing.Size(157, 29)
        Me.lblPrezzoCarta2.TabIndex = 21
        Me.lblPrezzoCarta2.Text = "0"
        Me.lblPrezzoCarta2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPrezzoCarta
        '
        Me.lblPrezzoCarta.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrezzoCarta.ForeColor = System.Drawing.Color.Red
        Me.lblPrezzoCarta.Location = New System.Drawing.Point(174, 252)
        Me.lblPrezzoCarta.Name = "lblPrezzoCarta"
        Me.lblPrezzoCarta.Size = New System.Drawing.Size(157, 29)
        Me.lblPrezzoCarta.TabIndex = 21
        Me.lblPrezzoCarta.Text = "0"
        Me.lblPrezzoCarta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(50, 262)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 15)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "PREZZO CARTA"
        '
        'lblDiffKg
        '
        Me.lblDiffKg.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiffKg.ForeColor = System.Drawing.Color.Green
        Me.lblDiffKg.Location = New System.Drawing.Point(541, 282)
        Me.lblDiffKg.Name = "lblDiffKg"
        Me.lblDiffKg.Size = New System.Drawing.Size(158, 29)
        Me.lblDiffKg.TabIndex = 21
        Me.lblDiffKg.Text = "0"
        Me.lblDiffKg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKilogrammi2
        '
        Me.lblKilogrammi2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilogrammi2.ForeColor = System.Drawing.Color.Red
        Me.lblKilogrammi2.Location = New System.Drawing.Point(375, 282)
        Me.lblKilogrammi2.Name = "lblKilogrammi2"
        Me.lblKilogrammi2.Size = New System.Drawing.Size(157, 29)
        Me.lblKilogrammi2.TabIndex = 21
        Me.lblKilogrammi2.Text = "0"
        Me.lblKilogrammi2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKilogrammi
        '
        Me.lblKilogrammi.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilogrammi.ForeColor = System.Drawing.Color.Red
        Me.lblKilogrammi.Location = New System.Drawing.Point(174, 282)
        Me.lblKilogrammi.Name = "lblKilogrammi"
        Me.lblKilogrammi.Size = New System.Drawing.Size(157, 29)
        Me.lblKilogrammi.TabIndex = 21
        Me.lblKilogrammi.Text = "0"
        Me.lblKilogrammi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(50, 292)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "PESO KG"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Fogli"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Grammatura"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Larghezza"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(538, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 15)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "(cm)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(337, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "(cm)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(538, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 15)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "(cm)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(337, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "(cm)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Altezza"
        '
        'TxtFogli2
        '
        Me.TxtFogli2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.TxtFogli2.Location = New System.Drawing.Point(375, 156)
        Me.TxtFogli2.MaxLength = 50
        Me.TxtFogli2.Name = "TxtFogli2"
        Me.TxtFogli2.Size = New System.Drawing.Size(157, 27)
        Me.TxtFogli2.TabIndex = 8
        Me.TxtFogli2.Text = "0"
        Me.TxtFogli2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFogli
        '
        Me.txtFogli.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtFogli.Location = New System.Drawing.Point(174, 156)
        Me.txtFogli.MaxLength = 50
        Me.txtFogli.Name = "txtFogli"
        Me.txtFogli.Size = New System.Drawing.Size(157, 27)
        Me.txtFogli.TabIndex = 3
        Me.txtFogli.Text = "0"
        Me.txtFogli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrammatura2
        '
        Me.txtGrammatura2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGrammatura2.Location = New System.Drawing.Point(375, 123)
        Me.txtGrammatura2.MaxLength = 50
        Me.txtGrammatura2.Name = "txtGrammatura2"
        Me.txtGrammatura2.Size = New System.Drawing.Size(157, 27)
        Me.txtGrammatura2.TabIndex = 7
        Me.txtGrammatura2.Text = "0"
        Me.txtGrammatura2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrammatura
        '
        Me.txtGrammatura.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGrammatura.Location = New System.Drawing.Point(174, 123)
        Me.txtGrammatura.MaxLength = 50
        Me.txtGrammatura.Name = "txtGrammatura"
        Me.txtGrammatura.Size = New System.Drawing.Size(157, 27)
        Me.txtGrammatura.TabIndex = 2
        Me.txtGrammatura.Text = "0"
        Me.txtGrammatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLarghezza2
        '
        Me.txtLarghezza2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtLarghezza2.Location = New System.Drawing.Point(375, 90)
        Me.txtLarghezza2.MaxLength = 50
        Me.txtLarghezza2.Name = "txtLarghezza2"
        Me.txtLarghezza2.Size = New System.Drawing.Size(157, 27)
        Me.txtLarghezza2.TabIndex = 6
        Me.txtLarghezza2.Text = "0"
        Me.txtLarghezza2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLarghezza
        '
        Me.txtLarghezza.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtLarghezza.Location = New System.Drawing.Point(174, 90)
        Me.txtLarghezza.MaxLength = 50
        Me.txtLarghezza.Name = "txtLarghezza"
        Me.txtLarghezza.Size = New System.Drawing.Size(157, 27)
        Me.txtLarghezza.TabIndex = 1
        Me.txtLarghezza.Text = "0"
        Me.txtLarghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAltezza2
        '
        Me.txtAltezza2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtAltezza2.Location = New System.Drawing.Point(375, 57)
        Me.txtAltezza2.MaxLength = 50
        Me.txtAltezza2.Name = "txtAltezza2"
        Me.txtAltezza2.Size = New System.Drawing.Size(157, 27)
        Me.txtAltezza2.TabIndex = 5
        Me.txtAltezza2.Text = "0"
        Me.txtAltezza2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAltezza
        '
        Me.txtAltezza.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtAltezza.Location = New System.Drawing.Point(174, 57)
        Me.txtAltezza.MaxLength = 50
        Me.txtAltezza.Name = "txtAltezza"
        Me.txtAltezza.Size = New System.Drawing.Size(157, 27)
        Me.txtAltezza.TabIndex = 0
        Me.txtAltezza.Text = "0"
        Me.txtAltezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.scale
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
        Me.lblTipo.Size = New System.Drawing.Size(159, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Calcolo Peso e Colli"
        '
        'frmCalcPeso
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(725, 458)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmCalcPeso"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - "
        Me.gbPulsanti.ResumeLayout(False)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAltezza As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFogli As System.Windows.Forms.TextBox
    Friend WithEvents txtGrammatura As System.Windows.Forms.TextBox
    Friend WithEvents txtLarghezza As System.Windows.Forms.TextBox
    Friend WithEvents lblKilogrammi As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPrezzoKg As System.Windows.Forms.TextBox
    Friend WithEvents lblPrezzoCarta As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPrezzoKg2 As System.Windows.Forms.TextBox
    Friend WithEvents lblDiffPrezzoCarta As System.Windows.Forms.Label
    Friend WithEvents lblPrezzoCarta2 As System.Windows.Forms.Label
    Friend WithEvents lblDiffKg As System.Windows.Forms.Label
    Friend WithEvents lblKilogrammi2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtFogli2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGrammatura2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLarghezza2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAltezza2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNumPezzi2 As ucNumericTextBox
    Friend WithEvents txtNumPezzi As ucNumericTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lblColli2 As Label
    Friend WithEvents lblColli As Label
    Friend WithEvents Label15 As Label
End Class
