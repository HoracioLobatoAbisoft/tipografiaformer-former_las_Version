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
'''DAO Class for table Pagamentionline
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _PagamentoOnline
	Inherits LUNA.LunaBaseClassEntity
	Implements _IPagamentoOnline
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IPagamentoOnline.FillFromDataRecord
		IdPagamentoOnline = myRecord("IdPagamentoOnline")
		IdConsegna = myRecord("IdConsegna")
		IdPagInt = myRecord("IdPagInt")
		IdTipoPagamento = myRecord("IdTipoPagamento")
		IdUt = myRecord("IdUt")
		if not myRecord("Importo") is DBNull.Value then Importo = myRecord("Importo")
		Quando = myRecord("Quando")
		StatoPagamento = myRecord("StatoPagamento")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of PagamentoOnline)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(PagamentiOnlineDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of PagamentoOnline))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdPagamentoOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPagInt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoPagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Importo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StatoPagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdPagamentoOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPagInt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoPagamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Importo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StatoPagamento = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdPagamentoOnline as integer  = 0 
	Public Overridable Property IdPagamentoOnline() as integer  Implements _IPagamentoOnline.IdPagamentoOnline
		Get
			Return _IdPagamentoOnline
		End Get
		Set (byval value as integer)
			If _IdPagamentoOnline <> value Then
				IsChanged = True
				WhatIsChanged.IdPagamentoOnline = True
				_IdPagamentoOnline = value
			End If
		End Set
	End property 

	Protected _IdConsegna as integer  = 0 
	Public Overridable Property IdConsegna() as integer  Implements _IPagamentoOnline.IdConsegna
		Get
			Return _IdConsegna
		End Get
		Set (byval value as integer)
			If _IdConsegna <> value Then
				IsChanged = True
				WhatIsChanged.IdConsegna = True
				_IdConsegna = value
			End If
		End Set
	End property 

	Protected _IdPagInt as integer  = 0 
	Public Overridable Property IdPagInt() as integer  Implements _IPagamentoOnline.IdPagInt
		Get
			Return _IdPagInt
		End Get
		Set (byval value as integer)
			If _IdPagInt <> value Then
				IsChanged = True
				WhatIsChanged.IdPagInt = True
				_IdPagInt = value
			End If
		End Set
	End property 

	Protected _IdTipoPagamento as integer  = 0 
	Public Overridable Property IdTipoPagamento() as integer  Implements _IPagamentoOnline.IdTipoPagamento
		Get
			Return _IdTipoPagamento
		End Get
		Set (byval value as integer)
			If _IdTipoPagamento <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoPagamento = True
				_IdTipoPagamento = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IPagamentoOnline.IdUt
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

	Protected _Importo as decimal  = 0 
	Public Overridable Property Importo() as decimal  Implements _IPagamentoOnline.Importo
		Get
			Return _Importo
		End Get
		Set (byval value as decimal)
			If _Importo <> value Then
				IsChanged = True
				WhatIsChanged.Importo = True
				_Importo = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IPagamentoOnline.Quando
		Get
			Return _Quando
		End Get
		Set (byval value as DateTime)
			If _Quando <> value Then
				IsChanged = True
				WhatIsChanged.Quando = True
				_Quando = value
			End If
		End Set
	End property 

	Protected _StatoPagamento as integer  = 0 
	Public Overridable Property StatoPagamento() as integer  Implements _IPagamentoOnline.StatoPagamento
		Get
			Return _StatoPagamento
		End Get
		Set (byval value as integer)
			If _StatoPagamento <> value Then
				IsChanged = True
				WhatIsChanged.StatoPagamento = True
				_StatoPagamento = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an PagamentoOnline from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As PagamentoOnline = Manager.Read(Id)
				_IdPagamentoOnline = int.IdPagamentoOnline
				_IdConsegna = int.IdConsegna
				_IdPagInt = int.IdPagInt
				_IdTipoPagamento = int.IdTipoPagamento
				_IdUt = int.IdUt
				_Importo = int.Importo
				_Quando = int.Quando
				_StatoPagamento = int.StatoPagamento
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an PagamentoOnline on DB.
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

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Pagamentionline
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IPagamentoOnline

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdPagamentoOnline() as integer
	Property IdConsegna() as integer
	Property IdPagInt() as integer
	Property IdTipoPagamento() as integer
	Property IdUt() as integer
	Property Importo() as decimal
	Property Quando() as DateTime
	Property StatoPagamento() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class PagamentoOnline
		Public Shared ReadOnly Property IdPagamentoOnline As New LUNA.LunaFieldName("IdPagamentoOnline")
		Public Shared ReadOnly Property IdConsegna As New LUNA.LunaFieldName("IdConsegna")
		Public Shared ReadOnly Property IdPagInt As New LUNA.LunaFieldName("IdPagInt")
		Public Shared ReadOnly Property IdTipoPagamento As New LUNA.LunaFieldName("IdTipoPagamento")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property Importo As New LUNA.LunaFieldName("Importo")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
		Public Shared ReadOnly Property StatoPagamento As New LUNA.LunaFieldName("StatoPagamento")
	End Class

End Class