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
'''DAO Class for table Paramlistini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ParamListino
	Inherits LUNA.LunaBaseClassEntity
	Implements _IParamListino
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IParamListino.FillFromDataRecord
		IdParamListino = myRecord("IdParamListino")
		IdPrev = myRecord("IdPrev")
		IdUt = myRecord("IdUt")
		PercRicarico = myRecord("PercRicarico")
		Qta1 = myRecord("Qta1")
		Qta2 = myRecord("Qta2")
		Qta3 = myRecord("Qta3")
		Qta4 = myRecord("Qta4")
		Qta5 = myRecord("Qta5")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ParamListino)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ParamListiniDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ParamListino))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdParamListino As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercRicarico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta5 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdParamListino = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercRicarico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta5 = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdParamListino as integer  = 0 
	Public Overridable Property IdParamListino() as integer  Implements _IParamListino.IdParamListino
		Get
			Return _IdParamListino
		End Get
		Set (byval value as integer)
			If _IdParamListino <> value Then
				IsChanged = True
				WhatIsChanged.IdParamListino = True
				_IdParamListino = value
			End If
		End Set
	End property 

	Protected _IdPrev as integer  = 0 
	Public Overridable Property IdPrev() as integer  Implements _IParamListino.IdPrev
		Get
			Return _IdPrev
		End Get
		Set (byval value as integer)
			If _IdPrev <> value Then
				IsChanged = True
				WhatIsChanged.IdPrev = True
				_IdPrev = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _IParamListino.IdUt
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

	Protected _PercRicarico as integer  = 0 
	Public Overridable Property PercRicarico() as integer  Implements _IParamListino.PercRicarico
		Get
			Return _PercRicarico
		End Get
		Set (byval value as integer)
			If _PercRicarico <> value Then
				IsChanged = True
				WhatIsChanged.PercRicarico = True
				_PercRicarico = value
			End If
		End Set
	End property 

	Protected _Qta1 as integer  = 0 
	Public Overridable Property Qta1() as integer  Implements _IParamListino.Qta1
		Get
			Return _Qta1
		End Get
		Set (byval value as integer)
			If _Qta1 <> value Then
				IsChanged = True
				WhatIsChanged.Qta1 = True
				_Qta1 = value
			End If
		End Set
	End property 

	Protected _Qta2 as integer  = 0 
	Public Overridable Property Qta2() as integer  Implements _IParamListino.Qta2
		Get
			Return _Qta2
		End Get
		Set (byval value as integer)
			If _Qta2 <> value Then
				IsChanged = True
				WhatIsChanged.Qta2 = True
				_Qta2 = value
			End If
		End Set
	End property 

	Protected _Qta3 as integer  = 0 
	Public Overridable Property Qta3() as integer  Implements _IParamListino.Qta3
		Get
			Return _Qta3
		End Get
		Set (byval value as integer)
			If _Qta3 <> value Then
				IsChanged = True
				WhatIsChanged.Qta3 = True
				_Qta3 = value
			End If
		End Set
	End property 

	Protected _Qta4 as integer  = 0 
	Public Overridable Property Qta4() as integer  Implements _IParamListino.Qta4
		Get
			Return _Qta4
		End Get
		Set (byval value as integer)
			If _Qta4 <> value Then
				IsChanged = True
				WhatIsChanged.Qta4 = True
				_Qta4 = value
			End If
		End Set
	End property 

	Protected _Qta5 as integer  = 0 
	Public Overridable Property Qta5() as integer  Implements _IParamListino.Qta5
		Get
			Return _Qta5
		End Get
		Set (byval value as integer)
			If _Qta5 <> value Then
				IsChanged = True
				WhatIsChanged.Qta5 = True
				_Qta5 = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ParamListino from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ParamListino = Manager.Read(Id)
				_IdParamListino = int.IdParamListino
				_IdPrev = int.IdPrev
				_IdUt = int.IdUt
				_PercRicarico = int.PercRicarico
				_Qta1 = int.Qta1
				_Qta2 = int.Qta2
				_Qta3 = int.Qta3
				_Qta4 = int.Qta4
				_Qta5 = int.Qta5
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ParamListino on DB.
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
'''Interface for table Paramlistini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IParamListino

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdParamListino() as integer
	Property IdPrev() as integer
	Property IdUt() as integer
	Property PercRicarico() as integer
	Property Qta1() as integer
	Property Qta2() as integer
	Property Qta3() as integer
	Property Qta4() as integer
	Property Qta5() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ParamListino
		Public Shared ReadOnly Property IdParamListino As New LUNA.LunaFieldName("IdParamListino")
		Public Shared ReadOnly Property IdPrev As New LUNA.LunaFieldName("IdPrev")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property PercRicarico As New LUNA.LunaFieldName("PercRicarico")
		Public Shared ReadOnly Property Qta1 As New LUNA.LunaFieldName("Qta1")
		Public Shared ReadOnly Property Qta2 As New LUNA.LunaFieldName("Qta2")
		Public Shared ReadOnly Property Qta3 As New LUNA.LunaFieldName("Qta3")
		Public Shared ReadOnly Property Qta4 As New LUNA.LunaFieldName("Qta4")
		Public Shared ReadOnly Property Qta5 As New LUNA.LunaFieldName("Qta5")
	End Class

End Class