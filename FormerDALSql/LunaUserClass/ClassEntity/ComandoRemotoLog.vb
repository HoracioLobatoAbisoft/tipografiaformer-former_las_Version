#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 04/07/2019 
#End Region



''' <summary>
'''Entity Class for table Comandiremotilog
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ComandoRemotoLog
	Inherits _ComandoRemotoLog
	Implements IComandoRemotoLog

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdCMLog() as integer
		Get
			Return MyBase.IdCMLog
		End Get
		Set (byval value as integer)
			MyBase.IdCMLog= value
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


	Public Overrides Property IdOperazioneRemota() as integer
		Get
			Return MyBase.IdOperazioneRemota
		End Get
		Set (byval value as integer)
			MyBase.IdOperazioneRemota= value
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

	Public Overrides Function IsValid() As Boolean Implements IComandoRemotoLog.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IComandoRemotoLog.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IComandoRemotoLog.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Comandiremotilog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IComandoRemotoLog
	Inherits _IComandoRemotoLog

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface