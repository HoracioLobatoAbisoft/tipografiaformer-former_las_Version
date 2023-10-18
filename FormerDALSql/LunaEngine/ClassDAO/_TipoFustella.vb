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
'''DAO Class for table T_tipofustella
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _TipoFustella
	Inherits LUNA.LunaBaseClassEntity
	Implements _ITipoFustella
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ITipoFustella.FillFromDataRecord
		IdTipoFustella = myRecord("IdTipoFustella")
		if not myRecord("Altezza") is DBNull.Value then Altezza = myRecord("Altezza")
		if not myRecord("Base") is DBNull.Value then Base = myRecord("Base")
		if not myRecord("Codice") is DBNull.Value then Codice = myRecord("Codice")
		if not myRecord("Disponibile") is DBNull.Value then Disponibile = myRecord("Disponibile")
		if not myRecord("IdCatFustella") is DBNull.Value then IdCatFustella = myRecord("IdCatFustella")
		if not myRecord("IdPrev") is DBNull.Value then IdPrev = myRecord("IdPrev")
		if not myRecord("ImgRif") is DBNull.Value then ImgRif = myRecord("ImgRif")
		if not myRecord("Orientabile") is DBNull.Value then Orientabile = myRecord("Orientabile")
		if not myRecord("Profondita") is DBNull.Value then Profondita = myRecord("Profondita")
		if not myRecord("TemplatePDF") is DBNull.Value then TemplatePDF = myRecord("TemplatePDF")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of TipoFustella)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(TipoFustelleDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of TipoFustella))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdTipoFustella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Altezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Base As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Disponibile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatFustella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Orientabile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Profondita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TemplatePDF As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdTipoFustella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Altezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Base = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Disponibile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatFustella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Orientabile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Profondita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TemplatePDF = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdTipoFustella as integer  = 0 
	Public Overridable Property IdTipoFustella() as integer  Implements _ITipoFustella.IdTipoFustella
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
	Public Overridable Property Altezza() as integer  Implements _ITipoFustella.Altezza
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
	Public Overridable Property Base() as integer  Implements _ITipoFustella.Base
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

	Protected _Codice as string  = "" 
	Public Overridable Property Codice() as string  Implements _ITipoFustella.Codice
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

	Protected _Disponibile as integer  = 0 
	Public Overridable Property Disponibile() as integer  Implements _ITipoFustella.Disponibile
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
	Public Overridable Property IdCatFustella() as integer  Implements _ITipoFustella.IdCatFustella
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
	Public Overridable Property IdPrev() as integer  Implements _ITipoFustella.IdPrev
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
	Public Overridable Property ImgRif() as string  Implements _ITipoFustella.ImgRif
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
	Public Overridable Property Orientabile() as integer  Implements _ITipoFustella.Orientabile
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
	Public Overridable Property Profondita() as integer  Implements _ITipoFustella.Profondita
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

	Protected _TemplatePDF as string  = "" 
	Public Overridable Property TemplatePDF() as string  Implements _ITipoFustella.TemplatePDF
		Get
			Return _TemplatePDF
		End Get
		Set (byval value as string)
			If _TemplatePDF <> value Then
				IsChanged = True
				WhatIsChanged.TemplatePDF = True
				_TemplatePDF = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an TipoFustella from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As TipoFustella = Manager.Read(Id)
				_IdTipoFustella = int.IdTipoFustella
				_Altezza = int.Altezza
				_Base = int.Base
				_Codice = int.Codice
				_Disponibile = int.Disponibile
				_IdCatFustella = int.IdCatFustella
				_IdPrev = int.IdPrev
				_ImgRif = int.ImgRif
				_Orientabile = int.Orientabile
				_Profondita = int.Profondita
				_TemplatePDF = int.TemplatePDF
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an TipoFustella on DB.
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
		if _Codice.Length > 50 then Ris = False
		if _ImgRif.Length > 255 then Ris = False
		if _TemplatePDF.Length > 255 then Ris = False

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

Public Interface _ITipoFustella

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdTipoFustella() as integer
	Property Altezza() as integer
	Property Base() as integer
	Property Codice() as string
	Property Disponibile() as integer
	Property IdCatFustella() as integer
	Property IdPrev() as integer
	Property ImgRif() as string
	Property Orientabile() as integer
	Property Profondita() as integer
	Property TemplatePDF() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class TipoFustella
		Public Shared ReadOnly Property IdTipoFustella As New LUNA.LunaFieldName("IdTipoFustella")
		Public Shared ReadOnly Property Altezza As New LUNA.LunaFieldName("Altezza")
		Public Shared ReadOnly Property Base As New LUNA.LunaFieldName("Base")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property Disponibile As New LUNA.LunaFieldName("Disponibile")
		Public Shared ReadOnly Property IdCatFustella As New LUNA.LunaFieldName("IdCatFustella")
		Public Shared ReadOnly Property IdPrev As New LUNA.LunaFieldName("IdPrev")
		Public Shared ReadOnly Property ImgRif As New LUNA.LunaFieldName("ImgRif")
		Public Shared ReadOnly Property Orientabile As New LUNA.LunaFieldName("Orientabile")
		Public Shared ReadOnly Property Profondita As New LUNA.LunaFieldName("Profondita")
		Public Shared ReadOnly Property TemplatePDF As New LUNA.LunaFieldName("TemplatePDF")
	End Class

End Class