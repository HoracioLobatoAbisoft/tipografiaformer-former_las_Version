Imports FormerDALSql
Imports System.IO
Imports System.Configuration
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig
Imports System.Net.Mail
Imports System.Text
Imports System.Text.RegularExpressions
Imports FormerBusinessLogic
Imports ActiveUp.Net.Mail
Imports System.Net

Friend Class FormerMessenger
    Inherits BaseService


#Region "Base Function"

    Private Shared Property _txtLog As TextBox = Nothing
    Private Shared Property _lblLastOp As Label = Nothing
    Private Shared Property _ModuleName As String = String.Empty
    Private Shared Property _ModuleSigla As String = String.Empty

    Public Shared ReadOnly Property ModuleSigla As String
        Get
            Return _ModuleSigla
        End Get
    End Property

    Public Shared Sub Initialize(ByRef txtLog As TextBox,
                                 ByRef lblLastOp As Label,
                                 ModuleName As String,
                                 ModuleSigla As String)
        _txtLog = txtLog
        _lblLastOp = lblLastOp
        _ModuleName = ModuleName
        _ModuleSigla = ModuleSigla

    End Sub

    Public Shared Sub LogMe(Testo As String,
             Optional DontStore As Boolean = False,
             Optional Errore As Exception = Nothing)
        _LogMe(_txtLog, _lblLastOp, Testo, _ModuleName, _ModuleSigla, DontStore, Errore)
    End Sub

#End Region
    Public Shared ReadOnly Property IntervalDelayInvio As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Messenger-Interval-Delay")
            Return Ris
        End Get
    End Property

    Private Shared ReadOnly Property IntervalMailMin As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Messenger-Interval-Mail")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalMail As Integer
        Get
            Dim Ris As Integer = IntervalMailMin
            If Ris Then Ris = Ris * 60 * 1000
            Return Ris
        End Get
    End Property
    Public Shared Sub StartService()

        Stato = enStatoServizio.Attivo

        InvioMailMarketing() 'invio le mail in uscita

        'ScaricaPreventiviMail()

        ScaricaOrdiniMail()

        MonitoraggioPECEx(MgrAziende.IdAziende.AziendaSnc)
        Threading.Thread.Sleep(5000)
        MonitoraggioPECEx(MgrAziende.IdAziende.AziendaSrl)


    End Sub


    Public Shared Sub StopService()

        Stato = enStatoServizio.NonAttivo

    End Sub
    Private Shared Sub ScaricaPreventiviMail()

        LogMe("***Scaricamento Mail Preventivi***")
        Dim count As Integer = 0
        Dim Scaricate As Integer = 0
        If Postazione.Network.ConnessioneInternetDisponibile Then
            Try
                Using p As New OpenPop.Pop3.Pop3Client

                    p.Connect(FConfiguration.PreventiviMail.ServerPOP, 995, True)

                    Dim User As String = FConfiguration.PreventiviMail.Email
                    Dim Pwd As String = FConfiguration.PreventiviMail.Password

                    'User = "postmaster@tipografiaformer.it"
                    'Pwd = "tghi9maeqa"

                    p.Authenticate(User,
                                   Pwd,
                                   OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword)

                    count = p.GetMessageCount()

                    If count Then

                        For i As Integer = count To 1 Step -1

                            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()

                                Try
                                    Dim msg As OpenPop.Mime.Message = p.GetMessage(i)

                                    Dim msgMail As MailMessage = msg.ToMailMessage

                                    Dim body As String = msgMail.Body

                                    Dim Mittente As String = msgMail.From.Address
                                    Dim Titolo As String = msgMail.Subject

                                    Dim FromSite As Boolean = False

                                    If Titolo.IndexOf("***SPAM***") <> -1 Then
                                        'questa è da cancellare
                                        p.DeleteMessage(i)
                                    Else
                                        'qui tutto ok 
                                        If Mittente = "noreply@tipografiaformer.it" And
                                                                               msgMail.IsBodyHtml = True And
                                                                               msgMail.Attachments.Count Then

                                            For Each a In msgMail.Attachments
                                                If a.Name.ToLower.EndsWith(".xml") Then
                                                    FromSite = True
                                                    Exit For
                                                End If
                                            Next
                                        End If

                                        Dim soggetto As String = msgMail.Subject

                                        'cerco un riferimento a un altra mail

                                        Dim IdMailRif As Integer = 0
                                        Dim ris As Match = Regex.Match(body, "FPGUID{.*?}")
                                        Dim GuidTrovato As String = String.Empty

                                        If ris.Success Then
                                            GuidTrovato = ris.Value

                                            GuidTrovato = GuidTrovato.Substring(GuidTrovato.IndexOf("{") + 1)
                                            GuidTrovato = GuidTrovato.Substring(0, GuidTrovato.Length - 1)

                                            Using mgr As New PreventiviMailDAO
                                                Dim lP As List(Of PreventivoMail) = mgr.FindAll(LFM.PreventivoMail.DataRif,
                                                                                                New LUNA.LunaSearchParameter(LFM.PreventivoMail.GuidMail, GuidTrovato))

                                                If lP.Count Then
                                                    IdMailRif = lP.Last.IdMailPreventivo
                                                End If

                                            End Using

                                        End If

                                        Dim MailIniziale As PreventivoMail = Nothing

                                        If GuidTrovato.Length Then
                                            Using mgr As New PreventiviMailDAO
                                                MailIniziale = mgr.Find(New LUNA.LunaSearchParameter(LFM.PreventivoMail.GuidMail, GuidTrovato),
                                                                        New LUNA.LunaSearchParameter(LFM.PreventivoMail.IdMailRif, 0))
                                            End Using
                                        End If

                                        Dim PulisciBody As Boolean = True

                                        If FromSite Then
                                            PulisciBody = False
                                        Else
                                            'qui non è dal sito ma potrebbe essere una risposta 
                                            If (Not MailIniziale Is Nothing AndAlso MailIniziale.DalSito = enSiNo.Si) Then
                                                PulisciBody = False
                                            End If
                                        End If

                                        If PulisciBody Then
                                            If msgMail.IsBodyHtml Then

                                                Dim bodyParsed As String = String.Empty

                                                If msgMail.AlternateViews.Count Then
                                                    For Each a As AlternateView In msgMail.AlternateViews
                                                        If a.ContentType.MediaType = "text/plain" Then
                                                            Dim contenuto As Stream = a.ContentStream
                                                            Dim byteBuffer(contenuto.Length) As Byte

                                                            Dim CharsetTrovato As String = String.Empty

                                                            Try
                                                                CharsetTrovato = a.ContentType.CharSet
                                                            Catch ex As Exception

                                                            End Try

                                                            If CharsetTrovato.Length = 0 Then
                                                                CharsetTrovato = "UTF-8"
                                                            End If

                                                            'Select Case CharsetTrovato.ToUpper
                                                            '    Case "UTF-7"
                                                            '        bodyParsed = Encoding.UTF7.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                            '    Case "UTF-32"
                                                            '        bodyParsed = Encoding.UTF32.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                            '    Case "UNICODE"
                                                            '        bodyParsed = Encoding.Unicode.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                            '    Case "US-ASCII"
                                                            '        bodyParsed = Encoding.ASCII.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                            '    Case Else '"UTF-8"
                                                            '        bodyParsed = Encoding.UTF8.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                            'End Select

                                                            bodyParsed = Encoding.GetEncoding(CharsetTrovato).GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))

                                                        End If
                                                    Next
                                                End If

                                                If bodyParsed.Length = 0 Then
                                                    body = FormerLib.FormerHelper.HTML.EliminaTag(msgMail.Body)
                                                Else
                                                    body = bodyParsed
                                                End If

                                            End If
                                        End If

                                        Try
                                            body = System.Web.HttpUtility.HtmlDecode(body)
                                        Catch ex As Exception

                                        End Try

                                        Dim l As New List(Of AttachPreventivoMail)

                                        If msgMail.Attachments.Count Then
                                            For Each a As Attachment In msgMail.Attachments

                                                Dim NomeFileDest As String = a.Name

                                                Randomize()
                                                Dim R As New Random

                                                NomeFileDest = FormerLib.FormerHelper.Web.NormalizzaNomeFile(NomeFileDest)

                                                NomeFileDest = R.Next(100, 999) & "_" & NomeFileDest

                                                Dim path As String = FormerPath.PathAttachMailPrev & NomeFileDest

                                                Using fs As New FileStream(path, FileMode.Create)

                                                    a.ContentStream.CopyTo(fs)

                                                End Using

                                                Dim mAttach As New AttachPreventivoMail
                                                mAttach.NomeFile = NomeFileDest
                                                mAttach.Path = path

                                                l.Add(mAttach)

                                            Next
                                        End If

                                        'qui devo vedere se e' inoltrata

                                        If FromSite = False Then
                                            Dim risInoltro As Match = Regex.Match(Mittente, "@tipografiaformer.")

                                            'Dim risInoltro As Match = Regex.Match(Mittente, "tipografia.duca@gmail.")

                                            If (risInoltro.Success = True Or Mittente = "tipografia.duca@gmail.com") Then
                                                'qui devo cercare l'inoltro

                                                Dim collCercaMail As MatchCollection = Regex.Matches(msgMail.Body, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")

                                                For Each singRis As Match In collCercaMail

                                                    Dim cercaMail As Match = Regex.Match(singRis.Value, "@tipografiaformer.")

                                                    If cercaMail.Success = False And singRis.Value <> "tipografia.duca@gmail.com" Then

                                                        If FormerLib.FormerHelper.Mail.IsValidEmailAddress(singRis.Value) Then
                                                            Mittente = singRis.Value
                                                            Exit For
                                                        End If

                                                    End If

                                                Next

                                            End If
                                        End If


                                        Dim risInoltroAfter As Match = Regex.Match(Mittente, "@tipografiaformer.")

                                        If GuidTrovato.Length = 0 Then

                                            Dim x As Guid = Guid.NewGuid
                                            GuidTrovato = x.ToString

                                        End If

                                        Dim DataRif As Date = Now

                                        Try

                                            Dim dataTemp As String = msg.Headers.Date

                                            Dim dataRifTemp As Date = CDate(dataTemp)

                                            DataRif = dataRifTemp

                                        Catch ex As Exception

                                        End Try

                                        Dim NumeroPreventivo As Integer = 0

                                        Using mp As New PreventivoMail

                                            mp.GuidMail = GuidTrovato
                                            mp.DataRif = DataRif
                                            mp.Mittente = Mittente.Trim

                                            Titolo = Titolo.Trim
                                            If Titolo.Length > 255 Then Titolo = Titolo.Substring(0, 254)

                                            mp.Titolo = Titolo
                                            mp.Testo = body.Trim
                                            mp.Stato = enStatoPreventivoMail.DaLavorare
                                            mp.IdMailRif = IdMailRif
                                            mp.TipoMail = enTipoMail.Preventivo
                                            mp.DalSito = IIf(FromSite, enSiNo.Si, enSiNo.No)

                                            If FromSite = False Then
                                                If (risInoltroAfter.Success = False And Mittente <> "tipografia.duca@gmail.com") Then
                                                    Using mgrR As New VociRubricaDAO
                                                        Dim lR As List(Of VoceRubrica) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Email, mp.Mittente))
                                                        If lR.Count Then
                                                            Dim vr As VoceRubrica = lR(0)
                                                            mp.IdRub = vr.IdRub
                                                        Else
                                                            'qui devo provare a cercare tra le mail in arrivo se per caso la stessa mail è
                                                            'stata assegnata gia a un cliente
                                                            Using mgrM As New PreventiviMailDAO
                                                                Dim IdRubTrovato As Integer = mgrM.GetIdRubFromStorico(Mittente)
                                                                If IdRubTrovato Then
                                                                    mp.IdRub = IdRubTrovato
                                                                End If
                                                            End Using
                                                        End If
                                                    End Using
                                                End If
                                            Else
                                                'qui devo spacchettare il file xml e ricostruire la richiesta di preventivo

                                                For Each singA As AttachPreventivoMail In l
                                                    If singA.Path.ToLower.EndsWith(".xml") Then
                                                        'qui vado a prendermi il file e ricostruisco la richiesta 

                                                        Dim Email As String = FormerHelper.XML.GetValueFromFile(singA.Path, "Email")
                                                        Using mgrM As New PreventiviMailDAO

                                                            Using mgrR As New VociRubricaDAO
                                                                Dim lR As List(Of VoceRubrica) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Email, Email))
                                                                If lR.Count Then
                                                                    Dim vr As VoceRubrica = lR(0)
                                                                    mp.IdRub = vr.IdRub
                                                                Else
                                                                    Dim IdRubTrovato As Integer = mgrM.GetIdRubFromStorico(Email)
                                                                    If IdRubTrovato Then
                                                                        mp.IdRub = IdRubTrovato
                                                                    End If
                                                                End If
                                                            End Using
                                                        End Using
                                                        Mittente = Email
                                                        mp.Mittente = Mittente.Trim
                                                        mp.Titolo = mp.Titolo.Substring(mp.Titolo.IndexOf("-") + 1).Trim(" ")

                                                        Dim PrezzoSuggerito As String = FormerHelper.XML.GetValueFromFile(singA.Path, "PrezzoCalcolatoNetto")

                                                        Try
                                                            mp.PrezzoSuggerito = PrezzoSuggerito
                                                        Catch ex As Exception

                                                        End Try

                                                        Exit For
                                                    End If
                                                Next

                                            End If

                                            tb.TransactionBegin()

                                            NumeroPreventivo = mp.Save()
                                            If mp.IdMailRif = 0 Then mp.Titolo = "PREVENTIVO " & NumeroPreventivo & " - " & mp.Titolo
                                            mp.Testo = mp.Testo.Replace(FormerConst.Tag.NumeroPreventivo, mp.IdMailPreventivo)
                                            mp.Save()

                                            Scaricate += 1

                                            For Each singA As AttachPreventivoMail In l

                                                Dim NuovoPath As String = singA.Path.Replace(singA.NomeFile, mp.IdMailPreventivo & "_" & singA.NomeFile)

                                                Rename(singA.Path, NuovoPath)

                                                singA.Path = NuovoPath
                                                singA.IdMailPreventivo = mp.IdMailPreventivo
                                                singA.Save()
                                            Next

                                            tb.TransactionCommit()

                                        End Using

                                        'RIATTIVARE PRIMA DI METTERE IN PRODUZIONE
                                        'qui cancello il messaggio dal server remoto
                                        p.DeleteMessage(i)

                                        If FromSite OrElse (ris.Success = False And risInoltroAfter.Success = False And Mittente <> "tipografia.duca@gmail.com") Then
                                            Dim TestoRisposta As String = String.Empty

                                            TestoRisposta = "Salve, <br><br>"
                                            TestoRisposta &= "la sua richiesta di preventivo <b>NUMERO " & NumeroPreventivo & "</b> per <b>'" & Titolo & "'</b> è stata presa in carico e riceverà una risposta entro 24/48 ore.<br><br>"
                                            TestoRisposta &= "<br><br><br><font face=""courier"">*********************************************************************************************************<br>"
                                            TestoRisposta &= "IN CASO DI RISPOSTA A QUESTA EMAIL NON RIMUOVERE QUESTA RIGA FPGUID{$}<br>".Replace("$", GuidTrovato) & ControlChars.NewLine
                                            TestoRisposta &= "*********************************************************************************************************</font>"

                                            Try
                                                'RIATTIVARE PRIMA DI METTERE IN PRODUZIONE
                                                'qui rispondo alla mail con una mail automatica di presa in carico
                                                FormerLib.FormerHelper.Mail.InviaMail("La sua richiesta di preventivo NUMERO " & NumeroPreventivo & " è stata presa in carico", TestoRisposta, Mittente, FConfiguration.PreventiviMail.EmailSender,,,,,, False)
                                            Catch ex As Exception

                                            End Try
                                        Else
                                            'qui devo rimettere da lavorare la discussione iniziale
                                            Using mgr As New PreventiviMailDAO
                                                Dim lP As List(Of PreventivoMail) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.PreventivoMail.GuidMail, GuidTrovato),
                                                                                               New LUNA.LunaSearchParameter(LFM.PreventivoMail.IdMailRif, 0))

                                                Using singmail As PreventivoMail = lP(0)
                                                    singmail.Stato = enStatoPreventivoMail.DaLavorare
                                                    singmail.Save()
                                                End Using

                                            End Using
                                        End If
                                    End If

                                Catch ex As Exception

                                    'PROVO A CANCELLARE IL MESSAGGIO 
                                    Try
                                        'p.DeleteMessage(i)
                                    Catch ex2 As Exception

                                    End Try

                                    LogMe("SORGENTE: ScaricaPreventiviMail(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace,, ex)
                                    tb.TransactionRollBack()
                                    'log
                                End Try

                            End Using

                        Next
                    End If

                    p.Disconnect()

                    'MessageBox.Show("Scaricate " & count & " mail")

                    If Scaricate Then FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Notifica, "Scaricati " & Scaricate & " nuovi preventivi email.", FormerLib.FormerUDP.DestUDP_Admin)

                End Using
            Catch ex As Exception
                LogMe("SORGENTE: ScaricaPreventiviMail(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, False, ex)
            End Try

        End If

        LogMe("*********************************************", True)
        LogMe("Scaricate " & count & " mail preventivi")
        LogMe("*********************************************", True)


    End Sub

    Private Shared Sub ScaricaPreventiviMailOld()
        LogMe("***Scaricamento Mail Preventivi***")
        Dim count As Integer = 0
        Dim Scaricate As Integer = 0
        If Postazione.Network.ConnessioneInternetDisponibile Then
            Try
                Using p As New OpenPop.Pop3.Pop3Client

                    p.Connect(FConfiguration.PreventiviMail.ServerPOP, 995, True)

                    p.Authenticate(FConfiguration.PreventiviMail.Email,
                                   FConfiguration.PreventiviMail.Password,
                                   OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword)

                    count = p.GetMessageCount()

                    If count Then

                        For i As Integer = count To 1 Step -1

                            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()

                                Try
                                    Dim msg As OpenPop.Mime.Message = p.GetMessage(i)

                                    Dim msgMail As MailMessage = msg.ToMailMessage

                                    Dim body As String = msgMail.Body

                                    Dim soggetto As String = msgMail.Subject
                                    If msgMail.IsBodyHtml Then

                                        Dim bodyParsed As String = String.Empty

                                        If msgMail.AlternateViews.Count Then
                                            For Each a As AlternateView In msgMail.AlternateViews
                                                If a.ContentType.MediaType = "text/plain" Then
                                                    Dim contenuto As Stream = a.ContentStream
                                                    Dim byteBuffer(contenuto.Length) As Byte

                                                    Dim CharsetTrovato As String = String.Empty

                                                    Try
                                                        CharsetTrovato = a.ContentType.CharSet
                                                    Catch ex As Exception

                                                    End Try

                                                    If CharsetTrovato.Length = 0 Then
                                                        CharsetTrovato = "UTF-8"
                                                    End If

                                                    'Select Case CharsetTrovato.ToUpper
                                                    '    Case "UTF-7"
                                                    '        bodyParsed = Encoding.UTF7.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    '    Case "UTF-32"
                                                    '        bodyParsed = Encoding.UTF32.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    '    Case "UNICODE"
                                                    '        bodyParsed = Encoding.Unicode.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    '    Case "US-ASCII"
                                                    '        bodyParsed = Encoding.ASCII.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    '    Case Else '"UTF-8"
                                                    '        bodyParsed = Encoding.UTF8.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    'End Select

                                                    bodyParsed = Encoding.GetEncoding(CharsetTrovato).GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))

                                                End If
                                            Next
                                        End If

                                        If bodyParsed.Length = 0 Then
                                            body = FormerLib.FormerHelper.HTML.EliminaTag(msgMail.Body)
                                        Else
                                            body = bodyParsed
                                        End If

                                    End If

                                    Try
                                        body = System.Web.HttpUtility.HtmlDecode(body)
                                    Catch ex As Exception

                                    End Try

                                    Dim l As New List(Of AttachPreventivoMail)

                                    If msgMail.Attachments.Count Then
                                        For Each a As Attachment In msgMail.Attachments

                                            Dim NomeFileDest As String = a.Name

                                            Randomize()
                                            Dim R As New Random

                                            NomeFileDest = FormerLib.FormerHelper.Web.NormalizzaNomeFile(NomeFileDest)

                                            NomeFileDest = R.Next(100, 999) & "_" & NomeFileDest

                                            Dim path As String = FormerPath.PathAttachMailPrev & NomeFileDest

                                            Using fs As New FileStream(path, FileMode.Create)

                                                a.ContentStream.CopyTo(fs)

                                            End Using

                                            Dim mAttach As New AttachPreventivoMail
                                            mAttach.NomeFile = NomeFileDest
                                            mAttach.Path = path

                                            l.Add(mAttach)

                                        Next
                                    End If

                                    'cerco un riferimento a un altra mail

                                    Dim IdMailRif As Integer = 0
                                    Dim ris As Match = Regex.Match(body, "FPGUID{.*?}")
                                    Dim GuidTrovato As String = String.Empty

                                    If ris.Success Then
                                        GuidTrovato = ris.Value

                                        GuidTrovato = GuidTrovato.Substring(GuidTrovato.IndexOf("{") + 1)
                                        GuidTrovato = GuidTrovato.Substring(0, GuidTrovato.Length - 1)

                                        Using mgr As New PreventiviMailDAO
                                            Dim lP As List(Of PreventivoMail) = mgr.FindAll(LFM.PreventivoMail.DataRif,
                                                                                            New LUNA.LunaSearchParameter(LFM.PreventivoMail.GuidMail, GuidTrovato))

                                            If lP.Count Then
                                                IdMailRif = lP.Last.IdMailPreventivo
                                            End If

                                        End Using

                                    End If

                                    Dim Mittente As String = msgMail.From.Address
                                    Dim Titolo As String = msgMail.Subject

                                    'qui devo vedere se e' inoltrata
                                    Dim risInoltro As Match = Regex.Match(Mittente, "@tipografiaformer.")

                                    'Dim risInoltro As Match = Regex.Match(Mittente, "tipografia.duca@gmail.")

                                    If risInoltro.Success = True Or Mittente = "tipografia.duca@gmail.com" Then
                                        'qui devo cercare l'inoltro

                                        Dim collCercaMail As MatchCollection = Regex.Matches(msgMail.Body, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")

                                        For Each singRis As Match In collCercaMail

                                            Dim cercaMail As Match = Regex.Match(singRis.Value, "@tipografiaformer.")

                                            If cercaMail.Success = False And singRis.Value <> "tipografia.duca@gmail.com" Then

                                                If FormerLib.FormerHelper.Mail.IsValidEmailAddress(singRis.Value) Then
                                                    Mittente = singRis.Value
                                                    Exit For
                                                End If

                                            End If

                                        Next

                                    End If

                                    Dim risInoltroAfter As Match = Regex.Match(Mittente, "@tipografiaformer.")

                                    If GuidTrovato.Length = 0 Then

                                        Dim x As Guid = Guid.NewGuid
                                        GuidTrovato = x.ToString

                                    End If

                                    Dim DataRif As Date = Now

                                    Try

                                        Dim dataTemp As String = msg.Headers.Date

                                        Dim dataRifTemp As Date = CDate(dataTemp)

                                        DataRif = dataRifTemp

                                    Catch ex As Exception

                                    End Try

                                    Using mp As New PreventivoMail

                                        mp.GuidMail = GuidTrovato
                                        mp.DataRif = DataRif
                                        mp.Mittente = Mittente.Trim

                                        Titolo = Titolo.Trim
                                        If Titolo.Length > 255 Then Titolo = Titolo.Substring(0, 254)

                                        mp.Titolo = Titolo
                                        mp.Testo = body.Trim
                                        mp.Stato = enStatoPreventivoMail.DaLavorare
                                        mp.IdMailRif = IdMailRif
                                        mp.TipoMail = enTipoMail.Preventivo

                                        If risInoltroAfter.Success = False And Mittente <> "tipografia.duca@gmail.com" Then
                                            Using mgrR As New VociRubricaDAO
                                                Dim lR As List(Of VoceRubrica) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Email, mp.Mittente))
                                                If lR.Count Then
                                                    Dim vr As VoceRubrica = lR(0)
                                                    mp.IdRub = vr.IdRub
                                                Else
                                                    'qui devo provare a cercare tra le mail in arrivo se per caso la stessa mail è
                                                    'stata assegnata gia a un cliente
                                                    Using mgrM As New PreventiviMailDAO
                                                        Dim IdRubTrovato As Integer = mgrM.GetIdRubFromStorico(Mittente)
                                                        If IdRubTrovato Then
                                                            mp.IdRub = IdRubTrovato
                                                        End If
                                                    End Using
                                                End If
                                            End Using
                                        End If

                                        tb.TransactionBegin()

                                        mp.Save()

                                        Scaricate += 1

                                        For Each singA As AttachPreventivoMail In l

                                            Dim NuovoPath As String = singA.Path.Replace(singA.NomeFile, mp.IdMailPreventivo & "_" & singA.NomeFile)

                                            Rename(singA.Path, NuovoPath)

                                            singA.Path = NuovoPath
                                            singA.IdMailPreventivo = mp.IdMailPreventivo
                                            singA.Save()
                                        Next

                                        tb.TransactionCommit()

                                    End Using

                                    'RIATTIVARE PRIMA DI METTERE IN PRODUZIONE
                                    'qui cancello il messaggio dal server remoto
                                    p.DeleteMessage(i)

                                    If ris.Success = False And risInoltroAfter.Success = False And Mittente <> "tipografia.duca@gmail.com" Then
                                        Dim TestoRisposta As String = String.Empty

                                        TestoRisposta = "Salve, <br><br>"
                                        TestoRisposta &= "la sua richiesta di preventivo <b>'" & Titolo & "'</b> è stata presa in carico e riceverà una risposta entro 24/48 ore.<br><br>"
                                        TestoRisposta &= "<br><br><br><font face=""courier"">*********************************************************************************************************<br>"
                                        TestoRisposta &= "IN CASO DI RISPOSTA A QUESTA EMAIL NON RIMUOVERE QUESTA RIGA FPGUID{$}<br>".Replace("$", GuidTrovato) & ControlChars.NewLine
                                        TestoRisposta &= "*********************************************************************************************************</font>"

                                        Try
                                            'RIATTIVARE PRIMA DI METTERE IN PRODUZIONE
                                            'qui rispondo alla mail con una mail automatica di presa in carico
                                            FormerLib.FormerHelper.Mail.InviaMail("La sua richiesta di preventivo è stata presa in carico", TestoRisposta, Mittente, FConfiguration.PreventiviMail.EmailSender,,,,,, False)
                                        Catch ex As Exception

                                        End Try
                                    Else
                                        'qui devo rimettere da lavorare la discussione iniziale
                                        Using mgr As New PreventiviMailDAO
                                            Dim lP As List(Of PreventivoMail) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.PreventivoMail.GuidMail, GuidTrovato),
                                                                                           New LUNA.LunaSearchParameter(LFM.PreventivoMail.IdMailRif, 0))

                                            Using singmail As PreventivoMail = lP(0)
                                                singmail.Stato = enStatoPreventivoMail.DaLavorare
                                                singmail.Save()
                                            End Using

                                        End Using
                                    End If

                                Catch ex As Exception

                                    'PROVO A CANCELLARE IL MESSAGGIO 
                                    Try
                                        p.DeleteMessage(i)
                                    Catch ex2 As Exception

                                    End Try

                                    LogMe("SORGENTE: ScaricaPreventiviMail(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace,, ex)
                                    tb.TransactionRollBack()
                                    'log
                                End Try

                            End Using

                        Next
                    End If

                    p.Disconnect()

                    'MessageBox.Show("Scaricate " & count & " mail")

                    If Scaricate Then FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Notifica, "Scaricati " & Scaricate & " nuovi preventivi email.", FormerLib.FormerUDP.DestUDP_Admin)

                End Using
            Catch ex As Exception
                LogMe("SORGENTE: ScaricaPreventiviMail(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, False, ex)
            End Try

        End If

        LogMe("*********************************************", True)
        LogMe("Scaricate " & count & " mail preventivi")
        LogMe("*********************************************", True)


    End Sub





    Private Shared Sub InviaSoluzioniAttuali(Destinatario As String)

        Dim Buffer As String = String.Empty

        Dim CheckOkParam As Boolean = True

        Dim LstStati As String = enStatoOrdine.Registrato
        Dim L As List(Of OrdineRicerca)

        Using OMgr As New OrdiniDAO
            L = OMgr.Lista(, LstStati, , True, , , , , , , , , , enTipoProdCom.StampaOffSet, True)
            'L = L.FindAll(Function(x) x.IdListinoBase <> 0)
        End Using

        Dim ParametriImpostati As New ParametriCreazioneSoluzione
        ParametriImpostati.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreBeta
        'Else
        'ParametriImpostati.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreStabile
        'End If
        ParametriImpostati.MaxDuplicazioneSingoloOrdine = 10
        ParametriImpostati.SoloSoluzioniOttimali = True
        ParametriImpostati.UtilizzaSoloMacchinarioDefault = True
        ParametriImpostati.PermettiQtaMinoreOrdini = False

        Buffer &= "<h3>SOLUZIONI DISPONIBILI</h3>"
        Buffer &= "<table border=0>"
        Dim LUtil As New List(Of OrdineRicerca)

        'L = L.FindAll(Function(Item) Item.IdCom = 0)

        ''li ordino in modo che tratto sempre prima gli ordini piu urgenti
        'L.Sort(Function(x, y) y.DataPrevConsegna.CompareTo(x.DataPrevConsegna))

        'Dim Sol As MgrCommesseOne = New MgrCommesseOne

        Dim lSol As List(Of Soluzione) = Nothing

        Dim lToLav As New List(Of OrdineRicerca)

        lToLav.AddRange(L)

        lSol = MotoreCalcoloSoluzioni.ProponiSoluzioni(lToLav, ParametriImpostati)

        Dim CountSol As Integer = 1

        For Each ss As Soluzione In lSol

            If ss.Commesse.FindAll(Function(x) x.PercentualeCompletamento > 50).Count Then
                ss.Commesse = ss.Commesse.FindAll(Function(x) x.PercentualeCompletamento >= 50)
            End If


            ss.Commesse.Sort(AddressOf FormerListSorter.CommesseSorter.ComparerCommessaProposta)
            For Each C As CommessaProposta In ss.Commesse

                Dim NodoCom As New TreeNode

                Dim WithPerc As Boolean = False
                Buffer &= "<tr>"
                Buffer &= "<td colspan=2 style='background-color:green;color:white;'><b>" & C.Riassunto(WithPerc) & IIf(FormerDebug.DebugAttivo, " - IDMod " & C.ModelloCommessa.IdModello & " - N° Las. " & C.NLastreNecessarie, String.Empty) & "</b></td>"
                Buffer &= "</tr>"

                'C.Ordini.Sort(Function(x, y) y.SpaziUsati.CompareTo(x.SpaziUsati))
                C.Ordini.Sort(AddressOf FormerListSorter.OrdiniSorter.ComparerOrderInSoluzione)

                Dim Contenuto As New Dictionary(Of String, Integer)

                For Each O As OrdineInSoluzione In C.Ordini
                    Dim Chiave As String = O.QtaOrdine & " " & O.Ordine.Prodotto.Descrizione

                    Dim Conteggio As Integer = 0
                    If Contenuto.TryGetValue(Chiave, Conteggio) Then
                        Contenuto(Chiave) += 1
                    Else
                        Contenuto.Add(Chiave, 1)
                    End If
                Next

                For Each Val As KeyValuePair(Of String, Integer) In Contenuto
                    Buffer &= "<tr>"
                    Buffer &= "<td width=50></td>"
                    Buffer &= "<td><b>" & Val.Value & "</b> ordini di <b>" & Val.Key & "</b></td>"
                    Buffer &= "</tr>"
                Next

                'NodoCom.Tag.ToString.TrimEnd(",")
            Next
        Next


        Buffer &= "</table>"

        'Buffer &= "<b>OPERATORI</b><ul>"
        'Buffer &= "</ul>"

        FormerLib.FormerHelper.Mail.InviaMail("Soluzioni disponibili", Buffer, Destinatario)


    End Sub
    Private Shared Sub InviaSituazioneAttuale(Destinatario As String)
        Dim Buffer As String = String.Empty
        Dim l As New List(Of String)
        Dim NOrd As Integer = 0
        Dim NOrdR As Integer = 0

        Using M As New CatProdDAO

            NOrd = M.GetNumOrd(0, 0, enStatoOrdine.Preinserito)
            NOrdR = M.GetNumOrd(0, 0, enStatoOrdine.Registrato)

            Buffer &= "<h3>ORDINI DISPONIBILI</h3>"
            Buffer &= "<b style=""background-color:" & FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Preinserito) & ";padding:3px;"">Preinserito: " & NOrd & "</b><br>"
            Buffer &= "<b style=""background-color:" & FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Registrato) & ";padding:3px;"">Registrato: " & NOrdR & "</b><br>"
            Buffer &= "<table border=0>"

            Using Mgr As New PreventivazioniDAO
                Dim Lst As List(Of Preventivazione) = Mgr.GetAll("IdReparto,Descrizione")

                For Each CategProd As Preventivazione In Lst

                    Dim DescrP As String = "<b>" & CategProd.Descrizione & "</b> "
                    NOrd = M.GetNumOrd(CategProd.IdPrev, 0, enStatoOrdine.Preinserito)
                    DescrP &= " {"
                    If NOrd Then DescrP &= "<b>" & NOrd & "</b> Preinserito "

                    NOrdR = M.GetNumOrd(CategProd.IdPrev, 0, enStatoOrdine.Registrato)
                    If NOrdR Then
                        DescrP &= "<b>" & NOrdR & "</b> Registrato"
                    End If
                    DescrP &= "}<br>"

                    'qui metto le qta

                    Using mgrO As New OrdiniDAO
                        Dim lOrd As List(Of OrdineRicerca) = mgrO.Lista(, enStatoOrdine.Preinserito & "," & enStatoOrdine.Registrato,, True,,,,,,,,,,,,,,, CategProd.IdPrev)

                        Dim qta As New Dictionary(Of Integer, Integer)

                        For Each ord In lOrd
                            If qta.ContainsKey(ord.QtaRif) Then
                                qta(ord.QtaRif) += 1
                            Else
                                qta.Add(ord.QtaRif, 1)
                            End If
                        Next

                        qta.OrderBy(Function(x) x.Value)

                        For Each Valore In qta
                            DescrP &= " - " & Valore.Key & " (" & Valore.Value & ")<br>"
                        Next

                    End Using

                    If NOrd <> 0 Or NOrdR <> 0 Then
                        Buffer &= "<tr><td>" & DescrP & "</td></tr>"
                    End If
                Next
            End Using
        End Using

        Buffer &= "</table>"

        Buffer &= "<b>COMMESSE IN CODA</b>"
        Buffer &= "<table border=0>"
        Buffer &= "<tr>"
        Buffer &= "<td width=""100""></td>"
        Buffer &= "<td><b>REPARTO</b></td>"
        Buffer &= "<td><b>COMMESSA</b></td>"
        Buffer &= "<td><b>STATO</b></td>"
        Buffer &= "<td><b>RIASSUNTO</b></td>"
        Buffer &= "<td align=right><b>COPIE/Q.TA</b></td>"
        Buffer &= "</tr>"
        Dim LOption As New LUNA.LunaSearchOption() With {.OrderBy = "IdReparto,DataIns"}

        Using mgr As New CommesseDAO
            Dim lC As List(Of Commessa) = mgr.FindAll(LOption,
                                                      New LUNA.LunaSearchParameter(LFM.Commessa.Stato, enStatoCommessa.Preinserito))

            For Each C As Commessa In lC
                Application.DoEvents()

                Dim Path As String = FormerPathCreator.GetAnteprima(C) '.Replace("Z:", "W:")
                Dim Cid As String = FormerHelper.File.EstraiNomeFile(Path)
                l.Add(Path)
                Buffer &= "<tr>"
                Buffer &= "<td width=""100""><img src=""cid:" & Cid & """ width=""100""></td>"
                Buffer &= "<td width=""8"" bgcolor=""" & FormerColori.GetColoreToHtml(FormerColori.GetColoreReparto(C.IdReparto)) & """>&nbsp;</td>"
                Buffer &= "<td>" & C.IdCom & "</td>"
                Buffer &= "<td bgcolor=""" & C.StatoColoreHTML & """>" & C.StatoStr & "</td>"
                Buffer &= "<td>" & C.Riassunto & "</td>"
                Buffer &= "<td align=right>" & C.CopieStr & "</td>"
                Buffer &= "</tr>"
            Next

        End Using

        Using mgr As New CommesseDAO
            Dim lC As List(Of Commessa) = mgr.FindAll(LOption,
                                                      New LUNA.LunaSearchParameter(LFM.Commessa.Stato, enStatoCommessa.Pronto))

            For Each C As Commessa In lC

                Application.DoEvents()
                Dim Path As String = FormerPathCreator.GetAnteprima(C) '.Replace("Z:", "W:")
                Dim Cid As String = FormerHelper.File.EstraiNomeFile(Path)
                l.Add(Path)
                Buffer &= "<tr>"
                Buffer &= "<td width=""100""><img src=""cid:" & Cid & """ width=""100""></td>"
                Buffer &= "<td width=""8"" bgcolor=""" & FormerColori.GetColoreToHtml(FormerColori.GetColoreReparto(C.IdReparto)) & """>&nbsp;</td>"
                Buffer &= "<td>" & C.IdCom & "</td>"
                Buffer &= "<td bgcolor=""" & C.StatoColoreHTML & """>" & C.StatoStr & "</td>"
                Buffer &= "<td>" & C.Riassunto & "</td>"
                Buffer &= "<td align=right>" & C.CopieStr & "</td>"
                Buffer &= "</tr>"
            Next

        End Using

        Using mgr As New CommesseDAO
            Dim lC As List(Of Commessa) = mgr.FindAll(LOption,
                                                      New LUNA.LunaSearchParameter(LFM.Commessa.Stato, enStatoCommessa.Stampa))

            For Each C As Commessa In lC
                Application.DoEvents()

                Dim Path As String = FormerPathCreator.GetAnteprima(C) '.Replace("Z:", "W:")
                Dim Cid As String = FormerHelper.File.EstraiNomeFile(Path)
                l.Add(Path)
                Buffer &= "<tr>"
                Buffer &= "<td width=""100""><img src=""cid:" & Cid & """ width=""100""></td>"
                Buffer &= "<td width=""8"" bgcolor=""" & FormerColori.GetColoreToHtml(FormerColori.GetColoreReparto(C.IdReparto)) & """>&nbsp;</td>"
                Buffer &= "<td>" & C.IdCom & "</td>"
                Buffer &= "<td bgcolor=""" & C.StatoColoreHTML & """>" & C.StatoStr & "</td>"
                Buffer &= "<td>" & C.Riassunto & "</td>"
                Buffer &= "<td align=right>" & C.CopieStr & "</td>"
                Buffer &= "</tr>"
            Next

        End Using

        Buffer &= "</table>"

        'Buffer &= "<b>OPERATORI</b><ul>"
        'Buffer &= "</ul>"

        FormerLib.FormerHelper.Mail.InviaMailEx("Situazione aggiornata", Buffer, Destinatario, l)


    End Sub

    Private Shared Function ScaricaXMLFromEML(msgMail As MailMessage,
                                             PathFolder As String,
                                             TipoMail As enTipoMailPEC) As String
        Dim ris As String = String.Empty

        For Each a In msgMail.AlternateViews
            If Not a.ContentType.Name Is Nothing AndAlso a.ContentType.Name.EndsWith(".eml") Then

                FormerHelper.File.CreateLongPath(PathFolder)

                Dim NomeFile As String = PathFolder & a.ContentType.Name
                Using f As New FileStream(NomeFile, FileMode.Create, FileAccess.Write)
                    a.ContentStream.CopyTo(f)
                End Using

                Dim Buffer As String = String.Empty
                Dim Parti As New List(Of String)

                Dim Boundary As String = String.Empty
                Dim EncodingFound As String = String.Empty
                Dim NomeFileXML As String = String.Empty

                Using r As New StreamReader(NomeFile, Encoding.UTF8)
                    While r.EndOfStream = False
                        Dim Riga As String = r.ReadLine
                        Dim Marcatore As String = String.Empty
                        Marcatore = "boundary="
                        Dim PosBoundary As Integer = Riga.IndexOf(Marcatore)
                        If PosBoundary <> -1 Then
                            Boundary = Riga.Substring(Riga.IndexOf("-"))
                            Boundary = Boundary.Substring(0, Boundary.Length - 1).Trim
                        End If
                        Marcatore = "Content-Transfer-Encoding:"
                        If Riga.StartsWith(Marcatore) Then
                            EncodingFound = Riga.Substring(Marcatore.Length).Trim
                        End If

                        If EncodingFound.Length AndAlso (EncodingFound = "base64" OrElse EncodingFound = "quoted-printable" OrElse EncodingFound = "7bit") Then
                            Marcatore = "Content-Disposition: attachment; filename="
                            If Riga.StartsWith(Marcatore) AndAlso NomeFileXML.Length = 0 Then
                                Dim NomeFileTemp As String = Riga.Substring(Marcatore.Length).Trim
                                Dim NomeFileOriginale As String = NomeFileTemp
                                If NomeFileTemp.ToLower.EndsWith(".xml") = False AndAlso NomeFileTemp.ToLower.IndexOf(".xml") <> -1 Then
                                    NomeFileTemp = NomeFileTemp.Substring(0, NomeFileTemp.Length - 4)
                                End If

                                'qui controllo la regular expression per il nomefile fattura
                                Dim PatternReg As String = "^[A-Za-z]{2}[0-9A-Za-z]{11,16}_[0-9A-Za-z]{5}.xml$"

                                If TipoMail <> enTipoMailPEC.InvioFile Then
                                    PatternReg = "^[A-Za-z]{2}[0-9A-Za-z]{11,16}_[0-9A-Za-z]{5}.{0,7}.xml$"
                                End If

                                Dim Re As New RegularExpressions.Regex(PatternReg) '.{0,7}

                                If Re.IsMatch(NomeFileTemp.ToLower) Then
                                    NomeFileXML = NomeFileOriginale
                                End If

                            ElseIf NomeFileXML.Length Then
                                If Riga.IndexOf(Boundary) <> -1 Then
                                    Exit While
                                Else
                                    If EncodingFound = "quoted-printable" AndAlso Riga.EndsWith("=") Then
                                        Riga = Riga.Substring(0, Riga.Length - 1)
                                        Buffer &= Riga
                                    Else
                                        Buffer &= Riga & ControlChars.NewLine
                                    End If

                                End If

                            End If
                        End If


                    End While

                End Using
                Buffer = Buffer.Trim
                'Buffer = Buffer.Replace(vbCrLf, "")

                Dim PathFinale As String = PathFolder & NomeFileXML

                If EncodingFound = "base64" Then
                    Buffer = Buffer.Replace(vbCrLf, "")
                    File.WriteAllBytes(PathFinale, Convert.FromBase64String(Buffer))
                ElseIf EncodingFound = "quoted-printable" Then
                    Buffer = DecodeQuotedPrintables(Buffer)
                    Using w As New StreamWriter(PathFinale)
                        w.Write(Buffer)
                    End Using
                ElseIf EncodingFound = "7bit" Then
                    Using w As New StreamWriter(PathFinale)
                        w.Write(Buffer)
                    End Using
                End If

                ris = PathFinale
                Exit For
            End If
        Next

        Return ris
    End Function

    Private Shared Function DecodeQuotedPrintables(ByVal input As String) As String

        Dim ris As String = String.Empty

        Dim A As AlternateView = AlternateView.CreateAlternateViewFromString(input)

        Using r As New StreamReader(A.ContentStream)
            ris = r.ReadToEnd
        End Using
        'ris = A.ContentStream
        ris = ris.Replace("3D""", """")
        ris = ris.Replace("=3D", "=")
        Return ris

    End Function

    Private Shared Function ScaricaXMLFromEMLEx(msgMail As Message,
                                             PathFolder As String,
                                             TipoMail As enTipoMailPEC) As String
        Dim ris As String = String.Empty

        For Each a As MimePart In msgMail.EmbeddedObjects
            If Not a.ContentName Is Nothing AndAlso a.ContentName.ToLower.EndsWith(".eml") Then

                FormerHelper.File.CreateLongPath(PathFolder)

                Dim NomeFile As String = PathFolder & a.ContentName
                Using f As New FileStream(NomeFile, FileMode.Create, FileAccess.Write)
                    f.Write(a.BinaryContent, 0, a.BinaryContent.Length)
                End Using

                Dim Buffer As String = String.Empty
                Dim Parti As New List(Of String)

                Dim Boundary As String = String.Empty
                Dim EncodingFound As String = String.Empty
                Dim NomeFileXML As String = String.Empty

                Using r As New StreamReader(NomeFile, Encoding.UTF8)
                    While r.EndOfStream = False
                        Dim Riga As String = r.ReadLine
                        Dim Marcatore As String = String.Empty
                        If Boundary = String.Empty Then
                            Marcatore = "boundary="

                            Dim PosBoundary As Integer = Riga.IndexOf(Marcatore)
                            If PosBoundary <> -1 Then
                                Boundary = Riga.Substring(Riga.IndexOf("-"))
                                Boundary = Boundary.Substring(0, Boundary.Length - 1).Trim
                            End If
                        End If

                        Marcatore = "Content-Transfer-Encoding:"
                        If Riga.StartsWith(Marcatore) Then
                            EncodingFound = Riga.Substring(Marcatore.Length).Trim
                        End If

                        If EncodingFound.Length AndAlso (EncodingFound = "base64" OrElse EncodingFound = "quoted-printable" OrElse EncodingFound = "7bit") Then
                            Marcatore = "Content-Disposition: attachment; filename="
                            If Riga.StartsWith(Marcatore) AndAlso NomeFileXML.Length = 0 Then
                                Dim NomeFileTemp As String = Riga.Substring(Marcatore.Length).Trim
                                Dim NomeFileOriginale As String = NomeFileTemp
                                If NomeFileTemp.ToLower.EndsWith(".xml") = False AndAlso NomeFileTemp.ToLower.IndexOf(".xml") <> -1 Then
                                    NomeFileTemp = NomeFileTemp.Substring(0, NomeFileTemp.Length - 4)
                                End If

                                'qui controllo la regular expression per il nomefile fattura
                                Dim PatternReg As String = "^[A-Za-z]{2}[0-9A-Za-z_]{5,18}_[0-9A-Za-z]{3,10}.xml$"

                                If TipoMail <> enTipoMailPEC.InvioFile Then
                                    PatternReg = "^[A-Za-z]{2}[0-9A-Za-z]{11,16}_[0-9A-Za-z]{5}.{0,7}.xml$"
                                End If

                                Dim Re As New RegularExpressions.Regex(PatternReg) '.{0,7}

                                If Re.IsMatch(NomeFileTemp.ToLower) Then




                                    NomeFileXML = NomeFileOriginale
                                End If

                            ElseIf NomeFileXML.Length Then
                                If Riga.IndexOf(Boundary) <> -1 Then
                                    'qui vedo se si tratta di una fattura elettronica davvero

                                    If TipoMail = enTipoMailPEC.InvioFile Then
                                        If NomeFileXML.ToLower.EndsWith("xml") Then
                                            If EncodingFound = "base64" OrElse Buffer.IndexOf("FatturaElettronica") <> -1 Then
                                                Exit While
                                            Else
                                                Buffer = String.Empty

                                                NomeFileXML = String.Empty
                                            End If

                                        ElseIf NomeFileXML.ToLower.EndsWith("p7m") Then
                                            Exit While
                                        End If
                                    Else
                                        Exit While 'p7m
                                    End If
                                Else
                                    If EncodingFound = "quoted-printable" AndAlso Riga.EndsWith("=") Then
                                        Riga = Riga.Substring(0, Riga.Length - 1)
                                        Buffer &= Riga
                                    Else
                                        Buffer &= Riga & ControlChars.NewLine
                                    End If
                                End If

                                'If Riga.IndexOf(Boundary) <> -1 Then
                                '    Exit While
                                'Else
                                '    If EncodingFound = "quoted-printable" AndAlso Riga.EndsWith("=") Then
                                '        Riga = Riga.Substring(0, Riga.Length - 1)
                                '        Buffer &= Riga
                                '    Else
                                '        Buffer &= Riga & ControlChars.NewLine
                                '    End If

                                'End If


                                'If Buffer.IndexOf("FatturaElettronica") <> -1 Then
                                '    Exit While
                                'Else
                                '    Buffer = String.Empty

                                '    NomeFileXML = String.Empty
                                'End If

                                'Exit While
                                'Else
                                '    If EncodingFound = "quoted-printable" AndAlso Riga.EndsWith("=") Then
                                '        Riga = Riga.Substring(0, Riga.Length - 1)
                                '        Buffer &= Riga
                                '    Else
                                '        Buffer &= Riga & ControlChars.NewLine
                                '    End If

                            End If

                        End If



                    End While

                End Using
                Buffer = Buffer.Trim
                'Buffer = Buffer.Replace(vbCrLf, "")
                If NomeFileXML.Length Then
                    Dim PathFinale As String = PathFolder & NomeFileXML

                    If EncodingFound = "base64" Then
                        Buffer = Buffer.Replace(vbCrLf, "")
                        File.WriteAllBytes(PathFinale, Convert.FromBase64String(Buffer))
                    ElseIf EncodingFound = "quoted-printable" Then
                        Buffer = DecodeQuotedPrintables(Buffer)
                        Using w As New StreamWriter(PathFinale)
                            w.Write(Buffer)
                        End Using
                    ElseIf EncodingFound = "7bit" Then
                        Using w As New StreamWriter(PathFinale)
                            w.Write(Buffer)
                        End Using
                    End If

                    ris = PathFinale
                End If

                Exit For
            End If
        Next

        'If ris = String.Empty Then
        '    For Each a As MimePart In msgMail.EmbeddedObjects
        '        Dim NomeOggetto As String = String.Empty

        '        If Not a.ContentName Is Nothing Then
        '            NomeOggetto = a.ContentName
        '        End If
        '        If Not a.ContentName Is Nothing AndAlso a.ContentName.ToLower.EndsWith(".xml") Then
        '            FormerHelper.File.CreateLongPath(PathFolder)

        '            Dim NomeFile As String = PathFolder & a.ContentName
        '            Using f As New FileStream(NomeFile, FileMode.Create, FileAccess.Write)
        '                f.Write(a.BinaryContent, 0, a.BinaryContent.Length)
        '            End Using
        '        End If
        '    Next

        'End If

        Return ris
    End Function

    Public Shared Sub MonitoraggioPECEx(IdAzienda As Integer)

        LogMe("***Monitoraggio PEC " & MgrAziende.GetRagioneSociale(IdAzienda) & " ***")
        Try

            Dim Spostamenti As New Dictionary(Of Integer, String)
            Dim Scarti As New Dictionary(Of Integer, String)

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Using s As New Imap4Client()

                Dim NomeHost As String = "imaps.pec.aruba.it"

                Dim hs As New ActiveUp.Net.Security.SslHandShake(NomeHost, System.Security.Authentication.SslProtocols.Tls12)

                LogMe("CONNESSIONE SERVER IMAP")
                s.ConnectSsl(NomeHost, 993, hs)
                LogMe("LOGIN SERVER IMAP")
                s.Login(MgrAziende.GetPEC(IdAzienda), MgrAziende.GetPECPassword(IdAzienda))

                Dim m As Mailbox = s.SelectMailbox("inbox")
                Dim fetch As Fetch = m.Fetch

                Dim count As Integer = m.MessageCount

                LogMe("PRESENTI " & count & " MESSAGGI")

                Dim PathStart As String = FormerPath.PathTempLocale & IdAzienda 'MgrAziende.GetAziendaStr(IdAzienda)

                Try
                    IO.Directory.Delete(PathStart, True)
                Catch ex As Exception

                End Try

                If count Then
                    Dim TotMailEsterne As Integer = 0

                    For i As Integer = count To 1 Step -1
                        Dim Titolo As String = String.Empty
                        Try
                            Dim DaSpostare As Boolean = False
                            Dim DaScartare As Boolean = False

                            LogMe("RECUPERO MESSAGGIO " & i)
                            Dim msg As Message = fetch.MessageObject(i)
                            'Dim msgMail As MailMessage = msg.ToMailMessage

                            'Dim body As String = msgMail.Body
                            Titolo = msg.Subject
                            LogMe("--- " & Titolo)
                            'Dim ListaAllegati As New List(Of String)
                            Dim Mittente As String = msg.From.Email

                            Dim path As String = PathStart & "\" & i & "\"

                            FormerLib.FormerHelper.File.CreateLongPath(path)
                            Dim PathXML As String = ""
                            Dim BufferXML As String = ""
                            Dim PathEML As String = ""

                            Dim NuovoStato As enStatoFatturaFE = -1
                            Dim NuovoFolder As String = String.Empty

                            Dim TipoMail As enTipoMailPEC = enTipoMailPEC.Altro

                            If Titolo.StartsWith("ACCETTAZIONE: Invio File ", StringComparison.CurrentCultureIgnoreCase) Then
                                TipoMail = enTipoMailPEC.Accettazione
                            ElseIf Titolo.StartsWith("CONSEGNA: Invio File ", StringComparison.CurrentCultureIgnoreCase) Then 'OK
                                TipoMail = enTipoMailPEC.Consegna
                            ElseIf Titolo.StartsWith("POSTA CERTIFICATA: Notifica di scarto ", StringComparison.CurrentCultureIgnoreCase) Then
                                TipoMail = enTipoMailPEC.Scarto
                            ElseIf Titolo.StartsWith("POSTA CERTIFICATA: Ricevuta di consegna ", StringComparison.CurrentCultureIgnoreCase) Then
                                TipoMail = enTipoMailPEC.Ricevuta
                            ElseIf Titolo.StartsWith("POSTA CERTIFICATA: Notifica di mancata consegna ", StringComparison.CurrentCultureIgnoreCase) Then
                                TipoMail = enTipoMailPEC.MancataConsegna
                            ElseIf Titolo.StartsWith("POSTA CERTIFICATA: Invio File ", StringComparison.CurrentCultureIgnoreCase) Then
                                TipoMail = enTipoMailPEC.InvioFile
                            End If

                            If TipoMail = enTipoMailPEC.Accettazione Then 'OK
                                'qui è un accettazione di file inviati da noi 
                                'qui cerco dentro l'xml l'id del ricavo 
                                NuovoStato = enStatoFatturaFE.AccettataPEC

                                For Each a As MimePart In msg.EmbeddedObjects
                                    Dim NomeFileDest As String = a.ContentName
                                    If Not NomeFileDest Is Nothing AndAlso NomeFileDest.Length Then

                                        NomeFileDest = FormerLib.FormerHelper.Web.NormalizzaNomeFile(NomeFileDest)

                                        'NomeFileDest = R.Next(100, 999) & "_" & NomeFileDest

                                        Dim pathSing As String = path & NomeFileDest

                                        Using fs As New FileStream(pathSing, FileMode.Create)

                                            fs.Write(a.BinaryContent, 0, a.BinaryContent.Length)

                                        End Using

                                        If pathSing.EndsWith(".xml") Then
                                            PathXML = pathSing

                                            Using rXml As New StreamReader(PathXML)
                                                BufferXML = rXml.ReadToEnd
                                            End Using

                                        End If

                                        'ListaAllegati.Add(pathSing)
                                    End If
                                Next

                                Dim Oggetto As String = String.Empty
                                Oggetto = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "oggetto")
                                Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromOggetto(Oggetto)
                                If IdRicavo Then
                                    Using R As New Ricavo
                                        R.Read(IdRicavo)
                                        NuovoFolder = "INBOX.FE." & R.AnnoRiferimento & ".V." & R.DataRicavo.Month
                                        If R.StatoFE = enStatoFatturaFE.InviatoXML Then
                                            Dim Identificativo As String = String.Empty
                                            Identificativo = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "identificativo")
                                            R.IdMessaggioFE = Identificativo
                                            R.StatoFE = NuovoStato
                                            R.DataUltimoCambioStatoFE = Now
                                            R.Save()
                                            DaSpostare = True
                                        ElseIf R.StatoFE >= enStatoFatturaFE.AccettataPEC Then
                                            'qui la elimino perche è vecchia e gia presa in carico presumibilmente
                                            DaSpostare = True
                                        End If
                                    End Using
                                End If

                            ElseIf TipoMail = enTipoMailPEC.Consegna Then 'OK
                                'qui è stato consegnato 
                                'enStatoFatturaFE.ConsegnataDest 
                                NuovoStato = enStatoFatturaFE.ConsegnataPEC
                                'qui è un accettazione di file inviati da noi 
                                'qui cerco dentro l'xml l'id del ricavo 

                                For Each a As MimePart In msg.EmbeddedObjects
                                    Dim NomeFileDest As String = a.ContentName
                                    If Not NomeFileDest Is Nothing AndAlso NomeFileDest.Length Then

                                        NomeFileDest = FormerLib.FormerHelper.Web.NormalizzaNomeFile(NomeFileDest)

                                        'NomeFileDest = R.Next(100, 999) & "_" & NomeFileDest

                                        Dim pathSing As String = path & NomeFileDest

                                        Using fs As New FileStream(pathSing, FileMode.Create)

                                            fs.Write(a.BinaryContent, 0, a.BinaryContent.Length)

                                        End Using

                                        If pathSing.EndsWith(".xml") Then
                                            PathXML = pathSing

                                            Using rXml As New StreamReader(PathXML)
                                                BufferXML = rXml.ReadToEnd
                                            End Using

                                        End If

                                        'ListaAllegati.Add(pathSing)
                                    End If
                                Next

                                Dim Oggetto As String = String.Empty
                                Oggetto = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "oggetto")
                                Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromOggetto(Oggetto)
                                If IdRicavo Then
                                    Using R As New Ricavo
                                        R.Read(IdRicavo)
                                        NuovoFolder = "INBOX.FE." & R.AnnoRiferimento & ".V." & R.DataRicavo.Month
                                        If R.StatoFE = enStatoFatturaFE.AccettataPEC Then
                                            Dim Identificativo As String = String.Empty
                                            Identificativo = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "identificativo")
                                            R.IdMessaggioFE = Identificativo
                                            R.StatoFE = NuovoStato
                                            R.DataUltimoCambioStatoFE = Now
                                            R.Save()

                                            DaSpostare = True
                                        ElseIf R.StatoFE >= enStatoFatturaFE.ConsegnataPEC Then
                                            'qui la elimino perche è vecchia e gia presa in carico presumibilmente
                                            DaSpostare = True
                                        End If
                                    End Using
                                End If

                            ElseIf TipoMail = enTipoMailPEC.Scarto Then
                                'qui è stata scartata
                                'enStatoFatturaFE.ScartataSDI 

                                PathXML = ScaricaXMLFromEMLEx(msg, path, TipoMail)
                                Using rXml As New StreamReader(PathXML)
                                    BufferXML = rXml.ReadToEnd
                                End Using
                                NuovoStato = enStatoFatturaFE.ScartataSDI

                                Dim NomeFile As String = String.Empty
                                NomeFile = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "NomeFile")
                                Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromNomeFile(NomeFile, IdAzienda)

                                Dim BufferErrori As String = String.Empty

                                BufferErrori = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "ListaErrori")
                                If IdRicavo Then
                                    Using R As New Ricavo
                                        R.Read(IdRicavo)
                                        NuovoFolder = "INBOX.FE." & R.AnnoRiferimento & ".V." & R.DataRicavo.Month
                                        If R.StatoFE = enStatoFatturaFE.InviatoXML OrElse
                                            R.StatoFE = enStatoFatturaFE.AccettataPEC OrElse
                                            R.StatoFE = enStatoFatturaFE.ConsegnataPEC Then
                                            R.RicevutaXML = BufferXML
                                            R.StatoFE = NuovoStato
                                            R.InfoFE = BufferErrori 'IIf(BufferErrori.Length > 250, BufferErrori.Substring(0, 250), BufferErrori)
                                            R.DataUltimoCambioStatoFE = Now
                                            R.Save()

                                            DaSpostare = True
                                        ElseIf R.StatoFE >= enStatoFatturaFE.ScartataSDI Then
                                            'qui la elimino perche è vecchia e gia presa in carico presumibilmente
                                            DaSpostare = True
                                        End If
                                    End Using
                                End If

                            ElseIf TipoMail = enTipoMailPEC.Ricevuta Then

                                PathXML = ScaricaXMLFromEMLEx(msg, path, TipoMail)
                                Using rXml As New StreamReader(PathXML)
                                    BufferXML = rXml.ReadToEnd
                                End Using

                                Dim testo As String = String.Empty
                                For Each a As MimePart In msg.EmbeddedObjects
                                    If Not a.ContentName Is Nothing AndAlso a.ContentName.EndsWith(".eml") Then

                                        Dim NomeFileEml As String = path & a.ContentName
                                        Using f As New FileStream(NomeFileEml, FileMode.Create, FileAccess.Write)
                                            f.Write(a.BinaryContent, 0, a.BinaryContent.Length)
                                        End Using

                                        'Dim Buffer As String = String.Empty

                                        Using r As New StreamReader(NomeFileEml)
                                            testo = r.ReadToEnd
                                        End Using
                                        Exit For

                                    End If
                                Next
                                If testo.Length Then
                                    Dim espressione As String = "sdi([0-9]){1,50}@pec.fatturapa.it"

                                    Dim risultato As Match = Regex.Match(testo, espressione)

                                    If Not risultato Is Nothing Then
                                        If risultato.Success Then
                                            'qui devo salvare la mail da utilizzare come destinatario nei prossimi invii
                                            If MgrAziende.GetPECSDI(IdAzienda) <> risultato.Value Then
                                                MgrAziende.SavePECSDI(IdAzienda, risultato.Value)
                                            End If


                                        End If
                                    End If
                                End If

                                'NuovoStato = enStatoFatturaFE.RicevutaDiConsegna

                                ''qui è stata scartata
                                ''enStatoFatturaFE.ScartataSDI 
                                NuovoStato = enStatoFatturaFE.ConsegnataDestinatario
                                Dim IdentificativoSDI As String = String.Empty
                                IdentificativoSDI = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "IdentificativoSdI")
                                'Dim PecMessageID As String = String.Empty
                                'PecMessageID = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "PecMessageID")
                                Dim NomeFile As String = String.Empty
                                NomeFile = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "NomeFile")
                                Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromNomeFile(NomeFile, IdAzienda)
                                If IdRicavo Then
                                    Using R As New Ricavo
                                        R.Read(IdRicavo)
                                        NuovoFolder = "INBOX.FE." & R.AnnoRiferimento & ".V." & R.DataRicavo.Month
                                        If R.StatoFE = enStatoFatturaFE.InviatoXML OrElse
                                            R.StatoFE = enStatoFatturaFE.AccettataPEC OrElse
                                           R.StatoFE = enStatoFatturaFE.ConsegnataPEC OrElse
                                           R.StatoFE = enStatoFatturaFE.NonConsegnataDestinatario Then
                                            R.IdentificativoSdI = IdentificativoSDI
                                            'R.IdMessaggioFE = PecMessageID
                                            R.RicevutaXML = BufferXML
                                            R.StatoFE = NuovoStato
                                            R.DataUltimoCambioStatoFE = Now
                                            R.Save()

                                            Try
                                                Dim PathDestXML As String = FormerConfig.FormerPath.PathFattureFE & R.AnnoRiferimento & "\" & R.IdAzienda & "\" & FormerLib.FormerHelper.File.EstraiNomeFile(PathXML)
                                                FormerHelper.File.CreateLongPath(PathDestXML)
                                                FileCopy(PathXML, PathDestXML)
                                            Catch ex As Exception

                                            End Try
                                            DaSpostare = True
                                        ElseIf R.StatoFE >= enStatoFatturaFE.ConsegnataDestinatario Then
                                            'qui la elimino perche è vecchia e gia presa in carico presumibilmente
                                            DaSpostare = True
                                        End If
                                    End Using
                                End If
                            ElseIf TipoMail = enTipoMailPEC.MancataConsegna Then
                                'qui è stata scartata
                                'enStatoFatturaFE.ScartataSDI 

                                PathXML = ScaricaXMLFromEMLEx(msg, path, TipoMail)
                                Using rXml As New StreamReader(PathXML)
                                    BufferXML = rXml.ReadToEnd
                                End Using
                                NuovoStato = enStatoFatturaFE.NonConsegnataDestinatario

                                Dim NomeFile As String = String.Empty
                                NomeFile = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "NomeFile")
                                Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromNomeFile(NomeFile, IdAzienda)
                                Dim IdentificativoSDI As String = String.Empty
                                IdentificativoSDI = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "IdentificativoSdI")
                                Dim BufferErrori As String = String.Empty

                                BufferErrori = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "Descrizione")
                                If IdRicavo Then
                                    Using R As New Ricavo
                                        R.Read(IdRicavo)
                                        NuovoFolder = "INBOX.FE." & R.AnnoRiferimento & ".V." & R.DataRicavo.Month
                                        If R.StatoFE = enStatoFatturaFE.InviatoXML OrElse
                                            R.StatoFE = enStatoFatturaFE.AccettataPEC OrElse
                                            R.StatoFE = enStatoFatturaFE.ConsegnataPEC Then
                                            R.RicevutaXML = BufferXML
                                            R.IdentificativoSdI = IdentificativoSDI
                                            R.StatoFE = NuovoStato
                                            R.InfoFE = IIf(BufferErrori.Length > 250, BufferErrori.Substring(0, 250), BufferErrori)
                                            R.DataUltimoCambioStatoFE = Now
                                            R.Save()

                                            'QUI VA MANDATO L'AVVISO AL CLIENTE

                                            Dim tempM As New My.Templates.MailFatturaNonConsegnata

                                            Dim TestoMail As String = tempM.TransformText

                                            Try
                                                FormerHelper.Mail.InviaMail("Mancato recapito fattura elettronica",
                                                                            TestoMail,
                                                                            R.VoceRubrica.Email)
                                            Catch ex As Exception

                                            End Try

                                            DaSpostare = True
                                        ElseIf R.StatoFE >= enStatoFatturaFE.NonConsegnataDestinatario Then
                                            'qui la elimino perche è vecchia e gia presa in carico presumibilmente
                                            DaSpostare = True
                                        End If
                                    End Using
                                End If

                            ElseIf TipoMail = enTipoMailPEC.InvioFile Then
                                'qui è stata ricevuta una fattura
                                'NuovoStato = enStatoFatturaFE.AllegatoXMLRicevuto
                                PathXML = ScaricaXMLFromEMLEx(msg, path, TipoMail)

                                If PathXML.ToLower.EndsWith("xml") = False Then
                                    PathXML = MgrFattureFE.ReadXmlSigned(PathXML, False)
                                End If

                                'Using rXml As New StreamReader(PathXML)
                                '    BufferXML = rXml.ReadToEnd
                                'End Using

                                Dim F As FatturaElettronica = MgrFattureFE.GetFatturaFromXML(PathXML)

                                Dim RisSalvataggio As RisSalvaCostoDaFatturaElettronica = MgrFattureFE.SalvaCostoDaFatturaElettronica(F, PathXML)

                                If Not RisSalvataggio.Errore Is Nothing Then
                                    Throw New Exception("Errore nel salvataggio di un documento fiscale ricevuto: " & PathXML & "<br>" & RisSalvataggio.Errore.Message)
                                Else

                                    MgrDocumentiFiscali.AggiornaStatoCostoDopoPagamento(RisSalvataggio.IdCostoSalvato)

                                    DaSpostare = RisSalvataggio.DaSpostare
                                    DaScartare = RisSalvataggio.DaScartare
                                    NuovoFolder = RisSalvataggio.NuovoFolder
                                End If

                                ''NuovoStato = enStatoFatturaFE.AllegatoXMLRicevuto


                                'Dim BufferF As String = BufferXML
                                ''Using reader As StreamReader = New StreamReader(PathXML)
                                ''    BufferF = reader.ReadToEnd
                                ''End Using

                                'Dim TipoDocumento As enTipoDocumento = MgrFattureFE.GetTipoDocumento(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.TipoDocumento)

                                'If TipoDocumento = enTipoDocumento.Fattura OrElse
                                '   TipoDocumento = enTipoDocumento.NotaDiCredito OrElse
                                '   TipoDocumento = enTipoDocumento.NotaDiDebito OrElse
                                '   TipoDocumento = enTipoDocumento.AccontoAnticipoSuFattura Then
                                '    'FATTURA
                                '    Dim IdRub As Integer = 0
                                '    Dim IdAziendaCosto As Integer = 0
                                '    'Dim TipoFattura As enTipoDocumento = enTipoDocumento.Fattura
                                '    'Dim NumeroFattura As String = String.Empty
                                '    Dim ListaDDT As List(Of DatiDDT) = Nothing

                                '    If Not F.FatturaElettronicaBody.DatiGenerali.DatiDDT Is Nothing AndAlso F.FatturaElettronicaBody.DatiGenerali.DatiDDT.Count AndAlso TipoDocumento = enTipoDocumento.Fattura Then
                                '        TipoDocumento = enTipoDocumento.FatturaRiepilogativa
                                '        ListaDDT = F.FatturaElettronicaBody.DatiGenerali.DatiDDT
                                '        'Else
                                '        '    TipoDocumento = enTipoDocumento.Fattura
                                '    End If

                                '    Using mgr As New VociRubricaDAO
                                '        Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Piva, F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice),
                                '                                                    New LUNA.LunaSearchParameter(LFM.VoceRubrica.IsFornitore, enSiNo.Si))
                                '        If l.Count Then
                                '            IdRub = l(0).IdRub
                                '        End If

                                '        Using r As New VoceRubrica
                                '            If IdRub Then r.Read(IdRub) 'qui in caso aggiorno i dati 
                                '            r.RagSoc = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione, VbStrConv.ProperCase)
                                '            r.Nome = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Nome, VbStrConv.ProperCase)
                                '            r.Cognome = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Cognome, VbStrConv.ProperCase)
                                '            r.Indirizzo = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.Sede.Indirizzo & " " & F.FatturaElettronicaHeader.CedentePrestatore.Sede.NumeroCivico, VbStrConv.ProperCase)
                                '            r.CodFisc = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.CodiceFiscale
                                '            r.Piva = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice
                                '            If IdRub = 0 Then
                                '                r.Tipo = enTipoRubrica.Cliente 'enTipoRubrica.Fornitore
                                '                r.IsFornitore = enSiNo.Si
                                '            End If

                                '            If Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti Is Nothing Then
                                '                r.Tel = IIf(Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Telefono Is Nothing, F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Telefono, "")
                                '                r.Fax = IIf(Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Fax Is Nothing, F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Fax, "")
                                '                If r.Email.Length = 0 OrElse r.Email = FormerConst.EmailNonDisponibile Then r.Email = IIf(Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Email Is Nothing, F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Email, "")
                                '            End If

                                '            If IdRub = 0 Then r.IdPagamento = enMetodoPagamento.AllaConsegna
                                '            If IdRub = 0 Then r.Pagamento = FormerEnumHelper.TipoPagamentoStr(r.IdPagamento)
                                '            If IdRub = 0 Then r.TipoDoc = enTipoDocumento.Fattura
                                '            If IdRub = 0 Then r.DataIns = Now
                                '            If IdRub = 0 Then r.IdCorriere = enTipoCorriere.ConTariffa

                                '            If IdRub = 0 Then r.Sorgente = "F"
                                '            r.PrefissoPiva = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese
                                '            'r.Provincia
                                '            'r.IdProvincia
                                '            'r.IdComune



                                '            Using MgrC As New ElencoComuniDAO
                                '                Dim lC As List(Of ComuneInElenco) = Nothing
                                '                Dim IdNazione As Integer = FormerConst.Culture.IdItalia

                                '                If F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.Length AndAlso F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.ToUpper <> "IT" Then
                                '                    'qui vado a selezionare o inserire la nuova nazione
                                '                    Using mgrN As New NazioniDAO
                                '                        Dim lN As List(Of Nazione) = mgrN.FindAll(New LUNA.LunaSearchParameter(LFM.Nazione.Code, F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.ToUpper))

                                '                        If lN.Count Then
                                '                            Using Naz As Nazione = lN(0)
                                '                                IdNazione = Naz.IdNazione
                                '                            End Using
                                '                        Else
                                '                            'qui la devo inserire
                                '                            Using naz As New Nazione
                                '                                naz.Code = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.ToUpper
                                '                                naz.Nazione = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Nazione.ToUpper
                                '                                naz.Save()
                                '                                IdNazione = naz.IdNazione
                                '                            End Using
                                '                        End If
                                '                    End Using

                                '                End If

                                '                If IdNazione = FormerConst.Culture.IdItalia Then
                                '                    Dim paramProv As LUNA.LunaSearchParameter = Nothing

                                '                    If Not F.FatturaElettronicaHeader.CedentePrestatore.Sede.Provincia Is Nothing Then
                                '                        paramProv = New LUNA.LunaSearchParameter(LFM.ComuneInElenco.Provincia, F.FatturaElettronicaHeader.CedentePrestatore.Sede.Provincia)
                                '                    End If

                                '                    lC = MgrC.FindAll(New LUNA.LunaSearchParameter(LFM.ComuneInElenco.CAP, F.FatturaElettronicaHeader.CedentePrestatore.Sede.CAP),
                                '                                                                   New LUNA.LunaSearchParameter(LFM.ComuneInElenco.Comune, F.FatturaElettronicaHeader.CedentePrestatore.Sede.Comune),
                                '                                                                   paramProv)
                                '                Else
                                '                    lC = New List(Of ComuneInElenco)
                                '                End If

                                '                If lC.Count = 1 Then
                                '                    Using CinE As ComuneInElenco = lC(0)
                                '                        r.IdComune = CinE.IDCap
                                '                        r.CAP = CinE.CAP
                                '                        r.Citta = CinE.Comune
                                '                        r.Provincia = CinE.Provincia
                                '                        r.IdProvincia = CinE.ProvinciaSel.ID
                                '                        r.IdNazione = FormerConst.Culture.IdItalia
                                '                    End Using
                                '                Else
                                '                    r.CAP = F.FatturaElettronicaHeader.CedentePrestatore.Sede.CAP
                                '                    r.Citta = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Comune
                                '                    r.Provincia = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Provincia
                                '                    r.IdNazione = IdNazione
                                '                End If

                                '            End Using
                                '            If r.IsChanged Then
                                '                r.LastUpdate = Now
                                '                IdRub = r.Save
                                '            End If

                                '        End Using
                                '    End Using

                                '    If F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSnc) Then
                                '        IdAziendaCosto = MgrAziende.IdAziende.AziendaSnc
                                '    ElseIf F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSrl) Then
                                '        IdAziendaCosto = MgrAziende.IdAziende.AziendaSrl
                                '    Else
                                '        DaScartare = True
                                '        NuovoFolder = "INBOX.FE.Scartate"
                                '    End If

                                '    If DaScartare = False Then
                                '        'End Using
                                '        If IdRub Then
                                '            Using r As New VoceRubrica
                                '                r.Read(IdRub)
                                '                'qui vado a creare una transaction box
                                '                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                                '                    Try
                                '                        Using C As New Costo
                                '                            C.IdRub = IdRub
                                '                            C.IdAzienda = IdAziendaCosto
                                '                            C.Descrizione = F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Causale
                                '                            C.DataCosto = MgrFattureFE.GetDataFromFormatoFE(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Data)
                                '                            C.Numero = F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero

                                '                            C.DocXML = BufferF
                                '                            C.StatoFE = enStatoFatturaFE.AllegatoXMLRicevuto
                                '                            C.StatoFEInterno = enStatoFEInterno.Inserito
                                '                            C.DataOraRicezione = Now
                                '                            C.IdStato = enStatoDocumentoFiscale.RegistratoAutomaticamente
                                '                            C.Tipo = TipoDocumento

                                '                            'Dim DatiRiepilogoMain As DatiRiepilogo = F.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo(0)

                                '                            Dim TotaleNetto As Decimal = 0
                                '                            Dim TotaleIva As Decimal = 0
                                '                            Dim AliquotaIva As Integer = -1
                                '                            Dim MultiIva As Boolean = False

                                '                            For Each dato As DatiRiepilogo In F.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo

                                '                                TotaleNetto += MgrFattureFE.GetDecimalFromFormatoFE(dato.ImponibileImporto)
                                '                                TotaleIva += MgrFattureFE.GetDecimalFromFormatoFE(dato.Imposta)
                                '                                If MultiIva = False Then
                                '                                    If AliquotaIva = -1 Then
                                '                                        AliquotaIva = MgrFattureFE.GetIvaFromFormatoFE(dato.AliquotaIVA)
                                '                                    Else
                                '                                        If AliquotaIva <> MgrFattureFE.GetIvaFromFormatoFE(dato.AliquotaIVA) Then
                                '                                            MultiIva = True
                                '                                        End If
                                '                                    End If
                                '                                End If
                                '                            Next

                                '                            If TipoDocumento = enTipoDocumento.NotaDiCredito Then
                                '                                C.Importo = Math.Abs(TotaleNetto)
                                '                                C.Iva = Math.Abs(TotaleIva)
                                '                                C.Totale = Math.Abs(MgrFattureFE.GetDecimalFromFormatoFE(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.ImportoTotaleDocumento)) 'C.Importo + C.Iva)
                                '                            Else
                                '                                C.Importo = TotaleNetto
                                '                                C.Iva = TotaleIva
                                '                                C.Totale = MgrFattureFE.GetDecimalFromFormatoFE(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.ImportoTotaleDocumento) 'C.Importo + C.Iva)
                                '                            End If

                                '                            'C.PercIva = MgrFattureFE.GetIvaFromFormatoFE(DatiRiepilogoMain.AliquotaIVA)
                                '                            If MultiIva Then
                                '                                C.PercIva = FormerConst.Fiscali.PercentualeMultiIva
                                '                            Else
                                '                                C.PercIva = AliquotaIva
                                '                            End If
                                '                            C.IdCat = r.IdCatContab
                                '                            'c.costocorr
                                '                            'c.speseincasso
                                '                            'c.addebitivari

                                '                            'PRIMA DI SALVARE CONTROLLO CHE IL DOCUMENTO NON SIA STATO GIA LAVORATO
                                '                            Dim ParamTipoDocumento As String = String.Empty
                                '                            If TipoDocumento = enTipoDocumento.Fattura OrElse TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
                                '                                ParamTipoDocumento = "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & ")"
                                '                            Else
                                '                                ParamTipoDocumento = "(" & TipoDocumento & ")"
                                '                            End If

                                '                            Using mgrC As New CostiDAO
                                '                                Dim lC As List(Of Costo) = mgrC.FindAll(New LUNA.LunaSearchParameter(LFM.Costo.Numero, C.Numero),
                                '                                                                        New LUNA.LunaSearchParameter(LFM.Costo.IdRub, C.IdRub),
                                '                                                                        New LUNA.LunaSearchParameter(LFM.Costo.IdAzienda, C.IdAzienda),
                                '                                                                        New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, ParamTipoDocumento, "IN"),
                                '                                                                        New LUNA.LunaSearchParameter("YEAR(DataCosto)", C.DataCosto.Year))
                                '                                If lC.Count = 0 Then
                                '                                    'qui la vado a salvare
                                '                                    Dim IdCosto As Integer = 0

                                '                                    'vado a copiare l'xml nella cartella corretta
                                '                                    Dim PathFinale As String = FormerPath.PathFattureAcquisto & "FE\" & C.AnnoStr & "\" & C.IdAzienda & "\" & FormerLib.FormerHelper.File.EstraiNomeFile(PathXML)
                                '                                    FormerLib.FormerHelper.File.CreateLongPath(PathFinale)

                                '                                    File.Copy(PathXML, PathFinale, True)
                                '                                    Dim OkPagam As Boolean = True
                                '                                    Dim Pag As Pagamento = Nothing
                                '                                    If Not F.FatturaElettronicaBody.DatiPagamento Is Nothing AndAlso
                                '                                        Not F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento Is Nothing AndAlso
                                '                                        Not F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento Is Nothing Then

                                '                                        Dim DataScadenzaPagamento As Date = MgrFattureFE.GetDataFromFormatoFE(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento)
                                '                                        C.DataPrevPagam = DataScadenzaPagamento
                                '                                    Else
                                '                                        C.DataPrevPagam = C.DataCosto
                                '                                        OkPagam = False
                                '                                    End If

                                '                                    'qui salvo effettivamente il costo
                                '                                    tb.TransactionBegin()
                                '                                    IdCosto = C.Save

                                '                                    NuovoFolder = "INBOX.FE." & C.AnnoStr & ".A." & C.DataCosto.Month

                                '                                    Dim ListaDDTSalvati As New List(Of Costo)
                                '                                    If TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
                                '                                        For Each DDT In ListaDDT
                                '                                            'vado a salvare i vari ddt
                                '                                            If ListaDDTSalvati.Find(Function(x) x.Numero = DDT.NumeroDDT) Is Nothing Then
                                '                                                Using NewDDT As New Costo
                                '                                                    NewDDT.IdRub = IdRub
                                '                                                    NewDDT.IdAzienda = IdAziendaCosto
                                '                                                    NewDDT.Descrizione = "DDT"
                                '                                                    NewDDT.DataCosto = MgrFattureFE.GetDataFromFormatoFE(DDT.DataDDT)
                                '                                                    NewDDT.Numero = DDT.NumeroDDT
                                '                                                    NewDDT.IdStato = enStatoDocumentoFiscale.RegistratoAutomaticamente
                                '                                                    NewDDT.Tipo = enTipoDocumento.DDT
                                '                                                    NewDDT.IdDocRif = C.IdCosto
                                '                                                    NewDDT.DataPrevPagam = NewDDT.DataCosto
                                '                                                    NewDDT.StatoFEInterno = enStatoFEInterno.Inserito
                                '                                                    NewDDT.IdCat = C.IdCat
                                '                                                    NewDDT.Save()
                                '                                                    ListaDDTSalvati.Add(NewDDT)
                                '                                                End Using
                                '                                            End If

                                '                                        Next
                                '                                    End If

                                '                                    If Not F.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee Is Nothing Then
                                '                                        For Each Linea In F.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee
                                '                                            Dim IdCostoLinea As Integer = IdCosto

                                '                                            If TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
                                '                                                For Each DDT In ListaDDT
                                '                                                    If Not DDT.RiferimentoNumeroLinea Is Nothing AndAlso DDT.RiferimentoNumeroLinea.FindAll(Function(x) x = Linea.NumeroLinea).Count Then
                                '                                                        IdCostoLinea = ListaDDTSalvati.Find(Function(x) x.Numero = DDT.NumeroDDT).IdCosto
                                '                                                        Exit For
                                '                                                    End If
                                '                                                Next

                                '                                                If IdCostoLinea = IdCosto Then
                                '                                                    'qui non e' riuscito a trovare il ddt
                                '                                                    If ListaDDTSalvati.Count = 1 Then
                                '                                                        'se dentro la fattura c'e' un solo ddt e non hanno messo il riferimento li aggancio in automatico all'unico che trovo
                                '                                                        IdCostoLinea = ListaDDTSalvati(0).IdCosto
                                '                                                    End If
                                '                                                End If

                                '                                            End If

                                '                                            Using Voce As New VoceCosto
                                '                                                Voce.IdCosto = IdCostoLinea
                                '                                                If Not Linea.CodiceArticolo Is Nothing Then
                                '                                                    Voce.Codice = Linea.CodiceArticolo.CodiceValore
                                '                                                End If
                                '                                                Voce.Descrizione = Linea.Descrizione
                                '                                                If Not Linea.Quantita Is Nothing AndAlso Linea.Quantita.Length > 0 Then
                                '                                                    Voce.Qta = MgrFattureFE.GetDecimalFromFormatoFE(Linea.Quantita)
                                '                                                Else
                                '                                                    Voce.Qta = 1
                                '                                                End If
                                '                                                If Not Linea.UnitaMisura Is Nothing AndAlso Linea.UnitaMisura.Length > 0 Then
                                '                                                    Voce.Um = Linea.UnitaMisura
                                '                                                End If
                                '                                                If Not Linea.TipoCessionePrestazione Is Nothing AndAlso Linea.TipoCessionePrestazione.Length > 0 Then
                                '                                                    Voce.TipoCessionePrestazione = Linea.TipoCessionePrestazione
                                '                                                End If
                                '                                                If TipoDocumento = enTipoDocumento.NotaDiCredito Then
                                '                                                    Voce.PrezzoUnit = Math.Abs(MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoUnitario))
                                '                                                    Voce.Totale = Math.Abs(MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoTotale))

                                '                                                Else
                                '                                                    Voce.PrezzoUnit = MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoUnitario)
                                '                                                    Voce.Totale = MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoTotale)

                                '                                                End If
                                '                                                Voce.AliquotaIva = MgrFattureFE.GetDecimalFromFormatoFE(Linea.AliquotaIVA)
                                '                                                Voce.idCat = C.IdCat
                                '                                                Voce.Save()
                                '                                            End Using
                                '                                        Next
                                '                                    End If

                                '                                    Dim SalvarePagamento As Boolean = False

                                '                                    'Using R As New VoceRubrica
                                '                                    '    R.Read(IdRub)
                                '                                    If r.RegistraAutomaticamentePagamenti = enSiNo.Si Then
                                '                                        SalvarePagamento = True
                                '                                    Else
                                '                                        If OkPagam = True AndAlso MgrFattureFE.InserirePagamento(F) Then
                                '                                            SalvarePagamento = True
                                '                                        End If
                                '                                    End If
                                '                                    'End Using

                                '                                    If SalvarePagamento Then
                                '                                        Pag = New Pagamento
                                '                                        Pag.IdRub = C.IdRub
                                '                                        Pag.Tipo = enTipoVoceContab.VoceAcquisto
                                '                                        Pag.IdFat = C.IdCosto
                                '                                        Pag.Importo = MgrFattureFE.GetDecimalFromFormatoFE(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ImportoPagamento)
                                '                                        Pag.DataPag = C.DataPrevPagam
                                '                                        Pag.IdTipoPagamento = MgrFattureFE.GetIdTipoPagamento(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento)
                                '                                        Pag.Save()
                                '                                    End If

                                '                                    tb.TransactionCommit()
                                '                                Else
                                '                                    Using CRif As Costo = lC(0)
                                '                                        NuovoFolder = "INBOX.FE." & CRif.AnnoStr & ".A." & CRif.DataCosto.Month
                                '                                    End Using
                                '                                End If
                                '                            End Using
                                '                            DaSpostare = True

                                '                        End Using
                                '                    Catch ex As Exception
                                '                        tb.TransactionRollBack()
                                '                    End Try

                                '                End Using
                                '            End Using



                                '        End If
                                '    End If



                                'End If

                                'DaEliminare = False
                            ElseIf TipoMail = enTipoMailPEC.Altro Then
                                TotMailEsterne += 1
                            End If

                            If DaSpostare Then

                                Spostamenti.Add(i, NuovoFolder)

                                Try
                                    Dim t As Mailbox = s.SelectMailbox(NuovoFolder)
                                Catch ex As Exception
                                    ''non esiste la creo
                                    s.CreateMailbox(NuovoFolder)

                                End Try

                                ''fetch.i
                                ''s.AllMailboxes("inbox").mo
                                ''m.MoveMessage(i, NuovoFolder)
                                ''Dim Uid As Integer = fetch.Uid(i)
                                'm.MoveMessage(i, NuovoFolder)
                            End If

                            If DaScartare Then

                                Spostamenti.Add(i, NuovoFolder)

                                Try
                                    Dim t As Mailbox = s.SelectMailbox(NuovoFolder)
                                Catch ex As Exception
                                    ''non esiste la creo
                                    s.CreateMailbox(NuovoFolder)

                                End Try

                                ''fetch.i
                                ''s.AllMailboxes("inbox").mo
                                ''m.MoveMessage(i, NuovoFolder)
                                ''Dim Uid As Integer = fetch.Uid(i)
                                'm.MoveMessage(i, NuovoFolder)
                            End If

                        Catch ex As Exception
                            LogMe("ERRORE Monitoraggio PEC MAIL '" & Titolo & "'",, ex)
                        End Try
                    Next

                    If TotMailEsterne Then
                        FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Notifica, TotMailEsterne & " PEC " & MgrAziende.GetAziendaStr(IdAzienda) & " da controllare MANUALMENTE!", FormerLib.FormerUDP.DestUDP_Admin)
                    End If


                    m = s.SelectMailbox("inbox")

                    For Each Valore In Spostamenti
                        Try
                            m.MoveMessage(Valore.Key, Valore.Value)
                        Catch ex As Exception
                            LogMe("ERRORE Spostamento PEC '" & Valore.Key & " to " & Valore.Value & "'",, ex)
                        End Try

                    Next

                End If
                s.Disconnect()

            End Using

            'Using s As New Imap4Client()

            '    Dim NomeHost As String = "imaps.pec.aruba.it"

            '    Dim hs As New ActiveUp.Net.Security.SslHandShake(NomeHost, System.Security.Authentication.SslProtocols.Tls12)

            '    s.ConnectSsl(NomeHost, 993, hs)

            '    s.Login(MgrAziende.GetPEC(IdAzienda), MgrAziende.GetPECPassword(IdAzienda))

            '    Dim m As Mailbox = s.SelectMailbox("inbox")

            '    Dim Contatore As Integer = m.MessageCount

            '    'Dim ids = m.Search("")
            '    Dim fetch As Fetch = m.Fetch

            '    For I = m.MessageCount To 1 Step -1
            '        Dim msg As Message = fetch.MessageObject(I)
            '        Try

            '            'Threading.Thread.Sleep(10000)
            '            'Dim Titolo As String = msg.Subject
            '            'If msg.Subject.StartsWith("ACCETTAZIONE") Then




            '            Dim FolderRif As String = String.Empty
            '            If Spostamenti.TryGetValue(I, FolderRif) Then
            '                m.MoveMessage(I, FolderRif)
            '            End If
            '            'End If
            '        Catch ex As Exception
            '            LogMe("ERRORE Spostamento PEC '" & msg.Subject & "'",, ex)
            '        End Try


            '    Next

            '    s.Disconnect()

            'End Using

        Catch ex As Exception
            LogMe("ERRORE GENERALE Monitoraggio PEC",, ex)
        End Try
        LogMe("***FINE Monitoraggio PEC***")
    End Sub



    'Public Shared Function CaricoMagazzinoDaCosto(C As Costo, Optional CreaNuovoInCaso As Boolean = False) As CaricoDiMagazzino

    '    Dim ris As CaricoDiMagazzino = Nothing

    '    Using mgr As New CarichiDiMagazzinoDAO
    '        Dim l As List(Of CaricoDiMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.NumeroDocRiferimento, C.Numero),
    '                                                          New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdRub, C.IdRub),
    '                                                          New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.TipoDocRiferimento, C.Tipo),
    '                                                          New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdAzienda, C.IdAzienda))

    '        If l.Count Then
    '            'qui lo lego 

    '            ris = l(0)
    '            LogMe("Trovato Carico " & ris.IdCaricoMagazzino)
    '            If ris.IdCosto <> C.IdCosto Then
    '                ris.IdCosto = C.IdCosto
    '            End If

    '            If ris.IdCaricoMagazzino <> C.IdCaricoMagazzino Then
    '                C.IdCaricoMagazzino = ris.IdCaricoMagazzino
    '            End If

    '            ris.IdStatoInterno = enStatoFEInterno.Collegato
    '            ris.Save()

    '        Else
    '            If CreaNuovoInCaso Then
    '                LogMe("Creo Carico NUOVO")
    '                'qui lo creo
    '                ris = New CaricoDiMagazzino
    '                ris.IdAzienda = C.IdAzienda
    '                ris.DataCarico = Now
    '                ris.IdUtCarico = FormerConst.UtentiSpecifici.IdUtenteAdmin
    '                ris.IdRub = C.IdRub
    '                ris.NumeroDocRiferimento = C.Numero
    '                Dim TipoDoc As enTipoDocumento
    '                If C.Tipo = enTipoDocumento.FatturaRiepilogativa OrElse C.Tipo = enTipoDocumento.Fattura Then
    '                    TipoDoc = enTipoDocumento.Fattura
    '                ElseIf C.Tipo = enTipoDocumento.DDT Then
    '                    TipoDoc = enTipoDocumento.DDT
    '                End If
    '                ris.TipoDocRiferimento = TipoDoc
    '                ris.IdCosto = C.IdCosto
    '                ris.IdStatoInterno = enStatoFEInterno.Collegato
    '                ris.Save()
    '            End If

    '        End If

    '    End Using

    '    Return ris

    'End Function

    'Public Shared Sub MonitoraggioPEC(IdAzienda As Integer)

    '    LogMe("***Monitoraggio PEC " & MgrAziende.GetRagioneSociale(IdAzienda) & " ***")
    '    Try
    '        Using p As New OpenPop.Pop3.Pop3Client

    '            p.Connect("pop3s.pec.aruba.it", 995, True)

    '            p.Authenticate(MgrAziende.GetPEC(IdAzienda),
    '                           MgrAziende.GetPECPassword(IdAzienda),
    '                           OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword)

    '            Dim count As Integer = p.GetMessageCount()
    '            Dim PathStart As String = FormerPath.PathTempLocale & IdAzienda 'MgrAziende.GetAziendaStr(IdAzienda)

    '            Try
    '                IO.Directory.Delete(PathStart, True)
    '            Catch ex As Exception

    '            End Try

    '            If count Then
    '                For i As Integer = count To 1 Step -1
    '                    Dim Titolo As String = String.Empty
    '                    Try
    '                        Dim DaEliminare As Boolean = False

    '                        Dim msg As OpenPop.Mime.Message = p.GetMessage(i)
    '                        Dim msgMail As MailMessage = msg.ToMailMessage

    '                        'Dim body As String = msgMail.Body
    '                        Titolo = msgMail.Subject
    '                        Dim ListaAllegati As New List(Of String)
    '                        Dim Mittente As String = msgMail.From.Address

    '                        Dim path As String = PathStart & "\" & i & "\"

    '                        FormerLib.FormerHelper.File.CreateLongPath(path)
    '                        Dim PathXML As String = ""
    '                        Dim BufferXML As String = ""
    '                        Dim PathEML As String = ""

    '                        If msgMail.Attachments.Count Then
    '                            For Each a As Attachment In msgMail.Attachments

    '                                Dim NomeFileDest As String = a.Name

    '                                Randomize()
    '                                Dim R As New Random

    '                                NomeFileDest = FormerLib.FormerHelper.Web.NormalizzaNomeFile(NomeFileDest)

    '                                'NomeFileDest = R.Next(100, 999) & "_" & NomeFileDest

    '                                Dim pathSing As String = path & NomeFileDest

    '                                Using fs As New FileStream(pathSing, FileMode.Create)

    '                                    a.ContentStream.CopyTo(fs)

    '                                End Using

    '                                If pathSing.EndsWith(".xml") Then
    '                                    PathXML = pathSing

    '                                    Using rXml As New StreamReader(PathXML)
    '                                        BufferXML = rXml.ReadToEnd
    '                                    End Using

    '                                End If

    '                                ListaAllegati.Add(pathSing)

    '                            Next
    '                        End If

    '                        Dim NuovoStato As enStatoFatturaFE = -1

    '                        Dim TipoMail As enTipoMailPEC = enTipoMailPEC.Altro

    '                        If Titolo.StartsWith("ACCETTAZIONE: Invio File ", StringComparison.CurrentCultureIgnoreCase) Then
    '                            TipoMail = enTipoMailPEC.Accettazione
    '                        ElseIf Titolo.StartsWith("CONSEGNA: Invio File ", StringComparison.CurrentCultureIgnoreCase) Then 'OK
    '                            TipoMail = enTipoMailPEC.Consegna
    '                        ElseIf Titolo.StartsWith("POSTA CERTIFICATA: Notifica di scarto ", StringComparison.CurrentCultureIgnoreCase) Then
    '                            TipoMail = enTipoMailPEC.Scarto
    '                        ElseIf Titolo.StartsWith("POSTA CERTIFICATA: Ricevuta di consegna ", StringComparison.CurrentCultureIgnoreCase) Then
    '                            TipoMail = enTipoMailPEC.Ricevuta
    '                        ElseIf Titolo.StartsWith("POSTA CERTIFICATA: Notifica di mancata consegna ", StringComparison.CurrentCultureIgnoreCase) Then
    '                            TipoMail = enTipoMailPEC.MancataConsegna
    '                        ElseIf Titolo.StartsWith("POSTA CERTIFICATA: Invio File ", StringComparison.CurrentCultureIgnoreCase) Then
    '                            TipoMail = enTipoMailPEC.InvioFile
    '                        End If

    '                        If TipoMail = enTipoMailPEC.Accettazione Then 'OK
    '                            'qui è un accettazione di file inviati da noi 
    '                            'qui cerco dentro l'xml l'id del ricavo 
    '                            NuovoStato = enStatoFatturaFE.AccettataSDI
    '                            Dim Oggetto As String = String.Empty
    '                            Oggetto = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "oggetto")
    '                            Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromOggetto(Oggetto)
    '                            If IdRicavo Then
    '                                Using R As New Ricavo
    '                                    R.Read(IdRicavo)
    '                                    If R.StatoFE = enStatoFatturaFE.InviataXML Then
    '                                        Dim Identificativo As String = String.Empty
    '                                        Identificativo = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "identificativo")
    '                                        R.IdMessaggioFE = Identificativo
    '                                        R.StatoFE = NuovoStato
    '                                        R.DataUltimoCambioStatoFE = Now
    '                                        R.Save()
    '                                        DaEliminare = True
    '                                    ElseIf R.StatoFE >= enStatoFatturaFE.AccettataSDI Then
    '                                        'qui la elimino perche è vecchia e gia presa in carico presumibilmente
    '                                        DaEliminare = True
    '                                    End If
    '                                End Using
    '                            End If

    '                        ElseIf TipoMail = enTipoMailPEC.Consegna Then 'OK
    '                            'qui è stato consegnato 
    '                            'enStatoFatturaFE.ConsegnataDest 
    '                            NuovoStato = enStatoFatturaFE.InoltrataDest
    '                            'qui è un accettazione di file inviati da noi 
    '                            'qui cerco dentro l'xml l'id del ricavo 
    '                            Dim Oggetto As String = String.Empty
    '                            Oggetto = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "oggetto")
    '                            Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromOggetto(Oggetto)
    '                            If IdRicavo Then
    '                                Using R As New Ricavo
    '                                    R.Read(IdRicavo)
    '                                    If R.StatoFE = enStatoFatturaFE.AccettataSDI Then
    '                                        Dim Identificativo As String = String.Empty
    '                                        Identificativo = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "identificativo")
    '                                        R.IdMessaggioFE = Identificativo
    '                                        R.StatoFE = NuovoStato
    '                                        R.DataUltimoCambioStatoFE = Now
    '                                        R.Save()
    '                                        DaEliminare = True
    '                                    ElseIf R.StatoFE >= enStatoFatturaFE.InoltrataDest Then
    '                                        'qui la elimino perche è vecchia e gia presa in carico presumibilmente
    '                                        DaEliminare = True
    '                                    End If
    '                                End Using
    '                            End If

    '                        ElseIf TipoMail = enTipoMailPEC.Scarto Then
    '                            'qui è stata scartata
    '                            'enStatoFatturaFE.ScartataSDI 

    '                            PathXML = ScaricaXMLFromEML(msgMail, path, TipoMail)
    '                            NuovoStato = enStatoFatturaFE.ScartataSDI

    '                            Dim NomeFile As String = String.Empty
    '                            NomeFile = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "NomeFile")
    '                            Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromNomeFile(NomeFile, IdAzienda)

    '                            Dim BufferErrori As String = String.Empty

    '                            BufferErrori = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "ListaErrori")
    '                            If IdRicavo Then
    '                                Using R As New Ricavo
    '                                    R.Read(IdRicavo)
    '                                    If R.StatoFE = enStatoFatturaFE.InviataXML Then
    '                                        R.RicevutaXML = BufferXML
    '                                        R.StatoFE = NuovoStato
    '                                        R.InfoFE = BufferErrori 'IIf(BufferErrori.Length > 250, BufferErrori.Substring(0, 250), BufferErrori)
    '                                        R.DataUltimoCambioStatoFE = Now
    '                                        R.Save()

    '                                        DaEliminare = True
    '                                    ElseIf R.StatoFE >= enStatoFatturaFE.ScartataSDI Then
    '                                        'qui la elimino perche è vecchia e gia presa in carico presumibilmente
    '                                        DaEliminare = True
    '                                    End If
    '                                End Using
    '                            End If

    '                        ElseIf TipoMail = enTipoMailPEC.Ricevuta Then

    '                            PathXML = ScaricaXMLFromEML(msgMail, path, TipoMail)
    '                            Using rXml As New StreamReader(PathXML)
    '                                BufferXML = rXml.ReadToEnd
    '                            End Using

    '                            'NuovoStato = enStatoFatturaFE.RicevutaDiConsegna

    '                            ''qui è stata scartata
    '                            ''enStatoFatturaFE.ScartataSDI 
    '                            NuovoStato = enStatoFatturaFE.RicevutaDiConsegna
    '                            Dim IdentificativoSDI As String = String.Empty
    '                            IdentificativoSDI = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "IdentificativoSdI")
    '                            'Dim PecMessageID As String = String.Empty
    '                            'PecMessageID = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "PecMessageID")
    '                            Dim NomeFile As String = String.Empty
    '                            NomeFile = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "NomeFile")
    '                            Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromNomeFile(NomeFile, IdAzienda)
    '                            If IdRicavo Then
    '                                Using R As New Ricavo
    '                                    R.Read(IdRicavo)
    '                                    If R.StatoFE = enStatoFatturaFE.InoltrataDest OrElse
    '                                       R.StatoFE = enStatoFatturaFE.NonConsegnataDest Then
    '                                        R.IdentificativoSdI = IdentificativoSDI
    '                                        'R.IdMessaggioFE = PecMessageID
    '                                        R.RicevutaXML = BufferXML
    '                                        R.StatoFE = NuovoStato
    '                                        R.DataUltimoCambioStatoFE = Now
    '                                        R.Save()

    '                                        Try
    '                                            Dim PathDestXML As String = FormerConfig.FormerPath.PathFattureFE & R.AnnoRiferimento & "\" & R.IdAzienda & "\" & FormerLib.FormerHelper.File.EstraiNomeFile(PathXML)
    '                                            FormerHelper.File.CreateLongPath(PathDestXML)
    '                                            FileCopy(PathXML, PathDestXML)
    '                                        Catch ex As Exception

    '                                        End Try
    '                                        DaEliminare = True
    '                                    ElseIf R.StatoFE >= enStatoFatturaFE.RicevutaDiConsegna Then
    '                                        'qui la elimino perche è vecchia e gia presa in carico presumibilmente
    '                                        DaEliminare = True
    '                                    End If
    '                                End Using
    '                            End If
    '                        ElseIf TipoMail = enTipoMailPEC.MancataConsegna Then
    '                            'qui è stata scartata
    '                            'enStatoFatturaFE.ScartataSDI 

    '                            PathXML = ScaricaXMLFromEML(msgMail, path, TipoMail)
    '                            NuovoStato = enStatoFatturaFE.NonConsegnataDest

    '                            Dim NomeFile As String = String.Empty
    '                            NomeFile = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "NomeFile")
    '                            Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromNomeFile(NomeFile, IdAzienda)

    '                            Dim BufferErrori As String = String.Empty

    '                            BufferErrori = FormerLib.FormerHelper.XML.GetValueFromFile(PathXML, "Descrizione")
    '                            If IdRicavo Then
    '                                Using R As New Ricavo
    '                                    R.Read(IdRicavo)
    '                                    If R.StatoFE = enStatoFatturaFE.InoltrataDest Then
    '                                        R.RicevutaXML = BufferXML
    '                                        R.StatoFE = NuovoStato
    '                                        R.InfoFE = IIf(BufferErrori.Length > 250, BufferErrori.Substring(0, 250), BufferErrori)
    '                                        R.DataUltimoCambioStatoFE = Now
    '                                        R.Save()

    '                                        DaEliminare = True
    '                                    ElseIf R.StatoFE >= enStatoFatturaFE.NonConsegnataDest Then
    '                                        'qui la elimino perche è vecchia e gia presa in carico presumibilmente
    '                                        DaEliminare = True
    '                                    End If
    '                                End Using
    '                            End If

    '                        ElseIf TipoMail = enTipoMailPEC.InvioFile Then
    '                            'qui è stata ricevuta una fattura
    '                            NuovoStato = enStatoFatturaFE.AllegatoXMLRicevuto
    '                            PathXML = ScaricaXMLFromEML(msgMail, path, TipoMail)
    '                            If PathXML.ToLower.EndsWith("xml") = False Then
    '                                PathXML = MgrFattureFE.ReadXmlSigned(PathXML, False)
    '                            End If

    '                            NuovoStato = enStatoFatturaFE.AllegatoXMLRicevuto

    '                            Dim F As FatturaElettronica = MgrFattureFE.GetFatturaFromXML(PathXML)
    '                            Dim BufferF As String = String.Empty
    '                            Using reader As StreamReader = New StreamReader(PathXML)
    '                                BufferF = reader.ReadToEnd
    '                            End Using

    '                            Dim TipoDocumento As enTipoDocumento = MgrFattureFE.GetTipoDocumento(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.TipoDocumento)

    '                            If TipoDocumento = enTipoDocumento.Fattura OrElse
    '                               TipoDocumento = enTipoDocumento.NotaDiCredito OrElse
    '                               TipoDocumento = enTipoDocumento.NotaDiDebito OrElse
    '                               TipoDocumento = enTipoDocumento.AccontoAnticipoSuFattura Then
    '                                'FATTURA
    '                                Dim IdRub As Integer = 0
    '                                Dim IdAziendaCosto As Integer = 0
    '                                'Dim TipoFattura As enTipoDocumento = enTipoDocumento.Fattura
    '                                'Dim NumeroFattura As String = String.Empty
    '                                Dim ListaDDT As List(Of DatiDDT) = Nothing

    '                                If Not F.FatturaElettronicaBody.DatiGenerali.DatiDDT Is Nothing AndAlso F.FatturaElettronicaBody.DatiGenerali.DatiDDT.Count AndAlso TipoDocumento = enTipoDocumento.Fattura Then
    '                                    TipoDocumento = enTipoDocumento.FatturaRiepilogativa
    '                                    ListaDDT = F.FatturaElettronicaBody.DatiGenerali.DatiDDT
    '                                    'Else
    '                                    '    TipoDocumento = enTipoDocumento.Fattura
    '                                End If

    '                                Using mgr As New VociRubricaDAO
    '                                    Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Piva, F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice))
    '                                    If l.Count > 0 Then
    '                                        IdRub = l(0).IdRub
    '                                    End If

    '                                    Using r As New VoceRubrica
    '                                        If IdRub Then r.Read(IdRub) 'qui in caso aggiorno i dati 
    '                                        r.RagSoc = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione, VbStrConv.ProperCase)
    '                                        r.Nome = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Nome, VbStrConv.ProperCase)
    '                                        r.Cognome = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Cognome, VbStrConv.ProperCase)
    '                                        r.Indirizzo = StrConv(F.FatturaElettronicaHeader.CedentePrestatore.Sede.Indirizzo & " " & F.FatturaElettronicaHeader.CedentePrestatore.Sede.NumeroCivico, VbStrConv.ProperCase)
    '                                        r.CodFisc = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.CodiceFiscale
    '                                        r.Piva = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice
    '                                        If IdRub = 0 Then
    '                                            r.Tipo = enTipoRubrica.Cliente 'enTipoRubrica.Fornitore
    '                                            r.IsFornitore = enSiNo.Si
    '                                        End If

    '                                        If Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti Is Nothing Then
    '                                            r.Tel = IIf(Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Telefono Is Nothing, F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Telefono, "")
    '                                            r.Fax = IIf(Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Fax Is Nothing, F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Fax, "")
    '                                            If r.Email.Length = 0 OrElse r.Email = FormerConst.EmailNonDisponibile Then r.Email = IIf(Not F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Email Is Nothing, F.FatturaElettronicaHeader.CedentePrestatore.Contatti.Email, "")
    '                                        End If

    '                                        If IdRub = 0 Then r.IdPagamento = enMetodoPagamento.AllaConsegna
    '                                        If IdRub = 0 Then r.Pagamento = FormerEnumHelper.TipoPagamentoStr(r.IdPagamento)
    '                                        If IdRub = 0 Then r.TipoDoc = enTipoDocumento.Fattura
    '                                        If IdRub = 0 Then r.DataIns = Now

    '                                        If IdRub = 0 Then r.Sorgente = "F"
    '                                        r.PrefissoPiva = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese
    '                                        'r.Provincia
    '                                        'r.IdProvincia
    '                                        'r.IdComune
    '                                        Using MgrC As New ElencoComuniDAO
    '                                            Dim lC As List(Of ComuneInElenco) = MgrC.FindAll(New LUNA.LunaSearchParameter(LFM.ComuneInElenco.CAP, F.FatturaElettronicaHeader.CedentePrestatore.Sede.CAP),
    '                                                                                            New LUNA.LunaSearchParameter(LFM.ComuneInElenco.Provincia, F.FatturaElettronicaHeader.CedentePrestatore.Sede.Provincia),
    '                                                                                            New LUNA.LunaSearchParameter(LFM.ComuneInElenco.Comune, F.FatturaElettronicaHeader.CedentePrestatore.Sede.Comune))

    '                                            If lC.Count = 1 Then
    '                                                Using CinE As ComuneInElenco = lC(0)
    '                                                    r.IdComune = CinE.IDCap
    '                                                    r.CAP = CinE.CAP
    '                                                    r.Citta = CinE.Comune
    '                                                    r.Provincia = CinE.Provincia
    '                                                    r.IdProvincia = CinE.ProvinciaSel.ID
    '                                                End Using
    '                                            Else
    '                                                r.CAP = F.FatturaElettronicaHeader.CedentePrestatore.Sede.CAP
    '                                                r.Citta = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Comune
    '                                                r.Provincia = F.FatturaElettronicaHeader.CedentePrestatore.Sede.Provincia
    '                                            End If

    '                                        End Using
    '                                        If r.IsChanged Then
    '                                            r.LastUpdate = Now
    '                                            IdRub = r.Save
    '                                        End If

    '                                    End Using
    '                                End Using

    '                                If F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSnc) Then
    '                                    IdAziendaCosto = MgrAziende.IdAziende.AziendaSnc
    '                                ElseIf F.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSrl) Then
    '                                    IdAziendaCosto = MgrAziende.IdAziende.AziendaSrl
    '                                End If

    '                                'End Using
    '                                If IdRub Then
    '                                    'qui vado a creare una transaction box
    '                                    Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
    '                                        Try
    '                                            Using C As New Costo
    '                                                C.IdRub = IdRub
    '                                                C.IdAzienda = IdAziendaCosto
    '                                                C.Descrizione = F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Causale
    '                                                C.DataCosto = MgrFattureFE.GetDataFromFormatoFE(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Data)
    '                                                C.Numero = F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero

    '                                                C.DocXML = BufferF
    '                                                C.StatoFE = enStatoFatturaFE.AllegatoXMLRicevuto
    '                                                C.DataOraRicezione = Now
    '                                                C.IdStato = enStatoDocumentoFiscale.RegistratoAutomaticamente
    '                                                C.Tipo = TipoDocumento

    '                                                Dim DatiRiepilogoMain As DatiRiepilogo = F.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo(0)
    '                                                C.Importo = MgrFattureFE.GetDecimalFromFormatoFE(DatiRiepilogoMain.ImponibileImporto)
    '                                                C.Iva = MgrFattureFE.GetDecimalFromFormatoFE(DatiRiepilogoMain.Imposta)
    '                                                C.Totale = C.Importo + C.Iva
    '                                                C.PercIva = MgrFattureFE.GetIvaFromFormatoFE(DatiRiepilogoMain.AliquotaIVA)
    '                                                'c.costocorr
    '                                                'c.speseincasso
    '                                                'c.addebitivari

    '                                                'PRIMA DI SALVARE CONTROLLO CHE IL DOCUMENTO NON SIA STATO GIA LAVORATO
    '                                                Dim ParamTipoDocumento As String = String.Empty
    '                                                If TipoDocumento = enTipoDocumento.Fattura OrElse TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
    '                                                    ParamTipoDocumento = "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & ")"
    '                                                Else
    '                                                    ParamTipoDocumento = "(" & TipoDocumento & ")"
    '                                                End If

    '                                                Using mgrC As New CostiDAO
    '                                                    Dim lC As List(Of Costo) = mgrC.FindAll(New LUNA.LunaSearchParameter(LFM.Costo.Numero, C.Numero),
    '                                                                                            New LUNA.LunaSearchParameter(LFM.Costo.IdRub, C.IdRub),
    '                                                                                            New LUNA.LunaSearchParameter(LFM.Costo.IdAzienda, C.IdAzienda),
    '                                                                                            New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, ParamTipoDocumento, "IN"),
    '                                                                                            New LUNA.LunaSearchParameter("YEAR(DataCosto)", C.DataCosto.Year))
    '                                                    If lC.Count = 0 Then
    '                                                        'qui la vado a salvare
    '                                                        Dim IdCosto As Integer = 0

    '                                                        'vado a copiare l'xml nella cartella corretta
    '                                                        Dim PathFinale As String = FormerPath.PathFattureAcquisto & "FE\" & C.AnnoStr & "\" & C.IdAzienda & "\" & FormerLib.FormerHelper.File.EstraiNomeFile(PathXML)
    '                                                        FormerLib.FormerHelper.File.CreateLongPath(PathFinale)

    '                                                        File.Copy(PathXML, PathFinale, True)
    '                                                        Dim OkPagam As Boolean = True
    '                                                        Dim Pag As Pagamento = Nothing
    '                                                        If Not F.FatturaElettronicaBody.DatiPagamento Is Nothing AndAlso
    '                                                            Not F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento Is Nothing AndAlso
    '                                                            Not F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento Is Nothing Then

    '                                                            Dim DataScadenzaPagamento As Date = MgrFattureFE.GetDataFromFormatoFE(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento)
    '                                                            C.DataPrevPagam = DataScadenzaPagamento
    '                                                        Else
    '                                                            C.DataPrevPagam = C.DataCosto
    '                                                            OkPagam = False
    '                                                        End If

    '                                                        'qui salvo effettivamente il costo
    '                                                        tb.TransactionBegin()
    '                                                        IdCosto = C.Save
    '                                                        Dim ListaDDTSalvati As New List(Of Costo)
    '                                                        If TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
    '                                                            For Each DDT In ListaDDT
    '                                                                'vado a salvare i vari ddt
    '                                                                If ListaDDTSalvati.Find(Function(x) x.Numero = DDT.NumeroDDT) Is Nothing Then
    '                                                                    Using NewDDT As New Costo
    '                                                                        NewDDT.IdRub = IdRub
    '                                                                        NewDDT.IdAzienda = IdAziendaCosto
    '                                                                        NewDDT.Descrizione = "DDT"
    '                                                                        NewDDT.DataCosto = MgrFattureFE.GetDataFromFormatoFE(DDT.DataDDT)
    '                                                                        NewDDT.Numero = DDT.NumeroDDT
    '                                                                        NewDDT.IdStato = enStatoDocumentoFiscale.RegistratoAutomaticamente
    '                                                                        NewDDT.Tipo = enTipoDocumento.DDT
    '                                                                        NewDDT.IdDocRif = C.IdCosto
    '                                                                        NewDDT.DataPrevPagam = NewDDT.DataCosto
    '                                                                        NewDDT.Save()
    '                                                                        ListaDDTSalvati.Add(NewDDT)
    '                                                                    End Using
    '                                                                End If

    '                                                            Next
    '                                                        End If

    '                                                        If Not F.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee Is Nothing Then
    '                                                            For Each Linea In F.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee
    '                                                                Dim IdCostoLinea As Integer = IdCosto

    '                                                                If TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
    '                                                                    For Each DDT In ListaDDT
    '                                                                        If Not DDT.RiferimentoNumeroLinea Is Nothing AndAlso DDT.RiferimentoNumeroLinea.FindAll(Function(x) x = Linea.NumeroLinea).Count Then
    '                                                                            IdCostoLinea = ListaDDTSalvati.Find(Function(x) x.Numero = DDT.NumeroDDT).IdCosto
    '                                                                            Exit For
    '                                                                        End If
    '                                                                    Next

    '                                                                    If IdCostoLinea = IdCosto Then
    '                                                                        'qui non e' riuscito a trovare il ddt
    '                                                                        If ListaDDTSalvati.Count = 1 Then
    '                                                                            'se dentro la fattura c'e' un solo ddt e non hanno messo il riferimento li aggancio in automatico all'unico che trovo
    '                                                                            IdCostoLinea = ListaDDTSalvati(0).IdCosto
    '                                                                        End If
    '                                                                    End If

    '                                                                End If

    '                                                                Using Voce As New VoceCosto
    '                                                                    Voce.IdCosto = IdCostoLinea
    '                                                                    If Not Linea.CodiceArticolo Is Nothing Then
    '                                                                        Voce.Codice = Linea.CodiceArticolo.CodiceValore
    '                                                                    End If
    '                                                                    Voce.Descrizione = Linea.Descrizione
    '                                                                    If Not Linea.Quantita Is Nothing AndAlso Linea.Quantita.Length > 0 Then
    '                                                                        Voce.Qta = MgrFattureFE.GetDecimalFromFormatoFE(Linea.Quantita)
    '                                                                    Else
    '                                                                        Voce.Qta = 1
    '                                                                    End If
    '                                                                    If Not Linea.UnitaMisura Is Nothing AndAlso Linea.UnitaMisura.Length > 0 Then
    '                                                                        Voce.Um = Linea.UnitaMisura
    '                                                                    End If
    '                                                                    If Not Linea.TipoCessionePrestazione Is Nothing AndAlso Linea.TipoCessionePrestazione.Length > 0 Then
    '                                                                        Voce.TipoCessionePrestazione = Linea.TipoCessionePrestazione
    '                                                                    End If
    '                                                                    Voce.PrezzoUnit = MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoUnitario)
    '                                                                    Voce.Totale = MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoTotale)
    '                                                                    Voce.AliquotaIva = MgrFattureFE.GetDecimalFromFormatoFE(Linea.AliquotaIVA)
    '                                                                    Voce.Save()
    '                                                                End Using
    '                                                            Next
    '                                                        End If

    '                                                        Dim SalvarePagamento As Boolean = False

    '                                                        Using R As New VoceRubrica
    '                                                            R.Read(IdRub)
    '                                                            If R.RegistraAutomaticamentePagamenti = enSiNo.Si Then
    '                                                                SalvarePagamento = True
    '                                                            Else
    '                                                                If OkPagam = True AndAlso MgrFattureFE.InserirePagamento(F) Then
    '                                                                    SalvarePagamento = True
    '                                                                End If
    '                                                            End If
    '                                                        End Using

    '                                                        If SalvarePagamento Then
    '                                                            Pag = New Pagamento
    '                                                            Pag.IdRub = C.IdRub
    '                                                            Pag.Tipo = enTipoVoceContab.VoceAcquisto
    '                                                            Pag.IdFat = C.IdCosto
    '                                                            Pag.Importo = MgrFattureFE.GetDecimalFromFormatoFE(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ImportoPagamento)
    '                                                            Pag.DataPag = C.DataPrevPagam
    '                                                            Pag.IdTipoPagamento = MgrFattureFE.GetIdTipoPagamento(F.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento)
    '                                                            Pag.Save()
    '                                                        End If

    '                                                        If TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
    '                                                            'qui vado a cercare o salvare il documento di carico dei ddt

    '                                                        ElseIf TipoDocumento = enTipoDocumento.FatturaRiepilogativa Then
    '                                                            'qui vado a cercare o salvare il documento di carico della fattura

    '                                                        End If

    '                                                        tb.TransactionCommit()
    '                                                    End If
    '                                                End Using
    '                                                DaEliminare = True

    '                                            End Using
    '                                        Catch ex As Exception
    '                                            tb.TransactionRollBack()
    '                                        End Try

    '                                    End Using

    '                                End If

    '                            End If

    '                            'DaEliminare = False

    '                        End If

    '                        If DaEliminare Then
    '                            p.DeleteMessage(i)
    '                        End If
    '                    Catch ex As Exception
    '                        LogMe("ERRORE Monitoraggio PEC MAIL '" & Titolo & "'",, ex)
    '                    End Try
    '                Next
    '            End If

    '            p.Disconnect()
    '        End Using
    '    Catch ex As Exception
    '        LogMe("ERRORE GENERALE Monitoraggio PEC",, ex)
    '    End Try
    '    LogMe("***FINE Monitoraggio PEC***")
    'End Sub

    Private Shared Sub ScaricaOrdiniMail()
        LogMe("***Scaricamento Mail Ordini***")
        Dim count As Integer = 0
        Dim Scaricate As Integer = 0
        If Postazione.Network.ConnessioneInternetDisponibile Then
            Try
                Using p As New OpenPop.Pop3.Pop3Client

                    p.Connect(FConfiguration.OrdiniMail.ServerPOP, 995, True)

                    p.Authenticate(FConfiguration.OrdiniMail.Email,
                                   FConfiguration.OrdiniMail.Password,
                                   OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword)

                    count = p.GetMessageCount()

                    If count Then

                        For i As Integer = count To 1 Step -1

                            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()

                                Try
                                    Dim msg As OpenPop.Mime.Message = p.GetMessage(i)

                                    Dim msgMail As MailMessage = msg.ToMailMessage

                                    Dim body As String = msgMail.Body

                                    Dim soggetto As String = msgMail.Subject
                                    If msgMail.IsBodyHtml Then

                                        Dim bodyParsed As String = String.Empty

                                        If msgMail.AlternateViews.Count Then
                                            For Each a As AlternateView In msgMail.AlternateViews
                                                If a.ContentType.MediaType = "text/plain" Then
                                                    Dim contenuto As Stream = a.ContentStream
                                                    Dim byteBuffer(contenuto.Length) As Byte

                                                    Dim CharsetTrovato As String = String.Empty

                                                    Try
                                                        CharsetTrovato = a.ContentType.CharSet
                                                    Catch ex As Exception

                                                    End Try

                                                    If CharsetTrovato.Length = 0 Then
                                                        CharsetTrovato = "UTF-8"
                                                    End If

                                                    'Select Case CharsetTrovato.ToUpper
                                                    '    Case "UTF-7"
                                                    '        bodyParsed = Encoding.UTF7.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    '    Case "UTF-32"
                                                    '        bodyParsed = Encoding.UTF32.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    '    Case "UNICODE"
                                                    '        bodyParsed = Encoding.Unicode.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    '    Case "US-ASCII"
                                                    '        bodyParsed = Encoding.ASCII.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    '    Case Else '"UTF-8"
                                                    '        bodyParsed = Encoding.UTF8.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                                    'End Select

                                                    bodyParsed = Encoding.GetEncoding(CharsetTrovato).GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))

                                                End If
                                            Next
                                        End If

                                        If bodyParsed.Length = 0 Then
                                            body = FormerLib.FormerHelper.HTML.EliminaTag(msgMail.Body)
                                        Else
                                            body = bodyParsed
                                        End If

                                    End If

                                    Try
                                        body = System.Web.HttpUtility.HtmlDecode(body)
                                    Catch ex As Exception

                                    End Try

                                    Dim l As New List(Of AttachPreventivoMail)

                                    If msgMail.Attachments.Count Then
                                        For Each a As Attachment In msgMail.Attachments

                                            Dim NomeFileDest As String = a.Name

                                            Randomize()
                                            Dim R As New Random
                                            NomeFileDest = FormerLib.FormerHelper.Web.NormalizzaNomeFile(NomeFileDest)
                                            NomeFileDest = R.Next(100, 999) & "_" & NomeFileDest

                                            Dim path As String = FormerPath.PathAttachMailPrev & NomeFileDest

                                            Using fs As New FileStream(path, FileMode.Create)

                                                a.ContentStream.CopyTo(fs)

                                            End Using

                                            Dim mAttach As New AttachPreventivoMail
                                            mAttach.NomeFile = NomeFileDest
                                            mAttach.Path = path

                                            l.Add(mAttach)

                                        Next
                                    End If

                                    'cerco un riferimento a un altra mail

                                    Dim IdMailRif As Integer = 0
                                    'Dim ris As Match = Regex.Match(body, "FPGUID{.*?}")
                                    'Dim GuidTrovato As String = String.Empty

                                    'If ris.Success Then
                                    '    GuidTrovato = ris.Value

                                    '    GuidTrovato = GuidTrovato.Substring(GuidTrovato.IndexOf("{") + 1)
                                    '    GuidTrovato = GuidTrovato.Substring(0, GuidTrovato.Length - 1)

                                    '    Using mgr As New PreventiviMailDAO
                                    '        Dim lP As List(Of PreventivoMail) = mgr.FindAll("DataRif",
                                    '                                                        New LUNA.LunaSearchParameter("GuidMail", GuidTrovato))

                                    '        If lP.Count Then
                                    '            IdMailRif = lP.Last.IdMailPreventivo
                                    '        End If

                                    '    End Using

                                    'End If

                                    Dim Mittente As String = msgMail.From.Address
                                    Dim Titolo As String = msgMail.Subject

                                    'QUI CONTROLLO SE SI STA RICHIEDENDO LA SITUAZIONE ATTUALE INTERNA 

                                    If (Mittente = "tipografia.duca@gmail.com" Or Mittente = "soft@tipografiaformer.it") And
                                       Titolo.ToLower = "situazione" Then

                                        InviaSituazioneAttuale(Mittente)

                                    ElseIf (Mittente = "tipografia.duca@gmail.com" Or Mittente = "soft@tipografiaformer.it") And
                                       Titolo.ToLower = "soluzioni" Then

                                        InviaSoluzioniAttuali(Mittente)

                                    Else
                                        'qui devo vedere se e' inoltrata
                                        Dim risInoltro As Match = Regex.Match(Mittente, "@tipografiaformer.")

                                        'Dim risInoltro As Match = Regex.Match(Mittente, "tipografia.duca@gmail.")

                                        If risInoltro.Success = True Or Mittente = "tipografia.duca@gmail.com" Then
                                            'qui devo cercare l'inoltro

                                            Dim collCercaMail As MatchCollection = Regex.Matches(msgMail.Body, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")

                                            For Each singRis As Match In collCercaMail

                                                Dim cercaMail As Match = Regex.Match(singRis.Value, "@tipografiaformer.")

                                                If cercaMail.Success = False And singRis.Value <> "tipografia.duca@gmail.com" Then

                                                    If FormerLib.FormerHelper.Mail.IsValidEmailAddress(singRis.Value) Then
                                                        Mittente = singRis.Value
                                                        Exit For
                                                    End If

                                                End If

                                            Next

                                        End If

                                        Dim risInoltroAfter As Match = Regex.Match(Mittente, "@tipografiaformer.")

                                        'If GuidTrovato.Length = 0 Then

                                        '    Dim x As Guid = Guid.NewGuid
                                        '    GuidTrovato = x.ToString

                                        'End If

                                        Dim DataRif As Date = Now

                                        Try

                                            Dim dataTemp As String = msg.Headers.Date

                                            Dim dataRifTemp As Date = CDate(dataTemp)

                                            DataRif = dataRifTemp

                                        Catch ex As Exception

                                        End Try

                                        Using mp As New PreventivoMail

                                            mp.GuidMail = String.Empty
                                            mp.DataRif = DataRif
                                            mp.Mittente = Mittente.Trim
                                            mp.Titolo = Titolo.Trim
                                            mp.Testo = body.Trim
                                            mp.Stato = enStatoPreventivoMail.DaLavorare
                                            mp.IdMailRif = IdMailRif
                                            mp.TipoMail = enTipoMail.Ordine

                                            If risInoltroAfter.Success = False And Mittente <> "tipografia.duca@gmail.com" Then
                                                Using mgrR As New VociRubricaDAO
                                                    Dim lR As List(Of VoceRubrica) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Email, mp.Mittente))
                                                    If lR.Count Then
                                                        Dim vr As VoceRubrica = lR(0)
                                                        mp.IdRub = vr.IdRub
                                                    Else
                                                        'qui devo provare a cercare tra le mail in arrivo se per caso la stessa mail è
                                                        'stata assegnata gia a un cliente
                                                        Using mgrM As New PreventiviMailDAO
                                                            Dim IdRubTrovato As Integer = mgrM.GetIdRubFromStorico(Mittente)
                                                            If IdRubTrovato Then
                                                                mp.IdRub = IdRubTrovato
                                                            End If
                                                        End Using
                                                    End If
                                                End Using
                                            End If

                                            tb.TransactionBegin()

                                            mp.Save()

                                            Scaricate += 1

                                            For Each singA As AttachPreventivoMail In l

                                                Dim NuovoPath As String = singA.Path.Replace(singA.NomeFile, mp.IdMailPreventivo & "_" & singA.NomeFile)

                                                Rename(singA.Path, NuovoPath)

                                                singA.Path = NuovoPath
                                                singA.IdMailPreventivo = mp.IdMailPreventivo
                                                singA.Save()
                                            Next

                                            tb.TransactionCommit()

                                        End Using

                                    End If


                                    'RIATTIVARE PRIMA DI METTERE IN PRODUZIONE
                                    'qui cancello il messaggio dal server remoto
                                    p.DeleteMessage(i)

                                    'If ris.Success = False And risInoltroAfter.Success = False And Mittente <> "tipografia.duca@gmail.com" Then
                                    '    Dim TestoRisposta As String = String.Empty

                                    '    TestoRisposta = "Salve, <br><br>"
                                    '    TestoRisposta &= "la sua richiesta di preventivo <b>'" & Titolo & "'</b> è stata presa in carico e riceverà una risposta entro 24/48 ore.<br><br>"
                                    '    TestoRisposta &= "<br><br><br><font face=""courier"">*********************************************************************************************************<br>"
                                    '    TestoRisposta &= "IN CASO DI RISPOSTA A QUESTA EMAIL NON RIMUOVERE QUESTA RIGA FPGUID{$}<br>".Replace("$", GuidTrovato) & ControlChars.NewLine
                                    '    TestoRisposta &= "*********************************************************************************************************</font>"

                                    '    Try
                                    '        'RIATTIVARE PRIMA DI METTERE IN PRODUZIONE
                                    '        'qui rispondo alla mail con una mail automatica di presa in carico
                                    '        FormerLib.FormerHelper.Mail.InviaMail("La sua richiesta di preventivo è stata presa in carico", TestoRisposta, Mittente, FConfiguration.PreventiviMail.EmailSender,,,,,, False)
                                    '    Catch ex As Exception

                                    '    End Try
                                    'Else
                                    '    'qui devo rimettere da lavorare la discussione iniziale
                                    '    Using mgr As New PreventiviMailDAO
                                    '        Dim lP As List(Of PreventivoMail) = mgr.FindAll(New LUNA.LunaSearchParameter("GuidMail", GuidTrovato),
                                    '                                                       New LUNA.LunaSearchParameter("IdMailRif", 0))

                                    '        Using singmail As PreventivoMail = lP(0)
                                    '            singmail.Stato = enStatoPreventivoMail.DaLavorare
                                    '            singmail.Save()
                                    '        End Using

                                    '    End Using
                                    'End If

                                Catch ex As Exception

                                    'PROVO A CANCELLARE IL MESSAGGIO 
                                    Try
                                        p.DeleteMessage(i)
                                    Catch ex2 As Exception

                                    End Try

                                    LogMe("SORGENTE: ScaricaOrdiniMail(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace,, ex)
                                    tb.TransactionRollBack()
                                    'log
                                End Try

                            End Using

                        Next
                    End If

                    p.Disconnect()

                    'MessageBox.Show("Scaricate " & count & " mail")

                    If Scaricate Then FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Notifica, "Scaricati " & Scaricate & " nuovi ordini email.", FormerLib.FormerUDP.DestUDP_Admin)

                End Using
            Catch ex As Exception
                LogMe("SORGENTE: ScaricaOrdiniMail(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, False, ex)
            End Try

        End If

        LogMe("*********************************************", True)
        LogMe("Scaricate " & count & " mail ordini")
        LogMe("*********************************************", True)


    End Sub

    Private Shared Sub InvioMailMarketing()

        Dim MailInv As Integer = 0
        Dim MailErr As Integer = 0

        Try

            LogMe("***Invio Mail Marketing***")

            Dim L As List(Of LogMarketing)
            Dim MaxMailSessione As Integer = 100

            Using mgr As New LogMarketingDAO
                L = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.LogMarketing.Stato, enStatoEmail.DaInviare),
                                New LUNA.LunaSearchParameter(LFM.LogMarketing.NTent, 4, "<"))

                For Each singL As LogMarketing In L

                    Try
                        Dim Ris As Integer = 0
                        Dim EmailDest As String = String.Empty
                        Dim SoggettoEmail As String = "Tipografia Former, Una comunicazione importante per te"

                        If singL.IdTemplateMarketing Then
                            EmailDest = singL.VoceRubricaG.EmailG
                        ElseIf singL.IdEmail Then
                            'qui devo prendere l'email del destinatario
                            Using E As New Email
                                E.Read(singL.IdEmail)
                                EmailDest = E.Destinatario.EmailG
                                SoggettoEmail = E.Titolo
                            End Using
                        End If
                        LogMe("Invio mail: " & EmailDest)

                        Dim Buffer As String = String.Empty
                        Dim PathEmail As String = String.Empty

                        If singL.IdTemplateMarketing Then
                            Using Tm As New TemplateMarketing
                                Tm.Read(singL.IdTemplateMarketing)
                                PathEmail = Tm.Path
                            End Using
                        ElseIf singL.IdEmail Then
                            PathEmail = FormerPath.PathEmail & singL.IdEmail & ".htm"
                        End If

                        If FileIO.FileSystem.FileExists(PathEmail) Then
                            Using R As New StreamReader(PathEmail)
                                Buffer = R.ReadToEnd
                            End Using

                            'SOSTITUISCO IL NOME CLIENTE CON IL SUO NOME DI BATTESIMO SE PRESENTE
                            Dim BufferReplace As String = "Cliente"
                            If singL.VoceRubricaG.NomeDiBattesimo.Length Then
                                BufferReplace = singL.VoceRubricaG.NomeDiBattesimo
                            End If
                            Buffer = Buffer.Replace(FormerConst.Tag.NomeDiBattesimoCliente, BufferReplace)

                            'estrarre il soggetto dal file di template
                            If singL.IdTemplateMarketing Then
                                Using F As New FiltroMarketing
                                    F.Read(singL.IdFm)

                                    If F.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                                        Dim PosizTitle As Integer = Buffer.IndexOf("<h4>")
                                        If PosizTitle <> -1 Then
                                            Dim PosizFineTitle As Integer = Buffer.IndexOf("</h4>", PosizTitle)
                                            If PosizFineTitle <> -1 Then
                                                SoggettoEmail = Buffer.Substring(PosizTitle + 4, PosizFineTitle - PosizTitle - 4)
                                            End If
                                        End If
                                    ElseIf F.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                                        Using Tm As New TemplateMarketing
                                            Tm.Read(singL.IdTemplateMarketing)
                                            SoggettoEmail = Tm.Titolo
                                        End Using

                                        '?SoggettoEmail =""
                                    End If

                                End Using
                            End If

                            Dim WithUnsubscribe As Boolean = True

                            If singL.IdEmail Then
                                WithUnsubscribe = False
                            End If

                            Ris = FormerLib.FormerHelper.Mail.InviaMail(SoggettoEmail,
                                                                        Buffer,
                                                                        EmailDest, , , , , ,
                                                                        WithUnsubscribe)
                            singL.NTent += 1
                            If Ris = 0 Then
                                MailInv += 1
                                singL.Stato = enStatoEmail.Inviata
                                singL.DataSent = Now
                                If singL.IdEmail Then
                                    Using e As New Email
                                        e.Read(singL.IdEmail)
                                        e.Quando = Now
                                        e.Save()
                                    End Using
                                End If
                            Else
                                If singL.NTent > 3 Then
                                    singL.Stato = enStatoEmail.Errore
                                End If
                                MailErr += 1
                            End If
                            singL.Save()

                            'DELAY DI INVIO
                            Threading.Thread.Sleep(IntervalDelayInvio)

                        Else
                            Throw New ApplicationException("File template/Email non trovato")
                        End If

                    Catch ex As Exception
                        LogMe("SORGENTE: CheckMails(), Invio IDLogMW " & singL.IdLogMw & " " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace)
                    End Try

                    If MailInv > MaxMailSessione Then
                        Exit For
                    End If
                Next
            End Using

            LogMe("*********************************************", True)
            LogMe("Mail Inviate " & MailInv)
            LogMe("Mail in errore " & MailErr)
            LogMe("*********************************************", True)

        Catch ex As Exception
            LogMe("SORGENTE: CheckMails(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace)

        End Try

    End Sub


End Class
