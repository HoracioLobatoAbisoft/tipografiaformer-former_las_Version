#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 22/02/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Indirizzi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Indirizzo
	Inherits LUNA.LunaBaseClassEntity
	Implements _IIndirizzo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IIndirizzo.FillFromDataRecord
		IdIndirizzo = myRecord("IdIndirizzo")
		Cap = myRecord("Cap")
		Citta = myRecord("Citta")
		if not myRecord("Destinatario") is DBNull.Value then Destinatario = myRecord("Destinatario")
		IdComune = myRecord("IdComune")
		if not myRecord("IdIndirizzoInt") is DBNull.Value then IdIndirizzoInt = myRecord("IdIndirizzoInt")
		if not myRecord("IdNazione") is DBNull.Value then IdNazione = myRecord("IdNazione")
		IdProvincia = myRecord("IdProvincia")
		IdUt = myRecord("IdUt")
		Indirizzo = myRecord("Indirizzo")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		Predefinito = myRecord("Predefinito")
		if not myRecord("Presso") is DBNull.Value then Presso = myRecord("Presso")
		Status = myRecord("Status")
		if not myRecord("Telefono") is DBNull.Value then Telefono = myRecord("Telefono")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Indirizzo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(IndirizziDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Indirizzo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdIndirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Cap As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Citta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Destinatario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdComune As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdIndirizzoInt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdNazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProvincia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Indirizzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Predefinito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Presso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Status As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Telefono As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdIndirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Cap = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Citta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Destinatario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdComune = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdIndirizzoInt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdNazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProvincia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Indirizzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Predefinito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Presso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Status = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Telefono = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdIndirizzo as integer  = 0 
	Public Overridable Property IdIndirizzo() as integer  Implements _IIndirizzo.IdIndirizzo
		Get
			Return _IdIndirizzo
		End Get
		Set (byval value as integer)
			If _IdIndirizzo <> value Then
				IsChanged = True
				WhatIsChanged.IdIndirizzo = True
				_IdIndirizzo = value
			End If
		End Set
	End property 

	Protected _Cap as string  = "" 
	Public Overridable Property Cap() as string  Implements _IIndirizzo.Cap
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
	Public Overridable Property Citta() as string  Implements _IIndirizzo.Citta
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

	Protected _Destinatario as string  = "" 
	Public Overridable Property Destinatario() as string  Implements _IIndirizzo.Destinatario
		Get
			Return _Destinatario
		End Get
		Set (byval value as string)
			If _Destinatario <> value Then
				IsChanged = True
				WhatIsChanged.Destinatario = True
				_Destinatario = value
			End If
		End Set
	End property 

	Protected _IdComune as integer  = 0 
	Public Overridable Property IdComune() as integer  Implements _IIndirizzo.IdComune
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

	Protected _IdIndirizzoInt as integer  = 0 
	Public Overridable Property IdIndirizzoInt() as integer  Implements _IIndirizzo.IdIndirizzoInt
		Get
			Return _IdIndirizzoInt
		End Get
		Set (byval value as integer)
			If _IdIndirizzoInt <> value Then
				IsChanged = True
				WhatIsChanged.IdIndirizzoInt = True
				_IdIndirizzoInt = value
			End If
		End Set
	End property 

	Protected _IdNazione as integer  = 0 
	Public Overridable Property IdNazione() as integer  Implements _IIndirizzo.IdNazione
		Get
			Return _IdNazione
		End Get
		Set (byval value as integer)
			If _IdNazione <> value Then
				IsChanged = True
				WhatIsChanged.IdNazione = True
				_IdNazione = value
			End If
		End Set
	End property 

	Protected _IdProvincia as integer  = 0 
	Public Overridable Property IdProvincia() as integer  Implements _IIndirizzo.IdProvincia
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

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IIndirizzo.IdUt
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

	Protected _Indirizzo as string  = "" 
	Public Overridable Property Indirizzo() as string  Implements _IIndirizzo.Indirizzo
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

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IIndirizzo.Nome
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

	Protected _Predefinito as Boolean  = False 
	Public Overridable Property Predefinito() as Boolean  Implements _IIndirizzo.Predefinito
		Get
			Return _Predefinito
		End Get
		Set (byval value as Boolean)
			If _Predefinito <> value Then
				IsChanged = True
				WhatIsChanged.Predefinito = True
				_Predefinito = value
			End If
		End Set
	End property 

	Protected _Presso as string  = "" 
	Public Overridable Property Presso() as string  Implements _IIndirizzo.Presso
		Get
			Return _Presso
		End Get
		Set (byval value as string)
			If _Presso <> value Then
				IsChanged = True
				WhatIsChanged.Presso = True
				_Presso = value
			End If
		End Set
	End property 

	Protected _Status as integer  = 0 
	Public Overridable Property Status() as integer  Implements _IIndirizzo.Status
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

	Protected _Telefono as string  = "" 
	Public Overridable Property Telefono() as string  Implements _IIndirizzo.Telefono
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Indirizzo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Indirizzo = Manager.Read(Id)
				_IdIndirizzo = int.IdIndirizzo
				_Cap = int.Cap
				_Citta = int.Citta
				_Destinatario = int.Destinatario
				_IdComune = int.IdComune
				_IdIndirizzoInt = int.IdIndirizzoInt
				_IdNazione = int.IdNazione
				_IdProvincia = int.IdProvincia
				_IdUt = int.IdUt
				_Indirizzo = int.Indirizzo
				_Nome = int.Nome
				_Predefinito = int.Predefinito
				_Presso = int.Presso
				_Status = int.Status
				_Telefono = int.Telefono
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Indirizzo on DB.
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

		If _Cap.Length = 0 Then Ris = False
		If _Cap.Length > 5 then Ris = False

		'if _Citta.Length = 0 then Ris = False
		If _Citta.Length > 100 then Ris = False
		if _Destinatario.Length > 255 then Ris = False
  
		if _Indirizzo.Length = 0 then Ris = False
		if _Indirizzo.Length > 100 then Ris = False
		if _Nome.Length > 100 then Ris = False
		if _Presso.Length > 255 then Ris = False
		if _Telefono.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Indirizzi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IIndirizzo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdIndirizzo() as integer
	Property Cap() as string
	Property Citta() as string
	Property Destinatario() as string
	Property IdComune() as integer
	Property IdIndirizzoInt() as integer
	Property IdNazione() as integer
	Property IdProvincia() as integer
	Property IdUt() as integer
	Property Indirizzo() as string
	Property Nome() as string
	Property Predefinito() as Boolean
	Property Presso() as string
	Property Status() as integer
	Property Telefono() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Indirizzo
		Public Shared ReadOnly Property IdIndirizzo As New LUNA.LunaFieldName("IdIndirizzo")
		Public Shared ReadOnly Property Cap As New LUNA.LunaFieldName("Cap")
		Public Shared ReadOnly Property Citta As New LUNA.LunaFieldName("Citta")
		Public Shared ReadOnly Property Destinatario As New LUNA.LunaFieldName("Destinatario")
		Public Shared ReadOnly Property IdComune As New LUNA.LunaFieldName("IdComune")
		Public Shared ReadOnly Property IdIndirizzoInt As New LUNA.LunaFieldName("IdIndirizzoInt")
		Public Shared ReadOnly Property IdNazione As New LUNA.LunaFieldName("IdNazione")
		Public Shared ReadOnly Property IdProvincia As New LUNA.LunaFieldName("IdProvincia")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property Indirizzo As New LUNA.LunaFieldName("Indirizzo")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property Predefinito As New LUNA.LunaFieldName("Predefinito")
		Public Shared ReadOnly Property Presso As New LUNA.LunaFieldName("Presso")
		Public Shared ReadOnly Property Status As New LUNA.LunaFieldName("Status")
		Public Shared ReadOnly Property Telefono As New LUNA.LunaFieldName("Telefono")
	End Class

End Class