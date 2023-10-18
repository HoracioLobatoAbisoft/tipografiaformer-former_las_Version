#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 22/02/2021 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table F24dettaglio
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _F24Dettaglio
	Inherits LUNA.LunaBaseClassEntity
	Implements _IF24Dettaglio
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IF24Dettaglio.FillFromDataRecord
		IdF24Dett = myRecord("IdF24Dett")
		if not myRecord("Anno") is DBNull.Value then Anno = myRecord("Anno")
		if not myRecord("Causale") is DBNull.Value then Causale = myRecord("Causale")
		if not myRecord("CausaleContributo") is DBNull.Value then CausaleContributo = myRecord("CausaleContributo")
		if not myRecord("cc") is DBNull.Value then cc = myRecord("cc")
		if not myRecord("CodiceDitta") is DBNull.Value then CodiceDitta = myRecord("CodiceDitta")
		if not myRecord("CodiceRegione") is DBNull.Value then CodiceRegione = myRecord("CodiceRegione")
		if not myRecord("CodiceSede") is DBNull.Value then CodiceSede = myRecord("CodiceSede")
		if not myRecord("CodiceTributo") is DBNull.Value then CodiceTributo = myRecord("CodiceTributo")
		IdF24 = myRecord("IdF24")
		IdSezione = myRecord("IdSezione")
		if not myRecord("ImportiCredito") is DBNull.Value then ImportiCredito = myRecord("ImportiCredito")
		if not myRecord("ImportiDebito") is DBNull.Value then ImportiDebito = myRecord("ImportiDebito")
		if not myRecord("MatricolaInps") is DBNull.Value then MatricolaInps = myRecord("MatricolaInps")
		if not myRecord("Mese") is DBNull.Value then Mese = myRecord("Mese")
		if not myRecord("NumeroRiferimento") is DBNull.Value then NumeroRiferimento = myRecord("NumeroRiferimento")
		if not myRecord("PeriodoA") is DBNull.Value then PeriodoA = myRecord("PeriodoA")
		if not myRecord("PeriodoDa") is DBNull.Value then PeriodoDa = myRecord("PeriodoDa")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of F24Dettaglio)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(F24DettaglioDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of F24Dettaglio))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdF24Dett As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Anno As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Causale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CausaleContributo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property cc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodiceDitta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodiceRegione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodiceSede As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodiceTributo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdF24 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdSezione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportiCredito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportiDebito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MatricolaInps As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Mese As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumeroRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PeriodoA As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PeriodoDa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdF24Dett = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Anno = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Causale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CausaleContributo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.cc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodiceDitta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodiceRegione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodiceSede = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodiceTributo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdF24 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdSezione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportiCredito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportiDebito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MatricolaInps = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Mese = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumeroRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PeriodoA = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PeriodoDa = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdF24Dett as integer  = 0 
	Public Overridable Property IdF24Dett() as integer  Implements _IF24Dettaglio.IdF24Dett
		Get
			Return _IdF24Dett
		End Get
		Set (byval value as integer)
			If _IdF24Dett <> value Then
				IsChanged = True
				WhatIsChanged.IdF24Dett = True
				_IdF24Dett = value
			End If
		End Set
	End property 

	Protected _Anno as string  = "" 
	Public Overridable Property Anno() as string  Implements _IF24Dettaglio.Anno
		Get
			Return _Anno
		End Get
		Set (byval value as string)
			If _Anno <> value Then
				IsChanged = True
				WhatIsChanged.Anno = True
				_Anno = value
			End If
		End Set
	End property 

	Protected _Causale as string  = "" 
	Public Overridable Property Causale() as string  Implements _IF24Dettaglio.Causale
		Get
			Return _Causale
		End Get
		Set (byval value as string)
			If _Causale <> value Then
				IsChanged = True
				WhatIsChanged.Causale = True
				_Causale = value
			End If
		End Set
	End property 

	Protected _CausaleContributo as string  = "" 
	Public Overridable Property CausaleContributo() as string  Implements _IF24Dettaglio.CausaleContributo
		Get
			Return _CausaleContributo
		End Get
		Set (byval value as string)
			If _CausaleContributo <> value Then
				IsChanged = True
				WhatIsChanged.CausaleContributo = True
				_CausaleContributo = value
			End If
		End Set
	End property 

	Protected _cc as string  = "" 
	Public Overridable Property cc() as string  Implements _IF24Dettaglio.cc
		Get
			Return _cc
		End Get
		Set (byval value as string)
			If _cc <> value Then
				IsChanged = True
				WhatIsChanged.cc = True
				_cc = value
			End If
		End Set
	End property 

	Protected _CodiceDitta as string  = "" 
	Public Overridable Property CodiceDitta() as string  Implements _IF24Dettaglio.CodiceDitta
		Get
			Return _CodiceDitta
		End Get
		Set (byval value as string)
			If _CodiceDitta <> value Then
				IsChanged = True
				WhatIsChanged.CodiceDitta = True
				_CodiceDitta = value
			End If
		End Set
	End property 

	Protected _CodiceRegione as string  = "" 
	Public Overridable Property CodiceRegione() as string  Implements _IF24Dettaglio.CodiceRegione
		Get
			Return _CodiceRegione
		End Get
		Set (byval value as string)
			If _CodiceRegione <> value Then
				IsChanged = True
				WhatIsChanged.CodiceRegione = True
				_CodiceRegione = value
			End If
		End Set
	End property 

	Protected _CodiceSede as string  = "" 
	Public Overridable Property CodiceSede() as string  Implements _IF24Dettaglio.CodiceSede
		Get
			Return _CodiceSede
		End Get
		Set (byval value as string)
			If _CodiceSede <> value Then
				IsChanged = True
				WhatIsChanged.CodiceSede = True
				_CodiceSede = value
			End If
		End Set
	End property 

	Protected _CodiceTributo as string  = "" 
	Public Overridable Property CodiceTributo() as string  Implements _IF24Dettaglio.CodiceTributo
		Get
			Return _CodiceTributo
		End Get
		Set (byval value as string)
			If _CodiceTributo <> value Then
				IsChanged = True
				WhatIsChanged.CodiceTributo = True
				_CodiceTributo = value
			End If
		End Set
	End property 

	Protected _IdF24 as integer  = 0 
	Public Overridable Property IdF24() as integer  Implements _IF24Dettaglio.IdF24
		Get
			Return _IdF24
		End Get
		Set (byval value as integer)
			If _IdF24 <> value Then
				IsChanged = True
				WhatIsChanged.IdF24 = True
				_IdF24 = value
			End If
		End Set
	End property 

	Protected _IdSezione as integer  = 0 
	Public Overridable Property IdSezione() as integer  Implements _IF24Dettaglio.IdSezione
		Get
			Return _IdSezione
		End Get
		Set (byval value as integer)
			If _IdSezione <> value Then
				IsChanged = True
				WhatIsChanged.IdSezione = True
				_IdSezione = value
			End If
		End Set
	End property 

	Protected _ImportiCredito as string  = "" 
	Public Overridable Property ImportiCredito() as string  Implements _IF24Dettaglio.ImportiCredito
		Get
			Return _ImportiCredito
		End Get
		Set (byval value as string)
			If _ImportiCredito <> value Then
				IsChanged = True
				WhatIsChanged.ImportiCredito = True
				_ImportiCredito = value
			End If
		End Set
	End property 

	Protected _ImportiDebito as string  = "" 
	Public Overridable Property ImportiDebito() as string  Implements _IF24Dettaglio.ImportiDebito
		Get
			Return _ImportiDebito
		End Get
		Set (byval value as string)
			If _ImportiDebito <> value Then
				IsChanged = True
				WhatIsChanged.ImportiDebito = True
				_ImportiDebito = value
			End If
		End Set
	End property 

	Protected _MatricolaInps as string  = "" 
	Public Overridable Property MatricolaInps() as string  Implements _IF24Dettaglio.MatricolaInps
		Get
			Return _MatricolaInps
		End Get
		Set (byval value as string)
			If _MatricolaInps <> value Then
				IsChanged = True
				WhatIsChanged.MatricolaInps = True
				_MatricolaInps = value
			End If
		End Set
	End property 

	Protected _Mese as string  = "" 
	Public Overridable Property Mese() as string  Implements _IF24Dettaglio.Mese
		Get
			Return _Mese
		End Get
		Set (byval value as string)
			If _Mese <> value Then
				IsChanged = True
				WhatIsChanged.Mese = True
				_Mese = value
			End If
		End Set
	End property 

	Protected _NumeroRiferimento as string  = "" 
	Public Overridable Property NumeroRiferimento() as string  Implements _IF24Dettaglio.NumeroRiferimento
		Get
			Return _NumeroRiferimento
		End Get
		Set (byval value as string)
			If _NumeroRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.NumeroRiferimento = True
				_NumeroRiferimento = value
			End If
		End Set
	End property 

	Protected _PeriodoA as string  = "" 
	Public Overridable Property PeriodoA() as string  Implements _IF24Dettaglio.PeriodoA
		Get
			Return _PeriodoA
		End Get
		Set (byval value as string)
			If _PeriodoA <> value Then
				IsChanged = True
				WhatIsChanged.PeriodoA = True
				_PeriodoA = value
			End If
		End Set
	End property 

	Protected _PeriodoDa as string  = "" 
	Public Overridable Property PeriodoDa() as string  Implements _IF24Dettaglio.PeriodoDa
		Get
			Return _PeriodoDa
		End Get
		Set (byval value as string)
			If _PeriodoDa <> value Then
				IsChanged = True
				WhatIsChanged.PeriodoDa = True
				_PeriodoDa = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an F24Dettaglio from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As F24Dettaglio = Manager.Read(Id)
				_IdF24Dett = int.IdF24Dett
				_Anno = int.Anno
				_Causale = int.Causale
				_CausaleContributo = int.CausaleContributo
				_cc = int.cc
				_CodiceDitta = int.CodiceDitta
				_CodiceRegione = int.CodiceRegione
				_CodiceSede = int.CodiceSede
				_CodiceTributo = int.CodiceTributo
				_IdF24 = int.IdF24
				_IdSezione = int.IdSezione
				_ImportiCredito = int.ImportiCredito
				_ImportiDebito = int.ImportiDebito
				_MatricolaInps = int.MatricolaInps
				_Mese = int.Mese
				_NumeroRiferimento = int.NumeroRiferimento
				_PeriodoA = int.PeriodoA
				_PeriodoDa = int.PeriodoDa
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
    Public Overridable Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdF24Dett Then
            ris = Read(IdF24Dett)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an F24Dettaglio on DB.
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
		if _Anno.Length > 50 then Ris = False
		if _Causale.Length > 2 then Ris = False
		if _CausaleContributo.Length > 50 then Ris = False
		if _cc.Length > 2 then Ris = False
		if _CodiceDitta.Length > 8 then Ris = False
		if _CodiceRegione.Length > 50 then Ris = False
		if _CodiceSede.Length > 50 then Ris = False
		if _CodiceTributo.Length > 50 then Ris = False
		if _ImportiCredito.Length > 50 then Ris = False
		if _ImportiDebito.Length > 50 then Ris = False
		if _MatricolaInps.Length > 50 then Ris = False
		if _Mese.Length > 50 then Ris = False
		if _NumeroRiferimento.Length > 6 then Ris = False
		if _PeriodoA.Length > 50 then Ris = False
		if _PeriodoDa.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table F24dettaglio
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IF24Dettaglio

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdF24Dett() as integer
	Property Anno() as string
	Property Causale() as string
	Property CausaleContributo() as string
	Property cc() as string
	Property CodiceDitta() as string
	Property CodiceRegione() as string
	Property CodiceSede() as string
	Property CodiceTributo() as string
	Property IdF24() as integer
	Property IdSezione() as integer
	Property ImportiCredito() as string
	Property ImportiDebito() as string
	Property MatricolaInps() as string
	Property Mese() as string
	Property NumeroRiferimento() as string
	Property PeriodoA() as string
	Property PeriodoDa() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class F24Dettaglio
		Public Shared ReadOnly Property IdF24Dett As New LUNA.LunaFieldName("IdF24Dett")
		Public Shared ReadOnly Property Anno As New LUNA.LunaFieldName("Anno")
		Public Shared ReadOnly Property Causale As New LUNA.LunaFieldName("Causale")
		Public Shared ReadOnly Property CausaleContributo As New LUNA.LunaFieldName("CausaleContributo")
		Public Shared ReadOnly Property cc As New LUNA.LunaFieldName("cc")
		Public Shared ReadOnly Property CodiceDitta As New LUNA.LunaFieldName("CodiceDitta")
		Public Shared ReadOnly Property CodiceRegione As New LUNA.LunaFieldName("CodiceRegione")
		Public Shared ReadOnly Property CodiceSede As New LUNA.LunaFieldName("CodiceSede")
		Public Shared ReadOnly Property CodiceTributo As New LUNA.LunaFieldName("CodiceTributo")
		Public Shared ReadOnly Property IdF24 As New LUNA.LunaFieldName("IdF24")
		Public Shared ReadOnly Property IdSezione As New LUNA.LunaFieldName("IdSezione")
		Public Shared ReadOnly Property ImportiCredito As New LUNA.LunaFieldName("ImportiCredito")
		Public Shared ReadOnly Property ImportiDebito As New LUNA.LunaFieldName("ImportiDebito")
		Public Shared ReadOnly Property MatricolaInps As New LUNA.LunaFieldName("MatricolaInps")
		Public Shared ReadOnly Property Mese As New LUNA.LunaFieldName("Mese")
		Public Shared ReadOnly Property NumeroRiferimento As New LUNA.LunaFieldName("NumeroRiferimento")
		Public Shared ReadOnly Property PeriodoA As New LUNA.LunaFieldName("PeriodoA")
		Public Shared ReadOnly Property PeriodoDa As New LUNA.LunaFieldName("PeriodoDa")
	End Class

End Class