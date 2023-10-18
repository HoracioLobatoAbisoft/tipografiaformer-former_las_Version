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
'''DAO Class for table Glossario
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Glossario
	Inherits LUNA.LunaBaseClassEntity
	Implements _IGlossario
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IGlossario.FillFromDataRecord
		ID = myRecord("ID")
		if not myRecord("Campo1") is DBNull.Value then Campo1 = myRecord("Campo1")
		if not myRecord("Campo2") is DBNull.Value then Campo2 = myRecord("Campo2")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Glossario)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(GlossarioDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Glossario))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property ID As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Campo1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Campo2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.ID = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Campo1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Campo2 = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _ID as integer  = 0 
	Public Overridable Property ID() as integer  Implements _IGlossario.ID
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

	Protected _Campo1 as string  = "" 
	Public Overridable Property Campo1() as string  Implements _IGlossario.Campo1
		Get
			Return _Campo1
		End Get
		Set (byval value as string)
			If _Campo1 <> value Then
				IsChanged = True
				WhatIsChanged.Campo1 = True
				_Campo1 = value
			End If
		End Set
	End property 

	Protected _Campo2 as string  = "" 
	Public Overridable Property Campo2() as string  Implements _IGlossario.Campo2
		Get
			Return _Campo2
		End Get
		Set (byval value as string)
			If _Campo2 <> value Then
				IsChanged = True
				WhatIsChanged.Campo2 = True
				_Campo2 = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Glossario from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Glossario = Manager.Read(Id)
				_ID = int.ID
				_Campo1 = int.Campo1
				_Campo2 = int.Campo2
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Glossario on DB.
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
		if _Campo1.Length > 255 then Ris = False
		if _Campo2.Length > 2147483647 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Glossario
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IGlossario

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property ID() as integer
	Property Campo1() as string
	Property Campo2() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Glossario
		Public Shared ReadOnly Property ID As New LUNA.LunaFieldName("ID")
		Public Shared ReadOnly Property Campo1 As New LUNA.LunaFieldName("Campo1")
		Public Shared ReadOnly Property Campo2 As New LUNA.LunaFieldName("Campo2")
	End Class

End Class