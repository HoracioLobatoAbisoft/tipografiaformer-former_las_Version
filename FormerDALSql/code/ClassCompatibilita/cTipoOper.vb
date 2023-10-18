Imports FormerLib.FormerEnum
Public Class cTipoOper
    Inherits CollectionBase

    Public Sub New()
        Dim Tipo As FormerLib.cEnum

        Tipo = New FormerLib.cEnum
        Tipo.Id = enTipoUtente.Admin
        Tipo.Descrizione = "Amministrazione"
        InnerList.Add(Tipo)

        Tipo = New FormerLib.cEnum
        Tipo.Id = enTipoUtente.Operatore
        Tipo.Descrizione = "Operatore"
        InnerList.Add(Tipo)

        Tipo = New FormerLib.cEnum
        Tipo.Id = enTipoUtente.SuperOperatore
        Tipo.Descrizione = "SuperOperatore"
        InnerList.Add(Tipo)

    End Sub
    Default Public Property Item(ByVal index As Integer) As FormerLib.cEnum
        Get
            Return (CType(InnerList.Item(index), FormerLib.cEnum))
        End Get
        Set(ByVal Value As FormerLib.cEnum)
            InnerList.Item(index) = Value
        End Set
    End Property
End Class
