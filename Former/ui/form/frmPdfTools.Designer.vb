<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPdfTools
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPdfTools))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lvwAllegati = New System.Windows.Forms.ListView()
        Me.imlFile = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpHelp = New System.Windows.Forms.TabPage()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lnkUnicoFile = New System.Windows.Forms.LinkLabel()
        Me.lnkMergeFile = New System.Windows.Forms.LinkLabel()
        Me.lnkAddFile = New System.Windows.Forms.LinkLabel()
        Me.lnkElimina = New System.Windows.Forms.LinkLabel()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.tpHelp.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 611)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpHelp)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 611)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lnkUnicoFile)
        Me.tbProd.Controls.Add(Me.lnkMergeFile)
        Me.tbProd.Controls.Add(Me.lnkAddFile)
        Me.tbProd.Controls.Add(Me.lnkElimina)
        Me.tbProd.Controls.Add(Me.Label27)
        Me.tbProd.Controls.Add(Me.lvwAllegati)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 585)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - PDF Tools"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(129, 46)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(60, 15)
        Me.Label27.TabIndex = 77
        Me.Label27.Text = "FILE Tools"
        '
        'lvwAllegati
        '
        Me.lvwAllegati.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwAllegati.LargeImageList = Me.imlFile
        Me.lvwAllegati.Location = New System.Drawing.Point(132, 64)
        Me.lvwAllegati.Name = "lvwAllegati"
        Me.lvwAllegati.Size = New System.Drawing.Size(807, 515)
        Me.lvwAllegati.SmallImageList = Me.imlFile
        Me.lvwAllegati.TabIndex = 76
        Me.toolTipHelp.SetToolTip(Me.lvwAllegati, "Elenco degli allegati della mail selezionata")
        Me.lvwAllegati.UseCompatibleStateImageBehavior = False
        Me.lvwAllegati.View = System.Windows.Forms.View.List
        '
        'imlFile
        '
        Me.imlFile.ImageStream = CType(resources.GetObject("imlFile.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlFile.TransparentColor = System.Drawing.Color.Transparent
        Me.imlFile.Images.SetKeyName(0, "_IcoPdfColor.png")
        Me.imlFile.Images.SetKeyName(1, "_IcoZipColor.png")
        Me.imlFile.Images.SetKeyName(2, "_Anteprima.png")
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(84, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "PDF Tools"
        '
        'tpHelp
        '
        Me.tpHelp.Controls.Add(Me.PictureBox1)
        Me.tpHelp.Location = New System.Drawing.Point(4, 22)
        Me.tpHelp.Name = "tpHelp"
        Me.tpHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHelp.Size = New System.Drawing.Size(947, 585)
        Me.tpHelp.TabIndex = 1
        Me.tpHelp.Text = "Help"
        Me.tpHelp.UseVisualStyleBackColor = True
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
        'lnkUnicoFile
        '
        Me.lnkUnicoFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkUnicoFile.Image = Global.Former.My.Resources.Resources._Unico
        Me.lnkUnicoFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkUnicoFile.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkUnicoFile.Location = New System.Drawing.Point(3, 165)
        Me.lnkUnicoFile.Name = "lnkUnicoFile"
        Me.lnkUnicoFile.Size = New System.Drawing.Size(85, 29)
        Me.lnkUnicoFile.TabIndex = 87
        Me.lnkUnicoFile.TabStop = True
        Me.lnkUnicoFile.Text = "Unico file"
        Me.lnkUnicoFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkMergeFile
        '
        Me.lnkMergeFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkMergeFile.Image = Global.Former.My.Resources.Resources._Merge
        Me.lnkMergeFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkMergeFile.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkMergeFile.Location = New System.Drawing.Point(3, 136)
        Me.lnkMergeFile.Name = "lnkMergeFile"
        Me.lnkMergeFile.Size = New System.Drawing.Size(87, 29)
        Me.lnkMergeFile.TabIndex = 87
        Me.lnkMergeFile.TabStop = True
        Me.lnkMergeFile.Text = "Merge file"
        Me.lnkMergeFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAddFile
        '
        Me.lnkAddFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAddFile.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAddFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAddFile.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAddFile.Location = New System.Drawing.Point(3, 64)
        Me.lnkAddFile.Name = "lnkAddFile"
        Me.lnkAddFile.Size = New System.Drawing.Size(101, 29)
        Me.lnkAddFile.TabIndex = 86
        Me.lnkAddFile.TabStop = True
        Me.lnkAddFile.Text = "Aggiungi file"
        Me.lnkAddFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkElimina
        '
        Me.lnkElimina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkElimina.Image = Global.Former.My.Resources.Resources._remove
        Me.lnkElimina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkElimina.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkElimina.Location = New System.Drawing.Point(3, 93)
        Me.lnkElimina.Name = "lnkElimina"
        Me.lnkElimina.Size = New System.Drawing.Size(98, 27)
        Me.lnkElimina.TabIndex = 85
        Me.lnkElimina.TabStop = True
        Me.lnkElimina.Text = "Rimuovi File"
        Me.lnkElimina.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._pdf
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._help
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'frmPdfTools
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 659)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPdfTools"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - PDF Tools"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.tpHelp.ResumeLayout(False)
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents tpHelp As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label27 As Label
    Friend WithEvents lvwAllegati As ListView
    Friend WithEvents lnkAddFile As LinkLabel
    Friend WithEvents lnkElimina As LinkLabel
    Friend WithEvents lnkMergeFile As LinkLabel
    Friend WithEvents imlFile As ImageList
    Friend WithEvents lnkUnicoFile As LinkLabel
End Class
