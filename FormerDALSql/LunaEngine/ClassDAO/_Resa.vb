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
'''DAO Class for table Tr_resa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Resa
	Inherits LUNA.LunaBaseClassEntity
	Implements _IResa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IResa.FillFromDataRecord
		IDFormatoResa = myRecord("IDFormatoResa")
		if not myRecord("IdFormato") is DBNull.Value then IdFormato = myRecord("IdFormato")
		if not myRecord("IdFormCarta") is DBNull.Value then IdFormCarta = myRecord("IdFormCarta")
		if not myRecord("PercScarto") is DBNull.Value then PercScarto = myRecord("PercScarto")
		if not myRecord("Resa") is DBNull.Value then Resa = myRecord("Resa")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Resa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ResaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Resa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDFormatoResa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercScarto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Resa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDFormatoResa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercScarto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Resa = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDFormatoResa as integer  = 0 
	Public Overridable Property IDFormatoResa() as integer  Implements _IResa.IDFormatoResa
		Get
			Return _IDFormatoResa
		End Get
		Set (byval value as integer)
			If _IDFormatoResa <> value Then
				IsChanged = True
				WhatIsChanged.IDFormatoResa = True
				_IDFormatoResa = value
			End If
		End Set
	End property 

	Protected _IdFormato as integer  = 0 
	Public Overridable Property IdFormato() as integer  Implements _IResa.IdFormato
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

	Protected _IdFormCarta as integer  = 0 
	Public Overridable Property IdFormCarta() as integer  Implements _IResa.IdFormCarta
		Get
			Return _IdFormCarta
		End Get
		Set (byval value as integer)
			If _IdFormCarta <> value Then
				IsChanged = True
				WhatIsChanged.IdFormCarta = True
				_IdFormCarta = value
			End If
		End Set
	End property 

	Protected _PercScarto as integer  = 0 
	Public Overridable Property PercScarto() as integer  Implements _IResa.PercScarto
		Get
			Return _PercScarto
		End Get
		Set (byval value as integer)
			If _PercScarto <> value Then
				IsChanged = True
				WhatIsChanged.PercScarto = True
				_PercScarto = value
			End If
		End Set
	End property 

	Protected _Resa as integer  = 0 
	Public Overridable Property Resa() as integer  Implements _IResa.Resa
		Get
			Return _Resa
		End Get
		Set (byval value as integer)
			If _Resa <> value Then
				IsChanged = True
				WhatIsChanged.Resa = True
				_Resa = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Resa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Resa = Manager.Read(Id)
				_IDFormatoResa = int.IDFormatoResa
				_IdFormato = int.IdFormato
				_IdFormCarta = int.IdFormCarta
				_PercScarto = int.PercScarto
				_Resa = int.Resa
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Resa on DB.
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
'''Interface for table Tr_resa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IResa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDFormatoResa() as integer
	Property IdFormato() as integer
	Property IdFormCarta() as integer
	Property PercScarto() as integer
	Property Resa() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Resa
		Public Shared ReadOnly Property IDFormatoResa As New LUNA.LunaFieldName("IDFormatoResa")
		Public Shared ReadOnly Property IdFormato As New LUNA.LunaFieldName("IdFormato")
		Public Shared ReadOnly Property IdFormCarta As New LUNA.LunaFieldName("IdFormCarta")
		Public Shared ReadOnly Property PercScarto As New LUNA.LunaFieldName("PercScarto")
		Public Shared ReadOnly Property Resa As New LUNA.LunaFieldName("Resa")
	End Class

End Class