Imports FormerLib.FormerEnum

Public Interface IListinoBaseB

    Property IdListinoBase() As Integer


    Property Nome() As String


    Property IdCurvaAtt() As Integer


    Property IdCurvaPubbl() As Integer


    Property IdFormProd() As Integer


    Property IdFormato() As Integer


    Property IdTipoCartaCop() As Integer


    Property IdTipoCarta() As Integer


    Property IdTipoCartaDorso() As Integer


    Property IdPrev() As Integer


    Property IdColoreStampa() As Integer


    Property v1() As Decimal


    Property v2() As Decimal


    Property v3() As Decimal


    Property v4() As Decimal


    Property v5() As Decimal


    Property v6() As Decimal


    Property qta1() As Single


    Property qta2() As Single


    Property qta3() As Single


    Property qta4() As Single


    Property qta5() As Single


    Property qta6() As Single


    Property p1() As Single


    Property p2() As Single


    Property p3() As Single


    Property p4() As Single


    Property p5() As Single


    Property p6() As Single


    Property qtaCollo() As Integer


    Property faccMin() As Integer


    Property faccMax() As Integer


    Property imgRif() As String


    Property NoFaccSuImpianti() As Boolean


    Property MultiploQta() As Integer


    Property noResa() As Integer


    Property PercAdatCostoCopia() As Integer


    Property AvviamStampa() As Integer


    Property MinimaleStampa() As Integer


    Property ImgSito() As String


    Property PrendiIcoDa() As Integer


    Property TipoPrezzo() As Integer


    Property DescrSito() As String


    Property LastUpdate() As Integer


    Property IdTipoImballo() As Integer


    Property IdModelloCubetto() As Integer

    Property NumFacciate As Integer

    'PROPERTY LOGICHE

    ReadOnly Property Preventivazione As IPreventivazioneB

    ReadOnly Property CurvaAtt As ICurvaAttB

    ReadOnly Property CurvaPub As ICurvaAttB

    ReadOnly Property Formato As IFormatoB

    ReadOnly Property Formato2 As IFormatoB

    ReadOnly Property Resa As ResaFPsuFM

    ReadOnly Property Resa2 As ResaFPsuFM

    ReadOnly Property FormatoCarta As IFormatoCartaB

    ReadOnly Property FormatoProdotto As IFormatoProdottoB

    ReadOnly Property ColoreStampa As IColoreStampaB

    ReadOnly Property TipoCarta As ITipoCartaB

    ReadOnly Property TipoCartaCop As ITipoCartaB

    ReadOnly Property TipoCartaDorso As ITipoCartaB

    ReadOnly Property MacchinarioProduzione As IMacchinarioB

    ReadOnly Property MacchinarioProduzione2 As IMacchinarioB

    Property AvviamStampa2 As Integer
    Property MinimaleStampa2 As Integer

    'FUNCTION
    Function GetPesoRifPerSpedizione(Qta As Integer) As Integer

    Property MoltiplicatoreQta0 As Integer
    Property MoltiplicatoreQta As Integer
    Property MoltiplicatoreQta2 As Integer
    Property MoltiplicatoreQta3 As Integer
    Property MoltiplicatoreQta4 As Integer
    Property MoltiplicatoreQta5 As Integer

    Property MoltiplicatoreQtaIntermedia As Integer

    Property AbilitaQtaIntermedie As Integer
    Property AbilitaQtaSottoColonna1 As Integer

    Property ForzatoFormatoW As Integer
    Property ForzatoFormatoH As Integer
    Property ForzatoIdFormProd As Integer
    Property ForzatoIdFormCarta As Integer
    Property ForzatoIdTipoCarta As Integer

    Property ConSoggettiDuplicati As Integer

    ReadOnly Property TipoUnitaMisuraInInput As enUnitaDiMisura


End Interface
