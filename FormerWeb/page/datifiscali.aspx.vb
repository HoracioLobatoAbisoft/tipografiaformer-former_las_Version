Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class pDatiFiscali
    Inherits FormerSecurePage

    Private Sub myFormer_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If UtenteConnesso.Utente.IdRubricaInt Then
                lblIdCli.Text = UtenteConnesso.Utente.IdRubricaInt
            Else
                lblIdCli.Text = "-"
            End If

            lblEmail.Text = Server.HtmlEncode(UtenteConnesso.Utente.Email)
            lblRagSoc.Text = Server.HtmlEncode(UtenteConnesso.Utente.RagSoc)
            lblNominativo.Text = Server.HtmlEncode(UtenteConnesso.Utente.Nome & " " & UtenteConnesso.Utente.Cognome)
            lblPiva.Text = Server.HtmlEncode(UtenteConnesso.Utente.PIvaStr)
            lblCodFisc.Text = Server.HtmlEncode(UtenteConnesso.Utente.CodFisc)
            txtPec.Text = Server.HtmlEncode(UtenteConnesso.Utente.Pec)
            txtSDI.Text = Server.HtmlEncode(UtenteConnesso.Utente.CodiceSDI)

            If Carrello.Ordini.Count > 0 Then
                lnkModDati.Text = "SALVA E PROSEGUI"
            End If

        End If

    End Sub

    Private Function ModuloValido() As String

        Dim ris As String = String.Empty
        'Dim ClientePrivato As Boolean = True

        'If UtenteConnesso.Utente.TipoRub = enTipoRubrica.Rivenditore Then
        '    ClientePrivato = False
        'Else
        '    If UtenteConnesso.Utente.Piva.Length Then
        '        ClientePrivato = False
        '    End If
        'End If

        'If ClientePrivato = False Then
        '    If txtPec.Text.Trim.Length = 0 AndAlso txtSDI.Text.Trim.Length = 0 Then
        '        ris &= "<li>Inserire la PEC o il Codice SDI</li>"
        '    End If
        'End If

        If txtPec.Text.Trim.Length > 0 Then
            If FormerHelper.Mail.IsValidEmailAddress(txtPec.Text) = False Then
                ris &= "<li>L'indirizzo Email PEC non sembra corretto</li>"
            End If
        End If
        If txtSDI.Text.Length > 0 AndAlso txtSDI.Text.Length <> 7 Then
            ris &= "<li>Il Codice SDI non sembra corretto</li>"
        End If

        If ris.Length Then
            ris = "<b>ATTENZIONE</b><ul>" & ris & "</ul>"
        End If

        Return ris

    End Function

    Private Sub lnkModDati_Click(sender As Object, e As EventArgs) Handles lnkModDati.Click

        Dim RisVal As String = ModuloValido()

        If RisVal = String.Empty Then

            pnlErrore.Visible = False

            UtenteConnesso.Utente.Pec = txtPec.Text
            UtenteConnesso.Utente.CodiceSDI = txtSDI.Text
            UtenteConnesso.Utente.UpdateFromUser = enSiNo.Si
            UtenteConnesso.Utente.Save()

            If Carrello.Ordini.Count > 0 Then
                Session("GiaChiestoAggiornamentoDF") = True
                Response.Redirect("/carrello-riepilogo")
            Else
                Response.Redirect("/i-tuoi-dati")
            End If

        Else

            lblErrore.Text = RisVal
            pnlErrore.Visible = True

        End If

    End Sub

End Class