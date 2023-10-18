Imports System.ComponentModel
Imports FormerConfig
Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmPreventivoMail
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _MailRif As PreventivoMail = Nothing

    Friend Function CaricaEx(MailRif As PreventivoMail) As Integer

        _MailRif = MailRif

        Dim Mittente As String = String.Empty
        If Not _MailRif.VoceRubrica Is Nothing Then
            Mittente = _MailRif.VoceRubrica.RagSocNome & " "
        End If

        Mittente &= "<" & _MailRif.Mittente & ">"

        lblTitolo.Text = Mittente & " - " & _MailRif.Titolo
        'txtInRisposta.Text = _MailRif.Testo

        If _MailRif.DalSito = enSiNo.Si OrElse (Not _MailRif.MailInizialeConversazione Is Nothing AndAlso _MailRif.MailInizialeConversazione.DalSito = enSiNo.Si) Then
            webPreview.Navigate("about:blank")
            webPreview.Document.OpenNew(False)
            webPreview.Document.Write(_MailRif.Testo)
            webPreview.Refresh()
            webPreview.Visible = True
            pnlPrezzo.Visible = True
            If _MailRif.DalSito = enSiNo.Si Then
                lblPrezzoSuggerito.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_MailRif.PrezzoSuggerito)
            Else
                lblPrezzoSuggerito.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_MailRif.MailInizialeConversazione.PrezzoSuggerito)
            End If
        Else
            txtInRisposta.Text = _MailRif.Testo
            webPreview.Visible = False
            pnlPrezzo.Visible = False
            lblPrezzoSuggerito.Text = "-"
        End If

        For Each alle As AttachPreventivoMail In _MailRif.Allegati
            Dim lv As New ListViewItem
            lv.ImageIndex = 4
            lv.Text = alle.NomeFile
            lv.Tag = alle.Path

            lvwAllegati.Items.Add(lv)
        Next

        Show()

    End Function

    '<Obsolete("Use CaricaEx no modal form")>
    'Friend Function Carica(MailRif As PreventivoMail) As Integer

    '    _MailRif = MailRif

    '    Dim Mittente As String = String.Empty
    '    If Not _MailRif.VoceRubrica Is Nothing Then
    '        Mittente = _MailRif.VoceRubrica.RagSocNome & " "
    '    End If

    '    Mittente &= "<" & _MailRif.Mittente & ">"

    '    lblTitolo.Text = Mittente & " - " & _MailRif.Titolo
    '    txtInRisposta.Text = _MailRif.Testo

    '    For Each alle As AttachPreventivoMail In _MailRif.Allegati
    '        Dim lv As New ListViewItem
    '        lv.ImageIndex = 4
    '        lv.Text = alle.NomeFile
    '        lv.Tag = alle.Path

    '        lvwAllegati.Items.Add(lv)
    '    Next

    '    ShowDialog()

    '    Return _Ris

    'End Function

    Private Sub lvwAllegati_DoubleClick(sender As Object, e As EventArgs) Handles lvwAllegati.DoubleClick
        If lvwAllegati.SelectedItems.Count Then
            Dim path As String = lvwAllegati.SelectedItems(0).Tag

            FormerLib.FormerHelper.File.ShellExtended(path)

        End If
    End Sub

    'Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    Dim x As Char = vbCr

    '    If e.KeyChar = x Then
    '        e.Handled = True
    '        SendKeys.Send(vbTab)

    '    End If
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtRisp.Text.Trim.Length Then
            If MessageBox.Show("Confermi l'invio della risposta?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim Soggetto As String = "Re: " & _MailRif.Titolo

                Dim Testo As String = txtRisp.Text

                Dim TestoHtml As String = FormerLib.FormerHelper.HTML.ConvertiTextToHtml(Testo)

                TestoHtml &= "<br><br><br><font face=""courier"">*********************************************************************************************************<br>"
                TestoHtml &= "IN CASO DI RISPOSTA A QUESTA EMAIL NON RIMUOVERE QUESTA RIGA FPGUID{$}<br>".Replace("$", _MailRif.GuidMail) & ControlChars.NewLine
                TestoHtml &= "*********************************************************************************************************</font>"

                TestoHtml &= "<br><br><br><i>" & _MailRif.Mittente & "</i> scriveva:<br>"

                If _MailRif.DalSito = enSiNo.Si OrElse (Not _MailRif.MailInizialeConversazione Is Nothing AndAlso _MailRif.MailInizialeConversazione.DalSito = enSiNo.Si) Then
                    TestoHtml &= _MailRif.Testo
                Else
                    TestoHtml &= "<i>" & FormerLib.FormerHelper.HTML.ConvertiTextToHtml(_MailRif.Testo) & "</i>"
                End If

                Dim MailInviata As Integer = FormerLib.FormerHelper.Mail.InviaMail(Soggetto,
                                                                                   TestoHtml,
                                                                                   _MailRif.Mittente,
                                                                                   FormerConfig.FConfiguration.PreventiviMail.EmailSender,,
                                                                                   txtAllegato1.Text, txtAllegato2.Text,,,
                                                                                   False,,, txtAllegato3.Text)

                If MailInviata Then
                    MessageBox.Show("Si è verificato un errore nell'invio della mail, riprovare")
                Else
                    Using m As New PreventivoMail

                        m.IdUtFormer = PostazioneCorrente.UtenteConnesso.IdUt

                        If Soggetto.Length > 255 Then
                            m.Titolo = Soggetto.Substring(0, 254)
                        Else
                            m.Titolo = Soggetto
                        End If
                        m.Testo = Testo
                        m.DataRif = Now
                        m.GuidMail = _MailRif.GuidMail
                        m.IdMailRif = _MailRif.IdMailPreventivo
                        m.Mittente = FormerConfig.FConfiguration.PreventiviMail.EmailSender
                        m.Letto = enSiNo.Si
                        m.Save()

                        If txtAllegato1.Text.Length Then
                            Dim NuovoPath As String = txtAllegato1.Text
                            Dim NomeFile As String = FormerLib.FormerHelper.File.EstraiNomeFile(NuovoPath)
                            NuovoPath = FormerPath.PathAttachMailPrev & m.IdMailPreventivo & "_1_" & NomeFile
                            MgrIO.FileCopia(Me, txtAllegato1.Text, NuovoPath)

                            Using All As New AttachPreventivoMail
                                All.IdMailPreventivo = m.IdMailPreventivo
                                All.NomeFile = NomeFile
                                All.Path = NuovoPath
                                All.Save()
                            End Using

                        End If

                        If txtAllegato2.Text.Length Then
                            Dim NuovoPath As String = txtAllegato2.Text
                            Dim NomeFile As String = FormerLib.FormerHelper.File.EstraiNomeFile(NuovoPath)
                            NuovoPath = FormerPath.PathAttachMailPrev & m.IdMailPreventivo & "_2_" & NomeFile
                            MgrIO.FileCopia(Me, txtAllegato2.Text, NuovoPath)

                            Using All As New AttachPreventivoMail
                                All.IdMailPreventivo = m.IdMailPreventivo
                                All.NomeFile = NomeFile
                                All.Path = NuovoPath
                                All.Save()
                            End Using

                        End If

                        If txtAllegato3.Text.Length Then
                            Dim NuovoPath As String = txtAllegato3.Text
                            Dim NomeFile As String = FormerLib.FormerHelper.File.EstraiNomeFile(NuovoPath)
                            NuovoPath = FormerPath.PathAttachMailPrev & m.IdMailPreventivo & "_3_" & NomeFile
                            MgrIO.FileCopia(Me, txtAllegato3.Text, NuovoPath)

                            Using All As New AttachPreventivoMail
                                All.IdMailPreventivo = m.IdMailPreventivo
                                All.NomeFile = NomeFile
                                All.Path = NuovoPath
                                All.Save()
                            End Using

                        End If

                    End Using

                    If chkLavorata.Checked Then
                        Using mgr As New PreventiviMailDAO
                            Dim l As List(Of PreventivoMail) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.PreventivoMail.GuidMail, _MailRif.GuidMail),
                                                                           New LUNA.LunaSearchParameter(LFM.PreventivoMail.IdMailRif, 0))

                            Using singmail As PreventivoMail = l(0)
                                singmail.Stato = enStatoPreventivoMail.Lavorata
                                singmail.Save()

                            End Using

                        End Using
                    End If
                    RicaricaDati = True
                    _Ris = 1
                    Close()
                End If
            End If
        Else
            MessageBox.Show("Inserire una risposta")
        End If


    End Sub

    Private Sub btnAllega_Click(sender As Object, e As EventArgs) Handles btnAllega.Click
        dlgAllegato.ShowDialog()

        If dlgAllegato.FileName.Length Then
            txtAllegato1.Text = dlgAllegato.FileName
        End If
    End Sub

    Private Sub btnAllega3_Click(sender As Object, e As EventArgs) Handles btnAllega3.Click
        dlgAllegato.ShowDialog()

        If dlgAllegato.FileName.Length Then
            txtAllegato3.Text = dlgAllegato.FileName
        End If
    End Sub

    Private Sub btnAllega2_Click(sender As Object, e As EventArgs) Handles btnAllega2.Click
        dlgAllegato.ShowDialog()

        If dlgAllegato.FileName.Length Then
            txtAllegato2.Text = dlgAllegato.FileName
        End If
    End Sub

    Private Sub frmPreventivoMail_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

    Public Property RicaricaDati As Boolean = False

    Private Sub btnCalcPrezzoLav_Click(sender As Object, e As EventArgs) Handles btnCalcPrezzoLav.Click
        Sottofondo()

        Using f As New frmCalcPrezzoLavorazioni
            f.Carica()
        End Using

        Sottofondo()
    End Sub
End Class