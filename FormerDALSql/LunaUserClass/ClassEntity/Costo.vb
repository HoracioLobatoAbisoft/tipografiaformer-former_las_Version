#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports System.Drawing
Imports FormerLib

''' <summary>
'''Entity Class for table T_contabcosti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Costo
    Inherits _Costo
    Implements ICosto

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Private _Ammortamento As AmmortamentoCosto = Nothing
    Public ReadOnly Property Ammortamento As AmmortamentoCosto
        Get
            If _Ammortamento Is Nothing Then
                Using mgr As New AmmortamentoCostiDAO
                    Dim l As List(Of AmmortamentoCosto) = mgr.FindAll(New LUNA.LSP(LFM.AmmortamentoCosto.IdCosto, IdCosto))
                    If l.Count Then
                        _Ammortamento = l(0)
                    End If
                End Using
            End If

            Return _Ammortamento
        End Get
    End Property


    Public ReadOnly Property TotaleStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Totale)
        End Get
    End Property

    'Public Overrides Property Importo As Decimal
    '    Get
    '        Return Math.Abs(MyBase.Importo)
    '    End Get
    '    Set(value As Decimal)
    '        MyBase.Importo = value
    '    End Set
    'End Property
    'Public Overrides Property Iva As Decimal
    '    Get
    '        Return Math.Abs(MyBase.Iva)
    '    End Get
    '    Set(value As Decimal)
    '        MyBase.Iva = value
    '    End Set
    'End Property

    'Public Overrides Property Totale As Decimal
    '    Get
    '        Return Math.Abs(MyBase.Totale)
    '    End Get
    '    Set(value As Decimal)
    '        MyBase.Totale = value
    '    End Set
    'End Property

    Public ReadOnly Property TotaleMatematico As Decimal
        Get
            Dim ris As Decimal = Totale
            If Tipo = enTipoDocumento.NotaDiCredito Then
                ris = -ris
            End If
            Return ris
        End Get
    End Property
    Public ReadOnly Property TotaleGiaPagato As Decimal
        Get
            Dim ris As Decimal = 0
            For Each SingPag In ListaPagamenti
                ris += SingPag.Importo
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleAncoraDaPagare As Decimal
        Get
            Dim ris As Decimal = 0

            If IdStato <> enStatoDocumentoFiscale.PagatoInteramente Then
                If Tipo <> enTipoDocumento.NotaDiCredito Then
                    ris = Totale - TotaleGiaPagato
                End If

                If ris < 0 Then ris = 0
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property PagatoInteramente As Boolean
        Get
            Dim ris As Boolean = False
            If Tipo = enTipoDocumento.DDT Then
                'If Not f Is Nothing AndAlso FatturaRiepilogativaRif.PagatoInteramente = True Then
                '    ris = True
                'End If
                ris = True
            Else
                If TotaleAncoraDaPagare = 0 Then ris = True
            End If


            Return ris
        End Get
    End Property

    Public ReadOnly Property ImportoMatematico As Decimal
        Get
            Dim ris As Decimal = Importo
            If Tipo = enTipoDocumento.NotaDiCredito Then
                ris = -ris
            End If
            Return ris
        End Get
    End Property
    Public ReadOnly Property IvaMatematico As Decimal
        Get
            Dim ris As Decimal = Iva
            If Tipo = enTipoDocumento.NotaDiCredito Then
                ris = -ris
            End If
            Return ris
        End Get
    End Property


    Public ReadOnly Property imgLinkCarico As Image
        Get
            Dim ris As Image = Nothing

            If IdCat = FormerLib.FormerConst.CategorieContabili.MateriePrime And
               (Tipo = enTipoDocumento.DDT Or
               Tipo = enTipoDocumento.Fattura Or
               Tipo = enTipoDocumento.FatturaRiepilogativa) Then
                If StatoFEInterno = enStatoFEInterno.Inserito Then
                    ris = My.Resources._NoLink
                ElseIf StatoFEInterno = enStatoFEInterno.Anomalia Then
                    ris = My.Resources._LinkWarning
                ElseIf StatoFEInterno = enStatoFEInterno.Collegato Then
                    ris = My.Resources._LinkOk
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property pRagSocEx As String
        Get
            Dim ris As String = String.Empty

            ris = "<html><b>" & pRagSoc & "</b>"

            If Fornitore.Cellulare.Length AndAlso Fornitore.Cellulare <> "0" Then
                ris &= ControlChars.NewLine & "<i>(Tel. " & Fornitore.Cellulare & ")</i>"
            ElseIf Fornitore.Tel.Length AndAlso Fornitore.Tel <> "0" Then
                ris &= ControlChars.NewLine & "<i>(Tel. " & Fornitore.Tel & ")</i>"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property StatoFEStr As String
        Get
            Dim ris As String = String.Empty
            If (Tipo = enTipoDocumento.Fattura OrElse
                Tipo = enTipoDocumento.FatturaRiepilogativa OrElse
                Tipo = enTipoDocumento.NotaDiCredito OrElse
                Tipo = enTipoDocumento.NotaDiDebito OrElse
                Tipo = enTipoDocumento.AccontoAnticipoSuFattura) AndAlso
                DataCosto.Year >= 2019 Then
                ris = FormerEnumHelper.GetStatoFEStr(StatoFE)
            Else
                ris = "-"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property AziendaStr As String
        Get
            Dim ris As String = ""

            ris = MgrAziende.GetAziendaStr(IdAzienda)

            Return ris
        End Get
    End Property

    Public Property DataRif As Date
        Get
            Return _DataCosto
        End Get
        Set(value As Date)
            _DataCosto = value
        End Set
    End Property
    Private _Fornitore As VoceRubrica
    Public ReadOnly Property Fornitore As VoceRubrica
        Get
            If _Fornitore Is Nothing Then
                _Fornitore = New VoceRubrica
                _Fornitore.Read(IdRub)
            End If
            Return _Fornitore
        End Get
    End Property

    'Protected _pRagSoc As String = ""
    Public ReadOnly Property pRagSoc() As String
        Get
            Return Fornitore.RagSocNome
        End Get
        'Set(ByVal value As String)
        '    If _pRagSoc <> value Then
        '        IsChanged = True
        '        _pRagSoc = value
        '    End If
        'End Set
    End Property

    Protected _pIndirizzo As String = ""
    Public Property pIndirizzo() As String
        Get
            Return _pIndirizzo
        End Get
        Set(ByVal value As String)
            If _pIndirizzo <> value Then
                IsChanged = True
                _pIndirizzo = value
            End If
        End Set
    End Property

    Protected _pCitta As String = ""
    Public Property pCitta() As String
        Get
            Return _pCitta
        End Get
        Set(ByVal value As String)
            If _pCitta <> value Then
                IsChanged = True
                _pCitta = value
            End If
        End Set
    End Property

    Protected _pCap As String = ""
    Public Property pCap() As String
        Get
            Return _pCap
        End Get
        Set(ByVal value As String)
            If _pCap <> value Then
                IsChanged = True
                _pCap = value
            End If
        End Set
    End Property

    Protected _pIva As String = ""
    Public Property pIva() As String
        Get
            Return _pIva
        End Get
        Set(ByVal value As String)
            If _pIva <> value Then
                IsChanged = True
                _pIva = value
            End If
        End Set
    End Property

    Public Property Stato As enStatoDocumentoFiscale

    Public Function Intestazione() As String

        Dim Intest As String = pRagSoc & " (" & _IdRub & ")" & vbNewLine
        Intest &= _pIndirizzo & vbNewLine
        Intest &= _pCitta & vbNewLine
        Intest &= _pCap & vbNewLine
        Intest &= "P.IVA " & _pIva & vbNewLine
        Return Intest
    End Function

    Public ReadOnly Property TipoStr As String
        Get
            Return FormerEnumHelper.TipoDocumentoFiscaleStr(Tipo)
        End Get
    End Property

    Public ReadOnly Property AnnoStr As String
        Get
            Return DataCosto.Year
        End Get
    End Property

    Public ReadOnly Property ListaPagamenti As List(Of Pagamento)
        Get
            'caricamento forzato ogni volta per essere sicuro di leggere sempre tutti i pagamenti
            Dim ris As List(Of Pagamento)
            Using mgr As New PagamentiDAO
                ris = mgr.FindAll("datapag desc",
                                  New LUNA.LunaSearchParameter(LFM.Pagamento.IdFat, IdCosto),
                                  New LUNA.LunaSearchParameter(LFM.Pagamento.Tipo, enTipoVoceContab.VoceAcquisto))

            End Using
            Return ris
        End Get
    End Property

    Public ReadOnly Property DataEffPagam As String
        Get
            Dim ris As String = "-"

            If Tipo <> enTipoDocumento.DDT Then
                If IdStato = enStatoDocumentoFiscale.PagatoAcconto OrElse
                   IdStato = enStatoDocumentoFiscale.PagatoInteramente Then
                    If DataEffettivoPagamento <> Date.MinValue Then
                        ris = DataEffettivoPagamento.ToString("dd/MM/yyyy")
                    End If
                End If
            End If

            'Dim TotalePag As Decimal = ListaPagamenti.Sum(Function(x) x.Importo)
            'If Tipo <> enTipoDocumento.DDT Then
            '    If FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Totale, 2) = TotalePag Then
            '        If ListaPagamenti.Count Then
            '            ris = ListaPagamenti(0).DataPag.ToString("dd/MM/yyyy")
            '        Else
            '            ris = "-"
            '        End If
            '    End If
            'End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property PagatoStr As String
        Get
            Dim ris As String = "No"

            If Tipo = enTipoDocumento.DDT Then
                ris = "-"
            Else
                'Dim TotalePag As Decimal = ListaPagamenti.Sum(Function(x) x.Importo)
                If TotaleAncoraDaPagare = 0 Then
                    ris = "SI"
                ElseIf TotaleGiaPagato <> 0 Then
                    ris = "Parz."
                End If
            End If


            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICosto.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICosto.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Refresh() As Integer
        Dim Ris As Integer = MyBase.Refresh()

        _Ammortamento = Nothing
        _Fornitore = Nothing

        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICosto.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

    Public ReadOnly Property TipoDocStr As String
        Get
            Dim ris As String = String.Empty

            ris = FormerEnumHelper.TipoDocumentoFiscaleStr(Tipo)

            Return ris
        End Get
    End Property
    Public ReadOnly Property ListaVociFatturaOnlyThis As List(Of VoceCosto)
        Get
            Dim ris As New List(Of VoceCosto)
            Using mgr As New VociCostoDAO
                ris = mgr.FindAll(LFM.VoceCosto.IdVoceCosto.Name, New LUNA.LunaSearchParameter(LFM.VoceCosto.IdCosto, IdCosto))
            End Using
            Return ris
        End Get
    End Property

    Public ReadOnly Property ListaVociFattura As List(Of VoceCosto)
        Get
            Dim ris As New List(Of VoceCosto)
            Using mgr As New VociCostoDAO

                If Tipo = enTipoDocumento.FatturaRiepilogativa Then
                    For Each C As Costo In ListaDocumenti
                        ris.AddRange(C.ListaVociFatturaOnlyThis)
                    Next
                End If
                ris.AddRange(ListaVociFatturaOnlyThis)
                'If Tipo = enTipoDocumento.FatturaRiepilogativa Then
                '    ris = New List(Of MovimentoMagazzino)
                '    For Each C As Costo In ListaDocumenti
                '        ris.AddRange(C.ListaDettaglio)
                '    Next
                'Else
                '    ris = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = LFM.MovimentoMagazzino.IdCarMag.Name},
                '                      New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdFat, IdCosto))
                'End If

            End Using
            Return ris
        End Get
    End Property

    Public ReadOnly Property ListaDettaglio As List(Of MovimentoMagazzino)
        Get
            Dim ris As List(Of MovimentoMagazzino) = Nothing
            Using mgr As New MagazzinoDAO

                If Tipo = enTipoDocumento.FatturaRiepilogativa Then
                    ris = New List(Of MovimentoMagazzino)
                    For Each C As Costo In ListaDocumenti
                        ris.AddRange(C.ListaDettaglio)
                    Next
                Else
                    ris = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = LFM.MovimentoMagazzino.IdCarMag.Name},
                                      New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdFat, IdCosto))
                End If

            End Using
            Return ris
        End Get
    End Property

    Public ReadOnly Property ListaDocumenti As List(Of Costo)
        Get
            Dim ris As List(Of Costo) = Nothing
            Using mgr As New CostiDAO
                ris = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = LFM.Costo.DataCosto.Name},
                                  New LUNA.LunaSearchParameter(LFM.Costo.IdDocRif, IdCosto))
            End Using
            Return ris
        End Get
    End Property

End Class

'Public Class CostoEx
'    Inherits Costo
'    Public Sub New()
'        MyBase.New()
'    End Sub

'    Public Sub New(myRecord As IDataRecord)
'        MyBase.New(myRecord)
'    End Sub

'    Public Sub New(TransactionBoxRif As LUNA.LunaTransactionBox)
'        MyBase.New(TransactionBoxRif)
'    End Sub

'    'Public Property pRagSoc As String = String.Empty



'End Class


''' <summary>
'''Interface for table T_contabcosti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICosto
    Inherits _ICosto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface