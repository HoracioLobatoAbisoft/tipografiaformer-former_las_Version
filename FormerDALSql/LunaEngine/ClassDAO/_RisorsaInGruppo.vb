#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 12/03/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Tr_risorsagruppo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _RisorsaInGruppo
	Inherits LUNA.LunaBaseClassEntity
	Implements _IRisorsaInGruppo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IRisorsaInGruppo.FillFromDataRecord
		IdRisGruppo = myRecord("IdRisGruppo")
		IdGruppo = myRecord("IdGruppo")
		IdRisorsa = myRecord("IdRisorsa")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of RisorsaInGruppo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(RisorsaInGruppoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of RisorsaInGruppo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdRisGruppo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdGruppo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRisorsa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdRisGruppo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdGruppo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRisorsa = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdRisGruppo as integer  = 0 
	Public Overridable Property IdRisGruppo() as integer  Implements _IRisorsaInGruppo.IdRisGruppo
		Get
			Return _IdRisGruppo
		End Get
		Set (byval value as integer)
			If _IdRisGruppo <> value Then
				IsChanged = True
				WhatIsChanged.IdRisGruppo = True
				_IdRisGruppo = value
			End If
		End Set
	End property 

	Protected _IdGruppo as integer  = 0 
	Public Overridable Property IdGruppo() as integer  Implements _IRisorsaInGruppo.IdGruppo
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

	Protected _IdRisorsa as integer  = 0 
	Public Overridable Property IdRisorsa() as integer  Implements _IRisorsaInGruppo.IdRisorsa
		Get
			Return _IdRisorsa
		End Get
		Set (byval value as integer)
			If _IdRisorsa <> value Then
				IsChanged = True
				WhatIsChanged.IdRisorsa = True
				_IdRisorsa = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an RisorsaInGruppo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As RisorsaInGruppo = Manager.Read(Id)
				_IdRisGruppo = int.IdRisGruppo
				_IdGruppo = int.IdGruppo
				_IdRisorsa = int.IdRisorsa
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an RisorsaInGruppo on DB.
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
'''Interface for table Tr_risorsagruppo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IRisorsaInGruppo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdRisGruppo() as integer
	Property IdGruppo() as integer
	Property IdRisorsa() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class RisorsaInGruppo
		Public Shared ReadOnly Property IdRisGruppo As New LUNA.LunaFieldName("IdRisGruppo")
		Public Shared ReadOnly Property IdGruppo As New LUNA.LunaFieldName("IdGruppo")
		Public Shared ReadOnly Property IdRisorsa As New LUNA.LunaFieldName("IdRisorsa")
	End Class

End Class