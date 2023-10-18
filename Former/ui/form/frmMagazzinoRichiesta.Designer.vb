<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMagazzinoRichiesta
    Inherits baseFormInternaRedim

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
        Me.components = New System.ComponentModel.Container()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grpRisorsa = New System.Windows.Forms.GroupBox()
        Me.lnkRichiestaEsistente = New Former.ucLinkLabel()
        Me.chkUrgente = New System.Windows.Forms.CheckBox()
        Me.lblCostoTotale = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.lblGiacFinale = New System.Windows.Forms.Label()
        Me.txtGiacReale = New Former.ucNumericTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pctRis = New Former.ucPictureWithZoom()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblGiacPresunta = New System.Windows.Forms.Label()
        Me.txtQta = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRisSel = New System.Windows.Forms.Label()
        Me.UcMagazzinoCercaRisorsa = New Former.ucMagazzinoCercaRisorsa()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpMovimentiRecenti = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoMgrMovimenti = New Former.ucMagazzinoMgrMovimenti()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRisorsa.SuspendLayout()
        CType(Me.pctRis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMovimentiRecenti.SuspendLayout()
        Me.gbPulsanti.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpMovimentiRecenti)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(963, 756)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.grpRisorsa)
        Me.tbProd.Controls.Add(Me.UcMagazzinoCercaRisorsa)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(955, 730)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Richiesta acquisto risorsa"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources.flash_auto96
        Me.PictureBox1.Location = New System.Drawing.Point(857, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(90, 90)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'grpRisorsa
        '
        Me.grpRisorsa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpRisorsa.Controls.Add(Me.lnkRichiestaEsistente)
        Me.grpRisorsa.Controls.Add(Me.chkUrgente)
        Me.grpRisorsa.Controls.Add(Me.lblCostoTotale)
        Me.grpRisorsa.Controls.Add(Me.txtNote)
        Me.grpRisorsa.Controls.Add(Me.lblGiacFinale)
        Me.grpRisorsa.Controls.Add(Me.txtGiacReale)
        Me.grpRisorsa.Controls.Add(Me.Label5)
        Me.grpRisorsa.Controls.Add(Me.Label3)
        Me.grpRisorsa.Controls.Add(Me.pctRis)
        Me.grpRisorsa.Controls.Add(Me.Label4)
        Me.grpRisorsa.Controls.Add(Me.lblGiacPresunta)
        Me.grpRisorsa.Controls.Add(Me.txtQta)
        Me.grpRisorsa.Controls.Add(Me.Label2)
        Me.grpRisorsa.Controls.Add(Me.lblRisSel)
        Me.grpRisorsa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grpRisorsa.Location = New System.Drawing.Point(106, 520)
        Me.grpRisorsa.Name = "grpRisorsa"
        Me.grpRisorsa.Size = New System.Drawing.Size(846, 204)
        Me.grpRisorsa.TabIndex = 110
        Me.grpRisorsa.TabStop = False
        Me.grpRisorsa.Text = "Risorsa selezionata"
        '
        'lnkRichiestaEsistente
        '
        Me.lnkRichiestaEsistente.BackColor = System.Drawing.Color.White
        Me.lnkRichiestaEsistente.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkRichiestaEsistente.ForeColor = System.Drawing.Color.Red
        Me.lnkRichiestaEsistente.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.lnkRichiestaEsistente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRichiestaEsistente.LinkColor = System.Drawing.Color.Red
        Me.lnkRichiestaEsistente.Location = New System.Drawing.Point(123, -4)
        Me.lnkRichiestaEsistente.Name = "lnkRichiestaEsistente"
        Me.lnkRichiestaEsistente.RoundedBorder = False
        Me.lnkRichiestaEsistente.Size = New System.Drawing.Size(523, 26)
        Me.lnkRichiestaEsistente.TabIndex = 116
        Me.lnkRichiestaEsistente.TabStop = True
        Me.lnkRichiestaEsistente.Text = "ATTENZIONE! Per la risorsa selezionata c'è già una richiesta pendente"
        Me.lnkRichiestaEsistente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkRichiestaEsistente.Visible = False
        '
        'chkUrgente
        '
        Me.chkUrgente.AutoSize = True
        Me.chkUrgente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUrgente.Location = New System.Drawing.Point(9, 109)
        Me.chkUrgente.Name = "chkUrgente"
        Me.chkUrgente.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkUrgente.Size = New System.Drawing.Size(133, 19)
        Me.chkUrgente.TabIndex = 123
        Me.chkUrgente.Text = "Richiesta URGENTE"
        Me.chkUrgente.UseVisualStyleBackColor = True
        '
        'lblCostoTotale
        '
        Me.lblCostoTotale.AutoSize = True
        Me.lblCostoTotale.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblCostoTotale.ForeColor = System.Drawing.Color.Black
        Me.lblCostoTotale.Location = New System.Drawing.Point(11, 137)
        Me.lblCostoTotale.Name = "lblCostoTotale"
        Me.lblCostoTotale.Size = New System.Drawing.Size(33, 15)
        Me.lblCostoTotale.TabIndex = 122
        Me.lblCostoTotale.Text = "Note"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(80, 134)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(532, 61)
        Me.txtNote.TabIndex = 121
        '
        'lblGiacFinale
        '
        Me.lblGiacFinale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGiacFinale.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGiacFinale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.lblGiacFinale.Location = New System.Drawing.Point(770, 130)
        Me.lblGiacFinale.Name = "lblGiacFinale"
        Me.lblGiacFinale.Size = New System.Drawing.Size(71, 27)
        Me.lblGiacFinale.TabIndex = 120
        Me.lblGiacFinale.Text = "0"
        Me.lblGiacFinale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGiacReale
        '
        Me.txtGiacReale.My_AccettaNegativi = False
        Me.txtGiacReale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGiacReale.My_DefaultValue = 0
        Me.txtGiacReale.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiacReale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.txtGiacReale.Location = New System.Drawing.Point(769, 54)
        Me.txtGiacReale.MaxLength = 6
        Me.txtGiacReale.My_MaxValue = 999999.0!
        Me.txtGiacReale.My_MinValue = 0!
        Me.txtGiacReale.Name = "txtGiacReale"
        Me.txtGiacReale.My_AllowOnlyInteger = False
        Me.txtGiacReale.My_ReplaceWithDefaultValue = False
        Me.txtGiacReale.Size = New System.Drawing.Size(71, 27)
        Me.txtGiacReale.TabIndex = 1
        Me.txtGiacReale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(632, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 19)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "Giacenza Reale"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(632, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 19)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Giacenza Presunta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pctRis
        '
        Me.pctRis.BackColor = System.Drawing.Color.White
        Me.pctRis.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctRis.Label = Nothing
        Me.pctRis.Location = New System.Drawing.Point(6, 17)
        Me.pctRis.Name = "pctRis"
        Me.pctRis.Size = New System.Drawing.Size(64, 64)
        Me.pctRis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctRis.TabIndex = 115
        Me.pctRis.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(632, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 19)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Giac. dopo Ordine"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGiacPresunta
        '
        Me.lblGiacPresunta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGiacPresunta.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGiacPresunta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblGiacPresunta.Location = New System.Drawing.Point(769, 18)
        Me.lblGiacPresunta.Name = "lblGiacPresunta"
        Me.lblGiacPresunta.Size = New System.Drawing.Size(71, 27)
        Me.lblGiacPresunta.TabIndex = 25
        Me.lblGiacPresunta.Text = "0"
        Me.lblGiacPresunta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQta
        '
        Me.txtQta.My_AccettaNegativi = False
        Me.txtQta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQta.My_DefaultValue = 1
        Me.txtQta.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtQta.Location = New System.Drawing.Point(769, 92)
        Me.txtQta.MaxLength = 6
        Me.txtQta.My_MaxValue = 999999.0!
        Me.txtQta.My_MinValue = 1.0!
        Me.txtQta.Name = "txtQta"
        Me.txtQta.My_AllowOnlyInteger = False
        Me.txtQta.My_ReplaceWithDefaultValue = False
        Me.txtQta.Size = New System.Drawing.Size(71, 27)
        Me.txtQta.TabIndex = 2
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(632, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 19)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Qtà da ordinare"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRisSel
        '
        Me.lblRisSel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRisSel.AutoEllipsis = True
        Me.lblRisSel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblRisSel.ForeColor = System.Drawing.Color.Black
        Me.lblRisSel.Location = New System.Drawing.Point(76, 17)
        Me.lblRisSel.Name = "lblRisSel"
        Me.lblRisSel.Size = New System.Drawing.Size(536, 64)
        Me.lblRisSel.TabIndex = 19
        Me.lblRisSel.Text = "-"
        '
        'UcMagazzinoCercaRisorsa
        '
        Me.UcMagazzinoCercaRisorsa._TipoMovRiferimento = FormerLib.FormerEnum.enTipoMovMagaz.Inserimento
        Me.UcMagazzinoCercaRisorsa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcMagazzinoCercaRisorsa.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoCercaRisorsa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoCercaRisorsa.Location = New System.Drawing.Point(3, 44)
        Me.UcMagazzinoCercaRisorsa.Name = "UcMagazzinoCercaRisorsa"
        Me.UcMagazzinoCercaRisorsa.Size = New System.Drawing.Size(949, 470)
        Me.UcMagazzinoCercaRisorsa.SoloAttivi = False
        Me.UcMagazzinoCercaRisorsa.TabIndex = 0
        Me.UcMagazzinoCercaRisorsa.TipoRisorsaToShow = FormerLib.FormerEnum.enTipoRisOffSet.Tutto
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(940, 34)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Richiesta Acquisto Risorsa"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpMovimentiRecenti
        '
        Me.tpMovimentiRecenti.Controls.Add(Me.UcMagazzinoMgrMovimenti)
        Me.tpMovimentiRecenti.Location = New System.Drawing.Point(4, 22)
        Me.tpMovimentiRecenti.Name = "tpMovimentiRecenti"
        Me.tpMovimentiRecenti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMovimentiRecenti.Size = New System.Drawing.Size(955, 730)
        Me.tpMovimentiRecenti.TabIndex = 1
        Me.tpMovimentiRecenti.Text = "Richieste attualmente in coda"
        Me.tpMovimentiRecenti.UseVisualStyleBackColor = True
        '
        'UcMagazzinoMgrMovimenti
        '
        Me.UcMagazzinoMgrMovimenti.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoMgrMovimenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoMgrMovimenti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoMgrMovimenti.IdRis = 0
        Me.UcMagazzinoMgrMovimenti.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoMgrMovimenti.Name = "UcMagazzinoMgrMovimenti"
        Me.UcMagazzinoMgrMovimenti.OnlyMaterialeDiConsumo = False
        Me.UcMagazzinoMgrMovimenti.OnlyRichiesteAcquistoInCoda = False
        Me.UcMagazzinoMgrMovimenti.Size = New System.Drawing.Size(949, 724)
        Me.UcMagazzinoMgrMovimenti.TabIndex = 1
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 756)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(963, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(879, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 4
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
        Me.btnOk.Location = New System.Drawing.Point(797, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(76, 32)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmMagazzinoRichiesta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(963, 804)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMagazzinoRichiesta"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Richiesta acquisto risorsa"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRisorsa.ResumeLayout(False)
        Me.grpRisorsa.PerformLayout()
        CType(Me.pctRis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMovimentiRecenti.ResumeLayout(False)
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents grpRisorsa As GroupBox
    Friend WithEvents lblRisSel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtQta As ucNumericTextBox
    Friend WithEvents lblGiacPresunta As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pctRis As ucPictureWithZoom
    Friend WithEvents tpMovimentiRecenti As TabPage
    Friend WithEvents UcMagazzinoCercaRisorsa As ucMagazzinoCercaRisorsa
    Friend WithEvents UcMagazzinoMgrMovimenti As ucMagazzinoMgrMovimenti
    Friend WithEvents lnkRichiestaEsistente As ucLinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblGiacFinale As Label
    Friend WithEvents txtGiacReale As ucNumericTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNote As TextBox
    Friend WithEvents chkUrgente As CheckBox
    Friend WithEvents lblCostoTotale As Label
End Class
