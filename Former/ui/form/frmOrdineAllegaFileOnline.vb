Imports FormerDALSql
Imports FW = FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerLib
Imports System.IO
Imports FormerBusinessLogicInterface
Imports FormerBusinessLogic
Imports FormerConfig
Imports FormerWebLabeling
Imports Telerik.WinControls.UI.Data

Friend Class frmOrdineAllegaFileOnline
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _IdOrdineOnline As Integer = 0
    Private _IdRubricaInt As Integer = 0
    Private _FronteRetro As Boolean = False

    Private _IdListinoBase As Integer = 0
    Private _AltezzaDaOrdine As Integer = 0
    Private _LarghezzaDaOrdine As Integer = 0
    Private _OrientamentoDaOrdine As Integer = 0

    Private _OrdineDiAltri As Boolean = False

    Private _TotaleFornitura As Decimal = 0

    Private _DataConsegnaOriginale As Date = Date.MinValue

    Private Sub CaricaCombo()

        'carico la rubrica
        'carico la combo dei clienti
        'Using cli As New VociRubricaDAO
        '    cmbCliente.ValueMember = "IdRub"
        '    cmbCliente.DisplayMember = "Nominativo"

        '    cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, True,,,,, True)
        'End Using
        cmbClienteSel.Carica(enTipoRubrica.Cliente, True,, True)

        cmbTipoRetro.ValueMember = "Id"
        cmbTipoRetro.DisplayMember = "Descrizione"

        Dim Voce As New cEnum
        Voce.Id = enTipoRetro.RetroDifferente
        Voce.Descrizione = "Fronte e Retro differenti"
        cmbTipoRetro.Items.Add(Voce)

        Voce = New cEnum
        Voce.Id = enTipoRetro.RetroUgualeFronte
        Voce.Descrizione = "Fronte e Retro uguali"
        cmbTipoRetro.Items.Add(Voce)

        Voce = New cEnum
        Voce.Id = enTipoRetro.RetroBianco
        Voce.Descrizione = "Retro Bianco"
        cmbTipoRetro.Items.Add(Voce)

        Voce = New cEnum
        Voce.Id = enTipoRetro.RetroNelFileFronte
        Voce.Descrizione = "Retro contenuto nel file Fronte"
        cmbTipoRetro.Items.Add(Voce)

        Using Corriere As New CorrieriDAO

            cmbCorriere.ValueMember = "IdCorriere"
            cmbCorriere.DisplayMember = "Descrizione"
            cmbCorriere.DataSource = Corriere.GetListaCorrieri() ' .FindAll("Descrizione", New LUNA.LunaSearchParameter("DisponibileOnline", enSiNo.Si))

        End Using

        Using PM As New TipoPagamentiDAO
            cmbTipoPagamento.DataSource = PM.GetAll(LFM.TipoPagamento.IdTipoPagam, False)
            cmbTipoPagamento.ValueMember = "IdTipoPagam"
            cmbTipoPagamento.DisplayMember = "TipoPagam"
        End Using

    End Sub

    Private _PrezzoRivenditore As Decimal = 0
    Private _PrezzoAlPubblico As Decimal = 0

    Private Function CalcolaPrezzi(O As FW.OrdineWeb,
                                   Qta As Single,
                                   QtaSecondaria As Single,
                                   NumeroPezzi As Integer,
                                   Optional Consigliato As Boolean = False) As RisPrezzoIntermedio
        'Dim QtaRichiesta As Integer = Convert.ToInt32(ddlQta.SelectedValue)
        'LRif.CaricaLavorazioniBase()

        O.L.CaricaLavorazioniBase()
        O.L.CaricaLavorazioniOpz()

        Dim listaBaseB As List(Of ILavorazioneB) = O.L.LavorazioniBaseB

        Dim listaOpz As List(Of FW.LavorazioneW) = O.ElencoLavorazioni
        Dim listaOpzB As New List(Of ILavorazioneB)

        For Each L As FW.LavorazioneW In listaOpz
            If listaBaseB.FindAll(Function(x) x.IdLavoro = L.IdLavoro).Count = 0 Then
                listaOpzB.Add(L)
            End If
        Next

        O.L.NumFacciate = O.Nfogli() * 2

        Dim Altezza As Integer = 0
        Dim Larghezza As Integer = 0

        If O.L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            Altezza = (O.Altezza)
            Larghezza = (O.Larghezza)
            'Qta = MgrCalcoliTecnici.CalcolaMq(O.L.LatoFissoRiferimento(Altezza, Larghezza),
            '                                       Qta,
            '                                       Altezza,
            '                                       Larghezza)
        ElseIf O.L.TipoPrezzo = enTipoPrezzo.SuFoglio Then
            Altezza = (O.Altezza)
            Larghezza = (O.Larghezza)



            'QtaRichiesta = CalcolaMq.Mq

        End If

        If O.L.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
            Altezza = Altezza / 10
            Larghezza = Larghezza / 10
        End If

        If Consigliato Then
            For Each riga As DataGridViewRow In DgLavorazioniSel.Rows
                Dim l As Lavorazione = riga.DataBoundItem
                If listaOpzB.FindAll(Function(x) x.IdLavoro = l.IdLavoro).Count = 0 Then
                    listaOpzB.Add(l)
                End If
            Next
        End If

        'Dim _Risultato As RisultatoListinoBase
        '_Risultato = MgrPreventivazioneB.CalcolaPrezzi(LRif, listaBaseB, listaOpzB, False,, Altezza, Larghezza)

        'Dim R As RisultatoPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoIntermedio(Qta,
        '                                                                                 QtaSecondaria,
        '                                                                                 _Risultato,
        '                                                                                 LRif,
        '                                                                                 listaBaseB,
        'listaOpzB)

        'Dim iRp As New RisultatoPluginPackaging
        'iRp.Altezza = O.Altezza
        'iRp.Base = O.Larghezza
        'iRp.Profondita = O.Profondita
        'iRp.IdFormatoProdottoScelto = O.L.IdFormProd
        'iRp.IdTipoFustella = O.IdTipoFustella


        Dim R As RisPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoFinale(O.L,
                                                                                Qta,
                                                                                listaBaseB,
                                                                                QtaSecondaria,
                                                                                listaOpzB,
                                                                                False,,
                                                                                Altezza,
                                                                                Larghezza,
                                                                                NumeroPezzi,
                                                                                Consigliato)

        Return R

    End Function

    Private Function CalcolaMq(O As FW.OrdineWeb) As RisCalcoloMq

        Dim Ris As New RisCalcoloMq
        Dim QtaToConsider As Integer = O.Qta

        'Ris = MgrCalcoliTecnici.CalcolaMq(LRif.FormatoProdotto.Fc.Larghezza,
        Dim AltezzaValidata As Integer = O.Altezza
        Dim LarghezzaValidata As Integer = O.Larghezza

        Dim Scarto As Integer = 0

        If O.L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri AndAlso O.L.ConSoggettiDuplicati = enSiNo.Si Then
            Scarto = FormerConst.ProdottiCaratteristiche.ScartoMMLatoSoggetto  '2mm per lato per ogni misura (altezza,larghezza)
        End If


        If O.L.TipoUnitaMisuraInInput = enUnitaDiMisura.mm Then
            AltezzaValidata = AltezzaValidata / 10
            LarghezzaValidata = LarghezzaValidata / 10
        End If

        Dim RisLatoFisso As FW.RisLatoFissoRiferimento = O.L.LatoFissoRiferimento(AltezzaValidata,
                                                                                LarghezzaValidata,
                                                                                QtaToConsider,
                                                                                Scarto)

        Dim LatoFissoRiferimento As Single = RisLatoFisso.LatoFissoPrincipale

        Dim AltezzaFissaRiferimento As Integer = 0

        AltezzaFissaRiferimento = O.L.FormatoProdotto.LunghezzaCm

        Dim QtaToUse As Integer = QtaToConsider

        If O.L.FormatoProdotto.IsRotolo = enSiNo.Si Then
            'qui non e' un rotolo devo calcolarlo a fogli sani
            AltezzaFissaRiferimento = 0
        ElseIf o.L.FormatoProdotto.IsLastra = enSiNo.Si Then
            AltezzaFissaRiferimento = RisLatoFisso.LatoFissoSecondario
            QtaToUse = 1

        End If

        Ris.Mq = MgrCalcoliTecnici.CalcolaMq(LatoFissoRiferimento,
                                                               QtaToUse,
                                                               AltezzaValidata,
                                                               LarghezzaValidata,,
                                                               Scarto,
                                                               AltezzaFissaRiferimento).AreaCalcolata

        If O.L.FormatoProdotto.IsLastra = enSiNo.Si Then
            Ris.Mq = Ris.Mq * QtaToConsider
        End If

        Ris.Lato1FissoRiferimento = LatoFissoRiferimento

        Return Ris

        'Dim RisOld As Single = 0

        'RisOld = MgrCalcoliTecnici.CalcolaMq(O.L.LatoFissoRiferimento(O.Altezza, O.Larghezza, O.Qta).LatoFissoPrincipale,
        '                                       O.Qta,
        '                                       O.Altezza,
        '                                       O.Larghezza).AreaCalcolata
        ''If Ris < 1 Then Ris = 1
        'Return RisOld
    End Function

    Private OrdineOnline As FW.OrdineWeb = Nothing

    Private Function CalcolaFogli(O As FW.OrdineWeb) As RisCalcoloFogli

        Dim Ris As New RisCalcoloFogli

        Dim QtaToConsider As Integer = O.Qta

        Dim AltezzaValidata As Integer = O.Altezza
        Dim LarghezzaValidata As Integer = O.Larghezza

        Dim Scarto As Integer = 0

        If O.L.TipoPrezzo = enTipoPrezzo.SuFoglio AndAlso O.L.ConSoggettiDuplicati = enSiNo.Si Then
            Scarto = FormerConst.ProdottiCaratteristiche.ScartoMMLatoSoggetto '2mm per lato per ogni misura (altezza,larghezza)
        End If

        Dim LarghezzaRif As Integer = O.L.FormatoProdotto.Larghezza
        Dim AltezzaRif As Integer = O.L.FormatoProdotto.Lunghezza

        'sviluppo i fogli che escono come sviluppo i metri quadri 
        Ris.NumeroFogli = MgrCalcoliTecnici.CalcolaFogli(LarghezzaRif,
                                                         AltezzaRif,
                                                         QtaToConsider,
                                                         AltezzaValidata,
                                                         LarghezzaValidata,
                                                         Scarto)

        Return Ris
    End Function

    Private Function CalcolaPrezzoConsigliato()
        Try

            Dim Ris As Decimal = 0
            Dim NumeroPezziScelti As Integer = OrdineOnline.Qta
            Dim QtaRichiesta As Single = NumeroPezziScelti
            Dim QtaSecondaria As Single = QtaRichiesta

            If OrdineOnline.L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                QtaRichiesta = CalcolaMq(OrdineOnline).Mq
                If OrdineOnline.L.ConSoggettiDuplicati = enSiNo.Si Then
                    QtaSecondaria = NumeroPezziScelti
                End If
            ElseIf OrdineOnline.L.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                QtaRichiesta = CalcolaFogli(OrdineOnline).NumeroFogli
                If OrdineOnline.L.ConSoggettiDuplicati = enSiNo.Si Then
                    QtaSecondaria = NumeroPezziScelti
                End If
            End If

            'If OrdineOnline.L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            '    QtaRichiesta = CalcolaMq(OrdineOnline).Mq
            'End If

            Dim PrezzoCalcolatoNetto As Decimal = 0
            Dim PrezzoPubblico As Decimal = 0
            Dim PrezzoRiv As Decimal = 0

            Dim R As RisPrezzoIntermedio = CalcolaPrezzi(OrdineOnline,
                                                        QtaRichiesta,
                                                        QtaSecondaria,
                                                        NumeroPezziScelti,
                                                        True)

            Dim vr As VoceRubrica = cmbClienteSel.RubSelezionato

            If vr.Tipo = enTipoRubrica.Rivenditore Then
                Ris = R.PrezzoRiv
            Else
                Ris = R.PrezzoPubbl
            End If

            If OrdineOnline.TipoConsegna = enTipoConsegna.Fast Then 'FAST
                Ris = Math.Ceiling(Ris * MgrPercentualiDay.PercentualeFast(OrdineOnline.P))
            ElseIf OrdineOnline.TipoConsegna = enTipoConsegna.Slow Then 'SLOW
                Ris = Math.Floor(Ris * MgrPercentualiDay.PercentualeSlow(OrdineOnline.P))
            End If

            txtTotConsigliato.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Ris)
        Catch ex As Exception
            txtTotConsigliato.Text = 0
        End Try


    End Function

    Private Function CalcolaTotaleFornitura(O As FW.OrdineWeb) As Decimal
        Dim Ris As Decimal = 0
        Dim NumeroPezziScelti As Integer = O.Qta
        Dim QtaRichiesta As Single = NumeroPezziScelti
        Dim QtaSecondaria As Single = 0

        If O.L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            QtaRichiesta = CalcolaMq(O).Mq
        End If

        Dim PrezzoCalcolatoNetto As Decimal = 0
        Dim PrezzoPubblico As Decimal = 0
        Dim PrezzoRiv As Decimal = 0

        Dim R As RisPrezzoIntermedio = CalcolaPrezzi(O,
                                                    QtaRichiesta,
                                                    QtaSecondaria,
                                                    NumeroPezziScelti)

        Ris = R.PrezzoPubbl




        If O.TipoConsegna = enTipoConsegna.Fast Then 'FAST
            Ris = Math.Ceiling(Ris * MgrPercentualiDay.PercentualeFast(O.P))
        ElseIf O.TipoConsegna = enTipoConsegna.Slow Then 'SLOW
            Ris = Math.Floor(Ris * MgrPercentualiDay.PercentualeSlow(O.P))
        End If

        Return Ris

    End Function

    Private _Altezza As Integer = 0
    Private _Larghezza As Integer = 0
    Private _Lb As ListinoBase = Nothing

    Friend Function Carica(IdOrdineOnline As Integer) As Integer

        _IdOrdineOnline = IdOrdineOnline

        lblIdOrd.Text = IdOrdineOnline

        CaricaCombo()

        CaricaCat()

        Dim TipoRetro As String = ""
        Dim IdUtOnline As Integer = 0
        Dim IdCorr As Integer = 0
        Dim IdPagam As Integer = 0
        Dim IdIndirizzo As Integer = 0
        Dim ChiudiForm As Boolean = False

        Try

            'qui provo a recuperare i dati dell'ordine

            Using Mgr As New FW.OrdiniWebDAO

                Using O As FW.OrdineWeb = Mgr.Read(IdOrdineOnline)

                    OrdineOnline = O.Clone

                    If O.IdOrdine = 0 Then
                        MessageBox.Show("Ordine Online non valido o inesistente")
                        Exit Function
                    End If

                    If O.L.NoAttachFile = enSiNo.Si Then
                        MessageBox.Show("L'ordine non prevede file allegati!")
                        Exit Function
                    End If

                    _Altezza = O.Altezza
                    _Larghezza = O.Larghezza

                    If _Altezza <> 0 Then
                        OFpAltezza = _Altezza
                    Else
                        OFpAltezza = O.L.FormatoProdotto.Lunghezza
                    End If

                    If _Larghezza <> 0 Then
                        OFpLarghezza = _Larghezza
                    Else
                        OFpLarghezza = O.L.FormatoProdotto.Larghezza
                    End If

                    OTcGrammi = O.L.TipoCarta.Grammi

                    Dim PrezzoInserimento As Decimal = 0

                    If MgrFormerException.AggiungereLavorazioneInserimentoNelSistema Then
                        'qui aggiungo la lavorazione di inserimento nel sistema che costa x una tantum 
                        _LavorazioniSelezionate = "," & FormerConst.Lavorazioni.InserimentoNelSistema & ","
                        Using mgrP As New PrezziLavoroDAO

                            Dim lp As List(Of PrezzoLavoro) = mgrP.FindAll(New LUNA.LunaSearchParameter(LFM.PrezzoLavoro.IdLavoro, FormerConst.Lavorazioni.InserimentoNelSistema))

                            If lp.Count Then
                                PrezzoInserimento = lp(0).Prezzo
                            End If

                        End Using

                    End If

                    _TotaleFornitura = O.PrezzoCalcolatoNetto + PrezzoInserimento

                    _PrezzoRivenditore = _TotaleFornitura
                    _PrezzoAlPubblico = _TotaleFornitura ' CalcolaTotaleFornitura(O)

                    Try
                        _PrezzoAlPubblico = CalcolaTotaleFornitura(O)
                    Catch ex As Exception

                    End Try

                    If O.TipoConsegna = enTipoConsegna.Fast Then
                        lblFast.Visible = True
                    ElseIf O.TipoConsegna = enTipoConsegna.Normale Then
                        lblNormale.Visible = True
                    ElseIf O.TipoConsegna = enTipoConsegna.Slow Then
                        lblSlow.Visible = True
                    End If

                    _IdListinoBase = O.IdListinoBase

                    _Lb = New ListinoBase
                    _Lb.Read(_IdListinoBase)

                    _AltezzaDaOrdine = O.Altezza
                    _LarghezzaDaOrdine = O.Larghezza
                    _OrientamentoDaOrdine = O.Orientamento

                    txtQtaReale.Text = O.Qta





                    _DataConsegnaOriginale = O.ConsegnaAssociata.Giorno

                    Try
                        dtDataConsegna.Value = _DataConsegnaOriginale
                    Catch ex As Exception

                    End Try

                    If O.IdCoupon Then
                        txtSconto.ReadOnly = True
                        txtRicarico.ReadOnly = True
                        txtTotDaRicavare.ReadOnly = True
                        lnkReset.Enabled = False
                    End If

                    If O.Utente.IdRubricaInt <> FormerLib.FormerConst.UtentiSpecifici.IdRubricaInternaFormer Then
                        _OrdineDiAltri = True
                    End If

                    lblStatoOrd.Text = O.StatoStr
                    lblStatoOrd.BackColor = O.ColoreStato
                    '28/02/2017 l'utente lo prendo dalla consegna invece che dall'ordine 
                    'per evitare il problema dell'indirizzo
                    'IdUtOnline = O.IdUt

                    IdUtOnline = O.ConsegnaAssociata.IdUt

                    _FronteRetro = O.C.FR
                    TipoRetro = O.TipoRetro

                    If O.Preventivo = enSiNo.Si Then chkPreventivo.Checked = True

                    txtNote.Text = O.Annotazioni

                    txtNomeLavoro.Text = O.NomeLavoro

                    IdCorr = O.ConsegnaAssociata.IdCorriere

                    IdPagam = O.ConsegnaAssociata.IdPagam

                    IdIndirizzo = O.ConsegnaAssociata.IdIndirizzo


                    _LavorazioniSelezionate &= "," & O.Lavorazioni & ","
                    CaricaLavorazioniSelezionate()
                    CalcolaPrezzoConsigliato()



                    Using mgrR As New VociRubricaDAO
                        Dim l As List(Of VoceRubrica) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.IdUtOnline, IdUtOnline))
                        Dim vr As VoceRubrica = l(0)
                        _IdRubricaInt = vr.IdRub
                        'MgrControl.SelectIndexCombo(cmbCliente, _IdRubricaInt)
                        cmbClienteSel.IdRubSelezionato = _IdRubricaInt

                        'If _OrdineDiAltri Then cmbCliente.Enabled = False

                        MgrControl.SelectIndexCombo(cmbCorriere, IdCorr)
                        MgrControl.SelectIndexCombo(cmbTipoPagamento, IdPagam)

                        If vr.Indirizzi.FindAll(Function(x) x.IdIndOnline = IdIndirizzo).Count = 0 Then
                            MessageBox.Show("La consegna ha un indirizzo scelto che ancora non è presente nel nostro database. Riprovare tra 5 minuti")
                            ChiudiForm = True
                        Else
                            MgrControl.SelectIndexCombo(cmbIndirizzo, IdIndirizzo)
                        End If

                    End Using

                    lblTotForn.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_TotaleFornitura)

                    txtTotDaRicavare.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(O.ImportoNetto)

                    txtSconto.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(O.Sconto)
                    txtRicarico.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(O.Ricarico)

                    lblTotImp.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(O.ImportoNetto)

                End Using

                If _OrdineDiAltri Then
                    chkPreventivo.Enabled = False
                    txtNote.ReadOnly = True
                    'cmbCorriere.Enabled = False 'il corriere lo lascio comunque selezionabile
                    dtDataConsegna.Enabled = False
                    cmbClienteSel.Enabled = False
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nel recupero delle informazioni sull'ordine. Tentare in seguito!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try

        If ChiudiForm = False Then
            If _FronteRetro Then
                pnlRetro.Visible = True
            End If

            MgrControl.SelectIndexComboEnum(cmbTipoRetro, TipoRetro)
            If _OrdineDiAltri Then cmbTipoRetro.Enabled = False

            ShowDialog()
        Else
            Close()
        End If

        Return _Ris

    End Function

    Private Sub CalcolaTotali()
        '' calcolo iva e totale
        Dim TotaleFornitura As Decimal = _TotaleFornitura

        Dim Sconto As Decimal = 0
        Try
            Sconto = CDec(txtSconto.Text)
        Catch ex As Exception

        End Try
        Dim Ricarico As Decimal = 0
        Try
            Ricarico = CDec(txtRicarico.Text)
        Catch ex As Exception

        End Try

        Dim TotImponibile As Decimal = TotaleFornitura - Sconto + Ricarico
        Dim Iva As Decimal = FormerHelper.Finanziarie.CalcolaIva(TotImponibile)

        lblTotImp.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotImponibile)
        lblIva.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Iva)
    End Sub

    Private Sub txtSconto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSconto.TextChanged, txtRicarico.TextChanged
        CalcolaTotali()
    End Sub

    Private Sub lnkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReset.LinkClicked
        ResetTxtTotDaRicavare()
        txtSconto.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(0)
        txtRicarico.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(0)
    End Sub

    Private Sub txtTotDaRicavare_LostFocus(sender As Object, e As EventArgs) Handles txtTotDaRicavare.LostFocus
        If txtTotDaRicavare.Value = 0 Then ResetTxtTotDaRicavare()
    End Sub

    Private Sub ResetTxtTotDaRicavare()
        'MARCO: IL RESET DEVE RIPORTARE IL CAMPO AL VALORE DELL'IMPONIBILE (INCLUSI QUINDI EVENTUALI RICARICHI O SCONTI GIA' PRESENTI)
        'O A QUELLO DELLA FORNITURA, AZZERANDO SCONTO E RICARICO? CHIEDERE AD ANTONIO
        txtTotDaRicavare.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_TotaleFornitura)
    End Sub

    'Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    '    Dim x As Char = vbCr
    '    If e.KeyChar = x Then
    '        e.Handled = True
    '        SendKeys.Send(vbTab)
    '    End If

    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub cmbTipoRetro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoRetro.SelectedIndexChanged

        Dim Voce As enTipoRetro = DirectCast(cmbTipoRetro.SelectedItem, cEnum).Id

        If Voce = enTipoRetro.RetroDifferente Then
            btnRetro.Enabled = True
        Else
            btnRetro.Enabled = False
        End If

    End Sub

    Private Sub btnFronte_Click(sender As Object, e As EventArgs) Handles btnFronte.Click

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica("C:\")
            Sottofondo()

            If f.SelectedFile.Length Then
                Dim FileName As String = f.SelectedFile

                If FileName.ToLower.EndsWith(".pdf") Then
                    'qui devo effettuare la validazione del file e se il livello e' sotto errore inserirlo comunque
                    Using L As New ListinoBase
                        L.Read(_IdListinoBase)
                        Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
                                                                                                               FileName,
                                                                                                               _LarghezzaDaOrdine,
                                                                                                               _AltezzaDaOrdine,
                                                                                                               _OrientamentoDaOrdine)

                        If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
                            MessageBox.Show("Il file non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & risValidazioneFile.ErrorBuffer(True))
                        ElseIf risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Attenzione Then
                            If MessageBox.Show("Il file presenta i seguenti problemi NON BLOCCANTI: " & risValidazioneFile.ErrorBuffer(True) &
                                               "Si vuole comunque allegarlo all'ordine? ", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                txtFronte.Text = FileName
                            End If
                        Else
                            txtFronte.Text = FileName
                        End If
                    End Using
                Else
                    MessageBox.Show("Si possono allegare solo file PDF agli ordini")
                End If
            End If

        End Using

        'OpenFileImg.ShowDialog()

        'If OpenFileImg.FileName.Length Then

        '    Dim FileName As String = OpenFileImg.FileName

        '    If FileName.ToLower.EndsWith(".pdf") Then
        '        'qui devo effettuare la validazione del file e se il livello e' sotto errore inserirlo comunque
        '        Using L As New ListinoBase
        '            L.Read(_IdListinoBase)
        '            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L, FileName, _LarghezzaDaOrdine, _AltezzaDaOrdine, _OrientamentoDaOrdine)

        '            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
        '                MessageBox.Show("Il file non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & risValidazioneFile.ErrorBuffer(True))
        '            ElseIf risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Attenzione Then
        '                If MessageBox.Show("Il file presenta i seguenti problemi NON BLOCCANTI: " & risValidazioneFile.ErrorBuffer(True) &
        '                                   "Si vuole comunque allegarlo all'ordine? ", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '                    txtFronte.Text = FileName
        '                End If
        '            Else
        '                txtFronte.Text = FileName
        '            End If
        '        End Using
        '    Else
        '        MessageBox.Show("Si possono allegare solo file PDF agli ordini")
        '    End If
        'End If

    End Sub

    Private Sub btnRetro_Click(sender As Object, e As EventArgs) Handles btnRetro.Click

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica("C:\")
            Sottofondo()

            If f.SelectedFile.Length Then
                Dim FileName As String = f.SelectedFile

                If FileName.ToLower.EndsWith(".pdf") Then

                    'qui devo effettuare la validazione del file e se il livello e' sotto errore inserirlo comunque
                    Using L As New ListinoBase
                        L.Read(_IdListinoBase)
                        Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
                                                                                                               FileName,
                                                                                                               _LarghezzaDaOrdine,
                                                                                                               _AltezzaDaOrdine,
                                                                                                               _OrientamentoDaOrdine)

                        If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
                            MessageBox.Show("Il file non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True))
                        ElseIf risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Attenzione Then
                            If MessageBox.Show("Il file presenta i seguenti problemi NON BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True) &
                                               "Si vuole comunque allegarlo all'ordine? ", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                txtRetro.Text = FileName
                            End If
                        Else
                            txtRetro.Text = FileName
                        End If
                    End Using
                Else
                    MessageBox.Show("Si possono allegare solo file PDF agli ordini")
                End If
            End If

        End Using

        'OpenFileImg.ShowDialog()

        'If OpenFileImg.FileName.Length Then
        '    Dim FileName As String = OpenFileImg.FileName

        '    If FileName.ToLower.EndsWith(".pdf") Then

        '        'qui devo effettuare la validazione del file e se il livello e' sotto errore inserirlo comunque
        '        Using L As New ListinoBase
        '            L.Read(_IdListinoBase)
        '            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L, FileName, _LarghezzaDaOrdine, _AltezzaDaOrdine, _OrientamentoDaOrdine)

        '            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
        '                MessageBox.Show("Il file non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True))
        '            ElseIf risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Attenzione Then
        '                If MessageBox.Show("Il file presenta i seguenti problemi NON BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True) &
        '                                   "Si vuole comunque allegarlo all'ordine? ", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '                    txtRetro.Text = FileName
        '                End If
        '            Else
        '                txtRetro.Text = FileName
        '            End If
        '        End Using
        '    Else
        '        MessageBox.Show("Si possono allegare solo file PDF agli ordini")
        '    End If
        'End If

    End Sub

    Private Function ValidaFileFronteInIns() As String
        Dim Ris As String = String.Empty

        Using L As New ListinoBase
            L.Read(_IdListinoBase)
            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
                                                                                                    txtFronte.Text,
                                                                                                    _Larghezza,
                                                                                                    _Altezza,
                                                                                                    enTipoOrientamento.NonSpecificato)

            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
                Ris = "Il file FRONTE non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True)
            End If
        End Using
        Return Ris
    End Function

    Private Function ValidaFileRetroInIns() As String
        Dim Ris As String = String.Empty

        Using L As New ListinoBase
            L.Read(_IdListinoBase)
            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
                                                                                                    txtRetro.Text,
                                                                                                    _Larghezza,
                                                                                                    _Altezza,
                                                                                                    enTipoOrientamento.NonSpecificato)

            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
                Ris = "Il file RETRO non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True)
            End If
        End Using
        Return Ris
    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        Dim ErrMsg As String = String.Empty

        Dim OkDimensioni As Boolean = True

        If txtFronte.Text.Length Then

            If FormerHelper.File.GetMB(txtFronte.Text) > 100 Then
                OkDimensioni = False
                If MessageBox.Show("Il file Fronte che stai allegando pesa piu di 100 Megabyte, questo può creare problemi e si consiglia di ottimizzarlo prima di allegarlo. Vuoi continuare?", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    OkDimensioni = True

                End If
            End If
        End If

        If txtRetro.Text.Length Then

            If FormerHelper.File.GetMB(txtRetro.Text) > 100 Then
                OkDimensioni = False
                If MessageBox.Show("Il file Retro che stai allegando pesa piu di 100 Megabyte, questo può creare problemi e si consiglia di ottimizzarlo prima di allegarlo. Vuoi continuare?", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    OkDimensioni = True

                End If
            End If
        End If

        If OkDimensioni Then

            Dim OkValidazione As Boolean = True
            'qui passo la validazione di entrambi
            Dim risVal As String = String.Empty
            'risVal = ValidaFileFronteInIns()

            'If _Lb.ColoreStampa.FR Then
            '    Dim risValR As String = ValidaFileRetroInIns()

            '    If risValR.Length Then
            '        If risVal.Length Then risVal &= ControlChars.NewLine
            '        risVal &= risValR
            '    End If
            'End If

            'If risVal.Length Then
            '    OkValidazione = False
            'End If

            If OkValidazione Then
                Dim dataPrevistaProduzione As Date = dtDataConsegna.Value

                Dim DataPrevistaConsegna As Date = CalcolaDataPrevistaConsegna()

                If dataPrevistaProduzione.DayOfWeek = DayOfWeek.Sunday Then
                    ErrMsg &= "Non è possibile selezionare la domenica come giorno di ritiro/spedizione" & ControlChars.NewLine
                End If

                If dataPrevistaProduzione.DayOfWeek = DayOfWeek.Saturday And cmbCorriere.SelectedValue <> enCorriere.RitiroCliente Then
                    ErrMsg &= "Non è possibile selezionare il sabato come giorno di ritiro/spedizione per il corriere scelto" & ControlChars.NewLine
                End If

                Dim TipoRetroScelto As enTipoRetro = DirectCast(cmbTipoRetro.SelectedItem, cEnum).Id

                If txtFronte.Text.Length = 0 Then
                    ErrMsg &= "Indicare il file Fronte" & ControlChars.NewLine
                End If

                If chkUsaNomeLavoro.Checked And txtNomeLavoro.Text.Trim.Length = 0 Then
                    ErrMsg &= "Per forzare il nome lavoro in fattura il campo deve essere valorizzato" & ControlChars.NewLine
                End If

                If dataPrevistaProduzione = Date.MinValue Then
                    ErrMsg &= " Selezionare una data" & ControlChars.NewLine
                End If

                If _FronteRetro Then
                    If TipoRetroScelto = enTipoRetro.RetroDifferente Then
                        If txtRetro.Text.Length = 0 Then
                            ErrMsg &= "Indicare il file Retro" & ControlChars.NewLine
                        End If
                    End If
                End If

                Dim vr As VoceRubrica = cmbClienteSel.RubSelezionato ' DirectCast(cmbCliente.SelectedItem, VoceRubrica)

                Dim IsOltreScopertoMax As Boolean = False

                'CHECK SU SCOPERTOMAX

                Using MgrR As New VociRubricaDAO
                    IsOltreScopertoMax = MgrR.OltreScopertoMax(vr)
                End Using

                If IsOltreScopertoMax Then
                    Dim MessaggioSM As String = "Il cliente selezionato ha attualmente uno scoperto complessivo di € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(MgrSituazioneCliente.GetSituazioneCliente(vr.IdRub).TotaleScopertoComplessivo) & " che supera il suo limite di scoperto massimo (" & vr.ScopertoMax & "). Vuoi inserire comunque l'ordine?"

                    If MessageBox.Show(MessaggioSM, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        IsOltreScopertoMax = False
                    End If

                End If

                If IsOltreScopertoMax = False Then
                    Dim IndSel As Indirizzo = DirectCast(cmbIndirizzo.SelectedItem, Indirizzo)

                    Dim IndirizzoOk As Boolean = False
                    Dim risValidazione As RisValidazioneIndirizzo = Nothing

                    risValidazione = FormerWebLabeling.MgrWebLabelingGls.CheckAddress(IndSel.Provincia,
                                                                IndSel.Cap,
                                                                IndSel.Comune,
                                                                IndSel.Indirizzo,
                                                                IndSel.IdNazione)
                    IndirizzoOk = risValidazione.Valido
                    If IndirizzoOk = False Then
                        If MessageBox.Show("L'indirizzo selezionato non ha passato la validazione GLS. Si vuole continuare comunque?", "Validazione Indirizzo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            IndirizzoOk = True
                        End If
                    End If

                    If txtQtaReale.Text.Length = 0 OrElse txtQtaReale.Value = 0 Then
                        ErrMsg &= "Indicare la quantità reale dell'ordine "
                    End If

                    If IndirizzoOk Then
                        If ErrMsg.Length Then
                            MessageBox.Show(ErrMsg, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            Dim OkCli As Boolean = True

                            If _OrdineDiAltri = False AndAlso
                            cmbClienteSel.IdRubSelezionato = _IdRubricaInt AndAlso
                            cmbClienteSel.IdRubSelezionato = FormerLib.FormerConst.UtentiSpecifici.IdRubricaInternaFormer Then
                                If MessageBox.Show("L'ordine non è stato assegnato a nessun cliente, si vuole continuare?", "Allega File Ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                    OkCli = False
                                End If
                            End If

                            If OkCli Then
                                If MessageBox.Show("Confermi il salvataggio dei file allegati all'ordine e l'assegnazione dell'ordine al cliente scelto?", "Allega File Ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                    'qui vado a copiare i file nel punto in cui lui se li aspetta, cambio l'id utente e il nome file e cambio lo stato ordine 
                                    Using tb As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox()
                                        Try
                                            Dim FOrig As New FileInfo(txtFronte.Text)
                                            Dim ROrig As FileInfo = Nothing
                                            Dim NomeFileF As String = "F_" & FormerLib.FormerHelper.Web.NormalizzaNomeFile(FOrig.Name)
                                            Dim NomeFileR As String = String.Empty

                                            If _FronteRetro Then

                                                If TipoRetroScelto = enTipoRetro.RetroDifferente Then
                                                    ROrig = New FileInfo(txtRetro.Text)
                                                    NomeFileR = "R_" & FormerLib.FormerHelper.Web.NormalizzaNomeFile(ROrig.Name)
                                                End If

                                            End If

                                            'qui devo lavorare su nomefileR e nomefileF

                                            Dim PathOrdineF As String = FormerPath.PathTemp & _IdOrdineOnline & "_" & NomeFileF

                                            MgrIO.FileCopia(Me, FOrig.FullName, PathOrdineF)

                                            If NomeFileR.Length Then
                                                Dim PathOrdineR As String = FormerPath.PathTemp & _IdOrdineOnline & "_" & NomeFileR

                                                MgrIO.FileCopia(Me, ROrig.FullName, PathOrdineR)

                                            End If

                                            'se arrivo qui ho copiato entrambi i file 
                                            Dim IdRubOnline As Integer = vr.IdUtOnline

                                            'Dim l As New List(Of ICorriereBusiness)

                                            'Using mgr As New CorrieriDAO
                                            '    For Each singCorr As Corriere In mgr.FindAll("IdCorriere", New LUNA.LunaSearchParameter("DisponibileOnline", enSiNo.Si))
                                            '        l.Add(singCorr)
                                            '    Next
                                            'End Using

                                            'Dim met As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(vr.IdCorriere)
                                            'Dim iCorr As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(met, l, vr.DefaultCAP)

                                            Dim IdCorrPredef As Integer = cmbCorriere.SelectedValue 'iCorr.IdCorriere

                                            If IdRubOnline <> 0 Then

                                                Using Mgr As New FW.OrdiniWebDAO

                                                    Using O As FW.OrdineWeb = Mgr.Read(_IdOrdineOnline)

                                                        O.SorgenteFronte = NomeFileF
                                                        O.SorgenteRetro = NomeFileR
                                                        O.Qta = txtQtaReale.Text

                                                        'If _OrdineDiAltri = False Then

                                                        'se arrivo qui sicuramente potrebbe cambiare corriere da ritiro cliente a qualche altra cosa 
                                                        'o potrebbe rimanere anche lo stesso. A questo punto se e' ritiro cliente lo lascio cosi 

                                                        'se invece il corriere e' diverso devo calcolare la spedizione 
                                                        'If O.IdCorriere <> IdCorrPredef Then
                                                        '    ''qui va ricalcolata la spedizione. anche se la cosa giusta sarebbe che loro cambino il loro 
                                                        '    ''Corriere al momento in cui fanno l'ordine con quello che verrà applicato 

                                                        '    ''MODIFICATO PER PARTIRE DAL GIORNO DI PRODUZIONE CALCOLANDO IL NUOVO CORRIERE 
                                                        '    'Dim GiornoStart As Date = O.DataPrevProduzione 'o.consegnaassociata.giorno

                                                        '    'Using C As New Corriere
                                                        '    '    C.Read(IdCorrPredef)
                                                        '    '    O.ConsegnaAssociata.Giorno = MgrDataConsegna.CalcolaDataConsegna(GiornoStart, C)
                                                        '    'End Using
                                                        '    If O.IdCorriere <> enCorriere.RitiroCliente Then
                                                        '        If O.ConsegnaAssociata.Giorno.DayOfWeek = DayOfWeek.Saturday Then
                                                        '            O.ConsegnaAssociata.Giorno = MgrDataConsegna.GetPrimaDataDisponibile(O.ConsegnaAssociata.Giorno, O.IdCorriere)
                                                        '        End If
                                                        '    End If
                                                        'End If

                                                        O.IdUt = IdRubOnline
                                                        O.IdCorriere = IdCorrPredef
                                                        If chkPreventivo.Checked Then
                                                            O.Preventivo = enSiNo.Si
                                                        Else
                                                            O.Preventivo = enSiNo.No
                                                        End If

                                                        O.Annotazioni = txtNote.Text

                                                        O.ConsegnaAssociata.IdUt = IdRubOnline
                                                        O.ConsegnaAssociata.IdCorriere = IdCorrPredef
                                                        O.ConsegnaAssociata.IdPagam = cmbTipoPagamento.SelectedValue 'vr.IdPagamento
                                                        O.ConsegnaAssociata.Giorno = dataPrevistaProduzione
                                                        O.DataPrevProduzione = dataPrevistaProduzione
                                                        O.DataPrevConsegna = DataPrevistaConsegna

                                                        If chkConsegnaGarantita.Checked Then
                                                            O.ConsegnaGarantita = O.DataPrevProduzione
                                                            O.ConsegnaGarantitaDa = PostazioneCorrente.UtenteConnesso.IdUt
                                                        End If

                                                        'If _OrdineDiAltri = False Then
                                                        O.ConsegnaAssociata.IdIndirizzo = IndSel.IdIndOnline ' vr.DefaultIndirizzo.IdIndOnline
                                                        O.IdIndirizzo = IndSel.IdIndOnline 'vr.DefaultIndirizzo.IdIndOnline
                                                        'End If

                                                        O.TipoRetro = TipoRetroScelto
                                                        O.ConsegnaAssociata.IdStatoConsegna = enStatoConsegna.InLavorazione
                                                        O.ConsegnaAssociata.NoCartaceo = IIf(chkNoCartaceo.Checked, enSiNo.Si, enSiNo.No)

                                                        O.DataCambioStato = Now
                                                        O.Stato = enStatoOrdine.Preinserito
                                                        O.InseritoDa = PostazioneCorrente.UtenteConnesso.IdUt

                                                        If O.IdCoupon = 0 Then

                                                            O.Sconto = txtSconto.Text
                                                            O.Ricarico = txtRicarico.Text

                                                        End If

                                                        If DateDiff(DateInterval.Day, _DataConsegnaOriginale, dataPrevistaProduzione) <> 0 Then
                                                            O.TipoConsegna = enTipoConsegna.Fast
                                                        End If

                                                        O.NoEmailDemone = IIf(chkNoEmail.Checked, enSiNo.Si, enSiNo.No)

                                                        O.NomeLavoro = txtNomeLavoro.Text
                                                        O.UsaNomeLavoroInFattura = IIf(chkUsaNomeLavoro.Checked, enSiNo.Si, enSiNo.No)

                                                        Dim NewLav As String = _LavorazioniSelezionate.TrimStart(",").TrimEnd(",")
                                                        O.Lavorazioni = NewLav

                                                        tb.TransactionBegin()
                                                        O.Save()
                                                        O.ConsegnaAssociata.Save()
                                                        tb.TransactionCommit()
                                                    End Using
                                                End Using

                                                If chkRendiPagamentoDefault.Checked Then
                                                    If vr.IdPagamento <> cmbTipoPagamento.SelectedValue Then
                                                        vr.IdPagamento = cmbTipoPagamento.SelectedValue
                                                        vr.LastUpdate = Now
                                                        vr.Save()
                                                    End If
                                                End If

                                            Else
                                                MessageBox.Show("Si è verificato un errore nella procedura di aggiornamento dell'ordine. IdRubOnline = 0, Riprovare")
                                            End If

                                            Close()

                                        Catch ex As Exception
                                            tb.TransactionRollBack()
                                            ManageError(ex, "Allega file Ordine Online")
                                        End Try
                                    End Using
                                End If
                            End If

                        End If
                    End If
                End If



            Else
                MessageBox.Show(risVal)

            End If
        End If


    End Sub

    Private Sub txtTotDaRicavare_TextChanged(sender As Object, e As EventArgs) Handles txtTotDaRicavare.TextChanged

        If sender.focused Then
            Dim ValoreScelto As Decimal = txtTotDaRicavare.Value

            If ValoreScelto >= 0 Then
                If ValoreScelto > _TotaleFornitura Then
                    txtRicarico.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((ValoreScelto - _TotaleFornitura), 2)
                    txtSconto.Text = 0
                ElseIf ValoreScelto < _TotaleFornitura Then
                    txtSconto.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((_TotaleFornitura - ValoreScelto), 2)
                    txtRicarico.Text = 0
                ElseIf ValoreScelto = _TotaleFornitura Then
                    txtSconto.Text = 0
                    txtRicarico.Text = 0
                End If
            End If
        End If


    End Sub

    Private Sub CaricaDefaultCliente()

        Using R As VoceRubrica = cmbClienteSel.RubSelezionato ' DirectCast(cmbCliente.SelectedItem, VoceRubrica)
            If Not R Is Nothing Then
                'in r.idcorriere ho il metodo di consegna , poi devo chiedere al mgr dei metodi di consegna in base al cap del cliente il default

                Dim l As New List(Of ICorriereBusiness)

                Using mgr As New CorrieriDAO
                    For Each singCorr As Corriere In mgr.FindAll(LFM.Corriere.IdCorriere,
                                                             New LUNA.LunaSearchParameter(LFM.Corriere.DisponibileOnline, enSiNo.Si))
                        l.Add(singCorr)
                    Next
                End Using

                Dim met As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(R.IdCorriere)
                Dim iCorr As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(met, l, R.DefaultCAP)
                Dim IdCorrPredef As Integer = iCorr.IdCorriere

                MgrControl.SelectIndexCombo(cmbCorriere, IdCorrPredef)

                cmbIndirizzo.ValueMember = "IdIndOnline"
                cmbIndirizzo.DisplayMember = "RiassuntoEx"
                cmbIndirizzo.DataSource = R.Indirizzi

                If R.Indirizzi.FindAll(Function(x) x.IdIndOnline = R.DefaultIndirizzo.IdIndOnline).Count = 0 Then
                    MessageBox.Show("Il cliente selezionato ha un indirizzo di default che ancora non è presente nel nostro database. Riprovare tra 5 minuti")
                    Close()
                Else
                    MgrControl.SelectIndexCombo(cmbIndirizzo, R.DefaultIndirizzo.IdIndOnline)
                End If

                If R.TipoDoc = enTipoDocumento.Preventivo Then
                    chkPreventivo.Checked = True
                Else
                    chkPreventivo.Checked = False
                End If

                Dim IdPagamToSel As Integer = R.IdPagamento

                Using Mp As New TipoPagamento
                    Mp.Read(IdPagamToSel)

                    If Mp.PeriodoPagam = enPeriodoPagamento.Anticipato Then
                        If cmbCorriere.SelectedValue = enCorriere.GLS OrElse
                           cmbCorriere.SelectedValue = enCorriere.GLSIsole OrElse
                           cmbCorriere.SelectedValue = enCorriere.PortoAssegnatoGLS Then
                            IdPagamToSel = enMetodoPagamento.ContrassegnoAlRitiro
                        Else
                            IdPagamToSel = enMetodoPagamento.BonificoBancario
                        End If
                    End If

                End Using

                MgrControl.SelectIndexCombo(cmbTipoPagamento, IdPagamToSel)

                'If 1 = 2 Then
                '    If R.Tipo = enTipoRubrica.Cliente Then
                '        'qui devo mostrare il prezzo consigliato al pubblico 
                '        'calcolo il prezzo e aggiorno in automatico il campo prezzo da ricavare 
                '        Using Lb As ListinoBase = New ListinoBase
                '            Lb.Read(_IdListinoBase)


                '        End Using
                '    Else
                '        'altrimenti resetto
                '        ResetTxtTotDaRicavare()
                '    End If
                'End If
            End If


        End Using

    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs)

        CaricaDefaultCliente()

        Using C As New VoceRubrica
            C.Read(cmbClienteSel.IdRubSelezionato)

            If C.Tipo = enTipoRubrica.Rivenditore Then
                txtTotDaRicavare.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_PrezzoRivenditore)
            Else
                txtTotDaRicavare.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_PrezzoAlPubblico)
            End If

        End Using

    End Sub

    Private OTcGrammi As Integer = 0
    Private OFpLarghezza As Integer = 0
    Private OFpAltezza As Integer = 0


    Private Sub lnkAddLavoraz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddLavoraz.LinkClicked

        If DgLavorazioni.SelectedRows.Count Then
            Dim l As Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem


            'check se la lavorazione è realizzabile sul prodotto scelto
            Dim BufferError As String = String.Empty

            If l.GrammiMin <> 0 Then
                If OTcGrammi < l.GrammiMin Then
                    BufferError &= " - La lavorazione prevede minimo " & l.GrammiMin & "gr di carta" & ControlChars.NewLine
                End If
            End If

            If l.GrammiMax <> 0 Then
                If OTcGrammi > l.GrammiMax Then
                    BufferError &= " - La lavorazione prevede massimo " & l.GrammiMin & "gr di carta" & ControlChars.NewLine
                End If
            End If

            If l.DimensMinW <> 0 And l.DimensMinH <> 0 Then
                If (OFpLarghezza < l.DimensMinW Or OFpAltezza < l.DimensMinH) And
                       (OFpLarghezza < l.DimensMinH Or OFpAltezza < l.DimensMinW) Then
                    BufferError &= " - La lavorazione prevede un formato minimo " & l.DimensMinW & "x" & l.DimensMinH & " di carta" & ControlChars.NewLine
                End If
            End If

            If l.DimensMaxW <> 0 And l.DimensMaxH <> 0 Then
                If (OFpLarghezza > l.DimensMaxW Or OFpAltezza > l.DimensMaxH) And
                       (OFpLarghezza > l.DimensMaxH Or OFpAltezza > l.DimensMaxW) Then
                    BufferError &= " - La lavorazione prevede un formato massimo " & l.DimensMaxW & "x" & l.DimensMaxH & " di carta" & ControlChars.NewLine
                End If
            End If

            If BufferError.Length Then
                BufferError = "Attenzione! " & ControlChars.NewLine & BufferError
            End If

            If _LavorazioniSelezionate.IndexOf("," & l.IdLavoro & ",") = -1 Then
                If MessageBox.Show("Confermi la modifica? " & BufferError, "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    For Each Id As String In _LavorazioniSelezionate.Split(",")
                        If Id.Length Then
                            Using LV As New Lavorazione
                                LV.Read(Id)
                                If LV.IdCatLav = l.IdCatLav Then
                                    _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & LV.IdLavoro, String.Empty)
                                    Exit For
                                End If
                            End Using
                        End If
                    Next
                    _LavorazioniSelezionate = _LavorazioniSelezionate & l.IdLavoro & ","

                    CaricaLavorazioniSelezionate()
                    CalcolaPrezzoConsigliato()
                End If
            Else
                MessageBox.Show("La lavorazione è gia presente nell'ordine!")
            End If

        Else
            MessageBox.Show("Selezionare una lavorazione dalla lista")
        End If
    End Sub

    Private Sub lnkSu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSu.LinkClicked
        If DgLavorazioniSel.SelectedRows.Count Then
            'If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SpostaSu()
            'End If
        Else
            MessageBox.Show("Selezionare una lavorazione dalla lista")
        End If
    End Sub

    Private Sub lnkGiu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGiu.LinkClicked

        If DgLavorazioniSel.SelectedRows.Count Then
            'If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SpostaGiu()
            'End If
        Else
            MessageBox.Show("Selezionare una lavorazione dalla lista")
        End If
    End Sub

    Private Sub lnkDelLavoraz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelLavoraz.LinkClicked
        If DgLavorazioniSel.SelectedRows.Count Then

            If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim l As Lavorazione = DgLavorazioniSel.SelectedRows(0).DataBoundItem

                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & l.IdLavoro & ",", ",")

                CaricaLavorazioniSelezionate()
                CalcolaPrezzoConsigliato()
            End If

        Else
            MessageBox.Show("Selezionare una lavorazione dalla lista")
        End If
    End Sub

    Private Sub SpostaSu()
        If DgLavorazioniSel.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavorazioniSel.SelectedRows(0)
            Dim lavorazione As Lavorazione = riga.DataBoundItem
            If (riga.Index - 1) >= 0 Then
                Dim RigaVecchia As DataGridViewRow = DgLavorazioniSel.Rows(riga.Index - 1)
                Dim LavVecchia As Lavorazione = RigaVecchia.DataBoundItem

                'If LavVecchia.IdLavoro <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then

                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavorazione.IdLavoro & ",", "," & lavorazione.IdLavoro & "$,")
                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & LavVecchia.IdLavoro & ",", "," & lavorazione.IdLavoro & ",")
                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavorazione.IdLavoro & "$,", "," & LavVecchia.IdLavoro & ",")
                CaricaLavorazioniSelezionate()
                For Each r As DataGridViewRow In DgLavorazioniSel.Rows
                    If r.DataBoundItem.idlavoro = lavorazione.IdLavoro Then
                        r.Selected = True
                        Exit For
                    End If
                Next
                'Else
                ' MessageBox.Show("La lavorazione non può essere spostata in quella posizione")
                'End If
            End If
            'riga.
        End If
    End Sub

    Private Sub SpostaGiu()
        If DgLavorazioniSel.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavorazioniSel.SelectedRows(0)
            Dim lavorazione As Lavorazione = riga.DataBoundItem

            'If lavorazione.IdLavoro <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then
            If (riga.Index + 1) < DgLavorazioniSel.Rows.Count Then
                Dim RigaDopo As DataGridViewRow = DgLavorazioniSel.Rows(riga.Index + 1)
                Dim lavDopo As Lavorazione = RigaDopo.DataBoundItem

                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavorazione.IdLavoro & ",", "," & lavorazione.IdLavoro & "$,")
                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavDopo.IdLavoro & ",", "," & lavorazione.IdLavoro & ",")
                _LavorazioniSelezionate = _LavorazioniSelezionate.Replace("," & lavorazione.IdLavoro & "$,", "," & lavDopo.IdLavoro & ",")

                CaricaLavorazioniSelezionate()
                For Each r As DataGridViewRow In DgLavorazioniSel.Rows
                    If r.DataBoundItem.idlavoro = lavorazione.IdLavoro Then
                        r.Selected = True
                        Exit For
                    End If
                Next
            End If
            'Else
            'MessageBox.Show("La lavorazione non può essere spostata")
            'End If

            'riga.
        End If
    End Sub

    Private _LavorazioniSelezionate As String = String.Empty

    Private Sub CaricaLavorazioniSelezionate()

        Dim l As New List(Of Lavorazione)

        Dim lInt() As String = _LavorazioniSelezionate.Split(",")

        For Each SingId As String In lInt
            If SingId.Length Then
                Dim singL As New Lavorazione
                singL.Read(SingId)
                l.Add(singL)
            End If
        Next

        'l.Sort(Function(x, y) x.Ordine.CompareTo(y.Ordine))
        DgLavorazioniSel.DataSource = Nothing
        DgLavorazioniSel.AutoGenerateColumns = False
        DgLavorazioniSel.DataSource = l

    End Sub


    Private Sub tvwCat_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwCatLavoraz.AfterSelect

        CaricaLavInCat()

    End Sub

    Private Sub CaricaCat()

        Using C As New CatLavDAO

            tvwCatLavoraz.Nodes.Clear()


            Dim Node As TreeNode = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Tutto, "TUTTO")
            Node.BackColor = Color.White
            Node.ForeColor = Color.Black

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.StampaOffset, "OFFSET")
            Node.BackColor = FormerColori.ColoreRepartoOffset
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.StampaDigitale, "DIGITALE")
            Node.BackColor = FormerColori.ColoreRepartoDigitale
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Packaging, "PACKAGING")
            Node.BackColor = FormerColori.ColoreRepartoPackaging
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Ricamo, "RICAMO")
            Node.BackColor = FormerColori.ColoreRepartoRicamo
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Etichette, "ETICHETTE")
            Node.BackColor = FormerColori.ColoreRepartoEtichette
            Node.ForeColor = Color.White

            tvwCatLavoraz.Nodes.Add("C0", "Senza categoria", 0, 0)

            For Each Cat As CatLav In C.GetAll("OrdineEsecuzione,Descrizione")
                Dim ChiavePadre As String = "C" & Cat.IdCatLav

                Dim ChiaveReparto As String = "R" & Cat.RepartoAppartenenza

                tvwCatLavoraz.Nodes(ChiaveReparto).Nodes.Add(ChiavePadre, Cat.Descrizione, 0, 0)

                'qui devo caricare tutti i singoli formati prodotto che sono linkati in tutte le lavorazioni di questa categoria
                'chiamo un metodo specifico che mi torna una serie di IdFormatoProdotto
                'Using mgr As New FormatiProdottoDAO
                '    For Each IdCl As Integer In mgr.ListaIdFormatoByIdCatLav(Cat.IdCatLav)
                '        Dim ChiaveNodo As String = ChiavePadre & "F" & IdCl
                '        Dim TextNodo As String = String.Empty
                '        If IdCl Then
                '            Dim fp As New FormatoProdotto
                '            fp.Read(IdCl)
                '            TextNodo = fp.Formato
                '        Else
                '            TextNodo = " * - Tutti i formati"
                '        End If
                '        tvwCatLavoraz.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes.Add(ChiaveNodo, TextNodo, 1, 1)

                '        Using mgrL As New LavorazioniDAO
                '            For Each IdL As Integer In mgrL.ListaIdLavorazioniByFormatoProdotto(IdCl, Cat.IdCatLav)
                '                Dim ChiaveNodoL As String = ChiaveNodo & "L" & IdL
                '                Dim TextNodoL As String = String.Empty

                '                Dim L As New Lavorazione
                '                L.Read(IdL)
                '                TextNodo = L.Sigla & " - " & L.Descrizione

                '                tvwCatLavoraz.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes(ChiaveNodo).Nodes.Add(ChiaveNodoL, TextNodo, 2, 2)

                '            Next
                '        End Using



                '    Next
                'End Using

            Next

            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Tutto).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.StampaOffset).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.StampaDigitale).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Ricamo).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Packaging).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Etichette).Expand()

        End Using

    End Sub

    Private Sub CaricaLavInCat()

        'carico la lista delle lavorazioni 

        Using mgr As New LavorazioniDAO


            Dim IdCat As Integer = 0

            If Not tvwCatLavoraz.SelectedNode Is Nothing Then

                If tvwCatLavoraz.SelectedNode.Name.StartsWith("C") Then
                    Dim PosizF As Integer = tvwCatLavoraz.SelectedNode.Name.IndexOf("F")
                    If PosizF <> -1 Then
                        IdCat = tvwCatLavoraz.SelectedNode.Name.Substring(1, PosizF - 1)
                    Else
                        IdCat = tvwCatLavoraz.SelectedNode.Name.Substring(1)
                    End If
                End If

                Dim l As List(Of LavorazioneEx) = mgr.ListaLavorazioni(0, IdCat) ',cmbCategoria.SelectedValue)
                DgLavorazioni.AutoGenerateColumns = False
                DgLavorazioni.DataSource = l

            End If
        End Using

        'Dim x As New cLavoriColl
        'Dim dtLista As DataTable

        'dtLista = x.ListaLavorazioni

        'DgLavorazioni.DataSource = dtLista

        'DgLavorazioni.Columns(0).Visible = False
        'DgLavorazioni.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"

        'x = Nothing

    End Sub

    Private Sub txtNomeLavoro_TextChanged(sender As Object, e As EventArgs) Handles txtNomeLavoro.TextChanged
        If sender.focused Then
            If txtNomeLavoro.Text.Trim.Length Then
                chkUsaNomeLavoro.Checked = True
            Else
                chkUsaNomeLavoro.Checked = False
            End If
        End If
    End Sub

    Private Sub chkUsaNomeLavoro_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsaNomeLavoro.CheckedChanged
        If sender.checked Then
            sender.backcolor = Color.Green
            sender.forecolor = Color.White
        Else
            sender.backcolor = Color.White
            sender.forecolor = Color.Black
        End If
    End Sub

    Private Sub OpenFileImg_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileImg.FileOk

    End Sub

    Private Sub txtFronte_TextChanged(sender As Object, e As EventArgs) Handles txtFronte.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub lblTipo_Click(sender As Object, e As EventArgs) Handles lblTipo.Click

    End Sub

    Private Sub cmbClienteSel_SelectedIndexChanged(sender As Object, e As PositionChangedEventArgs) Handles cmbClienteSel.SelectedIndexChanged
        CaricaDefaultCliente()

        Using C As New VoceRubrica
            C.Read(cmbClienteSel.IdRubSelezionato)

            If C.Tipo = enTipoRubrica.Rivenditore Then
                txtTotDaRicavare.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_PrezzoRivenditore)
            Else
                txtTotDaRicavare.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_PrezzoAlPubblico)
            End If

            CalcolaPrezzoConsigliato()

        End Using
    End Sub

    Private Sub lnkDettaglioSel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDettaglioSel.LinkClicked
        If DgLavorazioniSel.SelectedRows.Count Then
            Dim l As Lavorazione = DgLavorazioniSel.SelectedRows(0).DataBoundItem
            Sottofondo()
            Using f As New frmListinoLavorazione
                f.Carica(l.IdLavoro)
            End Using
            Sottofondo()
        End If
    End Sub

    Private Sub lnkDettaglioDisp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDettaglioDisp.LinkClicked
        If DgLavorazioni.SelectedRows.Count Then
            Dim l As Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem
            Sottofondo()
            Using f As New frmListinoLavorazione
                f.Carica(l.IdLavoro)
            End Using
            Sottofondo()
        End If
    End Sub

    Private Sub cmbClienteSel_Load(sender As Object, e As EventArgs) Handles cmbClienteSel.Load

    End Sub

    Private Sub txtQtaReale_TextChanged(sender As Object, e As EventArgs) Handles txtQtaReale.TextChanged

    End Sub

    Private Sub DtDataConsegna_ValueChanged(sender As Object, e As EventArgs) Handles dtDataConsegna.ValueChanged
        lblDataPrevistaConsegna.Text = CalcolaDataPrevistaConsegna().ToString("dd/MM/yyyy")
    End Sub

    Private Function CalcolaDataPrevistaConsegna() As Date

        Dim DataPrevistaProduzione As Date = dtDataConsegna.Value
        Dim DataPrevistaConsegna As Date = Date.MinValue
        Dim IdCorriere As Integer = cmbCorriere.SelectedValue
        Using C As New Corriere
            C.Read(IdCorriere)
            DataPrevistaConsegna = MgrDataConsegna.CalcolaDataConsegna(DataPrevistaProduzione, C)
        End Using

        Return DataPrevistaConsegna

    End Function

    Private Sub cmbCorriere_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCorriere.SelectedIndexChanged
        lblDataPrevistaConsegna.Text = CalcolaDataPrevistaConsegna().ToString("dd/MM/yyyy")
    End Sub

End Class