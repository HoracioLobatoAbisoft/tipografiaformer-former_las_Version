#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_tipofustella
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _TipoFustellaW
	Inherits LUNA.LunaBaseClassEntity
	Implements _ITipoFustellaW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ITipoFustellaW.FillFromDataRecord
		IdTipoFustella = myRecord("IdTipoFustella")
		if not myRecord("Altezza") is DBNull.Value then Altezza = myRecord("Altezza")
		if not myRecord("Base") is DBNull.Value then Base = myRecord("Base")
		if not myRecord("CODICE") is DBNull.Value then CODICE = myRecord("CODICE")
		if not myRecord("Disponibile") is DBNull.Value then Disponibile = myRecord("Disponibile")
		if not myRecord("IdCatFustella") is DBNull.Value then IdCatFustella = myRecord("IdCatFustella")
		if not myRecord("IdPrev") is DBNull.Value then IdPrev = myRecord("IdPrev")
		if not myRecord("ImgRif") is DBNull.Value then ImgRif = myRecord("ImgRif")
		if not myRecord("Orientabile") is DBNull.Value then Orientabile = myRecord("Orientabile")
		if not myRecord("Profondita") is DBNull.Value then Profondita = myRecord("Profondita")
		if not myRecord("TEMPLATEPDF") is DBNull.Value then TEMPLATEPDF = myRecord("TEMPLATEPDF")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of TipoFustellaW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(TipiFustellaWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of TipoFustellaW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdTipoFustella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Altezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Base As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CODICE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Disponibile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatFustella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Orientabile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Profondita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TEMPLATEPDF As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdTipoFustella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Altezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Base = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CODICE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Disponibile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatFustella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Orientabile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Profondita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TEMPLATEPDF = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdTipoFustella as integer  = 0 
	Public Overridable Property IdTipoFustella() as integer  Implements _ITipoFustellaW.IdTipoFustella
		Get
			Return _IdTipoFustella
		End Get
		Set (byval value as integer)
			If _IdTipoFustella <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoFustella = True
				_IdTipoFustella = value
			End If
		End Set
	End property 

	Protected _Altezza as integer  = 0 
	Public Overridable Property Altezza() as integer  Implements _ITipoFustellaW.Altezza
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

	Protected _Base as integer  = 0 
	Public Overridable Property Base() as integer  Implements _ITipoFustellaW.Base
		Get
			Return _Base
		End Get
		Set (byval value as integer)
			If _Base <> value Then
				IsChanged = True
				WhatIsChanged.Base = True
				_Base = value
			End If
		End Set
	End property 

	Protected _CODICE as string  = "" 
	Public Overridable Property CODICE() as string  Implements _ITipoFustellaW.CODICE
		Get
			Return _CODICE
		End Get
		Set (byval value as string)
			If _CODICE <> value Then
				IsChanged = True
				WhatIsChanged.CODICE = True
				_CODICE = value
			End If
		End Set
	End property 

	Protected _Disponibile as integer  = 0 
	Public Overridable Property Disponibile() as integer  Implements _ITipoFustellaW.Disponibile
		Get
			Return _Disponibile
		End Get
		Set (byval value as integer)
			If _Disponibile <> value Then
				IsChanged = True
				WhatIsChanged.Disponibile = True
				_Disponibile = value
			End If
		End Set
	End property 

	Protected _IdCatFustella as integer  = 0 
	Public Overridable Property IdCatFustella() as integer  Implements _ITipoFustellaW.IdCatFustella
		Get
			Return _IdCatFustella
		End Get
		Set (byval value as integer)
			If _IdCatFustella <> value Then
				IsChanged = True
				WhatIsChanged.IdCatFustella = True
				_IdCatFustella = value
			End If
		End Set
	End property 

	Protected _IdPrev as integer  = 0 
	Public Overridable Property IdPrev() as integer  Implements _ITipoFustellaW.IdPrev
		Get
			Return _IdPrev
		End Get
		Set (byval value as integer)
			If _IdPrev <> value Then
				IsChanged = True
				WhatIsChanged.IdPrev = True
				_IdPrev = value
			End If
		End Set
	End property 

	Protected _ImgRif as string  = "" 
	Public Overridable Property ImgRif() as string  Implements _ITipoFustellaW.ImgRif
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

	Protected _Orientabile as integer  = 0 
	Public Overridable Property Orientabile() as integer  Implements _ITipoFustellaW.Orientabile
		Get
			Return _Orientabile
		End Get
		Set (byval value as integer)
			If _Orientabile <> value Then
				IsChanged = True
				WhatIsChanged.Orientabile = True
				_Orientabile = value
			End If
		End Set
	End property 

	Protected _Profondita as integer  = 0 
	Public Overridable Property Profondita() as integer  Implements _ITipoFustellaW.Profondita
		Get
			Return _Profondita
		End Get
		Set (byval value as integer)
			If _Profondita <> value Then
				IsChanged = True
				WhatIsChanged.Profondita = True
				_Profondita = value
			End If
		End Set
	End property 

	Protected _TEMPLATEPDF as string  = "" 
	Public Overridable Property TEMPLATEPDF() as string  Implements _ITipoFustellaW.TEMPLATEPDF
		Get
			Return _TEMPLATEPDF
		End Get
		Set (byval value as string)
			If _TEMPLATEPDF <> value Then
				IsChanged = True
				WhatIsChanged.TEMPLATEPDF = True
				_TEMPLATEPDF = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an TipoFustellaW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As TipoFustellaW = Manager.Read(Id)
				_IdTipoFustella = int.IdTipoFustella
				_Altezza = int.Altezza
				_Base = int.Base
				_CODICE = int.CODICE
				_Disponibile = int.Disponibile
				_IdCatFustella = int.IdCatFustella
				_IdPrev = int.IdPrev
				_ImgRif = int.ImgRif
				_Orientabile = int.Orientabile
				_Profondita = int.Profondita
				_TEMPLATEPDF = int.TEMPLATEPDF
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an TipoFustellaW on DB.
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
		if _CODICE.Length > 50 then Ris = False
		if _ImgRif.Length > 255 then Ris = False
		if _TEMPLATEPDF.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_tipofustella
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITipoFustellaW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdTipoFustella() as integer
	Property Altezza() as integer
	Property Base() as integer
	Property CODICE() as string
	Property Disponibile() as integer
	Property IdCatFustella() as integer
	Property IdPrev() as integer
	Property ImgRif() as string
	Property Orientabile() as integer
	Property Profondita() as integer
	Property TEMPLATEPDF() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class TipoFustellaW
		Public Shared ReadOnly Property IdTipoFustella As New LUNA.LunaFieldName("IdTipoFustella")
		Public Shared ReadOnly Property Altezza As New LUNA.LunaFieldName("Altezza")
		Public Shared ReadOnly Property Base As New LUNA.LunaFieldName("Base")
		Public Shared ReadOnly Property CODICE As New LUNA.LunaFieldName("CODICE")
		Public Shared ReadOnly Property Disponibile As New LUNA.LunaFieldName("Disponibile")
		Public Shared ReadOnly Property IdCatFustella As New LUNA.LunaFieldName("IdCatFustella")
		Public Shared ReadOnly Property IdPrev As New LUNA.LunaFieldName("IdPrev")
		Public Shared ReadOnly Property ImgRif As New LUNA.LunaFieldName("ImgRif")
		Public Shared ReadOnly Property Orientabile As New LUNA.LunaFieldName("Orientabile")
		Public Shared ReadOnly Property Profondita As New LUNA.LunaFieldName("Profondita")
		Public Shared ReadOnly Property TEMPLATEPDF As New LUNA.LunaFieldName("TEMPLATEPDF")
	End Class

End Class