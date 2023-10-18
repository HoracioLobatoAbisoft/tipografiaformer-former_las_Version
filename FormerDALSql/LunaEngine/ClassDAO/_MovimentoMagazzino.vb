#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 26/02/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_magaz
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _MovimentoMagazzino
	Inherits LUNA.LunaBaseClassEntity
	Implements _IMovimentoMagazzino
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IMovimentoMagazzino.FillFromDataRecord
		IdCarMag = myRecord("IdCarMag")
		if not myRecord("CodiceForn") is DBNull.Value then CodiceForn = myRecord("CodiceForn")
		if not myRecord("DataMov") is DBNull.Value then DataMov = myRecord("DataMov")
		if not myRecord("DescrForn") is DBNull.Value then DescrForn = myRecord("DescrForn")
		if not myRecord("IdCaricoMagazzino") is DBNull.Value then IdCaricoMagazzino = myRecord("IdCaricoMagazzino")
		if not myRecord("IdCom") is DBNull.Value then IdCom = myRecord("IdCom")
		if not myRecord("IdFat") is DBNull.Value then IdFat = myRecord("IdFat")
		if not myRecord("IdForn") is DBNull.Value then IdForn = myRecord("IdForn")
		if not myRecord("IdOrdineAcquisto") is DBNull.Value then IdOrdineAcquisto = myRecord("IdOrdineAcquisto")
		if not myRecord("IdRis") is DBNull.Value then IdRis = myRecord("IdRis")
		if not myRecord("IdUt") is DBNull.Value then IdUt = myRecord("IdUt")
		if not myRecord("IdVoceCosto") is DBNull.Value then IdVoceCosto = myRecord("IdVoceCosto")
		if not myRecord("Nota") is DBNull.Value then Nota = myRecord("Nota")
		if not myRecord("Prezzo") is DBNull.Value then Prezzo = myRecord("Prezzo")
		if not myRecord("PrezzoUnit") is DBNull.Value then PrezzoUnit = myRecord("PrezzoUnit")
		if not myRecord("Qta") is DBNull.Value then Qta = myRecord("Qta")
		if not myRecord("TipoMov") is DBNull.Value then TipoMov = myRecord("TipoMov")
		if not myRecord("Urgenza") is DBNull.Value then Urgenza = myRecord("Urgenza")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of MovimentoMagazzino)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(MagazzinoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of MovimentoMagazzino))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCarMag As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodiceForn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataMov As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrForn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCaricoMagazzino As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdForn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrdineAcquisto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRis As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdVoceCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nota As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoUnit As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoMov As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Urgenza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCarMag = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodiceForn = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataMov = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrForn = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCaricoMagazzino = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdForn = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrdineAcquisto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRis = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdVoceCosto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nota = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoUnit = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoMov = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Urgenza = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCarMag as integer  = 0 
	Public Overridable Property IdCarMag() as integer  Implements _IMovimentoMagazzino.IdCarMag
		Get
			Return _IdCarMag
		End Get
		Set (byval value as integer)
			If _IdCarMag <> value Then
				IsChanged = True
				WhatIsChanged.IdCarMag = True
				_IdCarMag = value
			End If
		End Set
	End property 

	Protected _CodiceForn as string  = "" 
	Public Overridable Property CodiceForn() as string  Implements _IMovimentoMagazzino.CodiceForn
		Get
			Return _CodiceForn
		End Get
		Set (byval value as string)
			If _CodiceForn <> value Then
				IsChanged = True
				WhatIsChanged.CodiceForn = True
				_CodiceForn = value
			End If
		End Set
	End property 

	Protected _DataMov as DateTime  = Nothing 
	Public Overridable Property DataMov() as DateTime  Implements _IMovimentoMagazzino.DataMov
		Get
			Return _DataMov
		End Get
		Set (byval value as DateTime)
			If _DataMov <> value Then
				IsChanged = True
				WhatIsChanged.DataMov = True
				_DataMov = value
			End If
		End Set
	End property 

	Protected _DescrForn as string  = "" 
	Public Overridable Property DescrForn() as string  Implements _IMovimentoMagazzino.DescrForn
		Get
			Return _DescrForn
		End Get
		Set (byval value as string)
			If _DescrForn <> value Then
				IsChanged = True
				WhatIsChanged.DescrForn = True
				_DescrForn = value
			End If
		End Set
	End property 

	Protected _IdCaricoMagazzino as integer  = 0 
	Public Overridable Property IdCaricoMagazzino() as integer  Implements _IMovimentoMagazzino.IdCaricoMagazzino
		Get
			Return _IdCaricoMagazzino
		End Get
		Set (byval value as integer)
			If _IdCaricoMagazzino <> value Then
				IsChanged = True
				WhatIsChanged.IdCaricoMagazzino = True
				_IdCaricoMagazzino = value
			End If
		End Set
	End property 

	Protected _IdCom as integer  = 0 
	Public Overridable Property IdCom() as integer  Implements _IMovimentoMagazzino.IdCom
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

	Protected _IdFat as integer  = 0 
	Public Overridable Property IdFat() as integer  Implements _IMovimentoMagazzino.IdFat
		Get
			Return _IdFat
		End Get
		Set (byval value as integer)
			If _IdFat <> value Then
				IsChanged = True
				WhatIsChanged.IdFat = True
				_IdFat = value
			End If
		End Set
	End property 

	Protected _IdForn as integer  = 0 
	Public Overridable Property IdForn() as integer  Implements _IMovimentoMagazzino.IdForn
		Get
			Return _IdForn
		End Get
		Set (byval value as integer)
			If _IdForn <> value Then
				IsChanged = True
				WhatIsChanged.IdForn = True
				_IdForn = value
			End If
		End Set
	End property 

	Protected _IdOrdineAcquisto as integer  = 0 
	Public Overridable Property IdOrdineAcquisto() as integer  Implements _IMovimentoMagazzino.IdOrdineAcquisto
		Get
			Return _IdOrdineAcquisto
		End Get
		Set (byval value as integer)
			If _IdOrdineAcquisto <> value Then
				IsChanged = True
				WhatIsChanged.IdOrdineAcquisto = True
				_IdOrdineAcquisto = value
			End If
		End Set
	End property 

	Protected _IdRis as integer  = 0 
	Public Overridable Property IdRis() as integer  Implements _IMovimentoMagazzino.IdRis
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

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IMovimentoMagazzino.IdUt
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

	Protected _IdVoceCosto as integer  = 0 
	Public Overridable Property IdVoceCosto() as integer  Implements _IMovimentoMagazzino.IdVoceCosto
		Get
			Return _IdVoceCosto
		End Get
		Set (byval value as integer)
			If _IdVoceCosto <> value Then
				IsChanged = True
				WhatIsChanged.IdVoceCosto = True
				_IdVoceCosto = value
			End If
		End Set
	End property 

	Protected _Nota as string  = "" 
	Public Overridable Property Nota() as string  Implements _IMovimentoMagazzino.Nota
		Get
			Return _Nota
		End Get
		Set (byval value as string)
			If _Nota <> value Then
				IsChanged = True
				WhatIsChanged.Nota = True
				_Nota = value
			End If
		End Set
	End property 

	Protected _Prezzo as decimal  = 0 
	Public Overridable Property Prezzo() as decimal  Implements _IMovimentoMagazzino.Prezzo
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

	Protected _PrezzoUnit as decimal  = 0 
	Public Overridable Property PrezzoUnit() as decimal  Implements _IMovimentoMagazzino.PrezzoUnit
		Get
			Return _PrezzoUnit
		End Get
		Set (byval value as decimal)
			If _PrezzoUnit <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoUnit = True
				_PrezzoUnit = value
			End If
		End Set
	End property 

	Protected _Qta as Single  = 0 
	Public Overridable Property Qta() as Single  Implements _IMovimentoMagazzino.Qta
		Get
			Return _Qta
		End Get
		Set (byval value as Single)
			If _Qta <> value Then
				IsChanged = True
				WhatIsChanged.Qta = True
				_Qta = value
			End If
		End Set
	End property 

	Protected _TipoMov as integer  = 0 
	Public Overridable Property TipoMov() as integer  Implements _IMovimentoMagazzino.TipoMov
		Get
			Return _TipoMov
		End Get
		Set (byval value as integer)
			If _TipoMov <> value Then
				IsChanged = True
				WhatIsChanged.TipoMov = True
				_TipoMov = value
			End If
		End Set
	End property 

	Protected _Urgenza as integer  = 0 
	Public Overridable Property Urgenza() as integer  Implements _IMovimentoMagazzino.Urgenza
		Get
			Return _Urgenza
		End Get
		Set (byval value as integer)
			If _Urgenza <> value Then
				IsChanged = True
				WhatIsChanged.Urgenza = True
				_Urgenza = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an MovimentoMagazzino from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As MovimentoMagazzino = Manager.Read(Id)
				_IdCarMag = int.IdCarMag
				_CodiceForn = int.CodiceForn
				_DataMov = int.DataMov
				_DescrForn = int.DescrForn
				_IdCaricoMagazzino = int.IdCaricoMagazzino
				_IdCom = int.IdCom
				_IdFat = int.IdFat
				_IdForn = int.IdForn
				_IdOrdineAcquisto = int.IdOrdineAcquisto
				_IdRis = int.IdRis
				_IdUt = int.IdUt
				_IdVoceCosto = int.IdVoceCosto
				_Nota = int.Nota
				_Prezzo = int.Prezzo
				_PrezzoUnit = int.PrezzoUnit
				_Qta = int.Qta
				_TipoMov = int.TipoMov
				_Urgenza = int.Urgenza
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an MovimentoMagazzino on DB.
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
		if _CodiceForn.Length > 255 then Ris = False
		if _DescrForn.Length > 255 then Ris = False
		if _Nota.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"

	
	<XmlElementAttribute("Risorsa")> _
	Protected _Risorsa As Risorsa
	Public property Risorsa() As  Risorsa
		Get
			If _Risorsa Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
				Using Mgr As New RisorseDAO
					_Risorsa = Mgr.Read(_IdRis)
				End Using 
			End If
			Return _Risorsa
		End Get
		Set(ByVal value As Risorsa)
			_Risorsa = value
			_IdRis = _Risorsa.IdRis
		End Set
	End Property


#End Region

End Class 

''' <summary>
'''Interface for table T_magaz
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IMovimentoMagazzino

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCarMag() as integer
	Property CodiceForn() as string
	Property DataMov() as DateTime
	Property DescrForn() as string
	Property IdCaricoMagazzino() as integer
	Property IdCom() as integer
	Property IdFat() as integer
	Property IdForn() as integer
	Property IdOrdineAcquisto() as integer
	Property IdRis() as integer
	Property IdUt() as integer
	Property IdVoceCosto() as integer
	Property Nota() as string
	Property Prezzo() as decimal
	Property PrezzoUnit() as decimal
	Property Qta() as Single
	Property TipoMov() as integer
	Property Urgenza() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class MovimentoMagazzino
		Public Shared ReadOnly Property IdCarMag As New LUNA.LunaFieldName("IdCarMag")
		Public Shared ReadOnly Property CodiceForn As New LUNA.LunaFieldName("CodiceForn")
		Public Shared ReadOnly Property DataMov As New LUNA.LunaFieldName("DataMov")
		Public Shared ReadOnly Property DescrForn As New LUNA.LunaFieldName("DescrForn")
		Public Shared ReadOnly Property IdCaricoMagazzino As New LUNA.LunaFieldName("IdCaricoMagazzino")
		Public Shared ReadOnly Property IdCom As New LUNA.LunaFieldName("IdCom")
		Public Shared ReadOnly Property IdFat As New LUNA.LunaFieldName("IdFat")
		Public Shared ReadOnly Property IdForn As New LUNA.LunaFieldName("IdForn")
		Public Shared ReadOnly Property IdOrdineAcquisto As New LUNA.LunaFieldName("IdOrdineAcquisto")
		Public Shared ReadOnly Property IdRis As New LUNA.LunaFieldName("IdRis")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property IdVoceCosto As New LUNA.LunaFieldName("IdVoceCosto")
		Public Shared ReadOnly Property Nota As New LUNA.LunaFieldName("Nota")
		Public Shared ReadOnly Property Prezzo As New LUNA.LunaFieldName("Prezzo")
		Public Shared ReadOnly Property PrezzoUnit As New LUNA.LunaFieldName("PrezzoUnit")
		Public Shared ReadOnly Property Qta As New LUNA.LunaFieldName("Qta")
		Public Shared ReadOnly Property TipoMov As New LUNA.LunaFieldName("TipoMov")
		Public Shared ReadOnly Property Urgenza As New LUNA.LunaFieldName("Urgenza")
	End Class

End Class