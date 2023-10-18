<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpzioniTabSec
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dgDati = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTabelle = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.dgDati, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 450)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(932, 58)
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
        Me.btnCancel.Location = New System.Drawing.Point(890, 18)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(932, 450)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnDelete)
        Me.tbProd.Controls.Add(Me.dgDati)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbTabelle)
        Me.tbProd.Controls.Add(Me.Label35)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(924, 424)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Gestione tabelle secondarie"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(752, 42)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(164, 23)
        Me.btnDelete.TabIndex = 19
        Me.btnDelete.Text = "Cancella Riga selezionata"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'dgDati
        '
        Me.dgDati.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDati.Location = New System.Drawing.Point(9, 72)
        Me.dgDati.Name = "dgDati"
        Me.dgDati.Size = New System.Drawing.Size(907, 344)
        Me.dgDati.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 22)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Seleziona Tabella"
        '
        'cmbTabelle
        '
        Me.cmbTabelle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTabelle.FormattingEnabled = True
        Me.cmbTabelle.Location = New System.Drawing.Point(118, 43)
        Me.cmbTabelle.Name = "cmbTabelle"
        Me.cmbTabelle.Size = New System.Drawing.Size(170, 21)
        Me.cmbTabelle.TabIndex = 16
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(310, 18)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(473, 22)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "ATTENZIONE! Modificando queste tabelle si altera il funzionamento del programma"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Database
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
        Me.lblTipo.Size = New System.Drawing.Size(225, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Gestione Tabelle Secondarie"
        '
        'frmOpzioniTabSec
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(932, 508)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmOpzioniTabSec"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.dgDati, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents dgDati As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTabelle As System.Windows.Forms.ComboBox
    Private WithEvents btnDelete As System.Windows.Forms.Button
End Class
