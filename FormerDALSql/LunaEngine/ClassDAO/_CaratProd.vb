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
'''DAO Class for table Td_caratprod
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CaratProd
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICaratProd
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICaratProd.FillFromDataRecord
		IDCaratProd = myRecord("IDCaratProd")
		if not myRecord("ImgCarat") is DBNull.Value then ImgCarat = myRecord("ImgCarat")
		if not myRecord("NomeCarat") is DBNull.Value then NomeCarat = myRecord("NomeCarat")
		if not myRecord("Width") is DBNull.Value then Width = myRecord("Width")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CaratProd)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CaratProdDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CaratProd))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDCaratProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgCarat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeCarat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Width As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDCaratProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgCarat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeCarat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Width = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDCaratProd as integer  = 0 
	Public Overridable Property IDCaratProd() as integer  Implements _ICaratProd.IDCaratProd
		Get
			Return _IDCaratProd
		End Get
		Set (byval value as integer)
			If _IDCaratProd <> value Then
				IsChanged = True
				WhatIsChanged.IDCaratProd = True
				_IDCaratProd = value
			End If
		End Set
	End property 

	Protected _ImgCarat as string  = "" 
	Public Overridable Property ImgCarat() as string  Implements _ICaratProd.ImgCarat
		Get
			Return _ImgCarat
		End Get
		Set (byval value as string)
			If _ImgCarat <> value Then
				IsChanged = True
				WhatIsChanged.ImgCarat = True
				_ImgCarat = value
			End If
		End Set
	End property 

	Protected _NomeCarat as string  = "" 
	Public Overridable Property NomeCarat() as string  Implements _ICaratProd.NomeCarat
		Get
			Return _NomeCarat
		End Get
		Set (byval value as string)
			If _NomeCarat <> value Then
				IsChanged = True
				WhatIsChanged.NomeCarat = True
				_NomeCarat = value
			End If
		End Set
	End property 

	Protected _Width as integer  = 0 
	Public Overridable Property Width() as integer  Implements _ICaratProd.Width
		Get
			Return _Width
		End Get
		Set (byval value as integer)
			If _Width <> value Then
				IsChanged = True
				WhatIsChanged.Width = True
				_Width = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CaratProd from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CaratProd = Manager.Read(Id)
				_IDCaratProd = int.IDCaratProd
				_ImgCarat = int.ImgCarat
				_NomeCarat = int.NomeCarat
				_Width = int.Width
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CaratProd on DB.
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
		if _ImgCarat.Length > 255 then Ris = False
		if _NomeCarat.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_caratprod
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICaratProd

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDCaratProd() as integer
	Property ImgCarat() as string
	Property NomeCarat() as string
	Property Width() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CaratProd
		Public Shared ReadOnly Property IDCaratProd As New LUNA.LunaFieldName("IDCaratProd")
		Public Shared ReadOnly Property ImgCarat As New LUNA.LunaFieldName("ImgCarat")
		Public Shared ReadOnly Property NomeCarat As New LUNA.LunaFieldName("NomeCarat")
		Public Shared ReadOnly Property Width As New LUNA.LunaFieldName("Width")
	End Class

End Class