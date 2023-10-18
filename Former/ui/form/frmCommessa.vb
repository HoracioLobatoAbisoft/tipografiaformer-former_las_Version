Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerBusinessLogic
Imports FormerLib
Imports FormerConfig

Public Class frmCommessa
    ' Inherits baseFormInternaRedim

    Private _ComSel As New Commessa
    Private _Ris As Integer

    'Friend Function NuovaInManuale() As Integer

    '    Return Carica()

    'End Function

    'Friend Function Riapri(IdCom As Integer) As Integer

    '    Return Carica(IdCom)

    'End Function
    Private _CommessaProposta As CommessaProposta = Nothing
    Friend Function Carica(Optional ByVal IdCom As Integer = 0,
                           Optional ByVal ListaIdOrd As String = "",
                           Optional CommessaProposta As CommessaProposta = Nothing,
                           Optional IdReparto As enRepartoWeb = enRepartoWeb.StampaOffset) As Integer

        'Debug.Traccia(True)
        'FormerDebug.Traccia()
        _CommessaProposta = CommessaProposta
        If IdCom Then
            _ComSel.Read(IdCom)
        Else
            If IdReparto = enRepartoWeb.Packaging Then IdReparto = enRepartoWeb.StampaOffset
            _ComSel.IdReparto = IdReparto
            'NON SERVE _ComSel.IdModelloCommessa = CommessaProposta.ModelloCommessa.IdModello
        End If

        If _ComSel.IdCom Then
            'ricarico l'ordine
            If _ComSel.Stato <> enStatoCommessa.Preinserito Then
                btnOk.Visible = False
            End If
        End If
        Dim GoForward As Boolean = True

        For Each O In _ComSel.ListaOrdini
            Dim risLocked As RisIsLocked = MgrOrderLock.IsLocked(O.IdOrd, PostazioneCorrente.UtenteConnesso.IdUt)
            If risLocked.IsLocked = True Then
                GoForward = False
                Exit For
            End If
        Next

        If GoForward = False Then
            MessageBox.Show("Uno o più ordini della Commessa risulta attualmente locked da un altro processo, riprovare in seguito")
            Exit Function
        Else
            'vado a fare il lock
            Try
                MgrOrderLock.Lock(PostazioneCorrente.UtenteConnesso.IdUt, _ComSel.ListaOrdini, enFunctionLock.OrdineAperto)
            Catch ex As Exception
                MessageBox.Show("Si è verificato un errore nel lock di uno degli ordini della commessa, riprovare in seguito")
                Exit Function
            End Try

        End If

        UcCommesseDett.Carica(_ComSel,
                              ListaIdOrd,
                              CommessaProposta)

        Me.Text &= " - " & IdCom

        ShowDialog()
        'Debug.Traccia(False)

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

        If PostazioneCorrente.ScaricamentoOrdiniInCorso Then
            MessageBox.Show("Il demone sta scaricando degli ordini, quindi la commessa che si sta salvando potrebbe contenere Ordini non piu disponibili")
        Else
            If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim PrimoSalvataggio As Boolean = False
                If _ComSel.IdCom = 0 Then PrimoSalvataggio = True

                Dim BufferLocked As String = String.Empty

                Using com As New Commessa
                    If _ComSel.IdCom <> 0 Then com.Read(_ComSel.IdCom)
                    UcCommesseDett.RiempiCommessaDaControlli(com)

                    If com.ListaIdOrdini.Count Then
                        Dim OkFile As Boolean = True
                        For Each singId As Integer In com.ListaIdOrdini
                            Using O As New Ordine
                                O.Read(singId)

                                For Each S As FileSorgente In O.ListaSorgenti
                                    If FormerHelper.File.IsFileLocked(S.FilePath) Then
                                        BufferLocked &= " - " & S.FilePath & ControlChars.NewLine
                                        OkFile = False
                                    End If
                                Next

                            End Using
                        Next
                        If OkFile Then
                            Dim ErroreOrdini As Boolean = False

                            For Each singId As Integer In com.ListaIdOrdini
                                Using o As New Ordine
                                    o.Read(singId)
                                    If o.IdCom <> 0 And o.IdCom <> com.IdCom Then
                                        'qui potrebbe essere stato incluso automaticamente dentro una commessa
                                        ErroreOrdini = True
                                        Exit For
                                    End If
                                End Using
                            Next

                            If ErroreOrdini = False Then
                                Dim swFirst As Boolean = False
                                If com.IdCom = 0 Then swFirst = True

                                If (com.MovMagaz.Count > 0) Or com.IdReparto <> enRepartoWeb.StampaOffset Then
                                    If com.IsValid Then
                                        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                                            Try
                                                'LUNA.LunaContext.TransactionBegin()
                                                Dim IdIns As Integer = 0
                                                tb.TransactionBegin()
                                                IdIns = com.Save()

                                                Dim ListaOrdEsclusi As List(Of Integer) = Nothing

                                                Using M As New CommesseDAO

                                                    If swFirst Then 'questo lo devo fare per forza prima il salvataggio degli ordini
                                                        M.InserisciLog(com, enStatoCommessa.Preinserito, PostazioneCorrente.UtenteConnesso.IdUt)
                                                    End If

                                                    ListaOrdEsclusi = M.SalvaOrdiniTornaEsclusi(com)
                                                    M.SalvaMovMagaz(com)

                                                    'If swFirst Then 'questo lo devo fare per forza dopo il salvataggio degli ordini
                                                    M.InserisciLavorazioni(com, _CommessaProposta)
                                                    'End If

                                                End Using
                                                'LUNA.LunaContext.TransactionCommit()
                                                tb.TransactionCommit()
                                                'If swFirst Then

                                                'sposto i file degli ordini che sono stati esclusi se ci sono 
                                                For Each SingIdOrd In ListaOrdEsclusi
                                                    Using o As New Ordine
                                                        o.Read(SingIdOrd)
                                                        If o.FilePath.Length Then
                                                            Dim NuovoNomeFile As String = FormerPath.PathTemp & FormerLib.FormerHelper.File.EstraiNomeFile(o.FilePath)
                                                            'FileCopy(Ord.FilePath, NuovoNomeFile)
                                                            MgrIO.FileSposta(Me, o.FilePath, NuovoNomeFile)
                                                            o.FilePath = NuovoNomeFile
                                                            Using mO As New OrdiniDAO
                                                                mO.SalvaFile(o)
                                                            End Using
                                                            'qui copio i file dei sorgenti degli ordini
                                                        End If

                                                        For Each sorg As FileSorgente In o.ListaSorgenti
                                                            'Dim Estensione As String = ""

                                                            'Estensione = sorg.FilePath.Substring(sorg.FilePath.Length - 4)
                                                            Dim NomeFileOriginale As String = FormerLib.FormerHelper.File.EstraiNomeFile(sorg.FilePath)

                                                            Dim Posizione As Integer = NomeFileOriginale.IndexOf("-")

                                                            If Posizione <> -1 AndAlso Posizione < 7 Then
                                                                NomeFileOriginale = NomeFileOriginale.Substring(Posizione + 1)
                                                            End If

                                                            Dim NuovoNomeFile As String = FormerPath.PathTemp & NomeFileOriginale
                                                            'FileCopy(sorg.FilePath, NuovoNomeFile)
                                                            MgrIO.FileSposta(Me, sorg.FilePath, NuovoNomeFile)
                                                            sorg.FilePath = NuovoNomeFile
                                                            sorg.Save()
                                                        Next
                                                    End Using
                                                Next

                                                'sposto i file nuovi se non ci sono 
                                                UcCommesseDett.SalvaFile(com)
                                                'End If

                                                If com.IdReparto = enRepartoWeb.StampaOffset Then
                                                    If com.FromJob = enSiNo.No Then
                                                        Dim collOrd As OrdiniCTP = MgrCTP.GetListaOrdiniCTP(com)
                                                        'MgrCTP.EsportaCTP(collOrd)
                                                        If PrimoSalvataggio = True OrElse MessageBox.Show("Vuoi esportare il file JOB della commessa con le impostazioni di DEFAULT?", "Export JOB", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                                            MgrCTP.EsportaJOB(com.IdCom, collOrd, Me)
                                                        End If
                                                    End If
                                                End If

                                                _Ris = com.IdCom
                                                Close()

                                            Catch ex As Exception
                                                tb.TransactionRollBack()
                                                ManageError(ex)
                                            End Try
                                        End Using
                                    Else
                                        MessageBox.Show("Dati della commessa non validi!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End If

                                Else
                                    MessageBox.Show("Selezionare le risorse da utilizzare! In ogni commessa deve essere presente almeno un ordine e utilizzata almeno una risorsa!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else
                                MessageBox.Show("Gli ordini selezionati non possono essere più utilizzati perchè inseriti automaticamente in altre commesse. Ricalcolare le soluzioni!")
                                Close()
                            End If
                        Else
                            MessageBox.Show("Impossibile continuare, i seguenti file risultano locked:" & ControlChars.NewLine & BufferLocked & ControlChars.NewLine & "Controllare che non siano aperti in altri programmi e riprovare")
                        End If

                    Else
                        MessageBox.Show("Selezionare gli ordini da utilizzare! In ogni commessa deve essere presente almeno un ordine e utilizzata almeno una risorsa!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End If
        End If

    End Sub
    Private Sub UcCommesseDett_CambioStato() Handles UcCommesseDett.CambioStato
        If _ComSel.Stato <> enStatoCommessa.Preinserito Then
            btnOk.Visible = False
        Else
            btnOk.Visible = True
        End If
        _Ris = 1
        Refresh()
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        'WindowState = FormWindowState.Maximized

    End Sub

    Private Sub UcCommesseDett_CommessaCancellata() Handles UcCommesseDett.CommessaCancellata

        _Ris = 1
        Close()

    End Sub

    Private Sub frmCommessa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            MgrOrderLock.UnlockAll(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.OrdineAperto)
        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nell'unlock degli ordini bloccati. Contattare assistenza")
        End Try
    End Sub
End Class