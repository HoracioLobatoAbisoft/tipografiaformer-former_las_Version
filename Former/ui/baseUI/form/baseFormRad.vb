Public Class BaseFormRad
    Implements FormerLib.IFormWithSottofondo

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        Me.BackColor = Color.White
        'Me.ShowIcon = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormElement.Border.Width = 1
        Me.FormElement.Border.ForeColor = FormerLib.FormerColori.ColoreAmbienteGrigioChiaro 'System.Drawing.Color.Lime

        Me.FormElement.TitleBar.Font = New System.Drawing.Font("Segoe UI", 10.0!, FontStyle.Bold)

        Me.FormElement.TitleBar.Padding = New Padding(5, 5, 0, 0)

        'Me.FormElement.TitleBar.Margin = New Padding(0, 3, 0, 0)
        'Me.FormElement.TitleBar.Margin = New Padding(0, 0, 0, 5)

        Me.FormElement.TitleBar.BorderPrimitive.BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders
        Me.FormElement.TitleBar.BorderPrimitive.TopWidth = 0
        Me.FormElement.TitleBar.BorderPrimitive.LeftWidth = 0
        Me.FormElement.TitleBar.BorderPrimitive.RightWidth = 0
        Me.FormElement.TitleBar.BorderPrimitive.BottomWidth = 4
        Me.FormElement.TitleBar.BorderPrimitive.BottomColor = FormerLib.FormerColori.ColoreAmbienteSfondoPrincipale

        Me.FormElement.TitleBar.FillPrimitive.GradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.FormElement.TitleBar.FillPrimitive.BackColor = FormerLib.FormerColori.ColoreAmbienteSfondoGrigioScuro
        Me.FormElement.TitleBar.ForeColor = Color.White

        Me.FormElement.TitleBar.CloseButton.Enabled = False
        Me.FormElement.TitleBar.CloseButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden

        'Me.FormElement.TitleBar.MinimizeButton.BackColor = Color.Red
        Me.FormElement.TitleBar.MinimizeButton.ButtonFillElement.BackColor = FormerLib.FormerColori.ColoreAmbienteSfondoPrincipale
        Me.FormElement.TitleBar.MaximizeButton.ButtonFillElement.BackColor = FormerLib.FormerColori.ColoreAmbienteSfondoPrincipale
        Me.KeyPreview = True

    End Sub

    Public ReadOnly Property NameStr As String Implements FormerLib.IFormWithSottofondo.Name
        Get
            Return Name
        End Get
    End Property

    'Private Const CP_NOCLOSE_BUTTON As Integer = 512
    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim MyCP As CreateParams = MyBase.CreateParams
    '        MyCP.ClassStyle = MyCP.ClassStyle And CP_NOCLOSE_BUTTON
    '        Return MyCP

    '    End Get
    'End Property

    Public Property formSopra As cFormSopra = Nothing

    'Public Event ChiaveUSBConnessa()
    'Public Event ChiaveUSBDisconnessa()

    'Private WM_DEVICECHANGE As Integer = &H219
    'Public Enum WM_DEVICECHANGE_WPPARAMS As Integer
    '    DBT_CONFIGCHANGECANCELED = &H19
    '    DBT_CONFIGCHANGED = &H18
    '    DBT_CUSTOMEVENT = &H8006
    '    DBT_DEVICEARRIVAL = &H8000
    '    DBT_DEVICEQUERYREMOVE = &H8001
    '    DBT_DEVICEQUERYREMOVEFAILED = &H8002
    '    DBT_DEVICEREMOVECOMPLETE = &H8004
    '    DBT_DEVICEREMOVEPENDING = &H8003
    '    DBT_DEVICETYPESPECIFIC = &H8005
    '    DBT_DEVNODES_CHANGED = &H7
    '    DBT_QUERYCHANGECONFIG = &H17
    '    DBT_USERDEFINED = &HFFFF
    'End Enum

    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

    '    Try
    '        If UsbResponsive Then
    '            If m.Msg = WM_DEVICECHANGE Then
    '                Select Case m.WParam
    '                    Case WM_DEVICECHANGE_WPPARAMS.DBT_DEVICEARRIVAL
    '                        RaiseEvent ChiaveUSBConnessa()
    '                    Case WM_DEVICECHANGE_WPPARAMS.DBT_DEVICEREMOVECOMPLETE
    '                        RaiseEvent ChiaveUSBDisconnessa()
    '                End Select
    '            End If
    '            MyBase.WndProc(m)
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Public Property UsbResponsive As Boolean = False

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
