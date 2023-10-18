#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 12/06/2020 
#End Region



''' <summary>
'''Entity Class for table Logoperativi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class LogOperativo
	Inherits _LogOperativo
	Implements ILogOperativo

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdLog() as integer
		Get
			Return MyBase.IdLog
		End Get
		Set (byval value as integer)
			MyBase.IdLog= value
		End Set
	End Property 


	Public Overrides Property Buffer() as string
		Get
			Return MyBase.Buffer
		End Get
		Set (byval value as string)
			MyBase.Buffer= value
		End Set
	End Property 


	Public Overrides Property IdRif() as integer
		Get
			Return MyBase.IdRif
		End Get
		Set (byval value as integer)
			MyBase.IdRif= value
		End Set
	End Property 


	Public Overrides Property Quando() as DateTime
		Get
			Return MyBase.Quando
		End Get
		Set (byval value as DateTime)
			MyBase.Quando= value
		End Set
	End Property 


	Public Overrides Property TipoLog() as integer
		Get
			Return MyBase.TipoLog
		End Get
		Set (byval value as integer)
			MyBase.TipoLog= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements ILogOperativo.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements ILogOperativo.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Refresh() As Integer
		Return MyBase.Refresh
	End Function

	Public Overrides Function Save() As Integer Implements ILogOperativo.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Logoperativi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ILogOperativo
	Inherits _ILogOperativo

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface