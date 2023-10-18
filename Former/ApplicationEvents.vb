Imports Microsoft.Win32
Imports System.Security.Principal
Imports FormerConfig
Imports Microsoft.VisualBasic.ApplicationServices
Imports Telerik.WinControls
Imports System.IO
Imports FormerBusinessLogic

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown

            'qui l'app viene chiusa 
            'se una variabile globale dice di fare l'update lo faccio 

            If UpdateAppAtShutdown Then
                Try
                    Dim path As String = My.Application.Info.DirectoryPath & "\formerliveupdate.exe"
                    Dim proc As New ProcessStartInfo
                    proc.FileName = path
                    proc.WorkingDirectory = Environment.CurrentDirectory
                    Process.Start(proc)
                Catch ex As Exception

                End Try
            End If

        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup

            AppDomain.MonitoringIsEnabled = True

            Dim identity = WindowsIdentity.GetCurrent()
            Dim principal = New WindowsPrincipal(identity)
            Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)

            ServerCollaudo = New ServerSito("Collaudo")
            ServerTwin = New ServerSito("Twin")
            ServerProduzione = New ServerSito("Produzione")

            ServerCollaudo.SQLConnectionString = "Server=former-server\sqlexpress,1433;Database=FormerWeb;User Id=sa;Password=tgHi9MaEQA;" 'former-server
            ServerCollaudo.FTPLogin = FConfiguration.Ftp.ServerLoginSviluppo
            ServerCollaudo.FTPPwd = FConfiguration.Ftp.ServerPwdSviluppo
            ServerCollaudo.FTPHost = FConfiguration.Ftp.ServerNameSviluppo

            ServerTwin.SQLConnectionString = "Server=former-server\sqlexpress,1433;Database=FormerWebTwin;User Id=sa;Password=tgHi9MaEQA;" 'former-server
            ServerTwin.FTPLogin = FConfiguration.Ftp.ServerLoginSviluppo
            ServerTwin.FTPPwd = FConfiguration.Ftp.ServerPwdSviluppo
            ServerTwin.FTPHost = FConfiguration.Ftp.ServerNameSviluppo

            ServerProduzione.SQLConnectionString = "Server=188.213.172.73\sqlexpress,1433;Database=FormerWeb;User Id=sa;Password=tgHi9MaEQA;" '188.213.172.73
            ServerProduzione.FTPLogin = FConfiguration.Ftp.ServerLoginProduzione
            ServerProduzione.FTPPwd = FConfiguration.Ftp.ServerPwdProduzione
            ServerProduzione.FTPHost = FConfiguration.Ftp.ServerNameProduzione

            ThemeResolutionService.ApplicationThemeName = FormerConfig.FConfiguration.Environment.TelerikTheme

            'qui e' la prima istanza
            'se non c'e' mi aggiungo nel registry come risponditore al protocollo former:
            Dim Chiave As String = "former"
            Dim regVal As RegistryKey = Registry.ClassesRoot.OpenSubKey(Chiave)

            If regVal Is Nothing Then
                'qui va creato tutto 
                'mi rilancio come amministratore
                Dim PathExe As String = System.Windows.Forms.Application.ExecutablePath

                If isElevated = False Then
                    Dim proc As New ProcessStartInfo
                    proc.UseShellExecute = True
                    proc.WorkingDirectory = Environment.CurrentDirectory
                    proc.FileName = PathExe
                    proc.Verb = "runas"
                    Process.Start(proc)

                    End
                Else
                    regVal = Registry.ClassesRoot.CreateSubKey(Chiave)
                    regVal.SetValue("URL Protocol", "")
                    regVal.CreateSubKey("DefaultIcon")
                    Dim regShell As RegistryKey = regVal.CreateSubKey("shell")
                    regShell.SetValue("", "open")
                    Dim regOpen As RegistryKey = regShell.CreateSubKey("open")
                    Dim regCommand As RegistryKey = regOpen.CreateSubKey("Command")

                    regCommand.SetValue("", """" & PathExe & """" & " ""%1""")

                    regVal.Close()

                End If

            End If

            Try
                'AGGIORNO L'UPDATER SE POSSIBILE
                Dim pathUpdater As String = "z:\FormerEsercizio\bin\former\formerliveupdate.exe"
                Dim DirectoryLocale As String = My.Application.Info.DirectoryPath
                DirectoryLocale &= "\formerliveupdate.exe"

                File.Copy(pathUpdater, DirectoryLocale, True)

            Catch ex As Exception

            End Try

        End Sub

        Private Sub MyApplication_StartupNextInstance(sender As Object, e As ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

            'qui becco i parametri chiamati dal sito per i link di upload file 

            Dim currentProcess As Process = Process.GetCurrentProcess()

            If currentProcess.Id <> 0 Then AppActivate(currentProcess.Id)

            Try
                If e.CommandLine.Count Then
                    Dim Parametro As String = e.CommandLine(0)
                    Dim fr As New frmOrdineAllegaFileOnline

                    Dim IdOrdine As Integer = Parametro.Substring(Parametro.IndexOf(":") + 1)

                    FormPrincipale.Sottofondo()

                    frmOrdineAllegaFileOnline.Carica(IdOrdine)

                    frmOrdineAllegaFileOnline.Close()
                    frmOrdineAllegaFileOnline.Dispose()
                    frmOrdineAllegaFileOnline = Nothing

                    FormPrincipale.Sottofondo()
                End If
            Catch ex As Exception

                'ManageError(ex, "PROTOCOLLO FORMER ALLEGA FILE")

            End Try

        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            ManageError(e.Exception,, True)
        End Sub
    End Class

End Namespace

