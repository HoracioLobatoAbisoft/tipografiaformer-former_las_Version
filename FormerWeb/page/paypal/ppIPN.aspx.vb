Imports System.IO
Imports System.Net
Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ppStart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strRequest As String = String.Empty
        Dim CheckLogico As String = String.Empty

        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

            Dim RiassuntoPagamento As String = String.Empty

            Try
                'Post back to either sandbox or live

                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = 3072
                ServicePointManager.DefaultConnectionLimit = 9999

                Dim req As HttpWebRequest = CType(WebRequest.Create(FormerWebApp.PPEntryPoint), HttpWebRequest)

                'Set values for the request back
                req.Method = "POST"
                req.ContentType = "application/x-www-form-urlencoded"
                Dim Param() As Byte = Request.BinaryRead(HttpContext.Current.Request.ContentLength)
                strRequest = Encoding.ASCII.GetString(Param)

                SavePPLog(strRequest)

                strRequest = strRequest + "&cmd=_notify-validate"
                req.ContentLength = strRequest.Length

                'for proxy
                'Dim proxy As New WebProxy(New System.Uri("http://url:port#"))
                'req.Proxy = proxy

                Dim Rpp As New PPResponse(strRequest)

                'Send the request to PayPal and get the response
                Dim streamOut As StreamWriter = New StreamWriter(req.GetRequestStream(), Encoding.ASCII)
                streamOut.Write(strRequest)
                streamOut.Close()
                Dim streamIn As StreamReader = New StreamReader(req.GetResponse().GetResponseStream())
                Rpp.EsitoPayPal = streamIn.ReadToEnd()
                streamIn.Close()

                Dim PagamentoRegistrato As Boolean = False

                If Rpp.EsitoPayPal = "VERIFIED" Then
                    If Rpp.StatoPagamento = "Completed" Then
                        If Rpp.Beneficiario = FormerWebApp.PPSeller Then
                            If Rpp.Valuta = "EUR" Then
                                If Rpp.TransazioneDalSito Then
                                    'qui controllo che la consegna esista e se il pagamento non sia gia stato registrato e quindi e' una richiamata 
                                    'e in seguito se l'importo e' corretto
                                    Dim C As Consegna = Nothing
                                    Using mgr As New ConsegneDAO
                                        C = mgr.Find(New LUNA.LunaSearchParameter(LFM.Consegna.GuidTransazione, Rpp.IdTransazione),
                                                     New LUNA.LunaSearchParameter(LFM.Consegna.IdStatoConsegna, enStatoConsegna.Eliminata, "<>"))
                                    End Using
                                    If Not C Is Nothing Then
                                        'qui controllo che non ci sia gia un pagamento 
                                        If C.PagamentoOrdine Is Nothing Then
                                            If Rpp.ImportoPagamentoConfrontoPP = C.ImportoTotConfrontoPP Then

                                                'qui registro l'effettivo pagamento 
                                                CheckLogico = "Registrazione Effettivo Pagamento"

                                                RiassuntoPagamento = C.NomeCliente & " € " & Rpp.ImportoPagamento

                                                tb.TransactionBegin()

                                                Dim P As New PagamentoOnline
                                                P.IdUt = C.IdUt
                                                P.Quando = Now
                                                P.IdConsegna = C.IdConsegna
                                                P.IdTipoPagamento = enMetodoPagamento.PayPal  '9 PAYPAL
                                                P.Importo = Rpp.ImportoPagamento
                                                P.StatoPagamento = enStatoPagamento.Pagato
                                                P.Save()

                                                If C.IdStatoConsegna = enStatoConsegna.InAttesaDiPagamento Then
                                                    C.IdStatoConsegna = enStatoConsegna.InLavorazione
                                                    C.IdPagam = enMetodoPagamento.PayPal
                                                    C.Save()
                                                    For Each O As OrdineWeb In C.ListaOrdini
                                                        If O.Stato = enStatoOrdine.InAttesaPagamento Then
                                                            If O.L.NoAttachFile = enSiNo.Si Then
                                                                O.Stato = enStatoOrdine.Preinserito
                                                            Else
                                                                O.Stato = enStatoOrdine.InAttesaAllegati
                                                            End If
                                                            O.Save()
                                                        End If
                                                    Next
                                                End If

                                                tb.TransactionCommit()

                                                PagamentoRegistrato = True

                                            Else
                                                CheckLogico = "Importo ERRATO"
                                            End If
                                        Else
                                            CheckLogico = "Pagamento GIA REGISTRATO"
                                        End If
                                    Else
                                        CheckLogico = "Consegna NON PRESENTE"
                                    End If
                                Else
                                    CheckLogico = "RICEVUTO PAGAMENTO NON DAL SITO"
                                End If
                            Else
                                CheckLogico = "Valuta NON CORRETTA"
                            End If
                        Else
                            CheckLogico = "Benificiario NON CORRETTO"
                        End If
                    Else
                        CheckLogico = "Pagamento NON COMPLETED"
                    End If
                    'check the payment_status is Completed
                    'check that txn_id has not been previously processed
                    'check that receiver_email is your Primary PayPal email
                    'check that payment_amount/payment_currency are correct
                    'process payment

                    'ElseIf Rpp.EsitoPayPal = "INVALID" Then
                    '    'log for manual investigation
                    '    'QUI HO RICEVUTO UN PAGAMENTO INVALIDO 
                    'Else
                    '    'Response wasn't VERIFIED or INVALID, log for manual investigation
                End If

                Try
                    If PagamentoRegistrato = False Then
                        'qualcosa e' andato storto
                        FormerLib.FormerHelper.Mail.InviaMail("Pagamento SCARTATO PAYPAL", "<h2>Check Logico: " & CheckLogico & "</h2>" & Rpp.RispostaFormattataHTML, "soft@tipografiaformer.it")
                        'Else
                        '    FormerLib.FormerHelper.Mail.InviaMail("Pagamento SU PAYPAL: " & RiassuntoPagamento, Rpp.RispostaFormattataHTML, "soft@tipografiaformer.it")
                    End If
                Catch ex As Exception

                End Try

            Catch ex As Exception
                'qui mettere gestione errori generica
                tb.TransactionRollBack()
                FormerLib.FormerHelper.Mail.InviaMail("Pagamento PAYPAL ERRORE ", "<h2>Check Logico: " & CheckLogico & "</h2> StrRequest " & strRequest & "<br><br>" & ex.Message, "soft@tipografiaformer.it")
            End Try

        End Using

    End Sub

    Private Sub SavePPLog(ByVal request As String)

        Try

            request = request.Replace("&", ControlChars.NewLine)

            Dim Path As String = HttpContext.Current.Server.MapPath(FormerWebApp.PathLogPP)
            Dim NomeFile As String = Now.Date.ToString("yyyyMMdd") & FormerLib.FormerHelper.Numeri.GetNumeroCasuale() & ".txt"
            Path &= NomeFile
            Using w As New StreamWriter(Path, True)
                w.WriteLine(request)
            End Using

        Catch ex As Exception

        End Try

    End Sub

End Class