#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 02/05/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_vocifat
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _VoceFattura
	Inherits LUNA.LunaBaseClassEntity
	Implements _IVoceFattura
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IVoceFattura.FillFromDataRecord
		IdVoceFat = myRecord("IdVoceFat")
		if not myRecord("Codice") is DBNull.Value then Codice = myRecord("Codice")
		if not myRecord("Custom") is DBNull.Value then Custom = myRecord("Custom")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("IdDoc") is DBNull.Value then IdDoc = myRecord("IdDoc")
		if not myRecord("IdOrd") is DBNull.Value then IdOrd = myRecord("IdOrd")
		if not myRecord("IdRigaOriginale") is DBNull.Value then IdRigaOriginale = myRecord("IdRigaOriginale")
		if not myRecord("Importo") is DBNull.Value then Importo = myRecord("Importo")
		if not myRecord("ImportoSing") is DBNull.Value then ImportoSing = myRecord("ImportoSing")
		if not myRecord("Iva") is DBNull.Value then Iva = myRecord("Iva")
		if not myRecord("Qta") is DBNull.Value then Qta = myRecord("Qta")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of VoceFattura)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(VociFatturaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of VoceFattura))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdVoceFat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Custom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdDoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdOrd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRigaOriginale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Importo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoSing As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Iva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdVoceFat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Custom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdDoc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdOrd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRigaOriginale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Importo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoSing = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Iva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdVoceFat as integer  = 0 
	Public Overridable Property IdVoceFat() as integer  Implements _IVoceFattura.IdVoceFat
		Get
			Return _IdVoceFat
		End Get
		Set (byval value as integer)
			If _IdVoceFat <> value Then
				IsChanged = True
				WhatIsChanged.IdVoceFat = True
				_IdVoceFat = value
			End If
		End Set
	End property 

	Protected _Codice as string  = "" 
	Public Overridable Property Codice() as string  Implements _IVoceFattura.Codice
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

	Protected _Custom as integer  = 0 
	Public Overridable Property Custom() as integer  Implements _IVoceFattura.Custom
		Get
			Return _Custom
		End Get
		Set (byval value as integer)
			If _Custom <> value Then
				IsChanged = True
				WhatIsChanged.Custom = True
				_Custom = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IVoceFattura.Descrizione
		Get
			Return _Descrizione
		End Get
		Set (byval value as string)
			If _Descrizione <> value Then
				IsChanged = True
				WhatIsChanged.Descrizione = True
				_Descrizione = value
			End If
		End Set
	End property 

	Protected _IdDoc as integer  = 0 
	Public Overridable Property IdDoc() as integer  Implements _IVoceFattura.IdDoc
		Get
			Return _IdDoc
		End Get
		Set (byval value as integer)
			If _IdDoc <> value Then
				IsChanged = True
				WhatIsChanged.IdDoc = True
				_IdDoc = value
			End If
		End Set
	End property 

	Protected _IdOrd as integer  = 0 
	Public Overridable Property IdOrd() as integer  Implements _IVoceFattura.IdOrd
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

	Protected _IdRigaOriginale as integer  = 0 
	Public Overridable Property IdRigaOriginale() as integer  Implements _IVoceFattura.IdRigaOriginale
		Get
			Return _IdRigaOriginale
		End Get
		Set (byval value as integer)
			If _IdRigaOriginale <> value Then
				IsChanged = True
				WhatIsChanged.IdRigaOriginale = True
				_IdRigaOriginale = value
			End If
		End Set
	End property 

	Protected _Importo as decimal  = 0 
	Public Overridable Property Importo() as decimal  Implements _IVoceFattura.Importo
		Get
			Return _Importo
		End Get
		Set (byval value as decimal)
			If _Importo <> value Then
				IsChanged = True
				WhatIsChanged.Importo = True
				_Importo = value
			End If
		End Set
	End property 

	Protected _ImportoSing as decimal  = 0 
	Public Overridable Property ImportoSing() as decimal  Implements _IVoceFattura.ImportoSing
		Get
			Return _ImportoSing
		End Get
		Set (byval value as decimal)
			If _ImportoSing <> value Then
				IsChanged = True
				WhatIsChanged.ImportoSing = True
				_ImportoSing = value
			End If
		End Set
	End property 

	Protected _Iva as decimal  = 0 
	Public Overridable Property Iva() as decimal  Implements _IVoceFattura.Iva
		Get
			Return _Iva
		End Get
		Set (byval value as decimal)
			If _Iva <> value Then
				IsChanged = True
				WhatIsChanged.Iva = True
				_Iva = value
			End If
		End Set
	End property 

	Protected _Qta as Single  = 0 
	Public Overridable Property Qta() as Single  Implements _IVoceFattura.Qta
		Get
			Return _Qta
		End Get
		Set (byval value as Single)
			If _Qta <> value Then
				IsChanged = True
				WhatIsChanged.Qta = True
				_Qta = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an VoceFattura from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As VoceFattura = Manager.Read(Id)
				_IdVoceFat = int.IdVoceFat
				_Codice = int.Codice
				_Custom = int.Custom
				_Descrizione = int.Descrizione
				_IdDoc = int.IdDoc
				_IdOrd = int.IdOrd
				_IdRigaOriginale = int.IdRigaOriginale
				_Importo = int.Importo
				_ImportoSing = int.ImportoSing
				_Iva = int.Iva
				_Qta = int.Qta
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an VoceFattura on DB.
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
		if _Codice.Length > 30 then Ris = False
		if _Descrizione.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_vocifat
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IVoceFattura

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdVoceFat() as integer
	Property Codice() as string
	Property Custom() as integer
	Property Descrizione() as string
	Property IdDoc() as integer
	Property IdOrd() as integer
	Property IdRigaOriginale() as integer
	Property Importo() as decimal
	Property ImportoSing() as decimal
	Property Iva() as decimal
	Property Qta() as Single

#End Region

End Interface

Partial Public Class LFM

	Public Class VoceFattura
		Public Shared ReadOnly Property IdVoceFat As New LUNA.LunaFieldName("IdVoceFat")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property Custom As New LUNA.LunaFieldName("Custom")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property IdDoc As New LUNA.LunaFieldName("IdDoc")
		Public Shared ReadOnly Property IdOrd As New LUNA.LunaFieldName("IdOrd")
		Public Shared ReadOnly Property IdRigaOriginale As New LUNA.LunaFieldName("IdRigaOriginale")
		Public Shared ReadOnly Property Importo As New LUNA.LunaFieldName("Importo")
		Public Shared ReadOnly Property ImportoSing As New LUNA.LunaFieldName("ImportoSing")
		Public Shared ReadOnly Property Iva As New LUNA.LunaFieldName("Iva")
		Public Shared ReadOnly Property Qta As New LUNA.LunaFieldName("Qta")
	End Class

End Class