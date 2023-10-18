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
'''DAO Class for table Review
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Review
	Inherits LUNA.LunaBaseClassEntity
	Implements _IReview
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IReview.FillFromDataRecord
		IdReview = myRecord("IdReview")
		if not myRecord("Difetti") is DBNull.Value then Difetti = myRecord("Difetti")
		IdLavoro = myRecord("IdLavoro")
		IdListinoBase = myRecord("IdListinoBase")
		IdUt = myRecord("IdUt")
		if not myRecord("Pregi") is DBNull.Value then Pregi = myRecord("Pregi")
		if not myRecord("PrevedeCoupon") is DBNull.Value then PrevedeCoupon = myRecord("PrevedeCoupon")
		Quando = myRecord("Quando")
		if not myRecord("Risposta") is DBNull.Value then Risposta = myRecord("Risposta")
		Stato = myRecord("Stato")
		Voto = myRecord("Voto")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Review)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ReviewDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Review))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdReview As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Difetti As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdLavoro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Pregi As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrevedeCoupon As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Risposta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Voto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdReview = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Difetti = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdLavoro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Pregi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrevedeCoupon = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Risposta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Voto = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdReview as integer  = 0 
	Public Overridable Property IdReview() as integer  Implements _IReview.IdReview
		Get
			Return _IdReview
		End Get
		Set (byval value as integer)
			If _IdReview <> value Then
				IsChanged = True
				WhatIsChanged.IdReview = True
				_IdReview = value
			End If
		End Set
	End property 

	Protected _Difetti as string  = "" 
	Public Overridable Property Difetti() as string  Implements _IReview.Difetti
		Get
			Return _Difetti
		End Get
		Set (byval value as string)
			If _Difetti <> value Then
				IsChanged = True
				WhatIsChanged.Difetti = True
				_Difetti = value
			End If
		End Set
	End property 

	Protected _IdLavoro as integer  = 0 
	Public Overridable Property IdLavoro() as integer  Implements _IReview.IdLavoro
		Get
			Return _IdLavoro
		End Get
		Set (byval value as integer)
			If _IdLavoro <> value Then
				IsChanged = True
				WhatIsChanged.IdLavoro = True
				_IdLavoro = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IReview.IdListinoBase
		Get
			Return _IdListinoBase
		End Get
		Set (byval value as integer)
			If _IdListinoBase <> value Then
				IsChanged = True
				WhatIsChanged.IdListinoBase = True
				_IdListinoBase = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IReview.IdUt
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

	Protected _Pregi as string  = "" 
	Public Overridable Property Pregi() as string  Implements _IReview.Pregi
		Get
			Return _Pregi
		End Get
		Set (byval value as string)
			If _Pregi <> value Then
				IsChanged = True
				WhatIsChanged.Pregi = True
				_Pregi = value
			End If
		End Set
	End property 

	Protected _PrevedeCoupon as integer  = 0 
	Public Overridable Property PrevedeCoupon() as integer  Implements _IReview.PrevedeCoupon
		Get
			Return _PrevedeCoupon
		End Get
		Set (byval value as integer)
			If _PrevedeCoupon <> value Then
				IsChanged = True
				WhatIsChanged.PrevedeCoupon = True
				_PrevedeCoupon = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IReview.Quando
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

	Protected _Risposta as string  = "" 
	Public Overridable Property Risposta() as string  Implements _IReview.Risposta
		Get
			Return _Risposta
		End Get
		Set (byval value as string)
			If _Risposta <> value Then
				IsChanged = True
				WhatIsChanged.Risposta = True
				_Risposta = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IReview.Stato
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

	Protected _Voto as integer  = 0 
	Public Overridable Property Voto() as integer  Implements _IReview.Voto
		Get
			Return _Voto
		End Get
		Set (byval value as integer)
			If _Voto <> value Then
				IsChanged = True
				WhatIsChanged.Voto = True
				_Voto = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Review from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Review = Manager.Read(Id)
				_IdReview = int.IdReview
				_Difetti = int.Difetti
				_IdLavoro = int.IdLavoro
				_IdListinoBase = int.IdListinoBase
				_IdUt = int.IdUt
				_Pregi = int.Pregi
				_PrevedeCoupon = int.PrevedeCoupon
				_Quando = int.Quando
				_Risposta = int.Risposta
				_Stato = int.Stato
				_Voto = int.Voto
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Review on DB.
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
		if _Difetti.Length > 2147483647 then Ris = False
		if _Pregi.Length > 2147483647 then Ris = False
		if _Risposta.Length > 2147483647 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"



#End Region

End Class 

''' <summary>
'''Interface for table Review
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IReview

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdReview() as integer
	Property Difetti() as string
	Property IdLavoro() as integer
	Property IdListinoBase() as integer
	Property IdUt() as integer
	Property Pregi() as string
	Property PrevedeCoupon() as integer
	Property Quando() as DateTime
	Property Risposta() as string
	Property Stato() as integer
	Property Voto() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Review
		Public Shared ReadOnly Property IdReview As New LUNA.LunaFieldName("IdReview")
		Public Shared ReadOnly Property Difetti As New LUNA.LunaFieldName("Difetti")
		Public Shared ReadOnly Property IdLavoro As New LUNA.LunaFieldName("IdLavoro")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property Pregi As New LUNA.LunaFieldName("Pregi")
		Public Shared ReadOnly Property PrevedeCoupon As New LUNA.LunaFieldName("PrevedeCoupon")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
		Public Shared ReadOnly Property Risposta As New LUNA.LunaFieldName("Risposta")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property Voto As New LUNA.LunaFieldName("Voto")
	End Class

End Class