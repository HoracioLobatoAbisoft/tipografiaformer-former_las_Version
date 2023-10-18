Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class ucMagazzinoMgrMovimenti
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        MgrControl.InizializeGridview(DgMovimenti)

        CaricaCombo()

    End Sub

    Private Sub dgRisorseEx_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgMovimenti.ViewCellFormatting

        If TypeOf e.CellElement Is GridImageCellElement Then
            e.Row.Height = 64
        End If

    End Sub

    Public Event CambiatoQualcosa()

    Public Sub Carica()

    End Sub

    Public Property OnlyMaterialeDiConsumo As Boolean = False
    Public Property OnlyRichiesteAcquistoInCoda As Boolean = False

    Public Sub ShowDefault()

    End Sub

    Public Sub ShowRichiesteAcquisto()

        MgrControl.SelectIndexComboEnum(cmbTipoRisorsa, enTipoMovMagaz.RichiestaAcquisto)
        cmbTipoRisorsa.Enabled = False
        OnlyRichiesteAcquistoInCoda = True
        DgMovimenti.Columns("Tipo").IsVisible = False
        DgMovimenti.Columns("Fattura").IsVisible = False
        'OnlyMaterialeDiConsumo = True

    End Sub

    Public Sub ShowStorno()

        MgrControl.SelectIndexComboEnum(cmbTipoRisorsa, enTipoMovMagaz.Storno)
        cmbTipoRisorsa.Enabled = False
        DgMovimenti.Columns("Tipo").IsVisible = False
        DgMovimenti.Columns("Urgente").IsVisible = False
        DgMovimenti.Columns("Fattura").IsVisible = False
        DgMovimenti.Columns("Note").IsVisible = False
        DgMovimenti.Columns("UltimoForn").IsVisible = False
        'OnlyMaterialeDiConsumo = True

    End Sub

    Public Sub ShowScarico()

        MgrControl.SelectIndexComboEnum(cmbTipoRisorsa, enTipoMovMagaz.Scarico)
        cmbTipoRisorsa.Enabled = False
        DgMovimenti.Columns("Tipo").IsVisible = False
        DgMovimenti.Columns("Urgente").IsVisible = False
        DgMovimenti.Columns("Note").IsVisible = False
        DgMovimenti.Columns("UltimoForn").IsVisible = False
        OnlyMaterialeDiConsumo = True

    End Sub

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        Cerca()

    End Sub

    Private Sub CaricaCombo()
        Try
            'carico la combo dei fornitori
            Using cli As New VociRubricaDAO
                cmbFornitore.ValueMember = "IdRub"
                cmbFornitore.DisplayMember = "RagSocNome"

                cmbFornitore.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, True,,,,,, True)

                ''carico la combo dei clienti
                'cmbAgente.ValueMember = "IdRub"
                'cmbAgente.DisplayMember = "Nominativo"

                'cmbAgente.DataSource = cli.ListaCombo(enTipoRubrica.Agente, True)
            End Using

            Dim l As New List(Of cEnum)

            Dim val As New cEnum
            val.Id = enTipoMovMagaz.Tutto
            val.Descrizione = FormerLib.FormerEnum.FormerEnumHelper.TipoMovimentoMagazzinoStr(val.Id)
            l.Add(val)

            val = New cEnum
            val.Id = enTipoMovMagaz.Carico
            val.Descrizione = FormerLib.FormerEnum.FormerEnumHelper.TipoMovimentoMagazzinoStr(val.Id)
            l.Add(val)

            val = New cEnum
            val.Id = enTipoMovMagaz.Prenotazione
            val.Descrizione = FormerLib.FormerEnum.FormerEnumHelper.TipoMovimentoMagazzinoStr(val.Id)
            l.Add(val)

            val = New cEnum
            val.Id = enTipoMovMagaz.Scarico
            val.Descrizione = FormerLib.FormerEnum.FormerEnumHelper.TipoMovimentoMagazzinoStr(val.Id)
            l.Add(val)

            val = New cEnum
            val.Id = enTipoMovMagaz.Storno
            val.Descrizione = FormerLib.FormerEnum.FormerEnumHelper.TipoMovimentoMagazzinoStr(val.Id)
            l.Add(val)

            val = New cEnum
            val.Id = enTipoMovMagaz.RichiestaAcquisto
            val.Descrizione = FormerLib.FormerEnum.FormerEnumHelper.TipoMovimentoMagazzinoStr(val.Id)
            l.Add(val)

            cmbTipoRisorsa.DataSource = l
            cmbTipoRisorsa.SelectedIndex = 0

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Cerca()
        Cursor.Current = Cursors.WaitCursor
        Using mgr As New MagazzinoDAO

            Dim PTipo As LUNA.LunaSearchParameter = Nothing
            Dim PRis As LUNA.LunaSearchParameter = Nothing
            Dim PMat As LUNA.LunaSearchParameter = Nothing
            Dim POrdAcq As LUNA.LunaSearchParameter = Nothing

            Dim Tipo As cEnum = cmbTipoRisorsa.SelectedItem

            If IdRis Then
                PRis = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdRis)
            End If

            If Tipo.Id <> enTipoMovMagaz.Tutto Then
                PTipo = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, Tipo.Id)
            End If

            If Tipo.Id = enTipoMovMagaz.RichiestaAcquisto Then
                If OnlyRichiesteAcquistoInCoda Then
                    POrdAcq = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdOrdineAcquisto, 0)
                End If
            End If

            If OnlyMaterialeDiConsumo Then
                PMat = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, " (SELECT IdRis FROM T_Risorse WHERE TipoRis =" & enTipoRisOffSet.ProdottoDiConsumo & ")", "IN ")
                'l = l.FindAll(Function(x) x.Risorsa.TipoRis = enTipoRisOffSet.ProdottoDiConsumo)
            End If

            Dim Ordinamento As String = LFM.MovimentoMagazzino.DataMov.Name & " DESC"

            Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(Ordinamento,
                                                                PTipo,
                                                                PRis,
                                                                PMat,
                                                                POrdAcq)


            If cmbFornitore.SelectedValue Then
                l = l.FindAll(Function(x) x.IdForn = cmbFornitore.SelectedValue)
            End If

            If Tipo.Id = enTipoMovMagaz.RichiestaAcquisto Then
                l.Sort(Function(x, y) x.RisorsaStr.CompareTo(y.RisorsaStr))
            End If

            DgMovimenti.DataSource = l

        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub DgMovimenti_DoubleClick(sender As Object, e As EventArgs) Handles DgMovimenti.DoubleClick
        If DgMovimenti.SelectedRows.Count Then

            Dim M As MovimentoMagazzino = DgMovimenti.SelectedRows(0).DataBoundItem

            ParentFormEx.Sottofondo()

            If M.TipoMov = enTipoMovMagaz.Carico Then
                Using f As New frmMagazzinoCarico
                    f.IdRis = M.IdRis
                    '                    f.IDFat = M.IdFat
                    If f.Carica(M.IdCarMag,, enTipoMovMagaz.Carico, M.IdFat) Then
                        Cerca()
                        RaiseEvent CambiatoQualcosa()
                    End If
                End Using

            Else
                Using f As New frmMagazzinoMovimento
                    If f.Carica(M.IdCarMag) Then
                        Cerca()
                        RaiseEvent CambiatoQualcosa()
                    End If
                End Using

            End If

            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub DgMovimenti_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgMovimenti.CellFormatting
        If e.CellElement.ColumnInfo.Name = "Tipo" Then
            Dim Riga As GridViewRowInfo = e.Row
            Using o As MovimentoMagazzino = Riga.DataBoundItem

                If o.TipoMov = enTipoMovMagaz.Carico Then
                    e.CellElement.BackColor = Color.Green
                    e.CellElement.ForeColor = Color.White
                ElseIf o.TipoMov = enTipoMovMagaz.Prenotazione Then
                    e.CellElement.BackColor = Color.Orange
                    e.CellElement.ForeColor = Color.Black
                ElseIf o.TipoMov = enTipoMovMagaz.Scarico Then
                    e.CellElement.BackColor = Color.Red
                    e.CellElement.ForeColor = Color.White
                End If

            End Using
        Else
            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
            e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
        End If
    End Sub

    Private Sub lnkStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""

        Titolo = "Movimenti magazzino"

        StampaGlobale(Titolo, DgMovimenti)
        ParentFormEx.Sottofondo()
    End Sub

    Private _IdRis As Integer = 0
    Public Property IdRis As Integer
        Get
            Return _IdRis

        End Get
        Set(value As Integer)
            _IdRis = value
            If _IdRis Then
                DgMovimenti.Columns("Risorsa").IsVisible = False
                lnkStorno.Visible = True
                'lnkNew.Visible = True
            End If
        End Set
    End Property

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked
        If DgMovimenti.SelectedRows.Count Then

            Dim M As MovimentoMagazzino = DgMovimenti.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi l'eliminazione del movimento selezionato?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New MagazzinoDAO
                    mgr.Delete(M)
                    mgr.AggiornaQta(M.IdRis)
                    DgMovimenti.Rows.Remove(DgMovimenti.SelectedRows(0))
                    RaiseEvent CambiatoQualcosa()
                End Using
            End If

        End If
    End Sub



    Private Sub lnkStorno_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStorno.LinkClicked
        ParentFormEx.Sottofondo()

        Using x As New frmMagazzinoStorno

            If x.Carica(_IdRis) Then RaiseEvent CambiatoQualcosa()

        End Using

        ParentFormEx.Sottofondo()
    End Sub
End Class
