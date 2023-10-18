Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerLib
Imports FormerConfig
Imports Telerik.WinControls.UI

Friend Class frmListinoPreventivazione
    'Inherits baseFormInternaRedim

    Private _Ris As Integer
    Private _Prev As New Preventivazione


    Private Sub CaricaNodi()
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()

        Dim ChiaveSelezionata As String = String.Empty

        tvwLB.Nodes.Clear()

        'qui carico i listini base nell'albero
        For Each L As ListinoBase In _Prev.ListiniBase
            Dim NodoFormato As TreeNode = tvwLB.Nodes("F" & L.IdFormProd)
            If NodoFormato Is Nothing Then
                NodoFormato = tvwLB.Nodes.Add("F" & L.IdFormProd, L.FormatoProdotto.Formato)
            End If
            NodoFormato.Expand()
            'NodoFormato.Nodes.Add("L" & L.IdListinoBase, L.Riassunto & IIf(L.InEvidenza = enSiNo.Si, " (Evi)", ""), 1, 1)
            Dim NodoListino As TreeNode = NodoFormato.Nodes.Add("L" & L.IdListinoBase, L.NomeEx, 1, 1)

            NodoListino.Tag = L

        Next

        tvwLB.ExpandAll()



        Cursor.Current = Cursors.Default

    End Sub


    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()


    End Sub

    Private Sub CaricaCombo()

        Dim TipoProd As New cTipoProdCom(False)
        cmbTipoProd.DataSource = TipoProd
        cmbTipoProd.ValueMember = "Id"
        cmbTipoProd.DisplayMember = "Descrizione"

        'CARICO I REPARTI
        Dim Campo As FormerLib.cEnum

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.StampaOffset)
        Campo.Descrizione = "Stampa OffSet"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.StampaDigitale)
        Campo.Descrizione = "Stampa Digitale"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Packaging)
        Campo.Descrizione = "Packaging"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Ricamo)
        Campo.Descrizione = "Ricamo"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Etichette)
        Campo.Descrizione = "Etichette"
        cmbReparto.Items.Add(Campo)

        'CARICO LE FUNZIONI PACKAGING
        Campo = New FormerLib.cEnum
        Campo.Id = 0
        Campo.Descrizione = "Seleziona una funzione"
        cmbFunzionePackaging.Items.Add(Campo)

        For Each x As enFunzionePackaging In [Enum].GetValues(GetType(enFunzionePackaging))
            Campo = New FormerLib.cEnum
            Campo.Id = CInt(x)
            Campo.Descrizione = MgrPluginPackaging.GetNomeStandardECMA(x)
            cmbFunzionePackaging.Items.Add(Campo)
        Next

        'CARICO I PLUGIN ONLINE 
        Campo = New FormerLib.cEnum
        Campo.Id = 0
        Campo.Descrizione = "Seleziona un plugin del sito"
        cmbPlugin.Items.Add(Campo)

        For Each x As enPluginOnline In [Enum].GetValues(GetType(enPluginOnline))
            If CInt(x) Then 'escludo la voce 0
                Campo = New FormerLib.cEnum
                Campo.Id = CInt(x)
                Campo.Descrizione = GetNomePlugin(x)
                cmbPlugin.Items.Add(Campo)
            End If
        Next

    End Sub

    Public Sub CaricaColoriStampaDefault()

        Dim IdOld As Integer = cmbColoreStampaDefault.SelectedValue

        Dim IdColoreStampa As New List(Of Integer)
        For Each Lb As ListinoBase In _Prev.ListiniBase
            If IdColoreStampa.FindAll(Function(x) x = Lb.IdColoreStampa).Count = 0 Then
                IdColoreStampa.Add(Lb.IdColoreStampa)
            End If
        Next

        Dim ListaId As String = String.Empty

        For Each SingId In IdColoreStampa
            ListaId &= SingId & ","
        Next
        If ListaId.Length Then
            ListaId = "(" & ListaId.TrimEnd(",") & ")"

            Using mgr As New ColoriStampaDAO
                Dim l As List(Of ColoreStampa) = mgr.FindAll(New LUNA.LunaSearchOption With {.AddEmptyItem = True},
                                                             New LUNA.LunaSearchParameter(LFM.ColoreStampa.IdColoreStampa, ListaId, "IN"))

                cmbColoreStampaDefault.ValueMember = LFM.ColoreStampa.IdColoreStampa.Name
                cmbColoreStampaDefault.DisplayMember = LFM.ColoreStampa.Descrizione.Name
                cmbColoreStampaDefault.DataSource = l

            End Using

            If IdOld Then MgrControl.SelectIndexCombo(cmbColoreStampaDefault, IdOld)
        End If


    End Sub


    Public Function GetNomePlugin(IdPlugin As enPluginOnline) As String

        Dim ris As String = String.Empty

        Select Case IdPlugin
            Case enPluginOnline.Etichette
                ris = "Etichette"
            Case enPluginOnline.Packaging
                ris = "Packaging"
            Case enPluginOnline.EtichetteCm
                ris = "Etichette a Cm^2"
        End Select

        Return ris

    End Function

    Private Sub CaricaListiniBase()

        Dim L As ListinoBase = Nothing

        'If DgListinoBase.SelectedRows.Count Then
        '    L = DgListinoBase.SelectedRows(0).DataBoundItem
        'End If

        'DgListinoBase.DataSource = Nothing

        'DgListinoBase.Rows.Clear()

        _Prev.CaricaListinoBase(, enTipoListiniBase.Sorgente)

        'DgListinoBase.AutoGenerateColumns = False
        'DgListinoBase.DataSource = _Prev.ListiniBase

        CaricaNodi()


        'DgListinoBase.Refresh()
        CaricaListiniBaseOrdine()

        CaricaColoriStampaDefault()
        'If Not L Is Nothing Then
        '    For Each r As DataGridViewRow In DgListinoBase.Rows
        '        If DirectCast(r.DataBoundItem, ListinoBase).IdListinoBase = L.IdListinoBase Then
        '            r.Selected = True
        '            Exit For
        '        End If
        '    Next

        '    DgListinoBase.Select()
        'End If

    End Sub

    Private Sub CaricaListiniBaseOrdine()

        DgListiniBase.Rows.Clear()

        For Each L As ListinoBase In _Prev.ListiniBase
            'ordine prodotto cliente spazi duplicati
            Dim ImgPreview As Image
            Dim ImgNew As Image = Nothing
            Try
                ImgPreview = Image.FromFile(L.GetImgFormato)
                ImgNew = New Bitmap(ImgPreview, New Size(48, 48))

            Catch ex As Exception

            End Try

            Dim Riga As New DataGridViewRow
            Riga.CreateCells(DgListiniBase)

            Riga.Cells(0).Value = ImgNew
            Riga.Cells(1).Value = L.NomeEx
            Riga.Tag = L.IdListinoBase

            DgListiniBase.Rows.Add(Riga)
        Next

        PreviewLbOrder()

    End Sub

    Private Sub CaricaListiniBaseLinkati()
        dgListinoLink.DataSource = Nothing
        dgListinoLink.Rows.Clear()

        _Prev.CaricaListiniLinkati()

        dgListinoLink.AutoGenerateColumns = False
        dgListinoLink.DataSource = _Prev.ListiniLinkati

        'DgListinoBase.Refresh()
    End Sub

    Friend Function Carica(Optional Id As Integer = 0) As Integer



        CaricaCombo()

        If Id Then

            _Prev.Read(Id)
            'ricarico i valori
            txtCodice.Text = _Prev.Prefisso
            txtDescr.Text = _Prev.Descrizione
            txtDescrEstesa.Text = _Prev.DescrizioneEstesa
            txtGGFast.Text = _Prev.ggFast
            txtGGNorm.Text = _Prev.ggNorm
            txtGGLow.Text = _Prev.ggSlow
            txtImpGrafica.Text = _Prev.GraficaPerFacciata
            '_Prev.RicaricoCliente = txtRicarico.Text
            MgrControl.SelectIndexCombo(cmbTipoProd, _Prev.TipoProd)

            txtVideoYoutube.Text = _Prev.UrlVideo

            txtLinguetta.Text = _Prev.Linguetta
            MgrControl.SelectIndexComboEnum(cmbFunzionePackaging, _Prev.IdFunzionePack)
            MgrControl.SelectIndexComboEnum(cmbPlugin, _Prev.IdPluginToUse)
            'btnAddListBase.Visible = True
            'btnDelListBase.Visible = True

            If Not _Prev.GruppoVarianteRif Is Nothing Then
                lblGruppoVariante.Text = _Prev.GruppoVarianteRif.Nome
                lblGruppoVariante.Tag = _Prev.GruppoVariante
            Else
                lblGruppoVariante.Text = "-"
                lblGruppoVariante.Tag = 0
            End If

            txtPercCoupon.Text = _Prev.PercCoupon

            If _Prev.PercFast Then txtPercFast.Text = _Prev.PercFast
            If _Prev.PercSlow Then txtPercSlow.Text = _Prev.PercSlow

            CaricaListiniBase()
            CaricaListiniBaseLinkati()

            MgrControl.SelectIndexCombo(cmbColoreStampaDefault, _Prev.IdColoreStampaDefault)

            txtImgLav.Text = _Prev.ImgRif
            txtImgSito.Text = _Prev.ImgSito

            Try
                If txtImgLav.Text.Length Then
                    If File.Exists(txtImgLav.Text) Then
                        pctImgLav.Image = Image.FromFile(txtImgLav.Text)
                    End If
                End If
            Catch ex As Exception

            End Try

            Try
                If txtImgSito.Text.Length Then
                    If File.Exists(txtImgSito.Text) Then
                        pctImgSito.Image = Image.FromFile(txtImgSito.Text)
                    End If
                End If
            Catch ex As Exception

            End Try

            MgrControl.SelectIndexComboEnum(cmbReparto, _Prev.IdReparto)
            chkDispOnline.Checked = _Prev.DispOnline

            If _Prev.NascondiAlbero = enSiNo.Si Then
                chkNascondiAlbero.Checked = True
            End If

            txtRicercaGoogle.Text = _Prev.GoogleDescr
            chkSaltaFP.Checked = IIf(_Prev.SaltaFP = enSiNo.Si, True, False)
            chkSaltaTC.Checked = IIf(_Prev.SaltaTC = enSiNo.Si, True, False)
            chkSaltaCS.Checked = IIf(_Prev.SaltaCS = enSiNo.Si, True, False)


        Else
            MgrControl.SelectIndexComboEnum(cmbPlugin, 0)
            MgrControl.SelectIndexComboEnum(cmbTipoProd, enTipoProdCom.StampaOffSet)
            MgrControl.SelectIndexComboEnum(cmbReparto, enRepartoWeb.StampaOffset)
            cmbFunzionePackaging.SelectedIndex = 0
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

    'Private Sub btnCreaExcel_Click(sender As Object, e As EventArgs)

    '    Dim excel As Application = New Application
    '    Dim misValue As Object = System.Reflection.Missing.Value
    '    Dim w As Workbook = excel.Workbooks.Add(misValue)
    '    w.Worksheets(3).delete()
    '    w.Worksheets(2).delete()
    '    'cancello gli altri sheet

    '    Dim sheet As Worksheet = w.Sheets(1)
    '    sheet.Name = "Risultati"
    '    Dim PathDir As String = FormerPath.PathLocale & "xls\"
    '    CreateLongDir(PathDir)
    '    Dim PathXLS As String = PathDir & GetNomeFileTemp(".xls")
    '    'Dim X As New Microsoft.Office.Interop.Excel.Workbook

    '    'IDFORMATO IDCARTA FORMATO CARTA 
    '    '500 1000 2000 3000 4000 5000 6000 7000 8000 9000 10000 15000 20000 30000 
    '    '40000 50000 60000 70000 80000 90000 100000

    '    Dim style As Style = w.Styles.Add("NewStyle")
    '    style.Font.Bold = True
    '    style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)


    '    'Dim r As Range = sheet.UsedRange

    '    sheet.Cells(1, 1).value = "IDFP"
    '    sheet.Cells(1, 2).value = "IDC"
    '    sheet.Cells(1, 3).value = "FORMPROD"
    '    sheet.Cells(1, 4).value = "CARTA"
    '    sheet.Cells(1, 5).value = "PREZZOCARTA"
    '    sheet.Cells(1, 6).value = "IDCURVA"
    '    sheet.Cells(1, 7).value = "COLORIDISTAMPA"
    '    sheet.Cells(1, 8).value = "500"
    '    sheet.Cells(1, 9).value = "1000"
    '    sheet.Cells(1, 10).value = "2000"
    '    sheet.Cells(1, 11).value = "3000"
    '    sheet.Cells(1, 12).value = "4000"
    '    sheet.Cells(1, 13).value = "5000"
    '    sheet.Cells(1, 14).value = "6000"
    '    sheet.Cells(1, 15).value = "7000"
    '    sheet.Cells(1, 16).value = "8000"
    '    sheet.Cells(1, 17).value = "9000"
    '    sheet.Cells(1, 18).value = "10000"
    '    sheet.Cells(1, 19).value = "15000"
    '    sheet.Cells(1, 20).value = "20000"
    '    sheet.Cells(1, 21).value = "30000"
    '    sheet.Cells(1, 22).value = "40000"
    '    sheet.Cells(1, 23).value = "50000"
    '    sheet.Cells(1, 24).value = "60000"
    '    sheet.Cells(1, 25).value = "70000"
    '    sheet.Cells(1, 26).value = "80000"
    '    sheet.Cells(1, 27).value = "90000"
    '    sheet.Cells(1, 28).value = "100000"

    '    Dim ColsI As Integer = 29

    '    For Each itemL As Lavorazione In chkLstLav.CheckedItems

    '        sheet.Cells(1, ColsI).value = itemL.IdLavoro & "@" & itemL.Descrizione & " Min."
    '        ColsI += 1

    '        sheet.Cells(1, ColsI).value = itemL.IdLavoro & "@" & itemL.Descrizione & " Copia"

    '        ColsI += 1

    '    Next

    '    For y As Integer = 1 To 50
    '        sheet.Cells(1, y).Style = "NewStyle"
    '    Next

    '    Dim RowsI As Integer = 2
    '    For Each item As FormatoProdotto In chkLstFormati.CheckedItems

    '        For Each itemC As TipoCarta In chkLstCarta.CheckedItems

    '            Dim Sigla As String = item.Sigla & itemC.Sigla

    '            Dim sheetForm As Worksheet = w.Sheets.Add

    '            sheetForm.Name = Sigla
    '            sheetForm.Cells(1, 1) = item.Formato & " " & itemC.Tipologia

    '            sheet.Cells(RowsI, 1) = item.IdFormProd
    '            sheet.Cells(RowsI, 2) = itemC.IdTipoCarta
    '            sheet.Cells(RowsI, 3) = item.Formato
    '            sheet.Cells(RowsI, 4) = itemC.Tipologia
    '            sheet.Cells(RowsI, 5) = "='" & Sigla & "'!B5"
    '            sheet.Cells(RowsI, 6) = "='" & Sigla & "'!C1"
    '            Dim ColsInd As Integer = 8
    '            For indC As Integer = 68 To 88
    '                sheet.Cells(RowsI, ColsInd) = "='" & Sigla & "'!" & Chr(indC) & "51"
    '                ColsInd += 1
    '            Next
    '            RowsI += 1
    '        Next

    '    Next

    '    Dim sheet2 As Worksheet = w.Sheets.Add()
    '    sheet2.Name = "Curve Attenuatori"
    '    sheet2.Cells(1, 1).value = "IDCURVA"
    '    sheet2.Cells(1, 2).value = "NOMECURVA"
    '    sheet2.Cells(1, 3).value = ""
    '    sheet2.Cells(1, 4).value = ""
    '    sheet2.Cells(1, 5).value = "500"
    '    sheet2.Cells(1, 6).value = "1000"
    '    sheet2.Cells(1, 7).value = "2000"
    '    sheet2.Cells(1, 8).value = "3000"
    '    sheet2.Cells(1, 9).value = "4000"
    '    sheet2.Cells(1, 10).value = "5000"
    '    sheet2.Cells(1, 11).value = "6000"
    '    sheet2.Cells(1, 12).value = "7000"
    '    sheet2.Cells(1, 13).value = "8000"
    '    sheet2.Cells(1, 14).value = "9000"
    '    sheet2.Cells(1, 15).value = "10000"
    '    sheet2.Cells(1, 16).value = "15000"
    '    sheet2.Cells(1, 17).value = "20000"
    '    sheet2.Cells(1, 18).value = "30000"
    '    sheet2.Cells(1, 19).value = "40000"
    '    sheet2.Cells(1, 20).value = "50000"
    '    sheet2.Cells(1, 21).value = "60000"
    '    sheet2.Cells(1, 22).value = "70000"
    '    sheet2.Cells(1, 23).value = "80000"
    '    sheet2.Cells(1, 24).value = "90000"
    '    sheet2.Cells(1, 25).value = "100000"

    '    For y As Integer = 1 To 25
    '        sheet2.Cells(1, y).Style = "NewStyle"
    '    Next

    '    RowsI = 2
    '    Dim lC As List(Of CurvaAtt) = (New CurveAttDAO).GetAll("NomeCurva")
    '    For Each C As CurvaAtt In lC
    '        sheet2.Cells(RowsI, 1) = C.IdCurvaAtt
    '        sheet2.Cells(RowsI, 2) = C.NomeCurva
    '        sheet2.Cells(RowsI, 5) = C.v500
    '        sheet2.Cells(RowsI, 6) = C.v1000
    '        sheet2.Cells(RowsI, 7) = C.v2000
    '        sheet2.Cells(RowsI, 8) = C.v3000
    '        sheet2.Cells(RowsI, 9) = C.v4000
    '        sheet2.Cells(RowsI, 10) = C.v5000
    '        sheet2.Cells(RowsI, 11) = C.v6000
    '        sheet2.Cells(RowsI, 12) = C.v7000
    '        sheet2.Cells(RowsI, 13) = C.v8000
    '        sheet2.Cells(RowsI, 14) = C.v9000
    '        sheet2.Cells(RowsI, 15) = C.v10000
    '        sheet2.Cells(RowsI, 16) = C.v15000
    '        sheet2.Cells(RowsI, 17) = C.v20000
    '        sheet2.Cells(RowsI, 18) = C.v30000
    '        sheet2.Cells(RowsI, 19) = C.v40000
    '        sheet2.Cells(RowsI, 20) = C.v50000
    '        sheet2.Cells(RowsI, 21) = C.v60000
    '        sheet2.Cells(RowsI, 22) = C.v70000
    '        sheet2.Cells(RowsI, 23) = C.v80000
    '        sheet2.Cells(RowsI, 24) = C.v90000
    '        sheet2.Cells(RowsI, 25) = C.v100000
    '        RowsI += 1
    '    Next

    '    w.SaveAs(PathXLS)
    '    w.Close()
    '    excel.Quit()

    '    releaseObject(sheet)
    '    releaseObject(w)
    '    releaseObject(excel)

    '    FormerHelper.File.ShellExtended(PathXLS)

    'End Sub

    'Private Sub btnSfoglia_Click(sender As Object, e As EventArgs)

    '    openXLS.ShowDialog()
    '    If openXLS.FileName.Length Then
    '        txtFileXLS.Text = openXLS.FileName
    '    End If

    'End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    'Private Sub btnRecupera_Click(sender As Object, e As EventArgs)

    '    Dim excel As Application = New Application
    '    Dim misValue As Object = System.Reflection.Missing.Value
    '    Dim w As Workbook = excel.Workbooks.Open(txtFileXLS.Text)

    '    Dim sheet As Worksheet = w.Sheets("sheet1")

    '    'IDFORMATO IDCARTA FORMATO CARTA 
    '    '500 1000 2000 3000 4000 5000 6000 7000 8000 9000 10000 15000 20000 30000 
    '    '40000 50000 60000 70000 80000 90000 100000

    '    Dim RowsI As Integer = 2
    '    Dim strTrovata As String = ""

    '    Do

    '        strTrovata = sheet.Cells(RowsI, 1).value  'IDFORMPROD

    '        If Not strTrovata Is Nothing Then
    '            'qui se ho trovato qualcosa lo interpreto e lo salvo altrimenti vuoldire che sono finite le righe piene
    '            'mi becco il valore
    '            Dim Valore As String = sheet.Cells(RowsI, 5).value

    '            Valore = Valore
    '        End If

    '        RowsI += 1

    '    Loop While Not strTrovata Is Nothing

    '    w.Close()
    '    excel.Quit()

    '    releaseObject(sheet)
    '    releaseObject(w)
    '    releaseObject(excel)

    'End Sub

    Private Function SalvaPreventivazione() As Integer

        Dim ris As Integer = 0

        Dim CheckOkQuantita As Boolean = True

        Dim Qta1Inserita As Boolean = False
        Dim Qta2Inserita As Boolean = False
        Dim Qta3Inserita As Boolean = False
        Dim Qta4Inserita As Boolean = False
        Dim Qta5Inserita As Boolean = False

        If txtQta1.Value <> 0 Then
            Qta1Inserita = True
        End If
        If txtQta2.Value <> 0 Then
            Qta2Inserita = True
        End If
        If txtQta3.Value <> 0 Then
            Qta3Inserita = True
        End If
        If txtQta4.Value <> 0 Then
            Qta4Inserita = True
        End If
        If txtQta5.Value <> 0 Then
            Qta5Inserita = True
        End If

        If Qta1Inserita = True Or Qta2Inserita = True Or Qta3Inserita = True Or Qta4Inserita = True Or Qta5Inserita = True Then
            If Qta1Inserita = True And Qta2Inserita = True And Qta3Inserita = True And Qta4Inserita = True And Qta5Inserita = True Then
                CheckOkQuantita = True
            Else
                CheckOkQuantita = False
            End If
        End If

        If CheckOkQuantita Then
            If MessageBox.Show("Confermi il salvataggio della preventivazione?", "Preventivazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

                _Prev.Prefisso = txtCodice.Text
                _Prev.Descrizione = txtDescr.Text
                _Prev.DescrizioneEstesa = txtDescrEstesa.Text
                _Prev.ggFast = txtGGFast.Text
                _Prev.ggNorm = txtGGNorm.Text
                _Prev.ggSlow = txtGGLow.Text
                _Prev.GraficaPerFacciata = txtImpGrafica.Text
                '_Prev.RicaricoCliente = txtRicarico.Text
                _Prev.TipoProd = cmbTipoProd.SelectedValue
                _Prev.UrlVideo = txtVideoYoutube.Text
                _Prev.DispOnline = chkDispOnline.Checked
                _Prev.IdReparto = cmbReparto.SelectedItem.Id
                _Prev.Linguetta = txtLinguetta.Text
                _Prev.IdFunzionePack = cmbFunzionePackaging.SelectedItem.Id
                _Prev.PercCoupon = txtPercCoupon.Text
                _Prev.GoogleDescr = txtRicercaGoogle.Text
                _Prev.IdPluginToUse = cmbPlugin.SelectedItem.Id
                _Prev.IdColoreStampaDefault = cmbColoreStampaDefault.SelectedValue
                _Prev.NascondiAlbero = IIf(chkNascondiAlbero.Checked, enSiNo.Si, enSiNo.No)
                _Prev.PercFast = txtPercFast.Text
                _Prev.PercSlow = txtPercSlow.Text

                _Prev.SaltaFP = IIf(chkSaltaFP.Checked, enSiNo.Si, enSiNo.No)
                _Prev.SaltaTC = IIf(chkSaltaTC.Checked, enSiNo.Si, enSiNo.No)
                _Prev.SaltaCS = IIf(chkSaltaCS.Checked, enSiNo.Si, enSiNo.No)

                If _Prev.IsValid Then
                    Dim lst As List(Of Preventivazione) = Nothing
                    Using mgr As New PreventivazioniDAO
                        lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Preventivazione.Prefisso, _Prev.Prefisso),
                                          New LUNA.LunaSearchParameter(LFM.Preventivazione.IdPrev, _Prev.IdPrev, "<>"))
                    End Using
                    If lst.Count Then
                        'codice non univoco
                        MessageBox.Show("Il Prefisso inserito non è univoco! Cambiarlo", "Former", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        'copio l'immagine nella cartella centralizzata
                        If txtImgLav.Text.Length Then
                            If txtImgLav.Text <> _Prev.ImgRif Then
                                Dim nuovoNome As String = String.Empty
                                If txtImgLav.Text.StartsWith(FormerPath.PathListinoImg) Then
                                    'non devo copiare
                                    nuovoNome = txtImgLav.Text
                                Else
                                    'devo copiare 
                                    Dim F As New FileInfo(txtImgLav.Text)
                                    nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLav.Text),, _Prev.Descrizione)
                                    MgrIO.FileCopia(Me, txtImgLav.Text, nuovoNome)
                                End If
                                _Prev.ImgRif = nuovoNome
                            End If

                        End If

                        'copio l'immagine nella cartella centralizzata
                        If txtImgSito.Text.Length Then
                            If txtImgSito.Text <> _Prev.ImgSito Then
                                Dim nuovoNome As String = String.Empty
                                If txtImgSito.Text.StartsWith(FormerPath.PathListinoImg) Then
                                    'non devo copiare
                                    nuovoNome = txtImgSito.Text
                                Else
                                    'devo copiare 
                                    Dim F As New FileInfo(txtImgSito.Text)
                                    nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgSito.Text),, _Prev.Descrizione)
                                    MgrIO.FileCopia(Me, txtImgSito.Text, nuovoNome)
                                End If
                                _Prev.ImgSito = nuovoNome
                            End If

                        End If

                        _Prev.Save()
                        _Ris = _Prev.IdPrev

                        'qui salvo i listini base dopo averli cancellati 
                        'Dim MLb As New ListinoBaseDAO
                        'MLb.DeleteByIdPrev(_Prev.IdPrev)

                        'For Each lb As ListinoBase In _Prev.ListinoBase
                        '    If lb.IdPrev = 0 Then lb.IdPrev = _Prev.IdPrev
                        '    lb.IdListinoBase = 0 'lo setto a 0 per risalvarlo da zero nuovo ogni volta 
                        '    lb.Save()
                        'Next
                        If Qta1Inserita Then
                            'qui vuoldire che devo salvarle
                            Dim qta As ParamListino = Nothing

                            Using mgr As New ParamListiniDAO
                                Dim l As List(Of ParamListino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ParamListino.IdPrev, _Prev.IdPrev))

                                If l.Count Then
                                    qta = l(0)
                                End If

                            End Using

                            If qta Is Nothing Then
                                qta = New ParamListino
                                qta.IdPrev = _Prev.IdPrev
                            End If

                            qta.Qta1 = txtQta1.Text
                            qta.Qta2 = txtQta2.Text
                            qta.Qta3 = txtQta3.Text
                            qta.Qta4 = txtQta4.Text
                            qta.Qta5 = txtQta5.Text
                            qta.Save()

                        Else
                            'qui devo cancellarle se ci sono 

                            Using mgr As New ParamListiniDAO
                                mgr.DeleteByIdPrev(_Prev.IdPrev)
                            End Using

                        End If

                        SalvaOrdinamento()

                        ris = 1
                        '_Ris = 1
                        'Close()
                    End If
                Else
                    'errore dati non validi 
                    MessageBox.Show("I dati inseriti non sono validi. Completare tutti i campi!")
                End If
            End If
        Else
            MessageBox.Show("Le quantità per il Listini PDF devono essere inserite obbligatoriamente tutte quante, o nessuna.")
        End If

        Return ris

    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If SalvaPreventivazione() Then
            '_Ris = 1
            Close()
        End If

    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoProd.SelectedIndexChanged

        lblIntroPrev.BackColor = FormerColori.GetColoreReparto(cmbTipoProd.SelectedItem.id)

        Dim ColoreTesto As Color = Color.Black

        If cmbTipoProd.SelectedItem.id = enRepartoWeb.StampaOffset Or cmbTipoProd.SelectedItem.id = enRepartoWeb.Etichette Then
            ColoreTesto = Color.White
        End If

        lblIntroPrev.ForeColor = ColoreTesto

        MgrControl.SelectIndexComboEnum(cmbReparto, cmbTipoProd.SelectedItem.id)

    End Sub

    Private Sub btnAddListBase_Click(sender As Object, e As EventArgs) Handles btnAddListBase.Click

        Dim OkAggiungi As Boolean = False

        If _Prev.IdPrev = 0 Then
            If SalvaPreventivazione() Then
                OkAggiungi = True

            End If
        Else
            OkAggiungi = True
        End If

        If OkAggiungi Then
            Sottofondo()
            Dim a As New frmListinoBase
            Dim L As New ListinoBase

            'Dim LstLav As New List(Of Lavorazione)

            'For Each item As Lavorazione In chkListLav.CheckedItems

            '    LstLav.Add(item)

            'Next


            Dim Ris As Integer = a.Carica(L, _Prev)
            If Ris Then

                CaricaListiniBase()
                'qui lo gestisco
                'If _Prev.IdPrev Then L.IdPrev = _Prev.IdPrev

                '_Prev.ListinoBase.Add(L)
                'DgListinoBase.DataSource = Nothing
                'DgListinoBase.Rows.Clear()

                'DgListinoBase.AutoGenerateColumns = False
                'DgListinoBase.DataSource = _Prev.ListinoBase

                'DgListinoBase.Refresh()

            End If
            Sottofondo()
        End If

    End Sub

    'Private Sub chkListLav_ItemCheck(sender As Object, e As ItemCheckEventArgs)
    '    If e.NewValue = CheckState.Checked Then
    '        Dim item As Lavorazione = chkListLav.Items(e.Index)

    '        For Each i As Lavorazione In chkListLavOpz.CheckedItems
    '            If i.IdLavoro = item.IdLavoro Then
    '                'deselezionare la voce
    '                chkListLavOpz.SetItemCheckState(e.Index, CheckState.Unchecked)
    '                Exit For
    '            End If
    '        Next

    '    End If

    'End Sub

    'Private Sub chkListLav_SelectedIndexChanged(sender As Object, e As EventArgs)

    'End Sub

    'Private Sub chkListLavOpz_ItemCheck(sender As Object, e As ItemCheckEventArgs)
    '    If e.NewValue = CheckState.Checked Then
    '        Dim item As Lavorazione = chkListLavOpz.Items(e.Index)

    '        For Each i As Lavorazione In chkListLav.CheckedItems
    '            If i.IdLavoro = item.IdLavoro Then
    '                'deselezionare la voce
    '                chkListLav.SetItemCheckState(e.Index, CheckState.Unchecked)
    '                Exit For
    '            End If
    '        Next

    '    End If
    'End Sub

    Private Sub btnDelListBase_Click(sender As Object, e As EventArgs) Handles btnDelListBase.Click

        If Not tvwLB.SelectedNode Is Nothing Then

            If tvwLB.SelectedNode.Name.StartsWith("L") Then
                If MessageBox.Show("Confermi la cancellazione del listinobase? ATTENZIONE l'operazione non può essere annullata!", "Cancellazione listino base", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim L As ListinoBase = tvwLB.SelectedNode.Tag

                    L.Disattivo = enSiNo.Si
                    L.Save()
                    '                Using lmg As New ListinoBaseDAO
                    'lmg.Delete(L.IdListinoBase)
                    'End Using
                    CaricaListiniBase()

                End If
            End If

        End If


        'If DgListinoBase.SelectedRows.Count Then
        '    If MessageBox.Show("Confermi la cancellazione del listinobase? ATTENZIONE l'operazione non può essere annullata!", "Cancellazione listino base", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        Dim L As ListinoBase = DgListinoBase.SelectedRows(0).DataBoundItem

        '        L.Disattivo = enSiNo.Si
        '        L.Save()
        '        '                Using lmg As New ListinoBaseDAO
        '        'lmg.Delete(L.IdListinoBase)
        '        'End Using
        '        CaricaListiniBase()

        '    End If

        '    '_Prev.ListinoBase.Remove(L)
        '    'DgListinoBase.DataSource = Nothing
        '    'DgListinoBase.Rows.Clear()
        '    'DgListinoBase.AutoGenerateColumns = False
        '    'DgListinoBase.DataSource = _Prev.ListinoBase

        '    '' DgListinoBase.Refresh()

        'End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgLav.Text = OpenFileImg.FileName
            pctImgLav.Image = Image.FromFile(txtImgLav.Text)
        End If
    End Sub

    Private Sub Duplica()

        If Not tvwLB.SelectedNode Is Nothing Then

            If tvwLB.SelectedNode.Name.StartsWith("L") Then
                Dim LOld As ListinoBase = tvwLB.SelectedNode.Tag
                LOld.CaricaLavorazioni()
                Dim L As ListinoBase = LOld.Clone
                Sottofondo()
                Dim a As New frmListinoBase

                'Dim LstLav As New List(Of Lavorazione)

                'For Each item As Lavorazione In chkListLav.CheckedItems

                '    LstLav.Add(item)

                'Next

                Dim Ris As Integer = a.Carica(L, _Prev, True)
                Sottofondo()
                If Ris Then

                    CaricaListiniBase()
                    ''qui lo gestisco
                    'If _Prev.IdPrev Then L.IdPrev = _Prev.IdPrev

                    '_Prev.ListinoBase.Add(L)
                    'DgListinoBase.DataSource = Nothing
                    'DgListinoBase.Rows.Clear()

                    'DgListinoBase.AutoGenerateColumns = False
                    'DgListinoBase.DataSource = _Prev.ListinoBase

                    ''DgListinoBase.Refresh()

                End If

            Else
                MessageBox.Show("Selezionare un Listino Base per duplicarlo!")
            End If
        Else
            MessageBox.Show("Selezionare un Listino Base per duplicarlo!")
        End If

        'If DgListinoBase.SelectedRows.Count Then

        '    Dim LOld As ListinoBase = DgListinoBase.SelectedRows(0).DataBoundItem
        '    LOld.CaricaLavorazioni()
        '    Dim L As ListinoBase = LOld.Clone

        '    Sottofondo()
        '    Dim a As New frmListinoBase

        '    'Dim LstLav As New List(Of Lavorazione)

        '    'For Each item As Lavorazione In chkListLav.CheckedItems

        '    '    LstLav.Add(item)

        '    'Next

        '    Dim Ris As Integer = a.Carica(L, _Prev, True)
        '    If Ris Then

        '        CaricaListiniBase()
        '        ''qui lo gestisco
        '        'If _Prev.IdPrev Then L.IdPrev = _Prev.IdPrev

        '        '_Prev.ListinoBase.Add(L)
        '        'DgListinoBase.DataSource = Nothing
        '        'DgListinoBase.Rows.Clear()

        '        'DgListinoBase.AutoGenerateColumns = False
        '        'DgListinoBase.DataSource = _Prev.ListinoBase

        '        ''DgListinoBase.Refresh()

        '    End If
        '    Sottofondo()

        'Else
        '    MessageBox.Show("Selezionare un Listino Base per duplicarlo!")

        'End If
    End Sub

    Private Sub Importa()

        Dim IdListinoSelezionato As Integer = 0
        Sottofondo()

        Using f As New frmListinoBaseLink
            IdListinoSelezionato = f.Carica()
        End Using
        Sottofondo()

        If IdListinoSelezionato Then

            Dim LOld As New ListinoBase
            LOld.Read(IdListinoSelezionato)
            LOld.CaricaLavorazioni()
            Dim L As ListinoBase = LOld.Clone

            Sottofondo()
            Dim a As New frmListinoBase

            'Dim LstLav As New List(Of Lavorazione)

            'For Each item As Lavorazione In chkListLav.CheckedItems

            '    LstLav.Add(item)

            'Next

            Dim Ris As Integer = a.Carica(L, _Prev, , True)
            If Ris Then

                CaricaListiniBase()
                ''qui lo gestisco
                'If _Prev.IdPrev Then L.IdPrev = _Prev.IdPrev

                '_Prev.ListinoBase.Add(L)
                'DgListinoBase.DataSource = Nothing
                'DgListinoBase.Rows.Clear()

                'DgListinoBase.AutoGenerateColumns = False
                'DgListinoBase.DataSource = _Prev.ListinoBase

                ''DgListinoBase.Refresh()

            End If
            Sottofondo()
        End If

    End Sub

    Private Sub btnDuplica_Click(sender As Object, e As EventArgs) Handles btnDuplica.Click
        'duplico la voce corrente

        Duplica()

    End Sub

    Private Sub ModificaLB()
        If Not tvwLB.SelectedNode Is Nothing AndAlso tvwLB.SelectedNode.Name.StartsWith("L") Then

            Dim L As ListinoBase = tvwLB.SelectedNode.Tag

            Sottofondo()
            Using a As New frmListinoBase
                '            If 

                'disattivato l'if per ricaricare sempre la versione salvata del listino base e non le possibili modifiche 
                a.Carica(L, _Prev)
                'If a.Carica(L, _Prev) Then
            End Using
            CaricaListiniBase()
            'End If
            Sottofondo()

        End If
    End Sub

    'Private Sub DgListinoBase_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    '    'riapro il listino base
    '    If DgListinoBase.SelectedRows.Count Then

    '        Dim L As ListinoBase = DgListinoBase.SelectedRows(0).DataBoundItem

    '        Sottofondo()
    '        Using a As New frmListinoBase
    '            '            If 

    '            'disattivato l'if per ricaricare sempre la versione salvata del listino base e non le possibili modifiche 
    '            a.Carica(L, _Prev)
    '            'If a.Carica(L, _Prev) Then
    '        End Using
    '        CaricaListiniBase()
    '        'End If
    '        Sottofondo()

    '    End If

    'End Sub

    Private Sub btnSearchSito_Click(sender As Object, e As EventArgs) Handles btnSearchSito.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgSito.Text = OpenFileImg.FileName
            pctImgSito.Image = Image.FromFile(txtImgSito.Text)
        End If

    End Sub

    Private Sub txtCodice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodice.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    'Private Sub chkShowCurva_CheckedChanged(sender As Object, e As EventArgs)
    '    Try
    '        DgListinoBase.Columns("Curva").Visible = sender.Checked
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub chkShowFormato_CheckedChanged(sender As Object, e As EventArgs)
    '    Try
    '        DgListinoBase.Columns("Formato").Visible = sender.Checked
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub chkShowTipoCarta_CheckedChanged(sender As Object, e As EventArgs)
    '    Try
    '        DgListinoBase.Columns("TipoCarta").Visible = sender.Checked
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub chkColoreStampa_CheckedChanged(sender As Object, e As EventArgs)
    '    Try
    '        DgListinoBase.Columns("ColoreStampa").Visible = sender.Checked
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub chkShowQta_CheckedChanged(sender As Object, e As EventArgs)
    '    Try
    '        DgListinoBase.Columns("q1").Visible = sender.Checked
    '        DgListinoBase.Columns("q2").Visible = sender.Checked
    '        DgListinoBase.Columns("q3").Visible = sender.Checked
    '        DgListinoBase.Columns("q4").Visible = sender.Checked
    '        DgListinoBase.Columns("q5").Visible = sender.Checked
    '        DgListinoBase.Columns("q6").Visible = sender.Checked
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub chkShowImp_CheckedChanged(sender As Object, e As EventArgs)
    '    Try
    '        DgListinoBase.Columns("v1").Visible = sender.Checked
    '        DgListinoBase.Columns("v2").Visible = sender.Checked
    '        DgListinoBase.Columns("v3").Visible = sender.Checked
    '        DgListinoBase.Columns("v4").Visible = sender.Checked
    '        DgListinoBase.Columns("v5").Visible = sender.Checked
    '        DgListinoBase.Columns("v6").Visible = sender.Checked
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub DgListinoBase_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        OrdinatoreLista(Of ListinoBase).OrdinaLista(sender, e)
    End Sub

    Private Sub btnAddLinkListino_Click(sender As Object, e As EventArgs) Handles btnAddLinkListino.Click
        Sottofondo()

        Dim f As New frmListinoBaseLink
        Dim idListinoScelto As Integer = f.Carica(_Prev.IdPrev)

        If idListinoScelto Then

            Dim x As New PrevLinkListino
            x.IdPreventivazione = _Prev.IdPrev
            x.IdListinoBase = idListinoScelto
            x.Save()

            CaricaListiniBaseLinkati()

        End If

        f = Nothing

        Sottofondo()

    End Sub

    Private Sub btnDelLinkListino_Click(sender As Object, e As EventArgs) Handles btnDelLinkListino.Click

        If dgListinoLink.SelectedRows.Count Then
            If MessageBox.Show("Confermi la cancellazione del link al listino base selezionato?", "Elimina link a listino base", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim lb As ListinoBase = dgListinoLink.SelectedRows(0).DataBoundItem
                Using mgr As New PrevLinkListinoDAO
                    mgr.DeleteLink(lb.IdListinoBase, _Prev.IdPrev)
                End Using
                CaricaListiniBaseLinkati()
            End If
        Else
            MessageBox.Show("Selezionare un listino base linkato a questa preventivazione")
        End If

    End Sub

    Private Sub PreviewLbOrder()
        Dim IndRow As Integer = 0
        Dim IndCol As Integer = 0

        Dim NumRighe As Integer = _Prev.ListiniBase.Count Mod 4

        tblLB.RowCount = NumRighe
        tblLB.Controls.Clear()
        'tblLB.Height = NumRighe * 128

        _Prev.ListiniBase.Sort(Function(x, y) x.Ordinamento.CompareTo(y.Ordinamento))

        For Each Lb As ListinoBase In _Prev.ListiniBase

            Dim Img As Image = Nothing

            Try
                Img = Bitmap.FromFile(Lb.GetImgFormato)
            Catch ex As Exception

            End Try

            Dim pct As New PictureBox
            pct.Width = 128
            pct.Height = 128
            'pct.BorderStyle = BorderStyle.FixedSingle
            pct.SizeMode = PictureBoxSizeMode.StretchImage
            If Not Img Is Nothing Then pct.Image = Img
            tblLB.Controls.Add(pct, IndCol, IndRow)

            IndCol += 1
            If IndCol = 4 Then
                IndCol = 0
                IndRow += 1
            End If

        Next
    End Sub

    Private Sub lnkAggiorna_Click(sender As Object, e As EventArgs)

        PreviewLbOrder()

    End Sub

    Private Sub lnkSu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSu.LinkClicked
        SpostaLav("UP")
    End Sub

    Private Sub lnkGiu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGiu.LinkClicked
        SpostaLav("DOWN")
    End Sub

    Private Sub SpostaLav(ByVal Direzione As String)
        Cursor = Cursors.WaitCursor

        If DgListiniBase.SelectedRows.Count Then

            'Dim Dr As DataGridViewRow = DgListiniBase.SelectedRows(0)

            Dim IdListinoBaseSel As New List(Of Integer)
            Dim IdRowIndexSel As New List(Of Integer)

            For Each Dr As DataGridViewRow In DgListiniBase.SelectedRows
                IdRowIndexSel.Add(Dr.Index)
                IdListinoBaseSel.Add(Dr.Tag)
            Next

            Select Case Direzione
                Case "UP"
                    IdRowIndexSel.Sort(Function(x, y) x.CompareTo(y))
                Case "DOWN"
                    IdRowIndexSel.Sort(Function(x, y) y.CompareTo(x))
            End Select

            For Each Index As Integer In IdRowIndexSel
                Dim dr As DataGridViewRow = DgListiniBase.Rows(Index)
                Dim Riga As New DataGridViewRow
                Riga.CreateCells(DgListiniBase)

                Riga.Cells(0).Value = dr.Cells(0).Value
                Riga.Cells(1).Value = dr.Cells(1).Value
                Riga.Tag = dr.Tag

                Select Case Direzione
                    Case "UP"
                        If dr.Index - 1 >= 0 Then
                            DgListiniBase.Rows.Insert(dr.Index - 1, Riga)
                            DgListiniBase.Rows.Remove(dr)
                            'Riga.Selected = True
                        End If

                    Case "DOWN"
                        If dr.Index + 2 <= DgListiniBase.Rows.Count Then
                            DgListiniBase.Rows.Insert(dr.Index + 2, Riga)
                            DgListiniBase.Rows.Remove(dr)
                            'Riga.Selected = True
                        End If
                End Select

            Next

            For Each Dr As DataGridViewRow In DgListiniBase.Rows
                If IdListinoBaseSel.FindAll(Function(x) x = Dr.Tag).Count Then
                    Dr.Selected = True
                Else
                    Dr.Selected = False
                End If
            Next

        End If

        SalvaOrdinamento()



        Cursor = Cursors.Default

    End Sub

    Private Sub SalvaOrdinamento()
        'qui per sicurezza risalvo l'ordinamento dei listinibase sopratutto per il pregresso
        Dim Ordinamento As Integer = 0
        For Each row As DataGridViewRow In DgListiniBase.Rows

            Dim IdLb As Integer = row.Tag

            Dim lb As ListinoBase = _Prev.ListiniBase.Find(Function(x) x.IdListinoBase = IdLb)

            lb.Ordinamento = Ordinamento
            lb.Save()

            Ordinamento += 1

        Next
    End Sub

    Private Sub btnWizard_Click(sender As Object, e As EventArgs)
        Using f As New frmListinoImgTemporanea
            Sottofondo()
            Dim PathTemp As String = f.Carica()
            Sottofondo()
            If PathTemp.Length Then
                txtImgLav.Text = PathTemp
                pctImgLav.Image = Image.FromFile(PathTemp)
            End If

        End Using
    End Sub

    Private Sub DgListinoBase_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    'Private Sub DgListinoBase_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
    '    Try
    '        Dim r As DataGridViewRow = DgListinoBase.Rows(e.RowIndex)
    '        Dim l As ListinoBase = r.DataBoundItem

    '        If Not l Is Nothing Then
    '            If l.NascondiOnline = enSiNo.Si Then
    '                r.DefaultCellStyle.BackColor = Color.FromArgb(208, 208, 208)
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        Cursor.Current = Cursors.WaitCursor
        PreviewLbOrder()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lblGruppoVariante_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGruppoVariante.LinkClicked

        Try
            If IsNumeric(lblGruppoVariante.Tag) Then
                'Using f As New frmGruppoVariante
                '    f.carica(lblGruppoVariante.Tag)
                'End Using
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnImporta_Click(sender As Object, e As EventArgs) Handles btnImporta.Click
        Importa()
    End Sub

    Private Sub BtnStampaRiassunto_Click(sender As Object, e As EventArgs) Handles btnStampaRiassunto.Click

        Sottofondo()

        Using f As New frmStampa
            f.Carica(MgrReport.RiassuntoPreventivazione(_Prev.IdPrev))
        End Using

        Sottofondo()

    End Sub

    Private Sub dgListinoBaseEX_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs)
        If TypeOf e.CellElement Is GridGroupExpanderCellElement Then
            Dim Cell As GridGroupExpanderCellElement = e.CellElement
            Cell.RowInfo.Height = 48
        End If
    End Sub

    Private Sub TvwLB_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwLB.AfterSelect

    End Sub

    Private Sub tvwLB_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwLB.NodeMouseDoubleClick
        modificaLB
    End Sub

    Private Sub UcPictureWizard_Load(sender As Object, e As EventArgs) Handles UcPictureWizard.Load

    End Sub

    Private Sub txtDescr_TextChanged(sender As Object, e As EventArgs) Handles txtDescr.TextChanged
        lblIntroPrev.Text = txtDescr.Text
    End Sub
End Class