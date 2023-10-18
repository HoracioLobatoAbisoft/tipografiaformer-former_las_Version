Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerDALSql
Friend Class frmOperatore
    Inherits frmBaseForm
    Private _Ris As Integer = 0
    Private _Crono As CronoCommessa
    Private _IdCrono As Integer = 0
    Private _IdLavLog As Integer
    Private _IdCom As Integer

    Private _Lavoraz As enStatoCommessa
    Private _IdRif As Integer
    Private _AsCommessa As Boolean

    Private PathHCC As String = "R:\"

    Friend Function CaricaPerOrdine(ByVal IdOrd As Integer, IdLavLog As Integer) As Integer
        Cursor.Current = Cursors.WaitCursor

        _IdRif = IdOrd
        _AsCommessa = False
        _Lavoraz = enStatoCommessa.FinituraSuProdotti
        _IdLavLog = IdLavLog

        'If _AsCommessa Then
        Dim Ord As New Ordine
        Ord.Read(_IdRif)
        _IdCom = Ord.IdCom
        CreaRiepilogoOrd(Ord, WebPreview, enTipoAnteprima.Generale)

        'Dim P As New Prodotto
        'P.Read(Ord.IdProd)
        'UcCaratProdotto.Carica(P)
        Ord = Nothing

        Dim L As New LavLog
        L.Read(IdLavLog)

        'poco elegante da sistemare

        Dim RisStato As StatoLavorazione = Nothing
        Using c As New CommesseDAO
            RisStato = c.CommessaAperta(PostazioneCorrente.UtenteConnesso.IdUt, _IdCom, _Lavoraz, IdLavLog)
        End Using
        If RisStato.IdCrono Then ' qui ci deve per forza esser il cronologico della commessa allo stato finitura su prodotti
            _IdCrono = RisStato.IdCrono
            _Crono = New CronoCommessa
            _Crono.Read(RisStato.IdCrono)

        End If


        Dim Mess As String = ""
        'torna 0 se non cominciata
        'torna 1 se cominciata dall'operatore passato e non chiusa
        'torna 2 se cominciata dall'operatore passato e chiusa
        'torna 3 se cominciata da un altro operatore
        UcAllegati.Carica(, IdOrd)

        If L.DataOraInizio = Date.MinValue Then
            'qui non l'ha in carico nessuno
            lnkIniziaLav.Enabled = True
            lnkFinished.Enabled = False
            Mess = "Lavorazione ancora non iniziata"
        Else
            If L.IdUt <> PostazioneCorrente.UtenteConnesso.IdUt Then
                lnkIniziaLav.Enabled = False
                lnkFinished.Enabled = False

                Mess = "Lavorazione iniziata da " & L.Utente.Login & " il " & L.DataOraInizio
                If L.DataOraFine <> Date.MinValue Then Mess &= " e  chiusa il " & L.DataOraFine
            Else
                If L.DataOraFine <> Date.MinValue Then
                    lnkIniziaLav.Enabled = False
                    lnkFinished.Enabled = False

                    Mess = "Lavorazione iniziata da " & PostazioneCorrente.UtenteConnesso.Login & " il " & L.DataOraInizio
                    If L.DataOraFine <> Date.MinValue Then Mess &= " e  chiusa il " & L.DataOraFine
                Else
                    lnkIniziaLav.Enabled = False
                    lnkFinished.Enabled = True
                    Mess = "Lavorazione iniziata da " & PostazioneCorrente.UtenteConnesso.Login & " il " & L.DataOraInizio
                End If
            End If
        End If

        lblLavoraz.Text = L.Descrizione.ToUpper
        lblStatoLavorazione.Text = Mess

        If UcAllegati.NumAllegati Then
            lblMessaggi.Text = UcAllegati.NumAllegati & " Messaggi allegati"
            lblMessaggi.ForeColor = Color.Red
        Else
            lblMessaggi.Visible = False
            pctMessaggi.Visible = False
        End If

        Cursor.Current = Cursors.Default

        ShowDialog()

        Return _Ris

    End Function

    Friend Function CaricaPerCommessa(ByVal IdCom As Integer, ByVal Lavoraz As enStatoCommessa, Optional IdLavLog As Integer = 0) As Integer

        Cursor.Current = Cursors.WaitCursor
        _IdCom = IdCom
        _IdRif = IdCom
        _AsCommessa = True
        _Lavoraz = Lavoraz

        ' UcCaratProdotto.Visible = False
        ' WebPreview.Height = UcCaratProdotto.Top + UcCaratProdotto.Height - WebPreview.Top
        'If _AsCommessa Then
        Using Com As New Commessa
            Com.Read(IdCom)

            CreaRiepilogoCom(Com, WebPreview)
        End Using

        UcAllegati.Carica(IdCom)

        Dim RisStato As StatoLavorazione
        Using c As New CommesseDAO
            RisStato = c.CommessaAperta(PostazioneCorrente.UtenteConnesso.IdUt, IdCom, _Lavoraz, IdLavLog)
        End Using

        Dim Mess As String = ""
        'torna 0 se non cominciata
        'torna 1 se cominciata dall'operatore passato e non chiusa
        'torna 2 se cominciata dall'operatore passato e chiusa
        'torna 3 se cominciata da un altro operatore
        Select Case RisStato.Stato

            Case 0
                lnkIniziaLav.Enabled = True
                lnkFinished.Enabled = False
                Mess = "Lavorazione ancora non iniziata"
            Case 1
                lnkIniziaLav.Enabled = False
                lnkFinished.Enabled = True
                Dim u As New Utente
                u.Read(RisStato.IdOp)
                Mess = "Lavorazione iniziata da " & u.Login & " il " & RisStato.DataInizio
            Case 2, 3
                lnkIniziaLav.Enabled = False
                lnkFinished.Enabled = False
                Dim u As New Utente
                u.Read(RisStato.IdOp)
                Mess = "Lavorazione iniziata da " & u.Login & " il " & RisStato.DataInizio
                If RisStato.DataFine <> Date.MinValue Then Mess &= " e  chiusa il " & RisStato.DataFine
        End Select

        If RisStato.IdCrono Then
            _IdCrono = RisStato.IdCrono
            _Crono = New CronoCommessa
            _Crono.Read(RisStato.IdCrono)

        End If

        If IdLavLog Then
            _IdLavLog = IdLavLog
            Dim l As New LavLog
            l.Read(_IdLavLog)
            lblLavoraz.Text = l.Descrizione
        Else
            lblLavoraz.Text = "Stampa"
        End If

        lblStatoLavorazione.Text = Mess.ToUpper

        If UcAllegati.NumAllegati Then
            lblMessaggi.Text = UcAllegati.NumAllegati & " Messaggi allegati"
            lblMessaggi.ForeColor = Color.Red
        Else
            lblMessaggi.Visible = False
            pctMessaggi.Visible = False

        End If

        'Else
        '    Dim Ord As New Ordine
        '    Ord.Read(IdRif)

        '    CreaRiepilogoOrd(Ord, WebPreview, enTipoAnteprima.Generale)
        '    Ord = Nothing

        'End If
        Cursor.Current = Cursors.Default

        ShowDialog()

        Return _Ris

    End Function

    'Friend Function CaricaByCronsdsdsos(ByVal IdCrono As Integer, Optional ByVal IdLavLog As Integer = 0, Optional ByVal GrigliaAltriLavori As DataTable = Nothing) As Integer

    '    _IdLavLog = IdLavLog

    '    Cursor.Current = Cursors.WaitCursor

    '    Dim Crono As New cCommesseCrono
    '    Crono.Read(IdCrono)
    '    _Crono = Crono

    '    _IdCom = Crono.IdCom

    '    Select Case Crono.IdStato

    '        Case enStatoCommessa.Stampa
    '            Dim Com As New Commessa
    '            Com.Read(Crono.IdCom)

    '            CreaRiepilogoCom(Com, WebPreview)
    '            Com = Nothing
    '            lblLavoraz.Text = "STAMPA"

    '        Case enStatoCommessa.FinituraSuCommessa
    '            Dim Com As New Commessa
    '            Com.Read(Crono.IdCom)

    '            CreaRiepilogoCom(Com, WebPreview)
    '            Com = Nothing

    '            Dim Lav As New cLavLogColl, singLav As cLavLog
    '            singLav = Lav.GetNextLavByCom(Crono.IdCom)

    '            lblLavoraz.Text = singLav.Descrizione

    '        Case enStatoCommessa.FinituraSuProdotti
    '            'qui mi devo caricare in base al crono la singola lavorazione sui vari ordini

    '            Dim Lav As New cLavLog
    '            Lav.Read(IdLavLog)

    '            Dim Ord As New Ordine
    '            Ord.Read(Lav.IdOrd)

    '            CreaRiepilogoOrd(Ord, WebPreview, enTipoAnteprima.Generale)
    '            Ord = Nothing

    '            lblLavoraz.Text = Lav.Descrizione

    '            'Dim Ord As New Ordine
    '            'Ord.Read(IdRif)

    '            'CreaRiepilogoOrd(Ord, WebPreview)
    '            'Ord = Nothing

    '    End Select

    '    Cursor.Current = Cursors.Default


    '    'qui carico i prossimi lavori di quel tipo cosi lui si puo regolare
    '    DgProsLav.DataSource = GrigliaAltriLavori


    '    ShowDialog()

    '    Return _Ris

    'End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub lnkFinished_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFinished.LinkClicked

        If MessageBox.Show("Confermi la chiusura del lavoro in corso?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            lnkFinished.Enabled = False
            'qui ho sicuramente l'idcrono in corso e opzionalmente l'idLavLog
            'chiudo la lavorazione 

            Dim SwCom As Boolean = False

            If _AsCommessa Then
                Dim Lav As LavLog
                If _IdLavLog Then
                    'se c'e' una lavorazione la chiudo, in fase di stampa non c'è per questo e' necessaria la if
                    Lav = New LavLog
                    Lav.Read(_IdLavLog)
                    Lav.DataOraFine = Date.Now
                    Lav.Save()
                    Lav = Nothing
                End If

                ' ci sono delle finiture sulla commessa? 
                Using lavColl As New cLavLogColl
                    Lav = lavColl.GetNextLavByCom(_IdRif)
                End Using
                If Not Lav Is Nothing Then
                    'qui ci sono finiture sulla commessa
                    If _Crono.IdStato = enStatoCommessa.Stampa Then
                        'se sto in fase di stampa chiudo il cronologico attuale ma lascio tutto cosi perche ci sono lavorazioni sulla commessa
                        ChiudiCrono()
                        If DebugAttivo = False Then SpostaHCC()

                        '16/04/2015 aggiunto per mettere lo stato dell'ordine a stampa finita 
                        Using C As New Commessa
                            C.Read(_IdRif)
                            Using mgr As New OrdiniDAO
                                For Each O As Ordine In C.ListaOrdini
                                    mgr.InserisciLog(O, enStatoOrdine.StampaFine)
                                Next
                            End Using
                        End Using
                    Else
                        'se arrivo qui e ci sono lavorazioni sulla commessa sono per forza in finitura su commessa
                        'quindi non faccio niente
                    End If
                Else
                    'qui non ci sono finiture sulla commessa
                    'se sto in fase di stampa chiudo comunque la lavorazione 

                    If _Crono.IdStato = enStatoCommessa.Stampa Then
                        SpostaHCC()

                    ElseIf _Crono.IdStato = enStatoCommessa.FinituraSuCommessa Then

                    End If

                    ChiudiCrono()
                    'ora qui ciclo per tutti gli ordini nella commessa e li sposto allo stato giusto
                    Dim C As New Commessa
                    C.Read(_IdRif)

                    Dim ExistOrdiniConFinitura As Boolean = False

                    For Each O As Ordine In C.ListaOrdini
                        'ora per tutti gli stati controllo se ci sono finiture sul prodotto, in caso negativo gli faccio chiudere del tutto la commessa
                        Dim ProxStatoOrd As Integer = enStatoOrdine.FinituraCommessaFine

                        Dim l As List(Of LavLog) = Nothing
                        Using mgr As New LavLogDAO
                            l = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", O.IdOrd), _
                                                                           New LUNA.LunaSearchParameter("DataOraFine", Nothing, "is"))
                        End Using
                        If l.Count = 0 Then
                            ProxStatoOrd = enStatoOrdine.Imballaggio
                        Else
                            ExistOrdiniConFinitura = True
                        End If

                        Using OMgr As New OrdiniDAO

                            OMgr.AvanzaOrdiniAStatoByIdOrd(O.IdOrd, ProxStatoOrd)

                        End Using

                    Next

                    If ExistOrdiniConFinitura = False Then
                        ChiudiCrono()
                        SwCom = True
                    End If

                    'ora per tutti gli stati controllo se ci sono finiture sul prodotto, in caso negativo gli faccio chiudere del tutto la commessa
                    'Dim ContrOrd As New cLavLogColl, Ris As Integer
                    'Ris = ContrOrd.GetNextLavOrdByCom(_IdRif)

                    'If Ris = 0 Then
                    '    ChiudiCrono = True
                    '    SwCom = True
                    'End If

                End If
            Else
                'qui non e' una commessa ma un prodotto e sto in finitura su prodotto
                Dim IdOrdRif As Integer = 0
                Dim Lav As LavLog = New LavLog
                Lav.Read(_IdLavLog)
                Lav.DataOraFine = Date.Now
                IdOrdRif = Lav.IdOrd
                Lav.Save()
                Lav = Nothing

                'qui devo portare anche avanti l'ordine se non ci sono altre finiture su prodotto

                Dim l As List(Of LavLog) = Nothing
                Using mgr As New LavLogDAO
                    l = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", IdOrdRif), _
                                                                   New LUNA.LunaSearchParameter("DataOraFine", Nothing, "is"))
                End Using
                If l.Count = 0 Then
                    'qui salvo prima la fine finitura prodotto e poi lo sposto a imballaggio
                    Dim ProxStatoOrd As Integer = enStatoOrdine.FinituraProdottoFine

                    Using OMgr As New OrdiniDAO

                        OMgr.AvanzaOrdiniAStatoByIdOrd(IdOrdRif, ProxStatoOrd)

                        ProxStatoOrd = enStatoOrdine.Imballaggio

                        OMgr.AvanzaOrdiniAStatoByIdOrd(IdOrdRif, ProxStatoOrd)

                    End Using

                End If

                Dim Ris As Integer
                Using ContrOrd As New cLavLogColl
                    Ris = ContrOrd.GetNextLavOrdByCom(_IdCom)
                End Using
                If Ris = 0 Then
                    ChiudiCrono()
                    SwCom = True
                End If

            End If

            If SwCom Then
                Dim Com As New Commessa
                Using mC As New CommesseDAO
                    Com.Read(_IdCom)
                    mC.InserisciLog(Com, enStatoCommessa.Completata)
                End Using


            End If

            _Ris = 1
            Close()
        End If

    End Sub

    Private Sub ChiudiCrono()

        _Crono.DataCronoFine = Date.Now
        _Crono.Save()
    End Sub

    Private Sub SpostaHCC()
        Try

            Dim x As New DirectoryInfo(PathHCC)

            For Each f As FileInfo In x.GetFiles()

                If f.Name.StartsWith(_IdRif & ".") Then

                    File.Move(f.FullName, PathHCC & "Processed\" & f.Name)

                End If

            Next
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub lnkFinished_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFinished.LinkClicked

    '    If MessageBox.Show("Confermi la chiusura del lavoro in corso?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '        'qui ho sicuramente l'idcrono in corso e opzionalmente l'idLavLog
    '        'chiudo la lavorazione 

    '        Dim SwCom As Boolean = False

    '        Select Case _Crono.IdStato
    '            Case enStatoCommessa.Stampa
    '                Dim c As New cCommesseCrono

    '                c.Read(_Crono.IdCrono)
    '                c.DataCronoFine = Now
    '                c.Save()

    '                c = Nothing

    '            Case enStatoCommessa.FinituraSuCommessa, enStatoCommessa.FinituraSuProdotti

    '                Dim Lav As cLavLog
    '                If _IdLavLog Then

    '                    Lav = New cLavLog
    '                    Lav.Read(_IdLavLog)
    '                    Lav.DataOraFine = Now
    '                    Lav.Save()
    '                    Lav = Nothing

    '                End If

    '                If _Crono.IdStato = enStatoCommessa.FinituraSuCommessa Then

    '                    Dim lavColl As New cLavLogColl
    '                    Lav = lavColl.GetNextLavByCom(_IdCom)

    '                    If Lav Is Nothing Then

    '                        Dim c As New cCommesseCrono

    '                        c.Read(_Crono.IdCrono)
    '                        c.DataCronoFine = Now
    '                        c.Save()

    '                        Dim ContrOrd As New cLavLogColl, Ris As Integer
    '                        Ris = ContrOrd.GetNextLavOrdByCom(c.IdCom)

    '                        If Ris = 0 Then SwCom = True

    '                    End If

    '                Else
    '                    Dim ContrOrd As New cLavLogColl, Ris As Integer
    '                    Ris = ContrOrd.GetNextLavOrdByCom(_IdCom)

    '                    If Ris = 0 Then SwCom = True

    '                End If

    '        End Select

    '        Dim TrovAltriLav As Boolean = False


    '        If TrovAltriLav = False Then

    '            Dim c As New cCommesseCrono

    '            c.Read(_Crono.IdCrono)
    '            c.DataCronoFine = Now
    '            c.Save()

    '            c = Nothing

    '        End If

    '        If SwCom Then
    '            Dim Com As New Commessa
    '            Com.IdCom = _IdCom
    '            Com.InserisciLog(enStatoCommessa.Completata)

    '            'qui devo spostare tutti gli ordini della commessa a in spedizione
    '            Dim Ord As New cOrdiniColl
    '            Ord.AvanzaOrdiniAStatoByCom(_IdCom, enStatoOrdine.Imballaggio)

    '        End If

    '        _Ris = 1
    '        Close()

    '    End If

    'End Sub

    Private Sub lnkIniziaLav_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkIniziaLav.LinkClicked


        'qui puoi iniziare la lavorazione solo se non e' gia in lavorazione da qualcun altro

        If MessageBox.Show("Confermi la presa in carico del lavoro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'qui l'operatore prende in carico la commessa o l'ordine selezionato e inizio il calcolo del tempo
            lnkIniziaLav.Enabled = False
            Dim IdLavLog As Integer = 0
            ''salvo la commessa nel cronologico 
            Using TB As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                Try

                    TB.TransactionBegin()

                    'TODO: SISTEMARE!!!
                    LUNA.LunaContext.SetUtenteConnesso(PostazioneCorrente.UtenteConnesso.IdUt, PostazioneCorrente.UtenteConnesso.Tipo)
                    Select Case _Lavoraz

                        Case enStatoCommessa.Stampa
                            'qui ho cliccato su stampa

                            'scarico le cose di magazzino
                            Using mag As New MagazzinoDAO
                                mag.TrasformaPrenotazioneInScarico(_IdRif)
                            End Using
                            'mando avanti gli ordini
                            Using Ord As New cOrdiniColl
                                'Ord.AvanzaOrdiniAStatoByCom(_IdRif, enStatoOrdine.StampaInizio)
                            End Using
                            'mando avanti la commessa
                            Using mC As New CommesseDAO
                                Dim Com As New Commessa
                                Com.Read(_IdRif)
                                _IdCrono = mC.InserisciLog(Com, enStatoCommessa.Stampa)
                            End Using
                            If _Crono Is Nothing Then _Crono = New CronoCommessa
                            _Crono.Read(_IdCrono)


                        Case enStatoCommessa.FinituraSuCommessa

                            'mando avanti la commessa
                            Dim Com As New Commessa
                            Com.Read(_IdRif)
                            Using CMgr As New CommesseDAO
                                _IdCrono = CMgr.InserisciLog(Com, enStatoCommessa.FinituraSuCommessa)
                            End Using

                            If _Crono Is Nothing Then _Crono = New CronoCommessa
                            _Crono.Read(_IdCrono)

                            Using Ord As New cOrdiniColl
                                'Ord.AvanzaOrdiniAStatoByCom(_IdRif, enStatoOrdine.FinituraCommessaInizio)
                            End Using
                            Dim Lav As LavLog
                            Using lavlog As New cLavLogColl
                                Lav = lavlog.GetNextLavByCom(Com.IdCom)
                            End Using
                            If Not Lav Is Nothing Then
                                IdLavLog = Lav.IdLavLog
                                Lav.DataOraInizio = Now
                                Lav.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                                Lav.Save()
                            End If

                        Case enStatoCommessa.FinituraSuProdotti
                            'mando avanti la commessa

                            Using Ord As New Ordine
                                Ord.Read(_IdRif)

                                Using Com As New Commessa
                                    Using mC As New CommesseDAO
                                        Com.Read(Ord.IdCom)
                                        _IdCrono = mC.InserisciLog(Com, enStatoCommessa.FinituraSuProdotti)
                                    End Using
                                End Using
                                If _Crono Is Nothing Then _Crono = New CronoCommessa
                                _Crono.Read(_IdCrono)

                                'Dim OrdColl As New cOrdiniColl
                                'OrdColl.AvanzaOrdiniAStatoByCom(Ord.IdCom, enStatoOrdine.FinituraProdottoInizio)

                                'avanzo l'ordine a finitura su prodotto inizio
                                Using oMgr As New OrdiniDAO
                                    oMgr.AvanzaOrdiniAStatoByIdOrd(Ord.IdOrd, enStatoOrdine.FinituraProdottoInizio)
                                End Using

                                Using l As New LavLog
                                    l.Read(_IdLavLog)
                                    l.DataOraInizio = Now
                                    l.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                                    l.Save()
                                End Using
                            End Using

                    End Select

                    TB.TransactionCommit()

                    lblStatoLavorazione.Text = "Lavorazione iniziata da " & PostazioneCorrente.UtenteConnesso.Login

                    _Ris = 1
                    'lnkIniziaLav.Enabled = False
                    lnkFinished.Enabled = True

                Catch ex As Exception

                    TB.TransactionRollBack()
                    MessageBox.Show("Si è verificato un errore nella presa in carico del lavoro " & ex.Message)
                    ManageError(ex)
                    Close()

                End Try
            End Using

        End If
    End Sub

    Private Sub lnkChiudi_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkChiudi.LinkClicked

        Close()

    End Sub

    Private Sub lblMessaggi_Click(sender As Object, e As EventArgs) Handles lblMessaggi.Click
        TabMain.SelectedTab = tpMessaggi
    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        UcAllegati.Aggiorna()
    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        Sottofondo(Me)
        Dim f As New frmPostit, Ris As Integer = 0
        Ris = f.Carica(, UcAllegati.IdCom, UcAllegati.IdOrd)
        If Ris Then UcAllegati.Aggiorna()
        Sottofondo(Me)

    End Sub

End Class