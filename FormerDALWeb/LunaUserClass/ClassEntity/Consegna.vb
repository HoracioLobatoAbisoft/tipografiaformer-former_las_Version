#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.21984 
'Author: Diego Lunadei
'Date: 25/11/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerDALWeb
Imports FormerBusinessLogicInterface

''' <summary>
'''Entity Class for table Consegne
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Consegna
    Inherits _Consegna
    Implements IConsegna

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Public Property Tag As Object = Nothing

    Public ReadOnly Property IdConsegnaView As String
        Get
            Dim ris As String = "-"

            If IdConsegnaInt Then
                ris = IdConsegnaInt
            End If

            Return ris
        End Get
    End Property
    Private _DataOrdineStato As enStatoDataOrdine = enStatoDataOrdine.NonDefinita
    Public ReadOnly Property DataOrdineStato As enStatoDataOrdine
        Get
            If _DataOrdineStato = enStatoDataOrdine.NonDefinita Then
                If IdStatoConsegna <> enStatoConsegna.Consegnata Then
                    _DataOrdineStato = enStatoDataOrdine.Prevista
                    If HaOrdiniConDataGarantita Then
                        _DataOrdineStato = enStatoDataOrdine.Garantita
                    ElseIf Not PagamentoOrdine Is Nothing Then
                        _DataOrdineStato = enStatoDataOrdine.Confermata
                    Else
                        'qui controllo se tutti gli ordini dentro sono in stato da stampa in corso in poi e la metto comunque
                        'confermata
                        If ListaOrdini.FindAll(Function(x) x.Stato < enStatoOrdine.StampaInizio).Count = 0 Then
                            _DataOrdineStato = enStatoDataOrdine.Confermata
                        End If
                    End If
                Else
                    _DataOrdineStato = enStatoDataOrdine.Consegnata
                End If
            End If
            Return _DataOrdineStato
        End Get
    End Property
    Public ReadOnly Property DataOrdineClasse As String
        Get
            Dim ris As String = String.Empty
            Select Case DataOrdineStato
                Case enStatoDataOrdine.Prevista
                    ris = "DataOrdinePrevista"
                Case enStatoDataOrdine.Garantita
                    ris = "DataOrdineGarantita"
                Case enStatoDataOrdine.Confermata
                    ris = "DataOrdineConfermata"
                Case enStatoDataOrdine.Consegnata
                    ris = "DataOrdineConsegnata"
            End Select
            Return ris
        End Get
    End Property

    Public ReadOnly Property DataOrdineLabel As String
        Get
            Dim ris As String = String.Empty
            Select Case DataOrdineStato
                Case enStatoDataOrdine.Prevista
                    ris = " - Consegna PREVISTA"
                Case enStatoDataOrdine.Garantita
                    ris = " - Consegna GARANTITA"
                Case enStatoDataOrdine.Confermata
                    ris = " - Consegna CONFERMATA"
            End Select
            Return ris
        End Get
    End Property

    Public ReadOnly Property HaOrdiniConDataGarantita As Boolean
        Get
            Dim ris As Boolean = False
            If ListaOrdini.FindAll(Function(x) x.ConsegnaGarantita <> Date.MinValue).Count Then ris = True
            Return ris
        End Get
    End Property

    Public ReadOnly Property InseritoStr As String
        Get
            Return DataInserimento.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property GiornoStr As String
        Get

            Return GiornoConsegna.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property GiornoConsegna As Date
        Get
            'in giorno dal gestionale mi arriva il giorno di produzione in caso di ritiro cliente, 
            ' il giorno di produzione in caso di corriere
            ' il giorno di consegna in caso di tipografia former 

            'qui qui devo andare a ricalcolare il giorno 
            Dim Ris As Date = Date.MinValue

            Ris = MgrDataConsegna.CalcolaDataConsegna(Giorno, Corriere)

            Return Ris

        End Get
    End Property

    Public ReadOnly Property GetIdUtentebyOrd As Integer
        Get
            Dim ris As Integer = 0

            For Each O As OrdineWeb In ListaOrdini
                ris = O.IdUt
                Exit For
            Next

            Return ris
        End Get
    End Property

    Public ReadOnly Property ColoreStatoHtml As String
        Get
            Return FormerLib.FormerColori.GetColoreStatoConsegnaHtml(IdStatoConsegna)
        End Get
    End Property

    Public ReadOnly Property StatoStr As String
        Get
            Dim Ris As String = ""

            Ris = FormerEnumHelper.StatoConsegnaString(IdStatoConsegna, True)

            Return Ris

        End Get
    End Property

    Public ReadOnly Property ImportoTotConfrontoPP As String
        Get
            Dim Ris As String = ImportoTotStr

            Ris = Ris.Replace(".", "")
            Ris = Ris.Replace(",", "")

            Return Ris
        End Get
    End Property

    Public ReadOnly Property ImportoTot As Decimal
        Get
            Return ImportoTotNetto + ImportoTotIva
        End Get
    End Property

    Public ReadOnly Property HaUnPagamento As Boolean
        Get
            Dim ris As Boolean = False

            Using mgr As New PagamentiOnlineDAO
                Dim l As List(Of PagamentoOnline) = mgr.FindAll(New LUNA.LunaSearchParameter("IdConsegna", IdConsegna))
                If l.Count Then
                    ris = True
                End If
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property Accorpabile() As Boolean
        Get
            Dim ris As Boolean = True
            If Blocco = enSiNo.Si Then
                ris = False
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property IdCouponUtilizzato As Integer
        Get
            Dim Ris As Integer = 0

            For Each O As OrdineWeb In ListaOrdini
                If O.IdCoupon Then
                    Ris = O.IdCoupon
                    Exit For
                End If
            Next

            Return Ris
        End Get
    End Property

    Public ReadOnly Property Tracciabile As Boolean
        Get
            Dim ris As Boolean = False

            If IdStatoConsegna = enStatoConsegna.InConsegna Or IdStatoConsegna = enStatoConsegna.Consegnata Then
                If CodTrack.Length Then
                    ris = True
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property Modificabile() As Boolean
        Get
            'l'ordine e' eliminabile solo se non e' gia stato pagato e se tutti i lavori contenuti all'interno non hanno ancora i file allegati
            Dim ris As Boolean = True

            If IdStatoConsegna = enStatoConsegna.InAttesaDiPagamento Or _
                IdStatoConsegna = enStatoConsegna.InLavorazione Or _
                IdStatoConsegna = enStatoConsegna.Inserito Then
                'qui controllo se non ci sia un pagamento associato che potrebbe esserci in entrambi gli stati
                Dim GiaPagata As Boolean = False
                If IdStatoConsegna = enStatoConsegna.InLavorazione Then
                    GiaPagata = HaUnPagamento
                End If

                If GiaPagata = False Then
                    For Each O As OrdineWeb In ListaOrdini
                        If O.Modificabile = False Then
                            ris = False
                            Exit For
                        End If
                    Next
                Else
                    ris = False
                End If
            Else
                ris = False
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property PesoKg As Integer
        Get
            Dim Ris As Integer = 0
            If IdStatoConsegna = enStatoConsegna.InLavorazione Or IdStatoConsegna = enStatoConsegna.Inserito Then
                'qui sommo il numero di colli della spedizione 
                For Each O As OrdineWeb In ListaOrdini
                    Ris += O.Peso
                Next
            Else 'qui torno il valore salvato
                Ris = Peso
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property NumeroColliStr As String
        Get
            Dim Ris As String = NumeroColli
            If IdStatoConsegna = enStatoConsegna.InLavorazione Or IdStatoConsegna = enStatoConsegna.Inserito Then
                If Corriere.IdCorriere <> enCorriere.RitiroCliente And Corriere.IdCorriere <> enCorriere.TipografiaFormer Then
                    Ris = "n.d."
                End If
            End If
            If Ris = "0" Then Ris = "n.d."
            Return Ris
        End Get
    End Property

    Public ReadOnly Property NumeroColli As Integer
        Get
            Dim Ris As Integer = 0
            If IdStatoConsegna = enStatoConsegna.InLavorazione Or IdStatoConsegna = enStatoConsegna.Inserito Then
                'qui sommo il numero di colli della spedizione 
                For Each O As OrdineWeb In ListaOrdini
                    Ris += O.NumeroColli
                Next
            Else 'qui torno il valore salvato
                Ris = NumColli
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property ImportoConsegna As Decimal
        Get
            Dim Ris As Decimal = 0
            If IdStatoConsegna = enStatoConsegna.InLavorazione Or IdStatoConsegna = enStatoConsegna.Inserito Then
                'qui do un costo ipotetico della consegna piu il totale degli ordini contenuti all'interno 

                Dim PesoKg As Integer = 0
                Dim PesoVolumetrico As Integer = 0
                Dim PrezzoTotaleOrdini As Decimal = 0
                For Each O As OrdineWeb In ListaOrdini
                    PesoKg += O.Peso
                    PesoVolumetrico += O.PesoVolumetrico
                    PrezzoTotaleOrdini += O.PrezzoCalcolatoNetto
                Next

                Ris = MgrCorriere.CalcolaTariffa(Corriere, PesoVolumetrico, PesoKg, PrezzoTotaleOrdini, MetodoPagamento)

                Return Ris

            Else 'qui formatto solamente l'importo della consegna piu quello degli ordini contenuti all'interno 
                Ris = ImportoNetto
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property ImportoConsegnaStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoConsegna)
        End Get
    End Property

    Public ReadOnly Property ImportoTotStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoTot)
        End Get
    End Property

    Public ReadOnly Property ImportoTotPayPal As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzoPayPal(ImportoTot)
        End Get
    End Property

    Public ReadOnly Property ImportoTotNettoStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoTotNetto)
        End Get
    End Property

    Public ReadOnly Property ImportoTotIvaStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoTotIva)
        End Get
    End Property

    Public ReadOnly Property ImportoTotIva As Decimal
        Get
            Return FormerLib.FormerHelper.Finanziarie.CalcolaIva(ImportoTotNetto)
        End Get
    End Property

    Public ReadOnly Property ImportoTotOrdiniNettoOriginaleStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoTotNettoOriginale)
        End Get
    End Property


    Public ReadOnly Property ImportoTotOrdiniNettoStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoTotOrdiniNetto)
        End Get
    End Property

    Public ReadOnly Property ImportoTotaleScontiStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoTotaleSconti)
        End Get
    End Property

    Public ReadOnly Property ImportoTotaleSconti As Decimal
        Get
            Dim Ris As Single = 0
            For Each O As OrdineWeb In ListaOrdini
                Ris += O.Sconto
            Next
            Return Ris
        End Get
    End Property

    Public ReadOnly Property ImportoTotOrdiniNetto As Decimal
        Get
            Dim TotaleOrd As Decimal = 0

            For Each O As OrdineWeb In ListaOrdini
                TotaleOrd += O.ImportoNetto
            Next
            Return TotaleOrd
        End Get
    End Property

    Public ReadOnly Property ImportoTotNettoOriginale As Decimal
        Get
            Dim TotaleOrd As Decimal = 0

            For Each O As OrdineWeb In ListaOrdini
                TotaleOrd += O.ImportoNettoOrig
            Next
            Return TotaleOrd
        End Get
    End Property

    Public ReadOnly Property ImportoTotNetto As Decimal
        Get

            Return ImportoTotOrdiniNetto + ImportoConsegna

        End Get
    End Property

    Private _MetodoPagamento As TipoPagamentoW = Nothing
    Public ReadOnly Property MetodoPagamento As TipoPagamentoW
        Get
            If _MetodoPagamento Is Nothing Then

                _MetodoPagamento = New TipoPagamentoW
                _MetodoPagamento.Read(IdPagam)

            End If
            Return _MetodoPagamento

        End Get
    End Property

    Private _Corriere As CorriereW = Nothing
    Public ReadOnly Property Corriere As CorriereW
        Get
            If _Corriere Is Nothing Then

                _Corriere = New CorriereW
                _Corriere.Read(IdCorriere)

            End If
            Return _Corriere

        End Get
    End Property

    Public ReadOnly Property CorriereStr As String
        Get
            Dim Ris As String = Corriere.NomePulito
            Return Ris

        End Get
    End Property

    Public ReadOnly Property DataInserimentoStr As String
        Get
            Return DataInserimento.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property IconaCorriere As String
        Get
            Dim ris As String = String.Empty

            Dim metodo As MetodoConsegna = Corriere.MetodoDiConsegna

            If Not metodo Is Nothing Then
                Select Case metodo.IdMetodoConsegna
                    Case enTipoCorriere.ConTariffa
                        ris = "/img/icoCorriere20.png"
                    Case enTipoCorriere.Gratis
                        ris = "/img/icoRitiroCli20.png"
                    Case enTipoCorriere.PortoAssegnato
                        ris = "/img/icoPacco20.png"
                End Select
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property IconaCorriereAlt As String
        Get
            Dim ris As String = Corriere.Descrizione
            Return ris
        End Get
    End Property

    Public ReadOnly Property PagamentoStr As String
        Get
            Dim ris As String = "Come concordato"

            If IdPagam Then

                Dim P As New TipoPagamentoW
                P.Read(IdPagam)

                ris = P.TipoPagam

            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property IndirizzoStr As String
        Get
            Dim Ris As String = String.Empty
            If Corriere.TipoCorriere = enTipoCorriere.ConTariffa Then
                Dim I As New Indirizzo
                If IdIndirizzo Then
                    I.Read(IdIndirizzo)
                Else

                    Using u As New Utente
                        u.Read(IdUt)

                        I.IdIndirizzo = 0
                        I.IdProvincia = u.IdProvincia
                        I.IdComune = u.IdComune
                        I.Cap = u.Cap
                        I.Citta = u.Citta
                        I.Indirizzo = u.Indirizzo
                        I.Destinatario = u.Nominativo
                    End Using

                End If
                Ris = I.Riassunto
            Else
                Ris = "Tipografia Former, Via Cassia, 2010 - 00123 Roma"
            End If

            Return Ris
        End Get
    End Property


    Private _ListaOrdini As List(Of OrdineWeb) = Nothing
    Public ReadOnly Property ListaOrdini As List(Of OrdineWeb)
        Get
            If _ListaOrdini Is Nothing Then

                Using mgr As New OrdiniWebDAO
                    _ListaOrdini = mgr.FindAll("IdOrdine", New LUNA.LunaSearchParameter("IdCons", IdConsegna))
                End Using

            End If
            Return _ListaOrdini
        End Get
    End Property

    Public ReadOnly Property BufferHTMLOrdini As String
        Get
            Dim ris As String = String.Empty

            For Each O As OrdineWeb In ListaOrdini
                ris &= "<a href=""/" & O.IdOrdine & "/dettaglio-ordine""><img src=""/img/icoCarrello16.png""> <b>" & O.Riassunto & "</b></a><br />"
            Next

            Return ris
        End Get
    End Property

    Private _PagamentoOrdine As PagamentoOnline = Nothing
    Public ReadOnly Property PagamentoOrdine As PagamentoOnline
        Get
            If _PagamentoOrdine Is Nothing Then
                Using mgr As New PagamentiOnlineDAO
                    _PagamentoOrdine = mgr.Find(New LUNA.LunaSearchParameter("IdConsegna", IdConsegna))
                End Using
            End If
            Return _PagamentoOrdine
        End Get
    End Property

    Private _Utente As Utente = Nothing
    Public ReadOnly Property Utente As Utente
        Get
            If _Utente Is Nothing Then
                _Utente = New Utente
                _Utente.Read(IdUt)
            End If
            Return _Utente
        End Get
    End Property

    Public ReadOnly Property NomeCliente As String
        Get
            Return Utente.Nominativo
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IConsegna.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IConsegna.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IConsegna.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

Public Class ConsegnaWithFattura
    Inherits Consegna

    Public Property FatturaPDF As String = String.Empty

End Class

''' <summary>
'''Interface for table Consegne
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IConsegna
    Inherits _IConsegna

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface