Imports System.IO
Imports FormerDALSql
Imports FormerBusinessLogic
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerIO

Public Class ucProduzioneVerify
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        ForzaARegistratoToolStripMenuItem.BackColor = FormerColori.ColoreStatoOrdineRefine

        StatiOrdiniAmministr = enStatoOrdine.RefineAutomatico & ","
        StatiOrdiniAmministr &= enStatoOrdine.Preinserito & ","
        StatiOrdiniAmministr &= enStatoOrdine.Registrato & ","
        'StatiOrdiniAmministr &= enStatoOrdine.InSospeso & ","
        StatiOrdiniAmministr &= enStatoOrdine.InCodaDiStampa & ","
        StatiOrdiniAmministr &= enStatoOrdine.StampaInizio & ","
        StatiOrdiniAmministr &= enStatoOrdine.StampaFine & ","
        StatiOrdiniAmministr &= enStatoOrdine.FinituraCommessaInizio & ","
        StatiOrdiniAmministr &= enStatoOrdine.FinituraCommessaFine & ","
        StatiOrdiniAmministr &= enStatoOrdine.FinituraProdottoInizio & ","
        StatiOrdiniAmministr &= enStatoOrdine.FinituraProdottoFine & ","
        StatiOrdiniAmministr &= enStatoOrdine.Imballaggio & ","
        StatiOrdiniAmministr &= enStatoOrdine.ImballaggioCorriere & ","
        StatiOrdiniAmministr &= enStatoOrdine.ProntoRitiro & ","
        StatiOrdiniAmministr &= enStatoOrdine.UscitoMagazzino '& ","
        'StatiOrdiniAmministr &= enStatoOrdine.InConsegna & ","
        'StatiOrdiniAmministr &= enStatoOrdine.Consegnato

        UcListinoTipiCarta.ObbligaRisorseIncodaNonAssociate()

    End Sub

    Public Sub Carica()

    End Sub

    Private StatiOrdiniAmministr As String = String.Empty

    Public ReadOnly Property OrdiniInCoda As Integer
        Get
            Dim ris As Integer = 0
            ris = OrdiniDaEsportare.Count
            ris += OrdiniDaEsportare(StatiOrdiniAmministr, True).Count

            Return ris
        End Get
    End Property

    Private Sub AggiornaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggiornaToolStripMenuItem.Click

        CaricaOrdini()

    End Sub

    Private Function Comparer(x As OrdineRicerca, y As OrdineRicerca) As Integer
        Dim ris As Integer = y.Stato.CompareTo(x.Stato)

        If ris = 0 Then
            ris = x.IdListinoBase.CompareTo(y.IdListinoBase)
            If ris = 0 Then
                ris = x.QtaRif.CompareTo(y.QtaRif)
                If ris = 0 Then
                    ris = x.IdRub.CompareTo(y.IdRub)
                    If ris = 0 Then
                        ris = x.DataPrevConsegna.CompareTo(y.DataPrevConsegna)
                    End If
                End If
            End If
        End If

        Return ris
    End Function

    Private Function CaricaOrdini() As Integer
        Cursor.Current = Cursors.WaitCursor
        Dim Ris As Integer = 0

        Using mgr As New OrdiniDAO
            'Dim LstStati As String = enStatoOrdine.RefineAutomatico & "," & enStatoOrdine.Preinserito
            Dim LNoUtil As List(Of OrdineRicerca) = OrdiniDaEsportare()

            'LNoUtil = mgr.Lista(, LstStati, , True, , , , , , , , , , , True, )
            'LNoUtil.Sort(AddressOf Comparer)

            'L = L.FindAll(Function(x) x.IdListinoBase <> 0)
            dgOrdini.AutoGenerateColumns = False
            dgOrdini.DataSource = LNoUtil

            dgOrdini.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdini.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdini.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdini.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdini.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Ris = LNoUtil.FindAll(Function(x) x.Stato = enStatoOrdine.Preinserito).Count
        End Using

        Cursor.Current = Cursors.Default

        Return Ris

    End Function

    Private Sub dgOrdini_MouseClick(sender As Object, e As MouseEventArgs) Handles dgOrdini.MouseClick, dgOrdiniAmministr.MouseClick

        If sender.SelectedRows.Count Then
            Dim Dr As DataGridViewRow

            Dr = sender.SelectedRows(0)

            If Not Dr Is Nothing Then

                Dim O As Ordine = Dr.DataBoundItem

                Dr.Selected = True
                IdOrdSel = O.IdOrd
                RaiseEvent OrdineSelezionato()

            End If
        End If

    End Sub

    Private Sub dgOrdini_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgOrdini.RowPostPaint,
                                                                                                                                                                                           dgOrdiniAmministr.RowPostPaint

        Dim x As DataGridViewRow = sender.Rows.Item(e.RowIndex)
        Dim O As OrdineRicerca = x.DataBoundItem

        x.Cells(3).Style.BackColor = O.StatoColore
        x.Cells(3).Style.SelectionBackColor = O.StatoColore

    End Sub

    Public Event OrdineSelezionato()

    Public Property IdOrdSel

    Private Sub TuttiGliOrdiniToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TuttiGliOrdiniToolStripMenuItem.Click
        'Dim Ris As FunctionICanRis = FormerLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.PreRefine)
        'If Ris.ICan Then
        'If MessageBox.Show("Confermi l'export dei sorgenti di tutti gli ordini in stato Preinserito?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        EstraiOrdini()
        '    End If
        'Else
        'If Ris.IsLockedByAnother Then
        'MessageBox.Show("La funzione è già bloccata sulla postazione " & Ris.LockedBy.Postazione.ToUpper & " da '" & Ris.LockedBy.Utente.Login & "'")
        'Else
        'MessageBox.Show("La funzione non è stata bloccata. Utilizzare il FunctionLock nel menù principale")
        'End If
        'End If
    End Sub

    Private Function OrdiniDaEsportare(Optional LstStati As String = "",
                                       Optional SoloNonFatturabili As Boolean = False) As List(Of OrdineRicerca)
        Dim ris As List(Of OrdineRicerca) = Nothing

        Using mgr As New OrdiniDAO

            If LstStati.Length = 0 Then
                LstStati = enStatoOrdine.Preinserito
            End If

            ris = mgr.Lista(, LstStati, , , , , , , , , , , , , True,,,,,,,,,,,,,, SoloNonFatturabili)
            'ris.Sort(AddressOf Comparer)
            If SoloNonFatturabili Then
                ris = ris.FindAll(Function(x) x.Fatturabile = False)
                ris = ris.GroupBy(Function(r) r.IdRub).Select(Function(x) x.FirstOrDefault).ToList
                ris.Sort(Function(x, y) y.IdOrd.CompareTo(x.IdOrd))
            Else
                ris.Sort(Function(x, y) x.IdOrd.CompareTo(y.IdOrd))
            End If

        End Using

        Return ris
    End Function

    Private Sub EstraiOrdini(Optional LSpec As List(Of OrdineRicerca) = Nothing,
                                              Optional CreaFileTodo As Boolean = True)

        'esporto i sorgenti di tutti gli ordini in una cartella centralizzata
        'FormerEsercizio\OrdiniDaVerificare
        Dim PathFinale As String = FormerConfig.FormerPath.PathOrdiniDaVerificare
        Dim L As List(Of OrdineRicerca) = Nothing

        If LSpec Is Nothing Then
            L = OrdiniDaEsportare()
        Else
            L = LSpec
        End If

        'qui ho tutti gli ordini da esportare
        'che siano uno o tanti

        If L.Count Then
            'qui devo vedere se ci sono lock 
            Dim Check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, L)

            If Check.ICan Then

                MgrOrderLock.Lock(PostazioneCorrente.UtenteConnesso.IdUt,
                                L,
                                enFunctionLock.PreRefine)

                For Each Ord As OrdineRicerca In L
                    Application.DoEvents()
                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, Ord.IdOrd, "Estratti sorgenti in PreRefine da " & PostazioneCorrente.UtenteConnesso.Login)
                    For Each sorg As FileSorgente In Ord.ListaSorgenti
                        Dim Dest As String = PathFinale & FormerLib.FormerHelper.File.EstraiNomeFile(sorg.FilePath)
                        'qui devo controllare se il sorgente c'e' già e in caso ci sia se è più recente di quello che sto copiando
                        Dim Copia As Boolean = False
                        If IO.File.Exists(Dest) Then
                            Dim FOrig As New IO.FileInfo(sorg.FilePath)
                            Dim FNew As New IO.FileInfo(Dest)

                            'qui se la data di ultima modifica del file vecchio e nuovo sono differenti metto AlmenoUnSorgenteModificato a true 
                            Dim differenza As Integer = DateDiff(DateInterval.Second, FNew.LastWriteTime, FOrig.LastWriteTime)

                            If differenza > 0 Then
                                Copia = True
                            End If
                        Else
                            Copia = True
                        End If
                        If Copia Then MgrIO.FileCopia(Me.ParentFormEx, sorg.FilePath, Dest)
                        Application.DoEvents()
                    Next
                Next

                If CreaFileTodo Then
                    Dim PathLog As String = String.Empty
                    PathLog = PathFinale & "todo.txt"

                    Dim Buffer As String = String.Empty ' "ORDINE" & ControlChars.Tab & "FILE" & ControlChars.Tab & "DIMENSIONE ATTUALE" & ControlChars.Tab & "DOVREBBE ESSERE" & ControlChars.NewLine

                    Buffer &= GetBufferTodo(L)

                    Using w As New StreamWriter(PathLog)
                        w.Write(Buffer)
                    End Using
                    FormerLib.FormerHelper.File.ShellExtended(PathFinale)
                End If

                AnnullaEstrazioneToolStripMenuItem.Enabled = True

            Else
                MessageBox.Show(MgrOrderLock.GetMessageLocked(Check))
            End If

        Else
            MessageBox.Show("Non ci sono ordini Preinseriti da lavorare")
        End If

    End Sub

    Private Function GetBufferTodoAmministr(L As List(Of OrdineRicerca)) As String
        Dim ris As String = String.Empty

        For Each SingO As OrdineRicerca In L
            Application.DoEvents()
            Dim TrovatoQualcosa As Boolean = False

            If SingO.Preventivo = enSiNo.No Then
                Dim ProblemiAmministrativi As String = SingO.VoceRubrica.Fatturabile
                If ProblemiAmministrativi.Length Then
                    ris &= SingO.IdOrd & " - " & ProblemiAmministrativi
                    TrovatoQualcosa = True
                End If

            End If

            If TrovatoQualcosa = False Then
                ris &= SingO.IdOrd & " - Nessun problema trovato!" & ControlChars.NewLine
            End If

        Next

        Return ris
    End Function

    Private Function GetBufferTodo(L As List(Of OrdineRicerca)) As String
        Dim ris As String = String.Empty

        For Each SingO As OrdineRicerca In L
            Application.DoEvents()
            Dim TrovatoQualcosa As Boolean = False
            If MgrPreRefineCheck.ExistThisPreRefineError(SingO.PreRefineErrorCode, enErroriPreRefine.DimensioniErrate) Then
                'qui controllo manualmente per dare un info certa
                For Each Sorg As FileSorgente In SingO.ListaSorgenti
                    Using mgr As New FileSorgentiDAO
                        Dim risCheck As RisControlloDimensioniSorgente = mgr.CheckDimensioni(Sorg)
                        If risCheck.ErroreDimensioni Then
                            TrovatoQualcosa = True
                            ris &= SingO.IdOrd & " - Dimensioni ATTUALI " & risCheck.LarghezzaRiscontrata & "x" & risCheck.AltezzaRiscontrata & "mm ; Dimensioni PREVISTE " & risCheck.LarghezzaPrevista & "x" & risCheck.AltezzaPrevista & "mm - '" & FormerLib.FormerHelper.File.EstraiNomeFile(Sorg.FilePath) & "'" & ControlChars.NewLine
                        End If
                    End Using
                Next
            End If

            If MgrPreRefineCheck.ExistThisPreRefineError(SingO.PreRefineErrorCode, enErroriPreRefine.ModelloNonPresente) Then
                TrovatoQualcosa = True

                If MgrPreRefineCheck.GetNumeroModelliPerFormatoProdotto(SingO.ListinoBase) = 0 Then
                    ris &= SingO.IdOrd & " - Non è presente un modello commessa con il formato prodotto singolo '" & SingO.ListinoBase.FormatoProdotto.Formato.ToUpper & "' " & IIf(SingO.ListinoBase.ColoreStampa.FR, "Fronte/Retro", "Solo Fronte") & ControlChars.NewLine
                End If

            End If

            If MgrPreRefineCheck.ExistThisPreRefineError(SingO.PreRefineErrorCode, enErroriPreRefine.NumeroSorgentiErrato) Then
                Dim SorgPrevisti As Integer = MgrPreRefineCheck.GetNumeroSorgentiPrevistiOrdine(SingO)
                If SorgPrevisti <> SingO.ListaSorgenti.Count Then
                    TrovatoQualcosa = True
                    ris &= SingO.IdOrd & " - Il numero di file sorgenti (" & SingO.ListaSorgenti.Count & ") è diverso da quello previsto (" & SorgPrevisti & ")" & ControlChars.NewLine
                End If
            End If

            For Each S As FileSorgente In SingO.ListaSorgenti
                If S.StatoRefine = enStatoRefineSorgente.CompletatoErrore Then
                    TrovatoQualcosa = True
                    ris &= SingO.IdOrd & " - Il sorgente di pagina " & S.NumPagina & " è in andato in errore nel Refine Automatico" & ControlChars.NewLine
                End If
            Next

            If TrovatoQualcosa = False Then
                ris &= SingO.IdOrd & " - Nessun problema! Archiviare" & ControlChars.NewLine
            End If

        Next

        Return ris
    End Function

    Private Sub EstraiOrdiniSelezionati()
        If dgOrdini.SelectedRows.Count Then
            If MessageBox.Show("Confermi l'export dei sorgenti dell'ordine selezionato?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim ListOrd As New List(Of OrdineRicerca)

                For Each singRow In dgOrdini.SelectedRows
                    Dim O As OrdineRicerca = dgOrdini.SelectedRows(0).DataBoundItem
                    ListOrd.Add(O)
                Next

                EstraiOrdini(ListOrd)

            End If
        End If
    End Sub

    Private Sub OrdineSelezionatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdineSelezionatoToolStripMenuItem.Click
        'Dim Ris As FunctionICanRis = FormerLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.PreRefine)
        'If Ris.ICan Then
        EstraiOrdiniSelezionati()
        'Else
        'If Ris.IsLockedByAnother Then
        'MessageBox.Show("La funzione è già bloccata sulla postazione " & Ris.LockedBy.Postazione.ToUpper & " da '" & Ris.LockedBy.Utente.Login & "'")
        'Else
        'MessageBox.Show("La funzione non è stata bloccata. Utilizzare il FunctionLock nel menù principale")
        'End If
        'End If

    End Sub

    Private Sub ArchiviaOrdini()

        Dim l As List(Of OrdineRicerca) = OrdiniDaEsportare()
        Dim lToVerify As New List(Of OrdineRicerca)
        Dim AlmenoUnoDaRefine As Boolean = False
        For Each O As OrdineRicerca In l
            Application.DoEvents()
            'qui controllo se questo ordine deve essere verificato
            Dim NewPreRefineErrorCode As enErroriPreRefine = FormerEnum.enErroriPreRefine.Nessuno
            Dim RisVal As ValidationOrderResult = Nothing

            'If MgrPreRefineCheck.ExistThisPreRefineError(O.PreRefineErrorCode, enErroriPreRefine.DimensioniErrate) Then
            'qui devo controllare i sorgenti 
            Dim AlmenoUnSorgenteModificato As Boolean = False
            For Each S As FileSorgente In O.ListaSorgenti
                Dim PathToCheck As String = FormerConfig.FormerPath.PathOrdiniDaVerificare & FormerLib.FormerHelper.File.EstraiNomeFile(S.FilePath)

                If IO.File.Exists(PathToCheck) Then
                    Dim FOrig As New IO.FileInfo(S.FilePath)
                    Dim FNew As New IO.FileInfo(PathToCheck)

                    'qui se la data di ultima modifica del file vecchio e nuovo sono differenti metto AlmenoUnSorgenteModificato a true 
                    Dim differenza As Integer = DateDiff(DateInterval.Second, FOrig.LastWriteTime, FNew.LastWriteTime)

                    If differenza > 0 Then
                        AlmenoUnSorgenteModificato = True
                    End If
                Else
                    'OrdineLavorato = False 'questo lo metto in caso non ci sia più un sorgente che dovrebbe esserci
                    Exit For
                End If
            Next
            If AlmenoUnSorgenteModificato = True Then
                'qui ho trovato i sorgenti e qualcosa e' stato lavorato
                'sostituisco i sorgenti originali
                'rifaccio la validazione
                'se tutto ok li passo a refine automatico
                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "Archiviati sorgenti in PreRefine da " & PostazioneCorrente.UtenteConnesso.Login)
                For Each S As FileSorgente In O.ListaSorgenti

                    Application.DoEvents()
                    Dim PathToCheck As String = FormerConfig.FormerPath.PathOrdiniDaVerificare & FormerLib.FormerHelper.File.EstraiNomeFile(S.FilePath)
                    MgrIO.FileSposta(Me.ParentFormEx, PathToCheck, S.FilePath)

                Next
            Else
                For Each S As FileSorgente In O.ListaSorgenti
                    Dim PathToCheck As String = FormerConfig.FormerPath.PathOrdiniDaVerificare & FormerLib.FormerHelper.File.EstraiNomeFile(S.FilePath)
                    If IO.File.Exists(PathToCheck) Then
                        Try
                            MgrFormerIO.FileDelete(PathToCheck)
                        Catch ex As Exception
                            ManageError(ex)
                        End Try

                    End If
                Next
            End If
            Application.DoEvents()
            RisVal = FormerValidator.ValidaOrdineInterno(O)
            'Else
            'RisVal = New ValidationOrderResult
            'End If

            NewPreRefineErrorCode = MgrPreRefineCheck.CheckOrder(RisVal, O.ListinoBase, O.ListaSorgenti.Count, O.NFogli, O.TipoRetro)

            O.PreRefineErrorCode = NewPreRefineErrorCode
            O.Save()

            If NewPreRefineErrorCode = enErroriPreRefine.Nessuno Then
                'qui ha passato la validazione interna
                'lo metto in refine automatico

                Using mgr As New OrdiniDAO
                    mgr.InserisciLog(O, enStatoOrdine.RefineAutomatico, PostazioneCorrente.UtenteConnesso.IdUt)
                    AlmenoUnoDaRefine = True
                End Using
            End If
        Next

        'annullo il lock
        MgrOrderLock.UnlockAll(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.PreRefine)

        'elimino il file todo
        Try
            MgrFormerIO.FileDelete(FormerConfig.FormerPath.PathOrdiniDaVerificare & "todo.txt")
        Catch ex As Exception
            'ManageError(ex)
        End Try
        If AlmenoUnoDaRefine Then MgrOrdini.ForzaEsecuzioneRefineAutomaticoDemone()
        CaricaOrdini()
    End Sub

    Private Sub ArchiviaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchiviaToolStripMenuItem.Click
        'Dim Ris As FunctionICanRis = FormerLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.PreRefine)
        'If Ris.ICan Then
        If MessageBox.Show("Vuoi archiviare le modifiche fatte ai sorgenti degli ordini estratti? Gli ordini che supereranno la validazione passeranno alla fase di Refine automatico", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ArchiviaOrdini()
        End If
        'Else
        'If Ris.IsLockedByAnother Then
        'MessageBox.Show("La funzione è già bloccata sulla postazione " & Ris.LockedBy.Postazione.ToUpper & " da '" & Ris.LockedBy.Utente.Login & "'")
        'Else
        'MessageBox.Show("La funzione non è stata bloccata. Utilizzare il FunctionLock nel menù principale")
        'End If
        'End If
    End Sub

    Private Sub CosaCèDaFareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CosaCèDaFareToolStripMenuItem.Click
        CaricaOrdini()
        ParentFormEx.Sottofondo()
        Using f As New frmTextShow
            Dim l As List(Of OrdineRicerca) = OrdiniDaEsportare()
            f.Carica(GetBufferTodo(l))
        End Using
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub RiapriOrdine(Sender As DataGridView)
        If Sender.SelectedRows.Count Then
            'riapro l'ordine in modifica
            Dim rig As DataGridViewRow
            Dim RigaSel As Integer = Sender.SelectedRows(0).Index

            If RigaSel <> -1 Then
                rig = Sender.Rows(RigaSel)
                rig.Selected = True
                Sender.Select()

                Dim O As Ordine = Sender.SelectedRows(0).DataBoundItem
                IdOrdSel = O.IdOrd

                Using frmRif As New frmOrdine

                    Dim Ris As Integer = 0
                    ParentFormEx.Sottofondo()
                    Ris = frmRif.Carica(IdOrdSel)
                    ParentFormEx.Sottofondo()

                End Using

            End If
        End If
    End Sub

    Private Sub dgOrdini_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgOrdini.MouseDoubleClick, dgOrdiniAmministr.MouseDoubleClick

        RiapriOrdine(sender)

    End Sub

    Private Sub AdattaADimensioniFormato()
        If dgOrdini.SelectedRows.Count Then
            Dim O As OrdineRicerca = dgOrdini.SelectedRows(0).DataBoundItem

            'qui devo vedere se ho estratto e locckato l'ordine
            Dim Check As Boolean = MgrOrderLock.IsLockedByMe(O.IdOrd, PostazioneCorrente.UtenteConnesso.IdUt)
            If Check Then
                If MessageBox.Show("Vuoi espandere le dimensioni dei sorgenti dell'ordine " & O.IdOrd & " al formato previsto?", "Adatta dimensioni", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim rig As DataGridViewRow = dgOrdini.SelectedRows(0)
                    rig.Selected = True
                    dgOrdini.Select()
                    Dim AlmenoUnSorgenteModificato As Boolean = False

                    Using mgr As New FileSorgentiDAO
                        For Each sorg As FileSorgente In O.ListaSorgenti
                            Dim FilePathSorg As String = FormerConfig.FormerPath.PathOrdiniDaVerificare & FormerHelper.File.EstraiNomeFile(sorg.FilePath)
                            Dim checkVal As RisControlloDimensioniSorgente = mgr.CheckDimensioni(O.ListinoBase,
                                                                                                 FilePathSorg,
                                                                                                 O.Largo,
                                                                                                 O.Lungo)

                            If checkVal.ErroreDimensioni Then
                                'qui devo controllare che il formato prodotto sia piu grande del formato trovato
                                If checkVal.AltezzaPrevista >= checkVal.AltezzaRiscontrata AndAlso checkVal.LarghezzaPrevista >= checkVal.LarghezzaRiscontrata Then
                                    'qui devo fare qualcosa 
                                    AlmenoUnSorgenteModificato = True
                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "Espandi dimensioni effettuato. Sorgente '" & sorg.FilePath & "' Dimensioni originali: " & checkVal.LarghezzaRiscontrata & "x" & checkVal.AltezzaRiscontrata & " Dimensioni nuove: " & checkVal.LarghezzaPrevista & "x" & checkVal.AltezzaPrevista & " Operatore: " & PostazioneCorrente.UtenteConnesso.Login)
                                    Dim RisResize As Integer = FormerLib.FormerHelper.PDF.ResizePDF(FilePathSorg,
                                                                                                    checkVal.LarghezzaPrevista,
                                                                                                    checkVal.AltezzaPrevista)
                                    If RisResize Then
                                        MessageBox.Show("Si è verificato un errore nel resize del file " & FilePathSorg)
                                    End If
                                    'Else
                                    '    'qui non posso fare niente poi vediamo
                                End If
                            End If

                        Next
                    End Using

                    If AlmenoUnSorgenteModificato = False Then
                        MessageBox.Show("Non ci sono file sorgenti da adattare al formato prodotto previsto. Ricorda che i sorgenti possono essere adattati solo a un formato piu grande delle dimensioni attuali del file sorgente.")
                    Else
                        FormerLib.FormerHelper.File.ShellExtended(FormerConfig.FormerPath.PathOrdiniDaVerificare)
                        '    MessageBox.Show("I sorgenti sono stati adattati")
                    End If

                End If
            Else
                MessageBox.Show("Prima di modificare un ordine devi estrarlo!")
            End If
        Else
            Beep()
        End If
    End Sub

    Private Sub StretchADimensioniFormato()
        If dgOrdini.SelectedRows.Count Then
            Dim O As OrdineRicerca = dgOrdini.SelectedRows(0).DataBoundItem

            'qui devo vedere se ho estratto e locckato l'ordine
            Dim Check As Boolean = MgrOrderLock.IsLockedByMe(O.IdOrd, PostazioneCorrente.UtenteConnesso.IdUt)
            If Check Then
                If MessageBox.Show("Vuoi stretchare le dimensioni dei sorgenti dell'ordine " & O.IdOrd & " al formato previsto?", "Stretch dimensioni", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim rig As DataGridViewRow = dgOrdini.SelectedRows(0)
                    rig.Selected = True
                    dgOrdini.Select()
                    Dim AlmenoUnSorgenteModificato As Boolean = False

                    Using mgr As New FileSorgentiDAO
                        For Each sorg As FileSorgente In O.ListaSorgenti
                            Dim FilePathSorg As String = FormerConfig.FormerPath.PathOrdiniDaVerificare & FormerHelper.File.EstraiNomeFile(sorg.FilePath)
                            Dim checkVal As RisControlloDimensioniSorgente = mgr.CheckDimensioni(O.ListinoBase,
                                                                                                 FilePathSorg,
                                                                                                 O.Largo,
                                                                                                 O.Lungo)

                            If checkVal.ErroreDimensioni Then
                                'qui devo controllare che il formato prodotto sia piu grande del formato trovato
                                If checkVal.AltezzaPrevista <> checkVal.AltezzaRiscontrata OrElse checkVal.LarghezzaPrevista <> checkVal.LarghezzaRiscontrata Then
                                    'qui devo fare qualcosa 
                                    AlmenoUnSorgenteModificato = True
                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "Stretch dimensioni effettuato. Sorgente '" & sorg.FilePath & "' Dimensioni originali: " & checkVal.LarghezzaRiscontrata & "x" & checkVal.AltezzaRiscontrata & " Dimensioni nuove: " & checkVal.LarghezzaPrevista & "x" & checkVal.AltezzaPrevista & " Operatore: " & PostazioneCorrente.UtenteConnesso.Login)
                                    'qui prim aallego il sorgente come altro file all'ordine

                                    Dim RisResize As Integer = FormerLib.FormerHelper.PDF.ResizePDF(FilePathSorg,
                                                                                                    checkVal.LarghezzaPrevista,
                                                                                                    checkVal.AltezzaPrevista,
                                                                                                    ,
                                                                                                    True)
                                    If RisResize Then
                                        MessageBox.Show("Si è verificato un errore nel resize del file " & FilePathSorg)
                                    End If
                                    'Else
                                    '    'qui non posso fare niente poi vediamo
                                End If
                            End If

                        Next
                    End Using

                    If AlmenoUnSorgenteModificato = False Then
                        MessageBox.Show("Non ci sono file sorgenti da stretchare al formato prodotto previsto.")
                    Else
                        FormerLib.FormerHelper.File.ShellExtended(FormerConfig.FormerPath.PathOrdiniDaVerificare)
                        '    MessageBox.Show("I sorgenti sono stati adattati")
                    End If

                End If
            Else
                MessageBox.Show("Prima di modificare un ordine devi estrarlo!")
            End If
        Else
            Beep()
        End If
    End Sub

    Private Sub AdattaADimensioniFormatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdattaADimensioniFormatoToolStripMenuItem.Click
        AdattaADimensioniFormato()
    End Sub

    Private Sub ApriCartellaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriCartellaToolStripMenuItem.Click
        FormerHelper.File.ShellExtended(FormerConfig.FormerPath.PathOrdiniDaVerificare)
    End Sub

    Private Sub dgOrdini_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgOrdini.CellContentClick

    End Sub

    Private Sub ApriToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriToolStripMenuItem.Click
        RiapriOrdine(dgOrdini)
    End Sub

    Private Sub CosaCèDaFareToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CosaCèDaFareToolStripMenuItem1.Click
        If dgOrdini.SelectedRows.Count Then
            'riapro l'ordine in modifica
            Dim rig As DataGridViewRow
            Dim RigaSel As Integer = dgOrdini.SelectedRows(0).Index

            If RigaSel <> -1 Then
                rig = dgOrdini.Rows(RigaSel)
                rig.Selected = True
                dgOrdini.Select()

                Dim O As Ordine = dgOrdini.SelectedRows(0).DataBoundItem
                Dim L As New List(Of OrdineRicerca)
                L.Add(O)
                ParentFormEx.Sottofondo()
                Using f As New frmTextShow
                    f.Carica(GetBufferTodo(L))
                End Using
                ParentFormEx.Sottofondo()

            End If
        End If
    End Sub

    Private Sub EstraiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstraiToolStripMenuItem.Click
        'Dim Ris As FunctionICanRis = FormerLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.PreRefine)
        'If Ris.ICan Then
        EstraiOrdiniSelezionati()
        'Else
        'If Ris.IsLockedByAnother Then
        'MessageBox.Show("La funzione è già bloccata sulla postazione " & Ris.LockedBy.Postazione.ToUpper & " da '" & Ris.LockedBy.Utente.Login & "'")
        'Else
        'MessageBox.Show("La funzione non è stata bloccata. Utilizzare il FunctionLock nel menù principale")
        'End If
        'End If
    End Sub

    Private Sub dgOrdini_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgOrdini.CellMouseClick

        If e.Button = MouseButtons.Right AndAlso e.RowIndex <> -1 Then
            If dgOrdini.Rows.Count Then

                Dim x As System.Drawing.Point = MousePosition
                Dim row As DataGridViewRow = dgOrdini.Rows(e.RowIndex)
                row.Selected = True
                'dgOrdini.Select()

                mnuOrdine.Show(x)

            End If
        End If

    End Sub

    Private Sub ForzaARefineAutomatico()
        If dgOrdini.SelectedRows.Count Then
            Dim L As New List(Of Ordine)
            Dim O As OrdineRicerca = dgOrdini.SelectedRows(0).DataBoundItem
            L.Add(O)
            Dim Check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, L)

            If Check.ICan Then
                If MessageBox.Show("Vuoi forzare il passaggio dell'ordine a REFINE AUTOMATICO bypassando i controlli di verifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "Forzato passaggio a REFINE AUTOMATICO. PreRefineErrorCode: " & O.PreRefineErrorCode & " - Operatore " & PostazioneCorrente.UtenteConnesso.Login)
                    Using mgr As New OrdiniDAO
                        mgr.InserisciLog(O.IdOrd, enStatoOrdine.RefineAutomatico)
                    End Using

                    MgrOrdini.ForzaEsecuzioneRefineAutomaticoDemone()

                    CaricaOrdini()

                End If
            Else
                MessageBox.Show(MgrOrderLock.GetMessageLocked(Check))
            End If


        End If
    End Sub

    Private Sub ForzaARegistratoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForzaARegistratoToolStripMenuItem.Click
        ForzaARefineAutomatico
    End Sub

    Private Sub AnnullaEstrazioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnullaEstrazioneToolStripMenuItem.Click

        If MgrOrderLock.HoOrdiniLocked(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.PreRefine).Count Then
            If MessageBox.Show("Vuoi annullare l'estrazione degli ordini che avevi estratto?", "Estrazione ordini", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MgrOrderLock.UnlockAll(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.PreRefine)
                AnnullaEstrazioneToolStripMenuItem.Enabled = False
            End If
        Else
            Beep() 'qui non dovrebbe mai entrare
        End If

    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs)
        CaricaOrdini()
    End Sub

    Private Sub StretchDimensioniSorgentiAFormatoPrevistoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StretchDimensioniSorgentiAFormatoPrevistoToolStripMenuItem.Click
        StretchADimensioniFormato()
    End Sub

    Private Sub EseguiRefineAutomaticoSulDemoneToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'MessageBox.Show("Elaborazione ordini in Refine automatico richiesta al demone")
    End Sub

    Private Sub mnuToDoAmministr_Click(sender As Object, e As EventArgs) Handles mnuToDoAmministr.Click
        TodoAmministr()
    End Sub

    Private Sub mnuAggiornaAmministr_Click(sender As Object, e As EventArgs) Handles mnuAggiornaAmministr.Click
        AggiornaAmministr
    End Sub

    Private Sub AggiornaAmministr()
        Cursor.Current = Cursors.WaitCursor
        'Dim Ris As Integer = 0

        Using mgr As New OrdiniDAO
            'Dim LstStati As String = enStatoOrdine.RefineAutomatico & "," & enStatoOrdine.Preinserito
            Dim LNoUtil As List(Of OrdineRicerca) = OrdiniDaEsportare(StatiOrdiniAmministr, True)

            'LNoUtil = mgr.Lista(, LstStati, , True, , , , , , , , , , , True, )
            'LNoUtil.Sort(AddressOf Comparer)

            'L = L.FindAll(Function(x) x.IdListinoBase <> 0)
            dgOrdiniAmministr.AutoGenerateColumns = False
            dgOrdiniAmministr.DataSource = LNoUtil

            dgOrdiniAmministr.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdiniAmministr.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdiniAmministr.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdiniAmministr.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdiniAmministr.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Ris = LNoUtil.FindAll(Function(x) x.Stato = enStatoOrdine.Preinserito).Count
        End Using

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub TodoAmministr()
        AggiornaAmministr()
        ParentFormEx.Sottofondo()
        Using f As New frmTextShow
            Dim l As List(Of OrdineRicerca) = OrdiniDaEsportare(StatiOrdiniAmministr, True)
            f.Carica(GetBufferTodoAmministr(l))
        End Using
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub ApriSchedaClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriSchedaClienteToolStripMenuItem.Click
        If dgOrdiniAmministr.SelectedRows.Count Then
            Dim O As OrdineRicerca = dgOrdiniAmministr.SelectedRows(0).DataBoundItem

            ParentFormEx.Sottofondo()

            Using f As New frmVoceRubrica
                f.Carica(O.IdRub)
            End Using

            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub ApriOrdineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriOrdineToolStripMenuItem.Click
        RiapriOrdine(dgOrdiniAmministr)
    End Sub

    Private Sub ForzaARefineAutomaticoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForzaARefineAutomaticoToolStripMenuItem.Click
        ForzaARefineAutomatico()
    End Sub
End Class
