<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMagazzinoMovimenti
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
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.DgMovimenti = New System.Windows.Forms.DataGridView()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.lnkRicalcola = New System.Windows.Forms.LinkLabel()
        CType(Me.DgMovimenti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Magazzino
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(380, 0)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(134, 37)
        Me.lnkNew.TabIndex = 62
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo Movimento"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkNew.Visible = False
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(520, 0)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 37)
        Me.lnkStampa.TabIndex = 61
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgMovimenti
        '
        Me.DgMovimenti.AllowUserToAddRows = False
        Me.DgMovimenti.AllowUserToDeleteRows = False
        Me.DgMovimenti.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgMovimenti.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgMovimenti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgMovimenti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgMovimenti.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgMovimenti.BackgroundColor = System.Drawing.Color.White
        Me.DgMovimenti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgMovimenti.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMovimenti.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgMovimenti.ColumnHeadersHeight = 20
        Me.DgMovimenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMovimenti.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgMovimenti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgMovimenti.EnableHeadersVisualStyles = False
        Me.DgMovimenti.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgMovimenti.Location = New System.Drawing.Point(6, 40)
        Me.DgMovimenti.MultiSelect = False
        Me.DgMovimenti.Name = "DgMovimenti"
        Me.DgMovimenti.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMovimenti.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgMovimenti.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgMovimenti.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgMovimenti.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgMovimenti.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgMovimenti.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgMovimenti.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMovimenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgMovimenti.Size = New System.Drawing.Size(594, 305)
        Me.DgMovimenti.TabIndex = 60
        Me.DgMovimenti.TabStop = False
        '
        'lnkAll
        '
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(3, 0)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Size = New System.Drawing.Size(101, 37)
        Me.lnkAll.TabIndex = 59
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Mostra tutto"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkRicalcola
        '
        Me.lnkRicalcola.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRicalcola.Image = Global.Former.My.Resources.Resources._Calcolatrice
        Me.lnkRicalcola.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRicalcola.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRicalcola.Location = New System.Drawing.Point(110, 0)
        Me.lnkRicalcola.Name = "lnkRicalcola"
        Me.lnkRicalcola.Size = New System.Drawing.Size(134, 37)
        Me.lnkRicalcola.TabIndex = 63
        Me.lnkRicalcola.TabStop = True
        Me.lnkRicalcola.Text = "Ricalcola Giacenza"
        Me.lnkRicalcola.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucMagazzinoMovimenti
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lnkRicalcola)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.DgMovimenti)
        Me.Controls.Add(Me.lnkAll)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucMagazzinoMovimenti"
        Me.Size = New System.Drawing.Size(605, 348)
        CType(Me.DgMovimenti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents DgMovimenti As System.Windows.Forms.DataGridView
    Friend WithEvents lnkAll As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkRicalcola As LinkLabel
End Class
