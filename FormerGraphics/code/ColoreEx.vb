Imports System.Drawing

Public Class ColoreEx

    Public Sub New(ColoreNew As Color, NomeNew As String)
        Colore = ColoreNew
        Nome = NomeNew
    End Sub

    Public Property Colore As Color
    Public Property Nome As String

    Public Overrides Function ToString() As String
        Return Nome & " (" & Colore.R & "," & Colore.G & "," & Colore.B & ") Numero Pixel: " & NumeroPixel
    End Function

    Public Property NumeroPixel As Integer = 0

    Public Function Percentuale(Totale As Integer) As Integer
        Dim Ris As Integer = 0
        Ris = Math.Round((NumeroPixel * 100) / Totale)

        Return Ris
    End Function


End Class