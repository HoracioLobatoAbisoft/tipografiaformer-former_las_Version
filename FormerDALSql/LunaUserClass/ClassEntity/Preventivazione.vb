#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region

Imports System.Drawing
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerLib
Imports FormerConfig

''' <summary>
'''Entity Class for table T_preventivazione
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Preventivazione
    Inherits _Preventivazione
    Implements IPreventivazione, IPreventivazioneB

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Database Field"

    Public Overrides Property IdPrev As Integer Implements IPreventivazioneB.IdPrev
        Get
            Return MyBase.IdPrev
        End Get
        Set(value As Integer)
            MyBase.IdPrev = value
        End Set
    End Property

    Public Overrides Property Prefisso As String Implements IPreventivazioneB.Prefisso
        Get
            Return MyBase.Prefisso
        End Get
        Set(value As String)
            MyBase.Prefisso = value
        End Set
    End Property

    Public Overrides Property TipoProd As Integer Implements IPreventivazioneB.TipoProd
        Get
            Return MyBase.TipoProd
        End Get
        Set(value As Integer)
            MyBase.TipoProd = value
        End Set
    End Property

    Public Overrides Property Descrizione As String Implements IPreventivazioneB.Descrizione
        Get
            Return MyBase.Descrizione
        End Get
        Set(value As String)
            MyBase.Descrizione = value
        End Set
    End Property

    Public Overrides Property DescrizioneEstesa As String Implements IPreventivazioneB.DescrizioneEstesa
        Get
            Return MyBase.DescrizioneEstesa
        End Get
        Set(value As String)
            MyBase.DescrizioneEstesa = value
        End Set
    End Property

    Public Overrides Property ggFast As Integer Implements IPreventivazioneB.ggFast
        Get
            Return MyBase.ggFast
        End Get
        Set(value As Integer)
            MyBase.ggFast = value
        End Set
    End Property

    Public Overrides Property ggNorm As Integer Implements IPreventivazioneB.ggNorm
        Get
            Return MyBase.ggNorm
        End Get
        Set(value As Integer)
            MyBase.ggNorm = value
        End Set
    End Property

    Public Overrides Property ggSlow As Integer Implements IPreventivazioneB.ggSlow
        Get
            Return MyBase.ggSlow
        End Get
        Set(value As Integer)
            MyBase.ggSlow = value
        End Set
    End Property

    Public Overrides Property RicaricoPubblico As Integer Implements IPreventivazioneB.RicaricoPubblico
        Get
            Return MyBase.RicaricoPubblico
        End Get
        Set(value As Integer)
            MyBase.RicaricoPubblico = value
        End Set
    End Property

    Public Overrides Property GraficaPerFacciata As Decimal Implements IPreventivazioneB.GraficaPerFacciata
        Get
            Return MyBase.GraficaPerFacciata
        End Get
        Set(value As Decimal)
            MyBase.GraficaPerFacciata = value
        End Set
    End Property

    Public Overrides Property ImgRif As String Implements IPreventivazioneB.ImgRif
        Get
            Return MyBase.ImgRif
        End Get
        Set(value As String)
            MyBase.ImgRif = value
        End Set
    End Property

    Public Overrides Property ImgSito As String Implements IPreventivazioneB.ImgSito
        Get
            Return MyBase.ImgSito
        End Get
        Set(value As String)
            MyBase.ImgSito = value
        End Set
    End Property

    Public Overrides Property UrlVideo As String Implements IPreventivazioneB.UrlVideo
        Get
            Return MyBase.UrlVideo
        End Get
        Set(value As String)
            MyBase.UrlVideo = value
        End Set
    End Property

    Public Overrides Property IdReparto As Integer Implements IPreventivazioneB.IdReparto
        Get
            Return MyBase.IdReparto
        End Get
        Set(value As Integer)
            MyBase.IdReparto = value
        End Set
    End Property

    Public Overrides Property DispOnline As Boolean Implements IPreventivazioneB.DispOnline
        Get
            Return MyBase.DispOnline
        End Get
        Set(value As Boolean)
            MyBase.DispOnline = value
        End Set
    End Property

    Public Overrides Property IdFunzionePack() As Integer Implements IPreventivazioneB.IdFunzionePack
        Get
            Return MyBase.IdFunzionePack
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFunzionePack = value
        End Set
    End Property

    Public Overrides Property IdPluginToUse() As Integer Implements IPreventivazioneB.IdPluginToUse
        Get
            Return MyBase.IdPluginToUse
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPluginToUse = value
        End Set
    End Property

    Public Overrides Property Linguetta() As Integer Implements IPreventivazioneB.Linguetta
        Get
            Return MyBase.Linguetta
        End Get
        Set(ByVal value As Integer)
            MyBase.Linguetta = value
        End Set
    End Property

    Public Overrides Property PercFast As Integer Implements IPreventivazioneB.PercFast
        Get
            Return MyBase.PercFast
        End Get
        Set(value As Integer)
            MyBase.PercFast = value
        End Set
    End Property

    Public Overrides Property PercSlow As Integer Implements IPreventivazioneB.PercSlow
        Get
            Return MyBase.PercSlow
        End Get
        Set(value As Integer)
            MyBase.PercSlow = value
        End Set
    End Property

#End Region

#Region "Logic Field"

    Private _GruppoVarianteRif As GruppoVariante = Nothing
    Public ReadOnly Property GruppoVarianteRif As GruppoVariante
        Get
            If _GruppoVarianteRif Is Nothing Then
                If GruppoVariante Then
                    _GruppoVarianteRif = New GruppoVariante
                    _GruppoVarianteRif.Read(GruppoVariante)
                End If
            End If
            Return _GruppoVarianteRif
        End Get
    End Property

    Public Property ListiniLinkati As New List(Of ListinoBase)

    Public Property ListiniBase As New List(Of ListinoBase)
    Public Property ListiniBaseNascosti As New List(Of ListinoBase)

    Public Function Anteprima() As String
        'return path of html anteprima

        Dim Ris As String = ""

        Dim bufferhtml As String = ""

        bufferhtml = "<HTML><HEAD><TITLE>Riepilogo</TITLE></HEAD><BODY BGCOLOR=""WHITE""><FONT SIZE=1 face=Arial>" & ControlChars.NewLine
        bufferhtml &= "<IMG SRC=""" & _ImgSito & """ width=""800"" height=""150"" border=1><br>"
        bufferhtml &= "<TABLE WIDTH=100%>"
        bufferhtml &= "<TR bgcolor=""#9c1020"">"
        bufferhtml &= "<TD bgcolor=white width=128>"
        bufferhtml &= "<IMG SRC=""" & _ImgRif & """ ALIGN=ABSMIDDLE></TD>"
        bufferhtml &= "<TD valign=top><FONT  face=Arial COLOR=WHITE><H3>" & _Descrizione

        If _TipoProd = enTipoProdCom.StampaOffSet Then
            bufferhtml &= " (Offset)"
        Else
            bufferhtml &= " (Digitale)"
        End If

        bufferhtml &= "</H3>" & _DescrizioneEstesa & "</FONT>"
        bufferhtml &= "</TD>"
        bufferhtml &= "</TR></TABLE>"

        CaricaListinoBase(, enTipoListiniBase.Sorgente)
        bufferhtml &= "<TABLE WIDTH=100%>"
        bufferhtml &= "<TR bgcolor=""#9c1020"">"
        bufferhtml &= "<TD><font size=1 color=White>Nome</TD>"
        bufferhtml &= "<TD><font size=1 color=White>Curva</TD>"
        bufferhtml &= "<TD><font size=1 color=White>Formato</TD>"
        bufferhtml &= "<TD><font  size=1color=White>Tipo Carta</TD>"
        bufferhtml &= "<TD><font size=1 color=White>Colore</TD>"
        bufferhtml &= "<TD><font size=1 color=White>Q1</TD>"
        bufferhtml &= "<TD><font size=1 color=White>Q2</TD>"
        bufferhtml &= "<TD><foNT size=1 color=White>Q3</TD>"
        bufferhtml &= "<TD><foNT size=1 color=White>Q4</TD>"
        bufferhtml &= "<TD><foNT size=1 color=White>Q5</TD>"
        bufferhtml &= "<TD><foNT size=1 color=White>Q6</TD>"
        bufferhtml &= "<TD><foNT size=1 color=White>Lavoraz. Obbl.</TD>"
        bufferhtml &= "<TD><foNT size=1 color=White>Lavoraz. Opz.</TD>"
        bufferhtml &= "</TR>"

        For Each l As ListinoBase In ListiniBase
            bufferhtml &= "<TR bgcolor=""white"">"
            bufferhtml &= "<TD><font face=Arial size=1>" & l.Nome & "<br>(" & l.NomeInterno & ")</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>" & l.CurvaStr & "</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>" & l.FormatoStr & "</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>" & l.TipoCartaStr & "</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>" & l.ColoreStampaStr & "</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>pz " & l.qta1 & "<br>&#8364;" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(l.v1) & "</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>pz " & l.qta2 & "<br>&#8364;" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(l.v2) & "</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>pz " & l.qta3 & "<br>&#8364;" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(l.v3) & "</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>pz " & l.qta4 & "<br>&#8364;" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(l.v4) & "</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>pz " & l.qta5 & "<br>&#8364;" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(l.v5) & "</TD>"
            bufferhtml &= "<TD><font face=Arial size=1>pz " & l.qta6 & "<br>&#8364;" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(l.v6) & "</TD>"
            bufferhtml &= "<TD>"

            l.CaricaLavorazioni()
            'l.caricalavorazionibase
            For Each lav As Lavorazione In l.LavorazioniBase
                bufferhtml &= "<img src=""" & lav.ImgRif & """ width=64>"
            Next
            bufferhtml &= "</TD>"
            bufferhtml &= "<TD>"
            'l.CaricaLavorazioniOpz()
            For Each lav As Lavorazione In l.LavorazioniOpz
                bufferhtml &= "<img src=""" & lav.ImgRif & """ width=64>"
            Next
            bufferhtml &= "</TD>"

            bufferhtml &= "</TR>"
        Next

        bufferhtml &= "</TABLE>"

        bufferhtml &= "</BODY></HTML>" & ControlChars.NewLine

        Dim Sr As StreamWriter, PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")
        Sr = New System.IO.StreamWriter(PathFileStampa, False)

        Sr.Write(bufferhtml)

        Sr.Close()
        'sr = Nothing

        Ris = PathFileStampa

        Return Ris

    End Function

    Public Sub CaricaListiniLinkati()

        Dim LstB As List(Of PrevLinkListino) = Nothing

        Using MgrPL As New PrevLinkListinoDAO
            LstB = MgrPL.FindAll(New LUNA.LunaSearchParameter("IdPreventivazione", _IdPrev))

        End Using

        Dim l As New List(Of ListinoBase)

        For Each pl As PrevLinkListino In LstB
            Dim singL As New ListinoBase
            singL.Read(pl.IdListinoBase)
            singL.CaricaLavorazioni()
            'l.CaricaLavorazioniBase()
            'l.CaricaLavorazioniOpz()
            l.Add(singL)
        Next

        Using mgrP As New PreventivazioniDAO
            mgrP.OrdinaListinoPerFormatoProd(l)
        End Using
        ListiniLinkati = l
    End Sub

    Public Sub CaricaListinoBase(Optional OrdinamentoPredefinito As Boolean = True,
                                 Optional TipoListini As enTipoListiniBase = enTipoListiniBase.Tutto)
        Dim LstB As List(Of ListinoBase) = Nothing
        Using mgr As New ListinoBaseDAO

            Dim parHidden As LUNA.LunaSearchParameter = Nothing
            'If OnlyHidden Then
            '    parHidden = New LUNA.LunaSearchParameter(LFM.ListinoBase.NascondiOnline, enSiNo.Si)
            'Else
            parHidden = New LUNA.LunaSearchParameter(LFM.ListinoBase.NascondiOnline, enSiNo.Si, "<>")
            'End If

            Dim parTipo As LUNA.LunaSearchParameter

            If TipoListini = enTipoListiniBase.Sorgente Then
                parTipo = New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0)
            ElseIf TipoListini = enTipoListiniBase.Produzione Then
                parTipo = New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0, "<>")
            End If

            LstB = mgr.FindAll("IdFormato, IdTipoCarta",
                               New LUNA.LunaSearchParameter("IdPrev", _IdPrev),
                               New LUNA.LunaSearchParameter("Disattivo", enSiNo.Si, "<>"),
                               parHidden,
                               parTipo)

            For Each l As ListinoBase In LstB
                l.CaricaLavorazioni()
                'l.CaricaLavorazioniBase()
                'l.CaricaLavorazioniOpz()
            Next

            If OrdinamentoPredefinito Then
                Using mgrP As New PreventivazioniDAO
                    mgrP.OrdinaListinoPerFormatoProd(LstB)
                End Using
            End If

            ListiniBase = LstB

            Dim LstH As List(Of ListinoBase) = Nothing

            parHidden = New LUNA.LunaSearchParameter(LFM.ListinoBase.NascondiOnline, enSiNo.Si)

            LstH = mgr.FindAll("IdFormato, IdTipoCarta",
                               New LUNA.LunaSearchParameter("IdPrev", _IdPrev),
                               New LUNA.LunaSearchParameter("Disattivo", enSiNo.Si, "<>"),
                               parHidden,
                               parTipo)

            For Each l As ListinoBase In LstH
                l.CaricaLavorazioni()
                'l.CaricaLavorazioniBase()
                'l.CaricaLavorazioniOpz()
            Next

            If OrdinamentoPredefinito Then
                Using mgrP As New PreventivazioniDAO
                    mgrP.OrdinaListinoPerFormatoProd(LstH)
                End Using
            End If

            ListiniBaseNascosti = LstH
        End Using


    End Sub

    Public ReadOnly Property DescrizioneConReparto As String
        Get
            Return FormerEnumHelper.RepartoStr(IdReparto).ToUpper & " - " & Descrizione
        End Get
    End Property

    Public ReadOnly Property ListiniBaseB As List(Of IListinoBaseB) Implements IPreventivazioneB.ListiniBase
        Get
            CaricaListinoBase(, enTipoListiniBase.Produzione)
            Dim l As New List(Of IListinoBaseB)

            For Each singLB As ListinoBase In ListiniBase
                l.Add(singLB)
            Next
            Return l
        End Get
    End Property

    Public ReadOnly Property Img As Image
        Get
            Dim ris As Image = Nothing
            If _ImgRif.Length Then
                If File.Exists(_ImgRif) Then
                    Try
                        ris = Image.FromFile(_ImgRif)
                    Catch ex As Exception

                    End Try
                End If
            Else
                ris = My.Resources.no_image

            End If
            Return ris
        End Get
    End Property

#End Region

#Region "Method"



    Public Overrides Function IsValid() As Boolean Implements IPreventivazione.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        If _Prefisso.Length = 0 Then Ris = False
        If _Descrizione.Length = 0 Then Ris = False
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IPreventivazione.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IPreventivazione.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

Public Class PreventivazioneValidator
    Inherits Preventivazione
    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub
    Public Property ErrorLevelDimensioniNonCorrette As Integer
    Public Property ErrorLevelOrientamentoNonCorretto As Integer
    Public Property ErrorLevelFontIncorporati As Integer
    Public Property ErrorLevelFontNonIncorporati As Integer
    Public Property ErrorLevelAbbondanzaErrata As Integer

End Class

''' <summary>
'''Interface for table T_preventivazione
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPreventivazione
    Inherits _IPreventivazione

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface