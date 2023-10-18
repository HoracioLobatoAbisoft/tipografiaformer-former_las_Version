Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerBusinessLogic
Imports FormerLib
Imports FormerConfig
Imports FormerIO

Friend Class frmNewTemplMarketing
    'Inherits baseFormInternaRedim

    Private _Ris As TMO = Nothing
    Private _Fm As FiltroMarketing = Nothing
    Private ListaOfferte As List(Of ListinoBaseInTemplate) = Nothing

    Private _IdTmOff As Integer = 0
    Private _IdFm As Integer = 0
    Private _Mese As Integer = 0

    Friend Function Carica(Optional IdTmOff As Integer = 0,
                           Optional IdFm As Integer = 0,
                           Optional Mese As Integer = 0) As TMO

        'qui in caso lo carico
        _Ris = New TMO
        _IdTmOff = IdTmOff
        _IdFm = IdFm
        _Mese = Mese

        If IdTmOff Then
            _Ris.Read(IdTmOff)
        Else
            _Ris.IdFM = IdFm
            _Ris.Mese = Mese
            _IdTmOff = _Ris.Save()
        End If

        _IdFm = _Ris.IdFM

        _Fm = New FiltroMarketing
        _Fm.Read(_IdFm)

        CaricaOfferte()

        CaricaMesi()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If ListaOfferte.Count = 0 Then

            'elimino il tmoff
            Using mgr As New TemplateMarketingOfferteDAO
                mgr.Delete(_IdTmOff)
            End Using

            _Ris = New TMO

        End If

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnAnteprima.Click

        If ListaOfferte.Count Then
            MgrMarketingWeb.PathTarget = FormerPath.PathTemp

            Dim Path As String = MgrMarketingWeb.CreaNewsletterSuListiniBase(ListaOfferte, _Ris)
            FormerHelper.File.ShellExtended(Path)
        Else
            MessageBox.Show("Inserire almeno una offerta")
        End If

    End Sub

    Private Sub lnkNewTempl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNewTempl.LinkClicked

        Sottofondo()

        Dim ris As ListinoBaseInTemplate

        Using f As New frmMarketingAddLBToTemplate

            ris = f.Carica(_IdTmOff)

        End Using

        Sottofondo()

        If Not ris Is Nothing Then
            CaricaOfferte()

            Dim PathFile As String = FormerPath.PathTemplate
            PathFile &= "NL-" & _Fm.IdFiltroMarketing & "-" & _IdTmOff & "-" & Now.Year & ".htm"

            If File.Exists(PathFile) Then
                MgrFormerIO.FileDelete(PathFile)
            End If

        End If

    End Sub

    Private Sub CaricaOfferte()

        ListaOfferte = _Ris.ListaOfferte(True)
        DgListinoBase.DataSource = Nothing
        DgListinoBase.AutoGenerateColumns = False
        DgListinoBase.DataSource = ListaOfferte

    End Sub

    Private Sub lnkDelListinoBase_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelListinoBase.LinkClicked

        If DgListinoBase.SelectedRows.Count Then
            If MessageBox.Show("Confermi la cancellazione dell'offerta selezionata?", "Cancellazione Offerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim IdLb As Integer = 0

                Dim lb As ListinoBaseInTemplate = DirectCast(DgListinoBase.SelectedRows(0).DataBoundItem, ListinoBaseSuTemplate)
                IdLb = lb.IdTMLB

                Using mgr As New ListinoBaseSuTemplateDAO
                    mgr.Delete(IdLb)
                End Using

                CaricaOfferte()

                Dim PathFile As String = FormerPath.PathTemplate
                PathFile &= "NL-" & _Fm.IdFiltroMarketing & "-" & _IdTmOff & "-" & Now.Year & ".htm"

                If File.Exists(PathFile) Then
                    MgrFormerIO.FileDelete(PathFile)
                End If
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub CaricaMesi()

        Dim mese As cEnum
        cmbMesi.ValueMember = "Id"
        cmbMesi.DisplayMember = "Descrizione"

        If _Fm.chkGennaio Then
            mese = New cEnum
            mese.Id = _Fm.chkGennaio
            mese.Descrizione = "Gennaio"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkFebbraio Then
            mese = New cEnum
            mese.Id = _Fm.chkFebbraio
            mese.Descrizione = "Febbraio"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkMarzo Then
            mese = New cEnum
            mese.Id = _Fm.chkMarzo
            mese.Descrizione = "Marzo"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkAprile Then
            mese = New cEnum
            mese.Id = _Fm.chkAprile
            mese.Descrizione = "Aprile"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkMaggio Then
            mese = New cEnum
            mese.Id = _Fm.chkMaggio
            mese.Descrizione = "Maggio"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkGiugno Then
            mese = New cEnum
            mese.Id = _Fm.chkGiugno
            mese.Descrizione = "Giugno"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkLuglio Then
            mese = New cEnum
            mese.Id = _Fm.chkLuglio
            mese.Descrizione = "Luglio"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkAgosto Then
            mese = New cEnum
            mese.Id = _Fm.chkAgosto
            mese.Descrizione = "Agosto"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkSettembre Then
            mese = New cEnum
            mese.Id = _Fm.chkSettembre
            mese.Descrizione = "Settembre"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkOttobre Then
            mese = New cEnum
            mese.Id = _Fm.chkOttobre
            mese.Descrizione = "Ottobre"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkNovembre Then
            mese = New cEnum
            mese.Id = _Fm.chkNovembre
            mese.Descrizione = "Novembre"
            cmbMesi.Items.Add(mese)
        End If
        If _Fm.chkDicembre Then
            mese = New cEnum
            mese.Id = _Fm.chkDicembre
            mese.Descrizione = "Dicembre"
            cmbMesi.Items.Add(mese)
        End If

    End Sub

    Private Sub btnCopia_Click(sender As Object, e As EventArgs) Handles btnCopia.Click

        If MessageBox.Show("Confermi di voler copiare le impostazioni di marketing dal mese selezionato? ATTENZIONE, verranno cancellati tutti i listini attivi", "Copia marketing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim meseSel As cEnum = cmbMesi.SelectedItem

            If Not meseSel Is Nothing Then

                Using mgr As New ListinoBaseSuTemplateDAO

                    mgr.DeleteByIdTMOff(_IdTmOff)
                    mgr.InsertByIdTMOff(_IdTmOff, meseSel.Id)

                End Using
                CaricaOfferte()
                'cancello il file se presente
                Dim PathFile As String = FormerPath.PathTemplate
                PathFile &= "NL-" & _Fm.IdFiltroMarketing & "-" & _IdTmOff & "-" & Now.Year & ".htm"

                If File.Exists(PathFile) Then
                    MgrFormerIO.FileDelete(PathFile)
                End If

            Else
                Beep()
            End If

        End If

    End Sub
End Class