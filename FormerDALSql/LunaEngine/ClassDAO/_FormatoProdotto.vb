#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 03/02/2021 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Td_formatoprodotto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _FormatoProdotto
	Inherits LUNA.LunaBaseClassEntity
	Implements _IFormatoProdotto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IFormatoProdotto.FillFromDataRecord
		IdFormProd = myRecord("IdFormProd")
		if not myRecord("DescrizioneEstesa") is DBNull.Value then DescrizioneEstesa = myRecord("DescrizioneEstesa")
		if not myRecord("Formato") is DBNull.Value then Formato = myRecord("Formato")
		if not myRecord("IdCatFormatoProdotto") is DBNull.Value then IdCatFormatoProdotto = myRecord("IdCatFormatoProdotto")
		if not myRecord("IdFormCarta") is DBNull.Value then IdFormCarta = myRecord("IdFormCarta")
		if not myRecord("ImgRif") is DBNull.Value then ImgRif = myRecord("ImgRif")
		if not myRecord("IsLastra") is DBNull.Value then IsLastra = myRecord("IsLastra")
		if not myRecord("IsRotolo") is DBNull.Value then IsRotolo = myRecord("IsRotolo")
		if not myRecord("Larghezza") is DBNull.Value then Larghezza = myRecord("Larghezza")
		if not myRecord("Lunghezza") is DBNull.Value then Lunghezza = myRecord("Lunghezza")
		if not myRecord("NomeAlbero") is DBNull.Value then NomeAlbero = myRecord("NomeAlbero")
		if not myRecord("numfacc") is DBNull.Value then numfacc = myRecord("numfacc")
		if not myRecord("Orientabile") is DBNull.Value then Orientabile = myRecord("Orientabile")
		if not myRecord("Orientamento") is DBNull.Value then Orientamento = myRecord("Orientamento")
		if not myRecord("PdfTemplate") is DBNull.Value then PdfTemplate = myRecord("PdfTemplate")
		if not myRecord("PdfTemplate3d") is DBNull.Value then PdfTemplate3d = myRecord("PdfTemplate3d")
		if not myRecord("ProdottoFinito") is DBNull.Value then ProdottoFinito = myRecord("ProdottoFinito")
		if not myRecord("Sigla") is DBNull.Value then Sigla = myRecord("Sigla")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of FormatoProdotto)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(FormatiProdottoDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of FormatoProdotto))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdFormProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrizioneEstesa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Formato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCatFormatoProdotto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgRif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IsLastra As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IsRotolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Larghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Lunghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeAlbero As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property numfacc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Orientabile As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Orientamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PdfTemplate As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PdfTemplate3d As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ProdottoFinito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Sigla As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdFormProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrizioneEstesa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Formato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCatFormatoProdotto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgRif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IsLastra = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IsRotolo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Larghezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Lunghezza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeAlbero = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.numfacc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Orientabile = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Orientamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PdfTemplate = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PdfTemplate3d = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ProdottoFinito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Sigla = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdFormProd as integer  = 0 
	Public Overridable Property IdFormProd() as integer  Implements _IFormatoProdotto.IdFormProd
		Get
			Return _IdFormProd
		End Get
		Set (byval value as integer)
			If _IdFormProd <> value Then
				IsChanged = True
				WhatIsChanged.IdFormProd = True
				_IdFormProd = value
			End If
		End Set
	End property 

	Protected _DescrizioneEstesa as string  = "" 
	Public Overridable Property DescrizioneEstesa() as string  Implements _IFormatoProdotto.DescrizioneEstesa
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

	Protected _Formato as string  = "" 
	Public Overridable Property Formato() as string  Implements _IFormatoProdotto.Formato
		Get
			Return _Formato
		End Get
		Set (byval value as string)
			If _Formato <> value Then
				IsChanged = True
				WhatIsChanged.Formato = True
				_Formato = value
			End If
		End Set
	End property 

	Protected _IdCatFormatoProdotto as integer  = 0 
	Public Overridable Property IdCatFormatoProdotto() as integer  Implements _IFormatoProdotto.IdCatFormatoProdotto
		Get
			Return _IdCatFormatoProdotto
		End Get
		Set (byval value as integer)
			If _IdCatFormatoProdotto <> value Then
				IsChanged = True
				WhatIsChanged.IdCatFormatoProdotto = True
				_IdCatFormatoProdotto = value
			End If
		End Set
	End property 

	Protected _IdFormCarta as integer  = 0 
	Public Overridable Property IdFormCarta() as integer  Implements _IFormatoProdotto.IdFormCarta
		Get
			Return _IdFormCarta
		End Get
		Set (byval value as integer)
			If _IdFormCarta <> value Then
				IsChanged = True
				WhatIsChanged.IdFormCarta = True
				_IdFormCarta = value
			End If
		End Set
	End property 

	Protected _ImgRif as string  = "" 
	Public Overridable Property ImgRif() as string  Implements _IFormatoProdotto.ImgRif
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

	Protected _IsLastra as integer  = 0 
	Public Overridable Property IsLastra() as integer  Implements _IFormatoProdotto.IsLastra
		Get
			Return _IsLastra
		End Get
		Set (byval value as integer)
			If _IsLastra <> value Then
				IsChanged = True
				WhatIsChanged.IsLastra = True
				_IsLastra = value
			End If
		End Set
	End property 

	Protected _IsRotolo as integer  = 0 
	Public Overridable Property IsRotolo() as integer  Implements _IFormatoProdotto.IsRotolo
		Get
			Return _IsRotolo
		End Get
		Set (byval value as integer)
			If _IsRotolo <> value Then
				IsChanged = True
				WhatIsChanged.IsRotolo = True
				_IsRotolo = value
			End If
		End Set
	End property 

	Protected _Larghezza as integer  = 0 
	Public Overridable Property Larghezza() as integer  Implements _IFormatoProdotto.Larghezza
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

	Protected _Lunghezza as integer  = 0 
	Public Overridable Property Lunghezza() as integer  Implements _IFormatoProdotto.Lunghezza
		Get
			Return _Lunghezza
		End Get
		Set (byval value as integer)
			If _Lunghezza <> value Then
				IsChanged = True
				WhatIsChanged.Lunghezza = True
				_Lunghezza = value
			End If
		End Set
	End property 

	Protected _NomeAlbero as string  = "" 
	Public Overridable Property NomeAlbero() as string  Implements _IFormatoProdotto.NomeAlbero
		Get
			Return _NomeAlbero
		End Get
		Set (byval value as string)
			If _NomeAlbero <> value Then
				IsChanged = True
				WhatIsChanged.NomeAlbero = True
				_NomeAlbero = value
			End If
		End Set
	End property 

	Protected _numfacc as integer  = 0 
	Public Overridable Property numfacc() as integer  Implements _IFormatoProdotto.numfacc
		Get
			Return _numfacc
		End Get
		Set (byval value as integer)
			If _numfacc <> value Then
				IsChanged = True
				WhatIsChanged.numfacc = True
				_numfacc = value
			End If
		End Set
	End property 

	Protected _Orientabile as integer  = 0 
	Public Overridable Property Orientabile() as integer  Implements _IFormatoProdotto.Orientabile
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

	Protected _Orientamento as integer  = 0 
	Public Overridable Property Orientamento() as integer  Implements _IFormatoProdotto.Orientamento
		Get
			Return _Orientamento
		End Get
		Set (byval value as integer)
			If _Orientamento <> value Then
				IsChanged = True
				WhatIsChanged.Orientamento = True
				_Orientamento = value
			End If
		End Set
	End property 

	Protected _PdfTemplate as string  = "" 
	Public Overridable Property PdfTemplate() as string  Implements _IFormatoProdotto.PdfTemplate
		Get
			Return _PdfTemplate
		End Get
		Set (byval value as string)
			If _PdfTemplate <> value Then
				IsChanged = True
				WhatIsChanged.PdfTemplate = True
				_PdfTemplate = value
			End If
		End Set
	End property 

	Protected _PdfTemplate3d as string  = "" 
	Public Overridable Property PdfTemplate3d() as string  Implements _IFormatoProdotto.PdfTemplate3d
		Get
			Return _PdfTemplate3d
		End Get
		Set (byval value as string)
			If _PdfTemplate3d <> value Then
				IsChanged = True
				WhatIsChanged.PdfTemplate3d = True
				_PdfTemplate3d = value
			End If
		End Set
	End property 

	Protected _ProdottoFinito as Boolean  = False 
	Public Overridable Property ProdottoFinito() as Boolean  Implements _IFormatoProdotto.ProdottoFinito
		Get
			Return _ProdottoFinito
		End Get
		Set (byval value as Boolean)
			If _ProdottoFinito <> value Then
				IsChanged = True
				WhatIsChanged.ProdottoFinito = True
				_ProdottoFinito = value
			End If
		End Set
	End property 

	Protected _Sigla as string  = "" 
	Public Overridable Property Sigla() as string  Implements _IFormatoProdotto.Sigla
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


#End Region

#Region "Method"
	''' <summary>
	'''This method read an FormatoProdotto from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As FormatoProdotto = Manager.Read(Id)
				_IdFormProd = int.IdFormProd
				_DescrizioneEstesa = int.DescrizioneEstesa
				_Formato = int.Formato
				_IdCatFormatoProdotto = int.IdCatFormatoProdotto
				_IdFormCarta = int.IdFormCarta
				_ImgRif = int.ImgRif
				_IsLastra = int.IsLastra
				_IsRotolo = int.IsRotolo
				_Larghezza = int.Larghezza
				_Lunghezza = int.Lunghezza
				_NomeAlbero = int.NomeAlbero
				_numfacc = int.numfacc
				_Orientabile = int.Orientabile
				_Orientamento = int.Orientamento
				_PdfTemplate = int.PdfTemplate
				_PdfTemplate3d = int.PdfTemplate3d
				_ProdottoFinito = int.ProdottoFinito
				_Sigla = int.Sigla
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
        If IdFormProd Then
            ris = Read(IdFormProd)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an FormatoProdotto on DB.
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
		if _Formato.Length > 255 then Ris = False
		if _ImgRif.Length > 255 then Ris = False
		if _NomeAlbero.Length > 50 then Ris = False
		if _PdfTemplate.Length > 255 then Ris = False
		if _PdfTemplate3d.Length > 255 then Ris = False
		if _Sigla.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Td_formatoprodotto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IFormatoProdotto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdFormProd() as integer
	Property DescrizioneEstesa() as string
	Property Formato() as string
	Property IdCatFormatoProdotto() as integer
	Property IdFormCarta() as integer
	Property ImgRif() as string
	Property IsLastra() as integer
	Property IsRotolo() as integer
	Property Larghezza() as integer
	Property Lunghezza() as integer
	Property NomeAlbero() as string
	Property numfacc() as integer
	Property Orientabile() as integer
	Property Orientamento() as integer
	Property PdfTemplate() as string
	Property PdfTemplate3d() as string
	Property ProdottoFinito() as Boolean
	Property Sigla() as string

#End Region

End Interface

Partial Public Class LFM

	Public Class FormatoProdotto
		Public Shared ReadOnly Property IdFormProd As New LUNA.LunaFieldName("IdFormProd")
		Public Shared ReadOnly Property DescrizioneEstesa As New LUNA.LunaFieldName("DescrizioneEstesa")
		Public Shared ReadOnly Property Formato As New LUNA.LunaFieldName("Formato")
		Public Shared ReadOnly Property IdCatFormatoProdotto As New LUNA.LunaFieldName("IdCatFormatoProdotto")
		Public Shared ReadOnly Property IdFormCarta As New LUNA.LunaFieldName("IdFormCarta")
		Public Shared ReadOnly Property ImgRif As New LUNA.LunaFieldName("ImgRif")
		Public Shared ReadOnly Property IsLastra As New LUNA.LunaFieldName("IsLastra")
		Public Shared ReadOnly Property IsRotolo As New LUNA.LunaFieldName("IsRotolo")
		Public Shared ReadOnly Property Larghezza As New LUNA.LunaFieldName("Larghezza")
		Public Shared ReadOnly Property Lunghezza As New LUNA.LunaFieldName("Lunghezza")
		Public Shared ReadOnly Property NomeAlbero As New LUNA.LunaFieldName("NomeAlbero")
		Public Shared ReadOnly Property numfacc As New LUNA.LunaFieldName("numfacc")
		Public Shared ReadOnly Property Orientabile As New LUNA.LunaFieldName("Orientabile")
		Public Shared ReadOnly Property Orientamento As New LUNA.LunaFieldName("Orientamento")
		Public Shared ReadOnly Property PdfTemplate As New LUNA.LunaFieldName("PdfTemplate")
		Public Shared ReadOnly Property PdfTemplate3d As New LUNA.LunaFieldName("PdfTemplate3d")
		Public Shared ReadOnly Property ProdottoFinito As New LUNA.LunaFieldName("ProdottoFinito")
		Public Shared ReadOnly Property Sigla As New LUNA.LunaFieldName("Sigla")
	End Class

End Class