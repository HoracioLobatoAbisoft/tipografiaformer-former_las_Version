Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrDocumentiFiscali

    Public Class DocumentNumber

        Public Shared Function GetNextNumber(IdAzienda As Integer,
                                             TipoDoc As enTipoDocumento) As Integer

            Dim NumeroDoc As Integer = 0
            Using mRic As New RicaviDAO
                NumeroDoc = mRic.GetNextNumeroDoc(IdAzienda, TipoDoc, 0)
            End Using
            Return NumeroDoc

        End Function



        Public Shared Function GetNextNumberByYear(IdAzienda As Integer,
                                                   TipoDoc As enTipoDocumento, Anno As Integer) As Integer

            Dim NumeroDoc As Integer = 0
            Using mRic As New RicaviDAO
                NumeroDoc = mRic.GetNextNumeroDoc(IdAzienda, TipoDoc, Anno)
            End Using
            Return NumeroDoc

        End Function

        Public Shared Function GetNumberError(Optional AnnoRif As Integer = 0) As String
            Dim ris As String = String.Empty

            Using mgr As New RicaviDAO

                Dim pAnno As LUNA.LunaSearchParameter = Nothing

                If AnnoRif Then
                    pAnno = New LUNA.LunaSearchParameter("Year(dataricavo)", AnnoRif)
                End If

                For j As Integer = 1 To 2
                    Dim IdAzienda As Integer = j
                    Dim BufferAzienda As String = String.Empty

                    Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Year(dataricavo) DESC,numero DESC"},
                                                                       New LUNA.LunaSearchParameter(LFM.Ricavo.IdAzienda, IdAzienda),
                                                                       pAnno,
                                                                       New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.NotaDiCredito & "," & enTipoDocumento.FatturaRiepilogativa & ")", "IN"))

                    Dim Differenza As Integer = 0
                    Dim LastNum As Integer = 0
                    Dim LastYear As Integer = 0

                    For Each R As Ricavo In l
                        If LastYear <> R.DataRicavo.Year Then
                            LastNum = 0
                            LastYear = R.DataRicavo.Year
                        End If

                        If LastNum = 0 Then
                            LastNum = R.Numero
                        Else
                            Differenza = LastNum - R.Numero

                            If Differenza = 0 Then
                                'numero duplicato
                                BufferAzienda &= "NUMERO DUPLICATO: " & R.DataRicavo.Year & "-" & R.Numero & ControlChars.NewLine
                            ElseIf Differenza > 1 Then
                                'numero mancante 
                                For i = LastNum - 1 To R.Numero + 1 Step -1
                                    BufferAzienda &= "NUMERO MANCANTE: " & R.DataRicavo.Year & "-" & i & ControlChars.NewLine
                                Next
                            End If
                            LastNum = R.Numero
                        End If
                    Next
                    If BufferAzienda.Length Then
                        Using a As New Azienda
                            a.Read(IdAzienda)
                            BufferAzienda = "***" & a.RagioneSociale & "***" & ControlChars.NewLine & BufferAzienda
                        End Using
                    End If

                    ris &= BufferAzienda
                Next

            End Using

            Return ris
        End Function
    End Class

    Public Shared Function GetListaStatiFiscali() As List(Of Integer)
        Dim ris As List(Of Integer)

        Using mgr As New RicaviDAO
            ris = mgr.GetListaStatiFEAttivi
        End Using

        Return ris
    End Function

    Public Shared Sub AggiornaStatoCostoDopoPagamento(IdCosto As Integer)

        Using C As New Costo
            C.Read(IdCosto)

            Dim SommaPagamenti As Decimal = C.ListaPagamenti.Sum(Function(x) x.Importo)

            Dim TotaleDaControllare As Decimal = C.Totale
            Dim DataNuovoPagamento As Date = Date.MinValue
            Dim NuovoIdStato As Integer = 0

            'If C.DataEffettivoPagamento = Date.MinValue Then
            If C.ListaPagamenti.Count Then
                Dim lp As List(Of Pagamento) = C.ListaPagamenti
                lp.Sort(Function(x, y) y.DataPag.CompareTo(x.DataPag))
                Dim ultimoPag As Pagamento = lp(0)
                DataNuovoPagamento = ultimoPag.DataPag
            End If
            'End If

            If FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotaleDaControllare) = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(SommaPagamenti) Then

                NuovoIdStato = enStatoDocumentoFiscale.PagatoInteramente

                'End If
            Else
                If SommaPagamenti > 0 Then
                    NuovoIdStato = enStatoDocumentoFiscale.PagatoAcconto
                    'enStatoOrdine.PagatoAcconto 
                Else
                    NuovoIdStato = enStatoDocumentoFiscale.Registrato
                    'enStatoOrdine.Consegnato
                End If

            End If

            Dim CambiatoQualcosa As Boolean = False

            If NuovoIdStato <> C.IdStato Then
                'qui è cambiato qualcosa nello stato del documento
                CambiatoQualcosa = True
                C.IdStato = NuovoIdStato

                If C.Tipo = enTipoDocumento.FatturaRiepilogativa And NuovoIdStato = enStatoDocumentoFiscale.PagatoInteramente Then
                    'qui devo mettere a pagato anche tutti i ddt contenuti 
                    Using mgr As New CostiDAO
                        Dim lDDT As List(Of Costo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Costo.IdDocRif, C.IdCosto))

                        For Each RIn As Costo In lDDT
                            RIn.IdStato = enStatoDocumentoFiscale.PagatoInteramente
                            RIn.Save()
                        Next

                    End Using

                End If
            End If

            If DataNuovoPagamento <> C.DataEffettivoPagamento Then
                C.DataEffettivoPagamento = DataNuovoPagamento
                CambiatoQualcosa = True
            End If

            If CambiatoQualcosa Then
                C.Save()
            End If

        End Using

    End Sub

    Public Shared Sub AggiornaStatoRicavoDopoPagamento(IdRicavo As Integer)

        Using R As New Ricavo
            R.Read(IdRicavo)

            Dim SommaPagamenti As Decimal = R.ListaPagamenti.Sum(Function(x) x.Importo)

            Dim TotaleDaControllare As Decimal = R.Totale

            If R.EsigibilitaIva = enEsigibilitaIVA.SplitPayment Then
                TotaleDaControllare = R.Importo
            End If

            If FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotaleDaControllare) = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(SommaPagamenti) Then

                'If MessageBox.Show("L'importo totale del documento risulta incassato, passare tutti gli ordini relativi allo stato di Pagato?", "Pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Using doc As New cContabRicaviColl
                    doc.PassaA(IdRicavo,
                               enStatoOrdine.PagatoInteramente,
                               True)
                End Using
                'If fromNotaDiCredito = False Then
                '    MessageBox.Show("Gli ordini usciti da magazzino sono passati allo stato di Pagato!", "Consegna ordini", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If

                R.idstato = enStatoDocumentoFiscale.PagatoInteramente
                R.Save()

                If R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                    'qui devo mettere a pagato anche tutti i ddt contenuti 
                    Using mgr As New RicaviDAO
                        Dim lDDT As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.IdDocRif, R.IdRicavo))

                        For Each RIn As Ricavo In lDDT
                            RIn.idstato = enStatoDocumentoFiscale.PagatoInteramente
                            RIn.Save()
                        Next

                    End Using

                End If

                'End If
            Else
                If SommaPagamenti > 0 Then
                    R.idstato = enStatoDocumentoFiscale.PagatoAcconto
                    'enStatoOrdine.PagatoAcconto 
                Else
                    R.idstato = enStatoDocumentoFiscale.Registrato
                    'enStatoOrdine.Consegnato
                End If

                R.Save()

            End If

        End Using


    End Sub

    Public Shared Function GetIntestazione(R As Ricavo) As String
        Dim Intest As String = String.Empty

        If R.AnnoRiferimento >= 2019 Then
            If R.StatoFE = enStatoFatturaFE.DaInviare Or
               R.StatoFE = enStatoFatturaFE.ScartataSDI Or
               R.StatoFE = enStatoFatturaFE.InCodaInvio Then
                Intest = R.VoceRubrica.RagSocNome & " (" & R.IdRub & ")" & ControlChars.NewLine
                Intest &= R.VoceRubrica.Indirizzo & ControlChars.NewLine
                Intest &= R.VoceRubrica.Citta & ControlChars.NewLine
                Intest &= R.VoceRubrica.CAP & ControlChars.NewLine
                Intest &= "P.IVA " & R.VoceRubrica.PrefissoPiva & R.VoceRubrica.Piva & ControlChars.NewLine

                If Not R.ConsegnaRif Is Nothing Then
                    Intest &= "Ind.Cons. " & R.ConsegnaRif.IndirizzoRiassunto & ControlChars.NewLine
                    Intest &= "Pagamento " & R.ConsegnaRif.MetodoPagamento.TipoPagam
                End If

            Else
                'qui vado a prenderlo dal documento xml 
                Dim f As FatturaElettronica = Nothing
                If R.Tipo = enTipoDocumento.NotaDiCredito Then
                    Using RicavoRif As Ricavo = R.RicavoRiferimentoNotadiCredito
                        f = MgrFattureFE.GetFatturaFromRicavo(RicavoRif)
                    End Using
                Else
                    f = MgrFattureFE.GetFatturaFromRicavo(R)
                End If

                Dim RagSocNome As String = f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.Anagrafica.Denominazione

                If RagSocNome Is Nothing Then
                    RagSocNome = f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.Anagrafica.Cognome
                End If

                Intest = RagSocNome & " (" & R.IdRub & ")" & ControlChars.NewLine
                Intest &= f.FatturaElettronicaHeader.CessionarioCommittente.Sede.Indirizzo & ControlChars.NewLine
                Intest &= f.FatturaElettronicaHeader.CessionarioCommittente.Sede.Comune & ControlChars.NewLine
                Intest &= f.FatturaElettronicaHeader.CessionarioCommittente.Sede.CAP & ControlChars.NewLine

                If Not f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA Is Nothing AndAlso Not f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese Is Nothing Then
                    Intest &= "P.IVA " & f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese & f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice & ControlChars.NewLine
                End If

                If Not f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA Is Nothing AndAlso Not f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice Is Nothing AndAlso
                    f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice.Length = 0 AndAlso
                    Not f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.CodiceFiscale Is Nothing Then 'R.VoceRubrica.Piva.Length = 0 AndAlso R.VoceRubrica.CodFisc.Length Then
                    Intest &= "Cod. Fiscale " & f.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.CodiceFiscale
                End If

            End If
        Else
            Intest = R.pRagSoc & " (" & R.IdRub & ")" & vbNewLine
            Intest &= R.pIndirizzo & vbNewLine
            Intest &= R.pCitta & vbNewLine
            Intest &= R.pCap & vbNewLine
            Intest &= "P.IVA " & R.pIva & vbNewLine
            Intest &= "Ind.Cons. " & R.pIndCons & vbNewLine
            Intest &= "Pagamento " & R.pPagamento & vbNewLine
        End If

        Return Intest

    End Function
End Class
