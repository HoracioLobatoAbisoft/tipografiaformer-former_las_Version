Imports FormerBusinessLogicInterface
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmCalcPrezzoLavorazioni
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _IdLav As Integer = 0

    Friend Function Carica(Optional IdLav As Integer = 0) As Integer

        CaricaCat()

        If IdLav Then
            Using l As New Lavorazione
                l.Read(IdLav)
                Dim ns As TreeNode() = tvwCatLavoraz.Nodes.Find("C" & l.IdCatLav, True)
                If ns.Count Then
                    Dim n As TreeNode = ns(0)
                    tvwCatLavoraz.SelectedNode = n
                    n.EnsureVisible()
                    CaricaLavInCat()
                    _LavSel = l.Clone
                    CalcolaPrezzo()
                End If


            End Using
        End If

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

    Private Sub CaricaCat()
        DgLavorazioni.DataSource = Nothing

        Using C As New CatLavDAO

            tvwCatLavoraz.Nodes.Clear()

            Dim Node As TreeNode = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Tutto, "TUTTO")
            Node.BackColor = Color.White
            Node.ForeColor = Color.Black

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.StampaOffset, "OFFSET")
            Node.BackColor = FormerColori.ColoreRepartoOffset
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.StampaDigitale, "DIGITALE")
            Node.BackColor = FormerColori.ColoreRepartoDigitale
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Packaging, "PACKAGING")
            Node.BackColor = FormerColori.ColoreRepartoPackaging
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Ricamo, "RICAMO")
            Node.BackColor = FormerColori.ColoreRepartoRicamo
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Etichette, "ETICHETTE")
            Node.BackColor = FormerColori.ColoreRepartoEtichette
            Node.ForeColor = Color.White

            tvwCatLavoraz.Nodes.Add("C0", "Senza categoria", 0, 0)

            For Each Cat As CatLav In C.GetAll("OrdineEsecuzione,Descrizione")
                Dim ChiavePadre As String = "C" & Cat.IdCatLav

                Dim ChiaveReparto As String = "R" & Cat.RepartoAppartenenza

                tvwCatLavoraz.Nodes(ChiaveReparto).Nodes.Add(ChiavePadre, Cat.Descrizione, 0, 0)

                'qui devo caricare tutti i singoli formati prodotto che sono linkati in tutte le lavorazioni di questa categoria
                'chiamo un metodo specifico che mi torna una serie di IdFormatoProdotto
                'Using mgr As New FormatiProdottoDAO
                '    For Each IdCl As Integer In mgr.ListaIdFormatoByIdCatLav(Cat.IdCatLav)
                '        Dim ChiaveNodo As String = ChiavePadre & "F" & IdCl
                '        Dim TextNodo As String = String.Empty
                '        If IdCl Then
                '            Dim fp As New FormatoProdotto
                '            fp.Read(IdCl)
                '            TextNodo = fp.Formato
                '        Else
                '            TextNodo = " * - Tutti i formati"
                '        End If
                '        tvwCatLavoraz.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes.Add(ChiaveNodo, TextNodo, 1, 1)

                '        Using mgrL As New LavorazioniDAO
                '            For Each IdL As Integer In mgrL.ListaIdLavorazioniByFormatoProdotto(IdCl, Cat.IdCatLav)
                '                Dim ChiaveNodoL As String = ChiaveNodo & "L" & IdL
                '                Dim TextNodoL As String = String.Empty

                '                Dim L As New Lavorazione
                '                L.Read(IdL)
                '                TextNodo = L.Sigla & " - " & L.Descrizione

                '                tvwCatLavoraz.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes(ChiaveNodo).Nodes.Add(ChiaveNodoL, TextNodo, 2, 2)

                '            Next
                '        End Using



                '    Next
                'End Using

            Next

            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Tutto).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.StampaOffset).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.StampaDigitale).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Ricamo).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Packaging).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Etichette).Expand()

        End Using

    End Sub


    Private Sub tvwCatLavoraz_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwCatLavoraz.AfterSelect
        CaricaLavInCat()
    End Sub
    Private Sub CaricaLavInCat()

        'carico la lista delle lavorazioni 
        ResetLavorazione()

        Using mgr As New LavorazioniDAO

            Dim IdCat As Integer = 0

            If Not tvwCatLavoraz.SelectedNode Is Nothing Then

                If tvwCatLavoraz.SelectedNode.Name.StartsWith("C") Then
                    Dim PosizF As Integer = tvwCatLavoraz.SelectedNode.Name.IndexOf("F")
                    If PosizF <> -1 Then
                        IdCat = tvwCatLavoraz.SelectedNode.Name.Substring(1, PosizF - 1)
                    Else
                        IdCat = tvwCatLavoraz.SelectedNode.Name.Substring(1)
                    End If
                End If
                Dim IdListinoBase As Integer = 0

                Dim l As List(Of LavorazioneEx) = mgr.ListaLavorazioni(0, IdCat, IdListinoBase) ',cmbCategoria.SelectedValue)
                DgLavorazioni.AutoGenerateColumns = False
                DgLavorazioni.DataSource = l

            End If
        End Using

        'Dim x As New cLavoriColl
        'Dim dtLista As DataTable

        'dtLista = x.ListaLavorazioni

        'DgLavorazioni.DataSource = dtLista

        'DgLavorazioni.Columns(0).Visible = False
        'DgLavorazioni.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"

        'x = Nothing

    End Sub

    Private Sub DgLavorazioni_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLavorazioni.CellContentClick

    End Sub

    Private Sub DgLavorazioni_Click(sender As Object, e As EventArgs) Handles DgLavorazioni.Click

        If DgLavorazioni.SelectedRows.Count Then
            _LavSel = DgLavorazioni.SelectedRows(0).DataBoundItem
        Else
            ResetLavorazione()
        End If
        CalcolaPrezzo()

    End Sub

    Private Sub SetLavorazione()
        lblLavSel.Text = _LavSel.Descrizione
        lblDimensMin.Text = IIf(_LavSel.DimensMinW, _LavSel.DimensMinW & " (larg.) x " & _LavSel.DimensMinH & " (lung.) mm", "Non impostata")
        lblDimensMax.Text = IIf(_LavSel.DimensMaxW, _LavSel.DimensMaxW & " (larg.) x " & _LavSel.DimensMaxH & " (lung.) mm", "Non impostata")
        lblGrammMin.Text = IIf(_LavSel.GrammiMin, _LavSel.GrammiMin & " gr", "Non impostata")
        lblGrammMax.Text = IIf(_LavSel.GrammiMax, _LavSel.GrammiMax & " gr", "Non impostata")
        lnkMacchinario.Text = _LavSel.MacchinarioRif.Descrizione

    End Sub

    Private Sub ResetLavorazione()
        _LavSel = Nothing
        lblLavSel.Text = "-"
        lblDimensMin.Text = "-"
        lblDimensMax.Text = "-"
        lblGrammMin.Text = "-"
        lblGrammMax.Text = "-"

    End Sub

    Private _LavSel As Lavorazione = Nothing

    Private Sub CalcolaPrezzo()

        Cursor = Cursors.WaitCursor

        If Not _LavSel Is Nothing Then
            Try
                'calcolo il prezzo sulla lav sel 
                SetLavorazione()

                Dim ErrMsg As String = String.Empty

                If txtLarghezza.Value <> 0 And txtLunghezza.Value <> 0 Then
                    If txtGrammatura.Value Then
                        If _LavSel.GrammiMin <> 0 AndAlso txtGrammatura.Value < _LavSel.GrammiMin Then
                            ErrMsg = "La lavorazione prevede un minimo di grammatura di " & _LavSel.GrammiMin & " gr"
                        End If
                        If _LavSel.GrammiMax <> 0 AndAlso txtGrammatura.Value > _LavSel.GrammiMax Then
                            ErrMsg &= "La lavorazione prevede un massimo di grammatura di " & _LavSel.GrammiMax & " gr"
                        End If
                    End If

                    'qui devo controllare dimensioni minime e massime 
                    If _LavSel.DimensMinH <> 0 Then
                        If (txtLarghezza.Text < _LavSel.DimensMinW And txtLunghezza.Text < _LavSel.DimensMinH) AndAlso
                               (txtLarghezza.Text < _LavSel.DimensMinH And txtLunghezza.Text < _LavSel.DimensMinW) Then
                            'qui è troppo piccolo
                            ErrMsg &= "Le dimensioni inserite sono minori delle dimensioni minime impostate per questa lavorazione"
                        End If
                    End If
                    If _LavSel.DimensMaxH <> 0 Then
                        If (txtLarghezza.Text > _LavSel.DimensMaxW Or txtLunghezza.Text > _LavSel.DimensMaxH) And
                        (txtLarghezza.Text > _LavSel.DimensMinH Or txtLunghezza.Text > _LavSel.DimensMinW) Then
                            'qui è troppo piccolo
                            ErrMsg &= "Le dimensioni inserite sono maggiori delle dimensioni massime impostate per questa lavorazione"
                        End If
                    End If
                Else
                    ErrMsg &= "Inserire tutte le dimensioni dell'oggetto"
                End If

                If ErrMsg.Length = 0 Then

                    Dim L As New ListinoBase
                    L.NumFacciate = txtNumFacciate.Text
                    L.FaccMin = txtNumFacciate.Text
                    L.FaccMax = txtNumFacciate.Text
                    _LavSel.CaricaPrezzi()

                    Dim IdFormProdForzato As Integer = 0
                    Dim IdFormCartaForzato As Integer = 0

                    'qui vedo se ho gia un formato prodotto che ribatte le dimensioni del formato inserito
                    Dim Larghezza As Integer = txtLarghezza.Text
                    Dim Lunghezza As Integer = txtLunghezza.Text

                    For Each p In _LavSel.Prezzi
                        If p.IdFormProd Then
                            If (p.FormatoProdotto.Larghezza = Larghezza And p.FormatoProdotto.Lunghezza = Lunghezza) OrElse
                           (p.FormatoProdotto.Larghezza = Lunghezza And p.FormatoProdotto.Lunghezza = Larghezza) Then
                                IdFormProdForzato = p.FormatoProdotto.IdFormProd
                                IdFormCartaForzato = p.FormatoProdotto.IdFormCarta
                                Larghezza = 0
                                Lunghezza = 0
                                Exit For
                            End If
                        ElseIf p.IdFormCarta Then
                            If (p.FormatoCarta.LarghezzaMM = Larghezza And p.FormatoCarta.AltezzaMM = Lunghezza) OrElse
                           (p.FormatoCarta.LarghezzaMM = Lunghezza And p.FormatoCarta.AltezzaMM = Larghezza) Then
                                IdFormProdForzato = -1
                                IdFormCartaForzato = p.IdFormCarta
                                Larghezza = 0
                                Lunghezza = 0
                                Exit For
                            End If
                        End If
                    Next

                    Dim PrezzoCalcolato As RisCalcoloPrezzoLavorazione = MgrPreventivazioneB.CalcolaPrezzoLavorazione(txtQuantita.Text,
                                                                                            _LavSel,
                                                                                            L, L.TipoCarta, Lunghezza, Larghezza, True,
                                                                                            ,
                                                                                            ,
                                                                                            IdFormProdForzato,
                                                                                            IdFormCartaForzato)

                    If PrezzoCalcolato.PrezzoTotale = 0 Then
                        lblPrezzo.Text = "Prezzo non calcolabile"
                    Else
                        Dim Avviamento As Decimal = 0
                        Dim PrezzoNetto As Decimal = 0

                        If PrezzoCalcolato.IdMacchinario Then
                            Using M As New Macchinario
                                M.Read(PrezzoCalcolato.IdMacchinario)
                                Avviamento = M.CostoMinAvv
                                PrezzoNetto = PrezzoCalcolato.PrezzoTotale - Avviamento
                            End Using
                        Else
                            PrezzoNetto = PrezzoCalcolato.PrezzoTotale
                        End If
                        lblAvviamento.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Avviamento)
                        lblPrezzoCalcolato.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(PrezzoNetto)
                        lblPrezzo.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(PrezzoCalcolato.PrezzoTotale)
                    End If
                Else
                    'qui ci sono stati degli errori
                    lblPrezzo.Text = ErrMsg
                End If

            Catch ex As Exception
                lblPrezzo.Text = "-"
            End Try

        Else
            lblPrezzo.Text = "-"
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub txtLarghezza_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezza.TextChanged,
                                                                                   txtLunghezza.TextChanged,
                                                                                   txtGrammatura.TextChanged,
                                                                                   txtNumFacciate.TextChanged,
                                                                                   txtQuantita.TextChanged

        CalcolaPrezzo()
    End Sub

    Private Sub lblLavSel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblDimensMin_Click(sender As Object, e As EventArgs) Handles lblDimensMin.Click

    End Sub

    Private Sub lblPrezzo_Click(sender As Object, e As EventArgs) Handles lblPrezzo.Click

    End Sub

    Private Sub lblLavSel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblLavSel.LinkClicked
        If Not _LavSel Is Nothing Then

            Sottofondo()

            Using f As New frmListinoLavorazione
                f.Carica(_LavSel.IdLavoro)
            End Using

            Sottofondo()
        End If
    End Sub

    Private Sub lnkMacchinario_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMacchinario.LinkClicked
        If Not _LavSel Is Nothing Then

            Sottofondo()

            Using f As New frmListinoMacchinario
                f.Carica(_LavSel.MacchinarioRif.IdMacchinario)
            End Using

            Sottofondo()
        End If
    End Sub
End Class