<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsegnaOrdiniRCTF
    Inherits baseFormInternaRedim

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnUscitoSel = New System.Windows.Forms.Button()
        Me.btnOkAll = New System.Windows.Forms.Button()
        Me.chkEmettiDoc = New System.Windows.Forms.CheckBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.DgLavori = New System.Windows.Forms.DataGridView()
        Me.Anteprima = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Ordine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prodotto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColliCaricati = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColliTotali = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prezzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tmrColli = New System.Windows.Forms.Timer(Me.components)
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPulsanti.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(935, 500)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnUscitoSel)
        Me.tbProd.Controls.Add(Me.btnOkAll)
        Me.tbProd.Controls.Add(Me.chkEmettiDoc)
        Me.tbProd.Controls.Add(Me.btnAdd)
        Me.tbProd.Controls.Add(Me.DgLavori)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(927, 474)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Consegna ordini"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnUscitoSel
        '
        Me.btnUscitoSel.BackColor = System.Drawing.Color.White
        Me.btnUscitoSel.Image = Global.Former.My.Resources.Resources._Uscito
        Me.btnUscitoSel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUscitoSel.Location = New System.Drawing.Point(6, 121)
        Me.btnUscitoSel.Name = "btnUscitoSel"
        Me.btnUscitoSel.Size = New System.Drawing.Size(69, 69)
        Me.btnUscitoSel.TabIndex = 124
        Me.btnUscitoSel.Text = "Uscito Selez."
        Me.btnUscitoSel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.toolTipHelp.SetToolTip(Me.btnUscitoSel, "Segna tutti i colli presenti come usciti")
        Me.btnUscitoSel.UseVisualStyleBackColor = False
        Me.btnUscitoSel.Visible = False
        '
        'btnOkAll
        '
        Me.btnOkAll.BackColor = System.Drawing.Color.White
        Me.btnOkAll.Image = Global.Former.My.Resources.Resources._UscitoAll
        Me.btnOkAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOkAll.Location = New System.Drawing.Point(6, 196)
        Me.btnOkAll.Name = "btnOkAll"
        Me.btnOkAll.Size = New System.Drawing.Size(69, 69)
        Me.btnOkAll.TabIndex = 92
        Me.btnOkAll.Text = "Tutti Usciti"
        Me.btnOkAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.toolTipHelp.SetToolTip(Me.btnOkAll, "Segna tutti i colli presenti come usciti")
        Me.btnOkAll.UseVisualStyleBackColor = False
        Me.btnOkAll.Visible = False
        '
        'chkEmettiDoc
        '
        Me.chkEmettiDoc.AutoSize = True
        Me.chkEmettiDoc.BackColor = System.Drawing.Color.Red
        Me.chkEmettiDoc.Enabled = False
        Me.chkEmettiDoc.Location = New System.Drawing.Point(213, 16)
        Me.chkEmettiDoc.Name = "chkEmettiDoc"
        Me.chkEmettiDoc.Size = New System.Drawing.Size(209, 19)
        Me.chkEmettiDoc.TabIndex = 91
        Me.chkEmettiDoc.Text = "Emetti documenti fiscali se previsti"
        Me.chkEmettiDoc.UseVisualStyleBackColor = False
        Me.chkEmettiDoc.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAdd.Location = New System.Drawing.Point(6, 46)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(69, 69)
        Me.btnAdd.TabIndex = 88
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'DgLavori
        '
        Me.DgLavori.AllowUserToAddRows = False
        Me.DgLavori.AllowUserToDeleteRows = False
        Me.DgLavori.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLavori.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLavori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgLavori.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgLavori.BackgroundColor = System.Drawing.Color.White
        Me.DgLavori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLavori.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavori.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLavori.ColumnHeadersHeight = 20
        Me.DgLavori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLavori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Anteprima, Me.Ordine, Me.Prodotto, Me.Cliente, Me.ColliCaricati, Me.ColliTotali, Me.Prezzo})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgLavori.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavori.EnableHeadersVisualStyles = False
        Me.DgLavori.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavori.Location = New System.Drawing.Point(81, 46)
        Me.DgLavori.MultiSelect = False
        Me.DgLavori.Name = "DgLavori"
        Me.DgLavori.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgLavori.RowHeadersVisible = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DgLavori.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.DgLavori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.Height = 150
        Me.DgLavori.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavori.Size = New System.Drawing.Size(840, 422)
        Me.DgLavori.TabIndex = 87
        Me.DgLavori.TabStop = False
        '
        'Anteprima
        '
        Me.Anteprima.HeaderText = "Anteprima"
        Me.Anteprima.Name = "Anteprima"
        Me.Anteprima.ReadOnly = True
        '
        'Ordine
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Ordine.DefaultCellStyle = DataGridViewCellStyle3
        Me.Ordine.HeaderText = "Ordine"
        Me.Ordine.Name = "Ordine"
        Me.Ordine.ReadOnly = True
        '
        'Prodotto
        '
        Me.Prodotto.HeaderText = "Prodotto"
        Me.Prodotto.Name = "Prodotto"
        Me.Prodotto.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'ColliCaricati
        '
        Me.ColliCaricati.HeaderText = "Colli Caricati"
        Me.ColliCaricati.Name = "ColliCaricati"
        Me.ColliCaricati.ReadOnly = True
        '
        'ColliTotali
        '
        Me.ColliTotali.HeaderText = "Colli Totali"
        Me.ColliTotali.Name = "ColliTotali"
        Me.ColliTotali.ReadOnly = True
        '
        'Prezzo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Prezzo.DefaultCellStyle = DataGridViewCellStyle4
        Me.Prezzo.HeaderText = "Prezzo"
        Me.Prezzo.Name = "Prezzo"
        Me.Prezzo.ReadOnly = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Ordine
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
        Me.lblTipo.Size = New System.Drawing.Size(137, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Consegna Ordini"
        '
        'tmrColli
        '
        Me.tmrColli.Enabled = True
        Me.tmrColli.Interval = 500
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnClose)
        Me.gbPulsanti.Controls.Add(Me.btnSalva)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 500)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(935, 48)
        Me.gbPulsanti.TabIndex = 7
        Me.gbPulsanti.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.AutoSize = True
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderSize = 2
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnClose.Location = New System.Drawing.Point(893, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(36, 36)
        Me.btnClose.TabIndex = 3
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSalva
        '
        Me.btnSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalva.AutoSize = True
        Me.btnSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalva.ForeColor = System.Drawing.Color.White
        Me.btnSalva.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnSalva.Location = New System.Drawing.Point(842, 11)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(34, 34)
        Me.btnSalva.TabIndex = 2
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'frmConsegnaOrdiniRCTF
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(935, 548)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Location = New System.Drawing.Point(30, 30)
        Me.Name = "frmConsegnaOrdiniRCTF"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Former - Consegna Ordini"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents DgLavori As System.Windows.Forms.DataGridView
    Friend WithEvents Anteprima As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Ordine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prodotto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColliCaricati As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColliTotali As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prezzo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmrColli As System.Windows.Forms.Timer
    Friend WithEvents chkEmettiDoc As System.Windows.Forms.CheckBox
    Friend WithEvents btnOkAll As System.Windows.Forms.Button
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents btnUscitoSel As Button
End Class
