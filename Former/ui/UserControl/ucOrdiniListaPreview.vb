Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucOrdiniListaPreview
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Reset()

        flowPanel.Controls.Clear()
        ToolTipBox.RemoveAll()

    End Sub

    Public Sub ImageClick(Sender As Object, e As EventArgs)

        RaiseEvent OrdineSelezionato(Sender.tag)

    End Sub

    Public Event OrdineSelezionato(ByVal IdOrdine As Integer)

    Private Property IdRubAttuale As Integer = 0

    Public Sub Carica(IdRub As Integer,
                      Optional IdCorr As Integer = 0)

        'carico le preview degli ordini di un determinato cliente in tutti gli stati fino a pronto ritiro

        If IdRub <> IdRubAttuale Then
            IdRubAttuale = IdRub

            Reset()

            Using Mgr As New OrdiniDAO
                Dim l As List(Of Ordine) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdRub, IdRub),
                                                       New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.ProntoRitiro, " <="))

                If IdCorr Then
                    l = l.FindAll(Function(x) Not x.ConsegnaAssociata Is Nothing AndAlso x.ConsegnaAssociata.IdCorr = IdCorr)
                End If

                l.Sort(Function(x, y) y.ConsegnaAssociata.Giorno.CompareTo(x.ConsegnaAssociata.Giorno))

                For Each O As Ordine In l

                    Dim Larghezza As Integer = 96
                    Dim Altezza As Integer = 0
                    If O.ImgAnteprima.Width > O.ImgAnteprima.Height Then
                        Altezza = (O.ImgAnteprima.Height * Larghezza) / O.ImgAnteprima.Width
                    Else
                        Dim AltTemp As Integer = Altezza
                        Altezza = Larghezza
                        Larghezza = (O.ImgAnteprima.Width * Altezza) / O.ImgAnteprima.Height
                    End If

                    Dim ImgRif As Image = New Bitmap(O.ImgAnteprima, Larghezza, Altezza)

                    Dim P As New PictureBox  'ucPictureWithZoom
                    P.Top = 3
                    ' P.Left = Start
                    P.SizeMode = PictureBoxSizeMode.CenterImage
                    P.Visible = True
                    P.Width = 100
                    P.Height = 100
                    P.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                    P.BackColor = FormerLib.FormerColori.GetColoreStatoOrdine(O.Stato)
                    P.Image = ImgRif
                    P.Tag = O.IdOrd
                    P.Cursor = Cursors.Hand

                    AddHandler P.Click, AddressOf ImageClick

                    Dim Riassunto As String = O.StatoStr.ToUpper & " - Lavoro " & O.IdOrd
                    If Not O.ConsegnaAssociata Is Nothing Then
                        Riassunto &= " in consegna il " & O.ConsegnaAssociata.Giorno.ToString("dd/MM/yyyy")
                    End If
                    ToolTipBox.SetToolTip(P, Riassunto)

                    flowPanel.Controls.Add(P)
                Next

            End Using
        End If

    End Sub

End Class
