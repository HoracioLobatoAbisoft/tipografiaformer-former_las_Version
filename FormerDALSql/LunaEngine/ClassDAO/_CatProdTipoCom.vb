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
'''DAO Class for table Tr_catprodtipocom
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CatProdTipoCom
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICatProdTipoCom
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICatProdTipoCom.FillFromDataRecord
		IdCatPTipoCom = myRecord("IdCatPTipoCom")
		if not myRecord("IdCatProd") is DBNull.Value then IdCatProd = myRecord("IdCatProd")
		if not myRecord("IdTipoCom") is DBNull.Value then IdTipoCom = myRecord("IdTipoCom")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CatProdTipoCom)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CatProdTipoComDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CatProdTipoCom))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCatPTipoCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCatPTipoCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoCom = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCatPTipoCom as integer  = 0 
	Public Overridable Property IdCatPTipoCom() as integer  Implements _ICatProdTipoCom.IdCatPTipoCom
		Get
			Return _IdCatPTipoCom
		End Get
		Set (byval value as integer)
			If _IdCatPTipoCom <> value Then
				IsChanged = True
				WhatIsChanged.IdCatPTipoCom = True
				_IdCatPTipoCom = value
			End If
		End Set
	End property 

	Protected _IdCatProd as integer  = 0 
	Public Overridable Property IdCatProd() as integer  Implements _ICatProdTipoCom.IdCatProd
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

	Protected _IdTipoCom as integer  = 0 
	Public Overridable Property IdTipoCom() as integer  Implements _ICatProdTipoCom.IdTipoCom
		Get
			Return _IdTipoCom
		End Get
		Set (byval value as integer)
			If _IdTipoCom <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoCom = True
				_IdTipoCom = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CatProdTipoCom from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CatProdTipoCom = Manager.Read(Id)
				_IdCatPTipoCom = int.IdCatPTipoCom
				_IdCatProd = int.IdCatProd
				_IdTipoCom = int.IdTipoCom
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CatProdTipoCom on DB.
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
'''Interface for table Tr_catprodtipocom
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICatProdTipoCom

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCatPTipoCom() as integer
	Property IdCatProd() as integer
	Property IdTipoCom() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CatProdTipoCom
		Public Shared ReadOnly Property IdCatPTipoCom As New LUNA.LunaFieldName("IdCatPTipoCom")
		Public Shared ReadOnly Property IdCatProd As New LUNA.LunaFieldName("IdCatProd")
		Public Shared ReadOnly Property IdTipoCom As New LUNA.LunaFieldName("IdTipoCom")
	End Class

End Class