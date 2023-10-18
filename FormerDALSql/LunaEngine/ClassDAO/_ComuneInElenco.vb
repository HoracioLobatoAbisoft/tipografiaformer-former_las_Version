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
'''DAO Class for table Elencocomuni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ComuneInElenco
	Inherits LUNA.LunaBaseClassEntity
	Implements _IComuneInElenco
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IComuneInElenco.FillFromDataRecord
		IDCap = myRecord("IDCap")
		if not myRecord("CAP") is DBNull.Value then CAP = myRecord("CAP")
		if not myRecord("Comune") is DBNull.Value then Comune = myRecord("Comune")
		if not myRecord("Provincia") is DBNull.Value then Provincia = myRecord("Provincia")
		if not myRecord("Regione") is DBNull.Value then Regione = myRecord("Regione")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ComuneInElenco)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ElencoComuniDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ComuneInElenco))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDCap As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CAP As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Comune As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Provincia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Regione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDCap = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CAP = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Comune = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Provincia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Regione = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDCap as integer  = 0 
	Public Overridable Property IDCap() as integer  Implements _IComuneInElenco.IDCap
		Get
			Return _IDCap
		End Get
		Set (byval value as integer)
			If _IDCap <> value Then
				IsChanged = True
				WhatIsChanged.IDCap = True
				_IDCap = value
			End If
		End Set
	End property 

	Protected _CAP as string  = "" 
	Public Overridable Property CAP() as string  Implements _IComuneInElenco.CAP
		Get
			Return _CAP
		End Get
		Set (byval value as string)
			If _CAP <> value Then
				IsChanged = True
				WhatIsChanged.CAP = True
				_CAP = value
			End If
		End Set
	End property 

	Protected _Comune as string  = "" 
	Public Overridable Property Comune() as string  Implements _IComuneInElenco.Comune
		Get
			Return _Comune
		End Get
		Set (byval value as string)
			If _Comune <> value Then
				IsChanged = True
				WhatIsChanged.Comune = True
				_Comune = value
			End If
		End Set
	End property 

	Protected _Provincia as string  = "" 
	Public Overridable Property Provincia() as string  Implements _IComuneInElenco.Provincia
		Get
			Return _Provincia
		End Get
		Set (byval value as string)
			If _Provincia <> value Then
				IsChanged = True
				WhatIsChanged.Provincia = True
				_Provincia = value
			End If
		End Set
	End property 

	Protected _Regione as string  = "" 
	Public Overridable Property Regione() as string  Implements _IComuneInElenco.Regione
		Get
			Return _Regione
		End Get
		Set (byval value as string)
			If _Regione <> value Then
				IsChanged = True
				WhatIsChanged.Regione = True
				_Regione = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ComuneInElenco from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ComuneInElenco = Manager.Read(Id)
				_IDCap = int.IDCap
				_CAP = int.CAP
				_Comune = int.Comune
				_Provincia = int.Provincia
				_Regione = int.Regione
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ComuneInElenco on DB.
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
		if _CAP.Length > 255 then Ris = False
		if _Comune.Length > 255 then Ris = False
		if _Provincia.Length > 255 then Ris = False
		if _Regione.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Elencocomuni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IComuneInElenco

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDCap() as integer
	Property CAP() as string
	Property Comune() as string
	Property Provincia() as string
	Property Regione() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class ComuneInElenco
		Public Shared ReadOnly Property IDCap As New LUNA.LunaFieldName("IDCap")
		Public Shared ReadOnly Property CAP As New LUNA.LunaFieldName("CAP")
		Public Shared ReadOnly Property Comune As New LUNA.LunaFieldName("Comune")
		Public Shared ReadOnly Property Provincia As New LUNA.LunaFieldName("Provincia")
		Public Shared ReadOnly Property Regione As New LUNA.LunaFieldName("Regione")
	End Class

End Class