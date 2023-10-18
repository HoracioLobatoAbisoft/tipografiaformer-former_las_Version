<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucContabCostoAmmortamento
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
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.txtPerc = New Former.ucNumericTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAnni = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lnkSalva = New System.Windows.Forms.LinkLabel()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPianoAmmortamentoAttivo = New System.Windows.Forms.TextBox()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(57, 18)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(199, 21)
        Me.lblTipo.TabIndex = 15
        Me.lblTipo.Text = "Piano di Ammortamento"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._ammortamento48
        Me.pctTipo.Location = New System.Drawing.Point(3, 3)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(48, 48)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctTipo.TabIndex = 16
        Me.pctTipo.TabStop = False
        '
        'txtPerc
        '
        Me.txtPerc.My_AccettaNegativi = False
        Me.txtPerc.My_DefaultValue = 100
        Me.txtPerc.Location = New System.Drawing.Point(275, 295)
        Me.txtPerc.MaxLength = 5
        Me.txtPerc.My_MaxValue = 10000.0!
        Me.txtPerc.My_MinValue = 0!
        Me.txtPerc.Name = "txtPerc"
        Me.txtPerc.My_AllowOnlyInteger = True
        Me.txtPerc.My_ReplaceWithDefaultValue = True
        Me.txtPerc.Size = New System.Drawing.Size(58, 23)
        Me.txtPerc.TabIndex = 116
        Me.txtPerc.Text = "100"
        Me.txtPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(130, 298)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 15)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Percentuale da imputare "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(359, 298)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "(default 100%)"
        '
        'txtAnni
        '
        Me.txtAnni.My_AccettaNegativi = False
        Me.txtAnni.My_DefaultValue = 5
        Me.txtAnni.Location = New System.Drawing.Point(275, 324)
        Me.txtAnni.MaxLength = 5
        Me.txtAnni.My_MaxValue = 10000.0!
        Me.txtAnni.My_MinValue = 0!
        Me.txtAnni.Name = "txtAnni"
        Me.txtAnni.My_AllowOnlyInteger = True
        Me.txtAnni.My_ReplaceWithDefaultValue = True
        Me.txtAnni.Size = New System.Drawing.Size(58, 23)
        Me.txtAnni.TabIndex = 119
        Me.txtAnni.Text = "5"
        Me.txtAnni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(130, 327)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 15)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Numero di Anni"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(359, 327)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 15)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "(default 5, compreso quello in corso)"
        '
        'lnkSalva
        '
        Me.lnkSalva.AutoSize = True
        Me.lnkSalva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkSalva.Image = Global.Former.My.Resources.Resources._Save
        Me.lnkSalva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSalva.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSalva.Location = New System.Drawing.Point(628, 364)
        Me.lnkSalva.Name = "lnkSalva"
        Me.lnkSalva.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkSalva.Size = New System.Drawing.Size(64, 27)
        Me.lnkSalva.TabIndex = 121
        Me.lnkSalva.TabStop = True
        Me.lnkSalva.Text = "Salva"
        Me.lnkSalva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDel
        '
        Me.lnkDel.AutoSize = True
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(628, 203)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDel.Size = New System.Drawing.Size(142, 27)
        Me.lnkDel.TabIndex = 122
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Elimina piano attivo"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(58, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(211, 15)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "PIANO DI AMMORTAMENTO ATTIVO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(58, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(198, 15)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "CREA PIANO DI AMMORTAMENTO"
        '
        'txtPianoAmmortamentoAttivo
        '
        Me.txtPianoAmmortamentoAttivo.Location = New System.Drawing.Point(133, 108)
        Me.txtPianoAmmortamentoAttivo.Multiline = True
        Me.txtPianoAmmortamentoAttivo.Name = "txtPianoAmmortamentoAttivo"
        Me.txtPianoAmmortamentoAttivo.ReadOnly = True
        Me.txtPianoAmmortamentoAttivo.Size = New System.Drawing.Size(420, 90)
        Me.txtPianoAmmortamentoAttivo.TabIndex = 125
        '
        'ucContabCostoAmmortamento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.txtPianoAmmortamentoAttivo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lnkDel)
        Me.Controls.Add(Me.lnkSalva)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAnni)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPerc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pctTipo)
        Me.Controls.Add(Me.lblTipo)
        Me.Name = "ucContabCostoAmmortamento"
        Me.Size = New System.Drawing.Size(805, 540)
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pctTipo As PictureBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents txtPerc As ucNumericTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAnni As ucNumericTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lnkSalva As LinkLabel
    Friend WithEvents lnkDel As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPianoAmmortamentoAttivo As TextBox
End Class
