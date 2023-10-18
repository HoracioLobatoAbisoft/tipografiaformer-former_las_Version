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
'''DAO Class for table T_validatorerrorlevel
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ValidatorErrorLevel
	Inherits LUNA.LunaBaseClassEntity
	Implements _IValidatorErrorLevel
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IValidatorErrorLevel.FillFromDataRecord
		IdVELevel = myRecord("IdVELevel")
		IdPreventivazione = myRecord("IdPreventivazione")
		ValidatorErrorCode = myRecord("ValidatorErrorCode")
		ValidatorErrorLevel = myRecord("ValidatorErrorLevel")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ValidatorErrorLevel)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ValidatorErrorLevelDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ValidatorErrorLevel))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdVELevel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPreventivazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ValidatorErrorCode As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ValidatorErrorLevel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdVELevel = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPreventivazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ValidatorErrorCode = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ValidatorErrorLevel = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdVELevel as integer  = 0 
	Public Overridable Property IdVELevel() as integer  Implements _IValidatorErrorLevel.IdVELevel
		Get
			Return _IdVELevel
		End Get
		Set (byval value as integer)
			If _IdVELevel <> value Then
				IsChanged = True
				WhatIsChanged.IdVELevel = True
				_IdVELevel = value
			End If
		End Set
	End property 

	Protected _IdPreventivazione as integer  = 0 
	Public Overridable Property IdPreventivazione() as integer  Implements _IValidatorErrorLevel.IdPreventivazione
		Get
			Return _IdPreventivazione
		End Get
		Set (byval value as integer)
			If _IdPreventivazione <> value Then
				IsChanged = True
				WhatIsChanged.IdPreventivazione = True
				_IdPreventivazione = value
			End If
		End Set
	End property 

	Protected _ValidatorErrorCode as integer  = 0 
	Public Overridable Property ValidatorErrorCode() as integer  Implements _IValidatorErrorLevel.ValidatorErrorCode
		Get
			Return _ValidatorErrorCode
		End Get
		Set (byval value as integer)
			If _ValidatorErrorCode <> value Then
				IsChanged = True
				WhatIsChanged.ValidatorErrorCode = True
				_ValidatorErrorCode = value
			End If
		End Set
	End property 

	Protected _ValidatorErrorLevel as integer  = 0 
	Public Overridable Property ValidatorErrorLevel() as integer  Implements _IValidatorErrorLevel.ValidatorErrorLevel
		Get
			Return _ValidatorErrorLevel
		End Get
		Set (byval value as integer)
			If _ValidatorErrorLevel <> value Then
				IsChanged = True
				WhatIsChanged.ValidatorErrorLevel = True
				_ValidatorErrorLevel = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ValidatorErrorLevel from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ValidatorErrorLevel = Manager.Read(Id)
				_IdVELevel = int.IdVELevel
				_IdPreventivazione = int.IdPreventivazione
				_ValidatorErrorCode = int.ValidatorErrorCode
				_ValidatorErrorLevel = int.ValidatorErrorLevel
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ValidatorErrorLevel on DB.
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
'''Interface for table T_validatorerrorlevel
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IValidatorErrorLevel

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdVELevel() as integer
	Property IdPreventivazione() as integer
	Property ValidatorErrorCode() as integer
	Property ValidatorErrorLevel() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ValidatorErrorLevel
		Public Shared ReadOnly Property IdVELevel As New LUNA.LunaFieldName("IdVELevel")
		Public Shared ReadOnly Property IdPreventivazione As New LUNA.LunaFieldName("IdPreventivazione")
		Public Shared ReadOnly Property ValidatorErrorCode As New LUNA.LunaFieldName("ValidatorErrorCode")
		Public Shared ReadOnly Property ValidatorErrorLevel As New LUNA.LunaFieldName("ValidatorErrorLevel")
	End Class

End Class