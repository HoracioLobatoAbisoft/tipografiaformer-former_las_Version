Imports FormerDALWeb
Imports FormerLib.FormerEnum
Public Class ucBoxFooterLavoro
    Inherits FormerUserControl

    Public Property Ordine As IOrdineBox

    Private Sub DelOrd(Optional NextUrl As String = "")
        If Ordine.IdOrdineWeb Then
            'qui e' un ordine online salvato
            'devo prima vedere la consegna

            Dim O As New OrdineWeb
            O.Read(Ordine.IdOrdineWeb)
            If O.ConsegnaAssociata.Modificabile Then
                If O.Modificabile Then
                    'controllo tutti gli altri ordini della consegna
                    Dim AncheAltriOk As Boolean = True
                    Dim CountAltriOrdini As Integer = 0
                    Dim CountOrdiniOmaggio As Integer = 0
                    For Each singLav As OrdineWeb In O.ConsegnaAssociata.ListaOrdini.FindAll(Function(x) x.IdOrdine <> O.IdOrdine)
                        If singLav.Modificabile = False Then AncheAltriOk = False
                        CountAltriOrdini += 1
                        If singLav.Omaggio = enSiNo.Si Then
                            CountOrdiniOmaggio += 1
                        End If
                    Next
                    If AncheAltriOk Then

                        If CountAltriOrdini Then
                            'qui ci sono altri ordini
                            'bisogna cancellare solo l'ordine che a questo punto va eliminato
                            Dim IdCons As Integer = O.ConsegnaAssociata.IdConsegna

                            If CountAltriOrdini = 1 And CountOrdiniOmaggio = 1 Then
                                'qui va eliminato tutto
                                For Each singlav As OrdineWeb In O.ConsegnaAssociata.ListaOrdini
                                    Using mgr As New OrdiniWebDAO
                                        mgr.Delete(singlav)
                                    End Using
                                Next

                                Using mgr As New ConsegneDAO
                                    mgr.Delete(IdCons)
                                End Using

                            Else
                                Using mgr As New OrdiniWebDAO
                                    mgr.Delete(O)
                                End Using

                                Dim Cons As New Consegna
                                Cons.Read(IdCons)

                                Dim mgrSped As New MGRSpedizioniCumulative
                                Dim sp As SpedizioneCumulativa = mgrSped.RiCalcolaImportoConsegnaOrdini(Cons.ListaOrdini, Cons.MetodoPagamento)
                                Cons.Giorno = sp.Quando
                                Cons.ImportoNetto = sp.ImportoRicalcolato
                                Cons.Save()
                            End If

                        Else
                            O.DataCambioStato = Now
                            O.Stato = enStatoOrdine.Eliminato
                            O.StatoWeb = enStato.NonAttivo
                            O.Save()
                            'qui non ci sono altri ordini
                            'elimino anche la consegna
                            O.ConsegnaAssociata.IdStatoConsegna = enStatoConsegna.Eliminata
                            O.ConsegnaAssociata.Save()
                        End If
                    End If
                End If
            End If
        Else
            Carrello.RimuoviOrdine(Ordine.IdRiferimentoOrdine)
            'qui stiamo nel carrello
        End If

        Dim UrlRif As String = Request.Url.AbsolutePath
        If NextUrl.Length Then UrlRif = NextUrl
        Response.Redirect(UrlRif)

    End Sub

    Private Sub lnkDelOrd_Click(sender As Object, e As EventArgs) Handles lnkDelOrd.Click
        DelOrd()
    End Sub

    Private Sub lnkDelGo_Click(sender As Object, e As EventArgs) Handles lnkDelGo.Click

        Dim UrlRif As String = FormerUrlCreator.GetUrl(Ordine.ListinoBase.IdPrev,
                                                        Ordine.ListinoBase.IdFormProd,
                                                        Ordine.ListinoBase.IdTipoCarta,
                                                        Ordine.ListinoBase.IdColoreStampa)
        DelOrd(UrlRif)
    End Sub

End Class