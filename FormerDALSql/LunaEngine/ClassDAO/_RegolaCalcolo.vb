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
'''DAO Class for table T_regolecalcolo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _RegolaCalcolo
	Inherits LUNA.LunaBaseClassEntity
	Implements _IRegolaCalcolo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IRegolaCalcolo.FillFromDataRecord
		IdRegola = myRecord("IdRegola")
		if not myRecord("Chiave") is DBNull.Value then Chiave = myRecord("Chiave")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("Opzioni") is DBNull.Value then Opzioni = myRecord("Opzioni")
		if not myRecord("Stato") is DBNull.Value then Stato = myRecord("Stato")
		if not myRecord("TipoRegola") is DBNull.Value then TipoRegola = myRecord("TipoRegola")
		if not myRecord("Valore") is DBNull.Value then Valore = myRecord("Valore")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of RegolaCalcolo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(RegoleCalcoloDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of RegolaCalcolo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdRegola As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Chiave As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Opzioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoRegola As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Valore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdRegola = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Chiave = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Opzioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoRegola = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Valore = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdRegola as integer  = 0 
	Public Overridable Property IdRegola() as integer  Implements _IRegolaCalcolo.IdRegola
		Get
			Return _IdRegola
		End Get
		Set (byval value as integer)
			If _IdRegola <> value Then
				IsChanged = True
				WhatIsChanged.IdRegola = True
				_IdRegola = value
			End If
		End Set
	End property 

	Protected _Chiave as string  = "" 
	Public Overridable Property Chiave() as string  Implements _IRegolaCalcolo.Chiave
		Get
			Return _Chiave
		End Get
		Set (byval value as string)
			If _Chiave <> value Then
				IsChanged = True
				WhatIsChanged.Chiave = True
				_Chiave = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IRegolaCalcolo.IdListinoBase
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

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IRegolaCalcolo.Nome
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

	Protected _Opzioni as string  = "" 
	Public Overridable Property Opzioni() as string  Implements _IRegolaCalcolo.Opzioni
		Get
			Return _Opzioni
		End Get
		Set (byval value as string)
			If _Opzioni <> value Then
				IsChanged = True
				WhatIsChanged.Opzioni = True
				_Opzioni = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IRegolaCalcolo.Stato
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

	Protected _TipoRegola as integer  = 0 
	Public Overridable Property TipoRegola() as integer  Implements _IRegolaCalcolo.TipoRegola
		Get
			Return _TipoRegola
		End Get
		Set (byval value as integer)
			If _TipoRegola <> value Then
				IsChanged = True
				WhatIsChanged.TipoRegola = True
				_TipoRegola = value
			End If
		End Set
	End property 

	Protected _Valore as string  = "" 
	Public Overridable Property Valore() as string  Implements _IRegolaCalcolo.Valore
		Get
			Return _Valore
		End Get
		Set (byval value as string)
			If _Valore <> value Then
				IsChanged = True
				WhatIsChanged.Valore = True
				_Valore = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an RegolaCalcolo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As RegolaCalcolo = Manager.Read(Id)
				_IdRegola = int.IdRegola
				_Chiave = int.Chiave
				_IdListinoBase = int.IdListinoBase
				_Nome = int.Nome
				_Opzioni = int.Opzioni
				_Stato = int.Stato
				_TipoRegola = int.TipoRegola
				_Valore = int.Valore
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an RegolaCalcolo on DB.
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
		if _Chiave.Length > 255 then Ris = False
		if _Nome.Length > 100 then Ris = False
		if _Opzioni.Length > 255 then Ris = False
		if _Valore.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_regolecalcolo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IRegolaCalcolo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdRegola() as integer
	Property Chiave() as string
	Property IdListinoBase() as integer
	Property Nome() as string
	Property Opzioni() as string
	Property Stato() as integer
	Property TipoRegola() as integer
	Property Valore() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class RegolaCalcolo
		Public Shared ReadOnly Property IdRegola As New LUNA.LunaFieldName("IdRegola")
		Public Shared ReadOnly Property Chiave As New LUNA.LunaFieldName("Chiave")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property Opzioni As New LUNA.LunaFieldName("Opzioni")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property TipoRegola As New LUNA.LunaFieldName("TipoRegola")
		Public Shared ReadOnly Property Valore As New LUNA.LunaFieldName("Valore")
	End Class

End Class