#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 24/03/2021 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_contabcosti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Costo
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICosto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICosto.FillFromDataRecord
		IdCosto = myRecord("IdCosto")
		if not myRecord("AddebitiVari") is DBNull.Value then AddebitiVari = myRecord("AddebitiVari")
		if not myRecord("CostoCorr") is DBNull.Value then CostoCorr = myRecord("CostoCorr")
		if not myRecord("DataCosto") is DBNull.Value then DataCosto = myRecord("DataCosto")
		if not myRecord("DataEffettivoPagamento") is DBNull.Value then DataEffettivoPagamento = myRecord("DataEffettivoPagamento")
		if not myRecord("DataOraRicezione") is DBNull.Value then DataOraRicezione = myRecord("DataOraRicezione")
		if not myRecord("DataPrevPagam") is DBNull.Value then DataPrevPagam = myRecord("DataPrevPagam")
		if not myRecord("Descrizione") is DBNull.Value then Descrizione = myRecord("Descrizione")
		if not myRecord("DocXML") is DBNull.Value then DocXML = myRecord("DocXML")
		if not myRecord("IdAzienda") is DBNull.Value then IdAzienda = myRecord("IdAzienda")
		if not myRecord("IdCaricoMagazzino") is DBNull.Value then IdCaricoMagazzino = myRecord("IdCaricoMagazzino")
		if not myRecord("IdCat") is DBNull.Value then IdCat = myRecord("IdCat")
		if not myRecord("IdDocRif") is DBNull.Value then IdDocRif = myRecord("IdDocRif")
		if not myRecord("IdentificativoSdI") is DBNull.Value then IdentificativoSdI = myRecord("IdentificativoSdI")
		if not myRecord("IdMessaggioFE") is DBNull.Value then IdMessaggioFE = myRecord("IdMessaggioFE")
		if not myRecord("IdRub") is DBNull.Value then IdRub = myRecord("IdRub")
		if not myRecord("IdStato") is DBNull.Value then IdStato = myRecord("IdStato")
		if not myRecord("Importo") is DBNull.Value then Importo = myRecord("Importo")
		if not myRecord("Iva") is DBNull.Value then Iva = myRecord("Iva")
		if not myRecord("Numero") is DBNull.Value then Numero = myRecord("Numero")
		if not myRecord("PercIva") is DBNull.Value then PercIva = myRecord("PercIva")
		if not myRecord("Scansione") is DBNull.Value then Scansione = myRecord("Scansione")
		if not myRecord("Scansione1") is DBNull.Value then Scansione1 = myRecord("Scansione1")
		if not myRecord("Scansione2") is DBNull.Value then Scansione2 = myRecord("Scansione2")
		if not myRecord("Scansione3") is DBNull.Value then Scansione3 = myRecord("Scansione3")
		if not myRecord("Scansione4") is DBNull.Value then Scansione4 = myRecord("Scansione4")
		if not myRecord("SpeseIncasso") is DBNull.Value then SpeseIncasso = myRecord("SpeseIncasso")
		if not myRecord("StatoFE") is DBNull.Value then StatoFE = myRecord("StatoFE")
		if not myRecord("StatoFEInterno") is DBNull.Value then StatoFEInterno = myRecord("StatoFEInterno")
		if not myRecord("Tipo") is DBNull.Value then Tipo = myRecord("Tipo")
		if not myRecord("Totale") is DBNull.Value then Totale = myRecord("Totale")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Costo)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CostiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Costo))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AddebitiVari As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CostoCorr As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataEffettivoPagamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataOraRicezione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataPrevPagam As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DocXML As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdAzienda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCaricoMagazzino As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCat As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdDocRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdentificativoSdI As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMessaggioFE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRub As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdStato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Importo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Iva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Numero As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercIva As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Scansione4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property SpeseIncasso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StatoFE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property StatoFEInterno As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Tipo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Totale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCosto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AddebitiVari = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CostoCorr = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataCosto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataEffettivoPagamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataOraRicezione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataPrevPagam = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DocXML = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdAzienda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCaricoMagazzino = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCat = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdDocRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdentificativoSdI = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMessaggioFE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRub = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdStato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Importo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Iva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Numero = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercIva = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Scansione4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.SpeseIncasso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StatoFE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.StatoFEInterno = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Tipo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Totale = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCosto as integer  = 0 
	Public Overridable Property IdCosto() as integer  Implements _ICosto.IdCosto
		Get
			Return _IdCosto
		End Get
		Set (byval value as integer)
			If _IdCosto <> value Then
				IsChanged = True
				WhatIsChanged.IdCosto = True
				_IdCosto = value
			End If
		End Set
	End property 

	Protected _AddebitiVari as decimal  = 0 
	Public Overridable Property AddebitiVari() as decimal  Implements _ICosto.AddebitiVari
		Get
			Return _AddebitiVari
		End Get
		Set (byval value as decimal)
			If _AddebitiVari <> value Then
				IsChanged = True
				WhatIsChanged.AddebitiVari = True
				_AddebitiVari = value
			End If
		End Set
	End property 

	Protected _CostoCorr as decimal  = 0 
	Public Overridable Property CostoCorr() as decimal  Implements _ICosto.CostoCorr
		Get
			Return _CostoCorr
		End Get
		Set (byval value as decimal)
			If _CostoCorr <> value Then
				IsChanged = True
				WhatIsChanged.CostoCorr = True
				_CostoCorr = value
			End If
		End Set
	End property 

	Protected _DataCosto as DateTime  = Nothing 
	Public Overridable Property DataCosto() as DateTime  Implements _ICosto.DataCosto
		Get
			Return _DataCosto
		End Get
		Set (byval value as DateTime)
			If _DataCosto <> value Then
				IsChanged = True
				WhatIsChanged.DataCosto = True
				_DataCosto = value
			End If
		End Set
	End property 

	Protected _DataEffettivoPagamento as DateTime  = Nothing 
	Public Overridable Property DataEffettivoPagamento() as DateTime  Implements _ICosto.DataEffettivoPagamento
		Get
			Return _DataEffettivoPagamento
		End Get
		Set (byval value as DateTime)
			If _DataEffettivoPagamento <> value Then
				IsChanged = True
				WhatIsChanged.DataEffettivoPagamento = True
				_DataEffettivoPagamento = value
			End If
		End Set
	End property 

	Protected _DataOraRicezione as DateTime  = Nothing 
	Public Overridable Property DataOraRicezione() as DateTime  Implements _ICosto.DataOraRicezione
		Get
			Return _DataOraRicezione
		End Get
		Set (byval value as DateTime)
			If _DataOraRicezione <> value Then
				IsChanged = True
				WhatIsChanged.DataOraRicezione = True
				_DataOraRicezione = value
			End If
		End Set
	End property 

	Protected _DataPrevPagam as DateTime  = Nothing 
	Public Overridable Property DataPrevPagam() as DateTime  Implements _ICosto.DataPrevPagam
		Get
			Return _DataPrevPagam
		End Get
		Set (byval value as DateTime)
			If _DataPrevPagam <> value Then
				IsChanged = True
				WhatIsChanged.DataPrevPagam = True
				_DataPrevPagam = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _ICosto.Descrizione
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

	Protected _DocXML as string  = "" 
	Public Overridable Property DocXML() as string  Implements _ICosto.DocXML
		Get
			Return _DocXML
		End Get
		Set (byval value as string)
			If _DocXML <> value Then
				IsChanged = True
				WhatIsChanged.DocXML = True
				_DocXML = value
			End If
		End Set
	End property 

	Protected _IdAzienda as integer  = 0 
	Public Overridable Property IdAzienda() as integer  Implements _ICosto.IdAzienda
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

	Protected _IdCaricoMagazzino as integer  = 0 
	Public Overridable Property IdCaricoMagazzino() as integer  Implements _ICosto.IdCaricoMagazzino
		Get
			Return _IdCaricoMagazzino
		End Get
		Set (byval value as integer)
			If _IdCaricoMagazzino <> value Then
				IsChanged = True
				WhatIsChanged.IdCaricoMagazzino = True
				_IdCaricoMagazzino = value
			End If
		End Set
	End property 

	Protected _IdCat as integer  = 0 
	Public Overridable Property IdCat() as integer  Implements _ICosto.IdCat
		Get
			Return _IdCat
		End Get
		Set (byval value as integer)
			If _IdCat <> value Then
				IsChanged = True
				WhatIsChanged.IdCat = True
				_IdCat = value
			End If
		End Set
	End property 

	Protected _IdDocRif as integer  = 0 
	Public Overridable Property IdDocRif() as integer  Implements _ICosto.IdDocRif
		Get
			Return _IdDocRif
		End Get
		Set (byval value as integer)
			If _IdDocRif <> value Then
				IsChanged = True
				WhatIsChanged.IdDocRif = True
				_IdDocRif = value
			End If
		End Set
	End property 

	Protected _IdentificativoSdI as string  = "" 
	Public Overridable Property IdentificativoSdI() as string  Implements _ICosto.IdentificativoSdI
		Get
			Return _IdentificativoSdI
		End Get
		Set (byval value as string)
			If _IdentificativoSdI <> value Then
				IsChanged = True
				WhatIsChanged.IdentificativoSdI = True
				_IdentificativoSdI = value
			End If
		End Set
	End property 

	Protected _IdMessaggioFE as string  = "" 
	Public Overridable Property IdMessaggioFE() as string  Implements _ICosto.IdMessaggioFE
		Get
			Return _IdMessaggioFE
		End Get
		Set (byval value as string)
			If _IdMessaggioFE <> value Then
				IsChanged = True
				WhatIsChanged.IdMessaggioFE = True
				_IdMessaggioFE = value
			End If
		End Set
	End property 

	Protected _IdRub as integer  = 0 
	Public Overridable Property IdRub() as integer  Implements _ICosto.IdRub
		Get
			Return _IdRub
		End Get
		Set (byval value as integer)
			If _IdRub <> value Then
				IsChanged = True
				WhatIsChanged.IdRub = True
				_IdRub = value
			End If
		End Set
	End property 

	Protected _IdStato as integer  = 0 
	Public Overridable Property IdStato() as integer  Implements _ICosto.IdStato
		Get
			Return _IdStato
		End Get
		Set (byval value as integer)
			If _IdStato <> value Then
				IsChanged = True
				WhatIsChanged.IdStato = True
				_IdStato = value
			End If
		End Set
	End property 

	Protected _Importo as decimal  = 0 
	Public Overridable Property Importo() as decimal  Implements _ICosto.Importo
		Get
			Return _Importo
		End Get
		Set (byval value as decimal)
			If _Importo <> value Then
				IsChanged = True
				WhatIsChanged.Importo = True
				_Importo = value
			End If
		End Set
	End property 

	Protected _Iva as decimal  = 0 
	Public Overridable Property Iva() as decimal  Implements _ICosto.Iva
		Get
			Return _Iva
		End Get
		Set (byval value as decimal)
			If _Iva <> value Then
				IsChanged = True
				WhatIsChanged.Iva = True
				_Iva = value
			End If
		End Set
	End property 

	Protected _Numero as string  = "" 
	Public Overridable Property Numero() as string  Implements _ICosto.Numero
		Get
			Return _Numero
		End Get
		Set (byval value as string)
			If _Numero <> value Then
				IsChanged = True
				WhatIsChanged.Numero = True
				_Numero = value
			End If
		End Set
	End property 

	Protected _PercIva as integer  = 0 
	Public Overridable Property PercIva() as integer  Implements _ICosto.PercIva
		Get
			Return _PercIva
		End Get
		Set (byval value as integer)
			If _PercIva <> value Then
				IsChanged = True
				WhatIsChanged.PercIva = True
				_PercIva = value
			End If
		End Set
	End property 

	Protected _Scansione as string  = "" 
	Public Overridable Property Scansione() as string  Implements _ICosto.Scansione
		Get
			Return _Scansione
		End Get
		Set (byval value as string)
			If _Scansione <> value Then
				IsChanged = True
				WhatIsChanged.Scansione = True
				_Scansione = value
			End If
		End Set
	End property 

	Protected _Scansione1 as string  = "" 
	Public Overridable Property Scansione1() as string  Implements _ICosto.Scansione1
		Get
			Return _Scansione1
		End Get
		Set (byval value as string)
			If _Scansione1 <> value Then
				IsChanged = True
				WhatIsChanged.Scansione1 = True
				_Scansione1 = value
			End If
		End Set
	End property 

	Protected _Scansione2 as string  = "" 
	Public Overridable Property Scansione2() as string  Implements _ICosto.Scansione2
		Get
			Return _Scansione2
		End Get
		Set (byval value as string)
			If _Scansione2 <> value Then
				IsChanged = True
				WhatIsChanged.Scansione2 = True
				_Scansione2 = value
			End If
		End Set
	End property 

	Protected _Scansione3 as string  = "" 
	Public Overridable Property Scansione3() as string  Implements _ICosto.Scansione3
		Get
			Return _Scansione3
		End Get
		Set (byval value as string)
			If _Scansione3 <> value Then
				IsChanged = True
				WhatIsChanged.Scansione3 = True
				_Scansione3 = value
			End If
		End Set
	End property 

	Protected _Scansione4 as string  = "" 
	Public Overridable Property Scansione4() as string  Implements _ICosto.Scansione4
		Get
			Return _Scansione4
		End Get
		Set (byval value as string)
			If _Scansione4 <> value Then
				IsChanged = True
				WhatIsChanged.Scansione4 = True
				_Scansione4 = value
			End If
		End Set
	End property 

	Protected _SpeseIncasso as decimal  = 0 
	Public Overridable Property SpeseIncasso() as decimal  Implements _ICosto.SpeseIncasso
		Get
			Return _SpeseIncasso
		End Get
		Set (byval value as decimal)
			If _SpeseIncasso <> value Then
				IsChanged = True
				WhatIsChanged.SpeseIncasso = True
				_SpeseIncasso = value
			End If
		End Set
	End property 

	Protected _StatoFE as integer  = 0 
	Public Overridable Property StatoFE() as integer  Implements _ICosto.StatoFE
		Get
			Return _StatoFE
		End Get
		Set (byval value as integer)
			If _StatoFE <> value Then
				IsChanged = True
				WhatIsChanged.StatoFE = True
				_StatoFE = value
			End If
		End Set
	End property 

	Protected _StatoFEInterno as integer  = 0 
	Public Overridable Property StatoFEInterno() as integer  Implements _ICosto.StatoFEInterno
		Get
			Return _StatoFEInterno
		End Get
		Set (byval value as integer)
			If _StatoFEInterno <> value Then
				IsChanged = True
				WhatIsChanged.StatoFEInterno = True
				_StatoFEInterno = value
			End If
		End Set
	End property 

	Protected _Tipo as integer  = 0 
	Public Overridable Property Tipo() as integer  Implements _ICosto.Tipo
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

	Protected _Totale as decimal  = 0 
	Public Overridable Property Totale() as decimal  Implements _ICosto.Totale
		Get
			Return _Totale
		End Get
		Set (byval value as decimal)
			If _Totale <> value Then
				IsChanged = True
				WhatIsChanged.Totale = True
				_Totale = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Costo from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Costo = Manager.Read(Id)
				_IdCosto = int.IdCosto
				_AddebitiVari = int.AddebitiVari
				_CostoCorr = int.CostoCorr
				_DataCosto = int.DataCosto
				_DataEffettivoPagamento = int.DataEffettivoPagamento
				_DataOraRicezione = int.DataOraRicezione
				_DataPrevPagam = int.DataPrevPagam
				_Descrizione = int.Descrizione
				_DocXML = int.DocXML
				_IdAzienda = int.IdAzienda
				_IdCaricoMagazzino = int.IdCaricoMagazzino
				_IdCat = int.IdCat
				_IdDocRif = int.IdDocRif
				_IdentificativoSdI = int.IdentificativoSdI
				_IdMessaggioFE = int.IdMessaggioFE
				_IdRub = int.IdRub
				_IdStato = int.IdStato
				_Importo = int.Importo
				_Iva = int.Iva
				_Numero = int.Numero
				_PercIva = int.PercIva
				_Scansione = int.Scansione
				_Scansione1 = int.Scansione1
				_Scansione2 = int.Scansione2
				_Scansione3 = int.Scansione3
				_Scansione4 = int.Scansione4
				_SpeseIncasso = int.SpeseIncasso
				_StatoFE = int.StatoFE
				_StatoFEInterno = int.StatoFEInterno
				_Tipo = int.Tipo
				_Totale = int.Totale
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
    Public Overridable Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdCosto Then
            ris = Read(IdCosto)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an Costo on DB.
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
		if _DocXML.Length > 2147483647 then Ris = False
		if _IdentificativoSdI.Length > 20 then Ris = False
		if _IdMessaggioFE.Length > 255 then Ris = False
		if _Numero.Length > 20 then Ris = False
		if _Scansione.Length > 255 then Ris = False
		if _Scansione1.Length > 255 then Ris = False
		if _Scansione2.Length > 255 then Ris = False
		if _Scansione3.Length > 255 then Ris = False
		if _Scansione4.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_contabcosti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICosto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCosto() as integer
	Property AddebitiVari() as decimal
	Property CostoCorr() as decimal
	Property DataCosto() as DateTime
	Property DataEffettivoPagamento() as DateTime
	Property DataOraRicezione() as DateTime
	Property DataPrevPagam() as DateTime
	Property Descrizione() as string
	Property DocXML() as string
	Property IdAzienda() as integer
	Property IdCaricoMagazzino() as integer
	Property IdCat() as integer
	Property IdDocRif() as integer
	Property IdentificativoSdI() as string
	Property IdMessaggioFE() as string
	Property IdRub() as integer
	Property IdStato() as integer
	Property Importo() as decimal
	Property Iva() as decimal
	Property Numero() as string
	Property PercIva() as integer
	Property Scansione() as string
	Property Scansione1() as string
	Property Scansione2() as string
	Property Scansione3() as string
	Property Scansione4() as string
	Property SpeseIncasso() as decimal
	Property StatoFE() as integer
	Property StatoFEInterno() as integer
	Property Tipo() as integer
	Property Totale() as decimal

#End Region

End Interface

Partial Public Class LFM

	Public Class Costo
		Public Shared ReadOnly Property IdCosto As New LUNA.LunaFieldName("IdCosto")
		Public Shared ReadOnly Property AddebitiVari As New LUNA.LunaFieldName("AddebitiVari")
		Public Shared ReadOnly Property CostoCorr As New LUNA.LunaFieldName("CostoCorr")
		Public Shared ReadOnly Property DataCosto As New LUNA.LunaFieldName("DataCosto")
		Public Shared ReadOnly Property DataEffettivoPagamento As New LUNA.LunaFieldName("DataEffettivoPagamento")
		Public Shared ReadOnly Property DataOraRicezione As New LUNA.LunaFieldName("DataOraRicezione")
		Public Shared ReadOnly Property DataPrevPagam As New LUNA.LunaFieldName("DataPrevPagam")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property DocXML As New LUNA.LunaFieldName("DocXML")
		Public Shared ReadOnly Property IdAzienda As New LUNA.LunaFieldName("IdAzienda")
		Public Shared ReadOnly Property IdCaricoMagazzino As New LUNA.LunaFieldName("IdCaricoMagazzino")
		Public Shared ReadOnly Property IdCat As New LUNA.LunaFieldName("IdCat")
		Public Shared ReadOnly Property IdDocRif As New LUNA.LunaFieldName("IdDocRif")
		Public Shared ReadOnly Property IdentificativoSdI As New LUNA.LunaFieldName("IdentificativoSdI")
		Public Shared ReadOnly Property IdMessaggioFE As New LUNA.LunaFieldName("IdMessaggioFE")
		Public Shared ReadOnly Property IdRub As New LUNA.LunaFieldName("IdRub")
		Public Shared ReadOnly Property IdStato As New LUNA.LunaFieldName("IdStato")
		Public Shared ReadOnly Property Importo As New LUNA.LunaFieldName("Importo")
		Public Shared ReadOnly Property Iva As New LUNA.LunaFieldName("Iva")
		Public Shared ReadOnly Property Numero As New LUNA.LunaFieldName("Numero")
		Public Shared ReadOnly Property PercIva As New LUNA.LunaFieldName("PercIva")
		Public Shared ReadOnly Property Scansione As New LUNA.LunaFieldName("Scansione")
		Public Shared ReadOnly Property Scansione1 As New LUNA.LunaFieldName("Scansione1")
		Public Shared ReadOnly Property Scansione2 As New LUNA.LunaFieldName("Scansione2")
		Public Shared ReadOnly Property Scansione3 As New LUNA.LunaFieldName("Scansione3")
		Public Shared ReadOnly Property Scansione4 As New LUNA.LunaFieldName("Scansione4")
		Public Shared ReadOnly Property SpeseIncasso As New LUNA.LunaFieldName("SpeseIncasso")
		Public Shared ReadOnly Property StatoFE As New LUNA.LunaFieldName("StatoFE")
		Public Shared ReadOnly Property StatoFEInterno As New LUNA.LunaFieldName("StatoFEInterno")
		Public Shared ReadOnly Property Tipo As New LUNA.LunaFieldName("Tipo")
		Public Shared ReadOnly Property Totale As New LUNA.LunaFieldName("Totale")
	End Class

End Class