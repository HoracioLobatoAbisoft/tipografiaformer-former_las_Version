<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazioneEmailAvviso
    Inherits ucFormerUserControl


    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgEmail = New System.Windows.Forms.DataGridView()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Livello = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titolo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rdoLiv1 = New System.Windows.Forms.RadioButton()
        Me.rdoLiv2 = New System.Windows.Forms.RadioButton()
        Me.rdoLiv3 = New System.Windows.Forms.RadioButton()
        Me.rdoLiv4 = New System.Windows.Forms.RadioButton()
        Me.rdoLivTutti = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbStato = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.lblClienti = New System.Windows.Forms.Label()
        Me.lnkCli = New System.Windows.Forms.LinkLabel()
        Me.lnkNoInvio = New System.Windows.Forms.LinkLabel()
        Me.lnkCoda = New System.Windows.Forms.LinkLabel()
        CType(Me.DgEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgEmail
        '
        Me.DgEmail.AllowUserToAddRows = False
        Me.DgEmail.AllowUserToDeleteRows = False
        Me.DgEmail.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgEmail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgEmail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgEmail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgEmail.BackgroundColor = System.Drawing.Color.White
        Me.DgEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgEmail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgEmail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgEmail.ColumnHeadersHeight = 20
        Me.DgEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgEmail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Data, Me.Livello, Me.Cliente, Me.Stato, Me.Titolo})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgEmail.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgEmail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgEmail.EnableHeadersVisualStyles = False
        Me.DgEmail.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgEmail.Location = New System.Drawing.Point(0, 0)
        Me.DgEmail.MultiSelect = False
        Me.DgEmail.Name = "DgEmail"
        Me.DgEmail.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgEmail.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgEmail.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgEmail.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgEmail.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgEmail.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgEmail.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgEmail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgEmail.Size = New System.Drawing.Size(948, 286)
        Me.DgEmail.TabIndex = 60
        Me.DgEmail.TabStop = False
        '
        'Data
        '
        Me.Data.DataPropertyName = "Quando"
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 55
        '
        'Livello
        '
        Me.Livello.DataPropertyName = "Livello"
        Me.Livello.HeaderText = "Livello"
        Me.Livello.Name = "Livello"
        Me.Livello.ReadOnly = True
        Me.Livello.Width = 65
        '
        'Cliente
        '
        Me.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 68
        '
        'Stato
        '
        Me.Stato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Stato.DataPropertyName = "StatoStr"
        Me.Stato.HeaderText = "Stato"
        Me.Stato.Name = "Stato"
        Me.Stato.ReadOnly = True
        Me.Stato.Width = 58
        '
        'Titolo
        '
        Me.Titolo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Titolo.DataPropertyName = "Titolo"
        Me.Titolo.HeaderText = "Titolo"
        Me.Titolo.Name = "Titolo"
        Me.Titolo.ReadOnly = True
        Me.Titolo.Width = 62
        '
        'rdoLiv1
        '
        Me.rdoLiv1.AutoSize = True
        Me.rdoLiv1.BackColor = System.Drawing.Color.Lime
        Me.rdoLiv1.Location = New System.Drawing.Point(57, 3)
        Me.rdoLiv1.Name = "rdoLiv1"
        Me.rdoLiv1.Size = New System.Drawing.Size(68, 19)
        Me.rdoLiv1.TabIndex = 61
        Me.rdoLiv1.Tag = "1"
        Me.rdoLiv1.Text = "Livello 1"
        Me.rdoLiv1.UseVisualStyleBackColor = False
        '
        'rdoLiv2
        '
        Me.rdoLiv2.AutoSize = True
        Me.rdoLiv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdoLiv2.Location = New System.Drawing.Point(133, 3)
        Me.rdoLiv2.Name = "rdoLiv2"
        Me.rdoLiv2.Size = New System.Drawing.Size(68, 19)
        Me.rdoLiv2.TabIndex = 62
        Me.rdoLiv2.Tag = "2"
        Me.rdoLiv2.Text = "Livello 2"
        Me.rdoLiv2.UseVisualStyleBackColor = False
        '
        'rdoLiv3
        '
        Me.rdoLiv3.AutoSize = True
        Me.rdoLiv3.BackColor = System.Drawing.Color.Red
        Me.rdoLiv3.Location = New System.Drawing.Point(209, 3)
        Me.rdoLiv3.Name = "rdoLiv3"
        Me.rdoLiv3.Size = New System.Drawing.Size(68, 19)
        Me.rdoLiv3.TabIndex = 63
        Me.rdoLiv3.Tag = "3"
        Me.rdoLiv3.Text = "Livello 3"
        Me.rdoLiv3.UseVisualStyleBackColor = False
        '
        'rdoLiv4
        '
        Me.rdoLiv4.AutoSize = True
        Me.rdoLiv4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdoLiv4.ForeColor = System.Drawing.Color.White
        Me.rdoLiv4.Location = New System.Drawing.Point(285, 3)
        Me.rdoLiv4.Name = "rdoLiv4"
        Me.rdoLiv4.Size = New System.Drawing.Size(68, 19)
        Me.rdoLiv4.TabIndex = 64
        Me.rdoLiv4.Tag = "4"
        Me.rdoLiv4.Text = "Livello 4"
        Me.rdoLiv4.UseVisualStyleBackColor = False
        '
        'rdoLivTutti
        '
        Me.rdoLivTutti.AutoSize = True
        Me.rdoLivTutti.Checked = True
        Me.rdoLivTutti.Location = New System.Drawing.Point(3, 3)
        Me.rdoLivTutti.Name = "rdoLivTutti"
        Me.rdoLivTutti.Size = New System.Drawing.Size(50, 19)
        Me.rdoLivTutti.TabIndex = 65
        Me.rdoLivTutti.TabStop = True
        Me.rdoLivTutti.Tag = "0"
        Me.rdoLivTutti.Text = "Tutti"
        Me.rdoLivTutti.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(361, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Stato"
        '
        'cmbStato
        '
        Me.cmbStato.DisplayMember = "Descrizione"
        Me.cmbStato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStato.FormattingEnabled = True
        Me.cmbStato.Location = New System.Drawing.Point(402, 2)
        Me.cmbStato.Name = "cmbStato"
        Me.cmbStato.Size = New System.Drawing.Size(174, 23)
        Me.cmbStato.TabIndex = 69
        Me.cmbStato.ValueMember = "Id"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lnkCli)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbCliente)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblClienti)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lnkNoInvio)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdoLivTutti)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbStato)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdoLiv1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdoLiv2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdoLiv3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lnkCoda)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdoLiv4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgEmail)
        Me.SplitContainer1.Size = New System.Drawing.Size(948, 349)
        Me.SplitContainer1.SplitterDistance = 59
        Me.SplitContainer1.TabIndex = 70
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(57, 28)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(519, 25)
        Me.cmbCliente.TabIndex = 97
        '
        'lblClienti
        '
        Me.lblClienti.AutoSize = True
        Me.lblClienti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblClienti.ForeColor = System.Drawing.Color.Black
        Me.lblClienti.Location = New System.Drawing.Point(7, 33)
        Me.lblClienti.Name = "lblClienti"
        Me.lblClienti.Size = New System.Drawing.Size(44, 15)
        Me.lblClienti.TabIndex = 96
        Me.lblClienti.Text = "Cliente"
        '
        'lnkCli
        '
        Me.lnkCli.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCli.AutoSize = True
        Me.lnkCli.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCli.Image = Global.Former.My.Resources.Resources._Detail
        Me.lnkCli.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCli.LinkColor = System.Drawing.Color.Black
        Me.lnkCli.Location = New System.Drawing.Point(799, 30)
        Me.lnkCli.Name = "lnkCli"
        Me.lnkCli.Padding = New System.Windows.Forms.Padding(28, 6, 0, 6)
        Me.lnkCli.Size = New System.Drawing.Size(123, 27)
        Me.lnkCli.TabIndex = 98
        Me.lnkCli.TabStop = True
        Me.lnkCli.Text = "Dettaglio Cliente"
        Me.lnkCli.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNoInvio
        '
        Me.lnkNoInvio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNoInvio.AutoSize = True
        Me.lnkNoInvio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNoInvio.Image = Global.Former.My.Resources.Resources._CodaTogli
        Me.lnkNoInvio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNoInvio.LinkColor = System.Drawing.Color.Black
        Me.lnkNoInvio.Location = New System.Drawing.Point(632, 3)
        Me.lnkNoInvio.Name = "lnkNoInvio"
        Me.lnkNoInvio.Padding = New System.Windows.Forms.Padding(28, 6, 0, 6)
        Me.lnkNoInvio.Size = New System.Drawing.Size(161, 27)
        Me.lnkNoInvio.TabIndex = 67
        Me.lnkNoInvio.TabStop = True
        Me.lnkNoInvio.Text = "Elimina da coda di invio"
        Me.lnkNoInvio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkCoda
        '
        Me.lnkCoda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCoda.AutoSize = True
        Me.lnkCoda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCoda.Image = Global.Former.My.Resources.Resources._CodaMetti
        Me.lnkCoda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCoda.LinkColor = System.Drawing.Color.Black
        Me.lnkCoda.Location = New System.Drawing.Point(798, 3)
        Me.lnkCoda.Name = "lnkCoda"
        Me.lnkCoda.Padding = New System.Windows.Forms.Padding(28, 6, 0, 6)
        Me.lnkCoda.Size = New System.Drawing.Size(147, 27)
        Me.lnkCoda.TabIndex = 66
        Me.lnkCoda.TabStop = True
        Me.lnkCoda.Text = "Metti In coda di invio"
        Me.lnkCoda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucAmministrazioneEmailAvviso
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucAmministrazioneEmailAvviso"
        Me.Size = New System.Drawing.Size(948, 349)
        CType(Me.DgEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgEmail As System.Windows.Forms.DataGridView
    Friend WithEvents rdoLiv1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLiv2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLiv3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLiv4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLivTutti As System.Windows.Forms.RadioButton
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Livello As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Titolo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkCoda As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNoInvio As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbStato As System.Windows.Forms.ComboBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents lblClienti As System.Windows.Forms.Label
    Friend WithEvents lnkCli As System.Windows.Forms.LinkLabel

End Class
