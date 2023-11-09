#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 26/10/2023 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Utn_autorizzato
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Utn_autorizzato
	Inherits LUNA.LunaBaseClassEntity
	Implements _IUtn_autorizzato
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IUtn_autorizzato.FillFromDataRecord
		Id = myRecord("Id")
		IdUt = myRecord("IdUt")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Utn_autorizzato)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(Utn_autorizzatoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Utn_autorizzato))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property Id As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.Id = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _Id as integer  = 0 
	Public Overridable Property Id() as integer  Implements _IUtn_autorizzato.Id
		Get
			Return _Id
		End Get
		Set (byval value as integer)
			If _Id <> value Then
				IsChanged = True
				WhatIsChanged.Id = True
				_Id = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IUtn_autorizzato.IdUt
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Utn_autorizzato from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Utn_autorizzato = Manager.Read(Id)
				_Id = int.Id
				_IdUt = int.IdUt
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
    Public Overridable Function Refresh() As Integer
        Dim ris As Integer = 0
        If Id Then
            ris = Read(Id)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an Utn_autorizzato on DB.
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
'''Interface for table Utn_autorizzato
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IUtn_autorizzato

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property Id() as integer
	Property IdUt() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Utn_autorizzato
		Public Shared ReadOnly Property Id As New LUNA.LunaFieldName("Id")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
	End Class

End Class