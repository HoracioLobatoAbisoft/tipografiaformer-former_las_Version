<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucListinoOmaggi
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lnkRefresh = New System.Windows.Forms.LinkLabel()
        Me.DgOmaggi = New System.Windows.Forms.DataGridView()
        Me.IcoTipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportoFisso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prodotto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.lnkModifica = New System.Windows.Forms.LinkLabel()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        CType(Me.DgOmaggi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkRefresh
        '
        Me.lnkRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRefresh.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRefresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRefresh.Location = New System.Drawing.Point(3, 6)
        Me.lnkRefresh.Name = "lnkRefresh"
        Me.lnkRefresh.Size = New System.Drawing.Size(85, 27)
        Me.lnkRefresh.TabIndex = 58
        Me.lnkRefresh.TabStop = True
        Me.lnkRefresh.Text = "Aggiorna"
        Me.lnkRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgOmaggi
        '
        Me.DgOmaggi.AllowUserToAddRows = False
        Me.DgOmaggi.AllowUserToDeleteRows = False
        Me.DgOmaggi.AllowUserToOrderColumns = True
        Me.DgOmaggi.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOmaggi.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgOmaggi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgOmaggi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.DgOmaggi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgOmaggi.BackgroundColor = System.Drawing.Color.White
        Me.DgOmaggi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgOmaggi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgOmaggi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgOmaggi.ColumnHeadersHeight = 20
        Me.DgOmaggi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgOmaggi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IcoTipo, Me.Nome, Me.Qta, Me.ImportoFisso, Me.Prodotto})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOmaggi.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgOmaggi.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgOmaggi.EnableHeadersVisualStyles = False
        Me.DgOmaggi.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgOmaggi.Location = New System.Drawing.Point(3, 42)
        Me.DgOmaggi.MultiSelect = False
        Me.DgOmaggi.Name = "DgOmaggi"
        Me.DgOmaggi.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOmaggi.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgOmaggi.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOmaggi.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgOmaggi.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgOmaggi.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgOmaggi.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOmaggi.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOmaggi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgOmaggi.Size = New System.Drawing.Size(1183, 643)
        Me.DgOmaggi.TabIndex = 57
        Me.DgOmaggi.TabStop = False
        '
        'IcoTipo
        '
        Me.IcoTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.IcoTipo.DataPropertyName = "ImgRif"
        Me.IcoTipo.HeaderText = ""
        Me.IcoTipo.Name = "IcoTipo"
        Me.IcoTipo.ReadOnly = True
        Me.IcoTipo.Width = 5
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "NomeOmaggio"
        Me.Nome.HeaderText = "Omaggio"
        Me.Nome.MinimumWidth = 100
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        '
        'Qta
        '
        Me.Qta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Qta.DataPropertyName = "QtaStr"
        Me.Qta.HeaderText = "Qta"
        Me.Qta.Name = "Qta"
        Me.Qta.ReadOnly = True
        Me.Qta.Width = 50
        '
        'ImportoFisso
        '
        Me.ImportoFisso.DataPropertyName = "RiservatoA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ImportoFisso.DefaultCellStyle = DataGridViewCellStyle3
        Me.ImportoFisso.HeaderText = "Riservato A"
        Me.ImportoFisso.MinimumWidth = 100
        Me.ImportoFisso.Name = "ImportoFisso"
        Me.ImportoFisso.ReadOnly = True
        '
        'Prodotto
        '
        Me.Prodotto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Prodotto.DataPropertyName = "CondizioneStr"
        Me.Prodotto.HeaderText = "Condizione"
        Me.Prodotto.MinimumWidth = 100
        Me.Prodotto.Name = "Prodotto"
        Me.Prodotto.ReadOnly = True
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(94, 6)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(85, 27)
        Me.lnkNew.TabIndex = 59
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Aggiungi"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkModifica
        '
        Me.lnkModifica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModifica.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkModifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModifica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModifica.Location = New System.Drawing.Point(185, 6)
        Me.lnkModifica.Name = "lnkModifica"
        Me.lnkModifica.Size = New System.Drawing.Size(80, 27)
        Me.lnkModifica.TabIndex = 60
        Me.lnkModifica.TabStop = True
        Me.lnkModifica.Text = "Modifica"
        Me.lnkModifica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDel
        '
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(271, 6)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Size = New System.Drawing.Size(80, 27)
        Me.lnkDel.TabIndex = 61
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Elimina"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucListinoOmaggi
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkDel)
        Me.Controls.Add(Me.lnkModifica)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.lnkRefresh)
        Me.Controls.Add(Me.DgOmaggi)
        Me.Name = "ucListinoOmaggi"
        Me.Size = New System.Drawing.Size(1189, 688)
        CType(Me.DgOmaggi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lnkRefresh As LinkLabel
    Friend WithEvents DgOmaggi As DataGridView
    Friend WithEvents IcoTipo As DataGridViewImageColumn
    Friend WithEvents Nome As DataGridViewTextBoxColumn
    Friend WithEvents Qta As DataGridViewTextBoxColumn
    Friend WithEvents ImportoFisso As DataGridViewTextBoxColumn
    Friend WithEvents Prodotto As DataGridViewTextBoxColumn
    Friend WithEvents lnkNew As LinkLabel
    Friend WithEvents lnkModifica As LinkLabel
    Friend WithEvents lnkDel As LinkLabel
End Class
