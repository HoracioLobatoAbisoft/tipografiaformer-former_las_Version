#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 26/10/2023 
#End Region



''' <summary>
'''Entity Class for table Utn_autorizzato
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Utn_autorizzato
	Inherits _Utn_autorizzato
	Implements IUtn_autorizzato

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property Id() as integer
		Get
			Return MyBase.Id
		End Get
		Set (byval value as integer)
			MyBase.Id= value
		End Set
	End Property 


	Public Overrides Property IdUt() as integer
		Get
			Return MyBase.IdUt
		End Get
		Set (byval value as integer)
			MyBase.IdUt= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements IUtn_autorizzato.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IUtn_autorizzato.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Refresh() As Integer
		Return MyBase.Refresh
	End Function

	Public Overrides Function Save() As Integer Implements IUtn_autorizzato.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Utn_autorizzato
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IUtn_autorizzato
	Inherits _IUtn_autorizzato

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface