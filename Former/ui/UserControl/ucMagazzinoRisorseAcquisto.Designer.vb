<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMagazzinoRisorseAcquisto
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lnkAdd = New System.Windows.Forms.LinkLabel()
        Me.DgLavori = New System.Windows.Forms.DataGridView()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.lblRiassunto = New System.Windows.Forms.Label()
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.AutoSize = True
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(462, 0)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Padding = New System.Windows.Forms.Padding(30, 4, 0, 4)
        Me.lnkStampa.Size = New System.Drawing.Size(77, 23)
        Me.lnkStampa.TabIndex = 58
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAdd
        '
        Me.lnkAdd.AutoSize = True
        Me.lnkAdd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAdd.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAdd.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAdd.Location = New System.Drawing.Point(3, 0)
        Me.lnkAdd.Name = "lnkAdd"
        Me.lnkAdd.Padding = New System.Windows.Forms.Padding(30, 4, 0, 4)
        Me.lnkAdd.Size = New System.Drawing.Size(86, 23)
        Me.lnkAdd.TabIndex = 57
        Me.lnkAdd.TabStop = True
        Me.lnkAdd.Text = "Aggiungi"
        Me.lnkAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgLavori
        '
        Me.DgLavori.AllowUserToAddRows = False
        Me.DgLavori.AllowUserToDeleteRows = False
        Me.DgLavori.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgLavori.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLavori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgLavori.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgLavori.BackgroundColor = System.Drawing.Color.White
        Me.DgLavori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLavori.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavori.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DgLavori.ColumnHeadersHeight = 20
        Me.DgLavori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.DefaultCellStyle = DataGridViewCellStyle8
        Me.DgLavori.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavori.EnableHeadersVisualStyles = False
        Me.DgLavori.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavori.Location = New System.Drawing.Point(0, 26)
        Me.DgLavori.MultiSelect = False
        Me.DgLavori.Name = "DgLavori"
        Me.DgLavori.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DgLavori.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DgLavori.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLavori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavori.Size = New System.Drawing.Size(542, 370)
        Me.DgLavori.TabIndex = 60
        Me.DgLavori.TabStop = False
        '
        'lnkDel
        '
        Me.lnkDel.AutoSize = True
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._remove
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(95, 0)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Padding = New System.Windows.Forms.Padding(30, 4, 0, 4)
        Me.lnkDel.Size = New System.Drawing.Size(81, 23)
        Me.lnkDel.TabIndex = 57
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Rimuovi"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRiassunto
        '
        Me.lblRiassunto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRiassunto.Location = New System.Drawing.Point(0, 399)
        Me.lblRiassunto.Name = "lblRiassunto"
        Me.lblRiassunto.Size = New System.Drawing.Size(542, 18)
        Me.lblRiassunto.TabIndex = 61
        Me.lblRiassunto.Text = "(-)"
        Me.lblRiassunto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucMagazzinoRisorseAcquisto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblRiassunto)
        Me.Controls.Add(Me.DgLavori)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.lnkDel)
        Me.Controls.Add(Me.lnkAdd)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucMagazzinoRisorseAcquisto"
        Me.Size = New System.Drawing.Size(545, 417)
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents DgLavori As System.Windows.Forms.DataGridView
    Friend WithEvents lnkDel As System.Windows.Forms.LinkLabel
    Friend WithEvents lblRiassunto As System.Windows.Forms.Label

End Class
