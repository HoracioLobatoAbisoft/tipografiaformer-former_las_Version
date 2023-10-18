#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Richiesteregistrazione
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _RichiestaRegistrazioneW
	Inherits LUNA.LunaBaseClassEntity
	Implements _IRichiestaRegistrazioneW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IRichiestaRegistrazioneW.FillFromDataRecord
		IdRichReg = myRecord("IdRichReg")
		if not myRecord("Cap") is DBNull.Value then Cap = myRecord("Cap")
		if not myRecord("Citta") is DBNull.Value then Citta = myRecord("Citta")
        If Not myRecord("CodFisc") Is DBNull.Value Then CodFisc = myRecord("CodFisc")
        If not myRecord("Cognome") is DBNull.Value then Cognome = myRecord("Cognome")
		if not myRecord("Email") is DBNull.Value then Email = myRecord("Email")
		if not myRecord("IdComune") is DBNull.Value then IdComune = myRecord("IdComune")
		if not myRecord("IdProvincia") is DBNull.Value then IdProvincia = myRecord("IdProvincia")
		if not myRecord("Indirizzo") is DBNull.Value then Indirizzo = myRecord("Indirizzo")
		if not myRecord("Nazione") is DBNull.Value then Nazione = myRecord("Nazione")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("NomeAz") is DBNull.Value then NomeAz = myRecord("NomeAz")
		if not myRecord("Piva") is DBNull.Value then Piva = myRecord("Piva")
		if not myRecord("Sito") is DBNull.Value then Sito = myRecord("Sito")
		Stato = myRecord("Stato")
		if not myRecord("Telefono") is DBNull.Value then Telefono = myRecord("Telefono")
		Tipo = myRecord("Tipo")
		TipoStr = myRecord("TipoStr")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of RichiestaRegistrazioneW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(RichiesteRegistrazioneWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of RichiestaRegistrazioneW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdRichReg As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cap As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Citta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property CodFisc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cognome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Email As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdComune As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProvincia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Indirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeAz As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Piva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Telefono As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoStr As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdRichReg = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cap = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Citta = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.CodFisc = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Cognome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Email = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdComune = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProvincia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Indirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeAz = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Piva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Telefono = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoStr = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdRichReg as integer  = 0 
	Public Overridable Property IdRichReg() as integer  Implements _IRichiestaRegistrazioneW.IdRichReg
		Get
			Return _IdRichReg
		End Get
		Set (byval value as integer)
			If _IdRichReg <> value Then
				IsChanged = True
				WhatIsChanged.IdRichReg = True
				_IdRichReg = value
			End If
		End Set
	End property 

	Protected _Cap as string  = "" 
	Public Overridable Property Cap() as string  Implements _IRichiestaRegistrazioneW.Cap
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

	Protected _Citta as string  = "" 
	Public Overridable Property Citta() as string  Implements _IRichiestaRegistrazioneW.Citta
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
	End Property

    Protected _CodFisc As String = ""
    Public Overridable Property CodFisc() as string  Implements _IRichiestaRegistrazioneW.CodFisc
		Get
			Return _CodFisc
		End Get
		Set (byval value as string)
			If _CodFisc <> value Then
				IsChanged = True
				WhatIsChanged.CodFisc = True
				_CodFisc = value
			End If
		End Set
	End property 

	Protected _Cognome as string  = "" 
	Public Overridable Property Cognome() as string  Implements _IRichiestaRegistrazioneW.Cognome
		Get
			Return _Cognome
		End Get
		Set (byval value as string)
			If _Cognome <> value Then
				IsChanged = True
				WhatIsChanged.Cognome = True
				_Cognome = value
			End If
		End Set
	End property 

	Protected _Email as string  = "" 
	Public Overridable Property Email() as string  Implements _IRichiestaRegistrazioneW.Email
		Get
			Return _Email
		End Get
		Set (byval value as string)
			If _Email <> value Then
				IsChanged = True
				WhatIsChanged.Email = True
				_Email = value
			End If
		End Set
	End property 

	Protected _IdComune as integer  = 0 
	Public Overridable Property IdComune() as integer  Implements _IRichiestaRegistrazioneW.IdComune
		Get
			Return _IdComune
		End Get
		Set (byval value as integer)
			If _IdComune <> value Then
				IsChanged = True
				WhatIsChanged.IdComune = True
				_IdComune = value
			End If
		End Set
	End property 

	Protected _IdProvincia as integer  = 0 
	Public Overridable Property IdProvincia() as integer  Implements _IRichiestaRegistrazioneW.IdProvincia
		Get
			Return _IdProvincia
		End Get
		Set (byval value as integer)
			If _IdProvincia <> value Then
				IsChanged = True
				WhatIsChanged.IdProvincia = True
				_IdProvincia = value
			End If
		End Set
	End property 

	Protected _Indirizzo as string  = "" 
	Public Overridable Property Indirizzo() as string  Implements _IRichiestaRegistrazioneW.Indirizzo
		Get
			Return _Indirizzo
		End Get
		Set (byval value as string)
			If _Indirizzo <> value Then
				IsChanged = True
				WhatIsChanged.Indirizzo = True
				_Indirizzo = value
			End If
		End Set
	End property 

	Protected _Nazione as string  = "" 
	Public Overridable Property Nazione() as string  Implements _IRichiestaRegistrazioneW.Nazione
		Get
			Return _Nazione
		End Get
		Set (byval value as string)
			If _Nazione <> value Then
				IsChanged = True
				WhatIsChanged.Nazione = True
				_Nazione = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IRichiestaRegistrazioneW.Nome
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

	Protected _NomeAz as string  = "" 
	Public Overridable Property NomeAz() as string  Implements _IRichiestaRegistrazioneW.NomeAz
		Get
			Return _NomeAz
		End Get
		Set (byval value as string)
			If _NomeAz <> value Then
				IsChanged = True
				WhatIsChanged.NomeAz = True
				_NomeAz = value
			End If
		End Set
	End property 

	Protected _Piva as string  = "" 
	Public Overridable Property Piva() as string  Implements _IRichiestaRegistrazioneW.Piva
		Get
			Return _Piva
		End Get
		Set (byval value as string)
			If _Piva <> value Then
				IsChanged = True
				WhatIsChanged.Piva = True
				_Piva = value
			End If
		End Set
	End property 

	Protected _Sito as string  = "" 
	Public Overridable Property Sito() as string  Implements _IRichiestaRegistrazioneW.Sito
		Get
			Return _Sito
		End Get
		Set (byval value as string)
			If _Sito <> value Then
				IsChanged = True
				WhatIsChanged.Sito = True
				_Sito = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IRichiestaRegistrazioneW.Stato
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

	Protected _Telefono as string  = "" 
	Public Overridable Property Telefono() as string  Implements _IRichiestaRegistrazioneW.Telefono
		Get
			Return _Telefono
		End Get
		Set (byval value as string)
			If _Telefono <> value Then
				IsChanged = True
				WhatIsChanged.Telefono = True
				_Telefono = value
			End If
		End Set
	End property 

	Protected _Tipo as integer  = 0 
	Public Overridable Property Tipo() as integer  Implements _IRichiestaRegistrazioneW.Tipo
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

	Protected _TipoStr as string  = "" 
	Public Overridable Property TipoStr() as string  Implements _IRichiestaRegistrazioneW.TipoStr
		Get
			Return _TipoStr
		End Get
		Set (byval value as string)
			If _TipoStr <> value Then
				IsChanged = True
				WhatIsChanged.TipoStr = True
				_TipoStr = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an RichiestaRegistrazioneW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As RichiestaRegistrazioneW = Manager.Read(Id)
				_IdRichReg = int.IdRichReg
				_Cap = int.Cap
				_Citta = int.Citta
				_Citta = int.Citta
				_CodFisc = int.CodFisc
				_Cognome = int.Cognome
				_Email = int.Email
				_IdComune = int.IdComune
				_IdProvincia = int.IdProvincia
				_Indirizzo = int.Indirizzo
				_Nazione = int.Nazione
				_Nome = int.Nome
				_NomeAz = int.NomeAz
				_Piva = int.Piva
				_Sito = int.Sito
				_Stato = int.Stato
				_Telefono = int.Telefono
				_Tipo = int.Tipo
				_TipoStr = int.TipoStr
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an RichiestaRegistrazioneW on DB.
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
		if _Cap.Length > 5 then Ris = False
		if _Citta.Length > 100 then Ris = False
		if _Citta.Length > 100 then Ris = False
		if _CodFisc.Length > 50 then Ris = False
		if _Cognome.Length > 50 then Ris = False
		if _Email.Length > 50 then Ris = False
		if _Indirizzo.Length > 100 then Ris = False
		if _Nazione.Length > 50 then Ris = False
		if _Nome.Length > 50 then Ris = False
		if _NomeAz.Length > 100 then Ris = False
		if _Piva.Length > 50 then Ris = False
		if _Sito.Length > 250 then Ris = False
		if _Telefono.Length > 30 then Ris = False
  
		if _TipoStr.Length = 0 then Ris = False
		if _TipoStr.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Richiesteregistrazione
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IRichiestaRegistrazioneW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdRichReg() as integer
	Property Cap() as String
    Property Citta() As String
    Property CodFisc() as string
	Property Cognome() as string
	Property Email() as string
	Property IdComune() as integer
	Property IdProvincia() as integer
	Property Indirizzo() as string
	Property Nazione() as string
	Property Nome() as string
	Property NomeAz() as string
	Property Piva() as string
	Property Sito() as string
	Property Stato() as integer
	Property Telefono() as string
	Property Tipo() as integer
	Property TipoStr() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class RichiestaRegistrazioneW
		Public Shared ReadOnly Property IdRichReg As New LUNA.LunaFieldName("IdRichReg")
		Public Shared ReadOnly Property Cap As New LUNA.LunaFieldName("Cap")
        Public Shared ReadOnly Property Citta As New LUNA.LunaFieldName("Citta")
        Public Shared ReadOnly Property CodFisc As New LUNA.LunaFieldName("CodFisc")
		Public Shared ReadOnly Property Cognome As New LUNA.LunaFieldName("Cognome")
		Public Shared ReadOnly Property Email As New LUNA.LunaFieldName("Email")
		Public Shared ReadOnly Property IdComune As New LUNA.LunaFieldName("IdComune")
		Public Shared ReadOnly Property IdProvincia As New LUNA.LunaFieldName("IdProvincia")
		Public Shared ReadOnly Property Indirizzo As New LUNA.LunaFieldName("Indirizzo")
		Public Shared ReadOnly Property Nazione As New LUNA.LunaFieldName("Nazione")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property NomeAz As New LUNA.LunaFieldName("NomeAz")
		Public Shared ReadOnly Property Piva As New LUNA.LunaFieldName("Piva")
		Public Shared ReadOnly Property Sito As New LUNA.LunaFieldName("Sito")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property Telefono As New LUNA.LunaFieldName("Telefono")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
		Public Shared ReadOnly Property TipoStr As New LUNA.LunaFieldName("TipoStr")
	End Class

End Class