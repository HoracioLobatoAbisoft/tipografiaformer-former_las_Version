Imports System.Configuration

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

    Public Shared ReadOnly Property PathLog As String
        Get
            Dim ris As String = ConfigurationManager.AppSettings("PathLog")
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

    Public Shared ReadOnly Property PathLogRubrica As String
        Get
            Dim ris As String = PathLog.ToLower.Replace("log", "log-rubrica")
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathTemp As String
        Get
            Dim ris As String = ConfigurationManager.AppSettings("PathTemp")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathTempLocale As String
        Get
            Return PathLocale & "temp\"
        End Get
    End Property

    Public Shared ReadOnly Property PathTempImg As String
        Get
            Return PathLocale & "temp-img\"
        End Get
    End Property

    Public Shared ReadOnly Property PathCommesse As String
        Get
            Dim ris As String = ConfigurationManager.AppSettings("PathCommesse")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathTemplate As String
        Get
            Dim ris As String = ConfigurationManager.AppSettings("PathTemplate")
            If ris.EndsWith("\") = False Then ris &= "\"
            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PathBannerSito() As String
        Get
            Dim Ris As String = ConfigurationManager.AppSettings("PathBannerSito")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFatture() As String
        Get
            Dim Ris As String = ConfigurationManager.AppSettings("PathFatture")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFattureAcquisto() As String
        Get
            Dim Ris As String = ConfigurationManager.AppSettings("PathFattureAcquisto")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFileListino() As String
        Get
            Dim Ris As String = ConfigurationManager.AppSettings("PathFileListino")
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
            Dim Ris As String = ConfigurationManager.AppSettings("PathCTP")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFileDigitale() As String
        Get
            Dim Ris As String = ConfigurationManager.AppSettings("PathFileDigitale")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathFileRifiutati() As String
        Get
            Dim Ris As String = ConfigurationManager.AppSettings("PathFileRifiutati")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathJOB() As String
        Get
            Dim Ris As String = ConfigurationManager.AppSettings("PathJOB")
            If Ris.EndsWith("\") = False Then Ris &= "\"
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PathTemplateMarketing() As String
        Get
            Return PathCentralizzato & "TemplateMarketing\"
        End Get
    End Property

    Public Shared ReadOnly Property PathEmail() As String
        Get
            Return PathCentralizzato & "FormerEmail\"
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

End Class
