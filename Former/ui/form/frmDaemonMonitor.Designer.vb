<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDaemonMonitor
    Inherits baseFormInternaRedim

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDaemonMonitor))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnPrinterServer = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbMain = New System.Windows.Forms.TabPage()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.btnRefreshLog = New System.Windows.Forms.Button()
        Me.DgLog = New Former.ucDataGridView()
        Me.IcoTipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Prio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOrdLista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbMain.SuspendLayout()
        CType(Me.DgLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnPrinterServer)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 530)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnPrinterServer
        '
        Me.btnPrinterServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrinterServer.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnPrinterServer.ForeColor = System.Drawing.Color.Black
        Me.btnPrinterServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrinterServer.ImageKey = "_Aggiorna.png"
        Me.btnPrinterServer.Location = New System.Drawing.Point(6, 16)
        Me.btnPrinterServer.Name = "btnPrinterServer"
        Me.btnPrinterServer.Size = New System.Drawing.Size(120, 25)
        Me.btnPrinterServer.TabIndex = 58
        Me.btnPrinterServer.Text = "Printer Server"
        Me.btnPrinterServer.UseVisualStyleBackColor = False
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
        Me.btnCancel.Location = New System.Drawing.Point(871, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbMain)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 530)
        Me.TabMain.TabIndex = 6
        '
        'tbMain
        '
        Me.tbMain.Controls.Add(Me.btnReset)
        Me.tbMain.Controls.Add(Me.Label1)
        Me.tbMain.Controls.Add(Me.txtCerca)
        Me.tbMain.Controls.Add(Me.btnRefreshLog)
        Me.tbMain.Controls.Add(Me.DgLog)
        Me.tbMain.Location = New System.Drawing.Point(4, 22)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMain.Size = New System.Drawing.Size(947, 504)
        Me.tbMain.TabIndex = 0
        Me.tbMain.Text = "Former - Daemon Monitor"
        Me.tbMain.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(275, 8)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(22, 21)
        Me.btnReset.TabIndex = 60
        Me.btnReset.Text = "X"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Cerca"
        '
        'txtCerca
        '
        Me.txtCerca.Location = New System.Drawing.Point(54, 8)
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(215, 20)
        Me.txtCerca.TabIndex = 58
        '
        'btnRefreshLog
        '
        Me.btnRefreshLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRefreshLog.ForeColor = System.Drawing.Color.Black
        Me.btnRefreshLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefreshLog.ImageKey = "_Aggiorna.png"
        Me.btnRefreshLog.Location = New System.Drawing.Point(821, 6)
        Me.btnRefreshLog.Name = "btnRefreshLog"
        Me.btnRefreshLog.Size = New System.Drawing.Size(120, 25)
        Me.btnRefreshLog.TabIndex = 57
        Me.btnRefreshLog.Text = "Refresh"
        Me.btnRefreshLog.UseVisualStyleBackColor = False
        '
        'DgLog
        '
        Me.DgLog.AllowUserToAddRows = False
        Me.DgLog.AllowUserToDeleteRows = False
        Me.DgLog.AllowUserToOrderColumns = True
        Me.DgLog.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.DgLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgLog.BackgroundColor = System.Drawing.Color.White
        Me.DgLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLog.ColumnHeadersHeight = 20
        Me.DgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IcoTipo, Me.Prio, Me.IdOrdLista, Me.Descrizione})
        Me.DgLog.CustomVirtualMode = True
        Me.DgLog.DataSourceVirtual = Nothing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLog.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLog.EnableHeadersVisualStyles = False
        Me.DgLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLog.Location = New System.Drawing.Point(6, 35)
        Me.DgLog.MultiSelect = False
        Me.DgLog.Name = "DgLog"
        Me.DgLog.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLog.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgLog.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLog.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgLog.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLog.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLog.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLog.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLog.ScrollManuale = False
        Me.DgLog.ScrollValue = 0
        Me.DgLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLog.ShowCellToolTips = False
        Me.DgLog.ShowEditingIcon = False
        Me.DgLog.Size = New System.Drawing.Size(935, 461)
        Me.DgLog.TabIndex = 56
        Me.DgLog.TabStop = False
        '
        'IcoTipo
        '
        Me.IcoTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IcoTipo.DataPropertyName = "IcoTipo"
        Me.IcoTipo.HeaderText = ""
        Me.IcoTipo.Name = "IcoTipo"
        Me.IcoTipo.ReadOnly = True
        Me.IcoTipo.Width = 16
        '
        'Prio
        '
        Me.Prio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Prio.DataPropertyName = "QuandoStr"
        Me.Prio.HeaderText = "Quando"
        Me.Prio.Name = "Prio"
        Me.Prio.ReadOnly = True
        Me.Prio.Width = 150
        '
        'IdOrdLista
        '
        Me.IdOrdLista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IdOrdLista.DataPropertyName = "ServizioStr"
        Me.IdOrdLista.HeaderText = "Servizio"
        Me.IdOrdLista.Name = "IdOrdLista"
        Me.IdOrdLista.ReadOnly = True
        Me.IdOrdLista.Width = 150
        '
        'Descrizione
        '
        Me.Descrizione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Descrizione.DataPropertyName = "Descrizione"
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        Me.Descrizione.Width = 90
        '
        'frmDaemonMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 578)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        
        Me.Name = "frmDaemonMonitor"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Daemon Monitor"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        CType(Me.DgLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbMain As System.Windows.Forms.TabPage
    Friend WithEvents btnReset As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCerca As TextBox
    Friend WithEvents btnRefreshLog As Button
    Friend WithEvents DgLog As ucDataGridView
    Friend WithEvents btnPrinterServer As Button
    Friend WithEvents IcoTipo As DataGridViewImageColumn
    Friend WithEvents Prio As DataGridViewTextBoxColumn
    Friend WithEvents IdOrdLista As DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As DataGridViewTextBoxColumn
End Class
