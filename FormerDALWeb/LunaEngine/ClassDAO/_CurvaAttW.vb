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
'''DAO Class for table T_curvaatt
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CurvaAttW
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICurvaAttW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICurvaAttW.FillFromDataRecord
		IdCurvaAtt = myRecord("IdCurvaAtt")
		if not myRecord("NomeCurva") is DBNull.Value then NomeCurva = myRecord("NomeCurva")
		if not myRecord("v1") is DBNull.Value then v1 = myRecord("v1")
		if not myRecord("v2") is DBNull.Value then v2 = myRecord("v2")
		if not myRecord("v3") is DBNull.Value then v3 = myRecord("v3")
		if not myRecord("v4") is DBNull.Value then v4 = myRecord("v4")
		if not myRecord("v5") is DBNull.Value then v5 = myRecord("v5")
		if not myRecord("v6") is DBNull.Value then v6 = myRecord("v6")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CurvaAttW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CurvaAttWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CurvaAttW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCurvaAtt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeCurva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v5 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v6 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCurvaAtt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeCurva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v5 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v6 = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCurvaAtt as integer  = 0 
	Public Overridable Property IdCurvaAtt() as integer  Implements _ICurvaAttW.IdCurvaAtt
		Get
			Return _IdCurvaAtt
		End Get
		Set (byval value as integer)
			If _IdCurvaAtt <> value Then
				IsChanged = True
				WhatIsChanged.IdCurvaAtt = True
				_IdCurvaAtt = value
			End If
		End Set
	End property 

	Protected _NomeCurva as string  = "" 
	Public Overridable Property NomeCurva() as string  Implements _ICurvaAttW.NomeCurva
		Get
			Return _NomeCurva
		End Get
		Set (byval value as string)
			If _NomeCurva <> value Then
				IsChanged = True
				WhatIsChanged.NomeCurva = True
				_NomeCurva = value
			End If
		End Set
	End property 

	Protected _v1 as Single  = 0 
	Public Overridable Property v1() as Single  Implements _ICurvaAttW.v1
		Get
			Return _v1
		End Get
		Set (byval value as Single)
			If _v1 <> value Then
				IsChanged = True
				WhatIsChanged.v1 = True
				_v1 = value
			End If
		End Set
	End property 

	Protected _v2 as Single  = 0 
	Public Overridable Property v2() as Single  Implements _ICurvaAttW.v2
		Get
			Return _v2
		End Get
		Set (byval value as Single)
			If _v2 <> value Then
				IsChanged = True
				WhatIsChanged.v2 = True
				_v2 = value
			End If
		End Set
	End property 

	Protected _v3 as Single  = 0 
	Public Overridable Property v3() as Single  Implements _ICurvaAttW.v3
		Get
			Return _v3
		End Get
		Set (byval value as Single)
			If _v3 <> value Then
				IsChanged = True
				WhatIsChanged.v3 = True
				_v3 = value
			End If
		End Set
	End property 

	Protected _v4 as Single  = 0 
	Public Overridable Property v4() as Single  Implements _ICurvaAttW.v4
		Get
			Return _v4
		End Get
		Set (byval value as Single)
			If _v4 <> value Then
				IsChanged = True
				WhatIsChanged.v4 = True
				_v4 = value
			End If
		End Set
	End property 

	Protected _v5 as Single  = 0 
	Public Overridable Property v5() as Single  Implements _ICurvaAttW.v5
		Get
			Return _v5
		End Get
		Set (byval value as Single)
			If _v5 <> value Then
				IsChanged = True
				WhatIsChanged.v5 = True
				_v5 = value
			End If
		End Set
	End property 

	Protected _v6 as Single  = 0 
	Public Overridable Property v6() as Single  Implements _ICurvaAttW.v6
		Get
			Return _v6
		End Get
		Set (byval value as Single)
			If _v6 <> value Then
				IsChanged = True
				WhatIsChanged.v6 = True
				_v6 = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CurvaAttW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CurvaAttW = Manager.Read(Id)
				_IdCurvaAtt = int.IdCurvaAtt
				_NomeCurva = int.NomeCurva
				_v1 = int.v1
				_v2 = int.v2
				_v3 = int.v3
				_v4 = int.v4
				_v5 = int.v5
				_v6 = int.v6
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CurvaAttW on DB.
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
		if _NomeCurva.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_curvaatt
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICurvaAttW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCurvaAtt() as integer
	Property NomeCurva() as string
	Property v1() as Single
	Property v2() as Single
	Property v3() as Single
	Property v4() as Single
	Property v5() as Single
	Property v6() as Single

#End Region

End Interface

Partial Public Class LFM

	Public Class CurvaAttW
		Public Shared ReadOnly Property IdCurvaAtt As New LUNA.LunaFieldName("IdCurvaAtt")
		Public Shared ReadOnly Property NomeCurva As New LUNA.LunaFieldName("NomeCurva")
		Public Shared ReadOnly Property v1 As New LUNA.LunaFieldName("v1")
		Public Shared ReadOnly Property v2 As New LUNA.LunaFieldName("v2")
		Public Shared ReadOnly Property v3 As New LUNA.LunaFieldName("v3")
		Public Shared ReadOnly Property v4 As New LUNA.LunaFieldName("v4")
		Public Shared ReadOnly Property v5 As New LUNA.LunaFieldName("v5")
		Public Shared ReadOnly Property v6 As New LUNA.LunaFieldName("v6")
	End Class

End Class