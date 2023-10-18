Public Class RisConsegnaModificabile

    Public Property Esito As Boolean = True

    Private _BufferErrori As String = String.Empty
    Public ReadOnly Property BufferErrori As String
        Get
            Return _BufferErrori
        End Get

    End Property

    Public Sub AddProblem(Problema As String)
        Esito = False
        _BufferErrori &= ControlChars.NewLine & " - " & Problema

    End Sub

End Class
