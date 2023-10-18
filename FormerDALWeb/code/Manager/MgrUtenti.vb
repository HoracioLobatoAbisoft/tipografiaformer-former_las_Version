Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrUtenti

    Public Shared Function Login(ByVal Id As String) As UtenteSito

        'LOGIN DAL COOKIE
        Dim Ris As New UtenteSito
        Using u As New UtentiDAO
            Dim l As List(Of Utente) = u.FindAll(New LUNA.LunaSearchParameter("IdUt", Id))
            If l.Count Then
                Ris.Utente = l(0)
                Ris.Utente.LastLogin = Now
                Ris.Utente.LastIp = Ris.IpUtente
                Ris.Utente.AggiornaLogin(Now, Ris.IpUtente)
                'Ris.Utente.Save()
            End If
        End Using
        Return Ris

    End Function

    Private Shared Function RealLogin(ByVal Id As String, ByVal Chiave As String) As Utente

        Id = Id.Trim
        Chiave = Chiave.Trim

        Dim Ris As Utente = Nothing
        Dim PwdHash As String = FormerHelper.Security.GetMd5Hash(Chiave)
        Dim LoginPar As LUNA.LunaSearchParameter = Nothing

        If IsNumeric(Id) Then 'sta facendo login dall'id 
            LoginPar = New LUNA.LunaSearchParameter(LFM.Utente.IdRubricaInt, Id)
        Else 'sta facendo login dalla email
            If Id <> FormerLib.FormerConst.EmailNonDisponibile Then
                LoginPar = New LUNA.LunaSearchParameter(LFM.Utente.Email, Id)
            End If
        End If

        If Not LoginPar Is Nothing Then
            Using U As New UtentiDAO
                Dim l As List(Of Utente) = U.FindAll(LoginPar, New LUNA.LunaSearchParameter(LFM.Utente.PasswordHash, PwdHash))
                If l.Count = 1 Then
                    Ris = l(0)

                    If Ris.DisattivaAccessoSito = enSiNo.Si Then
                        'se accesso disattivato lo blocco
                        Ris = Nothing
                    End If
                End If
            End Using
        End If

        Return Ris
    End Function

    'Private Shared Function OldRealLogin(ByVal Id As String, ByVal Chiave As String) As Boolean

    '    '***************************
    '    'QUI EFFETTUO IL LOGIN REALE PER ORA CALCOLATO
    '    '***************************

    '    Dim LoginOk As Boolean = False



    '    If IsNumeric(Id) Then 'sta facendo login dall'id 
    '        Dim ChiaveConfr As String = Chiave
    '        'per ora abilito solo l'accesso ai rivenditori
    '        If ChiaveConfr.StartsWith("@A") Then
    '            ChiaveConfr = ChiaveConfr.Substring(2)
    '        End If
    '        If FormerHelper.Security.CalcolaChiave(Id) = ChiaveConfr Then
    '            LoginOk = True
    '        End If
    '    End If

    '    Return LoginOk
    'End Function

    Public Shared Function Login(ByVal Id As String, ByVal Chiave As String) As UtenteSito

        Dim Ris As New UtenteSito
        Dim UtRis As Utente = RealLogin(Id, Chiave)

        If Not UtRis Is Nothing Then
            Ris.Utente = UtRis
            Ris.Utente.LastLogin = Now
            Ris.Utente.LastIp = Ris.IpUtente
            Ris.Utente.Save()
        End If

        Return Ris

    End Function

    Public Class Listini

        Public Shared Sub RegistraAccesso(IdUt As Integer,
                                          PercDefaultRicarico As Integer)
            Using mgr As New ListiniUtenteWDAO
                Dim l As List(Of ListinoUtenteW) = mgr.FindAll(New LUNA.LunaSearchParameter("IdUt", IdUt))

                Dim lisUt As ListinoUtenteW = Nothing

                If l.Count = 0 Then
                    lisUt = New ListinoUtenteW
                    lisUt.IdUt = IdUt
                    lisUt.PercDefault = PercDefaultRicarico
                Else
                    lisUt = l(0)
                End If
                lisUt.UltimoAccesso = Now

                lisUt.Save()

            End Using
        End Sub

    End Class


End Class
