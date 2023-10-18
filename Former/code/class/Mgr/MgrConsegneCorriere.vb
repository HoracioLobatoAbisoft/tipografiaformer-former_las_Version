Imports FormerConfig
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerWebLabeling

Public Class MgrConsegneCorriere

    Public Class GLS

        Public Shared Sub EliminaRegistrazioneConsegna(C As ConsegnaProgrammata)
            Dim ris As String = String.Empty
            If C.IdStatoConsegna = enStatoConsegna.RegistrataCorriere OrElse C.CodTrack <> String.Empty Then

                Dim CodTrack As String = C.CodTrack
                If C.IdCorr = enCorriere.GLS Or C.IdCorr = enCorriere.GLSIsole Or C.IdCorr = enCorriere.PortoAssegnatoGLS Then
                    Try
                        ris = MgrWebLabelingGls.EliminaSpedizione(C.CodTrack) & vbCrLf & "Ricorda di togliere le etichette di GLS vecchie dai pacchi," &
                                            " di reimmettere la spedizione su GLS e di rietichettare i pacchi prima che venga fatta l'uscita da magazzino!"
                    Catch ex As Exception
                        ris = "C'è stato un problema con il Web Service di GLS durante l'eliminazione: " & ex.Message & vbCrLf & " Il codice di tracking della consegna" &
                            " è stato comunque azzerato e lo stato della consegna è stato riportato a ""In Lavorazione"""
                        FormerHelper.Mail.InviaMail("Errore durante l'eliminazione della spedizione su GLS", "Errore durante l'eliminazione della registrazione su GLS della consegna" &
                                                     " numero " & C.IdCons & " con codice tracking " & C.CodTrack & "!", "web@tipografiaformer.it", , , , , "soft@tipografiaformer.it")
                    End Try
                Else
                    ris = "Eliminazione spedizione Bartolini effettuata. Ricorda di togliere le vecchie etichette dai pacchi, di reimmettere la spedizione su Easy Sped e di" &
                        " rietichettare i pacchi prima che venga fatta l'uscita da magazzino!"
                End If

                ris &= ControlChars.NewLine & "Tutti gli ordini che avevano passato la fase di imballaggio sono stati riportati a IMBALLAGGIO"

                C.CodTrack = String.Empty
                C.NumeroPrimoColloBartolini = String.Empty
                C.DataTrasmissioneCorriere = Date.MinValue
                C.Save()

                Using mgr As New ConsegneProgrammateDAO()
                    mgr.AvanzaStatoConsegna(C, enStatoConsegna.InLavorazione)
                End Using

                For Each O As Ordine In C.ListaOrdini
                    If O.Stato > enStatoOrdine.Imballaggio Then
                        Using mgr As New OrdiniDAO
                            mgr.InserisciLog(O.IdOrd,
                                             enStatoOrdine.Imballaggio,
                                             PostazioneCorrente.UtenteConnesso.IdUt)
                        End Using
                    End If
                Next

                MessageBox.Show(ris)
                ris = String.Empty

                If CodTrack.Length Then
                    Using mgr As New ConsegneProgrammateDAO
                        Dim lstConsegne As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, CodTrack))
                        For Each Consegna As ConsegnaProgrammata In lstConsegne
                            Consegna.CodTrack = String.Empty
                            Consegna.Save()
                            Using mgr2 As New ConsegneProgrammateDAO()
                                mgr2.AvanzaStatoConsegna(Consegna, enStatoConsegna.InLavorazione)
                            End Using

                            For Each O As Ordine In Consegna.ListaOrdini
                                If O.Stato > enStatoOrdine.Imballaggio Then
                                    Using mgrO As New OrdiniDAO
                                        mgrO.InserisciLog(O.IdOrd,
                                                        enStatoOrdine.Imballaggio,
                                                        PostazioneCorrente.UtenteConnesso.IdUt)
                                    End Using
                                End If
                            Next

                            ris &= "Eliminata registrazione anche dalla consegna numero " & Consegna.IdCons & " con stesso Codice Tracking associato, e resettato lo stato ordini!" & ControlChars.NewLine
                        Next
                        If ris.Length Then MessageBox.Show(ris)
                    End Using
                End If

            Else
                MessageBox.Show("La spedizione non è in stato REGISTRATA CON CORRIERE e non ha codice di tracking quindi non può essere annullata la registrazione!")
            End If
        End Sub

        Public Shared Sub PrenotaSpedizioneGls(ByRef c As ConsegnaProgrammata)

            If c.SpedibileConGls = True Then
                Dim IdCons As Integer = c.IdCons
                'Dim lstPdfStreams As New List(Of System.IO.MemoryStream)
                Dim lstZpl As String = String.Empty
                Dim CodTrack As String = String.Empty
                Dim Ok As Boolean = True
                For i = 1 To c.NumColli
                    If Ok Then
                        Try
                            Dim ContatoreProgressivo As Integer = i
                            Dim SegnaCollo As SegnaCollo = MgrWebLabelingGls.GetSegnaCollo(c, ContatoreProgressivo)
                            'lstPdfStreams.Add(SegnaCollo.PdfLabel)
                            lstZpl &= SegnaCollo.Zpl & vbCrLf
                            CodTrack = SegnaCollo.NumeroSpedizione
                        Catch ex As Exception
                            Ok = False
                            'MessageBox.Show(ex.Message)
                            Throw ex
                        End Try
                    End If
                Next

                If Ok Then
                    c.CodTrack = CodTrack
                    'c.Blocco = enSiNo.Si
                    c.DataTrasmissioneCorriere = Now.Date()
                    c.Save()
                    Using mgr As New ConsegneProgrammateDAO()
                        mgr.AvanzaStatoConsegna(c, enStatoConsegna.RegistrataCorriere)
                    End Using

                    Dim Path As String = FormerPath.PathTempLocale()
                    'Dim PdfSalvato As String = FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf")
                    'Dim PdfSalvato As String = CodTrack & ".pdf"
                    'Dim Pdf As String = Path & PdfSalvato
                    Dim ZplSalvato As String = c.CodTrack & ".zpl"
                    Dim Zpl As String = Path & ZplSalvato

                    Try
                        'FormerLib.FormerHelper.PDF.CreaPdfMultiPagina(Pdf, lstPdfStreams)
                        'QUI SALVO LA STRINGA ZPL IN UN FILE FISICO
                        Using objWriter As New System.IO.StreamWriter(Zpl)
                            objWriter.Write(lstZpl)
                        End Using
                    Catch ex As Exception

                    End Try

                    Dim StampanteEtichetteGls As String = FConfiguration.Printer.EtichetteGLS ' Configuration.ConfigurationManager.AppSettings("StampanteEtichetteGls")
                    'TODO: E' IL CASO DI METTERE ANCHE LE DIMENSIONI DELLA PAGINA IN CONFIGURAZIONE?
                    'FormerHelper.PDF.StampaPdf(Pdf, StampanteEtichetteGls, 297, 288)
                    'FormerHelper.File.ShellExtended(Pdf)
                    'QUI STAMPO LA STRINGA ZPL
                    'TODO: SE DEBUG DISABILITARE LA STAMPA
                    If FormerDebug.DebugAttivo = False Then
                        RawPrinterHelper.SendStringToPrinter(StampanteEtichetteGls, lstZpl)
                    End If
                End If
                'Else
                '    Throw New Exception("La spedizione non può essere spedita con GLS!")
            End If

        End Sub

        Public Shared Sub EtichettaGls(c As ConsegnaProgrammata)

            If c.IdStatoConsegna >= enStatoConsegna.RegistrataCorriere Then
                Dim Path As String = FormerPath.PathTempLocale()
                'Dim PdfSalvato As String = c.CodTrack & ".pdf"
                'Dim Pdf As String = Path & PdfSalvato
                Dim ZplSalvato As String = c.CodTrack & ".zpl"
                Dim Zpl As String = Path & ZplSalvato
                Dim StampanteEtichetteGls As String = FConfiguration.Printer.EtichetteGLS ' Configuration.ConfigurationManager.AppSettings("StampanteEtichetteGls")
                If Not System.IO.File.Exists(Zpl) Then
                    'If Not System.IO.File.Exists(Pdf) Then
                    'Dim lstPdfStreams As New List(Of System.IO.MemoryStream)
                    Dim lstZpl As String = String.Empty
                    Dim Ok As Boolean = True
                    For i = 1 To c.NumColli
                        If Ok Then
                            Dim ContatoreProgressivo As Integer = c.IdCons & i
                            Try
                                'lstPdfStreams.Add(MgrGls.GetEtichettaPdf(ContatoreProgressivo))
                                lstZpl &= MgrWebLabelingGls.GetEtichettaZpl(ContatoreProgressivo) & vbCrLf
                            Catch ex As Exception
                                Ok = False
                                'MessageBox.Show(ex.Message)
                                Throw ex
                            End Try
                        End If
                    Next
                    If Ok Then
                        Try
                            'FormerLib.FormerHelper.PDF.CreaPdfMultiPagina(Pdf, lstPdfStreams)
                            'QUI SALVO LA STRINGA ZPL IN UN FILE FISICO
                            Using objWriter As New System.IO.StreamWriter(Zpl)
                                objWriter.Write(lstZpl)
                            End Using
                        Catch ex As Exception

                        End Try
                    End If
                End If
                'TODO: E' IL CASO DI METTERE ANCHE LE DIMENSIONI DELLA PAGINA IN CONFIGURAZIONE?
                'FormerHelper.PDF.StampaPdf(Pdf, StampanteEtichetteGls, 297, 288)
                'FormerHelper.File.ShellExtended(Pdf)
                Dim buffer As String = String.Empty
                Using objReader As New System.IO.StreamReader(Zpl)
                    buffer = objReader.ReadToEnd()
                End Using
                'QUI STAMPO LA STRINGA ZPL
                'TODO: SE DEBUG DISABILITARE LA STAMPA
                If FormerDebug.DebugAttivo = False Then
                    RawPrinterHelper.SendStringToPrinter(StampanteEtichetteGls, buffer)
                End If
            Else
                Throw New Exception("La spedizione non è registrata con GLS!")
            End If
        End Sub

        'Public Shared Sub EsportaCsvGls(ByRef c As ConsegnaProgrammata)
        '    If c.SpedibileConGls = True Then
        '        Dim CsvString As String = "vabccm;vabctr;vabcbo;vabrsd;vabrd2;vabind;vabcad;vablod;vabprd;vabnrc;vabtrc;vabemd;vabtsp;vabias;vabvas;vabncl;vabpkb;vabvlb;" &
        '        "vabcas;vabtic;vabvca;vabrmn;vabnot;vabnt2;vabffd;vabtc1;vabcel;vabtno" & vbCrLf
        '        'vabccm
        '        CsvString &= "0;"
        '        'vabctr
        '        CsvString &= "0;"
        '        'vabcbo
        '        CsvString &= "1;"
        '        'vabrsd
        '        CsvString &= c.Cliente.RagSocNome & ";"
        '        'vabrd2
        '        CsvString &= ";"
        '        'vabind
        '        CsvString &= c.IndirizzoRif.Indirizzo & ";"
        '        'vabcad
        '        CsvString &= c.IndirizzoRif.Cap & ";"
        '        'vablod
        '        CsvString &= c.IndirizzoRif.Citta & ";"
        '        'vabprd
        '        CsvString &= c.IndirizzoRif.Localita.Provincia & ";"
        '        'vabnrc
        '        CsvString &= ";"
        '        'vabtrc
        '        CsvString &= ";"
        '        'vabemd
        '        CsvString &= ";"
        '        'vabtsp
        '        CsvString &= "C;"
        '        'vabias
        '        CsvString &= "0;"
        '        'vabvas
        '        CsvString &= ";"
        '        'vabncl
        '        CsvString &= c.NumColli & ";"
        '        'vabpkb
        '        CsvString &= c.Peso & ";"
        '        'vabvlb
        '        CsvString &= ";"
        '        'vabcas
        '        CsvString &= ";"
        '        'vabtic
        '        CsvString &= ";"
        '        'vabvca
        '        CsvString &= ";"
        '        'vabrmn
        '        CsvString &= ";"
        '        'vabnot
        '        CsvString &= ";"
        '        'vabnt2
        '        CsvString &= ";"
        '        'vabffd
        '        CsvString &= ";"
        '        'vabtc1
        '        CsvString &= ";"
        '        'vabcel
        '        CsvString &= ";"
        '        'vabtno
        '        CsvString &= ";"
        '        CsvString &= vbCrLf

        '        Dim Path As String = FormerPath.PathTempLocale()
        '        Dim CsvSalvato As String = FormerLib.FormerHelper.File.GetNomeFileTemp(".csv")
        '        Dim Csv As String = Path & CsvSalvato
        '        Try
        '            Using objWriter As New System.IO.StreamWriter(Csv)
        '                objWriter.Write(CsvString)
        '            End Using
        '        Catch ex As Exception

        '        End Try
        '    End If
        'End Sub

    End Class

    'Public Class Bartolini

    '    Public Shared Sub EsportaCsvBartolini(ByRef c As ConsegnaProgrammata)
    '        If c.SpedibileConBrt = True Then
    '            Dim CsvString As String = "vabccm;vabctr;vabcbo;vabrsd;vabrd2;vabind;vabcad;vablod;vabprd;vabnrc;vabtrc;vabemd;vabtsp;vabias;vabvas;vabncl;vabpkb;vabvlb;" &
    '                "vabcas;vabtic;vabvca;vabrmn;vabnot;vabnt2;vabffd;vabtc1;vabcel;vabtno" & vbCrLf
    '            'vabccm
    '            CsvString &= "0;"
    '            'vabctr
    '            CsvString &= "0;"
    '            'vabcbo
    '            CsvString &= "1;"
    '            'vabrsd
    '            CsvString &= c.Cliente.RagSocNome & ";"
    '            'vabrd2
    '            CsvString &= ";"
    '            'vabind
    '            CsvString &= c.IndirizzoRif.Indirizzo & ";"
    '            'vabcad
    '            CsvString &= c.IndirizzoRif.Cap & ";"
    '            'vablod
    '            CsvString &= c.IndirizzoRif.Citta & ";"
    '            'vabprd
    '            CsvString &= c.IndirizzoRif.Localita.Provincia & ";"
    '            'vabnrc
    '            CsvString &= ";"
    '            'vabtrc
    '            CsvString &= ";"
    '            'vabemd
    '            CsvString &= ";"
    '            'vabtsp
    '            CsvString &= "C;"
    '            'vabias
    '            CsvString &= "0;"
    '            'vabvas
    '            CsvString &= ";"
    '            'vabncl
    '            CsvString &= c.NumColli & ";"
    '            'vabpkb
    '            CsvString &= c.Peso & ";"
    '            'vabvlb
    '            CsvString &= ";"
    '            'vabcas
    '            CsvString &= ";"
    '            'vabtic
    '            CsvString &= ";"
    '            'vabvca
    '            CsvString &= ";"
    '            'vabrmn
    '            CsvString &= ";"
    '            'vabnot
    '            CsvString &= ";"
    '            'vabnt2
    '            CsvString &= ";"
    '            'vabffd
    '            CsvString &= ";"
    '            'vabtc1
    '            CsvString &= ";"
    '            'vabcel
    '            CsvString &= ";"
    '            'vabtno
    '            CsvString &= ";"
    '            CsvString &= vbCrLf

    '            Dim Path As String = FormerPath.PathTempLocale()
    '            Dim CsvSalvato As String = FormerLib.FormerHelper.File.GetNomeFileTemp(".csv")
    '            Dim Csv As String = Path & CsvSalvato
    '            Try
    '                Using objWriter As New System.IO.StreamWriter(Csv)
    '                    objWriter.Write(CsvString)
    '                End Using
    '            Catch ex As Exception

    '            End Try
    '        End If
    '    End Sub

    'End Class

End Class
