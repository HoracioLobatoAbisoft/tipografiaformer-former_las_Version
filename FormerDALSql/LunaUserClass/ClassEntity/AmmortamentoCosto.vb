#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 19/12/2019 
#End Region



''' <summary>
'''Entity Class for table Ammortamentocosti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class AmmortamentoCosto
	Inherits _AmmortamentoCosto
	Implements IAmmortamentoCosto

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdAmmCosto() as integer
		Get
			Return MyBase.IdAmmCosto
		End Get
		Set (byval value as integer)
			MyBase.IdAmmCosto= value
		End Set
	End Property 


	Public Overrides Property Anni() as integer
		Get
			Return MyBase.Anni
		End Get
		Set (byval value as integer)
			MyBase.Anni= value
		End Set
	End Property 


	Public Overrides Property AnnoEnd() as integer
		Get
			Return MyBase.AnnoEnd
		End Get
		Set (byval value as integer)
			MyBase.AnnoEnd= value
		End Set
	End Property 


	Public Overrides Property AnnoStart() as integer
		Get
			Return MyBase.AnnoStart
		End Get
		Set (byval value as integer)
			MyBase.AnnoStart= value
		End Set
	End Property 


	Public Overrides Property IdCosto() as integer
		Get
			Return MyBase.IdCosto
		End Get
		Set (byval value as integer)
			MyBase.IdCosto= value
		End Set
	End Property 


	Public Overrides Property ImportoAnnuo() as decimal
		Get
			Return MyBase.ImportoAnnuo
		End Get
		Set (byval value as decimal)
			MyBase.ImportoAnnuo= value
		End Set
	End Property 


	Public Overrides Property ImportoTotale() as decimal
		Get
			Return MyBase.ImportoTotale
		End Get
		Set (byval value as decimal)
			MyBase.ImportoTotale= value
		End Set
	End Property 


	Public Overrides Property PercTotale() as integer
		Get
			Return MyBase.PercTotale
		End Get
		Set (byval value as integer)
			MyBase.PercTotale= value
		End Set
	End Property


#End Region

#Region "Logic Field"
	Public ReadOnly Property Riassunto As String
		Get
			Dim ris As String = String.Empty
			Dim ImportoPrimoAnno As Decimal = 0
			Dim ImportoAnniSuccessivi As Decimal = 0


			ImportoPrimoAnno = (ImportoTotale / Anni) / 2

			ImportoAnniSuccessivi = (ImportoTotale - ((ImportoTotale / Anni) / 2)) / (Anni - 1)

			ris = "Piano di ammortamento attivo dal " & AnnoStart & " al " & AnnoEnd & " (" & Anni & " anni)" & ControlChars.NewLine
			ris &= "Percentuale " & PercTotale & "% "
			ris &= "Importo totale " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoTotale) & " - Importo 1° Anno " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoprimoAnno) &
				" - Importo anni succ. " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoAnniSuccessivi)

			Return ris
		End Get
	End Property

	Private _Costo As Costo = Nothing
	Public ReadOnly Property Costo As Costo
		Get
			If _Costo Is Nothing Then
				_Costo = New Costo
				_Costo.Read(IdCosto)
			End If
			Return _Costo
		End Get
	End Property
#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements IAmmortamentoCosto.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements IAmmortamentoCosto.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements IAmmortamentoCosto.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Ammortamentocosti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IAmmortamentoCosto
	Inherits _IAmmortamentoCosto

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface