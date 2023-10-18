<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMagazzinoOrdini
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
        Me.components = New System.ComponentModel.Container()
        Me.tbMain = New System.Windows.Forms.TabControl()
        Me.tpOrdini = New System.Windows.Forms.TabPage()
        Me.tpRichieste = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoOrdiniAcquisto = New Former.ucMagazzinoOrdiniAcquisto()
        Me.UcMagazzinoRichieste = New Former.ucMagazzinoRichieste()
        Me.tbMain.SuspendLayout()
        Me.tpOrdini.SuspendLayout()
        Me.tpRichieste.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbMain
        '
        Me.tbMain.Controls.Add(Me.tpOrdini)
        Me.tbMain.Controls.Add(Me.tpRichieste)
        Me.tbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbMain.Location = New System.Drawing.Point(0, 0)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.SelectedIndex = 0
        Me.tbMain.Size = New System.Drawing.Size(805, 540)
        Me.tbMain.TabIndex = 0
        '
        'tpOrdini
        '
        Me.tpOrdini.Controls.Add(Me.UcMagazzinoOrdiniAcquisto)
        Me.tpOrdini.Location = New System.Drawing.Point(4, 24)
        Me.tpOrdini.Name = "tpOrdini"
        Me.tpOrdini.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrdini.Size = New System.Drawing.Size(797, 512)
        Me.tpOrdini.TabIndex = 0
        Me.tpOrdini.Text = "Ordini di Acquisto"
        Me.tpOrdini.UseVisualStyleBackColor = True
        '
        'tpRichieste
        '
        Me.tpRichieste.Controls.Add(Me.UcMagazzinoRichieste)
        Me.tpRichieste.Location = New System.Drawing.Point(4, 24)
        Me.tpRichieste.Name = "tpRichieste"
        Me.tpRichieste.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRichieste.Size = New System.Drawing.Size(797, 512)
        Me.tpRichieste.TabIndex = 1
        Me.tpRichieste.Text = "Richieste in sospeso"
        Me.tpRichieste.UseVisualStyleBackColor = True
        '
        'UcMagazzinoOrdiniAcquisto
        '
        Me.UcMagazzinoOrdiniAcquisto.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoOrdiniAcquisto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoOrdiniAcquisto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoOrdiniAcquisto.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoOrdiniAcquisto.Name = "UcMagazzinoOrdiniAcquisto"
        Me.UcMagazzinoOrdiniAcquisto.Size = New System.Drawing.Size(791, 506)
        Me.UcMagazzinoOrdiniAcquisto.TabIndex = 0
        '
        'UcMagazzinoRichieste
        '
        Me.UcMagazzinoRichieste.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoRichieste.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoRichieste.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoRichieste.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoRichieste.Name = "UcMagazzinoRichieste"
        Me.UcMagazzinoRichieste.Size = New System.Drawing.Size(791, 506)
        Me.UcMagazzinoRichieste.TabIndex = 0
        '
        'ucMagazzinoOrdini
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tbMain)
        Me.Name = "ucMagazzinoOrdini"
        Me.Size = New System.Drawing.Size(805, 540)
        Me.tbMain.ResumeLayout(False)
        Me.tpOrdini.ResumeLayout(False)
        Me.tpRichieste.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tbMain As TabControl
    Friend WithEvents tpOrdini As TabPage
    Friend WithEvents tpRichieste As TabPage
    Friend WithEvents UcMagazzinoOrdiniAcquisto As ucMagazzinoOrdiniAcquisto
    Friend WithEvents UcMagazzinoRichieste As ucMagazzinoRichieste
End Class
