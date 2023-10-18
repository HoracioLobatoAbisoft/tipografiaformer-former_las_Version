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
'''DAO Class for table T_scatole
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Scatola
	Inherits LUNA.LunaBaseClassEntity
	Implements _IScatola
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IScatola.FillFromDataRecord
		IdScatola = myRecord("IdScatola")
		if not myRecord("Numero") is DBNull.Value then Numero = myRecord("Numero")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Scatola)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ScatoleDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Scatola))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdScatola As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Numero As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdScatola = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Numero = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdScatola as integer  = 0 
	Public Overridable Property IdScatola() as integer  Implements _IScatola.IdScatola
		Get
			Return _IdScatola
		End Get
		Set (byval value as integer)
			If _IdScatola <> value Then
				IsChanged = True
				WhatIsChanged.IdScatola = True
				_IdScatola = value
			End If
		End Set
	End property 

	Protected _Numero as string  = "" 
	Public Overridable Property Numero() as string  Implements _IScatola.Numero
		Get
			Return _Numero
		End Get
		Set (byval value as string)
			If _Numero <> value Then
				IsChanged = True
				WhatIsChanged.Numero = True
				_Numero = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Scatola from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Scatola = Manager.Read(Id)
				_IdScatola = int.IdScatola
				_Numero = int.Numero
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Scatola on DB.
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
		if _Numero.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_scatole
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IScatola

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdScatola() as integer
	Property Numero() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Scatola
		Public Shared ReadOnly Property IdScatola As New LUNA.LunaFieldName("IdScatola")
		Public Shared ReadOnly Property Numero As New LUNA.LunaFieldName("Numero")
	End Class

End Class