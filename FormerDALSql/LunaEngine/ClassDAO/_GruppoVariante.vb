#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/11/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_gruppivarianti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _GruppoVariante
	Inherits LUNA.LunaBaseClassEntity
	Implements _IGruppoVariante
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IGruppoVariante.FillFromDataRecord
		IdGruppoVariante = myRecord("IdGruppoVariante")
		Nome = myRecord("Nome")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of GruppoVariante)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(GruppiVariantiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of GruppoVariante))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdGruppoVariante As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdGruppoVariante = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdGruppoVariante as integer  = 0 
	Public Overridable Property IdGruppoVariante() as integer  Implements _IGruppoVariante.IdGruppoVariante
		Get
			Return _IdGruppoVariante
		End Get
		Set (byval value as integer)
			If _IdGruppoVariante <> value Then
				IsChanged = True
				WhatIsChanged.IdGruppoVariante = True
				_IdGruppoVariante = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IGruppoVariante.Nome
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
	'''This method read an GruppoVariante from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As GruppoVariante = Manager.Read(Id)
				_IdGruppoVariante = int.IdGruppoVariante
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
	'''This method save an GruppoVariante on DB.
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
'''Interface for table T_gruppivarianti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IGruppoVariante

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdGruppoVariante() as integer
	Property Nome() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class GruppoVariante
		Public Shared ReadOnly Property IdGruppoVariante As New LUNA.LunaFieldName("IdGruppoVariante")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
	End Class

End Class