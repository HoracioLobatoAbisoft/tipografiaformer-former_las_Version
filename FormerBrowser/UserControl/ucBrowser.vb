Imports System.Text.RegularExpressions
Public Class ucBrowser
    Private _tp As TabPage

    Public Sub New(ByRef Tp As TabPage)

        _tp = Tp
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

    End Sub

    Private Sub txtUrl_Click(sender As Object, e As EventArgs) Handles txtUrl.Click
        txtUrl.SelectAll()
    End Sub

    Public Sub CercaConGoogle(textToSearch As String)
        Dim UrlInserito As String = "https://www.google.it/#q=" & textToSearch.Replace(" ", "+")
        Naviga(UrlInserito)
    End Sub

    Public Sub NavigaAlSito(textToSearch As String)
        Dim UrlInserito As String = textToSearch
        Naviga(UrlInserito)
    End Sub

    Private Sub txtUrl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUrl.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim UrlInserito As String = txtUrl.Text.ToLower

            Dim RegEx As Regex = New Regex("(^(ht|f)tp(s?)://)?([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$")
            Dim match As Match = RegEx.Match(UrlInserito)
            If Not match.Success Then

                'cerco su google
                'https://www.google.it/#q=diego+lunadei

                UrlInserito = "https://www.google.it/#q=" & UrlInserito.Replace(" ", "+")
            End If
            Naviga(UrlInserito)
        End If
    End Sub

    Private Sub Naviga(Url As String)
        webMain.Navigate(Url)
    End Sub

    Private Sub webMain_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles webMain.DocumentCompleted
        txtUrl.Text = webMain.Url.ToString
        Dim tit As String = webMain.Document.Title
        _tp.ToolTipText = tit
        If tit.Length > 20 Then
            tit = tit.Substring(0, 20) & "..."
        End If
        _tp.Text = tit

    End Sub

    Public ReadOnly Property Titolo As String
        Get
            Return webMain.Document.Title
        End Get
    End Property

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        If txtUrl.Text.Length Then
            webMain.Navigate(txtUrl.Text)
        End If
    End Sub

    Private Sub btnAvanti_Click(sender As Object, e As EventArgs) Handles btnAvanti.Click
        webMain.GoForward()
    End Sub

    Private Sub btnIndietro_Click(sender As Object, e As EventArgs) Handles btnIndietro.Click
        webMain.GoBack()
    End Sub

    Private Sub ucBrowser_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub ucBrowser_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub txtUrl_TextChanged(sender As Object, e As EventArgs) Handles txtUrl.TextChanged

    End Sub
End Class
