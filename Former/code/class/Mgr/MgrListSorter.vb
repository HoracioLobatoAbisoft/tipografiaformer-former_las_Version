Public Class MgrListSorter
    Public Class RisUtilizzoRisorsaSorter
        Public Shared Function SortPerELenco(ByVal x As RisUtilizzoRisorsa,
                                             ByVal y As RisUtilizzoRisorsa) As Integer


            Dim result As Integer = x.Risorsa.TipoCarta.Tipologia.CompareTo(y.Risorsa.TipoCarta.Tipologia)
            If result = 0 Then
                result = x.Risorsa.Descrizione.CompareTo(y.Risorsa.Descrizione)
            End If
            Return result
        End Function
    End Class
End Class
