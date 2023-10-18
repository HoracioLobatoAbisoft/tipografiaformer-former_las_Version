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
'''DAO Class for table Tr_prevlistino
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _PrevLinkListino
	Inherits LUNA.LunaBaseClassEntity
	Implements _IPrevLinkListino
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IPrevLinkListino.FillFromDataRecord
		IdPrevListino = myRecord("IdPrevListino")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		if not myRecord("IdPreventivazione") is DBNull.Value then IdPreventivazione = myRecord("IdPreventivazione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of PrevLinkListino)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(PrevLinkListinoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of PrevLinkListino))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdPrevListino As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPreventivazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdPrevListino = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPreventivazione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdPrevListino as integer  = 0 
	Public Overridable Property IdPrevListino() as integer  Implements _IPrevLinkListino.IdPrevListino
		Get
			Return _IdPrevListino
		End Get
		Set (byval value as integer)
			If _IdPrevListino <> value Then
				IsChanged = True
				WhatIsChanged.IdPrevListino = True
				_IdPrevListino = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IPrevLinkListino.IdListinoBase
		Get
			Return _IdListinoBase
		End Get
		Set (byval value as integer)
			If _IdListinoBase <> value Then
				IsChanged = True
				WhatIsChanged.IdListinoBase = True
				_IdListinoBase = value
			End If
		End Set
	End property 

	Protected _IdPreventivazione as integer  = 0 
	Public Overridable Property IdPreventivazione() as integer  Implements _IPrevLinkListino.IdPreventivazione
		Get
			Return _IdPreventivazione
		End Get
		Set (byval value as integer)
			If _IdPreventivazione <> value Then
				IsChanged = True
				WhatIsChanged.IdPreventivazione = True
				_IdPreventivazione = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an PrevLinkListino from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As PrevLinkListino = Manager.Read(Id)
				_IdPrevListino = int.IdPrevListino
				_IdListinoBase = int.IdListinoBase
				_IdPreventivazione = int.IdPreventivazione
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an PrevLinkListino on DB.
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
'''Interface for table Tr_prevlistino
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IPrevLinkListino

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdPrevListino() as integer
	Property IdListinoBase() as integer
	Property IdPreventivazione() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class PrevLinkListino
		Public Shared ReadOnly Property IdPrevListino As New LUNA.LunaFieldName("IdPrevListino")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdPreventivazione As New LUNA.LunaFieldName("IdPreventivazione")
	End Class

End Class