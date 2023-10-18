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
'''DAO Class for table T_logmw
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _LogMarketing
	Inherits LUNA.LunaBaseClassEntity
	Implements _ILogMarketing
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ILogMarketing.FillFromDataRecord
		IdLogMw = myRecord("IdLogMw")
		if not myRecord("DataIns") is DBNull.Value then DataIns = myRecord("DataIns")
		if not myRecord("DataSent") is DBNull.Value then DataSent = myRecord("DataSent")
		if not myRecord("IdEmail") is DBNull.Value then IdEmail = myRecord("IdEmail")
		if not myRecord("IdFm") is DBNull.Value then IdFm = myRecord("IdFm")
		if not myRecord("IdRubG") is DBNull.Value then IdRubG = myRecord("IdRubG")
		if not myRecord("IdTemplateMarketing") is DBNull.Value then IdTemplateMarketing = myRecord("IdTemplateMarketing")
		if not myRecord("NTent") is DBNull.Value then NTent = myRecord("NTent")
		if not myRecord("Stato") is DBNull.Value then Stato = myRecord("Stato")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of LogMarketing)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(LogMarketingDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of LogMarketing))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLogMw As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataSent As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdEmail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFm As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRubG As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTemplateMarketing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NTent As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLogMw = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataSent = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdEmail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFm = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRubG = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTemplateMarketing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NTent = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLogMw as integer  = 0 
	Public Overridable Property IdLogMw() as integer  Implements _ILogMarketing.IdLogMw
		Get
			Return _IdLogMw
		End Get
		Set (byval value as integer)
			If _IdLogMw <> value Then
				IsChanged = True
				WhatIsChanged.IdLogMw = True
				_IdLogMw = value
			End If
		End Set
	End property 

	Protected _DataIns as DateTime  = Nothing 
	Public Overridable Property DataIns() as DateTime  Implements _ILogMarketing.DataIns
		Get
			Return _DataIns
		End Get
		Set (byval value as DateTime)
			If _DataIns <> value Then
				IsChanged = True
				WhatIsChanged.DataIns = True
				_DataIns = value
			End If
		End Set
	End property 

	Protected _DataSent as DateTime  = Nothing 
	Public Overridable Property DataSent() as DateTime  Implements _ILogMarketing.DataSent
		Get
			Return _DataSent
		End Get
		Set (byval value as DateTime)
			If _DataSent <> value Then
				IsChanged = True
				WhatIsChanged.DataSent = True
				_DataSent = value
			End If
		End Set
	End property 

	Protected _IdEmail as integer  = 0 
	Public Overridable Property IdEmail() as integer  Implements _ILogMarketing.IdEmail
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

	Protected _IdFm as integer  = 0 
	Public Overridable Property IdFm() as integer  Implements _ILogMarketing.IdFm
		Get
			Return _IdFm
		End Get
		Set (byval value as integer)
			If _IdFm <> value Then
				IsChanged = True
				WhatIsChanged.IdFm = True
				_IdFm = value
			End If
		End Set
	End property 

	Protected _IdRubG as integer  = 0 
	Public Overridable Property IdRubG() as integer  Implements _ILogMarketing.IdRubG
		Get
			Return _IdRubG
		End Get
		Set (byval value as integer)
			If _IdRubG <> value Then
				IsChanged = True
				WhatIsChanged.IdRubG = True
				_IdRubG = value
			End If
		End Set
	End property 

	Protected _IdTemplateMarketing as integer  = 0 
	Public Overridable Property IdTemplateMarketing() as integer  Implements _ILogMarketing.IdTemplateMarketing
		Get
			Return _IdTemplateMarketing
		End Get
		Set (byval value as integer)
			If _IdTemplateMarketing <> value Then
				IsChanged = True
				WhatIsChanged.IdTemplateMarketing = True
				_IdTemplateMarketing = value
			End If
		End Set
	End property 

	Protected _NTent as integer  = 0 
	Public Overridable Property NTent() as integer  Implements _ILogMarketing.NTent
		Get
			Return _NTent
		End Get
		Set (byval value as integer)
			If _NTent <> value Then
				IsChanged = True
				WhatIsChanged.NTent = True
				_NTent = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _ILogMarketing.Stato
		Get
			Return _Stato
		End Get
		Set (byval value as integer)
			If _Stato <> value Then
				IsChanged = True
				WhatIsChanged.Stato = True
				_Stato = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an LogMarketing from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As LogMarketing = Manager.Read(Id)
				_IdLogMw = int.IdLogMw
				_DataIns = int.DataIns
				_DataSent = int.DataSent
				_IdEmail = int.IdEmail
				_IdFm = int.IdFm
				_IdRubG = int.IdRubG
				_IdTemplateMarketing = int.IdTemplateMarketing
				_NTent = int.NTent
				_Stato = int.Stato
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an LogMarketing on DB.
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
'''Interface for table T_logmw
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ILogMarketing

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLogMw() as integer
	Property DataIns() as DateTime
	Property DataSent() as DateTime
	Property IdEmail() as integer
	Property IdFm() as integer
	Property IdRubG() as integer
	Property IdTemplateMarketing() as integer
	Property NTent() as integer
	Property Stato() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class LogMarketing
		Public Shared ReadOnly Property IdLogMw As New LUNA.LunaFieldName("IdLogMw")
		Public Shared ReadOnly Property DataIns As New LUNA.LunaFieldName("DataIns")
		Public Shared ReadOnly Property DataSent As New LUNA.LunaFieldName("DataSent")
		Public Shared ReadOnly Property IdEmail As New LUNA.LunaFieldName("IdEmail")
		Public Shared ReadOnly Property IdFm As New LUNA.LunaFieldName("IdFm")
		Public Shared ReadOnly Property IdRubG As New LUNA.LunaFieldName("IdRubG")
		Public Shared ReadOnly Property IdTemplateMarketing As New LUNA.LunaFieldName("IdTemplateMarketing")
		Public Shared ReadOnly Property NTent As New LUNA.LunaFieldName("NTent")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
	End Class

End Class