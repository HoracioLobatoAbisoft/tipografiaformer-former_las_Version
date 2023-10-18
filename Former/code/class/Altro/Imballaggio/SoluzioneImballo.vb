Public Class SoluzioneImballo

    Public Property TipoScatola As TipoScatola
    Public Property Cubetto As Cubetto
    Public Property NumeroCubetti As Integer = 0

    Public ReadOnly Property TutteScatolePiene As Boolean
        Get
            Dim ris As Boolean = True
            For Each S As ScatolaProposta In Scatole
                If S.Cubetti.Count <> S.TipoScatola.MaxCubetti Then ris = False
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property NumeroScatole As Integer
        Get
            Return Scatole.Count
        End Get
    End Property

    Public Sub CalcolaScatoleReali()
        Scatole.Clear()
        Dim ScatolaAperta As New ScatolaProposta
        ScatolaAperta.TipoScatola = TipoScatola
        Dim DaInserireInSoluzione As Boolean = True

        Dim CubettiDaInserire As Integer = ScatolaAperta.TipoScatola.MaxCubetti
        For i = 1 To NumeroCubetti
            Dim SingCub As Cubetto = Cubetto.Clone
            ScatolaAperta.Cubetti.Add(SingCub)

            If ScatolaAperta.Cubetti.Count = CubettiDaInserire Then
                Scatole.Add(ScatolaAperta)
                ScatolaAperta = New ScatolaProposta
                ScatolaAperta.TipoScatola = TipoScatola
                DaInserireInSoluzione = False
            Else
                DaInserireInSoluzione = True
            End If
        Next

        If DaInserireInSoluzione Then
            Scatole.Add(ScatolaAperta)
        End If

    End Sub

    Public Property Scatole As New List(Of ScatolaProposta)

    Public ReadOnly Property VolumeCubetto As Single
        Get
            Return Cubetto.Volume
        End Get
    End Property

    'Public ReadOnly Property SpazioSprecatoConTolleranza As Single
    '    Get
    '        Return SpazioSprecato / 100
    '    End Get
    'End Property

    Public ReadOnly Property SpazioSprecato As Single
        Get
            Return TipoScatola.Volume - (VolumeCubetto * TipoScatola.MaxCubetti)
            'Return ((TipoScatola.Volume * NumeroScatole) - (VolumeCubetto * NumeroCubetti)) / 10
        End Get
    End Property

End Class
