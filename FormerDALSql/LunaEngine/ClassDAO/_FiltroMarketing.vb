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
'''DAO Class for table T_filtromarketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FiltroMarketing
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFiltroMarketing
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFiltroMarketing.FillFromDataRecord
		IdFiltroMarketing = myRecord("IdFiltroMarketing")
		if not myRecord("Cap") is DBNull.Value then Cap = myRecord("Cap")
		if not myRecord("CategoriaMarketing") is DBNull.Value then CategoriaMarketing = myRecord("CategoriaMarketing")
		if not myRecord("chkAgosto") is DBNull.Value then chkAgosto = myRecord("chkAgosto")
		if not myRecord("chkAprile") is DBNull.Value then chkAprile = myRecord("chkAprile")
		if not myRecord("chkDicembre") is DBNull.Value then chkDicembre = myRecord("chkDicembre")
		if not myRecord("chkFebbraio") is DBNull.Value then chkFebbraio = myRecord("chkFebbraio")
		if not myRecord("chkGennaio") is DBNull.Value then chkGennaio = myRecord("chkGennaio")
		if not myRecord("chkGiugno") is DBNull.Value then chkGiugno = myRecord("chkGiugno")
		if not myRecord("chkLuglio") is DBNull.Value then chkLuglio = myRecord("chkLuglio")
		if not myRecord("chkMaggio") is DBNull.Value then chkMaggio = myRecord("chkMaggio")
		if not myRecord("chkMarzo") is DBNull.Value then chkMarzo = myRecord("chkMarzo")
		if not myRecord("chkNovembre") is DBNull.Value then chkNovembre = myRecord("chkNovembre")
		if not myRecord("chkOttobre") is DBNull.Value then chkOttobre = myRecord("chkOttobre")
		if not myRecord("chkSettembre") is DBNull.Value then chkSettembre = myRecord("chkSettembre")
		if not myRecord("Citta") is DBNull.Value then Citta = myRecord("Citta")
		if not myRecord("HannoAcqAlmenoUn") is DBNull.Value then HannoAcqAlmenoUn = myRecord("HannoAcqAlmenoUn")
		if not myRecord("IdGruppo") is DBNull.Value then IdGruppo = myRecord("IdGruppo")
		if not myRecord("InseritiDa") is DBNull.Value then InseritiDa = myRecord("InseritiDa")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("NonHannoMaiAcqUn") is DBNull.Value then NonHannoMaiAcqUn = myRecord("NonHannoMaiAcqUn")
		if not myRecord("NonHannoMaiSpeso") is DBNull.Value then NonHannoMaiSpeso = myRecord("NonHannoMaiSpeso")
		if not myRecord("Ricorsiva") is DBNull.Value then Ricorsiva = myRecord("Ricorsiva")
		if not myRecord("SpesaNelPeriodo") is DBNull.Value then SpesaNelPeriodo = myRecord("SpesaNelPeriodo")
		if not myRecord("SpesaNelPeriodoMaggioreDi") is DBNull.Value then SpesaNelPeriodoMaggioreDi = myRecord("SpesaNelPeriodoMaggioreDi")
		if not myRecord("SpesaNelPeriodoMinoreDi") is DBNull.Value then SpesaNelPeriodoMinoreDi = myRecord("SpesaNelPeriodoMinoreDi")
		if not myRecord("Stato") is DBNull.Value then Stato = myRecord("Stato")
		if not myRecord("tag") is DBNull.Value then tag = myRecord("tag")
		if not myRecord("Tipo") is DBNull.Value then Tipo = myRecord("Tipo")
		if not myRecord("TipoFiltro") is DBNull.Value then TipoFiltro = myRecord("TipoFiltro")
		if not myRecord("TipoOrigine") is DBNull.Value then TipoOrigine = myRecord("TipoOrigine")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FiltroMarketing)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FiltriMarketingDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FiltroMarketing))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdFiltroMarketing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cap As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CategoriaMarketing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkAgosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkAprile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkDicembre As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkFebbraio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkGennaio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkGiugno As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkLuglio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkMaggio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkMarzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkNovembre As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkOttobre As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property chkSettembre As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Citta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property HannoAcqAlmenoUn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdGruppo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property InseritiDa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NonHannoMaiAcqUn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NonHannoMaiSpeso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ricorsiva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SpesaNelPeriodo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SpesaNelPeriodoMaggioreDi As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SpesaNelPeriodoMinoreDi As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property tag As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoFiltro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoOrigine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdFiltroMarketing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cap = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CategoriaMarketing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkAgosto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkAprile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkDicembre = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkFebbraio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkGennaio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkGiugno = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkLuglio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkMaggio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkMarzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkNovembre = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkOttobre = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.chkSettembre = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Citta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.HannoAcqAlmenoUn = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdGruppo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.InseritiDa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NonHannoMaiAcqUn = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NonHannoMaiSpeso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ricorsiva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SpesaNelPeriodo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SpesaNelPeriodoMaggioreDi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SpesaNelPeriodoMinoreDi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.tag = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoFiltro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoOrigine = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdFiltroMarketing as integer  = 0 
	Public Overridable Property IdFiltroMarketing() as integer  Implements _IFiltroMarketing.IdFiltroMarketing
		Get
			Return _IdFiltroMarketing
		End Get
		Set (byval value as integer)
			If _IdFiltroMarketing <> value Then
				IsChanged = True
				WhatIsChanged.IdFiltroMarketing = True
				_IdFiltroMarketing = value
			End If
		End Set
	End property 

	Protected _Cap as string  = "" 
	Public Overridable Property Cap() as string  Implements _IFiltroMarketing.Cap
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

	Protected _CategoriaMarketing as integer  = 0 
	Public Overridable Property CategoriaMarketing() as integer  Implements _IFiltroMarketing.CategoriaMarketing
		Get
			Return _CategoriaMarketing
		End Get
		Set (byval value as integer)
			If _CategoriaMarketing <> value Then
				IsChanged = True
				WhatIsChanged.CategoriaMarketing = True
				_CategoriaMarketing = value
			End If
		End Set
	End property 

	Protected _chkAgosto as integer  = 0 
	Public Overridable Property chkAgosto() as integer  Implements _IFiltroMarketing.chkAgosto
		Get
			Return _chkAgosto
		End Get
		Set (byval value as integer)
			If _chkAgosto <> value Then
				IsChanged = True
				WhatIsChanged.chkAgosto = True
				_chkAgosto = value
			End If
		End Set
	End property 

	Protected _chkAprile as integer  = 0 
	Public Overridable Property chkAprile() as integer  Implements _IFiltroMarketing.chkAprile
		Get
			Return _chkAprile
		End Get
		Set (byval value as integer)
			If _chkAprile <> value Then
				IsChanged = True
				WhatIsChanged.chkAprile = True
				_chkAprile = value
			End If
		End Set
	End property 

	Protected _chkDicembre as integer  = 0 
	Public Overridable Property chkDicembre() as integer  Implements _IFiltroMarketing.chkDicembre
		Get
			Return _chkDicembre
		End Get
		Set (byval value as integer)
			If _chkDicembre <> value Then
				IsChanged = True
				WhatIsChanged.chkDicembre = True
				_chkDicembre = value
			End If
		End Set
	End property 

	Protected _chkFebbraio as integer  = 0 
	Public Overridable Property chkFebbraio() as integer  Implements _IFiltroMarketing.chkFebbraio
		Get
			Return _chkFebbraio
		End Get
		Set (byval value as integer)
			If _chkFebbraio <> value Then
				IsChanged = True
				WhatIsChanged.chkFebbraio = True
				_chkFebbraio = value
			End If
		End Set
	End property 

	Protected _chkGennaio as integer  = 0 
	Public Overridable Property chkGennaio() as integer  Implements _IFiltroMarketing.chkGennaio
		Get
			Return _chkGennaio
		End Get
		Set (byval value as integer)
			If _chkGennaio <> value Then
				IsChanged = True
				WhatIsChanged.chkGennaio = True
				_chkGennaio = value
			End If
		End Set
	End property 

	Protected _chkGiugno as integer  = 0 
	Public Overridable Property chkGiugno() as integer  Implements _IFiltroMarketing.chkGiugno
		Get
			Return _chkGiugno
		End Get
		Set (byval value as integer)
			If _chkGiugno <> value Then
				IsChanged = True
				WhatIsChanged.chkGiugno = True
				_chkGiugno = value
			End If
		End Set
	End property 

	Protected _chkLuglio as integer  = 0 
	Public Overridable Property chkLuglio() as integer  Implements _IFiltroMarketing.chkLuglio
		Get
			Return _chkLuglio
		End Get
		Set (byval value as integer)
			If _chkLuglio <> value Then
				IsChanged = True
				WhatIsChanged.chkLuglio = True
				_chkLuglio = value
			End If
		End Set
	End property 

	Protected _chkMaggio as integer  = 0 
	Public Overridable Property chkMaggio() as integer  Implements _IFiltroMarketing.chkMaggio
		Get
			Return _chkMaggio
		End Get
		Set (byval value as integer)
			If _chkMaggio <> value Then
				IsChanged = True
				WhatIsChanged.chkMaggio = True
				_chkMaggio = value
			End If
		End Set
	End property 

	Protected _chkMarzo as integer  = 0 
	Public Overridable Property chkMarzo() as integer  Implements _IFiltroMarketing.chkMarzo
		Get
			Return _chkMarzo
		End Get
		Set (byval value as integer)
			If _chkMarzo <> value Then
				IsChanged = True
				WhatIsChanged.chkMarzo = True
				_chkMarzo = value
			End If
		End Set
	End property 

	Protected _chkNovembre as integer  = 0 
	Public Overridable Property chkNovembre() as integer  Implements _IFiltroMarketing.chkNovembre
		Get
			Return _chkNovembre
		End Get
		Set (byval value as integer)
			If _chkNovembre <> value Then
				IsChanged = True
				WhatIsChanged.chkNovembre = True
				_chkNovembre = value
			End If
		End Set
	End property 

	Protected _chkOttobre as integer  = 0 
	Public Overridable Property chkOttobre() as integer  Implements _IFiltroMarketing.chkOttobre
		Get
			Return _chkOttobre
		End Get
		Set (byval value as integer)
			If _chkOttobre <> value Then
				IsChanged = True
				WhatIsChanged.chkOttobre = True
				_chkOttobre = value
			End If
		End Set
	End property 

	Protected _chkSettembre as integer  = 0 
	Public Overridable Property chkSettembre() as integer  Implements _IFiltroMarketing.chkSettembre
		Get
			Return _chkSettembre
		End Get
		Set (byval value as integer)
			If _chkSettembre <> value Then
				IsChanged = True
				WhatIsChanged.chkSettembre = True
				_chkSettembre = value
			End If
		End Set
	End property 

	Protected _Citta as string  = "" 
	Public Overridable Property Citta() as string  Implements _IFiltroMarketing.Citta
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

	Protected _HannoAcqAlmenoUn as integer  = 0 
	Public Overridable Property HannoAcqAlmenoUn() as integer  Implements _IFiltroMarketing.HannoAcqAlmenoUn
		Get
			Return _HannoAcqAlmenoUn
		End Get
		Set (byval value as integer)
			If _HannoAcqAlmenoUn <> value Then
				IsChanged = True
				WhatIsChanged.HannoAcqAlmenoUn = True
				_HannoAcqAlmenoUn = value
			End If
		End Set
	End property 

	Protected _IdGruppo as integer  = 0 
	Public Overridable Property IdGruppo() as integer  Implements _IFiltroMarketing.IdGruppo
		Get
			Return _IdGruppo
		End Get
		Set (byval value as integer)
			If _IdGruppo <> value Then
				IsChanged = True
				WhatIsChanged.IdGruppo = True
				_IdGruppo = value
			End If
		End Set
	End property 

	Protected _InseritiDa as integer  = 0 
	Public Overridable Property InseritiDa() as integer  Implements _IFiltroMarketing.InseritiDa
		Get
			Return _InseritiDa
		End Get
		Set (byval value as integer)
			If _InseritiDa <> value Then
				IsChanged = True
				WhatIsChanged.InseritiDa = True
				_InseritiDa = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IFiltroMarketing.Nome
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

	Protected _NonHannoMaiAcqUn as integer  = 0 
	Public Overridable Property NonHannoMaiAcqUn() as integer  Implements _IFiltroMarketing.NonHannoMaiAcqUn
		Get
			Return _NonHannoMaiAcqUn
		End Get
		Set (byval value as integer)
			If _NonHannoMaiAcqUn <> value Then
				IsChanged = True
				WhatIsChanged.NonHannoMaiAcqUn = True
				_NonHannoMaiAcqUn = value
			End If
		End Set
	End property 

	Protected _NonHannoMaiSpeso as integer  = 0 
	Public Overridable Property NonHannoMaiSpeso() as integer  Implements _IFiltroMarketing.NonHannoMaiSpeso
		Get
			Return _NonHannoMaiSpeso
		End Get
		Set (byval value as integer)
			If _NonHannoMaiSpeso <> value Then
				IsChanged = True
				WhatIsChanged.NonHannoMaiSpeso = True
				_NonHannoMaiSpeso = value
			End If
		End Set
	End property 

	Protected _Ricorsiva as integer  = 0 
	Public Overridable Property Ricorsiva() as integer  Implements _IFiltroMarketing.Ricorsiva
		Get
			Return _Ricorsiva
		End Get
		Set (byval value as integer)
			If _Ricorsiva <> value Then
				IsChanged = True
				WhatIsChanged.Ricorsiva = True
				_Ricorsiva = value
			End If
		End Set
	End property 

	Protected _SpesaNelPeriodo as integer  = 0 
	Public Overridable Property SpesaNelPeriodo() as integer  Implements _IFiltroMarketing.SpesaNelPeriodo
		Get
			Return _SpesaNelPeriodo
		End Get
		Set (byval value as integer)
			If _SpesaNelPeriodo <> value Then
				IsChanged = True
				WhatIsChanged.SpesaNelPeriodo = True
				_SpesaNelPeriodo = value
			End If
		End Set
	End property 

	Protected _SpesaNelPeriodoMaggioreDi as integer  = 0 
	Public Overridable Property SpesaNelPeriodoMaggioreDi() as integer  Implements _IFiltroMarketing.SpesaNelPeriodoMaggioreDi
		Get
			Return _SpesaNelPeriodoMaggioreDi
		End Get
		Set (byval value as integer)
			If _SpesaNelPeriodoMaggioreDi <> value Then
				IsChanged = True
				WhatIsChanged.SpesaNelPeriodoMaggioreDi = True
				_SpesaNelPeriodoMaggioreDi = value
			End If
		End Set
	End property 

	Protected _SpesaNelPeriodoMinoreDi as integer  = 0 
	Public Overridable Property SpesaNelPeriodoMinoreDi() as integer  Implements _IFiltroMarketing.SpesaNelPeriodoMinoreDi
		Get
			Return _SpesaNelPeriodoMinoreDi
		End Get
		Set (byval value as integer)
			If _SpesaNelPeriodoMinoreDi <> value Then
				IsChanged = True
				WhatIsChanged.SpesaNelPeriodoMinoreDi = True
				_SpesaNelPeriodoMinoreDi = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IFiltroMarketing.Stato
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

	Protected _tag as string  = "" 
	Public Overridable Property tag() as string  Implements _IFiltroMarketing.tag
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

	Protected _Tipo as integer  = 0 
	Public Overridable Property Tipo() as integer  Implements _IFiltroMarketing.Tipo
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

	Protected _TipoFiltro as integer  = 0 
	Public Overridable Property TipoFiltro() as integer  Implements _IFiltroMarketing.TipoFiltro
		Get
			Return _TipoFiltro
		End Get
		Set (byval value as integer)
			If _TipoFiltro <> value Then
				IsChanged = True
				WhatIsChanged.TipoFiltro = True
				_TipoFiltro = value
			End If
		End Set
	End property 

	Protected _TipoOrigine as integer  = 0 
	Public Overridable Property TipoOrigine() as integer  Implements _IFiltroMarketing.TipoOrigine
		Get
			Return _TipoOrigine
		End Get
		Set (byval value as integer)
			If _TipoOrigine <> value Then
				IsChanged = True
				WhatIsChanged.TipoOrigine = True
				_TipoOrigine = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FiltroMarketing from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FiltroMarketing = Manager.Read(Id)
				_IdFiltroMarketing = int.IdFiltroMarketing
				_Cap = int.Cap
				_CategoriaMarketing = int.CategoriaMarketing
				_chkAgosto = int.chkAgosto
				_chkAprile = int.chkAprile
				_chkDicembre = int.chkDicembre
				_chkFebbraio = int.chkFebbraio
				_chkGennaio = int.chkGennaio
				_chkGiugno = int.chkGiugno
				_chkLuglio = int.chkLuglio
				_chkMaggio = int.chkMaggio
				_chkMarzo = int.chkMarzo
				_chkNovembre = int.chkNovembre
				_chkOttobre = int.chkOttobre
				_chkSettembre = int.chkSettembre
				_Citta = int.Citta
				_HannoAcqAlmenoUn = int.HannoAcqAlmenoUn
				_IdGruppo = int.IdGruppo
				_InseritiDa = int.InseritiDa
				_Nome = int.Nome
				_NonHannoMaiAcqUn = int.NonHannoMaiAcqUn
				_NonHannoMaiSpeso = int.NonHannoMaiSpeso
				_Ricorsiva = int.Ricorsiva
				_SpesaNelPeriodo = int.SpesaNelPeriodo
				_SpesaNelPeriodoMaggioreDi = int.SpesaNelPeriodoMaggioreDi
				_SpesaNelPeriodoMinoreDi = int.SpesaNelPeriodoMinoreDi
				_Stato = int.Stato
				_tag = int.tag
				_Tipo = int.Tipo
				_TipoFiltro = int.TipoFiltro
				_TipoOrigine = int.TipoOrigine
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an FiltroMarketing on DB.
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
		if _Cap.Length > 255 then Ris = False
		if _Citta.Length > 255 then Ris = False
		if _Nome.Length > 255 then Ris = False
		if _tag.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_filtromarketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFiltroMarketing

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdFiltroMarketing() as integer
	Property Cap() as string
	Property CategoriaMarketing() as integer
	Property chkAgosto() as integer
	Property chkAprile() as integer
	Property chkDicembre() as integer
	Property chkFebbraio() as integer
	Property chkGennaio() as integer
	Property chkGiugno() as integer
	Property chkLuglio() as integer
	Property chkMaggio() as integer
	Property chkMarzo() as integer
	Property chkNovembre() as integer
	Property chkOttobre() as integer
	Property chkSettembre() as integer
	Property Citta() as string
	Property HannoAcqAlmenoUn() as integer
	Property IdGruppo() as integer
	Property InseritiDa() as integer
	Property Nome() as string
	Property NonHannoMaiAcqUn() as integer
	Property NonHannoMaiSpeso() as integer
	Property Ricorsiva() as integer
	Property SpesaNelPeriodo() as integer
	Property SpesaNelPeriodoMaggioreDi() as integer
	Property SpesaNelPeriodoMinoreDi() as integer
	Property Stato() as integer
	Property tag() as string
	Property Tipo() as integer
	Property TipoFiltro() as integer
	Property TipoOrigine() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class FiltroMarketing
		Public Shared ReadOnly Property IdFiltroMarketing As New LUNA.LunaFieldName("IdFiltroMarketing")
		Public Shared ReadOnly Property Cap As New LUNA.LunaFieldName("Cap")
		Public Shared ReadOnly Property CategoriaMarketing As New LUNA.LunaFieldName("CategoriaMarketing")
		Public Shared ReadOnly Property chkAgosto As New LUNA.LunaFieldName("chkAgosto")
		Public Shared ReadOnly Property chkAprile As New LUNA.LunaFieldName("chkAprile")
		Public Shared ReadOnly Property chkDicembre As New LUNA.LunaFieldName("chkDicembre")
		Public Shared ReadOnly Property chkFebbraio As New LUNA.LunaFieldName("chkFebbraio")
		Public Shared ReadOnly Property chkGennaio As New LUNA.LunaFieldName("chkGennaio")
		Public Shared ReadOnly Property chkGiugno As New LUNA.LunaFieldName("chkGiugno")
		Public Shared ReadOnly Property chkLuglio As New LUNA.LunaFieldName("chkLuglio")
		Public Shared ReadOnly Property chkMaggio As New LUNA.LunaFieldName("chkMaggio")
		Public Shared ReadOnly Property chkMarzo As New LUNA.LunaFieldName("chkMarzo")
		Public Shared ReadOnly Property chkNovembre As New LUNA.LunaFieldName("chkNovembre")
		Public Shared ReadOnly Property chkOttobre As New LUNA.LunaFieldName("chkOttobre")
		Public Shared ReadOnly Property chkSettembre As New LUNA.LunaFieldName("chkSettembre")
		Public Shared ReadOnly Property Citta As New LUNA.LunaFieldName("Citta")
		Public Shared ReadOnly Property HannoAcqAlmenoUn As New LUNA.LunaFieldName("HannoAcqAlmenoUn")
		Public Shared ReadOnly Property IdGruppo As New LUNA.LunaFieldName("IdGruppo")
		Public Shared ReadOnly Property InseritiDa As New LUNA.LunaFieldName("InseritiDa")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property NonHannoMaiAcqUn As New LUNA.LunaFieldName("NonHannoMaiAcqUn")
		Public Shared ReadOnly Property NonHannoMaiSpeso As New LUNA.LunaFieldName("NonHannoMaiSpeso")
		Public Shared ReadOnly Property Ricorsiva As New LUNA.LunaFieldName("Ricorsiva")
		Public Shared ReadOnly Property SpesaNelPeriodo As New LUNA.LunaFieldName("SpesaNelPeriodo")
		Public Shared ReadOnly Property SpesaNelPeriodoMaggioreDi As New LUNA.LunaFieldName("SpesaNelPeriodoMaggioreDi")
		Public Shared ReadOnly Property SpesaNelPeriodoMinoreDi As New LUNA.LunaFieldName("SpesaNelPeriodoMinoreDi")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property tag As New LUNA.LunaFieldName("tag")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
		Public Shared ReadOnly Property TipoFiltro As New LUNA.LunaFieldName("TipoFiltro")
		Public Shared ReadOnly Property TipoOrigine As New LUNA.LunaFieldName("TipoOrigine")
	End Class

End Class