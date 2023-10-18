<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnTry = New System.Windows.Forms.Button()
        Me.rdoWeb = New System.Windows.Forms.RadioButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.rdoLocalHost = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPerc = New TextBox
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblColSfondo = New System.Windows.Forms.Label()
        Me.lblColPrimoPiano = New System.Windows.Forms.Label()
        Me.btnReOpen = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnTry
        '
        Me.btnTry.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnTry.Font = New System.Drawing.Font("Arial", 20.0!)
        Me.btnTry.ForeColor = System.Drawing.Color.White
        Me.btnTry.Location = New System.Drawing.Point(174, 48)
        Me.btnTry.Name = "btnTry"
        Me.btnTry.Size = New System.Drawing.Size(306, 80)
        Me.btnTry.TabIndex = 0
        Me.btnTry.Text = "Genera Listino"
        Me.btnTry.UseVisualStyleBackColor = False
        '
        'rdoWeb
        '
        Me.rdoWeb.AutoSize = True
        Me.rdoWeb.Location = New System.Drawing.Point(22, 32)
        Me.rdoWeb.Name = "rdoWeb"
        Me.rdoWeb.Size = New System.Drawing.Size(310, 19)
        Me.rdoWeb.TabIndex = 0
        Me.rdoWeb.Text = "Immagini dal sito web (http://www.tipografiaformer.it)"
        Me.rdoWeb.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(670, 344)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnReOpen)
        Me.TabPage1.Controls.Add(Me.btnTry)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(662, 316)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Genera Listino"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblColPrimoPiano)
        Me.TabPage2.Controls.Add(Me.lblColSfondo)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtPerc)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.rdoLocalHost)
        Me.TabPage2.Controls.Add(Me.rdoWeb)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(662, 316)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Opzioni"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'rdoLocalHost
        '
        Me.rdoLocalHost.AutoSize = True
        Me.rdoLocalHost.Checked = True
        Me.rdoLocalHost.Location = New System.Drawing.Point(386, 32)
        Me.rdoLocalHost.Name = "rdoLocalHost"
        Me.rdoLocalHost.Size = New System.Drawing.Size(246, 19)
        Me.rdoLocalHost.TabIndex = 1
        Me.rdoLocalHost.TabStop = True
        Me.rdoLocalHost.Text = "Immagini dal sito locale (http://localhost)"
        Me.rdoLocalHost.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "% di ricarico"
        '
        'txtPerc
        '
        Me.txtPerc.Location = New System.Drawing.Point(99, 80)
        Me.txtPerc.MaxLength = 3
        Me.txtPerc.Name = "txtPerc"
        Me.txtPerc.Size = New System.Drawing.Size(57, 21)
        Me.txtPerc.TabIndex = 4
        Me.txtPerc.Text = "40"
        Me.txtPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Colore di sfondo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Colore in primo piano"
        '
        'lblColSfondo
        '
        Me.lblColSfondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblColSfondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColSfondo.ForeColor = System.Drawing.Color.Gray
        Me.lblColSfondo.Location = New System.Drawing.Point(170, 128)
        Me.lblColSfondo.Name = "lblColSfondo"
        Me.lblColSfondo.Size = New System.Drawing.Size(100, 20)
        Me.lblColSfondo.TabIndex = 7
        '
        'lblColPrimoPiano
        '
        Me.lblColPrimoPiano.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColPrimoPiano.ForeColor = System.Drawing.Color.Gray
        Me.lblColPrimoPiano.Location = New System.Drawing.Point(170, 166)
        Me.lblColPrimoPiano.Name = "lblColPrimoPiano"
        Me.lblColPrimoPiano.Size = New System.Drawing.Size(100, 20)
        Me.lblColPrimoPiano.TabIndex = 8
        '
        'btnReOpen
        '
        Me.btnReOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnReOpen.Font = New System.Drawing.Font("Arial", 20.0!)
        Me.btnReOpen.ForeColor = System.Drawing.Color.Black
        Me.btnReOpen.Location = New System.Drawing.Point(174, 166)
        Me.btnReOpen.Name = "btnReOpen"
        Me.btnReOpen.Size = New System.Drawing.Size(306, 80)
        Me.btnReOpen.TabIndex = 1
        Me.btnReOpen.Text = "Riapri Ultimo"
        Me.btnReOpen.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 344)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Former Listino PDF"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnTry As Button
    Friend WithEvents rdoWeb As RadioButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents rdoLocalHost As RadioButton
    Friend WithEvents lblColPrimoPiano As Label
    Friend WithEvents lblColSfondo As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPerc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dlgColor As ColorDialog
    Friend WithEvents btnReOpen As Button
End Class
