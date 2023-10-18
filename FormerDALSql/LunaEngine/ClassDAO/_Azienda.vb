#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 04/12/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Aziende
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Azienda
	Inherits LUNA.LunaBaseClassEntity
	Implements _IAzienda
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IAzienda.FillFromDataRecord
		IdAzienda = myRecord("IdAzienda")
		RagioneSociale = myRecord("RagioneSociale")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Azienda)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(AziendeDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Azienda))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdAzienda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RagioneSociale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdAzienda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RagioneSociale = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdAzienda as integer  = 0 
	Public Overridable Property IdAzienda() as integer  Implements _IAzienda.IdAzienda
		Get
			Return _IdAzienda
		End Get
		Set (byval value as integer)
			If _IdAzienda <> value Then
				IsChanged = True
				WhatIsChanged.IdAzienda = True
				_IdAzienda = value
			End If
		End Set
	End property 

	Protected _RagioneSociale as string  = "" 
	Public Overridable Property RagioneSociale() as string  Implements _IAzienda.RagioneSociale
		Get
			Return _RagioneSociale
		End Get
		Set (byval value as string)
			If _RagioneSociale <> value Then
				IsChanged = True
				WhatIsChanged.RagioneSociale = True
				_RagioneSociale = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Azienda from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Azienda = Manager.Read(Id)
				_IdAzienda = int.IdAzienda
				_RagioneSociale = int.RagioneSociale
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Azienda on DB.
	''' </summary>
	''' <returns>
	'''Return Id insert in DB if all ok, 0 if error
	''' </returns>
	Public Overridable Function Save() As Integer
		'Return the id Inserted
		Dim Ris As Integer = 0
		Try
			Using Manager
				Ris = Manager.Save(Me)
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ris
	End Function

	Protected Function InternalIsValid() As Boolean
		Dim Ris As Boolean = True
  
		if _RagioneSociale.Length = 0 then Ris = False
		if _RagioneSociale.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Aziende
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IAzienda

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdAzienda() as integer
	Property RagioneSociale() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Azienda
		Public Shared ReadOnly Property IdAzienda As New LUNA.LunaFieldName("IdAzienda")
		Public Shared ReadOnly Property RagioneSociale As New LUNA.LunaFieldName("RagioneSociale")
	End Class

End Class