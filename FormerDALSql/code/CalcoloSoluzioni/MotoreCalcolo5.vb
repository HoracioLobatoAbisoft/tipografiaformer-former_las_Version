Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MotoreCalcolo5
    Implements IMotoreCalcoloSoluzioni
    Private Shared idComP As Integer = 1

    Private Shared Function CreaListePerTipoCarta(listOrd As List(Of OrdineRicerca)) As List(Of List(Of OrdineInSoluzione))

        Dim lstOrdEx As New List(Of List(Of OrdineInSoluzione))
        Dim OldTipoCarta As Integer = 0
        Dim lstSingTC As List(Of OrdineInSoluzione) = Nothing

        For Each O As Ordine In listOrd
            If O.Prodotto.TipoProd = enTipoProdCom.StampaOffSet Then
                If OldTipoCarta <> O.Prodotto.IdTipoCarta Then
                    If Not lstSingTC Is Nothing Then
                        lstOrdEx.Add(lstSingTC)
                    End If
                    lstSingTC = New List(Of OrdineInSoluzione)
                    OldTipoCarta = O.Prodotto.IdTipoCarta
                End If
                Dim OiS As New OrdineInSoluzione
                OiS.Ordine = O
                lstSingTC.Add(OiS)

                For Each Oagg As OrdineInSoluzione In lstSingTC.FindAll(Function(X) X.Ordine.IdRub = O.IdRub)
                    Oagg.NumeroOrdiniDaLavorareStessoIdRub = lstSingTC.FindAll(Function(X) X.Ordine.IdRub = O.IdRub).Count
                Next

            End If
        Next
        If Not lstSingTC Is Nothing Then
            lstOrdEx.Add(lstSingTC)
        End If
        Return lstOrdEx
    End Function

    Private Shared _ParamSoluzione As ParametriCreazioneSoluzione = Nothing

    Private Shared Function CreaListaFinale(lstOrdEx As List(Of List(Of OrdineInSoluzione)),
                                            Optional EscludiCommesseConSingoloOrdine As Boolean = True) As List(Of Soluzione)

        Dim lstFinale As New List(Of Soluzione)

        For Each lst As List(Of OrdineInSoluzione) In lstOrdEx

            lst.Sort(AddressOf SortOrdEx)
            'Dim soluz As New SoluzioniPerTipoCarta
            'soluz.TipoCarta = lst(0).Ordine.Prodotto.TipoCarta
            'If soluz.TipoCarta Is Nothing Then soluz.TipoCarta = New TipoCarta With {.Tipologia = "Non specificata"}
            'prendo tutti i formati carta 
            'prendo tutti i modellicommessa che hanno almeno un formato carta
            'ciclo per ogni modello commessa e vedo come lo riempio

            Dim FronteRetroCom As Boolean = False

            Dim Ml As New List(Of ModelloCommessa)

            For Each O As OrdineInSoluzione In lst
                If O.Ordine.Prodotto.FronteRetro Then
                    FronteRetroCom = True
                End If

                Using mgr As New ModelliCommessaDAO

                    Dim MlSingO As List(Of ModelloCommessa) = mgr.FindByFormatoProdotto(O.Ordine.ListinoBase.FormatoProdotto, _ParamSoluzione.IdMacchinario)

                    If MlSingO.Count Then
                        For Each singMod In MlSingO
                            If Ml.FindAll(Function(x) x.IdModello = singMod.IdModello).Count = 0 Then
                                Ml.Add(singMod)
                            End If
                        Next
                    Else

                        Dim Fl As List(Of FormatoCarta) = Nothing

                        MlSingO = mgr.FindByFormatoCarta(O.Ordine.ListinoBase.FormatoCarta, FronteRetroCom, _ParamSoluzione.IdMacchinario)
                        For Each singMod In MlSingO
                            If Ml.FindAll(Function(x) x.IdModello = singMod.IdModello).Count = 0 Then
                                Ml.Add(singMod)
                            End If
                        Next

                    End If

                End Using

            Next

            'For Each O As OrdineInSoluzione In lst
            '    If O.Ordine.Prodotto.FronteRetro Then
            '        FronteRetroCom = True
            '        Exit For
            '    End If
            'Next

            'Dim Fp As New List(Of FormatoProdotto)
            'For Each o As OrdineInSoluzione In lst
            '    If Fp.FindAll(Function(x) x.IdFormProd = o.Ordine.Prodotto.ListinoBase.IdFormProd).Count = 0 Then
            '        Fp.Add(o.Ordine.Prodotto.ListinoBase.FormatoProdotto)
            '    End If
            'Next

            'Dim Ml As List(Of ModelloCommessa) = Nothing

            'Using mgr As New ModelliCommessaDAO
            '    Ml = mgr.FindByFormatoProdotto(Fp, _ParamSoluzione.IdMacchinario)
            'End Using

            'If Ml.Count = 0 Then
            '    Using Mgr As New ModelliCommessaDAO
            '        Dim Fl As List(Of FormatoCarta) = Nothing
            '        Using MgrFP As New FormatiCartaDAO
            '            Fl = MgrFP.FindByOrdini(lst)
            '        End Using
            '        Ml = Mgr.FindByFormatoCarta(Fl, FronteRetroCom, _ParamSoluzione.IdMacchinario)
            '    End Using
            'End If

            'Dim MlFinale As List(Of ModelloCommessa) = (New ModelliCommessaDAO).GetAll()

            If _ParamSoluzione.CreazioneAutomaticaCommesse Then
                Ml = Ml.FindAll(Function(x) x.AbilitatoAutomazione = enSiNo.Si)
            End If

            If Ml.Count Then
                For Each M As ModelloCommessa In Ml
                    M.CaricaFormatiProdotto()
                    M.CaricaFormatiCarta()
                Next
                Ml.Sort(AddressOf SortModelli)

                Dim Ricorrenze As New List(Of Ricorrenza)
                For Each singOrd As OrdineInSoluzione In lst
                    Dim R As Ricorrenza = Ricorrenze.Find(Function(Item) Item.Qta = singOrd.QtaOrdine)
                    If R Is Nothing Then
                        R = New Ricorrenza
                        'R.Ordini = New List(Of OrdineInSoluzione)
                        R.Qta = singOrd.QtaOrdine
                        If R.Qta = 0 Then Stop
                        'R.IdFormatoCarta = singOrd.Ordine.Prodotto.FormatoProdotto.IdFormCarta
                        Ricorrenze.Add(R)
                    End If
                    R.NumeroOrdini += 1
                    'R.Ordini.Add(singOrd)
                Next

                Ricorrenze.Sort(AddressOf SortRicorrenze)

                'Dim lstNew As New List(Of Ricorrenza)
                Dim Riferimento As Integer = 0

                For Each R As Ricorrenza In Ricorrenze
                    Riferimento = R.Qta 'provo a montare a questa quantita
                    'e raggruppo le altre che non ci montano per quantita tra loro
                    Dim dicR As New Dictionary(Of Integer, List(Of OrdineInSoluzione))
                    Dim SingSol As New Soluzione
                    SingSol.TotOrdiniDaUsare = lst.Count
                    'SingSol.QtaTiratura = Riferimento

                    Dim lstOrd As New List(Of OrdineInSoluzione)(lst.ToArray())
                    'lstOrd.Sort(Function(x, y) y.QtaOrdine.CompareTo(x.QtaOrdine))
                    For Each O As OrdineInSoluzione In lstOrd
                        'qui devo comunque controllare che il rapporto sia il max quanto e' il max 
                        'dei pezzi di un determinato formatocarta in un modello commessa, tanto di piu non ci possono stare
                        If Not O.Ordine.Prodotto.FormatoProdotto Is Nothing Then
                            Dim IdFormatoCarta As Integer = O.Ordine.Prodotto.FormatoProdotto.IdFormCarta

                            'If O.IdOrd = 79624 Then Stop
                            If O.QtaOrdine Mod Riferimento = 0 And O.QtaOrdine >= Riferimento Then
                                'qui a questa quantita lo posso trattare 
                                Dim QuanteVolte As Integer = O.QtaOrdine / Riferimento
                                'O.SpaziUsati = QuanteVolte
                                Dim Max As Integer = 0
                                Using Mgr As New ModComFormProdDAO
                                    Max = Mgr.MaxPostiPerFormatoCarta(IdFormatoCarta)
                                End Using

                                If QuanteVolte <= Max AndAlso QuanteVolte <= _ParamSoluzione.MaxDuplicazioneSingoloOrdine Then
                                    O.TiratoA = Riferimento
                                Else
                                    O.TiratoA = O.QtaOrdine
                                End If
                                'O.UtilizzatoConTiratura = True
                            Else
                                O.TiratoA = O.QtaOrdine
                                'O.UtilizzatoConTiratura = False
                            End If

                            'vedo se esiste una lista con questa tiratur
                            'senno la creo
                            Dim lstOrdR As List(Of OrdineInSoluzione) = Nothing
                            dicR.TryGetValue(O.TiratoA, lstOrdR)
                            If lstOrdR Is Nothing Then
                                lstOrdR = New List(Of OrdineInSoluzione)
                                dicR.Add(O.TiratoA, lstOrdR)
                            End If
                            lstOrdR.Add(O)
                        End If
                    Next

                    For Each item In dicR
                        Dim LProp As List(Of CommessaProposta) = CreaCommesse(item.Value, Ml, EscludiCommesseConSingoloOrdine)
                        'LProp = LProp.FindAll(Function(x) x.NumeroFormatiContenuti = x.FormatiCartaTrovati)
                        LProp.Sort(Function(x, y) y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento))

                        For Each Cp As CommessaProposta In LProp
                            If Cp.PercentualeCompletamento <= 100 Then
                                Dim Aggiungi As Boolean = True

                                If _ParamSoluzione.CreazioneAutomaticaCommesse Then
                                    If Cp.Ordini.FindAll(Function(x) x.QtaOrdine = Cp.Tiratura).Count = 0 Then
                                        If Cp.ModelloCommessa.TiraturaIdeale <> 0 Then
                                            If Cp.Ordini.FindAll(Function(x) x.QtaOrdine = Cp.ModelloCommessa.TiraturaIdeale).Count = 0 Then
                                                Aggiungi = False
                                            End If
                                        Else
                                            Aggiungi = False
                                        End If
                                    End If
                                End If

                                If Aggiungi Then
                                    For Each s In lstFinale
                                        If s.Commesse.FindAll(Function(xx) xx.Firma = Cp.Firma).Count <> 0 Then
                                            Aggiungi = False
                                        End If
                                    Next
                                End If

                                If Aggiungi Then
                                    SingSol.Commesse.Add(Cp)
                                End If

                            End If
                        Next
                    Next
                    If SingSol.Commesse.Count Then lstFinale.Add(SingSol)
                Next
            End If

            'lstFinale.Add(soluz)
        Next

        Return lstFinale

    End Function

    Private Shared Function CalcolaSoluzioni(listOrd As List(Of OrdineRicerca),
                                             Optional SoloPerfect As Boolean = False) As List(Of Soluzione)

        Dim lstFinale As New List(Of Soluzione)

        listOrd.Sort(Function(x, y) x.ListinoBase.IdTipoCarta.CompareTo(y.ListinoBase.IdTipoCarta))

        Dim lstOrdEx As List(Of List(Of OrdineInSoluzione)) = CreaListePerTipoCarta(listOrd)

        'qui ho la lista ordini in list per tipocarta

        For Each s As Soluzione In CreaListaFinale(lstOrdEx)
            lstFinale.Add(s)
        Next

        Dim SFinalePerfect As New Soluzione

        'qui in lista finale ho tutte le commesse che lui ha ipotizzato

        For Each singSol As Soluzione In lstFinale

            singSol.Commesse = singSol.Commesse.FindAll(Function(x) x.NumeroFormatiContenuti = x.NumeroFormatiContenutiNegliOrdini)

            singSol.Commesse.Sort(Function(x, y) y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento))

            For Each singC As CommessaProposta In singSol.Commesse

                RielaboraSingolaCommessaIncompleta(singC, True)

                If SoloPerfect Then

                    If (singC.PercentualeCompletamento = 100 And singC.Rielaborata = False) Or
                           (singC.PercentualeCompletamento = 100 And singC.Rielaborata = True And singC.ModelloCommessa.RitieniOkDuplicati = enSiNo.Si) Then
                        If _ParamSoluzione.NonMostrareTutteleCombinazioni Then
                            SFinalePerfect.AggiungiCommessa(singC, _ParamSoluzione)
                        Else
                            SFinalePerfect.Commesse.Add(singC)
                        End If
                    End If

                Else
                    If _ParamSoluzione.NonMostrareTutteleCombinazioni Then
                        SFinalePerfect.AggiungiCommessa(singC, _ParamSoluzione)
                    Else
                        SFinalePerfect.Commesse.Add(singC)
                    End If
                End If
                'RielaboraSingolaCommessaIncompleta(singC)

            Next
        Next

        If SoloPerfect = False Then
            For Each singSol As Soluzione In lstFinale
                singSol.Commesse = singSol.Commesse.FindAll(Function(x) x.NumeroFormatiContenuti = x.NumeroFormatiContenutiNegliOrdini)

                singSol.Commesse.Sort(Function(x, y) y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento))

                For Each singC As CommessaProposta In singSol.Commesse

                    RielaboraSingolaCommessaIncompleta(singC, True)
                    SFinalePerfect.AggiungiCommessa(singC, _ParamSoluzione)
                Next

            Next
        End If


        'If _ParamSoluzione.CreazioneAutomaticaCommesse = False Then

        '    Dim ListaOrdiniInutilizzati As New List(Of OrdineRicerca)
        '    For Each ord In listOrd
        '        Dim Trovato As Boolean = False
        '        For Each cp As CommessaProposta In SFinalePerfect.Commesse
        '            If cp.Ordini.FindAll(Function(x) x.IdOrd = ord.IdOrd).Count Then
        '                Trovato = True
        '                Exit For
        '            End If
        '        Next
        '        If Trovato = False Then
        '            For Each cp As CommessaProposta In SFinalePerfect.Commesse
        '                If cp.Ordini.FindAll(Function(x) x.IdOrd = ord.IdOrd).Count Then
        '                    Trovato = True
        '                    Exit For
        '                End If
        '            Next
        '        End If
        '        If Trovato = False Then
        '            ListaOrdiniInutilizzati.Add(ord)
        '        End If
        '    Next

        '    If _ParamSoluzione.RielaboraSolitariInCommesseSimili Then

        '        'arrivato qui ho la lista degli ordini inutilizzati
        '        'qui provo a vedere se posso inserirli in qualche commessa di quelle plausibili anche se non hanno la stessa tiratura 
        '        For Each ord In ListaOrdiniInutilizzati
        '            For Each cp As CommessaProposta In SFinalePerfect.Commesse.FindAll(Function(x) x.Tiratura >= ord.Prodotto.NumPezzi And x.SpaziDisponibili(ord.ListinoBase.FormatoProdotto.IdFormCarta) > 0)
        '                'qui devo vedere se la commessa e' dello stesso tipo di carta, se ha spazi liberi per il formato prodotto
        '                'se la tiratura e' distante il giusto
        '                If cp.Ordini(0).Ordine.ListinoBase.IdTipoCarta = ord.ListinoBase.IdTipoCarta Then
        '                    If (cp.Tiratura - ord.Prodotto.NumPezzi) <= (ord.Prodotto.NumPezzi * 3) Then

        '                        'qui devo controllare che le lavorazioni di questo ordine siano compatibili con quelle della commessa

        '                        Dim OkWithEscl As Boolean = True

        '                        'qui devo gestire le lavorazioni esclusive di questo ordine 
        '                        'IMPORTANTE DO PER SCONTATO CHE SE ESCLUSIVA SIA ANCHE ACCORPABILE
        '                        Dim lLavEscl As List(Of Lavorazione) = ord.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
        '                        For Each singLav In lLavEscl
        '                            For Each singO In cp.Ordini
        '                                If singO.Ordine.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
        '                                    OkWithEscl = False
        '                                    Exit For
        '                                End If
        '                            Next
        '                            If OkWithEscl = False Then Exit For
        '                        Next

        '                        'qui le lavorazioni esclusive degli altri ordini gia in quella commessa proposta 
        '                        If OkWithEscl Then
        '                            For Each singO In cp.Ordini
        '                                For Each singlav In singO.Ordine.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
        '                                    If ord.ListaLavori.FindAll(Function(x) x.IdLavoro = singlav.IdLavoro).Count = 0 Then
        '                                        OkWithEscl = False
        '                                        Exit For
        '                                    End If
        '                                Next
        '                                If OkWithEscl = False Then Exit For
        '                            Next
        '                        End If

        '                        If OkWithEscl Then
        '                            Dim O As New OrdineInSoluzione()
        '                            O.Ordine = ord
        '                            O.TiratoA = ord.Prodotto.NumPezzi
        '                            cp.Ordini.Add(O)
        '                            cp.Rielaborata = True

        '                            'ListaOrdiniInutilizzati.Remove(ord)
        '                            Exit For
        '                        End If

        '                    End If
        '                End If

        '            Next
        '        Next
        '        ListaOrdiniInutilizzati = New List(Of OrdineRicerca)
        '        For Each ord In listOrd
        '            Dim Trovato As Boolean = False
        '            For Each cp As CommessaProposta In SFinalePerfect.Commesse
        '                If cp.Ordini.FindAll(Function(x) x.IdOrd = ord.IdOrd).Count Then
        '                    Trovato = True
        '                    Exit For
        '                End If
        '            Next
        '            If Trovato = False Then
        '                ListaOrdiniInutilizzati.Add(ord)
        '            End If
        '        Next

        '    End If
        '    'INIZIO MODIFICA
        '    ''qui devo per tutti gli ordini inutilizzati ricalcolare la soluzione solo per loro e aggiungerla alle plausibli
        '    'For Each SingOrd In ListaOrdiniInutilizzati

        '    '    Dim lstFinaleSing As List(Of Soluzione)
        '    '    Dim lSing As New List(Of OrdineRicerca)
        '    '    lSing.Add(SingOrd)

        '    '    Dim lstOrdExSing As List(Of List(Of OrdineInSoluzione)) = CreaListePerTipoCarta(lSing)

        '    '    'qui ho la lista ordini in list per tipocarta
        '    '    lstFinaleSing = CreaListaFinale(lstOrdExSing, False)

        '    '    For Each S As Soluzione In lstFinaleSing
        '    '        Dim SNew As New Soluzione
        '    '        'SNew.QtaTiratura = S.QtaTiratura
        '    '        SNew.TotOrdiniDaUsare = S.TotOrdiniDaUsare

        '    '        Dim sOk As List(Of CommessaProposta) = SNew.Commesse.FindAll(Function(item) item.PercentualeCompletamento <= 100)
        '    '        sOk.Sort(AddressOf SortCommFinale) 'sOk.Sort(AddressOf SortCommFinale)
        '    '        For Each c As CommessaProposta In sOk
        '    '            RielaboraSingolaCommessaIncompleta(c, True)
        '    '            If _ParamSoluzione.EscludiDoppioni Then
        '    '                SFinalePerfect.AggiungiCommessa(c, _ParamSoluzione)
        '    '            Else
        '    '                SFinalePerfect.Commesse.Add(c)
        '    '            End If
        '    '        Next
        '    '    Next
        '    '    'qui devo sistemare le liste ma sono gia a bun punto per aggiungerle alle plausibili

        '    'Next

        '    'For Each cp As CommessaProposta In SFinalePerfect.Commesse
        '    '    'For Each cp As CommessaProposta In SFinalePerfect.Commesse.FindAll(Function(x) x.Ordini.Count = 1)
        '    '    RielaboraSingolaCommessaIncompleta(cp, True)
        '    'Next
        '    'FINE MODIFICA
        'End If

        Dim lstScremata As New List(Of Soluzione)

        If SFinalePerfect.Commesse.Count Then lstScremata.Add(SFinalePerfect)

        Return lstScremata

    End Function

    Friend Shared Function ProponiSoluzioni(ByVal listOrd As List(Of OrdineRicerca),
                                            ParamSoluzione As ParametriCreazioneSoluzione) As List(Of Soluzione)

        _ParamSoluzione = ParamSoluzione

        idComP = 1

        Dim lstSoluzioni As New List(Of Soluzione)
        Dim SoluzioneFinale As New Soluzione

        Dim SoluzioniTrovate As List(Of Soluzione) = CalcolaSoluzioni(listOrd,
                                                                      True)

        If SoluzioniTrovate.Count = 0 Then
            SoluzioniTrovate = CalcolaSoluzioni(listOrd)
        End If

        While SoluzioniTrovate.Count

            For Each s As Soluzione In SoluzioniTrovate
                For Each C As CommessaProposta In s.Commesse
                    SoluzioneFinale.Commesse.Add(C)

                    For Each O As OrdineInSoluzione In C.Ordini
                        listOrd.Remove(O.Ordine)
                    Next

                Next
            Next

            SoluzioniTrovate = CalcolaSoluzioni(listOrd)

        End While

        'qui prendo le commesse con dentro un solo ordine e devo vedere se ci sono commesse con spazio libero in cui infilarle

        'If _ParamSoluzione.CreazioneAutomaticaCommesse = False Then

        '    Dim lstC As List(Of CommessaProposta) = SoluzioneFinale.Commesse.FindAll(Function(x) x.Ordini.Count = 1 And x.Tiratura = x.Ordini(0).TiratoA)

        '    For Each singC As CommessaProposta In lstC

        '        Dim O As OrdineInSoluzione = singC.Ordini(0)

        '        For Each cp As CommessaProposta In SoluzioneFinale.Commesse.FindAll(Function(x) x.Tiratura >= O.Ordine.Prodotto.NumPezzi And x.SpaziDisponibili(O.Ordine.ListinoBase.FormatoProdotto.IdFormCarta) > 0)
        '            'qui devo vedere se la commessa e' dello stesso tipo di carta, se ha spazi liberi per il formato prodotto
        '            'se la tiratura e' distante il giusto
        '            If cp.Ordini(0).Ordine.ListinoBase.IdTipoCarta = O.Ordine.ListinoBase.IdTipoCarta Then
        '                If (cp.Tiratura - O.Ordine.Prodotto.NumPezzi) <= (O.Ordine.Prodotto.NumPezzi * 3) Then

        '                    'qui devo controllare che le lavorazioni di questo ordine siano compatibili con quelle della commessa

        '                    Dim OkWithEscl As Boolean = True

        '                    'qui devo gestire le lavorazioni esclusive di questo ordine 
        '                    'IMPORTANTE DO PER SCONTATO CHE SE ESCLUSIVA SIA ANCHE ACCORPABILE
        '                    Dim lLavEscl As List(Of Lavorazione) = O.Ordine.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
        '                    For Each singLav In lLavEscl
        '                        For Each singO In cp.Ordini
        '                            If singO.Ordine.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
        '                                OkWithEscl = False
        '                                Exit For
        '                            End If
        '                        Next
        '                        If OkWithEscl = False Then Exit For
        '                    Next

        '                    'qui le lavorazioni esclusive degli altri ordini gia in quella commessa proposta 
        '                    If OkWithEscl Then
        '                        For Each singO In cp.Ordini
        '                            For Each singlav In singO.Ordine.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
        '                                If O.Ordine.ListaLavori.FindAll(Function(x) x.IdLavoro = singlav.IdLavoro).Count = 0 Then
        '                                    OkWithEscl = False
        '                                    Exit For
        '                                End If
        '                            Next
        '                            If OkWithEscl = False Then Exit For
        '                        Next
        '                    End If

        '                    If OkWithEscl Then

        '                        If singC.SpaziDisponibili(O.Ordine.ListinoBase.FormatoProdotto.IdFormCarta) > 0 Then
        '                            cp.Ordini.Add(O)
        '                            SoluzioneFinale.Commesse.Remove(singC)
        '                        End If


        '                        'ListaOrdiniInutilizzati.Remove(ord)
        '                        Exit For
        '                    End If

        '                End If
        '            End If

        '        Next
        '    Next

        'End If

        lstSoluzioni.Add(SoluzioneFinale)

        Return lstSoluzioni

    End Function

    'Private Shared Function SortCommessaProposta(ByVal x As CommessaProposta,
    '                                      ByVal y As CommessaProposta) As Integer
    '    Dim result As Integer = 0
    '    result = y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento)
    '    If result = 0 Then
    '        result = x.Riassunto.CompareTo(y.Riassunto)
    '        If result = 0 Then
    '            result = y.Tiratura.CompareTo(x.Tiratura)
    '        End If
    '    End If
    '    Return result
    'End Function

    Private Shared Function EliminaQuelleConOrdiniGiaInOttimali(SfinalePlaus As Soluzione,
                                                                SfinalePerfect As Soluzione) As Soluzione

        Dim SNew As New Soluzione
        SNew.TotOrdiniUsati = SfinalePlaus.TotOrdiniUsati
        SNew.TotOrdiniDaUsare = SfinalePlaus.TotOrdiniDaUsare

        For Each C As CommessaProposta In SfinalePlaus.Commesse
            Dim AggiungiCommessa As Boolean = True
            For Each O As OrdineInSoluzione In C.Ordini
                Dim IdOrd As Integer = O.IdOrd

                For Each Cok As CommessaProposta In SfinalePerfect.Commesse
                    For Each Ook As OrdineInSoluzione In Cok.Ordini
                        If Ook.IdOrd = IdOrd Then
                            'qui l'ho trovato gia e non lo devo aggiungere
                            AggiungiCommessa = False
                            Exit For
                        End If
                    Next
                Next

            Next
            If AggiungiCommessa Then
                'SNew.Commesse.Add(C)
                SNew.AggiungiCommessa(C, _ParamSoluzione)
            End If
        Next

        Return SNew

    End Function

    Private Shared Function EliminaQuelleConOrdiniGiaInOttimaliEx(SfinalePlaus As Soluzione,
                                                                ByRef SfinalePerfect As Soluzione) As Soluzione

        Dim SNew As New Soluzione
        SNew.TotOrdiniUsati = SfinalePlaus.TotOrdiniUsati
        SNew.TotOrdiniDaUsare = SfinalePlaus.TotOrdiniDaUsare

        For Each C As CommessaProposta In SfinalePlaus.Commesse
            Dim AggiungiCommessa As Boolean = True
            For Each O As OrdineInSoluzione In C.Ordini
                Dim IdOrd As Integer = O.IdOrd

                For Each Cok As CommessaProposta In SfinalePerfect.Commesse
                    For Each Ook As OrdineInSoluzione In Cok.Ordini
                        If Ook.IdOrd = IdOrd Then
                            'qui devo decidere se e' meglio quella tra le perfette o questa tra le plausibili
                            If Cok.DaPreferireAV4(C) Then
                                'qui l'ho trovato gia e non lo devo aggiungere
                                AggiungiCommessa = False
                                Exit For
                            End If
                        End If
                    Next
                Next

            Next
            If AggiungiCommessa Then
                'SNew.Commesse.Add(C)
                'qui devo andare tra le perfette e togliere tutte quelel che usano ordini contenuti nella plausibile
                SNew.AggiungiCommessa(C, _ParamSoluzione)
                For Each O As OrdineInSoluzione In C.Ordini

                    For Each Cok As CommessaProposta In SfinalePerfect.Commesse
                        Dim IdOrd As Integer = O.IdOrd
                        For Each Ook As OrdineInSoluzione In Cok.Ordini
                            If Ook.IdOrd = IdOrd Then
                                'qui devo eliminare questa commessa dalle perfette
                                'SfinalePerfect.Commesse.Remove(Cok)
                                Cok.DaScartare = True
                                Exit For
                            End If
                        Next
                    Next
                Next
                SfinalePerfect.Commesse = SfinalePerfect.Commesse.FindAll(Function(x) x.DaScartare = False)
            End If
        Next

        Return SNew

    End Function

    Private Shared Sub RielaboraSingolaCommessaIncompleta(ByRef C As CommessaProposta,
                                                          Optional ForzaSolitari As Boolean = False)

        If C.PercentualeCompletamento <= 50 Then

            'If C.PercentualeCompletamento = 16 Then Stop
            'If (C.SpaziDisponibiliTot Mod C.SpaziUsatiTot = 0) Then
            'If C.PercentualeCompletamento <= 50 And (100 Mod C.PercentualeCompletamento = 0) Then
            Dim Proporzione As Single = C.ProporzioneCommessaRielaborabile()
            If (Proporzione <> 0 And Proporzione <= _ParamSoluzione.MaxDuplicazioneSingoloOrdine) Or
                (Proporzione <> 0 And ForzaSolitari = True) Then

                Dim VecchiaTiratura As Integer = C.Tiratura
                Dim NuovaTiratura As Integer = C.Tiratura / Proporzione

                If NuovaTiratura >= C.QtaMinimaDagliOrdini OrElse
                    C.ModelloCommessa.RitieniOkDuplicati = enSiNo.Si OrElse
                    _ParamSoluzione.PermettiQtaMinoreOrdini = True Then
                    C.Rielaborata = True
                    C.Tiratura = NuovaTiratura
                    If C.Tiratura = 0 Then C.Tiratura = 1
                    While ((C.Tiratura * CInt(Proporzione)) < VecchiaTiratura)
                        C.Tiratura += 1
                    End While
                    For Each o As OrdineInSoluzione In C.Ordini
                        'If o.IdOrd = 36527 Then Stop
                        o.Rielabora(C.Tiratura)
                    Next
                End If

            End If

            'end if
        ElseIf C.PercentualeCompletamento < 100 And C.PercentualeCompletamento > 50 Then
            'qui devo vedere se posso togliere un ordine e poi rivederla ma e' complicato 

            If _ParamSoluzione.ProvaEscludereOrdiniPerRaddoppiareSpazi Then
                If C.Ordini.Count > 1 Then

                    'qui vanno ordinati correttamente prima di toglierli via 
                    C.Ordini.Sort(AddressOf SortPerEsclusione)
                    Do
                        If C.Ordini.Count = 1 Then
                            Exit Do
                        Else
                            C.Ordini.RemoveAt(C.Ordini.Count - 1)
                        End If
                    Loop Until C.PercentualeCompletamento <= 50

                    RielaboraSingolaCommessaIncompleta(C)

                End If
            End If
        End If

    End Sub

    Private Shared Function RielaboraCommesseIncomplete(s As Soluzione) As Soluzione

        'qui provo a rielaborare le commessse incomplete 
        'per ora rielaboro solo quelle in cui ogni ordine al massimo occupa uno spazio
        'in questo caso posso rielaborare se i ltotspaziusati e' max la meta dello spazio usato 
        Dim SNew As New Soluzione
        SNew.TotOrdiniUsati = s.TotOrdiniUsati
        SNew.TotOrdiniDaUsare = s.TotOrdiniDaUsare

        For Each C As CommessaProposta In s.Commesse
            'If Not C.Ordini.Find(Function(item) item.IdOrd = 36527) Is Nothing Then Stop
            'If C.Id = 37 Then Stop
            RielaboraSingolaCommessaIncompleta(C)
            SNew.Commesse.Add(C)
        Next

        Return SNew
    End Function

    Private Shared Function SortCommFinale(x As CommessaProposta, y As CommessaProposta) As Integer
        Dim Ris As Integer = 0

        Ris = y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento)
        If Ris = 0 Then
            Ris = y.ModelloCommessa.NumSpazi.CompareTo(x.ModelloCommessa.NumSpazi)
            If Ris = 0 Then
                Ris = y.Tiratura.CompareTo(x.Tiratura)
                If Ris = 0 Then
                    Ris = y.Ordini.Count.CompareTo(x.Ordini.Count)
                End If
            End If
        End If

        Return Ris
    End Function

    Private Shared Function SortComm(x As CommessaProposta, y As CommessaProposta) As Integer
        Dim Ris As Integer = Ris = y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento)
        If Ris = 0 Then
            Ris = y.SpaziDisponibiliTot.CompareTo(x.SpaziDisponibiliTot)
            If Ris = 0 Then
                Ris = y.Tiratura.CompareTo(x.Tiratura)
            End If
        End If

        Return Ris
    End Function

    Private Shared Function CreaCommesse(lstO As List(Of OrdineInSoluzione),
                                         lstM As List(Of ModelloCommessa),
                                         Optional EscludiCommesseConSingoloOrdine As Boolean = True) As List(Of CommessaProposta)

        'ordino la lista in base a quanti spazi occupa cosi sono sicuro di riempire
        lstO.Sort(AddressOf SortOrdFinale)

        Dim lcom As New List(Of CommessaProposta)
        For Each o As OrdineInSoluzione In lstO
            If Not o.Ordine.Prodotto.FormatoProdotto Is Nothing Then
                'If o.IdOrd = 50825 Then Stop
                Dim IdFormatoCarta As Integer = o.Ordine.Prodotto.FormatoProdotto.IdFormCarta

                'Dim ModComConFormProd As Integer = lstM.FindAll(Function(x) x.FormatiProdotto.FindAll(Function(item) item.FormatoProdotto.IdFormProd = o.Ordine.Prodotto.FormatoProdotto.IdFormProd).Count > 0).Count

                For Each m As ModelloCommessa In lstM

                    'If m.IdModello = 121 Then Stop
                    'If idComP = 204 Then Stop
                    'qui provo a usare ogni modello commessa e vedere se lo riempio con tutti gli ordini che ho 

                    'DISATTIVATO PER FAR UTILIZZARE I FORMATI PRODOTTO E NON I FORMATI CARTA NELLA RICERCA DEI MODELLI COMMESSA
                    If Not m.FormatiProdotto.Find(Function(item) item.FormatoProdotto.IdFormCarta = IdFormatoCarta) Is Nothing Then
                        'If (ModComConFormProd > 0 And Not m.FormatiProdotto.Find(Function(item) item.FormatoProdotto.IdFormProd = o.Ordine.Prodotto.FormatoProdotto.IdFormProd) Is Nothing) Or
                        '    (ModComConFormProd = 0 And Not m.FormatiProdotto.Find(Function(item) item.FormatoProdotto.IdFormCarta = IdFormatoCarta) Is Nothing) Then

                        Dim NumSpaziDisp As Integer = m.GetNumSpaziFormatoCarta(IdFormatoCarta)
                        'If NumSpaziDisp Then
                        If NumSpaziDisp >= o.SpaziUsati Then

                            Dim CmList As List(Of CommessaProposta) = lcom.FindAll(Function(item) item.ModelloCommessa.IdModello = m.IdModello)
                            CmList = CmList.FindAll(Function(item) item.Tiratura = o.TiratoA)
                            Dim CmLM As List(Of CommessaProposta) = CmList.FindAll(Function(item) (item.SpaziUsati(IdFormatoCarta) + o.SpaziUsati) <= item.SpaziDisponibili(IdFormatoCarta))

                            CmLM.Sort(AddressOf SortCommFinale)

                            Dim Cm As CommessaProposta = Nothing
                            If CmLM.Count Then
                                'Cm = CmLM(0)
                                For Each singCm In CmLM
                                    Dim OkWithEscl As Boolean = True

                                    'qui devo gestire le lavorazioni esclusive di questo ordine 
                                    'IMPORTANTE DO PER SCONTATO CHE SE ESCLUSIVA SIA ANCHE ACCORPABILE
                                    Dim lLavEscl As List(Of Lavorazione) = o.Ordine.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
                                    For Each singLav In lLavEscl
                                        For Each singO In singCm.Ordini
                                            If singO.Ordine.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
                                                OkWithEscl = False
                                                Exit For
                                            End If
                                        Next
                                        If OkWithEscl = False Then Exit For
                                    Next

                                    'qui le lavorazioni esclusive degli altri ordini gia in quella commessa proposta 
                                    If OkWithEscl Then
                                        For Each singO In singCm.Ordini
                                            For Each singlav In singO.Ordine.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
                                                If o.Ordine.ListaLavori.FindAll(Function(x) x.IdLavoro = singlav.IdLavoro).Count = 0 Then
                                                    OkWithEscl = False
                                                    Exit For
                                                End If
                                            Next
                                            If OkWithEscl = False Then Exit For
                                        Next
                                    End If

                                    If OkWithEscl Then
                                        Cm = singCm
                                        If Cm.Ordini.FindAll(Function(x) x.IdOrd = o.IdOrd).Count = 0 Then
                                            Dim OInC As OrdineInSoluzione = o.Clone
                                            Cm.Ordini.Add(OInC)
                                        End If
                                    End If

                                Next

                            End If

                            'qui cerco se esiste una commessa in cui sta da solo anche lui 

                            Dim CmSolo As CommessaProposta = Nothing

                            CmSolo = lcom.Find(Function(x) x.ModelloCommessa.IdModello = m.IdModello And
                                                   x.Ordini.FindAll(Function(z) z.IdOrd = o.IdOrd).Count = 1 And
                                                   x.Tiratura = o.TiratoA)

                            If CmSolo Is Nothing Then
                                CmSolo = New CommessaProposta
                                CmSolo.Tiratura = o.TiratoA
                                CmSolo.ModelloCommessa = m
                                CmSolo.Id = idComP
                                idComP += 1
                                lcom.Add(CmSolo)
                                Dim OInCs As OrdineInSoluzione = o.Clone
                                CmSolo.Ordini.Add(OInCs)
                            End If

                        End If

                    End If
                Next
            End If
        Next

        'lcom = lcom.FindAll(Function(x) x.NumeroFormatiContenuti = x.NumeroFormatiContenutiNegliOrdini)
        'If _ParamSoluzione.PermettiQtaMinoreOrdini = False Then lcom = lcom.FindAll(Function(x) x.Ordini.FindAll(Function(y) y.QtaOrdine = x.Tiratura).Count)
        'If EscludiCommesseConSingoloOrdine Then lcom = lcom.FindAll(Function(x) x.Ordini.Count > 1 Or (x.Ordini.Count = 1 And x.SpaziDisponibiliTot = 1))
        'Dim ris As New List(Of CommessaProposta)
        Return lcom
    End Function

    Private Shared Function SortModelli(ByVal x As ModelloCommessa, ByVal y As ModelloCommessa) As Integer
        Dim result As Integer = y.TotFormatiCarta.CompareTo(x.TotFormatiCarta)
        If result = 0 Then
            result = y.NumSpazi.CompareTo(x.NumSpazi)
        End If
        Return result
    End Function

    Private Shared Function SortRicorrenze(ByVal x As Ricorrenza, ByVal y As Ricorrenza) As Integer
        Dim result As Integer = y.NumeroOrdini.CompareTo(x.NumeroOrdini)
        If result = 0 Then
            result = y.Qta.CompareTo(x.Qta)
        End If
        Return result
        'torna prima quello con piu numerosita e a parita' quello con il valore piu basso
    End Function

    Private Shared Function SortOrdFinale(ByVal x As OrdineInSoluzione, ByVal y As OrdineInSoluzione) As Integer
        Dim result As Integer = x.QtaOrdine.CompareTo(y.QtaOrdine)
        'Dim result As Integer = y.Prioritario.CompareTo(x.Prioritario)
        If result = 0 Then
            result = x.Ordine.ConsegnaAssociata.Giorno.CompareTo(y.Ordine.ConsegnaAssociata.Giorno)
            If result = 0 Then
                result = y.TiratoA.CompareTo(x.TiratoA)
                If result = 0 Then
                    result = y.SpaziUsati.CompareTo(x.SpaziUsati)
                    If result = 0 Then
                        'result = x.Ordine.DataConsProgr.CompareTo(y.Ordine.DataConsProgr)
                        'If result = 0 Then
                        result = y.NumeroOrdiniDaLavorareStessoIdRub.CompareTo(x.NumeroOrdiniDaLavorareStessoIdRub)
                        If result = 0 Then
                            result = x.Ordine.IdOrd.CompareTo(y.Ordine.IdOrd)
                        End If
                        'End If
                    End If
                End If
            End If
        End If

        Return result
    End Function

    Private Shared Function SortOrdEx(ByVal x As OrdineInSoluzione, ByVal y As OrdineInSoluzione) As Integer
        Dim result As Integer = y.Ordine.Prodotto.IdTipoCarta.CompareTo(x.Ordine.Prodotto.IdTipoCarta)
        If result = 0 Then
            result = y.QtaOrdine.CompareTo(x.QtaOrdine)

            If result = 0 Then
                result = x.Ordine.ConsegnaAssociata.Giorno.CompareTo(y.Ordine.ConsegnaAssociata.Giorno)
                If result = 0 Then
                    result = y.NumeroOrdiniDaLavorareStessoIdRub.CompareTo(x.NumeroOrdiniDaLavorareStessoIdRub)
                    If result = 0 Then
                        result = y.Ordine.Prodotto.FronteRetro.CompareTo(x.Ordine.Prodotto.FronteRetro)
                    End If
                End If
            End If
        End If

        Return result
    End Function

    Private Shared Function SortOrd(ByVal x As Ordine, ByVal y As Ordine) As Integer
        Dim result As Integer = y.Prodotto.IdTipoCarta.CompareTo(x.Prodotto.IdTipoCarta)
        If result = 0 Then
            result = y.Qta.CompareTo(x.Qta)

            If result = 0 Then
                result = x.ConsegnaAssociata.Giorno.CompareTo(y.ConsegnaAssociata.Giorno)
                If result = 0 Then
                    result = y.IdRub.CompareTo(x.IdRub) 'AGGIUNTO PER METTERE INSIEME TUTTI GLI ORDINI DI UNO STESSO CLIENTE A PARITA PRIMA
                    If result = 0 Then
                        result = y.Prodotto.FronteRetro.CompareTo(x.Prodotto.FronteRetro)
                    End If
                End If
            End If
        End If


        Return result
    End Function

    Private Shared Function SortByRicorrenza(ByVal x As OrdineInSoluzione, ByVal y As OrdineInSoluzione) As Integer
        Dim result As Integer = y.Ordine.QtaOrdine.CompareTo(x.Ordine.QtaOrdine)
        'If result = 0 Then
        '    result = x.IdCom.CompareTo(y.IdCom)
        'End If
        Return result
    End Function

    Private Shared Function SortPerEsclusione(ByVal x As OrdineInSoluzione, ByVal y As OrdineInSoluzione) As Integer
        Dim result As Integer = y.Prioritario.CompareTo(x.Prioritario)
        If result = 0 Then
            result = x.Ordine.ConsegnaAssociata.Giorno.CompareTo(y.Ordine.ConsegnaAssociata.Giorno)
        End If
        Return result
    End Function

End Class