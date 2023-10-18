#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 04/03/2019 
#End Region



''' <summary>
'''Entity Class for table Couponlog
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CouponLog
	Inherits _CouponLog
	Implements ICouponLog

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(myRecord as IDataRecord)
		MyBase.New(myRecord)
	End Sub

#Region "Database Field"


	Public Overrides Property IdCouponLog() as integer
		Get
			Return MyBase.IdCouponLog
		End Get
		Set (byval value as integer)
			MyBase.IdCouponLog= value
		End Set
	End Property 


	Public Overrides Property IdCoupon() as integer
		Get
			Return MyBase.IdCoupon
		End Get
		Set (byval value as integer)
			MyBase.IdCoupon= value
		End Set
	End Property 


	Public Overrides Property IdUt() as integer
		Get
			Return MyBase.IdUt
		End Get
		Set (byval value as integer)
			MyBase.IdUt= value
		End Set
	End Property 


	Public Overrides Property Quando() as DateTime
		Get
			Return MyBase.Quando
		End Get
		Set (byval value as DateTime)
			MyBase.Quando= value
		End Set
	End Property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

	Public Overrides Function IsValid() As Boolean Implements ICouponLog.IsValid
		'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
		'RETURN FALSE IF LOGIC CONTROL FAIL
		'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
		Dim Ris As Boolean = InternalIsValid
		'PUT YOUR LOGIC VALIDATION CODE HERE
		Return Ris
	End Function

	Public Overrides Function Read(Id As Integer) As Integer Implements ICouponLog.Read
		Dim Ris as integer = MyBase.Read(Id)
		Return Ris
	End Function

	Public Overrides Function Save() As Integer Implements ICouponLog.Save
		Dim Ris as integer = MyBase.Save()
		Return Ris
	End Function

	Public Overrides Function ToString() As String
		Return MyBase.ToString()
	End Function

#End Region

End Class

''' <summary>
'''Interface for table Couponlog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICouponLog
	Inherits _ICouponLog

#Region "Method"

	Function Read(Id As Integer) As Integer

	Function Save() As Integer

	Function IsValid() As Boolean

#End Region

End Interface