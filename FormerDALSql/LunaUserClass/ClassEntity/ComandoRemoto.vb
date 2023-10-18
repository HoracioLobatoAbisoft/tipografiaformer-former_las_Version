#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 04/07/2019 
#End Region



''' <summary>
'''Entity Class for table Comandiremoti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ComandoRemoto
	Inherits _ComandoRemoto
	Implements IComandoRemoto

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdCM() as integer
		Get
			Return MyBase.IdCM
		End Get
		Set (byval value as integer)
			MyBase.IdCM= value
		End Set
	End Property 


	Public Overrides Property IdCom() as integer
		Get
			Return MyBase.IdCom
		End Get
		Set (byval value as integer)
			MyBase.IdCom= value
		End Set
	End Property 


	Public Overrides Property IdOrd() as integer
		Get
			Return MyBase.IdOrd
		End Get
		Set (byval value as integer)
			MyBase.IdOrd= value
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


	Public Overrides Property Stato() as integer
		Get
			Return MyBase.Stato
		End Get
		Set (byval value as integer)
			MyBase.Stato= value
		End Set
	End Property 


	Public Overrides Property TipoOperazione() as integer
		Get
			Return MyBase.TipoOperazione
		End Get
		Set (byval value as integer)
			MyBase.TipoOperazione= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements IComandoRemoto.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IComandoRemoto.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IComandoRemoto.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Comandiremoti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IComandoRemoto
	Inherits _IComandoRemoto

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface