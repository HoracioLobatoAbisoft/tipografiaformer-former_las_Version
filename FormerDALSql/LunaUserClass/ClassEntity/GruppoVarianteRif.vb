#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/11/2018 
#End Region



''' <summary>
'''Entity Class for table Tr_gruppovarianterif
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class GruppoVarianteRif
	Inherits _GruppoVarianteRif
	Implements IGruppoVarianteRif

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdGruppoVarianteDett() as integer
		Get
			Return MyBase.IdGruppoVarianteDett
		End Get
		Set (byval value as integer)
			MyBase.IdGruppoVarianteDett= value
		End Set
	End Property 


	Public Overrides Property IdGruppoVariante() as integer
		Get
			Return MyBase.IdGruppoVariante
		End Get
		Set (byval value as integer)
			MyBase.IdGruppoVariante= value
		End Set
	End Property 


	Public Overrides Property IdRiferimento() as integer
		Get
			Return MyBase.IdRiferimento
		End Get
		Set (byval value as integer)
			MyBase.IdRiferimento= value
		End Set
	End Property 


	Public Overrides Property TipoRiferimento() as integer
		Get
			Return MyBase.TipoRiferimento
		End Get
		Set (byval value as integer)
			MyBase.TipoRiferimento= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements IGruppoVarianteRif.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IGruppoVarianteRif.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IGruppoVarianteRif.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Tr_gruppovarianterif
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IGruppoVarianteRif
	Inherits _IGruppoVarianteRif

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface