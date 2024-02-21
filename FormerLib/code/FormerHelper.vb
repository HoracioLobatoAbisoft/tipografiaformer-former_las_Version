Imports System.Net.Mail
Imports System.IO
Imports GhostscriptSharp
Imports GhostscriptSharp.Settings

Imports System.Drawing
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports iTextSharp.text.html
Imports System.Text
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports FormerLib.FormerEnum
Imports FormerConfig
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Net.Sockets

Public Class FormerHelper

    Public Class XML
        Private Shared Function GetValueNode(StartNode As System.Xml.XmlNode, key As String) As String
            ' For Each node As System.Xml.XmlNode In StartNode.ChildNodes
            Dim Ris As String = String.Empty

            If Not StartNode.Attributes Is Nothing AndAlso Not StartNode.Attributes("key") Is Nothing AndAlso StartNode.Attributes("key").Value = key Then
                Ris = StartNode.Attributes("value").Value
            ElseIf StartNode.Name = key Then
                If Not StartNode.Value Is Nothing Then
                    Ris = StartNode.Value
                ElseIf StartNode.InnerText.Length Then
                    Ris = StartNode.InnerText
                End If
            End If
            If Ris.Length = 0 Then
                If StartNode.HasChildNodes Then
                    For Each NodeC As System.Xml.XmlNode In StartNode.ChildNodes
                        Ris = GetValueNode(NodeC, key)
                        If Ris.Length Then Exit For
                    Next
                End If
            End If

            'Next
            Return Ris
        End Function
        Public Shared Function GetValueFromFile(Path As String, Key As String) As String

            Dim ris As String = String.Empty

            Try
                Dim Buffer As String = String.Empty
                Using r As New StreamReader(Path)
                    Buffer = r.ReadToEnd
                End Using

                Dim MyDoc As New System.Xml.XmlDocument
                MyDoc.LoadXml(Buffer)

                If MyDoc.HasChildNodes Then
                    For Each node As System.Xml.XmlNode In MyDoc.ChildNodes
                        ris = GetValueNode(node, Key)
                        If ris.Length Then Exit For
                        'If node.HasChildNodes Then
                        '    For Each NodeC As System.Xml.XmlNode In node.ChildNodes

                        '        If (Not NodeC.Attributes Is Nothing AndAlso Not NodeC.Attributes("key") Is Nothing AndAlso NodeC.Attributes("key").Value = Key) Then
                        '            ris = NodeC.Attributes("value").Value
                        '            Exit For
                        '        ElseIf NodeC.Name = Key Then
                        '            If Not NodeC.Value Is Nothing Then
                        '                ris = NodeC.Value
                        '                Exit For
                        '            ElseIf nodec.InnerText.Length Then
                        '                ris = NodeC.InnerText
                        '                Exit For
                        '            End If
                        '        End If
                        '    Next
                        'Else
                        '    If Not node.Attributes Is Nothing AndAlso Not node.Attributes("key") Is Nothing AndAlso node.Attributes("key").Value = Key Then
                        '        ris = node.Attributes("value").Value
                        '        Exit For
                        '    ElseIf node.Name = Key Then
                        '        If Not node.Value Is Nothing Then
                        '            ris = node.Value
                        '            Exit For
                        '        ElseIf node.InnerText.Length Then
                        '            ris = node.InnerText
                        '            Exit For
                        '        End If
                        '    End If
                        'End If
                    Next
                End If
            Catch ex As Exception
                'Stop

            End Try

            Return ris
        End Function

    End Class

    Public Class Printer
        Public Shared Function ElencoInstallate() As List(Of String)
            Dim Ris As New List(Of String)

            For Each x As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                Ris.Add(x)
            Next

            Return Ris
        End Function

        Public Shared Function IsInstalled(Printer As String) As Boolean
            Dim ris As Boolean = False

            For Each stampante As String In ElencoInstallate()
                If stampante.ToLower = Printer.ToLower Then
                    ris = True
                    Exit For
                End If
            Next

            Return ris

        End Function

    End Class

    Public Class Telnet

        Private Shared _client As TcpClient
        Private Shared _data As String

        Private Shared _sendbuffer(128) As Byte
        Private Shared _readbuffer(128) As Byte
        Private Shared _bytecount As Integer

        Private Shared _stream As NetworkStream

        Public Shared Sub ResetRouter(Optional Ip As String = "192.168.1.1")

        End Sub

        Private Shared Sub Send(ByVal Text As String)
            _sendbuffer = Encoding.ASCII.GetBytes(Text)
            _stream.Write(_sendbuffer, 0, _sendbuffer.Length)
        End Sub

        Private Shared Sub Read()
            _bytecount = _stream.Read(_readbuffer, 0, _readbuffer.Length)
            _data = Encoding.ASCII.GetString(_readbuffer)
        End Sub

    End Class

    Public Class Calendario

        Public Shared Function MeseToString(ByVal Num As Integer) As String
            Dim Mese As String = ""

            Select Case Num
                Case 1
                    Mese = "Gennaio"
                Case 2
                    Mese = "Febbraio"
                Case 3
                    Mese = "Marzo"
                Case 4
                    Mese = "Aprile"
                Case 5
                    Mese = "Maggio"
                Case 6
                    Mese = "Giugno"
                Case 7
                    Mese = "Luglio"
                Case 8
                    Mese = "Agosto"
                Case 9
                    Mese = "Settembre"
                Case 10
                    Mese = "Ottobre"
                Case 11
                    Mese = "Novembre"
                Case 12
                    Mese = "Dicembre"
            End Select

            Return Mese

        End Function

    End Class

    Public Class Numeri

        Public Shared Function GetNumeroCasuale(Optional Minimo As Integer = 100, Optional Massimo As Integer = 9999999) As Integer
            Dim ris As Integer = 0
            Randomize()
            Dim rnd As New Random(DateTime.Now.Millisecond)

            ris = rnd.Next(Minimo, Massimo)

            Return ris
        End Function

    End Class

    Public Class Security

        Public Shared Function IsBase64(ByVal base64String As String) As Boolean
            Dim ris As Boolean = False
            If String.IsNullOrEmpty(base64String) OrElse base64String.Length Mod 4 <> 0 OrElse base64String.Contains(" ") OrElse base64String.Contains(vbTab) OrElse base64String.Contains(vbCr) OrElse base64String.Contains(vbLf) Then Return False

            Try
                Convert.FromBase64String(base64String)
                ris = True
            Catch exception As Exception

            End Try

            Return ris
        End Function

        Public Shared Function GeneraPassword() As String
            Dim ris As String = ""
            Dim R As New Random
            ris = R.Next(10000000, 99999999)
            Return ris
        End Function

        Public Shared Function Cripta(ByVal pwd As String) As String
            Dim lunghezzaPwd As Integer
            Dim i As Integer
            Dim codAscii As Long
            Dim pwdCriptata As String

            'Let pwd = StrConv(pwd, vbUpperCase)
            lunghezzaPwd = Len(pwd)
            pwdCriptata = ""

            For i = 1 To lunghezzaPwd
                codAscii = Asc(Mid(pwd, i, 1))
                codAscii = 255 - codAscii
                pwdCriptata = pwdCriptata & Chr(codAscii)
            Next i

            Cripta = pwdCriptata
        End Function

        Private Shared Key As String = "ZAMIRAEDIEGO18092008"
        Private Shared ReadOnly IVector As Byte() = New Byte(7) {1, 8, 0, 9, 2, 0, 0, 8}

        Public Shared ReadOnly Property GetSecurityCheckForExternalResources() As String
            Get
                Dim ris As String = "##F0RM3R##"
                Return ris
            End Get
        End Property

        Public Shared Function DecriptaURL(ByVal Url As String)
            Try
                Dim lunghezzaPwd As Integer
                Dim i As Integer
                Dim codAscii As Long
                Dim newcodAscii As Long
                Dim pwdCriptata As String
                Dim Numero As Integer

                Numero = Url.Substring(0, 1)
                Url = Url.Substring(1)
                'Let pwd = StrConv(pwd, vbUpperCase)
                lunghezzaPwd = Len(Url)
                pwdCriptata = ""

                For i = 1 To lunghezzaPwd
                    codAscii = (Mid(Url, i, 3))
                    i += 2
                    newcodAscii = codAscii - Numero
                    pwdCriptata = pwdCriptata & Chr(newcodAscii)
                Next i

                Return pwdCriptata
            Catch e As Exception
                Return String.Empty
            End Try
        End Function

        Public Shared Function CriptaURL(ByVal Url As String)

            Try
                Dim lunghezzaPwd As Integer
                Dim i As Integer
                Dim codAscii As Long
                Dim newcodAscii As Long
                Dim strNewCod As String
                Dim pwdCriptata As String
                Dim Numero As Integer
                Dim R As New Random
                Numero = R.Next(1, 9)
                'Let pwd = StrConv(pwd, vbUpperCase)

                lunghezzaPwd = Len(Url)
                pwdCriptata = ""

                For i = 1 To lunghezzaPwd
                    codAscii = Asc(Mid(Url, i, 1))
                    newcodAscii = codAscii + Numero
                    strNewCod = newcodAscii
                    Do Until strNewCod.Length = 3
                        strNewCod = "0" & strNewCod
                    Loop
                    pwdCriptata = pwdCriptata & (strNewCod)
                Next i
                pwdCriptata = Numero & pwdCriptata

                Return pwdCriptata
            Catch e As Exception
                Return e.Message
            End Try
        End Function

        Public Shared Function Crypt3DES(ByVal str As String) As String

            '//Create a new RSA key. This key will encrypt a symmetric key,
            '//which will then be imbedded in the XML document. 
            Dim ris As String = ""
            Try
                '//Get a byte array of the str as encryption works on byte blocks
                Dim enc As New ASCIIEncoding
                Dim byteData() As Byte = enc.GetBytes(str)

                '//Create encryption object
                Dim tDes As New TripleDESCryptoServiceProvider()
                Dim MD5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()

                '//Specify Initialisation Vector as encryption key to use
                tDes.IV = IVector
                tDes.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key))

                '//Adds key and IVector to Encrypt object
                Dim ITransform As CryptoAPITransform
                ITransform = tDes.CreateEncryptor()

                ris = Convert.ToBase64String(ITransform.TransformFinalBlock(byteData, 0, byteData.Length))
            Catch ex As Exception

            End Try

            Return ris

        End Function

        Public Shared Function Decrypt3DES(ByVal base64_str As String) As String

            Dim ris As String = ""
            '//Perform as decrypt of encytpted data with above method
            Try
                '//Get byte array from string
                Dim encData() As Byte = Convert.FromBase64String(base64_str)

                '//Create encryption object
                Dim tDes As New TripleDESCryptoServiceProvider()
                Dim MD5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
                '//Specify Initialisation Vector as encryption key to use
                tDes.IV = IVector
                tDes.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key))

                '//Adds key and IVector to decrypt object
                Dim ITransform As CryptoAPITransform
                ITransform = tDes.CreateDecryptor()

                ris = Encoding.ASCII.GetString(ITransform.TransformFinalBlock(encData, 0, encData.Length()))
            Catch ex As Exception

            End Try

            Return ris

        End Function

        Public Shared Function GetMd5Hash(ByVal input As String) As String

            Using md5Hash As MD5 = MD5.Create()
                Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
                Dim sBuilder As New StringBuilder()
                For i As Integer = 0 To data.Length - 1
                    sBuilder.Append(data(i).ToString("x2"))
                Next i
                Return sBuilder.ToString()
            End Using

        End Function

        Public Shared Function CheckMd5Hash(ByVal input As String, ByVal hash As String) As Boolean

            Dim ris As Boolean = False
            Using md5Hash As MD5 = MD5.Create()
                Dim hashOfInput As String = GetMd5Hash(input)
                If hash = hashOfInput Then
                    ris = True
                End If
            End Using
            Return ris

        End Function

        Public Shared Function CalcolaChiave(ByVal Id As String) As String

            Dim Risultato As String = ""
            Try
                If Id = "1703" Then
                    Risultato = "oh31mnj24f"
                Else
                    Dim Ris As String = ""

                    Ris = CInt(Id) * 1809 ^ 2

                    Dim car As String

                    For Each car In Ris

                        Risultato &= Chr(CInt(car) + 70)

                    Next
                End If
            Catch ex As Exception

            End Try

            Return Risultato

        End Function

        Private Shared Function GetLetteraCasuale() As String

            Dim ris As String = String.Empty
            Randomize()
            Dim r As New Random
            Dim TempId As Integer = r.Next(97, 122)
            ris = Chr(TempId)
            Return ris

        End Function

        Private Shared Function GetNumeroDaLettera(Lettera As String) As Integer

            Dim ris As Integer = 0

            Select Case Lettera
                Case "a"
                    ris = 0
                Case "C"
                    ris = 1
                Case "D"
                    ris = 2
                Case "g"
                    ris = 3
                Case "4"
                    ris = 4
                Case "o"
                    ris = 5
                Case "R"
                    ris = 6
                Case "V"
                    ris = 7
                Case "z"
                    ris = 8
                Case "9"
                    ris = 9
            End Select

            Return ris

        End Function

        Private Shared Function GetLetteraDaNumero(Numero As Integer) As String

            Dim ris As String = String.Empty

            Select Case Numero
                Case 0
                    ris = "a"
                Case 1
                    ris = "C"
                Case 2
                    ris = "D"
                Case 3
                    ris = "g"
                Case 4
                    ris = "4"
                Case 5
                    ris = "o"
                Case 6
                    ris = "R"
                Case 7
                    ris = "V"
                Case 8
                    ris = "z"
                Case 9
                    ris = "9"
            End Select

            Return ris

        End Function

        Public Shared Function CriptaID(Id As Integer) As String

            'prima lettera casuale, poi una serie di numeri in cui il primo mi dice quanti sono i casuali dopo
            'poi l'id criptato a lettere e numeri 
            Dim ris As String = String.Empty
            Randomize()
            Dim r As New Random
            ris = GetLetteraCasuale()
            Dim numChar As Integer = r.Next(3, 6)
            ris &= numChar
            For i As Integer = 1 To numChar
                ris &= r.Next(0, 9)
            Next
            For Each singNum As String In Id.ToString.ToCharArray
                ris &= GetLetteraDaNumero(singNum)
            Next
            Return ris

        End Function

        Public Shared Function DecriptaID(IdCriptato As String) As Integer

            Dim ris As Integer = 0
            Dim IdTemp As String = String.Empty
            IdCriptato = IdCriptato.Substring(1)
            Dim QuantiSaltare As Integer = CInt(IdCriptato.Substring(0, 1))
            IdCriptato = IdCriptato.Substring(QuantiSaltare + 1)

            For Each singchar In IdCriptato
                IdTemp &= GetNumeroDaLettera(singchar)
            Next

            ris = CInt(IdTemp)

            Return ris

        End Function

    End Class

    Public Class Mail

        Public Shared Property SMTPServerPEC As String = "smtps.pec.aruba.it" '"smtp.tipografiaformer.com"
        Public Shared Property SMTPServer As String = "smtp.tipografiaformer.it" '"smtp.tipografiaformer.com"
        Public Shared Property SMTPLogin As String = "postmaster@tipografiaformer.it" '"amministrazione@tipografiaformer.com"
        Public Shared ReadOnly Property SMTPPwd As String
            ' = "tghi9maeqa" '"amministrazione"
            Get
                Return FormerConfig.FConfiguration.Ftp.ServerPwdProduzione
            End Get
        End Property
        Public Shared Property SMTPFromEmail As String = "info@tipografiaformer.it" '"amministrazione@tipografiaformer.com"
        Public Shared Property SMTPFromName As String = "TipografiaFormer.it"

        Public Shared Function IsValidEmailAddress(Email As String) As Boolean

            Dim ris As Boolean = False

            Email = Email.Trim

            Dim RegExpres As String = ""

            'RegExpres = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            RegExpres = "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"
            'RegExpres = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.[A-Za-z][A-Za-z\.]*[A-Za-z]$"
            'RegExpres = "^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$"
            'Dim r As New Regex(RegExpres)

            If Regex.IsMatch(Email, RegExpres, RegexOptions.IgnoreCase) Then
                ris = True
                Dim Pos As Integer = Email.LastIndexOf(".")
                Dim DomExt As String = Email.Substring(Pos + 1)
                For Each car As Char In DomExt
                    If Char.IsLetter(car) = False Then
                        ris = False
                        Exit For
                    End If
                Next
            End If

            Return ris

        End Function

        'Public Shared Function InserisciMailInUscita(Optional IdEmail As Integer = 0, _
        '                                            Optional Titolo As String = "", _
        '                                            Optional Quando As DateTime = Nothing, _
        '                                            Optional Testo As String = "", _
        '                                            Optional IdRubDest As Integer = 0, _
        '                                            Optional IdMarketing As Integer = 0, _
        '                                            Optional Livello As Integer = 0, _
        '                                            Optional DaInviare As Integer = 0, _
        '                                            Optional Mittente As String = "", _
        '                                            Optional Destinatario As String = "", _
        '                                            Optional FromName As String = "", _
        '                                            Optional Stato As Integer = 0, _
        '                                            Optional DataInvio As DateTime = Nothing, _
        '                                            Optional Sorgente As String = "", _
        '                                            Optional PathAllegato1 As String = "", _
        '                                            Optional PathAllegato2 As String = "", _
        '                                            Optional ErroreInvio As String = "", _
        '                                            Optional ccn As String = "") As Integer

        '    Dim Ris As Integer = 0



        '    Return Ris

        'End Function

        Private Shared Function PulisciCaratteriSpeciali(Buffer As String) As String
            Dim ris As String = Buffer

            ris = ris.Replace("á", "&aacute;")
            ris = ris.Replace("à", "&agrave;")
            ris = ris.Replace("é", "&eacute;")
            ris = ris.Replace("è", "&egrave;")
            ris = ris.Replace("ó", "&oacute;")
            ris = ris.Replace("ò", "&ograve;")
            ris = ris.Replace("ú", "&uacute;")
            ris = ris.Replace("ù", "&ugrave;")
            Return ris
        End Function

        Public Shared Function InviaMail(Soggetto As String,
                                         ByVal Testo As String,
                                         Dest As String,
                                         Optional FromAddr As String = "noreply@tipografiaformer.it",
                                         Optional FromName As String = "TipografiaFormer.it",
                                         Optional Allegato1 As String = "",
                                         Optional Allegato2 As String = "",
                                         Optional CCN As String = "",
                                         Optional WithUnsubscribe As Boolean = False,
                                         Optional WithAutoGenerated As Boolean = True,
                                         Optional BorderType As enTipoBordoEmail = enTipoBordoEmail.Standard,
                                         Optional WithHeaderTextLogo As Boolean = True,
                                         Optional Allegato3 As String = "") As Integer

            Dim Ris As Integer = 0

            Dim l As New List(Of String)

            If Allegato1.Length Then l.Add(Allegato1)
            If Allegato2.Length Then l.Add(Allegato2)
            If Allegato3.Length Then l.Add(Allegato3)

            Ris = InviaMailEx(Soggetto, Testo, Dest, l, FromAddr, FromName, CCN, WithUnsubscribe, WithAutoGenerated, BorderType, WithHeaderTextLogo)

            Return Ris

        End Function

        Public Shared Function InviaMailEx(Soggetto As String,
                                           ByVal Testo As String,
                                           Dest As String,
                                           ListaAllegati As List(Of String),
                                           Optional FromAddr As String = "noreply@tipografiaformer.it",
                                           Optional FromName As String = "TipografiaFormer.it",
                                           Optional CCN As String = "",
                                           Optional WithUnsubscribe As Boolean = False,
                                           Optional WithAutoGenerated As Boolean = True,
                                           Optional BorderType As enTipoBordoEmail = enTipoBordoEmail.Standard,
                                           Optional WithHeaderTextLogo As Boolean = True)

            Dim Ris As Integer = 0
            Try

                Using msg As New MailMessage()
                    msg.Subject = "Tipografiaformer.it - " & Soggetto
                    msg.IsBodyHtml = True

                    Dim Header As String = ""

                    If WithHeaderTextLogo Then
                        Header = "<div>"
                        Header &= "<a href=""https://www.tipografiaformer.it""><img src=""https://www.tipografiaformer.it/img/logopiccolo.png"" border=0></a>"
                        Header &= "<div style=""float:right;"">"
                        Header &= "<a href=""https://www.facebook.com/tipografiaformer.it""><img src=""https://www.tipografiaformer.it/img/btnFacebook.png""/></a>&nbsp;"
                        Header &= "<a href=""https://www.instagram.com/tipografiaformer/""><img src=""https://www.tipografiaformer.it/img/btnInstagram.png""/></a>&nbsp;"
                        Header &= "<a href=""https://twitter.com/FormerOfficial""><img src=""https://www.tipografiaformer.it/img/btnTwitter.png""/></a>&nbsp;"
                        Header &= "<a href=""https://www.youtube.com/user/tipografiaformer""><img src=""https://www.tipografiaformer.it/img/btnYoutube.png""/></a>"
                        Header &= "</div>"
                        Header &= "</div>"
                        Header &= "<hr style=""border:1px solid darkgray;"">"
                    End If
                    Dim Footer As String = String.Empty

                    If WithUnsubscribe Then
                        Footer = "<br><br><center><font face=""Arial"" size=""1"" color=""gray"">Riceve questa e-mail perch&eacute; il suo nominativo &egrave; inserito nell'indirizzario di Tipografia Former, che si impegna a custodire e utilizzare i suoi dati con la massima riservatezza <br>secondo le disposizioni del D.Lgs. 196/2003. " &
                            "<br>A norma di tale Legge potr&agrave; esercitare il diritto di non ricevere pi&ugrave; comunicazioni </font><a href=""https://www.tipografiaformer.it/unsubscribe/" & FormerHelper.Security.CriptaURL(Dest) &
                            """><font face=""Arial"" size=""1"" color=""gray"">cliccando qui</font></a></center>"
                        'Footer = "<br><br><center><a href=""http://www.tipografiaformer.it/unsubscribe/" & FormerHelper.Security.CriptaURL(Dest) & _
                        '   """><font face=""Arial"" size=""1"" color=""gray"">Se non vuoi piu ricevere le nostre email clicca qui</font></a></center>"
                    Else
                        Footer = "<br><br>"
                    End If

                    If WithUnsubscribe = False Then Footer &= "Cordiali saluti<br>"

                    Footer &= "<hr style=""border:1px solid darkgray;""></font>" &
                        "<a href=""https://www.tipografiaformer.it""><img src=""https://www.tipografiaformer.it/img/logo.png"" border=0></a><br/>" &
                        "<font face=""Arial"" size=""1""><b>STABILIMENTO E UFFICI</b>: Via Cassia, 2010 - 00123 Roma<br>" &
                        "<b>SERVIZIO CLIENTI</b>: 06.30884518 Fax: 06.30884057 Dal Lunedi al Venerdi, con orario continuato 8.30-19.00<br>" &
                        "<a href=""https://www.tipografiaformer.it"">https://www.tipografiaformer.it/</a></font><br><br>"

                    If WithAutoGenerated Then Footer &= "<center><font face=""Arial"" size=""1"" color=""gray"">Nota: questa e-mail &egrave; generata automaticamente e non avremo la possibilit&agrave; di leggere eventuali e-mail di risposta. Non rispondere a questo messaggio.</font></center>"

                    Dim TestoFinale As String = String.Empty

                    Select Case BorderType
                        Case enTipoBordoEmail.Nessuno
                            TestoFinale = Header & Testo & Footer
                        Case enTipoBordoEmail.Standard
                            TestoFinale = "<div style=""border:40px solid #d6e03d;font-family:Arial;font-size:14px;padding:20px;border-radius:15px;"">"
                            TestoFinale &= Header & Testo & Footer
                            TestoFinale &= "</div>"
                        Case enTipoBordoEmail.Azzurro
                            TestoFinale = "<div style=""border:40px solid #009ec9;font-family:Arial;font-size:14px;padding:20px;"">"
                            TestoFinale &= Header & Testo & Footer
                            TestoFinale &= "</div>"

                    End Select

                    msg.Body = PulisciCaratteriSpeciali(TestoFinale)

                    If Dest.Trim.Length Then
                        For Each d As String In Dest.Split(";")
                            msg.To.Add(d.TrimEnd(";"))
                        Next
                    End If

                    msg.From = New MailAddress(FromAddr, FromName)

                    If CCN.Trim.Length Then
                        For Each d As String In CCN.Split(";")
                            msg.Bcc.Add(d.TrimEnd(";"))
                        Next
                    End If

                    If Not ListaAllegati Is Nothing Then

                        For Each Allegato As String In ListaAllegati
                            If System.IO.File.Exists(Allegato) Then
                                Dim a As New Net.Mail.Attachment(Allegato)
                                a.ContentId = FormerHelper.File.EstraiNomeFile(Allegato)
                                msg.Attachments.Add(a)
                            End If
                        Next

                    End If

                    Using sm As New SmtpClient(SMTPServer)
                        Dim c As New System.Net.NetworkCredential(SMTPLogin, SMTPPwd)
                        sm.UseDefaultCredentials = False
                        sm.Credentials = c
                        sm.Send(msg)
                    End Using
                End Using

            Catch ex As Exception
                If ex.Message.IndexOf("policy violation") <> -1 Then
                    'qui devo loggare in qualche modo la violazione di policy 
                    Try
                        My.Application.Log.WriteException(ex, TraceEventType.Error, "Policy Violation")
                    Catch exPolicy As Exception

                    End Try
                End If
                Ris = 1
            End Try
            Return Ris

        End Function

    End Class

    Public Class File

        <DllImport("mpr.dll")>
        Public Shared Function WNetGetConnection(ByVal lpLocalName As String, ByVal lpRemoteName As StringBuilder, ByRef lpnLength As Integer) As Integer
        End Function

        Public Shared Function TranslateRealDrivePath(DrivePath As String) As String
            'torna lo stesso path ma con il percorso di rete e non il nome dell'unita mappata

            Dim ris As String = String.Empty
            Dim drvName As String = DrivePath.Substring(0, 2)
            Dim Oltre As String = DrivePath.Substring(2)

            Dim UncPath As New StringBuilder(255)
            WNetGetConnection(drvName, UncPath, UncPath.Capacity)

            If FormerDebug.DebugAttivo AndAlso DrivePath.ToLower.StartsWith("z") Then
                ris = DrivePath.ToLower.Replace("z:\", "\\former-server\Z\")
            Else
                ris = UncPath.ToString & Oltre
            End If

            Return ris

        End Function

        Public Shared Function GetMappedDrivePath(Path As String) As String
            Dim ris As String = Path

            If Path.StartsWith("\\") Then
                'qui devo vedere se ho un drive di sistema che mappa questo path 
                Dim PathToFind As String = Path
                Dim Posizione As Integer = -1
                For i As Integer = 0 To 3
                    Posizione = PathToFind.IndexOf("\", Posizione + 1)
                Next

                If Posizione <> -1 Then
                    PathToFind = PathToFind.Substring(0, Posizione) & "\"
                End If

                Dim Drives As DriveInfo() = DriveInfo.GetDrives

                For Each singDrive As DriveInfo In Drives

                    If singDrive.DriveType = DriveType.Network Then
                        'qui devo vedere se mi torna
                        Dim PathReal As String = TranslateRealDrivePath(singDrive.RootDirectory.FullName)

                        If PathReal.ToLower.StartsWith(PathToFind.ToLower) Then
                            'lettera trovata 
                            ris = singDrive.RootDirectory.FullName & Path.Substring(Posizione + 1)
                            Exit For
                        End If

                    End If

                Next

            End If

            Return ris
        End Function

        Public Shared Function GetMB(PathFile As String) As Integer
            Dim ris As Integer = 0

            Try
                Dim f As New FileInfo(PathFile)

                ris = f.Length / 1048576

                f = Nothing
            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Function IsFileLocked(PathFile As String) As Boolean
            Dim stream As FileStream = Nothing
            Dim ris As Boolean = False

            Try

                If System.IO.File.Exists(PathFile) Then
                    Dim f As New FileInfo(PathFile)
                    stream = f.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                    f = Nothing
                End If

            Catch generatedExceptionName As IOException
                'the file is unavailable because it is:
                'still being written to
                'or being processed by another thread
                'or does not exist (has already been processed)
                ris = True
            Finally
                If stream IsNot Nothing Then
                    stream.Close()
                End If
            End Try

            'file is not locked
            Return ris
        End Function

        Public Shared Function CreaFileHtml(Buffer As String) As String

            Dim PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")

            Using Sr As New StreamWriter(PathFileStampa, False)

                Sr.Write(Buffer)

            End Using

            Return PathFileStampa

        End Function

        Public Shared Function GetEstensione(NomeFile As String) As String

            Dim ris As String = String.Empty

            Dim Posiz As Integer = NomeFile.LastIndexOf(".")

            If Posiz <> -1 Then
                ris = NomeFile.Substring(Posiz + 1)
            End If

            Return ris

        End Function

        Public Shared Function GetNomeFileTemp(Optional ByVal extension As String = ".jpg",
                                               Optional ByVal AddToBeReplaced As Boolean = False,
                                               Optional ByVal Prefisso As String = "") As String

            Dim Numero As New Random

            Randomize()

            Dim NomeFile As String = String.Empty

            If AddToBeReplaced Then
                NomeFile &= FormerLib.FormerConst.PrefissoFileListinoTemp
            End If

            If Prefisso.Length Then
                NomeFile &= Web.NormalizzaPrefissoFile(Prefisso) & "-"
            End If

            NomeFile &= Now.Year & Now.Month.ToString("00") & Now.Day.ToString("00") & Now.Hour.ToString("00") & Now.Minute.ToString("00") & Now.Second.ToString("00") & Now.Millisecond & Numero.Next(0, 1000) & extension

            Return NomeFile

        End Function

        Public Shared Function EstraiNomeFile(ByVal NomeFileLungo As String,
                                              Optional ByVal IdOrdinePrefisso As Integer = 0) As String

            Dim NuovoNome As String = String.Empty

            Dim posizione As Integer = NomeFileLungo.LastIndexOf("\")
            NuovoNome = NomeFileLungo.Substring(posizione + 1)

            If IdOrdinePrefisso Then
                NuovoNome = IdOrdinePrefisso & "_" & NuovoNome
            End If
            Return NuovoNome

        End Function

        Public Shared Function GetNomeFileFtp(ByVal NomeFile As String) As String

            Dim NuovoNome As String = String.Empty

            Dim posizione As Integer = NomeFile.LastIndexOf("/")
            NuovoNome = NomeFile.Substring(posizione + 1)

            Return NuovoNome

        End Function

        Public Shared Sub OpenWithDialog(Path As String)
            Try
                Dim x As New Process
                x.StartInfo.FileName = "rundll32.exe"
                x.StartInfo.UseShellExecute = False
                x.StartInfo.RedirectStandardOutput = True
                x.StartInfo.Arguments = "shell32.dll,OpenAs_RunDLL " + Path
                x.Start()
            Catch ex As Exception

            End Try

        End Sub

        Public Shared Sub ShellExtended(ByVal Path As String)

            Try

                Dim x As New Process

                x.StartInfo.FileName = Path
                x.Start()

            Catch ex As Exception

            End Try

        End Sub

        Public Shared Sub ShellExtended(ByVal AppPath As String, ByVal AppArgument As String)

            Try

                Dim x As New Process

                x.StartInfo.FileName = AppPath
                x.StartInfo.Arguments = AppArgument
                x.Start()

            Catch ex As Exception

            End Try

        End Sub

        Public Shared Sub CreateLongPath(ByVal LongPath As String)

            If System.IO.Directory.Exists(LongPath) = False Then
                Dim sBuild As String = String.Empty
                Dim startpos As Integer = 2

                If LongPath.StartsWith("\\") Then
                    startpos = 3
                End If

                While InStr(startpos, LongPath, "\") > 1
                    sBuild = sBuild & Left(LongPath, InStr(startpos, LongPath, "\") - 1)
                    LongPath = Mid(LongPath, InStr(startpos, LongPath, "\"))
                    If Dir(sBuild, 16) = "" Then
                        System.IO.Directory.CreateDirectory(sBuild)
                    End If
                End While
            End If

        End Sub

        Public Shared Function GetFolder(ByVal Path As String) As String

            Return Path.Substring(0, Path.LastIndexOf("\"))

        End Function

        Public Shared Sub UncompressFile(ByVal PathFile As String,
                                         ByVal PathDest As String,
                                         Optional PreserveStructure As Boolean = True)

            If System.IO.File.Exists(PathFile) Then
                'If Not System.IO.Directory.Exists(PathDest) Then
                CreateLongPath(PathDest)
                'End If
                Try
                    SevenZip.SevenZipCompressor.SetLibraryPath(FormerPath.PathLocale & "7z.dll")
                    Using Extr As New SevenZip.SevenZipExtractor(PathFile)
                        Extr.PreserveDirectoryStructure = PreserveStructure
                        Extr.ExtractArchive(PathDest)
                    End Using
                Catch ex As Exception

                End Try
            Else
                '?
            End If

        End Sub

    End Class

    Public Class PDF

        Public Shared Function ConvertiPDFToPS(SourcePdfFilePath As String, Optional NumCopie As Integer = 1) As Integer
            Dim Ris As Integer = -1

            Try

                Dim PathUtility As String = AppDomain.CurrentDomain.BaseDirectory & "pdftops.exe"

                If System.IO.File.Exists(PathUtility) Then
                    Dim DestPath As String = SourcePdfFilePath.ToLower.Replace(".pdf", ".ps")
                    If System.IO.File.Exists(DestPath) Then
                        Try
                            System.IO.File.Delete(DestPath)
                        Catch ex As Exception

                        End Try
                    End If

                    Dim x As New Process
                    x.StartInfo.FileName = PathUtility
                    x.StartInfo.Arguments = SourcePdfFilePath
                    'x.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    x.StartInfo.RedirectStandardOutput = True
                    x.StartInfo.UseShellExecute = False
                    x.StartInfo.CreateNoWindow = True
                    x.Start()
                    x.WaitForExit()
                    Ris = x.ExitCode
                End If

            Catch ex As Exception

            End Try

            Return Ris

        End Function

        'Public Shared Sub StampaPDF(Path As String, Printer As String)

        '    Try
        '        Using p As New Spire.Pdf.PdfDocument
        '            p.LoadFromFile(Path)

        '            p.PrinterName = Printer
        '            p.PrintFromPage = 1
        '            p.PrintToPage = p.Pages.Count
        '            Using pdoc As Printing.PrintDocument = p.PrintDocument
        '                pdoc.Print()
        '            End Using

        '            'Dim Img As Image = p.SaveAsImage(0)
        '            'Img.Save("C:\temp\gls.jpg")
        '            'Img.Dispose()
        '            p.Close()
        '        End Using

        '    Catch ex As Exception

        '    End Try

        'End Sub

        Public Shared Function GetTextFromPDF(PdfFileName As String) As String
            Dim oReader As New iTextSharp.text.pdf.PdfReader(PdfFileName)

            Dim sOut = ""

            For i = 1 To oReader.NumberOfPages
                Dim its As New iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy

                sOut &= iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
            Next

            Return sOut
        End Function

        Public Shared Function CombinaPDF(PathPdfContenitore As String,
                           PathPdfContenuto As String,
                           PathOutput As String,
                           MargineX As Single,
                           MargineY As Single,
                           CentraX As Boolean,
                           CentraY As Boolean,
                           Optional ContenitoreSopraIlContenuto As Boolean = False) As Size

            Dim Ris As New Size()
            Dim writerContenitore As iTextSharp.text.pdf.PdfWriter = Nothing

            Using ReaderContenitore As New iTextSharp.text.pdf.PdfReader(PathPdfContenitore)
                Dim rectPageContenitore As iTextSharp.text.Rectangle = Nothing
                rectPageContenitore = ReaderContenitore.GetPageSize(1)
                Ris.Width = rectPageContenitore.Width
                Ris.Height = rectPageContenitore.Height

                Using ReaderContenuto As New iTextSharp.text.pdf.PdfReader(PathPdfContenuto)
                    Dim rectPageContenuto As iTextSharp.text.Rectangle = Nothing
                    rectPageContenuto = ReaderContenuto.GetPageSize(1)

                    If MargineX = 0 Then
                        If CentraX Then
                            MargineX = (rectPageContenitore.Width - rectPageContenuto.Width) / 2
                        End If
                    End If

                    If MargineY = 0 Then
                        If CentraY Then
                            MargineY = (rectPageContenitore.Height - rectPageContenuto.Height) / 2
                        End If
                    End If

                    Using document As New Document(rectPageContenitore, 0, 0, 0, 0)
                        writerContenitore = iTextSharp.text.pdf.PdfWriter.GetInstance(document, New FileStream(PathOutput, FileMode.Create))
                        document.Open()

                        Dim pageContenitore As iTextSharp.text.pdf.PdfImportedPage = writerContenitore.GetImportedPage(ReaderContenitore, 1)
                        Dim pageContenuto As iTextSharp.text.pdf.PdfImportedPage = writerContenitore.GetImportedPage(ReaderContenuto, 1)
                        Dim cb As iTextSharp.text.pdf.PdfContentByte = writerContenitore.DirectContent

                        If CentraX = False Then MargineX = FormerHelper.PDF.TrasformaMmInPoint(MargineX)
                        If CentraY = False Then MargineY = FormerHelper.PDF.TrasformaMmInPoint(MargineY)

                        If ContenitoreSopraIlContenuto Then
                            cb.AddTemplate(pageContenuto, 1, 0, 0, 1, MargineX, MargineY)
                            cb.AddTemplate(pageContenitore, 1, 0, 0, 1, 0, 0) ' il contenitore lo metto sopra il contenuto 
                        Else
                            cb.AddTemplate(pageContenitore, 1, 0, 0, 1, 0, 0) ' il contenitore lo metto sopra il contenuto 
                            cb.AddTemplate(pageContenuto, 1, 0, 0, 1, MargineX, MargineY)
                        End If

                        document.Close()
                        writerContenitore.Close()
                    End Using
                    ReaderContenuto.Close()
                End Using
                ReaderContenitore.Close()
            End Using
            Return Ris
        End Function

        Public Shared Function GetImageResolution(SourcePdfFilePath As String) As Integer

            Dim ris As Integer = 0

            Try
                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    For i As Integer = 0 To Reader.XrefSize - 1
                        Dim oggetto As PdfObject = Reader.GetPdfObject(i)

                        If Not oggetto Is Nothing AndAlso oggetto.IsStream Then
                            Dim pdfStream As PdfStream = oggetto
                            Dim subtype As PdfObject = pdfStream.Get(iTextSharp.text.pdf.PdfName.SUBTYPE)

                            If Not subtype Is Nothing AndAlso subtype.ToString = iTextSharp.text.pdf.PdfName.IMAGE.ToString() Then

                                Dim bytes As Byte() = iTextSharp.text.pdf.PdfReader.GetStreamBytesRaw(pdfStream)

                                If Not bytes Is Nothing Then
                                    Using ms As New MemoryStream(bytes)
                                        ms.Position = 0
                                        Try
                                            Using img As Drawing.Image = Drawing.Image.FromStream(ms)
                                                ris = img.HorizontalResolution()
                                            End Using
                                        Catch ex As Exception

                                        End Try

                                    End Using
                                    'qui controllo la risoluzione dell'immagine

                                End If

                                Dim test As String = oggetto.ToString
                            End If
                        End If

                    Next

                End Using
            Catch ex As Exception

            End Try

            Return ris

        End Function

        Public Shared Function GetFontList(SourcePdfFilePath As String) As List(Of Object())

            'FONT INCORPORATI
            Dim fonts As List(Of Object()) = New List(Of Object())

            Try
                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    fonts = BaseFont.GetDocumentFonts(Reader)
                End Using

            Catch ex As Exception

            End Try

            Return fonts
        End Function

        ''' <summary>
        '''Torna abbondanza in millimetri
        '''Torna 0 se non c'e' abbondanza o l'abbondanza non e' simmetrica
        ''' </summary>
        ''' 

        Public Shared Function DocumentWithExternalLevel(SourcePdfFilePath As String) As Boolean
            Dim ris As Boolean = False

            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)
                    Dim rect As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "trim")
                    Dim rectB As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "bleed")

                    Dim RectP As iTextSharp.text.Rectangle = Reader.GetPageSize(1)

                    If RectP.Width <> rect.Width Or RectP.Height <> rect.Height Then
                        ris = True
                    End If

                End Using

            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Function GetAbbondanza(SourcePdfFilePath As String) As Integer
            Dim ris As Integer = 0
            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)
                    Dim rect As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "trim")
                    Dim rectB As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "bleed")

                    Dim rectS As Size = TrasformaRectInSize(rect)
                    Dim rectSB As Size = TrasformaRectInSize(rectB)

                    If Not rect Is Nothing AndAlso Not rectB Is Nothing Then
                        If rectB.Width > rect.Width And rectB.Height > rect.Height Then
                            'qui cerco di capire se l'abbondanza e' simmetrica o no 
                            Dim diffTop As Single = Math.Round(Math.Abs(TrasformaPointInMm(rectB.Top - rect.Top)), 2)
                            Dim diffBottom As Single = Math.Round(Math.Abs(TrasformaPointInMm(rectB.Bottom - rect.Bottom)), 2)
                            Dim diffLeft As Single = Math.Round(Math.Abs(TrasformaPointInMm(rectB.Left - rect.Left)), 2)
                            Dim diffRight As Single = Math.Round(Math.Abs(TrasformaPointInMm(rectB.Right - rect.Right)), 2)

                            If diffTop = diffBottom And diffLeft = diffRight And diffBottom = diffRight Then
                                ris = diffRight
                            Else
                                'abbondanza non simmetrica
                                ris = -1
                            End If

                        End If
                    End If


                End Using

            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Function TrasformaMmInCentesimiPollice(mm As Single) As Single
            Dim ris As Single = 0
            'point to cm dividere per 28.3464566929134

            ris = ((mm / 25.4) * 100) '* 10

            Return ris
        End Function

        Public Shared Function TrasformaMmInPoint(mm As Single) As Single

            Dim ris As Single = 0
            'point to cm dividere per 28.3464566929134
            Dim divisore As Single = 28.3464566929134
            ris = ((mm / 10) * divisore) '* 10

            Return ris

        End Function

        Public Shared Function TrasformaPointInMm(Punti As Single) As Single

            Dim ris As Single = 0
            'point to cm dividere per 28.3464566929134
            Dim divisore As Single = 28.3464566929134
            ris = (Punti / divisore) * 10

            Return ris

        End Function

        Private Shared Function TrasformaRectInSize(rect As iTextSharp.text.Rectangle) As System.Drawing.Size

            Dim ris As System.Drawing.Size

            Dim Larghezza As Single = 0
            Dim Altezza As Single = 0
            If Not rect Is Nothing Then
                Larghezza = TrasformaPointInMm(rect.Width)
                Altezza = TrasformaPointInMm(rect.Height)
                'Larghezza = ((rect.Right + rect.Left) / divisore) * 10
                'Altezza = ((rect.Top + rect.Bottom) / divisore) * 10
            End If
            ris = New System.Drawing.Size(Larghezza, Altezza)

            Return ris

        End Function

        Public Shared Function GetDimensioniPagina(SourcePdfFilePath As String) As System.Drawing.Size
            Dim ris As System.Drawing.Size

            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    '"crop", "trim", "art", "bleed" and "media"

                    'Dim rectCrop As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "crop")
                    '  Dim rectTrim As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "trim")
                    'Dim rectArt As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "art")
                    ' Dim rectBleed As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "bleed")
                    'Dim rectMedia As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "media")
                    Dim rectPage As iTextSharp.text.Rectangle = Reader.GetPageSize(1)


                    'Dim risCrop As System.Drawing.Size = TrasformaRectInSize(rectCrop)
                    '  Dim risTrim As System.Drawing.Size = TrasformaRectInSize(rectTrim)
                    '  Dim risArt As System.Drawing.Size = TrasformaRectInSize(rectArt)
                    '  Dim risBleed As System.Drawing.Size = TrasformaRectInSize(rectBleed)
                    'Dim risMedia As System.Drawing.Size = TrasformaRectInSize(rectMedia)
                    Dim risPage As System.Drawing.Size = TrasformaRectInSize(rectPage)

                    'If rectTrim Is Nothing Then
                    ris = risPage
                    '  Else
                    '  ris = risTrim
                    ' End If

                End Using
            Catch ex As Exception
                ris = New System.Drawing.Size(0, 0)
            End Try

            Return ris
        End Function

        Public Shared Function GetDimensioniPaginaInPointItext(SourcePdfFilePath As String) As iTextSharp.text.Rectangle
            Dim ris As iTextSharp.text.Rectangle = Nothing

            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    '"crop", "trim", "art", "bleed" and "media"

                    'Dim rectCrop As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "crop")
                    '  Dim rectTrim As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "trim")
                    'Dim rectArt As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "art")
                    ' Dim rectBleed As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "bleed")
                    'Dim rectMedia As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "media")
                    Dim rectPage As iTextSharp.text.Rectangle = Reader.GetPageSize(1)

                    ris = rectPage
                    '  Else
                    '  ris = risTrim
                    ' End If

                End Using
            Catch ex As Exception
                'ris = New Size(0, 0)
            End Try

            Return ris
        End Function

        Public Shared Function GetDimensioniPaginaInPoint(SourcePdfFilePath As String) As Size
            Dim ris As Size

            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    '"crop", "trim", "art", "bleed" and "media"

                    'Dim rectCrop As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "crop")
                    '  Dim rectTrim As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "trim")
                    'Dim rectArt As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "art")
                    ' Dim rectBleed As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "bleed")
                    'Dim rectMedia As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "media")
                    Dim rectPage As iTextSharp.text.Rectangle = Reader.GetPageSize(1)


                    'Dim risCrop As System.Drawing.Size = TrasformaRectInSize(rectCrop)
                    '  Dim risTrim As System.Drawing.Size = TrasformaRectInSize(rectTrim)
                    '  Dim risArt As System.Drawing.Size = TrasformaRectInSize(rectArt)
                    '  Dim risBleed As System.Drawing.Size = TrasformaRectInSize(rectBleed)
                    'Dim risMedia As System.Drawing.Size = TrasformaRectInSize(rectMedia)
                    Dim risPage As New Size(rectPage.Width, rectPage.Height)


                    'If rectTrim Is Nothing Then
                    ris = risPage
                    '  Else
                    '  ris = risTrim
                    ' End If

                End Using
            Catch ex As Exception
                ris = New Size(0, 0)
            End Try

            Return ris
        End Function

        Public Shared Function GetCanaleAlfa(SourcePdfFilePath As String) As Integer
            Dim ris As Integer = 0

            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    Dim s As String = Reader.Info.Count

                End Using

            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Function GetDimensioniTrimPagina(SourcePdfFilePath As String) As System.Drawing.Size
            Dim ris As System.Drawing.Size

            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    '"crop", "trim", "art", "bleed" and "media"

                    'Dim rectCrop As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "crop")
                    Dim rectTrim As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "trim")
                    Dim rectArt As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "art")
                    Dim rectBleed As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "bleed")
                    'Dim rectMedia As iTextSharp.text.Rectangle = Reader.GetBoxSize(1, "media")
                    Dim rectPage As iTextSharp.text.Rectangle = Reader.GetPageSize(1)


                    'Dim risCrop As System.Drawing.Size = TrasformaRectInSize(rectCrop)
                    Dim risTrim As System.Drawing.Size = TrasformaRectInSize(rectTrim)
                    Dim risArt As System.Drawing.Size = TrasformaRectInSize(rectArt)
                    Dim risBleed As System.Drawing.Size = TrasformaRectInSize(rectBleed)
                    'Dim risMedia As System.Drawing.Size = TrasformaRectInSize(rectMedia)
                    Dim risPage As System.Drawing.Size = TrasformaRectInSize(rectPage)

                    If rectTrim Is Nothing Then
                        ris = risPage
                    Else
                        ris = risTrim
                    End If

                End Using
            Catch ex As Exception
                ris = New System.Drawing.Size(0, 0)
            End Try

            Return ris
        End Function

        Public Shared Function GetOrientamentoPdf(SourcePdfFilePath As String) As enTipoOrientamento

            Dim Ris As enTipoOrientamento = enTipoOrientamento.Neutro

            'Try

            '    Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

            '        Dim dimensioni As iTextSharp.text.Rectangle = Reader.GetPageSize(1)

            '        If dimensioni.Width > dimensioni.Height Then
            '            Ris = enTipoOrientamento.Orizzontale
            '        ElseIf dimensioni.Height > dimensioni.Width Then
            '            Ris = enTipoOrientamento.Verticale
            '        End If

            '    End Using

            'Catch ex As Exception
            '    Dim testo As String = ex.Message

            'End Try

            Ris = GetOrientamentoPdfEx(SourcePdfFilePath)

            Return Ris

        End Function

        Public Shared Function GetOrientamentoPdfEx(SourcePdfFilePath As String) As enTipoOrientamento

            Dim Ris As enTipoOrientamento = enTipoOrientamento.Neutro

            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    Dim dimensioni As iTextSharp.text.Rectangle = Reader.GetPageSize(1)

                    If dimensioni.Width > dimensioni.Height Then
                        Ris = enTipoOrientamento.Orizzontale
                    ElseIf dimensioni.Height > dimensioni.Width Then
                        Ris = enTipoOrientamento.Verticale
                    End If

                    Dim PageDic As PdfDictionary = Reader.GetPageN(1)
                    If Not PageDic Is Nothing Then

                        Dim rotation As PdfNumber = PageDic.GetAsNumber(PdfName.ROTATE)

                        If Not rotation Is Nothing Then
                            If Math.Abs(rotation.IntValue) = 180 Or Math.Abs(rotation.IntValue) = 0 Then
                                'qui non devo fare niente 
                            ElseIf Math.Abs(rotation.IntValue) = 90 Or Math.Abs(rotation.IntValue) = 270 Then
                                If Ris = enTipoOrientamento.Orizzontale Then
                                    Ris = enTipoOrientamento.Verticale
                                ElseIf Ris = enTipoOrientamento.Verticale Then
                                    Ris = enTipoOrientamento.Orizzontale
                                End If
                            End If
                        End If
                    End If

                End Using

            Catch ex As Exception
                Dim testo As String = ex.Message

            End Try

            Return Ris

        End Function

        Public Shared Function GetNumeroPagine(SourcePdfFilePath As String) As Integer
            Dim ris As Integer = 0

            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    ris = Reader.NumberOfPages

                    Reader.Close()
                End Using

            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Function MergePdfFiles(ByVal pdfFiles() As String,
                                             ByVal outputPath As String) As Boolean
            Dim result As Boolean = False
            Dim pdfCount As Integer = 0     'total input pdf file count
            Dim f As Integer = 0    'pointer to current input pdf file
            Dim fileName As String
            Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
            Dim pageCount As Integer = 0

            Dim writer As PdfWriter = Nothing
            Dim cb As PdfContentByte = Nothing

            Dim page As PdfImportedPage = Nothing
            Dim rotation As Integer = 0

            Try
                pdfCount = pdfFiles.Length
                If pdfCount > 1 Then
                    'Open the 1st item in the array PDFFiles
                    fileName = pdfFiles(f)
                    reader = New iTextSharp.text.pdf.PdfReader(fileName)
                    'Get page count
                    pageCount = reader.NumberOfPages

                    Using pdfDoc As iTextSharp.text.Document = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1), 18, 18, 18, 18)

                        writer = PdfWriter.GetInstance(pdfDoc, New FileStream(outputPath, FileMode.OpenOrCreate))

                        With pdfDoc
                            .Open()
                        End With

                        'Instantiate a PdfContentByte object
                        cb = writer.DirectContent
                        'Now loop thru the input pdfs
                        While f < pdfCount
                            'Declare a page counter variable
                            Dim i As Integer = 0
                            'Loop thru the current input pdf's pages starting at page 1
                            While i < pageCount
                                i += 1
                                'Get the input page size
                                pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(i))
                                'Create a new page on the output document
                                pdfDoc.NewPage()
                                'If it is the 1st page, we add bookmarks to the page
                                'Now we get the imported page
                                page = writer.GetImportedPage(reader, i)
                                'Read the imported page's rotation
                                rotation = reader.GetPageRotation(i)
                                'Then add the imported page to the PdfContentByte object as a template based on the page's rotation
                                If rotation = 90 Then
                                    cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height)
                                ElseIf rotation = 270 Then
                                    cb.AddTemplate(page, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(i).Width + 60, -30)
                                Else
                                    cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                                End If
                            End While
                            'Increment f and read the next input pdf file
                            f += 1
                            If f < pdfCount Then
                                fileName = pdfFiles(f)
                                reader = New iTextSharp.text.pdf.PdfReader(fileName)
                                pageCount = reader.NumberOfPages
                            End If
                        End While
                        'When all done, we close the document so that the pdfwriter object can write it to the output file
                        pdfDoc.Close()
                    End Using

                    result = True
                End If
            Catch ex As Exception
                result = False
            End Try
            Return result
        End Function

        'Public Shared Sub CreaPdfBassaRisoluzione(SourcePdfFilePath As String,
        '                                  DestinationPdfFilePath As String)

        '    Try

        '        Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

        '            Using D As New Document(Reader.GetPageSizeWithRotation(1)) '
        '                Using P As New PdfCopy(D, New FileStream(DestinationPdfFilePath, FileMode.Create))
        '                    D.Open()
        '                    'D.PageSize = Reader.GetPageSize
        '                    Dim page As PdfImportedPage = P.GetImportedPage(Reader, 1)
        '                    P.AddPage(page)
        '                    P.CompressionLevel = PdfStream.BEST_COMPRESSION
        '                    P.SetFullCompression()
        '                End Using
        '                D.Close()
        '            End Using
        '            Reader.Close()
        '        End Using

        '    Catch ex As Exception

        '    End Try

        'End Sub

        Public Shared Sub EstraiPaginaFromPdf(SourcePdfFilePath As String,
                                          DestinationPdfFilePath As String,
                                          PageNumber As Integer)

            Try

                Using Reader As PdfReader = New PdfReader(SourcePdfFilePath)

                    Using D As New Document(Reader.GetPageSizeWithRotation(PageNumber)) '
                        Using P As New PdfCopy(D, New FileStream(DestinationPdfFilePath, FileMode.Create))
                            D.Open()
                            'D.PageSize = Reader.GetPageSize
                            Dim page As PdfImportedPage = P.GetImportedPage(Reader, PageNumber)
                            P.AddPage(page)
                        End Using
                        D.Close()
                    End Using
                    Reader.Close()
                End Using

            Catch ex As Exception

            End Try

        End Sub

        Public Shared Sub RuotaPdf(SourcePdfFilePath As String, DestinationPdfFilePath As String, Optional GradiRotazione As Integer = 90)

            Using reader As New PdfReader(SourcePdfFilePath)
                Using stamper As New PdfStamper(reader, New FileStream(DestinationPdfFilePath, FileMode.Create))

                    Dim PageDic As PdfDictionary = reader.GetPageN(1)
                    Dim rotation As PdfNumber = PageDic.GetAsNumber(PdfName.ROTATE)
                    Dim RotazioneDesiderata As Integer = GradiRotazione
                    If Not rotation Is Nothing Then

                        RotazioneDesiderata += rotation.IntValue

                        'RotazioneDesiderata /= 360
                    End If
                    PageDic.Put(PdfName.ROTATE, New PdfNumber(RotazioneDesiderata))
                    stamper.Close()
                End Using
            End Using

        End Sub

        Public Shared Function ResizePDF(Path As String,
                                    NewWidthMM As Integer,
                                    NewHeigthMM As Integer,
                                    Optional PathOut As String = "",
                                    Optional StretchContent As Boolean = False) As Integer
            Dim ris As Integer = 0
            Dim ReplaceOriginal As Boolean = False
            If PathOut.Length = 0 Then
                ReplaceOriginal = True
                PathOut = File.GetFolder(Path) & "\" & File.GetNomeFileTemp(".pdf")
            End If
            Try
                Dim dimensioniAttuali As Size = GetDimensioniPagina(Path)
                Using reader As New PdfReader(Path)

                    Dim LarghezzaEsistenteP As Integer = TrasformaMmInPoint(dimensioniAttuali.Width)
                    Dim AltezzaEsistenteP As Integer = TrasformaMmInPoint(dimensioniAttuali.Height)
                    Dim LarghezzaPunti As Integer = TrasformaMmInPoint(NewWidthMM)
                    Dim AltezzaPunti As Integer = TrasformaMmInPoint(NewHeigthMM)

                    If AltezzaEsistenteP > LarghezzaEsistenteP And LarghezzaPunti > AltezzaPunti Then
                        Dim Tmp As Single = LarghezzaPunti
                        LarghezzaPunti = AltezzaPunti
                        AltezzaPunti = Tmp
                    End If

                    Dim MargineSinistra As Integer = 0
                    Dim MargineSotto As Integer = 0

                    MargineSinistra = (LarghezzaPunti - LarghezzaEsistenteP) / 2
                    MargineSotto = (AltezzaPunti - AltezzaEsistenteP) / 2

                    Dim Box As New iTextSharp.text.Rectangle(LarghezzaPunti, AltezzaPunti)
                    Using doc As New Document(Box, 0, 0, 0, 0)
                        Using writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(PathOut, FileMode.Create))
                            doc.Open()
                            Dim cb As PdfContentByte = writer.DirectContent
                            Dim page As PdfImportedPage = writer.GetImportedPage(reader, 1)

                            Dim ScaleW As Single = 1
                            Dim ScaleH As Single = 1

                            If StretchContent Then

                                If MargineSinistra Then
                                    ScaleW = ((Box.Width * 100) / LarghezzaEsistenteP) / 100
                                    MargineSinistra = 0
                                End If

                                If MargineSotto Then
                                    ScaleH = ((Box.Height * 100) / AltezzaEsistenteP) / 100
                                    MargineSotto = 0
                                End If

                            End If

                            cb.AddTemplate(page, ScaleW, 0, 0, ScaleH, MargineSinistra, MargineSotto)

                            doc.Close()
                        End Using
                    End Using
                End Using

                'qui devo sostituire il file originale 
                If ReplaceOriginal Then
                    System.IO.File.Delete(Path)
                    'System.IO.File.Replace(PathOut, Path, Path.Replace(".pdf", ".bak.pdf"))
                    Rename(PathOut, Path)
                End If
            Catch ex As Exception
                ris = 1
            End Try
            Return ris
        End Function

        Public Shared Sub CreaPdfInFormato(Path As String,
                                           Width As Single,
                                           Heigth As Single,
                                           Optional Abbondanza As Integer = 0,
                                           Optional SicurezzaMM As Integer = 8,
                                           Optional AbbondanzaMM As Integer = 30,
                                           Optional IncludiIntestazione As Boolean = True,
                                           Optional IncludiAreeTaglio As Boolean = True)

            Dim Larghezza As Single = TrasformaMmInPoint(Width)
            Dim Altezza As Single = TrasformaMmInPoint(Heigth)

            Dim Allungamento As Single = 0

            Dim AbbondanzaP As Single = TrasformaMmInPoint(Abbondanza)
            Dim SicurezzaP As Single = TrasformaMmInPoint(SicurezzaMM)
            Dim AbbondanzaDocumento As Single = TrasformaMmInPoint(AbbondanzaMM)

            If IncludiIntestazione Then
                'Allungamento = TrasformaMmInPoint(100)
            End If

            Using w As FileStream = New FileStream(Path, FileMode.Create)

                Dim mainTable As New PdfPTable(1)
                mainTable.WidthPercentage = 100

                Dim CarattereNero As iTextSharp.text.Font = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA,
                                                                                     8,
                                                                                     iTextSharp.text.Font.NORMAL,
                                                                                     BaseColor.BLACK)

                'Dim customfont As BaseFont = BaseFont.CreateFont("Helvetica", "ISO-8859-1", BaseFont.EMBEDDED) ' BaseFont.HELVETICA, BaseFont.EMBEDDED)

                'Dim CarattereNero As iTextSharp.text.Font = New iTextSharp.text.Font(customfont, 8)

                '                BaseFont customfont = BaseFont.CreateFont(fontpath + "IDAutomationC128M.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
                'Font Font = New Font(customfont, 12);

                Dim rectPage As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(Larghezza + (AbbondanzaP * 2) + AbbondanzaDocumento, Allungamento + Altezza + (AbbondanzaP * 2) + AbbondanzaDocumento)
                Dim rectTrim As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(Larghezza + AbbondanzaP + (AbbondanzaDocumento / 2), Altezza + AbbondanzaP + (AbbondanzaDocumento / 2))
                Dim rectBleed As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(Larghezza + (AbbondanzaP * 4) + (AbbondanzaDocumento / 2), Altezza + (AbbondanzaP * 4) + (AbbondanzaDocumento / 2))

                rectTrim.Bottom = AbbondanzaP + (AbbondanzaDocumento / 2)
                rectTrim.Left = AbbondanzaP + (AbbondanzaDocumento / 2)

                rectBleed.Bottom = (AbbondanzaP / 2) + (AbbondanzaDocumento / 2)
                rectBleed.Left = (AbbondanzaP / 2) + (AbbondanzaDocumento / 2)

                Dim Document As New Document(rectPage)

                Dim p As PdfWriter = PdfWriter.GetInstance(Document, w)
                'p.PDFXConformance = PdfWriter.PDFX32002

                p.SetDefaultColorspace(PdfName.DEFAULTCMYK, PdfName.DEFAULTCMYK)
                'Dim profilo As ICC_Profile = p.ColorProfile

                'If IncludiAreeTaglio Then
                p.SetBoxSize("trim", rectTrim)
                p.SetBoxSize("bleed", rectBleed)
                'End If

                Document.Open()

                If IncludiAreeTaglio Then
                    'DISEGNO LE AREE 
                    Dim AreaTaglio As New iTextSharp.text.Rectangle(rectTrim.Right, rectTrim.Top)
                    AreaTaglio.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                    AreaTaglio.BorderColor = iTextSharp.text.BaseColor.BLACK
                    AreaTaglio.BorderWidth = 1
                    AreaTaglio.Border = iTextSharp.text.Rectangle.BOX
                    AreaTaglio.Bottom = rectTrim.Bottom
                    AreaTaglio.Left = rectTrim.Left
                    Document.Add(AreaTaglio)

                    'p.SetBoxSize("trim", AreaTaglio)

                    'Dim AreaBleed As New iTextSharp.text.Rectangle(rectBleed.Right, rectBleed.Top)
                    'AreaBleed.BorderColor = iTextSharp.text.BaseColor.GREEN
                    'AreaBleed.BorderWidth = 1
                    'AreaBleed.Border = iTextSharp.text.Rectangle.BOX
                    'AreaBleed.Bottom = rectBleed.Bottom
                    'AreaBleed.Left = rectBleed.Left
                    'Document.Add(AreaBleed)

                    Dim AreaSicurezza As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(AreaTaglio.Right - SicurezzaP, AreaTaglio.Top - SicurezzaP)

                    AreaSicurezza.Left = AreaTaglio.Left + SicurezzaP
                    AreaSicurezza.Bottom = AreaTaglio.Bottom + SicurezzaP
                    AreaSicurezza.BorderColor = iTextSharp.text.BaseColor.MAGENTA
                    AreaSicurezza.BorderWidth = 1
                    AreaSicurezza.Border = iTextSharp.text.Rectangle.BOX
                    Document.Add(AreaSicurezza)

                    Dim infoTable As New PdfPTable(1)

                    infoTable.WidthPercentage = 60


                    Dim CellaSpaceMain As New PdfPCell
                    CellaSpaceMain.Border = 0
                    CellaSpaceMain.FixedHeight = 150
                    CellaSpaceMain.AddElement(New iTextSharp.text.Phrase(" "))

                    infoTable.AddCell(CellaSpaceMain)

                    'METTO IL NOSTRO LOGO 

                    Dim ImgStream As Byte() = Nothing
                    Using ms = New System.IO.MemoryStream()
                        My.Resources.logo.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                        ImgStream = ms.ToArray
                    End Using
                    Dim ImgLogo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(ImgStream)

                    Dim cellaLogo As New PdfPCell
                    'cellaLogo.BackgroundColor = colorePrincipale
                    cellaLogo.FixedHeight = 30
                    cellaLogo.Border = 0
                    cellaLogo.HorizontalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER
                    cellaLogo.Padding = 5
                    cellaLogo.BackgroundColor = BaseColor.WHITE
                    cellaLogo.AddElement(ImgLogo)

                    infoTable.AddCell(cellaLogo)
                    Dim CellaSpace As New PdfPCell
                    CellaSpace.Border = 0
                    CellaSpace.FixedHeight = 10
                    CellaSpace.Padding = 5
                    CellaSpace.BackgroundColor = BaseColor.WHITE
                    CellaSpace.AddElement(New iTextSharp.text.Phrase(" "))

                    Dim cellaInfo As New PdfPCell
                    cellaInfo.AddElement(New iTextSharp.text.Phrase("Template " & Heigth & "mm x " & Width & "mm" & ControlChars.NewLine & ControlChars.NewLine))
                    cellaInfo.Border = 0
                    cellaInfo.Padding = 5
                    cellaInfo.BackgroundColor = BaseColor.WHITE
                    infoTable.AddCell(cellaInfo)

                    'Dim cellaBleed As New PdfPCell
                    'cellaBleed.AddElement(New iTextSharp.text.Phrase("AREA MARGINE"))
                    'cellaBleed.BorderColor = iTextSharp.text.BaseColor.GREEN
                    'cellaBleed.BorderWidth = 1
                    'cellaBleed.VerticalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_MIDDLE
                    'infoTable.AddCell(cellaBleed)
                    'infoTable.AddCell(CellaSpace)

                    Dim cellaTaglio As New PdfPCell
                    cellaTaglio.AddElement(New iTextSharp.text.Phrase("AREA TAGLIO"))
                    cellaTaglio.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                    cellaTaglio.BorderColor = iTextSharp.text.BaseColor.BLACK
                    cellaTaglio.BorderWidth = 1
                    cellaTaglio.PaddingLeft = 20
                    cellaTaglio.VerticalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_MIDDLE
                    'cellaTaglio.PaddingBottom = 10
                    infoTable.AddCell(cellaTaglio)
                    infoTable.AddCell(CellaSpace)

                    Dim cellaSicurezza As New PdfPCell
                    cellaSicurezza.AddElement(New iTextSharp.text.Phrase("AREA SICUREZZA"))
                    cellaSicurezza.BorderColor = iTextSharp.text.BaseColor.MAGENTA
                    cellaSicurezza.BorderWidth = 1
                    cellaSicurezza.PaddingLeft = 20
                    cellaSicurezza.VerticalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_MIDDLE
                    infoTable.AddCell(cellaSicurezza)
                    infoTable.AddCell(CellaSpace)

                    If IncludiIntestazione Then

                        Document.Add(infoTable)
                    End If
                Else
                    Dim AreaPagina As New iTextSharp.text.Rectangle(rectPage.Right, rectPage.Top)
                    'AreaPagina.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                    'AreaPagina.BorderColor = iTextSharp.text.BaseColor.BLACK
                    'AreaPagina.BorderWidth = 1
                    'AreaPagina.Border = iTextSharp.text.Rectangle.BOX
                    AreaPagina.Bottom = rectPage.Bottom
                    AreaPagina.Left = rectPage.Left
                    Document.Add(AreaPagina)
                End If

                Document.Add(mainTable)
                Document.NewPage()

                Document.Close()

                'Dim rectTrim As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(100, 100)

                'p.NewPage()
                'p.SetPageSize(rectPage)
                'p.SetBoxSize("trim", rectTrim)

            End Using

        End Sub

        Public Shared Sub CreaPdfMultiPagina(DestinationPdfFilePath As String, lstPdf As List(Of MemoryStream))

            Using Stream As FileStream = New FileStream(DestinationPdfFilePath, FileMode.Create)

                Dim Document As Document = New Document()
                Dim PdfDest As PdfSmartCopy = New PdfSmartCopy(Document, Stream)
                Try
                    Document.Open()
                    For Each PdfOrig In lstPdf
                        Using Reader As PdfReader = New PdfReader(PdfOrig)
                            PdfDest.AddPage(PdfDest.GetImportedPage(Reader, 1))
                        End Using
                    Next
                Catch ex As Exception

                Finally
                    Document.Close()
                End Try
            End Using

        End Sub

        Public Shared Sub GetPSFromPdf(SourcePdfFilePath As String,
                                        DestinationPSFilePath As String,
                                        Optional Copies As Integer = 1,
                                        Optional Formato As String = "") ', _

            Dim DimensioniAttuali As Size = GetDimensioniPaginaInPoint(SourcePdfFilePath)

            'PageSize = New GhostscriptPageSize() With {.Native = GhostscriptPageSizes.a4}
            'Dim DimensioniNuove As New Size
            'DimensioniNuove.Width = 400
            'DimensioniNuove.Height = 0


            'DimensioniNuove.Height = (DimensioniNuove.Width * DimensioniAttuali.Height) / DimensioniAttuali.Width

            'Dim DestinationPngFilePathEx As String = DestinationPngFilePath & ".tmp"

            'Using P As New Spire.Pdf.PdfDocument

            '    P.LoadFromFile(SourcePdfFilePath)
            '    Dim Formato As Imaging.ImageFormat = Imaging.ImageFormat.Png

            '    If DestinationPngFilePath.ToLower.EndsWith("png") Then
            '        Formato = Imaging.ImageFormat.Png
            '    ElseIf DestinationPngFilePath.ToLower.EndsWith("jpg") Then
            '        Formato = Imaging.ImageFormat.Jpeg
            '    ElseIf DestinationPngFilePath.ToLower.EndsWith("gif") Then
            '        Formato = Imaging.ImageFormat.Gif

            '    End If

            '    Using img As System.Drawing.Image = P.SaveAsImage(0)

            '        'img.Save(DestinationPngFilePath, Formato)
            '        Dim ImgNew As System.Drawing.Image = Nothing
            '        Using bmp As New Bitmap(img, DimensioniNuove)
            '            ImgNew = bmp
            '            'bmp.Dispose()
            '            'bmp.Save(DestinationPngFilePath, Formato)
            '            ImgNew.Save(DestinationPngFilePath, Formato)
            '        End Using

            '    End Using

            '        P.Close()

            'End Using

            'MgrImage.ResizeImgPublic(DestinationPngFilePathEx,
            '                         DestinationPngFilePath,
            '                         DimensioniNuove.Width,
            '                         DimensioniNuove.Height,,
            '                         False)

            'Try
            '    System.IO.File.Delete(DestinationPngFilePathEx)
            'Catch ex As Exception

            'End Try

            'Dim PageSize As GhostscriptPageSize '= GhostscriptDevice
            'PageSize = New GhostscriptPageSize() With {.Manual = DimensioniAttuali}

            Dim PageSize As GhostscriptPageSize '= GhostscriptDevice
            PageSize = New GhostscriptPageSize() With {.Manual = DimensioniAttuali}

            GhostscriptWrapper.GenerateOutput(SourcePdfFilePath, DestinationPSFilePath, New GhostscriptSettings() With {
                .Device = GhostscriptDevices.pswrite,
                .Page = New GhostscriptPages() With {
                     .AllPages = True
                },
                 .Resolution = New Size() With {
                     .Height = 300,
                     .Width = 300
                },
               .Size = PageSize
            })

            '.Page = New GhostscriptPages() With { _
            '       .Start = 1, _
            '       .[End] = 1, _
            '       .AllPages = False _
            '  }, _
            '   .Resolution = New Size() With { _
            '       .Height = 72, _
            '       .Width = 72 _
            '  }, _
            '   .Size = New GhostscriptPageSize() With { _
            '       .Native = GhostscriptPageSizes.a7 _
            '  } _

            'Image.ResizeImgPublic(NomeFileTempJPG, DestinationPngFilePath)
            'Try
            '    System.IO.File.Delete(NomeFileTempJPG)
            'Catch ex As Exception

            'End Try

        End Sub

        Public Shared Sub GetPdfThumbnail(SourcePdfFilePath As String,
                                          DestinationPngFilePath As String,
                                          Optional Width As Integer = 0,
                                          Optional NumeroPagina As Integer = 1) ', _

            'PRIMA DI RIDIMENSIONARE CREO UN FILE CON UNA SOLA PAGINA, LA PRIMA
            Dim NomeFileTemp As String = Path.GetDirectoryName(SourcePdfFilePath) & "\" & File.GetNomeFileTemp(".pdf")
            'Dim NomeFileTempJPG As String = Path.GetDirectoryName(SourcePdfFilePath) & "\" & File.GetNomeFileTemp()

            Dim EliminareTemporaneo As Boolean = True

            If GetNumeroPagine(SourcePdfFilePath) > 1 Then
                EstraiPaginaFromPdf(SourcePdfFilePath, NomeFileTemp, NumeroPagina)
            Else
                EliminareTemporaneo = False
                NomeFileTemp = SourcePdfFilePath
            End If

            'Optional PageSize As GhostscriptPageSizes = GhostscriptPageSizes.a4)
            ' Use GhostscriptSharp to convert the pdf to a png
            ' Only make a thumbnail of the first page
            ' Render at 72x72 dpi
            ' The dimentions of the incoming PDF must be
            ' specified. The example PDF is US Letter sized.
            'GhostscriptWrapper.GeneratePageThumb(NomeFileTemp, NomeFileTempJPG, 1, 200, 400)

            Dim DimensioniAttuali As Size = GetDimensioniPagina(SourcePdfFilePath)

            'PageSize = New GhostscriptPageSize() With {.Native = GhostscriptPageSizes.a4}
            Dim DimensioniNuove As New Size
            DimensioniNuove.Width = 400
            DimensioniNuove.Height = 0
            If Width <> 0 Then
                DimensioniNuove.Width = Width
            End If

            DimensioniNuove.Height = (DimensioniNuove.Width * DimensioniAttuali.Height) / DimensioniAttuali.Width

            'Dim DestinationPngFilePathEx As String = DestinationPngFilePath & ".tmp"

            'Using P As New Spire.Pdf.PdfDocument

            '    P.LoadFromFile(SourcePdfFilePath)
            '    Dim Formato As Imaging.ImageFormat = Imaging.ImageFormat.Png

            '    If DestinationPngFilePath.ToLower.EndsWith("png") Then
            '        Formato = Imaging.ImageFormat.Png
            '    ElseIf DestinationPngFilePath.ToLower.EndsWith("jpg") Then
            '        Formato = Imaging.ImageFormat.Jpeg
            '    ElseIf DestinationPngFilePath.ToLower.EndsWith("gif") Then
            '        Formato = Imaging.ImageFormat.Gif

            '    End If

            '    Using img As System.Drawing.Image = P.SaveAsImage(0)

            '        'img.Save(DestinationPngFilePath, Formato)
            '        Dim ImgNew As System.Drawing.Image = Nothing
            '        Using bmp As New Bitmap(img, DimensioniNuove)
            '            ImgNew = bmp
            '            'bmp.Dispose()
            '            'bmp.Save(DestinationPngFilePath, Formato)
            '            ImgNew.Save(DestinationPngFilePath, Formato)
            '        End Using

            '    End Using

            '        P.Close()

            'End Using

            'MgrImage.ResizeImgPublic(DestinationPngFilePathEx,
            '                         DestinationPngFilePath,
            '                         DimensioniNuove.Width,
            '                         DimensioniNuove.Height,,
            '                         False)

            'Try
            '    System.IO.File.Delete(DestinationPngFilePathEx)
            'Catch ex As Exception

            'End Try

            Dim PageSize As GhostscriptPageSize '= GhostscriptDevice
            PageSize = New GhostscriptPageSize() With {.Manual = DimensioniNuove}

            GhostscriptWrapper.GenerateOutput(NomeFileTemp, DestinationPngFilePath, New GhostscriptSettings() With {
                .Device = GhostscriptDevices.jpeg,
                .Page = New GhostscriptPages() With {
                     .Start = 1,
                     .[End] = 1,
                     .AllPages = False
                },
                 .Resolution = New Size() With {
                     .Height = 72,
                     .Width = 72
                },
               .Size = PageSize
            })

            '.Page = New GhostscriptPages() With { _
            '       .Start = 1, _
            '       .[End] = 1, _
            '       .AllPages = False _
            '  }, _
            '   .Resolution = New Size() With { _
            '       .Height = 72, _
            '       .Width = 72 _
            '  }, _
            '   .Size = New GhostscriptPageSize() With { _
            '       .Native = GhostscriptPageSizes.a7 _
            '  } _

            Try
                If EliminareTemporaneo Then System.IO.File.Delete(NomeFileTemp)
            Catch ex As Exception

            End Try

            'Image.ResizeImgPublic(NomeFileTempJPG, DestinationPngFilePath)
            'Try
            '    System.IO.File.Delete(NomeFileTempJPG)
            'Catch ex As Exception

            'End Try

        End Sub

        'Public Shared Sub StampaPdf(PdfFilePath As String,
        '                            PrinterName As String,
        '                            Width As Integer,
        '                            Height As Integer,
        '                            Optional Device As String = "mswinpr2")

        '    Dim ExeToUse As String = "gsdll32.dll"

        '    'If 1 = 1 Then
        '    '    ExeToUse = "gsdll64.dll"
        '    'End If

        '    'TODO: IL PATH DELLA DLL DOVREBBE PUNTARE ALLA DIRECTORY DI INSTALLAZIONE DELL'ESEGUBILE!
        '    Dim sDLLPath As String = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), ExeToUse)
        '    Dim gvi As New GhostscriptVersionInfo(New System.Version(0, 0, 0), sDLLPath, String.Empty, GhostscriptLicense.GPL)
        '    Dim processor As New Processor.GhostscriptProcessor(gvi, True)
        '    Dim switches As New List(Of String)()
        '    switches.Add("-dPrinted")
        '    switches.Add("-dBATCH")
        '    switches.Add("-dNOPAUSE")
        '    switches.Add("-dNOSAFER")
        '    switches.Add("-dDEVICEWIDTHPOINTS=" & Width)
        '    switches.Add("-dDEVICEHEIGHTPOINTS=" & Height)
        '    switches.Add("-dNumCopies=1")
        '    switches.Add("-sDEVICE=" & Device)
        '    switches.Add(Convert.ToString("-sOutputFile=%printer%") & PrinterName)
        '    switches.Add("-f")
        '    switches.Add(PdfFilePath)
        '    Try
        '        processor.StartProcessing(switches.ToArray(), Nothing)
        '    Catch ex As Exception

        '    End Try

        '    'Dim Process1 As New Process
        '    'Dim psi As New ProcessStartInfo("AcroRd32.exe", "/t """ & PdfFilePath & """ """ & PrinterName & """")
        '    'psi.CreateNoWindow = True
        '    'psi.WindowStyle = ProcessWindowStyle.Hidden
        '    'Process1.StartInfo = psi
        '    'Try
        '    '    Process1.Start()
        '    'Catch ex As Exception

        '    'End Try
        '    'Process1.WaitForInputIdle()
        '    'Process1.CloseMainWindow()
        'End Sub

        Public Shared Sub ConvertImgToPDF(ByVal PathImg As String, ByVal PathDest As String)

            Dim Image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(PathImg)

            Using fs As FileStream = New FileStream(PathDest, FileMode.Create, FileAccess.Write, FileShare.None)

                Using doc As Document = New Document(Image)
                    Using writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
                        doc.Open()
                        Image.SetAbsolutePosition(0, 0)
                        writer.DirectContent.AddImage(Image)
                        doc.Close()
                    End Using
                End Using

            End Using

        End Sub

        Public Shared Sub ConvertHTMLToPDF(ByVal HTMLCode As String,
                                           ByVal Path As String)

            'TODO: PER POTERLA UTILIZZARE ANCHE AL DI FUORI DELLA STAMPA DELLE DISTINTE DI SPEDIZIONE, BISOGNA POTER PASSARE PAGESIZE E ORIENTAMENTO COME PARAMETRO.
            Using doc As Document = New Document(iTextSharp.text.PageSize.A4.Rotate())
                Dim parser As simpleparser.HTMLWorker = New simpleparser.HTMLWorker(doc)
                Using writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(Path, FileMode.Create))
                    doc.Open()
                    For Each element As IElement In simpleparser.HTMLWorker.ParseToList(New StringReader(HTMLCode), Nothing)
                        doc.Add(element)
                    Next
                    doc.Close()
                End Using
            End Using

        End Sub

    End Class

    Public Class MgrImage

        Public Shared Function GetImageDimension(Path As String) As Size
            Dim ris As New Size

            Using img As Drawing.Image = Drawing.Image.FromFile(Path)
                ris.Width = img.Width
                ris.Height = img.Height
            End Using
            Return ris

        End Function

        ''' <param name="PathOld"></param>
        ''' <param name="PathNew"></param>
        ''' <param name="NumPixLong"></param>
        ''' <param name="NumPixShort"></param>
        ''' <param name="Watermark"></param>
        Public Shared Sub ResizeImgPublic(ByVal PathOld As String,
                                   ByVal PathNew As String,
                                   Optional ByVal NumPixLong As Integer = 800,
                                   Optional ByVal NumPixShort As Integer = 600,
                                   Optional ByVal Watermark As Boolean = False,
                                   Optional ByVal AutoSelectRotation As Boolean = True)
            Try
                Using Img As New Bitmap(PathOld)
                    Dim width As Integer = 0, height As Integer = 0
                    If AutoSelectRotation Then
                        If Img.Width > Img.Height Then
                            width = NumPixLong
                            height = NumPixShort
                        ElseIf Img.Width < Img.Height Then
                            width = NumPixShort
                            height = NumPixLong
                        Else
                            width = NumPixLong
                            height = NumPixLong
                        End If
                    Else
                        width = NumPixLong
                        height = NumPixShort
                    End If

                    Using ImgNew As Bitmap = New Bitmap(Img, New Size(width, height))
                        Using ms As New MemoryStream()
                            ImgNew.Save(ms, Imaging.ImageFormat.Jpeg)

                            Dim imgData(ms.Length - 1) As Byte
                            ms.Position = 0
                            ms.Read(imgData, 0, ms.Length)
                            Using fs As New FileStream(PathNew, FileMode.Create, FileAccess.Write)
                                fs.Write(imgData, 0, UBound(imgData))
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception

            End Try


            'If Watermark Then
            '    ImgNew = DrawWatermark(ImgNew, 10, 10)
            'End If

        End Sub

    End Class

    Public Class Web

        Public Shared Function GetUrlBuffer(Url As String) As String
            Dim ris As String = String.Empty

            Using W As New WebClient
                ris = W.DownloadString(Url)
            End Using

            Return ris
        End Function

        Public Shared Sub GetFile(Url As String, PathDest As String)

            Using W As New WebClient
                W.DownloadFile(Url, PathDest)
            End Using

        End Sub

        Public Shared Function TrasformaLink(st As String) As String
            Dim inizio As Integer
            Dim fine As Integer
            Dim url As String
            Dim strNew As String = st

            st = st.Replace("http://", "hxxp://")
            inizio = st.IndexOf("hxxp://")
            Do While inizio <> -1

                fine = st.IndexOf(" ", inizio)
                If fine = -1 Then
                    fine = st.Length
                End If
                url = st.Substring(inizio, fine - inizio)

                st = st.Replace(url, "<a href=""" & url.Replace("hxxp", "http") & """>" & url.Replace("hxxp", "http") & "</a>")
                inizio = st.IndexOf("hxxp://")
            Loop

            Return st

        End Function

        Public Shared Function IsValidIpAddress(Ip As String) As Boolean
            Dim ris As Boolean = False

            Ip = Ip.Trim

            If Regex.IsMatch(Ip, "\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b") Then
                ris = True
            End If

            Return ris
        End Function

        Public Shared Function NormalizzaUrl(url As String) As String

            url = url.Trim(" ")
            'url = url.TrimEnd(" ")
            'url = url.Replace("/", "+")
            'url = url.Replace("\", "+")
            'url = url.Replace(" ", "+")
            Dim NewUrl As String = String.Empty

            For Each s As Char In url
                If Char.IsLetterOrDigit(s) Then
                    NewUrl &= s
                Else
                    Select Case s
                        Case Is = "&"
                            NewUrl &= "e"
                        Case Else
                            NewUrl &= "-"
                    End Select
                End If
            Next

            'qui devo trovare --,---,---- e sostituirli con un trattino solo
            NewUrl = NewUrl.Replace("----", "-")
            NewUrl = NewUrl.Replace("---", "-")
            NewUrl = NewUrl.Replace("--", "-")

            Return NewUrl

        End Function

        Public Shared Function NormalizzaPrefissoFile(Prefisso As String) As String

            Prefisso = Prefisso.Trim
            Dim NewUrl As String = String.Empty

            For Each s As Char In Prefisso
                If Char.IsLetterOrDigit(s) Then
                    NewUrl &= s
                Else
                    If s = "." Then
                        NewUrl &= "."
                    Else
                        If NewUrl.EndsWith("-") = False Then NewUrl &= "-"
                    End If
                End If
            Next

            For Each S As Char In Path.GetInvalidFileNameChars
                NewUrl = NewUrl.Replace(S, "-")
            Next

            Try
                Dim tempBytes() As Byte
                tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(NewUrl)
                NewUrl = System.Text.Encoding.UTF8.GetString(tempBytes)
            Catch ex As Exception

            End Try

            NewUrl = NewUrl.Replace("?", "-")
            NewUrl = NewUrl.TrimEnd("-")
            Return NewUrl
        End Function

        Public Shared Function NormalizzaNomeFile(NomeFile As String) As String

            'url = url.Replace("&", "e")
            'url = url.Replace("/", "+")
            'url = url.Replace("\", "+")
            'url = url.Replace(" ", "+")

            NomeFile = NomeFile.Trim
            Dim NewUrl As String = String.Empty

            For Each s As Char In NomeFile
                If Char.IsLetterOrDigit(s) Then
                    NewUrl &= s
                Else
                    If s = "." Then
                        NewUrl &= "."
                    ElseIf s = "&" Then
                        NewUrl &= "e"
                    Else
                        If NewUrl.EndsWith("_") = False Then NewUrl &= "_"
                    End If
                End If
            Next

            For Each S As Char In Path.GetInvalidFileNameChars
                NewUrl = NewUrl.Replace(S, "_")
            Next

            Try
                Dim tempBytes() As Byte
                tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(NewUrl)
                NewUrl = System.Text.Encoding.UTF8.GetString(tempBytes)
            Catch ex As Exception

            End Try

            NewUrl = NewUrl.Replace("?", "_")
            NewUrl = NewUrl.TrimEnd("_")
            Return NewUrl

        End Function

        Public Shared Function IsPingable(ByRef HostNameOrAddress As String) As Boolean
            Dim Ris As Boolean = False
            Try
                Dim posSlash As Integer = HostNameOrAddress.IndexOf(" \ ")
                Dim tempPing As String = HostNameOrAddress
                If posSlash <> -1 Then
                    tempPing = HostNameOrAddress.Substring(0, posSlash)
                End If
                Ris = My.Computer.Network.Ping(tempPing, 1000)
            Catch ex As Exception

            End Try
            Return Ris
        End Function

        Public Shared Function IsOkWebsite(Url As String) As Boolean
            Dim ris As Boolean = False

            Try
                Dim request As WebRequest = WebRequest.Create(Url)
                Using response As WebResponse = request.GetResponse()
                    response.Close()
                End Using

                ris = True
            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Sub OpenWithChrome(Url As String)

            Try

                Dim x As New Process

                x.StartInfo.FileName = "chrome"
                x.StartInfo.Arguments = Url
                x.Start()

            Catch ex As Exception

            End Try

        End Sub

    End Class

    Public Class QrCode

        Private Shared _pathSave As String
        Public Shared Property pathSave() As String
            Get
                Return _pathSave
            End Get
            Set(ByVal value As String)
                _pathSave = value
            End Set
        End Property

        Private Shared _Larghezza As Integer = 100
        Public Shared Property Larghezza() As Integer
            Get
                Return _Larghezza
            End Get
            Set(ByVal value As Integer)
                _Larghezza = value
            End Set
        End Property

        Private Shared _Altezza As Integer = 100
        Public Shared Property Altezza() As Integer
            Get
                Return _Altezza
            End Get
            Set(ByVal value As Integer)
                _Altezza = value
            End Set
        End Property

        Public Shared Function CreaQrCode(DatiQr As String) As String
            Dim fn As String = "QR_" & String.Format("{0:MMddyyhhmmss}", DateTime.Now()) & ".png"

            Dim urlGoogle As String = ""
            urlGoogle = "http://chart.apis.google.com/chart?cht=qr&chs="
            urlGoogle &= Altezza & "x" & Larghezza
            urlGoogle &= "&chl="
            Try
                Dim client As New System.Net.WebClient
                'client.DownloadFile("http://chart.apis.google.com/chart?cht=qr&chs=300x300&chl=" & _datiQr, _pathSave & "/" & fn)
                client.DownloadFile(urlGoogle & DatiQr, _pathSave & "/" & fn)
                client = Nothing
            Catch ex As Exception

            End Try

            'I have an <asp:label> on my form so I can quickly test if thefile downloaded.
            Return "/public/" & fn
        End Function
        'fn: virtually unique file name based on date and time
    End Class

    Public Class EAN13

        Public Shared Function FromEAN13(ByVal CodiceLetto As String) As String

            Return CodiceLetto.Substring(0, 12)

        End Function

        'Public Shared Function TraduciBarcode(Barcode As String) As String

        '    'trasforma una serie di numeri nei caratteri reali da scrivere
        '    Dim ris As String = GetRealBarcode(Barcode)
        '    Return ris

        'End Function

        Private Shared Function GetRealBarcode(chaine As String) As String
            Dim CodeBarre As String = String.Empty, tableA As Boolean, first As Integer
            CodeBarre = Left$(chaine, 1) & Chr(65 + Val(Mid(chaine, 2, 1)))
            first = Val(Left$(chaine, 1))
            For i = 3 To 7
                tableA = False
                Select Case i
                    Case 3
                        Select Case first
                            Case 0 To 3
                                tableA = True
                        End Select
                    Case 4
                        Select Case first
                            Case 0, 4, 7, 8
                                tableA = True
                        End Select
                    Case 5
                        Select Case first
                            Case 0, 1, 4, 5, 9
                                tableA = True
                        End Select
                    Case 6
                        Select Case first
                            Case 0, 2, 5, 6, 7
                                tableA = True
                        End Select
                    Case 7
                        Select Case first
                            Case 0, 3, 6, 8, 9
                                tableA = True
                        End Select
                End Select
                If tableA Then
                    CodeBarre = CodeBarre & Chr(65 + Val(Mid(chaine, i, 1)))
                Else
                    CodeBarre = CodeBarre & Chr(75 + Val(Mid(chaine, i, 1)))
                End If
            Next
            CodeBarre = CodeBarre & "*"   'Ajout séparateur central / Add middle separator
            For i = 8 To 13
                CodeBarre = CodeBarre & Chr(97 + Val(Mid(chaine, i, 1)))
            Next
            CodeBarre = CodeBarre & "+"   'Ajout de la marque de fin / Add end mark
            Return CodeBarre

        End Function

        Public Shared Function ToEAN13(ByVal chaine As String) As String
            'Cette fonction est régie par la Licence Générale Publique Amoindrie GNU (GNU LGPL)
            'This function is governed by the GNU Lesser General Public License (GNU LGPL)
            'V 1.1.1
            'Paramètres : une chaine de 12 chiffres
            'Parameters : a 12 digits length string
            'Retour : * une chaine qui, affichée avec la police EAN13.TTF, donne le code barre
            '         * une chaine vide si paramètre fourni incorrect
            'Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
            '         * an empty string if the supplied parameter is no good
            Dim i As Integer, checksum As Integer, CodeBarre As String = String.Empty

            'Vérifier qu'il y a 12 caractères
            'Check for 12 characters
            If chaine.Length = 12 Then
                'Et que ce sont bien des chiffres
                'And they are really digits
                For i = 1 To 12
                    If Asc(Mid$(chaine, i, 1)) < 48 Or Asc(Mid$(chaine, i, 1)) > 57 Then
                        i = 0
                        Exit For
                    End If
                Next
                If i = 13 Then
                    'Calcul de la clé de contrôle
                    'Calculation of the checksum
                    For i = 12 To 1 Step -2
                        checksum = checksum + Val(Mid$(chaine, i, 1))
                    Next
                    checksum = checksum * 3
                    For i = 11 To 1 Step -2
                        checksum = checksum + Val(Mid$(chaine, i, 1))
                    Next
                    chaine = chaine & (10 - checksum Mod 10) Mod 10
                    'Le premier chiffre est pris tel quel, le deuxième vient de la table A
                    'The first digit is taken just as it is, the second one come from table A
                    CodeBarre = GetRealBarcode(chaine)

                End If

            End If
            Return CodeBarre
        End Function

    End Class

    Public Class FormerBarCode

        Public Shared Function CodiceOrdine(IdOrdine As Integer, NumCollo As Integer) As String

            Dim ris As String = FormerHelper.Stringhe.FormattaConZeri(IdOrdine, 8) & FormerHelper.Stringhe.FormattaConZeri(NumCollo, 4)

            Return ris

        End Function

    End Class

    Public Class Finanziarie

        Public Shared Function PulisciRigaFatturaFE(RigaInput As String) As String
            Dim ris As String = String.Empty

            Try
                'arriva una riga in input tipo bla bla bla 3 + 3 bla bla 300
                'e devo eliminare 300
                'ris = ris.TrimEnd(" ")
                If RigaInput.Length Then

                    For Each c In RigaInput
                        If Char.IsLetterOrDigit(c) Or c = " " Then
                            ris &= c
                        Else
                            ris &= " "
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Function PulisciRigaFattura(RigaInput As String) As String
            Dim ris As String = RigaInput

            Try
                'arriva una riga in input tipo bla bla bla 3 + 3 bla bla 300
                'e devo eliminare 300
                ris = ris.TrimEnd(" ")
                If ris.Length Then
                    Dim lastChar As String = ris.Substring(ris.Length - 1, 1)

                    If IsNumeric(lastChar) Then
                        Dim PosizSpazio As Integer = ris.LastIndexOf(" ")
                        ris = ris.Substring(0, PosizSpazio)
                    End If
                End If
            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Function GetPercentualeIva() As Integer

            Return FormerConst.Fiscali.PercentualeIva

        End Function

        Public Shared Function CalcolaImporto(Netto As Decimal, Qta As Decimal) As Decimal
            Dim ris As Decimal = 0

            ris = Netto * Qta
            ris = Finanziarie.ArrotondaImporto(ris, 2) ', MidpointRounding.AwayFromZero)

            Return ris
        End Function

        Public Shared Function CalcolaIva(Importo As Decimal,
                                          Optional PercIvaForced As Integer = 0,
                                          Optional NumeroDecimali As Integer = 2) As Decimal

            Dim Ris As Decimal = 0
            Dim PercIva As Integer = 0

            If PercIvaForced Then
                PercIva = PercIvaForced
            Else
                PercIva = GetPercentualeIva()
            End If

            Ris = (Importo * PercIva) / 100
            Ris = ArrotondaImporto(Ris, NumeroDecimali)

            Return Ris

        End Function

        Public Shared Function ArrotondaImporto(Importo As Decimal,
                                                Optional NumeroDecimali As Integer = 2) As Decimal
            Dim ris As Decimal = Math.Round(Importo, NumeroDecimali, MidpointRounding.AwayFromZero)
            Return ris
        End Function

        Public Shared Function CheckPartitaIva(ByVal sz_Codice As String,
                                               PrefissoNazione As String) As Boolean
            '======================================
            'Controllo la partita iva
            '======================================
            Dim ris As Boolean = False
            Dim n_Val As Integer
            Dim n_Som1 As Integer
            Dim n_Som2 As Integer
            Dim lcv As Integer

            If sz_Codice = FormerConst.Fiscali.PartitaIvaNonDisponibile Then
                ris = False
            Else
                If PrefissoNazione.ToUpper = FormerConst.Fiscali.PrefissoNazioneIT Then
                    'Gestione prefisso nazionale sulla partita IVA
                    If sz_Codice.Length Then
                        If Not IsNumeric(Mid(Trim(sz_Codice), 1, 2)) Then
                            sz_Codice = Mid(Trim(sz_Codice), 3, Len(sz_Codice))
                        ElseIf Not IsNumeric(Mid(Trim(sz_Codice), 1, 3)) Then
                            sz_Codice = Mid(Trim(sz_Codice), 4, Len(sz_Codice))
                        End If

                        If sz_Codice.Length <> 11 Then
                            ris = False
                        Else
                            For lcv = 1 To 9 Step 2
                                n_Val = Val(Mid$(sz_Codice, lcv, 1))
                                n_Som1 = n_Som1 + n_Val
                                n_Val = Val(Mid$(sz_Codice, lcv + 1, 1))
                                n_Som1 = n_Som1 + Int((n_Val * 2) / 10) + ((n_Val * 2) Mod 10)
                            Next lcv
                            n_Som2 = 10 - (n_Som1 Mod 10)
                            If n_Som2 = 10 Then n_Som2 = 0
                            n_Val = Val(Mid$(sz_Codice, 11, 1))
                            If n_Som2 = n_Val Then
                                ris = True
                                '    CheckPartitaIva = 0
                                'Else
                                '    CheckPartitaIva = n_Som2 + 48
                            End If
                        End If
                    End If
                Else
                    ris = True
                End If

            End If

            Return ris

        End Function

        Public Shared Function CheckCodiceFiscale(ByVal CodiceFiscale As String,
                                                        PrefissoNazione As String) As Boolean
            Dim result As Boolean = False
            Const caratteri As Integer = 16

            If PrefissoNazione.ToUpper = FormerConst.Fiscali.PrefissoNazioneIT Then

                CodiceFiscale = CodiceFiscale.Replace(" ", "")

                If Not CodiceFiscale Is Nothing Then
                    If CodiceFiscale.Length <> caratteri Then
                        If CodiceFiscale.Length = 11 Then
                            result = CheckPartitaIva(CodiceFiscale, PrefissoNazione)
                        End If
                    Else
                        Const omocodici As String = "LMNPQRSTUV"
                        Const listaControllo As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

                        Dim listaPari As Integer() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}
                        Dim listaDispari As Integer() = {1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23}

                        CodiceFiscale = CodiceFiscale.ToUpper
                        Dim cCodice As Char() = CodiceFiscale.ToCharArray

                        Dim k As Integer = 0

                        For k = 6 To 14
                            If (k = 8) OrElse (k = 11) Then
                            Else
                                Dim x As Integer = (omocodici.IndexOf(cCodice(k)))
                                If Not (x = -1) Then
                                    cCodice(k) = x.ToString.ToCharArray()(0)
                                End If
                            End If
                        Next

                        Dim rgx As Regex = New Regex("^[A-Z]{6}[]{2}[A-Z][]{2}[A-Z][]{3}[A-Z]$")
                        Dim m As Match = rgx.Match(New String(cCodice))
                        result = m.Success

                        result = True
                        If result Then
                            Dim somma As Integer = 0
                            cCodice = CodiceFiscale.ToCharArray
                            Dim i As Integer = 0
                            For i = 0 To 14
                                Dim c As Char = cCodice(i)
                                Dim x As Integer = "0123456789".IndexOf(c)
                                If Not (x = -1) Then
                                    c = listaControllo.Substring(x, 1) '.ToCharArray(0)
                                End If
                                x = listaControllo.IndexOf(c)
                                If (i Mod 2) = 0 Then
                                    x = listaDispari(x)
                                Else
                                    x = listaPari(x)
                                End If
                                somma += x
                            Next
                            result = (listaControllo.Substring(somma Mod 26, 1) = CodiceFiscale.Substring(15, 1))
                        End If
                    End If
                End If
            Else
                result = True
            End If

            Return result
        End Function

    End Class

    Public Class HTML

        Public Shared Function EliminaTag(HTMLText As String) As String

            Dim ris As String = HTMLText

            ris = ris.Replace("<br>", ControlChars.NewLine)
            ris = ris.Replace("<BR>", ControlChars.NewLine)
            ris = ris.Replace("<br/>", ControlChars.NewLine)
            ris = ris.Replace("<BR/>", ControlChars.NewLine)
            ris = ris.Replace("<br />", ControlChars.NewLine)
            ris = ris.Replace("<BR />", ControlChars.NewLine)

            ris = Regex.Replace(ris, "<.*?>", String.Empty)

            Return ris

        End Function

        Public Shared Function ConvertiTextToHtml(Testo As String) As String
            Dim ris As String = String.Empty

            ris = Testo.Replace(Chr(10), "<br>")

            Return ris
        End Function

    End Class

    Public Class Stringhe

        Public Shared Function SplittaByNumCaratteri(Buffer As String,
                                                     NumCaratteri As Integer) As String
            Dim ris As String = String.Empty

            If Buffer.Length <= NumCaratteri Then
                ris = Buffer
            Else
                'qui è per forza maggiore ControlChars.NewLine
                Dim Righe() As String = Buffer.Split(ControlChars.NewLine)

                For Each Riga In Righe

                    Riga = Riga.TrimStart(" ")
                    Riga = Riga.TrimEnd(" ")

                    While Riga.Length
                        If Riga.Length > NumCaratteri Then
                            'ris &= Riga.Substring(0, NumCaratteri).Trim(" ") & ControlChars.NewLine
                            'Riga = Riga.Substring(NumCaratteri)
                            Dim Posizione As Integer = NumCaratteri

                            Dim Carattere As Char = String.Empty

                            Do
                                Carattere = Riga(Posizione)

                                If Carattere <> " " Then Posizione -= 1

                            Loop Until Carattere = " " Or Posizione = 0

                            If Posizione = 0 Then
                                Posizione = NumCaratteri
                            End If

                            ris &= Riga.Substring(0, Posizione).Trim(" ") & ControlChars.NewLine
                            Riga = Riga.Substring(Posizione)


                        Else
                            ris &= Riga.Trim(" ") & ControlChars.NewLine
                            Riga = String.Empty
                        End If

                    End While
                Next
                ris = ris.TrimEnd(ControlChars.Cr, ControlChars.Lf)
            End If

            Return ris
        End Function

        'Public Shared Function FormattaConSpazi(ByVal Valore As String, ByVal LunghezzaTotale As Integer) As String

        '    Dim Codice As String = ""

        '    Dim I As Integer = 0

        '    For I = Valore.ToString.Length To LunghezzaTotale - 1
        '        Codice &= " "
        '    Next
        '    Codice = Valore & Codice

        '    Return Codice

        'End Function

        Public Shared Function FormattaConZeri(ByVal Valore As String, ByVal LunghezzaTotale As Integer) As String

            Return FormattaConCaratterePrefisso(Valore, LunghezzaTotale, "0")
            'Dim Codice As String = ""

            'Dim I As Integer = 0

            'For I = Numero.Length To LunghezzaTotale - 1
            '    Codice &= "0"
            'Next
            'Codice &= Numero

            'Return Codice

        End Function


        Public Shared Function FormattaConSpazi(ByVal Valore As String, ByVal LunghezzaTotale As Integer) As String

            Return FormattaConCaratterePrefisso(Valore, LunghezzaTotale, " ")
            'Dim Codice As String = ""

            'Dim I As Integer = 0

            'For I = Valore.ToString.Length To LunghezzaTotale - 1
            '    Codice &= " "
            'Next
            'Codice = Valore & Codice

            'Return Codice

        End Function

        Public Shared Function FormattaConCaratterePrefisso(ByVal Numero As String,
                                                            ByVal LunghezzaTotale As Integer,
                                                            CaratterePrefisso As String) As String

            Dim Codice As String = ""

            Dim I As Integer = 0

            For I = Numero.Length To LunghezzaTotale - 1
                Codice &= CaratterePrefisso
            Next
            Codice &= Numero

            Return Codice

        End Function

        Public Shared Function FormattaPrezzoPayPal(ByVal Val) As String
            'arriva un decimal
            Try
                Val = Finanziarie.ArrotondaImporto(Val, 2)
            Catch ex As Exception

            End Try

            Dim ris As String = Val.ToString()

            ris = ris.Replace(",", ".")

            Return ris

        End Function

        Public Shared Function FormattaPrezzoBancaSella(ByVal Val As Decimal) As String
            'arriva un decimal
            Try
                Val = Finanziarie.ArrotondaImporto(Val, 2)
            Catch ex As Exception

            End Try

            Dim ris As String = String.Empty

            ris = Format(Val, "###0.00")

            ris = ris.Replace(",", ".")

            Return ris

        End Function

        Public Shared Function FormattaPrezzoFAPA(ByVal Val) As String

            Dim ris As String = Val.ToString()
            If Val.ToString.Length = 0 Then
                Val = 0
            Else
                Val = CDbl(Val)
            End If

            Try
                Val = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Val)
                ris = Format(Val, "#.00")
                ris = ris.Replace(",", ".")
                'Return String.Format("{0:F2}", Val)
            Catch ex As Exception

            End Try

            If ris.StartsWith(".") Then ris = "0" & ris
            Return ris

        End Function

        Public Shared Function FormattaPrezzo(ByVal Val As Object, Optional NumeroDecimali As Integer = 2) As String

            Dim ris As String = Val.ToString()

            If Val.ToString.Length = 0 Then
                Val = 0
            Else
                Val = CDec(Val)
            End If

            Try
                Val = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Val, NumeroDecimali)
                Dim Formato As String = "#,##0."

                Formato &= Stringhe.FormattaConZeri("", NumeroDecimali)

                ris = Format(Val, Formato)
                'Return String.Format("{0:F2}", Val)
            Catch ex As Exception

            End Try

            Return ris

        End Function

        Public Shared Function FormatNumberNonVirgola(Val As Decimal)
            Dim ris As String = Val.ToString("N2")
            Return ris
        End Function

        Public Shared Function FormattaNumero(ByVal Val) As String
            Dim ris As String = Val.ToString()
            If Val.ToString.Length = 0 Then
                Val = 0
            Else
                Val = CDbl(Val)
            End If

            Try
                ris = Format(Val, "#,##0")
                'Return String.Format("{0:F2}", Val)
            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Function FormattaDataPerSQL(DataInput As Date) As String

            Dim ris As String = String.Empty

            ris = "convert(datetime,'" & DataInput.Day.ToString("00") & "-" & DataInput.Month.ToString("00") & "-" & DataInput.Year & "',103)"

            Return ris

        End Function

        Public Shared Function GetEtichettaPerTipoPrezzo(TipoPrezzo As enTipoPrezzo,
                                                         Optional QtaRif As Single = 0) As String
            Dim ris As String = "pezzi"

            Select Case TipoPrezzo
                Case enTipoPrezzo.SuQuantita
                    ris = "pezzi"
                'Case enTipoPrezzo.SuCCCCCCopie
                '    ris = "pezzi"
                Case enTipoPrezzo.SuFoglio
                    ris = "fogli"
                Case enTipoPrezzo.SuMetriQuadri
                    ris = "m^2"
                Case enTipoPrezzo.SuCmQuadri
                    If QtaRif = 0 Then
                        QtaRif = FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.CmQuadriEsempio
                    End If
                    ris = "pz " & QtaRif & "cm^2"
            End Select

            Return ris
        End Function

    End Class

End Class
