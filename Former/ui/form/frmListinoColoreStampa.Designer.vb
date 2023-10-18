<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoColoreStampa
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
        Me.components = New System.ComponentModel.Container()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.UcPictureWizard = New Former.ucPictureWizard()
        Me.pctImgLav = New System.Windows.Forms.PictureBox()
        Me.txtImgLav = New System.Windows.Forms.TextBox()
        Me.chkFR = New System.Windows.Forms.CheckBox()
        Me.txtNLastre = New Former.ucNumericTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSigla = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpImpatto = New System.Windows.Forms.TabPage()
        Me.UcListinoImpatto = New Former.ucListinoImpatto()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpImpatto.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 219)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(669, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(633, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnOk.Location = New System.Drawing.Point(597, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpImpatto)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(669, 219)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.UcPictureWizard)
        Me.tbProd.Controls.Add(Me.chkFR)
        Me.tbProd.Controls.Add(Me.txtNLastre)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtSigla)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.btnSearch)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.txtImgLav)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.pctImgLav)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtDescrizione)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(661, 193)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Colore Stampa"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'UcPictureWizard
        '
        Me.UcPictureWizard.AutoSize = True
        Me.UcPictureWizard.ImgHeight = 128
        Me.UcPictureWizard.ImgWidth = 128
        Me.UcPictureWizard.Location = New System.Drawing.Point(437, 108)
        Me.UcPictureWizard.Name = "UcPictureWizard"
        Me.UcPictureWizard.RifPictureBox = Me.pctImgLav
        Me.UcPictureWizard.RifTextBoxPath = Me.txtImgLav
        Me.UcPictureWizard.Size = New System.Drawing.Size(77, 23)
        Me.UcPictureWizard.TabIndex = 116
        '
        'pctImgLav
        '
        Me.pctImgLav.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctImgLav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgLav.Location = New System.Drawing.Point(525, 33)
        Me.pctImgLav.Name = "pctImgLav"
        Me.pctImgLav.Size = New System.Drawing.Size(128, 128)
        Me.pctImgLav.TabIndex = 57
        Me.pctImgLav.TabStop = False
        '
        'txtImgLav
        '
        Me.txtImgLav.Location = New System.Drawing.Point(164, 109)
        Me.txtImgLav.MaxLength = 50
        Me.txtImgLav.Name = "txtImgLav"
        Me.txtImgLav.ReadOnly = True
        Me.txtImgLav.Size = New System.Drawing.Size(235, 20)
        Me.txtImgLav.TabIndex = 59
        '
        'chkFR
        '
        Me.chkFR.AutoSize = True
        Me.chkFR.Location = New System.Drawing.Point(164, 136)
        Me.chkFR.Name = "chkFR"
        Me.chkFR.Size = New System.Drawing.Size(15, 14)
        Me.chkFR.TabIndex = 74
        Me.chkFR.UseVisualStyleBackColor = True
        '
        'txtNLastre
        '
        Me.txtNLastre.My_AccettaNegativi = False
        Me.txtNLastre.My_DefaultValue = 1
        Me.txtNLastre.Location = New System.Drawing.Point(164, 159)
        Me.txtNLastre.My_MaxValue = 1.0E+10!
        Me.txtNLastre.My_MinValue = -1.0E+9!
        Me.txtNLastre.Name = "txtNLastre"
        Me.txtNLastre.My_AllowOnlyInteger = False
        Me.txtNLastre.My_ReplaceWithDefaultValue = True
        Me.txtNLastre.Size = New System.Drawing.Size(82, 20)
        Me.txtNLastre.TabIndex = 73
        Me.txtNLastre.Text = "1"
        Me.txtNLastre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 15)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "F/R"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Sigla"
        '
        'txtSigla
        '
        Me.txtSigla.Location = New System.Drawing.Point(164, 55)
        Me.txtSigla.MaxLength = 50
        Me.txtSigla.Name = "txtSigla"
        Me.txtSigla.Size = New System.Drawing.Size(82, 20)
        Me.txtSigla.TabIndex = 69
        Me.txtSigla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "N° Lastre"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(405, 109)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 21)
        Me.btnSearch.TabIndex = 61
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(50, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Immagine"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(539, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 18)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "(128px - 128px)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Descrizione"
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Location = New System.Drawing.Point(164, 82)
        Me.txtDescrizione.MaxLength = 50
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(299, 20)
        Me.txtDescrizione.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._ColoreStampa
        Me.pctTipo.Location = New System.Drawing.Point(17, 8)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(26, 26)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
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
        Me.lblTipo.Size = New System.Drawing.Size(122, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Colore Stampa"
        '
        'tpImpatto
        '
        Me.tpImpatto.Controls.Add(Me.UcListinoImpatto)
        Me.tpImpatto.Location = New System.Drawing.Point(4, 22)
        Me.tpImpatto.Name = "tpImpatto"
        Me.tpImpatto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpImpatto.Size = New System.Drawing.Size(661, 193)
        Me.tpImpatto.TabIndex = 1
        Me.tpImpatto.Text = "Influisce su..."
        Me.tpImpatto.UseVisualStyleBackColor = True
        '
        'UcListinoImpatto
        '
        Me.UcListinoImpatto.BackColor = System.Drawing.Color.White
        Me.UcListinoImpatto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcListinoImpatto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcListinoImpatto.Location = New System.Drawing.Point(3, 3)
        Me.UcListinoImpatto.Name = "UcListinoImpatto"
        Me.UcListinoImpatto.Size = New System.Drawing.Size(655, 187)
        Me.UcListinoImpatto.TabIndex = 0
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'frmListinoColoreStampa
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(669, 267)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoColoreStampa"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Colore Stampa"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpImpatto.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pctImgLav As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtImgLav As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSigla As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkFR As System.Windows.Forms.CheckBox
    Friend WithEvents txtNLastre As ucNumericTextBox
    Friend WithEvents tpImpatto As System.Windows.Forms.TabPage
    Friend WithEvents UcListinoImpatto As Former.ucListinoImpatto
    Friend WithEvents UcPictureWizard As ucPictureWizard
End Class
