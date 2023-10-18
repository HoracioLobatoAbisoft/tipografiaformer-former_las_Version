#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 18/03/2020 
#End Region




Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table Listinobasesource
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class ListinoBaseSource
    Inherits _ListinoBaseSource
    Implements IListinoBaseSource
    Implements IListinoBaseB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdListinoBaseSource() As Integer Implements IListinoBaseB.IdListinoBase
        Get
            Return MyBase.IdListinoBaseSource
        End Get
        Set(ByVal value As Integer)
            MyBase.IdListinoBaseSource = value
        End Set
    End Property

    Public Property NumFacciate As Integer = 2 Implements IListinoBaseB.NumFacciate

    Public ReadOnly Property NomeEx As String
        Get
            Dim ris As String = NomeInterno
            If ris.Length = 0 Then ris = Nome
            Return ris
        End Get
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


    Public Overrides Property QtaCollo() As Integer Implements IListinoBaseB.qtaCollo
        Get
            Return MyBase.qtacollo
        End Get
        Set(ByVal value As Integer)
            MyBase.qtacollo = value
        End Set
    End Property


    Public Overrides Property FaccMin() As Integer Implements IListinoBaseB.faccMin
        Get
            Return MyBase.faccmin
        End Get
        Set(ByVal value As Integer)
            MyBase.faccmin = value
        End Set
    End Property


    Public Overrides Property FaccMax() As Integer Implements IListinoBaseB.faccMax
        Get
            Return MyBase.faccmax
        End Get
        Set(ByVal value As Integer)
            MyBase.faccmax = value
        End Set
    End Property


    Public Overrides Property ImgRif() As String Implements IListinoBaseB.imgRif
        Get
            Return MyBase.imgrif
        End Get
        Set(ByVal value As String)
            MyBase.imgrif = value
        End Set
    End Property


    Public Overrides Property NoFaccSuImpianti() As Boolean Implements IListinoBaseB.NoFaccSuImpianti
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


    Public Overrides Property noResa() As Integer Implements IListinoBaseB.noResa
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


#End Region

#Region "Logic Field"

    Private _Preventivazione As Preventivazione = Nothing
    Public ReadOnly Property Preventivazione As Preventivazione
        Get
            If _Preventivazione Is Nothing Then
                _Preventivazione = New Preventivazione
                _Preventivazione.Read(IdPrev)
            End If
            Return _Preventivazione
        End Get
    End Property

    Public ReadOnly Property Resa2 As ResaFPsuFM
        Get
            Dim Ris As ResaFPsuFM = Nothing

            Ris = MgrResa.GetResa(Formato2, FormatoProdotto.FormatoCarta)

            'Using mgr As New ResaDAO
            '    Ris = mgr.Find(New LUNA.LunaSearchParameter("IdFormato", IdFormatoMacchina2),
            '                                               New LUNA.LunaSearchParameter("IdFormCarta", FormatoProdotto.IdFormCarta))
            'End Using

            Return Ris

        End Get
    End Property

    Public ReadOnly Property Resa As ResaFPsuFM
        Get
            Dim Ris As ResaFPsuFM = Nothing

            Ris = MgrResa.GetResa(Formato, FormatoProdotto.FormatoCarta)

            'Using mgr As New ResaDAO
            '    Ris = mgr.Find(New LUNA.LunaSearchParameter("IdFormato", IdFormato),
            '                                               New LUNA.LunaSearchParameter("IdFormCarta", FormatoProdotto.IdFormCarta))
            'End Using

            Return Ris

        End Get
    End Property


    Private _TC As TipoCarta
    Public ReadOnly Property TipoCarta As TipoCarta
        Get
            If _TC Is Nothing Then
                _TC = New TipoCarta
                _TC.Read(IdTipoCarta)
            End If
            Return _TC
        End Get
    End Property

    Private _TCCop As TipoCarta
    Public ReadOnly Property TipoCartaCop As TipoCarta
        Get
            If IdTipoCartaCop Then
                If _TCCop Is Nothing Then
                    _TCCop = New TipoCarta
                    _TCCop.Read(IdTipoCartaCop)
                End If
            End If
            Return _TCCop
        End Get
    End Property

    Private _TCDorso As TipoCarta
    Public ReadOnly Property TipoCartaDorso As TipoCarta
        Get
            If IdTipoCartaDorso Then
                If _TCDorso Is Nothing Then
                    _TCDorso = New TipoCarta
                    _TCDorso.Read(IdTipoCartaDorso)
                End If
            End If
            Return _TCDorso
        End Get
    End Property


    Private _Formato As Formato
    Public ReadOnly Property Formato As Formato
        Get
            If _Formato Is Nothing Then
                _Formato = New Formato
                _Formato.Read(_IdFormato)
            End If
            Return _Formato
        End Get
    End Property

    Private _Formato2 As Formato
    Public ReadOnly Property Formato2 As Formato
        Get
            If _Formato2 Is Nothing Then
                _Formato2 = New Formato
                _Formato2.Read(_IdFormatoMacchina2)
            End If
            Return _Formato2
        End Get
    End Property

    Private _Fp As FormatoProdotto
    Public ReadOnly Property FormatoProdotto As FormatoProdotto
        Get
            If _Fp Is Nothing Then
                _Fp = New FormatoProdotto
                _Fp.Read(_IdFormProd)
            End If
            Return _Fp
        End Get
    End Property


    Private _TipoCartaStr As String = ""
    Public ReadOnly Property TipoCartaStr As String
        Get
            If _TipoCartaStr.Length = 0 Then
                _TipoCartaStr = TipoCarta.Tipologia
            End If
            Return _TipoCartaStr
        End Get
    End Property

    Private _ColoreStampa As ColoreStampa = Nothing

    Public ReadOnly Property ColoreStampa As ColoreStampa
        Get
            If _ColoreStampa Is Nothing Then
                _ColoreStampa = New ColoreStampa
                _ColoreStampa.Read(_IdColoreStampa)
            End If
            Return _ColoreStampa
        End Get
    End Property

    Public ReadOnly Property ColoreStampaStr As String
        Get
            Return ColoreStampa.Descrizione
        End Get
    End Property

    Public ReadOnly Property SiglaColoreStampaStr As String
        Get
            Return ColoreStampa.Sigla
        End Get
    End Property


    Public ReadOnly Property CurvaStr As String
        Get
            Dim Ris As String = ""
            Ris = CurvaAtt.NomeCurva
            Return Ris
        End Get
    End Property

    Private _CurvaAtt As CurvaAtt = Nothing
    Public ReadOnly Property CurvaAtt As CurvaAtt
        Get
            If IdCurvaAtt Then
                If _CurvaAtt Is Nothing Then
                    _CurvaAtt = New CurvaAtt
                    _CurvaAtt.Read(IdCurvaAtt)
                End If
            End If

            Return _CurvaAtt
        End Get
    End Property

    Private _CurvaPub As CurvaAtt = Nothing
    Public ReadOnly Property CurvaPub As CurvaAtt
        Get
            If IdCurvaPubbl Then
                If _CurvaPub Is Nothing Then
                    _CurvaPub = New CurvaAtt
                    _CurvaPub.Read(_IdCurvaPubbl)
                End If
            End If
            Return _CurvaPub
        End Get
    End Property
    Private _FormatoCarta As FormatoCarta
    Public ReadOnly Property FormatoCarta As FormatoCarta
        Get
            If _FormatoCarta Is Nothing Then
                _FormatoCarta = New FormatoCarta
                _FormatoCarta.Read(FormatoProdotto.IdFormCarta)
            End If
            Return _FormatoCarta
        End Get
    End Property


    Public ReadOnly Property LavorazioniBaseB As List(Of ILavorazioneB)
        Get
            Dim ris As New List(Of ILavorazioneB)
            For Each l As Lavorazione In LavorazioniBase
                ris.Add(l)
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property LavorazioniOpzB As List(Of ILavorazioneB)
        Get
            Dim ris As New List(Of ILavorazioneB)
            For Each l As Lavorazione In LavorazioniOpz
                ris.Add(l)
            Next
            Return ris
        End Get
    End Property

    Private _LavorazioniBase As New List(Of Lavorazione)
    Public Property LavorazioniBase As List(Of Lavorazione)
        Get
            Return _LavorazioniBase
        End Get
        Set(value As List(Of Lavorazione))
            _LavorazioniBase = value
        End Set
    End Property

    Private _LavorazioniOpz As New List(Of Lavorazione)
    Public Property LavorazioniOpz As List(Of Lavorazione)
        Get
            Return _LavorazioniOpz
        End Get
        Set(value As List(Of Lavorazione))
            _LavorazioniOpz = value
        End Set
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IListinoBaseSource.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IListinoBaseSource.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IListinoBaseSource.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

#Region "Interface property"

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


#Region "BusinessInterface"

    Public Function GetPesoRiferimentoPerSpedizione(Qta As Integer) As Integer Implements IListinoBaseB.GetPesoRifPerSpedizione
        Dim ris As Integer = 0
        'qui torno il piu alto tra peso volumetrico e peso reale

        Dim PesoKg As Single = MgrPreventivazioneB.CalcolaKgCarta(Qta, Me, False)

        Dim PesoVolumetrico As Single = 0

        Dim Altezza As Single = FormatoProdotto.FormatoCarta.Altezza + 3
        Dim Larghezza As Single = FormatoProdotto.FormatoCarta.Larghezza + 3
        Dim Profondita As Single = TipoCarta.CalcolaSpessoreCM(Qta)

        Dim NumColli As Integer = MgrPreventivazioneB.CalcolaColli(Qta, Me)

        If Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
            If IdModelloCubetto Then
                Using M As New ModelloCubetto
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

        Return ris

    End Function



    Private _Macchinario As Macchinario = Nothing
    Public ReadOnly Property MacchinarioProduzione As IMacchinarioB Implements IListinoBaseB.MacchinarioProduzione
        Get
            If _Macchinario Is Nothing Then
                _Macchinario = New Macchinario
                _Macchinario.Read(IdMacchinarioProduzione)
            End If
            Return _Macchinario
        End Get
    End Property

    Private _Macchinario2 As Macchinario = Nothing
    Public ReadOnly Property MacchinarioProduzione2 As IMacchinarioB Implements IListinoBaseB.MacchinarioProduzione2
        Get
            If _Macchinario2 Is Nothing Then
                _Macchinario2 = New Macchinario
                _Macchinario2.Read(IdMacchinarioProduzione2)
            End If
            Return _Macchinario2
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

End Class

''' <summary>
'''Interface for table Listinobasesource
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IListinoBaseSource
    Inherits _IListinoBaseSource

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface