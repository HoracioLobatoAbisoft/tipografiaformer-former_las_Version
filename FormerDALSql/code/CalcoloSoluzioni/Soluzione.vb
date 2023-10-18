Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class Soluzione
    'Public Property Ottimizzazione As Integer = 0
    'Public Property QtaTiratura As Integer = 0
    Public Property Commesse As New List(Of CommessaProposta)

    Public Property TotOrdiniDaUsare As Integer = 0
    Public Property TotOrdiniUsati As Integer = 0

    Public Property TipoSoluzione As enTipoSoluzione = 0

    Public Sub AggiungiCommessa(CP As CommessaProposta,
                                Parametri As ParametriCreazioneSoluzione)

        'aggiunge l'ordine alla lista se non lo trova
        'oppure se lo trova controlla che non sia meglio l'altra commessaproposta
        Dim OkAggiungi As Boolean = True
        Dim Sostituisci As Boolean = False

        'If CP.Firma.IndexOf("77925,77929,77934,77939") <> -1 Then
        '    Stop
        'End If

        For Each C As CommessaProposta In Commesse
            For Each Oinc As OrdineInSoluzione In CP.Ordini
                If C.Ordini.FindAll(Function(x) x.IdOrd = Oinc.IdOrd).Count Then
                    'qui non devo uscire e basta, devo vedere se questa commessa in cui lo sto aggiungendo e' meglio

                    Sostituisci = CP.DaPreferireAV4(C)

                    'If Sostituisci And C.Firma.IndexOf("77920,77925,77928,77929,77934,77939") <> -1 Then
                    '    Stop
                    'End If

                    'If CP.Ordini.Count = 6 Then Stop
                    If Sostituisci Then
                        'se non ha ordini contenuti in altre 
                        Dim EsciDo As Boolean = False

                        ' il do serve solo per l'exit senza goto
                        Dim ListaIdComDaEliminare As New List(Of Integer)
                        Do
                            For Each oincS In CP.Ordini.FindAll(Function(x) x.IdOrd <> Oinc.IdOrd)
                                For Each com In Commesse
                                    If com.Id <> C.Id Then
                                        If com.Ordini.FindAll(Function(x) x.IdOrd = oincS.IdOrd).Count Then
                                            If com.DaPreferireAV4(CP) Then
                                                ListaIdComDaEliminare.Clear()
                                                Sostituisci = False
                                                Exit Do
                                            Else
                                                ListaIdComDaEliminare.Add(com.Id)
                                            End If
                                        End If
                                    End If
                                Next
                            Next
                            EsciDo = True
                        Loop Until EsciDo = True

                        If Sostituisci Then
                            If Parametri.NonMostrareTutteleCombinazioni Then
                                'qui devo eliminare tutte quelle in cui e' contenuto un qualsiasi ordine di questa commessa nuova
                                Commesse.Remove(C)

                                For Each singId In ListaIdComDaEliminare
                                    Dim comEsist As CommessaProposta = Commesse.Find(Function(x) x.Id = singId)
                                    Commesse.Remove(comEsist)
                                Next

                            End If
                        Else
                            OkAggiungi = False
                        End If
                    Else
                        OkAggiungi = False
                    End If

                    GoTo FineCiclo
                End If
            Next
        Next
FineCiclo:
        'qui lo devo aggiungere  non e' stato trovato
        'OkAggiungi = True
        If OkAggiungi Then Commesse.Add(CP)
        'Commesse.Add(CP)
    End Sub

    Public Function ContieneOrdine(CP As CommessaProposta) As Boolean
        Dim Ris As Boolean = False

        For Each ord As OrdineInSoluzione In CP.Ordini
            For Each C As CommessaProposta In Commesse
                For Each o As OrdineInSoluzione In C.Ordini
                    If o.IdOrd = ord.IdOrd Then
                        Ris = True
                        Exit For
                        'Return Ris
                    End If
                Next
            Next
        Next
        'For Each C As CommessaProposta In Commesse
        '    For Each o As OrdineInSoluzione In C.Ordini
        '        For Each OinC As OrdineInSoluzione In CP.Ordini
        '            If o.IdOrd = 39666 Then Stop
        '            If o.IdOrd = OinC.IdOrd Then
        '                Ris = True
        '                Exit For
        '                'Return Ris
        '            End If
        '        Next
        '    Next
        'Next

        Return Ris
    End Function

End Class