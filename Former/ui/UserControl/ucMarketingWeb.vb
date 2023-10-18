Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerBusinessLogic
Imports FormerConfig

Public Class ucMarketingWeb
    Inherits ucFormerUserControl
    Private Sub ucMarketingWeb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

        CaricaCombo()

    End Sub

    Private Sub ApriFiltroMarketing(Optional IdFM As Integer = 0)

        Dim TipoFiltro As enTipoFiltroMarketing = DirectCast(cmbTipoFiltro.SelectedItem, cEnum).Id

        Dim ris As Integer = 0

        If TipoFiltro = enTipoFiltroMarketing.SuTemplateFormer Then
            MessageBox.Show("Questo tipo di filtro non è ancora utilizzabile")
        Else
            ParentFormEx.Sottofondo()
            Using f As New frmMarketingFiltro

                ris = f.Carica(TipoFiltro, IdFM)

            End Using
            ParentFormEx.Sottofondo()
        End If

        If ris Then CaricaDati()

    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        ApriFiltroMarketing()

    End Sub

    Private Sub CaricaDati()
        Cursor.Current = Cursors.WaitCursor
        Using mgr As New FiltriMarketingDAO

            Dim c As cEnum = cmbTipoFiltro.SelectedItem

            Dim l As List(Of FiltroMarketing) = mgr.FindAll(LFM.FiltroMarketing.Nome,
                                                            New LUNA.LunaSearchParameter(LFM.FiltroMarketing.Stato, enStatoFiltroMarketing.Eliminato, "<>"),
                                                            New LUNA.LunaSearchParameter(LFM.FiltroMarketing.TipoFiltro, c.Id))

            dgMarkWeb.AutoGenerateColumns = False
            dgMarkWeb.DataSource = l

        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lnkRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked

        CaricaDati()

    End Sub

    Private Sub CaricaCombo()

        Dim LTipoFiltro As New List(Of cEnum)
        Dim voce As cEnum = New cEnum
        voce.Id = enTipoFiltroMarketing.SuListiniBase
        voce.Descrizione = "Email con Listini Base selezionati"
        LTipoFiltro.Add(voce)

        voce = New cEnum
        voce.Id = enTipoFiltroMarketing.SuFileHtml
        voce.Descrizione = "Email da file HTML preconfezionato"
        LTipoFiltro.Add(voce)

        voce = New cEnum
        voce.Id = enTipoFiltroMarketing.SuTemplateFormer
        voce.Descrizione = "Email da Template Former"
        LTipoFiltro.Add(voce)

        cmbTipoFiltro.DataSource = LTipoFiltro
        cmbTipoFiltro.DisplayMember = "Descrizione"
        cmbTipoFiltro.ValueMember = "Id"

        cmbTipoFiltro.SelectedIndex = 0

    End Sub

    Private Sub dgMarkWeb_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMarkWeb.CellDoubleClick
        If dgMarkWeb.SelectedRows.Count Then
            Dim FM As FiltroMarketing = dgMarkWeb.SelectedRows(0).DataBoundItem
            ApriFiltroMarketing(FM.IdFiltroMarketing)
        End If
    End Sub

    Private Sub lnkDelFiltro_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelFiltro.LinkClicked
        If dgMarkWeb.SelectedRows.Count Then
            If MessageBox.Show("Confermi l'eliminazione del filtro selezionato?", "Eliminazione Filtro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim SingVoce As FiltroMarketing = dgMarkWeb.SelectedRows(0).DataBoundItem

                SingVoce.Stato = enStatoFiltroMarketing.Eliminato
                SingVoce.Save()

                CaricaDati()
            End If
        End If
    End Sub

    Private Sub dgMarkWeb_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgMarkWeb.RowPostPaint
        Dim R As DataGridViewRow = dgMarkWeb.Rows(e.RowIndex)
        Dim F As FiltroMarketing = R.DataBoundItem

        If F.Stato = enStatoFiltroMarketing.Attivo Then
            R.Cells(0).Style.BackColor = Color.Green
        Else
            R.Cells(0).Style.BackColor = Color.Red
        End If
    End Sub

    Private Sub lnkDisattiva_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDisattiva.LinkClicked
        If dgMarkWeb.SelectedRows.Count Then
            Dim SingVoce As FiltroMarketing = dgMarkWeb.SelectedRows(0).DataBoundItem
            If SingVoce.Stato = enStatoFiltroMarketing.Attivo Then
                If MessageBox.Show("Confermi la disattivazione del filtro selezionato?", "Disattivazione Filtro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                    SingVoce.Stato = enStatoFiltroMarketing.NonAttivo
                    SingVoce.Save()

                    CaricaDati()
                End If
            Else
                MessageBox.Show("Il filtro selezionato è già non attivo")
            End If

        End If
    End Sub

    Private Sub lnkAttiva_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAttiva.LinkClicked
        If dgMarkWeb.SelectedRows.Count Then
            Dim SingVoce As FiltroMarketing = dgMarkWeb.SelectedRows(0).DataBoundItem
            If SingVoce.Stato = enStatoFiltroMarketing.NonAttivo Then
                If MessageBox.Show("Confermi l' attivazione del filtro selezionato?", "Attivazione Filtro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    SingVoce.Stato = enStatoFiltroMarketing.Attivo
                    SingVoce.Save()

                    CaricaDati()
                End If
            Else
                MessageBox.Show("Il filtro selezionato è già attivo")
            End If

        End If

    End Sub

    Private Sub lnkLog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLog.LinkClicked
        If dgMarkWeb.SelectedRows.Count Then
            Dim SingVoce As FiltroMarketing = dgMarkWeb.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi la creazione del log per il filtro selezionato?", "Log Filtro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Using mgr As New LogMarketingDAO

                    Dim buffer As String = String.Empty

                    Dim l As List(Of LogMarketing) = mgr.FindAll(LFM.LogMarketing.DataSent,
                                                                 New LUNA.LunaSearchParameter(LFM.LogMarketing.IdFm, SingVoce.IdFiltroMarketing),
                                                                 New LUNA.LunaSearchParameter(LFM.LogMarketing.Stato, enStatoEmail.Inviata))

                    For Each sing As LogMarketing In l
                        'qui faccio il log degli invii
                        Dim Nome As String = String.Empty
                        Dim Tel As String = String.Empty
                        Dim Email As String = String.Empty
                        Dim Citta As String = String.Empty

                        Dim R As New VoceRubG
                        R.Read(sing.IdRubG)
                        If R.IdRub Then
                            Dim V As New VoceRubrica
                            V.Read(R.IdRub)
                            Nome = V.RagSocNome
                            Tel = V.Tel
                            Email = V.Email
                            Citta = V.Citta
                        Else
                            Dim v As New VoceRubricaMarketing
                            v.Read(R.IdRubM)
                            Nome = v.NominativoG
                            Tel = v.Telefono
                            Email = v.Email
                            Citta = v.Citta
                        End If

                        Dim riga As String = sing.DataSent.ToString("dd/MM/yyyy HH:mm:ss") & " - " & Nome & " tel. " & Tel & ", email " & Email & " (" & Citta & ")"

                        buffer &= riga & ControlChars.NewLine
                    Next

                    Dim NomeFile As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".txt")
                    Using w As New StreamWriter(NomeFile)
                        w.Write(buffer)
                    End Using

                    Dim p As New Process
                    p.StartInfo.FileName = NomeFile
                    p.Start()

                End Using

            End If
        Else
            MessageBox.Show("Selezionare un filtro")
        End If


    End Sub

    Private Sub lnkNewTempl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub CreaRiepilogo()

        Dim buffer As String = "<font size=2 face=arial>"
        Dim Path As String = FormerPath.PathTemp & FormerHelper.File.GetNomeFileTemp(".htm")
        Using Mgr As New TemplateMarketingOfferteDAO

            Dim l As List(Of TemplateMarketingOfferte) = Mgr.GetAll("Mese asc")
            Dim IdMeseInCorso As Integer = 0
            buffer &= "<table border=1>"

            For Each TM As TemplateMarketingOfferte In l
                Dim TMO As New TMO
                TMO.Read(TM.IdTmOff)
                If IdMeseInCorso <> TMO.Mese Then
                    buffer &= "<tr><td colspan=4><b style=""color:red;"">" & FormerHelper.Calendario.MeseToString(TMO.Mese).ToUpper & "</b></td></tr>"
                    buffer &= "<tr><td><b style=""color:green;font-style:italic;"">Prodotto</b></td><td><b style=""color:green;font-style:italic;"">QTA</b></td><td><b style=""color:green;font-style:italic;"">Filtro</b></td><td><b style=""color:green;font-style:italic;"">Riservato a</b></td>"
                    IdMeseInCorso = TMO.Mese
                End If
                Using mgrL As New ListinoBaseSuTemplateDAO
                    Dim lLb As List(Of ListinoBaseSuTemplate) = mgrL.FindAll(LFM.ListinoBaseSuTemplate.IdTMLB,
                                                                             New LUNA.LunaSearchParameter(LFM.ListinoBaseSuTemplate.IdTmOff, TMO.IdTmOff))

                    For Each singL In lLb
                        buffer &= "<tr><td>" & singL.ListinoBase.Nome & "</td><td align=right>" & singL.Qta & "</td><td><i>" & TMO.FiltroMarketing.Nome & "</i></td><td><b>" & FormerEnumHelper.TipoRubricaStr(TMO.FiltroMarketing.TipoRub, enSiNo.No) & "</b></td>"
                    Next
                End Using
            Next
            buffer &= "</table>"

        End Using
        buffer &= "</font>"
        Using w As New StreamWriter(Path)
            w.Write(buffer)
        End Using

        webAnte.Navigate(Path)

    End Sub

    Private Sub lnkAggRiepilogo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggRiepilogo.LinkClicked
        CreaRiepilogo()
    End Sub

    Private Sub cmbTipoFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoFiltro.SelectedIndexChanged
        CaricaDati()
    End Sub
End Class
