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
'''DAO Class for table T_templatemarketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _TemplateMarketing
	Inherits LUNA.LunaBaseClassEntity
	Implements _ITemplateMarketing
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ITemplateMarketing.FillFromDataRecord
		IdTemplateMarketing = myRecord("IdTemplateMarketing")
		if not myRecord("Path") is DBNull.Value then Path = myRecord("Path")
		if not myRecord("Titolo") is DBNull.Value then Titolo = myRecord("Titolo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of TemplateMarketing)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(TemplateMarketingDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of TemplateMarketing))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdTemplateMarketing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Path As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Titolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdTemplateMarketing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Path = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Titolo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdTemplateMarketing as integer  = 0 
	Public Overridable Property IdTemplateMarketing() as integer  Implements _ITemplateMarketing.IdTemplateMarketing
		Get
			Return _IdTemplateMarketing
		End Get
		Set (byval value as integer)
			If _IdTemplateMarketing <> value Then
				IsChanged = True
				WhatIsChanged.IdTemplateMarketing = True
				_IdTemplateMarketing = value
			End If
		End Set
	End property 

	Protected _Path as string  = "" 
	Public Overridable Property Path() as string  Implements _ITemplateMarketing.Path
		Get
			Return _Path
		End Get
		Set (byval value as string)
			If _Path <> value Then
				IsChanged = True
				WhatIsChanged.Path = True
				_Path = value
			End If
		End Set
	End property 

	Protected _Titolo as string  = "" 
	Public Overridable Property Titolo() as string  Implements _ITemplateMarketing.Titolo
		Get
			Return _Titolo
		End Get
		Set (byval value as string)
			If _Titolo <> value Then
				IsChanged = True
				WhatIsChanged.Titolo = True
				_Titolo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an TemplateMarketing from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As TemplateMarketing = Manager.Read(Id)
				_IdTemplateMarketing = int.IdTemplateMarketing
				_Path = int.Path
				_Titolo = int.Titolo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an TemplateMarketing on DB.
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
		if _Path.Length > 255 then Ris = False
		if _Titolo.Length > 200 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_templatemarketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITemplateMarketing

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdTemplateMarketing() as integer
	Property Path() as string
	Property Titolo() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class TemplateMarketing
		Public Shared ReadOnly Property IdTemplateMarketing As New LUNA.LunaFieldName("IdTemplateMarketing")
		Public Shared ReadOnly Property Path As New LUNA.LunaFieldName("Path")
		Public Shared ReadOnly Property Titolo As New LUNA.LunaFieldName("Titolo")
	End Class

End Class