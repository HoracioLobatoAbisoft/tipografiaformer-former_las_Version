Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucAmministrazioneStep
    Inherits ucFormerUserControl

    Friend WithEvents lnkDel As LinkLabel

    Friend WithEvents lnkEdit As LinkLabel

    Friend WithEvents dgStep As DataGridView

    Friend WithEvents lnkRefresh As LinkLabel
    Friend WithEvents lnkNew As LinkLabel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()

    End Sub

    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgStep = New System.Windows.Forms.DataGridView()
        Me.RiferitaA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.lnkEdit = New System.Windows.Forms.LinkLabel()
        Me.lnkRefresh = New System.Windows.Forms.LinkLabel()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.lnkSpostaSu = New System.Windows.Forms.LinkLabel()
        Me.lnkSpostaGiu = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        CType(Me.dgStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgStep
        '
        Me.dgStep.AllowUserToAddRows = False
        Me.dgStep.AllowUserToDeleteRows = False
        Me.dgStep.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgStep.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgStep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgStep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgStep.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgStep.BackgroundColor = System.Drawing.Color.White
        Me.dgStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgStep.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStep.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgStep.ColumnHeadersHeight = 20
        Me.dgStep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgStep.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RiferitaA, Me.Img, Me.Nome, Me.Descrizione})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStep.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgStep.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgStep.EnableHeadersVisualStyles = False
        Me.dgStep.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgStep.Location = New System.Drawing.Point(109, 61)
        Me.dgStep.MultiSelect = False
        Me.dgStep.Name = "dgStep"
        Me.dgStep.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStep.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgStep.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.dgStep.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgStep.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgStep.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgStep.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgStep.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgStep.Size = New System.Drawing.Size(784, 547)
        Me.dgStep.TabIndex = 93
        Me.dgStep.TabStop = False
        '
        'RiferitaA
        '
        Me.RiferitaA.DataPropertyName = "Ordine"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiferitaA.DefaultCellStyle = DataGridViewCellStyle3
        Me.RiferitaA.HeaderText = "Ordine"
        Me.RiferitaA.Name = "RiferitaA"
        Me.RiferitaA.ReadOnly = True
        Me.RiferitaA.Width = 68
        '
        'Img
        '
        Me.Img.DataPropertyName = "ImgThumb"
        Me.Img.HeaderText = "Img"
        Me.Img.Name = "Img"
        Me.Img.ReadOnly = True
        Me.Img.Width = 33
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Titolo"
        Me.Nome.HeaderText = "Titolo"
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 61
        '
        'Descrizione
        '
        Me.Descrizione.DataPropertyName = "Testo"
        Me.Descrizione.HeaderText = "Testo"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        Me.Descrizione.Width = 61
        '
        'lnkDel
        '
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(3, 170)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Size = New System.Drawing.Size(82, 32)
        Me.lnkDel.TabIndex = 95
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Rimuovi"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkEdit
        '
        Me.lnkEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkEdit.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkEdit.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkEdit.Location = New System.Drawing.Point(3, 138)
        Me.lnkEdit.Name = "lnkEdit"
        Me.lnkEdit.Size = New System.Drawing.Size(82, 32)
        Me.lnkEdit.TabIndex = 94
        Me.lnkEdit.TabStop = True
        Me.lnkEdit.Text = "Modifica"
        Me.lnkEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkRefresh
        '
        Me.lnkRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRefresh.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRefresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRefresh.Location = New System.Drawing.Point(3, 61)
        Me.lnkRefresh.Name = "lnkRefresh"
        Me.lnkRefresh.Size = New System.Drawing.Size(87, 27)
        Me.lnkRefresh.TabIndex = 91
        Me.lnkRefresh.TabStop = True
        Me.lnkRefresh.Text = "Aggiorna"
        Me.lnkRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(3, 111)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(100, 27)
        Me.lnkNew.TabIndex = 92
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo Step"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkSpostaSu
        '
        Me.lnkSpostaSu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkSpostaSu.Image = Global.Former.My.Resources.Resources._Su
        Me.lnkSpostaSu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSpostaSu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSpostaSu.Location = New System.Drawing.Point(3, 230)
        Me.lnkSpostaSu.Name = "lnkSpostaSu"
        Me.lnkSpostaSu.Size = New System.Drawing.Size(93, 37)
        Me.lnkSpostaSu.TabIndex = 103
        Me.lnkSpostaSu.TabStop = True
        Me.lnkSpostaSu.Text = "Sposta Su"
        Me.lnkSpostaSu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkSpostaGiu
        '
        Me.lnkSpostaGiu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkSpostaGiu.Image = Global.Former.My.Resources.Resources._Giu
        Me.lnkSpostaGiu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSpostaGiu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSpostaGiu.Location = New System.Drawing.Point(3, 267)
        Me.lnkSpostaGiu.Name = "lnkSpostaGiu"
        Me.lnkSpostaGiu.Size = New System.Drawing.Size(96, 37)
        Me.lnkSpostaGiu.TabIndex = 104
        Me.lnkSpostaGiu.TabStop = True
        Me.lnkSpostaGiu.Text = "Sposta Giù"
        Me.lnkSpostaGiu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(50, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(537, 17)
        Me.Label5.TabIndex = 106
        Me.Label5.Tag = ""
        Me.Label5.Text = "Elenco degli step da seguire per questa procedura"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.Former.My.Resources.Resources._Step
        Me.PictureBox5.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 105
        Me.PictureBox5.TabStop = False
        '
        'ucAmministrazioneStep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.lnkSpostaSu)
        Me.Controls.Add(Me.lnkSpostaGiu)
        Me.Controls.Add(Me.lnkDel)
        Me.Controls.Add(Me.lnkEdit)
        Me.Controls.Add(Me.dgStep)
        Me.Controls.Add(Me.lnkRefresh)
        Me.Controls.Add(Me.lnkNew)
        Me.Name = "ucAmministrazioneStep"
        Me.Size = New System.Drawing.Size(896, 611)
        CType(Me.dgStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Property IdProcedura As Integer

    Public Sub CaricaDati()

        Using mgr As New StepProcedureDAO

            Dim l As List(Of StepProcedura) = mgr.FindAll(LFM.StepProcedura.Ordine,
                                                          New LUNA.LunaSearchParameter(LFM.StepProcedura.IdProcedura, IdProcedura))
            dgStep.AutoGenerateColumns = False
            dgStep.DataSource = l

        End Using

    End Sub

    Private Sub lnkRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        CaricaDati()
    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        ParentFormEx.Sottofondo()

        Using f As New frmProceduraStep
            If f.Carica(IdProcedura) Then CaricaDati()
        End Using

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub ModificaStep()
        If dgStep.SelectedRows.Count Then
            Dim row As DataGridViewRow = dgStep.SelectedRows(0)
            Dim S As StepProcedura = row.DataBoundItem
            ParentFormEx.Sottofondo()

            Using f As New frmProceduraStep
                If f.Carica(IdProcedura, S.idstep) Then CaricaDati()
            End Using

            ParentFormEx.Sottofondo()
        End If
    End Sub
    Private Sub EliminaStep()
        If dgStep.SelectedRows.Count Then
            Dim row As DataGridViewRow = dgStep.SelectedRows(0)
            Dim P As StepProcedura = row.DataBoundItem

            If MessageBox.Show("Confermi l'eliminazione dello step selezionato?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New StepProcedureDAO
                    mgr.Delete(P.IdStep)
                End Using
                CaricaDati()
            End If

        End If
    End Sub


    Private Sub lnkModFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEdit.LinkClicked
        ModificaStep()
    End Sub

    Private Sub lnkDelFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked
        EliminaStep()
    End Sub

    Private Sub dgStep_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStep.CellContentClick

    End Sub

    Private Sub dgStep_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStep.CellContentDoubleClick

        ModificaStep()

    End Sub
End Class
