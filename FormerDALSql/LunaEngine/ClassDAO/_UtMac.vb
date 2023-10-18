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
'''DAO Class for table Tr_utmac
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _UtMac
	Inherits LUNA.LunaBaseClassEntity
	Implements _IUtMac
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IUtMac.FillFromDataRecord
		IdUtMac = myRecord("IdUtMac")
		if not myRecord("IdMac") is DBNull.Value then IdMac = myRecord("IdMac")
		if not myRecord("IdUt") is DBNull.Value then IdUt = myRecord("IdUt")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of UtMac)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(UtMacDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of UtMac))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdUtMac As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMac As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdUtMac = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMac = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdUtMac as integer  = 0 
	Public Overridable Property IdUtMac() as integer  Implements _IUtMac.IdUtMac
		Get
			Return _IdUtMac
		End Get
		Set (byval value as integer)
			If _IdUtMac <> value Then
				IsChanged = True
				WhatIsChanged.IdUtMac = True
				_IdUtMac = value
			End If
		End Set
	End property 

	Protected _IdMac as integer  = 0 
	Public Overridable Property IdMac() as integer  Implements _IUtMac.IdMac
		Get
			Return _IdMac
		End Get
		Set (byval value as integer)
			If _IdMac <> value Then
				IsChanged = True
				WhatIsChanged.IdMac = True
				_IdMac = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IUtMac.IdUt
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an UtMac from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As UtMac = Manager.Read(Id)
				_IdUtMac = int.IdUtMac
				_IdMac = int.IdMac
				_IdUt = int.IdUt
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an UtMac on DB.
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
'''Interface for table Tr_utmac
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IUtMac

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdUtMac() as integer
	Property IdMac() as integer
	Property IdUt() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class UtMac
		Public Shared ReadOnly Property IdUtMac As New LUNA.LunaFieldName("IdUtMac")
		Public Shared ReadOnly Property IdMac As New LUNA.LunaFieldName("IdMac")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
	End Class

End Class