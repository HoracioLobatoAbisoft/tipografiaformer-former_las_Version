#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/11/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_lavlog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _LavLog
	Inherits LUNA.LunaBaseClassEntity
	Implements _ILavLog
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ILavLog.FillFromDataRecord
		IdLavLog = myRecord("IdLavLog")
		if not myRecord("Custom") is DBNull.Value then Custom = myRecord("Custom")
		if not myRecord("DataOraFine") is DBNull.Value then DataOraFine = myRecord("DataOraFine")
		if not myRecord("DataOraInizio") is DBNull.Value then DataOraInizio = myRecord("DataOraInizio")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("ExtraData") is DBNull.Value then ExtraData = myRecord("ExtraData")
		if not myRecord("IdCom") is DBNull.Value then IdCom = myRecord("IdCom")
		if not myRecord("Idlav") is DBNull.Value then Idlav = myRecord("Idlav")
		if not myRecord("IdMacchinario") is DBNull.Value then IdMacchinario = myRecord("IdMacchinario")
		if not myRecord("IdOrd") is DBNull.Value then IdOrd = myRecord("IdOrd")
		if not myRecord("IdUt") is DBNull.Value then IdUt = myRecord("IdUt")
		if not myRecord("IdUtenteForzato") is DBNull.Value then IdUtenteForzato = myRecord("IdUtenteForzato")
		if not myRecord("Macchinario") is DBNull.Value then Macchinario = myRecord("Macchinario")
		if not myRecord("Opz") is DBNull.Value then Opz = myRecord("Opz")
		if not myRecord("Ordine") is DBNull.Value then Ordine = myRecord("Ordine")
		if not myRecord("Premio") is DBNull.Value then Premio = myRecord("Premio")
		if not myRecord("Tempo") is DBNull.Value then Tempo = myRecord("Tempo")
		if not myRecord("TempoStimatoOperatore") is DBNull.Value then TempoStimatoOperatore = myRecord("TempoStimatoOperatore")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of LavLog)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(LavLogDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of LavLog))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLavLog As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Custom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataOraFine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataOraInizio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ExtraData As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Idlav As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUtenteForzato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Macchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Opz As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Premio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tempo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TempoStimatoOperatore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLavLog = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Custom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataOraFine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataOraInizio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ExtraData = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Idlav = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUtenteForzato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Macchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Opz = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ordine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Premio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tempo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TempoStimatoOperatore = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLavLog as integer  = 0 
	Public Overridable Property IdLavLog() as integer  Implements _ILavLog.IdLavLog
		Get
			Return _IdLavLog
		End Get
		Set (byval value as integer)
			If _IdLavLog <> value Then
				IsChanged = True
				WhatIsChanged.IdLavLog = True
				_IdLavLog = value
			End If
		End Set
	End property 

	Protected _Custom as Boolean  = False 
	Public Overridable Property Custom() as Boolean  Implements _ILavLog.Custom
		Get
			Return _Custom
		End Get
		Set (byval value as Boolean)
			If _Custom <> value Then
				IsChanged = True
				WhatIsChanged.Custom = True
				_Custom = value
			End If
		End Set
	End property 

	Protected _DataOraFine as DateTime  = Nothing 
	Public Overridable Property DataOraFine() as DateTime  Implements _ILavLog.DataOraFine
		Get
			Return _DataOraFine
		End Get
		Set (byval value as DateTime)
			If _DataOraFine <> value Then
				IsChanged = True
				WhatIsChanged.DataOraFine = True
				_DataOraFine = value
			End If
		End Set
	End property 

	Protected _DataOraInizio as DateTime  = Nothing 
	Public Overridable Property DataOraInizio() as DateTime  Implements _ILavLog.DataOraInizio
		Get
			Return _DataOraInizio
		End Get
		Set (byval value as DateTime)
			If _DataOraInizio <> value Then
				IsChanged = True
				WhatIsChanged.DataOraInizio = True
				_DataOraInizio = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _ILavLog.Descrizione
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

	Protected _ExtraData as string  = "" 
	Public Overridable Property ExtraData() as string  Implements _ILavLog.ExtraData
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

	Protected _IdCom as integer  = 0 
	Public Overridable Property IdCom() as integer  Implements _ILavLog.IdCom
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

	Protected _Idlav as integer  = 0 
	Public Overridable Property Idlav() as integer  Implements _ILavLog.Idlav
		Get
			Return _Idlav
		End Get
		Set (byval value as integer)
			If _Idlav <> value Then
				IsChanged = True
				WhatIsChanged.Idlav = True
				_Idlav = value
			End If
		End Set
	End property 

	Protected _IdMacchinario as integer  = 0 
	Public Overridable Property IdMacchinario() as integer  Implements _ILavLog.IdMacchinario
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

	Protected _IdOrd as integer  = 0 
	Public Overridable Property IdOrd() as integer  Implements _ILavLog.IdOrd
		Get
			Return _IdOrd
		End Get
		Set (byval value as integer)
			If _IdOrd <> value Then
				IsChanged = True
				WhatIsChanged.IdOrd = True
				_IdOrd = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _ILavLog.IdUt
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

	Protected _IdUtenteForzato as integer  = 0 
	Public Overridable Property IdUtenteForzato() as integer  Implements _ILavLog.IdUtenteForzato
		Get
			Return _IdUtenteForzato
		End Get
		Set (byval value as integer)
			If _IdUtenteForzato <> value Then
				IsChanged = True
				WhatIsChanged.IdUtenteForzato = True
				_IdUtenteForzato = value
			End If
		End Set
	End property 

	Protected _Macchinario as string  = "" 
	Public Overridable Property Macchinario() as string  Implements _ILavLog.Macchinario
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

	Protected _Opz as Boolean  = False 
	Public Overridable Property Opz() as Boolean  Implements _ILavLog.Opz
		Get
			Return _Opz
		End Get
		Set (byval value as Boolean)
			If _Opz <> value Then
				IsChanged = True
				WhatIsChanged.Opz = True
				_Opz = value
			End If
		End Set
	End property 

	Protected _Ordine as integer  = 0 
	Public Overridable Property Ordine() as integer  Implements _ILavLog.Ordine
		Get
			Return _Ordine
		End Get
		Set (byval value as integer)
			If _Ordine <> value Then
				IsChanged = True
				WhatIsChanged.Ordine = True
				_Ordine = value
			End If
		End Set
	End property 

	Protected _Premio as decimal  = 0 
	Public Overridable Property Premio() as decimal  Implements _ILavLog.Premio
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

	Protected _Tempo as integer  = 0 
	Public Overridable Property Tempo() as integer  Implements _ILavLog.Tempo
		Get
			Return _Tempo
		End Get
		Set (byval value as integer)
			If _Tempo <> value Then
				IsChanged = True
				WhatIsChanged.Tempo = True
				_Tempo = value
			End If
		End Set
	End property 

	Protected _TempoStimatoOperatore as integer  = 0 
	Public Overridable Property TempoStimatoOperatore() as integer  Implements _ILavLog.TempoStimatoOperatore
		Get
			Return _TempoStimatoOperatore
		End Get
		Set (byval value as integer)
			If _TempoStimatoOperatore <> value Then
				IsChanged = True
				WhatIsChanged.TempoStimatoOperatore = True
				_TempoStimatoOperatore = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an LavLog from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As LavLog = Manager.Read(Id)
				_IdLavLog = int.IdLavLog
				_Custom = int.Custom
				_DataOraFine = int.DataOraFine
				_DataOraInizio = int.DataOraInizio
				_Descrizione = int.Descrizione
				_ExtraData = int.ExtraData
				_IdCom = int.IdCom
				_Idlav = int.Idlav
				_IdMacchinario = int.IdMacchinario
				_IdOrd = int.IdOrd
				_IdUt = int.IdUt
				_IdUtenteForzato = int.IdUtenteForzato
				_Macchinario = int.Macchinario
				_Opz = int.Opz
				_Ordine = int.Ordine
				_Premio = int.Premio
				_Tempo = int.Tempo
				_TempoStimatoOperatore = int.TempoStimatoOperatore
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an LavLog on DB.
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
		if _ExtraData.Length > 255 then Ris = False
		if _Macchinario.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"

	
	<XmlElementAttribute("Utente")> _
	Protected _Utente As Utente
	Public property Utente() As  Utente
		Get
			If _Utente Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
				Using Mgr As New UtentiDAO
					_Utente = Mgr.Read(_IdUt)
				End Using 
			End If
			Return _Utente
		End Get
		Set(ByVal value As Utente)
			_Utente = value
			_IdUt = _Utente.IdUt
		End Set
	End Property

    <XmlElementAttribute("Ordine")>
    Protected _OrdineRif As Ordine
    Public Property OrdineRif() As Ordine
        Get
            If _OrdineRif Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
                Using Mgr As New OrdiniDAO
                    _OrdineRif = Mgr.Read(_IdOrd)
                End Using
            End If
            Return _OrdineRif
        End Get
        Set(ByVal value As Ordine)
            _OrdineRif = value
            _IdOrd = _OrdineRif.IdOrd
        End Set
    End Property

#End Region

End Class 

''' <summary>
'''Interface for table T_lavlog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ILavLog

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLavLog() as integer
	Property Custom() as Boolean
	Property DataOraFine() as DateTime
	Property DataOraInizio() as DateTime
	Property Descrizione() as string
	Property ExtraData() as string
	Property IdCom() as integer
	Property Idlav() as integer
	Property IdMacchinario() as integer
	Property IdOrd() as integer
	Property IdUt() as integer
	Property IdUtenteForzato() as integer
	Property Macchinario() as string
	Property Opz() as Boolean
	Property Ordine() as integer
	Property Premio() as decimal
	Property Tempo() as integer
	Property TempoStimatoOperatore() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class LavLog
		Public Shared ReadOnly Property IdLavLog As New LUNA.LunaFieldName("IdLavLog")
		Public Shared ReadOnly Property Custom As New LUNA.LunaFieldName("Custom")
		Public Shared ReadOnly Property DataOraFine As New LUNA.LunaFieldName("DataOraFine")
		Public Shared ReadOnly Property DataOraInizio As New LUNA.LunaFieldName("DataOraInizio")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property ExtraData As New LUNA.LunaFieldName("ExtraData")
		Public Shared ReadOnly Property IdCom As New LUNA.LunaFieldName("IdCom")
		Public Shared ReadOnly Property Idlav As New LUNA.LunaFieldName("Idlav")
		Public Shared ReadOnly Property IdMacchinario As New LUNA.LunaFieldName("IdMacchinario")
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property IdUtenteForzato As New LUNA.LunaFieldName("IdUtenteForzato")
		Public Shared ReadOnly Property Macchinario As New LUNA.LunaFieldName("Macchinario")
		Public Shared ReadOnly Property Opz As New LUNA.LunaFieldName("Opz")
		Public Shared ReadOnly Property Ordine As New LUNA.LunaFieldName("Ordine")
		Public Shared ReadOnly Property Premio As New LUNA.LunaFieldName("Premio")
		Public Shared ReadOnly Property Tempo As New LUNA.LunaFieldName("Tempo")
		Public Shared ReadOnly Property TempoStimatoOperatore As New LUNA.LunaFieldName("TempoStimatoOperatore")
	End Class

End Class