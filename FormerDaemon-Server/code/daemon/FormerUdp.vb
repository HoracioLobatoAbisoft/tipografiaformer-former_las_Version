Imports FormerDALSql
Imports System.Configuration
Imports FormerLib
Imports FormerConfig
Imports FormerLib.FormerEnum

Friend Class FormerUDP
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

    Public Shared ReadOnly Property PortaUdp As Integer
        Get
            Return FConfiguration.Printer.PortaUdp ' ConfigurationManager.AppSettings("Printer-PortaUdp")
        End Get
    End Property

    Private Shared ReadOnly Property StampanteFattureSrl As String
        Get
            Return FConfiguration.Printer.FattureSrl ' ConfigurationManager.AppSettings("Printer-StampanteFatture")
        End Get
    End Property

    Private Shared ReadOnly Property StampanteFattureSnc As String
        Get
            Return FConfiguration.Printer.FattureSnc ' ConfigurationManager.AppSettings("Printer-StampanteFatture")
        End Get
    End Property


    'Private Shared ReadOnly Property StampanteFattureOperatore As String
    '    Get
    '        Return FConfiguration.Printer.FattureOperatore '  ConfigurationManager.AppSettings("Printer-StampanteFattureOperatore")
    '    End Get
    'End Property

    Private Shared ReadOnly Property StampantePDF As String
        Get
            Return FConfiguration.Printer.PDF ' ConfigurationManager.AppSettings("Printer-StampantePDF")
        End Get
    End Property

    Public Shared udp As System.Net.Sockets.UdpClient = Nothing

    Private Shared Sub Listen()
        Dim Esci As Boolean = False
        Dim Counter As Integer = 0

        Do
            Counter += 1
            If Counter <= 10 Then
                Dim MessaggioRicevuto As String = String.Empty
                Try
                    udp = New Net.Sockets.UdpClient(PortaUdp)
                    udp.EnableBroadcast = True
                    Dim ep As New Net.IPEndPoint(Net.IPAddress.Broadcast, PortaUdp)
                    Esci = True
                    Do
                        Dim b() As Byte = udp.Receive(ep)
                        MessaggioRicevuto = System.Text.Encoding.UTF32.GetString(b)
                        AddText(MessaggioRicevuto)
                    Loop

                Catch ex As Exception
                    If udp IsNot Nothing Then udp.Close()
                    LogMe("Tentativo " & Counter & " - Errore: " & ex.Message & " Messaggio ricevuto: " & MessaggioRicevuto)
                    Esci = False
                    'LogMe("Server di stampa terminato!")
                    'Threading.Thread.Sleep(5000)
                End Try
            Else
                Esci = True
                LogMe("Non sono riuscito ad avviare il servizio con 10 tentativi")
                LogMe("Server UDP terminato!")
            End If

        Loop Until (Counter = 10 Or Esci = True)

    End Sub

    Public Shared Sub StartService()

        'FormerPrinter.ProxyStampa.StampanteFatture = StampanteFatture
        'FormerPrinter.ProxyStampa.StampantePDF = StampantePDF

        'FormerPrinter.ProxyStampa.PathFatture = PathFatture

        LogMe("Servizio AVVIATO!")
        LogMe("*********************************************", True)
        LogMe("PORTA UDP:" & PortaUdp)
        'LogMe("STAMPANTE FATTURE:" & StampanteFatture)
        'LogMe("STAMPANTE FATTURE OPERATORE:" & StampanteFattureOperatore)
        LogMe("*********************************************", True)

        Dim Counter As Integer = 0
        Dim Esci As Boolean = False

        Do
            Counter += 1
            Try

                Dim t As New Threading.Thread(AddressOf Listen)
                t.IsBackground = True
                t.Start()

                Stato = enStatoServizio.Attivo

                Esci = True

            Catch ex As Exception
                LogMe("ERRORE PrinterService: Tentativo " & Counter & " - " & ex.Message, , ex)
            End Try

        Loop Until Counter = 10 Or Esci = True

    End Sub

    Public Shared Sub StopService()
        Try
            If udp IsNot Nothing Then udp.Close()
            udp = Nothing
        Catch ex As Exception
            LogMe("Errore: " & ex.Message)
        Finally
            Stato = enStatoServizio.NonAttivo
        End Try
    End Sub

    Private Shared Sub AddText(ByVal text As String)
        Dim M As New MessaggioDiReteInterno(text)

        If M.Valido Then

            Select Case M.TipoMess

                Case FormerLib.FormerUDP.TipoUDP_Printer ', FormerUDP.TipoUDP_PrinterOperatore

                    Dim IdR As Integer = 0 ' M.Testo
                    Dim IdUt As Integer = 0
                    Dim NumCopie As Integer = 0
                    'in M.testo mi arrivao 20-1
                    'documento id 20 1 copia
                    Dim PosTrattino As Integer = M.Testo.IndexOf("-")
                    If PosTrattino Then
                        IdR = M.Testo.Substring(0, PosTrattino)

                        Dim PosDollaro As Integer = M.Testo.IndexOf("$")

                        If PosDollaro <> -1 Then
                            NumCopie = M.Testo.Substring(PosTrattino + 1, PosDollaro - PosTrattino - 1)
                            IdUt = M.Testo.Substring(PosDollaro + 1)
                        Else
                            'vecchia versione
                            NumCopie = M.Testo.Substring(PosTrattino + 1)
                        End If
                    Else
                        IdR = M.Testo
                    End If

                    Using mgr As New RicaviDAO
                        Using R As Ricavo = mgr.Find(New LUNA.LunaSearchParameter(LFM.Ricavo.IdRicavo, IdR))
                            If R.IdRicavo Then
                                'FormerPrinter.ProxyStampa.StampanteFatture = StampanteFatture

                                Using u As New Utente
                                    u.Read(IdUt)
                                    LogMe("Stampa DOCUMENTO FISCALE " & IdR & " da Utente: " & u.Login)
                                End Using
                                FormerPrinter.ProxyStampa.StampaDocumentoFiscale(R, False, NumCopie, IdUt)
                                'LogMe("Stampa DOCUMENTO FISCALE TERMINATA")
                            Else
                                LogMe("Errore nella lettura del DOCUMENTO FISCALE " & IdR)
                            End If
                        End Using
                    End Using
                Case FormerLib.FormerUDP.TipoUDP_PrinterPDF
                    Dim IdR As Integer = M.Testo
                    Using mgr As New RicaviDAO
                        Dim R As Ricavo = mgr.Find(New LUNA.LunaSearchParameter(LFM.Ricavo.IdRicavo, IdR))
                        If Not R Is Nothing AndAlso R.IdRicavo Then
                            LogMe("Stampa DOCUMENTO FISCALE PDF " & IdR)
                            FormerPrinter.ProxyStampa.StampaDocumentoFiscalePDF(R, True)
                            'LogMe("Stampa DOCUMENTO FISCALE TERMINATA")
                        Else
                            LogMe("Errore nella lettura del DOCUMENTO FISCALE " & IdR)
                        End If
                        R = Nothing
                    End Using
                Case FormerLib.FormerUDP.TipoUDP_PrinterComanda
                    Dim IdM As Integer = M.Testo
                    Using mgr As New MessaggiDAO
                        Using P As Messaggio = mgr.Find(New LUNA.LunaSearchParameter(LFM.Messaggio.IdPostit, IdM))
                            If Not P Is Nothing AndAlso P.IdPostit Then
                                LogMe("Stampa COMANDA OPERATORE " & IdM)
                                FormerPrinter.ProxyStampa.StampaComandaOperatore(P)
                            End If
                        End Using
                    End Using
                Case FormerLib.FormerUDP.TipoUDP_RefineAutomatico
                    LogMe("Richiesta Elaborazione ordini REFINE AUTOMATICO")
                    FormerSyncronizer.RefineAutomatico.StartService()

                Case FormerLib.FormerUDP.TipoUDP_ForzaScaricamentoOrdini
                    LogMe("Richiesto SCARICAMENTO FORZATO ORDINI")
                    If FormerSyncronizer.NewOrder.ScaricamentoInCorso = False Then
                        FormerSyncronizer.NewOrder.StartService()
                    Else
                        LogMe("Richiesta ABORTITA, SCARICAMENTO già in CORSO")
                    End If


                Case FormerLib.FormerUDP.TipoUDP_CreaAnteprimaCommessa
                    LogMe("Richiesta CREAZIONE ANTEPRIMA Commessa " & M.Testo)

                    Dim Valori As String() = M.Testo.Split("§")

                    Dim IdC As Integer = Valori(0) 'M.Testo 'qui arriva l'id della commessa di cui generare l'anteprima
                    Dim ForzaMandaAlFlusso As Boolean = Valori(1)
                    MgrCommesse.CreaAnteprima(IdC, M.Mittente, ForzaMandaAlFlusso)

                Case FormerLib.FormerUDP.TipoUDP_MandaAlFlussoCommessa
                    LogMe("Richiesto MANDA AL FLUSSO Commessa " & M.Testo)
                    Dim IdC As Integer = M.Testo 'qui arriva l'id della commessa di cui generare l'anteprima
                    MgrCommesse.MandaAlFlusso(IdC, M.Mittente)

                Case FormerLib.FormerUDP.TipoUDP_RigeneraAnteprimaModello
                    LogMe("Richiesto Rigenera Anteprima Modello " & M.Testo)
                    'nel messaggio ho id modello e F o R per fronte o retro
                    Dim IdM As Integer = M.Testo.Substring(0, M.Testo.Length - 1)
                    Dim TipoRetro As enFronteRetro = M.Testo.Substring(M.Testo.Length - 1)

                    MgrModelliCommessa.RigeneraAnteprima(IdM, TipoRetro)

                Case FormerLib.FormerUDP.TipoUDP_RigeneraAnteprimaOrdine
                    LogMe("Richiesto Rigenera Anteprima Ordine " & M.Testo)
                    Dim IdO As Integer = M.Testo 'qui arriva l'id della commessa di cui generare l'anteprima
                    MgrOrdini.RigeneraAnteprima(IdO)

            End Select

        End If
    End Sub

End Class
