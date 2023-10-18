Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Friend Class frmProntoRitiroCliente
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Friend Function Carica() As Integer
        CaricaCombo()
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

    Private Sub CaricaAlberoConsegne(IdRub As Integer)
        Cursor.Current = Cursors.WaitCursor
        'carico gli ordini

        Dim LstM As New List(Of OrdineRicerca)
        Using mgr As New OrdiniDAO
            LstM = mgr.Lista(, enStatoOrdine.Registrato & "," & _
                                enStatoOrdine.InSospeso & "," & _
                                enStatoOrdine.InCodaDiStampa & "," & _
                                enStatoOrdine.StampaInizio & "," & _
                                enStatoOrdine.StampaFine & "," & _
                                enStatoOrdine.FinituraCommessaInizio & "," & _
                                enStatoOrdine.FinituraCommessaFine & "," & _
                                enStatoOrdine.FinituraProdottoInizio & "," & _
                                enStatoOrdine.FinituraProdottoFine & "," & _
                                enStatoOrdine.Imballaggio & "," & _
                                enStatoOrdine.ImballaggioCorriere & "," & _
                                enStatoOrdine.ProntoRitiro, , , , , , , , , , IdRub)
        End Using
        LstM.Sort(AddressOf ComparerDataIns)
        tvConsCliente.Nodes.Clear()

        For Each c As OrdineRicerca In LstM
            Dim ChiaveData As String = "D" & c.DataConsPrevKey
            Dim ChiaveCorriere As String = ChiaveData & "C" & c.IdCorriere
            Dim ChiaveRubrica As String = ChiaveCorriere & "R" & c.IdRub
            Dim ChiaveOrdine As String = "P" & c.IdOrd

            Dim NodoData As TreeNode = tvConsCliente.Nodes(ChiaveData)
            If NodoData Is Nothing Then
                NodoData = tvConsCliente.Nodes.Add(ChiaveData, c.DataConsPrevShort, 7, 7)
                'NodoData.Expand()
            End If

            Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
            If NodoCorr Is Nothing Then
                NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, c.CorriereStr, 6, 6)
                'NodoCorr.Expand()
            End If
            Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
            If NodoRub Is Nothing Then
                NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, c.ClienteNominativo, 0, 0)
                ' NodoRub.EnsureVisible()
            End If
            NodoCorr.Expand()
            Dim nodoOrd As TreeNode = NodoRub.Nodes.Add(ChiaveOrdine, "Ord." & c.IdOrd & " - " & c.ProdottoDescrizione, 1, 1)
            nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.Stato)
            nodoOrd.Tag = c

        Next
        tvConsCliente.ExpandAll()
        Cursor.Current = Cursors.Default
    End Sub

    Private Function ComparerDataIns(ByVal x As Ordine, ByVal y As Ordine) As Integer
        Dim result As Integer = x.DataPrevConsegna.CompareTo(y.DataPrevConsegna)

        Return result
    End Function

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged
        If cmbCliente.Focused Then
            CaricaAlberoConsegne(cmbCliente.SelectedValue)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CaricaCombo()
        'carico la combo dei clienti con solo quelli che hanno almeno un ordine nello stato da preinserito a prontoritiro
        Dim lst As List(Of VoceRubrica) = Nothing
        Using mgr As New VociRubricaDAO
            lst = mgr.ListaCombo(enTipoRubrica.Tutto, True, "AlberoOperatoreConsegna")
        End Using
        cmbCliente.DisplayMember = "Nominativo"
        cmbCliente.ValueMember = "IdRub"
        cmbCliente.DataSource = lst
    End Sub
    Private Sub tvConsCliente_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvConsCliente.AfterSelect
        If e.Node.Name.StartsWith("P") Then
            Dim IdOrd As Integer = e.Node.Name.Substring(1)
            Cursor.Current = Cursors.WaitCursor

            CreaAnteprima(, IdOrd)

            Cursor.Current = Cursors.Default

        End If
    End Sub
    Private Sub CreaAnteprima(Optional IdCom As Integer = 0, Optional IdOrd As Integer = 0)

        Cursor.Current = Cursors.WaitCursor
        If IdCom Then
            Dim Com As New Commessa
            Com.Read(IdCom)

            MgrAnteprime.CreaRiepilogoCom(Com, UcCommesseAnteprimaOp.WebPrew, enTipoAnteprima.Breve)
            Com = Nothing
            UcCommesseAnteprimaOp.CaricaDatiAccessori(, IdCom)
        Else
            Dim Ord As New Ordine
            Ord.Read(IdOrd)

            MgrAnteprime.CreaRiepilogoOrd(Ord, UcCommesseAnteprimaOp.WebPrew, enTipoAnteprima.Breve)
            Ord = Nothing
            UcCommesseAnteprimaOp.CaricaDatiAccessori(IdOrd)

        End If
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Close()
    End Sub
End Class