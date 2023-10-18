Imports System.IO

Imports FormerBusinessLogicInterface
Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class MGRListini

    Private Shared Sub AddFooter(ByRef W As PdfWriter,
                                NumPag As Integer,
                                Reparto As enRepartoWeb,
                                Listino As ListinoUtente)

        Dim tblNumPag As New PdfPTable(1)
        tblNumPag.TotalWidth = 50

        Dim ColoreTesto As BaseColor = BaseColor.BLACK

        If Reparto = enRepartoWeb.StampaOffset Or Reparto = enRepartoWeb.Etichette Then
            ColoreTesto = BaseColor.WHITE
        End If

        Dim cNumPag As New PdfPCell
        Dim ftestoNum As Font = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, ColoreTesto)
        Dim ParNum As New Paragraph(NumPag.ToString)
        ParNum.Alignment = 1
        ParNum.Font = ftestoNum
        ParNum.Leading = 8
        Dim ColoreReparto As Color = FormerLib.FormerColori.GetColoreReparto(Reparto)

        cNumPag.Border = 0
        cNumPag.BackgroundColor = New BaseColor(ColoreReparto.R, ColoreReparto.G, ColoreReparto.B)
        cNumPag.Padding = 10
        cNumPag.AddElement(ParNum)

        tblNumPag.AddCell(cNumPag)

        'Documento.Add(tblFooter)
        tblNumPag.WriteSelectedRows(0, -1, 500, 50, W.DirectContent)

        Dim tblData As New PdfPTable(1)
        tblData.TotalWidth = 100

        Dim cData As New PdfPCell
        Dim ftestoData As Font = FontFactory.GetFont("Arial", 9, 0, BaseColor.BLACK)
        Dim ValData As String = String.Empty

        If Listino.Versione.Length Then
            ValData = Listino.Versione & " "
        End If

        ValData &= Now.ToString("dd/MM/yyyy")

        Dim ParData As New Paragraph(ValData)
        ParData.Font = ftestoData
        ParData.Leading = 8

        cData.Border = 0
        cData.BackgroundColor = BaseColor.WHITE
        cData.Padding = 10
        cData.AddElement(ParData)

        tblData.AddCell(cData)

        'Documento.Add(tblFooter)
        tblData.WriteSelectedRows(0, -1, 50, 50, W.DirectContent)


    End Sub

    Private Shared Function CalcolaPrezzo(L As ListinoBaseW,
                                          Qta As Integer,
                                          Optional UtilizzaPrezzoRivenditore As Boolean = False) As Decimal
        Dim Ris As Decimal = 0

        Try

            Dim R As RisPrezzoIntermedio = Nothing

            Dim listaBaseB As List(Of ILavorazioneB) = L.LavorazioniBaseB
            Dim listaOpzB As List(Of ILavorazioneB) = Nothing

            L.NumFacciate = L.faccmin

            If L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
                Dim QtaRichiesta As Single = 0
                Dim QtaSecondaria As Integer = 0

                Dim LatoFisso As Integer = (L.FormatoProdotto.Fc.Larghezza * 10)
                Dim LatoRiferimento As Single = Math.Sqrt(FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.CmQuadriEsempio)

                QtaSecondaria = ((LatoRiferimento * LatoRiferimento)) * Qta
                QtaRichiesta = MgrCalcoliTecnici.CalcolaCmQuadri(LatoRiferimento,
                                                                LatoRiferimento,
                                                                enTipoOrientamento.Orizzontale,
                                                                LatoFisso,
                                                                QtaRichiesta)
                R = MgrPreventivazioneB.CalcolaPrezzoFinale(L, Qta, listaBaseB, QtaSecondaria,, False,, LatoRiferimento, LatoRiferimento)

            Else
                'Dim Fogli As Integer = 0

                'Try
                '    Fogli = L.faccmin / 2
                'Catch ex As Exception

                'End Try

                'If Fogli = 0 Then Fogli = 1

                'Dim QtaRichiesta As Integer = Convert.ToInt32(ddlQta.SelectedValue)



                'Dim _Risultato As RisultatoListinoBase
                '_Risultato = MgrPreventivazioneB.CalcolaPrezzi(L, listaBaseB, , False)

                'Dim R As RisultatoPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoIntermedio(Qta, L, _Risultato)

                Dim Altezza As Integer = 0
                Dim Larghezza As Integer = 0

                If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                    Altezza = 100
                    Larghezza = 100
                End If


                If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri AndAlso
                                L.ConSoggettiDuplicati = enSiNo.Si Then

                    If L.IdLavTaglioDuplicati Then
                        Dim LTaglio As New LavorazioneW
                        LTaglio.Read(L.IdLavTaglioDuplicati)
                        listaOpzB = New List(Of ILavorazioneB)
                        listaOpzB.Add(LTaglio)
                    End If


                End If

                'If L.IdListinoBase = 397 Then Stop


                R = MgrPreventivazioneB.CalcolaPrezzoFinale(L,
                                                            Qta,
                                                            listaBaseB,
                                                            Qta,
                                                            listaOpzB,
                                                            False,,
                                                            Altezza,
                                                            Larghezza,,
                                                            True)

            End If


            If UtilizzaPrezzoRivenditore Then
                Ris = R.PrezzoRiv
            Else
                Ris = R.PrezzoConsigliatoPubbl
            End If

        Catch ex As Exception

        End Try

        Return Ris

    End Function

    Public Shared Sub CreaCatalogo(PathFileDest As String,
                                   Listino As ListinoUtente,
                                   Optional PathWebListino As String = "http://www.tipografiaformer.it/",
                                   Optional UtilizzaPrezzoRivenditore As Boolean = False)

        Dim Margine As Single = 0

        Margine = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(10)

        Using Documento As Document = New Document(iTextSharp.text.PageSize.A4, Margine, Margine, Margine, Margine)
            Using w As PdfWriter = PdfWriter.GetInstance(Documento, New FileStream(PathFileDest, FileMode.Create))

                Documento.Open()

                'Documento.NewPage()

                Dim Indice As New Dictionary(Of Integer, Integer)

                'Dim fontPrincipale As BaseFont = BaseFont.CreateFont("Helvetica", BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
                Dim fTitolo1 As Font = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                'Dim fTitolo1 As Font = New Font(fontPrincipale, 14, Font.Bold, New BaseColor(Listino.ColoreContrasto.R, Listino.ColoreContrasto.G, Listino.ColoreContrasto.B))
                Dim fTitoloSezione As Font = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fTitolo2 As Font = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fTestoPiccolo As Font = FontFactory.GetFont("Arial", 8, BaseColor.BLACK)
                Dim fTestoPiccolissimo As Font = FontFactory.GetFont("Arial", 7, BaseColor.BLACK)
                Dim fTestoItalic As Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.ITALIC, BaseColor.BLACK)
                Dim fTestoBold As Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fTestoPrezzo As Font = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fReparto As Font = FontFactory.GetFont("Arial", 32, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

                Dim RepartoInCorso As enRepartoWeb = enRepartoWeb.Tutto

                'AGGIUNGO LA COPERTINA

                Dim tblCopertina As New PdfPTable(1)
                tblCopertina.WidthPercentage = 100

                Dim cCopertina As New PdfPCell
                'cTitolo.Colspan = 3
                cCopertina.Border = 0
                cCopertina.Padding = 30
                'cella.Padding = 10
                cCopertina.FixedHeight = 785
                cCopertina.BackgroundColor = New BaseColor(245, 245, 245)

                'ControlChars.NewLine & "LISTINO " & StrConv(Now.ToString("MMMM yyyy"), VbStrConv.ProperCase)

                cCopertina.AddElement(New Paragraph(Listino.Nominativo, fReparto))
                cCopertina.AddElement(New Paragraph("Listino " & StrConv(Now.ToString("MMMM yyyy"), VbStrConv.ProperCase) & ControlChars.NewLine & ControlChars.NewLine, fTitoloSezione))

                Dim tblReparti As New PdfPTable(1)

                Dim cRepartoCop As New PdfPCell
                cRepartoCop.Border = 0
                cRepartoCop.Padding = 10
                cRepartoCop.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoOffset.R,
                                                            FormerLib.FormerColori.ColoreRepartoOffset.G,
                                                            FormerLib.FormerColori.ColoreRepartoOffset.B)
                fTitoloSezione.Color = BaseColor.WHITE

                cRepartoCop.AddElement(New Paragraph("Stampa Offset", fTitoloSezione))

                tblReparti.AddCell(cRepartoCop)

                cRepartoCop = New PdfPCell
                cRepartoCop.Border = 0
                cRepartoCop.Padding = 10
                cRepartoCop.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoDigitale.R,
                                                            FormerLib.FormerColori.ColoreRepartoDigitale.G,
                                                            FormerLib.FormerColori.ColoreRepartoDigitale.B)
                fTitoloSezione.Color = BaseColor.WHITE

                cRepartoCop.AddElement(New Paragraph("Stampa Digitale", fTitoloSezione))

                tblReparti.AddCell(cRepartoCop)

                cRepartoCop = New PdfPCell
                cRepartoCop.Border = 0
                cRepartoCop.Padding = 10
                cRepartoCop.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoPackaging.R,
                                                            FormerLib.FormerColori.ColoreRepartoPackaging.G,
                                                            FormerLib.FormerColori.ColoreRepartoPackaging.B)
                fTitoloSezione.Color = BaseColor.WHITE

                cRepartoCop.AddElement(New Paragraph("Packaging", fTitoloSezione))

                tblReparti.AddCell(cRepartoCop)

                cRepartoCop = New PdfPCell
                cRepartoCop.Border = 0
                cRepartoCop.Padding = 10
                cRepartoCop.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoRicamo.R,
                                                            FormerLib.FormerColori.ColoreRepartoRicamo.G,
                                                            FormerLib.FormerColori.ColoreRepartoRicamo.B)
                fTitoloSezione.Color = BaseColor.BLACK

                cRepartoCop.AddElement(New Paragraph("Ricamo", fTitoloSezione))

                tblReparti.AddCell(cRepartoCop)

                cRepartoCop = New PdfPCell
                cRepartoCop.Border = 0
                cRepartoCop.Padding = 10
                cRepartoCop.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoEtichette.R,
                                                            FormerLib.FormerColori.ColoreRepartoEtichette.G,
                                                            FormerLib.FormerColori.ColoreRepartoEtichette.B)
                fTitoloSezione.Color = BaseColor.WHITE

                cRepartoCop.AddElement(New Paragraph("Etichette", fTitoloSezione))

                tblReparti.AddCell(cRepartoCop)

                cCopertina.AddElement(tblReparti)

                tblCopertina.AddCell(cCopertina)

                Documento.Add(tblCopertina)

                Documento.NewPage()

                fTitoloSezione.Color = BaseColor.BLACK

                Dim NumPag As Integer = 2
                Dim MaxLbInPage As Integer = 4
                Using mgr As New PreventivazioniWDAO
                    Dim l As List(Of PreventivazioneW) = mgr.FindAll("IdReparto, Descrizione",
                                                                     New LUNA.LunaSearchParameter("DispOnline", enSiNo.Si)) 'New LUNA.LunaSearchParameter("IdPrev", 10, "<"))

                    For Each singP As PreventivazioneW In l

                        If RepartoInCorso <> singP.IdReparto Then
                            RepartoInCorso = singP.IdReparto
                            Dim tblReparto As New PdfPTable(1)
                            tblReparto.WidthPercentage = 100

                            Dim cReparto As New PdfPCell
                            'cTitolo.Colspan = 3
                            cReparto.Border = 0
                            cReparto.Padding = 30
                            'cella.Padding = 10
                            cReparto.FixedHeight = 785

                            Select Case RepartoInCorso
                                Case enRepartoWeb.StampaOffset
                                    cReparto.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoOffset.R,
                                                                             FormerLib.FormerColori.ColoreRepartoOffset.G,
                                                                             FormerLib.FormerColori.ColoreRepartoOffset.B)
                                    fReparto.Color = BaseColor.WHITE

                                Case enRepartoWeb.StampaDigitale
                                    cReparto.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoDigitale.R,
                                                                             FormerLib.FormerColori.ColoreRepartoDigitale.G,
                                                                             FormerLib.FormerColori.ColoreRepartoDigitale.B)
                                    fReparto.Color = BaseColor.WHITE

                                Case enRepartoWeb.Ricamo
                                    cReparto.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoRicamo.R,
                                                                             FormerLib.FormerColori.ColoreRepartoRicamo.G,
                                                                             FormerLib.FormerColori.ColoreRepartoRicamo.B)
                                    fReparto.Color = BaseColor.BLACK

                                Case enRepartoWeb.Etichette
                                    cReparto.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoEtichette.R,
                                                                             FormerLib.FormerColori.ColoreRepartoEtichette.G,
                                                                             FormerLib.FormerColori.ColoreRepartoEtichette.B)
                                    fReparto.Color = BaseColor.WHITE

                                Case enRepartoWeb.Packaging
                                    cReparto.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoPackaging.R,
                                                                             FormerLib.FormerColori.ColoreRepartoPackaging.G,
                                                                             FormerLib.FormerColori.ColoreRepartoPackaging.B)
                                    fReparto.Color = BaseColor.WHITE

                            End Select

                            cReparto.AddElement(New Paragraph(singP.RepartoStr, fReparto))
                            tblReparto.AddCell(cReparto)
                            'qui aggiungo la pagina 
                            Documento.Add(tblReparto)
                            NumPag += 1
                            Documento.NewPage()
                        End If

                        Indice.Add(singP.IdPrev, NumPag)

                        Dim CounterLb As Integer = 0

                        Dim listLB As List(Of ListinoBaseW) = singP.GetListiniBase

                        For Each singL As ListinoBaseW In listLB

                            singL.CaricaLavorazioniBase()
                            singL.CaricaLavorazioniOpz()

                            If CounterLb = MaxLbInPage Then
                                'aggiungo il footer

                                AddFooter(w, NumPag, singP.IdReparto, Listino)

                                NumPag += 1

                                Documento.NewPage()
                                CounterLb = 0
                            End If

                            If CounterLb = 0 Then

                                Dim tabPre As PdfPTable = New PdfPTable(1)
                                tabPre.WidthPercentage = 100

                                Dim cTitolo As New PdfPCell
                                'cTitolo.Colspan = 3
                                cTitolo.Border = 0
                                cTitolo.Top = 0
                                cTitolo.PaddingTop = 0
                                'cella.Padding = 10
                                cTitolo.FixedHeight = 32

                                Select Case singP.IdReparto
                                    Case enRepartoWeb.StampaOffset
                                        cTitolo.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoOffset.R,
                                                                             FormerLib.FormerColori.ColoreRepartoOffset.G,
                                                                             FormerLib.FormerColori.ColoreRepartoOffset.B)
                                        fTitolo1.Color = BaseColor.WHITE

                                    Case enRepartoWeb.StampaDigitale
                                        cTitolo.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoDigitale.R,
                                                                             FormerLib.FormerColori.ColoreRepartoDigitale.G,
                                                                             FormerLib.FormerColori.ColoreRepartoDigitale.B)
                                        fTitolo1.Color = BaseColor.WHITE

                                    Case enRepartoWeb.Ricamo
                                        cTitolo.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoRicamo.R,
                                                                             FormerLib.FormerColori.ColoreRepartoRicamo.G,
                                                                             FormerLib.FormerColori.ColoreRepartoRicamo.B)
                                        fTitolo1.Color = BaseColor.BLACK

                                    Case enRepartoWeb.Etichette
                                        cTitolo.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoEtichette.R,
                                                                             FormerLib.FormerColori.ColoreRepartoEtichette.G,
                                                                             FormerLib.FormerColori.ColoreRepartoEtichette.B)
                                        fTitolo1.Color = BaseColor.WHITE

                                    Case enRepartoWeb.Packaging
                                        cTitolo.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoPackaging.R,
                                                                             FormerLib.FormerColori.ColoreRepartoPackaging.G,
                                                                             FormerLib.FormerColori.ColoreRepartoPackaging.B)
                                        fTitolo1.Color = BaseColor.WHITE

                                End Select

                                'cTitolo.BackgroundColor = New BaseColor(Listino.ColoreSfondo.R, Listino.ColoreSfondo.G, Listino.ColoreSfondo.B)

                                Dim pTitolo As New Paragraph(singP.Descrizione.ToUpper, fTitolo1)
                                pTitolo.Alignment = 1

                                cTitolo.AddElement(pTitolo)

                                tabPre.AddCell(cTitolo)

                                Dim cDescr As New PdfPCell
                                'cDescr.Colspan = 3
                                cDescr.Border = 0
                                'cDescr.FixedHeight = 60

                                cDescr.BackgroundColor = BaseColor.WHITE

                                Dim DescrPre As String = singP.DescrizioneEstesa.Replace("Tipografia Former", Listino.Nominativo)
                                DescrPre = DescrPre.Replace("Former", Listino.Nominativo)

                                Dim pDescr As New Paragraph(DescrPre, fTestoPiccolo)
                                cDescr.AddElement(pDescr)

                                tabPre.AddCell(cDescr)

                                Documento.Add(tabPre)

                            End If

                            Dim tabLb As PdfPTable = New PdfPTable(3)
                            tabLb.WidthPercentage = 90
                            Dim larghezza As Single() = New Single() {90, 300, 300}
                            tabLb.SetWidths(larghezza)
                            tabLb.SpacingBefore = 10

                            CounterLb += 1

                            Dim cLbHeader As New PdfPCell
                            cLbHeader.Colspan = 3
                            cLbHeader.Border = 0
                            Dim NomeLb As String = singL.Nome

                            If singL.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
                                NomeLb &= " (prezzi riferiti a " & FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.CmQuadriEsempio & " cm^2)"
                            End If

                            cLbHeader.AddElement(New Paragraph(NomeLb, fTitolo2))

                            tabLb.AddCell(cLbHeader)

                            Dim cLbDescr As New PdfPCell
                            cLbDescr.Colspan = 3
                            cLbDescr.Border = 0

                            Dim DescrLb As String = singL.DescrSito.Replace(ControlChars.NewLine, " ")

                            DescrLb = DescrLb.Replace("Tipografia Former", Listino.Nominativo)
                            DescrLb = DescrLb.Replace("Former", Listino.Nominativo)

                            cLbDescr.AddElement(New Paragraph(DescrLb, fTestoItalic))
                            tabLb.AddCell(cLbDescr)

                            Dim cImg As New PdfPCell
                            cImg.Border = 0
                            cImg.Padding = 0
                            cImg.PaddingTop = 20

                            Try
                                Dim PathImgRemoto As String = PathWebListino & "listino/img/" & singL.GetImgFormato
                                Dim img As Image = Image.GetInstance(PathImgRemoto)
                                img.ScaleAbsoluteWidth(60)
                                img.ScaleAbsoluteHeight(60)

                                cImg.AddElement(img)
                            Catch ex As Exception

                            End Try

                            tabLb.AddCell(cImg)

                            Dim cLav As New PdfPCell
                            cLav.Border = 0
                            cLav.PaddingTop = 10
                            cLav.PaddingLeft = 10

                            If singL.LavorazioniOpz.Count Then
                                Dim pLav As New Paragraph("Opzioni:")
                                pLav.Font = fTestoBold
                                cLav.AddElement(pLav)
                            End If
                            Dim LavorazInserite As Integer = 0

                            For Each lav As LavorazioneW In singL.LavorazioniOpz

                                If LavorazInserite < 7 Then
                                    Dim pLav As New Paragraph("- " & lav.Descrizione)
                                    pLav.Font = fTestoPiccolissimo
                                    cLav.AddElement(pLav)
                                    LavorazInserite += 1
                                ElseIf LavorazInserite = 7 Then

                                    Dim pLav As New Paragraph("- ...")
                                    pLav.Font = fTestoPiccolissimo
                                    cLav.AddElement(pLav)
                                    Exit For
                                End If

                            Next

                            tabLb.AddCell(cLav)

                            Dim cPrezzi As New PdfPCell
                            cPrezzi.Border = 0
                            cPrezzi.PaddingTop = 10
                            cPrezzi.PaddingLeft = 10

                            'cPrezzi.Colspan = 2

                            'qui ci va la tabella dei prezzi 
                            Dim tabPrezzi As PdfPTable = New PdfPTable(3)
                            tabPrezzi.WidthPercentage = 100
                            Dim larghezzaPrezzi As Single() = New Single() {30, 25, 45}
                            tabPrezzi.SetWidths(larghezzaPrezzi)

                            Dim qtaH As New PdfPCell
                            Dim parH As New Paragraph("Quantità")
                            parH.Alignment = 1
                            parH.Font = fTestoBold
                            parH.Leading = 10
                            qtaH.BackgroundColor = New BaseColor(230, 230, 230)
                            qtaH.Border = 0
                            qtaH.Top = 0
                            qtaH.PaddingTop = 0
                            qtaH.FixedHeight = 14
                            qtaH.AddElement(parH)

                            tabPrezzi.AddCell(qtaH)

                            qtaH = New PdfPCell
                            parH = New Paragraph("Peso")
                            parH.Leading = 10
                            parH.Alignment = 1
                            parH.Font = fTestoBold
                            qtaH.Top = 0
                            qtaH.PaddingTop = 0
                            qtaH.BackgroundColor = New BaseColor(230, 230, 230)
                            qtaH.Border = 0
                            qtaH.FixedHeight = 14
                            qtaH.AddElement(parH)

                            tabPrezzi.AddCell(qtaH)

                            qtaH = New PdfPCell
                            parH = New Paragraph("Prezzo (+ iva)")
                            parH.Leading = 10
                            parH.Alignment = 1
                            parH.Font = fTestoBold
                            qtaH.Top = 0
                            qtaH.PaddingTop = 0
                            qtaH.BackgroundColor = New BaseColor(230, 230, 230)
                            qtaH.Border = 0
                            qtaH.FixedHeight = 14

                            qtaH.AddElement(parH)
                            tabPrezzi.AddCell(qtaH)

                            'PREPARO LE CINQUE QUANTITA
                            Dim Qta1 As Integer = 0
                            Dim Qta2 As Integer = 0
                            Dim Qta3 As Integer = 0
                            Dim Qta4 As Integer = 0
                            Dim Qta5 As Integer = 0

                            If singL.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
                                Qta1 = 500
                                Qta2 = 1000
                                Qta3 = 5000
                                Qta4 = 10000
                                Qta5 = 50000
                            Else
                                Qta1 = singL.qta1
                                Qta2 = singL.qta2
                                Qta3 = singL.qta3
                                Qta4 = singL.qta4
                                Qta5 = singL.qta5
                            End If

                            'qui vedo prima se ci sono qta impostate dall'utente del listino, altrimenti se ci sono da noi , altrimenti prende quelle del listino base
                            Using mgrP As New ParamListiniDAO
                                Dim ParListino As ParamListino = Nothing
                                Dim LP As List(Of ParamListino) = mgrP.FindAll(New LUNA.LunaSearchParameter("IdPrev", singP.IdPrev),
                                                                              New LUNA.LunaSearchParameter("IdUt", Listino.IdUt))

                                If LP.Count Then
                                    ParListino = LP(0)
                                Else
                                    LP = mgrP.FindAll(New LUNA.LunaSearchParameter("IdPrev", singP.IdPrev),
                                                     New LUNA.LunaSearchParameter("IdUt", 0))
                                    If LP.Count Then
                                        ParListino = LP(0)
                                    End If
                                End If

                                If Not ParListino Is Nothing Then
                                    Qta1 = ParListino.Qta1
                                    Qta2 = ParListino.Qta2
                                    Qta3 = ParListino.Qta3
                                    Qta4 = ParListino.Qta4
                                    Qta5 = ParListino.Qta5
                                End If

                            End Using

                            For i As Integer = 1 To 5
                                Dim QtaRif As Integer = 0
                                Select Case i
                                    Case 1
                                        QtaRif = Qta1
                                    Case 2
                                        QtaRif = Qta2
                                    Case 3
                                        QtaRif = Qta3
                                    Case 4
                                        QtaRif = Qta4
                                    Case 5
                                        QtaRif = Qta5
                                End Select

                                Dim qtaCel As New PdfPCell
                                qtaCel.Border = 0
                                qtaCel.BorderWidthRight = 0.5
                                qtaCel.BorderColorRight = BaseColor.GRAY
                                qtaCel.BorderWidthBottom = 0.5
                                qtaCel.BorderColorBottom = BaseColor.GRAY
                                qtaCel.Padding = 0
                                qtaCel.PaddingRight = 10
                                qtaCel.FixedHeight = 16

                                Dim qtaVal As New Paragraph(QtaRif.ToString)
                                qtaVal.Alignment = 0
                                qtaVal.Font = fTestoPiccolo
                                qtaVal.Alignment = 2
                                qtaCel.AddElement(qtaVal)

                                Dim PesoCel As New PdfPCell
                                PesoCel.Border = 0
                                PesoCel.BorderWidthRight = 0.5
                                PesoCel.BorderColorRight = BaseColor.GRAY
                                PesoCel.BorderWidthBottom = 0.5
                                PesoCel.BorderColorBottom = BaseColor.GRAY
                                PesoCel.Padding = 0
                                PesoCel.PaddingRight = 10
                                PesoCel.FixedHeight = 16

                                Dim PesoRif As String = String.Empty

                                If singL.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
                                    Dim QtaPeso As Integer = 0
                                    QtaPeso = QtaRif * FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.CmQuadriEsempio
                                    PesoRif = singL.GetPesoRiferimentoPerSpedizione(QtaPeso) & " kg ±"

                                Else
                                    PesoRif = singL.GetPesoRiferimentoPerSpedizione(QtaRif) & " kg ±"
                                End If

                                Dim PesoVal As New Paragraph(PesoRif)
                                PesoVal.Alignment = 0
                                PesoVal.Font = fTestoPiccolo
                                PesoVal.Alignment = 2
                                PesoCel.AddElement(PesoVal)

                                Dim prezzoCel As New PdfPCell

                                prezzoCel.Border = 0
                                prezzoCel.BorderWidthBottom = 0.5
                                prezzoCel.BorderColorBottom = BaseColor.GRAY
                                prezzoCel.Padding = 0
                                prezzoCel.PaddingRight = 10
                                prezzoCel.FixedHeight = 16
                                Dim Prezzo As Integer = CalcolaPrezzo(singL, QtaRif, UtilizzaPrezzoRivenditore)

                                If Listino.PercRicarico Then
                                    Try
                                        Prezzo = Prezzo + (Prezzo * Listino.PercRicarico / 100)
                                    Catch ex As Exception

                                    End Try
                                End If

                                Dim prezzoVal As New Paragraph("€ " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Prezzo))
                                prezzoVal.Alignment = 0
                                prezzoVal.Leading = 12
                                prezzoVal.Font = fTestoPrezzo
                                prezzoVal.Alignment = 2
                                prezzoCel.AddElement(prezzoVal)

                                tabPrezzi.AddCell(qtaCel)
                                tabPrezzi.AddCell(PesoCel)
                                tabPrezzi.AddCell(prezzoCel)

                            Next

                            cPrezzi.AddElement(tabPrezzi)
                            tabLb.AddCell(cPrezzi)

                            Documento.Add(tabLb)

                        Next

                        If CounterLb <= MaxLbInPage Then
                            'aggiungo il footer

                            AddFooter(w, NumPag, singP.IdReparto, Listino)

                            NumPag += 1
                        End If

                        Documento.NewPage()

                    Next

                    'qui ci vanno i prezzi di spedizione
                    Dim ParPrezziSped As New Paragraph("Tariffe spedizione" & ControlChars.NewLine, fTitoloSezione)
                    Dim fTestoCorr As Font = FontFactory.GetFont("Arial", 11, BaseColor.BLACK)

                    Documento.Add(ParPrezziSped)

                    Dim pCorr As New Paragraph("Per le nostre spedizioni utilizziamo il corriere nazionale GLS." & ControlChars.NewLine & ControlChars.NewLine & ControlChars.NewLine, fTestoCorr)
                    Documento.Add(pCorr)

                    Documento.Add(New Paragraph("Tariffe Nazionali" & ControlChars.NewLine & ControlChars.NewLine, fTitolo2))

                    Dim tbCorr As New PdfPTable(2)
                    tbCorr.WidthPercentage = 30

                    Dim qtaKg As New PdfPCell
                    Dim parKg As New Paragraph("Kg")
                    parKg.Alignment = 1
                    parKg.Font = fTestoBold
                    parKg.Leading = 10
                    qtaKg.BackgroundColor = New BaseColor(230, 230, 230)
                    qtaKg.Border = 0
                    qtaKg.Top = 0
                    qtaKg.PaddingTop = 0
                    qtaKg.FixedHeight = 14
                    qtaKg.AddElement(parKg)

                    tbCorr.AddCell(qtaKg)

                    qtaKg = New PdfPCell
                    parKg = New Paragraph("Prezzo (+ iva)")
                    parKg.Leading = 10
                    parKg.Alignment = 1
                    parKg.Font = fTestoBold
                    qtaKg.Top = 0
                    qtaKg.PaddingTop = 0
                    qtaKg.BackgroundColor = New BaseColor(230, 230, 230)
                    qtaKg.Border = 0
                    qtaKg.FixedHeight = 14

                    qtaKg.AddElement(parKg)
                    tbCorr.AddCell(qtaKg)

                    Using c As New CorriereW
                        c.Read(enCorriere.GLS)
                        For i As Integer = 1 To 7

                            Dim Range As String = String.Empty
                            Dim Prezzo As String = String.Empty

                            Select Case i
                                Case 1
                                    Range = "0 - " & c.KgLimite1
                                    Prezzo = c.TariffaLimite1
                                Case 2
                                    Range = c.KgLimite1 & " - " & c.KgLimite2
                                    Prezzo = c.TariffaLimite2
                                Case 3
                                    Range = c.KgLimite2 & " - " & c.KgLimite3
                                    Prezzo = c.TariffaLimite3
                                Case 4
                                    Range = c.KgLimite3 & " - " & c.KgLimite4
                                    Prezzo = c.TariffaLimite4
                                Case 5
                                    Range = c.KgLimite4 & " - " & c.KgLimite5
                                    Prezzo = c.TariffaLimite5
                                Case 6
                                    Range = c.KgLimite5 & " - " & c.KgLimite6
                                    Prezzo = c.TariffaLimite6
                                Case 7
                                    Range = "Ogni " & c.KgLimite7 & "kg oltre " & c.KgLimite6
                                    Prezzo = c.TariffaLimite7

                            End Select

                            Dim qtaCel As New PdfPCell
                            qtaCel.Border = 0
                            qtaCel.BorderWidthRight = 0.5
                            qtaCel.BorderColorRight = BaseColor.GRAY
                            qtaCel.BorderWidthBottom = 0.5
                            qtaCel.BorderColorBottom = BaseColor.GRAY
                            qtaCel.Padding = 0
                            qtaCel.PaddingRight = 10
                            qtaCel.FixedHeight = 16

                            Dim qtaVal As New Paragraph(Range)
                            qtaVal.Alignment = 0
                            qtaVal.Font = fTestoPiccolo
                            qtaVal.Alignment = 2
                            qtaCel.AddElement(qtaVal)
                            tbCorr.AddCell(qtaCel)

                            Dim prezzoCel As New PdfPCell

                            prezzoCel.Border = 0
                            prezzoCel.BorderWidthBottom = 0.5
                            prezzoCel.BorderColorBottom = BaseColor.GRAY
                            prezzoCel.Padding = 0
                            prezzoCel.PaddingRight = 10
                            prezzoCel.FixedHeight = 16

                            Dim prezzoVal As New Paragraph("€ " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Prezzo))
                            prezzoVal.Alignment = 0
                            prezzoVal.Leading = 12
                            prezzoVal.Font = fTestoPrezzo
                            prezzoVal.Alignment = 2
                            prezzoCel.AddElement(prezzoVal)
                            tbCorr.AddCell(prezzoCel)
                        Next
                    End Using

                    Documento.Add(tbCorr)

                    Documento.Add(New Paragraph("Tariffe per le Isole" & ControlChars.NewLine & ControlChars.NewLine, fTitolo2))



                    Dim tbCorrIsole As New PdfPTable(2)
                    tbCorrIsole.WidthPercentage = 30

                    Dim qtaKgIsole As New PdfPCell
                    Dim parKgIsole As New Paragraph("Kg")
                    parKgIsole.Alignment = 1
                    parKgIsole.Font = fTestoBold
                    parKgIsole.Leading = 10
                    qtaKgIsole.BackgroundColor = New BaseColor(230, 230, 230)
                    qtaKgIsole.Border = 0
                    qtaKgIsole.Top = 0
                    qtaKgIsole.PaddingTop = 0
                    qtaKgIsole.FixedHeight = 14
                    qtaKgIsole.AddElement(parKgIsole)

                    tbCorrIsole.AddCell(qtaKgIsole)

                    qtaKgIsole = New PdfPCell
                    parKgIsole = New Paragraph("Prezzo (+ iva)")
                    parKgIsole.Leading = 10
                    parKgIsole.Alignment = 1
                    parKgIsole.Font = fTestoBold
                    qtaKgIsole.Top = 0
                    qtaKgIsole.PaddingTop = 0
                    qtaKgIsole.BackgroundColor = New BaseColor(230, 230, 230)
                    qtaKgIsole.Border = 0
                    qtaKgIsole.FixedHeight = 14

                    qtaKgIsole.AddElement(parKgIsole)
                    tbCorrIsole.AddCell(qtaKgIsole)

                    Using c As New CorriereW
                        c.Read(enCorriere.GLSIsole)
                        For i As Integer = 1 To 7

                            Dim Range As String = String.Empty
                            Dim Prezzo As String = String.Empty

                            Select Case i
                                Case 1
                                    Range = "0 - " & c.KgLimite1
                                    Prezzo = c.TariffaLimite1
                                Case 2
                                    Range = c.KgLimite1 & " - " & c.KgLimite2
                                    Prezzo = c.TariffaLimite2
                                Case 3
                                    Range = c.KgLimite2 & " - " & c.KgLimite3
                                    Prezzo = c.TariffaLimite3
                                Case 4
                                    Range = c.KgLimite3 & " - " & c.KgLimite4
                                    Prezzo = c.TariffaLimite4
                                Case 5
                                    Range = c.KgLimite4 & " - " & c.KgLimite5
                                    Prezzo = c.TariffaLimite5
                                Case 6
                                    Range = c.KgLimite5 & " - " & c.KgLimite6
                                    Prezzo = c.TariffaLimite6
                                Case 7
                                    Range = "Ogni " & c.KgLimite7 & "kg oltre " & c.KgLimite6
                                    Prezzo = c.TariffaLimite7

                            End Select

                            Dim qtaCel As New PdfPCell
                            qtaCel.Border = 0
                            qtaCel.BorderWidthRight = 0.5
                            qtaCel.BorderColorRight = BaseColor.GRAY
                            qtaCel.BorderWidthBottom = 0.5
                            qtaCel.BorderColorBottom = BaseColor.GRAY
                            qtaCel.Padding = 0
                            qtaCel.PaddingRight = 10
                            qtaCel.FixedHeight = 16

                            Dim qtaVal As New Paragraph(Range)
                            qtaVal.Alignment = 0
                            qtaVal.Font = fTestoPiccolo
                            qtaVal.Alignment = 2
                            qtaCel.AddElement(qtaVal)
                            tbCorrIsole.AddCell(qtaCel)

                            Dim prezzoCel As New PdfPCell

                            prezzoCel.Border = 0
                            prezzoCel.BorderWidthBottom = 0.5
                            prezzoCel.BorderColorBottom = BaseColor.GRAY
                            prezzoCel.Padding = 0
                            prezzoCel.PaddingRight = 10
                            prezzoCel.FixedHeight = 16

                            Dim prezzoVal As New Paragraph("€ " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Prezzo))
                            prezzoVal.Alignment = 0
                            prezzoVal.Leading = 12
                            prezzoVal.Font = fTestoPrezzo
                            prezzoVal.Alignment = 2
                            prezzoCel.AddElement(prezzoVal)
                            tbCorrIsole.AddCell(prezzoCel)
                        Next
                    End Using

                    Documento.Add(tbCorrIsole)

                    AddFooter(w, NumPag, enRepartoWeb.Tutto, Listino)

                    Documento.NewPage()

                    'qui ci va l'indice
                    'l'ultimo valore in numpag e' il valore dei costi di spedizione
                    Dim ParIndice As New Paragraph("Indice", fTitoloSezione)

                    Documento.Add(ParIndice)

                    RepartoInCorso = enRepartoWeb.Tutto

                    Dim tblIndice As New PdfPTable(2)
                    tblIndice.WidthPercentage = 100
                    Dim larghezzaIndice As Single() = New Single() {80, 20}
                    tblIndice.SetWidths(larghezzaIndice)

                    Dim fRepartoIndice As Font = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.WHITE)
                    Dim fIndice As Font = FontFactory.GetFont("Arial", 12, 0, BaseColor.BLACK)
                    Dim fIndiceB As Font = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                    For Each singP As PreventivazioneW In l

                        If RepartoInCorso <> singP.IdReparto Then
                            RepartoInCorso = singP.IdReparto

                            Dim cSpazioP As New PdfPCell
                            cSpazioP.Border = 0
                            cSpazioP.Colspan = 2
                            cSpazioP.FixedHeight = 10
                            cSpazioP.AddElement(New Phrase(""))
                            tblIndice.AddCell(cSpazioP)

                            Dim cIndiceP As New PdfPCell
                            cIndiceP.Border = 0
                            cIndiceP.Colspan = 2

                            Select Case RepartoInCorso
                                Case enRepartoWeb.StampaOffset
                                    cIndiceP.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoOffset.R,
                                                                             FormerLib.FormerColori.ColoreRepartoOffset.G,
                                                                             FormerLib.FormerColori.ColoreRepartoOffset.B)
                                    fRepartoIndice.Color = BaseColor.WHITE

                                Case enRepartoWeb.StampaDigitale
                                    cIndiceP.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoDigitale.R,
                                                                             FormerLib.FormerColori.ColoreRepartoDigitale.G,
                                                                             FormerLib.FormerColori.ColoreRepartoDigitale.B)
                                    fRepartoIndice.Color = BaseColor.WHITE

                                Case enRepartoWeb.Ricamo
                                    cIndiceP.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoRicamo.R,
                                                                             FormerLib.FormerColori.ColoreRepartoRicamo.G,
                                                                             FormerLib.FormerColori.ColoreRepartoRicamo.B)
                                    fRepartoIndice.Color = BaseColor.BLACK

                                Case enRepartoWeb.Etichette
                                    cIndiceP.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoEtichette.R,
                                                                             FormerLib.FormerColori.ColoreRepartoEtichette.G,
                                                                             FormerLib.FormerColori.ColoreRepartoEtichette.B)
                                    fRepartoIndice.Color = BaseColor.WHITE

                                Case enRepartoWeb.Packaging
                                    cIndiceP.BackgroundColor = New BaseColor(FormerLib.FormerColori.ColoreRepartoPackaging.R,
                                                                             FormerLib.FormerColori.ColoreRepartoPackaging.G,
                                                                             FormerLib.FormerColori.ColoreRepartoPackaging.B)
                                    fRepartoIndice.Color = BaseColor.WHITE

                            End Select
                            Dim ParRep As New Paragraph(singP.RepartoStr, fRepartoIndice)
                            ParRep.Leading = 12
                            cIndiceP.FixedHeight = 20
                            cIndiceP.AddElement(ParRep)
                            tblIndice.AddCell(cIndiceP)
                        End If

                        Dim cIndPrev As New PdfPCell
                        cIndPrev.Border = 0
                        cIndPrev.BorderWidthBottom = 1
                        cIndPrev.BorderColorBottom = New BaseColor(185, 185, 185)

                        cIndPrev.AddElement(New Paragraph(singP.Descrizione, fIndice))
                        tblIndice.AddCell(cIndPrev)

                        Dim NumPagPrev As Integer = Indice(singP.IdPrev)
                        cIndPrev = New PdfPCell
                        cIndPrev.Border = 0
                        cIndPrev.BorderWidthBottom = 1
                        cIndPrev.BorderColorBottom = New BaseColor(185, 185, 185)
                        Dim PPag As New Paragraph(NumPagPrev, fIndiceB)
                        PPag.Alignment = HorizontalAlignment.Center

                        cIndPrev.AddElement(PPag)
                        tblIndice.AddCell(cIndPrev)
                    Next

                    Documento.Add(tblIndice)

                End Using

                Documento.Close()
                Documento.Dispose()
            End Using
        End Using

    End Sub

End Class
