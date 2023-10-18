Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmMagazzinoCaricaColli
    'Inherits baseFormInternaRedim

    Private _Ris As String = ""
    Private _BufferCodice As String = ""

    Private _ClienteParam As Integer = 0
    Private _ListaIdOrdParam As String = ""

    Friend Function Carica(Optional ByVal ClienteSel As Integer = 0, Optional ByVal ListaIdOrd As String = "") As String

        _ClienteParam = ClienteSel
        _ListaIdOrdParam = ListaIdOrd

        CaricaOrdini(ClienteSel, ListaIdOrd)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaOrdini(Optional ByVal _ClienteSel As Integer = 0, Optional ByVal ListaIdOrd As String = "")
        DgLavori.Rows.Clear()

        Dim dt As DataTable, riga As DataRow

        Using Ordini As New cOrdiniColl
            Ordini.IdRub = _ClienteSel
            Dim ListaOrdini As String = enStatoOrdine.UscitoMagazzino & "," & enStatoOrdine.InConsegna & "," & enStatoOrdine.Consegnato & "," & enStatoOrdine.PagatoAcconto & "," & enStatoOrdine.PagatoInteramente
            dt = Ordini.Lista(, ListaOrdini, , , ListaIdOrd, , , True)
        End Using
        For Each riga In dt.Rows

            'qui controllo che ogni ordine non sia gia in un documento fiscale
            Using O As New Ordine
                O.Read(riga("Ord"))

                If O.DocumentoFiscale Is Nothing Then
                    Dim Dr As New DataGridViewRow

                    Dim ImgPreview As Image
                    Dim ImgNew As Image = Nothing
                    Try
                        ImgPreview = Image.FromFile(riga("filePath").ToString)
                        ImgNew = New Bitmap(ImgPreview, New Size(50, 75))
                    Catch ex As Exception
                        ImgNew = Nothing
                    End Try

                    Dr.CreateCells(DgLavori)

                    Dr.Cells(0).Value = ImgNew
                    Dr.Cells(1).Value = O.IdOrd
                    Dr.Cells(2).Value = O.StatoStr
                    Dr.Cells(3).Value = riga("Prodotto")
                    Dr.Cells(4).Value = O.VoceRubrica.RagSocNome
                    Dr.Cells(5).Value = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(riga("TotaleImp").ToString)
                    Dr.Cells(6).Value = IIf(CInt(riga("preventivo").ToString) = enSiNo.Si, "Si", "No")

                    Dr.Cells(2).Style.BackColor = FormerLib.FormerColori.GetColoreStatoOrdine(O.Stato)

                    DgLavori.Rows.Add(Dr)
                End If

            End Using

        Next

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        SelezionaOrdine()

    End Sub

    Private Sub SelezionaOrdine()

        If DgLavori.SelectedRows.Count Then

            Dim Codice As String = ""
            For Each dr As DataGridViewRow In DgLavori.SelectedRows
                Codice &= dr.Cells(1).Value.ToString & ","
            Next
            Codice = Codice.TrimEnd(",")

            '_Ris = FromEan13(Codice)
            _Ris = Codice

            Close()
        Else

            MessageBox.Show("Selezionare un ordine dalla lista!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    Private Sub txtCodice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MgrControl.ControlloNumerico(sender, e, True)
    End Sub

    Private Sub DgLavori_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLavori.CellDoubleClick
        SelezionaOrdine()
    End Sub

    Private Sub lnkPrevSi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrevSi.LinkClicked

        If DgLavori.SelectedRows.Count Then
            If MessageBox.Show("Confermi il cambiamento a PREVENTIVO SI dei lavori selezionati?", "Cambia Preventivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                For Each dr As DataGridViewRow In DgLavori.SelectedRows
                    Dim IdOrd As Integer = dr.Cells(1).Value
                    Using O As New Ordine
                        O.Read(IdOrd)
                        O.Preventivo = enSiNo.Si
                        O.Save()
                    End Using
                Next
                CaricaOrdini(_ClienteParam, _ListaIdOrdParam)
            End If
        End If
    End Sub

    Private Sub lnkPrevNo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrevNo.LinkClicked
        If DgLavori.SelectedRows.Count Then
            If MessageBox.Show("Confermi il cambiamento a PREVENTIVO NO dei lavori selezionati?", "Cambia Preventivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                For Each dr As DataGridViewRow In DgLavori.SelectedRows
                    Dim IdOrd As Integer = dr.Cells(1).Value
                    Using O As New Ordine
                        O.Read(IdOrd)
                        O.Preventivo = enSiNo.No
                        O.Save()
                    End Using
                Next
                CaricaOrdini(_ClienteParam, _ListaIdOrdParam)
            End If
        End If
    End Sub
End Class