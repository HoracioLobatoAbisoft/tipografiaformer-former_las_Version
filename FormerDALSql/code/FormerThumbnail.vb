Imports System.Drawing

Public Class FormerThumbnail

    Public Shared Function GetForImgListino(Immagine As Image,
                                          Optional Larghezza As Integer = 64,
                                          Optional Altezza As Integer = 64) As Image
        Dim Ris As Image = New Bitmap(Immagine, New Size(Larghezza, Altezza))

        Return Ris

    End Function

    Public Shared Function GetForMacchinario(Immagine As Image) As Image
        Dim Larghezza As Integer = 48
        Dim Altezza As Integer = 48
        Dim Ris As Image = New Bitmap(Immagine, New Size(Larghezza, Altezza))

        Return Ris

    End Function

    Public Shared Function GetForUtente(Immagine As Image) As Image
        Dim Larghezza As Integer = 128
        Dim Altezza As Integer = 128
        Dim Ris As Image = New Bitmap(Immagine, New Size(Larghezza, Altezza))

        Return Ris

    End Function

    Public Shared Function GetForOrdineCommessa(Immagine As Image) As Image

        Dim Larghezza As Integer = 50
        Dim Altezza As Integer = 75
        Dim Ris As Image = Nothing
        If Not Immagine Is Nothing Then
            If Immagine.Width > Immagine.Height Then
                Larghezza = 75
                Altezza = 50
            ElseIf Immagine.Width = Immagine.Height Then
                Larghezza = 75
                Altezza = 75
            End If
        Else
            Immagine = My.Resources.no_image
        End If
        Ris = New Bitmap(Immagine, New Size(Larghezza, Altezza))

        Return Ris

    End Function

End Class
