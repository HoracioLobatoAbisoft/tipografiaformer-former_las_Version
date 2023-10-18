Public Class RisUtilizzoRisorsaOld

    Public Property IdRisorsa As Integer
    Public Property Quantita As Single

    Private _Risorsa As Risorsa = Nothing
    Public ReadOnly Property Risorsa As Risorsa
        Get
            If _Risorsa Is Nothing Then
                _Risorsa = New Risorsa
                _Risorsa.Read(IdRisorsa)
            End If
            Return _Risorsa
        End Get
    End Property

End Class
