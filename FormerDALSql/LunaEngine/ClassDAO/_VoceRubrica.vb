#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 17/12/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_rubrica
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _VoceRubrica
	Inherits LUNA.LunaBaseClassEntity
	Implements _IVoceRubrica
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IVoceRubrica.FillFromDataRecord
		IdRub = myRecord("IdRub")
		if not myRecord("AbilitaInserimentoManualeDoc") is DBNull.Value then AbilitaInserimentoManualeDoc = myRecord("AbilitaInserimentoManualeDoc")
		if not myRecord("AltroTel") is DBNull.Value then AltroTel = myRecord("AltroTel")
		if not myRecord("AltroTelRif") is DBNull.Value then AltroTelRif = myRecord("AltroTelRif")
		if not myRecord("AssRilIntMitt") is DBNull.Value then AssRilIntMitt = myRecord("AssRilIntMitt")
		if not myRecord("BigliettoVisita") is DBNull.Value then BigliettoVisita = myRecord("BigliettoVisita")
		if not myRecord("CAP") is DBNull.Value then CAP = myRecord("CAP")
		if not myRecord("Cellulare") is DBNull.Value then Cellulare = myRecord("Cellulare")
		if not myRecord("CellulareRif") is DBNull.Value then CellulareRif = myRecord("CellulareRif")
		if not myRecord("Citta") is DBNull.Value then Citta = myRecord("Citta")
		if not myRecord("CodFisc") is DBNull.Value then CodFisc = myRecord("CodFisc")
		if not myRecord("CodiceSDI") is DBNull.Value then CodiceSDI = myRecord("CodiceSDI")
		if not myRecord("Cognome") is DBNull.Value then Cognome = myRecord("Cognome")
		if not myRecord("DataIns") is DBNull.Value then DataIns = myRecord("DataIns")
		if not myRecord("DisattivaAccessoSito") is DBNull.Value then DisattivaAccessoSito = myRecord("DisattivaAccessoSito")
		if not myRecord("Email") is DBNull.Value then Email = myRecord("Email")
		if not myRecord("EmailAdmin") is DBNull.Value then EmailAdmin = myRecord("EmailAdmin")
		if not myRecord("EsigibilitaIva") is DBNull.Value then EsigibilitaIva = myRecord("EsigibilitaIva")
		if not myRecord("Fax") is DBNull.Value then Fax = myRecord("Fax")
		if not myRecord("FaxRif") is DBNull.Value then FaxRif = myRecord("FaxRif")
		if not myRecord("IdAge") is DBNull.Value then IdAge = myRecord("IdAge")
		if not myRecord("IdAziendaDefaultFatture") is DBNull.Value then IdAziendaDefaultFatture = myRecord("IdAziendaDefaultFatture")
		if not myRecord("IdCatContab") is DBNull.Value then IdCatContab = myRecord("IdCatContab")
		if not myRecord("IdCategoria") is DBNull.Value then IdCategoria = myRecord("IdCategoria")
		if not myRecord("IdComune") is DBNull.Value then IdComune = myRecord("IdComune")
		if not myRecord("IdCorriere") is DBNull.Value then IdCorriere = myRecord("IdCorriere")
		if not myRecord("IdNazione") is DBNull.Value then IdNazione = myRecord("IdNazione")
		if not myRecord("IdOld") is DBNull.Value then IdOld = myRecord("IdOld")
		if not myRecord("IdPagamento") is DBNull.Value then IdPagamento = myRecord("IdPagamento")
		if not myRecord("IdProvincia") is DBNull.Value then IdProvincia = myRecord("IdProvincia")
		if not myRecord("IdRubricaLinked") is DBNull.Value then IdRubricaLinked = myRecord("IdRubricaLinked")
		if not myRecord("IdTipoAttivita") is DBNull.Value then IdTipoAttivita = myRecord("IdTipoAttivita")
		if not myRecord("IdUtOnline") is DBNull.Value then IdUtOnline = myRecord("IdUtOnline")
		if not myRecord("IdZona") is DBNull.Value then IdZona = myRecord("IdZona")
		if not myRecord("IndCons") is DBNull.Value then IndCons = myRecord("IndCons")
		if not myRecord("Indirizzo") is DBNull.Value then Indirizzo = myRecord("Indirizzo")
		if not myRecord("InserimentoManualeFatture") is DBNull.Value then InserimentoManualeFatture = myRecord("InserimentoManualeFatture")
		if not myRecord("IsFornitore") is DBNull.Value then IsFornitore = myRecord("IsFornitore")
		if not myRecord("LastUpdate") is DBNull.Value then LastUpdate = myRecord("LastUpdate")
		if not myRecord("NoCheckDatiFisc") is DBNull.Value then NoCheckDatiFisc = myRecord("NoCheckDatiFisc")
		if not myRecord("NoEmail") is DBNull.Value then NoEmail = myRecord("NoEmail")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("NonCreareAutomaticamenteDocumentiDiCarico") is DBNull.Value then NonCreareAutomaticamenteDocumentiDiCarico = myRecord("NonCreareAutomaticamenteDocumentiDiCarico")
		if not myRecord("Pagamento") is DBNull.Value then Pagamento = myRecord("Pagamento")
		if not myRecord("Pec") is DBNull.Value then Pec = myRecord("Pec")
		if not myRecord("Piva") is DBNull.Value then Piva = myRecord("Piva")
		if not myRecord("PrefissoPIva") is DBNull.Value then PrefissoPIva = myRecord("PrefissoPIva")
		if not myRecord("Provincia") is DBNull.Value then Provincia = myRecord("Provincia")
		if not myRecord("RagSoc") is DBNull.Value then RagSoc = myRecord("RagSoc")
		if not myRecord("RegistraAutomaticamentePagamenti") is DBNull.Value then RegistraAutomaticamentePagamenti = myRecord("RegistraAutomaticamentePagamenti")
		if not myRecord("ScopertoMax") is DBNull.Value then ScopertoMax = myRecord("ScopertoMax")
		if not myRecord("SitoWeb") is DBNull.Value then SitoWeb = myRecord("SitoWeb")
		if not myRecord("Sorgente") is DBNull.Value then Sorgente = myRecord("Sorgente")
		if not myRecord("SorgenteStorico") is DBNull.Value then SorgenteStorico = myRecord("SorgenteStorico")
		if not myRecord("StampaAutomaticaDocumenti") is DBNull.Value then StampaAutomaticaDocumenti = myRecord("StampaAutomaticaDocumenti")
		if not myRecord("Status") is DBNull.Value then Status = myRecord("Status")
		if not myRecord("tag") is DBNull.Value then tag = myRecord("tag")
		if not myRecord("Tel") is DBNull.Value then Tel = myRecord("Tel")
		if not myRecord("TelRif") is DBNull.Value then TelRif = myRecord("TelRif")
		if not myRecord("Tipo") is DBNull.Value then Tipo = myRecord("Tipo")
		if not myRecord("TipoDoc") is DBNull.Value then TipoDoc = myRecord("TipoDoc")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of VoceRubrica)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(VociRubricaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of VoceRubrica))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AbilitaInserimentoManualeDoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AltroTel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AltroTelRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AssRilIntMitt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property BigliettoVisita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CAP As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cellulare As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CellulareRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Citta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodFisc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodiceSDI As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cognome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DisattivaAccessoSito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Email As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property EmailAdmin As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property EsigibilitaIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Fax As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FaxRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdAge As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdAziendaDefaultFatture As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatContab As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCategoria As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdComune As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdNazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOld As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProvincia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRubricaLinked As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoAttivita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUtOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdZona As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IndCons As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Indirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property InserimentoManualeFatture As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IsFornitore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LastUpdate As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoCheckDatiFisc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoEmail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NonCreareAutomaticamenteDocumentiDiCarico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Pagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Pec As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Piva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrefissoPIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Provincia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RagSoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RegistraAutomaticamentePagamenti As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ScopertoMax As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SitoWeb As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sorgente As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SorgenteStorico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StampaAutomaticaDocumenti As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Status As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property tag As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TelRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoDoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AbilitaInserimentoManualeDoc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AltroTel = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AltroTelRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AssRilIntMitt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.BigliettoVisita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CAP = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cellulare = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CellulareRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Citta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodFisc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodiceSDI = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cognome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DisattivaAccessoSito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Email = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.EmailAdmin = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.EsigibilitaIva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Fax = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FaxRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdAge = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdAziendaDefaultFatture = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatContab = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCategoria = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdComune = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdNazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOld = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPagamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProvincia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRubricaLinked = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoAttivita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUtOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdZona = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IndCons = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Indirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.InserimentoManualeFatture = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IsFornitore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LastUpdate = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoCheckDatiFisc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoEmail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NonCreareAutomaticamenteDocumentiDiCarico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Pagamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Pec = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Piva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrefissoPIva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Provincia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RagSoc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RegistraAutomaticamentePagamenti = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ScopertoMax = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SitoWeb = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sorgente = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SorgenteStorico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StampaAutomaticaDocumenti = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Status = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.tag = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tel = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TelRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoDoc = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IVoceRubrica.IdRub
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

	Protected _AbilitaInserimentoManualeDoc as integer  = 0 
	Public Overridable Property AbilitaInserimentoManualeDoc() as integer  Implements _IVoceRubrica.AbilitaInserimentoManualeDoc
		Get
			Return _AbilitaInserimentoManualeDoc
		End Get
		Set (byval value as integer)
			If _AbilitaInserimentoManualeDoc <> value Then
				IsChanged = True
				WhatIsChanged.AbilitaInserimentoManualeDoc = True
				_AbilitaInserimentoManualeDoc = value
			End If
		End Set
	End property 

	Protected _AltroTel as string  = "" 
	Public Overridable Property AltroTel() as string  Implements _IVoceRubrica.AltroTel
		Get
			Return _AltroTel
		End Get
		Set (byval value as string)
			If _AltroTel <> value Then
				IsChanged = True
				WhatIsChanged.AltroTel = True
				_AltroTel = value
			End If
		End Set
	End property 

	Protected _AltroTelRif as string  = "" 
	Public Overridable Property AltroTelRif() as string  Implements _IVoceRubrica.AltroTelRif
		Get
			Return _AltroTelRif
		End Get
		Set (byval value as string)
			If _AltroTelRif <> value Then
				IsChanged = True
				WhatIsChanged.AltroTelRif = True
				_AltroTelRif = value
			End If
		End Set
	End property 

	Protected _AssRilIntMitt as integer  = 0 
	Public Overridable Property AssRilIntMitt() as integer  Implements _IVoceRubrica.AssRilIntMitt
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

	Protected _BigliettoVisita as string  = "" 
	Public Overridable Property BigliettoVisita() as string  Implements _IVoceRubrica.BigliettoVisita
		Get
			Return _BigliettoVisita
		End Get
		Set (byval value as string)
			If _BigliettoVisita <> value Then
				IsChanged = True
				WhatIsChanged.BigliettoVisita = True
				_BigliettoVisita = value
			End If
		End Set
	End property 

	Protected _CAP as string  = "" 
	Public Overridable Property CAP() as string  Implements _IVoceRubrica.CAP
		Get
			Return _CAP
		End Get
		Set (byval value as string)
			If _CAP <> value Then
				IsChanged = True
				WhatIsChanged.CAP = True
				_CAP = value
			End If
		End Set
	End property 

	Protected _Cellulare as string  = "" 
	Public Overridable Property Cellulare() as string  Implements _IVoceRubrica.Cellulare
		Get
			Return _Cellulare
		End Get
		Set (byval value as string)
			If _Cellulare <> value Then
				IsChanged = True
				WhatIsChanged.Cellulare = True
				_Cellulare = value
			End If
		End Set
	End property 

	Protected _CellulareRif as string  = "" 
	Public Overridable Property CellulareRif() as string  Implements _IVoceRubrica.CellulareRif
		Get
			Return _CellulareRif
		End Get
		Set (byval value as string)
			If _CellulareRif <> value Then
				IsChanged = True
				WhatIsChanged.CellulareRif = True
				_CellulareRif = value
			End If
		End Set
	End property 

	Protected _Citta as string  = "" 
	Public Overridable Property Citta() as string  Implements _IVoceRubrica.Citta
		Get
			Return _Citta
		End Get
		Set (byval value as string)
			If _Citta <> value Then
				IsChanged = True
				WhatIsChanged.Citta = True
				_Citta = value
			End If
		End Set
	End property 

	Protected _CodFisc as string  = "" 
	Public Overridable Property CodFisc() as string  Implements _IVoceRubrica.CodFisc
		Get
			Return _CodFisc
		End Get
		Set (byval value as string)
			If _CodFisc <> value Then
				IsChanged = True
				WhatIsChanged.CodFisc = True
				_CodFisc = value
			End If
		End Set
	End property 

	Protected _CodiceSDI as string  = "" 
	Public Overridable Property CodiceSDI() as string  Implements _IVoceRubrica.CodiceSDI
		Get
			Return _CodiceSDI
		End Get
		Set (byval value as string)
			If _CodiceSDI <> value Then
				IsChanged = True
				WhatIsChanged.CodiceSDI = True
				_CodiceSDI = value
			End If
		End Set
	End property 

	Protected _Cognome as string  = "" 
	Public Overridable Property Cognome() as string  Implements _IVoceRubrica.Cognome
		Get
			Return _Cognome
		End Get
		Set (byval value as string)
			If _Cognome <> value Then
				IsChanged = True
				WhatIsChanged.Cognome = True
				_Cognome = value
			End If
		End Set
	End property 

	Protected _DataIns as DateTime  = Nothing 
	Public Overridable Property DataIns() as DateTime  Implements _IVoceRubrica.DataIns
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

	Protected _DisattivaAccessoSito as integer  = 0 
	Public Overridable Property DisattivaAccessoSito() as integer  Implements _IVoceRubrica.DisattivaAccessoSito
		Get
			Return _DisattivaAccessoSito
		End Get
		Set (byval value as integer)
			If _DisattivaAccessoSito <> value Then
				IsChanged = True
				WhatIsChanged.DisattivaAccessoSito = True
				_DisattivaAccessoSito = value
			End If
		End Set
	End property 

	Protected _Email as string  = "" 
	Public Overridable Property Email() as string  Implements _IVoceRubrica.Email
		Get
			Return _Email
		End Get
		Set (byval value as string)
			If _Email <> value Then
				IsChanged = True
				WhatIsChanged.Email = True
				_Email = value
			End If
		End Set
	End property 

	Protected _EmailAdmin as string  = "" 
	Public Overridable Property EmailAdmin() as string  Implements _IVoceRubrica.EmailAdmin
		Get
			Return _EmailAdmin
		End Get
		Set (byval value as string)
			If _EmailAdmin <> value Then
				IsChanged = True
				WhatIsChanged.EmailAdmin = True
				_EmailAdmin = value
			End If
		End Set
	End property 

	Protected _EsigibilitaIva as integer  = 0 
	Public Overridable Property EsigibilitaIva() as integer  Implements _IVoceRubrica.EsigibilitaIva
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

	Protected _Fax as string  = "" 
	Public Overridable Property Fax() as string  Implements _IVoceRubrica.Fax
		Get
			Return _Fax
		End Get
		Set (byval value as string)
			If _Fax <> value Then
				IsChanged = True
				WhatIsChanged.Fax = True
				_Fax = value
			End If
		End Set
	End property 

	Protected _FaxRif as string  = "" 
	Public Overridable Property FaxRif() as string  Implements _IVoceRubrica.FaxRif
		Get
			Return _FaxRif
		End Get
		Set (byval value as string)
			If _FaxRif <> value Then
				IsChanged = True
				WhatIsChanged.FaxRif = True
				_FaxRif = value
			End If
		End Set
	End property 

	Protected _IdAge as integer  = 0 
	Public Overridable Property IdAge() as integer  Implements _IVoceRubrica.IdAge
		Get
			Return _IdAge
		End Get
		Set (byval value as integer)
			If _IdAge <> value Then
				IsChanged = True
				WhatIsChanged.IdAge = True
				_IdAge = value
			End If
		End Set
	End property 

	Protected _IdAziendaDefaultFatture as integer  = 0 
	Public Overridable Property IdAziendaDefaultFatture() as integer  Implements _IVoceRubrica.IdAziendaDefaultFatture
		Get
			Return _IdAziendaDefaultFatture
		End Get
		Set (byval value as integer)
			If _IdAziendaDefaultFatture <> value Then
				IsChanged = True
				WhatIsChanged.IdAziendaDefaultFatture = True
				_IdAziendaDefaultFatture = value
			End If
		End Set
	End property 

	Protected _IdCatContab as integer  = 0 
	Public Overridable Property IdCatContab() as integer  Implements _IVoceRubrica.IdCatContab
		Get
			Return _IdCatContab
		End Get
		Set (byval value as integer)
			If _IdCatContab <> value Then
				IsChanged = True
				WhatIsChanged.IdCatContab = True
				_IdCatContab = value
			End If
		End Set
	End property 

	Protected _IdCategoria as integer  = 0 
	Public Overridable Property IdCategoria() as integer  Implements _IVoceRubrica.IdCategoria
		Get
			Return _IdCategoria
		End Get
		Set (byval value as integer)
			If _IdCategoria <> value Then
				IsChanged = True
				WhatIsChanged.IdCategoria = True
				_IdCategoria = value
			End If
		End Set
	End property 

	Protected _IdComune as integer  = 0 
	Public Overridable Property IdComune() as integer  Implements _IVoceRubrica.IdComune
		Get
			Return _IdComune
		End Get
		Set (byval value as integer)
			If _IdComune <> value Then
				IsChanged = True
				WhatIsChanged.IdComune = True
				_IdComune = value
			End If
		End Set
	End property 

	Protected _IdCorriere as integer  = 0 
	Public Overridable Property IdCorriere() as integer  Implements _IVoceRubrica.IdCorriere
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

	Protected _IdNazione as integer  = 0 
	Public Overridable Property IdNazione() as integer  Implements _IVoceRubrica.IdNazione
		Get
			Return _IdNazione
		End Get
		Set (byval value as integer)
			If _IdNazione <> value Then
				IsChanged = True
				WhatIsChanged.IdNazione = True
				_IdNazione = value
			End If
		End Set
	End property 

	Protected _IdOld as integer  = 0 
	Public Overridable Property IdOld() as integer  Implements _IVoceRubrica.IdOld
		Get
			Return _IdOld
		End Get
		Set (byval value as integer)
			If _IdOld <> value Then
				IsChanged = True
				WhatIsChanged.IdOld = True
				_IdOld = value
			End If
		End Set
	End property 

	Protected _IdPagamento as integer  = 0 
	Public Overridable Property IdPagamento() as integer  Implements _IVoceRubrica.IdPagamento
		Get
			Return _IdPagamento
		End Get
		Set (byval value as integer)
			If _IdPagamento <> value Then
				IsChanged = True
				WhatIsChanged.IdPagamento = True
				_IdPagamento = value
			End If
		End Set
	End property 

	Protected _IdProvincia as integer  = 0 
	Public Overridable Property IdProvincia() as integer  Implements _IVoceRubrica.IdProvincia
		Get
			Return _IdProvincia
		End Get
		Set (byval value as integer)
			If _IdProvincia <> value Then
				IsChanged = True
				WhatIsChanged.IdProvincia = True
				_IdProvincia = value
			End If
		End Set
	End property 

	Protected _IdRubricaLinked as integer  = 0 
	Public Overridable Property IdRubricaLinked() as integer  Implements _IVoceRubrica.IdRubricaLinked
		Get
			Return _IdRubricaLinked
		End Get
		Set (byval value as integer)
			If _IdRubricaLinked <> value Then
				IsChanged = True
				WhatIsChanged.IdRubricaLinked = True
				_IdRubricaLinked = value
			End If
		End Set
	End property 

	Protected _IdTipoAttivita as integer  = 0 
	Public Overridable Property IdTipoAttivita() as integer  Implements _IVoceRubrica.IdTipoAttivita
		Get
			Return _IdTipoAttivita
		End Get
		Set (byval value as integer)
			If _IdTipoAttivita <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoAttivita = True
				_IdTipoAttivita = value
			End If
		End Set
	End property 

	Protected _IdUtOnline as integer  = 0 
	Public Overridable Property IdUtOnline() as integer  Implements _IVoceRubrica.IdUtOnline
		Get
			Return _IdUtOnline
		End Get
		Set (byval value as integer)
			If _IdUtOnline <> value Then
				IsChanged = True
				WhatIsChanged.IdUtOnline = True
				_IdUtOnline = value
			End If
		End Set
	End property 

	Protected _IdZona as integer  = 0 
	Public Overridable Property IdZona() as integer  Implements _IVoceRubrica.IdZona
		Get
			Return _IdZona
		End Get
		Set (byval value as integer)
			If _IdZona <> value Then
				IsChanged = True
				WhatIsChanged.IdZona = True
				_IdZona = value
			End If
		End Set
	End property 

	Protected _IndCons as string  = "" 
	Public Overridable Property IndCons() as string  Implements _IVoceRubrica.IndCons
		Get
			Return _IndCons
		End Get
		Set (byval value as string)
			If _IndCons <> value Then
				IsChanged = True
				WhatIsChanged.IndCons = True
				_IndCons = value
			End If
		End Set
	End property 

	Protected _Indirizzo as string  = "" 
	Public Overridable Property Indirizzo() as string  Implements _IVoceRubrica.Indirizzo
		Get
			Return _Indirizzo
		End Get
		Set (byval value as string)
			If _Indirizzo <> value Then
				IsChanged = True
				WhatIsChanged.Indirizzo = True
				_Indirizzo = value
			End If
		End Set
	End property 

	Protected _InserimentoManualeFatture as integer  = 0 
	Public Overridable Property InserimentoManualeFatture() as integer  Implements _IVoceRubrica.InserimentoManualeFatture
		Get
			Return _InserimentoManualeFatture
		End Get
		Set (byval value as integer)
			If _InserimentoManualeFatture <> value Then
				IsChanged = True
				WhatIsChanged.InserimentoManualeFatture = True
				_InserimentoManualeFatture = value
			End If
		End Set
	End property 

	Protected _IsFornitore as integer  = 0 
	Public Overridable Property IsFornitore() as integer  Implements _IVoceRubrica.IsFornitore
		Get
			Return _IsFornitore
		End Get
		Set (byval value as integer)
			If _IsFornitore <> value Then
				IsChanged = True
				WhatIsChanged.IsFornitore = True
				_IsFornitore = value
			End If
		End Set
	End property 

	Protected _LastUpdate as DateTime  = Nothing 
	Public Overridable Property LastUpdate() as DateTime  Implements _IVoceRubrica.LastUpdate
		Get
			Return _LastUpdate
		End Get
		Set (byval value as DateTime)
			If _LastUpdate <> value Then
				IsChanged = True
				WhatIsChanged.LastUpdate = True
				_LastUpdate = value
			End If
		End Set
	End property 

	Protected _NoCheckDatiFisc as integer  = 0 
	Public Overridable Property NoCheckDatiFisc() as integer  Implements _IVoceRubrica.NoCheckDatiFisc
		Get
			Return _NoCheckDatiFisc
		End Get
		Set (byval value as integer)
			If _NoCheckDatiFisc <> value Then
				IsChanged = True
				WhatIsChanged.NoCheckDatiFisc = True
				_NoCheckDatiFisc = value
			End If
		End Set
	End property 

	Protected _NoEmail as integer  = 0 
	Public Overridable Property NoEmail() as integer  Implements _IVoceRubrica.NoEmail
		Get
			Return _NoEmail
		End Get
		Set (byval value as integer)
			If _NoEmail <> value Then
				IsChanged = True
				WhatIsChanged.NoEmail = True
				_NoEmail = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IVoceRubrica.Nome
		Get
			Return _Nome
		End Get
		Set (byval value as string)
			If _Nome <> value Then
				IsChanged = True
				WhatIsChanged.Nome = True
				_Nome = value
			End If
		End Set
	End property 

	Protected _NonCreareAutomaticamenteDocumentiDiCarico as integer  = 0 
	Public Overridable Property NonCreareAutomaticamenteDocumentiDiCarico() as integer  Implements _IVoceRubrica.NonCreareAutomaticamenteDocumentiDiCarico
		Get
			Return _NonCreareAutomaticamenteDocumentiDiCarico
		End Get
		Set (byval value as integer)
			If _NonCreareAutomaticamenteDocumentiDiCarico <> value Then
				IsChanged = True
				WhatIsChanged.NonCreareAutomaticamenteDocumentiDiCarico = True
				_NonCreareAutomaticamenteDocumentiDiCarico = value
			End If
		End Set
	End property 

	Protected _Pagamento as string  = "" 
	Public Overridable Property Pagamento() as string  Implements _IVoceRubrica.Pagamento
		Get
			Return _Pagamento
		End Get
		Set (byval value as string)
			If _Pagamento <> value Then
				IsChanged = True
				WhatIsChanged.Pagamento = True
				_Pagamento = value
			End If
		End Set
	End property 

	Protected _Pec as string  = "" 
	Public Overridable Property Pec() as string  Implements _IVoceRubrica.Pec
		Get
			Return _Pec
		End Get
		Set (byval value as string)
			If _Pec <> value Then
				IsChanged = True
				WhatIsChanged.Pec = True
				_Pec = value
			End If
		End Set
	End property 

	Protected _Piva as string  = "" 
	Public Overridable Property Piva() as string  Implements _IVoceRubrica.Piva
		Get
			Return _Piva
		End Get
		Set (byval value as string)
			If _Piva <> value Then
				IsChanged = True
				WhatIsChanged.Piva = True
				_Piva = value
			End If
		End Set
	End property 

	Protected _PrefissoPIva as string  = "" 
	Public Overridable Property PrefissoPIva() as string  Implements _IVoceRubrica.PrefissoPIva
		Get
			Return _PrefissoPIva
		End Get
		Set (byval value as string)
			If _PrefissoPIva <> value Then
				IsChanged = True
				WhatIsChanged.PrefissoPIva = True
				_PrefissoPIva = value
			End If
		End Set
	End property 

	Protected _Provincia as string  = "" 
	Public Overridable Property Provincia() as string  Implements _IVoceRubrica.Provincia
		Get
			Return _Provincia
		End Get
		Set (byval value as string)
			If _Provincia <> value Then
				IsChanged = True
				WhatIsChanged.Provincia = True
				_Provincia = value
			End If
		End Set
	End property 

	Protected _RagSoc as string  = "" 
	Public Overridable Property RagSoc() as string  Implements _IVoceRubrica.RagSoc
		Get
			Return _RagSoc
		End Get
		Set (byval value as string)
			If _RagSoc <> value Then
				IsChanged = True
				WhatIsChanged.RagSoc = True
				_RagSoc = value
			End If
		End Set
	End property 

	Protected _RegistraAutomaticamentePagamenti as integer  = 0 
	Public Overridable Property RegistraAutomaticamentePagamenti() as integer  Implements _IVoceRubrica.RegistraAutomaticamentePagamenti
		Get
			Return _RegistraAutomaticamentePagamenti
		End Get
		Set (byval value as integer)
			If _RegistraAutomaticamentePagamenti <> value Then
				IsChanged = True
				WhatIsChanged.RegistraAutomaticamentePagamenti = True
				_RegistraAutomaticamentePagamenti = value
			End If
		End Set
	End property 

	Protected _ScopertoMax as integer  = 0 
	Public Overridable Property ScopertoMax() as integer  Implements _IVoceRubrica.ScopertoMax
		Get
			Return _ScopertoMax
		End Get
		Set (byval value as integer)
			If _ScopertoMax <> value Then
				IsChanged = True
				WhatIsChanged.ScopertoMax = True
				_ScopertoMax = value
			End If
		End Set
	End property 

	Protected _SitoWeb as string  = "" 
	Public Overridable Property SitoWeb() as string  Implements _IVoceRubrica.SitoWeb
		Get
			Return _SitoWeb
		End Get
		Set (byval value as string)
			If _SitoWeb <> value Then
				IsChanged = True
				WhatIsChanged.SitoWeb = True
				_SitoWeb = value
			End If
		End Set
	End property 

	Protected _Sorgente as string  = "" 
	Public Overridable Property Sorgente() as string  Implements _IVoceRubrica.Sorgente
		Get
			Return _Sorgente
		End Get
		Set (byval value as string)
			If _Sorgente <> value Then
				IsChanged = True
				WhatIsChanged.Sorgente = True
				_Sorgente = value
			End If
		End Set
	End property 

	Protected _SorgenteStorico as string  = "" 
	Public Overridable Property SorgenteStorico() as string  Implements _IVoceRubrica.SorgenteStorico
		Get
			Return _SorgenteStorico
		End Get
		Set (byval value as string)
			If _SorgenteStorico <> value Then
				IsChanged = True
				WhatIsChanged.SorgenteStorico = True
				_SorgenteStorico = value
			End If
		End Set
	End property 

	Protected _StampaAutomaticaDocumenti as integer  = 0 
	Public Overridable Property StampaAutomaticaDocumenti() as integer  Implements _IVoceRubrica.StampaAutomaticaDocumenti
		Get
			Return _StampaAutomaticaDocumenti
		End Get
		Set (byval value as integer)
			If _StampaAutomaticaDocumenti <> value Then
				IsChanged = True
				WhatIsChanged.StampaAutomaticaDocumenti = True
				_StampaAutomaticaDocumenti = value
			End If
		End Set
	End property 

	Protected _Status as integer  = 0 
	Public Overridable Property Status() as integer  Implements _IVoceRubrica.Status
		Get
			Return _Status
		End Get
		Set (byval value as integer)
			If _Status <> value Then
				IsChanged = True
				WhatIsChanged.Status = True
				_Status = value
			End If
		End Set
	End property 

	Protected _tag as string  = "" 
	Public Overridable Property tag() as string  Implements _IVoceRubrica.tag
		Get
			Return _tag
		End Get
		Set (byval value as string)
			If _tag <> value Then
				IsChanged = True
				WhatIsChanged.tag = True
				_tag = value
			End If
		End Set
	End property 

	Protected _Tel as string  = "" 
	Public Overridable Property Tel() as string  Implements _IVoceRubrica.Tel
		Get
			Return _Tel
		End Get
		Set (byval value as string)
			If _Tel <> value Then
				IsChanged = True
				WhatIsChanged.Tel = True
				_Tel = value
			End If
		End Set
	End property 

	Protected _TelRif as string  = "" 
	Public Overridable Property TelRif() as string  Implements _IVoceRubrica.TelRif
		Get
			Return _TelRif
		End Get
		Set (byval value as string)
			If _TelRif <> value Then
				IsChanged = True
				WhatIsChanged.TelRif = True
				_TelRif = value
			End If
		End Set
	End property 

	Protected _Tipo as integer  = 0 
	Public Overridable Property Tipo() as integer  Implements _IVoceRubrica.Tipo
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

	Protected _TipoDoc as integer  = 0 
	Public Overridable Property TipoDoc() as integer  Implements _IVoceRubrica.TipoDoc
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
	'''This method read an VoceRubrica from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As VoceRubrica = Manager.Read(Id)
				_IdRub = int.IdRub
				_AbilitaInserimentoManualeDoc = int.AbilitaInserimentoManualeDoc
				_AltroTel = int.AltroTel
				_AltroTelRif = int.AltroTelRif
				_AssRilIntMitt = int.AssRilIntMitt
				_BigliettoVisita = int.BigliettoVisita
				_CAP = int.CAP
				_Cellulare = int.Cellulare
				_CellulareRif = int.CellulareRif
				_Citta = int.Citta
				_CodFisc = int.CodFisc
				_CodiceSDI = int.CodiceSDI
				_Cognome = int.Cognome
				_DataIns = int.DataIns
				_DisattivaAccessoSito = int.DisattivaAccessoSito
				_Email = int.Email
				_EmailAdmin = int.EmailAdmin
				_EsigibilitaIva = int.EsigibilitaIva
				_Fax = int.Fax
				_FaxRif = int.FaxRif
				_IdAge = int.IdAge
				_IdAziendaDefaultFatture = int.IdAziendaDefaultFatture
				_IdCatContab = int.IdCatContab
				_IdCategoria = int.IdCategoria
				_IdComune = int.IdComune
				_IdCorriere = int.IdCorriere
				_IdNazione = int.IdNazione
				_IdOld = int.IdOld
				_IdPagamento = int.IdPagamento
				_IdProvincia = int.IdProvincia
				_IdRubricaLinked = int.IdRubricaLinked
				_IdTipoAttivita = int.IdTipoAttivita
				_IdUtOnline = int.IdUtOnline
				_IdZona = int.IdZona
				_IndCons = int.IndCons
				_Indirizzo = int.Indirizzo
				_InserimentoManualeFatture = int.InserimentoManualeFatture
				_IsFornitore = int.IsFornitore
				_LastUpdate = int.LastUpdate
				_NoCheckDatiFisc = int.NoCheckDatiFisc
				_NoEmail = int.NoEmail
				_Nome = int.Nome
				_NonCreareAutomaticamenteDocumentiDiCarico = int.NonCreareAutomaticamenteDocumentiDiCarico
				_Pagamento = int.Pagamento
				_Pec = int.Pec
				_Piva = int.Piva
				_PrefissoPIva = int.PrefissoPIva
				_Provincia = int.Provincia
				_RagSoc = int.RagSoc
				_RegistraAutomaticamentePagamenti = int.RegistraAutomaticamentePagamenti
				_ScopertoMax = int.ScopertoMax
				_SitoWeb = int.SitoWeb
				_Sorgente = int.Sorgente
				_SorgenteStorico = int.SorgenteStorico
				_StampaAutomaticaDocumenti = int.StampaAutomaticaDocumenti
				_Status = int.Status
				_tag = int.tag
				_Tel = int.Tel
				_TelRif = int.TelRif
				_Tipo = int.Tipo
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
	'''This method Refresh all data in the entity from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
    Public Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdRub Then
            ris = Read(IdRub)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an VoceRubrica on DB.
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
		if _AltroTel.Length > 50 then Ris = False
		if _AltroTelRif.Length > 255 then Ris = False
		if _BigliettoVisita.Length > 255 then Ris = False
		if _CAP.Length > 5 then Ris = False
		if _Cellulare.Length > 50 then Ris = False
		if _CellulareRif.Length > 255 then Ris = False
		if _Citta.Length > 50 then Ris = False
		if _CodFisc.Length > 16 then Ris = False
		if _CodiceSDI.Length > 7 then Ris = False
		if _Cognome.Length > 50 then Ris = False
		if _Email.Length > 100 then Ris = False
		if _EmailAdmin.Length > 255 then Ris = False
		if _Fax.Length > 50 then Ris = False
		if _FaxRif.Length > 255 then Ris = False
		if _IndCons.Length > 255 then Ris = False
		if _Indirizzo.Length > 250 then Ris = False
		if _Nome.Length > 50 then Ris = False
		if _Pagamento.Length > 255 then Ris = False
		if _Pec.Length > 100 then Ris = False
		If _Piva.Length > 20 Then Ris = False
		If _PrefissoPIva.Length > 2 then Ris = False
		if _Provincia.Length > 10 then Ris = False
		if _RagSoc.Length > 100 then Ris = False
		if _SitoWeb.Length > 250 then Ris = False
		if _Sorgente.Length > 1 then Ris = False
		if _SorgenteStorico.Length > 1 then Ris = False
		if _tag.Length > 255 then Ris = False
		if _Tel.Length > 50 then Ris = False
		if _TelRif.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_rubrica
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IVoceRubrica

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdRub() as integer
	Property AbilitaInserimentoManualeDoc() as integer
	Property AltroTel() as string
	Property AltroTelRif() as string
	Property AssRilIntMitt() as integer
	Property BigliettoVisita() as string
	Property CAP() as string
	Property Cellulare() as string
	Property CellulareRif() as string
	Property Citta() as string
	Property CodFisc() as string
	Property CodiceSDI() as string
	Property Cognome() as string
	Property DataIns() as DateTime
	Property DisattivaAccessoSito() as integer
	Property Email() as string
	Property EmailAdmin() as string
	Property EsigibilitaIva() as integer
	Property Fax() as string
	Property FaxRif() as string
	Property IdAge() as integer
	Property IdAziendaDefaultFatture() as integer
	Property IdCatContab() as integer
	Property IdCategoria() as integer
	Property IdComune() as integer
	Property IdCorriere() as integer
	Property IdNazione() as integer
	Property IdOld() as integer
	Property IdPagamento() as integer
	Property IdProvincia() as integer
	Property IdRubricaLinked() as integer
	Property IdTipoAttivita() as integer
	Property IdUtOnline() as integer
	Property IdZona() as integer
	Property IndCons() as string
	Property Indirizzo() as string
	Property InserimentoManualeFatture() as integer
	Property IsFornitore() as integer
	Property LastUpdate() as DateTime
	Property NoCheckDatiFisc() as integer
	Property NoEmail() as integer
	Property Nome() as string
	Property NonCreareAutomaticamenteDocumentiDiCarico() as integer
	Property Pagamento() as string
	Property Pec() as string
	Property Piva() as string
	Property PrefissoPIva() as string
	Property Provincia() as string
	Property RagSoc() as string
	Property RegistraAutomaticamentePagamenti() as integer
	Property ScopertoMax() as integer
	Property SitoWeb() as string
	Property Sorgente() as string
	Property SorgenteStorico() as string
	Property StampaAutomaticaDocumenti() as integer
	Property Status() as integer
	Property tag() as string
	Property Tel() as string
	Property TelRif() as string
	Property Tipo() as integer
	Property TipoDoc() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class VoceRubrica
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property AbilitaInserimentoManualeDoc As New LUNA.LunaFieldName("AbilitaInserimentoManualeDoc")
		Public Shared ReadOnly Property AltroTel As New LUNA.LunaFieldName("AltroTel")
		Public Shared ReadOnly Property AltroTelRif As New LUNA.LunaFieldName("AltroTelRif")
		Public Shared ReadOnly Property AssRilIntMitt As New LUNA.LunaFieldName("AssRilIntMitt")
		Public Shared ReadOnly Property BigliettoVisita As New LUNA.LunaFieldName("BigliettoVisita")
		Public Shared ReadOnly Property CAP As New LUNA.LunaFieldName("CAP")
		Public Shared ReadOnly Property Cellulare As New LUNA.LunaFieldName("Cellulare")
		Public Shared ReadOnly Property CellulareRif As New LUNA.LunaFieldName("CellulareRif")
		Public Shared ReadOnly Property Citta As New LUNA.LunaFieldName("Citta")
		Public Shared ReadOnly Property CodFisc As New LUNA.LunaFieldName("CodFisc")
		Public Shared ReadOnly Property CodiceSDI As New LUNA.LunaFieldName("CodiceSDI")
		Public Shared ReadOnly Property Cognome As New LUNA.LunaFieldName("Cognome")
		Public Shared ReadOnly Property DataIns As New LUNA.LunaFieldName("DataIns")
		Public Shared ReadOnly Property DisattivaAccessoSito As New LUNA.LunaFieldName("DisattivaAccessoSito")
		Public Shared ReadOnly Property Email As New LUNA.LunaFieldName("Email")
		Public Shared ReadOnly Property EmailAdmin As New LUNA.LunaFieldName("EmailAdmin")
		Public Shared ReadOnly Property EsigibilitaIva As New LUNA.LunaFieldName("EsigibilitaIva")
		Public Shared ReadOnly Property Fax As New LUNA.LunaFieldName("Fax")
		Public Shared ReadOnly Property FaxRif As New LUNA.LunaFieldName("FaxRif")
		Public Shared ReadOnly Property IdAge As New LUNA.LunaFieldName("IdAge")
		Public Shared ReadOnly Property IdAziendaDefaultFatture As New LUNA.LunaFieldName("IdAziendaDefaultFatture")
		Public Shared ReadOnly Property IdCatContab As New LUNA.LunaFieldName("IdCatContab")
		Public Shared ReadOnly Property IdCategoria As New LUNA.LunaFieldName("IdCategoria")
		Public Shared ReadOnly Property IdComune As New LUNA.LunaFieldName("IdComune")
		Public Shared ReadOnly Property IdCorriere As New LUNA.LunaFieldName("IdCorriere")
		Public Shared ReadOnly Property IdNazione As New LUNA.LunaFieldName("IdNazione")
		Public Shared ReadOnly Property IdOld As New LUNA.LunaFieldName("IdOld")
		Public Shared ReadOnly Property IdPagamento As New LUNA.LunaFieldName("IdPagamento")
		Public Shared ReadOnly Property IdProvincia As New LUNA.LunaFieldName("IdProvincia")
		Public Shared ReadOnly Property IdRubricaLinked As New LUNA.LunaFieldName("IdRubricaLinked")
		Public Shared ReadOnly Property IdTipoAttivita As New LUNA.LunaFieldName("IdTipoAttivita")
		Public Shared ReadOnly Property IdUtOnline As New LUNA.LunaFieldName("IdUtOnline")
		Public Shared ReadOnly Property IdZona As New LUNA.LunaFieldName("IdZona")
		Public Shared ReadOnly Property IndCons As New LUNA.LunaFieldName("IndCons")
		Public Shared ReadOnly Property Indirizzo As New LUNA.LunaFieldName("Indirizzo")
		Public Shared ReadOnly Property InserimentoManualeFatture As New LUNA.LunaFieldName("InserimentoManualeFatture")
		Public Shared ReadOnly Property IsFornitore As New LUNA.LunaFieldName("IsFornitore")
		Public Shared ReadOnly Property LastUpdate As New LUNA.LunaFieldName("LastUpdate")
		Public Shared ReadOnly Property NoCheckDatiFisc As New LUNA.LunaFieldName("NoCheckDatiFisc")
		Public Shared ReadOnly Property NoEmail As New LUNA.LunaFieldName("NoEmail")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property NonCreareAutomaticamenteDocumentiDiCarico As New LUNA.LunaFieldName("NonCreareAutomaticamenteDocumentiDiCarico")
		Public Shared ReadOnly Property Pagamento As New LUNA.LunaFieldName("Pagamento")
		Public Shared ReadOnly Property Pec As New LUNA.LunaFieldName("Pec")
		Public Shared ReadOnly Property Piva As New LUNA.LunaFieldName("Piva")
		Public Shared ReadOnly Property PrefissoPIva As New LUNA.LunaFieldName("PrefissoPIva")
		Public Shared ReadOnly Property Provincia As New LUNA.LunaFieldName("Provincia")
		Public Shared ReadOnly Property RagSoc As New LUNA.LunaFieldName("RagSoc")
		Public Shared ReadOnly Property RegistraAutomaticamentePagamenti As New LUNA.LunaFieldName("RegistraAutomaticamentePagamenti")
		Public Shared ReadOnly Property ScopertoMax As New LUNA.LunaFieldName("ScopertoMax")
		Public Shared ReadOnly Property SitoWeb As New LUNA.LunaFieldName("SitoWeb")
		Public Shared ReadOnly Property Sorgente As New LUNA.LunaFieldName("Sorgente")
		Public Shared ReadOnly Property SorgenteStorico As New LUNA.LunaFieldName("SorgenteStorico")
		Public Shared ReadOnly Property StampaAutomaticaDocumenti As New LUNA.LunaFieldName("StampaAutomaticaDocumenti")
		Public Shared ReadOnly Property Status As New LUNA.LunaFieldName("Status")
		Public Shared ReadOnly Property tag As New LUNA.LunaFieldName("tag")
		Public Shared ReadOnly Property Tel As New LUNA.LunaFieldName("Tel")
		Public Shared ReadOnly Property TelRif As New LUNA.LunaFieldName("TelRif")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
		Public Shared ReadOnly Property TipoDoc As New LUNA.LunaFieldName("TipoDoc")
	End Class

End Class