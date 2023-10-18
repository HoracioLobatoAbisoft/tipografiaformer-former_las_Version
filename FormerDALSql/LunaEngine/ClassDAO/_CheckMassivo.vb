#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 12/03/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_checkmassivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CheckMassivo
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICheckMassivo
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICheckMassivo.FillFromDataRecord
		IdCheckMassivo = myRecord("IdCheckMassivo")
		AnnoRiferimento = myRecord("AnnoRiferimento")
		if not myRecord("FileInputPath") is DBNull.Value then FileInputPath = myRecord("FileInputPath")
		if not myRecord("FileOutputPath") is DBNull.Value then FileOutputPath = myRecord("FileOutputPath")
		IdAzienda = myRecord("IdAzienda")
		if not myRecord("IdUtStep1") is DBNull.Value then IdUtStep1 = myRecord("IdUtStep1")
		if not myRecord("IdUtStep2") is DBNull.Value then IdUtStep2 = myRecord("IdUtStep2")
		MeseRiferimento = myRecord("MeseRiferimento")
		if not myRecord("QuandoStep1") is DBNull.Value then QuandoStep1 = myRecord("QuandoStep1")
		if not myRecord("QuandoStep2") is DBNull.Value then QuandoStep2 = myRecord("QuandoStep2")
		Stato = myRecord("Stato")
		if not myRecord("TipoCheck") is DBNull.Value then TipoCheck = myRecord("TipoCheck")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CheckMassivo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CheckMassiviDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CheckMassivo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCheckMassivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AnnoRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FileInputPath As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FileOutputPath As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdAzienda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUtStep1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdUtStep2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MeseRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property QuandoStep1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property QuandoStep2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoCheck As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCheckMassivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AnnoRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FileInputPath = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FileOutputPath = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdAzienda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUtStep1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdUtStep2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MeseRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.QuandoStep1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.QuandoStep2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoCheck = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCheckMassivo as integer  = 0 
	Public Overridable Property IdCheckMassivo() as integer  Implements _ICheckMassivo.IdCheckMassivo
		Get
			Return _IdCheckMassivo
		End Get
		Set (byval value as integer)
			If _IdCheckMassivo <> value Then
				IsChanged = True
				WhatIsChanged.IdCheckMassivo = True
				_IdCheckMassivo = value
			End If
		End Set
	End property 

	Protected _AnnoRiferimento as integer  = 0 
	Public Overridable Property AnnoRiferimento() as integer  Implements _ICheckMassivo.AnnoRiferimento
		Get
			Return _AnnoRiferimento
		End Get
		Set (byval value as integer)
			If _AnnoRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.AnnoRiferimento = True
				_AnnoRiferimento = value
			End If
		End Set
	End property 

	Protected _FileInputPath as string  = "" 
	Public Overridable Property FileInputPath() as string  Implements _ICheckMassivo.FileInputPath
		Get
			Return _FileInputPath
		End Get
		Set (byval value as string)
			If _FileInputPath <> value Then
				IsChanged = True
				WhatIsChanged.FileInputPath = True
				_FileInputPath = value
			End If
		End Set
	End property 

	Protected _FileOutputPath as string  = "" 
	Public Overridable Property FileOutputPath() as string  Implements _ICheckMassivo.FileOutputPath
		Get
			Return _FileOutputPath
		End Get
		Set (byval value as string)
			If _FileOutputPath <> value Then
				IsChanged = True
				WhatIsChanged.FileOutputPath = True
				_FileOutputPath = value
			End If
		End Set
	End property 

	Protected _IdAzienda as integer  = 0 
	Public Overridable Property IdAzienda() as integer  Implements _ICheckMassivo.IdAzienda
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

	Protected _IdUtStep1 as integer  = 0 
	Public Overridable Property IdUtStep1() as integer  Implements _ICheckMassivo.IdUtStep1
		Get
			Return _IdUtStep1
		End Get
		Set (byval value as integer)
			If _IdUtStep1 <> value Then
				IsChanged = True
				WhatIsChanged.IdUtStep1 = True
				_IdUtStep1 = value
			End If
		End Set
	End property 

	Protected _IdUtStep2 as integer  = 0 
	Public Overridable Property IdUtStep2() as integer  Implements _ICheckMassivo.IdUtStep2
		Get
			Return _IdUtStep2
		End Get
		Set (byval value as integer)
			If _IdUtStep2 <> value Then
				IsChanged = True
				WhatIsChanged.IdUtStep2 = True
				_IdUtStep2 = value
			End If
		End Set
	End property 

	Protected _MeseRiferimento as integer  = 0 
	Public Overridable Property MeseRiferimento() as integer  Implements _ICheckMassivo.MeseRiferimento
		Get
			Return _MeseRiferimento
		End Get
		Set (byval value as integer)
			If _MeseRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.MeseRiferimento = True
				_MeseRiferimento = value
			End If
		End Set
	End property 

	Protected _QuandoStep1 as DateTime  = Nothing 
	Public Overridable Property QuandoStep1() as DateTime  Implements _ICheckMassivo.QuandoStep1
		Get
			Return _QuandoStep1
		End Get
		Set (byval value as DateTime)
			If _QuandoStep1 <> value Then
				IsChanged = True
				WhatIsChanged.QuandoStep1 = True
				_QuandoStep1 = value
			End If
		End Set
	End property 

	Protected _QuandoStep2 as DateTime  = Nothing 
	Public Overridable Property QuandoStep2() as DateTime  Implements _ICheckMassivo.QuandoStep2
		Get
			Return _QuandoStep2
		End Get
		Set (byval value as DateTime)
			If _QuandoStep2 <> value Then
				IsChanged = True
				WhatIsChanged.QuandoStep2 = True
				_QuandoStep2 = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _ICheckMassivo.Stato
		Get
			Return _Stato
		End Get
		Set (byval value as integer)
			If _Stato <> value Then
				IsChanged = True
				WhatIsChanged.Stato = True
				_Stato = value
			End If
		End Set
	End property 

	Protected _TipoCheck as integer  = 0 
	Public Overridable Property TipoCheck() as integer  Implements _ICheckMassivo.TipoCheck
		Get
			Return _TipoCheck
		End Get
		Set (byval value as integer)
			If _TipoCheck <> value Then
				IsChanged = True
				WhatIsChanged.TipoCheck = True
				_TipoCheck = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CheckMassivo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CheckMassivo = Manager.Read(Id)
				_IdCheckMassivo = int.IdCheckMassivo
				_AnnoRiferimento = int.AnnoRiferimento
				_FileInputPath = int.FileInputPath
				_FileOutputPath = int.FileOutputPath
				_IdAzienda = int.IdAzienda
				_IdUtStep1 = int.IdUtStep1
				_IdUtStep2 = int.IdUtStep2
				_MeseRiferimento = int.MeseRiferimento
				_QuandoStep1 = int.QuandoStep1
				_QuandoStep2 = int.QuandoStep2
				_Stato = int.Stato
				_TipoCheck = int.TipoCheck
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CheckMassivo on DB.
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
		if _FileInputPath.Length > 255 then Ris = False
		if _FileOutputPath.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_checkmassivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICheckMassivo

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCheckMassivo() as integer
	Property AnnoRiferimento() as integer
	Property FileInputPath() as string
	Property FileOutputPath() as string
	Property IdAzienda() as integer
	Property IdUtStep1() as integer
	Property IdUtStep2() as integer
	Property MeseRiferimento() as integer
	Property QuandoStep1() as DateTime
	Property QuandoStep2() as DateTime
	Property Stato() as integer
	Property TipoCheck() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CheckMassivo
		Public Shared ReadOnly Property IdCheckMassivo As New LUNA.LunaFieldName("IdCheckMassivo")
		Public Shared ReadOnly Property AnnoRiferimento As New LUNA.LunaFieldName("AnnoRiferimento")
		Public Shared ReadOnly Property FileInputPath As New LUNA.LunaFieldName("FileInputPath")
		Public Shared ReadOnly Property FileOutputPath As New LUNA.LunaFieldName("FileOutputPath")
		Public Shared ReadOnly Property IdAzienda As New LUNA.LunaFieldName("IdAzienda")
		Public Shared ReadOnly Property IdUtStep1 As New LUNA.LunaFieldName("IdUtStep1")
		Public Shared ReadOnly Property IdUtStep2 As New LUNA.LunaFieldName("IdUtStep2")
		Public Shared ReadOnly Property MeseRiferimento As New LUNA.LunaFieldName("MeseRiferimento")
		Public Shared ReadOnly Property QuandoStep1 As New LUNA.LunaFieldName("QuandoStep1")
		Public Shared ReadOnly Property QuandoStep2 As New LUNA.LunaFieldName("QuandoStep2")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property TipoCheck As New LUNA.LunaFieldName("TipoCheck")
	End Class

End Class