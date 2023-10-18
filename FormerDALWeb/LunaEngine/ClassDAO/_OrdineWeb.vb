#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.1 
'Author: Diego Lunadei
'Date: 08/11/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Ordini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _OrdineWeb
	Inherits LUNA.LunaBaseClassEntity
	Implements _IOrdineWeb
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IOrdineWeb.FillFromDataRecord
		IdOrdine = myRecord("IdOrdine")
		if not myRecord("Altezza") is DBNull.Value then Altezza = myRecord("Altezza")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("Anteprima") is DBNull.Value then Anteprima = myRecord("Anteprima")
		if not myRecord("ConsegnaGarantita") is DBNull.Value then ConsegnaGarantita = myRecord("ConsegnaGarantita")
		if not myRecord("ConsegnaGarantitaDa") is DBNull.Value then ConsegnaGarantitaDa = myRecord("ConsegnaGarantitaDa")
		if not myRecord("DataCambioStato") is DBNull.Value then DataCambioStato = myRecord("DataCambioStato")
		if not myRecord("DataIns") is DBNull.Value then DataIns = myRecord("DataIns")
		if not myRecord("DataPrevConsegna") is DBNull.Value then DataPrevConsegna = myRecord("DataPrevConsegna")
		if not myRecord("DataPrevProduzione") is DBNull.Value then DataPrevProduzione = myRecord("DataPrevProduzione")
		if not myRecord("ExtraData") is DBNull.Value then ExtraData = myRecord("ExtraData")
		if not myRecord("IdCons") is DBNull.Value then IdCons = myRecord("IdCons")
		if not myRecord("IdCorriere") is DBNull.Value then IdCorriere = myRecord("IdCorriere")
		if not myRecord("IdCoupon") is DBNull.Value then IdCoupon = myRecord("IdCoupon")
		if not myRecord("IdIndirizzo") is DBNull.Value then IdIndirizzo = myRecord("IdIndirizzo")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		if not myRecord("IdMacchinarioProduzioneUtilizzato") is DBNull.Value then IdMacchinarioProduzioneUtilizzato = myRecord("IdMacchinarioProduzioneUtilizzato")
		if not myRecord("IdMailPreventivo") is DBNull.Value then IdMailPreventivo = myRecord("IdMailPreventivo")
		if not myRecord("IdOrdineInt") is DBNull.Value then IdOrdineInt = myRecord("IdOrdineInt")
		if not myRecord("IdPromo") is DBNull.Value then IdPromo = myRecord("IdPromo")
		if not myRecord("IdTipoFustella") is DBNull.Value then IdTipoFustella = myRecord("IdTipoFustella")
		if not myRecord("IdUt") is DBNull.Value then IdUt = myRecord("IdUt")
		if not myRecord("InseritoDa") is DBNull.Value then InseritoDa = myRecord("InseritoDa")
		if not myRecord("Larghezza") is DBNull.Value then Larghezza = myRecord("Larghezza")
		if not myRecord("Lavorazioni") is DBNull.Value then Lavorazioni = myRecord("Lavorazioni")
		if not myRecord("Mq") is DBNull.Value then Mq = myRecord("Mq")
		if not myRecord("Nfogli") is DBNull.Value then Nfogli = myRecord("Nfogli")
		if not myRecord("NoEmailDemone") is DBNull.Value then NoEmailDemone = myRecord("NoEmailDemone")
		if not myRecord("NomeLavoro") is DBNull.Value then NomeLavoro = myRecord("NomeLavoro")
		if not myRecord("NumeroColli") is DBNull.Value then NumeroColli = myRecord("NumeroColli")
		if not myRecord("OrdineInOmaggio") is DBNull.Value then OrdineInOmaggio = myRecord("OrdineInOmaggio")
		if not myRecord("OrdineWeb") is DBNull.Value then OrdineWeb = myRecord("OrdineWeb")
		if not myRecord("Orientamento") is DBNull.Value then Orientamento = myRecord("Orientamento")
		if not myRecord("Peso") is DBNull.Value then Peso = myRecord("Peso")
		if not myRecord("Preventivo") is DBNull.Value then Preventivo = myRecord("Preventivo")
		if not myRecord("PrezzoCalcolatoNetto") is DBNull.Value then PrezzoCalcolatoNetto = myRecord("PrezzoCalcolatoNetto")
		if not myRecord("PrezzoCorriere") is DBNull.Value then PrezzoCorriere = myRecord("PrezzoCorriere")
		if not myRecord("Profondita") is DBNull.Value then Profondita = myRecord("Profondita")
		if not myRecord("Qta") is DBNull.Value then Qta = myRecord("Qta")
		if not myRecord("Ricarico") is DBNull.Value then Ricarico = myRecord("Ricarico")
		if not myRecord("Sconto") is DBNull.Value then Sconto = myRecord("Sconto")
		if not myRecord("SorgenteCopertina") is DBNull.Value then SorgenteCopertina = myRecord("SorgenteCopertina")
		if not myRecord("SorgenteFronte") is DBNull.Value then SorgenteFronte = myRecord("SorgenteFronte")
		if not myRecord("SorgenteRetro") is DBNull.Value then SorgenteRetro = myRecord("SorgenteRetro")
		if not myRecord("Stato") is DBNull.Value then Stato = myRecord("Stato")
		if not myRecord("StatoWeb") is DBNull.Value then StatoWeb = myRecord("StatoWeb")
		if not myRecord("TipoConsegna") is DBNull.Value then TipoConsegna = myRecord("TipoConsegna")
		if not myRecord("TipoRetro") is DBNull.Value then TipoRetro = myRecord("TipoRetro")
		if not myRecord("TotaleIva") is DBNull.Value then TotaleIva = myRecord("TotaleIva")
		if not myRecord("TotaleNetto") is DBNull.Value then TotaleNetto = myRecord("TotaleNetto")
		if not myRecord("TotaleOrdine") is DBNull.Value then TotaleOrdine = myRecord("TotaleOrdine")
		if not myRecord("UsaNomeLavoroInFattura") is DBNull.Value then UsaNomeLavoroInFattura = myRecord("UsaNomeLavoroInFattura")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of OrdineWeb)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(OrdiniWebDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of OrdineWeb))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdOrdine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Altezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Anteprima As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ConsegnaGarantita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ConsegnaGarantitaDa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataCambioStato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataPrevConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataPrevProduzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ExtraData As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCons As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCoupon As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdIndirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinarioProduzioneUtilizzato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMailPreventivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrdineInt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPromo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoFustella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property InseritoDa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Larghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Lavorazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Mq As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nfogli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoEmailDemone As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeLavoro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumeroColli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property OrdineInOmaggio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property OrdineWeb As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Orientamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Peso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Preventivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoCalcolatoNetto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Profondita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ricarico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sconto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SorgenteCopertina As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SorgenteFronte As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SorgenteRetro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StatoWeb As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoRetro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TotaleIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TotaleNetto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TotaleOrdine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property UsaNomeLavoroInFattura As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdOrdine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Altezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Anteprima = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ConsegnaGarantita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ConsegnaGarantitaDa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataCambioStato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataPrevConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataPrevProduzione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ExtraData = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCons = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCoupon = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdIndirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinarioProduzioneUtilizzato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMailPreventivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrdineInt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPromo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoFustella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.InseritoDa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Larghezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Lavorazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Mq = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nfogli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoEmailDemone = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeLavoro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumeroColli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.OrdineInOmaggio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.OrdineWeb = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Orientamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Peso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Preventivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoCalcolatoNetto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Profondita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ricarico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sconto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SorgenteCopertina = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SorgenteFronte = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SorgenteRetro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StatoWeb = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoRetro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TotaleIva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TotaleNetto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TotaleOrdine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.UsaNomeLavoroInFattura = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdOrdine as integer  = 0 
	Public Overridable Property IdOrdine() as integer  Implements _IOrdineWeb.IdOrdine
		Get
			Return _IdOrdine
		End Get
		Set (byval value as integer)
			If _IdOrdine <> value Then
				IsChanged = True
				WhatIsChanged.IdOrdine = True
				_IdOrdine = value
			End If
		End Set
	End property 

	Protected _Altezza as integer  = 0 
	Public Overridable Property Altezza() as integer  Implements _IOrdineWeb.Altezza
		Get
			Return _Altezza
		End Get
		Set (byval value as integer)
			If _Altezza <> value Then
				IsChanged = True
				WhatIsChanged.Altezza = True
				_Altezza = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _IOrdineWeb.Annotazioni
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

	Protected _Anteprima as string  = "" 
	Public Overridable Property Anteprima() as string  Implements _IOrdineWeb.Anteprima
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

	Protected _ConsegnaGarantita as DateTime  = Nothing 
	Public Overridable Property ConsegnaGarantita() as DateTime  Implements _IOrdineWeb.ConsegnaGarantita
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
	Public Overridable Property ConsegnaGarantitaDa() as integer  Implements _IOrdineWeb.ConsegnaGarantitaDa
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

	Protected _DataCambioStato as DateTime  = Nothing 
	Public Overridable Property DataCambioStato() as DateTime  Implements _IOrdineWeb.DataCambioStato
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

	Protected _DataIns as DateTime  = Nothing 
	Public Overridable Property DataIns() as DateTime  Implements _IOrdineWeb.DataIns
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
	Public Overridable Property DataPrevConsegna() as DateTime  Implements _IOrdineWeb.DataPrevConsegna
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
	Public Overridable Property DataPrevProduzione() as DateTime  Implements _IOrdineWeb.DataPrevProduzione
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
	Public Overridable Property ExtraData() as string  Implements _IOrdineWeb.ExtraData
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

	Protected _IdCons as integer  = 0 
	Public Overridable Property IdCons() as integer  Implements _IOrdineWeb.IdCons
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

	Protected _IdCorriere as integer  = 0 
	Public Overridable Property IdCorriere() as integer  Implements _IOrdineWeb.IdCorriere
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
	Public Overridable Property IdCoupon() as integer  Implements _IOrdineWeb.IdCoupon
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

	Protected _IdIndirizzo as integer  = 0 
	Public Overridable Property IdIndirizzo() as integer  Implements _IOrdineWeb.IdIndirizzo
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

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IOrdineWeb.IdListinoBase
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

	Protected _IdMacchinarioProduzioneUtilizzato as integer  = 0 
	Public Overridable Property IdMacchinarioProduzioneUtilizzato() as integer  Implements _IOrdineWeb.IdMacchinarioProduzioneUtilizzato
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
	Public Overridable Property IdMailPreventivo() as integer  Implements _IOrdineWeb.IdMailPreventivo
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

	Protected _IdOrdineInt as integer  = 0 
	Public Overridable Property IdOrdineInt() as integer  Implements _IOrdineWeb.IdOrdineInt
		Get
			Return _IdOrdineInt
		End Get
		Set (byval value as integer)
			If _IdOrdineInt <> value Then
				IsChanged = True
				WhatIsChanged.IdOrdineInt = True
				_IdOrdineInt = value
			End If
		End Set
	End property 

	Protected _IdPromo as integer  = 0 
	Public Overridable Property IdPromo() as integer  Implements _IOrdineWeb.IdPromo
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

	Protected _IdTipoFustella as integer  = 0 
	Public Overridable Property IdTipoFustella() as integer  Implements _IOrdineWeb.IdTipoFustella
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

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IOrdineWeb.IdUt
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

	Protected _InseritoDa as integer  = 0 
	Public Overridable Property InseritoDa() as integer  Implements _IOrdineWeb.InseritoDa
		Get
			Return _InseritoDa
		End Get
		Set (byval value as integer)
			If _InseritoDa <> value Then
				IsChanged = True
				WhatIsChanged.InseritoDa = True
				_InseritoDa = value
			End If
		End Set
	End property 

	Protected _Larghezza as integer  = 0 
	Public Overridable Property Larghezza() as integer  Implements _IOrdineWeb.Larghezza
		Get
			Return _Larghezza
		End Get
		Set (byval value as integer)
			If _Larghezza <> value Then
				IsChanged = True
				WhatIsChanged.Larghezza = True
				_Larghezza = value
			End If
		End Set
	End property 

	Protected _Lavorazioni as string  = "" 
	Public Overridable Property Lavorazioni() as string  Implements _IOrdineWeb.Lavorazioni
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

	Protected _Mq as Single  = 0 
	Public Overridable Property Mq() as Single  Implements _IOrdineWeb.Mq
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

	Protected _Nfogli as integer  = 0 
	Public Overridable Property Nfogli() as integer  Implements _IOrdineWeb.Nfogli
		Get
			Return _Nfogli
		End Get
		Set (byval value as integer)
			If _Nfogli <> value Then
				IsChanged = True
				WhatIsChanged.Nfogli = True
				_Nfogli = value
			End If
		End Set
	End property 

	Protected _NoEmailDemone as integer  = 0 
	Public Overridable Property NoEmailDemone() as integer  Implements _IOrdineWeb.NoEmailDemone
		Get
			Return _NoEmailDemone
		End Get
		Set (byval value as integer)
			If _NoEmailDemone <> value Then
				IsChanged = True
				WhatIsChanged.NoEmailDemone = True
				_NoEmailDemone = value
			End If
		End Set
	End property 

	Protected _NomeLavoro as string  = "" 
	Public Overridable Property NomeLavoro() as string  Implements _IOrdineWeb.NomeLavoro
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

	Protected _NumeroColli as integer  = 0 
	Public Overridable Property NumeroColli() as integer  Implements _IOrdineWeb.NumeroColli
		Get
			Return _NumeroColli
		End Get
		Set (byval value as integer)
			If _NumeroColli <> value Then
				IsChanged = True
				WhatIsChanged.NumeroColli = True
				_NumeroColli = value
			End If
		End Set
	End property 

	Protected _OrdineInOmaggio as integer  = 0 
	Public Overridable Property OrdineInOmaggio() as integer  Implements _IOrdineWeb.OrdineInOmaggio
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

	Protected _OrdineWeb as Boolean  = False 
	Public Overridable Property OrdineWeb() as Boolean  Implements _IOrdineWeb.OrdineWeb
		Get
			Return _OrdineWeb
		End Get
		Set (byval value as Boolean)
			If _OrdineWeb <> value Then
				IsChanged = True
				WhatIsChanged.OrdineWeb = True
				_OrdineWeb = value
			End If
		End Set
	End property 

	Protected _Orientamento as integer  = 0 
	Public Overridable Property Orientamento() as integer  Implements _IOrdineWeb.Orientamento
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

	Protected _Peso as integer  = 0 
	Public Overridable Property Peso() as integer  Implements _IOrdineWeb.Peso
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

	Protected _Preventivo as integer  = 0 
	Public Overridable Property Preventivo() as integer  Implements _IOrdineWeb.Preventivo
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

	Protected _PrezzoCalcolatoNetto as decimal  = 0 
	Public Overridable Property PrezzoCalcolatoNetto() as decimal  Implements _IOrdineWeb.PrezzoCalcolatoNetto
		Get
			Return _PrezzoCalcolatoNetto
		End Get
		Set (byval value as decimal)
			If _PrezzoCalcolatoNetto <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoCalcolatoNetto = True
				_PrezzoCalcolatoNetto = value
			End If
		End Set
	End property 

	Protected _PrezzoCorriere as decimal  = 0 
	Public Overridable Property PrezzoCorriere() as decimal  Implements _IOrdineWeb.PrezzoCorriere
		Get
			Return _PrezzoCorriere
		End Get
		Set (byval value as decimal)
			If _PrezzoCorriere <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoCorriere = True
				_PrezzoCorriere = value
			End If
		End Set
	End property 

	Protected _Profondita as integer  = 0 
	Public Overridable Property Profondita() as integer  Implements _IOrdineWeb.Profondita
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
	Public Overridable Property Qta() as integer  Implements _IOrdineWeb.Qta
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
	Public Overridable Property Ricarico() as decimal  Implements _IOrdineWeb.Ricarico
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

	Protected _Sconto as decimal  = 0 
	Public Overridable Property Sconto() as decimal  Implements _IOrdineWeb.Sconto
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

	Protected _SorgenteCopertina as string  = "" 
	Public Overridable Property SorgenteCopertina() as string  Implements _IOrdineWeb.SorgenteCopertina
		Get
			Return _SorgenteCopertina
		End Get
		Set (byval value as string)
			If _SorgenteCopertina <> value Then
				IsChanged = True
				WhatIsChanged.SorgenteCopertina = True
				_SorgenteCopertina = value
			End If
		End Set
	End property 

	Protected _SorgenteFronte as string  = "" 
	Public Overridable Property SorgenteFronte() as string  Implements _IOrdineWeb.SorgenteFronte
		Get
			Return _SorgenteFronte
		End Get
		Set (byval value as string)
			If _SorgenteFronte <> value Then
				IsChanged = True
				WhatIsChanged.SorgenteFronte = True
				_SorgenteFronte = value
			End If
		End Set
	End property 

	Protected _SorgenteRetro as string  = "" 
	Public Overridable Property SorgenteRetro() as string  Implements _IOrdineWeb.SorgenteRetro
		Get
			Return _SorgenteRetro
		End Get
		Set (byval value as string)
			If _SorgenteRetro <> value Then
				IsChanged = True
				WhatIsChanged.SorgenteRetro = True
				_SorgenteRetro = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IOrdineWeb.Stato
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

	Protected _StatoWeb as integer  = 0 
	Public Overridable Property StatoWeb() as integer  Implements _IOrdineWeb.StatoWeb
		Get
			Return _StatoWeb
		End Get
		Set (byval value as integer)
			If _StatoWeb <> value Then
				IsChanged = True
				WhatIsChanged.StatoWeb = True
				_StatoWeb = value
			End If
		End Set
	End property 

	Protected _TipoConsegna as integer  = 0 
	Public Overridable Property TipoConsegna() as integer  Implements _IOrdineWeb.TipoConsegna
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
	Public Overridable Property TipoRetro() as integer  Implements _IOrdineWeb.TipoRetro
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

	Protected _TotaleIva as decimal  = 0 
	Public Overridable Property TotaleIva() as decimal  Implements _IOrdineWeb.TotaleIva
		Get
			Return _TotaleIva
		End Get
		Set (byval value as decimal)
			If _TotaleIva <> value Then
				IsChanged = True
				WhatIsChanged.TotaleIva = True
				_TotaleIva = value
			End If
		End Set
	End property 

	Protected _TotaleNetto as decimal  = 0 
	Public Overridable Property TotaleNetto() as decimal  Implements _IOrdineWeb.TotaleNetto
		Get
			Return _TotaleNetto
		End Get
		Set (byval value as decimal)
			If _TotaleNetto <> value Then
				IsChanged = True
				WhatIsChanged.TotaleNetto = True
				_TotaleNetto = value
			End If
		End Set
	End property 

	Protected _TotaleOrdine as decimal  = 0 
	Public Overridable Property TotaleOrdine() as decimal  Implements _IOrdineWeb.TotaleOrdine
		Get
			Return _TotaleOrdine
		End Get
		Set (byval value as decimal)
			If _TotaleOrdine <> value Then
				IsChanged = True
				WhatIsChanged.TotaleOrdine = True
				_TotaleOrdine = value
			End If
		End Set
	End property 

	Protected _UsaNomeLavoroInFattura as integer  = 0 
	Public Overridable Property UsaNomeLavoroInFattura() as integer  Implements _IOrdineWeb.UsaNomeLavoroInFattura
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
	'''This method read an OrdineWeb from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As OrdineWeb = Manager.Read(Id)
				_IdOrdine = int.IdOrdine
				_Altezza = int.Altezza
				_Annotazioni = int.Annotazioni
				_Anteprima = int.Anteprima
				_ConsegnaGarantita = int.ConsegnaGarantita
				_ConsegnaGarantitaDa = int.ConsegnaGarantitaDa
				_DataCambioStato = int.DataCambioStato
				_DataIns = int.DataIns
				_DataPrevConsegna = int.DataPrevConsegna
				_DataPrevProduzione = int.DataPrevProduzione
				_ExtraData = int.ExtraData
				_IdCons = int.IdCons
				_IdCorriere = int.IdCorriere
				_IdCoupon = int.IdCoupon
				_IdIndirizzo = int.IdIndirizzo
				_IdListinoBase = int.IdListinoBase
				_IdMacchinarioProduzioneUtilizzato = int.IdMacchinarioProduzioneUtilizzato
				_IdMailPreventivo = int.IdMailPreventivo
				_IdOrdineInt = int.IdOrdineInt
				_IdPromo = int.IdPromo
				_IdTipoFustella = int.IdTipoFustella
				_IdUt = int.IdUt
				_InseritoDa = int.InseritoDa
				_Larghezza = int.Larghezza
				_Lavorazioni = int.Lavorazioni
				_Mq = int.Mq
				_Nfogli = int.Nfogli
				_NoEmailDemone = int.NoEmailDemone
				_NomeLavoro = int.NomeLavoro
				_NumeroColli = int.NumeroColli
				_OrdineInOmaggio = int.OrdineInOmaggio
				_OrdineWeb = int.OrdineWeb
				_Orientamento = int.Orientamento
				_Peso = int.Peso
				_Preventivo = int.Preventivo
				_PrezzoCalcolatoNetto = int.PrezzoCalcolatoNetto
				_PrezzoCorriere = int.PrezzoCorriere
				_Profondita = int.Profondita
				_Qta = int.Qta
				_Ricarico = int.Ricarico
				_Sconto = int.Sconto
				_SorgenteCopertina = int.SorgenteCopertina
				_SorgenteFronte = int.SorgenteFronte
				_SorgenteRetro = int.SorgenteRetro
				_Stato = int.Stato
				_StatoWeb = int.StatoWeb
				_TipoConsegna = int.TipoConsegna
				_TipoRetro = int.TipoRetro
				_TotaleIva = int.TotaleIva
				_TotaleNetto = int.TotaleNetto
				_TotaleOrdine = int.TotaleOrdine
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
    Public Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdOrdine Then
            ris = Read(IdOrdine)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an OrdineWeb on DB.
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
		if _Anteprima.Length > 255 then Ris = False
		if _ExtraData.Length > 255 then Ris = False
		if _Lavorazioni.Length > 255 then Ris = False
		if _NomeLavoro.Length > 100 then Ris = False
		if _SorgenteCopertina.Length > 255 then Ris = False
		if _SorgenteFronte.Length > 255 then Ris = False
		if _SorgenteRetro.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Ordini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IOrdineWeb

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdOrdine() as integer
	Property Altezza() as integer
	Property Annotazioni() as string
	Property Anteprima() as string
	Property ConsegnaGarantita() as DateTime
	Property ConsegnaGarantitaDa() as integer
	Property DataCambioStato() as DateTime
	Property DataIns() as DateTime
	Property DataPrevConsegna() as DateTime
	Property DataPrevProduzione() as DateTime
	Property ExtraData() as string
	Property IdCons() as integer
	Property IdCorriere() as integer
	Property IdCoupon() as integer
	Property IdIndirizzo() as integer
	Property IdListinoBase() as integer
	Property IdMacchinarioProduzioneUtilizzato() as integer
	Property IdMailPreventivo() as integer
	Property IdOrdineInt() as integer
	Property IdPromo() as integer
	Property IdTipoFustella() as integer
	Property IdUt() as integer
	Property InseritoDa() as integer
	Property Larghezza() as integer
	Property Lavorazioni() as string
	Property Mq() as Single
	Property Nfogli() as integer
	Property NoEmailDemone() as integer
	Property NomeLavoro() as string
	Property NumeroColli() as integer
	Property OrdineInOmaggio() as integer
	Property OrdineWeb() as Boolean
	Property Orientamento() as integer
	Property Peso() as integer
	Property Preventivo() as integer
	Property PrezzoCalcolatoNetto() as decimal
	Property PrezzoCorriere() as decimal
	Property Profondita() as integer
	Property Qta() as integer
	Property Ricarico() as decimal
	Property Sconto() as decimal
	Property SorgenteCopertina() as string
	Property SorgenteFronte() as string
	Property SorgenteRetro() as string
	Property Stato() as integer
	Property StatoWeb() as integer
	Property TipoConsegna() as integer
	Property TipoRetro() as integer
	Property TotaleIva() as decimal
	Property TotaleNetto() as decimal
	Property TotaleOrdine() as decimal
	Property UsaNomeLavoroInFattura() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class OrdineWeb
		Public Shared ReadOnly Property IdOrdine As New LUNA.LunaFieldName("IdOrdine")
		Public Shared ReadOnly Property Altezza As New LUNA.LunaFieldName("Altezza")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property Anteprima As New LUNA.LunaFieldName("Anteprima")
		Public Shared ReadOnly Property ConsegnaGarantita As New LUNA.LunaFieldName("ConsegnaGarantita")
		Public Shared ReadOnly Property ConsegnaGarantitaDa As New LUNA.LunaFieldName("ConsegnaGarantitaDa")
		Public Shared ReadOnly Property DataCambioStato As New LUNA.LunaFieldName("DataCambioStato")
		Public Shared ReadOnly Property DataIns As New LUNA.LunaFieldName("DataIns")
		Public Shared ReadOnly Property DataPrevConsegna As New LUNA.LunaFieldName("DataPrevConsegna")
		Public Shared ReadOnly Property DataPrevProduzione As New LUNA.LunaFieldName("DataPrevProduzione")
		Public Shared ReadOnly Property ExtraData As New LUNA.LunaFieldName("ExtraData")
		Public Shared ReadOnly Property IdCons As New LUNA.LunaFieldName("IdCons")
		Public Shared ReadOnly Property IdCorriere As New LUNA.LunaFieldName("IdCorriere")
		Public Shared ReadOnly Property IdCoupon As New LUNA.LunaFieldName("IdCoupon")
		Public Shared ReadOnly Property IdIndirizzo As New LUNA.LunaFieldName("IdIndirizzo")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdMacchinarioProduzioneUtilizzato As New LUNA.LunaFieldName("IdMacchinarioProduzioneUtilizzato")
		Public Shared ReadOnly Property IdMailPreventivo As New LUNA.LunaFieldName("IdMailPreventivo")
		Public Shared ReadOnly Property IdOrdineInt As New LUNA.LunaFieldName("IdOrdineInt")
		Public Shared ReadOnly Property IdPromo As New LUNA.LunaFieldName("IdPromo")
		Public Shared ReadOnly Property IdTipoFustella As New LUNA.LunaFieldName("IdTipoFustella")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property InseritoDa As New LUNA.LunaFieldName("InseritoDa")
		Public Shared ReadOnly Property Larghezza As New LUNA.LunaFieldName("Larghezza")
		Public Shared ReadOnly Property Lavorazioni As New LUNA.LunaFieldName("Lavorazioni")
		Public Shared ReadOnly Property Mq As New LUNA.LunaFieldName("Mq")
		Public Shared ReadOnly Property Nfogli As New LUNA.LunaFieldName("Nfogli")
		Public Shared ReadOnly Property NoEmailDemone As New LUNA.LunaFieldName("NoEmailDemone")
		Public Shared ReadOnly Property NomeLavoro As New LUNA.LunaFieldName("NomeLavoro")
		Public Shared ReadOnly Property NumeroColli As New LUNA.LunaFieldName("NumeroColli")
		Public Shared ReadOnly Property OrdineInOmaggio As New LUNA.LunaFieldName("OrdineInOmaggio")
		Public Shared ReadOnly Property OrdineWeb As New LUNA.LunaFieldName("OrdineWeb")
		Public Shared ReadOnly Property Orientamento As New LUNA.LunaFieldName("Orientamento")
		Public Shared ReadOnly Property Peso As New LUNA.LunaFieldName("Peso")
		Public Shared ReadOnly Property Preventivo As New LUNA.LunaFieldName("Preventivo")
		Public Shared ReadOnly Property PrezzoCalcolatoNetto As New LUNA.LunaFieldName("PrezzoCalcolatoNetto")
		Public Shared ReadOnly Property PrezzoCorriere As New LUNA.LunaFieldName("PrezzoCorriere")
		Public Shared ReadOnly Property Profondita As New LUNA.LunaFieldName("Profondita")
		Public Shared ReadOnly Property Qta As New LUNA.LunaFieldName("Qta")
		Public Shared ReadOnly Property Ricarico As New LUNA.LunaFieldName("Ricarico")
		Public Shared ReadOnly Property Sconto As New LUNA.LunaFieldName("Sconto")
		Public Shared ReadOnly Property SorgenteCopertina As New LUNA.LunaFieldName("SorgenteCopertina")
		Public Shared ReadOnly Property SorgenteFronte As New LUNA.LunaFieldName("SorgenteFronte")
		Public Shared ReadOnly Property SorgenteRetro As New LUNA.LunaFieldName("SorgenteRetro")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property StatoWeb As New LUNA.LunaFieldName("StatoWeb")
		Public Shared ReadOnly Property TipoConsegna As New LUNA.LunaFieldName("TipoConsegna")
		Public Shared ReadOnly Property TipoRetro As New LUNA.LunaFieldName("TipoRetro")
		Public Shared ReadOnly Property TotaleIva As New LUNA.LunaFieldName("TotaleIva")
		Public Shared ReadOnly Property TotaleNetto As New LUNA.LunaFieldName("TotaleNetto")
		Public Shared ReadOnly Property TotaleOrdine As New LUNA.LunaFieldName("TotaleOrdine")
		Public Shared ReadOnly Property UsaNomeLavoroInFattura As New LUNA.LunaFieldName("UsaNomeLavoroInFattura")
	End Class

End Class