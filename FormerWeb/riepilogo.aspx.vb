Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports FormerLib
Imports System.Drawing
Imports FormerDALWeb
Public Class riepilogo
    Inherits FormerSecurePage

    Protected O As ProdottoInCarrello
    Protected NextUrl As String = "/"
    Private Descrizione As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Descrizione = Convert.ToString(Page.RouteData.Values("descrizione"))

            If Session("OrdineListinoBase") Is Nothing Then
                Response.Redirect("/") ' dire che la sessione è scaduta 
            Else
                O = Session("OrdineListinoBase")
                'inizializzo la lista in caso sia vuota
                If O.LavorazioniIncluse Is Nothing Then O.LavorazioniIncluse = New List(Of LavorazioneW)

                If Not Session("UltimoProdottoVisitato") Is Nothing Then
                    NextUrl = Session("UltimoProdottoVisitato")
                End If

                If Not IsPostBack Then
                    AbilitaFronteRetro()

                    If Not Request.Cookies("emailRif") Is Nothing Then
                        txtEmailRiferimento.Text = Request.Cookies("emailRif").Value
                    End If
                    Dim UrlQrCode As String = "http://www.tipografiaformer.it" & NextUrl
                    imgQrCode.ImageUrl = FormerLib.FormerHelper.QrCode.CreaQrCode(UrlQrCode)

                End If


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AbilitaFronteRetro()

        Dim FronteRetro As Boolean = O.C.FR

        If FronteRetro Then
            pnlRetro.Visible = True
            fileRetro.Enabled = True
            rqFileRetro.Enabled = True
        Else
            pnlRetro.Visible = False
            fileRetro.Enabled = False
            rqFileRetro.Enabled = False
        End If


    End Sub


    Private Function ValidazioneModulo() As String

        Dim ErrBuff As String = String.Empty

        'If fileAnteprima.HasFile AndAlso Not fileAnteprima.FileName.ToLower.EndsWith(".jpg") Then
        '    ErrBuff = " - Il file anteprima deve essere in formato JPG"
        'End If

        If fileFronte.HasFile AndAlso Not fileFronte.FileName.ToLower.EndsWith(".pdf") Then
            ErrBuff &= " - I file sorgente devono essere in formato PDF"
        End If

        If fileRetro.Enabled Then
            If fileFronte.FileName.ToLower = fileRetro.FileName.ToLower AndAlso Not fileRetro.FileName.ToLower.EndsWith(".pdf") Then
                ErrBuff &= " - I file sorgente FRONTE e sorgente RETRO devono essere diversi. I file sorgente devono essere in formato PDF"
            End If
        End If

        Return ErrBuff

    End Function

    Private Function PulisciStringa(ByVal in_put As String) As String
        Dim clean_and_clear As String
        Dim car As Char
        clean_and_clear = " ,%/'();éòàùè@!+^&\?][{}*ç°§"
        For Each car In clean_and_clear
            in_put = Replace(in_put, car, "")
        Next
        Return Trim$(in_put)
    End Function

    Private Sub SalvaOrdine()

        Dim NomeAnteprima As String = String.Empty
        Dim NomeFronte As String = String.Empty
        Dim NomeRetro As String = String.Empty

        'CREO L'ANTEPRIMA
        '*******************
        Dim filereceived As String = String.Empty 'fileAnteprima.PostedFile.FileName
        Dim PathOrdini As String = AppDomain.CurrentDomain.BaseDirectory & "ordini\daevadere\"
        Dim PathOrdiniFile As String = PathOrdini & O.NumOrd & "\"
        Directory.CreateDirectory(PathOrdiniFile)

        Dim filename As String = String.Empty
        Dim fileuploadPath As String = String.Empty

        'LAVORO I SORGENTI
        '*******************
        filereceived = fileFronte.PostedFile.FileName
        filename = Path.GetFileName(filereceived)
        NomeFronte = UtenteConnesso.IdRubricaInt & "_" & PulisciStringa(filereceived).Replace(" ", "_")
        fileuploadpath = PathOrdiniFile & NomeFronte

        fileFronte.PostedFile.SaveAs(fileuploadpath)


        If fileRetro.Enabled Then

            filereceived = fileRetro.PostedFile.FileName
            filename = Path.GetFileName(filereceived)
            NomeRetro = UtenteConnesso.IdRubricaInt & "_" & PulisciStringa(filereceived).Replace(" ", "_")
            fileuploadpath = PathOrdiniFile & NomeRetro

            fileRetro.PostedFile.SaveAs(fileuploadpath)

        End If

        'qui creo l'anteprima del fronte 
        'Dim NuovoNomeFileAnteprima As String = PathOrdiniFile & FormerHelper.File.GetNomeFileTemp()

        NomeAnteprima = Path.GetFileNameWithoutExtension(NomeFronte) & ".jpg"
        'NomeAnteprima = UtenteConnesso.IdUtente & "_" & PulisciStringa(filename).Replace(" ", "_")
        'fileuploadPath = PathOrdiniFile & NomeAnteprima

        'INVECE DI SALVARLO DAL FORM LO CREO DAL PDF RICEVUTO COME SORGENTE FRONTE
        'fileAnteprima.PostedFile.SaveAs(NuovoNomeFileAnteprima)

        'Dim grand As New Size(800, 600)
        'FormerHelper.PDF.GetPdfThumbnail((PathOrdiniFile & NomeFronte), NuovoNomeFileAnteprima, grand)
        'ResizeImgPublic(NuovoNomeFileAnteprima, fileuploadpath)

        'Try
        '    FileIO.FileSystem.DeleteFile(NuovoNomeFileAnteprima)

        'Catch ex As Exception

        'End Try

        'RIEMPIO L'OGGETTO ORDINE
        O.Preventivo = chkPreventivo.Checked
        O.Note = txtNote.Text
        O.EmailRiferimento = txtEmailRiferimento.Text

        O.Anteprima.NomeFileOriginale = NomeAnteprima
        O.Anteprima.NomeFileDestinazione = NomeAnteprima

        O.Sorgente1.NomeFileOriginale = fileFronte.PostedFile.FileName
        O.Sorgente1.NomeFileDestinazione = NomeFronte

        If fileRetro.Enabled Then
            O.Sorgente2.NomeFileOriginale = fileRetro.PostedFile.FileName
            O.Sorgente2.NomeFileDestinazione = NomeRetro
        End If

        'se arrivo qui ho salvato tutti gli allegati
        'CREO L'XML
        '**********
        CreaXMLDaOrdine(PathOrdini)

        InviaMailOrdineOK()

    End Sub

    Private Sub InviaMailOrdineOK()

        'INVIO MAIL DI CONFERMA DELL'ORDINE RICEVUTO

        Dim Pt As New My.Templates.MailOrdineOk
        Pt.O = O
        Dim Buffer As String = Pt.TransformText

        Try
            FormerHelper.Mail.InviaMail("Il suo ordine è stato REGISTRATO", Buffer, O.EmailRiferimento)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CreaXMLDaOrdine(PathOrdini As String)

        'Dim enc As System.Text.Encoding

        'Dim objXMLTW As New XmlTextWriter(PathOrdini & O.NomeFileOrd, enc)

        'objXMLTW.WriteStartDocument()
        ''Top level (Parent element)
        'objXMLTW.WriteStartElement("Ordine")
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("IdCliente")
        'objXMLTW.WriteString(UtenteConnesso.IdUtente)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Email")
        'objXMLTW.WriteString(O.EmailRiferimento)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Preventivo")
        'objXMLTW.WriteString(O.Preventivo)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Note")
        'objXMLTW.WriteString(O.Note)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("NumOrd")
        'objXMLTW.WriteString(O.NumOrd)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Prodotto")
        'objXMLTW.WriteString(O.L.IdListinoBase)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Corriere")
        'objXMLTW.WriteString(O.Corriere.IdCorriere)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("TipoConsegna")
        'objXMLTW.WriteString(O.TipoConsegna)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Anteprima")
        'objXMLTW.WriteString(O.Anteprima.NomeFileDestinazione)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Sorgente1")
        'objXMLTW.WriteString(O.Sorgente1.NomeFileDestinazione)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Sorgente2")
        'objXMLTW.WriteString(O.Sorgente2.NomeFileDestinazione)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Sorgente3")
        'objXMLTW.WriteString("")
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Sorgente4")
        'objXMLTW.WriteString("")
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Rilascio")
        'objXMLTW.WriteString(9999)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        ''QUI AGGIUNGO I CAMPI NUOVI CHE MI SERVONO PER COMPLETARE L'ORDINE

        'objXMLTW.WriteStartElement("Quando")
        'objXMLTW.WriteString(O.Quando)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("NFogli")
        'objXMLTW.WriteString(O.NFogli)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("NFogliVis")
        'objXMLTW.WriteString(O.NFogliVis)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("ShowLabelFogli")
        'objXMLTW.WriteString(O.L.ShowLabelFogli)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("LabelFogli")
        'objXMLTW.WriteString(O.L.GetLabelFogli)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Lavorazioni")
        'objXMLTW.WriteString(O.ElencoLavorazioni)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("PrezzoCalcolatoNetto")
        'objXMLTW.WriteString(O.PrezzoCalcolatoNetto)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("PrezzoCorriere")
        'objXMLTW.WriteString(O.SpeseDiTrasporto)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("TotaleNetto")
        'objXMLTW.WriteString(O.TotaleNetto)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("TotaleIva")
        'objXMLTW.WriteString(O.TotaleIva)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("TotaleOrdine")
        'objXMLTW.WriteString(O.TotaleOrdine)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Quantita")
        'objXMLTW.WriteString(O.Qta)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("NumColli")
        'objXMLTW.WriteString(O.Colli)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteStartElement("Peso")
        'objXMLTW.WriteString(O.Peso)
        'objXMLTW.WriteEndElement()
        'objXMLTW.WriteString(ControlChars.NewLine)

        'objXMLTW.WriteEndElement() 'End top level element
        'objXMLTW.WriteEndDocument() 'End Document
        'objXMLTW.Flush() 'Write to file
        'objXMLTW.Close()

    End Sub

    Protected Sub btnInviaOrdine_Click(sender As Object, e As ImageClickEventArgs) Handles btnInviaOrdine.Click

        If Not UtenteConnesso Is Nothing Then
            Dim risValidaz As String = ValidazioneModulo()
            If risValidaz.Length Then
                pnlError.Visible = True
                lblErrore.Text = risValidaz
                pnlError.Focus()
            Else
                'qui posso salvare l'ordine

                Dim HId As New HttpCookie("emailRif")
                HId.Value = txtEmailRiferimento.Text
                HId.Expires = Date.Now.AddMonths(3)
                Response.Cookies.Add(HId)

                SalvaOrdine()

                Session("OrdineListinoBase") = Nothing
                Response.Redirect("/ordine-registrato/" & Descrizione)
            End If
        Else
            Response.Redirect("/")
        End If

    End Sub
End Class