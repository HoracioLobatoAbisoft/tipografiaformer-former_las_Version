#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 12/03/2019 
#End Region



''' <summary>
'''Entity Class for table T_checkmassivi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CheckMassivo
	Inherits _CheckMassivo
	Implements ICheckMassivo

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdCheckMassivo() as integer
		Get
			Return MyBase.IdCheckMassivo
		End Get
		Set (byval value as integer)
			MyBase.IdCheckMassivo= value
		End Set
	End Property 


	Public Overrides Property AnnoRiferimento() as integer
		Get
			Return MyBase.AnnoRiferimento
		End Get
		Set (byval value as integer)
			MyBase.AnnoRiferimento= value
		End Set
	End Property 


	Public Overrides Property FileInputPath() as string
		Get
			Return MyBase.FileInputPath
		End Get
		Set (byval value as string)
			MyBase.FileInputPath= value
		End Set
	End Property 


	Public Overrides Property FileOutputPath() as string
		Get
			Return MyBase.FileOutputPath
		End Get
		Set (byval value as string)
			MyBase.FileOutputPath= value
		End Set
	End Property 


	Public Overrides Property IdAzienda() as integer
		Get
			Return MyBase.IdAzienda
		End Get
		Set (byval value as integer)
			MyBase.IdAzienda= value
		End Set
	End Property 


	Public Overrides Property IdUtStep1() as integer
		Get
			Return MyBase.IdUtStep1
		End Get
		Set (byval value as integer)
			MyBase.IdUtStep1= value
		End Set
	End Property 


	Public Overrides Property IdUtStep2() as integer
		Get
			Return MyBase.IdUtStep2
		End Get
		Set (byval value as integer)
			MyBase.IdUtStep2= value
		End Set
	End Property 


	Public Overrides Property MeseRiferimento() as integer
		Get
			Return MyBase.MeseRiferimento
		End Get
		Set (byval value as integer)
			MyBase.MeseRiferimento= value
		End Set
	End Property 


	Public Overrides Property QuandoStep1() as DateTime
		Get
			Return MyBase.QuandoStep1
		End Get
		Set (byval value as DateTime)
			MyBase.QuandoStep1= value
		End Set
	End Property 


	Public Overrides Property QuandoStep2() as DateTime
		Get
			Return MyBase.QuandoStep2
		End Get
		Set (byval value as DateTime)
			MyBase.QuandoStep2= value
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


	Public Overrides Property TipoCheck() as integer
		Get
			Return MyBase.TipoCheck
		End Get
		Set (byval value as integer)
			MyBase.TipoCheck= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements ICheckMassivo.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements ICheckMassivo.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements ICheckMassivo.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table T_checkmassivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICheckMassivo
	Inherits _ICheckMassivo

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface