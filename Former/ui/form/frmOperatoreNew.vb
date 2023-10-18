Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerDALSql
Imports FormerLib
Imports FormerIO
Imports FormerConfig

Friend Class frmOperatoreNew
    'Inherits baseFormInternaFixed

    Private PathHCC As String = FormerPath.PathHCC '"R:\"
    Private _LavoroInCorso As ILavoroOperatore = Nothing
    Private _Ris As Integer = 0

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub CaricaProcedure()

        Dim L As New List(Of Procedura)
        Using mgr As New ProcedureDAO
            L.AddRange(mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Procedura.IdLavorazione, _LavoroInCorso.IdLavoro),
                                   New LUNA.LunaSearchParameter(LFM.Procedura.IdMacchinario, 0)))

            For Each P As Procedura In mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Procedura.IdLavorazione, _LavoroInCorso.IdLavoro),
                                   New LUNA.LunaSearchParameter(LFM.Procedura.IdMacchinario, _LavoroInCorso.IdMacchinario))
                If L.FindAll(Function(x) x.IdProcedura = P.IdProcedura).Count = 0 Then
                    L.Add(P)
                End If
            Next

            For Each P As Procedura In mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Procedura.IdLavorazione, 0),
                       New LUNA.LunaSearchParameter(LFM.Procedura.IdMacchinario, _LavoroInCorso.IdMacchinario))
                If L.FindAll(Function(x) x.IdProcedura = P.IdProcedura).Count = 0 Then
                    L.Add(P)
                End If
            Next

        End Using

        L.Sort(Function(x, y) x.Nome.CompareTo(y.Nome))

        dgProcedure.AutoGenerateColumns = False
        dgProcedure.DataSource = L

    End Sub

    Public Function Carica(LavoroInCorso As ILavoroOperatore) As Integer
        Cursor.Current = Cursors.WaitCursor

        'UcSliderGroup.AddSlider("GLS", My.Resources._Corriere, "Corriere GLS")
        'UcSliderGroup.AddSlider("28", My.Resources._Consegna, "Consegna 28 Settembre 2018")

        _LavoroInCorso = LavoroInCorso

        CaricaProcedure()

        If _LavoroInCorso.IdOrdine Then
            'cose da fare in caso di lavorazione su ordine
            Using ord As New Ordine
                ord.Read(_LavoroInCorso.IdOrdine)
                MgrAnteprime.CreaRiepilogoOrd(ord,
                                 WebPreview,
                                 enTipoAnteprima.Operatore)
                MgrSlider.CaricaOrdine(UcSliderGroup, ord)
            End Using
            UcAllegati.Carica(, _LavoroInCorso.IdOrdine)

        Else
            'cose da fare in caso di lavorazione su commessa
            Using com As New Commessa
                com.Read(_LavoroInCorso.IdCommessa)
                MgrAnteprime.CreaRiepilogoCom(com,
                                 WebPreview,
                                 enTipoAnteprima.Operatore)
                MgrSlider.CaricaCommessa(UcSliderGroup, com)
                If com.Stato = enStatoCommessa.Stampa And com.IdReparto = enRepartoWeb.StampaDigitale Then
                    lnkPanel.Enabled = True
                Else
                    lnkPanel.Enabled = False
                End If

            End Using
            UcAllegati.Carica(_LavoroInCorso.IdCommessa)
        End If

        If UcAllegati.NumAllegati Then
            lblMessaggi.Text = UcAllegati.NumAllegati & " Messaggi allegati"
            lblMessaggi.ForeColor = Color.Red
        Else
            lblMessaggi.Visible = False
            pctMessaggi.Visible = False
        End If

        lblLavoraz.Text = _LavoroInCorso.LavorazioneStr.ToUpper & " - " & _LavoroInCorso.Copie & " copie " & _LavoroInCorso.FronteRetro

        'aggiungo le copie della lavorazione in corso


        Dim Mess As String = String.Empty

        If _LavoroInCorso.DataOraInizio = Date.MinValue Then
            Mess = "Lavorazione non ancora iniziata"
            If _LavoroInCorso.PrendibileInCarico(PostazioneCorrente.UtenteConnesso.IdUt) Then

                lnkIniziaLav.Enabled = True
                lnkFinished.Enabled = False

            End If
        Else
            If _LavoroInCorso.IdUtInCarico <> PostazioneCorrente.UtenteConnesso.IdUt Then
                'qui in realta non dovrebbe entrare mai
                lnkIniziaLav.Enabled = False
                lnkFinished.Enabled = False

            Else
                If _LavoroInCorso.DataOraFine <> Date.MinValue Then
                    lnkIniziaLav.Enabled = False
                    lnkFinished.Enabled = False
                    Mess = "Lavorazione iniziata da " & PostazioneCorrente.UtenteConnesso.Login & " il " & _LavoroInCorso.DataOraInizio & " e chiusa il " & _LavoroInCorso.DataOraFine
                Else
                    lnkIniziaLav.Enabled = False
                    lnkFinished.Enabled = True
                    Mess = "Lavorazione iniziata da " & PostazioneCorrente.UtenteConnesso.Login & " il " & _LavoroInCorso.DataOraInizio
                End If
            End If
        End If

        lblStatoLavorazione.Text = Mess

        Cursor.Current = Cursors.Default
        ShowDialog()
        Return _Ris

    End Function

    Private Sub SpostaHCC()
        Try

            Dim x As New DirectoryInfo(PathHCC)

            For Each f As FileInfo In x.GetFiles()
                Dim IdRif As Integer = 0
                If _LavoroInCorso.IdCommessa Then
                    IdRif = _LavoroInCorso.IdCommessa
                Else
                    IdRif = _LavoroInCorso.IdOrdine
                End If
                If f.Name.StartsWith(IdRif & ".") Then '_IdRif

                    'File.Move(f.FullName, PathHCC & "Processed\" & f.Name)
                    MgrFormerIO.FileMove(f.FullName, PathHCC & "Processed\" & f.Name, Me)

                End If

            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lnkChiudi_LinkClicked(sender As System.Object,
                                      e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkChiudi.LinkClicked

        Close()

    End Sub

    Private Sub lblMessaggi_Click(sender As Object,
                                  e As EventArgs) Handles lblMessaggi.Click
        TabMain.SelectedTab = tpMessaggi
    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object,
                                        e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        UcAllegati.Aggiorna()
    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object,
                                   e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        Sottofondo()
        Using f As New frmPostit
            Dim Ris As Integer = 0
            Ris = f.Carica(, UcAllegati.IdCom, UcAllegati.IdOrd)
            If Ris Then UcAllegati.Aggiorna()
        End Using
        Sottofondo()

    End Sub

    Private Sub IniziaLavorazione()
        If MessageBox.Show("Confermi la presa in carico del lavoro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'qui l'operatore prende in carico la commessa o l'ordine selezionato e inizio il calcolo del tempo

            If _LavoroInCorso.PrendibileInCarico(PostazioneCorrente.UtenteConnesso.IdUt, True) Then
                lnkIniziaLav.Enabled = False

                Dim TempoStimato As Integer = 0

                'DISATTIVATO PER NON CHIEDERE ALL'OPERATORE IL TEMPOSTIMATO
                'Sottofondo()
                'Using f As New frmOperatoreTempoStimato
                '    TempoStimato = f.Carica
                'End Using
                'Sottofondo()

                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                    Try
                        tb.TransactionBegin()

                        If _LavoroInCorso.IdCommessa Then
                            'qui stiamo lavorando su commessa 
                            'vale sia per i macchinari di produzione che di allestimento 
                            Using c As New Commessa
                                c.Read(_LavoroInCorso.IdCommessa)

                                Using m As New Macchinario
                                    m.Read(_LavoroInCorso.IdMacchinario)

                                    If m.Tipo = enTipoMacchinario.Produzione Then

                                        If c.Stato = enStatoCommessa.Pronto Then

                                            'qui sto nella fase di stampa 
                                            Using mag As New MagazzinoDAO
                                                mag.TrasformaPrenotazioneInScarico(_LavoroInCorso.IdCommessa)
                                                'anche se lo dovesse fare piu volte non fa niente 
                                            End Using

                                            'mando avanti gli ordini 
                                            Using mgr As New OrdiniDAO
                                                For Each singOrd As Ordine In c.ListaOrdini
                                                    mgr.InserisciLog(singOrd, enStatoOrdine.StampaInizio)
                                                Next
                                            End Using

                                            'mando avanti la commessa

                                            Using mgr As New CommesseDAO
                                                mgr.InserisciLog(c, enStatoCommessa.Stampa, PostazioneCorrente.UtenteConnesso.IdUt)
                                            End Using

                                            If c.IdReparto = enRepartoWeb.StampaDigitale Then
                                                lnkPanel.Enabled = True
                                            End If

                                        ElseIf c.Stato = enStatoCommessa.Stampa Then
                                            'in questo caso non devo fare nulla su ordini o commessa 
                                            'metto comunque la if per indicazione di rilettura codice

                                        End If

                                    ElseIf m.Tipo = enTipoMacchinario.Allestimento Then
                                        'mando avanti la commessa
                                        If c.Stato = enStatoCommessa.Stampa Then
                                            Using mgr As New CommesseDAO
                                                mgr.InserisciLog(c, enStatoCommessa.FinituraSuCommessa, PostazioneCorrente.UtenteConnesso.IdUt)
                                            End Using

                                            'mando avanti gli ordini 
                                            Using mgr As New OrdiniDAO
                                                For Each singOrd As Ordine In c.ListaOrdini
                                                    mgr.InserisciLog(singOrd, enStatoOrdine.FinituraCommessaInizio)
                                                Next
                                            End Using

                                        ElseIf c.Stato = enStatoCommessa.FinituraSuCommessa Then
                                            'in questo caso non devo fare nulla su ordini o commessa 
                                            'metto comunque la if per indicazione di rilettura codice

                                        End If
                                    End If

                                End Using
                            End Using
                        ElseIf _LavoroInCorso.IdOrdine Then
                            'qui siamo sicuramente in finitura su prodotto
                            Using o As New Ordine
                                o.Read(_LavoroInCorso.IdOrdine)
                                If o.Stato <> enStatoOrdine.FinituraProdottoInizio Then
                                    'sicuramente lo stato e' precedente

                                    ''QUESTO FORSE NON SERVE
                                    'If o.Commessa.Stato <> enStatoCommessa.FinituraSuProdotti Then
                                    '    'porto avanti la commessa
                                    '    Using mgr As New CommesseDAO
                                    '        mgr.InserisciLog(o.Commessa, enStatoCommessa.FinituraSuProdotti)
                                    '    End Using
                                    'End If

                                    Using mgr As New OrdiniDAO
                                        mgr.InserisciLog(o, enStatoOrdine.FinituraProdottoInizio)
                                    End Using

                                End If
                            End Using
                        End If

                        'qui devo lavorare su lavlog che sia che si tratta di commessa o di ordine non cambia niente
                        Using L As New LavLog
                            L.Read(_LavoroInCorso.IdLavLog)
                            L.DataOraInizio = Now
                            L.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                            L.TempoStimatoOperatore = TempoStimato
                            L.Save()
                            _LavoroInCorso = L
                        End Using

                        tb.TransactionCommit()

                        lblStatoLavorazione.Text = "Lavorazione iniziata da " & PostazioneCorrente.UtenteConnesso.Login

                        _Ris = 1
                        lnkFinished.Enabled = True

                    Catch ex As Exception
                        tb.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nella presa in carico del lavoro: " & ex.Message)
                        ManageError(ex)
                        Close()
                    End Try
                End Using
            Else
                MessageBox.Show("Il lavoro non è prendibile In carico")
            End If

        End If
    End Sub

    Private Sub TerminaLavorazione()

        If MessageBox.Show("Confermi la chiusura del lavoro in corso?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim DiffInMin As Integer = DateDiff(DateInterval.Minute, _LavoroInCorso.DataOraInizio, Now)
            Dim OkChiudi As Boolean = True
            Dim CreataFustella As Boolean = False

            If DiffInMin <= 10 Then
                If MessageBox.Show("ATTENZIONE, la lavorazione risulta iniziata da meno di 10 minuti, Confermi la chiusura della lavorazione?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    OkChiudi = False
                End If
            End If

            If OkChiudi Then
                lnkFinished.Enabled = False
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                    Try
                        tb.TransactionBegin()

                        Dim IsCreazioneFustella As Boolean = False
                        'qui devo lavorare su lavlog che sia che si tratta di commessa o di ordine non cambia niente
                        Using L As New LavLog
                            L.Read(_LavoroInCorso.IdLavLog)

                            If L.Idlav = FormerConst.Lavorazioni.CreazioneFustella Then
                                IsCreazioneFustella = True
                            End If

                            L.DataOraFine = Now
                            L.Save()
                        End Using

                        If _LavoroInCorso.IdCommessa Then
                            Using c As New Commessa
                                c.Read(_LavoroInCorso.IdCommessa)
                                'qui devo vedere se mandare avanti la commessa e tutti gli ordini dentro 

                                Using mgr As New LavLogDAO
                                    Dim l As List(Of LavLog) = mgr.LavoriAncoraAperti(_LavoroInCorso.IdCommessa)
                                    If c.Stato = enStatoCommessa.Stampa Then
                                        'qui devo controllare se ci sono altri macchinari di produzione cosa quasi impossibile 

                                        Dim PortaAvanti As Boolean = True

                                        For Each singLav As LavLog In l
                                            Using m As New Macchinario
                                                m.Read(singLav.Idlav)
                                                If m.Tipo = enTipoMacchinario.Produzione Then
                                                    PortaAvanti = False
                                                End If
                                            End Using
                                        Next

                                        If PortaAvanti Then
                                            'qui non ci sono altri lavori di tipo macchinario di produzione 
                                            If FormerDebug.DebugAttivo = False Then SpostaHCC(c.IdCom)

                                            For Each SingOrd As Ordine In c.ListaOrdini(True)

                                                Using mgrO As New OrdiniDAO
                                                    mgrO.InserisciLog(SingOrd, enStatoOrdine.StampaFine)
                                                End Using

                                            Next

                                            'ora vedo se ci sono finiture su commessa e poi su prodotto 
                                            If l.Count = 0 Then
                                                'qui non ci sono finiture su commessa
                                                'quindi la commessa e' completata
                                                Using mgrC As New CommesseDAO
                                                    mgrC.InserisciLog(c, enStatoCommessa.Completata, PostazioneCorrente.UtenteConnesso.IdUt)
                                                End Using

                                                For Each singOrd As Ordine In c.ListaOrdini(True)
                                                    Dim lLav As List(Of LavLog) = mgr.LavoriAncoraAperti(, singOrd.IdOrd)

                                                    If lLav.Count = 0 Then
                                                        'qui non ci sono finiture su prodotto 
                                                        Using mgrO As New OrdiniDAO
                                                            mgrO.InserisciLog(singOrd, enStatoOrdine.Imballaggio)

                                                            If singOrd.MantieniCampione = enSiNo.Si Then
                                                                Dim x As New myPrinter

                                                                x.PrinterName = PostazioneCorrente.StampanteEtichette
                                                                x.IdOrd = singOrd.IdOrd
                                                                Dim t As New System.Threading.Thread(AddressOf x.StampaMantieniCampione)
                                                                t.Start()

                                                                x = Nothing
                                                            End If

                                                        End Using
                                                    End If
                                                Next
                                            End If

                                        End If

                                    ElseIf c.Stato = enStatoCommessa.FinituraSuCommessa Then
                                        'qui devo controllare se ci sono altre lavorazioni sulla commessa

                                        If l.Count = 0 Then

                                            'qui la commessa e' completata

                                            Using mgrC As New CommesseDAO
                                                mgrC.InserisciLog(c, enStatoCommessa.Completata, PostazioneCorrente.UtenteConnesso.IdUt)
                                            End Using

                                            For Each SingOrd As Ordine In c.ListaOrdini(True)

                                                Using mgrO As New OrdiniDAO
                                                    mgrO.InserisciLog(SingOrd, enStatoOrdine.FinituraCommessaFine)

                                                    'qui devo vedere se ora ci sono finiture su questo ordine 

                                                    Dim lLav As List(Of LavLog) = mgr.LavoriAncoraAperti(, SingOrd.IdOrd)

                                                    If lLav.Count = 0 Then
                                                        mgrO.InserisciLog(SingOrd, enStatoOrdine.Imballaggio)

                                                        If SingOrd.MantieniCampione = enSiNo.Si Then
                                                            Dim x As New myPrinter

                                                            x.PrinterName = PostazioneCorrente.StampanteEtichette
                                                            x.IdOrd = SingOrd.IdOrd
                                                            Dim t As New System.Threading.Thread(AddressOf x.StampaMantieniCampione)
                                                            t.Start()

                                                            x = Nothing
                                                        End If
                                                    End If
                                                End Using

                                            Next

                                        End If

                                    End If
                                End Using

                            End Using
                        ElseIf _LavoroInCorso.IdOrdine Then
                            Using o As New Ordine
                                o.Read(_LavoroInCorso.IdOrdine)
                                'qui devo vedere se mandare avanti l'ordine e tutta la relativa commessa
                                Using mgr As New LavLogDAO
                                    Dim lLav As List(Of LavLog) = mgr.LavoriAncoraAperti(, _LavoroInCorso.IdOrdine)

                                    If lLav.Count = 0 Then

                                        Using mgrO As New OrdiniDAO
                                            mgrO.InserisciLog(o, enStatoOrdine.FinituraProdottoFine)

                                            'qui devo vedere se ora ci sono finiture su questo ordine 

                                            Dim lLavOrd As List(Of LavLog) = mgr.LavoriAncoraAperti(, o.IdOrd)

                                            If lLavOrd.Count = 0 Then
                                                mgrO.InserisciLog(o, enStatoOrdine.Imballaggio)

                                                If o.MantieniCampione = enSiNo.Si Then
                                                    Try
                                                        Dim x As New myPrinter

                                                        x.PrinterName = PostazioneCorrente.StampanteEtichette
                                                        x.IdOrd = o.IdOrd
                                                        Dim t As New System.Threading.Thread(AddressOf x.StampaMantieniCampione)
                                                        t.Start()

                                                        x = Nothing
                                                    Catch ex As Exception

                                                    End Try

                                                End If
                                            End If

                                        End Using

                                    End If

                                End Using

                            End Using
                        End If

                        If IsCreazioneFustella Then

                            'qui devo creare una nuova fustella del tipo fustella dell'ordine 
                            If _LavoroInCorso.IdOrdine Then
                                Using o As New Ordine
                                    o.Read(_LavoroInCorso.IdOrdine)

                                    If o.IdTipoFustella Then
                                        Using TF As New TipoFustella
                                            TF.Read(o.IdTipoFustella)

                                            Dim Counter As Integer = 0

                                            Using mgr As New FustelleDAO
                                                Dim LF As List(Of Fustella) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Fustella.IdTipoFustella, o.IdTipoFustella))

                                                Counter = LF.Count + 1

                                            End Using

                                            Using Fust As New Fustella

                                                Fust.IdTipoFustella = o.IdTipoFustella
                                                Fust.Ripetizione = 1
                                                Fust.Annotazioni = "da Ordine " & o.IdOrd
                                                Fust.Codice = TF.Base & "x" & TF.Altezza & "x" & TF.Profondita & "." & Counter
                                                Fust.Save()

                                                Dim E As New EtichettaCustom
                                                E.Riga1 = Fust.Codice
                                                E.Riga2 = Now.Date.ToString("dd/MM/yyyy")
                                                E.Riga3 = String.Empty
                                                E.Qta = 1
                                                E.WidthMM = FormerConst.ProdottiCaratteristiche.EtichetteCustom.WidthMM
                                                E.HeightMM = FormerConst.ProdottiCaratteristiche.EtichetteCustom.HeightMM

                                                Try
                                                    MgrEtichetteCustom.StampaEtichettaCustom(E, FormerConfig.FConfiguration.Printer.Etichette)
                                                Catch ex As Exception

                                                End Try

                                                CreataFustella = True

                                            End Using

                                        End Using
                                    End If

                                End Using
                            End If

                        End If

                        tb.TransactionCommit()

                        If CreataFustella Then MessageBox.Show("E' stata stampata un etichetta per questa nuova fustella sulla stampante '" & FormerConfig.FConfiguration.Printer.Etichette & "'. Applicarla sulla fustella")

                        _Ris = 1
                        Close()

                    Catch ex As Exception
                        tb.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nella terminazione del lavoro: " & ex.Message)
                        ManageError(ex)
                        Close()
                    End Try
                End Using
            End If

        End If
    End Sub

    Private Sub SpostaHCC(IdCom As Integer)
        Try

            Dim x As New DirectoryInfo(PathHCC)

            For Each f As FileInfo In x.GetFiles()

                If f.Name.StartsWith(IdCom & ".") Then

                    'File.Move(f.FullName, PathHCC & "Processed\" & f.Name)
                    MgrFormerIO.FileMove(f.FullName, PathHCC & "Processed\" & f.Name, Me)
                End If

            Next
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Private Sub lnkIniziaLav_LinkClicked(sender As Object,
                                         e As LinkLabelLinkClickedEventArgs) Handles lnkIniziaLav.LinkClicked
        IniziaLavorazione()
    End Sub

    Private Sub lnkFinished_LinkClicked(sender As Object,
                                        e As LinkLabelLinkClickedEventArgs) Handles lnkFinished.LinkClicked
        TerminaLavorazione()
    End Sub

    Private Sub lnkPanel_LinkClicked(sender As Object,
                                     e As LinkLabelLinkClickedEventArgs) Handles lnkPanel.LinkClicked

        Sottofondo()

        Using f As New frmCommessaDigitalePannelli
            f.Carica(_LavoroInCorso.IdCommessa)
        End Using

        Sottofondo()

    End Sub

    Private Sub UcSliderGroup_Load(sender As Object,
                                   e As EventArgs) Handles UcSliderGroup.Load

    End Sub

    Private Sub lnkCopyAllegati_LinkClicked(sender As Object,
                                            e As LinkLabelLinkClickedEventArgs) Handles lnkCopyAllegati.LinkClicked

        Dim Count As Integer = 0

        If _LavoroInCorso.IdCommessa Then
            Using c As New Commessa
                c.Read(_LavoroInCorso.IdCommessa)

                For Each o As Ordine In c.ListaOrdini
                    Count += o.ListaFileAllegati.Count
                Next

            End Using
        End If

        If Count Then
            Sottofondo()

            Using f As New frmCommessaCopyAllegati
                f.Carica(_LavoroInCorso.IdCommessa)
            End Using

            Sottofondo()
        Else
            MessageBox.Show("Non sono presenti file allegati da copiare")
        End If

    End Sub
End Class