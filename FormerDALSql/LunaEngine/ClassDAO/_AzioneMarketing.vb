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
'''DAO Class for table T_markaz
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _AzioneMarketing
	Inherits LUNA.LunaBaseClassEntity
	Implements _IAzioneMarketing
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IAzioneMarketing.FillFromDataRecord
		IdMarkAz = myRecord("IdMarkAz")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("IdMarketing") is DBNull.Value then IdMarketing = myRecord("IdMarketing")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("Quando") is DBNull.Value then Quando = myRecord("Quando")
		if not myRecord("TipoAzione") is DBNull.Value then TipoAzione = myRecord("TipoAzione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of AzioneMarketing)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(AzioniMarketingDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of AzioneMarketing))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdMarkAz As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMarketing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoAzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdMarkAz = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMarketing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoAzione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdMarkAz as integer  = 0 
	Public Overridable Property IdMarkAz() as integer  Implements _IAzioneMarketing.IdMarkAz
		Get
			Return _IdMarkAz
		End Get
		Set (byval value as integer)
			If _IdMarkAz <> value Then
				IsChanged = True
				WhatIsChanged.IdMarkAz = True
				_IdMarkAz = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _IAzioneMarketing.Annotazioni
		Get
			Return _Annotazioni
		End Get
		Set (byval value as string)
			If _Annotazioni <> value Then
				IsChanged = True
				WhatIsChanged.Annotazioni = True
				_Annotazioni = value
			End If
		End Set
	End property 

	Protected _IdMarketing as integer  = 0 
	Public Overridable Property IdMarketing() as integer  Implements _IAzioneMarketing.IdMarketing
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

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IAzioneMarketing.IdRub
		Get
			Return _IdRub
		End Get
		Set (byval value as integer)
			If _IdRub <> value Then
				IsChanged = True
				WhatIsChanged.IdRub = True
				_IdRub = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IAzioneMarketing.Quando
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

	Protected _TipoAzione as integer  = 0 
	Public Overridable Property TipoAzione() as integer  Implements _IAzioneMarketing.TipoAzione
		Get
			Return _TipoAzione
		End Get
		Set (byval value as integer)
			If _TipoAzione <> value Then
				IsChanged = True
				WhatIsChanged.TipoAzione = True
				_TipoAzione = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an AzioneMarketing from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As AzioneMarketing = Manager.Read(Id)
				_IdMarkAz = int.IdMarkAz
				_Annotazioni = int.Annotazioni
				_IdMarketing = int.IdMarketing
				_IdRub = int.IdRub
				_Quando = int.Quando
				_TipoAzione = int.TipoAzione
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an AzioneMarketing on DB.
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
		if _Annotazioni.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_markaz
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IAzioneMarketing

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdMarkAz() as integer
	Property Annotazioni() as string
	Property IdMarketing() as integer
	Property IdRub() as integer
	Property Quando() as DateTime
	Property TipoAzione() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class AzioneMarketing
		Public Shared ReadOnly Property IdMarkAz As New LUNA.LunaFieldName("IdMarkAz")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property IdMarketing As New LUNA.LunaFieldName("IdMarketing")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
		Public Shared ReadOnly Property TipoAzione As New LUNA.LunaFieldName("TipoAzione")
	End Class

End Class