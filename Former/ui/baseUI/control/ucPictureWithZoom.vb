Imports FormerLib

Public Class ucPictureWithZoom
    Inherits PictureBox

    Private WithEvents pctZoom As PictureBox = New PictureBox

    Public Sub New()

        Cursor = Cursors.Hand
        pctZoom.Image = My.Resources.icoZoom
        pctZoom.Width = 16
        pctZoom.Height = 16
        pctZoom.BringToFront()
        pctZoom.BackColor = Color.White
        Controls.Add(pctZoom)
        BackColor = Color.White
        SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private ReadOnly Property RelativeParent As IFormWithSottofondo
        Get
            Dim Ris As Object = Nothing
            Dim P As Object = Me
            Do Until Not Ris Is Nothing
                If Not P Is Nothing Then
                    P = P.Parent
                    If TypeOf (P) Is IFormWithSottofondo Then
                        Ris = P
                    End If
                Else
                    Exit Do
                End If
            Loop

            Return Ris
        End Get
    End Property

    Public Property Label As String

    Private Sub ucCTRPictureWithZoom_Click(sender As Object, e As EventArgs) Handles Me.Click, pctZoom.Click

        If Not Image Is Nothing Then

            If Not RelativeParent Is Nothing Then RelativeParent.Sottofondo()
            Using frm As New frmZoomImg
                frm.Carica(Image, Label)
            End Using
            If Not RelativeParent Is Nothing Then RelativeParent.Sottofondo()
        End If

    End Sub

    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ucCTRPictureWithZoom
        '
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub ucCTRPictureWithZoom_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pctZoom.Location = New Point(Width - 18, Height - 18)
    End Sub
End Class
