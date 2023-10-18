#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 11/03/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Utenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Utente
	Inherits LUNA.LunaBaseClassEntity
	Implements _IUtente
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IUtente.FillFromDataRecord
		IdUt = myRecord("IdUt")
		if not myRecord("Cap") is DBNull.Value then Cap = myRecord("Cap")
		if not myRecord("Cellulare") is DBNull.Value then Cellulare = myRecord("Cellulare")
		if not myRecord("Citta") is DBNull.Value then Citta = myRecord("Citta")
		if not myRecord("CodFisc") is DBNull.Value then CodFisc = myRecord("CodFisc")
		if not myRecord("CodiceSDI") is DBNull.Value then CodiceSDI = myRecord("CodiceSDI")
		if not myRecord("Cognome") is DBNull.Value then Cognome = myRecord("Cognome")
		if not myRecord("DataIns") is DBNull.Value then DataIns = myRecord("DataIns")
		if not myRecord("DisattivaAccessoSito") is DBNull.Value then DisattivaAccessoSito = myRecord("DisattivaAccessoSito")
		if not myRecord("DownloadEsplicito") is DBNull.Value then DownloadEsplicito = myRecord("DownloadEsplicito")
		Email = myRecord("Email")
		if not myRecord("Fax") is DBNull.Value then Fax = myRecord("Fax")
		if not myRecord("IdComune") is DBNull.Value then IdComune = myRecord("IdComune")
		if not myRecord("IdCorriereDef") is DBNull.Value then IdCorriereDef = myRecord("IdCorriereDef")
		if not myRecord("IdNazione") is DBNull.Value then IdNazione = myRecord("IdNazione")
		if not myRecord("IdPagamento") is DBNull.Value then IdPagamento = myRecord("IdPagamento")
		if not myRecord("IdProvincia") is DBNull.Value then IdProvincia = myRecord("IdProvincia")
		if not myRecord("IdRubricaInt") is DBNull.Value then IdRubricaInt = myRecord("IdRubricaInt")
		if not myRecord("IdTipoAttivita") is DBNull.Value then IdTipoAttivita = myRecord("IdTipoAttivita")
		if not myRecord("Indirizzo") is DBNull.Value then Indirizzo = myRecord("Indirizzo")
		if not myRecord("LastIp") is DBNull.Value then LastIp = myRecord("LastIp")
		if not myRecord("LastLogin") is DBNull.Value then LastLogin = myRecord("LastLogin")
		if not myRecord("LastUpdate") is DBNull.Value then LastUpdate = myRecord("LastUpdate")
		if not myRecord("NoCheckDatiFisc") is DBNull.Value then NoCheckDatiFisc = myRecord("NoCheckDatiFisc")
		if not myRecord("NoMail") is DBNull.Value then NoMail = myRecord("NoMail")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		PasswordHash = myRecord("PasswordHash")
		if not myRecord("Pec") is DBNull.Value then Pec = myRecord("Pec")
		if not myRecord("Piva") is DBNull.Value then Piva = myRecord("Piva")
		if not myRecord("PrefissoPIva") is DBNull.Value then PrefissoPIva = myRecord("PrefissoPIva")
		if not myRecord("Provincia") is DBNull.Value then Provincia = myRecord("Provincia")
		if not myRecord("RagSoc") is DBNull.Value then RagSoc = myRecord("RagSoc")
		if not myRecord("SitoWeb") is DBNull.Value then SitoWeb = myRecord("SitoWeb")
		if not myRecord("Tel") is DBNull.Value then Tel = myRecord("Tel")
		TipoRub = myRecord("TipoRub")
		if not myRecord("TipoWeb") is DBNull.Value then TipoWeb = myRecord("TipoWeb")
		if not myRecord("UpdateFromUser") is DBNull.Value then UpdateFromUser = myRecord("UpdateFromUser")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Utente)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(UtentiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Utente))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cap As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cellulare As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Citta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodFisc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodiceSDI As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cognome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DisattivaAccessoSito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DownloadEsplicito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Email As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Fax As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdComune As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorriereDef As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdNazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProvincia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRubricaInt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoAttivita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Indirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LastIp As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LastLogin As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LastUpdate As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoCheckDatiFisc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoMail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PasswordHash As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Pec As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Piva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrefissoPIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Provincia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RagSoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SitoWeb As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoWeb As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property UpdateFromUser As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cap = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cellulare = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Citta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodFisc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodiceSDI = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cognome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DisattivaAccessoSito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DownloadEsplicito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Email = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Fax = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdComune = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorriereDef = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdNazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPagamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProvincia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRubricaInt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoAttivita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Indirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LastIp = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LastLogin = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LastUpdate = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoCheckDatiFisc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoMail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PasswordHash = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Pec = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Piva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrefissoPIva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Provincia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RagSoc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SitoWeb = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tel = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoWeb = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.UpdateFromUser = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IUtente.IdUt
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

	Protected _Cap as string  = "" 
	Public Overridable Property Cap() as string  Implements _IUtente.Cap
		Get
			Return _Cap
		End Get
		Set (byval value as string)
			If _Cap <> value Then
				IsChanged = True
				WhatIsChanged.Cap = True
				_Cap = value
			End If
		End Set
	End property 

	Protected _Cellulare as string  = "" 
	Public Overridable Property Cellulare() as string  Implements _IUtente.Cellulare
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

	Protected _Citta as string  = "" 
	Public Overridable Property Citta() as string  Implements _IUtente.Citta
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
	Public Overridable Property CodFisc() as string  Implements _IUtente.CodFisc
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
	Public Overridable Property CodiceSDI() as string  Implements _IUtente.CodiceSDI
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
	Public Overridable Property Cognome() as string  Implements _IUtente.Cognome
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
	Public Overridable Property DataIns() as DateTime  Implements _IUtente.DataIns
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
	Public Overridable Property DisattivaAccessoSito() as integer  Implements _IUtente.DisattivaAccessoSito
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

	Protected _DownloadEsplicito as integer  = 0 
	Public Overridable Property DownloadEsplicito() as integer  Implements _IUtente.DownloadEsplicito
		Get
			Return _DownloadEsplicito
		End Get
		Set (byval value as integer)
			If _DownloadEsplicito <> value Then
				IsChanged = True
				WhatIsChanged.DownloadEsplicito = True
				_DownloadEsplicito = value
			End If
		End Set
	End property 

	Protected _Email as string  = "" 
	Public Overridable Property Email() as string  Implements _IUtente.Email
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

	Protected _Fax as string  = "" 
	Public Overridable Property Fax() as string  Implements _IUtente.Fax
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

	Protected _IdComune as integer  = 0 
	Public Overridable Property IdComune() as integer  Implements _IUtente.IdComune
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

	Protected _IdCorriereDef as integer  = 0 
	Public Overridable Property IdCorriereDef() as integer  Implements _IUtente.IdCorriereDef
		Get
			Return _IdCorriereDef
		End Get
		Set (byval value as integer)
			If _IdCorriereDef <> value Then
				IsChanged = True
				WhatIsChanged.IdCorriereDef = True
				_IdCorriereDef = value
			End If
		End Set
	End property 

	Protected _IdNazione as integer  = 0 
	Public Overridable Property IdNazione() as integer  Implements _IUtente.IdNazione
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

	Protected _IdPagamento as integer  = 0 
	Public Overridable Property IdPagamento() as integer  Implements _IUtente.IdPagamento
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
	Public Overridable Property IdProvincia() as integer  Implements _IUtente.IdProvincia
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

	Protected _IdRubricaInt as integer  = 0 
	Public Overridable Property IdRubricaInt() as integer  Implements _IUtente.IdRubricaInt
		Get
			Return _IdRubricaInt
		End Get
		Set (byval value as integer)
			If _IdRubricaInt <> value Then
				IsChanged = True
				WhatIsChanged.IdRubricaInt = True
				_IdRubricaInt = value
			End If
		End Set
	End property 

	Protected _IdTipoAttivita as integer  = 0 
	Public Overridable Property IdTipoAttivita() as integer  Implements _IUtente.IdTipoAttivita
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

	Protected _Indirizzo as string  = "" 
	Public Overridable Property Indirizzo() as string  Implements _IUtente.Indirizzo
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

	Protected _LastIp as string  = "" 
	Public Overridable Property LastIp() as string  Implements _IUtente.LastIp
		Get
			Return _LastIp
		End Get
		Set (byval value as string)
			If _LastIp <> value Then
				IsChanged = True
				WhatIsChanged.LastIp = True
				_LastIp = value
			End If
		End Set
	End property 

	Protected _LastLogin as DateTime  = Nothing 
	Public Overridable Property LastLogin() as DateTime  Implements _IUtente.LastLogin
		Get
			Return _LastLogin
		End Get
		Set (byval value as DateTime)
			If _LastLogin <> value Then
				IsChanged = True
				WhatIsChanged.LastLogin = True
				_LastLogin = value
			End If
		End Set
	End property 

	Protected _LastUpdate as DateTime  = Nothing 
	Public Overridable Property LastUpdate() as DateTime  Implements _IUtente.LastUpdate
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
	Public Overridable Property NoCheckDatiFisc() as integer  Implements _IUtente.NoCheckDatiFisc
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

	Protected _NoMail as integer  = 0 
	Public Overridable Property NoMail() as integer  Implements _IUtente.NoMail
		Get
			Return _NoMail
		End Get
		Set (byval value as integer)
			If _NoMail <> value Then
				IsChanged = True
				WhatIsChanged.NoMail = True
				_NoMail = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IUtente.Nome
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

	Protected _PasswordHash as string  = "" 
	Public Overridable Property PasswordHash() as string  Implements _IUtente.PasswordHash
		Get
			Return _PasswordHash
		End Get
		Set (byval value as string)
			If _PasswordHash <> value Then
				IsChanged = True
				WhatIsChanged.PasswordHash = True
				_PasswordHash = value
			End If
		End Set
	End property 

	Protected _Pec as string  = "" 
	Public Overridable Property Pec() as string  Implements _IUtente.Pec
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
	Public Overridable Property Piva() as string  Implements _IUtente.Piva
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
	Public Overridable Property PrefissoPIva() as string  Implements _IUtente.PrefissoPIva
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
	Public Overridable Property Provincia() as string  Implements _IUtente.Provincia
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
	Public Overridable Property RagSoc() as string  Implements _IUtente.RagSoc
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

	Protected _SitoWeb as string  = "" 
	Public Overridable Property SitoWeb() as string  Implements _IUtente.SitoWeb
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

	Protected _Tel as string  = "" 
	Public Overridable Property Tel() as string  Implements _IUtente.Tel
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

	Protected _TipoRub as integer  = 0 
	Public Overridable Property TipoRub() as integer  Implements _IUtente.TipoRub
		Get
			Return _TipoRub
		End Get
		Set (byval value as integer)
			If _TipoRub <> value Then
				IsChanged = True
				WhatIsChanged.TipoRub = True
				_TipoRub = value
			End If
		End Set
	End property 

	Protected _TipoWeb as integer  = 0 
	Public Overridable Property TipoWeb() as integer  Implements _IUtente.TipoWeb
		Get
			Return _TipoWeb
		End Get
		Set (byval value as integer)
			If _TipoWeb <> value Then
				IsChanged = True
				WhatIsChanged.TipoWeb = True
				_TipoWeb = value
			End If
		End Set
	End property 

	Protected _UpdateFromUser as integer  = 0 
	Public Overridable Property UpdateFromUser() as integer  Implements _IUtente.UpdateFromUser
		Get
			Return _UpdateFromUser
		End Get
		Set (byval value as integer)
			If _UpdateFromUser <> value Then
				IsChanged = True
				WhatIsChanged.UpdateFromUser = True
				_UpdateFromUser = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Utente from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Utente = Manager.Read(Id)
				_IdUt = int.IdUt
				_Cap = int.Cap
				_Cellulare = int.Cellulare
				_Citta = int.Citta
				_CodFisc = int.CodFisc
				_CodiceSDI = int.CodiceSDI
				_Cognome = int.Cognome
				_DataIns = int.DataIns
				_DisattivaAccessoSito = int.DisattivaAccessoSito
				_DownloadEsplicito = int.DownloadEsplicito
				_Email = int.Email
				_Fax = int.Fax
				_IdComune = int.IdComune
				_IdCorriereDef = int.IdCorriereDef
				_IdNazione = int.IdNazione
				_IdPagamento = int.IdPagamento
				_IdProvincia = int.IdProvincia
				_IdRubricaInt = int.IdRubricaInt
				_IdTipoAttivita = int.IdTipoAttivita
				_Indirizzo = int.Indirizzo
				_LastIp = int.LastIp
				_LastLogin = int.LastLogin
				_LastUpdate = int.LastUpdate
				_NoCheckDatiFisc = int.NoCheckDatiFisc
				_NoMail = int.NoMail
				_Nome = int.Nome
				_PasswordHash = int.PasswordHash
				_Pec = int.Pec
				_Piva = int.Piva
				_PrefissoPIva = int.PrefissoPIva
				_Provincia = int.Provincia
				_RagSoc = int.RagSoc
				_SitoWeb = int.SitoWeb
				_Tel = int.Tel
				_TipoRub = int.TipoRub
				_TipoWeb = int.TipoWeb
				_UpdateFromUser = int.UpdateFromUser
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Utente on DB.
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
		if _Cap.Length > 5 then Ris = False
		if _Cellulare.Length > 20 then Ris = False
		if _Citta.Length > 100 then Ris = False
		if _CodFisc.Length > 16 then Ris = False
		if _CodiceSDI.Length > 7 then Ris = False
		if _Cognome.Length > 50 then Ris = False
  
		if _Email.Length = 0 then Ris = False
		if _Email.Length > 50 then Ris = False
		if _Fax.Length > 20 then Ris = False
		if _Indirizzo.Length > 100 then Ris = False
		if _LastIp.Length > 50 then Ris = False
		if _Nome.Length > 50 then Ris = False
  
		if _PasswordHash.Length = 0 then Ris = False
		if _PasswordHash.Length > 100 then Ris = False
		if _Pec.Length > 100 then Ris = False
		If _Piva.Length > 20 Then Ris = False
		If _PrefissoPIva.Length > 2 then Ris = False
		if _Provincia.Length > 2 then Ris = False
		if _RagSoc.Length > 100 then Ris = False
		if _SitoWeb.Length > 250 then Ris = False
		if _Tel.Length > 20 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Utenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IUtente

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdUt() as integer
	Property Cap() as string
	Property Cellulare() as string
	Property Citta() as string
	Property CodFisc() as string
	Property CodiceSDI() as string
	Property Cognome() as string
	Property DataIns() as DateTime
	Property DisattivaAccessoSito() as integer
	Property DownloadEsplicito() as integer
	Property Email() as string
	Property Fax() as string
	Property IdComune() as integer
	Property IdCorriereDef() as integer
	Property IdNazione() as integer
	Property IdPagamento() as integer
	Property IdProvincia() as integer
	Property IdRubricaInt() as integer
	Property IdTipoAttivita() as integer
	Property Indirizzo() as string
	Property LastIp() as string
	Property LastLogin() as DateTime
	Property LastUpdate() as DateTime
	Property NoCheckDatiFisc() as integer
	Property NoMail() as integer
	Property Nome() as string
	Property PasswordHash() as string
	Property Pec() as string
	Property Piva() as string
	Property PrefissoPIva() as string
	Property Provincia() as string
	Property RagSoc() as string
	Property SitoWeb() as string
	Property Tel() as string
	Property TipoRub() as integer
	Property TipoWeb() as integer
	Property UpdateFromUser() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Utente
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property Cap As New LUNA.LunaFieldName("Cap")
		Public Shared ReadOnly Property Cellulare As New LUNA.LunaFieldName("Cellulare")
		Public Shared ReadOnly Property Citta As New LUNA.LunaFieldName("Citta")
		Public Shared ReadOnly Property CodFisc As New LUNA.LunaFieldName("CodFisc")
		Public Shared ReadOnly Property CodiceSDI As New LUNA.LunaFieldName("CodiceSDI")
		Public Shared ReadOnly Property Cognome As New LUNA.LunaFieldName("Cognome")
		Public Shared ReadOnly Property DataIns As New LUNA.LunaFieldName("DataIns")
		Public Shared ReadOnly Property DisattivaAccessoSito As New LUNA.LunaFieldName("DisattivaAccessoSito")
		Public Shared ReadOnly Property DownloadEsplicito As New LUNA.LunaFieldName("DownloadEsplicito")
		Public Shared ReadOnly Property Email As New LUNA.LunaFieldName("Email")
		Public Shared ReadOnly Property Fax As New LUNA.LunaFieldName("Fax")
		Public Shared ReadOnly Property IdComune As New LUNA.LunaFieldName("IdComune")
		Public Shared ReadOnly Property IdCorriereDef As New LUNA.LunaFieldName("IdCorriereDef")
		Public Shared ReadOnly Property IdNazione As New LUNA.LunaFieldName("IdNazione")
		Public Shared ReadOnly Property IdPagamento As New LUNA.LunaFieldName("IdPagamento")
		Public Shared ReadOnly Property IdProvincia As New LUNA.LunaFieldName("IdProvincia")
		Public Shared ReadOnly Property IdRubricaInt As New LUNA.LunaFieldName("IdRubricaInt")
		Public Shared ReadOnly Property IdTipoAttivita As New LUNA.LunaFieldName("IdTipoAttivita")
		Public Shared ReadOnly Property Indirizzo As New LUNA.LunaFieldName("Indirizzo")
		Public Shared ReadOnly Property LastIp As New LUNA.LunaFieldName("LastIp")
		Public Shared ReadOnly Property LastLogin As New LUNA.LunaFieldName("LastLogin")
		Public Shared ReadOnly Property LastUpdate As New LUNA.LunaFieldName("LastUpdate")
		Public Shared ReadOnly Property NoCheckDatiFisc As New LUNA.LunaFieldName("NoCheckDatiFisc")
		Public Shared ReadOnly Property NoMail As New LUNA.LunaFieldName("NoMail")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property PasswordHash As New LUNA.LunaFieldName("PasswordHash")
		Public Shared ReadOnly Property Pec As New LUNA.LunaFieldName("Pec")
		Public Shared ReadOnly Property Piva As New LUNA.LunaFieldName("Piva")
		Public Shared ReadOnly Property PrefissoPIva As New LUNA.LunaFieldName("PrefissoPIva")
		Public Shared ReadOnly Property Provincia As New LUNA.LunaFieldName("Provincia")
		Public Shared ReadOnly Property RagSoc As New LUNA.LunaFieldName("RagSoc")
		Public Shared ReadOnly Property SitoWeb As New LUNA.LunaFieldName("SitoWeb")
		Public Shared ReadOnly Property Tel As New LUNA.LunaFieldName("Tel")
		Public Shared ReadOnly Property TipoRub As New LUNA.LunaFieldName("TipoRub")
		Public Shared ReadOnly Property TipoWeb As New LUNA.LunaFieldName("TipoWeb")
		Public Shared ReadOnly Property UpdateFromUser As New LUNA.LunaFieldName("UpdateFromUser")
	End Class

End Class