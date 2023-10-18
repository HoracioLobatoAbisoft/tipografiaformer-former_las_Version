Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports FormerLib.FormerEnum

Public Class ucLinkLabel
    Inherits LinkLabel
    Implements IRoundedControl
    'Public Sub New()

    '    If TipoControllo = enTipoControlloSuForm.Principale Then
    '        BackColor = FormerLib.FormerColori.ColoreControlloPrimario
    '    ElseIf TipoControllo = enTipoControlloSuForm.Secondario Then
    '        BackColor = FormerLib.FormerColori.ColoreControlloSecondario
    '    End If

    'End Sub

    'Public Property TipoControllo As enTipoControlloSuForm = enTipoControlloSuForm.Secondario

    Public Property RoundedBorder As Boolean Implements IRoundedControl.RoundedBorder

    Private Sub lblCreataAutomatico_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        MgrRoundedControl.RePaint(Me, e)
    End Sub

End Class
