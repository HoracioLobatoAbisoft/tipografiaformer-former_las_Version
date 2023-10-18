<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarketingHtmlNew
    Inherits baseFormInternaRedim

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
        Me.txtPrefisso = New System.Windows.Forms.TextBox()
        Me.txtSoggetto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSfoglia = New System.Windows.Forms.Button()
        Me.txtSorgente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.dlgScegliTemplate = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.btnDelTemplate = New System.Windows.Forms.Button()
        Me.btnAnteprima = New System.Windows.Forms.Button()
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
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnDelTemplate)
        Me.gbPulsanti.Controls.Add(Me.btnAnteprima)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 229)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(681, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(681, 229)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.txtPrefisso)
        Me.tbProd.Controls.Add(Me.txtSoggetto)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.btnSfoglia)
        Me.tbProd.Controls.Add(Me.txtSorgente)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(673, 203)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Prodotto"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'txtPrefisso
        '
        Me.txtPrefisso.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.txtPrefisso.Location = New System.Drawing.Point(138, 70)
        Me.txtPrefisso.MaxLength = 100
        Me.txtPrefisso.Name = "txtPrefisso"
        Me.txtPrefisso.ReadOnly = True
        Me.txtPrefisso.Size = New System.Drawing.Size(117, 23)
        Me.txtPrefisso.TabIndex = 109
        Me.txtPrefisso.Text = "Tipografiaformer.it - "
        '
        'txtSoggetto
        '
        Me.txtSoggetto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSoggetto.Location = New System.Drawing.Point(261, 70)
        Me.txtSoggetto.MaxLength = 100
        Me.txtSoggetto.Name = "txtSoggetto"
        Me.txtSoggetto.Size = New System.Drawing.Size(333, 23)
        Me.txtSoggetto.TabIndex = 0
        Me.toolTipHelp.SetToolTip(Me.txtSoggetto, "Inserire il soggetto della mail SENZA il prefisso Tipografiaformer.it che è già i" &
        "nserito di default")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(44, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 15)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Soggetto Email"
        '
        'btnSfoglia
        '
        Me.btnSfoglia.Location = New System.Drawing.Point(600, 112)
        Me.btnSfoglia.Name = "btnSfoglia"
        Me.btnSfoglia.Size = New System.Drawing.Size(26, 21)
        Me.btnSfoglia.TabIndex = 1
        Me.btnSfoglia.Text = "..."
        Me.btnSfoglia.UseVisualStyleBackColor = True
        '
        'txtSorgente
        '
        Me.txtSorgente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSorgente.Location = New System.Drawing.Point(138, 112)
        Me.txtSorgente.Name = "txtSorgente"
        Me.txtSorgente.ReadOnly = True
        Me.txtSorgente.Size = New System.Drawing.Size(456, 23)
        Me.txtSorgente.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(44, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "File Sorgente"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(264, 21)
        Me.lblTipo.TabIndex = 48
        Me.lblTipo.Text = "Template Marketing su File HTML"
        '
        'dlgScegliTemplate
        '
        Me.dlgScegliTemplate.Filter = "File HTM|*.htm|File HTML|*.html"
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
        Me.btnCancel.Location = New System.Drawing.Point(639, 17)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 24)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Template
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 49
        Me.pctTipo.TabStop = False
        '
        'btnDelTemplate
        '
        Me.btnDelTemplate.AutoSize = True
        Me.btnDelTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDelTemplate.Enabled = False
        Me.btnDelTemplate.FlatAppearance.BorderSize = 0
        Me.btnDelTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelTemplate.ForeColor = System.Drawing.Color.Black
        Me.btnDelTemplate.Image = Global.Former.My.Resources.Resources._Elimina
        Me.btnDelTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelTemplate.Location = New System.Drawing.Point(164, 12)
        Me.btnDelTemplate.Name = "btnDelTemplate"
        Me.btnDelTemplate.Size = New System.Drawing.Size(86, 34)
        Me.btnDelTemplate.TabIndex = 3
        Me.btnDelTemplate.Text = "Elimina"
        Me.btnDelTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolTipHelp.SetToolTip(Me.btnDelTemplate, "Elimina il template ")
        Me.btnDelTemplate.UseVisualStyleBackColor = True
        '
        'btnAnteprima
        '
        Me.btnAnteprima.AutoSize = True
        Me.btnAnteprima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAnteprima.FlatAppearance.BorderSize = 0
        Me.btnAnteprima.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnteprima.ForeColor = System.Drawing.Color.Black
        Me.btnAnteprima.Image = Global.Former.My.Resources.Resources._Anteprima
        Me.btnAnteprima.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnteprima.Location = New System.Drawing.Point(6, 12)
        Me.btnAnteprima.Name = "btnAnteprima"
        Me.btnAnteprima.Size = New System.Drawing.Size(152, 34)
        Me.btnAnteprima.TabIndex = 2
        Me.btnAnteprima.Text = "Anteprima Template"
        Me.btnAnteprima.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnteprima.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.Location = New System.Drawing.Point(605, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 0
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmMarketingHtmlNew
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(681, 277)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmMarketingHtmlNew"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former -Template Marketing su File Html"
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
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents lblTipo As Label
    Friend WithEvents pctTipo As PictureBox
    Friend WithEvents btnAnteprima As Button
    Friend WithEvents txtSorgente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSfoglia As Button
    Friend WithEvents dlgScegliTemplate As OpenFileDialog
    Friend WithEvents btnDelTemplate As Button
    Friend WithEvents txtPrefisso As TextBox
    Friend WithEvents txtSoggetto As TextBox
    Friend WithEvents Label2 As Label
End Class
