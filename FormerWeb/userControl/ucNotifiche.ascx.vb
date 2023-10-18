Imports FormerLib
Imports FormerDALWeb
Imports FormerLib.FormerEnum
Public Class ucNotifiche
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Private _NumeroNotifiche As Integer = 0
    Public ReadOnly Property NumeroNotifiche As Integer
        Get
            CaricaNotifiche()
            Return _NumeroNotifiche
        End Get
    End Property

    Private Sub CaricaNotifiche()
        _NumeroNotifiche = 0
        tblNotifiche.Rows.Clear()
        If UtenteConnesso.IdUtente Then

            'CONTROLLO SE HA GENERATO IL LISTINO E IN CASO SE NON E' PIU AGGIORNATO DO UNA NOTIFICA
            Using mgr As New ListiniUtenteWDAO
                Dim lLis As List(Of ListinoUtenteW) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoUtenteW.IdUt, UtenteConnesso.IdUtente))

                If lLis.Count Then
                    Dim ListinoUtente As ListinoUtenteW = lLis(0)

                    Dim Differenza As Integer = DateDiff(DateInterval.Minute, ListinoUtente.UltimaGenerazione, FormerWebApp.DataUltimaPubblicazioneListino)
                    If Differenza > 0 Then
                        'qui mostro la notifica
                        _NumeroNotifiche += 1
                        Dim TrInt As New TableRow
                        Dim TcInt As TableCell

                        TcInt = New TableCell
                        TcInt.ColumnSpan = 3
                        TcInt.Text = "<b class=""red"">LISTINO PDF</b></font>"
                        TrInt.Cells.Add(TcInt)

                        tblNotifiche.Rows.Add(TrInt)

                        Dim Tr As New TableRow
                        Dim Tc As TableCell

                        Dim Img As New Image
                        Img.ImageUrl = "/img/icoListino.png"
                        Img.Width = 32
                        Img.Height = 32
                        Img.CssClass = "imgNotif"
                        Tc = New TableCell
                        Tc.Controls.Add(Img)
                        Tc.VerticalAlign = VerticalAlign.Middle
                        Tc.HorizontalAlign = HorizontalAlign.Center
                        Tc.Width = 32

                        Tr.Cells.Add(Tc)

                        Tc = New TableCell
                        Tc.HorizontalAlign = HorizontalAlign.Left
                        Tc.Text = "<a href=""http://listini.tipografiaformer.it/genera-listino"" target=""_new"">Il listino PDF che hai generato non è più aggiornato. <br>Clicca qui per andare alla sezione listini</a>"
                        Tc.Wrap = True

                        Tr.Cells.Add(Tc)

                        Tc = New TableCell
                        Tr.Cells.Add(Tc)

                        tblNotifiche.Rows.Add(Tr)

                        Dim TrSp As TableRow = New TableRow
                        Dim TdSp As TableCell = New TableCell
                        TdSp.ColumnSpan = 3
                        TdSp.Text = "<hr width=""80%"">"

                        TrSp.Cells.Add(TdSp)
                        tblNotifiche.Rows.Add(TrSp)

                    End If

                End If

            End Using


            'CONTROLLO SE HAI LAVORI A CUI ALLEGARE FILE
            Dim L As List(Of OrdineWeb) = Nothing

            'CONTROLLO SE HAI ORDINI DA PAGARE
            Dim LC As List(Of Consegna) = Nothing

            Using mgr As New ConsegneDAO
                LC = mgr.FindAll("DataInserimento", New LUNA.LunaSearchParameter(LFM.Consegna.IdUt, UtenteConnesso.IdUtente),
                                                   New LUNA.LunaSearchParameter(LFM.Consegna.IdStatoConsegna, CInt(enStatoConsegna.InAttesaDiPagamento)))
            End Using
            If LC.Count Then
                _NumeroNotifiche += LC.Count

                Dim TrInt As New TableRow
                Dim TcInt As TableCell

                TcInt = New TableCell
                TcInt.ColumnSpan = 3
                TcInt.Text = "<b class=""red"">ORDINI IN ATTESA PAGAMENTO</b></font>"
                TrInt.Cells.Add(TcInt)

                tblNotifiche.Rows.Add(TrInt)
                For Each C As Consegna In LC
                    Dim Tr As New TableRow
                    Dim Tc As TableCell

                    Dim Img As New Image
                    Img.ImageUrl = C.IconaCorriere
                    Img.Width = 25
                    Img.Height = 21
                    Img.CssClass = "imgNotif"
                    Tc = New TableCell
                    Tc.Controls.Add(Img)
                    Tc.VerticalAlign = VerticalAlign.Middle
                    Tc.HorizontalAlign = HorizontalAlign.Center
                    Tc.Width = 32

                    Tr.Cells.Add(Tc)

                    Tc = New TableCell
                    Tc.HorizontalAlign = HorizontalAlign.Left
                    Tc.Text = "<a href=""/" & C.IdConsegna & "/dettaglio-ordine"">Ordine del " & C.DataInserimento.ToString("dd/MM/yyyy") & "</a>"
                    Tc.Wrap = True

                    Tr.Cells.Add(Tc)

                    Tc = New TableCell
                    Tc.HorizontalAlign = HorizontalAlign.Right
                    Tc.Text = "<a href=""/" & C.IdConsegna & "/dettaglio-ordine""><b> € " & FormerHelper.Stringhe.FormattaPrezzo(C.ImportoTotStr) & "</b></a>"
                    Tc.VerticalAlign = VerticalAlign.Top
                    Tr.Cells.Add(Tc)

                    tblNotifiche.Rows.Add(Tr)
                Next

            End If

            Using mgr As New OrdiniWebDAO
                L = mgr.FindAll("DataIns", New LUNA.LunaSearchParameter("IdUt", UtenteConnesso.IdUtente),
                                                   New LUNA.LunaSearchParameter("StatoWeb", CInt(enStato.Attivo)),
                                                   New LUNA.LunaSearchParameter("Stato", CInt(enStatoOrdine.InAttesaAllegati)),
                                                   New LUNA.LunaSearchParameter("OrdineInOmaggio", enSiNo.Si, "<>"))
            End Using

            If L.Count Then

                If LC.Count Then
                    Dim TrSp As TableRow = New TableRow
                    Dim TdSp As TableCell = New TableCell
                    TdSp.ColumnSpan = 3
                    TdSp.Text = "<hr width=""80%"">"

                    TrSp.Cells.Add(TdSp)
                    tblNotifiche.Rows.Add(TrSp)
                End If

                _NumeroNotifiche += L.Count

                Dim TrInt As New TableRow
                Dim TcInt As TableCell
                'TcInt = New TableCell
                'TcInt.Text = "<div class=""statoOrdineBox"" title=""Ordini in Attesa Invio File"" style=""background-color:" & FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.InAttesaAllegati) & ";""></div>"
                'TcInt.HorizontalAlign = HorizontalAlign.Center
                'TrInt.Cells.Add(TcInt)

                TcInt = New TableCell
                TcInt.ColumnSpan = 3
                TcInt.Text = "<b class=""red"">LAVORI IN ATTESA INVIO FILE</b></font>"
                TrInt.Cells.Add(TcInt)

                tblNotifiche.Rows.Add(TrInt)

                'TrInt = New TableRow
                'TcInt = New TableCell
                'TcInt.ColumnSpan = 3
                'TcInt.Text = "<hr>"

                'TrInt.Cells.Add(TcInt)
                'tblNotifiche.Rows.Add(TrInt)

                For Each O As OrdineWeb In L
                    Dim Tr As New TableRow
                    Dim Tc As TableCell

                    Dim Img As New Image
                    Img.ImageUrl = FormerWeb.FormerWebApp.PathListinoImg & O.BoxImgRif
                    Img.Width = 32
                    Img.Height = 32
                    Tc = New TableCell
                    Tc.Controls.Add(Img)
                    Tc.Width = 32

                    Tr.Cells.Add(Tc)

                    Tc = New TableCell
                    Tc.HorizontalAlign = HorizontalAlign.Left
                    Tc.Text = "<a href=""/" & O.IdOrdine & "/dettaglio-lavoro"">" & O.RiassuntoBox & "</a>"
                    Tc.Wrap = True

                    Tr.Cells.Add(Tc)

                    Tc = New TableCell
                    Tc.HorizontalAlign = HorizontalAlign.Right
                    Tc.Text = "<a href=""/" & O.IdOrdine & "/dettaglio-lavoro""><b> € " & O.ImportoNettoStr & "</b></a>"
                    Tc.VerticalAlign = VerticalAlign.Top
                    Tr.Cells.Add(Tc)

                    tblNotifiche.Rows.Add(Tr)
                Next

            End If

      


        End If

        If _NumeroNotifiche = 0 Then
            Dim Tr As New TableRow
            Dim Tc As New TableCell
            Tc.Text = "Non hai notifiche"
            Tc.HorizontalAlign = HorizontalAlign.Center
            Tr.Cells.Add(Tc)
            tblNotifiche.Rows.Add(Tr)
        End If


    End Sub

End Class