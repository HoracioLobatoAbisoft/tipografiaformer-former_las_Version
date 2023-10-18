#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 05/07/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Comandiremotilog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ComandoRemotoLog
	Inherits LUNA.LunaBaseClassEntity
	Implements _IComandoRemotoLog
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IComandoRemotoLog.FillFromDataRecord
		IdCMLog = myRecord("IdCMLog")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		IdCM = myRecord("IdCM")
		IdOperazioneRemota = myRecord("IdOperazioneRemota")
		Quando = myRecord("Quando")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ComandoRemotoLog)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ComandiRemotiLogDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ComandoRemotoLog))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCMLog As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCM As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOperazioneRemota As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCMLog = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCM = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOperazioneRemota = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCMLog as integer  = 0 
	Public Overridable Property IdCMLog() as integer  Implements _IComandoRemotoLog.IdCMLog
		Get
			Return _IdCMLog
		End Get
		Set (byval value as integer)
			If _IdCMLog <> value Then
				IsChanged = True
				WhatIsChanged.IdCMLog = True
				_IdCMLog = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _IComandoRemotoLog.Annotazioni
		Get
			Return _Annotazioni
		End Get
		Set (byval value as string)
			If _Annotazioni <> value Then
				IsChanged = True
				WhatIsChanged.Annotazioni = True
				_Annotazioni = value
			End If
		End Set
	End property 

	Protected _IdCM as integer  = 0 
	Public Overridable Property IdCM() as integer  Implements _IComandoRemotoLog.IdCM
		Get
			Return _IdCM
		End Get
		Set (byval value as integer)
			If _IdCM <> value Then
				IsChanged = True
				WhatIsChanged.IdCM = True
				_IdCM = value
			End If
		End Set
	End property 

	Protected _IdOperazioneRemota as integer  = 0 
	Public Overridable Property IdOperazioneRemota() as integer  Implements _IComandoRemotoLog.IdOperazioneRemota
		Get
			Return _IdOperazioneRemota
		End Get
		Set (byval value as integer)
			If _IdOperazioneRemota <> value Then
				IsChanged = True
				WhatIsChanged.IdOperazioneRemota = True
				_IdOperazioneRemota = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IComandoRemotoLog.Quando
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ComandoRemotoLog from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ComandoRemotoLog = Manager.Read(Id)
				_IdCMLog = int.IdCMLog
				_Annotazioni = int.Annotazioni
				_IdCM = int.IdCM
				_IdOperazioneRemota = int.IdOperazioneRemota
				_Quando = int.Quando
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ComandoRemotoLog on DB.
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
		if _Annotazioni.Length > 2147483647 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Comandiremotilog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IComandoRemotoLog

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCMLog() as integer
	Property Annotazioni() as string
	Property IdCM() as integer
	Property IdOperazioneRemota() as integer
	Property Quando() as DateTime

#End Region

End Interface

Partial Public Class LFM

	Public Class ComandoRemotoLog
		Public Shared ReadOnly Property IdCMLog As New LUNA.LunaFieldName("IdCMLog")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property IdCM As New LUNA.LunaFieldName("IdCM")
		Public Shared ReadOnly Property IdOperazioneRemota As New LUNA.LunaFieldName("IdOperazioneRemota")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
	End Class

End Class