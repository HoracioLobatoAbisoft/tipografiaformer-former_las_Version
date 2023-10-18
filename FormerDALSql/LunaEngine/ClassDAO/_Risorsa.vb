#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.7.9 
'Author: Diego Lunadei
'Date: 16/09/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_risorse
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Risorsa
    Inherits LUNA.LunaBaseClassEntity
    Implements _IRisorsa
    '******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
    '******So you can replace this file without lost your code

    Public Sub New()

    End Sub
    Public Overridable Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdRis Then
            ris = Read(IdRis)
        End If
        Return ris
    End Function

    Public Sub New(myRecord As IDataRecord)
        FillFromDataRecord(myRecord)
    End Sub

    Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IRisorsa.FillFromDataRecord
        IdRis = myRecord("IdRis")
        If Not myRecord("BarCode") Is DBNull.Value Then BarCode = myRecord("BarCode")
        If Not myRecord("Categoria") Is DBNull.Value Then Categoria = myRecord("Categoria")
        If Not myRecord("Codice") Is DBNull.Value Then Codice = myRecord("Codice")
        If Not myRecord("CostoFoglioFormato") Is DBNull.Value Then CostoFoglioFormato = myRecord("CostoFoglioFormato")
        If Not myRecord("CostoFoglioSteso") Is DBNull.Value Then CostoFoglioSteso = myRecord("CostoFoglioSteso")
        If Not myRecord("CostoTotale") Is DBNull.Value Then CostoTotale = myRecord("CostoTotale")
        If Not myRecord("CostoVenduto") Is DBNull.Value Then CostoVenduto = myRecord("CostoVenduto")
        If Not myRecord("DataAggiornamento") Is DBNull.Value Then DataAggiornamento = myRecord("DataAggiornamento")
        If Not myRecord("Descrizione") Is DBNull.Value Then Descrizione = myRecord("Descrizione")
        If Not myRecord("Giacenza") Is DBNull.Value Then Giacenza = myRecord("Giacenza")
        If Not myRecord("GiacenzaMin") Is DBNull.Value Then GiacenzaMin = myRecord("GiacenzaMin")
        If Not myRecord("Grammatura") Is DBNull.Value Then Grammatura = myRecord("Grammatura")
        If Not myRecord("IdTipoCarta") Is DBNull.Value Then IdTipoCarta = myRecord("IdTipoCarta")
        If Not myRecord("IdUnitaMisura") Is DBNull.Value Then IdUnitaMisura = myRecord("IdUnitaMisura")
        If Not myRecord("IdUnitaMisuraConfezione") Is DBNull.Value Then IdUnitaMisuraConfezione = myRecord("IdUnitaMisuraConfezione")
        If Not myRecord("imgPath") Is DBNull.Value Then imgPath = myRecord("imgPath")
        If Not myRecord("IsLastra") Is DBNull.Value Then IsLastra = myRecord("IsLastra")
        If Not myRecord("Larghezza") Is DBNull.Value Then Larghezza = myRecord("Larghezza")
        If Not myRecord("Lunghezza") Is DBNull.Value Then Lunghezza = myRecord("Lunghezza")
        If Not myRecord("Nlastre") Is DBNull.Value Then Nlastre = myRecord("Nlastre")
        If Not myRecord("ProdottoFinito") Is DBNull.Value Then ProdottoFinito = myRecord("ProdottoFinito")
        If Not myRecord("Stato") Is DBNull.Value Then Stato = myRecord("Stato")
        If Not myRecord("TipoRis") Is DBNull.Value Then TipoRis = myRecord("TipoRis")

        ResetIsChanged()
    End Sub

    Private Property Manager As LUNA.ILunaBaseClassDAO(Of Risorsa)
        Get
            If _Mgr Is Nothing Then
                Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
                If _MgrType Is Nothing Then _MgrType = GetType(RisorseDAO)
                _Mgr = Activator.CreateInstance(_MgrType)
            End If
            Return _Mgr
        End Get
        Set(value As LUNA.ILunaBaseClassDAO(Of Risorsa))
            _Mgr = value
        End Set
    End Property

#Region "Database Field Map"

    Public Class WhatIsChanged

        Public Shared Property IdRis As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property BarCode As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Categoria As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Codice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property CostoFoglioFormato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property CostoFoglioSteso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property CostoTotale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property CostoVenduto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property DataAggiornamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Giacenza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property GiacenzaMin As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Grammatura As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property IdTipoCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property IdUnitaMisura As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property IdUnitaMisuraConfezione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property imgPath As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property IsLastra As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Larghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Lunghezza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Nlastre As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property ProdottoFinito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime
        Public Shared Property TipoRis As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime

    End Class

    Private Sub ResetIsChanged()

        IsChanged = False
        WhatIsChanged.IdRis = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.BarCode = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Categoria = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Codice = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.CostoFoglioFormato = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.CostoFoglioSteso = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.CostoTotale = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.CostoVenduto = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.DataAggiornamento = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Giacenza = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.GiacenzaMin = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Grammatura = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.IdTipoCarta = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.IdUnitaMisura = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.IdUnitaMisuraConfezione = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.imgPath = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.IsLastra = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Larghezza = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Lunghezza = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Nlastre = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.ProdottoFinito = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime
        WhatIsChanged.TipoRis = LUNA.LunaContext.WriteAllFieldEveryTime

    End Sub

    Protected _IdRis As Integer = 0
    Public Overridable Property IdRis() As Integer Implements _IRisorsa.IdRis
        Get
            Return _IdRis
        End Get
        Set(ByVal value As Integer)
            If _IdRis <> value Then
                IsChanged = True
                WhatIsChanged.IdRis = True
                _IdRis = value
            End If
        End Set
    End Property

    Protected _BarCode As String = ""
    Public Overridable Property BarCode() As String Implements _IRisorsa.BarCode
        Get
            Return _BarCode
        End Get
        Set(ByVal value As String)
            If _BarCode <> value Then
                IsChanged = True
                WhatIsChanged.BarCode = True
                _BarCode = value
            End If
        End Set
    End Property

    Protected _Categoria As String = ""
    Public Overridable Property Categoria() As String Implements _IRisorsa.Categoria
        Get
            Return _Categoria
        End Get
        Set(ByVal value As String)
            If _Categoria <> value Then
                IsChanged = True
                WhatIsChanged.Categoria = True
                _Categoria = value
            End If
        End Set
    End Property

    Protected _Codice As String = ""
    Public Overridable Property Codice() As String Implements _IRisorsa.Codice
        Get
            Return _Codice
        End Get
        Set(ByVal value As String)
            If _Codice <> value Then
                IsChanged = True
                WhatIsChanged.Codice = True
                _Codice = value
            End If
        End Set
    End Property

    Protected _CostoFoglioFormato As Decimal = 0
    Public Overridable Property CostoFoglioFormato() As Decimal Implements _IRisorsa.CostoFoglioFormato
        Get
            Return _CostoFoglioFormato
        End Get
        Set(ByVal value As Decimal)
            If _CostoFoglioFormato <> value Then
                IsChanged = True
                WhatIsChanged.CostoFoglioFormato = True
                _CostoFoglioFormato = value
            End If
        End Set
    End Property

    Protected _CostoFoglioSteso As Decimal = 0
    Public Overridable Property CostoFoglioSteso() As Decimal Implements _IRisorsa.CostoFoglioSteso
        Get
            Return _CostoFoglioSteso
        End Get
        Set(ByVal value As Decimal)
            If _CostoFoglioSteso <> value Then
                IsChanged = True
                WhatIsChanged.CostoFoglioSteso = True
                _CostoFoglioSteso = value
            End If
        End Set
    End Property

    Protected _CostoTotale As Decimal = 0
    Public Overridable Property CostoTotale() As Decimal Implements _IRisorsa.CostoTotale
        Get
            Return _CostoTotale
        End Get
        Set(ByVal value As Decimal)
            If _CostoTotale <> value Then
                IsChanged = True
                WhatIsChanged.CostoTotale = True
                _CostoTotale = value
            End If
        End Set
    End Property

    Protected _CostoVenduto As Decimal = 0
    Public Overridable Property CostoVenduto() As Decimal Implements _IRisorsa.CostoVenduto
        Get
            Return _CostoVenduto
        End Get
        Set(ByVal value As Decimal)
            If _CostoVenduto <> value Then
                IsChanged = True
                WhatIsChanged.CostoVenduto = True
                _CostoVenduto = value
            End If
        End Set
    End Property

    Protected _DataAggiornamento As DateTime = Nothing
    Public Overridable Property DataAggiornamento() As DateTime Implements _IRisorsa.DataAggiornamento
        Get
            Return _DataAggiornamento
        End Get
        Set(ByVal value As DateTime)
            If _DataAggiornamento <> value Then
                IsChanged = True
                WhatIsChanged.DataAggiornamento = True
                _DataAggiornamento = value
            End If
        End Set
    End Property

    Protected _Descrizione As String = ""
    Public Overridable Property Descrizione() As String Implements _IRisorsa.Descrizione
        Get
            Return _Descrizione
        End Get
        Set(ByVal value As String)
            If _Descrizione <> value Then
                IsChanged = True
                WhatIsChanged.Descrizione = True
                _Descrizione = value
            End If
        End Set
    End Property

    Protected _Giacenza As Single = 0
    Public Overridable Property Giacenza() As Single Implements _IRisorsa.Giacenza
        Get
            Return _Giacenza
        End Get
        Set(ByVal value As Single)
            If _Giacenza <> value Then
                IsChanged = True
                WhatIsChanged.Giacenza = True
                _Giacenza = value
            End If
        End Set
    End Property

    Protected _GiacenzaMin As Integer = 0
    Public Overridable Property GiacenzaMin() As Integer Implements _IRisorsa.GiacenzaMin
        Get
            Return _GiacenzaMin
        End Get
        Set(ByVal value As Integer)
            If _GiacenzaMin <> value Then
                IsChanged = True
                WhatIsChanged.GiacenzaMin = True
                _GiacenzaMin = value
            End If
        End Set
    End Property

    Protected _Grammatura As Integer = 0
    Public Overridable Property Grammatura() As Integer Implements _IRisorsa.Grammatura
        Get
            Return _Grammatura
        End Get
        Set(ByVal value As Integer)
            If _Grammatura <> value Then
                IsChanged = True
                WhatIsChanged.Grammatura = True
                _Grammatura = value
            End If
        End Set
    End Property

    Protected _IdTipoCarta As Integer = 0
    Public Overridable Property IdTipoCarta() As Integer Implements _IRisorsa.IdTipoCarta
        Get
            Return _IdTipoCarta
        End Get
        Set(ByVal value As Integer)
            If _IdTipoCarta <> value Then
                IsChanged = True
                WhatIsChanged.IdTipoCarta = True
                _IdTipoCarta = value
            End If
        End Set
    End Property

    Protected _IdUnitaMisura As Integer = 0
    Public Overridable Property IdUnitaMisura() As Integer Implements _IRisorsa.IdUnitaMisura
        Get
            Return _IdUnitaMisura
        End Get
        Set(ByVal value As Integer)
            If _IdUnitaMisura <> value Then
                IsChanged = True
                WhatIsChanged.IdUnitaMisura = True
                _IdUnitaMisura = value
            End If
        End Set
    End Property

    Protected _IdUnitaMisuraConfezione As Integer = 0
    Public Overridable Property IdUnitaMisuraConfezione() As Integer Implements _IRisorsa.IdUnitaMisuraConfezione
        Get
            Return _IdUnitaMisuraConfezione
        End Get
        Set(ByVal value As Integer)
            If _IdUnitaMisuraConfezione <> value Then
                IsChanged = True
                WhatIsChanged.IdUnitaMisuraConfezione = True
                _IdUnitaMisuraConfezione = value
            End If
        End Set
    End Property

    Protected _imgPath As String = ""
    Public Overridable Property imgPath() As String Implements _IRisorsa.imgPath
        Get
            Return _imgPath
        End Get
        Set(ByVal value As String)
            If _imgPath <> value Then
                IsChanged = True
                WhatIsChanged.imgPath = True
                _imgPath = value
            End If
        End Set
    End Property

    Protected _IsLastra As Boolean = False
    Public Overridable Property IsLastra() As Boolean Implements _IRisorsa.IsLastra
        Get
            Return _IsLastra
        End Get
        Set(ByVal value As Boolean)
            If _IsLastra <> value Then
                IsChanged = True
                WhatIsChanged.IsLastra = True
                _IsLastra = value
            End If
        End Set
    End Property

    Protected _Larghezza As Single = 0
    Public Overridable Property Larghezza() As Single Implements _IRisorsa.Larghezza
        Get
            Return _Larghezza
        End Get
        Set(ByVal value As Single)
            If _Larghezza <> value Then
                IsChanged = True
                WhatIsChanged.Larghezza = True
                _Larghezza = value
            End If
        End Set
    End Property

    Protected _Lunghezza As Single = 0
    Public Overridable Property Lunghezza() As Single Implements _IRisorsa.Lunghezza
        Get
            Return _Lunghezza
        End Get
        Set(ByVal value As Single)
            If _Lunghezza <> value Then
                IsChanged = True
                WhatIsChanged.Lunghezza = True
                _Lunghezza = value
            End If
        End Set
    End Property

    Protected _Nlastre As Integer = 0
    Public Overridable Property Nlastre() As Integer Implements _IRisorsa.Nlastre
        Get
            Return _Nlastre
        End Get
        Set(ByVal value As Integer)
            If _Nlastre <> value Then
                IsChanged = True
                WhatIsChanged.Nlastre = True
                _Nlastre = value
            End If
        End Set
    End Property

    Protected _ProdottoFinito As Integer = 0
    Public Overridable Property ProdottoFinito() As Integer Implements _IRisorsa.ProdottoFinito
        Get
            Return _ProdottoFinito
        End Get
        Set(ByVal value As Integer)
            If _ProdottoFinito <> value Then
                IsChanged = True
                WhatIsChanged.ProdottoFinito = True
                _ProdottoFinito = value
            End If
        End Set
    End Property

    Protected _Stato As Integer = 0
    Public Overridable Property Stato() As Integer Implements _IRisorsa.Stato
        Get
            Return _Stato
        End Get
        Set(ByVal value As Integer)
            If _Stato <> value Then
                IsChanged = True
                WhatIsChanged.Stato = True
                _Stato = value
            End If
        End Set
    End Property

    Protected _TipoRis As Integer = 0
    Public Overridable Property TipoRis() As Integer Implements _IRisorsa.TipoRis
        Get
            Return _TipoRis
        End Get
        Set(ByVal value As Integer)
            If _TipoRis <> value Then
                IsChanged = True
                WhatIsChanged.TipoRis = True
                _TipoRis = value
            End If
        End Set
    End Property


#End Region

#Region "Method"
    ''' <summary>
    '''This method read an Risorsa from DB.
    ''' </summary>
    ''' <returns>
    '''Return 0 if all ok, 1 if error
    ''' </returns>
    Public Overridable Function Read(Id As Integer) As Integer
        'Return 0 if all ok
        Dim Ris As Integer = 0
        Try
            Using Manager
                Dim int As Risorsa = Manager.Read(Id)
                _IdRis = int.IdRis
                _BarCode = int.BarCode
                _Categoria = int.Categoria
                _Codice = int.Codice
                _CostoFoglioFormato = int.CostoFoglioFormato
                _CostoFoglioSteso = int.CostoFoglioSteso
                _CostoTotale = int.CostoTotale
                _CostoVenduto = int.CostoVenduto
                _DataAggiornamento = int.DataAggiornamento
                _Descrizione = int.Descrizione
                _Giacenza = int.Giacenza
                _GiacenzaMin = int.GiacenzaMin
                _Grammatura = int.Grammatura
                _IdTipoCarta = int.IdTipoCarta
                _IdUnitaMisura = int.IdUnitaMisura
                _IdUnitaMisuraConfezione = int.IdUnitaMisuraConfezione
                _imgPath = int.imgPath
                _IsLastra = int.IsLastra
                _Larghezza = int.Larghezza
                _Lunghezza = int.Lunghezza
                _Nlastre = int.Nlastre
                _ProdottoFinito = int.ProdottoFinito
                _Stato = int.Stato
                _TipoRis = int.TipoRis
            End Using
            Manager = Nothing
        Catch ex As Exception
            ManageError(ex)
            Ris = 1
        End Try
        Return Ris
    End Function

    ''' <summary>
    '''This method save an Risorsa on DB.
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
            Manager = Nothing
        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Protected Function InternalIsValid() As Boolean
        Dim Ris As Boolean = True
        If _BarCode.Length > 255 Then Ris = False
        If _Categoria.Length > 255 Then Ris = False
        If _Codice.Length > 50 Then Ris = False
        If _Descrizione.Length > 1000 Then Ris = False
        If _imgPath.Length > 255 Then Ris = False

        Return Ris
    End Function

#End Region

#Region "Embedded Class"


#End Region

End Class

''' <summary>
'''Interface for table T_risorse
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IRisorsa

    Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

    Property IdRis() As Integer
    Property BarCode() As String
    Property Categoria() As String
    Property Codice() As String
    Property CostoFoglioFormato() As Decimal
    Property CostoFoglioSteso() As Decimal
    Property CostoTotale() As Decimal
    Property CostoVenduto() As Decimal
    Property DataAggiornamento() As DateTime
    Property Descrizione() As String
    Property Giacenza() As Single
    Property GiacenzaMin() as integer
	Property Grammatura() as integer
	Property IdTipoCarta() as integer
	Property IdUnitaMisura() as integer
	Property IdUnitaMisuraConfezione() as integer
	Property imgPath() as string
	Property IsLastra() as Boolean
	Property Larghezza() as Single
	Property Lunghezza() as Single
	Property Nlastre() as integer
	Property ProdottoFinito() as integer
	Property Stato() as integer
	Property TipoRis() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class Risorsa
		Public Shared ReadOnly Property IdRis As New LUNA.LunaFieldName("IdRis")
		Public Shared ReadOnly Property BarCode As New LUNA.LunaFieldName("BarCode")
		Public Shared ReadOnly Property Categoria As New LUNA.LunaFieldName("Categoria")
		Public Shared ReadOnly Property Codice As New LUNA.LunaFieldName("Codice")
		Public Shared ReadOnly Property CostoFoglioFormato As New LUNA.LunaFieldName("CostoFoglioFormato")
		Public Shared ReadOnly Property CostoFoglioSteso As New LUNA.LunaFieldName("CostoFoglioSteso")
		Public Shared ReadOnly Property CostoTotale As New LUNA.LunaFieldName("CostoTotale")
		Public Shared ReadOnly Property CostoVenduto As New LUNA.LunaFieldName("CostoVenduto")
		Public Shared ReadOnly Property DataAggiornamento As New LUNA.LunaFieldName("DataAggiornamento")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property Giacenza As New LUNA.LunaFieldName("Giacenza")
		Public Shared ReadOnly Property GiacenzaMin As New LUNA.LunaFieldName("GiacenzaMin")
		Public Shared ReadOnly Property Grammatura As New LUNA.LunaFieldName("Grammatura")
		Public Shared ReadOnly Property IdTipoCarta As New LUNA.LunaFieldName("IdTipoCarta")
		Public Shared ReadOnly Property IdUnitaMisura As New LUNA.LunaFieldName("IdUnitaMisura")
		Public Shared ReadOnly Property IdUnitaMisuraConfezione As New LUNA.LunaFieldName("IdUnitaMisuraConfezione")
		Public Shared ReadOnly Property imgPath As New LUNA.LunaFieldName("imgPath")
		Public Shared ReadOnly Property IsLastra As New LUNA.LunaFieldName("IsLastra")
		Public Shared ReadOnly Property Larghezza As New LUNA.LunaFieldName("Larghezza")
		Public Shared ReadOnly Property Lunghezza As New LUNA.LunaFieldName("Lunghezza")
		Public Shared ReadOnly Property Nlastre As New LUNA.LunaFieldName("Nlastre")
		Public Shared ReadOnly Property ProdottoFinito As New LUNA.LunaFieldName("ProdottoFinito")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
		Public Shared ReadOnly Property TipoRis As New LUNA.LunaFieldName("TipoRis")
	End Class

End Class