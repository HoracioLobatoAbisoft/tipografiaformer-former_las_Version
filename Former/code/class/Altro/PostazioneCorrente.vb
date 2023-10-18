Imports FormerDALSql
Imports System.Configuration
Imports FormerConfig
Imports FormerBusinessLogic
Imports System.Threading
Imports System.IO

Public Class PostazioneCorrente

    'Implements IPostazioneLavoro

    'costanti da impostare manualmente
    Public Shared Property UtenteConnesso As Utente
    Public Shared ReadOnly Property CaricamentiAutomatici As Boolean
        Get
            Dim ris As Boolean = True
            ris = FormerConfig.FConfiguration.Altro.CaricamentiAutomatici
            Return ris
        End Get
    End Property

    Public Shared Property ScaricamentoOrdiniInCorso As Boolean = False

    Public Shared Property UltimaDirectoryAperta As String = String.Empty
    Public Shared Property DialogSortColumn As Integer = -1
    Public Shared Property DialogSortOrder As SortOrder = SortOrder.Ascending

    Public Shared Property CallerAttivo As Boolean = False
    Public Shared Property ReminderAttivo As Boolean = False

    Private Shared _frmWait As frmWait = Nothing

    Private Shared _TextMessage As String = String.Empty

    Public Shared Sub MostraAttesa(Optional TextMessage As String = "")
        'If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine("MOSTRA FORMWAIT")
        _TextMessage = TextMessage
        Dim th As System.Threading.Thread = New Threading.Thread(AddressOf Task_A)
        th.SetApartmentState(ApartmentState.STA)
        th.Start()
    End Sub

    Public Shared Sub Task_A()
        _frmWait = New frmWait() ' Must be created on this thread!
        If _TextMessage.Length Then _frmWait.SetLabel(_TextMessage)
        _TextMessage = String.Empty
        Application.Run(_frmWait)
        '_frmWait.Carica()
    End Sub

    Public Shared Sub NascondiAttesa()

        'If Not _frmWait Is Nothing Then

        '    _frmWait.Hide()
        '    _frmWait.Close()

        'Try
        _frmWait.BeginInvoke(New Action(Sub() _frmWait.Close()))
        'If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine("CHIUSURA FORMWAIT")
        '_frmWait = Nothing
        'Catch ex As Exception

        'End Try

        'End If

    End Sub

    'Public Shared Property ColoreTema As Color = Color.White
    'Public Shared Property ColorePrimoPiano As Color = Color.Orange

    'Public Shared Property AnnoSelezionato As Integer = 0 ' Implements IPostazioneLavoro.AnnoSelezionato

    'Private _Email As String = "amministrazione@tipografiaformer.com"
    'Private _EmailPwd As String = "amministrazione"
    'Private _Pop3Server As String = "pop3.tipografiaformer.com"
    'Private _SmtpServer As String = "smtp.tipografiaformer.com"
    'Private _InviaMail As Integer = 0
    'Private _CancellaMail As Integer = 0

    'Private _PathTemp As String = System.AppDomain.CurrentDomain.BaseDirectory() & "temp\"
    'Private _PathCommesse As String = System.AppDomain.CurrentDomain.BaseDirectory() & "commesse\"
    'Private _PathFatture As String = System.AppDomain.CurrentDomain.BaseDirectory() & "fatture\"
    Private Shared _PathPreventivi As String = System.AppDomain.CurrentDomain.BaseDirectory() & "preventivi\"
    Private Shared _PathBiglietti As String = System.AppDomain.CurrentDomain.BaseDirectory() & "biglietti\"
    'Private _PathLavorazioni As String = System.AppDomain.CurrentDomain.BaseDirectory() & "lavorazioni\"
    'Private _PathFileListino As String = System.AppDomain.CurrentDomain.BaseDirectory() & "imglistino\"
    'Private _PathTemplate As String = System.AppDomain.CurrentDomain.BaseDirectory() & "template\"
    'Private _StampanteEtichette As String = ""
    'Private _StampanteLibera As String = ""

    Public Shared Property IsUsbLogin As Boolean = False
    Public Shared Property PortaUDP As Integer = 2456
    Public Shared Property TimeoutCallerId As Integer = 60

    'Public Shared Property LastPing As Date = Date.MinValue

    Public Shared MessageAggiornamentoAperto As Boolean = False

    Private Shared _SessioneLavoro As String = String.Empty
    Public Shared ReadOnly Property SessioneLavoro As String
        Get
            If _SessioneLavoro = String.Empty Then
                Dim G As Guid = Guid.NewGuid

                _SessioneLavoro = G.ToString
            End If
            Return _SessioneLavoro
        End Get
    End Property

    Public Shared ReadOnly Property TracciamentoAttivo As Boolean
        Get
            Dim ris As Boolean = False
            Try
                ris = FConfiguration.Debug.TracciamentoAttivo ' ConfigurationManager.AppSettings("TracciamentoAttivo")
            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

    'Public Shared Sub FileCopy(Optional frmRif As Form = Nothing, _
    '                    Optional FileOrigine As String = "", _
    '                    Optional FileDest As String = "", _
    '                    Optional ResizeImg As Boolean = False)

    '    If frmRif Is Nothing Then frmRif = FormPrincipale

    '    MgrIO.FileCopia(frmRif, FileOrigine, FileDest, ResizeImg)

    'End Sub
    Public Shared Sub ChiudiSessioneLavoro()

        'If Not _cnOld Is Nothing Then

        '    If _cnOld.State = ConnectionState.Open Then

        '        _cnOld.Close()

        '    End If

        '    _cnOld.Dispose()
        '    _cnOld = Nothing

        'End If
        'Try
        '    MostraAttesa("Chisura della sessione di lavoro in corso...")
        'Catch ex As Exception

        'End Try


        If LUNA.LunaContext.ShareConnection Then LUNA.LunaContext.CloseDbConnection()
        'ripulisco le stampe temp
        FormPrincipale.TerminaAscolto()
        Try
            Kill(FormerPath.PathStampaTemp & "*.htm")
        Catch ex As Exception

        End Try

        Try
            Kill(FormerPath.PathTempLocale & "*.*")
        Catch ex As Exception

        End Try

        Try
            Directory.Delete(FormerPath.PathTempLocale, True)
        Catch ex As Exception

        End Try

        Try
            MgrOrderLock.UnlockAll(PostazioneCorrente.UtenteConnesso.IdUt)
        Catch ex As Exception

        End Try

        Try
            FormerSecurity.RegistraLogOut(PostazioneCorrente.UtenteConnesso.IdUt,
                                          Environment.MachineName)
        Catch ex As Exception

        End Try

        'Try
        '    NascondiAttesa()
        'Catch ex As Exception

        'End Try


    End Sub

    'Public Sub PulisciTemp()

    '    'controllo tutti i file nella cartella temp ed elimino quelli non piu necessari
    '    Dim x As FileInfo

    '    Dim dir As New DirectoryInfo(FormerPath.PathTemp)
    '    Dim Counter As Integer = 0
    '    Dim SoloElenco As Boolean = True

    '    If MessageBox.Show("Vuoi cancellare effettivamente i file o ricevere solo l'elenco dei file che verrebbero lasciati? (SI = Cancellazione, NO = Elenco)", "Cancellazione File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

    '        SoloElenco = False

    '    End If
    '    Dim BufferFile As String = "ELENCO FILE CHE NON VERRANNO CANCELLATI" & vbNewLine & _
    '        "********************************************" & vbNewLine

    '    For Each x In dir.GetFiles

    '        'qui ho tutti i file nella cartella temp
    '        'li cerco nella tabella sorgenti e nel campo file della tabella ordini
    '        Dim ordFile As New cOrdiniColl, Ris As Boolean = True, Ok As Boolean = True

    '        Ris = ordFile.TrovaFile(x.FullName)

    '        Try
    '            If SoloElenco Then
    '                If Ris = True Then BufferFile &= x.Name & vbNewLine
    '            Else
    '                If Ris = False Then
    '                    If Ok Then
    '                        MgrFormerIo.FileDelete(x.FullName)
    '                        Counter += 1
    '                    End If
    '                End If

    '            End If

    '        Catch ex As Exception

    '        End Try

    '    Next

    '    If SoloElenco Then
    '        Dim TempName As String = FormerPath.PathLocale & GetNomeFileTemp(".txt")
    '        Using w As New StreamWriter(TempName)
    '            w.Write(BufferFile)
    '        End Using
    '        FormerHelper.File.ShellExtended(TempName)
    '    Else
    '        MessageBox.Show("Pulizia cartella temporanea eseguita correttamente! Cancellati " & Counter & " files", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If

    'End Sub

    'Public Sub SpostaDigitaleDaTemp(frmRif As Form)

    '    Dim Counter As Integer = 0

    '    Dim x As New cOrdiniColl, ListaIDOrd As List(Of Integer)

    '    ListaIDOrd = x.ListaIdOrdDigitaleDaSpostare(FormerPath.PathTemp)

    '    For Each IdSing As Integer In ListaIDOrd
    '        'su questo ordine devo spostare il file e aggiornare il db
    '        Dim Ord As New Ordine
    '        Ord.Read(IdSing)

    '        Dim NuovoNomeFile As String = FormerPath.PathCommesse & "Digitale\" & GetNomeFile(Ord.FilePath)
    '        Dim VecchioNomeFile As String = Ord.FilePath

    '        If File.Exists(VecchioNomeFile) Then
    '            MgrIO.FileCopia(frmRif, Ord.FilePath, NuovoNomeFile)
    '            Ord.FilePath = NuovoNomeFile
    '        Else
    '            Ord.FilePath = String.Empty
    '        End If

    '        Using mO As New OrdiniDAO
    '            mO.SalvaFile(Ord)
    '        End Using

    '        'FileCopy(Ord.FilePath, NuovoNomeFile)

    '        'qui copio i file dei sorgenti degli ordini
    '        Try
    '            If File.Exists(VecchioNomeFile) Then
    '                FileIO.FileSystem.DeleteFile(VecchioNomeFile, _
    '                                             FileIO.UIOption.OnlyErrorDialogs, _
    '                                             FileIO.RecycleOption.DeletePermanently)

    '            End If
    '        Catch ex As Exception

    '        End Try

    '        For Each sorg As FileSorgente In Ord.CollSorgenti

    '            NuovoNomeFile = FormerPath.PathCommesse & "Digitale\" & GetNomeFile(sorg.FilePath)
    '            VecchioNomeFile = sorg.FilePath
    '            'FileCopy(sorg.FilePath, NuovoNomeFile)
    '            If File.Exists(VecchioNomeFile) Then
    '                MgrIO.FileCopia(frmRif, sorg.FilePath, NuovoNomeFile)
    '                sorg.FilePath = NuovoNomeFile
    '                Try
    '                    FileIO.FileSystem.DeleteFile(VecchioNomeFile, _
    '                                                 FileIO.UIOption.OnlyErrorDialogs, _
    '                                                 FileIO.RecycleOption.DeletePermanently)
    '                Catch ex As Exception

    '                End Try

    '            Else
    '                sorg.FilePath = String.Empty
    '            End If
    '            sorg.Save()
    '        Next
    '    Next


    'End Sub

    'Public Sub CompattaDB()

    '    'Try
    '    '    Cursor.Current = Cursors.WaitCursor

    '    '    MessageBox.Show("Attenzione! Per ricompattare il db è necessario che tutte le postazioni escano dal programma, accertarsene prima di continuare!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '    '    If Postazione.EseguiBackup(True) = 0 Then

    '    '        ChiudiConn()
    '    '        Dim jro As JRO.JetEngine
    '    '        jro = New JRO.JetEngine
    '    '        jro.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Postazione.PathDB, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Postazione.PathDB & "x;Jet OLEDB:Engine Type=5")

    '    '        FileCopy(Postazione.PathDB & "x", Postazione.PathDB)
    '    '        Kill(Postazione.PathDB & "x")
    '    '        MessageBox.Show("Ricompattazione Database eseguita correttamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    '        ApriConn()

    '    '    End If

    '    'Catch ex As Exception
    '    '    ManageError(ex)
    '    'End Try

    '    'Cursor.Current = Cursors.Default

    'End Sub

    ''Public ReadOnly Property IconaOk() As String 'Implements IPostazioneLavoro.IconaOK
    ''    Get

    ''        Dim PathIco As String = FormerPath.PathLocale & "iconaOK.jpg"

    ''        If System.IO.Directory.Exists(PathIco) = False Then Former.My.Resources.icoOk.Save(PathIco)

    ''        Return PathIco

    ''    End Get
    ''End Property

    'Public ReadOnly Property IconaWorking() As String ' Implements IPostazioneLavoro.IconaWorking
    '    Get

    '        Dim PathIco As String = FormerPath.PathLocale & "iconaWorking.jpg"

    '        If System.IO.Directory.Exists(PathIco) = False Then Former.My.Resources.icoPrint.Save(PathIco)

    '        Return PathIco

    '    End Get
    'End Property

    'Public ReadOnly Property IconaCancel() As String
    '    Get

    '        Dim PathIco As String = FormerPath.PathLocale & "iconaCancel.jpg"

    '        If System.IO.Directory.Exists(PathIco) = False Then Former.My.Resources.icoCancel.Save(PathIco)

    '        Return PathIco

    '    End Get
    'End Property

    'Public ReadOnly Property StampaTempDir() As String
    '    Get
    '        Return FormerPath.PathLocale & "stampatemp\"
    '    End Get
    'End Property

    'Private _FTPServer As String = "ftp.tipografiaformer.com"
    'Public ReadOnly Property FTPServer() As String
    '    Get
    '        Return _FTPServer
    '    End Get
    'End Property

    'Private _FTPServer2 As String = "ftp.tipografiaformer.it"
    'Public ReadOnly Property FTPServer2() As String
    '    Get
    '        Return _FTPServer2
    '    End Get
    'End Property

    'Private _FTPLogin As String = "1246360@aruba.it"
    'Public ReadOnly Property FTPLogin() As String
    '    Get
    '        Return _FTPLogin
    '    End Get
    'End Property

    'Private _FTPPwd As String = "8ddd2cacc3"
    'Public ReadOnly Property FTPPwd() As String
    '    Get
    '        Return _FTPPwd
    '    End Get
    'End Property

    'Public ReadOnly Property FileStampaTemp() As String 'Implements IPostazioneLavoro.StampaTemp
    '    Get
    '        Return FormerPath.PathStampaTemp & GetNomeFileTemp(".htm")
    '    End Get
    'End Property

    'Public Property Email() As String
    '    Get

    '        Return _Email

    '    End Get
    '    Set(ByVal value As String)
    '        _Email = value
    '    End Set
    'End Property

    'Public Property EmailPwd() As String
    '    Get

    '        Return _EmailPwd

    '    End Get
    '    Set(ByVal value As String)
    '        _EmailPwd = value
    '    End Set
    'End Property

    'Public Property Pop3Server() As String
    '    Get

    '        Return _Pop3Server

    '    End Get
    '    Set(ByVal value As String)
    '        _Pop3Server = value
    '    End Set
    'End Property

    'Public Property SmtpServer() As String
    '    Get

    '        Return _SmtpServer

    '    End Get
    '    Set(ByVal value As String)
    '        _SmtpServer = value
    '    End Set
    'End Property

    'Public Property InviaMail() As Integer
    '    Get

    '        Return _InviaMail

    '    End Get
    '    Set(ByVal value As Integer)
    '        _InviaMail = value
    '    End Set
    'End Property

    'Public Property CancellaMail() As Integer
    '    Get

    '        Return _CancellaMail

    '    End Get
    '    Set(ByVal value As Integer)
    '        _CancellaMail = value
    '    End Set
    'End Property

    Private Shared _CodCliBart As String = ""
    Public Shared Property CodCliBart() As String
        Get

            Return _CodCliBart

        End Get
        Set(ByVal value As String)
            _CodCliBart = value
        End Set
    End Property

    Public Shared ReadOnly Property StampanteConsegnaOrdini() As String
        Get
            Dim Ris As String = "PDFCreator"
            Try
                Dim ConfigPrinter As String = FConfiguration.Printer.ConsegnaOrdini ' ConfigurationManager.AppSettings("StampanteConsegnaOrdini")

                If ConfigPrinter.Length Then
                    Ris = ConfigPrinter
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    'Public Shared ReadOnly Property FtpServerNameProduzione As String
    '    Get
    '        Dim ris As String = String.Empty

    '        Try
    '            ris = ConfigurationManager.AppSettings("FtpServerNameProduzione")
    '        Catch ex As Exception

    '        End Try

    '        Return ris
    '    End Get
    'End Property

    'Public Shared ReadOnly Property FtpServerLoginProduzione As String
    '    Get
    '        Dim ris As String = String.Empty

    '        Try
    '            ris = ConfigurationManager.AppSettings("FtpServerLoginProduzione")
    '        Catch ex As Exception

    '        End Try

    '        Return ris
    '    End Get
    'End Property

    'Public Shared ReadOnly Property FtpServerPwdProduzione As String
    '    Get
    '        Dim ris As String = String.Empty

    '        Try
    '            ris = ConfigurationManager.AppSettings("FtpServerPwdProduzione")
    '        Catch ex As Exception

    '        End Try

    '        Return ris
    '    End Get
    'End Property

    'Public Shared ReadOnly Property FtpServerNameSviluppo As String
    '    Get
    '        Dim ris As String = String.Empty

    '        Try
    '            ris = ConfigurationManager.AppSettings("FtpServerNameSviluppo")
    '        Catch ex As Exception

    '        End Try

    '        Return ris
    '    End Get
    'End Property

    'Public Shared ReadOnly Property FtpServerLoginSviluppo As String
    '    Get
    '        Dim ris As String = String.Empty

    '        Try
    '            ris = ConfigurationManager.AppSettings("FtpServerLoginSviluppo")
    '        Catch ex As Exception

    '        End Try

    '        Return ris
    '    End Get
    'End Property

    'Public Shared ReadOnly Property FtpServerPwdSviluppo As String
    '    Get
    '        Dim ris As String = String.Empty

    '        Try
    '            ris = ConfigurationManager.AppSettings("FtpServerPwdSviluppo")
    '        Catch ex As Exception

    '        End Try

    '        Return ris
    '    End Get
    'End Property

    Public Shared ReadOnly Property StampanteLibera() As String
        Get
            Dim Ris As String = "PDFCreator"
            Try
                Dim ConfigPrinter As String = FConfiguration.Printer.Libera '  ConfigurationManager.AppSettings("StampanteLibera")

                If ConfigPrinter.Length Then
                    Ris = ConfigPrinter
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    'Public Shared ReadOnly Property StampanteLiberaOperatore() As String
    '    Get
    '        Dim Ris As String = StampanteLibera
    '        Try
    '            Dim ConfigPrinter As String = FConfiguration.Printer.LiberaOperatore ' ConfigurationManager.AppSettings("StampanteLiberaOperatore")

    '            If ConfigPrinter.Length Then
    '                Ris = ConfigPrinter
    '            End If
    '        Catch ex As Exception

    '        End Try
    '        Return Ris
    '    End Get
    'End Property

    Public Shared ReadOnly Property StampanteFattureSrl() As String
        Get
            Dim Ris As String = "PDFCreator"
            Try
                Dim ConfigPrinter As String = FConfiguration.Printer.FattureSrl ' ConfigurationManager.AppSettings("StampanteFatture")

                If ConfigPrinter.Length Then
                    Ris = ConfigPrinter
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property StampanteFattureSnc() As String
        Get
            Dim Ris As String = "PDFCreator"
            Try
                Dim ConfigPrinter As String = FConfiguration.Printer.FattureSnc ' ConfigurationManager.AppSettings("StampanteFatture")

                If ConfigPrinter.Length Then
                    Ris = ConfigPrinter
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    'Public Shared ReadOnly Property StampanteFattureOperatore() As String
    '    Get
    '        Dim Ris As String = StampanteLibera
    '        Try
    '            Dim ConfigPrinter As String = FConfiguration.Printer.FattureOperatore ' ConfigurationManager.AppSettings("StampanteFattureOperatore")

    '            If ConfigPrinter.Length Then
    '                Ris = ConfigPrinter
    '            End If
    '        Catch ex As Exception

    '        End Try
    '        Return Ris
    '    End Get
    'End Property

    Public Shared ReadOnly Property StampanteEtichetteGLS() As String
        Get
            Dim Ris As String = "PDFCreator"
            Try
                Dim ConfigPrinter As String = FConfiguration.Printer.EtichetteGLS ' ConfigurationManager.AppSettings("StampanteEtichetteGls")

                If ConfigPrinter.Length Then
                    Ris = ConfigPrinter
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property StampanteEtichette() As String
        Get
            Dim Ris As String = "PDFCreator"
            Try
                Dim ConfigPrinter As String = FConfiguration.Printer.Etichette ' ConfigurationManager.AppSettings("StampanteEtichette")

                If ConfigPrinter.Length Then
                    Ris = ConfigPrinter
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property StampantePDF() As String
        Get
            Dim Ris As String = "PDFCreator"
            Try
                Dim ConfigPrinter As String = FConfiguration.Printer.PDF ' ConfigurationManager.AppSettings("StampantePDF")

                If ConfigPrinter.Length Then
                    Ris = ConfigPrinter
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property MargineXEtichette() As Integer
        Get
            Dim Ris As Integer = 0
            Try
                Ris = FConfiguration.Printer.MargineXEtichette ' ConfigurationManager.AppSettings("MargineXEtichette")
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property MargineYEtichette() As Integer
        Get
            Dim Ris As Integer = 0
            Try
                Ris = FConfiguration.Printer.MargineYEtichette ' ConfigurationManager.AppSettings("MargineYEtichette")
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property MargineXFatture() As Integer
        Get
            Dim Ris As Integer = 0
            Try
                Ris = FConfiguration.Printer.MargineXFatture ' ConfigurationManager.AppSettings("MargineXFatture")
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property MargineYFatture() As Integer
        Get
            Dim Ris As Integer = 0
            Try
                Ris = FConfiguration.Printer.MargineYFatture ' ConfigurationManager.AppSettings("MargineYFatture")
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    'Public Property MargineXEtichette() As Integer
    '    Get

    '        Return _MargineXEtichette

    '    End Get
    '    Set(ByVal value As Integer)
    '        _MargineXEtichette = value
    '    End Set
    'End Property

    'Public Property MargineyEtichette() As Integer
    '    Get

    '        Return _MargineYEtichette

    '    End Get
    '    Set(ByVal value As Integer)
    '        _MargineYEtichette = value
    '    End Set
    'End Property

    ''Public Property MargineXFatture() As Integer
    ''    Get

    ''        Return _MargineXFatture

    ''    End Get
    ''    Set(ByVal value As Integer)
    ''        _MargineXFatture = value
    ''    End Set
    ''End Property

    ''Public Property MargineyFatture() As Integer
    ''    Get

    ''        Return _MargineYFatture

    ''    End Get
    ''    Set(ByVal value As Integer)
    ''        _MargineYFatture = value
    ''    End Set
    ''End Property

    'Private _NextFat As Integer = 1
    'Public Property NextFat() As Integer
    '    Get

    '        Return _NextFat

    '    End Get
    '    Set(ByVal value As Integer)
    '        _NextFat = value
    '    End Set
    'End Property

    'Private _NextDDt As Integer = 1
    'Public Property NextDDT() As Integer
    '    Get

    '        Return _NextDDt

    '    End Get
    '    Set(ByVal value As Integer)
    '        _NextDDt = value
    '    End Set
    'End Property

    'Public Property PathTemp() As String 'Implements IPostazioneLavoro.PathTemp
    '    'torna il path completo di slash finale
    '    Get
    '        If _PathTemp.EndsWith("\") = False Then _PathTemp = _PathTemp & "\"
    '        Return _PathTemp

    '    End Get
    '    Set(ByVal value As String)
    '        _PathTemp = value
    '    End Set

    'End Property

    'Public ReadOnly Property PathTemplateMarketing() As String
    '    'torna il path completo di slash finale
    '    Get
    '        Return FormerPath.PathCentralizzato & "\TemplateMarketing\"

    '    End Get


    'End Property



    'Public ReadOnly Property PathEmail() As String 'Implements IPostazioneLavoro.PathEmail
    '    'torna il path completo di slash finale
    '    Get
    '        Return FormerPath.PathCentralizzato & "\FormerEmail\"
    '    End Get
    'End Property

    'Public ReadOnly Property PathListinoImg As String
    '    Get
    '        Return PathFileListino & "img\"
    '    End Get
    'End Property

    'Public ReadOnly Property PathListinoFoto As String
    '    Get
    '        Return PathFileListino & "foto\"
    '    End Get
    'End Property

    'Public ReadOnly Property PathListinoTemplate As String
    '    Get
    '        Return PathFileListino & "template\"
    '    End Get
    'End Property

    'Public Property PathFileListino() As String
    '    'torna il path completo di slash finale
    '    Get
    '        If _PathFileListino.EndsWith("\") = False Then _PathFileListino = _PathFileListino & "\"
    '        Return _PathFileListino

    '    End Get
    '    Set(ByVal value As String)
    '        _PathFileListino = value
    '    End Set
    'End Property

    'Public Property PathTemplate() As String
    '    'torna il path completo di slash finale
    '    Get
    '        If _PathTemplate.EndsWith("\") = False Then _PathTemplate = _PathTemplate & "\"
    '        Return _PathTemplate

    '    End Get
    '    Set(ByVal value As String)
    '        _PathTemplate = value
    '    End Set
    'End Property

    'Public Property PathLavorazioni() As String 'Implements IPostazioneLavoro.PathLavorazioni
    '    'torna il path completo di slash finale
    '    Get
    '        If _PathLavorazioni.EndsWith("\") = False Then _PathLavorazioni = _PathLavorazioni & "\"
    '        Return _PathLavorazioni

    '    End Get
    '    Set(ByVal value As String)
    '        _PathLavorazioni = value
    '    End Set
    'End Property

    Public Shared ReadOnly Property PathDirectoryLocale As String
        Get
            Return My.Application.Info.DirectoryPath
        End Get
    End Property

    Public Shared ReadOnly Property PathReleaseNote As String
        Get
            Dim PathNote As String = PathDirectoryLocale & "\releasenote.txt"

            Return PathNote
        End Get
    End Property

    Public Shared ReadOnly Property PathLastReleaseNote As String
        Get
            Dim PathNote As String = PathDirectoryLocale & "\lastreleasenote.txt"

            Return PathNote
        End Get
    End Property

    Public Shared Property PathBiglietti() As String
        'torna il path completo di slash finale
        Get
            If _PathBiglietti.EndsWith("\") = False Then _PathBiglietti = _PathBiglietti & "\"
            Return _PathBiglietti

        End Get
        Set(ByVal value As String)
            _PathBiglietti = value
        End Set
    End Property

    Public Shared Property PathPreventivi() As String
        'torna il path completo di slash finale
        Get

            If _PathPreventivi.EndsWith("\") = False Then _PathPreventivi = _PathPreventivi & "\"
            Return _PathPreventivi

        End Get
        Set(ByVal value As String)
            _PathPreventivi = value
        End Set
    End Property

    'Public Property PathCommesse() As String 'Implements IPostazioneLavoro.PathCommesse
    '    'torna il path completo di slash finale
    '    Get
    '        If _PathCommesse.EndsWith("\") = False Then _PathCommesse = _PathCommesse & "\"
    '        Return _PathCommesse

    '    End Get
    '    Set(ByVal value As String)
    '        _PathCommesse = value
    '    End Set
    'End Property

    ''Private _StrConnWeb As String = "Server=localhost\SQLEXPRESS;Database=FormerWeb;User Id=sa;Password=tgHi9MaEQA;"
    ''Public Property StrConnWeb As String
    ''    Get
    ''        Return _StrConnWeb
    ''    End Get
    ''    Set(value As String)
    ''        _StrConnWeb = value
    ''    End Set
    ''End Property

    'Private _FTPServerSito As String = "former-server"
    'Public Property FTPServerSito As String
    '    Get
    '        Return _FTPServerSito
    '    End Get
    '    Set(value As String)
    '        _FTPServerSito = value
    '    End Set
    'End Property

    'Private _FTPLoginSito As String = "Administrator"
    'Public Property FTPLoginSito As String
    '    Get
    '        Return _FTPLoginSito
    '    End Get
    '    Set(value As String)
    '        _FTPLoginSito = value
    '    End Set
    'End Property

    'Private _FTPPwdSito As String = "tgHi9MaEQA"
    'Public Property FTPPwdSito As String
    '    Get
    '        Return _FTPPwdSito
    '    End Get
    '    Set(value As String)
    '        _FTPPwdSito = value
    '    End Set
    'End Property

    'Public Property PathFatture() As String
    '    'torna il path completo di slash finale
    '    Get
    '        If _PathFatture.EndsWith("\") = False Then _PathFatture = _PathFatture & "\"
    '        Return _PathFatture

    '    End Get
    '    Set(ByVal value As String)
    '        _PathFatture = value
    '    End Set
    'End Property
    'Private _PathCTP As String = System.AppDomain.CurrentDomain.BaseDirectory() & "ctp\"
    'Public Property PathCtp() As String
    '    'torna il path completo di slash finale
    '    Get
    '        If _PathCTP.EndsWith("\") = False Then _PathCTP = _PathCTP & "\"
    '        Return _PathCTP

    '    End Get
    '    Set(ByVal value As String)
    '        _PathCTP = value
    '    End Set
    'End Property
    'Private _PathJob As String = System.AppDomain.CurrentDomain.BaseDirectory() & "job\"
    'Public Property PathJob() As String 'Implements IPostazioneLavoro.PathJob
    '    'torna il path completo di slash finale
    '    Get
    '        If _PathJob.EndsWith("\") = False Then _PathJob = _PathJob & "\"
    '        Return _PathJob

    '    End Get
    '    Set(ByVal value As String)
    '        _PathJob = value
    '    End Set
    'End Property

    'Public Function ReadXml() As Boolean

    '    Dim NomeFile As String = FormerPath.PathLocale & NomeFileIni
    '    'Dim Provider As String = ""
    '    'Dim db As String = ""

    '    Dim Ris As Boolean = False

    '    Try
    '        If Dir(FormerPath.PathLocale & NomeFileIni) <> "" Then


    '            Dim objXMLTR As New XmlTextReader(NomeFile)
    '            Do While objXMLTR.Read

    '                'Output elements and values
    '                'Look at output in browser and compare to menu.xml file to 
    '                'see exactly what is being done
    '                If objXMLTR.NodeType = XmlNodeType.Element Then
    '                    Select Case objXMLTR.Name
    '                        'SQL DB
    '                        'Case "SqlDB"
    '                        '    SQLDb = objXMLTR.ReadString
    '                        'Case "SqlLogin"
    '                        '    SqlLogin = objXMLTR.ReadString
    '                        'Case "SqlPwd"
    '                        '    SqlPwd = objXMLTR.ReadString
    '                        'Case "SqlServerName"
    '                        '    SqlServerName = objXMLTR.ReadString
    '                        'Case "SqlDbName"
    '                        '    SqlDbName = objXMLTR.ReadString
    '                        '    'SITO
    '                        'Case "StrConnWeb"
    '                        '    StrConnWeb = objXMLTR.ReadString
    '                        Case "FTPServerSito"
    '                            FTPServerSito = objXMLTR.ReadString
    '                        Case "FTPLoginSito"
    '                            FTPLoginSito = objXMLTR.ReadString
    '                        Case "FTPPwdSito"
    '                            FTPPwdSito = objXMLTR.ReadString
    '                            'DB 
    '                            'Case "PathDB"
    '                            '    PathDB = objXMLTR.ReadString
    '                        Case "PathTemp"
    '                            _PathTemp = objXMLTR.ReadString
    '                        Case "PathCommesse"
    '                            _PathCommesse = objXMLTR.ReadString
    '                        Case "PathLavorazioni"
    '                            _PathLavorazioni = objXMLTR.ReadString
    '                        Case "PathFatture"
    '                            _PathFatture = objXMLTR.ReadString
    '                        Case "PathCtp"
    '                            _PathCTP = objXMLTR.ReadString
    '                        Case "PathJob"
    '                            _PathJob = objXMLTR.ReadString
    '                        Case "PathFileListino"
    '                            _PathFileListino = objXMLTR.ReadString
    '                            'Case "PathTemplate"
    '                            '    _PathTemplate = objXMLTR.ReadString

    '                            'Case "Rilascio"
    '                            '    Rilascio = objXMLTR.ReadString

    '                            'Case "Email"
    '                            '    _Email = objXMLTR.ReadString
    '                            'Case "EmailPwd"
    '                            '    _EmailPwd = objXMLTR.ReadString
    '                            'Case "Pop3Server"
    '                            '    _Pop3Server = objXMLTR.ReadString
    '                            'Case "SmtpServer"
    '                            '    _SmtpServer = objXMLTR.ReadString
    '                            'Case "InviaMail"
    '                            '    _InviaMail = objXMLTR.ReadString
    '                            'Case "CancellaMail"
    '                            '    _CancellaMail = objXMLTR.ReadString

    '                        Case "StampanteConsegnaOrdini"
    '                            _StampanteConsegnaOrdini = objXMLTR.ReadString
    '                        Case "StampanteEtichette"
    '                            _StampanteEtichette = objXMLTR.ReadString
    '                        Case "MargineXEtichette"
    '                            _MargineXEtichette = objXMLTR.ReadString
    '                        Case "MargineYEtichette"
    '                            _MargineYEtichette = objXMLTR.ReadString

    '                            'Case "StampanteFatture"
    '                            '    _StampanteFatture = objXMLTR.ReadString
    '                            'Case "MargineXFatture"
    '                            '    _MargineXFatture = objXMLTR.ReadString
    '                            'Case "MargineYFatture"
    '                            '    _MargineYFatture = objXMLTR.ReadString

    '                            'Case "PortaUdp"
    '                            '    _PortaUDP = objXMLTR.ReadString
    '                            '    'Case "ServerUDP"
    '                            '    '    _ServerUDP = objXMLTR.ReadString
    '                            'Case "AttivaCallerId"
    '                            '    _AttivaCallerId = objXMLTR.ReadString
    '                            'Case "TimeoutCallerId"
    '                            '    _TimeoutCallerId = objXMLTR.ReadString

    '                        Case "NextFat"
    '                            _NextFat = objXMLTR.ReadString
    '                        Case "NextDDT"
    '                            _NextDDt = objXMLTR.ReadString
    '                            'Case "PercIva"
    '                            '    cPercIVA = CInt(objXMLTR.ReadString)

    '                        Case "StampanteLibera"
    '                            _StampanteLibera = objXMLTR.ReadString

    '                        Case "FTPServer"
    '                            _FTPServer = objXMLTR.ReadString
    '                        Case "FTPLogin"
    '                            _FTPLogin = objXMLTR.ReadString
    '                        Case "FTPPwd"
    '                            _FTPPwd = objXMLTR.ReadString

    '                            ' Bartolini
    '                        Case "CodCliBart"
    '                            _CodCliBart = objXMLTR.ReadString

    '                            'Case "Tema"
    '                            '    _ColoreTema = Color.FromArgb(objXMLTR.ReadString)

    '                            'Case "PrimoPiano"
    '                            '    _ColorePrimoPiano = Color.FromArgb(objXMLTR.ReadString)


    '                    End Select

    '                End If
    '            Loop

    '            objXMLTR.Close()

    '        End If

    '        If PathDB.Length <> 0 Then

    '            Ris = True

    '        End If

    '        Return Ris

    '    Catch ex As Exception
    '        ' qui non trova il file ini torna un errore 
    '        ManageError(ex)
    '        Return False

    '    End Try


    'End Function

    'Public Function SaveXml() As Boolean

    '    Dim NomeFile As String = FormerPath.PathLocale & NomeFileIni
    '    'Dim Provider As String = ""
    '    'Dim db As String = ""
    '    Dim enc As System.Text.Encoding


    '    Try

    '        Dim objXMLTW As New XmlTextWriter(NomeFile, enc)

    '        objXMLTW.WriteStartDocument()
    '        'Top level (Parent element)
    '        objXMLTW.WriteStartElement("Paths")
    '        objXMLTW.WriteString(ControlChars.NewLine)


    '        'Child elements, from request form
    '        objXMLTW.WriteStartElement("Generale")
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        'OPZIONI SQL DB
    '        objXMLTW.WriteStartElement("SqlDB")
    '        objXMLTW.WriteString(Postazione.SQLDb)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)
    '        objXMLTW.WriteStartElement("SqlLogin")
    '        objXMLTW.WriteString(Postazione.SqlLogin)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)
    '        objXMLTW.WriteStartElement("SqlPwd")
    '        objXMLTW.WriteString(Postazione.SqlPwd)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)
    '        objXMLTW.WriteStartElement("SqlServerName")
    '        objXMLTW.WriteString(Postazione.SqlServerName)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)
    '        objXMLTW.WriteStartElement("SqlDBName")
    '        objXMLTW.WriteString(Postazione.SqlDbName)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)
    '        'OPZIONI SITO
    '        objXMLTW.WriteStartElement("StrConnWeb")
    '        objXMLTW.WriteString(Postazione.StrConnWeb)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)
    '        objXMLTW.WriteStartElement("FTPServerSito")
    '        objXMLTW.WriteString(Postazione.FTPServerSito)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)
    '        objXMLTW.WriteStartElement("FTPLoginSito")
    '        objXMLTW.WriteString(Postazione.FTPLoginSito)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)
    '        objXMLTW.WriteStartElement("FTPPwdSito")
    '        objXMLTW.WriteString(Postazione.FTPPwdSito)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        ''OPZIONI DB
    '        'objXMLTW.WriteStartElement("PathDB")
    '        'objXMLTW.WriteString(Postazione.PathDB)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("PathTemp")
    '        objXMLTW.WriteString(FormerPath.PathTemp)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("PathCommesse")
    '        objXMLTW.WriteString(FormerPath.PathCommesse)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("PathFatture")
    '        objXMLTW.WriteString(FormerPath.PathFatture)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("PathLavorazioni")
    '        objXMLTW.WriteString(Postazione.PathLavorazioni)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("PathFileListino")
    '        objXMLTW.WriteString(Postazione.PathFileListino)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("PathCtp")
    '        objXMLTW.WriteString(Postazione.PathCtp)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("PathJob")
    '        objXMLTW.WriteString(Postazione.PathJob)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("PathTemplate")
    '        'objXMLTW.WriteString(Postazione.PathTemplate)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("Rilascio")
    '        'objXMLTW.WriteString(Postazione.Rilascio)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'OPZIONI EMAIL
    '        'objXMLTW.WriteStartElement("Email")
    '        'objXMLTW.WriteString(Postazione.Email)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("EmailPwd")
    '        'objXMLTW.WriteString(Postazione.EmailPwd)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("Pop3Server")
    '        'objXMLTW.WriteString(Postazione.Pop3Server)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("SmtpServer")
    '        'objXMLTW.WriteString(Postazione.SmtpServer)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("InviaMail")
    '        'objXMLTW.WriteString(Postazione.InviaMail)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("CancellaMail")
    '        'objXMLTW.WriteString(Postazione.CancellaMail)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("StampanteEtichette")
    '        objXMLTW.WriteString(Postazione.StampanteEtichette)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("MargineXEtichette")
    '        objXMLTW.WriteString(Postazione.MargineXEtichette)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("MargineYEtichette")
    '        objXMLTW.WriteString(Postazione.MargineyEtichette)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("StampanteConsegnaOrdini")
    '        objXMLTW.WriteString(Postazione.StampanteConsegnaOrdini)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("StampanteFatture")
    '        'objXMLTW.WriteString(Postazione.StampanteFatture)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("MargineXFatture")
    '        'objXMLTW.WriteString(Postazione.MargineXFatture)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("MargineYFatture")
    '        'objXMLTW.WriteString(Postazione.MargineyFatture)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("NextFat")
    '        objXMLTW.WriteString(Postazione.NextFat)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("NextDDT")
    '        objXMLTW.WriteString(Postazione.NextDDT)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("PercIva")
    '        'objXMLTW.WriteString(cPercIVA)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("StampanteLibera")
    '        objXMLTW.WriteString(Postazione.StampanteLibera)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        'OPZIONI FTP
    '        objXMLTW.WriteStartElement("FTPServer")
    '        objXMLTW.WriteString(Postazione.FTPServer)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("FTPLogin")
    '        objXMLTW.WriteString(Postazione.FTPLogin)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteStartElement("FTPPwd")
    '        objXMLTW.WriteString(Postazione.FTPPwd)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        'BARTOLINI
    '        objXMLTW.WriteStartElement("CodCliBart")
    '        objXMLTW.WriteString(Postazione.CodCliBart)
    '        objXMLTW.WriteEndElement()
    '        objXMLTW.WriteString(ControlChars.NewLine)


    '        'PortaCom
    '        'objXMLTW.WriteStartElement("PortaUdp")
    '        'objXMLTW.WriteString(Postazione.PortaUDP)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)
    '        ''PortaCom
    '        'objXMLTW.WriteStartElement("ServerUDP")
    '        'objXMLTW.WriteString(Postazione.ServerUDP)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)
    '        'PortaCom
    '        'objXMLTW.WriteStartElement("AttivaCallerId")
    '        'objXMLTW.WriteString(Postazione.AttivaCallerId)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("TimeoutCallerId")
    '        'objXMLTW.WriteString(Postazione.TimeoutCallerId)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)


    '        'COLORE
    '        'objXMLTW.WriteStartElement("Tema")
    '        'objXMLTW.WriteString(Postazione.ColoreTema.ToArgb)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        'objXMLTW.WriteStartElement("PrimoPiano")
    '        'objXMLTW.WriteString(Postazione.ColorePrimoPiano.ToArgb)
    '        'objXMLTW.WriteEndElement()
    '        'objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteEndElement() 'Generale
    '        objXMLTW.WriteString(ControlChars.NewLine)

    '        objXMLTW.WriteEndElement() 'End top level element
    '        objXMLTW.WriteEndDocument() 'End Document
    '        objXMLTW.Flush() 'Write to file
    '        objXMLTW.Close()

    '        Return True

    '    Catch ex As Exception
    '        ' qui non trova il file ini torna un errore 
    '        ManageError(ex)
    '        Return False
    '    End Try

    'End Function

    '#Region "Variabili"

    '    Friend NomeFileIni As String = "settaggi.xml"
    '    'Friend NomeFileExe As String = "nomefile.exe"

    '#End Region

#Region "Property"

    'Private _SqlDB As Boolean = False
    'Friend Property SQLDb() As Boolean
    '    Get
    '        Return _SqlDB
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _SqlDB = value
    '    End Set
    'End Property

    'Private _SqlLogin As String = ""
    'Friend Property SqlLogin() As String
    '    Get
    '        Return _SqlLogin
    '    End Get
    '    Set(ByVal value As String)
    '        _SqlLogin = value
    '    End Set
    'End Property

    'Private _SqlPwd As String = ""
    'Friend Property SqlPwd() As String
    '    Get
    '        Return _SqlPwd
    '    End Get
    '    Set(ByVal value As String)
    '        _SqlPwd = value
    '    End Set
    'End Property

    'Private _SqlServerName As String = ""
    'Friend Property SqlServerName() As String
    '    Get
    '        Return _SqlServerName
    '    End Get
    '    Set(ByVal value As String)
    '        _SqlServerName = value
    '    End Set
    'End Property

    'Private _SqlDbName As String = ""
    'Friend Property SqlDbName() As String
    '    Get
    '        Return _SqlDbName
    '    End Get
    '    Set(ByVal value As String)
    '        _SqlDbName = value
    '    End Set
    'End Property

    'Private _ConnString As String = ""
    'Friend ReadOnly Property ConnString() As String
    '    Get
    '        If SQLDb Then
    '            'Provider=SQLNCLI11;Server=myServerAddress;Database=myDataBase;Trusted_Connection=yes;
    '            _ConnString = "Provider=SQLNCLI11;Server=LUNADIXLAB\SQLEXPRESS;Database=Former;Trusted_Connection=yes;"
    '            '_ConnString = "server=" & _SqlServerName & ";uid=" & _SqlLogin & ";pwd=" & _SqlPwd & ";database=" & _SqlDbName
    '        Else
    '            'ORIGINALE
    '            _ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _PathDb & ";Persist Security Info=False"
    '            '_ConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & _PathDb & ";MaxBufferSize=2048;PageTimeout=5;"


    '        End If

    '        Return _ConnString

    '    End Get
    'End Property

    Private Shared _Rilascio As String = My.Application.Info.Version.Build.ToString
    Public Shared Property Rilascio() As String
        Get
            Return _Rilascio
        End Get
        Set(ByVal value As String)
            _Rilascio = value
        End Set
    End Property

    Public Shared ReadOnly Property Versione() As String
        Get

            Return My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision

        End Get
    End Property

    Public Shared ReadOnly Property Titolo() As String
        Get
            Return Application.ProductName
        End Get
    End Property

    Public Shared ReadOnly Property NomeFileExe() As String
        Get

            Dim Ris As String = FormerLib.FormerHelper.File.EstraiNomeFile(Application.ExecutablePath).ToLower
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property DbInUsoEsercizio As Boolean
        Get
            Dim ris As Boolean = False

            If (ConfigurationManager.ConnectionStrings("FormerDALSql.ConnectionString").ToString.IndexOf("localhost") = -1 And
                ConfigurationManager.ConnectionStrings("FormerDALSql.ConnectionString").ToString.IndexOf("thecell") = -1) Then
                ris = True
            End If

            Return ris
        End Get
    End Property

    'PATH
    'Friend ReadOnly Property PathApplicazione() As String
    '    'torna il path completo di slash finale
    '    Get

    '        Return System.AppDomain.CurrentDomain.BaseDirectory()

    '    End Get
    'End Property

    'Friend ReadOnly Property PathTempLocale As String
    '    Get
    '        Return PathApplicazione & "temp\"
    '    End Get
    'End Property

    'Private _PathDb As String = "" 'esempio "C:\path\archivio.mdb"
    'Friend Property PathDB() As String
    '    Get
    '        'Return _PathDb 
    '        Return "Z:\"
    '    End Get
    '    Set(ByVal value As String)
    '        _PathDb = value
    '    End Set
    'End Property

    'Private _PathCentralizzato As String = "" 'esempio "C:\path\archivio.mdb"
    'Friend ReadOnly Property PathCentralizzato() As String
    '    'torna il path completo di slash finale
    '    Get

    '        Return "Z:\"

    '    End Get
    'End Property

#End Region

#Region "Metodi"

    'Public Shared Sub ScriviLogFile(ByVal NomeFile As String, ByVal Testo As String)

    '    Using objWriter As New System.IO.StreamWriter(NomeFile, True)

    '        objWriter.WriteLine(Testo)

    '        objWriter.Close()
    '    End Using
    'End Sub

    'DATABASE
    'Friend Function ApriConn() As Integer

    '    ' Dim tconnString As String = "Provider=SQLNCLI10;Server=D-LUNADEI-NB\SQLEXPRESS;Database=Former;Trusted_Connection=yes;"
    '    LUNA.LunaContext.GetDbConnection(ConnString)

    '    'Try
    '    '    If _cnOld Is Nothing OrElse _cnOld.State <> ConnectionState.Open Then

    '    '        If SQLDb Then
    '    '            _cnOld = New SqlConnection(ConnString)
    '    '        Else
    '    '            _cnOld = New OleDbConnection(ConnString)
    '    '        End If

    '    '        _cnOld.Open()

    '    '        LUNA.LunaContext.Connection = _cnOld

    '    '        Return 0

    '    '    End If
    '    'Catch ex As Exception
    '    '    'qui c'e' stato un errore quindi non vado avanti e ritorno che non si è riusciti ad aprire la connessione

    '    '    If Not _cnOld Is Nothing Then
    '    '        _cnOld = Nothing
    '    '    End If

    '    '    Return ManageError(ex, ConnString)
    '    'End Try

    'End Function

    'Friend Function ChiudiConn() As Integer
    '    LUNA.LunaContext.CloseDbConnection()
    '    'Try
    '    '    If Not _cnOld Is Nothing OrElse _cnOld.State = ConnectionState.Open Then
    '    '        _cnOld.Close()
    '    '        _cnOld.Dispose()
    '    '        _cnOld = Nothing
    '    '    End If
    '    'Catch ex As Exception

    '    'End Try
    'End Function

    'Public Function EseguiBackup(Optional ByVal NoMsg As Boolean = False) As Integer
    '    'torna 0 se tutto ok 1 se c'e' errore
    '    Try

    '        Dim percorso As String

    '        percorso = FormerPath.PathLocale & "backup\"

    '        CreateLongDir(percorso)


    '        percorso &= Now.Day & Now.Month & Now.Year & ".mdb"

    '        If System.IO.File.Exists(percorso) Then Kill(percorso)

    '        FileIO.FileSystem.FileCopy(Postazione.PathDB, percorso)

    '        If NoMsg = False Then MessageBox.Show("Backup del database eseguito correttamente. Il file di backup si trova in : " & ControlChars.NewLine & percorso, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        Return 0
    '    Catch ex As Exception
    '        ManageError(ex)
    '        Return 1
    '    End Try


    'End Function

    'AGGIORNAMENTO AUTOMATICO DEL PROGRAMMA
    'Friend Function AggiornaProgramma(ByVal formRif As Windows.Forms.Form, Optional ByVal ContrAgg As Boolean = False) As Boolean

    '    Dim x As New frmOpzioni, ris As Boolean

    '    Sottofondo(formRif)

    '    ris = x.Carica(ContrAgg)

    '    Sottofondo(formRif)

    '    x = Nothing

    '    If ris Then

    '        MessageBox.Show("Il programma verrà ora riavviato automaticamente!", Postazione.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        Application.Restart()

    '    End If

    '    Return ris

    'End Function

    'Friend Function CaricaAggiornamenti() As LiveUpdate.cRilasci

    '    CreaCartella("update")
    '    Dim path As String = FormerPath.PathLocale & "update\update.xml"
    '    If System.IO.FilePath.Exists(path) Then Kill(path)

    '    Dim x As New LiveUpdate.cRilasci

    '    x.GetAggiornamenti()
    '    Return x

    'End Function

    'Public Function NuoviAggiornamentiDisponibili() As Boolean

    '    Dim Ris As Boolean = False
    '    Dim Ult As DCLibrary.LiveUpdate.cRilasci

    '    Ult = CaricaAggiornamenti()

    '    If Ult.LastRilascioId > Postazione.Rilascio Then Ris = True

    '    Return Ris

    'End Function


    'Friend Sub AggiornaFile(ByVal idRil As Integer, ByVal NomeOutput As String)

    '    Dim PercorsoDest As String
    '    Dim xs As System.IO.FilePath

    '    If NomeOutput.ToLower = NomeFileExe.ToLower Or NomeOutput.EndsWith(".dll") Then

    '        Dim pathNew As String = System.AppDomain.CurrentDomain.BaseDirectory() & NomeOutput & ".bak"
    '        Dim pathExe As String = System.AppDomain.CurrentDomain.BaseDirectory() & NomeOutput
    '        Dim pathOld As String = System.AppDomain.CurrentDomain.BaseDirectory() & NomeOutput & ".old"

    '        Dim x As New FileInfo(pathExe)

    '        Dim file As New FileIO.FileSystem

    '        If xs.Exists(pathOld) Then file.DeleteFile(pathOld, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
    '        x.MoveTo(pathOld)
    '    End If

    '    PercorsoDest = PathApplicazione & NomeOutput

    '    CreateLongDir(PercorsoDest)
    '    'copia i file dalla cartella di rilascio a quella 

    '    'System.IO.FilePath.Copy("update\" & idRil & "\" & NomeOutput, PercorsoDest, True)

    '    System.IO.FilePath.Copy(FormerPath.PathLocale & "update\" & idRil & "\" & NomeOutput, PercorsoDest, True)

    '    'se si tratta di file .sql eseguo la query contenuta all'interno
    '    If NomeOutput.EndsWith(".txt") Then
    '        'qui lancio un aggiornamento sul db

    '        Dim sw As New StreamReader(NomeOutput, System.Text.Encoding.ASCII)

    '        Dim ContentFile As String = ""

    '        While sw.Peek <> -1
    '            ContentFile = sw.ReadLine()

    '            If ContentFile.Length Then

    '                Dim UpdateCommand As OleDbCommand = New OleDbCommand()
    '                UpdateCommand.Connection = _cnOld
    '                'UpdateCommand.Transaction = transazione

    '                UpdateCommand.CommandText = ContentFile
    '                Try 'qui se va in errore vado avanti perche potrebbe essere una multipostazione e l'errore e' dato dall'aggiornamento sul db gia fatto da un altra postazione
    '                    UpdateCommand.ExecuteReader()
    '                Catch ex As Exception

    '                End Try

    '            End If
    '        End While

    '        sw.Close()
    '        sw = Nothing

    '    End If

    'End Sub

    'Friend Sub DownloadFile(ByVal percorsoweb As String, ByVal NomeOutput As String)
    '    'Try

    '    Dim wr As HttpWebRequest = CType(WebRequest.Create(percorsoweb), HttpWebRequest)
    '    Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
    '    Dim str As Stream = ws.GetResponseStream()
    '    Dim inBuf(10000000) As Byte
    '    Dim bytesToRead As Integer = CInt(inBuf.Length)
    '    Dim bytesRead As Integer = 0
    '    While bytesToRead > 0
    '        Dim n As Integer = str.Read(inBuf, bytesRead, bytesToRead)
    '        If n = 0 Then
    '            Exit While
    '        End If
    '        bytesRead += n
    '        bytesToRead -= n
    '    End While

    '    CreateLongDir(NomeOutput)

    '    If System.IO.File.Exists(PathApplicazione & NomeOutput) Then Kill(PathApplicazione & NomeOutput)

    '    Dim fstr As New FileStream(PathApplicazione & NomeOutput, FileMode.OpenOrCreate, FileAccess.Write)
    '    fstr.Write(inBuf, 0, bytesRead)

    '    fstr.Close()

    '    str.Close()
    '    'Catch ex As Exception
    '    '    ManageError(ex, "DownloadFile")
    '    'End Try

    'End Sub

    'ALTRO


#End Region

End Class

