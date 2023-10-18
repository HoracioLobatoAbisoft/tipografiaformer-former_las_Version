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
'''DAO Class for table Mailprevattach
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _AttachPreventivoMail
	Inherits LUNA.LunaBaseClassEntity
	Implements _IAttachPreventivoMail
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IAttachPreventivoMail.FillFromDataRecord
		IdMailAttach = myRecord("IdMailAttach")
		IdMailPreventivo = myRecord("IdMailPreventivo")
		NomeFile = myRecord("NomeFile")
		Path = myRecord("Path")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of AttachPreventivoMail)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(AttachPreventivoMailDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of AttachPreventivoMail))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdMailAttach As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMailPreventivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeFile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Path As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdMailAttach = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMailPreventivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeFile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Path = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdMailAttach as integer  = 0 
	Public Overridable Property IdMailAttach() as integer  Implements _IAttachPreventivoMail.IdMailAttach
		Get
			Return _IdMailAttach
		End Get
		Set (byval value as integer)
			If _IdMailAttach <> value Then
				IsChanged = True
				WhatIsChanged.IdMailAttach = True
				_IdMailAttach = value
			End If
		End Set
	End property 

	Protected _IdMailPreventivo as integer  = 0 
	Public Overridable Property IdMailPreventivo() as integer  Implements _IAttachPreventivoMail.IdMailPreventivo
		Get
			Return _IdMailPreventivo
		End Get
		Set (byval value as integer)
			If _IdMailPreventivo <> value Then
				IsChanged = True
				WhatIsChanged.IdMailPreventivo = True
				_IdMailPreventivo = value
			End If
		End Set
	End property 

	Protected _NomeFile as string  = "" 
	Public Overridable Property NomeFile() as string  Implements _IAttachPreventivoMail.NomeFile
		Get
			Return _NomeFile
		End Get
		Set (byval value as string)
			If _NomeFile <> value Then
				IsChanged = True
				WhatIsChanged.NomeFile = True
				_NomeFile = value
			End If
		End Set
	End property 

	Protected _Path as string  = "" 
	Public Overridable Property Path() as string  Implements _IAttachPreventivoMail.Path
		Get
			Return _Path
		End Get
		Set (byval value as string)
			If _Path <> value Then
				IsChanged = True
				WhatIsChanged.Path = True
				_Path = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an AttachPreventivoMail from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As AttachPreventivoMail = Manager.Read(Id)
				_IdMailAttach = int.IdMailAttach
				_IdMailPreventivo = int.IdMailPreventivo
				_NomeFile = int.NomeFile
				_Path = int.Path
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an AttachPreventivoMail on DB.
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
  
		if _NomeFile.Length = 0 then Ris = False
		if _NomeFile.Length > 255 then Ris = False
  
		if _Path.Length = 0 then Ris = False
		if _Path.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Mailprevattach
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IAttachPreventivoMail

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdMailAttach() as integer
	Property IdMailPreventivo() as integer
	Property NomeFile() as string
	Property Path() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class AttachPreventivoMail
		Public Shared ReadOnly Property IdMailAttach As New LUNA.LunaFieldName("IdMailAttach")
		Public Shared ReadOnly Property IdMailPreventivo As New LUNA.LunaFieldName("IdMailPreventivo")
		Public Shared ReadOnly Property NomeFile As New LUNA.LunaFieldName("NomeFile")
		Public Shared ReadOnly Property Path As New LUNA.LunaFieldName("Path")
	End Class

End Class