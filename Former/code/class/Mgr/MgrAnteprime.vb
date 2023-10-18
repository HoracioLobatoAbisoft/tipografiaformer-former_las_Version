Imports System.IO
Imports FormerConfig
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrAnteprime

    Private Const HeaderOperatore As String = "<style>.divOperatore{display: inline;width: 500px;height:expression(this.scrollHeight < 200 ? ""200px"" : ""auto"");vertical-align:top;float:left;}</style>"

    Friend Shared Sub CreaFatturaElettronica(ByVal bufferXml As String,
                                       ByRef webRiepilogo As WebBrowser,
                                       Optional XslConPath As Boolean = True)

        webRiepilogo.Navigate("about:blank")
        Cursor.Current = Cursors.WaitCursor
        Dim RigaXSL As String = ""

        'RigaXSL = ControlChars.NewLine & "<?xml-stylesheet type=""text/xsl"" href=""" & Environment.CurrentDirectory.Replace("\", "/") & "/fatturaordinaria_v1.2.xsl""?>"



        If XslConPath Then
            RigaXSL = "<?xml-stylesheet type=""text/xsl"" href=""" & FormerConst.Ambiente.PathFoglioStileFatturaElettronica & FormerConst.Ambiente.NomeFoglioStileFatturaElettronica & """?>"
        Else
            RigaXSL = "<?xml-stylesheet type=""text/xsl"" href=""" & FormerConst.Ambiente.NomeFoglioStileFatturaElettronica & """?>"
        End If
        Dim posiz As Integer = 0 ' bufferXml.IndexOf(">")
        Dim bufferXmlFinale As String = String.Empty

        posiz = bufferXml.IndexOf("<?xml-stylesheet")

        If posiz <> -1 Then
            Dim PosizFine As Integer = 0
            PosizFine = bufferXml.IndexOf(">", posiz)

            If posiz <> 0 Then bufferXmlFinale = bufferXml.Substring(0, posiz)
            bufferXmlFinale &= RigaXSL
            bufferXmlFinale &= bufferXml.Substring(PosizFine + 1)
        Else
            posiz = bufferXml.IndexOf("<?xml")
            If posiz <> -1 Then
                posiz = bufferXml.IndexOf(">")
                bufferXmlFinale = bufferXml.Substring(0, posiz + 1)
                bufferXmlFinale &= RigaXSL
                bufferXmlFinale &= bufferXml.Substring(posiz + 1)
            Else
                bufferXmlFinale = RigaXSL & ControlChars.NewLine & bufferXml
            End If

        End If

        'If bufferXml.IndexOf("fatturaordinaria_v1.2.xsl") = -1 Then
        '    bufferXmlFinale = bufferXml.Substring(0, posiz + 1) & RigaXSL & bufferXml.Substring(posiz + 1)
        'Else
        '    'qui devo sostituire il path 
        '    bufferXmlFinale = bufferXml.Replace("fatturaordinaria_v1.2.xsl", "z:/fatture/fe/fatturaordinaria_v1.2.xsl")
        'End If

        Dim NomeFileFatt As String = FormerPath.PathTempLocale & "tempfattura.xml"
        Using w As New StreamWriter(NomeFileFatt)
            w.Write(bufferXmlFinale)
        End Using
        webRiepilogo.Navigate(NomeFileFatt)
        'webRiepilogo.Document.OpenNew(False)
        'webRiepilogo.Document.Write(bufferXmlFinale)
        'webRiepilogo.Refresh()

        Cursor.Current = Cursors.Default

    End Sub

    Friend Shared Sub CreaRiepilogoOrd(ByVal _ordSel As Ordine,
                                       ByRef webRiepilogo As WebBrowser,
                                       ByVal TipoAnte As enTipoAnteprima)

        webRiepilogo.Navigate("about:blank")

        If Not _ordSel Is Nothing Then

            If _ordSel.IdOrd Then
                'qui creo il riepilogo e lo carico

                Try

                    Cursor.Current = Cursors.WaitCursor

                    Dim bufferhtml As String = String.Empty

                    Select Case TipoAnte
                        Case enTipoAnteprima.Generale, enTipoAnteprima.Breve
                            '    bufferhtml = _ordSel.CreaRiepilogo

                            'Case enTipoAnteprima.Breve
                            bufferhtml = _ordSel.CreaRiepilogo
                            bufferhtml &= _ordSel.CreaRiepilogoStatoLavori
                            bufferhtml &= _ordSel.CreaRiepilogoCommessa
                        Case enTipoAnteprima.Operatore

                            bufferhtml = HeaderOperatore
                            bufferhtml &= _ordSel.CreaRiepilogo(True)
                            bufferhtml &= _ordSel.CreaRiepilogoStatoLavori

                        Case enTipoAnteprima.Lavorazioni
                            bufferhtml = _ordSel.CreaRiepilogoStatoLavori

                        Case enTipoAnteprima.Imballo
                            bufferhtml = _ordSel.CreaRiepilogoImballo

                    End Select

                    Dim T As New My.Templates.ContenitoreAnteprima

                    bufferhtml = T.TransformText.Replace(FormerConst.Anteprime.TagContenuto, bufferhtml)

                    'ciclo per le varie zone presenti nell'agenzia e creo una riga per ogni zona 
                    'carico le offerte di quella zona

                    'qui lancio il modulo esterno per visualizzarlo
                    'Dim PathMOd As String = FormerPath.PathLocale & "riepOrd.htm"

                    'Dim Sr As StreamWriter, PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")
                    'Sr = New System.IO.StreamWriter(PathFileStampa, False)

                    'Sr.Write(bufferhtml)

                    'Sr.Close()
                    ''sr = Nothing

                    'webRiepilogo.Navigate(PathFileStampa)


                    webRiepilogo.Document.OpenNew(False)
                    webRiepilogo.Document.Write(bufferhtml)
                    webRiepilogo.Refresh()

                    Cursor.Current = Cursors.Default

                Catch ex As Exception
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try

            End If

        End If

    End Sub

    Friend Shared Sub CreaRiepilogoMagazzino(DataInizio As Date,
                                             DataFine As Date,
                                             IdTipoCarta As Integer,
                                             IdGruppo As Integer,
                                             ByRef webRiepilogo As WebBrowser)

        Cursor.Current = Cursors.WaitCursor

        webRiepilogo.Navigate("about:blank")

        Dim bufferhtml As String = ""

        bufferhtml &= "<br>"
        bufferhtml &= "<h2>Resoconto Magazzino: " & DataInizio.ToString("dd/MM/yyyy") & " - " & DataFine.ToString("dd/MM/yyyy") & "</h2>"

        Using Mgr As New MagazzinoDAO

            Dim p As LUNA.LunaSearchParameter = Nothing

            Dim l As List(Of MovimentoMagazzino) = Mgr.GetAll(LFM.MovimentoMagazzino.DataMov.Name & " DESC")

            l = l.FindAll(Function(x) x.DataMov.Date >= DataInizio.Date And x.DataMov.Date <= DataFine.Date)

            'Select Case PeriodoRiferimento
            '    Case enPeriodoRiferimento.UnGiorno  ' trimestre
            '        l = l.FindAll(Function(x) x.DataMov.Date = Now.Date)
            '    Case enPeriodoRiferimento.Ieri  ' trimestre
            '        l = l.FindAll(Function(x) x.DataMov.Date = Now.Date.AddDays(-1))
            '    Case enPeriodoRiferimento.UnaSettimana  ' semestre
            '        l = l.FindAll(Function(x) x.DataMov.Date >= Now.Date.AddDays(-7))
            '    Case enPeriodoRiferimento.UnMese
            '        l = l.FindAll(Function(x) x.DataMov.Date >= Now.Date.AddMonths(-1))
            '    Case enPeriodoRiferimento.UnAnno
            '        l = l.FindAll(Function(x) x.DataMov.Date >= Now.Date.AddYears(-1))
            'End Select

            If IdGruppo Then
                l = l.FindAll(Function(X) X.Risorsa.Gruppi.FindAll(Function(z) z.IdGruppo = IdGruppo).Count > 0)
            End If

            If IdTipoCarta Then
                l = l.FindAll(Function(X) X.Risorsa.IdTipoCarta = IdTipoCarta)
            End If

            Dim LRis As List(Of RisUtilizzoRisorsa) = MgrMagazzino.GetStatisticheUtilizzo(l)

            LRis = LRis.FindAll(Function(x) x.TotCarico <> 0 OrElse x.TotPrenotazioni <> 0 OrElse x.TotScarico <> 0 OrElse x.GiacenzaAttuale <> 0)

            LRis.Sort(AddressOf FormerListSorter.RisUtilizzoRisorsaSorter.SortPerELenco)

            bufferhtml &= "<center><div><table border=0 cellpadding=5 cellspacing=0 width=60% style='background-color:white;'>"

            Dim ColoreGiorno As String = "#f2f2f2"
            Dim ColoreGiornoAlt As String = "#cacaca"
            Dim ColoreGiornoSel As String = ColoreGiorno

            Dim ColoreTc As String = "#d7ffdb"
            Dim ColoreTcAlt As String = "#fffed7"
            Dim ColoreTcSel As String = ColoreGiorno

            Dim lastDate As Date = Date.MinValue
            Dim lastIdTC As Integer = -1

            For Each mov In LRis
                'If lastDate <> mov.Giorno Then
                '    If lastDate <> Date.MinValue Then
                '        bufferhtml &= "</td></tr>"

                '        If ColoreGiornoSel = ColoreGiorno Then
                '            ColoreGiornoSel = ColoreGiornoAlt
                '        Else
                '            ColoreGiornoSel = ColoreGiorno
                '        End If
                '    End If
                'End If

                bufferhtml &= "<tr>"

                'If lastDate <> mov.Giorno Then
                '    ColoreTcSel = ColoreTc
                '    lastIdTC = 0
                '    bufferhtml &= "<td style='font-size:14px;' valign=top bgcolor=" & ColoreGiornoSel & "><b>" & mov.Giorno.ToString("dd/MM/yyyy") & "</b></td>"
                'Else
                '    bufferhtml &= "<td bgcolor=" & ColoreGiornoSel & ">&nbsp;</td>"
                'End If
                'lastDate = mov.Giorno
                If mov.Risorsa.IsLastra Then
                    ColoreTcSel = "white"
                    lastIdTC = -1
                Else
                    If lastIdTC <> mov.Risorsa.IdTipoCarta Then

                        If ColoreTcSel = ColoreTc Then
                            ColoreTcSel = ColoreTcAlt
                        Else
                            ColoreTcSel = ColoreTc
                        End If
                    End If
                End If
                If lastIdTC <> mov.Risorsa.IdTipoCarta Then
                    If mov.Risorsa.IsLastra Then
                        lastIdTC = -1
                    Else
                        lastIdTC = mov.Risorsa.IdTipoCarta
                    End If
                    bufferhtml &= "<td width=200 valign=top align=center bgcolor=" & ColoreTcSel & "><img src=""" & mov.Risorsa.TipoCarta.ImgRif & """ width=64><br><b>" & mov.Risorsa.TipoCarta.Tipologia & "</b></td>"
                Else
                    bufferhtml &= "<td bgcolor=" & ColoreTcSel & ">&nbsp;</td>"
                End If

                bufferhtml &= "<td>"
                bufferhtml &= "<table border=0 style='width:500px;'><tr rowspan=5><td style='font-size:14px;' colspan=2 bgcolor=" & ColoreTcSel & "><b>" & mov.Risorsa.Descrizione & "</b></td></tr>"
                bufferhtml &= "<tr><td>Giacenza attuale </td><td style='font-size:14px;' align=right><b>" & FormerHelper.Stringhe.FormattaNumero(mov.GiacenzaAttuale) & "</b></td></tr>"
                bufferhtml &= "<tr><td bgcolor=#f2f2f2>Carico </td><td bgcolor=#f2f2f2 style='font-size:14px;' align=right><b>" & FormerHelper.Stringhe.FormattaNumero(mov.TotCarico) & "</b><i> (Ult. Carico " & mov.Risorsa.UltimoCaricoMagazzinoStr & ")</i></td></tr>"
                bufferhtml &= "<tr><td>Prenotazione </td><td style='font-size:14px;' align=right><b>" & FormerHelper.Stringhe.FormattaNumero(mov.TotPrenotazioni) & "</b></td></tr>"
                bufferhtml &= "<tr><td bgcolor=#f2f2f2>Scarico </td><td bgcolor=#f2f2f2 style='font-size:14px;' align=right><b>" & FormerHelper.Stringhe.FormattaNumero(mov.TotScarico) & "</b><i> (Ult. Scarico " & mov.Risorsa.UltimoScaricoMagazzinoStr & ")</i></td></tr></table>"
                'bufferhtml &= "<tr><td>Q.ta in Ordini </td><td style='font-size:14px;' align=right><b>" & FormerHelper.Stringhe.FormattaNumero(mov.TotDaOrdini) & "</b></td></tr></table>"
                bufferhtml &= "</td></tr>"

            Next

            bufferhtml &= "</table></div></center>"

        End Using

        Dim T As New My.Templates.ContenitoreAnteprima

        bufferhtml = T.TransformText.Replace(FormerConst.Anteprime.TagContenuto, bufferhtml)

        webRiepilogo.Document.OpenNew(False)
        webRiepilogo.Document.Write(bufferhtml)
        webRiepilogo.Refresh()
        'webRiepilogo.DocumentText = bufferhtml
        'webRiepilogo.Document.Write(bufferhtml)
        'Application.DoEvents()

        Cursor.Current = Cursors.Default

    End Sub

    'Friend Shared Sub CreaRiepilogoMagazzino(ByVal TipoMovimenti As enTipoMovMagaz,
    '                                         ByVal PeriodoRiferimento As enPeriodoRiferimento,
    '                                         ByRef webRiepilogo As WebBrowser)

    '    Cursor.Current = Cursors.WaitCursor

    '    webRiepilogo.Navigate("about:blank")

    '    Dim bufferhtml As String = ""

    '    bufferhtml &= "<br>"
    '    bufferhtml &= "<h2>Resoconto Magazzino: " & FormerEnumHelper.TipoMovimentoMagazzinoStr(TipoMovimenti).ToUpper & " - Periodo: " & FormerEnumHelper.PeriodoRiferimentoStr(PeriodoRiferimento).ToUpper & "</h2>"

    '    Using Mgr As New MagazzinoDAO

    '        Dim p As LUNA.LunaSearchParameter = Nothing

    '        If TipoMovimenti <> enTipoMovMagaz.Tutto Then
    '            p = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, TipoMovimenti)
    '        End If

    '        Dim l As List(Of MovimentoMagazzino) = Mgr.FindAll(LFM.MovimentoMagazzino.DataMov.Name & " DESC", p)

    '        Select Case PeriodoRiferimento
    '            Case enPeriodoRiferimento.UnGiorno  ' trimestre
    '                l = l.FindAll(Function(x) x.DataMov.Date = Now.Date)
    '            Case enPeriodoRiferimento.Ieri  ' trimestre
    '                l = l.FindAll(Function(x) x.DataMov.Date = Now.Date.AddDays(-1))
    '            Case enPeriodoRiferimento.UnaSettimana  ' semestre
    '                l = l.FindAll(Function(x) x.DataMov.Date >= Now.Date.AddDays(-7))
    '            Case enPeriodoRiferimento.UnMese
    '                l = l.FindAll(Function(x) x.DataMov.Date >= Now.Date.AddMonths(-1))
    '            Case enPeriodoRiferimento.UnAnno
    '                l = l.FindAll(Function(x) x.DataMov.Date >= Now.Date.AddYears(-1))
    '        End Select

    '        If TipoMovimenti <> enTipoMovMagaz.Tutto Then
    '            Dim Totale As Integer = 0

    '            Totale = l.Sum(Function(x) x.Qta)
    '            bufferhtml &= "<h3 style='color:red;'>TOTALE Q.TA' MOVIMENTI IN ELENCO " & FormerHelper.Stringhe.FormattaNumero(Totale) & "</h4>"
    '            bufferhtml &= "<br>"
    '        End If

    '        bufferhtml &= "<center><div><table border=1 cellpadding=5 width=60% style='background-color:white;'>"
    '        bufferhtml &= "<tr>"
    '        bufferhtml &= "<td></td>"
    '        bufferhtml &= "<td style='font-size:14px;font-weight:bold;'>DATA</td>"
    '        bufferhtml &= "<td style='font-size:14px;font-weight:bold;'>TIPO MOVIMENTO</td>"
    '        bufferhtml &= "<td style='font-size:14px;font-weight:bold;'>RISORSA</td>"
    '        bufferhtml &= "<td style='font-size:14px;font-weight:bold;'>QUANTITA'</td>"
    '        bufferhtml &= "<td style='font-size:14px;font-weight:bold;'>COMMESSA</td>"
    '        bufferhtml &= "<td style='font-size:14px;font-weight:bold;'>OPERATORE</td>"
    '        bufferhtml &= "</tr>"

    '        For Each mov In l
    '            bufferhtml &= "<tr>"
    '            bufferhtml &= "<td width=48><img src=""" & mov.Risorsa.TipoCarta.ImgRif & """ width=48></td>"
    '            bufferhtml &= "<td style='font-size:14px;'>" & mov.DataMov.ToString("dd/MM/yyyy") & "</td>"
    '            bufferhtml &= "<td style='font-size:14px;'><b>" & FormerEnumHelper.TipoMovimentoMagazzinoStr(mov.TipoMov) & "</b></td>"
    '            bufferhtml &= "<td style='font-size:14px;'>(" & mov.Risorsa.CodiceStr & ") <b>" & mov.Risorsa.Descrizione & "<b><br>" & mov.Risorsa.TipoCarta.TipoCartaStr & "</td>"
    '            bufferhtml &= "<td align=right style='font-size:14px;'><b>" & mov.Qta & "</b></td>"
    '            bufferhtml &= "<td align=right style='font-size:14px;'>" & mov.IdCom & "</td>"

    '            If mov.IdUt Then
    '                Using U As New Utente
    '                    U.Read(mov.IdUt)
    '                    bufferhtml &= "<td style='font-size:14px;'><b>" & U.LoginEx & "</b></td>"
    '                End Using
    '            Else
    '                bufferhtml &= "<td style='font-size:14px;'>-</td>"
    '            End If

    '            bufferhtml &= "</tr>"

    '        Next

    '        bufferhtml &= "</table></div></center>"

    '    End Using

    '    Dim T As New My.Templates.ContenitoreAnteprima

    '    bufferhtml = T.TransformText.Replace(FormerConst.Anteprime.TagContenuto, bufferhtml)

    '    webRiepilogo.Document.OpenNew(False)
    '    webRiepilogo.Document.Write(bufferhtml)
    '    webRiepilogo.Refresh()
    '    'webRiepilogo.DocumentText = bufferhtml
    '    'webRiepilogo.Document.Write(bufferhtml)
    '    'Application.DoEvents()

    '    Cursor.Current = Cursors.Default

    'End Sub

    Friend Shared Sub CreaRiepilogoCom(ByVal _ComSel As Commessa,
                                       ByRef webRiepilogo As WebBrowser,
                                       Optional ByVal TipoAnte As enTipoAnteprima = enTipoAnteprima.Generale)
        'FormerDebug.Traccia()
        webRiepilogo.Navigate("about:blank")

        If Not _ComSel Is Nothing Then

            If _ComSel.IdCom Then
                'qui creo il riepilogo e lo carico

                Try

                    Dim bufferhtml As String = ""

                    Select Case TipoAnte
                        Case enTipoAnteprima.Generale, enTipoAnteprima.Breve
                            bufferhtml = _ComSel.CreaRiepilogo

                        Case enTipoAnteprima.Operatore
                            bufferhtml = HeaderOperatore

                            'bufferhtml = "<style>body{font-size:16px;}</style>" & ControlChars.NewLine

                            bufferhtml &= _ComSel.CreaRiepilogo(True)

                    End Select

                    'qui lancio il modulo esterno per visualizzarlo
                    '               Dim PathMOd As String = FormerPath.PathLocale & "riepCom.htm"
                    'Dim Sr As StreamWriter, PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")
                    'Sr = New System.IO.StreamWriter(PathFileStampa, False)

                    'Sr.Write(bufferhtml)

                    'Sr.Close()

                    ''             sr = Nothing

                    'webRiepilogo.Navigate(PathFileStampa)
                    Dim T As New My.Templates.ContenitoreAnteprima

                    bufferhtml = T.TransformText.Replace(FormerConst.Anteprime.TagContenuto, bufferhtml)

                    webRiepilogo.Document.OpenNew(False)
                    webRiepilogo.Document.Write(bufferhtml)
                    webRiepilogo.Refresh()
                    'webRiepilogo.DocumentText = bufferhtml
                    'webRiepilogo.Document.Write(bufferhtml)
                    'Application.DoEvents()

                    Cursor.Current = Cursors.Default

                Catch ex As Exception
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try

            End If

        End If

    End Sub


End Class
