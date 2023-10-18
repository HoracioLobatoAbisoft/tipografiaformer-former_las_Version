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
'''DAO Class for table Td_catfustelle
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CategoriaFustella
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICategoriaFustella
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICategoriaFustella.FillFromDataRecord
		IdCatFustella = myRecord("IdCatFustella")
		if not myRecord("Anima") is DBNull.Value then Anima = myRecord("Anima")
		Categoria = myRecord("Categoria")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("ImgRif") is DBNull.Value then ImgRif = myRecord("ImgRif")
		if not myRecord("LarghezzaMax") is DBNull.Value then LarghezzaMax = myRecord("LarghezzaMax")
		if not myRecord("TipoForma") is DBNull.Value then TipoForma = myRecord("TipoForma")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CategoriaFustella)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CategorieFustelleDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CategoriaFustella))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCatFustella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Anima As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Categoria As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LarghezzaMax As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoForma As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCatFustella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Anima = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Categoria = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LarghezzaMax = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoForma = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCatFustella as integer  = 0 
	Public Overridable Property IdCatFustella() as integer  Implements _ICategoriaFustella.IdCatFustella
		Get
			Return _IdCatFustella
		End Get
		Set (byval value as integer)
			If _IdCatFustella <> value Then
				IsChanged = True
				WhatIsChanged.IdCatFustella = True
				_IdCatFustella = value
			End If
		End Set
	End property 

	Protected _Anima as integer  = 0 
	Public Overridable Property Anima() as integer  Implements _ICategoriaFustella.Anima
		Get
			Return _Anima
		End Get
		Set (byval value as integer)
			If _Anima <> value Then
				IsChanged = True
				WhatIsChanged.Anima = True
				_Anima = value
			End If
		End Set
	End property 

	Protected _Categoria as string  = "" 
	Public Overridable Property Categoria() as string  Implements _ICategoriaFustella.Categoria
		Get
			Return _Categoria
		End Get
		Set (byval value as string)
			If _Categoria <> value Then
				IsChanged = True
				WhatIsChanged.Categoria = True
				_Categoria = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _ICategoriaFustella.Descrizione
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

	Protected _ImgRif as string  = "" 
	Public Overridable Property ImgRif() as string  Implements _ICategoriaFustella.ImgRif
		Get
			Return _ImgRif
		End Get
		Set (byval value as string)
			If _ImgRif <> value Then
				IsChanged = True
				WhatIsChanged.ImgRif = True
				_ImgRif = value
			End If
		End Set
	End property 

	Protected _LarghezzaMax as integer  = 0 
	Public Overridable Property LarghezzaMax() as integer  Implements _ICategoriaFustella.LarghezzaMax
		Get
			Return _LarghezzaMax
		End Get
		Set (byval value as integer)
			If _LarghezzaMax <> value Then
				IsChanged = True
				WhatIsChanged.LarghezzaMax = True
				_LarghezzaMax = value
			End If
		End Set
	End property 

	Protected _TipoForma as integer  = 0 
	Public Overridable Property TipoForma() as integer  Implements _ICategoriaFustella.TipoForma
		Get
			Return _TipoForma
		End Get
		Set (byval value as integer)
			If _TipoForma <> value Then
				IsChanged = True
				WhatIsChanged.TipoForma = True
				_TipoForma = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CategoriaFustella from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CategoriaFustella = Manager.Read(Id)
				_IdCatFustella = int.IdCatFustella
				_Anima = int.Anima
				_Categoria = int.Categoria
				_Descrizione = int.Descrizione
				_ImgRif = int.ImgRif
				_LarghezzaMax = int.LarghezzaMax
				_TipoForma = int.TipoForma
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CategoriaFustella on DB.
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
  
		if _Categoria.Length = 0 then Ris = False
		if _Categoria.Length > 255 then Ris = False
		if _Descrizione.Length > 1000 then Ris = False
		if _ImgRif.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_catfustelle
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICategoriaFustella

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCatFustella() as integer
	Property Anima() as integer
	Property Categoria() as string
	Property Descrizione() as string
	Property ImgRif() as string
	Property LarghezzaMax() as integer
	Property TipoForma() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CategoriaFustella
		Public Shared ReadOnly Property IdCatFustella As New LUNA.LunaFieldName("IdCatFustella")
		Public Shared ReadOnly Property Anima As New LUNA.LunaFieldName("Anima")
		Public Shared ReadOnly Property Categoria As New LUNA.LunaFieldName("Categoria")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property ImgRif As New LUNA.LunaFieldName("ImgRif")
		Public Shared ReadOnly Property LarghezzaMax As New LUNA.LunaFieldName("LarghezzaMax")
		Public Shared ReadOnly Property TipoForma As New LUNA.LunaFieldName("TipoForma")
	End Class

End Class