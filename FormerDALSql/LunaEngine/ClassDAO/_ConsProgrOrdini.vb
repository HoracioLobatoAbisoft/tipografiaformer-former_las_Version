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
'''DAO Class for table Tr_consord
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ConsProgrOrdini
	Inherits LUNA.LunaBaseClassEntity
	Implements _IConsProgrOrdini
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IConsProgrOrdini.FillFromDataRecord
		IdConsOrd = myRecord("IdConsOrd")
		if not myRecord("IdCons") is DBNull.Value then IdCons = myRecord("IdCons")
		if not myRecord("IdOrd") is DBNull.Value then IdOrd = myRecord("IdOrd")
		if not myRecord("Inserito") is DBNull.Value then Inserito = myRecord("Inserito")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ConsProgrOrdini)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ConsProgrOrdiniDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ConsProgrOrdini))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdConsOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCons As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Inserito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdConsOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCons = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Inserito = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdConsOrd as integer  = 0 
	Public Overridable Property IdConsOrd() as integer  Implements _IConsProgrOrdini.IdConsOrd
		Get
			Return _IdConsOrd
		End Get
		Set (byval value as integer)
			If _IdConsOrd <> value Then
				IsChanged = True
				WhatIsChanged.IdConsOrd = True
				_IdConsOrd = value
			End If
		End Set
	End property 

	Protected _IdCons as integer  = 0 
	Public Overridable Property IdCons() as integer  Implements _IConsProgrOrdini.IdCons
		Get
			Return _IdCons
		End Get
		Set (byval value as integer)
			If _IdCons <> value Then
				IsChanged = True
				WhatIsChanged.IdCons = True
				_IdCons = value
			End If
		End Set
	End property 

	Protected _IdOrd as integer  = 0 
	Public Overridable Property IdOrd() as integer  Implements _IConsProgrOrdini.IdOrd
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

	Protected _Inserito as integer  = 0 
	Public Overridable Property Inserito() as integer  Implements _IConsProgrOrdini.Inserito
		Get
			Return _Inserito
		End Get
		Set (byval value as integer)
			If _Inserito <> value Then
				IsChanged = True
				WhatIsChanged.Inserito = True
				_Inserito = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ConsProgrOrdini from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ConsProgrOrdini = Manager.Read(Id)
				_IdConsOrd = int.IdConsOrd
				_IdCons = int.IdCons
				_IdOrd = int.IdOrd
				_Inserito = int.Inserito
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ConsProgrOrdini on DB.
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
'''Interface for table Tr_consord
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IConsProgrOrdini

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdConsOrd() as integer
	Property IdCons() as integer
	Property IdOrd() as integer
	Property Inserito() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ConsProgrOrdini
		Public Shared ReadOnly Property IdConsOrd As New LUNA.LunaFieldName("IdConsOrd")
		Public Shared ReadOnly Property IdCons As New LUNA.LunaFieldName("IdCons")
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property Inserito As New LUNA.LunaFieldName("Inserito")
	End Class

End Class