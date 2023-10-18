<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcNumerazione
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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCreaPDF = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtParteFissa = New Former.ucNumericTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkBarcode = New System.Windows.Forms.CheckBox()
        Me.btnCreaCSV = New System.Windows.Forms.Button()
        Me.lblSoluzOttimale = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSoluzMinima = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblNumReale = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFogliCalc = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFogliProposti = New Former.ucNumericTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnProponiSoluz = New System.Windows.Forms.Button()
        Me.lblNumPrevista = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumIniziale = New Former.ucNumericTextBox()
        Me.txtNumBlocchi = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFogliBlocco = New Former.ucNumericTextBox()
        Me.txtPosizPag = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 631)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(405, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(363, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(405, 631)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.GroupBox2)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(397, 603)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Numerazione automatica"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCreaPDF)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.btnCreaCSV)
        Me.GroupBox2.Controls.Add(Me.lblSoluzOttimale)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblSoluzMinima)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblNumReale)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblFogliCalc)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtFogliProposti)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(53, 259)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 314)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Soluzione Proposta"
        '
        'btnCreaPDF
        '
        Me.btnCreaPDF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreaPDF.Location = New System.Drawing.Point(21, 270)
        Me.btnCreaPDF.Name = "btnCreaPDF"
        Me.btnCreaPDF.Size = New System.Drawing.Size(242, 23)
        Me.btnCreaPDF.TabIndex = 32
        Me.btnCreaPDF.Text = "Crea PDF"
        Me.toolTipHelp.SetToolTip(Me.btnCreaPDF, "Ricordarsi di avere prima una soluzione proposta")
        Me.btnCreaPDF.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtParteFissa)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.chkBarcode)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 143)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(288, 78)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Codice a Barre"
        '
        'txtParteFissa
        '
        Me.txtParteFissa.Location = New System.Drawing.Point(165, 44)
        Me.txtParteFissa.MaxLength = 12
        Me.txtParteFissa.My_AccettaNegativi = False
        Me.txtParteFissa.My_AllowOnlyInteger = True
        Me.txtParteFissa.My_DefaultValue = 1
        Me.txtParteFissa.My_MaxValue = 1.0E+10!
        Me.txtParteFissa.My_MinValue = 0!
        Me.txtParteFissa.My_ReplaceWithDefaultValue = True
        Me.txtParteFissa.Name = "txtParteFissa"
        Me.txtParteFissa.Size = New System.Drawing.Size(117, 23)
        Me.txtParteFissa.TabIndex = 32
        Me.txtParteFissa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 15)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Parte Fissa"
        '
        'chkBarcode
        '
        Me.chkBarcode.AutoSize = True
        Me.chkBarcode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkBarcode.Location = New System.Drawing.Point(9, 26)
        Me.chkBarcode.Name = "chkBarcode"
        Me.chkBarcode.Size = New System.Drawing.Size(139, 19)
        Me.chkBarcode.TabIndex = 30
        Me.chkBarcode.Text = "Genera Codici a Barre"
        Me.chkBarcode.UseVisualStyleBackColor = True
        '
        'btnCreaCSV
        '
        Me.btnCreaCSV.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreaCSV.Location = New System.Drawing.Point(21, 241)
        Me.btnCreaCSV.Name = "btnCreaCSV"
        Me.btnCreaCSV.Size = New System.Drawing.Size(242, 23)
        Me.btnCreaCSV.TabIndex = 29
        Me.btnCreaCSV.Text = "Crea CSV"
        Me.toolTipHelp.SetToolTip(Me.btnCreaCSV, "Ricordarsi di avere prima una soluzione proposta")
        Me.btnCreaCSV.UseVisualStyleBackColor = True
        '
        'lblSoluzOttimale
        '
        Me.lblSoluzOttimale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSoluzOttimale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSoluzOttimale.ForeColor = System.Drawing.Color.Black
        Me.lblSoluzOttimale.Location = New System.Drawing.Point(171, 67)
        Me.lblSoluzOttimale.Name = "lblSoluzOttimale"
        Me.lblSoluzOttimale.Size = New System.Drawing.Size(117, 21)
        Me.lblSoluzOttimale.TabIndex = 28
        Me.lblSoluzOttimale.Text = "0"
        Me.lblSoluzOttimale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(6, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Soluz. Ottimale"
        '
        'lblSoluzMinima
        '
        Me.lblSoluzMinima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSoluzMinima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSoluzMinima.ForeColor = System.Drawing.Color.Black
        Me.lblSoluzMinima.Location = New System.Drawing.Point(171, 40)
        Me.lblSoluzMinima.Name = "lblSoluzMinima"
        Me.lblSoluzMinima.Size = New System.Drawing.Size(117, 21)
        Me.lblSoluzMinima.TabIndex = 26
        Me.lblSoluzMinima.Text = "0"
        Me.lblSoluzMinima.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 15)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Soluz. Minima"
        '
        'lblNumReale
        '
        Me.lblNumReale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumReale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNumReale.ForeColor = System.Drawing.Color.Black
        Me.lblNumReale.Location = New System.Drawing.Point(171, 118)
        Me.lblNumReale.Name = "lblNumReale"
        Me.lblNumReale.Size = New System.Drawing.Size(117, 21)
        Me.lblNumReale.TabIndex = 24
        Me.lblNumReale.Text = "0"
        Me.lblNumReale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 15)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Numerazione Finale"
        '
        'lblFogliCalc
        '
        Me.lblFogliCalc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFogliCalc.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFogliCalc.ForeColor = System.Drawing.Color.Black
        Me.lblFogliCalc.Location = New System.Drawing.Point(171, 13)
        Me.lblFogliCalc.Name = "lblFogliCalc"
        Me.lblFogliCalc.Size = New System.Drawing.Size(117, 21)
        Me.lblFogliCalc.TabIndex = 22
        Me.lblFogliCalc.Text = "0"
        Me.lblFogliCalc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Fogli Calcolati"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Fogli Proposti"
        '
        'txtFogliProposti
        '
        Me.txtFogliProposti.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtFogliProposti.Location = New System.Drawing.Point(171, 94)
        Me.txtFogliProposti.MaxLength = 6
        Me.txtFogliProposti.My_AccettaNegativi = False
        Me.txtFogliProposti.My_AllowOnlyInteger = True
        Me.txtFogliProposti.My_DefaultValue = 1
        Me.txtFogliProposti.My_MaxValue = 100000.0!
        Me.txtFogliProposti.My_MinValue = 1.0!
        Me.txtFogliProposti.My_ReplaceWithDefaultValue = True
        Me.txtFogliProposti.Name = "txtFogliProposti"
        Me.txtFogliProposti.Size = New System.Drawing.Size(117, 23)
        Me.txtFogliProposti.TabIndex = 20
        Me.txtFogliProposti.Text = "1"
        Me.txtFogliProposti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnProponiSoluz)
        Me.GroupBox1.Controls.Add(Me.lblNumPrevista)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtNumIniziale)
        Me.GroupBox1.Controls.Add(Me.txtNumBlocchi)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFogliBlocco)
        Me.GroupBox1.Controls.Add(Me.txtPosizPag)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 188)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dati Numerazione"
        '
        'btnProponiSoluz
        '
        Me.btnProponiSoluz.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnProponiSoluz.Location = New System.Drawing.Point(90, 154)
        Me.btnProponiSoluz.Name = "btnProponiSoluz"
        Me.btnProponiSoluz.Size = New System.Drawing.Size(117, 23)
        Me.btnProponiSoluz.TabIndex = 27
        Me.btnProponiSoluz.Text = "Proponi Soluzione"
        Me.toolTipHelp.SetToolTip(Me.btnProponiSoluz, "Propone una soluzione in base ai parametri inseriti sopra")
        Me.btnProponiSoluz.UseVisualStyleBackColor = True
        '
        'lblNumPrevista
        '
        Me.lblNumPrevista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumPrevista.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNumPrevista.ForeColor = System.Drawing.Color.Black
        Me.lblNumPrevista.Location = New System.Drawing.Point(171, 119)
        Me.lblNumPrevista.Name = "lblNumPrevista"
        Me.lblNumPrevista.Size = New System.Drawing.Size(117, 21)
        Me.lblNumPrevista.TabIndex = 26
        Me.lblNumPrevista.Text = "0"
        Me.lblNumPrevista.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(6, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 15)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Numerazione Prevista"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Numero Blocchi"
        '
        'txtNumIniziale
        '
        Me.txtNumIniziale.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumIniziale.Location = New System.Drawing.Point(171, 95)
        Me.txtNumIniziale.MaxLength = 7
        Me.txtNumIniziale.My_AccettaNegativi = False
        Me.txtNumIniziale.My_AllowOnlyInteger = True
        Me.txtNumIniziale.My_DefaultValue = 1
        Me.txtNumIniziale.My_MaxValue = 1000000.0!
        Me.txtNumIniziale.My_MinValue = 0!
        Me.txtNumIniziale.My_ReplaceWithDefaultValue = True
        Me.txtNumIniziale.Name = "txtNumIniziale"
        Me.txtNumIniziale.Size = New System.Drawing.Size(117, 23)
        Me.txtNumIniziale.TabIndex = 24
        Me.txtNumIniziale.Text = "1"
        Me.txtNumIniziale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumBlocchi
        '
        Me.txtNumBlocchi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumBlocchi.Location = New System.Drawing.Point(171, 14)
        Me.txtNumBlocchi.MaxLength = 6
        Me.txtNumBlocchi.My_AccettaNegativi = False
        Me.txtNumBlocchi.My_AllowOnlyInteger = True
        Me.txtNumBlocchi.My_DefaultValue = 0
        Me.txtNumBlocchi.My_MaxValue = 999999.0!
        Me.txtNumBlocchi.My_MinValue = 0!
        Me.txtNumBlocchi.My_ReplaceWithDefaultValue = True
        Me.txtNumBlocchi.Name = "txtNumBlocchi"
        Me.txtNumBlocchi.Size = New System.Drawing.Size(117, 23)
        Me.txtNumBlocchi.TabIndex = 18
        Me.txtNumBlocchi.Text = "1000"
        Me.txtNumBlocchi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Fogli del Blocco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Numero Iniziale"
        '
        'txtFogliBlocco
        '
        Me.txtFogliBlocco.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtFogliBlocco.Location = New System.Drawing.Point(171, 41)
        Me.txtFogliBlocco.MaxLength = 6
        Me.txtFogliBlocco.My_AccettaNegativi = False
        Me.txtFogliBlocco.My_AllowOnlyInteger = True
        Me.txtFogliBlocco.My_DefaultValue = 0
        Me.txtFogliBlocco.My_MaxValue = 100000.0!
        Me.txtFogliBlocco.My_MinValue = 1.0!
        Me.txtFogliBlocco.My_ReplaceWithDefaultValue = True
        Me.txtFogliBlocco.Name = "txtFogliBlocco"
        Me.txtFogliBlocco.Size = New System.Drawing.Size(117, 23)
        Me.txtFogliBlocco.TabIndex = 20
        Me.txtFogliBlocco.Text = "50"
        Me.txtFogliBlocco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPosizPag
        '
        Me.txtPosizPag.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtPosizPag.Location = New System.Drawing.Point(171, 68)
        Me.txtPosizPag.MaxLength = 3
        Me.txtPosizPag.My_AccettaNegativi = False
        Me.txtPosizPag.My_AllowOnlyInteger = True
        Me.txtPosizPag.My_DefaultValue = 1
        Me.txtPosizPag.My_MaxValue = 1000.0!
        Me.txtPosizPag.My_MinValue = 1.0!
        Me.txtPosizPag.My_ReplaceWithDefaultValue = True
        Me.txtPosizPag.Name = "txtPosizPag"
        Me.txtPosizPag.Size = New System.Drawing.Size(117, 23)
        Me.txtPosizPag.TabIndex = 22
        Me.txtPosizPag.Text = "8"
        Me.txtPosizPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "N° Posizioni Pagina"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.calendar3
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
        Me.lblTipo.Size = New System.Drawing.Size(207, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Numerazione Automatica"
        '
        'frmCalcNumerazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(405, 679)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmCalcNumerazione"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Numerazione Automatica"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtNumIniziale As ucNumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPosizPag As ucNumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFogliBlocco As ucNumericTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumBlocchi As ucNumericTextBox
    Friend WithEvents btnProponiSoluz As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNumReale As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblFogliCalc As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFogliProposti As ucNumericTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSoluzOttimale As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblSoluzMinima As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblNumPrevista As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnCreaCSV As System.Windows.Forms.Button
    Friend WithEvents chkBarcode As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtParteFissa As ucNumericTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnCreaPDF As Button
End Class
