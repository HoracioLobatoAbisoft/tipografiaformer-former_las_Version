Imports FormerLib

Friend Class frmListinoManageExtraData
    'Inherits baseFormInternaFixed

    Private _Ris As String
    Private _LSel As List(Of ExtraData) = Nothing

    Private Sub CaricaListe()
        DgExtraSel.DataSource = Nothing
        DgExtraSel.AutoGenerateColumns = False
        DgExtraSel.DataSource = _LSel
        DgExtraSel.AutoGenerateColumns = False

        Dim lDisp As List(Of ExtraData) = MgrExtraData.GetAll()
        Dim lDispEx As New List(Of ExtraData)
        For Each ed In lDisp
            If _LSel.FindAll(Function(x) x.Chiave = ed.Chiave).Count = 0 Then
                lDispEx.Add(ed)
            End If
        Next
        DgExtraDisp.DataSource = Nothing
        DgExtraDisp.AutoGenerateColumns = False
        DgExtraDisp.DataSource = lDispEx
        DgExtraDisp.AutoGenerateColumns = False
    End Sub
    Friend Function Carica(BufferExtraData As String) As String

        If BufferExtraData.Length Then
            _LSel = MgrExtraData.GetExtraData(BufferExtraData)
        Else
            _LSel = New List(Of ExtraData)
        End If

        CaricaListe()

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio degli ExtraData?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            _Ris = GetNewBuffer
            '_Ris = nuovobuffer
            Close()

        End If
    End Sub

    Private Sub ModificaSel()
        If DgExtraSel.SelectedRows.Count Then
            Dim row As DataGridViewRow = DgExtraSel.SelectedRows(0)
            Dim ed As ExtraData = row.DataBoundItem
            Dim Indicazioni As String = ed.TipoStr

            Dim NuovoValore As String = InputBox("Inserisci il valore per questo extradata. Il tipo di riferimento è: " & Indicazioni, "Modifica Extra Data", ed.Valore)

            If NuovoValore.Length Then
                'qui devo validare il risultato 
                Try
                    Dim NuovoValoreTipizzato = Nothing

                    If ed.Tipo = GetType(String) Then
                        'qui nn devo fare nulla , lo tengo solo per futura memoria

                    ElseIf ed.Tipo = GetType(Integer) Then
                        Try
                            NuovoValoreTipizzato = CInt(NuovoValore)
                        Catch ex As Exception

                        End Try
                    ElseIf ed.Tipo.BaseType = GetType(System.enum) Then

                        If [Enum].IsDefined(ed.Tipo, CInt(NuovoValore)) Then
                            NuovoValoreTipizzato = CInt(NuovoValore)
                        Else
                            Dim items = System.Enum.GetValues(ed.Tipo)
                            Dim item As String
                            For Each item In items
                                Dim Descrizione As String = String.Empty
                                Descrizione = [Enum].ToObject(ed.Tipo, CInt(item)).ToString()
                                Indicazioni &= ControlChars.NewLine & Descrizione & ": " & item
                            Next
                        End If
                    End If
                    If NuovoValoreTipizzato Is Nothing Then
                        MessageBox.Show("Valore non valido: " & Indicazioni)
                    Else
                        'qui devo andare a modificare il valore dentro la voce in griglia
                        ed.Valore = NuovoValoreTipizzato
                        DgExtraSel.Refresh()
                    End If
                Catch ex As Exception

                    If ed.Tipo.BaseType = GetType(System.Enum) Then
                        Dim items = System.Enum.GetValues(ed.Tipo)
                        Dim item As String
                        For Each item In items
                            Dim Descrizione As String = String.Empty
                            Descrizione = [Enum].ToObject(ed.Tipo, CInt(item)).ToString()
                            Indicazioni &= ControlChars.NewLine & Descrizione & ": " & item
                        Next
                    End If

                    MessageBox.Show("Valore non valido: " & Indicazioni)
                End Try
            End If

        Else
            Beep()
        End If
    End Sub

    Private Sub Rimuovi()
        If DgExtraSel.SelectedRows.Count Then
            Dim row As DataGridViewRow = DgExtraSel.SelectedRows(0)
            Dim ed As ExtraData = row.DataBoundItem
            _LSel.Remove(ed)
            CaricaListe()
        End If
    End Sub

    Private Sub Aggiungi()
        If DgExtraDisp.SelectedRows.Count Then
            Dim row As DataGridViewRow = DgExtraDisp.SelectedRows(0)
            Dim ed As ExtraData = row.DataBoundItem
            Dim Indicazioni As String = ed.TipoStr

            Dim NuovoValore As String = InputBox("Inserisci il valore per questo extradata. Il tipo di riferimento è: " & Indicazioni, "Modifica Extra Data", ed.Valore)

            If NuovoValore.Length Then
                'qui devo validare il risultato 
                Try
                    Dim NuovoValoreTipizzato = Nothing

                    If ed.Tipo = GetType(String) Then
                        'qui nn devo fare nulla , lo tengo solo per futura memoria
                        NuovoValoreTipizzato = NuovoValore
                    ElseIf ed.Tipo = GetType(Integer) Then
                        Try
                            NuovoValoreTipizzato = CInt(NuovoValore)
                        Catch ex As Exception

                        End Try
                    ElseIf ed.Tipo.BaseType = GetType(System.Enum) Then

                        If [Enum].IsDefined(ed.Tipo, CInt(NuovoValore)) Then
                            NuovoValoreTipizzato = CInt(NuovoValore)
                        Else
                            Dim items = System.Enum.GetValues(ed.Tipo)
                            Dim item As String
                            For Each item In items
                                Dim Descrizione As String = String.Empty
                                Descrizione = [Enum].ToObject(ed.Tipo, CInt(item)).ToString()
                                Indicazioni &= ControlChars.NewLine & Descrizione & ": " & item
                            Next
                        End If
                    End If
                    If NuovoValoreTipizzato Is Nothing Then
                        MessageBox.Show("Valore non valido: " & Indicazioni)
                    Else
                        'qui devo andare a modificare il valore dentro la voce in griglia
                        ed.Valore = NuovoValoreTipizzato

                        _LSel.Add(ed)
                        CaricaListe()
                    End If
                Catch ex As Exception

                    If ed.Tipo.BaseType = GetType(System.Enum) Then
                        Dim items = System.Enum.GetValues(ed.Tipo)
                        Dim item As String
                        For Each item In items
                            Dim Descrizione As String = String.Empty
                            Descrizione = [Enum].ToObject(ed.Tipo, CInt(item)).ToString()
                            Indicazioni &= ControlChars.NewLine & Descrizione & ": " & item
                        Next
                    End If

                    MessageBox.Show("Valore non valido: " & Indicazioni)
                End Try
            End If

        Else
            Beep()
        End If
    End Sub

    Private Function GetNewBuffer() As String
        Dim ris As String = String.Empty

        If DgExtraSel.Rows.Count Then
            For Each row In DgExtraSel.Rows
                Dim ed As ExtraData = row.databounditem
                ris &= ed.Chiave & ":" & ed.Valore & ";"
            Next
        End If
        If ris.Length Then ris = ris.TrimEnd(";")
        Return ris
    End Function

    Private Sub btnModifica_Click(sender As Object, e As EventArgs) Handles btnModifica.Click
        ModificaSel()
    End Sub

    Private Sub DgExtraSel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgExtraSel.CellContentClick

    End Sub

    Private Sub DgExtraSel_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgExtraSel.CellContentDoubleClick

    End Sub

    Private Sub btnAggiungi_Click(sender As Object, e As EventArgs) Handles btnAggiungi.Click
        Aggiungi()
    End Sub

    Private Sub btnRimuovi_Click(sender As Object, e As EventArgs) Handles btnRimuovi.Click
        Rimuovi()

    End Sub

    Private Sub DgExtraSel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgExtraSel.CellDoubleClick
        ModificaSel()

    End Sub
End Class