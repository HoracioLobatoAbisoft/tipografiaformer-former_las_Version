<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcCm2
    Inherits baseFormInternaFixed

    'Form overrides dispose to clean up the component list.
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtQuantita = New Former.ucNumericTextBox()
        Me.txtLarghezza = New Former.ucNumericTextBox()
        Me.txtAltezza = New Former.ucNumericTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblLatoRif = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblRis = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 328)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(436, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(436, 328)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.txtQuantita)
        Me.tbProd.Controls.Add(Me.txtLarghezza)
        Me.tbProd.Controls.Add(Me.txtAltezza)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.lblLatoRif)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.lblRis)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(428, 302)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Calcolo Centimetri ^2"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(186, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 29)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Orizzontale"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(25, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 15)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Orientamento"
        '
        'txtQuantita
        '
        Me.txtQuantita.My_AccettaNegativi = False
        Me.txtQuantita.My_DefaultValue = 1000
        Me.txtQuantita.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtQuantita.Location = New System.Drawing.Point(211, 206)
        Me.txtQuantita.MaxLength = 6
        Me.txtQuantita.My_MaxValue = 1.0E+10!
        Me.txtQuantita.My_MinValue = 0!
        Me.txtQuantita.Name = "txtQuantita"
        Me.txtQuantita.My_AllowOnlyInteger = True
        Me.txtQuantita.My_ReplaceWithDefaultValue = True
        Me.txtQuantita.Size = New System.Drawing.Size(104, 27)
        Me.txtQuantita.TabIndex = 30
        Me.txtQuantita.Text = "1000"
        Me.txtQuantita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLarghezza
        '
        Me.txtLarghezza.My_AccettaNegativi = False
        Me.txtLarghezza.My_DefaultValue = 0
        Me.txtLarghezza.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtLarghezza.Location = New System.Drawing.Point(211, 171)
        Me.txtLarghezza.MaxLength = 4
        Me.txtLarghezza.My_MaxValue = 1.0E+10!
        Me.txtLarghezza.My_MinValue = 0!
        Me.txtLarghezza.Name = "txtLarghezza"
        Me.txtLarghezza.My_AllowOnlyInteger = True
        Me.txtLarghezza.My_ReplaceWithDefaultValue = True
        Me.txtLarghezza.Size = New System.Drawing.Size(104, 27)
        Me.txtLarghezza.TabIndex = 29
        Me.txtLarghezza.Text = "0"
        Me.txtLarghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAltezza
        '
        Me.txtAltezza.My_AccettaNegativi = False
        Me.txtAltezza.My_DefaultValue = 0
        Me.txtAltezza.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtAltezza.Location = New System.Drawing.Point(211, 136)
        Me.txtAltezza.MaxLength = 4
        Me.txtAltezza.My_MaxValue = 1.0E+10!
        Me.txtAltezza.My_MinValue = 0!
        Me.txtAltezza.Name = "txtAltezza"
        Me.txtAltezza.My_AllowOnlyInteger = True
        Me.txtAltezza.My_ReplaceWithDefaultValue = True
        Me.txtAltezza.Size = New System.Drawing.Size(104, 27)
        Me.txtAltezza.TabIndex = 28
        Me.txtAltezza.Text = "0"
        Me.txtAltezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(321, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 15)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "(mm)"
        '
        'lblLatoRif
        '
        Me.lblLatoRif.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblLatoRif.ForeColor = System.Drawing.Color.Red
        Me.lblLatoRif.Location = New System.Drawing.Point(206, 61)
        Me.lblLatoRif.Name = "lblLatoRif"
        Me.lblLatoRif.Size = New System.Drawing.Size(109, 29)
        Me.lblLatoRif.TabIndex = 26
        Me.lblLatoRif.Text = "0"
        Me.lblLatoRif.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(25, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Lato riferimento Formato Carta"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(321, 211)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 15)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "(pz)"
        '
        'lblRis
        '
        Me.lblRis.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblRis.ForeColor = System.Drawing.Color.Red
        Me.lblRis.Location = New System.Drawing.Point(153, 252)
        Me.lblRis.Name = "lblRis"
        Me.lblRis.Size = New System.Drawing.Size(162, 29)
        Me.lblRis.TabIndex = 21
        Me.lblRis.Text = "0"
        Me.lblRis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(25, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 15)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Cm^2 calcolati"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(25, 211)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Quantità Etichette"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(25, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Larghezza Etichetta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(321, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "(mm)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(321, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "(mm)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(25, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Altezza Etichetta"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(116, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Calcolo Cm^2"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnCancel.Location = New System.Drawing.Point(393, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(32, 32)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.Ruler1
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 37)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'frmCalcCm2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(436, 376)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmCalcCm2"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Calcolo Centimetri ^2"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRis As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtAltezza As ucNumericTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblLatoRif As Label
    Friend WithEvents txtQuantita As ucNumericTextBox
    Friend WithEvents txtLarghezza As ucNumericTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
End Class
