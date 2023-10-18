Public MustInherit Class BoxContenitore

    Public Property Lunghezza As Single = 0
    Public Property Larghezza As Single = 0
    Public Property Profondita As Single = 0

    Public ReadOnly Property AreaBase As Single
        Get
            Return Lunghezza * Larghezza
        End Get
    End Property

    Public ReadOnly Property Volume As Single
        Get
            Return Lunghezza * Larghezza * Profondita
        End Get
    End Property

End Class
