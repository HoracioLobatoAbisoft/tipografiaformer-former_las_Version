Imports FormerLib
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerConfig
Imports FormerBusinessLogic

Public Class ProxyDocumenti
    Private Shared _TipoDoc As Integer = 0
    Private Shared _Pagamento As Integer = 0
    Private Shared _IdCorriere As Integer = 0
    'Private _IDcons As Integer = 0

    Public Shared ReadOnly Property StampanteConsegnaOrdini As String
        Get
            Dim Ris As String = "PDFCreator"
            Try
                Dim ConfigPrinter As String = FConfiguration.Printer.ConsegnaOrdini 'ConfigurationManager.AppSettings("StampanteConsegnaOrdini")

                If ConfigPrinter.Length Then
                    Ris = ConfigPrinter
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property StampanteLibera As String
        Get
            Dim Ris As String = "PDFCreator"
            Try
                Dim ConfigPrinter As String = FConfiguration.Printer.Libera ' ConfigurationManager.AppSettings("StampanteLibera")

                If ConfigPrinter.Length Then
                    Ris = ConfigPrinter
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public Shared Property LoginUtenteConnesso As String = String.Empty

    Private Shared Function CheckExistPrevFatt(List As List(Of Ordine)) As Boolean
        Dim ris As Boolean = False

        Dim lP As List(Of Ordine) = List.FindAll(Function(x) x.Preventivo = enSiNo.Si)

        Dim lNoP As List(Of Ordine) = List.FindAll(Function(x) x.Preventivo = enSiNo.No)

        If lP.Count <> 0 And lNoP.Count <> 0 Then ris = True

        Return ris
    End Function

    Public Shared Function StampaConsegnaOrdini(IdConsegna As Integer)

        Dim Ris As Integer = 0

        Dim Cp As New ConsegnaProgrammata
        Cp.Read(IdConsegna)

        Dim Prn As New myFPrinter
        Prn.PrinterName = StampanteConsegnaOrdini

        Prn.StampaConsegnaOrdini(Cp)

        Cp = Nothing

        Return Ris

    End Function

    Public Shared Function CreaDocumenti(IdConsegna As Integer,
                                         PortaAvantiStato As Boolean,
                                         StampaDocumenti As Boolean,
                                         IdUt As Integer) As Integer

        'nuovo proxy documenti che parte da una consegna per la stampa
        Dim Ris As Integer = 0
        'TORNA 0 se non c'e' bisogno di ritirare documenti
        '1 se c'e' bisogno di ritirare documenti
        '2 se c'e' bisogno di saldare
        'riceve una lista di IdOrdini e crea i relativi documenti accorpandoli per tipo di documento da emettere
        'prendo le consegne programmate degli ordini che mi arrivano e mi leggo il tipo di pagamento previsto e il tipo di documento previsto

        'se ci sono due documenti diversi la spesa di spedizione va su preventivo

        'MODIFICA PER EMISSIONE DOCUMENTO CON DOCUMENTI CORRELATI
        'qui devo aggiungere alla lista degli ordini in consegna la lista degli ordini associati a questa consegna

        Dim lD As New List(Of Ricavo)

        Dim Prom As Promemoria = Nothing

        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

            Try
                Using Cp As New ConsegnaProgrammata
                    Cp.Read(IdConsegna)

                    Dim LRif As List(Of Ordine) = Nothing

                    Using mgr As New OrdiniDAO
                        LRif = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdConsRiferimento, IdConsegna))
                    End Using

                    tb.TransactionBegin()

                    For Each o As Ordine In LRif

                        Using mgr As New ConsegneProgrammateDAO
                            'Dim IdConsVecchia As Integer = o.IdCons
                            'TOLTO IL 08/04/2015
                            'mgr.EliminaOrdineDaConsegna(IdConsVecchia, o.IdOrd)

                            mgr.RegistraConsegnaOrdineSuGiorno(o.IdOrd,
                                                           o.IdCorriere,
                                                           Now,
                                                           o.IdRub,
                                                           enMomentoConsegna.Pomeriggio,
                                                           o.IdIndirizzo,
                                                           Cp)

                            'TOLTO IL 08/04/2015
                            'mgr.EliminaConsegnaSeVuota(IdConsVecchia)

                        End Using

                        o.IdConsRiferimento = 0
                        o.Save()

                    Next

                    Dim ListaOrdini As New List(Of Ordine)

                    For Each O As ConsProgrOrdini In Cp.ListaOrdiniCP

                        Dim sO As New Ordine
                        sO.Read(O.IdOrd)
                        sO.IdConsRiferimento = 0
                        sO.Save()

                        ListaOrdini.Add(sO)

                    Next

                    'qui ho la lista degli ordini , devo vedere se esistono ordini di tipo diverso 

                    Dim ExistPrevFatt As Boolean = False

                    'If Cp.TipoDoc <> enTipoDocumento.Preventivo Then
                    ExistPrevFatt = CheckExistPrevFatt(ListaOrdini)
                    'End If

                    Dim Indirizzo As String = String.Empty
                    Dim Citta As String = String.Empty
                    Dim Cap As String = String.Empty
                    Dim Destinatario As String = String.Empty

                    If Cp.IdIndirizzo Then
                        Dim I As New Indirizzo
                        I.Read(Cp.IdIndirizzo)
                        Indirizzo = I.Indirizzo
                        Citta = I.Citta
                        Cap = I.Cap
                        Destinatario = I.Destinatario
                    Else
                        Indirizzo = Cp.Cliente.Indirizzo
                        Citta = Cp.Cliente.Citta
                        Cap = Cp.Cliente.CAP
                    End If

                    Dim ImportoSpedizioni As Decimal = 0

                    If MgrFormerException.CalcolareSpeseDiSpedizioneInFatturazione(Cp) Then
                        ImportoSpedizioni = Cp.CalcolaImportoSpedizioni()
                    Else
                        ImportoSpedizioni = Cp.ImportoNetto
                    End If

                    Dim Descrizione As String = ""

                    For Each O As Ordine In ListaOrdini
                        If O.IdDoc = 0 Then
                            Descrizione &= " " & O.IdOrd

                            If Cp.TipoDoc <> 0 Then
                                If Ris = 0 Then Ris = 1

                                'qui devo chiamare la funzione di ricerca che me lo cerca e mi da il riferimento
                                'enTipoDocumento

                                'If Cp.TipoDoc = enTipoDocumento.Preventivo Then
                                '    _TipoDoc = enTipoDocumento.Preventivo
                                '    _Pagamento = enMetodoPagamento.AllaConsegna
                                'Else
                                If O.Preventivo = enSiNo.Si Then
                                    _TipoDoc = enTipoDocumento.Preventivo
                                    _Pagamento = enMetodoPagamento.ContrassegnoAlRitiro
                                Else
                                    If Cp.TipoDoc <> enTipoDocumento.Preventivo Then
                                        _TipoDoc = Cp.TipoDoc
                                    Else
                                        _TipoDoc = enTipoDocumento.Fattura
                                    End If

                                    If _TipoDoc = enTipoDocumento.DDT Then
                                        _Pagamento = enMetodoPagamento.ContrassegnoAlRitiro
                                    Else
                                        _Pagamento = Cp.IdPagam
                                    End If

                                    '_Pagamento = Cp.IdPagam
                                End If
                                'End If

                                _IdCorriere = Cp.IdCorr

                                If _Pagamento = enMetodoPagamento.ContrassegnoAlRitiro Then Ris = 2 'questo serve per la messagebox esterna

                                Dim Pagam As New TipoPagamento
                                Pagam.Read(_Pagamento)

                                Dim Ric As Ricavo = lD.Find(AddressOf FindID)

                                If Ric Is Nothing Then
                                    'qui devo creare un nuovo documento
                                    Ric = New Ricavo
                                    Dim IdInserito As Integer = 0
                                    Ric.pRagSoc = Cp.Cliente.RagSocNome
                                    Ric.pIndirizzo = Cp.Cliente.Indirizzo
                                    Ric.pCitta = Cp.Cliente.Citta

                                    If Cp.Cliente.Provincia.Trim.Length = 2 Then
                                        Ric.pCitta &= " (" & Cp.Cliente.Provincia.Trim & ")"
                                    End If

                                    Ric.pCap = Cp.Cliente.CAP
                                    Ric.pIva = Cp.Cliente.PivaEx

                                    'Ric.Numero = NumeroDoc '*******************************
                                    Ric.Descrizione = "Documento ordini:"
                                    Ric.Tipo = _TipoDoc
                                    Ric.IdCorr = _IdCorriere
                                    If ExistPrevFatt Then
                                        If _TipoDoc = enTipoDocumento.Preventivo Then
                                            Ric.CostoCorr = ImportoSpedizioni 'qui devo vedere se imputare a questo documento il costo 
                                        End If
                                    Else
                                        Ric.CostoCorr = ImportoSpedizioni 'qui devo vedere se imputare a questo documento il costo 
                                    End If

                                    'TODO:RIMUOVERE IN SEGUITO
                                    'qui devo emettere il documento con la data della consegna se la data è antecedente al 2017

                                    If MgrFormerException.UsareGiornoConsegnaPerGiornoRicavo(Ric, Cp) Then
                                        Ric.DataRicavo = Cp.Giorno
                                    Else
                                        Ric.DataRicavo = Now.Date
                                    End If

                                    Ric.IdRub = Cp.Cliente.IdRub
                                    If Cp.IdIndirizzo Then

                                        If Destinatario.Length AndAlso Destinatario <> Cp.Cliente.RagSocNome Then
                                            Ric.pIndCons = Destinatario & " "
                                        End If

                                        Ric.pIndCons &= Indirizzo & " - " & Citta & " (" & Cap & ")"
                                    End If
                                    If _TipoDoc <> enTipoDocumento.DDT Then Ric.pPagamento = Pagam.TipoPagam
                                    Ric.Idpagamento = _Pagamento
                                    Ric.PercIva = FormerHelper.Finanziarie.GetPercentualeIva
                                    Ric.EsigibilitaIva = Cp.Cliente.EsigibilitaIva

                                    'Ric.Iva = TotaleIva + CostoCorriereIva '*******************************
                                    'Ric.Importo = Totale + CostoCorriere '*******************************
                                    'Ric.Totale = Totale + TotaleIva + CostoCorriere + CostoCorriereIva '*******************************

                                    'Ric.NumColli = txtNumColli.Text '*******************************
                                    'Ric.Peso = txtPeso.Text '*******************************
                                    Ric.Dataprevpagam = Ric.CalcolaDataPrevPagam

                                    'IdInserito = Ric.Save() '*******************************
                                    lD.Add(Ric)
                                End If
                                Ric.ListaIdOrd.Add(O.IdOrd)
                                'qui dentro ric ho sicuramente il documento contabile 

                            Else
                                'qui documento programmato nessuno 
                                If Prom Is Nothing Then
                                    Prom = New Promemoria
                                    Prom.Titolo = Prom.Data.ToString("dd/MM/yyyy hh:mm") & " - PROMEMORIA CONSEGNA MERCE" & vbNewLine &
                                    "CLIENTE: " & Cp.Cliente.RagSocNome & vbNewLine &
                                    "OPERATORE: " & LoginUtenteConnesso
                                End If
                                Prom.Testo &= "ORDINE: " & O.IdOrd & vbNewLine
                            End If
                        End If
                    Next

                    For Each R As Ricavo In lD

                        If R.IdRicavo = 0 Then 'aggiunto inc aso in futuro voglio fargli vedere anche i documenti gia emessi
                            Dim lsO As New List(Of Ordine)

                            Dim listaIdOrdStr As String = ""
                            For Each id As Integer In R.ListaIdOrd
                                Dim O As New Ordine
                                O.Read(id)
                                R.Importo += O.TotaleImponibile
                                'R.Iva += O.Iva
                                lsO.Add(O)
                                listaIdOrdStr &= id & ","
                            Next

                            'QUESTO PER EVITARE L'EMISSIONE DI DOCUMENTI A 0 
                            If R.Importo Then
                                R.Descrizione &= listaIdOrdStr
                                If R.Descrizione.Length > 254 Then R.Descrizione = R.Descrizione.Substring(0, 254)

                                R.Importo += R.CostoCorr

                                If R.Tipo <> enTipoDocumento.Preventivo Then R.Iva = FormerHelper.Finanziarie.CalcolaIva(R.Importo)
                                R.Totale = R.Importo + R.Iva ' + R.CostoCorr

                                'Dim num As New ProgressiviFiscali, NumeroDoc As Integer = 0
                                'num.Read(LUNA.LunaContext.IdNumerazioneDocumenti)
                                'Select Case R.Tipo
                                '    Case enTipoDocumento.enTipoDocDDT
                                '        NumeroDoc = num.NextDDT
                                '        num.NextDDT += 1
                                '    Case enTipoDocumento.enTipoDocFattura
                                '        NumeroDoc = num.NextFat
                                '        num.NextFat += 1
                                '    Case enTipoDocumento.enTipoDocFatturaRiepilogativa
                                '        NumeroDoc = num.NextFat
                                '        num.NextFat += 1
                                '    Case enTipoDocumento.enTipoDocPreventivo
                                '        NumeroDoc = num.NextPrev
                                '        num.NextPrev += 1
                                'End Select

                                'If NumeroDoc > 0 Then
                                '    'qui devo vedere se il numero precedente e' stato effettivamente assegnato altrimenti non lo porto avanti 
                                '    'se invece il nuovo numero e' valido lo assegno
                                '    Dim NumeroDocTemp As Integer = NumeroDoc - 1
                                '    Using mRic As New RicaviDAO
                                '        Dim l As List(Of Ricavo) = mRic.FindAll(New LUNA.LunaSearchParameter("Numero", NumeroDocTemp), _
                                '                                                New LUNA.LunaSearchParameter("Tipo", R.Tipo), _
                                '                                                New LUNA.LunaSearchParameter("year(DataRicavo)", Now.Year))

                                '        If l.Count = 0 Then
                                '            'qui non c'e' il documento qualcosa non va non aumento il contatore dei documenti e uso quel numero
                                '            NumeroDoc = NumeroDocTemp
                                '        Else
                                '            num.Save()
                                '        End If
                                '    End Using
                                'End If

                                Dim AziendaToUse As Integer = 0

                                If Cp.IdAziendaForzata Then
                                    AziendaToUse = Cp.IdAziendaForzata
                                Else
                                    AziendaToUse = MgrAziende.IdAziende.AziendaSrl
                                    'If Cp.HaUnPagamentoAnticipato Then
                                    '    AziendaToUse = FormerConst.Aziende.AziendaSrl
                                    'Else
                                    '    AziendaToUse = FormerConst.Aziende.AziendaSnc
                                    'End If
                                End If

                                R.IdAzienda = AziendaToUse
                                If R.Tipo = enTipoDocumento.Fattura OrElse R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                                    R.StatoFE = enStatoFatturaFE.InCodaInvio
                                End If

                                Dim IdInserito As Integer = R.Save
                                Dim PesoDaOrdini As Integer = 0
                                Dim ColliDaOrdini As Integer = 0

                                For Each ord As Ordine In lsO
                                    'qui inserisco le voci in fattura partendo dagli ordini
                                    Dim VoceFat As New VoceFattura
                                    Dim Prod As New Prodotto
                                    Prod.Read(ord.IdProd)

                                    VoceFat.IdDoc = IdInserito
                                    VoceFat.Codice = Prod.Codice

                                    Dim DescrOrdine As String = Prod.Descrizione ' lo inizializzo comunque alla descrizione del prodotto perche per qualche motivo il nome del lavoro potrebbe cmq saltare anceh se impostato
                                    If ord.UsaNomeLavoroInFattura = enSiNo.Si Then
                                        If ord.NomeLavoro.Length Then
                                            DescrOrdine = ord.NomeLavoro
                                            VoceFat.Custom = enSiNo.Si
                                        End If
                                    End If

                                    VoceFat.Descrizione = DescrOrdine 'Prod.Descrizione
                                    VoceFat.ImportoSing = ord.PrezzoProd / ord.QtaOrdine ' Prod.NumPezzi MODIFICA SPOSTAMENTO QTA
                                    VoceFat.Importo = ord.TotaleImponibile
                                    'VoceFat.Iva = ord.Iva
                                    VoceFat.Qta = ord.QtaOrdine 'Prod.NumPezzi * ord.Qta ' Prod.NumPezzi MODIFICA SPOSTAMENTO QTA
                                    VoceFat.IdOrd = ord.IdOrd
                                    VoceFat.Save()

                                    Using OrdDao As New OrdiniDAO
                                        Dim MettiAPrev As enSiNo = enSiNo.No
                                        If R.Tipo = enTipoDocumento.Preventivo Then
                                            MettiAPrev = enSiNo.Si
                                        End If
                                        OrdDao.AssociaOrdiniADoc(ord.IdOrd, IdInserito, MettiAPrev)
                                        ord.IdDoc = IdInserito

                                        If PortaAvantiStato Then
                                            Dim NuovoStato As enStatoOrdine = enStatoOrdine.InConsegna

                                            If R.IdCorr = enCorriere.RitiroCliente Then
                                                NuovoStato = enStatoOrdine.Consegnato
                                            End If
                                            If ord.Stato <> enStatoOrdine.PagatoInteramente Then OrdDao.InserisciLog(ord, NuovoStato)
                                        End If

                                        'qui corriere interno o ritiro cliente
                                        ColliDaOrdini += ord.NumeroRealeColli
                                        PesoDaOrdini += ord.Prodotto.PesoComplessivo
                                    End Using
                                Next

                                'qui ho peso e colli
                                'se ho un solo documento li prendo dalla consegna 
                                'se ho piu documenti li prendo dagli ordini

                                If lD.Count = 1 Then
                                    R.Peso = Cp.Peso
                                    R.NumColli = Cp.NumColli
                                Else
                                    R.Peso = PesoDaOrdini
                                    R.NumColli = ColliDaOrdini
                                End If

                                If R.Tipo = enTipoDocumento.Preventivo Then
                                    If Cp.Giorno.Year < 2017 Then
                                        R.Numero = MgrDocumentiFiscali.DocumentNumber.GetNextNumberByYear(AziendaToUse, R.Tipo, R.DataRicavo.Year)
                                    Else
                                        R.Numero = MgrDocumentiFiscali.DocumentNumber.GetNextNumber(AziendaToUse, R.Tipo)
                                    End If
                                Else

                                    If R.Tipo = enTipoDocumento.DDT Then
                                        'qui devo vedere se ci sono documenti aperti per questo cliente su vecchia azienda 
                                        'i ddt non sono mai pagati prima quindi puo essere tecnicamente solo la fase iniziale

                                        Using mgrD As New RicaviDAO
                                            Dim lDdt As List(Of Ricavo) = mgrD.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, enTipoDocumento.DDT),
                                                                                   New LUNA.LunaSearchParameter(LFM.Ricavo.IdDocRif, 0),
                                                                                   New LUNA.LunaSearchParameter(LFM.Ricavo.IdRub, R.IdRub))

                                            If lDdt.Count Then
                                                Dim singRic As Ricavo = lDdt(0)
                                                AziendaToUse = singRic.IdAzienda
                                            End If

                                        End Using

                                    End If

                                    R.Numero = MgrDocumentiFiscali.DocumentNumber.GetNextNumber(AziendaToUse, R.Tipo)
                                End If

                                If R.Tipo = enTipoDocumento.Fattura And Cp.HaUnPagamentoAnticipato Then
                                    If R.Totale <> Cp.PagamentoAnticipato.Importo Then
                                        R.Stato = enStatoDocumentoFiscale.PagatoAcconto
                                        Using m As New Messaggio
                                            m.DataIns = Now
                                            m.Titolo = "Incongruenza su importo totale fattura rispetto al pagamento anticipato"
                                            m.Testo = "L'importo della fattura numero " & R.AnnoRiferimento & "-" & R.Numero & " per la consegna " & Cp.IdCons & " è diverso dall'importo del pagamento!"
                                            m.TipoMsg = enTipoMessaggio.Automatico
                                            m.IdMitt = 0
                                            m.IdDest = FormerConst.UtentiSpecifici.IdUtenteLidia
                                            m.Save()
                                        End Using
                                    Else
                                        R.Stato = enStatoDocumentoFiscale.PagatoInteramente
                                    End If
                                End If

                                R.Save()
                            End If
                        End If
                    Next

                    'escludo i documenti non salvati e che quindi evidentemente non hanno un importo
                    lD = lD.FindAll(Function(x) x.IdRicavo <> 0)

                    'qui devo gestire che se ha un pagamento lo devo allegare al documento emesso 
                    If lD.Count Then
                        If Cp.HaUnPagamentoAnticipato AndAlso Cp.PagamentoAnticipato.IdFat = 0 Then
                            'Using R As Ricavo = lD(0) 'prendo il primo e presumilbimente unico documento
                            '    Cp.PagamentoAnticipato.IdFat = R.IdRicavo
                            '    Cp.PagamentoAnticipato.Save()
                            'End Using

                            'qui sicuramente e' un pagamento online e quindi sara' uno solo
                            'registrare il pagamento sul documento
                            Using mgr As New PagamentiDAO
                                Dim l As List(Of Pagamento) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Pagamento.IdConsegna, Cp.IdCons))
                                Using P As Pagamento = l(0) 'prendo il primo e presumilbimente unico pagamento
                                    Using R As Ricavo = lD(0) 'prendo il primo e presumilbimente unico documento
                                        P.IdFat = R.IdRicavo
                                    End Using
                                    P.Save()
                                End Using
                            End Using
                        End If
                    End If

                    If Cp.ImportoNetto <> ImportoSpedizioni Then
                        'MODIFICA AGGIUNTA PER RICALCOLARE LE SPEDIZIONI E AGGIORNARLE ONLINE
                        Cp.ImportoNetto = ImportoSpedizioni
                        Cp.Save()
                    End If

                    tb.TransactionCommit()
                End Using
            Catch ex As Exception
                tb.TransactionRollBack()
                FormerError.MgrError.InviaSegnalazione("Creazione documenti fiscali", ex)
            End Try

        End Using

        If StampaDocumenti Then
            Dim NumCopieDocFiscali As Integer = FormerLib.FormerConst.Fiscali.NumCopieDocFiscali
            For Each R As Ricavo In lD
                Try
                    MgrDocumentiFiscali.MessaggioModuloFattura(R, NumCopieDocFiscali)
                    ProxyStampa.StampaDocumentoFiscale(R, True, NumCopieDocFiscali, IdUt)
                Catch ex As Exception

                End Try
            Next
        End If

        If Not Prom Is Nothing Then
            'stampo il promemoria
            Try
                Dim Prn As New myFPrinter ', PrinterName As String
                Prn.PrinterName = StampanteLibera
                Prn.StampaPromemoria(Prom)
                Prn = Nothing
            Catch ex As Exception

            End Try
        End If

        Return Ris
    End Function

    Private Shared Function FindID(ByVal R As Ricavo) As Boolean
        If R.Tipo = _TipoDoc Then
            If R.IdCorr = _IdCorriere Then
                If R.Idpagamento = _Pagamento Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

End Class



