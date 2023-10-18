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
'''DAO Class for table Tr_utrep
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _UtRep
	Inherits LUNA.LunaBaseClassEntity
	Implements _IUtRep
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IUtRep.FillFromDataRecord
		IdUtRep = myRecord("IdUtRep")
		if not myRecord("IdRep") is DBNull.Value then IdRep = myRecord("IdRep")
		if not myRecord("IdUt") is DBNull.Value then IdUt = myRecord("IdUt")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of UtRep)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(UtRepDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of UtRep))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdUtRep As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRep As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdUtRep = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRep = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdUtRep as integer  = 0 
	Public Overridable Property IdUtRep() as integer  Implements _IUtRep.IdUtRep
		Get
			Return _IdUtRep
		End Get
		Set (byval value as integer)
			If _IdUtRep <> value Then
				IsChanged = True
				WhatIsChanged.IdUtRep = True
				_IdUtRep = value
			End If
		End Set
	End property 

	Protected _IdRep as integer  = 0 
	Public Overridable Property IdRep() as integer  Implements _IUtRep.IdRep
		Get
			Return _IdRep
		End Get
		Set (byval value as integer)
			If _IdRep <> value Then
				IsChanged = True
				WhatIsChanged.IdRep = True
				_IdRep = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IUtRep.IdUt
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
	'''This method read an UtRep from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As UtRep = Manager.Read(Id)
				_IdUtRep = int.IdUtRep
				_IdRep = int.IdRep
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
	'''This method save an UtRep on DB.
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
'''Interface for table Tr_utrep
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IUtRep

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdUtRep() as integer
	Property IdRep() as integer
	Property IdUt() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class UtRep
		Public Shared ReadOnly Property IdUtRep As New LUNA.LunaFieldName("IdUtRep")
		Public Shared ReadOnly Property IdRep As New LUNA.LunaFieldName("IdRep")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
	End Class

End Class