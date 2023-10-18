Imports System.IO
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrReport

    Public Shared Function ReportDocumentiMensiliEmessiIncassati(Optional Anno As Integer = 0) As String

        Dim Ris As String = FormerConfig.FormerPath.PathTempLocale & "ReportEmessiIncassati_" & Now.ToString("yyyyMMdd") & ".htm"

        Dim IdAzienda As Integer = MgrAziende.IdAziende.AziendaSrl
        Dim Buffer As String = String.Empty

        Buffer &= GetReportDocumentiMensiliEmessiIncassati(Anno)

        Using w As New StreamWriter(Ris)
            w.Write(Buffer)
        End Using

        Return Ris

    End Function

    Public Shared Function RiassuntoPreventivazione(IdPrev As Integer) As String

        Dim buffer As String = String.Empty

        Dim Ris As String = FormerConfig.FormerPath.PathTempLocale & "RiassuntoPreventivazione_" & Now.ToString("yyyyMMdd") & ".htm"

        Using P As New Preventivazione
            P.Read(IdPrev)
            buffer &= "<font face=Arial><h2>" & P.Descrizione & "</h2>"
            buffer &= "<table cellpadding=5 style='border:1px solid black;'>"
            buffer &= "<tr style='background-color:lightgray;'><td>LISTINO BASE</td><td>V1</td><td>V2</td><td>V3</td><td>V4</td><td>V5</td><td>V6</td><td>Molt. 1</td><td>Molt. 2</td><td>Molt. 3</td><td>Molt. 4</td><td>Molt. 5</td><td>Qta &lt; colonna 1</td><td>Qta Intermedie</td></tr>"
            P.CaricaListinoBase(, enTipoListiniBase.Sorgente)
            For Each lb As ListinoBase In P.ListiniBase
                buffer &= "<tr><td style='border-bottom:1px solid darkgray;'>" & lb.Nome & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.qta1 & "<br>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(lb.v1) & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.qta2 & "<br>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(lb.v2) & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.qta3 & "<br>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(lb.v3) & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.qta4 & "<br>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(lb.v4) & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.qta5 & "<br>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(lb.v5) & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.qta6 & "<br>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(lb.v6) & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.MoltiplicatoreQta & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.MoltiplicatoreQta2 & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.MoltiplicatoreQta3 & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.MoltiplicatoreQta4 & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & lb.MoltiplicatoreQta5 & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & IIf(lb.AbilitaQtaSottoColonna1 = enSiNo.Si, "SI", "NO") & "</td>"
                buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & IIf(lb.AbilitaQtaIntermedie = enSiNo.Si, "SI", "NO") & "</td>"

                buffer &= "</tr>"
            Next

            buffer &= "</table></font>"

        End Using

        Using w As New StreamWriter(Ris)
            w.Write(buffer)
        End Using

        Return Ris

    End Function

    Private Shared Function GetReportDocumentiMensiliEmessiIncassati(Optional Anno As Integer = 0) As String
        Dim Buffer As String = "<font face=Arial><table cellpadding=5 style='border:1px solid black;'>"
                buffer &= "<tr style='background-color:lightgray;'><td>MESE</td><td>Totale</td><td>Incassato</td><td>Da Incassare</td></tr>"

        Dim AR As New cAnnoRif

        For Each SingoloAnno As cEnum In AR
            Dim LavoraAnno As Boolean = True

            If SingoloAnno.Id = 0 Then LavoraAnno = False

            If Anno <> 0 Then
                If SingoloAnno.Id <> Anno Then LavoraAnno = False
            End If

            If LavoraAnno Then
                Dim MaxMesi As Integer = 12

                If SingoloAnno.Id = Now.Year Then MaxMesi = Now.Month
                Using mgr As New RicaviDAO
                    For mese As Integer = MaxMesi To 1 Step -1
                        Dim BufferMese As String = String.Empty
                        Dim l As List(Of Ricavo) = mgr.GetBySQL("select * from t_contabricavi where month(dataricavo) = " & mese & " and year(dataricavo) = " & SingoloAnno.Id & " and (tipo in (" & enTipoDocumento.Fattura & "," & enTipoDocumento.Preventivo & "," & enTipoDocumento.FatturaRiepilogativa & ") or (tipo = " & enTipoDocumento.DDT & " and IdDocRif =0)) and idricavo not in (Select distinct IdFatturaNotaDiCredito from t_contabricavi where IdFatturaNotaDiCredito<>0 and not IdFatturaNotaDiCredito is null) order by dataricavo desc")

                        l = l.FindAll(Function(x) x.Tipo <> enTipoDocumento.Preventivo Or (x.Tipo = enTipoDocumento.Preventivo And x.TotaleAncoraDaPagare <> 0))
                        If l.Count Then
                            BufferMese = "<tr><td style='border-bottom:1px solid darkgray;'>" & FormerHelper.Calendario.MeseToString(mese) & " " & SingoloAnno.Id & "</td>"

                            Dim TotFatturato As Decimal = l.Sum(Function(x) x.Totale)

                            Dim TotPagato As Decimal = l.Sum(Function(x) x.TotaleGiaPagato)

                            Dim TotDaPagare As Decimal = TotFatturato - TotPagato
                            'Dim TotOrdini As Decimal = 0

                            'Using mgrO As New OrdiniDAO
                            '    Dim lO As List(Of Ordine) = mgrO.GetBySQL("Select * from t_ordini where month(datains) = " & mese & " and year(datains) = " & SingoloAnno.Id & " and IdDoc=0 and stato <>" & enStatoOrdine.Rifiutato)
                            '    TotOrdini = lO.Sum(Function(x) x.TotaleFornitura)
                            'End Using

                            Dim percDaIncassare As Integer = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((TotDaPagare) * 100 / TotFatturato, 2)

                            BufferMese &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotFatturato) & "</td>"
                            BufferMese &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotPagato) & "</td>"
                            BufferMese &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotDaPagare) & " (" & percDaIncassare & "%)</td></tr>"
                            If BufferMese.Length Then
                                Buffer &= BufferMese
                            End If
                        End If


                    Next
                End Using
                'Exit For
            End If

        Next
        Buffer &= "</table></font>"
        Return Buffer
    End Function

    Public Shared Function ReportFlussiMensili(Optional Anno As Integer = 0) As String
        Dim Ris As String = FormerConfig.FormerPath.PathTempLocale & "ReportFlussiMensili_" & Now.ToString("yyyyMMdd") & ".htm"

        Dim IdAzienda As Integer = MgrAziende.IdAziende.AziendaSrl
        Dim Buffer As String = String.Empty

        Buffer &= GetReportFlussiMensili(Anno)

        Using w As New StreamWriter(Ris)
            w.Write(Buffer)
        End Using

        Return Ris
    End Function

    Private Shared Function GetReportFlussiMensili(Optional Anno As Integer = 0) As String
        Dim Buffer As String = "<font face=Arial><table cellpadding=5 style='border:1px solid black;'>"
        Buffer &= "<tr style='background-color:lightgray;'><td>MESE</td><td>Totale Ordini (Lordo)</td><td>Incassato</td><td>Da Incassare In Doc.</td><td>Da Incassare Fuori Doc.</td><td>Totale Scoperto</td></tr>"

        Dim AR As New cAnnoRif

        For Each SingoloAnno As cEnum In AR
            Dim LavoraAnno As Boolean = True

            If SingoloAnno.Id = 0 Then LavoraAnno = False

            'If Anno <> 0 Then
            '    If SingoloAnno.Id <> Anno Then LavoraAnno = False
            'End If

            If LavoraAnno Then
                Dim MaxMesi As Integer = 12

                If SingoloAnno.Id = Now.Year Then MaxMesi = Now.Month

                Using mgrO As New OrdiniDAO
                    For mese As Integer = MaxMesi To 1 Step -1
                        Dim BufferMese As String = String.Empty
                        Dim lO As New List(Of Ordine)
                        Dim lONoFilt As List(Of Ordine) = mgrO.GetBySQL("Select * from t_ordini o left join t_contabricavi c on o.iddoc = c.idricavo  and c.statoincasso <>" & enStatoIncasso.Impossibile & " where month(datains) = " & mese & " and year(datains) = " & SingoloAnno.Id & " and stato <>" & enStatoOrdine.Rifiutato)

                        'escludo i preventivi pagati
                        'lONoFilt = lONoFilt.FindAll(Function(x) x.DocumentoFiscale Is Nothing Or (Not x.DocumentoFiscale Is Nothing AndAlso x.DocumentoFiscale.StatoIncasso <> enStatoIncasso.Impossibile))
                        Dim TotOrdiniLordo As Decimal = lONoFilt.Sum(Function(x) x.TotaleFornitura)

                        lO.AddRange(lONoFilt.FindAll(Function(x) x.Preventivo = enSiNo.No))
                        lO.AddRange(lONoFilt.FindAll(Function(x) x.Preventivo = enSiNo.Si And x.Stato <> enStatoOrdine.PagatoInteramente))

                        If lO.Count Then
                            BufferMese = "<tr><td style='border-bottom:1px solid darkgray;'>" & FormerHelper.Calendario.MeseToString(mese) & " " & SingoloAnno.Id & "</td>"

                            Dim TotOrdini As Decimal = lO.Sum(Function(x) x.TotaleFornitura)
                            BufferMese &= "<td style='border-bottom:1px solid darkgray;text-align:right;'><b>" & FormerHelper.Stringhe.FormattaPrezzo(TotOrdini) & "</b>"
                            If TotOrdiniLordo <> TotOrdini Then
                                BufferMese &= " (<font size=-1><i>" & FormerHelper.Stringhe.FormattaPrezzo(TotOrdiniLordo) & "</i></font>)"
                            End If
                            BufferMese &= "</td>"

                            Dim TotOrdiniIncassato As Decimal = lO.FindAll(Function(y) y.Stato = enStatoOrdine.PagatoInteramente).Sum(Function(x) x.TotaleFornitura)
                            BufferMese &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotOrdiniIncassato) & "</td>"
                            Dim TotOrdiniDaIncassareInDoc As Decimal = lO.FindAll(Function(y) y.Stato <> enStatoOrdine.PagatoInteramente And y.IdDoc <> 0).Sum(Function(x) x.TotaleFornitura)
                            BufferMese &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotOrdiniDaIncassareInDoc) & "</td>"
                            Dim TotOrdiniDaIncassareOutDoc As Decimal = lO.FindAll(Function(y) y.Stato <> enStatoOrdine.PagatoInteramente And y.IdDoc = 0).Sum(Function(x) x.TotaleFornitura)
                            BufferMese &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotOrdiniDaIncassareOutDoc) & "</td>"
                            Dim TotScoperto As Decimal = TotOrdiniDaIncassareInDoc + TotOrdiniDaIncassareOutDoc
                            Dim percDaIncassare As Integer = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((TotScoperto) * 100 / TotOrdini, 2)
                            BufferMese &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotScoperto) & " (" & percDaIncassare & "%)</td></tr>"

                        End If
                        Buffer &= BufferMese
                    Next
                    Buffer &= "<tr><td colspan=6>&nbsp;</td></tr>"

                End Using

                'Exit For
            End If

        Next
        Buffer &= "</table></font>"
        Return Buffer
    End Function

    Public Shared Function GetInventarioMagazzinoCSVSPECIAL(Anno As Integer,
                                                     IdAzienda As Integer,
                                                     Optional FormatoHTML As Boolean = False) As String
        Dim buffer As String = String.Empty

        Anno = 2019

        Using mgr As New MagazzinoDAO
            Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Carico),
                                                               New LUNA.LunaSearchParameter("Year(DataMov)", Anno))


            'Dim ListaIdRis As New List(Of Integer)

            'For Each voce In l.FindAll(Function(x) (Not x.Fattura Is Nothing AndAlso x.Fattura.IdAzienda = IdAzienda)) ' Or (Not x.CaricoMagazzino Is Nothing AndAlso x.CaricoMagazzino.IdAzienda = IdAzienda))

            '    If ListaIdRis.FindAll(Function(y) y = voce.IdRis).Count = 0 Then
            '        ListaIdRis.Add(voce.IdRis)
            '    End If

            'Next

            'l = l.FindAll(Function(x) ListaIdRis.FindAll(Function(y) y = x.IdRis).Count)

            ''l = l.FindAll(Function(x) (Not x.Fattura Is Nothing AndAlso x.Fattura.IdAzienda = IdAzienda) Or (Not x.CaricoMagazzino Is Nothing AndAlso x.CaricoMagazzino.IdAzienda = IdAzienda))

            l.Sort(AddressOf FormerListSorter.MovimentiMagazzinoSorter.SortExportCSV) ' ComparerMovMagaz)

            'Dim Buffer As String = String.Empty

            Dim IdVoceOld As Integer = 0
            Dim Riga As String = String.Empty
            Dim TotQta As Single = 0
            Dim TotEuro As Decimal = 0
            Dim IdVoceAttuale As Integer = 0
            If FormatoHTML Then
                buffer &= "<font face=Arial><table border=1><tr><td><b>IDRIS</b></td><td><b>RISORSA</b></td><td><b>TOTEURO</b></td><td><b>TOTQTA</b></td><td><b>GIACENZA ATTUALE</b></td><td><b>CARICHI 2020</b></td><td><b>SCARICHI 2020</b></td></tr>"
            Else
                buffer &= "IDRIS;RISORSA;TOTEURO;TOTQTA;GIACENZAATTUALE;CARICHI2020;SCARICHI2020;" & ControlChars.NewLine
            End If

            For Each Voce In l
                IdVoceAttuale = Voce.IdRis
                If IdVoceOld <> IdVoceAttuale Then

                    'scrivo la riga precedente
                    If Riga.Length Then
                        'calcolo la giacenza

                        '******************************
                        'DA RIATTIVARE
                        '******************************
                        'Dim SaldoAnnuale As Single = 0

                        'Dim lScar As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Scarico),
                        '                                       New LUNA.LunaSearchParameter("Year(DataMov)", Anno),
                        '                                       New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceAttuale))

                        'Dim TotScarichi As Integer = lScar.Sum(Function(x) x.Qta)

                        'SaldoAnnuale = TotQta - TotScarichi
                        'If IdVoceAttuale = 464 Then Stop
                        Dim GiacenzaAttuale As Single = 0
                        Dim lG3112 As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Scarico),
                                                                   New LUNA.LunaSearchParameter("Year(DataMov)", 2020),
                                                                   New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceOld))

                        Dim TotScarichi2020 As Integer = lG3112.Sum(Function(x) x.Qta)

                        lG3112 = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Carico),
                                                                New LUNA.LunaSearchParameter("Year(DataMov)", 2020),
                                                                New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceOld))

                        Dim TotCarichi2020 As Integer = lG3112.Sum(Function(x) x.Qta)

                        Using r As New Risorsa
                            r.Read(IdVoceOld)
                            GiacenzaAttuale = r.Giacenza ' (r.Giacenza - TotCarichi2020) + TotScarichi2020
                        End Using

                        If FormatoHTML Then
                            Riga &= "<td align=right>" & FormerHelper.Stringhe.FormattaPrezzo(TotEuro) & "</td><td align=right>" & TotQta & "</td><td align=right>" & GiacenzaAttuale & "</td><td align=right>" & TotCarichi2020 & "</td><td align=right>" & TotScarichi2020 & "</td></tr>"
                        Else
                            Riga &= FormerHelper.Stringhe.FormattaPrezzo(TotEuro) & ";" & TotQta & ";" & GiacenzaAttuale & ";" & TotCarichi2020 & ";" & TotScarichi2020 & ";" & ControlChars.NewLine
                        End If

                        buffer &= Riga
                    End If
                    IdVoceOld = IdVoceAttuale

                    TotEuro = 0
                    TotQta = 0


                    TotEuro = Voce.Prezzo
                    TotQta = Voce.Qta

                    'GiacenzaAttuale = Voce.Risorsa.Giacenza
                    If FormatoHTML Then
                        Riga = "<tr><td>" & Voce.IdRis & "</td><td>" & Voce.RisorsaStr & "</td>"
                    Else
                        Riga = Voce.IdRis & ";" & Voce.RisorsaStr & ";"
                    End If

                Else
                    TotEuro += Voce.Prezzo
                    TotQta += Voce.Qta
                End If
            Next

            If IdVoceOld = IdVoceAttuale Then
                'chiudo l'ultima 
                If Riga.Length Then


                    Dim lG3112 As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Scarico),
                                    New LUNA.LunaSearchParameter("Year(DataMov)", 2020),
                                    New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceAttuale))

                    Dim TotScarichi2020 As Integer = lG3112.Sum(Function(x) x.Qta)

                    lG3112 = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Carico),
                                    New LUNA.LunaSearchParameter("Year(DataMov)", 2020),
                                    New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceAttuale))

                    Dim TotCarichi2020 As Integer = lG3112.Sum(Function(x) x.Qta)
                    Dim GiacenzaAttuale As Single = 0
                    Using r As New Risorsa
                        r.Read(IdVoceAttuale)
                        GiacenzaAttuale = r.Giacenza
                    End Using

                    If FormatoHTML Then
                        Riga &= "<td align=right>" & FormerHelper.Stringhe.FormattaPrezzo(TotEuro) & "</td><td align=right>" & TotQta & "</td><td align=right>" & GiacenzaAttuale & "</td><td align=right>" & TotCarichi2020 & "</td><td align=right>" & TotScarichi2020 & "</td></tr>"
                    Else
                        Riga &= FormerHelper.Stringhe.FormattaPrezzo(TotEuro) & ";" & TotQta & ";" & GiacenzaAttuale & ";" & TotCarichi2020 & ";" & TotScarichi2020 & ";" & ControlChars.NewLine
                    End If

                    buffer &= Riga
                End If
            End If

            If FormatoHTML Then
                buffer &= "</table></font>"
            End If

        End Using
        Return buffer
    End Function

    Public Shared Function GetInventarioMagazzinoCSV(Anno As Integer,
                                                     IdAzienda As Integer,
                                                     Optional FormatoHTML As Boolean = False) As String
        Dim buffer As String = String.Empty

        Using mgr As New MagazzinoDAO
            Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Carico),
                                                               New LUNA.LunaSearchParameter("Year(DataMov)", Anno))


            Dim ListaIdRis As New List(Of Integer)

            For Each voce In l.FindAll(Function(x) (Not x.Fattura Is Nothing AndAlso x.Fattura.IdAzienda = IdAzienda)) ' Or (Not x.CaricoMagazzino Is Nothing AndAlso x.CaricoMagazzino.IdAzienda = IdAzienda))

                If ListaIdRis.FindAll(Function(y) y = voce.IdRis).Count = 0 Then
                    ListaIdRis.Add(voce.IdRis)
                End If

            Next

            l = l.FindAll(Function(x) ListaIdRis.FindAll(Function(y) y = x.IdRis).Count)

            'l = l.FindAll(Function(x) (Not x.Fattura Is Nothing AndAlso x.Fattura.IdAzienda = IdAzienda) Or (Not x.CaricoMagazzino Is Nothing AndAlso x.CaricoMagazzino.IdAzienda = IdAzienda))

            l.Sort(AddressOf FormerListSorter.MovimentiMagazzinoSorter.SortExportCSV) ' ComparerMovMagaz)

            'Dim Buffer As String = String.Empty

            Dim IdVoceOld As Integer = 0
            Dim Riga As String = String.Empty
            Dim TotQtaSRL As Single = 0
            Dim TotEuroSRL As Decimal = 0
            Dim TotQtaSNC As Single = 0
            Dim TotEuroSNC As Decimal = 0
            Dim Giacenza3112 As Single = 0
            Dim IdVoceAttuale As Integer = 0
            If FormatoHTML Then
                buffer &= "<font face=Arial><table border=1><tr><td><b>IDRIS</b></td><td><b>RISORSA</b></td><td><b>TOTEURO SNC</b></td><td><b>TOTQTA SNC</b></td><td><b>TOTEURO SRL</b></td><td><b>TOTQTA SRL</b></td><td><b>GIACENZA 31/12</b></td></tr>"
            Else
                buffer &= "IDRIS;RISORSA;TOTEUROSNC;TOTQTASNC;TOTEUROSRL;TOTQTASRL;GIACENZA3112;" & ControlChars.NewLine
            End If

            For Each Voce In l
                IdVoceAttuale = Voce.IdRis
                If IdVoceOld <> IdVoceAttuale Then

                    'scrivo la riga precedente
                    If Riga.Length Then
                        'calcolo la giacenza

                        '******************************
                        'DA RIATTIVARE
                        '******************************
                        'Dim SaldoAnnuale As Single = 0

                        'Dim lScar As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Scarico),
                        '                                       New LUNA.LunaSearchParameter("Year(DataMov)", Anno),
                        '                                       New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceAttuale))

                        'Dim TotScarichi As Integer = lScar.Sum(Function(x) x.Qta)

                        'SaldoAnnuale = TotQta - TotScarichi
                        'If IdVoceAttuale = 464 Then Stop

                        If Anno = 2019 Then
                            Dim lG3112 As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Scarico),
                                                                   New LUNA.LunaSearchParameter("Year(DataMov)", 2020),
                                                                   New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceOld))

                            Dim TotScarichi2020 As Integer = lG3112.Sum(Function(x) x.Qta)

                            lG3112 = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Carico),
                                                                   New LUNA.LunaSearchParameter("Year(DataMov)", 2020),
                                                                   New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceOld))

                            Dim TotCarichi2020 As Integer = lG3112.Sum(Function(x) x.Qta)

                            Using r As New Risorsa
                                r.Read(IdVoceOld)
                                Giacenza3112 = (r.Giacenza - TotCarichi2020) + TotScarichi2020
                            End Using
                        End If

                        If FormatoHTML Then
                            Riga &= "<td align=right>" & FormerHelper.Stringhe.FormattaPrezzo(TotEuroSNC) & "</td><td align=right>" & TotQtaSNC & "</td><td align=right>" & FormerHelper.Stringhe.FormattaPrezzo(TotEuroSRL) & "</td><td align=right>" & TotQtaSRL & "</td><td align=right>" & Giacenza3112 & "</td></tr>"
                        Else
                            Riga &= FormerHelper.Stringhe.FormattaPrezzo(TotEuroSNC) & ";" & TotQtaSNC & ";" & FormerHelper.Stringhe.FormattaPrezzo(TotEuroSRL) & ";" & TotQtaSRL & ";" & Giacenza3112 & ";" & ControlChars.NewLine
                        End If

                        buffer &= Riga
                    End If
                    IdVoceOld = IdVoceAttuale

                    TotEuroSNC = 0
                    TotEuroSRL = 0
                    TotQtaSNC = 0
                    TotQtaSRL = 0

                    If (Not Voce.Fattura Is Nothing AndAlso Voce.Fattura.IdAzienda = MgrAziende.IdAziende.AziendaSnc) Then ' Or
                        '(Not Voce.CaricoMagazzino Is Nothing AndAlso Voce.CaricoMagazzino.IdAzienda = MgrAziende.IdAziende.AziendaSnc) Then
                        TotEuroSNC = Voce.Prezzo
                        TotQtaSNC = Voce.Qta
                    End If
                    If (Not Voce.Fattura Is Nothing AndAlso Voce.Fattura.IdAzienda = MgrAziende.IdAziende.AziendaSrl) Then ' Or
                        '(Not Voce.CaricoMagazzino Is Nothing AndAlso Voce.CaricoMagazzino.IdAzienda = MgrAziende.IdAziende.AziendaSrl) Then
                        TotEuroSRL = Voce.Prezzo
                        TotQtaSRL = Voce.Qta
                    End If
                    'GiacenzaAttuale = Voce.Risorsa.Giacenza
                    If FormatoHTML Then
                        Riga = "<tr><td>" & Voce.IdRis & "</td><td>" & Voce.RisorsaStr & "</td>"
                    Else
                        Riga = Voce.IdRis & ";" & Voce.RisorsaStr & ";"
                    End If

                Else
                    If (Not Voce.Fattura Is Nothing AndAlso Voce.Fattura.IdAzienda = MgrAziende.IdAziende.AziendaSnc) Then ' Or
                        '(Not Voce.CaricoMagazzino Is Nothing AndAlso Voce.CaricoMagazzino.IdAzienda = MgrAziende.IdAziende.AziendaSnc) Then
                        TotEuroSNC += Voce.Prezzo
                        TotQtaSNC += Voce.Qta
                    End If
                    If (Not Voce.Fattura Is Nothing AndAlso Voce.Fattura.IdAzienda = MgrAziende.IdAziende.AziendaSrl) Then 'Or
                        '(Not Voce.CaricoMagazzino Is Nothing AndAlso Voce.CaricoMagazzino.IdAzienda = MgrAziende.IdAziende.AziendaSrl) Then
                        TotEuroSRL += Voce.Prezzo
                        TotQtaSRL += Voce.Qta
                    End If
                End If
            Next

            If IdVoceOld = IdVoceAttuale Then
                'chiudo l'ultima 
                If Riga.Length Then

                    If Anno = 2019 Then
                        Dim lG3112 As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Scarico),
                                                                   New LUNA.LunaSearchParameter("Year(DataMov)", 2020),
                                                                   New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceAttuale))

                        Dim TotScarichi2020 As Integer = lG3112.Sum(Function(x) x.Qta)

                        lG3112 = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Carico),
                                                                   New LUNA.LunaSearchParameter("Year(DataMov)", 2020),
                                                                   New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdVoceAttuale))

                        Dim TotCarichi2020 As Integer = lG3112.Sum(Function(x) x.Qta)
                        Using r As New Risorsa
                            r.Read(IdVoceAttuale)
                            Giacenza3112 = (r.Giacenza - TotCarichi2020) + TotScarichi2020
                        End Using

                    End If

                    If FormatoHTML Then
                        Riga &= "<td align=right>" & FormerHelper.Stringhe.FormattaPrezzo(TotEuroSNC) & "</td><td align=right>" & TotQtaSNC & "</td><td align=right>" & FormerHelper.Stringhe.FormattaPrezzo(TotEuroSRL) & "</td><td align=right>" & TotQtaSRL & "</td><td align=right>" & Giacenza3112 & "</td></tr>"
                    Else
                        Riga &= FormerHelper.Stringhe.FormattaPrezzo(TotEuroSNC) & "€;" & TotQtaSNC & ";" & FormerHelper.Stringhe.FormattaPrezzo(TotEuroSRL) & "€;" & TotQtaSRL & ";" & Giacenza3112 & ";" & ControlChars.NewLine
                    End If
                    buffer &= Riga
                End If
            End If

            If FormatoHTML Then
                buffer &= "</table></font>"
            End If

        End Using
        Return buffer
    End Function

    Public Shared Function GetBilancioAziendaleAnnuale(Anno As Integer,
                                       IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        Dim TotaleCosti As Decimal = 0
        Dim TotaleCostiLordi As Decimal = 0
        Dim TotaleVociAmmortamento As Decimal = 0
        Dim TotaleDipendenti As Decimal = 0
        Dim TotaleRicavi As Decimal = 0
        Dim RisultatoEsercizio As Decimal = 0
        Dim TotIvaCredito As Decimal = 0
        Dim TotIvaDebito As Decimal = 0

        ris = "<font face=""Arial""><h1>" & MgrAziende.GetAziendaStr(IdAzienda) & "</h1>"

        ris &= "<h2>Bilancio Previsionale</h2>"

        ris &= "<table border=1 width=80%>"
        ris &= "<tr><td></td><td style='background-color:red;color:white'><h2>COSTI</h2></b></td><td style='background-color:green;color:white'><h2>RICAVI</h2></td></tr>"

        Using mgr As New CostiDAO

            Dim l As List(Of Costo) = mgr.FindAll(New LUNA.LSP(LFM.Costo.IdAzienda, IdAzienda),
                                                  New LUNA.LSP("Year(DataCosto)", Anno))
            For Each voce As Costo In l
                TotaleCostiLordi += voce.ImportoMatematico
                If voce.Ammortamento Is Nothing Then
                    TotaleCosti += voce.ImportoMatematico
                    TotIvaCredito += voce.IvaMatematico
                End If
            Next
            ris &= "<tr><td><h3>Documenti fiscali RICEVUTI</h3></td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotaleCostiLordi) & "</b></td><td>&nbsp;</td></tr>"
            ris &= "<tr><td><h3>Documenti fiscali NON in ammortamento</h3></td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotaleCosti) & "</b></td><td>&nbsp;</td></tr>"
        End Using
        Using mgrC As New AmmortamentoCostiDAO

            Dim lC As List(Of AmmortamentoCosto) = mgrC.FindAll(New LUNA.LSP(LFM.AmmortamentoCosto.AnnoStart, Anno, "<="),
                        New LUNA.LSP(LFM.AmmortamentoCosto.AnnoEnd, Anno, ">="),
                        New LUNA.LSP(LFM.AmmortamentoCosto.IdAzienda, IdAzienda))
            For Each voce As AmmortamentoCosto In lC
                Dim ImportoAnnuo As Decimal = 0
                If voce.AnnoStart = Anno Then
                    ImportoAnnuo = (voce.ImportoTotale / voce.Anni) / 2
                    TotIvaCredito += voce.Costo.IvaMatematico
                Else
                    ImportoAnnuo = (voce.ImportoTotale - ((voce.ImportoTotale / voce.Anni) / 2)) / (voce.Anni - 1)
                End If
                TotaleVociAmmortamento += ImportoAnnuo 'voce.ImportoAnnuo

            Next
        End Using

        ris &= "<tr><td><h3>Ammortamenti Attivi</h3></td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotaleVociAmmortamento) & "</b></td><td>&nbsp;</td></tr>"

        Using mgrU As New UtentiDAO
            Dim lU As List(Of Utente) = mgrU.FindAll(New LUNA.LunaSearchParameter(LFM.Utente.RedditoLordoMese, 0, "<>"),
                                                     New LUNA.LSP(LFM.Utente.idAzienda, IdAzienda))

            For Each voce In lU
                Dim Moltiplicatore As Integer = 12
                If Anno = Now.Year Then
                    Moltiplicatore = Now.Month
                End If

                Dim RedditoMensile As Decimal = (voce.RedditoLordoMese * voce.NumeroMensilita / 12) * Moltiplicatore
                TotaleDipendenti += RedditoMensile
            Next

        End Using

        ris &= "<tr><td><h3>Costi per dipendenti</h3></td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotaleDipendenti) & "</b></td><td>&nbsp;</td></tr>"


        Using mgr As New RicaviDAO

            Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LSP(LFM.Ricavo.IdAzienda, IdAzienda),
                                                   New LUNA.LSP("Year(dataricavo)", Anno),
                                                   New LUNA.LSP(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.NotaDiCredito & ")", "IN"))
            For Each voce As Ricavo In l '.FindAll(Function(x) x.Ammortamento Is Nothing)
                TotaleRicavi += voce.ImportoMatematico
                TotIvaDebito += voce.IvaMatematico
            Next

            ris &= "<tr><td><h3>Documenti fiscali EMESSI</h3></td><td>&nbsp;</td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotaleRicavi) & "</b></td></tr>"
        End Using

        Dim TotalePassivita As Decimal = TotaleCosti + TotaleVociAmmortamento + TotaleDipendenti

        ris &= "<tr><td><h3>TOTALE</h3></td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotalePassivita) & "</b></td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotaleRicavi) & "</b></td></tr>"

        RisultatoEsercizio = TotaleRicavi - TotalePassivita

        ris &= "<tr><td><h3>RISULTATO</h3></td><td colspan=2 align=center><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(RisultatoEsercizio) & "</b></td></tr>"

        ris &= "</table>"

        ris &= "<h2>IVA</h2>"

        ris &= "<table border=1 width=80%>"
        ris &= "<tr><td style='background-color:red;color:white'><h3>Iva a Debito</h3></td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotIvaDebito) & "</b></td></tr>"
        ris &= "<tr><td style='background-color:green;color:white'><h3>Iva a Credito</h3></td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotIvaCredito) & "</b></td></tr>"
        ris &= "<tr><td><h3>Differenza</h3></td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo((TotIvaCredito - TotIvaDebito)) & "</b></td></tr>"
        ris &= "</table></font>"

        Return ris
    End Function
    Public Shared Function ReportFatture(Anno As Integer,
                                        IdAzienda As Integer) As String

        'Dim Ris As String = FormerConfig.FormerPath.PathTempLocale & "ReportFatture_" & Now.ToString("yyyyMMdd") & ".htm"

        'Dim IdAzienda As Integer = MgrAziende.IdAziende.AziendaSrl
        Dim Buffer As String = String.Empty

        Buffer &= GetReportConteggiMensiliSingolaAzienda(Anno, IdAzienda)

        Buffer &= "<p style=""page-break-after: always;"">&nbsp;</p>"

        'IdAzienda = MgrAziende.IdAziende.AziendaSnc

        'Buffer &= GetReportConteggiMensiliSingolaAzienda(IdAzienda)

        'Using w As New StreamWriter(Ris)
        '    w.Write(Buffer)
        'End Using

        Return Buffer

    End Function

    Private Shared Function GetReportConteggiMensiliSingolaAzienda(Anno As Integer,
                                                                   IdAzienda As Integer) As String

        Dim Buffer As String = String.Empty

        Buffer = "<font face=""Arial""><h1>" & MgrAziende.GetAziendaStr(IdAzienda) & "</h1>"
        Buffer &= "<table cellpadding=5 style='border:1px solid black;'>"
        Buffer &= "<tr style='background-color:lightgray;'><td>MESE</td><td>Doc. Emessi</td><td>Tot. Netto</td><td>Iva Debito</td><td>Tot. Lordo</td><td>Doc. Ricevuti</td><td>Tot. Netto</td><td>Iva Credito</td><td>Tot. Lordo</td><td>Saldo IVA</td></tr>"

        Dim MeseMax As Integer = 12
        If Anno = Now.Year Then
            MeseMax = Now.Month
        End If

        Dim TrimestreCorrente As Integer = 1
        Dim TrimEmessiTotNetto As Decimal = 0
        Dim TrimEmessiTotLordo As Decimal = 0
        Dim TrimEmessiTotIva As Decimal = 0
        Dim TrimRicevutiTotNetto As Decimal = 0
        Dim TrimRicevutiTotLordo As Decimal = 0
        Dim TrimRicevutiTotIva As Decimal = 0
        Dim AnnoEmessiTotNetto As Decimal = 0
        Dim AnnoEmessiTotLordo As Decimal = 0
        Dim AnnoEmessiTotIva As Decimal = 0
        Dim AnnoRicevutiTotNetto As Decimal = 0
        Dim AnnoRicevutiTotLordo As Decimal = 0
        Dim AnnoRicevutiTotIva As Decimal = 0


        For i As Integer = 1 To MeseMax
            Buffer &= "<tr><td>" & FormerLib.FormerHelper.Calendario.MeseToString(i) & "</td>"
            Using mgr As New RicaviDAO
                Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.IdAzienda, IdAzienda),
                                                       New LUNA.LunaSearchParameter("Month(DataRicavo)", i),
                                                       New LUNA.LunaSearchParameter("Year(DataRicavo)", Anno),
                                                       New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.NotaDiCredito & ")", "IN"))

                Dim TotNetto As Decimal = l.Sum(Function(y) y.ImportoMatematico)
                Dim TotIva As Decimal = l.Sum(Function(y) y.IvaMatematico)

                TrimEmessiTotIva += TotIva
                TrimEmessiTotNetto += TotNetto

                Dim TotLordo As Decimal = l.Sum(Function(y) y.TotaleMatematico)

                TrimEmessiTotLordo += TotLordo
                'Buffer &= "Emessi <b>" & l.Count & "</b> documenti per un totale netto di &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotNetto) & "</b> (lordo &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotLordo) & "</b>)"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & l.Count & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotNetto) & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotIva) & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotLordo) & "</td>"

            End Using

            Using mgr As New CostiDAO
                Dim l As List(Of Costo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Costo.IdAzienda, IdAzienda),
                                                       New LUNA.LunaSearchParameter("Month(datacosto)", i),
                                                       New LUNA.LunaSearchParameter("Year(datacosto)", Anno),
                                                       New LUNA.LunaSearchParameter(LFM.Costo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.AccontoAnticipoSuFattura & "," & enTipoDocumento.NotaDiCredito & ")", "IN"))

                Dim TotNetto As Decimal = l.Sum(Function(x) x.ImportoMatematico)
                TrimRicevutiTotNetto += TotNetto
                Dim TotLordo As Decimal = l.Sum(Function(x) x.TotaleMatematico)
                TrimRicevutiTotLordo += TotLordo
                Dim TotIva As Decimal = l.Sum(Function(y) y.IvaMatematico)
                TrimRicevutiTotIva += TotIva
                'Buffer &= "<br><br>Ricevuti <b>" & l.Count & "</b> documenti per un totale netto di &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotNetto) & "</b> (lordo &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotLordo) & "</b>)"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & l.Count & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotNetto) & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotIva) & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TotLordo) & "</td>"

            End Using
            Buffer &= "<td></td>"
            Buffer &= "</tr>"

            If i Mod 3 = 0 OrElse i = MeseMax Then
                'chiusura trimestre
                Buffer &= "<tr>"
                Buffer &= "<td><b>" & TrimestreCorrente & " trimestre</b></td>"

                'Dim TotIvaCredito As Decimal = TrimRicevutiTotLordo - TrimRicevutiTotNetto
                'Dim TotIvaDebito As Decimal = TrimEmessiTotLordo - TrimEmessiTotNetto
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'></td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TrimEmessiTotNetto) & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TrimEmessiTotIva) & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TrimEmessiTotLordo) & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'></td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TrimRicevutiTotNetto) & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TrimRicevutiTotIva) & "</td>"
                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TrimRicevutiTotLordo) & "</td>"

                Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(TrimRicevutiTotIva - TrimEmessiTotIva) & "</td>"

                Buffer &= "</tr>"
                AnnoRicevutiTotNetto += TrimRicevutiTotNetto
                AnnoRicevutiTotLordo += TrimRicevutiTotLordo
                AnnoEmessiTotNetto += TrimEmessiTotNetto
                AnnoEmessiTotLordo += TrimEmessiTotLordo
                AnnoEmessiTotIva += TrimEmessiTotIva
                AnnoRicevutiTotIva += TrimRicevutiTotIva

                TrimestreCorrente += 1
                TrimRicevutiTotNetto = 0
                TrimRicevutiTotLordo = 0
                TrimEmessiTotNetto = 0
                TrimEmessiTotLordo = 0
                TrimEmessiTotIva = 0
                TrimRicevutiTotIva = 0
            End If

        Next

        Buffer &= "<tr>"
        Buffer &= "<td><b>Totale</b></td>"

        'Dim TotIvaCredito As Decimal = TrimRicevutiTotLordo - TrimRicevutiTotNetto
        'Dim TotIvaDebito As Decimal = TrimEmessiTotLordo - TrimEmessiTotNetto
        Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'></td>"
        Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(AnnoEmessiTotNetto) & "</td>"
        Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(AnnoEmessiTotIva) & "</td>"
        Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(AnnoEmessiTotLordo) & "</td>"
        Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'></td>"
        Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(AnnoRicevutiTotNetto) & "</td>"
        Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(AnnoRicevutiTotIva) & "</td>"
        Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(AnnoRicevutiTotLordo) & "</td>"

        Buffer &= "<td style='border-bottom:1px solid darkgray;text-align:right;'>" & FormerHelper.Stringhe.FormattaPrezzo(AnnoRicevutiTotIva - AnnoEmessiTotIva) & "</td>"

        Buffer &= "</tr>"
        Buffer &= "</table>"

        Return Buffer

    End Function

    Public Shared Function GetMesiDisponibili() As List(Of MeseDisponibile)
        Dim ris As New List(Of MeseDisponibile)
        Dim sql As String = "select Distinct concat(year(Datains) ,'/' , RIGHT('0'+ CONVERT(VARCHAR, month(datains)), 2)) from t_ordini where year(datains) > 2013 order by concat(year(Datains) ,'/' , RIGHT('0'+ CONVERT(VARCHAR, month(datains)), 2)) desc"
        Using myReader As IDataReader = GetData(sql)
            While myReader.Read
                Dim Val As String = myReader(0)

                Dim mese As New MeseDisponibile
                mese.AnnoRif = Val.Substring(0, Val.IndexOf("/"))
                mese.MeseRif = Val.Substring(Val.IndexOf("/") + 1)
                ris.Add(mese)

            End While
            myReader.Close()
        End Using

        Return ris
    End Function

    Public Shared Function GetTotaleMensile() As List(Of MeseDisponibile)
        Dim ris As New List(Of MeseDisponibile)
        Dim sql As String = "select year(datains) as Anno,month(datains) as Mese,sum (totaleforn + ricarico - sconto) as TotaleMensile,Count(*) as NumeroOrdini "
        sql &= " from (Select DataIns,TotaleForn,Ricarico,sconto from t_ordini where (year(datains) > 2013 and stato not in (90,91,21)) union all select DataIns,TotaleForn,Ricarico,sconto from archivi  where (year(datains) > 2013)) a "
        'sql &= "where year(datains) > 2013 and stato not in (90,91,21) "
        sql &= "group by year(datains) , month(datains)"
        sql &= "order by year(datains) desc, month(datains) desc"

        Using myReader As IDataReader = GetData(sql)
            While myReader.Read
                Dim mese As New MeseDisponibile
                mese.AnnoRif = myReader(0)
                mese.MeseRif = myReader(1)
                mese.Fatturato = myReader(2)
                mese.NumeroOrdini = myReader(3)

                Dim Sql2 As String = "select Count(*) from t_rubrica where sorgente ='W' and month(datains) = " & mese.MeseRif & " and year(datains) = " & mese.AnnoRif
                Using myreaderNewReg As IDataReader = GetData(Sql2)
                    If myreaderNewReg.Read() Then
                        mese.NumeroRegistrazioniDalSito = myreaderNewReg(0)
                    End If
                End Using

                ris.Add(mese)

            End While
            myReader.Close()
        End Using

        Return ris
    End Function

    Private Shared Function GetData(Sql As String) As IDataReader
        Dim ris As IDataReader = Nothing

        Using myCommand As IDbCommand = LUNA.LunaContext.Connection.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            ris = myCommand.ExecuteReader()
        End Using
        Return ris
    End Function

End Class

Public Class MeseDisponibile

    Public ReadOnly Property Riassunto As String
        Get
            Return AnnoRif & " " & FormerLib.FormerHelper.Calendario.MeseToString(MeseRif)
        End Get
    End Property
    Public ReadOnly Property Chiave As String
        Get
            Return MeseRif & "." & AnnoRif
        End Get
    End Property
    Public Property MeseRif As Integer = 0
    Public Property AnnoRif As Integer = 0

    Public Property Fatturato As Decimal = 0
    Public Property NumeroOrdini As Integer = 0
    Public Property NumeroRegistrazioniDalSito As Integer = 0

End Class

Public Class RisultatoPreventivazione
    Public Property IdPrev As Integer = 0
    Public Property IdRep As Integer = 0
    Public Property Descrizione As String = String.Empty
    Public Property Fatturato As Decimal = 0
    Public Property NumOrd As Integer = 0
End Class

Public Class RisultatoReparto
    Public Property IdRep As Integer = 0
    Public Property Descrizione As String = String.Empty
    Public Property Fatturato As Decimal = 0
    Public Property NumOrd As Integer = 0
End Class