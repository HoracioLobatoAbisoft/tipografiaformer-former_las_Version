#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 27/06/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_commesse
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Commessa
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICommessa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub
	Public Overridable Function Refresh() As Integer
		Dim ris As Integer = 0
		If IdCom Then
			ris = Read(IdCom)
		End If
		Return ris
	End Function
	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICommessa.FillFromDataRecord
		IdCom = myRecord("IdCom")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("Copie") is DBNull.Value then Copie = myRecord("Copie")
		if not myRecord("CostoCarta") is DBNull.Value then CostoCarta = myRecord("CostoCarta")
		if not myRecord("CostoFoglioSteso") is DBNull.Value then CostoFoglioSteso = myRecord("CostoFoglioSteso")
		if not myRecord("CostoImpianti") is DBNull.Value then CostoImpianti = myRecord("CostoImpianti")
		if not myRecord("CostoTotale") is DBNull.Value then CostoTotale = myRecord("CostoTotale")
		if not myRecord("CreataAutomaticamente") is DBNull.Value then CreataAutomaticamente = myRecord("CreataAutomaticamente")
		if not myRecord("DataCambioStato") is DBNull.Value then DataCambioStato = myRecord("DataCambioStato")
		if not myRecord("DataIns") is DBNull.Value then DataIns = myRecord("DataIns")
		if not myRecord("FilePath") is DBNull.Value then FilePath = myRecord("FilePath")
		if not myRecord("FromJob") is DBNull.Value then FromJob = myRecord("FromJob")
		if not myRecord("FronteRetro") is DBNull.Value then FronteRetro = myRecord("FronteRetro")
		if not myRecord("IdFormato") is DBNull.Value then IdFormato = myRecord("IdFormato")
		if not myRecord("IdLavorazione") is DBNull.Value then IdLavorazione = myRecord("IdLavorazione")
		if not myRecord("IdMacchinario") is DBNull.Value then IdMacchinario = myRecord("IdMacchinario")
		if not myRecord("IdModelloCommessa") is DBNull.Value then IdModelloCommessa = myRecord("IdModelloCommessa")
		if not myRecord("IdReparto") is DBNull.Value then IdReparto = myRecord("IdReparto")
		if not myRecord("IdRis") is DBNull.Value then IdRis = myRecord("IdRis")
		if not myRecord("IdTipoCom") is DBNull.Value then IdTipoCom = myRecord("IdTipoCom")
		if not myRecord("IdUtCreatore") is DBNull.Value then IdUtCreatore = myRecord("IdUtCreatore")
		if not myRecord("Largo") is DBNull.Value then Largo = myRecord("Largo")
		if not myRecord("Lungo") is DBNull.Value then Lungo = myRecord("Lungo")
		if not myRecord("MacchinaStampa") is DBNull.Value then MacchinaStampa = myRecord("MacchinaStampa")
		if not myRecord("NLastreNecessarie") is DBNull.Value then NLastreNecessarie = myRecord("NLastreNecessarie")
		if not myRecord("Numero") is DBNull.Value then Numero = myRecord("Numero")
		if not myRecord("Priorita") is DBNull.Value then Priorita = myRecord("Priorita")
		if not myRecord("Riassunto") is DBNull.Value then Riassunto = myRecord("Riassunto")
		if not myRecord("SchemaTaglio") is DBNull.Value then SchemaTaglio = myRecord("SchemaTaglio")
		if not myRecord("Segnature") is DBNull.Value then Segnature = myRecord("Segnature")
		if not myRecord("SoggettiFoglio") is DBNull.Value then SoggettiFoglio = myRecord("SoggettiFoglio")
		if not myRecord("Stato") is DBNull.Value then Stato = myRecord("Stato")
		if not myRecord("TipoCom") is DBNull.Value then TipoCom = myRecord("TipoCom")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Commessa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CommesseDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Commessa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Copie As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoFoglioSteso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoImpianti As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoTotale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CreataAutomaticamente As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataCambioStato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FilePath As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FromJob As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FronteRetro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdLavorazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdModelloCommessa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdReparto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRis As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUtCreatore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Largo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Lungo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MacchinaStampa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NLastreNecessarie As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Numero As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Priorita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Riassunto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SchemaTaglio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Segnature As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SoggettiFoglio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Copie = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoFoglioSteso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoImpianti = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoTotale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CreataAutomaticamente = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataCambioStato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FilePath = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FromJob = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FronteRetro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdLavorazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdModelloCommessa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdReparto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRis = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUtCreatore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Largo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Lungo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MacchinaStampa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NLastreNecessarie = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Numero = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Priorita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Riassunto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SchemaTaglio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Segnature = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SoggettiFoglio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoCom = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCom as integer  = 0 
	Public Overridable Property IdCom() as integer  Implements _ICommessa.IdCom
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

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _ICommessa.Annotazioni
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

	Protected _Copie as integer  = 0 
	Public Overridable Property Copie() as integer  Implements _ICommessa.Copie
		Get
			Return _Copie
		End Get
		Set (byval value as integer)
			If _Copie <> value Then
				IsChanged = True
				WhatIsChanged.Copie = True
				_Copie = value
			End If
		End Set
	End property 

	Protected _CostoCarta as decimal  = 0 
	Public Overridable Property CostoCarta() as decimal  Implements _ICommessa.CostoCarta
		Get
			Return _CostoCarta
		End Get
		Set (byval value as decimal)
			If _CostoCarta <> value Then
				IsChanged = True
				WhatIsChanged.CostoCarta = True
				_CostoCarta = value
			End If
		End Set
	End property 

	Protected _CostoFoglioSteso as decimal  = 0 
	Public Overridable Property CostoFoglioSteso() as decimal  Implements _ICommessa.CostoFoglioSteso
		Get
			Return _CostoFoglioSteso
		End Get
		Set (byval value as decimal)
			If _CostoFoglioSteso <> value Then
				IsChanged = True
				WhatIsChanged.CostoFoglioSteso = True
				_CostoFoglioSteso = value
			End If
		End Set
	End property 

	Protected _CostoImpianti as decimal  = 0 
	Public Overridable Property CostoImpianti() as decimal  Implements _ICommessa.CostoImpianti
		Get
			Return _CostoImpianti
		End Get
		Set (byval value as decimal)
			If _CostoImpianti <> value Then
				IsChanged = True
				WhatIsChanged.CostoImpianti = True
				_CostoImpianti = value
			End If
		End Set
	End property 

	Protected _CostoTotale as decimal  = 0 
	Public Overridable Property CostoTotale() as decimal  Implements _ICommessa.CostoTotale
		Get
			Return _CostoTotale
		End Get
		Set (byval value as decimal)
			If _CostoTotale <> value Then
				IsChanged = True
				WhatIsChanged.CostoTotale = True
				_CostoTotale = value
			End If
		End Set
	End property 

	Protected _CreataAutomaticamente as integer  = 0 
	Public Overridable Property CreataAutomaticamente() as integer  Implements _ICommessa.CreataAutomaticamente
		Get
			Return _CreataAutomaticamente
		End Get
		Set (byval value as integer)
			If _CreataAutomaticamente <> value Then
				IsChanged = True
				WhatIsChanged.CreataAutomaticamente = True
				_CreataAutomaticamente = value
			End If
		End Set
	End property 

	Protected _DataCambioStato as DateTime  = Nothing 
	Public Overridable Property DataCambioStato() as DateTime  Implements _ICommessa.DataCambioStato
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
	Public Overridable Property DataIns() as DateTime  Implements _ICommessa.DataIns
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

	Protected _FilePath as string  = "" 
	Public Overridable Property FilePath() as string  Implements _ICommessa.FilePath
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

	Protected _FromJob as integer  = 0 
	Public Overridable Property FromJob() as integer  Implements _ICommessa.FromJob
		Get
			Return _FromJob
		End Get
		Set (byval value as integer)
			If _FromJob <> value Then
				IsChanged = True
				WhatIsChanged.FromJob = True
				_FromJob = value
			End If
		End Set
	End property 

	Protected _FronteRetro as integer  = 0 
	Public Overridable Property FronteRetro() as integer  Implements _ICommessa.FronteRetro
		Get
			Return _FronteRetro
		End Get
		Set (byval value as integer)
			If _FronteRetro <> value Then
				IsChanged = True
				WhatIsChanged.FronteRetro = True
				_FronteRetro = value
			End If
		End Set
	End property 

	Protected _IdFormato as integer  = 0 
	Public Overridable Property IdFormato() as integer  Implements _ICommessa.IdFormato
		Get
			Return _IdFormato
		End Get
		Set (byval value as integer)
			If _IdFormato <> value Then
				IsChanged = True
				WhatIsChanged.IdFormato = True
				_IdFormato = value
			End If
		End Set
	End property 

	Protected _IdLavorazione as integer  = 0 
	Public Overridable Property IdLavorazione() as integer  Implements _ICommessa.IdLavorazione
		Get
			Return _IdLavorazione
		End Get
		Set (byval value as integer)
			If _IdLavorazione <> value Then
				IsChanged = True
				WhatIsChanged.IdLavorazione = True
				_IdLavorazione = value
			End If
		End Set
	End property 

	Protected _IdMacchinario as integer  = 0 
	Public Overridable Property IdMacchinario() as integer  Implements _ICommessa.IdMacchinario
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

	Protected _IdModelloCommessa as integer  = 0 
	Public Overridable Property IdModelloCommessa() as integer  Implements _ICommessa.IdModelloCommessa
		Get
			Return _IdModelloCommessa
		End Get
		Set (byval value as integer)
			If _IdModelloCommessa <> value Then
				IsChanged = True
				WhatIsChanged.IdModelloCommessa = True
				_IdModelloCommessa = value
			End If
		End Set
	End property 

	Protected _IdReparto as integer  = 0 
	Public Overridable Property IdReparto() as integer  Implements _ICommessa.IdReparto
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

	Protected _IdRis as integer  = 0 
	Public Overridable Property IdRis() as integer  Implements _ICommessa.IdRis
		Get
			Return _IdRis
		End Get
		Set (byval value as integer)
			If _IdRis <> value Then
				IsChanged = True
				WhatIsChanged.IdRis = True
				_IdRis = value
			End If
		End Set
	End property 

	Protected _IdTipoCom as integer  = 0 
	Public Overridable Property IdTipoCom() as integer  Implements _ICommessa.IdTipoCom
		Get
			Return _IdTipoCom
		End Get
		Set (byval value as integer)
			If _IdTipoCom <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoCom = True
				_IdTipoCom = value
			End If
		End Set
	End property 

	Protected _IdUtCreatore as integer  = 0 
	Public Overridable Property IdUtCreatore() as integer  Implements _ICommessa.IdUtCreatore
		Get
			Return _IdUtCreatore
		End Get
		Set (byval value as integer)
			If _IdUtCreatore <> value Then
				IsChanged = True
				WhatIsChanged.IdUtCreatore = True
				_IdUtCreatore = value
			End If
		End Set
	End property 

	Protected _Largo as integer  = 0 
	Public Overridable Property Largo() as integer  Implements _ICommessa.Largo
		Get
			Return _Largo
		End Get
		Set (byval value as integer)
			If _Largo <> value Then
				IsChanged = True
				WhatIsChanged.Largo = True
				_Largo = value
			End If
		End Set
	End property 

	Protected _Lungo as integer  = 0 
	Public Overridable Property Lungo() as integer  Implements _ICommessa.Lungo
		Get
			Return _Lungo
		End Get
		Set (byval value as integer)
			If _Lungo <> value Then
				IsChanged = True
				WhatIsChanged.Lungo = True
				_Lungo = value
			End If
		End Set
	End property 

	Protected _MacchinaStampa as string  = "" 
	Public Overridable Property MacchinaStampa() as string  Implements _ICommessa.MacchinaStampa
		Get
			Return _MacchinaStampa
		End Get
		Set (byval value as string)
			If _MacchinaStampa <> value Then
				IsChanged = True
				WhatIsChanged.MacchinaStampa = True
				_MacchinaStampa = value
			End If
		End Set
	End property 

	Protected _NLastreNecessarie as integer  = 0 
	Public Overridable Property NLastreNecessarie() as integer  Implements _ICommessa.NLastreNecessarie
		Get
			Return _NLastreNecessarie
		End Get
		Set (byval value as integer)
			If _NLastreNecessarie <> value Then
				IsChanged = True
				WhatIsChanged.NLastreNecessarie = True
				_NLastreNecessarie = value
			End If
		End Set
	End property 

	Protected _Numero as string  = "" 
	Public Overridable Property Numero() as string  Implements _ICommessa.Numero
		Get
			Return _Numero
		End Get
		Set (byval value as string)
			If _Numero <> value Then
				IsChanged = True
				WhatIsChanged.Numero = True
				_Numero = value
			End If
		End Set
	End property 

	Protected _Priorita as integer  = 0 
	Public Overridable Property Priorita() as integer  Implements _ICommessa.Priorita
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

	Protected _Riassunto as string  = "" 
	Public Overridable Property Riassunto() as string  Implements _ICommessa.Riassunto
		Get
			Return _Riassunto
		End Get
		Set (byval value as string)
			If _Riassunto <> value Then
				IsChanged = True
				WhatIsChanged.Riassunto = True
				_Riassunto = value
			End If
		End Set
	End property 

	Protected _SchemaTaglio as string  = "" 
	Public Overridable Property SchemaTaglio() as string  Implements _ICommessa.SchemaTaglio
		Get
			Return _SchemaTaglio
		End Get
		Set (byval value as string)
			If _SchemaTaglio <> value Then
				IsChanged = True
				WhatIsChanged.SchemaTaglio = True
				_SchemaTaglio = value
			End If
		End Set
	End property 

	Protected _Segnature as integer  = 0 
	Public Overridable Property Segnature() as integer  Implements _ICommessa.Segnature
		Get
			Return _Segnature
		End Get
		Set (byval value as integer)
			If _Segnature <> value Then
				IsChanged = True
				WhatIsChanged.Segnature = True
				_Segnature = value
			End If
		End Set
	End property 

	Protected _SoggettiFoglio as integer  = 0 
	Public Overridable Property SoggettiFoglio() as integer  Implements _ICommessa.SoggettiFoglio
		Get
			Return _SoggettiFoglio
		End Get
		Set (byval value as integer)
			If _SoggettiFoglio <> value Then
				IsChanged = True
				WhatIsChanged.SoggettiFoglio = True
				_SoggettiFoglio = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _ICommessa.Stato
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

	Protected _TipoCom as integer  = 0 
	Public Overridable Property TipoCom() as integer  Implements _ICommessa.TipoCom
		Get
			Return _TipoCom
		End Get
		Set (byval value as integer)
			If _TipoCom <> value Then
				IsChanged = True
				WhatIsChanged.TipoCom = True
				_TipoCom = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Commessa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Commessa = Manager.Read(Id)
				_IdCom = int.IdCom
				_Annotazioni = int.Annotazioni
				_Copie = int.Copie
				_CostoCarta = int.CostoCarta
				_CostoFoglioSteso = int.CostoFoglioSteso
				_CostoImpianti = int.CostoImpianti
				_CostoTotale = int.CostoTotale
				_CreataAutomaticamente = int.CreataAutomaticamente
				_DataCambioStato = int.DataCambioStato
				_DataIns = int.DataIns
				_FilePath = int.FilePath
				_FromJob = int.FromJob
				_FronteRetro = int.FronteRetro
				_IdFormato = int.IdFormato
				_IdLavorazione = int.IdLavorazione
				_IdMacchinario = int.IdMacchinario
				_IdModelloCommessa = int.IdModelloCommessa
				_IdReparto = int.IdReparto
				_IdRis = int.IdRis
				_IdTipoCom = int.IdTipoCom
				_IdUtCreatore = int.IdUtCreatore
				_Largo = int.Largo
				_Lungo = int.Lungo
				_MacchinaStampa = int.MacchinaStampa
				_NLastreNecessarie = int.NLastreNecessarie
				_Numero = int.Numero
				_Priorita = int.Priorita
				_Riassunto = int.Riassunto
				_SchemaTaglio = int.SchemaTaglio
				_Segnature = int.Segnature
				_SoggettiFoglio = int.SoggettiFoglio
				_Stato = int.Stato
				_TipoCom = int.TipoCom
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Commessa on DB.
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
		if _FilePath.Length > 255 then Ris = False
		if _MacchinaStampa.Length > 50 then Ris = False
		if _Numero.Length > 50 then Ris = False
		if _Riassunto.Length > 255 then Ris = False
		if _SchemaTaglio.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_commesse
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICommessa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCom() as integer
	Property Annotazioni() as string
	Property Copie() as integer
	Property CostoCarta() as decimal
	Property CostoFoglioSteso() as decimal
	Property CostoImpianti() as decimal
	Property CostoTotale() as decimal
	Property CreataAutomaticamente() as integer
	Property DataCambioStato() as DateTime
	Property DataIns() as DateTime
	Property FilePath() as string
	Property FromJob() as integer
	Property FronteRetro() as integer
	Property IdFormato() as integer
	Property IdLavorazione() as integer
	Property IdMacchinario() as integer
	Property IdModelloCommessa() as integer
	Property IdReparto() as integer
	Property IdRis() as integer
	Property IdTipoCom() as integer
	Property IdUtCreatore() as integer
	Property Largo() as integer
	Property Lungo() as integer
	Property MacchinaStampa() as string
	Property NLastreNecessarie() as integer
	Property Numero() as string
	Property Priorita() as integer
	Property Riassunto() as string
	Property SchemaTaglio() as string
	Property Segnature() as integer
	Property SoggettiFoglio() as integer
	Property Stato() as integer
	Property TipoCom() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Commessa
		Public Shared ReadOnly Property IdCom As New LUNA.LunaFieldName("IdCom")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property Copie As New LUNA.LunaFieldName("Copie")
		Public Shared ReadOnly Property CostoCarta As New LUNA.LunaFieldName("CostoCarta")
		Public Shared ReadOnly Property CostoFoglioSteso As New LUNA.LunaFieldName("CostoFoglioSteso")
		Public Shared ReadOnly Property CostoImpianti As New LUNA.LunaFieldName("CostoImpianti")
		Public Shared ReadOnly Property CostoTotale As New LUNA.LunaFieldName("CostoTotale")
		Public Shared ReadOnly Property CreataAutomaticamente As New LUNA.LunaFieldName("CreataAutomaticamente")
		Public Shared ReadOnly Property DataCambioStato As New LUNA.LunaFieldName("DataCambioStato")
		Public Shared ReadOnly Property DataIns As New LUNA.LunaFieldName("DataIns")
		Public Shared ReadOnly Property FilePath As New LUNA.LunaFieldName("FilePath")
		Public Shared ReadOnly Property FromJob As New LUNA.LunaFieldName("FromJob")
		Public Shared ReadOnly Property FronteRetro As New LUNA.LunaFieldName("FronteRetro")
		Public Shared ReadOnly Property IdFormato As New LUNA.LunaFieldName("IdFormato")
		Public Shared ReadOnly Property IdLavorazione As New LUNA.LunaFieldName("IdLavorazione")
		Public Shared ReadOnly Property IdMacchinario As New LUNA.LunaFieldName("IdMacchinario")
		Public Shared ReadOnly Property IdModelloCommessa As New LUNA.LunaFieldName("IdModelloCommessa")
		Public Shared ReadOnly Property IdReparto As New LUNA.LunaFieldName("IdReparto")
		Public Shared ReadOnly Property IdRis As New LUNA.LunaFieldName("IdRis")
		Public Shared ReadOnly Property IdTipoCom As New LUNA.LunaFieldName("IdTipoCom")
		Public Shared ReadOnly Property IdUtCreatore As New LUNA.LunaFieldName("IdUtCreatore")
		Public Shared ReadOnly Property Largo As New LUNA.LunaFieldName("Largo")
		Public Shared ReadOnly Property Lungo As New LUNA.LunaFieldName("Lungo")
		Public Shared ReadOnly Property MacchinaStampa As New LUNA.LunaFieldName("MacchinaStampa")
		Public Shared ReadOnly Property NLastreNecessarie As New LUNA.LunaFieldName("NLastreNecessarie")
		Public Shared ReadOnly Property Numero As New LUNA.LunaFieldName("Numero")
		Public Shared ReadOnly Property Priorita As New LUNA.LunaFieldName("Priorita")
		Public Shared ReadOnly Property Riassunto As New LUNA.LunaFieldName("Riassunto")
		Public Shared ReadOnly Property SchemaTaglio As New LUNA.LunaFieldName("SchemaTaglio")
		Public Shared ReadOnly Property Segnature As New LUNA.LunaFieldName("Segnature")
		Public Shared ReadOnly Property SoggettiFoglio As New LUNA.LunaFieldName("SoggettiFoglio")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property TipoCom As New LUNA.LunaFieldName("TipoCom")
	End Class

End Class