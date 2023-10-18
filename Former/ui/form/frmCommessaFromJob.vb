Imports System.IO
Imports FormerConfig
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerBusinessLogic
Imports FormerIO

Friend Class frmCommessaFromJob
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private Sub CaricaCombo()

        Using M As New MacchinariDAO
            cmbMacchinari.ValueMember = "IdMacchinario"
            cmbMacchinari.DisplayMember = "Descrizione"
            Dim so As New LUNA.LunaSearchOption With {.AddEmptyItem = True, .OrderBy = "Descrizione"}
            cmbMacchinari.DataSource = M.FindAll(so, New LUNA.LunaSearchParameter(LFM.Macchinario.Tipo, enTipoMacchinario.Produzione))
        End Using

    End Sub

    Friend Function Carica() As Integer

        lblReparto.BackColor = FormerColori.GetColoreReparto(enRepartoWeb.StampaOffset)
        lblReparto.Text = FormerEnumHelper.RepartoStr(enRepartoWeb.StampaOffset)
        lblReparto.ForeColor = Color.White

        CaricaCombo()

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

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnJob_Click(sender As Object, e As EventArgs) Handles btnJob.Click

        dlgFile.Filter = "File JOB|*.job"
        dlgFile.InitialDirectory = FormerConfig.FormerPath.PathGanging
        If dlgFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFileJob.Text = dlgFile.FileName
            _Interpretato = False
        End If
    End Sub

    Private Function InterpretaJob(Path As String) As RisInterpretazioneJob

        Cursor.Current = Cursors.WaitCursor

        Dim Ris As New RisInterpretazioneJob

        'Dim ListaFile As New List(Of FileTrovatoNelJobRis)
        'interpreto il job e torno una collezione di path
        '"%SSiJobDelivery
        '%SSiJobFileRef riga file
        'riempio anche il numero di segnature trovate
        Dim TotSegnature As Integer = 0
        Dim CounterPressSheetTrovate As Integer = 0
        Using r As New StreamReader(Path)
            Dim LastIdPageRead As Integer = 0
            While r.EndOfStream = False
                Dim Riga As String = r.ReadLine

                If Riga.StartsWith("%SSiJobFileRef") Then
                    Dim posInizio As Integer = Riga.IndexOf("file:")
                    If posInizio <> -1 Then

                        Dim posfine As Integer = Riga.IndexOf("'", posInizio)
                        Dim PathTrovato As String = Riga.Substring((posInizio + 5), (posfine - posInizio - 5))
                        PathTrovato = PathTrovato.Replace("/", "\")
                        Dim PathToFind As String = FormerHelper.File.GetMappedDrivePath(PathTrovato)

                        'TODO:RIMUOVERE
                        If FormerDebug.DebugAttivo Then PathToFind = PathToFind.Replace("W:\", "Z:\")

                        Dim FtNelJ As New RisFileTrovatoNelJob
                        FtNelJ.Path = PathToFind
                        posfine = posInizio
                        posInizio = Riga.IndexOf(":")

                        Dim IdFile As String = Riga.Substring(posInizio + 1, posfine - posInizio - 2)
                        FtNelJ.Id = IdFile

                        Ris.ListaFile.Add(FtNelJ)
                    End If
                ElseIf Riga.StartsWith("%SSiJobDelivery") Then
                    TotSegnature += 1
                ElseIf Riga.StartsWith("%SSiJobPage:") Then
                    Dim posInizio As Integer = Riga.IndexOf(":")
                    Dim posfine As Integer = Riga.IndexOf(" ", posInizio + 2)
                    Dim IdFile As String = Riga.Substring(posInizio + 1, posfine - posInizio - 1)
                    LastIdPageRead = IdFile
                ElseIf Riga.StartsWith("%SSiJobPageExtendInfo:") Then
                    If LastIdPageRead <> -1 Then
                        Dim posInizio As Integer = Riga.LastIndexOf("'")
                        Dim IdFileRiassegnato As Integer = Riga.Substring(posInizio + 1)
                        Ris.ListaFile.Find(Function(x) x.Id = LastIdPageRead).IdRiAssegnato = IdFileRiassegnato
                    End If
                ElseIf Riga.StartsWith("%SSiPressSheet:") Then
                    CounterPressSheetTrovate += 1

                    If CounterPressSheetTrovate = 2 Then
                        'qui devo andare a interpretare le dimensioni 
                        Dim posizStart As Integer = Riga.IndexOf(" ", "SSiPressSheet:".Length)
                        Dim posizMid As Integer = Riga.IndexOf(" ", posizStart + 1)
                        Dim posizEnd As Integer = Riga.IndexOf(" ", posizMid + 1)
                        'primo numero 

                        Dim PrimoValore As Double = Riga.Substring(posizStart, posizMid - posizStart).Replace(".", ",")
                        Dim SecondoValore As Double = Riga.Substring(posizMid, posizEnd - posizMid).Replace(".", ",")

                        Dim Base As Single = 0
                        Dim Altezza As Single = 0

                        Base = FormerLib.FormerHelper.PDF.TrasformaPointInMm(PrimoValore) / 10
                        Altezza = FormerLib.FormerHelper.PDF.TrasformaPointInMm(SecondoValore) / 10

                        'CERCO IL MACCHINARIO
                        posizStart = Riga.IndexOf("'")
                        posizEnd = Riga.IndexOf("'", posizStart + 1)

                        Dim SiglaMacchinarioTrovato As String = Riga.Substring(posizStart + 1, posizEnd - posizStart - 1)

                        Dim Parole As String() = SiglaMacchinarioTrovato.Split(" ")

                        Dim NumParole As Integer = 1
                        If Parole.Length < 2 Then
                            NumParole = 0
                        End If

                        SiglaMacchinarioTrovato = String.Empty
                        For i As Integer = 0 To NumParole
                            'sigla accorciata alle prime due parole 
                            SiglaMacchinarioTrovato &= Parole(i) & " "
                        Next

                        SiglaMacchinarioTrovato = SiglaMacchinarioTrovato.TrimEnd(" ")

                        Dim l As List(Of Formato) = Nothing

                        Dim a As New LUNA.LunaSearchParameter

                        a.FieldName = LFM.Utente.IdUt.Name

                        Using mgr As New FormatiDAO
                            l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Formato.Larghezza, Base),
                                            New LUNA.LunaSearchParameter(LFM.Formato.Altezza, Altezza))
                        End Using

                        If l.Count Then
                            'qui per ora prendo il primo anche se in realta quale devo prendere?
                            Ris.FormatoMacchina = l(0)

                            Using mgr As New FormatiSuMacchinariDAO
                                Dim lForm As List(Of FormatoSuMacchinario) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FormatoSuMacchinario.IdFormato, Ris.FormatoMacchina.IdFormato))

                                For Each FormSuMacc In lForm
                                    If FormSuMacc.Macchinario.Descrizione.ToLower.StartsWith(SiglaMacchinarioTrovato.ToLower) Then
                                        Ris.MacchinarioTrovato = FormSuMacc.Macchinario
                                        Exit For
                                    End If
                                Next

                                If Ris.MacchinarioTrovato Is Nothing Then
                                    Ris.BufferErrori &= "ALERT: Impossibile identificare un Macchinario dal file Job" & ControlChars.NewLine
                                    Ris.Alert = True
                                End If

                            End Using

                        End If

                    End If
                ElseIf Riga.StartsWith("%SSiPrshPage:") Then
                    If CounterPressSheetTrovate = 2 Then
                        Dim Valori() As String = Riga.Split(" ")
                        'in valore di 6 ho il riferimento all'id riassegnato del file
                        Dim IdRiassegnatoTrovato As Integer = Valori(6)
                        Dim IdRiassegnatoTrovatoR As Integer = Valori(7)
                        Ris.ListaIdPagine.Add(IdRiassegnatoTrovato)

                        If IdRiassegnatoTrovatoR Then Ris.ListaIdPagine.Add(IdRiassegnatoTrovatoR)
                    End If
                End If

            End While

        End Using

        Dim NewListaFile As New List(Of RisFileTrovatoNelJob)

        For Each FileTrovato As RisFileTrovatoNelJob In Ris.ListaFile
            If Ris.ListaIdPagine.FindAll(Function(x) x = FileTrovato.IdRiAssegnato).Count <> 0 Then
                NewListaFile.Add(FileTrovato)
            End If
        Next

        Ris.ListaFile = NewListaFile

        If Ris.ListaFile.Count = 0 Then
            Ris.BufferErrori &= "ERRORE: Deve essere utilizzato almeno un Ordine" & ControlChars.NewLine
            Ris.ErroriBloccanti = True
        End If

        Ris.Segnature = TotSegnature
        'Ris.ListaFile = ListaFile

        If Ris.FormatoMacchina Is Nothing Then
            Ris.BufferErrori &= "ERRORE: Impossibile identificare un Formato Macchina dal file Job" & ControlChars.NewLine
            Ris.ErroriBloccanti = True
        End If

        For Each FileTrovato As RisFileTrovatoNelJob In Ris.ListaFile
            'qui devo prendere la lista degli ordini e vedere se i file di un ordine ci sono tutti 

            'ora cerco il sorgente 
            Using mgr As New FileSorgentiDAO
                Dim NomeToSearch As String = FormerHelper.File.EstraiNomeFile(FileTrovato.Path)

                Dim lSorg As List(Of FileSorgente) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FileSorgente.FilePath, "%\" & NomeToSearch, "LIKE"))
                If lSorg.Count Then
                    Dim IdOrd As Integer = lSorg(0).IdOrd
                    FileTrovato.IdOrdineRif = IdOrd
                    If Ris.ListaOrdini.FindAll(Function(x) x.IdOrd = IdOrd).Count = 0 Then
                        Using O As New Ordine
                            O.Read(IdOrd)
                            Ris.ListaOrdini.Add(O)

                        End Using
                    End If

                Else
                    Ris.BufferErrori &= "ERRORE: Non riesco a identificare l'ordine del file '" & FileTrovato.Path & "'" & ControlChars.NewLine
                    Ris.ErroriBloccanti = True
                End If
            End Using

            If FormerHelper.File.IsFileLocked(FileTrovato.Path) Then
                Ris.BufferErrori &= "ERRORE: Il file '" & FileTrovato.Path & "' risulta bloccato. Controllare che non sia aperto in un altro programma." & ControlChars.NewLine
                Ris.ErroriBloccanti = True
            End If

        Next

        Array.Resize(Ris.ListaIdOrdSelezionati, Ris.ListaOrdini.Count)
        Dim Progr As Integer = 0
        Dim IdTipoCarta As Integer = 0
        For Each O As Ordine In Ris.ListaOrdini

            Ris.ListaIdOrdSelezionati.SetValue(O.IdOrd, Progr)
            Progr += 1
            'per ogni ordine ora controllo che siano stati inseriti tutti i file dentro 
            For Each S As FileSorgente In O.ListaSorgenti
                If Ris.ListaFile.FindAll(Function(x) x.Path = S.FilePath).Count = 0 Then
                    Ris.BufferErrori &= "ERRORE: Il file sorgente '" & S.FilePath & "' dell'ordine " & O.IdOrd & " non è stato utilizzato" & ControlChars.NewLine
                    Ris.ErroriBloccanti = True
                End If
            Next
            'qui devo controllare che gli ordini selezionati siano compatibili tra loro 
            If IdTipoCarta = 0 Then IdTipoCarta = O.ListinoBase.IdTipoCarta

            If O.ListinoBase.IdTipoCarta <> IdTipoCarta Then
                Ris.BufferErrori &= "ALERT: Gli ordini non sono compatibili tra loro perchè utilizzano tipi di carta differenti" & ControlChars.NewLine
                Ris.Alert = True
            End If

            'ora controllo se tutte le lavorazioni esclusive dell'ordine sono compatibili con gli altri 
            Dim lLavEscl As List(Of Lavorazione) = O.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
            For Each singO As Ordine In Ris.ListaOrdini.FindAll(Function(x) x.IdOrd <> O.IdOrd)
                Dim OkLav As Boolean = True
                For Each singLav In lLavEscl
                    If singO.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
                        OkLav = False
                        Exit For
                    End If
                Next
                If OkLav = False Then
                    Ris.BufferErrori &= "ERRORE: L'ordine " & O.IdOrd & " ha delle lavorazioni che non sono compatibili con gli altri" & ControlChars.NewLine
                    Ris.ErroriBloccanti = True
                    Exit For
                End If
            Next

            If O.Annotazioni.Length Then
                Ris.NoteGenerali &= "Ordine: " & O.IdOrd & " - " & O.Annotazioni & ";" & ControlChars.NewLine
            End If
        Next

        For Each IdRiassegnatoTrovato As Integer In Ris.ListaIdPagine
            Dim F As RisFileTrovatoNelJob = Ris.ListaFile.Find(Function(x) x.IdRiAssegnato = IdRiassegnatoTrovato)

            If Not F Is Nothing Then
                Dim O As Ordine = Ris.ListaOrdini.Find(Function(x) x.IdOrd = F.IdOrdineRif)

                If Not O Is Nothing Then
                    Dim Conteggio As Integer = 0
                    If Ris.ListaIdFormatiProdotto.TryGetValue(O.ListinoBase.IdFormProd, Conteggio) Then
                        Ris.ListaIdFormatiProdotto(O.ListinoBase.IdFormProd) += 1
                    Else
                        Ris.ListaIdFormatiProdotto.Add(O.ListinoBase.IdFormProd, 1)
                    End If
                End If
            End If

        Next

        'CONTROLLO CHE ESISTA ANCHE IL FILE JDF
        Dim FileJdfPath As String = Path.ToLower.Replace(".job", ".jdf")
        If File.Exists(FileJdfPath) = False Then
            Ris.BufferErrori &= "ERRORE: Non è presente il file JDF. Il file JDF si deve trovare nella stessa cartella del file JOB e deve avere lo stesso nome." & ControlChars.NewLine
            Ris.ErroriBloccanti = True
        End If

        'CONTROLLO CHE I FILE NON SIANO LOCCATI NEL FRATTEMPO  DA QUALCUN ALTRO
        Dim Check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, Ris.ListaOrdini)

        If Check.ICan = False Then
            Ris.ErroriBloccanti = True
            Ris.BufferErrori &= MgrOrderLock.GetMessageLocked(Check)
        End If

        'dopo aver controllato path e ordini controllo il formato prodotto dentro il tpl
        'Dim PathTpl As String = FormerPath.PathTemplateGanging & Ris.NomeModello

        'If File.Exists(PathTpl) Then

        ' Else
        ' Ris.BufferErrori &= "ERRORE: Impossibile trovare il file TPL su '" & PathTpl & "'" & ControlChars.NewLine
        'Ris.ErroriBloccanti = True
        ' End If

        'Using mgr As New CommesseDAO
        '    Ris.LastreNecessarie = mgr.GetLastreNecessarie(m, Ris.ListaIdOrdSelezionati)
        'End Using
        Cursor.Current = Cursors.Default

        Return Ris

    End Function

    Private Sub CreaCommessa()

        If PostazioneCorrente.ScaricamentoOrdiniInCorso Then
            MessageBox.Show("Il demone sta scaricando degli ordini, quindi la commessa che si sta salvando potrebbe contenere Ordini non piu disponibili")
        Else
            If txtNLastre.Text > 0 AndAlso txtQta.Text > 0 Then
                If _Interpretato Then
                    If txtFileJob.Text.Trim.Length Then
                        Dim PathFileJob As String = txtFileJob.Text
                        If cmbMacchinari.SelectedValue Then
                            If MessageBox.Show("Confermi la creazione della commessa?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Dim RisJob As RisInterpretazioneJob = InterpretaJob(PathFileJob)

                                'txtNLastre.Text = RisJob.LastreNecessarie

                                'ora dal path dei file recupero gli ordini 
                                'il modello deve essere il generico 

                                Dim CreaCommessa As Boolean = True

                                If RisJob.ErroriBloccanti Then
                                    CreaCommessa = False
                                    MessageBox.Show("Non è possibile creare la commessa per i seguenti problemi: " & ControlChars.NewLine & RisJob.BufferErrori)
                                Else
                                    If RisJob.Alert Then
                                        If MessageBox.Show("Si sono verificate le seguenti incongruenze: " & ControlChars.NewLine & RisJob.BufferErrori & "Vuoi creare comunque la commessa?", "Creazione Commessa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                            CreaCommessa = False
                                        End If
                                    End If
                                End If
                                Dim macchinario As Macchinario = cmbMacchinari.SelectedItem
                                If CreaCommessa Then

                                    Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

                                        Try

                                            tb.TransactionBegin()

                                            Dim NomeModello As String = "Ganging - "
                                            'Dim PathFileJobVuoto As String = FormerPath.PathTemplatePreps & NomeModello & ".job"
                                            Dim NumSpazi As Integer = 0
                                            Dim IsFronteRetro As Integer = enSiNo.No

                                            NumSpazi = RisJob.NumSpazi

                                            If RisJob.ListaOrdini.FindAll(Function(x) x.ListinoBase.ColoreStampa.FR = True).Count Then
                                                IsFronteRetro = enSiNo.Si
                                            End If

                                            Dim FormatiLavorati As New List(Of Integer)
                                            RisJob.ListaIdFormatiProdotto.OrderByDescending(Function(x) x.Value)

                                            For Each CounterFormati In RisJob.ListaIdFormatiProdotto
                                                Using fp As New FormatoProdotto
                                                    fp.Read(CounterFormati.Key)
                                                    NomeModello &= CounterFormati.Value & " " & fp.Formato & " "
                                                End Using
                                            Next

                                            Dim PathFileJobVuoto As String = FormerPath.PathTemplatePreps & NomeModello & ".job"

                                            'qui svuoto il file job e lo salvo li dentro 

                                            MgrIO.FileCopia(Me, PathFileJob, PathFileJobVuoto)

                                            'qui devo creare il modello commessa
                                            Dim m As New ModelloCommessa
                                            m.NumSpazi = NumSpazi
                                            m.FromGanging = enSiNo.Si
                                            m.Job = PathFileJobVuoto
                                            m.Disattivo = enSiNo.Si
                                            m.Nome = NomeModello
                                            m.IdFormatoMacchina = RisJob.FormatoMacchina.IdFormato
                                            m.IdMacchinarioDef = macchinario.IdMacchinario
                                            m.FronteRetro = IsFronteRetro
                                            m.IdReparto = enRepartoWeb.StampaOffset
                                            m.AbilitatoAutomazione = enSiNo.No
                                            m.TiraturaIdeale = 0
                                            m.RitieniOkDuplicati = enSiNo.No

                                            Dim lModComFP As New List(Of ModComFormProd)
                                            'salvo i vari formatiprodotto nel modello commessa
                                            For Each CounterFormati In RisJob.ListaIdFormatiProdotto
                                                Using fpMod As New ModComFormProd
                                                    fpMod.IdModCom = m.IdModello
                                                    fpMod.IdFormProd = CounterFormati.Key
                                                    fpMod.Spazi = CounterFormati.Value
                                                    lModComFP.Add(fpMod)
                                                End Using
                                            Next

                                            m.FormatiProdotto = lModComFP
                                            m.Save()

                                            'creo la commessa
                                            Using C As New Commessa
                                                C.FromJob = enSiNo.Si
                                                C.CreataAutomaticamente = enSiNo.No
                                                C.Stato = enStatoCommessa.Preinserito
                                                C.IdReparto = enRepartoWeb.StampaOffset
                                                C.ListaIdOrdini = RisJob.ListaIdOrdSelezionati
                                                C.TipoCom = C.IdReparto
                                                C.Copie = txtQta.Text
                                                C.Segnature = RisJob.Segnature
                                                C.IdModelloCommessa = m.IdModello
                                                C.IdFormato = RisJob.FormatoMacchina.IdFormato
                                                C.IdModelloCommessa = m.IdModello

                                                Using mgr As New CommesseDAO
                                                    C.Riassunto = mgr.GetNomeRiassuntivo(C.ListaIdOrdini)
                                                End Using
                                                C.NLastreNecessarie = txtNLastre.Text
                                                C.Annotazioni = RisJob.NoteGenerali
                                                C.IdUtCreatore = PostazioneCorrente.UtenteConnesso.IdUt

                                                If RisJob.ListaOrdini.FindAll(Function(x) x.ListinoBase.ColoreStampa.FR = True).Count > 0 Then
                                                    C.FronteRetro = enSiNo.Si
                                                Else
                                                    C.FronteRetro = enSiNo.No
                                                End If

                                                'Using M As Macchinario = DirectCast(cmbMacchinari.SelectedItem, Macchinario)
                                                C.IdMacchinario = macchinario.IdMacchinario
                                                C.MacchinaStampa = macchinario.Descrizione

                                                Using mgr As New RisorseDAO
                                                    Dim rislastra As Risorsa = mgr.GetLastraPerMacchinario(macchinario.IdMacchinario)

                                                    If Not rislastra Is Nothing Then
                                                        C.IdRis = rislastra.IdRis
                                                    End If

                                                End Using

                                                'End Using
                                                'C.ModificataListaLav = True
                                                Using mgr As New CommesseDAO
                                                    Dim lMov As New List(Of MovimentoMagazzino)

                                                    Dim RisorsaPredef As List(Of Risorsa) = mgr.GetRisorsaDefault(RisJob.ListaIdOrdSelezionati, C.ModelloCommessa)

                                                    For Each R In RisorsaPredef
                                                        Dim mov As New MovimentoMagazzino
                                                        mov.IdRis = R.IdRis
                                                        mov.Qta = mgr.CalcolaQtaRisorsaNecessaria(C.IdReparto,
                                                                                              C.IdFormato,
                                                                                              C.Copie,
                                                                                              R.IdRis)
                                                        mov.TipoMov = enTipoMovMagaz.Prenotazione
                                                        mov.DataMov = Date.Now
                                                        mov.IdUt = PostazioneCorrente.UtenteConnesso.IdUt

                                                        lMov.Add(mov)
                                                    Next

                                                    C.MovMagaz = lMov
                                                End Using

                                                C.Save()

                                                'la passo pronta
                                                Using mC As New CommesseDAO
                                                    mC.InserisciLog(C, enStatoCommessa.Preinserito,
                                                               PostazioneCorrente.UtenteConnesso.IdUt)

                                                    mC.SalvaOrdiniTornaEsclusi(C)
                                                    mC.SalvaMovMagaz(C)
                                                    mC.InserisciLavorazioni(C)

                                                    'mC.InserisciLog(C, enStatoCommessa.Pronto, PostazioneCorrente.UtenteConnesso.IdUt)
                                                End Using

                                                tb.TransactionCommit() 'Committo la transazione

                                                'sposto i file
                                                Dim RisSalvataggio As Integer = MgrCommesse.SalvaFile(C)

                                                'copio il file JOB e il file JDF alla cartella della commessa
                                                Dim PathCommessa As String = FormerPath.PathCommesse & C.IdCom & "\"
                                                Dim OldPathJdfMarksFlats As String = FormerHelper.File.GetFolder(PathFileJob) & "\JDFMarksFlats\"
                                                Dim PathJdfMarksFlats As String = PathCommessa & "JDFMarksFlats\"

                                                FormerHelper.File.CreateLongPath(PathJdfMarksFlats)

                                                Dim NomeFileJdfMarksFlats As String = PathFileJob.Replace(".job", ".pdf")
                                                NomeFileJdfMarksFlats = FormerLib.FormerHelper.File.EstraiNomeFile(NomeFileJdfMarksFlats)
                                                Dim OldNomeFileJdfMarksFlats As String = NomeFileJdfMarksFlats
                                                OldNomeFileJdfMarksFlats = OldPathJdfMarksFlats & OldNomeFileJdfMarksFlats
                                                NomeFileJdfMarksFlats = PathJdfMarksFlats & NomeFileJdfMarksFlats

                                                MgrIO.FileCopia(Me,
                                                          OldNomeFileJdfMarksFlats,
                                                          NomeFileJdfMarksFlats)

                                                'Dim D As New DirectoryInfo(OldPathJdfMarksFlats)
                                                'For Each Singfile In D.GetFiles("*.pdf")
                                                '    MgrIO.FileCopia(Me, Singfile.FullName, PathJdfMarksFlats & Singfile.Name)
                                                'Next

                                                Dim PathFileJdf As String = PathFileJob.ToLower.Replace(".job", ".jdf")
                                                Dim NewFileJob As String = PathCommessa & C.IdCom & ".job"
                                                Dim NewFileJdf As String = PathCommessa & C.IdCom & ".jdf"

                                                MgrIO.FileCopia(Me, PathFileJob, NewFileJob)
                                                MgrIO.FileCopia(Me, PathFileJdf, NewFileJdf)

                                                PathJdfMarksFlats &= FormerLib.FormerHelper.File.EstraiNomeFile(PathFileJob).ToLower.Replace(".job", ".pdf")

                                                'ora vado a modificare dentro i file mettendo i path corretti degli ordini 
                                                TrasformaPathJob(NewFileJob,
                                                                 RisJob)
                                                TrasformaPathJdf(NewFileJdf,
                                                                 RisJob,
                                                                 PathJdfMarksFlats)

                                                'creo anteprima
                                                MgrCommesse.CreaAnteprima(Me, C.IdCom)

                                                'ELIMINO IL FILE JOB E JDF ORIGINALI
                                                Try
                                                    MgrFormerIO.FileDelete(PathFileJob)
                                                    MgrFormerIO.FileDelete(PathFileJdf)
                                                    MgrFormerIO.FileDelete(OldNomeFileJdfMarksFlats)
                                                Catch ex As Exception

                                                End Try

                                                'sblocco i file che avevo loccato
                                                MgrOrderLock.UnlockAll(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.CreazioneCommesseFromGanging)

                                            End Using
                                        Catch ex As Exception
                                            tb.TransactionRollBack()
                                            MessageBox.Show("Si è verificato un errore nel salvataggio della commessa. Riprovare. " & ex.Message)
                                        End Try

                                    End Using

                                    _Ris = 1
                                    Close()
                                End If

                            End If
                        Else
                            MessageBox.Show("Selezionare un macchinario di produzione")
                        End If
                    Else
                        MessageBox.Show("Selezionare un file JOB")
                    End If

                Else
                    MessageBox.Show("Il file Job va prima interpretato")
                End If

            Else
                MessageBox.Show("Inserire numero lastre e quantità")
            End If

        End If

    End Sub

    Private Sub TrasformaPathJdf(Path As String,
                                 RisJob As RisInterpretazioneJob,
                                 NewPathJdfFile As String)

        Dim Buffer As String = String.Empty
        Using R As New StreamReader(Path)
            Buffer = R.ReadToEnd
        End Using

        For Each Ft As RisFileTrovatoNelJob In RisJob.ListaFile

            Dim NomeFile As String = FormerLib.FormerHelper.File.EstraiNomeFile(Ft.Path)

            Using O As New Ordine
                O.Read(Ft.IdOrdineRif)

                For Each F As FileSorgente In O.ListaSorgenti
                    If F.FilePath.ToLower.EndsWith("-" & NomeFile.ToLower) Then
                        Dim NewPath As String = F.FilePath
                        NewPath = FormerHelper.File.TranslateRealDrivePath(NewPath)
                        NewPath = NewPath.Replace("\", "/")

                        Dim OldPath As String = Ft.Path
                        OldPath = FormerHelper.File.TranslateRealDrivePath(OldPath)
                        OldPath = OldPath.Replace("\", "/")

                        Buffer = Buffer.Replace(OldPath, NewPath)

                        Exit For
                    End If
                Next

            End Using

        Next

        Dim NewPathJ As String = NewPathJdfFile
        NewPathJ = FormerHelper.File.TranslateRealDrivePath(NewPathJ)
        NewPathJ = NewPathJ.Replace("\", "/")
        'ora cerco il marcatore JDFMarksFlats

        Dim Righe() As String = Buffer.Split(vbLf)
        Dim NewBuffer As String = String.Empty

        For Each riga As String In Righe

            Dim Posiz As Integer = riga.IndexOf("/JDFMarksFlats/")

            If Posiz <> -1 Then
                'questa riga va cambiata con il path nuovo
                Dim RigaNew As String = riga
                Posiz = RigaNew.IndexOf("file:")
                RigaNew = RigaNew.Substring(0, Posiz) & "file:" & NewPathJ & """/>"
                NewBuffer &= RigaNew & ControlChars.NewLine
            Else
                NewBuffer &= riga & ControlChars.NewLine
            End If

        Next

        'Dim OldPathJ As String = OldPathJdfFile
        'OldPathJ = FormerHelper.File.TranslateRealDrivePath(OldPathJ)
        'OldPathJ = OldPathJ.Replace("\", "/")

        'Buffer = Buffer.Replace(OldPathJ, NewPathJ)

        Using w As New StreamWriter(Path)
            w.Write(NewBuffer)
        End Using

    End Sub

    Private Sub TrasformaPathJob(Path As String,
                                 RisJob As RisInterpretazioneJob)

        Dim Buffer As String = String.Empty
        Using R As New StreamReader(Path)
            Buffer = R.ReadToEnd
        End Using

        For Each Ft As RisFileTrovatoNelJob In RisJob.ListaFile

            Dim NomeFile As String = FormerLib.FormerHelper.File.EstraiNomeFile(Ft.Path)

            Using O As New Ordine
                O.Read(Ft.IdOrdineRif)

                For Each F As FileSorgente In O.ListaSorgenti
                    If F.FilePath.ToLower.EndsWith("-" & NomeFile.ToLower) Then
                        Dim NewPath As String = F.FilePath
                        NewPath = FormerHelper.File.TranslateRealDrivePath(NewPath)
                        NewPath = NewPath.Replace("\", "/")

                        Dim OldPath As String = Ft.Path
                        OldPath = FormerHelper.File.TranslateRealDrivePath(OldPath)
                        OldPath = OldPath.Replace("\", "/")

                        Buffer = Buffer.Replace(OldPath, NewPath)

                        Exit For
                    End If
                Next

            End Using

        Next

        Using w As New StreamWriter(Path)
            w.Write(Buffer)
        End Using

    End Sub

    Private Sub btnCrea_Click(sender As Object, e As EventArgs) Handles btnCrea.Click

        CreaCommessa()

    End Sub

    Private Sub btnInterpreta_Click(sender As Object, e As EventArgs) Handles btnInterpreta.Click

        Interpreta()

    End Sub

    Private _Interpretato As Boolean = False

    Private Sub Interpreta()

        If txtFileJob.Text.Trim.Length Then
            Dim RisJob As RisInterpretazioneJob = InterpretaJob(txtFileJob.Text)

            'ora dal path dei file recupero gli ordini 
            'il modello deve essere il generico 

            Dim CreaCommessa As Boolean = True

            If RisJob.ErroriBloccanti Then
                CreaCommessa = False
                MessageBox.Show("Non è possibile creare la commessa per i seguenti problemi: " & ControlChars.NewLine & RisJob.BufferErrori)
            Else
                _Interpretato = True
                If RisJob.Alert Then
                    MessageBox.Show("Si sono verificate le seguenti incongruenze: " & ControlChars.NewLine & RisJob.BufferErrori)
                Else
                    MessageBox.Show("Tutto Ok puoi creare la commessa su " & RisJob.MacchinarioTrovato.Descrizione)
                End If
                MgrControl.SelectIndexCombo(cmbMacchinari, RisJob.IdMacchinario)

            End If
        Else
            MessageBox.Show("Selezionare un file JOB")
        End If


    End Sub

End Class