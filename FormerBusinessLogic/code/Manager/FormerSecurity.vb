Imports FormerDALSql

Public Class FormerSecurity
    'System.Environment.MachineName

    Public Shared Sub RegistraLogOut(IdUt As Integer,
                                     Optional Postazione As String = "")
        Using mgr As New LoginDAO
            mgr.DeleteByIdUt(IdUt, Postazione)
        End Using
    End Sub

    Public Shared Function RegistraLogin(IdUt As Integer) As Integer
        Dim RegistratoLogin As Integer = 0
        Dim ris As New RisUserLogged
        ris = IsUserLogged(IdUt)
        Using L As New Login
            If ris.IdLogin Then
                L.Read(ris.IdLogin)
            End If
            L.Quando = Now
            L.Postazione = System.Environment.MachineName
            L.IdUt = IdUt
            L.Versione = My.Application.Info.Version.ToString
            L.Save()
            RegistraLogin = L.IdLogin
        End Using

        Return RegistraLogin

    End Function

    Public Shared Function IsUserLogged(IdUt As Integer) As RisUserLogged

        Dim ris As New RisUserLogged

        Using mgr As New LoginDAO
            Dim l As List(Of Login) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Login.IdUt, IdUt))

            If l.Count Then
                Dim loggato As Login = l(0)

                ris.IdLogin = loggato.IdLogin
                ris.IdUt = loggato.IdUt
                ris.DaQuando = loggato.Quando
                ris.IsLogged = True
                ris.Postazione = loggato.Postazione

            End If

        End Using

        Return ris

    End Function

End Class
