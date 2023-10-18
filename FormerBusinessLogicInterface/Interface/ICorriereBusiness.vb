Public Interface ICorriereBusiness


    Property IdCorriere() As Integer


    Property Descrizione() As String


    'Property Costo() As Single


    Property GGConsegna() As Integer


    Property TestoMail() As String


    Property NomeBreve() As String


    Property PrevedeAccorpamento() As Boolean


    Property TipoCorriere() As Integer


    Property PercPortoAssegnato() As Integer


    Property KgLimite1() As Integer


    Property TariffaLimite1() As Decimal


    Property KgLimite2() As Integer


    Property TariffaLimite2() As Decimal


    Property KgLimite3() As Integer


    Property TariffaLimite3() As Decimal


    Property KgLimite4() As Integer


    Property TariffaLimite4() As Decimal


    Property KgLimite5() As Integer


    Property TariffaLimite5() As Decimal


    Property KgLimite6() As Integer


    Property TariffaLimite6() As Decimal


    Property KgLimite7() As Integer


    Property TariffaLimite7() As Decimal


    Property DisponibileOnline() As Boolean


    Property Label() As String

    Function LavoraCap(Cap As String) As Boolean

    ReadOnly Property LabelDataConsegna As String

End Interface
