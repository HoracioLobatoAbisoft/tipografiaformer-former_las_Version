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
'''DAO Class for table Td_coloristampa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ColoreStampa
	Inherits LUNA.LunaBaseClassEntity
	Implements _IColoreStampa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IColoreStampa.FillFromDataRecord
		IdColoreStampa = myRecord("IdColoreStampa")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("FR") is DBNull.Value then FR = myRecord("FR")
		if not myRecord("imgrif") is DBNull.Value then imgrif = myRecord("imgrif")
		if not myRecord("NLastre") is DBNull.Value then NLastre = myRecord("NLastre")
		if not myRecord("Sigla") is DBNull.Value then Sigla = myRecord("Sigla")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ColoreStampa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ColoriStampaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ColoreStampa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdColoreStampa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FR As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property imgrif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NLastre As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sigla As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdColoreStampa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FR = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.imgrif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NLastre = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sigla = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdColoreStampa as integer  = 0 
	Public Overridable Property IdColoreStampa() as integer  Implements _IColoreStampa.IdColoreStampa
		Get
			Return _IdColoreStampa
		End Get
		Set (byval value as integer)
			If _IdColoreStampa <> value Then
				IsChanged = True
				WhatIsChanged.IdColoreStampa = True
				_IdColoreStampa = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IColoreStampa.Descrizione
		Get
			Return _Descrizione
		End Get
		Set (byval value as string)
			If _Descrizione <> value Then
				IsChanged = True
				WhatIsChanged.Descrizione = True
				_Descrizione = value
			End If
		End Set
	End property 

	Protected _FR as Boolean  = False 
	Public Overridable Property FR() as Boolean  Implements _IColoreStampa.FR
		Get
			Return _FR
		End Get
		Set (byval value as Boolean)
			If _FR <> value Then
				IsChanged = True
				WhatIsChanged.FR = True
				_FR = value
			End If
		End Set
	End property 

	Protected _imgrif as string  = "" 
	Public Overridable Property imgrif() as string  Implements _IColoreStampa.imgrif
		Get
			Return _imgrif
		End Get
		Set (byval value as string)
			If _imgrif <> value Then
				IsChanged = True
				WhatIsChanged.imgrif = True
				_imgrif = value
			End If
		End Set
	End property 

	Protected _NLastre as integer  = 0 
	Public Overridable Property NLastre() as integer  Implements _IColoreStampa.NLastre
		Get
			Return _NLastre
		End Get
		Set (byval value as integer)
			If _NLastre <> value Then
				IsChanged = True
				WhatIsChanged.NLastre = True
				_NLastre = value
			End If
		End Set
	End property 

	Protected _Sigla as string  = "" 
	Public Overridable Property Sigla() as string  Implements _IColoreStampa.Sigla
		Get
			Return _Sigla
		End Get
		Set (byval value as string)
			If _Sigla <> value Then
				IsChanged = True
				WhatIsChanged.Sigla = True
				_Sigla = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ColoreStampa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ColoreStampa = Manager.Read(Id)
				_IdColoreStampa = int.IdColoreStampa
				_Descrizione = int.Descrizione
				_FR = int.FR
				_imgrif = int.imgrif
				_NLastre = int.NLastre
				_Sigla = int.Sigla
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ColoreStampa on DB.
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
		if _Descrizione.Length > 255 then Ris = False
		if _imgrif.Length > 255 then Ris = False
		if _Sigla.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_coloristampa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IColoreStampa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdColoreStampa() as integer
	Property Descrizione() as string
	Property FR() as Boolean
	Property imgrif() as string
	Property NLastre() as integer
	Property Sigla() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class ColoreStampa
		Public Shared ReadOnly Property IdColoreStampa As New LUNA.LunaFieldName("IdColoreStampa")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property FR As New LUNA.LunaFieldName("FR")
		Public Shared ReadOnly Property imgrif As New LUNA.LunaFieldName("imgrif")
		Public Shared ReadOnly Property NLastre As New LUNA.LunaFieldName("NLastre")
		Public Shared ReadOnly Property Sigla As New LUNA.LunaFieldName("Sigla")
	End Class

End Class