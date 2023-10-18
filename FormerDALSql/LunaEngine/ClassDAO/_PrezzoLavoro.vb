#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 27/04/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_prezzilavoro
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _PrezzoLavoro
	Inherits LUNA.LunaBaseClassEntity
	Implements _IPrezzoLavoro
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IPrezzoLavoro.FillFromDataRecord
		IdLavPrezzo = myRecord("IdLavPrezzo")
		if not myRecord("IdFormProd") is DBNull.Value then IdFormProd = myRecord("IdFormProd")
		if not myRecord("IdLavoro") is DBNull.Value then IdLavoro = myRecord("IdLavoro")
		if not myRecord("Prezzo") is DBNull.Value then Prezzo = myRecord("Prezzo")
		if not myRecord("Prezzo2") is DBNull.Value then Prezzo2 = myRecord("Prezzo2")
		if not myRecord("PrezzoMin") is DBNull.Value then PrezzoMin = myRecord("PrezzoMin")
		if not myRecord("PrezzoMin2") is DBNull.Value then PrezzoMin2 = myRecord("PrezzoMin2")
		if not myRecord("PrezzoOltre") is DBNull.Value then PrezzoOltre = myRecord("PrezzoOltre")
		if not myRecord("PrezzoOltre2") is DBNull.Value then PrezzoOltre2 = myRecord("PrezzoOltre2")
		if not myRecord("QtaRif") is DBNull.Value then QtaRif = myRecord("QtaRif")
		if not myRecord("TipoGrandezza") is DBNull.Value then TipoGrandezza = myRecord("TipoGrandezza")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of PrezzoLavoro)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(PrezziLavoroDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of PrezzoLavoro))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLavPrezzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdLavoro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoMin As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoMin2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoOltre As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoOltre2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property QtaRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoGrandezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLavPrezzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdLavoro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoMin = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoMin2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoOltre = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoOltre2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.QtaRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoGrandezza = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLavPrezzo as integer  = 0 
	Public Overridable Property IdLavPrezzo() as integer  Implements _IPrezzoLavoro.IdLavPrezzo
		Get
			Return _IdLavPrezzo
		End Get
		Set (byval value as integer)
			If _IdLavPrezzo <> value Then
				IsChanged = True
				WhatIsChanged.IdLavPrezzo = True
				_IdLavPrezzo = value
			End If
		End Set
	End property 

	Protected _IdFormProd as integer  = 0 
	Public Overridable Property IdFormProd() as integer  Implements _IPrezzoLavoro.IdFormProd
		Get
			Return _IdFormProd
		End Get
		Set (byval value as integer)
			If _IdFormProd <> value Then
				IsChanged = True
				WhatIsChanged.IdFormProd = True
				_IdFormProd = value
			End If
		End Set
	End property 

	Protected _IdLavoro as integer  = 0 
	Public Overridable Property IdLavoro() as integer  Implements _IPrezzoLavoro.IdLavoro
		Get
			Return _IdLavoro
		End Get
		Set (byval value as integer)
			If _IdLavoro <> value Then
				IsChanged = True
				WhatIsChanged.IdLavoro = True
				_IdLavoro = value
			End If
		End Set
	End property 

	Protected _Prezzo as decimal  = 0 
	Public Overridable Property Prezzo() as decimal  Implements _IPrezzoLavoro.Prezzo
		Get
			Return _Prezzo
		End Get
		Set (byval value as decimal)
			If _Prezzo <> value Then
				IsChanged = True
				WhatIsChanged.Prezzo = True
				_Prezzo = value
			End If
		End Set
	End property 

	Protected _Prezzo2 as decimal  = 0 
	Public Overridable Property Prezzo2() as decimal  Implements _IPrezzoLavoro.Prezzo2
		Get
			Return _Prezzo2
		End Get
		Set (byval value as decimal)
			If _Prezzo2 <> value Then
				IsChanged = True
				WhatIsChanged.Prezzo2 = True
				_Prezzo2 = value
			End If
		End Set
	End property 

	Protected _PrezzoMin as decimal  = 0 
	Public Overridable Property PrezzoMin() as decimal  Implements _IPrezzoLavoro.PrezzoMin
		Get
			Return _PrezzoMin
		End Get
		Set (byval value as decimal)
			If _PrezzoMin <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoMin = True
				_PrezzoMin = value
			End If
		End Set
	End property 

	Protected _PrezzoMin2 as decimal  = 0 
	Public Overridable Property PrezzoMin2() as decimal  Implements _IPrezzoLavoro.PrezzoMin2
		Get
			Return _PrezzoMin2
		End Get
		Set (byval value as decimal)
			If _PrezzoMin2 <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoMin2 = True
				_PrezzoMin2 = value
			End If
		End Set
	End property 

	Protected _PrezzoOltre as decimal  = 0 
	Public Overridable Property PrezzoOltre() as decimal  Implements _IPrezzoLavoro.PrezzoOltre
		Get
			Return _PrezzoOltre
		End Get
		Set (byval value as decimal)
			If _PrezzoOltre <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoOltre = True
				_PrezzoOltre = value
			End If
		End Set
	End property 

	Protected _PrezzoOltre2 as decimal  = 0 
	Public Overridable Property PrezzoOltre2() as decimal  Implements _IPrezzoLavoro.PrezzoOltre2
		Get
			Return _PrezzoOltre2
		End Get
		Set (byval value as decimal)
			If _PrezzoOltre2 <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoOltre2 = True
				_PrezzoOltre2 = value
			End If
		End Set
	End property 

	Protected _QtaRif as integer  = 0 
	Public Overridable Property QtaRif() as integer  Implements _IPrezzoLavoro.QtaRif
		Get
			Return _QtaRif
		End Get
		Set (byval value as integer)
			If _QtaRif <> value Then
				IsChanged = True
				WhatIsChanged.QtaRif = True
				_QtaRif = value
			End If
		End Set
	End property 

	Protected _TipoGrandezza as integer  = 0 
	Public Overridable Property TipoGrandezza() as integer  Implements _IPrezzoLavoro.TipoGrandezza
		Get
			Return _TipoGrandezza
		End Get
		Set (byval value as integer)
			If _TipoGrandezza <> value Then
				IsChanged = True
				WhatIsChanged.TipoGrandezza = True
				_TipoGrandezza = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an PrezzoLavoro from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As PrezzoLavoro = Manager.Read(Id)
				_IdLavPrezzo = int.IdLavPrezzo
				_IdFormProd = int.IdFormProd
				_IdLavoro = int.IdLavoro
				_Prezzo = int.Prezzo
				_Prezzo2 = int.Prezzo2
				_PrezzoMin = int.PrezzoMin
				_PrezzoMin2 = int.PrezzoMin2
				_PrezzoOltre = int.PrezzoOltre
				_PrezzoOltre2 = int.PrezzoOltre2
				_QtaRif = int.QtaRif
				_TipoGrandezza = int.TipoGrandezza
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
        If IdLavPrezzo Then
            ris = Read(IdLavPrezzo)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an PrezzoLavoro on DB.
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


#End Region

End Class 

''' <summary>
'''Interface for table T_prezzilavoro
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IPrezzoLavoro

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLavPrezzo() as integer
	Property IdFormProd() as integer
	Property IdLavoro() as integer
	Property Prezzo() as decimal
	Property Prezzo2() as decimal
	Property PrezzoMin() as decimal
	Property PrezzoMin2() as decimal
	Property PrezzoOltre() as decimal
	Property PrezzoOltre2() as decimal
	Property QtaRif() as integer
	Property TipoGrandezza() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class PrezzoLavoro
		Public Shared ReadOnly Property IdLavPrezzo As New LUNA.LunaFieldName("IdLavPrezzo")
		Public Shared ReadOnly Property IdFormProd As New LUNA.LunaFieldName("IdFormProd")
		Public Shared ReadOnly Property IdLavoro As New LUNA.LunaFieldName("IdLavoro")
		Public Shared ReadOnly Property Prezzo As New LUNA.LunaFieldName("Prezzo")
		Public Shared ReadOnly Property Prezzo2 As New LUNA.LunaFieldName("Prezzo2")
		Public Shared ReadOnly Property PrezzoMin As New LUNA.LunaFieldName("PrezzoMin")
		Public Shared ReadOnly Property PrezzoMin2 As New LUNA.LunaFieldName("PrezzoMin2")
		Public Shared ReadOnly Property PrezzoOltre As New LUNA.LunaFieldName("PrezzoOltre")
		Public Shared ReadOnly Property PrezzoOltre2 As New LUNA.LunaFieldName("PrezzoOltre2")
		Public Shared ReadOnly Property QtaRif As New LUNA.LunaFieldName("QtaRif")
		Public Shared ReadOnly Property TipoGrandezza As New LUNA.LunaFieldName("TipoGrandezza")
	End Class

End Class