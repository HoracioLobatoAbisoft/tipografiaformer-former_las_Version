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
'''DAO Class for table Td_formatocarta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FormatoCartaW
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFormatoCartaW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFormatoCartaW.FillFromDataRecord
		IdFormCarta = myRecord("IdFormCarta")
		if not myRecord("Altezza") is DBNull.Value then Altezza = myRecord("Altezza")
		if not myRecord("FormatoCarta") is DBNull.Value then FormatoCarta = myRecord("FormatoCarta")
		if not myRecord("Larghezza") is DBNull.Value then Larghezza = myRecord("Larghezza")
		if not myRecord("TolleranzaDifetto") is DBNull.Value then TolleranzaDifetto = myRecord("TolleranzaDifetto")
		if not myRecord("TolleranzaEccesso") is DBNull.Value then TolleranzaEccesso = myRecord("TolleranzaEccesso")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FormatoCartaW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FormatiCartaWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FormatoCartaW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdFormCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Altezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FormatoCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Larghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TolleranzaDifetto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TolleranzaEccesso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdFormCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Altezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FormatoCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Larghezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TolleranzaDifetto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TolleranzaEccesso = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdFormCarta as integer  = 0 
	Public Overridable Property IdFormCarta() as integer  Implements _IFormatoCartaW.IdFormCarta
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

	Protected _Altezza as Single  = 0 
	Public Overridable Property Altezza() as Single  Implements _IFormatoCartaW.Altezza
		Get
			Return _Altezza
		End Get
		Set (byval value as Single)
			If _Altezza <> value Then
				IsChanged = True
				WhatIsChanged.Altezza = True
				_Altezza = value
			End If
		End Set
	End property 

	Protected _FormatoCarta as string  = "" 
	Public Overridable Property FormatoCarta() as string  Implements _IFormatoCartaW.FormatoCarta
		Get
			Return _FormatoCarta
		End Get
		Set (byval value as string)
			If _FormatoCarta <> value Then
				IsChanged = True
				WhatIsChanged.FormatoCarta = True
				_FormatoCarta = value
			End If
		End Set
	End property 

	Protected _Larghezza as Single  = 0 
	Public Overridable Property Larghezza() as Single  Implements _IFormatoCartaW.Larghezza
		Get
			Return _Larghezza
		End Get
		Set (byval value as Single)
			If _Larghezza <> value Then
				IsChanged = True
				WhatIsChanged.Larghezza = True
				_Larghezza = value
			End If
		End Set
	End property 

	Protected _TolleranzaDifetto as integer  = 0 
	Public Overridable Property TolleranzaDifetto() as integer  Implements _IFormatoCartaW.TolleranzaDifetto
		Get
			Return _TolleranzaDifetto
		End Get
		Set (byval value as integer)
			If _TolleranzaDifetto <> value Then
				IsChanged = True
				WhatIsChanged.TolleranzaDifetto = True
				_TolleranzaDifetto = value
			End If
		End Set
	End property 

	Protected _TolleranzaEccesso as integer  = 0 
	Public Overridable Property TolleranzaEccesso() as integer  Implements _IFormatoCartaW.TolleranzaEccesso
		Get
			Return _TolleranzaEccesso
		End Get
		Set (byval value as integer)
			If _TolleranzaEccesso <> value Then
				IsChanged = True
				WhatIsChanged.TolleranzaEccesso = True
				_TolleranzaEccesso = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FormatoCartaW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FormatoCartaW = Manager.Read(Id)
				_IdFormCarta = int.IdFormCarta
				_Altezza = int.Altezza
				_FormatoCarta = int.FormatoCarta
				_Larghezza = int.Larghezza
				_TolleranzaDifetto = int.TolleranzaDifetto
				_TolleranzaEccesso = int.TolleranzaEccesso
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an FormatoCartaW on DB.
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
		if _FormatoCarta.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_formatocarta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFormatoCartaW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdFormCarta() as integer
	Property Altezza() as Single
	Property FormatoCarta() as string
	Property Larghezza() as Single
	Property TolleranzaDifetto() as integer
	Property TolleranzaEccesso() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class FormatoCartaW
		Public Shared ReadOnly Property IdFormCarta As New LUNA.LunaFieldName("IdFormCarta")
		Public Shared ReadOnly Property Altezza As New LUNA.LunaFieldName("Altezza")
		Public Shared ReadOnly Property FormatoCarta As New LUNA.LunaFieldName("FormatoCarta")
		Public Shared ReadOnly Property Larghezza As New LUNA.LunaFieldName("Larghezza")
		Public Shared ReadOnly Property TolleranzaDifetto As New LUNA.LunaFieldName("TolleranzaDifetto")
		Public Shared ReadOnly Property TolleranzaEccesso As New LUNA.LunaFieldName("TolleranzaEccesso")
	End Class

End Class