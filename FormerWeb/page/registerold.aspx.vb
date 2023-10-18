Imports FormerLib.FormerEnum
Imports FormerDALWeb
Imports FormerLib
Public Class registerOld
    Inherits FormerFreePage
    'Private TipoWeb As Integer = enTipoWeb.Privato

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            CaricaProvincie()
            CaricaComuni()
            CaricaTipoAttivita()
        End If

    End Sub

    Private Sub CaricaTipoAttivita()

        Dim l As List(Of TipoAttivita)
        Using mgr As New TipoAttivitaDAO
            l = mgr.GetAll("Descrizione", True)
        End Using
        ddlTipoAtt.DataSource = l
        ddlTipoAtt.DataValueField = "IdTipoAttivita"
        ddlTipoAtt.DataTextField = "Descrizione"
        ddlTipoAtt.DataBind()
    End Sub

    Private Sub CaricaProvincie()

        Dim l As List(Of Provincia)
        Using cM As New ProvinceDAO
            l = cM.GetAll("Cod", True)
            l(0).Cod = "Selezionare una Provincia"
        End Using

        ddlProvincia.DataValueField = "ID"
        ddlProvincia.DataTextField = "Cod"
        ddlProvincia.DataSource = l
        ddlProvincia.DataBind()

    End Sub

    Private Function ModuloValido() As Boolean

        Dim ris As Boolean = True
        Dim ClientePrivato As Boolean = False

        If txtNomeAz.Text.Trim.Length = 0 Then
            ClientePrivato = True
        End If

        If txtNome.Text.Trim.Length < 2 Then
            ris = False
        End If

        If ris = True AndAlso txtCognome.Text.Trim.Length < 2 Then
            ris = False
        End If

        If ris = True AndAlso txtCodFisc.Text.Trim.Length <= 0 Then
            ris = False
        End If

        If ris = True AndAlso txtEmail.Text.Trim.Length = 0 Then
            ris = False
        End If

        If ris = True AndAlso txtEmailRip.Text.Trim.Length = 0 Then
            ris = False
        End If

        If ris = True AndAlso txtEmail.Text.Trim <> txtEmailRip.Text.Trim Then
            ris = False
        End If

        If ris = True AndAlso ddlProvincia.SelectedValue = 0 Then
            ris = False
        End If
        If ris = True AndAlso ddlComune.SelectedValue = 0 Then
            ris = False
        End If

        If ris = True AndAlso txtCitta.Text.Trim.Length = 0 Then
            ris = False
        End If

        If ris = True AndAlso txtIndirizzo.Text.Trim.Length = 0 Then
            ris = False
        End If

        If ris = True AndAlso txtCAP.Text.Trim.Length = 0 Then
            ris = False
        End If
        If ris = True AndAlso Not IsNumeric(txtCAP.Text) Then
            ris = False
        End If

        If ClientePrivato Then
            If txtCodFisc.Text.Trim.Length <> 16 Then ris = False
        Else
            If rdoRiv.Checked AndAlso ddlTipoAtt.SelectedValue = 0 Then
                ris = False
            End If

            If IsNumeric(txtCodFisc.Text.Trim) Then
                If txtCodFisc.Text.Trim.Length <> 11 Then ris = False
            Else
                If txtCodFisc.Text.Trim.Length <> 16 Then ris = False
            End If
            If FormerHelper.Finanziarie.CheckPartitaIva(txtPiva.Text) = False Then
                ris = False
            End If

        End If
        Try
            If FormerHelper.Finanziarie.CheckCodiceFiscale(txtCodFisc.Text) = False Then
                ris = False
            End If

        Catch ex As Exception

        End Try

        Return ris
    End Function

    Protected Sub btnRegistrami_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegistrami.Click

        If rdoCli.Checked = False And rdoRiv.Checked = False Then
            lblErrore.Text = "Scegli la Tipologia di Cliente, Privato o Società oppure Rivenditore"
            pnlErrore.Visible = True
        Else
            If ModuloValido() Then

                pnlErrore.Visible = False

                'prima controllo che non esiste un utente con questa email
                Dim TrovatoUt As Boolean = False
                Using U As New UtentiDAO
                    Dim lisU As List(Of Utente) = U.FindAll(New LUNA.LunaSearchParameter("Email", txtEmail.Text.Trim))
                    If lisU.Count Then TrovatoUt = True
                End Using

                If TrovatoUt Then
                    lblErrore.Text = "L'email inserita è già in uso. Se hai dimenticato la password di accesso utilizza la procedura di recupero Password dalla pagina di Login"
                    pnlErrore.Visible = True
                Else
                    'Dim l As List(Of RichiestaRegistrazioneW)
                    'Using M As New RichiesteRegistrazioneWDAO
                    'l = M.FindAll(New LUNA.LunaSearchParameter("Email", txtEmail.Text.Trim))
                    'End Using

                    'If l.Count Then
                    'lblErrore.Text = "Richiesta di registrazione già effettuata! Verrà contattato ai recapiti che ha lasciato non appena il suo account sarà pronto."
                    'pnlErrore.Visible = True
                    'Else

                    Dim TipoUt As Integer = 0

                    If rdoRiv.Checked Then
                        TipoUt = enTipoRubrica.Rivenditore
                    Else
                        TipoUt = enTipoRubrica.Cliente
                    End If
                    btnRegistrami.Enabled = False
                    'If TipoUt = enTipoRubrica.Rivenditore Then
                    'Dim R As New RichiestaRegistrazioneW

                    'R.Email = txtEmail.Text
                    'R.Cognome = txtCognome.Text
                    'R.Nome = txtNome.Text
                    'R.Tipo = TipoUt
                    'R.TipoStr = "Rivenditore"
                    'R.Sito = txtSito.Text
                    'R.Indirizzo = txtIndirizzo.Text
                    'R.IdComune = ddlComune.SelectedValue
                    'R.IdProvincia = ddlProvincia.SelectedValue
                    'R.Citta = txtCitta.Text
                    'R.Cap = txtCAP.Text
                    'R.Telefono = txtTel.Text
                    'R.NomeAz = txtNomeAz.Text
                    'R.Stato = enStatoRichiestaRegistrazione.InSospeso
                    'R.CodFisc = txtCodFisc.Text
                    'R.Piva = txtPiva.Text
                    'R.Save()
                    ''salvata la richiesta invio una mail a lui e una a noi 

                    'Dim Pt As New My.Templates.MailRegistrazioneOk
                    'Pt.R = R
                    'Dim Buffer As String = Pt.TransformText

                    'Try
                    '    FormerHelper.Mail.InviaMail("La sua Richiesta di Registrazione è stata inserita", Buffer, R.Email, _
                    '                                , , , , "soft@tipografiaformer.it;info@tipografiaformer.com")
                    'Catch ex As Exception

                    'End Try
                    'Else
                    'qui se non si tratta di un rivenditore e l'email non e' presente in rubrica lo posso gia inserire e inviargli login e password per email

                    Dim Pwd As String = FormerHelper.Security.GeneraPassword()
                    Dim PwdHash As String = FormerHelper.Security.GetMd5Hash(Pwd)
                    Dim Ut As New Utente
                    Ut.Email = txtEmail.Text
                    Ut.RagSoc = txtNomeAz.Text
                    Ut.Cognome = txtCognome.Text
                    Ut.Nome = txtNome.Text
                    Ut.TipoRub = TipoUt
                    Ut.TipoWeb = TipoUt
                    Ut.PasswordHash = PwdHash
                    Ut.IdComune = ddlComune.SelectedValue
                    Ut.IdProvincia = ddlProvincia.SelectedValue
                    Ut.Indirizzo = txtIndirizzo.Text
                    Ut.Citta = txtCitta.Text
                    Ut.Cap = txtCAP.Text
                    Ut.Tel = txtTel.Text
                    Ut.SitoWeb = txtSito.Text
                    Ut.CodFisc = txtCodFisc.Text
                    Ut.Piva = txtPiva.Text
                    Ut.DataIns = Now
                    Ut.IdTipoAttivita = ddlTipoAtt.SelectedValue
                    Ut.IdPagamento = enMetodoPagamento.PayPal
                    Ut.Save()

                    Dim Pt As New My.Templates.MailRegistrazioneInserita
                    Pt.U = Ut
                    Pt.Pwd = Pwd
                    Dim Buffer As String = Pt.TransformText

                    Try
                        FormerHelper.Mail.InviaMail("Benvenuto su TipografiaFormer.it", Buffer, Ut.Email, , , , , )
                    Catch ex As Exception

                    End Try
                    'End If
                    'ridirigo a registrazione OK 
                    Response.Redirect("/registrazione-effettuata")
                    'End If

                End If
            Else
                lblErrore.Text = "I dati che hai inserito non sembrano essere validi o non hai compilato tutti i campi obbligatori. Ti chiediamo cortesemente di ricontrollarli e in caso siano corretti di contattarci per permetterti di registrarti al nostro sito."
                pnlErrore.Visible = True

            End If
        End If


    End Sub

    Private Sub txtPiva_TextChanged(sender As Object, e As EventArgs) Handles txtPiva.TextChanged
        Dim val As Boolean
        Page.Validate("Piva")
        val = Page.IsValid

        If val Then val = FormerHelper.Finanziarie.CheckPartitaIva(txtPiva.Text)

        CheckValidate(val, imgPivaVal)

        If txtCodFisc.Text.Trim.Length = 0 And val = True Then
            txtCodFisc.Text = txtPiva.Text
            'txtCodFisc.Focus()
        End If
        If val = False Then
            txtPiva.Focus()
            'Else
            '    txtCodFisc.Focus()
        End If
    End Sub

    Private Sub rdoSoc_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRiv.CheckedChanged, _
        rdoCli.CheckedChanged

        If rdoCli.Checked Then
            'lblNomeAzienda.Visible = False
            'lblPiva.Visible = False
            'txtNomeAz.Visible = False
            lblTipoAtt.Visible = False
            ddlTipoAtt.Visible = False
            lblNomeAzienda.Text = "Ragione Sociale"
            lblSpecifIndirizzo.Text = "Principale"
            'txtPiva.Visible = False
            txtPiva.Text = ""
            txtNomeAz.Text = ""
            lblPiva.Text = "P. Iva"
            rqPiva.Enabled = False
            rqAz.Enabled = False
            imgRiv.Visible = False
            lblInfoRiv.Visible = False
        ElseIf rdoRiv.Checked Then
            imgRiv.Visible = True
            'lblNomeAzienda.Visible = True
            lblSpecifIndirizzo.Text = "della Sede Legale"
            lblTipoAtt.Visible = True
            ddlTipoAtt.Visible = True
            'lblPiva.Visible = True
            'txtNomeAz.Visible = True
            lblNomeAzienda.Text = "Ragione Sociale *"
            'txtPiva.Visible = True
            lblPiva.Text = "P. Iva *"
            rqPiva.Enabled = True
            rqAz.Enabled = True
            lblInfoRiv.Visible = True
        End If

    End Sub

    Private Sub txtCognome_TextChanged(sender As Object, e As EventArgs) Handles txtCognome.TextChanged
        Dim val As Boolean
        Page.Validate("cognome")
        val = Page.IsValid
        If val Then
            val = IsValidNominativo(txtCognome.Text)
            If val = False Then
                txtCognome.Focus()
                'Else
                '    txtIndirizzo.Focus()
            End If
        End If
        CheckValidate(val, imgCognomeval)
    End Sub
    Private Sub CheckValidate(valido As Boolean, img As Image)
        If valido Then
            img.ImageUrl = String.Empty
        Else
            img.ImageUrl = "/img/icoCheckKo.png"
        End If
        img.Visible = True
    End Sub
    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        Dim val As Boolean
        Page.Validate("email")
        val = Page.IsValid
        If val Then
            If val = False Then
                txtEmail.Focus()
            End If
        End If
        CheckValidate(val, imgEmail)

    End Sub

    Private Sub txtEmailRip_TextChanged(sender As Object, e As EventArgs) Handles txtEmailRip.TextChanged
        Dim val As Boolean
        Page.Validate("EmailRip")
        val = Page.IsValid
        If val Then
            If txtEmail.Text <> txtEmailRip.Text Then
                val = False
                regEmailRip.ErrorMessage = "Le email inserite non sono uguali"
            End If
        End If
        regEmailRip.ErrorMessage = "email non sembra corretta"

        CheckValidate(val, imgEmailRip)
        If val = False Then
            txtEmailRip.Focus()
        End If
    End Sub

    Private Sub txtNome_TextChanged(sender As Object, e As EventArgs) Handles txtNome.TextChanged
        Dim val As Boolean
        Page.Validate("nome")
        val = Page.IsValid
        If val Then val = IsValidNominativo(txtNome.Text)
        CheckValidate(val, imgNomeval)
        If val = False Then
            txtNome.Focus()
        End If
    End Sub
    Private Function IsValidNominativo(testo As String) As Boolean

        Dim retval As Boolean = True

        Try
            Dim contaLettere As Integer
            Dim OldLetter As String
            Dim newLetter As String
            Dim InizLett As String = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM"
            If testo.Length Then
                If testo.Trim.Length = 1 Then
                    retval = False
                End If
                If InizLett.IndexOf(testo.Substring(0, 1)) = -1 Then
                    retval = False
                End If
                If testo.Substring(0, 1) = testo.Substring(1, 1) Then
                    retval = False
                End If
                If testo.Substring(1, 1).Trim = "" Then 'spazio inserito dopo il primo carattere
                    retval = False
                End If
                OldLetter = testo.Substring(0, 1)
                For i As Integer = 1 To testo.Length - 1
                    newLetter = testo.Substring(i, 1)
                    If newLetter = OldLetter Then
                        contaLettere += 1
                    Else
                        OldLetter = newLetter
                        contaLettere = 0
                    End If
                    If contaLettere > 1 Then
                        retval = False
                    End If
                Next

                If testo.StartsWith("asd") Or testo.StartsWith("qwer") Then
                    retval = False
                End If
            Else
                retval = False
            End If
        Catch ex As Exception

        End Try

        Return retval

    End Function

    Private Sub txtCodFisc_TextChanged(sender As Object, e As EventArgs) Handles txtCodFisc.TextChanged
        Dim val As Boolean
        Page.Validate("fiscale")
        val = Page.IsValid
        If val Then val = FormerHelper.Finanziarie.CheckCodiceFiscale(txtCodFisc.Text)
        CheckValidate(val, imgCodFiscVal)
        If val = False Then
            txtCodFisc.Focus()
        End If
    End Sub
    Private Sub CaricaComuni()
        Dim IdProv As Integer = ddlProvincia.SelectedValue

        Using Mgr As New ComuniDAO
            Dim lst As List(Of Comune) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DESCCOMUNE"}, New LUNA.LunaSearchParameter("IdProv", IdProv))
            lst.Insert(0, (New Comune With {.ID = 0, .DESCCOMUNE = "Seleziona un Comune"}))
            ddlComune.DataSource = lst



            ddlComune.DataValueField = "ID"
            ddlComune.DataTextField = "DESCCOMUNE"
            ddlComune.DataBind()
        End Using


    End Sub
    Private Sub ddlProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvincia.SelectedIndexChanged
        If ddlProvincia.SelectedValue <> 0 Then
            CaricaComuni()

        Else
            ddlComune.DataSource = ""
            ddlComune.Items.Clear()

            ddlComune.DataBind()
        End If
    End Sub


End Class