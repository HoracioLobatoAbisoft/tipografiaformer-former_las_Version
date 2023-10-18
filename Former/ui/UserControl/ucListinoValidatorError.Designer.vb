<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoValidatorError
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
        Me.dgError = New System.Windows.Forms.DataGridView()
        Me.Preventivazione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DimensioniNonCorrette = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.OrientamentoErrato = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.FontIncorporati = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.FontNonIncorporati = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.AbbondanzaErrata = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalva = New System.Windows.Forms.Button()
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgError
        '
        Me.dgError.AllowUserToAddRows = False
        Me.dgError.AllowUserToDeleteRows = False
        Me.dgError.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgError.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgError.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgError.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgError.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgError.BackgroundColor = System.Drawing.Color.White
        Me.dgError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgError.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgError.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgError.ColumnHeadersHeight = 20
        Me.dgError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgError.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Preventivazione, Me.DimensioniNonCorrette, Me.OrientamentoErrato, Me.FontIncorporati, Me.FontNonIncorporati, Me.AbbondanzaErrata})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgError.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgError.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgError.EnableHeadersVisualStyles = False
        Me.dgError.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgError.Location = New System.Drawing.Point(3, 107)
        Me.dgError.MultiSelect = False
        Me.dgError.Name = "dgError"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgError.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgError.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgError.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgError.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgError.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgError.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgError.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgError.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgError.Size = New System.Drawing.Size(970, 481)
        Me.dgError.TabIndex = 59
        Me.dgError.TabStop = False
        '
        'Preventivazione
        '
        Me.Preventivazione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Preventivazione.DataPropertyName = "Descrizione"
        Me.Preventivazione.HeaderText = "Preventivazione"
        Me.Preventivazione.MinimumWidth = 200
        Me.Preventivazione.Name = "Preventivazione"
        Me.Preventivazione.Width = 200
        '
        'DimensioniNonCorrette
        '
        Me.DimensioniNonCorrette.DataPropertyName = "ErrorLevelDimensioniNonCorrette"
        Me.DimensioniNonCorrette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DimensioniNonCorrette.HeaderText = "Dimensioni Non Corrette"
        Me.DimensioniNonCorrette.Name = "DimensioniNonCorrette"
        Me.DimensioniNonCorrette.Width = 149
        '
        'OrientamentoErrato
        '
        Me.OrientamentoErrato.DataPropertyName = "ErrorLevelOrientamentoNonCorretto"
        Me.OrientamentoErrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OrientamentoErrato.HeaderText = "Orientamento Errato"
        Me.OrientamentoErrato.Name = "OrientamentoErrato"
        Me.OrientamentoErrato.Width = 123
        '
        'FontIncorporati
        '
        Me.FontIncorporati.DataPropertyName = "ErrorLevelFontIncorporati"
        Me.FontIncorporati.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FontIncorporati.HeaderText = "Font Incorporati"
        Me.FontIncorporati.Name = "FontIncorporati"
        Me.FontIncorporati.Width = 97
        '
        'FontNonIncorporati
        '
        Me.FontNonIncorporati.DataPropertyName = "ErrorLevelFontNonIncorporati"
        Me.FontNonIncorporati.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FontNonIncorporati.HeaderText = "Font Non Incorporati"
        Me.FontNonIncorporati.Name = "FontNonIncorporati"
        Me.FontNonIncorporati.Width = 123
        '
        'AbbondanzaErrata
        '
        Me.AbbondanzaErrata.DataPropertyName = "ErrorLevelAbbondanzaErrata"
        Me.AbbondanzaErrata.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AbbondanzaErrata.HeaderText = "Abbondanza Errata"
        Me.AbbondanzaErrata.Name = "AbbondanzaErrata"
        Me.AbbondanzaErrata.Width = 116
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggiorna.Image = Global.Former.My.Resources._Aggiorna
        Me.btnAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiorna.Location = New System.Drawing.Point(3, 4)
        Me.btnAggiorna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(91, 33)
        Me.btnAggiorna.TabIndex = 96
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(970, 57)
        Me.GroupBox1.TabIndex = 98
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Default Error Level"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Red
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(581, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 33)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Font Non Incorporati " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ERRORE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(476, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 33)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Font Incorporati INFORMAZIONE"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(708, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 33)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Abbondanza Errata INFORMAZIONE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(193, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 33)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Dimensioni Non Corrette " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ATTENZIONE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(350, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Orientamento Errato" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " ATTENZIONE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSalva
        '
        Me.btnSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalva.BackColor = System.Drawing.Color.White
        Me.btnSalva.FlatAppearance.BorderSize = 0
        Me.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSalva.Image = Global.Former.My.Resources._Save
        Me.btnSalva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalva.Location = New System.Drawing.Point(900, 4)
        Me.btnSalva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(73, 33)
        Me.btnSalva.TabIndex = 99
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalva.UseVisualStyleBackColor = False
        '
        'ucListinoValidatorError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnSalva)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.dgError)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucListinoValidatorError"
        Me.Size = New System.Drawing.Size(976, 591)
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgError As System.Windows.Forms.DataGridView
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents Preventivazione As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DimensioniNonCorrette As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents OrientamentoErrato As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents FontIncorporati As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents FontNonIncorporati As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AbbondanzaErrata As System.Windows.Forms.DataGridViewComboBoxColumn

End Class
