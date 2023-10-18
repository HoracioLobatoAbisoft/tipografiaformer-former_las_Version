Public Class pRichiediCampione
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("PageTitle") = "Richiedi un Campione Gratuito"

        If Not IsPostBack Then

            If Not Session("CampioneRichiesto") Is Nothing Then
                lblCampione.Text = Session("CampioneRichiesto")
            Else
                Response.Redirect("/")
            End If



        End If

    End Sub

    Private Sub imgRichiedi_Click(sender As Object, e As ImageClickEventArgs) Handles imgRichiedi.Click

        'invio la mail con la richiesta

        Dim TitMail As String = "Richiesta Campione Gratuito"
        Dim Testomail As String = "E' stato richiesto un campione gratuito di:<br><br> "

        Testomail &= "<b>" & Session("CampioneRichiesto") & "</b>"

        Testomail &= "<br><br>Da : "

        Testomail &= "<br><br>Rag.Soc. <b>" & UtenteConnesso.Utente.RagSoc & " </b>(Id:" & UtenteConnesso.IdUtente & ", IdInt:" & UtenteConnesso.IdRubricaInt & ")<br>"
        Testomail &= "Nominativo <b>" & UtenteConnesso.Utente.Nome & " " & UtenteConnesso.Utente.Cognome & "</b><br><br>"
        Testomail &= "Indirizzo: <b>" & UtenteConnesso.Utente.Indirizzo & ", " & UtenteConnesso.Utente.Cap & " - " & UtenteConnesso.Utente.Citta & "</b><br><br>"
        Testomail &= "Email: <b>" & UtenteConnesso.Utente.Email & "</b><br><br>"
        Testomail &= "Telefono: <b>" & UtenteConnesso.Utente.Tel & "</b><br><br>"
        Testomail &= "Cellulare: <b>" & UtenteConnesso.Utente.Cellulare & "</b><br><br>"

        FormerLib.FormerHelper.Mail.InviaMail(TitMail, Testomail, "info@tipografiaformer.it")

        Response.Redirect("/richiesta-campione-gratuito-registrata")


    End Sub
End Class