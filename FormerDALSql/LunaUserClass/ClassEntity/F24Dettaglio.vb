#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 27/12/2019 
#End Region



''' <summary>
'''Entity Class for table F24dettaglio
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class F24Dettaglio
	Inherits _F24Dettaglio
	Implements IF24Dettaglio

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdF24Dett() as integer
		Get
			Return MyBase.IdF24Dett
		End Get
		Set (byval value as integer)
			MyBase.IdF24Dett= value
		End Set
	End Property 


	Public Overrides Property Anno() as string
		Get
			Return MyBase.Anno
		End Get
		Set (byval value as string)
			MyBase.Anno= value
		End Set
	End Property 


	Public Overrides Property CausaleContributo() as string
		Get
			Return MyBase.CausaleContributo
		End Get
		Set (byval value as string)
			MyBase.CausaleContributo= value
		End Set
	End Property 


	Public Overrides Property CodiceRegione() as string
		Get
			Return MyBase.CodiceRegione
		End Get
		Set (byval value as string)
			MyBase.CodiceRegione= value
		End Set
	End Property 


	Public Overrides Property CodiceSede() as string
		Get
			Return MyBase.CodiceSede
		End Get
		Set (byval value as string)
			MyBase.CodiceSede= value
		End Set
	End Property 


	Public Overrides Property CodiceTributo() as string
		Get
			Return MyBase.CodiceTributo
		End Get
		Set (byval value as string)
			MyBase.CodiceTributo= value
		End Set
	End Property 


	Public Overrides Property IdF24() as integer
		Get
			Return MyBase.IdF24
		End Get
		Set (byval value as integer)
			MyBase.IdF24= value
		End Set
	End Property 


	Public Overrides Property IdSezione() as integer
		Get
			Return MyBase.IdSezione
		End Get
		Set (byval value as integer)
			MyBase.IdSezione= value
		End Set
	End Property 


	Public Overrides Property ImportiCredito() as string
		Get
			Return MyBase.ImportiCredito
		End Get
		Set (byval value as string)
			MyBase.ImportiCredito= value
		End Set
	End Property 


	Public Overrides Property ImportiDebito() as string
		Get
			Return MyBase.ImportiDebito
		End Get
		Set (byval value as string)
			MyBase.ImportiDebito= value
		End Set
	End Property 


	Public Overrides Property Mese() as string
		Get
			Return MyBase.Mese
		End Get
		Set (byval value as string)
			MyBase.Mese= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements IF24Dettaglio.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IF24Dettaglio.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IF24Dettaglio.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table F24dettaglio
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IF24Dettaglio
	Inherits _IF24Dettaglio

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface