Public Class ProcedimentoFustella

    Public Property Pezzo As Integer = 0
    Public Property Qta As Integer = 0
    Public Property LunghezzaTotale As Single = 0

    Public Property TipoAzione As String = String.Empty

    Public Property StartX As Single = 0
    Public Property StartY As Single = 0
    Public Property StartAngolo As Single = 0

    Private _procedimento As List(Of AzioneFustella) = Nothing

    Public ReadOnly Property Procedimento As List(Of AzioneFustella)
        Get

            If _procedimento Is Nothing Then
                _procedimento = New List(Of AzioneFustella)
            End If

            _procedimento.Sort(Function(x, y) y.Valore.CompareTo(x.Valore))

            Dim Counter As Integer = 1
            For Each singA In _procedimento

                singA.Counter = Counter

                Counter += 1

            Next

            Return _procedimento

        End Get
    End Property

    Private _Notch As List(Of AzioneFustella) = Nothing
    Public ReadOnly Property Notch As List(Of AzioneFustella)
        Get

            If _Notch Is Nothing Then
                _Notch = New List(Of AzioneFustella)
            End If
            _Notch.Sort(Function(x, y) y.Valore.CompareTo(x.Valore))

            Dim Counter As Integer = 1
            For Each singA In _Notch

                singA.Counter = Counter

                Counter += 1

            Next

            Return _Notch

        End Get
    End Property

    Private Function FormattaMM(Val As Single) As String

        Dim ris As String = Format(Val, "#,##0.00")
        Return ris

    End Function

    Public ReadOnly Property LunghezzaTotaleStr As String
        Get
            Dim ris As String = String.Empty

            ris = LunghezzaTotale

            Return ris
        End Get
    End Property

    Public ReadOnly Property ProcedimentoStr As String
        Get
            Dim ris As String = String.Empty

            For Each singProc As AzioneFustella In Procedimento
                ris &= singProc.Descrizione & ControlChars.NewLine
            Next

            'For Each singProc As Single In Notch
            '    ris &= "NOTCH " & FormattaMM(singProc) & " "
            'Next

            ris = ris.TrimEnd(" ")

            Return ris
        End Get
    End Property

    Public ReadOnly Property NotchStr As String
        Get
            Dim ris As String = String.Empty

            'For i As Integer = Notch.Count - 1 To 0
            '    ris &= "N " & FormattaMM(Notch(i)) & " "
            'Next

            For Each singProc As AzioneFustella In Notch
                ris &= singProc.Descrizione & ControlChars.NewLine
            Next

            ris = ris.TrimEnd(" ")

            Return ris
        End Get
    End Property

End Class
