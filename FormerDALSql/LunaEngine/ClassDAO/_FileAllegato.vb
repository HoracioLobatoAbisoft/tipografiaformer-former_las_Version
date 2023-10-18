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
'''DAO Class for table T_fileallegati
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FileAllegato
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFileAllegato
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFileAllegato.FillFromDataRecord
		IdFileAllegato = myRecord("IdFileAllegato")
		FilePath = myRecord("FilePath")
		IdOrd = myRecord("IdOrd")
		if not myRecord("IdProcedura") is DBNull.Value then IdProcedura = myRecord("IdProcedura")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FileAllegato)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FileAllegatiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FileAllegato))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdFileAllegato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FilePath As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProcedura As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdFileAllegato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FilePath = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProcedura = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdFileAllegato as integer  = 0 
	Public Overridable Property IdFileAllegato() as integer  Implements _IFileAllegato.IdFileAllegato
		Get
			Return _IdFileAllegato
		End Get
		Set (byval value as integer)
			If _IdFileAllegato <> value Then
				IsChanged = True
				WhatIsChanged.IdFileAllegato = True
				_IdFileAllegato = value
			End If
		End Set
	End property 

	Protected _FilePath as string  = "" 
	Public Overridable Property FilePath() as string  Implements _IFileAllegato.FilePath
		Get
			Return _FilePath
		End Get
		Set (byval value as string)
			If _FilePath <> value Then
				IsChanged = True
				WhatIsChanged.FilePath = True
				_FilePath = value
			End If
		End Set
	End property 

	Protected _IdOrd as integer  = 0 
	Public Overridable Property IdOrd() as integer  Implements _IFileAllegato.IdOrd
		Get
			Return _IdOrd
		End Get
		Set (byval value as integer)
			If _IdOrd <> value Then
				IsChanged = True
				WhatIsChanged.IdOrd = True
				_IdOrd = value
			End If
		End Set
	End property 

	Protected _IdProcedura as integer  = 0 
	Public Overridable Property IdProcedura() as integer  Implements _IFileAllegato.IdProcedura
		Get
			Return _IdProcedura
		End Get
		Set (byval value as integer)
			If _IdProcedura <> value Then
				IsChanged = True
				WhatIsChanged.IdProcedura = True
				_IdProcedura = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FileAllegato from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FileAllegato = Manager.Read(Id)
				_IdFileAllegato = int.IdFileAllegato
				_FilePath = int.FilePath
				_IdOrd = int.IdOrd
				_IdProcedura = int.IdProcedura
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an FileAllegato on DB.
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
  
		if _FilePath.Length = 0 then Ris = False
		if _FilePath.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_fileallegati
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFileAllegato

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdFileAllegato() as integer
	Property FilePath() as string
	Property IdOrd() as integer
	Property IdProcedura() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class FileAllegato
		Public Shared ReadOnly Property IdFileAllegato As New LUNA.LunaFieldName("IdFileAllegato")
		Public Shared ReadOnly Property FilePath As New LUNA.LunaFieldName("FilePath")
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property IdProcedura As New LUNA.LunaFieldName("IdProcedura")
	End Class

End Class