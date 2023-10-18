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
'''DAO Class for table Tr_lavprev
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _LavorazSuPreventivazW
	Inherits LUNA.LunaBaseClassEntity
	Implements _ILavorazSuPreventivazW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ILavorazSuPreventivazW.FillFromDataRecord
		IdLavPrev = myRecord("IdLavPrev")
		if not myRecord("IdLavoro") is DBNull.Value then IdLavoro = myRecord("IdLavoro")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		if not myRecord("Opzione") is DBNull.Value then Opzione = myRecord("Opzione")
		if not myRecord("Ordine") is DBNull.Value then Ordine = myRecord("Ordine")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of LavorazSuPreventivazW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(LavorazSuPreventivazWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of LavorazSuPreventivazW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLavPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdLavoro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Opzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLavPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdLavoro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Opzione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ordine = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLavPrev as integer  = 0 
	Public Overridable Property IdLavPrev() as integer  Implements _ILavorazSuPreventivazW.IdLavPrev
		Get
			Return _IdLavPrev
		End Get
		Set (byval value as integer)
			If _IdLavPrev <> value Then
				IsChanged = True
				WhatIsChanged.IdLavPrev = True
				_IdLavPrev = value
			End If
		End Set
	End property 

	Protected _IdLavoro as integer  = 0 
	Public Overridable Property IdLavoro() as integer  Implements _ILavorazSuPreventivazW.IdLavoro
		Get
			Return _IdLavoro
		End Get
		Set (byval value as integer)
			If _IdLavoro <> value Then
				IsChanged = True
				WhatIsChanged.IdLavoro = True
				_IdLavoro = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _ILavorazSuPreventivazW.IdListinoBase
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

	Protected _Opzione as integer  = 0 
	Public Overridable Property Opzione() as integer  Implements _ILavorazSuPreventivazW.Opzione
		Get
			Return _Opzione
		End Get
		Set (byval value as integer)
			If _Opzione <> value Then
				IsChanged = True
				WhatIsChanged.Opzione = True
				_Opzione = value
			End If
		End Set
	End property 

	Protected _Ordine as integer  = 0 
	Public Overridable Property Ordine() as integer  Implements _ILavorazSuPreventivazW.Ordine
		Get
			Return _Ordine
		End Get
		Set (byval value as integer)
			If _Ordine <> value Then
				IsChanged = True
				WhatIsChanged.Ordine = True
				_Ordine = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an LavorazSuPreventivazW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As LavorazSuPreventivazW = Manager.Read(Id)
				_IdLavPrev = int.IdLavPrev
				_IdLavoro = int.IdLavoro
				_IdListinoBase = int.IdListinoBase
				_Opzione = int.Opzione
				_Ordine = int.Ordine
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an LavorazSuPreventivazW on DB.
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

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Tr_lavprev
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ILavorazSuPreventivazW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLavPrev() as integer
	Property IdLavoro() as integer
	Property IdListinoBase() as integer
	Property Opzione() as integer
	Property Ordine() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class LavorazSuPreventivazW
		Public Shared ReadOnly Property IdLavPrev As New LUNA.LunaFieldName("IdLavPrev")
		Public Shared ReadOnly Property IdLavoro As New LUNA.LunaFieldName("IdLavoro")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property Opzione As New LUNA.LunaFieldName("Opzione")
		Public Shared ReadOnly Property Ordine As New LUNA.LunaFieldName("Ordine")
	End Class

End Class