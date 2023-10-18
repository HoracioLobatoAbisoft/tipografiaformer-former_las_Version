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
'''DAO Class for table Tracesource
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _TraceSource
	Inherits LUNA.LunaBaseClassEntity
	Implements _ITraceSource
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ITraceSource.FillFromDataRecord
		IdTraceSource = myRecord("IdTraceSource")
		Counter = myRecord("Counter")
		Nome = myRecord("Nome")
		TargetUrl = myRecord("TargetUrl")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of TraceSource)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(TraceSourceDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of TraceSource))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdTraceSource As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Counter As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TargetUrl As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdTraceSource = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Counter = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TargetUrl = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdTraceSource as integer  = 0 
	Public Overridable Property IdTraceSource() as integer  Implements _ITraceSource.IdTraceSource
		Get
			Return _IdTraceSource
		End Get
		Set (byval value as integer)
			If _IdTraceSource <> value Then
				IsChanged = True
				WhatIsChanged.IdTraceSource = True
				_IdTraceSource = value
			End If
		End Set
	End property 

	Protected _Counter as integer  = 0 
	Public Overridable Property Counter() as integer  Implements _ITraceSource.Counter
		Get
			Return _Counter
		End Get
		Set (byval value as integer)
			If _Counter <> value Then
				IsChanged = True
				WhatIsChanged.Counter = True
				_Counter = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _ITraceSource.Nome
		Get
			Return _Nome
		End Get
		Set (byval value as string)
			If _Nome <> value Then
				IsChanged = True
				WhatIsChanged.Nome = True
				_Nome = value
			End If
		End Set
	End property 

	Protected _TargetUrl as string  = "" 
	Public Overridable Property TargetUrl() as string  Implements _ITraceSource.TargetUrl
		Get
			Return _TargetUrl
		End Get
		Set (byval value as string)
			If _TargetUrl <> value Then
				IsChanged = True
				WhatIsChanged.TargetUrl = True
				_TargetUrl = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an TraceSource from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As TraceSource = Manager.Read(Id)
				_IdTraceSource = int.IdTraceSource
				_Counter = int.Counter
				_Nome = int.Nome
				_TargetUrl = int.TargetUrl
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an TraceSource on DB.
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
  
		if _Nome.Length = 0 then Ris = False
		if _Nome.Length > 50 then Ris = False
  
		if _TargetUrl.Length = 0 then Ris = False
		if _TargetUrl.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Tracesource
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITraceSource

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdTraceSource() as integer
	Property Counter() as integer
	Property Nome() as string
	Property TargetUrl() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class TraceSource
		Public Shared ReadOnly Property IdTraceSource As New LUNA.LunaFieldName("IdTraceSource")
		Public Shared ReadOnly Property Counter As New LUNA.LunaFieldName("Counter")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property TargetUrl As New LUNA.LunaFieldName("TargetUrl")
	End Class

End Class