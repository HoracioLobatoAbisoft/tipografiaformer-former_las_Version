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
'''DAO Class for table T_omaggi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Omaggio
	Inherits LUNA.LunaBaseClassEntity
	Implements _IOmaggio
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IOmaggio.FillFromDataRecord
		IdOmaggio = myRecord("IdOmaggio")
		IdListinoOmaggio = myRecord("IdListinoOmaggio")
		IdPreventivazione = myRecord("IdPreventivazione")
		ImportoMin = myRecord("ImportoMin")
		QtaOmaggio = myRecord("QtaOmaggio")
		TipoCliente = myRecord("TipoCliente")
		Tipologia = myRecord("Tipologia")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Omaggio)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(OmaggiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Omaggio))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdOmaggio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoOmaggio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPreventivazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoMin As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property QtaOmaggio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoCliente As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipologia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdOmaggio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoOmaggio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPreventivazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoMin = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.QtaOmaggio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoCliente = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipologia = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdOmaggio as integer  = 0 
	Public Overridable Property IdOmaggio() as integer  Implements _IOmaggio.IdOmaggio
		Get
			Return _IdOmaggio
		End Get
		Set (byval value as integer)
			If _IdOmaggio <> value Then
				IsChanged = True
				WhatIsChanged.IdOmaggio = True
				_IdOmaggio = value
			End If
		End Set
	End property 

	Protected _IdListinoOmaggio as integer  = 0 
	Public Overridable Property IdListinoOmaggio() as integer  Implements _IOmaggio.IdListinoOmaggio
		Get
			Return _IdListinoOmaggio
		End Get
		Set (byval value as integer)
			If _IdListinoOmaggio <> value Then
				IsChanged = True
				WhatIsChanged.IdListinoOmaggio = True
				_IdListinoOmaggio = value
			End If
		End Set
	End property 

	Protected _IdPreventivazione as integer  = 0 
	Public Overridable Property IdPreventivazione() as integer  Implements _IOmaggio.IdPreventivazione
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

	Protected _ImportoMin as decimal  = 0 
	Public Overridable Property ImportoMin() as decimal  Implements _IOmaggio.ImportoMin
		Get
			Return _ImportoMin
		End Get
		Set (byval value as decimal)
			If _ImportoMin <> value Then
				IsChanged = True
				WhatIsChanged.ImportoMin = True
				_ImportoMin = value
			End If
		End Set
	End property 

	Protected _QtaOmaggio as integer  = 0 
	Public Overridable Property QtaOmaggio() as integer  Implements _IOmaggio.QtaOmaggio
		Get
			Return _QtaOmaggio
		End Get
		Set (byval value as integer)
			If _QtaOmaggio <> value Then
				IsChanged = True
				WhatIsChanged.QtaOmaggio = True
				_QtaOmaggio = value
			End If
		End Set
	End property 

	Protected _TipoCliente as integer  = 0 
	Public Overridable Property TipoCliente() as integer  Implements _IOmaggio.TipoCliente
		Get
			Return _TipoCliente
		End Get
		Set (byval value as integer)
			If _TipoCliente <> value Then
				IsChanged = True
				WhatIsChanged.TipoCliente = True
				_TipoCliente = value
			End If
		End Set
	End property 

	Protected _Tipologia as integer  = 0 
	Public Overridable Property Tipologia() as integer  Implements _IOmaggio.Tipologia
		Get
			Return _Tipologia
		End Get
		Set (byval value as integer)
			If _Tipologia <> value Then
				IsChanged = True
				WhatIsChanged.Tipologia = True
				_Tipologia = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Omaggio from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Omaggio = Manager.Read(Id)
				_IdOmaggio = int.IdOmaggio
				_IdListinoOmaggio = int.IdListinoOmaggio
				_IdPreventivazione = int.IdPreventivazione
				_ImportoMin = int.ImportoMin
				_QtaOmaggio = int.QtaOmaggio
				_TipoCliente = int.TipoCliente
				_Tipologia = int.Tipologia
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Omaggio on DB.
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
'''Interface for table T_omaggi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IOmaggio

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdOmaggio() as integer
	Property IdListinoOmaggio() as integer
	Property IdPreventivazione() as integer
	Property ImportoMin() as decimal
	Property QtaOmaggio() as integer
	Property TipoCliente() as integer
	Property Tipologia() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Omaggio
		Public Shared ReadOnly Property IdOmaggio As New LUNA.LunaFieldName("IdOmaggio")
		Public Shared ReadOnly Property IdListinoOmaggio As New LUNA.LunaFieldName("IdListinoOmaggio")
		Public Shared ReadOnly Property IdPreventivazione As New LUNA.LunaFieldName("IdPreventivazione")
		Public Shared ReadOnly Property ImportoMin As New LUNA.LunaFieldName("ImportoMin")
		Public Shared ReadOnly Property QtaOmaggio As New LUNA.LunaFieldName("QtaOmaggio")
		Public Shared ReadOnly Property TipoCliente As New LUNA.LunaFieldName("TipoCliente")
		Public Shared ReadOnly Property Tipologia As New LUNA.LunaFieldName("Tipologia")
	End Class

End Class