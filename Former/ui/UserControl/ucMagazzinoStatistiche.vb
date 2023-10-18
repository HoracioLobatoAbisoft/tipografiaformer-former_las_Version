Imports System.IO
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucMagazzinoStatistiche
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        Try
            CaricaCombo()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CaricaCombo()

        Dim L As New List(Of cEnum)

        Dim voce As New cEnum
        voce.Id = enPeriodoRiferimento.UnGiorno
        voce.Descrizione = FormerEnumHelper.PeriodoRiferimentoStr(enPeriodoRiferimento.UnGiorno)
        L.Add(voce)

        voce = New cEnum
        voce.Id = enPeriodoRiferimento.Ieri
        voce.Descrizione = FormerEnumHelper.PeriodoRiferimentoStr(enPeriodoRiferimento.Ieri)
        L.Add(voce)

        voce = New cEnum
        voce.Id = enPeriodoRiferimento.UnaSettimana
        voce.Descrizione = FormerEnumHelper.PeriodoRiferimentoStr(enPeriodoRiferimento.UnaSettimana)
        L.Add(voce)

        voce = New cEnum
        voce.Id = enPeriodoRiferimento.UnMese
        voce.Descrizione = FormerEnumHelper.PeriodoRiferimentoStr(enPeriodoRiferimento.UnMese)
        L.Add(voce)

        voce = New cEnum
        voce.Id = enPeriodoRiferimento.UnAnno
        voce.Descrizione = FormerEnumHelper.PeriodoRiferimentoStr(enPeriodoRiferimento.UnAnno)
        L.Add(voce)

        cmbPeriodoRif.DataSource = L
        cmbPeriodoRif.DisplayMember = "Descrizione"
        cmbPeriodoRif.ValueMember = "Id"
        cmbPeriodoRif.SelectedIndex = 0

        dtDataInsAl.Value = Now
        dtDataInsDal.Value = Now

        Using mgr As New GruppoRisorsaDAO
            Dim lG As List(Of GruppoRisorsa) = mgr.GetAll(LFM.GruppoRisorsa.Nome, True)
            cmbGruppo.DisplayMember = LFM.GruppoRisorsa.Nome.Name
            cmbGruppo.ValueMember = LFM.GruppoRisorsa.IdGruppoRisorsa.Name

            cmbGruppo.DataSource = lG

        End Using

        Using mgr As New TipiCartaDAO
            Dim lT As List(Of TipoCarta) = mgr.GetAll(LFM.TipoCarta.Tipologia, True)
            cmbTipoCarta.DisplayMember = LFM.TipoCarta.Tipologia.Name
            cmbTipoCarta.ValueMember = LFM.TipoCarta.IdTipoCarta.Name

            cmbTipoCarta.DataSource = lT

        End Using

        'Dim Lt As New List(Of cEnum)

        'Dim VoceT As New cEnum
        'VoceT.Id = enTipoMovMagaz.Tutto
        'VoceT.Descrizione = FormerEnumHelper.TipoMovimentoMagazzinoStr(VoceT.Id)
        'Lt.Add(VoceT)

        'VoceT = New cEnum
        'VoceT.Id = enTipoMovMagaz.Prenotazione
        'VoceT.Descrizione = FormerEnumHelper.TipoMovimentoMagazzinoStr(VoceT.Id)
        'Lt.Add(VoceT)

        'VoceT = New cEnum
        'VoceT.Id = enTipoMovMagaz.Carico
        'VoceT.Descrizione = FormerEnumHelper.TipoMovimentoMagazzinoStr(VoceT.Id)
        'Lt.Add(VoceT)

        'VoceT = New cEnum
        'VoceT.Id = enTipoMovMagaz.Scarico
        'VoceT.Descrizione = FormerEnumHelper.TipoMovimentoMagazzinoStr(VoceT.Id)
        'Lt.Add(VoceT)

        'VoceT = New cEnum
        'VoceT.Id = enTipoMovMagaz.Storno
        'VoceT.Descrizione = FormerEnumHelper.TipoMovimentoMagazzinoStr(VoceT.Id)
        'Lt.Add(VoceT)

        'cmbTipoMov.DataSource = Lt
        'cmbTipoMov.DisplayMember = "Descrizione"
        'cmbTipoMov.ValueMember = "Id"
        'cmbTipoMov.SelectedIndex = 0


    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked

        CaricaStat()

    End Sub

    Private Sub CaricaStat()
        Cursor.Current = Cursors.WaitCursor
        MgrAnteprime.CreaRiepilogoMagazzino(dtDataInsDal.Value, dtDataInsAl.Value, cmbTipoCarta.SelectedValue, cmbGruppo.SelectedValue, WebStat)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmbPeriodoRif_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodoRif.SelectedIndexChanged
        Select Case cmbPeriodoRif.SelectedItem.id
            Case enPeriodoRiferimento.UnGiorno  ' trimestre
                dtDataInsDal.Value = dtDataInsAl.Value.AddDays(-1)
            Case enPeriodoRiferimento.Ieri  ' trimestre
                dtDataInsAl.Value = Now.Date.AddDays(-1)
                dtDataInsDal.Value = dtDataInsAl.Value.AddDays(-1)
            Case enPeriodoRiferimento.UnaSettimana  ' semestre
                dtDataInsDal.Value = dtDataInsAl.Value.AddDays(-7)
            Case enPeriodoRiferimento.UnMese
                dtDataInsDal.Value = dtDataInsAl.Value.AddMonths(-1)
            Case enPeriodoRiferimento.UnAnno
                dtDataInsDal.Value = dtDataInsAl.Value.AddYears(-1)
        End Select
    End Sub

End Class
