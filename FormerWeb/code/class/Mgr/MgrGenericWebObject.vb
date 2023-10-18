Imports FormerDALWeb

Public Class MgrGenericWebObject

    Public Shared Function FromListPreventivazione(lstP As List(Of PreventivazioneW)) As List(Of GenericWebObject)

        Dim lstV As New List(Of GenericWebObject)

        For Each p In lstP
            Dim r As New GenericWebObject
            r.aggiornata = p.Aggiornata
            r.IdObj = p.IdPrev
            r.NomeInUrl = p.NomeInUrl
            r.Descrizione = p.Descrizione
            r.DescrizioneEstesa = p.DescrizioneEstesa
            r.Img = p.ImgRif
            r.Url = FormerUrlCreator.GetUrlLb(p.GetFirstLb, True)
            lstV.Add(r)
        Next

        Return lstV

    End Function

End Class
