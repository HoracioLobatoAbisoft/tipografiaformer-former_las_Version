Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerDALSql
Imports FormerBusinessLogicInterface

Public Class MgrPreRefineCheck

    Public Shared Function CheckOrder(RisultatoValidazione As ValidationOrderResult,
                                      L As ListinoBase,
                                      NumeroSorgenti As Integer,
                                      NumeroFogliOrdine As Integer,
                                      TipoRetro As enTipoRetro) As enErroriPreRefine

        Dim ris As enErroriPreRefine = enErroriPreRefine.Nessuno
        If Not RisultatoValidazione Is Nothing Then
            If RisultatoValidazione.HannoDimensioniErrate AndAlso L.Preventivazione.IdReparto <> enRepartoWeb.Ricamo Then
                ris += enErroriPreRefine.DimensioniErrate
            End If
        End If

        If L.Preventivazione.IdReparto = enRepartoWeb.StampaOffset Then

            If GetNumeroModelliPerFormatoProdotto(L) = 0 Then
                ris += enErroriPreRefine.ModelloNonPresente
            End If

            'Using mgr As New ModelliCommessaDAO
            '    Using fp As New FormatoProdotto
            '        fp.Read(L.IdFormProd)
            '        Dim Ml As List(Of ModelloCommessa) = mgr.FindByFormatoProdotto(fp)
            '        Ml = Ml.FindAll(Function(x) x.FormatiProdotto.Count = 1)
            '        If L.ColoreStampa.FR Then
            '            Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.Si)
            '        Else
            '            Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.No)
            '        End If

            '        If Ml.Count = 0 Then
            '            ris += enErroriPreRefine.ModelloNonPresente
            '        End If
            '    End Using
            'End Using
            If NumeroSorgenti <> GetNumeroSorgentiPrevistiOrdine(L, TipoRetro, NumeroFogliOrdine) Then
                ris += enErroriPreRefine.NumeroSorgentiErrato
            End If
        End If

        Return ris

    End Function

    Public Shared Function GetNumeroModelliPerFormatoProdotto(L As ListinoBase) As Integer
        Dim ris As Integer = 0
        If L.Preventivazione.IdReparto = enRepartoWeb.StampaOffset Then
            Using mgr As New ModelliCommessaDAO
                Using fp As New FormatoProdotto
                    fp.Read(L.IdFormProd)
                    Dim Ml As List(Of ModelloCommessa) = mgr.FindByFormatoProdotto(fp)
                    Ml = Ml.FindAll(Function(x) x.FormatiProdotto.Count = 1)
                    If L.ColoreStampa.FR Then
                        Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.Si)
                    Else
                        Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.No)
                    End If
                    ris = Ml.Count
                End Using
            End Using
        End If
        Return ris
    End Function

    Public Shared Function GetNumeroSorgentiPrevistiOrdine(O As Ordine) As Integer
        Dim ris As Integer = 0

        ris = GetNumeroSorgentiPrevistiOrdine(O.ListinoBase, O.TipoRetro, O.NFogli)

        Return ris
    End Function


    Public Shared Function GetNumeroSorgentiPrevistiOrdine(L As ListinoBase,
                                                           TipoRetro As enTipoRetro,
                                                           NumeroFogliOrdine As Integer) As Integer
        Dim ris As Integer = 0

        If L.ColoreStampa.FR = False Then 'SOLO FRONTE 1 sorgente
            If (L.FaccMin = 2 And L.FaccMax = 2) OrElse L.NoFaccSuImpianti = True Then
                ris = 1
            Else
                If L.FaccMin = L.FaccMax Then
                    ris = L.FaccMin / 2
                Else
                    ris = NumeroFogliOrdine * 2
                End If
            End If
            'ris = 1
        Else
            If (L.FaccMin = 2 And L.FaccMax = 2) OrElse L.NoFaccSuImpianti = True Then
                'qui è solo fronte retro 
                If TipoRetro = enTipoRetro.RetroBianco Then
                    ris = 1
                Else
                    ris = 2
                End If
            Else
                'qui e' multipagina 
                Dim NumeroFacciate As Integer = NumeroFogliOrdine * 2
                If TipoRetro = enTipoRetro.RetroBianco Then
                    NumeroFacciate /= 2
                End If
                ris = NumeroFacciate
            End If
        End If

        Return ris
    End Function

    Public Shared Function ExistThisPreRefineError(Valore As Integer,
                                               Errore As enErroriPreRefine) As Boolean
        Dim ris As Boolean = False

        If (Valore And Errore) = Errore Then ris = True

        Return ris
    End Function

End Class
