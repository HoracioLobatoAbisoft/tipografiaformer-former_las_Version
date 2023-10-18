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
'''DAO Class for table Td_formatorisorsa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FormatoRisorsa
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFormatoRisorsa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFormatoRisorsa.FillFromDataRecord
		IdFormatoRisorsa = myRecord("IdFormatoRisorsa")
		Altezza = myRecord("Altezza")
		Formato = myRecord("Formato")
		Larghezza = myRecord("Larghezza")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FormatoRisorsa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FormatoRisorsaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FormatoRisorsa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdFormatoRisorsa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Altezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Formato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Larghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdFormatoRisorsa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Altezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Formato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Larghezza = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdFormatoRisorsa as integer  = 0 
	Public Overridable Property IdFormatoRisorsa() as integer  Implements _IFormatoRisorsa.IdFormatoRisorsa
		Get
			Return _IdFormatoRisorsa
		End Get
		Set (byval value as integer)
			If _IdFormatoRisorsa <> value Then
				IsChanged = True
				WhatIsChanged.IdFormatoRisorsa = True
				_IdFormatoRisorsa = value
			End If
		End Set
	End property 

	Protected _Altezza as integer  = 0 
	Public Overridable Property Altezza() as integer  Implements _IFormatoRisorsa.Altezza
		Get
			Return _Altezza
		End Get
		Set (byval value as integer)
			If _Altezza <> value Then
				IsChanged = True
				WhatIsChanged.Altezza = True
				_Altezza = value
			End If
		End Set
	End property 

	Protected _Formato as string  = "" 
	Public Overridable Property Formato() as string  Implements _IFormatoRisorsa.Formato
		Get
			Return _Formato
		End Get
		Set (byval value as string)
			If _Formato <> value Then
				IsChanged = True
				WhatIsChanged.Formato = True
				_Formato = value
			End If
		End Set
	End property 

	Protected _Larghezza as integer  = 0 
	Public Overridable Property Larghezza() as integer  Implements _IFormatoRisorsa.Larghezza
		Get
			Return _Larghezza
		End Get
		Set (byval value as integer)
			If _Larghezza <> value Then
				IsChanged = True
				WhatIsChanged.Larghezza = True
				_Larghezza = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FormatoRisorsa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FormatoRisorsa = Manager.Read(Id)
				_IdFormatoRisorsa = int.IdFormatoRisorsa
				_Altezza = int.Altezza
				_Formato = int.Formato
				_Larghezza = int.Larghezza
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an FormatoRisorsa on DB.
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
  
		if _Formato.Length = 0 then Ris = False
		if _Formato.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_formatorisorsa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFormatoRisorsa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdFormatoRisorsa() as integer
	Property Altezza() as integer
	Property Formato() as string
	Property Larghezza() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class FormatoRisorsa
		Public Shared ReadOnly Property IdFormatoRisorsa As New LUNA.LunaFieldName("IdFormatoRisorsa")
		Public Shared ReadOnly Property Altezza As New LUNA.LunaFieldName("Altezza")
		Public Shared ReadOnly Property Formato As New LUNA.LunaFieldName("Formato")
		Public Shared ReadOnly Property Larghezza As New LUNA.LunaFieldName("Larghezza")
	End Class

End Class