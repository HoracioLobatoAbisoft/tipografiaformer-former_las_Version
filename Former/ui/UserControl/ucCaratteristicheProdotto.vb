Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucCaratteristicheProdotto

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' BackColor = Color.White

    End Sub

    Private Sub RimuoviLavorazioni()
        flowPanel.Controls.Clear()

        'For Each c As PictureBox In flowPanel.Controls
        '    c.Visible = False
        '    Try
        '        If c.Tag = "CUSTOM" Then
        '            flowPanel.Controls.Remove(c)
        '            'c.Dispose()
        '            'c = Nothing
        '        End If
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        If c.Tag = "CUSTOM" Then
        '            c.Dispose()
        '        End If
        '    Catch ex As Exception

        '    End Try
        'Next
        flowPanel.Refresh()
    End Sub

    Public Sub Carica(Lis As ListinoBase)
        'dall'ordine risalgo al litsino base

        ToolTipBox.RemoveAll()

        Dim L As List(Of Integer) = Nothing
        Using mgr As New LavorazioniDAO
            L = mgr.ListaIdLavorazioniSuListinoBase(Lis.IdListinoBase)
        End Using

        CaricaFormato(Lis.IdFormProd)
        CaricaTipoCarta(Lis.IdTipoCarta)

        RimuoviLavorazioni()
        If Not L Is Nothing Then
            CaricaLavorazioni(L)
        End If
    End Sub

    Public Sub Carica(C As Commessa)

        ToolTipBox.RemoveAll()
        RimuoviLavorazioni()

        If C.IdReparto <> enRepartoWeb.StampaOffset Then
            If C.ListaOrdini.Count Then
                Carica(C.ListaOrdini.Item(0))
            End If
        End If

    End Sub

    Public Sub Carica(O As Ordine)
        'dall'ordine risalgo al litsino base

        ToolTipBox.RemoveAll()
        RimuoviLavorazioni()

        Dim L As List(Of Integer) = Nothing

        If O.IdListinoBase Then

            Using mgr As New LavorazioniDAO
                L = mgr.ListaIdLavorazioniSuOrdine(O.IdOrd, O.IdCom)
            End Using
            If O.IdTipoFustella Then
                CaricaFustella(O.IdTipoFustella)
            Else
                If O.Prodotto.ListinoBase.Preventivazione.IdReparto <> enRepartoWeb.Ricamo Then
                    CaricaFormato(O.Prodotto.ListinoBase.IdFormProd)
                End If
            End If
            CaricaTipoCarta(O.Prodotto.ListinoBase.IdTipoCarta)
            'Else
            '    pctFormato.Image = pctFormato.ErrorImage
            '    pctTipoCarta.Image = pctTipoCarta.ErrorImage
        End If

        If Not L Is Nothing Then
            CaricaLavorazioni(L)
        End If
    End Sub

    'Public Sub Caricas(Optional IdFormato As Integer = 0, Optional IdTipoCarta As Integer = 0, Optional Lavorazioni As List(Of Integer) = Nothing)
    '    ToolTipBox.RemoveAll()
    '    Try
    '        If IdFormato Then
    '            CaricaFormato(IdFormato)
    '        Else
    '            pctFormato.Image = pctFormato.ErrorImage
    '        End If

    '        If IdTipoCarta Then
    '            CaricaTipoCarta(IdTipoCarta)
    '        Else
    '            pctTipoCarta.Image = pctTipoCarta.ErrorImage
    '        End If
    '        RimuoviLavorazioni()
    '        If Not Lavorazioni Is Nothing Then
    '            CaricaLavorazioni(Lavorazioni)
    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Public Sub Carica(PathImgFormato As String, PathImgTipoCarta As String, PathImgLavorazioni As List(Of String))

    '    Try

    '        pctFormato.Image = Image.FromFile(PathImgFormato)
    '        pctTipoCarta.Image = Image.FromFile(PathImgTipoCarta)

    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Public Sub Carica(IdProd As Integer)
    '    ToolTipBox.RemoveAll()
    '    Dim P As New Prodotto
    '    P.Read(IdProd)

    '    Dim L As List(Of Integer) = (New LavorazioniDAO).ListaIdLavorazioniSuProdotto(P.IdProd)

    '    If P.IdFormato Then
    '        CaricaFormato(P.IdFormato)
    '    Else
    '        pctFormato.Image = pctFormato.ErrorImage
    '    End If

    '    If P.IdTipoCarta Then
    '        CaricaTipoCarta(P.IdTipoCarta)
    '    Else
    '        pctTipoCarta.Image = pctTipoCarta.ErrorImage
    '    End If

    '    RimuoviLavorazioni()
    '    If Not L Is Nothing Then
    '        CaricaLavorazioni(L)
    '    End If

    '    P = Nothing

    'End Sub

    Private Sub CaricaFormato(IDFormato As Integer)

        Dim P As New ucPictureWithZoom
        P.Top = 3
        ' P.Left = Start
        P.SizeMode = PictureBoxSizeMode.StretchImage
        P.Visible = True
        P.Width = 64
        P.Height = 64
        P.BorderStyle = Windows.Forms.BorderStyle.FixedSingle

        'P.Tag = "CUSTOM"
        Using F As New FormatoProdottoEx
            F.Read(IDFormato)
            P.Image = F.Img
            P.Label = F.Formato
            ToolTipBox.SetToolTip(P, F.Formato)
        End Using

        flowPanel.Controls.Add(P)

    End Sub

    Private Sub CaricaFustella(IDTipoFustella As Integer)
        Dim P As New ucPictureWithZoom
        P.Top = 3
        ' P.Left = Start
        P.SizeMode = PictureBoxSizeMode.StretchImage
        P.Visible = True
        P.Width = 64
        P.Height = 64
        P.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        'P.Tag = "CUSTOM"
        Using F As New TipoFustella
            F.Read(IDTipoFustella)
            P.Image = F.ImgRiferimento128
            P.Label = F.Riassunto
            ToolTipBox.SetToolTip(P, F.Riassunto)
        End Using

        flowPanel.Controls.Add(P)

    End Sub

    Private Sub CaricaTipoCarta(IdTipoCarta As Integer)
        Dim P As New ucPictureWithZoom
        P.Top = 3
        ' P.Left = Start
        P.SizeMode = PictureBoxSizeMode.StretchImage
        P.Visible = True
        P.Width = 64
        P.Height = 64
        P.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        'P.Tag = "CUSTOM"
        Using TC As New TipoCartaEx
            TC.Read(IdTipoCarta)
            P.Image = TC.Img
            P.Label = TC.Tipologia
            ToolTipBox.SetToolTip(P, TC.Tipologia)
        End Using

        flowPanel.Controls.Add(P)
    End Sub

    Private Sub CaricaLavorazioni(Lavorazioni As List(Of Integer))
        'Dim Start As Integer = pctTipoCarta.Left + pctTipoCarta.Width + 3

        For Each IdL As Integer In Lavorazioni

            'qui devo caricare a runtime le img 
            Dim P As New ucPictureWithZoom
            P.Top = 3
            ' P.Left = Start
            P.SizeMode = PictureBoxSizeMode.StretchImage
            P.Visible = True
            P.Width = 64
            P.Height = 64
            P.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            'P.Tag = "CUSTOM"
            Using L As New LavorazioneEx
                L.Read(IdL)
                P.Image = L.Img
                P.Label = L.Descrizione
                ToolTipBox.SetToolTip(P, L.Descrizione)
            End Using

            flowPanel.Controls.Add(P)
        Next
    End Sub

    Private Sub CaricaListinoBase(IdListinoBase As Integer)
        Dim P As New ucPictureWithZoom
        P.Top = 3
        ' P.Left = Start
        P.SizeMode = PictureBoxSizeMode.StretchImage
        P.Visible = True
        P.Width = 64
        P.Height = 64
        P.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        'P.Tag = "CUSTOM"
        Using F As New ListinoBase
            F.Read(IdListinoBase)
            P.Image = F.GetImgRif
            P.Label = F.Nome
            ToolTipBox.SetToolTip(P, F.Nome)
        End Using

        flowPanel.Controls.Add(P)

    End Sub
End Class
