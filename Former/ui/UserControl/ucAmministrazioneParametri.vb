Imports FormerDALSql
Imports FormerLib

Public Class ucAmministrazioneParametri
    Inherits ucFormerUserControl
    Public Sub Carica()

        'FormerDebug.Traccia("CARICAMENTO INIZIALE")
        'UcProdottiNew.Carica()
        'UcMacchinari.Carica()
        'UcResa.Carica()
        'UcFormatoMacchina.Carica()
        'UcListinoFustelle.CaricaCombo()

        CaricaCombo()

    End Sub
    Private Sub CaricaCombo()

        'Dim M As New MacchinariDAO

        'cmbMacchinari.ValueMember = "IdMacchinario"
        'cmbMacchinari.DisplayMember = "Descrizione"
        'cmbMacchinari.DataSource = M.GetAll("Descrizione", True)

        'Dim C As New CatLavDAO

        'cmbCategoria.ValueMember = "IdCatLav"
        'cmbCategoria.DisplayMember = "Descrizione"
        'cmbCategoria.DataSource = C.GetAll("Descrizione", True)

    End Sub

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        BackColor = Color.White
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        'tabMain.TabPages.Remove(tpListino)
        'tabMain.TabPages.Remove(tpCommesse)
        'tabMain.TabPages.Remove(tpReport)

        tabMain.ItemSize = New Size(100, 40)

    End Sub

    'Private Sub CaricaLavorazioni()

    '    'carico la lista delle lavorazioni 

    '    Dim mgr As New LavorazioniDAO

    '    Dim l As List(Of LavorazioneEx) = mgr.ListaLavorazioni(cmbMacchinari.SelectedValue, cmbCategoria.SelectedValue)
    '    DgLavorazioni.AutoGenerateColumns = False
    '    DgLavorazioni.DataSource = l

    '    'Dim x As New cLavoriColl
    '    'Dim dtLista As DataTable

    '    'dtLista = x.ListaLavorazioni

    '    'DgLavorazioni.DataSource = dtLista

    '    'DgLavorazioni.Columns(0).Visible = False
    '    'DgLavorazioni.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"

    '    'x = Nothing

    'End Sub

    'Private Sub CaricaTipoCommesse()

    '    'carico la lista dei tipi di Commessa

    '    Using x As New cTipoCommessaColl
    '        Dim dtLista As DataTable

    '        dtLista = x.Lista

    '        dgTipoCom.DataSource = dtLista

    '        dgTipoCom.Columns(0).Visible = False
    '        '        DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        '        DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"

    '    End Using

    'End Sub

    'Private Sub RiapriVoce()

    '    If dgTipoCom.SelectedRows.Count Then

    '        Dim IdVoce As Integer
    '        IdVoce = dgTipoCom.SelectedRows(0).Cells(0).Value

    '        Dim Ris As Integer = 0

    '        Using frmRif As New frmCommessaTipo
    '            ParentFormEx.Sottofondo()
    '            Ris = frmRif.Carica(IdVoce)
    '            ParentFormEx.Sottofondo()

    '            If Ris Then CaricaTipoCommesse()
    '        End Using

    '    End If

    'End Sub

    'Private Sub dgTipoCom_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    RiapriVoce()
    'End Sub

    'Private Sub lnkAggiungiLav_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    ParentFormerForm.Sottofondo 

    '    Dim x As New frmLavorazione, Ris As Integer

    '    Ris = x.Carica()

    '    If Ris Then CaricaLavorazioni()
    '    x = Nothing

    '    ParentFormerForm.Sottofondo 
    'End Sub

    'Private Sub lnkModTipoCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    If dgTipoCom.SelectedRows.Count Then

    '        Dim IdRif As Integer = 0
    '        IdRif = dgTipoCom.SelectedRows(0).Cells(0).Value
    '        ParentFormEx.Sottofondo()

    '        Dim Ris As Integer = 0, x As New frmCommessaTipo
    '        Ris = x.Carica(IdRif)
    '        If Ris Then CaricaTipoCommesse()
    '        x = Nothing
    '        ParentFormEx.Sottofondo()

    '    End If
    'End Sub

    'Private Sub lnkNewTipoCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    ParentFormEx.Sottofondo()

    '    Dim Ris As Integer = 0, x As New frmCommessaTipo
    '    Ris = x.Carica()
    '    If Ris Then CaricaTipoCommesse()
    '    x = Nothing
    '    ParentFormEx.Sottofondo()

    'End Sub

    Private Sub lnkCercaBarCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCercaBarCode.LinkClicked

        Dim x As New myPrinter

        Dim stampanteScelta As String = ""
        Dim prin As New System.Windows.Forms.PrintDialog
        prin.ShowDialog()
        If prin.PrinterSettings.PrinterName.Length Then stampanteScelta = prin.PrinterSettings.PrinterName
        x.PrinterName = stampanteScelta
        x.StampaBarcode(FormerConst.Barcode.BarcodeFineCaricamentoColli)
        x = Nothing
        MessageBox.Show("Barcode stampato correttamente")

    End Sub

    'Private Sub lnkAggModello_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    ParentFormerForm.Sottofondo 
    '    Dim M As New frmCommessaModello, Ris As Integer = 0
    '    Ris = M.Carica()
    '    M = Nothing
    '    If Ris Then CaricaModelliCommessa()
    '    ParentFormerForm.Sottofondo 
    'End Sub

    'Private Sub CaricaModelliCommessa()

    '    dgModelliCommessa.AutoGenerateColumns = False
    '    Using Mgr As New ModelliCommessaDAO
    '        Dim para As LUNA.LunaSearchParameter = Nothing
    '        If txtCerca.Text.Trim.Length Then
    '            para = New LUNA.LunaSearchParameter("Nome", "%" & txtCerca.Text & "%", " like ")
    '        End If

    '        Dim l As List(Of ModelloCommessa) = Mgr.FindAll("Nome", para)
    '        For Each m As ModelloCommessa In l
    '            m.CaricaFormatiProdotto()
    '        Next
    '        dgModelliCommessa.DataSource = l
    '    End Using
    'End Sub

    'Private Sub DuplicaModello()
    '    If dgModelliCommessa.SelectedRows.Count Then

    '        If MessageBox.Show("Confermi la duplicazione del modello comessa selezionato?", "Duplica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

    '            Dim M As ModelloCommessa = dgModelliCommessa.SelectedRows(0).DataBoundItem

    '            Dim MNew As ModelloCommessa = M.Clone
    '            MNew.IdModello = 0
    '            MNew.Nome &= " Copia"
    '            MNew.Save()

    '            ParentFormerForm.Sottofondo 
    '            Using F As New frmCommessaModello
    '                Dim Ris As Integer = F.Carica(MNew.IdModello)
    '            End Using
    '            ParentFormerForm.Sottofondo 

    '        End If

    '    End If
    'End Sub

    'Private Sub ModificaModello()
    '    If dgModelliCommessa.SelectedRows.Count Then
    '        Dim M As ModelloCommessa = dgModelliCommessa.SelectedRows(0).DataBoundItem
    '        ParentFormerForm.Sottofondo 
    '        Dim F As New frmCommessaModello
    '        Dim Ris As Integer = F.Carica(M.IdModello)

    '        ParentFormerForm.Sottofondo 

    '    End If
    'End Sub

    'Private Sub dgModelliCommessa_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    '    ModificaModello()
    'End Sub

    Private Sub dgModelliCommessa_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        OrdinatoreLista(Of ModelloCommessa).OrdinaLista(sender, e)
    End Sub

    'Private Sub dgModelliCommessa_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
    '    Try
    '        '
    '        Dim M As ModelloCommessa = DirectCast(dgModelliCommessa.Rows(e.RowIndex).DataBoundItem, ModelloCommessa)

    '        If Not M Is Nothing Then
    '            Dim Err As Boolean = False
    '            If M.FormatiProdotto.Count = 0 Then Err = True
    '            If M.IdMacchinarioDef = 0 Then Err = True
    '            If M.IdFormatoMacchina = 0 Then Err = True
    '            If Err Then dgModelliCommessa.Rows(e.RowIndex).Cells(1).Style.BackColor = Color.Red
    '        End If
    '        'End If

    '        'Refresh()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged

        If tabMain.SelectedTab Is tpOperatori Then
            UcOperatori.CaricaDati()
        End If

    End Sub

    'Private Sub lnkEditModello_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    ModificaModello()
    'End Sub

    'Private Sub lnkAddFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    ParentFormerForm.Sottofondo 

    '    Dim f As New frmFormatoProdotto

    '    Dim ris As Integer = f.Carica()
    '    f = Nothing

    '    If ris Then
    '        CaricaFormati()
    '    End If

    '    ParentFormerForm.Sottofondo 

    'End Sub

    'Private Sub CaricaColoriStampa()

    '    UcColoriStampa.CaricaDati()

    'End Sub

    'Private Sub CaricaFormati()

    '    Using mgr As New FormatiProdottoDAO

    '        Dim l As List(Of FormatoProdottoEx) = mgr.ListaFormati()

    '        If rdoFPStandard.Checked Then
    '            l = l.FindAll(Function(x) x.ProdottoFinito = False)
    '        ElseIf rdoFPOnlyProd.Checked Then
    '            l = l.FindAll(Function(x) x.ProdottoFinito = True)
    '        End If

    '        dgFormati.AutoGenerateColumns = False
    '        dgFormati.DataSource = l
    '    End Using
    'End Sub

    'Private Sub ModificaFormatoProdotto()

    '    If dgFormati.SelectedRows.Count Then

    '        Dim v As FormatoProdottoEx = dgFormati.SelectedRows(0).DataBoundItem

    '        Dim IdRif As Integer = 0
    '        IdRif = v.IdFormProd
    '        ParentFormerForm.Sottofondo 

    '        Dim Ris As Integer = 0, x As New frmFormatoProdotto
    '        Ris = x.Carica(IdRif)
    '        If Ris Then CaricaFormati()
    '        x = Nothing
    '        ParentFormerForm.Sottofondo 

    '    End If
    'End Sub

    'Private Sub lnkModFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    ModificaFormatoProdotto()
    'End Sub

    'Private Sub lnkAggiungiLav_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    ParentFormerForm.Sottofondo 

    '    Dim x As New frmLavorazione, Ris As Integer

    '    Ris = x.Carica()

    '    If Ris Then CaricaLavorazioni()
    '    x = Nothing

    '    ParentFormerForm.Sottofondo 
    'End Sub

    'Private Sub ModificaLavorazioni()
    '    If DgLavorazioni.SelectedRows.Count Then

    '        Dim v As Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem

    '        Dim IdRif As Integer = 0
    '        IdRif = v.IdLavoro
    '        ParentFormerForm.Sottofondo 

    '        Dim Ris As Integer = 0, x As New frmLavorazione
    '        Ris = x.Carica(IdRif)
    '        If Ris Then CaricaLavorazioni()
    '        x = Nothing
    '        ParentFormerForm.Sottofondo 

    '    End If
    'End Sub

    'Private Sub lnkModLav_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModLav.LinkClicked
    '    ModificaLavorazioni()
    'End Sub

    'Private Sub cmbMacchinari_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMacchinari.SelectedIndexChanged
    '    CaricaLavorazioni()
    'End Sub

    'Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged
    '    CaricaLavorazioni()
    'End Sub

    'Private Sub dgFormati_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    '    ModificaFormatoProdotto()
    'End Sub

    'Private Sub DgLavorazioni_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLavorazioni.CellDoubleClick
    '    ModificaLavorazioni()
    'End Sub

    'Private Sub txtCerca_KeyDown(sender As Object, e As KeyEventArgs)

    '    If e.KeyCode = Keys.Enter Then
    '        CaricaModelliCommessa()
    '    End If

    'End Sub

    Private Sub btnBarCode_Click(sender As Object, e As EventArgs) Handles btnBarCode.Click

        If txtBarCode.Text.Length = 13 Then

            Dim Barcode As String = txtBarCode.Text.Substring(0, 12)

            Dim x As New myPrinter, PrinterName As String = String.Empty
            Dim prin As New System.Windows.Forms.PrintDialog
            prin.ShowDialog()
            If prin.PrinterSettings.PrinterName.Length Then
                PrinterName = prin.PrinterSettings.PrinterName
            Else
                PrinterName = PostazioneCorrente.StampanteEtichette
            End If

            x.PrinterName = PrinterName
            x.StampaBarcode(Barcode)
            x = Nothing
            MessageBox.Show("Barcode stampato correttamente")
        Else
            MessageBox.Show("Inserire un codice a barre")
        End If

    End Sub

    Private Sub btnCalcola_Click(sender As Object, e As EventArgs) Handles btnCalcola.Click
        If txtBarcodeForCheck.Text.Length = 12 Then

            Dim Barcode As String = txtBarcodeForCheck.Text
            Dim Cifre(12) As Integer

            For I = 0 To Barcode.Length - 1
                Cifre(I) = CInt(Barcode(I).ToString)
            Next

            Dim SommaPari As Integer = Cifre(0) + Cifre(2) + Cifre(4) + Cifre(6) + Cifre(8) + Cifre(10)
            Dim SommaDispari As Integer = Cifre(1) + Cifre(3) + Cifre(5) + Cifre(7) + Cifre(9) + Cifre(11)

            Dim Ris As Integer = (SommaDispari * 3) + SommaPari

            'ora devo trovare il multiplo superiore di 10 compresa la base
            'quindi se la somma e' 60 va bene anche 60 ma se e' 61 deve trovare 70 
            Dim Trovato As Boolean = False
            Dim Partenza As Integer = Ris
            While Trovato = False
                If Partenza Mod 10 = 0 Then
                    Trovato = True
                Else
                    Partenza += 1
                End If
            End While

            Dim BarcodeFinale As String = Barcode &
            MessageBox.Show("Il barcode finale è " & Barcode & (Partenza - Ris) & ". La cifra di controllo è " & (Partenza - Ris))
            txtBarCode.Text = Barcode & (Partenza - Ris)
        Else
            MessageBox.Show("BarCode inserito non valido ")

        End If
    End Sub

    'Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    CaricaModelliCommessa()
    'End Sub

    'Private Sub tpModelliCommessa_Click(sender As Object, e As EventArgs) Handles tpModelliCommessa.Click

    'End Sub

    'Private Sub lnkDuplicaModCommessa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    '    DuplicaModello()

    'End Sub

    Private Sub lnkCreaNuovaScatola_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCreaNuovaScatola.LinkClicked

        Dim x As New myPrinter
        Dim stampanteScelta As String = ""
        Dim prin As New System.Windows.Forms.PrintDialog
        prin.ShowDialog()
        If prin.PrinterSettings.PrinterName.Length Then stampanteScelta = prin.PrinterSettings.PrinterName
        x.PrinterName = stampanteScelta
        x.StampaBarcode(FormerConst.Barcode.BarcodeChiudiScatolaERiapri)
        x = Nothing
        MessageBox.Show("Barcode stampato correttamente")

    End Sub

    Private Sub btnQrCode_Click(sender As Object, e As EventArgs) Handles btnQrCode.Click

        If txtQrCode.Text.Length Then
            Dim Val As String = txtQrCode.Text
            If Val.StartsWith("www.") Then
                Val = "http://" & Val
            End If

            FormerHelper.QrCode.pathSave = FormerConfig.FormerPath.PathTempLocale
            Dim Ris As String = FormerHelper.QrCode.CreaQrCode(Val)
            Ris = FormerConfig.FormerPath.PathTempLocale & Ris.Replace("/public/", String.Empty)
            FormerHelper.File.ShellExtended(Ris)
        Else
            Beep()
        End If

    End Sub
End Class

