#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.2.31 
'Author: Diego Lunadei
'Date: 20/02/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_ricavilog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _LogRicavo
	Inherits LUNA.LunaBaseClassEntity
	Implements _ILogRicavo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ILogRicavo.FillFromDataRecord
		IdLogRicavo = myRecord("IdLogRicavo")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		IdOperatore = myRecord("IdOperatore")
		IdRicavo = myRecord("IdRicavo")
		Quando = myRecord("Quando")
		if not myRecord("StatoIncasso") is DBNull.Value then StatoIncasso = myRecord("StatoIncasso")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of LogRicavo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(LogRicaviDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of LogRicavo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLogRicavo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOperatore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRicavo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StatoIncasso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLogRicavo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOperatore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRicavo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StatoIncasso = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLogRicavo as integer  = 0 
	Public Overridable Property IdLogRicavo() as integer  Implements _ILogRicavo.IdLogRicavo
		Get
			Return _IdLogRicavo
		End Get
		Set (byval value as integer)
			If _IdLogRicavo <> value Then
				IsChanged = True
				WhatIsChanged.IdLogRicavo = True
				_IdLogRicavo = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _ILogRicavo.Annotazioni
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

	Protected _IdOperatore as integer  = 0 
	Public Overridable Property IdOperatore() as integer  Implements _ILogRicavo.IdOperatore
		Get
			Return _IdOperatore
		End Get
		Set (byval value as integer)
			If _IdOperatore <> value Then
				IsChanged = True
				WhatIsChanged.IdOperatore = True
				_IdOperatore = value
			End If
		End Set
	End property 

	Protected _IdRicavo as integer  = 0 
	Public Overridable Property IdRicavo() as integer  Implements _ILogRicavo.IdRicavo
		Get
			Return _IdRicavo
		End Get
		Set (byval value as integer)
			If _IdRicavo <> value Then
				IsChanged = True
				WhatIsChanged.IdRicavo = True
				_IdRicavo = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _ILogRicavo.Quando
		Get
			Return _Quando
		End Get
		Set (byval value as DateTime)
			If _Quando <> value Then
				IsChanged = True
				WhatIsChanged.Quando = True
				_Quando = value
			End If
		End Set
	End property 

	Protected _StatoIncasso as integer  = 0 
	Public Overridable Property StatoIncasso() as integer  Implements _ILogRicavo.StatoIncasso
		Get
			Return _StatoIncasso
		End Get
		Set (byval value as integer)
			If _StatoIncasso <> value Then
				IsChanged = True
				WhatIsChanged.StatoIncasso = True
				_StatoIncasso = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an LogRicavo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As LogRicavo = Manager.Read(Id)
				_IdLogRicavo = int.IdLogRicavo
				_Annotazioni = int.Annotazioni
				_IdOperatore = int.IdOperatore
				_IdRicavo = int.IdRicavo
				_Quando = int.Quando
				_StatoIncasso = int.StatoIncasso
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an LogRicavo on DB.
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
		if _Annotazioni.Length > 2147483647 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_ricavilog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ILogRicavo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLogRicavo() as integer
	Property Annotazioni() as string
	Property IdOperatore() as integer
	Property IdRicavo() as integer
	Property Quando() as DateTime
	Property StatoIncasso() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class LogRicavo
		Public Shared ReadOnly Property IdLogRicavo As New LUNA.LunaFieldName("IdLogRicavo")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property IdOperatore As New LUNA.LunaFieldName("IdOperatore")
		Public Shared ReadOnly Property IdRicavo As New LUNA.LunaFieldName("IdRicavo")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
		Public Shared ReadOnly Property StatoIncasso As New LUNA.LunaFieldName("StatoIncasso")
	End Class

End Class