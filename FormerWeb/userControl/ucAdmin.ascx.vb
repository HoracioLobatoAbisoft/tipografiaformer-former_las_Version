Imports FormerDALWeb
Imports System.IO
Imports FormerLib.FormerEnum
Imports System.Net

Public Class ucAdmin
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            CaricaDati()
        End If
    End Sub

    Private Sub CaricaRecensioni()

        Dim l As List(Of Review) = Nothing
        Using mgr As New ReviewDAO
            l = mgr.FindAll(New LUNA.LunaSearchParameter("Stato", enStatoReview.DaApprovare))
        End Using

        lblTotRecensioni.Text = "Sono presenti <b class=""red"">" & l.Count & "</b> RECENSIONI in <b>Attesa di Approvazione</b>"

    End Sub


    Private Sub CaricaDati()
        CaricaRecensioni()
        CaricaUtentiConnessi()
        CaricaLog()
        CaricaConnAttive()
        CaricaGoto()
        CaricaLastReg()
        If FormerWebApp.IsDebug Then
            lblDebugAttivo.Text = "SI!!! Attenzione sei in modalità DEVELOPER"
            lblDebugAttivo.ForeColor = Drawing.Color.Red
        End If

    End Sub

    Private Sub CaricaLastReg()

        Dim L As List(Of Utente) = Nothing
        Using mgr As New UtentiDAO
            Dim so As New LUNA.LunaSearchOption
            so.Top = 30
            so.OrderBy = "DataIns Desc"

            L = mgr.FindAll(so)
        End Using

        dgUtentiReg.DataSource = L
        dgUtentiReg.DataBind()

    End Sub

    Private Sub CaricaGoto()

        'Dim L As List(Of TraceSource) = Nothing
        'Using mgr As New TraceSourceDAO
        '    L = mgr.GetAll("Counter desc")
        'End Using

        'dgGoto.DataSource = L
        'dgGoto.DataBind()


    End Sub

    Private Sub CaricaConnAttive()
        Dim TotMemory As Single = Math.Round(GC.GetTotalMemory(False) / 1024000, 2)
        lblTotConnAttive.Text = LUNA.LunaContext.TotConnAttive & " (" & TotMemory & "mb)"
    End Sub

    Private Function StringInside(StringaToFind As String, StringaMaster As String) As Integer
        Dim ris As Integer = 0

        Dim trovato As Integer = StringaMaster.IndexOf(StringaToFind)
        Do While trovato <> -1
            ris += 1
            trovato = StringaMaster.IndexOf(StringaToFind, trovato + 1)
        Loop

        Return ris
    End Function
    Private Sub CaricaLog()
        Dim tr As New TableRow

        For x = 0 To 7

            Dim DataRif As Date = Date.Now.AddDays(-x).Date
            Dim NomeFile As String = DataRif.ToString("yyyyMMdd") & ".txt"
            Dim PathFile As String = Server.MapPath("/public/log") & "/" & NomeFile
            Dim NumOrdWeb As Decimal = 0
            Dim NumOrdG As Decimal = 0
            Dim TotOrdWeb As Integer = 0
            Dim TotOrdG As Integer = 0
            Dim NumUtReg As String = String.Empty


            Dim ParamSearch As New LUNA.LunaSearchParameter("CONVERT(varchar(10), DataIns, 112)", DataRif.ToString("yyyyMMdd"))

            Using mgr As New OrdiniWebDAO
                Dim L As List(Of OrdineWeb) = mgr.FindAll(ParamSearch,
                                                        New LUNA.LunaSearchParameter("StatoWeb", CInt(enStato.Attivo)),
                                                        New LUNA.LunaSearchParameter("Stato", "(" & enStatoOrdine.Eliminato & "," & enStatoOrdine.Rifiutato & "," & enStatoOrdine.InSospeso & ")", "NOT IN"),
                                                        New LUNA.LunaSearchParameter("OrdineWeb", 1))
                For Each o As OrdineWeb In L
                    If o.InseritoDa OrElse
                       o.Utente.IdRubricaInt = FormerLib.FormerConst.UtentiSpecifici.IdRubricaInternaFormer Then
                        NumOrdG += (o.PrezzoCalcolatoNetto - o.Sconto + o.Ricarico)
                        TotOrdG += 1
                    Else
                        NumOrdWeb += (o.PrezzoCalcolatoNetto - o.Sconto + o.Ricarico)
                        TotOrdWeb += 1
                    End If
                Next
            End Using

            Using mgr As New UtentiDAO
                Dim L As List(Of Utente) = mgr.FindAll(ParamSearch)
                NumUtReg = L.Count
            End Using

            Dim tc As New TableCell
            tc.Text = "<a href=""/public/log/" & NomeFile & """ target=""_new"">" & DataRif.ToString("ddd dd MMM") & "<br><b>W: € " & Math.Round(NumOrdWeb, 2) & "</b> (" & TotOrdWeb & ")" & "<br><b>G: € " & Math.Round(NumOrdG, 2) & "</b> (" & TotOrdG & ")<br>" & "<b style='color:green;'>T: € " & Math.Round(NumOrdWeb + NumOrdG, 2) & "</b> (" & TotOrdWeb + TotOrdG & ")" & "<br>New Ut. <b>" & NumUtReg & "</b>" & "</a>"
            tc.CssClass = "celleAdmin"
            tr.Cells.Add(tc)
        Next
        tableLog.Rows.Add(tr)

        Dim D As New DirectoryInfo(FormerWebApp.PhisicalPathLog)
        Dim Count As Integer = 0
        Dim Grandezza As Integer = 0
        Try
            For Each F As FileInfo In D.GetFiles
                Grandezza += F.Length
                Count += 1
            Next
        Catch ex As Exception

        End Try

        Using mgr As New OrdiniWebDAO
            Dim l As List(Of OrdineWeb) = mgr.FindAll("DataIns",
                                                      New LUNA.LunaSearchParameter("StatoWeb", CInt(enStato.Attivo)),
                                                      New LUNA.LunaSearchParameter("Stato", CInt(enStatoOrdine.InAttesaAllegati)))

            dgLavFile.DataSource = l
            dgLavFile.DataBind()
            lblTotOrdAll.Text = "Sono presenti <b class=""red"">" & l.Count & "</b> LAVORI in <b>Attesa di Invio File</b>"
        End Using

        Using mgr As New OrdiniWebDAO
            Dim l As List(Of OrdineWeb) = mgr.FindAll("DataIns",
                                                      New LUNA.LunaSearchParameter("StatoWeb", CInt(enStato.Attivo)),
                                                      New LUNA.LunaSearchParameter("Stato", CInt(enStatoOrdine.Preinserito)),
                                                      New LUNA.LunaSearchParameter("IdOrdineInt", 0))

            dgLavDownload.DataSource = l
            dgLavDownload.DataBind()
        End Using

        Using mgr As New ConsegneDAO
            Dim l As List(Of Consegna) = mgr.FindAll("DataInserimento", New LUNA.LunaSearchParameter("IdStatoConsegna", CInt(enStatoConsegna.InAttesaDiPagamento)))

            dgOrdPag.DataSource = l
            dgOrdPag.DataBind()
            lblTotOrdPag.Text = "Sono presenti <b class=""red"">" & l.Count & "</b> ORDINI in <b>Attesa di Pagamento</b>"
        End Using

        Using mgr As New UtentiDAO
            Dim l As List(Of Utente) = mgr.FindAll(New LUNA.LunaSearchParameter("CONVERT(varchar(10), LastLogin, 112)", Now.Date.ToString("yyyyMMdd")))

            lblTotUtOggi.Text = "Oggi sono entrati nel sito <b class=""red"">" & l.Count & "</b> nostri clienti diversi."
        End Using
        lblTotaleLog.Text = "Sono presenti <b>" & Count & "</b> files. Il totale in Kb è <b>" & Math.Round(Grandezza / 1024) & "</b>"

    End Sub

    Private Sub CaricaUtentiConnessi()

        Dim ListaUtenti As Dictionary(Of String, UtenteSito) = Application("ListaUtenti")

        Dim l As New List(Of UtenteSito)
        For Each UtCon As KeyValuePair(Of String, UtenteSito) In ListaUtenti
            l.Add(UtCon.Value)
        Next

        l = l.FindAll(Function(x) DateDiff(DateInterval.Minute, x.LastPageVisitedWhen, Now) < 11)

        l.Sort(Function(x, y) y.LastPageVisitedWhen.CompareTo(x.LastPageVisitedWhen))

        lblTitolo.Text = "Totale aggiornato alle <b>" & Now.ToString("HH:mm.ss") & "</b>: utenti collegati <b>" & l.Count & "</b>"

        tableAdmin.Rows.Clear()

        For Each UtCon As UtenteSito In l
            Dim tr As New TableRow
            Dim tc As New TableCell

            tc.Text = UtCon.LastPageVisitedWhen.ToString("HH:mm:ss")
            tc.CssClass = "celleTableUt"
            tc.VerticalAlign = VerticalAlign.Top
            tr.Cells.Add(tc)

            tc = New TableCell

            Dim CellaUtente As String = ""
            If UtCon.IsAdmin Then
                CellaUtente = "<img src=""/img/icoAdmin16.png"" /> "
            ElseIf UtCon.IsCrawler Then
                CellaUtente = "<img src=""/img/icoCrawler16.png"" /> "
            End If

            Dim Nominativo As String = StrConv(UtCon.Nominativo, VbStrConv.ProperCase)
            If Nominativo.Length > 50 Then
                Nominativo = Nominativo.Substring(0, 50) & "..."
            End If

            CellaUtente &= "<b style=""color:#009ec9;"">" & Nominativo & "</b>"
            CellaUtente &= "<br><div style=""padding:2px;background-color:#d6e03d;""><i><b>" & UtCon.BrowserInUso & "</b> Ip <b><a href=""https://cymon.io/" & UtCon.IpUtente & """ target=""_new"">" & UtCon.IpUtente & "</a></b>"
            CellaUtente &= " - Id <b>" & UtCon.IdUtente & "</b> (Id int.<b>" & UtCon.IdRubricaInt & "</b>)</i></div>"
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = CellaUtente
            tc.CssClass = "celleTableUt"
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = "<b><a href=""https://cymon.io/" & UtCon.IpUtente & """ target=""_new"" style=""color:red;"">CYMON</a></b><br><br><b><a href=""http://whatismyipaddress.com/ip/" & UtCon.IpUtente & """ target=""_new"" style=""color:green;"">WHO IS</a></b>"
            tc.CssClass = "celleTableUt"
            tc.VerticalAlign = VerticalAlign.Top
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = "<img src=""/img/icoCarrello16.png""> &euro; " & UtCon.TotNelCarrello
            tc.CssClass = "celleTableUt"
            tc.VerticalAlign = VerticalAlign.Top
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = "<a href=""" & UtCon.LastPageVisited & """>" & IIf(UtCon.LastPageVisited.Length > 50, Left(UtCon.LastPageVisited, 50) & "...", UtCon.LastPageVisited) & "</a>"
            tc.CssClass = "celleTableUt"
            tc.VerticalAlign = VerticalAlign.Top
            tr.Cells.Add(tc)

            tableAdmin.Rows.Add(tr)

        Next

    End Sub

    Protected Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiornaUtenti.Click

        CaricaDati()

    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        Try


            'Cache.Remove(FormerWebApp.CacheKeyLstOffSet)
            'Cache.Remove(FormerWebApp.CacheKeyLstDigitale)
            'Cache.Remove(FormerWebApp.CacheKeyLstRicamo)
            'Cache.Remove(FormerWebApp.CacheKeyLstPackaging)
            'Cache.Remove(FormerWebApp.CacheKeyLstCouponVisibili)

            HttpRuntime.Close()

        Catch ex As Exception

        End Try

        Try
            HttpRuntime.UnloadAppDomain()
        Catch ex As Exception

        End Try

        Response.Redirect("/")

    End Sub

    Private Sub TestTLS()

        Dim EntryPointTLS As String = "https://tlstest.paypal.com/"

        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = 3072
        ServicePointManager.DefaultConnectionLimit = 9999

        Dim req As HttpWebRequest = HttpWebRequest.Create(EntryPointTLS)
        Dim resp As HttpWebResponse
        Try
            resp = DirectCast(req.GetResponse(), HttpWebResponse)
        Catch ex As WebException
            resp = DirectCast(ex.Response, HttpWebResponse)
        End Try

        lblTestTls.Text = resp.StatusCode

    End Sub

    Private Sub btnTestTLS12_Click(sender As Object, e As EventArgs) Handles btnTestTLS12.Click

        TestTLS()

    End Sub
End Class