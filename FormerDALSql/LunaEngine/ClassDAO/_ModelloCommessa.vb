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
'''DAO Class for table T_modellicommessa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ModelloCommessa
	Inherits LUNA.LunaBaseClassEntity
	Implements _IModelloCommessa
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IModelloCommessa.FillFromDataRecord
		IdModello = myRecord("IdModello")
		if not myRecord("AbilitatoAutomazione") is DBNull.Value then AbilitatoAutomazione = myRecord("AbilitatoAutomazione")
		if not myRecord("Anteprima") is DBNull.Value then Anteprima = myRecord("Anteprima")
		if not myRecord("AnteprimaR") is DBNull.Value then AnteprimaR = myRecord("AnteprimaR")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("Disattivo") is DBNull.Value then Disattivo = myRecord("Disattivo")
		if not myRecord("FileJDP") is DBNull.Value then FileJDP = myRecord("FileJDP")
		if not myRecord("FromGanging") is DBNull.Value then FromGanging = myRecord("FromGanging")
		if not myRecord("FronteRetro") is DBNull.Value then FronteRetro = myRecord("FronteRetro")
		if not myRecord("FRSuSeStessa") is DBNull.Value then FRSuSeStessa = myRecord("FRSuSeStessa")
		if not myRecord("IdCatModello") is DBNull.Value then IdCatModello = myRecord("IdCatModello")
		if not myRecord("IdFormatoMacchina") is DBNull.Value then IdFormatoMacchina = myRecord("IdFormatoMacchina")
		if not myRecord("IdMacchinarioDef") is DBNull.Value then IdMacchinarioDef = myRecord("IdMacchinarioDef")
		if not myRecord("IdMacchinarioTaglioDef") is DBNull.Value then IdMacchinarioTaglioDef = myRecord("IdMacchinarioTaglioDef")
		if not myRecord("IdReparto") is DBNull.Value then IdReparto = myRecord("IdReparto")
		if not myRecord("Job") is DBNull.Value then Job = myRecord("Job")
		if not myRecord("MinGiroTaglio") is DBNull.Value then MinGiroTaglio = myRecord("MinGiroTaglio")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("NumSpazi") is DBNull.Value then NumSpazi = myRecord("NumSpazi")
		if not myRecord("PathTemplateAutomazione") is DBNull.Value then PathTemplateAutomazione = myRecord("PathTemplateAutomazione")
		if not myRecord("PDF") is DBNull.Value then PDF = myRecord("PDF")
		if not myRecord("RitieniOkDuplicati") is DBNull.Value then RitieniOkDuplicati = myRecord("RitieniOkDuplicati")
		if not myRecord("TiraturaIdeale") is DBNull.Value then TiraturaIdeale = myRecord("TiraturaIdeale")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ModelloCommessa)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ModelliCommessaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ModelloCommessa))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdModello As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AbilitatoAutomazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Anteprima As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AnteprimaR As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Disattivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FileJDP As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FromGanging As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FronteRetro As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property FRSuSeStessa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatModello As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormatoMacchina As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinarioDef As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinarioTaglioDef As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdReparto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Job As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MinGiroTaglio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NumSpazi As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PathTemplateAutomazione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PDF As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property RitieniOkDuplicati As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TiraturaIdeale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdModello = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AbilitatoAutomazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Anteprima = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AnteprimaR = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Disattivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FileJDP = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FromGanging = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FronteRetro = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.FRSuSeStessa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatModello = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormatoMacchina = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinarioDef = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinarioTaglioDef = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdReparto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Job = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MinGiroTaglio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NumSpazi = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PathTemplateAutomazione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PDF = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.RitieniOkDuplicati = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TiraturaIdeale = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdModello as integer  = 0 
	Public Overridable Property IdModello() as integer  Implements _IModelloCommessa.IdModello
		Get
			Return _IdModello
		End Get
		Set (byval value as integer)
			If _IdModello <> value Then
				IsChanged = True
				WhatIsChanged.IdModello = True
				_IdModello = value
			End If
		End Set
	End property 

	Protected _AbilitatoAutomazione as integer  = 0 
	Public Overridable Property AbilitatoAutomazione() as integer  Implements _IModelloCommessa.AbilitatoAutomazione
		Get
			Return _AbilitatoAutomazione
		End Get
		Set (byval value as integer)
			If _AbilitatoAutomazione <> value Then
				IsChanged = True
				WhatIsChanged.AbilitatoAutomazione = True
				_AbilitatoAutomazione = value
			End If
		End Set
	End property 

	Protected _Anteprima as string  = "" 
	Public Overridable Property Anteprima() as string  Implements _IModelloCommessa.Anteprima
		Get
			Return _Anteprima
		End Get
		Set (byval value as string)
			If _Anteprima <> value Then
				IsChanged = True
				WhatIsChanged.Anteprima = True
				_Anteprima = value
			End If
		End Set
	End property 

	Protected _AnteprimaR as string  = "" 
	Public Overridable Property AnteprimaR() as string  Implements _IModelloCommessa.AnteprimaR
		Get
			Return _AnteprimaR
		End Get
		Set (byval value as string)
			If _AnteprimaR <> value Then
				IsChanged = True
				WhatIsChanged.AnteprimaR = True
				_AnteprimaR = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _IModelloCommessa.Descrizione
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

	Protected _Disattivo as integer  = 0 
	Public Overridable Property Disattivo() as integer  Implements _IModelloCommessa.Disattivo
		Get
			Return _Disattivo
		End Get
		Set (byval value as integer)
			If _Disattivo <> value Then
				IsChanged = True
				WhatIsChanged.Disattivo = True
				_Disattivo = value
			End If
		End Set
	End property 

	Protected _FileJDP as string  = "" 
	Public Overridable Property FileJDP() as string  Implements _IModelloCommessa.FileJDP
		Get
			Return _FileJDP
		End Get
		Set (byval value as string)
			If _FileJDP <> value Then
				IsChanged = True
				WhatIsChanged.FileJDP = True
				_FileJDP = value
			End If
		End Set
	End property 

	Protected _FromGanging as integer  = 0 
	Public Overridable Property FromGanging() as integer  Implements _IModelloCommessa.FromGanging
		Get
			Return _FromGanging
		End Get
		Set (byval value as integer)
			If _FromGanging <> value Then
				IsChanged = True
				WhatIsChanged.FromGanging = True
				_FromGanging = value
			End If
		End Set
	End property 

	Protected _FronteRetro as integer  = 0 
	Public Overridable Property FronteRetro() as integer  Implements _IModelloCommessa.FronteRetro
		Get
			Return _FronteRetro
		End Get
		Set (byval value as integer)
			If _FronteRetro <> value Then
				IsChanged = True
				WhatIsChanged.FronteRetro = True
				_FronteRetro = value
			End If
		End Set
	End property 

	Protected _FRSuSeStessa as integer  = 0 
	Public Overridable Property FRSuSeStessa() as integer  Implements _IModelloCommessa.FRSuSeStessa
		Get
			Return _FRSuSeStessa
		End Get
		Set (byval value as integer)
			If _FRSuSeStessa <> value Then
				IsChanged = True
				WhatIsChanged.FRSuSeStessa = True
				_FRSuSeStessa = value
			End If
		End Set
	End property 

	Protected _IdCatModello as integer  = 0 
	Public Overridable Property IdCatModello() as integer  Implements _IModelloCommessa.IdCatModello
		Get
			Return _IdCatModello
		End Get
		Set (byval value as integer)
			If _IdCatModello <> value Then
				IsChanged = True
				WhatIsChanged.IdCatModello = True
				_IdCatModello = value
			End If
		End Set
	End property 

	Protected _IdFormatoMacchina as integer  = 0 
	Public Overridable Property IdFormatoMacchina() as integer  Implements _IModelloCommessa.IdFormatoMacchina
		Get
			Return _IdFormatoMacchina
		End Get
		Set (byval value as integer)
			If _IdFormatoMacchina <> value Then
				IsChanged = True
				WhatIsChanged.IdFormatoMacchina = True
				_IdFormatoMacchina = value
			End If
		End Set
	End property 

	Protected _IdMacchinarioDef as integer  = 0 
	Public Overridable Property IdMacchinarioDef() as integer  Implements _IModelloCommessa.IdMacchinarioDef
		Get
			Return _IdMacchinarioDef
		End Get
		Set (byval value as integer)
			If _IdMacchinarioDef <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinarioDef = True
				_IdMacchinarioDef = value
			End If
		End Set
	End property 

	Protected _IdMacchinarioTaglioDef as integer  = 0 
	Public Overridable Property IdMacchinarioTaglioDef() as integer  Implements _IModelloCommessa.IdMacchinarioTaglioDef
		Get
			Return _IdMacchinarioTaglioDef
		End Get
		Set (byval value as integer)
			If _IdMacchinarioTaglioDef <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinarioTaglioDef = True
				_IdMacchinarioTaglioDef = value
			End If
		End Set
	End property 

	Protected _IdReparto as integer  = 0 
	Public Overridable Property IdReparto() as integer  Implements _IModelloCommessa.IdReparto
		Get
			Return _IdReparto
		End Get
		Set (byval value as integer)
			If _IdReparto <> value Then
				IsChanged = True
				WhatIsChanged.IdReparto = True
				_IdReparto = value
			End If
		End Set
	End property 

	Protected _Job as string  = "" 
	Public Overridable Property Job() as string  Implements _IModelloCommessa.Job
		Get
			Return _Job
		End Get
		Set (byval value as string)
			If _Job <> value Then
				IsChanged = True
				WhatIsChanged.Job = True
				_Job = value
			End If
		End Set
	End property 

	Protected _MinGiroTaglio as integer  = 0 
	Public Overridable Property MinGiroTaglio() as integer  Implements _IModelloCommessa.MinGiroTaglio
		Get
			Return _MinGiroTaglio
		End Get
		Set (byval value as integer)
			If _MinGiroTaglio <> value Then
				IsChanged = True
				WhatIsChanged.MinGiroTaglio = True
				_MinGiroTaglio = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IModelloCommessa.Nome
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

	Protected _NumSpazi as integer  = 0 
	Public Overridable Property NumSpazi() as integer  Implements _IModelloCommessa.NumSpazi
		Get
			Return _NumSpazi
		End Get
		Set (byval value as integer)
			If _NumSpazi <> value Then
				IsChanged = True
				WhatIsChanged.NumSpazi = True
				_NumSpazi = value
			End If
		End Set
	End property 

	Protected _PathTemplateAutomazione as string  = "" 
	Public Overridable Property PathTemplateAutomazione() as string  Implements _IModelloCommessa.PathTemplateAutomazione
		Get
			Return _PathTemplateAutomazione
		End Get
		Set (byval value as string)
			If _PathTemplateAutomazione <> value Then
				IsChanged = True
				WhatIsChanged.PathTemplateAutomazione = True
				_PathTemplateAutomazione = value
			End If
		End Set
	End property 

	Protected _PDF as string  = "" 
	Public Overridable Property PDF() as string  Implements _IModelloCommessa.PDF
		Get
			Return _PDF
		End Get
		Set (byval value as string)
			If _PDF <> value Then
				IsChanged = True
				WhatIsChanged.PDF = True
				_PDF = value
			End If
		End Set
	End property 

	Protected _RitieniOkDuplicati as integer  = 0 
	Public Overridable Property RitieniOkDuplicati() as integer  Implements _IModelloCommessa.RitieniOkDuplicati
		Get
			Return _RitieniOkDuplicati
		End Get
		Set (byval value as integer)
			If _RitieniOkDuplicati <> value Then
				IsChanged = True
				WhatIsChanged.RitieniOkDuplicati = True
				_RitieniOkDuplicati = value
			End If
		End Set
	End property 

	Protected _TiraturaIdeale as integer  = 0 
	Public Overridable Property TiraturaIdeale() as integer  Implements _IModelloCommessa.TiraturaIdeale
		Get
			Return _TiraturaIdeale
		End Get
		Set (byval value as integer)
			If _TiraturaIdeale <> value Then
				IsChanged = True
				WhatIsChanged.TiraturaIdeale = True
				_TiraturaIdeale = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ModelloCommessa from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ModelloCommessa = Manager.Read(Id)
				_IdModello = int.IdModello
				_AbilitatoAutomazione = int.AbilitatoAutomazione
				_Anteprima = int.Anteprima
				_AnteprimaR = int.AnteprimaR
				_Descrizione = int.Descrizione
				_Disattivo = int.Disattivo
				_FileJDP = int.FileJDP
				_FromGanging = int.FromGanging
				_FronteRetro = int.FronteRetro
				_FRSuSeStessa = int.FRSuSeStessa
				_IdCatModello = int.IdCatModello
				_IdFormatoMacchina = int.IdFormatoMacchina
				_IdMacchinarioDef = int.IdMacchinarioDef
				_IdMacchinarioTaglioDef = int.IdMacchinarioTaglioDef
				_IdReparto = int.IdReparto
				_Job = int.Job
				_MinGiroTaglio = int.MinGiroTaglio
				_Nome = int.Nome
				_NumSpazi = int.NumSpazi
				_PathTemplateAutomazione = int.PathTemplateAutomazione
				_PDF = int.PDF
				_RitieniOkDuplicati = int.RitieniOkDuplicati
				_TiraturaIdeale = int.TiraturaIdeale
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an ModelloCommessa on DB.
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
		if _Anteprima.Length > 255 then Ris = False
		if _AnteprimaR.Length > 255 then Ris = False
		if _Descrizione.Length > 255 then Ris = False
		if _FileJDP.Length > 255 then Ris = False
		if _Job.Length > 255 then Ris = False
		if _Nome.Length > 255 then Ris = False
		if _PathTemplateAutomazione.Length > 255 then Ris = False
		if _PDF.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_modellicommessa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IModelloCommessa

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdModello() as integer
	Property AbilitatoAutomazione() as integer
	Property Anteprima() as string
	Property AnteprimaR() as string
	Property Descrizione() as string
	Property Disattivo() as integer
	Property FileJDP() as string
	Property FromGanging() as integer
	Property FronteRetro() as integer
	Property FRSuSeStessa() as integer
	Property IdCatModello() as integer
	Property IdFormatoMacchina() as integer
	Property IdMacchinarioDef() as integer
	Property IdMacchinarioTaglioDef() as integer
	Property IdReparto() as integer
	Property Job() as string
	Property MinGiroTaglio() as integer
	Property Nome() as string
	Property NumSpazi() as integer
	Property PathTemplateAutomazione() as string
	Property PDF() as string
	Property RitieniOkDuplicati() as integer
	Property TiraturaIdeale() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ModelloCommessa
		Public Shared ReadOnly Property IdModello As New LUNA.LunaFieldName("IdModello")
		Public Shared ReadOnly Property AbilitatoAutomazione As New LUNA.LunaFieldName("AbilitatoAutomazione")
		Public Shared ReadOnly Property Anteprima As New LUNA.LunaFieldName("Anteprima")
		Public Shared ReadOnly Property AnteprimaR As New LUNA.LunaFieldName("AnteprimaR")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property Disattivo As New LUNA.LunaFieldName("Disattivo")
		Public Shared ReadOnly Property FileJDP As New LUNA.LunaFieldName("FileJDP")
		Public Shared ReadOnly Property FromGanging As New LUNA.LunaFieldName("FromGanging")
		Public Shared ReadOnly Property FronteRetro As New LUNA.LunaFieldName("FronteRetro")
		Public Shared ReadOnly Property FRSuSeStessa As New LUNA.LunaFieldName("FRSuSeStessa")
		Public Shared ReadOnly Property IdCatModello As New LUNA.LunaFieldName("IdCatModello")
		Public Shared ReadOnly Property IdFormatoMacchina As New LUNA.LunaFieldName("IdFormatoMacchina")
		Public Shared ReadOnly Property IdMacchinarioDef As New LUNA.LunaFieldName("IdMacchinarioDef")
		Public Shared ReadOnly Property IdMacchinarioTaglioDef As New LUNA.LunaFieldName("IdMacchinarioTaglioDef")
		Public Shared ReadOnly Property IdReparto As New LUNA.LunaFieldName("IdReparto")
		Public Shared ReadOnly Property Job As New LUNA.LunaFieldName("Job")
		Public Shared ReadOnly Property MinGiroTaglio As New LUNA.LunaFieldName("MinGiroTaglio")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property NumSpazi As New LUNA.LunaFieldName("NumSpazi")
		Public Shared ReadOnly Property PathTemplateAutomazione As New LUNA.LunaFieldName("PathTemplateAutomazione")
		Public Shared ReadOnly Property PDF As New LUNA.LunaFieldName("PDF")
		Public Shared ReadOnly Property RitieniOkDuplicati As New LUNA.LunaFieldName("RitieniOkDuplicati")
		Public Shared ReadOnly Property TiraturaIdeale As New LUNA.LunaFieldName("TiraturaIdeale")
	End Class

End Class