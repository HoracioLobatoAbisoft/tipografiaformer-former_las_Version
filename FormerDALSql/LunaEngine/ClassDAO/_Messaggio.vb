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
'''DAO Class for table T_postit
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Messaggio
	Inherits LUNA.LunaBaseClassEntity
	Implements _IMessaggio
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IMessaggio.FillFromDataRecord
		IdPostit = myRecord("IdPostit")
		if not myRecord("AltroRiferimento") is DBNull.Value then AltroRiferimento = myRecord("AltroRiferimento")
		if not myRecord("DataIns") is DBNull.Value then DataIns = myRecord("DataIns")
		if not myRecord("IdCom") is DBNull.Value then IdCom = myRecord("IdCom")
		if not myRecord("IdDest") is DBNull.Value then IdDest = myRecord("IdDest")
		if not myRecord("IdMitt") is DBNull.Value then IdMitt = myRecord("IdMitt")
		if not myRecord("IdOrd") is DBNull.Value then IdOrd = myRecord("IdOrd")
		if not myRecord("IdVoceRubrica") is DBNull.Value then IdVoceRubrica = myRecord("IdVoceRubrica")
		if not myRecord("Letto") is DBNull.Value then Letto = myRecord("Letto")
		if not myRecord("NumeroTel") is DBNull.Value then NumeroTel = myRecord("NumeroTel")
		if not myRecord("Status") is DBNull.Value then Status = myRecord("Status")
		if not myRecord("Testo") is DBNull.Value then Testo = myRecord("Testo")
		if not myRecord("TipoMsg") is DBNull.Value then TipoMsg = myRecord("TipoMsg")
		if not myRecord("Titolo") is DBNull.Value then Titolo = myRecord("Titolo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Messaggio)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(MessaggiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Messaggio))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdPostit As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AltroRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdDest As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMitt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdVoceRubrica As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Letto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumeroTel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Status As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Testo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoMsg As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Titolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdPostit = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AltroRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdDest = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMitt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdVoceRubrica = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Letto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumeroTel = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Status = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Testo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoMsg = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Titolo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdPostit as integer  = 0 
	Public Overridable Property IdPostit() as integer  Implements _IMessaggio.IdPostit
		Get
			Return _IdPostit
		End Get
		Set (byval value as integer)
			If _IdPostit <> value Then
				IsChanged = True
				WhatIsChanged.IdPostit = True
				_IdPostit = value
			End If
		End Set
	End property 

	Protected _AltroRiferimento as string  = "" 
	Public Overridable Property AltroRiferimento() as string  Implements _IMessaggio.AltroRiferimento
		Get
			Return _AltroRiferimento
		End Get
		Set (byval value as string)
			If _AltroRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.AltroRiferimento = True
				_AltroRiferimento = value
			End If
		End Set
	End property 

	Protected _DataIns as DateTime  = Nothing 
	Public Overridable Property DataIns() as DateTime  Implements _IMessaggio.DataIns
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

	Protected _IdCom as integer  = 0 
	Public Overridable Property IdCom() as integer  Implements _IMessaggio.IdCom
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

	Protected _IdDest as integer  = 0 
	Public Overridable Property IdDest() as integer  Implements _IMessaggio.IdDest
		Get
			Return _IdDest
		End Get
		Set (byval value as integer)
			If _IdDest <> value Then
				IsChanged = True
				WhatIsChanged.IdDest = True
				_IdDest = value
			End If
		End Set
	End property 

	Protected _IdMitt as integer  = 0 
	Public Overridable Property IdMitt() as integer  Implements _IMessaggio.IdMitt
		Get
			Return _IdMitt
		End Get
		Set (byval value as integer)
			If _IdMitt <> value Then
				IsChanged = True
				WhatIsChanged.IdMitt = True
				_IdMitt = value
			End If
		End Set
	End property 

	Protected _IdOrd as integer  = 0 
	Public Overridable Property IdOrd() as integer  Implements _IMessaggio.IdOrd
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

	Protected _IdVoceRubrica as integer  = 0 
	Public Overridable Property IdVoceRubrica() as integer  Implements _IMessaggio.IdVoceRubrica
		Get
			Return _IdVoceRubrica
		End Get
		Set (byval value as integer)
			If _IdVoceRubrica <> value Then
				IsChanged = True
				WhatIsChanged.IdVoceRubrica = True
				_IdVoceRubrica = value
			End If
		End Set
	End property 

	Protected _Letto as Boolean  = False 
	Public Overridable Property Letto() as Boolean  Implements _IMessaggio.Letto
		Get
			Return _Letto
		End Get
		Set (byval value as Boolean)
			If _Letto <> value Then
				IsChanged = True
				WhatIsChanged.Letto = True
				_Letto = value
			End If
		End Set
	End property 

	Protected _NumeroTel as string  = "" 
	Public Overridable Property NumeroTel() as string  Implements _IMessaggio.NumeroTel
		Get
			Return _NumeroTel
		End Get
		Set (byval value as string)
			If _NumeroTel <> value Then
				IsChanged = True
				WhatIsChanged.NumeroTel = True
				_NumeroTel = value
			End If
		End Set
	End property 

	Protected _Status as integer  = 0 
	Public Overridable Property Status() as integer  Implements _IMessaggio.Status
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

	Protected _Testo as string  = "" 
	Public Overridable Property Testo() as string  Implements _IMessaggio.Testo
		Get
			Return _Testo
		End Get
		Set (byval value as string)
			If _Testo <> value Then
				IsChanged = True
				WhatIsChanged.Testo = True
				_Testo = value
			End If
		End Set
	End property 

	Protected _TipoMsg as integer  = 0 
	Public Overridable Property TipoMsg() as integer  Implements _IMessaggio.TipoMsg
		Get
			Return _TipoMsg
		End Get
		Set (byval value as integer)
			If _TipoMsg <> value Then
				IsChanged = True
				WhatIsChanged.TipoMsg = True
				_TipoMsg = value
			End If
		End Set
	End property 

	Protected _Titolo as string  = "" 
	Public Overridable Property Titolo() as string  Implements _IMessaggio.Titolo
		Get
			Return _Titolo
		End Get
		Set (byval value as string)
			If _Titolo <> value Then
				IsChanged = True
				WhatIsChanged.Titolo = True
				_Titolo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Messaggio from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Messaggio = Manager.Read(Id)
				_IdPostit = int.IdPostit
				_AltroRiferimento = int.AltroRiferimento
				_DataIns = int.DataIns
				_IdCom = int.IdCom
				_IdDest = int.IdDest
				_IdMitt = int.IdMitt
				_IdOrd = int.IdOrd
				_IdVoceRubrica = int.IdVoceRubrica
				_Letto = int.Letto
				_NumeroTel = int.NumeroTel
				_Status = int.Status
				_Testo = int.Testo
				_TipoMsg = int.TipoMsg
				_Titolo = int.Titolo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Messaggio on DB.
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
		if _AltroRiferimento.Length > 100 then Ris = False
		if _NumeroTel.Length > 30 then Ris = False
		if _Testo.Length > 2000 then Ris = False
		if _Titolo.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_postit
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IMessaggio

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdPostit() as integer
	Property AltroRiferimento() as string
	Property DataIns() as DateTime
	Property IdCom() as integer
	Property IdDest() as integer
	Property IdMitt() as integer
	Property IdOrd() as integer
	Property IdVoceRubrica() as integer
	Property Letto() as Boolean
	Property NumeroTel() as string
	Property Status() as integer
	Property Testo() as string
	Property TipoMsg() as integer
	Property Titolo() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Messaggio
		Public Shared ReadOnly Property IdPostit As New LUNA.LunaFieldName("IdPostit")
		Public Shared ReadOnly Property AltroRiferimento As New LUNA.LunaFieldName("AltroRiferimento")
		Public Shared ReadOnly Property DataIns As New LUNA.LunaFieldName("DataIns")
		Public Shared ReadOnly Property IdCom As New LUNA.LunaFieldName("IdCom")
		Public Shared ReadOnly Property IdDest As New LUNA.LunaFieldName("IdDest")
		Public Shared ReadOnly Property IdMitt As New LUNA.LunaFieldName("IdMitt")
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property IdVoceRubrica As New LUNA.LunaFieldName("IdVoceRubrica")
		Public Shared ReadOnly Property Letto As New LUNA.LunaFieldName("Letto")
		Public Shared ReadOnly Property NumeroTel As New LUNA.LunaFieldName("NumeroTel")
		Public Shared ReadOnly Property Status As New LUNA.LunaFieldName("Status")
		Public Shared ReadOnly Property Testo As New LUNA.LunaFieldName("Testo")
		Public Shared ReadOnly Property TipoMsg As New LUNA.LunaFieldName("TipoMsg")
		Public Shared ReadOnly Property Titolo As New LUNA.LunaFieldName("Titolo")
	End Class

End Class