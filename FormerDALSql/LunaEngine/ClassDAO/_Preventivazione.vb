#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 27/01/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_preventivazione
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Preventivazione
	Inherits LUNA.LunaBaseClassEntity
	Implements _IPreventivazione
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IPreventivazione.FillFromDataRecord
		IdPrev = myRecord("IdPrev")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("DescrizioneEstesa") is DBNull.Value then DescrizioneEstesa = myRecord("DescrizioneEstesa")
		if not myRecord("DispOnline") is DBNull.Value then DispOnline = myRecord("DispOnline")
		if not myRecord("ggFast") is DBNull.Value then ggFast = myRecord("ggFast")
		if not myRecord("ggNorm") is DBNull.Value then ggNorm = myRecord("ggNorm")
		if not myRecord("ggSlow") is DBNull.Value then ggSlow = myRecord("ggSlow")
		if not myRecord("GoogleDescr") is DBNull.Value then GoogleDescr = myRecord("GoogleDescr")
		if not myRecord("GraficaPerFacciata") is DBNull.Value then GraficaPerFacciata = myRecord("GraficaPerFacciata")
		if not myRecord("GruppoVariante") is DBNull.Value then GruppoVariante = myRecord("GruppoVariante")
		if not myRecord("IdColoreStampaDefault") is DBNull.Value then IdColoreStampaDefault = myRecord("IdColoreStampaDefault")
		if not myRecord("IdFunzionePack") is DBNull.Value then IdFunzionePack = myRecord("IdFunzionePack")
		if not myRecord("IdMacchinario") is DBNull.Value then IdMacchinario = myRecord("IdMacchinario")
		if not myRecord("IdMacchinarioTaglio") is DBNull.Value then IdMacchinarioTaglio = myRecord("IdMacchinarioTaglio")
		if not myRecord("IdPluginToUse") is DBNull.Value then IdPluginToUse = myRecord("IdPluginToUse")
		if not myRecord("IdReparto") is DBNull.Value then IdReparto = myRecord("IdReparto")
		if not myRecord("ImgRif") is DBNull.Value then ImgRif = myRecord("ImgRif")
		if not myRecord("ImgSito") is DBNull.Value then ImgSito = myRecord("ImgSito")
		if not myRecord("Linguetta") is DBNull.Value then Linguetta = myRecord("Linguetta")
		if not myRecord("NascondiAlbero") is DBNull.Value then NascondiAlbero = myRecord("NascondiAlbero")
		if not myRecord("PercCoupon") is DBNull.Value then PercCoupon = myRecord("PercCoupon")
		if not myRecord("PercFast") is DBNull.Value then PercFast = myRecord("PercFast")
		if not myRecord("PercSlow") is DBNull.Value then PercSlow = myRecord("PercSlow")
		if not myRecord("Prefisso") is DBNull.Value then Prefisso = myRecord("Prefisso")
		if not myRecord("RicaricoPubblico") is DBNull.Value then RicaricoPubblico = myRecord("RicaricoPubblico")
		if not myRecord("SaltaCS") is DBNull.Value then SaltaCS = myRecord("SaltaCS")
		if not myRecord("SaltaFP") is DBNull.Value then SaltaFP = myRecord("SaltaFP")
		if not myRecord("SaltaTC") is DBNull.Value then SaltaTC = myRecord("SaltaTC")
		if not myRecord("TipoProd") is DBNull.Value then TipoProd = myRecord("TipoProd")
		if not myRecord("UrlVideo") is DBNull.Value then UrlVideo = myRecord("UrlVideo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Preventivazione)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(PreventivazioniDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Preventivazione))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrizioneEstesa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DispOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ggFast As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ggNorm As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ggSlow As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GoogleDescr As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GraficaPerFacciata As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GruppoVariante As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdColoreStampaDefault As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFunzionePack As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinarioTaglio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPluginToUse As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdReparto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgSito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Linguetta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NascondiAlbero As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercCoupon As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercFast As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercSlow As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prefisso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RicaricoPubblico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SaltaCS As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SaltaFP As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SaltaTC As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property UrlVideo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrizioneEstesa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DispOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ggFast = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ggNorm = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ggSlow = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GoogleDescr = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GraficaPerFacciata = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GruppoVariante = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdColoreStampaDefault = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFunzionePack = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinarioTaglio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPluginToUse = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdReparto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgSito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Linguetta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NascondiAlbero = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercCoupon = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercFast = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercSlow = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prefisso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RicaricoPubblico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SaltaCS = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SaltaFP = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SaltaTC = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.UrlVideo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdPrev as integer  = 0 
	Public Overridable Property IdPrev() as integer  Implements _IPreventivazione.IdPrev
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

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IPreventivazione.Descrizione
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
	Public Overridable Property DescrizioneEstesa() as string  Implements _IPreventivazione.DescrizioneEstesa
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

	Protected _DispOnline as Boolean  = False 
	Public Overridable Property DispOnline() as Boolean  Implements _IPreventivazione.DispOnline
		Get
			Return _DispOnline
		End Get
		Set (byval value as Boolean)
			If _DispOnline <> value Then
				IsChanged = True
				WhatIsChanged.DispOnline = True
				_DispOnline = value
			End If
		End Set
	End property 

	Protected _ggFast as integer  = 0 
	Public Overridable Property ggFast() as integer  Implements _IPreventivazione.ggFast
		Get
			Return _ggFast
		End Get
		Set (byval value as integer)
			If _ggFast <> value Then
				IsChanged = True
				WhatIsChanged.ggFast = True
				_ggFast = value
			End If
		End Set
	End property 

	Protected _ggNorm as integer  = 0 
	Public Overridable Property ggNorm() as integer  Implements _IPreventivazione.ggNorm
		Get
			Return _ggNorm
		End Get
		Set (byval value as integer)
			If _ggNorm <> value Then
				IsChanged = True
				WhatIsChanged.ggNorm = True
				_ggNorm = value
			End If
		End Set
	End property 

	Protected _ggSlow as integer  = 0 
	Public Overridable Property ggSlow() as integer  Implements _IPreventivazione.ggSlow
		Get
			Return _ggSlow
		End Get
		Set (byval value as integer)
			If _ggSlow <> value Then
				IsChanged = True
				WhatIsChanged.ggSlow = True
				_ggSlow = value
			End If
		End Set
	End property 

	Protected _GoogleDescr as string  = "" 
	Public Overridable Property GoogleDescr() as string  Implements _IPreventivazione.GoogleDescr
		Get
			Return _GoogleDescr
		End Get
		Set (byval value as string)
			If _GoogleDescr <> value Then
				IsChanged = True
				WhatIsChanged.GoogleDescr = True
				_GoogleDescr = value
			End If
		End Set
	End property 

	Protected _GraficaPerFacciata as decimal  = 0 
	Public Overridable Property GraficaPerFacciata() as decimal  Implements _IPreventivazione.GraficaPerFacciata
		Get
			Return _GraficaPerFacciata
		End Get
		Set (byval value as decimal)
			If _GraficaPerFacciata <> value Then
				IsChanged = True
				WhatIsChanged.GraficaPerFacciata = True
				_GraficaPerFacciata = value
			End If
		End Set
	End property 

	Protected _GruppoVariante as integer  = 0 
	Public Overridable Property GruppoVariante() as integer  Implements _IPreventivazione.GruppoVariante
		Get
			Return _GruppoVariante
		End Get
		Set (byval value as integer)
			If _GruppoVariante <> value Then
				IsChanged = True
				WhatIsChanged.GruppoVariante = True
				_GruppoVariante = value
			End If
		End Set
	End property 

	Protected _IdColoreStampaDefault as integer  = 0 
	Public Overridable Property IdColoreStampaDefault() as integer  Implements _IPreventivazione.IdColoreStampaDefault
		Get
			Return _IdColoreStampaDefault
		End Get
		Set (byval value as integer)
			If _IdColoreStampaDefault <> value Then
				IsChanged = True
				WhatIsChanged.IdColoreStampaDefault = True
				_IdColoreStampaDefault = value
			End If
		End Set
	End property 

	Protected _IdFunzionePack as integer  = 0 
	Public Overridable Property IdFunzionePack() as integer  Implements _IPreventivazione.IdFunzionePack
		Get
			Return _IdFunzionePack
		End Get
		Set (byval value as integer)
			If _IdFunzionePack <> value Then
				IsChanged = True
				WhatIsChanged.IdFunzionePack = True
				_IdFunzionePack = value
			End If
		End Set
	End property 

	Protected _IdMacchinario as integer  = 0 
	Public Overridable Property IdMacchinario() as integer  Implements _IPreventivazione.IdMacchinario
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

	Protected _IdMacchinarioTaglio as integer  = 0 
	Public Overridable Property IdMacchinarioTaglio() as integer  Implements _IPreventivazione.IdMacchinarioTaglio
		Get
			Return _IdMacchinarioTaglio
		End Get
		Set (byval value as integer)
			If _IdMacchinarioTaglio <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinarioTaglio = True
				_IdMacchinarioTaglio = value
			End If
		End Set
	End property 

	Protected _IdPluginToUse as integer  = 0 
	Public Overridable Property IdPluginToUse() as integer  Implements _IPreventivazione.IdPluginToUse
		Get
			Return _IdPluginToUse
		End Get
		Set (byval value as integer)
			If _IdPluginToUse <> value Then
				IsChanged = True
				WhatIsChanged.IdPluginToUse = True
				_IdPluginToUse = value
			End If
		End Set
	End property 

	Protected _IdReparto as integer  = 0 
	Public Overridable Property IdReparto() as integer  Implements _IPreventivazione.IdReparto
		Get
			Return _IdReparto
		End Get
		Set (byval value as integer)
			If _IdReparto <> value Then
				IsChanged = True
				WhatIsChanged.IdReparto = True
				_IdReparto = value
			End If
		End Set
	End property 

	Protected _ImgRif as string  = "" 
	Public Overridable Property ImgRif() as string  Implements _IPreventivazione.ImgRif
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

	Protected _ImgSito as string  = "" 
	Public Overridable Property ImgSito() as string  Implements _IPreventivazione.ImgSito
		Get
			Return _ImgSito
		End Get
		Set (byval value as string)
			If _ImgSito <> value Then
				IsChanged = True
				WhatIsChanged.ImgSito = True
				_ImgSito = value
			End If
		End Set
	End property 

	Protected _Linguetta as integer  = 0 
	Public Overridable Property Linguetta() as integer  Implements _IPreventivazione.Linguetta
		Get
			Return _Linguetta
		End Get
		Set (byval value as integer)
			If _Linguetta <> value Then
				IsChanged = True
				WhatIsChanged.Linguetta = True
				_Linguetta = value
			End If
		End Set
	End property 

	Protected _NascondiAlbero as integer  = 0 
	Public Overridable Property NascondiAlbero() as integer  Implements _IPreventivazione.NascondiAlbero
		Get
			Return _NascondiAlbero
		End Get
		Set (byval value as integer)
			If _NascondiAlbero <> value Then
				IsChanged = True
				WhatIsChanged.NascondiAlbero = True
				_NascondiAlbero = value
			End If
		End Set
	End property 

	Protected _PercCoupon as integer  = 0 
	Public Overridable Property PercCoupon() as integer  Implements _IPreventivazione.PercCoupon
		Get
			Return _PercCoupon
		End Get
		Set (byval value as integer)
			If _PercCoupon <> value Then
				IsChanged = True
				WhatIsChanged.PercCoupon = True
				_PercCoupon = value
			End If
		End Set
	End property 

	Protected _PercFast as integer  = 0 
	Public Overridable Property PercFast() as integer  Implements _IPreventivazione.PercFast
		Get
			Return _PercFast
		End Get
		Set (byval value as integer)
			If _PercFast <> value Then
				IsChanged = True
				WhatIsChanged.PercFast = True
				_PercFast = value
			End If
		End Set
	End property 

	Protected _PercSlow as integer  = 0 
	Public Overridable Property PercSlow() as integer  Implements _IPreventivazione.PercSlow
		Get
			Return _PercSlow
		End Get
		Set (byval value as integer)
			If _PercSlow <> value Then
				IsChanged = True
				WhatIsChanged.PercSlow = True
				_PercSlow = value
			End If
		End Set
	End property 

	Protected _Prefisso as string  = "" 
	Public Overridable Property Prefisso() as string  Implements _IPreventivazione.Prefisso
		Get
			Return _Prefisso
		End Get
		Set (byval value as string)
			If _Prefisso <> value Then
				IsChanged = True
				WhatIsChanged.Prefisso = True
				_Prefisso = value
			End If
		End Set
	End property 

	Protected _RicaricoPubblico as integer  = 0 
	Public Overridable Property RicaricoPubblico() as integer  Implements _IPreventivazione.RicaricoPubblico
		Get
			Return _RicaricoPubblico
		End Get
		Set (byval value as integer)
			If _RicaricoPubblico <> value Then
				IsChanged = True
				WhatIsChanged.RicaricoPubblico = True
				_RicaricoPubblico = value
			End If
		End Set
	End property 

	Protected _SaltaCS as integer  = 0 
	Public Overridable Property SaltaCS() as integer  Implements _IPreventivazione.SaltaCS
		Get
			Return _SaltaCS
		End Get
		Set (byval value as integer)
			If _SaltaCS <> value Then
				IsChanged = True
				WhatIsChanged.SaltaCS = True
				_SaltaCS = value
			End If
		End Set
	End property 

	Protected _SaltaFP as integer  = 0 
	Public Overridable Property SaltaFP() as integer  Implements _IPreventivazione.SaltaFP
		Get
			Return _SaltaFP
		End Get
		Set (byval value as integer)
			If _SaltaFP <> value Then
				IsChanged = True
				WhatIsChanged.SaltaFP = True
				_SaltaFP = value
			End If
		End Set
	End property 

	Protected _SaltaTC as integer  = 0 
	Public Overridable Property SaltaTC() as integer  Implements _IPreventivazione.SaltaTC
		Get
			Return _SaltaTC
		End Get
		Set (byval value as integer)
			If _SaltaTC <> value Then
				IsChanged = True
				WhatIsChanged.SaltaTC = True
				_SaltaTC = value
			End If
		End Set
	End property 

	Protected _TipoProd as integer  = 0 
	Public Overridable Property TipoProd() as integer  Implements _IPreventivazione.TipoProd
		Get
			Return _TipoProd
		End Get
		Set (byval value as integer)
			If _TipoProd <> value Then
				IsChanged = True
				WhatIsChanged.TipoProd = True
				_TipoProd = value
			End If
		End Set
	End property 

	Protected _UrlVideo as string  = "" 
	Public Overridable Property UrlVideo() as string  Implements _IPreventivazione.UrlVideo
		Get
			Return _UrlVideo
		End Get
		Set (byval value as string)
			If _UrlVideo <> value Then
				IsChanged = True
				WhatIsChanged.UrlVideo = True
				_UrlVideo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Preventivazione from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Preventivazione = Manager.Read(Id)
				_IdPrev = int.IdPrev
				_Descrizione = int.Descrizione
				_DescrizioneEstesa = int.DescrizioneEstesa
				_DispOnline = int.DispOnline
				_ggFast = int.ggFast
				_ggNorm = int.ggNorm
				_ggSlow = int.ggSlow
				_GoogleDescr = int.GoogleDescr
				_GraficaPerFacciata = int.GraficaPerFacciata
				_GruppoVariante = int.GruppoVariante
				_IdColoreStampaDefault = int.IdColoreStampaDefault
				_IdFunzionePack = int.IdFunzionePack
				_IdMacchinario = int.IdMacchinario
				_IdMacchinarioTaglio = int.IdMacchinarioTaglio
				_IdPluginToUse = int.IdPluginToUse
				_IdReparto = int.IdReparto
				_ImgRif = int.ImgRif
				_ImgSito = int.ImgSito
				_Linguetta = int.Linguetta
				_NascondiAlbero = int.NascondiAlbero
				_PercCoupon = int.PercCoupon
				_PercFast = int.PercFast
				_PercSlow = int.PercSlow
				_Prefisso = int.Prefisso
				_RicaricoPubblico = int.RicaricoPubblico
				_SaltaCS = int.SaltaCS
				_SaltaFP = int.SaltaFP
				_SaltaTC = int.SaltaTC
				_TipoProd = int.TipoProd
				_UrlVideo = int.UrlVideo
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
        If IdPrev Then
            ris = Read(IdPrev)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an Preventivazione on DB.
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
		if _DescrizioneEstesa.Length > 255 then Ris = False
		if _GoogleDescr.Length > 255 then Ris = False
		if _ImgRif.Length > 255 then Ris = False
		if _ImgSito.Length > 255 then Ris = False
		if _Prefisso.Length > 255 then Ris = False
		if _UrlVideo.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_preventivazione
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IPreventivazione

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdPrev() as integer
	Property Descrizione() as string
	Property DescrizioneEstesa() as string
	Property DispOnline() as Boolean
	Property ggFast() as integer
	Property ggNorm() as integer
	Property ggSlow() as integer
	Property GoogleDescr() as string
	Property GraficaPerFacciata() as decimal
	Property GruppoVariante() as integer
	Property IdColoreStampaDefault() as integer
	Property IdFunzionePack() as integer
	Property IdMacchinario() as integer
	Property IdMacchinarioTaglio() as integer
	Property IdPluginToUse() as integer
	Property IdReparto() as integer
	Property ImgRif() as string
	Property ImgSito() as string
	Property Linguetta() as integer
	Property NascondiAlbero() as integer
	Property PercCoupon() as integer
	Property PercFast() as integer
	Property PercSlow() as integer
	Property Prefisso() as string
	Property RicaricoPubblico() as integer
	Property SaltaCS() as integer
	Property SaltaFP() as integer
	Property SaltaTC() as integer
	Property TipoProd() as integer
	Property UrlVideo() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Preventivazione
		Public Shared ReadOnly Property IdPrev As New LUNA.LunaFieldName("IdPrev")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property DescrizioneEstesa As New LUNA.LunaFieldName("DescrizioneEstesa")
		Public Shared ReadOnly Property DispOnline As New LUNA.LunaFieldName("DispOnline")
		Public Shared ReadOnly Property ggFast As New LUNA.LunaFieldName("ggFast")
		Public Shared ReadOnly Property ggNorm As New LUNA.LunaFieldName("ggNorm")
		Public Shared ReadOnly Property ggSlow As New LUNA.LunaFieldName("ggSlow")
		Public Shared ReadOnly Property GoogleDescr As New LUNA.LunaFieldName("GoogleDescr")
		Public Shared ReadOnly Property GraficaPerFacciata As New LUNA.LunaFieldName("GraficaPerFacciata")
		Public Shared ReadOnly Property GruppoVariante As New LUNA.LunaFieldName("GruppoVariante")
		Public Shared ReadOnly Property IdColoreStampaDefault As New LUNA.LunaFieldName("IdColoreStampaDefault")
		Public Shared ReadOnly Property IdFunzionePack As New LUNA.LunaFieldName("IdFunzionePack")
		Public Shared ReadOnly Property IdMacchinario As New LUNA.LunaFieldName("IdMacchinario")
		Public Shared ReadOnly Property IdMacchinarioTaglio As New LUNA.LunaFieldName("IdMacchinarioTaglio")
		Public Shared ReadOnly Property IdPluginToUse As New LUNA.LunaFieldName("IdPluginToUse")
		Public Shared ReadOnly Property IdReparto As New LUNA.LunaFieldName("IdReparto")
		Public Shared ReadOnly Property ImgRif As New LUNA.LunaFieldName("ImgRif")
		Public Shared ReadOnly Property ImgSito As New LUNA.LunaFieldName("ImgSito")
		Public Shared ReadOnly Property Linguetta As New LUNA.LunaFieldName("Linguetta")
		Public Shared ReadOnly Property NascondiAlbero As New LUNA.LunaFieldName("NascondiAlbero")
		Public Shared ReadOnly Property PercCoupon As New LUNA.LunaFieldName("PercCoupon")
		Public Shared ReadOnly Property PercFast As New LUNA.LunaFieldName("PercFast")
		Public Shared ReadOnly Property PercSlow As New LUNA.LunaFieldName("PercSlow")
		Public Shared ReadOnly Property Prefisso As New LUNA.LunaFieldName("Prefisso")
		Public Shared ReadOnly Property RicaricoPubblico As New LUNA.LunaFieldName("RicaricoPubblico")
		Public Shared ReadOnly Property SaltaCS As New LUNA.LunaFieldName("SaltaCS")
		Public Shared ReadOnly Property SaltaFP As New LUNA.LunaFieldName("SaltaFP")
		Public Shared ReadOnly Property SaltaTC As New LUNA.LunaFieldName("SaltaTC")
		Public Shared ReadOnly Property TipoProd As New LUNA.LunaFieldName("TipoProd")
		Public Shared ReadOnly Property UrlVideo As New LUNA.LunaFieldName("UrlVideo")
	End Class

End Class