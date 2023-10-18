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
'''DAO Class for table Ipban
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _IpBan
	Inherits LUNA.LunaBaseClassEntity
	Implements _IIpBan
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IIpBan.FillFromDataRecord
		IdIpBan = myRecord("IdIpBan")
		IpToBan = myRecord("IpToBan")
		Quando = myRecord("Quando")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of IpBan)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(IpBanDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of IpBan))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdIpBan As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IpToBan As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdIpBan = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IpToBan = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdIpBan as integer  = 0 
	Public Overridable Property IdIpBan() as integer  Implements _IIpBan.IdIpBan
		Get
			Return _IdIpBan
		End Get
		Set (byval value as integer)
			If _IdIpBan <> value Then
				IsChanged = True
				WhatIsChanged.IdIpBan = True
				_IdIpBan = value
			End If
		End Set
	End property 

	Protected _IpToBan as string  = "" 
	Public Overridable Property IpToBan() as string  Implements _IIpBan.IpToBan
		Get
			Return _IpToBan
		End Get
		Set (byval value as string)
			If _IpToBan <> value Then
				IsChanged = True
				WhatIsChanged.IpToBan = True
				_IpToBan = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IIpBan.Quando
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
	'''This method read an IpBan from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As IpBan = Manager.Read(Id)
				_IdIpBan = int.IdIpBan
				_IpToBan = int.IpToBan
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
	'''This method save an IpBan on DB.
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
  
		if _IpToBan.Length = 0 then Ris = False
		if _IpToBan.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Ipban
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IIpBan

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdIpBan() as integer
	Property IpToBan() as string
	Property Quando() as DateTime

#End Region

End Interface

Partial Public Class LFM

	Public Class IpBan
		Public Shared ReadOnly Property IdIpBan As New LUNA.LunaFieldName("IdIpBan")
		Public Shared ReadOnly Property IpToBan As New LUNA.LunaFieldName("IpToBan")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
	End Class

End Class