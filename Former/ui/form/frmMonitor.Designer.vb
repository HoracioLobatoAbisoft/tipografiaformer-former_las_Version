<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitor
    Inherits baseFormInternaFixed

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitor))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lnkCaricaTutto = New System.Windows.Forms.LinkLabel()
        Me.lnkCaricaLastYear = New System.Windows.Forms.LinkLabel()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.tmrMess = New System.Windows.Forms.Timer(Me.components)
        Me.UcAllegati = New Former.ucAllegati()
        Me.gbPulsanti.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lnkCaricaTutto)
        Me.gbPulsanti.Controls.Add(Me.lnkCaricaLastYear)
        Me.gbPulsanti.Controls.Add(Me.lnkAggiorna)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 273)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1047, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lnkCaricaTutto
        '
        Me.lnkCaricaTutto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkCaricaTutto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkCaricaTutto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCaricaTutto.Image = Global.Former.My.Resources._Aggiorna
        Me.lnkCaricaTutto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCaricaTutto.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCaricaTutto.Location = New System.Drawing.Point(158, 13)
        Me.lnkCaricaTutto.Name = "lnkCaricaTutto"
        Me.lnkCaricaTutto.Size = New System.Drawing.Size(98, 32)
        Me.lnkCaricaTutto.TabIndex = 8
        Me.lnkCaricaTutto.TabStop = True
        Me.lnkCaricaTutto.Text = "Carica tutto"
        Me.lnkCaricaTutto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkCaricaLastYear
        '
        Me.lnkCaricaLastYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkCaricaLastYear.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkCaricaLastYear.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCaricaLastYear.Image = Global.Former.My.Resources._Aggiorna
        Me.lnkCaricaLastYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCaricaLastYear.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCaricaLastYear.Location = New System.Drawing.Point(12, 13)
        Me.lnkCaricaLastYear.Name = "lnkCaricaLastYear"
        Me.lnkCaricaLastYear.Size = New System.Drawing.Size(140, 32)
        Me.lnkCaricaLastYear.TabIndex = 7
        Me.lnkCaricaLastYear.TabStop = True
        Me.lnkCaricaLastYear.Text = "Carica ultimo anno"
        Me.lnkCaricaLastYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources._Annulla
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(969, 13)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(72, 32)
        Me.lnkAggiorna.TabIndex = 6
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Chiudi"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmrMess
        '
        Me.tmrMess.Enabled = True
        Me.tmrMess.Interval = 60000
        '
        'UcAllegati
        '
        Me.UcAllegati.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcAllegati.BackColor = System.Drawing.Color.White
        Me.UcAllegati.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAllegati.FromOperatore = False
        Me.UcAllegati.Location = New System.Drawing.Point(0, 0)
        Me.UcAllegati.Name = "UcAllegati"
        Me.UcAllegati.Size = New System.Drawing.Size(1047, 273)
        Me.UcAllegati.TabIndex = 6
        '
        'frmMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        
        Me.CancelButton = Me.lnkAggiorna
        Me.ClientSize = New System.Drawing.Size(1047, 321)
        Me.Controls.Add(Me.UcAllegati)
        Me.Controls.Add(Me.gbPulsanti)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        
        Me.KeyPreview = True
        Me.Name = "frmMonitor"
        Me.Text = "Former - Monitor Messaggi"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbPulsanti.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents lnkAggiorna As System.Windows.Forms.LinkLabel
    Friend WithEvents UcAllegati As Former.ucAllegati
    Friend WithEvents tmrMess As System.Windows.Forms.Timer
    Friend WithEvents lnkCaricaTutto As LinkLabel
    Friend WithEvents lnkCaricaLastYear As LinkLabel
End Class
