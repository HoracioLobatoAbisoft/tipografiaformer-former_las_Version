Imports FormerDALSql
Imports FormerLib.FormerEnum


Friend Class frmConsegnaGLSReportContrassegno
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

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

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)

        If MessageBox.Show("Confermi qualcosa?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Ris = 1
            Close()

        End If

    End Sub

    Private Sub btnFileResoConto_Click(sender As Object, e As EventArgs) Handles btnFileResoConto.Click

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica("C:\")
            Sottofondo()

            If f.SelectedFile.Length Then
                Dim FileName As String = f.SelectedFile

                If FileName.ToLower.EndsWith(".pdf") Then
                    txtFileResoconto.Text = FileName
                Else
                    MessageBox.Show("Si possono selezionare solo file PDF")
                End If
            End If

        End Using

    End Sub

    Private Function InterpretaPdfGLS(Path As String, ByRef DataPagamento As Date) As List(Of ConsegnaProgrammata)

        Dim buffer As String = FormerLib.FormerHelper.PDF.GetTextFromPDF(Path)

        Dim righe() As String = buffer.Split(ControlChars.Lf)

        Dim l As New List(Of String)

        Dim DataPagamentoStr As String = String.Empty
        Dim contatoreRighe As Integer = 0

        For Each riga In righe
            contatoreRighe += 1

            If contatoreRighe > 2 Then
                Dim Valori() As String = riga.Split(" ")
                Dim ValoriNew(0) As String

                For Each val As String In Valori
                    If val.Trim.Length Then
                        ValoriNew(ValoriNew.Count - 1) = val
                        ReDim Preserve ValoriNew(ValoriNew.Count)
                    End If
                Next

                Dim CodTrack As String = Valori(Valori.Count - 1)

                If ValoriNew.Count > 5 Then
                    DataPagamentoStr = ValoriNew(5)
                End If

                If IsNumeric(CodTrack) Then

                    If CodTrack.Length > 6 Then
                        l.Add(CodTrack)
                    End If

                End If
            End If
        Next

        Dim lCons As New List(Of ConsegnaProgrammata)

        Using mgr As New ConsegneProgrammateDAO
            For Each singCod In l
                Dim lC As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, singCod))

                If lC.Count = 1 Then
                    lCons.Add(lC(0))
                End If

            Next
        End Using

        If lCons.Count Then

            Dim Anno As Integer = Now.Year
            Dim mese As String = ""
            Dim giorno As String = ""
            Dim OldPosizione As Integer = 0
            Dim Posizione As Integer = 0
            Posizione = DataPagamentoStr.IndexOf("/")

            giorno = DataPagamentoStr.Substring(0, Posizione)
            OldPosizione = Posizione
            Posizione = DataPagamentoStr.IndexOf("/", Posizione + 1)

            If Posizione = -1 Then
                mese = DataPagamentoStr.Substring(OldPosizione + 1)
            Else
                mese = DataPagamentoStr.Substring(OldPosizione + 1, Posizione - OldPosizione - 1)
            End If

            DataPagamento = New Date(Anno, mese, giorno)

        End If

        Return lCons

    End Function

    Private Sub btnInterpreta_Click(sender As Object, e As EventArgs) Handles btnInterpreta.Click

        If txtFileResoconto.Text.Length Then

            Dim Buffer As String = "In questo elenco le consegne che sono pagabili automaticamente con questa funzionalità:" & ControlChars.NewLine & ControlChars.NewLine
            Dim MaxLen As Integer = 0

            Dim DataRif As Date = Now.Date

            Dim lCons As List(Of ConsegnaProgrammata) = InterpretaPdfGLS(txtFileResoconto.Text, DataRif)

            For Each cons In lCons
                If cons.IndirizzoRif.Destinatario.Length > MaxLen Then MaxLen = cons.IndirizzoRif.Destinatario.Length
            Next

            lCons.Sort(Function(x, y) x.Giorno.CompareTo(y.Giorno))

            For Each cons In lCons

                If cons.HaDocumentiFiscali Then
                    For Each d As Ricavo In cons.ListaDocumenti

                        If d.Tipo = enTipoDocumento.Fattura OrElse d.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                            Buffer &= cons.Giorno.ToString("dd/MM/yyyy") & ControlChars.Tab &
                                      cons.ImpContrassegnoStr & ControlChars.Tab &
                                      FormerLib.FormerHelper.Stringhe.FormattaConSpazi(cons.IndirizzoRif.Destinatario, MaxLen) & ControlChars.Tab &
                                      cons.CodTrack & ControlChars.NewLine
                        End If
                    Next
                End If

            Next

            txtBuffer.Text = Buffer

            dtDataPagamento.Value = DataRif

        Else
            MessageBox.Show("Selezionare un file PDF")
        End If
    End Sub

    Private Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click
        If txtFileResoconto.Text.Length Then
            If MessageBox.Show("Confermi l'inserimento dei pagamenti per le consegne visualizzate al giorno selezionato?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim DataRif As Date = Now.Date
                Dim lCons As List(Of ConsegnaProgrammata) = InterpretaPdfGLS(txtFileResoconto.Text, DataRif)

                If lCons.Count Then
                    DataRif = dtDataPagamento.Value

                    Dim BufferResult As String = String.Empty

                    For Each cons In lCons

                        If cons.HaDocumentiFiscali Then
                            For Each d As Ricavo In cons.ListaDocumenti

                                If d.Tipo = enTipoDocumento.Fattura OrElse d.Tipo = enTipoDocumento.FatturaRiepilogativa Then

                                    'qui ci lavoro su
                                    Dim Differenza As Decimal = 0
                                    Using mgr As New PagamentiDAO
                                        Differenza = mgr.ImportoAncoraDaPagareDocumento(d.IdRicavo, enTipoVoceContab.VoceVendita)
                                    End Using
                                    If Differenza Then
                                        Using P As New Pagamento
                                            P.DataPag = DataRif
                                            P.Descrizione = "Bonifico Bancario GLS per Contrassegno"
                                            P.Importo = Differenza
                                            P.IdRub = cons.IdRub
                                            P.IdFat = d.IdRicavo
                                            P.NotePag = "Bonifico Bancario GLS per Contrassegno"
                                            P.Tipo = enTipoVoceContab.VoceVendita
                                            P.IdTipoPagamento = enMetodoPagamento.BonificoBancario
                                            P.Save()
                                        End Using

                                        Using doc As New cContabRicaviColl
                                            doc.PassaA(d.IdRicavo, enStatoOrdine.PagatoInteramente, True)
                                        End Using

                                        d.idstato = enStatoDocumentoFiscale.PagatoInteramente
                                        d.Save()

                                        If d.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                                            'qui devo mettere a pagato anche tutti i ddt contenuti 
                                            Using mgr As New RicaviDAO
                                                Dim lDDT As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.IdDocRif, d.IdRicavo))

                                                For Each R As Ricavo In lDDT
                                                    R.idstato = enStatoDocumentoFiscale.PagatoInteramente
                                                    R.Save()
                                                Next

                                            End Using

                                        End If
                                    End If


                                End If

                            Next
                        End If

                    Next

                    MessageBox.Show("Tutti i pagamenti sono stati salvati")
                Else
                    MessageBox.Show("Non ci sono consegne su cui salvare il pagamento")
                End If


            End If
        Else
            MessageBox.Show("Selezionare un file PDF")
        End If
    End Sub

End Class