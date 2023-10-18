Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerPrinter
Imports FormerBusinessLogic
Imports FormerWebLabeling
Imports FormerConfig

Friend Class frmConsegnaOrdiniCorriere
    'Inherits baseFormInternaRedim

    Private _Ris As Integer = 0

    Private _IdRub As Integer = 0

    Private _IdIndirizzo As Integer = 0

    Private _lstCons As List(Of ConsegnaProgrammata) = Nothing

    Private _IdCorr As Integer = 0

    Private _IdCorrString As String = String.Empty

    Private _Corriere As String = String.Empty

    Friend Function Carica() As Integer

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaConsegne()

        Select Case _IdCorr
            Case enCorriere.GLS, enCorriere.PortoAssegnatoGLS, enCorriere.GLSIsole
                _Corriere = "GLS"
                _IdCorrString = "(" & enCorriere.GLS & ", " & enCorriere.PortoAssegnatoGLS & "," & enCorriere.GLSIsole & ")"
            Case enCorriere.Bartolini, enCorriere.PortoAssegnatoBartolini
                _Corriere = "Bartolini"
                _IdCorrString = "(" & enCorriere.Bartolini & ", " & enCorriere.PortoAssegnatoBartolini & ")"
        End Select

        Using mgr As New ConsegneProgrammateDAO
            '_lstCons = mgr.FindAll("CodTrack",
            '                       New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.RegistrataCorriere),
            '                       New LUNA.LunaSearchParameter("IdCorr", _IdCorrString, "IN"),
            '                       New LUNA.LunaSearchParameter("CodTrack", String.Empty, "<>"),
            '                       New LUNA.LunaSearchParameter("Eliminato", enSiNo.No))
            _lstCons = mgr.ListaConsegneCorriereConsegnabili(_IdCorrString)
        End Using

        For Each Cons As ConsegnaProgrammata In _lstCons

            Dim Dr As New DataGridViewRow

            Dim ImgNew As Image = Nothing

            Dr.CreateCells(DgLavori)

            Dr.Cells(0).Value = Cons.IdCons
            Dr.Cells(1).Value = Cons.Cliente.RagSocNome
            Dr.Cells(2).Value = Cons.CodTrack
            Dr.Cells(3).Value = Cons.Giorno.ToString("dd/MM/yyyy")
            Dr.Cells(4).Value = "0"
            Dr.Cells(5).Value = Cons.NumColli
            Dr.Cells(6).Value = Cons.Peso
            'Dr.Cells(5).Value = IIf(CInt(riga("preventivo").ToString) = enPreventivoSiNo.Si, "Si", "No")
            Dr.Tag = "C,"
            DgLavori.Rows.Add(Dr)

        Next

        'DgLavori.Sort(DgLavori.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
        DgLavori.Sort(DgLavori.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

    End Sub

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

    Private Sub Salva()
        If DgLavori.Rows.Count Then

            Dim OkGls As Boolean = True

            'Test Servizi GLS 
            Dim TestGlsOk As Boolean = False

            TestGlsOk = FormerHelper.Web.IsOkWebsite("https://weblabeling.gls-italy.com")

            If TestGlsOk = False Then
                If MessageBox.Show("Il servizio di GLS non sembra funzionante, vuoi continuare comunque?", "GLS Test", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    OkGls = False
                End If
            End If

            If OkGls Then
                If MessageBox.Show("Confermi l'uscita dal magazzino dei colli inseriti?", "Consegna colli", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim Messaggio As String = String.Empty
                    Dim MessaggioDocumentiFiscali As String = String.Empty
                    Dim TrasmettiCorriere As Boolean = False

                    For Each dr As DataGridViewRow In DgLavori.Rows
                        Dim okAll As Boolean = True
                        Dim okConsegnaBloccata As Boolean = True
                        Dim TrovatiOrdiniNonConsegnati As Boolean = False
                        Dim TrovatiOrdiniNonConsegnatiConsegnaDuplicata As Boolean = False

                        If dr.Cells(5).Value = 0 Then
                            okAll = False
                        Else
                            If dr.Cells(4).Value = 0 Then
                                okAll = False
                            Else
                                If dr.Cells(4).Value <> dr.Cells(5).Value Then
                                    TrovatiOrdiniNonConsegnati = True
                                    okAll = False
                                End If
                            End If
                        End If

                        Dim Idcons As Integer = dr.Cells(0).Value
                        Dim GiornoOriginale As Date
                        Dim ConsegnaProgrammataInCorso As ConsegnaProgrammata = New ConsegnaProgrammata
                        ConsegnaProgrammataInCorso.Read(Idcons)
                        GiornoOriginale = ConsegnaProgrammataInCorso.Giorno

                        If ConsegnaProgrammataInCorso.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito = False Then 'ConsegnaProgrammataInCorso.ModificabileEx(True, False, True, True, False, True).Modificabile = False Then
                            'qui devo fare il controllo che se sto lavorando una consegna bloccata devono per forza uscire tutti
                            If TrovatiOrdiniNonConsegnati Then okConsegnaBloccata = False
                        End If

                        Dim HaDocumentiFiscali As Boolean = True

                        If okAll = True And okConsegnaBloccata = True Then

                            'QUI CONTROLLO SE E' GIA' STATO EMESSO IL DOCUMENTO FISCALE E SE IL VALORE DI STAMPADOCUMENTI E' QUELLO PER L'USCITA FORZATA SENZA DOCUMENTI
                            If ConsegnaProgrammataInCorso.HaDocumentiFiscali = False And
                           ConsegnaProgrammataInCorso.StampaDocumenti <> enStampaDocumenti.ForzaUscita Then
                                'okAll = False
                                HaDocumentiFiscali = False
                            End If

                            For Each drEsist As DataGridViewRow In DgLavori.Rows
                                If drEsist.Cells(2).Value = ConsegnaProgrammataInCorso.CodTrack And
                                   drEsist.Cells(0).Value <> ConsegnaProgrammataInCorso.IdCons And
                                   drEsist.Cells(4).Value <> drEsist.Cells(5).Value Then
                                    TrovatiOrdiniNonConsegnatiConsegnaDuplicata = True
                                    okAll = False
                                    Exit For
                                End If
                            Next
                        End If

                        If okAll = True And okConsegnaBloccata = True Then

                            For Each O As Ordine In ConsegnaProgrammataInCorso.ListaOrdini

                                If DirectCast(dr.Tag, String).StartsWith("C") Then
                                    'CONSEGNA

                                    Dim IdOrd As Integer = O.IdOrd
                                    Using m As New OrdiniDAO
                                        m.InserisciLog(IdOrd, FormerEnum.enStatoOrdine.UscitoMagazzino)
                                        ' IdOrdini.Add(IdOrd)

                                        If ConsegnaProgrammataInCorso.ListaIdDocumenti.Count Then
                                            Dim NuovoStato As enStatoOrdine = enStatoOrdine.InConsegna
                                            m.InserisciLog(IdOrd, NuovoStato, , False)
                                        End If

                                    End Using

                                End If

                            Next

                            Using mgr As New ConsegneProgrammateDAO()
                                mgr.AvanzaStatoConsegna(ConsegnaProgrammataInCorso, enStatoConsegna.InConsegna)
                                ConsegnaProgrammataInCorso.IdStatoConsegna = enStatoConsegna.InConsegna
                            End Using

                            Using mgr As New OrdiniDAO
                                Dim lstOrdSganciare As List(Of Ordine) = mgr.ListaOrdiniConsegnaDaSganciare(ConsegnaProgrammataInCorso.IdCons)

                                Dim DataNuova As Date = Now.Date

                                'DataNuova = MgrDataConsegna.PosticipaAProssimoGiornoUtile(DataNuova, ConsegnaProgrammataInCorso.IdCorr)


                                If DateDiff(DateInterval.Day, Now.Date, GiornoOriginale) > 0 Then
                                    DataNuova = GiornoOriginale
                                Else
                                    DataNuova = MgrDataConsegna.GetPrimaDataDisponibile(DataNuova,
                                                                                    ConsegnaProgrammataInCorso.IdCorr)
                                End If
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
                                                                            ord.IdIndirizzo)
                                    Next
                                    'TOLTO IL 08/04/2015
                                    'mgrC.EliminaConsegnaSeVuota(ConsegnaProgrammataInCorso.IdCons)
                                End Using
                            End Using

                            Messaggio = "I colli sono stati correttamente scaricati da magazzino"

                            If HaDocumentiFiscali = False And ConsegnaProgrammataInCorso.StampaDocumenti <> enStampaDocumenti.ForzaUscita Then
                                MessaggioDocumentiFiscali &= "Per la consegna numero " & ConsegnaProgrammataInCorso.IdCons & " di " & ConsegnaProgrammataInCorso.IndirizzoRif.Destinatario & " non sono stati emessi documenti fiscali! Passare in amministrazione!" & ControlChars.NewLine
                            End If

                            If HaDocumentiFiscali = True And ConsegnaProgrammataInCorso.NoCartaceo = enSiNo.Si Then
                                MessaggioDocumentiFiscali &= "Per la consegna numero " & ConsegnaProgrammataInCorso.IdCons & " di " & ConsegnaProgrammataInCorso.IndirizzoRif.Destinatario & " i documenti fiscali non vanno inseriti all'interno del pacco!" & ControlChars.NewLine
                            End If

                            TrasmettiCorriere = True

                            If ConsegnaProgrammataInCorso.DataTrasmissioneCorriere <> Date.MinValue And
                               ConsegnaProgrammataInCorso.NoRegistrazioneGLS <> enSiNo.Si Then
                                ConsegnaProgrammataInCorso.DataTrasmissioneCorriere = Now.Date
                            Else
                                ConsegnaProgrammataInCorso.DataTrasmissioneCorriere = Date.MinValue
                            End If

                            ConsegnaProgrammataInCorso.Save()

                            'If RisStampaDocumenti = 1 Then
                            '    'si devono ritirare documenti
                            '    Messaggio &= vbNewLine & vbNewLine & "Si prega di RITIRARE i relativi documenti contabili in amministrazione"
                            'ElseIf RisStampaDocumenti = 2 Then
                            '    'si deve saldare il pagamento
                            '    Messaggio &= vbNewLine & vbNewLine & "Si prega di RITIRARE i relativi documenti contabili in amministrazione e SALDARE l'importo"
                            'End If
                        Else
                            Dim BufferErrore As String = String.Empty

                            If okConsegnaBloccata = False Then
                                BufferErrore &= "La consegna numero " & ConsegnaProgrammataInCorso.IdCons & " può essere effettuata solo consegnando TUTTI i colli previsti!" & ControlChars.NewLine
                                'ElseIf HaDocumentiFiscali = False And okConsegnaBloccata = True Then
                                '    BufferErrore &= "La consegna numero " & ConsegnaProgrammataInCorso.IdCons & " non può ancora essere spedita con corriere perché non sono stati emessi documenti fiscali! Passare in amministrazione!" & ControlChars.NewLine
                            End If
                            If TrovatiOrdiniNonConsegnatiConsegnaDuplicata Then
                                BufferErrore &= "La consegna numero " & ConsegnaProgrammataInCorso.IdCons & " può essere effettuata solo consegnando TUTTI i colli delle altre consegne che hanno lo stesso Codice Tracking!" & ControlChars.NewLine
                            End If

                            If BufferErrore.Length Then
                                MessageBox.Show(BufferErrore)
                            End If

                        End If
                    Next

                    If Messaggio <> String.Empty Then
                        MessageBox.Show(Messaggio & ControlChars.NewLine & MessaggioDocumentiFiscali)
                    End If

                    If TrasmettiCorriere Then
                        ChiudiCorriere()
                        Close()
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
        Try
            While Ris.Length

                'Sottofondo()

                Dim x As New frmMagazzinoBarCodeCorriere

                Ris = x.Carica(Messaggio, _IdCorr, MsgSupplement)
                Ris = Ris.TrimEnd
                Ris = Ris.TrimStart

                'Sottofondo()

                If Ris.Length = 15 Or Ris.Length = 16 Or Ris.Length = 18 Then
                    'Ris = Ris.Substring(0, 12)
                    'qui si puo trattare di un ordine in consegna tramite corriere o diretto quindi ho i due codici da gestire
                    Dim CodiceRifs As String = ""
                    Dim CodiceRif As String = ""
                    Dim NumCollo As Integer = 0
                    If Ris.ToUpper.StartsWith("R2") Or Ris.Length = 16 Then
                        'GLS
                        CodiceRifs = Ris.Substring(2, 9)

                        NumCollo = Ris.Substring(11, 2) '(11,2)

                        'SCATOLA 
                        'QUI HO IL CODICE SCATOLA, IL NUMERO COLLO SARA' SEMPRE 1 
                        CodiceRif = CInt(CodiceRifs)

                        Dim lstConsegne As List(Of ConsegnaProgrammata) = Nothing
                        Using mgr As New ConsegneProgrammateDAO
                            lstConsegne = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, CodiceRif))
                        End Using

                        If lstConsegne.Count Then

                            If _IdCorr = 0 Then
                                _IdCorr = lstConsegne(0).IdCorr
                                CaricaConsegne()
                                lblCorrTesto.Visible = True
                                lblCorr.Text = "GLS"
                                lblCorr.Visible = True
                            End If

                            ScaricaColloConsegna(lstConsegne, NumCollo)

                        Else
                            'qui la scatola non è valida 
                            MgrSound.Suona(enTipoSuono.ErroreCodiceInseritoNonValido)
                            MsgSupplement = "Il codice inserito non è valido"
                        End If

                        'ElseIf Ris.Length = 15 Or Ris.Length = 18 Then
                        '    'BARTOLINI
                        '    CodiceRifs = Ris.Substring(8, 7)

                        '    CodiceRif = CInt(CodiceRifs)

                        '    Dim lstConsegne As List(Of ConsegnaProgrammata) = New List(Of ConsegnaProgrammata)
                        '    Using mgr As New ConsegneProgrammateDAO
                        '        Dim C As ConsegnaProgrammata = Nothing
                        '        C = mgr.GetConsDaNumColloBartolini(CodiceRif)
                        '        If Not C Is Nothing Then
                        '            lstConsegne.Add(C)
                        '        End If
                        '    End Using

                        '    If lstConsegne.Count Then

                        '        If _IdCorr = 0 Then
                        '            _IdCorr = lstConsegne(0).IdCorr
                        '            CaricaConsegne()
                        '            lblCorrTesto.Visible = True
                        '            lblCorr.Text = "Bartolini"
                        '            lblCorr.Visible = True
                        '        End If

                        '        NumCollo = CodiceRif - lstConsegne(0).NumeroPrimoColloBartolini
                        '        ScaricaColloConsegna(lstConsegne, NumCollo)

                        '    Else
                        '        'qui la scatola non è valida 
                        '        MgrSound.Suona(enTipoSuono.ErroreCodiceInseritoNonValido)
                        '        MsgSupplement = "Il codice inserito non è valido"
                        '    End If
                    End If
                Else
                    If Ris.Length Then
                        'MessageBox.Show("Codice formalmente non valido")
                        MgrSound.Suona(enTipoSuono.ErroreCodiceInseritoNonValido)
                        MsgSupplement = "Codice inserito non valido"
                    End If

                End If
            End While
        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nel caricamento dei colli: " & ex.Message)
        End Try

    End Sub

    Private Sub ScaricaColloConsegna(lstConsegne As List(Of ConsegnaProgrammata),
                                     NumCollo As Integer)
        Dim ScalatoreColli As Integer = 0
        For Each C As ConsegnaProgrammata In lstConsegne

            Dim SwTrovato As Boolean = False
            Dim Dr As DataGridViewRow = Nothing

            For Each drEsist As DataGridViewRow In DgLavori.Rows
                If drEsist.Cells(0).Value = C.IdCons Then

                    If drEsist.Cells(4).Value = drEsist.Cells(5).Value Then
                        ScalatoreColli += drEsist.Cells(5).Value
                    Else
                        SwTrovato = True
                        Dr = drEsist
                        Exit For
                    End If

                End If
            Next

            NumCollo -= ScalatoreColli

            Dim Esci As Boolean = False

            If SwTrovato = False Then

                MsgSupplement = "Il codice inserito non è utilizzabile per l'uscita da magazzino e non può essere caricato."

            Else
                'qui in dr ho gia la riga interessata
                'controllo che il pacco non sia stato gia sparato

                Dim TrovatoCollo As Integer = DirectCast(Dr.Tag.ToString, String).IndexOf("," & NumCollo & ",")
                If TrovatoCollo = -1 Then
                    'qui non l'ho trovato
                    If NumCollo <= Dr.Cells(5).Value Then
                        Dr.Cells(4).Value = CInt(Dr.Cells(4).Value) + 1
                        Dr.Tag &= NumCollo & ","
                        MsgSupplement = ""
                        'Try
                        DgLavori.Sort(New RowComparer(SortOrder.Descending))
                        Esci = True
                    End If
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
                If C.NumColli <> nCollicaricati Then
                    'IdOrdRif = O.IdOrd
                    'IdConsRif = 0
                    Messaggio = "Devono ancora essere caricati " & C.NumColli - nCollicaricati & " colli"
                Else
                    'IdOrdRif = 0
                    'IdConsRif = 0
                    Messaggio = ""
                    MsgSupplement = ""
                    MgrSound.Suona(enTipoSuono.OkGiroCompletato)

                End If
            End If
            If Esci Then Exit For
        Next

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

    Private Sub ChiudiCorriere()
        If _IdCorr = enCorriere.PortoAssegnatoGLS Or _IdCorr = enCorriere.GLS Or _IdCorr = enCorriere.GLSIsole Then
            'If MessageBox.Show("Confermi la trasmissione delle spedizioni etichettate a " & _Corriere & " e la stampa del borderò?", "Trasmissione Spedizione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'MessageBox.Show("Controlla che nella stampante non ci sia carta per fatture!")
            Cursor.Current = Cursors.WaitCursor
            Dim lstConsegne As List(Of ConsegnaProgrammata) = Nothing

            Dim lstConsegneColliGls As List(Of ConsegnaProgrammata) = New List(Of ConsegnaProgrammata)

            Using mgr As New ConsegneProgrammateDAO
                'TODO: COSI' NON VA BENE: BECCO ANCHE QUELLE PASSATE CON LO STATO ANCORA A "INCONSEGNA"!
                lstConsegne = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.InConsegna),
                                          New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.No),
                                          New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, _IdCorrString, "IN"),
                                          New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, String.Empty, "<>"),
                                          New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.DataTrasmissioneCorriere, Now.Date))
            End Using

            If lstConsegne.Count Then
                Dim Ok As Boolean = True

                For Each C In lstConsegne
                    For i = 1 To C.NumColli
                        lstConsegneColliGls.Add(C)
                    Next
                Next

                Dim ris As String = String.Empty
                Try
                    ris = FormerWebLabeling.MgrWebLabelingGls.TrasmettiSpedizioniGls(lstConsegneColliGls)
                Catch ex As Exception
                    Ok = False
                    ris = ex.Message
                End Try
                MessageBox.Show("Risultato trasmissione spedizioni: " & ris)
                Cursor.Current = Cursors.Default

                If Ok Then
                    Dim Pt As New FormerWebLabeling.My.Templates.DistintaTemplate
                    Pt.Consegne = lstConsegne
                    Dim Path As String = FormerPath.PathTempLocale()
                    'Dim NomeFile As String = FormerHelper.File.GetNomeFileTemp(".pdf")
                    'FormerHelper.PDF.ConvertHTMLToPDF(Pt.TransformText, Path & NomeFile)
                    'Dim StampanteDistintaSpedizione As String = Configuration.ConfigurationManager.AppSettings("StampantePDF")
                    'FormerHelper.PDF.StampaPdf(Path & NomeFile, StampanteDistintaSpedizione, 842, 595)
                    Dim NomeFile As String = FormerHelper.File.GetNomeFileTemp(".html")
                    Using objWriter As New System.IO.StreamWriter(Path & NomeFile)
                        objWriter.Write(Pt.TransformText)
                    End Using
                    'FormerHelper.File.ShellExtended(Path & NomeFile)

                    'STAMPO LA DISTINTA IN MODO DIRETTO SULLA STAMPANTE PREDEFINITA CON ORIENTAMENTO PREDEFINITO?
                    'Dim myWebBrowser As New WebBrowser
                    'AddHandler myWebBrowser.DocumentCompleted, AddressOf DocumentCompleted
                    'myWebBrowser.Navigate(Path & NomeFile)

                    'STAMPO LA DISTINTA PASSANDO PER FORM DI ANTEPRIMA
                    'qui ho il file completato e lo mando alla form di preview
                    Sottofondo()
                    Using x As New frmStampa
                        x.carica(Path & NomeFile)
                    End Using
                    Sottofondo()
                End If
            Else
                MessageBox.Show("Nessuna spedizione da trasmettere!")
            End If
            'End If
            'Else
            '    MessageBox.Show("Al momento la stampa della distinta e la trasmissione automatica delle spedizioni è disponibile solo per GLS!")
        End If
    End Sub

    'Private Sub DocumentCompleted(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
    '    With DirectCast(sender, WebBrowser)
    '        If .ReadyState = WebBrowserReadyState.Complete Then
    '            .Print()
    '        End If
    '    End With
    'End Sub

    Private Class RowComparer
        Implements System.Collections.IComparer

        Private sortOrderModifier As Integer = 1

        Public Sub New(ByVal sortOrder As SortOrder)
            If sortOrder = sortOrder.Descending Then
                sortOrderModifier = -1
            ElseIf sortOrder = sortOrder.Ascending Then

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

    Private Sub btnAnnullaRegistrazioneGLS_Click(sender As Object, e As EventArgs) Handles btnAnnullaRegistrazioneGLS.Click

        If DgLavori.SelectedRows.Count Then

            Dim x As DataGridViewRow = DgLavori.SelectedRows(0)

            'qqui posso sganciare solo consegne in cui ci sono piu consegne con lo stesso codtrack
            Dim IdCons As Integer = x.Cells(0).Value
            Dim CodTrack As String = x.Cells(2).Value

            If MessageBox.Show("Conferma l'annullamento della registrazione GLS per tutte le consegne che condividono il codice track " & CodTrack & "?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Using mgr As New ConsegneProgrammateDAO
                    Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.RegistrataCorriere),
                                                                        New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, CodTrack))

                    If l.Count > 1 Then

                        'qui devo prendere tutte le consegne con questo codtrack e riportarle indietro a imballaggio corriere 
                        'annullare tutto e annullare la chiamata al sito dei loro colli 

                        'sposto tutti gli ordini a imballaggio corriere
                        'resetto la consegna
                        'levo il cod track 
                        'levo la data di comunicazione al corriere
                        'cancello la registrazione al corriere

                        For Each singcons As ConsegnaProgrammata In l

                            For Each O As Ordine In singcons.ListaOrdini

                                Using mgrO As New OrdiniDAO
                                    mgrO.InserisciLog(O, enStatoOrdine.ImballaggioCorriere)
                                End Using

                            Next

                            singcons.IdStatoConsegna = enStatoConsegna.InLavorazione
                            singcons.CodTrack = String.Empty
                            'singcons.Blocco = enSiNo.Si
                            singcons.DataTrasmissioneCorriere = Date.MinValue
                            singcons.LastUpdate = enSiNo.Si
                            singcons.Save()

                        Next

                        MessageBox.Show("ATTENZIONE! Tutti le consegne con CODTRACK " & CodTrack & " sono state riportate a IMBALLAGGIO CORRIERE. Rimuovere tutte le etichette GLS dai pacchi e creare le nuove etichette GLS")

                        'infine qui cancello la spedizione da GLS
                        'se non ci riesco devo avvisare perche senno succede un casino 
                        Try
                            MgrWebLabelingGls.EliminaSpedizione(CodTrack)
                        Catch ex As Exception
                            MessageBox.Show("ATTENZIONE! La cancellazione di questa consegna da GLS non è andata a buon fine! Chiamare ASSOLUTAMENTE DIEGO")
                            FormerHelper.Mail.InviaMail("Errore Cancellazione Automatica Consegna da GLS", "La consegna COD TRACK " & CodTrack & " non è stata cancellata automaticamente da GLS. Va cancellata manualmente", FormerConst.EmailAssistenzaTecnica)
                        End Try

                        Close()

                    Else
                        MessageBox.Show("Questa funzione può essere utilizzata solo per sganciare due o piu consegne che hanno lo stesso CodTrack!")
                    End If

                End Using
            End If

        Else
            MessageBox.Show("Selezionare una consegna dalla lista")
        End If

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


