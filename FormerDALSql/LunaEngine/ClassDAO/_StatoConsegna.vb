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
'''DAO Class for table Td_statoconsegna
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _StatoConsegna
	Inherits LUNA.LunaBaseClassEntity
	Implements _IStatoConsegna
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IStatoConsegna.FillFromDataRecord
		IDStato = myRecord("IDStato")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of StatoConsegna)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(StatoConsegneDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of StatoConsegna))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDStato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDStato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDStato as integer  = 0 
	Public Overridable Property IDStato() as integer  Implements _IStatoConsegna.IDStato
		Get
			Return _IDStato
		End Get
		Set (byval value as integer)
			If _IDStato <> value Then
				IsChanged = True
				WhatIsChanged.IDStato = True
				_IDStato = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IStatoConsegna.Descrizione
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an StatoConsegna from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As StatoConsegna = Manager.Read(Id)
				_IDStato = int.IDStato
				_Descrizione = int.Descrizione
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an StatoConsegna on DB.
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
		if _Descrizione.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_statoconsegna
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IStatoConsegna

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDStato() as integer
	Property Descrizione() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class StatoConsegna
		Public Shared ReadOnly Property IDStato As New LUNA.LunaFieldName("IDStato")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
	End Class

End Class