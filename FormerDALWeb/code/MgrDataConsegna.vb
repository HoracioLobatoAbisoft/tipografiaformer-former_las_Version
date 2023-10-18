Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrDataConsegna

    Public Function CalcolaDataConsegna(DataProduzione As Date, C As CorriereW) As Date

        Dim DataConsegna As Date = DataProduzione

        If C.IdCorriere <> enCorriere.RitiroCliente Then
            If C.IdCorriere <> enCorriere.TipografiaFormer Then
                If DataProduzione.DayOfWeek = DayOfWeek.Saturday Then
                    'qui se il corriere non e' nemmeno tipografia former controllo se la produzione finisce di sabato, siccome non ritirano sposto di un giorno
                    DataConsegna = DataConsegna.AddDays(2)
                End If
            End If

            Dim GGAggiunti As Integer = 0

            Do Until GGAggiunti = C.GGConsegna
                DataConsegna = DataConsegna.AddDays(1)
                If DataConsegna.DayOfWeek <> DayOfWeek.Sunday And DataConsegna.DayOfWeek <> DayOfWeek.Saturday Then
                    GGAggiunti += 1
                End If
            Loop

        End If

        Return DataConsegna

    End Function

    Private Sub CalcolaBloccoDate(ByVal DataPartenza As Date, _
                                  ByRef DataProduzione As Date, _
                                  ByRef DataConsegna As Date, _
                                  ggProduzione As Integer, _
                                  C As CorriereW)

        DataProduzione = DataPartenza.AddDays(ggProduzione)
        For i = 1 To ggProduzione 'per la produzione escludo solo la domenica
            Dim TempD As Date = DataPartenza.AddDays(i)
            If TempD.DayOfWeek = DayOfWeek.Sunday Then
                DataProduzione = DataProduzione.AddDays(1)
            End If
        Next
        DataConsegna = CalcolaDataConsegna(DataProduzione, C)
        'If C.IdCorriere <> enCorriere.RitiroCliente Then
        '    If C.IdCorriere <> enCorriere.TipografiaFormer Then
        '        If DataProduzione.DayOfWeek = DayOfWeek.Saturday Then
        '            'qui se il corriere non e' nemmeno tipografia former controllo se la produzione finisce di sabato, siccome non ritirano sposto di un giorno
        '            DataConsegna = DataConsegna.AddDays(2)
        '        End If
        '    End If

        '    Dim GGAggiunti As Integer = 0

        '    Do Until GGAggiunti = C.GGConsegna
        '        DataConsegna = DataConsegna.AddDays(1)
        '        If DataConsegna.DayOfWeek <> DayOfWeek.Sunday And DataConsegna.DayOfWeek <> DayOfWeek.Saturday Then
        '            GGAggiunti += 1
        '        End If
        '    Loop

        'End If

    End Sub

    Public Function CalcolaDateConsegna(P As PreventivazioneW, C As CorriereW) As RisultatoDataConsegna

        Dim R As New RisultatoDataConsegna

        Dim DataPartenza As Date = Now.Date ' Now.AddDays(C.GGConsegna)

        If Now.Hour >= 18 Then DataPartenza = DataPartenza.AddDays(1)

        If P.ggFast Then
            CalcolaBloccoDate(DataPartenza, R.DataFastProduzione, R.DataFast, P.ggFast, C)
            'R.DataFast = DataPartenza.AddDays(P.ggFast)
            'For i = 1 To P.ggFast
            '    Dim TempD As Date = DataPartenza.AddDays(i)
            '    If TempD.DayOfWeek = DayOfWeek.Sunday Then
            '        R.DataFast = R.DataFast.AddDays(1)
            '    End If
            'Next
            'R.DataFastProduzione = R.DataFast
            'R.DataFast = R.DataFast.AddDays(C.GGConsegna)
            'Dim DayToAdd As Integer = 0
            'If C.IdCorriere <> enCorriere.RitiroCliente Then
            '    If R.DataFast.DayOfWeek = DayOfWeek.Saturday Then DayToAdd = 2
            'End If
            'If R.DataFast.DayOfWeek = DayOfWeek.Sunday Then DayToAdd = 1
            'If DayToAdd Then R.DataFast = R.DataFast.AddDays(DayToAdd)
        End If

        If P.ggNorm Then
            CalcolaBloccoDate(DataPartenza, R.DataNormaleProduzione, R.DataNormale, P.ggNorm, C)
            'R.DataNormale = DataPartenza.AddDays(P.ggNorm)
            'For i = 1 To P.ggNorm
            '    Dim TempD As Date = DataPartenza.AddDays(i)
            '    If TempD.DayOfWeek = DayOfWeek.Sunday Then
            '        R.DataNormale = R.DataNormale.AddDays(1)
            '    End If
            'Next
            'R.DataNormaleProduzione = R.DataNormale
            'R.DataNormale = R.DataNormale.AddDays(C.GGConsegna)
            'Dim DayToAdd As Integer = 0
            'If C.IdCorriere <> enCorriere.RitiroCliente Then
            '    If R.DataNormale.DayOfWeek = DayOfWeek.Saturday Then DayToAdd = 2
            'End If
            'If R.DataNormale.DayOfWeek = DayOfWeek.Sunday Then DayToAdd = 1
            'If DayToAdd Then R.DataNormale = R.DataNormale.AddDays(DayToAdd)
        End If

        If P.ggSlow Then
            CalcolaBloccoDate(DataPartenza, R.DataSlowProduzione, R.DataSlow, P.ggSlow, C)
            'R.DataSlow = DataPartenza.AddDays(P.ggSlow)
            'For i = 1 To P.ggSlow
            '    Dim TempD As Date = DataPartenza.AddDays(i)
            '    If TempD.DayOfWeek = DayOfWeek.Sunday Then
            '        R.DataSlow = R.DataSlow.AddDays(1)
            '    End If
            'Next
            'R.DataSlowProduzione = R.DataSlow
            'R.DataSlow = R.DataSlow.AddDays(C.GGConsegna)
            'Dim DayToAdd As Integer = 0
            'If C.IdCorriere <> enCorriere.RitiroCliente Then
            '    If R.DataSlow.DayOfWeek = DayOfWeek.Saturday Then DayToAdd = 2
            'End If
            'If R.DataSlow.DayOfWeek = DayOfWeek.Sunday Then DayToAdd = 1
            'If DayToAdd Then R.DataSlow = R.DataSlow.AddDays(DayToAdd)
        End If

        Return R

    End Function

End Class
