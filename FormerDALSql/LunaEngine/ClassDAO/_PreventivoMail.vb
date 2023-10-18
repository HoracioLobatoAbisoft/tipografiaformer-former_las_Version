#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 28/11/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Mailpreventivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _PreventivoMail
	Inherits LUNA.LunaBaseClassEntity
	Implements _IPreventivoMail
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IPreventivoMail.FillFromDataRecord
		IdMailPreventivo = myRecord("IdMailPreventivo")
		if not myRecord("DalSito") is DBNull.Value then DalSito = myRecord("DalSito")
		if not myRecord("DataDel") is DBNull.Value then DataDel = myRecord("DataDel")
		DataRif = myRecord("DataRif")
		if not myRecord("GuidMail") is DBNull.Value then GuidMail = myRecord("GuidMail")
		if not myRecord("IdMailRif") is DBNull.Value then IdMailRif = myRecord("IdMailRif")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("IdUtDel") is DBNull.Value then IdUtDel = myRecord("IdUtDel")
		if not myRecord("IdUtFormer") is DBNull.Value then IdUtFormer = myRecord("IdUtFormer")
		if not myRecord("Letto") is DBNull.Value then Letto = myRecord("Letto")
		Mittente = myRecord("Mittente")
		if not myRecord("PrezzoSuggerito") is DBNull.Value then PrezzoSuggerito = myRecord("PrezzoSuggerito")
		Stato = myRecord("Stato")
		if not myRecord("Testo") is DBNull.Value then Testo = myRecord("Testo")
		if not myRecord("TipoMail") is DBNull.Value then TipoMail = myRecord("TipoMail")
		if not myRecord("Titolo") is DBNull.Value then Titolo = myRecord("Titolo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of PreventivoMail)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(PreventiviMailDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of PreventivoMail))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdMailPreventivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DalSito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataDel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GuidMail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMailRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUtDel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUtFormer As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Letto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Mittente As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoSuggerito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Testo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoMail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Titolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdMailPreventivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DalSito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataDel = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GuidMail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMailRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUtDel = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUtFormer = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Letto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Mittente = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoSuggerito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Testo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoMail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Titolo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdMailPreventivo as integer  = 0 
	Public Overridable Property IdMailPreventivo() as integer  Implements _IPreventivoMail.IdMailPreventivo
		Get
			Return _IdMailPreventivo
		End Get
		Set (byval value as integer)
			If _IdMailPreventivo <> value Then
				IsChanged = True
				WhatIsChanged.IdMailPreventivo = True
				_IdMailPreventivo = value
			End If
		End Set
	End property 

	Protected _DalSito as integer  = 0 
	Public Overridable Property DalSito() as integer  Implements _IPreventivoMail.DalSito
		Get
			Return _DalSito
		End Get
		Set (byval value as integer)
			If _DalSito <> value Then
				IsChanged = True
				WhatIsChanged.DalSito = True
				_DalSito = value
			End If
		End Set
	End property 

	Protected _DataDel as DateTime  = Nothing 
	Public Overridable Property DataDel() as DateTime  Implements _IPreventivoMail.DataDel
		Get
			Return _DataDel
		End Get
		Set (byval value as DateTime)
			If _DataDel <> value Then
				IsChanged = True
				WhatIsChanged.DataDel = True
				_DataDel = value
			End If
		End Set
	End property 

	Protected _DataRif as DateTime  = Nothing 
	Public Overridable Property DataRif() as DateTime  Implements _IPreventivoMail.DataRif
		Get
			Return _DataRif
		End Get
		Set (byval value as DateTime)
			If _DataRif <> value Then
				IsChanged = True
				WhatIsChanged.DataRif = True
				_DataRif = value
			End If
		End Set
	End property 

	Protected _GuidMail as string  = "" 
	Public Overridable Property GuidMail() as string  Implements _IPreventivoMail.GuidMail
		Get
			Return _GuidMail
		End Get
		Set (byval value as string)
			If _GuidMail <> value Then
				IsChanged = True
				WhatIsChanged.GuidMail = True
				_GuidMail = value
			End If
		End Set
	End property 

	Protected _IdMailRif as integer  = 0 
	Public Overridable Property IdMailRif() as integer  Implements _IPreventivoMail.IdMailRif
		Get
			Return _IdMailRif
		End Get
		Set (byval value as integer)
			If _IdMailRif <> value Then
				IsChanged = True
				WhatIsChanged.IdMailRif = True
				_IdMailRif = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IPreventivoMail.IdRub
		Get
			Return _IdRub
		End Get
		Set (byval value as integer)
			If _IdRub <> value Then
				IsChanged = True
				WhatIsChanged.IdRub = True
				_IdRub = value
			End If
		End Set
	End property 

	Protected _IdUtDel as integer  = 0 
	Public Overridable Property IdUtDel() as integer  Implements _IPreventivoMail.IdUtDel
		Get
			Return _IdUtDel
		End Get
		Set (byval value as integer)
			If _IdUtDel <> value Then
				IsChanged = True
				WhatIsChanged.IdUtDel = True
				_IdUtDel = value
			End If
		End Set
	End property 

	Protected _IdUtFormer as integer  = 0 
	Public Overridable Property IdUtFormer() as integer  Implements _IPreventivoMail.IdUtFormer
		Get
			Return _IdUtFormer
		End Get
		Set (byval value as integer)
			If _IdUtFormer <> value Then
				IsChanged = True
				WhatIsChanged.IdUtFormer = True
				_IdUtFormer = value
			End If
		End Set
	End property 

	Protected _Letto as integer  = 0 
	Public Overridable Property Letto() as integer  Implements _IPreventivoMail.Letto
		Get
			Return _Letto
		End Get
		Set (byval value as integer)
			If _Letto <> value Then
				IsChanged = True
				WhatIsChanged.Letto = True
				_Letto = value
			End If
		End Set
	End property 

	Protected _Mittente as string  = "" 
	Public Overridable Property Mittente() as string  Implements _IPreventivoMail.Mittente
		Get
			Return _Mittente
		End Get
		Set (byval value as string)
			If _Mittente <> value Then
				IsChanged = True
				WhatIsChanged.Mittente = True
				_Mittente = value
			End If
		End Set
	End property 

	Protected _PrezzoSuggerito as decimal  = 0 
	Public Overridable Property PrezzoSuggerito() as decimal  Implements _IPreventivoMail.PrezzoSuggerito
		Get
			Return _PrezzoSuggerito
		End Get
		Set (byval value as decimal)
			If _PrezzoSuggerito <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoSuggerito = True
				_PrezzoSuggerito = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IPreventivoMail.Stato
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

	Protected _Testo as string  = "" 
	Public Overridable Property Testo() as string  Implements _IPreventivoMail.Testo
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

	Protected _TipoMail as integer  = 0 
	Public Overridable Property TipoMail() as integer  Implements _IPreventivoMail.TipoMail
		Get
			Return _TipoMail
		End Get
		Set (byval value as integer)
			If _TipoMail <> value Then
				IsChanged = True
				WhatIsChanged.TipoMail = True
				_TipoMail = value
			End If
		End Set
	End property 

	Protected _Titolo as string  = "" 
	Public Overridable Property Titolo() as string  Implements _IPreventivoMail.Titolo
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
	'''This method read an PreventivoMail from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As PreventivoMail = Manager.Read(Id)
				_IdMailPreventivo = int.IdMailPreventivo
				_DalSito = int.DalSito
				_DataDel = int.DataDel
				_DataRif = int.DataRif
				_GuidMail = int.GuidMail
				_IdMailRif = int.IdMailRif
				_IdRub = int.IdRub
				_IdUtDel = int.IdUtDel
				_IdUtFormer = int.IdUtFormer
				_Letto = int.Letto
				_Mittente = int.Mittente
				_PrezzoSuggerito = int.PrezzoSuggerito
				_Stato = int.Stato
				_Testo = int.Testo
				_TipoMail = int.TipoMail
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
	'''This method save an PreventivoMail on DB.
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
		if _GuidMail.Length > 50 then Ris = False
  
		if _Mittente.Length = 0 then Ris = False
		if _Mittente.Length > 255 then Ris = False
		if _Testo.Length > 2147483647 then Ris = False
		if _Titolo.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Mailpreventivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IPreventivoMail

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdMailPreventivo() as integer
	Property DalSito() as integer
	Property DataDel() as DateTime
	Property DataRif() as DateTime
	Property GuidMail() as string
	Property IdMailRif() as integer
	Property IdRub() as integer
	Property IdUtDel() as integer
	Property IdUtFormer() as integer
	Property Letto() as integer
	Property Mittente() as string
	Property PrezzoSuggerito() as decimal
	Property Stato() as integer
	Property Testo() as string
	Property TipoMail() as integer
	Property Titolo() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class PreventivoMail
		Public Shared ReadOnly Property IdMailPreventivo As New LUNA.LunaFieldName("IdMailPreventivo")
		Public Shared ReadOnly Property DalSito As New LUNA.LunaFieldName("DalSito")
		Public Shared ReadOnly Property DataDel As New LUNA.LunaFieldName("DataDel")
		Public Shared ReadOnly Property DataRif As New LUNA.LunaFieldName("DataRif")
		Public Shared ReadOnly Property GuidMail As New LUNA.LunaFieldName("GuidMail")
		Public Shared ReadOnly Property IdMailRif As New LUNA.LunaFieldName("IdMailRif")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property IdUtDel As New LUNA.LunaFieldName("IdUtDel")
		Public Shared ReadOnly Property IdUtFormer As New LUNA.LunaFieldName("IdUtFormer")
		Public Shared ReadOnly Property Letto As New LUNA.LunaFieldName("Letto")
		Public Shared ReadOnly Property Mittente As New LUNA.LunaFieldName("Mittente")
		Public Shared ReadOnly Property PrezzoSuggerito As New LUNA.LunaFieldName("PrezzoSuggerito")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property Testo As New LUNA.LunaFieldName("Testo")
		Public Shared ReadOnly Property TipoMail As New LUNA.LunaFieldName("TipoMail")
		Public Shared ReadOnly Property Titolo As New LUNA.LunaFieldName("Titolo")
	End Class

End Class