Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.UI

Public Class ucAmministrazionePagamenti
    Inherits ucFormerUserControl

    'Private _TipoDoc As enTipoVoceContab
    Public Property TipoVoceContabile As enTipoVoceContab = enTipoVoceContab.NonSpecificata


    Private _IdRub As Integer = 0
    Public Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
        End Set
    End Property

    Private _IdDocRif As Integer = 0

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        MgrControl.InizializeGridview(DgPagamentiEx)
        dtDataSelInizio.Value = Now.Date
        dtDataSelFine.Value = Now.Date

    End Sub

    Public Property IdDocRif() As Integer
        Get
            Return _IdDocRif
        End Get
        Set(ByVal value As Integer)
            _IdDocRif = value
            If _IdDocRif Then
                chkOnlyDataSel.Checked = False
                chkOnlyDataSel.Visible = False
                dtDataSelFine.Visible = False
            End If
        End Set
    End Property

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        ParentFormEx.Sottofondo()

        StampaGlobale("Pagamenti", DgPagamentiEx)

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        Dim OkDate As Boolean = True
        If chkOnlyDataSel.Checked Then
            If dtDataSelInizio.Value > dtDataSelFine.Value Then
                OkDate = False
            End If
        End If
        If OkDate Then
            MostraDati(TipoVoceContabile)
        Else
            MessageBox.Show("Le date di inizio e fine del periodo non sono congruenti")
        End If

    End Sub

    Friend Sub MostraDati(ByVal TipoVoce As enTipoVoceContab)
        If IdRub = 0 Then
            DgPagamentiEx.Columns(0).IsVisible = True
        Else
            DgPagamentiEx.Columns(0).IsVisible = False
        End If

        TipoVoceContabile = TipoVoce

        Using mgr As New PagamentiDAO

            Dim ParRub As LUNA.LunaSearchParameter = Nothing
            If _IdRub Then
                ParRub = New LUNA.LunaSearchParameter(LFM.Pagamento.IdRub, _IdRub)
            End If

            Dim ParDocRif As LUNA.LunaSearchParameter = Nothing
            If _IdDocRif Then
                ParDocRif = New LUNA.LunaSearchParameter(LFM.Pagamento.IdFat, _IdDocRif)
            End If
            Dim ParTipoVoce As LUNA.LunaSearchParameter = New LUNA.LunaSearchParameter(LFM.Pagamento.Tipo, TipoVoceContabile)

            Dim ParPagDataPrima As LUNA.LunaSearchParameter = Nothing
            Dim ParPagDataDopo As LUNA.LunaSearchParameter = Nothing

            If chkOnlyDataSel.Checked Then
                Dim DataRif As Date = dtDataSelInizio.Value.Date
                Dim DataPre As Date = New Date(DataRif.Year, DataRif.Month, DataRif.Day, 0, 0, 0)
                DataRif = dtDataSelFine.Value.Date
                Dim DataPost As Date = New Date(DataRif.Year, DataRif.Month, DataRif.Day, 23, 59, 59)

                ParPagDataPrima = New LUNA.LunaSearchParameter(LFM.Pagamento.DataPag, DataPre, ">=")
                ParPagDataDopo = New LUNA.LunaSearchParameter(LFM.Pagamento.DataPag, DataPost, "<=")
            End If


            Dim l As List(Of Pagamento) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataPag Desc"},
                                                      ParRub,
                                                      ParDocRif,
                                                      ParTipoVoce,
                                                      ParPagDataPrima,
                                                      ParPagDataDopo)

            'DgPagamenti.AutoGenerateColumns = False
            'DgPagamenti.DataSource = l
            'DgPagamenti.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgPagamenti.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgPagamenti.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DgPagamenti.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DgPagamentiEx.AutoGenerateColumns = False
            DgPagamentiEx.DataSource = l

            Dim Totale As Decimal = l.Sum(Function(x) x.Importo)

            lblNumEuro.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Totale)

        End Using

    End Sub


    Private Sub DgPagamenti_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub ModificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaToolStripMenuItem.Click

        If DgPagamentiEx.SelectedRows.Count Then

            Dim IdVoce As Integer = DirectCast(DgPagamentiEx.SelectedRows(0).DataBoundItem, Pagamento).IdPag
            'riapertura pagamento
            ParentFormEx.Sottofondo()
            Dim appForm As New frmContabilitaPagamento

            If appForm.Carica(IdVoce) Then MostraDati(TipoVoceContabile)
            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub EliminaToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaToolStripMenu.Click
        If DgPagamentiEx.SelectedRows.Count Then
            Dim P As Pagamento = DgPagamentiEx.SelectedRows(0).DataBoundItem
            If P.IdConsegna Then
                MessageBox.Show("Impossibile eliminare un pagamento anticipato dal sito")
            ElseIf P.IdTipoPagamento = enMetodoPagamento.StornoDaNotaDiCredito Then
                MessageBox.Show("Impossibile eliminare un pagamento da una nota di credito")
            Else

                If MessageBox.Show("Confermi la cancellazione del pagamento?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Using cP As New PagamentiDAO
                        cP.Delete(P.IdPag)
                    End Using

                    If P.Tipo = enTipoVoceContab.VoceVendita Then
                        MgrDocumentiFiscali.AggiornaStatoRicavoDopoPagamento(P.IdFat)
                    ElseIf P.Tipo = enTipoVoceContab.VoceAcquisto Then
                        MgrDocumentiFiscali.AggiornaStatoCostoDopoPagamento(P.IdFat)
                    End If

                    MostraDati(TipoVoceContabile)

                End If
            End If

        End If
    End Sub

    Private Sub DgPagamenti_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim x As System.Drawing.Point = MousePosition
            ContextMenu.Show(x)
        End If
    End Sub

    Private Sub RiapriDocumentoFiscaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RiapriDocumentoFiscaleToolStripMenuItem.Click

        If DgPagamentiEx.SelectedRows.Count Then
            Dim P As Pagamento = DgPagamentiEx.SelectedRows(0).DataBoundItem

            If P.Tipo = enTipoVoceContab.VoceAcquisto Then
                Using voce As New Costo
                    voce.Read(P.IdFat)
                    If P.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                        ParentFormEx.Sottofondo()
                        Using appForm As New frmContabilitaFatturaRiepilogativaCosto
                            appForm.Carica(P.IdFat)
                        End Using
                        ParentFormEx.Sottofondo()
                    Else
                        ParentFormEx.Sottofondo()
                        Using appForm As New frmContabilitaCosto
                            appForm.Carica(P.IdFat)
                        End Using
                        ParentFormEx.Sottofondo()
                    End If

                End Using

            ElseIf P.Tipo = enTipoVoceContab.VoceVendita Then
                If P.IdFat Then
                    Using voce As New Ricavo
                        voce.Read(P.IdFat)
                        If P.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                            ParentFormEx.Sottofondo()
                            Using appForm As New frmContabilitaFatturaRiepilogativaRicavo
                                appForm.Carica(P.IdFat)
                            End Using
                            ParentFormEx.Sottofondo()
                        Else
                            ParentFormEx.Sottofondo()
                            Using appForm As New frmContabilitaRicavo
                                appForm.Carica(P.IdFat)
                            End Using
                            ParentFormEx.Sottofondo()
                        End If
                    End Using
                ElseIf P.IdConsegna Then
                    ParentFormEx.Sottofondo()
                    Using appForm As New frmConsegnaProgrammata
                        appForm.Carica(P.IdConsegna)
                    End Using
                    ParentFormEx.Sottofondo()
                End If
            End If
        End If

    End Sub

    Private Sub DgPagamentiEx_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles DgPagamentiEx.CellDoubleClick
        Dim RigaSel As Integer = e.RowIndex

        If RigaSel <> -1 Then
            Dim IdVoce As Integer = DirectCast(DgPagamentiEx.SelectedRows(0).DataBoundItem, Pagamento).IdPag
            'riapertura pagamento
            ParentFormEx.Sottofondo()
            Dim appForm As New frmContabilitaPagamento

            If appForm.Carica(IdVoce) Then MostraDati(TipoVoceContabile)
            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub DgPagamentiEx_MouseClick(sender As Object, e As MouseEventArgs) Handles DgPagamentiEx.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim x As System.Drawing.Point = MousePosition
            ContextMenu.Show(x)
        End If
    End Sub
End Class
