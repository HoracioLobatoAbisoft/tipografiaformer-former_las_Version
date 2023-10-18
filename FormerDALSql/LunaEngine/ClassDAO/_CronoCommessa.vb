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
'''DAO Class for table T_commessecrono
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CronoCommessa
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICronoCommessa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICronoCommessa.FillFromDataRecord
		IdCrono = myRecord("IdCrono")
		if not myRecord("DataCronoFine") is DBNull.Value then DataCronoFine = myRecord("DataCronoFine")
		if not myRecord("DataCronoInizio") is DBNull.Value then DataCronoInizio = myRecord("DataCronoInizio")
		if not myRecord("IdCom") is DBNull.Value then IdCom = myRecord("IdCom")
		if not myRecord("IdOperatore") is DBNull.Value then IdOperatore = myRecord("IdOperatore")
		if not myRecord("IdStato") is DBNull.Value then IdStato = myRecord("IdStato")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CronoCommessa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CronoCommesseDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CronoCommessa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCrono As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataCronoFine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataCronoInizio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOperatore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdStato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCrono = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataCronoFine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataCronoInizio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOperatore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdStato = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCrono as integer  = 0 
	Public Overridable Property IdCrono() as integer  Implements _ICronoCommessa.IdCrono
		Get
			Return _IdCrono
		End Get
		Set (byval value as integer)
			If _IdCrono <> value Then
				IsChanged = True
				WhatIsChanged.IdCrono = True
				_IdCrono = value
			End If
		End Set
	End property 

	Protected _DataCronoFine as DateTime  = Nothing 
	Public Overridable Property DataCronoFine() as DateTime  Implements _ICronoCommessa.DataCronoFine
		Get
			Return _DataCronoFine
		End Get
		Set (byval value as DateTime)
			If _DataCronoFine <> value Then
				IsChanged = True
				WhatIsChanged.DataCronoFine = True
				_DataCronoFine = value
			End If
		End Set
	End property 

	Protected _DataCronoInizio as DateTime  = Nothing 
	Public Overridable Property DataCronoInizio() as DateTime  Implements _ICronoCommessa.DataCronoInizio
		Get
			Return _DataCronoInizio
		End Get
		Set (byval value as DateTime)
			If _DataCronoInizio <> value Then
				IsChanged = True
				WhatIsChanged.DataCronoInizio = True
				_DataCronoInizio = value
			End If
		End Set
	End property 

	Protected _IdCom as integer  = 0 
	Public Overridable Property IdCom() as integer  Implements _ICronoCommessa.IdCom
		Get
			Return _IdCom
		End Get
		Set (byval value as integer)
			If _IdCom <> value Then
				IsChanged = True
				WhatIsChanged.IdCom = True
				_IdCom = value
			End If
		End Set
	End property 

	Protected _IdOperatore as integer  = 0 
	Public Overridable Property IdOperatore() as integer  Implements _ICronoCommessa.IdOperatore
		Get
			Return _IdOperatore
		End Get
		Set (byval value as integer)
			If _IdOperatore <> value Then
				IsChanged = True
				WhatIsChanged.IdOperatore = True
				_IdOperatore = value
			End If
		End Set
	End property 

	Protected _IdStato as integer  = 0 
	Public Overridable Property IdStato() as integer  Implements _ICronoCommessa.IdStato
		Get
			Return _IdStato
		End Get
		Set (byval value as integer)
			If _IdStato <> value Then
				IsChanged = True
				WhatIsChanged.IdStato = True
				_IdStato = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CronoCommessa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CronoCommessa = Manager.Read(Id)
				_IdCrono = int.IdCrono
				_DataCronoFine = int.DataCronoFine
				_DataCronoInizio = int.DataCronoInizio
				_IdCom = int.IdCom
				_IdOperatore = int.IdOperatore
				_IdStato = int.IdStato
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CronoCommessa on DB.
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
'''Interface for table T_commessecrono
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICronoCommessa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCrono() as integer
	Property DataCronoFine() as DateTime
	Property DataCronoInizio() as DateTime
	Property IdCom() as integer
	Property IdOperatore() as integer
	Property IdStato() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CronoCommessa
		Public Shared ReadOnly Property IdCrono As New LUNA.LunaFieldName("IdCrono")
		Public Shared ReadOnly Property DataCronoFine As New LUNA.LunaFieldName("DataCronoFine")
		Public Shared ReadOnly Property DataCronoInizio As New LUNA.LunaFieldName("DataCronoInizio")
		Public Shared ReadOnly Property IdCom As New LUNA.LunaFieldName("IdCom")
		Public Shared ReadOnly Property IdOperatore As New LUNA.LunaFieldName("IdOperatore")
		Public Shared ReadOnly Property IdStato As New LUNA.LunaFieldName("IdStato")
	End Class

End Class