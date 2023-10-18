Imports System.Xml
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib

Friend Class frmPrev

    Public formSopra As cFormSopra
    Private _Ris As Integer
    Private _IdListinoBase As Integer = 0

    Friend Function Carica(TipoLavoro As String, _
                           Codice As String, _
                           Qta As String, _
                           Pagine As String, _
                           Stampa As String, _
                           Formato As String, _
                           Carta As String, _
                           Lavorazioni As String, _
                           Consegna As Integer, _
                           IdListinoBase As Integer, _
                           PrzNetto As Decimal) As Integer
        CaricaCombo()

        _IdListinoBase = IdListinoBase

        txtTipoLav.Text = TipoLavoro
        txtCodice.Text = Codice
        txtQta.Text = Qta
        txtPag.Text = Pagine
        txtStampa.Text = Stampa
        txtFormatoAp.Text = Formato
        txtCarta.Text = Carta
        txtLavoraz.Text = Lavorazioni
        SelectIndexCombo(cmbCorr, Consegna)


        txtPrezzo.Text = PrzNetto


        ShowDialog()

        Return _Ris

    End Function

    Friend Function Carica(Optional ByVal Codice As String = "") As Integer

        CaricaCombo()

        'SelectIndexCombo(cmbCorr, Postazione.IdCorr)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using cli As New VociRubricaDAO
            cmbCli.ValueMember = "IdRub"
            cmbCli.DisplayMember = "Nominativo"

            cmbCli.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, False)
        End Using

        Using Corriere As New CorrieriDAO

            cmbCorr.ValueMember = "IdCorriere"
            cmbCorr.DisplayMember = "Descrizione"
            cmbCorr.DataSource = Corriere.GetAll("IdCorriere", True)
        End Using
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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi l'inserimento del preventivo?", "Invio Preventivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Try

                btnOk.Enabled = False
                btnCancel.Enabled = False

                Cursor.Current = Cursors.WaitCursor

                If OrdineValido() Then

                    'qui l'ordine e' valido 
                    'e invio la mail di ordine

                    'creo il file xml, poi carico gli allegati e infine carico il file xml nell'area ordini
                    Dim Prev As New Preventivo
                    Prev.IdRub = cmbCli.SelectedValue
                    Prev.Numero = txtNumero.Text
                    Prev.TipoLavoro = txtTipoLav.Text
                    Prev.Qta = txtQta.Text
                    Prev.Pagine = txtPag.Text
                    Prev.Stampa = txtStampa.Text
                    Prev.FormatoAperto = txtFormatoAp.Text
                    Prev.FormatoChiuso = txtFormatoCh.Text
                    Prev.Carta = txtCarta.Text
                    Prev.Lavorazioni = txtLavoraz.Text
                    Prev.IdCorr = cmbCorr.SelectedValue
                    Prev.IdListinoBase = _IdListinoBase
                    Prev.Codice = txtCodice.Text
                    Prev.PrezzoNetto = txtPrezzo.Text
                    Prev.Iva = txtIva.Text
                    Prev.Sconto = txtSconto.Text

                    Dim NuovoNomeFile As String = ""
                    'creo l'anteprima in bassa risoluzione qui
                    If NuovoNomeFile.ToLower.EndsWith("jpg") Then
                        NuovoNomeFile = FormerPath.PathTemp & GetNomeFileTemp()
                        ResizeImgPublic(txtAnteprima.Text, NuovoNomeFile)
                    Else
                        NuovoNomeFile = FormerPath.PathTemp & GetNomeFileTemp(".eml")
                        FileCopia(Me, txtAnteprima.Text, NuovoNomeFile)
                    End If

                    'ridimensiono l'anteprima

                    Prev.Anteprima = NuovoNomeFile
                    '                    Prev.NomeFileDestinazione = Prev.Numero & "_" & PulisciStringa(GetNomeFile(txtAnteprima.Text).Replace(" ", "_"))
                    Prev.DataIns = Now

                    Prev.Save()
                    'Prev.SalvaFile()
                    Cursor.Current = Cursors.WaitCursor

                    'creo la cartella
                    'trasferisco i file
                    'prima gli allegati poi il file con l'ordine vero e proprio


                    'Dim FTP As New FTPclient(Postazione.FTPServer, Postazione.FTPLogin, Postazione.FTPPwd)

                    'FtpTransfer(Me, FTP, Prev.NomeFileOriginale, PathNuovoOrdine & "/" & Prev.NomeFileDestinazione, enTipoOpFTP.Upload)

                    'FtpTransfer(Me, FTP, FormerPath.PathLocale & Prev.NomeFilePrev, "tipografiaformer.it/preventivi/" & Prev.NomeFilePrev, enTipoOpFTP.Upload)

                    'FTP = Nothing

                    Cursor.Current = Cursors.Default
                    _Ris = 1
                    'MessageBox.Show("Il preventivo è stato salvato!", "Former Clienti", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Close()

                Else

                    MessageBox.Show("E' obbligatorio inserire almeno un anteprima e riempire tutti i campi contrassegnati dall'asterisco!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    btnOk.Enabled = True
                    btnCancel.Enabled = True

                End If

            Catch ex As Exception
                ManageError(ex, "Invio Preventivo")
            End Try

        End If
    End Sub

    Private Function OrdineValido() As Boolean

        Dim Ris As Boolean = True

        If txtAnteprima.Text.Length = 0 Then Ris = False

        If txtTipoLav.Text.Length = 0 Then Ris = False

        If txtQta.Text.Length = 0 Then Ris = False

        If txtStampa.Text.Length = 0 Then Ris = False

        If txtFormatoAp.Text.Length = 0 Then Ris = False

        If txtCarta.Text.Length = 0 Then Ris = False

        Return Ris

    End Function

    Private Sub btnSfogliaAnte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSfogliaAnte.Click
        Dim path As String = ""

        OpenFileDialogAnte.ShowDialog()
        If OpenFileDialogAnte.FileName.Length Then
            path = OpenFileDialogAnte.FileName
            If path.EndsWith(".jpg") Then pctAnte.Image = Image.FromFile(path)
            txtAnteprima.Text = path
        End If

    End Sub

    Private Sub cmbCorr_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbCorr.SelectedIndexChanged



    End Sub

    Private Sub cmbCli_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbCli.SelectedIndexChanged
        Dim Rnd As New Random

        txtNumero.Text = cmbCli.SelectedValue & Rnd.Next(100000000, 999999999).ToString
    End Sub

    Private Sub txtPrezzo_TextChanged(sender As Object, e As EventArgs) Handles txtPrezzo.TextChanged
        calcolaPrezzoTot()

    End Sub

    Private Sub CalcolaPrezzoTot()

        Dim P As Decimal = CDec(txtPrezzo.Text)

        If P Then


            Try
                Dim s As Decimal = CDec(txtSconto.Text)
                P -= s

            Catch ex As Exception

            End Try

            Dim iva As Decimal = FormerHelper.Finanziarie.CalcolaIva(P)
            txtIva.Text = iva
            txtTot.Text = P + iva

        End If

    End Sub

    Private Sub txtSconto_TextChanged(sender As Object, e As EventArgs) Handles txtSconto.TextChanged
        CalcolaPrezzoTot()
    End Sub
End Class