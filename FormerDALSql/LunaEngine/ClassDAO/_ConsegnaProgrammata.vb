#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/12/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_cons
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ConsegnaProgrammata
	Inherits LUNA.LunaBaseClassEntity
	Implements _IConsegnaProgrammata
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IConsegnaProgrammata.FillFromDataRecord
		IdCons = myRecord("IdCons")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("AssRilIntMitt") is DBNull.Value then AssRilIntMitt = myRecord("AssRilIntMitt")
		if not myRecord("Blocco") is DBNull.Value then Blocco = myRecord("Blocco")
		if not myRecord("CodTrack") is DBNull.Value then CodTrack = myRecord("CodTrack")
		if not myRecord("DataEffettiva") is DBNull.Value then DataEffettiva = myRecord("DataEffettiva")
		if not myRecord("DataPrevistaOriginale") is DBNull.Value then DataPrevistaOriginale = myRecord("DataPrevistaOriginale")
		if not myRecord("DataTrasmissioneCorriere") is DBNull.Value then DataTrasmissioneCorriere = myRecord("DataTrasmissioneCorriere")
		if not myRecord("Eliminato") is DBNull.Value then Eliminato = myRecord("Eliminato")
		if not myRecord("EmailNotificheCorriere") is DBNull.Value then EmailNotificheCorriere = myRecord("EmailNotificheCorriere")
		if not myRecord("ForzaCsvCorriere") is DBNull.Value then ForzaCsvCorriere = myRecord("ForzaCsvCorriere")
		if not myRecord("Giorno") is DBNull.Value then Giorno = myRecord("Giorno")
		if not myRecord("GiornoPartenza") is DBNull.Value then GiornoPartenza = myRecord("GiornoPartenza")
		if not myRecord("IdAziendaForzata") is DBNull.Value then IdAziendaForzata = myRecord("IdAziendaForzata")
		if not myRecord("IdConsOnline") is DBNull.Value then IdConsOnline = myRecord("IdConsOnline")
		if not myRecord("IdCorr") is DBNull.Value then IdCorr = myRecord("IdCorr")
		if not myRecord("IdIndirizzo") is DBNull.Value then IdIndirizzo = myRecord("IdIndirizzo")
		if not myRecord("IdOperatore") is DBNull.Value then IdOperatore = myRecord("IdOperatore")
		if not myRecord("IdPagam") is DBNull.Value then IdPagam = myRecord("IdPagam")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("IdStatoConsegna") is DBNull.Value then IdStatoConsegna = myRecord("IdStatoConsegna")
		if not myRecord("ImportoNetto") is DBNull.Value then ImportoNetto = myRecord("ImportoNetto")
		if not myRecord("LastUpdate") is DBNull.Value then LastUpdate = myRecord("LastUpdate")
		if not myRecord("MatPom") is DBNull.Value then MatPom = myRecord("MatPom")
		if not myRecord("NoCartaceo") is DBNull.Value then NoCartaceo = myRecord("NoCartaceo")
		if not myRecord("NoRegistrazioneGLS") is DBNull.Value then NoRegistrazioneGLS = myRecord("NoRegistrazioneGLS")
		if not myRecord("NumColli") is DBNull.Value then NumColli = myRecord("NumColli")
		if not myRecord("NumeroPrimoColloBartolini") is DBNull.Value then NumeroPrimoColloBartolini = myRecord("NumeroPrimoColloBartolini")
		if not myRecord("Peso") is DBNull.Value then Peso = myRecord("Peso")
		if not myRecord("StampaDocumenti") is DBNull.Value then StampaDocumenti = myRecord("StampaDocumenti")
		if not myRecord("TipoDoc") is DBNull.Value then TipoDoc = myRecord("TipoDoc")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ConsegnaProgrammata)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ConsegneProgrammateDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ConsegnaProgrammata))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCons As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AssRilIntMitt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Blocco As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodTrack As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataEffettiva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataPrevistaOriginale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataTrasmissioneCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Eliminato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property EmailNotificheCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ForzaCsvCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Giorno As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GiornoPartenza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdAziendaForzata As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdConsOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorr As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdIndirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOperatore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPagam As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdStatoConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoNetto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LastUpdate As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MatPom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoCartaceo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoRegistrazioneGLS As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumColli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumeroPrimoColloBartolini As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Peso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StampaDocumenti As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoDoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCons = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AssRilIntMitt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Blocco = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodTrack = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataEffettiva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataPrevistaOriginale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataTrasmissioneCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Eliminato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.EmailNotificheCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ForzaCsvCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Giorno = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GiornoPartenza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdAziendaForzata = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdConsOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorr = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdIndirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOperatore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPagam = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdStatoConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoNetto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LastUpdate = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MatPom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoCartaceo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoRegistrazioneGLS = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumColli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumeroPrimoColloBartolini = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Peso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StampaDocumenti = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoDoc = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCons as integer  = 0 
	Public Overridable Property IdCons() as integer  Implements _IConsegnaProgrammata.IdCons
		Get
			Return _IdCons
		End Get
		Set (byval value as integer)
			If _IdCons <> value Then
				IsChanged = True
				WhatIsChanged.IdCons = True
				_IdCons = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _IConsegnaProgrammata.Annotazioni
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

	Protected _AssRilIntMitt as integer  = 0 
	Public Overridable Property AssRilIntMitt() as integer  Implements _IConsegnaProgrammata.AssRilIntMitt
		Get
			Return _AssRilIntMitt
		End Get
		Set (byval value as integer)
			If _AssRilIntMitt <> value Then
				IsChanged = True
				WhatIsChanged.AssRilIntMitt = True
				_AssRilIntMitt = value
			End If
		End Set
	End property 

	Protected _Blocco as integer  = 0 
	Public Overridable Property Blocco() as integer  Implements _IConsegnaProgrammata.Blocco
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
	Public Overridable Property CodTrack() as string  Implements _IConsegnaProgrammata.CodTrack
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
	Public Overridable Property DataEffettiva() as DateTime  Implements _IConsegnaProgrammata.DataEffettiva
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

	Protected _DataPrevistaOriginale as DateTime  = Nothing 
	Public Overridable Property DataPrevistaOriginale() as DateTime  Implements _IConsegnaProgrammata.DataPrevistaOriginale
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

	Protected _DataTrasmissioneCorriere as DateTime  = Nothing 
	Public Overridable Property DataTrasmissioneCorriere() as DateTime  Implements _IConsegnaProgrammata.DataTrasmissioneCorriere
		Get
			Return _DataTrasmissioneCorriere
		End Get
		Set (byval value as DateTime)
			If _DataTrasmissioneCorriere <> value Then
				IsChanged = True
				WhatIsChanged.DataTrasmissioneCorriere = True
				_DataTrasmissioneCorriere = value
			End If
		End Set
	End property 

	Protected _Eliminato as integer  = 0 
	Public Overridable Property Eliminato() as integer  Implements _IConsegnaProgrammata.Eliminato
		Get
			Return _Eliminato
		End Get
		Set (byval value as integer)
			If _Eliminato <> value Then
				IsChanged = True
				WhatIsChanged.Eliminato = True
				_Eliminato = value
			End If
		End Set
	End property 

	Protected _EmailNotificheCorriere as string  = "" 
	Public Overridable Property EmailNotificheCorriere() as string  Implements _IConsegnaProgrammata.EmailNotificheCorriere
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

	Protected _ForzaCsvCorriere as integer  = 0 
	Public Overridable Property ForzaCsvCorriere() as integer  Implements _IConsegnaProgrammata.ForzaCsvCorriere
		Get
			Return _ForzaCsvCorriere
		End Get
		Set (byval value as integer)
			If _ForzaCsvCorriere <> value Then
				IsChanged = True
				WhatIsChanged.ForzaCsvCorriere = True
				_ForzaCsvCorriere = value
			End If
		End Set
	End property 

	Protected _Giorno as DateTime  = Nothing 
	Public Overridable Property Giorno() as DateTime  Implements _IConsegnaProgrammata.Giorno
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

	Protected _GiornoPartenza as DateTime  = Nothing 
	Public Overridable Property GiornoPartenza() as DateTime  Implements _IConsegnaProgrammata.GiornoPartenza
		Get
			Return _GiornoPartenza
		End Get
		Set (byval value as DateTime)
			If _GiornoPartenza <> value Then
				IsChanged = True
				WhatIsChanged.GiornoPartenza = True
				_GiornoPartenza = value
			End If
		End Set
	End property 

	Protected _IdAziendaForzata as integer  = 0 
	Public Overridable Property IdAziendaForzata() as integer  Implements _IConsegnaProgrammata.IdAziendaForzata
		Get
			Return _IdAziendaForzata
		End Get
		Set (byval value as integer)
			If _IdAziendaForzata <> value Then
				IsChanged = True
				WhatIsChanged.IdAziendaForzata = True
				_IdAziendaForzata = value
			End If
		End Set
	End property 

	Protected _IdConsOnline as integer  = 0 
	Public Overridable Property IdConsOnline() as integer  Implements _IConsegnaProgrammata.IdConsOnline
		Get
			Return _IdConsOnline
		End Get
		Set (byval value as integer)
			If _IdConsOnline <> value Then
				IsChanged = True
				WhatIsChanged.IdConsOnline = True
				_IdConsOnline = value
			End If
		End Set
	End property 

	Protected _IdCorr as integer  = 0 
	Public Overridable Property IdCorr() as integer  Implements _IConsegnaProgrammata.IdCorr
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

	Protected _IdIndirizzo as integer  = 0 
	Public Overridable Property IdIndirizzo() as integer  Implements _IConsegnaProgrammata.IdIndirizzo
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

	Protected _IdOperatore as integer  = 0 
	Public Overridable Property IdOperatore() as integer  Implements _IConsegnaProgrammata.IdOperatore
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

	Protected _IdPagam as integer  = 0 
	Public Overridable Property IdPagam() as integer  Implements _IConsegnaProgrammata.IdPagam
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

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IConsegnaProgrammata.IdRub
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

	Protected _IdStatoConsegna as integer  = 0 
	Public Overridable Property IdStatoConsegna() as integer  Implements _IConsegnaProgrammata.IdStatoConsegna
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

	Protected _ImportoNetto as decimal  = 0 
	Public Overridable Property ImportoNetto() as decimal  Implements _IConsegnaProgrammata.ImportoNetto
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

	Protected _LastUpdate as integer  = 0 
	Public Overridable Property LastUpdate() as integer  Implements _IConsegnaProgrammata.LastUpdate
		Get
			Return _LastUpdate
		End Get
		Set (byval value as integer)
			If _LastUpdate <> value Then
				IsChanged = True
				WhatIsChanged.LastUpdate = True
				_LastUpdate = value
			End If
		End Set
	End property 

	Protected _MatPom as integer  = 0 
	Public Overridable Property MatPom() as integer  Implements _IConsegnaProgrammata.MatPom
		Get
			Return _MatPom
		End Get
		Set (byval value as integer)
			If _MatPom <> value Then
				IsChanged = True
				WhatIsChanged.MatPom = True
				_MatPom = value
			End If
		End Set
	End property 

	Protected _NoCartaceo as integer  = 0 
	Public Overridable Property NoCartaceo() as integer  Implements _IConsegnaProgrammata.NoCartaceo
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

	Protected _NoRegistrazioneGLS as integer  = 0 
	Public Overridable Property NoRegistrazioneGLS() as integer  Implements _IConsegnaProgrammata.NoRegistrazioneGLS
		Get
			Return _NoRegistrazioneGLS
		End Get
		Set (byval value as integer)
			If _NoRegistrazioneGLS <> value Then
				IsChanged = True
				WhatIsChanged.NoRegistrazioneGLS = True
				_NoRegistrazioneGLS = value
			End If
		End Set
	End property 

	Protected _NumColli as integer  = 0 
	Public Overridable Property NumColli() as integer  Implements _IConsegnaProgrammata.NumColli
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

	Protected _NumeroPrimoColloBartolini as string  = "" 
	Public Overridable Property NumeroPrimoColloBartolini() as string  Implements _IConsegnaProgrammata.NumeroPrimoColloBartolini
		Get
			Return _NumeroPrimoColloBartolini
		End Get
		Set (byval value as string)
			If _NumeroPrimoColloBartolini <> value Then
				IsChanged = True
				WhatIsChanged.NumeroPrimoColloBartolini = True
				_NumeroPrimoColloBartolini = value
			End If
		End Set
	End property 

	Protected _Peso as Single  = 0 
	Public Overridable Property Peso() as Single  Implements _IConsegnaProgrammata.Peso
		Get
			Return _Peso
		End Get
		Set (byval value as Single)
			If _Peso <> value Then
				IsChanged = True
				WhatIsChanged.Peso = True
				_Peso = value
			End If
		End Set
	End property 

	Protected _StampaDocumenti as integer  = 0 
	Public Overridable Property StampaDocumenti() as integer  Implements _IConsegnaProgrammata.StampaDocumenti
		Get
			Return _StampaDocumenti
		End Get
		Set (byval value as integer)
			If _StampaDocumenti <> value Then
				IsChanged = True
				WhatIsChanged.StampaDocumenti = True
				_StampaDocumenti = value
			End If
		End Set
	End property 

	Protected _TipoDoc as integer  = 0 
	Public Overridable Property TipoDoc() as integer  Implements _IConsegnaProgrammata.TipoDoc
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
	'''This method read an ConsegnaProgrammata from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ConsegnaProgrammata = Manager.Read(Id)
				_IdCons = int.IdCons
				_Annotazioni = int.Annotazioni
				_AssRilIntMitt = int.AssRilIntMitt
				_Blocco = int.Blocco
				_CodTrack = int.CodTrack
				_DataEffettiva = int.DataEffettiva
				_DataPrevistaOriginale = int.DataPrevistaOriginale
				_DataTrasmissioneCorriere = int.DataTrasmissioneCorriere
				_Eliminato = int.Eliminato
				_EmailNotificheCorriere = int.EmailNotificheCorriere
				_ForzaCsvCorriere = int.ForzaCsvCorriere
				_Giorno = int.Giorno
				_GiornoPartenza = int.GiornoPartenza
				_IdAziendaForzata = int.IdAziendaForzata
				_IdConsOnline = int.IdConsOnline
				_IdCorr = int.IdCorr
				_IdIndirizzo = int.IdIndirizzo
				_IdOperatore = int.IdOperatore
				_IdPagam = int.IdPagam
				_IdRub = int.IdRub
				_IdStatoConsegna = int.IdStatoConsegna
				_ImportoNetto = int.ImportoNetto
				_LastUpdate = int.LastUpdate
				_MatPom = int.MatPom
				_NoCartaceo = int.NoCartaceo
				_NoRegistrazioneGLS = int.NoRegistrazioneGLS
				_NumColli = int.NumColli
				_NumeroPrimoColloBartolini = int.NumeroPrimoColloBartolini
				_Peso = int.Peso
				_StampaDocumenti = int.StampaDocumenti
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
	'''This method save an ConsegnaProgrammata on DB.
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
		if _NumeroPrimoColloBartolini.Length > 20 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_cons
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IConsegnaProgrammata

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCons() as integer
	Property Annotazioni() as string
	Property AssRilIntMitt() as integer
	Property Blocco() as integer
	Property CodTrack() as string
	Property DataEffettiva() as DateTime
	Property DataPrevistaOriginale() as DateTime
	Property DataTrasmissioneCorriere() as DateTime
	Property Eliminato() as integer
	Property EmailNotificheCorriere() as string
	Property ForzaCsvCorriere() as integer
	Property Giorno() as DateTime
	Property GiornoPartenza() as DateTime
	Property IdAziendaForzata() as integer
	Property IdConsOnline() as integer
	Property IdCorr() as integer
	Property IdIndirizzo() as integer
	Property IdOperatore() as integer
	Property IdPagam() as integer
	Property IdRub() as integer
	Property IdStatoConsegna() as integer
	Property ImportoNetto() as decimal
	Property LastUpdate() as integer
	Property MatPom() as integer
	Property NoCartaceo() as integer
	Property NoRegistrazioneGLS() as integer
	Property NumColli() as integer
	Property NumeroPrimoColloBartolini() as string
	Property Peso() as Single
	Property StampaDocumenti() as integer
	Property TipoDoc() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ConsegnaProgrammata
		Public Shared ReadOnly Property IdCons As New LUNA.LunaFieldName("IdCons")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property AssRilIntMitt As New LUNA.LunaFieldName("AssRilIntMitt")
		Public Shared ReadOnly Property Blocco As New LUNA.LunaFieldName("Blocco")
		Public Shared ReadOnly Property CodTrack As New LUNA.LunaFieldName("CodTrack")
		Public Shared ReadOnly Property DataEffettiva As New LUNA.LunaFieldName("DataEffettiva")
		Public Shared ReadOnly Property DataPrevistaOriginale As New LUNA.LunaFieldName("DataPrevistaOriginale")
		Public Shared ReadOnly Property DataTrasmissioneCorriere As New LUNA.LunaFieldName("DataTrasmissioneCorriere")
		Public Shared ReadOnly Property Eliminato As New LUNA.LunaFieldName("Eliminato")
		Public Shared ReadOnly Property EmailNotificheCorriere As New LUNA.LunaFieldName("EmailNotificheCorriere")
		Public Shared ReadOnly Property ForzaCsvCorriere As New LUNA.LunaFieldName("ForzaCsvCorriere")
		Public Shared ReadOnly Property Giorno As New LUNA.LunaFieldName("Giorno")
		Public Shared ReadOnly Property GiornoPartenza As New LUNA.LunaFieldName("GiornoPartenza")
		Public Shared ReadOnly Property IdAziendaForzata As New LUNA.LunaFieldName("IdAziendaForzata")
		Public Shared ReadOnly Property IdConsOnline As New LUNA.LunaFieldName("IdConsOnline")
		Public Shared ReadOnly Property IdCorr As New LUNA.LunaFieldName("IdCorr")
		Public Shared ReadOnly Property IdIndirizzo As New LUNA.LunaFieldName("IdIndirizzo")
		Public Shared ReadOnly Property IdOperatore As New LUNA.LunaFieldName("IdOperatore")
		Public Shared ReadOnly Property IdPagam As New LUNA.LunaFieldName("IdPagam")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property IdStatoConsegna As New LUNA.LunaFieldName("IdStatoConsegna")
		Public Shared ReadOnly Property ImportoNetto As New LUNA.LunaFieldName("ImportoNetto")
		Public Shared ReadOnly Property LastUpdate As New LUNA.LunaFieldName("LastUpdate")
		Public Shared ReadOnly Property MatPom As New LUNA.LunaFieldName("MatPom")
		Public Shared ReadOnly Property NoCartaceo As New LUNA.LunaFieldName("NoCartaceo")
		Public Shared ReadOnly Property NoRegistrazioneGLS As New LUNA.LunaFieldName("NoRegistrazioneGLS")
		Public Shared ReadOnly Property NumColli As New LUNA.LunaFieldName("NumColli")
		Public Shared ReadOnly Property NumeroPrimoColloBartolini As New LUNA.LunaFieldName("NumeroPrimoColloBartolini")
		Public Shared ReadOnly Property Peso As New LUNA.LunaFieldName("Peso")
		Public Shared ReadOnly Property StampaDocumenti As New LUNA.LunaFieldName("StampaDocumenti")
		Public Shared ReadOnly Property TipoDoc As New LUNA.LunaFieldName("TipoDoc")
	End Class

End Class