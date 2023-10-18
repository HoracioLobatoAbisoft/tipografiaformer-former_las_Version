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
'''DAO Class for table T_preventivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Preventivo
	Inherits LUNA.LunaBaseClassEntity
	Implements _IPreventivo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IPreventivo.FillFromDataRecord
		IdPrev = myRecord("IdPrev")
		if not myRecord("Anteprima") is DBNull.Value then Anteprima = myRecord("Anteprima")
		if not myRecord("Carta") is DBNull.Value then Carta = myRecord("Carta")
		if not myRecord("Codice") is DBNull.Value then Codice = myRecord("Codice")
		if not myRecord("DataIns") is DBNull.Value then DataIns = myRecord("DataIns")
		if not myRecord("EmailRif") is DBNull.Value then EmailRif = myRecord("EmailRif")
		if not myRecord("FormatoAperto") is DBNull.Value then FormatoAperto = myRecord("FormatoAperto")
		if not myRecord("FormatoChiuso") is DBNull.Value then FormatoChiuso = myRecord("FormatoChiuso")
		if not myRecord("IdCorr") is DBNull.Value then IdCorr = myRecord("IdCorr")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("Iva") is DBNull.Value then Iva = myRecord("Iva")
		if not myRecord("Lavorazioni") is DBNull.Value then Lavorazioni = myRecord("Lavorazioni")
		if not myRecord("Numero") is DBNull.Value then Numero = myRecord("Numero")
		if not myRecord("Pagine") is DBNull.Value then Pagine = myRecord("Pagine")
		if not myRecord("PrezzoNetto") is DBNull.Value then PrezzoNetto = myRecord("PrezzoNetto")
		if not myRecord("Qta") is DBNull.Value then Qta = myRecord("Qta")
		if not myRecord("Risposto") is DBNull.Value then Risposto = myRecord("Risposto")
		if not myRecord("Sconto") is DBNull.Value then Sconto = myRecord("Sconto")
		if not myRecord("Stampa") is DBNull.Value then Stampa = myRecord("Stampa")
		if not myRecord("TestoRisp") is DBNull.Value then TestoRisp = myRecord("TestoRisp")
		if not myRecord("TipoLavoro") is DBNull.Value then TipoLavoro = myRecord("TipoLavoro")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Preventivo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(PreventiviDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Preventivo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Anteprima As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Carta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property EmailRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FormatoAperto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FormatoChiuso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorr As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Iva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Lavorazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Numero As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Pagine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoNetto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Risposto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sconto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stampa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TestoRisp As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoLavoro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Anteprima = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Carta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.EmailRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FormatoAperto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FormatoChiuso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorr = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Iva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Lavorazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Numero = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Pagine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoNetto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Risposto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sconto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stampa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TestoRisp = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoLavoro = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdPrev as integer  = 0 
	Public Overridable Property IdPrev() as integer  Implements _IPreventivo.IdPrev
		Get
			Return _IdPrev
		End Get
		Set (byval value as integer)
			If _IdPrev <> value Then
				IsChanged = True
				WhatIsChanged.IdPrev = True
				_IdPrev = value
			End If
		End Set
	End property 

	Protected _Anteprima as string  = "" 
	Public Overridable Property Anteprima() as string  Implements _IPreventivo.Anteprima
		Get
			Return _Anteprima
		End Get
		Set (byval value as string)
			If _Anteprima <> value Then
				IsChanged = True
				WhatIsChanged.Anteprima = True
				_Anteprima = value
			End If
		End Set
	End property 

	Protected _Carta as string  = "" 
	Public Overridable Property Carta() as string  Implements _IPreventivo.Carta
		Get
			Return _Carta
		End Get
		Set (byval value as string)
			If _Carta <> value Then
				IsChanged = True
				WhatIsChanged.Carta = True
				_Carta = value
			End If
		End Set
	End property 

	Protected _Codice as string  = "" 
	Public Overridable Property Codice() as string  Implements _IPreventivo.Codice
		Get
			Return _Codice
		End Get
		Set (byval value as string)
			If _Codice <> value Then
				IsChanged = True
				WhatIsChanged.Codice = True
				_Codice = value
			End If
		End Set
	End property 

	Protected _DataIns as DateTime  = Nothing 
	Public Overridable Property DataIns() as DateTime  Implements _IPreventivo.DataIns
		Get
			Return _DataIns
		End Get
		Set (byval value as DateTime)
			If _DataIns <> value Then
				IsChanged = True
				WhatIsChanged.DataIns = True
				_DataIns = value
			End If
		End Set
	End property 

	Protected _EmailRif as string  = "" 
	Public Overridable Property EmailRif() as string  Implements _IPreventivo.EmailRif
		Get
			Return _EmailRif
		End Get
		Set (byval value as string)
			If _EmailRif <> value Then
				IsChanged = True
				WhatIsChanged.EmailRif = True
				_EmailRif = value
			End If
		End Set
	End property 

	Protected _FormatoAperto as string  = "" 
	Public Overridable Property FormatoAperto() as string  Implements _IPreventivo.FormatoAperto
		Get
			Return _FormatoAperto
		End Get
		Set (byval value as string)
			If _FormatoAperto <> value Then
				IsChanged = True
				WhatIsChanged.FormatoAperto = True
				_FormatoAperto = value
			End If
		End Set
	End property 

	Protected _FormatoChiuso as string  = "" 
	Public Overridable Property FormatoChiuso() as string  Implements _IPreventivo.FormatoChiuso
		Get
			Return _FormatoChiuso
		End Get
		Set (byval value as string)
			If _FormatoChiuso <> value Then
				IsChanged = True
				WhatIsChanged.FormatoChiuso = True
				_FormatoChiuso = value
			End If
		End Set
	End property 

	Protected _IdCorr as integer  = 0 
	Public Overridable Property IdCorr() as integer  Implements _IPreventivo.IdCorr
		Get
			Return _IdCorr
		End Get
		Set (byval value as integer)
			If _IdCorr <> value Then
				IsChanged = True
				WhatIsChanged.IdCorr = True
				_IdCorr = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IPreventivo.IdListinoBase
		Get
			Return _IdListinoBase
		End Get
		Set (byval value as integer)
			If _IdListinoBase <> value Then
				IsChanged = True
				WhatIsChanged.IdListinoBase = True
				_IdListinoBase = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IPreventivo.IdRub
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

	Protected _Iva as Single  = 0 
	Public Overridable Property Iva() as Single  Implements _IPreventivo.Iva
		Get
			Return _Iva
		End Get
		Set (byval value as Single)
			If _Iva <> value Then
				IsChanged = True
				WhatIsChanged.Iva = True
				_Iva = value
			End If
		End Set
	End property 

	Protected _Lavorazioni as string  = "" 
	Public Overridable Property Lavorazioni() as string  Implements _IPreventivo.Lavorazioni
		Get
			Return _Lavorazioni
		End Get
		Set (byval value as string)
			If _Lavorazioni <> value Then
				IsChanged = True
				WhatIsChanged.Lavorazioni = True
				_Lavorazioni = value
			End If
		End Set
	End property 

	Protected _Numero as string  = "" 
	Public Overridable Property Numero() as string  Implements _IPreventivo.Numero
		Get
			Return _Numero
		End Get
		Set (byval value as string)
			If _Numero <> value Then
				IsChanged = True
				WhatIsChanged.Numero = True
				_Numero = value
			End If
		End Set
	End property 

	Protected _Pagine as string  = "" 
	Public Overridable Property Pagine() as string  Implements _IPreventivo.Pagine
		Get
			Return _Pagine
		End Get
		Set (byval value as string)
			If _Pagine <> value Then
				IsChanged = True
				WhatIsChanged.Pagine = True
				_Pagine = value
			End If
		End Set
	End property 

	Protected _PrezzoNetto as Single  = 0 
	Public Overridable Property PrezzoNetto() as Single  Implements _IPreventivo.PrezzoNetto
		Get
			Return _PrezzoNetto
		End Get
		Set (byval value as Single)
			If _PrezzoNetto <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoNetto = True
				_PrezzoNetto = value
			End If
		End Set
	End property 

	Protected _Qta as string  = "" 
	Public Overridable Property Qta() as string  Implements _IPreventivo.Qta
		Get
			Return _Qta
		End Get
		Set (byval value as string)
			If _Qta <> value Then
				IsChanged = True
				WhatIsChanged.Qta = True
				_Qta = value
			End If
		End Set
	End property 

	Protected _Risposto as integer  = 0 
	Public Overridable Property Risposto() as integer  Implements _IPreventivo.Risposto
		Get
			Return _Risposto
		End Get
		Set (byval value as integer)
			If _Risposto <> value Then
				IsChanged = True
				WhatIsChanged.Risposto = True
				_Risposto = value
			End If
		End Set
	End property 

	Protected _Sconto as Single  = 0 
	Public Overridable Property Sconto() as Single  Implements _IPreventivo.Sconto
		Get
			Return _Sconto
		End Get
		Set (byval value as Single)
			If _Sconto <> value Then
				IsChanged = True
				WhatIsChanged.Sconto = True
				_Sconto = value
			End If
		End Set
	End property 

	Protected _Stampa as string  = "" 
	Public Overridable Property Stampa() as string  Implements _IPreventivo.Stampa
		Get
			Return _Stampa
		End Get
		Set (byval value as string)
			If _Stampa <> value Then
				IsChanged = True
				WhatIsChanged.Stampa = True
				_Stampa = value
			End If
		End Set
	End property 

	Protected _TestoRisp as string  = "" 
	Public Overridable Property TestoRisp() as string  Implements _IPreventivo.TestoRisp
		Get
			Return _TestoRisp
		End Get
		Set (byval value as string)
			If _TestoRisp <> value Then
				IsChanged = True
				WhatIsChanged.TestoRisp = True
				_TestoRisp = value
			End If
		End Set
	End property 

	Protected _TipoLavoro as string  = "" 
	Public Overridable Property TipoLavoro() as string  Implements _IPreventivo.TipoLavoro
		Get
			Return _TipoLavoro
		End Get
		Set (byval value as string)
			If _TipoLavoro <> value Then
				IsChanged = True
				WhatIsChanged.TipoLavoro = True
				_TipoLavoro = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Preventivo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Preventivo = Manager.Read(Id)
				_IdPrev = int.IdPrev
				_Anteprima = int.Anteprima
				_Carta = int.Carta
				_Codice = int.Codice
				_DataIns = int.DataIns
				_EmailRif = int.EmailRif
				_FormatoAperto = int.FormatoAperto
				_FormatoChiuso = int.FormatoChiuso
				_IdCorr = int.IdCorr
				_IdListinoBase = int.IdListinoBase
				_IdRub = int.IdRub
				_Iva = int.Iva
				_Lavorazioni = int.Lavorazioni
				_Numero = int.Numero
				_Pagine = int.Pagine
				_PrezzoNetto = int.PrezzoNetto
				_Qta = int.Qta
				_Risposto = int.Risposto
				_Sconto = int.Sconto
				_Stampa = int.Stampa
				_TestoRisp = int.TestoRisp
				_TipoLavoro = int.TipoLavoro
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Preventivo on DB.
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
		if _Anteprima.Length > 255 then Ris = False
		if _Carta.Length > 255 then Ris = False
		if _Codice.Length > 255 then Ris = False
		if _EmailRif.Length > 50 then Ris = False
		if _FormatoAperto.Length > 255 then Ris = False
		if _FormatoChiuso.Length > 255 then Ris = False
		if _Lavorazioni.Length > 255 then Ris = False
		if _Numero.Length > 30 then Ris = False
		if _Pagine.Length > 255 then Ris = False
		if _Qta.Length > 255 then Ris = False
		if _Stampa.Length > 255 then Ris = False
		if _TestoRisp.Length > 1073741823 then Ris = False
		if _TipoLavoro.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_preventivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IPreventivo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdPrev() as integer
	Property Anteprima() as string
	Property Carta() as string
	Property Codice() as string
	Property DataIns() as DateTime
	Property EmailRif() as string
	Property FormatoAperto() as string
	Property FormatoChiuso() as string
	Property IdCorr() as integer
	Property IdListinoBase() as integer
	Property IdRub() as integer
	Property Iva() as Single
	Property Lavorazioni() as string
	Property Numero() as string
	Property Pagine() as string
	Property PrezzoNetto() as Single
	Property Qta() as string
	Property Risposto() as integer
	Property Sconto() as Single
	Property Stampa() as string
	Property TestoRisp() as string
	Property TipoLavoro() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Preventivo
		Public Shared ReadOnly Property IdPrev As New LUNA.LunaFieldName("IdPrev")
		Public Shared ReadOnly Property Anteprima As New LUNA.LunaFieldName("Anteprima")
		Public Shared ReadOnly Property Carta As New LUNA.LunaFieldName("Carta")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property DataIns As New LUNA.LunaFieldName("DataIns")
		Public Shared ReadOnly Property EmailRif As New LUNA.LunaFieldName("EmailRif")
		Public Shared ReadOnly Property FormatoAperto As New LUNA.LunaFieldName("FormatoAperto")
		Public Shared ReadOnly Property FormatoChiuso As New LUNA.LunaFieldName("FormatoChiuso")
		Public Shared ReadOnly Property IdCorr As New LUNA.LunaFieldName("IdCorr")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property Iva As New LUNA.LunaFieldName("Iva")
		Public Shared ReadOnly Property Lavorazioni As New LUNA.LunaFieldName("Lavorazioni")
		Public Shared ReadOnly Property Numero As New LUNA.LunaFieldName("Numero")
		Public Shared ReadOnly Property Pagine As New LUNA.LunaFieldName("Pagine")
		Public Shared ReadOnly Property PrezzoNetto As New LUNA.LunaFieldName("PrezzoNetto")
		Public Shared ReadOnly Property Qta As New LUNA.LunaFieldName("Qta")
		Public Shared ReadOnly Property Risposto As New LUNA.LunaFieldName("Risposto")
		Public Shared ReadOnly Property Sconto As New LUNA.LunaFieldName("Sconto")
		Public Shared ReadOnly Property Stampa As New LUNA.LunaFieldName("Stampa")
		Public Shared ReadOnly Property TestoRisp As New LUNA.LunaFieldName("TestoRisp")
		Public Shared ReadOnly Property TipoLavoro As New LUNA.LunaFieldName("TipoLavoro")
	End Class

End Class