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
'''DAO Class for table Td_catmodelli
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CategoriaModelloCommessa
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICategoriaModelloCommessa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICategoriaModelloCommessa.FillFromDataRecord
		IdCatModello = myRecord("IdCatModello")
		if not myRecord("CatModello") is DBNull.Value then CatModello = myRecord("CatModello")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CategoriaModelloCommessa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CatModelliDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CategoriaModelloCommessa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCatModello As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CatModello As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCatModello = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CatModello = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCatModello as integer  = 0 
	Public Overridable Property IdCatModello() as integer  Implements _ICategoriaModelloCommessa.IdCatModello
		Get
			Return _IdCatModello
		End Get
		Set (byval value as integer)
			If _IdCatModello <> value Then
				IsChanged = True
				WhatIsChanged.IdCatModello = True
				_IdCatModello = value
			End If
		End Set
	End property 

	Protected _CatModello as string  = "" 
	Public Overridable Property CatModello() as string  Implements _ICategoriaModelloCommessa.CatModello
		Get
			Return _CatModello
		End Get
		Set (byval value as string)
			If _CatModello <> value Then
				IsChanged = True
				WhatIsChanged.CatModello = True
				_CatModello = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CategoriaModelloCommessa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CategoriaModelloCommessa = Manager.Read(Id)
				_IdCatModello = int.IdCatModello
				_CatModello = int.CatModello
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CategoriaModelloCommessa on DB.
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
		if _CatModello.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_catmodelli
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICategoriaModelloCommessa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCatModello() as integer
	Property CatModello() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class CategoriaModelloCommessa
		Public Shared ReadOnly Property IdCatModello As New LUNA.LunaFieldName("IdCatModello")
		Public Shared ReadOnly Property CatModello As New LUNA.LunaFieldName("CatModello")
	End Class

End Class