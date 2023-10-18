Imports FormerLib.FormerEnum
Imports FormerDALWeb
Imports FormerLib

Public Class register
    Inherits FormerFreePage
    'Private TipoWeb As Integer = enTipoWeb.Privato

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If UtenteConnesso.IdUtente Then

            Response.Redirect("/area-riservata")

        Else

            Me.MaintainScrollPositionOnPostBack = True

            If Not IsPostBack Then
                'CaricaProvincie()
                'CaricaComuni()
                CaricaNazioni()
                CaricaTipoAttivita()
                CaricaOmaggi()
            End If
        End If

    End Sub

    Private Sub CaricaNazioni()
        Dim l As List(Of Nazione)
        l = MgrNazioni.GetLista

        ddlNazione.DataSource = l
        ddlNazione.DataValueField = LFM.Nazione.IdNazione.Name
        ddlNazione.DataTextField = LFM.Nazione.Nazione.Name
        ddlNazione.DataBind()
    End Sub

    Private Sub CaricaOmaggi()

        Dim L As List(Of OmaggioW) = MgrOmaggi.GetOmaggi(UtenteConnesso)

        L = L.FindAll(Function(x) x.Tipologia = enTipologiaOmaggio.AlPrimoOrdine)

        rptOmaggi.DataSource = L
        rptOmaggi.DataBind()

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

    'Private Sub CaricaProvincie()

    '    Dim l As List(Of Provincia)
    '    Using cM As New ProvinceDAO
    '        l = cM.GetAll("Cod", True)
    '        l(0).Cod = "Selezionare una Provincia"
    '    End Using

    '    ddlProvincia.DataValueField = "ID"
    '    ddlProvincia.DataTextField = "Cod"
    '    ddlProvincia.DataSource = l
    '    ddlProvincia.DataBind()

    'End Sub

    Private Function ModuloValido() As String

        Dim ris As String = String.Empty
        Dim ClientePrivato As Boolean = False

        If rdoCli.Checked = False And rdoRiv.Checked = False Then
            ris &= "<li>Scegliere la Tipologia di Cliente, Privato o Società oppure Rivenditore</li>"
        Else
            If rdoRiv.Checked Then
                ClientePrivato = False
            Else
                If txtNomeAz.Text.Trim.Length = 0 Then
                    ClientePrivato = True
                End If
            End If
        End If

        If ClientePrivato = False And txtNomeAz.Text.Trim.Length = 0 Then
            ris &= "<li>La Ragione Sociale non sembra corretta</li>"
        End If

        If txtNome.Text.Trim.Length < 2 OrElse IsValidNominativo(txtNome.Text) = False Then
            ris &= "<li>Il Nome non sembra corretto</li>"
        End If

        If txtCognome.Text.Trim.Length < 2 OrElse IsValidNominativo(txtCognome.Text) = False Then
            ris &= "<li>Il Cognome non sembra corretto</li>"
        End If

        If txtIndirizzo.Text.Trim.Length = 0 Then
            ris &= "<li>Inserire l'indirizzo</li>"
        End If

        If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
            If txtCAP.Text.Trim.Length = 0 Then
                ris &= "<li>Inserire il CAP</li>"
            ElseIf Not IsNumeric(txtCAP.Text) Then
                ris &= "<li>Il CAP non sembra corretto</li>"
            End If

            If ddlCitta.Items.Count <> 0 AndAlso ddlCitta.SelectedValue = 0 Then
                ris &= "<li>Selezionare la Località</li>"
            ElseIf ddlCitta.Items.Count = 0 Then
                ris &= "<li>Selezionare la Località</li>"
            End If
        Else
            If txtLocalita.Text.Trim.Length = 0 Then
                ris &= "<li>Inserire la Località e il CAP</li>"
            End If
        End If

        If Not ClientePrivato Then
            If rdoRiv.Checked AndAlso ddlTipoAtt.SelectedValue = 0 Then
                ris &= "<li>Selezionare il tipo di Attività</li>"
            End If

            If IsNumeric(txtCodFisc.Text.Trim) Then
                If txtCodFisc.Text.Trim.Length <> 11 Then
                    ris &= "<li>Il Codice Fiscale non sembra corretto</li>"
                End If
            End If
        End If

        Dim ClienteConPIva As Boolean = False

        If ClientePrivato = False OrElse txtNomeAz.Text.Trim.Length <> 0 Then
            ClienteConPIva = True
            If txtPiva.Text.Length = 0 Then
                ris &= "<li>La Partita Iva non sembra corretta</li>"
            Else

                If txtPrefisso.Text.Trim.Length = 0 Then
                    ris &= "<li>Inserire il prefisso della Partita IVA</li>"
                Else
                    If FormerHelper.Finanziarie.CheckPartitaIva(txtPiva.Text, txtPrefisso.Text) = False Then
                        ris &= "<li>La Partita Iva non sembra corretta</li>"
                    End If
                End If
            End If
        End If

        'If ClienteConPIva Then
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

        If txtCodFisc.Text.Trim.Length <= 0 Then
            ris &= "<li>Il Codice Fiscale non sembra corretto</li>"
        Else
            Try
                If FormerHelper.Finanziarie.CheckCodiceFiscale(txtCodFisc.Text, txtPrefisso.Text) = False Then
                    ris &= "<li>Il Codice Fiscale non sembra corretto</li>"
                End If

            Catch ex As Exception
                ris &= "<li>Il Codice Fiscale non sembra corretto</li>"
            End Try
        End If

        If txtTel.Text.Trim.Length <> 0 AndAlso IsNumeric(txtTel.Text) = False Then
            ris &= "<li>Il Telefono non sembra corretto</li>"
        End If

        If txtCel.Text.Trim.Length <> 0 AndAlso IsNumeric(txtCel.Text) = False Then
            ris &= "<li>Il Cellulare non sembra corretto</li>"
        End If

        If txtTel.Text.Trim.Length = 0 And txtCel.Text.Trim.Length = 0 Then
            ris &= "<li>Inserire almeno un recapito telefonico</li>"
        End If

        If txtFax.Text.Trim.Length <> 0 AndAlso IsNumeric(txtFax.Text) = False Then
            ris &= "<li>Il Fax non sembra essere corretto</li>"
        End If

        If txtEmail.Text.Trim.Length = 0 Then
            ris &= "<li>Inserire l'indirizzo Email</li>"
        Else
            If FormerHelper.Mail.IsValidEmailAddress(txtEmail.Text) = False Then
                ris &= "<li>L'indirizzo Email non sembra corretto</li>"
            End If
        End If

        If txtEmailRip.Text.Trim.Length = 0 Then
            ris &= "<li>Ripetere l'indirizzo Email</li>"
        ElseIf txtEmail.Text.Trim <> txtEmailRip.Text.Trim Then
            ris &= "<li>L'indirizzo Email inserito è diverso da quello Ripetuto</li>"
        End If

        If chkConsensoDati.Checked = False Then
            ris &= "<li>E' necessario dare il consenso al trattamento dei proprio dati personali</li>"
        End If

        If ris.Length Then
            ris = "<b>ATTENZIONE</b><ul>" & ris & "</ul>"
        End If

        Return ris

    End Function

    Private Sub RegistraUtente()

        Dim RisVal As String = ModuloValido()

        If RisVal = String.Empty Then

            pnlErrore.Visible = False

            'prima controllo che non esiste un utente con questa email
            Dim TrovatoUtEmail As Boolean = False
            Using U As New UtentiDAO
                Dim lisU As List(Of Utente) = U.FindAll(New LUNA.LunaSearchParameter(LFM.Utente.Email, txtEmail.Text.Trim))
                If lisU.Count Then TrovatoUtEmail = True
            End Using

            Dim TrovatoUtPiva As Boolean = False

            If txtPiva.Text.Trim.Length Then
                Using U As New UtentiDAO
                    Dim lisU As List(Of Utente) = U.FindAll(New LUNA.LunaSearchParameter(LFM.Utente.Piva, txtPiva.Text.Trim))
                    If lisU.Count Then TrovatoUtPiva = True
                End Using
            End If

            If TrovatoUtEmail Then
                lblErrore.Text = "<b>ATTENZIONE</b><ul><li>L'email inserita è già in uso. Se hai dimenticato la password di accesso utilizza la procedura di recupero Password dalla pagina di Login</li></ul>"
                pnlErrore.Visible = True
            ElseIf TrovatoUtPiva Then
                lblErrore.Text = "<b>ATTENZIONE</b><ul><li>La partita IVA inserita è già in uso. Se hai dimenticato la password di accesso utilizza la procedura di recupero Password dalla pagina di Login</li></ul>"
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

                'Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                'Try

                Dim TipoUt As Integer = 0

                If rdoRiv.Checked Then
                    TipoUt = enTipoRubrica.Rivenditore
                Else
                    TipoUt = enTipoRubrica.Cliente
                End If
                btnRegistrami.Enabled = False

                Dim Pwd As String = FormerHelper.Security.GeneraPassword()
                Dim PwdHash As String = FormerHelper.Security.GetMd5Hash(Pwd)

                Dim ComuneScelto As New ComuneInElenco

                If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
                    ComuneScelto.Read(ddlCitta.SelectedValue)
                End If

                'tb.TransactionBegin()

                'Dim TrovatoUtEmail As Boolean = False
                Using U As New UtentiDAO
                    Dim lisU As List(Of Utente) = U.FindAll(New LUNA.LunaSearchParameter(LFM.Utente.Email, txtEmail.Text.Trim))
                    If lisU.Count Then TrovatoUtEmail = True
                End Using

                If TrovatoUtEmail = False Then 'controllo solo per evitare doppioni
                    Dim Ut As New Utente
                    Ut.Email = txtEmail.Text.Trim.ToLower
                    Ut.RagSoc = StrConv(txtNomeAz.Text.Trim, VbStrConv.ProperCase)
                    Ut.Cognome = StrConv(txtCognome.Text.Trim, VbStrConv.ProperCase)
                    Ut.Nome = StrConv(txtNome.Text.Trim, VbStrConv.ProperCase)
                    Ut.TipoRub = TipoUt
                    Ut.TipoWeb = TipoUt
                    Ut.PasswordHash = PwdHash
                    Ut.IdNazione = ddlNazione.SelectedValue
                    Ut.Indirizzo = txtIndirizzo.Text.Trim

                    If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
                        Ut.IdComune = ComuneScelto.IDCap
                        Ut.IdProvincia = ComuneScelto.ProvinciaSel.ID
                        Ut.Provincia = ComuneScelto.Provincia
                        Ut.Citta = ComuneScelto.Comune
                        Ut.Cap = txtCAP.Text
                    Else
                        Ut.Cap = FormerConst.Culture.CapEstero
                        Ut.Citta = txtLocalita.Text
                    End If

                    Ut.Tel = txtTel.Text.Trim
                    Ut.Cellulare = txtCel.Text.Trim
                    Ut.SitoWeb = txtSito.Text.Trim.ToLower
                    Ut.CodFisc = txtCodFisc.Text.ToUpper
                    Ut.PrefissoPIva = txtPrefisso.Text.ToUpper
                    Ut.Piva = txtPiva.Text
                    Ut.DataIns = Now
                    Ut.IdTipoAttivita = ddlTipoAtt.SelectedValue
                    Ut.IdPagamento = enMetodoPagamento.PayPal
                    Ut.NoMail = IIf(chkConsensoNewsletter.Checked, enSiNo.No, enSiNo.Si)
                    Ut.Pec = txtPec.Text
                    Ut.CodiceSDI = txtSDI.Text

                    Ut.Save()
                    'tb.TransactionCommit()

                    Dim Pt As New My.Templates.MailRegistrazioneInserita
                    Pt.U = Ut
                    Pt.Pwd = Pwd
                    Dim Buffer As String = Pt.TransformText

                    Try
                        FormerHelper.Mail.InviaMail("Benvenuto su TipografiaFormer.it", Buffer, Ut.Email, , , , , )
                    Catch ex As Exception

                    End Try

                    'Else
                    'tb.TransactionRollBack()
                End If

                ' Catch ex As Exception
                'tb.TransactionRollBack()
                'End Try
                'End Using


                'End If
                'ridirigo a registrazione OK 
                Response.Redirect("/registrazione-effettuata")
                'End If

            End If
        Else
            lblErrore.Text = RisVal
            pnlErrore.Visible = True

        End If
    End Sub

    Protected Sub btnRegistrami_Click(sender As Object, e As EventArgs) Handles btnRegistrami.Click

        RegistraUtente()

    End Sub

    Public Function MostraOmaggi() As Boolean

        Dim ris As Boolean = True

        ''se non ha gia in carrello un omaggio puo avere un omaggio
        ''se ci sono omaggi puo avere un omaggio


        'Using p As New PreventivazioneW
        '        p.Read(FormerConst.ProdottiParticolari.IdPreventivazioneOmaggi)
        '        Dim l As List(Of ListinoBaseW) = p.GetListiniBase

        '        If l.FindAll(Function(x) x.Disattivo = enSiNo.No).Count = 0 Then
        '            ris = False
        '        End If

        '    End Using

        'If ris Then
        '    'qui vado a valutare quali omaggi mostrare
        '    Dim l As List(Of OmaggioW) = MgrOmaggi.GetOmaggi(UtenteConnesso)

        '    If l.Count = 0 Then
        '        ris = False
        '    End If
        'End If

        ris = MgrOmaggi.MostraOmaggi(UtenteConnesso, New List(Of ProdottoInCarrello), enTipologiaOmaggio.AlPrimoOrdine)

        Return ris

    End Function

    'Private Sub txtPiva_TextChanged(sender As Object, e As EventArgs) Handles txtPiva.TextChanged
    '    Dim val As Boolean
    '    Page.Validate("Piva")
    '    val = Page.IsValid

    '    If val Then val = FormerHelper.Finanziarie.CheckPartitaIva(txtPiva.Text)

    '    CheckValidate(val, imgPivaVal)

    '    If txtCodFisc.Text.Trim.Length = 0 And val = True Then
    '        txtCodFisc.Text = txtPiva.Text
    '        'txtCodFisc.Focus()
    '    End If
    '    If val = False Then
    '        txtPiva.Focus()
    '        'Else
    '        '    txtCodFisc.Focus()
    '    End If
    'End Sub

    Private Sub rdoSoc_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRiv.CheckedChanged, _
        rdoCli.CheckedChanged

        If rdoCli.Checked Then
            lblTipoAtt.Visible = False
            ddlTipoAtt.Visible = False
            lblNomeAzienda.Text = "Ragione Sociale"
            lblSpecifIndirizzo.Text = "Principale"
            'txtPiva.Text = ""
            'txtNomeAz.Text = ""
            lblPiva.Text = "P. Iva"
            lblPec.Text = "Pec"
            'rqPiva.Enabled = False
            'rqAz.Enabled = False
            imgRiv.Visible = False
            lblInfoRiv.Visible = False
        ElseIf rdoRiv.Checked Then
            imgRiv.Visible = True
            lblSpecifIndirizzo.Text = "della Sede Legale"
            lblTipoAtt.Visible = True
            ddlTipoAtt.Visible = True
            lblNomeAzienda.Text = "Ragione Sociale *"
            lblPiva.Text = "P. Iva *"
            lblPec.Text = "Pec *"
            'rqPiva.Enabled = True
            'rqAz.Enabled = True
            lblInfoRiv.Visible = True
        End If

    End Sub

    'Private Sub txtCognome_TextChanged(sender As Object, e As EventArgs) Handles txtCognome.TextChanged
    '    Dim val As Boolean
    '    Page.Validate("cognome")
    '    val = Page.IsValid
    '    If val Then
    '        val = IsValidNominativo(txtCognome.Text)
    '        If val = False Then
    '            txtCognome.Focus()
    '            'Else
    '            '    txtIndirizzo.Focus()
    '        End If
    '    End If
    '    CheckValidate(val, imgCognomeval)
    'End Sub
    'Private Sub CheckValidate(valido As Boolean, img As Image)
    '    If valido Then
    '        img.ImageUrl = String.Empty
    '    Else
    '        img.ImageUrl = "/img/icoCheckKo.png"
    '    End If
    '    img.Visible = True
    'End Sub
    'Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
    '    Dim val As Boolean
    '    Page.Validate("email")
    '    val = Page.IsValid
    '    If val Then
    '        If val = False Then
    '            txtEmail.Focus()
    '        End If
    '    End If
    '    CheckValidate(val, imgEmail)

    'End Sub

    'Private Sub txtEmailRip_TextChanged(sender As Object, e As EventArgs) Handles txtEmailRip.TextChanged
    '    Dim val As Boolean
    '    Page.Validate("EmailRip")
    '    val = Page.IsValid
    '    If val Then
    '        If txtEmail.Text <> txtEmailRip.Text Then
    '            val = False
    '            regEmailRip.ErrorMessage = "Le email inserite non sono uguali"
    '        End If
    '    End If
    '    regEmailRip.ErrorMessage = "email non sembra corretta"

    '    CheckValidate(val, imgEmailRip)
    '    If val = False Then
    '        txtEmailRip.Focus()
    '    End If
    'End Sub

    'Private Sub txtNome_TextChanged(sender As Object, e As EventArgs) Handles txtNome.TextChanged
    '    Dim val As Boolean
    '    Page.Validate("nome")
    '    val = Page.IsValid
    '    If val Then val = IsValidNominativo(txtNome.Text)
    '    CheckValidate(val, imgNomeval)
    '    If val = False Then
    '        txtNome.Focus()
    '    End If
    'End Sub

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

    'Private Sub txtCodFisc_TextChanged(sender As Object, e As EventArgs) Handles txtCodFisc.TextChanged
    '    Dim val As Boolean
    '    Page.Validate("fiscale")
    '    val = Page.IsValid
    '    If val Then val = FormerHelper.Finanziarie.CheckCodiceFiscale(txtCodFisc.Text)
    '    CheckValidate(val, imgCodFiscVal)
    '    If val = False Then
    '        txtCodFisc.Focus()
    '    End If
    'End Sub

    Private Sub CaricaLocalita(Cap As String)
        Dim IdComune As Integer = 0
        Using Mgr As New ElencoComuniDAO
            Dim l As List(Of ComuneInElenco) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Comune", .AddEmptyItem = True}, New LUNA.LunaSearchParameter("CAP", Cap))
            If l.Count Then
                ddlCitta.DataTextField = "Riassunto"
                ddlCitta.DataValueField = "IdCap"
                ddlCitta.DataSource = l
                ddlCitta.DataBind()
            Else
                ddlCitta.Items.Clear()
            End If


        End Using
    End Sub
    'Private Sub ddlProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvincia.SelectedIndexChanged
    '    If ddlProvincia.SelectedValue <> 0 Then
    '        CaricaComuni()

    '    Else
    '        ddlComune.DataSource = ""
    '        ddlComune.Items.Clear()

    '        ddlComune.DataBind()
    '    End If
    'End Sub


    Private Sub txtCAP_TextChanged(sender As Object, e As EventArgs) Handles txtCAP.TextChanged

        If txtCAP.Text.Trim.Length = 5 Then
            'qui ho 5 caratteri, se sono tutti numeri provo a cercare le localita e il resto
            Dim CapScelto As String = txtCAP.Text
            If IsNumeric(CapScelto) Then
                If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
                    CaricaLocalita(CapScelto)
                End If
            End If
        End If

    End Sub

    Private Sub ddlNazione_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlNazione.SelectedIndexChanged

        txtCAP.Text = String.Empty
        txtLocalita.Text = String.Empty
        ddlCitta.DataSource = Nothing
        ddlCitta.DataBind()

        If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
            pnlLocalitaIT.Visible = True
            pnlLocalitaNonIT.Visible = False
        Else
            pnlLocalitaIT.Visible = False
            pnlLocalitaNonIT.Visible = True
        End If

        txtPrefisso.Text = MgrNazioni.GetLista().Find(Function(x) x.IdNazione = ddlNazione.SelectedValue).Code

    End Sub

End Class