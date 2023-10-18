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
'''DAO Class for table Tr_cartacomposta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ComposizioneCartaW
	Inherits LUNA.LunaBaseClassEntity
	Implements _IComposizioneCartaW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IComposizioneCartaW.FillFromDataRecord
		IdCartaComposta = myRecord("IdCartaComposta")
		if not myRecord("IdCartaPadre") is DBNull.Value then IdCartaPadre = myRecord("IdCartaPadre")
		if not myRecord("IdCartaSingola") is DBNull.Value then IdCartaSingola = myRecord("IdCartaSingola")
		if not myRecord("NumFogli") is DBNull.Value then NumFogli = myRecord("NumFogli")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ComposizioneCartaW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ComposizioneCartaWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ComposizioneCartaW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCartaComposta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCartaPadre As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCartaSingola As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumFogli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCartaComposta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCartaPadre = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCartaSingola = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumFogli = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCartaComposta as integer  = 0 
	Public Overridable Property IdCartaComposta() as integer  Implements _IComposizioneCartaW.IdCartaComposta
		Get
			Return _IdCartaComposta
		End Get
		Set (byval value as integer)
			If _IdCartaComposta <> value Then
				IsChanged = True
				WhatIsChanged.IdCartaComposta = True
				_IdCartaComposta = value
			End If
		End Set
	End property 

	Protected _IdCartaPadre as integer  = 0 
	Public Overridable Property IdCartaPadre() as integer  Implements _IComposizioneCartaW.IdCartaPadre
		Get
			Return _IdCartaPadre
		End Get
		Set (byval value as integer)
			If _IdCartaPadre <> value Then
				IsChanged = True
				WhatIsChanged.IdCartaPadre = True
				_IdCartaPadre = value
			End If
		End Set
	End property 

	Protected _IdCartaSingola as integer  = 0 
	Public Overridable Property IdCartaSingola() as integer  Implements _IComposizioneCartaW.IdCartaSingola
		Get
			Return _IdCartaSingola
		End Get
		Set (byval value as integer)
			If _IdCartaSingola <> value Then
				IsChanged = True
				WhatIsChanged.IdCartaSingola = True
				_IdCartaSingola = value
			End If
		End Set
	End property 

	Protected _NumFogli as integer  = 0 
	Public Overridable Property NumFogli() as integer  Implements _IComposizioneCartaW.NumFogli
		Get
			Return _NumFogli
		End Get
		Set (byval value as integer)
			If _NumFogli <> value Then
				IsChanged = True
				WhatIsChanged.NumFogli = True
				_NumFogli = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ComposizioneCartaW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ComposizioneCartaW = Manager.Read(Id)
				_IdCartaComposta = int.IdCartaComposta
				_IdCartaPadre = int.IdCartaPadre
				_IdCartaSingola = int.IdCartaSingola
				_NumFogli = int.NumFogli
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ComposizioneCartaW on DB.
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
'''Interface for table Tr_cartacomposta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IComposizioneCartaW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCartaComposta() as integer
	Property IdCartaPadre() as integer
	Property IdCartaSingola() as integer
	Property NumFogli() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ComposizioneCartaW
		Public Shared ReadOnly Property IdCartaComposta As New LUNA.LunaFieldName("IdCartaComposta")
		Public Shared ReadOnly Property IdCartaPadre As New LUNA.LunaFieldName("IdCartaPadre")
		Public Shared ReadOnly Property IdCartaSingola As New LUNA.LunaFieldName("IdCartaSingola")
		Public Shared ReadOnly Property NumFogli As New LUNA.LunaFieldName("NumFogli")
	End Class

End Class