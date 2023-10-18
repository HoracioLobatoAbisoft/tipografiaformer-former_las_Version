#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 20/09/2021 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Tracker
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _TrackerW
	Inherits LUNA.LunaBaseClassEntity
	Implements _ITrackerW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ITrackerW.FillFromDataRecord
		IdTrack = myRecord("IdTrack")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		if not myRecord("IdUt") is DBNull.Value then IdUt = myRecord("IdUt")
		if not myRecord("Quando") is DBNull.Value then Quando = myRecord("Quando")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of TrackerW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(TrackerWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of TrackerW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdTrack As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Quando As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdTrack = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Quando = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdTrack as integer  = 0 
	Public Overridable Property IdTrack() as integer  Implements _ITrackerW.IdTrack
		Get
			Return _IdTrack
		End Get
		Set (byval value as integer)
			If _IdTrack <> value Then
				IsChanged = True
				WhatIsChanged.IdTrack = True
				_IdTrack = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _ITrackerW.IdListinoBase
		Get
			Return _IdListinoBase
		End Get
		Set (byval value as integer)
			If _IdListinoBase <> value Then
				IsChanged = True
				WhatIsChanged.IdListinoBase = True
				_IdListinoBase = value
			End If
		End Set
	End property 

	Protected _IdUt as integer  = 0 
	Public Overridable Property IdUt() as integer  Implements _ITrackerW.IdUt
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

	Protected _Quando as DateTime  = Nothing 
	Public Overridable Property Quando() as DateTime  Implements _ITrackerW.Quando
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
	'''This method read an TrackerW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As TrackerW = Manager.Read(Id)
				_IdTrack = int.IdTrack
				_IdListinoBase = int.IdListinoBase
				_IdUt = int.IdUt
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
	'''This method Refresh all data in the entity from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
    Public Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdTrack Then
            ris = Read(IdTrack)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an TrackerW on DB.
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
'''Interface for table Tracker
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITrackerW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdTrack() as integer
	Property IdListinoBase() as integer
	Property IdUt() as integer
	Property Quando() as DateTime

#End Region

End Interface

Partial Public Class LFM

	Public Class TrackerW
		Public Shared ReadOnly Property IdTrack As New LUNA.LunaFieldName("IdTrack")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdUt As New LUNA.LunaFieldName("IdUt")
		Public Shared ReadOnly Property Quando As New LUNA.LunaFieldName("Quando")
	End Class

End Class