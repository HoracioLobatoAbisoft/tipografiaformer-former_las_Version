#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 29/12/2017 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_azionisottoscorta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _AzioneSottoscorta
	Inherits LUNA.LunaBaseClassEntity
	Implements _IAzioneSottoscorta
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IAzioneSottoscorta.FillFromDataRecord
		IdRegola = myRecord("IdRegola")
		Azione = myRecord("Azione")
		if not myRecord("IdDestMessaggio") is DBNull.Value then IdDestMessaggio = myRecord("IdDestMessaggio")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		IdRisorsa = myRecord("IdRisorsa")
		if not myRecord("PathFile") is DBNull.Value then PathFile = myRecord("PathFile")
		if not myRecord("QtaOrdine") is DBNull.Value then QtaOrdine = myRecord("QtaOrdine")
		if not myRecord("StampareReminder") is DBNull.Value then StampareReminder = myRecord("StampareReminder")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of AzioneSottoscorta)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(AzioniSottoscortaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of AzioneSottoscorta))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdRegola As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Azione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdDestMessaggio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRisorsa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PathFile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property QtaOrdine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StampareReminder As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdRegola = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Azione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdDestMessaggio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRisorsa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PathFile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.QtaOrdine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StampareReminder = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdRegola as integer  = 0 
	Public Overridable Property IdRegola() as integer  Implements _IAzioneSottoscorta.IdRegola
		Get
			Return _IdRegola
		End Get
		Set (byval value as integer)
			If _IdRegola <> value Then
				IsChanged = True
				WhatIsChanged.IdRegola = True
				_IdRegola = value
			End If
		End Set
	End property 

	Protected _Azione as integer  = 0 
	Public Overridable Property Azione() as integer  Implements _IAzioneSottoscorta.Azione
		Get
			Return _Azione
		End Get
		Set (byval value as integer)
			If _Azione <> value Then
				IsChanged = True
				WhatIsChanged.Azione = True
				_Azione = value
			End If
		End Set
	End property 

	Protected _IdDestMessaggio as integer  = 0 
	Public Overridable Property IdDestMessaggio() as integer  Implements _IAzioneSottoscorta.IdDestMessaggio
		Get
			Return _IdDestMessaggio
		End Get
		Set (byval value as integer)
			If _IdDestMessaggio <> value Then
				IsChanged = True
				WhatIsChanged.IdDestMessaggio = True
				_IdDestMessaggio = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IAzioneSottoscorta.IdListinoBase
		Get
			Return _IdListinoBase
		End Get
		Set (byval value as integer)
			If _IdListinoBase <> value Then
				IsChanged = True
				WhatIsChanged.IdListinoBase = True
				_IdListinoBase = value
			End If
		End Set
	End property 

	Protected _IdRisorsa as integer  = 0 
	Public Overridable Property IdRisorsa() as integer  Implements _IAzioneSottoscorta.IdRisorsa
		Get
			Return _IdRisorsa
		End Get
		Set (byval value as integer)
			If _IdRisorsa <> value Then
				IsChanged = True
				WhatIsChanged.IdRisorsa = True
				_IdRisorsa = value
			End If
		End Set
	End property 

	Protected _PathFile as string  = "" 
	Public Overridable Property PathFile() as string  Implements _IAzioneSottoscorta.PathFile
		Get
			Return _PathFile
		End Get
		Set (byval value as string)
			If _PathFile <> value Then
				IsChanged = True
				WhatIsChanged.PathFile = True
				_PathFile = value
			End If
		End Set
	End property 

	Protected _QtaOrdine as integer  = 0 
	Public Overridable Property QtaOrdine() as integer  Implements _IAzioneSottoscorta.QtaOrdine
		Get
			Return _QtaOrdine
		End Get
		Set (byval value as integer)
			If _QtaOrdine <> value Then
				IsChanged = True
				WhatIsChanged.QtaOrdine = True
				_QtaOrdine = value
			End If
		End Set
	End property 

	Protected _StampareReminder as integer  = 0 
	Public Overridable Property StampareReminder() as integer  Implements _IAzioneSottoscorta.StampareReminder
		Get
			Return _StampareReminder
		End Get
		Set (byval value as integer)
			If _StampareReminder <> value Then
				IsChanged = True
				WhatIsChanged.StampareReminder = True
				_StampareReminder = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an AzioneSottoscorta from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As AzioneSottoscorta = Manager.Read(Id)
				_IdRegola = int.IdRegola
				_Azione = int.Azione
				_IdDestMessaggio = int.IdDestMessaggio
				_IdListinoBase = int.IdListinoBase
				_IdRisorsa = int.IdRisorsa
				_PathFile = int.PathFile
				_QtaOrdine = int.QtaOrdine
				_StampareReminder = int.StampareReminder
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an AzioneSottoscorta on DB.
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
		if _PathFile.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_azionisottoscorta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IAzioneSottoscorta

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdRegola() as integer
	Property Azione() as integer
	Property IdDestMessaggio() as integer
	Property IdListinoBase() as integer
	Property IdRisorsa() as integer
	Property PathFile() as string
	Property QtaOrdine() as integer
	Property StampareReminder() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class AzioneSottoscorta
		Public Shared ReadOnly Property IdRegola As New LUNA.LunaFieldName("IdRegola")
		Public Shared ReadOnly Property Azione As New LUNA.LunaFieldName("Azione")
		Public Shared ReadOnly Property IdDestMessaggio As New LUNA.LunaFieldName("IdDestMessaggio")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdRisorsa As New LUNA.LunaFieldName("IdRisorsa")
		Public Shared ReadOnly Property PathFile As New LUNA.LunaFieldName("PathFile")
		Public Shared ReadOnly Property QtaOrdine As New LUNA.LunaFieldName("QtaOrdine")
		Public Shared ReadOnly Property StampareReminder As New LUNA.LunaFieldName("StampareReminder")
	End Class

End Class