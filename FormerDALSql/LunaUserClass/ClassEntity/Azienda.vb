#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 04/12/2018 
#End Region



''' <summary>
'''Entity Class for table Aziende
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Azienda
	Inherits _Azienda
	Implements IAzienda

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdAzienda() as integer
		Get
			Return MyBase.IdAzienda
		End Get
		Set (byval value as integer)
			MyBase.IdAzienda= value
		End Set
	End Property 


	Public Overrides Property RagioneSociale() as string
		Get
			Return MyBase.RagioneSociale
		End Get
		Set (byval value as string)
			MyBase.RagioneSociale= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements IAzienda.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IAzienda.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IAzienda.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Aziende
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IAzienda
	Inherits _IAzienda

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface