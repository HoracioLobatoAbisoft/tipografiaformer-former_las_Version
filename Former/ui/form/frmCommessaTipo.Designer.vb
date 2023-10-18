<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommessaTipo
    Inherits baseFormInterna
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCommessaTipo))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCatMod = New System.Windows.Forms.ComboBox()
        Me.txtNumSpazi = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQuantita = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTempoRif = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPremioStampa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoCom = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblImpianti = New System.Windows.Forms.Label()
        Me.cmbImpianti = New System.Windows.Forms.ComboBox()
        Me.lblFormato = New System.Windows.Forms.Label()
        Me.cmbFormato = New System.Windows.Forms.ComboBox()
        Me.lblMaccStampa = New System.Windows.Forms.Label()
        Me.UcLavorazioni = New Former.ucLavorazioni()
        Me.cmbMaccStampa = New System.Windows.Forms.ComboBox()
        Me.chkFronteRetro = New System.Windows.Forms.CheckBox()
        Me.cmbRisorsa = New System.Windows.Forms.ComboBox()
        Me.lblRisPred = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 676)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(790, 48)
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
        Me.btnCancel.Image = Global.Former.My.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(754, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.TabStop = False
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources._Ok
        Me.btnOk.Location = New System.Drawing.Point(718, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 15
        Me.btnOk.TabStop = False
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(790, 676)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.cmbCatMod)
        Me.tbProd.Controls.Add(Me.txtNumSpazi)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtQuantita)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtTempoRif)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.txtPremioStampa)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbTipoCom)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.lblImpianti)
        Me.tbProd.Controls.Add(Me.cmbImpianti)
        Me.tbProd.Controls.Add(Me.lblFormato)
        Me.tbProd.Controls.Add(Me.cmbFormato)
        Me.tbProd.Controls.Add(Me.lblMaccStampa)
        Me.tbProd.Controls.Add(Me.UcLavorazioni)
        Me.tbProd.Controls.Add(Me.cmbMaccStampa)
        Me.tbProd.Controls.Add(Me.chkFronteRetro)
        Me.tbProd.Controls.Add(Me.cmbRisorsa)
        Me.tbProd.Controls.Add(Me.lblRisPred)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtDescrizione)
        Me.tbProd.Controls.Add(Me.Label35)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(782, 648)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Tipo Commessa"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(52, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 15)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Modelli Commessa"
        '
        'cmbCatMod
        '
        Me.cmbCatMod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCatMod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCatMod.FormattingEnabled = True
        Me.cmbCatMod.Location = New System.Drawing.Point(179, 169)
        Me.cmbCatMod.Name = "cmbCatMod"
        Me.cmbCatMod.Size = New System.Drawing.Size(247, 23)
        Me.cmbCatMod.TabIndex = 65
        '
        'txtNumSpazi
        '
        Me.txtNumSpazi.Location = New System.Drawing.Point(479, 256)
        Me.txtNumSpazi.Name = "txtNumSpazi"
        Me.txtNumSpazi.Size = New System.Drawing.Size(145, 21)
        Me.txtNumSpazi.TabIndex = 64
        Me.txtNumSpazi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(388, 259)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 15)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Numero Spazi"
        '
        'txtQuantita
        '
        Me.txtQuantita.Location = New System.Drawing.Point(179, 256)
        Me.txtQuantita.Name = "txtQuantita"
        Me.txtQuantita.Size = New System.Drawing.Size(145, 21)
        Me.txtQuantita.TabIndex = 62
        Me.txtQuantita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 259)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Quantità"
        '
        'txtTempoRif
        '
        Me.txtTempoRif.Location = New System.Drawing.Point(479, 283)
        Me.txtTempoRif.Name = "txtTempoRif"
        Me.txtTempoRif.Size = New System.Drawing.Size(145, 21)
        Me.txtTempoRif.TabIndex = 60
        Me.txtTempoRif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(338, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 15)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Tempo Riferim. Premio"
        '
        'txtPremioStampa
        '
        Me.txtPremioStampa.Location = New System.Drawing.Point(179, 283)
        Me.txtPremioStampa.Name = "txtPremioStampa"
        Me.txtPremioStampa.Size = New System.Drawing.Size(145, 21)
        Me.txtPremioStampa.TabIndex = 58
        Me.txtPremioStampa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Premio Stampa"
        '
        'cmbTipoCom
        '
        Me.cmbTipoCom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipoCom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoCom.FormattingEnabled = True
        Me.cmbTipoCom.Location = New System.Drawing.Point(179, 55)
        Me.cmbTipoCom.Name = "cmbTipoCom"
        Me.cmbTipoCom.Size = New System.Drawing.Size(247, 23)
        Me.cmbTipoCom.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(51, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 15)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Tipo Commessa"
        '
        'lblImpianti
        '
        Me.lblImpianti.AutoSize = True
        Me.lblImpianti.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblImpianti.ForeColor = System.Drawing.Color.Black
        Me.lblImpianti.Location = New System.Drawing.Point(52, 230)
        Me.lblImpianti.Name = "lblImpianti"
        Me.lblImpianti.Size = New System.Drawing.Size(51, 15)
        Me.lblImpianti.TabIndex = 54
        Me.lblImpianti.Text = "Impianti"
        '
        'cmbImpianti
        '
        Me.cmbImpianti.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbImpianti.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbImpianti.FormattingEnabled = True
        Me.cmbImpianti.Location = New System.Drawing.Point(179, 227)
        Me.cmbImpianti.Name = "cmbImpianti"
        Me.cmbImpianti.Size = New System.Drawing.Size(445, 23)
        Me.cmbImpianti.TabIndex = 53
        '
        'lblFormato
        '
        Me.lblFormato.AutoSize = True
        Me.lblFormato.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblFormato.ForeColor = System.Drawing.Color.Black
        Me.lblFormato.Location = New System.Drawing.Point(52, 201)
        Me.lblFormato.Name = "lblFormato"
        Me.lblFormato.Size = New System.Drawing.Size(53, 15)
        Me.lblFormato.TabIndex = 52
        Me.lblFormato.Text = "Formato"
        '
        'cmbFormato
        '
        Me.cmbFormato.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFormato.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFormato.FormattingEnabled = True
        Me.cmbFormato.Location = New System.Drawing.Point(179, 198)
        Me.cmbFormato.Name = "cmbFormato"
        Me.cmbFormato.Size = New System.Drawing.Size(247, 23)
        Me.cmbFormato.TabIndex = 51
        '
        'lblMaccStampa
        '
        Me.lblMaccStampa.AutoSize = True
        Me.lblMaccStampa.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblMaccStampa.ForeColor = System.Drawing.Color.Black
        Me.lblMaccStampa.Location = New System.Drawing.Point(52, 143)
        Me.lblMaccStampa.Name = "lblMaccStampa"
        Me.lblMaccStampa.Size = New System.Drawing.Size(121, 15)
        Me.lblMaccStampa.TabIndex = 50
        Me.lblMaccStampa.Text = "Macchina da stampa"
        '
        'UcLavorazioni
        '
        Me.UcLavorazioni.BackColor = System.Drawing.Color.White
        Me.UcLavorazioni.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.UcLavorazioni.Location = New System.Drawing.Point(41, 310)
        Me.UcLavorazioni.Name = "UcLavorazioni"
        Me.UcLavorazioni.Size = New System.Drawing.Size(733, 332)
        Me.UcLavorazioni.SolaLettura = False
        Me.UcLavorazioni.TabIndex = 49
        '
        'cmbMaccStampa
        '
        Me.cmbMaccStampa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMaccStampa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMaccStampa.FormattingEnabled = True
        Me.cmbMaccStampa.Location = New System.Drawing.Point(179, 140)
        Me.cmbMaccStampa.Name = "cmbMaccStampa"
        Me.cmbMaccStampa.Size = New System.Drawing.Size(247, 23)
        Me.cmbMaccStampa.TabIndex = 48
        '
        'chkFronteRetro
        '
        Me.chkFronteRetro.AutoSize = True
        Me.chkFronteRetro.Location = New System.Drawing.Point(432, 200)
        Me.chkFronteRetro.Name = "chkFronteRetro"
        Me.chkFronteRetro.Size = New System.Drawing.Size(91, 19)
        Me.chkFronteRetro.TabIndex = 5
        Me.chkFronteRetro.Text = "FronteRetro"
        Me.chkFronteRetro.UseVisualStyleBackColor = True
        '
        'cmbRisorsa
        '
        Me.cmbRisorsa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRisorsa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRisorsa.FormattingEnabled = True
        Me.cmbRisorsa.Location = New System.Drawing.Point(179, 111)
        Me.cmbRisorsa.Name = "cmbRisorsa"
        Me.cmbRisorsa.Size = New System.Drawing.Size(445, 23)
        Me.cmbRisorsa.TabIndex = 1
        '
        'lblRisPred
        '
        Me.lblRisPred.AutoSize = True
        Me.lblRisPred.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblRisPred.ForeColor = System.Drawing.Color.Black
        Me.lblRisPred.Location = New System.Drawing.Point(52, 114)
        Me.lblRisPred.Name = "lblRisPred"
        Me.lblRisPred.Size = New System.Drawing.Size(112, 15)
        Me.lblRisPred.TabIndex = 20
        Me.lblRisPred.Text = "Risorsa predefinita"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(52, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Descrizione"
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Location = New System.Drawing.Point(179, 84)
        Me.txtDescrizione.MaxLength = 50
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(445, 21)
        Me.txtDescrizione.TabIndex = 0
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(206, 18)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(280, 22)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Dettaglio del tipo di commessa."
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.icoCom
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
        Me.lblTipo.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(150, 22)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Tipo Commessa"
        '
        'frmCommessaTipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(790, 724)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCommessaTipo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Tipo Commessa"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents chkFronteRetro As System.Windows.Forms.CheckBox
    Friend WithEvents cmbRisorsa As System.Windows.Forms.ComboBox
    Friend WithEvents lblRisPred As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents UcLavorazioni As Former.ucLavorazioni
    Friend WithEvents cmbMaccStampa As System.Windows.Forms.ComboBox
    Friend WithEvents lblMaccStampa As System.Windows.Forms.Label
    Friend WithEvents lblFormato As System.Windows.Forms.Label
    Friend WithEvents cmbFormato As System.Windows.Forms.ComboBox
    Friend WithEvents lblImpianti As System.Windows.Forms.Label
    Friend WithEvents cmbImpianti As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoCom As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPremioStampa As System.Windows.Forms.TextBox
    Friend WithEvents txtTempoRif As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumSpazi As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQuantita As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCatMod As System.Windows.Forms.ComboBox
End Class
