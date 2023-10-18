Imports System.Windows.Forms

Public Class ucLabelScrolling
    Inherits Label
    Private WithEvents T As New Timer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub PowerOn()
        T.Interval = 200
        T.Enabled = True
    End Sub

    Public Sub PowerOff()
        T.Enabled = False
    End Sub

    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            'If Not value.EndsWith(" ") Then value &= " "
            MyBase.Text = value
        End Set
    End Property

    Private Sub Timer() Handles T.Tick
        If Text.Length > 1 Then
            Dim OrigText As String = Text
            Dim FirstChar As String = OrigText.Substring(0, 1)
            OrigText = OrigText.Substring(1) & FirstChar
            Text = OrigText
        End If
    End Sub
End Class
