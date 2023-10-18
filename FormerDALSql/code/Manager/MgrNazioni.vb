Public Class MgrNazioni
    Public Shared Function GetLista() As List(Of Nazione)

        Dim ris As New List(Of Nazione)

        ris.Add(New Nazione With {.IdNazione = 0, .Code = "IT", .Nazione = "Italia"})

        Using Mgr As New NazioniDAO
            Dim l As List(Of Nazione) = Mgr.GetAll(LFM.Nazione.Nazione)
            ris.AddRange(l)
        End Using

        Return ris
    End Function

End Class
