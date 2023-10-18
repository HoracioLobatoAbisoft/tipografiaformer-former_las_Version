Imports FormerLib.FormerEnum

Public Class MgrSituazioneCliente

    Public Shared Function GetSituazioneCliente(IdRub As Integer,
                                                Optional StatoIncasso As enStatoIncasso = enStatoIncasso.Tutto) As RisSituazioneCliente
        Dim ris As RisSituazioneCliente = Nothing

        Dim l As List(Of RisSituazioneCliente) = GetSituazioneClienti(IdRub, StatoIncasso)
        If l.Count Then
            ris = l(0)
        End If

        Return ris
    End Function

    Public Shared Function GetSituazioneClienti(Optional IdRubPar As Integer = 0,
                                                Optional StatoIncasso As enStatoIncasso = enStatoIncasso.Tutto) As List(Of RisSituazioneCliente)
        Dim ris As New List(Of RisSituazioneCliente)

        Dim lCli As List(Of Integer) = Nothing

        If IdRubPar Then

            lCli = New List(Of Integer)
            lCli.Add(IdRubPar)

        Else
            Using mgr As New VociRubricaDAO

                lCli = mgr.ListaIdClientiConPendenza()

            End Using
        End If

        For Each IdRub In lCli
            Dim Voce As New RisSituazioneCliente
            Voce.IdRub = IdRub
            'voce.TotaleDocumenti 
            'Voce.TotaleDaIncassareDocumenti
            'Voce.TotaleDaIncassareDocumentiScaduto

            Using mgr As New RicaviDAO
                Dim lR As List(Of RicavoEx) = mgr.Lista(IdRub) ', StatoIncasso)

                If StatoIncasso <> enStatoIncasso.Tutto Then
                    If lR.FindAll(Function(x) x.StatoIncasso = StatoIncasso).Count = 0 Then
                        'se non trovo nemmeno un documento con quello statoincasso azzero la lista 
                        lR = New List(Of RicavoEx)
                    End If
                End If

                Voce.TotaleDocumenti = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(lR.Sum(Function(x) x.TotaleMatematico)) '****NOTADICREDITO x.Totale
                Voce.TotaleIncassati = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(lR.Sum(Function(x) x.Incassati))
                Voce.TotaleDaIncassareScaduto = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(lR.FindAll(Function(x) x.Tipo <> enTipoDocumento.NotaDiCredito And DateDiff(DateInterval.Day, x.Dataprevpagam, Now) > 0).Sum(Function(x) x.TotaleAncoraDaPagare))

                For Each VoceR In lR
                    If Voce.ListaAnniDocumenti.FindAll(Function(x) x = VoceR.DataRicavo.Year).Count = 0 Then
                        Voce.ListaAnniDocumenti.Add(VoceR.DataRicavo.Year)
                    End If
                Next

            End Using

            Dim AggiungiVoce As Boolean = True

            If StatoIncasso <> enStatoIncasso.Tutto Then
                If Voce.TotaleDocumenti = 0 AndAlso IdRubPar = 0 Then
                    AggiungiVoce = False
                End If
            End If

            If AggiungiVoce Then
                Using MgrO As New OrdiniDAO
                    Voce.TotaleProntoStampa = MgrO.TotaleProntoStampa(IdRub)
                End Using
            End If

            If AggiungiVoce Then
                Using mgr As New PagamentiDAO
                    Voce.UltimoPagamento = mgr.GetLastByIdRub(IdRub)
                End Using
            End If

            If AggiungiVoce Then
                Using mgr As New OrdiniDAO

                    Dim lOrd As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = "DataIns DESC"},
                                                    New LUNA.LunaSearchParameter(LFM.Ordine.IdRub, IdRub))
                    If lOrd.Count Then Voce.UltimoLavoro = lOrd(0)
                End Using
            End If

            If Voce.TotaleScopertoComplessivo = 0 AndAlso IdRubPar = 0 Then
                AggiungiVoce = False
            End If

            If AggiungiVoce Then
                Using R As New VoceRubrica
                    R.Read(IdRub)
                    Voce.RagSocNome = R.RagSocNome

                End Using

                ris.Add(Voce)
            End If


        Next

        Return ris
    End Function

End Class
