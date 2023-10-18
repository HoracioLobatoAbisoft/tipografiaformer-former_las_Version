#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 19.2.27.1 
'Author: Diego Lunadei
'Date: 28/02/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_coupon
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Coupon
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICoupon
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICoupon.FillFromDataRecord
		IdCoupon = myRecord("IdCoupon")
		if not myRecord("Codice") is DBNull.Value then Codice = myRecord("Codice")
		if not myRecord("DataFineValidita") is DBNull.Value then DataFineValidita = myRecord("DataFineValidita")
		if not myRecord("DataInizioValidita") is DBNull.Value then DataInizioValidita = myRecord("DataInizioValidita")
		if not myRecord("IdCouponOnline") is DBNull.Value then IdCouponOnline = myRecord("IdCouponOnline")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		if not myRecord("IdReview") is DBNull.Value then IdReview = myRecord("IdReview")
		if not myRecord("ImgOnline") is DBNull.Value then ImgOnline = myRecord("ImgOnline")
		if not myRecord("ImportoFisso") is DBNull.Value then ImportoFisso = myRecord("ImportoFisso")
		if not myRecord("ImportoMinimoSpesa") is DBNull.Value then ImportoMinimoSpesa = myRecord("ImportoMinimoSpesa")
		if not myRecord("MaxVolte") is DBNull.Value then MaxVolte = myRecord("MaxVolte")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("Percentuale") is DBNull.Value then Percentuale = myRecord("Percentuale")
		if not myRecord("QtaSpecifica") is DBNull.Value then QtaSpecifica = myRecord("QtaSpecifica")
		if not myRecord("Riservato") is DBNull.Value then Riservato = myRecord("Riservato")
		if not myRecord("RiservatoATipoUtente") is DBNull.Value then RiservatoATipoUtente = myRecord("RiservatoATipoUtente")
		if not myRecord("Stato") is DBNull.Value then Stato = myRecord("Stato")
		if not myRecord("UrlHref") is DBNull.Value then UrlHref = myRecord("UrlHref")
		if not myRecord("VisibileOnline") is DBNull.Value then VisibileOnline = myRecord("VisibileOnline")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Coupon)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CouponDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Coupon))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCoupon As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataFineValidita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataInizioValidita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCouponOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdReview As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoFisso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoMinimoSpesa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MaxVolte As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Percentuale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property QtaSpecifica As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Riservato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RiservatoATipoUtente As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property UrlHref As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property VisibileOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCoupon = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataFineValidita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataInizioValidita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCouponOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdReview = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoFisso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoMinimoSpesa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MaxVolte = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Percentuale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.QtaSpecifica = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Riservato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RiservatoATipoUtente = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.UrlHref = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.VisibileOnline = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCoupon as integer  = 0 
	Public Overridable Property IdCoupon() as integer  Implements _ICoupon.IdCoupon
		Get
			Return _IdCoupon
		End Get
		Set (byval value as integer)
			If _IdCoupon <> value Then
				IsChanged = True
				WhatIsChanged.IdCoupon = True
				_IdCoupon = value
			End If
		End Set
	End property 

	Protected _Codice as string  = "" 
	Public Overridable Property Codice() as string  Implements _ICoupon.Codice
		Get
			Return _Codice
		End Get
		Set (byval value as string)
			If _Codice <> value Then
				IsChanged = True
				WhatIsChanged.Codice = True
				_Codice = value
			End If
		End Set
	End property 

	Protected _DataFineValidita as DateTime  = Nothing 
	Public Overridable Property DataFineValidita() as DateTime  Implements _ICoupon.DataFineValidita
		Get
			Return _DataFineValidita
		End Get
		Set (byval value as DateTime)
			If _DataFineValidita <> value Then
				IsChanged = True
				WhatIsChanged.DataFineValidita = True
				_DataFineValidita = value
			End If
		End Set
	End property 

	Protected _DataInizioValidita as DateTime  = Nothing 
	Public Overridable Property DataInizioValidita() as DateTime  Implements _ICoupon.DataInizioValidita
		Get
			Return _DataInizioValidita
		End Get
		Set (byval value as DateTime)
			If _DataInizioValidita <> value Then
				IsChanged = True
				WhatIsChanged.DataInizioValidita = True
				_DataInizioValidita = value
			End If
		End Set
	End property 

	Protected _IdCouponOnline as integer  = 0 
	Public Overridable Property IdCouponOnline() as integer  Implements _ICoupon.IdCouponOnline
		Get
			Return _IdCouponOnline
		End Get
		Set (byval value as integer)
			If _IdCouponOnline <> value Then
				IsChanged = True
				WhatIsChanged.IdCouponOnline = True
				_IdCouponOnline = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _ICoupon.IdListinoBase
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

	Protected _IdReview as integer  = 0 
	Public Overridable Property IdReview() as integer  Implements _ICoupon.IdReview
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

	Protected _ImgOnline as string  = "" 
	Public Overridable Property ImgOnline() as string  Implements _ICoupon.ImgOnline
		Get
			Return _ImgOnline
		End Get
		Set (byval value as string)
			If _ImgOnline <> value Then
				IsChanged = True
				WhatIsChanged.ImgOnline = True
				_ImgOnline = value
			End If
		End Set
	End property 

	Protected _ImportoFisso as decimal  = 0 
	Public Overridable Property ImportoFisso() as decimal  Implements _ICoupon.ImportoFisso
		Get
			Return _ImportoFisso
		End Get
		Set (byval value as decimal)
			If _ImportoFisso <> value Then
				IsChanged = True
				WhatIsChanged.ImportoFisso = True
				_ImportoFisso = value
			End If
		End Set
	End property 

	Protected _ImportoMinimoSpesa as decimal  = 0 
	Public Overridable Property ImportoMinimoSpesa() as decimal  Implements _ICoupon.ImportoMinimoSpesa
		Get
			Return _ImportoMinimoSpesa
		End Get
		Set (byval value as decimal)
			If _ImportoMinimoSpesa <> value Then
				IsChanged = True
				WhatIsChanged.ImportoMinimoSpesa = True
				_ImportoMinimoSpesa = value
			End If
		End Set
	End property 

	Protected _MaxVolte as integer  = 0 
	Public Overridable Property MaxVolte() as integer  Implements _ICoupon.MaxVolte
		Get
			Return _MaxVolte
		End Get
		Set (byval value as integer)
			If _MaxVolte <> value Then
				IsChanged = True
				WhatIsChanged.MaxVolte = True
				_MaxVolte = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _ICoupon.Nome
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

	Protected _Percentuale as integer  = 0 
	Public Overridable Property Percentuale() as integer  Implements _ICoupon.Percentuale
		Get
			Return _Percentuale
		End Get
		Set (byval value as integer)
			If _Percentuale <> value Then
				IsChanged = True
				WhatIsChanged.Percentuale = True
				_Percentuale = value
			End If
		End Set
	End property 

	Protected _QtaSpecifica as integer  = 0 
	Public Overridable Property QtaSpecifica() as integer  Implements _ICoupon.QtaSpecifica
		Get
			Return _QtaSpecifica
		End Get
		Set (byval value as integer)
			If _QtaSpecifica <> value Then
				IsChanged = True
				WhatIsChanged.QtaSpecifica = True
				_QtaSpecifica = value
			End If
		End Set
	End property 

	Protected _Riservato as integer  = 0 
	Public Overridable Property Riservato() as integer  Implements _ICoupon.Riservato
		Get
			Return _Riservato
		End Get
		Set (byval value as integer)
			If _Riservato <> value Then
				IsChanged = True
				WhatIsChanged.Riservato = True
				_Riservato = value
			End If
		End Set
	End property 

	Protected _RiservatoATipoUtente as integer  = 0 
	Public Overridable Property RiservatoATipoUtente() as integer  Implements _ICoupon.RiservatoATipoUtente
		Get
			Return _RiservatoATipoUtente
		End Get
		Set (byval value as integer)
			If _RiservatoATipoUtente <> value Then
				IsChanged = True
				WhatIsChanged.RiservatoATipoUtente = True
				_RiservatoATipoUtente = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _ICoupon.Stato
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

	Protected _UrlHref as string  = "" 
	Public Overridable Property UrlHref() as string  Implements _ICoupon.UrlHref
		Get
			Return _UrlHref
		End Get
		Set (byval value as string)
			If _UrlHref <> value Then
				IsChanged = True
				WhatIsChanged.UrlHref = True
				_UrlHref = value
			End If
		End Set
	End property 

	Protected _VisibileOnline as integer  = 0 
	Public Overridable Property VisibileOnline() as integer  Implements _ICoupon.VisibileOnline
		Get
			Return _VisibileOnline
		End Get
		Set (byval value as integer)
			If _VisibileOnline <> value Then
				IsChanged = True
				WhatIsChanged.VisibileOnline = True
				_VisibileOnline = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Coupon from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Coupon = Manager.Read(Id)
				_IdCoupon = int.IdCoupon
				_Codice = int.Codice
				_DataFineValidita = int.DataFineValidita
				_DataInizioValidita = int.DataInizioValidita
				_IdCouponOnline = int.IdCouponOnline
				_IdListinoBase = int.IdListinoBase
				_IdReview = int.IdReview
				_ImgOnline = int.ImgOnline
				_ImportoFisso = int.ImportoFisso
				_ImportoMinimoSpesa = int.ImportoMinimoSpesa
				_MaxVolte = int.MaxVolte
				_Nome = int.Nome
				_Percentuale = int.Percentuale
				_QtaSpecifica = int.QtaSpecifica
				_Riservato = int.Riservato
				_RiservatoATipoUtente = int.RiservatoATipoUtente
				_Stato = int.Stato
				_UrlHref = int.UrlHref
				_VisibileOnline = int.VisibileOnline
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Coupon on DB.
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
		if _Codice.Length > 255 then Ris = False
		if _ImgOnline.Length > 255 then Ris = False
		if _Nome.Length > 255 then Ris = False
		if _UrlHref.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_coupon
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICoupon

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCoupon() as integer
	Property Codice() as string
	Property DataFineValidita() as DateTime
	Property DataInizioValidita() as DateTime
	Property IdCouponOnline() as integer
	Property IdListinoBase() as integer
	Property IdReview() as integer
	Property ImgOnline() as string
	Property ImportoFisso() as decimal
	Property ImportoMinimoSpesa() as decimal
	Property MaxVolte() as integer
	Property Nome() as string
	Property Percentuale() as integer
	Property QtaSpecifica() as integer
	Property Riservato() as integer
	Property RiservatoATipoUtente() as integer
	Property Stato() as integer
	Property UrlHref() as string
	Property VisibileOnline() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Coupon
		Public Shared ReadOnly Property IdCoupon As New LUNA.LunaFieldName("IdCoupon")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property DataFineValidita As New LUNA.LunaFieldName("DataFineValidita")
		Public Shared ReadOnly Property DataInizioValidita As New LUNA.LunaFieldName("DataInizioValidita")
		Public Shared ReadOnly Property IdCouponOnline As New LUNA.LunaFieldName("IdCouponOnline")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdReview As New LUNA.LunaFieldName("IdReview")
		Public Shared ReadOnly Property ImgOnline As New LUNA.LunaFieldName("ImgOnline")
		Public Shared ReadOnly Property ImportoFisso As New LUNA.LunaFieldName("ImportoFisso")
		Public Shared ReadOnly Property ImportoMinimoSpesa As New LUNA.LunaFieldName("ImportoMinimoSpesa")
		Public Shared ReadOnly Property MaxVolte As New LUNA.LunaFieldName("MaxVolte")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property Percentuale As New LUNA.LunaFieldName("Percentuale")
		Public Shared ReadOnly Property QtaSpecifica As New LUNA.LunaFieldName("QtaSpecifica")
		Public Shared ReadOnly Property Riservato As New LUNA.LunaFieldName("Riservato")
		Public Shared ReadOnly Property RiservatoATipoUtente As New LUNA.LunaFieldName("RiservatoATipoUtente")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property UrlHref As New LUNA.LunaFieldName("UrlHref")
		Public Shared ReadOnly Property VisibileOnline As New LUNA.LunaFieldName("VisibileOnline")
	End Class

End Class