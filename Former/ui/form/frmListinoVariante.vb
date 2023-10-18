Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmListinoVariante
    'Inherits baseFormInternaFixed

    Private _Ris As Integer
    Private _IdGruppoVar As Integer = 0

    Friend Function Carica(Optional IdGruppoVar As Integer = 0) As Integer
        _IdGruppoVar = IdGruppoVar
        CaricaListe()

        If IdGruppoVar Then
            'ricarico l'oggetto
            Using v As New GruppoVariante
                v.Read(IdGruppoVar)
                txtNome.Text = v.Nome

                For Each p As Preventivazione In v.ListaPrev
                    For i = 0 To chkPreventivazione.Items.Count - 1
                        Dim item As Preventivazione = chkPreventivazione.Items(i)
                        If item.IdPrev = p.IdPrev Then
                            If chkPreventivazione.GetItemCheckState(i) = CheckState.Unchecked Then chkPreventivazione.SetItemChecked(i, True)
                            Exit For
                        End If
                    Next
                Next

                For Each tc As TipoCarta In v.ListaTC
                    For i = 0 To chkTipoCarta.Items.Count - 1
                        Dim item As TipoCarta = chkTipoCarta.Items(i)
                        If item.IdTipoCarta = tc.IdTipoCarta Then
                            If chkTipoCarta.GetItemCheckState(i) = CheckState.Unchecked Then chkTipoCarta.SetItemChecked(i, True)
                            Exit For
                        End If
                    Next
                Next

                For Each cl As CatLav In v.ListaCatLav
                    For i = 0 To chkLavorazioni.Items.Count - 1
                        Dim item As CatLav = chkLavorazioni.Items(i)
                        If item.IdCatLav = cl.IdCatLav Then
                            If chkLavorazioni.GetItemCheckState(i) = CheckState.Unchecked Then chkLavorazioni.SetItemChecked(i, True)
                            Exit For
                        End If
                    Next
                Next
                CalcolaRiassunto()
            End Using

        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaListe()

        Using mgr As New PreventivazioniDAO
            Dim l As List(Of Preventivazione) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Preventivazione.GruppoVariante, "(0," & _IdGruppoVar & ")", "IN"))

            l.Sort(AddressOf FormerListSorter.PreventivazioneSorter.SortRepartoDescrizione)

            chkPreventivazione.DataSource = l
            chkPreventivazione.DisplayMember = "DescrizioneConReparto"
            chkPreventivazione.ValueMember = "IdPrev"

        End Using

        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.GetBySQL("SELECT * FROM T_LISTINOBASE ORDER By Nome")

            chkLB.DataSource = l
            chkLB.DisplayMember = "Nome"
            chkLB.ValueMember = "IdListinoBase"

        End Using

        Using mgr As New TipiCartaDAO
            Dim l As List(Of TipoCarta) = mgr.GetAll("Finitura,Tipologia")

            'l.Sort(Function(x, y) x.DescrizioneConReparto.CompareTo(y.DescrizioneConReparto))

            chkTipoCarta.DataSource = l
            chkTipoCarta.DisplayMember = "RiassuntoTipologia"
            chkTipoCarta.ValueMember = "IdTipoCarta"

        End Using

        Using mgr As New CatLavDAO
            Dim l As List(Of CatLav) = mgr.FindAll("RepartoAppartenenza,Descrizione",
                                                   New LUNA.LunaSearchParameter(LFM.CatLav.VisibilePreventivo, enSiNo.Si))

            'l.Sort(Function(x, y) x.DescrizioneConReparto.CompareTo(y.DescrizioneConReparto))

            chkLavorazioni.DataSource = l
            chkLavorazioni.DisplayMember = "Riassunto"
            chkLavorazioni.ValueMember = "IdCatLav"

        End Using

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Salva()

        If MessageBox.Show("Confermi il salvataggio?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If chkPreventivazione.CheckedItems.Count = 0 Or chkLB.CheckedItems.Count = 0 Then
                MessageBox.Show("Si deve selezionare almeno una preventivazione o un ListinoBase")
            Else

                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

                    Try
                        tb.TransactionBegin()
                        Using V As New GruppoVariante
                            V.Read(_IdGruppoVar)
                            V.Nome = txtNome.Text
                            V.Save()

                            If _IdGruppoVar Then
                                Using mgr As New GruppiVariantiRifDAO
                                    mgr.DeleteByIdGruppoVariante(V.IdGruppoVariante)
                                End Using

                                Using mgr As New PreventivazioniDAO
                                    mgr.ResetGruppoVariante(V.IdGruppoVariante)
                                End Using

                            End If

                            For Each item As Preventivazione In chkPreventivazione.CheckedItems
                                Using rif As New GruppoVarianteRif
                                    rif.IdGruppoVariante = V.IdGruppoVariante
                                    rif.IdRiferimento = item.IdPrev
                                    rif.TipoRiferimento = enTipoOggettoListino.Preventivazione
                                    rif.Save()

                                    Using P As New Preventivazione
                                        P.Read(item.IdPrev)
                                        P.GruppoVariante = V.IdGruppoVariante
                                        P.Save()
                                    End Using

                                End Using
                            Next

                            For Each item As TipoCarta In chkTipoCarta.CheckedItems
                                Using rif As New GruppoVarianteRif
                                    rif.IdGruppoVariante = V.IdGruppoVariante
                                    rif.IdRiferimento = item.IdTipoCarta
                                    rif.TipoRiferimento = enTipoOggettoListino.TipoCarta
                                    rif.Save()
                                End Using
                            Next

                            For Each item As CatLav In chkLavorazioni.CheckedItems
                                Using rif As New GruppoVarianteRif
                                    rif.IdGruppoVariante = V.IdGruppoVariante
                                    rif.IdRiferimento = item.IdCatLav
                                    rif.TipoRiferimento = enTipoOggettoListino.CatLav
                                    rif.Save()
                                End Using
                            Next
                        End Using
                        tb.TransactionCommit()

                        _Ris = 1
                        Close()

                    Catch ex As Exception
                        tb.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nel salvataggio, riprovare. Errore " & ex.Message)
                    End Try
                End Using

            End If

        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub chkPreventivazione_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chkPreventivazione.SelectedIndexChanged

    End Sub




    Private Sub chkPreventivazione_SelectedValueChanged(sender As Object, e As EventArgs) Handles chkPreventivazione.SelectedValueChanged,
                                                                                                    chkTipoCarta.SelectedValueChanged,
                                                                                                    chkLavorazioni.SelectedValueChanged,
                                                                                                    chkLB.SelectedValueChanged
        If sender.focused Then

            Dim chk As CheckedListBox = sender
            If chk Is chkPreventivazione AndAlso chk.GetItemChecked(chk.SelectedIndex) = False Then
                'qui ha deselezionato devo andare a togliere i default di quella preventivazione

                Deseleziona(chk.SelectedItem.idPrev)

            End If

            SelezioneAutomatica()
            CalcolaRiassunto()
        End If

    End Sub

    Private Sub Deseleziona(IdPrev As Integer)

        Using P As New Preventivazione
            P.Read(IdPrev)
            P.CaricaListinoBase(, enTipoListiniBase.Sorgente)
            For Each Lb As ListinoBase In P.ListiniBase
                Lb.CaricaLavorazioni()
                For i = 0 To chkTipoCarta.Items.Count - 1
                    Dim tc As TipoCarta = chkTipoCarta.Items(i)
                    If tc.IdTipoCarta = Lb.IdTipoCarta Then
                        If chkTipoCarta.GetItemCheckState(i) = CheckState.Checked Then
                            chkTipoCarta.SetItemChecked(i, False)
                            'Exit For
                        End If
                    End If
                Next

                For i = 0 To chkLavorazioni.Items.Count - 1
                    Dim tc As CatLav = chkLavorazioni.Items(i)
                    If Lb.IdCategorieLavorazioni.FindAll(Function(x) x = tc.IdCatLav).Count Then
                        If chkLavorazioni.GetItemCheckState(i) = CheckState.Checked Then
                            chkLavorazioni.SetItemChecked(i, False)
                            'Exit For
                        End If
                    End If
                Next
            Next

        End Using

    End Sub

    Private Sub SelezioneAutomatica()

        'qui in base alla preventivazioner scelta seleziono in automatico tutti i tipi carta e le lavorazioni 

        For Each item As Preventivazione In chkPreventivazione.CheckedItems
            item.CaricaListinoBase(, enTipoListiniBase.Sorgente)
            For Each Lb As ListinoBase In item.ListiniBase
                Lb.CaricaLavorazioni()
                For i = 0 To chkTipoCarta.Items.Count - 1
                    Dim tc As TipoCarta = chkTipoCarta.Items(i)
                    If tc.IdTipoCarta = Lb.IdTipoCarta Then
                        If chkTipoCarta.GetItemCheckState(i) = CheckState.Unchecked Then
                            chkTipoCarta.SetItemChecked(i, True)
                            'Exit For
                        End If
                    End If
                Next

                For i = 0 To chkLavorazioni.Items.Count - 1
                    Dim tc As CatLav = chkLavorazioni.Items(i)
                    If Lb.IdCategorieLavorazioni.FindAll(Function(x) x = tc.IdCatLav).Count Then
                        If chkLavorazioni.GetItemCheckState(i) = CheckState.Unchecked Then
                            chkLavorazioni.SetItemChecked(i, True)
                            'Exit For
                        End If
                    End If
                Next
            Next


        Next

    End Sub

    Private Sub CalcolaRiassunto()

        lstPrev.Items.Clear()
        Dim ListaPrev As New List(Of Preventivazione)
        For Each item As Preventivazione In chkPreventivazione.CheckedItems

            Dim x As New cEnum
            x.Descrizione = item.Descrizione
            x.Id = item.IdPrev
            lstPrev.Items.Add(x)
            'item.CaricaListinoBase()
            ListaPrev.Add(item)
        Next

        lstLB.Items.Clear()
        Dim ListaLB As New List(Of ListinoBase)
        For Each item As ListinoBase In chkLB.CheckedItems

            Dim x As New cEnum
            x.Descrizione = item.Nome
            x.Id = item.IdPrev
            lstLB.Items.Add(x)
            'item.CaricaListinoBase()
            ListaLB.Add(item)
        Next

        lstTC.Items.Clear()
        For Each item As TipoCarta In chkTipoCarta.CheckedItems
            Dim x As New cEnum

            Dim Descr As String = item.Tipologia
            Dim Suff As String = " - AGGIUNTO"
            Dim Trovato As Boolean = False
            For Each p As Preventivazione In ListaPrev
                Using mgr As New PreventivazioniDAO
                    If mgr.UseThisTipoCarta(p.IdPrev, item.IdTipoCarta) Then
                        Suff = " - INCLUSO"
                        Trovato = True
                        Exit For
                    End If
                End Using
            Next
            Descr &= Suff
            x.Descrizione = Descr
            x.Id = item.IdTipoCarta
            lstTC.Items.Add(x)

        Next

        lstLav.Items.Clear()
        For Each item As CatLav In chkLavorazioni.CheckedItems
            Dim x As New cEnum

            Dim Descr As String = item.Descrizione
            Dim Suff As String = " - AGGIUNTO"
            Dim Trovato As Boolean = False
            For Each p As Preventivazione In ListaPrev
                Using mgr As New PreventivazioniDAO
                    If mgr.UseThisCatLav(p.IdPrev, item.IdCatLav) Then
                        Suff = " - INCLUSO"
                        Trovato = True
                        Exit For
                    End If
                End Using
            Next
            Descr &= Suff
            x.Descrizione = Descr
            x.Id = item.IdCatLav
            lstLav.Items.Add(x)
        Next


    End Sub

    Private Sub lnkPulisciPrev_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPulisciPrev.LinkClicked
        Pulisci(chkPreventivazione)
    End Sub

    Private Sub Pulisci(ByRef chk As CheckedListBox)
        Cursor.Current = Cursors.WaitCursor
        For i = 0 To chk.Items.Count - 1
            If chk.GetItemCheckState(i) = CheckState.Checked Then
                chk.SetItemChecked(i, False)
            End If
        Next
        SelezioneAutomatica()
        CalcolaRiassunto()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lnkPulisciTC_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPulisciTC.LinkClicked
        Pulisci(chkTipoCarta)
    End Sub

    Private Sub lnkPulisciLav_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPulisciLav.LinkClicked
        Pulisci(chkLavorazioni)
    End Sub

    Private Sub lnkDelPrev_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelPrev.LinkClicked
        Elimina(lstPrev)
    End Sub

    Private Sub Elimina(lst As ListBox)
        Cursor.Current = Cursors.WaitCursor
        'If chk.SelectedIndex <> -1 Then
        '    chk.SetItemCheckState(chk.SelectedIndex, CheckState.Unchecked)
        'End If
        Dim chkB As CheckedListBox = Nothing
        Dim IdRif As Integer = lst.SelectedItem.id

        If lst Is lstPrev Then
            chkB = chkPreventivazione
            Deseleziona(IdRif)
            For I = 0 To chkB.Items.Count - 1
                Dim voce As Preventivazione = chkB.Items(I)
                If voce.IdPrev = IdRif Then
                    chkB.SetItemCheckState(I, CheckState.Unchecked)
                End If
            Next
        ElseIf lst Is lstTC Then
            chkB = chkTipoCarta
            For I = 0 To chkB.Items.Count - 1
                Dim voce As TipoCarta = chkB.Items(I)
                If voce.IdTipoCarta = IdRif Then
                    chkB.SetItemCheckState(I, CheckState.Unchecked)
                End If
            Next
        ElseIf lst Is lstLav Then
            chkB = chkLavorazioni
            For I = 0 To chkB.Items.Count - 1
                Dim voce As CatLav = chkB.Items(I)
                If voce.IdCatLav = IdRif Then
                    chkB.SetItemCheckState(I, CheckState.Unchecked)
                End If
            Next
        End If


        SelezioneAutomatica()
        CalcolaRiassunto()
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub lnkDelTC_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelTC.LinkClicked
        Elimina(lstTC)
    End Sub

    Private Sub lnkDelLav_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelLav.LinkClicked
        Elimina(lstLav)
    End Sub

    Private Sub lnkPulisciLB_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPulisciLB.LinkClicked
        Pulisci(chkLB)
    End Sub

    Private Sub lnkDelLB_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelLB.LinkClicked
        Elimina(lstLB)
    End Sub

    Private Sub ChiudiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChiudiToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub SalvaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvaToolStripMenuItem.Click
        Salva()
    End Sub

    Private Sub lstPrev_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPrev.SelectedIndexChanged

    End Sub
End Class