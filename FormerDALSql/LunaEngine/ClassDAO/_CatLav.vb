#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/11/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Td_catlav
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CatLav
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICatLav
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICatLav.FillFromDataRecord
		IdCatLav = myRecord("IdCatLav")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("FileLavNonSelezionata") is DBNull.Value then FileLavNonSelezionata = myRecord("FileLavNonSelezionata")
		if not myRecord("OrdineEsecuzione") is DBNull.Value then OrdineEsecuzione = myRecord("OrdineEsecuzione")
		if not myRecord("RepartoAppartenenza") is DBNull.Value then RepartoAppartenenza = myRecord("RepartoAppartenenza")
		if not myRecord("SovrascriviImgScheda") is DBNull.Value then SovrascriviImgScheda = myRecord("SovrascriviImgScheda")
		if not myRecord("TipoCaratteristica") is DBNull.Value then TipoCaratteristica = myRecord("TipoCaratteristica")
		if not myRecord("TipoControllo") is DBNull.Value then TipoControllo = myRecord("TipoControllo")
		if not myRecord("VisibilePreventivo") is DBNull.Value then VisibilePreventivo = myRecord("VisibilePreventivo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CatLav)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CatLavDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CatLav))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCatLav As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FileLavNonSelezionata As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property OrdineEsecuzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RepartoAppartenenza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SovrascriviImgScheda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoCaratteristica As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoControllo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property VisibilePreventivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCatLav = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FileLavNonSelezionata = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.OrdineEsecuzione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RepartoAppartenenza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SovrascriviImgScheda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoCaratteristica = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoControllo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.VisibilePreventivo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCatLav as integer  = 0 
	Public Overridable Property IdCatLav() as integer  Implements _ICatLav.IdCatLav
		Get
			Return _IdCatLav
		End Get
		Set (byval value as integer)
			If _IdCatLav <> value Then
				IsChanged = True
				WhatIsChanged.IdCatLav = True
				_IdCatLav = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _ICatLav.Descrizione
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

	Protected _FileLavNonSelezionata as string  = "" 
	Public Overridable Property FileLavNonSelezionata() as string  Implements _ICatLav.FileLavNonSelezionata
		Get
			Return _FileLavNonSelezionata
		End Get
		Set (byval value as string)
			If _FileLavNonSelezionata <> value Then
				IsChanged = True
				WhatIsChanged.FileLavNonSelezionata = True
				_FileLavNonSelezionata = value
			End If
		End Set
	End property 

	Protected _OrdineEsecuzione as integer  = 0 
	Public Overridable Property OrdineEsecuzione() as integer  Implements _ICatLav.OrdineEsecuzione
		Get
			Return _OrdineEsecuzione
		End Get
		Set (byval value as integer)
			If _OrdineEsecuzione <> value Then
				IsChanged = True
				WhatIsChanged.OrdineEsecuzione = True
				_OrdineEsecuzione = value
			End If
		End Set
	End property 

	Protected _RepartoAppartenenza as integer  = 0 
	Public Overridable Property RepartoAppartenenza() as integer  Implements _ICatLav.RepartoAppartenenza
		Get
			Return _RepartoAppartenenza
		End Get
		Set (byval value as integer)
			If _RepartoAppartenenza <> value Then
				IsChanged = True
				WhatIsChanged.RepartoAppartenenza = True
				_RepartoAppartenenza = value
			End If
		End Set
	End property 

	Protected _SovrascriviImgScheda as integer  = 0 
	Public Overridable Property SovrascriviImgScheda() as integer  Implements _ICatLav.SovrascriviImgScheda
		Get
			Return _SovrascriviImgScheda
		End Get
		Set (byval value as integer)
			If _SovrascriviImgScheda <> value Then
				IsChanged = True
				WhatIsChanged.SovrascriviImgScheda = True
				_SovrascriviImgScheda = value
			End If
		End Set
	End property 

	Protected _TipoCaratteristica as integer  = 0 
	Public Overridable Property TipoCaratteristica() as integer  Implements _ICatLav.TipoCaratteristica
		Get
			Return _TipoCaratteristica
		End Get
		Set (byval value as integer)
			If _TipoCaratteristica <> value Then
				IsChanged = True
				WhatIsChanged.TipoCaratteristica = True
				_TipoCaratteristica = value
			End If
		End Set
	End property 

	Protected _TipoControllo as integer  = 0 
	Public Overridable Property TipoControllo() as integer  Implements _ICatLav.TipoControllo
		Get
			Return _TipoControllo
		End Get
		Set (byval value as integer)
			If _TipoControllo <> value Then
				IsChanged = True
				WhatIsChanged.TipoControllo = True
				_TipoControllo = value
			End If
		End Set
	End property 

	Protected _VisibilePreventivo as integer  = 0 
	Public Overridable Property VisibilePreventivo() as integer  Implements _ICatLav.VisibilePreventivo
		Get
			Return _VisibilePreventivo
		End Get
		Set (byval value as integer)
			If _VisibilePreventivo <> value Then
				IsChanged = True
				WhatIsChanged.VisibilePreventivo = True
				_VisibilePreventivo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CatLav from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CatLav = Manager.Read(Id)
				_IdCatLav = int.IdCatLav
				_Descrizione = int.Descrizione
				_FileLavNonSelezionata = int.FileLavNonSelezionata
				_OrdineEsecuzione = int.OrdineEsecuzione
				_RepartoAppartenenza = int.RepartoAppartenenza
				_SovrascriviImgScheda = int.SovrascriviImgScheda
				_TipoCaratteristica = int.TipoCaratteristica
				_TipoControllo = int.TipoControllo
				_VisibilePreventivo = int.VisibilePreventivo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CatLav on DB.
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
		if _Descrizione.Length > 50 then Ris = False
		if _FileLavNonSelezionata.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_catlav
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICatLav

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCatLav() as integer
	Property Descrizione() as string
	Property FileLavNonSelezionata() as string
	Property OrdineEsecuzione() as integer
	Property RepartoAppartenenza() as integer
	Property SovrascriviImgScheda() as integer
	Property TipoCaratteristica() as integer
	Property TipoControllo() as integer
	Property VisibilePreventivo() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CatLav
		Public Shared ReadOnly Property IdCatLav As New LUNA.LunaFieldName("IdCatLav")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property FileLavNonSelezionata As New LUNA.LunaFieldName("FileLavNonSelezionata")
		Public Shared ReadOnly Property OrdineEsecuzione As New LUNA.LunaFieldName("OrdineEsecuzione")
		Public Shared ReadOnly Property RepartoAppartenenza As New LUNA.LunaFieldName("RepartoAppartenenza")
		Public Shared ReadOnly Property SovrascriviImgScheda As New LUNA.LunaFieldName("SovrascriviImgScheda")
		Public Shared ReadOnly Property TipoCaratteristica As New LUNA.LunaFieldName("TipoCaratteristica")
		Public Shared ReadOnly Property TipoControllo As New LUNA.LunaFieldName("TipoControllo")
		Public Shared ReadOnly Property VisibilePreventivo As New LUNA.LunaFieldName("VisibilePreventivo")
	End Class

End Class