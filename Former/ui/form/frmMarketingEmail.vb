Imports System.IO
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig

Friend Class frmMarketingEmail
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Dim _Anteprima As String = ""
    Dim _IdMark As Integer = 0
    Dim _IdRub As Integer = 0
    Dim _IdEmail As Integer = 0
    Dim _IdGruppo As Integer = 0
    Dim _IdMarkProg As Integer = 0
    Dim _IdFm As Integer = 0

    Friend Sub Riapri(ByVal Email As Email)
        RiapriP(Email)
    End Sub

    'Friend Sub Riapri(ByVal IdEmail As Integer)

    '    Dim Mgr As New EmailDAO()
    '    Dim Email As Email = Mgr.Read(IdEmail)

    '    Mgr = Nothing

    '    RiapriP(Email)

    'End Sub

    Private Sub RiapriP(ByRef Email As Email)

        btnOk.Visible = False
        txtTestoMail.ReadOnly = True
        txtTitolo.ReadOnly = True
        txtTitolo.Text = Email.Titolo
        txtTestoMail.Text = Email.Testo
        Dim Rub As New VoceRubrica
        Rub.Read(Email.IdRubDest)

        lblDestinatario.Text = Rub.Email
        Rub = Nothing
        lblStatus.Text = "Spedita il " & Email.Quando
        cmbTipoProd.Enabled = False
        Email = Nothing
        MostraAnteprima()
        ShowDialog()

    End Sub


    Friend Function Carica(Optional ByVal IdEMail As Integer = 0,
                           Optional ByVal IdRub As Integer = 0,
                           Optional ByVal IdMark As Integer = 0,
                           Optional ByVal IdMarkProgr As Integer = 0,
                           Optional ByVal IdFm As Integer = 0) As Integer

        _IdRub = IdRub
        _IdMark = IdMark
        _IdEmail = IdEMail
        _IdMarkProg = IdMarkProgr
        _IdFm = IdFm
        'carico i template
        Dim filetemp As FileInfo
        Dim dirtemp As New DirectoryInfo(FormerPath.PathTemplateMarketing)

        UcInfoBoxModelli.HelpText = UcInfoBoxModelli.HelpText.Replace("$", FormerPath.PathTemplateMarketing)

        cmbTipoProd.Items.Add("Seleziona un template da cui copiare il contenuto")

        For Each filetemp In dirtemp.GetFiles("*.htm*")

            cmbTipoProd.Items.Add(StrConv(filetemp.Name, VbStrConv.ProperCase))

        Next

        cmbTipoProd.SelectedIndex = 0

        If _IdRub Then

            Using Rub As New VoceRubrica
                Rub.Read(IdRub)
                lblDestinatario.Text = "Contatto: " & Rub.RagSoc & " (" & Rub.Email & ")"
            End Using

        ElseIf _IdMark Then

            Using Mark As New CampagnaMarketing
                Mark.Read(_IdMark)
                _IdGruppo = Mark.IdGruppo

                Using Gruppo As New Gruppo
                    Gruppo.Read(_IdGruppo)
                    lblDestinatario.Text = "Gruppo: " & Gruppo.Nome
                End Using
            End Using
        ElseIf IdFm Then
            Using fm As New FiltroMarketing
                fm.Read(IdFm)
                lblDestinatario.Text = fm.Nome
            End Using
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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If txtTitolo.Text.Length = 0 Then
            MessageBox.Show("Inserire il titolo della mail!", "Invio mail marketing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If txtTestoMail.Text.Length = 0 Then
            MessageBox.Show("Inserire il testo della mail!", "Invio mail marketing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show("Confermi l'operazione di invio mail?", "Invio mail marketing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Cursor.Current = Cursors.WaitCursor
            'Dim sw As New StreamReader(Postazione.PathTemplate & cmbTipoProd.Text, System.Text.Encoding.ASCII)

            'BodyMail = sw.ReadToEnd()

            'sw.Close()
            'sw = Nothing
            btnOk.Enabled = False
            Dim BufferRiport As String = ""
            If _IdRub Then

                'qui la mando a un singolo
                BufferRiport = InvioMailMark(_IdRub)
                MessageBox.Show("Email inviate", "Invio mail marketing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf _IdGruppo Then

                'qui invio la  mail al gruppo 
                'Dim dt As DataTable, dr As DataRow
                'Using mgr As New VociRubricaDAO
                '    dt = mgr.ListaGruppo(_IdGruppo)
                'End Using

                Using G As New Gruppo
                    G.Read(_IdGruppo)
                    Dim l As List(Of IVoceRubricaG)
                    Using mgr As New VociRubGDAO

                        l = mgr.GetAllVoceRubG(G)

                        l = mgr.ApplicaFiltro(l, G)
                        If MessageBox.Show("Verranno inviate " & l.Count & " email. Confermi?", "Conferma invio email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Dim Id As Integer = 1
                            For Each dr In l
                                Application.DoEvents()
                                BufferRiport &= InvioMailMark(dr, Id, l.Count)
                                If BufferRiport.Length Then BufferRiport &= ControlChars.NewLine
                                Id += 1
                                lblStatus.Text = "Inviata mail " & Id & " di " & l.Count & " (" & dr.EmailG & ")"
                            Next
                            MessageBox.Show("Email inviate", "Invio mail marketing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using

            ElseIf _IdFm Then
                'qui invio la mail al filtro di marketing 

                Dim l As List(Of IVoceRubricaG)
                Using mgr As New VociRubGDAO

                    l = mgr.GetAllVoceRubG()

                    Using F As New FiltroMarketing
                        F.Read(_IdFm)
                        l = mgr.ApplicaFiltro(l, F)

                        If MessageBox.Show("Verranno inviate " & l.Count & " email. Confermi?", "Conferma invio email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Dim Id As Integer = 1

                            Dim tm As New TemplateMarketing
                            tm.Titolo = txtTitolo.Text
                            tm.Path = ""
                            tm.Save()

                            For Each c As IVoceRubricaG In l
                                Application.DoEvents()

                                'qui salvo il log di marketing 
                                Using lm As New LogMarketing
                                    lm.DataIns = Now
                                    lm.IdTemplateMarketing = tm.IdTemplateMarketing
                                    lm.IdFm = F.IdFiltroMarketing
                                    lm.IdRubG = c.IdRubG
                                    lm.NTent = 0
                                    lm.Stato = enStatoEmail.DaInviare
                                    lm.Save()
                                End Using

                            Next
                            MessageBox.Show("Email inviate", "Invio mail marketing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using

                End Using

            End If
            Cursor.Current = Cursors.Default

            'If BufferRiport.Length Then
            ''qui c'e' stato qualche errore e lo devo riportare

            'MessageBox.Show("Sono state inviate delle email ma sono stati riscontrati alcuni errori.", "Invio mail marketing", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Dim X As New Random
            'Dim NomeFile As String = FormerPath.PathLocale & "Err" & X.Next(0, 100000).ToString & ".txt"

            'PostazioneCorrente.ScriviLogFile(NomeFile, BufferRiport)

            'FormerHelper.File.ShellExtended(NomeFile)

            'Else

            'End If


            Close()
        End If
    End Sub

    Private Function InvioMailMark(RubG As IVoceRubricaG,
                                   Optional ByVal RigaCorr As Integer = 1,
                                   Optional ByVal NumMail As Integer = 1) As String
        Dim BodyMail As String = txtTestoMail.Text
        Dim Ris As String = ""

        If RubG.EmailG.Length Then

            'Ris = SendMail(emailDest, txtTitolo.Text, BodyMail, "", True, True)
            'lblStatus.Text = "Mail " & RigaCorr & "/" & NumMail & ": " & emailDest
            Dim IdMarkAz As Integer = 0

            If RubG.ProvenienzaVoce = "R" Then
                If _IdMarkProg = 0 Then
                    Dim xMk As New AzioneMarketing
                    xMk.IdMarketing = _IdMark
                    xMk.IdRub = RubG.IdRubRif
                    xMk.TipoAzione = enTipoAzMarketing.InvioMail
                    xMk.Quando = Now
                    xMk.Annotazioni = txtTitolo.Text
                    IdMarkAz = xMk.Save()
                Else
                    IdMarkAz = _IdMarkProg
                End If
            End If

            Dim em As New Email
            em.IdMarketing = IdMarkAz

            If RubG.ProvenienzaVoce = "R" Then
                em.IdRubDest = RubG.IdRubRif
                em.IdRubMarketing = 0
            Else
                em.IdRubDest = 0
                em.IdRubMarketing = RubG.IdRubRif
            End If
            em.Quando = Date.MinValue
            em.Testo = BodyMail
            em.Titolo = txtTitolo.Text
            em.Save()

            Dim l As New LogMarketing
            l.IdEmail = em.IdEmail
            l.DataIns = Now
            l.Stato = enStatoEmail.DaInviare
            l.Save()

        End If
        Return Ris
    End Function

    Private Function InvioMailMark(ByVal IdRub As Integer,
                                   Optional ByVal RigaCorr As Integer = 1,
                                   Optional ByVal NumMail As Integer = 1) As String
        Dim BodyMail As String = txtTestoMail.Text
        Dim emailDest As String = ""
        Dim Rub As New VoceRubrica
        Rub.Read(IdRub)
        If Rub.IdRub Then emailDest = Rub.Email
        Dim Ris As String = ""
        Rub = Nothing
        If emailDest.Length Then

            'Ris = SendMail(emailDest, txtTitolo.Text, BodyMail, "", True, True)
            'lblStatus.Text = "Mail " & RigaCorr & "/" & NumMail & ": " & emailDest
            Dim IdMarkAz As Integer = 0

            If _IdMarkProg = 0 Then
                Dim xMk As New AzioneMarketing
                xMk.IdMarketing = _IdMark
                xMk.IdRub = IdRub
                xMk.TipoAzione = enTipoAzMarketing.InvioMail
                xMk.Quando = Now
                xMk.Annotazioni = txtTitolo.Text
                IdMarkAz = xMk.Save()
            Else
                IdMarkAz = _IdMarkProg
            End If

            Dim em As New Email
            em.IdMarketing = IdMarkAz
            em.IdRubDest = IdRub
            em.Quando = Date.MinValue
            em.Testo = BodyMail
            em.Titolo = txtTitolo.Text
            em.Save()

            Dim l As New LogMarketing
            l.IdEmail = em.IdEmail
            l.DataIns = Now
            l.Stato = enStatoEmail.DaInviare
            l.Save()

        End If
        Return Ris
    End Function

    Private Sub MostraAnteprima()

        Dim PathTemp As String = FormerPath.PathLocale & "tempEmail.htm"
        Dim W As New StreamWriter(PathTemp)
        W.Write(txtTestoMail.Text)
        W.Close()
        webAnteprima.Navigate(PathTemp)

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then

            MostraAnteprima()
        End If
    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoProd.SelectedIndexChanged
        If cmbTipoProd.SelectedIndex > 0 Then

            'qui devo aprire il template e caricarlo all'interno del testo
            Dim x As New StreamReader(FormerPath.PathTemplateMarketing & cmbTipoProd.Text)
            Dim testo = x.ReadToEnd
            x.Close()
            txtTestoMail.Text = testo

        End If
    End Sub
End Class