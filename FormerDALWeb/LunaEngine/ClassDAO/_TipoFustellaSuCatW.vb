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
'''DAO Class for table Tr_cattipofustella
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _TipoFustellaSuCatW
	Inherits LUNA.LunaBaseClassEntity
	Implements _ITipoFustellaSuCatW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ITipoFustellaSuCatW.FillFromDataRecord
		IdCatTipo = myRecord("IdCatTipo")
		IdCat = myRecord("IdCat")
		IdTipo = myRecord("IdTipo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of TipoFustellaSuCatW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(TipoFustellaSuCatWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of TipoFustellaSuCatW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCatTipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCatTipo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCatTipo as integer  = 0 
	Public Overridable Property IdCatTipo() as integer  Implements _ITipoFustellaSuCatW.IdCatTipo
		Get
			Return _IdCatTipo
		End Get
		Set (byval value as integer)
			If _IdCatTipo <> value Then
				IsChanged = True
				WhatIsChanged.IdCatTipo = True
				_IdCatTipo = value
			End If
		End Set
	End property 

	Protected _IdCat as integer  = 0 
	Public Overridable Property IdCat() as integer  Implements _ITipoFustellaSuCatW.IdCat
		Get
			Return _IdCat
		End Get
		Set (byval value as integer)
			If _IdCat <> value Then
				IsChanged = True
				WhatIsChanged.IdCat = True
				_IdCat = value
			End If
		End Set
	End property 

	Protected _IdTipo as integer  = 0 
	Public Overridable Property IdTipo() as integer  Implements _ITipoFustellaSuCatW.IdTipo
		Get
			Return _IdTipo
		End Get
		Set (byval value as integer)
			If _IdTipo <> value Then
				IsChanged = True
				WhatIsChanged.IdTipo = True
				_IdTipo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an TipoFustellaSuCatW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As TipoFustellaSuCatW = Manager.Read(Id)
				_IdCatTipo = int.IdCatTipo
				_IdCat = int.IdCat
				_IdTipo = int.IdTipo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an TipoFustellaSuCatW on DB.
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
'''Interface for table Tr_cattipofustella
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITipoFustellaSuCatW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCatTipo() as integer
	Property IdCat() as integer
	Property IdTipo() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class TipoFustellaSuCatW
		Public Shared ReadOnly Property IdCatTipo As New LUNA.LunaFieldName("IdCatTipo")
		Public Shared ReadOnly Property IdCat As New LUNA.LunaFieldName("IdCat")
		Public Shared ReadOnly Property IdTipo As New LUNA.LunaFieldName("IdTipo")
	End Class

End Class