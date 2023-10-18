Imports FormerDALWeb

Public Class ucReview
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private _Review As Review = Nothing
    Public Property Review As Review
        Get
            Return _Review
        End Get
        Set(value As Review)
            _Review = value
        End Set
    End Property

    Private _Utente As Utente = Nothing
    Private ReadOnly Property Utente As Utente
        Get
            If _Utente Is Nothing Then
                _Utente = New Utente
                _Utente.Read(Review.IdUt)
            End If
            Return _Utente
        End Get
    End Property

    Public Function GetNome() As String

        Dim ris As String = String.Empty

        Try
            ris = StrConv(Utente.Nome, VbStrConv.ProperCase) & " " & Utente.Cognome.ToUpper.Substring(0, 1) & "."
        Catch ex As Exception

        End Try
        If ris.Length = 0 Then
            ris = "*****"
        End If
        Return ris
    End Function

    Public Property WithProduct As Boolean = False

    Public Function GetStars() As String

        Dim ris As String = String.Empty
        Dim bufSingStarFull As String = "<img src=""/img/icoStarFull.png"" width=""16"">"
        Dim bufSingStarEmpty As String = "<img src=""/img/icoStarEmpty.png"" width=""16"">"

        For i As Integer = 1 To 5

            If i <= Review.Voto Then
                ris &= bufSingStarFull
            Else
                ris &= bufSingStarEmpty
            End If

        Next

        Return ris

    End Function

    Public Function GetPregi() As String

        Dim ris As String = String.Empty

        ris = Server.HtmlEncode(Review.Pregi).Replace(ControlChars.NewLine, "<br />")

        Return ris

    End Function

    Public Function GetDifetti() As String

        Dim ris As String = String.Empty

        ris = Server.HtmlEncode(Review.Difetti).Replace(ControlChars.NewLine, "<br />")

        Return ris

    End Function

    Public Function GetRisposta() As String

        Dim ris As String = String.Empty

        ris = Server.HtmlEncode(Review.Risposta).Replace(ControlChars.NewLine, "<br />")

        Return ris

    End Function

End Class