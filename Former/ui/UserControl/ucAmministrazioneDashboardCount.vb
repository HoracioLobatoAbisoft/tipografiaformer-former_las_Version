Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucAmministrazioneDashboardCount
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub CaricaDati()
        Cursor.Current = Cursors.WaitCursor

        Dim r As RisCheckFinanziario = MgrCheckFinanziario.GetSituation

        lblTotDuplicati.Text = r.VociDuplicate
        lblTotFornitori.Text = r.FornitoriInseritiAutomaticamente
        lblTotNoCat.Text = r.fornitorisenzacategoria

        lblDocDaInviare.Text = r.NonInCodaPerInvio
        lblDocScartati.Text = r.Scartati
        lblDocInoltrati.Text = r.InviatiSDIDaOltre5Giorni
        lblDocCodaInvio.Text = r.InCodaInvioDaOltre3Giorni

        lstCheckMassivi.Items.Clear()

        For Each voce In r.ListaCheckMassiviMancanti
            lstCheckMassivi.Items.Add(voce)
        Next

        lblCarichiMagazzinoAnomalia.Text = r.CarichiMagazzinoAnomalia
        lblCarichiNonCollegati.Text = r.CarichiMagazzinoNonCollegati

        lblRisTipoNonSpecificato.Text = r.RisorseTipoNonSpecificato

        'gpdocemessi
        If r.NonInCodaPerInvio = 0 AndAlso
            r.Scartati = 0 AndAlso
            r.InviatiSDIDaOltre5Giorni = 0 AndAlso
            r.InCodaInvioDaOltre3Giorni = 0 Then
            gpDocEmessi.Visible = False
        Else
            gpDocEmessi.Visible = True
        End If

        If r.ListaCheckMassiviMancanti.Count Then
            gpCheckMassivi.Visible = True
        Else
            gpCheckMassivi.Visible = False
        End If

        If r.RisorseTipoNonSpecificato = 0 Then
            gpRisorse.Visible = False
        Else
            gpRisorse.Visible = True
        End If

        If r.CarichiMagazzinoAnomalia = 0 AndAlso
           r.CarichiMagazzinoNonCollegati = 0 Then
            gpCarichi.Visible = False
        Else
            gpCarichi.Visible = True
        End If

        If r.VociDuplicate = 0 AndAlso
            r.FornitoriSenzaCategoria = 0 AndAlso
            r.FornitoriInseritiAutomaticamente = 0 Then
            gpRubrica.Visible = False
        Else
            gpRubrica.Visible = True
        End If

        Cursor.Current = Cursors.Default
    End Sub

    Public Sub Carica()
        'CaricaDati()
    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        CaricaDati()
    End Sub

    Private Sub lnkRisolviNonInCoda_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisolviNonInCoda.LinkClicked

        FormPrincipale.UcMain.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.TabMain.SelectedIndex = 1
        FormPrincipale.UcMain.UcFatture.UcContab.tabDoc.SelectedIndex = 0

        FormPrincipale.UcMain.UcFatture.UcContab.MostranonIncoda

    End Sub

    Private Sub lnkRisolviScartati_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisolviScartati.LinkClicked
        FormPrincipale.UcMain.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.TabMain.SelectedIndex = 1
        FormPrincipale.UcMain.UcFatture.UcContab.tabDoc.SelectedIndex = 0

        FormPrincipale.UcMain.UcFatture.UcContab.MostraScartati()
    End Sub

    Private Sub lnkRisolviSDI_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisolviSDI.LinkClicked
        FormPrincipale.UcMain.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.TabMain.SelectedIndex = 1
        FormPrincipale.UcMain.UcFatture.UcContab.tabDoc.SelectedIndex = 0

        FormPrincipale.UcMain.UcFatture.UcContab.MostraInoltrati()
    End Sub

    Private Sub lnkControllaFornitori_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkControllaFornitori.LinkClicked
        FormPrincipale.UcMain.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.UcRubrica1.MostraInseritiAutomaticamenteDaValidare()
    End Sub

    Private Sub lnkRisolviDuplicati_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisolviDuplicati.LinkClicked
        FormPrincipale.UcMain.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.UcRubrica1.MostraDuplicati()
    End Sub

    Private Sub lnkControllaNoCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkControllaNoCat.LinkClicked
        FormPrincipale.UcMain.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.UcRubrica1.MostraSenzaCategoria()
    End Sub

    Private Sub lnkRisolviCheckMassivi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisolviCheckMassivi.LinkClicked
        FormPrincipale.UcMain.UcFatture.UcAmministrazioneDashboard.tabMain.SelectedIndex = 1

    End Sub

    Private Sub lnkRisolviCarichiMagazzino_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisolviCarichiMagazzino.LinkClicked
        FormPrincipale.UcMain.TabMain.SelectedIndex = 4
        FormPrincipale.UcMain.UcMagazzinoMain.tabMain.SelectedIndex = 4
        FormPrincipale.UcMain.UcMagazzinoMain.UcMagazzinoCarichiDiMagazzino.MostraAnomalia()
    End Sub

    Private Sub lnkRisTipoNonSpecificato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisTipoNonSpecificato.LinkClicked
        FormPrincipale.UcMain.TabMain.SelectedIndex = 4
        FormPrincipale.UcMain.UcMagazzinoMain.tabMain.SelectedIndex = 0
        FormPrincipale.UcMain.UcMagazzinoMain.UcMagazzinoRisorse.MostraTipoNonSpecificato()
    End Sub

    Private Sub lnkRisolviNonCollegati_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisolviNonCollegati.LinkClicked
        FormPrincipale.UcMain.TabMain.SelectedIndex = 4
        FormPrincipale.UcMain.UcMagazzinoMain.tabMain.SelectedIndex = 4
        FormPrincipale.UcMain.UcMagazzinoMain.UcMagazzinoCarichiDiMagazzino.MostraNonCollegati()
    End Sub

    Private Sub LnkRisolviDocCodaInvio_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisolviDocCodaInvio.LinkClicked

        FormPrincipale.UcMain.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.TabMain.SelectedIndex = 1
        FormPrincipale.UcMain.UcFatture.UcContab.tabDoc.SelectedIndex = 0

        FormPrincipale.UcMain.UcFatture.UcContab.MostraInCodaInvio()
    End Sub
End Class
