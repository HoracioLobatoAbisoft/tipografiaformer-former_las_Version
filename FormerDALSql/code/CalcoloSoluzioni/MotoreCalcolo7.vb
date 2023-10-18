Imports System.Drawing
Imports FormerBusinessLogicInterface
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MotoreCalcolo7
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

    Private Shared Function CreaListePerCompatibili(listOrd As List(Of OrdineRicerca)) As List(Of List(Of OrdineInSoluzione))
        'CREA LISTE PER TIPOCARTA E LAVORAZIONI COMPATIBILI
        Dim lstOrdEx As New List(Of List(Of OrdineInSoluzione))

        For Each O As Ordine In listOrd
            Dim lstSingTC As List(Of OrdineInSoluzione) = Nothing
            If O.Prodotto.TipoProd = enTipoProdCom.StampaOffSet Then
                Dim OkLav As Boolean = True
                For Each singL As List(Of OrdineInSoluzione) In lstOrdEx.FindAll(Function(x) x.FindAll(Function(y) y.Ordine.ListinoBase.IdTipoCarta = O.ListinoBase.IdTipoCarta).Count > 0)
                    OkLav = True
                    'qui controllo se gli ordini nella lista sono compatibili a livello di lavorazioni con questo selezionato
                    Dim lLavEscl As List(Of Lavorazione) = O.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
                    For Each OIn As OrdineInSoluzione In singL
                        For Each singLav In lLavEscl
                            If OIn.Ordine.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
                                OkLav = False
                                Exit For
                            End If
                        Next
                        If OkLav = False Then Exit For
                    Next

                    If OkLav Then
                        'qui controllo se le lavorazioni esclusive degli ordini della lista ci stanno in questo ordine
                        If singL.Count Then
                            Dim OIn As OrdineInSoluzione = singL(0)
                            Dim lLavEsclIn As List(Of Lavorazione) = OIn.Ordine.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)

                            For Each singLav In lLavEsclIn
                                If O.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
                                    OkLav = False
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                    If OkLav Then
                        lstSingTC = singL
                        Exit For
                    End If
                Next

                If lstSingTC Is Nothing Then
                    lstSingTC = New List(Of OrdineInSoluzione)
                    lstOrdEx.Add(lstSingTC)
                End If

                Dim OiS As New OrdineInSoluzione
                OiS.Ordine = O
                lstSingTC.Add(OiS)

                Dim TotOrdByIdRub As Integer = lstSingTC.FindAll(Function(X) X.Ordine.IdRub = O.IdRub).Count
                For Each Oagg As OrdineInSoluzione In lstSingTC.FindAll(Function(X) X.Ordine.IdRub = O.IdRub)
                    Oagg.NumeroOrdiniDaLavorareStessoIdRub = TotOrdByIdRub
                Next

            End If
        Next
        'If Not lstSingTC Is Nothing Then
        '    lstOrdEx.Add(lstSingTC)
        'End If
        Return lstOrdEx
    End Function

    Private Shared _ParamSoluzione As ParametriCreazioneSoluzione = Nothing
    Private Shared Function CreaListaFinaleOld(lstOrdEx As List(Of List(Of OrdineInSoluzione)),
                                            Optional EscludiCommesseConSingoloOrdine As Boolean = True) As List(Of Soluzione)

        Dim lstFinale As New List(Of Soluzione)
        Dim ListaInCorso As Integer = 1
        For Each lst As List(Of OrdineInSoluzione) In lstOrdEx
            Dim TipoCartaStr As String = lst(0).Ordine.ListinoBase.TipoCarta.Tipologia
            RaiseEvent AggiornamentoStato("***Creo soluzioni per la lista compatibili " & ListaInCorso & " di " & lstOrdEx.Count & ": " & TipoCartaStr)
            ListaInCorso += 1
            'lst.Sort(AddressOf SortOrdEx)
            'Dim soluz As New SoluzioniPerTipoCarta
            'soluz.TipoCarta = lst(0).Ordine.Prodotto.TipoCarta
            'If soluz.TipoCarta Is Nothing Then soluz.TipoCarta = New TipoCarta With {.Tipologia = "Non specificata"}
            'prendo tutti i formati carta 
            'prendo tutti i modellicommessa che hanno almeno un formato carta
            'ciclo per ogni modello commessa e vedo come lo riempio

            Dim FronteRetroCom As Boolean = False

            Dim Ml As New List(Of ModelloCommessa)

            For Each O As OrdineInSoluzione In lst

                If O.Ordine.ListinoBase.ColoreStampa.FR Then
                    FronteRetroCom = True
                End If

                'If O.Ordine.Prodotto.FronteRetro Then
                '    FronteRetroCom = True
                'End If

                Using mgr As New ModelliCommessaDAO
                    Dim MlSingO As List(Of ModelloCommessa) = Nothing
                    If _ParamSoluzione.UtilizzaSoloFormatiCarta Then
                        Dim Fl As List(Of FormatoCarta) = Nothing
                        MlSingO = mgr.FindByFormatoCarta(O.Ordine.ListinoBase.FormatoCarta,, _ParamSoluzione.IdMacchinario, True)
                        For Each singMod In MlSingO
                            If Ml.FindAll(Function(x) x.IdModello = singMod.IdModello).Count = 0 Then
                                Ml.Add(singMod)
                            End If
                        Next
                    Else
                        MlSingO = mgr.FindByFormatoProdotto(O.Ordine.ListinoBase.FormatoProdotto, _ParamSoluzione.IdMacchinario)
                        If MlSingO.Count Then
                            For Each singMod In MlSingO
                                If Ml.FindAll(Function(x) x.IdModello = singMod.IdModello).Count = 0 Then
                                    Ml.Add(singMod)
                                End If
                            Next
                        Else
                            Dim Fl As List(Of FormatoCarta) = Nothing
                            MlSingO = mgr.FindByFormatoCarta(O.Ordine.ListinoBase.FormatoCarta,, _ParamSoluzione.IdMacchinario, True)
                            For Each singMod In MlSingO
                                If Ml.FindAll(Function(x) x.IdModello = singMod.IdModello).Count = 0 Then
                                    Ml.Add(singMod)
                                End If
                            Next
                        End If
                    End If

                End Using
            Next

            'qui scremo i modelli commessa
            Dim MlFinale As New List(Of ModelloCommessa)
            For Each M As ModelloCommessa In Ml
                Dim Aggiungi As Boolean = True
                For Each fp As ModComFormProd In M.FormatiProdotto
                    If lst.FindAll(Function(x) x.Ordine.ListinoBase.IdFormProd = fp.IdFormProd).Count = 0 Then
                        Aggiungi = False
                        Exit For
                    End If
                Next
                If Aggiungi Then MlFinale.Add(M)
            Next
            Ml = MlFinale

            Ml = Ml.FindAll(Function(x) x.Disattivo = enSiNo.No) 'ESCLUDO I DISATTIVATI

            If FronteRetroCom Then
                'qui c'e' almeno un ordine fronteretro
                Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.Si)
            Else
                'qui ci sono solo ordini solofronte
                Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.No)
            End If

            If _ParamSoluzione.CreazioneAutomaticaCommesse Then
                Ml = Ml.FindAll(Function(x) x.AbilitatoAutomazione = enSiNo.Si)
            End If

            If Ml.Count Then

                If _ParamSoluzione.IdModelloCommessa Then
                    Ml = Ml.FindAll(Function(x) x.IdModello = _ParamSoluzione.IdModelloCommessa)
                End If

                For Each M As ModelloCommessa In Ml
                    M.CaricaFormatiProdotto()
                    M.CaricaFormatiCarta()
                Next
                Ml.Sort(AddressOf SortModelli)

                Dim Ricorrenze As New List(Of Ricorrenza)
                Dim RicorrenzeStr As String = String.Empty
                For Each singOrd As OrdineInSoluzione In lst
                    Dim R As Ricorrenza = Ricorrenze.Find(Function(Item) Item.Qta = singOrd.QtaOrdine)
                    If R Is Nothing Then
                        R = New Ricorrenza
                        'R.Ordini = New List(Of OrdineInSoluzione)
                        R.Qta = singOrd.QtaOrdine
                        RicorrenzeStr &= R.Qta & ","
                        If R.Qta = 0 Then Stop
                        'R.IdFormatoCarta = singOrd.Ordine.Prodotto.FormatoProdotto.IdFormCarta
                        Ricorrenze.Add(R)
                    End If
                    R.NumeroOrdini += 1
                    'R.Ordini.Add(singOrd)
                Next
                RicorrenzeStr = RicorrenzeStr.TrimEnd(",")

                Ricorrenze.Sort(AddressOf SortRicorrenze)
                RaiseEvent AggiornamentoStato("***Trovate " & Ricorrenze.Count & " ricorrenze: " & RicorrenzeStr)
                'Dim lstNew As New List(Of Ricorrenza)
                Dim Riferimento As Integer = 0
                Dim dicR As New Dictionary(Of Integer, List(Of OrdineInSoluzione))
                'Dim SingSol As New Soluzione
                For Each R As Ricorrenza In Ricorrenze
                    Riferimento = R.Qta 'provo a montare a questa quantita
                    'e raggruppo le altre che non ci montano per quantita tra loro
                    'SingSol.TotOrdiniDaUsare = lst.Count
                    Dim lstOrd As List(Of OrdineInSoluzione) = lst.FindAll(Function(x) x.QtaOrdine >= Riferimento)
                    'SingSol.TotOrdiniDaUsare = lstOrd.Count

                    'SingSol.QtaTiratura = Riferimento


                    'lstOrd.Sort(Function(x, y) y.QtaOrdine.CompareTo(x.QtaOrdine))
                    For Each OS As OrdineInSoluzione In lstOrd
                        Dim O As OrdineInSoluzione = OS.Clone
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

                                If QuanteVolte <= Max Then
                                    If QuanteVolte <= _ParamSoluzione.MaxDuplicazioneSingoloOrdine Then
                                        O.TiratoA = Riferimento
                                    Else
                                        'qui devo vedere se per questa quantita va bene tutto 
                                        If MgrRegoleCalcolo.ExistRegola(O, MgrRegoleCalcolo.ChiaveRegolaUtente.OkConQtaSuperioreA) Then
                                            O.TiratoA = Riferimento
                                        End If

                                    End If
                                End If

                                'If QuanteVolte <= Max AndAlso QuanteVolte <= _ParamSoluzione.MaxDuplicazioneSingoloOrdine Then
                                '    O.TiratoA = Riferimento
                                '    'Else
                                '    '   O.TiratoA = O.QtaOrdine
                                'End If
                                'O.UtilizzatoConTiratura = True
                                'Else
                                '   O.TiratoA = O.QtaOrdine
                                'O.UtilizzatoConTiratura = False
                            End If

                            'vedo se esiste una lista con questa tiratura
                            'senno la creo
                            If O.TiratoA Then
                                Dim lstOrdR As List(Of OrdineInSoluzione) = Nothing
                                dicR.TryGetValue(O.TiratoA, lstOrdR)
                                If lstOrdR Is Nothing Then
                                    lstOrdR = New List(Of OrdineInSoluzione)
                                    dicR.Add(O.TiratoA, lstOrdR)
                                End If
                                lstOrdR.Add(O)
                            End If

                        End If
                    Next
                Next

                For Each item In dicR
                    System.Windows.Forms.Application.DoEvents()
                    Dim SingSol As New Soluzione
                    SingSol.TotOrdiniDaUsare = item.Value.Count
                    Dim LProp As List(Of CommessaProposta) = New List(Of CommessaProposta)

                    Dim IdMacchinarioPrescelto As Integer = 0
                    Dim dicMacch As New Dictionary(Of Integer, Integer)
                    For Each o As OrdineInSoluzione In item.Value
                        'Dim IdMaccOrd As Integer = o.Ordine.ListinoBase.Preventivazione.IdMacchinario 'IDMACCHINARIO
                        Dim IdMaccOrd As Integer = o.Ordine.ListinoBase.IdMacchinarioProduzione 'IDMACCHINARIO
                        If IdMaccOrd <> 0 Then
                            Dim TotMacc As Integer = 0
                            dicMacch.TryGetValue(IdMaccOrd, TotMacc)
                            TotMacc += 1
                            If TotMacc = 1 Then
                                dicMacch.Add(IdMaccOrd, TotMacc)
                            Else
                                dicMacch.Item(IdMaccOrd) = TotMacc
                            End If
                        End If
                    Next

                    For Each items In dicMacch
                        IdMacchinarioPrescelto = items.Key
                    Next

                    'qui scremo i modelli commessa
                    Dim MlFiltrata As New List(Of ModelloCommessa)
                    For Each M As ModelloCommessa In Ml
                        Dim Aggiungi As Boolean = True

                        If _ParamSoluzione.SoloSoluzioniOttimali AndAlso
                                   IdMacchinarioPrescelto <> 0 AndAlso
                                   IdMacchinarioPrescelto <> M.IdMacchinarioDef Then
                            Aggiungi = False
                        End If

                        If Aggiungi Then
                            For Each fp As ModComFormProd In M.FormatiProdotto
                                If item.Value.FindAll(Function(x) x.Ordine.ListinoBase.IdFormProd = fp.IdFormProd).Count = 0 Then
                                    Aggiungi = False
                                    Exit For
                                End If

                                If Aggiungi And 1 = 0 Then 'TODO: CONTROLLARE PERCHE QUESTO BLOCCO VIENE DISABILITATO
                                    Dim ControllaFp As Boolean = True
                                    If item.Value.Count = 1 Then
                                        Dim OSing As OrdineInSoluzione = item.Value(0)
                                        If OSing.Ordine.ListinoBase.CalcolaAncheDaSolo = enSiNo.Si Then
                                            ControllaFp = False
                                        End If
                                    End If
                                    If ControllaFp Then
                                        If _ParamSoluzione.SoloSoluzioniOttimali Then
                                            Dim TotNegliOrdini As Integer = 0
                                            For Each O As OrdineInSoluzione In item.Value
                                                If O.Ordine.ListinoBase.IdFormProd = fp.IdFormProd Then
                                                    TotNegliOrdini += O.SpaziUsati
                                                End If
                                            Next
                                            If TotNegliOrdini < M.GetNumSpaziFormatoProdotto(fp.IdFormProd) Then
                                                Aggiungi = False
                                                Exit For
                                            End If

                                        End If
                                    End If

                                End If
                            Next
                        End If

                        If Aggiungi Then MlFiltrata.Add(M)
                    Next

                    RaiseEvent AggiornamentoStato("***Trovati " & MlFiltrata.Count & " modelli utilizzabili")

                    For Each M As ModelloCommessa In MlFiltrata
                        'qui devo vedere se 
                        RaiseEvent AggiornamentoStato("****Creo Commesse con modello " & M.Nome)
                        Dim lTemp As List(Of CommessaProposta) = CreaCommesseByModello(item.Value, M)
                        RaiseEvent AggiornamentoStato("****Create " & lTemp.Count & " commesse plausibili")
                        LProp.AddRange(lTemp)
                    Next

                    'LProp = LProp.FindAll(Function(x) x.NumeroFormatiContenuti = x.FormatiCartaTrovati)
                    'LProp.Sort(Function(x, y) y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento))
                    RaiseEvent AggiornamentoStato("***Trovate " & LProp.Count & " commesse plausibili")
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
                                        If Not (Cp.Ordini.Count = 1 AndAlso Cp.Ordini(0).Ordine.ListinoBase.CalcolaAncheDaSolo = enSiNo.Si) Then
                                            Aggiungi = False
                                        End If
                                    End If
                                End If
                            End If

                            Dim AggiungiAlPostoDi As Boolean = False
                            If Aggiungi AndAlso _ParamSoluzione.NonMostrareTutteleCombinazioni = False Then
                                'qui se e' solo su selezionati devo vedere che non ci siano piu combinazioni di 
                                'idmodello, itiratura, n° ordini

                                'questo non dovrebbe servire più
                                'For Each s In lstFinale
                                If SingSol.Commesse.FindAll(Function(xx) xx.Firma = Cp.Firma).Count <> 0 Then
                                    Aggiungi = False
                                    'AggiungiAlPostoDi = True
                                End If
                                For Each s In lstFinale
                                    If s.Commesse.FindAll(Function(xx) xx.Firma = Cp.Firma).Count <> 0 Then
                                        Aggiungi = False
                                        'AggiungiAlPostoDi = True
                                    End If
                                Next
                                'Next
                                If Aggiungi Then
                                    If SingSol.Commesse.FindAll(Function(x) x.ModelloCommessa.IdModello = Cp.ModelloCommessa.IdModello And
                                                x.Tiratura = Cp.Tiratura And
                                                x.Ordini.Count = Cp.Ordini.Count).Count Then

                                        AggiungiAlPostoDi = True
                                    End If
                                End If
                            End If

                            'If Aggiungi Then
                            '    If Cp.Ordini.FindAll(Function(xo) xo.QtaOrdine = Cp.Tiratura).Count = 0 And
                            '            Cp.Ordini.Count = 1 Then
                            '        Aggiungi = False
                            '    End If
                            'End If

                            If Aggiungi Then
                                If AggiungiAlPostoDi Then
                                    SingSol.AggiungiCommessa(Cp, _ParamSoluzione)
                                Else
                                    'SingSol.AggiungiCommessa(Cp, _ParamSoluzione)
                                    SingSol.Commesse.Add(Cp)
                                End If
                            End If

                            'If Aggiungi Then
                            '    SingSol.AggiungiCommessa(Cp, _ParamSoluzione)
                            'End If

                        End If
                    Next
                    If SingSol.Commesse.Count Then lstFinale.Add(SingSol)
                Next

                'next
            End If

            'lstFinale.Add(soluz)
        Next

        Return lstFinale

    End Function
    Private Shared Function CreaListaFinale(lstOrdEx As List(Of List(Of OrdineInSoluzione)),
                                            Optional EscludiCommesseConSingoloOrdine As Boolean = True) As List(Of Soluzione)

        Dim lstFinale As New List(Of Soluzione)
        Dim ListaInCorso As Integer = 1
        For Each lst As List(Of OrdineInSoluzione) In lstOrdEx
            Dim TipoCartaStr As String = lst(0).Ordine.ListinoBase.TipoCarta.Tipologia
            RaiseEvent AggiornamentoStato("***Creo soluzioni per la lista compatibili " & ListaInCorso & " di " & lstOrdEx.Count & ": " & TipoCartaStr)
            ListaInCorso += 1
            'lst.Sort(AddressOf SortOrdEx)
            'Dim soluz As New SoluzioniPerTipoCarta
            'soluz.TipoCarta = lst(0).Ordine.Prodotto.TipoCarta
            'If soluz.TipoCarta Is Nothing Then soluz.TipoCarta = New TipoCarta With {.Tipologia = "Non specificata"}
            'prendo tutti i formati carta 
            'prendo tutti i modellicommessa che hanno almeno un formato carta
            'ciclo per ogni modello commessa e vedo come lo riempio

            'Dim FronteRetroCom As Boolean = False

            Dim Ml As New List(Of ModelloCommessa)

            For Each O As OrdineInSoluzione In lst

                'If O.Ordine.ListinoBase.ColoreStampa.FR Then
                '    FronteRetroCom = True
                'End If

                'If O.Ordine.Prodotto.FronteRetro Then
                '    FronteRetroCom = True
                'End If

                Using mgr As New ModelliCommessaDAO
                    Dim MlSingO As List(Of ModelloCommessa) = Nothing
                    If _ParamSoluzione.UtilizzaSoloFormatiCarta Then
                        Dim Fl As List(Of FormatoCarta) = Nothing
                        MlSingO = mgr.FindByFormatoCarta(O.Ordine.ListinoBase.FormatoCarta,, _ParamSoluzione.IdMacchinario, True)
                        For Each singMod In MlSingO
                            If Ml.FindAll(Function(x) x.IdModello = singMod.IdModello).Count = 0 Then
                                Ml.Add(singMod)
                            End If
                        Next
                    Else
                        MlSingO = mgr.FindByFormatoProdotto(O.Ordine.ListinoBase.FormatoProdotto, _ParamSoluzione.IdMacchinario)
                        If MlSingO.Count Then
                            For Each singMod In MlSingO
                                If Ml.FindAll(Function(x) x.IdModello = singMod.IdModello).Count = 0 Then
                                    Ml.Add(singMod)
                                End If
                            Next
                        Else
                            Dim Fl As List(Of FormatoCarta) = Nothing
                            MlSingO = mgr.FindByFormatoCarta(O.Ordine.ListinoBase.FormatoCarta,
                                                                ,
                                                                _ParamSoluzione.IdMacchinario,
                                                                False) 'era true
                            For Each singMod In MlSingO
                                If Ml.FindAll(Function(x) x.IdModello = singMod.IdModello).Count = 0 Then
                                    Ml.Add(singMod)
                                End If
                            Next
                        End If
                    End If

                End Using
            Next

            Ml = Ml.FindAll(Function(x) x.FromGanging = enSiNo.No)

            'qui scremo i modelli commessa
            Dim MlFinale As New List(Of ModelloCommessa)
            For Each M As ModelloCommessa In Ml
                Dim Aggiungi As Boolean = True
                For Each fp As ModComFormProd In M.FormatiProdotto
                    If lst.FindAll(Function(x) x.Ordine.ListinoBase.IdFormProd = fp.IdFormProd).Count = 0 Then
                        Aggiungi = False
                        Exit For
                    End If
                Next
                If Aggiungi Then MlFinale.Add(M)
            Next

            If _ParamSoluzione.UtilizzaAncheFormatiCarta Then
                If MlFinale.Count = 0 Then
                    For Each M As ModelloCommessa In Ml
                        Dim Aggiungi As Boolean = True
                        For Each fc As FormatoCarta In M.FormatiCarta
                            If lst.FindAll(Function(x) x.Ordine.ListinoBase.FormatoProdotto.IdCatFormatoProdotto = fc.IdFormCarta).Count = 0 Then
                                Aggiungi = False
                                Exit For
                            End If
                        Next
                        If Aggiungi Then MlFinale.Add(M)
                    Next
                End If
            End If

            Ml = MlFinale

            Ml = Ml.FindAll(Function(x) x.Disattivo = enSiNo.No) 'ESCLUDO I DISATTIVATI

            If lst.Count = lst.FindAll(Function(x) x.Ordine.ListinoBase.ColoreStampa.FR).Count Then
                'qui tutto fronte retro
                Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.Si)
            ElseIf lst.Count = lst.FindAll(Function(x) x.Ordine.ListinoBase.ColoreStampa.FR = False).Count Then
                'qui ci sono solo ordini solofronte
                Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.No)
            End If

            'If FronteRetroCom Then
            '    'qui c'e' almeno un ordine fronteretro
            '    Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.Si)
            'Else
            '    'qui ci sono solo ordini solofronte
            '    Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.No)
            'End If

            If _ParamSoluzione.CreazioneAutomaticaCommesse Then
                Ml = Ml.FindAll(Function(x) x.AbilitatoAutomazione = enSiNo.Si)
            End If

            If Ml.Count Then

                If _ParamSoluzione.IdModelloCommessa Then
                    Ml = Ml.FindAll(Function(x) x.IdModello = _ParamSoluzione.IdModelloCommessa)
                End If

                For Each M As ModelloCommessa In Ml
                    M.CaricaFormatiProdotto()
                    M.CaricaFormatiCarta()
                Next
                Ml.Sort(AddressOf SortModelli)

                Dim Ricorrenze As New List(Of Ricorrenza)
                Dim RicorrenzeStr As String = String.Empty
                For Each singOrd As OrdineInSoluzione In lst
                    Dim R As Ricorrenza = Ricorrenze.Find(Function(Item) Item.Qta = singOrd.QtaOrdine)
                    If R Is Nothing Then
                        R = New Ricorrenza
                        'R.Ordini = New List(Of OrdineInSoluzione)
                        R.Qta = singOrd.QtaOrdine
                        RicorrenzeStr &= R.Qta & ","
                        If R.Qta = 0 Then Stop
                        'R.IdFormatoCarta = singOrd.Ordine.Prodotto.FormatoProdotto.IdFormCarta
                        Ricorrenze.Add(R)
                    End If
                    R.NumeroOrdini += 1
                    'R.Ordini.Add(singOrd)
                Next
                RicorrenzeStr = RicorrenzeStr.TrimEnd(",")

                Ricorrenze.Sort(AddressOf SortRicorrenze)
                RaiseEvent AggiornamentoStato("***Trovate " & Ricorrenze.Count & " ricorrenze: " & RicorrenzeStr)
                'Dim lstNew As New List(Of Ricorrenza)
                Dim Riferimento As Integer = 0
                Dim dicR As New Dictionary(Of Integer, List(Of OrdineInSoluzione))
                'Dim SingSol As New Soluzione
                For Each R As Ricorrenza In Ricorrenze
                    Riferimento = R.Qta 'provo a montare a questa quantita
                    'e raggruppo le altre che non ci montano per quantita tra loro
                    'SingSol.TotOrdiniDaUsare = lst.Count
                    Dim lstOrd As List(Of OrdineInSoluzione) = lst.FindAll(Function(x) x.QtaOrdine >= Riferimento)
                    'SingSol.TotOrdiniDaUsare = lstOrd.Count

                    'SingSol.QtaTiratura = Riferimento


                    'lstOrd.Sort(Function(x, y) y.QtaOrdine.CompareTo(x.QtaOrdine))
                    For Each OS As OrdineInSoluzione In lstOrd
                        Dim O As OrdineInSoluzione = OS.Clone
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

                                If QuanteVolte <= Max Then
                                    If QuanteVolte <= _ParamSoluzione.MaxDuplicazioneSingoloOrdine Then
                                        O.TiratoA = Riferimento
                                    Else
                                        'qui devo vedere se per questa quantita va bene tutto 
                                        If MgrRegoleCalcolo.ExistRegola(O, MgrRegoleCalcolo.ChiaveRegolaUtente.OkConQtaSuperioreA) Then
                                            O.TiratoA = Riferimento
                                        End If

                                    End If
                                End If

                                'If QuanteVolte <= Max AndAlso QuanteVolte <= _ParamSoluzione.MaxDuplicazioneSingoloOrdine Then
                                '    O.TiratoA = Riferimento
                                '    'Else
                                '    '   O.TiratoA = O.QtaOrdine
                                'End If
                                'O.UtilizzatoConTiratura = True
                                'Else
                                '   O.TiratoA = O.QtaOrdine
                                'O.UtilizzatoConTiratura = False
                            End If

                            'vedo se esiste una lista con questa tiratura
                            'senno la creo
                            If O.TiratoA Then
                                Dim lstOrdR As List(Of OrdineInSoluzione) = Nothing
                                dicR.TryGetValue(O.TiratoA, lstOrdR)
                                If lstOrdR Is Nothing Then
                                    lstOrdR = New List(Of OrdineInSoluzione)
                                    dicR.Add(O.TiratoA, lstOrdR)
                                End If
                                lstOrdR.Add(O)
                            End If

                        End If
                    Next
                Next

                For Each item In dicR
                    System.Windows.Forms.Application.DoEvents()
                    Dim SingSol As New Soluzione
                    SingSol.TotOrdiniDaUsare = item.Value.Count
                    Dim LProp As List(Of CommessaProposta) = New List(Of CommessaProposta)

                    Dim IdMacchinarioPrescelto As Integer = 0
                    Dim dicMacch As New Dictionary(Of Integer, Integer)
                    For Each o As OrdineInSoluzione In item.Value
                        'Dim IdMaccOrd As Integer = o.Ordine.ListinoBase.Preventivazione.IdMacchinario 'IDMACCHINARIO
                        Dim IdMaccOrd As Integer = o.Ordine.ListinoBase.IdMacchinarioProduzione 'IDMACCHINARIO
                        If IdMaccOrd <> 0 Then
                            Dim TotMacc As Integer = 0
                            dicMacch.TryGetValue(IdMaccOrd, TotMacc)
                            TotMacc += 1
                            If TotMacc = 1 Then
                                dicMacch.Add(IdMaccOrd, TotMacc)
                            Else
                                dicMacch.Item(IdMaccOrd) = TotMacc
                            End If
                        End If
                    Next

                    For Each items In dicMacch
                        IdMacchinarioPrescelto = items.Key
                    Next

                    'qui scremo i modelli commessa
                    Dim MlFiltrata As New List(Of ModelloCommessa)
                    For Each M As ModelloCommessa In Ml
                        Dim Aggiungi As Boolean = True

                        If _ParamSoluzione.SoloSoluzioniOttimali AndAlso
                                   IdMacchinarioPrescelto <> 0 AndAlso
                                   IdMacchinarioPrescelto <> M.IdMacchinarioDef Then
                            Aggiungi = False
                        End If

                        If Aggiungi Then
                            For Each fp As ModComFormProd In M.FormatiProdotto
                                If item.Value.FindAll(Function(x) x.Ordine.ListinoBase.IdFormProd = fp.IdFormProd).Count = 0 Then
                                    If _ParamSoluzione.UtilizzaAncheFormatiCarta Then
                                        'SPERIMENTALE
                                        If item.Value.FindAll(Function(x) x.Ordine.ListinoBase.FormatoProdotto.IdFormCarta = fp.FormatoProdotto.IdFormCarta).Count = 0 Then
                                            Aggiungi = False
                                            Exit For
                                        End If

                                    Else
                                            Aggiungi = False
                                        Exit For
                                    End If
                                End If

                                'If Aggiungi And 1 = 0 Then 'TODO: CONTROLLARE PERCHE QUESTO BLOCCO VIENE DISABILITATO
                                '    Dim ControllaFp As Boolean = True
                                '    If item.Value.Count = 1 Then
                                '        Dim OSing As OrdineInSoluzione = item.Value(0)
                                '        If OSing.Ordine.ListinoBase.CalcolaAncheDaSolo = enSiNo.Si Then
                                '            ControllaFp = False
                                '        End If
                                '    End If
                                '    If ControllaFp Then
                                '        If _ParamSoluzione.SoloSoluzioniOttimali Then
                                '            Dim TotNegliOrdini As Integer = 0
                                '            For Each O As OrdineInSoluzione In item.Value
                                '                If O.Ordine.ListinoBase.IdFormProd = fp.IdFormProd Then
                                '                    TotNegliOrdini += O.SpaziUsati
                                '                End If
                                '            Next
                                '            If TotNegliOrdini < M.GetNumSpaziFormatoProdotto(fp.IdFormProd) Then
                                '                Aggiungi = False
                                '                Exit For
                                '            End If

                                '        End If
                                '    End If

                                'End If
                            Next
                        End If

                        If Aggiungi Then MlFiltrata.Add(M)
                    Next

                    RaiseEvent AggiornamentoStato("***Trovati " & MlFiltrata.Count & " modelli utilizzabili")

                    For Each M As ModelloCommessa In MlFiltrata
                        'qui devo vedere se 
                        RaiseEvent AggiornamentoStato("****Creo Commesse con modello " & M.Nome)
                        Dim lTemp As List(Of CommessaProposta) = CreaCommesseByModello(item.Value, M)
                        RaiseEvent AggiornamentoStato("****Create " & lTemp.Count & " commesse plausibili")
                        LProp.AddRange(lTemp)
                    Next

                    'LProp = LProp.FindAll(Function(x) x.NumeroFormatiContenuti = x.FormatiCartaTrovati)
                    'LProp.Sort(Function(x, y) y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento))
                    RaiseEvent AggiornamentoStato("***Trovate " & LProp.Count & " commesse plausibili")
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
                                        If Not (Cp.Ordini.Count = 1 AndAlso Cp.Ordini(0).Ordine.ListinoBase.CalcolaAncheDaSolo = enSiNo.Si) Then
                                            Aggiungi = False
                                        End If
                                    End If
                                End If
                            End If

                            Dim AggiungiAlPostoDi As Boolean = False
                            If Aggiungi AndAlso _ParamSoluzione.NonMostrareTutteleCombinazioni = False Then
                                'qui se e' solo su selezionati devo vedere che non ci siano piu combinazioni di 
                                'idmodello, itiratura, n° ordini

                                'questo non dovrebbe servire più
                                'For Each s In lstFinale
                                If SingSol.Commesse.FindAll(Function(xx) xx.Firma = Cp.Firma).Count <> 0 Then
                                    Aggiungi = False
                                    'AggiungiAlPostoDi = True
                                End If
                                For Each s In lstFinale
                                    If s.Commesse.FindAll(Function(xx) xx.Firma = Cp.Firma).Count <> 0 Then
                                        Aggiungi = False
                                        'AggiungiAlPostoDi = True
                                    End If
                                Next
                                'Next
                                If Aggiungi Then
                                    If SingSol.Commesse.FindAll(Function(x) x.ModelloCommessa.IdModello = Cp.ModelloCommessa.IdModello And
                                                x.Tiratura = Cp.Tiratura And
                                                x.Ordini.Count = Cp.Ordini.Count).Count Then

                                        AggiungiAlPostoDi = True
                                    End If
                                End If
                            End If

                            'If Aggiungi Then
                            '    If Cp.Ordini.FindAll(Function(xo) xo.QtaOrdine = Cp.Tiratura).Count = 0 And
                            '            Cp.Ordini.Count = 1 Then
                            '        Aggiungi = False
                            '    End If
                            'End If

                            If Aggiungi Then
                                If AggiungiAlPostoDi Then
                                    SingSol.AggiungiCommessa(Cp, _ParamSoluzione)
                                Else
                                    'SingSol.AggiungiCommessa(Cp, _ParamSoluzione)
                                    SingSol.Commesse.Add(Cp)
                                End If
                            End If

                            'If Aggiungi Then
                            '    SingSol.AggiungiCommessa(Cp, _ParamSoluzione)
                            'End If

                        End If
                    Next
                    If SingSol.Commesse.Count Then lstFinale.Add(SingSol)
                Next

                'next
            End If

            'lstFinale.Add(soluz)
        Next

        Return lstFinale

    End Function

    Public Shared Event AggiornamentoStato(Messaggio As String)

    Private Shared Function CalcolaSoluzioni(listOrd As List(Of OrdineRicerca),
                                             Optional ForzaMacchinarioDigitaleAlternativo As Boolean = False) As List(Of Soluzione)

        Dim lstFinale As New List(Of Soluzione)

        listOrd.Sort(Function(x, y) x.ListinoBase.IdTipoCarta.CompareTo(y.ListinoBase.IdTipoCarta))

        Dim lstOrdEx As List(Of List(Of OrdineInSoluzione)) = CreaListePerCompatibili(listOrd) 'CreaListePerTipoCarta(listOrd)

        RaiseEvent AggiornamentoStato("**Create " & lstOrdEx.Count & " liste per compatibili in base a tipocarta e lavorazioni")

        'qui ho la lista ordini in list per tipocarta
        Dim lSol As List(Of Soluzione) = CreaListaFinale(lstOrdEx)

        For Each s As Soluzione In lSol
            lstFinale.Add(s)
        Next

        Dim SFinalePerfect As New Soluzione

        'qui in lista finale ho tutte le commesse che lui ha ipotizzato

        For Each singSol As Soluzione In lstFinale
            singSol.Commesse = singSol.Commesse.FindAll(Function(x) x.Ordini.Count > 0)
            If _ParamSoluzione.NonMostrareTutteleCombinazioni = True Then
                If _ParamSoluzione.UtilizzaAncheFormatiCarta Then
                    singSol.Commesse = singSol.Commesse.FindAll(Function(x) x.FormatiCartaPrevisti = x.FormatiCartaTrovati)
                Else
                    singSol.Commesse = singSol.Commesse.FindAll(Function(x) x.NumeroFormatiContenuti = x.NumeroFormatiContenutiNegliOrdini)
                End If

            End If

            'singSol.Commesse.Sort(Function(x, y) y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento))

            For Each singC As CommessaProposta In singSol.Commesse
                Dim NumForm As Integer = singC.NumeroFormatiContenutiNegliOrdini
                Dim CalcolaAncheDaSolo As Boolean = False

                If singC.Ordini.Count = 1 Then
                    Dim OSing As OrdineInSoluzione = singC.Ordini(0)
                    '                If OSing.Ordine.ListinoBase.CalcolaAncheDaSolo = enSiNo.Si AndAlso
                    'listOrd.FindAll(Function(x) x.IdListinoBase = OSing.Ordine.IdListinoBase And x.IdOrd <> OSing.IdOrd).Count = 0 Then

                    If OSing.Ordine.ListinoBase.CalcolaAncheDaSolo = enSiNo.Si Then
                        CalcolaAncheDaSolo = True
                    End If
                End If

                If CalcolaAncheDaSolo = False Then
                    'qui devo vedere se per caso rispettya la regola della quantita' 
                    Dim OkConQtaSuperiore As Boolean = True
                    For Each O As OrdineInSoluzione In singC.Ordini
                        If MgrRegoleCalcolo.ExistRegola(O, MgrRegoleCalcolo.ChiaveRegolaUtente.OkConQtaSuperioreA) = False Then
                            OkConQtaSuperiore = False
                            Exit For
                        End If
                    Next

                    If OkConQtaSuperiore Then
                        singC.OkConRegole = True
                        CalcolaAncheDaSolo = True
                    End If
                End If

                If (_ParamSoluzione.SoloSoluzioniOttimali = False Or
                    CalcolaAncheDaSolo = True) And singC.PercentualeCompletamento < 100 Then
                    RielaboraSingolaCommessaIncompleta(singC, True)
                End If

                If _ParamSoluzione.NonMostrareTutteleCombinazioni Then
                    If singC.PercentualeCompletamento = 100 Then
                        Dim Aggiungi As Boolean = True

                        Dim IdMacchinarioDefaultOrdini As Integer = 0

                        If _ParamSoluzione.UtilizzaSoloMacchinarioDefault Then
                            Dim NonControllabile As Boolean = False
                            For Each O As OrdineInSoluzione In singC.Ordini
                                If IdMacchinarioDefaultOrdini = 0 Then
                                    'IdMacchinarioDefaultOrdini = O.Ordine.ListinoBase.Preventivazione.IdMacchinario 'IDMACCHINARIO
                                    IdMacchinarioDefaultOrdini = O.Ordine.ListinoBase.IdMacchinarioProduzione
                                Else
                                    If IdMacchinarioDefaultOrdini <> O.Ordine.ListinoBase.IdMacchinarioProduzione Then '.Preventivazione.IdMacchinario Then
                                        NonControllabile = True
                                    End If
                                End If
                            Next
                            If NonControllabile = False Then
                                If IdMacchinarioDefaultOrdini <> 0 AndAlso
                                    singC.ModelloCommessa.IdMacchinarioDef <> 0 AndAlso
                                    singC.ModelloCommessa.IdMacchinarioDef <> IdMacchinarioDefaultOrdini Then
                                    Aggiungi = False
                                End If
                            End If
                        End If

                        If Aggiungi Then
                            If _ParamSoluzione.SoloSoluzioniOttimali Then
                                'qui prendo solo quelle tirate a uno degli ordini o tirate al giusto del modello commessa
                                If singC.Tiratura <> singC.ModelloCommessa.TiraturaIdeale AndAlso
                                    singC.Ordini.FindAll(Function(y) y.QtaOrdine = singC.Tiratura).Count = 0 AndAlso
                                    CalcolaAncheDaSolo = False Then
                                    Aggiungi = False
                                End If
                            End If
                        End If

                        If Aggiungi Then SFinalePerfect.AggiungiCommessa(singC, _ParamSoluzione)
                    End If


                Else
                    SFinalePerfect.Commesse.Add(singC)
                End If

            Next
        Next

        Dim lstScremata As New List(Of Soluzione)

        If SFinalePerfect.Commesse.Count Then lstScremata.Add(SFinalePerfect)

        Return lstScremata

    End Function

    Private Shared Function CalcolaCostoProduzioneStandard(O As OrdineRicerca) As Decimal
        Dim ris As Decimal = 0
        Dim NumSpazi As Integer = 0
        Using FM As New Formato
            FM.Read(O.ListinoBase.IdFormatoMacchina2)
            Dim sFM As New Size(FM.LarghezzaMM, FM.AltezzaMM)
            Dim sFP As New Size(O.ListinoBase.FormatoProdotto.Larghezza, O.ListinoBase.FormatoProdotto.Lunghezza)

            NumSpazi = MgrCalcoliTecnici.QuanteVolteFormatoInFormato(sFP, sFM).QuantiEntrano



            Dim NLastreNecessarie As Integer = 0
            Dim ListaIdOrdini As Integer()
            ReDim ListaIdOrdini(1)
            ListaIdOrdini(0) = O.IdOrd
            Dim FrSuSeStessa As Integer = enSiNo.No

            If O.ListinoBase.ColoreStampa.FR Then
                FrSuSeStessa = enSiNo.Si
            End If

            Using mgr As New CommesseDAO
                NLastreNecessarie = mgr.GetLastreNecessarie(NumSpazi, FrSuSeStessa, ListaIdOrdini)
            End Using

            ris = NLastreNecessarie * FM.CostoLastra

            'Using mgr As New RisorseDAO
            '    Dim risorsaLastra As Risorsa = mgr.GetLastraPerMacchinario(O.ListinoBase.IdMacchinarioProduzione)

            '    If Not risorsaLastra Is Nothing Then
            '        ris = risorsaLastra.CostoTotale * NLastreNecessarie
            '    End If

            'End Using
        End Using
        Return ris
    End Function
    Private Shared Function CalcolaCostoProduzioneAlternativo(O As OrdineRicerca) As Decimal
        Dim ris As Decimal = 0

        'qui parto dalla quantita e calcolo quanti fogli di quel formato ci stanno nel formato macchina 
        'dopo che ho il numero di copie calcolo il costo copia per la quantita di fogli e ho il costo di produzione
        If Not O.ListinoBase.MacchinarioProduzione2 Is Nothing Then
            Using m As Macchinario = O.ListinoBase.MacchinarioProduzione2
                If m.CostoSingCopia Then

                    Using FM As New Formato
                        FM.Read(O.ListinoBase.IdFormatoMacchina2)
                        Dim sFM As New Size(FM.LarghezzaMM, FM.AltezzaMM)
                        Dim sFP As New Size(O.ListinoBase.FormatoProdotto.Larghezza, O.ListinoBase.FormatoProdotto.Lunghezza)

                        Dim QtaSpazi As Integer = MgrCalcoliTecnici.QuanteVolteFormatoInFormato(sFP, sFM).QuantiEntrano
                        Dim QtaTiratura As Integer = 0

                        If O.ListinoBase.ColoreStampa.FR Then
                            QtaTiratura = O.Qta * 2
                        Else
                            QtaTiratura = O.Qta
                        End If

                        QtaTiratura = QtaTiratura * O.NFogli

                        ris = Math.Ceiling(QtaTiratura / QtaSpazi) * m.CostoSingCopia

                    End Using

                End If
            End Using
        End If

        'ris = 1 'TODO:TOGLIERE PRIMA DEL RILASCIO

        Return ris
    End Function
    Friend Shared Function ProponiSoluzioni(ByVal listOrd As List(Of OrdineRicerca),
                                            ParamSoluzione As ParametriCreazioneSoluzione) As List(Of Soluzione)

        '**********
        'ENTRYPOINT
        '**********

        _ParamSoluzione = ParamSoluzione

        idComP = 1

        Dim lstSoluzioni As New List(Of Soluzione)
        Dim SoluzioneFinale As New Soluzione

        RaiseEvent AggiornamentoStato("#Motore avviato")

        Dim lstEsclusiPerProduzioneOttimizzata As New List(Of OrdineRicerca)

        If ParamSoluzione.SelezionaMacchinarioInBaseACostoDiProduzione Then
            'qui vado a togliere gli ordini che calcolati con il secondo macchinario hanno un costo di produzione piu basso

            For Each o As OrdineRicerca In listOrd
                If o.ListinoBase.IdMacchinarioProduzione2 <> 0 Then
                    If o.QtaOrdine <= o.ListinoBase.qta1 Then
                        'qui devo andare a vedere se costa meno con il secondo macchinario e in quel caso toglierlo dalla lista
                        'e calcolarlo poi a parte con il secondo macchinario
                        Dim CostoProduzioneStandard As Decimal = 0
                        Dim CostoProduzioneAlternativo As Decimal = 0

                        'per calcolare il costo produzione standard devo calcolare il costo delle lastre in base al modello commessa 
                        'calcolando l'ordine da solo 

                        CostoProduzioneStandard = CalcolaCostoProduzioneStandard(o)
                        CostoProduzioneAlternativo = CalcolaCostoProduzioneAlternativo(o)

                        If CostoProduzioneAlternativo > 0 AndAlso CostoProduzioneAlternativo < CostoProduzioneStandard Then
                            lstEsclusiPerProduzioneOttimizzata.Add(o)
                        End If

                    End If
                End If
            Next

            For Each o As OrdineRicerca In lstEsclusiPerProduzioneOttimizzata
                listOrd.Remove(o)
            Next

        End If

        Dim SoluzioniTrovate As List(Of Soluzione) = CalcolaSoluzioni(listOrd)

        'If SoluzioniTrovate.Count = 0 Then
        '    SoluzioniTrovate = CalcolaSoluzioni(listOrd)
        'End If

        'While SoluzioniTrovate.Count

        While SoluzioniTrovate.Count
            RaiseEvent AggiornamentoStato("#Aggiungo le " & SoluzioniTrovate.Count & " soluzioni trovate alla lista finale")
            For Each s As Soluzione In SoluzioniTrovate
                For Each C As CommessaProposta In s.Commesse
                    SoluzioneFinale.Commesse.Add(C)

                    For Each O As OrdineInSoluzione In C.Ordini
                        listOrd.Remove(O.Ordine)
                    Next

                Next
            Next
            RaiseEvent AggiornamentoStato("#Calcolo soluzioni con i " & listOrd.Count & " ordini rimasti")
            'If _ParamSoluzione.SoloSoluzioniOttimali = False Then
            SoluzioniTrovate = CalcolaSoluzioni(listOrd)
            'Else
            'Exit While
            'End If

        End While
        'For Each s As Soluzione In SoluzioniTrovate
        '    For Each C As CommessaProposta In s.Commesse
        '        SoluzioneFinale.Commesse.Add(C)
        '    Next
        'Next

        If lstEsclusiPerProduzioneOttimizzata.Count Then
            RaiseEvent AggiornamentoStato("*****Calcolo commesse con macchinario alternativo")
            CalcolaCommesseConMacchinarioAlternativo(lstEsclusiPerProduzioneOttimizzata, SoluzioneFinale)

        End If

        If _ParamSoluzione.SoloSoluzioniOttimali Then
            SoluzioneFinale.Commesse = SoluzioneFinale.Commesse.FindAll(Function(x) x.Ottimale = True)
        ElseIf _ParamSoluzione.NonMostrareTutteleCombinazioni = False Then
            'prendo la prima per vedere quanto e' il limite piu alto trovato tra tutte le combinazioni

            If _ParamSoluzione.TagliaCombinazioniSottoXPercento Then
                If SoluzioneFinale.Commesse.Count Then
                    SoluzioneFinale.Commesse.Sort(Function(x, y) y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento))
                    Dim LimiteMax As Integer = SoluzioneFinale.Commesse(0).PercentualeCompletamento
                    Dim LimiteMinimo As Integer = LimiteMax - 50
                    SoluzioneFinale.Commesse = SoluzioneFinale.Commesse.FindAll(Function(x) x.PercentualeCompletamento >= LimiteMinimo)

                End If
            End If

        End If

        RaiseEvent AggiornamentoStato("#Calcolo soluzioni terminato")

        lstSoluzioni.Add(SoluzioneFinale)

        Return lstSoluzioni

    End Function
    Private Shared Sub CalcolaCommesseConMacchinarioAlternativo(lstEsclusiPerProduzioneOttimizzata As List(Of OrdineRicerca),
                                                                ByRef soluzioneFinale As Soluzione)

        For Each o As OrdineRicerca In lstEsclusiPerProduzioneOttimizzata
            Dim c As New CommessaProposta
            Dim OiS As New OrdineInSoluzione
            OiS.Ordine = o
            Dim QtaTiratura As Integer = o.Qta
            Dim NumSpaziCalcolati As Integer = 0
            Using FM As New Formato
                FM.Read(o.ListinoBase.IdFormatoMacchina2)
                Dim sFM As New Size(FM.LarghezzaMM, FM.AltezzaMM)
                Dim sFP As New Size(o.ListinoBase.FormatoProdotto.Larghezza, o.ListinoBase.FormatoProdotto.Lunghezza)

                NumSpaziCalcolati = MgrCalcoliTecnici.QuanteVolteFormatoInFormato(sFP, sFM).QuantiEntrano

                'If o.ListinoBase.ColoreStampa.FR Then
                '    QtaTiratura = o.Qta * 2
                'End If

                QtaTiratura = Math.Ceiling(QtaTiratura / NumSpaziCalcolati)

            End Using
            OiS.TiratoA = QtaTiratura

            Dim L As List(Of ModelloCommessa) = Nothing
            Dim M As ModelloCommessa = Nothing
            Using mgr As New ModelliCommessaDAO
                L = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ModelloCommessa.IdReparto, enRepartoWeb.StampaDigitale))
                If L.Count Then
                    M = L(0)
                End If

                If Not M Is Nothing Then
                    c.Tiratura = OiS.TiratoA
                    M.IdMacchinarioDef = o.ListinoBase.IdMacchinarioProduzione2
                    M.NumSpazi = NumSpaziCalcolati
                    c.ModelloCommessa = M
                    c.Id = idComP

                    idComP += 1
                    c.Ordini.Add(OiS.Clone)
                    soluzioneFinale.Commesse.Add(c)
                End If


            End Using


        Next

    End Sub

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

    Private Shared Function CreaCommesseByModello(lstO As List(Of OrdineInSoluzione),
                                            m As ModelloCommessa) As List(Of CommessaProposta)

        'qui prima creo tutte le possibili combinazioni di ordini, poi ognuna di queste provo a montarla per ognuno dei modelli 
        Dim lcom As New List(Of CommessaProposta)

        'For Each m As ModelloCommessa In lstM
        'If m.IdModello = 26 Then Stop
        'If ProvaSuFormatoProdotto Then
        For Each f As ModComFormProd In m.FormatiProdotto
            Dim lstOSpec As New List(Of OrdineInSoluzione)
            lstOSpec.AddRange(lstO.FindAll(Function(x) x.Ordine.ListinoBase.IdFormProd = f.IdFormProd))
            If _ParamSoluzione.UtilizzaAncheFormatiCarta Then
                If lstOSpec.Count = 0 Then
                    lstOSpec.AddRange(lstO.FindAll(Function(x) x.Ordine.ListinoBase.FormatoProdotto.IdFormCarta = f.FormatoProdotto.IdFormCarta))
                End If

                If lstOSpec.Count < lstO.Count Then
                    Dim lstOSpecEx As New List(Of OrdineInSoluzione)
                    lstOSpecEx.AddRange(lstO.FindAll(Function(x) x.Ordine.ListinoBase.FormatoProdotto.IdFormCarta = f.FormatoProdotto.IdFormCarta))

                    If lstOSpecEx.Count > lstOSpec.Count Then
                        lstOSpec = lstOSpecEx
                    End If

                End If

            End If
            RaiseEvent AggiornamentoStato("*****Lavoro formato prodotto " & f.FormatoProdotto.Formato)
            If lstOSpec.Count Then

                Dim MaxSpazi As Integer = m.GetNumSpaziFormatoProdotto(f.IdFormProd)
                Dim OkCheckSpecifico As Boolean = True

                '**********************************
                'TODO:10/10/2019 - MODIFICATO CHECK SPECIFICO 
                '**********************************
                If MaxSpazi >= 15 And lstO(0).TiratoA < 500 Then
                    OkCheckSpecifico = False
                End If

                'If MaxSpazi >= 15 Then

                '    If lstO(0).TiratoA < 500 Then
                '        If lstO(0).TiratoA <> lstO(0).QtaOrdine Then
                '            OkCheckSpecifico = False
                '        End If
                '    End If

                '    'OkCheckSpecifico = False
                'End If

                If OkCheckSpecifico Then

                    Dim mySubsets As New List(Of List(Of OrdineInSoluzione))

                    'Dim LimiteMax As Integer = MaxSpazi
                    'If MaxSpazi > lstOSpec.Count Then LimiteMax = lstOSpec.Count
                    Dim UsaMotoreVeloce As Boolean = False
                    Dim SommaSpaziOrdini As Integer = lstOSpec.Sum(Function(x) x.SpaziUsati)
                    'If MaxSpazi > 15 AndAlso SommaSpaziOrdini > MaxSpazi Then
                    '    'qui se c'e' troppa differenza tra spazi negli ordini e spazi nel modello devo chiamare la funzione 
                    '    'nuova
                    '    Dim Rapporto As Integer = (SommaSpaziOrdini * 100) / MaxSpazi

                    '    If Rapporto > 125 Then
                    '        UsaMotoreVeloce = True
                    '    End If

                    'End If

                    'If UsaMotoreVeloce And 1 = 0 Then ' _ParamSoluzione.UtilizzaCalcoloVeloce Then
                    '    'qui prima devo passare gli ordini ordinati partendo dalla tiratura ottimale per quel modello commessa se impostata
                    '    'altrimenti no
                    '    mySubsets = CombinationEx.GetSubsetsEx(lstOSpec.ToArray, MaxSpazi, _ParamSoluzione)
                    'Else

                    mySubsets = CombinationEx.GetSubsets(lstOSpec.ToArray, MaxSpazi, _ParamSoluzione)
                    RaiseEvent AggiornamentoStato("*****Calcolate " & mySubsets.Count & " combinazioni possibili")
                    'End If

                    'Clear the display.
                    'SORT DISATTIVATO CHE PER ORA NN MI SERVE
                    'Combination.Sort(mySubsets)

                    For Each s As Object In mySubsets
                        Dim lstOrd As List(Of OrdineInSoluzione) = s

                        'QUI PROVO AD ANDARE IN SOSTITUZIONE PER VEDERE SE CI SONO POSSIBILITA MIGLIORI NEGLI ORDINI SCARTATI 
                        If SommaSpaziOrdini > MaxSpazi Then lstOrd = ProvaSostituzioni(lstOrd, lstOSpec)


                        Dim Continua As Boolean = True
                        If m.FronteRetro = enSiNo.Si Then
                            'qui solo fronte
                            If lstOrd.FindAll(Function(X) X.Ordine.ListinoBase.ColoreStampa.FR).Count = 0 Then
                                Continua = False
                                'se non trovo almeno un fr abortisco il tentativo
                            End If
                        Else
                            'qui solo fronte
                            If lstOrd.FindAll(Function(X) X.Ordine.ListinoBase.ColoreStampa.FR).Count Then
                                Continua = False
                                'se trovo almeno un fr abortisco il tentativo
                            End If
                        End If

                        If Continua Then

                            Dim SommaSpazi As Integer = 0
                            Dim Tiratura As Integer = 0
                            For Each O As OrdineInSoluzione In lstOrd
                                SommaSpazi += O.SpaziUsati
                                Tiratura = O.TiratoA
                            Next
                            'If OkLav Then
                            'If SommaSpazi <= MaxSpazi Then
                            'qui e' una combinazione valida

                            Dim CmSolo As CommessaProposta = Nothing

                            If _ParamSoluzione.AccorpaCommesse Then
                                CmSolo = lcom.Find(Function(x) x.ModelloCommessa.IdModello = m.IdModello And
                                                               x.Tiratura = Tiratura And
                                                               x.SpaziDisponibiliFP(f.IdFormProd) >= SommaSpazi And
                                                               x.SpaziUsatiFP(f.IdFormProd) = 0)
                            End If

                            If CmSolo Is Nothing Then
                                CmSolo = New CommessaProposta
                                CmSolo.Tiratura = lstOrd(0).TiratoA
                                CmSolo.ModelloCommessa = m
                                CmSolo.Id = idComP
                                idComP += 1
                                lcom.Add(CmSolo)
                            End If

                            For Each O As OrdineInSoluzione In lstOrd
                                CmSolo.Ordini.Add(O.Clone)
                            Next

                        End If

                    Next
                End If
            End If
        Next
        'Else
        '    For Each f As FormatoCarta In m.FormatiCarta
        '        Dim lstOSpec As New List(Of OrdineInSoluzione)
        '        lstOSpec.AddRange(lstO.FindAll(Function(x) x.Ordine.ListinoBase.FormatoProdotto.IdFormCarta = f.IdFormCarta))

        '        If lstOSpec.Count Then
        '            Dim MaxSpazi As Integer = m.GetNumSpaziFormatoCarta(f.IdFormCarta)

        '            Dim mySet(lstOSpec.Count - 1) As Object

        '            For I As Integer = 0 To lstOSpec.Count - 1
        '                mySet(I) = lstOSpec(I).IdOrd
        '            Next
        '            Dim mySubsets As New List(Of List(Of Object))

        '            Dim LimiteMax As Integer = MaxSpazi
        '            If MaxSpazi > lstOSpec.Count Then LimiteMax = lstOSpec.Count

        '            mySubsets = Combination.GetSubsets(mySet, LimiteMax)
        '            'Clear the display.
        '            Combination.Sort(mySubsets)

        '            For Each s As Object In mySubsets
        '                Dim lstOrd As New List(Of OrdineInSoluzione)

        '                For Each o In s
        '                    lstOrd.Add(lstO.Find(Function(x) x.IdOrd = o))
        '                Next
        '                'questi sono ordini di questa soluzione 
        '                'se la somma degli spazi è maggiore gia scarto la combinazione
        '                Dim SommaSpazi As Integer = 0
        '                Dim Tiratura As Integer = 0
        '                For Each O As OrdineInSoluzione In lstOrd
        '                    SommaSpazi += O.SpaziUsati
        '                    Tiratura = O.TiratoA
        '                Next

        '                If SommaSpazi <= MaxSpazi Then
        '                    'qui e' una combinazione valida
        '                    Dim CmSolo As CommessaProposta = Nothing

        '                    CmSolo = lcom.Find(Function(x) x.ModelloCommessa.IdModello = m.IdModello And
        '                                           x.Tiratura = Tiratura And
        '                                           x.SpaziDisponibili(f.IdFormCarta) >= SommaSpazi)

        '                    If CmSolo Is Nothing Then
        '                        CmSolo = New CommessaProposta
        '                        CmSolo.Tiratura = Tiratura
        '                        CmSolo.ModelloCommessa = m
        '                        CmSolo.Id = idComP
        '                        idComP += 1
        '                        lcom.Add(CmSolo)
        '                    End If

        '                    For Each O As OrdineInSoluzione In lstOrd
        '                        CmSolo.Ordini.Add(O.Clone)
        '                    Next

        '                End If
        '            Next
        '        End If
        '    Next
        'End If


        'qui ho tutti gli ordini che stanno in questo modello ora li devo mischiare tutti a gruppi di N per quanti sono i spazi di quel determinato formato prodotto
        ' Next
        RaiseEvent AggiornamentoStato("*****Provo a sostituire gli ordini peggiori nelle commesse trovate")
        For Each singC As CommessaProposta In lcom
            Dim CalcolaAncheDaSolo As Boolean = False

            If singC.Ordini.Count = 1 Then
                Dim OSing As OrdineInSoluzione = singC.Ordini(0)
                If OSing.Ordine.ListinoBase.CalcolaAncheDaSolo = enSiNo.Si AndAlso
                        singC.Ordini.FindAll(Function(x) x.Ordine.IdListinoBase = OSing.Ordine.IdListinoBase And x.IdOrd <> OSing.IdOrd).Count = 0 Then
                    CalcolaAncheDaSolo = True
                End If
            End If

            If (_ParamSoluzione.SoloSoluzioniOttimali = False Or
                    CalcolaAncheDaSolo = True) And singC.PercentualeCompletamento < 100 Then
                RielaboraSingolaCommessaIncompleta(singC, True)
            End If

            'If singC.ModelloCommessa.IdModello = 85 Then Stop

            singC.Ordini = ProvaSostituzioni(singC.Ordini, lstO)

            'If singC.ModelloCommessa.IdModello = 85 Then Stop

        Next

        Return lcom

    End Function

    Private Shared Function Comparer(x As OrdineInSoluzione, y As OrdineInSoluzione) As Integer
        Dim ris As Integer = y.Ordine.ConsegnaAssociata.Giorno.CompareTo(x.Ordine.ConsegnaAssociata.Giorno)
        If ris = 0 Then
            ris = x.Ordine.IdRub.CompareTo(y.Ordine.IdRub)
        End If

        Return ris
    End Function

    Private Shared Function ProvaSostituzioni(ByVal LStart As List(Of OrdineInSoluzione),
                                              ByVal OrdiniDisp As List(Of OrdineInSoluzione)) As List(Of OrdineInSoluzione)

        'PROVA A SOSTITURE GLI ORDINI RIMASTI NELLA COMMESSA PER VEDERE SE NE TROVA UNA COMBINAZIONE MIGLIORE
        Dim L As New List(Of OrdineInSoluzione)

        L.AddRange(LStart)

        Dim LInutilizzati As List(Of OrdineInSoluzione) = OrdiniDisp.FindAll(Function(x) L.FindAll(Function(y) y.IdOrd = x.IdOrd).Count = 0)

        'ora devo vedere se qualsiasi ordine di quelli inutilizzati e' migliore di uno di quelli utilizzati
        For Each O As OrdineInSoluzione In LInutilizzati
            Dim ListaCompatibili As New List(Of OrdineInSoluzione)
            ListaCompatibili.AddRange(L.FindAll(Function(x) x.SpaziUsati = O.SpaziUsati And x.TiratoA = O.TiratoA And x.Ordine.ListinoBase.FormatoProdotto.IdFormCarta = O.Ordine.ListinoBase.FormatoProdotto.IdFormCarta))
            ListaCompatibili.Sort(AddressOf Comparer)
            Dim DataO As Date = O.Ordine.ConsegnaAssociata.Giorno
            If O.Ordine.DataPrevConsegna < O.Ordine.ConsegnaAssociata.Giorno Then
                DataO = O.Ordine.DataPrevConsegna
            End If
            For Each Oexist In ListaCompatibili
                Dim DataE As Date = Oexist.Ordine.ConsegnaAssociata.Giorno
                If Oexist.Ordine.DataPrevConsegna < Oexist.Ordine.ConsegnaAssociata.Giorno Then
                    DataE = Oexist.Ordine.DataPrevConsegna
                End If

                Dim Sostituisci As Boolean = False
                If DataE > DataO Then
                    'sostituisci
                    Sostituisci = True
                ElseIf DataE = DataO Then
                    'stesso giorno guardo quanti clienti ci sono di entrambi dentro 
                    Dim cOrdiniPres As Integer = 0
                    Dim cOrdiniNuovo As Integer = 0
                    cOrdiniPres = L.FindAll(Function(x) x.Ordine.IdRub = Oexist.Ordine.IdRub).Count
                    cOrdiniNuovo = L.FindAll(Function(x) x.Ordine.IdRub = O.Ordine.IdRub).Count

                    If cOrdiniPres < cOrdiniNuovo Then
                        Sostituisci = True
                    ElseIf cOrdiniPres = cOrdiniNuovo Then
                        If O.IdOrd < Oexist.IdOrd Then
                            Sostituisci = True
                        End If
                    End If

                End If

                If Sostituisci Then
                    'qui lo devo sostituire con questo
                    L.Remove(Oexist)
                    L.Add(O.Clone)
                    Exit For
                End If
            Next
        Next

        Return L

    End Function


    Private Shared Function CreaCommesseEx(lstO As List(Of OrdineInSoluzione),
                                         lstM As List(Of ModelloCommessa),
                                         Optional EscludiCommesseConSingoloOrdine As Boolean = True) As List(Of CommessaProposta)

        'qui prima creo tutte le possibili combinazioni di ordini, poi ognuna di queste provo a montarla per ognuno dei modelli 
        Dim lcom As New List(Of CommessaProposta)

        Dim mySet(lstO.Count - 1) As Object

        For I As Integer = 0 To lstO.Count - 1
            mySet(I) = lstO(I).IdOrd
        Next

        For i As Integer = 1 To mySet.Count
            Dim mySubsets As New List(Of List(Of Object))
            mySubsets = Combination.GetSubsets(mySet, i)
            'Clear the display.
            Combination.Sort(mySubsets)

            For Each s As Object In mySubsets

                Dim lstOrd As New List(Of OrdineInSoluzione)

                For Each o In s
                    lstOrd.Add(lstO.Find(Function(x) x.IdOrd = o))
                Next

                'qui ho la lista di ordini da trattare che possono essere uno o 100 

                For Each o As OrdineInSoluzione In lstO

                    If Not o.Ordine.Prodotto.FormatoProdotto Is Nothing Then

                        Dim IdFormatoCarta As Integer = o.Ordine.Prodotto.FormatoProdotto.IdFormCarta
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
            Next
        Next

        Return lcom
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
        Dim result As Integer = y.Ordine.QtaOrdine.CompareTo(x.QtaOrdine) ' y.Ordine.Prodotto.NumPezzi.CompareTo(x.Ordine.Prodotto.NumPezzi) 'MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO

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