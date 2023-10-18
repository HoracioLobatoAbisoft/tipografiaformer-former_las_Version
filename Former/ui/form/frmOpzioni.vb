Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogic

Public Class frmOpzioni
    'Inherits baseFormInternaFixed

    'Private Ult As DCLibrary.LiveUpdate.cRilasci
    Private _risultato As Boolean = False
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(btnColore)

    End Sub

    Public Function Carica(Optional ByVal ContrAgg As Boolean = False) As Boolean

        lblVer.Text = PostazioneCorrente.Versione
        lblRil.Text = PostazioneCorrente.Rilascio

        If ContrAgg Then
            'AggiornaClick()
            TabOpzioni.SelectedTab = tbUpdate
        End If

        'Dim x As New ProgressiviFiscali

        'x.Read(LUNA.LunaContext.IdNumerazioneDocumenti)

        'txtEmail.Text = Postazione.Email
        'txtEmailPwd.Text = Postazione.EmailPwd
        'txtPop3.Text = Postazione.Pop3Server
        'txtSmtp.Text = Postazione.SmtpServer
        'chkInvioMail.Checked = Postazione.InviaMail
        'chkDelMailOk.Checked = Postazione.CancellaMail
        'txtPathDB.Text = Postazione.PathDB
        'txtPathCommesse.Text = FormerPath.PathCommesse
        'txtPathTemp.Text = FormerPath.PathTemp
        'txtPathFatture.Text = FormerPath.PathFatture
        'txtPathCtp.Text = Postazione.PathCtp
        'txtPathLavorazioni.Text = Postazione.PathLavorazioni
        'txtPathJob.Text = Postazione.PathJob
        'txtPathImgListino.Text = Postazione.PathFileListino
        'txtNextFat.Text = MgrDocumentNumber.GetNextNumber(enTipoDocumento.Fattura)
        'txtNextDDT.Text = MgrDocumentNumber.GetNextNumber(enTipoDocumento.DDT)
        'txtNextPrev.Text = MgrDocumentNumber.GetNextNumber(enTipoDocumento.Preventivo)
        'txtPercIva.Text = FormerHelper.Finanziarie.GetPercentualeIva

        'MgrControl.SelectIndexCombo(cmbTimeout, Postazione.TimeoutCallerId)
        ''SelectIndexComboTesto(cmbTimeout, Postazione.TimeoutCallerId)
        'cmbTimeout.Text = Postazione.TimeoutCallerId
        'txtCom.Text = Postazione.PortaUDP
        ''txtComInit.Text = Postazione.ServerUDP
        'chkCom.Checked = Postazione.AttivaCallerId

        'txtCodCliBart.Text = Postazione.CodCliBart
        'txtNextProgrBart.Text = x.NextProgrBart

        ' x = Nothing

        caricaconfigstampanti
        CaricaStampantiDisponibili()

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then

            'TabOpzioni.TabPages.Remove(tbDocumenti)
            'TabOpzioni.TabPages.Remove(tbMailOrdini)
            'TabOpzioni.TabPages.Remove(tbPercorsi)
            'TabOpzioni.TabPages.Remove(tpSito)
            btnTabelle.Enabled = False

        End If

        'CaricaStampanti()

        'txtMargineXEtichette.Text = Postazione.MargineXEtichette
        ' txtMargineYEtichette.Text = Postazione.MargineyEtichette

        'If Postazione.StampanteEtichette.Length Then
        '    MgrControl.SelectIndexCombo(cmbStampanteEtichette, Postazione.StampanteEtichette)
        'Else
        '    cmbStampanteEtichette.SelectedIndex = 0
        'End If

        'If Postazione.StampanteFatture.Length Then
        '    MgrControl.SelectIndexCombo(cmbStampanteFatture, Postazione.StampanteFatture)
        'Else
        '    cmbStampanteFatture.SelectedIndex = 0
        'End If

        'If Postazione.StampanteLibera.Length Then
        '    MgrControl.SelectIndexCombo(cmbPrinterLibera, Postazione.StampanteLibera)
        'Else
        '    cmbPrinterLibera.SelectedIndex = 0
        'End If

        'If Postazione.StampanteConsegnaOrdini.Length Then
        '    MgrControl.SelectIndexCombo(cmbPrinterOrdini, Postazione.StampanteConsegnaOrdini)
        'Else
        '    cmbPrinterOrdini.SelectedIndex = 0
        'End If

        ShowDialog()

        Return _risultato

    End Function

    Private Sub CaricaConfigStampanti()

        lblStampanteFattureSrl.Text = FormerConfig.FConfiguration.Printer.FattureSrl
        lblStampanteFattureSnc.Text = FormerConfig.FConfiguration.Printer.FattureSnc
        lblStampanteEtichette.Text = FormerConfig.FConfiguration.Printer.Etichette
        lblStampanteGLS.Text = FormerConfig.FConfiguration.Printer.EtichetteGLS
        lblStampanteInfoLavori.Text = FormerConfig.FConfiguration.Printer.InfoLavori

    End Sub

    Private Sub CaricaStampantiDisponibili()

        For Each Stamp In FormerHelper.Printer.ElencoInstallate

            'cmbStampanteFatture.Items.Add(Stamp)
            cmbStampanti.Items.Add(Stamp)
            'cmbPrinterLibera.Items.Add(Stamp)
            'cmbPrinterOrdini.Items.Add(Stamp)

        Next

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If MessageBox.Show("Confermi il salvataggio delle impostazioni inserite? In caso affermativo il programma sarà riavviato.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ''salvo le impostazioni nuove
            'Postazione.Email = txtEmail.Text
            'Postazione.EmailPwd = txtEmailPwd.Text
            'Postazione.Pop3Server = txtPop3.Text
            'Postazione.SmtpServer = txtSmtp.Text
            'Postazione.InviaMail = chkInvioMail.Checked
            ''Postazione.CancellaMail = chkDelMailOk.Checked
            'Postazione.StampanteEtichette = cmbStampanteEtichette.Text
            'Postazione.MargineXEtichette = txtMargineXEtichette.Text
            'Postazione.MargineyEtichette = txtMargineYEtichette.Text
            ''Postazione.StampanteFatture = cmbStampanteFatture.Text
            ''Postazione.MargineXFatture = txtMargineXFatture.Text
            ''Postazione.MargineyFatture = txtMargineYFatture.Text

            'Postazione.StampanteLibera = cmbPrinterLibera.Text
            'Postazione.StampanteConsegnaOrdini = cmbPrinterOrdini.Text

            'Postazione.PathDB = txtPathDB.Text
            'FormerPath.PathCommesse = txtPathCommesse.Text
            'FormerPath.PathTemp = txtPathTemp.Text
            'FormerPath.PathFatture = txtPathFatture.Text
            'Postazione.PathCtp = txtPathCtp.Text
            'Postazione.PathJob = txtPathJob.Text
            'Postazione.PathFileListino = txtPathImgListino.Text
            'Postazione.PathLavorazioni = txtPathLavorazioni.Text

            'Postazione.CodCliBart = txtCodCliBart.Text

            'Postazione.PortaUDP = txtCom.Text
            'Postazione.ServerUDP = txtComInit.Text
            'Postazione.AttivaCallerId = chkCom.Checked

            'Postazione.TimeoutCallerId = cmbTimeout.Text

            'Postazione.StrConnWeb = txtStrConnWeb.Text
            'Postazione.FTPServerSito = txtFTPServer.Text
            'Postazione.FTPLoginSito = txtFTPLogin.Text
            'Postazione.FTPPwdSito = txtFTPPwd.Text

            'Dim x As New ProgressiviFiscali

            'x.Read(LUNA.LunaContext.IdNumerazioneDocumenti)
            'x.NextFat = txtNextFat.Text
            'x.NextDDT = txtNextDDT.Text
            'x.NextPrev = txtNextPrev.Text
            ''x.NextProgrBart = txtNextProgrBart.Text

            'x.Save()
            'x = Nothing

            'cPercIVA = txtPercIva.Text
            'Postazione.SaveXml()

            _risultato = True
            Close()

        End If

    End Sub



    'Private Sub EseguiAggiornamento()

    '    Try

    '        If MessageBox.Show("Vuoi iniziare l'aggiornamento? (il tempo richiesto dipende dalla velocità della connessione)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '            btnAggiorna.Enabled = False
    '            btnInformazioni.Enabled = False
    '            Cursor.Current = Cursors.WaitCursor

    '            'ciclo nella collezione degli aggiornamenti, li scarico, poi aggiorno l'id rilascio, risalvo il file ini e riavvio l'applicazione
    '            'qui ho caricato nell'oggetto Ult gli aggiornamenti 

    '            Dim MyRil As DCLibrary.LiveUpdate.cRilascio
    '            Dim i As Integer = 0

    '            For Each MyRil In Ult.Rilasci

    '                Dim Myagg As String
    '                Dim path As String = FormerPath.PathLocale & "update\" & MyRil.Id

    '                CreateLongDir(path)

    '                For Each Myagg In MyRil.Aggiornamenti

    '                    Dim FileToDown As String = Postazione.PathAggiornamenti & MyRil.Id & "/" & Myagg
    '                    lstAgg.Items(i) = Myagg & " - In download"
    '                    Refresh()
    '                    Postazione.DownloadFile(FileToDown, "update\" & MyRil.Id & "\" & Myagg)
    '                    lstAgg.Items(i) = Myagg & " - Scaricato"
    '                    Refresh()

    '                    i = i + 1
    '                Next
    '            Next

    '            i = 0
    '            'se arrivo qui tutti i file sono stati scaricati correttamente
    '            'ora devo applicare le varie modifiche
    '            For Each MyRil In Ult.Rilasci

    '                Dim Myagg As String

    '                For Each Myagg In MyRil.Aggiornamenti

    '                    Dim FileToDown As String = Postazione.PathAggiornamenti & MyRil.Id & "/" & Myagg
    '                    lstAgg.Items(i) = Myagg & " - Sto aggiornando..."
    '                    Refresh()
    '                    Postazione.AggiornaFile(MyRil.Id, Myagg)
    '                    lstAgg.Items(i) = Myagg & " - Aggiornato"
    '                    Refresh()

    '                    i = i + 1
    '                Next
    '            Next


    '            'salvo la situazione
    '            Postazione.Rilascio = Ult.LastRilascioId

    '            Postazione.SaveXml()

    '            _risultato = True

    '            Close()

    '            MessageBox.Show("Aggiornamento completato: " & vbNewLine & vbNewLine & Ult.Descr, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        End If


    '    Catch ex As Exception

    '        'qui c'e' stato un errore quindi non vado avanti e ritorno che non si è riusciti ad aprire la connessione

    '        btnAggiorna.Enabled = True
    '        Cursor.Current = Cursors.Default
    '        ManageError(ex, "Aggiornamento programma")
    '    End Try


    'End Sub

    'Private Sub btnAggiornamenti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiornamenti.Click

    '    AggiornaClick()

    'End Sub

    'Private Sub AggiornaClick()

    '    Try

    '        btnAggiorna.Enabled = False
    '        btnInformazioni.Enabled = False

    '        Cursor.Current = Cursors.WaitCursor

    '        btnAggiornamenti.Enabled = False
    '        lstAgg.Items.Clear()
    '        'scarico la collezione degli aggiornamenti
    '        Ult = Postazione.CaricaAggiornamenti()

    '        lblNewRil.Text = Ult.LastRilascioId

    '        Dim Myagg As DCLibrary.LiveUpdate.cRilascio

    '        For Each Myagg In Ult.Rilasci

    '            Dim filenome As String
    '            For Each filenome In Myagg.Aggiornamenti
    '                lstAgg.Items.Add(filenome)
    '            Next

    '        Next

    '        btnAggiornamenti.Enabled = True

    '        Cursor.Current = Cursors.Default

    '        If Ult.LastRilascioId > Postazione.Rilascio Then
    '            btnAggiorna.Enabled = True
    '            btnInformazioni.Enabled = True
    '        Else
    '            MessageBox.Show("Non sono disponibili nuovi aggiornamenti!", Postazione.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If


    '    Catch ex As Exception

    '        btnAggiornamenti.Enabled = True

    '        Cursor.Current = Cursors.Default
    '        ManageError(ex, "Controllo aggiornamenti")
    '    End Try


    'End Sub



    Private Sub txtMargineXEtichette_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MgrControl.ControlloNumerico(sender, e, True)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtNextFat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MgrControl.ControlloNumerico(sender, e, True)
    End Sub

    'Private Sub txtPercIva_LostFocus(sender As Object, e As System.EventArgs)
    '    If txtPercIva.TextLength = 0 Then txtPercIva.Text = FormerHelper.Finanziarie.GetPercentualeIva
    'End Sub

    Private Sub txtPercIva_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    'Private Sub btnColore_Click(sender As Object, e As EventArgs)
    '    ColorDialog.Color = Postazione.ColoreTema
    '    If ColorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        Postazione.ColoreTema = ColorDialog.Color
    '        'ColoraSfondo(btnColore)
    '    End If

    'End Sub

    'Private Sub btnFont_Click(sender As Object, e As EventArgs)
    '    ColorDialog.Color = Postazione.ColorePrimoPiano
    '    If ColorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        Postazione.ColorePrimoPiano = ColorDialog.Color
    '        'ColoraSfondo(btnColore)
    '    End If
    'End Sub

    Private Sub tbPercorsi_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnTabelle_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub txtMargineXEtichette_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox23_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnTabelle_Click_1(sender As Object, e As EventArgs) Handles btnTabelle.Click
        Sottofondo()

        Dim x As New frmOpzioniTabSec
        x.Carica()
        x = Nothing

        Sottofondo()
    End Sub

    Private Sub lnkTestPrn1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub StampaReticolo(Prn As String)
        If MessageBox.Show("Vuoi stampare un reticolo di prova su '" & Prn & "'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim p As New FormerPrinter.myFPrinter
            p.StampaReticolo(Prn)

            MessageBox.Show("Stampa reticolo effettuata")
        End If
    End Sub

    Private Sub lnkTestPrn3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub lnkTestPrn4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub lnkTestPrn5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub


    Private Sub lnkTestPrn7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub lnkCopyName_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub pctEdit1_Click(sender As Object, e As EventArgs) Handles pctEdit1.Click

        SalvaValore("Printer.FattureSrl", lblStampanteFattureSrl.Text)

    End Sub

    Private Sub SalvaValore(Chiave As String, ValorePredefinito As String)

        Dim Valore As String = String.Empty

        Valore = InputBox("Inserisci il valore locale per " & Chiave & "", "Configurazione custom", ValorePredefinito.Trim)

        If Valore.Length Then
            FormerConfig.FConfiguration.SaveValueToLocalSettings(Chiave, Valore)
            CaricaConfigStampanti()
        End If

    End Sub

    Private Sub pctEdit2_Click(sender As Object, e As EventArgs) Handles pctEdit2.Click
        SalvaValore("Printer.FattureSnc", lblStampanteFattureSnc.Text)
    End Sub

    Private Sub pctEdit3_Click(sender As Object, e As EventArgs) Handles pctEdit3.Click
        SalvaValore("Printer.Etichette", lblStampanteEtichette.Text)
    End Sub

    Private Sub pctEdit4_Click(sender As Object, e As EventArgs) Handles pctEdit4.Click
        SalvaValore("Printer.EtichetteGls", lblStampanteGLS.Text)
    End Sub

    Private Sub pctEdit5_Click(sender As Object, e As EventArgs) Handles pctEdit5.Click
        SalvaValore("Printer.InfoLavori", lblStampanteInfoLavori.Text)
    End Sub

    Private Sub btnApriLocale_Click(sender As Object, e As EventArgs) Handles btnApriLocale.Click

        Dim Path As String = PostazioneCorrente.PathDirectoryLocale & "\former.exe.config.local"

        FormerHelper.File.ShellExtended(Path)

    End Sub

    Private Sub pctRet6_Click(sender As Object, e As EventArgs) Handles pctRet6.Click
        StampaReticolo(cmbStampanti.Text)
    End Sub

    Private Sub pctRet1_Click(sender As Object, e As EventArgs) Handles pctRet1.Click
        StampaReticolo(lblStampanteFattureSrl.Text)
    End Sub

    Private Sub pctRet2_Click(sender As Object, e As EventArgs) Handles pctRet2.Click
        StampaReticolo(lblStampanteFattureSnc.Text)
    End Sub

    Private Sub pctRet3_Click(sender As Object, e As EventArgs) Handles pctRet3.Click
        StampaReticolo(lblStampanteEtichette.Text)
    End Sub

    Private Sub pctRet4_Click(sender As Object, e As EventArgs) Handles pctRet4.Click
        StampaReticolo(lblStampanteGLS.Text)
    End Sub

    Private Sub pctRet5_Click(sender As Object, e As EventArgs) Handles pctRet5.Click
        StampaReticolo(lblStampanteInfoLavori.Text)
    End Sub

    Private Sub PictureBox22_Click(sender As Object, e As EventArgs) Handles pctCopyName.Click
        Try
            Clipboard.SetText(cmbStampanti.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub pctDel1_Click(sender As Object, e As EventArgs) Handles pctDel1.Click
        FormerConfig.FConfiguration.DeleteLocalSettings("Printer.FattureSrl")
        CaricaConfigStampanti()
    End Sub

    Private Sub pctDel2_Click(sender As Object, e As EventArgs) Handles pctDel2.Click
        FormerConfig.FConfiguration.DeleteLocalSettings("Printer.FattureSnc")
        CaricaConfigStampanti()
    End Sub

    Private Sub pctDel3_Click(sender As Object, e As EventArgs) Handles pctDel3.Click
        FormerConfig.FConfiguration.DeleteLocalSettings("Printer.Etichette")
        CaricaConfigStampanti()
    End Sub

    Private Sub pctDel4_Click(sender As Object, e As EventArgs) Handles pctDel4.Click
        FormerConfig.FConfiguration.DeleteLocalSettings("Printer.EtichetteGls")
        CaricaConfigStampanti()
    End Sub

    Private Sub pctDel5_Click(sender As Object, e As EventArgs) Handles pctDel5.Click
        FormerConfig.FConfiguration.DeleteLocalSettings("Printer.InfoLavori")
        CaricaConfigStampanti()
    End Sub
End Class