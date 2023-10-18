Public Class Cubetto
    Inherits BoxContenitore
    Implements ICloneable

    Public Sub New(LunghezzaN As Single, LarghezzaN As Single, ProfonditaN As Single, NumeroPezziN As Integer, PesoNGrammi As Single)
        Lunghezza = LunghezzaN
        Larghezza = LarghezzaN
        Profondita = ProfonditaN
        NumeroPezzi = NumeroPezziN
        Peso = PesoNGrammi
    End Sub

    Public Property NumeroPezzi As Integer = 0
    Public Property Peso As Single = 0

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class
