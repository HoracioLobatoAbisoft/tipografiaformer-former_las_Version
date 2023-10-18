Public Class FormerDebug

    Public Shared ReadOnly Property LightMode As Boolean
        Get
            Dim ris As Boolean = False
            Return ris
        End Get
    End Property

    Public Shared Property DebugAttivo As Boolean
        Get
            Dim ris As Boolean = False
            Dim risStr As String = Environment.GetEnvironmentVariable("DebugAttivo", EnvironmentVariableTarget.Process)
            If risStr = "True" Then
                ris = True
            End If
            Return ris
        End Get
        Set(value As Boolean)
            Environment.SetEnvironmentVariable("DebugAttivo", value)
        End Set
    End Property

End Class
