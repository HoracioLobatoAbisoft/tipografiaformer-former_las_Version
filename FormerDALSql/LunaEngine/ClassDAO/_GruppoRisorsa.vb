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
'''DAO Class for table T_gruppirisorsa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _GruppoRisorsa
	Inherits LUNA.LunaBaseClassEntity
	Implements _IGruppoRisorsa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IGruppoRisorsa.FillFromDataRecord
		IdGruppoRisorsa = myRecord("IdGruppoRisorsa")
		Nome = myRecord("Nome")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of GruppoRisorsa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(GruppoRisorsaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of GruppoRisorsa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdGruppoRisorsa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdGruppoRisorsa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdGruppoRisorsa as integer  = 0 
	Public Overridable Property IdGruppoRisorsa() as integer  Implements _IGruppoRisorsa.IdGruppoRisorsa
		Get
			Return _IdGruppoRisorsa
		End Get
		Set (byval value as integer)
			If _IdGruppoRisorsa <> value Then
				IsChanged = True
				WhatIsChanged.IdGruppoRisorsa = True
				_IdGruppoRisorsa = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IGruppoRisorsa.Nome
		Get
			Return _Nome
		End Get
		Set (byval value as string)
			If _Nome <> value Then
				IsChanged = True
				WhatIsChanged.Nome = True
				_Nome = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an GruppoRisorsa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As GruppoRisorsa = Manager.Read(Id)
				_IdGruppoRisorsa = int.IdGruppoRisorsa
				_Nome = int.Nome
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an GruppoRisorsa on DB.
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
  
		if _Nome.Length = 0 then Ris = False
		if _Nome.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_gruppirisorsa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IGruppoRisorsa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdGruppoRisorsa() as integer
	Property Nome() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class GruppoRisorsa
		Public Shared ReadOnly Property IdGruppoRisorsa As New LUNA.LunaFieldName("IdGruppoRisorsa")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
	End Class

End Class