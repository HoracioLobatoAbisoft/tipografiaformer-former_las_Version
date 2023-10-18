<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucComboRubrica
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
        Me.mainCombo = New Telerik.WinControls.UI.RadDropDownList()
        Me.pctRefresh = New System.Windows.Forms.PictureBox()
        CType(Me.mainCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainCombo
        '
        Me.mainCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainCombo.AutoScroll = True
        Me.mainCombo.AutoSize = False
        Me.mainCombo.EnableAlternatingItemColor = True
        Me.mainCombo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mainCombo.Location = New System.Drawing.Point(0, 0)
        Me.mainCombo.Name = "mainCombo"
        Me.mainCombo.Size = New System.Drawing.Size(474, 25)
        Me.mainCombo.TabIndex = 0
        Me.mainCombo.Text = "RadDropDownList1"
        '
        'pctRefresh
        '
        Me.pctRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctRefresh.BackColor = System.Drawing.Color.White
        Me.pctRefresh.Image = Global.Former.My.Resources.Resources._RefreshCombo
        Me.pctRefresh.Location = New System.Drawing.Point(475, 0)
        Me.pctRefresh.Name = "pctRefresh"
        Me.pctRefresh.Size = New System.Drawing.Size(25, 25)
        Me.pctRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctRefresh.TabIndex = 1
        Me.pctRefresh.TabStop = False
        '
        'ucComboRubrica
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.pctRefresh)
        Me.Controls.Add(Me.mainCombo)
        Me.Name = "ucComboRubrica"
        Me.Size = New System.Drawing.Size(500, 25)
        CType(Me.mainCombo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainCombo As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents pctRefresh As PictureBox
End Class
