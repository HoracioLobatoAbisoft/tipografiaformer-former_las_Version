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
'''DAO Class for table T_step
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _StepProcedura
	Inherits LUNA.LunaBaseClassEntity
	Implements _IStepProcedura
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IStepProcedura.FillFromDataRecord
		IdStep = myRecord("IdStep")
		if not myRecord("FilePath") is DBNull.Value then FilePath = myRecord("FilePath")
		IdProcedura = myRecord("IdProcedura")
		Ordine = myRecord("Ordine")
		if not myRecord("Testo") is DBNull.Value then Testo = myRecord("Testo")
		Titolo = myRecord("Titolo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of StepProcedura)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(StepProcedureDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of StepProcedura))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdStep As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FilePath As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProcedura As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Testo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Titolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdStep = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FilePath = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProcedura = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ordine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Testo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Titolo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdStep as integer  = 0 
	Public Overridable Property IdStep() as integer  Implements _IStepProcedura.IdStep
		Get
			Return _IdStep
		End Get
		Set (byval value as integer)
			If _IdStep <> value Then
				IsChanged = True
				WhatIsChanged.IdStep = True
				_IdStep = value
			End If
		End Set
	End property 

	Protected _FilePath as string  = "" 
	Public Overridable Property FilePath() as string  Implements _IStepProcedura.FilePath
		Get
			Return _FilePath
		End Get
		Set (byval value as string)
			If _FilePath <> value Then
				IsChanged = True
				WhatIsChanged.FilePath = True
				_FilePath = value
			End If
		End Set
	End property 

	Protected _IdProcedura as integer  = 0 
	Public Overridable Property IdProcedura() as integer  Implements _IStepProcedura.IdProcedura
		Get
			Return _IdProcedura
		End Get
		Set (byval value as integer)
			If _IdProcedura <> value Then
				IsChanged = True
				WhatIsChanged.IdProcedura = True
				_IdProcedura = value
			End If
		End Set
	End property 

	Protected _Ordine as integer  = 0 
	Public Overridable Property Ordine() as integer  Implements _IStepProcedura.Ordine
		Get
			Return _Ordine
		End Get
		Set (byval value as integer)
			If _Ordine <> value Then
				IsChanged = True
				WhatIsChanged.Ordine = True
				_Ordine = value
			End If
		End Set
	End property 

	Protected _Testo as string  = "" 
	Public Overridable Property Testo() as string  Implements _IStepProcedura.Testo
		Get
			Return _Testo
		End Get
		Set (byval value as string)
			If _Testo <> value Then
				IsChanged = True
				WhatIsChanged.Testo = True
				_Testo = value
			End If
		End Set
	End property 

	Protected _Titolo as string  = "" 
	Public Overridable Property Titolo() as string  Implements _IStepProcedura.Titolo
		Get
			Return _Titolo
		End Get
		Set (byval value as string)
			If _Titolo <> value Then
				IsChanged = True
				WhatIsChanged.Titolo = True
				_Titolo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an StepProcedura from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As StepProcedura = Manager.Read(Id)
				_IdStep = int.IdStep
				_FilePath = int.FilePath
				_IdProcedura = int.IdProcedura
				_Ordine = int.Ordine
				_Testo = int.Testo
				_Titolo = int.Titolo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an StepProcedura on DB.
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
		if _FilePath.Length > 255 then Ris = False
		if _Testo.Length > 2147483647 then Ris = False
  
		if _Titolo.Length = 0 then Ris = False
		if _Titolo.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_step
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IStepProcedura

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdStep() as integer
	Property FilePath() as string
	Property IdProcedura() as integer
	Property Ordine() as integer
	Property Testo() as string
	Property Titolo() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class StepProcedura
		Public Shared ReadOnly Property IdStep As New LUNA.LunaFieldName("IdStep")
		Public Shared ReadOnly Property FilePath As New LUNA.LunaFieldName("FilePath")
		Public Shared ReadOnly Property IdProcedura As New LUNA.LunaFieldName("IdProcedura")
		Public Shared ReadOnly Property Ordine As New LUNA.LunaFieldName("Ordine")
		Public Shared ReadOnly Property Testo As New LUNA.LunaFieldName("Testo")
		Public Shared ReadOnly Property Titolo As New LUNA.LunaFieldName("Titolo")
	End Class

End Class