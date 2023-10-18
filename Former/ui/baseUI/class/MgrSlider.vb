Imports FormerDALSql

Public Class MgrSlider

    Public Shared Sub CaricaOrdine(ByRef S As ucSliderGroup,
                                   O As Ordine)

        S.AddSlider("O", My.Resources._Ordine, "Ordine " & O.IdOrd & " - " & O.StatoStr,, O.StatoColore)

    End Sub

    Public Shared Sub CaricaCommessa(ByRef S As ucSliderGroup,
                               C As Commessa)

        S.AddSlider("C", My.Resources._Commessa, "Commessa " & C.IdCom & " - " & C.StatoStr,, C.StatoColore)

        Using Mgr As New MagazzinoDAO

            Dim lRis As List(Of MovimentoMagazzino) = Mgr.FindAll(LFM.MovimentoMagazzino.Qta,
                                                               New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCom, C.IdCom))

            For Each R As MovimentoMagazzino In lRis.FindAll(Function(x) x.Risorsa.IsLastra = False)
                S.AddSlider(R.Risorsa.Codice, R.Risorsa.TipoCarta.Img, R.RisorsaStr)
            Next

        End Using

    End Sub

End Class
