Public Class FormerListSorterW

    Public Class ListinoBaseWSorter
        Public Shared Function SortPreventivi(ByVal x As ListinoBaseW,
                                              ByVal y As ListinoBaseW) As Integer
            Dim result As Integer = x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area)
            If result = 0 Then result = y.IsListinoBaseComparativo.CompareTo(x.IsListinoBaseComparativo)
            Return result
        End Function
    End Class

End Class
