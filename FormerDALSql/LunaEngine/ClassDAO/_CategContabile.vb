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
'''DAO Class for table Td_catcontab
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CategContabile
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICategContabile
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICategContabile.FillFromDataRecord
		IdCatContab = myRecord("IdCatContab")
		if not myRecord("NomeCat") is DBNull.Value then NomeCat = myRecord("NomeCat")
		if not myRecord("TipoCat") is DBNull.Value then TipoCat = myRecord("TipoCat")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CategContabile)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CategContabiliDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CategContabile))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCatContab As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeCat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoCat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCatContab = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeCat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoCat = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCatContab as integer  = 0 
	Public Overridable Property IdCatContab() as integer  Implements _ICategContabile.IdCatContab
		Get
			Return _IdCatContab
		End Get
		Set (byval value as integer)
			If _IdCatContab <> value Then
				IsChanged = True
				WhatIsChanged.IdCatContab = True
				_IdCatContab = value
			End If
		End Set
	End property 

	Protected _NomeCat as string  = "" 
	Public Overridable Property NomeCat() as string  Implements _ICategContabile.NomeCat
		Get
			Return _NomeCat
		End Get
		Set (byval value as string)
			If _NomeCat <> value Then
				IsChanged = True
				WhatIsChanged.NomeCat = True
				_NomeCat = value
			End If
		End Set
	End property 

	Protected _TipoCat as integer  = 0 
	Public Overridable Property TipoCat() as integer  Implements _ICategContabile.TipoCat
		Get
			Return _TipoCat
		End Get
		Set (byval value as integer)
			If _TipoCat <> value Then
				IsChanged = True
				WhatIsChanged.TipoCat = True
				_TipoCat = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CategContabile from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CategContabile = Manager.Read(Id)
				_IdCatContab = int.IdCatContab
				_NomeCat = int.NomeCat
				_TipoCat = int.TipoCat
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CategContabile on DB.
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
		if _NomeCat.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_catcontab
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICategContabile

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCatContab() as integer
	Property NomeCat() as string
	Property TipoCat() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CategContabile
		Public Shared ReadOnly Property IdCatContab As New LUNA.LunaFieldName("IdCatContab")
		Public Shared ReadOnly Property NomeCat As New LUNA.LunaFieldName("NomeCat")
		Public Shared ReadOnly Property TipoCat As New LUNA.LunaFieldName("TipoCat")
	End Class

End Class