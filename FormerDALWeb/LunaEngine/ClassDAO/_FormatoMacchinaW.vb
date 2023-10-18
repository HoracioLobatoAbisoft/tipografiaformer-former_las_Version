#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Td_formato
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FormatoMacchinaW
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFormatoMacchinaW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFormatoMacchinaW.FillFromDataRecord
		IdFormato = myRecord("IdFormato")
		if not myRecord("Altezza") is DBNull.Value then Altezza = myRecord("Altezza")
		if not myRecord("CostoLastra") is DBNull.Value then CostoLastra = myRecord("CostoLastra")
		if not myRecord("DivisioneFoglio") is DBNull.Value then DivisioneFoglio = myRecord("DivisioneFoglio")
		if not myRecord("Formato") is DBNull.Value then Formato = myRecord("Formato")
		if not myRecord("IdMacchinario") is DBNull.Value then IdMacchinario = myRecord("IdMacchinario")
		if not myRecord("ImgRif") is DBNull.Value then ImgRif = myRecord("ImgRif")
		if not myRecord("Larghezza") is DBNull.Value then Larghezza = myRecord("Larghezza")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FormatoMacchinaW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FormatiMacchinaWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FormatoMacchinaW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdFormato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Altezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoLastra As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DivisioneFoglio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Formato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Larghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdFormato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Altezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoLastra = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DivisioneFoglio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Formato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Larghezza = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdFormato as integer  = 0 
	Public Overridable Property IdFormato() as integer  Implements _IFormatoMacchinaW.IdFormato
		Get
			Return _IdFormato
		End Get
		Set (byval value as integer)
			If _IdFormato <> value Then
				IsChanged = True
				WhatIsChanged.IdFormato = True
				_IdFormato = value
			End If
		End Set
	End property 

	Protected _Altezza as integer  = 0 
	Public Overridable Property Altezza() as integer  Implements _IFormatoMacchinaW.Altezza
		Get
			Return _Altezza
		End Get
		Set (byval value as integer)
			If _Altezza <> value Then
				IsChanged = True
				WhatIsChanged.Altezza = True
				_Altezza = value
			End If
		End Set
	End property 

	Protected _CostoLastra as decimal  = 0 
	Public Overridable Property CostoLastra() as decimal  Implements _IFormatoMacchinaW.CostoLastra
		Get
			Return _CostoLastra
		End Get
		Set (byval value as decimal)
			If _CostoLastra <> value Then
				IsChanged = True
				WhatIsChanged.CostoLastra = True
				_CostoLastra = value
			End If
		End Set
	End property 

	Protected _DivisioneFoglio as integer  = 0 
	Public Overridable Property DivisioneFoglio() as integer  Implements _IFormatoMacchinaW.DivisioneFoglio
		Get
			Return _DivisioneFoglio
		End Get
		Set (byval value as integer)
			If _DivisioneFoglio <> value Then
				IsChanged = True
				WhatIsChanged.DivisioneFoglio = True
				_DivisioneFoglio = value
			End If
		End Set
	End property 

	Protected _Formato as string  = "" 
	Public Overridable Property Formato() as string  Implements _IFormatoMacchinaW.Formato
		Get
			Return _Formato
		End Get
		Set (byval value as string)
			If _Formato <> value Then
				IsChanged = True
				WhatIsChanged.Formato = True
				_Formato = value
			End If
		End Set
	End property 

	Protected _IdMacchinario as integer  = 0 
	Public Overridable Property IdMacchinario() as integer  Implements _IFormatoMacchinaW.IdMacchinario
		Get
			Return _IdMacchinario
		End Get
		Set (byval value as integer)
			If _IdMacchinario <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinario = True
				_IdMacchinario = value
			End If
		End Set
	End property 

	Protected _ImgRif as string  = "" 
	Public Overridable Property ImgRif() as string  Implements _IFormatoMacchinaW.ImgRif
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

	Protected _Larghezza as integer  = 0 
	Public Overridable Property Larghezza() as integer  Implements _IFormatoMacchinaW.Larghezza
		Get
			Return _Larghezza
		End Get
		Set (byval value as integer)
			If _Larghezza <> value Then
				IsChanged = True
				WhatIsChanged.Larghezza = True
				_Larghezza = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FormatoMacchinaW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FormatoMacchinaW = Manager.Read(Id)
				_IdFormato = int.IdFormato
				_Altezza = int.Altezza
				_CostoLastra = int.CostoLastra
				_DivisioneFoglio = int.DivisioneFoglio
				_Formato = int.Formato
				_IdMacchinario = int.IdMacchinario
				_ImgRif = int.ImgRif
				_Larghezza = int.Larghezza
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an FormatoMacchinaW on DB.
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
		if _Formato.Length > 50 then Ris = False
		if _ImgRif.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_formato
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFormatoMacchinaW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdFormato() as integer
	Property Altezza() as integer
	Property CostoLastra() as decimal
	Property DivisioneFoglio() as integer
	Property Formato() as string
	Property IdMacchinario() as integer
	Property ImgRif() as string
	Property Larghezza() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class FormatoMacchinaW
		Public Shared ReadOnly Property IdFormato As New LUNA.LunaFieldName("IdFormato")
		Public Shared ReadOnly Property Altezza As New LUNA.LunaFieldName("Altezza")
		Public Shared ReadOnly Property CostoLastra As New LUNA.LunaFieldName("CostoLastra")
		Public Shared ReadOnly Property DivisioneFoglio As New LUNA.LunaFieldName("DivisioneFoglio")
		Public Shared ReadOnly Property Formato As New LUNA.LunaFieldName("Formato")
		Public Shared ReadOnly Property IdMacchinario As New LUNA.LunaFieldName("IdMacchinario")
		Public Shared ReadOnly Property ImgRif As New LUNA.LunaFieldName("ImgRif")
		Public Shared ReadOnly Property Larghezza As New LUNA.LunaFieldName("Larghezza")
	End Class

End Class