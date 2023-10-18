#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 27/12/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table F24
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _F24
	Inherits LUNA.LunaBaseClassEntity
	Implements _IF24
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IF24.FillFromDataRecord
		IdF24 = myRecord("IdF24")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		IdAzienda = myRecord("IdAzienda")
		InseritoIl = myRecord("InseritoIl")
		if not myRecord("NotePagamento") is DBNull.Value then NotePagamento = myRecord("NotePagamento")
		if not myRecord("PagatoIl") is DBNull.Value then PagatoIl = myRecord("PagatoIl")
		Totale = myRecord("Totale")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of F24)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(F24DAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of F24))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdF24 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdAzienda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property InseritoIl As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NotePagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PagatoIl As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Totale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdF24 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdAzienda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.InseritoIl = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NotePagamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PagatoIl = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Totale = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdF24 as integer  = 0 
	Public Overridable Property IdF24() as integer  Implements _IF24.IdF24
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

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IF24.Descrizione
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

	Protected _IdAzienda as integer  = 0 
	Public Overridable Property IdAzienda() as integer  Implements _IF24.IdAzienda
		Get
			Return _IdAzienda
		End Get
		Set (byval value as integer)
			If _IdAzienda <> value Then
				IsChanged = True
				WhatIsChanged.IdAzienda = True
				_IdAzienda = value
			End If
		End Set
	End property 

	Protected _InseritoIl as DateTime  = Nothing 
	Public Overridable Property InseritoIl() as DateTime  Implements _IF24.InseritoIl
		Get
			Return _InseritoIl
		End Get
		Set (byval value as DateTime)
			If _InseritoIl <> value Then
				IsChanged = True
				WhatIsChanged.InseritoIl = True
				_InseritoIl = value
			End If
		End Set
	End property 

	Protected _NotePagamento as string  = "" 
	Public Overridable Property NotePagamento() as string  Implements _IF24.NotePagamento
		Get
			Return _NotePagamento
		End Get
		Set (byval value as string)
			If _NotePagamento <> value Then
				IsChanged = True
				WhatIsChanged.NotePagamento = True
				_NotePagamento = value
			End If
		End Set
	End property 

	Protected _PagatoIl as DateTime  = Nothing 
	Public Overridable Property PagatoIl() as DateTime  Implements _IF24.PagatoIl
		Get
			Return _PagatoIl
		End Get
		Set (byval value as DateTime)
			If _PagatoIl <> value Then
				IsChanged = True
				WhatIsChanged.PagatoIl = True
				_PagatoIl = value
			End If
		End Set
	End property 

	Protected _Totale as decimal  = 0 
	Public Overridable Property Totale() as decimal  Implements _IF24.Totale
		Get
			Return _Totale
		End Get
		Set (byval value as decimal)
			If _Totale <> value Then
				IsChanged = True
				WhatIsChanged.Totale = True
				_Totale = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an F24 from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As F24 = Manager.Read(Id)
				_IdF24 = int.IdF24
				_Descrizione = int.Descrizione
				_IdAzienda = int.IdAzienda
				_InseritoIl = int.InseritoIl
				_NotePagamento = int.NotePagamento
				_PagatoIl = int.PagatoIl
				_Totale = int.Totale
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
		If IdF24 Then
			ris = Read(IdF24)
		End If
		Return ris
	End Function

	''' <summary>
	'''This method save an F24 on DB.
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
		if _NotePagamento.Length > 100 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table F24
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IF24

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdF24() as integer
	Property Descrizione() as string
	Property IdAzienda() as integer
	Property InseritoIl() as DateTime
	Property NotePagamento() as string
	Property PagatoIl() as DateTime
	Property Totale() as decimal

#End Region

End Interface

Partial Public Class LFM

	Public Class F24
		Public Shared ReadOnly Property IdF24 As New LUNA.LunaFieldName("IdF24")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property IdAzienda As New LUNA.LunaFieldName("IdAzienda")
		Public Shared ReadOnly Property InseritoIl As New LUNA.LunaFieldName("InseritoIl")
		Public Shared ReadOnly Property NotePagamento As New LUNA.LunaFieldName("NotePagamento")
		Public Shared ReadOnly Property PagatoIl As New LUNA.LunaFieldName("PagatoIl")
		Public Shared ReadOnly Property Totale As New LUNA.LunaFieldName("Totale")
	End Class

End Class