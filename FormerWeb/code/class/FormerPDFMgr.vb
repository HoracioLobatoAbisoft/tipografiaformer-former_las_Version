Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.pdf
Imports DW = System.Drawing
Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface

Public Class FormerPDFMgr

    Public Shared Function CreaPreventivoWeb(O As ProdottoInCarrello) As String

        Dim ris As String = String.Empty

        Dim Doc As New Document
        Dim NomeFile As String = FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf")
        Dim path As String = FormerWebApp.PathFisicoPreventivi & NomeFile

        Dim Writer As PdfWriter = PdfWriter.GetInstance(Doc, New FileStream(path, FileMode.Create))
        Writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_5)
        Writer.CompressionLevel = PdfStream.BEST_COMPRESSION

        Doc.Open()

        Dim CarattereNeroSmall As Font = New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim CarattereNero As Font = New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim CarattereNeroBold As Font = New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

        Dim tb As New PdfPTable(2)

        Dim larghezza As Single() = New Single() {750, 400}
        tb.SetWidths(larghezza)

        Dim CellaIntestazione As New PdfPCell()
        CellaIntestazione.Border = 0
        Dim ImgLogo As iTextSharp.text.Image = Image.GetInstance(FormerWebApp.PathFisicoImg & "logo.png")
        ImgLogo.WidthPercentage = 50
        CellaIntestazione.AddElement(ImgLogo)

        CellaIntestazione.AddElement(New iTextSharp.text.Phrase("TIPOGRAFIA FORMER", CarattereNeroBold))
        CellaIntestazione.AddElement(New iTextSharp.text.Phrase("Stabilimento e Uffici: Via Cassia 2010, 00123 Roma", CarattereNero))
        CellaIntestazione.AddElement(New iTextSharp.text.Phrase("Servizio Clienti: 06.30884518 - Email: info@tipografiaformer.it", CarattereNero))
        CellaIntestazione.AddElement(New iTextSharp.text.Phrase("Partita Iva: 14974961006", CarattereNero))
        CellaIntestazione.AddElement(New iTextSharp.text.Phrase(ControlChars.NewLine & ControlChars.NewLine, CarattereNero))
        tb.AddCell(CellaIntestazione)

        Dim CellaCli As New PdfPCell
        CellaCli.Border = 0
        CellaCli.HorizontalAlignment = PdfPCell.ALIGN_CENTER
        CellaCli.VerticalAlignment = PdfPCell.ALIGN_TOP

        Dim p As New Paragraph
        p.Alignment = PdfPCell.ALIGN_CENTER
        p.Add(New iTextSharp.text.Phrase("Preventivo WEB" & ControlChars.NewLine, CarattereNeroBold))
        p.Add(New iTextSharp.text.Phrase(StrConv(Now.ToString("dd MMMM yyyy HH:mm"), VbStrConv.ProperCase), CarattereNero))
        CellaCli.AddElement(p)

        tb.AddCell(CellaCli)
        Doc.Add(tb)

        Dim tbCentro As New PdfPTable(2)
        tbCentro.SetWidths(larghezza)
        Dim CellaVuota As New PdfPCell()
        CellaVuota.Border = 0

        Dim CellaVal As New PdfPCell

        Dim U As UtenteSito = HttpContext.Current.Session("UtenteConnesso")

        If U.IdUtente Then

            CellaVal.Border = 0
            CellaVal.AddElement(New iTextSharp.text.Phrase("Cliente", CarattereNeroBold))

            tbCentro.AddCell(CellaVal)
            tbCentro.AddCell(CellaVuota)
            CellaVal.CompositeElements.Clear()

            CellaVal.Border = 1
            CellaVal.AddElement(New iTextSharp.text.Phrase(U.Nominativo, CarattereNeroBold))
            CellaVal.AddElement(New iTextSharp.text.Phrase("Cod. Cliente Online: " & U.IdUtente, CarattereNero))
            CellaVal.AddElement(New iTextSharp.text.Phrase("Riferimento: " & U.Utente.Nome & " " & U.Utente.Cognome, CarattereNero))
            CellaVal.AddElement(New iTextSharp.text.Phrase("Cod. Fisc: " & U.Utente.CodFisc, CarattereNero))
            CellaVal.AddElement(New iTextSharp.text.Phrase("P.IVA: " & U.Utente.Piva, CarattereNero))
            CellaVal.AddElement(New iTextSharp.text.Phrase("Email: " & U.Utente.Email, CarattereNero))
            CellaVal.AddElement(New iTextSharp.text.Phrase("Tel: " & U.Utente.Tel & ControlChars.NewLine & ControlChars.NewLine, CarattereNero))
            tbCentro.AddCell(CellaVal)
            CellaVuota.Border = 1
            tbCentro.AddCell(CellaVuota)
            CellaVal.CompositeElements.Clear()

            CellaVuota.Border = 0
        End If

        CellaVal.Border = 0
        CellaVal.AddElement(New iTextSharp.text.Phrase("Ordine", CarattereNeroBold))

        tbCentro.AddCell(CellaVal)
        tbCentro.AddCell(CellaVuota)

        CellaVal.CompositeElements.Clear()
        'CREO LA TABELLA DI DETTAGLIO ORDINE
        CellaVal.Border = 1
        CellaVal.AddElement(New iTextSharp.text.Phrase("Quantità: " & O.Qta, CarattereNero))

        tbCentro.AddCell(CellaVal)
        CellaVuota.Border = 1
        tbCentro.AddCell(CellaVuota)
        CellaVal.CompositeElements.Clear()
        CellaVuota.Border = 0
        CellaVal.Border = 0
        If O.L.FormatoProdotto.ProdottoFinito = False Or (O.L.FormatoProdotto.ProdottoFinito = True And O.L.Preventivazione.IdPluginToUse <> 0) Then
            CellaVal.AddElement(New iTextSharp.text.Phrase("Prodotto: " & O.ListinoBase.Nome, CarattereNero)) '& 
            tbCentro.AddCell(CellaVal)
            tbCentro.AddCell(CellaVuota)
            CellaVal.CompositeElements.Clear()
        End If

        Dim FormatoStr As String = String.Empty
        If O.L.Preventivazione.IdPluginToUse Then
            Select Case O.L.Preventivazione.IdPluginToUse
                Case enPluginOnline.Etichette
                    Dim R As RisultatoPluginEtichette = HttpContext.Current.Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
                    If Not R Is Nothing Then
                        FormatoStr = R.Base & " x " & R.Altezza
                    End If
                Case enPluginOnline.Packaging
                    Dim R As RisultatoPluginPackaging = HttpContext.Current.Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
                    If Not R Is Nothing Then
                        FormatoStr = R.Base & " x " & R.Profondita & " x " & R.Altezza & " (Chiuso)"
                    Else
                        FormatoStr = O.L.FormatoProdotto.Formato & " " & IIf(O.L.FormatoProdotto.ProdottoFinito, "", " " & O.L.FormatoProdotto.OrientamentoStr)
                    End If

            End Select
        Else
            FormatoStr = O.L.FormatoProdotto.Formato & IIf(O.L.FormatoProdotto.ProdottoFinito, "", " " & O.L.FormatoProdotto.OrientamentoStr)

            If O.L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                FormatoStr &= " " & O.DimensioniStr
            End If

        End If

        CellaVal.AddElement(New iTextSharp.text.Phrase("Formato: " & FormatoStr, CarattereNero))
        tbCentro.AddCell(CellaVal)
        tbCentro.AddCell(CellaVuota)
        CellaVal.CompositeElements.Clear()

        CellaVal.AddElement(New iTextSharp.text.Phrase(IIf(O.L.Preventivazione.IdReparto = enRepartoWeb.StampaDigitale Or O.L.Preventivazione.IdReparto = enRepartoWeb.Ricamo, "Materiale: ", "Tipo di carta: ") & O.TC.Tipologia, CarattereNero))
        tbCentro.AddCell(CellaVal)
        tbCentro.AddCell(CellaVuota)
        CellaVal.CompositeElements.Clear()

        If O.L.IdTipoCartaCop Then
            CellaVal.AddElement(New iTextSharp.text.Phrase(IIf(O.L.Preventivazione.IdReparto = enRepartoWeb.StampaDigitale, "", "Copertina: ") & O.L.TipoCartaCop.Tipologia, CarattereNero))
            tbCentro.AddCell(CellaVal)
            tbCentro.AddCell(CellaVuota)
            CellaVal.CompositeElements.Clear()
        End If

        If O.L.IdTipoCartaDorso Then
            CellaVal.AddElement(New iTextSharp.text.Phrase(IIf(O.L.Preventivazione.IdReparto = enRepartoWeb.StampaDigitale, "", "Sottoblocco: ") & O.L.TipoCartaDorso.Tipologia, CarattereNero))
            tbCentro.AddCell(CellaVal)
            tbCentro.AddCell(CellaVuota)
            CellaVal.CompositeElements.Clear()
        End If

        CellaVal.AddElement(New iTextSharp.text.Phrase("Colori di Stampa: " & O.C.Descrizione, CarattereNero))
        'CellaVal.FixedHeight = 10
        tbCentro.AddCell(CellaVal)
        tbCentro.AddCell(CellaVuota)
        CellaVal.CompositeElements.Clear()

        If O.L.ShowLabelFogli() Then
            CellaVal.AddElement(New iTextSharp.text.Phrase(O.L.GetLabelFogli & ": " & O.NFogliVis & IIf(O.L.Target = enTargetListinoBase.Pagina AndAlso O.L.IdTipoCartaCop <> 0, " compresa copertina", ""), CarattereNero))
            tbCentro.AddCell(CellaVal)
            tbCentro.AddCell(CellaVuota)
            CellaVal.CompositeElements.Clear()
        End If

        If O.LavorazioniIncluse.Count Then
            Dim buffLavorazioni As String = "Opzioni: " & ControlChars.NewLine

            For Each singL In O.LavorazioniIncluse.FindAll(Function(x) x.LavorazioneInterna = enSiNo.No)
                buffLavorazioni &= " - " & singL.Descrizione & ControlChars.NewLine
            Next
            'buffLavorazioni &= ControlChars.NewLine

            CellaVal.AddElement(New iTextSharp.text.Phrase(buffLavorazioni, CarattereNero))
            'CellaVal.FixedHeight = 10
            tbCentro.AddCell(CellaVal)
            tbCentro.AddCell(CellaVuota)
            CellaVal.CompositeElements.Clear()

        End If

        CellaVal.AddElement(New iTextSharp.text.Phrase(ControlChars.NewLine & "Informazioni aggiuntive", CarattereNeroBold))

        tbCentro.AddCell(CellaVal)
        tbCentro.AddCell(CellaVuota)
        CellaVal.CompositeElements.Clear()

        CellaVuota.Border = 0
        CellaVal.Border = 0

        Dim lblConsegna As String = "Data"

        Dim LCorr As New List(Of ICorriereBusiness)
        Using mgrC As New CorrieriWDAO
            LCorr = mgrC.GetListaCorrieri
        End Using

        Dim C As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(U.Utente.Corriere, LCorr, U.Utente.Cap)

        lblConsegna &= C.LabelDataConsegna
        C = Nothing

        CellaVal.AddElement(New iTextSharp.text.Phrase(lblConsegna & ": " & O.DataConsegnaStr, CarattereNero))
        'CellaVal.FixedHeight = 10
        tbCentro.AddCell(CellaVal)
        tbCentro.AddCell(CellaVuota)
        CellaVal.CompositeElements.Clear()

        Dim ModalitaDiPagamento As String = String.Empty

        Using tp As New TipoPagamentoW

            If U.Utente.IdPagamento Then
                tp.Read(U.Utente.IdPagamento)
            Else
                tp.Read(enMetodoPagamento.PayPal)
            End If
            ModalitaDiPagamento = tp.TipoPagam
        End Using

        CellaVal.AddElement(New iTextSharp.text.Phrase("Modalità di pagamento: " & ModalitaDiPagamento, CarattereNero))
        'CellaVal.FixedHeight = 10
        tbCentro.AddCell(CellaVal)
        tbCentro.AddCell(CellaVuota)
        CellaVal.CompositeElements.Clear()

        CellaVal.AddElement(New iTextSharp.text.Phrase("Colli: " & O.ColliStr, CarattereNero))
        'CellaVal.FixedHeight = 10
        tbCentro.AddCell(CellaVal)
        tbCentro.AddCell(CellaVuota)
        CellaVal.CompositeElements.Clear()

        CellaVal.AddElement(New iTextSharp.text.Phrase("Peso: " & O.PesoStr & " kg ±" & ControlChars.NewLine & ControlChars.NewLine, CarattereNero))
        'CellaVal.FixedHeight = 10
        tbCentro.AddCell(CellaVal)
        tbCentro.AddCell(CellaVuota)
        CellaVal.CompositeElements.Clear()

        'FINE TABELLA DETTAGLIO ORDINE
        CellaVuota.Border = 1

        Dim pTot As New Paragraph
        pTot.Alignment = PdfPCell.ALIGN_RIGHT
        pTot.Add(New iTextSharp.text.Phrase("Imponibile € " & O.TotaleNettoStr & ControlChars.NewLine, CarattereNeroBold))
        pTot.Add(New iTextSharp.text.Phrase("IVA € " & O.TotaleIvaStr & ControlChars.NewLine, CarattereNeroBold))
        pTot.Add(New iTextSharp.text.Phrase("Totale con IVA € " & O.TotaleOrdineStr & ControlChars.NewLine & ControlChars.NewLine, CarattereNeroBold))
        CellaVal.AddElement(pTot)
        CellaVal.Border = 1
        tbCentro.AddCell(CellaVuota)
        tbCentro.AddCell(CellaVal)
        CellaVal.CompositeElements.Clear()

        CellaVal.Border = 0
        Dim pCondiz As New Paragraph
        pCondiz.Alignment = PdfPCell.ALIGN_JUSTIFIED
        pCondiz.SetLeading(0, 1)

        pCondiz.Add(New iTextSharp.text.Phrase(ControlChars.NewLine & ControlChars.NewLine & ControlChars.NewLine & "CONDIZIONI DI VENDITA" & ControlChars.NewLine, CarattereNeroSmall))
        pCondiz.Add(New iTextSharp.text.Phrase("I prezzi indicati sono soggetti ad improvvise variazioni, verificare on line il prezzo prima dell’ordine. In caso di spedizione i costi sono esclusi dal presente preventivo e verranno conteggiati automaticamente al momento dell'ordine a seconda dell'indirizzo di consegna." & ControlChars.NewLine, CarattereNeroSmall))
        pCondiz.Add(New iTextSharp.text.Phrase(ControlChars.NewLine & "FILE ALLEGATI AL LAVORO" & ControlChars.NewLine, CarattereNeroSmall))
        pCondiz.Add(New iTextSharp.text.Phrase("Dopo aver effettuato l'ordine potrai allegare i file sorgenti con estrema semplicità tramite un apposito modulo nel sito internet." & ControlChars.NewLine, CarattereNeroSmall))
        pCondiz.Add(New iTextSharp.text.Phrase(ControlChars.NewLine & "RESPONSABILITA' DEL COMMITENTE" & ControlChars.NewLine, CarattereNeroSmall))
        pCondiz.Add(New iTextSharp.text.Phrase("La committente si assume la paternità dei contenuti oggetto di stampa esonerando la Tipografia Former dall'obbligo di esame degli stessi ed assumendosi, pertanto, qualsiasi responsabilità nei confronti di terzi che dovessero lamentare lesioni all'immagine, onore, decoro, integrità morale o comunque qualsiasi danno patrimoniale e non patrimoniale causalmente collegate alla stampa oggetto di contratto. La Tipografia Former si riserva la chiamata in manleva della committente nell'eventualità in cui domande risarcitorie venissero formulate direttamente nei suoi confronti." & ControlChars.NewLine, CarattereNeroSmall))
        pCondiz.Add(New iTextSharp.text.Phrase(ControlChars.NewLine & "CLAUSOLA ESONERO RESPONSABILITA'" & ControlChars.NewLine, CarattereNeroSmall))
        pCondiz.Add(New iTextSharp.text.Phrase("Tipografia Former non sarà responsabile nei confronti del committente e/o beneficiario della prestazione se diverso, per danni di qualsiasi specie, sia diretti che indiretti, derivanti da eventuali errori, di ogni natura, nella stampa del file inviato dal cliente o derivanti dalla ricezione di materiale sbagliato. In tali casi Tipografia Former sarà tenuta esclusivamente ad effettuare una sola ristampa del materiale qualora l'errore sia imputabile alla qualita della stampa. Parimenti Tipografia Former non sarà responsabile per danni, diretti e indiretti, dovuti alla mancata e/o ritardata consegna del materiale," & "né sarà responsabile di eventuali deterioramenti dell'imballaggio; in tali casi sarà tenuta esclusivamente ad effettuare una sola ristampa del materiale a condizione che il pacco venga accettato dal cliente ""con riserva dei vizi"" che dovranno essere elencati sulla ricevuta rilasciata dal corriere e comunicati a Tipografia Former a mezzo fax, a pena di decadenza, entro tre giorni dalla ricezione del plico. Eventuali errori nella stampa o nel confezionamento del materiale vanno segnalati alla email info@tipografiaformer.it con documentazione fotografica digitale allegata, avendo cura di indicare nell'oggetto il numero d'ordine di riferimento, entro tre giorni dalla ricezione del materiale. " & ControlChars.NewLine, CarattereNeroSmall))
        pCondiz.Add(New iTextSharp.text.Phrase(ControlChars.NewLine & "FORO DI COMPETENZA" & ControlChars.NewLine, CarattereNeroSmall))
        pCondiz.Add(New iTextSharp.text.Phrase("Per tutte le controversie relative all'interpretazione e/o all'esecuzione del presente contratto, le parti riconoscono l'esclusiva competenza del foro di Roma, indipendentemente dal luogo di conclusione del contratto, dal domicilio del committente, dal luogo di pagamento anche se per mezzo di tratta e/o di r.b." & ControlChars.NewLine, CarattereNeroSmall))

        CellaVal.AddElement(pCondiz)

        CellaVal.Colspan = 2
        tbCentro.AddCell(CellaVal)

        Doc.Add(tbCentro)

        Doc.Close()

        Return NomeFile

    End Function

End Class
