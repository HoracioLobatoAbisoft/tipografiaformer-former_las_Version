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
'''DAO Class for table T_prodotti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Prodotto
	Inherits LUNA.LunaBaseClassEntity
	Implements _IProdotto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IProdotto.FillFromDataRecord
		IdProd = myRecord("IdProd")
		if not myRecord("Codice") is DBNull.Value then Codice = myRecord("Codice")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("DescrizioneEstesa") is DBNull.Value then DescrizioneEstesa = myRecord("DescrizioneEstesa")
		if not myRecord("FronteRetro") is DBNull.Value then FronteRetro = myRecord("FronteRetro")
		if not myRecord("GGFast") is DBNull.Value then GGFast = myRecord("GGFast")
		if not myRecord("GGLow") is DBNull.Value then GGLow = myRecord("GGLow")
		if not myRecord("GGNormale") is DBNull.Value then GGNormale = myRecord("GGNormale")
		if not myRecord("IdCatProd") is DBNull.Value then IdCatProd = myRecord("IdCatProd")
		if not myRecord("IdFormato") is DBNull.Value then IdFormato = myRecord("IdFormato")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		if not myRecord("IdTipoCarta") is DBNull.Value then IdTipoCarta = myRecord("IdTipoCarta")
		if not myRecord("NoImpiantiSuFacciate") is DBNull.Value then NoImpiantiSuFacciate = myRecord("NoImpiantiSuFacciate")
		if not myRecord("NumColli") is DBNull.Value then NumColli = myRecord("NumColli")
		if not myRecord("NumDuplic") is DBNull.Value then NumDuplic = myRecord("NumDuplic")
		if not myRecord("NumFacciate") is DBNull.Value then NumFacciate = myRecord("NumFacciate")
		if not myRecord("NumOreMax") is DBNull.Value then NumOreMax = myRecord("NumOreMax")
		if not myRecord("NumPezzi") is DBNull.Value then NumPezzi = myRecord("NumPezzi")
		if not myRecord("NumSpazi") is DBNull.Value then NumSpazi = myRecord("NumSpazi")
		if not myRecord("PercFast") is DBNull.Value then PercFast = myRecord("PercFast")
		if not myRecord("PercLow") is DBNull.Value then PercLow = myRecord("PercLow")
		if not myRecord("PercNormale") is DBNull.Value then PercNormale = myRecord("PercNormale")
		if not myRecord("PesoComplessivo") is DBNull.Value then PesoComplessivo = myRecord("PesoComplessivo")
		if not myRecord("Prezzo") is DBNull.Value then Prezzo = myRecord("Prezzo")
		if not myRecord("PrezzoPubbl") is DBNull.Value then PrezzoPubbl = myRecord("PrezzoPubbl")
		if not myRecord("Scarto") is DBNull.Value then Scarto = myRecord("Scarto")
		if not myRecord("Status") is DBNull.Value then Status = myRecord("Status")
		if not myRecord("TipoProd") is DBNull.Value then TipoProd = myRecord("TipoProd")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Prodotto)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ProdottiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Prodotto))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrizioneEstesa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FronteRetro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GGFast As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GGLow As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GGNormale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoImpiantiSuFacciate As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumColli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumDuplic As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumFacciate As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumOreMax As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumPezzi As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumSpazi As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercFast As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercLow As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercNormale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PesoComplessivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoPubbl As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scarto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Status As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrizioneEstesa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FronteRetro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GGFast = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GGLow = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GGNormale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoImpiantiSuFacciate = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumColli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumDuplic = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumFacciate = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumOreMax = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumPezzi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumSpazi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercFast = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercLow = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercNormale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PesoComplessivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoPubbl = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scarto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Status = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoProd = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdProd as integer  = 0 
	Public Overridable Property IdProd() as integer  Implements _IProdotto.IdProd
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

	Protected _Codice as string  = "" 
	Public Overridable Property Codice() as string  Implements _IProdotto.Codice
		Get
			Return _Codice
		End Get
		Set (byval value as string)
			If _Codice <> value Then
				IsChanged = True
				WhatIsChanged.Codice = True
				_Codice = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IProdotto.Descrizione
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
	Public Overridable Property DescrizioneEstesa() as string  Implements _IProdotto.DescrizioneEstesa
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

	Protected _FronteRetro as Boolean  = False 
	Public Overridable Property FronteRetro() as Boolean  Implements _IProdotto.FronteRetro
		Get
			Return _FronteRetro
		End Get
		Set (byval value as Boolean)
			If _FronteRetro <> value Then
				IsChanged = True
				WhatIsChanged.FronteRetro = True
				_FronteRetro = value
			End If
		End Set
	End property 

	Protected _GGFast as integer  = 0 
	Public Overridable Property GGFast() as integer  Implements _IProdotto.GGFast
		Get
			Return _GGFast
		End Get
		Set (byval value as integer)
			If _GGFast <> value Then
				IsChanged = True
				WhatIsChanged.GGFast = True
				_GGFast = value
			End If
		End Set
	End property 

	Protected _GGLow as integer  = 0 
	Public Overridable Property GGLow() as integer  Implements _IProdotto.GGLow
		Get
			Return _GGLow
		End Get
		Set (byval value as integer)
			If _GGLow <> value Then
				IsChanged = True
				WhatIsChanged.GGLow = True
				_GGLow = value
			End If
		End Set
	End property 

	Protected _GGNormale as integer  = 0 
	Public Overridable Property GGNormale() as integer  Implements _IProdotto.GGNormale
		Get
			Return _GGNormale
		End Get
		Set (byval value as integer)
			If _GGNormale <> value Then
				IsChanged = True
				WhatIsChanged.GGNormale = True
				_GGNormale = value
			End If
		End Set
	End property 

	Protected _IdCatProd as integer  = 0 
	Public Overridable Property IdCatProd() as integer  Implements _IProdotto.IdCatProd
		Get
			Return _IdCatProd
		End Get
		Set (byval value as integer)
			If _IdCatProd <> value Then
				IsChanged = True
				WhatIsChanged.IdCatProd = True
				_IdCatProd = value
			End If
		End Set
	End property 

	Protected _IdFormato as integer  = 0 
	Public Overridable Property IdFormato() as integer  Implements _IProdotto.IdFormato
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

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IProdotto.IdListinoBase
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

	Protected _IdTipoCarta as integer  = 0 
	Public Overridable Property IdTipoCarta() as integer  Implements _IProdotto.IdTipoCarta
		Get
			Return _IdTipoCarta
		End Get
		Set (byval value as integer)
			If _IdTipoCarta <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoCarta = True
				_IdTipoCarta = value
			End If
		End Set
	End property 

	Protected _NoImpiantiSuFacciate as integer  = 0 
	Public Overridable Property NoImpiantiSuFacciate() as integer  Implements _IProdotto.NoImpiantiSuFacciate
		Get
			Return _NoImpiantiSuFacciate
		End Get
		Set (byval value as integer)
			If _NoImpiantiSuFacciate <> value Then
				IsChanged = True
				WhatIsChanged.NoImpiantiSuFacciate = True
				_NoImpiantiSuFacciate = value
			End If
		End Set
	End property 

	Protected _NumColli as integer  = 0 
	Public Overridable Property NumColli() as integer  Implements _IProdotto.NumColli
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

	Protected _NumDuplic as integer  = 0 
	Public Overridable Property NumDuplic() as integer  Implements _IProdotto.NumDuplic
		Get
			Return _NumDuplic
		End Get
		Set (byval value as integer)
			If _NumDuplic <> value Then
				IsChanged = True
				WhatIsChanged.NumDuplic = True
				_NumDuplic = value
			End If
		End Set
	End property 

	Protected _NumFacciate as integer  = 0 
	Public Overridable Property NumFacciate() as integer  Implements _IProdotto.NumFacciate
		Get
			Return _NumFacciate
		End Get
		Set (byval value as integer)
			If _NumFacciate <> value Then
				IsChanged = True
				WhatIsChanged.NumFacciate = True
				_NumFacciate = value
			End If
		End Set
	End property 

	Protected _NumOreMax as integer  = 0 
	Public Overridable Property NumOreMax() as integer  Implements _IProdotto.NumOreMax
		Get
			Return _NumOreMax
		End Get
		Set (byval value as integer)
			If _NumOreMax <> value Then
				IsChanged = True
				WhatIsChanged.NumOreMax = True
				_NumOreMax = value
			End If
		End Set
	End property 

	Protected _NumPezzi as integer  = 0 
	Public Overridable Property NumPezzi() as integer  Implements _IProdotto.NumPezzi
		Get
			Return _NumPezzi
		End Get
		Set (byval value as integer)
			If _NumPezzi <> value Then
				IsChanged = True
				WhatIsChanged.NumPezzi = True
				_NumPezzi = value
			End If
		End Set
	End property 

	Protected _NumSpazi as integer  = 0 
	Public Overridable Property NumSpazi() as integer  Implements _IProdotto.NumSpazi
		Get
			Return _NumSpazi
		End Get
		Set (byval value as integer)
			If _NumSpazi <> value Then
				IsChanged = True
				WhatIsChanged.NumSpazi = True
				_NumSpazi = value
			End If
		End Set
	End property 

	Protected _PercFast as integer  = 0 
	Public Overridable Property PercFast() as integer  Implements _IProdotto.PercFast
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

	Protected _PercLow as integer  = 0 
	Public Overridable Property PercLow() as integer  Implements _IProdotto.PercLow
		Get
			Return _PercLow
		End Get
		Set (byval value as integer)
			If _PercLow <> value Then
				IsChanged = True
				WhatIsChanged.PercLow = True
				_PercLow = value
			End If
		End Set
	End property 

	Protected _PercNormale as integer  = 0 
	Public Overridable Property PercNormale() as integer  Implements _IProdotto.PercNormale
		Get
			Return _PercNormale
		End Get
		Set (byval value as integer)
			If _PercNormale <> value Then
				IsChanged = True
				WhatIsChanged.PercNormale = True
				_PercNormale = value
			End If
		End Set
	End property 

	Protected _PesoComplessivo as integer  = 0 
	Public Overridable Property PesoComplessivo() as integer  Implements _IProdotto.PesoComplessivo
		Get
			Return _PesoComplessivo
		End Get
		Set (byval value as integer)
			If _PesoComplessivo <> value Then
				IsChanged = True
				WhatIsChanged.PesoComplessivo = True
				_PesoComplessivo = value
			End If
		End Set
	End property 

	Protected _Prezzo as decimal  = 0 
	Public Overridable Property Prezzo() as decimal  Implements _IProdotto.Prezzo
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

	Protected _PrezzoPubbl as decimal  = 0 
	Public Overridable Property PrezzoPubbl() as decimal  Implements _IProdotto.PrezzoPubbl
		Get
			Return _PrezzoPubbl
		End Get
		Set (byval value as decimal)
			If _PrezzoPubbl <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoPubbl = True
				_PrezzoPubbl = value
			End If
		End Set
	End property 

	Protected _Scarto as Single  = 0 
	Public Overridable Property Scarto() as Single  Implements _IProdotto.Scarto
		Get
			Return _Scarto
		End Get
		Set (byval value as Single)
			If _Scarto <> value Then
				IsChanged = True
				WhatIsChanged.Scarto = True
				_Scarto = value
			End If
		End Set
	End property 

	Protected _Status as integer  = 0 
	Public Overridable Property Status() as integer  Implements _IProdotto.Status
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

	Protected _TipoProd as integer  = 0 
	Public Overridable Property TipoProd() as integer  Implements _IProdotto.TipoProd
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Prodotto from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Prodotto = Manager.Read(Id)
				_IdProd = int.IdProd
				_Codice = int.Codice
				_Descrizione = int.Descrizione
				_DescrizioneEstesa = int.DescrizioneEstesa
				_FronteRetro = int.FronteRetro
				_GGFast = int.GGFast
				_GGLow = int.GGLow
				_GGNormale = int.GGNormale
				_IdCatProd = int.IdCatProd
				_IdFormato = int.IdFormato
				_IdListinoBase = int.IdListinoBase
				_IdTipoCarta = int.IdTipoCarta
				_NoImpiantiSuFacciate = int.NoImpiantiSuFacciate
				_NumColli = int.NumColli
				_NumDuplic = int.NumDuplic
				_NumFacciate = int.NumFacciate
				_NumOreMax = int.NumOreMax
				_NumPezzi = int.NumPezzi
				_NumSpazi = int.NumSpazi
				_PercFast = int.PercFast
				_PercLow = int.PercLow
				_PercNormale = int.PercNormale
				_PesoComplessivo = int.PesoComplessivo
				_Prezzo = int.Prezzo
				_PrezzoPubbl = int.PrezzoPubbl
				_Scarto = int.Scarto
				_Status = int.Status
				_TipoProd = int.TipoProd
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Prodotto on DB.
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
		if _Codice.Length > 50 then Ris = False
		if _Descrizione.Length > 200 then Ris = False
		if _DescrizioneEstesa.Length > 1073741823 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_prodotti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IProdotto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdProd() as integer
	Property Codice() as string
	Property Descrizione() as string
	Property DescrizioneEstesa() as string
	Property FronteRetro() as Boolean
	Property GGFast() as integer
	Property GGLow() as integer
	Property GGNormale() as integer
	Property IdCatProd() as integer
	Property IdFormato() as integer
	Property IdListinoBase() as integer
	Property IdTipoCarta() as integer
	Property NoImpiantiSuFacciate() as integer
	Property NumColli() as integer
	Property NumDuplic() as integer
	Property NumFacciate() as integer
	Property NumOreMax() as integer
	Property NumPezzi() as integer
	Property NumSpazi() as integer
	Property PercFast() as integer
	Property PercLow() as integer
	Property PercNormale() as integer
	Property PesoComplessivo() as integer
	Property Prezzo() as decimal
	Property PrezzoPubbl() as decimal
	Property Scarto() as Single
	Property Status() as integer
	Property TipoProd() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Prodotto
		Public Shared ReadOnly Property IdProd As New LUNA.LunaFieldName("IdProd")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property DescrizioneEstesa As New LUNA.LunaFieldName("DescrizioneEstesa")
		Public Shared ReadOnly Property FronteRetro As New LUNA.LunaFieldName("FronteRetro")
		Public Shared ReadOnly Property GGFast As New LUNA.LunaFieldName("GGFast")
		Public Shared ReadOnly Property GGLow As New LUNA.LunaFieldName("GGLow")
		Public Shared ReadOnly Property GGNormale As New LUNA.LunaFieldName("GGNormale")
		Public Shared ReadOnly Property IdCatProd As New LUNA.LunaFieldName("IdCatProd")
		Public Shared ReadOnly Property IdFormato As New LUNA.LunaFieldName("IdFormato")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdTipoCarta As New LUNA.LunaFieldName("IdTipoCarta")
		Public Shared ReadOnly Property NoImpiantiSuFacciate As New LUNA.LunaFieldName("NoImpiantiSuFacciate")
		Public Shared ReadOnly Property NumColli As New LUNA.LunaFieldName("NumColli")
		Public Shared ReadOnly Property NumDuplic As New LUNA.LunaFieldName("NumDuplic")
		Public Shared ReadOnly Property NumFacciate As New LUNA.LunaFieldName("NumFacciate")
		Public Shared ReadOnly Property NumOreMax As New LUNA.LunaFieldName("NumOreMax")
		Public Shared ReadOnly Property NumPezzi As New LUNA.LunaFieldName("NumPezzi")
		Public Shared ReadOnly Property NumSpazi As New LUNA.LunaFieldName("NumSpazi")
		Public Shared ReadOnly Property PercFast As New LUNA.LunaFieldName("PercFast")
		Public Shared ReadOnly Property PercLow As New LUNA.LunaFieldName("PercLow")
		Public Shared ReadOnly Property PercNormale As New LUNA.LunaFieldName("PercNormale")
		Public Shared ReadOnly Property PesoComplessivo As New LUNA.LunaFieldName("PesoComplessivo")
		Public Shared ReadOnly Property Prezzo As New LUNA.LunaFieldName("Prezzo")
		Public Shared ReadOnly Property PrezzoPubbl As New LUNA.LunaFieldName("PrezzoPubbl")
		Public Shared ReadOnly Property Scarto As New LUNA.LunaFieldName("Scarto")
		Public Shared ReadOnly Property Status As New LUNA.LunaFieldName("Status")
		Public Shared ReadOnly Property TipoProd As New LUNA.LunaFieldName("TipoProd")
	End Class

End Class