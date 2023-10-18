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
'''DAO Class for table T_listinocli
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ListinoClienti
	Inherits LUNA.LunaBaseClassEntity
	Implements _IListinoClienti
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IListinoClienti.FillFromDataRecord
		IdList = myRecord("IdList")
		if not myRecord("IdProd") is DBNull.Value then IdProd = myRecord("IdProd")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("PrezzoRis") is DBNull.Value then PrezzoRis = myRecord("PrezzoRis")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ListinoClienti)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ListinoClientiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ListinoClienti))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdList As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrezzoRis As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdList = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrezzoRis = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdList as integer  = 0 
	Public Overridable Property IdList() as integer  Implements _IListinoClienti.IdList
		Get
			Return _IdList
		End Get
		Set (byval value as integer)
			If _IdList <> value Then
				IsChanged = True
				WhatIsChanged.IdList = True
				_IdList = value
			End If
		End Set
	End property 

	Protected _IdProd as integer  = 0 
	Public Overridable Property IdProd() as integer  Implements _IListinoClienti.IdProd
		Get
			Return _IdProd
		End Get
		Set (byval value as integer)
			If _IdProd <> value Then
				IsChanged = True
				WhatIsChanged.IdProd = True
				_IdProd = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IListinoClienti.IdRub
		Get
			Return _IdRub
		End Get
		Set (byval value as integer)
			If _IdRub <> value Then
				IsChanged = True
				WhatIsChanged.IdRub = True
				_IdRub = value
			End If
		End Set
	End property 

	Protected _PrezzoRis as decimal  = 0 
	Public Overridable Property PrezzoRis() as decimal  Implements _IListinoClienti.PrezzoRis
		Get
			Return _PrezzoRis
		End Get
		Set (byval value as decimal)
			If _PrezzoRis <> value Then
				IsChanged = True
				WhatIsChanged.PrezzoRis = True
				_PrezzoRis = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ListinoClienti from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ListinoClienti = Manager.Read(Id)
				_IdList = int.IdList
				_IdProd = int.IdProd
				_IdRub = int.IdRub
				_PrezzoRis = int.PrezzoRis
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ListinoClienti on DB.
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

	
	<XmlElementAttribute("VoceRubrica")> _
	Protected _VoceRubrica As VoceRubrica
	Public property VoceRubrica() As  VoceRubrica
		Get
			If _VoceRubrica Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
				Using Mgr As New VociRubricaDAO
					_VoceRubrica = Mgr.Read(_IdRub)
				End Using 
			End If
			Return _VoceRubrica
		End Get
		Set(ByVal value As VoceRubrica)
			_VoceRubrica = value
			_IdRub = _VoceRubrica.IdRub
		End Set
	End Property


#End Region

End Class 

''' <summary>
'''Interface for table T_listinocli
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IListinoClienti

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdList() as integer
	Property IdProd() as integer
	Property IdRub() as integer
	Property PrezzoRis() as decimal

#End Region

End Interface

Partial Public Class LFM

	Public Class ListinoClienti
		Public Shared ReadOnly Property IdList As New LUNA.LunaFieldName("IdList")
		Public Shared ReadOnly Property IdProd As New LUNA.LunaFieldName("IdProd")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property PrezzoRis As New LUNA.LunaFieldName("PrezzoRis")
	End Class

End Class