Imports FormerBusinessLogicInterface
Imports FormerBusinessLogic
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucOperatoreImballaggio
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()

        'If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then

        '    btnAvanzaSenzaStampa.Visible = True
        '    btnAvanzaSenzaStampa.Enabled = True
        'End If
        CaricaImballaggio()
    End Sub

    Private Sub CaricaImballaggio()

        Cursor = Cursors.WaitCursor
        'PrepVociOperatore()

        Using mgr As New OrdiniDAO
            Dim l As List(Of Ordine) = mgr.FindAll(LFM.Ordine.IdOrd,
                                                   New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Imballaggio))

            'TODO: EVENTUALE FILTRAGGIO SU GLS ANCHE PER LA SCHEDA "IMBALLO"; PER ORA LASCIO COMMENTATO PERCHE'
            'IN QUESTO CASO VIENE VERIFICATO IL CORRIERE SUGLI ORDINI ANZICHE' SULLA CONSEGNA E NON SO SE E' CORRETTO
            '(HO NOTATO CHE SE VIENE CAMBIATO CORRIERE ALLA CONSEGNA, GLI ORDINI RESTANO CON IL CORRIERE ORIGINALE)
            'Dim l As List(Of Ordine) = Nothing
            'If chkSoloGlsImballo.Checked Then
            '    l = mgr.FindAll("IdOrd", New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Imballaggio), _
            '                    New LUNA.LunaSearchParameter("IdCorriere", "(" & enCorriere.GLS & ", " & enCorriere.PortoAssegnatoGLS & ")", "IN"))
            'Else
            '    l = mgr.FindAll("IdOrd", New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Imballaggio))
            'End If

            DgImballoEx.AutoGenerateColumns = False
            DgImballoEx.DataSource = l

        End Using

        'Dim Dt As DataTable, x As New cOrdiniColl
        'Dt = x.ListaDaLav(enStatoOrdine.Imballaggio)
        'DgImballaggio.DataSource = Dt
        'DgImballaggio.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgImballaggio.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgImballaggio.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Cursor = Cursors.Default
    End Sub

    Private Sub btnStampaEtich_Click(sender As Object, e As EventArgs) Handles btnStampaEtich.Click

        Dim IdOrd As Integer = 0
        If DgImballoEx.SelectedRows.Count Then

            Dim O As Ordine = DirectCast(DgImballoEx.SelectedRows(0).DataBoundItem, Ordine)
            Dim StampareEtichette As Boolean = True

            If O.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente AndAlso
               O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormer AndAlso
               O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo Then

                If O.Fatturabile = False Then
                    StampareEtichette = False
                End If

            End If

            'qui vado a controllare se l'ordine è fatturabile altrimenti non lo faccio andare avanti
            If StampareEtichette Then
                'Dim OkStampa As Boolean = True
                'Dim Accorpabile As Boolean = False
                ''qui controllo che non ci siano ordini dello stesso cliente 
                'If O.ConsegnaAssociata.Modificabile(True) Then
                '    If O.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente AndAlso
                '        O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormer AndAlso
                '        O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo Then
                '        'qui è con corriere
                '        Using mgr As New OrdiniDAO
                '            Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdRub, O.IdRub),
                '                                                   New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.InCodaDiStampa, ">"),
                '                                                   New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Imballaggio, "<"))
                '            For Each OAltri As Ordine In l
                '                If OAltri.ConsegnaAssociata.IdCons <> O.ConsegnaAssociata.IdCons Then
                '                    If OAltri.ConsegnaAssociata.Modificabile(True) Then
                '                        If OAltri.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente AndAlso
                '                           OAltri.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormer AndAlso
                '                           OAltri.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo Then
                '                            ChiediConferma = True
                '                            Exit For
                '                        End If
                '                    End If
                '                End If
                '            Next
                '        End Using

                '    End If
                'End If

                'If ChiediConferma Then
                '    If MessageBox.Show("Richiedi conferma in amministrazione. Esistono degli ordini di questo stesso cliente che non sono ancora pronti e potrebbero essere accorpati nella consegna. Confermi la stampa etichette?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                '        OkStampa = False
                '    End If
                'End If

                'If OkStampa Then

                Dim StampaEffettiva As Boolean = MgrFormerException.StampareEtichetteOrdine(O)
                StampaEtichette(StampaEffettiva)

                'End If
            Else
                MessageBox.Show("Il lavoro è assegnato a un cliente che non ha completato i dati fiscali per la fatturazione. Impossibile andare avanti")
            End If

        Else
            Beep()
        End If
    End Sub

    Private Sub StampaEtichette(Optional StampaEffettiva As Boolean = True)

        Dim MessaggioOperat As String = "Vuoi stampare le etichette per l'ordine selezionato?"

        If StampaEffettiva = False Then
            MessaggioOperat = "Vuoi portare avanti l'ordine senza stampare le etichette?"
        End If

        Dim IdOrd As Integer = 0
        If DgImballoEx.SelectedRows.Count Then
            Dim O As Ordine = DirectCast(DgImballoEx.SelectedRows(0).DataBoundItem, Ordine)
            IdOrd = O.IdOrd

            If PostazioneCorrente.StampanteEtichette.Length Then
                Dim PassatoPerSoluzione As Boolean = False
                Dim DovevaPassarePerSoluzione As Boolean = False
                If MessageBox.Show(MessaggioOperat, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim Peso As Single = O.Prodotto.PesoComplessivo
                    Dim NumColli As Integer = 0

                    If O.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente And O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormer And O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo Then

                        If O.IdListinoBase Then

                            Dim Altezza As Single = O.ListinoBase.FormatoProdotto.FormatoCarta.Altezza + 3
                            Dim Larghezza As Single = O.ListinoBase.FormatoProdotto.FormatoCarta.Larghezza + 3
                            Dim Profondita As Single = O.ListinoBase.TipoCarta.CalcolaSpessoreCM(O.QtaOrdine) '.Prodotto.NumPezzi)''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO

                            Dim SingPeso As Single = 0
                            If O.ListinoBase.Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
                                If O.ListinoBase.IdModelloCubetto Then
                                    Using M As New ModelloCubetto
                                        M.Read(O.ListinoBase.IdModelloCubetto)
                                        Altezza = M.Lunghezza / 10
                                        Larghezza = M.Larghezza / 10
                                        Profondita = M.Profondita / 10
                                    End Using

                                    SingPeso = MgrCorriere.CalcolaPesoVolumetrico(Altezza,
                                                                                  Larghezza,
                                                                                  Profondita)
                                    SingPeso = SingPeso * O.NumeroRealeColli
                                End If
                            End If

                            If SingPeso = 0 Then SingPeso = MgrCorriere.CalcolaPesoVolumetrico(Altezza,
                                                                                               Larghezza,
                                                                                               Profondita)

                            Dim PesoVolumetrico As Single = SingPeso

                            If PesoVolumetrico > Peso Then Peso = PesoVolumetrico

                            '****************************************
                            'DISATTIVATO PER NON PASSARE IN SOLUZIONE 
                            '****************************************
                            'If O.ConsegnaAssociata.ListaOrdini.Count = 1 Or Peso > FormerConst.Massimali.MaxPesoSingoloOrdineInImballaggio Then
                            '    DovevaPassarePerSoluzione = True
                            '    If O.ListinoBase.IdModelloCubetto Then
                            '        NumColli = MgrImballo.NumColliDaSoluzione(O.IdOrd, Me.ParentForm)
                            '        'If NumColli > -1 Then
                            '        PassatoPerSoluzione = True
                            '        'End If
                            '    End If
                            'End If
                            '****************************************
                            'FINE DISATTIVATO PER NON PASSARE IN SOLUZIONE 
                            '****************************************

                        End If

                    End If

                    If NumColli = 0 Then

                        NumColli = O.NumeroColliCalcolati
                        'Dim Msg As String = "Inserire il numero di colli reali dell'ordine"
                        'NumColliUtente = InputBox(Msg, "Stampa etichette Ordine", NumColli)

                        ParentFormEx.Sottofondo()
                        Using x As New frmOrdineNumColli
                            x.Carica(IdOrd, NumColli)
                            NumColli = x.NumColli
                        End Using
                        ParentFormEx.Sottofondo()

                        PassatoPerSoluzione = False

                    End If

                    If Peso = 0 Then
                        Dim PesoUtente As String = InputBox("Inserisci il peso approssimativo dei colli in Kg", "Stampa etichette Ordine", 0)
                        If IsNumeric(PesoUtente) Then
                            'se il peso e' valido lo salvo come default
                            O.Prodotto.PesoComplessivo = PesoUtente
                            O.Prodotto.Save()
                        End If
                    End If


                    'If NumColli > 0 Then
                    If NumColli Then
                        O.NumeroRealeColli = NumColli
                        O.Save()

                        If DovevaPassarePerSoluzione = True And PassatoPerSoluzione = True Then

                            Using mgr As New ConsProgrOrdiniDAO

                                Dim cp As ConsProgrOrdini = mgr.Find(New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdOrd, O.IdOrd))
                                If Not cp Is Nothing Then
                                    cp.Inserito = enSiNo.Si
                                    cp.Save()

                                End If
                                cp = Nothing

                                'Dim l As List(Of ConsProgrOrdini) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", O.IdOrd))
                                'If l.Count Then
                                '    l(0).Inserito = True
                                '    l(0).Save()
                                'End If

                            End Using

                        End If

                        If StampaEffettiva Then
                            Dim x As New myPrinter

                            x.PrinterName = PostazioneCorrente.StampanteEtichette
                            x.IdOrd = IdOrd
                            x.NumColli = NumColli
                            Dim t As New System.Threading.Thread(AddressOf x.StampaEtichetteOrdine)
                            t.Start()

                            x = Nothing
                        End If

                        Dim Prossimostato As enStatoOrdine
                        If (O.ConsegnaAssociata.IdCorr = enCorriere.TipografiaFormer _
                            Or O.ConsegnaAssociata.IdCorr = enCorriere.TipografiaFormerFuoriRaccordo _
                            Or O.ConsegnaAssociata.IdCorr = enCorriere.RitiroCliente) Then
                            Prossimostato = enStatoOrdine.ProntoRitiro
                        Else
                            'qui va in imballaggio corriere
                            Prossimostato = enStatoOrdine.ImballaggioCorriere
                        End If

                        Using OMgr As New OrdiniDAO
                            OMgr.AvanzaOrdiniAStatoByIdOrd(IdOrd, Prossimostato)
                        End Using

                        'If DovevaPassarePerSoluzione = True And PassatoPerSoluzione = True Then 'qui lo porto avanti se doveva passare per la soluizione anche se poio non ci e' passato
                        '    Using OMgr As New OrdiniDAO
                        '        OMgr.AvanzaOrdiniAStatoByIdOrd(IdOrd, enStatoOrdine.ProntoRitiro)
                        '    End Using
                        'End If

                        'DISATTIVATO PER ACCORPARE AUTOMATICAMENTE ANCHE LE GLS
                        'If Prossimostato = enStatoOrdine.ProntoRitiro Then
                        If O.ConsegnaAssociata.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then ' O.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, True).Modificabile Then
                            'qui devo vedere se posso accorpare l'ordine
                            Dim TrovataConsegnaDaAccorpare As Boolean = False

                            Using mgr As New ConsegneProgrammateDAO

                                Dim IdOldCons As Integer = O.ConsegnaAssociata.IdCons
                                Dim IdCorr As Integer = O.ConsegnaAssociata.IdCorr
                                Dim IdRub As Integer = O.IdRub
                                Dim IdInd As Integer = O.ConsegnaAssociata.IdIndirizzo

                                Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCons, O.ConsegnaAssociata.IdCons, "<>"),
                                                                                        New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, O.ConsegnaAssociata.IdCorr),
                                                                                        New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdRub, O.ConsegnaAssociata.IdRub),
                                                                                        New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdIndirizzo, O.ConsegnaAssociata.IdIndirizzo),
                                                                                        New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.Si, "<>"),
                                                                                        New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.InLavorazione),
                                                                                        New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Giorno, Date.Now.Date.AddDays(-1), ">"),
                                                                                        New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Giorno, O.ConsegnaAssociata.Giorno, "<="))
                                For Each singC As ConsegnaProgrammata In l
                                    If singC.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then 'singC.ModificabileEx(True, False, True, True, False, True).Modificabile Then

                                        If singC.StampaDocumenti = O.ConsegnaAssociata.StampaDocumenti Then
                                            If singC.NoCartaceo = O.ConsegnaAssociata.NoCartaceo Then

                                                Dim OkStato As Boolean = True

                                                If Prossimostato = enStatoOrdine.ImballaggioCorriere Then

                                                    If singC.ListaOrdini.FindAll(Function(x) x.Stato <> enStatoOrdine.ImballaggioCorriere And x.Stato <> enStatoOrdine.Imballaggio).Count Then
                                                        OkStato = False
                                                    End If

                                                End If

                                                If OkStato Then
                                                    'TOLTO IL 08/04/2015
                                                    'mgr.EliminaOrdineDaConsegna(IdOldCons, O.IdOrd)
                                                    mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd, IdCorr, singC.Giorno, IdRub, enMomentoConsegna.Pomeriggio, IdInd, singC)
                                                    'TOLTO IL 08/04/2015
                                                    'mgr.EliminaConsegnaSeVuota(IdOldCons)
                                                    TrovataConsegnaDaAccorpare = True
                                                    Exit For
                                                End If


                                            End If
                                        End If

                                    End If
                                Next

                                O.SvuotaConsegnaAssociata()

                                If Prossimostato = enStatoOrdine.ProntoRitiro Then
                                    l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCons, O.ConsegnaAssociata.IdCons, "<>"),
                                                                                    New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, O.ConsegnaAssociata.IdCorr),
                                                                                    New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdRub, O.ConsegnaAssociata.IdRub),
                                                                                    New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdIndirizzo, O.ConsegnaAssociata.IdIndirizzo),
                                                                                    New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.Si, "<>"),
                                                                                    New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.InLavorazione),
                                                                                    New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Giorno, O.ConsegnaAssociata.Giorno, ">"))

                                    For Each singC As ConsegnaProgrammata In l
                                        If singC.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then 'singC.ModificabileEx(True, False, True, True, False, True).Modificabile Then

                                            If singC.StampaDocumenti = O.ConsegnaAssociata.StampaDocumenti Then
                                                If singC.NoCartaceo = O.ConsegnaAssociata.NoCartaceo Then
                                                    For Each ONew As Ordine In singC.ListaOrdini
                                                        If ONew.Stato = enStatoOrdine.ProntoRitiro Then
                                                            'qui lo accorpo a questa consegna 
                                                            mgr.RegistraConsegnaOrdineSuGiorno(ONew.IdOrd, IdCorr, singC.Giorno, IdRub, enMomentoConsegna.Pomeriggio, IdInd, O.ConsegnaAssociata)
                                                            'TOLTO IL 08/04/2015
                                                            'mgr.EliminaConsegnaSeVuota(IdOldCons)
                                                            TrovataConsegnaDaAccorpare = True
                                                        End If
                                                    Next
                                                End If
                                            End If
                                        End If
                                    Next
                                End If

                            End Using



                            If TrovataConsegnaDaAccorpare = False Then O.ConsegnaAssociata.AggiornaColliPeso()
                        End If
                        'End If

                        'O.ConsegnaAssociata.ListaOrdini = Nothing

                        'If DovevaPassarePerSoluzione = True And PassatoPerSoluzione = True Then
                        '    If Prossimostato = enStatoOrdine.ImballaggioCorriere And (O.ConsegnaAssociata.IdCorr = enCorriere.GLS Or O.ConsegnaAssociata.IdCorr = enCorriere.PortoAssegnatoGLS) Then
                        '        Cursor.Current = Cursors.WaitCursor
                        '        Try
                        '            cGls.PrenotaSpedizioneGls(O.ConsegnaAssociata)
                        '            'TODO: QUESTO SALVATAGGIO MI PARE INDISPENSABILE; ALTRIMENTI LA CONSEGNA NON VIENE SALVATA DA ALTRE PARTI
                        '            O.ConsegnaAssociata.Save()
                        '        Catch ex As Exception
                        '            '    'TODO: SE VA IN ERRORE (AD ESEMPIO PERCHE' NON C'E' CONNESSIONE AD INTERNET), MANDA FUORI MESSAGGIO ERRORE
                        '            '    'MA ORMAI LA CONSEGNA E' STATA AVANZATA E NON E' PIU' POSSIBILE, LATO OPERATORE, GENERARE L'ETICHETTA GLS;
                        '            '    'BISOGNA PER FORZA FARLO LATO ADMIN
                        '            Using m As New Messaggio
                        '                m.DataIns = Now
                        '                m.Titolo = "Registrazione Consegna su GLS Fallita: " & O.ConsegnaAssociata.IdCons
                        '                m.Testo = "La registrazione della consegna numero " & O.ConsegnaAssociata.IdCons & " su GLS è fallita:" & vbCrLf & ex.Message & vbCrLf & "La registrazione della spedizione deve essere fatta manualmente."
                        '                m.IdMitt = 0
                        '                m.IdDest = FormerConst.UtentiSpecifici.IdUtenteLidia
                        '                m.Save()
                        '            End Using
                        '            MessageBox.Show("Si è verificato un errore nella creazione del segnacollo di GLS:" & vbCrLf & ex.Message & vbCrLf & "Il segnacollo deve essere generato manualmente")
                        '        End Try
                        '        Cursor.Current = Cursors.Default
                        '    End If
                        'End If

                        If O.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente And O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormer And O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo Then
                            If (O.ConsegnaAssociata.ListaOrdini.FindAll(Function(y) y.Stato < enStatoOrdine.ImballaggioCorriere).Count = 0) Then 'And O.ConsegnaAssociata.ListaOrdini.Count > 1) Then 'COMMENTATO 10 MARZO 2014 PER FAR PASSARE SEMPRE 

                                ParentFormEx.Sottofondo()
                                Using fr As New frmConsegnaImballaggio
                                    fr.Carica(O.ConsegnaAssociata.IdCons)
                                End Using
                                ParentFormEx.Sottofondo()

                            End If
                        End If

                        CaricaImballaggio()

                    End If
                End If
            Else
                MessageBox.Show("Selezionare prima la stampante da usare per la stampa etichette!", "Stampa etichette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub DgImballoEx_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgImballoEx.CellClick
        Dim O As Ordine = DirectCast(DgImballoEx.SelectedRows(0).DataBoundItem, Ordine)
        RaiseEvent OrdineSelezionato(O.IdOrd)

    End Sub
    Private Sub btnAvanzaSenzaStampa_Click(sender As Object, e As EventArgs) Handles btnAvanzaSenzaStampa.Click
        StampaEtichette(False)
    End Sub

    Public Event OrdineSelezionato(ByVal IdOrdine As Integer)

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        CaricaImballaggio()
    End Sub

    Private Sub DgImballoEx_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgImballoEx.CellContentClick

    End Sub

    Private Sub DgImballoEx_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgImballoEx.ColumnHeaderMouseClick
        OrdinatoreLista(Of Ordine).OrdinaLista(sender, e)
    End Sub
End Class
