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
'''DAO Class for table Tr_gruprubr
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _GruppoVoceRubrica
	Inherits LUNA.LunaBaseClassEntity
	Implements _IGruppoVoceRubrica
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IGruppoVoceRubrica.FillFromDataRecord
		IDGrupRubr = myRecord("IDGrupRubr")
		if not myRecord("IdGruppo") is DBNull.Value then IdGruppo = myRecord("IdGruppo")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of GruppoVoceRubrica)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(GruppoVoceRubricaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of GruppoVoceRubrica))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDGrupRubr As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdGruppo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDGrupRubr = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdGruppo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDGrupRubr as integer  = 0 
	Public Overridable Property IDGrupRubr() as integer  Implements _IGruppoVoceRubrica.IDGrupRubr
		Get
			Return _IDGrupRubr
		End Get
		Set (byval value as integer)
			If _IDGrupRubr <> value Then
				IsChanged = True
				WhatIsChanged.IDGrupRubr = True
				_IDGrupRubr = value
			End If
		End Set
	End property 

	Protected _IdGruppo as integer  = 0 
	Public Overridable Property IdGruppo() as integer  Implements _IGruppoVoceRubrica.IdGruppo
		Get
			Return _IdGruppo
		End Get
		Set (byval value as integer)
			If _IdGruppo <> value Then
				IsChanged = True
				WhatIsChanged.IdGruppo = True
				_IdGruppo = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IGruppoVoceRubrica.IdRub
		Get
			Return _IdRub
		End Get
		Set (byval value as integer)
			If _IdRub <> value Then
				IsChanged = True
				WhatIsChanged.IdRub = True
				_IdRub = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an GruppoVoceRubrica from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As GruppoVoceRubrica = Manager.Read(Id)
				_IDGrupRubr = int.IDGrupRubr
				_IdGruppo = int.IdGruppo
				_IdRub = int.IdRub
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an GruppoVoceRubrica on DB.
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
'''Interface for table Tr_gruprubr
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IGruppoVoceRubrica

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDGrupRubr() as integer
	Property IdGruppo() as integer
	Property IdRub() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class GruppoVoceRubrica
		Public Shared ReadOnly Property IDGrupRubr As New LUNA.LunaFieldName("IDGrupRubr")
		Public Shared ReadOnly Property IdGruppo As New LUNA.LunaFieldName("IdGruppo")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
	End Class

End Class