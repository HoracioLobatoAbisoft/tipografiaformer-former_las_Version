<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCommesseStato
    Inherits ucFormerUserControl


    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.chkPreInserito = New System.Windows.Forms.CheckBox()
        Me.chkPronto = New System.Windows.Forms.CheckBox()
        Me.chkFinitCom = New System.Windows.Forms.CheckBox()
        Me.chkFinitProd = New System.Windows.Forms.CheckBox()
        Me.chkCompletata = New System.Windows.Forms.CheckBox()
        Me.chkTutti = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.chkStampa = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkPreInserito
        '
        Me.chkPreInserito.AutoSize = True
        Me.chkPreInserito.Checked = True
        Me.chkPreInserito.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPreInserito.Location = New System.Drawing.Point(55, 3)
        Me.chkPreInserito.Name = "chkPreInserito"
        Me.chkPreInserito.Size = New System.Drawing.Size(77, 18)
        Me.chkPreInserito.TabIndex = 0
        Me.chkPreInserito.Text = "Preinserita"
        Me.chkPreInserito.UseVisualStyleBackColor = True
        '
        'chkPronto
        '
        Me.chkPronto.AutoSize = True
        Me.chkPronto.Location = New System.Drawing.Point(138, 3)
        Me.chkPronto.Name = "chkPronto"
        Me.chkPronto.Size = New System.Drawing.Size(57, 18)
        Me.chkPronto.TabIndex = 1
        Me.chkPronto.Text = "Pronta"
        Me.chkPronto.UseVisualStyleBackColor = True
        '
        'chkFinitCom
        '
        Me.chkFinitCom.AutoSize = True
        Me.chkFinitCom.Location = New System.Drawing.Point(269, 3)
        Me.chkFinitCom.Name = "chkFinitCom"
        Me.chkFinitCom.Size = New System.Drawing.Size(132, 18)
        Me.chkFinitCom.TabIndex = 2
        Me.chkFinitCom.Text = "Finitura su Commessa"
        Me.chkFinitCom.UseVisualStyleBackColor = True
        '
        'chkFinitProd
        '
        Me.chkFinitProd.AutoSize = True
        Me.chkFinitProd.Location = New System.Drawing.Point(407, 3)
        Me.chkFinitProd.Name = "chkFinitProd"
        Me.chkFinitProd.Size = New System.Drawing.Size(115, 18)
        Me.chkFinitProd.TabIndex = 3
        Me.chkFinitProd.Text = "Finitura su Prodotti"
        Me.chkFinitProd.UseVisualStyleBackColor = True
        '
        'chkCompletata
        '
        Me.chkCompletata.AutoSize = True
        Me.chkCompletata.Location = New System.Drawing.Point(528, 3)
        Me.chkCompletata.Name = "chkCompletata"
        Me.chkCompletata.Size = New System.Drawing.Size(79, 18)
        Me.chkCompletata.TabIndex = 4
        Me.chkCompletata.Text = "Completata"
        Me.chkCompletata.UseVisualStyleBackColor = False
        '
        'chkTutti
        '
        Me.chkTutti.AutoSize = True
        Me.chkTutti.Location = New System.Drawing.Point(3, 3)
        Me.chkTutti.Name = "chkTutti"
        Me.chkTutti.Size = New System.Drawing.Size(46, 18)
        Me.chkTutti.TabIndex = 9
        Me.chkTutti.Text = "Tutti"
        Me.chkTutti.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel
        '
        Me.FlowLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel.Controls.Add(Me.chkTutti)
        Me.FlowLayoutPanel.Controls.Add(Me.chkPreInserito)
        Me.FlowLayoutPanel.Controls.Add(Me.chkPronto)
        Me.FlowLayoutPanel.Controls.Add(Me.chkStampa)
        Me.FlowLayoutPanel.Controls.Add(Me.chkFinitCom)
        Me.FlowLayoutPanel.Controls.Add(Me.chkFinitProd)
        Me.FlowLayoutPanel.Controls.Add(Me.chkCompletata)
        Me.FlowLayoutPanel.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
        Me.FlowLayoutPanel.Size = New System.Drawing.Size(613, 25)
        Me.FlowLayoutPanel.TabIndex = 10
        '
        'chkStampa
        '
        Me.chkStampa.AutoSize = True
        Me.chkStampa.Location = New System.Drawing.Point(201, 3)
        Me.chkStampa.Name = "chkStampa"
        Me.chkStampa.Size = New System.Drawing.Size(62, 18)
        Me.chkStampa.TabIndex = 10
        Me.chkStampa.Text = "Stampa"
        Me.chkStampa.UseVisualStyleBackColor = True
        '
        'ucStatoCommesse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.FlowLayoutPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Name = "ucStatoCommesse"
        Me.Size = New System.Drawing.Size(618, 28)
        Me.FlowLayoutPanel.ResumeLayout(False)
        Me.FlowLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkPreInserito As System.Windows.Forms.CheckBox
    Friend WithEvents chkPronto As System.Windows.Forms.CheckBox
    Friend WithEvents chkFinitCom As System.Windows.Forms.CheckBox
    Friend WithEvents chkFinitProd As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompletata As System.Windows.Forms.CheckBox
    Friend WithEvents chkTutti As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents chkStampa As System.Windows.Forms.CheckBox

End Class
