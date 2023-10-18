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
'''DAO Class for table T_rubricamarketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _VoceRubricaMarketing
	Inherits LUNA.LunaBaseClassEntity
	Implements _IVoceRubricaMarketing
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IVoceRubricaMarketing.FillFromDataRecord
		IDRubMarketing = myRecord("IDRubMarketing")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("Cap") is DBNull.Value then Cap = myRecord("Cap")
		if not myRecord("Citta") is DBNull.Value then Citta = myRecord("Citta")
		if not myRecord("DataAcquisizione") is DBNull.Value then DataAcquisizione = myRecord("DataAcquisizione")
		if not myRecord("Disattivo") is DBNull.Value then Disattivo = myRecord("Disattivo")
		if not myRecord("Email") is DBNull.Value then Email = myRecord("Email")
		if not myRecord("Fax") is DBNull.Value then Fax = myRecord("Fax")
		if not myRecord("IdCategoria") is DBNull.Value then IdCategoria = myRecord("IdCategoria")
		if not myRecord("IdCategoria2") is DBNull.Value then IdCategoria2 = myRecord("IdCategoria2")
		if not myRecord("IdUtente") is DBNull.Value then IdUtente = myRecord("IdUtente")
		if not myRecord("Indirizzo") is DBNull.Value then Indirizzo = myRecord("Indirizzo")
		if not myRecord("Lavorato") is DBNull.Value then Lavorato = myRecord("Lavorato")
		if not myRecord("NoEmail") is DBNull.Value then NoEmail = myRecord("NoEmail")
		if not myRecord("NomeAzienda") is DBNull.Value then NomeAzienda = myRecord("NomeAzienda")
		if not myRecord("Sito") is DBNull.Value then Sito = myRecord("Sito")
		if not myRecord("Tag") is DBNull.Value then Tag = myRecord("Tag")
		if not myRecord("Telefono") is DBNull.Value then Telefono = myRecord("Telefono")
		if not myRecord("Tipo") is DBNull.Value then Tipo = myRecord("Tipo")
		if not myRecord("UrlProvenienza") is DBNull.Value then UrlProvenienza = myRecord("UrlProvenienza")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of VoceRubricaMarketing)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(VoceRubricaMarketingDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of VoceRubricaMarketing))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDRubMarketing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cap As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Citta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataAcquisizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Disattivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Email As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Fax As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCategoria As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCategoria2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUtente As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Indirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Lavorato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NoEmail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeAzienda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tag As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Telefono As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property UrlProvenienza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDRubMarketing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cap = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Citta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataAcquisizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Disattivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Email = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Fax = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCategoria = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCategoria2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUtente = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Indirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Lavorato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NoEmail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeAzienda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tag = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Telefono = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.UrlProvenienza = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDRubMarketing as integer  = 0 
	Public Overridable Property IDRubMarketing() as integer  Implements _IVoceRubricaMarketing.IDRubMarketing
		Get
			Return _IDRubMarketing
		End Get
		Set (byval value as integer)
			If _IDRubMarketing <> value Then
				IsChanged = True
				WhatIsChanged.IDRubMarketing = True
				_IDRubMarketing = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _IVoceRubricaMarketing.Annotazioni
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

	Protected _Cap as string  = "" 
	Public Overridable Property Cap() as string  Implements _IVoceRubricaMarketing.Cap
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
	Public Overridable Property Citta() as string  Implements _IVoceRubricaMarketing.Citta
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

	Protected _DataAcquisizione as DateTime  = Nothing 
	Public Overridable Property DataAcquisizione() as DateTime  Implements _IVoceRubricaMarketing.DataAcquisizione
		Get
			Return _DataAcquisizione
		End Get
		Set (byval value as DateTime)
			If _DataAcquisizione <> value Then
				IsChanged = True
				WhatIsChanged.DataAcquisizione = True
				_DataAcquisizione = value
			End If
		End Set
	End property 

	Protected _Disattivo as integer  = 0 
	Public Overridable Property Disattivo() as integer  Implements _IVoceRubricaMarketing.Disattivo
		Get
			Return _Disattivo
		End Get
		Set (byval value as integer)
			If _Disattivo <> value Then
				IsChanged = True
				WhatIsChanged.Disattivo = True
				_Disattivo = value
			End If
		End Set
	End property 

	Protected _Email as string  = "" 
	Public Overridable Property Email() as string  Implements _IVoceRubricaMarketing.Email
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

	Protected _Fax as string  = "" 
	Public Overridable Property Fax() as string  Implements _IVoceRubricaMarketing.Fax
		Get
			Return _Fax
		End Get
		Set (byval value as string)
			If _Fax <> value Then
				IsChanged = True
				WhatIsChanged.Fax = True
				_Fax = value
			End If
		End Set
	End property 

	Protected _IdCategoria as integer  = 0 
	Public Overridable Property IdCategoria() as integer  Implements _IVoceRubricaMarketing.IdCategoria
		Get
			Return _IdCategoria
		End Get
		Set (byval value as integer)
			If _IdCategoria <> value Then
				IsChanged = True
				WhatIsChanged.IdCategoria = True
				_IdCategoria = value
			End If
		End Set
	End property 

	Protected _IdCategoria2 as integer  = 0 
	Public Overridable Property IdCategoria2() as integer  Implements _IVoceRubricaMarketing.IdCategoria2
		Get
			Return _IdCategoria2
		End Get
		Set (byval value as integer)
			If _IdCategoria2 <> value Then
				IsChanged = True
				WhatIsChanged.IdCategoria2 = True
				_IdCategoria2 = value
			End If
		End Set
	End property 

	Protected _IdUtente as integer  = 0 
	Public Overridable Property IdUtente() as integer  Implements _IVoceRubricaMarketing.IdUtente
		Get
			Return _IdUtente
		End Get
		Set (byval value as integer)
			If _IdUtente <> value Then
				IsChanged = True
				WhatIsChanged.IdUtente = True
				_IdUtente = value
			End If
		End Set
	End property 

	Protected _Indirizzo as string  = "" 
	Public Overridable Property Indirizzo() as string  Implements _IVoceRubricaMarketing.Indirizzo
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

	Protected _Lavorato as Boolean  = False 
	Public Overridable Property Lavorato() as Boolean  Implements _IVoceRubricaMarketing.Lavorato
		Get
			Return _Lavorato
		End Get
		Set (byval value as Boolean)
			If _Lavorato <> value Then
				IsChanged = True
				WhatIsChanged.Lavorato = True
				_Lavorato = value
			End If
		End Set
	End property 

	Protected _NoEmail as integer  = 0 
	Public Overridable Property NoEmail() as integer  Implements _IVoceRubricaMarketing.NoEmail
		Get
			Return _NoEmail
		End Get
		Set (byval value as integer)
			If _NoEmail <> value Then
				IsChanged = True
				WhatIsChanged.NoEmail = True
				_NoEmail = value
			End If
		End Set
	End property 

	Protected _NomeAzienda as string  = "" 
	Public Overridable Property NomeAzienda() as string  Implements _IVoceRubricaMarketing.NomeAzienda
		Get
			Return _NomeAzienda
		End Get
		Set (byval value as string)
			If _NomeAzienda <> value Then
				IsChanged = True
				WhatIsChanged.NomeAzienda = True
				_NomeAzienda = value
			End If
		End Set
	End property 

	Protected _Sito as string  = "" 
	Public Overridable Property Sito() as string  Implements _IVoceRubricaMarketing.Sito
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

	Protected _Tag as string  = "" 
	Public Overridable Property Tag() as string  Implements _IVoceRubricaMarketing.Tag
		Get
			Return _Tag
		End Get
		Set (byval value as string)
			If _Tag <> value Then
				IsChanged = True
				WhatIsChanged.Tag = True
				_Tag = value
			End If
		End Set
	End property 

	Protected _Telefono as string  = "" 
	Public Overridable Property Telefono() as string  Implements _IVoceRubricaMarketing.Telefono
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
	Public Overridable Property Tipo() as integer  Implements _IVoceRubricaMarketing.Tipo
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

	Protected _UrlProvenienza as string  = "" 
	Public Overridable Property UrlProvenienza() as string  Implements _IVoceRubricaMarketing.UrlProvenienza
		Get
			Return _UrlProvenienza
		End Get
		Set (byval value as string)
			If _UrlProvenienza <> value Then
				IsChanged = True
				WhatIsChanged.UrlProvenienza = True
				_UrlProvenienza = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an VoceRubricaMarketing from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As VoceRubricaMarketing = Manager.Read(Id)
				_IDRubMarketing = int.IDRubMarketing
				_Annotazioni = int.Annotazioni
				_Cap = int.Cap
				_Citta = int.Citta
				_DataAcquisizione = int.DataAcquisizione
				_Disattivo = int.Disattivo
				_Email = int.Email
				_Fax = int.Fax
				_IdCategoria = int.IdCategoria
				_IdCategoria2 = int.IdCategoria2
				_IdUtente = int.IdUtente
				_Indirizzo = int.Indirizzo
				_Lavorato = int.Lavorato
				_NoEmail = int.NoEmail
				_NomeAzienda = int.NomeAzienda
				_Sito = int.Sito
				_Tag = int.Tag
				_Telefono = int.Telefono
				_Tipo = int.Tipo
				_UrlProvenienza = int.UrlProvenienza
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an VoceRubricaMarketing on DB.
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
		if _Annotazioni.Length > 1073741823 then Ris = False
		if _Cap.Length > 255 then Ris = False
		if _Citta.Length > 255 then Ris = False
		if _Email.Length > 255 then Ris = False
		if _Fax.Length > 255 then Ris = False
		if _Indirizzo.Length > 255 then Ris = False
		if _NomeAzienda.Length > 255 then Ris = False
		if _Sito.Length > 255 then Ris = False
		if _Tag.Length > 255 then Ris = False
		if _Telefono.Length > 255 then Ris = False
		if _UrlProvenienza.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_rubricamarketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IVoceRubricaMarketing

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDRubMarketing() as integer
	Property Annotazioni() as string
	Property Cap() as string
	Property Citta() as string
	Property DataAcquisizione() as DateTime
	Property Disattivo() as integer
	Property Email() as string
	Property Fax() as string
	Property IdCategoria() as integer
	Property IdCategoria2() as integer
	Property IdUtente() as integer
	Property Indirizzo() as string
	Property Lavorato() as Boolean
	Property NoEmail() as integer
	Property NomeAzienda() as string
	Property Sito() as string
	Property Tag() as string
	Property Telefono() as string
	Property Tipo() as integer
	Property UrlProvenienza() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class VoceRubricaMarketing
		Public Shared ReadOnly Property IDRubMarketing As New LUNA.LunaFieldName("IDRubMarketing")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property Cap As New LUNA.LunaFieldName("Cap")
		Public Shared ReadOnly Property Citta As New LUNA.LunaFieldName("Citta")
		Public Shared ReadOnly Property DataAcquisizione As New LUNA.LunaFieldName("DataAcquisizione")
		Public Shared ReadOnly Property Disattivo As New LUNA.LunaFieldName("Disattivo")
		Public Shared ReadOnly Property Email As New LUNA.LunaFieldName("Email")
		Public Shared ReadOnly Property Fax As New LUNA.LunaFieldName("Fax")
		Public Shared ReadOnly Property IdCategoria As New LUNA.LunaFieldName("IdCategoria")
		Public Shared ReadOnly Property IdCategoria2 As New LUNA.LunaFieldName("IdCategoria2")
		Public Shared ReadOnly Property IdUtente As New LUNA.LunaFieldName("IdUtente")
		Public Shared ReadOnly Property Indirizzo As New LUNA.LunaFieldName("Indirizzo")
		Public Shared ReadOnly Property Lavorato As New LUNA.LunaFieldName("Lavorato")
		Public Shared ReadOnly Property NoEmail As New LUNA.LunaFieldName("NoEmail")
		Public Shared ReadOnly Property NomeAzienda As New LUNA.LunaFieldName("NomeAzienda")
		Public Shared ReadOnly Property Sito As New LUNA.LunaFieldName("Sito")
		Public Shared ReadOnly Property Tag As New LUNA.LunaFieldName("Tag")
		Public Shared ReadOnly Property Telefono As New LUNA.LunaFieldName("Telefono")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
		Public Shared ReadOnly Property UrlProvenienza As New LUNA.LunaFieldName("UrlProvenienza")
	End Class

End Class