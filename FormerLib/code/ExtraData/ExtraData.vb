Public Class ExtraData
    Public Property Chiave As String = String.Empty
    Public Property Valore As String = String.Empty

    Public ReadOnly Property TipoEn As MgrExtraData.enExtraData
        Get
            Return MgrExtraData.GetExtraDataEnum(Chiave)
        End Get
    End Property

    Public ReadOnly Property Tipo As Type
        Get
            Return MgrExtraData.GetExtraDataType(TipoEn)
        End Get
    End Property

    Public ReadOnly Property TipoStr As String
        Get
            Return Tipo.ToString
        End Get
    End Property

End Class
