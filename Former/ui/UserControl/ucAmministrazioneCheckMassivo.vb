Imports System.IO
Imports FormerBusinessLogic
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.Zip

Public Class ucAmministrazioneCheckMassivo
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Public Sub Carica()

        CaricaCombo()

        CaricaDati()

    End Sub

    Private Sub CaricaDati()
        Cursor.Current = Cursors.WaitCursor
        'SRL

        For Each c As Control In Controls
            If TypeOf (c) Is LinkLabel Then
                If c.Name.StartsWith("lnkSnc") OrElse c.Name.StartsWith("lnkSrl") Then
                    If c.Name.EndsWith("2") Then
                        Dim lnk As LinkLabel = c

                        lnk.Image = My.Resources._Annulla
                        lnk.Text = "-"
                        lnk.Tag = ""
                    ElseIf c.Name.EndsWith("1") Then
                        Dim lblStep1 As LinkLabel = c
                        RemoveHandler lblStep1.LinkClicked, AddressOf Voce_LinkClicked
                        AddHandler lblStep1.LinkClicked, AddressOf Voce_LinkClicked

                    End If

                End If
            End If
        Next

        Using mgr As New CheckMassiviDAO
            Dim l As List(Of CheckMassivo) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = LFM.CheckMassivo.MeseRiferimento.Name},
                                                         New LUNA.LunaSearchParameter(LFM.CheckMassivo.AnnoRiferimento, cmbAnnoRif.Text))

            For Each m As CheckMassivo In l

                Dim NomeLabelStep1 As String = "lnk"
                Dim NomeLabelStep2 As String = "lnk"

                If m.IdAzienda = MgrAziende.IdAziende.AziendaSnc Then
                    NomeLabelStep1 &= "Snc"
                ElseIf m.IdAzienda = MgrAziende.IdAziende.AziendaSrl Then
                    NomeLabelStep1 &= "Srl"
                End If

                NomeLabelStep1 &= m.MeseRiferimento.ToString("00")

                If m.TipoCheck = enTipoVoceContab.VoceAcquisto Then
                    NomeLabelStep1 &= "A"
                ElseIf m.TipoCheck = enTipoVoceContab.VoceVendita Then
                    NomeLabelStep1 &= "V"
                End If

                NomeLabelStep2 = NomeLabelStep1

                NomeLabelStep1 &= "S1"
                NomeLabelStep2 &= "S2"

                Dim lblStep1 As LinkLabel = Nothing
                Dim lblStep2 As LinkLabel = Nothing

                Dim risCS1 As Control() = Controls.Find(NomeLabelStep1, True)
                Dim risCS2 As Control() = Controls.Find(NomeLabelStep2, True)

                lblStep1 = risCS1(0)
                lblStep2 = risCS2(0)
                'RemoveHandler lblStep1.LinkClicked, AddressOf Voce_LinkClicked
                RemoveHandler lblStep2.LinkClicked, AddressOf Voce_LinkClicked

                If m.FileInputPath.Length Then
                    'lblStep1.Image = My.Resources._Ok
                    'lblStep1.Text = m.QuandoStep1.ToString("dd/MM/yyyy")
                    lblStep1.Tag = m.IdCheckMassivo
                    'AddHandler lblStep1.LinkClicked, AddressOf Voce_LinkClicked
                Else
                    lblStep1.Tag = ""
                End If

                If m.FileOutputPath.Length Then
                    If m.Stato = enStatoCheckMassivo.Completato Then
                        lblStep2.Image = My.Resources._Ok
                    ElseIf m.Stato = enStatoCheckMassivo.Attenzione Then
                        lblStep2.Image = My.Resources._Attenzione
                    End If

                    lblStep2.Text = m.QuandoStep2.ToString("dd/MM/yyyy")
                    lblStep2.Tag = m.IdCheckMassivo
                    AddHandler lblStep2.LinkClicked, AddressOf Voce_LinkClicked
                Else
                    lblStep2.Tag = ""

                End If

            Next

        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CaricaCombo()

        For i As Integer = Now.Year To 2019 Step -1
            cmbAnnoRif.Items.Add(i)
        Next

        'MgrControl.SelectIndexCombo(cmbAnnoRif, Now.Date.Year)
        cmbAnnoRif.SelectedIndex = 0

        'Dim x As New cMeseRif(False)
        'cmbMeseRifStep1.DataSource = x
        'cmbMeseRifStep1.DisplayMember = "Descrizione"
        'cmbMeseRifStep1.ValueMember = "Id"

        'Dim x2 As New cMeseRif(False)
        'cmbMeseRifStep2.DataSource = x2
        'cmbMeseRifStep2.DisplayMember = "Descrizione"
        'cmbMeseRifStep2.ValueMember = "Id"

        'Dim s1 As New cTipoVoceContab()
        'cmbTipologiaStep1.DataSource = s1
        'cmbTipologiaStep1.DisplayMember = "Descrizione"
        'cmbTipologiaStep1.ValueMember = "Id"

        'Dim s2 As New cTipoVoceContab()
        'cmbTipologiaStep2.DataSource = s2
        'cmbTipologiaStep2.DisplayMember = "Descrizione"
        'cmbTipologiaStep2.ValueMember = "Id"

        'Dim lAz As New List(Of cEnum)
        'Dim val As New cEnum(MgrAziende.IdAziende.AziendaSnc, "Former Snc")
        'lAz.Add(val)

        'val = New cEnum(MgrAziende.IdAziende.AziendaSrl, "Tipografia Former Srl")
        'lAz.Add(val)

        'cmbAziendaStep1.DisplayMember = "Descrizione"
        'cmbAziendaStep1.ValueMember = "Id"
        'cmbAziendaStep1.DataSource = lAz

        'Dim lAz2 As New List(Of cEnum)
        'lAz2.AddRange(lAz)

        'cmbAziendaStep2.DisplayMember = "Descrizione"
        'cmbAziendaStep2.ValueMember = "Id"
        'cmbAziendaStep2.DataSource = lAz2

    End Sub

    Private Sub cmbAnnoRif_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnnoRif.SelectedIndexChanged
        CaricaDati()
    End Sub

    Private Sub lnkRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        CaricaDati()
    End Sub

    Private Sub Voce_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        Dim IdMassivo As Integer = 0
        If IsNumeric(sender.tag) Then
            IdMassivo = sender.tag
        End If
        Dim Path As String = String.Empty
        If sender.name.endswith("1") Then
            If IdMassivo Then
                Using M As New CheckMassivo
                    M.Read(IdMassivo)
                    Path = M.FileInputPath
                    Path = FormerLib.FormerHelper.File.GetFolder(Path) & "\"
                    FormerLib.FormerHelper.File.ShellExtended(Path)
                End Using
            Else

                Dim IdAzienda As Integer = 0
                Dim Tipologia As Integer = 0
                Dim MeseRif As Integer = 0

                'lnkSrl1AS1
                'lnkSrl6VS1
                'lnkSnc5VS1

                Dim NomeTemp As String = sender.name
                NomeTemp = NomeTemp.Substring(3).ToLower

                If NomeTemp.StartsWith("snc") Then
                    IdAzienda = MgrAziende.IdAziende.AziendaSnc
                ElseIf NomeTemp.StartsWith("srl") Then
                    IdAzienda = MgrAziende.IdAziende.AziendaSrl
                End If

                MeseRif = NomeTemp.Substring(3, 2)

                If NomeTemp.Substring(5, 1) = "v" Then
                    Tipologia = enTipoVoceContab.VoceVendita
                ElseIf NomeTemp.Substring(5, 1) = "a" Then
                    Tipologia = enTipoVoceContab.VoceAcquisto
                End If

                generaXml(MeseRif, IdAzienda, Tipologia)
            End If

        ElseIf sender.name.endswith("2") Then
            Using M As New CheckMassivo
                M.Read(IdMassivo)

                Path = M.FileOutputPath
                caricaZip(Path)

            End Using
        End If


    End Sub

    Private Sub lnkGeneraXml_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)



    End Sub

    Private Sub generaXml(MeseRif As Integer,
                          IdAzienda As Integer,
                          IdTipologia As Integer)
        Dim AnnoRif As Integer = 0

        Dim TipologiaTrovataLong As String = String.Empty
        If IdTipologia = enTipoVoceContab.VoceVendita Then
            TipologiaTrovataLong = "Vendita"
        ElseIf IdTipologia = enTipoVoceContab.VoceAcquisto Then
            TipologiaTrovataLong = "Acquisto"
        End If
        AnnoRif = cmbAnnoRif.Text
        Dim Messaggio As String = MgrAziende.GetAziendaStr(IdAzienda) & " " &
                                    FormerHelper.Calendario.MeseToString(MeseRif) & " " & AnnoRif & " " & TipologiaTrovataLong

        If MessageBox.Show("Confermi la generazione del file XML per la richiesta massiva (" & Messaggio & ")?",
                           "Check Massivo",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.Yes Then

            'controllo che questo step non sia stato gia fatto 
            'Dim IdAzienda As Integer = 0
            'Dim IdTipologia As Integer = 0

            'IdTipologia = cmbTipologiaStep1.SelectedValue
            'IdAzienda = cmbAziendaStep1.SelectedValue

            Dim TipologiaStr As String = String.Empty
            Dim TipologiaStrFE As String = String.Empty
            'Dim TipologiaTrovataLong As String = String.Empty

            If IdTipologia = enTipoVoceContab.VoceVendita Then
                TipologiaStr = "V"
                TipologiaStrFE = "CEDENTE"
                'TipologiaTrovataLong = "Vendita"
            ElseIf IdTipologia = enTipoVoceContab.VoceAcquisto Then
                TipologiaStr = "A"
                TipologiaStrFE = "CESSIONARIO"
                'TipologiaTrovataLong = "Acquisto"
            End If

            Using mgr As New CheckMassiviDAO
                Dim l As List(Of CheckMassivo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CheckMassivo.MeseRiferimento, MeseRif),
                                                             New LUNA.LunaSearchParameter(LFM.CheckMassivo.AnnoRiferimento, AnnoRif),
                                                             New LUNA.LunaSearchParameter(LFM.CheckMassivo.IdAzienda, IdAzienda),
                                                             New LUNA.LunaSearchParameter(LFM.CheckMassivo.TipoCheck, IdTipologia))

                Dim Esistente As CheckMassivo = Nothing
                Dim OkGo As Boolean = True
                If l.Count Then
                    Esistente = l(0)
                    If Esistente.FileInputPath.Length Then
                        OkGo = False
                    End If
                End If

                If OkGo = False Then
                    If MessageBox.Show("L'attività selezionata risulta già effettuata (" & MgrAziende.GetAziendaStr(IdAzienda) & " " & FormerHelper.Calendario.MeseToString(MeseRif) & " " & AnnoRif & " " & TipologiaTrovataLong & ")! Si vuole eseguirla nuovamente?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        OkGo = True
                    End If

                End If

                If OkGo Then
                    Dim PathDest As String = FormerConfig.FormerPath.PathFattureFE & "CM\"

                    PathDest &= IdAzienda & "\" & AnnoRif & "\" & MeseRif & "\" & TipologiaStr & "\"

                    FormerLib.FormerHelper.File.CreateLongPath(PathDest)

                    Dim NomeFileRichiesta As String = String.Empty '"120319101934000000000000449961_fileInput"

                    NomeFileRichiesta = Now.ToString("ddMMyyHHmmss") & "0000000000_fileInput.xml"

                    Dim FilePath As String = PathDest & NomeFileRichiesta

                    Dim DataStart As New Date(AnnoRif, MeseRif, 1)
                    Dim DataEnd As Date = DataStart.AddMonths(1).AddDays(-1)

                    Dim BufferXML As String = String.Empty
                    BufferXML &= "<?xml version=""1.0"" encoding=""UTF-8""?>" & ControlChars.NewLine
                    BufferXML &= "<ns1:InputMassivo " & ControlChars.NewLine
                    BufferXML &= "	xsi:schemaLocation=""http://www.sogei.it/InputPubblico " & ControlChars.NewLine
                    BufferXML &= "	untitled.xsd""" & ControlChars.NewLine
                    BufferXML &= "	xmlns:ns1=""http://www.sogei.it/InputPubblico""" & ControlChars.NewLine
                    BufferXML &= "	xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">" & ControlChars.NewLine
                    BufferXML &= "	<ns1:TipoRichiesta>" & ControlChars.NewLine
                    BufferXML &= "      <ns1:Fatture>" & ControlChars.NewLine
                    BufferXML &= "          <ns1:Richiesta>FATT</ns1:Richiesta>" & ControlChars.NewLine
                    BufferXML &= "          <ns1:ElencoPiva>" & ControlChars.NewLine
                    BufferXML &= "              <ns1:Piva>" & MgrAziende.GetPartitaIva(IdAzienda) & "</ns1:Piva>" & ControlChars.NewLine
                    BufferXML &= "          </ns1:ElencoPiva>" & ControlChars.NewLine
                    BufferXML &= "          <ns1:TipoRicerca>PUNTUALE</ns1:TipoRicerca>" & ControlChars.NewLine
                    If IdTipologia = enTipoVoceContab.VoceVendita Then
                        BufferXML &= "          <ns1:FattureEmesse>" & ControlChars.NewLine
                    ElseIf IdTipologia = enTipoVoceContab.VoceAcquisto Then
                        BufferXML &= "          <ns1:FattureRicevute>" & ControlChars.NewLine
                    End If
                    BufferXML &= "          <ns1:DataEmissione>" & ControlChars.NewLine
                    BufferXML &= "              <ns1:Da>" & DataStart.ToString("yyyy-MM-dd") & "</ns1:Da>" & ControlChars.NewLine
                    BufferXML &= "              <ns1:A>" & DataEnd.ToString("yyyy-MM-dd") & "</ns1:A>" & ControlChars.NewLine
                    BufferXML &= "          </ns1:DataEmissione>" & ControlChars.NewLine
                    BufferXML &= "          <ns1:Flusso><ns1:Tutte>ALL</ns1:Tutte></ns1:Flusso>" & ControlChars.NewLine
                    BufferXML &= "          <ns1:Ruolo>" & TipologiaStrFE & "</ns1:Ruolo>" & ControlChars.NewLine
                    If IdTipologia = enTipoVoceContab.VoceVendita Then
                        BufferXML &= "          </ns1:FattureEmesse>" & ControlChars.NewLine
                    ElseIf IdTipologia = enTipoVoceContab.VoceAcquisto Then
                        BufferXML &= "          </ns1:FattureRicevute>" & ControlChars.NewLine
                    End If
                    BufferXML &= "      </ns1:Fatture>" & ControlChars.NewLine
                    BufferXML &= "  </ns1:TipoRichiesta>" & ControlChars.NewLine
                    BufferXML &= "</ns1:InputMassivo>"

                    Using w As New StreamWriter(FilePath)
                        w.Write(BufferXML)
                    End Using

                    FormerHelper.File.ShellExtended(PathDest)

                    If Esistente Is Nothing Then
                        Using m As New CheckMassivo
                            m.IdAzienda = IdAzienda
                            m.QuandoStep1 = Now
                            m.IdUtStep1 = PostazioneCorrente.UtenteConnesso.IdUt
                            m.AnnoRiferimento = AnnoRif
                            m.MeseRiferimento = MeseRif
                            m.FileInputPath = FilePath
                            m.TipoCheck = IdTipologia
                            m.Save()
                        End Using
                    Else
                        Esistente.QuandoStep1 = Now
                        Esistente.IdUtStep1 = PostazioneCorrente.UtenteConnesso.IdUt
                        Esistente.FileInputPath = FilePath
                        Esistente.Save()
                    End If

                    CaricaDati()

                End If

            End Using

        End If

    End Sub

    Private Sub lnkCaricaZip_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        SelezionaECaricaZIP()

    End Sub
    Private Sub SelezionaECaricaZIP()
        Dim PathFile As String = String.Empty
        dlgSelectZIP.CheckFileExists = True
        dlgSelectZIP.CheckPathExists = True

        If dlgSelectZIP.ShowDialog() = DialogResult.OK Then

            PathFile = dlgSelectZIP.FileName
            caricaZip(PathFile)
        End If
    End Sub

    Private Sub caricaZip(PathFile As String)

        'estraggo il file 
        Try
            If FormerDebug.DebugAttivo Then
                PathFile = PathFile.ToLower.Replace("z:\", "w:\")
            End If
            Dim pathLocale As String = FormerConfig.FormerPath.PathTempLocale

            Dim rn As New Random

            pathLocale &= rn.Next(1000000, 9999999) & "\"

            FormerLib.FormerHelper.File.CreateLongPath(pathLocale)

            Using stream As Stream = File.Open(PathFile, FileMode.Open)
                Using archive As New ZipArchive(stream)
                    ' Display the list of the files in the selected zip file using the ZipArchive.Entries property. 
                    For Each f In archive.Entries
                        Using fN As New StreamWriter(pathLocale & f.Name, FileMode.Create, System.Text.Encoding.Default)
                            Dim s As Stream = f.Open()
                            Using r As New StreamReader(s, System.Text.Encoding.Default)
                                Dim buffer As String = r.ReadToEnd
                                fN.Write(buffer)
                            End Using

                        End Using
                    Next

                End Using
            End Using

            Dim BufferResult As String = String.Empty
            Dim TrovatiErrori As Boolean = False
            Dim DataMinoreTrovata As Date = Date.MinValue
            Dim DataMaggioreTrovata As Date = Date.MinValue
            Dim IdAziendaEmittente As Integer = 0
            Dim IdAziendaRicevente As Integer = 0

            Dim ListaFatture As New List(Of FatturaElettronica)

            Dim ListaFattureAcquistoDaImportare As New List(Of FatturaElettronica)

            'FormerLib.FormerHelper.File.ShellExtended(pathLocale)
            Dim d As New DirectoryInfo(pathLocale)
            For Each f As FileInfo In d.GetFiles
                Dim IdRub As Integer = 0
                If f.Name.ToLower.IndexOf("metadato") = -1 Then
                    'BufferResult &= "<b>" & f.Name & "</b><br><br>" & ControlChars.NewLine
                    Dim PathXML As String = f.FullName

                    If PathXML.ToLower.EndsWith("xml") = False Then
                        PathXML = MgrFattureFE.ReadXmlSigned(PathXML, False)
                    End If

                    Try
                        Dim Fat As FatturaElettronica = MgrFattureFE.GetFatturaFromXML(PathXML)
                        ListaFatture.Add(Fat)
                        Dim DataDocumento As Date = MgrFattureFE.GetDataFromFormatoFE(Fat.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Data)

                        If DataMinoreTrovata = Date.MinValue Then
                            DataMinoreTrovata = DataDocumento
                        Else
                            If DataDocumento < DataMinoreTrovata Then
                                DataMinoreTrovata = DataDocumento
                            End If
                        End If
                        If DataMaggioreTrovata = Date.MinValue Then
                            DataMaggioreTrovata = DataDocumento
                        Else
                            If DataDocumento > DataMaggioreTrovata Then
                                DataMaggioreTrovata = DataDocumento
                            End If
                        End If

                        If Trim(Fat.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice) = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSnc) Then
                            If IdAziendaRicevente = 0 Then
                                IdAziendaRicevente = MgrAziende.IdAziende.AziendaSnc
                            ElseIf IdAziendaRicevente = -1 Then
                                'qui non devo fare niente
                            Else
                                If IdAziendaRicevente <> MgrAziende.IdAziende.AziendaSnc Then
                                    IdAziendaRicevente = -1
                                End If
                            End If

                        ElseIf Trim(Fat.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice) = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSrl) Then
                            If IdAziendaRicevente = 0 Then
                                IdAziendaRicevente = MgrAziende.IdAziende.AziendaSrl
                            ElseIf IdAziendaRicevente = -1 Then
                                'qui non devo fare niente
                            Else
                                If IdAziendaRicevente <> MgrAziende.IdAziende.AziendaSrl Then
                                    IdAziendaRicevente = -1
                                End If
                            End If
                        Else
                            IdAziendaRicevente = -1
                        End If

                        If Fat.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSnc) Then
                            If IdAziendaEmittente = 0 Then
                                IdAziendaEmittente = MgrAziende.IdAziende.AziendaSnc
                            ElseIf IdAziendaEmittente = -1 Then
                                'qui non devo fare niente
                            Else
                                If IdAziendaEmittente <> MgrAziende.IdAziende.AziendaSnc Then
                                    IdAziendaEmittente = -1
                                End If
                            End If

                        ElseIf Fat.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice = MgrAziende.GetPartitaIva(MgrAziende.IdAziende.AziendaSrl) Then
                            If IdAziendaEmittente = 0 Then
                                IdAziendaEmittente = MgrAziende.IdAziende.AziendaSrl
                            ElseIf IdAziendaEmittente = -1 Then
                                'qui non devo fare niente
                            Else
                                If IdAziendaEmittente <> MgrAziende.IdAziende.AziendaSrl Then
                                    IdAziendaEmittente = -1
                                End If
                            End If
                        Else
                            IdAziendaEmittente = -1
                        End If


                        'qui vuoldire che è riuscito a interpretarla
                    Catch ex As Exception

                    End Try
                    'BufferResult &= "<br><br>" & ControlChars.NewLine
                End If
            Next

            Dim TipologiaTrovata As Integer = 0
            Dim AnnoRiferimento As Integer = 0
            Dim MeseRiferimento As Integer = 0
            Dim TipologiaTrovataLong As String = String.Empty
            If IdAziendaEmittente <> 0 And IdAziendaEmittente <> -1 Then
                'qui ho dei ricavi 
                TipologiaTrovata = enTipoVoceContab.VoceVendita
                TipologiaTrovataLong = "Vendita"
            ElseIf IdAziendaRicevente <> 0 And IdAziendaRicevente <> -1 Then
                TipologiaTrovata = enTipoVoceContab.VoceAcquisto
                TipologiaTrovataLong = "Acquisto"
            End If

            If DataMinoreTrovata.Year = DataMaggioreTrovata.Year Then
                If DataMinoreTrovata.Month = DataMaggioreTrovata.Month Then
                    AnnoRiferimento = DataMinoreTrovata.Year
                    MeseRiferimento = DataMinoreTrovata.Month
                End If
            End If

            If ((IdAziendaEmittente <> 0 And IdAziendaEmittente <> -1) OrElse (IdAziendaRicevente <> 0 And IdAziendaRicevente <> -1)) AndAlso
                TipologiaTrovata <> 0 AndAlso
                AnnoRiferimento <> 0 AndAlso
                MeseRiferimento <> 0 Then
                'qui il file zip contiene file congruenti

                Dim OkGo As Boolean = True
                Dim Esistente As CheckMassivo = Nothing
                Dim IdAziendaRif As Integer = 0
                'DEVO CONTROLLARE CHE L'ATTIVITA NON SIA STATA GIA FATTA
                Using mgr As New CheckMassiviDAO

                    If TipologiaTrovata = enTipoVoceContab.VoceAcquisto Then
                        IdAziendaRif = IdAziendaRicevente
                    Else
                        IdAziendaRif = IdAziendaEmittente
                    End If
                    Dim l As List(Of CheckMassivo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CheckMassivo.MeseRiferimento, MeseRiferimento),
                                                                                        New LUNA.LunaSearchParameter(LFM.CheckMassivo.AnnoRiferimento, AnnoRiferimento),
                                                                                        New LUNA.LunaSearchParameter(LFM.CheckMassivo.IdAzienda, IdAziendaRif),
                                                                                        New LUNA.LunaSearchParameter(LFM.CheckMassivo.TipoCheck, TipologiaTrovata))


                    If l.Count Then
                        Esistente = l(0)
                        If Esistente.FileOutputPath.Length Then
                            OkGo = False
                        End If
                    End If

                End Using

                If OkGo = False Then
                    If MessageBox.Show("L'attività selezionata risulta già effettuata (" & MgrAziende.GetAziendaStr(IdAziendaRif) & " " & FormerHelper.Calendario.MeseToString(MeseRiferimento) & " " & AnnoRiferimento & " " & TipologiaTrovataLong & ")! Si vuole eseguirla nuovamente?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        OkGo = True
                    End If

                End If

                If OkGo Then
                    BufferResult &= "<font face=Arial size=2>"
                    Dim TipologiaStr As String = String.Empty
                    If TipologiaTrovata = enTipoVoceContab.VoceAcquisto Then
                        TipologiaStr = "A"
                        'fattura di acquisto
                        BufferResult &= "<h2 style='color:red'>" & MgrAziende.GetRagioneSociale(IdAziendaEmittente) & "</h2>"
                        BufferResult &= "<h3>Fatture Ricevute " & DataMinoreTrovata.ToString("dd/MM/yyyy") & " - " & DataMaggioreTrovata.ToString("dd/MM/yyyy") & "</h3>"
                        Dim ListaFattureRicevute As List(Of Costo)
                        Using mgr As New CostiDAO
                            ListaFattureRicevute = mgr.GetLista(AnnoRiferimento, MeseRiferimento,, enFiltroTipoDocumento.FatturaENotaDiCredito,,,,, IdAziendaRicevente)
                        End Using

                        'ordino le liste 
                        ListaFattureRicevute.Sort(Function(x, y) x.Numero.CompareTo(y.Numero))
                        ListaFatture.Sort(Function(x, y) x.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero.CompareTo(y.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero))

                        Dim DataRif As Date = Date.MinValue
                        Dim NumeroRif As Integer = 0

                        For Each F As FatturaElettronica In ListaFatture

                            If ListaFattureRicevute.FindAll(Function(x) x.Numero = F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero And x.Fornitore.Piva = F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice).Count = 0 Then
                                BufferResult &= "<li>Fattura <b style='color:red'>" & F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero & "</b> EMESSA il <b style='color:red'>" & MgrFattureFE.GetDataFromFormatoFE(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Data).ToString("dd/MM/yyyy") & "</b> da <b style='color:red'>" & F.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione & "</b> PRESENTE ONLINE ma NON NEL DB INTERNO</b><br><br>" & ControlChars.NewLine
                                ListaFattureAcquistoDaImportare.Add(F)
                                TrovatiErrori = True
                            End If

                        Next

                        For Each R In ListaFattureRicevute
                            If ListaFatture.FindAll(Function(x) x.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero = R.Numero And R.Fornitore.Piva = x.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice).Count = 0 Then
                                BufferResult &= "<li>Fattura <b style='color:red'>" & R.Numero & "</b> EMESSA il <b style='color:red'>" & R.DataCosto.ToString("dd/MM/yyyy") & "</b> da <b style='color:red'>" & R.pRagSoc & "</b> <b>NON PRESENTE</b> Online<br>&nbsp;&nbsp;&nbsp;&nbsp;<i>(Ricevuta il <b>" & R.DataOraRicezione.ToString("dd/MM/yyyy HH:mm.ss") & "</b>)</i><br><br>" & ControlChars.NewLine
                                TrovatiErrori = True
                            End If
                        Next
                        BufferResult &= "</font>"
                    Else
                        TipologiaStr = "V"
                        'fattura di vendita
                        'qui cerco le fatture emesse nello stesso periodo 
                        BufferResult &= "<h2 style='color:red'>" & MgrAziende.GetRagioneSociale(IdAziendaEmittente) & "</h2>"
                        BufferResult &= "<h3>Fatture Emesse " & DataMinoreTrovata.ToString("dd/MM/yyyy") & " - " & DataMaggioreTrovata.ToString("dd/MM/yyyy") & "</h3>"
                        Dim ListaFattureEmesse As List(Of RicavoEx)
                        Using mgr As New RicaviDAO
                            ListaFattureEmesse = mgr.GetLista(AnnoRiferimento, MeseRiferimento,, enFiltroTipoDocumento.FatturaENotaDiCredito,,,,,,,, IdAziendaEmittente)
                        End Using
                        'ordino le liste 
                        ListaFattureEmesse.Sort(Function(x, y) x.Numero.CompareTo(y.Numero))
                        ListaFatture.Sort(Function(x, y) MgrFattureFE.EstraiNumeroFatturaFE(x.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero).CompareTo(MgrFattureFE.EstraiNumeroFatturaFE(y.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero)))

                        Dim DataRif As Date = Date.MinValue
                        Dim NumeroRif As Integer = 0
                        BufferResult &= "<h4>CHECK ZIP SCARICATO</h4>"
                        For Each F As FatturaElettronica In ListaFatture
                            Dim DataFattura As Date = MgrFattureFE.GetDataFromFormatoFE(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Data)
                            Dim NumeroFat As Integer = MgrFattureFE.EstraiNumeroFatturaFE(F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero)

                            If NumeroFat <> -1 AndAlso NumeroRif <> 0 Then

                                Dim Differenza As Integer = NumeroFat - NumeroRif

                                If Differenza <> 1 Then
                                    For i = NumeroRif + 1 To NumeroFat - 1
                                        BufferResult &= "<li><b>NUMERO Fattura " & i & "/" & AnnoRiferimento & " MANCANTE ONLINE</b><br><br>" & ControlChars.NewLine
                                    Next

                                End If
                                NumeroRif = NumeroFat
                            End If

                            If DataRif <> Date.MinValue Then
                                If DataRif > DataFattura Then
                                    BufferResult &= "<li><b>La fattura " & F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero & " HA UNA DATA NON CONGRUENTE CON LA SEQUENZA</b><br><br>" & ControlChars.NewLine
                                End If
                            End If

                            DataRif = DataFattura

                            If ListaFattureEmesse.FindAll(Function(x) x.NumeroCompleto = F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero).Count = 0 Then
                                BufferResult &= "<li><b>Fattura " & F.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero & " PRESENTE ONLINE MA NON NEL DB INTERNO</b><br><br>" & ControlChars.NewLine
                                TrovatiErrori = True
                            End If

                        Next

                        NumeroRif = 0
                        DataRif = Date.MinValue
                        BufferResult &= "<h4>CHECK ARCHIVIO INTERNO</h4>"
                        For Each R In ListaFattureEmesse

                            Dim DataFattura As Date = R.DataRicavo

                            If NumeroRif <> 0 Then

                                Dim Differenza As Integer = R.Numero - NumeroRif

                                If Differenza <> 1 Then
                                    For i = NumeroRif + 1 To R.Numero - 1
                                        BufferResult &= "<li><b>NUMERO Fattura " & i & "/" & AnnoRiferimento & " MANCANTE NEL DB INTERNO</b><br><br>" & ControlChars.NewLine
                                    Next

                                End If

                            End If
                            NumeroRif = R.Numero

                            If DataRif <> Date.MinValue Then
                                If DataRif > DataFattura Then
                                    BufferResult &= "<li><b>La fattura " & R.NumeroCompleto & " HA UNA DATA NON CONGRUENTE CON LA SEQUENZA</b><br><br>" & ControlChars.NewLine
                                End If
                            End If

                            DataRif = DataFattura

                            If ListaFatture.FindAll(Function(x) x.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Numero = R.NumeroCompleto).Count = 0 Then
                                BufferResult &= "<li>Fattura <b style='color:red'>" & R.NumeroCompleto & "</b> EMESSA il <b style='color:red'>" & R.DataRicavoStr & "</b> ma <b>NON PRESENTE</b><br>&nbsp;&nbsp;&nbsp;&nbsp;<i>(Inviata il <b>" & R.DataOraInvio.ToString("dd/MM/yyyy HH:mm.ss") & "</b>)</i><br><br>" & ControlChars.NewLine
                                TrovatiErrori = True
                            End If
                        Next

                    End If
                    BufferResult &= "</font>"

                    Dim PathDest As String = FormerConfig.FormerPath.PathFattureFE & "CM\"

                    PathDest &= IdAziendaRif & "\" & AnnoRiferimento & "\" & MeseRiferimento & "\" & TipologiaStr & "\"

                    FormerLib.FormerHelper.File.CreateLongPath(PathDest)

                    PathDest &= FormerLib.FormerHelper.File.EstraiNomeFile(PathFile)

                    'l'if serve se viene rieseguito il controllo su se stesso 
                    If PathDest <> PathFile Then MgrIO.FileCopia(Me, PathFile, PathDest)

                    Dim ProssimoStato As enStatoCheckMassivo = enStatoCheckMassivo.Completato
                    If TrovatiErrori Then
                        ProssimoStato = enStatoCheckMassivo.Attenzione
                    End If

                    If Esistente Is Nothing Then
                        Using m As New CheckMassivo
                            m.IdAzienda = IdAziendaRif
                            m.QuandoStep2 = Now
                            m.IdUtStep2 = PostazioneCorrente.UtenteConnesso.IdUt
                            m.AnnoRiferimento = AnnoRiferimento
                            m.MeseRiferimento = MeseRiferimento
                            m.FileOutputPath = PathDest
                            m.TipoCheck = TipologiaTrovata
                            m.Stato = ProssimoStato
                            m.Save()
                        End Using
                    Else
                        Esistente.QuandoStep2 = Now
                        Esistente.IdUtStep2 = PostazioneCorrente.UtenteConnesso.IdUt
                        Esistente.FileOutputPath = PathDest
                        Esistente.Stato = ProssimoStato
                        Esistente.Save()
                    End If

                    If TrovatiErrori = False Then
                        MessageBox.Show("Tutto è congruente. Attività completata")
                    Else
                        Dim PathResult As String = FormerConfig.FormerPath.PathTempLocale & FormerHelper.File.GetNomeFileTemp(".htm")

                        Using w As New StreamWriter(PathResult)
                            w.Write(BufferResult)
                        End Using

                        ParentFormEx.Sottofondo()
                        Using f As New frmBrowser
                            f.CaricaFromCheckMassivoFatture(PathResult, ListaFattureAcquistoDaImportare)
                        End Using
                        ParentFormEx.Sottofondo()
                    End If
                    CaricaDati()
                End If

            Else
                MessageBox.Show("Il file ZIP contiene fatture non congruenti con le richieste del gestionale. (+ di 1 mese, + di 1 azienda, + tipologie)")
            End If

        Catch ex As Exception
            ManageError(ex)
        End Try



    End Sub


    Private Sub btnCaricaZip_Click(sender As Object, e As EventArgs) Handles btnCaricaZip.Click

        SelezionaECaricaZIP()

    End Sub

End Class
