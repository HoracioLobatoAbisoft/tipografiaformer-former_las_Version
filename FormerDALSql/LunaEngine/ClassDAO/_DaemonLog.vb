#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 05/01/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Daemonlog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _DaemonLog
	Inherits LUNA.LunaBaseClassEntity
	Implements _IDaemonLog
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

    Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IDaemonLog.FillFromDataRecord
        IdDaemonLog = myRecord("IdDaemonLog")
        Descrizione = myRecord("Descrizione")
        Quando = myRecord("Quando")
        Servizio = myRecord("Servizio")
        Tipo = myRecord("Tipo")

        ResetIsChanged()
    End Sub

    Private Property Manager As LUNA.ILunaBaseClassDAO(Of DaemonLog)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(DaemonLogDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of DaemonLog))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdDaemonLog As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Servizio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

    Private Sub ResetIsChanged()

        IsChanged = False
        WhatIsChanged.IdDaemonLog = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Servizio = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime

    End Sub

    Protected _IdDaemonLog as integer  = 0 
	Public Overridable Property IdDaemonLog() as integer  Implements _IDaemonLog.IdDaemonLog
		Get
			Return _IdDaemonLog
		End Get
		Set (byval value as integer)
			If _IdDaemonLog <> value Then
				IsChanged = True
				WhatIsChanged.IdDaemonLog = True
				_IdDaemonLog = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IDaemonLog.Descrizione
		Get
			Return _Descrizione
		End Get
		Set (byval value as string)
			If _Descrizione <> value Then
				IsChanged = True
				WhatIsChanged.Descrizione = True
				_Descrizione = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IDaemonLog.Quando
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

	Protected _Servizio as integer  = 0 
	Public Overridable Property Servizio() as integer  Implements _IDaemonLog.Servizio
		Get
			Return _Servizio
		End Get
		Set (byval value as integer)
			If _Servizio <> value Then
				IsChanged = True
				WhatIsChanged.Servizio = True
				_Servizio = value
			End If
		End Set
	End property 

	Protected _Tipo as integer  = 0 
	Public Overridable Property Tipo() as integer  Implements _IDaemonLog.Tipo
		Get
			Return _Tipo
		End Get
		Set (byval value as integer)
			If _Tipo <> value Then
				IsChanged = True
				WhatIsChanged.Tipo = True
				_Tipo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an DaemonLog from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As DaemonLog = Manager.Read(Id)
				_IdDaemonLog = int.IdDaemonLog
				_Descrizione = int.Descrizione
				_Quando = int.Quando
				_Servizio = int.Servizio
				_Tipo = int.Tipo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an DaemonLog on DB.
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
  
		if _Descrizione.Length = 0 then Ris = False
		if _Descrizione.Length > 2147483647 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Daemonlog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IDaemonLog

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdDaemonLog() as integer
	Property Descrizione() as string
	Property Quando() as DateTime
	Property Servizio() as integer
	Property Tipo() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class DaemonLog
		Public Shared ReadOnly Property IdDaemonLog As New LUNA.LunaFieldName("IdDaemonLog")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
		Public Shared ReadOnly Property Servizio As New LUNA.LunaFieldName("Servizio")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
	End Class

End Class