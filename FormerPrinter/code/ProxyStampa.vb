Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerConfig
Imports FormerLib
Imports System.Windows.Forms

Public Class ProxyStampa

    Public Shared ReadOnly Property StampanteLibera As String
        Get
            Return FConfiguration.Printer.Libera
        End Get
    End Property

    Public Shared ReadOnly Property StampanteFattureSrl As String
        Get
            Return FConfiguration.Printer.FattureSrl
        End Get
    End Property

    Public Shared ReadOnly Property StampanteFattureSnc As String
        Get
            Return FConfiguration.Printer.FattureSnc
        End Get
    End Property

    Public Shared ReadOnly Property StampantePDF As String
        Get
            Dim ris As String = "PDFCreator"

            If FConfiguration.Printer.PDF.Length Then
                ris = FConfiguration.Printer.PDF
            End If

            Return ris
        End Get
    End Property

    'Public Shared Property PathFatture As String = String.Empty

    Private Shared ReadOnly Property StampanteBarcodeFatture As String
        Get
            Return FConfiguration.Printer.BarcodeFatture ' ConfigurationManager.AppSettings("Printer-StampanteBarcodeFatture")
        End Get
    End Property

    Public Shared Function OkDemoneDiStampa() As Boolean

        'DISATTIVATO PER NON DARE ALERT DI STAMPA 

        Dim ris As Boolean = False

        ris = True

        Return ris

        'qui tanto lo pingo poi vediamo
        If FormerEnvironment.ISServiceUp Then
            ris = True
        Else
            Dim Esci As Boolean = False

            While Esci = False
                Dim Risposta As DialogResult = MessageBox.Show("Il server di stampa " & FConfiguration.Environment.DaemonServer.ToUpper & " non sembra raggiungibile. Cosa vuoi fare?", "Errore di stampa", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question)

                If Risposta = DialogResult.Abort Then
                    Esci = True
                ElseIf Risposta = DialogResult.Retry Then
                    Cursor.Current = Cursors.WaitCursor
                    Threading.Thread.Sleep(3000)
                    Cursor.Current = Cursors.Default
                ElseIf Risposta = DialogResult.Ignore Then
                    ris = True
                    Esci = True
                End If

            End While

        End If

        Return ris
    End Function

    Public Shared Sub StampaDocumentoFiscale(ByRef R As Ricavo,
                                             ChiediStampanteLibera As Boolean,
                                             NumCopieDocFiscale As Integer,
                                             IdUt As Integer)

        'PER ORA LASCIO QUESTO CHE PRIMA ERA UN PARAMENTRO PER POTER IN CASO TORNARE INDIETRO 
        'SEMPRE IMPOSTATO A TRUE PERCHE OGNI POSTAZIONE STAMPA PER SE

        Dim PostazioneConStampanteFisica As Boolean = False

        Dim Prn As New myFPrinter

        If R.Tipo = enTipoDocumento.Preventivo Then

            'If StampanteLibera.Length = 0 Then
            '    StampanteLibera = FormerConfig.FConfiguration.Printer.Libera
            'End If

            Prn.PrinterName = StampanteLibera
            If ChiediStampanteLibera Then
                Dim prin As New System.Windows.Forms.PrintDialog
                prin.ShowDialog()
                If prin.PrinterSettings.PrinterName.Length Then Prn.PrinterName = prin.PrinterSettings.PrinterName
            End If
            Prn.StampaDocumento(R)
            R.AumentaCounterStampe()
        Else

            If R.UsareStampanteSNC Then
                Prn.PrinterName = StampanteFattureSnc
            Else
                Prn.PrinterName = StampanteFattureSrl
            End If

            If FConfiguration.Printer.IsPrinterDaemon Then
                PostazioneConStampanteFisica = True
            Else
                If FormerHelper.Printer.IsInstalled(Prn.PrinterName) Then
                    PostazioneConStampanteFisica = True
                End If
            End If

            If PostazioneConStampanteFisica = False Then
                Dim TestoMsg As String = R.IdRicavo & "-" & NumCopieDocFiscale & "$" & IdUt
                'If UsaStampanteOperatore Then
                '    FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_PrinterOperatore, TestoMsg)
                'Else
                If OkDemoneDiStampa() Then FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Printer, TestoMsg)
                'End If

            Else

                'If StampanteFatture.Length = 0 Then StampanteFatture = "PDFCreator"
                'Prn.PrinterName = StampanteFatture
                If NumCopieDocFiscale Then
                    Prn.NumCopieDocFiscale = NumCopieDocFiscale
                Else
                    Prn.NumCopieDocFiscale = FormerLib.FormerConst.Fiscali.NumCopieDocFiscali
                End If

                Prn.StampaDocumento(R)
                R.AumentaCounterStampe()

                'DISATTIVATO PER NON STAMPARE IN AUTOMATICO IL DOCUMENTO FATTURA PDF
                'If R.Tipo = enTipoDocumento.Fattura Or R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                '    StampaDocumentoFiscalePDF(R, FConfiguration.Printer.IsPrinterDaemon)
                'End If

            End If
        End If
        'RicavoCompatibilita = Nothing
        Prn = Nothing

    End Sub

    Public Shared Sub StampaComandaOperatore(M As Messaggio)
        Dim prnPDF As New myFPrinter
        If FormerDebug.DebugAttivo Then
            prnPDF.PrinterName = StampantePDF
        Else
            prnPDF.PrinterName = FormerConfig.FConfiguration.Printer.OperatoreComanda
        End If
        prnPDF.StampaComandaOperatore(M)
        prnPDF = Nothing
    End Sub

    Public Shared Sub StampaDocumentoFiscalePDF(R As Ricavo,
                                                Optional PostazioneConStampanteFisica As Boolean = False)

        If PostazioneConStampanteFisica = False Then

            'TODO:qui devo controllare se il demone e' attivo

            If OkDemoneDiStampa() Then FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_PrinterPDF, R.IdRicavo)

        Else
            Dim prnPDF As New myFPrinter
            prnPDF.PrinterName = StampantePDF
            prnPDF.StampaDocumento(R, True)
            prnPDF = Nothing
        End If

    End Sub

End Class
