Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class CommessaProposta

    Public Property Id As Integer = 0

    Public Property Tiratura As Integer = 0
    Public Property ModelloCommessa As New ModelloCommessa
    Public Property Ordini As New List(Of OrdineInSoluzione)
    Public Property Rielaborata As Boolean = False

    Public ReadOnly Property TiraturaEffettiva As Integer
        Get
            Dim ris As Integer = Tiratura

            If ModelloCommessa.FRSuSeStessa = enSiNo.Si Then
                ris = ris / 2
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TiraturaStr As String
        Get
            Dim ris As String = TiraturaEffettiva

            Return ris
        End Get
    End Property

    Public ReadOnly Property FormatiCartaTrovati As Integer
        Get
            Dim NumFC As New List(Of Integer)
            For Each O As OrdineInSoluzione In Ordini
                If NumFC.FindAll(Function(x) x = O.IDFormatoCartaRif).Count = 0 Then
                    NumFC.Add(O.IDFormatoCartaRif)
                End If
            Next
            Return NumFC.Count
        End Get
    End Property
    Public ReadOnly Property FormatiCartaPrevisti As Integer
        Get
            Return ModelloCommessa.FormatiCarta.Count '  NumeroFormatiContenuti
        End Get
    End Property

    Public Property MiglioreDiQuante As Integer
    Public Property DaScartare As Boolean = False

    Public ReadOnly Property QtaMinimaDagliOrdini As Integer
        Get
            Dim ris As Integer = 100000000

            For Each O As OrdineInSoluzione In Ordini
                If ris > O.Ordine.ListinoBase.qta1 Then
                    ris = O.Ordine.ListinoBase.qta1
                End If
            Next

            Return ris
        End Get
    End Property

    Public ReadOnly Property Firma As String
        Get

            Dim ris As String = ModelloCommessa.IdModello & "-"

            Ordini.Sort(Function(x, y) x.IdOrd.CompareTo(y.IdOrd))

            For Each o As OrdineInSoluzione In Ordini
                ris &= o.IdOrd & ","
            Next
            ris = ris.TrimEnd(",")

            If Ordini.Count <> 1 AndAlso ModelloCommessa.FormatiProdotto.Count <> 1 Then
                ris &= "-" & Tiratura
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleUrgenza As Integer
        Get
            Dim ris As Integer = 0

            For Each o As OrdineInSoluzione In Ordini

                ris += DateDiff(DateInterval.Day, Now, o.Ordine.DataPrevProduzione)

            Next

            Return ris
        End Get
    End Property

    Public Function DaPreferireA(C As CommessaProposta) As Boolean
        Dim ris As Boolean = False

        If PercentualeCompletamento > C.PercentualeCompletamento Then
            ris = True
        ElseIf PercentualeCompletamento = C.PercentualeCompletamento Then
            If Ordini.Count > C.Ordini.Count Then
                ris = True
            ElseIf Ordini.Count = C.Ordini.Count Then
                If NumeroFormatiContenuti > C.NumeroFormatiContenuti Then
                    ris = True
                ElseIf NumeroFormatiContenuti = C.NumeroFormatiContenuti Then
                    If ModelloCommessa.NumSpazi > C.ModelloCommessa.NumSpazi Then
                        ris = True
                    ElseIf ModelloCommessa.NumSpazi = C.ModelloCommessa.NumSpazi Then
                        If CostoLastre() < C.CostoLastre Then
                            ris = True
                        ElseIf CostoLastre() = C.CostoLastre Then
                            If Tiratura > C.Tiratura Then
                                ris = True
                            ElseIf Tiratura = C.Tiratura Then
                                If ConPiuOrdiniTiratiAlGiusto > C.ConPiuOrdiniTiratiAlGiusto Then
                                    ris = True
                                ElseIf ConPiuOrdiniTiratiAlGiusto = C.ConPiuOrdiniTiratiAlGiusto Then
                                    'qui devo prendere prima quelle con piu ordini urgenti
                                    If TotaleUrgenza < C.TotaleUrgenza Then
                                        ris = True
                                    ElseIf TotaleUrgenza = C.TotaleUrgenza Then
                                        If C.NumeroClienti > NumeroClienti Then
                                            ris = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return ris
    End Function

    Public ReadOnly Property CostoCarta As Decimal
        Get
            Dim ris As Decimal = 0

            Try
                Using tc As TipoCarta = Ordini(0).Ordine.ListinoBase.TipoCarta
                    Using fm As New Formato
                        fm.Read(ModelloCommessa.IdFormatoMacchina)

                        Dim Altezza As Integer = 0
                        Dim Larghezza As Integer = 0

                        Altezza = fm.Altezza
                        Larghezza = fm.Larghezza

                        Dim fattore As Double = (Larghezza * Altezza * CDbl(tc.Grammi) * Tiratura) / 10000000
                        ris = fattore * tc.CostoCartaKg
                    End Using
                End Using
            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

    Public ReadOnly Property AreaStampata As Integer
        Get
            Dim ris As Integer = 0

            For Each fp As ModComFormProd In ModelloCommessa.FormatiProdotto
                Using f As New FormatoProdotto
                    f.Read(fp.IdFormProd)
                    ris += (f.AreaCmQuadrati * fp.Spazi)
                End Using
            Next

            Return ris
        End Get
    End Property

    Public Function DaPreferireAV4(C As CommessaProposta) As Boolean
        Dim ris As Boolean = False

        Dim PunteggioCommessa As Integer = 0
        Dim PunteggioCommessaProposta As Integer = 0

        Dim Diff As Integer = 0
        Dim DiffPerc As Integer = 0
        Diff = Math.Abs(AreaStampata - C.AreaStampata)

        If AreaStampata > C.AreaStampata Then
            DiffPerc = (C.AreaStampata * 3) / 100
            If Diff > DiffPerc Then PunteggioCommessa += MgrRegoleCalcolo.PESO_AreaStampataMaggiore
        ElseIf AreaStampata < C.AreaStampata Then
            DiffPerc = (AreaStampata * 3) / 100
            If Diff > DiffPerc Then PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_AreaStampataMaggiore
        End If

        If C.ModelloCommessa.IdMacchinarioDef = ModelloCommessa.IdMacchinarioDef AndAlso
                PercentualeCompletamento = C.PercentualeCompletamento AndAlso
                C.Tiratura = Tiratura Then
            If NumeroFormatiContenuti < C.NumeroFormatiContenuti Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_NumeroFormatiContenutiMaggiore
            ElseIf NumeroFormatiContenuti > C.NumeroFormatiContenuti Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_NumeroFormatiContenutiMaggiore
            End If

            If HaTiraturaOttimale Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_TiraturaOttimale
            End If
            If C.HaTiraturaOttimale Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_TiraturaOttimale
            End If
            If Ordini.Count = C.Ordini.Count Then
                If TotaleUrgenza > C.TotaleUrgenza Then
                    PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_TotaleUrgenzaMaggiore
                ElseIf TotaleUrgenza < C.TotaleUrgenza Then
                    PunteggioCommessa += MgrRegoleCalcolo.PESO_TotaleUrgenzaMaggiore
                End If
                If NumeroClienti < C.NumeroClienti Then
                    PunteggioCommessa += MgrRegoleCalcolo.PESO_NumeroClientiContenutiMinore
                ElseIf NumeroClienti > C.NumeroClienti Then
                    PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_NumeroClientiContenutiMinore
                End If

            End If


            If Ordini.Count > C.Ordini.Count Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_NumeroOrdineContenutiMaggiore
            ElseIf Ordini.Count < C.Ordini.Count Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_NumeroOrdineContenutiMaggiore
            End If


        Else
            Dim CostoProcapite As Decimal = 0
            Dim CostoProcapiteC As Decimal = 0

            ''calcolo il costo delle lastre
            CostoProcapite = CostoLastre()
            CostoProcapiteC = C.CostoLastre()

            ''calcolo il costo della carta

            'CostoProcapite += CostoCarta
            'CostoProcapiteC += C.CostoCarta

            ''divido per il numero di ordini contenuti nella commessa
            CostoProcapite = CostoProcapite / Ordini.Count
            CostoProcapiteC = CostoProcapiteC / C.Ordini.Count

            If CostoProcapite < CostoProcapiteC Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_CostoOrdine
            ElseIf CostoProcapite > CostoProcapiteC Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_CostoOrdine
            End If

            PunteggioCommessa += PercentualeCompletamento
            PunteggioCommessaProposta += C.PercentualeCompletamento
            'If PercentualeCompletamento > C.PercentualeCompletamento Then
            '    PunteggioCommessa += PESO_PercentualeCompletamento
            'ElseIf PercentualeCompletamento < C.PercentualeCompletamento Then
            '    PunteggioCommessaProposta += PESO_PercentualeCompletamento
            'End If

            If ConPiuOrdiniTiratiAlGiusto > C.ConPiuOrdiniTiratiAlGiusto Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_ConPiuOrdiniTiratiAlGiusto
            ElseIf ConPiuOrdiniTiratiAlGiusto < C.ConPiuOrdiniTiratiAlGiusto Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_ConPiuOrdiniTiratiAlGiusto
            End If

            If PercentualeOrdiniContenuti > C.PercentualeOrdiniContenuti Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_NumeroOrdineContenutiMaggiore
            ElseIf PercentualeOrdiniContenuti < C.PercentualeOrdiniContenuti Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_NumeroOrdineContenutiMaggiore
            End If

            If NumeroFormatiContenuti < C.NumeroFormatiContenuti Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_NumeroFormatiContenutiMaggiore
            ElseIf NumeroFormatiContenuti > C.NumeroFormatiContenuti Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_NumeroFormatiContenutiMaggiore
            End If

            If ModelloCommessa.NumSpazi > C.ModelloCommessa.NumSpazi Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_NumeroSpaziContenutiNelModelloCommessaMaggiore
            ElseIf ModelloCommessa.NumSpazi < C.ModelloCommessa.NumSpazi Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_NumeroSpaziContenutiNelModelloCommessaMaggiore
            End If

            If HaTiraturaOttimale Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_TiraturaOttimale
            End If
            If C.HaTiraturaOttimale Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_TiraturaOttimale
            End If
            If Ordini.Count = C.Ordini.Count Then
                If TotaleUrgenza < C.TotaleUrgenza Then
                    PunteggioCommessa += MgrRegoleCalcolo.PESO_TotaleUrgenzaMaggiore
                ElseIf TotaleUrgenza > C.TotaleUrgenza Then
                    PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_TotaleUrgenzaMaggiore
                End If

                If NumeroClienti < C.NumeroClienti Then
                    PunteggioCommessa += MgrRegoleCalcolo.PESO_NumeroClientiContenutiMinore
                ElseIf NumeroClienti > C.NumeroClienti Then
                    PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_NumeroClientiContenutiMinore
                End If
            End If

            If UsaMacchinarioIdealePerPreventivazione Then
                PunteggioCommessa += MgrRegoleCalcolo.PESO_MacchinarioIdealePerProdotto
            End If
            If C.UsaMacchinarioIdealePerPreventivazione Then
                PunteggioCommessaProposta += MgrRegoleCalcolo.PESO_MacchinarioIdealePerProdotto
            End If
        End If

        'CONFRONTO FINALE
        If PunteggioCommessa > PunteggioCommessaProposta Then
            ris = True
        End If

        Return ris
    End Function

    Public ReadOnly Property UsaMacchinarioIdealePerPreventivazione As Boolean
        Get
            Dim ris As Boolean = False

            Dim IdMacchDaModello As Integer = 0

            IdMacchDaModello = ModelloCommessa.IdMacchinarioDef

            If IdMacchDaModello Then
                Dim IdMacchDaPrev As Integer = 0

                Dim LP As New List(Of Integer)

                For Each o As OrdineInSoluzione In Ordini

                    'Dim IdMacc As Integer = o.Ordine.ListinoBase.Preventivazione.IdMacchinario 'IDMACCHINARIO
                    Dim IdMacc As Integer = o.Ordine.ListinoBase.IdMacchinarioProduzione

                    If LP.FindAll(Function(x) x = IdMacc).Count = 0 Then LP.Add(IdMacc)

                Next

                If LP.Count = 1 AndAlso LP(0) <> 0 Then
                    If IdMacchDaModello = LP(0) Then
                        ris = True
                    End If
                End If

            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property HaTiraturaOttimale As Boolean
        Get
            Dim ris As Boolean = False

            Dim TiraturaOttimale As Integer = 0

            If ModelloCommessa.TiraturaIdeale Then
                'qui vedo se sta alla quantita ideale per il modello commessa

                TiraturaOttimale = ModelloCommessa.TiraturaIdeale
            Else
                'calcolo la tiratura ottimale

                Dim L As New List(Of ListinoBase)
                For Each O As OrdineInSoluzione In Ordini
                    If L.FindAll(Function(X) X.IdListinoBase = O.Ordine.IdListinoBase).Count = 0 Then
                        L.Add(O.Ordine.ListinoBase)
                    End If
                Next

                For Each Lb As ListinoBase In L
                    Dim tiratOttimTemp As Integer = 0
                    Dim VoceDaSelezionare As Integer = 3
                    If Lb.QtaDefault <> 0 Then
                        VoceDaSelezionare = Lb.QtaDefault
                    End If

                    If VoceDaSelezionare Then
                        Select Case VoceDaSelezionare
                            Case 1
                                tiratOttimTemp = Lb.qta1
                            Case 2
                                tiratOttimTemp = Lb.qta2
                            Case 3
                                tiratOttimTemp = Lb.qta3
                            Case 4
                                tiratOttimTemp = Lb.qta4
                            Case 5
                                tiratOttimTemp = Lb.qta5
                            Case 6
                                tiratOttimTemp = Lb.qta6
                        End Select
                    End If
                    If TiraturaOttimale = 0 Then
                        TiraturaOttimale = tiratOttimTemp
                    Else
                        If TiraturaOttimale <> tiratOttimTemp Then
                            TiraturaOttimale = 0
                            Exit For
                        End If
                    End If
                Next

            End If

            If Tiratura = TiraturaOttimale Then ris = True
            Return ris
        End Get
    End Property

    Public Function DaPreferireAEx(C As CommessaProposta) As Boolean
        Dim ris As Boolean = False

        If PercentualeCompletamento > C.PercentualeCompletamento Then
            ris = True
        ElseIf PercentualeCompletamento = C.PercentualeCompletamento Then
            If ConPiuOrdiniTiratiAlGiusto > C.ConPiuOrdiniTiratiAlGiusto Then
                ris = True
            ElseIf ConPiuOrdiniTiratiAlGiusto = C.ConPiuOrdiniTiratiAlGiusto Then
                If Ordini.Count > C.Ordini.Count Then
                    ris = True
                ElseIf Ordini.Count = C.Ordini.Count Then
                    If NumeroFormatiContenuti > C.NumeroFormatiContenuti Then
                        ris = True
                    ElseIf NumeroFormatiContenuti = C.NumeroFormatiContenuti Then
                        If ModelloCommessa.NumSpazi > C.ModelloCommessa.NumSpazi Then
                            ris = True
                        ElseIf ModelloCommessa.NumSpazi = C.ModelloCommessa.NumSpazi Then
                            If CostoLastre() < C.CostoLastre Then
                                ris = True
                            ElseIf CostoLastre() = C.CostoLastre Then
                                If Tiratura > C.Tiratura Then
                                    ris = True
                                ElseIf Tiratura = C.Tiratura Then
                                    If TotaleUrgenza < C.TotaleUrgenza Then
                                        ris = True
                                    ElseIf TotaleUrgenza = C.TotaleUrgenza Then
                                        If C.NumeroClienti > NumeroClienti Then
                                            ris = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        End If

        Return ris
    End Function


    'Public Function DaPreferireA(C As CommessaProposta) As Boolean
    '    Dim ris As Boolean = False

    '    If PercentualeCompletamento > C.PercentualeCompletamento Then
    '        ris = True
    '    ElseIf PercentualeCompletamento = C.PercentualeCompletamento Then
    '        If Tiratura > C.Tiratura Then
    '            ris = True
    '        ElseIf Tiratura = C.Tiratura Then
    '            If ConPiuOrdiniTiratiAlGiusto > C.ConPiuOrdiniTiratiAlGiusto Then
    '                ris = True
    '            ElseIf ConPiuOrdiniTiratiAlGiusto = C.ConPiuOrdiniTiratiAlGiusto Then
    '                If Ordini.Count > C.Ordini.Count Then
    '                    ris = True
    '                ElseIf Ordini.Count = C.Ordini.Count Then
    '                    If TotaleUrgenza < C.TotaleUrgenza Then
    '                        ris = True
    '                    ElseIf TotaleUrgenza = C.TotaleUrgenza Then
    '                        If NumeroFormatiContenuti > C.NumeroFormatiContenuti Then
    '                            ris = True
    '                        ElseIf NumeroFormatiContenuti = C.NumeroFormatiContenuti Then
    '                            If ModelloCommessa.NumSpazi > C.ModelloCommessa.NumSpazi Then
    '                                ris = True
    '                            ElseIf ModelloCommessa.NumSpazi = C.ModelloCommessa.NumSpazi Then
    '                                If CostoLastre() < C.CostoLastre Then
    '                                    ris = True
    '                                ElseIf CostoLastre() = C.CostoLastre Then
    '                                    If C.NumeroClienti > NumeroClienti Then
    '                                        ris = True
    '                                    End If
    '                                End If
    '                            End If
    '                        End If
    '                    End If

    '                End If
    '            End If
    '        End If
    '    End If

    '    Return ris
    'End Function

    Public Function ProporzioneCommessaRielaborabile() As Single
        Dim Ris As Single = 0
        Dim Proporzione As Single = 0
        If PercentualeCompletamento < 100 Then
            If SpaziDisponibiliTot > 1 Then
                For Each Fc As FormatoCarta In ModelloCommessa.FormatiCarta
                    If Proporzione = 0 Then
                        Proporzione = Math.Floor(SpaziDisponibili(Fc.IdFormCarta) / SpaziUsati(Fc.IdFormCarta))
                        If Single.IsInfinity(Proporzione) = False Then Ris = Proporzione
                    End If
                    Dim ProporzioneCommessa As Single = Math.Floor(SpaziDisponibili(Fc.IdFormCarta) / SpaziUsati(Fc.IdFormCarta))
                    If Proporzione <> ProporzioneCommessa Then Ris = 0
                Next
            End If
        End If
        Return Ris
    End Function

    Public ReadOnly Property NomeCorto As String
        Get
            Dim ris As String = String.Empty
            Dim LimiteMax As Integer = 25

            If Ordini.Count = 1 Then
                Dim NomeLb As String = Ordini(0).Ordine.ListinoBase.Nome

                If NomeLb.Length > LimiteMax Then
                    NomeLb = NomeLb.Substring(0, LimiteMax) & "..."
                End If
                ris = NomeLb
            Else

                Dim Lc As New List(Of Integer)

                For Each o As OrdineInSoluzione In Ordini
                    If Lc.FindAll(Function(x) x = o.Ordine.IdListinoBase).Count = 0 Then
                        Lc.Add(o.Ordine.IdListinoBase)
                    End If
                Next

                If Lc.Count = 1 Then
                    Dim NomeLb As String = Ordini(0).Ordine.ListinoBase.Nome

                    If NomeLb.Length > LimiteMax Then
                        NomeLb = NomeLb.Substring(0, LimiteMax) & "..."
                    End If
                    ris = NomeLb
                Else
                    For Each o As OrdineInSoluzione In Ordini
                        Dim NomePrev As String = o.Ordine.ListinoBase.Preventivazione.Descrizione
                        If ris.IndexOf(NomePrev) = -1 Then ris &= NomePrev & ", "
                    Next
                End If
            End If

            'If ris.Length > 2 Then ris = ris.Substring(0, ris.Length - 2)

            ris &= " ("
            For Each fc As FormatoCarta In ModelloCommessa.FormatiCarta
                ris &= SpaziDisponibili(fc.IdFormCarta) & " - " & fc.FormatoCarta & ", "
            Next
            ris = ris.Substring(0, ris.Length - 2)
            ris &= ")"
            Return ris
        End Get
    End Property

    Public ReadOnly Property Riassunto(Optional WithPerc As Boolean = True) As String
        Get
            Dim ris As String = String.Empty
            ris = Ordini.Count & " "

            'ris &= "AREA STAMPATA: " & AreaStampata & " "
            If WithPerc Then
                'If Not ((PercentualeCompletamento = 100 And Rielaborata = False) Or
                '        (PercentualeCompletamento = 100 And Rielaborata = True And ModelloCommessa.RitieniOkDuplicati = enSiNo.Si)) Then
                ris &= "(" & PercentualeCompletamento & "%) - "
                'End If
            End If

            ris &= NomeCorto

            ris &= " " & TiraturaStr & "fg " & MacchinarioStr & " Spz Disp: " & SpaziDisponibiliTot & " Spz Util: " & SpaziUsatiTot

            Return ris
        End Get
    End Property

    Private Function CalcolaLastreNecessarie() As Integer

        Dim NumLastre As Integer = 1

        Dim m As ModelloCommessa = ModelloCommessa

        Dim NumFacciate As Integer = 2
        Dim NoImpiantiSuFacc As enSiNo = enSiNo.No

        Dim AlmenoUnOrdineFR As Boolean = False

        For Each singO In Ordini
            If singO.Ordine.Prodotto.ListinoBase.ColoreStampa.NLastre > NumLastre Then
                NumLastre = singO.Ordine.Prodotto.ListinoBase.ColoreStampa.NLastre
            End If

            If singO.Ordine.Prodotto.NumFacciate > NumFacciate Then
                NumFacciate = singO.Ordine.Prodotto.NumFacciate
            End If

            If singO.Ordine.Prodotto.NoImpiantiSuFacciate = enSiNo.Si Then
                NoImpiantiSuFacc = enSiNo.Si
            End If

            If singO.Ordine.ListinoBase.ColoreStampa.FR Then
                AlmenoUnOrdineFR = True
            End If
        Next

        If NumFacciate <> 2 And NoImpiantiSuFacc = enSiNo.No Then
            'qui devo andare a fare il calcolo giusto delle facciate su impianti 

            Dim NumFogli As Integer = NumFacciate / 2

            Dim RisTemp As Integer = (NumFogli * NumLastre) / m.NumSpazi

            NumLastre = RisTemp

        End If

        If AlmenoUnOrdineFR = True AndAlso m.FRSuSeStessa = enSiNo.Si Then
            NumLastre /= 2
        End If

        Return NumLastre

    End Function

    Public ReadOnly Property MacchinarioStr As String
        Get
            Dim ris As String = String.Empty
            Dim PosPrimoSpazio As Integer = MacchinarioScelto.Descrizione.IndexOf(" ")
            If PosPrimoSpazio <> -1 Then
                ris = MacchinarioScelto.Descrizione.Substring(0, PosPrimoSpazio)
            Else
                ris = MacchinarioScelto.Descrizione
            End If
            Return ris
        End Get
    End Property

    Private _MacchinarioScelto As Macchinario = Nothing
    Public ReadOnly Property MacchinarioScelto As Macchinario
        Get

            If _MacchinarioScelto Is Nothing Then

                _MacchinarioScelto = New Macchinario
                _MacchinarioScelto.Read(ModelloCommessa.IdMacchinarioDef)

            End If

            Return _MacchinarioScelto
        End Get
    End Property

    Public ReadOnly Property NLastreNecessarie As Integer
        Get
            Return CalcolaLastreNecessarie()
        End Get
    End Property

    Public Function CostoLastre() As Decimal

        Dim ris As Decimal = 0

        Dim NumLastre As Integer = NLastreNecessarie
        Dim IdMacchinarioScelto As Integer = ModelloCommessa.IdMacchinarioDef
        Dim valoreDefault As Decimal = 10000
        Dim CostoLastra As Decimal = valoreDefault

        Using mgr As New RisorseSuMacchinaDAO

            Dim l As List(Of RisorsaSuMacchina) = mgr.FindAll(New LUNA.LunaSearchParameter("IdMacchinario", IdMacchinarioScelto))

            'qui prendo le risorse per macchinario e trovo la piu economica tra le compatibili 

            For Each s As RisorsaSuMacchina In l

                Using r As New Risorsa
                    r.Read(s.IdRisorsa)
                    If r.IsLastra = True Then 'scontato ma non si sa mai
                        If r.CostoTotale < CostoLastra Then
                            CostoLastra = r.CostoTotale
                        End If
                    End If
                End Using

            Next

        End Using

        If CostoLastra = valoreDefault Then CostoLastra = 1

        'Using mgr As New RisorseDAO
        '    Dim l As List(Of Risorsa) = mgr.FindAll("Giacenza Desc", _
        '                                            New LUNA.LunaSearchParameter("IsLastra", enSiNo.Si), _
        '                                            New LUNA.LunaSearchParameter("NLastre", NumLastre))
        '    For Each singRis As Risorsa In l
        '        If singRis.ListaMacchinari.FindAll(Function(x) x.IdMacchinario = ModelloCommessa.IdMacchinarioDef).Count Then
        '            ris = singRis.CostoTotale
        '            Exit For
        '        End If
        '    Next
        'End Using

        ris = NumLastre * CostoLastra

        Return ris

    End Function

    ''Public Function CostoLastre() As Decimal

    ''    Dim ris As Decimal = 0

    ''    For Each o In Ordini

    ''        Dim L As ListinoBase = o.Ordine.Prodotto.ListinoBase

    ''        Dim ResaInt As Integer = L.Resa.Resa
    ''        If L.noResa Then
    ''            ResaInt = 1
    ''        End If

    ''        Dim MoltiplF As Integer = o.Ordine.Nfogli 'NumFacc / 2

    ''        If L.IdTipoCartaDorso = 0 Then
    ''            If L.IdTipoCartaCop Then MoltiplF -= 2
    ''        End If

    ''        If L.nofaccsuimpianti Then MoltiplF = 1

    ''        ris = L.Formato.CostoLastra * ((L.ColoreStampa.NLastre * MoltiplF) / ResaInt)

    ''        'IMPIANTI COPERTINA
    ''        If L.IdTipoCartaCop Then
    ''            Dim MoltiplFCop As Integer = 1
    ''            If L.IdTipoCartaDorso = 0 Then MoltiplFCop = 2

    ''            ris += L.Formato.CostoLastra * ((L.ColoreStampa.NLastre * MoltiplFCop) / ResaInt)
    ''        End If

    ''    Next

    ''    Return ris

    ''End Function

    Public ReadOnly Property NumeroClienti As Integer
        Get
            Dim ris As Integer = 0
            Dim ListaIdRub As New List(Of Integer)

            For Each o As OrdineInSoluzione In Ordini
                If ListaIdRub.FindAll(Function(x) x = o.Ordine.IdRub).Count = 0 Then
                    ListaIdRub.Add(o.Ordine.IdRub)
                End If
            Next
            ris = ListaIdRub.Count
            Return ris
        End Get
    End Property

    Public ReadOnly Property MediaTiraturaSuTiratoA As Single
        Get
            Dim ris As Single = 0

            'calcolo la tiratura media
            Dim Tot As Single = 0
            For Each o In Ordini
                Tot += (o.TiratoA / o.Ordine.Qta)
            Next

            ris = Tot / Ordini.Count

            Return ris
        End Get
    End Property

    Public ReadOnly Property PercentualeOrdiniContenuti As Integer
        Get
            Dim ris As Integer = 0

            ris = (Ordini.Count * 100) / SpaziDisponibiliTot

            Return ris
        End Get
    End Property

    Public ReadOnly Property ConPiuOrdiniTiratiAlGiusto As Integer
        Get
            Dim ris As Integer = 0
            'For Each fp As ModComFormProd In ModelloCommessa.FormatiProdotto
            'ris += 1
            For Each O In Ordini
                If Tiratura = O.QtaOrdine Then
                    ris += 1
                    'ElseIf Tiratura = O.QtaOrdine / 2 Then
                    '    ris += 1
                End If
            Next
            'Next

            ris = (ris * 100) / Ordini.Count 'SpaziDisponibiliTot

            Return ris
        End Get
    End Property

    Public ReadOnly Property NumeroFormatiContenutiNegliOrdini As Integer
        Get

            Dim L As New List(Of Integer)

            For Each o As OrdineInSoluzione In Ordini
                If L.FindAll(Function(x) x = o.Ordine.ListinoBase.IdFormProd).Count = 0 Then
                    L.Add(o.Ordine.ListinoBase.IdFormProd)
                End If
            Next
            Return L.Count
        End Get
    End Property

    Public ReadOnly Property NumeroFormatiContenuti As Integer
        Get
            Dim ris As Integer = 0
            ris = ModelloCommessa.FormatiProdotto.Count
            Return ris
        End Get
    End Property

    'Public ReadOnly Property Rating As Integer
    '    Get
    '        Dim ris As Integer = 0
    '        For Each fp As ModComFormProd In ModelloCommessa.FormatiProdotto
    '            'ris += 1
    '            For Each O In Ordini
    '                If fp.IdFormProd = O.Ordine.ListinoBase.IdFormProd Then
    '                    ris += 1
    '                End If
    '            Next
    '        Next
    '        Return ris
    '    End Get
    'End Property

    Public ReadOnly Property SpaziDisponibiliFP(IdFormatoProdotto As Integer) As Integer
        Get
            Dim Ris As Integer = 0
            If Not ModelloCommessa Is Nothing Then
                Dim l As List(Of ModComFormProd) = ModelloCommessa.FormatiProdotto.FindAll(Function(item) item.IdFormProd = IdFormatoProdotto)
                For Each m As ModComFormProd In l
                    Ris += m.Spazi
                Next

                If ModelloCommessa.FronteRetro = enSiNo.Si AndAlso ModelloCommessa.FRSuSeStessa = enSiNo.Si Then
                    Ris /= 2
                End If

            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpaziDisponibili(IdFormatoCarta As Integer) As Integer
        Get
            Dim Ris As Integer = 0
            If Not ModelloCommessa Is Nothing Then
                Dim l As List(Of ModComFormProd) = ModelloCommessa.FormatiProdotto.FindAll(Function(item) item.FormatoProdotto.IdFormCarta = IdFormatoCarta)
                For Each m As ModComFormProd In l
                    Ris += m.Spazi
                Next

                If ModelloCommessa.FronteRetro = enSiNo.Si AndAlso ModelloCommessa.FRSuSeStessa = enSiNo.Si Then
                    Ris /= 2
                End If

            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpaziLiberiTot() As Integer
        Get
            Dim Ris As Integer = 0
            Ris = SpaziDisponibiliTot - SpaziUsatiTot
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpaziUsatiFP(IdFormatoProdotto As Integer) As Integer
        Get
            Dim Ris As Integer = 0
            For Each o As OrdineInSoluzione In Ordini
                If o.Ordine.ListinoBase.IdFormProd = IdFormatoProdotto Then
                    Ris += o.SpaziUsati
                End If
            Next
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpaziUsati(IdFormatoCarta As Integer) As Integer
        Get
            Dim Ris As Integer = 0
            For Each o As OrdineInSoluzione In Ordini
                If o.Ordine.Prodotto.FormatoProdotto.IdFormCarta = IdFormatoCarta Then
                    Ris += o.SpaziUsati
                End If
            Next
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpaziDisponibiliTot() As Integer
        Get
            Dim Ris As Integer = 0
            If Not ModelloCommessa Is Nothing Then
                If ModelloCommessa.FormatiProdotto.Count Then
                    For Each m As ModComFormProd In ModelloCommessa.FormatiProdotto
                        Ris += m.Spazi
                    Next
                Else
                    Ris = ModelloCommessa.NumSpazi
                End If
                If (ModelloCommessa.FronteRetro = enSiNo.Si AndAlso ModelloCommessa.FRSuSeStessa = enSiNo.Si) OrElse ModelloCommessa.IdReparto = enRepartoWeb.StampaDigitale AndAlso Ris > 1 Then

                    Ris /= 2
                End If
            End If

            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpaziUsatiTot() As Integer
        Get
            Dim Ris As Integer = 0
            For Each o As OrdineInSoluzione In Ordini
                Ris += o.SpaziUsati
            Next

            Return Ris
        End Get
    End Property

    Public Property OkConRegole As Boolean = False

    Public ReadOnly Property Ottimale As Boolean
        Get
            Dim ris As Boolean = True

            If PercentualeCompletamento < 100 Then
                ris = False
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property PercentualeCompletamento As Integer
        Get

            Dim Ris As Integer = 0

            Ris = Math.Round((SpaziUsatiTot * 100) / SpaziDisponibiliTot)

            'If ModelloCommessa.FronteRetro = enSiNo.Si AndAlso ModelloCommessa.FRSuSeStessa = enSiNo.Si Then
            '    Ris *= 2
            'End If

            Return Ris
        End Get
    End Property

    Public ReadOnly Property QtaNumeroPezzi As Integer
        Get
            Dim Ris As Integer = 0
            Dim buffqta As String = ","
            For Each O As OrdineInSoluzione In Ordini
                If buffqta.IndexOf("," & O.Ordine.QtaOrdine & ",") = -1 Then 'O.Ordine.Prodotto.NumPezzi & ",") = -1 Then ''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                    Ris += 1
                    buffqta &= O.Ordine.QtaOrdine 'O.Ordine.Prodotto.NumPezzi & ","'MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                End If
            Next
            Return Ris
        End Get
    End Property

    Public ReadOnly Property Creabile As Boolean
        Get
            Dim Ris As Boolean = True

            For Each O As OrdineInSoluzione In Ordini
                If O.Ordine.ProgrammataConsegna = False Then
                    Ris = False
                End If
            Next
            Return Ris
        End Get
    End Property


End Class