Public Class MgrPluginEtichette

    Public Shared Function GetListiniBaseCompatibili(Pre As IPreventivazioneB,
                                    H As Integer,
                                    B As Integer) As List(Of IListinoBaseB)

        'puo tornare anche nothing se nessuno dei formatiprodotto va bene per queste misure

        Dim ris As New List(Of IListinoBaseB)

        'qui cerco nella lista dei formatiprodotto quelli in cui entra mettendo prima quello che si adatta meglio e cosi via
        For Each lb As IListinoBaseB In Pre.ListiniBase
            If (H <= (lb.FormatoCarta.Altezza * 10) And B <= (lb.FormatoCarta.Larghezza * 10)) Or
                (B <= (lb.FormatoCarta.Altezza * 10) And H <= (lb.FormatoCarta.Larghezza * 10)) Then
                ris.Add(lb)
            End If
        Next

        ris.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))

        Return ris
    End Function

End Class
