<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOpenPDF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenPDF))
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbAlarm = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.DirectoryTreeView = New Former.DirectoryTreeView()
        Me.FileListView = New Former.FileListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCurrentPath = New System.Windows.Forms.TextBox()
        Me.lnkUp = New System.Windows.Forms.LinkLabel()
        Me.grpBtn = New System.Windows.Forms.GroupBox()
        Me.chkAnteprima = New System.Windows.Forms.CheckBox()
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.btnConferma = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.RadPreview = New Telerik.WinControls.UI.RadPdfViewer()
        Me.RadPdfViewerNavigator = New Telerik.WinControls.UI.RadPdfViewerNavigator()
        Me.TabControl1.SuspendLayout()
        Me.tbAlarm.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpBtn.SuspendLayout()
        CType(Me.RadPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPdfViewerNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "_pdf.png")
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbAlarm)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ImageList = Me.imlTab
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1209, 766)
        Me.TabControl1.TabIndex = 11
        '
        'tbAlarm
        '
        Me.tbAlarm.Controls.Add(Me.SplitContainer1)
        Me.tbAlarm.ImageKey = "_pdf.png"
        Me.tbAlarm.Location = New System.Drawing.Point(4, 31)
        Me.tbAlarm.Name = "tbAlarm"
        Me.tbAlarm.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAlarm.Size = New System.Drawing.Size(1201, 731)
        Me.tbAlarm.TabIndex = 0
        Me.tbAlarm.Text = "Seleziona file PDF..."
        Me.tbAlarm.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.RadPreview)
        Me.SplitContainer1.Panel2.Controls.Add(Me.RadPdfViewerNavigator)
        Me.SplitContainer1.Size = New System.Drawing.Size(1195, 725)
        Me.SplitContainer1.SplitterDistance = 621
        Me.SplitContainer1.TabIndex = 122
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 36)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DirectoryTreeView)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.FileListView)
        Me.SplitContainer2.Size = New System.Drawing.Size(621, 689)
        Me.SplitContainer2.SplitterDistance = 228
        Me.SplitContainer2.TabIndex = 0
        '
        'DirectoryTreeView
        '
        Me.DirectoryTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DirectoryTreeView.ImageIndex = 0
        Me.DirectoryTreeView.Location = New System.Drawing.Point(0, 0)
        Me.DirectoryTreeView.Name = "DirectoryTreeView"
        Me.DirectoryTreeView.SelectedImageIndex = 0
        Me.DirectoryTreeView.Size = New System.Drawing.Size(228, 689)
        Me.DirectoryTreeView.TabIndex = 0
        '
        'FileListView
        '
        Me.FileListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileListView.HideSelection = False
        Me.FileListView.Location = New System.Drawing.Point(0, 0)
        Me.FileListView.Name = "FileListView"
        Me.FileListView.Size = New System.Drawing.Size(389, 689)
        Me.FileListView.TabIndex = 1
        Me.FileListView.UseCompatibleStateImageBehavior = False
        Me.FileListView.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtCurrentPath)
        Me.Panel1.Controls.Add(Me.lnkUp)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(621, 36)
        Me.Panel1.TabIndex = 1
        '
        'txtCurrentPath
        '
        Me.txtCurrentPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurrentPath.Location = New System.Drawing.Point(37, 8)
        Me.txtCurrentPath.Name = "txtCurrentPath"
        Me.txtCurrentPath.ReadOnly = True
        Me.txtCurrentPath.Size = New System.Drawing.Size(581, 20)
        Me.txtCurrentPath.TabIndex = 1
        '
        'lnkUp
        '
        Me.lnkUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkUp.Image = Global.Former.My.Resources.Resources._Su
        Me.lnkUp.Location = New System.Drawing.Point(7, 6)
        Me.lnkUp.Name = "lnkUp"
        Me.lnkUp.Size = New System.Drawing.Size(24, 24)
        Me.lnkUp.TabIndex = 0
        '
        'grpBtn
        '
        Me.grpBtn.BackColor = System.Drawing.Color.White
        Me.grpBtn.Controls.Add(Me.chkAnteprima)
        Me.grpBtn.Controls.Add(Me.btnAnnulla)
        Me.grpBtn.Controls.Add(Me.btnConferma)
        Me.grpBtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpBtn.ForeColor = System.Drawing.Color.White
        Me.grpBtn.Location = New System.Drawing.Point(0, 766)
        Me.grpBtn.Name = "grpBtn"
        Me.grpBtn.Padding = New System.Windows.Forms.Padding(20)
        Me.grpBtn.Size = New System.Drawing.Size(1209, 51)
        Me.grpBtn.TabIndex = 12
        Me.grpBtn.TabStop = False
        '
        'chkAnteprima
        '
        Me.chkAnteprima.AutoSize = True
        Me.chkAnteprima.ForeColor = System.Drawing.Color.Black
        Me.chkAnteprima.Location = New System.Drawing.Point(12, 21)
        Me.chkAnteprima.Name = "chkAnteprima"
        Me.chkAnteprima.Size = New System.Drawing.Size(215, 19)
        Me.chkAnteprima.TabIndex = 4
        Me.chkAnteprima.Text = "Caricamento anteprima automatico"
        Me.chkAnteprima.UseVisualStyleBackColor = True
        '
        'btnAnnulla
        '
        Me.btnAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnnulla.BackColor = System.Drawing.Color.White
        Me.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnulla.ForeColor = System.Drawing.Color.White
        Me.btnAnnulla.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnAnnulla.Location = New System.Drawing.Point(1171, 12)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(34, 34)
        Me.btnAnnulla.TabIndex = 3
        Me.btnAnnulla.TabStop = False
        Me.btnAnnulla.UseVisualStyleBackColor = False
        '
        'btnConferma
        '
        Me.btnConferma.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConferma.BackColor = System.Drawing.Color.White
        Me.btnConferma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConferma.ForeColor = System.Drawing.Color.White
        Me.btnConferma.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnConferma.Location = New System.Drawing.Point(1127, 12)
        Me.btnConferma.Name = "btnConferma"
        Me.btnConferma.Size = New System.Drawing.Size(34, 34)
        Me.btnConferma.TabIndex = 2
        Me.btnConferma.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.Image = Global.Former.My.Resources.Resources.Conferma
        Me.btnOk.Location = New System.Drawing.Point(4, 20)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.Former.My.Resources.Resources.Annulla
        Me.btnCancel.Location = New System.Drawing.Point(4, 60)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(34, 34)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.TabStop = False
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'RadPreview
        '
        Me.RadPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPreview.Location = New System.Drawing.Point(0, 36)
        Me.RadPreview.Name = "RadPreview"
        Me.RadPreview.Size = New System.Drawing.Size(570, 689)
        Me.RadPreview.TabIndex = 5
        Me.RadPreview.ThemeName = "VisualStudio2012Dark"
        Me.RadPreview.ThumbnailsScaleFactor = 0.15!
        '
        'RadPdfViewerNavigator
        '
        Me.RadPdfViewerNavigator.AssociatedViewer = Me.RadPreview
        Me.RadPdfViewerNavigator.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPdfViewerNavigator.Location = New System.Drawing.Point(0, 0)
        Me.RadPdfViewerNavigator.Name = "RadPdfViewerNavigator"
        Me.RadPdfViewerNavigator.Size = New System.Drawing.Size(570, 36)
        Me.RadPdfViewerNavigator.TabIndex = 4
        Me.RadPdfViewerNavigator.ThemeName = "VisualStudio2012Dark"
        '
        'frmOpenPDF
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnAnnulla
        Me.ClientSize = New System.Drawing.Size(1209, 817)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.grpBtn)
        Me.Name = "frmOpenPDF"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Seleziona file PDF..."
        Me.TabControl1.ResumeLayout(False)
        Me.tbAlarm.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpBtn.ResumeLayout(False)
        Me.grpBtn.PerformLayout()
        CType(Me.RadPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPdfViewerNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbAlarm As System.Windows.Forms.TabPage
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents grpBtn As System.Windows.Forms.GroupBox
    Friend WithEvents btnAnnulla As System.Windows.Forms.Button
    Friend WithEvents btnConferma As System.Windows.Forms.Button
    Friend WithEvents imlTab As ImageList
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents DirectoryTreeView As DirectoryTreeView
    Friend WithEvents FileListView As FileListView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtCurrentPath As TextBox
    Friend WithEvents lnkUp As LinkLabel
    Friend WithEvents chkAnteprima As CheckBox
    Friend WithEvents RadPreview As Telerik.WinControls.UI.RadPdfViewer
    Friend WithEvents RadPdfViewerNavigator As Telerik.WinControls.UI.RadPdfViewerNavigator
End Class
