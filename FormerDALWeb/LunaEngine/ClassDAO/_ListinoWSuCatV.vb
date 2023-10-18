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
'''DAO Class for table Tr_catvlistini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ListinoWSuCatV
	Inherits LUNA.LunaBaseClassEntity
	Implements _IListinoWSuCatV
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IListinoWSuCatV.FillFromDataRecord
		IdCatListino = myRecord("IdCatListino")
		IdCatVirtuale = myRecord("IdCatVirtuale")
		IdListinoBase = myRecord("IdListinoBase")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ListinoWSuCatV)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ListiniWSuCatVDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ListinoWSuCatV))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCatListino As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatVirtuale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCatListino = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatVirtuale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCatListino as integer  = 0 
	Public Overridable Property IdCatListino() as integer  Implements _IListinoWSuCatV.IdCatListino
		Get
			Return _IdCatListino
		End Get
		Set (byval value as integer)
			If _IdCatListino <> value Then
				IsChanged = True
				WhatIsChanged.IdCatListino = True
				_IdCatListino = value
			End If
		End Set
	End property 

	Protected _IdCatVirtuale as integer  = 0 
	Public Overridable Property IdCatVirtuale() as integer  Implements _IListinoWSuCatV.IdCatVirtuale
		Get
			Return _IdCatVirtuale
		End Get
		Set (byval value as integer)
			If _IdCatVirtuale <> value Then
				IsChanged = True
				WhatIsChanged.IdCatVirtuale = True
				_IdCatVirtuale = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IListinoWSuCatV.IdListinoBase
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ListinoWSuCatV from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ListinoWSuCatV = Manager.Read(Id)
				_IdCatListino = int.IdCatListino
				_IdCatVirtuale = int.IdCatVirtuale
				_IdListinoBase = int.IdListinoBase
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ListinoWSuCatV on DB.
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
'''Interface for table Tr_catvlistini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IListinoWSuCatV

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCatListino() as integer
	Property IdCatVirtuale() as integer
	Property IdListinoBase() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ListinoWSuCatV
		Public Shared ReadOnly Property IdCatListino As New LUNA.LunaFieldName("IdCatListino")
		Public Shared ReadOnly Property IdCatVirtuale As New LUNA.LunaFieldName("IdCatVirtuale")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
	End Class

End Class