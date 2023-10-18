Imports FormerDALSql

Public Class ucListinoIcoLavorazione
    Inherits ucFormerUserControl
    Private Start As Integer = 3

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
        'ResizeRedraw = True
    End Sub

    Private Sub RimuoviLavorazioni()
        Try
            Me.Controls.Clear()
        Catch ex As Exception

        End Try

        Try
            Me.Refresh()
        Catch ex As Exception

        End Try

        Start = 3
    End Sub

    Public Sub Carica(LObbl As List(Of Lavorazione),
                      Optional LOpz As List(Of Lavorazione) = Nothing)
        'ResizeRedraw = True

        ToolTipBox.RemoveAll()
        RimuoviLavorazioni()

        CaricaLavorazioni(LObbl)
        If Not LOpz Is Nothing Then CaricaLavorazioni(LOpz)

    End Sub

    Private Sub CaricaLavorazioni(Lavorazioni As List(Of Lavorazione))
        Dim mWidth As Integer = 64
        Dim mHeigth As Integer = 64


        For Each L As Lavorazione In Lavorazioni

            'qui devo caricare a runtime le img 
            Dim P As New ucPictureWithZoom
            P.Top = Start
            P.Left = 3
            P.SizeMode = PictureBoxSizeMode.StretchImage
            P.Visible = True
            P.Width = 64
            P.Height = 64
            P.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            P.Tag = "CUSTOM"
            Me.Controls.Add(P)

            Try
                Dim Img As Image = Image.FromFile(L.ImgRif)
                P.Image = Img
            Catch ex As Exception
                P.Image = My.Resources.no_image
            End Try



            Start += 67

            ToolTipBox.SetToolTip(P, L.Descrizione)

        Next
        Refresh()

    End Sub

End Class
