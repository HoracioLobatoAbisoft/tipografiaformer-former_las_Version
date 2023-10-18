Public Class FormerPath

    Public Shared ReadOnly Property PathLocale() As String
        'torna il path completo di slash finale
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory()
        End Get
    End Property

    Public Shared ReadOnly Property PathCentralizzato() As String
        'torna il path completo di slash finale
        Get
            Return "Z:\"
        End Get
    End Property

    Public Shared ReadOnly Property PathPreps8 As String
        Get
            Dim ris As String = FConfiguration.Path.Preps8  ' ConfigurationManager.AppSettings("PathLog")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathLog As String
        Get
            Dim ris As String = FConfiguration.Path.Log ' ConfigurationManager.AppSettings("PathLog")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathGanging As String
        Get
            Dim ris As String = "C:\Ganging\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathOrdiniDaVerificare As String
        Get
            Dim ris As String = "O:\OrdiniDaVerificare\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathArchivioOrdini As String
        Get
            Dim ris As String = "O:\OrdiniArchiviati\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathLogCoupon As String
        Get
            Dim ris As String = FConfiguration.Path.LogCoupon ' ConfigurationManager.AppSettings("PathLog")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathRefineStart As String
        Get
            Dim ris As String = FConfiguration.Path.RefineStart ' ConfigurationManager.AppSettings("PathLog")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathRefineSuccess As String
        Get
            Dim ris As String = FConfiguration.Path.RefineSuccess ' ConfigurationManager.AppSettings("PathLog")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathRefineError As String
        Get
            Dim ris As String = FConfiguration.Path.RefineError ' ConfigurationManager.AppSettings("PathLog")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathRefineWarning As String
        Get
            Dim ris As String = FConfiguration.Path.RefineWarning  ' ConfigurationManager.AppSettings("PathLog")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathRefineCancelled As String
        Get
            Dim ris As String = FConfiguration.Path.RefineCancelled  ' ConfigurationManager.AppSettings("PathLog")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathRefineResult As String
        Get
            Dim ris As String = FConfiguration.Path.RefineResult  ' ConfigurationManager.AppSettings("PathLog")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathLogConsegne As String
        Get
            Dim ris As String = PathLog.ToLower.Replace("log", "log-consegne")
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathBug As String
        Get
            Dim ris As String = PathLog.ToLower.Replace("log", "bug")
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathLogInvalidati As String
        Get
            Dim ris As String = PathLog.ToLower.Replace("log", "log-invalidati")
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathLogPostazioni As String
        Get
            Dim ris As String = PathLog.ToLower.Replace("log", "log-postazioni")
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathAttachMailPrev As String
        Get
            Dim ris As String = PathLog.ToLower.Replace("log", "preventivi")
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathProcedure As String
        Get
            Dim ris As String = PathLog.ToLower.Replace("log", "procedure")
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathLogRubrica As String
        Get
            Dim ris As String = PathLog.ToLower.Replace("log", "log-rubrica")
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathTemp As String
        Get
            Dim ris As String = FConfiguration.Path.Temp ' ConfigurationManager.AppSettings("PathTemp")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathTemplateGanging As String
        Get
            Dim ris As String = FConfiguration.Path.TemplateGanging ' ConfigurationManager.AppSettings("PathTemp")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathTempLocale As String
        Get

            Dim pathRis As String = PathLocale & "temp\"

            If IO.Directory.Exists(pathRis) = False Then
                Try
                    IO.Directory.CreateDirectory(pathRis)
                Catch ex As Exception

                End Try

            End If

            Return pathRis
        End Get
    End Property

    Public Shared ReadOnly Property PathTempImg As String
        Get
            Return PathLocale & "temp-img\"
        End Get
    End Property

    Public Shared ReadOnly Property PathCommesse As String
        Get
            Dim ris As String = FConfiguration.Path.Commesse ' ConfigurationManager.AppSettings("PathCommesse")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathTemplate As String
        Get
            Dim ris As String = FConfiguration.Path.Template ' ConfigurationManager.AppSettings("PathTemplate")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathBannerSito() As String
        Get
            Dim Ris As String = FConfiguration.Path.BannerSito ' ConfigurationManager.AppSettings("PathBannerSito")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property


    Public Shared ReadOnly Property PathFattureTemp() As String
        Get
            Dim Ris As String = FConfiguration.Path.Fatture ' ConfigurationManager.AppSettings("PathFatture")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Ris &= "temp\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFatture(IdAzienda As Integer) As String
        Get
            Dim Ris As String = FConfiguration.Path.Fatture ' ConfigurationManager.AppSettings("PathFatture")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Ris &= IdAzienda & "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFattureAcquisto() As String
        Get
            Dim Ris As String = FConfiguration.Path.FattureAcquisto ' ConfigurationManager.AppSettings("PathFattureAcquisto")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFileListino() As String
        Get
            Dim Ris As String = FConfiguration.Path.FileListino ' ConfigurationManager.AppSettings("PathFileListino")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathListinoImg As String
        Get
            Return PathFileListino & "img\"
        End Get
    End Property

    Public Shared ReadOnly Property PathListinoFoto As String
        Get
            Return PathFileListino & "foto\"
        End Get
    End Property

    Public Shared ReadOnly Property PathListinoTemplate As String
        Get
            Return PathFileListino & "template\"
        End Get
    End Property

    Public Shared ReadOnly Property PathCTP() As String
        Get
            Dim Ris As String = FConfiguration.Path.CTP ' ConfigurationManager.AppSettings("PathCTP")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFileDigitale() As String
        Get
            Dim Ris As String = FConfiguration.Path.FileDigitale  ' ConfigurationManager.AppSettings("PathFileDigitale")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFileRifiutati() As String
        Get
            Dim Ris As String = FConfiguration.Path.FileRifiutati  ' ConfigurationManager.AppSettings("PathFileRifiutati")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathBkpFile() As String
        Get
            Dim Ris As String = FConfiguration.Path.BkpFile ' ConfigurationManager.AppSettings("PathJOB")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathNewVer() As String
        Get
            Dim Ris As String = FConfiguration.Path.NewVer ' ConfigurationManager.AppSettings("PathJOB")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathLogWeb() As String
        Get
            Dim Ris As String = FConfiguration.Path.LogWeb  ' ConfigurationManager.AppSettings("PathJOB")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFattureFE() As String
        Get
            Dim Ris As String = FConfiguration.Path.FattureFE  ' ConfigurationManager.AppSettings("PathJOB")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFileBianco() As String
        Get
            Dim Ris As String = FConfiguration.Path.FileBianco  ' ConfigurationManager.AppSettings("PathJOB")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathSorgentiHCC() As String
        Get
            Dim Ris As String = FConfiguration.Path.SorgentiHCC ' ConfigurationManager.AppSettings("PathJOB")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathSorgentiHCC35x50() As String
        Get
            Dim Ris As String = FConfiguration.Path.SorgentiHCC35x50 ' ConfigurationManager.AppSettings("PathJOB")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathHCC() As String
        Get
            Dim Ris As String = FConfiguration.Path.HCC ' ConfigurationManager.AppSettings("PathJOB")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFileLastUser As String
        Get
            Dim ris As String = PathLocale & "lastuser.txt"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathSorgentiRiOrdinoRisorse() As String
        Get
            Dim Ris As String = FConfiguration.Path.SorgentiRiOrdinoRisorse ' ConfigurationManager.AppSettings("PathJOB")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathTemplateMarketing() As String
        Get
            Return PathCentralizzato & "TemplateMarketing\"
        End Get
    End Property

    Public Shared ReadOnly Property PathTemplatePreps() As String
        Get
            Return PathCentralizzato & "template preps\"
        End Get
    End Property
    Public Shared ReadOnly Property PathTemplateEmailMarketingSorgenti() As String
        Get
            Return PathCentralizzato & "FormerEsercizio\TemplateEmailSorgenti"
        End Get
    End Property

    Public Shared ReadOnly Property PathEmail() As String
        Get
            Return PathCentralizzato & "FormerEmail\"
        End Get
    End Property

    Public Shared ReadOnly Property PathImgRisorse() As String
        Get
            Return PathCentralizzato & "FormerEsercizio\ImgRisorse\"
        End Get
    End Property

    Public Shared ReadOnly Property PathStampaTemp() As String
        Get
            Return PathLocale & "stampatemp\"
        End Get
    End Property

    Public Shared ReadOnly Property PathSound() As String
        Get
            Return PathLocale & "sound\"
        End Get
    End Property

    Public Class HotFolder
        Public Shared ReadOnly Property CreazioneAnteprimaPDFfromJOB As String
            Get
                Dim ris As String = FConfiguration.Path.HotFolderCreazioneAnteprimaPDFfromJOB
                Return ris
            End Get
        End Property
    End Class

End Class
