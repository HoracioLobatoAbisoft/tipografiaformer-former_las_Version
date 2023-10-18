Imports FormerLib.FormerEnum

Public Class FormerListSorter

    Public Class RisUtilizzoRisorsaSorter
        Public Shared Function SortPerELenco(ByVal x As RisUtilizzoRisorsa,
                                             ByVal y As RisUtilizzoRisorsa) As Integer


            Dim result As Integer = x.Risorsa.TipoCarta.Tipologia.CompareTo(y.Risorsa.TipoCarta.Tipologia)
            If result = 0 Then
                result = x.Risorsa.Descrizione.CompareTo(y.Risorsa.Descrizione)
            End If
            Return result
        End Function
    End Class

    Public Class ListiniBaseSorter
        Public Shared Function SortRepartoDescrizione(ByVal x As ListinoBase,
                                                      ByVal y As ListinoBase) As Integer
            Dim result As Integer = x.Preventivazione.IdReparto.CompareTo(y.Preventivazione.IdReparto)
            If result = 0 Then result = x.Nome.CompareTo(y.Nome)
            Return result
        End Function
    End Class

    Public Class PreventivazioneSorter
        Public Shared Function SortRepartoDescrizione(ByVal x As Preventivazione,
                                                      ByVal y As Preventivazione) As Integer
            Dim result As Integer = x.IdReparto.CompareTo(y.IdReparto)
            If result = 0 Then result = x.Descrizione.CompareTo(y.Descrizione)
            Return result
        End Function
    End Class

    Public Class RicaviSorter
        Public Shared Function SortDefault(ByVal x As Ricavo,
                                           ByVal y As Ricavo) As Integer
            Dim result As Integer = 0
            If result = 0 Then result = y.DataRicavo.CompareTo(x.DataRicavo)
            If result = 0 Then result = y.Numero.CompareTo(x.Numero)
            Return result
        End Function
    End Class

    Public Class MovimentiMagazzinoSorter
        Public Shared Function SortExportCSV(ByVal x As MovimentoMagazzino, ByVal y As MovimentoMagazzino) As Integer
            Dim result As Integer = 0 ' x.FornitoreStr.CompareTo(y.FornitoreStr)

            If result = 0 Then
                result = x.RisorsaStr.CompareTo(y.RisorsaStr)
            End If

            Return result
        End Function
    End Class

    Public Class CostiSorter
        Public Shared Function SortDefault(ByVal x As Costo,
                                           ByVal y As Costo) As Integer
            Dim result As Integer = 0
            If result = 0 Then result = y.DataCosto.CompareTo(x.DataCosto)
            If result = 0 Then result = y.Numero.CompareTo(x.Numero)
            Return result
        End Function
    End Class

    Public Class TipoCartaSorter
        Public Shared Function SortFinituraNome(ByVal x As TipoCarta,
                                                ByVal y As TipoCarta) As Integer
            Dim result As Integer = x.Finitura.CompareTo(y.Finitura)
            If result = 0 Then result = x.Tipologia.CompareTo(y.Tipologia)
            Return result
        End Function
    End Class

    Public Class IndirizziSorter
        Public Shared Function SortDefault(ByVal x As Indirizzo,
                                                       ByVal y As Indirizzo) As Integer

            Dim result As Integer = x.RiassuntoEx.CompareTo(y.RiassuntoEx)
            'Dim result As Integer = y.Predefinito.CompareTo(x.Predefinito)
            'If result = 0 Then result = x.RiassuntoEx.CompareTo(y.RiassuntoEx)
            'If result = 0 Then result = x.Citta.CompareTo(y.Citta)
            'If result = 0 Then result = x.Indirizzo.CompareTo(y.Indirizzo)
            Return result
        End Function
    End Class

    Public Class RisorseSorter
        Public Shared Function SortDefault(ByVal x As Risorsa,
                                               ByVal y As Risorsa) As Integer
            Dim result As Integer = y.UltimoCaricoMagazzinoDate.CompareTo(x.UltimoCaricoMagazzinoDate)
            Return result
        End Function
    End Class

    Public Class PrezziLavorazioneSorter
        Public Shared Function SortNomeFormato(ByVal x As PrezzoLavoro,
                                                ByVal y As PrezzoLavoro) As Integer
            Dim result As Integer = x.Riassunto.CompareTo(y.Riassunto)
            Return result
        End Function

        Public Shared Function SortAreaFormato(ByVal x As PrezzoLavoro,
                                        ByVal y As PrezzoLavoro) As Integer
            Dim result As Integer = 0
            result = x.IdFormProd.CompareTo(y.IdFormProd)
            If result = 0 Then
                result = x.TipoGrandezzaPrezzo.CompareTo(y.TipoGrandezzaPrezzo)
                If result = 0 Then
                    If Not x.FormatoCarta Is Nothing And Not y.FormatoCarta Is Nothing Then
                        result = x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area)
                    End If
                End If
            End If
            Return result
        End Function

    End Class

    Public Class LavLogSorter
        Public Shared Function SortPerAnteprima(ByVal x As LavLog,
                                                ByVal y As LavLog) As Integer
            Dim result As Integer = (y.Idlav = FormerLib.FormerConst.Lavorazioni.InserimentoNelSistema).CompareTo(x.Idlav = FormerLib.FormerConst.Lavorazioni.InserimentoNelSistema)
            If result = 0 Then result = x.Ordine.CompareTo(y.Ordine)
            Return result
        End Function
    End Class

    Public Class PromoSorter
        Public Shared Function ComparerSceltaProssimi(x As RisPromoSuLB, y As RisPromoSuLB) As Integer
            Dim result As Integer = 0

            result = x.ListinoBase.CounterDayPromo.CompareTo(y.ListinoBase.CounterDayPromo)
            If result = 0 Then
                result = x.PercentualeSuFatturato.CompareTo(y.PercentualeSuFatturato)
                If result = 0 Then
                    result = x.FatturatoMensileTotale.CompareTo(y.FatturatoMensileTotale)
                End If
            End If
            'ORDINO SEMPRE PER COUNTERDAY COSI SONO EQUILIBRATI PER GIORNI VISUALIZZATI

            'result = x.PercentualeSuFatturato.CompareTo(y.PercentualeSuFatturato)
            'If result = 0 Then
            '    result = x.FatturatoMensileTotale.CompareTo(y.FatturatoMensileTotale)
            'End If
            Return result
        End Function
    End Class

    Public Class CommesseSorter
        Public Shared Function ComparerCommessaProposta(ByVal x As CommessaProposta,
                                         ByVal y As CommessaProposta) As Integer
            Dim result As Integer = 0
            'result = x.ModelloCommessa.Nome.CompareTo(y.ModelloCommessa.Nome)
            If result = 0 Then
                result = y.Ordini.Count.CompareTo(x.Ordini.Count)
                If result = 0 Then
                    result = y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento)
                    If result = 0 Then
                        result = y.Tiratura.CompareTo(x.Tiratura)
                    End If
                End If
            End If


            Return result
        End Function
    End Class

    Public Class OrdiniSorter
        Public Shared Function ComparerOrderInSoluzione(x As OrdineInSoluzione,
                                        y As OrdineInSoluzione) As Integer
            Dim result As Integer = 0

            result = x.Ordine.IdListinoBase.CompareTo(y.Ordine.IdListinoBase)

            If result = 0 Then
                result = x.QtaOrdine.CompareTo(y.QtaOrdine)
            End If

            Return result

        End Function
    End Class

End Class
