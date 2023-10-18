#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 11/01/2021 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_contabricavi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Ricavo
	Inherits LUNA.LunaBaseClassEntity
	Implements _IRicavo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IRicavo.FillFromDataRecord
		IdRicavo = myRecord("IdRicavo")
		if not myRecord("CostoCorr") is DBNull.Value then CostoCorr = myRecord("CostoCorr")
		if not myRecord("CounterStampe") is DBNull.Value then CounterStampe = myRecord("CounterStampe")
		if not myRecord("DataOraInvio") is DBNull.Value then DataOraInvio = myRecord("DataOraInvio")
		if not myRecord("Dataprevpagam") is DBNull.Value then Dataprevpagam = myRecord("Dataprevpagam")
		if not myRecord("DataRicavo") is DBNull.Value then DataRicavo = myRecord("DataRicavo")
		if not myRecord("DataUltimoCambioStatoFE") is DBNull.Value then DataUltimoCambioStatoFE = myRecord("DataUltimoCambioStatoFE")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("DocXML") is DBNull.Value then DocXML = myRecord("DocXML")
		if not myRecord("EsigibilitaIva") is DBNull.Value then EsigibilitaIva = myRecord("EsigibilitaIva")
		if not myRecord("IdAzienda") is DBNull.Value then IdAzienda = myRecord("IdAzienda")
		if not myRecord("IdCat") is DBNull.Value then IdCat = myRecord("IdCat")
		if not myRecord("IdCorr") is DBNull.Value then IdCorr = myRecord("IdCorr")
		if not myRecord("IdDocRif") is DBNull.Value then IdDocRif = myRecord("IdDocRif")
		if not myRecord("IdentificativoSdI") is DBNull.Value then IdentificativoSdI = myRecord("IdentificativoSdI")
		if not myRecord("IdFatturaNotaDiCredito") is DBNull.Value then IdFatturaNotaDiCredito = myRecord("IdFatturaNotaDiCredito")
		if not myRecord("IdMessaggioFE") is DBNull.Value then IdMessaggioFE = myRecord("IdMessaggioFE")
		if not myRecord("Idpagamento") is DBNull.Value then Idpagamento = myRecord("Idpagamento")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("IdRubIntestatario") is DBNull.Value then IdRubIntestatario = myRecord("IdRubIntestatario")
		if not myRecord("idstato") is DBNull.Value then idstato = myRecord("idstato")
		if not myRecord("Importo") is DBNull.Value then Importo = myRecord("Importo")
		if not myRecord("InfoFE") is DBNull.Value then InfoFE = myRecord("InfoFE")
		if not myRecord("Iva") is DBNull.Value then Iva = myRecord("Iva")
		if not myRecord("NaturaEsclIva") is DBNull.Value then NaturaEsclIva = myRecord("NaturaEsclIva")
		if not myRecord("NumColli") is DBNull.Value then NumColli = myRecord("NumColli")
		if not myRecord("Numero") is DBNull.Value then Numero = myRecord("Numero")
		if not myRecord("pCap") is DBNull.Value then pCap = myRecord("pCap")
		if not myRecord("pCitta") is DBNull.Value then pCitta = myRecord("pCitta")
		if not myRecord("PercIva") is DBNull.Value then PercIva = myRecord("PercIva")
		if not myRecord("Peso") is DBNull.Value then Peso = myRecord("Peso")
		if not myRecord("pIndCons") is DBNull.Value then pIndCons = myRecord("pIndCons")
		if not myRecord("pIndirizzo") is DBNull.Value then pIndirizzo = myRecord("pIndirizzo")
		if not myRecord("pIva") is DBNull.Value then pIva = myRecord("pIva")
		if not myRecord("pPagamento") is DBNull.Value then pPagamento = myRecord("pPagamento")
		if not myRecord("pRagSoc") is DBNull.Value then pRagSoc = myRecord("pRagSoc")
		if not myRecord("RicevutaXML") is DBNull.Value then RicevutaXML = myRecord("RicevutaXML")
		if not myRecord("Scansione") is DBNull.Value then Scansione = myRecord("Scansione")
		if not myRecord("Scansione1") is DBNull.Value then Scansione1 = myRecord("Scansione1")
		if not myRecord("Scansione2") is DBNull.Value then Scansione2 = myRecord("Scansione2")
		if not myRecord("Scansione3") is DBNull.Value then Scansione3 = myRecord("Scansione3")
		if not myRecord("Scansione4") is DBNull.Value then Scansione4 = myRecord("Scansione4")
		if not myRecord("StatoFE") is DBNull.Value then StatoFE = myRecord("StatoFE")
		if not myRecord("StatoIncasso") is DBNull.Value then StatoIncasso = myRecord("StatoIncasso")
		if not myRecord("Tipo") is DBNull.Value then Tipo = myRecord("Tipo")
		if not myRecord("Totale") is DBNull.Value then Totale = myRecord("Totale")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Ricavo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(RicaviDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Ricavo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdRicavo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoCorr As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CounterStampe As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataOraInvio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Dataprevpagam As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataRicavo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataUltimoCambioStatoFE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DocXML As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property EsigibilitaIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdAzienda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorr As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdDocRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdentificativoSdI As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFatturaNotaDiCredito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMessaggioFE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Idpagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRubIntestatario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property idstato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Importo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property InfoFE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Iva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NaturaEsclIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumColli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Numero As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property pCap As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property pCitta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Peso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property pIndCons As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property pIndirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property pIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property pPagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property pRagSoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RicevutaXML As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StatoFE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StatoIncasso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Totale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdRicavo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoCorr = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CounterStampe = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataOraInvio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Dataprevpagam = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataRicavo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataUltimoCambioStatoFE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DocXML = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.EsigibilitaIva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdAzienda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorr = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdDocRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdentificativoSdI = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFatturaNotaDiCredito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMessaggioFE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Idpagamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRubIntestatario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.idstato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Importo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.InfoFE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Iva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NaturaEsclIva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumColli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Numero = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.pCap = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.pCitta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercIva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Peso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.pIndCons = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.pIndirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.pIva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.pPagamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.pRagSoc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RicevutaXML = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StatoFE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StatoIncasso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Totale = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdRicavo as integer  = 0 
	Public Overridable Property IdRicavo() as integer  Implements _IRicavo.IdRicavo
		Get
			Return _IdRicavo
		End Get
		Set (byval value as integer)
			If _IdRicavo <> value Then
				IsChanged = True
				WhatIsChanged.IdRicavo = True
				_IdRicavo = value
			End If
		End Set
	End property 

	Protected _CostoCorr as decimal  = 0 
	Public Overridable Property CostoCorr() as decimal  Implements _IRicavo.CostoCorr
		Get
			Return _CostoCorr
		End Get
		Set (byval value as decimal)
			If _CostoCorr <> value Then
				IsChanged = True
				WhatIsChanged.CostoCorr = True
				_CostoCorr = value
			End If
		End Set
	End property 

	Protected _CounterStampe as integer  = 0 
	Public Overridable Property CounterStampe() as integer  Implements _IRicavo.CounterStampe
		Get
			Return _CounterStampe
		End Get
		Set (byval value as integer)
			If _CounterStampe <> value Then
				IsChanged = True
				WhatIsChanged.CounterStampe = True
				_CounterStampe = value
			End If
		End Set
	End property 

	Protected _DataOraInvio as DateTime  = Nothing 
	Public Overridable Property DataOraInvio() as DateTime  Implements _IRicavo.DataOraInvio
		Get
			Return _DataOraInvio
		End Get
		Set (byval value as DateTime)
			If _DataOraInvio <> value Then
				IsChanged = True
				WhatIsChanged.DataOraInvio = True
				_DataOraInvio = value
			End If
		End Set
	End property 

	Protected _Dataprevpagam as DateTime  = Nothing 
	Public Overridable Property Dataprevpagam() as DateTime  Implements _IRicavo.Dataprevpagam
		Get
			Return _Dataprevpagam
		End Get
		Set (byval value as DateTime)
			If _Dataprevpagam <> value Then
				IsChanged = True
				WhatIsChanged.Dataprevpagam = True
				_Dataprevpagam = value
			End If
		End Set
	End property 

	Protected _DataRicavo as DateTime  = Nothing 
	Public Overridable Property DataRicavo() as DateTime  Implements _IRicavo.DataRicavo
		Get
			Return _DataRicavo
		End Get
		Set (byval value as DateTime)
			If _DataRicavo <> value Then
				IsChanged = True
				WhatIsChanged.DataRicavo = True
				_DataRicavo = value
			End If
		End Set
	End property 

	Protected _DataUltimoCambioStatoFE as DateTime  = Nothing 
	Public Overridable Property DataUltimoCambioStatoFE() as DateTime  Implements _IRicavo.DataUltimoCambioStatoFE
		Get
			Return _DataUltimoCambioStatoFE
		End Get
		Set (byval value as DateTime)
			If _DataUltimoCambioStatoFE <> value Then
				IsChanged = True
				WhatIsChanged.DataUltimoCambioStatoFE = True
				_DataUltimoCambioStatoFE = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IRicavo.Descrizione
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

	Protected _DocXML as string  = "" 
	Public Overridable Property DocXML() as string  Implements _IRicavo.DocXML
		Get
			Return _DocXML
		End Get
		Set (byval value as string)
			If _DocXML <> value Then
				IsChanged = True
				WhatIsChanged.DocXML = True
				_DocXML = value
			End If
		End Set
	End property 

	Protected _EsigibilitaIva as integer  = 0 
	Public Overridable Property EsigibilitaIva() as integer  Implements _IRicavo.EsigibilitaIva
		Get
			Return _EsigibilitaIva
		End Get
		Set (byval value as integer)
			If _EsigibilitaIva <> value Then
				IsChanged = True
				WhatIsChanged.EsigibilitaIva = True
				_EsigibilitaIva = value
			End If
		End Set
	End property 

	Protected _IdAzienda as integer  = 0 
	Public Overridable Property IdAzienda() as integer  Implements _IRicavo.IdAzienda
		Get
			Return _IdAzienda
		End Get
		Set (byval value as integer)
			If _IdAzienda <> value Then
				IsChanged = True
				WhatIsChanged.IdAzienda = True
				_IdAzienda = value
			End If
		End Set
	End property 

	Protected _IdCat as integer  = 0 
	Public Overridable Property IdCat() as integer  Implements _IRicavo.IdCat
		Get
			Return _IdCat
		End Get
		Set (byval value as integer)
			If _IdCat <> value Then
				IsChanged = True
				WhatIsChanged.IdCat = True
				_IdCat = value
			End If
		End Set
	End property 

	Protected _IdCorr as integer  = 0 
	Public Overridable Property IdCorr() as integer  Implements _IRicavo.IdCorr
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

	Protected _IdDocRif as integer  = 0 
	Public Overridable Property IdDocRif() as integer  Implements _IRicavo.IdDocRif
		Get
			Return _IdDocRif
		End Get
		Set (byval value as integer)
			If _IdDocRif <> value Then
				IsChanged = True
				WhatIsChanged.IdDocRif = True
				_IdDocRif = value
			End If
		End Set
	End property 

	Protected _IdentificativoSdI as string  = "" 
	Public Overridable Property IdentificativoSdI() as string  Implements _IRicavo.IdentificativoSdI
		Get
			Return _IdentificativoSdI
		End Get
		Set (byval value as string)
			If _IdentificativoSdI <> value Then
				IsChanged = True
				WhatIsChanged.IdentificativoSdI = True
				_IdentificativoSdI = value
			End If
		End Set
	End property 

	Protected _IdFatturaNotaDiCredito as integer  = 0 
	Public Overridable Property IdFatturaNotaDiCredito() as integer  Implements _IRicavo.IdFatturaNotaDiCredito
		Get
			Return _IdFatturaNotaDiCredito
		End Get
		Set (byval value as integer)
			If _IdFatturaNotaDiCredito <> value Then
				IsChanged = True
				WhatIsChanged.IdFatturaNotaDiCredito = True
				_IdFatturaNotaDiCredito = value
			End If
		End Set
	End property 

	Protected _IdMessaggioFE as string  = "" 
	Public Overridable Property IdMessaggioFE() as string  Implements _IRicavo.IdMessaggioFE
		Get
			Return _IdMessaggioFE
		End Get
		Set (byval value as string)
			If _IdMessaggioFE <> value Then
				IsChanged = True
				WhatIsChanged.IdMessaggioFE = True
				_IdMessaggioFE = value
			End If
		End Set
	End property 

	Protected _Idpagamento as integer  = 0 
	Public Overridable Property Idpagamento() as integer  Implements _IRicavo.Idpagamento
		Get
			Return _Idpagamento
		End Get
		Set (byval value as integer)
			If _Idpagamento <> value Then
				IsChanged = True
				WhatIsChanged.Idpagamento = True
				_Idpagamento = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IRicavo.IdRub
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

	Protected _IdRubIntestatario as integer  = 0 
	Public Overridable Property IdRubIntestatario() as integer  Implements _IRicavo.IdRubIntestatario
		Get
			Return _IdRubIntestatario
		End Get
		Set (byval value as integer)
			If _IdRubIntestatario <> value Then
				IsChanged = True
				WhatIsChanged.IdRubIntestatario = True
				_IdRubIntestatario = value
			End If
		End Set
	End property 

	Protected _idstato as integer  = 0 
	Public Overridable Property idstato() as integer  Implements _IRicavo.idstato
		Get
			Return _idstato
		End Get
		Set (byval value as integer)
			If _idstato <> value Then
				IsChanged = True
				WhatIsChanged.idstato = True
				_idstato = value
			End If
		End Set
	End property 

	Protected _Importo as decimal  = 0 
	Public Overridable Property Importo() as decimal  Implements _IRicavo.Importo
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

	Protected _InfoFE as string  = "" 
	Public Overridable Property InfoFE() as string  Implements _IRicavo.InfoFE
		Get
			Return _InfoFE
		End Get
		Set (byval value as string)
			If _InfoFE <> value Then
				IsChanged = True
				WhatIsChanged.InfoFE = True
				_InfoFE = value
			End If
		End Set
	End property 

	Protected _Iva as decimal  = 0 
	Public Overridable Property Iva() as decimal  Implements _IRicavo.Iva
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

	Protected _NaturaEsclIva as string  = "" 
	Public Overridable Property NaturaEsclIva() as string  Implements _IRicavo.NaturaEsclIva
		Get
			Return _NaturaEsclIva
		End Get
		Set (byval value as string)
			If _NaturaEsclIva <> value Then
				IsChanged = True
				WhatIsChanged.NaturaEsclIva = True
				_NaturaEsclIva = value
			End If
		End Set
	End property 

	Protected _NumColli as integer  = 0 
	Public Overridable Property NumColli() as integer  Implements _IRicavo.NumColli
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

	Protected _Numero as integer  = 0 
	Public Overridable Property Numero() as integer  Implements _IRicavo.Numero
		Get
			Return _Numero
		End Get
		Set (byval value as integer)
			If _Numero <> value Then
				IsChanged = True
				WhatIsChanged.Numero = True
				_Numero = value
			End If
		End Set
	End property 

	Protected _pCap as string  = "" 
	Public Overridable Property pCap() as string  Implements _IRicavo.pCap
		Get
			Return _pCap
		End Get
		Set (byval value as string)
			If _pCap <> value Then
				IsChanged = True
				WhatIsChanged.pCap = True
				_pCap = value
			End If
		End Set
	End property 

	Protected _pCitta as string  = "" 
	Public Overridable Property pCitta() as string  Implements _IRicavo.pCitta
		Get
			Return _pCitta
		End Get
		Set (byval value as string)
			If _pCitta <> value Then
				IsChanged = True
				WhatIsChanged.pCitta = True
				_pCitta = value
			End If
		End Set
	End property 

	Protected _PercIva as integer  = 0 
	Public Overridable Property PercIva() as integer  Implements _IRicavo.PercIva
		Get
			Return _PercIva
		End Get
		Set (byval value as integer)
			If _PercIva <> value Then
				IsChanged = True
				WhatIsChanged.PercIva = True
				_PercIva = value
			End If
		End Set
	End property 

	Protected _Peso as Single  = 0 
	Public Overridable Property Peso() as Single  Implements _IRicavo.Peso
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

	Protected _pIndCons as string  = "" 
	Public Overridable Property pIndCons() as string  Implements _IRicavo.pIndCons
		Get
			Return _pIndCons
		End Get
		Set (byval value as string)
			If _pIndCons <> value Then
				IsChanged = True
				WhatIsChanged.pIndCons = True
				_pIndCons = value
			End If
		End Set
	End property 

	Protected _pIndirizzo as string  = "" 
	Public Overridable Property pIndirizzo() as string  Implements _IRicavo.pIndirizzo
		Get
			Return _pIndirizzo
		End Get
		Set (byval value as string)
			If _pIndirizzo <> value Then
				IsChanged = True
				WhatIsChanged.pIndirizzo = True
				_pIndirizzo = value
			End If
		End Set
	End property 

	Protected _pIva as string  = "" 
	Public Overridable Property pIva() as string  Implements _IRicavo.pIva
		Get
			Return _pIva
		End Get
		Set (byval value as string)
			If _pIva <> value Then
				IsChanged = True
				WhatIsChanged.pIva = True
				_pIva = value
			End If
		End Set
	End property 

	Protected _pPagamento as string  = "" 
	Public Overridable Property pPagamento() as string  Implements _IRicavo.pPagamento
		Get
			Return _pPagamento
		End Get
		Set (byval value as string)
			If _pPagamento <> value Then
				IsChanged = True
				WhatIsChanged.pPagamento = True
				_pPagamento = value
			End If
		End Set
	End property 

	Protected _pRagSoc as string  = "" 
	Public Overridable Property pRagSoc() as string  Implements _IRicavo.pRagSoc
		Get
			Return _pRagSoc
		End Get
		Set (byval value as string)
			If _pRagSoc <> value Then
				IsChanged = True
				WhatIsChanged.pRagSoc = True
				_pRagSoc = value
			End If
		End Set
	End property 

	Protected _RicevutaXML as string  = "" 
	Public Overridable Property RicevutaXML() as string  Implements _IRicavo.RicevutaXML
		Get
			Return _RicevutaXML
		End Get
		Set (byval value as string)
			If _RicevutaXML <> value Then
				IsChanged = True
				WhatIsChanged.RicevutaXML = True
				_RicevutaXML = value
			End If
		End Set
	End property 

	Protected _Scansione as string  = "" 
	Public Overridable Property Scansione() as string  Implements _IRicavo.Scansione
		Get
			Return _Scansione
		End Get
		Set (byval value as string)
			If _Scansione <> value Then
				IsChanged = True
				WhatIsChanged.Scansione = True
				_Scansione = value
			End If
		End Set
	End property 

	Protected _Scansione1 as string  = "" 
	Public Overridable Property Scansione1() as string  Implements _IRicavo.Scansione1
		Get
			Return _Scansione1
		End Get
		Set (byval value as string)
			If _Scansione1 <> value Then
				IsChanged = True
				WhatIsChanged.Scansione1 = True
				_Scansione1 = value
			End If
		End Set
	End property 

	Protected _Scansione2 as string  = "" 
	Public Overridable Property Scansione2() as string  Implements _IRicavo.Scansione2
		Get
			Return _Scansione2
		End Get
		Set (byval value as string)
			If _Scansione2 <> value Then
				IsChanged = True
				WhatIsChanged.Scansione2 = True
				_Scansione2 = value
			End If
		End Set
	End property 

	Protected _Scansione3 as string  = "" 
	Public Overridable Property Scansione3() as string  Implements _IRicavo.Scansione3
		Get
			Return _Scansione3
		End Get
		Set (byval value as string)
			If _Scansione3 <> value Then
				IsChanged = True
				WhatIsChanged.Scansione3 = True
				_Scansione3 = value
			End If
		End Set
	End property 

	Protected _Scansione4 as string  = "" 
	Public Overridable Property Scansione4() as string  Implements _IRicavo.Scansione4
		Get
			Return _Scansione4
		End Get
		Set (byval value as string)
			If _Scansione4 <> value Then
				IsChanged = True
				WhatIsChanged.Scansione4 = True
				_Scansione4 = value
			End If
		End Set
	End property 

	Protected _StatoFE as integer  = 0 
	Public Overridable Property StatoFE() as integer  Implements _IRicavo.StatoFE
		Get
			Return _StatoFE
		End Get
		Set (byval value as integer)
			If _StatoFE <> value Then
				IsChanged = True
				WhatIsChanged.StatoFE = True
				_StatoFE = value
			End If
		End Set
	End property 

	Protected _StatoIncasso as integer  = 0 
	Public Overridable Property StatoIncasso() as integer  Implements _IRicavo.StatoIncasso
		Get
			Return _StatoIncasso
		End Get
		Set (byval value as integer)
			If _StatoIncasso <> value Then
				IsChanged = True
				WhatIsChanged.StatoIncasso = True
				_StatoIncasso = value
			End If
		End Set
	End property 

	Protected _Tipo as integer  = 0 
	Public Overridable Property Tipo() as integer  Implements _IRicavo.Tipo
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

	Protected _Totale as decimal  = 0 
	Public Overridable Property Totale() as decimal  Implements _IRicavo.Totale
		Get
			Return _Totale
		End Get
		Set (byval value as decimal)
			If _Totale <> value Then
				IsChanged = True
				WhatIsChanged.Totale = True
				_Totale = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Ricavo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Ricavo = Manager.Read(Id)
				_IdRicavo = int.IdRicavo
				_CostoCorr = int.CostoCorr
				_CounterStampe = int.CounterStampe
				_DataOraInvio = int.DataOraInvio
				_Dataprevpagam = int.Dataprevpagam
				_DataRicavo = int.DataRicavo
				_DataUltimoCambioStatoFE = int.DataUltimoCambioStatoFE
				_Descrizione = int.Descrizione
				_DocXML = int.DocXML
				_EsigibilitaIva = int.EsigibilitaIva
				_IdAzienda = int.IdAzienda
				_IdCat = int.IdCat
				_IdCorr = int.IdCorr
				_IdDocRif = int.IdDocRif
				_IdentificativoSdI = int.IdentificativoSdI
				_IdFatturaNotaDiCredito = int.IdFatturaNotaDiCredito
				_IdMessaggioFE = int.IdMessaggioFE
				_Idpagamento = int.Idpagamento
				_IdRub = int.IdRub
				_IdRubIntestatario = int.IdRubIntestatario
				_idstato = int.idstato
				_Importo = int.Importo
				_InfoFE = int.InfoFE
				_Iva = int.Iva
				_NaturaEsclIva = int.NaturaEsclIva
				_NumColli = int.NumColli
				_Numero = int.Numero
				_pCap = int.pCap
				_pCitta = int.pCitta
				_PercIva = int.PercIva
				_Peso = int.Peso
				_pIndCons = int.pIndCons
				_pIndirizzo = int.pIndirizzo
				_pIva = int.pIva
				_pPagamento = int.pPagamento
				_pRagSoc = int.pRagSoc
				_RicevutaXML = int.RicevutaXML
				_Scansione = int.Scansione
				_Scansione1 = int.Scansione1
				_Scansione2 = int.Scansione2
				_Scansione3 = int.Scansione3
				_Scansione4 = int.Scansione4
				_StatoFE = int.StatoFE
				_StatoIncasso = int.StatoIncasso
				_Tipo = int.Tipo
				_Totale = int.Totale
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
        If IdRicavo Then
            ris = Read(IdRicavo)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an Ricavo on DB.
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
		if _DocXML.Length > 2147483647 then Ris = False
		if _IdentificativoSdI.Length > 20 then Ris = False
		if _IdMessaggioFE.Length > 255 then Ris = False
		if _InfoFE.Length > 2147483647 then Ris = False
		if _NaturaEsclIva.Length > 4 then Ris = False
		if _pCap.Length > 5 then Ris = False
		if _pCitta.Length > 255 then Ris = False
		if _pIndCons.Length > 255 then Ris = False
		if _pIndirizzo.Length > 255 then Ris = False
		if _pIva.Length > 20 then Ris = False
		if _pPagamento.Length > 255 then Ris = False
		if _pRagSoc.Length > 255 then Ris = False
		if _RicevutaXML.Length > 2147483647 then Ris = False
		if _Scansione.Length > 255 then Ris = False
		if _Scansione1.Length > 255 then Ris = False
		if _Scansione2.Length > 255 then Ris = False
		if _Scansione3.Length > 255 then Ris = False
		if _Scansione4.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_contabricavi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IRicavo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdRicavo() as integer
	Property CostoCorr() as decimal
	Property CounterStampe() as integer
	Property DataOraInvio() as DateTime
	Property Dataprevpagam() as DateTime
	Property DataRicavo() as DateTime
	Property DataUltimoCambioStatoFE() as DateTime
	Property Descrizione() as string
	Property DocXML() as string
	Property EsigibilitaIva() as integer
	Property IdAzienda() as integer
	Property IdCat() as integer
	Property IdCorr() as integer
	Property IdDocRif() as integer
	Property IdentificativoSdI() as string
	Property IdFatturaNotaDiCredito() as integer
	Property IdMessaggioFE() as string
	Property Idpagamento() as integer
	Property IdRub() as integer
	Property IdRubIntestatario() as integer
	Property idstato() as integer
	Property Importo() as decimal
	Property InfoFE() as string
	Property Iva() as decimal
	Property NaturaEsclIva() as string
	Property NumColli() as integer
	Property Numero() as integer
	Property pCap() as string
	Property pCitta() as string
	Property PercIva() as integer
	Property Peso() as Single
	Property pIndCons() as string
	Property pIndirizzo() as string
	Property pIva() as string
	Property pPagamento() as string
	Property pRagSoc() as string
	Property RicevutaXML() as string
	Property Scansione() as string
	Property Scansione1() as string
	Property Scansione2() as string
	Property Scansione3() as string
	Property Scansione4() as string
	Property StatoFE() as integer
	Property StatoIncasso() as integer
	Property Tipo() as integer
	Property Totale() as decimal

#End Region

End Interface

Partial Public Class LFM

	Public Class Ricavo
		Public Shared ReadOnly Property IdRicavo As New LUNA.LunaFieldName("IdRicavo")
		Public Shared ReadOnly Property CostoCorr As New LUNA.LunaFieldName("CostoCorr")
		Public Shared ReadOnly Property CounterStampe As New LUNA.LunaFieldName("CounterStampe")
		Public Shared ReadOnly Property DataOraInvio As New LUNA.LunaFieldName("DataOraInvio")
		Public Shared ReadOnly Property Dataprevpagam As New LUNA.LunaFieldName("Dataprevpagam")
		Public Shared ReadOnly Property DataRicavo As New LUNA.LunaFieldName("DataRicavo")
		Public Shared ReadOnly Property DataUltimoCambioStatoFE As New LUNA.LunaFieldName("DataUltimoCambioStatoFE")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property DocXML As New LUNA.LunaFieldName("DocXML")
		Public Shared ReadOnly Property EsigibilitaIva As New LUNA.LunaFieldName("EsigibilitaIva")
		Public Shared ReadOnly Property IdAzienda As New LUNA.LunaFieldName("IdAzienda")
		Public Shared ReadOnly Property IdCat As New LUNA.LunaFieldName("IdCat")
		Public Shared ReadOnly Property IdCorr As New LUNA.LunaFieldName("IdCorr")
		Public Shared ReadOnly Property IdDocRif As New LUNA.LunaFieldName("IdDocRif")
		Public Shared ReadOnly Property IdentificativoSdI As New LUNA.LunaFieldName("IdentificativoSdI")
		Public Shared ReadOnly Property IdFatturaNotaDiCredito As New LUNA.LunaFieldName("IdFatturaNotaDiCredito")
		Public Shared ReadOnly Property IdMessaggioFE As New LUNA.LunaFieldName("IdMessaggioFE")
		Public Shared ReadOnly Property Idpagamento As New LUNA.LunaFieldName("Idpagamento")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property IdRubIntestatario As New LUNA.LunaFieldName("IdRubIntestatario")
		Public Shared ReadOnly Property idstato As New LUNA.LunaFieldName("idstato")
		Public Shared ReadOnly Property Importo As New LUNA.LunaFieldName("Importo")
		Public Shared ReadOnly Property InfoFE As New LUNA.LunaFieldName("InfoFE")
		Public Shared ReadOnly Property Iva As New LUNA.LunaFieldName("Iva")
		Public Shared ReadOnly Property NaturaEsclIva As New LUNA.LunaFieldName("NaturaEsclIva")
		Public Shared ReadOnly Property NumColli As New LUNA.LunaFieldName("NumColli")
		Public Shared ReadOnly Property Numero As New LUNA.LunaFieldName("Numero")
		Public Shared ReadOnly Property pCap As New LUNA.LunaFieldName("pCap")
		Public Shared ReadOnly Property pCitta As New LUNA.LunaFieldName("pCitta")
		Public Shared ReadOnly Property PercIva As New LUNA.LunaFieldName("PercIva")
		Public Shared ReadOnly Property Peso As New LUNA.LunaFieldName("Peso")
		Public Shared ReadOnly Property pIndCons As New LUNA.LunaFieldName("pIndCons")
		Public Shared ReadOnly Property pIndirizzo As New LUNA.LunaFieldName("pIndirizzo")
		Public Shared ReadOnly Property pIva As New LUNA.LunaFieldName("pIva")
		Public Shared ReadOnly Property pPagamento As New LUNA.LunaFieldName("pPagamento")
		Public Shared ReadOnly Property pRagSoc As New LUNA.LunaFieldName("pRagSoc")
		Public Shared ReadOnly Property RicevutaXML As New LUNA.LunaFieldName("RicevutaXML")
		Public Shared ReadOnly Property Scansione As New LUNA.LunaFieldName("Scansione")
		Public Shared ReadOnly Property Scansione1 As New LUNA.LunaFieldName("Scansione1")
		Public Shared ReadOnly Property Scansione2 As New LUNA.LunaFieldName("Scansione2")
		Public Shared ReadOnly Property Scansione3 As New LUNA.LunaFieldName("Scansione3")
		Public Shared ReadOnly Property Scansione4 As New LUNA.LunaFieldName("Scansione4")
		Public Shared ReadOnly Property StatoFE As New LUNA.LunaFieldName("StatoFE")
		Public Shared ReadOnly Property StatoIncasso As New LUNA.LunaFieldName("StatoIncasso")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
		Public Shared ReadOnly Property Totale As New LUNA.LunaFieldName("Totale")
	End Class

End Class