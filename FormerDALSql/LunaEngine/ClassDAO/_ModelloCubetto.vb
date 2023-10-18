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
'''DAO Class for table Modellicubetti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ModelloCubetto
	Inherits LUNA.LunaBaseClassEntity
	Implements _IModelloCubetto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IModelloCubetto.FillFromDataRecord
		IDModelloCubetto = myRecord("IDModelloCubetto")
		if not myRecord("Larghezza") is DBNull.Value then Larghezza = myRecord("Larghezza")
		if not myRecord("Lunghezza") is DBNull.Value then Lunghezza = myRecord("Lunghezza")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("Profondita") is DBNull.Value then Profondita = myRecord("Profondita")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ModelloCubetto)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ModelliCubettiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ModelloCubetto))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDModelloCubetto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Larghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Lunghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Profondita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDModelloCubetto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Larghezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Lunghezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Profondita = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDModelloCubetto as integer  = 0 
	Public Overridable Property IDModelloCubetto() as integer  Implements _IModelloCubetto.IDModelloCubetto
		Get
			Return _IDModelloCubetto
		End Get
		Set (byval value as integer)
			If _IDModelloCubetto <> value Then
				IsChanged = True
				WhatIsChanged.IDModelloCubetto = True
				_IDModelloCubetto = value
			End If
		End Set
	End property 

	Protected _Larghezza as integer  = 0 
	Public Overridable Property Larghezza() as integer  Implements _IModelloCubetto.Larghezza
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

	Protected _Lunghezza as integer  = 0 
	Public Overridable Property Lunghezza() as integer  Implements _IModelloCubetto.Lunghezza
		Get
			Return _Lunghezza
		End Get
		Set (byval value as integer)
			If _Lunghezza <> value Then
				IsChanged = True
				WhatIsChanged.Lunghezza = True
				_Lunghezza = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IModelloCubetto.Nome
		Get
			Return _Nome
		End Get
		Set (byval value as string)
			If _Nome <> value Then
				IsChanged = True
				WhatIsChanged.Nome = True
				_Nome = value
			End If
		End Set
	End property 

	Protected _Profondita as integer  = 0 
	Public Overridable Property Profondita() as integer  Implements _IModelloCubetto.Profondita
		Get
			Return _Profondita
		End Get
		Set (byval value as integer)
			If _Profondita <> value Then
				IsChanged = True
				WhatIsChanged.Profondita = True
				_Profondita = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ModelloCubetto from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ModelloCubetto = Manager.Read(Id)
				_IDModelloCubetto = int.IDModelloCubetto
				_Larghezza = int.Larghezza
				_Lunghezza = int.Lunghezza
				_Nome = int.Nome
				_Profondita = int.Profondita
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ModelloCubetto on DB.
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
		if _Nome.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Modellicubetti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IModelloCubetto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDModelloCubetto() as integer
	Property Larghezza() as integer
	Property Lunghezza() as integer
	Property Nome() as string
	Property Profondita() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ModelloCubetto
		Public Shared ReadOnly Property IDModelloCubetto As New LUNA.LunaFieldName("IDModelloCubetto")
		Public Shared ReadOnly Property Larghezza As New LUNA.LunaFieldName("Larghezza")
		Public Shared ReadOnly Property Lunghezza As New LUNA.LunaFieldName("Lunghezza")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property Profondita As New LUNA.LunaFieldName("Profondita")
	End Class

End Class