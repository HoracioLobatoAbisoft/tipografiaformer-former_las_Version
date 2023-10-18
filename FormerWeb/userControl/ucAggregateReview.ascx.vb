Imports FormerDALWeb

Public Class ucAggregateReview
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



    End Sub

    Public Property IdListinoBase As Integer = 0

    Private _ListinoBase As ListinoBaseW = Nothing
    Private ReadOnly Property ListinoBase As ListinoBaseW
        Get
            If _ListinoBase Is Nothing Then

                _ListinoBase = New ListinoBaseW
                _ListinoBase.Read(IdListinoBase)

            End If

            Return _ListinoBase
        End Get
    End Property

    Public Function GetDescrizione() As String
        Dim ris As String = String.Empty

        If Not ListinoBase Is Nothing Then
            ris = ListinoBase.DescrSitoFormatted
        End If

        Return ris

    End Function

    Public Function GetNome() As String
        Dim ris As String = String.Empty

        If Not ListinoBase Is Nothing Then
            ris = ListinoBase.Nome
        End If

        Return ris

    End Function

    Public Function GetVoto() As String
        Dim ris As String = "0"

        If Not ListinoBase Is Nothing Then
            ris = ListinoBase.AggregateRatingStr
        End If

        Return ris

    End Function

    Public Function GetNumeroRecensioni() As Integer
        Dim ris As Integer = 0

        If Not ListinoBase Is Nothing Then

            ris = ListinoBase.Reviews.Count

        End If

        Return ris
    End Function

    Public Function GetStars() As String

        Dim ris As String = String.Empty
        Dim bufSingStarFull As String = "<img src=""/img/icoStarFull.png"">"
        Dim bufSingStarHalf As String = "<img src=""/img/icoStarHalf.png"">"
        Dim bufSingStarEmpty As String = "<img src=""/img/icoStarEmpty.png"">"

        Dim Voto As Decimal = 0

        If Not ListinoBase Is Nothing Then
            Voto = ListinoBase.AggregateRating
        End If

        For i As Integer = 1 To 5

            If i <= Voto Then
                ris &= bufSingStarFull
            ElseIf (i > Math.Floor(Voto) And (i - Math.Floor(Voto) = 1) And Voto > Math.Floor(Voto)) Then
                ris &= bufSingStarHalf
            ElseIf i > Voto Then
                ris &= bufSingStarEmpty
            End If

        Next

        Return ris

    End Function

    Public Property ShortVersion As Boolean = False

End Class
