#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 07/04/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Tr_gruppovarianterif
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _GruppoVarianteRifW
	Inherits LUNA.LunaBaseClassEntity
	Implements _IGruppoVarianteRifW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IGruppoVarianteRifW.FillFromDataRecord
		IdGruppoVarianteDett = myRecord("IdGruppoVarianteDett")
		IdGruppoVariante = myRecord("IdGruppoVariante")
		if not myRecord("IdListinoBase") is DBNull.Value then IdListinoBase = myRecord("IdListinoBase")
		IdRiferimento = myRecord("IdRiferimento")
		if not myRecord("PercDiminuzione") is DBNull.Value then PercDiminuzione = myRecord("PercDiminuzione")
		TipoRiferimento = myRecord("TipoRiferimento")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of GruppoVarianteRifW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(GruppiVariantiRifWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of GruppoVarianteRifW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdGruppoVarianteDett As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdGruppoVariante As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercDiminuzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdGruppoVarianteDett = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdGruppoVariante = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercDiminuzione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdGruppoVarianteDett as integer  = 0 
	Public Overridable Property IdGruppoVarianteDett() as integer  Implements _IGruppoVarianteRifW.IdGruppoVarianteDett
		Get
			Return _IdGruppoVarianteDett
		End Get
		Set (byval value as integer)
			If _IdGruppoVarianteDett <> value Then
				IsChanged = True
				WhatIsChanged.IdGruppoVarianteDett = True
				_IdGruppoVarianteDett = value
			End If
		End Set
	End property 

	Protected _IdGruppoVariante as integer  = 0 
	Public Overridable Property IdGruppoVariante() as integer  Implements _IGruppoVarianteRifW.IdGruppoVariante
		Get
			Return _IdGruppoVariante
		End Get
		Set (byval value as integer)
			If _IdGruppoVariante <> value Then
				IsChanged = True
				WhatIsChanged.IdGruppoVariante = True
				_IdGruppoVariante = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IGruppoVarianteRifW.IdListinoBase
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

	Protected _IdRiferimento as integer  = 0 
	Public Overridable Property IdRiferimento() as integer  Implements _IGruppoVarianteRifW.IdRiferimento
		Get
			Return _IdRiferimento
		End Get
		Set (byval value as integer)
			If _IdRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.IdRiferimento = True
				_IdRiferimento = value
			End If
		End Set
	End property 

	Protected _PercDiminuzione as integer  = 0 
	Public Overridable Property PercDiminuzione() as integer  Implements _IGruppoVarianteRifW.PercDiminuzione
		Get
			Return _PercDiminuzione
		End Get
		Set (byval value as integer)
			If _PercDiminuzione <> value Then
				IsChanged = True
				WhatIsChanged.PercDiminuzione = True
				_PercDiminuzione = value
			End If
		End Set
	End property 

	Protected _TipoRiferimento as integer  = 0 
	Public Overridable Property TipoRiferimento() as integer  Implements _IGruppoVarianteRifW.TipoRiferimento
		Get
			Return _TipoRiferimento
		End Get
		Set (byval value as integer)
			If _TipoRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.TipoRiferimento = True
				_TipoRiferimento = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an GruppoVarianteRifW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As GruppoVarianteRifW = Manager.Read(Id)
				_IdGruppoVarianteDett = int.IdGruppoVarianteDett
				_IdGruppoVariante = int.IdGruppoVariante
				_IdListinoBase = int.IdListinoBase
				_IdRiferimento = int.IdRiferimento
				_PercDiminuzione = int.PercDiminuzione
				_TipoRiferimento = int.TipoRiferimento
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
        If IdGruppoVarianteDett Then
            ris = Read(IdGruppoVarianteDett)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an GruppoVarianteRifW on DB.
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
'''Interface for table Tr_gruppovarianterif
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IGruppoVarianteRifW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdGruppoVarianteDett() as integer
	Property IdGruppoVariante() as integer
	Property IdListinoBase() as integer
	Property IdRiferimento() as integer
	Property PercDiminuzione() as integer
	Property TipoRiferimento() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class GruppoVarianteRifW
		Public Shared ReadOnly Property IdGruppoVarianteDett As New LUNA.LunaFieldName("IdGruppoVarianteDett")
		Public Shared ReadOnly Property IdGruppoVariante As New LUNA.LunaFieldName("IdGruppoVariante")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdRiferimento As New LUNA.LunaFieldName("IdRiferimento")
		Public Shared ReadOnly Property PercDiminuzione As New LUNA.LunaFieldName("PercDiminuzione")
		Public Shared ReadOnly Property TipoRiferimento As New LUNA.LunaFieldName("TipoRiferimento")
	End Class

End Class