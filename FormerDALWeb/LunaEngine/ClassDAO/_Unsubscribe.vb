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
'''DAO Class for table Unsubscribe
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Unsubscribe
	Inherits LUNA.LunaBaseClassEntity
	Implements _IUnsubscribe
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IUnsubscribe.FillFromDataRecord
		IdUnsubscribe = myRecord("IdUnsubscribe")
		Email = myRecord("Email")
		Ip = myRecord("Ip")
		if not myRecord("Lavorato") is DBNull.Value then Lavorato = myRecord("Lavorato")
		Quando = myRecord("Quando")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Unsubscribe)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(UnsubscribeDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Unsubscribe))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdUnsubscribe As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Email As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ip As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Lavorato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdUnsubscribe = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Email = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ip = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Lavorato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdUnsubscribe as integer  = 0 
	Public Overridable Property IdUnsubscribe() as integer  Implements _IUnsubscribe.IdUnsubscribe
		Get
			Return _IdUnsubscribe
		End Get
		Set (byval value as integer)
			If _IdUnsubscribe <> value Then
				IsChanged = True
				WhatIsChanged.IdUnsubscribe = True
				_IdUnsubscribe = value
			End If
		End Set
	End property 

	Protected _Email as string  = "" 
	Public Overridable Property Email() as string  Implements _IUnsubscribe.Email
		Get
			Return _Email
		End Get
		Set (byval value as string)
			If _Email <> value Then
				IsChanged = True
				WhatIsChanged.Email = True
				_Email = value
			End If
		End Set
	End property 

	Protected _Ip as string  = "" 
	Public Overridable Property Ip() as string  Implements _IUnsubscribe.Ip
		Get
			Return _Ip
		End Get
		Set (byval value as string)
			If _Ip <> value Then
				IsChanged = True
				WhatIsChanged.Ip = True
				_Ip = value
			End If
		End Set
	End property 

	Protected _Lavorato as integer  = 0 
	Public Overridable Property Lavorato() as integer  Implements _IUnsubscribe.Lavorato
		Get
			Return _Lavorato
		End Get
		Set (byval value as integer)
			If _Lavorato <> value Then
				IsChanged = True
				WhatIsChanged.Lavorato = True
				_Lavorato = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IUnsubscribe.Quando
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
	'''This method read an Unsubscribe from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Unsubscribe = Manager.Read(Id)
				_IdUnsubscribe = int.IdUnsubscribe
				_Email = int.Email
				_Ip = int.Ip
				_Lavorato = int.Lavorato
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
	'''This method save an Unsubscribe on DB.
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
  
		if _Email.Length = 0 then Ris = False
		if _Email.Length > 255 then Ris = False
  
		if _Ip.Length = 0 then Ris = False
		if _Ip.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Unsubscribe
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IUnsubscribe

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdUnsubscribe() as integer
	Property Email() as string
	Property Ip() as string
	Property Lavorato() as integer
	Property Quando() as DateTime

#End Region

End Interface

Partial Public Class LFM

	Public Class Unsubscribe
		Public Shared ReadOnly Property IdUnsubscribe As New LUNA.LunaFieldName("IdUnsubscribe")
		Public Shared ReadOnly Property Email As New LUNA.LunaFieldName("Email")
		Public Shared ReadOnly Property Ip As New LUNA.LunaFieldName("Ip")
		Public Shared ReadOnly Property Lavorato As New LUNA.LunaFieldName("Lavorato")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
	End Class

End Class