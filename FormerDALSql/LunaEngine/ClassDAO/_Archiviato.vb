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
'''DAO Class for table Archivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Archiviato
	Inherits LUNA.LunaBaseClassEntity
	Implements _IArchiviato
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IArchiviato.FillFromDataRecord
		IdArchivio = myRecord("IdArchivio")
		DataIns = myRecord("DataIns")
		IdCorriere = myRecord("IdCorriere")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		IdProd = myRecord("IdProd")
		Qta = myRecord("Qta")
		Ricarico = myRecord("Ricarico")
		Sconto = myRecord("Sconto")
		if not myRecord("Sorgente") is DBNull.Value then Sorgente = myRecord("Sorgente")
		TotaleForn = myRecord("TotaleForn")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Archiviato)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ArchiviDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Archiviato))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdArchivio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ricarico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sconto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sorgente As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TotaleForn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdArchivio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ricarico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sconto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sorgente = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TotaleForn = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdArchivio as integer  = 0 
	Public Overridable Property IdArchivio() as integer  Implements _IArchiviato.IdArchivio
		Get
			Return _IdArchivio
		End Get
		Set (byval value as integer)
			If _IdArchivio <> value Then
				IsChanged = True
				WhatIsChanged.IdArchivio = True
				_IdArchivio = value
			End If
		End Set
	End property 

	Protected _DataIns as DateTime  = Nothing 
	Public Overridable Property DataIns() as DateTime  Implements _IArchiviato.DataIns
		Get
			Return _DataIns
		End Get
		Set (byval value as DateTime)
			If _DataIns <> value Then
				IsChanged = True
				WhatIsChanged.DataIns = True
				_DataIns = value
			End If
		End Set
	End property 

	Protected _IdCorriere as integer  = 0 
	Public Overridable Property IdCorriere() as integer  Implements _IArchiviato.IdCorriere
		Get
			Return _IdCorriere
		End Get
		Set (byval value as integer)
			If _IdCorriere <> value Then
				IsChanged = True
				WhatIsChanged.IdCorriere = True
				_IdCorriere = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IArchiviato.IdListinoBase
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

	Protected _IdProd as integer  = 0 
	Public Overridable Property IdProd() as integer  Implements _IArchiviato.IdProd
		Get
			Return _IdProd
		End Get
		Set (byval value as integer)
			If _IdProd <> value Then
				IsChanged = True
				WhatIsChanged.IdProd = True
				_IdProd = value
			End If
		End Set
	End property 

	Protected _Qta as integer  = 0 
	Public Overridable Property Qta() as integer  Implements _IArchiviato.Qta
		Get
			Return _Qta
		End Get
		Set (byval value as integer)
			If _Qta <> value Then
				IsChanged = True
				WhatIsChanged.Qta = True
				_Qta = value
			End If
		End Set
	End property 

	Protected _Ricarico as decimal  = 0 
	Public Overridable Property Ricarico() as decimal  Implements _IArchiviato.Ricarico
		Get
			Return _Ricarico
		End Get
		Set (byval value as decimal)
			If _Ricarico <> value Then
				IsChanged = True
				WhatIsChanged.Ricarico = True
				_Ricarico = value
			End If
		End Set
	End property 

	Protected _Sconto as decimal  = 0 
	Public Overridable Property Sconto() as decimal  Implements _IArchiviato.Sconto
		Get
			Return _Sconto
		End Get
		Set (byval value as decimal)
			If _Sconto <> value Then
				IsChanged = True
				WhatIsChanged.Sconto = True
				_Sconto = value
			End If
		End Set
	End property 

	Protected _Sorgente as string  = "" 
	Public Overridable Property Sorgente() as string  Implements _IArchiviato.Sorgente
		Get
			Return _Sorgente
		End Get
		Set (byval value as string)
			If _Sorgente <> value Then
				IsChanged = True
				WhatIsChanged.Sorgente = True
				_Sorgente = value
			End If
		End Set
	End property 

	Protected _TotaleForn as decimal  = 0 
	Public Overridable Property TotaleForn() as decimal  Implements _IArchiviato.TotaleForn
		Get
			Return _TotaleForn
		End Get
		Set (byval value as decimal)
			If _TotaleForn <> value Then
				IsChanged = True
				WhatIsChanged.TotaleForn = True
				_TotaleForn = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Archiviato from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Archiviato = Manager.Read(Id)
				_IdArchivio = int.IdArchivio
				_DataIns = int.DataIns
				_IdCorriere = int.IdCorriere
				_IdListinoBase = int.IdListinoBase
				_IdProd = int.IdProd
				_Qta = int.Qta
				_Ricarico = int.Ricarico
				_Sconto = int.Sconto
				_Sorgente = int.Sorgente
				_TotaleForn = int.TotaleForn
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Archiviato on DB.
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
		if _Sorgente.Length > 1 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Archivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IArchiviato

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdArchivio() as integer
	Property DataIns() as DateTime
	Property IdCorriere() as integer
	Property IdListinoBase() as integer
	Property IdProd() as integer
	Property Qta() as integer
	Property Ricarico() as decimal
	Property Sconto() as decimal
	Property Sorgente() as string
	Property TotaleForn() as decimal

#End Region

End Interface

Partial Public Class LFM

	Public Class Archiviato
		Public Shared ReadOnly Property IdArchivio As New LUNA.LunaFieldName("IdArchivio")
		Public Shared ReadOnly Property DataIns As New LUNA.LunaFieldName("DataIns")
		Public Shared ReadOnly Property IdCorriere As New LUNA.LunaFieldName("IdCorriere")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdProd As New LUNA.LunaFieldName("IdProd")
		Public Shared ReadOnly Property Qta As New LUNA.LunaFieldName("Qta")
		Public Shared ReadOnly Property Ricarico As New LUNA.LunaFieldName("Ricarico")
		Public Shared ReadOnly Property Sconto As New LUNA.LunaFieldName("Sconto")
		Public Shared ReadOnly Property Sorgente As New LUNA.LunaFieldName("Sorgente")
		Public Shared ReadOnly Property TotaleForn As New LUNA.LunaFieldName("TotaleForn")
	End Class

End Class