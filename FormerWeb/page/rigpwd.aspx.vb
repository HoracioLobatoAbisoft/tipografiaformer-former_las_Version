Imports FormerLib
Imports FormerDALWeb
Public Class pRigPwd
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim Ris As String = ""
            Dim emailCrypt As String = Convert.ToString(Page.RouteData.Values("email"))

            If emailCrypt.Length Then
                Dim email As String = FormerHelper.Security.DecriptaURL(emailCrypt)
                'qui levo i primi 9 caratteri
                If email.Length > 8 Then
                    email = email.Substring(8)
                    'qui ho l'email 
                    Using u As New UtentiDAO
                        Dim l As List(Of Utente) = u.FindAll(New LUNA.LunaSearchParameter(LFM.Utente.Email, email))
                        If l.Count = 1 Then
                            Dim Pwd As String = FormerHelper.Security.GeneraPassword()
                            Dim PwdHash As String = FormerHelper.Security.GetMd5Hash(Pwd)
                            Dim Ut As Utente = l(0)
                            Ut.PasswordHash = PwdHash
                            Ut.Save()

                            Dim Pt As New My.Templates.MailPwdChanged
                            Pt.Pwd = Pwd
                            Dim Buffer As String = Pt.TransformText

                            Try
                                FormerHelper.Mail.InviaMail("La tua nuova Password su TipografiaFormer.it", Buffer, Ut.Email, _
                                                            , , , , )
                            Catch ex As Exception

                            End Try
                            Ris = "La tua nuova password è stata inviata alla tua email!"
                        Else
                            Ris = "La rigenerazione della password non può essere effettuata perchè l'email non è valida"
                        End If
                    End Using
                Else
                    Ris = "Richiesta di rigenerazione della password non valida"
                End If
            Else
                Ris = "Richiesta di rigenerazione della password non valida"
            End If
            lblEsito.Text = Ris
        End If


    End Sub

End Class