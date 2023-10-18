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
'''DAO Class for table T_tmlb
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ListinoBaseSuTemplate
	Inherits LUNA.LunaBaseClassEntity
	Implements _IListinoBaseSuTemplate
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IListinoBaseSuTemplate.FillFromDataRecord
		IdTMLB = myRecord("IdTMLB")
		if not myRecord("Fogli") is DBNull.Value then Fogli = myRecord("Fogli")
		IdListinoBase = myRecord("IdListinoBase")
		IdTmOff = myRecord("IdTmOff")
		Qta = myRecord("Qta")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ListinoBaseSuTemplate)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ListinoBaseSuTemplateDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ListinoBaseSuTemplate))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdTMLB As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Fogli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTmOff As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdTMLB = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Fogli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTmOff = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdTMLB as integer  = 0 
	Public Overridable Property IdTMLB() as integer  Implements _IListinoBaseSuTemplate.IdTMLB
		Get
			Return _IdTMLB
		End Get
		Set (byval value as integer)
			If _IdTMLB <> value Then
				IsChanged = True
				WhatIsChanged.IdTMLB = True
				_IdTMLB = value
			End If
		End Set
	End property 

	Protected _Fogli as integer  = 0 
	Public Overridable Property Fogli() as integer  Implements _IListinoBaseSuTemplate.Fogli
		Get
			Return _Fogli
		End Get
		Set (byval value as integer)
			If _Fogli <> value Then
				IsChanged = True
				WhatIsChanged.Fogli = True
				_Fogli = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IListinoBaseSuTemplate.IdListinoBase
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

	Protected _IdTmOff as integer  = 0 
	Public Overridable Property IdTmOff() as integer  Implements _IListinoBaseSuTemplate.IdTmOff
		Get
			Return _IdTmOff
		End Get
		Set (byval value as integer)
			If _IdTmOff <> value Then
				IsChanged = True
				WhatIsChanged.IdTmOff = True
				_IdTmOff = value
			End If
		End Set
	End property 

	Protected _Qta as integer  = 0 
	Public Overridable Property Qta() as integer  Implements _IListinoBaseSuTemplate.Qta
		Get
			Return _Qta
		End Get
		Set (byval value as integer)
			If _Qta <> value Then
				IsChanged = True
				WhatIsChanged.Qta = True
				_Qta = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ListinoBaseSuTemplate from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ListinoBaseSuTemplate = Manager.Read(Id)
				_IdTMLB = int.IdTMLB
				_Fogli = int.Fogli
				_IdListinoBase = int.IdListinoBase
				_IdTmOff = int.IdTmOff
				_Qta = int.Qta
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ListinoBaseSuTemplate on DB.
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
'''Interface for table T_tmlb
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IListinoBaseSuTemplate

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdTMLB() as integer
	Property Fogli() as integer
	Property IdListinoBase() as integer
	Property IdTmOff() as integer
	Property Qta() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ListinoBaseSuTemplate
		Public Shared ReadOnly Property IdTMLB As New LUNA.LunaFieldName("IdTMLB")
		Public Shared ReadOnly Property Fogli As New LUNA.LunaFieldName("Fogli")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdTmOff As New LUNA.LunaFieldName("IdTmOff")
		Public Shared ReadOnly Property Qta As New LUNA.LunaFieldName("Qta")
	End Class

End Class