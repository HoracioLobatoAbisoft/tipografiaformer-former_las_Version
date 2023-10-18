Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmListinoPrezzoLavorazione
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0
    Private _P As PrezzoLavoro = Nothing

    Private Sub CaricaCombo(Optional Duplica As Boolean = False)

        Dim lFmX As List(Of FormatoProdotto) = Nothing
        Using mgr As New FormatiProdottoDAO
            lFmX = mgr.GetAll(LFM.FormatoProdotto.Formato)
        End Using

        Dim fsing As New FormatoProdotto With {.IdFormProd = 0, .Formato = " * - Generico (Dimensioni MEDIE)", .TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Medio}
        lFmX.Add(fsing)

        fsing = New FormatoProdotto With {.IdFormProd = 0, .Formato = " * - Generico (Dimensioni PICCOLE)", .TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo}
        lFmX.Add(fsing)

        fsing = New FormatoProdotto With {.IdFormProd = 0, .Formato = " * - Generico (Dimensioni GRANDI)", .TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande}
        lFmX.Add(fsing)

        lFmX.Sort(Function(x, y) x.Formato.CompareTo(y.Formato))

        'qui devo togliere i formati gia usati

        For Each pl As PrezzoLavoro In _L.Prezzi
            Dim fp As FormatoProdotto = lFmX.Find(Function(x) x.IdFormProd = pl.IdFormProd And x.TipoGrandezzaPrezzo = pl.TipoGrandezza)
            If Not fp Is Nothing Then
                Dim Rimuovi As Boolean = True
                If Duplica = False Then
                    If Not _P Is Nothing Then
                        If fp.IdFormProd = _P.IdFormProd Then
                            Rimuovi = False
                        End If
                    End If
                End If
                If Rimuovi Then lFmX.Remove(fp)
            End If
        Next

        cmbFormatoProdotto.DataSource = lFmX
        cmbFormatoProdotto.ValueMember = "IdFormProd"
        cmbFormatoProdotto.DisplayMember = "Formato"

    End Sub
    Private _L As Lavorazione = Nothing

    Friend Function Carica(L As Lavorazione, ByRef P As PrezzoLavoro, Optional Duplica As Boolean = False) As Integer

        _L = L
        _P = P

        CaricaCombo(Duplica)

        'qui posso ricevere opzionalmente dei valori da duplicare
        If Not P Is Nothing Then

            txtPrezzo.Text = P.Prezzo
            txtPrezzoMin.Text = P.PrezzoMin
            txtPrezzoOltre.Text = P.PrezzoOltre
            txtPezziRif.Text = P.QtaRif

            txtPrezzo2.Text = P.Prezzo2
            txtPrezzoMin2.Text = P.PrezzoMin2
            txtPrezzoOltre2.Text = P.PrezzoOltre2

            If Duplica = False Then
                If P.IdFormProd = 0 Then

                    Dim IdVoce As Integer = 0
                    For Each voce As FormatoProdotto In cmbFormatoProdotto.Items
                        If voce.IdFormProd = 0 And voce.TipoGrandezzaPrezzo = P.TipoGrandezzaPrezzo Then
                            Exit For
                        End If
                        IdVoce += 1
                    Next
                    cmbFormatoProdotto.SelectedIndex = IdVoce
                Else
                    MgrControl.SelectIndexCombo(cmbFormatoProdotto, P.IdFormProd)
                End If
            End If
            If Duplica = False Then cmbFormatoProdotto.Enabled = False

        End If

        If _L.IdTipoLav = enTipoLavorazione.suMetriLineari Then
            txtPrezzoMin.Enabled = False
            txtPrezzoOltre.Enabled = False
        End If

        EsempioPrezzo()
        EsempioPrezzoMin()
        EsempioPrezzoOltre()

        ShowDialog()
        P = _P
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

        If Not cmbFormatoProdotto.SelectedItem Is Nothing Then
            If MessageBox.Show("Confermi i prezzi inseriti?", "Prezzi Lavorazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                'qui devo controllare che non ci sia gia una coppia per quel formato carta e formato macchina 

                Dim Exist As Boolean = False

                ' If _L.Prezzi.FindAll(Function(x) x.IdFormProd = cmbFormatoProdotto.SelectedValue).Count = 0 Then
                'qui ci sono gia combinazioni per questo formato 
                Dim Fp As FormatoProdotto = cmbFormatoProdotto.SelectedItem
                Dim pz As PrezzoLavoro = New PrezzoLavoro
                pz.IdFormProd = Fp.IdFormProd
                pz.Prezzo = txtPrezzo.Text
                pz.IdLavoro = _L.IdLavoro
                pz.PrezzoMin = txtPrezzoMin.Text
                pz.PrezzoOltre = txtPrezzoOltre.Text
                pz.Prezzo2 = txtPrezzo2.Text
                pz.PrezzoMin2 = txtPrezzoMin2.Text
                pz.PrezzoOltre2 = txtPrezzoOltre2.Text
                pz.QtaRif = txtPezziRif.Text
                pz.TipoGrandezza = Fp.TipoGrandezzaPrezzo

                Dim checkOk As Boolean = True

                If (pz.PrezzoMin < pz.Prezzo) Or (pz.Prezzo < pz.PrezzoOltre) Or (pz.PrezzoMin2 < pz.Prezzo2) Or (pz.Prezzo2 < pz.PrezzoOltre2) Then

                    If MessageBox.Show("I prezzi inseriti sembrano incoerenti, confermi l'inserimento?", "Prezzi Lavorazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        checkOk = False
                    End If

                End If

                If checkOk Then
                    If pz.IsValid Then

                        If pz.PrezzoMin = 0 Then pz.PrezzoMin = pz.Prezzo
                        If pz.PrezzoOltre = 0 Then pz.PrezzoOltre = pz.Prezzo

                        If pz.PrezzoMin2 = 0 Then pz.PrezzoMin2 = pz.Prezzo2
                        If pz.PrezzoOltre2 = 0 Then pz.PrezzoOltre2 = pz.Prezzo2

                        _P = pz
                        _Ris = 1
                        Close()
                    Else
                        MessageBox.Show("Inserire tutti i dati obbligatori!", "Prezzi Lavorazione")
                    End If

                End If

                'Else
                '    MessageBox.Show("E' già presente una combinazione di resa per il formato carta e il formato macchina selezionati")
                'End If

            End If
        Else
            MessageBox.Show("Selezionare un formato")
        End If
    End Sub

    Private Sub EsempioPrezzoOltre()
        Dim prezzo As Decimal = CDec(txtPrezzoOltre.Text) * CInt(txtPezziRif.Text)
        lblRisOltre.Text = "(es. " & txtPezziRif.Text & "pz: " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(prezzo) & "€)"
    End Sub

    Private Sub EsempioPrezzo()
        Dim prezzo As Decimal = CDec(txtPrezzo.Text) * CInt(txtPezziRif.Text)
        lblRispz.Text = "(" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(prezzo) & "€)"
    End Sub

    Private Sub EsempioPrezzoMin()
        Dim prezzo As Decimal = CDec(txtPrezzoMin.Text) * CInt(txtPezziRif.Text)
        lblRisMin.Text = "(es. " & txtPezziRif.Text & "pz: " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(prezzo) & "€)"
    End Sub

    Private Sub EsempioPrezzoOltre2()
        Dim prezzo As Decimal = CDec(txtPrezzoOltre2.Text) * CInt(txtPezziRif2.Text)
        lblRisOltre2.Text = "(es. " & txtPezziRif2.Text & "pz: " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(prezzo) & "€)"
    End Sub

    Private Sub EsempioPrezzo2()
        Dim prezzo As Decimal = CDec(txtPrezzo2.Text) * CInt(txtPezziRif2.Text)
        lblRispz2.Text = "(" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(prezzo) & "€)"
    End Sub

    Private Sub EsempioPrezzoMin2()
        Dim prezzo As Decimal = CDec(txtPrezzoMin2.Text) * CInt(txtPezziRif2.Text)
        lblRisMin2.Text = "(es. " & txtPezziRif2.Text & "pz: " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(prezzo) & "€)"
    End Sub

    Private Sub txtPrezzo_TextChanged(sender As Object, e As EventArgs) Handles txtPrezzo.TextChanged
        Try
            EsempioPrezzo()

            If _L.IdTipoLav = enTipoLavorazione.suMetriLineari Then
                txtPrezzoMin.Text = txtPrezzo.Text
                txtPrezzoOltre.Text = txtPrezzo.Text
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrezzoOltre_TextChanged(sender As Object, e As EventArgs) Handles txtPrezzoOltre.TextChanged
        Try
            EsempioPrezzoOltre()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtPrezzoMin_TextChanged(sender As Object, e As EventArgs) Handles txtPrezzoMin.TextChanged
        Try
            EsempioPrezzoMin()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtPezziRif_TextChanged(sender As Object, e As EventArgs) Handles txtPezziRif.TextChanged
        Try
            txtPezziRif2.Text = txtPezziRif.Text
            EsempioPrezzo()
            EsempioPrezzoMin()
            EsempioPrezzoOltre()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtPezziRif2_TextChanged(sender As Object, e As EventArgs) Handles txtPezziRif2.TextChanged
        EsempioPrezzo2()
        EsempioPrezzoMin2()
        EsempioPrezzoOltre2()
    End Sub

    Private Sub txtPrezzoMin2_TextChanged(sender As Object, e As EventArgs) Handles txtPrezzoMin2.TextChanged
        Try
            EsempioPrezzoMin2()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrezzo2_TextChanged(sender As Object, e As EventArgs) Handles txtPrezzo2.TextChanged
        Try
            EsempioPrezzo2()
            If _L.IdTipoLav = enTipoLavorazione.suMetriLineari Then
                txtPrezzoMin2.Text = txtPrezzo2.Text
                txtPrezzoOltre2.Text = txtPrezzo2.Text
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrezzoOltre2_TextChanged(sender As Object, e As EventArgs) Handles txtPrezzoOltre2.TextChanged
        Try
            EsempioPrezzoOltre2()
        Catch ex As Exception

        End Try
    End Sub
End Class