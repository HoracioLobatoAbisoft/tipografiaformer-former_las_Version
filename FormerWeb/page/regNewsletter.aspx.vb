Imports FormerLib
Imports FormerDALWeb
Public Class pRegNewsletter
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

                    'prima controllo un po di cose e poi lo registro per la newsletter
                    Try
                        Using mgr As New NewsletterDAO
                            Dim l As List(Of Newsletter) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Newsletter.Email, email))
                            If l.Count = 0 Then
                                'non è gia iscritto alla newsletter 
                                'devo vedere se e' gia iscritto al sito ?
                                'salvo comunque l'iscirziopne e poi la lavoro in caso per togliere l'unsubscribe

                                Using N As New Newsletter
                                    N.Ip = UtenteConnesso.IpUtente
                                    N.Quando = Now
                                    N.Email = email
                                    N.Save()
                                    'N.e
                                End Using
                            End If
                            Ris = "Iscrizione alla nostra Newsletter confermata, da oggi riceverai le nostre offerte e promozioni."
                        End Using
                    Catch ex As Exception
                        Ris = "Si è verificato un problema nell'iscrizione alla newsletter, riprova più tardi"
                    End Try

                    'qui devo registrarlo effettivamente per la newsletter

                    ''qui ho l'email 
                    'Using u As New UtentiDAO
                    '    Dim l As List(Of Utente) = u.FindAll(New LUNA.LunaSearchParameter("Email", email))
                    '    If l.Count = 1 Then
                    '        Dim Pwd As String = FormerHelper.Security.GeneraPassword()
                    '        Dim PwdHash As String = FormerHelper.Security.GetMd5Hash(Pwd)
                    '        Dim Ut As Utente = l(0)
                    '        Ut.PasswordHash = PwdHash
                    '        Ut.Save()

                    '        Dim Pt As New My.Templates.MailPwdChanged
                    '        Pt.Pwd = Pwd
                    '        Dim Buffer As String = Pt.TransformText

                    '        Try
                    '            FormerHelper.Mail.InviaMail("La tua nuova Password su TipografiaFormer.it", Buffer, Ut.Email, _
                    '                                        , , , , )
                    '        Catch ex As Exception

                    '        End Try
                    '        Ris = "La tua nuova password è stata inviata alla tua email!"
                    '    Else
                    '        Ris = "La rigenerazione della password non può essere effettuata perchè l'email non è valida"
                    '    End If
                    'End Using

                Else
                    Ris = "Richiesta di iscrizione alla newsletter non valida"
                End If
            Else
                Ris = "Richiesta di iscrizione alla newsletter non valida"
            End If
            lblEsito.Text = Ris
        End If


    End Sub

End Class