Imports FormerDALSql

Public Class RisFatturaXML

    Public Property IdRicavo As Integer

    Private _Ricavo As Ricavo = Nothing
    Public ReadOnly Property Ricavo As Ricavo
        Get
            If _Ricavo Is Nothing Then
                _Ricavo = New Ricavo
                _Ricavo.Read(IdRicavo)
            End If
            Return _Ricavo
        End Get
    End Property

    Public ReadOnly Property BufferXML As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property

End Class
