#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 07/10/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_functionlock
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FunctionLock
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFunctionLock
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFunctionLock.FillFromDataRecord
		IdFunctionLock = myRecord("IdFunctionLock")
		if not myRecord("idcom") is DBNull.Value then idcom = myRecord("idcom")
		IdFunction = myRecord("IdFunction")
		if not myRecord("IdOrd") is DBNull.Value then IdOrd = myRecord("IdOrd")
		IdUt = myRecord("IdUt")
		Postazione = myRecord("Postazione")
		Quando = myRecord("Quando")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FunctionLock)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FunctionLockDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FunctionLock))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdFunctionLock As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property idcom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFunction As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Postazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdFunctionLock = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.idcom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFunction = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Postazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdFunctionLock as integer  = 0 
	Public Overridable Property IdFunctionLock() as integer  Implements _IFunctionLock.IdFunctionLock
		Get
			Return _IdFunctionLock
		End Get
		Set (byval value as integer)
			If _IdFunctionLock <> value Then
				IsChanged = True
				WhatIsChanged.IdFunctionLock = True
				_IdFunctionLock = value
			End If
		End Set
	End property 

	Protected _idcom as integer  = 0 
	Public Overridable Property idcom() as integer  Implements _IFunctionLock.idcom
		Get
			Return _idcom
		End Get
		Set (byval value as integer)
			If _idcom <> value Then
				IsChanged = True
				WhatIsChanged.idcom = True
				_idcom = value
			End If
		End Set
	End property 

	Protected _IdFunction as integer  = 0 
	Public Overridable Property IdFunction() as integer  Implements _IFunctionLock.IdFunction
		Get
			Return _IdFunction
		End Get
		Set (byval value as integer)
			If _IdFunction <> value Then
				IsChanged = True
				WhatIsChanged.IdFunction = True
				_IdFunction = value
			End If
		End Set
	End property 

	Protected _IdOrd as integer  = 0 
	Public Overridable Property IdOrd() as integer  Implements _IFunctionLock.IdOrd
		Get
			Return _IdOrd
		End Get
		Set (byval value as integer)
			If _IdOrd <> value Then
				IsChanged = True
				WhatIsChanged.IdOrd = True
				_IdOrd = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IFunctionLock.IdUt
		Get
			Return _IdUt
		End Get
		Set (byval value as integer)
			If _IdUt <> value Then
				IsChanged = True
				WhatIsChanged.IdUt = True
				_IdUt = value
			End If
		End Set
	End property 

	Protected _Postazione as string  = "" 
	Public Overridable Property Postazione() as string  Implements _IFunctionLock.Postazione
		Get
			Return _Postazione
		End Get
		Set (byval value as string)
			If _Postazione <> value Then
				IsChanged = True
				WhatIsChanged.Postazione = True
				_Postazione = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IFunctionLock.Quando
		Get
			Return _Quando
		End Get
		Set (byval value as DateTime)
			If _Quando <> value Then
				IsChanged = True
				WhatIsChanged.Quando = True
				_Quando = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FunctionLock from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FunctionLock = Manager.Read(Id)
				_IdFunctionLock = int.IdFunctionLock
				_idcom = int.idcom
				_IdFunction = int.IdFunction
				_IdOrd = int.IdOrd
				_IdUt = int.IdUt
				_Postazione = int.Postazione
				_Quando = int.Quando
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method Refresh all data in the entity from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
    Public Overridable Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdFunctionLock Then
            ris = Read(IdFunctionLock)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an FunctionLock on DB.
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
  
		if _Postazione.Length = 0 then Ris = False
		if _Postazione.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_functionlock
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFunctionLock

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdFunctionLock() as integer
	Property idcom() as integer
	Property IdFunction() as integer
	Property IdOrd() as integer
	Property IdUt() as integer
	Property Postazione() as string
	Property Quando() as DateTime

#End Region

End Interface

Partial Public Class LFM

	Public Class FunctionLock
		Public Shared ReadOnly Property IdFunctionLock As New LUNA.LunaFieldName("IdFunctionLock")
		Public Shared ReadOnly Property idcom As New LUNA.LunaFieldName("idcom")
		Public Shared ReadOnly Property IdFunction As New LUNA.LunaFieldName("IdFunction")
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property Postazione As New LUNA.LunaFieldName("Postazione")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
	End Class

End Class