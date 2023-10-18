#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.2.11 
'Author: Diego Lunadei
'Date: 04/05/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_ordini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Ordine
	Inherits LUNA.LunaBaseClassEntity
	Implements _IOrdine
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IOrdine.FillFromDataRecord
		IdOrd = myRecord("IdOrd")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("ConsegnaGarantita") is DBNull.Value then ConsegnaGarantita = myRecord("ConsegnaGarantita")
		if not myRecord("ConsegnaGarantitaDa") is DBNull.Value then ConsegnaGarantitaDa = myRecord("ConsegnaGarantitaDa")
		if not myRecord("CostoSped") is DBNull.Value then CostoSped = myRecord("CostoSped")
		if not myRecord("DataCambioStato") is DBNull.Value then DataCambioStato = myRecord("DataCambioStato")
		if not myRecord("DataEffConsegna") is DBNull.Value then DataEffConsegna = myRecord("DataEffConsegna")
		if not myRecord("DataIns") is DBNull.Value then DataIns = myRecord("DataIns")
		if not myRecord("DataPrevConsegna") is DBNull.Value then DataPrevConsegna = myRecord("DataPrevConsegna")
		if not myRecord("DataPrevProduzione") is DBNull.Value then DataPrevProduzione = myRecord("DataPrevProduzione")
		if not myRecord("ExtraData") is DBNull.Value then ExtraData = myRecord("ExtraData")
		if not myRecord("FilePath") is DBNull.Value then FilePath = myRecord("FilePath")
		if not myRecord("FileSorgente") is DBNull.Value then FileSorgente = myRecord("FileSorgente")
		if not myRecord("ForzaIdFormatoProdotto") is DBNull.Value then ForzaIdFormatoProdotto = myRecord("ForzaIdFormatoProdotto")
		if not myRecord("ForzaIdMacchinarioProduzione") is DBNull.Value then ForzaIdMacchinarioProduzione = myRecord("ForzaIdMacchinarioProduzione")
		if not myRecord("ForzaIdTipoCarta") is DBNull.Value then ForzaIdTipoCarta = myRecord("ForzaIdTipoCarta")
		if not myRecord("ForzaQta") is DBNull.Value then ForzaQta = myRecord("ForzaQta")
		if not myRecord("IdCom") is DBNull.Value then IdCom = myRecord("IdCom")
		if not myRecord("IdConsProgrammata") is DBNull.Value then IdConsProgrammata = myRecord("IdConsProgrammata")
		if not myRecord("IdConsRiferimento") is DBNull.Value then IdConsRiferimento = myRecord("IdConsRiferimento")
		if not myRecord("IdCorriere") is DBNull.Value then IdCorriere = myRecord("IdCorriere")
		if not myRecord("IdCoupon") is DBNull.Value then IdCoupon = myRecord("IdCoupon")
		if not myRecord("IdDoc") is DBNull.Value then IdDoc = myRecord("IdDoc")
		if not myRecord("IdIndirizzo") is DBNull.Value then IdIndirizzo = myRecord("IdIndirizzo")
		if not myRecord("IdMacchinarioProduzioneUtilizzato") is DBNull.Value then IdMacchinarioProduzioneUtilizzato = myRecord("IdMacchinarioProduzioneUtilizzato")
		if not myRecord("IdMailPreventivo") is DBNull.Value then IdMailPreventivo = myRecord("IdMailPreventivo")
		if not myRecord("IdOrdineProvvisorio") is DBNull.Value then IdOrdineProvvisorio = myRecord("IdOrdineProvvisorio")
		if not myRecord("IdOrdOnline") is DBNull.Value then IdOrdOnline = myRecord("IdOrdOnline")
		if not myRecord("IdProd") is DBNull.Value then IdProd = myRecord("IdProd")
		if not myRecord("IdPromo") is DBNull.Value then IdPromo = myRecord("IdPromo")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("IdTipoFustella") is DBNull.Value then IdTipoFustella = myRecord("IdTipoFustella")
		if not myRecord("IdTipoProd") is DBNull.Value then IdTipoProd = myRecord("IdTipoProd")
		if not myRecord("Iva") is DBNull.Value then Iva = myRecord("Iva")
		if not myRecord("Largo") is DBNull.Value then Largo = myRecord("Largo")
		if not myRecord("LastUpdate") is DBNull.Value then LastUpdate = myRecord("LastUpdate")
		if not myRecord("Lungo") is DBNull.Value then Lungo = myRecord("Lungo")
		if not myRecord("MantieniCampione") is DBNull.Value then MantieniCampione = myRecord("MantieniCampione")
		if not myRecord("Mq") is DBNull.Value then Mq = myRecord("Mq")
		if not myRecord("NFogli") is DBNull.Value then NFogli = myRecord("NFogli")
		if not myRecord("NomeFileOriginale") is DBNull.Value then NomeFileOriginale = myRecord("NomeFileOriginale")
		if not myRecord("NomeLavoro") is DBNull.Value then NomeLavoro = myRecord("NomeLavoro")
		if not myRecord("NumeroRealeColli") is DBNull.Value then NumeroRealeColli = myRecord("NumeroRealeColli")
		if not myRecord("OraConsegna") is DBNull.Value then OraConsegna = myRecord("OraConsegna")
		if not myRecord("OrdineInOmaggio") is DBNull.Value then OrdineInOmaggio = myRecord("OrdineInOmaggio")
		if not myRecord("OrdMail") is DBNull.Value then OrdMail = myRecord("OrdMail")
		if not myRecord("Orientamento") is DBNull.Value then Orientamento = myRecord("Orientamento")
		if not myRecord("PeriodoPrevConsegna") is DBNull.Value then PeriodoPrevConsegna = myRecord("PeriodoPrevConsegna")
		if not myRecord("PreRefineErrorCode") is DBNull.Value then PreRefineErrorCode = myRecord("PreRefineErrorCode")
		if not myRecord("Preventivo") is DBNull.Value then Preventivo = myRecord("Preventivo")
		if not myRecord("Prezzo") is DBNull.Value then Prezzo = myRecord("Prezzo")
		if not myRecord("PrezzoProd") is DBNull.Value then PrezzoProd = myRecord("PrezzoProd")
		if not myRecord("Priorita") is DBNull.Value then Priorita = myRecord("Priorita")
		if not myRecord("Profondita") is DBNull.Value then Profondita = myRecord("Profondita")
		if not myRecord("Qta") is DBNull.Value then Qta = myRecord("Qta")
		if not myRecord("Ricarico") is DBNull.Value then Ricarico = myRecord("Ricarico")
		if not myRecord("RilascioCli") is DBNull.Value then RilascioCli = myRecord("RilascioCli")
		if not myRecord("Sconto") is DBNull.Value then Sconto = myRecord("Sconto")
		if not myRecord("Stato") is DBNull.Value then Stato = myRecord("Stato")
		if not myRecord("TipoConsegna") is DBNull.Value then TipoConsegna = myRecord("TipoConsegna")
		if not myRecord("TipoRetro") is DBNull.Value then TipoRetro = myRecord("TipoRetro")
		if not myRecord("TotaleForn") is DBNull.Value then TotaleForn = myRecord("TotaleForn")
		if not myRecord("UsaNomeLavoroInFattura") is DBNull.Value then UsaNomeLavoroInFattura = myRecord("UsaNomeLavoroInFattura")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Ordine)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(OrdiniDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Ordine))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ConsegnaGarantita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ConsegnaGarantitaDa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoSped As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataCambioStato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataEffConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataPrevConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataPrevProduzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ExtraData As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FilePath As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FileSorgente As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ForzaIdFormatoProdotto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ForzaIdMacchinarioProduzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ForzaIdTipoCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ForzaQta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdConsProgrammata As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdConsRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCoupon As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdDoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdIndirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinarioProduzioneUtilizzato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMailPreventivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrdineProvvisorio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrdOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPromo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoFustella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Iva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Largo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LastUpdate As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Lungo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MantieniCampione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Mq As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NFogli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeFileOriginale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeLavoro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumeroRealeColli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property OraConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property OrdineInOmaggio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property OrdMail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Orientamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PeriodoPrevConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PreRefineErrorCode As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Preventivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Priorita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Profondita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ricarico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RilascioCli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sconto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoRetro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TotaleForn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property UsaNomeLavoroInFattura As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ConsegnaGarantita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ConsegnaGarantitaDa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoSped = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataCambioStato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataEffConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataPrevConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataPrevProduzione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ExtraData = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FilePath = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FileSorgente = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ForzaIdFormatoProdotto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ForzaIdMacchinarioProduzione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ForzaIdTipoCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ForzaQta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdConsProgrammata = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdConsRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCoupon = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdDoc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdIndirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinarioProduzioneUtilizzato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMailPreventivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrdineProvvisorio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrdOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPromo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoFustella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Iva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Largo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LastUpdate = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Lungo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MantieniCampione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Mq = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NFogli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeFileOriginale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeLavoro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumeroRealeColli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.OraConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.OrdineInOmaggio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.OrdMail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Orientamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PeriodoPrevConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PreRefineErrorCode = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Preventivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Priorita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Profondita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ricarico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RilascioCli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sconto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoRetro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TotaleForn = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.UsaNomeLavoroInFattura = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdOrd as integer  = 0 
	Public Overridable Property IdOrd() as integer  Implements _IOrdine.IdOrd
		Get
			Return _IdOrd
		End Get
		Set (byval value as integer)
			If _IdOrd <> value Then
				IsChanged = True
				WhatIsChanged.IdOrd = True
				_IdOrd = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _IOrdine.Annotazioni
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

	Protected _ConsegnaGarantita as DateTime  = Nothing 
	Public Overridable Property ConsegnaGarantita() as DateTime  Implements _IOrdine.ConsegnaGarantita
		Get
			Return _ConsegnaGarantita
		End Get
		Set (byval value as DateTime)
			If _ConsegnaGarantita <> value Then
				IsChanged = True
				WhatIsChanged.ConsegnaGarantita = True
				_ConsegnaGarantita = value
			End If
		End Set
	End property 

	Protected _ConsegnaGarantitaDa as integer  = 0 
	Public Overridable Property ConsegnaGarantitaDa() as integer  Implements _IOrdine.ConsegnaGarantitaDa
		Get
			Return _ConsegnaGarantitaDa
		End Get
		Set (byval value as integer)
			If _ConsegnaGarantitaDa <> value Then
				IsChanged = True
				WhatIsChanged.ConsegnaGarantitaDa = True
				_ConsegnaGarantitaDa = value
			End If
		End Set
	End property 

	Protected _CostoSped as decimal  = 0 
	Public Overridable Property CostoSped() as decimal  Implements _IOrdine.CostoSped
		Get
			Return _CostoSped
		End Get
		Set (byval value as decimal)
			If _CostoSped <> value Then
				IsChanged = True
				WhatIsChanged.CostoSped = True
				_CostoSped = value
			End If
		End Set
	End property 

	Protected _DataCambioStato as DateTime  = Nothing 
	Public Overridable Property DataCambioStato() as DateTime  Implements _IOrdine.DataCambioStato
		Get
			Return _DataCambioStato
		End Get
		Set (byval value as DateTime)
			If _DataCambioStato <> value Then
				IsChanged = True
				WhatIsChanged.DataCambioStato = True
				_DataCambioStato = value
			End If
		End Set
	End property 

	Protected _DataEffConsegna as DateTime  = Nothing 
	Public Overridable Property DataEffConsegna() as DateTime  Implements _IOrdine.DataEffConsegna
		Get
			Return _DataEffConsegna
		End Get
		Set (byval value as DateTime)
			If _DataEffConsegna <> value Then
				IsChanged = True
				WhatIsChanged.DataEffConsegna = True
				_DataEffConsegna = value
			End If
		End Set
	End property 

	Protected _DataIns as DateTime  = Nothing 
	Public Overridable Property DataIns() as DateTime  Implements _IOrdine.DataIns
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

	Protected _DataPrevConsegna as DateTime  = Nothing 
	Public Overridable Property DataPrevConsegna() as DateTime  Implements _IOrdine.DataPrevConsegna
		Get
			Return _DataPrevConsegna
		End Get
		Set (byval value as DateTime)
			If _DataPrevConsegna <> value Then
				IsChanged = True
				WhatIsChanged.DataPrevConsegna = True
				_DataPrevConsegna = value
			End If
		End Set
	End property 

	Protected _DataPrevProduzione as DateTime  = Nothing 
	Public Overridable Property DataPrevProduzione() as DateTime  Implements _IOrdine.DataPrevProduzione
		Get
			Return _DataPrevProduzione
		End Get
		Set (byval value as DateTime)
			If _DataPrevProduzione <> value Then
				IsChanged = True
				WhatIsChanged.DataPrevProduzione = True
				_DataPrevProduzione = value
			End If
		End Set
	End property 

	Protected _ExtraData as string  = "" 
	Public Overridable Property ExtraData() as string  Implements _IOrdine.ExtraData
		Get
			Return _ExtraData
		End Get
		Set (byval value as string)
			If _ExtraData <> value Then
				IsChanged = True
				WhatIsChanged.ExtraData = True
				_ExtraData = value
			End If
		End Set
	End property 

	Protected _FilePath as string  = "" 
	Public Overridable Property FilePath() as string  Implements _IOrdine.FilePath
		Get
			Return _FilePath
		End Get
		Set (byval value as string)
			If _FilePath <> value Then
				IsChanged = True
				WhatIsChanged.FilePath = True
				_FilePath = value
			End If
		End Set
	End property 

	Protected _FileSorgente as string  = "" 
	Public Overridable Property FileSorgente() as string  Implements _IOrdine.FileSorgente
		Get
			Return _FileSorgente
		End Get
		Set (byval value as string)
			If _FileSorgente <> value Then
				IsChanged = True
				WhatIsChanged.FileSorgente = True
				_FileSorgente = value
			End If
		End Set
	End property 

	Protected _ForzaIdFormatoProdotto as integer  = 0 
	Public Overridable Property ForzaIdFormatoProdotto() as integer  Implements _IOrdine.ForzaIdFormatoProdotto
		Get
			Return _ForzaIdFormatoProdotto
		End Get
		Set (byval value as integer)
			If _ForzaIdFormatoProdotto <> value Then
				IsChanged = True
				WhatIsChanged.ForzaIdFormatoProdotto = True
				_ForzaIdFormatoProdotto = value
			End If
		End Set
	End property 

	Protected _ForzaIdMacchinarioProduzione as integer  = 0 
	Public Overridable Property ForzaIdMacchinarioProduzione() as integer  Implements _IOrdine.ForzaIdMacchinarioProduzione
		Get
			Return _ForzaIdMacchinarioProduzione
		End Get
		Set (byval value as integer)
			If _ForzaIdMacchinarioProduzione <> value Then
				IsChanged = True
				WhatIsChanged.ForzaIdMacchinarioProduzione = True
				_ForzaIdMacchinarioProduzione = value
			End If
		End Set
	End property 

	Protected _ForzaIdTipoCarta as integer  = 0 
	Public Overridable Property ForzaIdTipoCarta() as integer  Implements _IOrdine.ForzaIdTipoCarta
		Get
			Return _ForzaIdTipoCarta
		End Get
		Set (byval value as integer)
			If _ForzaIdTipoCarta <> value Then
				IsChanged = True
				WhatIsChanged.ForzaIdTipoCarta = True
				_ForzaIdTipoCarta = value
			End If
		End Set
	End property 

	Protected _ForzaQta as integer  = 0 
	Public Overridable Property ForzaQta() as integer  Implements _IOrdine.ForzaQta
		Get
			Return _ForzaQta
		End Get
		Set (byval value as integer)
			If _ForzaQta <> value Then
				IsChanged = True
				WhatIsChanged.ForzaQta = True
				_ForzaQta = value
			End If
		End Set
	End property 

	Protected _IdCom as integer  = 0 
	Public Overridable Property IdCom() as integer  Implements _IOrdine.IdCom
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

	Protected _IdConsProgrammata as integer  = 0 
	Public Overridable Property IdConsProgrammata() as integer  Implements _IOrdine.IdConsProgrammata
		Get
			Return _IdConsProgrammata
		End Get
		Set (byval value as integer)
			If _IdConsProgrammata <> value Then
				IsChanged = True
				WhatIsChanged.IdConsProgrammata = True
				_IdConsProgrammata = value
			End If
		End Set
	End property 

	Protected _IdConsRiferimento as integer  = 0 
	Public Overridable Property IdConsRiferimento() as integer  Implements _IOrdine.IdConsRiferimento
		Get
			Return _IdConsRiferimento
		End Get
		Set (byval value as integer)
			If _IdConsRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.IdConsRiferimento = True
				_IdConsRiferimento = value
			End If
		End Set
	End property 

	Protected _IdCorriere as integer  = 0 
	Public Overridable Property IdCorriere() as integer  Implements _IOrdine.IdCorriere
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

	Protected _IdCoupon as integer  = 0 
	Public Overridable Property IdCoupon() as integer  Implements _IOrdine.IdCoupon
		Get
			Return _IdCoupon
		End Get
		Set (byval value as integer)
			If _IdCoupon <> value Then
				IsChanged = True
				WhatIsChanged.IdCoupon = True
				_IdCoupon = value
			End If
		End Set
	End property 

	Protected _IdDoc as integer  = 0 
	Public Overridable Property IdDoc() as integer  Implements _IOrdine.IdDoc
		Get
			Return _IdDoc
		End Get
		Set (byval value as integer)
			If _IdDoc <> value Then
				IsChanged = True
				WhatIsChanged.IdDoc = True
				_IdDoc = value
			End If
		End Set
	End property 

	Protected _IdIndirizzo as integer  = 0 
	Public Overridable Property IdIndirizzo() as integer  Implements _IOrdine.IdIndirizzo
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

	Protected _IdMacchinarioProduzioneUtilizzato as integer  = 0 
	Public Overridable Property IdMacchinarioProduzioneUtilizzato() as integer  Implements _IOrdine.IdMacchinarioProduzioneUtilizzato
		Get
			Return _IdMacchinarioProduzioneUtilizzato
		End Get
		Set (byval value as integer)
			If _IdMacchinarioProduzioneUtilizzato <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinarioProduzioneUtilizzato = True
				_IdMacchinarioProduzioneUtilizzato = value
			End If
		End Set
	End property 

	Protected _IdMailPreventivo as integer  = 0 
	Public Overridable Property IdMailPreventivo() as integer  Implements _IOrdine.IdMailPreventivo
		Get
			Return _IdMailPreventivo
		End Get
		Set (byval value as integer)
			If _IdMailPreventivo <> value Then
				IsChanged = True
				WhatIsChanged.IdMailPreventivo = True
				_IdMailPreventivo = value
			End If
		End Set
	End property 

	Protected _IdOrdineProvvisorio as integer  = 0 
	Public Overridable Property IdOrdineProvvisorio() as integer  Implements _IOrdine.IdOrdineProvvisorio
		Get
			Return _IdOrdineProvvisorio
		End Get
		Set (byval value as integer)
			If _IdOrdineProvvisorio <> value Then
				IsChanged = True
				WhatIsChanged.IdOrdineProvvisorio = True
				_IdOrdineProvvisorio = value
			End If
		End Set
	End property 

	Protected _IdOrdOnline as integer  = 0 
	Public Overridable Property IdOrdOnline() as integer  Implements _IOrdine.IdOrdOnline
		Get
			Return _IdOrdOnline
		End Get
		Set (byval value as integer)
			If _IdOrdOnline <> value Then
				IsChanged = True
				WhatIsChanged.IdOrdOnline = True
				_IdOrdOnline = value
			End If
		End Set
	End property 

	Protected _IdProd as integer  = 0 
	Public Overridable Property IdProd() as integer  Implements _IOrdine.IdProd
		Get
			Return _IdProd
		End Get
		Set (byval value as integer)
			If _IdProd <> value Then
				IsChanged = True
				WhatIsChanged.IdProd = True
				_IdProd = value
			End If
		End Set
	End property 

	Protected _IdPromo as integer  = 0 
	Public Overridable Property IdPromo() as integer  Implements _IOrdine.IdPromo
		Get
			Return _IdPromo
		End Get
		Set (byval value as integer)
			If _IdPromo <> value Then
				IsChanged = True
				WhatIsChanged.IdPromo = True
				_IdPromo = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IOrdine.IdRub
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

	Protected _IdTipoFustella as integer  = 0 
	Public Overridable Property IdTipoFustella() as integer  Implements _IOrdine.IdTipoFustella
		Get
			Return _IdTipoFustella
		End Get
		Set (byval value as integer)
			If _IdTipoFustella <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoFustella = True
				_IdTipoFustella = value
			End If
		End Set
	End property 

	Protected _IdTipoProd as integer  = 0 
	Public Overridable Property IdTipoProd() as integer  Implements _IOrdine.IdTipoProd
		Get
			Return _IdTipoProd
		End Get
		Set (byval value as integer)
			If _IdTipoProd <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoProd = True
				_IdTipoProd = value
			End If
		End Set
	End property 

	Protected _Iva as decimal  = 0 
	Public Overridable Property Iva() as decimal  Implements _IOrdine.Iva
		Get
			Return _Iva
		End Get
		Set (byval value as decimal)
			If _Iva <> value Then
				IsChanged = True
				WhatIsChanged.Iva = True
				_Iva = value
			End If
		End Set
	End property 

	Protected _Largo as Single  = 0 
	Public Overridable Property Largo() as Single  Implements _IOrdine.Largo
		Get
			Return _Largo
		End Get
		Set (byval value as Single)
			If _Largo <> value Then
				IsChanged = True
				WhatIsChanged.Largo = True
				_Largo = value
			End If
		End Set
	End property 

	Protected _LastUpdate as integer  = 0 
	Public Overridable Property LastUpdate() as integer  Implements _IOrdine.LastUpdate
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

	Protected _Lungo as Single  = 0 
	Public Overridable Property Lungo() as Single  Implements _IOrdine.Lungo
		Get
			Return _Lungo
		End Get
		Set (byval value as Single)
			If _Lungo <> value Then
				IsChanged = True
				WhatIsChanged.Lungo = True
				_Lungo = value
			End If
		End Set
	End property 

	Protected _MantieniCampione as integer  = 0 
	Public Overridable Property MantieniCampione() as integer  Implements _IOrdine.MantieniCampione
		Get
			Return _MantieniCampione
		End Get
		Set (byval value as integer)
			If _MantieniCampione <> value Then
				IsChanged = True
				WhatIsChanged.MantieniCampione = True
				_MantieniCampione = value
			End If
		End Set
	End property 

	Protected _Mq as Single  = 0 
	Public Overridable Property Mq() as Single  Implements _IOrdine.Mq
		Get
			Return _Mq
		End Get
		Set (byval value as Single)
			If _Mq <> value Then
				IsChanged = True
				WhatIsChanged.Mq = True
				_Mq = value
			End If
		End Set
	End property 

	Protected _NFogli as integer  = 0 
	Public Overridable Property NFogli() as integer  Implements _IOrdine.NFogli
		Get
			Return _NFogli
		End Get
		Set (byval value as integer)
			If _NFogli <> value Then
				IsChanged = True
				WhatIsChanged.NFogli = True
				_NFogli = value
			End If
		End Set
	End property 

	Protected _NomeFileOriginale as string  = "" 
	Public Overridable Property NomeFileOriginale() as string  Implements _IOrdine.NomeFileOriginale
		Get
			Return _NomeFileOriginale
		End Get
		Set (byval value as string)
			If _NomeFileOriginale <> value Then
				IsChanged = True
				WhatIsChanged.NomeFileOriginale = True
				_NomeFileOriginale = value
			End If
		End Set
	End property 

	Protected _NomeLavoro as string  = "" 
	Public Overridable Property NomeLavoro() as string  Implements _IOrdine.NomeLavoro
		Get
			Return _NomeLavoro
		End Get
		Set (byval value as string)
			If _NomeLavoro <> value Then
				IsChanged = True
				WhatIsChanged.NomeLavoro = True
				_NomeLavoro = value
			End If
		End Set
	End property 

	Protected _NumeroRealeColli as integer  = 0 
	Public Overridable Property NumeroRealeColli() as integer  Implements _IOrdine.NumeroRealeColli
		Get
			Return _NumeroRealeColli
		End Get
		Set (byval value as integer)
			If _NumeroRealeColli <> value Then
				IsChanged = True
				WhatIsChanged.NumeroRealeColli = True
				_NumeroRealeColli = value
			End If
		End Set
	End property 

	Protected _OraConsegna as string  = "" 
	Public Overridable Property OraConsegna() as string  Implements _IOrdine.OraConsegna
		Get
			Return _OraConsegna
		End Get
		Set (byval value as string)
			If _OraConsegna <> value Then
				IsChanged = True
				WhatIsChanged.OraConsegna = True
				_OraConsegna = value
			End If
		End Set
	End property 

	Protected _OrdineInOmaggio as integer  = 0 
	Public Overridable Property OrdineInOmaggio() as integer  Implements _IOrdine.OrdineInOmaggio
		Get
			Return _OrdineInOmaggio
		End Get
		Set (byval value as integer)
			If _OrdineInOmaggio <> value Then
				IsChanged = True
				WhatIsChanged.OrdineInOmaggio = True
				_OrdineInOmaggio = value
			End If
		End Set
	End property 

	Protected _OrdMail as Boolean  = False 
	Public Overridable Property OrdMail() as Boolean  Implements _IOrdine.OrdMail
		Get
			Return _OrdMail
		End Get
		Set (byval value as Boolean)
			If _OrdMail <> value Then
				IsChanged = True
				WhatIsChanged.OrdMail = True
				_OrdMail = value
			End If
		End Set
	End property 

	Protected _Orientamento as integer  = 0 
	Public Overridable Property Orientamento() as integer  Implements _IOrdine.Orientamento
		Get
			Return _Orientamento
		End Get
		Set (byval value as integer)
			If _Orientamento <> value Then
				IsChanged = True
				WhatIsChanged.Orientamento = True
				_Orientamento = value
			End If
		End Set
	End property 

	Protected _PeriodoPrevConsegna as integer  = 0 
	Public Overridable Property PeriodoPrevConsegna() as integer  Implements _IOrdine.PeriodoPrevConsegna
		Get
			Return _PeriodoPrevConsegna
		End Get
		Set (byval value as integer)
			If _PeriodoPrevConsegna <> value Then
				IsChanged = True
				WhatIsChanged.PeriodoPrevConsegna = True
				_PeriodoPrevConsegna = value
			End If
		End Set
	End property 

	Protected _PreRefineErrorCode as integer  = 0 
	Public Overridable Property PreRefineErrorCode() as integer  Implements _IOrdine.PreRefineErrorCode
		Get
			Return _PreRefineErrorCode
		End Get
		Set (byval value as integer)
			If _PreRefineErrorCode <> value Then
				IsChanged = True
				WhatIsChanged.PreRefineErrorCode = True
				_PreRefineErrorCode = value
			End If
		End Set
	End property 

	Protected _Preventivo as integer  = 0 
	Public Overridable Property Preventivo() as integer  Implements _IOrdine.Preventivo
		Get
			Return _Preventivo
		End Get
		Set (byval value as integer)
			If _Preventivo <> value Then
				IsChanged = True
				WhatIsChanged.Preventivo = True
				_Preventivo = value
			End If
		End Set
	End property 

	Protected _Prezzo as decimal  = 0 
	Public Overridable Property Prezzo() as decimal  Implements _IOrdine.Prezzo
		Get
			Return _Prezzo
		End Get
		Set (byval value as decimal)
			If _Prezzo <> value Then
				IsChanged = True
				WhatIsChanged.Prezzo = True
				_Prezzo = value
			End If
		End Set
	End property 

	Protected _PrezzoProd as decimal  = 0 
	Public Overridable Property PrezzoProd() as decimal  Implements _IOrdine.PrezzoProd
		Get
			Return _PrezzoProd
		End Get
		Set (byval value as decimal)
			If _PrezzoProd <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoProd = True
				_PrezzoProd = value
			End If
		End Set
	End property 

	Protected _Priorita as integer  = 0 
	Public Overridable Property Priorita() as integer  Implements _IOrdine.Priorita
		Get
			Return _Priorita
		End Get
		Set (byval value as integer)
			If _Priorita <> value Then
				IsChanged = True
				WhatIsChanged.Priorita = True
				_Priorita = value
			End If
		End Set
	End property 

	Protected _Profondita as integer  = 0 
	Public Overridable Property Profondita() as integer  Implements _IOrdine.Profondita
		Get
			Return _Profondita
		End Get
		Set (byval value as integer)
			If _Profondita <> value Then
				IsChanged = True
				WhatIsChanged.Profondita = True
				_Profondita = value
			End If
		End Set
	End property 

	Protected _Qta as integer  = 0 
	Public Overridable Property Qta() as integer  Implements _IOrdine.Qta
		Get
			Return _Qta
		End Get
		Set (byval value as integer)
			If _Qta <> value Then
				IsChanged = True
				WhatIsChanged.Qta = True
				_Qta = value
			End If
		End Set
	End property 

	Protected _Ricarico as decimal  = 0 
	Public Overridable Property Ricarico() as decimal  Implements _IOrdine.Ricarico
		Get
			Return _Ricarico
		End Get
		Set (byval value as decimal)
			If _Ricarico <> value Then
				IsChanged = True
				WhatIsChanged.Ricarico = True
				_Ricarico = value
			End If
		End Set
	End property 

	Protected _RilascioCli as integer  = 0 
	Public Overridable Property RilascioCli() as integer  Implements _IOrdine.RilascioCli
		Get
			Return _RilascioCli
		End Get
		Set (byval value as integer)
			If _RilascioCli <> value Then
				IsChanged = True
				WhatIsChanged.RilascioCli = True
				_RilascioCli = value
			End If
		End Set
	End property 

	Protected _Sconto as decimal  = 0 
	Public Overridable Property Sconto() as decimal  Implements _IOrdine.Sconto
		Get
			Return _Sconto
		End Get
		Set (byval value as decimal)
			If _Sconto <> value Then
				IsChanged = True
				WhatIsChanged.Sconto = True
				_Sconto = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IOrdine.Stato
		Get
			Return _Stato
		End Get
		Set (byval value as integer)
			If _Stato <> value Then
				IsChanged = True
				WhatIsChanged.Stato = True
				_Stato = value
			End If
		End Set
	End property 

	Protected _TipoConsegna as integer  = 0 
	Public Overridable Property TipoConsegna() as integer  Implements _IOrdine.TipoConsegna
		Get
			Return _TipoConsegna
		End Get
		Set (byval value as integer)
			If _TipoConsegna <> value Then
				IsChanged = True
				WhatIsChanged.TipoConsegna = True
				_TipoConsegna = value
			End If
		End Set
	End property 

	Protected _TipoRetro as integer  = 0 
	Public Overridable Property TipoRetro() as integer  Implements _IOrdine.TipoRetro
		Get
			Return _TipoRetro
		End Get
		Set (byval value as integer)
			If _TipoRetro <> value Then
				IsChanged = True
				WhatIsChanged.TipoRetro = True
				_TipoRetro = value
			End If
		End Set
	End property 

	Protected _TotaleForn as decimal  = 0 
	Public Overridable Property TotaleForn() as decimal  Implements _IOrdine.TotaleForn
		Get
			Return _TotaleForn
		End Get
		Set (byval value as decimal)
			If _TotaleForn <> value Then
				IsChanged = True
				WhatIsChanged.TotaleForn = True
				_TotaleForn = value
			End If
		End Set
	End property 

	Protected _UsaNomeLavoroInFattura as integer  = 0 
	Public Overridable Property UsaNomeLavoroInFattura() as integer  Implements _IOrdine.UsaNomeLavoroInFattura
		Get
			Return _UsaNomeLavoroInFattura
		End Get
		Set (byval value as integer)
			If _UsaNomeLavoroInFattura <> value Then
				IsChanged = True
				WhatIsChanged.UsaNomeLavoroInFattura = True
				_UsaNomeLavoroInFattura = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Ordine from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Ordine = Manager.Read(Id)
				_IdOrd = int.IdOrd
				_Annotazioni = int.Annotazioni
				_ConsegnaGarantita = int.ConsegnaGarantita
				_ConsegnaGarantitaDa = int.ConsegnaGarantitaDa
				_CostoSped = int.CostoSped
				_DataCambioStato = int.DataCambioStato
				_DataEffConsegna = int.DataEffConsegna
				_DataIns = int.DataIns
				_DataPrevConsegna = int.DataPrevConsegna
				_DataPrevProduzione = int.DataPrevProduzione
				_ExtraData = int.ExtraData
				_FilePath = int.FilePath
				_FileSorgente = int.FileSorgente
				_ForzaIdFormatoProdotto = int.ForzaIdFormatoProdotto
				_ForzaIdMacchinarioProduzione = int.ForzaIdMacchinarioProduzione
				_ForzaIdTipoCarta = int.ForzaIdTipoCarta
				_ForzaQta = int.ForzaQta
				_IdCom = int.IdCom
				_IdConsProgrammata = int.IdConsProgrammata
				_IdConsRiferimento = int.IdConsRiferimento
				_IdCorriere = int.IdCorriere
				_IdCoupon = int.IdCoupon
				_IdDoc = int.IdDoc
				_IdIndirizzo = int.IdIndirizzo
				_IdMacchinarioProduzioneUtilizzato = int.IdMacchinarioProduzioneUtilizzato
				_IdMailPreventivo = int.IdMailPreventivo
				_IdOrdineProvvisorio = int.IdOrdineProvvisorio
				_IdOrdOnline = int.IdOrdOnline
				_IdProd = int.IdProd
				_IdPromo = int.IdPromo
				_IdRub = int.IdRub
				_IdTipoFustella = int.IdTipoFustella
				_IdTipoProd = int.IdTipoProd
				_Iva = int.Iva
				_Largo = int.Largo
				_LastUpdate = int.LastUpdate
				_Lungo = int.Lungo
				_MantieniCampione = int.MantieniCampione
				_Mq = int.Mq
				_NFogli = int.NFogli
				_NomeFileOriginale = int.NomeFileOriginale
				_NomeLavoro = int.NomeLavoro
				_NumeroRealeColli = int.NumeroRealeColli
				_OraConsegna = int.OraConsegna
				_OrdineInOmaggio = int.OrdineInOmaggio
				_OrdMail = int.OrdMail
				_Orientamento = int.Orientamento
				_PeriodoPrevConsegna = int.PeriodoPrevConsegna
				_PreRefineErrorCode = int.PreRefineErrorCode
				_Preventivo = int.Preventivo
				_Prezzo = int.Prezzo
				_PrezzoProd = int.PrezzoProd
				_Priorita = int.Priorita
				_Profondita = int.Profondita
				_Qta = int.Qta
				_Ricarico = int.Ricarico
				_RilascioCli = int.RilascioCli
				_Sconto = int.Sconto
				_Stato = int.Stato
				_TipoConsegna = int.TipoConsegna
				_TipoRetro = int.TipoRetro
				_TotaleForn = int.TotaleForn
				_UsaNomeLavoroInFattura = int.UsaNomeLavoroInFattura
			End Using
			Manager = nothing
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
    Public Overridable Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdOrd Then
            ris = Read(IdOrd)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an Ordine on DB.
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
		if _Annotazioni.Length > 2147483647 then Ris = False
		if _ExtraData.Length > 255 then Ris = False
		if _FilePath.Length > 255 then Ris = False
		if _FileSorgente.Length > 255 then Ris = False
		if _NomeFileOriginale.Length > 255 then Ris = False
		if _NomeLavoro.Length > 100 then Ris = False
		if _OraConsegna.Length > 5 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_ordini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IOrdine

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdOrd() as integer
	Property Annotazioni() as string
	Property ConsegnaGarantita() as DateTime
	Property ConsegnaGarantitaDa() as integer
	Property CostoSped() as decimal
	Property DataCambioStato() as DateTime
	Property DataEffConsegna() as DateTime
	Property DataIns() as DateTime
	Property DataPrevConsegna() as DateTime
	Property DataPrevProduzione() as DateTime
	Property ExtraData() as string
	Property FilePath() as string
	Property FileSorgente() as string
	Property ForzaIdFormatoProdotto() as integer
	Property ForzaIdMacchinarioProduzione() as integer
	Property ForzaIdTipoCarta() as integer
	Property ForzaQta() as integer
	Property IdCom() as integer
	Property IdConsProgrammata() as integer
	Property IdConsRiferimento() as integer
	Property IdCorriere() as integer
	Property IdCoupon() as integer
	Property IdDoc() as integer
	Property IdIndirizzo() as integer
	Property IdMacchinarioProduzioneUtilizzato() as integer
	Property IdMailPreventivo() as integer
	Property IdOrdineProvvisorio() as integer
	Property IdOrdOnline() as integer
	Property IdProd() as integer
	Property IdPromo() as integer
	Property IdRub() as integer
	Property IdTipoFustella() as integer
	Property IdTipoProd() as integer
	Property Iva() as decimal
	Property Largo() as Single
	Property LastUpdate() as integer
	Property Lungo() as Single
	Property MantieniCampione() as integer
	Property Mq() as Single
	Property NFogli() as integer
	Property NomeFileOriginale() as string
	Property NomeLavoro() as string
	Property NumeroRealeColli() as integer
	Property OraConsegna() as string
	Property OrdineInOmaggio() as integer
	Property OrdMail() as Boolean
	Property Orientamento() as integer
	Property PeriodoPrevConsegna() as integer
	Property PreRefineErrorCode() as integer
	Property Preventivo() as integer
	Property Prezzo() as decimal
	Property PrezzoProd() as decimal
	Property Priorita() as integer
	Property Profondita() as integer
	Property Qta() as integer
	Property Ricarico() as decimal
	Property RilascioCli() as integer
	Property Sconto() as decimal
	Property Stato() as integer
	Property TipoConsegna() as integer
	Property TipoRetro() as integer
	Property TotaleForn() as decimal
	Property UsaNomeLavoroInFattura() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Ordine
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property ConsegnaGarantita As New LUNA.LunaFieldName("ConsegnaGarantita")
		Public Shared ReadOnly Property ConsegnaGarantitaDa As New LUNA.LunaFieldName("ConsegnaGarantitaDa")
		Public Shared ReadOnly Property CostoSped As New LUNA.LunaFieldName("CostoSped")
		Public Shared ReadOnly Property DataCambioStato As New LUNA.LunaFieldName("DataCambioStato")
		Public Shared ReadOnly Property DataEffConsegna As New LUNA.LunaFieldName("DataEffConsegna")
		Public Shared ReadOnly Property DataIns As New LUNA.LunaFieldName("DataIns")
		Public Shared ReadOnly Property DataPrevConsegna As New LUNA.LunaFieldName("DataPrevConsegna")
		Public Shared ReadOnly Property DataPrevProduzione As New LUNA.LunaFieldName("DataPrevProduzione")
		Public Shared ReadOnly Property ExtraData As New LUNA.LunaFieldName("ExtraData")
		Public Shared ReadOnly Property FilePath As New LUNA.LunaFieldName("FilePath")
		Public Shared ReadOnly Property FileSorgente As New LUNA.LunaFieldName("FileSorgente")
		Public Shared ReadOnly Property ForzaIdFormatoProdotto As New LUNA.LunaFieldName("ForzaIdFormatoProdotto")
		Public Shared ReadOnly Property ForzaIdMacchinarioProduzione As New LUNA.LunaFieldName("ForzaIdMacchinarioProduzione")
		Public Shared ReadOnly Property ForzaIdTipoCarta As New LUNA.LunaFieldName("ForzaIdTipoCarta")
		Public Shared ReadOnly Property ForzaQta As New LUNA.LunaFieldName("ForzaQta")
		Public Shared ReadOnly Property IdCom As New LUNA.LunaFieldName("IdCom")
		Public Shared ReadOnly Property IdConsProgrammata As New LUNA.LunaFieldName("IdConsProgrammata")
		Public Shared ReadOnly Property IdConsRiferimento As New LUNA.LunaFieldName("IdConsRiferimento")
		Public Shared ReadOnly Property IdCorriere As New LUNA.LunaFieldName("IdCorriere")
		Public Shared ReadOnly Property IdCoupon As New LUNA.LunaFieldName("IdCoupon")
		Public Shared ReadOnly Property IdDoc As New LUNA.LunaFieldName("IdDoc")
		Public Shared ReadOnly Property IdIndirizzo As New LUNA.LunaFieldName("IdIndirizzo")
		Public Shared ReadOnly Property IdMacchinarioProduzioneUtilizzato As New LUNA.LunaFieldName("IdMacchinarioProduzioneUtilizzato")
		Public Shared ReadOnly Property IdMailPreventivo As New LUNA.LunaFieldName("IdMailPreventivo")
		Public Shared ReadOnly Property IdOrdineProvvisorio As New LUNA.LunaFieldName("IdOrdineProvvisorio")
		Public Shared ReadOnly Property IdOrdOnline As New LUNA.LunaFieldName("IdOrdOnline")
		Public Shared ReadOnly Property IdProd As New LUNA.LunaFieldName("IdProd")
		Public Shared ReadOnly Property IdPromo As New LUNA.LunaFieldName("IdPromo")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property IdTipoFustella As New LUNA.LunaFieldName("IdTipoFustella")
		Public Shared ReadOnly Property IdTipoProd As New LUNA.LunaFieldName("IdTipoProd")
		Public Shared ReadOnly Property Iva As New LUNA.LunaFieldName("Iva")
		Public Shared ReadOnly Property Largo As New LUNA.LunaFieldName("Largo")
		Public Shared ReadOnly Property LastUpdate As New LUNA.LunaFieldName("LastUpdate")
		Public Shared ReadOnly Property Lungo As New LUNA.LunaFieldName("Lungo")
		Public Shared ReadOnly Property MantieniCampione As New LUNA.LunaFieldName("MantieniCampione")
		Public Shared ReadOnly Property Mq As New LUNA.LunaFieldName("Mq")
		Public Shared ReadOnly Property NFogli As New LUNA.LunaFieldName("NFogli")
		Public Shared ReadOnly Property NomeFileOriginale As New LUNA.LunaFieldName("NomeFileOriginale")
		Public Shared ReadOnly Property NomeLavoro As New LUNA.LunaFieldName("NomeLavoro")
		Public Shared ReadOnly Property NumeroRealeColli As New LUNA.LunaFieldName("NumeroRealeColli")
		Public Shared ReadOnly Property OraConsegna As New LUNA.LunaFieldName("OraConsegna")
		Public Shared ReadOnly Property OrdineInOmaggio As New LUNA.LunaFieldName("OrdineInOmaggio")
		Public Shared ReadOnly Property OrdMail As New LUNA.LunaFieldName("OrdMail")
		Public Shared ReadOnly Property Orientamento As New LUNA.LunaFieldName("Orientamento")
		Public Shared ReadOnly Property PeriodoPrevConsegna As New LUNA.LunaFieldName("PeriodoPrevConsegna")
		Public Shared ReadOnly Property PreRefineErrorCode As New LUNA.LunaFieldName("PreRefineErrorCode")
		Public Shared ReadOnly Property Preventivo As New LUNA.LunaFieldName("Preventivo")
		Public Shared ReadOnly Property Prezzo As New LUNA.LunaFieldName("Prezzo")
		Public Shared ReadOnly Property PrezzoProd As New LUNA.LunaFieldName("PrezzoProd")
		Public Shared ReadOnly Property Priorita As New LUNA.LunaFieldName("Priorita")
		Public Shared ReadOnly Property Profondita As New LUNA.LunaFieldName("Profondita")
		Public Shared ReadOnly Property Qta As New LUNA.LunaFieldName("Qta")
		Public Shared ReadOnly Property Ricarico As New LUNA.LunaFieldName("Ricarico")
		Public Shared ReadOnly Property RilascioCli As New LUNA.LunaFieldName("RilascioCli")
		Public Shared ReadOnly Property Sconto As New LUNA.LunaFieldName("Sconto")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property TipoConsegna As New LUNA.LunaFieldName("TipoConsegna")
		Public Shared ReadOnly Property TipoRetro As New LUNA.LunaFieldName("TipoRetro")
		Public Shared ReadOnly Property TotaleForn As New LUNA.LunaFieldName("TotaleForn")
		Public Shared ReadOnly Property UsaNomeLavoroInFattura As New LUNA.LunaFieldName("UsaNomeLavoroInFattura")
	End Class

End Class