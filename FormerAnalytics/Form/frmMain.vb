Imports FormerLib
Imports System.IO
Imports System.Configuration
Imports FW = FormerDALWeb
Imports FormerConfig
Imports FormerBusinessLogic

Public Class frmMain

    Private ListaSessioni As List(Of SessioneWeb) = Nothing

    Private Sub btnCarica_Click(sender As Object, e As EventArgs) Handles btnCarica.Click

        ListaSessioni = EstraiDati(dtGiorno.Value)

        ListaSessioni.Sort(Function(x, y) y.TracceWeb.Count.CompareTo(x.TracceWeb.Count))

        tvwSessioni.Nodes.Clear()

        Dim Counter As Integer = 1
        For Each singsess In ListaSessioni
            Dim N As New TreeNode
            N.Text = Counter & " - " & singsess.Utente & " " & singsess.SessionId & " (Tr. " & singsess.TracceWeb.Count & ")"
            N.Name = singsess.SessionId
            tvwSessioni.Nodes.Add(N)
            Counter += 1
        Next

    End Sub

    Private Function EstraiKeywords() As List(Of KeywordResult)

        Dim ris As New List(Of KeywordResult)

        Dim Path As String = FormerPath.PathLog

        Dim d As New DirectoryInfo(Path)

        Dim CounterFileFatti As Integer = 0
        Dim CounterTotale As Integer = d.GetFiles("*.txt").Count

        For Each f As FileInfo In d.GetFiles("*.txt")
            CounterFileFatti += 1

            lblFileCorrente.Text = "(" & CounterFileFatti & " di " & CounterTotale & ") " & f.FullName

            Application.DoEvents()

            Dim BuffSingFile As String = String.Empty

            Using r As New StreamReader(f.FullName)

                BuffSingFile = r.ReadToEnd()

                Dim posiz As Integer = BuffSingFile.IndexOf("/cerca/")
                Dim PosizFine As Integer = 0
                While posiz <> -1

                    PosizFine = BuffSingFile.IndexOf(";", posiz)

                    Dim SingKeyword As String = BuffSingFile.Substring(posiz + 7, PosizFine - posiz - 7).Replace("-", " ")

                    If ris.FindAll(Function(x) x.Keyword.ToLower = SingKeyword.ToLower).Count Then
                        Dim x As KeywordResult = ris.Find(Function(y) y.Keyword.ToLower = SingKeyword.ToLower)

                        x.Hit += 1
                    Else
                        Dim x As New KeywordResult
                        x.Keyword = SingKeyword
                        x.Hit = 1

                        Dim l As IEnumerable(Of FW.IndiceRicerca) = FormerSearchEngine.Cerca(SingKeyword)

                        x.Risultati = l.Count

                        ris.Add(x)
                    End If

                    posiz = BuffSingFile.IndexOf("/cerca/", posiz + 1)

                End While

            End Using

        Next

        Return ris

    End Function

    Private Function EstraiDati(Giorno As Date,
                                Optional ListaSessioni As List(Of SessioneWeb) = Nothing) As List(Of SessioneWeb)
        Dim Sessioni As List(Of SessioneWeb) = Nothing
        If ListaSessioni Is Nothing Then
            Sessioni = New List(Of SessioneWeb)
        Else
            Sessioni = ListaSessioni
        End If
        Try

            'carico dati dal log 
            Dim GiornoStr As String = Giorno.ToString("dd/MM/yyyy")
            Dim Path As String = FormerPath.PathLog & Giorno.ToString("yyyyMMdd") & ".txt"
            Dim BufferLog As String = String.Empty
            If FileIO.FileSystem.FileExists(Path) Then
                Using r As New StreamReader(Path)
                    BufferLog = r.ReadToEnd
                End Using

                Dim Righe() As String = BufferLog.Split(ControlChars.NewLine)

                For Each Riga As String In Righe

                    Dim Campi() As String = Riga.Split(";")
                    If Campi.Count > 5 Then
                        Dim IdSessione As String = Campi(2)
                        Dim IpSessione As String = Campi(1)
                        Dim UserAgentSessione As String = String.Empty
                        Try
                            For i As Integer = 5 To Campi.Count - 1
                                UserAgentSessione &= Campi(i)
                            Next
                        Catch ex As Exception

                        End Try

                        Dim SessioneLavorata As SessioneWeb = Nothing
                        SessioneLavorata = Sessioni.Find(Function(x) x.SessionId = IdSessione)

                        If SessioneLavorata Is Nothing Then
                            SessioneLavorata = New SessioneWeb(IdSessione)
                            SessioneLavorata.Ip = IpSessione
                            SessioneLavorata.UserAgent = UserAgentSessione
                            Sessioni.Add(SessioneLavorata)
                        End If

                        Dim T As New TracciaWeb
                        T.Quando = GiornoStr & " " & Campi(0)
                        T.UrlTarget = Campi(4)
                        T.IdSito = Campi(3)

                        SessioneLavorata.TracceWeb.Add(T)
                    End If
                Next
            End If


            'MessageBox.Show("Sessioni trovate:" & Sessioni.Count)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return Sessioni

    End Function

    Private Sub tvwSessioni_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwSessioni.AfterSelect

        Dim N As TreeNode = e.Node

        Dim s As SessioneWeb = ListaSessioni.Find(Function(x) x.SessionId = N.Name)

        lblInfoSess.Text = "Utente: " & s.Utente & " Session: " & s.SessionId & " ip: " & s.Ip & " useragent: " & s.UserAgent

        dgTrace.AutoGenerateColumns = False
        dgTrace.DataSource = s.TracceWeb

    End Sub

    Private Sub btnAggiornaGoto_Click(sender As Object, e As EventArgs) Handles btnAggiornaGoto.Click

        If MessageBox.Show("Confermi il caricamento dei goto? Sarà effettuata una connessione al server", "GoTo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim l As New List(Of FW.TraceSource)
            Using mgr As New FW.TraceSourceDAO
                l = mgr.GetAll()

                dgGoto.AutoGenerateColumns = False
                dgGoto.DataSource = l

            End Using
        End If

    End Sub

    Private Sub btnApriUrl_Click(sender As Object, e As EventArgs) Handles btnApriUrl.Click

        If dgGoto.SelectedRows.Count Then
            Dim riga As DataGridViewRow = dgGoto.SelectedRows(0)
            Dim traccia As FW.TraceSource = riga.DataBoundItem

            FormerLib.FormerHelper.Web.OpenWithChrome("http://www.tipografiaformer.it" & traccia.TargetUrl)
        End If

    End Sub

    Private Sub dgGoto_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgGoto.ColumnHeaderMouseClick

        'OrdinatoreLista(Of FW.TraceSource).OrdinaLista(sender, e)

    End Sub

    Private _SorgenteKeywords As List(Of KeywordResult) = Nothing

    Private Sub btnEstraiKeywords_Click(sender As Object, e As EventArgs) Handles btnEstraiKeywords.Click

        Cursor = Cursors.WaitCursor

        If _SorgenteKeywords Is Nothing Then
            _SorgenteKeywords = EstraiKeywords()
        End If

        Dim l As List(Of KeywordResult) = _SorgenteKeywords

        If chkSoloSenzaRis.Checked Then
            l = l.FindAll(Function(x) x.Risultati = 0)
        End If

        l.Sort(AddressOf Comparer)

        dgKeyword.DataSource = l
        dgKeyword.AutoGenerateColumns = False

        Cursor = Cursors.Default

    End Sub

    Private Function Comparer(ByVal x As KeywordResult, ByVal y As KeywordResult) As Integer

        Dim result As Integer = y.Hit.CompareTo(x.Hit)
        If result = 0 Then result = x.Keyword.CompareTo(y.Keyword)
        Return result

    End Function

    Private Sub btnElaboraStat_Click(sender As Object, e As EventArgs) Handles btnElaboraStat.Click

        If MessageBox.Show("Confermi l'elaborazione delle statistiche?", "Statistiche", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim Path As String = FormerPath.PathLog

            Dim d As New DirectoryInfo(Path)

            Dim CounterFileFatti As Integer = 0
            Dim CounterTotale As Integer = d.GetFiles("*.txt").Count

            Dim ris As New Dictionary(Of String, Integer)

            For Each f As FileInfo In d.GetFiles("*.txt")
                CounterFileFatti += 1

                lblFileCorrente.Text = "(" & CounterFileFatti & " di " & CounterTotale & ") " & f.FullName

                Application.DoEvents()

                Dim BuffSingFile As String = String.Empty

                Using r As New StreamReader(f.FullName)

                    BuffSingFile = r.ReadToEnd()

                    Dim Righe As String() = BuffSingFile.Split(ControlChars.NewLine)

                    For Each riga As String In Righe
                        Dim Valori As String() = riga.Split(";")
                        If Valori.Length > 3 Then
                            Dim UserAgent As String = Valori(Valori.Length - 2)
                            If ris.ContainsKey(UserAgent) Then
                                ris(UserAgent) += 1
                            Else
                                ris.Add(UserAgent, 1)
                            End If
                        End If
                    Next

                End Using

            Next

            For Each singchiave In ris
                txtElabora.Text &= singchiave.Value & " - " & singchiave.Key
            Next

        End If

    End Sub
End Class
