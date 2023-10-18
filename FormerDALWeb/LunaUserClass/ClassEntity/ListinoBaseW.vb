#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports System.Drawing

''' <summary>
'''Entity Class for table T_listinobase
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ListinoBaseW
    Inherits _ListinoBaseW
    Implements IListinoBaseW
    Implements IListinoBaseB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"
    Public Overrides Property TipoControlloPrezzo As Integer
        Get

            Dim Val As Integer = MyBase.TipoControlloPrezzo

            'DISATTIVATO QUANDO E' SPARITA LA TEXTBOX
            'If Preventivazione.IdReparto = enRepartoWeb.Etichette And ConSoggettiDuplicati = enSiNo.Si Then
            '    'TODO: RIATTIVARE!!!
            '    Val = enTipoControlloPrezzo.TextBox
            'End If

            Return Val
        End Get
        Set(value As Integer)
            MyBase.TipoControlloPrezzo = value
        End Set
    End Property

    Public Overrides Property IdListinoBase() As Integer Implements IListinoBaseB.IdListinoBase
        Get
            Return MyBase.IdListinoBase
        End Get
        Set(ByVal value As Integer)
            MyBase.IdListinoBase = value
        End Set
    End Property
    Public Overrides Property ConSoggettiDuplicati() As Integer Implements IListinoBaseB.ConSoggettiDuplicati
        Get
            Return MyBase.ConSoggettiDuplicati
        End Get
        Set(ByVal value As Integer)
            MyBase.ConSoggettiDuplicati = value
        End Set
    End Property

    Public Overrides Property Nome() As String Implements IListinoBaseB.Nome
        Get
            Return MyBase.Nome
        End Get
        Set(ByVal value As String)
            MyBase.Nome = value
        End Set
    End Property

    Public Overrides Property IdCurvaAtt() As Integer Implements IListinoBaseB.IdCurvaAtt
        Get
            Return MyBase.IdCurvaAtt
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCurvaAtt = value
        End Set
    End Property


    Public Overrides Property IdCurvaPubbl() As Integer Implements IListinoBaseB.IdCurvaPubbl
        Get
            Return MyBase.IdCurvaPubbl
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCurvaPubbl = value
        End Set
    End Property


    Public Overrides Property IdFormProd() As Integer Implements IListinoBaseB.IdFormProd
        Get
            Return MyBase.IdFormProd
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormProd = value
        End Set
    End Property


    Public Overrides Property IdFormato() As Integer Implements IListinoBaseB.IdFormato
        Get
            Return MyBase.IdFormato
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormato = value
        End Set
    End Property


    Public Overrides Property IdTipoCartaCop() As Integer Implements IListinoBaseB.IdTipoCartaCop
        Get
            Return MyBase.IdTipoCartaCop
        End Get
        Set(ByVal value As Integer)
            MyBase.IdTipoCartaCop = value
        End Set
    End Property


    Public Overrides Property IdTipoCarta() As Integer Implements IListinoBaseB.IdTipoCarta
        Get
            Return MyBase.IdTipoCarta
        End Get
        Set(ByVal value As Integer)
            MyBase.IdTipoCarta = value
        End Set
    End Property


    Public Overrides Property IdTipoCartaDorso() As Integer Implements IListinoBaseB.IdTipoCartaDorso
        Get
            Return MyBase.IdTipoCartaDorso
        End Get
        Set(ByVal value As Integer)
            MyBase.IdTipoCartaDorso = value
        End Set
    End Property


    Public Overrides Property IdPrev() As Integer Implements IListinoBaseB.IdPrev
        Get
            Return MyBase.IdPrev
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPrev = value
        End Set
    End Property


    Public Overrides Property IdColoreStampa() As Integer Implements IListinoBaseB.IdColoreStampa
        Get
            Return MyBase.IdColoreStampa
        End Get
        Set(ByVal value As Integer)
            MyBase.IdColoreStampa = value
        End Set
    End Property


    Public Overrides Property v1() As Decimal Implements IListinoBaseB.v1
        Get
            Return MyBase.v1
        End Get
        Set(ByVal value As Decimal)
            MyBase.v1 = value
        End Set
    End Property


    Public Overrides Property v2() As Decimal Implements IListinoBaseB.v2
        Get
            Return MyBase.v2
        End Get
        Set(ByVal value As Decimal)
            MyBase.v2 = value
        End Set
    End Property


    Public Overrides Property v3() As Decimal Implements IListinoBaseB.v3
        Get
            Return MyBase.v3
        End Get
        Set(ByVal value As Decimal)
            MyBase.v3 = value
        End Set
    End Property


    Public Overrides Property v4() As Decimal Implements IListinoBaseB.v4
        Get
            Return MyBase.v4
        End Get
        Set(ByVal value As Decimal)
            MyBase.v4 = value
        End Set
    End Property


    Public Overrides Property v5() As Decimal Implements IListinoBaseB.v5
        Get
            Return MyBase.v5
        End Get
        Set(ByVal value As Decimal)
            MyBase.v5 = value
        End Set
    End Property


    Public Overrides Property v6() As Decimal Implements IListinoBaseB.v6
        Get
            Return MyBase.v6
        End Get
        Set(ByVal value As Decimal)
            MyBase.v6 = value
        End Set
    End Property


    Public Overrides Property qta1() As Single Implements IListinoBaseB.qta1
        Get
            Return MyBase.qta1
        End Get
        Set(ByVal value As Single)
            MyBase.qta1 = value
        End Set
    End Property


    Public Overrides Property qta2() As Single Implements IListinoBaseB.qta2
        Get
            Return MyBase.qta2
        End Get
        Set(ByVal value As Single)
            MyBase.qta2 = value
        End Set
    End Property


    Public Overrides Property qta3() As Single Implements IListinoBaseB.qta3
        Get
            Return MyBase.qta3
        End Get
        Set(ByVal value As Single)
            MyBase.qta3 = value
        End Set
    End Property


    Public Overrides Property qta4() As Single Implements IListinoBaseB.qta4
        Get
            Return MyBase.qta4
        End Get
        Set(ByVal value As Single)
            MyBase.qta4 = value
        End Set
    End Property


    Public Overrides Property qta5() As Single Implements IListinoBaseB.qta5
        Get
            Return MyBase.qta5
        End Get
        Set(ByVal value As Single)
            MyBase.qta5 = value
        End Set
    End Property


    Public Overrides Property qta6() As Single Implements IListinoBaseB.qta6
        Get
            Return MyBase.qta6
        End Get
        Set(ByVal value As Single)
            MyBase.qta6 = value
        End Set
    End Property


    Public Overrides Property p1() As Single Implements IListinoBaseB.p1
        Get
            Return MyBase.p1
        End Get
        Set(ByVal value As Single)
            MyBase.p1 = value
        End Set
    End Property


    Public Overrides Property p2() As Single Implements IListinoBaseB.p2
        Get
            Return MyBase.p2
        End Get
        Set(ByVal value As Single)
            MyBase.p2 = value
        End Set
    End Property


    Public Overrides Property p3() As Single Implements IListinoBaseB.p3
        Get
            Return MyBase.p3
        End Get
        Set(ByVal value As Single)
            MyBase.p3 = value
        End Set
    End Property


    Public Overrides Property p4() As Single Implements IListinoBaseB.p4
        Get
            Return MyBase.p4
        End Get
        Set(ByVal value As Single)
            MyBase.p4 = value
        End Set
    End Property


    Public Overrides Property p5() As Single Implements IListinoBaseB.p5
        Get
            Return MyBase.p5
        End Get
        Set(ByVal value As Single)
            MyBase.p5 = value
        End Set
    End Property


    Public Overrides Property p6() As Single Implements IListinoBaseB.p6
        Get
            Return MyBase.p6
        End Get
        Set(ByVal value As Single)
            MyBase.p6 = value
        End Set
    End Property


    Public Overrides Property qtacollo() As Integer Implements IListinoBaseB.qtaCollo
        Get
            Return MyBase.qtacollo
        End Get
        Set(ByVal value As Integer)
            MyBase.qtacollo = value
        End Set
    End Property


    Public Overrides Property faccmin() As Integer Implements IListinoBaseB.faccMin
        Get
            Return MyBase.faccmin
        End Get
        Set(ByVal value As Integer)
            MyBase.faccmin = value
        End Set
    End Property


    Public Overrides Property faccmax() As Integer Implements IListinoBaseB.faccMax
        Get
            Return MyBase.faccmax
        End Get
        Set(ByVal value As Integer)
            MyBase.faccmax = value
        End Set
    End Property


    Public Overrides Property imgrif() As String Implements IListinoBaseB.imgRif
        Get
            Return MyBase.imgrif
        End Get
        Set(ByVal value As String)
            MyBase.imgrif = value
        End Set
    End Property


    Public Overrides Property nofaccsuimpianti() As Boolean Implements IListinoBaseB.NoFaccSuImpianti
        Get
            Return MyBase.nofaccsuimpianti
        End Get
        Set(ByVal value As Boolean)
            MyBase.nofaccsuimpianti = value
        End Set
    End Property


    Public Overrides Property Disattivo() As Integer
        Get
            Return MyBase.Disattivo
        End Get
        Set(ByVal value As Integer)
            MyBase.Disattivo = value
        End Set
    End Property


    Public Overrides Property MultiploQta() As Integer Implements IListinoBaseB.MultiploQta
        Get
            Return MyBase.MultiploQta
        End Get
        Set(ByVal value As Integer)
            MyBase.MultiploQta = value
        End Set
    End Property

    Public Property noResaB() As Integer Implements IListinoBaseB.noResa
        Get
            Return MyBase.noResa
        End Get
        Set(ByVal value As Integer)
            MyBase.noResa = value
        End Set
    End Property


    Public Overrides Property PercAdatCostoCopia() As Integer Implements IListinoBaseB.PercAdatCostoCopia
        Get
            Return MyBase.PercAdatCostoCopia
        End Get
        Set(ByVal value As Integer)
            MyBase.PercAdatCostoCopia = value
        End Set
    End Property


    Public Overrides Property AvviamStampa() As Integer Implements IListinoBaseB.AvviamStampa
        Get
            Return MyBase.AvviamStampa
        End Get
        Set(ByVal value As Integer)
            MyBase.AvviamStampa = value
        End Set
    End Property


    Public Overrides Property MinimaleStampa() As Integer Implements IListinoBaseB.MinimaleStampa
        Get
            Return MyBase.MinimaleStampa
        End Get
        Set(ByVal value As Integer)
            MyBase.MinimaleStampa = value
        End Set
    End Property


    Public Overrides Property ImgSito() As String Implements IListinoBaseB.ImgSito
        Get
            Return MyBase.ImgSito
        End Get
        Set(ByVal value As String)
            MyBase.ImgSito = value
        End Set
    End Property


    Public Overrides Property PrendiIcoDa() As Integer Implements IListinoBaseB.PrendiIcoDa
        Get
            Return MyBase.PrendiIcoDa
        End Get
        Set(ByVal value As Integer)
            MyBase.PrendiIcoDa = value
        End Set
    End Property


    Public Overrides Property TipoPrezzo() As Integer Implements IListinoBaseB.TipoPrezzo
        Get
            Return MyBase.TipoPrezzo
        End Get
        Set(ByVal value As Integer)
            MyBase.TipoPrezzo = value
        End Set
    End Property


    Public Overrides Property DescrSito() As String Implements IListinoBaseB.DescrSito
        Get
            Return MyBase.DescrSito
        End Get
        Set(ByVal value As String)
            MyBase.DescrSito = value
        End Set
    End Property


    Public Overrides Property LastUpdate() As Integer Implements IListinoBaseB.LastUpdate
        Get
            Return MyBase.LastUpdate
        End Get
        Set(ByVal value As Integer)
            MyBase.LastUpdate = value
        End Set
    End Property


    Public Overrides Property IdTipoImballo() As Integer Implements IListinoBaseB.IdTipoImballo
        Get
            Return MyBase.IdTipoImballo
        End Get
        Set(ByVal value As Integer)
            MyBase.IdTipoImballo = value
        End Set
    End Property


    Public Overrides Property IdModelloCubetto() As Integer Implements IListinoBaseB.IdModelloCubetto
        Get
            Return MyBase.IdModelloCubetto
        End Get
        Set(ByVal value As Integer)
            MyBase.IdModelloCubetto = value
        End Set
    End Property

    Public Overrides Property MoltiplicatoreQta As Integer Implements IListinoBaseB.MoltiplicatoreQta
        Get
            Return MyBase.MoltiplicatoreQta
        End Get
        Set(value As Integer)
            MyBase.MoltiplicatoreQta = value
        End Set
    End Property


    Public Overrides Property MoltiplicatoreQta2 As Integer Implements IListinoBaseB.MoltiplicatoreQta2
        Get
            Return MyBase.MoltiplicatoreQta2
        End Get
        Set(value As Integer)
            MyBase.MoltiplicatoreQta2 = value
        End Set
    End Property

    Public Overrides Property MoltiplicatoreQta3 As Integer Implements IListinoBaseB.MoltiplicatoreQta3
        Get
            Return MyBase.MoltiplicatoreQta3
        End Get
        Set(value As Integer)
            MyBase.MoltiplicatoreQta3 = value
        End Set
    End Property

    Public Overrides Property MoltiplicatoreQta4 As Integer Implements IListinoBaseB.MoltiplicatoreQta4
        Get
            Return MyBase.MoltiplicatoreQta4
        End Get
        Set(value As Integer)
            MyBase.MoltiplicatoreQta4 = value
        End Set
    End Property

    Public Overrides Property MoltiplicatoreQta5 As Integer Implements IListinoBaseB.MoltiplicatoreQta5
        Get
            Return MyBase.MoltiplicatoreQta5
        End Get
        Set(value As Integer)
            MyBase.MoltiplicatoreQta5 = value
        End Set
    End Property

    Public Overrides Property MoltiplicatoreQta0 As Integer Implements IListinoBaseB.MoltiplicatoreQta0
        Get
            Return MyBase.MoltiplicatoreQta0
        End Get
        Set(value As Integer)
            MyBase.MoltiplicatoreQta0 = value
        End Set
    End Property

    Public Overrides Property MoltiplicatoreQtaIntermedia As Integer Implements IListinoBaseB.MoltiplicatoreQtaIntermedia
        Get
            Return MyBase.MoltiplicatoreQtaIntermedia
        End Get
        Set(value As Integer)
            MyBase.MoltiplicatoreQtaIntermedia = value
        End Set
    End Property

    Public Overrides Property AbilitaQtaSottoColonna1 As Integer Implements IListinoBaseB.AbilitaQtaSottoColonna1
        Get
            Return MyBase.AbilitaQtaSottoColonna1
        End Get
        Set(value As Integer)
            MyBase.AbilitaQtaSottoColonna1 = value
        End Set
    End Property

    Public Overrides Property AbilitaQtaIntermedie As Integer Implements IListinoBaseB.AbilitaQtaIntermedie
        Get
            Return MyBase.AbilitaQtaIntermedie
        End Get
        Set(value As Integer)
            MyBase.AbilitaQtaIntermedie = value
        End Set
    End Property

    Public ReadOnly Property TipoUnitaMisuraInInput As enUnitaDiMisura Implements IListinoBaseB.TipoUnitaMisuraInInput
        Get
            Dim Ris As enUnitaDiMisura = enUnitaDiMisura.Pezzi

            Ris = MgrCalcoliTecnici.GetUnitaMisuraInput(Me)

            Return Ris
        End Get
    End Property

#End Region

#Region "Interface property"

    Public ReadOnly Property PreventivazioneB As IPreventivazioneB Implements IListinoBaseB.Preventivazione
        Get
            Return Preventivazione
        End Get
    End Property

    Public ReadOnly Property ResaB As ResaFPsuFM Implements IListinoBaseB.Resa
        Get
            Return Resa
        End Get
    End Property

    Public ReadOnly Property ResaB2 As ResaFPsuFM Implements IListinoBaseB.Resa2
        Get
            Return Resa2
        End Get
    End Property

    Public ReadOnly Property CurvaAttB As ICurvaAttB Implements IListinoBaseB.CurvaAtt
        Get
            Return CurvaAtt
        End Get
    End Property

    Public ReadOnly Property FormatoB As IFormatoB Implements IListinoBaseB.Formato
        Get
            Return Formato
        End Get
    End Property

    Public ReadOnly Property FormatoB2 As IFormatoB Implements IListinoBaseB.Formato2
        Get
            Return Formato2
        End Get
    End Property

    Public ReadOnly Property FormatoCartaB As IFormatoCartaB Implements IListinoBaseB.FormatoCarta
        Get
            Return FormatoCarta
        End Get
    End Property

    Public ReadOnly Property CurvaPubblB As ICurvaAttB Implements IListinoBaseB.CurvaPub
        Get
            Return CurvaPub
        End Get
    End Property

    Public ReadOnly Property FormatoProdottoB As IFormatoProdottoB Implements IListinoBaseB.FormatoProdotto
        Get
            Return FormatoProdotto
        End Get
    End Property

    Public ReadOnly Property ColoreStampaB As IColoreStampaB Implements IListinoBaseB.ColoreStampa
        Get
            Return ColoreStampa
        End Get
    End Property

    Public ReadOnly Property TipoCartaB As ITipoCartaB Implements IListinoBaseB.TipoCarta
        Get
            Return TipoCarta
        End Get
    End Property

    Public ReadOnly Property TipoCartaBCop As ITipoCartaB Implements IListinoBaseB.TipoCartaCop
        Get
            Return TipoCartaCop
        End Get
    End Property

    Public ReadOnly Property TipoCartaBDorso As ITipoCartaB Implements IListinoBaseB.TipoCartaDorso
        Get
            Return TipoCartaDorso
        End Get
    End Property


#End Region

#Region "Logic Field"

    Private _Macchinario2 As MacchinarioW = Nothing
    Public ReadOnly Property MacchinarioProduzione2 As IMacchinarioB Implements IListinoBaseB.MacchinarioProduzione2
        Get
            If _Macchinario2 Is Nothing Then
                _Macchinario2 = New MacchinarioW
                _Macchinario2.Read(IdMacchinarioProduzione2)
            End If
            Return _Macchinario2
        End Get
    End Property

    Public Overrides Property AvviamStampa2() As Integer Implements IListinoBaseB.AvviamStampa2
        Get
            Return MyBase.AvviamStampa2
        End Get
        Set(ByVal value As Integer)
            MyBase.AvviamStampa2 = value
        End Set
    End Property

    Public Overrides Property MinimaleStampa2() As Integer Implements IListinoBaseB.MinimaleStampa2
        Get
            Return MyBase.MinimaleStampa2
        End Get
        Set(ByVal value As Integer)
            MyBase.MinimaleStampa2 = value
        End Set
    End Property

    Private _Macchinario As MacchinarioW = Nothing
    Public ReadOnly Property MacchinarioProduzione As IMacchinarioB Implements IListinoBaseB.MacchinarioProduzione
        Get
            If _Macchinario Is Nothing Then
                _Macchinario = New MacchinarioW
                _Macchinario.Read(IdMacchinarioProduzione)
            End If
            Return _Macchinario
        End Get
    End Property

    Public ReadOnly Property ExistPromo As Boolean
        Get
            Dim ris As Boolean = False

            If Not Promo Is Nothing Then
                ris = True
            End If

            Return ris
        End Get
    End Property

    Private _Pr As PromoW = Nothing
    Public ReadOnly Property Promo() As PromoW
        Get
            'qui controllo se per caso c'è un promo
            'If _Pr Is Nothing Then
            Using mgr As New PromoWDAO
                    _Pr = mgr.GetPromo(IdListinoBase)
                End Using
            'End If

            Return _Pr
        End Get
    End Property

    Public Property IdListinoBasePerOrdinamentoComparativo As Integer

    Public ReadOnly Property IsListinoBaseComparativo As Boolean
        Get
            Dim ris As Boolean = False
            If IdListinoBase = IdListinoBasePerOrdinamentoComparativo Then
                ris = True
            End If
            Return ris
        End Get
    End Property

    Public Function LatoFissoRiferimento(Optional AltezzaCm As Single = 0,
                                         Optional LarghezzaCm As Single = 0,
                                         Optional Quantita As Integer = 1,
                                         Optional ScartoMM As Integer = 0) As RisLatoFissoRiferimento

        Dim ris As New RisLatoFissoRiferimento

        If FormatoProdotto.IsRotolo = enSiNo.Si AndAlso
            LargRotolo.Length Then

            'qui prendo le varie larghezze e vedo quale usare
            Dim l As String() = LargRotolo.Split(",")
            'ris = l(UBound(l) - 1)
            Dim LastMis As Integer = 0
            Dim Soluzioni As New List(Of SviluppoDisegnoSuRotoloLastra)
            Dim AreaStampataCalcolata As Single = Math.Round(((AltezzaCm * LarghezzaCm * Quantita) / 10000), 2)

            For Each singMis In l
                If IsNumeric(singMis) Then
                    LastMis = singMis
                    'If singMis >= LatoMin Then

                    Dim svil As New SviluppoDisegnoSuRotoloLastra
                    svil.AreaStampata = AreaStampataCalcolata
                    svil.LatoFissoPrincipale = singMis
                    svil.Mq = MgrCalcoliTecnici.CalcolaMq(singMis,
                                            Quantita,
                                            AltezzaCm,
                                            LarghezzaCm,,
                                            ScartoMM).AreaCalcolata

                    Soluzioni.Add(svil)

                    'Exit For
                    'End If
                End If
            Next

            If Soluzioni.Count = 0 Then
                ris.LatoFissoPrincipale = LastMis 'cosi a limite prendo sempre il rotolo piu grande per pannellizzare
            Else
                'qui devo vedere tra le varie soluzioni quella in cui c'e' meno spreco
                Soluzioni.Sort(Function(x, y) x.Scarto.CompareTo(y.Scarto))
                ris.LatoFissoPrincipale = Soluzioni(0).LatoFissoPrincipale
            End If

        ElseIf FormatoProdotto.IsLastra = enSiNo.SI Then

            Dim Soluzioni As New List(Of SviluppoDisegnoSuRotoloLastra)

            Dim AreaStampataCalcolata As Single = Math.Round(((AltezzaCm * LarghezzaCm * 1) / 10000), 2) 'Quantita) / 10000), 2)

            Dim AltezzaLastraCm As Integer = FormatoProdotto.LunghezzaCm
            Dim LarghezzaLastraCm As Integer = FormatoProdotto.LarghezzaCm

            Dim DimensioniMinimeAltezza As New Size
            Dim DimensioniMinimeLarghezza As New Size

            Dim Differenziale As Single = (AltezzaLastraCm / AltezzaCm)

            If Differenziale >= 1 Then
                'se non e' almeno 1 vuoldire che non c'entra in questo verso
                'Differenziale = Math.Floor(Differenziale)
                'DimensioniMinimeAltezza.Height = (AltezzaLastraCm / Differenziale)
                DimensioniMinimeAltezza.Height = (Math.Ceiling(AltezzaCm / 25) * 25)


                Differenziale = (LarghezzaLastraCm / LarghezzaCm)
                If Differenziale >= 1 Then
                    'Differenziale = Math.Floor(Differenziale)
                    'DimensioniMinimeAltezza.Width = (LarghezzaLastraCm / Differenziale)
                    DimensioniMinimeAltezza.Width = (Math.Ceiling(LarghezzaCm / 25) * 25)
                End If

                If DimensioniMinimeAltezza.Width <> 0 AndAlso DimensioniMinimeAltezza.Height <> 0 Then
                    Dim svil As New SviluppoDisegnoSuRotoloLastra
                    svil.AreaStampata = AreaStampataCalcolata
                    svil.LatoFissoPrincipale = DimensioniMinimeAltezza.Width
                    svil.LatoFissoSecondario = DimensioniMinimeAltezza.Height
                    svil.Mq = MgrCalcoliTecnici.CalcolaMq(DimensioniMinimeAltezza.Width,
                                    1,
                                    AltezzaCm,
                                    LarghezzaCm,,
                                    ScartoMM,
                                    DimensioniMinimeAltezza.Height).AreaCalcolata


                    svil.Mq = svil.Mq * Quantita

                    Soluzioni.Add(svil)

                End If

            End If

            Differenziale = LarghezzaLastraCm / AltezzaCm

            If Differenziale >= 1 AndAlso Soluzioni.Count = 0 Then
                'se non e' almeno 1 vuoldire che non c'entra in questo verso
                'Differenziale = Math.Floor(Differenziale)
                'DimensioniMinimeLarghezza.Height = (LarghezzaLastraCm / Differenziale)
                DimensioniMinimeLarghezza.Height = (Math.Ceiling(AltezzaCm / 25) * 25)


                Differenziale = (AltezzaLastraCm / LarghezzaCm)
                If Differenziale >= 1 Then
                    'Differenziale = Math.Floor(Differenziale)
                    'DimensioniMinimeLarghezza.Width = (AltezzaLastraCm / Differenziale)

                    DimensioniMinimeLarghezza.Width = (Math.Ceiling(LarghezzaCm / 25) * 25)

                End If

                If DimensioniMinimeLarghezza.Width <> 0 AndAlso DimensioniMinimeLarghezza.Height <> 0 Then
                    Dim svil As New SviluppoDisegnoSuRotoloLastra
                    svil.AreaStampata = AreaStampataCalcolata
                    svil.LatoFissoPrincipale = DimensioniMinimeLarghezza.Width
                    svil.LatoFissoSecondario = DimensioniMinimeLarghezza.Height
                    svil.Mq = MgrCalcoliTecnici.CalcolaMq(DimensioniMinimeLarghezza.Width,
                                    Quantita,
                                    AltezzaCm,
                                    LarghezzaCm,,
                                    ScartoMM,
                                    DimensioniMinimeLarghezza.Height).AreaCalcolata

                    Soluzioni.Add(svil)

                End If

            End If

            Soluzioni = Soluzioni.FindAll(Function(x) x.Mq > 0)

            If Soluzioni.Count = 0 Then
                ris.LatoFissoPrincipale = FormatoProdotto.LarghezzaCm 'cosi a limite prendo sempre il rotolo piu grande per pannellizzare
                ris.LatoFissoSecondario = FormatoProdotto.LunghezzaCm
            Else
                'qui devo vedere tra le varie soluzioni quella in cui c'e' meno spreco
                Soluzioni.Sort(Function(x, y) x.Scarto.CompareTo(y.Scarto))
                ris.LatoFissoPrincipale = Soluzioni(0).LatoFissoPrincipale
                ris.LatoFissoSecondario = Soluzioni(0).LatoFissoSecondario
            End If

        Else

            ris.LatoFissoPrincipale = FormatoProdotto.LarghezzaCm 'FormatoProdotto.Fc.Larghezza

        End If

        Return ris

    End Function

    Public ReadOnly Property DescrizioneAlberoFPEstesa As String
        Get
            Dim ris As String = FormatoProdotto.Formato
            Return ris
        End Get
    End Property

    Public ReadOnly Property DescrizioneAlberoFP As String
        Get
            Dim ris As String = FormatoProdotto.NomeAlberoRif
            If ris.Length > 30 Then
                ris = ris.Substring(0, 30) & "..."
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property DescrizioneAlbero As String
        Get
            Dim ris As String = Nome

            If ris.Length > 20 Then
                ris = ris.Substring(0, 20) & "..."
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property GetImgFormato As String
        Get
            Dim Ris As String = String.Empty

            Select Case PrendiIcoDa
                Case enPrendiIcoDa.FormatoProdotto
                    Ris = FormatoProdotto.ImgRif
                Case enPrendiIcoDa.ColoreDiStampa
                    Ris = ColoreStampa.imgrif
                Case enPrendiIcoDa.Preventivazione
                    Ris = Preventivazione.ImgRif
                Case enPrendiIcoDa.TipoCarta
                    Ris = TipoCarta.ImgRif
            End Select

            Return Ris
        End Get
    End Property

    Private _Formato As FormatoMacchinaW
    Public ReadOnly Property Formato As FormatoMacchinaW
        Get
            If _Formato Is Nothing Then
                _Formato = New FormatoMacchinaW
                _Formato.Read(_IdFormato)
            End If
            Return _Formato
        End Get
    End Property

    Private _Formato2 As FormatoMacchinaW
    Public ReadOnly Property Formato2 As FormatoMacchinaW
        Get
            If _Formato2 Is Nothing Then
                _Formato2 = New FormatoMacchinaW
                _Formato2.Read(_IdFormatoMacchina2)
            End If
            Return _Formato2
        End Get
    End Property

    Private _FormatoCarta As FormatoCartaW
    Public ReadOnly Property FormatoCarta As FormatoCartaW
        Get
            If _FormatoCarta Is Nothing Then
                _FormatoCarta = New FormatoCartaW
                _FormatoCarta.Read(FormatoProdotto.IdFormCarta)
            End If
            Return _FormatoCarta
        End Get
    End Property

    Public ReadOnly Property Resa As ResaFPsuFM ' ResaW
        Get
            Dim Ris As ResaFPsuFM = Nothing

            Ris = MgrResa.GetResa(Formato, FormatoProdotto.Fc)

            'Using mgr As New ResaWDAO
            '    Ris = mgr.Find(New LUNA.LunaSearchParameter("IdFormato", IdFormato),
            '                   New LUNA.LunaSearchParameter("IdFormCarta", FormatoProdotto.IdFormCarta))
            'End Using

            Return Ris

        End Get
    End Property

    Public ReadOnly Property Resa2 As ResaFPsuFM ' ResaW
        Get
            Dim Ris As ResaFPsuFM = Nothing

            Ris = MgrResa.GetResa(Formato2, FormatoProdotto.Fc)

            'Using mgr As New ResaWDAO
            '    Ris = mgr.Find(New LUNA.LunaSearchParameter("IdFormato", IdFormatoMacchina2),
            '                   New LUNA.LunaSearchParameter("IdFormCarta", FormatoProdotto.IdFormCarta))
            'End Using

            Return Ris

        End Get
    End Property

    Private _TCCop As TipoCartaW
    Public ReadOnly Property TipoCartaCop As TipoCartaW
        Get
            If IdTipoCartaCop Then
                If _TCCop Is Nothing Then
                    _TCCop = New TipoCartaW
                    _TCCop.Read(IdTipoCartaCop)
                End If
            End If
            Return _TCCop
        End Get
    End Property

    Private _TCDorso As TipoCartaW
    Public ReadOnly Property TipoCartaDorso As TipoCartaW
        Get
            If IdTipoCartaDorso Then
                If _TCDorso Is Nothing Then
                    _TCDorso = New TipoCartaW
                    _TCDorso.Read(IdTipoCartaDorso)
                End If
            End If
            Return _TCDorso
        End Get
    End Property

    Public ReadOnly Property DescrSitoFormatted As String
        Get
            Return DescrSito.Replace(ControlChars.NewLine, "<br />")
        End Get
    End Property

    Public ReadOnly Property DescrSitoGoogleFormattedInLine As String
        Get
            Dim ris As String = GoogleDescr.Replace(ControlChars.NewLine, " ")

            If ris.Length = 0 Then
                ris = DescrSitoFormattedInLine
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property DescrSitoSEOFormatted As String
        Get
            Dim ris As String = GoogleSEO.Replace(ControlChars.NewLine, "<br />")

            If ris.Length = 0 Then
                ris = DescrSitoFormatted
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property DescrSitoFormattedInLine As String
        Get

            Dim ris As String = Nome & " -"

            If DescrSito.Length Then
                ris &= " " & DescrSito
            End If

            If Preventivazione.DescrizioneEstesa.Length Then
                ris &= " " & Preventivazione.DescrizioneEstesa
            End If

            ris = ris.Replace("""", "'")

            Return ris.Replace(ControlChars.NewLine, " ")

        End Get
    End Property

    Private _P As PreventivazioneW
    Public ReadOnly Property Preventivazione As PreventivazioneW
        Get
            If _P Is Nothing Then
                _P = New PreventivazioneW
                _P.Read(IdPrev)
            End If
            Return _P
        End Get
    End Property

    Private _Fp As FormatoProdottoW
    Public ReadOnly Property FormatoProdotto As FormatoProdottoW
        Get
            If _Fp Is Nothing Then
                _Fp = New FormatoProdottoW
                _Fp.Read(IdFormProd)
            End If
            Return _Fp
        End Get
    End Property

    Private _TC As TipoCartaW
    Public ReadOnly Property TipoCarta As TipoCartaW
        Get
            If _TC Is Nothing Then
                _TC = New TipoCartaW
                If ForzatoIdTipoCarta Then
                    _TC.Read(ForzatoIdTipoCarta)
                Else
                    _TC.Read(IdTipoCarta)
                End If

            End If
            Return _TC
        End Get
    End Property

    Private _CS As ColoreStampaW
    Public ReadOnly Property ColoreStampa As ColoreStampaW
        Get
            If _CS Is Nothing Then
                _CS = New ColoreStampaW
                _CS.Read(IdColoreStampa)
            End If
            Return _CS
        End Get
    End Property

    Private _SiglaProdotto As String = String.Empty
    Public ReadOnly Property SiglaProdotto As String
        Get

            If _SiglaProdotto.Length = 0 Then
                Dim P As New PreventivazioneW
                P.Read(IdPrev)
                _SiglaProdotto = P.Prefisso
                P = Nothing
                'Dim F As New FormatoProdottoW
                'F.Read(_IdFormProd)
                _SiglaProdotto &= FormatoProdotto.Sigla
                'F = Nothing
                Dim TC As New TipoCartaW
                TC.Read(_IdTipoCarta)
                _SiglaProdotto &= TC.Sigla
                TC = Nothing
                'Dim CS As New ColoreStampaW
                'CS.Read(_IdColoreStampa)
                _SiglaProdotto &= ColoreStampa.Sigla
                'CS = Nothing

            End If

            Return _SiglaProdotto

        End Get
    End Property

    Public ReadOnly Property Target() As Integer
        Get
            If nofaccsuimpianti Then
                Return enTargetListinoBase.Foglio
            Else
                Return enTargetListinoBase.Pagina
            End If
        End Get
    End Property

    Public Function ShowLabelFogli() As Boolean
        Dim ris As Boolean = True

        If faccmin = faccmax Then
            If faccmin = 2 Then ris = False
        End If

        Return ris
    End Function

    Private Function Comparer(x As CatLavW, y As CatLavW) As Integer
        Dim ris As Integer = x.TipoControllo.CompareTo(y.TipoControllo)
        If ris = 0 Then
            ris = x.NumeroLavorazioni(IdListinoBase).CompareTo(y.NumeroLavorazioni(IdListinoBase))
        End If
        Return ris
    End Function

    Public ReadOnly Property GetCatLav() As List(Of CatLavW)
        Get
            Dim ris As New List(Of CatLavW)
            For Each l As LavorazioneW In LavorazioniOpz
                If ris.Find(Function(x) x.IdCatLav = l.IdCatLav) Is Nothing Then
                    Dim c As New CatLavW
                    c.Read(l.IdCatLav)
                    'If c.IdCatLav <> LUNA.LunaContext.IdCatPieghe Then
                    ris.Add(c)
                    'End If
                End If
            Next
            ris.Sort(AddressOf Comparer)
            Return ris
        End Get
    End Property

    Public Function GetLabelFogli() As String

        Dim ris As String = String.Empty

        If nofaccsuimpianti Then
            ris = "Fogli"
        Else
            ris = "Facciate-Pagine"
        End If

        Return ris

    End Function

    Public ReadOnly Property NomeInUrl() As String
        Get
            'Dim P As New PreventivazioneW
            'P.Read(_IdPrev)
            'Dim _NomeInUrl As String = P.NomeInUrl & "_"
            'P = Nothing

            ''Dim F As New FormatoProdottoW
            ''F.Read(_IdFormProd)
            '_NomeInUrl &= FormatoProdotto.NomeInUrl & "_"
            ''F = Nothing

            ''Dim TC As New TipoCartaW
            ''TC.Read(_IdTipoCarta)
            '_NomeInUrl &= TipoCarta.NomeInUrl & "_"
            ''TC = Nothing

            ''Dim CS As New ColoreStampaW
            ''CS.Read(_IdColoreStampa)
            '_NomeInUrl &= ColoreStampa.NomeInUrl
            ''CS = Nothing
            Dim Prefisso As String = "Stampa-"

            If Preventivazione.IdReparto = enRepartoWeb.Ricamo Then
                Prefisso = "Ricamo-"
            End If

            Dim _NomeInUrl As String = Prefisso & FormerHelper.Web.NormalizzaUrl(Nome)
            Return _NomeInUrl
        End Get
    End Property

    Public Property NumFacciate As Integer = 2 Implements IListinoBaseB.NumFacciate

    Private _CurvaAtt As CurvaAttW = Nothing
    Public ReadOnly Property CurvaAtt As CurvaAttW
        Get
            If _CurvaAtt Is Nothing Then
                _CurvaAtt = New CurvaAttW
                _CurvaAtt.Read(_IdCurvaAtt)
            End If
            Return _CurvaAtt
        End Get
    End Property

    Private _CurvaPub As CurvaAttW = Nothing
    Public ReadOnly Property CurvaPub As CurvaAttW
        Get
            If _CurvaPub Is Nothing Then
                _CurvaPub = New CurvaAttW
                _CurvaPub.Read(_IdCurvaPubbl)
            End If
            Return _CurvaPub
        End Get
    End Property

    Public ReadOnly Property LavorazioniBaseB As List(Of ILavorazioneB)
        Get
            Dim ris As New List(Of ILavorazioneB)
            For Each l As LavorazioneW In LavorazioniBase
                ris.Add(l)
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property LavorazioniOpzB As List(Of ILavorazioneB)
        Get
            Dim ris As New List(Of ILavorazioneB)
            For Each l As LavorazioneW In LavorazioniOpz
                ris.Add(l)
            Next
            Return ris
        End Get
    End Property

    Private _LavorazioniBase As New List(Of LavorazioneW)
    Public Property LavorazioniBase As List(Of LavorazioneW)
        Get
            Return _LavorazioniBase
        End Get
        Set(value As List(Of LavorazioneW))
            _LavorazioniBase = value
        End Set
    End Property

    Private _LavorazioniOpz As New List(Of LavorazioneW)
    Public Property LavorazioniOpz As List(Of LavorazioneW)
        Get
            Return _LavorazioniOpz
        End Get
        Set(value As List(Of LavorazioneW))
            _LavorazioniOpz = value
        End Set
    End Property

    Public Property Linkato As Boolean = False


    Public ReadOnly Property LabelCopertina As String
        Get
            Dim ris As String = String.Empty

            If TipoCarta.TipoCarta = enTipoCarta.Composta Then
                Dim NumStrati As Integer = 0

                For Each comp As ComposizioneCartaW In TipoCarta.ComposizioniCarta
                    NumStrati += comp.NumFogli
                Next

                ris = "x" & NumStrati

            End If

            If Target = enTargetListinoBase.Pagina Then
                If IdTipoCartaCop Then
                    ris &= " compresa copertina"
                End If
            End If

            Return ris

        End Get
    End Property


#End Region

#Region "Forzato"

    Public Property ForzatoFormatoW As Integer Implements IListinoBaseB.ForzatoFormatoW

    Public Property ForzatoFormatoH As Integer Implements IListinoBaseB.ForzatoFormatoH

    Public Property ForzatoIdFormProd As Integer Implements IListinoBaseB.ForzatoIdFormProd

    Public Property ForzatoIdFormCarta As Integer Implements IListinoBaseB.ForzatoIdFormCarta

    Public Property ForzatoIdTipoCarta As Integer Implements IListinoBaseB.ForzatoIdTipoCarta

#End Region

#Region "Method"

    Public Function GetPesoRiferimentoPerSpedizione(Qta As Integer) As Integer Implements IListinoBaseB.GetPesoRifPerSpedizione
        Dim ris As Integer = 0
        'qui torno il piu alto tra peso volumetrico e peso reale

        If TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            Dim LatoIpotetico As Single = Math.Sqrt(Qta)
            ris = MgrPreventivazioneB.CalcolaKgCarta(LatoIpotetico, LatoIpotetico, TipoCarta.Grammi, 1)
        Else
            Dim PesoKg As Single = MgrPreventivazioneB.CalcolaKgCarta(Qta, Me, False)

            Dim PesoVolumetrico As Single = 0

            Dim Altezza As Single = FormatoProdotto.Fc.Altezza + 3
            Dim Larghezza As Single = FormatoProdotto.Fc.Larghezza + 3
            Dim Profondita As Single = TipoCarta.CalcolaSpessoreCM(Qta)

            Dim NumColli As Integer = MgrPreventivazioneB.CalcolaColli(Qta, Me)

            If Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
                If IdModelloCubetto Then
                    Using M As New ModelloCubettoW
                        M.Read(IdModelloCubetto)
                        Altezza = M.Lunghezza / 10
                        Larghezza = M.Larghezza / 10
                        Profondita = M.Profondita / 10
                    End Using

                    ris = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)
                    ris = ris * NumColli
                End If
            End If

            If PesoVolumetrico = 0 Then PesoVolumetrico = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)

            If PesoKg > PesoVolumetrico Then
                ris = PesoKg
            Else
                ris = PesoVolumetrico
            End If
        End If

        If ris = 0 Then ris = 1

        Return ris

    End Function

    Public Overrides Function IsValid() As Boolean Implements IListinoBaseW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IListinoBaseW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IListinoBaseW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Sub CaricaLavorazioniBase()
        Dim lst As List(Of LavorazSuPreventivazW)
        Using Mgr As New LavorazSuPreventivazWDAO
            lst = Mgr.FindAll("Ordine",
                              New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase),
                              New LUNA.LunaSearchParameter("Opzione", enSiNo.No))
        End Using
        _LavorazioniBase.Clear()
        For Each l As LavorazSuPreventivazW In lst
            Dim Lav As New LavorazioneW
            Lav.Read(l.IdLavoro)

            _LavorazioniBase.Add(Lav)

        Next

    End Sub

    Public Sub CaricaLavorazioniOpz()
        Dim lst As List(Of LavorazSuPreventivazW)
        Using Mgr As New LavorazSuPreventivazWDAO
            lst = Mgr.FindAll("Ordine",
                              New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase),
                              New LUNA.LunaSearchParameter("Opzione", enSiNo.Si))
        End Using
        _LavorazioniOpz.Clear()
        For Each l As LavorazSuPreventivazW In lst
            Dim Lav As New LavorazioneW
            Lav.Read(l.IdLavoro)

            _LavorazioniOpz.Add(Lav)

        Next

    End Sub

#End Region

#Region "Review"

    Private _Reviews As List(Of Review) = Nothing
    Public ReadOnly Property Reviews As List(Of Review)
        Get
            If _Reviews Is Nothing Then
                Using mgr As New ReviewDAO
                    _Reviews = mgr.FindAll("Quando Desc", New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase),
                                            New LUNA.LunaSearchParameter("Stato", enStatoReview.Approvata))
                End Using
            End If
            Return _Reviews
        End Get
    End Property

    Public ReadOnly Property AggregateRatingStr As String
        Get
            Dim ris As String = Format(AggregateRating, "#.0")

            Return ris
        End Get
    End Property

    Public ReadOnly Property AggregateRating As Decimal
        Get
            Dim ris As Decimal = 0

            If Reviews.Count Then
                For Each r As Review In Reviews
                    ris += r.Voto
                Next

                ris = Math.Round(ris / Reviews.Count, 1)
            End If

            Return ris
        End Get
    End Property

#End Region

End Class



''' <summary>
'''Interface for table T_listinobase
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IListinoBaseW
    Inherits _IListinoBaseW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface