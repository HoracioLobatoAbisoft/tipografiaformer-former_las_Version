<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListino
    Inherits ucFormerUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucListino))
        Me.tabLav = New System.Windows.Forms.TabControl()
        Me.tpPreventivazione = New System.Windows.Forms.TabPage()
        Me.UcProdottiNew = New Former.ucListinoPreventivazione()
        Me.tpFormatoMacch = New System.Windows.Forms.TabPage()
        Me.UcFormatoMacchina = New Former.ucListinoFormatoMacchina()
        Me.tpFormatoCarta = New System.Windows.Forms.TabPage()
        Me.tpFormato = New System.Windows.Forms.TabPage()
        Me.UcListinoFormatiProdotto = New Former.ucListinoFormatiProdotto()
        Me.tpTipologia = New System.Windows.Forms.TabPage()
        Me.UcTipiCarta = New Former.ucListinoTipiCarta()
        Me.tpColoriStampa = New System.Windows.Forms.TabPage()
        Me.UcColoriStampa = New Former.ucListinoColoriStampa()
        Me.tpLav = New System.Windows.Forms.TabPage()
        Me.UcLavorazioniGest = New Former.ucListinoLavorazioniGestione()
        Me.tpValidatorError = New System.Windows.Forms.TabPage()
        Me.UcListinoValidatorError = New Former.ucListinoValidatorError()
        Me.tpMacchinari = New System.Windows.Forms.TabPage()
        Me.UcMacchinari = New Former.ucListinoMacchinari()
        Me.tpFustelle = New System.Windows.Forms.TabPage()
        Me.UcListinoFustelle = New Former.ucListinoFustelle()
        Me.tpOmaggi = New System.Windows.Forms.TabPage()
        Me.UcListinoOmaggi = New Former.ucListinoOmaggi()
        Me.imlListino = New System.Windows.Forms.ImageList(Me.components)
        Me.tabLav.SuspendLayout()
        Me.tpPreventivazione.SuspendLayout()
        Me.tpFormatoMacch.SuspendLayout()
        Me.tpFormato.SuspendLayout()
        Me.tpTipologia.SuspendLayout()
        Me.tpColoriStampa.SuspendLayout()
        Me.tpLav.SuspendLayout()
        Me.tpValidatorError.SuspendLayout()
        Me.tpMacchinari.SuspendLayout()
        Me.tpFustelle.SuspendLayout()
        Me.tpOmaggi.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabLav
        '
        Me.tabLav.Controls.Add(Me.tpPreventivazione)
        Me.tabLav.Controls.Add(Me.tpFormatoMacch)
        Me.tabLav.Controls.Add(Me.tpFormatoCarta)
        Me.tabLav.Controls.Add(Me.tpFormato)
        Me.tabLav.Controls.Add(Me.tpTipologia)
        Me.tabLav.Controls.Add(Me.tpColoriStampa)
        Me.tabLav.Controls.Add(Me.tpLav)
        Me.tabLav.Controls.Add(Me.tpValidatorError)
        Me.tabLav.Controls.Add(Me.tpMacchinari)
        Me.tabLav.Controls.Add(Me.tpFustelle)
        Me.tabLav.Controls.Add(Me.tpOmaggi)
        Me.tabLav.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabLav.ImageList = Me.imlListino
        Me.tabLav.Location = New System.Drawing.Point(0, 0)
        Me.tabLav.Name = "tabLav"
        Me.tabLav.SelectedIndex = 0
        Me.tabLav.Size = New System.Drawing.Size(1027, 520)
        Me.tabLav.TabIndex = 82
        '
        'tpPreventivazione
        '
        Me.tpPreventivazione.Controls.Add(Me.UcProdottiNew)
        Me.tpPreventivazione.ImageKey = "ico_P.png"
        Me.tpPreventivazione.Location = New System.Drawing.Point(4, 31)
        Me.tpPreventivazione.Name = "tpPreventivazione"
        Me.tpPreventivazione.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPreventivazione.Size = New System.Drawing.Size(1019, 485)
        Me.tpPreventivazione.TabIndex = 4
        Me.tpPreventivazione.Text = "Preventivazione"
        Me.tpPreventivazione.UseVisualStyleBackColor = True
        '
        'UcProdottiNew
        '
        Me.UcProdottiNew.BackColor = System.Drawing.Color.White
        Me.UcProdottiNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcProdottiNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcProdottiNew.Location = New System.Drawing.Point(3, 3)
        Me.UcProdottiNew.Name = "UcProdottiNew"
        Me.UcProdottiNew.Size = New System.Drawing.Size(1013, 479)
        Me.UcProdottiNew.TabIndex = 1
        '
        'tpFormatoMacch
        '
        Me.tpFormatoMacch.Controls.Add(Me.UcFormatoMacchina)
        Me.tpFormatoMacch.ImageKey = "ico_FM.png"
        Me.tpFormatoMacch.Location = New System.Drawing.Point(4, 31)
        Me.tpFormatoMacch.Name = "tpFormatoMacch"
        Me.tpFormatoMacch.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFormatoMacch.Size = New System.Drawing.Size(1019, 485)
        Me.tpFormatoMacch.TabIndex = 6
        Me.tpFormatoMacch.Text = "Formato Carta in Macchina"
        Me.tpFormatoMacch.UseVisualStyleBackColor = True
        '
        'UcFormatoMacchina
        '
        Me.UcFormatoMacchina.BackColor = System.Drawing.Color.White
        Me.UcFormatoMacchina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcFormatoMacchina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcFormatoMacchina.Location = New System.Drawing.Point(3, 3)
        Me.UcFormatoMacchina.Name = "UcFormatoMacchina"
        Me.UcFormatoMacchina.Size = New System.Drawing.Size(1013, 479)
        Me.UcFormatoMacchina.TabIndex = 0
        '
        'tpFormatoCarta
        '
        Me.tpFormatoCarta.ImageKey = "ico_FC_R.png"
        Me.tpFormatoCarta.Location = New System.Drawing.Point(4, 31)
        Me.tpFormatoCarta.Name = "tpFormatoCarta"
        Me.tpFormatoCarta.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFormatoCarta.Size = New System.Drawing.Size(1019, 485)
        Me.tpFormatoCarta.TabIndex = 13
        Me.tpFormatoCarta.Text = "Formato Carta"
        Me.tpFormatoCarta.UseVisualStyleBackColor = True
        '
        'tpFormato
        '
        Me.tpFormato.Controls.Add(Me.UcListinoFormatiProdotto)
        Me.tpFormato.ImageKey = "ico_FP.png"
        Me.tpFormato.Location = New System.Drawing.Point(4, 31)
        Me.tpFormato.Name = "tpFormato"
        Me.tpFormato.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFormato.Size = New System.Drawing.Size(1019, 485)
        Me.tpFormato.TabIndex = 1
        Me.tpFormato.Text = "Formato Prodotto"
        Me.tpFormato.UseVisualStyleBackColor = True
        '
        'UcListinoFormatiProdotto
        '
        Me.UcListinoFormatiProdotto.BackColor = System.Drawing.Color.White
        Me.UcListinoFormatiProdotto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcListinoFormatiProdotto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcListinoFormatiProdotto.Location = New System.Drawing.Point(3, 3)
        Me.UcListinoFormatiProdotto.Name = "UcListinoFormatiProdotto"
        Me.UcListinoFormatiProdotto.Size = New System.Drawing.Size(1013, 479)
        Me.UcListinoFormatiProdotto.TabIndex = 0
        '
        'tpTipologia
        '
        Me.tpTipologia.Controls.Add(Me.UcTipiCarta)
        Me.tpTipologia.ImageKey = "ico_TC.png"
        Me.tpTipologia.Location = New System.Drawing.Point(4, 31)
        Me.tpTipologia.Name = "tpTipologia"
        Me.tpTipologia.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTipologia.Size = New System.Drawing.Size(1019, 485)
        Me.tpTipologia.TabIndex = 2
        Me.tpTipologia.Text = "Tipologia Carta"
        Me.tpTipologia.UseVisualStyleBackColor = True
        '
        'UcTipiCarta
        '
        Me.UcTipiCarta.BackColor = System.Drawing.Color.White
        Me.UcTipiCarta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcTipiCarta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcTipiCarta.Location = New System.Drawing.Point(3, 3)
        Me.UcTipiCarta.Name = "UcTipiCarta"
        Me.UcTipiCarta.Size = New System.Drawing.Size(1013, 479)
        Me.UcTipiCarta.TabIndex = 0
        '
        'tpColoriStampa
        '
        Me.tpColoriStampa.Controls.Add(Me.UcColoriStampa)
        Me.tpColoriStampa.ImageKey = "ico_CS.png"
        Me.tpColoriStampa.Location = New System.Drawing.Point(4, 31)
        Me.tpColoriStampa.Name = "tpColoriStampa"
        Me.tpColoriStampa.Padding = New System.Windows.Forms.Padding(3)
        Me.tpColoriStampa.Size = New System.Drawing.Size(1019, 485)
        Me.tpColoriStampa.TabIndex = 7
        Me.tpColoriStampa.Text = "Colori di Stampa"
        Me.tpColoriStampa.UseVisualStyleBackColor = True
        '
        'UcColoriStampa
        '
        Me.UcColoriStampa.BackColor = System.Drawing.Color.White
        Me.UcColoriStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcColoriStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcColoriStampa.Location = New System.Drawing.Point(3, 3)
        Me.UcColoriStampa.Name = "UcColoriStampa"
        Me.UcColoriStampa.Size = New System.Drawing.Size(1013, 479)
        Me.UcColoriStampa.TabIndex = 0
        '
        'tpLav
        '
        Me.tpLav.Controls.Add(Me.UcLavorazioniGest)
        Me.tpLav.ImageKey = "ico_L.png"
        Me.tpLav.Location = New System.Drawing.Point(4, 31)
        Me.tpLav.Name = "tpLav"
        Me.tpLav.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLav.Size = New System.Drawing.Size(1019, 485)
        Me.tpLav.TabIndex = 0
        Me.tpLav.Text = "Lavorazioni"
        Me.tpLav.UseVisualStyleBackColor = True
        '
        'UcLavorazioniGest
        '
        Me.UcLavorazioniGest.BackColor = System.Drawing.Color.White
        Me.UcLavorazioniGest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcLavorazioniGest.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcLavorazioniGest.Location = New System.Drawing.Point(3, 3)
        Me.UcLavorazioniGest.Name = "UcLavorazioniGest"
        Me.UcLavorazioniGest.Size = New System.Drawing.Size(1013, 479)
        Me.UcLavorazioniGest.TabIndex = 0
        '
        'tpValidatorError
        '
        Me.tpValidatorError.Controls.Add(Me.UcListinoValidatorError)
        Me.tpValidatorError.ImageKey = "ico_VO.png"
        Me.tpValidatorError.Location = New System.Drawing.Point(4, 31)
        Me.tpValidatorError.Name = "tpValidatorError"
        Me.tpValidatorError.Padding = New System.Windows.Forms.Padding(3)
        Me.tpValidatorError.Size = New System.Drawing.Size(1019, 485)
        Me.tpValidatorError.TabIndex = 10
        Me.tpValidatorError.Text = "Validazione Ordini"
        Me.tpValidatorError.UseVisualStyleBackColor = True
        '
        'UcListinoValidatorError
        '
        Me.UcListinoValidatorError.BackColor = System.Drawing.Color.White
        Me.UcListinoValidatorError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcListinoValidatorError.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcListinoValidatorError.Location = New System.Drawing.Point(3, 3)
        Me.UcListinoValidatorError.Name = "UcListinoValidatorError"
        Me.UcListinoValidatorError.Size = New System.Drawing.Size(1013, 479)
        Me.UcListinoValidatorError.TabIndex = 0
        '
        'tpMacchinari
        '
        Me.tpMacchinari.Controls.Add(Me.UcMacchinari)
        Me.tpMacchinari.ImageKey = "ico_M.png"
        Me.tpMacchinari.Location = New System.Drawing.Point(4, 31)
        Me.tpMacchinari.Name = "tpMacchinari"
        Me.tpMacchinari.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMacchinari.Size = New System.Drawing.Size(1019, 485)
        Me.tpMacchinari.TabIndex = 3
        Me.tpMacchinari.Text = "Macchinari"
        Me.tpMacchinari.UseVisualStyleBackColor = True
        '
        'UcMacchinari
        '
        Me.UcMacchinari.BackColor = System.Drawing.Color.White
        Me.UcMacchinari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMacchinari.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMacchinari.Location = New System.Drawing.Point(3, 3)
        Me.UcMacchinari.Name = "UcMacchinari"
        Me.UcMacchinari.Size = New System.Drawing.Size(1013, 479)
        Me.UcMacchinari.TabIndex = 0
        '
        'tpFustelle
        '
        Me.tpFustelle.Controls.Add(Me.UcListinoFustelle)
        Me.tpFustelle.ImageKey = "ico_F.png"
        Me.tpFustelle.Location = New System.Drawing.Point(4, 31)
        Me.tpFustelle.Name = "tpFustelle"
        Me.tpFustelle.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFustelle.Size = New System.Drawing.Size(1019, 485)
        Me.tpFustelle.TabIndex = 8
        Me.tpFustelle.Text = "Fustelle"
        Me.tpFustelle.UseVisualStyleBackColor = True
        '
        'UcListinoFustelle
        '
        Me.UcListinoFustelle.BackColor = System.Drawing.Color.White
        Me.UcListinoFustelle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcListinoFustelle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcListinoFustelle.Location = New System.Drawing.Point(3, 3)
        Me.UcListinoFustelle.Name = "UcListinoFustelle"
        Me.UcListinoFustelle.Size = New System.Drawing.Size(1013, 479)
        Me.UcListinoFustelle.TabIndex = 0
        '
        'tpOmaggi
        '
        Me.tpOmaggi.Controls.Add(Me.UcListinoOmaggi)
        Me.tpOmaggi.ImageKey = "ico_O_R.png"
        Me.tpOmaggi.Location = New System.Drawing.Point(4, 31)
        Me.tpOmaggi.Name = "tpOmaggi"
        Me.tpOmaggi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOmaggi.Size = New System.Drawing.Size(1019, 485)
        Me.tpOmaggi.TabIndex = 11
        Me.tpOmaggi.Text = "Omaggi"
        Me.tpOmaggi.UseVisualStyleBackColor = True
        '
        'UcListinoOmaggi
        '
        Me.UcListinoOmaggi.BackColor = System.Drawing.Color.White
        Me.UcListinoOmaggi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcListinoOmaggi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcListinoOmaggi.Location = New System.Drawing.Point(3, 3)
        Me.UcListinoOmaggi.Name = "UcListinoOmaggi"
        Me.UcListinoOmaggi.Size = New System.Drawing.Size(1013, 479)
        Me.UcListinoOmaggi.TabIndex = 0
        '
        'imlListino
        '
        Me.imlListino.ImageStream = CType(resources.GetObject("imlListino.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlListino.TransparentColor = System.Drawing.Color.Transparent
        Me.imlListino.Images.SetKeyName(0, "ico_FM.png")
        Me.imlListino.Images.SetKeyName(1, "ico_FP.png")
        Me.imlListino.Images.SetKeyName(2, "ico_LB.png")
        Me.imlListino.Images.SetKeyName(3, "ico_P.png")
        Me.imlListino.Images.SetKeyName(4, "ico_CS.png")
        Me.imlListino.Images.SetKeyName(5, "ico_F.png")
        Me.imlListino.Images.SetKeyName(6, "ico_L.png")
        Me.imlListino.Images.SetKeyName(7, "ico_M.png")
        Me.imlListino.Images.SetKeyName(8, "ico_R.png")
        Me.imlListino.Images.SetKeyName(9, "ico_TC.png")
        Me.imlListino.Images.SetKeyName(10, "ico_VO.png")
        Me.imlListino.Images.SetKeyName(11, "ico_O_R.png")
        Me.imlListino.Images.SetKeyName(12, "ico_FC_R.png")
        Me.imlListino.Images.SetKeyName(13, "ico_GV_R.png")
        '
        'ucListino
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tabLav)
        Me.Name = "ucListino"
        Me.Size = New System.Drawing.Size(1027, 520)
        Me.tabLav.ResumeLayout(False)
        Me.tpPreventivazione.ResumeLayout(False)
        Me.tpFormatoMacch.ResumeLayout(False)
        Me.tpFormato.ResumeLayout(False)
        Me.tpTipologia.ResumeLayout(False)
        Me.tpColoriStampa.ResumeLayout(False)
        Me.tpLav.ResumeLayout(False)
        Me.tpValidatorError.ResumeLayout(False)
        Me.tpMacchinari.ResumeLayout(False)
        Me.tpFustelle.ResumeLayout(False)
        Me.tpOmaggi.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabLav As System.Windows.Forms.TabControl
    Friend WithEvents tpPreventivazione As System.Windows.Forms.TabPage
    Friend WithEvents UcProdottiNew As Former.ucListinoPreventivazione
    Friend WithEvents tpFormatoMacch As System.Windows.Forms.TabPage
    Friend WithEvents UcFormatoMacchina As Former.ucListinoFormatoMacchina
    Friend WithEvents tpFormato As System.Windows.Forms.TabPage
    Friend WithEvents UcListinoFormatiProdotto As Former.ucListinoFormatiProdotto
    Friend WithEvents tpTipologia As System.Windows.Forms.TabPage
    Friend WithEvents UcTipiCarta As Former.ucListinoTipiCarta
    Friend WithEvents tpColoriStampa As System.Windows.Forms.TabPage
    Friend WithEvents UcColoriStampa As Former.ucListinoColoriStampa
    Friend WithEvents tpLav As System.Windows.Forms.TabPage
    Friend WithEvents UcLavorazioniGest As Former.ucListinoLavorazioniGestione
    Friend WithEvents tpMacchinari As System.Windows.Forms.TabPage
    Friend WithEvents UcMacchinari As Former.ucListinoMacchinari
    Friend WithEvents tpFustelle As System.Windows.Forms.TabPage
    Friend WithEvents UcListinoFustelle As Former.ucListinoFustelle
    Friend WithEvents tpValidatorError As System.Windows.Forms.TabPage
    Friend WithEvents UcListinoValidatorError As Former.ucListinoValidatorError
    Friend WithEvents imlListino As ImageList
    Friend WithEvents tpOmaggi As TabPage
    Friend WithEvents UcListinoOmaggi As ucListinoOmaggi
    Friend WithEvents tpFormatoCarta As TabPage
End Class
