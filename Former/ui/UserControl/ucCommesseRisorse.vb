Imports FormerDALSql
Imports FormerLib.FormerEnum
Public Class ucCommesseRisorse
    Inherits ucFormerUserControl

    Private _idTipoCom As Integer
    Private _RisPredef As Risorsa

    Public Property IdTipoCom() As Integer
        Get
            Return _idTipoCom
        End Get
        Set(ByVal value As Integer)
            _idTipoCom = value

        End Set
    End Property
    Private _CommessaSel As Commessa = Nothing
    Public ReadOnly Property CommessaSel As Commessa
        Get
            If _CommessaSel Is Nothing Then
                _CommessaSel = New Commessa
                _CommessaSel.Read(IdCom)
            End If
            Return _CommessaSel
        End Get
    End Property

    Private _IdCom As Integer
    Public Property IdCom() As Integer
        Get
            Return _IdCom
        End Get
        Set(ByVal value As Integer)
            _IdCom = value
            'MostraAncheNonDisponibiliToolStripMenuItem.Checked = True
        End Set
    End Property

    Public Event CambiataRisorsa()

    Private _QtaNeces As Single = 0
    Public Function GetQtaNeces() As Single

        Return _QtaNeces 'Math.Ceiling(_QtaNeces)
    End Function

    Public Sub SetQtaNeces(ByVal value As Single,
                           Optional UpdateRis As Boolean = True)

        Try
            _QtaNeces = value
            lblQtaNeces.Text = value

            If UpdateRis Then
                Dim Dr As DataGridViewRow
                Dim TotaleParziale As Double = 0
                Dim GiacenzaSpec As Double = 0

                For Each Dr In DgRisorseSelezionate.Rows

                    If TotaleParziale < _QtaNeces Then

                        GiacenzaSpec = Dr.Cells(2).Value
                        Dr.Cells(3).Value = _QtaNeces - TotaleParziale

                        If CartaComposta = False Then
                            TotaleParziale += _QtaNeces
                        End If

                        'If GiacenzaSpec >= _QtaNeces Then
                        '    Dr.Cells(3).Value = _QtaNeces - TotaleParziale
                        '    TotaleParziale += _QtaNeces
                        'Else
                        '    'Dim Diff As Single = _QtaNeces - GiacenzaSpec
                        '    If GiacenzaSpec > 0 Then
                        '        Dim Diff As Single = GiacenzaSpec
                        '        Dr.Cells(3).Value = Diff
                        '        TotaleParziale += Diff
                        '    Else
                        '        Dim Diff As Single = _QtaNeces
                        '        Dr.Cells(3).Value = Diff
                        '        TotaleParziale += Diff
                        '    End If

                        '    End If

                    End If
                Next

            End If


            'If Not _RisPredef Is Nothing Then

            '    Dim Dr As DataGridViewRow

            '    For Each Dr In DGLavorazioniSel.Rows

            '        If Dr.Cells(0).Value = _RisPredef.IdRis Then
            '            Dr.Cells(3).Value = _QtaNeces
            '        End If

            '    Next

            'End If

            AggiornaQtaCaricata()

        Catch ex As Exception

        End Try

    End Sub

    Private _QtaCaric As Single
    Public Property QtaCaric() As Single
        Get
            Return _QtaCaric
        End Get
        Set(ByVal value As Single)
            _QtaCaric = value
            lblQtaScaric.Text = value
        End Set
    End Property

    Public Property IdTipoCartaToShow As Integer

    Public ReadOnly Property RisorseSelezionate As List(Of Risorsa)
        Get
            Dim ris As New List(Of Risorsa)

            For Each dr As DataGridViewRow In DgRisorseSelezionate.Rows

                Dim cell As DataGridViewCell = dr.Cells(0)
                Dim IdRis As Integer = cell.Value
                Dim R As New Risorsa
                R.Read(IdRis)
                ris.Add(R)

            Next

            Return ris
        End Get
    End Property

    Friend Sub AddRisPredef(ByVal Ris As List(Of Risorsa))

        DgRisorseSelezionate.Rows.Clear()

        If Ris.Count > 1 Then CartaComposta = True

        For Each R In Ris
            _RisPredef = R

            lblRisPredef.Text = _RisPredef.Descrizione

            Dim Dr As DataGridViewRow

            For Each Dr In DgRisorseDisponibili.Rows

                If Dr.Cells(0).Value = _RisPredef.IdRis Then

                    Dim Riga As New DataGridViewRow
                    Riga.CreateCells(DgRisorseSelezionate)

                    Riga.Cells(0).Value = Dr.Cells(0).Value
                    Riga.Cells(1).Value = Dr.Cells(1).Value
                    Riga.Cells(2).Value = Dr.Cells(2).Value
                    Riga.Cells(3).Value = 0

                    If IdTipoCartaToShow <> 0 AndAlso R.IdTipoCarta = IdTipoCartaToShow Then
                        Riga.Cells(0).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                        Riga.Cells(0).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                        Riga.Cells(1).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                        Riga.Cells(1).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                        Riga.Cells(2).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                        Riga.Cells(2).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteGrigioChiarissimo
                        Riga.Cells(3).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                        Riga.Cells(3).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteGrigioChiarissimo

                    End If


                    DgRisorseSelezionate.Rows.Add(Riga)
                    DgRisorseDisponibili.Rows.Remove(Dr)
                    Riga = Nothing

                End If

            Next
        Next
        AggiornaQtaCaricata()
    End Sub

    Public ReadOnly Property ListaMovMagaz() As List(Of MovimentoMagazzino)

        Get
            Dim x As New List(Of MovimentoMagazzino)

            If DgRisorseSelezionate.Rows.Count Then

                Dim dr As DataGridViewRow
                For Each dr In DgRisorseSelezionate.Rows

                    Dim mov As New MovimentoMagazzino
                    mov.IdRis = dr.Cells(0).Value
                    mov.Qta = dr.Cells(3).Value
                    mov.TipoMov = enTipoMovMagaz.Prenotazione
                    mov.DataMov = Date.Now
                    mov.IdUt = PostazioneCorrente.UtenteConnesso.IdUt

                    x.Add(mov)

                Next

            End If

            Return x

        End Get
    End Property

    Private Function Comparer(ByVal x As Risorsa,
                              ByVal y As Risorsa) As Integer

        'Dim Result As Integer = y.TutteScatolePiene.CompareTo(x.TutteScatolePiene)
        'If Result = 0 Then Result = x.NumeroScatole.CompareTo(y.NumeroScatole)
        'If result = 0 Then result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        Dim Result As Integer = x.IdTipoCarta.CompareTo(y.IdTipoCarta)
        If Result = 0 Then Result = x.Descrizione.CompareTo(y.Descrizione)
        'Dim Result As Integer = x.Selezionatore.CompareTo(y.Selezionatore)
        ''If Result = 0 Then Result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        Return Result

    End Function

    Private Sub CaricaRisDisponibili(l As List(Of Risorsa))

        Dim ListIdSel As New List(Of Integer)

        For Each giaSel As DataGridViewRow In DgRisorseSelezionate.Rows
            Dim cell As DataGridViewCell = giaSel.Cells(0)
            ListIdSel.Add(cell.Value)
        Next

        For Each Dr As Risorsa In l

            If ListIdSel.FindAll(Function(x) x = Dr.IdRis).Count = 0 Then
                Dim Riga As New DataGridViewRow

                Riga.CreateCells(DgRisorseDisponibili)

                Riga.Cells(0).Value = Dr.IdRis
                Riga.Cells(1).Value = Dr.Descrizione
                Riga.Cells(2).Value = Dr.Giacenza

                'Using R As New Risorsa
                '    R.Read(Dr("IdRis"))

                If IdTipoCartaToShow <> 0 AndAlso Dr.IdTipoCarta = IdTipoCartaToShow Then
                    Riga.Cells(0).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                    Riga.Cells(0).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                    Riga.Cells(1).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                    Riga.Cells(1).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                    Riga.Cells(2).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                    Riga.Cells(2).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteGrigioChiarissimo

                End If

                ' End Using

                DgRisorseDisponibili.Rows.Add(Riga)

                Riga = Nothing
            End If

        Next

    End Sub

    Public Sub CaricaDaCommessa()
        'FormerDebug.Traccia()
        'carico la lista delle lavorazioni 
        'se mi viene passato l'id del prodotto carico dal db le check su quelle selezionate

        Dim x As New cRisorseColl
        'Dim dtLista As DataTable = Nothing
        Dim dtListaSel As DataTable

        Dim Dr As DataRow

        Dim l As List(Of Risorsa)
        Using mgr As New RisorseDAO
            l = mgr.Lista(_IdCom,
                          _idTipoCom,
                          MostraAncheNonDisponibiliToolStripMenuItem.Checked)
        End Using

        'dtLista = x.ListaCom(_IdCom, _idTipoCom)

        DgRisorseSelezionate.Rows.Clear()

        DgRisorseDisponibili.Rows.Clear()

        dtListaSel = x.ListaComSel(_IdCom, _idTipoCom)

        For Each Dr In dtListaSel.Rows

            Dim Riga As New DataGridViewRow
            Riga.CreateCells(DgRisorseSelezionate)

            Riga.Cells(0).Value = Dr("IdRis")
            Riga.Cells(1).Value = Dr("Descrizione")
            Riga.Cells(2).Value = Dr("Giacenza")
            Riga.Cells(3).Value = Dr("Utilizzata")

            If lblRisPredef.Text = " -" Then
                lblRisPredef.Text = Dr("Descrizione")
            End If

            If IdTipoCartaToShow <> 0 AndAlso Dr("IdTipoCarta") = IdTipoCartaToShow Then
                Riga.Cells(0).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                Riga.Cells(0).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                Riga.Cells(1).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                Riga.Cells(1).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                Riga.Cells(2).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                Riga.Cells(2).Style.SelectionBackColor = FormerLib.FormerColori.ColoreAmbienteGrigioChiarissimo

            End If

            DgRisorseSelezionate.Rows.Add(Riga)

            Riga = Nothing

        Next

        DgRisorseSelezionate.Columns(0).Visible = False

        CaricaRisDisponibili(l.FindAll(Function(xx) xx.IdTipoCarta = IdTipoCartaToShow))
        CaricaRisDisponibili(l.FindAll(Function(xx) xx.IdTipoCarta <> IdTipoCartaToShow))
        DgRisorseDisponibili.Columns(0).Visible = False


    End Sub

    Private Sub lnkAggiungi_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        If AggiungiRisorsa() = enSiNo.Si Then RaiseEvent CambiataRisorsa()
    End Sub

    Public Property CartaComposta As Boolean = False
    Private _Formato As Formato = Nothing
    Public Property Formato As Formato
        Get
            Return _Formato
        End Get
        Set(value As Formato)
            _Formato = value
        End Set
    End Property

    Private Function AggiungiRisorsa() As Integer
        Dim risu As Integer = enSiNo.No

        If DgRisorseDisponibili.SelectedRows.Count Then

            Dim Dr As DataGridViewRow = DgRisorseDisponibili.SelectedRows(0)
            If Dr.Selected Then
                'sposto la lavorazione tra quelle selezionate

                Dim Mov As MovimentoMagazzino = Nothing
                Dim Ris As Integer
                Dim QtaDaMovimentare As Single = 0
                Dim IdRis As Integer = Dr.Cells(0).Value

                'qiu controllo che c'entra
                Dim CheckDimensioni As Boolean = True

                If DgRisorseSelezionate.Rows.Count Then
                    If CartaComposta Then
                        QtaDaMovimentare = GetQtaNeces()
                    Else
                        QtaDaMovimentare = GetQtaNeces() - AggiornaQtaCaricata()
                    End If
                Else
                    'caricamento a secco 
                    'devo ricalcolare la qta
                    Dim TotVerticale As Single = 0
                    Dim TotOrizzontale As Single = 0
                    Dim TotSoggetti As Single = 0

                    Dim Colonne As Integer = 0
                    Dim Righe As Integer = 0

                    Using R As New Risorsa
                        R.Read(IdRis)

                        Dim FFly As Formato = Nothing
                        'PORTO TUTTE LE MISURE IN MILLIMETRI

                        If _IdCom Then
                            Using c As New Commessa
                                c.Read(_IdCom)
                                Dim UnitaDiMisuraUsata As enUnitaDiMisura = enUnitaDiMisura.cm
                                Dim OrdineH As Integer = 0
                                Dim OrdineW As Integer = 0

                                If c.ListaOrdini.Count Then
                                    Using o As Ordine = c.ListaOrdini()(0)
                                        UnitaDiMisuraUsata = o.ListinoBase.TipoUnitaMisuraInInput
                                        OrdineW = o.Largo
                                        OrdineH = o.Lungo
                                    End Using
                                End If

                                If c.IdReparto = enRepartoWeb.StampaDigitale Then
                                    FFly = New Formato
                                    FFly.Larghezza = c.Largo
                                    FFly.Altezza = c.Lungo
                                ElseIf c.IdReparto = enRepartoWeb.Etichette Then
                                    FFly = New Formato
                                    FFly.Larghezza = OrdineW
                                    FFly.Altezza = OrdineH
                                End If

                                If UnitaDiMisuraUsata = enUnitaDiMisura.cm Then
                                    FFly.Larghezza = FFly.Larghezza * 10
                                    FFly.Altezza = FFly.Altezza * 10
                                End If

                            End Using

                        End If

                        Dim FormatoH As Integer = 0 'FFly.Altezza
                        Dim FormatoW As Integer = 0 'FFly.Larghezza

                        If FFly Is Nothing Then
                            'FFly = Formato
                            FormatoH = Formato.AltezzaMM
                            FormatoW = Formato.LarghezzaMM
                        Else
                            FormatoH = FFly.Altezza
                            FormatoW = FFly.Larghezza
                        End If

                        Colonne = Math.Floor(R.Larghezzamm / FormatoW)
                        Righe = Math.Floor(R.Lunghezzamm / FormatoH)

                        If Colonne > 0 And Righe > 0 Then

                            TotOrizzontale = Math.Ceiling(CommessaSel.Copie / Colonne) '(GetQtaNeces() / Colonne)
                            TotOrizzontale = R.Larghezzamm * (FormatoH * TotOrizzontale)
                            'TotOrizzontale = Colonne * Righe
                        End If

                        Colonne = Math.Floor(R.Larghezzamm / FormatoH)
                        Righe = Math.Floor(R.Lunghezzamm / FormatoW)

                        If Colonne > 0 And Righe > 0 Then
                            TotVerticale = Math.Ceiling(CommessaSel.Copie / Colonne) '(GetQtaNeces() / Colonne)
                            TotVerticale = R.Larghezzamm * (FormatoW * TotVerticale)
                            'TotVerticale = Colonne * Righe
                        End If

                        If TotOrizzontale <= TotVerticale Or TotVerticale = 0 Then
                            TotSoggetti = TotOrizzontale
                        Else
                            TotSoggetti = TotVerticale
                        End If

                        'qui ho i mmquadrati devo convertirlo in metri quadrati
                        TotSoggetti = TotSoggetti / 1000000

                        If TotSoggetti <= 0 Then ' TOLTO <1
                            CheckDimensioni = False
                        Else
                            'QtaDaMovimentare = GetQtaNeces() / TotSoggetti
                            QtaDaMovimentare = GetQtaNeces()

                            If Not CommessaSel Is Nothing AndAlso
                               CommessaSel.IdCom <> 0 Then

                                If (CommessaSel.IdReparto = enRepartoWeb.StampaDigitale OrElse
                                    CommessaSel.IdReparto = enRepartoWeb.Etichette) And
                                    (R.IdUnitaMisura = enUnitaDiMisura.lastra Or
                                    R.IdUnitaMisura = enUnitaDiMisura.m2) Then

                                    QtaDaMovimentare = TotSoggetti
                                Else
                                    QtaDaMovimentare = GetQtaNeces()
                                End If

                            Else

                                QtaDaMovimentare = GetQtaNeces()

                            End If

                        End If
                    End Using
                End If

                Dim OkDimensioni As Boolean = True

                If CheckDimensioni = False Then
                    If MessageBox.Show("La risorsa selezionata è più piccola del formato richiesto dal modello commessa. Vuoi forzare l'utilizzo di questa risorsa?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        OkDimensioni = False
                    Else
                        QtaDaMovimentare = GetQtaNeces()
                    End If
                End If

                If OkDimensioni Then
                    If QtaDaMovimentare > 0 Then

                        Dim mag As New frmMagazzinoMovimento
                        mag.MaxQta = QtaDaMovimentare
                        mag.IdRis = IdRis

                        ParentFormEx.Sottofondo()
                        mag.TipoMov = enTipoMovMagaz.Prenotazione
                        mag.OnlyManual = False
                        mag.IdCom = _IdCom
                        Ris = mag.Carica(, Mov, enTipoMovMagaz.Prenotazione)
                        ParentFormEx.Sottofondo()

                        If Ris Then

                            'QtaCaric += Mov.Qta

                            Dim Riga As New DataGridViewRow
                            Riga.CreateCells(DgRisorseSelezionate)

                            Riga.Cells(0).Value = Dr.Cells(0).Value
                            Riga.Cells(1).Value = Dr.Cells(1).Value
                            Riga.Cells(2).Value = (Dr.Cells(2).Value) - Mov.Qta
                            Riga.Cells(3).Value = Mov.Qta
                            Riga.Cells(1).Style.BackColor = Dr.Cells(1).Style.BackColor
                            Riga.Cells(2).Style.BackColor = Dr.Cells(2).Style.BackColor
                            'Riga.Cells(3).Style.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
                            Riga.Cells(1).Style.SelectionBackColor = Dr.Cells(1).Style.SelectionBackColor
                            Riga.Cells(2).Style.SelectionBackColor = Dr.Cells(2).Style.SelectionBackColor

                            DgRisorseSelezionate.Rows.Add(Riga)
                            DgRisorseDisponibili.Rows.Remove(DgRisorseDisponibili.SelectedRows(0))

                            Riga = Nothing
                            AggiornaQtaCaricata()
                            risu = enSiNo.Si
                        End If
                    Else
                        MessageBox.Show("Non è necessario aggiungere altre risorse")
                    End If
                    'Else
                    '    MessageBox.Show("La risorsa selezionata è troppo piccola")
                End If

            End If
        End If
        Return risu
    End Function

    Private Function AggiornaQtaCaricata() As Integer

        Dim tot As Single = 0

        For Each dr As DataGridViewRow In DgRisorseSelezionate.Rows

            Dim C As DataGridViewCell = dr.Cells(3)

            tot += C.Value

        Next

        QtaCaric = tot
        lblQtaScaric.Text = tot
        Return tot

    End Function

    Private Sub lnkDel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked
        RimuoviRisorsa()
        'RaiseEvent CambiataRisorsa()
    End Sub

    Private Sub RimuoviRisorsa()

        If DgRisorseSelezionate.SelectedRows.Count Then
            Dim Dr As DataGridViewRow = DgRisorseSelezionate.SelectedRows(0)
            If Dr.Selected Then
                'sposto la lavorazione tra quelle selezionate

                Dim Riga As New DataGridViewRow
                Riga.CreateCells(DgRisorseDisponibili)

                Riga.Cells(0).Value = Dr.Cells(0).Value
                Riga.Cells(1).Value = Dr.Cells(1).Value
                Riga.Cells(2).Value = Dr.Cells(2).Value
                'Riga.Cells(3).Value = Dr.Cells(3).Value
                Riga.Cells(1).Style.BackColor = Dr.Cells(1).Style.BackColor
                Riga.Cells(2).Style.BackColor = Dr.Cells(2).Style.BackColor
                Riga.Cells(1).Style.SelectionBackColor = Dr.Cells(1).Style.SelectionBackColor
                Riga.Cells(2).Style.SelectionBackColor = Dr.Cells(2).Style.SelectionBackColor

                DgRisorseDisponibili.Rows.Insert(0, Riga)
                DgRisorseSelezionate.Rows.Remove(DgRisorseSelezionate.SelectedRows(0))

                Riga = Nothing

                AggiornaQtaCaricata()

            End If
        End If
    End Sub

    Private Sub DgLavorazioni_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgRisorseDisponibili.CellDoubleClick
        If AggiungiRisorsa() = enSiNo.Si Then RaiseEvent CambiataRisorsa()
    End Sub

    Private Sub DGLavorazioniSel_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgRisorseSelezionate.CellDoubleClick
        RimuoviRisorsa()
        'RaiseEvent CambiataRisorsa()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        DgRisorseDisponibili.Columns.Add("IdRis", "IdRis")
        DgRisorseDisponibili.Columns.Add("Descrizione", "Descrizione")
        DgRisorseDisponibili.Columns.Add("Giacenza", "Giacenza")

        DgRisorseDisponibili.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DgRisorseSelezionate.Columns.Add("IdRis", "IdRis")
        DgRisorseSelezionate.Columns.Add("Descrizione", "Descrizione")
        DgRisorseSelezionate.Columns.Add("Giacenza", "Giacenza")
        DgRisorseSelezionate.Columns.Add("Qta", "Quantità utilizzata")

        DgRisorseSelezionate.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgRisorseSelezionate.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub lnkImpostaGiacenza_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub ImpostaGiacenzaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpostaGiacenzaToolStripMenuItem.Click

        If DgRisorseDisponibili.SelectedRows.Count Then

            Dim Dr As DataGridViewRow = DgRisorseDisponibili.SelectedRows(0)
            If Dr.Selected Then
                Using R As New Risorsa
                    Dim IdRis As Integer = Dr.Cells(0).Value
                    R.Read(IdRis)
                    If MessageBox.Show("Vuoi impostare manualmente la giacenza della risorsa '" & R.Descrizione & "'", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        Dim NuovaGiacenza As String = InputBox("Inserisci la giacenza corretta della risorsa '" & R.Descrizione & "'", "Imposta giacenza", R.Giacenza)

                        If NuovaGiacenza.Length Then
                            If IsNumeric(NuovaGiacenza) Then
                                If CInt(NuovaGiacenza) <> R.Giacenza Then
                                    Dim Mov As New MovimentoMagazzino
                                    Mov.TipoMov = enTipoMovMagaz.Storno
                                    'If CInt(NuovaGiacenza) > R.Giacenza Then
                                    '    Mov.TipoMov = enTipoMovMagaz.Carico

                                    'Else
                                    '    Mov.TipoMov = enTipoMovMagaz.Scarico
                                    'End If

                                    Mov.Qta = NuovaGiacenza - R.Giacenza
                                    Mov.IdRis = R.IdRis
                                    Mov.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                                    Mov.DataMov = Now
                                    Mov.Nota = "Storno per giacenza impostata manualmente"
                                    Mov.Save()

                                    'Using m As New MagazzinoDAO
                                    '    m.AggiornaQta(Mov)
                                    'End Using

                                    R.Read(IdRis)
                                    Dr.Cells(2).Value = R.Giacenza
                                End If
                            End If
                        End If

                    End If
                End Using

            End If
        End If
    End Sub

    Private Sub DettaglioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DettaglioToolStripMenuItem.Click

        If DgRisorseDisponibili.SelectedRows.Count Then

            Dim Dr As DataGridViewRow = DgRisorseDisponibili.SelectedRows(0)
            If Dr.Selected Then
                Dim IdRis As Integer = Dr.Cells(0).Value

                ParentFormEx.Sottofondo()

                Using f As New frmMagazzinoRisorsa
                    f.Carica(IdRis)
                End Using

                ParentFormEx.Sottofondo()

            End If
        End If
    End Sub

    Private Sub AggiungiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggiungiToolStripMenuItem.Click
        If AggiungiRisorsa() = enSiNo.Si Then RaiseEvent CambiataRisorsa()
    End Sub

    Private Sub MostraAncheNonDisponibiliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostraAncheNonDisponibiliToolStripMenuItem.Click
        CaricaDaCommessa()
    End Sub
End Class
