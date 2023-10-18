Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Public Class frmListinoProdotto
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0
    Private _Prod As Prodotto

    Private Sub CaricaAnteprima()
        Dim UrlAnteprima As String
        If FormerHelper.Web.IsPingable("www.tipografiaformer.it") Then
            UrlAnteprima = "http://www.tipografiaformer.com/listino/anteprima/" & _Prod.IdCatProd & ".html"
        Else
            UrlAnteprima = "about:Anteprima non disponibile"
        End If

        WebAnteprima.Navigate(UrlAnteprima)

    End Sub

    Private Sub CaricaCombo()

        Dim TipoProd As New cTipoProdCom(False)
        cmbTipoProd.DataSource = TipoProd
        cmbTipoProd.ValueMember = "Id"
        cmbTipoProd.DisplayMember = "Descrizione"

        'Dim CatProd As New CatProdDAO
        'cmbCatProd.ValueMember = "IdCatProd"
        'cmbCatProd.DisplayMember = "Descrizione"

        ''cmbCatProd.DataSource = CatProd.Find("Descrizione", New LUNA.LunaSearchParameter("IdCatPadre", 0))
        'cmbCatProd.DataSource = CatProd.GetAll("Descrizione")

        'qui carico le combo di formato e tipocarta
        Using mgr As New FormatiProdottoDAO
            cmbFormato.HeightImg = 64
            cmbFormato.WidthImg = 64
            cmbFormato.DataSource = mgr.ListaFormati
            cmbFormato.DisplayMember = "Id"
            cmbFormato.ValueMember = "Text"
        End Using

        Using mgr As New TipiCartaDAO
            cmbTipoCarta.HeightImg = 64
            cmbTipoCarta.WidthImg = 64
            cmbTipoCarta.DataSource = mgr.ListaTipi
            cmbTipoCarta.DisplayMember = "Id"
            cmbTipoCarta.ValueMember = "Text"
        End Using

    End Sub

    Private _IdPrev As Integer = 0

    Friend Function Carica(ByVal Prod As Prodotto, Optional ByVal IdPrev As Integer = 0) As Integer
        _IdPrev = IdPrev
        _Prod = Prod

        CaricaCombo()

        If _Prod.IdProd Then
            'modifica
            Text = "Former - Prodotto " & _Prod.IdProd
            txtCodice.Text = _Prod.Codice

            txtDescr.Text = _Prod.Descrizione
            txtDescrEstesa.Text = _Prod.DescrizioneEstesa
            txtPrezzo.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Prod.Prezzo, 2)
            txtPrezzoRiv.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Prod.PrezzoPubbl, 2)

            txtScarto.Text = _Prod.Scarto
            txtNumColli.Text = _Prod.NumColli
            txtNumPezzi.Text = _Prod.NumPezzi
            txtPesoComplessivo.Text = _Prod.PesoComplessivo
            txtNumOreMax.Text = _Prod.NumOreMax
            txtNumSpazi.Text = _Prod.NumSpazi
            txtNumDuplic.Text = _Prod.NumDuplic

            MgrControl.SelectIndexCombo(cmbTipoProd, _Prod.TipoProd)

            If Not _Prod.ListinoBase Is Nothing Then
                lblListinoBase.Text = _Prod.ListinoBase.IdListinoBase & " - " & _Prod.ListinoBase.Nome
            End If

            If _Prod.IdFormato Then
                Dim F As New FormatoProdotto
                F.Read(_Prod.IdFormato)
                MgrControl.SelectIndexComboValore(cmbFormato, F.Formato)
                F = Nothing
            End If
            If _Prod.IdTipoCarta Then
                Dim TC As New TipoCarta
                TC.Read(_Prod.IdTipoCarta)
                MgrControl.SelectIndexComboValore(cmbTipoCarta, TC.Tipologia)
                TC = Nothing
            End If

            lblCat.Tag = _Prod.IdCatProd
            Dim C As New CatProd
            C.Read(_Prod.IdCatProd)
            lblCat.Text = C.Descrizione
            C = Nothing

            chkFR.Checked = _Prod.FronteRetro

            txtGGNorm.Text = _Prod.GGNormale
            txtGGFast.Text = _Prod.GGFast
            txtGGLow.Text = _Prod.GGLow
            txtPercFast.Text = _Prod.PercFast
            txtPercLow.Text = _Prod.PercLow
            txtPercNorm.Text = _Prod.PercNormale

        Else
            'nuovo

            TabMain.TabPages.Remove(tpAnteprima)
            MgrControl.SelectIndexCombo(cmbTipoProd, enTipoProdCom.StampaOffSet)
            txtNumColli.Text = 1
            txtNumPezzi.Text = 1

        End If

        'carico le lavorazioni disponibili e selezionate
        UcLavorazioni.CaricaxProd(_Prod.IdProd)

        If _Prod.IdListinoBase Then
            Dim L As List(Of Integer) = Nothing
            Using mgr As New LavorazioniDAO
                L = mgr.ListaIdLavorazioniSuListinoBase(_Prod.IdListinoBase)
            End Using
            UcCaratProdotto.Carica(_Prod.ListinoBase)
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    'Private Sub lnkPrev_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPrev.LinkClicked
    '    Dim Ris As Integer, rif As New frmCalcCarta
    '    Dim PrezzoRif As Single
    '    Sottofondo()
    '    Ris = rif.Carica(enTipoProdCom.OffSet, PrezzoRif)
    '    Sottofondo()
    '    If Ris Then
    '        txtPrezzo.Text = PrezzoRif
    '    End If
    'End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        'Dim x As New cProdottiColl
        Dim ExistCodice As Boolean = False
        Using Mgr As New ProdottiDAO
            ExistCodice = Mgr.Exists(txtCodice.Text, _Prod.IdProd)
        End Using
        If ExistCodice Then
            MessageBox.Show("Il codice inserito è già utilizzato per un altro prodotto!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

            If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                _Prod.Codice = txtCodice.Text
                _Prod.Descrizione = txtDescr.Text
                _Prod.DescrizioneEstesa = txtDescrEstesa.Text
                _Prod.Prezzo = CDec(txtPrezzo.Text)
                _Prod.PrezzoPubbl = CDec(txtPrezzoRiv.Text)
                _Prod.TipoProd = cmbTipoProd.SelectedValue
                _Prod.FronteRetro = chkFR.Checked
                _Prod.NumPezzi = CInt(txtNumPezzi.Text)
                _Prod.NumColli = CInt(txtNumColli.Text)
                _Prod.NumOreMax = CInt(txtNumOreMax.Text)


                '_Prod.IdCatProd = cmbCatProd.SelectedValue
                _Prod.IdCatProd = lblCat.Tag

                _Prod.PesoComplessivo = CInt(txtPesoComplessivo.Text)
                _Prod.NumSpazi = txtNumSpazi.Text
                _Prod.NumDuplic = txtNumDuplic.Text
                _Prod.GGNormale = txtGGNorm.Text
                _Prod.GGFast = txtGGFast.Text
                _Prod.GGLow = txtGGLow.Text
                _Prod.PercFast = txtPercFast.Text
                _Prod.PercLow = txtPercLow.Text
                _Prod.PercNormale = txtPercNorm.Text
                If cmbTipoCarta.SelectedIndex <> -1 Then
                    Dim TC As TipoCartaEx = cmbTipoCarta.SelectedItem
                    _Prod.IdTipoCarta = TC.IdTipoCarta
                End If
                If cmbFormato.SelectedIndex <> -1 Then
                    Dim TC As FormatoProdottoEx = cmbFormato.SelectedItem
                    _Prod.IdFormato = TC.IdFormProd
                End If
                _Prod.Scarto = txtScarto.Text

                If _Prod.IsValid Then
                    _Prod.Save()
                    Using mP As New ProdottiDAO
                        mP.SalvaLavorazioni(_Prod, UcLavorazioni.ListaIdSelezionati)
                    End Using
                    _Ris = 1

                    ''qui se vengo da un preventivo mando una mail al cliente avvisandolo 
                    'If _IdPrev Then
                    '    InviaMailAPreventivo()
                    'End If


                    Close()
                Else
                    MessageBox.Show("I campi Codice, Descrizione e Categoria Prodotto sono obbligatori! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        End If

    End Sub

    'Private Sub InviaMailAPreventivo()

    '    Dim prev As New Preventivo
    '    prev.Read(_IdPrev)
    '    Dim Rub As New VoceRubrica
    '    Rub.Read(prev.IdRub)
    '    If Rub.Email.Length Then
    '        Dim CorpoMail As String = ""
    '        CorpoMail = "Gentile Cliente, in seguito alla sua richiesta di preventivo numero " & prev.Numero & " la informiamo che potrà fare riferimento al nuovo prodotto '" & _Prod.Descrizione & "' con codice '" & _Prod.Codice & "' che è stato inserito a listino. Cordiali saluti"
    '        FormerHelper.Mail.InviaMail("Riferimento preventivo numero " & prev.Numero,CorpoMail,
    '        'SendMail(Rub.Email, "Riferimento preventivo numero " & prev.Numero, CorpoMail, "", False)
    '    End If

    '    Rub = Nothing
    '    prev = Nothing


    'End Sub

    Private Sub txtCodice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodice.KeyPress
        ControlloCodice(sender, e)
    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoProd.SelectedIndexChanged
        Try

            If cmbTipoProd.SelectedIndex <> -1 Then
                If cmbTipoProd.SelectedItem.id = enTipoProdCom.StampaOffSet Then
                    'lnkPrev.Visible = True
                    chkFR.Visible = True

                Else
                    'lnkPrev.Visible = False
                    chkFR.Visible = False

                End If
            End If
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Private Sub txtCodice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodice.TextChanged
        'controllo che non sia presente
        ' Dim x As New cProdottiColl

        If (New ProdottiDAO).Exists(txtCodice.Text, _Prod.IdProd) Then
            pctAlertCodice.Visible = True
        Else
            pctAlertCodice.Visible = False
        End If

        'x = Nothing
    End Sub

    Private Sub txtPrezzo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrezzo.TextChanged
        If sender.text.length = 0 Then
            sender.text = "0"
        Else
            'calcolo iva e totale
            Dim Prezzo As Decimal = 0
            Try
                Prezzo = CDec(txtPrezzo.Text)
            Catch ex As Exception

            End Try
            Dim Iva As Decimal = FormerHelper.Finanziarie.CalcolaIva(Prezzo)
            'Dim Iva As String = CDbl(txtPrezzo.Text) * FormerHelper.Finanziarie.GetPercentualeIva / 100
            Dim Totale As Decimal = Prezzo + Iva

            lblIva.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Iva)
            lblTot.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Totale)
        End If


    End Sub

    Private Sub txtGGNorm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGGNorm.TextChanged, txtGGFast.TextChanged, txtGGLow.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
    End Sub

    Private Sub TabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabMain.SelectedIndexChanged
        If TabMain.SelectedIndex = 2 Then
            CaricaAnteprima()
        End If
    End Sub

    Private Sub txtPrezzoRiv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrezzoRiv.TextChanged
        If sender.text.length = 0 Then
            sender.text = "0"
        Else
            'calcolo iva e totale
            Dim Prezzo As Decimal = 0
            Try
                Prezzo = CDec(txtPrezzoRiv.Text)
            Catch ex As Exception

            End Try
            Dim Iva As Decimal = FormerHelper.Finanziarie.CalcolaIva(Prezzo)
            'Dim Iva As String = CDbl(txtPrezzo.Text) * FormerHelper.Finanziarie.GetPercentualeIva / 100
            Dim Totale As Decimal = Prezzo + Iva

            lblIvaRiv.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Iva)
            lblTotRiv.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Totale)
        End If

    End Sub

    Private Sub btnSelCat_Click(sender As Object, e As EventArgs) Handles btnSelCat.Click
        Sottofondo()

        Dim f As New frmSelectCat

        Dim Ris As Integer = f.SelezionaCategoria(lblCat.Tag)
        If Ris Then
            Dim C As New CatProd
            C.Read(Ris)
            lblCat.Text = C.Descrizione
            lblCat.Tag = Ris
            C = Nothing
        End If
        f = Nothing

        Sottofondo()

    End Sub

End Class