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
'''DAO Class for table Tr_catcarat
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CatCarat
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICatCarat
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICatCarat.FillFromDataRecord
		IdCatCarat = myRecord("IdCatCarat")
		if not myRecord("IdCaratProd") is DBNull.Value then IdCaratProd = myRecord("IdCaratProd")
		if not myRecord("IdCatProd") is DBNull.Value then IdCatProd = myRecord("IdCatProd")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CatCarat)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CatCaratDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CatCarat))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCatCarat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCaratProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCatCarat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCaratProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatProd = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCatCarat as integer  = 0 
	Public Overridable Property IdCatCarat() as integer  Implements _ICatCarat.IdCatCarat
		Get
			Return _IdCatCarat
		End Get
		Set (byval value as integer)
			If _IdCatCarat <> value Then
				IsChanged = True
				WhatIsChanged.IdCatCarat = True
				_IdCatCarat = value
			End If
		End Set
	End property 

	Protected _IdCaratProd as integer  = 0 
	Public Overridable Property IdCaratProd() as integer  Implements _ICatCarat.IdCaratProd
		Get
			Return _IdCaratProd
		End Get
		Set (byval value as integer)
			If _IdCaratProd <> value Then
				IsChanged = True
				WhatIsChanged.IdCaratProd = True
				_IdCaratProd = value
			End If
		End Set
	End property 

	Protected _IdCatProd as integer  = 0 
	Public Overridable Property IdCatProd() as integer  Implements _ICatCarat.IdCatProd
		Get
			Return _IdCatProd
		End Get
		Set (byval value as integer)
			If _IdCatProd <> value Then
				IsChanged = True
				WhatIsChanged.IdCatProd = True
				_IdCatProd = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CatCarat from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CatCarat = Manager.Read(Id)
				_IdCatCarat = int.IdCatCarat
				_IdCaratProd = int.IdCaratProd
				_IdCatProd = int.IdCatProd
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CatCarat on DB.
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
'''Interface for table Tr_catcarat
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICatCarat

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCatCarat() as integer
	Property IdCaratProd() as integer
	Property IdCatProd() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CatCarat
		Public Shared ReadOnly Property IdCatCarat As New LUNA.LunaFieldName("IdCatCarat")
		Public Shared ReadOnly Property IdCaratProd As New LUNA.LunaFieldName("IdCaratProd")
		Public Shared ReadOnly Property IdCatProd As New LUNA.LunaFieldName("IdCatProd")
	End Class

End Class