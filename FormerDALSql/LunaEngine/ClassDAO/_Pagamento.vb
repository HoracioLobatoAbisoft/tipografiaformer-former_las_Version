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
'''DAO Class for table T_pagamenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Pagamento
	Inherits LUNA.LunaBaseClassEntity
	Implements _IPagamento
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IPagamento.FillFromDataRecord
		IdPag = myRecord("IdPag")
		if not myRecord("DataPag") is DBNull.Value then DataPag = myRecord("DataPag")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("IdConsegna") is DBNull.Value then IdConsegna = myRecord("IdConsegna")
		if not myRecord("IdFat") is DBNull.Value then IdFat = myRecord("IdFat")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("IdTipoPagamento") is DBNull.Value then IdTipoPagamento = myRecord("IdTipoPagamento")
		if not myRecord("Importo") is DBNull.Value then Importo = myRecord("Importo")
		if not myRecord("NotePag") is DBNull.Value then NotePag = myRecord("NotePag")
		if not myRecord("Tipo") is DBNull.Value then Tipo = myRecord("Tipo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Pagamento)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(PagamentiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Pagamento))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdPag As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataPag As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoPagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Importo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NotePag As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdPag = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataPag = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoPagamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Importo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NotePag = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdPag as integer  = 0 
	Public Overridable Property IdPag() as integer  Implements _IPagamento.IdPag
		Get
			Return _IdPag
		End Get
		Set (byval value as integer)
			If _IdPag <> value Then
				IsChanged = True
				WhatIsChanged.IdPag = True
				_IdPag = value
			End If
		End Set
	End property 

	Protected _DataPag as DateTime  = Nothing 
	Public Overridable Property DataPag() as DateTime  Implements _IPagamento.DataPag
		Get
			Return _DataPag
		End Get
		Set (byval value as DateTime)
			If _DataPag <> value Then
				IsChanged = True
				WhatIsChanged.DataPag = True
				_DataPag = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IPagamento.Descrizione
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

	Protected _IdConsegna as integer  = 0 
	Public Overridable Property IdConsegna() as integer  Implements _IPagamento.IdConsegna
		Get
			Return _IdConsegna
		End Get
		Set (byval value as integer)
			If _IdConsegna <> value Then
				IsChanged = True
				WhatIsChanged.IdConsegna = True
				_IdConsegna = value
			End If
		End Set
	End property 

	Protected _IdFat as integer  = 0 
	Public Overridable Property IdFat() as integer  Implements _IPagamento.IdFat
		Get
			Return _IdFat
		End Get
		Set (byval value as integer)
			If _IdFat <> value Then
				IsChanged = True
				WhatIsChanged.IdFat = True
				_IdFat = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IPagamento.IdRub
		Get
			Return _IdRub
		End Get
		Set (byval value as integer)
			If _IdRub <> value Then
				IsChanged = True
				WhatIsChanged.IdRub = True
				_IdRub = value
			End If
		End Set
	End property 

	Protected _IdTipoPagamento as integer  = 0 
	Public Overridable Property IdTipoPagamento() as integer  Implements _IPagamento.IdTipoPagamento
		Get
			Return _IdTipoPagamento
		End Get
		Set (byval value as integer)
			If _IdTipoPagamento <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoPagamento = True
				_IdTipoPagamento = value
			End If
		End Set
	End property 

	Protected _Importo as decimal  = 0 
	Public Overridable Property Importo() as decimal  Implements _IPagamento.Importo
		Get
			Return _Importo
		End Get
		Set (byval value as decimal)
			If _Importo <> value Then
				IsChanged = True
				WhatIsChanged.Importo = True
				_Importo = value
			End If
		End Set
	End property 

	Protected _NotePag as string  = "" 
	Public Overridable Property NotePag() as string  Implements _IPagamento.NotePag
		Get
			Return _NotePag
		End Get
		Set (byval value as string)
			If _NotePag <> value Then
				IsChanged = True
				WhatIsChanged.NotePag = True
				_NotePag = value
			End If
		End Set
	End property 

	Protected _Tipo as integer  = 0 
	Public Overridable Property Tipo() as integer  Implements _IPagamento.Tipo
		Get
			Return _Tipo
		End Get
		Set (byval value as integer)
			If _Tipo <> value Then
				IsChanged = True
				WhatIsChanged.Tipo = True
				_Tipo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Pagamento from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Pagamento = Manager.Read(Id)
				_IdPag = int.IdPag
				_DataPag = int.DataPag
				_Descrizione = int.Descrizione
				_IdConsegna = int.IdConsegna
				_IdFat = int.IdFat
				_IdRub = int.IdRub
				_IdTipoPagamento = int.IdTipoPagamento
				_Importo = int.Importo
				_NotePag = int.NotePag
				_Tipo = int.Tipo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Pagamento on DB.
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
		if _NotePag.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_pagamenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IPagamento

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdPag() as integer
	Property DataPag() as DateTime
	Property Descrizione() as string
	Property IdConsegna() as integer
	Property IdFat() as integer
	Property IdRub() as integer
	Property IdTipoPagamento() as integer
	Property Importo() as decimal
	Property NotePag() as string
	Property Tipo() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Pagamento
		Public Shared ReadOnly Property IdPag As New LUNA.LunaFieldName("IdPag")
		Public Shared ReadOnly Property DataPag As New LUNA.LunaFieldName("DataPag")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property IdConsegna As New LUNA.LunaFieldName("IdConsegna")
		Public Shared ReadOnly Property IdFat As New LUNA.LunaFieldName("IdFat")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property IdTipoPagamento As New LUNA.LunaFieldName("IdTipoPagamento")
		Public Shared ReadOnly Property Importo As New LUNA.LunaFieldName("Importo")
		Public Shared ReadOnly Property NotePag As New LUNA.LunaFieldName("NotePag")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
	End Class

End Class