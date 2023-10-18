#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 04/07/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Comandiremoti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ComandoRemoto
	Inherits LUNA.LunaBaseClassEntity
	Implements _IComandoRemoto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IComandoRemoto.FillFromDataRecord
		IdCM = myRecord("IdCM")
		if not myRecord("IdCom") is DBNull.Value then IdCom = myRecord("IdCom")
		if not myRecord("IdOrd") is DBNull.Value then IdOrd = myRecord("IdOrd")
		if not myRecord("IdUt") is DBNull.Value then IdUt = myRecord("IdUt")
		if not myRecord("Stato") is DBNull.Value then Stato = myRecord("Stato")
		if not myRecord("TipoOperazione") is DBNull.Value then TipoOperazione = myRecord("TipoOperazione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ComandoRemoto)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ComandiRemotiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ComandoRemoto))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCM As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoOperazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCM = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoOperazione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCM as integer  = 0 
	Public Overridable Property IdCM() as integer  Implements _IComandoRemoto.IdCM
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

	Protected _IdCom as integer  = 0 
	Public Overridable Property IdCom() as integer  Implements _IComandoRemoto.IdCom
		Get
			Return _IdCom
		End Get
		Set (byval value as integer)
			If _IdCom <> value Then
				IsChanged = True
				WhatIsChanged.IdCom = True
				_IdCom = value
			End If
		End Set
	End property 

	Protected _IdOrd as integer  = 0 
	Public Overridable Property IdOrd() as integer  Implements _IComandoRemoto.IdOrd
		Get
			Return _IdOrd
		End Get
		Set (byval value as integer)
			If _IdOrd <> value Then
				IsChanged = True
				WhatIsChanged.IdOrd = True
				_IdOrd = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IComandoRemoto.IdUt
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

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IComandoRemoto.Stato
		Get
			Return _Stato
		End Get
		Set (byval value as integer)
			If _Stato <> value Then
				IsChanged = True
				WhatIsChanged.Stato = True
				_Stato = value
			End If
		End Set
	End property 

	Protected _TipoOperazione as integer  = 0 
	Public Overridable Property TipoOperazione() as integer  Implements _IComandoRemoto.TipoOperazione
		Get
			Return _TipoOperazione
		End Get
		Set (byval value as integer)
			If _TipoOperazione <> value Then
				IsChanged = True
				WhatIsChanged.TipoOperazione = True
				_TipoOperazione = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ComandoRemoto from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ComandoRemoto = Manager.Read(Id)
				_IdCM = int.IdCM
				_IdCom = int.IdCom
				_IdOrd = int.IdOrd
				_IdUt = int.IdUt
				_Stato = int.Stato
				_TipoOperazione = int.TipoOperazione
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ComandoRemoto on DB.
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
'''Interface for table Comandiremoti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IComandoRemoto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCM() as integer
	Property IdCom() as integer
	Property IdOrd() as integer
	Property IdUt() as integer
	Property Stato() as integer
	Property TipoOperazione() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ComandoRemoto
		Public Shared ReadOnly Property IdCM As New LUNA.LunaFieldName("IdCM")
		Public Shared ReadOnly Property IdCom As New LUNA.LunaFieldName("IdCom")
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property TipoOperazione As New LUNA.LunaFieldName("TipoOperazione")
	End Class

End Class