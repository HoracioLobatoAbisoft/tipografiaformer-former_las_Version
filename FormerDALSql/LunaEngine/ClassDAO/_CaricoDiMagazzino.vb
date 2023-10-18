#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 02/04/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_carichimagazzino
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CaricoDiMagazzino
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICaricoDiMagazzino
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICaricoDiMagazzino.FillFromDataRecord
		IdCaricoMagazzino = myRecord("IdCaricoMagazzino")
		DataCarico = myRecord("DataCarico")
		if not myRecord("IdAzienda") is DBNull.Value then IdAzienda = myRecord("IdAzienda")
		if not myRecord("IdCosto") is DBNull.Value then IdCosto = myRecord("IdCosto")
		IdRub = myRecord("IdRub")
		if not myRecord("IdStatoInterno") is DBNull.Value then IdStatoInterno = myRecord("IdStatoInterno")
		IdUtCarico = myRecord("IdUtCarico")
		NumeroDocRiferimento = myRecord("NumeroDocRiferimento")
		TipoDocRiferimento = myRecord("TipoDocRiferimento")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CaricoDiMagazzino)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CarichiDiMagazzinoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CaricoDiMagazzino))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCaricoMagazzino As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataCarico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdAzienda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdStatoInterno As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUtCarico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumeroDocRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoDocRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCaricoMagazzino = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataCarico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdAzienda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCosto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdStatoInterno = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUtCarico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumeroDocRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoDocRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCaricoMagazzino as integer  = 0 
	Public Overridable Property IdCaricoMagazzino() as integer  Implements _ICaricoDiMagazzino.IdCaricoMagazzino
		Get
			Return _IdCaricoMagazzino
		End Get
		Set (byval value as integer)
			If _IdCaricoMagazzino <> value Then
				IsChanged = True
				WhatIsChanged.IdCaricoMagazzino = True
				_IdCaricoMagazzino = value
			End If
		End Set
	End property 

	Protected _DataCarico as DateTime  = Nothing 
	Public Overridable Property DataCarico() as DateTime  Implements _ICaricoDiMagazzino.DataCarico
		Get
			Return _DataCarico
		End Get
		Set (byval value as DateTime)
			If _DataCarico <> value Then
				IsChanged = True
				WhatIsChanged.DataCarico = True
				_DataCarico = value
			End If
		End Set
	End property 

	Protected _IdAzienda as integer  = 0 
	Public Overridable Property IdAzienda() as integer  Implements _ICaricoDiMagazzino.IdAzienda
		Get
			Return _IdAzienda
		End Get
		Set (byval value as integer)
			If _IdAzienda <> value Then
				IsChanged = True
				WhatIsChanged.IdAzienda = True
				_IdAzienda = value
			End If
		End Set
	End property 

	Protected _IdCosto as integer  = 0 
	Public Overridable Property IdCosto() as integer  Implements _ICaricoDiMagazzino.IdCosto
		Get
			Return _IdCosto
		End Get
		Set (byval value as integer)
			If _IdCosto <> value Then
				IsChanged = True
				WhatIsChanged.IdCosto = True
				_IdCosto = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _ICaricoDiMagazzino.IdRub
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

	Protected _IdStatoInterno as integer  = 0 
	Public Overridable Property IdStatoInterno() as integer  Implements _ICaricoDiMagazzino.IdStatoInterno
		Get
			Return _IdStatoInterno
		End Get
		Set (byval value as integer)
			If _IdStatoInterno <> value Then
				IsChanged = True
				WhatIsChanged.IdStatoInterno = True
				_IdStatoInterno = value
			End If
		End Set
	End property 

	Protected _IdUtCarico as integer  = 0 
	Public Overridable Property IdUtCarico() as integer  Implements _ICaricoDiMagazzino.IdUtCarico
		Get
			Return _IdUtCarico
		End Get
		Set (byval value as integer)
			If _IdUtCarico <> value Then
				IsChanged = True
				WhatIsChanged.IdUtCarico = True
				_IdUtCarico = value
			End If
		End Set
	End property 

	Protected _NumeroDocRiferimento as string  = "" 
	Public Overridable Property NumeroDocRiferimento() as string  Implements _ICaricoDiMagazzino.NumeroDocRiferimento
		Get
			Return _NumeroDocRiferimento
		End Get
		Set (byval value as string)
			If _NumeroDocRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.NumeroDocRiferimento = True
				_NumeroDocRiferimento = value
			End If
		End Set
	End property 

	Protected _TipoDocRiferimento as integer  = 0 
	Public Overridable Property TipoDocRiferimento() as integer  Implements _ICaricoDiMagazzino.TipoDocRiferimento
		Get
			Return _TipoDocRiferimento
		End Get
		Set (byval value as integer)
			If _TipoDocRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.TipoDocRiferimento = True
				_TipoDocRiferimento = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CaricoDiMagazzino from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CaricoDiMagazzino = Manager.Read(Id)
				_IdCaricoMagazzino = int.IdCaricoMagazzino
				_DataCarico = int.DataCarico
				_IdAzienda = int.IdAzienda
				_IdCosto = int.IdCosto
				_IdRub = int.IdRub
				_IdStatoInterno = int.IdStatoInterno
				_IdUtCarico = int.IdUtCarico
				_NumeroDocRiferimento = int.NumeroDocRiferimento
				_TipoDocRiferimento = int.TipoDocRiferimento
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CaricoDiMagazzino on DB.
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
  
		if _NumeroDocRiferimento.Length = 0 then Ris = False
		if _NumeroDocRiferimento.Length > 50 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_carichimagazzino
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICaricoDiMagazzino

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCaricoMagazzino() as integer
	Property DataCarico() as DateTime
	Property IdAzienda() as integer
	Property IdCosto() as integer
	Property IdRub() as integer
	Property IdStatoInterno() as integer
	Property IdUtCarico() as integer
	Property NumeroDocRiferimento() as string
	Property TipoDocRiferimento() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CaricoDiMagazzino
		Public Shared ReadOnly Property IdCaricoMagazzino As New LUNA.LunaFieldName("IdCaricoMagazzino")
		Public Shared ReadOnly Property DataCarico As New LUNA.LunaFieldName("DataCarico")
		Public Shared ReadOnly Property IdAzienda As New LUNA.LunaFieldName("IdAzienda")
		Public Shared ReadOnly Property IdCosto As New LUNA.LunaFieldName("IdCosto")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property IdStatoInterno As New LUNA.LunaFieldName("IdStatoInterno")
		Public Shared ReadOnly Property IdUtCarico As New LUNA.LunaFieldName("IdUtCarico")
		Public Shared ReadOnly Property NumeroDocRiferimento As New LUNA.LunaFieldName("NumeroDocRiferimento")
		Public Shared ReadOnly Property TipoDocRiferimento As New LUNA.LunaFieldName("TipoDocRiferimento")
	End Class

End Class