#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 04/03/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Couponlog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CouponLog
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICouponLog
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICouponLog.FillFromDataRecord
		IdCouponLog = myRecord("IdCouponLog")
		IdCoupon = myRecord("IdCoupon")
		IdUt = myRecord("IdUt")
		Quando = myRecord("Quando")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CouponLog)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CouponLogDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CouponLog))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCouponLog As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCoupon As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCouponLog = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCoupon = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCouponLog as integer  = 0 
	Public Overridable Property IdCouponLog() as integer  Implements _ICouponLog.IdCouponLog
		Get
			Return _IdCouponLog
		End Get
		Set (byval value as integer)
			If _IdCouponLog <> value Then
				IsChanged = True
				WhatIsChanged.IdCouponLog = True
				_IdCouponLog = value
			End If
		End Set
	End property 

	Protected _IdCoupon as integer  = 0 
	Public Overridable Property IdCoupon() as integer  Implements _ICouponLog.IdCoupon
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

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _ICouponLog.IdUt
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

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _ICouponLog.Quando
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CouponLog from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CouponLog = Manager.Read(Id)
				_IdCouponLog = int.IdCouponLog
				_IdCoupon = int.IdCoupon
				_IdUt = int.IdUt
				_Quando = int.Quando
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CouponLog on DB.
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
'''Interface for table Couponlog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICouponLog

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCouponLog() as integer
	Property IdCoupon() as integer
	Property IdUt() as integer
	Property Quando() as DateTime

#End Region

End Interface

Partial Public Class LFM

	Public Class CouponLog
		Public Shared ReadOnly Property IdCouponLog As New LUNA.LunaFieldName("IdCouponLog")
		Public Shared ReadOnly Property IdCoupon As New LUNA.LunaFieldName("IdCoupon")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
	End Class

End Class