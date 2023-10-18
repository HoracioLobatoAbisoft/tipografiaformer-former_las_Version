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
'''DAO Class for table T_marketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CampagnaMarketing
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICampagnaMarketing
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICampagnaMarketing.FillFromDataRecord
		IDMark = myRecord("IDMark")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("Completata") is DBNull.Value then Completata = myRecord("Completata")
		if not myRecord("IdGruppo") is DBNull.Value then IdGruppo = myRecord("IdGruppo")
		if not myRecord("Quando") is DBNull.Value then Quando = myRecord("Quando")
		if not myRecord("Ripetizione") is DBNull.Value then Ripetizione = myRecord("Ripetizione")
		if not myRecord("TipoAzione") is DBNull.Value then TipoAzione = myRecord("TipoAzione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CampagnaMarketing)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(MarketingDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CampagnaMarketing))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDMark As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Completata As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdGruppo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ripetizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoAzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDMark = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Completata = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdGruppo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ripetizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoAzione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDMark as integer  = 0 
	Public Overridable Property IDMark() as integer  Implements _ICampagnaMarketing.IDMark
		Get
			Return _IDMark
		End Get
		Set (byval value as integer)
			If _IDMark <> value Then
				IsChanged = True
				WhatIsChanged.IDMark = True
				_IDMark = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _ICampagnaMarketing.Annotazioni
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

	Protected _Completata as Boolean  = False 
	Public Overridable Property Completata() as Boolean  Implements _ICampagnaMarketing.Completata
		Get
			Return _Completata
		End Get
		Set (byval value as Boolean)
			If _Completata <> value Then
				IsChanged = True
				WhatIsChanged.Completata = True
				_Completata = value
			End If
		End Set
	End property 

	Protected _IdGruppo as integer  = 0 
	Public Overridable Property IdGruppo() as integer  Implements _ICampagnaMarketing.IdGruppo
		Get
			Return _IdGruppo
		End Get
		Set (byval value as integer)
			If _IdGruppo <> value Then
				IsChanged = True
				WhatIsChanged.IdGruppo = True
				_IdGruppo = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _ICampagnaMarketing.Quando
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

	Protected _Ripetizione as integer  = 0 
	Public Overridable Property Ripetizione() as integer  Implements _ICampagnaMarketing.Ripetizione
		Get
			Return _Ripetizione
		End Get
		Set (byval value as integer)
			If _Ripetizione <> value Then
				IsChanged = True
				WhatIsChanged.Ripetizione = True
				_Ripetizione = value
			End If
		End Set
	End property 

	Protected _TipoAzione as integer  = 0 
	Public Overridable Property TipoAzione() as integer  Implements _ICampagnaMarketing.TipoAzione
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
	'''This method read an CampagnaMarketing from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CampagnaMarketing = Manager.Read(Id)
				_IDMark = int.IDMark
				_Annotazioni = int.Annotazioni
				_Completata = int.Completata
				_IdGruppo = int.IdGruppo
				_Quando = int.Quando
				_Ripetizione = int.Ripetizione
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
	'''This method save an CampagnaMarketing on DB.
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
'''Interface for table T_marketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICampagnaMarketing

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDMark() as integer
	Property Annotazioni() as string
	Property Completata() as Boolean
	Property IdGruppo() as integer
	Property Quando() as DateTime
	Property Ripetizione() as integer
	Property TipoAzione() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CampagnaMarketing
		Public Shared ReadOnly Property IDMark As New LUNA.LunaFieldName("IDMark")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property Completata As New LUNA.LunaFieldName("Completata")
		Public Shared ReadOnly Property IdGruppo As New LUNA.LunaFieldName("IdGruppo")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
		Public Shared ReadOnly Property Ripetizione As New LUNA.LunaFieldName("Ripetizione")
		Public Shared ReadOnly Property TipoAzione As New LUNA.LunaFieldName("TipoAzione")
	End Class

End Class