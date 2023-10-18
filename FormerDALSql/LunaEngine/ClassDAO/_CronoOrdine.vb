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
'''DAO Class for table T_ordinicrono
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CronoOrdine
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICronoOrdine
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICronoOrdine.FillFromDataRecord
		IdCronoOrd = myRecord("IdCronoOrd")
		if not myRecord("DataCrono") is DBNull.Value then DataCrono = myRecord("DataCrono")
		if not myRecord("IdOperatore") is DBNull.Value then IdOperatore = myRecord("IdOperatore")
		if not myRecord("IdOrd") is DBNull.Value then IdOrd = myRecord("IdOrd")
		if not myRecord("IdStato") is DBNull.Value then IdStato = myRecord("IdStato")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CronoOrdine)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CronoOrdiniDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CronoOrdine))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCronoOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataCrono As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOperatore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdStato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCronoOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataCrono = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOperatore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdStato = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCronoOrd as integer  = 0 
	Public Overridable Property IdCronoOrd() as integer  Implements _ICronoOrdine.IdCronoOrd
		Get
			Return _IdCronoOrd
		End Get
		Set (byval value as integer)
			If _IdCronoOrd <> value Then
				IsChanged = True
				WhatIsChanged.IdCronoOrd = True
				_IdCronoOrd = value
			End If
		End Set
	End property 

	Protected _DataCrono as DateTime  = Nothing 
	Public Overridable Property DataCrono() as DateTime  Implements _ICronoOrdine.DataCrono
		Get
			Return _DataCrono
		End Get
		Set (byval value as DateTime)
			If _DataCrono <> value Then
				IsChanged = True
				WhatIsChanged.DataCrono = True
				_DataCrono = value
			End If
		End Set
	End property 

	Protected _IdOperatore as integer  = 0 
	Public Overridable Property IdOperatore() as integer  Implements _ICronoOrdine.IdOperatore
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

	Protected _IdOrd as integer  = 0 
	Public Overridable Property IdOrd() as integer  Implements _ICronoOrdine.IdOrd
		Get
			Return _IdOrd
		End Get
		Set (byval value as integer)
			If _IdOrd <> value Then
				IsChanged = True
				WhatIsChanged.IdOrd = True
				_IdOrd = value
			End If
		End Set
	End property 

	Protected _IdStato as integer  = 0 
	Public Overridable Property IdStato() as integer  Implements _ICronoOrdine.IdStato
		Get
			Return _IdStato
		End Get
		Set (byval value as integer)
			If _IdStato <> value Then
				IsChanged = True
				WhatIsChanged.IdStato = True
				_IdStato = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CronoOrdine from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CronoOrdine = Manager.Read(Id)
				_IdCronoOrd = int.IdCronoOrd
				_DataCrono = int.DataCrono
				_IdOperatore = int.IdOperatore
				_IdOrd = int.IdOrd
				_IdStato = int.IdStato
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CronoOrdine on DB.
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

		Return Ris
	End Function

#End Region

#Region "Embedded Class"

	
	<XmlElementAttribute("Ordine")> _
	Protected _Ordine As Ordine
	Public property Ordine() As  Ordine
		Get
			If _Ordine Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
				Using Mgr As New OrdiniDAO
					_Ordine = Mgr.Read(_IdOrd)
				End Using 
			End If
			Return _Ordine
		End Get
		Set(ByVal value As Ordine)
			_Ordine = value
			_IdOrd = _Ordine.IdOrd
		End Set
	End Property


#End Region

End Class 

''' <summary>
'''Interface for table T_ordinicrono
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICronoOrdine

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCronoOrd() as integer
	Property DataCrono() as DateTime
	Property IdOperatore() as integer
	Property IdOrd() as integer
	Property IdStato() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CronoOrdine
		Public Shared ReadOnly Property IdCronoOrd As New LUNA.LunaFieldName("IdCronoOrd")
		Public Shared ReadOnly Property DataCrono As New LUNA.LunaFieldName("DataCrono")
		Public Shared ReadOnly Property IdOperatore As New LUNA.LunaFieldName("IdOperatore")
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property IdStato As New LUNA.LunaFieldName("IdStato")
	End Class

End Class