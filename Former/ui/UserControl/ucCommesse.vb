
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerDALSql.LUNA
Imports System.IO
Imports FormerConfig
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class ucCommesse
    Inherits ucFormerUserControl

    Public IdComSel As Integer

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        MgrControl.InizializeGridview(DgCommesseEx)

    End Sub

    Public Function Carica() As Integer
        'FormerDebug.Traccia("CARICAMENTO INIZIALE")
        Dim ris As Integer = 0
        Try

            If IdRepartoRiferimento <> enRepartoWeb.StampaOffset Then
                btnPrendiInCarico.Visible = True
                ToolStripSeparator3.Visible = False

                ApriAnteprimaPDFToolStrip.Visible = False
                ApriCartellaSorgentiCommessaToolStripMenuItem.Visible = False
                ApriJobCommessaToolStripMenuItem.Visible = False

                'lnkNew.Visible = True
            End If

            If IdRepartoRiferimento = enRepartoWeb.StampaDigitale Then
                lnkExportFlora.Visible = True
                rdExport.Visible = True
            End If

            CaricaCombo()
            If IdRepartoRiferimento = enRepartoWeb.StampaOffset Then
                CaricaMenuATendina()
            Else
                ForzaIlLavoroAlMacchinarioToolStripMenuItem.Visible = False
            End If

            UcStatoCommesse.Carica()

            'carico le commesse 
            ris = AvviaRicerca()
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return ris
    End Function

    Private _RepartoRiferimento As enRepartoWeb = enRepartoWeb.StampaOffset
    Public Property IdRepartoRiferimento As enRepartoWeb
        Get
            Return _RepartoRiferimento
        End Get
        Set(value As enRepartoWeb)
            _RepartoRiferimento = value
        End Set
    End Property

    Private Sub CaricaCombo()
        Try
            'carico la combo dei clienti
            'Using cli As New VociRubricaDAO
            '    cmbCliente.ValueMember = "IdRub"
            '    cmbCliente.DisplayMember = "Nominativo"

            '    cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, True)
            'End Using

            UcCmbCliente.Carica(enTipoRubrica.Cliente, True)

            'carico la combo dei macchinari
            'con i macchinari di produzione solo di questo reparto 

            Using mgr As New MacchinariDAO
                Dim LIdMacc As List(Of Macchinario) = mgr.GetIdMacchinariPerReparto(IdRepartoRiferimento,, True)
                cmbMacchinari.ValueMember = "IdMacchinario"
                cmbMacchinari.DisplayMember = "Descrizione"

                cmbMacchinari.DataSource = LIdMacc
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Public Function AvviaRicerca(Optional ByVal Showall As Boolean = False) As Integer

        Dim ris As Integer = 0

        Cursor.Current = Cursors.WaitCursor

        Using Mgr As New CommesseDAO
            Dim l As List(Of CommessaRicerca)

            ' Dim x As New cCommesseColl

            If Showall Then

                Dim ParReparti As LunaSearchParameter = Nothing
                Dim ParMacchinario As LunaSearchParameter = Nothing

                ParReparti = New LunaSearchParameter(LFM.Commessa.IdReparto, IdRepartoRiferimento)

                Dim ParUltimoMese As LunaSearchParameter = Nothing

                'If chkUltimoMese.Checked Then
                '    ParUltimoMese = New LUNA.LunaSearchParameter("datediff(""d"",DataIns,GetDate())", 30, "<=")
                'End If


                'If Not Lav.LavLogRealizzazione Is Nothing Then

                l = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdCom DESC"},
                                ParReparti,
                                ParUltimoMese)


                If cmbMacchinari.SelectedValue Then

                    l = l.FindAll(Function(x) x.IdMacchinario = cmbMacchinari.SelectedValue Or (Not x.LavLogRealizzazione Is Nothing AndAlso x.LavLogRealizzazione.IdMacchinario = cmbMacchinari.SelectedValue))

                    'ParMacchinario = New LUNA.LunaSearchParameter(LFM.Commessa.IdMacchinario, cmbMacchinari.SelectedValue)
                End If



            Else

                Dim Cod As String = txtCerca.Text

                If Cod = "{inserire qui il codice}" Then

                    Cod = ""

                End If

                l = Mgr.Lista(Cod,
                              UcCmbCliente.IdRubSelezionato,
                              UcStatoCommesse.StatiSelezionati,
                              IdRepartoRiferimento,
                              ,
                              cmbMacchinari.SelectedValue)

                RaiseEvent CommessaSelezionata()

            End If

            'DgCommesse.AutoGenerateColumns = False
            'DgCommesse.DataSourceVirtual = l

            'DgCommesse.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgCommesse.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgCommesse.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgCommesse.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgCommesse.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'DgCommesse.Columns(3).DefaultCellStyle.SelectionForeColor = Color.Red
            'DgCommesse.Columns(3).DefaultCellStyle.ForeColor = Color.Red

            lblNumRis.Text = l.Count
            ris = l.Count

            'DgCommesse.ClearSelection()

            DgCommesseEx.DataSource = l


            Cursor.Current = Cursors.Default

        End Using

        Return ris

    End Function

    Private Sub lnkCerca_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        Try
            AvviaRicerca()
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked

        'Try
        'Dim O As Ordine
        'O.Read(1)
        'Catch ex As Exception
        'ManageError(ex)
        'End Try

        'AvviaRicerca(True)
        Cursor.Current = Cursors.WaitCursor
        UcStatoCommesse.CheckSuTutti()
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub txtCerca_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCerca.MouseClick

        If txtCerca.Text = "{inserire qui il codice}" Then

            txtCerca.Text = ""

        End If

    End Sub

    Public Event CommessaSelezionata()

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        Using frmRif As New frmCommessa

            Dim Ris As Integer = 0
            ParentFormEx.Sottofondo()
            Ris = frmRif.Carica(,,, IdRepartoRiferimento)
            ParentFormEx.Sottofondo()

        End Using

    End Sub


    Private Sub UcStatoCommesse_CambiatoStato() Handles UcStatoCommesse.CambiatoStato
        Try
            AvviaRicerca()
        Catch ex As Exception
            'ManageError(ex)
        End Try

    End Sub

    Private Sub AnteprimaPDF(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If DgCommesseEx.SelectedRows.Count Then

            Dim Dr As GridViewRowInfo
            Dr = DgCommesseEx.SelectedRows(0)
            Dim c As Commessa = Dr.DataBoundItem

            Dim PathToOpen As String = FormerPath.PathCommesse & c.IdCom & "\" & sender.text
            FormerHelper.File.ShellExtended(PathToOpen)
        End If
    End Sub

    Private Sub PrioritàNormaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub AllegaUnMessaggioAllaCommessaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AllegaUnMessaggioAllaCommessaToolStripMenuItem.Click
        If DgCommesseEx.SelectedRows.Count Then
            Dim c As Commessa = DgCommesseEx.SelectedRows(0).DataBoundItem
            ParentFormEx.Sottofondo()
            Using f As New frmPostit
                f.Carica(, c.IdCom)
            End Using
            ParentFormEx.Sottofondo()
        End If

    End Sub

    'Private Sub DgCommesse_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgCommesse.ColumnHeaderMouseClick
    '    OrdinatoreLista(Of CommessaRicerca).OrdinaLista(sender, e)
    'End Sub

    Private Sub UcRepartoWeb_SelezioneCambiata()
        Try
            AvviaRicerca()
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Private Sub txtCerca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCerca.KeyPress

        If e.KeyChar = vbCr Then

            AvviaRicerca()

        End If

    End Sub

    Private Sub btnPrendiInCarico_Click(sender As Object, e As EventArgs) Handles btnPrendiInCarico.Click

        If DgCommesseEx.SelectedRows.Count Then

            Using Commessa As Commessa = DgCommesseEx.SelectedRows(0).DataBoundItem
                Commessa.Refresh()

                'qui ho la commessa 
                'devo trovare il primo lavoro non eseguito e aprire la maschera operatore
                Dim GoOn As Boolean = True

                If Commessa.Stato = enStatoCommessa.Preinserito Then

                    If Commessa.IdReparto = enRepartoWeb.StampaDigitale Then
                        Commessa.CaricaMovimentiMagazzino()

                        If Commessa.MovMagaz.Count = 0 Then
                            GoOn = False
                        Else
                            If MessageBox.Show("La commessa selezionata è in stato PREINSERITO, si vuole portare direttamente allo stato PRONTA e proseguire?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Using mC As New CommesseDAO
                                    mC.InserisciLog(Commessa, enStatoCommessa.Pronto, PostazioneCorrente.UtenteConnesso.IdUt)
                                End Using
                                Commessa.Refresh()
                            Else
                                GoOn = False
                            End If
                        End If

                    Else
                        GoOn = False
                    End If

                End If

                If GoOn Then
                    Using mgr As New LavLogDAO

                        Dim Lavoro As ILavoroOperatore = Nothing

                        Dim lInC As List(Of LavLog) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Ordine"},
                                                                New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, Commessa.IdCom),
                                                                New LUNA.LunaSearchParameter(LFM.LavLog.IdUt, PostazioneCorrente.UtenteConnesso.IdUt),
                                                                New LUNA.LunaSearchParameter(LFM.LavLog.DataOraInizio, Nothing, " Is Not "),
                                                                New LUNA.LunaSearchParameter(LFM.LavLog.DataOraFine, Nothing, " Is "))

                        If lInC.Count Then
                            'qui vuoldire che c'e' una lavorazione in corso di questo utente 
                            Dim Lav As ILavoroOperatore = lInC(0)
                            If Lav.PrendibileInCarico(PostazioneCorrente.UtenteConnesso.IdUt) Then
                                Lavoro = Lav
                            End If
                        Else
                            Dim l As List(Of LavLog) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Ordine"},
                                                                    New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, Commessa.IdCom),
                                                                    New LUNA.LunaSearchParameter(LFM.LavLog.DataOraInizio, Nothing, " Is "))

                            For Each Lav As ILavoroOperatore In l

                                If Lav.PrendibileInCarico(PostazioneCorrente.UtenteConnesso.IdUt) Then
                                    Lavoro = Lav
                                    Exit For
                                End If

                            Next
                        End If

                        If Not Lavoro Is Nothing Then
                            Dim Ris As Integer = 0
                            Using frm As New frmOperatoreNew
                                ParentFormEx.Sottofondo()
                                Ris = frm.Carica(Lavoro)
                                ParentFormEx.Sottofondo()
                                If Ris Then
                                    AvviaRicerca()
                                End If
                            End Using
                        Else
                            MessageBox.Show("Non ci sono lavorazioni effettuabili sulla commessa selezionata")
                        End If

                    End Using
                Else
                    MessageBox.Show("La Commessa è in stato PREINSERITO, non può essere presa in carico")
                End If
            End Using
        Else
            MessageBox.Show("Selezionare una Commessa")
        End If

    End Sub

    'Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

    '    If cmbCliente.SelectedValue = 0 Then
    '        chkUltimoMese.Checked = True
    '    Else
    '        chkUltimoMese.Checked = False
    '    End If

    'End Sub

    Private Sub ExportMacchinarioDigitale(IdMacchinario As Integer)


        Dim Buffer As String = String.Empty
        'Dim path As String = String.Empty
        'path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\CsvAnapurna\"

        Using mgr As New CommesseDAO
            Dim l As List(Of Commessa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Commessa.TipoCom, enRepartoWeb.StampaDigitale),
                                                     New LUNA.LunaSearchParameter(LFM.Commessa.Stato, enStatoCommessa.Preinserito),
                                                     New LUNA.LunaSearchParameter(LFM.Commessa.IdMacchinario, IdMacchinario)) ' FormerConst.Macchinari.IdFlora))
            Using M As New Macchinario
                M.Read(IdMacchinario)
                If l.Count Then
                    For Each C As Commessa In l
                        Dim Riga As String = String.Empty
                        Dim Note As String = String.Empty
                        For Each O As Ordine In C.ListaOrdini
                            If O.ListinoBase.TipoCarta.HotFolder.Length Then
                                Dim Path As String = O.ListinoBase.TipoCarta.HotFolder
                                If Path.EndsWith("\") = False Then Path &= "\"

                                'If O.DescrizioneCliente.Length >= 8 Then
                                '    Note = O.DescrizioneCliente.Substring(0, 7)
                                'Else
                                '    Note = O.DescrizioneCliente
                                'End If
                                'Note = IIf(O.DescrizioneCliente.Length >= 8, O.DescrizioneCliente.Substring(0, 7), O.DescrizioneCliente) & "-"


                                For Each s As FileSorgente In O.ListaSorgenti
                                    Dim NomeFileSorg As String = FormerHelper.File.EstraiNomeFile(s.FilePath)
                                    'If NomeFileSorg.Length >= 8 Then NomeFileSorg = NomeFileSorg.Substring(0, 8)
                                    'Note &= NomeFileSorg
                                    'Dim Materiale As String = String.Empty
                                    'Materiale = O.ListinoBase.TipoCarta.Tipologia
                                    Dim PathDest As String = Path '& 'Materiale & "\"
                                    'FormerLib.FormerHelper.File.CreateLongPath(PathDest)
                                    PathDest &= NomeFileSorg
                                    MgrIO.FileCopia(Me.ParentForm, s.FilePath, PathDest)
                                Next

                                'Using mgr As New CommesseDAO
                                mgr.InserisciLog(C, enStatoCommessa.Pronto, PostazioneCorrente.UtenteConnesso.IdUt)
                                'End Using

                                'Riga = C.Lungo & ";" & C.Largo & ";" & C.Copie & ";" & O.ListinoBase.TipoCarta.Tipologia & ";1;" & Note & ";;;;;" & O.DescrizioneCliente & ";" & ControlChars.NewLine
                                '150;150;1;FOREX 3;1;note;;;;;cliente;

                                ''qui lo salvo dentro un file 
                                'FormerLib.FormerHelper.File.CreateLongPath(Path)

                                'Dim NomeFile As String = Now.ToString("ddMMyyyy-hhmmss") & ".csv"
                                'Path = Path & "\" & NomeFile
                                'Using w As New StreamWriter(Path, True)
                                '    w.Write(Riga)
                                'End Using
                            End If

                        Next
                        Buffer &= Riga
                    Next
                    MessageBox.Show("Export Completato!")


                Else
                    MessageBox.Show("Non ci sono commesse " & M.Descrizione & " in stato preinserito da esportare")
                End If
            End Using

        End Using
    End Sub

    Private Sub lnkCsvAnapurna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkExportFlora.LinkClicked

        If MessageBox.Show("Confermi l'export?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ExportMacchinarioDigitale(FormerConst.Macchinari.IdFlora)
        End If

    End Sub

    Private Sub ApriJobCommessaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriJobCommessaToolStripMenuItem.Click
        If DgCommesseEx.SelectedRows.Count Then
            Dim c As Commessa = DgCommesseEx.SelectedRows(0).DataBoundItem
            Dim Path As String = FormerHelper.File.TranslateRealDrivePath(FormerPath.PathCommesse) & c.IdCom & "\" & c.IdCom & ".job" '(c.ModelloCommessa.Job)

            If File.Exists(Path) Then

                'qui devo vedere dentro il file se usare il preps8 o quello di default sul sistema (il 5) 

                Dim UsePreps8 As Boolean = False

                Using r As New StreamReader(Path)
                    Dim Buffer As String = r.ReadToEnd

                    If Buffer.IndexOf("%%Creator: Preps 5") = -1 Then
                        UsePreps8 = True
                    End If

                End Using

                'If c.ModelloCommessa.FromGanging = enSiNo.Si Then UsePreps8 = True

                If UsePreps8 Then
                    Dim PathPreps8 As String = FormerConfig.FormerPath.PathPreps8

                    If PathPreps8 = "\" Then
                        'qui provo a farlo 
                        dlgFolder.SelectedPath = "C:\"
                        dlgFolder.Description = "Seleziona la cartella dove si trova il file eseguibile di Preps8 (Preps8.exe)"

                        If dlgFolder.ShowDialog() = DialogResult.OK Then
                            Dim PathPreps8New As String = dlgFolder.SelectedPath & "\preps8.exe"

                            If File.Exists(PathPreps8New) Then
                                PathPreps8 = PathPreps8New
                                FormerConfig.FConfiguration.SaveValueToLocalSettings("Path.Preps8", PathPreps8)
                            Else
                                MessageBox.Show("Impossibile trovare il file eseguibile Preps8.exe nel path specificato")
                            End If

                        End If

                    End If
                    FormerHelper.File.ShellExtended(PathPreps8, Path) 'ma qui in realta devo lanciare il ganging del preps8 se presente 
                Else
                    FormerHelper.File.ShellExtended(Path)
                End If

            Else
                MessageBox.Show("Impossibile trovare il file JOB per questa commessa")
            End If

        End If
    End Sub

    Private Sub ApriCartellaSorgentiCommessaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriCartellaSorgentiCommessaToolStripMenuItem.Click
        If DgCommesseEx.SelectedRows.Count Then
            Dim c As Commessa = DgCommesseEx.SelectedRows(0).DataBoundItem
            Dim Path As String = FormerPath.PathCommesse & c.IdCom & "\" '& c.IdCom & ".job" '(c.ModelloCommessa.Job)

            If Directory.Exists(Path) Then
                FormerHelper.File.ShellExtended(Path)
            Else
                MessageBox.Show("Impossibile trovare la cartella dei sorgenti per questa commessa")
            End If

        End If
    End Sub

    Private Sub NormaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormaleToolStripMenuItem.Click
        If MessageBox.Show("Vuoi impostare la commessa selezionata a Priorità Normale?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Using c As Commessa = DgCommesseEx.SelectedRows(0).DataBoundItem
                c.Refresh()
                c.Priorita = enSiNo.No
                c.Save()
            End Using

            AvviaRicerca()
        End If
    End Sub

    Private Sub AltaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaToolStripMenuItem.Click
        If MessageBox.Show("Vuoi impostare la commessa selezionata ad Alta Priorità?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim c As Commessa = DgCommesseEx.SelectedRows(0).DataBoundItem
            c.Refresh()
            c.Priorita = enSiNo.Si
            c.Save()
            AvviaRicerca()
        End If
    End Sub

    Private Sub CreaAnteprimaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreaAnteprimaToolStripMenuItem.Click

        If DgCommesseEx.SelectedRows.Count Then
            Dim c As Commessa = DgCommesseEx.SelectedRows(0).DataBoundItem

            MgrCommesse.CreaAnteprima(Me.ParentFormEx, c.IdCom,, True)

        End If

    End Sub

    Private Sub MandaAlFlussoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MandaAlFlussoToolStripMenuItem.Click

        If DgCommesseEx.SelectedRows.Count Then
            Dim c As Commessa = DgCommesseEx.SelectedRows(0).DataBoundItem

            'forzo la rilettura dell'oggetto per controllare 
            Dim OkStato As Boolean = True
            Using CNew As New Commessa
                CNew.Read(c.IdCom)

                If c.Stato <> CNew.Stato AndAlso CNew.Stato = enStatoCommessa.Pronto Then
                    If MessageBox.Show("Confermi l'invio al flusso per la commessa? La commessa selezionata risulta in stato PRONTO", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        OkStato = False
                    End If
                End If

            End Using

            If OkStato Then
                If c.FromJob = enSiNo.Si Then
                    MgrCommesse.CreaAnteprima(Me.ParentFormEx, c.IdCom,
                                              True, True)

                    'CommesseMgr.MandaAlFlusso(Me.ParentFormEx, c.IdCom)
                Else
                    MgrCommesse.CreaAnteprima(Me.ParentFormEx, c.IdCom,, True)
                End If
            End If

        End If

    End Sub

    Private Sub DgCommesse_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DgCommesseEx_Click(sender As Object, e As EventArgs) Handles DgCommesseEx.Click

    End Sub

    Private Sub DgCommesseEx_SelectionChanged(sender As Object, e As EventArgs) Handles DgCommesseEx.SelectionChanged
        Try
            If DgCommesseEx.SelectedRows.Count Then
                Dim rig As GridViewRowInfo
                rig = DgCommesseEx.SelectedRows(0)

                Dim c As Commessa = rig.DataBoundItem
                If c.IdCom <> IdComSel Then
                    rig.IsSelected = True
                    'rig.Cells(1).Style.BackColor = Color.White
                    DgCommesseEx.Select()

                    IdComSel = c.IdCom

                    RaiseEvent CommessaSelezionata()

                    Try
                        If sender.focused Then
                            FormPrincipale.UcToolbarMain.ShowNote(c.Annotazioni)
                        End If
                    Catch ex As Exception

                    End Try

                End If
            End If
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Private Sub DgCommesseEx_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgCommesseEx.CellFormatting
        'qui sono state aggiunte delle righe calcolo il numero ore
        Try

            If e.CellElement.ColumnInfo.Name = "Stato" Then
                Dim Riga As GridViewRowInfo = e.Row
                Using C As CommessaRicerca = Riga.DataBoundItem
                    Dim ColoreSfondo As Color = C.Colore
                    e.CellElement.BackColor = ColoreSfondo
                    lblNumCopie.Text = C.Copie
                End Using
            Else
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
            End If
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub
    Private Sub DgCommesseEx_MouseClick(sender As Object, e As MouseEventArgs) Handles DgCommesseEx.MouseClick

        If DgCommesseEx.SelectedRows.Count Then

            Dim Dr As GridViewRowInfo

            Dr = DgCommesseEx.SelectedRows(0)

            If Not Dr Is Nothing Then
                Dim c As CommessaRicerca = Dr.DataBoundItem
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Dim x As System.Drawing.Point = MousePosition

                    'btnNuovoCliente.ContextMenu = menuNuovo.
                    'x.X -= 200
                    '                    DgOrdini.Select( )

                    Dr.IsSelected = True

                    If c.Priorita = enSiNo.Si Then
                        AltaToolStripMenuItem.Enabled = False
                        NormaleToolStripMenuItem.Enabled = True
                    Else
                        AltaToolStripMenuItem.Enabled = True
                        NormaleToolStripMenuItem.Enabled = False
                    End If

                    Dim Path As String = FormerPath.PathCommesse & c.IdCom & "\" & c.IdCom & ".jdf"

                    If File.Exists(Path) Then
                        CreaAnteprimaToolStripMenuItem.Enabled = True
                        MandaAlFlussoToolStripMenuItem.Enabled = True
                    Else
                        MandaAlFlussoToolStripMenuItem.Enabled = False
                        CreaAnteprimaToolStripMenuItem.Enabled = False
                    End If

                    ApriAnteprimaPDFToolStrip.DropDownItems.Clear()

                    If Directory.Exists(FormerPath.PathCommesse & c.IdCom & "\") Then
                        Dim d As New DirectoryInfo(FormerPath.PathCommesse & c.IdCom & "\")
                        Dim lF As FileInfo() = d.GetFiles("*.pdf")
                        'Array.Sort(lF)
                        For Each f As FileInfo In lF
                            Dim rgx As Regex = New Regex("^" & c.IdCom & ".[0-9]{1}[A-Z]{1}.pdf|.PDF")
                            Dim m As Match = rgx.Match(f.Name)
                            If m.Success Then ApriAnteprimaPDFToolStrip.DropDownItems.Add(f.Name, Nothing, AddressOf AnteprimaPDF)
                        Next
                    End If

                    If ApriAnteprimaPDFToolStrip.DropDownItems.Count Then
                        ApriAnteprimaPDFToolStrip.Enabled = True
                    Else
                        ApriAnteprimaPDFToolStrip.Enabled = False
                    End If
                    MenuOrd.Show(x)

                End If

            End If
        End If
    End Sub
    Private Sub DgCommesseEx_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgCommesseEx.MouseDoubleClick

        If e.Button = Windows.Forms.MouseButtons.Left Then

            RiapriCommessa()


        End If

    End Sub

    Private Sub ForzaMacchinarioSuLavoro(sender As Object, e As EventArgs)
        If DgCommesseEx.SelectedRows.Count Then
            Dim Lav As CommessaRicerca = DgCommesseEx.SelectedRows(0).DataBoundItem

            If Not Lav.LavLogRealizzazione Is Nothing Then
                If Lav.LavLogRealizzazione.IdUtInCarico = 0 Then 'qui solo su quelle non ancora finite
                    If Lav.LavLogRealizzazione.IdMacchinario <> sender.tag Then
                        If MessageBox.Show("Confermi lo spostamento del lavoro sul macchinario selezionato? ", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Using M As New Macchinario
                                M.Read(sender.tag)
                                Lav.LavLogRealizzazione.IdMacchinario = M.IdMacchinario
                                Lav.LavLogRealizzazione.Macchinario = M.Descrizione

                                Lav.LavLogRealizzazione.Save()
                            End Using


                            MessageBox.Show("Il lavoro è stato assegnato al macchinario selezionato")
                            AvviaRicerca()
                        End If
                    Else
                        MessageBox.Show("Il lavoro è gia previsto sul macchinario selezionato")

                    End If

                Else
                    MessageBox.Show("Il Lavoro è gia stato iniziato")
                End If
            Else
                MessageBox.Show("Impossibile trovare la lavorazione di stampa")
            End If

        Else
            Beep()
        End If
    End Sub

    Private Sub CaricaMenuATendina()

        Using mgr As New MacchinariDAO
            Dim l As List(Of Macchinario) = mgr.FindAll(New LunaSearchOption With {.OrderBy = LFM.Macchinario.Descrizione.Name},
                                                        New LunaSearchParameter(LFM.Macchinario.Tipo, enTipoMacchinario.Produzione))

            ForzaIlLavoroAlMacchinarioToolStripMenuItem.DropDownItems.Clear()

            For Each singMacc As Macchinario In l

                Dim t As New ToolStripMenuItem(singMacc.Riassunto(True))
                t.Tag = singMacc.IdMacchinario
                AddHandler t.Click, AddressOf ForzaMacchinarioSuLavoro
                ForzaIlLavoroAlMacchinarioToolStripMenuItem.DropDownItems.Add(t)
            Next
        End Using

    End Sub


    Private Sub RiapriCommessa()

        If DgCommesseEx.SelectedRows.Count Then

            'riapro l'ordine in modifica
            Dim rig As GridViewRowInfo = DgCommesseEx.SelectedRows(0)
            Dim c As CommessaRicerca = rig.DataBoundItem
            rig.IsSelected = True
            DgCommesseEx.Select()

            IdComSel = c.IdCom

            Using frmRif As New frmCommessa
                Dim Ris As Integer = 0

                ParentFormEx.Sottofondo()
                Ris = frmRif.Carica(IdComSel)
                ParentFormEx.Sottofondo()
                If Ris Then AvviaRicerca()
            End Using
        End If

    End Sub

    Private Sub UnisciSelezionateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnisciSelezionateToolStripMenuItem.Click

        'provo a unire le commesse selezionate
        Dim ListaCommesse As New List(Of Commessa)
        For Each riga In DgCommesseEx.SelectedRows
            ListaCommesse.Add(riga.DataBoundItem)
        Next

        If MgrCommesse.UnisciCommesse(ListaCommesse) Then AvviaRicerca()

    End Sub

    Private Sub MnuFlora_Click(sender As Object, e As EventArgs) Handles mnuFlora.Click
        If MessageBox.Show("Confermi l'export?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ExportMacchinarioDigitale(FormerConst.Macchinari.IdFlora)
        End If
    End Sub

    Private Sub MnuExportEpson_Click(sender As Object, e As EventArgs) Handles mnuExportEpson.Click
        If MessageBox.Show("Confermi l'export?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ExportMacchinarioDigitale(FormerConst.Macchinari.IdEpsonT7000)
        End If
    End Sub

    Private Sub ModificaCommessaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaCommessaToolStripMenuItem.Click
        RiapriCommessa()
    End Sub



End Class
