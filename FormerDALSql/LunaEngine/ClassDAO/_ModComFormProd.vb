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
'''DAO Class for table Tr_modcomformp
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ModComFormProd
	Inherits LUNA.LunaBaseClassEntity
	Implements _IModComFormProd
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IModComFormProd.FillFromDataRecord
		IdModComFormP = myRecord("IdModComFormP")
		if not myRecord("IdFormProd") is DBNull.Value then IdFormProd = myRecord("IdFormProd")
		if not myRecord("IdModCom") is DBNull.Value then IdModCom = myRecord("IdModCom")
		if not myRecord("Orientamento") is DBNull.Value then Orientamento = myRecord("Orientamento")
		if not myRecord("RangeMax") is DBNull.Value then RangeMax = myRecord("RangeMax")
		if not myRecord("RangeMin") is DBNull.Value then RangeMin = myRecord("RangeMin")
		if not myRecord("Spazi") is DBNull.Value then Spazi = myRecord("Spazi")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ModComFormProd)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ModComFormProdDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ModComFormProd))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdModComFormP As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdModCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Orientamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RangeMax As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RangeMin As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Spazi As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdModComFormP = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdModCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Orientamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RangeMax = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RangeMin = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Spazi = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdModComFormP as integer  = 0 
	Public Overridable Property IdModComFormP() as integer  Implements _IModComFormProd.IdModComFormP
		Get
			Return _IdModComFormP
		End Get
		Set (byval value as integer)
			If _IdModComFormP <> value Then
				IsChanged = True
				WhatIsChanged.IdModComFormP = True
				_IdModComFormP = value
			End If
		End Set
	End property 

	Protected _IdFormProd as integer  = 0 
	Public Overridable Property IdFormProd() as integer  Implements _IModComFormProd.IdFormProd
		Get
			Return _IdFormProd
		End Get
		Set (byval value as integer)
			If _IdFormProd <> value Then
				IsChanged = True
				WhatIsChanged.IdFormProd = True
				_IdFormProd = value
			End If
		End Set
	End property 

	Protected _IdModCom as integer  = 0 
	Public Overridable Property IdModCom() as integer  Implements _IModComFormProd.IdModCom
		Get
			Return _IdModCom
		End Get
		Set (byval value as integer)
			If _IdModCom <> value Then
				IsChanged = True
				WhatIsChanged.IdModCom = True
				_IdModCom = value
			End If
		End Set
	End property 

	Protected _Orientamento as integer  = 0 
	Public Overridable Property Orientamento() as integer  Implements _IModComFormProd.Orientamento
		Get
			Return _Orientamento
		End Get
		Set (byval value as integer)
			If _Orientamento <> value Then
				IsChanged = True
				WhatIsChanged.Orientamento = True
				_Orientamento = value
			End If
		End Set
	End property 

	Protected _RangeMax as integer  = 0 
	Public Overridable Property RangeMax() as integer  Implements _IModComFormProd.RangeMax
		Get
			Return _RangeMax
		End Get
		Set (byval value as integer)
			If _RangeMax <> value Then
				IsChanged = True
				WhatIsChanged.RangeMax = True
				_RangeMax = value
			End If
		End Set
	End property 

	Protected _RangeMin as integer  = 0 
	Public Overridable Property RangeMin() as integer  Implements _IModComFormProd.RangeMin
		Get
			Return _RangeMin
		End Get
		Set (byval value as integer)
			If _RangeMin <> value Then
				IsChanged = True
				WhatIsChanged.RangeMin = True
				_RangeMin = value
			End If
		End Set
	End property 

	Protected _Spazi as integer  = 0 
	Public Overridable Property Spazi() as integer  Implements _IModComFormProd.Spazi
		Get
			Return _Spazi
		End Get
		Set (byval value as integer)
			If _Spazi <> value Then
				IsChanged = True
				WhatIsChanged.Spazi = True
				_Spazi = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ModComFormProd from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ModComFormProd = Manager.Read(Id)
				_IdModComFormP = int.IdModComFormP
				_IdFormProd = int.IdFormProd
				_IdModCom = int.IdModCom
				_Orientamento = int.Orientamento
				_RangeMax = int.RangeMax
				_RangeMin = int.RangeMin
				_Spazi = int.Spazi
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ModComFormProd on DB.
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
'''Interface for table Tr_modcomformp
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IModComFormProd

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdModComFormP() as integer
	Property IdFormProd() as integer
	Property IdModCom() as integer
	Property Orientamento() as integer
	Property RangeMax() as integer
	Property RangeMin() as integer
	Property Spazi() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ModComFormProd
		Public Shared ReadOnly Property IdModComFormP As New LUNA.LunaFieldName("IdModComFormP")
		Public Shared ReadOnly Property IdFormProd As New LUNA.LunaFieldName("IdFormProd")
		Public Shared ReadOnly Property IdModCom As New LUNA.LunaFieldName("IdModCom")
		Public Shared ReadOnly Property Orientamento As New LUNA.LunaFieldName("Orientamento")
		Public Shared ReadOnly Property RangeMax As New LUNA.LunaFieldName("RangeMax")
		Public Shared ReadOnly Property RangeMin As New LUNA.LunaFieldName("RangeMin")
		Public Shared ReadOnly Property Spazi As New LUNA.LunaFieldName("Spazi")
	End Class

End Class