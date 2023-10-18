<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucOperatoreImballaggio
    Inherits ucFormerUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.chkSoloGlsImballo = New System.Windows.Forms.CheckBox()
        Me.btnAvanzaSenzaStampa = New System.Windows.Forms.Button()
        Me.DgImballoEx = New System.Windows.Forms.DataGridView()
        Me.Anteprima = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Imballo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Colli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prodotto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Corriere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.btnStampaEtich = New System.Windows.Forms.Button()
        CType(Me.DgImballoEx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkSoloGlsImballo
        '
        Me.chkSoloGlsImballo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSoloGlsImballo.AutoSize = True
        Me.chkSoloGlsImballo.Location = New System.Drawing.Point(686, 26)
        Me.chkSoloGlsImballo.Name = "chkSoloGlsImballo"
        Me.chkSoloGlsImballo.Size = New System.Drawing.Size(72, 19)
        Me.chkSoloGlsImballo.TabIndex = 140
        Me.chkSoloGlsImballo.Text = "Solo GLS"
        Me.chkSoloGlsImballo.UseVisualStyleBackColor = True
        Me.chkSoloGlsImballo.Visible = False
        '
        'btnAvanzaSenzaStampa
        '
        Me.btnAvanzaSenzaStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAvanzaSenzaStampa.BackColor = System.Drawing.Color.White
        Me.btnAvanzaSenzaStampa.Image = Global.Former.My.Resources.Resources._EtichettaSenza
        Me.btnAvanzaSenzaStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAvanzaSenzaStampa.Location = New System.Drawing.Point(764, 3)
        Me.btnAvanzaSenzaStampa.Name = "btnAvanzaSenzaStampa"
        Me.btnAvanzaSenzaStampa.Size = New System.Drawing.Size(176, 42)
        Me.btnAvanzaSenzaStampa.TabIndex = 139
        Me.btnAvanzaSenzaStampa.Text = "Avanza senza Etichette"
        Me.btnAvanzaSenzaStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolTipHelp.SetToolTip(Me.btnAvanzaSenzaStampa, "Avanza gli ordini senza stampare le etichette di ogni collo")
        Me.btnAvanzaSenzaStampa.UseVisualStyleBackColor = False
        '
        'DgImballoEx
        '
        Me.DgImballoEx.AllowUserToAddRows = False
        Me.DgImballoEx.AllowUserToDeleteRows = False
        Me.DgImballoEx.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DgImballoEx.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DgImballoEx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgImballoEx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DgImballoEx.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgImballoEx.BackgroundColor = System.Drawing.Color.White
        Me.DgImballoEx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgImballoEx.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgImballoEx.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DgImballoEx.ColumnHeadersHeight = 20
        Me.DgImballoEx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgImballoEx.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Anteprima, Me.Imballo, Me.Colli, Me.IdOrd, Me.IdCom, Me.QtaOrd, Me.Prodotto, Me.Cliente, Me.Corriere})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgImballoEx.DefaultCellStyle = DataGridViewCellStyle16
        Me.DgImballoEx.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgImballoEx.EnableHeadersVisualStyles = False
        Me.DgImballoEx.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgImballoEx.Location = New System.Drawing.Point(3, 51)
        Me.DgImballoEx.MultiSelect = False
        Me.DgImballoEx.Name = "DgImballoEx"
        Me.DgImballoEx.ReadOnly = True
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgImballoEx.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.DgImballoEx.RowHeadersVisible = False
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black
        Me.DgImballoEx.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.DgImballoEx.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgImballoEx.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgImballoEx.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgImballoEx.RowTemplate.Height = 40
        Me.DgImballoEx.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgImballoEx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgImballoEx.Size = New System.Drawing.Size(937, 684)
        Me.DgImballoEx.TabIndex = 138
        Me.DgImballoEx.TabStop = False
        '
        'Anteprima
        '
        Me.Anteprima.DataPropertyName = "ImgAnteprima"
        Me.Anteprima.HeaderText = ""
        Me.Anteprima.Name = "Anteprima"
        Me.Anteprima.ReadOnly = True
        Me.Anteprima.Width = 5
        '
        'Imballo
        '
        Me.Imballo.DataPropertyName = "ImgTipoImballo"
        Me.Imballo.HeaderText = "Imballo"
        Me.Imballo.Name = "Imballo"
        Me.Imballo.ReadOnly = True
        Me.Imballo.Width = 52
        '
        'Colli
        '
        Me.Colli.DataPropertyName = "NumeroColliCalcolatiStr"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Colli.DefaultCellStyle = DataGridViewCellStyle12
        Me.Colli.HeaderText = "Colli"
        Me.Colli.Name = "Colli"
        Me.Colli.ReadOnly = True
        Me.Colli.Width = 55
        '
        'IdOrd
        '
        Me.IdOrd.DataPropertyName = "IdOrd"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.IdOrd.DefaultCellStyle = DataGridViewCellStyle13
        Me.IdOrd.HeaderText = "Ordine"
        Me.IdOrd.Name = "IdOrd"
        Me.IdOrd.ReadOnly = True
        Me.IdOrd.Width = 67
        '
        'IdCom
        '
        Me.IdCom.DataPropertyName = "IdCom"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.IdCom.DefaultCellStyle = DataGridViewCellStyle14
        Me.IdCom.HeaderText = "Commessa"
        Me.IdCom.Name = "IdCom"
        Me.IdCom.ReadOnly = True
        Me.IdCom.Width = 90
        '
        'QtaOrd
        '
        Me.QtaOrd.DataPropertyName = "QtaRif"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.QtaOrd.DefaultCellStyle = DataGridViewCellStyle15
        Me.QtaOrd.HeaderText = "Qta"
        Me.QtaOrd.Name = "QtaOrd"
        Me.QtaOrd.ReadOnly = True
        Me.QtaOrd.Width = 50
        '
        'Prodotto
        '
        Me.Prodotto.DataPropertyName = "DescrizioneProdotto"
        Me.Prodotto.HeaderText = "Prodotto"
        Me.Prodotto.Name = "Prodotto"
        Me.Prodotto.ReadOnly = True
        Me.Prodotto.Width = 78
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "DescrizioneCliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 68
        '
        'Corriere
        '
        Me.Corriere.DataPropertyName = "CorriereStr"
        Me.Corriere.HeaderText = "Corriere"
        Me.Corriere.Name = "Corriere"
        Me.Corriere.ReadOnly = True
        Me.Corriere.Width = 73
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.Location = New System.Drawing.Point(3, 3)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(42, 42)
        Me.btnAggiorna.TabIndex = 137
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'btnStampaEtich
        '
        Me.btnStampaEtich.BackColor = System.Drawing.Color.White
        Me.btnStampaEtich.Image = Global.Former.My.Resources.Resources._Etichetta
        Me.btnStampaEtich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampaEtich.Location = New System.Drawing.Point(51, 3)
        Me.btnStampaEtich.Name = "btnStampaEtich"
        Me.btnStampaEtich.Size = New System.Drawing.Size(136, 42)
        Me.btnStampaEtich.TabIndex = 136
        Me.btnStampaEtich.Text = "Etichette Ordine"
        Me.btnStampaEtich.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStampaEtich.UseVisualStyleBackColor = False
        '
        'ucOperatoreImballaggio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.chkSoloGlsImballo)
        Me.Controls.Add(Me.btnAvanzaSenzaStampa)
        Me.Controls.Add(Me.DgImballoEx)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.btnStampaEtich)
        Me.Name = "ucOperatoreImballaggio"
        Me.Size = New System.Drawing.Size(943, 738)
        CType(Me.DgImballoEx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkSoloGlsImballo As CheckBox
    Friend WithEvents btnAvanzaSenzaStampa As Button
    Friend WithEvents DgImballoEx As DataGridView
    Friend WithEvents Anteprima As DataGridViewImageColumn
    Friend WithEvents Imballo As DataGridViewImageColumn
    Friend WithEvents Colli As DataGridViewTextBoxColumn
    Friend WithEvents IdOrd As DataGridViewTextBoxColumn
    Friend WithEvents IdCom As DataGridViewTextBoxColumn
    Friend WithEvents QtaOrd As DataGridViewTextBoxColumn
    Friend WithEvents Prodotto As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents Corriere As DataGridViewTextBoxColumn
    Friend WithEvents btnAggiorna As Button
    Friend WithEvents btnStampaEtich As Button
End Class
