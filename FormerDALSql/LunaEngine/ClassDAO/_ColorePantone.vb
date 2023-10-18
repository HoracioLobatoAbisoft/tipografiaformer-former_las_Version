#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 29/12/2017 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_pantone
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ColorePantone
	Inherits LUNA.LunaBaseClassEntity
	Implements _IColorePantone
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IColorePantone.FillFromDataRecord
		IDPantone = myRecord("IDPantone")
		if not myRecord("B") is DBNull.Value then B = myRecord("B")
		if not myRecord("Codice") is DBNull.Value then Codice = myRecord("Codice")
		if not myRecord("G") is DBNull.Value then G = myRecord("G")
		if not myRecord("HtmlCode") is DBNull.Value then HtmlCode = myRecord("HtmlCode")
		if not myRecord("R") is DBNull.Value then R = myRecord("R")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ColorePantone)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ColoriPantoneDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ColorePantone))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDPantone As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property B As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property G As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property HtmlCode As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property R As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDPantone = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.B = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.G = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.HtmlCode = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.R = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDPantone as integer  = 0 
	Public Overridable Property IDPantone() as integer  Implements _IColorePantone.IDPantone
		Get
			Return _IDPantone
		End Get
		Set (byval value as integer)
			If _IDPantone <> value Then
				IsChanged = True
				WhatIsChanged.IDPantone = True
				_IDPantone = value
			End If
		End Set
	End property 

	Protected _B as integer  = 0 
	Public Overridable Property B() as integer  Implements _IColorePantone.B
		Get
			Return _B
		End Get
		Set (byval value as integer)
			If _B <> value Then
				IsChanged = True
				WhatIsChanged.B = True
				_B = value
			End If
		End Set
	End property 

	Protected _Codice as string  = "" 
	Public Overridable Property Codice() as string  Implements _IColorePantone.Codice
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

	Protected _G as integer  = 0 
	Public Overridable Property G() as integer  Implements _IColorePantone.G
		Get
			Return _G
		End Get
		Set (byval value as integer)
			If _G <> value Then
				IsChanged = True
				WhatIsChanged.G = True
				_G = value
			End If
		End Set
	End property 

	Protected _HtmlCode as string  = "" 
	Public Overridable Property HtmlCode() as string  Implements _IColorePantone.HtmlCode
		Get
			Return _HtmlCode
		End Get
		Set (byval value as string)
			If _HtmlCode <> value Then
				IsChanged = True
				WhatIsChanged.HtmlCode = True
				_HtmlCode = value
			End If
		End Set
	End property 

	Protected _R as integer  = 0 
	Public Overridable Property R() as integer  Implements _IColorePantone.R
		Get
			Return _R
		End Get
		Set (byval value as integer)
			If _R <> value Then
				IsChanged = True
				WhatIsChanged.R = True
				_R = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ColorePantone from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ColorePantone = Manager.Read(Id)
				_IDPantone = int.IDPantone
				_B = int.B
				_Codice = int.Codice
				_G = int.G
				_HtmlCode = int.HtmlCode
				_R = int.R
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ColorePantone on DB.
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
		if _HtmlCode.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_pantone
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IColorePantone

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDPantone() as integer
	Property B() as integer
	Property Codice() as string
	Property G() as integer
	Property HtmlCode() as string
	Property R() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ColorePantone
		Public Shared ReadOnly Property IDPantone As New LUNA.LunaFieldName("IDPantone")
		Public Shared ReadOnly Property B As New LUNA.LunaFieldName("B")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property G As New LUNA.LunaFieldName("G")
		Public Shared ReadOnly Property HtmlCode As New LUNA.LunaFieldName("HtmlCode")
		Public Shared ReadOnly Property R As New LUNA.LunaFieldName("R")
	End Class

End Class