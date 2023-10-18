<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class baseFormInternaRidimensionabile
    Inherits baseFormInterna

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(baseFormInternaRidimensionabile))
        Me.pctMinimize = New System.Windows.Forms.PictureBox()
        Me.pctMove = New System.Windows.Forms.PictureBox()
        Me.pctMaximize = New System.Windows.Forms.PictureBox()
        Me.pctMainBar = New System.Windows.Forms.PictureBox()
        CType(Me.pctMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctMove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctMainBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pctMinimize
        '
        Me.pctMinimize.BackColor = System.Drawing.Color.White
        Me.pctMinimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctMinimize.Image = My.Resources.Resources.minimize
        Me.pctMinimize.Location = New System.Drawing.Point(80, 3)
        Me.pctMinimize.Name = "pctMinimize"
        Me.pctMinimize.Size = New System.Drawing.Size(20, 20)
        Me.pctMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctMinimize.TabIndex = 0
        Me.pctMinimize.TabStop = False
        '
        'pctMove
        '
        Me.pctMove.BackColor = System.Drawing.Color.White
        Me.pctMove.Cursor = System.Windows.Forms.Cursors.NoMove2D
        Me.pctMove.Image = My.Resources.Resources.IcoLogo
        Me.pctMove.Location = New System.Drawing.Point(2, 3)
        Me.pctMove.Name = "pctMove"
        Me.pctMove.Size = New System.Drawing.Size(20, 20)
        Me.pctMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctMove.TabIndex = 2
        Me.pctMove.TabStop = False
        Me.pctMove.Visible = False
        '
        'pctMaximize
        '
        Me.pctMaximize.BackColor = System.Drawing.Color.White
        Me.pctMaximize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctMaximize.Image = My.Resources.Resources.maximize1
        Me.pctMaximize.Location = New System.Drawing.Point(101, 3)
        Me.pctMaximize.Name = "pctMaximize"
        Me.pctMaximize.Size = New System.Drawing.Size(20, 20)
        Me.pctMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctMaximize.TabIndex = 1
        Me.pctMaximize.TabStop = False
        '
        'pctMainBar
        '
        Me.pctMainBar.BackColor = System.Drawing.Color.White
        Me.pctMainBar.Cursor = System.Windows.Forms.Cursors.NoMove2D
        Me.pctMainBar.Image = My.Resources.Resources.MainBarex
        Me.pctMainBar.Location = New System.Drawing.Point(-1, 0)
        Me.pctMainBar.Name = "pctMainBar"
        Me.pctMainBar.Size = New System.Drawing.Size(125, 26)
        Me.pctMainBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctMainBar.TabIndex = 3
        Me.pctMainBar.TabStop = False
        '
        'frmRidimensionabile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.ClientSize = New System.Drawing.Size(902, 351)
        Me.Controls.Add(Me.pctMinimize)
        Me.Controls.Add(Me.pctMove)
        Me.Controls.Add(Me.pctMaximize)
        Me.Controls.Add(Me.pctMainBar)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmRidimensionabile"
        Me.Text = "Former - "
        CType(Me.pctMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctMove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctMainBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pctMinimize As System.Windows.Forms.PictureBox
    Friend WithEvents pctMaximize As System.Windows.Forms.PictureBox
    Friend WithEvents pctMove As System.Windows.Forms.PictureBox
    Friend WithEvents pctMainBar As Windows.Forms.PictureBox
End Class
