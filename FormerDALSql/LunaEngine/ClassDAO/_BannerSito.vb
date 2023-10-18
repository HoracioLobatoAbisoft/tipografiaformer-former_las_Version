#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 29/05/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Bannersito
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _BannerSito
	Inherits LUNA.LunaBaseClassEntity
	Implements _IBannerSito
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IBannerSito.FillFromDataRecord
		IdBannerSito = myRecord("IdBannerSito")
		If Not myRecord("Alternate") Is DBNull.Value Then Alternate = myRecord("Alternate")
		imgRif = myRecord("imgRif")
		Ordine = myRecord("Ordine")
		Stato = myRecord("Stato")
		Url = myRecord("Url")

		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of BannerSito)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(BannerSitoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of BannerSito))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdBannerSito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property Alternate As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property imgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property Ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
		Public Shared Property Url As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdBannerSito = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.Alternate = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.imgRif = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.Ordine = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime
		WhatIsChanged.Url = LUNA.LunaContext.WriteAllFieldEveryTime

	End Sub

	Protected _IdBannerSito As Integer = 0
	Public Overridable Property IdBannerSito() As Integer Implements _IBannerSito.IdBannerSito
		Get
			Return _IdBannerSito
		End Get
		Set(ByVal value As Integer)
			If _IdBannerSito <> value Then
				IsChanged = True
				WhatIsChanged.IdBannerSito = True
				_IdBannerSito = value
			End If
		End Set
	End Property

	Protected _Alternate As String = ""
	Public Overridable Property Alternate() As String Implements _IBannerSito.Alternate
		Get
			Return _Alternate
		End Get
		Set(ByVal value As String)
			If _Alternate <> value Then
				IsChanged = True
				WhatIsChanged.Alternate = True
				_Alternate = value
			End If
		End Set
	End Property

	Protected _imgRif As String = ""
	Public Overridable Property imgRif() As String Implements _IBannerSito.imgRif
		Get
			Return _imgRif
		End Get
		Set(ByVal value As String)
			If _imgRif <> value Then
				IsChanged = True
				WhatIsChanged.imgRif = True
				_imgRif = value
			End If
		End Set
	End Property

	Protected _Ordine As Integer = 0
	Public Overridable Property Ordine() As Integer Implements _IBannerSito.Ordine
		Get
			Return _Ordine
		End Get
		Set(ByVal value As Integer)
			If _Ordine <> value Then
				IsChanged = True
				WhatIsChanged.Ordine = True
				_Ordine = value
			End If
		End Set
	End Property

	Protected _Stato As Integer = 0
	Public Overridable Property Stato() As Integer Implements _IBannerSito.Stato
		Get
			Return _Stato
		End Get
		Set(ByVal value As Integer)
			If _Stato <> value Then
				IsChanged = True
				WhatIsChanged.Stato = True
				_Stato = value
			End If
		End Set
	End Property

	Protected _Url As String = ""
	Public Overridable Property Url() As String Implements _IBannerSito.Url
		Get
			Return _Url
		End Get
		Set(ByVal value As String)
			If _Url <> value Then
				IsChanged = True
				WhatIsChanged.Url = True
				_Url = value
			End If
		End Set
	End Property


#End Region

#Region "Method"
	''' <summary>
	'''This method read an BannerSito from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As BannerSito = Manager.Read(Id)
				_IdBannerSito = int.IdBannerSito
				_Alternate = int.Alternate
				_imgRif = int.imgRif
				_Ordine = int.Ordine
				_Stato = int.Stato
				_Url = int.Url
			End Using
			Manager = Nothing
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
		If IdBannerSito Then
			ris = Read(IdBannerSito)
		End If
		Return ris
	End Function

	''' <summary>
	'''This method save an BannerSito on DB.
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
			Manager = Nothing
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ris
	End Function

	Protected Function InternalIsValid() As Boolean
		Dim Ris As Boolean = True
		If _Alternate.Length > 255 Then Ris = False

		'if _imgRif.Length = 0 then Ris = False
		If _imgRif.Length > 255 Then Ris = False

		If _Url.Length = 0 Then Ris = False
		If _Url.Length > 2000 Then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class

''' <summary>
'''Interface for table Bannersito
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IBannerSito

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdBannerSito() As Integer
	Property Alternate() As String
	Property imgRif() As String
	Property Ordine() As Integer
	Property Stato() As Integer
	Property Url() As String

#End Region

End Interface

Partial Public Class LFM

	Public Class BannerSito
		Public Shared ReadOnly Property IdBannerSito As New LUNA.LunaFieldName("IdBannerSito")
		Public Shared ReadOnly Property Alternate As New LUNA.LunaFieldName("Alternate")
		Public Shared ReadOnly Property imgRif As New LUNA.LunaFieldName("imgRif")
		Public Shared ReadOnly Property Ordine As New LUNA.LunaFieldName("Ordine")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property Url As New LUNA.LunaFieldName("Url")
	End Class

End Class