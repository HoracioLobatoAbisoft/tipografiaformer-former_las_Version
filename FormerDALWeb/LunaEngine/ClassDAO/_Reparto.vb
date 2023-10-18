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
'''DAO Class for table Reparti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Reparto
	Inherits LUNA.LunaBaseClassEntity
	Implements _IReparto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IReparto.FillFromDataRecord
		IDReparto = myRecord("IDReparto")
		if not myRecord("Email") is DBNull.Value then Email = myRecord("Email")
		if not myRecord("NomeReparto") is DBNull.Value then NomeReparto = myRecord("NomeReparto")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Reparto)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(RepartiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Reparto))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDReparto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Email As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeReparto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDReparto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Email = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeReparto = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDReparto as integer  = 0 
	Public Overridable Property IDReparto() as integer  Implements _IReparto.IDReparto
		Get
			Return _IDReparto
		End Get
		Set (byval value as integer)
			If _IDReparto <> value Then
				IsChanged = True
				WhatIsChanged.IDReparto = True
				_IDReparto = value
			End If
		End Set
	End property 

	Protected _Email as string  = "" 
	Public Overridable Property Email() as string  Implements _IReparto.Email
		Get
			Return _Email
		End Get
		Set (byval value as string)
			If _Email <> value Then
				IsChanged = True
				WhatIsChanged.Email = True
				_Email = value
			End If
		End Set
	End property 

	Protected _NomeReparto as string  = "" 
	Public Overridable Property NomeReparto() as string  Implements _IReparto.NomeReparto
		Get
			Return _NomeReparto
		End Get
		Set (byval value as string)
			If _NomeReparto <> value Then
				IsChanged = True
				WhatIsChanged.NomeReparto = True
				_NomeReparto = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Reparto from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Reparto = Manager.Read(Id)
				_IDReparto = int.IDReparto
				_Email = int.Email
				_NomeReparto = int.NomeReparto
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Reparto on DB.
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
		if _Email.Length > 255 then Ris = False
		if _NomeReparto.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Reparti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IReparto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDReparto() as integer
	Property Email() as string
	Property NomeReparto() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Reparto
		Public Shared ReadOnly Property IDReparto As New LUNA.LunaFieldName("IDReparto")
		Public Shared ReadOnly Property Email As New LUNA.LunaFieldName("Email")
		Public Shared ReadOnly Property NomeReparto As New LUNA.LunaFieldName("NomeReparto")
	End Class

End Class