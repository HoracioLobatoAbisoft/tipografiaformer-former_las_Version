Imports FormerDALWeb
Imports FormerLib.FormerEnum

Friend Class frmContabilitaPagamentoOnlineBonifico
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _C As Consegna = Nothing
    Friend Function Carica(C As Consegna) As Integer

        _C = C

        dtPagam.Value = Now.Date
        txtImporto.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_C.ImportoTot, 2)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim Imp As Decimal = 0
        Try
            Imp = CDec(txtImporto.Text)
        Catch ex As Exception

        End Try

        If MessageBox.Show("Confermi il salvataggio del bonifico bancario anticipato?", "Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()

                Try
                    tb.TransactionBegin()

                    Dim P As New PagamentoOnline
                    P.IdUt = _C.IdUt
                    P.Quando = dtPagam.Value
                    P.IdConsegna = _C.IdConsegna
                    P.IdTipoPagamento = enMetodoPagamento.BonificoBancarioAnticipato
                    P.Importo = _C.ImportoTot
                    P.StatoPagamento = enStatoPagamento.Pagato
                    P.Save()

                    If _C.IdStatoConsegna = enStatoConsegna.InAttesaDiPagamento Then
                        _C.IdStatoConsegna = enStatoConsegna.InLavorazione
                        _C.Save()
                        For Each O As OrdineWeb In _C.ListaOrdini
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
                Catch ex As Exception
                    tb.TransactionRollBack()
                    MessageBox.Show("Si è verificato un errore nel salvataggio del pagamento Online: " & ex.Message)
                End Try

            End Using

            Try
                'qui invio una mail al cliente avvisandolo che il pagamento e' stato registrato e i suoi ordini sono in attesa di invio file
                Dim BufferEmail As String = String.Empty
                Dim emailDest As String = _C.Utente.Email

                Dim Titolo As String = "Pagamento con Bonifico Bancario registrato. Allegare i file all'ordine"
                Dim Testo As String = "Gentile cliente,<br><br> la informiamo che il pagamento relativo al suo ordine <b>" & _C.IdConsegna & "</b> è stato correttamente registrato e, se previsti dal prodotto scelto, può ora allegare i file all'ordine direttamente dal sito."

                FormerLib.FormerHelper.Mail.InviaMail(Titolo, Testo, emailDest)

            Catch ex As Exception

            End Try

            _Ris = 1

            Close()

        End If

    End Sub

End Class