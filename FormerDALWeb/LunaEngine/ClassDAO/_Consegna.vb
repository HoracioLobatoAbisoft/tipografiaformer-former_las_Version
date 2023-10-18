#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Consegne
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Consegna
	Inherits LUNA.LunaBaseClassEntity
	Implements _IConsegna
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IConsegna.FillFromDataRecord
		IdConsegna = myRecord("IdConsegna")
		if not myRecord("AlertLevel") is DBNull.Value then AlertLevel = myRecord("AlertLevel")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("Blocco") is DBNull.Value then Blocco = myRecord("Blocco")
		if not myRecord("CodTrack") is DBNull.Value then CodTrack = myRecord("CodTrack")
		if not myRecord("DataEffettiva") is DBNull.Value then DataEffettiva = myRecord("DataEffettiva")
		if not myRecord("DataInserimento") is DBNull.Value then DataInserimento = myRecord("DataInserimento")
		if not myRecord("DataPrevistaOriginale") is DBNull.Value then DataPrevistaOriginale = myRecord("DataPrevistaOriginale")
		if not myRecord("EmailNotificheCorriere") is DBNull.Value then EmailNotificheCorriere = myRecord("EmailNotificheCorriere")
		if not myRecord("Giorno") is DBNull.Value then Giorno = myRecord("Giorno")
		if not myRecord("GuidTransazione") is DBNull.Value then GuidTransazione = myRecord("GuidTransazione")
		if not myRecord("IdConsegnaInt") is DBNull.Value then IdConsegnaInt = myRecord("IdConsegnaInt")
		if not myRecord("IdCorriere") is DBNull.Value then IdCorriere = myRecord("IdCorriere")
		if not myRecord("IdIndirizzo") is DBNull.Value then IdIndirizzo = myRecord("IdIndirizzo")
		if not myRecord("IdPagam") is DBNull.Value then IdPagam = myRecord("IdPagam")
		if not myRecord("IdStatoConsegna") is DBNull.Value then IdStatoConsegna = myRecord("IdStatoConsegna")
		if not myRecord("IdUt") is DBNull.Value then IdUt = myRecord("IdUt")
		if not myRecord("ImportoNetto") is DBNull.Value then ImportoNetto = myRecord("ImportoNetto")
		if not myRecord("NoCartaceo") is DBNull.Value then NoCartaceo = myRecord("NoCartaceo")
		if not myRecord("NumColli") is DBNull.Value then NumColli = myRecord("NumColli")
		if not myRecord("Peso") is DBNull.Value then Peso = myRecord("Peso")
		if not myRecord("TipoDoc") is DBNull.Value then TipoDoc = myRecord("TipoDoc")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Consegna)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ConsegneDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Consegna))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AlertLevel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Blocco As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodTrack As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataEffettiva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataInserimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataPrevistaOriginale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property EmailNotificheCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Giorno As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GuidTransazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdConsegnaInt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdIndirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPagam As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdStatoConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoNetto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoCartaceo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumColli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Peso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoDoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AlertLevel = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Blocco = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodTrack = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataEffettiva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataInserimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataPrevistaOriginale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.EmailNotificheCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Giorno = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GuidTransazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdConsegnaInt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdIndirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPagam = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdStatoConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoNetto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoCartaceo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumColli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Peso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoDoc = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdConsegna as integer  = 0 
	Public Overridable Property IdConsegna() as integer  Implements _IConsegna.IdConsegna
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

	Protected _AlertLevel as integer  = 0 
	Public Overridable Property AlertLevel() as integer  Implements _IConsegna.AlertLevel
		Get
			Return _AlertLevel
		End Get
		Set (byval value as integer)
			If _AlertLevel <> value Then
				IsChanged = True
				WhatIsChanged.AlertLevel = True
				_AlertLevel = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _IConsegna.Annotazioni
		Get
			Return _Annotazioni
		End Get
		Set (byval value as string)
			If _Annotazioni <> value Then
				IsChanged = True
				WhatIsChanged.Annotazioni = True
				_Annotazioni = value
			End If
		End Set
	End property 

	Protected _Blocco as integer  = 0 
	Public Overridable Property Blocco() as integer  Implements _IConsegna.Blocco
		Get
			Return _Blocco
		End Get
		Set (byval value as integer)
			If _Blocco <> value Then
				IsChanged = True
				WhatIsChanged.Blocco = True
				_Blocco = value
			End If
		End Set
	End property 

	Protected _CodTrack as string  = "" 
	Public Overridable Property CodTrack() as string  Implements _IConsegna.CodTrack
		Get
			Return _CodTrack
		End Get
		Set (byval value as string)
			If _CodTrack <> value Then
				IsChanged = True
				WhatIsChanged.CodTrack = True
				_CodTrack = value
			End If
		End Set
	End property 

	Protected _DataEffettiva as DateTime  = Nothing 
	Public Overridable Property DataEffettiva() as DateTime  Implements _IConsegna.DataEffettiva
		Get
			Return _DataEffettiva
		End Get
		Set (byval value as DateTime)
			If _DataEffettiva <> value Then
				IsChanged = True
				WhatIsChanged.DataEffettiva = True
				_DataEffettiva = value
			End If
		End Set
	End property 

	Protected _DataInserimento as DateTime  = Nothing 
	Public Overridable Property DataInserimento() as DateTime  Implements _IConsegna.DataInserimento
		Get
			Return _DataInserimento
		End Get
		Set (byval value as DateTime)
			If _DataInserimento <> value Then
				IsChanged = True
				WhatIsChanged.DataInserimento = True
				_DataInserimento = value
			End If
		End Set
	End property 

	Protected _DataPrevistaOriginale as DateTime  = Nothing 
	Public Overridable Property DataPrevistaOriginale() as DateTime  Implements _IConsegna.DataPrevistaOriginale
		Get
			Return _DataPrevistaOriginale
		End Get
		Set (byval value as DateTime)
			If _DataPrevistaOriginale <> value Then
				IsChanged = True
				WhatIsChanged.DataPrevistaOriginale = True
				_DataPrevistaOriginale = value
			End If
		End Set
	End property 

	Protected _EmailNotificheCorriere as string  = "" 
	Public Overridable Property EmailNotificheCorriere() as string  Implements _IConsegna.EmailNotificheCorriere
		Get
			Return _EmailNotificheCorriere
		End Get
		Set (byval value as string)
			If _EmailNotificheCorriere <> value Then
				IsChanged = True
				WhatIsChanged.EmailNotificheCorriere = True
				_EmailNotificheCorriere = value
			End If
		End Set
	End property 

	Protected _Giorno as DateTime  = Nothing 
	Public Overridable Property Giorno() as DateTime  Implements _IConsegna.Giorno
		Get
			Return _Giorno
		End Get
		Set (byval value as DateTime)
			If _Giorno <> value Then
				IsChanged = True
				WhatIsChanged.Giorno = True
				_Giorno = value
			End If
		End Set
	End property 

	Protected _GuidTransazione as string  = "" 
	Public Overridable Property GuidTransazione() as string  Implements _IConsegna.GuidTransazione
		Get
			Return _GuidTransazione
		End Get
		Set (byval value as string)
			If _GuidTransazione <> value Then
				IsChanged = True
				WhatIsChanged.GuidTransazione = True
				_GuidTransazione = value
			End If
		End Set
	End property 

	Protected _IdConsegnaInt as integer  = 0 
	Public Overridable Property IdConsegnaInt() as integer  Implements _IConsegna.IdConsegnaInt
		Get
			Return _IdConsegnaInt
		End Get
		Set (byval value as integer)
			If _IdConsegnaInt <> value Then
				IsChanged = True
				WhatIsChanged.IdConsegnaInt = True
				_IdConsegnaInt = value
			End If
		End Set
	End property 

	Protected _IdCorriere as integer  = 0 
	Public Overridable Property IdCorriere() as integer  Implements _IConsegna.IdCorriere
		Get
			Return _IdCorriere
		End Get
		Set (byval value as integer)
			If _IdCorriere <> value Then
				IsChanged = True
				WhatIsChanged.IdCorriere = True
				_IdCorriere = value
			End If
		End Set
	End property 

	Protected _IdIndirizzo as integer  = 0 
	Public Overridable Property IdIndirizzo() as integer  Implements _IConsegna.IdIndirizzo
		Get
			Return _IdIndirizzo
		End Get
		Set (byval value as integer)
			If _IdIndirizzo <> value Then
				IsChanged = True
				WhatIsChanged.IdIndirizzo = True
				_IdIndirizzo = value
			End If
		End Set
	End property 

	Protected _IdPagam as integer  = 0 
	Public Overridable Property IdPagam() as integer  Implements _IConsegna.IdPagam
		Get
			Return _IdPagam
		End Get
		Set (byval value as integer)
			If _IdPagam <> value Then
				IsChanged = True
				WhatIsChanged.IdPagam = True
				_IdPagam = value
			End If
		End Set
	End property 

	Protected _IdStatoConsegna as integer  = 0 
	Public Overridable Property IdStatoConsegna() as integer  Implements _IConsegna.IdStatoConsegna
		Get
			Return _IdStatoConsegna
		End Get
		Set (byval value as integer)
			If _IdStatoConsegna <> value Then
				IsChanged = True
				WhatIsChanged.IdStatoConsegna = True
				_IdStatoConsegna = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IConsegna.IdUt
		Get
			Return _IdUt
		End Get
		Set (byval value as integer)
			If _IdUt <> value Then
				IsChanged = True
				WhatIsChanged.IdUt = True
				_IdUt = value
			End If
		End Set
	End property 

	Protected _ImportoNetto as decimal  = 0 
	Public Overridable Property ImportoNetto() as decimal  Implements _IConsegna.ImportoNetto
		Get
			Return _ImportoNetto
		End Get
		Set (byval value as decimal)
			If _ImportoNetto <> value Then
				IsChanged = True
				WhatIsChanged.ImportoNetto = True
				_ImportoNetto = value
			End If
		End Set
	End property 

	Protected _NoCartaceo as integer  = 0 
	Public Overridable Property NoCartaceo() as integer  Implements _IConsegna.NoCartaceo
		Get
			Return _NoCartaceo
		End Get
		Set (byval value as integer)
			If _NoCartaceo <> value Then
				IsChanged = True
				WhatIsChanged.NoCartaceo = True
				_NoCartaceo = value
			End If
		End Set
	End property 

	Protected _NumColli as integer  = 0 
	Public Overridable Property NumColli() as integer  Implements _IConsegna.NumColli
		Get
			Return _NumColli
		End Get
		Set (byval value as integer)
			If _NumColli <> value Then
				IsChanged = True
				WhatIsChanged.NumColli = True
				_NumColli = value
			End If
		End Set
	End property 

	Protected _Peso as integer  = 0 
	Public Overridable Property Peso() as integer  Implements _IConsegna.Peso
		Get
			Return _Peso
		End Get
		Set (byval value as integer)
			If _Peso <> value Then
				IsChanged = True
				WhatIsChanged.Peso = True
				_Peso = value
			End If
		End Set
	End property 

	Protected _TipoDoc as integer  = 0 
	Public Overridable Property TipoDoc() as integer  Implements _IConsegna.TipoDoc
		Get
			Return _TipoDoc
		End Get
		Set (byval value as integer)
			If _TipoDoc <> value Then
				IsChanged = True
				WhatIsChanged.TipoDoc = True
				_TipoDoc = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Consegna from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Consegna = Manager.Read(Id)
				_IdConsegna = int.IdConsegna
				_AlertLevel = int.AlertLevel
				_Annotazioni = int.Annotazioni
				_Blocco = int.Blocco
				_CodTrack = int.CodTrack
				_DataEffettiva = int.DataEffettiva
				_DataInserimento = int.DataInserimento
				_DataPrevistaOriginale = int.DataPrevistaOriginale
				_EmailNotificheCorriere = int.EmailNotificheCorriere
				_Giorno = int.Giorno
				_GuidTransazione = int.GuidTransazione
				_IdConsegnaInt = int.IdConsegnaInt
				_IdCorriere = int.IdCorriere
				_IdIndirizzo = int.IdIndirizzo
				_IdPagam = int.IdPagam
				_IdStatoConsegna = int.IdStatoConsegna
				_IdUt = int.IdUt
				_ImportoNetto = int.ImportoNetto
				_NoCartaceo = int.NoCartaceo
				_NumColli = int.NumColli
				_Peso = int.Peso
				_TipoDoc = int.TipoDoc
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Consegna on DB.
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
		if _Annotazioni.Length > 255 then Ris = False
		if _CodTrack.Length > 50 then Ris = False
		if _EmailNotificheCorriere.Length > 255 then Ris = False
		if _GuidTransazione.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Consegne
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IConsegna

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdConsegna() as integer
	Property AlertLevel() as integer
	Property Annotazioni() as string
	Property Blocco() as integer
	Property CodTrack() as string
	Property DataEffettiva() as DateTime
	Property DataInserimento() as DateTime
	Property DataPrevistaOriginale() as DateTime
	Property EmailNotificheCorriere() as string
	Property Giorno() as DateTime
	Property GuidTransazione() as string
	Property IdConsegnaInt() as integer
	Property IdCorriere() as integer
	Property IdIndirizzo() as integer
	Property IdPagam() as integer
	Property IdStatoConsegna() as integer
	Property IdUt() as integer
	Property ImportoNetto() as decimal
	Property NoCartaceo() as integer
	Property NumColli() as integer
	Property Peso() as integer
	Property TipoDoc() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Consegna
		Public Shared ReadOnly Property IdConsegna As New LUNA.LunaFieldName("IdConsegna")
		Public Shared ReadOnly Property AlertLevel As New LUNA.LunaFieldName("AlertLevel")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property Blocco As New LUNA.LunaFieldName("Blocco")
		Public Shared ReadOnly Property CodTrack As New LUNA.LunaFieldName("CodTrack")
		Public Shared ReadOnly Property DataEffettiva As New LUNA.LunaFieldName("DataEffettiva")
		Public Shared ReadOnly Property DataInserimento As New LUNA.LunaFieldName("DataInserimento")
		Public Shared ReadOnly Property DataPrevistaOriginale As New LUNA.LunaFieldName("DataPrevistaOriginale")
		Public Shared ReadOnly Property EmailNotificheCorriere As New LUNA.LunaFieldName("EmailNotificheCorriere")
		Public Shared ReadOnly Property Giorno As New LUNA.LunaFieldName("Giorno")
		Public Shared ReadOnly Property GuidTransazione As New LUNA.LunaFieldName("GuidTransazione")
		Public Shared ReadOnly Property IdConsegnaInt As New LUNA.LunaFieldName("IdConsegnaInt")
		Public Shared ReadOnly Property IdCorriere As New LUNA.LunaFieldName("IdCorriere")
		Public Shared ReadOnly Property IdIndirizzo As New LUNA.LunaFieldName("IdIndirizzo")
		Public Shared ReadOnly Property IdPagam As New LUNA.LunaFieldName("IdPagam")
		Public Shared ReadOnly Property IdStatoConsegna As New LUNA.LunaFieldName("IdStatoConsegna")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property ImportoNetto As New LUNA.LunaFieldName("ImportoNetto")
		Public Shared ReadOnly Property NoCartaceo As New LUNA.LunaFieldName("NoCartaceo")
		Public Shared ReadOnly Property NumColli As New LUNA.LunaFieldName("NumColli")
		Public Shared ReadOnly Property Peso As New LUNA.LunaFieldName("Peso")
		Public Shared ReadOnly Property TipoDoc As New LUNA.LunaFieldName("TipoDoc")
	End Class

End Class