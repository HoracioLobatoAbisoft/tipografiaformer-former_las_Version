Imports System.IO
Imports System.Xml
Imports FormerLib.FormerEnum
Imports FormerDao
Friend Class frmCheckMail

    Public formSopra As DCLibrary.ControlliPersonalizzati.cFormSopra
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

            _Ris = ControllaOrdiniFTP()

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

    Private Function ControllaOrdiniFTP() As Integer

        Dim Ris As Integer = 0, CountOrd As Integer = 0

        Try

            Dim UltRilascioModClienti As Integer = GetUltimoRilascioModClienti

            Dim PathLocale As String = Postazione.PathApplicazione & "ordini\daevadere\"

            CreateLongDir(PathLocale)

            Dim PathRemoto As String = "tipografiaformer.it/ordini/daevadere/"

            Dim Ftp As New FTPclient(Postazione.FTPServer, Postazione.FTPLogin, Postazione.FTPPwd)

            Dim ListaFile As Collections.Generic.List(Of String)

            ListaFile = Ftp.ListDirectory("/" & PathRemoto)

            'qui ciclo nella collezione e prendo i file xml riempiendo una collezione di ordini
            Dim File As String = ""

            For Each File In ListaFile

                If File.EndsWith(".xml") Then

                    Dim RisultatoOrdine As enStatoOrdMail
                    Dim Note As String = ""

                    Dim Risu As Integer = 0
                    Dim Ord As cOrdineScaricato
                    Dim Ordine As Ordine

                    Try
                        CountOrd += 1
                        lblTotOrdini.Text = CountOrd
                        Application.DoEvents()
                        'qui ho un ordine 
                        'i file xml vanno scaricati in una cartella ordini da evadere e poi copiati nella cartella temp
                        'lo scarico leggo gli allegati e li scarico, poi se tutto e' ok lo registro nel db e lo cancello

                        Risu = FtpTransfer(Me, Ftp, PathRemoto & File, PathLocale & File, enTipoOpFTP.Download)

                        'file scaricato ora lo leggo

                        Ord = ReadOrdScaricato(PathLocale & File)

                        'controllo che gli allegati siano presenti

                        Risu = FtpTransfer(Me, Ftp, PathRemoto & Ord.NumOrd & "/" & Ord.Anteprima, Postazione.PathTemp & Ord.Anteprima, enTipoOpFTP.Download)
                        Risu = FtpTransfer(Me, Ftp, PathRemoto & Ord.NumOrd & "/" & Ord.Sorgente1, Postazione.PathTemp & Ord.Sorgente1, enTipoOpFTP.Download)
                        If Ord.Sorgente2.Length Then Risu = FtpTransfer(Me, Ftp, PathRemoto & Ord.NumOrd & "/" & Ord.Sorgente2, Postazione.PathTemp & Ord.Sorgente2, enTipoOpFTP.Download)
                        If Ord.Sorgente3.Length Then Risu = FtpTransfer(Me, Ftp, PathRemoto & Ord.NumOrd & "/" & Ord.Sorgente3, Postazione.PathTemp & Ord.Sorgente3, enTipoOpFTP.Download)
                        If Ord.Sorgente4.Length Then Risu = FtpTransfer(Me, Ftp, PathRemoto & Ord.NumOrd & "/" & Ord.Sorgente4, Postazione.PathTemp & Ord.Sorgente4, enTipoOpFTP.Download)

                    Catch ex As Exception

                    End Try

                    'se arrivo qui e ris = 1 ho scaricato tutto 
                    If Risu Then

                        Dim Rub As New VoceRubrica, RubMgr As New VociRubricaDAO
                        Rub.Read(Ord.IdCliente)

                        If Rub.IdRub Then
                            'qui controllo che l'email sia corretta e se e' diversa l'aggiorno
                            If (Rub.Email <> Ord.Email) And Ord.Email.Length <> 0 Then
                                Rub.Email = Ord.Email
                                Rub.Save()
                            End If

                            If RubMgr.OltreScopertoMax(Rub) = False Then

                                Dim Prodotto As Prodotto = (New ProdottiDAO).ReadEx(, Ord.Prodotto, Rub.IdRub)
                                Dim PrezzoRiferimento As Decimal = Prodotto.Prezzo

                                If Ord.TipoConsegna = enTipoConsegna.Fast Then PrezzoRiferimento = Prodotto.PrezzoFast
                                If Ord.TipoConsegna = enTipoConsegna.Low Then PrezzoRiferimento = Prodotto.PrezzoLow


                                If Prodotto.IdProd Then

                                    Dim Corr As New Corriere, PrezzoCorr As Single
                                    Corr.Read(Rub.IdCorriere)

                                    PrezzoCorr = Corr.Costo

                                    Corr = Nothing

                                    Dim IdOrd As Integer = 0

                                    Ordine = New Ordine
                                    Ordine.Annotazioni = Ord.Note
                                    Ordine.Preventivo = Ord.Preventivo
                                    Ordine.DataIns = Now
                                    Ordine.DataCambioStato = Now
                                    Ordine.File = Postazione.PathTemp & Ord.Anteprima
                                    Ordine.IdProd = Prodotto.IdProd
                                    Ordine.Qta = 1
                                    Ordine.IdRub = Rub.IdRub
                                    Ordine.IdTipoProd = Prodotto.TipoProd
                                    Ordine.PrezzoProd = Prodotto.Prezzo
                                    Ordine.IdCorriere = Ord.IdCorriere
                                    Ordine.CostoSped = PrezzoCorr
                                    Ordine.NomeFileOriginale = Ord.Sorgente1
                                    Ordine.OrdMail = True
                                    Ordine.TipoConsegna = Ord.TipoConsegna
                                    Ordine.RilascioCli = Ord.Rilascio

                                    Ordine.DataPrevConsegna = Ordine.CalcolaDataConsegna 'qui devo calcolare di nuovo la data di prevista consegna 

                                    'inserisco il prezzo 
                                    Ordine.TotaleForn = PrezzoRiferimento
                                    Ordine.Iva = (Ordine.TotaleForn * cPercIVA) / 100
                                    Ordine.Prezzo = Ordine.TotaleForn + Ordine.Iva + PrezzoCorr

                                    IdOrd = Ordine.Save()

                                    'qui ho l'id dell'ordine... cambio i nomi dei file
                                    Rename(Postazione.PathTemp & Ord.Anteprima, Postazione.PathTemp & IdOrd & "_" & Ord.Anteprima)
                                    Ordine.File = Postazione.PathTemp & IdOrd & "_" & Ord.Anteprima
                                    Dim mO As New OrdiniDAO
                                    mO.SalvaFile(Ordine)
                                    mO.Dispose()

                                    'ora che ho salvato l'ordine salvo i sorgenti
                                    'salvo ogni singolo sorgente
                                    Dim Sorg As FileSorgente

                                    Sorg = New FileSorgente
                                    Sorg.IdOrd = IdOrd
                                    Rename(Postazione.PathTemp & Ord.Sorgente1, Postazione.PathTemp & IdOrd & "_" & Ord.Sorgente1)
                                    Sorg.File = Postazione.PathTemp & IdOrd & "_" & Ord.Sorgente1
                                    Sorg.Save()
                                    Sorg = Nothing

                                    If Ord.Sorgente2.Length Then
                                        Sorg = New FileSorgente
                                        Sorg.IdOrd = IdOrd
                                        Rename(Postazione.PathTemp & Ord.Sorgente2, Postazione.PathTemp & IdOrd & "_" & Ord.Sorgente2)
                                        Sorg.File = Postazione.PathTemp & IdOrd & "_" & Ord.Sorgente2
                                        Sorg.Save()
                                        Sorg = Nothing
                                    End If

                                    If Ord.Sorgente3.Length Then
                                        Sorg = New FileSorgente
                                        Sorg.IdOrd = IdOrd
                                        Rename(Postazione.PathTemp & Ord.Sorgente3, Postazione.PathTemp & IdOrd & "_" & Ord.Sorgente3)
                                        Sorg.File = Postazione.PathTemp & IdOrd & "_" & Ord.Sorgente3
                                        Sorg.Save()
                                        Sorg = Nothing
                                    End If

                                    If Ord.Sorgente4.Length Then
                                        Sorg = New FileSorgente
                                        Sorg.IdOrd = IdOrd
                                        Rename(Postazione.PathTemp & Ord.Sorgente4, Postazione.PathTemp & IdOrd & "_" & Ord.Sorgente4)
                                        Sorg.File = Postazione.PathTemp & IdOrd & "_" & Ord.Sorgente4
                                        Sorg.Save()
                                        Sorg = Nothing
                                    End If

                                    'qui cancello i file remoti
                                    'se sto in modalita debug attivo non li cancello cosi posso scaricare gli ordini senza rovinare nulla

                                    If DebugAttivo = False Then

                                        Ftp.FtpDelete(PathRemoto & File)
                                        Threading.Thread.Sleep(50)
                                        'qui invece di cancellare l'anteprima la devo rinominare e spostare in un altra cartella in cui la chiamo con l'idord
                                        'TESTARE
                                        Dim PathRemotoAnteprima As String = "tipografiaformer.it/ordini/anteprima/" & IdOrd & "_" & Ord.Anteprima
                                        Ftp.FtpRename(PathRemoto & Ord.NumOrd & "/" & Ord.Anteprima, PathRemotoAnteprima)

                                        'carico l'anteprima
                                        Risu = FtpTransfer(Me, Ftp, Ordine.File, PathRemotoAnteprima, enTipoOpFTP.Upload)

                                        'cancello i file 
                                        Ftp.FtpDelete(PathRemoto & Ord.NumOrd & "/" & Ord.Anteprima)
                                        Threading.Thread.Sleep(50)
                                        Ftp.FtpDelete(PathRemoto & Ord.NumOrd & "/" & Ord.Sorgente1)
                                        Threading.Thread.Sleep(50)
                                        Ftp.FtpDelete(PathRemoto & Ord.NumOrd & "/" & Ord.Sorgente2)
                                        Threading.Thread.Sleep(50)
                                        Ftp.FtpDelete(PathRemoto & Ord.NumOrd & "/" & Ord.Sorgente3)
                                        Threading.Thread.Sleep(50)
                                        Ftp.FtpDelete(PathRemoto & Ord.NumOrd & "/" & Ord.Sorgente4)
                                        Threading.Thread.Sleep(50)
                                        Ftp.FtpDeleteDirectory(PathRemoto & Ord.NumOrd & "/")

                                    End If

                                    RisultatoOrdine = enStatoOrdMail.Accettato
                                    Ris = 1

                                Else
                                    RisultatoOrdine = enStatoOrdMail.Rifiutato
                                    Note = "Prodotto non più disponibile nel listino "
                                End If
                                Prodotto = Nothing
                            Else
                                'Superato scoperto massimo
                                RisultatoOrdine = enStatoOrdMail.Rifiutato
                                Note = "Superato limite massimo di scoperto"

                            End If

                        Else
                            'id cliente non trovato
                            RisultatoOrdine = enStatoOrdMail.Rifiutato
                            Note = "Il codice cliente non è presente in rubrica"

                        End If
                        Rub = Nothing

                    Else
                        'qui è andato in errore qualcosa nello scaricamento file
                        RisultatoOrdine = enStatoOrdMail.Rifiutato
                        Note = "Non sono stati trovati i file allegati all'ordine"

                    End If

                    'qui invio una mail di risposta all'ordine cmq vada
                    If Postazione.InviaMail Then

                        If DebugAttivo = False Then
                            InviaMailRispostaOrdine(RisultatoOrdine, Ordine, Note, Ord.Email)
                        End If

                        If UltRilascioModClienti > Ord.Rilascio Then
                            InviaMailVersioneNonCorretta(Ord.Email)
                        End If

                    End If


                End If

            Next

            'FtpTransfer(Me.ParentForm, Ftp, PathLocale, PathRemoto, enTipoOpFTP.Upload)

            Ftp = Nothing

        Catch ex As Exception
            ManageError(ex, "Controllo ordini FTP")
        End Try

        Return Ris

    End Function

    Private Function ReadOrdScaricato(ByVal Path As String) As cOrdineScaricato

        Dim Ord As New cOrdineScaricato

        Dim objXMLTR As New XmlTextReader(Path)
        Do While objXMLTR.Read

            'Output elements and values
            'Look at output in browser and compare to menu.xml file to 
            'see exactly what is being done
            If objXMLTR.NodeType = XmlNodeType.Element Then
                Select Case objXMLTR.Name
                    'DB 
                    Case "IdCliente"
                        Ord.IdCliente = objXMLTR.ReadString
                    Case "NumOrd"
                        Ord.NumOrd = objXMLTR.ReadString
                    Case "Prodotto"
                        Ord.Prodotto = objXMLTR.ReadString
                    Case "Corriere"
                        Ord.IdCorriere = objXMLTR.ReadString
                    Case "Email"
                        Ord.Email = objXMLTR.ReadString
                    Case "Anteprima"
                        Ord.Anteprima = objXMLTR.ReadString
                    Case "Preventivo"
                        If objXMLTR.ReadString.ToLower = "false" Then
                            Ord.Preventivo = enPreventivoSiNo.No
                        Else
                            Ord.Preventivo = enPreventivoSiNo.Si
                        End If

                    Case "Note"
                        Ord.Note = objXMLTR.ReadString
                    Case "Sorgente1"
                        Ord.Sorgente1 = objXMLTR.ReadString
                    Case "Sorgente2"
                        Ord.Sorgente2 = objXMLTR.ReadString
                    Case "Sorgente3"
                        Ord.Sorgente3 = objXMLTR.ReadString
                    Case "Sorgente4"
                        Ord.Sorgente4 = objXMLTR.ReadString
                    Case "TipoConsegna"
                        Ord.TipoConsegna = objXMLTR.ReadString
                    Case "Rilascio"
                        Ord.Rilascio = objXMLTR.ReadString


                End Select

            End If
        Loop

        objXMLTR.Close()

        Return Ord

    End Function

    Public Function ControllaOrdiniMail(Optional ByVal Manuale As Boolean = False) As Integer

        'Dim Mail As cMailObj
        'Dim Counter As Integer = 1
        'Dim CountOrd As Integer = 0
        'Dim CountOrdVal As Integer = 0

        ''controlla l'email di riferimento per gli ordini 
        'Try

        '    Dim email As New Pop3.Pop3Client(Postazione.Email, Postazione.EmailPwd, Postazione.Pop3Server)

        '    email.OpenInbox()

        '    progressBarMail.Value = 0
        '    progressBarMail.Minimum = 0
        '    progressBarMail.Maximum = email.MessageCount
        '    progressBarMail.Step = 1

        '    Application.DoEvents()


        '    While email.NextEmail

        '        'qui devo controllare che l'email non sia stata gia controllata
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

        '                                                    Dim fs As New FileStream(Postazione.PathApplicazione & "anteprimatemp.jpg", FileMode.Create, FileAccess.Write)
        '                                                    fs.Write(atB, 0, UBound(atB) + 1)
        '                                                    fs.Close()

        '                                                    ResizeImgPublic(Postazione.PathApplicazione & "anteprimatemp.jpg", Postazione.PathTemp & NuovoNomeFile)

        '                                                    NomeFileAnteprima = Postazione.PathTemp & NuovoNomeFile

        '                                                ElseIf NomeFile.ToLower.StartsWith("sorgente") Then

        '                                                    Dim EstensioneFile As String = NomeFile.Substring(NomeFile.Length - 4, 4)
        '                                                    Dim NuovoNomeFile As String = GetNomeFileTemp(EstensioneFile)

        '                                                    Dim fs As New FileStream(Postazione.PathTemp & NuovoNomeFile, FileMode.Create, FileAccess.Write)
        '                                                    fs.Write(atB, 0, UBound(atB) + 1)
        '                                                    fs.Close()

        '                                                    'metto nei file sorgenti 
        '                                                    Dim Pos As Integer = NomeFileSorgenti.Length + 1
        '                                                    Array.Resize(NomeFileSorgenti, Pos)
        '                                                    NomeFileSorgenti(Pos - 1) = Postazione.PathTemp & NuovoNomeFile

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

        '                                                Dim IdOrd As Integer = 0

        '                                                Ord = New Ordine
        '                                                Ord.Annotazioni = Mail.Testo
        '                                                Ord.DataIns = Mail.DataMail
        '                                                Ord.File = NomeFileAnteprima
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

        '                                                Dim nuovoPath As String = Postazione.PathTemp & IdOrd & "_" & NomeFileAnteprimaOriginale
        '                                                FileCopy(Ord.File, nuovoPath)

        '                                                Ord.File = nuovoPath
        '                                                Ord.SalvaFile()


        '                                                'ora che ho salvato l'ordine salvo i sorgenti
        '                                                Dim J As Integer = 0

        '                                                For J = 1 To NomeFileSorgenti.Length - 1

        '                                                    Dim nuovoPathSorg As String = Postazione.PathTemp & IdOrd & "_" & NomeFileSorgentiOrig(J)

        '                                                    FileCopy(NomeFileSorgenti(J), nuovoPathSorg)
        '                                                    'salvo ogni singolo sorgente
        '                                                    Dim Sorg As New FileSorgente
        '                                                    Sorg.IdOrd = IdOrd
        '                                                    Sorg.File = nuovoPathSorg
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

        '                '  If Postazione.InviaMail Then InviaMailRispostaOrdine(Mail, Ord)

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