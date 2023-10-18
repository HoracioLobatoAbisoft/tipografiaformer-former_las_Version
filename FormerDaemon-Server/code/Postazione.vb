Imports System.Configuration
Imports FormerLib.FormerEnum

Public Class Postazione

    Public Class Network
        Private Shared Property AddressServerVirtuale As String = "188.213.172.73"
        'Private Shared Property GoogleAddressToPing As String = "8.8.8.8"
        Public Shared Property ConnessioneServerInternoDisponibile As Boolean
        Public Shared Function ConnessioneInternetDisponibile() As Integer
            Dim Ris As Integer = 0

            Dim listaIp As New List(Of String)
            listaIp.Add("1.1.1.1")
            listaIp.Add("8.8.8.8")
            listaIp.Add("8.8.4.4")
            listaIp.Add("139.130.4.5")

            For Each ip In listaIp
                Ris = IsPingable(ip)
                If Ris Then Exit For
            Next

            Return Ris
        End Function

        Public Shared Function NetRenew()

            Dim pstart As New ProcessStartInfo
            Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
            Using p As New Process
                pstart.FileName = path + "\cmd.exe"
                pstart.UseShellExecute = False
                pstart.CreateNoWindow = False
                pstart.WorkingDirectory = path
                pstart.FileName = "cmd.exe"
                pstart.Arguments = "/c ipconfig /renew"
                p.StartInfo = pstart
                p.Start()
            End Using

        End Function

        Public Shared Function ConnessioneDbRemotoDisponibile() As Integer
            Dim Ris As Integer = 0

            Ris = IsPingable(AddressServerVirtuale)

            Return Ris
        End Function

        Public Shared Function IsPingable(Address As String, Optional TimeOut As Integer = 1000) As Integer
            Dim ris As Integer = 0
            Try
                If My.Computer.Network.IsAvailable Then
                    Dim Result As Net.NetworkInformation.PingReply
                    Dim SendPing As New Net.NetworkInformation.Ping
                    Result = SendPing.Send(Address)
                    If Result.Status = Net.NetworkInformation.IPStatus.Success Then
                        If Result.RoundtripTime Then
                            ris = Result.RoundtripTime
                        Else
                            ris = 10
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
            Return ris
        End Function
    End Class

    Public Class Configurazione

        Private Shared _AutoStartSyncronizer As Boolean = False
        Public Shared Property AutoStartSyncronizer As Boolean
            Get
                Return ConfigurationManager.AppSettings("AutoStartSyncronizer")
            End Get
            Set(value As Boolean)
                Dim configuration As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                configuration.AppSettings.Settings("AutoStartSyncronizer").Value = IIf(value, "True", "False")
                configuration.Save()
                ConfigurationManager.RefreshSection("appSettings")
            End Set
        End Property

        Private Shared _AutoStartService As Boolean = False
        Public Shared Property AutoStartService As Boolean
            Get
                Return ConfigurationManager.AppSettings("AutoStartService")
            End Get
            Set(value As Boolean)
                Dim configuration As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                configuration.AppSettings.Settings("AutoStartService").Value = IIf(value, "True", "False")
                configuration.Save()
                ConfigurationManager.RefreshSection("appSettings")
            End Set
        End Property

        Private Shared _AutoStartMessenger As Boolean = False
        Public Shared Property AutoStartMessenger As Boolean
            Get
                Return ConfigurationManager.AppSettings("AutoStartMessenger")
            End Get
            Set(value As Boolean)
                Dim configuration As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                configuration.AppSettings.Settings("AutoStartMessenger").Value = IIf(value, "True", "False")
                configuration.Save()
                ConfigurationManager.RefreshSection("appSettings")
            End Set
        End Property

        Private Shared _AutoStartPrinter As Boolean = False
        Public Shared Property AutoStartPrinter As Boolean
            Get
                Return ConfigurationManager.AppSettings("AutoStartPrinter")
            End Get
            Set(value As Boolean)
                Dim configuration As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                configuration.AppSettings.Settings("AutoStartPrinter").Value = IIf(value, "True", "False")
                configuration.Save()
                ConfigurationManager.RefreshSection("appSettings")
            End Set
        End Property

        Private Shared _AutoStartCaller As Boolean = False
        Public Shared Property AutoStartCaller As Boolean
            Get
                Return ConfigurationManager.AppSettings("AutoStartCaller")
            End Get
            Set(value As Boolean)
                Dim configuration As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                configuration.AppSettings.Settings("AutoStartCaller").Value = IIf(value, "True", "False")
                configuration.Save()
                ConfigurationManager.RefreshSection("appSettings")
            End Set
        End Property

    End Class

End Class
