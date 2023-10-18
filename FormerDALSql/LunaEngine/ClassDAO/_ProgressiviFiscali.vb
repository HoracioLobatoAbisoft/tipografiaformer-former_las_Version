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
'''DAO Class for table T_progressivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ProgressiviFiscali
	Inherits LUNA.LunaBaseClassEntity
	Implements _IProgressiviFiscali
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IProgressiviFiscali.FillFromDataRecord
		IdProgressivo = myRecord("IdProgressivo")
		if not myRecord("NextDDT") is DBNull.Value then NextDDT = myRecord("NextDDT")
		NextFat = myRecord("NextFat")
		if not myRecord("NextPrev") is DBNull.Value then NextPrev = myRecord("NextPrev")
		if not myRecord("NextProgrBart") is DBNull.Value then NextProgrBart = myRecord("NextProgrBart")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ProgressiviFiscali)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ProgressiviFiscaliDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ProgressiviFiscali))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdProgressivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NextDDT As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NextFat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NextPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NextProgrBart As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdProgressivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NextDDT = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NextFat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NextPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NextProgrBart = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdProgressivo as integer  = 0 
	Public Overridable Property IdProgressivo() as integer  Implements _IProgressiviFiscali.IdProgressivo
		Get
			Return _IdProgressivo
		End Get
		Set (byval value as integer)
			If _IdProgressivo <> value Then
				IsChanged = True
				WhatIsChanged.IdProgressivo = True
				_IdProgressivo = value
			End If
		End Set
	End property 

	Protected _NextDDT as integer  = 0 
	Public Overridable Property NextDDT() as integer  Implements _IProgressiviFiscali.NextDDT
		Get
			Return _NextDDT
		End Get
		Set (byval value as integer)
			If _NextDDT <> value Then
				IsChanged = True
				WhatIsChanged.NextDDT = True
				_NextDDT = value
			End If
		End Set
	End property 

	Protected _NextFat as integer  = 0 
	Public Overridable Property NextFat() as integer  Implements _IProgressiviFiscali.NextFat
		Get
			Return _NextFat
		End Get
		Set (byval value as integer)
			If _NextFat <> value Then
				IsChanged = True
				WhatIsChanged.NextFat = True
				_NextFat = value
			End If
		End Set
	End property 

	Protected _NextPrev as integer  = 0 
	Public Overridable Property NextPrev() as integer  Implements _IProgressiviFiscali.NextPrev
		Get
			Return _NextPrev
		End Get
		Set (byval value as integer)
			If _NextPrev <> value Then
				IsChanged = True
				WhatIsChanged.NextPrev = True
				_NextPrev = value
			End If
		End Set
	End property 

	Protected _NextProgrBart as integer  = 0 
	Public Overridable Property NextProgrBart() as integer  Implements _IProgressiviFiscali.NextProgrBart
		Get
			Return _NextProgrBart
		End Get
		Set (byval value as integer)
			If _NextProgrBart <> value Then
				IsChanged = True
				WhatIsChanged.NextProgrBart = True
				_NextProgrBart = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ProgressiviFiscali from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ProgressiviFiscali = Manager.Read(Id)
				_IdProgressivo = int.IdProgressivo
				_NextDDT = int.NextDDT
				_NextFat = int.NextFat
				_NextPrev = int.NextPrev
				_NextProgrBart = int.NextProgrBart
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ProgressiviFiscali on DB.
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
'''Interface for table T_progressivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IProgressiviFiscali

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdProgressivo() as integer
	Property NextDDT() as integer
	Property NextFat() as integer
	Property NextPrev() as integer
	Property NextProgrBart() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ProgressiviFiscali
		Public Shared ReadOnly Property IdProgressivo As New LUNA.LunaFieldName("IdProgressivo")
		Public Shared ReadOnly Property NextDDT As New LUNA.LunaFieldName("NextDDT")
		Public Shared ReadOnly Property NextFat As New LUNA.LunaFieldName("NextFat")
		Public Shared ReadOnly Property NextPrev As New LUNA.LunaFieldName("NextPrev")
		Public Shared ReadOnly Property NextProgrBart As New LUNA.LunaFieldName("NextProgrBart")
	End Class

End Class