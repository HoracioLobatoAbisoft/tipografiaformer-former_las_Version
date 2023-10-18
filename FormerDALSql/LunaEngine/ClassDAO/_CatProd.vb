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
'''DAO Class for table Td_catprod
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CatProd
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICatProd
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICatProd.FillFromDataRecord
		IdCatProd = myRecord("IdCatProd")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("DescrizioneLunga") is DBNull.Value then DescrizioneLunga = myRecord("DescrizioneLunga")
		if not myRecord("IdCatPadre") is DBNull.Value then IdCatPadre = myRecord("IdCatPadre")
		if not myRecord("ImgCat") is DBNull.Value then ImgCat = myRecord("ImgCat")
		if not myRecord("PercPubblico") is DBNull.Value then PercPubblico = myRecord("PercPubblico")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CatProd)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CatProdDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CatProd))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCatProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrizioneLunga As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatPadre As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgCat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercPubblico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCatProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrizioneLunga = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatPadre = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgCat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercPubblico = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCatProd as integer  = 0 
	Public Overridable Property IdCatProd() as integer  Implements _ICatProd.IdCatProd
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

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _ICatProd.Descrizione
		Get
			Return _Descrizione
		End Get
		Set (byval value as string)
			If _Descrizione <> value Then
				IsChanged = True
				WhatIsChanged.Descrizione = True
				_Descrizione = value
			End If
		End Set
	End property 

	Protected _DescrizioneLunga as string  = "" 
	Public Overridable Property DescrizioneLunga() as string  Implements _ICatProd.DescrizioneLunga
		Get
			Return _DescrizioneLunga
		End Get
		Set (byval value as string)
			If _DescrizioneLunga <> value Then
				IsChanged = True
				WhatIsChanged.DescrizioneLunga = True
				_DescrizioneLunga = value
			End If
		End Set
	End property 

	Protected _IdCatPadre as integer  = 0 
	Public Overridable Property IdCatPadre() as integer  Implements _ICatProd.IdCatPadre
		Get
			Return _IdCatPadre
		End Get
		Set (byval value as integer)
			If _IdCatPadre <> value Then
				IsChanged = True
				WhatIsChanged.IdCatPadre = True
				_IdCatPadre = value
			End If
		End Set
	End property 

	Protected _ImgCat as string  = "" 
	Public Overridable Property ImgCat() as string  Implements _ICatProd.ImgCat
		Get
			Return _ImgCat
		End Get
		Set (byval value as string)
			If _ImgCat <> value Then
				IsChanged = True
				WhatIsChanged.ImgCat = True
				_ImgCat = value
			End If
		End Set
	End property 

	Protected _PercPubblico as integer  = 0 
	Public Overridable Property PercPubblico() as integer  Implements _ICatProd.PercPubblico
		Get
			Return _PercPubblico
		End Get
		Set (byval value as integer)
			If _PercPubblico <> value Then
				IsChanged = True
				WhatIsChanged.PercPubblico = True
				_PercPubblico = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CatProd from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CatProd = Manager.Read(Id)
				_IdCatProd = int.IdCatProd
				_Descrizione = int.Descrizione
				_DescrizioneLunga = int.DescrizioneLunga
				_IdCatPadre = int.IdCatPadre
				_ImgCat = int.ImgCat
				_PercPubblico = int.PercPubblico
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CatProd on DB.
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
		if _Descrizione.Length > 50 then Ris = False
		if _DescrizioneLunga.Length > 255 then Ris = False
		if _ImgCat.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_catprod
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICatProd

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCatProd() as integer
	Property Descrizione() as string
	Property DescrizioneLunga() as string
	Property IdCatPadre() as integer
	Property ImgCat() as string
	Property PercPubblico() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CatProd
		Public Shared ReadOnly Property IdCatProd As New LUNA.LunaFieldName("IdCatProd")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property DescrizioneLunga As New LUNA.LunaFieldName("DescrizioneLunga")
		Public Shared ReadOnly Property IdCatPadre As New LUNA.LunaFieldName("IdCatPadre")
		Public Shared ReadOnly Property ImgCat As New LUNA.LunaFieldName("ImgCat")
		Public Shared ReadOnly Property PercPubblico As New LUNA.LunaFieldName("PercPubblico")
	End Class

End Class