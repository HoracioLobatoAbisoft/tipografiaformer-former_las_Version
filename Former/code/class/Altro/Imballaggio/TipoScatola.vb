Imports FormerLib.FormerEnum
Public Class TipoScatola
    Inherits BoxContenitore
    Implements ICloneable

    Public Property Custom As Boolean = False

    Public Sub New(LunghezzaN As Single, LarghezzaN As Single, ProfonditaN As Single, TipologiaScatolaN As enTipologiaScatola)
        Lunghezza = LunghezzaN
        Larghezza = LarghezzaN
        Profondita = ProfonditaN
        TipologiaScatola = TipologiaScatolaN
    End Sub

    Public Property TipologiaScatola As enTipologiaScatola = enTipologiaScatola.Scatola

    Public ReadOnly Property TipologiaScatolaStr As String
        Get
            Dim ris As String = String.Empty

            Select Case TipologiaScatola
                Case enTipologiaScatola.Scatola
                    ris = "Scatola/e"
                Case enTipologiaScatola.Busta
                    ris = "Busta/e"
                Case enTipologiaScatola.ImballoPersonalizzato
                    ris = "Imballo Personalizzato"
            End Select

            Return ris
        End Get
    End Property

    Public Sub CalcolaParametriRiempimento(Cubetto As Cubetto)
        _CubettoInserito = Cubetto
        'qui decido come e' meglio inserire questo oggetto in questa scatola a prescindere
        'provo le varie combinazioni. la migliore e': 
        ' - quella in cui ce ne entrano di piu 
        ' - a parita quella in cui c'e' meno spreco dispazio 
        ' - a parita la prima 

        Dim L As New List(Of SoluzioneProvata)

        For Each LatoAppoggio As enLatoAppoggio In [Enum].GetValues(GetType(enLatoAppoggio))
            For Each VersoAppoggio As enVersoAppoggio In [Enum].GetValues(GetType(enVersoAppoggio))

                Dim S As New SoluzioneProvata
                S.LatoAppoggio = LatoAppoggio
                S.VersoAppoggio = VersoAppoggio

                Dim Quanti As Integer = 0
                Dim InLarghezza As Integer = 0
                Dim InLunghezza As Integer = 0
                Dim InProfondita As Integer = 0
                Dim AreaBase As Integer = 0
                Select Case LatoAppoggio
                    Case enLatoAppoggio.LatoLungProf
                        If VersoAppoggio = enVersoAppoggio.PerCorto Then
                            InLarghezza = Larghezza \ Cubetto.Profondita
                            InLunghezza = Lunghezza \ Cubetto.Lunghezza
                            InProfondita = Profondita \ Cubetto.Larghezza
                            AreaBase = (Cubetto.Lunghezza * Cubetto.Profondita) * (InLarghezza * InLunghezza)
                        ElseIf VersoAppoggio = enVersoAppoggio.PerLungo Then
                            InLarghezza = Larghezza \ Cubetto.Lunghezza
                            InLunghezza = Lunghezza \ Cubetto.Profondita
                            InProfondita = Profondita \ Cubetto.Larghezza
                            AreaBase = (Cubetto.Lunghezza * Cubetto.Profondita) * (InLarghezza * InLunghezza)
                        End If
                    Case enLatoAppoggio.LatoLargLung
                        If VersoAppoggio = enVersoAppoggio.PerCorto Then
                            InLarghezza = Larghezza \ Cubetto.Lunghezza
                            InLunghezza = Lunghezza \ Cubetto.Larghezza
                            InProfondita = Profondita \ Cubetto.Profondita
                            AreaBase = (Cubetto.Lunghezza * Cubetto.Larghezza) * (InLarghezza * InLunghezza)
                        ElseIf VersoAppoggio = enVersoAppoggio.PerLungo Then
                            InLarghezza = Larghezza \ Cubetto.Larghezza
                            InLunghezza = Lunghezza \ Cubetto.Lunghezza
                            InProfondita = Profondita \ Cubetto.Profondita
                            AreaBase = (Cubetto.Lunghezza * Cubetto.Larghezza) * (InLarghezza * InLunghezza)
                        End If
                    Case enLatoAppoggio.LatoLargProf
                        If VersoAppoggio = enVersoAppoggio.PerCorto Then
                            InLarghezza = Larghezza \ Cubetto.Profondita
                            InLunghezza = Lunghezza \ Cubetto.Larghezza
                            InProfondita = Profondita \ Cubetto.Lunghezza
                            AreaBase = (Cubetto.Profondita * Cubetto.Larghezza) * (InLarghezza * InLunghezza)
                        ElseIf VersoAppoggio = enVersoAppoggio.PerLungo Then
                            InLarghezza = Larghezza \ Cubetto.Larghezza
                            InLunghezza = Lunghezza \ Cubetto.Profondita
                            InProfondita = Profondita \ Cubetto.Lunghezza
                            AreaBase = (Cubetto.Profondita * Cubetto.Larghezza) * (InLarghezza * InLunghezza)
                        End If
                End Select

                If InLunghezza <> 0 And InLarghezza <> 0 And InProfondita <> 0 Then
                    S.InLunghezza = InLunghezza
                    S.InLarghezza = InLarghezza
                    S.InProfondita = InProfondita
                    Quanti = InLarghezza * InLunghezza * InProfondita

                    Dim PesoTotale As Single = Quanti * Cubetto.Peso
                    If PesoTotale > 30000 Then
                        Quanti = 30000 \ Cubetto.Peso
                    End If

                    S.AreaOccupataBase = AreaBase
                    S.NumeroCubetti = Quanti

                    L.Add(S)
                End If
            Next
        Next

        'qui ho tutte le soluzioni e trovo la migliore
        L.Sort(AddressOf Comparer)

        'la prima voce e' la migliore 
        Dim SoluzioneMigliore As SoluzioneProvata = L(0)

        _MaxCubetti = SoluzioneMigliore.NumeroCubetti
        LatoCorrettoAppoggio = SoluzioneMigliore.LatoAppoggio
        VersoCorrettoAppoggio = SoluzioneMigliore.VersoAppoggio
        InLunghezza = SoluzioneMigliore.InLunghezza
        InLarghezza = SoluzioneMigliore.InLarghezza
        InProfondita = SoluzioneMigliore.InProfondita

    End Sub

    Private Class SoluzioneProvata

        Public Property LatoAppoggio As enLatoAppoggio
        Public Property VersoAppoggio As enVersoAppoggio
        Public Property InLarghezza As Integer = 0
        Public Property InLunghezza As Integer = 0
        Public Property InProfondita As Integer = 0
        Public Property NumeroCubetti As Integer = 0
        Public Property AreaOccupataBase As Single = 0

    End Class

    Private _CubettoInserito As Cubetto = Nothing
    Public ReadOnly Property CubettoInserito As Cubetto
        Get
            Return _CubettoInserito
        End Get
    End Property

    Private _MaxCubetti As Integer = 0
    Public ReadOnly Property MaxCubetti As Integer
        Get
            Return _MaxCubetti
        End Get
    End Property

    Public Property InLarghezza As Integer = 0
    Public Property InLunghezza As Integer = 0
    Public Property InProfondita As Integer = 0

    Public Property LatoCorrettoAppoggio As enLatoAppoggio = enLatoAppoggio.LatoLargLung
    Public Property VersoCorrettoAppoggio As enVersoAppoggio = enVersoAppoggio.PerLungo

    Private Function Comparer(ByVal x As SoluzioneProvata, ByVal y As SoluzioneProvata) As Integer
        Dim result As Integer = y.NumeroCubetti.CompareTo(x.NumeroCubetti)
        If result = 0 Then result = y.AreaOccupataBase.CompareTo(x.AreaOccupataBase)

        Return result
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

End Class