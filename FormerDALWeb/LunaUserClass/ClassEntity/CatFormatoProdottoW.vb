#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 03/11/2016 
#End Region



''' <summary>
'''Entity Class for table Td_catformatoprodotto
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CatFormatoProdottoW
	Inherits _CatFormatoProdottoW
    Implements ICatFormatoProdottoW

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdCatFormatoProdotto() as integer
    Get
	    Return MyBase.IdCatFormatoProdotto
    End Get
    Set (byval value as integer)
        MyBase.IdCatFormatoProdotto= value
    End Set
End property 


Public Overrides Property Nome() as string
    Get
	    Return MyBase.Nome
    End Get
    Set (byval value as string)
        MyBase.Nome= value
    End Set
End property 


Public Overrides Property ImgRif() as string
    Get
	    Return MyBase.ImgRif
    End Get
    Set (byval value as string)
        MyBase.ImgRif= value
    End Set
End property 


Public Overrides Property DescrizioneEstesa() as string
    Get
	    Return MyBase.DescrizioneEstesa
    End Get
    Set (byval value as string)
        MyBase.DescrizioneEstesa= value
    End Set
End property


#End Region

#Region "Logic Field"

    Public ReadOnly Property DescrizioneHTML As String
        Get
            Return DescrizioneEstesa.Replace(vbNewLine, "<br />")
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICatFormatoProdottoW.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ICatFormatoProdottoW.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ICatFormatoProdottoW.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_catformatoprodotto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICatFormatoProdottoW
        Inherits _ICatFormatoProdottoW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface