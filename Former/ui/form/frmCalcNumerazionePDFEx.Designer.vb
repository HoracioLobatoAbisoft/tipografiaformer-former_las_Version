<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCalcNumerazionePDFEx
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.btnApri = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgDuplicati = New Telerik.WinControls.UI.RadGridView()
        Me.lnkRimuoviDupl = New System.Windows.Forms.Button()
        Me.lnkAddDupl = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txtNumPagX = New Former.ucNumericTextBox()
        Me.txtNumPagY = New Former.ucNumericTextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.chkNumPagina = New System.Windows.Forms.CheckBox()
        Me.txtMaxPageFile = New Former.ucNumericTextBox()
        Me.rdoMultiFile = New System.Windows.Forms.RadioButton()
        Me.rdoSingFile = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkCompletaZeri = New System.Windows.Forms.CheckBox()
        Me.chkInverso = New System.Windows.Forms.CheckBox()
        Me.lblOrient = New System.Windows.Forms.Label()
        Me.chkRuota = New System.Windows.Forms.CheckBox()
        Me.cmbFont = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtGrandezzaFont = New Former.ucNumericTextBox()
        Me.txtSuffisso = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLarghezzaEtichetta = New Former.ucNumericTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAltezzaEtichetta = New Former.ucNumericTextBox()
        Me.txtPrefisso = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBassoX = New Former.ucNumericTextBox()
        Me.txtPassoY = New Former.ucNumericTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBassoY = New Former.ucNumericTextBox()
        Me.txtPassoX = New Former.ucNumericTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCSV = New System.Windows.Forms.TextBox()
        Me.btnCSV = New System.Windows.Forms.Button()
        Me.chkCSVEtichette = New System.Windows.Forms.CheckBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.chkPDFSfondo = New System.Windows.Forms.CheckBox()
        Me.txtSfondo = New System.Windows.Forms.TextBox()
        Me.btnSfondo = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNumColonne = New Former.ucNumericTextBox()
        Me.txtNumRighe = New Former.ucNumericTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtLarghezza = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAltezza = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGeneraPDF = New System.Windows.Forms.Button()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.dlgSaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.dlgOpenSfondo = New System.Windows.Forms.OpenFileDialog()
        Me.chkOnlyFront = New System.Windows.Forms.CheckBox()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgDuplicati, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDuplicati.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnSalva)
        Me.gbPulsanti.Controls.Add(Me.btnApri)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 751)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1091, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnSalva
        '
        Me.btnSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalva.AutoSize = True
        Me.btnSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalva.FlatAppearance.BorderSize = 0
        Me.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSalva.Image = Global.Former.My.Resources.Resources._Save
        Me.btnSalva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalva.Location = New System.Drawing.Point(135, 12)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(72, 32)
        Me.btnSalva.TabIndex = 25
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'btnApri
        '
        Me.btnApri.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApri.AutoSize = True
        Me.btnApri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnApri.FlatAppearance.BorderSize = 0
        Me.btnApri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApri.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnApri.Image = Global.Former.My.Resources.Resources._CartellaAperta
        Me.btnApri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApri.Location = New System.Drawing.Point(57, 12)
        Me.btnApri.Name = "btnApri"
        Me.btnApri.Size = New System.Drawing.Size(72, 32)
        Me.btnApri.TabIndex = 24
        Me.btnApri.Text = "Apri..."
        Me.btnApri.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnApri.UseVisualStyleBackColor = True
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
        Me.btnCancel.Location = New System.Drawing.Point(960, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 26
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
        Me.TabMain.Size = New System.Drawing.Size(1091, 751)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.GroupBox6)
        Me.tbProd.Controls.Add(Me.GroupBox5)
        Me.tbProd.Controls.Add(Me.GroupBox2)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.btnGeneraPDF)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1083, 725)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Parametri Creazione PDF"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgDuplicati)
        Me.GroupBox6.Controls.Add(Me.lnkRimuoviDupl)
        Me.GroupBox6.Controls.Add(Me.lnkAddDupl)
        Me.GroupBox6.Location = New System.Drawing.Point(383, 260)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(651, 325)
        Me.GroupBox6.TabIndex = 60
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Lista duplicati"
        '
        'dgDuplicati
        '
        Me.dgDuplicati.Location = New System.Drawing.Point(8, 21)
        '
        '
        '
        Me.dgDuplicati.MasterTemplate.AllowAddNewRow = False
        Me.dgDuplicati.MasterTemplate.AllowColumnChooser = False
        Me.dgDuplicati.MasterTemplate.AllowColumnReorder = False
        Me.dgDuplicati.MasterTemplate.AllowDeleteRow = False
        Me.dgDuplicati.MasterTemplate.AllowDragToGroup = False
        Me.dgDuplicati.MasterTemplate.AllowEditRow = False
        Me.dgDuplicati.MasterTemplate.AutoGenerateColumns = False
        GridViewTextBoxColumn1.FieldName = "FontNome"
        GridViewTextBoxColumn1.HeaderText = "Font"
        GridViewTextBoxColumn1.Name = "FontNome"
        GridViewTextBoxColumn1.Width = 150
        GridViewTextBoxColumn2.FieldName = "PrimoAngoloBassoSx_X"
        GridViewTextBoxColumn2.HeaderText = "Basso Sx X"
        GridViewTextBoxColumn2.Name = "Basso Sx X"
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.FieldName = "PrimoAngoloBassoSx_Y"
        GridViewTextBoxColumn3.HeaderText = "Basso Sx Y"
        GridViewTextBoxColumn3.Name = "Basso Sx Y"
        GridViewTextBoxColumn3.Width = 100
        Me.dgDuplicati.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3})
        Me.dgDuplicati.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgDuplicati.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgDuplicati.Name = "dgDuplicati"
        Me.dgDuplicati.ShowGroupPanel = False
        Me.dgDuplicati.ShowGroupPanelScrollbars = False
        Me.dgDuplicati.Size = New System.Drawing.Size(637, 260)
        Me.dgDuplicati.TabIndex = 19
        Me.dgDuplicati.ThemeName = "VisualStudio2012Light"
        '
        'lnkRimuoviDupl
        '
        Me.lnkRimuoviDupl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkRimuoviDupl.AutoSize = True
        Me.lnkRimuoviDupl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.lnkRimuoviDupl.FlatAppearance.BorderSize = 0
        Me.lnkRimuoviDupl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkRimuoviDupl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRimuoviDupl.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkRimuoviDupl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRimuoviDupl.Location = New System.Drawing.Point(564, 287)
        Me.lnkRimuoviDupl.Name = "lnkRimuoviDupl"
        Me.lnkRimuoviDupl.Size = New System.Drawing.Size(81, 32)
        Me.lnkRimuoviDupl.TabIndex = 18
        Me.lnkRimuoviDupl.Text = "Elimina"
        Me.lnkRimuoviDupl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkRimuoviDupl.UseVisualStyleBackColor = True
        '
        'lnkAddDupl
        '
        Me.lnkAddDupl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAddDupl.AutoSize = True
        Me.lnkAddDupl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.lnkAddDupl.FlatAppearance.BorderSize = 0
        Me.lnkAddDupl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkAddDupl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAddDupl.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAddDupl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAddDupl.Location = New System.Drawing.Point(6, 287)
        Me.lnkAddDupl.Name = "lnkAddDupl"
        Me.lnkAddDupl.Size = New System.Drawing.Size(88, 32)
        Me.lnkAddDupl.TabIndex = 17
        Me.lnkAddDupl.Text = "Aggiungi"
        Me.lnkAddDupl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkAddDupl.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkOnlyFront)
        Me.GroupBox5.Controls.Add(Me.Label61)
        Me.GroupBox5.Controls.Add(Me.Label62)
        Me.GroupBox5.Controls.Add(Me.txtNumPagX)
        Me.GroupBox5.Controls.Add(Me.txtNumPagY)
        Me.GroupBox5.Controls.Add(Me.Label59)
        Me.GroupBox5.Controls.Add(Me.Label60)
        Me.GroupBox5.Controls.Add(Me.chkNumPagina)
        Me.GroupBox5.Controls.Add(Me.txtMaxPageFile)
        Me.GroupBox5.Controls.Add(Me.rdoMultiFile)
        Me.GroupBox5.Controls.Add(Me.rdoSingFile)
        Me.GroupBox5.Location = New System.Drawing.Point(53, 592)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(981, 70)
        Me.GroupBox5.TabIndex = 59
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Generazione File"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(791, 18)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(14, 15)
        Me.Label61.TabIndex = 179
        Me.Label61.Text = "X"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(791, 45)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(14, 15)
        Me.Label62.TabIndex = 180
        Me.Label62.Text = "Y"
        '
        'txtNumPagX
        '
        Me.txtNumPagX.Location = New System.Drawing.Point(811, 15)
        Me.txtNumPagX.My_AccettaNegativi = False
        Me.txtNumPagX.My_AllowOnlyInteger = False
        Me.txtNumPagX.My_DefaultValue = 100
        Me.txtNumPagX.My_MaxValue = 1.0E+10!
        Me.txtNumPagX.My_MinValue = 1.0!
        Me.txtNumPagX.My_ReplaceWithDefaultValue = True
        Me.txtNumPagX.Name = "txtNumPagX"
        Me.txtNumPagX.Size = New System.Drawing.Size(47, 20)
        Me.txtNumPagX.TabIndex = 175
        Me.txtNumPagX.Text = "5"
        Me.txtNumPagX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumPagY
        '
        Me.txtNumPagY.Location = New System.Drawing.Point(811, 42)
        Me.txtNumPagY.My_AccettaNegativi = False
        Me.txtNumPagY.My_AllowOnlyInteger = False
        Me.txtNumPagY.My_DefaultValue = 100
        Me.txtNumPagY.My_MaxValue = 1.0E+10!
        Me.txtNumPagY.My_MinValue = 1.0!
        Me.txtNumPagY.My_ReplaceWithDefaultValue = True
        Me.txtNumPagY.Name = "txtNumPagY"
        Me.txtNumPagY.Size = New System.Drawing.Size(47, 20)
        Me.txtNumPagY.TabIndex = 176
        Me.txtNumPagY.Text = "5"
        Me.txtNumPagY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(864, 18)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(37, 15)
        Me.Label59.TabIndex = 177
        Me.Label59.Text = "(mm)"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(864, 45)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(37, 15)
        Me.Label60.TabIndex = 178
        Me.Label60.Text = "(mm)"
        '
        'chkNumPagina
        '
        Me.chkNumPagina.AutoSize = True
        Me.chkNumPagina.Location = New System.Drawing.Point(658, 31)
        Me.chkNumPagina.Name = "chkNumPagina"
        Me.chkNumPagina.Size = New System.Drawing.Size(109, 19)
        Me.chkNumPagina.TabIndex = 174
        Me.chkNumPagina.Text = "Numero Pagina"
        Me.chkNumPagina.UseVisualStyleBackColor = True
        '
        'txtMaxPageFile
        '
        Me.txtMaxPageFile.Location = New System.Drawing.Point(451, 29)
        Me.txtMaxPageFile.My_AccettaNegativi = False
        Me.txtMaxPageFile.My_AllowOnlyInteger = True
        Me.txtMaxPageFile.My_DefaultValue = 1
        Me.txtMaxPageFile.My_MaxValue = 999999.0!
        Me.txtMaxPageFile.My_MinValue = 1.0!
        Me.txtMaxPageFile.My_ReplaceWithDefaultValue = True
        Me.txtMaxPageFile.Name = "txtMaxPageFile"
        Me.txtMaxPageFile.Size = New System.Drawing.Size(47, 20)
        Me.txtMaxPageFile.TabIndex = 18
        Me.txtMaxPageFile.Text = "1"
        Me.txtMaxPageFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rdoMultiFile
        '
        Me.rdoMultiFile.AutoSize = True
        Me.rdoMultiFile.Location = New System.Drawing.Point(179, 30)
        Me.rdoMultiFile.Name = "rdoMultiFile"
        Me.rdoMultiFile.Size = New System.Drawing.Size(276, 19)
        Me.rdoMultiFile.TabIndex = 1
        Me.rdoMultiFile.Text = "Genera più file contenenti il massimo pagine di "
        Me.rdoMultiFile.UseVisualStyleBackColor = True
        '
        'rdoSingFile
        '
        Me.rdoSingFile.AutoSize = True
        Me.rdoSingFile.Checked = True
        Me.rdoSingFile.Location = New System.Drawing.Point(13, 30)
        Me.rdoSingFile.Name = "rdoSingFile"
        Me.rdoSingFile.Size = New System.Drawing.Size(140, 19)
        Me.rdoSingFile.TabIndex = 0
        Me.rdoSingFile.TabStop = True
        Me.rdoSingFile.Text = "Genera un singolo file"
        Me.rdoSingFile.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCompletaZeri)
        Me.GroupBox2.Controls.Add(Me.chkInverso)
        Me.GroupBox2.Controls.Add(Me.lblOrient)
        Me.GroupBox2.Controls.Add(Me.chkRuota)
        Me.GroupBox2.Controls.Add(Me.cmbFont)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.txtGrandezzaFont)
        Me.GroupBox2.Controls.Add(Me.txtSuffisso)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtLarghezzaEtichetta)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtAltezzaEtichetta)
        Me.GroupBox2.Controls.Add(Me.txtPrefisso)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtBassoX)
        Me.GroupBox2.Controls.Add(Me.txtPassoY)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtBassoY)
        Me.GroupBox2.Controls.Add(Me.txtPassoX)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(53, 260)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(323, 325)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contatore"
        '
        'chkCompletaZeri
        '
        Me.chkCompletaZeri.AutoSize = True
        Me.chkCompletaZeri.Checked = True
        Me.chkCompletaZeri.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompletaZeri.Location = New System.Drawing.Point(194, 299)
        Me.chkCompletaZeri.Name = "chkCompletaZeri"
        Me.chkCompletaZeri.Size = New System.Drawing.Size(122, 19)
        Me.chkCompletaZeri.TabIndex = 60
        Me.chkCompletaZeri.Text = "Completa con zeri"
        Me.chkCompletaZeri.UseVisualStyleBackColor = True
        '
        'chkInverso
        '
        Me.chkInverso.AutoSize = True
        Me.chkInverso.Location = New System.Drawing.Point(14, 300)
        Me.chkInverso.Name = "chkInverso"
        Me.chkInverso.Size = New System.Drawing.Size(174, 19)
        Me.chkInverso.TabIndex = 58
        Me.chkInverso.Text = "Ordine numerazione inversa"
        Me.chkInverso.UseVisualStyleBackColor = True
        '
        'lblOrient
        '
        Me.lblOrient.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOrient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrient.Location = New System.Drawing.Point(285, 24)
        Me.lblOrient.Name = "lblOrient"
        Me.lblOrient.Size = New System.Drawing.Size(32, 19)
        Me.lblOrient.TabIndex = 57
        Me.lblOrient.Text = "90"
        Me.lblOrient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkRuota
        '
        Me.chkRuota.AutoSize = True
        Me.chkRuota.Location = New System.Drawing.Point(171, 25)
        Me.chkRuota.Name = "chkRuota"
        Me.chkRuota.Size = New System.Drawing.Size(104, 19)
        Me.chkRuota.TabIndex = 56
        Me.chkRuota.Text = "Ruota Verticale"
        Me.chkRuota.UseVisualStyleBackColor = True
        '
        'cmbFont
        '
        Me.cmbFont.FormattingEnabled = True
        Me.cmbFont.Location = New System.Drawing.Point(86, 50)
        Me.cmbFont.Name = "cmbFont"
        Me.cmbFont.Size = New System.Drawing.Size(137, 21)
        Me.cmbFont.TabIndex = 55
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(226, 53)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(61, 15)
        Me.Label34.TabIndex = 35
        Me.Label34.Text = "Grandezza"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(11, 276)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(48, 15)
        Me.Label36.TabIndex = 54
        Me.Label36.Text = "Suffisso"
        '
        'txtGrandezzaFont
        '
        Me.txtGrandezzaFont.Location = New System.Drawing.Point(297, 50)
        Me.txtGrandezzaFont.MaxLength = 2
        Me.txtGrandezzaFont.My_AccettaNegativi = False
        Me.txtGrandezzaFont.My_AllowOnlyInteger = True
        Me.txtGrandezzaFont.My_DefaultValue = 100
        Me.txtGrandezzaFont.My_MaxValue = 99.0!
        Me.txtGrandezzaFont.My_MinValue = 1.0!
        Me.txtGrandezzaFont.My_ReplaceWithDefaultValue = True
        Me.txtGrandezzaFont.Name = "txtGrandezzaFont"
        Me.txtGrandezzaFont.Size = New System.Drawing.Size(20, 20)
        Me.txtGrandezzaFont.TabIndex = 5
        Me.txtGrandezzaFont.Text = "12"
        Me.txtGrandezzaFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSuffisso
        '
        Me.txtSuffisso.BackColor = System.Drawing.Color.White
        Me.txtSuffisso.Location = New System.Drawing.Point(170, 273)
        Me.txtSuffisso.Name = "txtSuffisso"
        Me.txtSuffisso.Size = New System.Drawing.Size(47, 20)
        Me.txtSuffisso.TabIndex = 13
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(12, 53)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(67, 15)
        Me.Label33.TabIndex = 33
        Me.Label33.Text = "Nome Font"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 15)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Larghezza Etichetta"
        '
        'txtLarghezzaEtichetta
        '
        Me.txtLarghezzaEtichetta.Location = New System.Drawing.Point(171, 83)
        Me.txtLarghezzaEtichetta.My_AccettaNegativi = False
        Me.txtLarghezzaEtichetta.My_AllowOnlyInteger = False
        Me.txtLarghezzaEtichetta.My_DefaultValue = 100
        Me.txtLarghezzaEtichetta.My_MaxValue = 1.0E+10!
        Me.txtLarghezzaEtichetta.My_MinValue = 1.0!
        Me.txtLarghezzaEtichetta.My_ReplaceWithDefaultValue = True
        Me.txtLarghezzaEtichetta.Name = "txtLarghezzaEtichetta"
        Me.txtLarghezzaEtichetta.Size = New System.Drawing.Size(47, 20)
        Me.txtLarghezzaEtichetta.TabIndex = 6
        Me.txtLarghezzaEtichetta.Text = "34"
        Me.txtLarghezzaEtichetta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 249)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 15)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "Prefisso"
        '
        'txtAltezzaEtichetta
        '
        Me.txtAltezzaEtichetta.Location = New System.Drawing.Point(171, 110)
        Me.txtAltezzaEtichetta.My_AccettaNegativi = False
        Me.txtAltezzaEtichetta.My_AllowOnlyInteger = False
        Me.txtAltezzaEtichetta.My_DefaultValue = 100
        Me.txtAltezzaEtichetta.My_MaxValue = 1.0E+10!
        Me.txtAltezzaEtichetta.My_MinValue = 1.0!
        Me.txtAltezzaEtichetta.My_ReplaceWithDefaultValue = True
        Me.txtAltezzaEtichetta.Name = "txtAltezzaEtichetta"
        Me.txtAltezzaEtichetta.Size = New System.Drawing.Size(47, 20)
        Me.txtAltezzaEtichetta.TabIndex = 7
        Me.txtAltezzaEtichetta.Text = "9"
        Me.txtAltezzaEtichetta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrefisso
        '
        Me.txtPrefisso.Location = New System.Drawing.Point(171, 246)
        Me.txtPrefisso.Name = "txtPrefisso"
        Me.txtPrefisso.Size = New System.Drawing.Size(47, 20)
        Me.txtPrefisso.TabIndex = 12
        Me.txtPrefisso.Text = "N° "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 15)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Altezza Etichetta"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(224, 221)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 15)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "(mm)"
        Me.toolTipHelp.SetToolTip(Me.Label13, "Il passo va calcolato tra un etichetta e l'altra, non tra i biglietti")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(224, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 15)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "(mm)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(224, 194)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 15)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "(mm)"
        Me.toolTipHelp.SetToolTip(Me.Label14, "Il passo va calcolato tra un etichetta e l'altra, non tra i biglietti")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(224, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "(mm)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 221)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 15)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Passo Y tra Etichette"
        Me.toolTipHelp.SetToolTip(Me.Label15, "Il passo Y indica in pratica l'altezza del biglietto")
        '
        'txtBassoX
        '
        Me.txtBassoX.Location = New System.Drawing.Point(171, 137)
        Me.txtBassoX.My_AccettaNegativi = False
        Me.txtBassoX.My_AllowOnlyInteger = False
        Me.txtBassoX.My_DefaultValue = 100
        Me.txtBassoX.My_MaxValue = 1.0E+10!
        Me.txtBassoX.My_MinValue = 1.0!
        Me.txtBassoX.My_ReplaceWithDefaultValue = True
        Me.txtBassoX.Name = "txtBassoX"
        Me.txtBassoX.Size = New System.Drawing.Size(47, 20)
        Me.txtBassoX.TabIndex = 8
        Me.txtBassoX.Text = "30"
        Me.txtBassoX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPassoY
        '
        Me.txtPassoY.Location = New System.Drawing.Point(171, 218)
        Me.txtPassoY.My_AccettaNegativi = False
        Me.txtPassoY.My_AllowOnlyInteger = False
        Me.txtPassoY.My_DefaultValue = 100
        Me.txtPassoY.My_MaxValue = 1.0E+10!
        Me.txtPassoY.My_MinValue = 1.0!
        Me.txtPassoY.My_ReplaceWithDefaultValue = True
        Me.txtPassoY.Name = "txtPassoY"
        Me.txtPassoY.Size = New System.Drawing.Size(47, 20)
        Me.txtPassoY.TabIndex = 11
        Me.txtPassoY.Text = "65"
        Me.txtPassoY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.toolTipHelp.SetToolTip(Me.txtPassoY, "Il passo va calcolato tra un etichetta e l'altra, non tra i biglietti")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(12, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 15)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Primo Angolo Basso SX X"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 194)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 15)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Passo X tra Etichette"
        Me.toolTipHelp.SetToolTip(Me.Label16, "Il passo X indica in pratica la larghezza del biglietto")
        '
        'txtBassoY
        '
        Me.txtBassoY.Location = New System.Drawing.Point(171, 164)
        Me.txtBassoY.My_AccettaNegativi = False
        Me.txtBassoY.My_AllowOnlyInteger = False
        Me.txtBassoY.My_DefaultValue = 100
        Me.txtBassoY.My_MaxValue = 1.0E+10!
        Me.txtBassoY.My_MinValue = 1.0!
        Me.txtBassoY.My_ReplaceWithDefaultValue = True
        Me.txtBassoY.Name = "txtBassoY"
        Me.txtBassoY.Size = New System.Drawing.Size(47, 20)
        Me.txtBassoY.TabIndex = 9
        Me.txtBassoY.Text = "30"
        Me.txtBassoY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPassoX
        '
        Me.txtPassoX.Location = New System.Drawing.Point(171, 191)
        Me.txtPassoX.My_AccettaNegativi = False
        Me.txtPassoX.My_AllowOnlyInteger = False
        Me.txtPassoX.My_DefaultValue = 100
        Me.txtPassoX.My_MaxValue = 1.0E+10!
        Me.txtPassoX.My_MinValue = 1.0!
        Me.txtPassoX.My_ReplaceWithDefaultValue = True
        Me.txtPassoX.Name = "txtPassoX"
        Me.txtPassoX.Size = New System.Drawing.Size(47, 20)
        Me.txtPassoX.TabIndex = 10
        Me.txtPassoX.Text = "180"
        Me.txtPassoX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.toolTipHelp.SetToolTip(Me.txtPassoX, "Il passo va calcolato tra un etichetta e l'altra, non tra i biglietti")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(12, 167)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 15)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Primo Angolo Basso SX Y"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(224, 167)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 15)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "(mm) dal basso "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(224, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 15)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "(mm) dal basso "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCSV)
        Me.GroupBox1.Controls.Add(Me.btnCSV)
        Me.GroupBox1.Controls.Add(Me.chkCSVEtichette)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.Label57)
        Me.GroupBox1.Controls.Add(Me.lblY)
        Me.GroupBox1.Controls.Add(Me.lblX)
        Me.GroupBox1.Controls.Add(Me.chkPDFSfondo)
        Me.GroupBox1.Controls.Add(Me.txtSfondo)
        Me.GroupBox1.Controls.Add(Me.btnSfondo)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtNumColonne)
        Me.GroupBox1.Controls.Add(Me.txtNumRighe)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtLarghezza)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAltezza)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(981, 208)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Foglio e Disposizione"
        '
        'txtCSV
        '
        Me.txtCSV.Location = New System.Drawing.Point(450, 179)
        Me.txtCSV.MaxLength = 50
        Me.txtCSV.Name = "txtCSV"
        Me.txtCSV.ReadOnly = True
        Me.txtCSV.Size = New System.Drawing.Size(336, 20)
        Me.txtCSV.TabIndex = 174
        '
        'btnCSV
        '
        Me.btnCSV.Location = New System.Drawing.Point(792, 177)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(26, 22)
        Me.btnCSV.TabIndex = 175
        Me.btnCSV.Text = "..."
        Me.btnCSV.UseVisualStyleBackColor = True
        '
        'chkCSVEtichette
        '
        Me.chkCSVEtichette.AutoSize = True
        Me.chkCSVEtichette.Location = New System.Drawing.Point(328, 181)
        Me.chkCSVEtichette.Name = "chkCSVEtichette"
        Me.chkCSVEtichette.Size = New System.Drawing.Size(96, 19)
        Me.chkCSVEtichette.TabIndex = 173
        Me.chkCSVEtichette.Text = "CSV Etichette"
        Me.chkCSVEtichette.UseVisualStyleBackColor = True
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Red
        Me.Label58.Location = New System.Drawing.Point(231, 26)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(16, 130)
        Me.Label58.TabIndex = 172
        Me.Label58.Text = "C" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "O" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "L" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "O" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "N" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "N" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "E" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "˅" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "˅"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.Red
        Me.Label57.Location = New System.Drawing.Point(79, 141)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(58, 13)
        Me.Label57.TabIndex = 171
        Me.Label57.Text = "RIGHE >>"
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblY.ForeColor = System.Drawing.Color.Red
        Me.lblY.Location = New System.Drawing.Point(75, 187)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(14, 15)
        Me.lblY.TabIndex = 170
        Me.lblY.Text = "Y"
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX.ForeColor = System.Drawing.Color.Red
        Me.lblX.Location = New System.Drawing.Point(12, 148)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(15, 15)
        Me.lblX.TabIndex = 169
        Me.lblX.Text = "X"
        '
        'chkPDFSfondo
        '
        Me.chkPDFSfondo.AutoSize = True
        Me.chkPDFSfondo.Location = New System.Drawing.Point(328, 156)
        Me.chkPDFSfondo.Name = "chkPDFSfondo"
        Me.chkPDFSfondo.Size = New System.Drawing.Size(88, 19)
        Me.chkPDFSfondo.TabIndex = 168
        Me.chkPDFSfondo.Text = "PDF Sfondo"
        Me.chkPDFSfondo.UseVisualStyleBackColor = True
        '
        'txtSfondo
        '
        Me.txtSfondo.Location = New System.Drawing.Point(450, 154)
        Me.txtSfondo.MaxLength = 50
        Me.txtSfondo.Name = "txtSfondo"
        Me.txtSfondo.ReadOnly = True
        Me.txtSfondo.Size = New System.Drawing.Size(336, 20)
        Me.txtSfondo.TabIndex = 166
        '
        'btnSfondo
        '
        Me.btnSfondo.Location = New System.Drawing.Point(792, 153)
        Me.btnSfondo.Name = "btnSfondo"
        Me.btnSfondo.Size = New System.Drawing.Size(26, 22)
        Me.btnSfondo.TabIndex = 167
        Me.btnSfondo.Text = "..."
        Me.btnSfondo.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(541, 96)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(257, 15)
        Me.Label37.TabIndex = 55
        Me.Label37.Text = "(verticale senza conteggiare eventuali duplicati)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(541, 128)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(270, 15)
        Me.Label38.TabIndex = 56
        Me.Label38.Text = "(orizzontale senza conteggiare eventuali duplicati)"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources.biglietti
        Me.PictureBox2.Location = New System.Drawing.Point(15, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(255, 182)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(326, 128)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 15)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "N° Righe"
        '
        'txtNumColonne
        '
        Me.txtNumColonne.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumColonne.Location = New System.Drawing.Point(451, 90)
        Me.txtNumColonne.MaxLength = 2
        Me.txtNumColonne.My_AccettaNegativi = False
        Me.txtNumColonne.My_AllowOnlyInteger = True
        Me.txtNumColonne.My_DefaultValue = 1
        Me.txtNumColonne.My_MaxValue = 99.0!
        Me.txtNumColonne.My_MinValue = 1.0!
        Me.txtNumColonne.My_ReplaceWithDefaultValue = True
        Me.txtNumColonne.Name = "txtNumColonne"
        Me.txtNumColonne.Size = New System.Drawing.Size(82, 29)
        Me.txtNumColonne.TabIndex = 2
        Me.txtNumColonne.Text = "2"
        Me.txtNumColonne.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumRighe
        '
        Me.txtNumRighe.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRighe.Location = New System.Drawing.Point(451, 122)
        Me.txtNumRighe.MaxLength = 2
        Me.txtNumRighe.My_AccettaNegativi = False
        Me.txtNumRighe.My_AllowOnlyInteger = True
        Me.txtNumRighe.My_DefaultValue = 1
        Me.txtNumRighe.My_MaxValue = 99.0!
        Me.txtNumRighe.My_MinValue = 1.0!
        Me.txtNumRighe.My_ReplaceWithDefaultValue = True
        Me.txtNumRighe.Name = "txtNumRighe"
        Me.txtNumRighe.Size = New System.Drawing.Size(82, 29)
        Me.txtNumRighe.TabIndex = 3
        Me.txtNumRighe.Text = "4"
        Me.txtNumRighe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(326, 93)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 15)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "N° Colonne"
        '
        'txtLarghezza
        '
        Me.txtLarghezza.Location = New System.Drawing.Point(451, 23)
        Me.txtLarghezza.My_AccettaNegativi = False
        Me.txtLarghezza.My_AllowOnlyInteger = True
        Me.txtLarghezza.My_DefaultValue = 100
        Me.txtLarghezza.My_MaxValue = 1.0E+10!
        Me.txtLarghezza.My_MinValue = 1.0!
        Me.txtLarghezza.My_ReplaceWithDefaultValue = True
        Me.txtLarghezza.Name = "txtLarghezza"
        Me.txtLarghezza.Size = New System.Drawing.Size(82, 20)
        Me.txtLarghezza.TabIndex = 0
        Me.txtLarghezza.Text = "440"
        Me.txtLarghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(326, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Larghezza Foglio"
        '
        'txtAltezza
        '
        Me.txtAltezza.Location = New System.Drawing.Point(451, 50)
        Me.txtAltezza.My_AccettaNegativi = False
        Me.txtAltezza.My_AllowOnlyInteger = True
        Me.txtAltezza.My_DefaultValue = 100
        Me.txtAltezza.My_MaxValue = 1.0E+10!
        Me.txtAltezza.My_MinValue = 1.0!
        Me.txtAltezza.My_ReplaceWithDefaultValue = True
        Me.txtAltezza.Name = "txtAltezza"
        Me.txtAltezza.Size = New System.Drawing.Size(82, 20)
        Me.txtAltezza.TabIndex = 1
        Me.txtAltezza.Text = "320"
        Me.txtAltezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(326, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Altezza Foglio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(541, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "(mm)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(541, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "(mm)"
        '
        'btnGeneraPDF
        '
        Me.btnGeneraPDF.Image = Global.Former.My.Resources.Resources._pdf
        Me.btnGeneraPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGeneraPDF.Location = New System.Drawing.Point(458, 668)
        Me.btnGeneraPDF.Name = "btnGeneraPDF"
        Me.btnGeneraPDF.Size = New System.Drawing.Size(170, 49)
        Me.btnGeneraPDF.TabIndex = 23
        Me.btnGeneraPDF.Text = "Genera PDF"
        Me.toolTipHelp.SetToolTip(Me.btnGeneraPDF, "Propone una soluzione in base ai parametri inseriti sopra")
        Me.btnGeneraPDF.UseVisualStyleBackColor = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._pdf
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
        Me.lblTipo.Size = New System.Drawing.Size(197, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Parametri creazione PDF"
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.FileName = "parametri.txt"
        Me.dlgOpenFile.Filter = "File di testo|*.txt"
        '
        'dlgSaveFile
        '
        Me.dlgSaveFile.FileName = "parametri.txt"
        Me.dlgSaveFile.Filter = "File di testo|*.txt"
        '
        'dlgOpenSfondo
        '
        Me.dlgOpenSfondo.Filter = "File PDF|*.pdf"
        '
        'chkOnlyFront
        '
        Me.chkOnlyFront.AutoSize = True
        Me.chkOnlyFront.Location = New System.Drawing.Point(513, 31)
        Me.chkOnlyFront.Name = "chkOnlyFront"
        Me.chkOnlyFront.Size = New System.Drawing.Size(102, 19)
        Me.chkOnlyFront.TabIndex = 182
        Me.chkOnlyFront.Text = "Solo sul fronte"
        Me.chkOnlyFront.UseVisualStyleBackColor = True
        '
        'frmCalcNumerazionePDFEx
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1091, 799)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmCalcNumerazionePDFEx"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Parametri Creazione PDF"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.dgDuplicati.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDuplicati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAltezza As ucNumericTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLarghezza As ucNumericTextBox
    Friend WithEvents btnGeneraPDF As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAltezzaEtichetta As ucNumericTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtLarghezzaEtichetta As ucNumericTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtBassoY As ucNumericTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtBassoX As ucNumericTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtPassoY As ucNumericTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPassoX As ucNumericTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtPrefisso As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtNumRighe As ucNumericTextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtNumColonne As ucNumericTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtGrandezzaFont As ucNumericTextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents txtSuffisso As TextBox
    Friend WithEvents btnSalva As Button
    Friend WithEvents btnApri As Button
    Friend WithEvents dlgOpenFile As OpenFileDialog
    Friend WithEvents dlgSaveFile As SaveFileDialog
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents cmbFont As ComboBox
    Friend WithEvents txtSfondo As TextBox
    Friend WithEvents btnSfondo As Button
    Friend WithEvents dlgOpenSfondo As OpenFileDialog
    Friend WithEvents chkPDFSfondo As CheckBox
    Friend WithEvents chkRuota As CheckBox
    Friend WithEvents lblOrient As Label
    Friend WithEvents chkInverso As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtMaxPageFile As ucNumericTextBox
    Friend WithEvents rdoMultiFile As RadioButton
    Friend WithEvents rdoSingFile As RadioButton
    Friend WithEvents lblY As Label
    Friend WithEvents lblX As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents txtCSV As TextBox
    Friend WithEvents btnCSV As Button
    Friend WithEvents chkCSVEtichette As CheckBox
    Friend WithEvents Label61 As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents txtNumPagX As ucNumericTextBox
    Friend WithEvents txtNumPagY As ucNumericTextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents chkNumPagina As CheckBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents lnkRimuoviDupl As Button
    Friend WithEvents lnkAddDupl As Button
    Friend WithEvents dgDuplicati As Telerik.WinControls.UI.RadGridView
    Friend WithEvents chkCompletaZeri As CheckBox
    Friend WithEvents chkOnlyFront As CheckBox
End Class
