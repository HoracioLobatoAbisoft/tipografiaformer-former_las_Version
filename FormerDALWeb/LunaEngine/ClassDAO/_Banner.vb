#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 14/06/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Banner
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Banner
	Inherits LUNA.LunaBaseClassEntity
	Implements _IBanner
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IBanner.FillFromDataRecord
		IdBanner = myRecord("IdBanner")
		Alt = myRecord("Alt")
		Attivo = myRecord("Attivo")
		Path = myRecord("Path")
		Url = myRecord("Url")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Banner)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(BannerDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Banner))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdBanner As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Alt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Attivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Path As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Url As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdBanner = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Alt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Attivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Path = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Url = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdBanner as integer  = 0 
	Public Overridable Property IdBanner() as integer  Implements _IBanner.IdBanner
		Get
			Return _IdBanner
		End Get
		Set (byval value as integer)
			If _IdBanner <> value Then
				IsChanged = True
				WhatIsChanged.IdBanner = True
				_IdBanner = value
			End If
		End Set
	End property 

	Protected _Alt as string  = "" 
	Public Overridable Property Alt() as string  Implements _IBanner.Alt
		Get
			Return _Alt
		End Get
		Set (byval value as string)
			If _Alt <> value Then
				IsChanged = True
				WhatIsChanged.Alt = True
				_Alt = value
			End If
		End Set
	End property 

	Protected _Attivo as Boolean  = False 
	Public Overridable Property Attivo() as Boolean  Implements _IBanner.Attivo
		Get
			Return _Attivo
		End Get
		Set (byval value as Boolean)
			If _Attivo <> value Then
				IsChanged = True
				WhatIsChanged.Attivo = True
				_Attivo = value
			End If
		End Set
	End property 

	Protected _Path as string  = "" 
	Public Overridable Property Path() as string  Implements _IBanner.Path
		Get
			Return _Path
		End Get
		Set (byval value as string)
			If _Path <> value Then
				IsChanged = True
				WhatIsChanged.Path = True
				_Path = value
			End If
		End Set
	End property 

	Protected _Url as string  = "" 
	Public Overridable Property Url() as string  Implements _IBanner.Url
		Get
			Return _Url
		End Get
		Set (byval value as string)
			If _Url <> value Then
				IsChanged = True
				WhatIsChanged.Url = True
				_Url = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Banner from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Banner = Manager.Read(Id)
				_IdBanner = int.IdBanner
				_Alt = int.Alt
				_Attivo = int.Attivo
				_Path = int.Path
				_Url = int.Url
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Banner on DB.
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
  
		if _Alt.Length = 0 then Ris = False
		if _Alt.Length > 255 then Ris = False
  
		if _Path.Length = 0 then Ris = False
		if _Path.Length > 255 then Ris = False
  
		if _Url.Length = 0 then Ris = False
		if _Url.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Banner
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IBanner

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdBanner() as integer
	Property Alt() as string
	Property Attivo() as Boolean
	Property Path() as string
	Property Url() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Banner
		Public Shared ReadOnly Property IdBanner As New LUNA.LunaFieldName("IdBanner")
		Public Shared ReadOnly Property Alt As New LUNA.LunaFieldName("Alt")
		Public Shared ReadOnly Property Attivo As New LUNA.LunaFieldName("Attivo")
		Public Shared ReadOnly Property Path As New LUNA.LunaFieldName("Path")
		Public Shared ReadOnly Property Url As New LUNA.LunaFieldName("Url")
	End Class

End Class