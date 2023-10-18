#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 19/03/2014 
#End Region

Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib
Imports FormerGraphics

''' <summary>
'''Entity Class for table T_tipofustella
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TipoFustellaW
    Inherits _TipoFustellaW
    Implements ITipoFustellaW

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdTipoFustella() As Integer
        Get
            Return MyBase.IdTipoFustella
        End Get
        Set(ByVal value As Integer)
            MyBase.IdTipoFustella = value
        End Set
    End Property

    Public Overrides Property IdPrev() As Integer
        Get
            Return MyBase.IdPrev
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPrev = value
        End Set
    End Property

    Public Overrides Property Base() As Integer
        Get
            Return MyBase.Base
        End Get
        Set(ByVal value As Integer)
            MyBase.Base = value
        End Set
    End Property


    Public Overrides Property Profondita() As Integer
        Get
            Return MyBase.Profondita
        End Get
        Set(ByVal value As Integer)
            MyBase.Profondita = value
        End Set
    End Property


    Public Overrides Property Altezza() As Integer
        Get
            Return MyBase.Altezza
        End Get
        Set(ByVal value As Integer)
            MyBase.Altezza = value
        End Set
    End Property

    Public Overrides Property Disponibile() As Integer
        Get
            Return MyBase.Disponibile
        End Get
        Set(ByVal value As Integer)
            MyBase.Disponibile = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public Sub FillSVG(ByRef P As PreventivazioneW,
                       BrowserCompatibileSVG As Boolean)

        Dim mgr As New MgrPackagingDraw
        Dim Buffer As String = String.Empty

        If Base <> 0 And Altezza <> 0 And Profondita <> 0 Then
            Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P,
                                                                                Altezza,
                                                                                Base,
                                                                                Profondita)
            If BrowserCompatibileSVG Then
                Buffer = Rsteso.BufferSVG
            Else
                Buffer = "<img src=""" & P.GetImgMisure & """ class=""svgRend"">"
            End If
            RisultatoStesoAltezza = Rsteso.Heigth
            RisultatoStesoBase = Rsteso.Width
        Else
            Buffer = "<img src=""" & P.GetImgMisure & """ class=""svgRend"">"
        End If

        SvgRender = Buffer

    End Sub


    Public Property SvgRender As String = String.Empty


    Public RisultatoStesoAltezza As Integer = 0
    Public RisultatoStesoBase As Integer = 0

    Private _C As CatFustellaW = Nothing
    Public ReadOnly Property Categoria As CatFustellaW
        Get
            If _C Is Nothing Then
                If IdCatFustella Then
                    _C = New CatFustellaW
                    _C.Read(IdCatFustella)
                End If
            End If
            Return _C

        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ITipoFustellaW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ITipoFustellaW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ITipoFustellaW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_tipofustella
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITipoFustellaW
    Inherits _ITipoFustellaW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface