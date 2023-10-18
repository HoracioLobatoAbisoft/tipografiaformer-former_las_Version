<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdineModificaImporti
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
        Me.chkMantieniCampione = New System.Windows.Forms.CheckBox()
        Me.txtNomeLavoro = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkUsaNomeLavoro = New System.Windows.Forms.CheckBox()
        Me.lnkReset = New System.Windows.Forms.LinkLabel()
        Me.txtTotDaRicavare = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbStato = New System.Windows.Forms.ComboBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumOrd = New System.Windows.Forms.TextBox()
        Me.chkPreventivo = New System.Windows.Forms.CheckBox()
        Me.lblTotImp = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtRicarico = New Former.ucNumericTextBox()
        Me.lblCostoVenduto = New System.Windows.Forms.Label()
        Me.txtSconto = New Former.ucNumericTextBox()
        Me.lblTotForn = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbCorriere = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblAnteprima = New System.Windows.Forms.Label()
        Me.pctPreview = New System.Windows.Forms.PictureBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctPreview, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 551)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(818, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(739, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 30)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(663, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(70, 30)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(818, 551)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.chkMantieniCampione)
        Me.tbProd.Controls.Add(Me.txtNomeLavoro)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.chkUsaNomeLavoro)
        Me.tbProd.Controls.Add(Me.lnkReset)
        Me.tbProd.Controls.Add(Me.txtTotDaRicavare)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.cmbStato)
        Me.tbProd.Controls.Add(Me.txtNote)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtNumOrd)
        Me.tbProd.Controls.Add(Me.chkPreventivo)
        Me.tbProd.Controls.Add(Me.lblTotImp)
        Me.tbProd.Controls.Add(Me.Label22)
        Me.tbProd.Controls.Add(Me.Label19)
        Me.tbProd.Controls.Add(Me.txtRicarico)
        Me.tbProd.Controls.Add(Me.lblCostoVenduto)
        Me.tbProd.Controls.Add(Me.txtSconto)
        Me.tbProd.Controls.Add(Me.lblTotForn)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.lblIva)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.cmbCorriere)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.lblAnteprima)
        Me.tbProd.Controls.Add(Me.pctPreview)
        Me.tbProd.Controls.Add(Me.Label35)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(810, 525)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Modifica Importi"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'chkMantieniCampione
        '
        Me.chkMantieniCampione.AutoSize = True
        Me.chkMantieniCampione.Location = New System.Drawing.Point(187, 353)
        Me.chkMantieniCampione.Name = "chkMantieniCampione"
        Me.chkMantieniCampione.Size = New System.Drawing.Size(235, 19)
        Me.chkMantieniCampione.TabIndex = 130
        Me.chkMantieniCampione.Text = "Mantieni un campione di questo ordine"
        Me.toolTipHelp.SetToolTip(Me.chkMantieniCampione, "Questa opzione deve essere impostata prima che l'ordine arrivi in stato IMBALLAGG" &
        "IO")
        Me.chkMantieniCampione.UseVisualStyleBackColor = True
        '
        'txtNomeLavoro
        '
        Me.txtNomeLavoro.Location = New System.Drawing.Point(187, 317)
        Me.txtNomeLavoro.MaxLength = 100
        Me.txtNomeLavoro.Name = "txtNomeLavoro"
        Me.txtNomeLavoro.Size = New System.Drawing.Size(191, 20)
        Me.txtNomeLavoro.TabIndex = 129
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(50, 320)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 15)
        Me.Label10.TabIndex = 128
        Me.Label10.Text = "Nome Lavoro"
        '
        'chkUsaNomeLavoro
        '
        Me.chkUsaNomeLavoro.AutoSize = True
        Me.chkUsaNomeLavoro.Location = New System.Drawing.Point(386, 319)
        Me.chkUsaNomeLavoro.Name = "chkUsaNomeLavoro"
        Me.chkUsaNomeLavoro.Size = New System.Drawing.Size(219, 19)
        Me.chkUsaNomeLavoro.TabIndex = 127
        Me.chkUsaNomeLavoro.Text = "Usa Nome Lavoro per Riga in Fattura"
        Me.chkUsaNomeLavoro.UseVisualStyleBackColor = True
        '
        'lnkReset
        '
        Me.lnkReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkReset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkReset.Image = Global.Former.My.Resources.Resources._Reset
        Me.lnkReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkReset.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkReset.Location = New System.Drawing.Point(564, 170)
        Me.lnkReset.Name = "lnkReset"
        Me.lnkReset.Size = New System.Drawing.Size(71, 27)
        Me.lnkReset.TabIndex = 126
        Me.lnkReset.TabStop = True
        Me.lnkReset.Text = "Reset"
        Me.lnkReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotDaRicavare
        '
        Me.txtTotDaRicavare.My_AccettaNegativi = False
        Me.txtTotDaRicavare.My_DefaultValue = 0
        Me.txtTotDaRicavare.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotDaRicavare.ForeColor = System.Drawing.Color.Black
        Me.txtTotDaRicavare.Location = New System.Drawing.Point(498, 173)
        Me.txtTotDaRicavare.MaxLength = 20
        Me.txtTotDaRicavare.My_MaxValue = 1.0E+10!
        Me.txtTotDaRicavare.My_MinValue = 0!
        Me.txtTotDaRicavare.Name = "txtTotDaRicavare"
        Me.txtTotDaRicavare.My_AllowOnlyInteger = False
        Me.txtTotDaRicavare.My_ReplaceWithDefaultValue = True
        Me.txtTotDaRicavare.Size = New System.Drawing.Size(60, 23)
        Me.txtTotDaRicavare.TabIndex = 125
        Me.txtTotDaRicavare.Text = "0"
        Me.txtTotDaRicavare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(383, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 15)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Totale da Ricavare"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Stato Ordine"
        '
        'cmbStato
        '
        Me.cmbStato.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbStato.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStato.BackColor = System.Drawing.Color.White
        Me.cmbStato.Enabled = False
        Me.cmbStato.ForeColor = System.Drawing.Color.Black
        Me.cmbStato.FormattingEnabled = True
        Me.cmbStato.Location = New System.Drawing.Point(187, 116)
        Me.cmbStato.Name = "cmbStato"
        Me.cmbStato.Size = New System.Drawing.Size(189, 21)
        Me.cmbStato.TabIndex = 122
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(187, 378)
        Me.txtNote.MaxLength = 255
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(606, 127)
        Me.txtNote.TabIndex = 121
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 381)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Note"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 18)
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "Ordine Numero"
        '
        'txtNumOrd
        '
        Me.txtNumOrd.BackColor = System.Drawing.Color.White
        Me.txtNumOrd.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumOrd.Location = New System.Drawing.Point(187, 86)
        Me.txtNumOrd.Name = "txtNumOrd"
        Me.txtNumOrd.ReadOnly = True
        Me.txtNumOrd.Size = New System.Drawing.Size(190, 27)
        Me.txtNumOrd.TabIndex = 119
        Me.txtNumOrd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkPreventivo
        '
        Me.chkPreventivo.AutoSize = True
        Me.chkPreventivo.Location = New System.Drawing.Point(53, 144)
        Me.chkPreventivo.Name = "chkPreventivo"
        Me.chkPreventivo.Size = New System.Drawing.Size(82, 19)
        Me.chkPreventivo.TabIndex = 0
        Me.chkPreventivo.Text = "Preventivo"
        Me.chkPreventivo.UseVisualStyleBackColor = True
        '
        'lblTotImp
        '
        Me.lblTotImp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotImp.ForeColor = System.Drawing.Color.Black
        Me.lblTotImp.Location = New System.Drawing.Point(188, 255)
        Me.lblTotImp.Name = "lblTotImp"
        Me.lblTotImp.Size = New System.Drawing.Size(189, 15)
        Me.lblTotImp.TabIndex = 116
        Me.lblTotImp.Text = "0"
        Me.lblTotImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(50, 255)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 15)
        Me.Label22.TabIndex = 115
        Me.Label22.Text = "Totale Imponibile"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(50, 224)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 15)
        Me.Label19.TabIndex = 114
        Me.Label19.Text = "Ricarico"
        '
        'txtRicarico
        '
        Me.txtRicarico.My_AccettaNegativi = False
        Me.txtRicarico.My_DefaultValue = 0
        Me.txtRicarico.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRicarico.ForeColor = System.Drawing.Color.Black
        Me.txtRicarico.Location = New System.Drawing.Point(187, 221)
        Me.txtRicarico.MaxLength = 20
        Me.txtRicarico.My_MaxValue = 1.0E+10!
        Me.txtRicarico.My_MinValue = -1.0E+9!
        Me.txtRicarico.Name = "txtRicarico"
        Me.txtRicarico.My_AllowOnlyInteger = False
        Me.txtRicarico.My_ReplaceWithDefaultValue = True
        Me.txtRicarico.Size = New System.Drawing.Size(189, 23)
        Me.txtRicarico.TabIndex = 2
        Me.txtRicarico.Text = "0"
        Me.txtRicarico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCostoVenduto
        '
        Me.lblCostoVenduto.AutoSize = True
        Me.lblCostoVenduto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblCostoVenduto.ForeColor = System.Drawing.Color.Black
        Me.lblCostoVenduto.Location = New System.Drawing.Point(50, 197)
        Me.lblCostoVenduto.Name = "lblCostoVenduto"
        Me.lblCostoVenduto.Size = New System.Drawing.Size(41, 15)
        Me.lblCostoVenduto.TabIndex = 107
        Me.lblCostoVenduto.Text = "Sconto"
        '
        'txtSconto
        '
        Me.txtSconto.My_AccettaNegativi = False
        Me.txtSconto.My_DefaultValue = 0
        Me.txtSconto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSconto.ForeColor = System.Drawing.Color.Black
        Me.txtSconto.Location = New System.Drawing.Point(187, 194)
        Me.txtSconto.MaxLength = 20
        Me.txtSconto.My_MaxValue = 1.0E+10!
        Me.txtSconto.My_MinValue = -1.0E+9!
        Me.txtSconto.Name = "txtSconto"
        Me.txtSconto.My_AllowOnlyInteger = False
        Me.txtSconto.My_ReplaceWithDefaultValue = True
        Me.txtSconto.Size = New System.Drawing.Size(189, 23)
        Me.txtSconto.TabIndex = 1
        Me.txtSconto.Text = "0"
        Me.txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotForn
        '
        Me.lblTotForn.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotForn.ForeColor = System.Drawing.Color.Black
        Me.lblTotForn.Location = New System.Drawing.Point(188, 176)
        Me.lblTotForn.Name = "lblTotForn"
        Me.lblTotForn.Size = New System.Drawing.Size(189, 15)
        Me.lblTotForn.TabIndex = 112
        Me.lblTotForn.Text = "0"
        Me.lblTotForn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(50, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 15)
        Me.Label13.TabIndex = 111
        Me.Label13.Text = "Totale Fornitura"
        '
        'lblIva
        '
        Me.lblIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIva.ForeColor = System.Drawing.Color.Black
        Me.lblIva.Location = New System.Drawing.Point(188, 270)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(189, 15)
        Me.lblIva.TabIndex = 110
        Me.lblIva.Text = "0"
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(50, 270)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 15)
        Me.Label11.TabIndex = 109
        Me.Label11.Text = "IVA"
        '
        'cmbCorriere
        '
        Me.cmbCorriere.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCorriere.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCorriere.BackColor = System.Drawing.Color.White
        Me.cmbCorriere.Enabled = False
        Me.cmbCorriere.ForeColor = System.Drawing.Color.Black
        Me.cmbCorriere.FormattingEnabled = True
        Me.cmbCorriere.Location = New System.Drawing.Point(187, 288)
        Me.cmbCorriere.Name = "cmbCorriere"
        Me.cmbCorriere.Size = New System.Drawing.Size(191, 21)
        Me.cmbCorriere.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(50, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 15)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "Corriere"
        '
        'lblAnteprima
        '
        Me.lblAnteprima.AutoSize = True
        Me.lblAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAnteprima.ForeColor = System.Drawing.Color.Black
        Me.lblAnteprima.Location = New System.Drawing.Point(683, 67)
        Me.lblAnteprima.Name = "lblAnteprima"
        Me.lblAnteprima.Size = New System.Drawing.Size(66, 15)
        Me.lblAnteprima.TabIndex = 99
        Me.lblAnteprima.Text = "Anteprima"
        '
        'pctPreview
        '
        Me.pctPreview.Location = New System.Drawing.Point(641, 85)
        Me.pctPreview.Name = "pctPreview"
        Me.pctPreview.Size = New System.Drawing.Size(153, 198)
        Me.pctPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctPreview.TabIndex = 98
        Me.pctPreview.TabStop = False
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(50, 37)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(509, 36)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Da questa maschera è possibile modificare i dettagli economici dell'ordine"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Prezzo
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
        Me.lblTipo.Size = New System.Drawing.Size(139, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Modifica Importi"
        '
        'frmOrdineModificaImporti
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(818, 599)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmOrdineModificaImporti"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Modifica Importi"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblAnteprima As System.Windows.Forms.Label
    Friend WithEvents pctPreview As System.Windows.Forms.PictureBox
    Friend WithEvents lblTotImp As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtRicarico As ucNumericTextBox
    Friend WithEvents lblCostoVenduto As System.Windows.Forms.Label
    Friend WithEvents txtSconto As ucNumericTextBox
    Friend WithEvents lblTotForn As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbCorriere As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkPreventivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumOrd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbStato As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotDaRicavare As ucNumericTextBox
    Friend WithEvents lnkReset As System.Windows.Forms.LinkLabel
    Friend WithEvents chkUsaNomeLavoro As System.Windows.Forms.CheckBox
    Friend WithEvents txtNomeLavoro As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkMantieniCampione As CheckBox
End Class
