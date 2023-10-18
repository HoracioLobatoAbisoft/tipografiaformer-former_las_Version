<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrdineNumColli
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
        Me.components = New System.ComponentModel.Container()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbNumColli = New System.Windows.Forms.TabPage()
        Me.UcAnteprimaO = New Former.ucAnteprima()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumColli = New Former.ucNumericTextBox()
        Me.lblOrdine = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbNumColli.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 550)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 49)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(913, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 34)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.Location = New System.Drawing.Point(879, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbNumColli)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 550)
        Me.TabMain.TabIndex = 6
        '
        'tbNumColli
        '
        Me.tbNumColli.Controls.Add(Me.UcAnteprimaO)
        Me.tbNumColli.Controls.Add(Me.Label7)
        Me.tbNumColli.Controls.Add(Me.txtNumColli)
        Me.tbNumColli.Controls.Add(Me.lblOrdine)
        Me.tbNumColli.Controls.Add(Me.pctTipo)
        Me.tbNumColli.Controls.Add(Me.lblTipo)
        Me.tbNumColli.Location = New System.Drawing.Point(4, 22)
        Me.tbNumColli.Name = "tbNumColli"
        Me.tbNumColli.Padding = New System.Windows.Forms.Padding(3)
        Me.tbNumColli.Size = New System.Drawing.Size(947, 524)
        Me.tbNumColli.TabIndex = 0
        Me.tbNumColli.Text = "Former - Inserisci Colli"
        Me.tbNumColli.UseVisualStyleBackColor = True
        '
        'UcAnteprimaO
        '
        Me.UcAnteprimaO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcAnteprimaO.BackColor = System.Drawing.Color.White
        Me.UcAnteprimaO.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAnteprimaO.Location = New System.Drawing.Point(43, 57)
        Me.UcAnteprimaO.Name = "UcAnteprimaO"
        Me.UcAnteprimaO.Size = New System.Drawing.Size(896, 400)
        Me.UcAnteprimaO.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(668, 482)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(201, 21)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Inserire Numero dei Colli"
        '
        'txtNumColli
        '
        Me.txtNumColli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumColli.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.txtNumColli.Location = New System.Drawing.Point(875, 478)
        Me.txtNumColli.MaxLength = 50
        Me.txtNumColli.My_AccettaNegativi = False
        Me.txtNumColli.My_AllowOnlyInteger = False
        Me.txtNumColli.My_DefaultValue = 0
        Me.txtNumColli.My_MaxValue = 1.0E+10!
        Me.txtNumColli.My_MinValue = -1.0E+9!
        Me.txtNumColli.My_ReplaceWithDefaultValue = True
        Me.txtNumColli.Name = "txtNumColli"
        Me.txtNumColli.Size = New System.Drawing.Size(56, 31)
        Me.txtNumColli.TabIndex = 0
        Me.txtNumColli.Text = "0"
        Me.txtNumColli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOrdine
        '
        Me.lblOrdine.AutoSize = True
        Me.lblOrdine.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrdine.Location = New System.Drawing.Point(156, 16)
        Me.lblOrdine.Name = "lblOrdine"
        Me.lblOrdine.Size = New System.Drawing.Size(15, 20)
        Me.lblOrdine.TabIndex = 15
        Me.lblOrdine.Text = "-"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Ordine
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(62, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Ordine"
        '
        'frmOrdineNumColli
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 599)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmOrdineNumColli"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbNumColli.ResumeLayout(False)
        Me.tbNumColli.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbNumColli As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNumColli As ucNumericTextBox
    Friend WithEvents lblOrdine As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents UcAnteprimaO As ucAnteprima
End Class
