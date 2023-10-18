Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerWebLabeling
Imports FormerConfig
Imports FormerBusinessLogicInterface
Imports FormerBusinessLogic

Public Class ucConsegneGlsAdmin
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Public Sub Carica()

        CaricaCombo()

    End Sub

    Public Sub CaricaCombo()

        'Using cli As New VociRubricaDAO

        '    cmbCliente.ValueMember = "IdRub"
        '    cmbCliente.DisplayMember = "Nominativo"

        '    cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, True)

        'End Using

        UcComboCliente.Carica(enTipoRubrica.Cliente, True)

        Dim l As New List(Of cEnum)

        Dim P As New cEnum With {.Id = 0, .Descrizione = "Tutti"}
        l.Add(P)

        'CICLO ENUM
        Dim Stati() As FormerLib.FormerEnum.enStatoConsegna = [Enum].GetValues(GetType(enStatoConsegna))

        For Each stato As enStatoConsegna In Stati
            If stato > enStatoConsegna.InAttesaDiPagamento Then
                P = New FormerLib.cEnum
                P.Id = stato
                P.Descrizione = FormerEnumHelper.StatoConsegnaString(stato)
                l.Add(P)
            End If
        Next

        cmbStatoConsegna.DataSource = l

        Dim lPer As New List(Of cEnum)

        Dim PPer As New cEnum With {.Id = enPeriodoRiferimento.UnGiorno, .Descrizione = "Oggi e future"}
        lPer.Add(PPer)

        PPer = New cEnum With {.Id = enPeriodoRiferimento.UnMese, .Descrizione = "Un mese"}
        lPer.Add(PPer)

        PPer = New cEnum With {.Id = enPeriodoRiferimento.TreMesi, .Descrizione = "Tre mesi"}
        lPer.Add(PPer)

        PPer = New cEnum With {.Id = enPeriodoRiferimento.SeiMesi, .Descrizione = "Sei mesi"}
        lPer.Add(PPer)

        PPer = New cEnum With {.Id = enPeriodoRiferimento.UnAnno, .Descrizione = "Un anno"}
        lPer.Add(PPer)

        PPer = New cEnum With {.Id = 0, .Descrizione = "Sempre"}
        lPer.Add(PPer)

        cmbPeriodo.DataSource = lPer


    End Sub

    Private Sub CaricaDati()

        Cursor = Cursors.WaitCursor

        Using mgr As New ConsegneProgrammateDAO

            Dim PStato As LUNA.LunaSearchParameter = Nothing
            Dim PCliente As LUNA.LunaSearchParameter = Nothing
            Dim PCodTrack As LUNA.LunaSearchParameter = Nothing
            Dim PIdInterno As LUNA.LunaSearchParameter = Nothing
            Dim PPeriodo As LUNA.LunaSearchParameter = Nothing

            If UcComboCliente.IdRubSelezionato Then
                PCliente = New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdRub, UcComboCliente.IdRubSelezionato)
            End If

            If txtCodInterno.Text.Trim.Length And IsNumeric(txtCodInterno.Text) Then
                PIdInterno = New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCons, txtCodInterno.Text)
            End If

            If txtCodTracking.Text.Trim.Length Then
                PCodTrack = New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, "%" & txtCodTracking.Text.Trim & "%", "LIKE")
            End If

            Dim ValoreSel As cEnum = cmbStatoConsegna.SelectedItem

            If ValoreSel.Id Then
                PStato = New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, ValoreSel.Id)
            Else
                PStato = New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, "(" & enStatoConsegna.InLavorazione & "," & enStatoConsegna.RegistrataCorriere & "," & enStatoConsegna.InConsegna & "," & enStatoConsegna.Consegnata & ")", " IN ")
            End If

            Dim ValorePer As cEnum = cmbPeriodo.SelectedItem

            Select Case ValorePer.Id

                Case enPeriodoRiferimento.UnGiorno
                    PPeriodo = New LUNA.LunaSearchParameter("datediff(""d"",Giorno,GetDate())", 1, "<=")

                Case enPeriodoRiferimento.UnMese
                    PPeriodo = New LUNA.LunaSearchParameter("datediff(""d"",Giorno,GetDate())", 30, "<=")

                Case enPeriodoRiferimento.TreMesi
                    PPeriodo = New LUNA.LunaSearchParameter("datediff(""d"",Giorno,GetDate())", 90, "<=")

                Case enPeriodoRiferimento.SeiMesi
                    PPeriodo = New LUNA.LunaSearchParameter("datediff(""d"",Giorno,GetDate())", 180, "<=")

                Case enPeriodoRiferimento.UnAnno
                    PPeriodo = New LUNA.LunaSearchParameter("datediff(""d"",Giorno,GetDate())", 365, "<=")

            End Select

            Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Giorno Desc"},
                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.No),
                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, "(" & enCorriere.GLS & "," & enCorriere.GLSIsole & "," & enCorriere.PortoAssegnatoGLS & ")", " IN "),
                                                                PStato,
                                                                PCliente,
                                                                PCodTrack,
                                                                PIdInterno,
                                                                PPeriodo)

            DgConsegne.AutoGenerateColumns = False
            DgConsegne.DataSource = l

        End Using

        Cursor = Cursors.Default

    End Sub

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        CaricaDati()

    End Sub

    Private Sub GestisciConsegna()

        If DgConsegne.SelectedRows.Count Then

            Dim Cons As ConsegnaProgrammata = DgConsegne.SelectedRows(0).DataBoundItem
            Dim IdCons As Integer = Cons.IdCons

            If IdCons Then

                ParentFormEx.Sottofondo()

                Using x As New frmConsegnaProgrammata
                    Dim Ris As Integer = x.Carica(IdCons)

                    If Ris Then CaricaDati()
                End Using

                ParentFormEx.Sottofondo()
            End If
        Else
            MessageBox.Show("Selezionare una consegna dalla lista")
        End If
        'devo recuperare l'id della consegna

    End Sub

    Private Sub btnGestCons_Click(sender As Object, e As EventArgs) Handles btnGestCons.Click

        GestisciConsegna()

    End Sub

    Private Sub btnTracking_Click(sender As Object, e As EventArgs) Handles btnTracking.Click
        If DgConsegne.SelectedRows.Count Then

            Dim Cons As ConsegnaProgrammata = DgConsegne.SelectedRows(0).DataBoundItem
            Dim CodTrack As String = Cons.CodTrack

            If CodTrack.Length Then

                Dim PathUrl As String = MgrTraceCorriere.GetUrlTraceGLS(CodTrack)

                FormerLib.FormerHelper.File.ShellExtended(PathUrl)

            Else
                MessageBox.Show("La consegna non contiene un codice di tracking")
            End If
        Else
            MessageBox.Show("Selezionare una consegna dalla lista")
        End If
    End Sub

    Private Sub DgConsegne_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgConsegne.CellContentClick

    End Sub

    Private Sub DgConsegne_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgConsegne.CellDoubleClick

        GestisciConsegna()

    End Sub

    Private Sub DgConsegne_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgConsegne.ColumnHeaderMouseClick
        OrdinatoreLista(Of ConsegnaProgrammata).OrdinaLista(sender, e)
    End Sub

    Private Sub DgConsegne_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgConsegne.RowPostPaint

        Dim Riga As DataGridViewRow = DgConsegne.Rows.Item(e.RowIndex)
        Dim c As ConsegnaProgrammata = Riga.DataBoundItem

        Dim ColoreSfondo As Color = c.ColoreStatoConsegna

        Riga.Cells(5).Style.BackColor = ColoreSfondo
        Riga.Cells(5).Style.SelectionBackColor = ColoreSfondo

        'Dim l As New LUNA.LunaSearchParameter("ciao", "ciao")

    End Sub

    Private Sub btnStampaEtichCorr_Click(sender As Object, e As EventArgs) Handles btnStampaEtichCorr.Click

        If DgConsegne.SelectedRows.Count Then

            Dim Cons As ConsegnaProgrammata = DgConsegne.SelectedRows(0).DataBoundItem
            Dim CodTrack As String = Cons.CodTrack

            If CodTrack.Length Then
                If MessageBox.Show("Vuoi ristampare l'etichetta di GLS?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim Path As String = FormerPath.PathTempLocale()
                    'Dim PdfSalvato As String = c.CodTrack & ".pdf"
                    'Dim Pdf As String = Path & PdfSalvato
                    Dim ZplSalvato As String = Cons.CodTrack & ".zpl"
                    Dim Zpl As String = Path & ZplSalvato
                    Cursor.Current = Cursors.WaitCursor
                    If Not System.IO.File.Exists(Zpl) Then
                        'If Not System.IO.File.Exists(Pdf) Then
                        'Dim lstPdfStreams As New List(Of System.IO.MemoryStream)
                        Dim lstZpl As String = String.Empty
                        Dim Ok As Boolean = True
                        For i = 1 To Cons.NumColli
                            Dim ContatoreProgressivo As Integer = Cons.IdCons & i
                            Try
                                'lstPdfStreams.Add(MgrGls.GetEtichettaPdf(ContatoreProgressivo))
                                lstZpl &= MgrWebLabelingGls.GetEtichettaZpl(ContatoreProgressivo) & vbCrLf
                            Catch ex As Exception
                                Ok = False
                                MessageBox.Show(ex.Message)
                            End Try
                        Next
                        If Ok Then
                            Try
                                'FormerLib.FormerHelper.PDF.CreaPdfMultiPagina(Pdf, lstPdfStreams)
                                'QUI SALVO LA STRINGA ZPL IN UN FILE FISICO
                                Using objWriter As New System.IO.StreamWriter(Zpl)
                                    objWriter.Write(lstZpl)
                                End Using
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                    Dim buffer As String = String.Empty
                    Using objReader As New System.IO.StreamReader(Zpl)
                        buffer = objReader.ReadToEnd()
                    End Using

                    If FormerDebug.DebugAttivo = False Then
                        RawPrinterHelper.SendStringToPrinter(PostazioneCorrente.StampanteEtichetteGLS, buffer)
                    End If
                    Cursor.Current = Cursors.Default

                    MessageBox.Show("Stampa effettuata correttamente")
                End If

            Else
                MessageBox.Show("La consegna non contiene un codice di tracking")
            End If
        Else
            MessageBox.Show("Selezionare una consegna dalla lista")
        End If

    End Sub

    Private Sub btnDelRegistraz_Click(sender As Object, e As EventArgs) Handles btnDelRegistraz.Click

        If DgConsegne.SelectedRows.Count Then

            Dim Cons As ConsegnaProgrammata = DgConsegne.SelectedRows(0).DataBoundItem
            Dim CodTrack As String = Cons.CodTrack

            If CodTrack.Length Then
                If MessageBox.Show("Vuoi eliminare la registrazione al corriere GLS?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    MgrConsegneCorriere.GLS.EliminaRegistrazioneConsegna(Cons)
                End If
            Else
                MessageBox.Show("Codice tracking non presente!")
            End If
        End If

    End Sub

    Private Sub btnResoconto_Click(sender As Object, e As EventArgs) Handles btnResoconto.Click

        ParentFormEx.Sottofondo()

        Using f As New frmConsegnaGLSReportContrassegno
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()

    End Sub

End Class
