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
'''DAO Class for table NewsletterRequest
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Newsletter
	Inherits LUNA.LunaBaseClassEntity
	Implements _INewsletter
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _INewsletter.FillFromDataRecord
		IdNewsletter = myRecord("IdNewsletter")
		Email = myRecord("Email")
		if not myRecord("Ip") is DBNull.Value then Ip = myRecord("Ip")
		if not myRecord("Lavorato") is DBNull.Value then Lavorato = myRecord("Lavorato")
		if not myRecord("Quando") is DBNull.Value then Quando = myRecord("Quando")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Newsletter)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(NewsletterDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Newsletter))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdNewsletter As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Email As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ip As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Lavorato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdNewsletter = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Email = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ip = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Lavorato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdNewsletter as integer  = 0 
	Public Overridable Property IdNewsletter() as integer  Implements _INewsletter.IdNewsletter
		Get
			Return _IdNewsletter
		End Get
		Set (byval value as integer)
			If _IdNewsletter <> value Then
				IsChanged = True
				WhatIsChanged.IdNewsletter = True
				_IdNewsletter = value
			End If
		End Set
	End property 

	Protected _Email as string  = "" 
	Public Overridable Property Email() as string  Implements _INewsletter.Email
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
	Public Overridable Property Ip() as string  Implements _INewsletter.Ip
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
	Public Overridable Property Lavorato() as integer  Implements _INewsletter.Lavorato
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
	Public Overridable Property Quando() as DateTime  Implements _INewsletter.Quando
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
	'''This method read an Newsletter from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Newsletter = Manager.Read(Id)
				_IdNewsletter = int.IdNewsletter
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
	'''This method save an Newsletter on DB.
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
		if _Email.Length > 100 then Ris = False
		if _Ip.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table NewsletterRequest
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _INewsletter

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdNewsletter() as integer
	Property Email() as string
	Property Ip() as string
	Property Lavorato() as integer
	Property Quando() as DateTime

#End Region

End Interface

Partial Public Class LFM

	Public Class Newsletter
		Public Shared ReadOnly Property IdNewsletter As New LUNA.LunaFieldName("IdNewsletter")
		Public Shared ReadOnly Property Email As New LUNA.LunaFieldName("Email")
		Public Shared ReadOnly Property Ip As New LUNA.LunaFieldName("Ip")
		Public Shared ReadOnly Property Lavorato As New LUNA.LunaFieldName("Lavorato")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
	End Class

End Class