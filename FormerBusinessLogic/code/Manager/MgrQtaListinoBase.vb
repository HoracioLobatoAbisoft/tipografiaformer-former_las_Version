Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

Public Class MgrQtaListinoBase
    Implements IDisposable

    'Public Function GetElencoQta(L As IListinoBaseB) As List(Of Integer)

    '    Dim ris As New List(Of Integer)

    '    If L.TipoPrezzo = enTipoPrezzo.SuQuantita Then

    '        ris.Add(L.qta1)

    '        If L.MoltiplicatoreQta Then
    '            Dim QtaIniziale As Integer = L.qta1 + L.MoltiplicatoreQta
    '            Dim QtaFinale As Integer = L.qta2 - L.MoltiplicatoreQta
    '            For valore As Integer = QtaIniziale To QtaFinale Step L.MoltiplicatoreQta
    '                ris.Add(valore)
    '            Next
    '        End If

    '        For I As Integer = L.qta2 To L.qta6 Step L.qta2
    '            Dim VarI As Integer = I
    '            If ris.FindAll(Function(x) x = VarI).Count = 0 Then
    '                ris.Add(VarI)
    '            End If
    '        Next

    '    End If

    '    Return ris

    'End Function

    <Obsolete("This method is deprecated, use GetElencoQtaReverse.")>
    Public Function GetElencoQtaEx(L As IListinoBaseB) As List(Of Integer)

        Dim ris As List(Of Integer) = GetElencoQtaReverse(L)

        Return ris


        'Dim ris As New List(Of Integer)

        'If L.TipoPrezzo = enTipoPrezzo.SuQuantita Then

        '    ris.Add(L.qta1)

        '    If L.MoltiplicatoreQta Then
        '        Dim QtaIniziale As Integer = L.qta1 + L.MoltiplicatoreQta
        '        Dim QtaFinale As Integer = L.qta2 - L.MoltiplicatoreQta
        '        For valore As Integer = QtaIniziale To QtaFinale Step L.MoltiplicatoreQta
        '            ris.Add(valore)
        '        Next
        '    End If

        '    Dim QtaStep As Integer = 0

        '    If ris.FindAll(Function(x) x = L.qta2).Count = 0 Then ris.Add(L.qta2)
        '    If L.MoltiplicatoreQta2 Then
        '        QtaStep = L.MoltiplicatoreQta2
        '    Else
        '        QtaStep = L.qta3
        '    End If

        '    For I As Integer = L.qta2 To L.qta3 Step QtaStep 'L.qta3
        '        Dim VarI As Integer = I
        '        If ris.FindAll(Function(x) x = VarI).Count = 0 Then
        '            ris.Add(VarI)
        '        End If
        '    Next

        '    If ris.FindAll(Function(x) x = L.qta3).Count = 0 Then ris.Add(L.qta3)
        '    If L.MoltiplicatoreQta3 Then
        '        QtaStep = L.MoltiplicatoreQta3
        '    Else
        '        QtaStep = L.qta2
        '    End If

        '    For I As Integer = L.qta3 To L.qta4 Step QtaStep 'L.qta2
        '        Dim VarI As Integer = I
        '        If ris.FindAll(Function(x) x = VarI).Count = 0 Then
        '            ris.Add(VarI)
        '        End If
        '    Next

        '    If ris.FindAll(Function(x) x = L.qta4).Count = 0 Then ris.Add(L.qta4)
        '    If L.MoltiplicatoreQta4 Then
        '        QtaStep = L.MoltiplicatoreQta4
        '    Else
        '        QtaStep = L.qta3
        '    End If
        '    For I As Integer = L.qta4 To L.qta5 Step QtaStep ' L.qta3
        '        Dim VarI As Integer = I
        '        If ris.FindAll(Function(x) x = VarI).Count = 0 Then
        '            ris.Add(VarI)
        '        End If
        '    Next

        '    If ris.FindAll(Function(x) x = L.qta5).Count = 0 Then ris.Add(L.qta5)
        '    If L.MoltiplicatoreQta5 Then
        '        QtaStep = L.MoltiplicatoreQta5
        '    Else
        '        QtaStep = L.qta5
        '    End If
        '    For I As Integer = L.qta5 To L.qta6 Step QtaStep 'L.qta5
        '        Dim VarI As Integer = I
        '        If ris.FindAll(Function(x) x = VarI).Count = 0 Then
        '            ris.Add(VarI)
        '        End If
        '    Next

        '    If ris.FindAll(Function(x) x = L.qta6).Count = 0 Then ris.Add(L.qta6)

        'ElseIf L.TipoPrezzo = enTipoPrezzo.SuCopie Then
        '    For I As Integer = 1 To L.qta6 '100
        '        ris.Add(I)
        '    Next

        'ElseIf L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then

        '    ris.Add(500)
        '    For I As Integer = 1000 To 10000 Step 1000 '100
        '        ris.Add(I)
        '    Next
        '    For I As Integer = 15000 To 50000 Step 5000 '100
        '        ris.Add(I)
        '    Next

        'ElseIf L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
        '    For I As Integer = 1 To L.qta6 '100
        '        ris.Add(I)
        '    Next
        'End If

        'Return ris

    End Function

    Public Function GetElencoQtaSecondaria() As List(Of Integer)

        Dim ris As New List(Of Integer)

        For i As Integer = 1 To 10 Step 1
            ris.Add(i)
        Next

        For i As Integer = 15 To 50 Step 5
            ris.Add(i)
        Next

        For i As Integer = 60 To 100 Step 10
            ris.Add(i)
        Next

        For i As Integer = 200 To 1000 Step 100
            ris.Add(i)
        Next

        For i As Integer = 2000 To 5000 Step 1000
            ris.Add(i)
        Next

        ris.Add(7500)

        For i As Integer = 10000 To 100000 Step 10000
            ris.Add(i)
        Next

        'ris.Add(100)
        'ris.Add(500)
        'ris.Add(1000)
        'ris.Add(1500)
        'ris.Add(2000)
        'ris.Add(2500)
        'ris.Add(3000)
        'ris.Add(4000)
        'ris.Add(5000)
        'ris.Add(10000)
        Return ris

    End Function

    Public Function GetElencoQtaReverse(L As IListinoBaseB) As List(Of Integer)

        Dim ris As New List(Of Integer)

        If L.TipoPrezzo = enTipoPrezzo.SuQuantita Then 'Or
            'L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then 'TODO:MODIFICATOTIPOPREZZO

            ris.Add(L.qta1)

            If L.MoltiplicatoreQta Then
                Dim QtaIniziale As Integer = L.qta2 - L.MoltiplicatoreQta

                For valore As Integer = QtaIniziale To L.qta1 Step -L.MoltiplicatoreQta
                    If valore > L.qta1 Then
                        ris.Add(valore)
                    Else
                        Exit For
                    End If
                Next
            End If

            Dim QtaStep As Integer = 0

            If ris.FindAll(Function(x) x = L.qta2).Count = 0 Then ris.Add(L.qta2)
            If L.MoltiplicatoreQta2 Then
                QtaStep = L.MoltiplicatoreQta2
            Else
                QtaStep = L.qta2 'era 3 non so perche
            End If

            For I As Integer = L.qta3 To L.qta2 Step -QtaStep 'L.qta3
                Dim VarI As Integer = I
                If ris.FindAll(Function(x) x = VarI).Count = 0 Then
                    ris.Add(VarI)
                End If
            Next

            If ris.FindAll(Function(x) x = L.qta3).Count = 0 Then ris.Add(L.qta3)
            If L.MoltiplicatoreQta3 Then
                QtaStep = L.MoltiplicatoreQta3
            Else
                QtaStep = L.qta2
            End If

            For I As Integer = L.qta4 To L.qta3 Step -QtaStep 'L.qta2
                Dim VarI As Integer = I
                If ris.FindAll(Function(x) x = VarI).Count = 0 Then
                    ris.Add(VarI)
                End If
            Next

            If ris.FindAll(Function(x) x = L.qta4).Count = 0 Then ris.Add(L.qta4)
            If L.MoltiplicatoreQta4 Then
                QtaStep = L.MoltiplicatoreQta4
            Else
                QtaStep = L.qta3
            End If
            For I As Integer = L.qta5 To L.qta4 Step -QtaStep ' L.qta3
                Dim VarI As Integer = I
                If ris.FindAll(Function(x) x = VarI).Count = 0 Then
                    ris.Add(VarI)
                End If
            Next

            If ris.FindAll(Function(x) x = L.qta5).Count = 0 Then ris.Add(L.qta5)
            If L.MoltiplicatoreQta5 Then
                QtaStep = L.MoltiplicatoreQta5
            Else
                QtaStep = L.qta5
            End If
            For I As Integer = L.qta6 To L.qta5 Step -QtaStep 'L.qta5
                Dim VarI As Integer = I
                If ris.FindAll(Function(x) x = VarI).Count = 0 Then
                    ris.Add(VarI)
                End If
            Next

            If ris.FindAll(Function(x) x = L.qta6).Count = 0 Then ris.Add(L.qta6)

            ris.Sort(Function(x, y) x.CompareTo(y))

            'ElseIf L.TipoPrezzo = enTipoPrezzo.SuCopie Then 'TODO:MODIFICATOTIPOPREZZO
            '    For I As Integer = 1 To L.qta6 '100
            '        ris.Add(I)
            '    Next
        ElseIf L.TipoPrezzo = enTipoPrezzo.SuFoglio Or
               L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            ris.AddRange(GetElencoQtaSecondaria)

        ElseIf L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then

            ris.Add(500)
            For I As Integer = 1000 To 10000 Step 1000 '100
                ris.Add(I)
            Next
            For I As Integer = 15000 To 50000 Step 5000 '100
                ris.Add(I)
            Next

            'ElseIf L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            '    For I As Integer = 1 To L.qta6 '100
            '        ris.Add(I)
            '    Next
        End If

        Return ris

    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: eliminare lo stato gestito (oggetti gestiti).
            End If

            ' TODO: liberare risorse non gestite (oggetti non gestiti) ed eseguire sotto l'override di Finalize().
            ' TODO: impostare campi di grandi dimensioni su Null.
        End If
        disposedValue = True
    End Sub

    ' TODO: eseguire l'override di Finalize() solo se Dispose(disposing As Boolean) include il codice per liberare risorse non gestite.
    'Protected Overrides Sub Finalize()
    '    ' Non modificare questo codice. Inserire sopra il codice di pulizia in Dispose(disposing As Boolean).
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Questo codice viene aggiunto da Visual Basic per implementare in modo corretto il criterio Disposable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Non modificare questo codice. Inserire sopra il codice di pulizia in Dispose(disposing As Boolean).
        Dispose(True)
        ' TODO: rimuovere il commento dalla riga seguente se è stato eseguito l'override di Finalize().
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
