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
'''DAO Class for table T_fustelle
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Fustella
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFustella
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFustella.FillFromDataRecord
		IdFustella = myRecord("IdFustella")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("Codice") is DBNull.Value then Codice = myRecord("Codice")
		if not myRecord("IdFormCarta") is DBNull.Value then IdFormCarta = myRecord("IdFormCarta")
		if not myRecord("IdTipoFustella") is DBNull.Value then IdTipoFustella = myRecord("IdTipoFustella")
		if not myRecord("Ripetizione") is DBNull.Value then Ripetizione = myRecord("Ripetizione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Fustella)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FustelleDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Fustella))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdFustella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoFustella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ripetizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdFustella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoFustella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ripetizione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdFustella as integer  = 0 
	Public Overridable Property IdFustella() as integer  Implements _IFustella.IdFustella
		Get
			Return _IdFustella
		End Get
		Set (byval value as integer)
			If _IdFustella <> value Then
				IsChanged = True
				WhatIsChanged.IdFustella = True
				_IdFustella = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _IFustella.Annotazioni
		Get
			Return _Annotazioni
		End Get
		Set (byval value as string)
			If _Annotazioni <> value Then
				IsChanged = True
				WhatIsChanged.Annotazioni = True
				_Annotazioni = value
			End If
		End Set
	End property 

	Protected _Codice as string  = "" 
	Public Overridable Property Codice() as string  Implements _IFustella.Codice
		Get
			Return _Codice
		End Get
		Set (byval value as string)
			If _Codice <> value Then
				IsChanged = True
				WhatIsChanged.Codice = True
				_Codice = value
			End If
		End Set
	End property 

	Protected _IdFormCarta as integer  = 0 
	Public Overridable Property IdFormCarta() as integer  Implements _IFustella.IdFormCarta
		Get
			Return _IdFormCarta
		End Get
		Set (byval value as integer)
			If _IdFormCarta <> value Then
				IsChanged = True
				WhatIsChanged.IdFormCarta = True
				_IdFormCarta = value
			End If
		End Set
	End property 

	Protected _IdTipoFustella as integer  = 0 
	Public Overridable Property IdTipoFustella() as integer  Implements _IFustella.IdTipoFustella
		Get
			Return _IdTipoFustella
		End Get
		Set (byval value as integer)
			If _IdTipoFustella <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoFustella = True
				_IdTipoFustella = value
			End If
		End Set
	End property 

	Protected _Ripetizione as integer  = 0 
	Public Overridable Property Ripetizione() as integer  Implements _IFustella.Ripetizione
		Get
			Return _Ripetizione
		End Get
		Set (byval value as integer)
			If _Ripetizione <> value Then
				IsChanged = True
				WhatIsChanged.Ripetizione = True
				_Ripetizione = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Fustella from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Fustella = Manager.Read(Id)
				_IdFustella = int.IdFustella
				_Annotazioni = int.Annotazioni
				_Codice = int.Codice
				_IdFormCarta = int.IdFormCarta
				_IdTipoFustella = int.IdTipoFustella
				_Ripetizione = int.Ripetizione
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Fustella on DB.
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
		if _Annotazioni.Length > 255 then Ris = False
		if _Codice.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_fustelle
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFustella

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdFustella() as integer
	Property Annotazioni() as string
	Property Codice() as string
	Property IdFormCarta() as integer
	Property IdTipoFustella() as integer
	Property Ripetizione() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Fustella
		Public Shared ReadOnly Property IdFustella As New LUNA.LunaFieldName("IdFustella")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property IdFormCarta As New LUNA.LunaFieldName("IdFormCarta")
		Public Shared ReadOnly Property IdTipoFustella As New LUNA.LunaFieldName("IdTipoFustella")
		Public Shared ReadOnly Property Ripetizione As New LUNA.LunaFieldName("Ripetizione")
	End Class

End Class