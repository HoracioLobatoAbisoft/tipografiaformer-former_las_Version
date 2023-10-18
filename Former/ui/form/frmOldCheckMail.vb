Imports System.IO
Imports FormerDALSql
Friend Class frmOldCheckMail

    Public formSopra As cFormSopra
    Private _Ris As Integer

    Friend Function Carica() As Integer

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("La procedura di download ordini può richiedere alcuni minuti, confermi l'operazione?", "Download Ordini", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            btnCancel.Enabled = False
            btnOk.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            _Ris = ControllaOrdiniMail(True)

            If _Ris Then
                MessageBox.Show("Sono stati trovati nuovi ordini", "Ordini email", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Non sono presenti nuovi ordini", "Ordini email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            btnCancel.Enabled = True
            btnOk.Enabled = True
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Public Function ControllaOrdiniMail(Optional ByVal Manuale As Boolean = False) As Integer

        'Dim Mail As cMailObj
        'Dim Counter As Integer = 1
        'Dim CountOrd As Integer = 0
        'Dim CountOrdVal As Integer = 0

        ''controlla l'email di riferimento per gli ordini 
        'Try

        '    Dim email As New Pop3.Pop3Client(Postazione.Email, Postazione.EmailPwd, Postazione.Pop3Server)

        '    email.OpenInbox()

        '    lblTotMail.Text = email.MessageCount
        '    progressBarMail.Value = 0
        '    progressBarMail.Minimum = 0
        '    progressBarMail.Maximum = email.MessageCount
        '    progressBarMail.Step = 1

        '    Application.DoEvents()


        '    While email.NextEmail

        '        'qui devo controllare che l'email non sia stata gia controllata
        '        lblCurrentMail.Text = Counter
        '        Refresh()
        '        Application.DoEvents()

        '        Mail = New cMailObj

        '        'mail.DataMail 
        '        Date.TryParse(email.DataRic, Mail.DataMail)

        '        Mail.MailMitt = email.From.ToString
        '        If Not email.MessageId Is Nothing Then Mail.MessageId = email.MessageId.ToString
        '        Mail.Titolo = email.Subject.ToString.TrimEnd

        '        Dim Testo As String = email.Body

        '        'Testo = Testo.Substring(Testo.IndexOf(ControlChars.NewLine))

        '        Mail.Testo = Testo.ToString

        '        If Mail.Titolo.ToLower.StartsWith("ordine") Then

        '            Dim Ord As Ordine
        '            'da qui in poi cmq devo mandare una mail con il risultato dell'ordine

        '            CountOrd += 1
        '            lblTotOrdini.Text = CountOrd

        '            If Mail.EsisteGia = False Then

        '                'qui devo controllare che l'email sia da un cliente in rubrica
        '                'e che sia interpretabile il codice prodotto e la quantita

        '                Dim rubColl as new VociRubricaDao, rub as VoceRubrica

        '                rub = rubColl.CercaByEmail(Mail.MailMitt)

        '                If Not rub Is Nothing Then

        '                    If rub.OltreScopertoMax = False Then

        '                        'qui devo cercare di interpretare l'ordine

        '                        Dim arrOrd As String() = Split(Mail.Titolo, " ")

        '                        If arrOrd.Length > 1 Then

        '                            Dim CodProd As String = arrOrd(1)
        '                            Dim Qta As String = "1"

        '                            If arrOrd.Length = 3 Then Qta = arrOrd(2)

        '                            Dim Prodotto As New Prodotto
        '                            Prodotto.Read(, CodProd)

        '                            'ORDINE BIGLIETTIDAVISITA1000 QTA

        '                            If Prodotto.IdProd Then

        '                                Dim qt As Integer, ErrQta As Boolean = False

        '                                Try

        '                                    qt = CInt(Qta)

        '                                Catch ex As Exception
        '                                    ErrQta = True
        '                                End Try

        '                                If ErrQta = False Then

        '                                    If email.IsMultipart Then

        '                                        Dim enumerator As IEnumerator = email.MultipartEnumerator
        '                                        Dim NomeFileAnteprimaOriginale As String = ""
        '                                        Dim NomeFileAnteprima As String = ""
        '                                        Dim NomeFileSorgenti(0) As String
        '                                        Dim NomeFileSorgentiOrig(0) As String

        '                                        While enumerator.MoveNext()

        '                                            Dim multipart As Pop3.Pop3Component

        '                                            multipart = enumerator.Current

        '                                            Dim NomeFile As String = ""

        '                                            If multipart.IsAttachment Then

        '                                                If multipart.Filename Is Nothing Then

        '                                                    'cerco di prenderlo dalla posizione 
        '                                                    Dim Posizione As Integer = 0

        '                                                    Posizione = multipart.ContentDisposition.IndexOf("filename=")

        '                                                    If Posizione <> -1 Then
        '                                                        Posizione += 10
        '                                                        Dim FineNome As Integer = multipart.ContentDisposition.IndexOf("""", Posizione)
        '                                                        'Posizione += 18

        '                                                        NomeFile = multipart.ContentDisposition.Substring(Posizione, FineNome - Posizione)

        '                                                    End If

        '                                                Else
        '                                                    NomeFile = multipart.Filename.ToString
        '                                                End If

        '                                                Dim attachmsg As String = multipart.Data

        '                                                Dim atB As Byte()

        '                                                atB = System.Convert.FromBase64CharArray(attachmsg.ToCharArray(), 0, attachmsg.Length)

        '                                                If NomeFile.ToLower.StartsWith("anteprima") Then

        '                                                    NomeFileAnteprimaOriginale = NomeFile

        '                                                    Dim NuovoNomeFile As String = GetNomeFileTemp()

        '                                                    Dim fs As New FileStream(FormerPath.PathLocale & "anteprimatemp.jpg", FileMode.Create, FileAccess.Write)
        '                                                    fs.Write(atB, 0, UBound(atB) + 1)
        '                                                    fs.Close()

        '                                                    ResizeImgPublic(FormerPath.PathLocale & "anteprimatemp.jpg", FormerPath.PathTemp & NuovoNomeFile)

        '                                                    NomeFileAnteprima = FormerPath.PathTemp & NuovoNomeFile

        '                                                ElseIf NomeFile.ToLower.StartsWith("sorgente") Then

        '                                                    Dim EstensioneFile As String = NomeFile.Substring(NomeFile.Length - 4, 4)
        '                                                    Dim NuovoNomeFile As String = GetNomeFileTemp(EstensioneFile)

        '                                                    Dim fs As New FileStream(FormerPath.PathTemp & NuovoNomeFile, FileMode.Create, FileAccess.Write)
        '                                                    fs.Write(atB, 0, UBound(atB) + 1)
        '                                                    fs.Close()

        '                                                    'metto nei file sorgenti 
        '                                                    Dim Pos As Integer = NomeFileSorgenti.Length + 1
        '                                                    Array.Resize(NomeFileSorgenti, Pos)
        '                                                    NomeFileSorgenti(Pos - 1) = FormerPath.PathTemp & NuovoNomeFile

        '                                                    Array.Resize(NomeFileSorgentiOrig, Pos)
        '                                                    NomeFileSorgentiOrig(Pos - 1) = NomeFile.ToLower


        '                                                End If

        '                                            End If

        '                                        End While

        '                                        'qui ho scaricato se erano presenti tutti gli attach
        '                                        'quindi se e' tutto ok creo l'ordine
        '                                        If NomeFileAnteprima.Length Then

        '                                            If NomeFileSorgenti.Length > 1 Then

        '                                                Dim Corr As New cCorriere, PrezzoCorr As Single
        '                                                Corr.Read(rub.IdCorriere)

        '                                                PrezzoCorr = Corr.Costo

        '                                                Corr = Nothing

        '                                                CountOrdVal += 1
        '                                                lblTotOrdiniVal.Text = CountOrdVal

        '                                                Dim IdOrd As Integer = 0

        '                                                Ord = New Ordine
        '                                                Ord.Annotazioni = Mail.Testo
        '                                                Ord.DataIns = Mail.DataMail
        '                                                Ord.FilePath = NomeFileAnteprima
        '                                                Ord.IdProd = Prodotto.IdProd
        '                                                Ord.Qta = Qta
        '                                                Ord.IdRub = rub.IdRub
        '                                                Ord.IdTipoProd = Prodotto.TipoProd
        '                                                Ord.PrezzoProd = Prodotto.Prezzo
        '                                                Ord.IdCorriere = rub.IdCorriere
        '                                                Ord.TotaleForn = (Prodotto.Prezzo * qt)
        '                                                Ord.CostoSped = PrezzoCorr
        '                                                Ord.Iva = (Ord.TotaleForn * 20) / 100
        '                                                Ord.Prezzo = Ord.TotaleForn + Ord.Iva + PrezzoCorr
        '                                                Ord.NomeFileOriginale = NomeFileAnteprimaOriginale
        '                                                Ord.OrdMail = True

        '                                                Ord.Save(IdOrd)

        '                                                Dim nuovoPath As String = FormerPath.PathTemp & IdOrd & "_" & NomeFileAnteprimaOriginale
        '                                                FileCopy(Ord.FilePath, nuovoPath)

        '                                                Ord.FilePath = nuovoPath
        '                                                Ord.SalvaFile()


        '                                                'ora che ho salvato l'ordine salvo i sorgenti
        '                                                Dim J As Integer = 0

        '                                                For J = 1 To NomeFileSorgenti.Length - 1

        '                                                    Dim nuovoPathSorg As String = FormerPath.PathTemp & IdOrd & "_" & NomeFileSorgentiOrig(J)

        '                                                    FileCopy(NomeFileSorgenti(J), nuovoPathSorg)
        '                                                    'salvo ogni singolo sorgente
        '                                                    Dim Sorg As New FileSorgente
        '                                                    Sorg.IdOrd = IdOrd
        '                                                    Sorg.FilePath = nuovoPathSorg
        '                                                    Sorg.Save()
        '                                                    Sorg = Nothing

        '                                                Next


        '                                                Mail.Stato = enStatoOrdMail.Accettato
        '                                            Else
        '                                                Mail.Stato = enStatoOrdMail.Rifiutato
        '                                                Mail.Note = "Nessun file sorgente presente"

        '                                            End If

        '                                        Else
        '                                            'qui non ha trovato allegati
        '                                            Mail.Stato = enStatoOrdMail.Rifiutato
        '                                            Mail.Note = "Anteprima non presente"

        '                                        End If

        '                                    Else 'qui in teoria non ci dovrebbe finire mai
        '                                        Mail.Stato = enStatoOrdMail.Rifiutato
        '                                        Mail.Note = "Errore generico"
        '                                    End If
        '                                Else
        '                                    'qui la quantità è errata
        '                                    Mail.Stato = enStatoOrdMail.Rifiutato
        '                                    Mail.Note = "Quantità ordinata non valida"

        '                                End If
        '                            Else
        '                                'qui non trova il prodotto o la qta e' errata
        '                                Mail.Stato = enStatoOrdMail.Rifiutato
        '                                Mail.Note = "Codice prodotto non valido"

        '                            End If 'if not prodotto is nothing 
        '                        Else
        '                            Mail.Stato = enStatoOrdMail.Rifiutato
        '                            Mail.Note = "Parametri dell'ordine mancanti"

        '                        End If
        '                    Else 'qui ha superato lo scoperto e vediamo che fare

        '                        Mail.Stato = enStatoOrdMail.Rifiutato
        '                        Mail.Note = "Superato scoperto max"


        '                    End If

        '                Else ' qui il cliente non esiste in rubrica

        '                    Mail.Stato = enStatoOrdMail.Rifiutato
        '                    Mail.Note = "Cliente non presente in rubrica"

        '                End If

        '                Mail.RegistraNelDb()
        '                'Invio RisultatoMail

        '                'If Postazione.InviaMail Then InviaMailRispostaOrdine(Mail, Ord)

        '            End If 'l'ho gia registrata

        '        End If 'non e' un ordine

        '        'se e' andato tutto ok e nelle opzioni devo cancellare le mail la elimino dal server
        '        If Mail.Stato = enStatoOrdMail.Accettato Then
        '            If Postazione.CancellaMail Then
        '                email.DeleteEmail()
        '            End If
        '        End If

        '        progressBarMail.PerformStep()
        '        Counter += 1
        '    End While

        '    email.CloseConnection()

        'Catch ex As Exception

        '    'qui vediamo come gestire l'errore in questa procedura
        '    If Manuale Then
        '        MessageBox.Show("Si è verificato un errore nello scaricamento degli ordini:" & vbNewLine & ex.Message & vbNewLine & "Controllare la connessione a internet e ritentare!", "Controllo ordini", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '    End If
        '    'ManageError(ex)

        '    If Not Mail Is Nothing Then
        '        Mail.Stato = enStatoOrdMail.Rifiutato
        '        Mail.Note = "Errore generico"
        '        Mail.RegistraNelDb()
        '    End If

        'End Try

        'Return CountOrdVal

    End Function




End Class