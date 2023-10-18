Imports System.Configuration
Imports System.IO
Imports System.Threading

Namespace My

    ' I seguenti eventi sono disponibili per MyApplication:
    ' 
    ' Startup: generato all'avvio dell'applicazione, prima della creazione del form di avvio.
    ' Shutdown: generato dopo la chiusura di tutti i form dell'applicazione. L'evento non è generato se l'applicazione termina in modo anormale.
    ' UnhandledException: generato se l'applicazione rileva un'eccezione non gestita.
    ' StartupNextInstance: generato quando si avvia un'applicazione istanza singola e l'applicazione è già attiva. 
    ' NetworkAvailabilityChanged: generato quando la connessione di rete è connessa o disconnessa.
    Partial Friend Class MyApplication

        Private Const FileConfigLocale As String = "\former.exe.config.local"

        'QUESTA FUNZIONE E' REPLICATA PER NON METTERE IL LOCK SUL FILE DI CONFIG 
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

        Private Function IsBetaVersion() As Boolean

            Dim ris As Boolean = False
            Try
                ris = GetValue("Debug.BetaVersion")
            Catch ex As Exception

            End Try


            Return ris

        End Function

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup

            'qui viene lanciato, prendo il path di tutto quello che trovo e lo sovrascrivo nella directory locale tranne l'exe di me stesso 
            Dim DirectoryLocale As String = My.Application.Info.DirectoryPath
            Dim PathDistribuzione As String = "z:\FormerEsercizio\bin\former"
            Dim PathExeRemoto As String = PathDistribuzione & "\former.exe"
            Dim PathExeLocale As String = DirectoryLocale & "\former.exe"

            'If IsBetaVersion() = True Then
            '    PathExeRemoto = PathExeRemoto.Replace("former.exe", "former.beta.exe")
            '    PathExeLocale = PathExeLocale.Replace("former.exe", "former.beta.exe")
            'End If

            Try

                Dim FRemoto As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathExeRemoto)
                Dim FLocale As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathExeLocale)

                If FLocale.FileVersion <> FRemoto.FileVersion Then

                    Dim OkAggiorna As Boolean = False

                    If IsBetaVersion() = False Then
                        If FRemoto.FileVersion.StartsWith("99.") = False Then
                            OkAggiorna = True
                        End If
                    Else
                        'qui e' una versione beta devo capire se aggiornare o no 
                        If FRemoto.FileVersion.StartsWith("99.") Then
                            OkAggiorna = True
                        Else
                            'qui devo capire se la versione che non e' beta e' piu recente della beta

                            Dim ValoriVDisp() As String = FRemoto.FileVersion.Split(".")
                            Dim ValoriVAtt() As String = FLocale.FileVersion.Split(".")
                            'salto il primo valore che e' sempre maggiore essendo questa la beta

                            If CInt(ValoriVDisp(1)) > CInt(ValoriVAtt(1)) Then '2018
                                OkAggiorna = True
                            ElseIf CInt(ValoriVDisp(1)) = CInt(ValoriVAtt(1)) Then '11
                                If CInt(ValoriVDisp(2)) > CInt(ValoriVAtt(2)) Then
                                    OkAggiorna = True
                                ElseIf CInt(ValoriVDisp(2)) = CInt(ValoriVAtt(2)) Then '2
                                    If CInt(ValoriVDisp(3)) > CInt(ValoriVAtt(3)) Then
                                        OkAggiorna = True
                                    End If
                                End If
                            End If
                        End If
                    End If

                    'If FRemoto.FileVersion.StartsWith("99.") Then
                    '    'versione beta
                    '    If IsBetaVersion() = False Then
                    '        'qui non devo aggiornare
                    '        OkAggiorna = False
                    '    End If
                    'Else
                    '    'versione normale
                    '    If IsBetaVersion() = True Then
                    '        'qui non devo aggiornare
                    '        OkAggiorna = False
                    '    End If
                    'End If

                    If OkAggiorna Then
                        'aspetto un attimo 
                        Thread.Sleep(2000)

                        Dim d As New DirectoryInfo(PathDistribuzione)

                        For Each f As FileInfo In d.GetFiles()

                            If f.Name.ToLower <> "formerliveupdate.exe" Then

                                'qui lo copio
                                File.Copy(f.FullName, DirectoryLocale & "\" & f.Name, True)

                            End If

                        Next
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show("Si è verificato un errore nell'aggiornamento del Gestionale Former: " & ex.Message)

            End Try

            Threading.Thread.Sleep(1000)

            'Dim PathExeFormer = DirectoryLocale & "\former.exe"

            Try
                'FormerLib.FormerHelper.File.ShellExtended(PathExeFormer)

                Dim proc As New ProcessStartInfo
                proc.FileName = PathExeLocale
                proc.WorkingDirectory = Environment.CurrentDirectory
                Process.Start(proc)

            Catch ex As Exception
                MessageBox.Show("Non sono riuscito a rilanciare il Gestionale Former: " & ex.Message)

            End Try

            End


        End Sub
    End Class


End Namespace

