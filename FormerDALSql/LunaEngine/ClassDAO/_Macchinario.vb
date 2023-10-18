#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 28/01/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_macchinari
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Macchinario
	Inherits LUNA.LunaBaseClassEntity
	Implements _IMacchinario
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IMacchinario.FillFromDataRecord
		IdMacchinario = myRecord("IdMacchinario")
		if not myRecord("AlertCommesse") is DBNull.Value then AlertCommesse = myRecord("AlertCommesse")
		if not myRecord("AltezzaCaricoCm") is DBNull.Value then AltezzaCaricoCm = myRecord("AltezzaCaricoCm")
		if not myRecord("CaricoPrevistoMensile") is DBNull.Value then CaricoPrevistoMensile = myRecord("CaricoPrevistoMensile")
		if not myRecord("CopieOra") is DBNull.Value then CopieOra = myRecord("CopieOra")
		if not myRecord("CostoMensile") is DBNull.Value then CostoMensile = myRecord("CostoMensile")
		if not myRecord("CostoMinAvv") is DBNull.Value then CostoMinAvv = myRecord("CostoMinAvv")
		if not myRecord("CostoSingCopia") is DBNull.Value then CostoSingCopia = myRecord("CostoSingCopia")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("DescrizioneEstesa") is DBNull.Value then DescrizioneEstesa = myRecord("DescrizioneEstesa")
		if not myRecord("DescrizioneOnline") is DBNull.Value then DescrizioneOnline = myRecord("DescrizioneOnline")
		if not myRecord("HotFolderFlusso") is DBNull.Value then HotFolderFlusso = myRecord("HotFolderFlusso")
		if not myRecord("IdRepartoDefault") is DBNull.Value then IdRepartoDefault = myRecord("IdRepartoDefault")
		if not myRecord("ImgBig") is DBNull.Value then ImgBig = myRecord("ImgBig")
		if not myRecord("ImgRif") is DBNull.Value then ImgRif = myRecord("ImgRif")
		if not myRecord("MinutiAvv") is DBNull.Value then MinutiAvv = myRecord("MinutiAvv")
		if not myRecord("Ordinamento") is DBNull.Value then Ordinamento = myRecord("Ordinamento")
		if not myRecord("Tipo") is DBNull.Value then Tipo = myRecord("Tipo")
		if not myRecord("VisibileOnline") is DBNull.Value then VisibileOnline = myRecord("VisibileOnline")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Macchinario)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(MacchinariDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Macchinario))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdMacchinario As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AlertCommesse As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AltezzaCaricoCm As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CaricoPrevistoMensile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CopieOra As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoMensile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoMinAvv As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoSingCopia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrizioneEstesa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrizioneOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property HotFolderFlusso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRepartoDefault As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgBig As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MinutiAvv As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ordinamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property VisibileOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdMacchinario = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AlertCommesse = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AltezzaCaricoCm = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CaricoPrevistoMensile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CopieOra = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoMensile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoMinAvv = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoSingCopia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrizioneEstesa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrizioneOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.HotFolderFlusso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRepartoDefault = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgBig = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MinutiAvv = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ordinamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.VisibileOnline = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdMacchinario as integer  = 0 
	Public Overridable Property IdMacchinario() as integer  Implements _IMacchinario.IdMacchinario
		Get
			Return _IdMacchinario
		End Get
		Set (byval value as integer)
			If _IdMacchinario <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinario = True
				_IdMacchinario = value
			End If
		End Set
	End property 

	Protected _AlertCommesse as integer  = 0 
	Public Overridable Property AlertCommesse() as integer  Implements _IMacchinario.AlertCommesse
		Get
			Return _AlertCommesse
		End Get
		Set (byval value as integer)
			If _AlertCommesse <> value Then
				IsChanged = True
				WhatIsChanged.AlertCommesse = True
				_AlertCommesse = value
			End If
		End Set
	End property 

	Protected _AltezzaCaricoCm as integer  = 0 
	Public Overridable Property AltezzaCaricoCm() as integer  Implements _IMacchinario.AltezzaCaricoCm
		Get
			Return _AltezzaCaricoCm
		End Get
		Set (byval value as integer)
			If _AltezzaCaricoCm <> value Then
				IsChanged = True
				WhatIsChanged.AltezzaCaricoCm = True
				_AltezzaCaricoCm = value
			End If
		End Set
	End property 

	Protected _CaricoPrevistoMensile as integer  = 0 
	Public Overridable Property CaricoPrevistoMensile() as integer  Implements _IMacchinario.CaricoPrevistoMensile
		Get
			Return _CaricoPrevistoMensile
		End Get
		Set (byval value as integer)
			If _CaricoPrevistoMensile <> value Then
				IsChanged = True
				WhatIsChanged.CaricoPrevistoMensile = True
				_CaricoPrevistoMensile = value
			End If
		End Set
	End property 

	Protected _CopieOra as integer  = 0 
	Public Overridable Property CopieOra() as integer  Implements _IMacchinario.CopieOra
		Get
			Return _CopieOra
		End Get
		Set (byval value as integer)
			If _CopieOra <> value Then
				IsChanged = True
				WhatIsChanged.CopieOra = True
				_CopieOra = value
			End If
		End Set
	End property 

	Protected _CostoMensile as integer  = 0 
	Public Overridable Property CostoMensile() as integer  Implements _IMacchinario.CostoMensile
		Get
			Return _CostoMensile
		End Get
		Set (byval value as integer)
			If _CostoMensile <> value Then
				IsChanged = True
				WhatIsChanged.CostoMensile = True
				_CostoMensile = value
			End If
		End Set
	End property 

	Protected _CostoMinAvv as decimal  = 0 
	Public Overridable Property CostoMinAvv() as decimal  Implements _IMacchinario.CostoMinAvv
		Get
			Return _CostoMinAvv
		End Get
		Set (byval value as decimal)
			If _CostoMinAvv <> value Then
				IsChanged = True
				WhatIsChanged.CostoMinAvv = True
				_CostoMinAvv = value
			End If
		End Set
	End property 

	Protected _CostoSingCopia as decimal  = 0 
	Public Overridable Property CostoSingCopia() as decimal  Implements _IMacchinario.CostoSingCopia
		Get
			Return _CostoSingCopia
		End Get
		Set (byval value as decimal)
			If _CostoSingCopia <> value Then
				IsChanged = True
				WhatIsChanged.CostoSingCopia = True
				_CostoSingCopia = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IMacchinario.Descrizione
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

	Protected _DescrizioneEstesa as string  = "" 
	Public Overridable Property DescrizioneEstesa() as string  Implements _IMacchinario.DescrizioneEstesa
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

	Protected _DescrizioneOnline as string  = "" 
	Public Overridable Property DescrizioneOnline() as string  Implements _IMacchinario.DescrizioneOnline
		Get
			Return _DescrizioneOnline
		End Get
		Set (byval value as string)
			If _DescrizioneOnline <> value Then
				IsChanged = True
				WhatIsChanged.DescrizioneOnline = True
				_DescrizioneOnline = value
			End If
		End Set
	End property 

	Protected _HotFolderFlusso as string  = "" 
	Public Overridable Property HotFolderFlusso() as string  Implements _IMacchinario.HotFolderFlusso
		Get
			Return _HotFolderFlusso
		End Get
		Set (byval value as string)
			If _HotFolderFlusso <> value Then
				IsChanged = True
				WhatIsChanged.HotFolderFlusso = True
				_HotFolderFlusso = value
			End If
		End Set
	End property 

	Protected _IdRepartoDefault as integer  = 0 
	Public Overridable Property IdRepartoDefault() as integer  Implements _IMacchinario.IdRepartoDefault
		Get
			Return _IdRepartoDefault
		End Get
		Set (byval value as integer)
			If _IdRepartoDefault <> value Then
				IsChanged = True
				WhatIsChanged.IdRepartoDefault = True
				_IdRepartoDefault = value
			End If
		End Set
	End property 

	Protected _ImgBig as string  = "" 
	Public Overridable Property ImgBig() as string  Implements _IMacchinario.ImgBig
		Get
			Return _ImgBig
		End Get
		Set (byval value as string)
			If _ImgBig <> value Then
				IsChanged = True
				WhatIsChanged.ImgBig = True
				_ImgBig = value
			End If
		End Set
	End property 

	Protected _ImgRif as string  = "" 
	Public Overridable Property ImgRif() as string  Implements _IMacchinario.ImgRif
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

	Protected _MinutiAvv as integer  = 0 
	Public Overridable Property MinutiAvv() as integer  Implements _IMacchinario.MinutiAvv
		Get
			Return _MinutiAvv
		End Get
		Set (byval value as integer)
			If _MinutiAvv <> value Then
				IsChanged = True
				WhatIsChanged.MinutiAvv = True
				_MinutiAvv = value
			End If
		End Set
	End property 

	Protected _Ordinamento as integer  = 0 
	Public Overridable Property Ordinamento() as integer  Implements _IMacchinario.Ordinamento
		Get
			Return _Ordinamento
		End Get
		Set (byval value as integer)
			If _Ordinamento <> value Then
				IsChanged = True
				WhatIsChanged.Ordinamento = True
				_Ordinamento = value
			End If
		End Set
	End property 

	Protected _Tipo as integer  = 0 
	Public Overridable Property Tipo() as integer  Implements _IMacchinario.Tipo
		Get
			Return _Tipo
		End Get
		Set (byval value as integer)
			If _Tipo <> value Then
				IsChanged = True
				WhatIsChanged.Tipo = True
				_Tipo = value
			End If
		End Set
	End property 

	Protected _VisibileOnline as integer  = 0 
	Public Overridable Property VisibileOnline() as integer  Implements _IMacchinario.VisibileOnline
		Get
			Return _VisibileOnline
		End Get
		Set (byval value as integer)
			If _VisibileOnline <> value Then
				IsChanged = True
				WhatIsChanged.VisibileOnline = True
				_VisibileOnline = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Macchinario from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Macchinario = Manager.Read(Id)
				_IdMacchinario = int.IdMacchinario
				_AlertCommesse = int.AlertCommesse
				_AltezzaCaricoCm = int.AltezzaCaricoCm
				_CaricoPrevistoMensile = int.CaricoPrevistoMensile
				_CopieOra = int.CopieOra
				_CostoMensile = int.CostoMensile
				_CostoMinAvv = int.CostoMinAvv
				_CostoSingCopia = int.CostoSingCopia
				_Descrizione = int.Descrizione
				_DescrizioneEstesa = int.DescrizioneEstesa
				_DescrizioneOnline = int.DescrizioneOnline
				_HotFolderFlusso = int.HotFolderFlusso
				_IdRepartoDefault = int.IdRepartoDefault
				_ImgBig = int.ImgBig
				_ImgRif = int.ImgRif
				_MinutiAvv = int.MinutiAvv
				_Ordinamento = int.Ordinamento
				_Tipo = int.Tipo
				_VisibileOnline = int.VisibileOnline
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
        If IdMacchinario Then
            ris = Read(IdMacchinario)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an Macchinario on DB.
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
		if _Descrizione.Length > 255 then Ris = False
		if _DescrizioneEstesa.Length > 1000 then Ris = False
		if _DescrizioneOnline.Length > 255 then Ris = False
		if _HotFolderFlusso.Length > 255 then Ris = False
		if _ImgBig.Length > 255 then Ris = False
		if _ImgRif.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_macchinari
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IMacchinario

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdMacchinario() as integer
	Property AlertCommesse() as integer
	Property AltezzaCaricoCm() as integer
	Property CaricoPrevistoMensile() as integer
	Property CopieOra() as integer
	Property CostoMensile() as integer
	Property CostoMinAvv() as decimal
	Property CostoSingCopia() as decimal
	Property Descrizione() as string
	Property DescrizioneEstesa() as string
	Property DescrizioneOnline() as string
	Property HotFolderFlusso() as string
	Property IdRepartoDefault() as integer
	Property ImgBig() as string
	Property ImgRif() as string
	Property MinutiAvv() as integer
	Property Ordinamento() as integer
	Property Tipo() as integer
	Property VisibileOnline() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Macchinario
		Public Shared ReadOnly Property IdMacchinario As New LUNA.LunaFieldName("IdMacchinario")
		Public Shared ReadOnly Property AlertCommesse As New LUNA.LunaFieldName("AlertCommesse")
		Public Shared ReadOnly Property AltezzaCaricoCm As New LUNA.LunaFieldName("AltezzaCaricoCm")
		Public Shared ReadOnly Property CaricoPrevistoMensile As New LUNA.LunaFieldName("CaricoPrevistoMensile")
		Public Shared ReadOnly Property CopieOra As New LUNA.LunaFieldName("CopieOra")
		Public Shared ReadOnly Property CostoMensile As New LUNA.LunaFieldName("CostoMensile")
		Public Shared ReadOnly Property CostoMinAvv As New LUNA.LunaFieldName("CostoMinAvv")
		Public Shared ReadOnly Property CostoSingCopia As New LUNA.LunaFieldName("CostoSingCopia")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property DescrizioneEstesa As New LUNA.LunaFieldName("DescrizioneEstesa")
		Public Shared ReadOnly Property DescrizioneOnline As New LUNA.LunaFieldName("DescrizioneOnline")
		Public Shared ReadOnly Property HotFolderFlusso As New LUNA.LunaFieldName("HotFolderFlusso")
		Public Shared ReadOnly Property IdRepartoDefault As New LUNA.LunaFieldName("IdRepartoDefault")
		Public Shared ReadOnly Property ImgBig As New LUNA.LunaFieldName("ImgBig")
		Public Shared ReadOnly Property ImgRif As New LUNA.LunaFieldName("ImgRif")
		Public Shared ReadOnly Property MinutiAvv As New LUNA.LunaFieldName("MinutiAvv")
		Public Shared ReadOnly Property Ordinamento As New LUNA.LunaFieldName("Ordinamento")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
		Public Shared ReadOnly Property VisibileOnline As New LUNA.LunaFieldName("VisibileOnline")
	End Class

End Class