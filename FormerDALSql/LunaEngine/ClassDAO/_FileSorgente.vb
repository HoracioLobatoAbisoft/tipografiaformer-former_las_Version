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
'''DAO Class for table T_sorgenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FileSorgente
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFileSorgente
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFileSorgente.FillFromDataRecord
		IdSorgente = myRecord("IdSorgente")
		if not myRecord("FilePath") is DBNull.Value then FilePath = myRecord("FilePath")
		if not myRecord("IdOrd") is DBNull.Value then IdOrd = myRecord("IdOrd")
		if not myRecord("NumPagina") is DBNull.Value then NumPagina = myRecord("NumPagina")
		if not myRecord("StatoRefine") is DBNull.Value then StatoRefine = myRecord("StatoRefine")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FileSorgente)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FileSorgentiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FileSorgente))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdSorgente As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FilePath As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumPagina As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StatoRefine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdSorgente = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FilePath = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumPagina = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StatoRefine = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdSorgente as integer  = 0 
	Public Overridable Property IdSorgente() as integer  Implements _IFileSorgente.IdSorgente
		Get
			Return _IdSorgente
		End Get
		Set (byval value as integer)
			If _IdSorgente <> value Then
				IsChanged = True
				WhatIsChanged.IdSorgente = True
				_IdSorgente = value
			End If
		End Set
	End property 

	Protected _FilePath as string  = "" 
	Public Overridable Property FilePath() as string  Implements _IFileSorgente.FilePath
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
	Public Overridable Property IdOrd() as integer  Implements _IFileSorgente.IdOrd
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

	Protected _NumPagina as integer  = 0 
	Public Overridable Property NumPagina() as integer  Implements _IFileSorgente.NumPagina
		Get
			Return _NumPagina
		End Get
		Set (byval value as integer)
			If _NumPagina <> value Then
				IsChanged = True
				WhatIsChanged.NumPagina = True
				_NumPagina = value
			End If
		End Set
	End property 

	Protected _StatoRefine as integer  = 0 
	Public Overridable Property StatoRefine() as integer  Implements _IFileSorgente.StatoRefine
		Get
			Return _StatoRefine
		End Get
		Set (byval value as integer)
			If _StatoRefine <> value Then
				IsChanged = True
				WhatIsChanged.StatoRefine = True
				_StatoRefine = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FileSorgente from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FileSorgente = Manager.Read(Id)
				_IdSorgente = int.IdSorgente
				_FilePath = int.FilePath
				_IdOrd = int.IdOrd
				_NumPagina = int.NumPagina
				_StatoRefine = int.StatoRefine
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an FileSorgente on DB.
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
		if _FilePath.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_sorgenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFileSorgente

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdSorgente() as integer
	Property FilePath() as string
	Property IdOrd() as integer
	Property NumPagina() as integer
	Property StatoRefine() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class FileSorgente
		Public Shared ReadOnly Property IdSorgente As New LUNA.LunaFieldName("IdSorgente")
		Public Shared ReadOnly Property FilePath As New LUNA.LunaFieldName("FilePath")
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property NumPagina As New LUNA.LunaFieldName("NumPagina")
		Public Shared ReadOnly Property StatoRefine As New LUNA.LunaFieldName("StatoRefine")
	End Class

End Class