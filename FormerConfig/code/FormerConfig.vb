Imports System.Configuration
Imports System.IO
Imports System.Reflection

Public Class FConfiguration

    Private Const FileConfigLocale As String = "\former.exe.config.local"
    Private Const ModelloRigaConfig As String = "<add key=""{1}"" value=""{2}""/>"

    Public Shared Function DeleteLocalSettings(Key As String)

        Try
            Dim PathConfigLocale As String = System.Environment.CurrentDirectory & FileConfigLocale
            Dim Buffer As String = String.Empty
            If File.Exists(PathConfigLocale) Then
                Using R As New StreamReader(PathConfigLocale)
                    Buffer = R.ReadToEnd
                End Using
            End If

            If Buffer.Length Then
                Dim righe() As String = Buffer.Split(vbLf)
                Buffer = String.Empty

                For i = 0 To righe.Count - 1

                    Dim Posiz As Integer = righe(i).IndexOf("key=""" & Key & """")
                    If Posiz = -1 Then
                        If righe(i).TrimEnd(vbCr).Length Then Buffer &= righe(i).TrimEnd(vbCr) & ControlChars.NewLine
                    End If

                Next

            End If

            Using w As New StreamWriter(PathConfigLocale)
                w.Write(Buffer)
            End Using

        Catch ex As Exception

        End Try

    End Function

    Public Shared Function SaveValueToLocalSettings(Key As String, Value As String)
        Try
            Dim PathConfigLocale As String = System.Environment.CurrentDirectory & FileConfigLocale
            Dim Buffer As String = String.Empty
            If File.Exists(PathConfigLocale) Then
                Using R As New StreamReader(PathConfigLocale)
                    Buffer = R.ReadToEnd
                End Using
            End If

            Dim RigaValore As String = ModelloRigaConfig.Replace("{1}", Key)
            RigaValore = RigaValore.Replace("{2}", Value)

            If Buffer.Length Then
                Dim righe() As String = Buffer.Split(vbLf)
                Buffer = String.Empty

                For i = 0 To righe.Count - 1
                    If righe(i).StartsWith("<custom") = False AndAlso righe(i).StartsWith("</custom") = False Then
                        If righe(i).TrimEnd(vbCr).Length Then Buffer &= righe(i).TrimEnd(vbCr) & ControlChars.NewLine
                    End If
                Next

            End If

            If Buffer.Length Then
                Dim Posiz As Integer = Buffer.IndexOf("""" & Key & """")
                If Posiz <> -1 Then
                    Posiz = Buffer.IndexOf("=", Posiz)
                    Posiz = Buffer.IndexOf("""", Posiz)
                    Dim PosizFine As String = Buffer.IndexOf("""", Posiz + 1)
                    Buffer = Buffer.Substring(0, Posiz + 1) & Value & Buffer.Substring(PosizFine)
                Else
                    Buffer &= ControlChars.NewLine & RigaValore
                End If
            Else
                Buffer = RigaValore
            End If

            Buffer = Buffer.TrimEnd(vbCr, vbLf)


            Buffer = "<custom>" & ControlChars.NewLine & Buffer & ControlChars.NewLine & "</custom>"

            Using w As New StreamWriter(PathConfigLocale)
                w.Write(Buffer)
            End Using

        Catch ex As Exception

        End Try
    End Function

    Private Shared Function GetValue(Key As String) As String

        Dim ris As String = String.Empty

        Try
            'qui devo provare a vedere se ci sono app setting locali che sovrascrivono quello condiviso
            ris = ConfigurationManager.AppSettings(Key)

            Dim PathConfigLocale As String = System.Environment.CurrentDirectory & FileConfigLocale

            If File.Exists(PathConfigLocale) Then
                'qui provo a vedere se riesco a trovare una key locale che sovrascrive la key per tutti 

                Dim Buffer As String = String.Empty
                Using r As New StreamReader(PathConfigLocale)
                    Buffer = r.ReadToEnd
                End Using

                Dim MyDoc As New System.Xml.XmlDocument
                MyDoc.LoadXml(Buffer)

                If MyDoc.HasChildNodes Then
                    For Each node As Xml.XmlNode In MyDoc.ChildNodes

                        If node.HasChildNodes Then
                            For Each NodeC As Xml.XmlNode In node.ChildNodes
                                If NodeC.Attributes("key").Value = Key Then
                                    ris = NodeC.Attributes("value").Value
                                    Exit For
                                End If
                            Next
                        Else
                            If node.Attributes("key").Value = Key Then
                                ris = node.Attributes("value").Value
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

        Catch ex As Exception

        End Try
        If ris Is Nothing Then ris = String.Empty
        Return ris

    End Function

    Private Shared Function GetKey(M As MethodBase) As String
        Dim ris As String = String.Empty
        Dim t As Type = M.DeclaringType
        ris = t.Name & "." & M.Name.Substring(4)
        Return ris
    End Function

    Public Class PreventiviMail
        Public Shared ReadOnly Property ServerPOP As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property Email As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property EmailSender As String
            Get
                Dim ris As String = Email.Replace(".com", ".it")
                'ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property Password As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

    End Class

    Public Class OrdiniMail
        Public Shared ReadOnly Property ServerPOP As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property Email As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property EmailSender As String
            Get
                Return Email
            End Get
        End Property

        Public Shared ReadOnly Property Password As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

    End Class

    Public Class Debug

        Public Shared ReadOnly Property BetaVersion As Boolean
            Get
                Dim ris As Boolean = False
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property CheckBanIp As Boolean
            Get
                Dim ris As Boolean = False
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property DebugAttivo As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property DisabilitaLog As Boolean
            Get
                Dim ris As Boolean = False
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property TracciamentoAttivo As Boolean
            Get
                Dim ris As Boolean = False
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property AbilitaCaching As Boolean
            Get
                Dim ris As Boolean = False
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property IntervalloCaching As Integer
            Get
                Dim ris As Integer = 60
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

    End Class

    Public Class Altro
        Public Shared ReadOnly Property GiorniFerie As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property WithUIFileOperation As Boolean
            Get
                Dim ris As Boolean = False
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property CaricamentiAutomatici As Boolean
            Get
                Dim ris As Boolean = True
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

    End Class

    Public Class Refine
        Public Shared ReadOnly Property Server As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property
    End Class

    Public Class BancaSella
        Public Shared ReadOnly Property ShopLogin As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property EntryPoint As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

    End Class

    Public Class Environment
        Public Shared ReadOnly Property DaemonServer As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property
        Public Shared ReadOnly Property TelerikTheme As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                If ris = String.Empty Then ris = "VisualStudio2012Light"
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property EnableMobile As Boolean
            Get
                Dim ris As Boolean = False
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

    End Class

    Public Class Printer

        Public Shared ReadOnly Property IsPrinterDaemon As Boolean
            Get
                Dim ris As Boolean = False
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property PDF As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property OperatoreComanda As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property MargineXEtichette As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property MargineYEtichette As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property MargineXFatture As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property MargineYFatture As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        'Public Shared ReadOnly Property FattureOperatore As String
        '    Get
        '        Dim ris As String = String.Empty
        '        ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
        '        Return ris
        '    End Get
        'End Property

        'Public Shared ReadOnly Property LiberaOperatore As String
        '    Get
        '        Dim ris As String = String.Empty
        '        ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
        '        Return ris
        '    End Get
        'End Property

        Public Shared ReadOnly Property InfoLavori As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        'FINE TODO

        Public Shared ReadOnly Property Etichette As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property EtichetteGLS As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property FattureSrl As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property FattureSnc As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property PortaUdp As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property ConsegnaOrdini As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property Libera As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property BarcodeFatture As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

    End Class

    Public Class Gls

        Public Shared ReadOnly Property Sede As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property CodiceCliente As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property Password As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property CodiceContratto As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

    End Class

    Public Class Ftp
        Public Shared ReadOnly Property ServerNameProduzione As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property ServerLoginProduzione As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property ServerPwdProduzione As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris

            End Get
        End Property

        Public Shared ReadOnly Property ServerNameSviluppo As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris

            End Get
        End Property

        Public Shared ReadOnly Property ServerLoginSviluppo As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris

            End Get
        End Property

        Public Shared ReadOnly Property ServerPwdSviluppo As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Public Shared ReadOnly Property PassiveMode As Boolean
            Get
                Dim ris As Boolean = False
                Try
                    ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Catch ex As Exception

                End Try
                Return ris
            End Get
        End Property

    End Class

    Friend Class Path

        Friend Shared ReadOnly Property Preps8 As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property Log As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property FattureFE As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property HotFolderCreazioneAnteprimaPDFfromJOB As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property LogCoupon As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property RefineStart As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property RefineSuccess As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property RefineError As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property RefineCancelled As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property RefineWarning As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property RefineResult As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property TemplateGanging As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property Temp As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property FileDigitale As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property CTP As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property JOB As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property LogWeb As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property FileBianco As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property NewVer As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property HCC As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property SorgentiHCC As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property SorgentiHCC35x50 As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property FileListino As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property SorgentiRiOrdinoRisorse As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property FattureAcquisto As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property FileRifiutati As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property Fatture As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property BannerSito As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property Template As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property BkpFile As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

        Friend Shared ReadOnly Property Commesse As String
            Get
                Dim ris As String = String.Empty
                ris = GetValue(GetKey(MethodInfo.GetCurrentMethod()))
                Return ris
            End Get
        End Property

    End Class

End Class
