#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 16/06/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Logoperativi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _LogOperativo
	Inherits LUNA.LunaBaseClassEntity
	Implements _ILogOperativo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ILogOperativo.FillFromDataRecord
		IdLog = myRecord("IdLog")
		Buffer = myRecord("Buffer")
		if not myRecord("Chiamata1") is DBNull.Value then Chiamata1 = myRecord("Chiamata1")
		if not myRecord("Chiamata2") is DBNull.Value then Chiamata2 = myRecord("Chiamata2")
		if not myRecord("IdOperatore") is DBNull.Value then IdOperatore = myRecord("IdOperatore")
		IdRif = myRecord("IdRif")
		Quando = myRecord("Quando")
		TipoLog = myRecord("TipoLog")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of LogOperativo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(LogOperativiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of LogOperativo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLog As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Buffer As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Chiamata1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Chiamata2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOperatore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoLog As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLog = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Buffer = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Chiamata1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Chiamata2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOperatore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoLog = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLog as integer  = 0 
	Public Overridable Property IdLog() as integer  Implements _ILogOperativo.IdLog
		Get
			Return _IdLog
		End Get
		Set (byval value as integer)
			If _IdLog <> value Then
				IsChanged = True
				WhatIsChanged.IdLog = True
				_IdLog = value
			End If
		End Set
	End property 

	Protected _Buffer as string  = "" 
	Public Overridable Property Buffer() as string  Implements _ILogOperativo.Buffer
		Get
			Return _Buffer
		End Get
		Set (byval value as string)
			If _Buffer <> value Then
				IsChanged = True
				WhatIsChanged.Buffer = True
				_Buffer = value
			End If
		End Set
	End property 

	Protected _Chiamata1 as string  = "" 
	Public Overridable Property Chiamata1() as string  Implements _ILogOperativo.Chiamata1
		Get
			Return _Chiamata1
		End Get
		Set (byval value as string)
			If _Chiamata1 <> value Then
				IsChanged = True
				WhatIsChanged.Chiamata1 = True
				_Chiamata1 = value
			End If
		End Set
	End property 

	Protected _Chiamata2 as string  = "" 
	Public Overridable Property Chiamata2() as string  Implements _ILogOperativo.Chiamata2
		Get
			Return _Chiamata2
		End Get
		Set (byval value as string)
			If _Chiamata2 <> value Then
				IsChanged = True
				WhatIsChanged.Chiamata2 = True
				_Chiamata2 = value
			End If
		End Set
	End property 

	Protected _IdOperatore as integer  = 0 
	Public Overridable Property IdOperatore() as integer  Implements _ILogOperativo.IdOperatore
		Get
			Return _IdOperatore
		End Get
		Set (byval value as integer)
			If _IdOperatore <> value Then
				IsChanged = True
				WhatIsChanged.IdOperatore = True
				_IdOperatore = value
			End If
		End Set
	End property 

	Protected _IdRif as integer  = 0 
	Public Overridable Property IdRif() as integer  Implements _ILogOperativo.IdRif
		Get
			Return _IdRif
		End Get
		Set (byval value as integer)
			If _IdRif <> value Then
				IsChanged = True
				WhatIsChanged.IdRif = True
				_IdRif = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _ILogOperativo.Quando
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

	Protected _TipoLog as integer  = 0 
	Public Overridable Property TipoLog() as integer  Implements _ILogOperativo.TipoLog
		Get
			Return _TipoLog
		End Get
		Set (byval value as integer)
			If _TipoLog <> value Then
				IsChanged = True
				WhatIsChanged.TipoLog = True
				_TipoLog = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an LogOperativo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As LogOperativo = Manager.Read(Id)
				_IdLog = int.IdLog
				_Buffer = int.Buffer
				_Chiamata1 = int.Chiamata1
				_Chiamata2 = int.Chiamata2
				_IdOperatore = int.IdOperatore
				_IdRif = int.IdRif
				_Quando = int.Quando
				_TipoLog = int.TipoLog
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method Refresh all data in the entity from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
    Public Overridable Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdLog Then
            ris = Read(IdLog)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an LogOperativo on DB.
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
  
		if _Buffer.Length = 0 then Ris = False
		if _Buffer.Length > 255 then Ris = False
		if _Chiamata1.Length > 255 then Ris = False
		if _Chiamata2.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Logoperativi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ILogOperativo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLog() as integer
	Property Buffer() as string
	Property Chiamata1() as string
	Property Chiamata2() as string
	Property IdOperatore() as integer
	Property IdRif() as integer
	Property Quando() as DateTime
	Property TipoLog() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class LogOperativo
		Public Shared ReadOnly Property IdLog As New LUNA.LunaFieldName("IdLog")
		Public Shared ReadOnly Property Buffer As New LUNA.LunaFieldName("Buffer")
		Public Shared ReadOnly Property Chiamata1 As New LUNA.LunaFieldName("Chiamata1")
		Public Shared ReadOnly Property Chiamata2 As New LUNA.LunaFieldName("Chiamata2")
		Public Shared ReadOnly Property IdOperatore As New LUNA.LunaFieldName("IdOperatore")
		Public Shared ReadOnly Property IdRif As New LUNA.LunaFieldName("IdRif")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
		Public Shared ReadOnly Property TipoLog As New LUNA.LunaFieldName("TipoLog")
	End Class

End Class