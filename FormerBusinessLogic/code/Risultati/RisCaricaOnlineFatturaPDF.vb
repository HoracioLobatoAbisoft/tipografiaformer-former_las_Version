Public Class RisCaricaOnlineFatturaPDF

    Public Enum enExitCode
        Ok
        FileLocaleNonPresente
        FileOnlineGiaPresente
        ErroreNellaFaseDiUpload
    End Enum

    Public Property IdConsegnaInterna As Integer = 0
    Public Property IdConsegnaOnline As Integer = 0

    Public Property ExitCode As enExitCode = enExitCode.Ok

End Class
