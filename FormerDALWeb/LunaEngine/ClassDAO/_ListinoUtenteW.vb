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
'''DAO Class for table Listiniutente
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ListinoUtenteW
	Inherits LUNA.LunaBaseClassEntity
	Implements _IListinoUtenteW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IListinoUtenteW.FillFromDataRecord
		IdListino = myRecord("IdListino")
		IdUt = myRecord("IdUt")
		PercDefault = myRecord("PercDefault")
		if not myRecord("UltimaGenerazione") is DBNull.Value then UltimaGenerazione = myRecord("UltimaGenerazione")
		UltimoAccesso = myRecord("UltimoAccesso")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ListinoUtenteW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ListiniUtenteWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ListinoUtenteW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdListino As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercDefault As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property UltimaGenerazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property UltimoAccesso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdListino = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercDefault = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.UltimaGenerazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.UltimoAccesso = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdListino as integer  = 0 
	Public Overridable Property IdListino() as integer  Implements _IListinoUtenteW.IdListino
		Get
			Return _IdListino
		End Get
		Set (byval value as integer)
			If _IdListino <> value Then
				IsChanged = True
				WhatIsChanged.IdListino = True
				_IdListino = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IListinoUtenteW.IdUt
		Get
			Return _IdUt
		End Get
		Set (byval value as integer)
			If _IdUt <> value Then
				IsChanged = True
				WhatIsChanged.IdUt = True
				_IdUt = value
			End If
		End Set
	End property 

	Protected _PercDefault as integer  = 0 
	Public Overridable Property PercDefault() as integer  Implements _IListinoUtenteW.PercDefault
		Get
			Return _PercDefault
		End Get
		Set (byval value as integer)
			If _PercDefault <> value Then
				IsChanged = True
				WhatIsChanged.PercDefault = True
				_PercDefault = value
			End If
		End Set
	End property 

	Protected _UltimaGenerazione as DateTime  = Nothing 
	Public Overridable Property UltimaGenerazione() as DateTime  Implements _IListinoUtenteW.UltimaGenerazione
		Get
			Return _UltimaGenerazione
		End Get
		Set (byval value as DateTime)
			If _UltimaGenerazione <> value Then
				IsChanged = True
				WhatIsChanged.UltimaGenerazione = True
				_UltimaGenerazione = value
			End If
		End Set
	End property 

	Protected _UltimoAccesso as DateTime  = Nothing 
	Public Overridable Property UltimoAccesso() as DateTime  Implements _IListinoUtenteW.UltimoAccesso
		Get
			Return _UltimoAccesso
		End Get
		Set (byval value as DateTime)
			If _UltimoAccesso <> value Then
				IsChanged = True
				WhatIsChanged.UltimoAccesso = True
				_UltimoAccesso = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ListinoUtenteW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ListinoUtenteW = Manager.Read(Id)
				_IdListino = int.IdListino
				_IdUt = int.IdUt
				_PercDefault = int.PercDefault
				_UltimaGenerazione = int.UltimaGenerazione
				_UltimoAccesso = int.UltimoAccesso
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ListinoUtenteW on DB.
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

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Listiniutente
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IListinoUtenteW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdListino() as integer
	Property IdUt() as integer
	Property PercDefault() as integer
	Property UltimaGenerazione() as DateTime
	Property UltimoAccesso() as DateTime

#End Region

End Interface

Partial Public Class LFM

	Public Class ListinoUtenteW
		Public Shared ReadOnly Property IdListino As New LUNA.LunaFieldName("IdListino")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property PercDefault As New LUNA.LunaFieldName("PercDefault")
		Public Shared ReadOnly Property UltimaGenerazione As New LUNA.LunaFieldName("UltimaGenerazione")
		Public Shared ReadOnly Property UltimoAccesso As New LUNA.LunaFieldName("UltimoAccesso")
	End Class

End Class