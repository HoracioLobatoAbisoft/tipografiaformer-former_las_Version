#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.7.9 
'Author: Diego Lunadei
'Date: 31/07/2019 
#End Region



''' <summary>
'''Entity Class for table Richiestepreventivo
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class RichiestaPreventivo
	Inherits _RichiestaPreventivo
	Implements IRichiestaPreventivo

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdRP() as integer
		Get
			Return MyBase.IdRP
		End Get
		Set (byval value as integer)
			MyBase.IdRP= value
		End Set
	End Property 


	Public Overrides Property BufferXML() as string
		Get
			Return MyBase.BufferXML
		End Get
		Set (byval value as string)
			MyBase.BufferXML= value
		End Set
	End Property 


	Public Overrides Property IdLb() as integer
		Get
			Return MyBase.IdLb
		End Get
		Set (byval value as integer)
			MyBase.IdLb= value
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
    Public ReadOnly Property Numero As String
        Get
            Dim ris As String = Quando.Year
            ris &= IdRP.ToString("00000")
            Return ris
        End Get

    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IRichiestaPreventivo.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IRichiestaPreventivo.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IRichiestaPreventivo.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Richiestepreventivo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IRichiestaPreventivo
	Inherits _IRichiestaPreventivo

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface