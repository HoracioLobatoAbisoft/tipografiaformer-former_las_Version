Imports FormerLib.FormerEnum
Imports FormerConfig
Imports Microsoft.VisualBasic

Public Class MgrDataConsegna

    Private Shared _ListaFestivita As New List(Of String)

    Shared Sub New()

        _ListaFestivita.Add("1-1") 'CAPODANNO
        _ListaFestivita.Add("6-1") 'EPIFANIA
        _ListaFestivita.Add("25-4") 'LIBERAZIONE
        _ListaFestivita.Add("1-5") 'LAVORO
        _ListaFestivita.Add("2-6") 'REPUBBLICA
        _ListaFestivita.Add("29-6") 'SAN PIETRO E PAOLO
        _ListaFestivita.Add("15-8") 'FERRAGOSTO
        _ListaFestivita.Add("1-11") 'TUTTI I SANTI
        _ListaFestivita.Add("8-12") 'IMMACOLATA
        _ListaFestivita.Add("25-12") 'NATALE
        _ListaFestivita.Add("26-12") 'SANTO STEFANO

        'PASQUETTA
        Dim DataPasquetta As Date = GetPasquetta()
        Dim DataPasquettaStr As String = DataPasquetta.Day & "-" & DataPasquetta.Month

        If _ListaFestivita.FindAll(Function(x) x = DataPasquettaStr).Count = 0 Then _ListaFestivita.Add(DataPasquettaStr) 'PASQUETTA

        'QUI QUELLE VARIABILI
        Dim FerieVariabili As String = String.Empty

        Try
            FerieVariabili = FConfiguration.Altro.GiorniFerie ' ConfigurationManager.AppSettings("GiorniFerie")

            If FerieVariabili.Length Then
                For Each singFerie As String In FerieVariabili.Split(";")

                    If _ListaFestivita.FindAll(Function(x) x = singFerie).Count = 0 Then _ListaFestivita.Add(singFerie)

                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function ConfermaDataConsegna(DataInserimento As Date,
                                                DataDaConfermare As Date,
                                                IdCorriere As Integer) As Date

        Dim DataRiferimento As Date = DataDaConfermare
        Dim ggDiff As Integer = DateDiff(DateInterval.Day, DataInserimento.Date, Now.Date)
        Dim ggPrevisti As Integer = DateDiff(DateInterval.Day, DataInserimento.Date, DataDaConfermare)
        If ggDiff > 0 Then

            Dim DataTemp As Date = DataInserimento
            Dim ggDaTogliere As Integer = 0

            For I As Integer = 1 To ggPrevisti
                DataTemp = DataTemp.AddDays(1)

                If MgrDataConsegna.IsFestivita(DataTemp) = True Then
                    ggDaTogliere += 1
                ElseIf DataTemp.DayOfWeek = DayOfWeek.Sunday Then
                    ggDaTogliere += 1
                ElseIf DataTemp.DayOfWeek = DayOfWeek.Saturday Then
                    'qui e' sabato 
                    'devo toglierlo solo se verra' tolto dal calcolo del posticipo 
                    If IdCorriere = enCorriere.TipografiaFormer Or IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
                        ggDaTogliere += 1
                    End If
                End If
            Next

            If ggDaTogliere Then
                ggPrevisti -= ggDaTogliere
            End If
            DataRiferimento = MgrDataConsegna.PosticipaDataConsegna(Now.Date, IdCorriere, ggPrevisti)
        End If

        If IdCorriere <> enCorriere.RitiroCliente And
               IdCorriere <> enCorriere.TipografiaFormer And
               IdCorriere <> enCorriere.TipografiaFormerFuoriRaccordo Then

            If DataRiferimento.DayOfWeek = DayOfWeek.Saturday Then
                DataRiferimento = MgrDataConsegna.GetPrimaDataDisponibile(DataRiferimento, IdCorriere)
            End If

        End If

        Return DataRiferimento

    End Function

    Private Shared Function GetPasquetta() As Date

        Dim ris As Date
        Dim Y As Integer = DateTime.Now.Year
        Dim M As Integer, N As Integer, A As Integer, B As Integer, C As Integer, D As Integer, E As Integer
        Dim ED As String
        M = 24 : N = 5
        A = Y Mod 19
        B = Y Mod 4
        C = Y Mod 7
        D = (19 * A + M) Mod 30
        E = (2 * B + 4 * C + 6 * D + N) Mod 7
        ED = 22 + D + E
        If ED <= 31 Then
            ED = ED & "/03/" & Y
        Else
            ED = D + E - 9 & "/04/" & Y
        End If
        ris = CDate(ED)

        ris = ris.AddDays(1)

        Return ris

    End Function

    'Public Shared Function PosticipaAProssimoGiornoUtile(DataOrig As Date, IdCorriere As Integer) As Date

    '    Dim ris As Date = DataOrig.AddDays(1)
    '    Dim esci As Boolean = False

    '    Do Until esci = True
    '        If IdCorriere = enCorriere.TipografiaFormer Or IdCorriere = enCorriere.RitiroCliente Or IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
    '            If IsFestivita(ris) = False And ris.DayOfWeek <> DayOfWeek.Sunday Then
    '                esci = True
    '            Else
    '                ris = ris.AddDays(1)
    '            End If
    '        Else
    '            If IsFestivita(ris) = False And ris.DayOfWeek <> DayOfWeek.Saturday And ris.DayOfWeek <> DayOfWeek.Sunday Then
    '                esci = True
    '            Else
    '                ris = ris.AddDays(1)
    '            End If
    '        End If
    '    Loop

    '    Return ris
    'End Function

    Public Shared Function GetPrimaDataDisponibile(DataStart As Date,
                                                   IdCorriere As Integer,
                                                   Optional ConsideraAncheDataStart As Boolean = False) As Date
        Dim DataNuova As Date = DataStart
        Dim DataTrovata As Boolean = False

        Do
            Select Case DataNuova.DayOfWeek
                Case DayOfWeek.Saturday
                    DataNuova = DataNuova.AddDays(2)
                Case DayOfWeek.Friday
                    If IdCorriere = enCorriere.RitiroCliente Then
                        DataNuova = DataNuova.AddDays(1)
                    Else
                        DataNuova = DataNuova.AddDays(3)
                    End If
                Case Else
                    If ConsideraAncheDataStart Then
                        If DataNuova <> DataStart OrElse IsFestivita(DataStart) = True Then
                            DataNuova = DataNuova.AddDays(1)
                        End If
                    Else
                        DataNuova = DataNuova.AddDays(1)
                    End If
            End Select

            If IsFestivita(DataNuova) = False Then
                DataTrovata = True
            End If

        Loop Until DataTrovata = True

        Return DataNuova

    End Function

    Public Shared Function CalcolaGiorniMancanti(DataPartenza As Date,
                                                 IdCorr As Integer,
                                                 DataFinoAl As Date) As String


        Dim ris As String = String.Empty

        Dim DataEnd As Date = DataFinoAl
        Dim DataEsaminata As Date = DataPartenza
        Dim OraRif As Integer = 14

        If IdCorr <> enCorriere.GLS And
           IdCorr <> enCorriere.GLSIsole And
           IdCorr <> enCorriere.PortoAssegnatoGLS Then

            If DataFinoAl.DayOfWeek = DayOfWeek.Saturday Then
                OraRif = 13
            Else
                OraRif = 19
            End If

        End If

        Dim DataFineGiornata As New Date(DataEnd.Year, DataEnd.Month, DataEnd.Day, OraRif, 0, 0)

        Dim DiffOre As Integer = DateDiff(DateInterval.Hour, DataEsaminata, DataFineGiornata)
        'If DiffOre < 0 Then DiffOre = 0

        Dim DiffGiorni As Integer = 0
        If DataEsaminata < DataEnd Then
            Do Until DataEsaminata > DataEnd
                DataEsaminata = DataEsaminata.AddDays(1)

                If DataEsaminata.DayOfWeek <> DayOfWeek.Sunday AndAlso MgrDataConsegna.IsFestivita(DataEsaminata) = False Then
                    DiffGiorni += 1
                End If
            Loop
        Else
            DiffGiorni = DateDiff(DateInterval.Day, DataEsaminata, DataEnd)
        End If


        'If DiffOre = 0 And DiffGiorni = 0 Then
        '    Dim Differenza As Integer = 0
        '    Differenza = DateDiff(DateInterval.Day, Date.Now, DataPartenza)

        '    Dim DiffOrig As Integer = 0
        '    DiffOrig = DateDiff(DateInterval.Day, Date.Now, DataFinoAl)

        '    If DiffOrig < Differenza Then
        '        ris = DiffOrig & "g"
        '    Else
        '        ris = Differenza & "g"
        '    End If

        '    'If Differenza = 0 Then
        '    '    ris = "Scade Oggi"
        '    'Else
        '    '    ris = "Scaduto da " & Math.Abs(Differenza) & "g"
        '    'End If

        'Else
        If DiffGiorni = 0 Then
            ris = "Oggi alle " & OraRif
        ElseIf DiffGiorni = 1 Then
            ris = "Domani alle " & OraRif
        ElseIf DiffGiorni < 0 Then
            ris = "Scaduto da " & Math.Abs(DiffGiorni) & "g"
        ElseIf DiffGiorni > 1 Then
            ris = "Scade tra " & DiffGiorni & "g"
        End If

        'If DiffGiorni Then
        '    ris = DiffGiorni & "g"
        'End If

        'If DiffOre Then
        '    If Math.Abs(DiffOre) > 24 Then
        '        DiffOre = DiffOre \ 24
        '    End If
        '    ris &= IIf(ris.Length, ",", "") & DiffOre & "h" '
        'End If
        'End If
        Return ris

    End Function

    Public Shared Function IsFestivita(Data As Date) As Boolean
        Dim ris As Boolean = False

        For Each singData As String In _ListaFestivita
            Dim Giorno As Integer = 0
            Dim Mese As Integer = 0

            Dim GiornoData As String() = singData.Split("-")
            Giorno = GiornoData(0)
            Mese = GiornoData(1)

            If Data.Day = Giorno And Data.Month = Mese Then
                ris = True
                Exit For
            End If
        Next

        Return ris
    End Function

    Public Shared Function PosticipaDataConsegna(DataOrig As Date,
                                                 IdCorriere As Integer,
                                                 ggToAdd As Integer) As Date

        Dim ris As Date = DataOrig
        Dim ggAggiunti As Integer = 0

        If DataOrig.Hour >= 18 Then
            ggAggiunti -= 1
        End If

        Do Until ggAggiunti = ggToAdd
            ris = ris.AddDays(1)
            If IsFestivita(ris) = False Then
                If ris.DayOfWeek <> DayOfWeek.Sunday Then
                    If ris.DayOfWeek = DayOfWeek.Saturday Then
                        If IdCorriere = enCorriere.TipografiaFormer Or 
                           IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
                            ggAggiunti += 1
                        End If
                    Else
                        ggAggiunti += 1
                    End If
                End If
            End If
        Loop

        Return ris

    End Function

    Public Shared Function CalcolaDataConsegna(DataProduzione As Date,
                                               C As ICorriereBusiness) As Date

        Dim DataConsegna As Date = DataProduzione

        If C.IdCorriere <> enCorriere.RitiroCliente Then
            If C.IdCorriere <> enCorriere.TipografiaFormer Then
                If DataProduzione.DayOfWeek = DayOfWeek.Saturday Then
                    'qui se il corriere non e' nemmeno tipografia former controllo se la produzione finisce di sabato, 
                    'siccome non ritirano sposto di un giorno
                    DataConsegna = DataConsegna.AddDays(2)
                End If
            End If

            Dim GGAggiunti As Integer = 0
            Do Until GGAggiunti = C.GGConsegna
                DataConsegna = DataConsegna.AddDays(1)
                If DataConsegna.DayOfWeek <> DayOfWeek.Sunday And
                   DataConsegna.DayOfWeek <> DayOfWeek.Saturday And
                   IsFestivita(DataConsegna) = False Then
                    GGAggiunti += 1
                End If
            Loop

        End If

        Return DataConsegna

    End Function

    Private Shared Sub CalcolaBloccoDate(ByVal DataPartenza As Date, _
                                  ByRef DataProduzione As Date, _
                                  ByRef DataConsegna As Date, _
                                  ggProduzione As Integer, _
                                  ggLavorazioni As Integer, _
                                  C As ICorriereBusiness)

        'DataProduzione = DataPartenza.AddDays(ggProduzione)

        Dim ggAggiunti As Integer = 0
        Dim TempD As Date = DataPartenza
        Do Until ggAggiunti = ggProduzione
            TempD = TempD.AddDays(1)
            If IsFestivita(TempD) = False Then
                If TempD.DayOfWeek <> DayOfWeek.Sunday Then
                    ggAggiunti += 1
                End If
            End If
        Loop
        'quando arrivo qui in tempD ho la data produzione
        DataProduzione = TempD

        'For i = 1 To ggProduzione 'per la produzione escludo solo la domenica
        '    Dim TempD As Date = DataPartenza.AddDays(i)
        '    If IsFestivita(TempD) = True Then
        '        DataProduzione = DataProduzione.AddDays(1)
        '        If DataProduzione.DayOfWeek = DayOfWeek.Sunday Then
        '            DataProduzione = DataProduzione.AddDays(1)
        '        End If
        '    ElseIf TempD.DayOfWeek = DayOfWeek.Sunday Then
        '        DataProduzione = DataProduzione.AddDays(1)
        '    End If
        'Next

        If ggLavorazioni Then
            ggAggiunti = 0
            TempD = DataProduzione
            Do Until ggAggiunti = ggProduzione
                TempD = TempD.AddDays(1)
                If IsFestivita(TempD) = False Then
                    If TempD.DayOfWeek <> DayOfWeek.Sunday Then
                        ggAggiunti += 1
                    End If
                End If
            Loop
            DataProduzione = TempD
            'Dim DataPreProduzione As Date = DataProduzione
            'DataProduzione = DataProduzione.AddDays(ggLavorazioni)
            'For i = 1 To ggLavorazioni 'per la produzione escludo solo la domenica
            '    Dim TempD As Date = DataPreProduzione.AddDays(i)
            '    If TempD.DayOfWeek = DayOfWeek.Saturday Then
            '        DataProduzione = DataProduzione.AddDays(2)
            '    ElseIf TempD.DayOfWeek = DayOfWeek.Sunday Or IsFestivita(TempD) = True Then
            '        DataProduzione = DataProduzione.AddDays(1)
            '    End If
            'Next
        End If

        If DataProduzione.DayOfWeek = DayOfWeek.Saturday Then
            'qui se la data di produzione e' il sabato allora devo avanzare al lunedi
            If C.IdCorriere <> enCorriere.RitiroCliente And
               C.IdCorriere <> enCorriere.TipografiaFormer And
               C.IdCorriere <> enCorriere.TipografiaFormerFuoriRaccordo Then
                DataProduzione = DataProduzione.AddDays(2)
            End If
        End If

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

    Public Shared Function GetProssimoGiornoLavorativo(DataPartenza As Date) As Date

        Dim ris As Date = DataPartenza

        ris = ris.AddDays(1)
        Dim esci As Boolean = False

        While esci = False
            If IsFestivita(ris) = False AndAlso ris.DayOfWeek <> DayOfWeek.Sunday Then
                esci = True
            Else
                ris = ris.AddDays(1)
            End If
        End While

        Return ris
    End Function

    Public Shared Function CalcolaDateConsegna(P As IPreventivazioneB,
                                        C As ICorriereBusiness,
                                        L As List(Of ILavorazioneB),
                                        Optional DataPartenzaCalcolo As Date = Nothing) As RisDataConsegna

        Dim R As New RisDataConsegna

        If DataPartenzaCalcolo = Date.MinValue Then
            DataPartenzaCalcolo = DateTime.Now.Date
        End If

        Dim DataPartenza As Date = DataPartenzaCalcolo 'DateTime.Now.Date ' Now.AddDays(C.GGConsegna)

        Dim ggLavorazioni As Integer = 0
        If Not L Is Nothing Then
            For Each singLav As ILavorazioneB In L
                ggLavorazioni += singLav.ggRealiz
            Next
        End If

        If DateTime.Now.DayOfWeek = DayOfWeek.Saturday Then
            'se ordini di sabato tanto sposto la data di partenza al lunedi se non e' festa
            DataPartenza = GetProssimoGiornoLavorativo(DateTime.Now)
        ElseIf DateTime.Now.DayOfWeek = DayOfWeek.Sunday Then
            'se ordini di domenica tanto sposto la data di partenza al lunedi se non e' festa
            DataPartenza = GetProssimoGiornoLavorativo(DateTime.Now)
        Else
            If DateTime.Now.Hour >= 18 Then DataPartenza = DataPartenza.AddDays(1)
        End If

        If P.ggFast Then
            CalcolaBloccoDate(DataPartenza, R.DataFastProduzione, R.DataFast, P.ggFast, ggLavorazioni, C)
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
            CalcolaBloccoDate(DataPartenza, R.DataNormaleProduzione, R.DataNormale, P.ggNorm, ggLavorazioni, C)
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
            CalcolaBloccoDate(DataPartenza, R.DataSlowProduzione, R.DataSlow, P.ggSlow, ggLavorazioni, C)
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
