Imports FormerDALSql
Imports System.IO
Imports FormerLib
Imports FormerConfig
Imports FormerLib.FormerEnum

Friend Class frmListinoFormatoMacchina
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _FormatoMacchina As New Formato

    Private Sub CaricaCombo()
        Using M As New MacchinariDAO

            cmbMacchinari.ValueMember = "IdMacchinario"
            cmbMacchinari.DisplayMember = "Descrizione"
            cmbMacchinari.DataSource = M.GetAll(LFM.Macchinario.Descrizione)
        End Using
    End Sub

    Private Sub CaricaMacchinari(IdFormatoMacchina As Integer)
        Using MgrCarat As New MacchinariDAO()
            Dim LstCarat As List(Of Macchinario) = MgrCarat.FindAll(LFM.Macchinario.Descrizione,
                                                                    New LUNA.LunaSearchParameter(LFM.Macchinario.Tipo, enTipoMacchinario.Produzione))

            For Each caratt As Macchinario In LstCarat
                Dim Selezionato As Boolean = False

                If IdFormatoMacchina Then
                    Using Mgr As New FormatiSuMacchinariDAO
                        Dim Par1 As New LUNA.LunaSearchParameter(LFM.FormatoSuMacchinario.IdFormato, IdFormatoMacchina)
                        Dim Par2 As New LUNA.LunaSearchParameter(LFM.FormatoSuMacchinario.IdMacchinario, caratt.IdMacchinario)
                        Dim NumTrov As Integer = Mgr.FindAll(Par1, Par2).Count
                        If NumTrov Then Selezionato = True
                    End Using

                End If

                chkMacchinari.Items.Add(caratt, Selezionato)

            Next
        End Using
    End Sub

    Friend Function Carica(Optional ByVal IdFormatoMacchina As Integer = 0,
                           Optional ByVal IdMacchinario As Integer = 0) As Integer

        CaricaCombo()

        CaricaMacchinari(IdFormatoMacchina)

        If IdFormatoMacchina Then

            _FormatoMacchina.Read(IdFormatoMacchina)
            txtFormato.Text = _FormatoMacchina.Formato
            txtDivisioneFoglio.Text = _FormatoMacchina.DivisioneFoglio
            txtLunghezza.Text = _FormatoMacchina.Altezza
            txtLarghezza.Text = _FormatoMacchina.Larghezza
            txtCostoLastra.Text = _FormatoMacchina.CostoLastra
            MgrControl.SelectIndexCombo(cmbMacchinari, _FormatoMacchina.IdMacchinario)
            txtImgLav.Text = _FormatoMacchina.ImgRif

            UcListinoImpatto.CalcolaSuFormatoMacchina(IdFormatoMacchina)

            If txtImgLav.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImgLav.Text)
                Catch ex As Exception

                End Try
            End If
        Else
            For i As Integer = 0 To chkMacchinari.Items.Count - 1

                Dim Voce As Macchinario = chkMacchinari.Items(i)

                If Voce.IdMacchinario = IdMacchinario Then
                    chkMacchinari.SetItemChecked(i, True)
                End If

            Next
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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _FormatoMacchina.Formato = txtFormato.Text
            '_FormatoMacchina.DivisioneFoglio = txtDivisioneFoglio.Text
            _FormatoMacchina.Altezza = txtLunghezza.Text
            _FormatoMacchina.Larghezza = txtLarghezza.Text
            _FormatoMacchina.CostoLastra = txtCostoLastra.Text
            '_FormatoMacchina.IdMacchinario = cmbMacchinari.SelectedValue

            If _FormatoMacchina.IsValid Then

                'copio l'immagine nella cartella centralizzata
                If txtImgLav.Text.Length Then
                    If txtImgLav.Text <> _FormatoMacchina.ImgRif Then
                        Dim F As New FileInfo(txtImgLav.Text)
                        Dim nuovoNome As String = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLav.Text))

                        MgrIO.FileCopia(Me, txtImgLav.Text, nuovoNome)

                        _FormatoMacchina.ImgRif = nuovoNome
                    End If

                End If

                _FormatoMacchina.Save()

                Using mgr As New FormatiSuMacchinariDAO
                    mgr.DeleteByIdFormato(_FormatoMacchina.IdFormato)
                End Using

                For Each voce In chkMacchinari.CheckedItems

                    Using link As New FormatoSuMacchinario
                        link.IdFormato = _FormatoMacchina.IdFormato
                        link.IdMacchinario = voce.IdMacchinario
                        link.Save()
                    End Using

                Next

                _Ris = 1
                Close()

            Else
                MessageBox.Show("Inserisci tutti i dati richiesti.", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgLav.Text = OpenFileImg.FileName
            pctImgLav.Image = Image.FromFile(txtImgLav.Text)
        End If
    End Sub

    Private Sub btmMacch_Click(sender As Object, e As EventArgs) Handles btmMacch.Click
        Sottofondo()
        Dim x As New frmListinoMacchinario

        Dim OldValue As Integer = cmbMacchinari.SelectedValue
        If x.Carica(OldValue) Then
            CaricaCombo()
            MgrControl.SelectIndexCombo(cmbMacchinari, OldValue)
        End If

        x = Nothing
        Sottofondo()

    End Sub
End Class