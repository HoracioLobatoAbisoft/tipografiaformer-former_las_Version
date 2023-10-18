#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 22/10/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib

''' <summary>
'''Entity Class for table Td_catfustelle
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CatFustellaW
	Inherits _CatFustellaW
    Implements ICatFustellaW

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdCatFustella() as integer
    Get
	    Return MyBase.IdCatFustella
    End Get
    Set (byval value as integer)
        MyBase.IdCatFustella= value
    End Set
End property 


Public Overrides Property Categoria() as string
    Get
	    Return MyBase.Categoria
    End Get
    Set (byval value as string)
        MyBase.Categoria= value
    End Set
End property 


Public Overrides Property Descrizione() as string
    Get
	    Return MyBase.Descrizione
    End Get
    Set (byval value as string)
        MyBase.Descrizione= value
    End Set
End property 


Public Overrides Property Anima() as integer
    Get
	    Return MyBase.Anima
    End Get
    Set (byval value as integer)
        MyBase.Anima= value
    End Set
End property 


Public Overrides Property LarghezzaMax() as integer
    Get
	    Return MyBase.LarghezzaMax
    End Get
    Set (byval value as integer)
        MyBase.LarghezzaMax= value
    End Set
End property 


#End Region

#Region "Logic Field"

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
            Dim _NomeInUrl As String = "Stampa-" & FormerHelper.Web.NormalizzaUrl(Categoria)
            Return _NomeInUrl
        End Get
    End Property

#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ICatFustellaW.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ICatFustellaW.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ICatFustellaW.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_catfustelle
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICatFustellaW
        Inherits _ICatFustellaW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface