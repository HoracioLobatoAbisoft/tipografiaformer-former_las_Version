Imports FormerLib.FormerEnum
Public Class cTipoRisOffSet
    Inherits CollectionBase

    Public Sub New()
        Dim StatoComm As FormerLib.cEnum

        StatoComm = New FormerLib.cEnum
        StatoComm.Id = enTipoRisOffSet.MateriaPrima
        StatoComm.Descrizione = "Materia Prima"
        InnerList.Add(StatoComm)

        StatoComm = New FormerLib.cEnum
        StatoComm.Id = enTipoRisOffSet.Lastra
        StatoComm.Descrizione = "Lastra Offset"
        InnerList.Add(StatoComm)

    End Sub


    Default Public Property item(ByVal index As Integer) As FormerLib.cEnum
        Get
            Return (CType(InnerList.Item(index), FormerLib.cEnum))
        End Get
        Set(ByVal Value As FormerLib.cEnum)
            InnerList.Item(index) = Value
        End Set
    End Property
End Class