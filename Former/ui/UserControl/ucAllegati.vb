Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucAllegati
    Inherits ucFormerUserControl

    Private Sub ucAllegati_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White
    End Sub
    ' Private _NumAllegati As Integer = 0
    Public ReadOnly Property NumAllegati As Integer
        Get
            Return dgMessRic.Rows.Count
        End Get
    End Property

    Private _IdCom As Integer = 0
    Private _IdOrd As Integer = 0
    Private _IdRub As Integer = 0
    Private _LastYearOnly As Boolean = False

    Public Property FromOperatore As Boolean = False

    Public Sub Carica(Optional IdCom As Integer = 0,
                      Optional IdOrd As Integer = 0,
                      Optional IdRub As Integer = 0,
                      Optional LastYearOnly As Boolean = False)
        'FormerDebug.Traccia()
        _IdCom = IdCom
        _IdOrd = IdOrd
        _IdRub = IdRub
        _LastYearOnly = LastYearOnly
        Cursor.Current = Cursors.WaitCursor
        CaricaDati()
        'se non mi viene passato nessuno dei due e' la visualizzazione solo di quelli per tutti a tutto schermo con anteprima

        Cursor.Current = Cursors.Default

    End Sub

    Public ReadOnly Property IdCom As Integer
        Get
            Return _IdCom
        End Get
    End Property

    Public ReadOnly Property IdOrd As Integer
        Get
            Return _IdOrd
        End Get
    End Property

    Public ReadOnly Property IdRub As Integer
        Get
            Return _IdRub
        End Get
    End Property

    Public Sub Aggiorna()
        Cursor.Current = Cursors.WaitCursor
        CaricaDati()
        'se non mi viene passato nessuno dei due e' la visualizzazione solo di quelli per tutti a tutto schermo con anteprima

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub CaricaDati()

        Using mgr As New MessaggiDAO
            Dim l As List(Of Messaggio)

            If _IdCom Then
                'dgMessRic.Columns(0).Visible = False
                'dgMessRic.Columns(1).Visible = False
                'dgMessRic.Columns(2).Visible = False
                'l = mgr.Find("Datains desc", New LUNA.LunaSearchParameter("IdCom", IdCom))
                l = mgr.MessaggiCommessa(_IdCom, FromOperatore)
            ElseIf _IdOrd Then
                'dgMessRic.Columns(0).Visible = False
                'dgMessRic.Columns(1).Visible = False
                'dgMessRic.Columns(2).Visible = False

                Dim pFromOperatore As LUNA.LunaSearchParameter = Nothing

                If FromOperatore Then
                    pFromOperatore = New LUNA.LunaSearchParameter(LFM.Messaggio.TipoMsg, enTipoMessaggio.Automatico, "<>")
                End If

                l = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Datains desc"},
                                New LUNA.LunaSearchParameter(LFM.Messaggio.IdOrd, _IdOrd), pFromOperatore)
            Else
                Dim ParamLastYear As LUNA.LunaSearchParameter = Nothing
                If _LastYearOnly Then
                    ParamLastYear = New LUNA.LunaSearchParameter("datediff(""d"",DataIns,GetDate())", 365, "<=")
                End If
                l = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Datains desc"},
                                New LUNA.LunaSearchParameter(LFM.Messaggio.IdDest, 0), ParamLastYear)
            End If
            dgMessRic.AutoGenerateColumns = False
            dgMessRic.DataSource = l
            dgMessRic.ClearSelection()
        End Using
    End Sub

    Private Sub dgMessRic_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMessRic.CellDoubleClick
        If e.RowIndex <> -1 Then
            Dim M As Messaggio = dgMessRic.Rows(e.RowIndex).DataBoundItem

            Dim x As New frmPostit
            ParentFormEx.Sottofondo()
            x.Carica(M)
            ParentFormEx.Sottofondo()
        End If
    End Sub

    Private Sub dgMessRic_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgMessRic.RowPostPaint
        Dim r As DataGridViewRow = dgMessRic.Rows(e.RowIndex)
        If r.Cells(0).Visible = True Then
            If Not r.Cells(0).Value Is Nothing Then
                r.Height = 100
            End If
        End If
    End Sub
End Class
