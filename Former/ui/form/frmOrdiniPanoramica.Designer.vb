<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrdiniPanoramica
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
        Dim CarouselEllipsePath1 As Telerik.WinControls.UI.CarouselEllipsePath = New Telerik.WinControls.UI.CarouselEllipsePath()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdiniPanoramica))
        Me.RadCarousel = New Telerik.WinControls.UI.RadCarousel()
        Me.UcOrdiniAnteprima = New Former.ucOrdiniAnteprima()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lblTotOrd = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbCatProd = New System.Windows.Forms.ComboBox()
        Me.lblRub = New System.Windows.Forms.Label()
        Me.TabRisultati = New System.Windows.Forms.TabControl()
        Me.tpRicercaImmagini = New System.Windows.Forms.TabPage()
        Me.flowPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.tpPanoramica = New System.Windows.Forms.TabPage()
        Me.imlTab24 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.RadCarousel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPulsanti.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        Me.TabRisultati.SuspendLayout()
        Me.tpRicercaImmagini.SuspendLayout()
        Me.tpPanoramica.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadCarousel
        '
        CarouselEllipsePath1.Center = New Telerik.WinControls.UI.Point3D(50.0R, 50.0R, 0R)
        CarouselEllipsePath1.FinalAngle = -100.0R
        CarouselEllipsePath1.InitialAngle = -90.0R
        CarouselEllipsePath1.U = New Telerik.WinControls.UI.Point3D(-20.0R, -17.0R, -50.0R)
        CarouselEllipsePath1.V = New Telerik.WinControls.UI.Point3D(30.0R, -25.0R, -60.0R)
        CarouselEllipsePath1.ZScale = 500.0R
        Me.RadCarousel.CarouselPath = CarouselEllipsePath1
        Me.RadCarousel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadCarousel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCarousel.FormattingEnabled = True
        Me.RadCarousel.Location = New System.Drawing.Point(3, 3)
        Me.RadCarousel.Name = "RadCarousel"
        Me.RadCarousel.NavigationButtonsOffset = New System.Drawing.Size(10, 10)
        Me.RadCarousel.Size = New System.Drawing.Size(666, 416)
        Me.RadCarousel.TabIndex = 6
        Me.RadCarousel.Text = "RadCarousel1"
        Me.RadCarousel.VisibleItemCount = 20
        CType(Me.RadCarousel.GetChildAt(0).GetChildAt(3), Telerik.WinControls.UI.RadRepeatButtonElement).Text = "Precedente"
        CType(Me.RadCarousel.GetChildAt(0).GetChildAt(3), Telerik.WinControls.UI.RadRepeatButtonElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        CType(Me.RadCarousel.GetChildAt(0).GetChildAt(4), Telerik.WinControls.UI.RadRepeatButtonElement).Text = "Prossimo"
        CType(Me.RadCarousel.GetChildAt(0).GetChildAt(4), Telerik.WinControls.UI.RadRepeatButtonElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        '
        'UcOrdiniAnteprima
        '
        Me.UcOrdiniAnteprima.BackColor = System.Drawing.Color.White
        Me.UcOrdiniAnteprima.Dock = System.Windows.Forms.DockStyle.Right
        Me.UcOrdiniAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdiniAnteprima.Location = New System.Drawing.Point(680, 0)
        Me.UcOrdiniAnteprima.Name = "UcOrdiniAnteprima"
        Me.UcOrdiniAnteprima.NascondiResto = False
        Me.UcOrdiniAnteprima.NoLavori = False
        Me.UcOrdiniAnteprima.Size = New System.Drawing.Size(275, 566)
        Me.UcOrdiniAnteprima.TabIndex = 0
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lblTotOrd)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 566)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lblTotOrd
        '
        Me.lblTotOrd.AutoSize = True
        Me.lblTotOrd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotOrd.Location = New System.Drawing.Point(12, 19)
        Me.lblTotOrd.Name = "lblTotOrd"
        Me.lblTotOrd.Size = New System.Drawing.Size(12, 15)
        Me.lblTotOrd.TabIndex = 17
        Me.lblTotOrd.Text = "-"
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
        Me.btnCancel.Location = New System.Drawing.Point(871, 11)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlFilter
        '
        Me.pnlFilter.Controls.Add(Me.lnkCerca)
        Me.pnlFilter.Controls.Add(Me.Label11)
        Me.pnlFilter.Controls.Add(Me.cmbCatProd)
        Me.pnlFilter.Controls.Add(Me.lblRub)
        Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(680, 109)
        Me.pnlFilter.TabIndex = 7
        '
        'lnkCerca
        '
        Me.lnkCerca.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lnkCerca.AutoSize = True
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources.search24
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(296, 79)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkCerca.Size = New System.Drawing.Size(86, 27)
        Me.lnkCerca.TabIndex = 99
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Aggiorna"
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(12, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 15)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "Preventivazione"
        '
        'cmbCatProd
        '
        Me.cmbCatProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCatProd.FormattingEnabled = True
        Me.cmbCatProd.Location = New System.Drawing.Point(108, 48)
        Me.cmbCatProd.Name = "cmbCatProd"
        Me.cmbCatProd.Size = New System.Drawing.Size(565, 21)
        Me.cmbCatProd.TabIndex = 98
        '
        'lblRub
        '
        Me.lblRub.AutoSize = True
        Me.lblRub.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblRub.Location = New System.Drawing.Point(11, 9)
        Me.lblRub.Name = "lblRub"
        Me.lblRub.Size = New System.Drawing.Size(16, 22)
        Me.lblRub.TabIndex = 56
        Me.lblRub.Text = "-"
        '
        'TabRisultati
        '
        Me.TabRisultati.Controls.Add(Me.tpRicercaImmagini)
        Me.TabRisultati.Controls.Add(Me.tpPanoramica)
        Me.TabRisultati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabRisultati.ImageList = Me.imlTab24
        Me.TabRisultati.Location = New System.Drawing.Point(0, 109)
        Me.TabRisultati.Name = "TabRisultati"
        Me.TabRisultati.SelectedIndex = 0
        Me.TabRisultati.Size = New System.Drawing.Size(680, 457)
        Me.TabRisultati.TabIndex = 9
        '
        'tpRicercaImmagini
        '
        Me.tpRicercaImmagini.Controls.Add(Me.flowPanel)
        Me.tpRicercaImmagini.ImageKey = "business_contact-24.png"
        Me.tpRicercaImmagini.Location = New System.Drawing.Point(4, 31)
        Me.tpRicercaImmagini.Name = "tpRicercaImmagini"
        Me.tpRicercaImmagini.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRicercaImmagini.Size = New System.Drawing.Size(672, 422)
        Me.tpRicercaImmagini.TabIndex = 1
        Me.tpRicercaImmagini.Text = "Card"
        Me.tpRicercaImmagini.UseVisualStyleBackColor = True
        '
        'flowPanel
        '
        Me.flowPanel.AutoScroll = True
        Me.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowPanel.Location = New System.Drawing.Point(3, 3)
        Me.flowPanel.Name = "flowPanel"
        Me.flowPanel.Size = New System.Drawing.Size(666, 416)
        Me.flowPanel.TabIndex = 0
        '
        'tpPanoramica
        '
        Me.tpPanoramica.Controls.Add(Me.RadCarousel)
        Me.tpPanoramica.ImageKey = "multiple_smartphones-24.png"
        Me.tpPanoramica.Location = New System.Drawing.Point(4, 31)
        Me.tpPanoramica.Name = "tpPanoramica"
        Me.tpPanoramica.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPanoramica.Size = New System.Drawing.Size(672, 422)
        Me.tpPanoramica.TabIndex = 0
        Me.tpPanoramica.Text = "Panoramica"
        Me.tpPanoramica.UseVisualStyleBackColor = True
        '
        'imlTab24
        '
        Me.imlTab24.ImageStream = CType(resources.GetObject("imlTab24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab24.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab24.Images.SetKeyName(0, "business_contact-24.png")
        Me.imlTab24.Images.SetKeyName(1, "multiple_smartphones-24.png")
        '
        'frmOrdiniPanoramica
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 614)
        Me.Controls.Add(Me.TabRisultati)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.UcOrdiniAnteprima)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmOrdiniPanoramica"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Panoramica Lavori"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RadCarousel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.TabRisultati.ResumeLayout(False)
        Me.tpRicercaImmagini.ResumeLayout(False)
        Me.tpPanoramica.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents RadCarousel As Telerik.WinControls.UI.RadCarousel
    Friend WithEvents UcOrdiniAnteprima As ucOrdiniAnteprima
    Friend WithEvents lblTotOrd As Label
    Friend WithEvents pnlFilter As Panel
    Friend WithEvents TabRisultati As TabControl
    Friend WithEvents tpPanoramica As TabPage
    Friend WithEvents tpRicercaImmagini As TabPage
    Friend WithEvents lblRub As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbCatProd As ComboBox
    Friend WithEvents lnkCerca As LinkLabel
    Friend WithEvents flowPanel As FlowLayoutPanel
    Friend WithEvents imlTab24 As ImageList
End Class
