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
'''DAO Class for table T_login
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Login
	Inherits LUNA.LunaBaseClassEntity
	Implements _ILogin
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ILogin.FillFromDataRecord
		IdLogin = myRecord("IdLogin")
		IdUt = myRecord("IdUt")
		Postazione = myRecord("Postazione")
		Quando = myRecord("Quando")
		Versione = myRecord("Versione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Login)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(LoginDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Login))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLogin As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Postazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Versione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLogin = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Postazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Versione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLogin as integer  = 0 
	Public Overridable Property IdLogin() as integer  Implements _ILogin.IdLogin
		Get
			Return _IdLogin
		End Get
		Set (byval value as integer)
			If _IdLogin <> value Then
				IsChanged = True
				WhatIsChanged.IdLogin = True
				_IdLogin = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _ILogin.IdUt
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
	Public Overridable Property Postazione() as string  Implements _ILogin.Postazione
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
	Public Overridable Property Quando() as DateTime  Implements _ILogin.Quando
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

	Protected _Versione as string  = "" 
	Public Overridable Property Versione() as string  Implements _ILogin.Versione
		Get
			Return _Versione
		End Get
		Set (byval value as string)
			If _Versione <> value Then
				IsChanged = True
				WhatIsChanged.Versione = True
				_Versione = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Login from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Login = Manager.Read(Id)
				_IdLogin = int.IdLogin
				_IdUt = int.IdUt
				_Postazione = int.Postazione
				_Quando = int.Quando
				_Versione = int.Versione
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Login on DB.
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
  
		if _Versione.Length = 0 then Ris = False
		if _Versione.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_login
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ILogin

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLogin() as integer
	Property IdUt() as integer
	Property Postazione() as string
	Property Quando() as DateTime
	Property Versione() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Login
		Public Shared ReadOnly Property IdLogin As New LUNA.LunaFieldName("IdLogin")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property Postazione As New LUNA.LunaFieldName("Postazione")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
		Public Shared ReadOnly Property Versione As New LUNA.LunaFieldName("Versione")
	End Class

End Class