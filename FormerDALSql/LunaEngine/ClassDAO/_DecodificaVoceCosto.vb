#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 20/02/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_decodificavocicosto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _DecodificaVoceCosto
	Inherits LUNA.LunaBaseClassEntity
	Implements _IDecodificaVoceCosto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IDecodificaVoceCosto.FillFromDataRecord
		IdDecodificaVociCosto = myRecord("IdDecodificaVociCosto")
		if not myRecord("IdFornitore") is DBNull.Value then IdFornitore = myRecord("IdFornitore")
		if not myRecord("IdRis") is DBNull.Value then IdRis = myRecord("IdRis")
		if not myRecord("QtaMoltiplicatore") is DBNull.Value then QtaMoltiplicatore = myRecord("QtaMoltiplicatore")
		if not myRecord("TextToSearch") is DBNull.Value then TextToSearch = myRecord("TextToSearch")
		TipoDecodifica = myRecord("TipoDecodifica")
		if not myRecord("Um") is DBNull.Value then Um = myRecord("Um")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of DecodificaVoceCosto)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(DecodificaVociCostoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of DecodificaVoceCosto))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdDecodificaVociCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFornitore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRis As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property QtaMoltiplicatore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TextToSearch As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoDecodifica As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Um As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdDecodificaVociCosto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFornitore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRis = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.QtaMoltiplicatore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TextToSearch = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoDecodifica = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Um = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdDecodificaVociCosto as integer  = 0 
	Public Overridable Property IdDecodificaVociCosto() as integer  Implements _IDecodificaVoceCosto.IdDecodificaVociCosto
		Get
			Return _IdDecodificaVociCosto
		End Get
		Set (byval value as integer)
			If _IdDecodificaVociCosto <> value Then
				IsChanged = True
				WhatIsChanged.IdDecodificaVociCosto = True
				_IdDecodificaVociCosto = value
			End If
		End Set
	End property 

	Protected _IdFornitore as integer  = 0 
	Public Overridable Property IdFornitore() as integer  Implements _IDecodificaVoceCosto.IdFornitore
		Get
			Return _IdFornitore
		End Get
		Set (byval value as integer)
			If _IdFornitore <> value Then
				IsChanged = True
				WhatIsChanged.IdFornitore = True
				_IdFornitore = value
			End If
		End Set
	End property 

	Protected _IdRis as integer  = 0 
	Public Overridable Property IdRis() as integer  Implements _IDecodificaVoceCosto.IdRis
		Get
			Return _IdRis
		End Get
		Set (byval value as integer)
			If _IdRis <> value Then
				IsChanged = True
				WhatIsChanged.IdRis = True
				_IdRis = value
			End If
		End Set
	End property 

	Protected _QtaMoltiplicatore as Single  = 0 
	Public Overridable Property QtaMoltiplicatore() as Single  Implements _IDecodificaVoceCosto.QtaMoltiplicatore
		Get
			Return _QtaMoltiplicatore
		End Get
		Set (byval value as Single)
			If _QtaMoltiplicatore <> value Then
				IsChanged = True
				WhatIsChanged.QtaMoltiplicatore = True
				_QtaMoltiplicatore = value
			End If
		End Set
	End property 

	Protected _TextToSearch as string  = "" 
	Public Overridable Property TextToSearch() as string  Implements _IDecodificaVoceCosto.TextToSearch
		Get
			Return _TextToSearch
		End Get
		Set (byval value as string)
			If _TextToSearch <> value Then
				IsChanged = True
				WhatIsChanged.TextToSearch = True
				_TextToSearch = value
			End If
		End Set
	End property 

	Protected _TipoDecodifica as integer  = 0 
	Public Overridable Property TipoDecodifica() as integer  Implements _IDecodificaVoceCosto.TipoDecodifica
		Get
			Return _TipoDecodifica
		End Get
		Set (byval value as integer)
			If _TipoDecodifica <> value Then
				IsChanged = True
				WhatIsChanged.TipoDecodifica = True
				_TipoDecodifica = value
			End If
		End Set
	End property 

	Protected _Um as string  = "" 
	Public Overridable Property Um() as string  Implements _IDecodificaVoceCosto.Um
		Get
			Return _Um
		End Get
		Set (byval value as string)
			If _Um <> value Then
				IsChanged = True
				WhatIsChanged.Um = True
				_Um = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an DecodificaVoceCosto from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As DecodificaVoceCosto = Manager.Read(Id)
				_IdDecodificaVociCosto = int.IdDecodificaVociCosto
				_IdFornitore = int.IdFornitore
				_IdRis = int.IdRis
				_QtaMoltiplicatore = int.QtaMoltiplicatore
				_TextToSearch = int.TextToSearch
				_TipoDecodifica = int.TipoDecodifica
				_Um = int.Um
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
    Public Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdDecodificaVociCosto Then
            ris = Read(IdDecodificaVociCosto)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an DecodificaVoceCosto on DB.
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
		if _TextToSearch.Length > 50 then Ris = False
		if _Um.Length > 10 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_decodificavocicosto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IDecodificaVoceCosto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdDecodificaVociCosto() as integer
	Property IdFornitore() as integer
	Property IdRis() as integer
	Property QtaMoltiplicatore() as Single
	Property TextToSearch() as string
	Property TipoDecodifica() as integer
	Property Um() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class DecodificaVoceCosto
		Public Shared ReadOnly Property IdDecodificaVociCosto As New LUNA.LunaFieldName("IdDecodificaVociCosto")
		Public Shared ReadOnly Property IdFornitore As New LUNA.LunaFieldName("IdFornitore")
		Public Shared ReadOnly Property IdRis As New LUNA.LunaFieldName("IdRis")
		Public Shared ReadOnly Property QtaMoltiplicatore As New LUNA.LunaFieldName("QtaMoltiplicatore")
		Public Shared ReadOnly Property TextToSearch As New LUNA.LunaFieldName("TextToSearch")
		Public Shared ReadOnly Property TipoDecodifica As New LUNA.LunaFieldName("TipoDecodifica")
		Public Shared ReadOnly Property Um As New LUNA.LunaFieldName("Um")
	End Class

End Class