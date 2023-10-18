Public Class OrdineView

#Region "Column Fields"
    Public ReadOnly Property cIdOrdine As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property
    Public ReadOnly Property cData As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property
    Public ReadOnly Property cCommessa As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property
    Public ReadOnly Property cQta As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property
    Public ReadOnly Property cProdotto As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property
    Public ReadOnly Property cCliente As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get

    End Property
    Public ReadOnly Property cStato As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property
    Public ReadOnly Property cTotale As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property
    Public ReadOnly Property cCorriere As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property
    Public ReadOnly Property cConsegna As String
        Get
            Dim ris As String = String.Empty

            Return ris
        End Get
    End Property
#End Region

#Region "Field"
    Public Property IdOrdine As Integer = 0
    Public Property IdCons As Integer = 0

#End Region

#Region "Logic Property"

    Private _Ordine As Ordine = Nothing
    Public ReadOnly Property Ordine As Ordine
        Get
            If _Ordine Is Nothing Then
                _Ordine = New Ordine
                _Ordine.Read(IdOrdine)
            End If
            Return _Ordine
        End Get
    End Property

    Private _Consegna As ConsegnaProgrammata = Nothing
    Public ReadOnly Property Consegna As ConsegnaProgrammata
        Get
            If _Consegna Is Nothing Then
                _Consegna = New ConsegnaProgrammata
                _Consegna.Read(IdCons)
            End If
            Return _Consegna
        End Get
    End Property

#End Region

End Class
