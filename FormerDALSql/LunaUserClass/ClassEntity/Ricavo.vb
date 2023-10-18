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
Imports FormerLib

''' <summary>
'''Entity Class for table T_contabricavi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Ricavo
    Inherits _Ricavo
    Implements IRicavo

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Fattura Elettronica"
    Public ReadOnly Property FAPAFormatoTrasmissioneVersoPrivati As String
        Get
            Dim ris As String = "FPR12"
            'tornrare il codice giusto a seconda che si tratti o meno di pubblica amministrazione
            Return ris
        End Get
    End Property

    Public ReadOnly Property FAPAFormatoTrasmissioneVersoPA As String
        Get
            Dim ris As String = "FPA12"
            'tornrare il codice giusto a seconda che si tratti o meno di pubblica amministrazione
            Return ris
        End Get
    End Property

    Public ReadOnly Property FAPATipoDocumento As String
        Get
            Dim ris As String = String.Empty

            If Tipo = enTipoDocumento.Fattura Or Tipo = enTipoDocumento.FatturaRiepilogativa Then
                ris = "TD01"
            ElseIf Tipo = enTipoDocumento.NotaDiCredito Then
                ris = "TD04"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property FAPADataRicavoStr As String
        Get
            Return DataRicavo.ToString("yyyy-MM-dd")
        End Get
    End Property

    Public ReadOnly Property FAPADataScadenzaPagamentoStr As String
        Get
            Return Dataprevpagam.ToString("yyyy-MM-dd")
        End Get
    End Property

    Public ReadOnly Property FAPATotaleDocumento As String
        Get
            Dim ris As String = FormerLib.FormerHelper.Stringhe.FormattaPrezzoFAPA(Totale)
            Return ris
        End Get
    End Property

    Public ReadOnly Property FAPACausaleTrasporto As String
        Get
            Return "Vendita"
        End Get
    End Property

    Public ReadOnly Property FAPAModalitaPagamento As String
        Get
            Dim ris As String = String.Empty

            Select Case Idpagamento
                Case enMetodoPagamento.Contanti, enMetodoPagamento.AllaConsegna
                    ris = "MP01"
                Case enMetodoPagamento.BonificoBancario, enMetodoPagamento.BonificoBancarioAnticipato
                    ris = "MP05"
                Case enMetodoPagamento.CartaDiCredito, enMetodoPagamento.PayPal
                    ris = "MP08"
                Case enMetodoPagamento.ContrassegnoAlRitiro
                    ris = "MP02"
                Case Else
                    ris = "MP05"
            End Select


            Return ris
        End Get
    End Property

    Public ReadOnly Property FAPAPesoLordo As String
        Get
            Dim ris As String = CInt(Peso) & ".00"
            'ris = ris.ToString("F") '.Replace(",", ".")
            Return ris
        End Get
    End Property
#End Region

#Region "Logic Field"

    Private _NotaDiCreditoRelativa As Ricavo = Nothing
    Public ReadOnly Property NotaDiCreditoRelativa As Ricavo
        Get
            If _NotaDiCreditoRelativa Is Nothing Then
                Using mgr As New RicaviDAO

                    Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LSP(LFM.Ricavo.IdFatturaNotaDiCredito, IdRicavo),
                                                       New LUNA.LSP(LFM.Ricavo.Tipo, enTipoDocumento.NotaDiCredito))
                    If l.Count Then
                        _NotaDiCreditoRelativa = l(0)

                    End If
                End Using
            End If

            Return _NotaDiCreditoRelativa
        End Get
    End Property

    Private _RicavoRiferimentoNotadiCredito As Ricavo = Nothing
    Public ReadOnly Property RicavoRiferimentoNotadiCredito As Ricavo
        Get

            If _RicavoRiferimentoNotadiCredito Is Nothing Then
                If IdFatturaNotaDiCredito Then
                    _RicavoRiferimentoNotadiCredito = New Ricavo
                    _RicavoRiferimentoNotadiCredito.Read(IdFatturaNotaDiCredito)
                End If
            End If

            Return _RicavoRiferimentoNotadiCredito
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty

            ris = AziendaStr & " " & TipoDocStr & " " & NumeroCompleto & " del " & DataRicavoStr

            Return ris
        End Get
    End Property

    Public ReadOnly Property pRagSocEx As String
        Get
            Dim ris As String = String.Empty

            ris = "<html><b>" & pRagSoc & "</b>"

            If VoceRubrica.Cellulare.Length AndAlso VoceRubrica.Cellulare <> "0" Then
                ris &= ControlChars.NewLine & "<i>(Tel. " & VoceRubrica.Cellulare & ")</i>"
            ElseIf VoceRubrica.Tel.Length AndAlso VoceRubrica.tel <> "0" Then
                ris &= ControlChars.NewLine & "<i>(Tel. " & VoceRubrica.Tel & ")</i>"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property NumeroCompleto As String
        Get
            Dim ris As String = String.Empty

            ris = Numero & "/" & AnnoRiferimento

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
                DataRicavo.Year >= 2019 Then
                ris = FormerEnumHelper.GetStatoFEStr(StatoFE)
            Else
                ris = "-"
            End If

            Return ris
        End Get
    End Property

    Private _FatturaRiepilogativaRif As Ricavo
    Public ReadOnly Property FatturaRiepilogativaRif As Ricavo
        Get
            If _FatturaRiepilogativaRif Is Nothing Then
                If IdDocRif Then
                    _FatturaRiepilogativaRif = New Ricavo
                    _FatturaRiepilogativaRif.Read(IdDocRif)

                End If
            End If


            Return _FatturaRiepilogativaRif
        End Get
    End Property

    Public ReadOnly Property ListaDDT As List(Of Ricavo)
        Get
            Dim ris As List(Of Ricavo)
            If Tipo = enTipoDocumento.FatturaRiepilogativa Then
                Using mgr As New RicaviDAO
                    ris = mgr.FindAll(LFM.Ricavo.IdRicavo, New LUNA.LunaSearchParameter(LFM.Ricavo.IdDocRif, IdRicavo))
                End Using
            Else
                ris = New List(Of Ricavo)
            End If

            Return ris

        End Get
    End Property

    Public ReadOnly Property ListaRigheFat As List(Of VoceFattura)
        Get
            Dim ris As List(Of VoceFattura)

            Using mgr As New VociFatturaDAO

                Dim Ordinamento As String = String.Empty
                Dim pIdDoc As LUNA.LunaSearchParameter = Nothing

                If Tipo = enTipoDocumento.FatturaRiepilogativa Then
                    Ordinamento = "IdDoc,IdOrd DESC"
                    pIdDoc = New LUNA.LunaSearchParameter(LFM.VoceFattura.IdDoc, "(SELECT IDRICAVO FROM T_CONTABRICAVI WHERE IDDOCRIF=" & IdRicavo & ")", " IN ")
                Else
                    Ordinamento = "IdOrd DESC"
                    pIdDoc = New LUNA.LunaSearchParameter(LFM.VoceFattura.IdDoc, IdRicavo)
                End If

                ris = mgr.FindAll(Ordinamento, pIdDoc)
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property UsareStampanteSNC As Boolean
        Get
            Dim ris As Boolean = False

            If Tipo <> enTipoDocumento.Preventivo Then
                If IdAzienda = MgrAziende.IdAziende.AziendaSnc Then
                    ris = True
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property IdRubRif As Integer
        Get
            Dim ris As Integer = IdRub
            Return ris
        End Get
    End Property


    Private _VoceRubrica As VoceRubrica = Nothing
    Public ReadOnly Property VoceRubrica As VoceRubrica
        Get
            If _VoceRubrica Is Nothing Then
                _VoceRubrica = New VoceRubrica
                _VoceRubrica.Read(IdRubRif)
            End If
            Return _VoceRubrica
        End Get
    End Property


    Private _ConsegnaRif As ConsegnaProgrammata = Nothing
    Public ReadOnly Property ConsegnaRif As ConsegnaProgrammata
        Get
            If _ConsegnaRif Is Nothing Then

                _ConsegnaRif = New ConsegnaProgrammata
                _ConsegnaRif.Read(IdConsegnaRif)

            End If
            Return _ConsegnaRif
        End Get
    End Property

    Public ReadOnly Property AziendaStr As String
        Get
            Dim ris As String = ""

            ris = MgrAziende.GetAziendaStr(IdAzienda)

            Return ris
        End Get
    End Property

    Public ReadOnly Property AnnoRiferimento As String
        Get
            Dim ris As String = String.Empty

            ris = DataRicavo.Year

            Return ris
        End Get
    End Property

    Public ReadOnly Property AnnotazioniDaConsegna As String
        Get
            Dim ris As String = String.Empty

            Using c As New ConsegnaProgrammata
                c.Read(IdConsegnaRif)
                ris = c.Annotazioni
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property IdConsegnaRif As Integer
        Get
            Dim ris As Integer = 0

            If ListaOrdini.Count Then
                ris = ListaOrdini(0).IdCons
            End If

            Return ris
        End Get
    End Property

    Private _ListaOrdini As List(Of Ordine) = Nothing
    Public ReadOnly Property ListaOrdini As List(Of Ordine)
        Get
            If _ListaOrdini Is Nothing Then
                Using mgr As New OrdiniDAO
                    _ListaOrdini = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdDoc, _IdRicavo))
                End Using
            End If
            Return _ListaOrdini
        End Get
    End Property

    Public ListaIdOrd As New List(Of Integer)
    'Public Function Intestaziones() As String

    '    Dim Intest As String = String.Empty

    '    If AnnoRiferimento >= 2019 Then
    '        If StatoFE = enStatoFatturaFE.DaInviare Or StatoFE = enStatoFatturaFE.ScartataSDI Or StatoFE = enStatoFatturaFE.InCodaInvio Then
    '            Intest = VoceRubrica.RagSocNome & " (" & IdRub & ")" & ControlChars.NewLine
    '            Intest &= VoceRubrica.Indirizzo & ControlChars.NewLine
    '            Intest &= 

    '        Else

    '        End If
    '    Else
    '        Intest = _pRagSoc & " (" & _IdRub & ")" & vbNewLine
    '        Intest &= _pIndirizzo & vbNewLine
    '        Intest &= _pCitta & vbNewLine
    '        Intest &= _pCap & vbNewLine
    '        Intest &= "P.IVA " & _pIva & vbNewLine
    '        Intest &= "Ind.Cons. " & _pIndCons & vbNewLine
    '        Intest &= "Pagamento " & _pPagamento & vbNewLine
    '    End If
    '    Return Intest

    'End Function

    Public Property DataRif As Date
        Get
            Return DataRicavo
        End Get
        Set(value As Date)
            DataRicavo = value
        End Set
    End Property

    Public Function CalcolaDataPrevPagam() As Date

        Dim Ris As Date = _DataRicavo

        Dim tp As New TipoPagamento
        tp.Read(_Idpagamento)

        If tp.ggToAdd Then
            Ris = Ris.AddDays(tp.ggToAdd)
        End If

        Return Ris
    End Function

    Public ReadOnly Property ListaPagamenti As List(Of Pagamento)
        Get
            'caricamento forzato ogni volta per essere sicuro di leggere sempre tutti i pagamenti
            Dim ris As List(Of Pagamento)
            Using mgr As New PagamentiDAO
                ris = mgr.FindAll("datapag desc",
                                  New LUNA.LunaSearchParameter("IdFat", IdRicavo),
                                  New LUNA.LunaSearchParameter(LFM.Pagamento.Tipo, TipoVoce))

            End Using
            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoDocStr As String
        Get
            Dim ris As String = String.Empty

            ris = FormerEnumHelper.TipoDocumentoFiscaleStr(Tipo)

            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoVoce As enTipoVoceContab
        Get
            Return enTipoVoceContab.VoceVendita
        End Get
    End Property

    Public ReadOnly Property TotaleGiaPagato As Decimal
        Get
            Dim ris As Decimal = 0


            If Stato <> enStatoDocumentoFiscale.PagatoInteramente Then
                For Each SingPag In ListaPagamenti
                    ris += SingPag.Importo
                Next
            Else
                ris = Totale
            End If


            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleAncoraDaPagare As Decimal
        Get
            Dim ris As Decimal = 0
            Dim TotaleDaControllare As Decimal = Totale

            If Stato <> enStatoDocumentoFiscale.PagatoInteramente Then

                If EsigibilitaIva = enEsigibilitaIVA.SplitPayment Then
                    TotaleDaControllare = Importo
                End If

                If Tipo <> enTipoDocumento.NotaDiCredito Then
                    ris = TotaleDaControllare - TotaleGiaPagato
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
                If Not FatturaRiepilogativaRif Is Nothing AndAlso FatturaRiepilogativaRif.PagatoInteramente = True Then
                    ris = True
                End If
            Else
                If TotaleAncoraDaPagare = 0 Then ris = True
            End If


            Return ris
        End Get
    End Property

    Public Property Stato As enStatoDocumentoFiscale
        Get
            Return _idstato
        End Get
        Set(value As enStatoDocumentoFiscale)
            _idstato = value
        End Set
    End Property

    Public ReadOnly Property DataRicavoStr As String
        Get
            Return DataRicavo.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public Overrides Property Iva As Decimal
        Get
            Return MyBase.Iva
        End Get
        Set(value As Decimal)
            MyBase.Iva = value
        End Set
    End Property

    Public ReadOnly Property TotaleMatematico As Decimal
        Get
            Dim ris As Decimal = Totale
            If Tipo = enTipoDocumento.NotaDiCredito Then
                ris = -ris
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

    Public Overrides Property Totale() As Decimal
        Get
            Return FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(MyBase.Totale, 2)
        End Get
        Set(value As Decimal)
            MyBase.Totale = value
        End Set
    End Property

    Public ReadOnly Property TotaleStr As String
        Get
            Dim ris As String = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Totale)
            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleAncoraDaPagareStr As String
        Get
            Dim ris As String = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotaleAncoraDaPagare)
            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoStr As String
        Get
            Return FormerEnumHelper.TipoDocumentoFiscaleStr(Tipo)
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IRicavo.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IRicavo.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Refresh() As Integer
        Dim Ris As Integer = MyBase.Refresh

        _ConsegnaRif = Nothing
        _FatturaRiepilogativaRif = Nothing
        _ListaOrdini = Nothing
        _NotaDiCreditoRelativa = Nothing
        _RicavoRiferimentoNotadiCredito = Nothing
        _VoceRubrica = Nothing



        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IRicavo.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Sub AumentaCounterStampe()

        Using mgr As New RicaviDAO
            mgr.AumentaCounterStampe(Me)
        End Using
    End Sub

#End Region

End Class

Public Class RicavoEx
    Inherits Ricavo
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    Public Sub New(TransactionBoxRif As LUNA.LunaTransactionBox)
        MyBase.New(TransactionBoxRif)
    End Sub

    Public Property Incassati As Decimal = 0

    'Public Property Differenza As Decimal = 0

    Public Property FatturaRif As String = String.Empty
    Public Property DataPagamento As Date = Date.MinValue

    Public ReadOnly Property StatoIncassoStr As String
        Get
            Dim ris As String = String.Empty

            ris = FormerEnumHelper.GetStatoIncassoStr(StatoIncasso)

            Return ris
        End Get
    End Property

    Public Property DestinatarioStr As String = String.Empty


End Class

''' <summary>
'''Interface for table T_contabricavi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IRicavo
    Inherits _IRicavo

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface