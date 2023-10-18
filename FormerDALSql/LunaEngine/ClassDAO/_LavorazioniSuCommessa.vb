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
'''DAO Class for table Tr_lavori
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _LavorazioniSuCommessa
	Inherits LUNA.LunaBaseClassEntity
	Implements _ILavorazioniSuCommessa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ILavorazioniSuCommessa.FillFromDataRecord
		IdLavRel = myRecord("IdLavRel")
		if not myRecord("IdLav") is DBNull.Value then IdLav = myRecord("IdLav")
		if not myRecord("IdProd") is DBNull.Value then IdProd = myRecord("IdProd")
		if not myRecord("IdTipoCom") is DBNull.Value then IdTipoCom = myRecord("IdTipoCom")
		if not myRecord("Opzione") is DBNull.Value then Opzione = myRecord("Opzione")
		if not myRecord("Ordine") is DBNull.Value then Ordine = myRecord("Ordine")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of LavorazioniSuCommessa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(LavorazioniSuCommessaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of LavorazioniSuCommessa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLavRel As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdLav As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoCom As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Opzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ordine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLavRel = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdLav = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoCom = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Opzione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ordine = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLavRel as integer  = 0 
	Public Overridable Property IdLavRel() as integer  Implements _ILavorazioniSuCommessa.IdLavRel
		Get
			Return _IdLavRel
		End Get
		Set (byval value as integer)
			If _IdLavRel <> value Then
				IsChanged = True
				WhatIsChanged.IdLavRel = True
				_IdLavRel = value
			End If
		End Set
	End property 

	Protected _IdLav as integer  = 0 
	Public Overridable Property IdLav() as integer  Implements _ILavorazioniSuCommessa.IdLav
		Get
			Return _IdLav
		End Get
		Set (byval value as integer)
			If _IdLav <> value Then
				IsChanged = True
				WhatIsChanged.IdLav = True
				_IdLav = value
			End If
		End Set
	End property 

	Protected _IdProd as integer  = 0 
	Public Overridable Property IdProd() as integer  Implements _ILavorazioniSuCommessa.IdProd
		Get
			Return _IdProd
		End Get
		Set (byval value as integer)
			If _IdProd <> value Then
				IsChanged = True
				WhatIsChanged.IdProd = True
				_IdProd = value
			End If
		End Set
	End property 

	Protected _IdTipoCom as integer  = 0 
	Public Overridable Property IdTipoCom() as integer  Implements _ILavorazioniSuCommessa.IdTipoCom
		Get
			Return _IdTipoCom
		End Get
		Set (byval value as integer)
			If _IdTipoCom <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoCom = True
				_IdTipoCom = value
			End If
		End Set
	End property 

	Protected _Opzione as Boolean  = False 
	Public Overridable Property Opzione() as Boolean  Implements _ILavorazioniSuCommessa.Opzione
		Get
			Return _Opzione
		End Get
		Set (byval value as Boolean)
			If _Opzione <> value Then
				IsChanged = True
				WhatIsChanged.Opzione = True
				_Opzione = value
			End If
		End Set
	End property 

	Protected _Ordine as integer  = 0 
	Public Overridable Property Ordine() as integer  Implements _ILavorazioniSuCommessa.Ordine
		Get
			Return _Ordine
		End Get
		Set (byval value as integer)
			If _Ordine <> value Then
				IsChanged = True
				WhatIsChanged.Ordine = True
				_Ordine = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an LavorazioniSuCommessa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As LavorazioniSuCommessa = Manager.Read(Id)
				_IdLavRel = int.IdLavRel
				_IdLav = int.IdLav
				_IdProd = int.IdProd
				_IdTipoCom = int.IdTipoCom
				_Opzione = int.Opzione
				_Ordine = int.Ordine
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an LavorazioniSuCommessa on DB.
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

	
	<XmlElementAttribute("TipoCommessa")> _
	Protected _TipoCommessa As TipoCommessa
	Public property TipoCommessa() As  TipoCommessa
		Get
			If _TipoCommessa Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
				Using Mgr As New TipoCommesseDAO
					_TipoCommessa = Mgr.Read(_IdTipoCom)
				End Using 
			End If
			Return _TipoCommessa
		End Get
		Set(ByVal value As TipoCommessa)
			_TipoCommessa = value
			_IdTipoCom = _TipoCommessa.IdTipoCom
		End Set
	End Property

	
	<XmlElementAttribute("Lavorazione")> _
	Protected _Lavorazione As Lavorazione
	Public property Lavorazione() As  Lavorazione
		Get
			If _Lavorazione Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
				Using Mgr As New LavorazioniDAO
					_Lavorazione = Mgr.Read(_IdLav)
				End Using 
			End If
			Return _Lavorazione
		End Get
		Set(ByVal value As Lavorazione)
			_Lavorazione = value
            _IdLav = _Lavorazione.IdLavoro
        End Set
	End Property


#End Region

End Class 

''' <summary>
'''Interface for table Tr_lavori
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ILavorazioniSuCommessa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLavRel() as integer
	Property IdLav() as integer
	Property IdProd() as integer
	Property IdTipoCom() as integer
	Property Opzione() as Boolean
	Property Ordine() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class LavorazioniSuCommessa
		Public Shared ReadOnly Property IdLavRel As New LUNA.LunaFieldName("IdLavRel")
		Public Shared ReadOnly Property IdLav As New LUNA.LunaFieldName("IdLav")
		Public Shared ReadOnly Property IdProd As New LUNA.LunaFieldName("IdProd")
		Public Shared ReadOnly Property IdTipoCom As New LUNA.LunaFieldName("IdTipoCom")
		Public Shared ReadOnly Property Opzione As New LUNA.LunaFieldName("Opzione")
		Public Shared ReadOnly Property Ordine As New LUNA.LunaFieldName("Ordine")
	End Class

End Class