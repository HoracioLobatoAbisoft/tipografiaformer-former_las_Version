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
'''DAO Class for table Argomenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Argomento
	Inherits LUNA.LunaBaseClassEntity
	Implements _IArgomento
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IArgomento.FillFromDataRecord
		IDArgomento = myRecord("IDArgomento")
		if not myRecord("DescrizioneBreve") is DBNull.Value then DescrizioneBreve = myRecord("DescrizioneBreve")
		if not myRecord("Ordine") is DBNull.Value then Ordine = myRecord("Ordine")
		if not myRecord("Titolo") is DBNull.Value then Titolo = myRecord("Titolo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Argomento)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ArgomentiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Argomento))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDArgomento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrizioneBreve As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Titolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDArgomento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrizioneBreve = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ordine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Titolo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDArgomento as integer  = 0 
	Public Overridable Property IDArgomento() as integer  Implements _IArgomento.IDArgomento
		Get
			Return _IDArgomento
		End Get
		Set (byval value as integer)
			If _IDArgomento <> value Then
				IsChanged = True
				WhatIsChanged.IDArgomento = True
				_IDArgomento = value
			End If
		End Set
	End property 

	Protected _DescrizioneBreve as string  = "" 
	Public Overridable Property DescrizioneBreve() as string  Implements _IArgomento.DescrizioneBreve
		Get
			Return _DescrizioneBreve
		End Get
		Set (byval value as string)
			If _DescrizioneBreve <> value Then
				IsChanged = True
				WhatIsChanged.DescrizioneBreve = True
				_DescrizioneBreve = value
			End If
		End Set
	End property 

	Protected _Ordine as integer  = 0 
	Public Overridable Property Ordine() as integer  Implements _IArgomento.Ordine
		Get
			Return _Ordine
		End Get
		Set (byval value as integer)
			If _Ordine <> value Then
				IsChanged = True
				WhatIsChanged.Ordine = True
				_Ordine = value
			End If
		End Set
	End property 

	Protected _Titolo as string  = "" 
	Public Overridable Property Titolo() as string  Implements _IArgomento.Titolo
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
	'''This method read an Argomento from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Argomento = Manager.Read(Id)
				_IDArgomento = int.IDArgomento
				_DescrizioneBreve = int.DescrizioneBreve
				_Ordine = int.Ordine
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
	'''This method save an Argomento on DB.
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
		if _DescrizioneBreve.Length > 255 then Ris = False
		if _Titolo.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Argomenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IArgomento

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDArgomento() as integer
	Property DescrizioneBreve() as string
	Property Ordine() as integer
	Property Titolo() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Argomento
		Public Shared ReadOnly Property IDArgomento As New LUNA.LunaFieldName("IDArgomento")
		Public Shared ReadOnly Property DescrizioneBreve As New LUNA.LunaFieldName("DescrizioneBreve")
		Public Shared ReadOnly Property Ordine As New LUNA.LunaFieldName("Ordine")
		Public Shared ReadOnly Property Titolo As New LUNA.LunaFieldName("Titolo")
	End Class

End Class