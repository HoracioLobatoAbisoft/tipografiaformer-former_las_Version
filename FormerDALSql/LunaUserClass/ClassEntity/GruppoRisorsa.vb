#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 12/03/2019 
#End Region



''' <summary>
'''Entity Class for table T_gruppirisorsa
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class GruppoRisorsa
	Inherits _GruppoRisorsa
	Implements IGruppoRisorsa

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdGruppoRisorsa() as integer
		Get
			Return MyBase.IdGruppoRisorsa
		End Get
		Set (byval value as integer)
			MyBase.IdGruppoRisorsa= value
		End Set
	End Property 


	Public Overrides Property Nome() as string
		Get
			Return MyBase.Nome
		End Get
		Set (byval value as string)
			MyBase.Nome= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements IGruppoRisorsa.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IGruppoRisorsa.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IGruppoRisorsa.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table T_gruppirisorsa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IGruppoRisorsa
	Inherits _IGruppoRisorsa

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface