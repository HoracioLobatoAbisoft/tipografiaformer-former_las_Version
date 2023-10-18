<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoCatFormato
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
        Me.UcPictureWizard = New Former.ucPictureWizard()
        Me.pctImgLav = New System.Windows.Forms.PictureBox()
        Me.txtImgLav = New System.Windows.Forms.TextBox()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lstFormatiProdotto = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescEst = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpDefault = New System.Windows.Forms.TabPage()
        Me.lnkDelDefault = New System.Windows.Forms.Button()
        Me.lnkAddDefault = New System.Windows.Forms.Button()
        Me.lstDefaultInseriti = New System.Windows.Forms.ListBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDefault.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 648)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(831, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(747, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 5
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
        Me.btnOk.Location = New System.Drawing.Point(665, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(76, 32)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpDefault)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(831, 648)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.UcPictureWizard)
        Me.tbProd.Controls.Add(Me.btnDel)
        Me.tbProd.Controls.Add(Me.btnAdd)
        Me.tbProd.Controls.Add(Me.lstFormatiProdotto)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtDescEst)
        Me.tbProd.Controls.Add(Me.btnSearch)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.txtImgLav)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.pctImgLav)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtNome)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(823, 622)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Categoria Formato Prodotto"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'UcPictureWizard
        '
        Me.UcPictureWizard.AutoSize = True
        Me.UcPictureWizard.Location = New System.Drawing.Point(734, 327)
        Me.UcPictureWizard.Name = "UcPictureWizard"
        Me.UcPictureWizard.RifPictureBox = Me.pctImgLav
        Me.UcPictureWizard.RifTextBoxPath = Me.txtImgLav
        Me.UcPictureWizard.Size = New System.Drawing.Size(77, 23)
        Me.UcPictureWizard.TabIndex = 155
        '
        'pctImgLav
        '
        Me.pctImgLav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgLav.Location = New System.Drawing.Point(683, 63)
        Me.pctImgLav.Name = "pctImgLav"
        Me.pctImgLav.Size = New System.Drawing.Size(128, 128)
        Me.pctImgLav.TabIndex = 92
        Me.pctImgLav.TabStop = False
        '
        'txtImgLav
        '
        Me.txtImgLav.Location = New System.Drawing.Point(164, 329)
        Me.txtImgLav.MaxLength = 50
        Me.txtImgLav.Name = "txtImgLav"
        Me.txtImgLav.ReadOnly = True
        Me.txtImgLav.Size = New System.Drawing.Size(532, 20)
        Me.txtImgLav.TabIndex = 3
        Me.txtImgLav.TabStop = False
        '
        'btnDel
        '
        Me.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDel.FlatAppearance.BorderSize = 0
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.ForeColor = System.Drawing.Color.Black
        Me.btnDel.Image = Global.Former.My.Resources.Resources._remove
        Me.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDel.Location = New System.Drawing.Point(48, 410)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(84, 30)
        Me.btnDel.TabIndex = 154
        Me.btnDel.Text = "Elimina"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(48, 374)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(91, 30)
        Me.btnAdd.TabIndex = 153
        Me.btnAdd.Text = "Aggiungi"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lstFormatiProdotto
        '
        Me.lstFormatiProdotto.FormattingEnabled = True
        Me.lstFormatiProdotto.Location = New System.Drawing.Point(164, 356)
        Me.lstFormatiProdotto.Name = "lstFormatiProdotto"
        Me.lstFormatiProdotto.Size = New System.Drawing.Size(532, 238)
        Me.lstFormatiProdotto.TabIndex = 152
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 15)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Formati Prodotto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Orange
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Descrizione sito"
        '
        'txtDescEst
        '
        Me.txtDescEst.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescEst.Location = New System.Drawing.Point(164, 90)
        Me.txtDescEst.MaxLength = 255
        Me.txtDescEst.Multiline = True
        Me.txtDescEst.Name = "txtDescEst"
        Me.txtDescEst.Size = New System.Drawing.Size(216, 233)
        Me.txtDescEst.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(702, 329)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 21)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(50, 332)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "Immagine"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(697, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 18)
        Me.Label8.TabIndex = 93
        Me.Label8.Text = "(128px - 128px)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Orange
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 15)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Nome"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(164, 63)
        Me.txtNome.MaxLength = 50
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(451, 20)
        Me.txtNome.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._CartellaAperta
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
        Me.lblTipo.Size = New System.Drawing.Size(224, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Categoria Formato Prodotto"
        '
        'tpDefault
        '
        Me.tpDefault.Controls.Add(Me.lnkDelDefault)
        Me.tpDefault.Controls.Add(Me.lnkAddDefault)
        Me.tpDefault.Controls.Add(Me.lstDefaultInseriti)
        Me.tpDefault.Controls.Add(Me.PictureBox1)
        Me.tpDefault.Controls.Add(Me.Label3)
        Me.tpDefault.Location = New System.Drawing.Point(4, 22)
        Me.tpDefault.Name = "tpDefault"
        Me.tpDefault.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDefault.Size = New System.Drawing.Size(823, 622)
        Me.tpDefault.TabIndex = 1
        Me.tpDefault.Text = "Default per Preventivazione"
        Me.tpDefault.UseVisualStyleBackColor = True
        '
        'lnkDelDefault
        '
        Me.lnkDelDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.lnkDelDefault.FlatAppearance.BorderSize = 0
        Me.lnkDelDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkDelDefault.ForeColor = System.Drawing.Color.Black
        Me.lnkDelDefault.Image = Global.Former.My.Resources.Resources.minus
        Me.lnkDelDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelDefault.Location = New System.Drawing.Point(13, 109)
        Me.lnkDelDefault.Name = "lnkDelDefault"
        Me.lnkDelDefault.Size = New System.Drawing.Size(84, 30)
        Me.lnkDelDefault.TabIndex = 160
        Me.lnkDelDefault.Text = "Elimina"
        Me.lnkDelDefault.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkDelDefault.UseVisualStyleBackColor = True
        '
        'lnkAddDefault
        '
        Me.lnkAddDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.lnkAddDefault.FlatAppearance.BorderSize = 0
        Me.lnkAddDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkAddDefault.ForeColor = System.Drawing.Color.Black
        Me.lnkAddDefault.Image = Global.Former.My.Resources.Resources.plus
        Me.lnkAddDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAddDefault.Location = New System.Drawing.Point(13, 73)
        Me.lnkAddDefault.Name = "lnkAddDefault"
        Me.lnkAddDefault.Size = New System.Drawing.Size(91, 30)
        Me.lnkAddDefault.TabIndex = 159
        Me.lnkAddDefault.Text = "Aggiungi"
        Me.lnkAddDefault.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkAddDefault.UseVisualStyleBackColor = True
        '
        'lstDefaultInseriti
        '
        Me.lstDefaultInseriti.FormattingEnabled = True
        Me.lstDefaultInseriti.Location = New System.Drawing.Point(129, 55)
        Me.lstDefaultInseriti.Name = "lstDefaultInseriti"
        Me.lstDefaultInseriti.Size = New System.Drawing.Size(630, 537)
        Me.lstDefaultInseriti.TabIndex = 158
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._CartellaAperta
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 156
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(49, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(224, 21)
        Me.Label3.TabIndex = 155
        Me.Label3.Text = "Default per preventivazione"
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'frmListinoCatFormato
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(831, 696)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmListinoCatFormato"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Categoria Formato Prodotto"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDefault.ResumeLayout(False)
        Me.tpDefault.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDescEst As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents txtImgLav As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents pctImgLav As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents OpenFileImg As OpenFileDialog
    Friend WithEvents tpDefault As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDel As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents lstFormatiProdotto As ListBox
    Friend WithEvents lnkDelDefault As Button
    Friend WithEvents lnkAddDefault As Button
    Friend WithEvents lstDefaultInseriti As ListBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents UcPictureWizard As ucPictureWizard
End Class
