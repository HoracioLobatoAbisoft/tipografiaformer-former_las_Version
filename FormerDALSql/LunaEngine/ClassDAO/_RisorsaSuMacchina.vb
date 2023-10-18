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
'''DAO Class for table Tr_rismacchina
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _RisorsaSuMacchina
	Inherits LUNA.LunaBaseClassEntity
	Implements _IRisorsaSuMacchina
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IRisorsaSuMacchina.FillFromDataRecord
		IdRisMacchina = myRecord("IdRisMacchina")
		IdMacchinario = myRecord("IdMacchinario")
		IdRisorsa = myRecord("IdRisorsa")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of RisorsaSuMacchina)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(RisorseSuMacchinaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of RisorsaSuMacchina))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdRisMacchina As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRisorsa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdRisMacchina = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRisorsa = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdRisMacchina as integer  = 0 
	Public Overridable Property IdRisMacchina() as integer  Implements _IRisorsaSuMacchina.IdRisMacchina
		Get
			Return _IdRisMacchina
		End Get
		Set (byval value as integer)
			If _IdRisMacchina <> value Then
				IsChanged = True
				WhatIsChanged.IdRisMacchina = True
				_IdRisMacchina = value
			End If
		End Set
	End property 

	Protected _IdMacchinario as integer  = 0 
	Public Overridable Property IdMacchinario() as integer  Implements _IRisorsaSuMacchina.IdMacchinario
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

	Protected _IdRisorsa as integer  = 0 
	Public Overridable Property IdRisorsa() as integer  Implements _IRisorsaSuMacchina.IdRisorsa
		Get
			Return _IdRisorsa
		End Get
		Set (byval value as integer)
			If _IdRisorsa <> value Then
				IsChanged = True
				WhatIsChanged.IdRisorsa = True
				_IdRisorsa = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an RisorsaSuMacchina from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As RisorsaSuMacchina = Manager.Read(Id)
				_IdRisMacchina = int.IdRisMacchina
				_IdMacchinario = int.IdMacchinario
				_IdRisorsa = int.IdRisorsa
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an RisorsaSuMacchina on DB.
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
'''Interface for table Tr_rismacchina
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IRisorsaSuMacchina

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdRisMacchina() as integer
	Property IdMacchinario() as integer
	Property IdRisorsa() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class RisorsaSuMacchina
		Public Shared ReadOnly Property IdRisMacchina As New LUNA.LunaFieldName("IdRisMacchina")
		Public Shared ReadOnly Property IdMacchinario As New LUNA.LunaFieldName("IdMacchinario")
		Public Shared ReadOnly Property IdRisorsa As New LUNA.LunaFieldName("IdRisorsa")
	End Class

End Class