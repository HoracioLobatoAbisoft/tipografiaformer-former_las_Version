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
'''DAO Class for table Regioni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Regione
	Inherits LUNA.LunaBaseClassEntity
	Implements _IRegione
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IRegione.FillFromDataRecord
		ID = myRecord("ID")
		if not myRecord("CODAREA") is DBNull.Value then CODAREA = myRecord("CODAREA")
		if not myRecord("ordine") is DBNull.Value then ordine = myRecord("ordine")
		if not myRecord("REGIONE") is DBNull.Value then REGIONE = myRecord("REGIONE")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Regione)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(RegioniDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Regione))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property ID As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CODAREA As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property REGIONE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.ID = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CODAREA = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ordine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.REGIONE = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _ID as integer  = 0 
	Public Overridable Property ID() as integer  Implements _IRegione.ID
		Get
			Return _ID
		End Get
		Set (byval value as integer)
			If _ID <> value Then
				IsChanged = True
				WhatIsChanged.ID = True
				_ID = value
			End If
		End Set
	End property 

	Protected _CODAREA as integer  = 0 
	Public Overridable Property CODAREA() as integer  Implements _IRegione.CODAREA
		Get
			Return _CODAREA
		End Get
		Set (byval value as integer)
			If _CODAREA <> value Then
				IsChanged = True
				WhatIsChanged.CODAREA = True
				_CODAREA = value
			End If
		End Set
	End property 

	Protected _ordine as integer  = 0 
	Public Overridable Property ordine() as integer  Implements _IRegione.ordine
		Get
			Return _ordine
		End Get
		Set (byval value as integer)
			If _ordine <> value Then
				IsChanged = True
				WhatIsChanged.ordine = True
				_ordine = value
			End If
		End Set
	End property 

	Protected _REGIONE as string  = "" 
	Public Overridable Property REGIONE() as string  Implements _IRegione.REGIONE
		Get
			Return _REGIONE
		End Get
		Set (byval value as string)
			If _REGIONE <> value Then
				IsChanged = True
				WhatIsChanged.REGIONE = True
				_REGIONE = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Regione from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Regione = Manager.Read(Id)
				_ID = int.ID
				_CODAREA = int.CODAREA
				_ordine = int.ordine
				_REGIONE = int.REGIONE
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Regione on DB.
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
		if _REGIONE.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Regioni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IRegione

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property ID() as integer
	Property CODAREA() as integer
	Property ordine() as integer
	Property REGIONE() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Regione
		Public Shared ReadOnly Property ID As New LUNA.LunaFieldName("ID")
		Public Shared ReadOnly Property CODAREA As New LUNA.LunaFieldName("CODAREA")
		Public Shared ReadOnly Property ordine As New LUNA.LunaFieldName("ordine")
		Public Shared ReadOnly Property REGIONE As New LUNA.LunaFieldName("REGIONE")
	End Class

End Class