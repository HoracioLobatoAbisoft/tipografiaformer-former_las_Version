Imports FormerDALWeb

Public Class admin
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If UtenteConnesso.IsAdmin = False Then
            Response.Redirect("/")
        End If

        If Not IsPostBack Then
            CaricaDati()
        End If

    End Sub

    Private Sub CaricaDati()

        CaricaLog()

        CaricaUtentiConnessi()

        CaricaTotListiniGenerati()

    End Sub

    Private Sub CaricaTotListiniGenerati()

        Using mgr As New ListiniUtenteWDAO

            Dim l As List(Of ListinoUtenteW) = mgr.FindAll(New LUNA.LunaSearchParameter("NOT UltimaGenerazione", Nothing, "IS"))

            lblTotList.Text = l.Count

            Dim lC As List(Of ListinoUtenteW) = mgr.GetAll()

            lblTotRiv.Text = lC.Count

        End Using

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

            'tc = New TableCell
            'tc.Text = "<b><a href=""https://cymon.io/" & UtCon.IpUtente & """ target=""_new"" style=""color:red;"">CYMON</a></b><br><br><b><a href=""http://whatismyipaddress.com/ip/" & UtCon.IpUtente & """ target=""_new"" style=""color:green;"">WHO IS</a></b>"
            'tc.CssClass = "celleTableUt"
            'tc.VerticalAlign = VerticalAlign.Top
            'tr.Cells.Add(tc)

            'tc = New TableCell
            'tc.Text = "<img src=""/img/icoCarrello16.png""> &euro; " & UtCon.TotNelCarrello
            'tc.CssClass = "celleTableUt"
            'tc.VerticalAlign = VerticalAlign.Top
            'tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = "<a href=""" & UtCon.LastPageVisited & """>" & IIf(UtCon.LastPageVisited.Length > 50, Left(UtCon.LastPageVisited, 50) & "...", UtCon.LastPageVisited) & "</a>"
            tc.CssClass = "celleTableUt"
            tc.VerticalAlign = VerticalAlign.Top
            tr.Cells.Add(tc)

            tableAdmin.Rows.Add(tr)

        Next

    End Sub

    Private Sub CaricaLog()
        Dim tr As New TableRow

        For x = 0 To 7

            Dim DataRif As Date = Date.Now.AddDays(-x).Date
            Dim NomeFile As String = DataRif.ToString("yyyyMMdd") & ".txt"
            Dim PathFile As String = Server.MapPath("/public/log") & "/" & NomeFile
            Dim NumOrd As Single = 0
            Dim TotOrd As String = String.Empty
            Dim NumUtReg As String = String.Empty

            Dim tc As New TableCell
            tc.Text = "<a href=""/public/log/" & NomeFile & """ target=""_new"">" & DataRif.ToString("ddd dd MMM") & "</a>"
            tc.CssClass = "celleAdmin"
            tr.Cells.Add(tc)
        Next
        tableLog.Rows.Add(tr)


    End Sub

    Protected Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiornaUtenti.Click

        CaricaDati()

    End Sub

End Class