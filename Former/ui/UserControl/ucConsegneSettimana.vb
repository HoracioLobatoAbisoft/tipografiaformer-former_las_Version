Imports FormerDALSql
Imports FormerLib.FormerEnum
Public Class ucConsegneSettimana
    Inherits ucFormerUserControl
    Private _DataRif As Date = Now.Date

    Private Sub ucConsegneSettimana_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

        If LUNA.LunaContext.TotConnAttive Then UcStatoOrdiniAdvanced.Carica("LAVORAZIONE")

        cmbGiorni.SelectedIndex = 2


    End Sub

    'Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ParentFormerForm.Sottofondo 

    '    Dim x As New frmConsProgrNuova
    '    If x.Carica() Then CaricaDati(_DataRif)
    '    x = Nothing

    '    ParentFormerForm.Sottofondo 
    'End Sub

    Public Sub Carica(Optional ByVal DataRif As Date = Nothing)
        ' FormerDebug.Traccia("CARICAMENTO INIZIALE")
        If DataRif = Nothing Then DataRif = Date.Now

        'If Postazione.UtenteConnesso.Tipo = enTipoUtente.Operatore Then
        tabOrdini.TabPages.Remove(tpPreviste)
        'End If
        _DataRif = DataRif

        CaricaCombo()

        'UcAlberoConsegnePreviste.Carica(True)
        UcAlberoConsegneProgrammate.Carica(False)
        UcConsegneGlsAdmin.Carica()

        If PostazioneCorrente.CaricamentiAutomatici Then CaricaDati(_DataRif)

    End Sub

    Private Sub CaricaCombo()
        Dim ValTemp As Integer = 0
        If cmbCliente.SelectedValue Then
            ValTemp = cmbCliente.SelectedValue
        End If

        Using cli As New VociRubricaDAO
            cmbCliente.ValueMember = "IdRub"
            cmbCliente.DisplayMember = "Nominativo"

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, True, "CONSPROGR")
        End Using
        If ValTemp Then MgrControl.SelectIndexCombo(cmbCliente, ValTemp)

        If cmbCorriere.DataSource Is Nothing Then

            Using Corriere As New CorrieriDAO
                cmbCorriere.ValueMember = "IdCorriere"
                cmbCorriere.DisplayMember = "Descrizione"
                cmbCorriere.DataSource = Corriere.GetListaCorrieri(True) ' Corriere.GetAll("Descrizione", True)
            End Using
        End If

        If cmbOperatore.DataSource Is Nothing Then
            Using mgr As New UtentiDAO
                Dim Operatori As List(Of Utente) = mgr.GetAll(LFM.Utente.Login, True)

                cmbOperatore.ValueMember = "IdUt"
                cmbOperatore.DisplayMember = "Login"
                cmbOperatore.DataSource = Operatori
            End Using
        End If

        If cmbZona.DataSource Is Nothing Then
            Using mgr As New ZoneDAO
                Dim Zone As List(Of Zona) = mgr.GetAll(LFM.Zona.Descrizione, True)
                cmbZona.ValueMember = "Id"
                cmbZona.DisplayMember = "Descrizione"
                cmbZona.DataSource = Zone
            End Using
        End If

    End Sub

    Private Sub CaricaDati(ByVal DataRif As Date, Optional VaiAInizioSettimana As Boolean = True)

        If cmbCorriere.SelectedValue = enCorriere.GLS _
            Or cmbCorriere.SelectedValue = enCorriere.PortoAssegnatoGLS _
            Or cmbCorriere.SelectedValue = enCorriere.GLSIsole _
            Or cmbCorriere.SelectedValue = enCorriere.Bartolini _
            Or cmbCorriere.SelectedValue = enCorriere.PortoAssegnatoBartolini Then
            chkCorrRegistratiInConsegna.Visible = True
            chkCorrRegistratiProntiConsegna.Visible = True
        Else
            chkCorrRegistratiInConsegna.Visible = False
            chkCorrRegistratiProntiConsegna.Visible = False
            chkCorrRegistratiInConsegna.Checked = False
            chkCorrRegistratiProntiConsegna.Checked = False
        End If

        LastUseUltimaSettimana = VaiAInizioSettimana
        _DataRif = DataRif
        'qui carico i vari giorni partendo dal giorno di oggi
        'mi porto al lunedi in base al giorno in cui sto 
        Dim Diff As Integer = 0
        Dim primoGiorno As Date
        If VaiAInizioSettimana Then
            Select Case DataRif.Date.DayOfWeek
                Case DayOfWeek.Sunday
                    primoGiorno = DataRif.Date.AddDays(-6)
                Case Else
                    Diff = -(DataRif.Date.DayOfWeek - 1)
                    primoGiorno = DataRif.Date.AddDays(Diff)
            End Select
            _DataRif = primoGiorno
        Else
            primoGiorno = DataRif
        End If

        Dim Lunedi As Date = primoGiorno
        'If Lunedi.DayOfWeek = DayOfWeek.Sunday Then Lunedi = Lunedi.AddDays(1)
        Dim Martedi As Date = Lunedi.AddDays(1)
        If Martedi.DayOfWeek = DayOfWeek.Sunday Then Martedi = Martedi.AddDays(1)
        Dim Mercoledi As Date = Martedi.AddDays(1)
        If Mercoledi.DayOfWeek = DayOfWeek.Sunday Then Mercoledi = Mercoledi.AddDays(1)
        Dim Giovedi As Date = Mercoledi.AddDays(1)
        If Giovedi.DayOfWeek = DayOfWeek.Sunday Then Giovedi = Giovedi.AddDays(1)
        Dim Venerdi As Date = Giovedi.AddDays(1)
        If Venerdi.DayOfWeek = DayOfWeek.Sunday Then Venerdi = Venerdi.AddDays(1)
        Dim Sabato As Date = Venerdi.AddDays(1)
        If Sabato.DayOfWeek = DayOfWeek.Sunday Then Sabato = Sabato.AddDays(1)

        ' Dim IdCli As Integer = cmbCliente.SelectedValue
        '   Dim IdCom As Integer = cmbCommessa.SelectedValue
        ' Dim IdCorr As Integer = cmbCorriere.SelectedValue

        '  Dim ListaStati As String = UcStatoOrdini.StatiSelezionati
        UcConsegneGiornoLunedi.IdCorr = cmbCorriere.SelectedValue
        UcConsegneGiornoMartedi.IdCorr = cmbCorriere.SelectedValue
        UcConsegneGiornoMercoledi.IdCorr = cmbCorriere.SelectedValue
        UcConsegneGiornoGiovedi.IdCorr = cmbCorriere.SelectedValue
        UcConsegneGiornoVenerdi.IdCorr = cmbCorriere.SelectedValue
        UcConsegneGiornoSabato.IdCorr = cmbCorriere.SelectedValue


        Dim ListaStati As String = UcStatoOrdiniAdvanced.StatiSelezionati

        Dim SoloRegistratiCorriere As Boolean = False
        If chkCorrRegistratiInConsegna.Checked Or chkCorrRegistratiProntiConsegna.Checked Then
            SoloRegistratiCorriere = True
        End If


        UcConsegneGiornoLunedi.Carica(Lunedi,
                                      cmbCliente.SelectedValue,
                                      ListaStati,
                                      cmbZona.SelectedValue,
                                      cmbOperatore.SelectedValue,
                                      SoloRegistratiCorriere)
        UcConsegneGiornoMartedi.Carica(Martedi,
                                       cmbCliente.SelectedValue,
                                       ListaStati, cmbZona.SelectedValue,
                                       cmbOperatore.SelectedValue,
                                       SoloRegistratiCorriere)
        UcConsegneGiornoMercoledi.Carica(Mercoledi,
                                         cmbCliente.SelectedValue,
                                         ListaStati,
                                         cmbZona.SelectedValue,
                                         cmbOperatore.SelectedValue,
                                         SoloRegistratiCorriere)
        UcConsegneGiornoGiovedi.Carica(Giovedi,
                                       cmbCliente.SelectedValue,
                                       ListaStati,
                                       cmbZona.SelectedValue,
                                       cmbOperatore.SelectedValue,
                                       SoloRegistratiCorriere)
        UcConsegneGiornoVenerdi.Carica(Venerdi,
                                       cmbCliente.SelectedValue,
                                       ListaStati,
                                       cmbZona.SelectedValue,
                                       cmbOperatore.SelectedValue,
                                       SoloRegistratiCorriere)
        UcConsegneGiornoSabato.Carica(Sabato,
                                      cmbCliente.SelectedValue,
                                      ListaStati,
                                      cmbZona.SelectedValue,
                                      cmbOperatore.SelectedValue,
                                      SoloRegistratiCorriere)

    End Sub
    Private LastUseUltimaSettimana As Boolean = True
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiorna.Click

        CaricaDati(_DataRif, LastUseUltimaSettimana)
        CaricaCombo()
    End Sub

    Private GiorniToMove As Integer = 1

    Private Sub btnIndietro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIndietro.Click

        If cmbGiorni.Text.Length Then
            GiorniToMove = cmbGiorni.Text
        End If

        Cursor.Current = Cursors.WaitCursor
        Dim NewGiorno As Date = _DataRif.AddDays(-GiorniToMove)
        If NewGiorno.DayOfWeek = DayOfWeek.Sunday Then NewGiorno = NewGiorno.AddDays(-1)
        CaricaDati(NewGiorno, False)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnAvanti_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAvanti.Click

        If cmbGiorni.Text.Length Then
            GiorniToMove = cmbGiorni.Text
        End If

        Cursor.Current = Cursors.WaitCursor
        Dim NewGiorno As Date = _DataRif.AddDays(GiorniToMove)
        If NewGiorno.DayOfWeek = DayOfWeek.Sunday Then NewGiorno = NewGiorno.AddDays(1)
        CaricaDati(NewGiorno, False)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnEspandi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEspandi.Click

        UcConsegneGiornoLunedi.EspandiTutto()
        UcConsegneGiornoMartedi.EspandiTutto()
        UcConsegneGiornoMercoledi.EspandiTutto()
        UcConsegneGiornoGiovedi.EspandiTutto()
        UcConsegneGiornoVenerdi.EspandiTutto()
        UcConsegneGiornoSabato.EspandiTutto()

    End Sub

    Private Sub btnComprimi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComprimi.Click
        UcConsegneGiornoLunedi.CollassaTutto()
        UcConsegneGiornoMartedi.CollassaTutto()
        UcConsegneGiornoMercoledi.CollassaTutto()
        UcConsegneGiornoGiovedi.CollassaTutto()
        UcConsegneGiornoVenerdi.CollassaTutto()
        UcConsegneGiornoSabato.CollassaTutto()

    End Sub

    Private Sub lnkOggi_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub SDragStart(sender As Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim tree As TreeView = CType(sender, TreeView)

            Dim node As TreeNode
            node = tree.GetNodeAt(e.X, e.Y)

            tree.SelectedNode = node
            If Not node Is Nothing Then
                If node.Name.StartsWith("O") Then
                    tree.DoDragDrop(node.Clone(), DragDropEffects.Move)
                End If

            End If
        End If

    End Sub
    Private Sub tvClienti_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        SDragStart(sender, e)
    End Sub

    Private Sub tvClienti_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs)

    End Sub

    Private Sub tvClienti_NodeMouseDoubleClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
        Dim Node As TreeNode = e.Node
        If Node.Name.StartsWith("O") Then
            ParentFormEx.Sottofondo()
            Dim IdOrd As Integer = Node.Name.Substring(1)
            Dim f As New frmOrdine
            f.Carica(IdOrd)
            ParentFormEx.Sottofondo()
        End If


    End Sub

    Private Sub UcConsegneGiornoMartedi_Load(sender As System.Object, e As System.EventArgs) Handles UcConsegneGiornoMartedi.Load

    End Sub

    Private Sub UcConsegneGiornoMartedi_MouseHover(sender As Object, e As System.EventArgs) Handles UcConsegneGiornoMartedi.MouseHover

    End Sub

    Private Sub UcConsegneGiornoLunedi_Load(sender As System.Object, e As System.EventArgs) Handles UcConsegneGiornoLunedi.Load

    End Sub



    Private Sub UcConsegneGiornoLunedi_OrdineTrascinato(sender As Object, senderDest As ucConsegneGiorno) Handles UcConsegneGiornoLunedi.OrdineTrascinato, _
        UcConsegneGiornoMartedi.OrdineTrascinato, _
        UcConsegneGiornoMercoledi.OrdineTrascinato, _
        UcConsegneGiornoGiovedi.OrdineTrascinato, _
        UcConsegneGiornoVenerdi.OrdineTrascinato, _
        UcConsegneGiornoSabato.OrdineTrascinato

        'CaricaDati(sender.Giorno)
        'RICARICO QUELLO DI DESTINAZIONE 
        Dim ListaStati As String = UcStatoOrdiniAdvanced.StatiSelezionati

        Dim SoloRegistratiCorriere As Boolean = False
        If chkCorrRegistratiInConsegna.Checked Or chkCorrRegistratiProntiConsegna.Checked Then
            SoloRegistratiCorriere = True
        End If

        senderDest.Carica(senderDest.Giorno, cmbCliente.SelectedValue,
                                       ListaStati, cmbZona.SelectedValue,
                                       cmbOperatore.SelectedValue,
                                       SoloRegistratiCorriere)

        'Dim x As TreeView = sender

        'Dim o = sender.tag

        'ChiaveNodoStart = ChiaveNodoStart
        'sender.carica()

        ' Dim tv As TreeView = sender
        'tv.Nodes.Remove(tv.SelectedNode)
        ' DirectCast(tv.Parent.Parent.Parent, Object).carica()

        ' UcAlberoConsegnePreviste.Carica(True)
        ' UcAlberoConsegneProgrammate.Carica(False)

    End Sub

    Private Sub UcConsegneGiornoMercoledi_Load(sender As System.Object, e As System.EventArgs) Handles UcConsegneGiornoMercoledi.Load

    End Sub

    Private Sub UcAlberoConsegneProgrammate_CambiataDataSelezionata() Handles UcAlberoConsegneProgrammate.CambiataDataSelezionata
        CaricaDati(UcAlberoConsegneProgrammate.DataSelezionata)
    End Sub

    Private Sub UcAlberoConsegnePreviste_CambiataDataSelezionata() Handles UcAlberoConsegnePreviste.CambiataDataSelezionata
        CaricaDati(UcAlberoConsegnePreviste.DataSelezionata)
    End Sub



    Private Sub UcAlberoConsegnePreviste_ClienteSelezionato(sender As System.Object) Handles UcAlberoConsegnePreviste.ClienteSelezionato,
        UcAlberoConsegneProgrammate.ClienteSelezionato,
        UcConsegneGiornoLunedi.ClienteSelezionato,
        UcConsegneGiornoMartedi.ClienteSelezionato,
        UcConsegneGiornoMercoledi.ClienteSelezionato,
        UcConsegneGiornoGiovedi.ClienteSelezionato,
        UcConsegneGiornoVenerdi.ClienteSelezionato,
        UcConsegneGiornoSabato.ClienteSelezionato


        Dim Txt As String = sender.TestoSelezionato
        UcConsegneGiornoLunedi.Evidenzia(Txt)
        UcConsegneGiornoMartedi.Evidenzia(Txt)
        UcConsegneGiornoMercoledi.Evidenzia(Txt)
        UcConsegneGiornoGiovedi.Evidenzia(Txt)
        UcConsegneGiornoVenerdi.Evidenzia(Txt)
        UcConsegneGiornoSabato.Evidenzia(Txt)
    End Sub

    Private Sub UcAlberoConsegnePreviste_CreateAutomaticamenteConsegne() Handles UcAlberoConsegnePreviste.CreateAutomaticamenteConsegne
        'qui devo ricaricare l'albero delle consegne della settimana
        CaricaDati(_DataRif)
    End Sub

    Private Sub UcAlberoConsegnePreviste_FiltroApplicato() Handles UcAlberoConsegnePreviste.FiltroApplicato
        If MgrControl.SelectIndexCombo(cmbCliente, UcAlberoConsegnePreviste.IdRubFiltro) = -1 Then
            MessageBox.Show("Il cliente selezionato non ha consegne programmate")
        End If
        CaricaDati(_DataRif)
    End Sub

    Private Sub UcAlberoConsegnePreviste_FiltroCancellato() Handles UcAlberoConsegnePreviste.FiltroCancellato
        MgrControl.SelectIndexCombo(cmbCliente, 0)
        CaricaDati(_DataRif)
    End Sub

    Private Sub UcAlberoConsegnePreviste_Load(sender As System.Object, e As System.EventArgs) Handles UcAlberoConsegnePreviste.Load

    End Sub

    Private Sub dtPickCons_ValueChanged(sender As Object, e As EventArgs) Handles dtPickCons.ValueChanged
        Dim NewGiorno As Date = dtPickCons.Value
        If NewGiorno.DayOfWeek = DayOfWeek.Sunday Then NewGiorno = NewGiorno.AddDays(-6)
        CaricaDati(NewGiorno)
    End Sub

    Private Sub UcStatoOrdiniAdvanced_CambiatoStato() Handles UcStatoOrdiniAdvanced.CambiatoStato
        CaricaDati(_DataRif)
    End Sub

    Private Sub UcStatoOrdiniAdvanced_Load(sender As Object, e As EventArgs) Handles UcStatoOrdiniAdvanced.Load

    End Sub

    Private Sub UcAlberoConsegneProgrammate_Load(sender As Object, e As EventArgs) Handles UcAlberoConsegneProgrammate.Load

    End Sub

    Private Sub UcAlberoConsegnePreviste_OrdineSelezionato(Sender As Object) Handles UcAlberoConsegnePreviste.OrdineSelezionato, UcAlberoConsegneProgrammate.OrdineSelezionato
        Dim Txt As String = Sender.TestoSelezionato
        UcConsegneGiornoLunedi.Evidenzia(Txt)
        UcConsegneGiornoMartedi.Evidenzia(Txt)
        UcConsegneGiornoMercoledi.Evidenzia(Txt)
        UcConsegneGiornoGiovedi.Evidenzia(Txt)
        UcConsegneGiornoVenerdi.Evidenzia(Txt)
        UcConsegneGiornoSabato.Evidenzia(Txt)
    End Sub

    Private Sub cmbCorriere_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCorriere.SelectedIndexChanged
        If cmbCorriere.SelectedValue = enCorriere.GLS _
            Or cmbCorriere.SelectedValue = enCorriere.PortoAssegnatoGLS _
            Or cmbCorriere.SelectedValue = enCorriere.GLSIsole _
            Or cmbCorriere.SelectedValue = enCorriere.Bartolini _
            Or cmbCorriere.SelectedValue = enCorriere.PortoAssegnatoBartolini Then
            chkCorrRegistratiInConsegna.Visible = True
            chkCorrRegistratiProntiConsegna.Visible = True
        Else
            chkCorrRegistratiInConsegna.Visible = False
            chkCorrRegistratiProntiConsegna.Visible = False
        End If
    End Sub

    Private Sub chkCorrRegistratiInConsegna_CheckedChanged(sender As Object, e As EventArgs) Handles chkCorrRegistratiInConsegna.CheckedChanged, chkCorrRegistratiProntiConsegna.CheckedChanged
        If chkCorrRegistratiInConsegna.Checked And chkCorrRegistratiProntiConsegna.Checked Then
            UcStatoOrdiniAdvanced.Carica("CORRIEREINCONSEGNAPRONTICONSEGNA")
        ElseIf chkCorrRegistratiInConsegna.Checked = False And chkCorrRegistratiProntiConsegna.Checked = False Then
            UcStatoOrdiniAdvanced.Carica("LAVORAZIONE")
        Else
            'ListaStati = ""
            If chkCorrRegistratiInConsegna.Checked Then
                'ListaStati &= enStatoOrdine.InConsegna & ","
                UcStatoOrdiniAdvanced.Carica("CORRIEREINCONSEGNA")
            End If
            If chkCorrRegistratiProntiConsegna.Checked Then
                'ListaStati &= enStatoOrdine.ProntoRitiro & ","
                UcStatoOrdiniAdvanced.Carica("CORRIEREPRONTICONSEGNA")
            End If
            'ListaStati = ListaStati.TrimEnd(",")
        End If
    End Sub
End Class
