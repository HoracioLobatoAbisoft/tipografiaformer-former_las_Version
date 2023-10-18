Imports FormerDALSql
Imports System.Configuration
Imports FormerLib
Imports System.IO.Ports

Friend Class FormerCaller
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
             Optional Errore As Exception = Nothing,
             Optional TagLabel As String = "")
        _LogMe(_txtLog, _lblLastOp, Testo, _ModuleName, _ModuleSigla, DontStore, Errore, TagLabel)
    End Sub

#End Region

    Private Shared WithEvents ComPort As SerialPort

    Public Shared ReadOnly Property PortaCom As String
        Get
            Return ConfigurationManager.AppSettings("Caller-PortaCom")
        End Get
    End Property

    Public Shared ReadOnly Property PortaUdp As String
        Get
            Return ConfigurationManager.AppSettings("Caller-PortaUdp")
        End Get
    End Property

    Public Shared ReadOnly Property PortaComInit As String
        Get
            Return ConfigurationManager.AppSettings("Caller-PortaComInit")
        End Get
    End Property

    Public Shared Sub StartService()

        Stato = enStatoServizio.Attivo

        If ComPort Is Nothing OrElse ComPort.IsOpen = False Then

            Dim Counter As Integer = 0
            Dim Esci As Boolean = False

            Do
                Counter += 1
                Try

                    Dim tr As New Threading.Thread(AddressOf listen)
                    tr.IsBackground = True
                    tr.Start()

                    LogMe("Rilevamento Attivato")
                    Esci = True

                Catch ex As Exception
                    LogMe("ERRORE CALLERID: Tentativo " & Counter & " - " & ex.Message, , ex)
                End Try

            Loop Until Counter = 10 Or Esci = True

        End If

    End Sub

    Private Shared Sub listen()

        If ComPort Is Nothing Then ComPort = New SerialPort

        Dim Esci As Boolean = False

        With ComPort
            .PortName = PortaCom
            .BaudRate = 4800
            .Parity = Parity.None
            .DataBits = 8
            .StopBits = StopBits.One
        End With

        ComPort.Open()
        ComPort.Write(PortaComInit & vbCr)

    End Sub

    Private Shared Sub ComPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles ComPort.DataReceived

        Dim BufferLetto As String = ComPort.ReadExisting

        If BufferLetto.Length Then
            'qui devo vedere se c'e' qualcosa 
            'se trovo un numero di telefono chiamo la formcallerid
            Dim Posiz As Integer = BufferLetto.ToUpper.IndexOf("NMBR")
            If Posiz <> -1 Then
                Dim PosizFine As Integer = BufferLetto.ToUpper.IndexOf("NAME", Posiz)
                'qui devo vedere se riesco a capire il chiamante
                Dim NumeroTrovato As String = BufferLetto.Substring(Posiz + 7, PosizFine - (Posiz + 7)).TrimEnd

                If NumeroTrovato = "P" Then NumeroTrovato = "**********" 'NUMERO PRIVATO BECCATO COSI O CON P

                If IsNumeric(NumeroTrovato) Or NumeroTrovato = "**********" Then
                    If NumeroTrovato.Length Then
                        Dim lstNum As String = Now.Hour & ":" & Now.Minute & "." & Now.Second & " - " & NumeroTrovato

                        Dim MessaggioCompleto As String = NumeroTrovato

                        'LogMe("Apertura Connessione DB INTERNO")
                        'Dim ConnDbInterno As IDbConnection = LUNA.LunaContext.GetDbConnection()
                        Dim TagLabel As String = NumeroTrovato
                        Dim msgLog As String = "Chiamata da " & NumeroTrovato

                        If IsNumeric(NumeroTrovato) Then
                            Dim Lst As List(Of VoceRubrica) = Nothing

                            Using mgr As New VociRubricaDAO
                                Lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Tel, NumeroTrovato),
                                                  New LUNA.LunaSearchParameter(LFM.VoceRubrica.Fax, NumeroTrovato, , LUNA.enLogicOperator.enOR),
                                                  New LUNA.LunaSearchParameter(LFM.VoceRubrica.Cellulare, NumeroTrovato, , LUNA.enLogicOperator.enOR),
                                                  New LUNA.LunaSearchParameter(LFM.VoceRubrica.AltroTel, NumeroTrovato, , LUNA.enLogicOperator.enOR))
                            End Using

                            If Lst.Count Then
                                Dim ClienteTrovato As VoceRubrica = Lst(0)
                                MessaggioCompleto &= "§" & ClienteTrovato.IdRub & "§" & ClienteTrovato.RagSocNome
                                msgLog &= " (" & ClienteTrovato.RagSocNome & ")"
                                TagLabel &= ":" & ClienteTrovato.IdRub
                                ClienteTrovato = Nothing
                            Else
                                TagLabel &= ":0"
                            End If
                        End If

                        LogMe(msgLog,,, TagLabel)

                        'ConnDbInterno.Close()
                        'ConnDbInterno = Nothing
                        FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Notifica, msgLog, FormerLib.FormerUDP.DestUDP_Admin)

                        FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_CallerID, MessaggioCompleto)
                    End If
                Else
                    If BufferLetto.Trim <> "OK" And BufferLetto.Trim <> "RING" Then LogMe("Buffer non riconosciuto: " & BufferLetto)
                End If
            Else
                If BufferLetto.Trim <> "OK" And BufferLetto.Trim <> "RING" Then LogMe("Buffer non riconosciuto: " & BufferLetto)
            End If
        End If
    End Sub

    Public Shared Sub StopService()
        Try
            If ComPort.IsOpen Then
                ComPort.Close()
            End If

            If Not ComPort Is Nothing Then
                ComPort.Dispose()
                ComPort = Nothing
            End If

        Catch ex As Exception
            LogMe("Errore: " & ex.Message)
        Finally
            Stato = enStatoServizio.NonAttivo
        End Try
    End Sub

End Class
