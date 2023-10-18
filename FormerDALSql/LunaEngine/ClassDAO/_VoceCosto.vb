#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 20/02/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_vocicosto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _VoceCosto
	Inherits LUNA.LunaBaseClassEntity
	Implements _IVoceCosto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IVoceCosto.FillFromDataRecord
		IdVoceCosto = myRecord("IdVoceCosto")
		If Not myRecord("AliquotaIva") Is DBNull.Value Then AliquotaIva = myRecord("AliquotaIva")
		If Not myRecord("Codice") Is DBNull.Value Then Codice = myRecord("Codice")
		If Not myRecord("Descrizione") Is DBNull.Value Then Descrizione = myRecord("Descrizione")
		If Not myRecord("idCat") Is DBNull.Value Then idCat = myRecord("idCat")
		IdCosto = myRecord("IdCosto")
		If Not myRecord("IdMovMagaz") Is DBNull.Value Then IdMovMagaz = myRecord("IdMovMagaz")
		If Not myRecord("PrezzoUnit") Is DBNull.Value Then PrezzoUnit = myRecord("PrezzoUnit")
		If Not myRecord("Qta") Is DBNull.Value Then Qta = myRecord("Qta")
		If Not myRecord("TipoCessionePrestazione") Is DBNull.Value Then TipoCessionePrestazione = myRecord("TipoCessionePrestazione")
		If Not myRecord("Totale") Is DBNull.Value Then Totale = myRecord("Totale")
		If Not myRecord("Um") Is DBNull.Value Then Um = myRecord("Um")

		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of VoceCosto)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(VociCostoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of VoceCosto))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdVoceCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property AliquotaIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property idCat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property IdCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property IdMovMagaz As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property PrezzoUnit As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property Qta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property TipoCessionePrestazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property Totale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property Um As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdVoceCosto = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.AliquotaIva = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.idCat = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.IdCosto = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.IdMovMagaz = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.PrezzoUnit = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.Qta = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.TipoCessionePrestazione = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.Totale = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.Um = LUNA.LunaContext.WriteAllFieldEveryTime

	End Sub

	Protected _IdVoceCosto As Integer = 0
	Public Overridable Property IdVoceCosto() As Integer Implements _IVoceCosto.IdVoceCosto
		Get
			Return _IdVoceCosto
		End Get
		Set(ByVal value As Integer)
			If _IdVoceCosto <> value Then
				IsChanged = True
				WhatIsChanged.IdVoceCosto = True
				_IdVoceCosto = value
			End If
		End Set
	End Property

	Protected _AliquotaIva As Integer = 0
	Public Overridable Property AliquotaIva() As Integer Implements _IVoceCosto.AliquotaIva
		Get
			Return _AliquotaIva
		End Get
		Set(ByVal value As Integer)
			If _AliquotaIva <> value Then
				IsChanged = True
				WhatIsChanged.AliquotaIva = True
				_AliquotaIva = value
			End If
		End Set
	End Property

	Protected _Codice As String = ""
	Public Overridable Property Codice() As String Implements _IVoceCosto.Codice
		Get
			Return _Codice
		End Get
		Set(ByVal value As String)
			If _Codice <> value Then
				IsChanged = True
				WhatIsChanged.Codice = True
				_Codice = value
			End If
		End Set
	End Property

	Protected _Descrizione As String = ""
	Public Overridable Property Descrizione() As String Implements _IVoceCosto.Descrizione
		Get
			Return _Descrizione
		End Get
		Set(ByVal value As String)
			If _Descrizione <> value Then
				IsChanged = True
				WhatIsChanged.Descrizione = True
				_Descrizione = value
			End If
		End Set
	End Property

	Protected _idCat As Integer = 0
	Public Overridable Property idCat() As Integer Implements _IVoceCosto.idCat
		Get
			Return _idCat
		End Get
		Set(ByVal value As Integer)
			If _idCat <> value Then
				IsChanged = True
				WhatIsChanged.idCat = True
				_idCat = value
			End If
		End Set
	End Property

	Protected _IdCosto As Integer = 0
	Public Overridable Property IdCosto() As Integer Implements _IVoceCosto.IdCosto
		Get
			Return _IdCosto
		End Get
		Set(ByVal value As Integer)
			If _IdCosto <> value Then
				IsChanged = True
				WhatIsChanged.IdCosto = True
				_IdCosto = value
			End If
		End Set
	End Property

	Protected _IdMovMagaz As Integer = 0
	Public Overridable Property IdMovMagaz() As Integer Implements _IVoceCosto.IdMovMagaz
		Get
			Return _IdMovMagaz
		End Get
		Set(ByVal value As Integer)
			If _IdMovMagaz <> value Then
				IsChanged = True
				WhatIsChanged.IdMovMagaz = True
				_IdMovMagaz = value
			End If
		End Set
	End Property

	Protected _PrezzoUnit As Decimal = 0
	Public Overridable Property PrezzoUnit() As Decimal Implements _IVoceCosto.PrezzoUnit
		Get
			Return _PrezzoUnit
		End Get
		Set(ByVal value As Decimal)
			If _PrezzoUnit <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoUnit = True
				_PrezzoUnit = value
			End If
		End Set
	End Property

	Protected _Qta As Decimal = 0
	Public Overridable Property Qta() As Decimal Implements _IVoceCosto.Qta
		Get
			Return _Qta
		End Get
		Set(ByVal value As Decimal)
			If _Qta <> value Then
				IsChanged = True
				WhatIsChanged.Qta = True
				_Qta = value
			End If
		End Set
	End Property

	Protected _TipoCessionePrestazione As String = ""
	Public Overridable Property TipoCessionePrestazione() As String Implements _IVoceCosto.TipoCessionePrestazione
		Get
			Return _TipoCessionePrestazione
		End Get
		Set(ByVal value As String)
			If _TipoCessionePrestazione <> value Then
				IsChanged = True
				WhatIsChanged.TipoCessionePrestazione = True
				_TipoCessionePrestazione = value
			End If
		End Set
	End Property

	Protected _Totale As Decimal = 0
	Public Overridable Property Totale() As Decimal Implements _IVoceCosto.Totale
		Get
			Return _Totale
		End Get
		Set(ByVal value As Decimal)
			If _Totale <> value Then
				IsChanged = True
				WhatIsChanged.Totale = True
				_Totale = value
			End If
		End Set
	End Property

	Protected _Um As String = ""
	Public Overridable Property Um() As String Implements _IVoceCosto.Um
		Get
			Return _Um
		End Get
		Set(ByVal value As String)
			If _Um <> value Then
				IsChanged = True
				WhatIsChanged.Um = True
				_Um = value
			End If
		End Set
	End Property


#End Region

#Region "Method"
	''' <summary>
	'''This method read an VoceCosto from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As VoceCosto = Manager.Read(Id)
				_IdVoceCosto = int.IdVoceCosto
				_AliquotaIva = int.AliquotaIva
				_Codice = int.Codice
				_Descrizione = int.Descrizione
				_idCat = int.idCat
				_IdCosto = int.IdCosto
				_IdMovMagaz = int.IdMovMagaz
				_PrezzoUnit = int.PrezzoUnit
				_Qta = int.Qta
				_TipoCessionePrestazione = int.TipoCessionePrestazione
				_Totale = int.Totale
				_Um = int.Um
			End Using
			Manager = Nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method Refresh all data in the entity from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Function Refresh() As Integer
		Dim ris As Integer = 0
		If IdVoceCosto Then
			ris = Read(IdVoceCosto)
		End If
		Return ris
	End Function

	''' <summary>
	'''This method save an VoceCosto on DB.
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
		if _Codice.Length > 35 then Ris = False
		if _Descrizione.Length > 1000 then Ris = False
		if _TipoCessionePrestazione.Length > 2 then Ris = False
		if _Um.Length > 10 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_vocicosto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IVoceCosto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdVoceCosto() as integer
	Property AliquotaIva() as integer
	Property Codice() as string
	Property Descrizione() as string
	Property idCat() as integer
	Property IdCosto() as integer
	Property IdMovMagaz() as integer
	Property PrezzoUnit() as decimal
	Property Qta() as decimal
	Property TipoCessionePrestazione() as string
	Property Totale() as decimal
	Property Um() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class VoceCosto
		Public Shared ReadOnly Property IdVoceCosto As New LUNA.LunaFieldName("IdVoceCosto")
		Public Shared ReadOnly Property AliquotaIva As New LUNA.LunaFieldName("AliquotaIva")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property idCat As New LUNA.LunaFieldName("idCat")
		Public Shared ReadOnly Property IdCosto As New LUNA.LunaFieldName("IdCosto")
		Public Shared ReadOnly Property IdMovMagaz As New LUNA.LunaFieldName("IdMovMagaz")
		Public Shared ReadOnly Property PrezzoUnit As New LUNA.LunaFieldName("PrezzoUnit")
		Public Shared ReadOnly Property Qta As New LUNA.LunaFieldName("Qta")
		Public Shared ReadOnly Property TipoCessionePrestazione As New LUNA.LunaFieldName("TipoCessionePrestazione")
		Public Shared ReadOnly Property Totale As New LUNA.LunaFieldName("Totale")
		Public Shared ReadOnly Property Um As New LUNA.LunaFieldName("Um")
	End Class

End Class