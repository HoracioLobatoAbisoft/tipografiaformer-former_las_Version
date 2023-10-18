#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.2.29 
'Author: Diego Lunadei
'Date: 20/02/2018 
#End Region



''' <summary>
'''Entity Class for table T_ricavilog
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class LogRicavo
	Inherits _LogRicavo
	Implements ILogRicavo

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdLogRicavo() as integer
		Get
			Return MyBase.IdLogRicavo
		End Get
		Set (byval value as integer)
			MyBase.IdLogRicavo= value
		End Set
	End Property 


	Public Overrides Property Annotazioni() as string
		Get
			Return MyBase.Annotazioni
		End Get
		Set (byval value as string)
			MyBase.Annotazioni= value
		End Set
	End Property 


	Public Overrides Property IdOperatore() as integer
		Get
			Return MyBase.IdOperatore
		End Get
		Set (byval value as integer)
			MyBase.IdOperatore= value
		End Set
	End Property 


	Public Overrides Property IdRicavo() as integer
		Get
			Return MyBase.IdRicavo
		End Get
		Set (byval value as integer)
			MyBase.IdRicavo= value
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

	Public Overrides Function IsValid() As Boolean Implements ILogRicavo.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements ILogRicavo.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements ILogRicavo.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table T_ricavilog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ILogRicavo
	Inherits _ILogRicavo

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface