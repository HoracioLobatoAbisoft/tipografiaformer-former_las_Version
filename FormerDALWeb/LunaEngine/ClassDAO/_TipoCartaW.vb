#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 11/03/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Td_tipocarta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _TipoCartaW
	Inherits LUNA.LunaBaseClassEntity
	Implements _ITipoCartaW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ITipoCartaW.FillFromDataRecord
		IdTipoCarta = myRecord("IdTipoCarta")
		if not myRecord("Altezza") is DBNull.Value then Altezza = myRecord("Altezza")
		if not myRecord("CostoCartaKg") is DBNull.Value then CostoCartaKg = myRecord("CostoCartaKg")
		if not myRecord("CostoRiferimento") is DBNull.Value then CostoRiferimento = myRecord("CostoRiferimento")
		if not myRecord("DescrizioneEstesa") is DBNull.Value then DescrizioneEstesa = myRecord("DescrizioneEstesa")
		if not myRecord("Finitura") is DBNull.Value then Finitura = myRecord("Finitura")
		if not myRecord("Grammi") is DBNull.Value then Grammi = myRecord("Grammi")
		if not myRecord("HotFolder") is DBNull.Value then HotFolder = myRecord("HotFolder")
		if not myRecord("ImgRif") is DBNull.Value then ImgRif = myRecord("ImgRif")
		if not myRecord("Larghezza") is DBNull.Value then Larghezza = myRecord("Larghezza")
		if not myRecord("Sigla") is DBNull.Value then Sigla = myRecord("Sigla")
		if not myRecord("Spessore") is DBNull.Value then Spessore = myRecord("Spessore")
		if not myRecord("TipoCarta") is DBNull.Value then TipoCarta = myRecord("TipoCarta")
		if not myRecord("TipoCosto") is DBNull.Value then TipoCosto = myRecord("TipoCosto")
		if not myRecord("Tipologia") is DBNull.Value then Tipologia = myRecord("Tipologia")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of TipoCartaW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(TipiCartaWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of TipoCartaW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdTipoCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Altezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoCartaKg As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoRiferimento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrizioneEstesa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Finitura As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Grammi As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property HotFolder As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Larghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sigla As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Spessore As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipologia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdTipoCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Altezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoCartaKg = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoRiferimento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrizioneEstesa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Finitura = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Grammi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.HotFolder = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Larghezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sigla = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Spessore = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoCosto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipologia = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdTipoCarta as integer  = 0 
	Public Overridable Property IdTipoCarta() as integer  Implements _ITipoCartaW.IdTipoCarta
		Get
			Return _IdTipoCarta
		End Get
		Set (byval value as integer)
			If _IdTipoCarta <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoCarta = True
				_IdTipoCarta = value
			End If
		End Set
	End property 

	Protected _Altezza as integer  = 0 
	Public Overridable Property Altezza() as integer  Implements _ITipoCartaW.Altezza
		Get
			Return _Altezza
		End Get
		Set (byval value as integer)
			If _Altezza <> value Then
				IsChanged = True
				WhatIsChanged.Altezza = True
				_Altezza = value
			End If
		End Set
	End property 

	Protected _CostoCartaKg as decimal  = 0 
	Public Overridable Property CostoCartaKg() as decimal  Implements _ITipoCartaW.CostoCartaKg
		Get
			Return _CostoCartaKg
		End Get
		Set (byval value as decimal)
			If _CostoCartaKg <> value Then
				IsChanged = True
				WhatIsChanged.CostoCartaKg = True
				_CostoCartaKg = value
			End If
		End Set
	End property 

	Protected _CostoRiferimento as decimal  = 0 
	Public Overridable Property CostoRiferimento() as decimal  Implements _ITipoCartaW.CostoRiferimento
		Get
			Return _CostoRiferimento
		End Get
		Set (byval value as decimal)
			If _CostoRiferimento <> value Then
				IsChanged = True
				WhatIsChanged.CostoRiferimento = True
				_CostoRiferimento = value
			End If
		End Set
	End property 

	Protected _DescrizioneEstesa as string  = "" 
	Public Overridable Property DescrizioneEstesa() as string  Implements _ITipoCartaW.DescrizioneEstesa
		Get
			Return _DescrizioneEstesa
		End Get
		Set (byval value as string)
			If _DescrizioneEstesa <> value Then
				IsChanged = True
				WhatIsChanged.DescrizioneEstesa = True
				_DescrizioneEstesa = value
			End If
		End Set
	End property 

	Protected _Finitura as string  = "" 
	Public Overridable Property Finitura() as string  Implements _ITipoCartaW.Finitura
		Get
			Return _Finitura
		End Get
		Set (byval value as string)
			If _Finitura <> value Then
				IsChanged = True
				WhatIsChanged.Finitura = True
				_Finitura = value
			End If
		End Set
	End property 

	Protected _Grammi as integer  = 0 
	Public Overridable Property Grammi() as integer  Implements _ITipoCartaW.Grammi
		Get
			Return _Grammi
		End Get
		Set (byval value as integer)
			If _Grammi <> value Then
				IsChanged = True
				WhatIsChanged.Grammi = True
				_Grammi = value
			End If
		End Set
	End property 

	Protected _HotFolder as string  = "" 
	Public Overridable Property HotFolder() as string  Implements _ITipoCartaW.HotFolder
		Get
			Return _HotFolder
		End Get
		Set (byval value as string)
			If _HotFolder <> value Then
				IsChanged = True
				WhatIsChanged.HotFolder = True
				_HotFolder = value
			End If
		End Set
	End property 

	Protected _ImgRif as string  = "" 
	Public Overridable Property ImgRif() as string  Implements _ITipoCartaW.ImgRif
		Get
			Return _ImgRif
		End Get
		Set (byval value as string)
			If _ImgRif <> value Then
				IsChanged = True
				WhatIsChanged.ImgRif = True
				_ImgRif = value
			End If
		End Set
	End property 

	Protected _Larghezza as integer  = 0 
	Public Overridable Property Larghezza() as integer  Implements _ITipoCartaW.Larghezza
		Get
			Return _Larghezza
		End Get
		Set (byval value as integer)
			If _Larghezza <> value Then
				IsChanged = True
				WhatIsChanged.Larghezza = True
				_Larghezza = value
			End If
		End Set
	End property 

	Protected _Sigla as string  = "" 
	Public Overridable Property Sigla() as string  Implements _ITipoCartaW.Sigla
		Get
			Return _Sigla
		End Get
		Set (byval value as string)
			If _Sigla <> value Then
				IsChanged = True
				WhatIsChanged.Sigla = True
				_Sigla = value
			End If
		End Set
	End property 

	Protected _Spessore as Single  = 0 
	Public Overridable Property Spessore() as Single  Implements _ITipoCartaW.Spessore
		Get
			Return _Spessore
		End Get
		Set (byval value as Single)
			If _Spessore <> value Then
				IsChanged = True
				WhatIsChanged.Spessore = True
				_Spessore = value
			End If
		End Set
	End property 

	Protected _TipoCarta as integer  = 0 
	Public Overridable Property TipoCarta() as integer  Implements _ITipoCartaW.TipoCarta
		Get
			Return _TipoCarta
		End Get
		Set (byval value as integer)
			If _TipoCarta <> value Then
				IsChanged = True
				WhatIsChanged.TipoCarta = True
				_TipoCarta = value
			End If
		End Set
	End property 

	Protected _TipoCosto as integer  = 0 
	Public Overridable Property TipoCosto() as integer  Implements _ITipoCartaW.TipoCosto
		Get
			Return _TipoCosto
		End Get
		Set (byval value as integer)
			If _TipoCosto <> value Then
				IsChanged = True
				WhatIsChanged.TipoCosto = True
				_TipoCosto = value
			End If
		End Set
	End property 

	Protected _Tipologia as string  = "" 
	Public Overridable Property Tipologia() as string  Implements _ITipoCartaW.Tipologia
		Get
			Return _Tipologia
		End Get
		Set (byval value as string)
			If _Tipologia <> value Then
				IsChanged = True
				WhatIsChanged.Tipologia = True
				_Tipologia = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an TipoCartaW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As TipoCartaW = Manager.Read(Id)
				_IdTipoCarta = int.IdTipoCarta
				_Altezza = int.Altezza
				_CostoCartaKg = int.CostoCartaKg
				_CostoRiferimento = int.CostoRiferimento
				_DescrizioneEstesa = int.DescrizioneEstesa
				_Finitura = int.Finitura
				_Grammi = int.Grammi
				_HotFolder = int.HotFolder
				_ImgRif = int.ImgRif
				_Larghezza = int.Larghezza
				_Sigla = int.Sigla
				_Spessore = int.Spessore
				_TipoCarta = int.TipoCarta
				_TipoCosto = int.TipoCosto
				_Tipologia = int.Tipologia
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an TipoCartaW on DB.
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
		if _DescrizioneEstesa.Length > 255 then Ris = False
		if _Finitura.Length > 255 then Ris = False
		if _HotFolder.Length > 255 then Ris = False
		if _ImgRif.Length > 255 then Ris = False
		if _Sigla.Length > 255 then Ris = False
		if _Tipologia.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_tipocarta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITipoCartaW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdTipoCarta() as integer
	Property Altezza() as integer
	Property CostoCartaKg() as decimal
	Property CostoRiferimento() as decimal
	Property DescrizioneEstesa() as string
	Property Finitura() as string
	Property Grammi() as integer
	Property HotFolder() as string
	Property ImgRif() as string
	Property Larghezza() as integer
	Property Sigla() as string
	Property Spessore() as Single
	Property TipoCarta() as integer
	Property TipoCosto() as integer
	Property Tipologia() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class TipoCartaW
		Public Shared ReadOnly Property IdTipoCarta As New LUNA.LunaFieldName("IdTipoCarta")
		Public Shared ReadOnly Property Altezza As New LUNA.LunaFieldName("Altezza")
		Public Shared ReadOnly Property CostoCartaKg As New LUNA.LunaFieldName("CostoCartaKg")
		Public Shared ReadOnly Property CostoRiferimento As New LUNA.LunaFieldName("CostoRiferimento")
		Public Shared ReadOnly Property DescrizioneEstesa As New LUNA.LunaFieldName("DescrizioneEstesa")
		Public Shared ReadOnly Property Finitura As New LUNA.LunaFieldName("Finitura")
		Public Shared ReadOnly Property Grammi As New LUNA.LunaFieldName("Grammi")
		Public Shared ReadOnly Property HotFolder As New LUNA.LunaFieldName("HotFolder")
		Public Shared ReadOnly Property ImgRif As New LUNA.LunaFieldName("ImgRif")
		Public Shared ReadOnly Property Larghezza As New LUNA.LunaFieldName("Larghezza")
		Public Shared ReadOnly Property Sigla As New LUNA.LunaFieldName("Sigla")
		Public Shared ReadOnly Property Spessore As New LUNA.LunaFieldName("Spessore")
		Public Shared ReadOnly Property TipoCarta As New LUNA.LunaFieldName("TipoCarta")
		Public Shared ReadOnly Property TipoCosto As New LUNA.LunaFieldName("TipoCosto")
		Public Shared ReadOnly Property Tipologia As New LUNA.LunaFieldName("Tipologia")
	End Class

End Class