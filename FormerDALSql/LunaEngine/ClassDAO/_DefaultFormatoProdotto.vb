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
'''DAO Class for table Tr_defaultformatoprev
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _DefaultFormatoProdotto
	Inherits LUNA.LunaBaseClassEntity
	Implements _IDefaultFormatoProdotto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IDefaultFormatoProdotto.FillFromDataRecord
		IdDefaultFormatoPrev = myRecord("IdDefaultFormatoPrev")
		IdCatFormatoProdotto = myRecord("IdCatFormatoProdotto")
		IdFormatoProdotto = myRecord("IdFormatoProdotto")
		IdPreventivazione = myRecord("IdPreventivazione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of DefaultFormatoProdotto)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(DefaultFormatoProdottoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of DefaultFormatoProdotto))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdDefaultFormatoPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatFormatoProdotto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormatoProdotto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPreventivazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdDefaultFormatoPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatFormatoProdotto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormatoProdotto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPreventivazione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdDefaultFormatoPrev as integer  = 0 
	Public Overridable Property IdDefaultFormatoPrev() as integer  Implements _IDefaultFormatoProdotto.IdDefaultFormatoPrev
		Get
			Return _IdDefaultFormatoPrev
		End Get
		Set (byval value as integer)
			If _IdDefaultFormatoPrev <> value Then
				IsChanged = True
				WhatIsChanged.IdDefaultFormatoPrev = True
				_IdDefaultFormatoPrev = value
			End If
		End Set
	End property 

	Protected _IdCatFormatoProdotto as integer  = 0 
	Public Overridable Property IdCatFormatoProdotto() as integer  Implements _IDefaultFormatoProdotto.IdCatFormatoProdotto
		Get
			Return _IdCatFormatoProdotto
		End Get
		Set (byval value as integer)
			If _IdCatFormatoProdotto <> value Then
				IsChanged = True
				WhatIsChanged.IdCatFormatoProdotto = True
				_IdCatFormatoProdotto = value
			End If
		End Set
	End property 

	Protected _IdFormatoProdotto as integer  = 0 
	Public Overridable Property IdFormatoProdotto() as integer  Implements _IDefaultFormatoProdotto.IdFormatoProdotto
		Get
			Return _IdFormatoProdotto
		End Get
		Set (byval value as integer)
			If _IdFormatoProdotto <> value Then
				IsChanged = True
				WhatIsChanged.IdFormatoProdotto = True
				_IdFormatoProdotto = value
			End If
		End Set
	End property 

	Protected _IdPreventivazione as integer  = 0 
	Public Overridable Property IdPreventivazione() as integer  Implements _IDefaultFormatoProdotto.IdPreventivazione
		Get
			Return _IdPreventivazione
		End Get
		Set (byval value as integer)
			If _IdPreventivazione <> value Then
				IsChanged = True
				WhatIsChanged.IdPreventivazione = True
				_IdPreventivazione = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an DefaultFormatoProdotto from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As DefaultFormatoProdotto = Manager.Read(Id)
				_IdDefaultFormatoPrev = int.IdDefaultFormatoPrev
				_IdCatFormatoProdotto = int.IdCatFormatoProdotto
				_IdFormatoProdotto = int.IdFormatoProdotto
				_IdPreventivazione = int.IdPreventivazione
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an DefaultFormatoProdotto on DB.
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
'''Interface for table Tr_defaultformatoprev
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IDefaultFormatoProdotto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdDefaultFormatoPrev() as integer
	Property IdCatFormatoProdotto() as integer
	Property IdFormatoProdotto() as integer
	Property IdPreventivazione() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class DefaultFormatoProdotto
		Public Shared ReadOnly Property IdDefaultFormatoPrev As New LUNA.LunaFieldName("IdDefaultFormatoPrev")
		Public Shared ReadOnly Property IdCatFormatoProdotto As New LUNA.LunaFieldName("IdCatFormatoProdotto")
		Public Shared ReadOnly Property IdFormatoProdotto As New LUNA.LunaFieldName("IdFormatoProdotto")
		Public Shared ReadOnly Property IdPreventivazione As New LUNA.LunaFieldName("IdPreventivazione")
	End Class

End Class