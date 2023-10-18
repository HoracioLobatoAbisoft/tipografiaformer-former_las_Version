#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region

Imports System.IO
Imports System.Drawing
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerLib
Imports FormerConfig

''' <summary>
'''Entity Class for table T_listinobase
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ListinoBase
    Inherits _ListinoBase
    Implements IListinoBase
    Implements ICloneable
    Implements IListinoBaseB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"



    Public Overrides Property IdListinoBase() As Integer Implements IListinoBaseB.IdListinoBase
        Get
            Return MyBase.IdListinoBase
        End Get
        Set(ByVal value As Integer)
            MyBase.IdListinoBase = value
        End Set
    End Property

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

    Public Overrides Property ConSoggettiDuplicati() As Integer Implements IListinoBaseB.ConSoggettiDuplicati
        Get
            Return MyBase.ConSoggettiDuplicati
        End Get
        Set(ByVal value As Integer)
            MyBase.ConSoggettiDuplicati = value
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

    ReadOnly Property StatoPromoAutomaticoStr As String
        Get
            Dim ris As String = "Non attivo"

            If AttivaPromoAutomatico = enSiNo.Si Then
                ris = "ATTIVO"
            End If

            Return ris
        End Get
    End Property

    Private _ListinoBaseSource As ListinoBase = Nothing
    Public ReadOnly Property ListinoBaseSource As ListinoBase
        Get
            If IdListinoBaseSource Then
                _ListinoBaseSource = New ListinoBase
                _ListinoBaseSource.Read(IdListinoBaseSource)
            End If
            Return _ListinoBaseSource
        End Get
    End Property

    Public ReadOnly Property LinkAPreventivazione As List(Of PrevLinkListino)
        Get
            Dim l As List(Of PrevLinkListino)
            Using mgrCat As New PrevLinkListinoDAO
                l = mgrCat.FindAll(New LUNA.LSP(LFM.PrevLinkListino.IdListinoBase, IdListinoBase))
            End Using
            Return l
        End Get
    End Property

    Public ReadOnly Property CollegamentoSuCatVirtuale As List(Of ListinoSuCatVirtuale)
        Get
            Dim l As List(Of ListinoSuCatVirtuale)
            Using mgrCat As New ListiniSuCatVirtualeDAO
                l = mgrCat.FindAll(New LUNA.LSP(LFM.ListinoSuCatVirtuale.IdListinoBase, IdListinoBase))
            End Using
            Return l
        End Get
    End Property


    Private _CatVirtuali As List(Of CatVirtuale) = Nothing
    Public ReadOnly Property CatVirtuali As List(Of CatVirtuale)
        Get
            If _CatVirtuali Is Nothing Then
                _CatVirtuali = New List(Of CatVirtuale)
                For Each singVoce In CollegamentoSuCatVirtuale
                    Dim voce As New CatVirtuale
                    voce.Read(singVoce.IdCatVirtuale)
                    _CatVirtuali.Add(voce)
                Next
            End If
            Return _CatVirtuali
        End Get
    End Property


    Public ReadOnly Property ListiniBaseFigli As List(Of ListinoBase)
        Get
            Dim l As List(Of ListinoBase)
            Using mgr As New ListinoBaseDAO
                l = mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, IdListinoBase))
            End Using
            Return l
        End Get
    End Property

    Public ReadOnly Property IdCategorieLavorazioni As List(Of Integer)
        Get
            Dim ris As New List(Of Integer)

            For Each lav In LavorazioniBase
                If ris.FindAll(Function(x) x = lav.IdCatLav).Count = 0 Then ris.Add(lav.IdCatLav)
            Next

            For Each lav In LavorazioniOpz
                If ris.FindAll(Function(x) x = lav.IdCatLav).Count = 0 Then ris.Add(lav.IdCatLav)
            Next

            Return ris

        End Get
    End Property

    Private _ListaVarianti As List(Of GruppoVarianteRif) = Nothing

    Public ReadOnly Property ListaVarianti As List(Of GruppoVarianteRif)
        Get
            If _ListaVarianti Is Nothing Then
                Using mgr As New GruppiVariantiRifDAO
                    _ListaVarianti = mgr.FindAll("TipoRiferimento", New LUNA.LSP(LFM.GruppoVarianteRif.IdListinoBase, IdListinoBase))
                End Using
            End If

            Return _ListaVarianti
        End Get
    End Property

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

    Public ReadOnly Property FirmaLavorazioni As String
        Get
            Dim ris As String = String.Empty

            For Each lav In LavorazioniBase
                ris &= lav.IdLavoro & ","
            Next

            For Each lav In LavorazioniOpz
                ris &= lav.IdLavoro & ","
            Next

            Return ris
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

    Private _Pr As Promo = Nothing
    Public ReadOnly Property Promo() As Promo
        Get
            'qui controllo se per caso c'è un promo
            If _Pr Is Nothing Then
                Using mgr As New PromoDAO
                    _Pr = mgr.GetPromo(IdListinoBase)
                End Using
            End If

            Return _Pr
        End Get
    End Property

    Public ReadOnly Property NomeInUrl() As String
        Get
            Dim Prefisso As String = "Stampa-"

            If Preventivazione.IdReparto = enRepartoWeb.Ricamo Then
                Prefisso = "Ricamo-"
            End If

            Dim _NomeInUrl As String = Prefisso & FormerHelper.Web.NormalizzaUrl(Nome)
            Return _NomeInUrl
        End Get
    End Property

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

    Public ReadOnly Property PreventivazioneB As IPreventivazioneB Implements IListinoBaseB.Preventivazione
        Get
            Return Preventivazione
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

    Private _SiglaProdotto As String = String.Empty
    Public ReadOnly Property SiglaProdotto As String
        Get

            If _SiglaProdotto.Length = 0 Then
                Dim P As New Preventivazione
                P.Read(IdPrev)
                _SiglaProdotto = P.Prefisso
                P = Nothing
                Dim F As New FormatoProdotto
                F.Read(_IdFormProd)
                _SiglaProdotto &= F.Sigla
                F = Nothing
                Dim TC As New TipoCarta
                TC.Read(_IdTipoCarta)
                _SiglaProdotto &= TC.Sigla
                TC = Nothing
                Dim CS As New ColoreStampa
                CS.Read(_IdColoreStampa)
                _SiglaProdotto &= CS.Sigla
                CS = Nothing

            End If

            Return _SiglaProdotto

        End Get
    End Property

    Public ReadOnly Property RiassuntoConPreventivazione As String
        Get
            Dim ris As String = "[" & Preventivazione.Descrizione & "] " & Nome
            Return ris
        End Get
    End Property

    Public Property NumFacciate As Integer = 2 Implements IListinoBaseB.NumFacciate

    Public ReadOnly Property Riassunto As String
        Get

            Dim ris As String = String.Empty

            ris = NomeEx & " (" & FormatoStr & " " & TipoCartaStr & " " & ColoreStampaStr & ")"

            Return ris

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

    Public ReadOnly Property Target() As Integer
        Get
            If NoFaccSuImpianti Then
                Return enTargetListinoBase.Foglio
            Else
                Return enTargetListinoBase.Pagina
            End If
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

    Private _formatoStr As String = ""
    Public ReadOnly Property FormatoStr As String
        Get
            If _formatoStr.Length = 0 Then

                _formatoStr = FormatoProdotto.Formato
            End If

            Return _formatoStr
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

    Public ReadOnly Property ImgFp48 As Image
        Get
            Dim ris As Image = Nothing
            If File.Exists(FormatoProdotto.ImgRif) Then
                Dim ImgInt As New Bitmap(FormatoProdotto.ImgRif)
                Dim ImgNew = New Bitmap(ImgInt, New Size(48, 48))
                Return ImgNew
            End If
            Return ris
        End Get
    End Property
    Public ReadOnly Property ImgTc48 As Image
        Get
            Dim ris As Image = Nothing
            If File.Exists(TipoCarta.ImgRif) Then
                Dim ImgInt As New Bitmap(TipoCarta.ImgRif)
                Dim ImgNew = New Bitmap(ImgInt, New Size(48, 48))
                Return ImgNew
            End If
            Return ris
        End Get
    End Property
    Public ReadOnly Property ImgCs48 As Image
        Get
            Dim ris As Image = Nothing
            If File.Exists(ColoreStampa.imgrif) Then
                Dim ImgInt As New Bitmap(ColoreStampa.imgrif)
                Dim ImgNew = New Bitmap(ImgInt, New Size(48, 48))
                Return ImgNew
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property GetImgRif As Image
        Get
            Dim Ris As Image = Nothing

            Select Case PrendiIcoDa
                Case enPrendiIcoDa.FormatoProdotto
                    Ris = FormatoProdotto.Img
                Case enPrendiIcoDa.ColoreDiStampa
                    Ris = ColoreStampa.Img
                Case enPrendiIcoDa.Preventivazione
                    Ris = Preventivazione.Img
                Case enPrendiIcoDa.TipoCarta
                    Ris = TipoCarta.Img
            End Select

            Return Ris
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

#End Region

#Region "Method"

    Public Function CreaCodProd(Qta As Integer, _
                                NumFacc As Integer, _
                                Optional TieniContoFacciate As Boolean = True) As String

        Dim Ris As String = String.Empty

        Dim P As New Preventivazione
        P.Read(IdPrev)
        Ris = P.Prefisso

        Dim F As New FormatoProdotto
        F.Read(IdFormProd)
        Ris &= F.Sigla

        Dim T As New TipoCarta
        T.Read(IdTipoCarta)
        Ris &= T.Sigla

        Dim C As New ColoreStampa
        C.Read(IdColoreStampa)
        Ris &= C.Sigla

        'Ris &= Qta''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO

        'For Each l As Lavorazione In LavorazioniBase
        '    Ris &= l.Sigla
        'Next

        'For Each lavO As Lavorazione In chkListLavOpz.CheckedItems
        '    Ris &= lavO.Sigla
        'Next
        If TieniContoFacciate Then
            Ris &= "F" & NumFacc
        End If


        Return Ris.ToUpper

    End Function

    Public Function GetLabelFogli() As String

        Dim ris As String = String.Empty

        If nofaccsuimpianti Then
            ris = "Fogli"
        Else
            ris = "Pagine"
        End If

        Return ris

    End Function

    Public Function ShowLabelFogli() As Boolean
        Dim ris As Boolean = True

        If faccmin = faccmax Then
            If faccmin = 2 Then ris = False
        End If

        Return ris
    End Function

    Public Function CreaProdDaListinoBase(Qta As Integer, _
                                          NumFacc As Integer, _
                                          NumColli As Integer, _
                                          Peso As Integer, _
                                          PrezzoRiv As Decimal, _
                                          PrezzoPubbl As Decimal, _
                                          ShowLabelFogli As Boolean, _
                                          LabelFogli As String, _
                                          NFogli As Integer) As Prodotto

        Dim P As New Prodotto

        Dim Pre As New Preventivazione
        Pre.Read(IdPrev)

        Dim Fp As New FormatoProdotto
        Fp.Read(IdFormProd)

        Dim Fm As New FormatoCarta

        Fm.Read(Fp.IdFormCarta)

        Dim Descrizione As String = NomeEx '& " " & Qta

        'If Pre.IdReparto <> enRepartoWeb.StampaDigitale Then
        '    Descrizione &= " " & Fm.FormatoCarta
        'End If

        Dim Cs As New ColoreStampa
        Cs.Read(IdColoreStampa)

        'If Cs.FR Then
        '    Descrizione &= " FR"
        'End If

        If ShowLabelFogli Then
            Descrizione &= " " & NFogli & " " & LabelFogli
        End If

        Dim DescrizioneEstesa As String = Descrizione

        P.Codice = CreaCodProd(Qta, NumFacc, ShowLabelFogli)

        P.NumFacciate = NumFacc
        P.NoImpiantiSuFacciate = IIf(NoFaccSuImpianti, enSiNo.Si, enSiNo.No)

        P.Descrizione = Descrizione
        P.DescrizioneEstesa = DescrizioneEstesa

        P.FronteRetro = Cs.FR

        P.GGFast = Pre.ggFast
        P.GGLow = Pre.ggSlow
        P.GGNormale = Pre.ggNorm

        P.PercFast = 5
        P.PercNormale = 0
        P.PercLow = 5

        P.IdFormato = IdFormProd
        P.IdListinoBase = IdListinoBase
        P.IdTipoCarta = IdTipoCarta
        P.NumColli = NumColli

        P.NumDuplic = 1
        'P.NumOreMax =
        P.NumSpazi = 1

        P.NumPezzi = 1 'Qta''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO

        P.PesoComplessivo = Peso

        P.Prezzo = PrezzoRiv
        P.PrezzoPubbl = PrezzoPubbl

        'Dim RlSt As List(Of Resa) = Nothing
        'Using RMGr As New ResaDAO
        '    RlSt = RMGr.FindAll(New LUNA.LunaSearchParameter("IdFormato", IdFormato), _
        '                                         New LUNA.LunaSearchParameter("IdFormCarta", Fp.IdFormCarta))
        'End Using

        'Dim R As Resa = RlSt(0)

        P.Scarto = 0 'R.PercScarto
        P.TipoProd = Pre.TipoProd
        P.Save()

        Return P

    End Function

    Public Function Anteprima() As String

        Dim bufferhtml As String = ""

        bufferhtml = "<HTML><HEAD><TITLE>Riepilogo</TITLE><style>BODY {font-family: 'Segoe UI';}</style></HEAD><BODY BGCOLOR=""WHITE""><FONT SIZE=1 face=Arial>" & ControlChars.NewLine
        bufferhtml &= "<IMG SRC=""" & _ImgSito & """ width=""300"" height=""130"" border=1><br><br>"
        bufferhtml &= "<h4>Sigla:</h4><h3>" & SiglaProdotto & "</h3>"
        bufferhtml &= "<h4>Sigla:</h4><h3>" & _Nome & "</h3><br><br>"
        bufferhtml &= "</BODY></HTML>" & ControlChars.NewLine

        Dim Sr As StreamWriter, PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")
        Sr = New System.IO.StreamWriter(PathFileStampa, False)

        Sr.Write(bufferhtml)

        Sr.Close()
        'sr = Nothing

        Return PathFileStampa

    End Function

    Public Sub CaricaLavorazioni()

        Dim lst As List(Of LavorazSuPreventivaz) = Nothing
        Using mgr As New LavorazSuPreventivazDAO
            lst = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "Ordine"},
                              New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase))
        End Using
        _LavorazioniBase.Clear()
        _LavorazioniOpz.Clear()
        For Each l As LavorazSuPreventivaz In lst
            Dim Lav As New Lavorazione
            Lav.Read(l.IdLavoro)
            Lav.OrdineInListino = l.Ordine
            If l.Opzione = enSiNo.Si Then
                _LavorazioniOpz.Add(Lav)
            Else
                _LavorazioniBase.Add(Lav)
            End If
        Next
    End Sub

    'Public Sub CaricaLavorazioniBase()
    '    Dim lst As List(Of LavorazSuPreventivaz) = (New LavorazSuPreventivazDAO).Find(New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase), _
    '                                                                           New LUNA.LunaSearchParameter("Opzione", 0))

    '    _LavorazioniBase.Clear()
    '    For Each l As LavorazSuPreventivaz In lst
    '        Dim Lav As New Lavorazione
    '        Lav.Read(l.IdLavoro)
    '        _LavorazioniBase.Add(Lav)

    '    Next

    'End Sub

    'Public Sub CaricaLavorazioniOpz()
    '    Dim lst As List(Of LavorazSuPreventivaz) = (New LavorazSuPreventivazDAO).Find(New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase), _
    '                                                                           New LUNA.LunaSearchParameter("Opzione", 1))

    '    _LavorazioniOpz.Clear()
    '    For Each l As LavorazSuPreventivaz In lst
    '        Dim Lav As New Lavorazione
    '        Lav.Read(l.IdLavoro)
    '        _LavorazioniOpz.Add(Lav)

    '    Next

    'End Sub

    Private _ListaLavorazSuPreventivaz As List(Of LavorazSuPreventivaz) = Nothing
    Public ReadOnly Property ListaLavorazSuPreventivaz As List(Of LavorazSuPreventivaz)
        Get
            If _ListaLavorazSuPreventivaz Is Nothing Then
                Using mgr As New LavorazSuPreventivazDAO
                    _ListaLavorazSuPreventivaz = mgr.FindAll("Ordine",
                                                             New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase))
                End Using
            End If

            Return _ListaLavorazSuPreventivaz
        End Get
    End Property


    Public Overrides Function IsValid() As Boolean Implements IListinoBase.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE

        If qta1 = 0 Then Ris = False
        If qta2 = 0 Then Ris = False
        If qta3 = 0 Then Ris = False
        If qta4 = 0 Then Ris = False
        If qta5 = 0 Then Ris = False
        If qta6 = 0 Then Ris = False

        If v1 = 0 Then Ris = False
        If v2 = 0 Then Ris = False
        If v3 = 0 Then Ris = False
        If v4 = 0 Then Ris = False
        If v5 = 0 Then Ris = False
        If v6 = 0 Then Ris = False

        'If p1 = 0 Then Ris = False
        'If p2 = 0 Then Ris = False
        'If p3 = 0 Then Ris = False
        'If p4 = 0 Then Ris = False
        'If p5 = 0 Then Ris = False
        'If p6 = 0 Then Ris = False
        If faccmin < 2 Then faccmin = 2
        If faccmax < 2 Then faccmax = 2
        'If FaccMin < 2 Then Ris = False
        If faccmax < faccmin Then Ris = False
        If _Nome.Length = 0 Then Ris = False
        If faccmin <> faccmax And MultiploQta = 0 Then Ris = False
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IListinoBase.Read
        Return MyBase.Read(Id)
    End Function

    Public Overrides Function Save() As Integer Implements IListinoBase.Save

        Dim FirstTime As Boolean = False
        If IdListinoBase = 0 Then FirstTime = True

        Dim ris As Integer = MyBase.Save()
        'salvo le lavorazioni
        Dim Contatore As Integer = ListaLavorazSuPreventivaz.Count

        If FirstTime = False Then
            Using mgr As New LavorazSuPreventivazDAO
                mgr.DeleteByIdListinoBase(IdListinoBase)
            End Using
        End If

        Dim Ordine As Integer = 0
        For Each l As Lavorazione In LavorazioniBase

            'For Each i As Lavorazione In chkListLav.CheckedItems
            '    'salvo le obbligatorie 
            Using x As New LavorazSuPreventivaz
                Ordine = 0
                If l.OrdineInListino Then
                    Ordine = l.OrdineInListino
                End If

                If Ordine = 0 Then
                    Using lav As LavorazSuPreventivaz = ListaLavorazSuPreventivaz.Find(Function(xx) xx.IdLavoro = l.IdLavoro)
                        If Not lav Is Nothing Then
                            Ordine = lav.Ordine
                        End If
                    End Using
                End If


                If FirstTime Then x.IdLavPrev = 0

                x.IdLavoro = l.IdLavoro
                x.IdListinoBase = IdListinoBase
                x.Ordine = Ordine
                x.Opzione = 0
                x.Save()

            End Using

        Next

        For Each l As Lavorazione In LavorazioniOpz

            'For Each i As Lavorazione In chkListLav.CheckedItems
            '    'salvo le obbligatorie 
            Using x As New LavorazSuPreventivaz
                Ordine = 0
                If l.OrdineInListino Then
                    Ordine = l.OrdineInListino
                End If

                If Ordine = 0 Then
                    Using lav As LavorazSuPreventivaz = ListaLavorazSuPreventivaz.Find(Function(xx) xx.IdLavoro = l.IdLavoro)
                        If Not lav Is Nothing Then
                            Ordine = lav.Ordine
                        End If
                    End Using
                End If

                If FirstTime Then x.IdLavPrev = 0

                x.IdLavoro = l.IdLavoro
                x.IdListinoBase = IdListinoBase
                x.Ordine = Ordine
                x.Opzione = 1
                x.Save()
            End Using
        Next

        Return ris

    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
#End Region


#Region "Forzato"

    Public Property ForzatoFormatoW As Integer Implements IListinoBaseB.ForzatoFormatoW

    Public Property ForzatoFormatoH As Integer Implements IListinoBaseB.ForzatoFormatoH

    Public Property ForzatoIdFormProd As Integer Implements IListinoBaseB.ForzatoIdFormProd

    Public Property ForzatoIdFormCarta As Integer Implements IListinoBaseB.ForzatoIdFormCarta

    Public Property ForzatoIdTipoCarta As Integer Implements IListinoBaseB.ForzatoIdTipoCarta

    Public ReadOnly Property TipoUnitaMisuraInInput As enUnitaDiMisura Implements IListinoBaseB.TipoUnitaMisuraInInput
        Get
            Dim Ris As enUnitaDiMisura = enUnitaDiMisura.Pezzi

            Ris = MgrCalcoliTecnici.GetUnitaMisuraInput(Me)

            Return Ris
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

Public Interface IListinoBase
    Inherits _IListinoBase

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface