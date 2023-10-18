Imports System.IO
Imports System.Net
Imports FormerBancaSella
Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class bsStart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strRequest As String = String.Empty
        Dim CheckLogico As String = String.Empty
        Dim RispostaFormattataHTML As String = String.Empty

        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

            Dim RiassuntoPagamento As String = String.Empty

            Try

                Dim ShopLogin As String = FormerConfig.FConfiguration.BancaSella.ShopLogin
                Dim Buffer As String = Request.QueryString("b")

                Dim bsResult As BancaSellaResult = MgrBancaSella.Decript(ShopLogin, Buffer)

                RispostaFormattataHTML = "<h1>" & bsResult.Risultato & "</h1>"

                Dim PagamentoRegistrato As Boolean = False

                If bsResult.Risultato = "OK" Then
                    If ShopLogin = FormerConfig.FConfiguration.BancaSella.ShopLogin Then
                        If bsResult.CurrencyCode = "242" Then
                            If bsResult.ShopTransactionID.Length Then

                                RispostaFormattataHTML &= "GuidTransazione " & bsResult.ShopTransactionID & "<br>"

                                'qui controllo che la consegna esista e se il pagamento non sia gia stato registrato e quindi e' una richiamata 
                                'e in seguito se l'importo e' corretto
                                Dim C As Consegna = Nothing
                                Using mgr As New ConsegneDAO
                                    C = mgr.Find(New LUNA.LunaSearchParameter("GuidTransazione", bsResult.ShopTransactionID),
                                                 New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.Eliminata, "<>"))
                                End Using
                                If Not C Is Nothing Then
                                    'qui controllo che non ci sia gia un pagamento 
                                    If C.PagamentoOrdine Is Nothing Then
                                        If bsResult.Importo = C.ImportoTot Then

                                            'qui registro l'effettivo pagamento 
                                            CheckLogico = "Registrazione Effettivo Pagamento"

                                            RiassuntoPagamento = C.NomeCliente & " € " & bsResult.ImportoStr

                                            RispostaFormattataHTML &= RiassuntoPagamento & "<br>"

                                            tb.TransactionBegin()

                                            Dim P As New PagamentoOnline
                                            P.IdUt = C.IdUt
                                            P.Quando = Now
                                            P.IdConsegna = C.IdConsegna
                                            P.IdTipoPagamento = enMetodoPagamento.CartaDiCredito
                                            P.Importo = bsResult.Importo
                                            P.StatoPagamento = enStatoPagamento.Pagato
                                            P.Save()

                                            If C.IdStatoConsegna = enStatoConsegna.InAttesaDiPagamento Then
                                                C.IdStatoConsegna = enStatoConsegna.InLavorazione
                                                C.IdPagam = enMetodoPagamento.CartaDiCredito
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
                    CheckLogico = "Pagamento KO"
                End If

                Try
                    If PagamentoRegistrato = False Then
                        'qualcosa e' andato storto
                        FormerLib.FormerHelper.Mail.InviaMail("Pagamento SCARTATO BANCA SELLA", "<h2>Check Logico: " & CheckLogico & "</h2>" & RispostaFormattataHTML, "soft@tipografiaformer.it")
                        'Else
                        '    FormerLib.FormerHelper.Mail.InviaMail("Pagamento SU BANCA SELLA: " & RiassuntoPagamento, RispostaFormattataHTML, "soft@tipografiaformer.it")
                    End If
                Catch ex As Exception

                End Try

            Catch ex As Exception
                'qui mettere gestione errori generica
                tb.TransactionRollBack()
                FormerLib.FormerHelper.Mail.InviaMail("Pagamento BANCA SELLA ERRORE ", "<h2>Check Logico: " & CheckLogico & "</h2> StrRequest " & strRequest & "<br><br>" & ex.Message, "soft@tipografiaformer.it")
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