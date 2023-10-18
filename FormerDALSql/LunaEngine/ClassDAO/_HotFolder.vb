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
'''DAO Class for table T_hotfolder
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _HotFolder
	Inherits LUNA.LunaBaseClassEntity
	Implements _IHotFolder
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IHotFolder.FillFromDataRecord
		IdHotFolder = myRecord("IdHotFolder")
		Nome = myRecord("Nome")
		Path = myRecord("Path")
		Stato = myRecord("Stato")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of HotFolder)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(HotFolderDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of HotFolder))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdHotFolder As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Path As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdHotFolder = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Path = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdHotFolder as integer  = 0 
	Public Overridable Property IdHotFolder() as integer  Implements _IHotFolder.IdHotFolder
		Get
			Return _IdHotFolder
		End Get
		Set (byval value as integer)
			If _IdHotFolder <> value Then
				IsChanged = True
				WhatIsChanged.IdHotFolder = True
				_IdHotFolder = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IHotFolder.Nome
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

	Protected _Path as string  = "" 
	Public Overridable Property Path() as string  Implements _IHotFolder.Path
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

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IHotFolder.Stato
		Get
			Return _Stato
		End Get
		Set (byval value as integer)
			If _Stato <> value Then
				IsChanged = True
				WhatIsChanged.Stato = True
				_Stato = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an HotFolder from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As HotFolder = Manager.Read(Id)
				_IdHotFolder = int.IdHotFolder
				_Nome = int.Nome
				_Path = int.Path
				_Stato = int.Stato
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an HotFolder on DB.
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
  
		if _Nome.Length = 0 then Ris = False
		if _Nome.Length > 50 then Ris = False
  
		if _Path.Length = 0 then Ris = False
		if _Path.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_hotfolder
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IHotFolder

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdHotFolder() as integer
	Property Nome() as string
	Property Path() as string
	Property Stato() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class HotFolder
		Public Shared ReadOnly Property IdHotFolder As New LUNA.LunaFieldName("IdHotFolder")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property Path As New LUNA.LunaFieldName("Path")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
	End Class

End Class