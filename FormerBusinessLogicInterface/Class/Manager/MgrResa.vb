Public Class MgrResa
    Public Shared Function GetResa(FM As IFormatoB,
                                   FC As IFormatoCartaB) As ResaFPsuFM

        Dim ris As New ResaFPsuFM

        'calcolo in un verso e poi nell'altro e vedo quello che e' la resa piu adeguata

        Dim TotOrizzontali As Integer = 0
        Dim TotVerticali As Integer = 0

        Dim FMLatoLungoMM As Single = FM.LatoLungoMM - 8
        Dim FMLatoCortoMM As Single = FM.LatoCortoMM - 8

        Dim FCLatoLungoMM As Integer = FC.LatoLungoMM
        Dim FCLatoCortoMM As Integer = FC.LatoCortoMM

        If FMLatoLungoMM >= FCLatoLungoMM AndAlso FMLatoCortoMM >= FCLatoCortoMM Then
            Dim QuanteColonne As Integer = Math.Floor(FMLatoLungoMM / FCLatoLungoMM)
            Dim QuanteRighe As Integer = Math.Floor(FMLatoCortoMM / FCLatoCortoMM)

            TotOrizzontali = QuanteColonne * QuanteRighe
        End If

        If FMLatoLungoMM >= FCLatoCortoMM AndAlso FMLatoCortoMM >= FCLatoLungoMM Then
            Dim QuanteColonne As Integer = Math.Floor(FMLatoLungoMM / FCLatoCortoMM)
            Dim QuanteRighe As Integer = Math.Floor(FMLatoCortoMM / FCLatoLungoMM)

            TotVerticali = QuanteColonne * QuanteRighe
        End If

        ris.FormatoMacchina = FM
        ris.FormatoCarta = FC

        If TotOrizzontali > TotVerticali Then
            ris.Resa = TotOrizzontali
        Else
            ris.Resa = TotVerticali
        End If

        If ris.Resa = 0 Then ris.Resa = 1

        Return ris

    End Function
End Class
