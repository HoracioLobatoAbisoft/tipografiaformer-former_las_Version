Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerBusinessLogicInterface

Public Class Carrello
    Implements IDisposable

    Public Sub New()
        _ordini = New List(Of ProdottoInCarrello)
    End Sub

    Private Sub SalvaStato()
        HttpContext.Current.Session("Carrello") = Me
    End Sub

    Private _Ordini As List(Of ProdottoInCarrello) = Nothing
    Public Property Ordini As List(Of ProdottoInCarrello)
        Get
            Return _Ordini
        End Get
        Set(value As List(Of ProdottoInCarrello))
            _Ordini = value
        End Set
    End Property

    Public Property IdUtenteConnesso As Integer = 0

    Public Property IdMetodoPagamentoDefault As Integer = 0

    Private _MetodoPagamentoScelto As TipoPagamentoW
    Public Property MetodoPagamentoScelto As TipoPagamentoW
        Get
            If _MetodoPagamentoScelto Is Nothing Then
                _MetodoPagamentoScelto = New TipoPagamentoW

                If IdMetodoPagamentoDefault <> 0 Then
                    _MetodoPagamentoScelto.Read(IdMetodoPagamentoDefault) 'paypal
                Else
                    _MetodoPagamentoScelto.Read(enMetodoPagamento.PayPal) 'paypal
                End If
            End If
            Return _MetodoPagamentoScelto
        End Get
        Set(value As TipoPagamentoW)
            _MetodoPagamentoScelto = value
        End Set
    End Property

    Public ReadOnly Property IdMetodoConsegnaScelto As Integer
        Get
            Dim Ris As Integer = -1
            For Each O In Ordini
                Ris = MgrMetodiConsegna.GetMetodoConsegna(O.Corriere).IdMetodoConsegna
                Exit For
            Next
            Return Ris
        End Get
    End Property

    Public Property IdIndirizzoScelto As Integer = -1

    Public Function ApplicabileCoupon(TipoUtenteConnesso As Integer) As Boolean
        Dim ris As Boolean = True

        'If CouponGiaApplicato() = False Then
        Using mgr As New CouponWDAO

            Dim l As List(Of CouponW) = mgr.ListaCouponAttivi(IdUtenteConnesso, False)

            For Each SC As CouponW In l
                If SC.RiservatoATipoUtente = enTipoRubrica.Tutto OrElse TipoUtenteConnesso = SC.RiservatoATipoUtente Then
                    For Each o As ProdottoInCarrello In Ordini
                        'Dim CheckOk As Boolean = True

                        If o.IdPromo = 0 Then ' IL COUPON E' APPLICABILE SOLO SU ORDINI CHE NON HANNO UN PROMO ATTIVO
                            If SC.IdListinoBase Then
                                If o.ListinoBase.IdListinoBase <> SC.IdListinoBase Then
                                    ris = False
                                End If
                            End If
                            If SC.QtaSpecifica Then
                                If o.Qta <> SC.QtaSpecifica Then
                                    ris = False
                                End If
                            End If
                        End If

                        'If CheckOk Then ris = True
                        If ris Then
                            Exit For
                        End If
                    Next
                End If

            Next

        End Using
        'End If

        Return ris
    End Function

    Public Function ApplicatoCouponAlCarrello() As Boolean
        Dim ris As Boolean = False

        For Each O As ProdottoInCarrello In Ordini
            If O.IdCoupon Then
                ris = True
            End If
        Next

        Return ris
    End Function

    'Public Function CouponGiaApplicato(CodiceCoupon As String) As Boolean
    '    Dim ris As Boolean = False

    '    For Each O As ProdottoInCarrello In Ordini
    '        If O.IdCoupon Then
    '            ris = True
    '        End If
    '    Next

    '    Return ris
    'End Function

    Public ReadOnly Property CodiceCouponApplicato As String
        Get
            Dim ris As String = String.Empty

            For Each o In Ordini
                If o.IdCoupon Then
                    ris = o.CodiceCouponApplicato
                End If
            Next
            Return ris
        End Get
    End Property

    Public Function ApplicaCoupon(CodiceCoupon As String, _
                                  TipoUtenteConnesso As enTipoRubrica) As String
        'APPLICA UN COUPON AGLI ORDINI DOPO I NECESSARI CONTROLLI 
        Dim ris As String = String.Empty

        If ApplicatoCouponAlCarrello() = False Then

            Dim CouponValido As Boolean = False

            Using mgr As New CouponWDAO
                CouponValido = mgr.CheckCoupon(CodiceCoupon)
                If CouponValido Then

                    Dim Coupon As CouponW = mgr.Find(New LUNA.LunaSearchParameter(LFM.CouponW.Codice, CodiceCoupon),
                                                     New LUNA.LunaSearchParameter(LFM.CouponW.Stato, enStato.Attivo))

                    If Not Coupon Is Nothing Then
                        'qui devo controllare se le date di validita mi consentono di usarlo ancora e 
                        'se l'hai gia usato piu del numero massimo di volte
                        Dim CheckOkRiservato As Boolean = True
                        If Coupon.Riservato <> 0 AndAlso Coupon.Riservato <> IdUtenteConnesso Then
                            CheckOkRiservato = False
                        End If

                        If CheckOkRiservato Then
                            If Coupon.RiservatoATipoUtente = enTipoRubrica.Tutto OrElse Coupon.RiservatoATipoUtente = TipoUtenteConnesso Then

                                Dim diffIniziale As Integer = 0
                                Dim diffFinale As Integer = 0

                                diffIniziale = DateDiff(DateInterval.Day, Coupon.DataInizioValidita, Now)
                                diffFinale = DateDiff(DateInterval.Day, Coupon.DataFineValidita, Now)

                                If diffIniziale >= 0 AndAlso diffFinale <= 0 Then

                                    Dim TotCoupon As Integer = 0
                                    TotCoupon = mgr.TotaleCouponUtilizzati(Coupon.IdCoupon, IdUtenteConnesso)

                                    If TotCoupon < Coupon.MaxVolte Then

                                        Dim OkImportoMinimo As Boolean = True

                                        If Coupon.ImportoMinimoSpesa Then
                                            If TotaleImportiNettiOriginale < Coupon.ImportoMinimoSpesa Then
                                                OkImportoMinimo = False
                                            End If
                                        End If

                                        If OkImportoMinimo Then
                                            Dim GiaApplicato As Boolean = False

                                            Ordini.Sort(Function(x, y) y.PrezzoCalcolatoNettoOriginale.CompareTo(x.PrezzoCalcolatoNettoOriginale))

                                            For Each O As ProdottoInCarrello In Ordini
                                                If GiaApplicato = False Then
                                                    If O.ApplicaCoupon(Coupon) Then
                                                        GiaApplicato = True

                                                        If Coupon.ImportoFisso Then
                                                            Exit For 'se è a importo fisso per ora lo applico solo a un ordine
                                                            'TODO: va cambiato 
                                                        End If
                                                        'Exit For
                                                        'If Coupon.IdListinoBase = 0 Then
                                                        '    'questo e' un coupon di sconto sul carrello non essendo legato a nessun listino base 
                                                        '    'lascio l'if per ricordarmi il motivo
                                                        'Else
                                                        '    GiaApplicato = True
                                                        'End If
                                                    End If
                                                End If
                                            Next
                                            'se arrivo qui e il codicecoupon non sta in nessun ordine vuoldire che non era applicabile e lo dico
                                            If GiaApplicato = False Then
                                                ris = "Il codice coupon inserito NON è applicabile a nessun prodotto nel Carrello"
                                            Else
                                                ris = "Complimenti! Sconto per Coupon '" & CodiceCoupon.ToUpper & "' APPLICATO all' ordine"
                                            End If
                                        Else
                                            ris = "Il codice coupon inserito NON è applicabile (importo ordine minimo previsto " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Coupon.ImportoMinimoSpesa) & " &euro; )"
                                        End If

                                    Else
                                        ris = "Il codice coupon inserito è già stato utilizzato " & TotCoupon & " volta/e"
                                    End If
                                Else
                                    ris = "Il codice coupon inserito NON è valido (attivo dal " & Coupon.DataInizioValidita.ToString("dd/MM/yyyy") & " al " & Coupon.DataFineValidita.ToString("dd/MM/yyyy") & ")"
                                End If
                            Else
                                ris = "Il codice coupon inserito NON è applicabile"
                            End If
                        Else
                            ris = "Il codice coupon inserito NON è applicabile"
                        End If
                    Else
                        ris = "Il codice coupon inserito NON è valido"
                    End If
                Else
                    ris = "Il codice coupon inserito NON è valido"
                End If
            End Using
        Else
            ris = "E' possibile utilizzare un solo coupon per ogni ordine"
        End If

        Return ris
    End Function

    Public Sub SvuotaCarrello()

        Ordini.Clear()
        _MetodoPagamentoScelto = Nothing
        IdIndirizzoScelto = -1
        EmailTracciamento = String.Empty

    End Sub

    Public Property EmailTracciamento As String = String.Empty

    Public Sub RimuoviOrdine(IdOrd As Integer)

        Ordini.RemoveAll(Function(x) x.NumOrd = IdOrd)

        'qui devo controllare che se c'e' un ordine di tipo omaggio sia congruente 
        If Ordini.FindAll(Function(x) x.Omaggio = enSiNo.Si).Count Then
            'qui devo vedere se l'omaggio e' ancora valido
            Dim OrdineOmaggio As ProdottoInCarrello = Ordini.Find(Function(x) x.Omaggio = enSiNo.Si)
            Dim IdOmaggioToCheck As Integer = OrdineOmaggio.IdOmaggioRegola

            Using O As New OmaggioW
                O.Read(IdOmaggioToCheck)

                If MgrOmaggi.OmaggioUtilizzabile(O, Ordini, TotaleImportiNetti) = False Then
                    'qui va eliminato anceh questo ordine
                    Ordini.RemoveAll(Function(x) x.NumOrd = OrdineOmaggio.NumOrd)
                End If

            End Using


        End If

    End Sub

    Public Sub AggiungiOrdine(O As ProdottoInCarrello)

        If O.Omaggio = enSiNo.Si Then
            Ordini.Insert(Ordini.Count, O)
        Else
            Ordini.Insert(0, O)
        End If

    End Sub

    Public Function SalvaOrdine() As Integer

        Dim Ris As Integer = 0

        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
            Try
                Dim ProxStato As enStatoConsegna

                If MetodoPagamentoScelto.PeriodoPagam = enPeriodoPagamento.Anticipato Then
                    ProxStato = enStatoConsegna.InAttesaDiPagamento
                Else
                    ProxStato = enStatoConsegna.Inserito
                End If

                Dim sp As SpedizioneCumulativa = SpedizioneCumulativa
                Dim GuidOrd As Guid = Guid.NewGuid()
                Dim GuidToSave As String = IdUtenteConnesso & "-" & GuidOrd.ToString

                Dim C As New Consegna
                C.DataInserimento = Now
                C.Giorno = DataProduzioneCumulativa
                C.IdUt = IdUtenteConnesso
                C.IdIndirizzo = IdIndirizzoScelto
                C.IdCorriere = sp.Corriere.IdCorriere
                C.IdStatoConsegna = ProxStato
                C.Peso = Peso
                C.IdPagam = MetodoPagamentoScelto.IdTipoPagam
                If MetodoPagamentoScelto.PeriodoPagam = enPeriodoPagamento.Anticipato OrElse
                   Ordini.FindAll(Function(x) x.Omaggio = enSiNo.Si).Count OrElse
                   C.NoCartaceo = enSiNo.Si Then
                    C.Blocco = enSiNo.Si
                Else
                    C.Blocco = enSiNo.No
                End If

                C.TipoDoc = enTipoDocumento.Fattura
                C.DataPrevistaOriginale = sp.Quando
                C.GuidTransazione = GuidToSave
                C.ImportoNetto = sp.Importo 'salvo l'importo calcolato netto 
                C.EmailNotificheCorriere = EmailTracciamento

                'check su coupon per importominimo
                If Ordini.FindAll(Function(x) x.IdCoupon <> 0).Count Then
                    'qui almeno uno ha il coupon 
                    Dim IdCoupon As Integer = Ordini.Find(Function(x) x.IdCoupon <> 0).IdCoupon
                    Using Coup As New CouponW
                        Coup.Read(IdCoupon)
                        If Coup.ImportoMinimoSpesa Then
                            'qui controllo che il carrello sia ancora nell'importo minimo di spesa senza il coupon 
                            If TotaleImportiNettiOriginale < Coup.ImportoMinimoSpesa Then
                                'qui e' minore azzero il coupon 
                                For Each P As ProdottoInCarrello In Ordini
                                    If P.IdCoupon Then
                                        P.ResetCoupon()
                                        Exit For
                                    End If
                                Next

                            End If
                        End If
                    End Using

                End If

                tb.TransactionBegin()
                C.Save()
                For Each P As ProdottoInCarrello In Ordini
                    P.Salva(C)
                Next
                tb.TransactionCommit()

                Ris = C.IdConsegna

                'salvo una copia dell'ordine a futura memoria
                Try
                    Dim PathOrdine As String = FormerWebApp.PathConsegne & C.IdConsegna & "\"

                    If Directory.Exists(PathOrdine) = False Then
                        Directory.CreateDirectory(PathOrdine)
                    End If

                    PathOrdine &= C.IdConsegna & ".xml"

                    FormerSerializator.SerializeObjectToFile(C, PathOrdine)

                    'Using w As New StreamWriter(PathOrdine)
                    '    w.Write(buffer)
                    'End Using

                    'Using mgr As New OrdiniWebDAO
                    '    mgr.SaveSerialize(O, PathOrdine)
                    'End Using

                Catch ex As Exception
                    'Stop
                End Try

            Catch ex As Exception
                tb.TransactionRollBack()
            End Try

        End Using

        Return Ris

    End Function

    Public ReadOnly Property TotaleScontiStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleSconti)
        End Get
    End Property

    Public ReadOnly Property TotaleNettoStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleNetto)
        End Get
    End Property

    Public ReadOnly Property TotaleCarrelloStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleCarrello)
        End Get
    End Property

    Public ReadOnly Property TotaleIVAStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleIVA)
        End Get
    End Property

    Public ReadOnly Property TotaleSpedizioniStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleSpedizioni)
        End Get
    End Property

    Public ReadOnly Property TotaleImportiNetti As Decimal
        Get
            Dim Ris As Decimal = 0
            For Each O As ProdottoInCarrello In Ordini
                Ris += O.PrezzoCalcolatoNetto
            Next
            Return Ris
        End Get
    End Property

    Public ReadOnly Property TotaleImportiNettiOriginale As Decimal
        Get
            Dim Ris As Decimal = 0
            For Each O As ProdottoInCarrello In Ordini
                Ris += O.PrezzoCalcolatoNettoOriginale
            Next
            Return Ris
        End Get
    End Property

    Public ReadOnly Property TotaleImportiNettiStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleImportiNetti)
        End Get
    End Property

    Public ReadOnly Property TotaleImportiNettiOriginaleStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleImportiNettiOriginale)
        End Get
    End Property

    Public ReadOnly Property TotaleNetto As Decimal
        Get
            Dim Ris As Decimal = 0
            For Each O As ProdottoInCarrello In Ordini
                Ris += O.TotaleNetto
            Next
            Return Ris
        End Get
    End Property

    Public ReadOnly Property TotaleSconti As Decimal
        Get
            Dim Ris As Decimal = 0
            For Each O As ProdottoInCarrello In Ordini
                Ris += O.Sconto
            Next
            Return Ris
        End Get
    End Property

    Public ReadOnly Property TotaleIVA As Decimal
        Get
            Dim Ris As Decimal = 0
            For Each O As ProdottoInCarrello In Ordini
                Ris += FormerHelper.Finanziarie.CalcolaIva(O.PrezzoCalcolatoNetto)
            Next
            Ris += TotaleIvaSpedizioni
            Return Ris
        End Get
    End Property

    Public ReadOnly Property TotaleIvaSpedizioni As Decimal
        Get
            Dim ris As Decimal = 0

            ris = FormerHelper.Finanziarie.CalcolaIva(TotaleSpedizioni)

            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleSpedizioni As Decimal
        Get

            Dim ris As Decimal = 0

            'For Each O As OrdineWeb In Ordini
            '    'DicDate(O.DataConsegna) += O.SpeseDiTrasporto
            '    ris += O.SpeseDiTrasporto
            'Next

            'For Each S As SpedizioneCumulativa In SpedizioniCumulative
            '    ris += S.Importo
            'Next

            Dim Sp As SpedizioneCumulativa = SpedizioneCumulativa
            If Not Sp Is Nothing Then
                ris = Sp.Importo
            End If


            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleCarrello As Decimal
        Get
            Dim Ris As Decimal = TotaleImportiNetti + TotaleIVA + TotaleSpedizioni
            Return Ris
        End Get
    End Property

    Public ReadOnly Property DataConsegnaStr As String
        Get
            Dim Ris As String = "--"
            Dim Sp As SpedizioneCumulativa = SpedizioneCumulativa
            If Not Sp Is Nothing Then
                Ris = StrConv(Sp.Quando.ToString("dddd dd MMMM yyyy"), VbStrConv.ProperCase)
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpedizioneCumulativa As SpedizioneCumulativa
        Get
            Dim mgr As New MGRSpedizioniCumulative

            Dim ris As SpedizioneCumulativa = mgr.CalcolaSpedizioneCumulativa(Ordini, MetodoPagamentoScelto)

            Return ris
        End Get
    End Property

    Public ReadOnly Property DataProduzioneCumulativa As Date
        Get
            Dim DataRis As Date = Now

            For Each O As ProdottoInCarrello In Ordini
                Dim Differenza As Integer = DateDiff(DateInterval.Day, DataRis.Date, O.DataPrevProduzione.Date)
                If Differenza > 0 Then
                    DataRis = O.DataPrevProduzione
                End If
            Next

            Return DataRis
        End Get
    End Property

    'Public ReadOnly Property SpedizioniCumulative As List(Of SpedizioneCumulativa)
    '    Get
    '        Dim mgr As New MGRSpedizioniCumulative

    '        Dim ris As List(Of SpedizioneCumulativa) = mgr.CalcolaSpedizioniCumulative(Ordini)

    '        Return ris
    '    End Get
    'End Property

    Public ReadOnly Property CorrieriScelti As List(Of CorriereW)
        Get
            Dim Lst As New List(Of CorriereW)

            For Each O As ProdottoInCarrello In Ordini
                If Lst.Find(Function(x) x.IdCorriere = O.Corriere.IdCorriere) Is Nothing Then
                    Lst.Add(O.Corriere)
                End If
            Next

            Return Lst
        End Get
    End Property

    Public ReadOnly Property NumeroColli As Integer
        Get
            Dim ris As Integer = 0
            For Each O As ProdottoInCarrello In Ordini
                ris += O.Colli
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property Peso As Integer
        Get
            Dim ris As Integer = 0
            For Each O As ProdottoInCarrello In Ordini
                ris += O.Peso
            Next
            Return ris
        End Get
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                '  eliminare stato gestito (oggetti gestiti).
            End If
            SalvaStato()
            '  liberare risorse non gestite (oggetti non gestiti) ed eseguire l'override del seguente Finalize().
            ' : impostare campi di grandi dimensioni su null.
        End If
        Me.disposedValue = True
    End Sub

    ' : eseguire l'override di Finalize() solo se Dispose(ByVal disposing As Boolean) dispone del codice per liberare risorse non gestite.
    'Protected Overrides Sub Finalize()
    '    ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(ByVal disposing As Boolean).
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
