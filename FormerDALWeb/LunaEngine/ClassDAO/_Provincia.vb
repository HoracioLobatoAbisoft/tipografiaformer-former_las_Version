#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Province
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Provincia
	Inherits LUNA.LunaBaseClassEntity
	Implements _IProvincia
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IProvincia.FillFromDataRecord
		ID = myRecord("ID")
		if not myRecord("Cod") is DBNull.Value then Cod = myRecord("Cod")
		if not myRecord("DTVARIAZIONE") is DBNull.Value then DTVARIAZIONE = myRecord("DTVARIAZIONE")
		if not myRecord("FLGVARIAZIONE") is DBNull.Value then FLGVARIAZIONE = myRecord("FLGVARIAZIONE")
		if not myRecord("IdRegione") is DBNull.Value then IdRegione = myRecord("IdRegione")
		if not myRecord("ordine") is DBNull.Value then ordine = myRecord("ordine")
		if not myRecord("PROVINCIA") is DBNull.Value then PROVINCIA = myRecord("PROVINCIA")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Provincia)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ProvinceDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Provincia))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property ID As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cod As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DTVARIAZIONE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FLGVARIAZIONE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRegione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PROVINCIA As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.ID = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cod = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DTVARIAZIONE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FLGVARIAZIONE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRegione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ordine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PROVINCIA = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _ID as integer  = 0 
	Public Overridable Property ID() as integer  Implements _IProvincia.ID
		Get
			Return _ID
		End Get
		Set (byval value as integer)
			If _ID <> value Then
				IsChanged = True
				WhatIsChanged.ID = True
				_ID = value
			End If
		End Set
	End property 

	Protected _Cod as string  = "" 
	Public Overridable Property Cod() as string  Implements _IProvincia.Cod
		Get
			Return _Cod
		End Get
		Set (byval value as string)
			If _Cod <> value Then
				IsChanged = True
				WhatIsChanged.Cod = True
				_Cod = value
			End If
		End Set
	End property 

	Protected _DTVARIAZIONE as string  = "" 
	Public Overridable Property DTVARIAZIONE() as string  Implements _IProvincia.DTVARIAZIONE
		Get
			Return _DTVARIAZIONE
		End Get
		Set (byval value as string)
			If _DTVARIAZIONE <> value Then
				IsChanged = True
				WhatIsChanged.DTVARIAZIONE = True
				_DTVARIAZIONE = value
			End If
		End Set
	End property 

	Protected _FLGVARIAZIONE as integer  = 0 
	Public Overridable Property FLGVARIAZIONE() as integer  Implements _IProvincia.FLGVARIAZIONE
		Get
			Return _FLGVARIAZIONE
		End Get
		Set (byval value as integer)
			If _FLGVARIAZIONE <> value Then
				IsChanged = True
				WhatIsChanged.FLGVARIAZIONE = True
				_FLGVARIAZIONE = value
			End If
		End Set
	End property 

	Protected _IdRegione as integer  = 0 
	Public Overridable Property IdRegione() as integer  Implements _IProvincia.IdRegione
		Get
			Return _IdRegione
		End Get
		Set (byval value as integer)
			If _IdRegione <> value Then
				IsChanged = True
				WhatIsChanged.IdRegione = True
				_IdRegione = value
			End If
		End Set
	End property 

	Protected _ordine as integer  = 0 
	Public Overridable Property ordine() as integer  Implements _IProvincia.ordine
		Get
			Return _ordine
		End Get
		Set (byval value as integer)
			If _ordine <> value Then
				IsChanged = True
				WhatIsChanged.ordine = True
				_ordine = value
			End If
		End Set
	End property 

	Protected _PROVINCIA as string  = "" 
	Public Overridable Property PROVINCIA() as string  Implements _IProvincia.PROVINCIA
		Get
			Return _PROVINCIA
		End Get
		Set (byval value as string)
			If _PROVINCIA <> value Then
				IsChanged = True
				WhatIsChanged.PROVINCIA = True
				_PROVINCIA = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Provincia from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Provincia = Manager.Read(Id)
				_ID = int.ID
				_Cod = int.Cod
				_DTVARIAZIONE = int.DTVARIAZIONE
				_FLGVARIAZIONE = int.FLGVARIAZIONE
				_IdRegione = int.IdRegione
				_ordine = int.ordine
				_PROVINCIA = int.PROVINCIA
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Provincia on DB.
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
		if _Cod.Length > 255 then Ris = False
		if _DTVARIAZIONE.Length > 255 then Ris = False
		if _PROVINCIA.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Province
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IProvincia

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property ID() as integer
	Property Cod() as string
	Property DTVARIAZIONE() as string
	Property FLGVARIAZIONE() as integer
	Property IdRegione() as integer
	Property ordine() as integer
	Property PROVINCIA() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Provincia
		Public Shared ReadOnly Property ID As New LUNA.LunaFieldName("ID")
		Public Shared ReadOnly Property Cod As New LUNA.LunaFieldName("Cod")
		Public Shared ReadOnly Property DTVARIAZIONE As New LUNA.LunaFieldName("DTVARIAZIONE")
		Public Shared ReadOnly Property FLGVARIAZIONE As New LUNA.LunaFieldName("FLGVARIAZIONE")
		Public Shared ReadOnly Property IdRegione As New LUNA.LunaFieldName("IdRegione")
		Public Shared ReadOnly Property ordine As New LUNA.LunaFieldName("ordine")
		Public Shared ReadOnly Property PROVINCIA As New LUNA.LunaFieldName("PROVINCIA")
	End Class

End Class