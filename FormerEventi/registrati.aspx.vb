Imports FormerDALEventi

Public Class registrati
    Inherits EventiPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Function IsValidEmailAddress(Email As String) As Boolean

        Dim ris As Boolean = False

        Email = Email.Trim

        Dim RegExpres As String = ""

        'RegExpres = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        RegExpres = "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"
        'RegExpres = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.[A-Za-z][A-Za-z\.]*[A-Za-z]$"
        'RegExpres = "^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$"
        'Dim r As New Regex(RegExpres)

        If Regex.IsMatch(Email, RegExpres, RegexOptions.IgnoreCase) Then
            ris = True
            Dim Pos As Integer = Email.LastIndexOf(".")
            Dim DomExt As String = Email.Substring(Pos + 1)
            For Each car As Char In DomExt
                If Char.IsLetter(car) = False Then
                    ris = False
                    Exit For
                End If
            Next
        End If

        Return ris

    End Function

    Private Sub btnRegistra_Click(sender As Object, e As EventArgs) Handles btnRegistra.Click

        Dim ErrMsg As String = String.Empty

        If txtRagSoc.Text.Trim.Length = 0 Then
            ErrMsg &= "<li>Inserire la Ragione Sociale</li>"
        End If

        If txtEmail.Text.Trim.Length = 0 Then
            ErrMsg &= "<li>Inserire l' email</li>"
        Else
            If IsValidEmailAddress(txtEmail.Text) = False Then
                ErrMsg &= "<li>Inserire una email valida</li>"
            End If
        End If

        If ErrMsg.Length = 0 Then

            Try
                Using mgr As New ContattiDAO
                    Dim l As List(Of Contatto) = mgr.FindAll(New LUNA.LunaSearchParameter("Email", txtEmail.Text))

                    If l.Count = 0 Then
                        Using c As New Contatto
                            c.Cellulare = txtCellulare.Text
                            c.Email = txtEmail.Text
                            c.Nominativo = txtNominativo.Text
                            c.RagSoc = txtRagSoc.Text
                            c.DataIns = Now
                            c.Tag = ConfigurationManager.AppSettings("TagEvento")
                            c.Save()

                            'qui posso inviare una mail 

                        End Using

                    End If

                End Using

                Response.Redirect("/grazie")
            Catch ex As Exception
                lblErrore.Text = "Si è verificato un errore, riprova"
                pnlErrore.Visible = True
            End Try

        Else
            lblErrore.Text = ErrMsg
            pnlErrore.Visible = True
        End If

    End Sub
End Class