<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsegnaOperatore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsegnaOperatore))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbOperatore = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnComprimi = New System.Windows.Forms.Button()
        Me.btnEspandi = New System.Windows.Forms.Button()
        Me.cmbCorriere = New System.Windows.Forms.ComboBox()
        Me.btnAvanti = New System.Windows.Forms.Button()
        Me.btnIndietro = New System.Windows.Forms.Button()
        Me.UcOrdineAnteprima = New Former.ucOrdiniAnteprima()
        Me.UcConsegneGiorno = New Former.ucConsegneGiorno()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Location = New System.Drawing.Point(1058, 23)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(37, 727)
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
        Me.btnCancel.Location = New System.Drawing.Point(3, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 16
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
        Me.TabMain.Size = New System.Drawing.Size(1059, 750)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.cmbZona)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.cmbOperatore)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.btnComprimi)
        Me.tbProd.Controls.Add(Me.btnEspandi)
        Me.tbProd.Controls.Add(Me.cmbCorriere)
        Me.tbProd.Controls.Add(Me.btnAvanti)
        Me.tbProd.Controls.Add(Me.btnIndietro)
        Me.tbProd.Controls.Add(Me.UcOrdineAnteprima)
        Me.tbProd.Controls.Add(Me.UcConsegneGiorno)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1051, 722)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Consegna del giorno"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'cmbZona
        '
        Me.cmbZona.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbZona.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbZona.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(642, 37)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(297, 23)
        Me.cmbZona.TabIndex = 74
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(601, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 15)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Zona"
        '
        'cmbOperatore
        '
        Me.cmbOperatore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbOperatore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOperatore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOperatore.FormattingEnabled = True
        Me.cmbOperatore.Location = New System.Drawing.Point(256, 38)
        Me.cmbOperatore.Name = "cmbOperatore"
        Me.cmbOperatore.Size = New System.Drawing.Size(339, 23)
        Me.cmbOperatore.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Operatore"
        '
        'btnComprimi
        '
        Me.btnComprimi.BackColor = System.Drawing.Color.White
        Me.btnComprimi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnComprimi.Image = Global.Former.My.Resources.minus
        Me.btnComprimi.Location = New System.Drawing.Point(150, 4)
        Me.btnComprimi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnComprimi.Name = "btnComprimi"
        Me.btnComprimi.Size = New System.Drawing.Size(32, 45)
        Me.btnComprimi.TabIndex = 21
        Me.btnComprimi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnComprimi.UseVisualStyleBackColor = False
        '
        'btnEspandi
        '
        Me.btnEspandi.BackColor = System.Drawing.Color.White
        Me.btnEspandi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEspandi.Image = Global.Former.My.Resources.plus
        Me.btnEspandi.Location = New System.Drawing.Point(112, 4)
        Me.btnEspandi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEspandi.Name = "btnEspandi"
        Me.btnEspandi.Size = New System.Drawing.Size(32, 45)
        Me.btnEspandi.TabIndex = 20
        Me.btnEspandi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEspandi.UseVisualStyleBackColor = False
        '
        'cmbCorriere
        '
        Me.cmbCorriere.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmbCorriere.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmbCorriere.FormattingEnabled = True
        Me.cmbCorriere.Location = New System.Drawing.Point(8, 66)
        Me.cmbCorriere.Name = "cmbCorriere"
        Me.cmbCorriere.Size = New System.Drawing.Size(723, 27)
        Me.cmbCorriere.TabIndex = 19
        '
        'btnAvanti
        '
        Me.btnAvanti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAvanti.AutoSize = True
        Me.btnAvanti.BackColor = System.Drawing.Color.White
        Me.btnAvanti.FlatAppearance.BorderSize = 0
        Me.btnAvanti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAvanti.Image = Global.Former.My.Resources.right
        Me.btnAvanti.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAvanti.Location = New System.Drawing.Point(945, 4)
        Me.btnAvanti.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAvanti.Name = "btnAvanti"
        Me.btnAvanti.Size = New System.Drawing.Size(100, 45)
        Me.btnAvanti.TabIndex = 18
        Me.btnAvanti.Text = "Successiva"
        Me.btnAvanti.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAvanti.UseVisualStyleBackColor = False
        '
        'btnIndietro
        '
        Me.btnIndietro.AutoSize = True
        Me.btnIndietro.BackColor = System.Drawing.Color.White
        Me.btnIndietro.FlatAppearance.BorderSize = 0
        Me.btnIndietro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnIndietro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnIndietro.Image = Global.Former.My.Resources.left
        Me.btnIndietro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIndietro.Location = New System.Drawing.Point(6, 4)
        Me.btnIndietro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnIndietro.Name = "btnIndietro"
        Me.btnIndietro.Size = New System.Drawing.Size(100, 45)
        Me.btnIndietro.TabIndex = 17
        Me.btnIndietro.Text = "Precedente"
        Me.btnIndietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIndietro.UseVisualStyleBackColor = False
        '
        'UcOrdineAnteprima
        '
        Me.UcOrdineAnteprima.BackColor = System.Drawing.Color.White
        Me.UcOrdineAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdineAnteprima.Location = New System.Drawing.Point(738, 66)
        Me.UcOrdineAnteprima.Name = "UcOrdineAnteprima"
        Me.UcOrdineAnteprima.NoLavori = False
        Me.UcOrdineAnteprima.Size = New System.Drawing.Size(307, 650)
        Me.UcOrdineAnteprima.TabIndex = 16
        '
        'UcConsegneGiorno
        '
        Me.UcConsegneGiorno.BackColor = System.Drawing.Color.White
        Me.UcConsegneGiorno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcConsegneGiorno.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneGiorno.ForeColor = System.Drawing.Color.Black
        Me.UcConsegneGiorno.IdCorr = 0
        Me.UcConsegneGiorno.IdOrdSel = 0
        Me.UcConsegneGiorno.IsOperatore = False
        Me.UcConsegneGiorno.Location = New System.Drawing.Point(6, 99)
        Me.UcConsegneGiorno.Name = "UcConsegneGiorno"
        Me.UcConsegneGiorno.Operatore = False
        Me.UcConsegneGiorno.Size = New System.Drawing.Size(726, 617)
        Me.UcConsegneGiorno.TabIndex = 15
        Me.UcConsegneGiorno.TestoSelezionato = Nothing
        '
        'lblTipo
        '
        Me.lblTipo.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.Red
        Me.lblTipo.Location = New System.Drawing.Point(188, 4)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(751, 25)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "-"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmConsProgrOperat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1096, 750)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        
        Me.KeyPreview = True
        Me.Name = "frmConsProgrOperat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Consegne del giorno"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents UcConsegneGiorno As Former.ucConsegneGiorno
    Friend WithEvents UcOrdineAnteprima As Former.ucOrdiniAnteprima
    Friend WithEvents btnAvanti As System.Windows.Forms.Button
    Friend WithEvents btnIndietro As System.Windows.Forms.Button
    Friend WithEvents cmbCorriere As System.Windows.Forms.ComboBox
    Friend WithEvents btnComprimi As System.Windows.Forms.Button
    Friend WithEvents btnEspandi As System.Windows.Forms.Button
    Friend WithEvents cmbZona As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbOperatore As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
