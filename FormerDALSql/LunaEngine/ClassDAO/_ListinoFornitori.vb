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
'''DAO Class for table T_listinoforn
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ListinoFornitori
	Inherits LUNA.LunaBaseClassEntity
	Implements _IListinoFornitori
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IListinoFornitori.FillFromDataRecord
		IdListinoForn = myRecord("IdListinoForn")
		if not myRecord("Annotazioni") is DBNull.Value then Annotazioni = myRecord("Annotazioni")
		if not myRecord("Codice") is DBNull.Value then Codice = myRecord("Codice")
		if not myRecord("DataAcc") is DBNull.Value then DataAcc = myRecord("DataAcc")
		if not myRecord("IdRis") is DBNull.Value then IdRis = myRecord("IdRis")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("Prezzo") is DBNull.Value then Prezzo = myRecord("Prezzo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ListinoFornitori)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ListinoFornitoriDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ListinoFornitori))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdListinoForn As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Annotazioni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataAcc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRis As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdListinoForn = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Annotazioni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataAcc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRis = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdListinoForn as integer  = 0 
	Public Overridable Property IdListinoForn() as integer  Implements _IListinoFornitori.IdListinoForn
		Get
			Return _IdListinoForn
		End Get
		Set (byval value as integer)
			If _IdListinoForn <> value Then
				IsChanged = True
				WhatIsChanged.IdListinoForn = True
				_IdListinoForn = value
			End If
		End Set
	End property 

	Protected _Annotazioni as string  = "" 
	Public Overridable Property Annotazioni() as string  Implements _IListinoFornitori.Annotazioni
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

	Protected _Codice as string  = "" 
	Public Overridable Property Codice() as string  Implements _IListinoFornitori.Codice
		Get
			Return _Codice
		End Get
		Set (byval value as string)
			If _Codice <> value Then
				IsChanged = True
				WhatIsChanged.Codice = True
				_Codice = value
			End If
		End Set
	End property 

	Protected _DataAcc as DateTime  = Nothing 
	Public Overridable Property DataAcc() as DateTime  Implements _IListinoFornitori.DataAcc
		Get
			Return _DataAcc
		End Get
		Set (byval value as DateTime)
			If _DataAcc <> value Then
				IsChanged = True
				WhatIsChanged.DataAcc = True
				_DataAcc = value
			End If
		End Set
	End property 

	Protected _IdRis as integer  = 0 
	Public Overridable Property IdRis() as integer  Implements _IListinoFornitori.IdRis
		Get
			Return _IdRis
		End Get
		Set (byval value as integer)
			If _IdRis <> value Then
				IsChanged = True
				WhatIsChanged.IdRis = True
				_IdRis = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _IListinoFornitori.IdRub
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

	Protected _Prezzo as decimal  = 0 
	Public Overridable Property Prezzo() as decimal  Implements _IListinoFornitori.Prezzo
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ListinoFornitori from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ListinoFornitori = Manager.Read(Id)
				_IdListinoForn = int.IdListinoForn
				_Annotazioni = int.Annotazioni
				_Codice = int.Codice
				_DataAcc = int.DataAcc
				_IdRis = int.IdRis
				_IdRub = int.IdRub
				_Prezzo = int.Prezzo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ListinoFornitori on DB.
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
		if _Annotazioni.Length > 255 then Ris = False
		if _Codice.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"

	
	<XmlElementAttribute("Risorsa")> _
	Protected _Risorsa As Risorsa
	Public property Risorsa() As  Risorsa
		Get
			If _Risorsa Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
				Using Mgr As New RisorseDAO
					_Risorsa = Mgr.Read(_IdRis)
				End Using 
			End If
			Return _Risorsa
		End Get
		Set(ByVal value As Risorsa)
			_Risorsa = value
			_IdRis = _Risorsa.IdRis
		End Set
	End Property

	
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
'''Interface for table T_listinoforn
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IListinoFornitori

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdListinoForn() as integer
	Property Annotazioni() as string
	Property Codice() as string
	Property DataAcc() as DateTime
	Property IdRis() as integer
	Property IdRub() as integer
	Property Prezzo() as decimal

#End Region

End Interface

Partial Public Class LFM

	Public Class ListinoFornitori
		Public Shared ReadOnly Property IdListinoForn As New LUNA.LunaFieldName("IdListinoForn")
		Public Shared ReadOnly Property Annotazioni As New LUNA.LunaFieldName("Annotazioni")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property DataAcc As New LUNA.LunaFieldName("DataAcc")
		Public Shared ReadOnly Property IdRis As New LUNA.LunaFieldName("IdRis")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property Prezzo As New LUNA.LunaFieldName("Prezzo")
	End Class

End Class