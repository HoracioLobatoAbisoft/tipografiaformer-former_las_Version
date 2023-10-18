Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucAmministrazioneReport
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        CaricaCombo()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()

    End Sub

    Private Sub CaricaCombo()
        Try

            cmbMeseRif.DataSource = MgrReport.GetMesiDisponibili
            cmbMeseRif.DisplayMember = "Riassunto"
            cmbMeseRif.ValueMember = "Chiave"

        Catch ex As Exception

        End Try

    End Sub

    Private _BufferTotale As String = String.Empty

    Private Sub CreaReport()

        Cursor.Current = Cursors.WaitCursor

        Try
            Dim buffer As String = String.Empty

            Dim RisultatoMesi As List(Of MeseDisponibile) = MgrReport.GetTotaleMensile
            buffer &= "<html><head>"

            buffer &= "<style>"
            buffer &= "body {font-family:arial;font-size:11px;}"
            buffer &= "table {font-family:arial;font-size:11px;}td {padding-right:10px;}"
            buffer &= "h1 {font-size:20px;font-weight:bold;color:red;margin-bottom:5px;}"
            buffer &= "h2 {font-size:14px;font-weight:bold;color:blue;margin-bottom:5px;}"
            buffer &= ".importi {background-color:#f3cbaa;}"
            buffer &= ".importiHeader {background-color:#f58220;}"
            buffer &= ".statOrdini {background-color:#aaf3af;}"
            buffer &= ".statClienti {background-color:#aaddf3;}"
            buffer &= ".statProd {background-color:#f1f2a0;}"
            buffer &= "</style>"
            buffer &= "</head><body>"
            buffer &= "<table>"
            buffer &= "<tr>"

            If _BufferTotale.Length = 0 Then
                _BufferTotale &= "<td valign=top>"
                _BufferTotale &= "<h1>Riassunto</h1>"
                _BufferTotale &= "<table border=1 class=""importi"">"
                _BufferTotale &= "<tr>"
                _BufferTotale &= "<td class=""importiHeader""><b>Mese</b></td>"
                _BufferTotale &= "<td class=""importiHeader""><b>Totale</b></td>"
                _BufferTotale &= "<td class=""importiHeader""><b>Numero Ordini</b></td>"
                _BufferTotale &= "<td class=""importiHeader""><b>Registrazioni dal sito</b></td>"
                _BufferTotale &= "</tr>"
                For Each singMese As MeseDisponibile In RisultatoMesi
                    _BufferTotale &= "<tr>"
                    _BufferTotale &= "<td>" & singMese.AnnoRif & " " & FormerLib.FormerHelper.Calendario.MeseToString(singMese.MeseRif) & "</td>"
                    _BufferTotale &= "<td align=right>&euro; " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(singMese.Fatturato) & "</td>"
                    _BufferTotale &= "<td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(singMese.NumeroOrdini) & "</td>"
                    _BufferTotale &= "<td align=right>" & singMese.NumeroRegistrazioniDalSito & "</td>"
                    _BufferTotale &= "</tr>"
                Next
                _BufferTotale &= "</table></td>"

                _BufferTotale &= "<td valign=top>"
                _BufferTotale &= "<h1>Statistiche</h1>"

                Dim totClienti As Integer = 0
                Dim totClientiSito As Integer = 0
                Dim totClientiSitoOrd As Integer = 0
                Dim totClientiGest As Integer = 0
                Dim totClientiGestOrd As Integer = 0
                Dim totClientiPre As Integer = 0
                Dim totClientiPreOrd As Integer = 0
                Using mgr As New VociRubricaDAO
                    Dim l As List(Of VoceRubrica) = mgr.GetAll()

                    totClienti = l.Count
                    Dim lSito As List(Of VoceRubrica) = l.FindAll(Function(x) x.Sorgente = "W")
                    Dim lGest As List(Of VoceRubrica) = l.FindAll(Function(x) x.Sorgente = "G" Or x.Sorgente = "F")
                    Dim lPre As List(Of VoceRubrica) = l.FindAll(Function(x) x.Sorgente <> "W" And x.Sorgente <> "G" And x.Sorgente <> "F")
                    totClientiSito = lSito.Count
                    totClientiSitoOrd = lSito.FindAll(Function(y) y.Ordini.Count > 0).Count
                    totClientiGest = lGest.Count
                    totClientiGestOrd = lGest.FindAll(Function(y) y.Ordini.Count > 0).Count
                    totClientiPre = lPre.Count
                    totClientiPreOrd = lPre.FindAll(Function(y) y.Ordini.Count > 0).Count
                End Using

                _BufferTotale &= "<h2>Clienti</h2>"
                _BufferTotale &= "<table class=""statClienti"" border=1 >"
                _BufferTotale &= "<tr><td>Numero Clienti</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClienti) & "</td></tr>"
                _BufferTotale &= "<tr><td><i>Registrati dal sito</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiSito) & "</td></tr>"
                _BufferTotale &= "<tr><td><i>Registrati dal sito che hanno fatto almeno un ordine</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiSitoOrd) & "</td></tr>"
                _BufferTotale &= "<tr><td><i>Registrati dal gestionale</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiGest) & "</td></tr>"
                _BufferTotale &= "<tr><td><i>Registrati dal gestionale che hanno fatto almeno un ordine</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiGestOrd) & "</td></tr>"
                _BufferTotale &= "<tr><td><i>Pre-esistenti</td align=right><td>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiPre) & "</td></tr>"
                _BufferTotale &= "<tr><td><i>Pre-esistenti che hanno fatto almeno un ordine</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiPreOrd) & "</td></tr>"
                _BufferTotale &= "</table>"

                _BufferTotale &= "</td>"
            End If

            buffer &= _BufferTotale

            buffer &= "<td valign=top>"

            Dim MeseScelto As MeseDisponibile = cmbMeseRif.SelectedItem

            buffer &= "<h1>" & MeseScelto.Riassunto & "</h1>"

            Dim ListaOrdini As List(Of OrdineRicerca) = Nothing

            Dim DataStart As New Date(MeseScelto.AnnoRif, MeseScelto.MeseRif, 1)
            Dim DataEnd As Date = DataStart.AddMonths(1).AddDays(-1)

            Using mgr As New OrdiniDAO

                Dim ListaStati As String = enStatoOrdine.Preinserito

                ListaStati &= "," & enStatoOrdine.Registrato
                ListaStati &= "," & enStatoOrdine.RefineAutomatico
                'ListaStati &= "," & enStatoOrdine.InSospeso
                ListaStati &= "," & enStatoOrdine.InCodaDiStampa
                ListaStati &= "," & enStatoOrdine.StampaInizio
                ListaStati &= "," & enStatoOrdine.StampaFine
                ListaStati &= "," & enStatoOrdine.FinituraCommessaInizio
                ListaStati &= "," & enStatoOrdine.FinituraCommessaFine
                ListaStati &= "," & enStatoOrdine.FinituraProdottoInizio
                ListaStati &= "," & enStatoOrdine.FinituraProdottoFine
                ListaStati &= "," & enStatoOrdine.Imballaggio
                ListaStati &= "," & enStatoOrdine.ImballaggioCorriere
                ListaStati &= "," & enStatoOrdine.ProntoRitiro
                ListaStati &= "," & enStatoOrdine.UscitoMagazzino
                ListaStati &= "," & enStatoOrdine.InConsegna
                ListaStati &= "," & enStatoOrdine.Consegnato
                ListaStati &= "," & enStatoOrdine.PagatoAcconto
                ListaStati &= "," & enStatoOrdine.PagatoInteramente

                ListaOrdini = mgr.Lista(, ListaStati,,,,,,, DataStart, DataEnd)

            End Using

            'qui devo integrare quelli archiviati

            Using mgr As New ArchiviDAO
                Dim lO As List(Of Archiviato) = mgr.Lista(DataStart, DataEnd)

                For Each singO In lO
                    Dim Oric As New OrdineRicerca(singO)
                    ListaOrdini.Add(Oric)
                Next

            End Using


            Dim ToTOrdini As Integer = ListaOrdini.Count

            Dim totOrdiniDaNuovi As Integer = ListaOrdini.FindAll(Function(x) x.SorgenteCliente = "W").Count
            Dim totOrdiniDaGest As Integer = ListaOrdini.FindAll(Function(x) x.SorgenteCliente = "G").Count
            Dim totOrdiniDaVecchi As Integer = ListaOrdini.FindAll(Function(x) x.SorgenteCliente <> "W" And x.SorgenteCliente <> "G").Count

            Dim totOrdiniCoupon As Integer = ListaOrdini.FindAll(Function(x) x.IdCoupon <> 0).Count
            Dim totOrdiniPromo As Integer = ListaOrdini.FindAll(Function(x) x.IdPromo <> 0).Count

            Dim PercNuovi As Integer = Math.Round((totOrdiniDaNuovi * 100) / ToTOrdini)
            Dim PercGest As Integer = Math.Round((totOrdiniDaGest * 100) / ToTOrdini)
            Dim PercVecchi As Integer = Math.Round((totOrdiniDaVecchi * 100) / ToTOrdini)
            buffer &= "<h2>Ordini</h2>"
            buffer &= "<table class=""statOrdini"" border=1 >"
            buffer &= "<tr><td>Numero Ordini</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(ToTOrdini) & "</td></tr>"
            buffer &= "<tr><td><i>Inseriti da</i> Clienti registrati dal sito</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniDaNuovi) & " (" & PercNuovi & "%)</td></tr>"
            buffer &= "<tr><td><i>Inseriti da</i> Clienti registrati dal gestionale</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniDaGest) & " (" & PercGest & "%)</td></tr>"
            buffer &= "<tr><td><i>Inseriti da</i> Vecchi clienti della tipografia</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniDaVecchi) & " (" & PercVecchi & "%)</td></tr>"
            buffer &= "<tr><td><i>con Coupon</i></td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniCoupon) & "</td></tr>"
            buffer &= "<tr><td><i>con Promo</i></td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniPromo) & "</td></tr>"
            buffer &= "</table>"

            Dim lRep As New List(Of RisultatoReparto)
            Dim lPrev As New List(Of RisultatoPreventivazione)
            Dim TotFatturato As Decimal = 0
            For Each O As Ordine In ListaOrdini
                Dim IdListinoBase As Integer = O.IdListinoBase
                Dim Pre As RisultatoPreventivazione = Nothing
                Dim Rep As RisultatoReparto = Nothing
                If IdListinoBase Then
                    Rep = lRep.Find(Function(x) x.IdRep = O.ListinoBase.Preventivazione.IdReparto)
                    If Rep Is Nothing Then
                        Rep = New RisultatoReparto
                        Rep.IdRep = O.ListinoBase.Preventivazione.IdReparto
                        Rep.Descrizione = FormerEnumHelper.RepartoStr(Rep.IdRep)
                        lRep.Add(Rep)
                    End If
                    Pre = lPrev.Find(Function(x) x.IdPrev = O.ListinoBase.IdPrev)
                    If Pre Is Nothing Then
                        Pre = New RisultatoPreventivazione
                        Pre.IdRep = O.ListinoBase.Preventivazione.IdReparto
                        Pre.Descrizione = O.ListinoBase.Preventivazione.Descrizione
                        Pre.IdPrev = O.ListinoBase.IdPrev
                        lPrev.Add(Pre)
                    End If
                Else
                    Rep = lRep.Find(Function(x) x.IdRep = 0)
                    If Rep Is Nothing Then
                        Rep = New RisultatoReparto
                        Rep.IdRep = 0
                        Rep.Descrizione = "Non specificato"
                        lRep.Add(Rep)
                    End If
                    Pre = lPrev.Find(Function(x) x.IdPrev = 0)
                    If Pre Is Nothing Then
                        Pre = New RisultatoPreventivazione
                        Pre.IdRep = enRepartoWeb.Tutto
                        Pre.Descrizione = "Non specificato"
                        Pre.IdPrev = 0
                        lPrev.Add(Pre)
                    End If
                End If
                Pre.NumOrd += 1
                Pre.Fatturato += O.TotaleImponibile
                TotFatturato += O.TotaleImponibile
                Rep.NumOrd += 1
                Rep.Fatturato += O.TotaleImponibile
            Next

            lPrev.Sort(Function(x, y) y.Fatturato.CompareTo(x.Fatturato))

            lRep.Sort(Function(x, y) y.Fatturato.CompareTo(x.Fatturato))

            buffer &= "<h2>Numero di Ordini per Reparto</h2>"
            buffer &= "<table class=""statProd"" border=1 >"
            For Each P As RisultatoReparto In lRep
                buffer &= "<tr><td>" & P.Descrizione & "</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(P.NumOrd) & "</td>"
                buffer &= "<td align=right>&euro; " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(P.Fatturato) & "</td>"
                buffer &= "<td align=right>" & Math.Round((P.Fatturato * 100) / TotFatturato) & "%</td>"
                buffer &= "</tr>"
            Next
            buffer &= "</table>"

            buffer &= "<h2>Numero di Ordini per Preventivazione</h2>"
            buffer &= "<table class=""statProd"" border=1 >"
            For Each P As RisultatoPreventivazione In lPrev
                buffer &= "<tr><td>" & P.Descrizione & "</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(P.NumOrd) & "</td>"
                buffer &= "<td align=right>&euro; " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(P.Fatturato) & "</td>"
                buffer &= "<td align=right>" & Math.Round((P.Fatturato * 100) / TotFatturato) & "%</td>"
                buffer &= "</tr>"
            Next
            buffer &= "</table>"

            buffer &= "</td></tr></table></body></html>"

            Dim PathRis As String = FormerConfig.FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")

            Using w As New IO.StreamWriter(PathRis)

                w.Write(buffer)

            End Using

            webReport.Navigate(PathRis)
        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nella creazione del report: " & ex.Message)
        End Try

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked

        CreaReport()

    End Sub

    Private Sub lnkStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        'If _ComSel.IdCom Then

        ParentFormEx.Sottofondo()

        'Dim PathMOd As String = webRiepilogo.Url.ToString 'FormerPath.PathLocale & "riepCom.htm"

        Using x As New frmStampa

            x.Carica(webReport)

        End Using

        ParentFormEx.Sottofondo()

        'End If

    End Sub
End Class
