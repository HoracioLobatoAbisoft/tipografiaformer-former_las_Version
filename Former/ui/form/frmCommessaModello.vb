Imports System.IO
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmCommessaModello
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _IdModello As Integer = 0
    Private _M As ModelloCommessa

    Private Sub CaricaCombo()
        Using Mgr As New CatModelliDAO
            cmbCat.DataSource = Mgr.GetAll(LFM.CategoriaModelloCommessa.CatModello)
            cmbCat.ValueMember = "IdCatModello"
            cmbCat.DisplayMember = "CatModello"
        End Using

        Using M As New MacchinariDAO
            cmbMacchinarioProduz.ValueMember = "IdMacchinario"
            cmbMacchinarioProduz.DisplayMember = "Descrizione"
            cmbMacchinarioProduz.DataSource = M.FindAll(LFM.Macchinario.Descrizione,
                                                        New LUNA.LunaSearchParameter(LFM.Macchinario.Tipo, enTipoMacchinario.Produzione))
        End Using

        Using M As New MacchinariDAO
            cmbMacchinarioTaglio.ValueMember = "IdMacchinario"
            cmbMacchinarioTaglio.DisplayMember = "Descrizione"
            cmbMacchinarioTaglio.DataSource = M.FindAll(New LUNA.LunaSearchOption With {.OrderBy = LFM.Macchinario.Descrizione.Name, .AddEmptyItem = True},
                                                        New LUNA.LunaSearchParameter(LFM.Macchinario.Tipo, enTipoMacchinario.Allestimento))
        End Using

        Dim lstFM As List(Of Formato) = Nothing
        Using Mgr As New FormatiDAO
            lstFM = Mgr.GetAll(LFM.Formato.Formato)
        End Using

        cmbFormatoMacchina.ValueMember = "IdFormato"
        cmbFormatoMacchina.DisplayMember = "Formato"
        cmbFormatoMacchina.DataSource = lstFM

        Dim Stati() As FormerLib.FormerEnum.enRepartoWeb = [Enum].GetValues(GetType(enRepartoWeb))
        Dim l As New List(Of cEnum)
        Dim P As cEnum = Nothing
        For Each reparto As enRepartoWeb In Stati

            If reparto > enRepartoWeb.Tutto Then

                P = New FormerLib.cEnum
                P.Id = reparto
                P.Descrizione = FormerEnumHelper.RepartoStr(reparto)
                l.Add(P)

            End If

        Next
        cmbReparto.DisplayMember = "Descrizione"
        cmbReparto.ValueMember = "Id"
        cmbReparto.DataSource = l

    End Sub

    Friend Function Carica(Optional IdModello As Integer = 0) As Integer
        _IdModello = IdModello
        CaricaCombo()
        If _IdModello Then
            'caricamento
            _M = New ModelloCommessa
            _M.Read(_IdModello)
            txtNome.Text = _M.Nome
            txtAnteF.Text = _M.Anteprima
            txtAnteR.Text = _M.AnteprimaR
            txtPDF.Text = _M.PDF
            txtFileJob.Text = _M.Job
            txtFileJDF.Text = _M.FileJDP
            txtMinGiroTaglio.Text = _M.MinGiroTaglio
            txtDescr.Text = _M.Descrizione
            txtNumSpazi.Text = _M.NumSpazi
            txtTiraturaIdeale.Text = _M.TiraturaIdeale
            MgrControl.SelectIndexCombo(cmbCat, _M.IdCatModello)
            MgrControl.SelectIndexCombo(cmbFormatoMacchina, _M.IdFormatoMacchina)
            MgrControl.SelectIndexCombo(cmbMacchinarioProduz, _M.IdMacchinarioDef)
            MgrControl.SelectIndexCombo(cmbMacchinarioTaglio, _M.IdMacchinarioTaglioDef)
            MgrControl.SelectIndexComboEnum(cmbReparto, _M.IdReparto)
            chkDisattiva.Checked = IIf(_M.Disattivo = enSiNo.Si, True, False)
            If _M.AbilitatoAutomazione = enSiNo.Si Then chkAbilitatoCreazAutomat.Checked = True

            If _M.RitieniOkDuplicati = enSiNo.Si Then chkRitieniOkDuplicazioni.Checked = True

            If _M.IdReparto <> enRepartoWeb.StampaOffset Then
                chkAbilitatoCreazAutomat.Checked = True
                chkAbilitatoCreazAutomat.Enabled = False
            End If

            If _M.FronteRetro Then rdoFronteRetro.Checked = True
            If _M.FRSuSeStessa Then chkFRSeStessa.Checked = True

            CaricaFormatiProdotto()
            Try
                pctAnteF.Image = Image.FromFile(txtAnteF.Text)
            Catch ex As Exception

            End Try
            Try
                pctAnteR.Image = Image.FromFile(txtAnteR.Text)
            Catch ex As Exception

            End Try

            Me.Text &= " - " & IdModello
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaFormatiProdotto()
        dgFormatiProdotto.DataSource = Nothing
        dgFormatiProdotto.Refresh()
        dgFormatiProdotto.AutoGenerateColumns = False
        dgFormatiProdotto.DataSource = _M.FormatiProdotto
        dgFormatiProdotto.Refresh()
        CalcolaSpazi()
    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnAnte_Click(sender As Object, e As EventArgs) Handles btnAnteF.Click

        dlgFile.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        If dlgFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtAnteF.Text = dlgFile.FileName
            Try
                pctAnteF.Image = Image.FromFile(txtAnteF.Text)
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private ModificataAnteprima As Boolean = False

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If MessageBox.Show("Confermi il salvataggio?", , MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim TuttoOkAnteprima As Boolean = True
                If ModificataAnteprima And 1 = 0 Then 'per ora disabilito la creazione dell'anteprima 
                    'rigenero anteprima 
                    Dim NewVal As String = txtPDF.Text
                    Dim NumPag As Integer = FormerHelper.PDF.GetNumeroPagine(NewVal)
                    Dim NomeAnteprimaF As String = FormerConfig.FormerPath.PathTemplatePreps & Path.GetFileNameWithoutExtension(NewVal) & ".F.jpg"

                    Try
                        If FileIO.FileSystem.FileExists(NewVal) Then
                            If NewVal.EndsWith("pdf") Then
                                FormerHelper.PDF.GetPdfThumbnail(NewVal, NomeAnteprimaF)
                            End If
                            txtAnteF.Text = NomeAnteprimaF
                        End If
                    Catch ex As Exception
                        'qui c'è stato un errore nella creazione dell'anteprima
                        'metto un file temporaneo e poi vediamo
                        MessageBox.Show("Si è verificato un errore nella creazione automatica dell'anteprima del modello PDF FRONTE: " & ex.Message)
                        TuttoOkAnteprima = False
                    End Try
                    If NumPag = 2 AndAlso rdoFronteRetro.Checked = True Then
                        Dim NomeAnteprimaR As String = FormerConfig.FormerPath.PathTemplatePreps & Path.GetFileNameWithoutExtension(NewVal) & ".R.jpg"
                        Try
                            If FileIO.FileSystem.FileExists(NewVal) Then
                                If NewVal.EndsWith("pdf") Then
                                    FormerHelper.PDF.GetPdfThumbnail(NewVal, NomeAnteprimaR)
                                End If
                                txtAnteR.Text = NomeAnteprimaR
                            End If
                        Catch ex As Exception
                            'qui c'è stato un errore nella creazione dell'anteprima
                            'metto un file temporaneo e poi vediamo
                            MessageBox.Show("Si è verificato un errore nella creazione automatica dell'anteprima del modello PDF RETRO: " & ex.Message)
                            TuttoOkAnteprima = False
                        End Try
                    Else
                        txtAnteR.Text = String.Empty
                    End If

                End If

                Dim SalvaModello As Boolean = True
                If TuttoOkAnteprima = False Then
                    If MessageBox.Show("Si è verificato un errore nella creazione dell'anteprima. Vuoi comunque salvare il modello?", "Salva Modello", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        SalvaModello = False
                    End If
                End If

                If SalvaModello Then
                    Using M As New ModelloCommessa
                        If _IdModello Then M.Read(_IdModello)
                        M.Nome = txtNome.Text
                        M.Anteprima = txtAnteF.Text
                        M.AnteprimaR = txtAnteR.Text
                        M.PDF = txtPDF.Text
                        M.Job = txtFileJob.Text
                        M.FileJDP = txtFileJDF.Text
                        M.IdCatModello = cmbCat.SelectedValue
                        M.Descrizione = txtDescr.Text
                        M.NumSpazi = txtNumSpazi.Text
                        M.IdFormatoMacchina = cmbFormatoMacchina.SelectedValue
                        M.IdMacchinarioDef = cmbMacchinarioProduz.SelectedValue
                        M.IdMacchinarioTaglioDef = cmbMacchinarioTaglio.SelectedValue
                        M.MinGiroTaglio = txtMinGiroTaglio.Text
                        M.FronteRetro = IIf(rdoSoloFronte.Checked, enSiNo.No, enSiNo.Si)
                        M.FRSuSeStessa = IIf(chkFRSeStessa.Checked, enSiNo.Si, enSiNo.No)
                        M.AbilitatoAutomazione = IIf(chkAbilitatoCreazAutomat.Checked, enSiNo.Si, enSiNo.No)
                        M.RitieniOkDuplicati = IIf(chkRitieniOkDuplicazioni.Checked, enSiNo.Si, enSiNo.No)
                        Dim repartoSel As cEnum = cmbReparto.SelectedItem
                        M.IdReparto = repartoSel.Id
                        M.TiraturaIdeale = txtTiraturaIdeale.Text
                        M.Disattivo = IIf(chkDisattiva.Checked, enSiNo.Si, enSiNo.No)
                        M.FormatiProdotto.Clear()

                        For Each rig As DataGridViewRow In dgFormatiProdotto.Rows
                            M.FormatiProdotto.Add(rig.DataBoundItem)
                        Next

                        If M.IsValid Then
                            M.Save()
                            _Ris = 1
                            Close()
                        Else
                            MessageBox.Show("Tutti i campi sono obbligatori!")
                        End If
                    End Using
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub btnJob_Click(sender As Object, e As EventArgs) Handles btnJob.Click
        dlgFile.Filter = "File JOB|*.job"
        dlgFile.InitialDirectory = FormerConfig.FormerPath.PathTemplatePreps
        If dlgFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFileJob.Text = dlgFile.FileName

        End If
    End Sub

    Private Sub txtNumSpazi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumSpazi.KeyPress
        MgrControl.ControlloNumerico(sender, e, True)
    End Sub

    Private Sub btnAnteR_Click(sender As Object, e As EventArgs) Handles btnAnteR.Click
        dlgFile.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        If dlgFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtAnteR.Text = dlgFile.FileName
            Try
                pctAnteR.Image = Image.FromFile(txtAnteR.Text)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        dlgFile.Filter = "File PDF|*.pdf"
        dlgFile.InitialDirectory = FormerConfig.FormerPath.PathTemplatePreps

        If dlgFile.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim OldVal As String = txtPDF.Text
            Dim NewVal As String = dlgFile.FileName

            txtPDF.Text = NewVal

            If OldVal <> NewVal Then
                ModificataAnteprima = True
            End If

        End If

    End Sub

    Private Sub pctShell3_Click(sender As Object, e As EventArgs) Handles pctShell3.Click
        Anteprima(txtFileJob.Text)
    End Sub

    Private Sub Anteprima(Path As String)

        Try

            Dim PathMOd As String = Path

            Dim x As New Process

            x.StartInfo.FileName = PathMOd
            x.Start()
        Catch ex As Exception

            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub pctShell2_Click(sender As Object, e As EventArgs) Handles pctShell2.Click
        Anteprima(txtPDF.Text)
    End Sub

    Private Sub pctShell1_Click(sender As Object, e As EventArgs) Handles pctShell1.Click
        Anteprima(txtAnteR.Text)
    End Sub

    Private Sub pctShell_Click(sender As Object, e As EventArgs) Handles pctShell.Click
        Anteprima(txtAnteF.Text)
    End Sub

    Private Sub pctAnteF_Click(sender As Object, e As EventArgs) Handles pctAnteF.Click
        If txtAnteF.Text.Length Then
            Anteprima(txtAnteF.Text)
        End If
    End Sub

    Private Sub pctAnteR_Click(sender As Object, e As EventArgs) Handles pctAnteR.Click
        If txtAnteR.Text.Length Then
            Anteprima(txtAnteR.Text)
        End If
    End Sub

    Private Sub CalcolaSpazi()

        Dim NumSpazi As Integer = 0
        For Each dg As DataGridViewRow In dgFormatiProdotto.Rows
            NumSpazi += dg.Cells(2).Value
        Next
        If NumSpazi Then txtNumSpazi.Text = NumSpazi
    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        Dim NuovaCat As String = InputBox("Inserisci il nome della nuova categoria di modelli che vuoi creare:", "Nuova Categoria di Modelli")

        If NuovaCat.Trim.Length Then

            Dim L As List(Of CategoriaModelloCommessa) = Nothing
            Using mgr As New CatModelliDAO
                L = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CategoriaModelloCommessa.CatModello, NuovaCat))
            End Using
            If L.Count = 0 Then
                Dim c As New CategoriaModelloCommessa
                c.CatModello = NuovaCat
                c.Save()
                CaricaCombo()
            Else
                MessageBox.Show("Categoria di Modello gia presente! Selezionarla dalla lista.", , MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

    End Sub

    Private Sub lnkRimuovi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRimuovi.LinkClicked
        If dgFormatiProdotto.SelectedRows.Count Then
            Dim f As ModComFormProd = dgFormatiProdotto.SelectedRows(0).DataBoundItem
            _M.FormatiProdotto.Remove(f)
        End If

        CaricaFormatiProdotto()

    End Sub

    Private Sub lnkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAdd.LinkClicked

        If _M Is Nothing Then
            MessageBox.Show("Salvare prima il modello per aggiungere formati all'interno")
        Else

            Sottofondo()

            Dim f As New frmFormatoProdsuModCom
            Dim fp As ModComFormProd = Nothing

            Dim l As List(Of ModComFormProd) = Nothing
            If Not _M Is Nothing Then
                l = _M.FormatiProdotto
            Else
                l = New List(Of ModComFormProd)
            End If

            Dim Ris As Integer = f.Carica(_IdModello, l, fp)

            If Not fp Is Nothing Then
                _M.FormatiProdotto.Add(fp)
                CaricaFormatiProdotto()

            End If

            Sottofondo()

        End If

    End Sub

    Private Sub rdoFronteRetro_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFronteRetro.CheckedChanged
        If rdoFronteRetro.Checked Then
            chkFRSeStessa.Enabled = True
        End If
    End Sub

    Private Sub rdoSoloFronte_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSoloFronte.CheckedChanged
        If rdoSoloFronte.Checked Then
            chkFRSeStessa.Enabled = False
            chkFRSeStessa.Checked = False
        End If
    End Sub

    Private Sub lnkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEdit.LinkClicked
        If dgFormatiProdotto.SelectedRows.Count Then

            Dim f As New frmFormatoProdsuModCom
            Dim fp As ModComFormProd = dgFormatiProdotto.SelectedRows(0).DataBoundItem

            Dim l As List(Of ModComFormProd) = Nothing
            If Not _M Is Nothing Then
                l = _M.FormatiProdotto
            Else
                l = New List(Of ModComFormProd)
            End If

            'dgFormatiProdotto.BeginEdit(False)

            Sottofondo()
            Dim Ris As Integer = f.Carica(_IdModello, l, fp)
            Sottofondo()

            If Ris Then
                If Not fp Is Nothing Then
                    '       dgFormatiProdotto.RefreshEdit()
                    'dgFormatiProdotto.Refresh()
                    'dgFormatiProdotto.EndEdit()
                    CaricaFormatiProdotto()
                End If
            End If
        End If
    End Sub

    Private Sub pctShell4_Click(sender As Object, e As EventArgs) Handles pctShell4.Click
        Anteprima(txtFileJDF.Text)
    End Sub

    Private Sub btnJdf_Click(sender As Object, e As EventArgs) Handles btnJdf.Click
        dlgFile.Filter = "File JDF|*.jdf"
        dlgFile.InitialDirectory = FormerConfig.FormerPath.PathTemplatePreps
        If dlgFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFileJDF.Text = dlgFile.FileName
        End If
    End Sub

    Private Sub pctGenera_Click(sender As Object, e As EventArgs) Handles pctGeneraFronte.Click

        If MessageBox.Show("Vuoi rigenerare automaticamente l'anteprima del PDF Fronte?", "Generazione anteprima", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            If _IdModello Then
                MgrUDP.AnteprimaModelloCommessa(_IdModello, enFronteRetro.Fronte)

                MessageBox.Show("Richiesta rigenerazione anteprima modello commessa al Demone")

            Else
                MessageBox.Show("Prima di richiedere la generazione dell'anteprima salvare il modello commessa")
            End If


            'Dim NewVal As String = txtPDF.Text
            'Dim NomeAnteprimaF As String = FormerConfig.FormerPath.PathTemplatePreps & Path.GetFileNameWithoutExtension(NewVal) & ".F.jpg"

            'Try
            '    If FileIO.FileSystem.FileExists(NewVal) Then
            '        If NewVal.EndsWith("pdf") Then
            '            FormerHelper.PDF.GetPdfThumbnail(NewVal, NomeAnteprimaF)
            '        End If
            '        txtAnteF.Text = NomeAnteprimaF
            '    End If
            'Catch ex As Exception
            '    'qui c'è stato un errore nella creazione dell'anteprima
            '    'metto un file temporaneo e poi vediamo
            '    MessageBox.Show("Si è verificato un errore nella creazione automatica dell'anteprima del modello PDF FRONTE: " & ex.Message)
            '    'TuttoOkAnteprima = False
            'End Try

        End If

    End Sub

    Private Sub pctGeneraRetro_Click(sender As Object, e As EventArgs) Handles pctGeneraRetro.Click
        If MessageBox.Show("Vuoi rigenerare automaticamente l'anteprima del PDF Retro?", "Generazione anteprima", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim NewVal As String = txtPDF.Text
            Dim NomeAnteprimaF As String = FormerConfig.FormerPath.PathTemplatePreps & Path.GetFileNameWithoutExtension(NewVal) & ".R.jpg"
            Dim NumPag As Integer = FormerHelper.PDF.GetNumeroPagine(NewVal)

            If NumPag = 2 Then

                If _IdModello Then
                    MgrUDP.AnteprimaModelloCommessa(_IdModello, enFronteRetro.Retro)

                    MessageBox.Show("Richiesta rigenerazione anteprima modello commessa al Demone")

                Else
                    MessageBox.Show("Prima di richiedere la generazione dell'anteprima salvare il modello commessa")
                End If


                'Try
                '    If FileIO.FileSystem.FileExists(NewVal) Then
                '        If NewVal.EndsWith("pdf") Then
                '            FormerHelper.PDF.GetPdfThumbnail(NewVal, NomeAnteprimaF,, 2)
                '        End If
                '        txtAnteR.Text = NomeAnteprimaF
                '    End If
                'Catch ex As Exception
                '    'qui c'è stato un errore nella creazione dell'anteprima
                '    'metto un file temporaneo e poi vediamo
                '    MessageBox.Show("Si è verificato un errore nella creazione automatica dell'anteprima del modello PDF RETRO: " & ex.Message)
                '    'TuttoOkAnteprima = False
                'End Try
            Else
                MessageBox.Show("Nel file PDF del modello è presente solo una pagina")
            End If

        End If
    End Sub

    Private Sub pctDelAnteprimaF_Click(sender As Object, e As EventArgs) Handles pctDelAnteprimaF.Click
        txtAnteF.Text = String.Empty
    End Sub

    Private Sub pctDelAnteprimaR_Click(sender As Object, e As EventArgs) Handles pctDelAnteprimaR.Click
        txtAnteR.Text = String.Empty
    End Sub

End Class