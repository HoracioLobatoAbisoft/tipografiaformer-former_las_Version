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
'''DAO Class for table Tr_scatord
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _OrdineScatola
	Inherits LUNA.LunaBaseClassEntity
	Implements _IOrdineScatola
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IOrdineScatola.FillFromDataRecord
		IdScatOrd = myRecord("IdScatOrd")
		if not myRecord("EtichettaCollo") is DBNull.Value then EtichettaCollo = myRecord("EtichettaCollo")
		if not myRecord("IdOrdine") is DBNull.Value then IdOrdine = myRecord("IdOrdine")
		if not myRecord("IdScatola") is DBNull.Value then IdScatola = myRecord("IdScatola")
		if not myRecord("NumeroCollo") is DBNull.Value then NumeroCollo = myRecord("NumeroCollo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of OrdineScatola)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(OrdiniScatoleDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of OrdineScatola))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdScatOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property EtichettaCollo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrdine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdScatola As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumeroCollo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdScatOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.EtichettaCollo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrdine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdScatola = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumeroCollo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdScatOrd as integer  = 0 
	Public Overridable Property IdScatOrd() as integer  Implements _IOrdineScatola.IdScatOrd
		Get
			Return _IdScatOrd
		End Get
		Set (byval value as integer)
			If _IdScatOrd <> value Then
				IsChanged = True
				WhatIsChanged.IdScatOrd = True
				_IdScatOrd = value
			End If
		End Set
	End property 

	Protected _EtichettaCollo as string  = "" 
	Public Overridable Property EtichettaCollo() as string  Implements _IOrdineScatola.EtichettaCollo
		Get
			Return _EtichettaCollo
		End Get
		Set (byval value as string)
			If _EtichettaCollo <> value Then
				IsChanged = True
				WhatIsChanged.EtichettaCollo = True
				_EtichettaCollo = value
			End If
		End Set
	End property 

	Protected _IdOrdine as integer  = 0 
	Public Overridable Property IdOrdine() as integer  Implements _IOrdineScatola.IdOrdine
		Get
			Return _IdOrdine
		End Get
		Set (byval value as integer)
			If _IdOrdine <> value Then
				IsChanged = True
				WhatIsChanged.IdOrdine = True
				_IdOrdine = value
			End If
		End Set
	End property 

	Protected _IdScatola as integer  = 0 
	Public Overridable Property IdScatola() as integer  Implements _IOrdineScatola.IdScatola
		Get
			Return _IdScatola
		End Get
		Set (byval value as integer)
			If _IdScatola <> value Then
				IsChanged = True
				WhatIsChanged.IdScatola = True
				_IdScatola = value
			End If
		End Set
	End property 

	Protected _NumeroCollo as integer  = 0 
	Public Overridable Property NumeroCollo() as integer  Implements _IOrdineScatola.NumeroCollo
		Get
			Return _NumeroCollo
		End Get
		Set (byval value as integer)
			If _NumeroCollo <> value Then
				IsChanged = True
				WhatIsChanged.NumeroCollo = True
				_NumeroCollo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an OrdineScatola from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As OrdineScatola = Manager.Read(Id)
				_IdScatOrd = int.IdScatOrd
				_EtichettaCollo = int.EtichettaCollo
				_IdOrdine = int.IdOrdine
				_IdScatola = int.IdScatola
				_NumeroCollo = int.NumeroCollo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an OrdineScatola on DB.
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
		if _EtichettaCollo.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Tr_scatord
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IOrdineScatola

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdScatOrd() as integer
	Property EtichettaCollo() as string
	Property IdOrdine() as integer
	Property IdScatola() as integer
	Property NumeroCollo() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class OrdineScatola
		Public Shared ReadOnly Property IdScatOrd As New LUNA.LunaFieldName("IdScatOrd")
		Public Shared ReadOnly Property EtichettaCollo As New LUNA.LunaFieldName("EtichettaCollo")
		Public Shared ReadOnly Property IdOrdine As New LUNA.LunaFieldName("IdOrdine")
		Public Shared ReadOnly Property IdScatola As New LUNA.LunaFieldName("IdScatola")
		Public Shared ReadOnly Property NumeroCollo As New LUNA.LunaFieldName("NumeroCollo")
	End Class

End Class