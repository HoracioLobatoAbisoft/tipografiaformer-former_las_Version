Imports FormerDALSql
Imports FormerBusinessLogic
Imports FormerLib.FormerEnum

Friend Class frmOrdine
    'Inherits baseFormInternaRedim

    Private _OrdSel As New Ordine
    Private _Ris As Integer

    Friend Function Carica(Optional ByVal IdOrd As Integer = 0,
                           Optional ByVal IdRub As Integer = 0,
                           Optional P As Prodotto = Nothing,
                           Optional Qta As Integer = 0) As Integer


        If IdOrd Then

            _OrdSel.Read(IdOrd)

        End If

        Dim risLocked As RisIsLocked = MgrOrderLock.IsLocked(IdOrd, PostazioneCorrente.UtenteConnesso.IdUt)
        If risLocked.IsLocked Then
            MessageBox.Show("L'ordine risulta attualmente locked da un altro processo, riprovare in seguito")
            Exit Function
        Else
            'vado a fare il lock
            Dim L As New List(Of Ordine)
            L.Add(_OrdSel)

            Try
                MgrOrderLock.Lock(PostazioneCorrente.UtenteConnesso.IdUt, L, enFunctionLock.OrdineAperto)
            Catch ex As Exception
                MessageBox.Show("Si è verificato un errore nel lock dell'ordine, riprovare in seguito")
                Exit Function
            End Try

        End If

        If _OrdSel.IdOrd Then

            'ricarico l'ordine
            'If _OrdSel.IdCom <> 0 Then
            'btnOk.Visible = False
            ' End If

            UcOrdineDett.Carica(_OrdSel)
            UcOrdineDett.TipoAzione = enTipoAzione.Modifica

        Else
            UcOrdineDett.TipoAzione = enTipoAzione.Nuovo
            UcOrdineDett.Carica(, IdRub)

        End If

        If Not P Is Nothing Then
            'riseleziono il prodotto 
            UcOrdineDett.Carica(, , P)
        End If

        If Qta Then
            'UcOrdineDett.txtQta.Text = Qta
        End If

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

        Close()

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim OrdAgg As New Ordine
            UcOrdineDett.RiempiOrdineDaControlli(OrdAgg)

            If OrdAgg.IsValid Then
                OrdAgg.Save()

                If OrdAgg.IdCom <> 0 AndAlso MgrFormerException.SincronizzareNoteCommessa(OrdAgg) Then
                    OrdAgg.Commessa.Refresh()
                    OrdAgg.Commessa.Annotazioni = OrdAgg.Annotazioni
                    OrdAgg.Commessa.Save()
                End If

                If OrdAgg.ModificatiLavLog Then
                    'qui devo risalvare i lavlog dell'ordine

                    Dim IdllPresenti As String = String.Empty

                    For Each ll As LavLog In OrdAgg.ListLavLog

                        IdllPresenti &= ll.IdLavLog & ","

                    Next

                    IdllPresenti = IdllPresenti.TrimEnd(",")

                    Using mgr As New LavLogDAO
                        mgr.DeleteByIdLavLogList(IdllPresenti, OrdAgg.IdOrd)
                    End Using

                    For Each ll As LavLog In OrdAgg.ListLavLog
                        ll.Save()
                    Next

                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, _OrdSel.IdOrd, "Modificata manualmente la lista delle lavorazioni")

                End If

                'If OrdAgg.IdOrd = 0 Then
                '    'QUI NON CI ENTRA MAI IMPOSSIBILE CHE CI SIA UN ORDINE CON IDORD = 0 PERCHE GLI ORDINI ARRIVANO SOLO DAL SITO O DAL DUPLICA
                '    'OrdAgg.SaveEx(True)
                'Else
                '    'CHIAMO LA SAVE NORMALE INVECE DELLA SAVEEX
                '    OrdAgg.Save()
                '    'OrdAgg.SaveEx(False)
                'End If
                Dim SalvaFile As Boolean = False
                If OrdAgg.IdCom = 0 Then
                    SalvaFile = True
                Else
                    If OrdAgg.IdTipoProd <> enRepartoWeb.StampaOffset Then
                        If OrdAgg.Stato < enStatoOrdine.InCodaDiStampa Then
                            SalvaFile = True
                        End If
                    End If
                End If

                If SalvaFile Then
                    UcOrdineDett.SalvaFile(OrdAgg)
                End If

                _Ris = 1
                Close()

            Else
                MessageBox.Show("La quantità e l'immagine sono dati obbligatori! Il prezzo non può essere negativo! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub UcOrdineDett_CambioStato() Handles UcOrdineDett.CambioStato
        If _OrdSel.Stato <> enStatoOrdine.Preinserito Then
            btnOk.Visible = False
        Else
            btnOk.Visible = True
        End If
        _Ris = 1

    End Sub

    Private Sub UcOrdineDett_BloccaTastiForm() Handles UcOrdineDett.BloccaTastiForm
        btnOk.Enabled = False
    End Sub

    Private Sub UcOrdineDett_SbloccaTastiForm() Handles UcOrdineDett.SbloccaTastiForm
        btnOk.Enabled = True
    End Sub

    Private Sub frmOrdine_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            MgrOrderLock.UnlockAll(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.OrdineAperto)
        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nell'unlock degli ordini bloccati. Contattare assistenza")
        End Try

    End Sub
End Class