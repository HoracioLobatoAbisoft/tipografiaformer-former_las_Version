Imports FormerDALWeb
Imports System.IO
Imports System.Drawing
Imports FormerLib

Public Class pContattaci
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CaricaCat()
            CreaCap()
        End If
    End Sub

    Private Sub CreaCap()

        Dim R As New Random
        Randomize()
        Dim Prox As Integer = R.Next(1000, 9999)

        Session("cap") = Prox
        imgCap.ImageUrl = GeneraCap(Prox)


    End Sub

    Private Sub CaricaCat()

        Dim l As List(Of Argomento)
        Using cM As New ArgomentiDAO
            l = cM.GetAll("Ordine")
        End Using

        lstCat.DataSource = l
        lstCat.DataBind()

        Dim IdA As Integer = Convert.ToInt32(Page.RouteData.Values("ida"))
        Dim IdD As Integer = Convert.ToInt32(Page.RouteData.Values("idd"))

        l.Add(New Argomento() With {.IDArgomento = 0, .Titolo = "Altro...", .DescrizioneBreve = "", .Ordine = 0})

        lstCat.SelectedValue = IdA
        If IdD Then CaricaDom(IdD)
           
        ddlArgomento.DataSource = l
        ddlArgomento.DataBind()

    End Sub

    Private Sub CaricaDom(Optional IdFaq As String = "")
        Dim IdArg As Integer = lstCat.SelectedValue
        Dim l As List(Of Faq)
        Using fM As New FaqDAO
            l = fM.FindAll("Ordine", New LUNA.LunaSearchParameter("IDArgomento", IdArg))
        End Using

        lstDom.DataSource = l
        lstDom.DataBind()

        If IdFaq.Length Then
            If IsNumeric(IdFaq) Then
                Dim IdF As Integer = CInt(IdFaq)

                If IdF Then
                    lstDom.SelectedValue = IdF

                    CaricaRisp()
                End If

            End If
        End If


    End Sub

    Protected Sub lstCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCat.SelectedIndexChanged

        CaricaDom()

    End Sub

    Protected Sub lstDom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDom.SelectedIndexChanged

        CaricaRisp()

    End Sub

    Private Sub CaricaRisp()
        pnlRisp.Visible = True
        pnlContactus.Visible = True

        ddlArgomento.SelectedValue = lstCat.SelectedItem.Text
        Dim faq As New Faq
        Dim IdFaq As Integer = lstDom.SelectedValue
        faq.Read(IdFaq)
        lblDomanda.Text = faq.Domanda

        'arg.Read(IdArg)
        'lblArg.Text = arg.Titolo
        lblRisp.Text = faq.RispostaWithLink
    End Sub

    Protected Sub btnInvia_Click(sender As Object, e As EventArgs) Handles btnInvia.Click

        'qui dopo i controlli javascript invio la mail al reparto e alla persona
        Dim Ris As Integer = 0

        If Session("cap").ToString <> txtCap.Text Then
            Ris = 2
        Else

            Try
                Dim LogText As String = txtEmail.Text & " " & txtOggetto.Text

                Dim Allegato1 As String = ""
                Dim Allegato2 As String = ""
                'qui provo a caricare gli allegati
                If flAllegato1.FileName.Length Then
                    Dim Estensione As String = flAllegato1.PostedFile.FileName.Substring(flAllegato1.PostedFile.FileName.LastIndexOf("."))
                    Dim NomeAllegato As String = GetNomeFileTemp(Estensione)

                    Allegato1 = MapPath("~\upload") & "\" & NomeAllegato

                    flAllegato1.PostedFile.SaveAs(Allegato1)
                End If
                If flAllegato2.FileName.Length Then
                    Dim Estensione As String = flAllegato1.PostedFile.FileName.Substring(flAllegato1.PostedFile.FileName.LastIndexOf("."))
                    Dim NomeAllegato As String = GetNomeFileTemp(Estensione)

                    Allegato2 = MapPath("~\upload") & "\" & NomeAllegato

                    flAllegato2.PostedFile.SaveAs(Allegato2)
                End If

                'se tutto ok invio le mail 

                Dim Dom As New Faq
                Dim Reparto As New Reparto

                Dom.Read(lstDom.SelectedValue)
                Reparto.Read(Dom.IDReparto)

               
                Dim TestoEmailCliente As String = "Gentile cliente,<br> abbiamo ricevuto la sua richiesta di assistenza relativa a:<br><br>"
                TestoEmailCliente &= "<b>" & txtOggetto.Text & "</b><br><br>"
                TestoEmailCliente &= "La ricontatteremo il prima possibile per fornirLe le informazioni di cui ha bisogno.<br><br>Cordiali saluti."
                TestoEmailCliente &= "<br><br><B>ATTENZIONE</b>, non rispondere a questa email in quanto questo indirizzo non viene monitorato."
                TestoEmailCliente &= "<br><br><B>RIEPILOGO RICHIESTA DI ASSISTENZA:</B><br><br>"
                TestoEmailCliente &= "Email di contatto: " & txtEmail.Text & "<br>"
                TestoEmailCliente &= "Nome e Cognome: " & txtNome.Text & "<br>"
                TestoEmailCliente &= "Argomento: <b>" & ddlArgomento.SelectedValue & "</b><br>"
                TestoEmailCliente &= "Numero Ordine: <b>" & txtNumOrd.Text & "</b><br>"
                TestoEmailCliente &= "Oggetto: <b>" & txtOggetto.Text & "</b><br>"
                TestoEmailCliente &= "Messaggio: <I>" & txtMessaggio.Text & "</i><br>"

                
                Ris = FormerHelper.Mail.InviaMail("Richiesta di assistenza: " & Strings.Left(txtOggetto.Text, 50), TestoEmailCliente, txtEmail.Text, , , Allegato1, Allegato2, Reparto.Email)
              
            Catch ex As Exception
                Ris = 1
            End Try
        End If
        Response.Redirect("/" & Ris & "-esito-richiesta/")

    End Sub

    Public Function GetNomeFileTemp(Optional ByVal extension As String = ".jpg") As String

        Dim Numero As New Random

        Randomize()

        Dim NomeFile As String = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond & Numero.Next(0, 1000) & extension

        Return NomeFile

    End Function

    Private Function GeneraCap(stringa As String) As String
        Dim imma As New Bitmap(60, 40)
        Dim g As Graphics = Graphics.FromImage(imma)
        Dim PathUrl As String = FormerWebApp.PathImgCaptcha & stringa & ".jpg"
        Dim PathImg As String = AppDomain.CurrentDomain.BaseDirectory & FormerWebApp.PathImgCaptcha.Replace("/", "\") & stringa & ".jpg"
        If Not File.Exists(PathImg) Then
            Dim pennello As SolidBrush = New SolidBrush(Color.White)
            g.Clear(Color.White)
            g.Clear(Color.Black)
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias

            Dim i As Integer
            Dim casuale As Integer
            Dim casfont As Integer
            Randomize()
            For i = 0 To stringa.Length - 1
                casuale = (Rnd() * 6) - 3
                casfont = (Rnd() * 5)
                g.DrawString(stringa.Substring(i, 1), New Font("arial", 10 + casfont, FontStyle.Regular), pennello, New PointF(2 + i * 12 + casuale, 10 + casuale * 2))
            Next

            imma.Save(PathImg, Imaging.ImageFormat.Jpeg)
        End If
        Return PathUrl
    End Function

End Class