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
'''DAO Class for table T_gruppi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Gruppo
	Inherits LUNA.LunaBaseClassEntity
	Implements _IGruppo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IGruppo.FillFromDataRecord
		IdGruppo = myRecord("IdGruppo")
		if not myRecord("AncheNoMail") is DBNull.Value then AncheNoMail = myRecord("AncheNoMail")
		if not myRecord("Cap") is DBNull.Value then Cap = myRecord("Cap")
		if not myRecord("CategoriaMarketing") is DBNull.Value then CategoriaMarketing = myRecord("CategoriaMarketing")
		if not myRecord("Citta") is DBNull.Value then Citta = myRecord("Citta")
		if not myRecord("DocumentiInScadenzaAl") is DBNull.Value then DocumentiInScadenzaAl = myRecord("DocumentiInScadenzaAl")
		if not myRecord("DocumentiInScadenzaDal") is DBNull.Value then DocumentiInScadenzaDal = myRecord("DocumentiInScadenzaDal")
		if not myRecord("HannoAcqAlmenoUn") is DBNull.Value then HannoAcqAlmenoUn = myRecord("HannoAcqAlmenoUn")
		if not myRecord("HannoSpesoAl") is DBNull.Value then HannoSpesoAl = myRecord("HannoSpesoAl")
		if not myRecord("HannoSpesoDal") is DBNull.Value then HannoSpesoDal = myRecord("HannoSpesoDal")
		if not myRecord("IdCorrierePredefinito") is DBNull.Value then IdCorrierePredefinito = myRecord("IdCorrierePredefinito")
		if not myRecord("InseritiDa") is DBNull.Value then InseritiDa = myRecord("InseritiDa")
		if not myRecord("LimiteMassimoSuperato") is DBNull.Value then LimiteMassimoSuperato = myRecord("LimiteMassimoSuperato")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("NonHannoMaiAcqUn") is DBNull.Value then NonHannoMaiAcqUn = myRecord("NonHannoMaiAcqUn")
		if not myRecord("NonHannoMaiSpeso") is DBNull.Value then NonHannoMaiSpeso = myRecord("NonHannoMaiSpeso")
		if not myRecord("NonHannoSpesoAl") is DBNull.Value then NonHannoSpesoAl = myRecord("NonHannoSpesoAl")
		if not myRecord("NonHannoSpesoDal") is DBNull.Value then NonHannoSpesoDal = myRecord("NonHannoSpesoDal")
		if not myRecord("RagSoc") is DBNull.Value then RagSoc = myRecord("RagSoc")
		if not myRecord("RegistratiDal") is DBNull.Value then RegistratiDal = myRecord("RegistratiDal")
		if not myRecord("SoloRegistratiDalSito") is DBNull.Value then SoloRegistratiDalSito = myRecord("SoloRegistratiDalSito")
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

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Gruppo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(GruppiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Gruppo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdGruppo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AncheNoMail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cap As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CategoriaMarketing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Citta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DocumentiInScadenzaAl As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DocumentiInScadenzaDal As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property HannoAcqAlmenoUn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property HannoSpesoAl As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property HannoSpesoDal As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCorrierePredefinito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property InseritiDa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LimiteMassimoSuperato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NonHannoMaiAcqUn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NonHannoMaiSpeso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NonHannoSpesoAl As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NonHannoSpesoDal As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RagSoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RegistratiDal As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SoloRegistratiDalSito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
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
		WhatIsChanged.IdGruppo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AncheNoMail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cap = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CategoriaMarketing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Citta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DocumentiInScadenzaAl = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DocumentiInScadenzaDal = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.HannoAcqAlmenoUn = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.HannoSpesoAl = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.HannoSpesoDal = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCorrierePredefinito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.InseritiDa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LimiteMassimoSuperato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NonHannoMaiAcqUn = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NonHannoMaiSpeso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NonHannoSpesoAl = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NonHannoSpesoDal = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RagSoc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RegistratiDal = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SoloRegistratiDalSito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SpesaNelPeriodo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SpesaNelPeriodoMaggioreDi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SpesaNelPeriodoMinoreDi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.tag = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoFiltro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoOrigine = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdGruppo as integer  = 0 
	Public Overridable Property IdGruppo() as integer  Implements _IGruppo.IdGruppo
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

	Protected _AncheNoMail as integer  = 0 
	Public Overridable Property AncheNoMail() as integer  Implements _IGruppo.AncheNoMail
		Get
			Return _AncheNoMail
		End Get
		Set (byval value as integer)
			If _AncheNoMail <> value Then
				IsChanged = True
				WhatIsChanged.AncheNoMail = True
				_AncheNoMail = value
			End If
		End Set
	End property 

	Protected _Cap as string  = "" 
	Public Overridable Property Cap() as string  Implements _IGruppo.Cap
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
	Public Overridable Property CategoriaMarketing() as integer  Implements _IGruppo.CategoriaMarketing
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

	Protected _Citta as string  = "" 
	Public Overridable Property Citta() as string  Implements _IGruppo.Citta
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

	Protected _DocumentiInScadenzaAl as DateTime  = Nothing 
	Public Overridable Property DocumentiInScadenzaAl() as DateTime  Implements _IGruppo.DocumentiInScadenzaAl
		Get
			Return _DocumentiInScadenzaAl
		End Get
		Set (byval value as DateTime)
			If _DocumentiInScadenzaAl <> value Then
				IsChanged = True
				WhatIsChanged.DocumentiInScadenzaAl = True
				_DocumentiInScadenzaAl = value
			End If
		End Set
	End property 

	Protected _DocumentiInScadenzaDal as DateTime  = Nothing 
	Public Overridable Property DocumentiInScadenzaDal() as DateTime  Implements _IGruppo.DocumentiInScadenzaDal
		Get
			Return _DocumentiInScadenzaDal
		End Get
		Set (byval value as DateTime)
			If _DocumentiInScadenzaDal <> value Then
				IsChanged = True
				WhatIsChanged.DocumentiInScadenzaDal = True
				_DocumentiInScadenzaDal = value
			End If
		End Set
	End property 

	Protected _HannoAcqAlmenoUn as integer  = 0 
	Public Overridable Property HannoAcqAlmenoUn() as integer  Implements _IGruppo.HannoAcqAlmenoUn
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

	Protected _HannoSpesoAl as DateTime  = Nothing 
	Public Overridable Property HannoSpesoAl() as DateTime  Implements _IGruppo.HannoSpesoAl
		Get
			Return _HannoSpesoAl
		End Get
		Set (byval value as DateTime)
			If _HannoSpesoAl <> value Then
				IsChanged = True
				WhatIsChanged.HannoSpesoAl = True
				_HannoSpesoAl = value
			End If
		End Set
	End property 

	Protected _HannoSpesoDal as DateTime  = Nothing 
	Public Overridable Property HannoSpesoDal() as DateTime  Implements _IGruppo.HannoSpesoDal
		Get
			Return _HannoSpesoDal
		End Get
		Set (byval value as DateTime)
			If _HannoSpesoDal <> value Then
				IsChanged = True
				WhatIsChanged.HannoSpesoDal = True
				_HannoSpesoDal = value
			End If
		End Set
	End property 

	Protected _IdCorrierePredefinito as integer  = 0 
	Public Overridable Property IdCorrierePredefinito() as integer  Implements _IGruppo.IdCorrierePredefinito
		Get
			Return _IdCorrierePredefinito
		End Get
		Set (byval value as integer)
			If _IdCorrierePredefinito <> value Then
				IsChanged = True
				WhatIsChanged.IdCorrierePredefinito = True
				_IdCorrierePredefinito = value
			End If
		End Set
	End property 

	Protected _InseritiDa as integer  = 0 
	Public Overridable Property InseritiDa() as integer  Implements _IGruppo.InseritiDa
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

	Protected _LimiteMassimoSuperato as integer  = 0 
	Public Overridable Property LimiteMassimoSuperato() as integer  Implements _IGruppo.LimiteMassimoSuperato
		Get
			Return _LimiteMassimoSuperato
		End Get
		Set (byval value as integer)
			If _LimiteMassimoSuperato <> value Then
				IsChanged = True
				WhatIsChanged.LimiteMassimoSuperato = True
				_LimiteMassimoSuperato = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IGruppo.Nome
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
	Public Overridable Property NonHannoMaiAcqUn() as integer  Implements _IGruppo.NonHannoMaiAcqUn
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
	Public Overridable Property NonHannoMaiSpeso() as integer  Implements _IGruppo.NonHannoMaiSpeso
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

	Protected _NonHannoSpesoAl as DateTime  = Nothing 
	Public Overridable Property NonHannoSpesoAl() as DateTime  Implements _IGruppo.NonHannoSpesoAl
		Get
			Return _NonHannoSpesoAl
		End Get
		Set (byval value as DateTime)
			If _NonHannoSpesoAl <> value Then
				IsChanged = True
				WhatIsChanged.NonHannoSpesoAl = True
				_NonHannoSpesoAl = value
			End If
		End Set
	End property 

	Protected _NonHannoSpesoDal as DateTime  = Nothing 
	Public Overridable Property NonHannoSpesoDal() as DateTime  Implements _IGruppo.NonHannoSpesoDal
		Get
			Return _NonHannoSpesoDal
		End Get
		Set (byval value as DateTime)
			If _NonHannoSpesoDal <> value Then
				IsChanged = True
				WhatIsChanged.NonHannoSpesoDal = True
				_NonHannoSpesoDal = value
			End If
		End Set
	End property 

	Protected _RagSoc as string  = "" 
	Public Overridable Property RagSoc() as string  Implements _IGruppo.RagSoc
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

	Protected _RegistratiDal as DateTime  = Nothing 
	Public Overridable Property RegistratiDal() as DateTime  Implements _IGruppo.RegistratiDal
		Get
			Return _RegistratiDal
		End Get
		Set (byval value as DateTime)
			If _RegistratiDal <> value Then
				IsChanged = True
				WhatIsChanged.RegistratiDal = True
				_RegistratiDal = value
			End If
		End Set
	End property 

	Protected _SoloRegistratiDalSito as integer  = 0 
	Public Overridable Property SoloRegistratiDalSito() as integer  Implements _IGruppo.SoloRegistratiDalSito
		Get
			Return _SoloRegistratiDalSito
		End Get
		Set (byval value as integer)
			If _SoloRegistratiDalSito <> value Then
				IsChanged = True
				WhatIsChanged.SoloRegistratiDalSito = True
				_SoloRegistratiDalSito = value
			End If
		End Set
	End property 

	Protected _SpesaNelPeriodo as integer  = 0 
	Public Overridable Property SpesaNelPeriodo() as integer  Implements _IGruppo.SpesaNelPeriodo
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
	Public Overridable Property SpesaNelPeriodoMaggioreDi() as integer  Implements _IGruppo.SpesaNelPeriodoMaggioreDi
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
	Public Overridable Property SpesaNelPeriodoMinoreDi() as integer  Implements _IGruppo.SpesaNelPeriodoMinoreDi
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
	Public Overridable Property Stato() as integer  Implements _IGruppo.Stato
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
	Public Overridable Property tag() as string  Implements _IGruppo.tag
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
	Public Overridable Property Tipo() as integer  Implements _IGruppo.Tipo
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
	Public Overridable Property TipoFiltro() as integer  Implements _IGruppo.TipoFiltro
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
	Public Overridable Property TipoOrigine() as integer  Implements _IGruppo.TipoOrigine
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
	'''This method read an Gruppo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Gruppo = Manager.Read(Id)
				_IdGruppo = int.IdGruppo
				_AncheNoMail = int.AncheNoMail
				_Cap = int.Cap
				_CategoriaMarketing = int.CategoriaMarketing
				_Citta = int.Citta
				_DocumentiInScadenzaAl = int.DocumentiInScadenzaAl
				_DocumentiInScadenzaDal = int.DocumentiInScadenzaDal
				_HannoAcqAlmenoUn = int.HannoAcqAlmenoUn
				_HannoSpesoAl = int.HannoSpesoAl
				_HannoSpesoDal = int.HannoSpesoDal
				_IdCorrierePredefinito = int.IdCorrierePredefinito
				_InseritiDa = int.InseritiDa
				_LimiteMassimoSuperato = int.LimiteMassimoSuperato
				_Nome = int.Nome
				_NonHannoMaiAcqUn = int.NonHannoMaiAcqUn
				_NonHannoMaiSpeso = int.NonHannoMaiSpeso
				_NonHannoSpesoAl = int.NonHannoSpesoAl
				_NonHannoSpesoDal = int.NonHannoSpesoDal
				_RagSoc = int.RagSoc
				_RegistratiDal = int.RegistratiDal
				_SoloRegistratiDalSito = int.SoloRegistratiDalSito
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
	'''This method save an Gruppo on DB.
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
		if _RagSoc.Length > 255 then Ris = False
		if _tag.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_gruppi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IGruppo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdGruppo() as integer
	Property AncheNoMail() as integer
	Property Cap() as string
	Property CategoriaMarketing() as integer
	Property Citta() as string
	Property DocumentiInScadenzaAl() as DateTime
	Property DocumentiInScadenzaDal() as DateTime
	Property HannoAcqAlmenoUn() as integer
	Property HannoSpesoAl() as DateTime
	Property HannoSpesoDal() as DateTime
	Property IdCorrierePredefinito() as integer
	Property InseritiDa() as integer
	Property LimiteMassimoSuperato() as integer
	Property Nome() as string
	Property NonHannoMaiAcqUn() as integer
	Property NonHannoMaiSpeso() as integer
	Property NonHannoSpesoAl() as DateTime
	Property NonHannoSpesoDal() as DateTime
	Property RagSoc() as string
	Property RegistratiDal() as DateTime
	Property SoloRegistratiDalSito() as integer
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

	Public Class Gruppo
		Public Shared ReadOnly Property IdGruppo As New LUNA.LunaFieldName("IdGruppo")
		Public Shared ReadOnly Property AncheNoMail As New LUNA.LunaFieldName("AncheNoMail")
		Public Shared ReadOnly Property Cap As New LUNA.LunaFieldName("Cap")
		Public Shared ReadOnly Property CategoriaMarketing As New LUNA.LunaFieldName("CategoriaMarketing")
		Public Shared ReadOnly Property Citta As New LUNA.LunaFieldName("Citta")
		Public Shared ReadOnly Property DocumentiInScadenzaAl As New LUNA.LunaFieldName("DocumentiInScadenzaAl")
		Public Shared ReadOnly Property DocumentiInScadenzaDal As New LUNA.LunaFieldName("DocumentiInScadenzaDal")
		Public Shared ReadOnly Property HannoAcqAlmenoUn As New LUNA.LunaFieldName("HannoAcqAlmenoUn")
		Public Shared ReadOnly Property HannoSpesoAl As New LUNA.LunaFieldName("HannoSpesoAl")
		Public Shared ReadOnly Property HannoSpesoDal As New LUNA.LunaFieldName("HannoSpesoDal")
		Public Shared ReadOnly Property IdCorrierePredefinito As New LUNA.LunaFieldName("IdCorrierePredefinito")
		Public Shared ReadOnly Property InseritiDa As New LUNA.LunaFieldName("InseritiDa")
		Public Shared ReadOnly Property LimiteMassimoSuperato As New LUNA.LunaFieldName("LimiteMassimoSuperato")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property NonHannoMaiAcqUn As New LUNA.LunaFieldName("NonHannoMaiAcqUn")
		Public Shared ReadOnly Property NonHannoMaiSpeso As New LUNA.LunaFieldName("NonHannoMaiSpeso")
		Public Shared ReadOnly Property NonHannoSpesoAl As New LUNA.LunaFieldName("NonHannoSpesoAl")
		Public Shared ReadOnly Property NonHannoSpesoDal As New LUNA.LunaFieldName("NonHannoSpesoDal")
		Public Shared ReadOnly Property RagSoc As New LUNA.LunaFieldName("RagSoc")
		Public Shared ReadOnly Property RegistratiDal As New LUNA.LunaFieldName("RegistratiDal")
		Public Shared ReadOnly Property SoloRegistratiDalSito As New LUNA.LunaFieldName("SoloRegistratiDalSito")
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