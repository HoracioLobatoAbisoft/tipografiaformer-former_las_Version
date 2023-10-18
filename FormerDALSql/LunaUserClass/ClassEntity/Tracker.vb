#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 20/09/2021 
#End Region



''' <summary>
'''Entity Class for table Tracker
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Tracker
	Inherits _Tracker
	Implements ITracker

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdTrack() as integer
		Get
			Return MyBase.IdTrack
		End Get
		Set (byval value as integer)
			MyBase.IdTrack= value
		End Set
	End Property 


	Public Overrides Property IdListinoBase() as integer
		Get
			Return MyBase.IdListinoBase
		End Get
		Set (byval value as integer)
			MyBase.IdListinoBase= value
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


	Public Overrides Property Quando() as DateTime
		Get
			Return MyBase.Quando
		End Get
		Set (byval value as DateTime)
			MyBase.Quando= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements ITracker.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements ITracker.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements ITracker.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Tracker
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITracker
	Inherits _ITracker

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface