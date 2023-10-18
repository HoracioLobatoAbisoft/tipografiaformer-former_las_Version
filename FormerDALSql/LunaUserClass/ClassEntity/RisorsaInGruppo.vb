#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 12/03/2019 
#End Region



''' <summary>
'''Entity Class for table Tr_risorsagruppo
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class RisorsaInGruppo
	Inherits _RisorsaInGruppo
	Implements IRisorsaInGruppo

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdRisGruppo() as integer
		Get
			Return MyBase.IdRisGruppo
		End Get
		Set (byval value as integer)
			MyBase.IdRisGruppo= value
		End Set
	End Property 


	Public Overrides Property IdGruppo() as integer
		Get
			Return MyBase.IdGruppo
		End Get
		Set (byval value as integer)
			MyBase.IdGruppo= value
		End Set
	End Property 


	Public Overrides Property IdRisorsa() as integer
		Get
			Return MyBase.IdRisorsa
		End Get
		Set (byval value as integer)
			MyBase.IdRisorsa= value
		End Set
	End Property


#End Region

#Region "Logic Field"
    Public ReadOnly Property NomeGruppo As String
        Get
            Dim ris As String = String.Empty

            Using g As New GruppoRisorsa
                g.Read(IdGruppo)
                ris = g.Nome
            End Using
            Return ris
        End Get
    End Property



#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IRisorsaInGruppo.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IRisorsaInGruppo.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IRisorsaInGruppo.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Tr_risorsagruppo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IRisorsaInGruppo
	Inherits _IRisorsaInGruppo

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface