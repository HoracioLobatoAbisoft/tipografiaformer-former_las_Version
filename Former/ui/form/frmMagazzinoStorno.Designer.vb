<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMagazzinoStorno
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grpRisorsa = New System.Windows.Forms.GroupBox()
        Me.pctRis = New Former.ucPictureWithZoom()
        Me.txtRimanenza = New Former.ucNumericTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblGiacenza = New System.Windows.Forms.Label()
        Me.txtQta = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRisSel = New System.Windows.Forms.Label()
        Me.UcMagazzinoCercaRisorsa = New Former.ucMagazzinoCercaRisorsa()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpMovimentiRecenti = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoMgrMovimenti = New Former.ucMagazzinoMgrMovimenti()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.dtDataStorno = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.TabMain.Controls.Add(Me.tpMovimentiRecenti)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(963, 680)
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
        Me.tbProd.Size = New System.Drawing.Size(955, 654)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Storno risorsa di magazzino"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources.do_not_mix96
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
        Me.grpRisorsa.Controls.Add(Me.Label3)
        Me.grpRisorsa.Controls.Add(Me.dtDataStorno)
        Me.grpRisorsa.Controls.Add(Me.pctRis)
        Me.grpRisorsa.Controls.Add(Me.txtRimanenza)
        Me.grpRisorsa.Controls.Add(Me.Label4)
        Me.grpRisorsa.Controls.Add(Me.lblGiacenza)
        Me.grpRisorsa.Controls.Add(Me.txtQta)
        Me.grpRisorsa.Controls.Add(Me.Label2)
        Me.grpRisorsa.Controls.Add(Me.lblRisSel)
        Me.grpRisorsa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grpRisorsa.Location = New System.Drawing.Point(103, 527)
        Me.grpRisorsa.Name = "grpRisorsa"
        Me.grpRisorsa.Size = New System.Drawing.Size(849, 121)
        Me.grpRisorsa.TabIndex = 110
        Me.grpRisorsa.TabStop = False
        Me.grpRisorsa.Text = "Risorsa selezionata"
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
        'txtRimanenza
        '
        Me.txtRimanenza.My_AccettaNegativi = False
        Me.txtRimanenza.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRimanenza.My_DefaultValue = 0
        Me.txtRimanenza.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtRimanenza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.txtRimanenza.Location = New System.Drawing.Point(771, 54)
        Me.txtRimanenza.MaxLength = 8
        Me.txtRimanenza.My_MaxValue = 9999999.0!
        Me.txtRimanenza.My_MinValue = -9999999.0!
        Me.txtRimanenza.Name = "txtRimanenza"
        Me.txtRimanenza.My_AllowOnlyInteger = False
        Me.txtRimanenza.My_ReplaceWithDefaultValue = True
        Me.txtRimanenza.Size = New System.Drawing.Size(72, 27)
        Me.txtRimanenza.TabIndex = 113
        Me.txtRimanenza.Text = "0"
        Me.txtRimanenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(681, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 19)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Rimanenza"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGiacenza
        '
        Me.lblGiacenza.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGiacenza.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblGiacenza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.lblGiacenza.Location = New System.Drawing.Point(505, 17)
        Me.lblGiacenza.Name = "lblGiacenza"
        Me.lblGiacenza.Size = New System.Drawing.Size(170, 32)
        Me.lblGiacenza.TabIndex = 25
        Me.lblGiacenza.Text = "-"
        Me.lblGiacenza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQta
        '
        Me.txtQta.My_AccettaNegativi = True
        Me.txtQta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQta.My_DefaultValue = 0
        Me.txtQta.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtQta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.txtQta.Location = New System.Drawing.Point(771, 20)
        Me.txtQta.MaxLength = 7
        Me.txtQta.My_MaxValue = 999999.0!
        Me.txtQta.My_MinValue = -999999.0!
        Me.txtQta.Name = "txtQta"
        Me.txtQta.My_AllowOnlyInteger = False
        Me.txtQta.My_ReplaceWithDefaultValue = True
        Me.txtQta.Size = New System.Drawing.Size(72, 27)
        Me.txtQta.TabIndex = 0
        Me.txtQta.Text = "1"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(681, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 19)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Qtà storno"
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
        Me.lblRisSel.Size = New System.Drawing.Size(423, 64)
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
        Me.UcMagazzinoCercaRisorsa.Location = New System.Drawing.Point(3, 43)
        Me.UcMagazzinoCercaRisorsa.Name = "UcMagazzinoCercaRisorsa"
        Me.UcMagazzinoCercaRisorsa.Size = New System.Drawing.Size(949, 478)
        Me.UcMagazzinoCercaRisorsa.SoloAttivi = False
        Me.UcMagazzinoCercaRisorsa.TabIndex = 111
        Me.UcMagazzinoCercaRisorsa.TipoRisorsaToShow = FormerLib.FormerEnum.enTipoRisOffSet.Tutto
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(940, 34)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Storno"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpMovimentiRecenti
        '
        Me.tpMovimentiRecenti.Controls.Add(Me.UcMagazzinoMgrMovimenti)
        Me.tpMovimentiRecenti.Location = New System.Drawing.Point(4, 22)
        Me.tpMovimentiRecenti.Name = "tpMovimentiRecenti"
        Me.tpMovimentiRecenti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMovimentiRecenti.Size = New System.Drawing.Size(955, 611)
        Me.tpMovimentiRecenti.TabIndex = 1
        Me.tpMovimentiRecenti.Text = "Movimenti recenti"
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
        Me.UcMagazzinoMgrMovimenti.Size = New System.Drawing.Size(949, 605)
        Me.UcMagazzinoMgrMovimenti.TabIndex = 0
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 680)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(963, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
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
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'dtDataStorno
        '
        Me.dtDataStorno.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.dtDataStorno.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDataStorno.Location = New System.Drawing.Point(685, 87)
        Me.dtDataStorno.Name = "dtDataStorno"
        Me.dtDataStorno.Size = New System.Drawing.Size(158, 29)
        Me.dtDataStorno.TabIndex = 116
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoEllipsis = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(505, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 23)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Data Storno"
        '
        'frmMagazzinoStorno
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(963, 728)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMagazzinoStorno"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Storno risorsa di magazzino"
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
    Friend WithEvents lblGiacenza As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRimanenza As ucNumericTextBox
    Friend WithEvents pctRis As ucPictureWithZoom
    Friend WithEvents tpMovimentiRecenti As TabPage
    Friend WithEvents UcMagazzinoMgrMovimenti As ucMagazzinoMgrMovimenti
    Friend WithEvents UcMagazzinoCercaRisorsa As ucMagazzinoCercaRisorsa
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtDataStorno As DateTimePicker
End Class
