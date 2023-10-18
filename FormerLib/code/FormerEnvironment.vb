Public Class FormerEnvironment

    Public Shared Property LastDaemonPing As Date = Date.MinValue

    Public Shared Function ISServiceUp() As Boolean

        Dim ris As Boolean = False

        If FormerLib.FormerHelper.Web.IsPingable(FormerConfig.FConfiguration.Environment.DaemonServer) Then

            'qui controllare se il demone e' attivo
            Dim diff As Integer = 0

            Try
                If FormerEnvironment.LastDaemonPing <> Date.MinValue Then
                    diff = DateDiff(DateInterval.Second, FormerEnvironment.LastDaemonPing, Now)
                Else
                    diff = 61
                End If

            Catch ex As Exception

            End Try

            If diff < 60 Then
                ris = True
            End If

        End If

        Return ris

    End Function

End Class
