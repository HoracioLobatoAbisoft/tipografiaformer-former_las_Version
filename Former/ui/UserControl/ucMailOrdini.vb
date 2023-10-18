Imports System.Text.RegularExpressions
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerPrinter

Public Class ucMailOrdini
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        dtDataDal.Value = Now.AddMonths(-1)

    End Sub

    Public Property IdRub As Integer = 0

    Public Function CounterDaLavorare() As Integer
        Dim ris As Integer = 0

        Using mgr As New PreventiviMailDAO

            Dim l As List(Of PreventivoMail) = mgr.FindAll(New LUNA.LunaSearchParameter("Stato", enStatoPreventivoMail.DaLavorare),
                                                           New LUNA.LunaSearchParameter("IdMailRif", 0),
                                                           New LUNA.LunaSearchParameter("TipoMail", enTipoMail.Ordine))
            ris = l.Count
        End Using

        Return ris
    End Function

    Public Sub Carica()

    End Sub

    Private Function CaricaDati() As Integer

        Dim ris As Integer = 0

        Cursor = Cursors.WaitCursor

        tvwMail.Nodes.Clear()

        Dim NodoDaLavorare As TreeNode = tvwMail.Nodes.Add("DL", "Da Lavorare", 2, 2)
        'Dim NodoLavorate As TreeNode = tvwMail.Nodes.Add("LV", "Lavorate", 3, 3)
        'Dim NodoCestino As TreeNode = tvwMail.Nodes.Add("CS", "Cestino", 5, 5)

        Dim CountDaLavorare As Integer = 0
        Dim CountLavorate As Integer = 0

        Using mgr As New PreventiviMailDAO

            'Dim l As List(Of PreventivoMail) = mgr.FindAll("DataRif", New LUNA.LunaSearchParameter("Stato", enStatoPreventivoMail.Eliminata, "<>"),
            '                                                        New LUNA.LunaSearchParameter("IdMailRif", 0))
            Dim l As List(Of PreventivoMail) = mgr.ElencoMail(txtCerca.Text.Trim,
                                                              IIf(chkDataDal.Checked, dtDataDal.Value, Nothing),
                                                              IIf(chkDataAl.Checked, dtDataAl.Value, Nothing),
                                                              IdRub,
                                                              enTipoMail.Ordine,
                                                              enStatoPreventivoMail.DaLavorare)

            l.Sort(Function(x, y) y.DataOrdinamento.CompareTo(x.DataOrdinamento))
            Dim EspandiPrimoMese As Boolean = False
            For Each singMail As PreventivoMail In l

                Dim Riassunto As String = "" 'singMail.DataRif.ToString("dd/MM/yyyy HH:mm.ss")

                If singMail.IdRub Then
                    Riassunto = singMail.VoceRubrica.RagSocNome & " "
                End If

                Riassunto &= "<" & singMail.Mittente & ">"
                'Riassunto &= "'" & singMail.Titolo & "'"

                Dim lFigli As List(Of PreventivoMail) = singMail.ListaRisposte

                Dim NodoMail As TreeNode = Nothing

                If singMail.Stato = enStatoPreventivoMail.DaLavorare Then

                    Riassunto = "(" & lFigli.Count & ") " & Riassunto
                    Riassunto &= " '" & singMail.Titolo & "'"

                    Dim KeyM As String = "C" & singMail.DataOrdinamento.ToString("MMyyyy")
                    Dim KeyG As String = "G" & singMail.DataOrdinamento.ToString("ddMMyyyy")
                    Dim NodoMese As TreeNode = Nothing
                    If NodoDaLavorare.Nodes.Find(KeyM, False).Count Then
                        NodoMese = NodoDaLavorare.Nodes.Find(KeyM, False)(0)
                    Else
                        NodoMese = NodoDaLavorare.Nodes.Add(KeyM, singMail.DataOrdinamento.ToString("MMMM yyyy"), 6, 6)
                    End If

                    Dim NodoData As TreeNode = Nothing
                    If NodoMese.Nodes.Find(KeyG, False).Count Then
                        NodoData = NodoMese.Nodes.Find(KeyG, False)(0)
                    End If
                    Dim IdGiornoImg As Integer = 6 + singMail.DataOrdinamento.Day
                    If NodoData Is Nothing Then
                        NodoData = NodoMese.Nodes.Add(KeyG, singMail.DataOrdinamento.ToString("dd/MM/yyyy"), IdGiornoImg, IdGiornoImg)
                    End If

                    NodoMail = NodoData.Nodes.Add("M" & singMail.IdMailPreventivo, Riassunto, 0, 0)

                    If singMail.IdRub = 0 Then
                        NodoMail.BackColor = Color.Orange
                    End If

                    If EspandiPrimoMese = False Then
                        NodoMese.ExpandAll()
                        EspandiPrimoMese = True
                    End If

                    'NodoData.Expand()
                    ris += 1
                    CountDaLavorare = ris

                    'ElseIf singMail.Stato = enStatoPreventivoMail.Lavorata Then
                    '    Dim KeyM As String = "C" & singMail.DataOrdinamento.ToString("MMyyyy")
                    '    Dim KeyG As String = "G" & singMail.DataOrdinamento.ToString("ddMMyyyy")
                    '    Dim NodoMese As TreeNode = Nothing
                    '    If NodoLavorate.Nodes.Find(KeyM, False).Count Then
                    '        NodoMese = NodoLavorate.Nodes.Find(KeyM, False)(0)
                    '    Else
                    '        NodoMese = NodoLavorate.Nodes.Add(KeyM, singMail.DataOrdinamento.ToString("MMMM yyyy"), 6, 6)
                    '    End If

                    '    Dim NodoData As TreeNode = Nothing
                    '    If NodoMese.Nodes.Find(KeyG, False).Count Then
                    '        NodoData = NodoMese.Nodes.Find(KeyG, False)(0)
                    '    End If
                    '    Dim IdGiornoImg As Integer = 6 + singMail.DataOrdinamento.Day
                    '    If NodoData Is Nothing Then
                    '        NodoData = NodoMese.Nodes.Add(KeyG, singMail.DataOrdinamento.ToString("dd/MM/yyyy"), IdGiornoImg, IdGiornoImg)
                    '    End If
                    '    Riassunto = "(" & lFigli.Count & ") " & singMail.DataRif.ToString("dd/MM/yyyy HH:mm.ss") & " " & Riassunto & " '" & singMail.Titolo & "'"
                    '    NodoMail = NodoData.Nodes.Add("M" & singMail.IdMailPreventivo, Riassunto, 0, 0)

                    '    If singMail.IdRub = 0 Then
                    '        NodoMail.BackColor = Color.Orange
                    '    End If

                    '    CountLavorate += 1
                    NodoMail.Tag = singMail

                    If singMail.Letto = enSiNo.No Then
                        NodoMail.NodeFont = New Font(tvwMail.Font, FontStyle.Bold)
                    End If

                    For Each singMailF As PreventivoMail In lFigli
                        Dim IdIco As Integer = 0

                        If singMailF.IdUtFormer Then
                            IdIco = 1
                        End If

                        Dim RiassuntoF As String = singMailF.DataRif.ToString("dd/MM/yyyy HH:mm.ss")

                        If singMailF.IdRub Then
                            RiassuntoF &= " " & singMailF.VoceRubrica.RagSocNome
                        End If

                        RiassuntoF &= " <" & singMailF.Mittente & "> "

                        RiassuntoF &= "'" & singMailF.Titolo & "'"

                        Dim NodoMailF As TreeNode = NodoMail.Nodes.Add("M" & singMailF.IdMailPreventivo, RiassuntoF, IdIco, IdIco)
                        'NodoMailF.EnsureVisible()

                        NodoMailF.Tag = singMailF
                        If singMailF.Letto = enSiNo.No Then
                            NodoMailF.NodeFont = New Font(tvwMail.Font, FontStyle.Bold)
                        End If
                    Next

                    If lFigli.FindAll(Function(x) x.Letto = enSiNo.No).Count Then NodoMail.Expand()
                End If





            Next

        End Using

        NodoDaLavorare.Text = "Da Lavorare (" & CountDaLavorare & ")"
        'NodoLavorate.Text = "Lavorate (" & CountLavorate & ")"

        If txtCerca.Text.Trim.Length Then
            NodoDaLavorare.ExpandAll()
            'NodoLavorate.ExpandAll()
        Else
            NodoDaLavorare.Expand()
        End If

        'caricare cestino



        Cursor = Cursors.Default

        Return ris

    End Function

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked

        CaricaDati()

    End Sub

    Private Sub tvwMail_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwMail.AfterSelect
        Try
            Dim mail As PreventivoMail = e.Node.Tag

            UcMailPreview.Carica(mail)

            'lblTitolo.Text = mail.DataRif & " - " & mail.Titolo
            'txtPreview.Text = mail.Testo

            'If mail.IdUtFormer <> 0 And mail.IdMailRif <> 0 Then
            '    txtPreview.Text &= ControlChars.NewLine & ControlChars.NewLine & ControlChars.NewLine &
            '        "***************************************************************************************" & ControlChars.NewLine &
            '        "In risposta a:" & ControlChars.NewLine &
            '        "***************************************************************************************" & ControlChars.NewLine & ControlChars.NewLine &
            '        mail.MailRif.Testo
            'End If

            ''If mail.Letto = enSiNo.No Then
            ''    mail.Letto = enSiNo.Si
            ''    mail.Save()
            ''    e.Node.NodeFont = New Font(e.Node.NodeFont, FontStyle.Regular)
            ''End If

            'If mail.IdUtFormer Then
            '    Using U As New Utente
            '        U.Read(mail.IdUtFormer)
            '        lblMitt.Text = "Risposta di " & U.Login
            '    End Using
            'Else
            '    If mail.VoceRubrica Is Nothing Then
            '        lblMitt.Text = "Inviata da <" & mail.Mittente & ">"
            '    Else
            '        lblMitt.Text = "Inviata da " & mail.VoceRubrica.RagSocNome & " <" & mail.Mittente & ">"
            '    End If
            'End If

            'lvwAllegati.Items.Clear()
            'For Each alle As AttachPreventivoMail In mail.Allegati
            '    Dim lv As New ListViewItem
            '    lv.ImageIndex = 4
            '    lv.Text = alle.NomeFile
            '    lv.Tag = alle.Path

            '    lvwAllegati.Items.Add(lv)
            'Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lvwAllegati_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CreaOrdine()

        Dim selNode As TreeNode = tvwMail.SelectedNode

        If selNode Is Nothing OrElse selNode.Name.StartsWith("M") = False Then
            MessageBox.Show("Seleziona un email per rispondere")
        Else
            Dim mailMsg As PreventivoMail = selNode.Tag

            If mailMsg.IdRub Then
                ParentFormEx.Sottofondo()
                Dim Ris As Integer = 0
                Using f As New frmOrdineCreaOnline
                    Ris = f.Carica(mailMsg.IdMailPreventivo)
                    If Ris Then
                        CaricaDati()
                    End If
                End Using

                ParentFormEx.Sottofondo()
            Else
                MessageBox.Show("Si possono creare ordini solo su mail già assegnate a un cliente. Assegnare la mail a un cliente e riprovare")
            End If
        End If

    End Sub

    Private Sub lnkRispondi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        CreaOrdine()

    End Sub

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        CaricaDati()

    End Sub

    Private Sub txtCerca_TextChanged(sender As Object, e As EventArgs) Handles txtCerca.TextChanged

    End Sub

    Private Sub txtCerca_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCerca.KeyDown
        If e.KeyCode = Keys.Enter Then
            CaricaDati()
        End If
    End Sub

    'Private Sub lnkScarica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkScarica.LinkClicked
    '    ScaricaPreventiviMail()
    'End Sub

    'Private Sub ScaricaPreventiviMail()

    '    Try
    '        Using p As New OpenPop.Pop3.Pop3Client

    '            p.Connect(FConfiguration.PreventiviMail.ServerPOP, 995, True)

    '            p.Authenticate(FConfiguration.PreventiviMail.Email,
    '                           FConfiguration.PreventiviMail.Password,
    '                           OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword)

    '            Dim count As Integer = p.GetMessageCount()

    '            If count Then
    '                For i As Integer = count To 1 Step -1

    '                    Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()

    '                        Try
    '                            Dim msg As OpenPop.Mime.Message = p.GetMessage(i)
    '                            Dim msgMail As MailMessage = msg.ToMailMessage

    '                            Dim body As String = msgMail.Body

    '                            If msgMail.IsBodyHtml Then

    '                                Dim bodyParsed As String = String.Empty

    '                                If msgMail.AlternateViews.Count Then
    '                                    For Each a As AlternateView In msgMail.AlternateViews
    '                                        If a.ContentType.MediaType = "text/plain" Then
    '                                            Dim contenuto As Stream = a.ContentStream
    '                                            Dim byteBuffer(contenuto.Length) As Byte
    '                                            bodyParsed = Encoding.ASCII.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
    '                                        End If
    '                                    Next
    '                                End If

    '                                If bodyParsed.Length = 0 Then
    '                                    body = FormerLib.FormerHelper.HTML.EliminaTag(msgMail.Body)
    '                                Else
    '                                    body = bodyParsed
    '                                End If

    '                            End If

    '                            Dim l As New List(Of AttachPreventivoMail)

    '                            If msgMail.Attachments.Count Then
    '                                For Each a As Attachment In msgMail.Attachments

    '                                    Dim path As String = FormerPath.PathAttachMailPrev & a.Name

    '                                    Using fs As New FileStream(path, FileMode.Create)

    '                                        a.ContentStream.CopyTo(fs)

    '                                    End Using

    '                                    Dim mAttach As New AttachPreventivoMail
    '                                    mAttach.NomeFile = a.Name
    '                                    mAttach.Path = path

    '                                    l.Add(mAttach)

    '                                Next
    '                            End If

    '                            'cerco un riferimento a un altra mail

    '                            Dim IdMailRif As Integer = 0
    '                            Dim ris As Match = Regex.Match(body, "FPGUID{.*?}")
    '                            Dim GuidTrovato As String = String.Empty

    '                            If ris.Success Then
    '                                GuidTrovato = ris.Value

    '                                GuidTrovato = GuidTrovato.Substring(GuidTrovato.IndexOf("{") + 1)
    '                                GuidTrovato = GuidTrovato.Substring(0, GuidTrovato.Length - 1)

    '                                Using mgr As New PreventiviMailDAO
    '                                    Dim lP As List(Of PreventivoMail) = mgr.FindAll("DataRif",
    '                                                                                    New LUNA.LunaSearchParameter("GuidMail", GuidTrovato))

    '                                    If lP.Count Then
    '                                        IdMailRif = lP.Last.IdMailPreventivo
    '                                    End If

    '                                End Using

    '                            End If

    '                            Dim Mittente As String = msgMail.From.Address
    '                            Dim Titolo As String = msgMail.Subject

    '                            'qui devo vedere se e' inoltrata
    '                            Dim risInoltro As Match = Regex.Match(Mittente, "@tipografiaformer.")

    '                            'Dim risInoltro As Match = Regex.Match(Mittente, "tipografia.duca@gmail.")

    '                            If risInoltro.Success Or Mittente = "tipografia.duca@gmail.com" Then
    '                                'qui devo cercare l'inoltro

    '                                Dim cercaMail As Match = Regex.Match(body, "From: \w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")

    '                                If cercaMail.Success Then
    '                                    Dim MittTemp As String = cercaMail.Value.Substring(cercaMail.Value.IndexOf(":") + 1).Trim
    '                                    If FormerLib.FormerHelper.Mail.IsValidEmailAddress(MittTemp) Then
    '                                        Mittente = MittTemp
    '                                    End If
    '                                End If

    '                            End If

    '                            If GuidTrovato.Length = 0 Then

    '                                Dim x As Guid = Guid.NewGuid
    '                                GuidTrovato = x.ToString

    '                            End If

    '                            Dim DataRif As Date = Now

    '                            Try

    '                                Dim dataTemp As String = msg.Headers.Date

    '                                Dim dataRifTemp As Date = CDate(dataTemp)

    '                                DataRif = dataRifTemp


    '                            Catch ex As Exception

    '                            End Try

    '                            Using mp As New PreventivoMail

    '                                mp.GuidMail = GuidTrovato
    '                                mp.DataRif = DataRif
    '                                mp.Mittente = Mittente
    '                                mp.Titolo = Titolo
    '                                mp.Testo = body
    '                                mp.Stato = enStatoPreventivoMail.DaLavorare
    '                                mp.IdMailRif = IdMailRif

    '                                Using mgrR As New VociRubricaDAO
    '                                    Dim lR As List(Of VoceRubrica) = mgrR.FindAll(New LUNA.LunaSearchParameter("email", mp.Mittente))
    '                                    If lR.Count Then
    '                                        Dim vr As VoceRubrica = lR(0)
    '                                        mp.IdRub = vr.IdRub
    '                                    Else
    '                                        'qui devo provare a cercare tra le mail in arrivo se per caso la stessa mail è
    '                                        'stata assegnata gia a un cliente
    '                                        Using mgrM As New PreventiviMailDAO
    '                                            Dim IdRubTrovato As Integer = mgrM.GetIdRubFromStorico(Mittente)
    '                                            If IdRubTrovato Then
    '                                                mp.IdRub = IdRubTrovato
    '                                            End If
    '                                        End Using
    '                                    End If
    '                                End Using

    '                                tb.TransactionBegin()

    '                                mp.Save()

    '                                For Each singA As AttachPreventivoMail In l

    '                                    Dim NuovoPath As String = singA.Path.Replace(singA.NomeFile, mp.IdMailPreventivo & "_" & singA.NomeFile)

    '                                    Rename(singA.Path, NuovoPath)

    '                                    singA.Path = NuovoPath
    '                                    singA.IdMailPreventivo = mp.IdMailPreventivo
    '                                    singA.Save()
    '                                Next

    '                                tb.TransactionCommit()

    '                            End Using

    '                            'RIATTIVARE PRIMA DI METTERE IN PRODUZIONE
    '                            'qui cancello il messaggio
    '                            p.DeleteMessage(i)

    '                            If ris.Success = False Then
    '                                Dim TestoRisposta As String = String.Empty

    '                                TestoRisposta = "Salve, <br><br>"
    '                                TestoRisposta &= "la sua richiesta di preventivo <b>'" & Titolo & "'</b> è stata presa in carico e riceverà una risposta entro 24/48 ore.<br><br>"
    '                                TestoRisposta &= "<br><br><br><font face=""courier"">*********************************************************************************************************<br>"
    '                                TestoRisposta &= "IN CASO DI RISPOSTA A QUESTA EMAIL NON RIMUOVERE QUESTA RIGA FPGUID{$}<br>".Replace("$", GuidTrovato) & ControlChars.NewLine
    '                                TestoRisposta &= "*********************************************************************************************************</font>"

    '                                Try
    '                                    'RIATTIVARE PRIMA DI METTERE IN PRODUZIONE
    '                                    'qui rispondo alla mail con una mail automatica di presa in carico
    '                                    'FormerLib.FormerHelper.Mail.InviaMail("La sua richiesta di preventivo è stata presa in carico", TestoRisposta, Mittente, FConfiguration.PreventiviMail.EmailSender,,,,,, False)
    '                                Catch ex As Exception

    '                                End Try
    '                            Else
    '                                'qui devo rimettere da lavorare la discussione iniziale
    '                                Using mgr As New PreventiviMailDAO
    '                                    Dim lP As List(Of PreventivoMail) = mgr.FindAll(New LUNA.LunaSearchParameter("GuidMail", GuidTrovato),
    '                                                                                   New LUNA.LunaSearchParameter("IdMailRif", 0))

    '                                    Using singmail As PreventivoMail = lP(0)
    '                                        singmail.Stato = enStatoPreventivoMail.DaLavorare
    '                                        singmail.Save()
    '                                    End Using

    '                                End Using
    '                            End If

    '                        Catch ex As Exception
    '                            tb.TransactionRollBack()
    '                            'log
    '                        End Try

    '                    End Using

    '                Next
    '            End If

    '            p.Disconnect()

    '            MessageBox.Show("Scaricate " & count & " mail")

    '            If count Then FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_Notifica, "Scaricate " & count & " nuove email.", FormerUDP.DestUDP_Admin)

    '        End Using
    '    Catch ex As Exception
    '        'logme
    '    End Try

    'End Sub

    Private Sub tvwMail_MouseUp(sender As Object, e As MouseEventArgs) Handles tvwMail.MouseUp
        If e.Button = MouseButtons.Right Then

            ' Point where mouse is clicked
            Dim p As Point = New Point(e.X, e.Y)

            ' Go to the node that the user clicked
            Dim node As TreeNode = tvwMail.GetNodeAt(p)
            If Not node Is Nothing Then

                tvwMail.SelectedNode = node

                If node.Name.StartsWith("M") Then

                    Dim M As PreventivoMail = node.Tag

                    If M.IdUtFormer = 0 Then
                        If M.IdRub = 0 Then
                            AssegnaAClienteToolStripMenuItem.Enabled = True
                        Else
                            AssegnaAClienteToolStripMenuItem.Enabled = False
                        End If
                    Else
                        AssegnaAClienteToolStripMenuItem.Enabled = False
                    End If

                    If M.IdMailRif Then
                        M = node.Parent.Tag
                    End If

                    'qui provo a dare suggerimenti se possibile
                    For i As Integer = (AssegnaAClienteToolStripMenuItem.DropDownItems.Count - 1) To 0 Step -1
                        Dim mts As ToolStripItem = AssegnaAClienteToolStripMenuItem.DropDownItems(i)
                        If Not mts.Tag Is Nothing Then
                            If mts.Tag.ToString.StartsWith("R") Then
                                AssegnaAClienteToolStripMenuItem.DropDownItems.RemoveAt(i)
                            End If
                        End If
                    Next

                    Dim Dominio As String = String.Empty
                    Dominio = M.Mittente.Substring(M.Mittente.IndexOf("@"))

                    Using mgr As New VociRubricaDAO
                        Dim l As List(Of VoceRubrica) = mgr.FindAll("RagSoc, Cognome",
                                                                New LUNA.LunaSearchParameter("Email", "%" & Dominio, " like "))

                        If l.Count = 1 Then
                            Dim singV As VoceRubrica = l(0)
                            Dim t As New ToolStripMenuItem
                            t.Text = singV.RagSocNome
                            t.Tag = "R" & singV.IdRub

                            AddHandler t.Click, AddressOf CliccaAssegna
                            AssegnaAClienteToolStripMenuItem.DropDownItems.Add(t)
                        End If

                    End Using

                    mnuPrev.Show(tvwMail, p)

                End If

            End If
        End If
    End Sub

    Private Sub EliminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminaToolStripMenuItem.Click

        If Not tvwMail.SelectedNode Is Nothing Then

            Dim Messaggio As String = "Confermi l' eliminazione della mail selezionata?"

            Dim m As PreventivoMail = tvwMail.SelectedNode.Tag

            If m.IdMailRif = 0 Then
                Messaggio = "Confermi l' eliminazione dell' intera conversazione?"
            End If

            If MessageBox.Show(Messaggio, "Eliminazione Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'qui devo eliminare la mail e tutte le risposte in caso sia una iniziale

                If m.IdMailRif = 0 And m.ListaRisposte.Count = 0 Then
                    'qui lo cancello fisicamente 
                    Using mgr As New PreventiviMailDAO
                        mgr.Delete(m.IdMailPreventivo)
                    End Using
                Else
                    Using mgr As New PreventiviMailDAO
                        If m.IdMailRif Then
                            m.Stato = enStatoPreventivoMail.Eliminata
                            m.Save()
                        Else
                            mgr.DeleteByGuid(m.GuidMail)
                        End If
                    End Using

                    RaiseEvent CambiamentoStatoMail(-1)
                End If

                CaricaDati()

            End If

        End If

    End Sub

    Private Sub SegnaDaLeggereToolStripMenuItem_Click(sender As Object, e As EventArgs)

        If Not tvwMail.SelectedNode Is Nothing Then

            Dim m As PreventivoMail = tvwMail.SelectedNode.Tag

            m.Letto = enSiNo.No
            m.Save()

            tvwMail.SelectedNode.NodeFont = New Font(tvwMail.Font, FontStyle.Bold)

        End If

    End Sub

    Private Sub SegnaComeLavorataToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim NodoRif As TreeNode = tvwMail.SelectedNode

        If Not NodoRif Is Nothing Then

            Dim m As PreventivoMail = NodoRif.Tag

            If m.IdMailRif Then
                NodoRif = NodoRif.Parent
                m = NodoRif.Tag
            End If

            m.Stato = enStatoPreventivoMail.Lavorata
            m.Letto = enSiNo.Si
            m.Save()

            For Each s As PreventivoMail In m.ListaRisposte
                m.Letto = enSiNo.Si
                m.Save()
            Next

            CaricaDati()

            'Dim tn As Integer = tvwMail.Nodes.Item("LV").Nodes.Add(NodoRif.Clone)
            'tvwMail.Nodes.Item("DL").Nodes.RemoveByKey(NodoRif.Name)
            'tvwMail.Nodes("LV").Nodes(tn).EnsureVisible()

            RaiseEvent CambiamentoStatoMail(-1)

        End If

    End Sub

    Public Event CambiamentoStatoMail(Conteggio As Integer)

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

        Dim NodoRif As TreeNode = tvwMail.SelectedNode

        If Not NodoRif Is Nothing Then

            Dim m As PreventivoMail = NodoRif.Tag

            If m.IdMailRif Then
                NodoRif = NodoRif.Parent
                m = NodoRif.Tag
            End If

            m.Stato = enStatoPreventivoMail.DaLavorare
            m.Save()

            CaricaDati()

            'Dim tn As Integer = tvwMail.Nodes.Item("DL").Nodes.Add(NodoRif.Clone)
            'tvwMail.Nodes.Item("LV").Nodes.RemoveByKey(NodoRif.Name)
            'tvwMail.Nodes("DL").Nodes(tn).EnsureVisible()

            RaiseEvent CambiamentoStatoMail(-1)

        End If

    End Sub

    Private Sub RiapriToolStripmenu_Click(sender As Object, e As EventArgs) Handles RiapriToolStripmenu.Click

        CreaOrdine()

    End Sub

    Private Sub tvwMail_MouseDown(sender As Object, e As MouseEventArgs) Handles tvwMail.MouseDown
        SDragStart(sender, e)

    End Sub

    Private Sub tvwMail_DragOver(sender As Object, e As DragEventArgs) Handles tvwMail.DragOver
        SDragOver(sender, e)

    End Sub

    Private Sub tvwMail_DragDrop(sender As Object, e As DragEventArgs) Handles tvwMail.DragDrop
        SDragDrop(sender, e)
    End Sub

    Private Sub SDragStart(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Dim tree As TreeView = CType(sender, TreeView)

                Dim node As TreeNode
                node = tree.GetNodeAt(e.X, e.Y)

                tree.SelectedNode = node
                If Not node Is Nothing Then
                    If node.Name.StartsWith("M") Then
                        Dim mail As PreventivoMail = node.Tag
                        If mail.IdMailRif = 0 AndAlso mail.ListaRisposte.Count = 0 Then
                            tree.DoDragDrop(node, DragDropEffects.Move)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SDragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim tree As TreeView = CType(sender, TreeView)
        e.Effect = DragDropEffects.None

        If Not e.Data.GetData(GetType(TreeNode)) Is Nothing Then

            'Dim pt As New Point(e.X, e.Y)

            'pt = tree.PointToClient(pt)

            'Dim node As TreeNode = tree.GetNodeAt(pt)

            'If Not node Is Nothing Then

            e.Effect = DragDropEffects.Move

            'tree.SelectedNode = node

            'End If

        End If

    End Sub

    Private Sub SDragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs)

        'qui devo vedere se si tratta di una mail e se posso agganciarla (solo mail idmailrif =0 )
        Dim O As TreeNode = e.Data.GetData(GetType(TreeNode))

        Dim m As PreventivoMail = O.Tag

        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))

        Dim NodoDest As TreeNode = tvwMail.GetNodeAt(pt)

        If Not NodoDest Is Nothing AndAlso NodoDest.Name.StartsWith("M") Then

            If O.Name <> NodoDest.Name Then
                Dim mDest As PreventivoMail = NodoDest.Tag

                If mDest.IdMailRif Then
                    mDest = NodoDest.Parent.Tag
                End If

                If MessageBox.Show("Confermi l'accorpamento della mail '" & m.Titolo & "' nella conversazione '" & mDest.Titolo & "'?", "Accorpa conversazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    m.IdMailRif = mDest.IdMailPreventivo
                    m.GuidMail = mDest.GuidMail
                    m.Save()
                    CaricaDati()
                End If
            End If

        End If

    End Sub

    Private Sub CercaCliMenu()
        If txtCercaCli.Text.Trim.Length > 3 Then
            Try
                For i As Integer = (AssegnaAClienteToolStripMenuItem.DropDownItems.Count - 1) To 0 Step -1
                    Dim m As ToolStripItem = AssegnaAClienteToolStripMenuItem.DropDownItems(i)
                    If Not m.Tag Is Nothing Then
                        If m.Tag.ToString.StartsWith("R") Then
                            AssegnaAClienteToolStripMenuItem.DropDownItems.RemoveAt(i)
                        End If
                    End If
                Next

                'For Each singMenu As ToolStripItem In AssegnaAClienteToolStripMenuItem.DropDownItems
                '    If Not singMenu.Tag Is Nothing Then
                '        If singMenu.Tag.ToString.StartsWith("R") Then
                '            AssegnaAClienteToolStripMenuItem.DropDownItems.RemoveByKey(singMenu.Name)
                '        End If
                '    End If
                'Next

                Using mgr As New VociRubricaDAO
                    Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "RagSoc, Cognome"},
                                                                New LUNA.LunaSearchParameter(LFM.VoceRubrica.RagSoc, "%" & txtCercaCli.Text.Trim & "%", " like "),
                                                                New LUNA.LunaSearchParameter(LFM.VoceRubrica.Cognome, "%" & txtCercaCli.Text.Trim & "%", " like ", LUNA.enLogicOperator.enOR))

                    For Each singV As VoceRubrica In l
                        Dim t As New ToolStripMenuItem
                        t.Text = singV.RagSocNome
                        t.Tag = "R" & singV.IdRub

                        AddHandler t.Click, AddressOf CliccaAssegna
                        AssegnaAClienteToolStripMenuItem.DropDownItems.Add(t)
                    Next

                End Using
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtCercaCli_TextChanged(sender As Object, e As EventArgs) Handles txtCercaCli.TextChanged

        'If sender.focused Then
        '    CercaCliMenu()
        'End If

    End Sub

    Private Sub CliccaAssegna(sender As Object, e As EventArgs)

        If Not tvwMail.SelectedNode Is Nothing Then
            Dim m As ToolStripItem = sender
            Dim Mittente As String = String.Empty

            Dim mail As PreventivoMail = tvwMail.SelectedNode.Tag
            Mittente = mail.Mittente

            Using R As New VoceRubrica
                Dim IdRub As Integer = 0
                IdRub = m.Tag.ToString.Substring(1)

                R.Read(IdRub)

                If MessageBox.Show("Confermi l'assegnazione di questa mail a '" & R.RagSocNome & "'?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    'assegno tutte le conversazioni a questa email 

                    Dim risInoltro As Match = Regex.Match(Mittente, "@tipografiaformer.")

                    'Dim risInoltro As Match = Regex.Match(Mittente, "tipografia.duca@gmail.")

                    If risInoltro.Success = True Or Mittente = "tipografia.duca@gmail.com" Then
                        mail.IdRub = IdRub
                        mail.Mittente = R.Email
                        mail.Save()
                    Else

                        Using mgr As New PreventiviMailDAO
                            mgr.AssegnaEmailaIdRub(Mittente, IdRub)
                        End Using

                        If mail.Mittente <> R.Email Then
                            If MessageBox.Show("Vuoi sostituire la mail originale della conversazione '" & mail.Mittente & "' con la mail di default del cliente scelto '" & R.Email & "'?", "Sostituzione email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                mail.IdRub = IdRub
                                mail.Mittente = R.Email
                                mail.Save()
                            End If
                        End If
                    End If

                    For i As Integer = (AssegnaAClienteToolStripMenuItem.DropDownItems.Count - 1) To 0 Step -1
                        Dim mts As ToolStripItem = AssegnaAClienteToolStripMenuItem.DropDownItems(i)
                        If Not mts.Tag Is Nothing Then
                            If mts.Tag.ToString.StartsWith("R") Then
                                AssegnaAClienteToolStripMenuItem.DropDownItems.RemoveAt(i)
                            End If
                        End If
                    Next

                    txtCercaCli.Text = String.Empty

                    CaricaDati()
                End If

            End Using
        End If

    End Sub

    Private Sub btnCercaAvanzata_Click(sender As Object, e As EventArgs) Handles btnCercaAvanzata.Click

        pnlCercaAvanzato.Visible = Not pnlCercaAvanzato.Visible

        If pnlCercaAvanzato.Visible = False Then
            chkDataAl.Checked = False
            chkDataDal.Checked = False
            btnCercaAvanzata.Text = "▼"
            'chkSoloConAllegati.Checked = False
        Else
            btnCercaAvanzata.Text = "▲"
        End If

    End Sub

    Private Sub StampaMail()
        If Not tvwMail.SelectedNode Is Nothing Then

            If MessageBox.Show("Confermi la stampa della mail selezionata?", "Stampa Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim m As PreventivoMail = tvwMail.SelectedNode.Tag

                Dim Prn As New myFPrinter

                Dim prin As New System.Windows.Forms.PrintDialog
                prin.ShowDialog()
                If prin.PrinterSettings.PrinterName.Length Then
                    Prn.PrinterName = prin.PrinterSettings.PrinterName
                    Prn.StampaPreventivoMail(m)
                End If

            End If

        End If
    End Sub

    Private Sub lnkScarica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkScarica.LinkClicked

        StampaMail()

    End Sub

    Private Sub lnkCerca_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        CaricaDati()

    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles StampaToolStripMenu.Click

        StampaMail()

    End Sub

    Private Sub txtCercaCli_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCercaCli.KeyDown
        If e.KeyCode = Keys.Enter Then
            CercaCliMenu()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click_2(sender As Object, e As EventArgs)

        If Not tvwMail.SelectedNode Is Nothing Then

            Dim m As PreventivoMail = tvwMail.SelectedNode.Tag

            m.Letto = enSiNo.Si
            m.Save()

            tvwMail.SelectedNode.NodeFont = New Font(tvwMail.Font, FontStyle.Bold)

        End If
    End Sub

    Private Sub txtCerca_GotFocus(sender As Object, e As EventArgs) Handles txtCerca.GotFocus
        toolTipHelp.Show("Inserisci il testo di ricerca e premi INVIO", txtCerca)
    End Sub

    Private Sub toolStripDuplica_Click(sender As Object, e As EventArgs) Handles toolStripDuplica.Click


        Dim selNode As TreeNode = tvwMail.SelectedNode

        If selNode Is Nothing OrElse selNode.Name.StartsWith("M") = False Then
            MessageBox.Show("Seleziona un email per rispondere")
        Else
            Dim mailMsg As PreventivoMail = selNode.Tag

            If MessageBox.Show("Confermi la duplicazione della mail selezionata? Ti verrà chiesto di inserire un nuovo titolo per riconoscerla dall'originale", "Duplica Email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim NuovoTitolo As String = mailMsg.Titolo

                NuovoTitolo = InputBox("Inserisci il nuovo titolo di questa mail duplicata", "Duplica Email", NuovoTitolo)

                If NuovoTitolo.Length Then
                    Dim NuovoId As Integer = 0
                    Dim ListaAllegati As List(Of AttachPreventivoMail) = mailMsg.Allegati
                    mailMsg.Titolo = NuovoTitolo
                    mailMsg.IdMailPreventivo = 0
                    NuovoId = mailMsg.Save()
                    If NuovoId Then
                        For Each a As AttachPreventivoMail In ListaAllegati
                            a.IdMailAttach = 0
                            a.IdMailPreventivo = NuovoId
                            a.Save()
                        Next
                    End If

                    CaricaDati()
                End If

            End If

        End If
    End Sub

End Class
