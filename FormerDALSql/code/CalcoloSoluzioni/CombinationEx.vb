'Author: Arman Ghazanchyan
'Created date: 10/10/2006
'Updated date: 10/30/2008

''' <summary>
''' Provides methods to generate and calculate unique combinations.
''' </summary>

Public Class CombinationEx : Implements IComparer(Of List(Of OrdineInSoluzione))

#Region " Methods "

    ''' <summary>
    ''' Gets a nested(2D) list of unique combinations.
    ''' </summary>
    ''' <param name="items">A list(set) of objects from which 
    ''' the unique combinations of subsets should be returned.</param>
    ''' <param name="k">The subset size.</param>

    ''' 

    Private Shared Function CalcolaFirma(l As List(Of OrdineInSoluzione)) As String
        Dim R As String = String.Empty
        l.Sort(Function(x, y) x.IdOrd.CompareTo(y.IdOrd))
        For Each o As OrdineInSoluzione In l
            R &= o.IdOrd & "-"
        Next
        R.TrimEnd("-")
        Return R
    End Function

    Private Shared Function GetSpaziUsati(l As List(Of OrdineInSoluzione)) As Integer
        Dim ris As Integer = 0

        ris = l.Sum(Function(x) x.SpaziUsati)

        Return ris
    End Function

    Private Shared Function Comparer(x As OrdineInSoluzione, y As OrdineInSoluzione) As Integer
        'Dim ris As Integer = x.Ordine.ConsegnaAssociata.Giorno.CompareTo(y.Ordine.ConsegnaAssociata.Giorno)
        'If ris = 0 Then
        '    ris = x.SpaziUsati.CompareTo(y.SpaziUsati)
        '    If ris = 0 Then
        '        ris = x.Ordine.IdRub.CompareTo(y.Ordine.IdRub)
        '    End If
        'End If
        Dim ris As Integer = x.SpaziUsati.CompareTo(y.SpaziUsati)


        Return ris
    End Function

    Public Shared Function GetSubsetsEx(ByVal items() As OrdineInSoluzione,
                                     ByVal kk As Integer,
                                     ByVal Ps As ParametriCreazioneSoluzione) As List(Of List(Of OrdineInSoluzione))

        Dim ListOrdini As List(Of OrdineInSoluzione) = items.ToList
        Dim SommaSpazi As Integer = ListOrdini.Sum(Function(x) x.SpaziUsati)
        Dim finalList As New List(Of List(Of OrdineInSoluzione))

        Dim firstSubList As New List(Of OrdineInSoluzione)
        For Each O In ListOrdini
            firstSubList.Add(O)
        Next

        If kk = SommaSpazi Then
            finalList.Add(firstSubList)
        ElseIf kk > SommaSpazi Then
            finalList.Add(firstSubList)
        ElseIf kk < SommaSpazi Then
            'qui devo trovare tutte le combinazioni in cui la somma degli spazi da kk 
            'qui prendo i primi KK dalla lista che riesco a creare
            Dim TiraturaRif As Integer = ListOrdini(0).TiratoA
            firstSubList.Clear()
            Dim LCorretti As List(Of OrdineInSoluzione) = ListOrdini.FindAll(Function(x) x.QtaOrdine = TiraturaRif)
            LCorretti.Sort(AddressOf Comparer)
            If LCorretti.Count >= kk Then
                'qui dentro c'ho la soluzione
                For i As Integer = 0 To kk - 1
                    firstSubList.Add(LCorretti(i))
                Next
            Else
                Dim PossoMontare As Boolean = True

                If kk Mod 2 = 0 Then
                    'pari
                    If LCorretti.Count Mod 2 = 0 Then
                        'pari
                        Dim TrovatoPari As Boolean = False
                        For Each O In ListOrdini
                            If O.SpaziUsati Mod 2 = 0 Then
                                TrovatoPari = True
                                Exit For
                            End If
                        Next
                        If TrovatoPari = False Then
                            If LCorretti.Count > 2 Then
                                LCorretti.RemoveAt(LCorretti.Count - 1)
                            Else
                                PossoMontare = False
                            End If
                        End If
                    Else
                        'dispari
                        Dim TrovatoDispari As Boolean = False
                        For Each O In ListOrdini
                            If O.SpaziUsati Mod 2 <> 0 Then
                                TrovatoDispari = True
                                Exit For
                            End If
                        Next
                        If TrovatoDispari = False Then
                            If LCorretti.Count <> 1 Then
                                LCorretti.RemoveAt(LCorretti.Count - 1)
                            Else
                                PossoMontare = False
                            End If
                        End If
                    End If
                Else
                    'dispari
                    If LCorretti.Count Mod 2 <> 0 Then
                        'dispari
                        Dim TrovatoPari As Boolean = False
                        For Each O In ListOrdini
                            If O.SpaziUsati Mod 2 = 0 Then
                                TrovatoPari = True
                                Exit For
                            End If
                        Next
                        If TrovatoPari = False Then
                            If LCorretti.Count <> 1 Then
                                LCorretti.RemoveAt(LCorretti.Count - 1)
                            Else
                                PossoMontare = False
                            End If
                        End If
                    Else
                        'pari
                        Dim TrovatoDispari As Boolean = False
                        For Each O In ListOrdini
                            If O.SpaziUsati Mod 2 <> 0 Then
                                TrovatoDispari = True
                                Exit For
                            End If
                        Next
                        If TrovatoDispari = False Then
                            If LCorretti.Count > 2 Then
                                LCorretti.RemoveAt(LCorretti.Count - 1)
                            Else
                                PossoMontare = False
                            End If
                        End If
                    End If
                End If
                If PossoMontare Then
                    firstSubList.AddRange(LCorretti)

                    Dim ListaAltri As List(Of OrdineInSoluzione) = ListOrdini.FindAll(Function(X) firstSubList.FindAll(Function(Y) X.IdOrd = Y.IdOrd).Count = 0)
                    ListaAltri.Sort(AddressOf Comparer)
                    For Each o In ListaAltri
                        Dim SommaSpaziUsati As Integer = firstSubList.Sum(Function(x) x.SpaziUsati)

                        If o.SpaziUsati + SommaSpaziUsati <= kk Then
                            firstSubList.Add(o)
                        End If
                    Next

                    If firstSubList.Sum(Function(x) x.SpaziUsati) = kk Then
                        finalList.Add(firstSubList)
                    End If

                End If
            End If

        End If

        Return finalList

    End Function

    Public Shared Function GetListeSpazi(ListaOrdini As List(Of OrdineInSoluzione), kk As Integer) As List(Of ListEx)
        Dim ris As New List(Of ListEx)
        ListaOrdini.Sort(Function(x, y) x.SpaziUsati.CompareTo(y.SpaziUsati))
        Dim SingList As New ListEx
        Dim Start As Integer = 0
        For Each O As OrdineInSoluzione In ListaOrdini
            If (SingList.Sum(Function(z) z.SpaziUsati) + O.SpaziUsati) <= kk Then
                SingList.Add(O)
                Dim ListaAltri As List(Of OrdineInSoluzione) = ListaOrdini.FindAll(Function(h) h.IdOrd <> O.IdOrd)
                For Start = 0 To ListaAltri.Count - 1
                    'qui devo shiftare la listaaltri di 1 posizione

                    ListaAltri = ShiftList(ListaAltri)

                    For Each Y As OrdineInSoluzione In ListaAltri
                        If ((SingList.Sum(Function(z) z.SpaziUsati) + Y.SpaziUsati) <= kk AndAlso SingList.FindAll(Function(m) m.IdOrd = Y.IdOrd).Count = 0) Then
                            SingList.Add(Y)
                        End If
                    Next

                    If ris.FindAll(Function(x) x.Firma = SingList.Firma).Count = 0 Then
                        ris.Add(SingList)
                    End If
                    SingList = New ListEx
                    SingList.Add(O)
                Next
            End If
            
        Next

        Return ris
    End Function

    Private Shared Function ShiftList(L As List(Of OrdineInSoluzione)) As List(Of OrdineInSoluzione)

        Dim ris As List(Of OrdineInSoluzione)
        ris = L
        ris = ris.Skip(1).ToList
        ris.Add(L(0))
        Return ris

    End Function

    Public Shared Function GetSubsets(ByVal items() As OrdineInSoluzione,
                                      ByVal kk As Integer,
                                      ByVal Ps As ParametriCreazioneSoluzione) As List(Of List(Of OrdineInSoluzione))

        Dim ListOrdini As List(Of OrdineInSoluzione) = items.ToList
        Dim SommaSpazi As Integer = ListOrdini.Sum(Function(x) x.SpaziUsati)
        Dim finalList As New List(Of ListEx)
        'Dim finalList As New List(Of List(Of OrdineInSoluzione))
        'If kk > SommaSpazi Then kk = SommaSpazi
        'Dim Start As Integer = 1
        Dim Start As Integer = 1

        'If Ps.SoloSoluzioniOttimali Then
        '    If kk = SommaSpazi Then
        '        Start = kk
        '    ElseIf kk < SommaSpazi Then
        '        'kk = SommaSpazi
        '        Start = kk
        '    End If
        'End If
        Dim OrdiniTuttiEquivalenti As Boolean = True
        For Each O As OrdineInSoluzione In items 'k-1s
            If ListOrdini.FindAll(Function(x) x.SpaziUsati <> O.SpaziUsati Or x.IDFormatoProdottoRif <> O.IDFormatoProdottoRif).Count Then
                OrdiniTuttiEquivalenti = False
            End If
        Next

        If kk > SommaSpazi Then kk = SommaSpazi
        'If kk > SommaSpazi Then kk = SommaSpazi

        'Dim Combinazioni As List(Of ListEx) = GetListeSpazi(ListOrdini, kk)

        If kk = SommaSpazi Then
            'qui creo una sola combinazione senza fare altro 
            Dim UniqueList As New ListEx
            For Each O As OrdineInSoluzione In ListOrdini 'k-1s
                UniqueList.Add(O)
            Next
            finalList.Add(UniqueList)
        Else
            For Each Lista As ListEx In GetListeSpazi(ListOrdini, kk)
                finalList.Add(Lista)
            Next
        End If


        '******************************************************
        'If kk = SommaSpazi Then
        '    'qui creo una sola combinazione senza fare altro 
        '    Dim UniqueList As New ListEx
        '    For Each O As OrdineInSoluzione In ListOrdini 'k-1s
        '        UniqueList.Add(O)
        '    Next
        '    finalList.Add(UniqueList)
        'ElseIf OrdiniTuttiEquivalenti Then
        '    'qui mi sono stati passati x ordini tutti uguali come spazi occupati
        '    'ma sono di piu degli spazi disponibili, prendo i primi x 
        '    Dim UniqueList As New ListEx
        '    For Each O As OrdineInSoluzione In ListOrdini
        '        If (UniqueList.Sum(Function(y) y.SpaziUsati) + O.SpaziUsati) <= kk Then
        '            UniqueList.Add(O)
        '        End If
        '    Next
        '    finalList.Add(UniqueList)
        'Else

        '    For K As Integer = Start To kk
        '        System.Windows.Forms.Application.DoEvents()
        '        Dim i As Integer = K 'ListOrdini.Count
        '        Dim n As Integer = items.Length

        '        i -= 1
        '        'Add the objects to the first sub list.
        '        Dim indexs(K - 1) As Integer 'k-1
        '        Dim firstSubList As New ListEx
        '        For j As Integer = 0 To K - 1 'k-1s
        '            If j <= UBound(items) Then
        '                indexs(j) = j
        '                firstSubList.Add(items(j))
        '            End If
        '        Next
        '        'Add the first sub list to the parent list.
        '        'finalList.Add(firstSubList)
        '        If SommaSpazi <= K Then
        '            finalList.Add(firstSubList)
        '        End If
        '        'Continue adding lasts.
        '        'While finalList.Count < 2147483647
        '        While indexs(0) <> n - K AndAlso finalList.Count < 2147483647
        '            System.Windows.Forms.Application.DoEvents()
        '            If i > items.Count - 1 OrElse i < 0 Then
        '                'If i > kk - 1 OrElse i < 0 Then
        '                Exit While
        '            End If

        '            If indexs(i) < i + (n - K) Then
        '                indexs(i) += 1
        '                Dim subList As New ListEx

        '                For Each j As Integer In indexs
        '                    'Add the objects to the sub list.
        '                    ' If j <= UBound(indexs) Then
        '                    'Dim SommaSpaziInt As Integer = subList.ToList().Sum(Function(x) x.SpaziUsati)
        '                    'Try
        '                    'If SommaSpaziInt + items(j).SpaziUsati <= k Then

        '                    subList.Add(items(j))                            'j -= 1
        '                    'End If
        '                    'Else
        '                    'Exit For
        '                    'End If

        '                    'Catch ex As Exception

        '                    'End Try

        '                    'subList.Add(items(j))
        '                Next
        '                'Add the sub list to the parent list.
        '                ' Dim FirmaSubList As String = CalcolaFirma(subList)
        '                'Dim Aggiungi As Boolean = True
        '                'For Each l As List(Of OrdineInSoluzione) In finalList

        '                'If CalcolaFirma(l) = FirmaSubList Then
        '                'Aggiungi = False
        '                '        Exit For
        '                'End If
        '                'Next

        '                'If Aggiungi Then
        '                Dim Aggiungi As Boolean = True
        '                If subList.Sum(Function(y) y.SpaziUsati) <= kk Then Aggiungi = True
        '                If Aggiungi Then
        '                    'If finalList.FindAll(Function(x) x.Firma = subList.Firma).Count = 0 Then
        '                    finalList.Add(subList)
        '                    'End If
        '                End If

        '                'End If
        '            Else
        '                Do
        '                    i -= 1
        '                Loop While indexs(i) = i + (n - K)
        '                indexs(i) += 1
        '                For j As Integer = i + 1 To K - 1
        '                    indexs(j) = indexs(j - 1) + 1
        '                Next
        '                Dim subList As New ListEx
        '                For Each j As Integer In indexs
        '                    'Add the objects to the sub list.
        '                    'If j <= UBound(indexs) Then
        '                    'Dim SommaSpaziInt As Integer = subList.ToList().Sum(Function(x) x.SpaziUsati)
        '                    'Try
        '                    'If SommaSpaziInt + items(j).SpaziUsati <= k Then
        '                    'If UBound(items) >= j Then
        '                    subList.Add(items(j))
        '                    'Else
        '                    '    Exit For
        '                    'End If
        '                    'j -= 1
        '                    '  End If
        '                    ' Else
        '                    'Exit For
        '                    'End If

        '                    'Catch ex As Exception

        '                    'End Try
        '                    'subList.Add(items(j))
        '                Next
        '                'Add the sub list to the parent list.
        '                'Dim FirmaSubList As String = CalcolaFirma(subList)

        '                'For Each l As List(Of OrdineInSoluzione) In finalList

        '                '    If CalcolaFirma(l) = FirmaSubList Then
        '                '        Aggiungi = False
        '                '        Exit For
        '                '    End If
        '                'Next
        '                Dim Aggiungi As Boolean = True
        '                If subList.Sum(Function(y) y.SpaziUsati) <= kk Then Aggiungi = True
        '                If Aggiungi Then
        '                    'If finalList.FindAll(Function(x) x.Firma = subList.Firma).Count = 0 Then
        '                    finalList.Add(subList)
        '                    'End If
        '                End If
        '                i = K - 1
        '            End If
        '        End While
        '    Next
        'End If
        '******************************************************


        Dim TempList As New List(Of ListEx)
        TempList = finalList.FindAll(Function(x) x.Sum(Function(y) y.SpaziUsati) = kk)

        If TempList.Count Then
            finalList = TempList
        End If

        'QUI A PRESCINDERE DEVO RIPULIRE LA FINALLIST
        Dim UltimateList As New List(Of List(Of OrdineInSoluzione))

        'finalList = finalList.Select(Function(x) x.Firma).Distinct()

        Dim GiaTrovati As New List(Of String)

        Do Until finalList.Count = 0
            Dim FirmaToWork As String = finalList(0).Firma
            If GiaTrovati.FindAll(Function(x) x = FirmaToWork).Count = 0 Then
                GiaTrovati.Add(FirmaToWork)
                UltimateList.Add(finalList(0))
                finalList.RemoveAll(Function(x) x.Firma = FirmaToWork)
            End If
        Loop

        'If TempList.Count = 0 Then
        '    'QUI NON SERVE CHE FA NIENTE
        '    'If Ps.SoloSoluzioniOttimali = False Then
        '    'qui devo compunque ripulire la finallist dalle combinazioni inutili
        '    'finalList = finalList.FindAll(Function(x) x.Sum(Function(y) y.SpaziUsati) <= kk)
        '    'End If
        'ElseIf TempList.Count = 1 Then
        '    finalList = TempList
        'Else
        '    'finalList.Clear()
        '    'finalList.Add(TempList(0))
        '    finalList = TempList
        'End If

        Return UltimateList
    End Function

    Public Shared Function GetSubsetsOld(ByVal items() As OrdineInSoluzione,
                                      ByVal k As Integer) As List(Of List(Of OrdineInSoluzione))

        Dim ListOrdini As List(Of OrdineInSoluzione) = items.ToList
        Dim SommaSpazi As Integer = ListOrdini.Sum(Function(x) x.SpaziUsati)
        Dim finalList As New List(Of List(Of OrdineInSoluzione))

        If k > SommaSpazi Then k = SommaSpazi

        'Dim ListaCorrente As List(Of OrdineInSoluzione) = Nothing

        'For z = 0 To items.Count - 1
        '    Dim OStart As OrdineInSoluzione = items(z)
        '    If OStart.SpaziUsati <= k Then
        '        For f = 0 To items.Count - 1
        '            If f <> z Then
        '                Dim O As OrdineInSoluzione = items(f)
        '                If ListaCorrente Is Nothing Then
        '                    ListaCorrente = New List(Of OrdineInSoluzione)
        '                    ListaCorrente.Add(OStart)
        '                End If
        '                Dim SpaziUsatiListaCorr As Integer = GetSpaziUsati(ListaCorrente)
        '                If O.SpaziUsati + SpaziUsatiListaCorr <= k Then
        '                    ListaCorrente.Add(O)
        '                End If
        '                If SpaziUsatiListaCorr = k Or f = items.Count - 1 Then
        '                    Dim FirmaSubList As String = CalcolaFirma(ListaCorrente)
        '                    Dim Aggiungi As Boolean = True
        '                    For Each l As List(Of OrdineInSoluzione) In finalList

        '                        If CalcolaFirma(l) = FirmaSubList Then
        '                            Aggiungi = False
        '                            Exit For
        '                        End If
        '                    Next

        '                    If Aggiungi Then finalList.Add(ListaCorrente)
        '                    ListaCorrente = Nothing
        '                End If
        '            End If
        '        Next
        '    End If
        'Next

        'If k > items.Count Then k = items.Count

        Dim i As Integer = k 'ListOrdini.Count
        Dim n As Integer = items.Length

        i -= 1
        'Add the objects to the first sub list.
        Dim indexs(items.Count - 1) As Integer 'k-1
        Dim firstSubList As New List(Of OrdineInSoluzione)
        For j As Integer = 0 To items.Count - 1 'k-1s
            indexs(j) = j
            firstSubList.Add(items(j))
        Next
        'Add the first sub list to the parent list.
        'finalList.Add(firstSubList)
        If SommaSpazi <= k Then finalList.Add(firstSubList)
        'Continue adding lasts.
        'While finalList.Count < 2147483647
        While indexs(0) <> n - k AndAlso finalList.Count < 2147483647
            If i > items.Count - 1 OrElse i < 0 Then
                Exit While
            End If

            If indexs(i) < i + (n - k) Then
                indexs(i) += 1
                Dim subList As New List(Of OrdineInSoluzione)

                For Each j As Integer In indexs
                    'Add the objects to the sub list.
                    If j <= UBound(indexs) Then
                        Dim SommaSpaziInt As Integer = subList.ToList().Sum(Function(x) x.SpaziUsati)
                        'Try
                        If SommaSpaziInt + items(j).SpaziUsati <= k Then
                            subList.Add(items(j))                            'j -= 1
                        End If
                    Else
                        Exit For
                    End If

                    'Catch ex As Exception

                    'End Try

                    'subList.Add(items(j))
                Next
                'Add the sub list to the parent list.
                Dim FirmaSubList As String = CalcolaFirma(subList)
                Dim Aggiungi As Boolean = True
                For Each l As List(Of OrdineInSoluzione) In finalList

                    If CalcolaFirma(l) = FirmaSubList Then
                        Aggiungi = False
                        Exit For
                    End If
                Next

                If Aggiungi Then finalList.Add(subList)
            Else
                Do
                    i -= 1
                Loop While indexs(i) = i + (n - k)
                indexs(i) += 1
                For j As Integer = i + 1 To k - 1
                    indexs(j) = indexs(j - 1) + 1
                Next
                Dim subList As New List(Of OrdineInSoluzione)
                For Each j As Integer In indexs
                    'Add the objects to the sub list.
                    If j <= UBound(indexs) Then
                        Dim SommaSpaziInt As Integer = subList.ToList().Sum(Function(x) x.SpaziUsati)
                        'Try
                        If SommaSpaziInt + items(j).SpaziUsati <= k Then
                            subList.Add(items(j))                            'j -= 1
                        End If
                    Else
                        Exit For
                    End If

                    'Catch ex As Exception

                    'End Try
                    'subList.Add(items(j))
                Next
                'Add the sub list to the parent list.
                Dim FirmaSubList As String = CalcolaFirma(subList)
                Dim Aggiungi As Boolean = True
                For Each l As List(Of OrdineInSoluzione) In finalList

                    If CalcolaFirma(l) = FirmaSubList Then
                        Aggiungi = False
                        Exit For
                    End If
                Next

                If Aggiungi Then finalList.Add(subList)
                i = k - 1
            End If
        End While
        Return finalList
    End Function

    ''' <summary>
    ''' Calculates the number of unique combinations. 
    ''' </summary>
    ''' <param name="n">The total number(set size) of objects.</param>
    ''' <param name="k">The subset size.</param>
    Public Shared Function Count(ByVal n As UInt32, ByVal k As UInt32) As ULong
        If n < k Then Return 0
        If n = k Then Return 1
        Dim delta, iMax As ULong
        If (k < n - k) Then
            delta = n - k
            iMax = k
        Else
            delta = k
            iMax = n - k
        End If
        Dim ans As ULong = CULng(delta + 1)
        For i As ULong = 2 To iMax
            ans = CULng((ans * (delta + i)) / i)
        Next
        Return ans
    End Function

    ''' <summary>
    ''' Sorts the elements in a List(Of List(Of Object)).
    ''' </summary>
    ''' <param name="combLists">A list of combinations list to sort.</param>
    Public Shared Sub Sort(ByVal combLists As List(Of List(Of OrdineInSoluzione)))
        If combLists.Count = 1 Then
            combLists(0).Sort()
        ElseIf combLists.Count > 1 Then
            combLists.Sort(New CombinationEx)
        End If
    End Sub

    ''' <summary>
    ''' Compares two specified List(Of Object).
    ''' </summary>
    ''' <param name="x">The first List(Of Object).</param>
    ''' <param name="y">The second List(Of Object).</param>
    Protected Overridable Function Compare(ByVal x As List(Of OrdineInSoluzione), ByVal y As List(Of OrdineInSoluzione)) As Integer _
    Implements System.Collections.Generic.IComparer(Of List(Of OrdineInSoluzione)).Compare
        x.Sort()
        y.Sort()
        Dim t As Integer
        'Numeric type compare
        'If IsNumeric(x(0).IdOrd) Then
        For i As Integer = 0 To x.Count - 1
                t = Val(x(i).IdOrd).CompareTo(Val(y(i).IdOrd))
                If t <> 0 Then
                    Return t
                End If
            Next i
            Return 0
        'End If
        ''String type compare
        'If x(0).GetType Is GetType(String) Then
        '    For i As Integer = 0 To x.Count - 1
        '        t = CStr(x(i).IdOrd).CompareTo(y(i).IdOrd)
        '        If t <> 0 Then
        '            Return t
        '        End If
        '    Next i
        '    Return 0
        'End If
        ''Date type compare
        'If x(0).GetType Is GetType(Date) Then
        '    For i As Integer = 0 To x.Count - 1
        '        t = CDate(x(i).IdOrd).CompareTo(y(i).IdOrd)
        '        If t <> 0 Then
        '            Return t
        '        End If
        '    Next i
        '    Return 0
        'End If
    End Function

#End Region

End Class


