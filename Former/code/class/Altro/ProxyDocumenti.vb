Friend Class ProxyDocumenti
    Inherits FormerPrinter.ProxyDocumenti

    Shared Sub New()

        'StampanteConsegnaOrdini = PostazioneCorrente.StampanteConsegnaOrdini
        'StampanteLibera = PostazioneCorrente.StampanteLibera
        LoginUtenteConnesso = PostazioneCorrente.UtenteConnesso.Login

    End Sub

End Class

'Friend Class ProxyDocumenti
'    Private _TipoDoc As Integer = 0
'    Private _Pagamento As Integer = 0
'    Private _IdCorriere As Integer = 0
'    'Private _IDcons As Integer = 0

'    Private Function CheckExistPrevFatt(List As List(Of Ordine)) As Boolean
'        Dim ris As Boolean = False

'        Dim lP As List(Of Ordine) = List.FindAll(Function(x) x.Preventivo = enSiNo.Si)

'        Dim lNoP As List(Of Ordine) = List.FindAll(Function(x) x.Preventivo = enSiNo.Si)

'        If lP.Count <> 0 And lNoP.Count <> 0 Then ris = True

'        Return ris
'    End Function

'    Public Function StampaConsegnaOrdini(IdConsegna As Integer)

'        Dim Ris As Integer = 0

'        Dim Cp As New ConsegnaProgrammata
'        Cp.Read(IdConsegna)

'        Dim Prn As New myPrinter
'        Prn.PrinterName = Postazione.StampanteConsegnaOrdini

'        Prn.StampaConsegnaOrdini(Cp)

'        Cp = Nothing

'        Return Ris

'    End Function

'    Public Function CreaDocumenti(IdConsegna As Integer, Optional PortaAvantiStato As Boolean = True, _
'                                  Optional StampaDocumenti As Boolean = True) As Integer

'        'nuovo proxy documenti che parte da una consegna per la stampa
'        Dim Ris As Integer = 0
'        'TORNA 0 se non c'e' bisogno di ritirare documenti
'        '1 se c'e' bisogno di ritirare documenti
'        '2 se c'e' bisogno di saldare
'        'riceve una lista di IdOrdini e crea i relativi documenti accorpandoli per tipo di documento da emettere
'        'prendo le consegne programmate degli ordini che mi arrivano e mi leggo il tipo di pagamento previsto e il tipo di documento previsto

'        'se ci sono due documenti diversi la spesa di spedizione va su preventivo

'        'MODIFICA PER EMISSIONE DOCUMENTO CON DOCUMENTI CORRELATI
'        'qui devo aggiungere alla lista degli ordini in consegna la lista degli ordini associati a questa consegna
'        Dim Cp As New ConsegnaProgrammata
'        Cp.Read(IdConsegna)

'        Dim LRif As List(Of Ordine) = (New OrdiniDAO).FindAll(New LUNA.LunaSearchParameter("IdConsRiferimento", IdConsegna))

'        For Each o As Ordine In LRif

'            Using mgr As New ConsegneProgrammateDAO
'                Dim IdConsVecchia As Integer = o.IdCons
'                mgr.EliminaOrdineDaConsegna(IdConsVecchia, o.IdOrd)

'                mgr.RegistraConsegnaOrdineSuGiorno(o.IdOrd, o.IdCorriere, Now, o.IdRub, enMomentoConsegna.Pomeriggio, o.IdIndirizzo, Cp)

'                mgr.EliminaConsegnaSeVuota(IdConsVecchia)

'            End Using

'            o.IdConsRiferimento = 0
'            o.Save()

'        Next

'        Dim ListaOrdini As New List(Of Ordine)

'        For Each O As ConsProgrOrdini In Cp.ListaOrdiniCP

'            Dim sO As New Ordine
'            sO.Read(O.IdOrd)

'            ListaOrdini.Add(sO)

'        Next

'        'qui ho la lista degli ordini , devo vedere se sistono ordini di tipo diverso 

'        Dim ExistPrevFatt As Boolean = False

'        If Cp.TipoDoc <> enTipoDocumento.enTipoDocPreventivo Then
'            ExistPrevFatt = CheckExistPrevFatt(ListaOrdini)
'        End If

'        Dim Indirizzo As String = String.Empty
'        Dim Citta As String = String.Empty
'        Dim Cap As String = String.Empty

'        If Cp.IdIndirizzo Then
'            Dim I As New Indirizzo
'            I.Read(Cp.IdIndirizzo)
'            Indirizzo = I.Indirizzo
'            Citta = I.Citta
'            Cap = I.Cap
'        Else
'            Indirizzo = Cp.Cliente.Indirizzo
'            Citta = Cp.Cliente.Citta
'            Cap = Cp.Cliente.CAP
'        End If

'        Dim ImportoSpedizioni As Single = 0

'        ImportoSpedizioni = Cp.CalcolaImportoSpedizioni

'        Dim Descrizione As String = ""
'        Dim lD As New List(Of Ricavo)

'        Dim Prom As Promemoria = Nothing

'        For Each O As Ordine In ListaOrdini

'            Descrizione &= " " & O.IdOrd

'            If Cp.TipoDoc <> 0 Then
'                If Ris = 0 Then Ris = 1

'                'qui devo chiamare la funzione di ricerca che me lo cerca e mi da il riferimento
'                'enTipoDocumento

'                If Cp.TipoDoc = enTipoDocumento.enTipoDocPreventivo Then
'                    _TipoDoc = enTipoDocumento.enTipoDocPreventivo
'                    _Pagamento = 1 'TODO: CAMBIARE CON ENUM PAGAMENTO
'                Else
'                    If O.Preventivo Then
'                        _TipoDoc = enTipoDocumento.enTipoDocPreventivo
'                        _Pagamento = 1 'TODO: CAMBIARE CON ENUM PAGAMENTO
'                    Else
'                        _TipoDoc = Cp.TipoDoc
'                        _Pagamento = Cp.IdPagam
'                    End If
'                End If

'                _IdCorriere = Cp.IdCorr

'                If _Pagamento = 1 Then Ris = 2 'questo serve per la messagebox esterna

'                Dim Pagam As New TipoPagamento
'                Pagam.Read(_Pagamento)

'                Dim Ric As Ricavo = lD.Find(AddressOf FindID)

'                If Ric Is Nothing Then
'                    'qui devo creare un nuovo documento
'                    Ric = New Ricavo
'                    Dim IdInserito As Integer = 0
'                    Ric.pRagSoc = Cp.Cliente.RagSoc
'                    Ric.pIndirizzo = Cp.Cliente.Indirizzo
'                    Ric.pCitta = Cp.Cliente.Citta
'                    Ric.pCap = Cp.Cliente.CAP
'                    Ric.pIva = Cp.Cliente.Piva

'                    'Ric.Numero = NumeroDoc '*******************************
'                    Ric.Descrizione = "Documento ordini:"
'                    Ric.Tipo = _TipoDoc
'                    Ric.IdCorr = _IdCorriere
'                    If ExistPrevFatt Then
'                        If _TipoDoc = enTipoDocumento.enTipoDocPreventivo Then
'                            Ric.CostoCorr = ImportoSpedizioni 'qui devo vedere se imputare a questo documento il costo 
'                        End If
'                    Else
'                        Ric.CostoCorr = ImportoSpedizioni 'qui devo vedere se imputare a questo documento il costo 
'                    End If
'                    Ric.DataRicavo = Now.Date
'                    Ric.IdRub = Cp.Cliente.IdRub
'                    If Cp.IdIndirizzo Then
'                        Ric.pIndCons = Indirizzo
'                    End If
'                    Ric.pPagamento = Pagam.TipoPagam
'                    Ric.Idpagamento = _Pagamento
'                    Ric.PercIva = FormerHelper.Finanziarie.GetPercentualeIva

'                    'Ric.Iva = TotaleIva + CostoCorriereIva '*******************************
'                    'Ric.Importo = Totale + CostoCorriere '*******************************
'                    'Ric.Totale = Totale + TotaleIva + CostoCorriere + CostoCorriereIva '*******************************

'                    'Ric.NumColli = txtNumColli.Text '*******************************
'                    'Ric.Peso = txtPeso.Text '*******************************
'                    Ric.Dataprevpagam = Ric.CalcolaDataPrevPagam

'                    'IdInserito = Ric.Save() '*******************************
'                    lD.Add(Ric)
'                End If
'                Ric.ListaIdOrd.Add(O.IdOrd)
'                'qui dentro ric ho sicuramente il documento contabile 

'            Else
'                'qui documento programmato nessuno 
'                If Prom Is Nothing Then
'                    Prom = New Promemoria
'                    Prom.Titolo = Prom.Data.ToString("dd/MM/yyyy hh:mm") & " - PROMEMORIA CONSEGNA MERCE" & vbNewLine & _
'                        "CLIENTE: " & Cp.Cliente.RagSoc & vbNewLine & _
'                    "OPERATORE: " & Postazione.UtenteConnesso.Login
'                End If
'                Prom.Testo &= "ORDINE: " & O.IdOrd & vbNewLine
'            End If

'        Next

'        For Each R As Ricavo In lD
'            Dim lsO As New List(Of Ordine)

'            Dim listaIdOrdStr As String = ""
'            For Each id As Integer In R.ListaIdOrd
'                Dim O As New Ordine
'                O.Read(id)
'                R.Importo += O.TotaleImponibile
'                'R.Iva += O.Iva
'                lsO.Add(O)
'                listaIdOrdStr &= id & ","
'            Next
'            R.Descrizione &= listaIdOrdStr
'            If R.Descrizione.Length > 254 Then R.Descrizione = R.Descrizione.Substring(0, 254)

'            R.Importo += R.CostoCorr

'            If R.Tipo <> enTipoDocumento.enTipoDocPreventivo Then R.Iva = FormerHelper.Finanziarie.CalcolaIva(R.Importo)
'            R.Totale = R.Importo + R.Iva ' + R.CostoCorr
'            R.NumColli = 0 'TODO: SISTEMARE
'            R.Peso = 0 'TODO: SISTEMARE

'            Dim num As New cProgressivi, NumeroDoc As Integer = 0
'            num.Read()
'            Select Case R.Tipo
'                Case enTipoDocumento.enTipoDocDDT
'                    NumeroDoc = num.NextDDT
'                    num.NextDDT += 1
'                Case enTipoDocumento.enTipoDocFattura
'                    NumeroDoc = num.NextFat
'                    num.NextFat += 1
'                Case enTipoDocumento.enTipoDocFatturaRiepilogativa
'                    NumeroDoc = num.NextFat
'                    num.NextFat += 1
'                Case enTipoDocumento.enTipoDocPreventivo
'                    NumeroDoc = num.NextPrev
'                    num.NextPrev += 1
'            End Select

'            If NumeroDoc > 1 Then
'                'qui devo vedere se il numero precedente e' stato effettivamente assegnato altrimenti non lo porto avanti 
'                'se invece il nuovo numero e' valido lo assegno
'                Dim NumeroDocTemp As Integer = NumeroDoc - 1
'                Dim mRic As New RicaviDAO
'                Dim l As List(Of Ricavo) = mRic.FindAll(New LUNA.LunaSearchParameter("Numero", NumeroDocTemp), New LUNA.LunaSearchParameter("Tipo", R.Tipo), New LUNA.LunaSearchParameter("year(DataRicavo)", Now.Year))

'                If l.Count = 0 Then
'                    'qui non c'e' il documento qualcosa non va non aumento il contatore dei documenti e uso quel numero
'                    NumeroDoc = NumeroDocTemp
'                Else
'                    num.Save()
'                End If
'            End If

'            R.Numero = NumeroDoc
'            Dim IdInserito As Integer = R.Save
'            Dim Peso As Integer = 0
'            Dim Colli As Integer = 0

'            For Each ord As Ordine In lsO
'                'qui inserisco le voci in fattura partendo dagli ordini
'                Dim VoceFat As New VoceFattura
'                Dim Prod As New Prodotto
'                Prod.Read(ord.IdProd)

'                VoceFat.IdDoc = IdInserito
'                VoceFat.Codice = Prod.Codice
'                VoceFat.Descrizione = Prod.Descrizione
'                VoceFat.ImportoSing = ord.PrezzoProd / Prod.NumPezzi
'                VoceFat.Importo = ord.TotaleImponibile
'                'VoceFat.Iva = ord.Iva
'                VoceFat.Qta = Prod.NumPezzi * ord.Qta
'                VoceFat.IdOrd = ord.IdOrd
'                VoceFat.Save()

'                Dim OrdDao As New OrdiniDAO
'                Dim MettiAPrev As enSiNo = enSiNo.No
'                If R.Tipo = enTipoDocumento.enTipoDocPreventivo Then
'                    MettiAPrev = enSiNo.Si
'                End If
'                OrdDao.AssociaOrdiniADoc(ord.IdOrd, IdInserito, MettiAPrev)
'                ord.IdDoc = IdInserito

'                If PortaAvantiStato Then
'                    Dim NuovoStato As enStatoOrdine = enStatoOrdine.InConsegna

'                    If R.IdCorr = enCorriere.RitiroCliente Then
'                        NuovoStato = enStatoOrdine.Consegnato
'                    End If
'                    OrdDao.InserisciLog(ord, NuovoStato)
'                End If

'                'qui corriere interno o ritiro cliente
'                Colli += ord.NumeroRealeColli
'                Peso += ord.Prodotto.PesoComplessivo

'            Next

'            'qui ho peso e colli
'            R.Peso = Peso
'            R.NumColli = Colli
'            R.Save()
'        Next

'        If StampaDocumenti Then
'            For Each R As Ricavo In lD

'                ProxyStampa.StampaDocumentoFiscale(R)

'            Next
'        End If


'        If Not Prom Is Nothing Then
'            'stampo il promemoria
'            Dim Prn As New myPrinter ', PrinterName As String
'            Prn.PrinterName = Postazione.StampanteLibera
'            Prn.StampaPromemoria(Prom)
'            Prn = Nothing
'        End If

'        Return Ris
'    End Function

'    Private Function FindID(ByVal R As Ricavo) As Boolean
'        If R.Tipo = _TipoDoc Then
'            If R.IdCorr = _IdCorriere Then
'                If R.Idpagamento = _Pagamento Then
'                    Return True
'                Else
'                    Return False
'                End If
'            Else
'                Return False
'            End If
'        Else
'            Return False
'        End If
'    End Function

'End Class



