Public Class ucSliderGroup

    Private _ListaSlider As List(Of ucLabelSlider)

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        pnlMain.Controls.Clear()
        _ListaSlider = New List(Of ucLabelSlider)

    End Sub

    Public ReadOnly Property ListaSlider As List(Of ucLabelSlider)
        Get
            Return _ListaSlider
        End Get
    End Property

    Public Sub AddSlider(Sigla As String,
                         Icon As Image,
                         Optional LabelLunga As String = "",
                         Optional SiglaForeColor As Color = Nothing,
                         Optional PanelBackColor As Color = Nothing)

        Dim S As New ucLabelSlider

        Dim SiglaEx As String = Sigla
        If SiglaEx.Length > 3 Then
            SiglaEx = "..."
        End If

        S.CustomSigla = SiglaEx
        S.CustomIcon = Icon
        S.CustomLongMessage = LabelLunga
        S.CustomBackColor = PanelBackColor
        S.CustomSiglaForeColor = SiglaForeColor
        S.Visible = True

        'AddHandler S.MouseEnter, AddressOf S.MouseEnterSub
        'AddHandler S.MouseLeave, AddressOf S.MouseLeaveSub

        _ListaSlider.Add(S)

        pnlMain.Controls.Add(S)

    End Sub

    Public Sub ResetListaSlider()
        _ListaSlider.Clear()
        pnlMain.Controls.Clear()
    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnRiassunto.Click
        For Each ctr As ucLabelSlider In pnlMain.Controls
            ctr.NotForceExpand()
        Next
    End Sub

    Private Sub btnExpandAll_Click(sender As Object, e As EventArgs) Handles btnExpandAll.Click
        For Each ctr As ucLabelSlider In pnlMain.Controls
            ctr.ForceExpand()
        Next
    End Sub

    Private Sub ucSliderGroup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Width < 83 Then Width = 83
    End Sub

    Private Sub ucSliderGroup_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter

    End Sub
End Class
