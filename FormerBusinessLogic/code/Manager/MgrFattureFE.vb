Imports System.Data
Imports System.IO
'Imports System.Web.Mail
Imports System.Text
Imports System.Xml
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports Org.BouncyCastle.Cms
Imports Org.BouncyCastle.X509.Store
Imports System.Xml.Serialization
Imports FormerConfig
Imports FormerLib
Imports System.Net.Mail

Public Class MgrFattureFE

    Public Shared Function SalvaCostoDaFatturaElettronica(ByRef F As FatturaElettronica,
                                                          PathXML As String) As RisSalvaCostoDaFatturaElettronica

        Dim Ris As New RisSalvaCostoDaFatturaElettronica

        Dim BufferF As String = String.Empty

        Using rXml As New StreamReader(PathXML)
            BufferF = rXml.ReadToEnd
        End Using

        Dim TipoDocumento As enTipoDocumento = MgrFattureFE.GetTipoDocumento(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.TipoDocumento)

        If TipoDocumento = enTipoDocumento.Fattura OrElse
        TipoDocumento = enTipoDocumento.NotaDiCredito OrElse
        TipoDocumento = enTipoDocumento.NotaDiDebito OrElse
        TipoDocumento = enTipoDocumento.AccontoAnticipoSuFattura OrElse
        TipoDocumento = enTipoDocumento.AccontoAnticipoSuParcella OrElse
        TipoDocumento = enTipoDocumento.Parcella Then
            'FATTURA
            Dim IdRub As Integer = 0
            Dim IdAziendaCosto As Integer = 0
            'Dim TipoFattura As enTipoDocumento = enTipoDocumento.Fattura
            'Dim NumeroFattura As String = String.Empty
            Dim ListaDDT As List(Of DatiDDT) = Nothing

            If Not F.FatturaElettronicaBody.DatiGenerali.DatiDDT Is Nothing AndAlso F.FatturaElettronicaBody.DatiGenerali.DatiDDT.Count AndAlso TipoDocumento = enTipoDocumento.Fattura Then
                TipoDocumento = enTipoDocumento.FatturaRiepilogativa
                ListaDDT = F.FatturaElettronicaBody.DatiGenerali.DatiDDT
                'Else
                '    TipoDocumento = enTipoDocumento.Fattura
            End If

            Using mgr As New VociRubricaDAO
                Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Piva, F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice),
                                                            New LUNA.LunaSearchParameter(LFM.VoceRubrica.IsFornitore, enSiNo.Si))
                If l.Count Then
                    IdRub = l(0).IdRub
                End If

                Using r As New VoceRubrica
                    If IdRub Then r.Read(IdRub) 'qui in caso aggiorno i dati 
                    r.RagSoc = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione, VbStrConv.ProperCase)
                    r.Nome = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Nome, VbStrConv.ProperCase)
                    r.Cognome = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Cognome, VbStrConv.ProperCase)
                    r.Indirizzo = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.Sede.Indirizzo & " " & F.FatturaElettronicaHeader.CedentePrestatore.Sede.NumeroCivico, VbStrConv.ProperCase)
                    r.CodFisc = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.CodiceFiscale
                    r.Piva = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice
                    If IdRub = 0 Then
                        r.Tipo = enTipoRubrica.Cliente 'enTipoRubrica.Fornitore
                        r.IsFornitore = enSiNo.Si
                    End If

                    If Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti Is Nothing Then
                        r.Tel = IIf(Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Telefono Is Nothing, F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Telefono, "")
                        r.Fax = IIf(Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Fax Is Nothing, F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Fax, "")
                        If r.Email.Length = 0 OrElse r.Email = FormerConst.EmailNonDisponibile Then r.Email = IIf(Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Email Is Nothing, F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Email, "")
                    End If

                    If IdRub = 0 Then
                        r.IdPagamento = enMetodoPagamento.BonificoBancario
                        If Not F.FatturaElettronicaBody.DatiPagamento Is Nothing AndAlso
                          Not F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento Is Nothing AndAlso
                          Not F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento Is Nothing Then
                            r.IdPagamento = MgrFattureFE.GetIdTipoPagamento(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento)

                        End If
                    End If
                    If IdRub = 0 Then r.Pagamento = FormerEnumHelper.TipoPagamentoStr(r.IdPagamento)
                    If IdRub = 0 Then r.TipoDoc = enTipoDocumento.Fattura
                    If IdRub = 0 Then r.DataIns = Now
                    If IdRub = 0 Then r.IdCorriere = enTipoCorriere.ConTariffa

                    If IdRub = 0 Then r.Sorgente = "F"
                    r.PrefissoPiva = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese
                    'r.Provincia
                    'r.IdProvincia
                    'r.IdComune

                    Using MgrC As New ElencoComuniDAO
                        Dim lC As List(Of ComuneInElenco) = Nothing
                        Dim IdNazione As Integer = FormerConst.Culture.IdItalia

                        If F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.Length AndAlso F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.ToUpper <> "IT" Then
                            'qui vado a selezionare o inserire la nuova nazione
                            Using mgrN As New NazioniDAO
                                Dim lN As List(Of Nazione) = mgrN.FindAll(New LUNA.LunaSearchParameter(LFM.Nazione.Code, F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.ToUpper))

                                If lN.Count Then
                                    Using Naz As Nazione = lN(0)
                                        IdNazione = Naz.IdNazione
                                    End Using
                                Else
                                    'qui la devo inserire
                                    Using naz As New Nazione
                                        naz.Code = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.ToUpper
                                        naz.Nazione = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.ToUpper
                                        naz.Save()
                                        IdNazione = naz.IdNazione
                                    End Using
                                End If
                            End Using

                        End If

                        If IdNazione = FormerConst.Culture.IdItalia Then
                            Dim paramProv As LUNA.LunaSearchParameter = Nothing

                            If Not F.FatturaElettronicaHeader.CedentePrestatore.Sede.Provincia Is Nothing Then
                                paramProv = New LUNA.LunaSearchParameter(LFM.ComuneInElenco.Provincia, F.FatturaElettronicaHeader.CedentePrestatore.Sede.Provincia)
                            End If

                            lC = MgrC.FindAll(New LUNA.LunaSearchParameter(LFM.ComuneInElenco.CAP, F.FatturaElettronicaHeader.CedentePrestatore.Sede.CAP),
                                                                                                   New LUNA.LunaSearchParameter(LFM.ComuneInElenco.Comune, F.FatturaElettronicaHeader.CedentePrestatore.Sede.Comune),
                                                                                                   paramProv)
                        Else
                            lC = New List(Of ComuneInElenco)
                        End If

                        If lC.Count = 1 Then
                            Using CinE As ComuneInElenco = lC(0)
                                r.IdComune = CinE.IDCap
                                r.CAP = CinE.CAP
                                r.Citta = CinE.Comune
                                r.Provincia = CinE.Provincia
                                r.IdProvincia = CinE.ProvinciaSel.ID
                                r.IdNazione = FormerConst.Culture.IdItalia
                            End Using
                        Else
                            r.CAP = F.FatturaElettronicaHeader.CedentePrestatore.Sede.CAP
                            r.Citta = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Comune
                            r.Provincia = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Provincia
                            r.IdNazione = IdNazione
                        End If

                    End Using
                    If r.IsChanged Then
                        r.LastUpdate = Now
                        IdRub = r.Save
                    End If

                End Using
            End Using

            If Not F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA Is Nothing Then
                If Trim(F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice) = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSnc) Then
                    IdAziendaCosto = MgrAziende.IdAziende.AziendaSnc
                ElseIf Trim(F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice) = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSrl) Then
                    IdAziendaCosto = MgrAziende.IdAziende.AziendaSrl
                    'Else
                    '    Ris.DaScartare = True
                    '    Ris.NuovoFolder = "INBOX.FE.Scartate"
                End If
            Else
                'qui controllo dentro il codice fiscale per sicurezza
                If Not F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.CodiceFiscale Is Nothing Then
                    If F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.CodiceFiscale = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSnc) Then
                        IdAziendaCosto = MgrAziende.IdAziende.AziendaSnc
                    ElseIf F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.CodiceFiscale = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSrl) Then
                        IdAziendaCosto = MgrAziende.IdAziende.AziendaSrl
                    End If
                End If
            End If

            If IdAziendaCosto = 0 Then
                Ris.DaScartare = True
                Ris.NuovoFolder = "INBOX.FE.Scartate"
            End If

            If Ris.DaScartare = False Then
                'End Using
                If IdRub Then
                    Using r As New VoceRubrica
                        r.Read(IdRub)
                        'qui vado a creare una transaction box
                        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                            Try
                                Using C As New Costo
                                    C.IdRub = IdRub
                                    C.IdAzienda = IdAziendaCosto

                                    Dim DescrizioneDocumento As String = String.Empty

                                    Select Case TipoDocumento
                                        Case enTipoDocumento.AccontoAnticipoSuFattura
                                            DescrizioneDocumento = "FE ACCONTOANTICIPOSUFATTURA - "
                                            TipoDocumento = enTipoDocumento.Fattura
                                        Case enTipoDocumento.AccontoAnticipoSuParcella
                                            DescrizioneDocumento = "FE ACCONTOANTICIPOSUPARCELLA - "
                                            TipoDocumento = enTipoDocumento.Fattura
                                        Case enTipoDocumento.Parcella
                                            DescrizioneDocumento = "FE PARCELLA - "
                                            TipoDocumento = enTipoDocumento.Fattura
                                    End Select

                                    DescrizioneDocumento &= F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Causale

                                    C.Descrizione = DescrizioneDocumento
                                    C.DataCosto = MgrFattureFE.GetDataFromFormatoFE(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Data)
                                    C.Numero = F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero

                                    C.DocXML = BufferF
                                    C.StatoFE = enStatoFatturaFE.AllegatoXMLRicevuto
                                    C.StatoFEInterno = enStatoFEInterno.Inserito
                                    C.DataOraRicezione = Now
                                    C.IdStato = enStatoDocumentoFiscale.RegistratoAutomaticamente
                                    C.Tipo = TipoDocumento

                                    'Dim DatiRiepilogoMain As DatiRiepilogo = F.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo(0)

                                    Dim TotaleNetto As Decimal = 0
                                    Dim TotaleIva As Decimal = 0
                                    Dim AliquotaIva As Integer = -1
                                    Dim MultiIva As Boolean = False

                                    For Each dato As DatiRiepilogo In F.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo

                                        TotaleNetto += MgrFattureFE.GetDecimalFromFormatoFE(dato.ImponibileImporto)
                                        TotaleIva += MgrFattureFE.GetDecimalFromFormatoFE(dato.Imposta)
                                        If MultiIva = False Then
                                            If AliquotaIva = -1 Then
                                                AliquotaIva = MgrFattureFE.GetIvaFromFormatoFE(dato.AliquotaIVA)
                                            Else
                                                If AliquotaIva <> MgrFattureFE.GetIvaFromFormatoFE(dato.AliquotaIVA) Then
                                                    MultiIva = True
                                                End If
                                            End If
                                        End If
                                    Next


                                    Dim ImportoTotaleDocumento As Decimal = 0


                                    If Not F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.ImportoTotaleDocumento Is Nothing Then
                                        ImportoTotaleDocumento = MgrFattureFE.GetDecimalFromFormatoFE(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.ImportoTotaleDocumento)
                                    Else
                                        ImportoTotaleDocumento = TotaleNetto + TotaleIva
                                    End If


                                    If TipoDocumento = enTipoDocumento.NotaDiCredito Then
                                        C.Importo = Math.Abs(TotaleNetto)
                                        C.Iva = Math.Abs(TotaleIva)
                                        C.Totale = Math.Abs(ImportoTotaleDocumento) 'C.Importo + C.Iva)
                                    Else
                                        C.Importo = TotaleNetto
                                        C.Iva = TotaleIva
                                        C.Totale = ImportoTotaleDocumento 'C.Importo + C.Iva)
                                    End If

                                    'C.PercIva = MgrFattureFE.GetIvaFromFormatoFE(DatiRiepilogoMain.AliquotaIVA)
                                    If MultiIva Then
                                        C.PercIva = FormerConst.Fiscali.PercentualeMultiIva
                                    Else
                                        C.PercIva = AliquotaIva
                                    End If
                                    C.IdCat = r.IdCatContab
                                    'c.costocorr
                                    'c.speseincasso
                                    'c.addebitivari

                                    'PRIMA DI SALVARE CONTROLLO CHE IL DOCUMENTO NON SIA STATO GIA LAVORATO
                                    Dim ParamTipoDocumento As String = String.Empty
                                    If TipoDocumento = enTipoDocumento.Fattura OrElse TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
                                        ParamTipoDocumento = "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & ")"
                                    Else
                                        ParamTipoDocumento = "(" & TipoDocumento & ")"
                                    End If

                                    Using mgrC As New CostiDAO
                                        Dim lC As List(Of Costo) = mgrC.FindAll(New LUNA.LunaSearchParameter(LFM.Costo.Numero, C.Numero),
                                                                                New LUNA.LunaSearchParameter(LFM.Costo.IdRub, C.IdRub),
                                                                                New LUNA.LunaSearchParameter(LFM.Costo.IdAzienda, C.IdAzienda),
                                                                                New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, ParamTipoDocumento, "IN"),
                                                                                New LUNA.LunaSearchParameter("YEAR(DataCosto)", C.DataCosto.Year))
                                        If lC.Count = 0 Then
                                            'qui la vado a salvare
                                            Dim IdCosto As Integer = 0

                                            'vado a copiare l'xml nella cartella corretta
                                            Dim PathFinale As String = FormerPath.PathFattureAcquisto & "FE\" & C.AnnoStr & "\" & C.IdAzienda & "\" & FormerLib.FormerHelper.File.EstraiNomeFile(PathXML)
                                            FormerLib.FormerHelper.File.CreateLongPath(PathFinale)

                                            If PathXML.StartsWith(FormerConfig.FormerPath.PathTempLocale) = False Then File.Copy(PathXML, PathFinale, True)
                                            Dim OkPagam As Boolean = True
                                            Dim Pag As Pagamento = Nothing
                                            If Not F.FatturaElettronicaBody.DatiPagamento Is Nothing AndAlso
                                           Not F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento Is Nothing AndAlso
                                           Not F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento Is Nothing Then

                                                Dim DataScadenzaPagamento As Date = MgrFattureFE.GetDataFromFormatoFE(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento)
                                                C.DataPrevPagam = DataScadenzaPagamento
                                            Else
                                                C.DataPrevPagam = C.DataCosto
                                                OkPagam = False
                                            End If

                                            'qui salvo effettivamente il costo
                                            tb.TransactionBegin()
                                            IdCosto = C.Save
                                            Ris.IdCostoSalvato = IdCosto
                                            Ris.NuovoFolder = "INBOX.FE." & C.AnnoStr & ".A." & C.DataCosto.Month

                                            Dim ListaDDTSalvati As New List(Of Costo)
                                            If TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
                                                For Each DDT In ListaDDT
                                                    'vado a salvare i vari ddt
                                                    If ListaDDTSalvati.Find(Function(x) x.Numero = DDT.NumeroDDT) Is Nothing Then
                                                        Using NewDDT As New Costo
                                                            NewDDT.IdRub = IdRub
                                                            NewDDT.IdAzienda = IdAziendaCosto
                                                            NewDDT.Descrizione = "DDT"
                                                            NewDDT.DataCosto = MgrFattureFE.GetDataFromFormatoFE(DDT.DataDDT)
                                                            NewDDT.Numero = DDT.NumeroDDT
                                                            NewDDT.IdStato = enStatoDocumentoFiscale.RegistratoAutomaticamente
                                                            NewDDT.Tipo = enTipoDocumento.DDT
                                                            NewDDT.IdDocRif = C.IdCosto
                                                            NewDDT.DataPrevPagam = NewDDT.DataCosto
                                                            NewDDT.StatoFEInterno = enStatoFEInterno.Inserito
                                                            NewDDT.StatoFE = enStatoFatturaFE.AllegatoXMLRicevuto
                                                            NewDDT.DataOraRicezione = Now
                                                            NewDDT.IdCat = C.IdCat
                                                            NewDDT.Save()
                                                            ListaDDTSalvati.Add(NewDDT)
                                                        End Using
                                                    End If

                                                Next
                                            End If

                                            If Not F.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee Is Nothing Then
                                                For Each Linea In F.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee
                                                    Dim IdCostoLinea As Integer = IdCosto

                                                    If TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
                                                        For Each DDT In ListaDDT
                                                            If Not DDT.RiferimentoNumeroLinea Is Nothing AndAlso DDT.RiferimentoNumeroLinea.FindAll(Function(x) x = Linea.NumeroLinea).Count Then
                                                                IdCostoLinea = ListaDDTSalvati.Find(Function(x) x.Numero = DDT.NumeroDDT).IdCosto
                                                                Exit For
                                                            End If
                                                        Next

                                                        If IdCostoLinea = IdCosto Then
                                                            'qui non e' riuscito a trovare il ddt
                                                            If ListaDDTSalvati.Count = 1 Then
                                                                'se dentro la fattura c'e' un solo ddt e non hanno messo il riferimento li aggancio in automatico all'unico che trovo
                                                                IdCostoLinea = ListaDDTSalvati(0).IdCosto
                                                            End If
                                                        End If

                                                    End If

                                                    Using Voce As New VoceCosto
                                                        Voce.IdCosto = IdCostoLinea
                                                        If Not Linea.CodiceArticolo Is Nothing Then
                                                            Voce.Codice = Linea.CodiceArticolo.CodiceValore
                                                        End If
                                                        Voce.Descrizione = Linea.Descrizione
                                                        If Not Linea.Quantita Is Nothing AndAlso Linea.Quantita.Length > 0 Then
                                                            Voce.Qta = MgrFattureFE.GetDecimalFromFormatoFE(Linea.Quantita)
                                                        Else
                                                            Voce.Qta = 1
                                                        End If
                                                        If Not Linea.UnitaMisura Is Nothing AndAlso Linea.UnitaMisura.Length > 0 Then
                                                            Voce.Um = Linea.UnitaMisura
                                                        End If
                                                        If Not Linea.TipoCessionePrestazione Is Nothing AndAlso Linea.TipoCessionePrestazione.Length > 0 Then
                                                            Voce.TipoCessionePrestazione = Linea.TipoCessionePrestazione
                                                        End If
                                                        If TipoDocumento = enTipoDocumento.NotaDiCredito Then
                                                            Voce.PrezzoUnit = Math.Abs(MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoUnitario))
                                                            Voce.Totale = Math.Abs(MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoTotale))

                                                        Else
                                                            Voce.PrezzoUnit = MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoUnitario)
                                                            Voce.Totale = MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoTotale)

                                                        End If
                                                        Voce.AliquotaIva = MgrFattureFE.GetDecimalFromFormatoFE(Linea.AliquotaIVA)
                                                        Voce.idCat = C.IdCat
                                                        Voce.Save()
                                                    End Using
                                                Next
                                            End If

                                            Dim SalvarePagamento As Boolean = False

                                            'Using R As New VoceRubrica
                                            '    R.Read(IdRub)
                                            If r.RegistraAutomaticamentePagamenti = enSiNo.Si Then
                                                SalvarePagamento = True
                                            Else
                                                'If OkPagam = True AndAlso MgrFattureFE.InserirePagamento(F) Then
                                                If OkPagam = True AndAlso MgrFattureFE.InserirePagamento(F) Then
                                                    SalvarePagamento = True
                                                End If
                                            End If
                                            'End Using

                                            If SalvarePagamento Then
                                                Pag = New Pagamento
                                                Pag.IdRub = C.IdRub
                                                Pag.Tipo = enTipoVoceContab.VoceAcquisto
                                                Pag.IdFat = C.IdCosto

                                                Dim ImportoPagamento As Decimal = 0
                                                Dim IdTipoPagamento As Integer = 0


                                                If Not F.FatturaElettronicaBody.DatiPagamento Is Nothing AndAlso
                                                Not F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento Is Nothing Then

                                                    ImportoPagamento = MgrFattureFE.GetDecimalFromFormatoFE(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ImportoPagamento)
                                                    IdTipoPagamento = MgrFattureFE.GetIdTipoPagamento(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento)
                                                Else
                                                    ImportoPagamento = C.Totale
                                                    IdTipoPagamento = r.IdPagamento

                                                End If

                                                Pag.Importo = ImportoPagamento 'MgrFattureFE.GetDecimalFromFormatoFE(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ImportoPagamento)
                                                Pag.DataPag = C.DataPrevPagam
                                                Pag.IdTipoPagamento = IdTipoPagamento 'MgrFattureFE.GetIdTipoPagamento(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento)
                                                Pag.Descrizione = "REGISTRATO AUTOMATICAMENTE AL RICEVIMENTO FATTURA"
                                                Pag.Save()
                                            End If

                                            tb.TransactionCommit()
                                        Else
                                            Using CRif As Costo = lC(0)
                                                Ris.NuovoFolder = "INBOX.FE." & CRif.AnnoStr & ".A." & CRif.DataCosto.Month
                                            End Using
                                        End If
                                    End Using
                                    Ris.DaSpostare = True

                                End Using
                            Catch ex As Exception

                                tb.TransactionRollBack()
                                Ris.Errore = ex
                            End Try

                        End Using
                    End Using

                End If
            End If

        End If
        Return Ris
    End Function

    Public Shared Function CaricaOnlineFatturaPDF(R As Ricavo) As RisCaricaOnlineFatturaPDF

        Dim Ris As New RisCaricaOnlineFatturaPDF

        'Exit Sub
        Try
            Dim PathFile As String = String.Empty
            PathFile = FormerPath.PathFatture(R.IdAzienda)

            Dim NomeFile = R.AnnoRiferimento & "-" & R.Numero.ToString("0000") & ".pdf"

            PathFile &= NomeFile

            If IO.File.Exists(PathFile) Then

                For Each O As Ordine In R.ListaOrdini
                    If Not O.ConsegnaAssociata Is Nothing Then
                        Ris.IdConsegnaInterna = O.ConsegnaAssociata.IdCons
                        Ris.IdConsegnaOnline = O.ConsegnaAssociata.IdConsOnline
                        Exit For
                    End If
                Next

                If Ris.IdConsegnaInterna <> 0 AndAlso Ris.IdConsegnaOnline <> 0 Then

                    Dim PathRemoto As String = "/tipografiaformer.it/consegne/" & Ris.IdConsegnaOnline & "/" & NomeFile
                    Using Ftp As New FTPclient(FormerConfig.FConfiguration.Ftp.ServerNameProduzione,
                                               FormerConfig.FConfiguration.Ftp.ServerLoginProduzione,
                                               FormerConfig.FConfiguration.Ftp.ServerPwdProduzione)
                        Try
                            Ftp.FtpCreateDirectory("tipografiaformer.it/consegne/" & Ris.IdConsegnaOnline)
                        Catch ex As Exception

                        End Try

                        Try
                            If Ftp.FtpFileExists(PathRemoto) Then
                                Ris.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.FileOnlineGiaPresente
                            End If
                        Catch ex As Exception

                        End Try

                        If Ris.ExitCode <> RisCaricaOnlineFatturaPDF.enExitCode.FileOnlineGiaPresente Then
                            FormerIO.MgrFormerIO.FtpTransfer(Ftp, PathFile, PathRemoto, enTipoOpFTP.Upload)
                        End If

                    End Using
                End If
            Else
                Ris.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.FileLocaleNonPresente
            End If

        Catch ex As Exception
            Ris.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.ErroreNellaFaseDiUpload
        End Try

        Return Ris
    End Function

    Public Shared Function EstraiNumeroFatturaFE(NumeroFattura As String) As Integer
        Dim ris As Integer = 0

        Dim posiz As Integer = NumeroFattura.IndexOf("/")

        If posiz <> -1 Then
            Try
                ris = NumeroFattura.Substring(0, posiz)

            Catch ex As Exception
                ris = -1
            End Try
        End If

        Return ris
    End Function

    Public Shared Function InserirePagamento(F As FatturaElettronica) As Boolean
        Dim ris As Boolean = False
        Try
            If F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento Is Nothing OrElse
                F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento = F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Data Then
                If F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento = "MP01" OrElse
                   F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento = "MP08" Then
                    ris = True
                End If
            End If

        Catch ex As Exception

        End Try

        Return ris
    End Function
    Public Shared Function GetStatoAggiornatoFatturaFE(IdRicavo As Integer) As enStatoFatturaFE

        Dim ris As enStatoFatturaFE

        Using R As New Ricavo
            R.Read(IdRicavo)
            ris = R.StatoFE
        End Using

        Return ris

    End Function

    Public Shared Function GetDataFromFormatoFE(DataInput As String) As Date
        Dim ris As Date
        Dim Anno As String = DataInput.Substring(0, 4)
        Dim Mese As String = DataInput.Substring(5, 2)
        Dim Giorno As String = DataInput.Substring(8, 2)
        ris = New Date(Anno, Mese, Giorno)
        Return ris
    End Function

    Public Shared Function GetIdTipoPagamento(TipoPagamento As String) As Integer
        Dim ris As Integer = 0

        Select Case TipoPagamento
            Case "MP01", "MP04"
                ris = enMetodoPagamento.Contanti
            Case "MP02", "MP03"
                ris = enMetodoPagamento.AssegnoBancario
            Case "MP08"
                ris = enMetodoPagamento.CartaDiCredito
            Case Else
                ris = enMetodoPagamento.BonificoBancario
        End Select

        Return ris
    End Function

    Public Shared Function GetTipoPagamentoDescrizione(SiglaTipoPagamento As String) As String
        Dim ris As String = String.Empty

        Select Case SiglaTipoPagamento
            Case "MP01"
                ris = "Contanti"
            Case "MP02"
                ris = "Assegno"
            Case "MP03"
                ris = "Assegno circolare"
            Case "MP04"
                ris = "Contanti presso Tesoreria"
            Case "MP05"
                ris = "Bonifico"
            Case "MP06"
                ris = "Vaglia cambiario"
            Case "MP07"
                ris = "Bollettino bancario"
            Case "MP08"
                ris = "Carta di pagamento"
            Case "MP09"
                ris = "RID"
            Case "MP10"
                ris = "RID Utenze"
            Case "MP11"
                ris = "RID veloce"
            Case "MP12"
                ris = "RIBA"
            Case "MP13"
                ris = "MAV"
            Case "MP14"
                ris = "Quietanza erario"
            Case "MP15"
                ris = "Giroconto su conti di contabilità speciale"
            Case "MP16"
                ris = "Domiciliazione bancaria"
            Case "MP17"
                ris = "Domiciliazione postale"
            Case "MP18"
                ris = "Bollettino di c/c postale"
            Case "MP19"
                ris = "SEPA Direct Debit"
            Case "MP20"
                ris = "SEPA Direct Debit CORE"
            Case "MP21"
                ris = "SEPA Direct Debit B2B"
            Case "MP22"
                ris = "Trattenuta su somme già riscosse"
            Case "MP23"
                ris = "PagoPA"
        End Select

        Return ris
    End Function

    Public Shared Function GetTipoDocumento(TipoDocumento As String) As enTipoDocumento
        Dim ris As Integer = 0

        Select Case TipoDocumento
            Case "TD01"
                ris = enTipoDocumento.Fattura
            Case "TD02"
                ris = enTipoDocumento.AccontoAnticipoSuFattura
            Case "TD03"
                ris = enTipoDocumento.AccontoAnticipoSuParcella
            Case "TD04"
                ris = enTipoDocumento.NotaDiCredito
            Case "TD05"
                ris = enTipoDocumento.NotaDiDebito
            Case "TD06"
                ris = enTipoDocumento.Parcella
            Case "TD24"
                ris = enTipoDocumento.Fattura
            Case "TD25"
                ris = enTipoDocumento.Fattura
            Case "TD26"
                ris = enTipoDocumento.Fattura
            Case "TD27"
                ris = enTipoDocumento.Fattura

            Case Else
                ris = enTipoDocumento.Altro
        End Select

        Return ris
    End Function

    Public Shared Function GetDecimalFromFormatoFE(ImportoInput As String) As Decimal
        Dim ris As Decimal
        ris = CDec(ImportoInput.Replace(".", ","))
        Return ris
    End Function

    Public Shared Function GetIvaFromFormatoFE(PercInput As String) As Integer
        Dim ris As Integer
        ris = CInt(PercInput.Replace(".", ","))
        Return ris
    End Function

    Public Shared Function GetFatturaFromRicavo(R As Ricavo) As FatturaElettronica
        Dim ris As FatturaElettronica = Nothing
        Dim Buffer As String = String.Empty

        Dim bytes As Byte() = Encoding.Default.GetBytes(R.DocXML)
        Buffer = Encoding.UTF8.GetString(bytes)

        If Buffer.StartsWith("?") Then
            Buffer = Buffer.Substring(1)
        End If

        Dim serializer As New XmlSerializer(GetType(FatturaElettronica))
        Using reader As TextReader = New StringReader(Buffer)
            ris = serializer.Deserialize(reader)
        End Using

        Return ris
    End Function

    Public Shared Function GetFatturaFromXML(PathIn As String) As FatturaElettronica
        Dim ris As FatturaElettronica = Nothing

        Dim serializer As New XmlSerializer(GetType(FatturaElettronica))
        Using reader As StreamReader = New StreamReader(PathIn)
            ris = serializer.Deserialize(reader)
        End Using

        Return ris
    End Function

    Public Shared Function GetFatturaFromXMLBuffer(BufferXML As String) As FatturaElettronica
        Dim ris As FatturaElettronica = Nothing

        Dim serializer As New XmlSerializer(GetType(FatturaElettronica))
        Using reader As TextReader = New StringReader(BufferXML)
            ris = serializer.Deserialize(reader)
        End Using

        Return ris
    End Function

    Public Shared Sub FatturaElettronicaToXML(F As FatturaElettronica,
                                                   PathOut As String)

        Dim serializer As New XmlSerializer(GetType(FatturaElettronica))
        Using reader As StreamWriter = New StreamWriter(PathOut)
            serializer.Serialize(reader, F)
        End Using

    End Sub

    Public Shared Function FatturaRicevutaModificabile(IdCosto As Integer) As Boolean
        Dim ris As Boolean = False
        If IdCosto Then
            Using C As New Costo
                C.Read(IdCosto)
                If C.StatoFE = enStatoFatturaFE.DaInviare Then
                    If C.Tipo = enTipoDocumento.DDT Then
                        If C.IdDocRif Then
                            Using cRif As New Costo
                                cRif.Read(C.IdDocRif)
                                If cRif.StatoFE = enStatoFatturaFE.DaInviare Then
                                    ris = True
                                End If
                            End Using
                        Else
                            ris = True
                        End If
                    Else
                        ris = True
                    End If
                End If
            End Using
        End If
        Return ris
    End Function

    Public Shared Function FatturaEmessaModificabile(IdRicavo As Integer) As Boolean
        Dim ris As Boolean = False
        If IdRicavo Then
            Using R As New Ricavo
                R.Read(IdRicavo)
                If R.ListaPagamenti.Count = 0 Then

                    If R.Tipo = enTipoDocumento.Fattura OrElse
                        R.Tipo = enTipoDocumento.FatturaRiepilogativa OrElse
                        R.Tipo = enTipoDocumento.NotaDiCredito Then
                        If R.StatoFE = enStatoFatturaFE.DaInviare OrElse R.StatoFE = enStatoFatturaFE.ScartataSDI Then
                            ris = True
                        End If
                    ElseIf R.Tipo = enTipoDocumento.DDT Then
                        If R.IdDocRif = 0 Then
                            ris = True
                        End If
                    Else
                        ris = True
                    End If
                End If


            End Using
        Else
            ris = True
        End If
        Return ris
    End Function

    Public Shared Function GetIdRicavoFromNomeFile(NomeFile As String,
                                                   IdAzienda As Integer) As Integer
        Dim ris As Integer = 0
        Try
            Dim Posiz As Integer = NomeFile.IndexOf("_")
            Dim Numero As String = NomeFile.Substring(Posiz + 1, 5)

            Dim LetteraAnno As String = Numero.Substring(0, 1)
            Numero = Numero.Substring(1)
            Dim Anno As Integer = MgrFattureFE.GetAnnoFromLettera(LetteraAnno)

            Using mgr As New RicaviDAO
                Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.Numero, Numero),
                                                       New LUNA.LunaSearchParameter(LFM.Ricavo.IdAzienda, IdAzienda),
                                                       New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.NotaDiCredito & ")", "IN"),
                                                       New LUNA.LunaSearchParameter("YEAR(DataRicavo)", Anno))
                If l.Count = 1 Then
                    ris = l(0).IdRicavo
                End If
            End Using
        Catch ex As Exception

        End Try

        Return ris
    End Function

    Public Shared Function GetIdRicavoFromOggetto(Oggetto As String) As Integer
        Dim ris As Integer = 0
        Try
            Dim posiz As Integer = Oggetto.LastIndexOf(" ")
            ris = Oggetto.Substring(posiz + 1)
        Catch ex As Exception

        End Try

        Return ris
    End Function

    Public Shared Function GetLetteraFromAnno(Anno As Integer) As String
        Dim ris As String = String.Empty
        'CODIFICA 1 LETTERA PER ANNO + 4 caratteri per numero 
        'LA A corrisponde a 65
        Dim AnnoStart As Integer = 2019
        Dim Fisso As Integer = Asc("A")
        Dim DiffAnno As Integer = Anno - AnnoStart

        ris = Chr(Fisso + DiffAnno)

        Do While Char.IsLetterOrDigit(ris) = False
            DiffAnno += 1
            ris = Chr(Fisso + DiffAnno)
        Loop

        Return ris
    End Function

    Public Shared Function GetAnnoFromLettera(Lettera As String) As Integer

        Dim ris As Integer = 0
        Dim AnnoStart As Integer = 2019
        'CODIFICA 1 LETTERA PER ANNO + 4 caratteri per numero 
        'LA A corrisponde a 65
        Dim ValoreLettera As Integer = Asc(Lettera)
        Dim ValoreStart As Integer = Asc("A")
        Dim Differenza As Integer = ValoreLettera - ValoreStart

        ris = AnnoStart + Differenza

        Return ris
    End Function

    Public Shared Function GetProgressivo(R As Ricavo) As String
        Dim ris As String = String.Empty

        'ris = Conversion.Hex(R.Numero)

        Dim Prefisso As String = String.Empty

        Prefisso = GetLetteraFromAnno(R.DataRicavo.Year)

        ris = Prefisso & FormerLib.FormerHelper.Stringhe.FormattaConZeri(R.Numero, 4)

        Return ris
    End Function

    Public Shared Function InviaFatturaPEC(R As Ricavo,
                                           ListaAllegati As List(Of String)) As Integer

        Dim Ris As Integer = 0

        Dim Dest As String = MgrAziende.GetPECSDI(R.IdAzienda) '"sdi01@pec.fatturapa.it"
        Dim FromAddr As String = MgrAziende.GetPEC(R.IdAzienda)
        Dim FromName As String = MgrAziende.GetRagioneSociale(R.IdAzienda)
        Dim FromPwd As String = MgrAziende.GetPECPassword(R.IdAzienda)

        'Try


        '    Dim sslMail As New System.Web.Mail.MailMessage()

        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", FormerLib.FormerHelper.Mail.SMTPServerPEC)
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465")
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2") 'Send the message using the network (SMTP over the network)
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1") 'YES
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", FromAddr)
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", FromPwd)
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true")
        '    sslMail.From = FromAddr
        '    sslMail.To = Dest
        '    sslMail.Subject = "Invio File " & R.IdRicavo
        '    sslMail.BodyFormat = MailFormat.Text
        '    sslMail.Body = "Invio File XML " & R.IdRicavo

        '    If Not ListaAllegati Is Nothing Then

        '        For Each Allegato As String In ListaAllegati
        '            If System.IO.File.Exists(Allegato) Then
        '                sslMail.Attachments.Add(New MailAttachment(Allegato))
        '            End If
        '        Next

        '    End If

        '    System.Web.Mail.SmtpMail.SmtpServer = FormerLib.FormerHelper.Mail.SMTPServerPEC & ":465"
        '    System.Web.Mail.SmtpMail.Send(sslMail)

        'Catch ex As Exception
        '    Ris = 1
        'End Try

        Try

            Using msg As New MailMessage()
                msg.Subject = "Invio File " & R.IdRicavo
                'msg.IsBodyHtml = True
                msg.Body = "Invio File XML " & R.IdRicavo
                msg.To.Add(Dest)

                msg.From = New MailAddress(FromAddr, FromName)

                If Not ListaAllegati Is Nothing Then

                    For Each Allegato As String In ListaAllegati
                        If System.IO.File.Exists(Allegato) Then
                            Dim a As New Net.Mail.Attachment(Allegato)
                            a.ContentId = FormerHelper.File.EstraiNomeFile(Allegato)
                            msg.Attachments.Add(a)
                        End If
                    Next

                End If

                Using sm As New SmtpClient(FormerLib.FormerHelper.Mail.SMTPServerPEC)
                    Dim c As New System.Net.NetworkCredential(FromAddr, FromPwd)
                    sm.Port = 587
                    sm.UseDefaultCredentials = False
                    sm.EnableSsl = True
                    sm.Credentials = c
                    sm.DeliveryMethod = SmtpDeliveryMethod.Network

                    sm.Send(msg)

                End Using
            End Using

        Catch ex As Exception
            If ex.Message.IndexOf("policy violation") <> -1 Then
                'qui devo loggare in qualche modo la violazione di policy 
                Try
                    My.Application.Log.WriteException(ex, TraceEventType.Error, "Policy Violation")
                Catch exPolicy As Exception

                End Try
            End If
            Ris = 1
        End Try
        Return Ris

    End Function

    Public Shared Function GetEsigibilitaIVAFormatoFE(EsigibilitaIva As enEsigibilitaIVA) As String
        Dim ris As String = String.Empty

        Select Case EsigibilitaIva
            Case enEsigibilitaIVA.Immediata
                ris = "I"
            Case enEsigibilitaIVA.Differita
                ris = "D"
            Case enEsigibilitaIVA.SplitPayment
                ris = "S"
        End Select

        Return ris
    End Function

    Public Shared Function GetCosto(ByVal FilePath As String) As Costo

        Dim Buffer As String = String.Empty

        Using r As New StreamReader(FilePath)

            Buffer = r.ReadToEnd

        End Using

    End Function

    Public Shared Function RicavoToXML(R As Ricavo,
                                       PathOut As String,
                                       Optional OutputSigned As Boolean = False) As String

        Dim ris As String = String.Empty

        Try
            Dim IsRiepilogativa As Boolean = False

            If R.Tipo = enTipoDocumento.FatturaRiepilogativa Then IsRiepilogativa = True
            Using ms As New MemoryStream()
                Using w As New XmlTextWriter(ms, UTF8Encoding.UTF8)
                    With w
                        .Formatting = Formatting.Indented
                        .Indentation = 2

                        .WriteStartDocument()

                        .WriteStartElement("p:FatturaElettronica")
                        .WriteAttributeString("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#")
                        .WriteAttributeString("xmlns:p", "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")
                        '.WriteAttributeString("versione", R.FAPAFormatoTrasmissioneVersoPrivati)
                        If R.EsigibilitaIva = enEsigibilitaIVA.SplitPayment Then
                            .WriteAttributeString("versione", R.FAPAFormatoTrasmissioneVersoPA)
                        Else
                            .WriteAttributeString("versione", R.FAPAFormatoTrasmissioneVersoPrivati)
                        End If

                        .WriteStartElement("FatturaElettronicaHeader")
                        .WriteStartElement("DatiTrasmissione")

                        .WriteStartElement("IdTrasmittente")
                        .WriteElementString("IdPaese", "IT")
                        .WriteElementString("IdCodice", MgrAziende.GetPartitaIva(R.IdAzienda)) '"01879020517") '
                        .WriteEndElement() 'IdTrasmittente

                        .WriteElementString("ProgressivoInvio", GetProgressivo(R)) 'R.Numero)
                        If R.EsigibilitaIva = enEsigibilitaIVA.SplitPayment Then
                            .WriteElementString("FormatoTrasmissione", R.FAPAFormatoTrasmissioneVersoPA)
                        Else
                            .WriteElementString("FormatoTrasmissione", R.FAPAFormatoTrasmissioneVersoPrivati)
                        End If
                        '

                        If R.VoceRubrica.IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
                            If R.VoceRubrica.CodiceSDI.Length Then
                                .WriteElementString("CodiceDestinatario", R.VoceRubrica.CodiceSDI.ToUpper)
                            Else
                                .WriteElementString("CodiceDestinatario", "0000000")
                                If R.VoceRubrica.Pec.Length Then .WriteElementString("PECDestinatario", R.VoceRubrica.Pec)
                            End If
                        Else
                            .WriteElementString("CodiceDestinatario", "0000000")
                            If R.VoceRubrica.Pec.Length Then .WriteElementString("PECDestinatario", R.VoceRubrica.Pec)
                        End If

                        .WriteEndElement() 'DatiTrasmissione

                        .WriteStartElement("CedentePrestatore")

                        .WriteStartElement("DatiAnagrafici")
                        .WriteStartElement("IdFiscaleIVA")
                        .WriteElementString("IdPaese", "IT")
                        .WriteElementString("IdCodice", MgrAziende.GetPartitaIva(R.IdAzienda))
                        .WriteEndElement() 'IdFiscaleIVA
                        .WriteElementString("CodiceFiscale", MgrAziende.GetPartitaIva(R.IdAzienda))

                        .WriteStartElement("Anagrafica")
                        .WriteElementString("Denominazione", MgrAziende.GetRagioneSociale(R.IdAzienda))
                        .WriteEndElement() 'Anagrafica
                        .WriteElementString("RegimeFiscale", "RF01")
                        .WriteEndElement() 'DatiAnagrafici

                        .WriteStartElement("Sede")
                        .WriteElementString("Indirizzo", MgrAziende.GetIndirizzo(R.IdAzienda))
                        .WriteElementString("CAP", MgrAziende.GetCAP(R.IdAzienda))
                        .WriteElementString("Comune", "Roma")
                        .WriteElementString("Provincia", "RM")
                        .WriteElementString("Nazione", "IT")
                        .WriteEndElement() 'Sede

                        .WriteStartElement("IscrizioneREA")
                        .WriteElementString("Ufficio", "RM")
                        .WriteElementString("NumeroREA", MgrAziende.GetREA(R.IdAzienda))
                        .WriteElementString("StatoLiquidazione", "LN")
                        .WriteEndElement() 'Sede

                        .WriteStartElement("Contatti")
                        .WriteElementString("Telefono", "0630884518")
                        .WriteElementString("Email", "info@tipografiaformer.it")
                        .WriteEndElement() 'Sede

                        .WriteEndElement() 'CedentePrestatore

                        '***************************************
                        '******* CESSIONARIO COMMITTENTE *******
                        '***************************************

                        Dim PrefissoPIva As String = String.Empty
                        Dim Piva As String = String.Empty
                        Dim CodFiscale As String = String.Empty
                        Dim RagSociale As String = String.Empty
                        Dim Nome As String = String.Empty
                        Dim Cognome As String = String.Empty
                        Dim SedeIndirizzo As String = String.Empty
                        Dim SedeCap As String = String.Empty
                        Dim SedeComune As String = String.Empty
                        Dim SedeProvincia As String = String.Empty
                        Dim SedeNazione As String = String.Empty

                        If R.Tipo = enTipoDocumento.NotaDiCredito Then

                            Using RicavoRif As Ricavo = R.RicavoRiferimentoNotadiCredito

                                Dim FatturaVecchia As FatturaElettronica = MgrFattureFE.GetFatturaFromRicavo(RicavoRif)

                                PrefissoPIva = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese
                                If PrefissoPIva Is Nothing Then PrefissoPIva = String.Empty
                                Piva = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice
                                If Piva Is Nothing Then Piva = String.Empty
                                CodFiscale = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.CodiceFiscale
                                If CodFiscale Is Nothing Then CodFiscale = String.Empty
                                RagSociale = RicavoRif.VoceRubrica.RagSoc 'FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.Anagrafica.Denominazione
                                If RagSociale Is Nothing Then RagSociale = String.Empty
                                Nome = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.Anagrafica.Nome
                                If Nome Is Nothing Then Nome = String.Empty
                                Cognome = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.Anagrafica.Cognome
                                If Cognome Is Nothing Then Cognome = String.Empty
                                SedeIndirizzo = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.Indirizzo
                                If SedeIndirizzo Is Nothing Then SedeIndirizzo = String.Empty
                                SedeCap = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.CAP
                                If SedeCap Is Nothing Then SedeCap = String.Empty
                                SedeComune = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.Comune
                                If SedeComune Is Nothing Then SedeComune = String.Empty
                                SedeProvincia = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.Provincia
                                If SedeProvincia Is Nothing Then SedeProvincia = String.Empty
                                SedeNazione = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.Nazione
                                If SedeNazione Is Nothing Then SedeNazione = String.Empty
                            End Using

                        Else
                            PrefissoPIva = R.VoceRubrica.PrefissoPiva
                            Piva = R.VoceRubrica.Piva
                            CodFiscale = R.VoceRubrica.CodFisc.ToUpper
                            RagSociale = R.VoceRubrica.RagSoc
                            Nome = R.VoceRubrica.Nome
                            Cognome = R.VoceRubrica.Cognome
                            SedeIndirizzo = R.VoceRubrica.Indirizzo
                            If R.VoceRubrica.IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
                                SedeCap = R.VoceRubrica.CAP
                                SedeComune = R.VoceRubrica.Localita.Comune
                                SedeProvincia = R.VoceRubrica.Localita.Provincia
                                SedeNazione = "IT"
                            Else
                                SedeCap = FormerLib.FormerConst.Culture.CapEstero
                                SedeComune = R.VoceRubrica.Citta
                                SedeNazione = R.VoceRubrica.Nazione.Code
                            End If

                        End If

                        .WriteStartElement("CessionarioCommittente")

                        .WriteStartElement("DatiAnagrafici")

                        If Piva.Length Then 'R.VoceRubrica.Piva.Length Then
                            .WriteStartElement("IdFiscaleIVA")
                            .WriteElementString("IdPaese", PrefissoPIva) 'R.VoceRubrica.PrefissoPiva)
                            .WriteElementString("IdCodice", Piva) 'R.VoceRubrica.Piva)
                            .WriteEndElement() 'IdFiscaleIVA
                        Else
                            If R.VoceRubrica.IdNazione <> FormerLib.FormerConst.Culture.IdItalia Then
                                .WriteStartElement("IdFiscaleIVA")
                                .WriteElementString("IdPaese", PrefissoPIva) 'R.VoceRubrica.PrefissoPiva)
                                .WriteElementString("IdCodice", CodFiscale) ' MODIFICATO IN BASE A SPECIFICHE FATTURA ELETTRONICA
                                'CHE PREVEDE CODFISCALE UGUALE A PIVA IN CASO DI CLIENTE ESTERO
                                'SOSTITUITI TUTTI I ZERO
                                ' "00000000000") 'R.VoceRubrica.Piva)
                                .WriteEndElement() 'IdFiscaleIVA
                            End If
                        End If

                        If Piva.Length = 0 AndAlso CodFiscale.Length Then 'R.VoceRubrica.Piva.Length = 0 AndAlso R.VoceRubrica.CodFisc.Length Then
                            .WriteElementString("CodiceFiscale", CodFiscale)
                        ElseIf Piva.Length <> 0 AndAlso CodFiscale.Length <> 0 AndAlso Piva <> CodFiscale Then
                            .WriteElementString("CodiceFiscale", CodFiscale)
                        End If

                        .WriteStartElement("Anagrafica")
                        If RagSociale.Length Then 'R.VoceRubrica.RagSoc.Length Then
                            RagSociale = RagSociale.Replace("'", "&apos;")
                            .WriteElementString("Denominazione", RagSociale) 'R.VoceRubrica.RagSoc)
                        Else
                            .WriteElementString("Nome", Nome) 'R.VoceRubrica.Nome)
                            .WriteElementString("Cognome", Cognome) 'R.VoceRubrica.Cognome)
                        End If

                        .WriteEndElement() 'Anagrafica
                        .WriteEndElement() 'DatiAnagrafici

                        .WriteStartElement("Sede")
                        .WriteElementString("Indirizzo", SedeIndirizzo) ', R.VoceRubrica.Indirizzo)
                        .WriteElementString("CAP", SedeCap) 'R.VoceRubrica.CAP)
                        .WriteElementString("Comune", SedeComune)
                        If SedeProvincia.Length Then .WriteElementString("Provincia", SedeProvincia)
                        .WriteElementString("Nazione", SedeNazione)

                        'If R.VoceRubrica.IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
                        '    .WriteElementString("CAP", R.VoceRubrica.CAP)
                        'Else
                        '    .WriteElementString("CAP", FormerLib.FormerConst.Culture.CapEstero)
                        'End If

                        'If R.VoceRubrica.IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
                        '    .WriteElementString("Comune", R.VoceRubrica.Localita.Comune)
                        '    .WriteElementString("Provincia", R.VoceRubrica.Localita.Provincia)
                        '    .WriteElementString("Nazione", "IT")
                        'Else
                        '    .WriteElementString("Comune", R.VoceRubrica.Citta)
                        '    .WriteElementString("Nazione", R.VoceRubrica.Nazione.Code)
                        'End If

                        .WriteEndElement() 'Sede

                        .WriteEndElement() 'CessionarioCommittente

                        .WriteEndElement() 'FATTURAELETTRONICAHEADER

                        .WriteStartElement("FatturaElettronicaBody")

                        .WriteStartElement("DatiGenerali")
                        .WriteStartElement("DatiGeneraliDocumento")

                        .WriteElementString("TipoDocumento", R.FAPATipoDocumento)
                        .WriteElementString("Divisa", "EUR")
                        .WriteElementString("Data", R.FAPADataRicavoStr)
                        .WriteElementString("Numero", R.Numero & "/" & R.DataRicavo.Year) ' R.Numero)
                        .WriteElementString("ImportoTotaleDocumento", R.FAPATotaleDocumento)

                        .WriteEndElement() 'DatiGeneraliDocumento

                        If R.Tipo = enTipoDocumento.NotaDiCredito Then
                            'qui se nota di credito vado a mettere il documento di riferimento
                            'Using RRif As New Ricavo
                            '    RRif.Read(R.IdFatturaNotaDiCredito)
                            .WriteStartElement("DatiFattureCollegate")
                            .WriteElementString("IdDocumento", R.RicavoRiferimentoNotadiCredito.Numero & "/" & R.RicavoRiferimentoNotadiCredito.DataRicavo.Year)
                            .WriteElementString("Data", R.RicavoRiferimentoNotadiCredito.FAPADataRicavoStr)
                            .WriteEndElement() 'DatiFattureCollegate
                            'End Using
                        End If

                        Dim ContatoreLinee As Integer = 1
                        If R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                            '*************************qui devo elencare i ddt 

                            For Each d In R.ListaDDT
                                .WriteStartElement("DatiDDT")
                                .WriteElementString("NumeroDDT", d.Numero)
                                .WriteElementString("DataDDT", d.DataRicavo.ToString("yyyy-MM-dd"))

                                For Each v In d.ListaRigheFat
                                    .WriteElementString("RiferimentoNumeroLinea", ContatoreLinee)
                                    ContatoreLinee += 1
                                Next
                                'qui ci vanno le spedizioni
                                If d.CostoCorr Then
                                    .WriteElementString("RiferimentoNumeroLinea", ContatoreLinee)
                                    ContatoreLinee += 1
                                End If

                                .WriteEndElement() 'DatiDDT
                            Next

                        End If

                        If R.Tipo = enTipoDocumento.Fattura Then
                            .WriteStartElement("DatiTrasporto")

                            If R.ConsegnaRif.IdCorr = enCorriere.GLS OrElse R.ConsegnaRif.IdCorr = enCorriere.GLSIsole Then
                                .WriteStartElement("DatiAnagraficiVettore")

                                .WriteStartElement("IdFiscaleIVA")
                                .WriteElementString("IdPaese", "IT")
                                .WriteElementString("IdCodice", "04102770965")
                                .WriteEndElement() 'IdFiscaleIVA

                                .WriteStartElement("Anagrafica")
                                .WriteElementString("Denominazione", "GLS Enterprise")
                                .WriteEndElement() 'Anagrafica

                                .WriteEndElement() 'DatiAnagraficiVettore
                                .WriteElementString("MezzoTrasporto", "Vettore GLS Enterprise")
                            End If

                            .WriteElementString("CausaleTrasporto", R.FAPACausaleTrasporto)
                            Dim NumColli As Integer = R.NumColli
                            If NumColli = 0 Then NumColli = 1
                            .WriteElementString("NumeroColli", NumColli)
                            .WriteElementString("UnitaMisuraPeso", "Kg")
                            .WriteElementString("PesoLordo", R.FAPAPesoLordo)

                            If R.ConsegnaRif.IdIndirizzo Then
                                .WriteStartElement("IndirizzoResa")

                                .WriteElementString("Indirizzo", MgrAziende.GetIndirizzo(R.IdAzienda))
                                .WriteElementString("CAP", MgrAziende.GetCAP(R.IdAzienda))
                                .WriteElementString("Comune", "Roma")
                                .WriteElementString("Provincia", "RM")
                                .WriteElementString("Nazione", "IT")

                                'COMMENTATO PER ERRATO INDIRIZZO RESA ORA E' SEMPRE TIPOGRAFIA FORMER
                                '.WriteElementString("Indirizzo", R.ConsegnaRif.IndirizzoRif.Indirizzo)
                                'If R.ConsegnaRif.IndirizzoRif.IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
                                '    .WriteElementString("CAP", R.ConsegnaRif.IndirizzoRif.Cap)
                                'Else
                                '    .WriteElementString("CAP", FormerLib.FormerConst.Culture.CapEstero)
                                'End If

                                '.WriteElementString("Comune", R.ConsegnaRif.IndirizzoRif.Comune)
                                'If R.ConsegnaRif.IndirizzoRif.IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
                                '    .WriteElementString("Provincia", R.ConsegnaRif.IndirizzoRif.Provincia)
                                '    .WriteElementString("Nazione", "IT")
                                'Else

                                '    .WriteElementString("Nazione", R.ConsegnaRif.IndirizzoRif.Nazione.Code)
                                'End If

                                .WriteEndElement() 'IndirizzoResa
                            End If

                            .WriteEndElement() 'DatiTrasporto
                        End If

                        .WriteEndElement() 'DatiGenerali

                        .WriteStartElement("DatiBeniServizi")

                        Dim ContatoreInterno As Integer = 1
                        If IsRiepilogativa Then
                            'qui ciclo nei ddt
                            For Each ddt In R.ListaDDT
                                For Each rigaddt In ddt.ListaRigheFat
                                    'qui scrivo le varie linee della fattura
                                    .WriteStartElement("DettaglioLinee")

                                    .WriteElementString("NumeroLinea", ContatoreInterno)

                                    Dim Codice As String = rigaddt.Codice
                                    If Codice.Length > 10 Then
                                        Codice = Codice.Substring(0, 10)
                                    End If

                                    .WriteStartElement("CodiceArticolo")
                                    .WriteElementString("CodiceTipo", "Interno")
                                    .WriteElementString("CodiceValore", Codice)
                                    .WriteEndElement() 'CodiceArticolo

                                    Dim DescrRiga As String = rigaddt.Descrizione

                                    If rigaddt.Custom = enSiNo.No Then
                                        DescrRiga = FormerLib.FormerHelper.Finanziarie.PulisciRigaFattura(DescrRiga)
                                    End If

                                    DescrRiga = rigaddt.Qta.ToString & " " & DescrRiga

                                    DescrRiga = FormerLib.FormerHelper.Finanziarie.PulisciRigaFatturaFE(DescrRiga)

                                    .WriteElementString("Descrizione", DescrRiga)
                                    '.WriteElementString("Quantita", Dr("Qta").ToString & ".00")
                                    '.WriteElementString("UnitaMisura", "Pz")
                                    .WriteElementString("Quantita", "1.00")
                                    .WriteElementString("PrezzoUnitario", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(rigaddt.Importo))
                                    .WriteElementString("PrezzoTotale", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(rigaddt.Importo))
                                    .WriteElementString("AliquotaIVA", R.PercIva & ".00")
                                    If R.PercIva = 0 Then
                                        .WriteElementString("Natura", R.NaturaEsclIva)
                                    End If

                                    .WriteEndElement() 'DettaglioLinee
                                    ContatoreInterno += 1
                                Next

                                If ddt.CostoCorr Then
                                    .WriteStartElement("DettaglioLinee")

                                    .WriteElementString("NumeroLinea", ContatoreInterno)

                                    Dim TestoDaStampare As String = "Consegna"

                                    Using C As New Corriere
                                        C.Read(ddt.IdCorr)

                                        If C.TipoCorriere = enTipoCorriere.PortoAssegnato Then
                                            TestoDaStampare = "Spese di Imballo"
                                        End If

                                    End Using

                                    .WriteElementString("Descrizione", TestoDaStampare)
                                    .WriteElementString("Quantita", "1.00")
                                    .WriteElementString("PrezzoUnitario", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(ddt.CostoCorr))
                                    .WriteElementString("PrezzoTotale", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(ddt.CostoCorr))
                                    .WriteElementString("AliquotaIVA", R.PercIva & ".00")
                                    If R.PercIva = 0 Then
                                        .WriteElementString("Natura", R.NaturaEsclIva)
                                    End If

                                    .WriteEndElement() 'DettaglioLinee
                                    ContatoreInterno += 1
                                End If
                            Next
                        Else
                            'qui ciclo nelle righe di questa fattura

                            For Each riga In R.ListaRigheFat
                                'qui scrivo le varie linee della fattura
                                .WriteStartElement("DettaglioLinee")

                                .WriteElementString("NumeroLinea", ContatoreInterno)

                                Dim Codice As String = riga.Codice
                                If Codice.Length > 10 Then
                                    Codice = Codice.Substring(0, 10)
                                End If

                                .WriteStartElement("CodiceArticolo")
                                .WriteElementString("CodiceTipo", "Interno")
                                .WriteElementString("CodiceValore", Codice)
                                .WriteEndElement() 'CodiceArticolo

                                Dim DescrRiga As String = riga.Descrizione

                                If riga.Custom = enSiNo.No Then
                                    DescrRiga = FormerLib.FormerHelper.Finanziarie.PulisciRigaFattura(DescrRiga)
                                End If

                                DescrRiga = riga.Qta.ToString & " " & DescrRiga

                                DescrRiga = FormerLib.FormerHelper.Finanziarie.PulisciRigaFatturaFE(DescrRiga)

                                .WriteElementString("Descrizione", DescrRiga)
                                '.WriteElementString("Quantita", Dr("Qta").ToString & ".00")
                                '.WriteElementString("UnitaMisura", "Pz")
                                .WriteElementString("Quantita", "1.00")
                                .WriteElementString("PrezzoUnitario", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(riga.Importo))
                                .WriteElementString("PrezzoTotale", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(riga.Importo))
                                .WriteElementString("AliquotaIVA", R.PercIva & ".00")
                                If R.PercIva = 0 Then
                                    .WriteElementString("Natura", R.NaturaEsclIva)
                                End If
                                .WriteEndElement() 'DettaglioLinee
                                ContatoreInterno += 1
                            Next

                            If R.CostoCorr Then

                                'ContatoreInterno += 1

                                .WriteStartElement("DettaglioLinee")

                                .WriteElementString("NumeroLinea", ContatoreInterno)

                                Dim TestoDaStampare As String = "Consegna"

                                Using C As New Corriere
                                    C.Read(R.IdCorr)

                                    If C.TipoCorriere = enTipoCorriere.PortoAssegnato Then
                                        TestoDaStampare = "Spese di Imballo"
                                    End If

                                End Using

                                .WriteElementString("Descrizione", TestoDaStampare)
                                .WriteElementString("Quantita", "1.00")
                                .WriteElementString("PrezzoUnitario", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(R.CostoCorr))
                                .WriteElementString("PrezzoTotale", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(R.CostoCorr))
                                .WriteElementString("AliquotaIVA", R.PercIva & ".00")
                                If R.PercIva = 0 Then
                                    .WriteElementString("Natura", R.NaturaEsclIva)
                                End If
                                .WriteEndElement() 'DettaglioLinee

                            End If

                        End If

                        Dim VociFat As New cVociFatColl
                        Dim Dt As DataTable

                        Dt = VociFat.Lista(R.IdRicavo, IsRiepilogativa)

                        .WriteStartElement("DatiRiepilogo")
                        .WriteElementString("AliquotaIVA", R.PercIva & ".00")
                        If R.PercIva = 0 Then
                            .WriteElementString("Natura", R.NaturaEsclIva)
                        End If
                        .WriteElementString("ImponibileImporto", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(R.Importo))
                        .WriteElementString("Imposta", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(R.Iva))

                        '**************AGGIUNGERE QUI ESIGIBILITA IVA
                        .WriteElementString("EsigibilitaIVA", MgrFattureFE.GetEsigibilitaIVAFormatoFE(R.EsigibilitaIva))

                        .WriteEndElement() 'DatiRiepilogo

                        .WriteEndElement() 'DatiBeniServizi

                        If R.Tipo <> enTipoDocumento.NotaDiCredito Then
                            .WriteStartElement("DatiPagamento")
                            .WriteElementString("CondizioniPagamento", "TP02")
                            .WriteStartElement("DettaglioPagamento")
                            .WriteElementString("ModalitaPagamento", R.FAPAModalitaPagamento) ' "TP02") '************************

                            If R.EsigibilitaIva = enEsigibilitaIVA.SplitPayment Then
                                .WriteElementString("ImportoPagamento", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(R.Importo))
                            Else
                                .WriteElementString("ImportoPagamento", FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(R.Totale))
                            End If

                            'If R.Dataprevpagam <> Date.MinValue AndAlso R.Dataprevpagam <> R.DataRicavo Then
                            '    .WriteElementString("DataScadenzaPagamento", R.FAPADataScadenzaPagamentoStr)
                            'End If
                            If R.FAPAModalitaPagamento = "MP05" Then
                                'bonifico bancario
                                .WriteElementString("IBAN", MgrAziende.GetIBAN(R.IdAzienda).Replace(" ", ""))
                                .WriteElementString("BIC", MgrAziende.GetBIC(R.IdAzienda))
                            End If
                            .WriteEndElement() 'DettaglioPagamento
                            .WriteEndElement() 'DatiPagamento
                        End If

                        .WriteEndElement() 'FATTURAELETTRONICABODY

                        .WriteEndElement() 'P:FatturaElettronica
                        .WriteEndDocument()
                        .Close()

                    End With
                End Using

                ris = Encoding.UTF8.GetString(ms.ToArray())

                'qui salvo il memory stream in un file 

                Using fs As New IO.StreamWriter(PathOut)
                    fs.Write(ris)
                End Using

            End Using

        Catch ex As Exception

        End Try

        Return ris
    End Function

    Public Shared Function ReadXmlSigned(ByVal filePath As String,
                                   ByVal Optional validateSignature As Boolean = True) As String
        Dim buffer As String = String.Empty
        Using R As New StreamReader(filePath)
            buffer = R.ReadToEnd
        End Using

        If FormerLib.FormerHelper.Security.IsBase64(buffer) Then
            File.WriteAllBytes(filePath, Convert.FromBase64String(buffer))
        End If

        Using inputStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
            Dim signedFile As CmsSignedData = New CmsSignedData(inputStream)

            If validateSignature Then
                Dim certStore As IX509Store = signedFile.GetCertificates("Collection")
                Dim certs As ICollection = certStore.GetMatches(New X509CertStoreSelector())
                Dim signerStore As SignerInformationStore = signedFile.GetSignerInfos()
                Dim signers As ICollection = signerStore.GetSigners()

                For Each tempCertification As Object In certs
                    Dim certification As Org.BouncyCastle.X509.X509Certificate = TryCast(tempCertification, Org.BouncyCastle.X509.X509Certificate)

                    For Each tempSigner As Object In signers
                        Dim signer As SignerInformation = TryCast(tempSigner, SignerInformation)

                        If Not signer.Verify(certification.GetPublicKey()) Then
                            'MessageBox.Show("Errore")
                            Throw New ApplicationException("SignatureException")
                            'Throw New FatturaElettronicaSignatureException(Resources.ErrorMessages.SignatureException)
                        End If
                    Next
                Next
            End If

            Dim outFile As String = filePath & ".source.xml"

            Using fileStream = New FileStream(outFile, FileMode.Create, FileAccess.Write)
                signedFile.SignedContent.Write(fileStream)
            End Using

            Return outFile

        End Using
    End Function

End Class
