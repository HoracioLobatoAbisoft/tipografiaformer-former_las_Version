#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.7.9 
'Author: Diego Lunadei
'Date: 31/07/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Richiestepreventivo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _RichiestaPreventivo
	Inherits LUNA.LunaBaseClassEntity
	Implements _IRichiestaPreventivo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IRichiestaPreventivo.FillFromDataRecord
		IdRP = myRecord("IdRP")
		if not myRecord("BufferXML") is DBNull.Value then BufferXML = myRecord("BufferXML")
		IdLb = myRecord("IdLb")
		IdUt = myRecord("IdUt")
		if not myRecord("ImportoNetto") is DBNull.Value then ImportoNetto = myRecord("ImportoNetto")
		Quando = myRecord("Quando")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of RichiestaPreventivo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(RichiestePreventivoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of RichiestaPreventivo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdRP As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property BufferXML As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdLb As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoNetto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdRP = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.BufferXML = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdLb = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoNetto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdRP as integer  = 0 
	Public Overridable Property IdRP() as integer  Implements _IRichiestaPreventivo.IdRP
		Get
			Return _IdRP
		End Get
		Set (byval value as integer)
			If _IdRP <> value Then
				IsChanged = True
				WhatIsChanged.IdRP = True
				_IdRP = value
			End If
		End Set
	End property 

	Protected _BufferXML as string  = "" 
	Public Overridable Property BufferXML() as string  Implements _IRichiestaPreventivo.BufferXML
		Get
			Return _BufferXML
		End Get
		Set (byval value as string)
			If _BufferXML <> value Then
				IsChanged = True
				WhatIsChanged.BufferXML = True
				_BufferXML = value
			End If
		End Set
	End property 

	Protected _IdLb as integer  = 0 
	Public Overridable Property IdLb() as integer  Implements _IRichiestaPreventivo.IdLb
		Get
			Return _IdLb
		End Get
		Set (byval value as integer)
			If _IdLb <> value Then
				IsChanged = True
				WhatIsChanged.IdLb = True
				_IdLb = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IRichiestaPreventivo.IdUt
		Get
			Return _IdUt
		End Get
		Set (byval value as integer)
			If _IdUt <> value Then
				IsChanged = True
				WhatIsChanged.IdUt = True
				_IdUt = value
			End If
		End Set
	End property 

	Protected _ImportoNetto as decimal  = 0 
	Public Overridable Property ImportoNetto() as decimal  Implements _IRichiestaPreventivo.ImportoNetto
		Get
			Return _ImportoNetto
		End Get
		Set (byval value as decimal)
			If _ImportoNetto <> value Then
				IsChanged = True
				WhatIsChanged.ImportoNetto = True
				_ImportoNetto = value
			End If
		End Set
	End property 

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _IRichiestaPreventivo.Quando
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an RichiestaPreventivo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As RichiestaPreventivo = Manager.Read(Id)
				_IdRP = int.IdRP
				_BufferXML = int.BufferXML
				_IdLb = int.IdLb
				_IdUt = int.IdUt
				_ImportoNetto = int.ImportoNetto
				_Quando = int.Quando
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an RichiestaPreventivo on DB.
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
		if _BufferXML.Length > 2147483647 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Richiestepreventivo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IRichiestaPreventivo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdRP() as integer
	Property BufferXML() as string
	Property IdLb() as integer
	Property IdUt() as integer
	Property ImportoNetto() as decimal
	Property Quando() as DateTime

#End Region

End Interface

Partial Public Class LFM

	Public Class RichiestaPreventivo
		Public Shared ReadOnly Property IdRP As New LUNA.LunaFieldName("IdRP")
		Public Shared ReadOnly Property BufferXML As New LUNA.LunaFieldName("BufferXML")
		Public Shared ReadOnly Property IdLb As New LUNA.LunaFieldName("IdLb")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property ImportoNetto As New LUNA.LunaFieldName("ImportoNetto")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
	End Class

End Class