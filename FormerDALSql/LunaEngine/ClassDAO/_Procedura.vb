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
'''DAO Class for table T_procedure
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Procedura
	Inherits LUNA.LunaBaseClassEntity
	Implements _IProcedura
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IProcedura.FillFromDataRecord
		IdProcedura = myRecord("IdProcedura")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("IdLavorazione") is DBNull.Value then IdLavorazione = myRecord("IdLavorazione")
		if not myRecord("IdMacchinario") is DBNull.Value then IdMacchinario = myRecord("IdMacchinario")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Procedura)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ProcedureDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Procedura))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdProcedura As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdLavorazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdProcedura = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdLavorazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdProcedura as integer  = 0 
	Public Overridable Property IdProcedura() as integer  Implements _IProcedura.IdProcedura
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

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IProcedura.Descrizione
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

	Protected _IdLavorazione as integer  = 0 
	Public Overridable Property IdLavorazione() as integer  Implements _IProcedura.IdLavorazione
		Get
			Return _IdLavorazione
		End Get
		Set (byval value as integer)
			If _IdLavorazione <> value Then
				IsChanged = True
				WhatIsChanged.IdLavorazione = True
				_IdLavorazione = value
			End If
		End Set
	End property 

	Protected _IdMacchinario as integer  = 0 
	Public Overridable Property IdMacchinario() as integer  Implements _IProcedura.IdMacchinario
		Get
			Return _IdMacchinario
		End Get
		Set (byval value as integer)
			If _IdMacchinario <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinario = True
				_IdMacchinario = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IProcedura.Nome
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Procedura from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Procedura = Manager.Read(Id)
				_IdProcedura = int.IdProcedura
				_Descrizione = int.Descrizione
				_IdLavorazione = int.IdLavorazione
				_IdMacchinario = int.IdMacchinario
				_Nome = int.Nome
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Procedura on DB.
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
		if _Descrizione.Length > 2147483647 then Ris = False
		if _Nome.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_procedure
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IProcedura

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdProcedura() as integer
	Property Descrizione() as string
	Property IdLavorazione() as integer
	Property IdMacchinario() as integer
	Property Nome() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Procedura
		Public Shared ReadOnly Property IdProcedura As New LUNA.LunaFieldName("IdProcedura")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property IdLavorazione As New LUNA.LunaFieldName("IdLavorazione")
		Public Shared ReadOnly Property IdMacchinario As New LUNA.LunaFieldName("IdMacchinario")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
	End Class

End Class