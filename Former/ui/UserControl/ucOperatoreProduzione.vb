Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucOperatoreProduzione
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        'MgrControl.InizializeGridview(DgLavoriEx, False)

    End Sub

    Private IdMacchinarioSelezionato As Integer = 0

    Public Sub Carica()
        pctOperatore.Image = PostazioneCorrente.UtenteConnesso.FotoOperatore
        toolTipHelp.SetToolTip(pctOperatore, PostazioneCorrente.UtenteConnesso.Login)
        lblNomeUt.Text = PostazioneCorrente.UtenteConnesso.Login
        Application.DoEvents()
        CaricaMacchinari()
        CaricaMenuATendina()
        CaricaPreventivazioni()
        DgLavori.DataSource = Nothing
        lblMacchinario.Text = "-"
    End Sub

    Private Sub CaricaMenuATendina()

        Using mgr As New MacchinariDAO
            Dim l As List(Of Macchinario) = mgr.GetAll("Tipo, Descrizione")

            ForzaIlLavoroAlMacchinarioToolStripMenuItem.DropDownItems.Clear()

            For Each singMacc As Macchinario In l

                Dim t As New ToolStripMenuItem(singMacc.Riassunto(True))
                t.Tag = singMacc.IdMacchinario
                AddHandler t.Click, AddressOf ForzaMacchinarioSuLavoro
                ForzaIlLavoroAlMacchinarioToolStripMenuItem.DropDownItems.Add(t)
            Next
        End Using

        Using mgr As New UtentiDAO
            Dim l As List(Of Utente) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "tipo,login"},
                                                   New LUNA.LunaSearchParameter(LFM.Utente.Attivo, enSiNo.Si))
            ForzaIlLavoroAlloperatoreToolStripMenuItem.DropDownItems.Clear()

            For Each singUt As Utente In l
                Dim t As New ToolStripMenuItem(singUt.Riassunto)
                t.Tag = singUt.IdUt
                AddHandler t.Click, AddressOf ForzaOperatoreSuLavoro
                ForzaIlLavoroAlloperatoreToolStripMenuItem.DropDownItems.Add(t)
            Next

        End Using

    End Sub

    Private Sub ForzaOperatoreSuLavoro(sender As Object, e As EventArgs)

        If DgLavori.SelectedRows.Count Then
            Dim Lav As ILavoroOperatore = DgLavori.SelectedRows(0).DataBoundItem

            If Lav.IdUtInCarico = 0 Then
                If MessageBox.Show("Vuoi rendere disponibile il lavoro all'operatore selezionato? ", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Using l As New LavLog
                        l.Read(Lav.IdLavLog)
                        l.IdUtenteForzato = sender.tag
                        l.Save()
                    End Using

                    Using m As New Macchinario
                        m.Read(IdMacchinarioSelezionato)
                        CaricaLavoriMacchinario(m)
                    End Using

                    MessageBox.Show("Il lavoro è disponibile per l'operatore selezionato")

                End If
            Else
                MessageBox.Show("Il Lavoro è gia stato iniziato")
            End If

        Else
            Beep()
        End If
    End Sub

    Private Sub ForzaMacchinarioSuLavoro(sender As Object, e As EventArgs)
        If DgLavori.SelectedRows.Count Then
            Dim Lav As ILavoroOperatore = DgLavori.SelectedRows(0).DataBoundItem

            If Lav.IdUtInCarico = 0 Then
                If MessageBox.Show("Confermi lo spostamento del lavoro sul macchinario selezionato? ", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Using l As New LavLog
                        l.Read(Lav.IdLavLog)
                        Using M As New Macchinario
                            M.Read(sender.tag)
                            l.IdMacchinario = M.IdMacchinario
                            l.Macchinario = M.Descrizione
                            l.Save()
                        End Using

                    End Using

                    Using m As New Macchinario
                        m.Read(IdMacchinarioSelezionato)
                        CaricaLavoriMacchinario(m)
                    End Using

                    MessageBox.Show("Il lavoro è stato assegnato al macchinario selezionato")
                End If
            Else
                MessageBox.Show("Il Lavoro è gia stato iniziato")
            End If

        Else
            Beep()
        End If

    End Sub

    Private Sub CaricaMacchinari()
        Cursor = Cursors.WaitCursor


        Dim IdOrdine As Integer = 0
        Dim IdCommessa As Integer = 0

        Using mgr As New MacchinariDAO

            IdOrdine = txtNumOrd.Value
            IdCommessa = txtNumCom.Value

            Dim l As List(Of Macchinario) = mgr.GetMacchinariInCodaLavoro(IdOrdine, IdCommessa)
            toolTipHelp.RemoveAll()
            FlowMacchinari.Controls.Clear()
            Dim f As New Font("Segoe UI", 10, FontStyle.Bold)

            For Each singM As Macchinario In l

                Dim SoloProntiDaLavorare As Boolean = chkSoloProntiDaLavorare.Checked

                'AGGIUNTO PER VEDERE SEMPRE ANCHE I NON PRONTI SUI MACCHINARI DI STAMPA 
                If singM.Tipo = enTipoMacchinario.Produzione Then
                    SoloProntiDaLavorare = False
                End If

                Dim MacchinarioAbilitato As Boolean = False
                Dim LavoriForzatiSuMacchinario As Integer = 0
                If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
                    MacchinarioAbilitato = True
                Else
                    'qui devo vedere se mi spetta questo macchinario o se ho qualche lavoro su un macchinario che non mi spetta

                    Using mgrUM As New UtMacDAO
                        Dim lUM As List(Of UtMac) = mgrUM.FindAll(New LUNA.LunaSearchParameter(LFM.UtMac.IdUt, PostazioneCorrente.UtenteConnesso.IdUt),
                                                                  New LUNA.LunaSearchParameter(LFM.UtMac.IdMac, singM.IdMacchinario))
                        If lUM.Count Then
                            MacchinarioAbilitato = True
                        Else
                            'qui devo vedere se per caso ho un lavoro abilitato che non e' il mio tra quelli in coda
                            LavoriForzatiSuMacchinario = singM.LavoriInCoda(SoloProntiDaLavorare).FindAll(Function(x) x.IdUtenteForzato = PostazioneCorrente.UtenteConnesso.IdUt).Count
                            If LavoriForzatiSuMacchinario Then
                                MacchinarioAbilitato = True
                            End If
                        End If
                    End Using

                End If

                If MacchinarioAbilitato Then
                    Dim NumeroLavoriInCoda As Integer = 0
                    If LavoriForzatiSuMacchinario Then
                        NumeroLavoriInCoda = LavoriForzatiSuMacchinario
                        singM.InCaricoPerLavoriForzati = True
                    Else
                        NumeroLavoriInCoda = singM.LavoriInCoda(SoloProntiDaLavorare).Count
                    End If

                    Dim OkInLista As Boolean = True
                    If NumeroLavoriInCoda Then
                        Dim btn As New Button
                        btn.Name = "btn" & singM.IdMacchinario
                        btn.Tag = singM
                        'btn.Width = FlowMacchinari.Width - 3
                        btn.TextAlign = ContentAlignment.MiddleLeft
                        btn.Height = 70
                        btn.Width = 100
                        btn.Image = singM.Img
                        btn.ImageAlign = ContentAlignment.MiddleLeft
                        btn.TextAlign = ContentAlignment.MiddleRight
                        btn.Font = f
                        btn.BackColor = Color.White

                        btn.Text = NumeroLavoriInCoda

                        toolTipHelp.SetToolTip(btn, singM.Riassunto(True))

                        AddHandler btn.Click, AddressOf MacchinarioCliccato

                        FlowMacchinari.Controls.Add(btn)
                    End If
                End If

            Next

        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub CaricaLavoriMacchinario(Optional M As Macchinario = Nothing)
        Cursor = Cursors.WaitCursor
        'in sender ho il pulsate di cui di base mi interessa solo il tag

        Dim IdOrdine As Integer = 0
        Dim IdCommessa As Integer = 0

        IdOrdine = txtNumOrd.Value
        IdCommessa = txtNumCom.Value

        If M Is Nothing Then
            'tento di reperire il primo macchinario disponibile 
            For Each ctr As Button In FlowMacchinari.Controls
                Dim IdMacc As Integer = ctr.Name.Substring(3)

                M = New Macchinario
                M.Read(IdMacc)

                IdMacchinarioSelezionato = M.IdMacchinario
                Exit For
            Next
            If M Is Nothing Then
                IdMacchinarioSelezionato = 0
            End If
        Else
            IdMacchinarioSelezionato = M.IdMacchinario
        End If

        If IdMacchinarioSelezionato Then
            Dim SoloProntiDaLavorare As Boolean = chkSoloProntiDaLavorare.Checked

            If M.Tipo = enTipoMacchinario.Produzione Then
                SoloProntiDaLavorare = False
            End If

            lblMacchinario.Text = M.Descrizione

            'qui devo caricare i lavori di questo macchinario 
            Dim l As New List(Of ILavoroOperatore)

            Dim lInt As List(Of LavLog) = Nothing
            Dim IdUtDaForzare As Integer = 0

            If M.InCaricoPerLavoriForzati Then
                IdUtDaForzare = PostazioneCorrente.UtenteConnesso.IdUt
            End If

            lInt = M.LavoriInCoda(SoloProntiDaLavorare, IdUtDaForzare, IdOrdine, IdCommessa, cmbCatProd.SelectedValue)
            For Each singLav In lInt
                l.Add(singLav)
            Next

            DgLavori.AutoGenerateColumns = False

            If M.Tipo = enTipoMacchinario.Allestimento Then
                'DgLavori.Columns("Qta").Visible = False
                DgLavori.Columns("Risorsa").Visible = False
                DgLavori.Columns("NLastre").Visible = False
                DgLavori.Columns("RagSoc").Visible = False 'TRUE
                DgLavori.Columns("Lavorazione").Visible = True
                DgLavori.Columns("Ordine").Visible = True
                'DgLavoriEx.Columns("Qta").IsVisible = False
                'DgLavoriEx.Columns("Risorsa").IsVisible = False
                'DgLavoriEx.Columns("NLastre").IsVisible = False
            Else
                'DgLavori.Columns("Qta").Visible = True
                DgLavori.Columns("Risorsa").Visible = True
                DgLavori.Columns("NLastre").Visible = True
                DgLavori.Columns("RagSoc").Visible = False
                DgLavori.Columns("Lavorazione").Visible = False
                DgLavori.Columns("Ordine").Visible = False


                'DgLavoriEx.Columns("Qta").IsVisible = True
                'DgLavoriEx.Columns("Risorsa").IsVisible = True
                'DgLavoriEx.Columns("NLastre").IsVisible = True
            End If

            'qui ordino la lista
            l.Sort(Function(x, y) x.DataRifOrdinamento.CompareTo(y.DataRifOrdinamento))

            DgLavori.DataSource = l

            'DgLavoriEx.DataSource = l

            DgLavori.ClearSelection()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub RicaricaLavori()
        Application.DoEvents()
        If IdMacchinarioSelezionato Then
            Dim Trovato As Boolean = False
            'qui devo controllare che il macchinario selezionato ci sia ancora tra quelli disponibili
            'in realta se non ci fosse piu niente la lista sarebbe vuota ma resterebbe selezionato un macchinario non valido
            For Each ctr As Control In FlowMacchinari.Controls
                If TypeOf (ctr) Is Button Then
                    Dim IdMacc As Integer = ctr.Name.Substring(3)
                    If IdMacc = IdMacchinarioSelezionato Then
                        Trovato = True
                        Exit For
                    End If
                End If
            Next
            If Trovato Then
                Using m As New Macchinario
                    m.Read(IdMacchinarioSelezionato)
                    CaricaLavoriMacchinario(m)
                End Using
            Else
                DgLavori.DataSource = Nothing
                lblMacchinario.Text = "-"
            End If
        Else
            DgLavori.DataSource = Nothing
            lblMacchinario.Text = "-"
        End If
    End Sub

    Private Sub MacchinarioCliccato(sender As Object, e As EventArgs)
        Dim M As Macchinario = DirectCast(sender.tag, Macchinario)
        CaricaLavoriMacchinario(M)
    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        CaricaMacchinari()
        RicaricaLavori()
    End Sub

    Private Sub chkSoloProntiDaLavorare_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloProntiDaLavorare.CheckedChanged
        If sender.focused Then
            CaricaMacchinari()
            'Application.DoEvents()
            RicaricaLavori()
        End If
    End Sub

    Private Sub DgLavori_CellMouseup(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgLavori.CellMouseUp
        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
            If e.Button = MouseButtons.Right Then
                DgLavori.Rows(e.RowIndex).Selected = True
                If DgLavori.SelectedRows.Count Then
                    'qui vado a popolare il menu a tendina
                    mnuLavoro.Show(Cursor.Position)
                End If
            End If
        End If
    End Sub

    Private Sub PrendiInCaricoIlLavoro()
        If DgLavori.SelectedRows.Count Then
            Dim Lav As ILavoroOperatore = DgLavori.SelectedRows(0).DataBoundItem
            'qui devo capire se quel lavoro lo posso o no prendere in carico 
            If Lav.PrendibileInCarico(PostazioneCorrente.UtenteConnesso.IdUt) Then
                Dim Ris As Integer = 0

                If Lav.IdCommessa Then
                    lnkLastWork.Tag = "C" & Lav.IdCommessa
                    lnkLastWork.Text = "Segui Commessa " & Lav.IdCommessa
                ElseIf Lav.IdOrdine Then
                    lnkLastWork.Tag = "O" & Lav.IdOrdine
                    lnkLastWork.Text = "Segui Ordine " & Lav.IdOrdine
                End If

                Using frm As New frmOperatoreNew
                    ParentFormEx.Sottofondo()
                    Ris = frm.Carica(Lav)
                    ParentFormEx.Sottofondo()

                    If Ris Then
                        CaricaMacchinari() 'DISATTIVATO PER NON RICARICARE SIA MACCHINARI CHE LAVORI
                        RicaricaLavori()
                        'RicaricaLavori()
                    End If
                End Using
            Else
                MessageBox.Show("Il lavoro selezionato non è attualmente in uno stato che permette di prenderlo in carico")
            End If
        Else
            Beep()
        End If
    End Sub

    Private Sub btnPrendiInCarico_Click(sender As Object, e As EventArgs) Handles btnPrendiInCarico.Click

        PrendiInCaricoIlLavoro()

    End Sub

    Private Sub DgLavori_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgLavori.RowPostPaint
        Try
            Dim r As DataGridViewRow = DgLavori.Rows(e.RowIndex)
            Dim lav As ILavoroOperatore = r.DataBoundItem

            If lav.PrendibileInCarico(PostazioneCorrente.UtenteConnesso.IdUt) = False Then
                If lav.IdUtInCarico Then
                    r.DefaultCellStyle.BackColor = Color.FromArgb(214, 224, 61)
                    r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 224, 61)
                Else
                    r.DefaultCellStyle.BackColor = Color.LightGray
                    r.DefaultCellStyle.SelectionBackColor = Color.LightGray
                End If

                Dim f As New Font(r.DefaultCellStyle.Font, FontStyle.Italic)
                r.DefaultCellStyle.Font = f
            Else
                If lav.IdUtInCarico = PostazioneCorrente.UtenteConnesso.IdUt Then
                    r.DefaultCellStyle.BackColor = Color.FromArgb(214, 224, 61)
                    r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 224, 61)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgLavori_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLavori.CellClick
        If e.RowIndex >= 0 Then
            Dim L As ILavoroOperatore = DirectCast(DgLavori.SelectedRows(0).DataBoundItem, ILavoroOperatore)
            If L.IdCommessa Then
                RaiseEvent CommessaSelezionata(L.IdCommessa)
            Else
                RaiseEvent OrdineSelezionato(L.IdOrdine)
            End If

            Try
                If sender.focused Then
                    FormPrincipale.UcToolbarMain.ShowNote(L.AnnotazioniOperatore)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub DgLavori_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgLavori.CellMouseDoubleClick

        PrendiInCaricoIlLavoro()

    End Sub

    Private Sub DgLavori_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgLavori.ColumnHeaderMouseClick
        OrdinatoreLista(Of ILavoroOperatore).OrdinaLista(sender, e)
    End Sub

    Private Sub DgLavori_SelectionChanged(sender As Object, e As EventArgs) Handles DgLavori.SelectionChanged

        'provo a mettere il font della riga selezionata non bold

        For Each row As DataGridViewRow In DgLavori.Rows
            If row.DefaultCellStyle.Font.Bold = True Then

                Dim NewStyle As Integer = FontStyle.Regular

                If row.DefaultCellStyle.Font.Italic = True Then
                    NewStyle += FontStyle.Italic
                End If

                Dim f As Font = New Font(row.DefaultCellStyle.Font, NewStyle)

                row.DefaultCellStyle.Font = f

            End If
        Next

        For Each row As DataGridViewRow In DgLavori.SelectedRows
            Dim NewStyle As Integer = FontStyle.Bold

            If row.DefaultCellStyle.Font.Italic = True Then
                NewStyle += FontStyle.Italic
            End If

            Dim f As Font = New Font(row.DefaultCellStyle.Font, NewStyle)

            row.DefaultCellStyle.Font = f
        Next

    End Sub

    Public Event CommessaSelezionata(ByVal IdCommessa As Integer)

    Public Event OrdineSelezionato(ByVal IdOrdine As Integer)

    Private Sub txtNumOrd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumOrd.KeyDown,
                                                                                txtNumCom.KeyDown
        If sender.focused Then
            If e.KeyCode = Keys.Enter Then
                CaricaMacchinari()
                CaricaLavoriMacchinario()
            End If
        End If

    End Sub

    Private Sub txtNumOrd_TextChanged(sender As Object, e As EventArgs) Handles txtNumOrd.TextChanged
        If sender.focused Then txtNumCom.Text = String.Empty
    End Sub

    Private Sub txtNumCom_TextChanged(sender As Object, e As EventArgs) Handles txtNumCom.TextChanged
        If sender.focused Then txtNumOrd.Text = String.Empty
    End Sub

    Private Sub lnkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReset.LinkClicked

        chkSoloProntiDaLavorare.Checked = False
        txtNumCom.Text = String.Empty
        txtNumOrd.Text = String.Empty

    End Sub

    Private Sub lnkLastWork_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLastWork.LinkClicked

        'rimetto in cerca l'ultima cosa fatta

        If Not lnkLastWork.Tag Is Nothing Then
            Dim Link As String = lnkLastWork.Tag.ToString
            If Link.Length Then
                Dim IdRif As Integer = Link.Substring(1)
                If Link.StartsWith("C") Then
                    txtNumOrd.Text = ""
                    txtNumCom.Text = IdRif
                Else
                    txtNumOrd.Text = IdRif
                    txtNumCom.Text = ""
                End If
                CaricaMacchinari()
                CaricaLavoriMacchinario()
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub DgLavori_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLavori.CellContentClick

    End Sub

    Private Sub lnkAggiornaPrev_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        CaricaPreventivazioni()

    End Sub

    Private Sub CaricaPreventivazioni()

        Cursor.Current = Cursors.WaitCursor

        Using mgr As New PreventivazioniDAO

            cmbCatProd.ValueMember = "IdPrev"
            cmbCatProd.DisplayMember = "Descrizione"

            cmbCatProd.DataSource = mgr.ListaInCoda()
        End Using

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub pctAggiornaPrev_Click(sender As Object, e As EventArgs) Handles pctAggiornaPrev.Click
        CaricaPreventivazioni()
    End Sub

    Private Sub pctHelpFlag_Click(sender As Object, e As EventArgs) Handles pctHelpFlag.Click
        ParentFormEx.Sottofondo()

        Using f As New frmInfoBandierine
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()

    End Sub
End Class
