Imports FormerLib.FormerEnum

Public Class cTipoProdCom
    Inherits CollectionBase

    Public Sub New(ByVal Consumo As Boolean)
        Dim TipoProd As FormerLib.cEnum

        TipoProd = New FormerLib.cEnum
        TipoProd.Id = enTipoProdCom.StampaOffSet
        TipoProd.Descrizione = "OffSet"
        InnerList.Add(TipoProd)

        TipoProd = New FormerLib.cEnum
        TipoProd.Id = enTipoProdCom.StampaDigitale
        TipoProd.Descrizione = "Digitale"
        InnerList.Add(TipoProd)

        TipoProd = New FormerLib.cEnum
        TipoProd.Id = enTipoProdCom.Packaging
        TipoProd.Descrizione = "Packaging"
        InnerList.Add(TipoProd)

        TipoProd = New FormerLib.cEnum
        TipoProd.Id = enTipoProdCom.Ricamo
        TipoProd.Descrizione = "Ricamo"
        InnerList.Add(TipoProd)

        TipoProd = New FormerLib.cEnum
        TipoProd.Id = enTipoProdCom.Etichette
        TipoProd.Descrizione = "Etichette"
        InnerList.Add(TipoProd)

        TipoProd = New FormerLib.cEnum
        TipoProd.Id = enTipoProdCom.NonSpecificato
        TipoProd.Descrizione = "Non Specificato"
        InnerList.Add(TipoProd)

        If Consumo Then
            TipoProd = New FormerLib.cEnum
            TipoProd.Id = enTipoProdCom.Consumo
            TipoProd.Descrizione = "Materiale di consumo"
            InnerList.Add(TipoProd)
        End If

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