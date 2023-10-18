#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.2.1 
'Author: Diego Lunadei
'Date: 09/02/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_email
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Email
	Inherits LUNA.LunaBaseClassEntity
	Implements _IEmail
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IEmail.FillFromDataRecord
		IdEmail = myRecord("IdEmail")
		if not myRecord("DaInviare") is DBNull.Value then DaInviare = myRecord("DaInviare")
		if not myRecord("IdMarketing") is DBNull.Value then IdMarketing = myRecord("IdMarketing")
		if not myRecord("IdRubDest") is DBNull.Value then IdRubDest = myRecord("IdRubDest")
		if not myRecord("IdRubMarketing") is DBNull.Value then IdRubMarketing = myRecord("IdRubMarketing")
		if not myRecord("Livello") is DBNull.Value then Livello = myRecord("Livello")
		if not myRecord("Quando") is DBNull.Value then Quando = myRecord("Quando")
		if not myRecord("Testo") is DBNull.Value then Testo = myRecord("Testo")
		if not myRecord("Titolo") is DBNull.Value then Titolo = myRecord("Titolo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Email)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(EmailDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Email))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdEmail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DaInviare As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMarketing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRubDest As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRubMarketing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Livello As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Testo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Titolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdEmail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DaInviare = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMarketing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRubDest = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRubMarketing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Livello = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Testo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Titolo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdEmail as integer  = 0 
	Public Overridable Property IdEmail() as integer  Implements _IEmail.IdEmail
		Get
			Return _IdEmail
		End Get
		Set (byval value as integer)
			If _IdEmail <> value Then
				IsChanged = True
				WhatIsChanged.IdEmail = True
				_IdEmail = value
			End If
		End Set
	End property 

	Protected _DaInviare as integer  = 0 
	Public Overridable Property DaInviare() as integer  Implements _IEmail.DaInviare
		Get
			Return _DaInviare
		End Get
		Set (byval value as integer)
			If _DaInviare <> value Then
				IsChanged = True
				WhatIsChanged.DaInviare = True
				_DaInviare = value
			End If
		End Set
	End property 

	Protected _IdMarketing as integer  = 0 
	Public Overridable Property IdMarketing() as integer  Implements _IEmail.IdMarketing
		Get
			Return _IdMarketing
		End Get
		Set (byval value as integer)
			If _IdMarketing <> value Then
				IsChanged = True
				WhatIsChanged.IdMarketing = True
				_IdMarketing = value
			End If
		End Set
	End property 

	Protected _IdRubDest as integer  = 0 
	Public Overridable Property IdRubDest() as integer  Implements _IEmail.IdRubDest
		Get
			Return _IdRubDest
		End Get
		Set (byval value as integer)
			If _IdRubDest <> value Then
				IsChanged = True
				WhatIsChanged.IdRubDest = True
				_IdRubDest = value
			End If
		End Set
	End property 

	Protected _IdRubMarketing as integer  = 0 
	Public Overridable Property IdRubMarketing() as integer  Implements _IEmail.IdRubMarketing
		Get
			Return _IdRubMarketing
		End Get
		Set (byval value as integer)
			If _IdRubMarketing <> value Then
				IsChanged = True
				WhatIsChanged.IdRubMarketing = True
				_IdRubMarketing = value
			End If
		End Set
	End property 

	Protected _Livello as integer  = 0 
	Public Overridable Property Livello() as integer  Implements _IEmail.Livello
		Get
			Return _Livello
		End Get
		Set (byval value as integer)
			If _Livello <> value Then
				IsChanged = True
				WhatIsChanged.Livello = True
				_Livello = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IEmail.Quando
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

	Protected _Testo as string  = "" 
	Public Overridable Property Testo() as string  Implements _IEmail.Testo
		Get
			Return _Testo
		End Get
		Set (byval value as string)
			If _Testo <> value Then
				IsChanged = True
				WhatIsChanged.Testo = True
				_Testo = value
			End If
		End Set
	End property 

	Protected _Titolo as string  = "" 
	Public Overridable Property Titolo() as string  Implements _IEmail.Titolo
		Get
			Return _Titolo
		End Get
		Set (byval value as string)
			If _Titolo <> value Then
				IsChanged = True
				WhatIsChanged.Titolo = True
				_Titolo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Email from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Email = Manager.Read(Id)
				_IdEmail = int.IdEmail
				_DaInviare = int.DaInviare
				_IdMarketing = int.IdMarketing
				_IdRubDest = int.IdRubDest
				_IdRubMarketing = int.IdRubMarketing
				_Livello = int.Livello
				_Quando = int.Quando
				_Testo = int.Testo
				_Titolo = int.Titolo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Email on DB.
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
		if _Testo.Length > 1073741823 then Ris = False
		if _Titolo.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_email
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IEmail

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdEmail() as integer
	Property DaInviare() as integer
	Property IdMarketing() as integer
	Property IdRubDest() as integer
	Property IdRubMarketing() as integer
	Property Livello() as integer
	Property Quando() as DateTime
	Property Testo() as string
	Property Titolo() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Email
		Public Shared ReadOnly Property IdEmail As New LUNA.LunaFieldName("IdEmail")
		Public Shared ReadOnly Property DaInviare As New LUNA.LunaFieldName("DaInviare")
		Public Shared ReadOnly Property IdMarketing As New LUNA.LunaFieldName("IdMarketing")
		Public Shared ReadOnly Property IdRubDest As New LUNA.LunaFieldName("IdRubDest")
		Public Shared ReadOnly Property IdRubMarketing As New LUNA.LunaFieldName("IdRubMarketing")
		Public Shared ReadOnly Property Livello As New LUNA.LunaFieldName("Livello")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
		Public Shared ReadOnly Property Testo As New LUNA.LunaFieldName("Testo")
		Public Shared ReadOnly Property Titolo As New LUNA.LunaFieldName("Titolo")
	End Class

End Class