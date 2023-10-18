#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 27/04/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_lavori
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _LavorazioneW
	Inherits LUNA.LunaBaseClassEntity
	Implements _ILavorazioneW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ILavorazioneW.FillFromDataRecord
		IdLavoro = myRecord("IdLavoro")
		if not myRecord("Accorpabile") is DBNull.Value then Accorpabile = myRecord("Accorpabile")
		if not myRecord("CostoSingCopia") is DBNull.Value then CostoSingCopia = myRecord("CostoSingCopia")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("DescrizioneEstesa") is DBNull.Value then DescrizioneEstesa = myRecord("DescrizioneEstesa")
		if not myRecord("DimensMaxH") is DBNull.Value then DimensMaxH = myRecord("DimensMaxH")
		if not myRecord("DimensMaxW") is DBNull.Value then DimensMaxW = myRecord("DimensMaxW")
		if not myRecord("DimensMedieMaxH") is DBNull.Value then DimensMedieMaxH = myRecord("DimensMedieMaxH")
		if not myRecord("DimensMedieMaxW") is DBNull.Value then DimensMedieMaxW = myRecord("DimensMedieMaxW")
		if not myRecord("DimensMedieMinH") is DBNull.Value then DimensMedieMinH = myRecord("DimensMedieMinH")
		if not myRecord("DimensMedieMinW") is DBNull.Value then DimensMedieMinW = myRecord("DimensMedieMinW")
		if not myRecord("DimensMinH") is DBNull.Value then DimensMinH = myRecord("DimensMinH")
		if not myRecord("DimensMinW") is DBNull.Value then DimensMinW = myRecord("DimensMinW")
		if not myRecord("ExtraData") is DBNull.Value then ExtraData = myRecord("ExtraData")
		if not myRecord("FormatoRiferimento") is DBNull.Value then FormatoRiferimento = myRecord("FormatoRiferimento")
		if not myRecord("ggRealiz") is DBNull.Value then ggRealiz = myRecord("ggRealiz")
		if not myRecord("GrammiMax") is DBNull.Value then GrammiMax = myRecord("GrammiMax")
		if not myRecord("GrammiMin") is DBNull.Value then GrammiMin = myRecord("GrammiMin")
		if not myRecord("IdCatLav") is DBNull.Value then IdCatLav = myRecord("IdCatLav")
		if not myRecord("IdMacchinario") is DBNull.Value then IdMacchinario = myRecord("IdMacchinario")
		if not myRecord("IdMacchinario2") is DBNull.Value then IdMacchinario2 = myRecord("IdMacchinario2")
		if not myRecord("IdTipoLav") is DBNull.Value then IdTipoLav = myRecord("IdTipoLav")
		if not myRecord("ImgRif") is DBNull.Value then ImgRif = myRecord("ImgRif")
		if not myRecord("ImgZoom") is DBNull.Value then ImgZoom = myRecord("ImgZoom")
		if not myRecord("LavorazioneInterna") is DBNull.Value then LavorazioneInterna = myRecord("LavorazioneInterna")
		if not myRecord("Macchinario") is DBNull.Value then Macchinario = myRecord("Macchinario")
		if not myRecord("Premio") is DBNull.Value then Premio = myRecord("Premio")
		if not myRecord("PreTaglio") is DBNull.Value then PreTaglio = myRecord("PreTaglio")
		if not myRecord("Prezzo") is DBNull.Value then Prezzo = myRecord("Prezzo")
		if not myRecord("Pubblica") is DBNull.Value then Pubblica = myRecord("Pubblica")
		if not myRecord("SePresenteCalcolaSuSoggetti") is DBNull.Value then SePresenteCalcolaSuSoggetti = myRecord("SePresenteCalcolaSuSoggetti")
		if not myRecord("Sigla") is DBNull.Value then Sigla = myRecord("Sigla")
		if not myRecord("Stato") is DBNull.Value then Stato = myRecord("Stato")
		if not myRecord("SuCommessa") is DBNull.Value then SuCommessa = myRecord("SuCommessa")
		if not myRecord("SuProdotto") is DBNull.Value then SuProdotto = myRecord("SuProdotto")
		if not myRecord("TempoRif") is DBNull.Value then TempoRif = myRecord("TempoRif")
		if not myRecord("TipoControlloWeb") is DBNull.Value then TipoControlloWeb = myRecord("TipoControlloWeb")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of LavorazioneW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(LavorazioniWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of LavorazioneW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLavoro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Accorpabile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoSingCopia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrizioneEstesa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DimensMaxH As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DimensMaxW As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DimensMedieMaxH As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DimensMedieMaxW As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DimensMedieMinH As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DimensMedieMinW As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DimensMinH As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DimensMinW As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ExtraData As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FormatoRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ggRealiz As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GrammiMax As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GrammiMin As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatLav As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinario2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoLav As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgZoom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LavorazioneInterna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Macchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Premio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PreTaglio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Pubblica As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SePresenteCalcolaSuSoggetti As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sigla As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SuCommessa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SuProdotto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TempoRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoControlloWeb As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLavoro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Accorpabile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoSingCopia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrizioneEstesa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DimensMaxH = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DimensMaxW = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DimensMedieMaxH = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DimensMedieMaxW = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DimensMedieMinH = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DimensMedieMinW = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DimensMinH = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DimensMinW = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ExtraData = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FormatoRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ggRealiz = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GrammiMax = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GrammiMin = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatLav = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinario2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoLav = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgZoom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LavorazioneInterna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Macchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Premio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PreTaglio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Pubblica = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SePresenteCalcolaSuSoggetti = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sigla = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SuCommessa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SuProdotto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TempoRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoControlloWeb = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLavoro as integer  = 0 
	Public Overridable Property IdLavoro() as integer  Implements _ILavorazioneW.IdLavoro
		Get
			Return _IdLavoro
		End Get
		Set (byval value as integer)
			If _IdLavoro <> value Then
				IsChanged = True
				WhatIsChanged.IdLavoro = True
				_IdLavoro = value
			End If
		End Set
	End property 

	Protected _Accorpabile as integer  = 0 
	Public Overridable Property Accorpabile() as integer  Implements _ILavorazioneW.Accorpabile
		Get
			Return _Accorpabile
		End Get
		Set (byval value as integer)
			If _Accorpabile <> value Then
				IsChanged = True
				WhatIsChanged.Accorpabile = True
				_Accorpabile = value
			End If
		End Set
	End property 

	Protected _CostoSingCopia as decimal  = 0 
	Public Overridable Property CostoSingCopia() as decimal  Implements _ILavorazioneW.CostoSingCopia
		Get
			Return _CostoSingCopia
		End Get
		Set (byval value as decimal)
			If _CostoSingCopia <> value Then
				IsChanged = True
				WhatIsChanged.CostoSingCopia = True
				_CostoSingCopia = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _ILavorazioneW.Descrizione
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

	Protected _DescrizioneEstesa as string  = "" 
	Public Overridable Property DescrizioneEstesa() as string  Implements _ILavorazioneW.DescrizioneEstesa
		Get
			Return _DescrizioneEstesa
		End Get
		Set (byval value as string)
			If _DescrizioneEstesa <> value Then
				IsChanged = True
				WhatIsChanged.DescrizioneEstesa = True
				_DescrizioneEstesa = value
			End If
		End Set
	End property 

	Protected _DimensMaxH as integer  = 0 
	Public Overridable Property DimensMaxH() as integer  Implements _ILavorazioneW.DimensMaxH
		Get
			Return _DimensMaxH
		End Get
		Set (byval value as integer)
			If _DimensMaxH <> value Then
				IsChanged = True
				WhatIsChanged.DimensMaxH = True
				_DimensMaxH = value
			End If
		End Set
	End property 

	Protected _DimensMaxW as integer  = 0 
	Public Overridable Property DimensMaxW() as integer  Implements _ILavorazioneW.DimensMaxW
		Get
			Return _DimensMaxW
		End Get
		Set (byval value as integer)
			If _DimensMaxW <> value Then
				IsChanged = True
				WhatIsChanged.DimensMaxW = True
				_DimensMaxW = value
			End If
		End Set
	End property 

	Protected _DimensMedieMaxH as integer  = 0 
	Public Overridable Property DimensMedieMaxH() as integer  Implements _ILavorazioneW.DimensMedieMaxH
		Get
			Return _DimensMedieMaxH
		End Get
		Set (byval value as integer)
			If _DimensMedieMaxH <> value Then
				IsChanged = True
				WhatIsChanged.DimensMedieMaxH = True
				_DimensMedieMaxH = value
			End If
		End Set
	End property 

	Protected _DimensMedieMaxW as integer  = 0 
	Public Overridable Property DimensMedieMaxW() as integer  Implements _ILavorazioneW.DimensMedieMaxW
		Get
			Return _DimensMedieMaxW
		End Get
		Set (byval value as integer)
			If _DimensMedieMaxW <> value Then
				IsChanged = True
				WhatIsChanged.DimensMedieMaxW = True
				_DimensMedieMaxW = value
			End If
		End Set
	End property 

	Protected _DimensMedieMinH as integer  = 0 
	Public Overridable Property DimensMedieMinH() as integer  Implements _ILavorazioneW.DimensMedieMinH
		Get
			Return _DimensMedieMinH
		End Get
		Set (byval value as integer)
			If _DimensMedieMinH <> value Then
				IsChanged = True
				WhatIsChanged.DimensMedieMinH = True
				_DimensMedieMinH = value
			End If
		End Set
	End property 

	Protected _DimensMedieMinW as integer  = 0 
	Public Overridable Property DimensMedieMinW() as integer  Implements _ILavorazioneW.DimensMedieMinW
		Get
			Return _DimensMedieMinW
		End Get
		Set (byval value as integer)
			If _DimensMedieMinW <> value Then
				IsChanged = True
				WhatIsChanged.DimensMedieMinW = True
				_DimensMedieMinW = value
			End If
		End Set
	End property 

	Protected _DimensMinH as integer  = 0 
	Public Overridable Property DimensMinH() as integer  Implements _ILavorazioneW.DimensMinH
		Get
			Return _DimensMinH
		End Get
		Set (byval value as integer)
			If _DimensMinH <> value Then
				IsChanged = True
				WhatIsChanged.DimensMinH = True
				_DimensMinH = value
			End If
		End Set
	End property 

	Protected _DimensMinW as integer  = 0 
	Public Overridable Property DimensMinW() as integer  Implements _ILavorazioneW.DimensMinW
		Get
			Return _DimensMinW
		End Get
		Set (byval value as integer)
			If _DimensMinW <> value Then
				IsChanged = True
				WhatIsChanged.DimensMinW = True
				_DimensMinW = value
			End If
		End Set
	End property 

	Protected _ExtraData as string  = "" 
	Public Overridable Property ExtraData() as string  Implements _ILavorazioneW.ExtraData
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

	Protected _FormatoRiferimento as string  = "" 
	Public Overridable Property FormatoRiferimento() as string  Implements _ILavorazioneW.FormatoRiferimento
		Get
			Return _FormatoRiferimento
		End Get
		Set (byval value as string)
			If _FormatoRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.FormatoRiferimento = True
				_FormatoRiferimento = value
			End If
		End Set
	End property 

	Protected _ggRealiz as integer  = 0 
	Public Overridable Property ggRealiz() as integer  Implements _ILavorazioneW.ggRealiz
		Get
			Return _ggRealiz
		End Get
		Set (byval value as integer)
			If _ggRealiz <> value Then
				IsChanged = True
				WhatIsChanged.ggRealiz = True
				_ggRealiz = value
			End If
		End Set
	End property 

	Protected _GrammiMax as integer  = 0 
	Public Overridable Property GrammiMax() as integer  Implements _ILavorazioneW.GrammiMax
		Get
			Return _GrammiMax
		End Get
		Set (byval value as integer)
			If _GrammiMax <> value Then
				IsChanged = True
				WhatIsChanged.GrammiMax = True
				_GrammiMax = value
			End If
		End Set
	End property 

	Protected _GrammiMin as integer  = 0 
	Public Overridable Property GrammiMin() as integer  Implements _ILavorazioneW.GrammiMin
		Get
			Return _GrammiMin
		End Get
		Set (byval value as integer)
			If _GrammiMin <> value Then
				IsChanged = True
				WhatIsChanged.GrammiMin = True
				_GrammiMin = value
			End If
		End Set
	End property 

	Protected _IdCatLav as integer  = 0 
	Public Overridable Property IdCatLav() as integer  Implements _ILavorazioneW.IdCatLav
		Get
			Return _IdCatLav
		End Get
		Set (byval value as integer)
			If _IdCatLav <> value Then
				IsChanged = True
				WhatIsChanged.IdCatLav = True
				_IdCatLav = value
			End If
		End Set
	End property 

	Protected _IdMacchinario as integer  = 0 
	Public Overridable Property IdMacchinario() as integer  Implements _ILavorazioneW.IdMacchinario
		Get
			Return _IdMacchinario
		End Get
		Set (byval value as integer)
			If _IdMacchinario <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinario = True
				_IdMacchinario = value
			End If
		End Set
	End property 

	Protected _IdMacchinario2 as integer  = 0 
	Public Overridable Property IdMacchinario2() as integer  Implements _ILavorazioneW.IdMacchinario2
		Get
			Return _IdMacchinario2
		End Get
		Set (byval value as integer)
			If _IdMacchinario2 <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinario2 = True
				_IdMacchinario2 = value
			End If
		End Set
	End property 

	Protected _IdTipoLav as integer  = 0 
	Public Overridable Property IdTipoLav() as integer  Implements _ILavorazioneW.IdTipoLav
		Get
			Return _IdTipoLav
		End Get
		Set (byval value as integer)
			If _IdTipoLav <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoLav = True
				_IdTipoLav = value
			End If
		End Set
	End property 

	Protected _ImgRif as string  = "" 
	Public Overridable Property ImgRif() as string  Implements _ILavorazioneW.ImgRif
		Get
			Return _ImgRif
		End Get
		Set (byval value as string)
			If _ImgRif <> value Then
				IsChanged = True
				WhatIsChanged.ImgRif = True
				_ImgRif = value
			End If
		End Set
	End property 

	Protected _ImgZoom as string  = "" 
	Public Overridable Property ImgZoom() as string  Implements _ILavorazioneW.ImgZoom
		Get
			Return _ImgZoom
		End Get
		Set (byval value as string)
			If _ImgZoom <> value Then
				IsChanged = True
				WhatIsChanged.ImgZoom = True
				_ImgZoom = value
			End If
		End Set
	End property 

	Protected _LavorazioneInterna as integer  = 0 
	Public Overridable Property LavorazioneInterna() as integer  Implements _ILavorazioneW.LavorazioneInterna
		Get
			Return _LavorazioneInterna
		End Get
		Set (byval value as integer)
			If _LavorazioneInterna <> value Then
				IsChanged = True
				WhatIsChanged.LavorazioneInterna = True
				_LavorazioneInterna = value
			End If
		End Set
	End property 

	Protected _Macchinario as string  = "" 
	Public Overridable Property Macchinario() as string  Implements _ILavorazioneW.Macchinario
		Get
			Return _Macchinario
		End Get
		Set (byval value as string)
			If _Macchinario <> value Then
				IsChanged = True
				WhatIsChanged.Macchinario = True
				_Macchinario = value
			End If
		End Set
	End property 

	Protected _Premio as decimal  = 0 
	Public Overridable Property Premio() as decimal  Implements _ILavorazioneW.Premio
		Get
			Return _Premio
		End Get
		Set (byval value as decimal)
			If _Premio <> value Then
				IsChanged = True
				WhatIsChanged.Premio = True
				_Premio = value
			End If
		End Set
	End property 

	Protected _PreTaglio as integer  = 0 
	Public Overridable Property PreTaglio() as integer  Implements _ILavorazioneW.PreTaglio
		Get
			Return _PreTaglio
		End Get
		Set (byval value as integer)
			If _PreTaglio <> value Then
				IsChanged = True
				WhatIsChanged.PreTaglio = True
				_PreTaglio = value
			End If
		End Set
	End property 

	Protected _Prezzo as decimal  = 0 
	Public Overridable Property Prezzo() as decimal  Implements _ILavorazioneW.Prezzo
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

	Protected _Pubblica as Boolean  = False 
	Public Overridable Property Pubblica() as Boolean  Implements _ILavorazioneW.Pubblica
		Get
			Return _Pubblica
		End Get
		Set (byval value as Boolean)
			If _Pubblica <> value Then
				IsChanged = True
				WhatIsChanged.Pubblica = True
				_Pubblica = value
			End If
		End Set
	End property 

	Protected _SePresenteCalcolaSuSoggetti as integer  = 0 
	Public Overridable Property SePresenteCalcolaSuSoggetti() as integer  Implements _ILavorazioneW.SePresenteCalcolaSuSoggetti
		Get
			Return _SePresenteCalcolaSuSoggetti
		End Get
		Set (byval value as integer)
			If _SePresenteCalcolaSuSoggetti <> value Then
				IsChanged = True
				WhatIsChanged.SePresenteCalcolaSuSoggetti = True
				_SePresenteCalcolaSuSoggetti = value
			End If
		End Set
	End property 

	Protected _Sigla as string  = "" 
	Public Overridable Property Sigla() as string  Implements _ILavorazioneW.Sigla
		Get
			Return _Sigla
		End Get
		Set (byval value as string)
			If _Sigla <> value Then
				IsChanged = True
				WhatIsChanged.Sigla = True
				_Sigla = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _ILavorazioneW.Stato
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

	Protected _SuCommessa as Boolean  = False 
	Public Overridable Property SuCommessa() as Boolean  Implements _ILavorazioneW.SuCommessa
		Get
			Return _SuCommessa
		End Get
		Set (byval value as Boolean)
			If _SuCommessa <> value Then
				IsChanged = True
				WhatIsChanged.SuCommessa = True
				_SuCommessa = value
			End If
		End Set
	End property 

	Protected _SuProdotto as Boolean  = False 
	Public Overridable Property SuProdotto() as Boolean  Implements _ILavorazioneW.SuProdotto
		Get
			Return _SuProdotto
		End Get
		Set (byval value as Boolean)
			If _SuProdotto <> value Then
				IsChanged = True
				WhatIsChanged.SuProdotto = True
				_SuProdotto = value
			End If
		End Set
	End property 

	Protected _TempoRif as integer  = 0 
	Public Overridable Property TempoRif() as integer  Implements _ILavorazioneW.TempoRif
		Get
			Return _TempoRif
		End Get
		Set (byval value as integer)
			If _TempoRif <> value Then
				IsChanged = True
				WhatIsChanged.TempoRif = True
				_TempoRif = value
			End If
		End Set
	End property 

	Protected _TipoControlloWeb as integer  = 0 
	Public Overridable Property TipoControlloWeb() as integer  Implements _ILavorazioneW.TipoControlloWeb
		Get
			Return _TipoControlloWeb
		End Get
		Set (byval value as integer)
			If _TipoControlloWeb <> value Then
				IsChanged = True
				WhatIsChanged.TipoControlloWeb = True
				_TipoControlloWeb = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an LavorazioneW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As LavorazioneW = Manager.Read(Id)
				_IdLavoro = int.IdLavoro
				_Accorpabile = int.Accorpabile
				_CostoSingCopia = int.CostoSingCopia
				_Descrizione = int.Descrizione
				_DescrizioneEstesa = int.DescrizioneEstesa
				_DimensMaxH = int.DimensMaxH
				_DimensMaxW = int.DimensMaxW
				_DimensMedieMaxH = int.DimensMedieMaxH
				_DimensMedieMaxW = int.DimensMedieMaxW
				_DimensMedieMinH = int.DimensMedieMinH
				_DimensMedieMinW = int.DimensMedieMinW
				_DimensMinH = int.DimensMinH
				_DimensMinW = int.DimensMinW
				_ExtraData = int.ExtraData
				_FormatoRiferimento = int.FormatoRiferimento
				_ggRealiz = int.ggRealiz
				_GrammiMax = int.GrammiMax
				_GrammiMin = int.GrammiMin
				_IdCatLav = int.IdCatLav
				_IdMacchinario = int.IdMacchinario
				_IdMacchinario2 = int.IdMacchinario2
				_IdTipoLav = int.IdTipoLav
				_ImgRif = int.ImgRif
				_ImgZoom = int.ImgZoom
				_LavorazioneInterna = int.LavorazioneInterna
				_Macchinario = int.Macchinario
				_Premio = int.Premio
				_PreTaglio = int.PreTaglio
				_Prezzo = int.Prezzo
				_Pubblica = int.Pubblica
				_SePresenteCalcolaSuSoggetti = int.SePresenteCalcolaSuSoggetti
				_Sigla = int.Sigla
				_Stato = int.Stato
				_SuCommessa = int.SuCommessa
				_SuProdotto = int.SuProdotto
				_TempoRif = int.TempoRif
				_TipoControlloWeb = int.TipoControlloWeb
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
        If IdLavoro Then
            ris = Read(IdLavoro)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an LavorazioneW on DB.
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
		if _Descrizione.Length > 100 then Ris = False
		if _DescrizioneEstesa.Length > 255 then Ris = False
		if _ExtraData.Length > 255 then Ris = False
		if _FormatoRiferimento.Length > 255 then Ris = False
		if _ImgRif.Length > 255 then Ris = False
		if _ImgZoom.Length > 255 then Ris = False
		if _Macchinario.Length > 255 then Ris = False
		if _Sigla.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_lavori
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ILavorazioneW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLavoro() as integer
	Property Accorpabile() as integer
	Property CostoSingCopia() as decimal
	Property Descrizione() as string
	Property DescrizioneEstesa() as string
	Property DimensMaxH() as integer
	Property DimensMaxW() as integer
	Property DimensMedieMaxH() as integer
	Property DimensMedieMaxW() as integer
	Property DimensMedieMinH() as integer
	Property DimensMedieMinW() as integer
	Property DimensMinH() as integer
	Property DimensMinW() as integer
	Property ExtraData() as string
	Property FormatoRiferimento() as string
	Property ggRealiz() as integer
	Property GrammiMax() as integer
	Property GrammiMin() as integer
	Property IdCatLav() as integer
	Property IdMacchinario() as integer
	Property IdMacchinario2() as integer
	Property IdTipoLav() as integer
	Property ImgRif() as string
	Property ImgZoom() as string
	Property LavorazioneInterna() as integer
	Property Macchinario() as string
	Property Premio() as decimal
	Property PreTaglio() as integer
	Property Prezzo() as decimal
	Property Pubblica() as Boolean
	Property SePresenteCalcolaSuSoggetti() as integer
	Property Sigla() as string
	Property Stato() as integer
	Property SuCommessa() as Boolean
	Property SuProdotto() as Boolean
	Property TempoRif() as integer
	Property TipoControlloWeb() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class LavorazioneW
		Public Shared ReadOnly Property IdLavoro As New LUNA.LunaFieldName("IdLavoro")
		Public Shared ReadOnly Property Accorpabile As New LUNA.LunaFieldName("Accorpabile")
		Public Shared ReadOnly Property CostoSingCopia As New LUNA.LunaFieldName("CostoSingCopia")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property DescrizioneEstesa As New LUNA.LunaFieldName("DescrizioneEstesa")
		Public Shared ReadOnly Property DimensMaxH As New LUNA.LunaFieldName("DimensMaxH")
		Public Shared ReadOnly Property DimensMaxW As New LUNA.LunaFieldName("DimensMaxW")
		Public Shared ReadOnly Property DimensMedieMaxH As New LUNA.LunaFieldName("DimensMedieMaxH")
		Public Shared ReadOnly Property DimensMedieMaxW As New LUNA.LunaFieldName("DimensMedieMaxW")
		Public Shared ReadOnly Property DimensMedieMinH As New LUNA.LunaFieldName("DimensMedieMinH")
		Public Shared ReadOnly Property DimensMedieMinW As New LUNA.LunaFieldName("DimensMedieMinW")
		Public Shared ReadOnly Property DimensMinH As New LUNA.LunaFieldName("DimensMinH")
		Public Shared ReadOnly Property DimensMinW As New LUNA.LunaFieldName("DimensMinW")
		Public Shared ReadOnly Property ExtraData As New LUNA.LunaFieldName("ExtraData")
		Public Shared ReadOnly Property FormatoRiferimento As New LUNA.LunaFieldName("FormatoRiferimento")
		Public Shared ReadOnly Property ggRealiz As New LUNA.LunaFieldName("ggRealiz")
		Public Shared ReadOnly Property GrammiMax As New LUNA.LunaFieldName("GrammiMax")
		Public Shared ReadOnly Property GrammiMin As New LUNA.LunaFieldName("GrammiMin")
		Public Shared ReadOnly Property IdCatLav As New LUNA.LunaFieldName("IdCatLav")
		Public Shared ReadOnly Property IdMacchinario As New LUNA.LunaFieldName("IdMacchinario")
		Public Shared ReadOnly Property IdMacchinario2 As New LUNA.LunaFieldName("IdMacchinario2")
		Public Shared ReadOnly Property IdTipoLav As New LUNA.LunaFieldName("IdTipoLav")
		Public Shared ReadOnly Property ImgRif As New LUNA.LunaFieldName("ImgRif")
		Public Shared ReadOnly Property ImgZoom As New LUNA.LunaFieldName("ImgZoom")
		Public Shared ReadOnly Property LavorazioneInterna As New LUNA.LunaFieldName("LavorazioneInterna")
		Public Shared ReadOnly Property Macchinario As New LUNA.LunaFieldName("Macchinario")
		Public Shared ReadOnly Property Premio As New LUNA.LunaFieldName("Premio")
		Public Shared ReadOnly Property PreTaglio As New LUNA.LunaFieldName("PreTaglio")
		Public Shared ReadOnly Property Prezzo As New LUNA.LunaFieldName("Prezzo")
		Public Shared ReadOnly Property Pubblica As New LUNA.LunaFieldName("Pubblica")
		Public Shared ReadOnly Property SePresenteCalcolaSuSoggetti As New LUNA.LunaFieldName("SePresenteCalcolaSuSoggetti")
		Public Shared ReadOnly Property Sigla As New LUNA.LunaFieldName("Sigla")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property SuCommessa As New LUNA.LunaFieldName("SuCommessa")
		Public Shared ReadOnly Property SuProdotto As New LUNA.LunaFieldName("SuProdotto")
		Public Shared ReadOnly Property TempoRif As New LUNA.LunaFieldName("TempoRif")
		Public Shared ReadOnly Property TipoControlloWeb As New LUNA.LunaFieldName("TipoControlloWeb")
	End Class

End Class