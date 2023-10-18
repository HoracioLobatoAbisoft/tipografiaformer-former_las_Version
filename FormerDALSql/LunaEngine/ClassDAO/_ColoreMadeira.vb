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
'''DAO Class for table T_madeira
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ColoreMadeira
	Inherits LUNA.LunaBaseClassEntity
	Implements _IColoreMadeira
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IColoreMadeira.FillFromDataRecord
		IdMadeira = myRecord("IdMadeira")
		if not myRecord("Attivo") is DBNull.Value then Attivo = myRecord("Attivo")
		if not myRecord("CodiceMadeira") is DBNull.Value then CodiceMadeira = myRecord("CodiceMadeira")
		if not myRecord("CostoMillePunti") is DBNull.Value then CostoMillePunti = myRecord("CostoMillePunti")
		if not myRecord("IdPantone") is DBNull.Value then IdPantone = myRecord("IdPantone")
		if not myRecord("IdTavolozza") is DBNull.Value then IdTavolozza = myRecord("IdTavolozza")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ColoreMadeira)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ColoriMadeiraDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ColoreMadeira))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdMadeira As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Attivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CodiceMadeira As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoMillePunti As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPantone As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTavolozza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdMadeira = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Attivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CodiceMadeira = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoMillePunti = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPantone = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTavolozza = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdMadeira as integer  = 0 
	Public Overridable Property IdMadeira() as integer  Implements _IColoreMadeira.IdMadeira
		Get
			Return _IdMadeira
		End Get
		Set (byval value as integer)
			If _IdMadeira <> value Then
				IsChanged = True
				WhatIsChanged.IdMadeira = True
				_IdMadeira = value
			End If
		End Set
	End property 

	Protected _Attivo as integer  = 0 
	Public Overridable Property Attivo() as integer  Implements _IColoreMadeira.Attivo
		Get
			Return _Attivo
		End Get
		Set (byval value as integer)
			If _Attivo <> value Then
				IsChanged = True
				WhatIsChanged.Attivo = True
				_Attivo = value
			End If
		End Set
	End property 

	Protected _CodiceMadeira as string  = "" 
	Public Overridable Property CodiceMadeira() as string  Implements _IColoreMadeira.CodiceMadeira
		Get
			Return _CodiceMadeira
		End Get
		Set (byval value as string)
			If _CodiceMadeira <> value Then
				IsChanged = True
				WhatIsChanged.CodiceMadeira = True
				_CodiceMadeira = value
			End If
		End Set
	End property 

	Protected _CostoMillePunti as Single  = 0 
	Public Overridable Property CostoMillePunti() as Single  Implements _IColoreMadeira.CostoMillePunti
		Get
			Return _CostoMillePunti
		End Get
		Set (byval value as Single)
			If _CostoMillePunti <> value Then
				IsChanged = True
				WhatIsChanged.CostoMillePunti = True
				_CostoMillePunti = value
			End If
		End Set
	End property 

	Protected _IdPantone as integer  = 0 
	Public Overridable Property IdPantone() as integer  Implements _IColoreMadeira.IdPantone
		Get
			Return _IdPantone
		End Get
		Set (byval value as integer)
			If _IdPantone <> value Then
				IsChanged = True
				WhatIsChanged.IdPantone = True
				_IdPantone = value
			End If
		End Set
	End property 

	Protected _IdTavolozza as integer  = 0 
	Public Overridable Property IdTavolozza() as integer  Implements _IColoreMadeira.IdTavolozza
		Get
			Return _IdTavolozza
		End Get
		Set (byval value as integer)
			If _IdTavolozza <> value Then
				IsChanged = True
				WhatIsChanged.IdTavolozza = True
				_IdTavolozza = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ColoreMadeira from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ColoreMadeira = Manager.Read(Id)
				_IdMadeira = int.IdMadeira
				_Attivo = int.Attivo
				_CodiceMadeira = int.CodiceMadeira
				_CostoMillePunti = int.CostoMillePunti
				_IdPantone = int.IdPantone
				_IdTavolozza = int.IdTavolozza
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ColoreMadeira on DB.
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
		if _CodiceMadeira.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_madeira
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IColoreMadeira

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdMadeira() as integer
	Property Attivo() as integer
	Property CodiceMadeira() as string
	Property CostoMillePunti() as Single
	Property IdPantone() as integer
	Property IdTavolozza() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ColoreMadeira
		Public Shared ReadOnly Property IdMadeira As New LUNA.LunaFieldName("IdMadeira")
		Public Shared ReadOnly Property Attivo As New LUNA.LunaFieldName("Attivo")
		Public Shared ReadOnly Property CodiceMadeira As New LUNA.LunaFieldName("CodiceMadeira")
		Public Shared ReadOnly Property CostoMillePunti As New LUNA.LunaFieldName("CostoMillePunti")
		Public Shared ReadOnly Property IdPantone As New LUNA.LunaFieldName("IdPantone")
		Public Shared ReadOnly Property IdTavolozza As New LUNA.LunaFieldName("IdTavolozza")
	End Class

End Class