<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucDocumentiFiscaliEditRow
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
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.txtPesoKg = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrezzoKg = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPrezzoUnit = New System.Windows.Forms.TextBox()
        Me.txtPrezzo = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQta = New Former.ucNumericTextBox()
        Me.lblPrezzo = New System.Windows.Forms.Label()
        Me.lblPrezzoUnit = New System.Windows.Forms.Label()
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSalva
        '
        Me.btnSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalva.Location = New System.Drawing.Point(17, 158)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(75, 23)
        Me.btnSalva.TabIndex = 2
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'txtPesoKg
        '
        Me.txtPesoKg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPesoKg.Location = New System.Drawing.Point(94, 124)
        Me.txtPesoKg.MaxLength = 50
        Me.txtPesoKg.Name = "txtPesoKg"
        Me.txtPesoKg.ReadOnly = True
        Me.txtPesoKg.Size = New System.Drawing.Size(58, 23)
        Me.txtPesoKg.TabIndex = 46
        Me.txtPesoKg.TabStop = False
        Me.txtPesoKg.Text = "-"
        Me.txtPesoKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 15)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Peso Kg"
        '
        'txtPrezzoKg
        '
        Me.txtPrezzoKg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrezzoKg.Location = New System.Drawing.Point(94, 95)
        Me.txtPrezzoKg.MaxLength = 50
        Me.txtPrezzoKg.Name = "txtPrezzoKg"
        Me.txtPrezzoKg.ReadOnly = True
        Me.txtPrezzoKg.Size = New System.Drawing.Size(58, 23)
        Me.txtPrezzoKg.TabIndex = 44
        Me.txtPrezzoKg.TabStop = False
        Me.txtPrezzoKg.Text = "-"
        Me.txtPrezzoKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Prezzo Kg"
        '
        'txtPrezzoUnit
        '
        Me.txtPrezzoUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrezzoUnit.Location = New System.Drawing.Point(94, 66)
        Me.txtPrezzoUnit.MaxLength = 50
        Me.txtPrezzoUnit.Name = "txtPrezzoUnit"
        Me.txtPrezzoUnit.ReadOnly = True
        Me.txtPrezzoUnit.Size = New System.Drawing.Size(58, 23)
        Me.txtPrezzoUnit.TabIndex = 37
        Me.txtPrezzoUnit.TabStop = False
        Me.txtPrezzoUnit.Text = "-"
        Me.txtPrezzoUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrezzo
        '
        Me.txtPrezzo.My_AccettaNegativi = False
        Me.txtPrezzo.My_DefaultValue = 0
        Me.txtPrezzo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrezzo.Location = New System.Drawing.Point(94, 37)
        Me.txtPrezzo.MaxLength = 50
        Me.txtPrezzo.My_MaxValue = 1.0E+10!
        Me.txtPrezzo.My_MinValue = 0!
        Me.txtPrezzo.Name = "txtPrezzo"
        Me.txtPrezzo.My_AllowOnlyInteger = False
        Me.txtPrezzo.My_ReplaceWithDefaultValue = True
        Me.txtPrezzo.Size = New System.Drawing.Size(58, 23)
        Me.txtPrezzo.TabIndex = 1
        Me.txtPrezzo.Text = "0"
        Me.txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Quantità"
        '
        'txtQta
        '
        Me.txtQta.My_AccettaNegativi = False
        Me.txtQta.My_DefaultValue = 1
        Me.txtQta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtQta.Location = New System.Drawing.Point(94, 8)
        Me.txtQta.MaxLength = 50
        Me.txtQta.My_MaxValue = 1.0E+10!
        Me.txtQta.My_MinValue = 1.0!
        Me.txtQta.Name = "txtQta"
        Me.txtQta.My_AllowOnlyInteger = True
        Me.txtQta.My_ReplaceWithDefaultValue = True
        Me.txtQta.Size = New System.Drawing.Size(58, 23)
        Me.txtQta.TabIndex = 0
        Me.txtQta.Text = "1"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrezzo
        '
        Me.lblPrezzo.AutoSize = True
        Me.lblPrezzo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPrezzo.ForeColor = System.Drawing.Color.Black
        Me.lblPrezzo.Location = New System.Drawing.Point(3, 40)
        Me.lblPrezzo.Name = "lblPrezzo"
        Me.lblPrezzo.Size = New System.Drawing.Size(39, 15)
        Me.lblPrezzo.TabIndex = 40
        Me.lblPrezzo.Text = "Totale"
        '
        'lblPrezzoUnit
        '
        Me.lblPrezzoUnit.AutoSize = True
        Me.lblPrezzoUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPrezzoUnit.ForeColor = System.Drawing.Color.Black
        Me.lblPrezzoUnit.Location = New System.Drawing.Point(3, 69)
        Me.lblPrezzoUnit.Name = "lblPrezzoUnit"
        Me.lblPrezzoUnit.Size = New System.Drawing.Size(69, 15)
        Me.lblPrezzoUnit.TabIndex = 41
        Me.lblPrezzoUnit.Text = "Prezzo Unit."
        '
        'btnAnnulla
        '
        Me.btnAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnnulla.Location = New System.Drawing.Point(94, 158)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(75, 23)
        Me.btnAnnulla.TabIndex = 3
        Me.btnAnnulla.Text = "Annulla"
        Me.btnAnnulla.UseVisualStyleBackColor = True
        '
        'ucDocumentiFiscaliEditRow
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnAnnulla)
        Me.Controls.Add(Me.txtPesoKg)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPrezzoKg)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPrezzoUnit)
        Me.Controls.Add(Me.txtPrezzo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtQta)
        Me.Controls.Add(Me.lblPrezzo)
        Me.Controls.Add(Me.lblPrezzoUnit)
        Me.Controls.Add(Me.btnSalva)
        Me.Name = "ucDocumentiFiscaliEditRow"
        Me.Size = New System.Drawing.Size(172, 184)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalva As Button
    Friend WithEvents txtPesoKg As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPrezzoKg As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPrezzoUnit As TextBox
    Friend WithEvents txtPrezzo As ucNumericTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtQta As ucNumericTextBox
    Friend WithEvents lblPrezzo As Label
    Friend WithEvents lblPrezzoUnit As Label
    Friend WithEvents btnAnnulla As Button
End Class
