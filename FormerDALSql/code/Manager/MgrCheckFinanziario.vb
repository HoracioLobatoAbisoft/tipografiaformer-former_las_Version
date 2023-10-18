Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrCheckFinanziario

    Public Shared Function GetSituation() As RisCheckFinanziario

        Dim r As New RisCheckFinanziario

        Using mgr As New VociRubricaDAO
            Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Sorgente, "F"))

            r.FornitoriInseritiAutomaticamente = l.Count
            If l.Count Then
                r.TotAlert += 1
            End If
            r.VociDuplicate = mgr.GetDuplicati().Count
            If r.VociDuplicate Then
                r.TotAlert += 1
            End If
            Dim lNoC As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.IsFornitore, enSiNo.Si),
                                                         New LUNA.LunaSearchParameter(LFM.VoceRubrica.IdCatContab, 0))
            r.FornitoriSenzaCategoria = lNoC.Count
            If lNoC.Count Then
                r.TotError += 1
            End If
        End Using

        Using mgr As New RicaviDAO
            Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.DaInviare),
                                                   New LUNA.LunaSearchParameter("year(DataRicavo)", 2019, ">="),
                                                   New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.DDT & "," & enTipoDocumento.NotaDiDebito & "," & enTipoDocumento.Preventivo & ")", "NOT IN"))
            r.NonInCodaPerInvio = l.Count
            If l.Count Then
                r.TotAlert += 1
            End If

            If l.Count Then
                Dim TotaleSbagliati As Integer = 0
                For Each doc In l
                    Dim DiffGiorni As Integer = DateDiff(DateInterval.Day, doc.DataRicavo.Date, Now.Date)
                    If DiffGiorni > 8 Then
                        TotaleSbagliati += 1
                    End If
                Next
                r.NonInCodaPerInvio9Giorni = TotaleSbagliati
            End If

            l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.ConsegnataPEC),
                            New LUNA.LunaSearchParameter("year(DataRicavo)", 2019, ">="),
                            New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.DDT & "," & enTipoDocumento.NotaDiDebito & ")", "NOT IN"))

            If l.Count Then
                Dim TotaleSbagliati As Integer = 0
                For Each doc In l
                    Dim DiffGiorni As Integer = DateDiff(DateInterval.Day, doc.DataOraInvio.Date, Now.Date)
                    If DiffGiorni > 4 And DiffGiorni < 180 Then 'aggiunto 180 per evitare notifiche di cose ormai consolidate
                        TotaleSbagliati += 1
                    End If
                Next
                r.InviatiSDIDaOltre5Giorni = TotaleSbagliati
                If r.InviatiSDIDaOltre5Giorni Then
                    r.TotAlert += 1
                End If
            End If



            l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.ScartataSDI),
                            New LUNA.LunaSearchParameter("year(DataRicavo)", 2019, ">="),
                            New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.DDT & "," & enTipoDocumento.NotaDiDebito & ")", "NOT IN"))
            r.Scartati = l.Count
            If l.Count Then
                r.TotError += 1
            End If
            l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.ConsegnataPEC),
                            New LUNA.LunaSearchParameter("year(DataRicavo)", 2019, ">="),
                            New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.DDT & "," & enTipoDocumento.NotaDiDebito & ")", "NOT IN"))

            If l.Count Then
                Dim TotaleSbagliati As Integer = 0
                For Each doc In l
                    Dim DiffGiorni As Integer = DateDiff(DateInterval.Day, doc.DataOraInvio.Date, Now.Date)
                    If DiffGiorni > 4 And DiffGiorni < 180 Then
                        TotaleSbagliati += 1
                    End If
                Next
                r.InviatiSDIDaOltre5Giorni = TotaleSbagliati
                If r.InviatiSDIDaOltre5Giorni Then
                    r.TotAlert += 1
                End If
            End If

            l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.InCodaInvio),
                            New LUNA.LunaSearchParameter("year(DataRicavo)", 2019, ">="),
                            New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.DDT & "," & enTipoDocumento.Preventivo & "," & enTipoDocumento.NotaDiDebito & ")", "NOT IN"))

            If l.Count Then
                Dim TotaleSbagliati As Integer = 0
                For Each doc In l
                    Dim DiffGiorni As Integer = DateDiff(DateInterval.Day, doc.DataRicavo.Date, Now.Date)
                    If DiffGiorni > 2 Then
                        TotaleSbagliati += 1
                    End If
                Next
                r.InCodaInvioDaOltre3Giorni = TotaleSbagliati
                If r.InCodaInvioDaOltre3Giorni Then
                    r.TotAlert += 1
                End If
            End If

        End Using

        Using mgr As New CheckMassiviDAO
            Dim l As List(Of CheckMassivo) = mgr.GetAll(LFM.CheckMassivo.IdAzienda)
            For az = 1 To 2
                Dim AzStr As String = String.Empty

                If az = MgrAziende.IdAziende.AziendaSrl Then
                    AzStr = "SRL "
                ElseIf az = MgrAziende.IdAziende.AziendaSnc Then
                    AzStr = "SNC "
                End If

                For i As Integer = 2019 To Now.Year
                    Dim MeseFin As Integer = 12
                    If i = Now.Year Then
                        MeseFin = Now.Month
                        If MeseFin <> 1 Then
                            MeseFin = MeseFin - 1
                        End If
                    End If
                    For j As Integer = 1 To MeseFin
                        Dim MeseRif As Integer = j
                        Dim AnnoRif As Integer = i
                        Dim IdAz As Integer = az
                        If l.FindAll(Function(x) x.AnnoRiferimento = AnnoRif And
                                         x.MeseRiferimento = MeseRif And
                                         x.Stato = enStatoCheckMassivo.Completato And
                                         x.IdAzienda = IdAz And
                                         x.TipoCheck = enTipoVoceContab.VoceAcquisto).Count = 0 Then
                            r.ListaCheckMassiviMancanti.Add(AzStr & AnnoRif & " " & FormerLib.FormerHelper.Calendario.MeseToString(MeseRif) & " ACQUISTO")
                        End If

                        If l.FindAll(Function(x) x.AnnoRiferimento = AnnoRif And
                                         x.MeseRiferimento = MeseRif And
                                         x.Stato = enStatoCheckMassivo.Completato And
                                         x.IdAzienda = IdAz And
                                         x.TipoCheck = enTipoVoceContab.VoceVendita).Count = 0 Then
                            r.ListaCheckMassiviMancanti.Add(AzStr & AnnoRif & " " & FormerLib.FormerHelper.Calendario.MeseToString(MeseRif) & " VENDITA")
                        End If
                    Next
                Next
            Next

        End Using

        If r.ListaCheckMassiviMancanti.Count Then
            r.TotError += 1
        End If

        Using mgr As New CarichiDiMagazzinoDAO
            Dim l As List(Of CaricoDiMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdStatoInterno, enStatoFEInterno.Anomalia))
            r.CarichiMagazzinoAnomalia = l.Count
            If l.Count Then
                r.TotError += 1
            End If
            l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdStatoInterno, enStatoFEInterno.Inserito))
            r.CarichiMagazzinoNonCollegati = l.Count
            If l.Count Then
                r.TotAlert += 1
            End If
        End Using

        Using mgr As New RisorseDAO
            Dim l As List(Of Risorsa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Risorsa.TipoRis, enTipoProdCom.NonSpecificato),
                                                    New LUNA.LSP(LFM.Risorsa.Stato, enStato.Attivo))

            r.RisorseTipoNonSpecificato = l.Count
            If l.Count Then
                r.TotAlert += 1
            End If
        End Using

        Return r

    End Function

End Class
