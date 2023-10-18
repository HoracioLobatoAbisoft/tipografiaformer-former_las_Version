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
'''DAO Class for table Td_tipocommessa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _TipoCommessa
	Inherits LUNA.LunaBaseClassEntity
	Implements _ITipoCommessa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ITipoCommessa.FillFromDataRecord
		IdTipoCom = myRecord("IdTipoCom")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("FronteRetro") is DBNull.Value then FronteRetro = myRecord("FronteRetro")
		if not myRecord("IdCatModelli") is DBNull.Value then IdCatModelli = myRecord("IdCatModelli")
		if not myRecord("IdFormato") is DBNull.Value then IdFormato = myRecord("IdFormato")
		if not myRecord("IdImpianto") is DBNull.Value then IdImpianto = myRecord("IdImpianto")
		if not myRecord("IdRis") is DBNull.Value then IdRis = myRecord("IdRis")
		if not myRecord("MacchinaStampa") is DBNull.Value then MacchinaStampa = myRecord("MacchinaStampa")
		if not myRecord("NumSpazi") is DBNull.Value then NumSpazi = myRecord("NumSpazi")
		if not myRecord("PremioStampa") is DBNull.Value then PremioStampa = myRecord("PremioStampa")
		if not myRecord("Quantita") is DBNull.Value then Quantita = myRecord("Quantita")
		if not myRecord("TempoRif") is DBNull.Value then TempoRif = myRecord("TempoRif")
		if not myRecord("TipoCom") is DBNull.Value then TipoCom = myRecord("TipoCom")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of TipoCommessa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(TipoCommesseDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of TipoCommessa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdTipoCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FronteRetro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatModelli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdImpianto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRis As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MacchinaStampa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumSpazi As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PremioStampa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quantita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TempoRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdTipoCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FronteRetro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatModelli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdImpianto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRis = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MacchinaStampa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumSpazi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PremioStampa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quantita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TempoRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoCom = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdTipoCom as integer  = 0 
	Public Overridable Property IdTipoCom() as integer  Implements _ITipoCommessa.IdTipoCom
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

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _ITipoCommessa.Descrizione
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

	Protected _FronteRetro as Boolean  = False 
	Public Overridable Property FronteRetro() as Boolean  Implements _ITipoCommessa.FronteRetro
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

	Protected _IdCatModelli as integer  = 0 
	Public Overridable Property IdCatModelli() as integer  Implements _ITipoCommessa.IdCatModelli
		Get
			Return _IdCatModelli
		End Get
		Set (byval value as integer)
			If _IdCatModelli <> value Then
				IsChanged = True
				WhatIsChanged.IdCatModelli = True
				_IdCatModelli = value
			End If
		End Set
	End property 

	Protected _IdFormato as integer  = 0 
	Public Overridable Property IdFormato() as integer  Implements _ITipoCommessa.IdFormato
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

	Protected _IdImpianto as integer  = 0 
	Public Overridable Property IdImpianto() as integer  Implements _ITipoCommessa.IdImpianto
		Get
			Return _IdImpianto
		End Get
		Set (byval value as integer)
			If _IdImpianto <> value Then
				IsChanged = True
				WhatIsChanged.IdImpianto = True
				_IdImpianto = value
			End If
		End Set
	End property 

	Protected _IdRis as integer  = 0 
	Public Overridable Property IdRis() as integer  Implements _ITipoCommessa.IdRis
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

	Protected _MacchinaStampa as string  = "" 
	Public Overridable Property MacchinaStampa() as string  Implements _ITipoCommessa.MacchinaStampa
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

	Protected _NumSpazi as integer  = 0 
	Public Overridable Property NumSpazi() as integer  Implements _ITipoCommessa.NumSpazi
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

	Protected _PremioStampa as decimal  = 0 
	Public Overridable Property PremioStampa() as decimal  Implements _ITipoCommessa.PremioStampa
		Get
			Return _PremioStampa
		End Get
		Set (byval value as decimal)
			If _PremioStampa <> value Then
				IsChanged = True
				WhatIsChanged.PremioStampa = True
				_PremioStampa = value
			End If
		End Set
	End property 

	Protected _Quantita as integer  = 0 
	Public Overridable Property Quantita() as integer  Implements _ITipoCommessa.Quantita
		Get
			Return _Quantita
		End Get
		Set (byval value as integer)
			If _Quantita <> value Then
				IsChanged = True
				WhatIsChanged.Quantita = True
				_Quantita = value
			End If
		End Set
	End property 

	Protected _TempoRif as integer  = 0 
	Public Overridable Property TempoRif() as integer  Implements _ITipoCommessa.TempoRif
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

	Protected _TipoCom as integer  = 0 
	Public Overridable Property TipoCom() as integer  Implements _ITipoCommessa.TipoCom
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
	'''This method read an TipoCommessa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As TipoCommessa = Manager.Read(Id)
				_IdTipoCom = int.IdTipoCom
				_Descrizione = int.Descrizione
				_FronteRetro = int.FronteRetro
				_IdCatModelli = int.IdCatModelli
				_IdFormato = int.IdFormato
				_IdImpianto = int.IdImpianto
				_IdRis = int.IdRis
				_MacchinaStampa = int.MacchinaStampa
				_NumSpazi = int.NumSpazi
				_PremioStampa = int.PremioStampa
				_Quantita = int.Quantita
				_TempoRif = int.TempoRif
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
	'''This method save an TipoCommessa on DB.
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
		if _MacchinaStampa.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"

	
	Protected _ListLavorazioniSuCommessa as List(Of LavorazioniSuCommessa)
	<XmlElementAttribute("ListLavorazioniSuCommessa")> _
	Public Property ListLavorazioniSuCommessa() as List(Of LavorazioniSuCommessa)
		Get
			If _ListLavorazioniSuCommessa Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
				Using Mgr As New LavorazioniSuCommessaDAO
					Dim Param1 As New LUNA.LunaSearchParameter("IdTipoCom", _IdTipoCom)
					_ListLavorazioniSuCommessa = Mgr.FindAll(Param1)
				End Using
			End If
			Return _ListLavorazioniSuCommessa
		End Get
		Set (ByVal value As List(Of LavorazioniSuCommessa))
			_ListLavorazioniSuCommessa = value
		End Set
	End Property


#End Region

End Class 

''' <summary>
'''Interface for table Td_tipocommessa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITipoCommessa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdTipoCom() as integer
	Property Descrizione() as string
	Property FronteRetro() as Boolean
	Property IdCatModelli() as integer
	Property IdFormato() as integer
	Property IdImpianto() as integer
	Property IdRis() as integer
	Property MacchinaStampa() as string
	Property NumSpazi() as integer
	Property PremioStampa() as decimal
	Property Quantita() as integer
	Property TempoRif() as integer
	Property TipoCom() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class TipoCommessa
		Public Shared ReadOnly Property IdTipoCom As New LUNA.LunaFieldName("IdTipoCom")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property FronteRetro As New LUNA.LunaFieldName("FronteRetro")
		Public Shared ReadOnly Property IdCatModelli As New LUNA.LunaFieldName("IdCatModelli")
		Public Shared ReadOnly Property IdFormato As New LUNA.LunaFieldName("IdFormato")
		Public Shared ReadOnly Property IdImpianto As New LUNA.LunaFieldName("IdImpianto")
		Public Shared ReadOnly Property IdRis As New LUNA.LunaFieldName("IdRis")
		Public Shared ReadOnly Property MacchinaStampa As New LUNA.LunaFieldName("MacchinaStampa")
		Public Shared ReadOnly Property NumSpazi As New LUNA.LunaFieldName("NumSpazi")
		Public Shared ReadOnly Property PremioStampa As New LUNA.LunaFieldName("PremioStampa")
		Public Shared ReadOnly Property Quantita As New LUNA.LunaFieldName("Quantita")
		Public Shared ReadOnly Property TempoRif As New LUNA.LunaFieldName("TempoRif")
		Public Shared ReadOnly Property TipoCom As New LUNA.LunaFieldName("TipoCom")
	End Class

End Class