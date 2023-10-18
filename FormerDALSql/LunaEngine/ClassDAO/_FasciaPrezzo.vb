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
'''DAO Class for table T_fasceprezzo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FasciaPrezzo
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFasciaPrezzo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFasciaPrezzo.FillFromDataRecord
		IDFP = myRecord("IDFP")
		if not myRecord("Max") is DBNull.Value then Max = myRecord("Max")
		if not myRecord("Min") is DBNull.Value then Min = myRecord("Min")
		if not myRecord("Perc") is DBNull.Value then Perc = myRecord("Perc")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FasciaPrezzo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FascePrezzoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FasciaPrezzo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IDFP As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Max As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Min As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Perc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IDFP = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Max = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Min = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Perc = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IDFP as integer  = 0 
	Public Overridable Property IDFP() as integer  Implements _IFasciaPrezzo.IDFP
		Get
			Return _IDFP
		End Get
		Set (byval value as integer)
			If _IDFP <> value Then
				IsChanged = True
				WhatIsChanged.IDFP = True
				_IDFP = value
			End If
		End Set
	End property 

	Protected _Max as integer  = 0 
	Public Overridable Property Max() as integer  Implements _IFasciaPrezzo.Max
		Get
			Return _Max
		End Get
		Set (byval value as integer)
			If _Max <> value Then
				IsChanged = True
				WhatIsChanged.Max = True
				_Max = value
			End If
		End Set
	End property 

	Protected _Min as integer  = 0 
	Public Overridable Property Min() as integer  Implements _IFasciaPrezzo.Min
		Get
			Return _Min
		End Get
		Set (byval value as integer)
			If _Min <> value Then
				IsChanged = True
				WhatIsChanged.Min = True
				_Min = value
			End If
		End Set
	End property 

	Protected _Perc as integer  = 0 
	Public Overridable Property Perc() as integer  Implements _IFasciaPrezzo.Perc
		Get
			Return _Perc
		End Get
		Set (byval value as integer)
			If _Perc <> value Then
				IsChanged = True
				WhatIsChanged.Perc = True
				_Perc = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FasciaPrezzo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FasciaPrezzo = Manager.Read(Id)
				_IDFP = int.IDFP
				_Max = int.Max
				_Min = int.Min
				_Perc = int.Perc
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an FasciaPrezzo on DB.
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
'''Interface for table T_fasceprezzo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFasciaPrezzo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IDFP() as integer
	Property Max() as integer
	Property Min() as integer
	Property Perc() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class FasciaPrezzo
		Public Shared ReadOnly Property IDFP As New LUNA.LunaFieldName("IDFP")
		Public Shared ReadOnly Property Max As New LUNA.LunaFieldName("Max")
		Public Shared ReadOnly Property Min As New LUNA.LunaFieldName("Min")
		Public Shared ReadOnly Property Perc As New LUNA.LunaFieldName("Perc")
	End Class

End Class