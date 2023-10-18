Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerPrinter
Imports FormerBusinessLogic

Friend Class frmConsegnaOrdiniRCTF
    'Inherits baseFormInternaRedim

    Private _Ris As Integer = 0

    Private _IdRub As Integer = 0

    Private _IdIndirizzo As Integer = 0

    Private _IdCons As Integer = 0

    Friend Function Carica(IdCons As Integer) As Integer

        _IdCons = IdCons

        'qui mi arriva l'id della consegna e devo lavorare solo quella
        CaricaOrdiniProntiRitiro()

        Dim OrdiniSenzaStampaEtichette As Boolean = False

        Dim SoloRitiroClienteTipografiaFormer As Boolean = True

        Using c As New ConsegnaProgrammata
            c.Read(_IdCons)
            For Each O In c.ListaOrdini
                Dim RisStampareEtichette As Boolean = MgrFormerException.StampareEtichetteOrdine(O)
                If RisStampareEtichette = False Then
                    OrdiniSenzaStampaEtichette = True
                    Exit For
                End If
            Next

            If c.IdCorr <> enCorriere.RitiroCliente And c.IdCorr <> enCorriere.TipografiaFormer And c.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo Then
                SoloRitiroClienteTipografiaFormer = False
            End If

        End Using

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Or OrdiniSenzaStampaEtichette = True Then
            btnOkAll.Visible = True
            btnUscitoSel.Visible = True
        End If

        If SoloRitiroClienteTipografiaFormer = False Then
            MessageBox.Show("Da questa maschera è possibile gestire solo ordini con ritiro cliente o corriere Tipografia Former!")
            tmrColli.Enabled = False
        Else
            ShowDialog()
        End If

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs)
        Close()

    End Sub

    Private Sub btnSalva_Click(sender As Object, e As EventArgs)
        _Ris = 1
        Salva()

    End Sub

    Private Sub Salva()
        If DgLavori.Rows.Count Then
            If MessageBox.Show("Confermi l'uscita dal magazzino dei colli inseriti?", "Consegna colli", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim okAll As Boolean = True
                Dim okConsegnaBloccata As Boolean = True

                Dim TrovatiOrdiniNonConsegnati As Boolean = False

                For Each dr As DataGridViewRow In DgLavori.Rows
                    If dr.Cells(5).Value = 0 Then
                        okAll = False
                    Else
                        If dr.Cells(4).Value <> dr.Cells(5).Value Then
                            TrovatiOrdiniNonConsegnati = True
                            If dr.Cells(4).Value <> 0 Then
                                okAll = False
                            End If
                        End If
                    End If
                Next

                Dim IdConsSel As Integer = _IdCons
                Dim ConsegnaProgrammataInCorso As New ConsegnaProgrammata
                ConsegnaProgrammataInCorso.Read(_IdCons)

                Dim GiornoOriginale As Date = ConsegnaProgrammataInCorso.Giorno

                'IF modificabile(true)
                If ConsegnaProgrammataInCorso.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito = False Then 'ConsegnaProgrammataInCorso.ModificabileEx(True, False, True, True, False, True).Modificabile = False Then
                    'qui devo fare il controllo che se sto lavorando una consegna bloccata devono per forza uscire tutti
                    If TrovatiOrdiniNonConsegnati Then okConsegnaBloccata = False
                End If

                If okAll = True And okConsegnaBloccata = True Then

                    'Dim IdOrdini As New List(Of Integer)
                    For Each dr As DataGridViewRow In DgLavori.Rows
                        If dr.Cells(4).Value <> 0 Then
                            If DirectCast(dr.Tag, String).StartsWith("O") Then
                                'ordine
                                Dim IdOrd As Integer = dr.Cells(1).Value
                                Using m As New OrdiniDAO
                                    m.InserisciLog(IdOrd, FormerEnum.enStatoOrdine.UscitoMagazzino)
                                    ' IdOrdini.Add(IdOrd)

                                    Dim CambiatoConsegna As Boolean = False

                                    If ConsegnaProgrammataInCorso.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then 'ConsegnaProgrammataInCorso.ModificabileEx(True, False, True, True, False, False).Modificabile Then
                                        'qui devo vedere se lo posso accorpare con un altra in caso ci sia
                                        Using mgrC As New ConsegneProgrammateDAO

                                            'Dim l As List(Of ConsegnaProgrammata) = mgrC.FindAll(New LUNA.LunaSearchParameter("IdCons", ConsegnaProgrammataInCorso.IdCons, "<>"), _
                                            '                                                     New LUNA.LunaSearchParameter("IdRub", ConsegnaProgrammataInCorso.IdRub), _
                                            '                                                     New LUNA.LunaSearchParameter("Giorno", ConsegnaProgrammataInCorso.Giorno), _
                                            '                                                     New LUNA.LunaSearchParameter("IdCorr", ConsegnaProgrammataInCorso.IdCorr), _
                                            '                                                     New LUNA.LunaSearchParameter("IdIndirizzo", ConsegnaProgrammataInCorso.IdIndirizzo), _
                                            '                                                     New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.InLavorazione), _
                                            '                                                     New LUNA.LunaSearchParameter("Eliminato", enSiNo.Si, "<>"))

                                            Dim l As List(Of ConsegnaProgrammata) = mgrC.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCons, ConsegnaProgrammataInCorso.IdCons, "<>"),
                                                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdRub, ConsegnaProgrammataInCorso.IdRub),
                                                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Giorno, Now.Date, ">="),
                                                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, ConsegnaProgrammataInCorso.IdCorr),
                                                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdIndirizzo, ConsegnaProgrammataInCorso.IdIndirizzo),
                                                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.InLavorazione),
                                                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.Si, "<>"))

                                            For Each singC As ConsegnaProgrammata In l
                                                If singC.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then 'singC.ModificabileEx(True, False, True, True, False, False).Modificabile Then
                                                    If singC.HaSoloOrdiniUscitiDaMagazzino Then
                                                        'qui mi potrei agganciare con l'ordine
                                                        'TOLTO IL 08/04/2015
                                                        'mgrC.EliminaOrdineDaConsegna(0, IdOrd)
                                                        mgrC.RegistraConsegnaOrdineSuGiorno(IdOrd, ConsegnaProgrammataInCorso.IdCorr, ConsegnaProgrammataInCorso.Giorno, ConsegnaProgrammataInCorso.IdRub, enMomentoConsegna.Pomeriggio, ConsegnaProgrammataInCorso.IdIndirizzo, singC)
                                                        CambiatoConsegna = True
                                                        Exit For
                                                    End If
                                                End If
                                            Next
                                        End Using

                                    End If

                                    If CambiatoConsegna = False Then
                                        If ConsegnaProgrammataInCorso.ListaIdDocumenti.Count Then
                                            Dim NuovoStato As enStatoOrdine = enStatoOrdine.InConsegna

                                            If ConsegnaProgrammataInCorso.IdCorr = enCorriere.RitiroCliente Then
                                                NuovoStato = enStatoOrdine.Consegnato
                                            End If
                                            m.InserisciLog(IdOrd, NuovoStato)
                                        End If
                                    End If
                                End Using

                            End If
                        End If
                    Next

                    Using mgr As New OrdiniDAO
                        Dim lstOrdSganciare As List(Of Ordine) = mgr.ListaOrdiniConsegnaDaSganciare(ConsegnaProgrammataInCorso.IdCons)

                        Dim DataNuova As Date = Now.Date

                        Dim ConsideraOggi As Boolean = True

                        If Now.Hour > 14 Then
                            ConsideraOggi = False
                        End If


                        'qui devo vedere se la data originale e' da domani in poi allora li rimetto a quella data altrimenti mi faccio dare la prima disponibile

                        If DateDiff(DateInterval.Day, Now.Date, GiornoOriginale) > 0 Then
                            DataNuova = GiornoOriginale
                        Else
                            DataNuova = MgrDataConsegna.GetPrimaDataDisponibile(DataNuova, ConsegnaProgrammataInCorso.IdCorr, ConsideraOggi)
                        End If

                        'DataNuova = MgrDataConsegna.PosticipaAProssimoGiornoUtile(DataNuova, ConsegnaProgrammataInCorso.IdCorr)
                        'tenere sotto controllo
                        '01/06/2015 - modifica effettuata per consegna messa nei giorni di festa

                        'Select Case Now.DayOfWeek
                        '    Case DayOfWeek.Saturday
                        '        DataNuova = DataNuova.AddDays(2)
                        '    Case DayOfWeek.Friday
                        '        If ConsegnaProgrammataInCorso.IdCorr = enCorriere.RitiroCliente Then
                        '            DataNuova = DataNuova.AddDays(1)
                        '        Else
                        '            DataNuova = DataNuova.AddDays(3)
                        '        End If
                        '    Case Else
                        '        DataNuova = DataNuova.AddDays(1)
                        'End Select

                        Using mgrC As New ConsegneProgrammateDAO
                            For Each ord As Ordine In lstOrdSganciare
                                'TOLTO IL 08/04/2015
                                'mgrC.EliminaOrdineDaConsegna(0, ord.IdOrd)
                                mgrC.RegistraConsegnaOrdineSuGiorno(ord.IdOrd,
                                                                ord.IdCorriere,
                                                                DataNuova,
                                                                ord.IdRub,
                                                                enMomentoConsegna.Pomeriggio,
                                                                ord.IdIndirizzo,,,,
                                                                ConsegnaProgrammataInCorso.IdCons,, True)
                            Next
                            'TOLTO IL 08/04/2015
                            'mgrC.EliminaConsegnaSeVuota(ConsegnaProgrammataInCorso.IdCons)
                        End Using
                    End Using

                    Dim RisStampaDocumenti As Integer = 0
                    If ConsegnaProgrammataInCorso.Eliminato <> enSiNo.Si Then

                        If ConsegnaProgrammataInCorso.StampaDocumenti = enStampaDocumenti.Si Then

                            If ConsegnaProgrammataInCorso.HaDocumentiFiscali = False Then
                                ConsegnaProgrammataInCorso.AggiornaColliPeso()
                                'EMETTO I DOCUMENTI
                                RisStampaDocumenti = ProxyDocumenti.CreaDocumenti(ConsegnaProgrammataInCorso.IdCons,
                                                                                True,
                                                                                False,
                                                                                PostazioneCorrente.UtenteConnesso.IdUt)
                            End If

                            If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then
                                'STAMPO TUTTI I DOCUMENTI
                                'ProxyStampa.StampanteLibera = PostazioneCorrente.StampanteLiberaOperatore
                                'ProxyStampa.StampanteFatture = PostazioneCorrente.StampanteFattureOperatore
                                For Each R As Ricavo In ConsegnaProgrammataInCorso.ListaDocumenti
                                    Try
                                        MgrDocumentiFiscali.MessaggioModuloFattura(R, FormerLib.FormerConst.Fiscali.NumCopieDocFiscali)
                                        ProxyStampa.StampaDocumentoFiscale(R,
                                                                        False,
                                                                        FormerLib.FormerConst.Fiscali.NumCopieDocFiscali,
                                                                        PostazioneCorrente.UtenteConnesso.IdUt) 'modificato a true per stampare diretto
                                    Catch ex As Exception
                                        MessageBox.Show("Si è verificato un errore nella stampa del documento fiscale, riprovare")
                                    End Try
                                Next
                                'ProxyStampa.StampanteLibera = PostazioneCorrente.StampanteLibera
                                'ProxyStampa.StampanteFatture = PostazioneCorrente.StampanteFatture

                            Else
                                For Each R As Ricavo In ConsegnaProgrammataInCorso.ListaDocumenti
                                    Try
                                        MgrDocumentiFiscali.MessaggioModuloFattura(R, FormerLib.FormerConst.Fiscali.NumCopieDocFiscali)
                                        ProxyStampa.StampaDocumentoFiscale(R, True, FormerLib.FormerConst.Fiscali.NumCopieDocFiscali, PostazioneCorrente.UtenteConnesso.IdUt)
                                    Catch ex As Exception
                                        MessageBox.Show("Si è verificato un errore nella stampa del documento fiscale, riprovare")
                                    End Try
                                Next
                            End If

                        End If

                        'qui devo stampare in automatico il riepilogo della consegna

                        'If PostazioneCorrente.StampanteConsegnaOrdini.Length Then

                        '    ProxyDocumenti.StampaConsegnaOrdini(ConsegnaProgrammataInCorso.IdCons)

                        'End If

                    End If

                    Dim Messaggio As String = "I colli sono stati correttamente scaricati da magazzino"

                    If RisStampaDocumenti = 1 Then
                        'si devono ritirare documenti
                        Messaggio &= vbNewLine & vbNewLine & "Si prega di RITIRARE i relativi documenti contabili in amministrazione"
                    ElseIf RisStampaDocumenti = 2 Then
                        'si deve saldare il pagamento
                        Messaggio &= vbNewLine & vbNewLine & "Si prega di RITIRARE i relativi documenti contabili in amministrazione e SALDARE l'importo"
                    End If
                    MessageBox.Show(Messaggio)

                    Close()
                Else
                    If okConsegnaBloccata = False Then
                        MessageBox.Show("La consegna può essere effettuata solo consegnando TUTTI gli ordini previsti!")
                    Else
                        MessageBox.Show("E' obbligatorio passare con il lettore codice a barre tutti i colli previsti di ogni ordine iniziato, e non è possibile far uscire da magazzino ordini che non hanno il numero di colli uguale a 0!")
                    End If
                End If
            End If

        Else
            Close()

        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        CaricaColli()

    End Sub

    Private IdOrdRif As Integer = 0
    'Private IdConsRif As Integer = 0
    Private MsgSupplement As String = ""
    Private Messaggio As String = ""

    Private Sub CaricaColli()

        Dim Ris As String = "GO"

        While Ris.Length

            'Sottofondo()

            Dim x As New frmMagazzinoBarCodeRCTF

            Ris = x.Carica(Messaggio, IdOrdRif, _IdCons, MsgSupplement)
            Ris = Ris.TrimEnd
            Ris = Ris.TrimStart
            'Sottofondo()

            If Ris.Length = 12 Or Ris.Length = 13 Then
                Ris = Ris.Substring(0, 12)
                'qui si puo trattare di un ordine in consegna tramite corriere o diretto quindi ho i due codici da gestire
                Dim CodiceRifs As String = ""
                Dim CodiceRif As Integer = 0
                Dim NumCollo As Integer = 0
                If Ris.StartsWith("9") Then
                    CodiceRifs = Ris.Substring(1, 7)

                    NumCollo = Ris.Substring(8, 4)

                    'SCATOLA 
                    'QUI HO IL CODICE SCATOLA, IL NUMERO COLLO SARA' SEMPRE 1 
                    CodiceRif = CInt(CodiceRifs)

                    Dim S As New FormerDALSql.Scatola
                    S.Read(CodiceRif)

                    If S.IdScatola Then
                        'qui devo caricare tutti i colli contenuti dentro la scatola
                        Dim ListaColli As List(Of OrdineScatola) = Nothing

                        Using mgr As New OrdiniScatoleDAO
                            ListaColli = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.OrdineScatola.IdScatola, S.IdScatola))
                        End Using

                        For Each singCollo As OrdineScatola In ListaColli

                            'qui scarico ogni singolo collo 
                            ScaricaColloOrdine(singCollo.IdOrdine, singCollo.NumeroCollo)

                        Next

                    Else
                        'qui la scatola non è valida 
                        MgrSound.Suona(enTipoSuono.ErroreCodiceInseritoNonValido)
                        MsgSupplement = "Il codice inserito non è valido"
                    End If

                ElseIf Ris.StartsWith("0") Then
                    CodiceRifs = Ris.Substring(0, 7)

                    NumCollo = Ris.Substring(7, 4)

                    'PACCO ORDINE
                    CodiceRif = CInt(CodiceRifs)

                    ScaricaColloOrdine(CodiceRif, NumCollo)

                ElseIf Ris.StartsWith("8") Then 'COMANDO SPECIALE
                    Dim Comando As String = Ris.Substring(11, 1)
                    If Comando = "1" Then
                        'qui devo chiudere l'operazione di inserimento e se possibile chiudere anche la lavorazione
                        Ris = ""
                        Salva()
                    End If

                End If
            Else
                If Ris.Length Then
                    'MessageBox.Show("Codice formalmente non valido")
                    MgrSound.Suona(enTipoSuono.ErroreCodiceInseritoNonValido)
                    MsgSupplement = "Codice inserito non valido"
                End If

            End If
        End While
    End Sub

    Private Sub ScaricaColloOrdine(CodiceRif As Integer, NumCollo As Integer)

        Dim O As New Ordine
        O.Read(CodiceRif)
        If O.IdOrd Then

            If _IdRub = 0 Then
                _IdRub = O.IdRub
                _IdIndirizzo = O.IdIndirizzo
                'If O.Stato = enStatoOrdine.ProntoRitiro Then CaricaOrdiniProntiRitiro()
            End If
            If _IdRub <> O.IdRub Then
                'MessageBox.Show("Non si possono scaricare da magazzino ordini di clienti diversi")
                MgrSound.Suona(enTipoSuono.ErroreNoClientiDiversi)
                MsgSupplement = "Non si possono scaricare da magazzino ordini di clienti diversi"
            Else
                Dim SwTrovato As Boolean = False
                Dim Dr As DataGridViewRow = Nothing
                For Each drEsist As DataGridViewRow In DgLavori.Rows
                    If drEsist.Cells(1).Value = CodiceRif Then
                        SwTrovato = True
                        Dr = drEsist
                        Exit For
                    End If
                Next
                If O.Stato = enStatoOrdine.ProntoRitiro Then
                    If SwTrovato = False Then

                        MessageBox.Show("L'ordine selezionato non appartiene a questa consegna e non può essere caricato.")
                        'qui lo inserisco 

                        'Dr = New DataGridViewRow

                        'Dim ImgPreview As Image
                        'Dim ImgNew As Image = Nothing
                        'Try
                        '    ImgPreview = Image.FromFile(O.FilePath)
                        '    ImgNew = New Bitmap(ImgPreview, New Size(50, 75))
                        'Catch ex As Exception

                        'End Try

                        'Dr.CreateCells(DgLavori)

                        'Dr.Cells(0).Value = ImgNew
                        'Dr.Cells(1).Value = O.IdOrd
                        'Dr.Cells(2).Value = O.Prodotto.Descrizione
                        'Dr.Cells(3).Value = O.VoceRubrica.Nominativo
                        'Dr.Cells(4).Value = 1
                        'Dr.Cells(5).Value = O.NumeroRealeColli
                        'Dr.Cells(6).Value = FormattaPrezzo(O.TotaleImponibile)
                        'Dr.Tag = "O," & NumCollo & ","

                        'DgLavori.Rows.Add(Dr)

                        MsgSupplement = ""

                    Else
                        'qui in dr ho gia la riga interessata
                        'controllo che il pacco non sia stato gia sparato

                        Dim TrovatoCollo As Integer = DirectCast(Dr.Tag.ToString, String).IndexOf("," & NumCollo & ",")
                        If TrovatoCollo = -1 Then
                            'qui non l'ho trovato
                            Dr.Cells(4).Value = CInt(Dr.Cells(4).Value) + 1
                            Dr.Tag &= NumCollo & ","
                            MsgSupplement = ""
                            'Try
                            DgLavori.Sort(New RowComparer(SortOrder.Descending))
                        Else
                            'MessageBox.Show("Collo gia caricato")
                            MgrSound.Suona(enTipoSuono.ErroreColloGiaCaricato)
                            MsgSupplement = "Collo già caricato"
                        End If

                    End If
                    'qui cmq vada in dr ho la riga relativa a cosa stavo lavorando
                    If Not Dr Is Nothing Then
                        'è nothing se era un collo di un altra consegna
                        Dim nCollicaricati As Integer = (DirectCast(Dr.Tag.ToString(), String).Split(",").Count) - 2
                        If O.NumeroRealeColli <> nCollicaricati Then
                            IdOrdRif = O.IdOrd
                            'IdConsRif = 0
                            Messaggio = "Devono ancora essere caricati " & O.NumeroRealeColli - nCollicaricati & " colli"
                        Else
                            IdOrdRif = 0
                            'IdConsRif = 0
                            Messaggio = ""
                            MsgSupplement = ""
                            MgrSound.Suona(enTipoSuono.OkGiroCompletato)

                        End If
                    End If
                Else
                    'qui l'ordine non e' in stato preinserito
                    MessageBox.Show("L'ordine selezionato si trova nello stato " & O.StatoStr & " e non può essere caricato.")
                    MgrSound.Suona(enTipoSuono.ErroreColloGiaCaricato)
                    IdOrdRif = 0
                    'IdConsRif = 0
                    Messaggio = ""
                    _IdRub = 0
                    MsgSupplement = "Merce già consegnata"
                End If
            End If
        Else
            'MessageBox.Show("Codice inserito non valido")
            MgrSound.Suona(enTipoSuono.ErroreCodiceInseritoNonValido)
            MsgSupplement = "Codice inserito non valido"

        End If

    End Sub

    Private Sub CaricaOrdiniProntiRitiro()

        Dim dt As DataTable, riga As DataRow

        Using Ordini As New cOrdiniColl
            Ordini.IdRub = _IdRub
            'dt = Ordini.Lista(, enStatoOrdine.ProntoRitiro, , , , , ,  True, , , , , _IdIndirizzo)
            dt = Ordini.Lista(, enStatoOrdine.ProntoRitiro, , , , , , True, , , , _IdCons, )
        End Using
        For Each riga In dt.Rows
            Dim Dr As New DataGridViewRow

            Dim ImgPreview As Image
            Dim ImgNew As Image = Nothing
            Try
                ImgPreview = Image.FromFile(riga("filePath").ToString)
                ImgNew = New Bitmap(ImgPreview, New Size(50, 75))
            Catch ex As Exception
                ImgNew = Nothing
            End Try

            Dr.CreateCells(DgLavori)

            Dr.Cells(0).Value = ImgNew
            Dr.Cells(1).Value = riga("ord")
            Dr.Cells(2).Value = riga("Prodotto")
            Dr.Cells(3).Value = riga("Cliente")
            Dr.Cells(4).Value = "0"
            Dr.Cells(5).Value = IIf(IsDBNull(riga("NumeroRealeColli")), riga("NumeroPrevistoColli"), riga("NumeroRealeColli"))
            Dr.Cells(6).Value = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(riga("TotaleImp").ToString)
            'Dr.Cells(5).Value = IIf(CInt(riga("preventivo").ToString) = enPreventivoSiNo.Si, "Si", "No")
            Dr.Tag = "O,"
            DgLavori.Rows.Add(Dr)
        Next
        DgLavori.Sort(New RowComparer(SortOrder.Descending))
    End Sub
    Private Sub DgLavori_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgLavori.RowPostPaint
        Dim x As DataGridViewRow = DgLavori.Rows.Item(e.RowIndex)

        If x.Cells(4).Value <> x.Cells(5).Value Then
            x.Cells(4).Style.BackColor = Color.Red
            x.Cells(4).Style.SelectionBackColor = Color.Red
        Else
            x.Cells(4).Style.BackColor = Color.Green
            x.Cells(4).Style.SelectionBackColor = Color.Green
        End If

    End Sub

    Private Sub tmrColli_Tick(sender As Object, e As EventArgs) Handles tmrColli.Tick
        tmrColli.Enabled = False
        CaricaColli()

    End Sub

    Private Class RowComparer
        Implements System.Collections.IComparer

        Private sortOrderModifier As Integer = 1

        Public Sub New(ByVal sortOrder As SortOrder)
            If sortOrder = SortOrder.Descending Then
                sortOrderModifier = -1
            ElseIf sortOrder = SortOrder.Ascending Then

                sortOrderModifier = 1
            End If
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
            Implements System.Collections.IComparer.Compare

            Dim DataGridViewRow1 As DataGridViewRow = CType(x, DataGridViewRow)
            Dim DataGridViewRow2 As DataGridViewRow = CType(y, DataGridViewRow)

            ' Try to sort based on the Last Name column.
            Dim CompareResult As Integer = System.String.Compare( _
                DataGridViewRow1.Cells(4).Value.ToString(), _
                DataGridViewRow2.Cells(4).Value.ToString())

            ' If the Last Names are equal, sort based on the First Name.
            'If CompareResult = 0 Then
            '    CompareResult = System.String.Compare( _
            '        DataGridViewRow1.Cells(0).Value.ToString(), _
            '        DataGridViewRow2.Cells(0).Value.ToString())
            'End If
            Return CompareResult * sortOrderModifier
        End Function
    End Class

    Private Sub chkEmettiDoc_CheckedChanged(sender As Object, e As EventArgs) Handles chkEmettiDoc.CheckedChanged
        If chkEmettiDoc.Checked = False Then
            MessageBox.Show("ATTENZIONE! Disabilitando l'emissione dei documenti fiscali non verranno emessi documenti relativi alla merce uscita da magazzino!", , MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnOkAll_Click(sender As Object, e As EventArgs) Handles btnOkAll.Click

        If MessageBox.Show("Vuoi segnare tutti i colli come usciti?", "Consegna colli", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            For Each dr As DataGridViewRow In DgLavori.Rows
                dr.Cells(4).Value = dr.Cells(5).Value
            Next

        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Close()

    End Sub

    Private Sub btnSalva_Click_1(sender As Object, e As EventArgs) Handles btnSalva.Click
        _Ris = 1
        Salva()
    End Sub

    Private Sub btnUscitoSel_Click(sender As Object, e As EventArgs) Handles btnUscitoSel.Click

        If DgLavori.SelectedRows.Count Then
            If MessageBox.Show("Vuoi segnare uscito l'ordine selezionato?", "Consegna colli", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                DgLavori.SelectedRows(0).Cells(4).Value = DgLavori.SelectedRows(0).Cells(5).Value
            End If
        Else
            Beep()
        End If

    End Sub
End Class


