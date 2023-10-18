<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatProd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatProd))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnSelectImg = New System.Windows.Forms.Button()
        Me.btnSelCat = New System.Windows.Forms.Button()
        Me.lblCat = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkTipCommessa = New System.Windows.Forms.CheckedListBox()
        Me.chkCarat = New System.Windows.Forms.CheckedListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtImg = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescrEstesa = New System.Windows.Forms.TextBox()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pctImgLav = New System.Windows.Forms.PictureBox()
        Me.gbPulsanti.SuspendLayout
        Me.TabMain.SuspendLayout
        Me.tbProd.SuspendLayout
        CType(Me.pctTipo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pctImgLav,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(3, 482)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(752, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = false
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.icoCancel
        Me.btnCancel.Location = New System.Drawing.Point(716, 12)
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
        Me.btnOk.Image = Global.Former.My.Resources.icoOk
        Me.btnOk.Location = New System.Drawing.Point(680, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(3, 2)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(752, 480)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.pctImgLav)
        Me.tbProd.Controls.Add(Me.btnSelectImg)
        Me.tbProd.Controls.Add(Me.btnSelCat)
        Me.tbProd.Controls.Add(Me.lblCat)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.chkTipCommessa)
        Me.tbProd.Controls.Add(Me.chkCarat)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtImg)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtDescrEstesa)
        Me.tbProd.Controls.Add(Me.txtDescrizione)
        Me.tbProd.Controls.Add(Me.Label35)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(744, 452)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Dettaglio Categoria Prodotto"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnSelectImg
        '
        Me.btnSelectImg.Location = New System.Drawing.Point(685, 187)
        Me.btnSelectImg.Name = "btnSelectImg"
        Me.btnSelectImg.Size = New System.Drawing.Size(24, 21)
        Me.btnSelectImg.TabIndex = 104
        Me.btnSelectImg.Text = "..."
        Me.btnSelectImg.UseVisualStyleBackColor = True
        '
        'btnSelCat
        '
        Me.btnSelCat.Location = New System.Drawing.Point(463, 132)
        Me.btnSelCat.Name = "btnSelCat"
        Me.btnSelCat.Size = New System.Drawing.Size(24, 23)
        Me.btnSelCat.TabIndex = 103
        Me.btnSelCat.Text = "..."
        Me.btnSelCat.UseVisualStyleBackColor = True
        '
        'lblCat
        '
        Me.lblCat.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCat.Location = New System.Drawing.Point(154, 132)
        Me.lblCat.Name = "lblCat"
        Me.lblCat.Size = New System.Drawing.Size(303, 24)
        Me.lblCat.TabIndex = 102
        Me.lblCat.Text = "..."
        Me.lblCat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(390, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 15)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Tipologie Commessa"
        '
        'chkTipCommessa
        '
        Me.chkTipCommessa.FormattingEnabled = True
        Me.chkTipCommessa.Location = New System.Drawing.Point(393, 256)
        Me.chkTipCommessa.Name = "chkTipCommessa"
        Me.chkTipCommessa.Size = New System.Drawing.Size(303, 180)
        Me.chkTipCommessa.TabIndex = 29
        '
        'chkCarat
        '
        Me.chkCarat.FormattingEnabled = True
        Me.chkCarat.Location = New System.Drawing.Point(50, 256)
        Me.chkCarat.Name = "chkCarat"
        Me.chkCarat.Size = New System.Drawing.Size(303, 180)
        Me.chkCarat.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(47, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 15)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Caratteristiche"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(151, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(563, 15)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "(nome del file immagine associato alla categoria. Il file si deve trovare all'int" &
    "erno della directory listino)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(50, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 15)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Immagine"
        '
        'txtImg
        '
        Me.txtImg.Location = New System.Drawing.Point(154, 187)
        Me.txtImg.MaxLength = 50
        Me.txtImg.Name = "txtImg"
        Me.txtImg.ReadOnly = True
        Me.txtImg.Size = New System.Drawing.Size(525, 21)
        Me.txtImg.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Cat. Padre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(151, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(299, 15)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "(lascia vuoto se vuoi che sia una categoria principale)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(151, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "(sotto la descrizione nel listino generato)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Descr. Estesa"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Descrizione"
        '
        'txtDescrEstesa
        '
        Me.txtDescrEstesa.Location = New System.Drawing.Point(154, 88)
        Me.txtDescrEstesa.MaxLength = 50
        Me.txtDescrEstesa.Name = "txtDescrEstesa"
        Me.txtDescrEstesa.Size = New System.Drawing.Size(303, 21)
        Me.txtDescrEstesa.TabIndex = 0
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Location = New System.Drawing.Point(154, 57)
        Me.txtDescrizione.MaxLength = 50
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(303, 21)
        Me.txtDescrizione.TabIndex = 0
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(225, 18)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(394, 22)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Dettaglio della categoria prodotto a listino."
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.icoProd
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = false
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = true
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(170, 22)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Categoria Prodotto"
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(554, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 18)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "(128px - 128px)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctImgLav
        '
        Me.pctImgLav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgLav.Location = New System.Drawing.Point(541, 24)
        Me.pctImgLav.Name = "pctImgLav"
        Me.pctImgLav.Size = New System.Drawing.Size(128, 128)
        Me.pctImgLav.TabIndex = 105
        Me.pctImgLav.TabStop = false
        '
        'frmCatProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(757, 532)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Name = "frmCatProd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - "
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.gbPulsanti.ResumeLayout(false)
        Me.TabMain.ResumeLayout(false)
        Me.tbProd.ResumeLayout(false)
        Me.tbProd.PerformLayout
        CType(Me.pctTipo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pctImgLav,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescrEstesa As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtImg As System.Windows.Forms.TextBox
    Friend WithEvents chkCarat As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkTipCommessa As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSelCat As System.Windows.Forms.Button
    Friend WithEvents lblCat As System.Windows.Forms.Label
    Friend WithEvents btnSelectImg As System.Windows.Forms.Button
    Friend WithEvents OpenFileImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pctImgLav As System.Windows.Forms.PictureBox
End Class
