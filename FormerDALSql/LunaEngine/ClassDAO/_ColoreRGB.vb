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
'''DAO Class for table T_colori
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ColoreRGB
	Inherits LUNA.LunaBaseClassEntity
	Implements _IColoreRGB
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IColoreRGB.FillFromDataRecord
		IdColore = myRecord("IdColore")
		if not myRecord("Alpha") is DBNull.Value then Alpha = myRecord("Alpha")
		if not myRecord("Attivo") is DBNull.Value then Attivo = myRecord("Attivo")
		if not myRecord("B") is DBNull.Value then B = myRecord("B")
		if not myRecord("G") is DBNull.Value then G = myRecord("G")
		if not myRecord("ImportoMillePunti") is DBNull.Value then ImportoMillePunti = myRecord("ImportoMillePunti")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("R") is DBNull.Value then R = myRecord("R")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ColoreRGB)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ColoriRGBDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ColoreRGB))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdColore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Alpha As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Attivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property B As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property G As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoMillePunti As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property R As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdColore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Alpha = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Attivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.B = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.G = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoMillePunti = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.R = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdColore as integer  = 0 
	Public Overridable Property IdColore() as integer  Implements _IColoreRGB.IdColore
		Get
			Return _IdColore
		End Get
		Set (byval value as integer)
			If _IdColore <> value Then
				IsChanged = True
				WhatIsChanged.IdColore = True
				_IdColore = value
			End If
		End Set
	End property 

	Protected _Alpha as integer  = 0 
	Public Overridable Property Alpha() as integer  Implements _IColoreRGB.Alpha
		Get
			Return _Alpha
		End Get
		Set (byval value as integer)
			If _Alpha <> value Then
				IsChanged = True
				WhatIsChanged.Alpha = True
				_Alpha = value
			End If
		End Set
	End property 

	Protected _Attivo as integer  = 0 
	Public Overridable Property Attivo() as integer  Implements _IColoreRGB.Attivo
		Get
			Return _Attivo
		End Get
		Set (byval value as integer)
			If _Attivo <> value Then
				IsChanged = True
				WhatIsChanged.Attivo = True
				_Attivo = value
			End If
		End Set
	End property 

	Protected _B as integer  = 0 
	Public Overridable Property B() as integer  Implements _IColoreRGB.B
		Get
			Return _B
		End Get
		Set (byval value as integer)
			If _B <> value Then
				IsChanged = True
				WhatIsChanged.B = True
				_B = value
			End If
		End Set
	End property 

	Protected _G as integer  = 0 
	Public Overridable Property G() as integer  Implements _IColoreRGB.G
		Get
			Return _G
		End Get
		Set (byval value as integer)
			If _G <> value Then
				IsChanged = True
				WhatIsChanged.G = True
				_G = value
			End If
		End Set
	End property 

	Protected _ImportoMillePunti as Single  = 0 
	Public Overridable Property ImportoMillePunti() as Single  Implements _IColoreRGB.ImportoMillePunti
		Get
			Return _ImportoMillePunti
		End Get
		Set (byval value as Single)
			If _ImportoMillePunti <> value Then
				IsChanged = True
				WhatIsChanged.ImportoMillePunti = True
				_ImportoMillePunti = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IColoreRGB.Nome
		Get
			Return _Nome
		End Get
		Set (byval value as string)
			If _Nome <> value Then
				IsChanged = True
				WhatIsChanged.Nome = True
				_Nome = value
			End If
		End Set
	End property 

	Protected _R as integer  = 0 
	Public Overridable Property R() as integer  Implements _IColoreRGB.R
		Get
			Return _R
		End Get
		Set (byval value as integer)
			If _R <> value Then
				IsChanged = True
				WhatIsChanged.R = True
				_R = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ColoreRGB from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ColoreRGB = Manager.Read(Id)
				_IdColore = int.IdColore
				_Alpha = int.Alpha
				_Attivo = int.Attivo
				_B = int.B
				_G = int.G
				_ImportoMillePunti = int.ImportoMillePunti
				_Nome = int.Nome
				_R = int.R
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ColoreRGB on DB.
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
		if _Nome.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_colori
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IColoreRGB

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdColore() as integer
	Property Alpha() as integer
	Property Attivo() as integer
	Property B() as integer
	Property G() as integer
	Property ImportoMillePunti() as Single
	Property Nome() as string
	Property R() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ColoreRGB
		Public Shared ReadOnly Property IdColore As New LUNA.LunaFieldName("IdColore")
		Public Shared ReadOnly Property Alpha As New LUNA.LunaFieldName("Alpha")
		Public Shared ReadOnly Property Attivo As New LUNA.LunaFieldName("Attivo")
		Public Shared ReadOnly Property B As New LUNA.LunaFieldName("B")
		Public Shared ReadOnly Property G As New LUNA.LunaFieldName("G")
		Public Shared ReadOnly Property ImportoMillePunti As New LUNA.LunaFieldName("ImportoMillePunti")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property R As New LUNA.LunaFieldName("R")
	End Class

End Class