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
'''DAO Class for table Tr_formatomacchinario
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FormatoSuMacchinario
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFormatoSuMacchinario
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFormatoSuMacchinario.FillFromDataRecord
		IdFormatoMacc = myRecord("IdFormatoMacc")
		IdFormato = myRecord("IdFormato")
		IdMacchinario = myRecord("IdMacchinario")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FormatoSuMacchinario)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FormatiSuMacchinariDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FormatoSuMacchinario))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdFormatoMacc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdFormatoMacc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinario = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdFormatoMacc as integer  = 0 
	Public Overridable Property IdFormatoMacc() as integer  Implements _IFormatoSuMacchinario.IdFormatoMacc
		Get
			Return _IdFormatoMacc
		End Get
		Set (byval value as integer)
			If _IdFormatoMacc <> value Then
				IsChanged = True
				WhatIsChanged.IdFormatoMacc = True
				_IdFormatoMacc = value
			End If
		End Set
	End property 

	Protected _IdFormato as integer  = 0 
	Public Overridable Property IdFormato() as integer  Implements _IFormatoSuMacchinario.IdFormato
		Get
			Return _IdFormato
		End Get
		Set (byval value as integer)
			If _IdFormato <> value Then
				IsChanged = True
				WhatIsChanged.IdFormato = True
				_IdFormato = value
			End If
		End Set
	End property 

	Protected _IdMacchinario as integer  = 0 
	Public Overridable Property IdMacchinario() as integer  Implements _IFormatoSuMacchinario.IdMacchinario
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FormatoSuMacchinario from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FormatoSuMacchinario = Manager.Read(Id)
				_IdFormatoMacc = int.IdFormatoMacc
				_IdFormato = int.IdFormato
				_IdMacchinario = int.IdMacchinario
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an FormatoSuMacchinario on DB.
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
'''Interface for table Tr_formatomacchinario
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFormatoSuMacchinario

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdFormatoMacc() as integer
	Property IdFormato() as integer
	Property IdMacchinario() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class FormatoSuMacchinario
		Public Shared ReadOnly Property IdFormatoMacc As New LUNA.LunaFieldName("IdFormatoMacc")
		Public Shared ReadOnly Property IdFormato As New LUNA.LunaFieldName("IdFormato")
		Public Shared ReadOnly Property IdMacchinario As New LUNA.LunaFieldName("IdMacchinario")
	End Class

End Class