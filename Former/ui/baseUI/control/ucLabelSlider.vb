Public Class ucLabelSlider

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        Width = 34
        BackColor = Color.White

    End Sub

    Private Sub Panel1_MouseEnter(sender As Object, e As EventArgs) Handles pctIco.MouseEnter,
                                                                            lblSigla.MouseEnter,
                                                                            Me.MouseEnter
        Expand()
    End Sub

    'Private Sub Panel1_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
    '    Expand()
    'End Sub

    Private Sub Expand()
        If lblLongMessage.Text.Length AndAlso lblLongMessage.Visible = False Then

            lblLongMessage.Visible = True
            'pctIco.Width = 64
            'pctIco.Height = 64
            'lblLongMessage.Height = 64
            'lblSigla.Height = 64
        End If
    End Sub

    Private Sub Collapse()
        If lblLongMessage.Text.Length AndAlso lblLongMessage.Visible = True Then
            If _ForceExpand = False Then
                lblLongMessage.Visible = False
                'pctIco.Width = 26
                'pctIco.Height = 26
                'lblLongMessage.Height = 24
                'lblSigla.Height = 25
            End If
        End If
    End Sub

    Private Sub Panel1_MouseLeave(sender As Object, e As EventArgs) Handles pctIco.MouseLeave, lblSigla.MouseLeave, Me.MouseLeave

        Collapse()

    End Sub

    Public Property CustomSigla As String
        Get
            Return lblSigla.Text
        End Get
        Set(value As String)
            lblSigla.Text = value
        End Set
    End Property

    Public Property CustomSiglaForeColor As Color
        Get
            Return lblSigla.ForeColor
        End Get
        Set(value As Color)
            lblSigla.ForeColor = value
        End Set
    End Property

    Public Property CustomLongMessage As String
        Get
            Return lblLongMessage.Text
        End Get
        Set(value As String)
            lblLongMessage.Text = value
        End Set
    End Property

    Public Property CustomIcon As Image
        Get
            Return pctIco.Image
        End Get
        Set(value As Image)
            pctIco.Image = value
        End Set
    End Property

    Public Property CustomBackColor As Color
        Get
            Return pnlMain.BackColor
        End Get
        Set(value As Color)
            pnlMain.BackColor = value
        End Set
    End Property

    Private _ForceExpand As Boolean = False

    Public Sub ForceExpand()
        _ForceExpand = True
        If lblLongMessage.Text.Length Then lblLongMessage.Visible = True
    End Sub

    Public Sub NotForceExpand()
        _ForceExpand = False
        If lblLongMessage.Text.Length Then lblLongMessage.Visible = False
    End Sub

    'Public Sub MouseEnterSub(sender As Object, e As EventArgs)
    '    Expand()
    'End Sub

    'Public Sub MouseLeaveSub(sender As Object, e As EventArgs)
    '    Collapse()
    'End Sub

    'Private Sub ucLabelSlider_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
    '    Expand()
    'End Sub

    'Private Sub ucLabelSlider_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
    '    Collapse()
    'End Sub

    'Private Sub pnlMain_MouseEnter(sender As Object, e As EventArgs) Handles pnlMain.MouseEnter

    '    Expand()

    'End Sub

    'Private Sub pnlMain_MouseLeave(sender As Object, e As EventArgs) Handles pnlMain.MouseLeave
    '    Collapse()
    'End Sub
End Class
