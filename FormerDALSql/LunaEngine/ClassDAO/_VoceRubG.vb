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
'''DAO Class for table T_rubricag
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _VoceRubG
	Inherits LUNA.LunaBaseClassEntity
	Implements _IVoceRubG
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IVoceRubG.FillFromDataRecord
		IdRubG = myRecord("IdRubG")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("IdRubM") is DBNull.Value then IdRubM = myRecord("IdRubM")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of VoceRubG)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(VociRubGDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of VoceRubG))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdRubG As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRubM As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdRubG = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRubM = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdRubG as integer  = 0 
	Public Overridable Property IdRubG() as integer  Implements _IVoceRubG.IdRubG
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

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IVoceRubG.IdRub
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

	Protected _IdRubM as integer  = 0 
	Public Overridable Property IdRubM() as integer  Implements _IVoceRubG.IdRubM
		Get
			Return _IdRubM
		End Get
		Set (byval value as integer)
			If _IdRubM <> value Then
				IsChanged = True
				WhatIsChanged.IdRubM = True
				_IdRubM = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an VoceRubG from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As VoceRubG = Manager.Read(Id)
				_IdRubG = int.IdRubG
				_IdRub = int.IdRub
				_IdRubM = int.IdRubM
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an VoceRubG on DB.
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
'''Interface for table T_rubricag
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IVoceRubG

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdRubG() as integer
	Property IdRub() as integer
	Property IdRubM() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class VoceRubG
		Public Shared ReadOnly Property IdRubG As New LUNA.LunaFieldName("IdRubG")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property IdRubM As New LUNA.LunaFieldName("IdRubM")
	End Class

End Class