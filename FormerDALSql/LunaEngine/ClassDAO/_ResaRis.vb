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
'''DAO Class for table Tr_resaris
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ResaRis
	Inherits LUNA.LunaBaseClassEntity
	Implements _IResaRis
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IResaRis.FillFromDataRecord
		IdResaRis = myRecord("IdResaRis")
		IdFormMacchina = myRecord("IdFormMacchina")
		IdFormRisorsa = myRecord("IdFormRisorsa")
		Resa = myRecord("Resa")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ResaRis)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ResaRisDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ResaRis))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdResaRis As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormMacchina As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormRisorsa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Resa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdResaRis = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormMacchina = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormRisorsa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Resa = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdResaRis as integer  = 0 
	Public Overridable Property IdResaRis() as integer  Implements _IResaRis.IdResaRis
		Get
			Return _IdResaRis
		End Get
		Set (byval value as integer)
			If _IdResaRis <> value Then
				IsChanged = True
				WhatIsChanged.IdResaRis = True
				_IdResaRis = value
			End If
		End Set
	End property 

	Protected _IdFormMacchina as integer  = 0 
	Public Overridable Property IdFormMacchina() as integer  Implements _IResaRis.IdFormMacchina
		Get
			Return _IdFormMacchina
		End Get
		Set (byval value as integer)
			If _IdFormMacchina <> value Then
				IsChanged = True
				WhatIsChanged.IdFormMacchina = True
				_IdFormMacchina = value
			End If
		End Set
	End property 

	Protected _IdFormRisorsa as integer  = 0 
	Public Overridable Property IdFormRisorsa() as integer  Implements _IResaRis.IdFormRisorsa
		Get
			Return _IdFormRisorsa
		End Get
		Set (byval value as integer)
			If _IdFormRisorsa <> value Then
				IsChanged = True
				WhatIsChanged.IdFormRisorsa = True
				_IdFormRisorsa = value
			End If
		End Set
	End property 

	Protected _Resa as integer  = 0 
	Public Overridable Property Resa() as integer  Implements _IResaRis.Resa
		Get
			Return _Resa
		End Get
		Set (byval value as integer)
			If _Resa <> value Then
				IsChanged = True
				WhatIsChanged.Resa = True
				_Resa = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ResaRis from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ResaRis = Manager.Read(Id)
				_IdResaRis = int.IdResaRis
				_IdFormMacchina = int.IdFormMacchina
				_IdFormRisorsa = int.IdFormRisorsa
				_Resa = int.Resa
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ResaRis on DB.
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
'''Interface for table Tr_resaris
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IResaRis

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdResaRis() as integer
	Property IdFormMacchina() as integer
	Property IdFormRisorsa() as integer
	Property Resa() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ResaRis
		Public Shared ReadOnly Property IdResaRis As New LUNA.LunaFieldName("IdResaRis")
		Public Shared ReadOnly Property IdFormMacchina As New LUNA.LunaFieldName("IdFormMacchina")
		Public Shared ReadOnly Property IdFormRisorsa As New LUNA.LunaFieldName("IdFormRisorsa")
		Public Shared ReadOnly Property Resa As New LUNA.LunaFieldName("Resa")
	End Class

End Class