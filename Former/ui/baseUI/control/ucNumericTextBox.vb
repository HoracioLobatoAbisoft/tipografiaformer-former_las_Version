Imports System.Windows.Forms

Public Class ucNumericTextBox
    Inherits TextBox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Text = DefaultValue
        TextAlign = HorizontalAlignment.Right
        Width = 82
    End Sub

    Public Property My_AllowOnlyInteger As Boolean = False
    Private Const DefaultMinValue As Single = -1000000000
    Private Const DefaultMaxValue As Single = 10000000000
    Public Property My_MinValue As Single = DefaultMinValue
    Public Property My_MaxValue As Single = DefaultMaxValue

    Private _ReplaceWithDefaultValue As Boolean = True
    Public Property My_ReplaceWithDefaultValue As Boolean
        Get
            Return _ReplaceWithDefaultValue
        End Get
        Set(value As Boolean)
            _ReplaceWithDefaultValue = value
        End Set
    End Property

    Public ReadOnly Property Value As Single
        Get
            Dim ris As Single = 0
            If MyBase.Text <> String.Empty Then
                ris = CSng(MyBase.Text)
            End If
            Return ris
        End Get
    End Property

    Public Property My_AccettaNegativi As Boolean = False

    Private Sub ucNumericTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        MgrControl.ControlloNumerico(sender, e, My_AllowOnlyInteger, My_AccettaNegativi)
    End Sub

    Public Property My_DefaultValue As Integer = 0

    Private Sub ucNumericTextBox_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        sender.selectall()
    End Sub

    Private Sub ucNumericTextBox_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        If sender.text.length = 0 Then
            If My_DefaultValue < My_MinValue Then
                My_DefaultValue = My_MinValue
            End If
            If My_ReplaceWithDefaultValue Then sender.text = My_DefaultValue
        Else
            If My_MinValue <> DefaultMinValue Then
                If Val(sender.text) < My_MinValue Then
                    sender.text = My_MinValue
                End If
            End If
            If My_MaxValue <> DefaultMaxValue Then
                If Val(sender.text) > My_MaxValue Then
                    sender.text = My_MaxValue
                End If
            End If
        End If
    End Sub

    Private Sub ucNumericTextBox_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        'If sender.text.length = 0 Then
        '    If DefaultValue < MinValue Then
        '        DefaultValue = MinValue
        '    End If
        '    sender.text = DefaultValue
        'Else
        '    If Val(sender.text) < MinValue Then
        '        sender.text = MinValue
        '    End If
        'End If
    End Sub

    Private Property TestoSelezionato As Boolean = False

    Private Sub ucNumericTextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.Click
        If TestoSelezionato = False Then
            TestoSelezionato = True
            sender.SelectAll()
        Else
            TestoSelezionato = False
        End If
    End Sub

    'Public Overrides Property Text As String
    '    Get
    '        Return MyBase.Text
    '    End Get
    '    Set(value As String)

    '        If OnlyInteger = False Then
    '            MyBase.Text = Math.Round(CDec(value), 2)
    '        End If

    '    End Set
    'End Property

End Class
