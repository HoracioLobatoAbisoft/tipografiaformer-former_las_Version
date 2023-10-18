Public Class baseFormInterna
    Implements FormerLib.IFormWithSottofondo

    Public Property formSopra As cFormSopra

    Public ReadOnly Property NameStr As String Implements FormerLib.IFormWithSottofondo.Name
        Get
            Return Name
        End Get
    End Property

    Public Sub Sottofondo() Implements FormerLib.IFormWithSottofondo.Sottofondo

        If Visible Then
            If formSopra Is Nothing Then

                Dim x As New cFormSopra(Me)
                formSopra = x
                'x.StartPosition = FormStartPosition.CenterParent
                'x.ShowInTaskbar = False
                'x.ShowIcon = False

                x.Show(Me)

            Else

                Focus()
                formSopra.Hide()
                formSopra.Dispose()
                formSopra = Nothing

            End If
        End If

    End Sub

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()
        KeyPreview = True

        'ImlOfficialLoader.Load(imlOfficial16)
        'ImlOfficialLoader.Load(imlOfficial26)


    End Sub

    'Public Event SegnalazioneBugRichiesta()

    Private Sub frmBaseForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F10 Then

            Using f As New frmBug
                f.Carica(Me)
            End Using
        ElseIf e.KeyCode = Keys.F12 Then
            Using f As New frmScreenShoot
                f.Carica(Me)
            End Using
        ElseIf e.KeyCode = Keys.Escape Then
            If CloseOnEsc Then
                Close()
            End If
        End If

    End Sub

    Public Property CloseOnEsc As Boolean = False


End Class