#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 19/12/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_utenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Utente
	Inherits LUNA.LunaBaseClassEntity
	Implements _IUtente
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IUtente.FillFromDataRecord
		IdUt = myRecord("IdUt")
		if not myRecord("AbilitaRepartoImballaggio") is DBNull.Value then AbilitaRepartoImballaggio = myRecord("AbilitaRepartoImballaggio")
		if not myRecord("Attivo") is DBNull.Value then Attivo = myRecord("Attivo")
		if not myRecord("idAzienda") is DBNull.Value then idAzienda = myRecord("idAzienda")
		if not myRecord("Login") is DBNull.Value then Login = myRecord("Login")
		if not myRecord("NomeReale") is DBNull.Value then NomeReale = myRecord("NomeReale")
		if not myRecord("NumeroMensilita") is DBNull.Value then NumeroMensilita = myRecord("NumeroMensilita")
		if not myRecord("PathFoto") is DBNull.Value then PathFoto = myRecord("PathFoto")
		if not myRecord("Pwd") is DBNull.Value then Pwd = myRecord("Pwd")
		if not myRecord("RedditoLordoMese") is DBNull.Value then RedditoLordoMese = myRecord("RedditoLordoMese")
		if not myRecord("RepDefault") is DBNull.Value then RepDefault = myRecord("RepDefault")
		if not myRecord("Tipo") is DBNull.Value then Tipo = myRecord("Tipo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Utente)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(UtentiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Utente))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AbilitaRepartoImballaggio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Attivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property idAzienda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Login As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeReale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumeroMensilita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PathFoto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Pwd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RedditoLordoMese As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RepDefault As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AbilitaRepartoImballaggio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Attivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.idAzienda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Login = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeReale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumeroMensilita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PathFoto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Pwd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RedditoLordoMese = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RepDefault = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IUtente.IdUt
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

	Protected _AbilitaRepartoImballaggio as integer  = 0 
	Public Overridable Property AbilitaRepartoImballaggio() as integer  Implements _IUtente.AbilitaRepartoImballaggio
		Get
			Return _AbilitaRepartoImballaggio
		End Get
		Set (byval value as integer)
			If _AbilitaRepartoImballaggio <> value Then
				IsChanged = True
				WhatIsChanged.AbilitaRepartoImballaggio = True
				_AbilitaRepartoImballaggio = value
			End If
		End Set
	End property 

	Protected _Attivo as Boolean  = False 
	Public Overridable Property Attivo() as Boolean  Implements _IUtente.Attivo
		Get
			Return _Attivo
		End Get
		Set (byval value as Boolean)
			If _Attivo <> value Then
				IsChanged = True
				WhatIsChanged.Attivo = True
				_Attivo = value
			End If
		End Set
	End property 

	Protected _idAzienda as integer  = 0 
	Public Overridable Property idAzienda() as integer  Implements _IUtente.idAzienda
		Get
			Return _idAzienda
		End Get
		Set (byval value as integer)
			If _idAzienda <> value Then
				IsChanged = True
				WhatIsChanged.idAzienda = True
				_idAzienda = value
			End If
		End Set
	End property 

	Protected _Login as string  = "" 
	Public Overridable Property Login() as string  Implements _IUtente.Login
		Get
			Return _Login
		End Get
		Set (byval value as string)
			If _Login <> value Then
				IsChanged = True
				WhatIsChanged.Login = True
				_Login = value
			End If
		End Set
	End property 

	Protected _NomeReale as string  = "" 
	Public Overridable Property NomeReale() as string  Implements _IUtente.NomeReale
		Get
			Return _NomeReale
		End Get
		Set (byval value as string)
			If _NomeReale <> value Then
				IsChanged = True
				WhatIsChanged.NomeReale = True
				_NomeReale = value
			End If
		End Set
	End property 

	Protected _NumeroMensilita as integer  = 0 
	Public Overridable Property NumeroMensilita() as integer  Implements _IUtente.NumeroMensilita
		Get
			Return _NumeroMensilita
		End Get
		Set (byval value as integer)
			If _NumeroMensilita <> value Then
				IsChanged = True
				WhatIsChanged.NumeroMensilita = True
				_NumeroMensilita = value
			End If
		End Set
	End property 

	Protected _PathFoto as string  = "" 
	Public Overridable Property PathFoto() as string  Implements _IUtente.PathFoto
		Get
			Return _PathFoto
		End Get
		Set (byval value as string)
			If _PathFoto <> value Then
				IsChanged = True
				WhatIsChanged.PathFoto = True
				_PathFoto = value
			End If
		End Set
	End property 

	Protected _Pwd as string  = "" 
	Public Overridable Property Pwd() as string  Implements _IUtente.Pwd
		Get
			Return _Pwd
		End Get
		Set (byval value as string)
			If _Pwd <> value Then
				IsChanged = True
				WhatIsChanged.Pwd = True
				_Pwd = value
			End If
		End Set
	End property 

	Protected _RedditoLordoMese as decimal  = 0 
	Public Overridable Property RedditoLordoMese() as decimal  Implements _IUtente.RedditoLordoMese
		Get
			Return _RedditoLordoMese
		End Get
		Set (byval value as decimal)
			If _RedditoLordoMese <> value Then
				IsChanged = True
				WhatIsChanged.RedditoLordoMese = True
				_RedditoLordoMese = value
			End If
		End Set
	End property 

	Protected _RepDefault as integer  = 0 
	Public Overridable Property RepDefault() as integer  Implements _IUtente.RepDefault
		Get
			Return _RepDefault
		End Get
		Set (byval value as integer)
			If _RepDefault <> value Then
				IsChanged = True
				WhatIsChanged.RepDefault = True
				_RepDefault = value
			End If
		End Set
	End property 

	Protected _Tipo as integer  = 0 
	Public Overridable Property Tipo() as integer  Implements _IUtente.Tipo
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Utente from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Utente = Manager.Read(Id)
				_IdUt = int.IdUt
				_AbilitaRepartoImballaggio = int.AbilitaRepartoImballaggio
				_Attivo = int.Attivo
				_idAzienda = int.idAzienda
				_Login = int.Login
				_NomeReale = int.NomeReale
				_NumeroMensilita = int.NumeroMensilita
				_PathFoto = int.PathFoto
				_Pwd = int.Pwd
				_RedditoLordoMese = int.RedditoLordoMese
				_RepDefault = int.RepDefault
				_Tipo = int.Tipo
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
    Public Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdUt Then
            ris = Read(IdUt)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an Utente on DB.
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
		if _Login.Length > 50 then Ris = False
		if _NomeReale.Length > 100 then Ris = False
		if _PathFoto.Length > 255 then Ris = False
		if _Pwd.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_utenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IUtente

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdUt() as integer
	Property AbilitaRepartoImballaggio() as integer
	Property Attivo() as Boolean
	Property idAzienda() as integer
	Property Login() as string
	Property NomeReale() as string
	Property NumeroMensilita() as integer
	Property PathFoto() as string
	Property Pwd() as string
	Property RedditoLordoMese() as decimal
	Property RepDefault() as integer
	Property Tipo() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Utente
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property AbilitaRepartoImballaggio As New LUNA.LunaFieldName("AbilitaRepartoImballaggio")
		Public Shared ReadOnly Property Attivo As New LUNA.LunaFieldName("Attivo")
		Public Shared ReadOnly Property idAzienda As New LUNA.LunaFieldName("idAzienda")
		Public Shared ReadOnly Property Login As New LUNA.LunaFieldName("Login")
		Public Shared ReadOnly Property NomeReale As New LUNA.LunaFieldName("NomeReale")
		Public Shared ReadOnly Property NumeroMensilita As New LUNA.LunaFieldName("NumeroMensilita")
		Public Shared ReadOnly Property PathFoto As New LUNA.LunaFieldName("PathFoto")
		Public Shared ReadOnly Property Pwd As New LUNA.LunaFieldName("Pwd")
		Public Shared ReadOnly Property RedditoLordoMese As New LUNA.LunaFieldName("RedditoLordoMese")
		Public Shared ReadOnly Property RepDefault As New LUNA.LunaFieldName("RepDefault")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
	End Class

End Class