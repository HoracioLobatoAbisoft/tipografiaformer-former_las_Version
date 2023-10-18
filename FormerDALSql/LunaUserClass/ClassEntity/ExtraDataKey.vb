#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 06/12/2019 
#End Region



''' <summary>
'''Entity Class for table Extradata
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ExtraDataKey
	Inherits _ExtraDataKey
	Implements IExtraDataKey

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdExtraData() as integer
		Get
			Return MyBase.IdExtraData
		End Get
		Set (byval value as integer)
			MyBase.IdExtraData= value
		End Set
	End Property 


	Public Overrides Property Chiave() as string
		Get
			Return MyBase.Chiave
		End Get
		Set (byval value as string)
			MyBase.Chiave= value
		End Set
	End Property 


	Public Overrides Property Tipo() as string
		Get
			Return MyBase.Tipo
		End Get
		Set (byval value as string)
			MyBase.Tipo= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements IExtraDataKey.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IExtraDataKey.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IExtraDataKey.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Extradata
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IExtraDataKey
	Inherits _IExtraDataKey

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface