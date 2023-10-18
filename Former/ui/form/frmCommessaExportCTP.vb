Imports FormerDALSql
Imports FormerLib
Imports FormerConfig
Imports FormerLib.FormerEnum
Imports FormerBusinessLogic

Friend Class frmCommessaExportCTP
    'Inherits baseFormInternaRedim
    Private _Ris As Integer = 0
    Private _CollOrd As OrdiniCTP
    Private _IdCom As Integer = 0

    Friend Function Carica(ByRef ordini As OrdiniCTP,
                           IdCom As Integer) As Integer

        _CollOrd = ordini
        _IdCom = IdCom

        CaricaOrdini()

        ShowDialog()
        Return _Ris

    End Function

    Private Sub CaricaOrdini()

        Using C As New Commessa
            C.Read(_IdCom)
            If C.IdModelloCommessa Then
                Using M As New ModelloCommessa
                    M.Read(C.IdModelloCommessa)
                    Try
                        pctAnteF.Image = Image.FromFile(M.Anteprima)
                        pctAnteR.Image = Image.FromFile(M.AnteprimaR)
                    Catch ex As Exception

                    End Try
                End Using
            End If
        End Using

        '_CollOrd.ListaOrdini.Sort(Function(o, y) o.OrdinamentoDaFormato.CompareTo(y.OrdinamentoDaFormato))
        MgrCTP.OrdinaListaOrdini(_CollOrd)
        DgOrdini.Rows.Clear()

        For Each x As OrdineCTP In _CollOrd.ListaOrdini
            Using Ordine As New Ordine
                Ordine.Read(x.IdOrd)
                Dim Riga As New DataGridViewRow
                Riga.CreateCells(DgOrdini)
                Using Prod As New Prodotto
                    Dim Prodotto As String = ""
                    Prod.Read(Ordine.IdProd)

                    'ordine prodotto cliente spazi duplicati
                    Dim ImgPreview As Image = Nothing
                    Dim ImgNew As Image = Nothing
                    Try
                        ImgPreview = Image.FromFile(Ordine.FilePath)
                        ImgNew = New Bitmap(ImgPreview, New Size(50, 75))
                    Catch ex As Exception

                    End Try

                    Riga.Cells(0).Value = ImgNew
                    Riga.Cells(1).Value = x.IdOrd
                    Riga.Cells(2).Value = Prod.Descrizione
                    Riga.Cells(3).Value = x.Ordine.QtaRifStr
                    Riga.Cells(4).Value = Ordine.VoceRubrica.RagSocNome
                    Riga.Cells(5).Value = x.Duplicati
                    Riga.Cells(6).Value = 0

                End Using
                DgOrdini.Rows.Add(Riga)
            End Using

        Next

    End Sub

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

    Private Sub lnkSu_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSu.LinkClicked
        SpostaLav("UP")
    End Sub

    Private Sub SpostaLav(ByVal Direzione As String)

        If DgOrdini.SelectedRows.Count Then
            Dim Dr As DataGridViewRow = DgOrdini.SelectedRows(0)
            If Dr.Selected Then

                Dim Riga As New DataGridViewRow
                Riga.CreateCells(DgOrdini)

                Riga.Cells(0).Value = Dr.Cells(0).Value
                Riga.Cells(1).Value = Dr.Cells(1).Value
                Riga.Cells(2).Value = Dr.Cells(2).Value
                Riga.Cells(3).Value = Dr.Cells(3).Value
                Riga.Cells(4).Value = Dr.Cells(4).Value
                Riga.Cells(5).Value = Dr.Cells(5).Value
                Riga.Cells(6).Value = Dr.Cells(6).Value

                Select Case Direzione
                    Case "UP"

                        If Dr.Index - 1 >= 0 Then
                            DgOrdini.Rows.Insert(Dr.Index - 1, Riga)
                            DgOrdini.Rows.Remove(DgOrdini.SelectedRows(0))
                            Riga.Selected = True
                        End If

                    Case "DOWN"
                        If Dr.Index + 2 <= DgOrdini.Rows.Count Then
                            DgOrdini.Rows.Insert(Dr.Index + 2, Riga)
                            DgOrdini.Rows.Remove(DgOrdini.SelectedRows(0))
                            Riga.Selected = True
                        End If

                End Select

            End If
        End If

    End Sub

    Private Sub lnkGiu_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkGiu.LinkClicked
        SpostaLav("DOWN")
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi l'export dei file nell'ordine selezionato?", "Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Cursor.Current = Cursors.WaitCursor
            'esporto effettivamente i file

            Dim collOrd As New OrdiniCTP
            'carico la lista di ordini in base agli ordini presenti nella commessa

            collOrd.IdCom = _CollOrd.IdCom

            Dim dr As DataGridViewRow, Cont As Integer = 1

            For Each dr In DgOrdini.Rows

                Dim Ord As New OrdineCTP
                Ord.IdOrd = dr.Cells(1).Value
                Ord.Ordinamento = Cont
                Ord.Duplicati = dr.Cells(5).Value
                collOrd.ListaOrdini.Add(Ord)

                Cont += 1

            Next

            'chiamo la funzione che esporta effettivamente i file degli ordini
            Try
                ' Dim risCtp As Integer = 0
                Dim risJob As Integer = 0

                'risCtp = MgrCTP.EsportaCTP(collOrd)

                risJob = MgrCTP.EsportaJOB(collOrd.IdCom, collOrd, Me)

                'If risCtp = 1 Then

                '    MessageBox.Show("Nel modello commessa scelto non è presente un formato prodotto specifico o generico da cui poter capire l'orientamento. I file sorgenti NON sono stati quindi orientati")

                'End If

                If risJob = 1 Then

                    MessageBox.Show("Si è verificato un errore nell' export del File JOB. Eseguire di nuovo l'operazione")

                End If

                Cursor.Current = Cursors.Default
                Close()
            Catch ex As Exception
                MessageBox.Show("Si è verificato un errore nell'export CTP: " & ex.Message)
            End Try

        End If

    End Sub

    'Private Sub EsportaJOB(IdCom As Integer)

    '    Dim C As New Commessa
    '    C.Read(IdCom)
    '    If C.IdModelloCommessa Then
    '        Dim M As New ModelloCommessa
    '        M.Read(C.IdModelloCommessa)

    '        Dim PathDir As String = FormerPath.PathJOB & IdCom & "\"

    '        FormerHelper.File.CreateLongPath(PathDir)

    '        Dim NomeFileDest As String = PathDir & IdCom & ".job"
    '        Dim NomefileAnte As String = PathDir & IdCom & "F.jpg"
    '        Dim NomefileAnteR As String = PathDir & IdCom & "R.jpg"
    '        Dim NomefilePDF As String = PathDir & IdCom & ".pdf"
    '        MgrIO.FileCopia(Me, M.Job, NomeFileDest)
    '        If M.Anteprima.Length Then
    '            MgrIO.FileCopia(Me, M.Anteprima, NomefileAnte)
    '        End If
    '        If M.AnteprimaR.Length Then
    '            MgrIO.FileCopia(Me, M.AnteprimaR, NomefileAnteR)
    '        End If
    '        If M.PDF.Length Then
    '            MgrIO.FileCopia(Me, M.PDF, NomefilePDF)
    '        End If
    '    End If

    'End Sub

    'Private Sub EsportaCTP(ByVal CollOrd As cCTPOrdini)

    '    Dim PathDir As String = FormerPath.PathCTP & CollOrd.IdCom & "\"

    '    FormerHelper.File.CreateLongPath(PathDir)

    '    'creo la cartella della commessa

    '    'ora ciclo per tutti gli ordini contenuti nella collezione, mi carico i file di ogni ordine e lo copio n volte per quanti sono i duplicati 
    '    'mantenendo la numerazione in base a fronte retro 
    '    Dim ContNumFronte As Integer = 1
    '    Dim ContNumRetro As Integer = 2

    '    Dim Ord As cCTPOrdine
    '    Dim buffer As String = ""
    '    Dim NumRiga As Integer = 1

    '    For Each Ord In CollOrd.ListaOrdini
    '        'Dim DT As DataTable, Dr As DataRow

    '        'Using collSorg As New cSorgentiColl
    '        '    DT = collSorg.Lista(Ord.IdOrd)
    '        'End Using

    '        Dim l As List(Of FileSorgente) = Ord.Ordine.ListaSorgenti ' Nothing

    '        NumRiga = 1

    '        For Each Dr As FileSorgente In l

    '            'la prima volta e' il fronte la seconda il retro

    '            Dim NuovoNomeFile As String = ""
    '            Dim ContInterno As Integer = 0

    '            Dim NomeFileOriginale As String = Dr.FilePath
    '            Dim NomeFileOrientato As String = String.Empty

    '            Dim OrientamentoPrevisto As enTipoOrientamento = enTipoOrientamento.Orizzontale
    '            Dim OrientamentoTrovato As enTipoOrientamento = enTipoOrientamento.NonSpecificato

    '            'qui vedo l'orientamento trovato nel file sorgente
    '            OrientamentoTrovato = FormerLib.FormerHelper.PDF.GetOrientamentoPdf(NomeFileOriginale)

    '            'qui cerco l'orientamento previsto nel modello commessa
    '            Dim ModComFP As ModComFormProd = CollOrd.Commessa.ModelloCommessa.FormatiProdotto.Find(Function(x) x.IdFormProd = Ord.Ordine.ListinoBase.IdFormProd)

    '            Dim AngoloRotazione As Integer = 0

    '            If ModComFP Is Nothing Then
    '                ModComFP = CollOrd.Commessa.ModelloCommessa.FormatiProdotto.Find(Function(x) x.FormatoProdotto.IdFormCarta = Ord.Ordine.ListinoBase.FormatoProdotto.IdFormCarta)
    '            End If

    '            If ModComFP Is Nothing Then
    '                MessageBox.Show("Nel modello commessa scelto non è presente un formato prodotto specifico o generico da cui poter capire l'orientamento")
    '            Else
    '                OrientamentoPrevisto = ModComFP.Orientamento

    '                If Dr.NumPagina And Not ModComFP Is Nothing Then
    '                    If OrientamentoPrevisto = enTipoOrientamento.Orizzontale Then
    '                        If OrientamentoTrovato = enTipoOrientamento.Verticale Then
    '                            If Dr.NumPagina Mod 2 = 0 Then ' retro
    '                                '-270
    '                                AngoloRotazione = -270
    '                            Else 'fronte
    '                                '-90
    '                                AngoloRotazione = -90
    '                            End If
    '                        End If
    '                    ElseIf OrientamentoPrevisto = enTipoOrientamento.Verticale Then
    '                        If OrientamentoTrovato = enTipoOrientamento.Orizzontale Then
    '                            If Dr.NumPagina Mod 2 = 0 Then ' retro
    '                                '-270
    '                                AngoloRotazione = -270
    '                            Else 'fronte
    '                                '-90
    '                                AngoloRotazione = -90
    '                            End If
    '                        End If
    '                    End If
    '                End If

    '            End If

    '            For ContInterno = 1 To Ord.Duplicati
    '                Dim contatore As Integer = 0

    '                contatore += 1

    '                If CollOrd.Commessa.ModelloCommessa.FronteRetro = enSiNo.No Then
    '                    'qui sono tutti fronte quindi se ci sono piu di un sorgente nell'ordine in realta è un anomalia
    '                    contatore = ContNumFronte
    '                    ContNumFronte += 1
    '                Else
    '                    If Dr.NumPagina Mod 2 <> 0 Then
    '                        'qui fronte
    '                        contatore = ContNumFronte
    '                        ContNumFronte += 2
    '                    Else
    '                        'qui retro
    '                        contatore = ContNumRetro
    '                        ContNumRetro += 2
    '                    End If
    '                End If

    '                'If NumRiga = 1 Then
    '                '    contatore = ContNumFronte
    '                '    ContNumFronte += 2
    '                'Else
    '                '    contatore = ContNumRetro
    '                '    ContNumRetro += 2 'porto cmq avanti anche il retro 
    '                'End If

    '                NuovoNomeFile = PathDir & FormerHelper.Stringhe.FormattaConZeri(contatore, 3) & "-" & FormerLib.FormerHelper.File.EstraiNomeFile(Dr.FilePath)

    '                If AngoloRotazione Then
    '                    FormerLib.FormerHelper.PDF.RuotaPdf(Dr.FilePath, NuovoNomeFile, AngoloRotazione)
    '                Else
    '                    'qui copio effettivamente il file
    '                    MgrIO.FileCopia(Me, Dr.FilePath, NuovoNomeFile)
    '                End If

    '                'Buffer &= NuovoNomeFile & vbNewLine
    '            Next

    '            NumRiga += 1
    '        Next

    '        Dim FileVuoto As String = FormerPath.PathFileBianco

    '        If CollOrd.Commessa.ModelloCommessa.FronteRetro = enSiNo.Si Then
    '            If l.Count Mod 2 <> 0 Then

    '                'qui la modifica per il nuovo ragionamento con file vuoto

    '                Dim ContInterno As Integer = 0

    '                For ContInterno = 1 To Ord.Duplicati
    '                    Dim NuovoNomeFile As String = ""
    '                    NuovoNomeFile = PathDir & FormerHelper.Stringhe.FormattaConZeri(ContNumRetro, 3) & "-" & FormerLib.FormerHelper.File.EstraiNomeFile(FileVuoto)
    '                    'qui copio effettivamente il file
    '                    MgrIO.FileCopia(Me, FileVuoto, NuovoNomeFile)
    '                    ContNumRetro += 2
    '                Next

    '            End If
    '        End If

    '    Next

    '    'txtris.text = buffer
    'End Sub

    Private Sub DgOrdini_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgOrdini.CellDoubleClick
        If DgOrdini.SelectedRows.Count Then
            Dim NumDupl As Integer = DgOrdini.SelectedRows(0).Cells(5).Value
            Try
                Dim NewNumDupl As String = InputBox("Inserisci il numero di duplicati per questo ordine", "Numero duplicati", NumDupl)
                If CInt(NewNumDupl) Then
                    DgOrdini.SelectedRows(0).Cells(5).Value = NewNumDupl
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnFileVuoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileVuoto.Click

        OpenFileSorg.ShowDialog()

        If OpenFileSorg.FileName.Length Then

            txtFileVuoto.Text = OpenFileSorg.FileName

        End If

    End Sub

    Private Sub DgOrdini_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgOrdini.RowPostPaint

        CalcolaPosizione()

    End Sub

    Private Sub CalcolaPosizione()

        Dim PosizVecchia As Integer = 1
        Dim PosizAttuale As Integer = 0
        If chkPosDispari.Checked Then PosizAttuale = -1
        For Each R As DataGridViewRow In DgOrdini.Rows
            Dim Valore As Integer = R.Cells(5).Value
            If chkPosDispari.Checked Then
                For i As Integer = 1 To Valore
                    PosizAttuale += 2
                Next
            Else
                PosizAttuale += Valore
            End If
            Dim D As String = ""
            If PosizAttuale <> PosizVecchia Then
                D = PosizVecchia & "-" & PosizAttuale
            Else
                D = PosizAttuale
            End If
            R.Cells(6).Value = D
            Dim Addiz As Integer = 1
            If chkPosDispari.Checked Then Addiz = 2
            PosizVecchia = PosizAttuale + Addiz
        Next

    End Sub

    Private Sub chkPosDispari_CheckedChanged(sender As Object, e As EventArgs) Handles chkPosDispari.CheckedChanged

        CalcolaPosizione()

    End Sub

    Private Sub lnkModModelloCommessa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModModelloCommessa.LinkClicked

        Using c As New Commessa
            c.Read(_IdCom)

            Sottofondo()

            Using f As New frmCommessaModello
                Dim ris As Integer = f.Carica(c.IdModelloCommessa)

                If ris Then
                    If MessageBox.Show("Il modello commessa e' stato modificato, vuoi ricaricare gli ordini?", "Modello Commessa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        CaricaOrdini()
                    End If
                End If
            End Using

            Sottofondo()

        End Using

    End Sub

    Private Sub DgOrdini_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgOrdini.CellContentClick

    End Sub
End Class