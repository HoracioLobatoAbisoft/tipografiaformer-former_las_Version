#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Comuni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Comune
	Inherits LUNA.LunaBaseClassEntity
	Implements _IComune
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IComune.FillFromDataRecord
		ID = myRecord("ID")
		if not myRecord("CAP") is DBNull.Value then CAP = myRecord("CAP")
		if not myRecord("CODCOMUNE") is DBNull.Value then CODCOMUNE = myRecord("CODCOMUNE")
		DESCCOMUNE = myRecord("DESCCOMUNE")
		if not myRecord("DTVARIAZIONE") is DBNull.Value then DTVARIAZIONE = myRecord("DTVARIAZIONE")
		if not myRecord("FLGVARIAZIONE") is DBNull.Value then FLGVARIAZIONE = myRecord("FLGVARIAZIONE")
		if not myRecord("IDPROV") is DBNull.Value then IDPROV = myRecord("IDPROV")
		if not myRecord("ordine") is DBNull.Value then ordine = myRecord("ordine")
		if not myRecord("SGLCATASTALE") is DBNull.Value then SGLCATASTALE = myRecord("SGLCATASTALE")
		if not myRecord("SGLNAZIONALE") is DBNull.Value then SGLNAZIONALE = myRecord("SGLNAZIONALE")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Comune)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ComuniDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Comune))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property ID As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CAP As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CODCOMUNE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DESCCOMUNE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DTVARIAZIONE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FLGVARIAZIONE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IDPROV As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SGLCATASTALE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SGLNAZIONALE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.ID = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CAP = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CODCOMUNE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DESCCOMUNE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DTVARIAZIONE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FLGVARIAZIONE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IDPROV = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ordine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SGLCATASTALE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SGLNAZIONALE = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _ID as integer  = 0 
	Public Overridable Property ID() as integer  Implements _IComune.ID
		Get
			Return _ID
		End Get
		Set (byval value as integer)
			If _ID <> value Then
				IsChanged = True
				WhatIsChanged.ID = True
				_ID = value
			End If
		End Set
	End property 

	Protected _CAP as string  = "" 
	Public Overridable Property CAP() as string  Implements _IComune.CAP
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

	Protected _CODCOMUNE as integer  = 0 
	Public Overridable Property CODCOMUNE() as integer  Implements _IComune.CODCOMUNE
		Get
			Return _CODCOMUNE
		End Get
		Set (byval value as integer)
			If _CODCOMUNE <> value Then
				IsChanged = True
				WhatIsChanged.CODCOMUNE = True
				_CODCOMUNE = value
			End If
		End Set
	End property 

	Protected _DESCCOMUNE as string  = "" 
	Public Overridable Property DESCCOMUNE() as string  Implements _IComune.DESCCOMUNE
		Get
			Return _DESCCOMUNE
		End Get
		Set (byval value as string)
			If _DESCCOMUNE <> value Then
				IsChanged = True
				WhatIsChanged.DESCCOMUNE = True
				_DESCCOMUNE = value
			End If
		End Set
	End property 

	Protected _DTVARIAZIONE as string  = "" 
	Public Overridable Property DTVARIAZIONE() as string  Implements _IComune.DTVARIAZIONE
		Get
			Return _DTVARIAZIONE
		End Get
		Set (byval value as string)
			If _DTVARIAZIONE <> value Then
				IsChanged = True
				WhatIsChanged.DTVARIAZIONE = True
				_DTVARIAZIONE = value
			End If
		End Set
	End property 

	Protected _FLGVARIAZIONE as integer  = 0 
	Public Overridable Property FLGVARIAZIONE() as integer  Implements _IComune.FLGVARIAZIONE
		Get
			Return _FLGVARIAZIONE
		End Get
		Set (byval value as integer)
			If _FLGVARIAZIONE <> value Then
				IsChanged = True
				WhatIsChanged.FLGVARIAZIONE = True
				_FLGVARIAZIONE = value
			End If
		End Set
	End property 

	Protected _IDPROV as integer  = 0 
	Public Overridable Property IDPROV() as integer  Implements _IComune.IDPROV
		Get
			Return _IDPROV
		End Get
		Set (byval value as integer)
			If _IDPROV <> value Then
				IsChanged = True
				WhatIsChanged.IDPROV = True
				_IDPROV = value
			End If
		End Set
	End property 

	Protected _ordine as integer  = 0 
	Public Overridable Property ordine() as integer  Implements _IComune.ordine
		Get
			Return _ordine
		End Get
		Set (byval value as integer)
			If _ordine <> value Then
				IsChanged = True
				WhatIsChanged.ordine = True
				_ordine = value
			End If
		End Set
	End property 

	Protected _SGLCATASTALE as string  = "" 
	Public Overridable Property SGLCATASTALE() as string  Implements _IComune.SGLCATASTALE
		Get
			Return _SGLCATASTALE
		End Get
		Set (byval value as string)
			If _SGLCATASTALE <> value Then
				IsChanged = True
				WhatIsChanged.SGLCATASTALE = True
				_SGLCATASTALE = value
			End If
		End Set
	End property 

	Protected _SGLNAZIONALE as string  = "" 
	Public Overridable Property SGLNAZIONALE() as string  Implements _IComune.SGLNAZIONALE
		Get
			Return _SGLNAZIONALE
		End Get
		Set (byval value as string)
			If _SGLNAZIONALE <> value Then
				IsChanged = True
				WhatIsChanged.SGLNAZIONALE = True
				_SGLNAZIONALE = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Comune from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Comune = Manager.Read(Id)
				_ID = int.ID
				_CAP = int.CAP
				_CODCOMUNE = int.CODCOMUNE
				_DESCCOMUNE = int.DESCCOMUNE
				_DTVARIAZIONE = int.DTVARIAZIONE
				_FLGVARIAZIONE = int.FLGVARIAZIONE
				_IDPROV = int.IDPROV
				_ordine = int.ordine
				_SGLCATASTALE = int.SGLCATASTALE
				_SGLNAZIONALE = int.SGLNAZIONALE
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Comune on DB.
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
  
		if _DESCCOMUNE.Length = 0 then Ris = False
		if _DESCCOMUNE.Length > 255 then Ris = False
		if _DTVARIAZIONE.Length > 255 then Ris = False
		if _SGLCATASTALE.Length > 255 then Ris = False
		if _SGLNAZIONALE.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Comuni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IComune

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property ID() as integer
	Property CAP() as string
	Property CODCOMUNE() as integer
	Property DESCCOMUNE() as string
	Property DTVARIAZIONE() as string
	Property FLGVARIAZIONE() as integer
	Property IDPROV() as integer
	Property ordine() as integer
	Property SGLCATASTALE() as string
	Property SGLNAZIONALE() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Comune
		Public Shared ReadOnly Property ID As New LUNA.LunaFieldName("ID")
		Public Shared ReadOnly Property CAP As New LUNA.LunaFieldName("CAP")
		Public Shared ReadOnly Property CODCOMUNE As New LUNA.LunaFieldName("CODCOMUNE")
		Public Shared ReadOnly Property DESCCOMUNE As New LUNA.LunaFieldName("DESCCOMUNE")
		Public Shared ReadOnly Property DTVARIAZIONE As New LUNA.LunaFieldName("DTVARIAZIONE")
		Public Shared ReadOnly Property FLGVARIAZIONE As New LUNA.LunaFieldName("FLGVARIAZIONE")
		Public Shared ReadOnly Property IDPROV As New LUNA.LunaFieldName("IDPROV")
		Public Shared ReadOnly Property ordine As New LUNA.LunaFieldName("ordine")
		Public Shared ReadOnly Property SGLCATASTALE As New LUNA.LunaFieldName("SGLCATASTALE")
		Public Shared ReadOnly Property SGLNAZIONALE As New LUNA.LunaFieldName("SGLNAZIONALE")
	End Class

End Class