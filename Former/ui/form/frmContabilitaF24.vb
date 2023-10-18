Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmContabilitaF24
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _IdF24 As Integer = 0
    Friend Function Carica(Optional IdF24 As Integer = 0) As Integer
        _IdF24 = IdF24

        CaricaCombo()

        If IdF24 Then
            'carico
            Using f24 As New F24
                f24.Read(IdF24)
                MgrControl.SelectIndexComboEnum(cmbAzienda, f24.IdAzienda)
                txtDescrizione.Text = f24.Descrizione
                txtTotale.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(f24.Totale)

                If f24.PagatoIl <> Date.MinValue Then
                    chkPagamentoEffettuato.Checked = True
                    txtNotePagamento.Text = f24.NotePagamento
                    dtPagamento.Value = f24.PagatoIl
                End If

                For Each riga In f24.SezioneErario
                    Dim rigaDG As New DataGridViewRow
                    rigaDG.CreateCells(DgErario)

                    rigaDG.Cells(0).Value = riga.CodiceTributo
                    rigaDG.Cells(1).Value = riga.Mese
                    rigaDG.Cells(2).Value = riga.Anno
                    rigaDG.Cells(3).Value = riga.ImportiDebito
                    rigaDG.Cells(4).Value = riga.ImportiCredito
                    DgErario.Rows.Add(rigaDG)
                Next

                For Each riga In f24.SezioneInps
                    Dim rigaDG As New DataGridViewRow
                    rigaDG.CreateCells(DgInps)
                    rigaDG.Cells(0).Value = riga.CodiceSede
                    rigaDG.Cells(1).Value = riga.CausaleContributo
                    rigaDG.Cells(2).Value = riga.MatricolaInps
                    rigaDG.Cells(3).Value = riga.PeriodoDa
                    rigaDG.Cells(4).Value = riga.PeriodoA
                    rigaDG.Cells(5).Value = riga.ImportiDebito
                    rigaDG.Cells(6).Value = riga.ImportiCredito

                    DgInps.Rows.Add(rigaDG)
                Next

                For Each riga In f24.SezioneRegioni
                    Dim rigaDG As New DataGridViewRow
                    rigaDG.CreateCells(DgRegioni)
                    rigaDG.Cells(0).Value = riga.CodiceRegione
                    rigaDG.Cells(1).Value = riga.CodiceTributo
                    rigaDG.Cells(2).Value = riga.Mese
                    rigaDG.Cells(3).Value = riga.Anno
                    rigaDG.Cells(4).Value = riga.ImportiDebito
                    rigaDG.Cells(5).Value = riga.ImportiCredito
                    DgRegioni.Rows.Add(rigaDG)
                Next

                For Each riga In f24.SezioneImu
                    Dim rigaDG As New DataGridViewRow
                    rigaDG.CreateCells(DgImu)
                    rigaDG.Cells(0).Value = riga.CodiceRegione
                    rigaDG.Cells(1).Value = riga.CodiceTributo
                    rigaDG.Cells(2).Value = riga.Mese
                    rigaDG.Cells(3).Value = riga.Anno
                    rigaDG.Cells(4).Value = riga.ImportiDebito
                    rigaDG.Cells(5).Value = riga.ImportiCredito
                    DgImu.Rows.Add(rigaDG)
                Next

                For Each riga In f24.SezioneAltriEnti
                    Dim rigaDG As New DataGridViewRow
                    rigaDG.CreateCells(DGAltriEnti)
                    rigaDG.Cells(0).Value = riga.CodiceSede
                    rigaDG.Cells(1).Value = riga.CodiceDitta
                    rigaDG.Cells(2).Value = riga.cc
                    rigaDG.Cells(3).Value = riga.NumeroRiferimento
                    rigaDG.Cells(4).Value = riga.Causale
                    rigaDG.Cells(5).Value = riga.ImportiDebito
                    rigaDG.Cells(6).Value = riga.ImportiCredito
                    DGAltriEnti.Rows.Add(rigaDG)
                Next

            End Using

        End If
        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Dim laz As New List(Of cEnum)
        Dim az1 As New cEnum(MgrAziende.IdAziende.AziendaSnc, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSnc))
        laz.Add(az1)
        Dim az2 As New cEnum(MgrAziende.IdAziende.AziendaSrl, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSrl))
        laz.Add(az2)

        cmbAzienda.ValueMember = "Id"
        cmbAzienda.DisplayMember = "Descrizione"
        cmbAzienda.DataSource = laz

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object,
                                 ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object,
                                ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object,
                                        ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object,
                            e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If _IdF24 Then
                Using t As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                    Try
                        Using f As New F24
                            f.Read(_IdF24)
                            'f.InseritoIl = Now
                            f.Descrizione = txtDescrizione.Text
                            f.Totale = AggiornaTotali()
                            f.IdAzienda = DirectCast(cmbAzienda.SelectedItem, cEnum).Id

                            If chkPagamentoEffettuato.Checked Then
                                f.PagatoIl = dtPagamento.Value
                                f.NotePagamento = txtNotePagamento.Text
                            Else
                                f.PagatoIl = Date.MinValue
                                f.NotePagamento = String.Empty
                            End If

                            t.TransactionBegin()
                            f.Save()

                            Using mgr As New F24DettaglioDAO
                                mgr.DeleteByIdF24(_IdF24)
                            End Using

                            Dim ColonnaDebito As Integer = 0
                            Dim ColonnaCredito As Integer = 0

                            ColonnaDebito = DgErario.ColumnCount - 2
                            ColonnaCredito = ColonnaDebito + 1

                            For Each row As DataGridViewRow In DgErario.Rows
                                If (Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "") OrElse
                                    (Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "") Then
                                    Using fdett As New F24Dettaglio
                                        fdett.IdF24 = f.IdF24
                                        fdett.IdSezione = enSezioneF24.Erario
                                        fdett.CodiceTributo = row.Cells(0).Value
                                        fdett.Mese = row.Cells(1).Value
                                        fdett.Anno = row.Cells(2).Value
                                        fdett.ImportiDebito = row.Cells(3).Value
                                        fdett.ImportiCredito = row.Cells(4).Value
                                        fdett.Save()
                                    End Using
                                End If

                            Next
                            ColonnaDebito = DgInps.ColumnCount - 2
                            ColonnaCredito = ColonnaDebito + 1
                            For Each row As DataGridViewRow In DgInps.Rows
                                If (Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "") OrElse
                                    (Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "") Then
                                    Using fdett As New F24Dettaglio
                                        fdett.IdF24 = f.IdF24
                                        fdett.IdSezione = enSezioneF24.Inps
                                        fdett.CodiceSede = row.Cells(0).Value
                                        fdett.CausaleContributo = row.Cells(1).Value
                                        fdett.MatricolaInps = row.Cells(2).Value
                                        fdett.PeriodoDa = row.Cells(3).Value
                                        fdett.PeriodoA = row.Cells(4).Value
                                        fdett.ImportiDebito = row.Cells(5).Value
                                        fdett.ImportiCredito = row.Cells(6).Value
                                        fdett.Save()
                                    End Using
                                End If

                            Next
                            ColonnaDebito = DgRegioni.ColumnCount - 2
                            ColonnaCredito = ColonnaDebito + 1
                            For Each row As DataGridViewRow In DgRegioni.Rows
                                If (Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "") OrElse
                                    (Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "") Then
                                    Using fdett As New F24Dettaglio
                                        fdett.IdF24 = f.IdF24
                                        fdett.IdSezione = enSezioneF24.Regioni
                                        fdett.CodiceRegione = row.Cells(0).Value
                                        fdett.CodiceTributo = row.Cells(1).Value
                                        fdett.Mese = row.Cells(2).Value
                                        fdett.Anno = row.Cells(3).Value
                                        fdett.ImportiDebito = row.Cells(4).Value
                                        fdett.ImportiCredito = row.Cells(5).Value
                                        fdett.Save()
                                    End Using
                                End If

                            Next

                            ColonnaDebito = DgImu.ColumnCount - 2
                            ColonnaCredito = ColonnaDebito + 1
                            For Each row As DataGridViewRow In DgImu.Rows
                                If (Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "") OrElse
                                    (Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "") Then
                                    Using fdett As New F24Dettaglio
                                        fdett.IdF24 = f.IdF24
                                        fdett.IdSezione = enSezioneF24.Imu
                                        fdett.CodiceRegione = row.Cells(0).Value
                                        fdett.CodiceTributo = row.Cells(1).Value
                                        fdett.Mese = row.Cells(2).Value
                                        fdett.Anno = row.Cells(3).Value
                                        fdett.ImportiDebito = row.Cells(4).Value
                                        fdett.ImportiCredito = row.Cells(5).Value
                                        fdett.Save()
                                    End Using
                                End If

                            Next

                            ColonnaDebito = DGAltriEnti.ColumnCount - 2
                            ColonnaCredito = ColonnaDebito + 1
                            For Each row As DataGridViewRow In DGAltriEnti.Rows
                                If (Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "") OrElse
                                    (Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "") Then
                                    Using fdett As New F24Dettaglio
                                        fdett.IdF24 = f.IdF24
                                        fdett.IdSezione = enSezioneF24.AltriEnti
                                        fdett.CodiceSede = row.Cells(0).Value
                                        fdett.CodiceDitta = row.Cells(1).Value
                                        fdett.cc = row.Cells(2).Value
                                        fdett.NumeroRiferimento = row.Cells(3).Value
                                        fdett.Causale = row.Cells(4).Value
                                        fdett.ImportiDebito = row.Cells(5).Value
                                        fdett.ImportiCredito = row.Cells(6).Value
                                        fdett.Save()
                                    End Using
                                End If

                            Next

                            t.TransactionCommit()
                        End Using
                    Catch ex As Exception
                        t.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nel salvataggio del modello F24: " & ex.Message)
                    End Try
                End Using
            Else
                Using t As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                    Try
                        Using f As New F24
                            f.InseritoIl = Now
                            f.Descrizione = txtDescrizione.Text
                            f.Totale = AggiornaTotali()
                            f.IdAzienda = DirectCast(cmbAzienda.SelectedItem, cEnum).Id
                            If chkPagamentoEffettuato.Checked Then
                                f.PagatoIl = dtPagamento.Value
                                f.NotePagamento = txtNotePagamento.Text
                            Else
                                f.PagatoIl = Date.MinValue
                                f.NotePagamento = String.Empty
                            End If
                            t.TransactionBegin()
                            f.Save()

                            For Each row As DataGridViewRow In DgErario.Rows
                                Using fdett As New F24Dettaglio
                                    fdett.IdF24 = f.IdF24
                                    fdett.IdSezione = enSezioneF24.Erario
                                    fdett.CodiceTributo = row.Cells(0).Value
                                    fdett.Mese = row.Cells(1).Value
                                    fdett.Anno = row.Cells(2).Value
                                    fdett.ImportiDebito = row.Cells(3).Value
                                    fdett.ImportiCredito = row.Cells(4).Value
                                    fdett.Save()
                                End Using
                            Next

                            For Each row As DataGridViewRow In DgInps.Rows
                                Using fdett As New F24Dettaglio
                                    fdett.IdF24 = f.IdF24
                                    fdett.IdSezione = enSezioneF24.Inps
                                    fdett.CodiceSede = row.Cells(0).Value
                                    fdett.CausaleContributo = row.Cells(1).Value
                                    fdett.MatricolaInps = row.Cells(2).Value
                                    fdett.PeriodoDa = row.Cells(3).Value
                                    fdett.PeriodoA = row.Cells(4).Value
                                    fdett.ImportiDebito = row.Cells(5).Value
                                    fdett.ImportiCredito = row.Cells(6).Value
                                    fdett.Save()
                                End Using
                            Next

                            For Each row As DataGridViewRow In DgRegioni.Rows
                                Using fdett As New F24Dettaglio
                                    fdett.IdF24 = f.IdF24
                                    fdett.IdSezione = enSezioneF24.Regioni
                                    fdett.CodiceRegione = row.Cells(0).Value
                                    fdett.CodiceTributo = row.Cells(1).Value
                                    fdett.Mese = row.Cells(2).Value
                                    fdett.Anno = row.Cells(3).Value
                                    fdett.ImportiDebito = row.Cells(4).Value
                                    fdett.ImportiCredito = row.Cells(5).Value
                                    fdett.Save()
                                End Using
                            Next

                            t.TransactionCommit()
                        End Using
                    Catch ex As Exception
                        t.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nel salvataggio del modello F24: " & ex.Message)
                    End Try
                End Using

            End If



            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub dgErario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgErario.CellContentClick

    End Sub

    Private Sub dgErario_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgErario.CellEndEdit,
                                                                                               DgInps.CellEndEdit,
                                                                                               DgRegioni.CellEndEdit,
                                                                                               DgImu.CellEndEdit,
                                                                                               DGAltriEnti.CellEndEdit

        If e.ColumnIndex >= sender.ColumnCount - 2 Then
            If Not sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing AndAlso
                sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value <> "" Then
                sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Replace(".", ",")
                Dim val As Decimal = sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = val.ToString("f")
            End If

            AggiornaTotali()

        End If
    End Sub

    Private Function AggiornaTotali() As Decimal

        Dim TotaleDebito As Decimal = 0
        Dim TotaleCredito As Decimal = 0
        Dim ColonnaDebito As Integer = 0
        Dim ColonnaCredito As Integer = 0
        Dim Saldo As Decimal = 0

        Try
            ColonnaDebito = DgErario.ColumnCount - 2
            ColonnaCredito = ColonnaDebito + 1

            For Each row As DataGridViewRow In DgErario.Rows

                If Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "" Then
                    Dim Value1 As Decimal = row.Cells(ColonnaDebito).Value.ToString.Replace(".", ",")
                    TotaleDebito += Value1
                End If
                If Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "" Then
                    Dim Value2 As Decimal = row.Cells(ColonnaCredito).Value.ToString.Replace(".", ",")
                    TotaleCredito += Value2
                End If

            Next

            ColonnaDebito = DgInps.ColumnCount - 2
            ColonnaCredito = ColonnaDebito + 1

            For Each row As DataGridViewRow In DgInps.Rows

                If Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "" Then
                    Dim Value1 As Decimal = row.Cells(ColonnaDebito).Value.ToString.Replace(".", ",")
                    TotaleDebito += Value1
                End If
                If Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "" Then
                    Dim Value2 As Decimal = row.Cells(ColonnaCredito).Value.ToString.Replace(".", ",")
                    TotaleCredito += Value2
                End If

            Next

            ColonnaDebito = DgRegioni.ColumnCount - 2
            ColonnaCredito = ColonnaDebito + 1

            For Each row As DataGridViewRow In DgRegioni.Rows

                If Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "" Then
                    Dim Value1 As Decimal = row.Cells(ColonnaDebito).Value.ToString.Replace(".", ",")
                    TotaleDebito += Value1
                End If
                If Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "" Then
                    Dim Value2 As Decimal = row.Cells(ColonnaCredito).Value.ToString.Replace(".", ",")
                    TotaleCredito += Value2
                End If

            Next

            ColonnaDebito = DgImu.ColumnCount - 2
            ColonnaCredito = ColonnaDebito + 1

            For Each row As DataGridViewRow In DgImu.Rows

                If Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "" Then
                    Dim Value1 As Decimal = row.Cells(ColonnaDebito).Value.ToString.Replace(".", ",")
                    TotaleDebito += Value1
                End If
                If Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "" Then
                    Dim Value2 As Decimal = row.Cells(ColonnaCredito).Value.ToString.Replace(".", ",")
                    TotaleCredito += Value2
                End If

            Next

            ColonnaDebito = DGAltriEnti.ColumnCount - 2
            ColonnaCredito = ColonnaDebito + 1

            For Each row As DataGridViewRow In DGAltriEnti.Rows

                If Not row.Cells(ColonnaDebito).Value Is Nothing AndAlso row.Cells(ColonnaDebito).Value <> "" Then
                    Dim Value1 As Decimal = row.Cells(ColonnaDebito).Value.ToString.Replace(".", ",")
                    TotaleDebito += Value1
                End If
                If Not row.Cells(ColonnaCredito).Value Is Nothing AndAlso row.Cells(ColonnaCredito).Value <> "" Then
                    Dim Value2 As Decimal = row.Cells(ColonnaCredito).Value.ToString.Replace(".", ",")
                    TotaleCredito += Value2
                End If

            Next

            Saldo = TotaleDebito - TotaleCredito

            txtTotale.BackColor = Color.White
            txtTotale.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Saldo)

        Catch ex As Exception
            txtTotale.BackColor = Color.White
            txtTotale.Text = "#ERRORE"
        End Try

        Return Saldo

    End Function

    Private Sub DgRegioni_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DgRegioni.RowsRemoved,
            DgInps.RowsRemoved,
            DgErario.RowsRemoved,
            DgImu.RowsRemoved,
            DGAltriEnti.RowsRemoved
        AggiornaTotali()
    End Sub

    Private Sub DgImu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgImu.CellContentClick

    End Sub
End Class