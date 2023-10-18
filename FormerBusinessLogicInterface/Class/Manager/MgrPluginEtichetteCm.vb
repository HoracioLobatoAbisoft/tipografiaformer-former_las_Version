Imports FormerLib.FormerEnum

Public Class MgrPluginEtichetteCm

    Public Shared Function GetListiniBaseCompatibili(Pre As IPreventivazioneB) As List(Of IListinoBaseB)

        'puo tornare anche nothing se nessuno dei formatiprodotto va bene per queste misure

        Dim ris As New List(Of IListinoBaseB)

        'qui cerco nella lista dei formatiprodotto quelli in cui entra mettendo prima quello che si adatta meglio e cosi via

        ris = Pre.ListiniBase.FindAll(Function(x) x.TipoPrezzo = enTipoPrezzo.SuCmQuadri)

        ris.Sort(Function(y, x) y.FormatoCarta.Larghezza.CompareTo(x.FormatoCarta.Larghezza))

        Return ris
    End Function

End Class
