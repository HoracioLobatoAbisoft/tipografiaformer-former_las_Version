#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 06/12/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Extradata
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ExtraDataKey
	Inherits LUNA.LunaBaseClassEntity
	Implements _IExtraDataKey
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IExtraDataKey.FillFromDataRecord
		IdExtraData = myRecord("IdExtraData")
		Chiave = myRecord("Chiave")
		Tipo = myRecord("Tipo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ExtraDataKey)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ExtraDataKeyDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ExtraDataKey))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdExtraData As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Chiave As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdExtraData = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Chiave = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdExtraData as integer  = 0 
	Public Overridable Property IdExtraData() as integer  Implements _IExtraDataKey.IdExtraData
		Get
			Return _IdExtraData
		End Get
		Set (byval value as integer)
			If _IdExtraData <> value Then
				IsChanged = True
				WhatIsChanged.IdExtraData = True
				_IdExtraData = value
			End If
		End Set
	End property 

	Protected _Chiave as string  = "" 
	Public Overridable Property Chiave() as string  Implements _IExtraDataKey.Chiave
		Get
			Return _Chiave
		End Get
		Set (byval value as string)
			If _Chiave <> value Then
				IsChanged = True
				WhatIsChanged.Chiave = True
				_Chiave = value
			End If
		End Set
	End property 

	Protected _Tipo as string  = "" 
	Public Overridable Property Tipo() as string  Implements _IExtraDataKey.Tipo
		Get
			Return _Tipo
		End Get
		Set (byval value as string)
			If _Tipo <> value Then
				IsChanged = True
				WhatIsChanged.Tipo = True
				_Tipo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ExtraDataKey from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ExtraDataKey = Manager.Read(Id)
				_IdExtraData = int.IdExtraData
				_Chiave = int.Chiave
				_Tipo = int.Tipo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method Refresh all data in the entity from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
    Public Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdExtraData Then
            ris = Read(IdExtraData)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an ExtraDataKey on DB.
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
  
		if _Chiave.Length = 0 then Ris = False
		if _Chiave.Length > 50 then Ris = False
  
		if _Tipo.Length = 0 then Ris = False
		if _Tipo.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Extradata
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IExtraDataKey

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdExtraData() as integer
	Property Chiave() as string
	Property Tipo() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class ExtraDataKey
		Public Shared ReadOnly Property IdExtraData As New LUNA.LunaFieldName("IdExtraData")
		Public Shared ReadOnly Property Chiave As New LUNA.LunaFieldName("Chiave")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
	End Class

End Class