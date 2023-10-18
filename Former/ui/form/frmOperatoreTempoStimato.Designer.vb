<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOperatoreTempoStimato
    Inherits baseFormInternaFixed

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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lnkTempo10 = New System.Windows.Forms.LinkLabel()
        Me.lnkTempo9 = New System.Windows.Forms.LinkLabel()
        Me.lnkTempo8 = New System.Windows.Forms.LinkLabel()
        Me.lnkTempo7 = New System.Windows.Forms.LinkLabel()
        Me.lnkTempo6 = New System.Windows.Forms.LinkLabel()
        Me.lnkTempo5 = New System.Windows.Forms.LinkLabel()
        Me.lnkTempo4 = New System.Windows.Forms.LinkLabel()
        Me.lnkTempo3 = New System.Windows.Forms.LinkLabel()
        Me.lnkTempo2 = New System.Windows.Forms.LinkLabel()
        Me.lnkTempo = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTempoStimato = New Former.ucNumericTextBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.btnOk = New System.Windows.Forms.Button()
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
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 263)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(474, 48)
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
        Me.TabMain.Size = New System.Drawing.Size(474, 263)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.lnkTempo10)
        Me.tbProd.Controls.Add(Me.lnkTempo9)
        Me.tbProd.Controls.Add(Me.lnkTempo8)
        Me.tbProd.Controls.Add(Me.lnkTempo7)
        Me.tbProd.Controls.Add(Me.lnkTempo6)
        Me.tbProd.Controls.Add(Me.lnkTempo5)
        Me.tbProd.Controls.Add(Me.lnkTempo4)
        Me.tbProd.Controls.Add(Me.lnkTempo3)
        Me.tbProd.Controls.Add(Me.lnkTempo2)
        Me.tbProd.Controls.Add(Me.lnkTempo)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtTempoStimato)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(466, 237)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Inserisci tempo stimato"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(427, 219)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 15)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "4h"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(382, 219)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "3h"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(336, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 15)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "2h"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(200, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "1h"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(452, 28)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Inserisci un valore manualmente o clicca su uno predefinito in basso"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lnkTempo10
        '
        Me.lnkTempo10.BackColor = System.Drawing.Color.Maroon
        Me.lnkTempo10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo10.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo10.Location = New System.Drawing.Point(420, 190)
        Me.lnkTempo10.Name = "lnkTempo10"
        Me.lnkTempo10.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo10.TabIndex = 27
        Me.lnkTempo10.TabStop = True
        Me.lnkTempo10.Text = "240"
        Me.lnkTempo10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkTempo9
        '
        Me.lnkTempo9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkTempo9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo9.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo9.Location = New System.Drawing.Point(374, 190)
        Me.lnkTempo9.Name = "lnkTempo9"
        Me.lnkTempo9.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo9.TabIndex = 26
        Me.lnkTempo9.TabStop = True
        Me.lnkTempo9.Text = "180"
        Me.lnkTempo9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkTempo8
        '
        Me.lnkTempo8.BackColor = System.Drawing.Color.Red
        Me.lnkTempo8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo8.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo8.Location = New System.Drawing.Point(328, 190)
        Me.lnkTempo8.Name = "lnkTempo8"
        Me.lnkTempo8.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo8.TabIndex = 25
        Me.lnkTempo8.TabStop = True
        Me.lnkTempo8.Text = "120"
        Me.lnkTempo8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkTempo7
        '
        Me.lnkTempo7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lnkTempo7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo7.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo7.Location = New System.Drawing.Point(282, 190)
        Me.lnkTempo7.Name = "lnkTempo7"
        Me.lnkTempo7.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo7.TabIndex = 23
        Me.lnkTempo7.TabStop = True
        Me.lnkTempo7.Text = "90"
        Me.lnkTempo7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkTempo6
        '
        Me.lnkTempo6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkTempo6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo6.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo6.Location = New System.Drawing.Point(236, 190)
        Me.lnkTempo6.Name = "lnkTempo6"
        Me.lnkTempo6.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo6.TabIndex = 22
        Me.lnkTempo6.TabStop = True
        Me.lnkTempo6.Text = "75"
        Me.lnkTempo6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkTempo5
        '
        Me.lnkTempo5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lnkTempo5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo5.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo5.Location = New System.Drawing.Point(190, 190)
        Me.lnkTempo5.Name = "lnkTempo5"
        Me.lnkTempo5.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo5.TabIndex = 21
        Me.lnkTempo5.TabStop = True
        Me.lnkTempo5.Text = "60"
        Me.lnkTempo5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkTempo4
        '
        Me.lnkTempo4.BackColor = System.Drawing.Color.Yellow
        Me.lnkTempo4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo4.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo4.Location = New System.Drawing.Point(144, 190)
        Me.lnkTempo4.Name = "lnkTempo4"
        Me.lnkTempo4.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo4.TabIndex = 20
        Me.lnkTempo4.TabStop = True
        Me.lnkTempo4.Text = "45"
        Me.lnkTempo4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkTempo3
        '
        Me.lnkTempo3.BackColor = System.Drawing.Color.Green
        Me.lnkTempo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo3.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo3.Location = New System.Drawing.Point(98, 190)
        Me.lnkTempo3.Name = "lnkTempo3"
        Me.lnkTempo3.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo3.TabIndex = 19
        Me.lnkTempo3.TabStop = True
        Me.lnkTempo3.Text = "30"
        Me.lnkTempo3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkTempo2
        '
        Me.lnkTempo2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkTempo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo2.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo2.Location = New System.Drawing.Point(52, 190)
        Me.lnkTempo2.Name = "lnkTempo2"
        Me.lnkTempo2.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo2.TabIndex = 18
        Me.lnkTempo2.TabStop = True
        Me.lnkTempo2.Text = "20"
        Me.lnkTempo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkTempo
        '
        Me.lnkTempo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lnkTempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnkTempo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTempo.LinkColor = System.Drawing.Color.Black
        Me.lnkTempo.Location = New System.Drawing.Point(6, 190)
        Me.lnkTempo.Name = "lnkTempo"
        Me.lnkTempo.Size = New System.Drawing.Size(40, 24)
        Me.lnkTempo.TabIndex = 17
        Me.lnkTempo.TabStop = True
        Me.lnkTempo.Text = "10"
        Me.lnkTempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(275, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "minuti"
        '
        'txtTempoStimato
        '
        Me.txtTempoStimato.My_AccettaNegativi = False
        Me.txtTempoStimato.My_DefaultValue = 0
        Me.txtTempoStimato.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTempoStimato.Location = New System.Drawing.Point(187, 84)
        Me.txtTempoStimato.MaxLength = 3
        Me.txtTempoStimato.My_MaxValue = 999.0!
        Me.txtTempoStimato.My_MinValue = 1.0!
        Me.txtTempoStimato.Name = "txtTempoStimato"
        Me.txtTempoStimato.My_AllowOnlyInteger = True
        Me.txtTempoStimato.My_ReplaceWithDefaultValue = True
        Me.txtTempoStimato.Size = New System.Drawing.Size(82, 50)
        Me.txtTempoStimato.TabIndex = 0
        Me.txtTempoStimato.Text = "0"
        Me.txtTempoStimato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(84, 31)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(376, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Inserisci il tempo stimato per questa operazione"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Timer
        Me.pctTipo.Location = New System.Drawing.Point(8, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(61, 61)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(392, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(76, 32)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmOperatoreTempoStimato
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(474, 311)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmOperatoreTempoStimato"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Inserisci tempo stimato"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTempoStimato As ucNumericTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lnkTempo10 As LinkLabel
    Friend WithEvents lnkTempo9 As LinkLabel
    Friend WithEvents lnkTempo8 As LinkLabel
    Friend WithEvents lnkTempo7 As LinkLabel
    Friend WithEvents lnkTempo6 As LinkLabel
    Friend WithEvents lnkTempo5 As LinkLabel
    Friend WithEvents lnkTempo4 As LinkLabel
    Friend WithEvents lnkTempo3 As LinkLabel
    Friend WithEvents lnkTempo2 As LinkLabel
    Friend WithEvents lnkTempo As LinkLabel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
End Class
