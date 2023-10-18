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
'''DAO Class for table Faq
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Faq
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFaq
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFaq.FillFromDataRecord
		IDFaq = myRecord("IDFaq")
		if not myRecord("Domanda") is DBNull.Value then Domanda = myRecord("Domanda")
		if not myRecord("IDArgomento") is DBNull.Value then IDArgomento = myRecord("IDArgomento")
		if not myRecord("IDReparto") is DBNull.Value then IDReparto = myRecord("IDReparto")
		if not myRecord("Ordine") is DBNull.Value then Ordine = myRecord("Ordine")
		if not myRecord("Risposta") is DBNull.Value then Risposta = myRecord("Risposta")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Faq)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FaqDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Faq))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDFaq As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Domanda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IDArgomento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IDReparto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Risposta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDFaq = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Domanda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IDArgomento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IDReparto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ordine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Risposta = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDFaq as integer  = 0 
	Public Overridable Property IDFaq() as integer  Implements _IFaq.IDFaq
		Get
			Return _IDFaq
		End Get
		Set (byval value as integer)
			If _IDFaq <> value Then
				IsChanged = True
				WhatIsChanged.IDFaq = True
				_IDFaq = value
			End If
		End Set
	End property 

	Protected _Domanda as string  = "" 
	Public Overridable Property Domanda() as string  Implements _IFaq.Domanda
		Get
			Return _Domanda
		End Get
		Set (byval value as string)
			If _Domanda <> value Then
				IsChanged = True
				WhatIsChanged.Domanda = True
				_Domanda = value
			End If
		End Set
	End property 

	Protected _IDArgomento as integer  = 0 
	Public Overridable Property IDArgomento() as integer  Implements _IFaq.IDArgomento
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

	Protected _IDReparto as integer  = 0 
	Public Overridable Property IDReparto() as integer  Implements _IFaq.IDReparto
		Get
			Return _IDReparto
		End Get
		Set (byval value as integer)
			If _IDReparto <> value Then
				IsChanged = True
				WhatIsChanged.IDReparto = True
				_IDReparto = value
			End If
		End Set
	End property 

	Protected _Ordine as integer  = 0 
	Public Overridable Property Ordine() as integer  Implements _IFaq.Ordine
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

	Protected _Risposta as string  = "" 
	Public Overridable Property Risposta() as string  Implements _IFaq.Risposta
		Get
			Return _Risposta
		End Get
		Set (byval value as string)
			If _Risposta <> value Then
				IsChanged = True
				WhatIsChanged.Risposta = True
				_Risposta = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Faq from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Faq = Manager.Read(Id)
				_IDFaq = int.IDFaq
				_Domanda = int.Domanda
				_IDArgomento = int.IDArgomento
				_IDReparto = int.IDReparto
				_Ordine = int.Ordine
				_Risposta = int.Risposta
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Faq on DB.
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
		if _Domanda.Length > 255 then Ris = False
		if _Risposta.Length > 2147483647 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Faq
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFaq

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDFaq() as integer
	Property Domanda() as string
	Property IDArgomento() as integer
	Property IDReparto() as integer
	Property Ordine() as integer
	Property Risposta() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class Faq
		Public Shared ReadOnly Property IDFaq As New LUNA.LunaFieldName("IDFaq")
		Public Shared ReadOnly Property Domanda As New LUNA.LunaFieldName("Domanda")
		Public Shared ReadOnly Property IDArgomento As New LUNA.LunaFieldName("IDArgomento")
		Public Shared ReadOnly Property IDReparto As New LUNA.LunaFieldName("IDReparto")
		Public Shared ReadOnly Property Ordine As New LUNA.LunaFieldName("Ordine")
		Public Shared ReadOnly Property Risposta As New LUNA.LunaFieldName("Risposta")
	End Class

End Class