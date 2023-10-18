Imports FormerLib
Imports FormerLib.FormerEnum
Imports System.Web

Public Class UtenteSito

    Public Sub New()
        _IpUtente = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
    End Sub

    Private _Utente As Utente = Nothing
    Public Property Utente As Utente
        Get
            If _Utente Is Nothing Then _Utente = New Utente
            Return _Utente
        End Get
        Set(value As Utente)
            _Utente = value
        End Set
    End Property

    Public ReadOnly Property Nominativo As String
        Get
            Dim ris As String = ""
            If Utente.Nominativo.Length Then
                ris = Utente.Nominativo
            Else
                ris = "Visitatore"
            End If
            Return ris
        End Get

    End Property

    Public ReadOnly Property Email As String
        Get
            Dim ris As String = ""
            If Utente.Email.Length Then
                ris = Utente.Email
            Else
                ris = "non disponibile"
            End If
            Return ris
        End Get

    End Property

    Public ReadOnly Property AggiornareDatiFiscali As Boolean
        Get
            Dim ris As Boolean = False

            'If Utente.NoCheckDatiFisc <> enSiNo.Si Then
            If Utente.Piva.Length And Utente.Piva <> FormerConst.Fiscali.PartitaIvaNonDisponibile Then

                If Utente.Pec.Length = 0 AndAlso Utente.CodiceSDI.Length = 0 Then
                    ris = True
                Else
                    If Utente.Pec.Length > 0 AndAlso FormerHelper.Mail.IsValidEmailAddress(Utente.Pec) = False Then
                        'qui non va bene 
                        ris = True
                    End If

                    If Utente.CodiceSDI.Length > 0 AndAlso Utente.CodiceSDI.Length <> 7 Then
                        ris = True
                    End If
                End If
            End If
            'End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property IdRubricaInt As Integer
        Get
            Return Utente.IdRubricaInt
        End Get
    End Property

    Public ReadOnly Property IdUtente As Integer
        Get
            Dim Ris As Integer = Utente.IdUt
            Return Ris

        End Get
    End Property

    Public ReadOnly Property Tipo As Integer
        Get
            Dim Ris As Integer = enTipoRubrica.Cliente
            If Utente.TipoRub Then ' If Utente.IdRubricaInt Then ' CAMBIATO IN DATA 4 marzo 2014 per permettere la registrazione diretta di rivenditori
                Ris = Utente.TipoRub
            End If
            Return Ris
        End Get
    End Property

#Region "SITO"

    'PROPERTY RIGUARDANTI IL SITO WEB

    Private _IpUtente As String
    Public ReadOnly Property IpUtente As String
        Get
            Return _IpUtente
        End Get
    End Property

    Private _PreviousPageVisited As String = "/"
    ReadOnly Property PreviousPageVisited As String
        Get
            Return _PreviousPageVisited
        End Get
    End Property

    Private _LastPageVisited As String = "/"
    Public Property LastPageVisited() As String
        Get
            Return _LastPageVisited
        End Get
        Set(value As String)
            If _LastPageVisited <> "/" And _LastPageVisited <> "/login" Then _PreviousPageVisited = _LastPageVisited
            _LastPageVisited = value
        End Set
    End Property

    Public Property TotNelCarrello As String = "0"

    Public Property LastPageVisitedWhen As Date

    'FUNZIONE PER RETROCOMPATIBILITA DA TOGLIERE APPENA ARRIVA NUOVA SITUAZIONE ORDINI
    'Public ReadOnly Property NomeFileOrdini As String
    '    Get
    '        Dim IdCli As String = Utente.IdRubricaInt
    '        Dim Ris As String = String.Empty
    '        If IdCli Then
    '            Ris = IdCli.Replace("0", "df")
    '            Ris = Ris.Replace("1", "a")
    '            Ris = Ris.Replace("2", "yh")
    '            Ris = Ris.Replace("3", "wee")
    '            Ris = Ris.Replace("4", "nn")
    '            Ris = Ris.Replace("5", "bb")
    '            Ris = Ris.Replace("6", "poi")
    '            Ris = Ris.Replace("7", "as")
    '            Ris = Ris.Replace("8", "x")
    '            Ris = Ris.Replace("9", "tt")

    '            Ris &= ".html"
    '        End If

    '        Return Ris
    '    End Get

    'End Property

#End Region

    Public ReadOnly Property IsCrawler As Boolean
        Get
            Dim ris As Boolean = False
            Try
                Dim Crawlers As List(Of String) = FormerLib.FormerConst.Web.CrawlersList

                Dim ua As String = UserAgent
                ris = Crawlers.Exists(Function(x) ua.Contains(x))

            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

    Public ReadOnly Property IsBoss As Boolean
        Get
            Dim ris As Boolean = False
            If Utente.IdRubricaInt = 1703 Then
                ris = True
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property IsAdmin As Boolean
        Get
            Dim ris As Boolean = False
            If Utente.IdRubricaInt = 1703 Or
               Utente.IdRubricaInt = FormerLib.FormerConst.UtentiSpecifici.IdRubricaInternaFormer Then
                ris = True
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property IsRegisteredInternal As Boolean
        Get
            Dim ris As Boolean = False
            If Utente.IdRubricaInt Then ris = True
            Return ris
        End Get
    End Property

    Public Property UserAgent As String = String.Empty

    Public Property BrowserInUso As String = String.Empty

    Public ReadOnly Property DefaultIdIndirizzoPredefinito As Integer
        Get
            Dim ris As Integer = 0
            If IdUtente Then
                Using Mgr As New IndirizziDAO
                    Dim lst As List(Of Indirizzo) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "citta"},
                                                                      New LUNA.LunaSearchParameter(LFM.Indirizzo.IdUt, IdUtente),
                                                                      New LUNA.LunaSearchParameter(LFM.Indirizzo.Status, CInt(enStato.Attivo)))
                    Dim IndPred As Indirizzo = lst.Find(Function(x) x.Predefinito = True)
                    If Not IndPred Is Nothing Then
                        ris = IndPred.IdIndirizzo
                    End If
                End Using
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property DefaultCAP As String
        Get
            Dim ris As String = Utente.Cap

            Using Mgr As New IndirizziDAO
                Dim lst As List(Of Indirizzo) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "citta"},
                                                                  New LUNA.LunaSearchParameter(LFM.Indirizzo.IdUt, IdUtente),
                                                                  New LUNA.LunaSearchParameter(LFM.Indirizzo.Status, CInt(enStato.Attivo)))
                Dim IndPred As Indirizzo = lst.Find(Function(x) x.Predefinito = True)
                If Not IndPred Is Nothing Then
                    ris = IndPred.Cap
                End If
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property DefaultTipoPagamento As Integer
        Get
            Dim ris As Integer = Utente.IdPagamento
            If ris = 0 Then ris = enMetodoPagamento.PayPal 'paypal
            Return ris
        End Get
    End Property

    Public Function GetNumeroOrdiniDaAllegare() As Integer
        Dim ris As Integer = 0

        Using mgr As New OrdiniWebDAO
            Dim l As List(Of OrdineWeb) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.OrdineWeb.IdUt, IdUtente),
                                                   New LUNA.LunaSearchParameter(LFM.OrdineWeb.StatoWeb, CInt(enStato.Attivo)),
                                                   New LUNA.LunaSearchParameter(LFM.OrdineWeb.Stato, CInt(enStatoOrdine.InAttesaAllegati)))
            ris = l.Count
        End Using

        Return ris

    End Function

    Public Function GetNumeroTotaleOrdini() As Integer
        Dim ris As Integer = 0

        Using mgr As New OrdiniWebDAO
            Dim l As List(Of OrdineWeb) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.OrdineWeb.IdUt, IdUtente),
                                                   New LUNA.LunaSearchParameter(LFM.OrdineWeb.StatoWeb, CInt(enStato.Attivo)),
                                                   New LUNA.LunaSearchParameter(LFM.OrdineWeb.Stato, CInt(enStatoOrdine.PagatoAcconto), "<"))
            ris = l.Count
        End Using

        Return ris

    End Function

    Public Function GetNumeroTotaleCoupon() As Integer
        Dim ris As Integer = 0
        Using mgr As New CouponWDAO
            Dim l As List(Of CouponW) = mgr.ListaCouponAttivi(IdUtente, True)

            For Each SC As CouponW In l
                If SC.RiservatoATipoUtente = Tipo Then
                    Dim CheckOkVisibile As Boolean = True
                    If SC.VisibileOnline = enSiNo.No Then
                        If SC.Riservato <> IdUtente Then
                            CheckOkVisibile = False
                        End If
                    End If
                    If CheckOkVisibile Then
                        SC.Utilizzati = mgr.TotaleCouponUtilizzati(SC.IdCoupon, IdUtente)
                        If SC.Utilizzati < SC.MaxVolte Then ris += 1
                    End If

                End If
            Next
        End Using

        Return ris

    End Function

End Class
