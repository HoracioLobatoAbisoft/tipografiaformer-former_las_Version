Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerBusinessLogic
Imports FormerConfig

Friend Class frmMarketingFiltro
    'Inherits baseFormInternaRedim

    Private _Ris As Integer

    Private _FM As FiltroMarketing = Nothing

    Private Sub CaricaCombo()

        Dim LTipoFiltro As New List(Of cEnum)
        Dim voce As New cEnum
        voce.Id = enTipoFiltroMarketing.SuListiniBase
        voce.Descrizione = "Email con Listini Base selezionati"
        LTipoFiltro.Add(voce)

        voce = New cEnum
        voce.Id = enTipoFiltroMarketing.SuFileHtml
        voce.Descrizione = "Email da file HTML preconfezionato"
        LTipoFiltro.Add(voce)

        'voce = New cEnum
        'voce.Id = enTipoFiltroMarketing.SuTemplateFormer
        'voce.Descrizione = "Email da Template Former"
        'LOrig.Add(voce)

        cmbTipoFiltro.DataSource = LTipoFiltro
        cmbTipoFiltro.DisplayMember = "Descrizione"
        cmbTipoFiltro.ValueMember = "Id"

        cmbTipoFiltro.SelectedIndex = 0

        CaricaGruppi()

    End Sub

    Private Sub CaricaGruppi()
        Using mgr As New GruppiDAO
            Dim lG As List(Of Gruppo) = mgr.GetAll(LFM.Gruppo.Nome, True)
            cmbGruppoContatti.DataSource = lG
            cmbGruppoContatti.DisplayMember = "Nome"
            cmbGruppoContatti.ValueMember = "IdGruppo"
        End Using
    End Sub

    Private _TipoFiltro As enTipoFiltroMarketing = enTipoFiltroMarketing.SuListiniBase

    Friend Function Carica(TipoFiltro As enTipoFiltroMarketing,
                           Optional IdFiltro As Integer = 0) As Integer
        _TipoFiltro = TipoFiltro

        CaricaCombo()

        MgrControl.SelectIndexComboEnum(cmbTipoFiltro, TipoFiltro)

        cmbTipoFiltro.Enabled = False

        _FM = New FiltroMarketing
        If IdFiltro Then
            _FM.Read(IdFiltro)
            'qui precarico le voci per ora solo il nome
            txtNome.Text = _FM.Nome

            If _FM.IdGruppo Then MgrControl.SelectIndexCombo(cmbGruppoContatti, _FM.IdGruppo)

            ''PRINCIPALE
            'If _FM.CategoriaMarketing Then
            '    chkCatMark.Checked = True
            '    MgrControl.SelectIndexCombo(cmbCatMark, _FM.CategoriaMarketing)
            'End If

            'If _FM.Tipo Then
            '    chkTipo.Checked = True
            '    MgrControl.SelectIndexCombo(cmbTipo, _FM.Tipo)
            'End If

            'If _FM.TipoOrigine Then
            '    chkOrigine.Checked = True
            '    MgrControl.SelectIndexCombo(cmbOrigine, _FM.TipoOrigine)
            'End If

            'If _FM.Citta.Length Then
            '    chkCitta.Checked = True
            '    txtCitta.Text = _FM.Citta
            'End If

            'If _FM.Cap.Length Then
            '    txtCAP.Text = _FM.Cap
            '    chkCap.Checked = True
            'End If

            'If _FM.InseritiDa Then
            '    chkInseritiDa.Checked = True
            '    MgrControl.SelectIndexCombo(cmbInseritiDa, _FM.InseritiDa)
            'End If

            'If _FM.HannoAcqAlmenoUn Then
            '    chkHannoAcquistatoUn.Checked = True
            '    MgrControl.SelectIndexCombo(cmbCatProdAcq, _FM.HannoAcqAlmenoUn)
            'End If

            'If _FM.NonHannoMaiAcqUn Then
            '    chkNonHannoAcquistatoUn.Checked = True
            '    MgrControl.SelectIndexCombo(cmbCatProdNonAcq, _FM.NonHannoMaiAcqUn)
            'End If

            'If _FM.NonHannoMaiSpeso = enSiNo.Si Then
            '    chkNonHannoMaiSpeso.Checked = True
            'End If

            'If _FM.SpesaNelPeriodoMinoreDi Then
            '    chkSpesaMinDi.Checked = True
            '    txtSpesaMinDi.Text = _FM.SpesaNelPeriodoMinoreDi
            'End If

            'If _FM.SpesaNelPeriodoMaggioreDi Then
            '    chkSpesaMaxDi.Checked = True
            '    txtSpesaMaxDi.Text = _FM.SpesaNelPeriodoMaggioreDi
            'End If

            'If chkSpesaMinDi.Checked Or chkSpesaMaxDi.Checked Then MgrControl.SelectIndexComboEnum(cmbPeriodoSpesa, _FM.SpesaNelPeriodo)

            'If _FM.tag.Length Then
            '    txtTag.Text = _FM.tag
            '    chkTag.Checked = True
            'End If

            If _FM.Ricorsiva Then chkRicorsiva.Checked = True

            If _FM.chkGennaio Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkGennaio)
                        txt01.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkGennaio)
                    txt01.Text = F.Riassunto
                End If
            End If

            If _FM.chkFebbraio Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkFebbraio)
                        txt02.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkFebbraio)
                    txt02.Text = F.Riassunto
                End If
            End If

            If _FM.chkMarzo Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkMarzo)
                        txt03.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkMarzo)
                    txt03.Text = F.Riassunto
                End If
            End If

            If _FM.chkAprile Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkAprile)
                        txt04.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkAprile)
                    txt04.Text = F.Riassunto
                End If
            End If

            If _FM.chkMaggio Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkMaggio)
                        txt05.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkMaggio)
                    txt05.Text = F.Riassunto
                End If
            End If

            If _FM.chkGiugno Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkGiugno)
                        txt06.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkGiugno)
                    txt06.Text = F.Riassunto
                End If
            End If

            If _FM.chkLuglio Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkLuglio)
                        txt07.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkLuglio)
                    txt07.Text = F.Riassunto
                End If
            End If

            If _FM.chkAgosto Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkAgosto)
                        txt08.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkAgosto)
                    txt08.Text = F.Riassunto
                End If
            End If

            If _FM.chkSettembre Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkSettembre)
                        txt09.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkSettembre)
                    txt09.Text = F.Riassunto
                End If
            End If

            If _FM.chkOttobre Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkOttobre)
                        txt10.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkOttobre)
                    txt10.Text = F.Riassunto
                End If
            End If

            If _FM.chkNovembre Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkNovembre)
                        txt11.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkNovembre)
                    txt11.Text = F.Riassunto
                End If
            End If

            If _FM.chkDicembre Then
                If _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                    Using t As New TemplateMarketing
                        t.Read(_FM.chkDicembre)
                        txt12.Text = t.Path
                    End Using
                ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                    Dim F As New TMO
                    F.Read(_FM.chkDicembre)
                    txt12.Text = F.Riassunto
                End If
            End If

        Else

            btn01.Enabled = False
            btn02.Enabled = False
            btn03.Enabled = False
            btn04.Enabled = False
            btn05.Enabled = False
            btn06.Enabled = False
            btn07.Enabled = False
            btn08.Enabled = False
            btn09.Enabled = False
            btn10.Enabled = False
            btn11.Enabled = False
            btn12.Enabled = False

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

    Private Sub RiempiFiltroDaForm(ByRef FM As FiltroMarketing)
        FM.Nome = txtNome.Text

        If chkRicorsiva.Checked Then
            FM.Ricorsiva = enSiNo.Si
        Else
            FM.Ricorsiva = enSiNo.No
        End If

        FM.IdGruppo = cmbGruppoContatti.SelectedValue

        ''PRINCIPALE
        'If chkCatMark.Checked Then
        '    FM.CategoriaMarketing = cmbCatMark.SelectedValue
        'Else
        '    FM.CategoriaMarketing = 0
        'End If

        'If chkTipo.Checked Then
        '    FM.Tipo = cmbTipo.SelectedValue
        'Else
        '    FM.Tipo = 0
        'End If

        'If chkOrigine.Checked Then
        '    FM.TipoOrigine = cmbOrigine.SelectedValue
        'Else
        '    FM.TipoOrigine = enOrigineContatto.Tutto
        'End If

        'If chkCitta.Checked Then
        '    FM.Citta = txtCitta.Text
        'Else
        '    FM.Citta = String.Empty
        'End If

        'If chkCap.Checked Then
        '    FM.Cap = txtCAP.Text
        'Else
        '    FM.Cap = String.Empty
        'End If

        'If chkInseritiDa.Checked Then
        '    FM.InseritiDa = cmbInseritiDa.SelectedValue
        'Else
        '    FM.InseritiDa = 0
        'End If

        ''PRODOTTI
        'If chkHannoAcquistatoUn.Checked Then
        '    FM.HannoAcqAlmenoUn = cmbCatProdAcq.SelectedValue
        'Else
        '    FM.HannoAcqAlmenoUn = 0
        'End If
        'If chkNonHannoAcquistatoUn.Checked Then
        '    FM.NonHannoMaiAcqUn = cmbCatProdNonAcq.SelectedValue
        'Else
        '    FM.NonHannoMaiAcqUn = 0
        'End If

        ''SPESA COMPLESSIVA
        'If chkSpesaMinDi.Checked Or chkSpesaMaxDi.Checked Then FM.SpesaNelPeriodo = cmbPeriodoSpesa.SelectedValue

        'If chkSpesaMinDi.Checked Then
        '    FM.SpesaNelPeriodoMinoreDi = txtSpesaMinDi.Text
        'Else
        '    FM.SpesaNelPeriodoMinoreDi = 0
        'End If

        'If chkSpesaMaxDi.Checked Then
        '    FM.SpesaNelPeriodoMaggioreDi = txtSpesaMaxDi.Text
        'Else
        '    FM.SpesaNelPeriodoMaggioreDi = 0
        'End If

        'If chkNonHannoMaiSpeso.Checked Then
        '    FM.NonHannoMaiSpeso = enSiNo.Si
        'Else
        '    FM.NonHannoMaiSpeso = enSiNo.No
        'End If

        'If chkTag.Checked Then
        '    FM.tag = txtTag.Text
        'Else
        '    FM.tag = String.Empty
        'End If

        FM.TipoFiltro = _TipoFiltro

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If cmbGruppoContatti.SelectedValue = 0 Then
            MessageBox.Show("Selezionare un gruppo di contatti")
        Else
            If MessageBox.Show("Confermi il salvataggio del filtro?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                RiempiFiltroDaForm(_FM)

                _FM.Save()

                _Ris = 1
                Close()
            End If
        End If


    End Sub

    Private Function Comparer(ByVal x As IVoceRubricaG, ByVal y As IVoceRubricaG) As Integer
        Dim result As Integer = y.ProvenienzaVoce.CompareTo(x.ProvenienzaVoce)
        If result = 0 Then result = x.NominativoG.CompareTo(y.NominativoG)

        Return result
    End Function

    Private Sub lnkTest_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTest.LinkClicked
        If cmbGruppoContatti.SelectedValue = 0 Then
            MessageBox.Show("Selezionare un gruppo di contatti")
        Else
            'qui devo testare il filtro con le scelte selezionate
            Cursor = Cursors.WaitCursor

            'Dim F As New FiltroMarketing

            'F.IdFiltroMarketing = _FM.IdFiltroMarketing

            Dim l As List(Of IVoceRubricaG)
            'Using mgr As New VociRubGDAO

            '    l = mgr.GetAllVoceRubG()

            '    RiempiFiltroDaForm(F)

            '    l = mgr.ApplicaFiltro(l, F)

            'End Using

            Using G As New Gruppo
                G.Read(cmbGruppoContatti.SelectedValue)
                Using mgr As New VociRubGDAO
                    l = mgr.GetAllVoceRubG(G)
                    l = mgr.ApplicaFiltro(l, G)
                End Using
            End Using
            lblRisAtt.Text = "Risultati attuali con i filtri impostati: " & l.Count

            If MessageBox.Show("Vuoi esportare i risultati attuali del filtro in formato testuale?", "Export risultati", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim buffer As String = String.Empty

                For Each singL As IVoceRubricaG In l
                    buffer &= singL.IdRubG & " - (" & singL.ProvenienzaVoceExt & ") " & singL.NominativoG & ControlChars.NewLine
                Next

                Dim Path As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".txt")

                Using w As New StreamWriter(Path)
                    w.Write(buffer)
                End Using

                FormerHelper.File.ShellExtended(Path)

            End If

            Cursor = Cursors.Default

        End If

    End Sub

    Private Sub btn01_Click(sender As Object, e As EventArgs) Handles btn01.Click

        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkGennaio, fm.IdFiltroMarketing, 1)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkGennaio = risultato.IdTmOff
                txt01.Text = risultato.Riassunto
            Else
                fm.chkGennaio = 0
                txt01.Text = String.Empty
            End If

            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkGennaio)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt01.Text = t.Path
                    _FM.chkGennaio = ris
                End Using
            Else
                _FM.chkGennaio = 0
                txt01.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If

    End Sub

    Private Sub btn02_Click(sender As Object, e As EventArgs) Handles btn02.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkFebbraio, fm.IdFiltroMarketing, 2)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkFebbraio = risultato.IdTmOff
                txt02.Text = risultato.Riassunto
            Else
                fm.chkFebbraio = 0
                txt02.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkFebbraio)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt02.Text = t.Path
                    _FM.chkFebbraio = ris
                End Using
            Else
                _FM.chkFebbraio = 0
                txt02.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn03_Click(sender As Object, e As EventArgs) Handles btn03.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkMarzo, fm.IdFiltroMarketing, 3)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkMarzo = risultato.IdTmOff
                txt03.Text = risultato.Riassunto
            Else
                fm.chkMarzo = 0
                txt03.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkMarzo)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt03.Text = t.Path
                    _FM.chkMarzo = ris
                End Using
            Else
                _FM.chkMarzo = 0
                txt03.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn04_Click(sender As Object, e As EventArgs) Handles btn04.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkAprile, fm.IdFiltroMarketing, 4)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkAprile = risultato.IdTmOff
                txt04.Text = risultato.Riassunto
            Else
                fm.chkAprile = 0
                txt04.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkAprile)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt04.Text = t.Path
                    _FM.chkAprile = ris
                End Using
            Else
                _FM.chkAprile = 0
                txt04.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn05_Click(sender As Object, e As EventArgs) Handles btn05.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkMaggio, fm.IdFiltroMarketing, 5)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkMaggio = risultato.IdTmOff
                txt05.Text = risultato.Riassunto
            Else
                fm.chkMaggio = 0
                txt05.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkMaggio)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt05.Text = t.Path
                    _FM.chkMaggio = ris
                End Using
            Else
                _FM.chkMaggio = 0
                txt05.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn06_Click(sender As Object, e As EventArgs) Handles btn06.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkGiugno, fm.IdFiltroMarketing, 6)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkGiugno = risultato.IdTmOff
                txt06.Text = risultato.Riassunto
            Else
                fm.chkGiugno = 0
                txt06.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkGiugno)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt06.Text = t.Path
                    _FM.chkGiugno = ris
                End Using
            Else
                _FM.chkGiugno = 0
                txt06.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn07_Click(sender As Object, e As EventArgs) Handles btn07.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkLuglio, fm.IdFiltroMarketing, 7)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkLuglio = risultato.IdTmOff
                txt07.Text = risultato.Riassunto
            Else
                fm.chkLuglio = 0
                txt07.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkLuglio)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt07.Text = t.Path
                    _FM.chkLuglio = ris
                End Using
            Else
                _FM.chkLuglio = 0
                txt07.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn08_Click(sender As Object, e As EventArgs) Handles btn08.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkAgosto, fm.IdFiltroMarketing, 8)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkAgosto = risultato.IdTmOff
                txt08.Text = risultato.Riassunto
            Else
                fm.chkAgosto = 0
                txt08.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkAgosto)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt08.Text = t.Path
                    _FM.chkAgosto = ris
                End Using
            Else
                _FM.chkAgosto = 0
                txt08.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn09_Click(sender As Object, e As EventArgs) Handles btn09.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkSettembre, fm.IdFiltroMarketing, 9)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkSettembre = risultato.IdTmOff
                txt09.Text = risultato.Riassunto
            Else
                fm.chkSettembre = 0
                txt09.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkSettembre)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt09.Text = t.Path
                    _FM.chkSettembre = ris
                End Using
            Else
                _FM.chkSettembre = 0
                txt09.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn10_Click(sender As Object, e As EventArgs) Handles btn10.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkOttobre, fm.IdFiltroMarketing, 10)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkOttobre = risultato.IdTmOff
                txt10.Text = risultato.Riassunto
            Else
                fm.chkOttobre = 0
                txt10.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkOttobre)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt10.Text = t.Path
                    _FM.chkOttobre = ris
                End Using
            Else
                _FM.chkOttobre = 0
                txt10.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn11_Click(sender As Object, e As EventArgs) Handles btn11.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkNovembre, fm.IdFiltroMarketing, 11)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkNovembre = risultato.IdTmOff
                txt11.Text = risultato.Riassunto
            Else
                fm.chkNovembre = 0
                txt11.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkNovembre)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt11.Text = t.Path
                    _FM.chkNovembre = ris
                End Using
            Else
                _FM.chkNovembre = 0
                txt11.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btn12_Click(sender As Object, e As EventArgs) Handles btn12.Click
        If _FM.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
            Sottofondo()

            Dim f As New frmNewTemplMarketing

            Dim fm As FiltroMarketing = _FM

            Dim risultato As TMO = f.Carica(fm.chkDicembre, fm.IdFiltroMarketing, 12)

            f = Nothing

            Sottofondo()

            If risultato.IdTmOff Then
                fm.chkDicembre = risultato.IdTmOff
                txt12.Text = risultato.Riassunto
            Else
                fm.chkDicembre = 0
                txt12.Text = String.Empty
            End If
            fm.Save()
        ElseIf _FM.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
            Sottofondo()
            Dim f As New frmMarketingHtmlNew

            Dim ris As Integer = f.Carica(_FM.chkDicembre)

            If ris Then
                Using t As New TemplateMarketing
                    t.Read(ris)
                    txt12.Text = t.Path
                    _FM.chkDicembre = ris
                End Using
            Else
                _FM.chkDicembre = 0
                txt12.Text = String.Empty
            End If
            _FM.Save()
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub btnElencoTag_Click(sender As Object, e As EventArgs)

        'qui carico tutti i tag disponibili distinti e mostro una form di riepilogo
        Dim Buffer As String = String.Empty

        Using mgr As New VociRubricaDAO
            Dim l As List(Of String) = mgr.GetAllTag

            For Each s As String In l
                Buffer &= s & ControlChars.NewLine
            Next

        End Using

        Sottofondo()
        Using f As New frmTextShow
            f.Carica(Buffer)
        End Using
        Sottofondo()

    End Sub

    Private Sub btnDettGruppo_Click(sender As Object, e As EventArgs) Handles btnDettGruppo.Click

        If cmbGruppoContatti.SelectedValue Then
            Sottofondo()
            Using f As New frmGruppo
                Dim Ris As Integer = f.Carica(cmbGruppoContatti.SelectedValue)
                If Ris Then
                    CaricaGruppi()
                    If _FM.IdGruppo Then
                        MgrControl.SelectIndexCombo(cmbGruppoContatti, _FM.IdGruppo)
                    End If
                End If
            End Using
            Sottofondo()
        End If

    End Sub
End Class