Imports FormerDALSql
Imports FW = FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports System.Xml.Serialization
Imports System.IO
Imports FormerConfig
Imports FormerWebLabeling
Imports FormerBusinessLogic

Public Class frmVoceRubrica
    'Inherits baseFormInternaRedim
    'Public formSopra As cFormSopra
    Private _VoceRub As VoceRubrica
    Private _Ris As Integer = 0

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub CaricaTipoDoc()

        Dim L As New List(Of cEnum)
        Dim x As New cEnum
        'x.Id = 0
        'x.Descrizione = "Nessuno"

        'L.Add(x)

        x = New cEnum
        x.Id = enTipoDocumento.Preventivo
        x.Descrizione = "Preventivo"

        L.Add(x)

        x = New cEnum
        x.Id = enTipoDocumento.DDT
        x.Descrizione = "DDT"

        L.Add(x)

        x = New cEnum
        x.Id = enTipoDocumento.Fattura
        x.Descrizione = "Fattura"

        L.Add(x)

        cmbTipoDoc.DataSource = L

        MgrControl.SelectIndexComboEnum(cmbTipoDoc, 0)

    End Sub

    Private Sub CaricaCombo()

        'qui devo cambiare la gestione dei corrieri con il metodo di pagamento predefinito per questa persona

        'Dim Corriere As New CorrieriDAO

        'cmbCorriere.DataSource = Corriere.GetAll("Descrizione", False)
        'cmbCorriere.ValueMember = "IdCorriere"
        'cmbCorriere.DisplayMember = "Descrizione"

        Dim lIVA As New List(Of cEnum)
        lIVA.Add(New cEnum(enEsigibilitaIVA.Immediata, "Immediata"))
        lIVA.Add(New cEnum(enEsigibilitaIVA.Differita, "Differita"))
        lIVA.Add(New cEnum(enEsigibilitaIVA.SplitPayment, "Split Payment"))

        cmbEsigiblitaIVA.DisplayMember = "Descrizione"
        cmbEsigiblitaIVA.ValueMember = "Id"
        cmbEsigiblitaIVA.DataSource = lIVA

        Dim lTipo As New List(Of cEnum)
        lTipo.Add(New cEnum(enTipoRubrica.Cliente, "Cliente"))
        lTipo.Add(New cEnum(enTipoRubrica.Rivenditore, "Rivenditore"))

        cmbTipo.DisplayMember = "Descrizione"
        cmbTipo.ValueMember = "Id"
        cmbTipo.DataSource = lTipo


        Dim l As List(Of MetodoConsegna) = MgrMetodiConsegna.Corrieri
        cmbCorriere.DataSource = l
        cmbCorriere.ValueMember = "IdMetodoConsegna"
        cmbCorriere.DisplayMember = "Descrizione"

        Using PM As New TipoPagamentiDAO
            cmbPagam.DataSource = PM.GetAll(LFM.TipoPagamento.IdTipoPagam, False)
            cmbPagam.ValueMember = "IdTipoPagam"
            cmbPagam.DisplayMember = "TipoPagam"
        End Using

        'Using x As New cGruppiColl
        '    Dim dtListaScelti As DataTable

        '    dtListaScelti = x.Lista(True)

        '    cmbGruppo.DisplayMember = "Nome"
        '    cmbGruppo.ValueMember = "IdGruppo"
        '    cmbGruppo.DataSource = dtListaScelti

        'End Using

        Using Mgr As New ZoneDAO()
            Dim Lst As List(Of Zona) = Mgr.GetAll(LFM.Zona.Descrizione, True)
            cmbZona.DataSource = Lst
            cmbZona.DisplayMember = "Descrizione"
            cmbZona.ValueMember = "Id"
        End Using

        'Using rc As New VociRubricaDAO
        '    cmbAgente.DataSource = rc.ListaCombo(enTipoRubrica.Agente, False)
        '    cmbAgente.DisplayMember = "Nominativo"
        '    cmbAgente.ValueMember = "IdRub"
        'End Using

        'Using mgr As New ProvinceDAO
        '    cmbProv.DataSource = mgr.GetAll("Cod")
        '    cmbProv.DisplayMember = "Riassunto"
        '    cmbProv.ValueMember = "Id"

        'End Using


        cmbNazione.DisplayMember = "Riassunto"
        cmbNazione.ValueMember = "IdNazione"
        cmbNazione.DataSource = MgrNazioni.GetLista()

        Using mgr As New CategContabiliDAO
            Dim lC As List(Of CategContabile) = mgr.FindAll(New LUNA.LunaSearchOption With {.AddEmptyItem = True, .OrderBy = "Tipocat,NomeCat"},
                                                            New LUNA.LunaSearchParameter(LFM.CategContabile.TipoCat, enTipoVoceContab.VoceAcquisto))
            cmbCategoriaFornitore.DisplayMember = "Riassunto"
            cmbCategoriaFornitore.ValueMember = LFM.CategContabile.IdCatContab.Name
            cmbCategoriaFornitore.DataSource = lC
        End Using


    End Sub

    'Private Sub CaricaGruppi()

    '    'carico la lista delle lavorazioni 

    '    Using x As New cGruppiColl
    '        Dim dtListaScelti As DataTable
    '        Dim dtListaDisp As DataTable

    '        dtListaScelti = x.ListaGruppiScelti(_VoceRub.IdRub)

    '        lstGruppiScelti.DisplayMember = "Nome"
    '        lstGruppiScelti.ValueMember = "IdGruppo"
    '        lstGruppiScelti.DataSource = dtListaScelti

    '        dtListaDisp = x.ListaGruppiDisp(_VoceRub.IdRub)

    '        lstGruppiDisp.DisplayMember = "Nome"
    '        lstGruppiDisp.ValueMember = "IdGruppo"
    '        lstGruppiDisp.DataSource = dtListaDisp

    '    End Using

    'End Sub

    Friend Function Carica(ByVal IdRub As Integer) As Integer

        Dim VoceRub As New VoceRubrica
        VoceRub.Read(IdRub)

        Using m As New VociRubricaDAO
            lblScopertoAttuale.Text = m.CalcolaScopertoOld(VoceRub)
        End Using
        _Carica(VoceRub)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub _Carica(ByVal VoceRub As VoceRubrica)
        _VoceRub = VoceRub

        'operazioni preliminari

        toolTipHelp.SetToolTip(pctAlertCodFisc, "I dati inseriti risultano già presenti in archivio!")
        toolTipHelp.SetToolTip(pctAlertPiva, "I dati inseriti risultano già presenti in archivio!")
        toolTipHelp.SetToolTip(pctAlertCogn, "I dati inseriti risultano già presenti in archivio!")
        toolTipHelp.SetToolTip(pctAlertRagSoc, "I dati inseriti risultano già presenti in archivio!")

        CaricaTipoDoc()

        CaricaCombo()

        If _VoceRub.IsFornitore = enSiNo.Si Then
            lblTipo.Text = "Fornitore"
        Else
            Select Case _VoceRub.Tipo
                'Case enTipoRubrica.Agente
                '    lblTipo.Text = "Agente"
                Case enTipoRubrica.Rivenditore
                    lblTipo.Text = "Rivenditore"
                    lblTipo.BackColor = FormerColori.ColoreRubricaRivenditore
                Case enTipoRubrica.Cliente
                    'pnlAgente.Visible = True
                    lblTipo.BackColor = FormerColori.ColoreRubricaCliente
            End Select
        End If

        'If _VoceRub.IsFornitore = enSiNo.Si Then 'Tipo = enTipoRubrica.Fornitore Then

        '    'si tratta di un fornitore
        '    lblTipo.Text = "Fornitore"
        '    TabMain.TabPages.Remove(tbOrdini)
        '    TabMain.TabPages.Remove(tbListino)
        '    'TabMain.TabPages.Remove(tbMoney)
        '    pctTipo.Image = Former.My.Resources.icoForn
        '    UcRisorse.IdRub = _VoceRub.IdRub
        '    UcStoricoAcquisti.IdForn = _VoceRub.IdRub

        '    cmbCorriere.Visible = False
        '    lblCorriere.Visible = False

        '    'cmbPagam.Visible = False
        '    'lblPagam.Visible = False

        '    chkAssRilIntMitt.Visible = False
        '    chkStampaAutoDoc.Visible = False

        '    lblTipo.BackColor = Color.LightGray
        '    pctTipo.BackColor = Color.LightGray

        'Else
        '    'qui si tratta di un cliente
        '    TabMain.TabPages.Remove(tbRisorse)
        '    TabMain.TabPages.Remove(tpStorico)
        '    'TabMain.TabPages.Remove(tbOrdini)
        '    'TabMain.TabPages.Remove(tbMoney)

        '    Select Case _VoceRub.Tipo
        '        'Case enTipoRubrica.Agente
        '        '    lblTipo.Text = "Agente"
        '        Case enTipoRubrica.Rivenditore
        '            lblTipo.Text = "Rivenditore"
        '            lblTipo.BackColor = FormerColori.ColoreRubricaRivenditore
        '        Case enTipoRubrica.Cliente
        '            'pnlAgente.Visible = True
        '            lblTipo.BackColor = FormerColori.ColoreRubricaCliente
        '    End Select
        '    pctTipo.BackColor = lblTipo.BackColor

        'End If
        lblTipo.Text = lblTipo.Text.ToUpper

        If _VoceRub.IdRub Then
            'qui ricarico i dati 
            If _IdInSostituzione Then
                _VoceRub.IdRub = 0
            End If

            txtIdCli.Text = _VoceRub.IdRub
            txtChiave.Text = _VoceRub.CalcolaChiave


            'If _VoceRub.Tipo <> enTipoRubrica.Fornitore Then PanelIdCli.Visible = True
            txtRagSoc.Text = _VoceRub.RagSoc
            txtCognome.Text = _VoceRub.Cognome
            txtNome.Text = _VoceRub.Nome
            txtInd.Text = _VoceRub.Indirizzo

            MgrControl.SelectIndexCombo(cmbNazione, _VoceRub.IdNazione)
            txtCAP.Text = _VoceRub.CAP

            txtCodFisc.Text = _VoceRub.CodFisc
            txtPiva.Text = _VoceRub.Piva
            txtTel.Text = _VoceRub.Tel
            txtFax.Text = _VoceRub.Fax
            txtCel.Text = _VoceRub.Cellulare
            txtAltroTel.Text = _VoceRub.AltroTel
            txtMail.Text = _VoceRub.Email
            txtMailAdmin.Text = _VoceRub.EmailAdmin
            txtWeb.Text = _VoceRub.SitoWeb
            txtScopertoMax.Text = _VoceRub.ScopertoMax
            txtPrefissoIVA.Text = _VoceRub.PrefissoPiva
            If txtPrefissoIVA.Text.Length = 0 Then txtPrefissoIVA.Text = "IT"

            txtPEC.Text = _VoceRub.Pec
            txtSDI.Text = _VoceRub.CodiceSDI

            If _VoceRub.DisattivaAccessoSito = enSiNo.Si Then chkDisattivaAccesso.Checked = True

            txtTag.Text = _VoceRub.tag
            'cmbPagam.Text = _VoceRub.Pagamento
            'cmbPagam.SelectedIndex = _VoceRub.IdPagamento
            'cmbTipo.SelectedIndex = _VoceRub.Tipo - 1

            MgrControl.SelectIndexComboEnum(cmbTipo, _VoceRub.Tipo)

            txtIndConsOld.Text = _VoceRub.IndCons

            CaricaIndirizziAlternativi()

            MgrControl.SelectIndexComboEnum(cmbTipoDoc, _VoceRub.TipoDoc)
            MgrControl.SelectIndexComboEnum(cmbEsigiblitaIVA, _VoceRub.EsigibilitaIva)
            MgrControl.SelectIndexCombo(cmbPagam, _VoceRub.IdPagamento)
            If _VoceRub.IdNazione = FormerConst.Culture.IdItalia Then
                MgrControl.SelectIndexCombo(cmbLocalita, _VoceRub.IdComune)
            Else
                cmbLocalita.Text = _VoceRub.Citta
            End If

            'txtCitta.Text = _VoceRub.Citta
            '            MgrControl.SelectIndexCombo(cmbProv, _VoceRub.IdProvincia)

            txtTelRif.Text = _VoceRub.TelRif
            txtAltroTelRif.Text = _VoceRub.AltroTelRif
            txtCelRif.Text = _VoceRub.CellulareRif
            txtFaxRif.Text = _VoceRub.FaxRif

            If _VoceRub.StampaAutomaticaDocumenti = enSiNo.Si Then chkStampaAutoDoc.Checked = True
            If _VoceRub.AssRilIntMitt = enSiNo.Si Then chkAssRilIntMitt.Checked = True

            If _VoceRub.BigliettoVisita.Length Then
                If FileIO.FileSystem.FileExists(_VoceRub.BigliettoVisita) Then
                    txtAnteprima.Text = _VoceRub.BigliettoVisita
                    pctBiglVisit.Image = Image.FromFile(_VoceRub.BigliettoVisita)
                Else
                    MessageBox.Show("Il cliente ha associato un biglietto da visita che non è più presente, il biglietto da visita verrà annullato", "Former", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _VoceRub.BigliettoVisita = ""
                End If

            End If
            MgrControl.SelectIndexCombo(cmbCorriere, _VoceRub.IdCorriere)
            MgrControl.SelectIndexCombo(cmbZona, _VoceRub.IdZona)
            MgrControl.SelectIndexCombo(cmbAgente, _VoceRub.IdAge)
            MgrControl.SelectIndexCombo(cmbCategoriaFornitore, _VoceRub.IdCatContab)

            If _VoceRub.IsFornitore = enSiNo.Si Then
                chkIsFornitore.Checked = True
                UcMagazzinoDecodificaVociCosto.IdFornitore = _VoceRub.IdRub
            Else
                TabMain.TabPages.Remove(tpDecodificaVociCosto)
            End If

            UcCoupon.IdRub = _VoceRub.IdRub
            UcOrdini.IdRub = _VoceRub.IdRub
            UcOrdini.Carica()

            UcCoupon.Carica()
            UcFatture.IdRub = _VoceRub.IdRub
            UcFatture.Carica()

            UcRubmark.IdRub = _VoceRub.IdRub
            'CaricaGruppi()

            UcPreventiviMail.IdRub = _VoceRub.IdRub

            Using m As New VociRubricaDAO
                lblScopertoAttuale.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(m.CalcolaScopertoOld(VoceRub))
            End Using

            If _VoceRub.IdUtOnline = 0 Then
                dgIndirizzi.Enabled = False
                btnIndPredef.Enabled = False
                btnNuovoIndirizzo.Enabled = False
                BtnModificaInd.Enabled = False

            End If

            Dim Provenienza As String = String.Empty

            If _VoceRub.Sorgente = "W" Then
                Provenienza = "Registrato dal sito"
            ElseIf _VoceRub.Sorgente = "G" Then
                Provenienza = "Inserito nel gestionale"
            ElseIf _VoceRub.Sorgente = "F" Then
                Provenienza = "Registrato da Fattura"
            Else
                Provenienza = "Importato dal vecchio database"
            End If

            If _VoceRub.DataIns <> Date.MinValue Then
                Provenienza &= " il " & _VoceRub.DataIns.ToString("dd/MM/yyyy")
            End If

            lblProvenienza.Text = Provenienza

            If _VoceRub.AbilitaInserimentoManualeDoc = enSiNo.Si Then chkInserimentoManualeFatture.Checked = True
            If _VoceRub.RegistraAutomaticamentePagamenti = enSiNo.Si Then chkAutoRegisterPagamento.Checked = True

            If Not _VoceRub.SostituitaDa Is Nothing Then
                'QUI DEVO BLOCCARE TUTTO
                txtRagSoc.Enabled = False
                txtNome.Enabled = False
                txtCognome.Enabled = False
                txtInd.Enabled = False
                txtCAP.Enabled = False
                cmbNazione.Enabled = False
                cmbLocalita.Enabled = False


                txtSDI.Enabled = False
                txtMail.Enabled = False
                txtMailAdmin.Enabled = False

                txtPiva.Enabled = False
                txtPrefissoIVA.Enabled = False
                txtCodFisc.Enabled = False

                lnkRubricaLinked.Visible = True
                lnkRubricaLinked.Tag = _VoceRub.SostituitaDa.IdRub
                lnkRubricaLinked.Text = "SOSTITUITA DA: " & _VoceRub.SostituitaDa.Nominativo

            Else
                If Not _VoceRub.Sostituisce Is Nothing Then
                    lnkRubricaLinked.Visible = True
                    lnkRubricaLinked.Tag = _VoceRub.Sostituisce.IdRub
                    lnkRubricaLinked.Text = "SOSTITUISCE : " & _VoceRub.Sostituisce.Nominativo
                End If

                If _VoceRub.IntestazioneBloccataLogicamente Then

                    txtRagSoc.Enabled = False
                    txtPiva.Enabled = False
                    txtPrefissoIVA.Enabled = False
                    txtCodFisc.Enabled = False

                End If

            End If

        Else

            'MgrControl.SelectIndexComboValore(cmbProv, "ROMA - ROMA")

            'qui si tratta di una voce nuova
            TabMain.TabPages.Remove(tbMoney)
            TabMain.TabPages.Remove(tbListino)
            TabMain.TabPages.Remove(tbOrdini)
            TabMain.TabPages.Remove(tbRisorse)
            'TabMain.TabPages.Remove(tpGruppi)
            TabMain.TabPages.Remove(tpAzMark)
            TabMain.TabPages.Remove(tpDecodificaVociCosto)
            cmbPagam.SelectedIndex = 0
            'pnlGruppo.Visible = True

            MgrControl.SelectIndexComboEnum(cmbTipo, _VoceRub.Tipo)

            MgrControl.SelectIndexCombo(cmbPagam, enMetodoPagamento.PayPal)
            MgrControl.SelectIndexComboEnum(cmbTipoDoc, enTipoDocumento.Fattura)
            MgrControl.SelectIndexCombo(cmbCorriere, enTipoCorriere.ConTariffa)
            MgrControl.SelectIndexComboEnum(cmbEsigiblitaIVA, enEsigibilitaIVA.Immediata)


            dgIndirizzi.Enabled = False
            btnIndPredef.Enabled = False
            btnNuovoIndirizzo.Enabled = False
            BtnModificaInd.Enabled = False

        End If




    End Sub

    Private _IdInSostituzione As Integer = 0

    Friend Function Carica(ByVal VoceRub As VoceRubrica,
                           Optional InSostituzione As Integer = 0) As Integer

        _IdInSostituzione = InSostituzione

        _Carica(VoceRub)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub btnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        SalvaVoce()

    End Sub

    Private Sub SalvaVoce()

        Dim OkEmail As Boolean = True
        Dim IndEmail As String = txtMail.Text.Trim

        If IndEmail <> FormerLib.FormerConst.EmailNonDisponibile Then
            Using mgr As New VociRubricaDAO
                Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Email, IndEmail),
                                                            New LUNA.LunaSearchParameter(LFM.VoceRubrica.IdRub, _VoceRub.IdRub, "<>"))
                If l.Count Then
                    OkEmail = False
                End If
            End Using
        End If

        If OkEmail Then
            If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim ComuneScelto As ComuneInElenco = Nothing
                If Not cmbLocalita.SelectedItem Is Nothing Then
                    ComuneScelto = cmbLocalita.SelectedItem
                Else
                    ComuneScelto = New ComuneInElenco
                End If

                Dim NazioneScelta As Nazione = cmbNazione.SelectedItem

                _VoceRub.RagSoc = txtRagSoc.Text
                _VoceRub.Cognome = txtCognome.Text
                _VoceRub.Nome = txtNome.Text
                _VoceRub.Indirizzo = txtInd.Text
                _VoceRub.IndCons = txtIndConsOld.Text
                _VoceRub.CodFisc = txtCodFisc.Text
                _VoceRub.Piva = txtPiva.Text
                _VoceRub.Tel = txtTel.Text
                _VoceRub.Fax = txtFax.Text
                _VoceRub.Cellulare = txtCel.Text
                _VoceRub.AltroTel = txtAltroTel.Text
                _VoceRub.Pagamento = cmbPagam.SelectedText
                _VoceRub.Email = txtMail.Text.Trim
                _VoceRub.EmailAdmin = txtMailAdmin.Text.Trim
                _VoceRub.SitoWeb = txtWeb.Text
                _VoceRub.ScopertoMax = IIf(txtScopertoMax.Text.Trim.Length, txtScopertoMax.Text, 0)
                _VoceRub.IdCorriere = cmbCorriere.SelectedValue
                _VoceRub.IdPagamento = cmbPagam.SelectedValue
                _VoceRub.IdZona = cmbZona.SelectedValue
                _VoceRub.IdAge = cmbAgente.SelectedValue

                _VoceRub.Tipo = DirectCast(cmbTipo.SelectedItem, cEnum).Id
                _VoceRub.EsigibilitaIva = DirectCast(cmbEsigiblitaIVA.SelectedItem, cEnum).Id

                _VoceRub.TipoDoc = cmbTipoDoc.SelectedValue
                _VoceRub.TelRif = txtTelRif.Text
                _VoceRub.AltroTelRif = txtAltroTelRif.Text
                _VoceRub.CellulareRif = txtCelRif.Text
                _VoceRub.FaxRif = txtFaxRif.Text
                _VoceRub.DisattivaAccessoSito = IIf(chkDisattivaAccesso.Checked, enSiNo.Si, enSiNo.No)
                _VoceRub.IsFornitore = IIf(chkIsFornitore.Checked, enSiNo.Si, enSiNo.No)

                Dim IdOldCatContab As Integer = _VoceRub.IdCatContab
                _VoceRub.IdCatContab = cmbCategoriaFornitore.SelectedValue

                _VoceRub.CAP = txtCAP.Text
                _VoceRub.IdNazione = NazioneScelta.IdNazione
                If _VoceRub.IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
                    _VoceRub.IdComune = ComuneScelto.IDCap
                    _VoceRub.Citta = ComuneScelto.Comune
                    _VoceRub.Provincia = ComuneScelto.Provincia
                    _VoceRub.IdProvincia = ComuneScelto.ProvinciaSel.ID
                Else
                    _VoceRub.IdComune = 0
                    _VoceRub.IdProvincia = 0
                    _VoceRub.Provincia = String.Empty
                    _VoceRub.Citta = cmbLocalita.Text
                End If

                _VoceRub.tag = txtTag.Text.ToLower
                _VoceRub.StampaAutomaticaDocumenti = IIf(chkStampaAutoDoc.Checked, enSiNo.Si, enSiNo.No)
                _VoceRub.PrefissoPiva = txtPrefissoIVA.Text
                _VoceRub.AssRilIntMitt = IIf(chkAssRilIntMitt.Checked, enSiNo.Si, enSiNo.No)
                _VoceRub.CodiceSDI = txtSDI.Text
                _VoceRub.Pec = txtPEC.Text
                _VoceRub.AbilitaInserimentoManualeDoc = IIf(chkInserimentoManualeFatture.Checked, enSiNo.Si, enSiNo.No)
                _VoceRub.RegistraAutomaticamentePagamenti = IIf(chkAutoRegisterPagamento.Checked, enSiNo.Si, enSiNo.No)

                If _VoceRub.PrefissoPiva.Length = 0 Then
                    _VoceRub.PrefissoPiva = "IT"
                End If

                Dim ControlliValiditaOk As String = String.Empty

                If _VoceRub.Piva.Trim.Length <> 0 Then
                    If _VoceRub.PrefissoPiva = "IT" Then
                        If _VoceRub.Piva.Trim.Length <> 11 Then
                            ControlliValiditaOk = "La partita IVA deve essere di 11 caratteri senza spazi; " & ControlChars.NewLine
                        Else
                            'controllo validita partita Iva
                            If FormerHelper.Finanziarie.CheckPartitaIva(_VoceRub.Piva, _VoceRub.PrefissoPiva) = False Then
                                ControlliValiditaOk &= "La partita IVA non è formalmente valida; " & ControlChars.NewLine
                            End If
                        End If
                    End If
                End If

                If _VoceRub.CodFisc.Trim.Length <> 0 Then
                    'If _VoceRub.CodFisc.Trim.Length <> 11 And _VoceRub.CodFisc.Trim.Length <> 16 Then
                    '    ControlliValiditaOk &= "Il codice fiscale deve essere di 11 o 16 caratteri senza spazi; " & ControlChars.NewLine
                    'Else
                    If FormerHelper.Finanziarie.CheckCodiceFiscale(_VoceRub.CodFisc, NazioneScelta.Code) = False Then
                        ControlliValiditaOk &= "Il codice fiscale non è formalmente valido; " & ControlChars.NewLine
                    End If
                    'End If
                End If

                'If chkNoDatiFisc.Checked = False Then
                'If _VoceRub.CodFisc.Trim.Length = 0 And _VoceRub.Piva.Trim.Length = 0 Then
                '    ControlliValiditaOk &= "E' obbligatorio inserire il codice fiscale o la partita iva; " & ControlChars.NewLine
                'End If
                'End If

                If FormerHelper.Mail.IsValidEmailAddress(_VoceRub.Email) = False Then
                    ControlliValiditaOk &= "L'email non è formalmente valida; " & ControlChars.NewLine
                End If

                If _VoceRub.Pec.Trim.Length Then
                    If FormerHelper.Mail.IsValidEmailAddress(_VoceRub.Pec) = False Then
                        ControlliValiditaOk &= "La PEC non è formalmente valida; " & ControlChars.NewLine
                    End If
                End If

                If _VoceRub.IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
                    If _VoceRub.CAP.Length <> 5 Then ControlliValiditaOk &= "Inserire il CAP corretto; " & ControlChars.NewLine
                    If _VoceRub.IdComune = 0 Then ControlliValiditaOk &= "Selezionare la Località; " & ControlChars.NewLine
                Else
                    If _VoceRub.CAP.Length = 0 Then ControlliValiditaOk &= "Inserire il CAP corretto; " & ControlChars.NewLine
                    If _VoceRub.Citta = String.Empty Then ControlliValiditaOk &= "Inserire la Località; " & ControlChars.NewLine
                End If

                If _VoceRub.EsigibilitaIva = enEsigibilitaIVA.SplitPayment And _VoceRub.CodiceSDI.Length <> 6 Then
                    ControlliValiditaOk &= "Il codice SDI deve essere di 6 caratteri per SplitPayment"
                Else
                    If _VoceRub.EsigibilitaIva <> enEsigibilitaIVA.SplitPayment AndAlso
                        _VoceRub.CodiceSDI.Length > 0 AndAlso
                        _VoceRub.CodiceSDI.Length <> 7 Then
                        ControlliValiditaOk &= "Il codice SDI deve essere di 7 caratteri"
                    End If
                End If

                If _VoceRub.IdRub = 0 AndAlso _IdInSostituzione <> 0 Then
                    _VoceRub.IdRubricaLinked = _IdInSostituzione
                End If

                If ControlliValiditaOk = String.Empty Then
                    If _VoceRub.IsValid Then

                        Dim OkCampiImportanti As Boolean = True

                        If _VoceRub.Email.Length = 0 OrElse
                           _VoceRub.Email = FormerConst.EmailNonDisponibile OrElse
                           _VoceRub.Tel.Length = 0 OrElse
                           _VoceRub.Tel = "0" OrElse
                           _VoceRub.IdCatContab = 0 Then
                            If MessageBox.Show("Alcuni dati importanti non risultano valorizzati (Email, Telefono, Categoria). Vuoi salvare comunque?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                OkCampiImportanti = False
                            End If
                        End If

                        If OkCampiImportanti Then
                            If txtAnteprima.Text.Length Then
                                If _VoceRub.BigliettoVisita <> txtAnteprima.Text Then
                                    Dim NuovoNomeFile As String = ""
                                    Dim rnd As New Random
                                    Dim Pref As String = rnd.Next(0, 99999)
                                    NuovoNomeFile = FormerPath.PathTemp & "BV_" & FormerLib.FormerHelper.File.EstraiNomeFile(txtAnteprima.Text, Pref)
                                    'FileCopy(txtFile.Text, NuovoNomeFile)
                                    'ResizeImg(txtFile.Text, NuovoNomeFile)
                                    MgrIO.FileCopia(Me, txtAnteprima.Text, NuovoNomeFile)

                                    _VoceRub.BigliettoVisita = NuovoNomeFile
                                End If
                            End If
                            _VoceRub.LastUpdate = Now

                            If _VoceRub.IdRub = 0 Then
                                _VoceRub.DataIns = Now
                                _VoceRub.Sorgente = "G"
                            End If

                            'If _VoceRub.Sorgente = "F" Then
                            '    If MessageBox.Show("La voce in rubrica risulta salvata automaticamente da una fattura ricevuta. Vuoi validare la voce come approvata?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            '        _VoceRub.Sorgente = "G"
                            '    End If
                            'End If

                            If _VoceRub.Sorgente = "F" Then
                                'qui proviene da una fattura elettronica
                                'se ho messo la categoria levo la F e metto la G
                                If _VoceRub.IdCatContab Then
                                    _VoceRub.Sorgente = "G"
                                End If
                            End If

                            _VoceRub.Save()

                            'qui vado a salvare tutti i documeunti di acquisto per cambiare categoria in caso
                            If IdOldCatContab <> _VoceRub.IdCatContab Then

                                'aggiorno tutti i costi 
                                Using mgr As New CostiDAO
                                    mgr.AggiornaCategoriaFromRubrica(_VoceRub.IdRub, _VoceRub.IdCatContab, IdOldCatContab)
                                End Using

                            End If

                            'If pnlGruppo.Visible Then
                            '    If cmbGruppo.SelectedIndex <> 0 Then
                            '        'qui devo salvare il gruppo per la prima volta
                            '        Using x As New cGruppiColl
                            '            x.AssociaRubGruppo(_VoceRub.IdRub, cmbGruppo.SelectedValue)
                            '        End Using
                            '    End If
                            'End If

                            _Ris = 1
                            Close()
                        End If



                    Else
                        MessageBox.Show("Attenzione:" & vbNewLine & " - I campi Ragione Sociale o Cognome sono obbligatori;", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Impossibile salvare la voce in rubrica per i seguenti motivi: " & ControlChars.NewLine & ControlliValiditaOk, PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            MessageBox.Show("Attenzione:" & vbNewLine & " - L'indirizzo email inserito è già associato ad un'altra voce in Rubrica;", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtPiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPiva.KeyPress

        MgrControl.ControlloNumerico(sender, e, True)

        'Dim x As Char = vbBack

        'If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> x Then

        '    e.Handled = True

        'End If

    End Sub

    Private Sub txtCAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCAP.KeyPress
        Dim x As Char = vbBack
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> x Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtScopertoMax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScopertoMax.KeyPress
        Dim x As Char = vbBack
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> x Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtCognome_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCognome.TextChanged
        Using x As New VociRubricaDAO

            If x.Exists(txtCognome.Text, enTipoRicercaRub.Cognome, _VoceRub.IdRub) Then
                pctAlertCogn.Visible = True
            Else
                pctAlertCogn.Visible = False
            End If

        End Using
    End Sub

    Private Sub txtCodFisc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodFisc.TextChanged
        Using x As New VociRubricaDAO

            If x.Exists(txtCodFisc.Text, enTipoRicercaRub.CodiceFiscale, _VoceRub.IdRub) Then
                pctAlertCodFisc.Visible = True
            Else
                pctAlertCodFisc.Visible = False
            End If

        End Using
    End Sub

    Private Sub txtPiva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiva.TextChanged

        Using x As New VociRubricaDAO
            If txtPiva.Text.Length Then
                If x.Exists(txtPiva.Text, enTipoRicercaRub.PartitaIva, _VoceRub.IdRub) Then
                    pctAlertPiva.Visible = True
                Else
                    pctAlertPiva.Visible = False
                End If
            Else
                pctAlertPiva.Visible = False
            End If

        End Using

    End Sub

    'Private Sub txtRagSoc_LostFocus(sender As Object, e As EventArgs) Handles txtRagSoc.LostFocus, txtCognome.LostFocus, txtNome.LostFocus
    '    sender.text = sender.Text.TrimEnd(" ")
    'End Sub

    Private Sub txtPiva_LostFocus(sender As Object, e As EventArgs) Handles txtPiva.LostFocus, txtCodFisc.LostFocus, txtMail.LostFocus, txtMailAdmin.LostFocus,
        txtRagSoc.LostFocus, txtCognome.LostFocus, txtNome.LostFocus, txtInd.LostFocus, txtWeb.LostFocus, txtIndConsOld.LostFocus, txtCAP.LostFocus
        sender.text = sender.Text.Trim(" ")
    End Sub

    Private Sub txtRagSoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRagSoc.TextChanged

        'controllo che non sia presente
        Using x As New VociRubricaDAO

            If x.Exists(txtRagSoc.Text, enTipoRicercaRub.RagioneSociale, _VoceRub.IdRub) Then
                pctAlertRagSoc.Visible = True
            Else
                pctAlertRagSoc.Visible = False
            End If

        End Using

    End Sub

    Private Sub frmRub_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    'Private Sub btnScegli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim IdGruppoSel As Integer = 0

    '    If lstGruppiDisp.SelectedIndex <> -1 Then

    '        IdGruppoSel = lstGruppiDisp.SelectedValue

    '    End If

    '    If IdGruppoSel Then
    '        If MessageBox.Show("Confermi l'aggiunta di questo contatto al gruppo selezionato?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '            Using x As New cGruppiColl
    '                x.AssociaRubGruppo(_VoceRub.IdRub, IdGruppoSel)

    '            End Using
    '            MessageBox.Show("Il contatto è ora nel gruppo scelto!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            CaricaGruppi()

    '        End If

    '    Else
    '        MessageBox.Show("Selezionare un gruppo tra quelli disponibili!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '    End If

    'End Sub

    'Private Sub btnTogli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim IdGruppoSel As Integer = 0

    '    If lstGruppiScelti.SelectedIndex <> -1 Then

    '        IdGruppoSel = lstGruppiScelti.SelectedValue

    '    End If

    '    If IdGruppoSel Then
    '        If MessageBox.Show("Confermi l'eliminazione di questo contatto dal gruppo selezionato?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '            Using x As New cGruppiColl
    '                x.TogliRubGruppo(_VoceRub.IdRub, IdGruppoSel)
    '            End Using
    '            MessageBox.Show("Il contatto è stato tolto dal gruppo!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            CaricaGruppi()

    '        End If

    '    Else
    '        MessageBox.Show("Selezionare un gruppo tra quelli scelti!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '    End If

    'End Sub

    Private Sub btnSfogliaAnte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSfogliaAnte.Click
        Dim path As String = ""

        OpenFileDialogAnte.ShowDialog()
        If OpenFileDialogAnte.FileName.Length Then
            path = OpenFileDialogAnte.FileName

            pctBiglVisit.Image = Image.FromFile(path)
            txtAnteprima.Text = path
        End If
    End Sub

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        Sottofondo()
        StampaBuffer(_VoceRub.SituazioneContabile(, True))
        Sottofondo()
    End Sub

    Private Sub lnkSitEcon_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSitEcon.LinkClicked

        If MessageBox.Show("Confermi l'invio della email con la situazione contabile al cliente?", "Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            If _VoceRub.Email.Length Then
                Dim Titolo As String = "Situazione contabile aggiornata " & _VoceRub.RagSocNome
                Dim Testo As String = "Gentile Cliente, <BR><BR>al fine di agevolare le operazioni amministrative Le inviamo la sua situazione contabile aggiornata. "

                'TODO: INSERIRE COORDINATE BANCARIE
                '                Testo &= "<br><br>Coordinate per Bonifico Bancario:<br><br>BANCA: <b>CARIPARMA</b><br>IBAN: <b>IT 55 A 06230 05089 0000 6337 9643</b>"

                Testo &= "<BR><BR><B>Amministrazione Former</B><BR>06.30884518<BR><A HREF=""mailto:amministrazione@tipografiaformer.com"">amministrazione@tipografiaformer.com</A><BR><BR>"
                Dim IndDest As String = _VoceRub.EmailAmministrativa

                Testo &= _VoceRub.SituazioneContabile(False)
                FormerHelper.Mail.InviaMail(Titolo, Testo, IndDest)
                'SendMail(IndDest, Titolo, Testo, "", True)
                MessageBox.Show("Email Inviata!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Email del cliente non inserita nella rubrica!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
    End Sub

    Private Sub lnkInviaCodici_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkInviaCodici.LinkClicked
        If txtMail.Text.Length Then
            If MessageBox.Show("Confermi l'invio della mail di rigenerazione della password?", "Rigenerazione Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                'Dim BodyMail As String = "Gentile Cliente,<br><br> ringraziandoVi per l'attenzione, Vi inviamo le Vostre credenziali di accesso al nostro sito <a href=""http://www.tipografiaformer.it"">http://www.tipografiaformer.it</a> sono:<br><BR>"


                'BodyMail &= "Id Cliente: <B>" & txtIdCli.Text & "</B><BR><BR>"

                'BodyMail &= "Chiave: <B>" & txtChiave.Text & "</B><BR><BR>"


                ''BodyMail = sw.ReadToEnd()

                ''sw.Close()
                ''sw = Nothing
                ''btnOk.Enabled = False
                'SendMail(txtMail.Text, "Invio codici accesso sito TipografiaFormer.it", BodyMail, "", True)

                Dim Pt As New My.Templates.MailRigeneraPwd
                Pt.Email = txtMail.Text
                Dim Buffer As String = Pt.TransformText

                Try
                    FormerHelper.Mail.InviaMail("Richiesta di rigenerazione Password", Buffer, txtMail.Text)
                Catch ex As Exception

                End Try

                MessageBox.Show("Email inviata", "Invio automatico", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Close()
            End If
        End If
    End Sub

    Private Sub pctMappa_Click(sender As Object, e As EventArgs) Handles pctMappa.Click

        'DA RIVEDERE

        Dim Indirizzo As String = String.Empty
        If txtInd.Text.Length Then
            If cmbLocalita.SelectedValue Then
                Dim val As ComuneInElenco = DirectCast(cmbLocalita.SelectedItem, ComuneInElenco)
                Indirizzo = txtInd.Text & " " & val.ProvinciaSel.PROVINCIA
            End If
        End If
        If Indirizzo.Length Then
            Sottofondo()
            Using f As New frmConsegnaPercorso
                f.Carica(Indirizzo, False)
            End Using
            Sottofondo()
        Else
            MessageBox.Show("Compila l'indirizzo e la Città per avere la mappa")
        End If
    End Sub

    Private Sub lnkLog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLog.LinkClicked

        Dim Path As String = FormerPath.PathLogRubrica & _VoceRub.IdRub & ".log.txt"

        If FileIO.FileSystem.FileExists(Path) Then
            FormerHelper.File.ShellExtended(Path)
        Else
            MessageBox.Show("Il file di Log della voce in Rubrica non è presente")
        End If

    End Sub

    Private Sub txtMail_LostFocus(sender As Object, e As EventArgs) Handles txtMail.LostFocus
        txtMail.Text = txtMail.Text.Trim
    End Sub

    Private Sub lnkEmailNonDisp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEmailNonDisp.LinkClicked
        If MessageBox.Show("Sicuro di voler assegnare l'indirizzo email a NON DISPONIBILE?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            txtMail.Text = FormerLib.FormerConst.EmailNonDisponibile
        End If
    End Sub

    Private Sub CaricaLocalita(Cap As String)
        Dim IdComune As Integer = 0
        Using Mgr As New ElencoComuniDAO
            Dim l As List(Of ComuneInElenco) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Comune", .AddEmptyItem = True},
                                                           New LUNA.LunaSearchParameter(LFM.ComuneInElenco.CAP, Cap))
            If l.Count Then
                cmbLocalita.DisplayMember = "Riassunto"
                cmbLocalita.ValueMember = "IdCap"
                cmbLocalita.DataSource = l
            Else
                cmbLocalita.Items.Clear()
            End If
        End Using
    End Sub

    Private Sub txtCAP_TextChanged(sender As Object, e As EventArgs) Handles txtCAP.TextChanged

        Dim CapScelto As String = txtCAP.Text

        If cmbNazione.SelectedValue = FormerLib.FormerConst.Culture.IdItalia Then

            If CapScelto.Length = 5 Then

                'qui provo a caricare le località

                CaricaLocalita(CapScelto)
            Else
                cmbLocalita.DataSource = Nothing
            End If
        Else
            cmbLocalita.DataSource = Nothing

        End If

    End Sub

    Private Sub btnNuovoIndirizzo_Click(sender As Object, e As EventArgs) Handles btnNuovoIndirizzo.Click
        Sottofondo()
        Using x As New frmIndirizzo
            Dim IdRub As Integer = _VoceRub.IdRub
            Dim Ris As Integer = x.Carica(IdRub)
            If Ris Then
                CaricaIndirizziAlternativi()
            End If
        End Using
        Sottofondo()
    End Sub

    Private Sub CaricaIndirizziAlternativi()

        Dim lstIndirizzi As List(Of Indirizzo) = _VoceRub.Indirizzi(True)
        lstIndirizzi.RemoveAll(Function(x) x.IDIndirizzo = 0)
        lstIndirizzi.Sort(AddressOf FormerListSorter.IndirizziSorter.SortDefault)

        dgIndirizzi.AutoGenerateColumns = False
        dgIndirizzi.DataSource = lstIndirizzi

    End Sub

    Private Sub BtnModificaInd_Click(sender As Object, e As EventArgs) Handles BtnModificaInd.Click

        If dgIndirizzi.SelectedRows.Count Then
            Dim I As Indirizzo = DirectCast(dgIndirizzi.SelectedRows(0).DataBoundItem, Indirizzo)
            Sottofondo()
            Using x As New frmIndirizzo
                Dim IdRub As Integer = _VoceRub.IdRub
                Dim IdIndirizzo As Integer = I.IDIndirizzo
                Dim Ris As Integer = x.Carica(IdRub, IdIndirizzo)
                If Ris Then
                    CaricaIndirizziAlternativi()
                End If
            End Using
            Sottofondo()
        End If
    End Sub

    Private Sub btnIndPredef_Click(sender As Object, e As EventArgs) Handles btnIndPredef.Click

        If dgIndirizzi.SelectedRows.Count Then
            Dim I As Indirizzo = DirectCast(dgIndirizzi.SelectedRows(0).DataBoundItem, Indirizzo)
            If I.Status Then
                MessageBox.Show("Non puoi rendere predefinito un indirizzo non attivo!")
            Else
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Using tbO As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox
                        Try

                            tb.TransactionBegin()
                            tbO.TransactionBegin()

                            Using mgr As New IndirizziDAO
                                mgr.RendiPredefinito(_VoceRub.IdRub, I.IDIndirizzo)
                            End Using
                            Using mgr As New FW.IndirizziDAO
                                mgr.RendiPredefinito(_VoceRub.IdUtOnline, I.IdIndOnline)
                            End Using

                            tb.TransactionCommit()
                            tbO.TransactionCommit()

                        Catch ex As Exception
                            tb.TransactionRollBack()
                            tbO.TransactionRollBack()
                        End Try
                    End Using
                End Using

                CaricaIndirizziAlternativi()
            End If
        End If

    End Sub

    Private Sub pctCheck_Click(sender As Object, e As EventArgs) Handles pctCheck.Click
        Cursor = Cursors.WaitCursor
        Try

            Dim ris As RisValidazioneIndirizzo

            If cmbNazione.SelectedValue = FormerLib.FormerConst.Culture.IdItalia Then
                Dim ComuneScelto As ComuneInElenco = Nothing
                If Not cmbLocalita.SelectedItem Is Nothing Then
                    ComuneScelto = cmbLocalita.SelectedItem
                Else
                    ComuneScelto = New ComuneInElenco
                End If

                ris = FormerWebLabeling.MgrWebLabelingGls.CheckAddress(ComuneScelto.Provincia,
                                                                   txtCAP.Text,
                                                                   ComuneScelto.Comune,
                                                                   txtInd.Text,
                                                                   cmbNazione.SelectedValue)

                If ris.Valido Then
                    MessageBox.Show("L'indirizzo inserito ha superato CORRETTAMENTE la validazione GLS")
                Else
                    Dim MessaggioErrore As String = String.Empty

                    MessaggioErrore = "L'indirizzo inserito NON ha superato la validazione GLS. Informazioni supplementari: " & ris.Messaggio
                    If ris.ListaIndirizziSuggeriti.Count Then
                        MessaggioErrore &= ControlChars.NewLine & ControlChars.NewLine & "Suggerimenti: "

                        For Each IndirizzoSing In ris.ListaIndirizziSuggeriti
                            MessaggioErrore &= IndirizzoSing & ControlChars.NewLine
                        Next

                    End If
                    MessageBox.Show(MessaggioErrore)

                End If
            Else
                MessageBox.Show("Non è possibile validare indirizzi ESTERI")
            End If


        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nel tentativo di validazione dell'indirizzo con GLS")
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub pctHelpTag_Click(sender As Object, e As EventArgs) Handles pctHelpTag.Click

        MessageBox.Show("Inserisci i vari tag preceduti da cancelletto e separati da spazi. esempio: #shopexpo2017 #smau2017 #importante #etichette")

    End Sub

    Private Sub btnTag_Click(sender As Object, e As EventArgs) Handles btnTag.Click
        'qui carico tutti i tag disponibili distinti e mostro una form di riepilogo
        Dim Buffer As String = String.Empty

        Using mgr As New VociRubricaDAO
            Dim l As List(Of String) = mgr.GetAllTag

            For Each s As String In l
                Buffer &= s & ControlChars.NewLine
            Next

        End Using

        Sottofondo()
        Using f As New frmTextShow
            f.Carica(Buffer)
        End Using
        Sottofondo()
    End Sub

    Private Sub pctWhatsapp_Click(sender As Object, e As EventArgs) Handles pctWhatsapp.Click

        If txtCel.Text.Trim.Length < 8 Then

            Dim NumCel As String = txtCel.Text

            NumCel = "https://wa.me/39" & NumCel

            FormerHelper.File.ShellExtended(NumCel)

        Else
            MessageBox.Show("Inserire un numero di cellulare")
        End If

    End Sub

    Private Sub cmbNazione_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNazione.SelectedIndexChanged
        If cmbNazione.SelectedValue = FormerLib.FormerConst.Culture.IdItalia Then
            cmbLocalita.DropDownStyle = ComboBoxStyle.DropDownList
            txtCAP.Text = String.Empty
            txtCAP.Enabled = True
        Else
            cmbLocalita.DropDownStyle = ComboBoxStyle.Simple
            txtCAP.Text = FormerConst.Culture.CapEstero
            txtCAP.Enabled = False
        End If
        'txtCAP.Text = String.Empty
        cmbLocalita.DataSource = Nothing
        cmbLocalita.Text = String.Empty

        Using NazioneScelta As Nazione = cmbNazione.SelectedItem
            txtPrefissoIVA.Text = NazioneScelta.Code
        End Using

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub lnkUploadFatt_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUploadFatt.LinkClicked
        uploadfattureFTP()
    End Sub

    Private Sub uploadfattureFTP()

        If _VoceRub.IdRub Then
            If MessageBox.Show("Confermi l'upload di TUTTE le fatture di questo cliente sul sito? Saranno caricate solo quelle non presenti", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New RicaviDAO
                    Dim ListaRisultati As New List(Of RisCaricaOnlineFatturaPDF)
                    Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LSP(LFM.Ricavo.IdRub, _VoceRub.IdRub),
                                                           New LUNA.LSP(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & ")", "IN"))

                    For Each R As Ricavo In l
                        Try
                            ListaRisultati.Add(MgrFattureFE.CaricaOnlineFatturaPDF(R))
                        Catch ex As Exception

                        End Try
                    Next

                    Dim TotOk As Integer = ListaRisultati.FindAll(Function(x) x.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.Ok).Count
                    Dim TotKo As Integer = ListaRisultati.FindAll(Function(x) x.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.ErroreNellaFaseDiUpload Or x.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.FileLocaleNonPresente).Count

                    MessageBox.Show("Fatture caricate correttamente: " & TotOk & ". Fatture NON caricate per errori: " & TotKo)

                End Using
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub LnkPanoramicaLavori_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPanoramicaLavori.LinkClicked
        If _VoceRub.IdRub Then
            Sottofondo()
            Using f As New frmOrdiniPanoramica
                f.Carica(_VoceRub.IdRub)
            End Using
            Sottofondo()
        Else
            Beep()

        End If

    End Sub

    Private Sub LnkRubricaLinked_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRubricaLinked.LinkClicked
        Dim IdClicked As Integer = lnkRubricaLinked.Tag
        Sottofondo()
        Using f As New frmVoceRubrica
            f.Carica(IdClicked)
        End Using
        Sottofondo()
    End Sub
End Class