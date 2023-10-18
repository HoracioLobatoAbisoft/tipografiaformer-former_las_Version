#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 21/02/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Nazioni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Nazione
	Inherits LUNA.LunaBaseClassEntity
	Implements _INazione
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _INazione.FillFromDataRecord
		IdNazione = myRecord("IdNazione")
		Code = myRecord("Code")
		if not myRecord("IdGruppo") is DBNull.Value then IdGruppo = myRecord("IdGruppo")
		Nazione = myRecord("Nazione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Nazione)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(NazioniDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Nazione))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdNazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Code As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdGruppo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdNazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Code = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdGruppo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nazione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdNazione as integer  = 0 
	Public Overridable Property IdNazione() as integer  Implements _INazione.IdNazione
		Get
			Return _IdNazione
		End Get
		Set (byval value as integer)
			If _IdNazione <> value Then
				IsChanged = True
				WhatIsChanged.IdNazione = True
				_IdNazione = value
			End If
		End Set
	End property 

	Protected _Code as string  = "" 
	Public Overridable Property Code() as string  Implements _INazione.Code
		Get
			Return _Code
		End Get
		Set (byval value as string)
			If _Code <> value Then
				IsChanged = True
				WhatIsChanged.Code = True
				_Code = value
			End If
		End Set
	End property 

	Protected _IdGruppo as integer  = 0 
	Public Overridable Property IdGruppo() as integer  Implements _INazione.IdGruppo
		Get
			Return _IdGruppo
		End Get
		Set (byval value as integer)
			If _IdGruppo <> value Then
				IsChanged = True
				WhatIsChanged.IdGruppo = True
				_IdGruppo = value
			End If
		End Set
	End property 

	Protected _Nazione as string  = "" 
	Public Overridable Property Nazione() as string  Implements _INazione.Nazione
		Get
			Return _Nazione
		End Get
		Set (byval value as string)
			If _Nazione <> value Then
				IsChanged = True
				WhatIsChanged.Nazione = True
				_Nazione = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Nazione from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Nazione = Manager.Read(Id)
				_IdNazione = int.IdNazione
				_Code = int.Code
				_IdGruppo = int.IdGruppo
				_Nazione = int.Nazione
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Nazione on DB.
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
  
		if _Code.Length = 0 then Ris = False
		if _Code.Length > 2 then Ris = False
  
		if _Nazione.Length = 0 then Ris = False
		if _Nazione.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Nazioni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _INazione

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdNazione() as integer
	Property Code() as string
	Property IdGruppo() as integer
	Property Nazione() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Nazione
		Public Shared ReadOnly Property IdNazione As New LUNA.LunaFieldName("IdNazione")
		Public Shared ReadOnly Property Code As New LUNA.LunaFieldName("Code")
		Public Shared ReadOnly Property IdGruppo As New LUNA.LunaFieldName("IdGruppo")
		Public Shared ReadOnly Property Nazione As New LUNA.LunaFieldName("Nazione")
	End Class

End Class