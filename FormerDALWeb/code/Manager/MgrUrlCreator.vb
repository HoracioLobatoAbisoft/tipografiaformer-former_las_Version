'CLASSE GEMELLA DI FORMERULRCREATOR IN PROGETTO WEB
'PER ORA VA DUPLICATA PERCHE NON POSSO INTEGRARLA E L'ALTRA NON PUO ESSERE SPOSTATA 
'PERCHE PREVEDE I PLUGIN CHE NN SI POSSONO SFILARE DAL PROGETTO

Public Class MgrUrlCreator
    Public Shared Function GetUrlLb(L As ListinoBaseW) As String
        Dim ris As String = String.Empty

        Dim NFogli As Integer = L.faccmin / 2

        If L.faccmin <> L.faccmax AndAlso L.DefaultNFogli <> 0 Then
            NFogli = L.DefaultNFogli
        End If

        ris = "/" & L.IdPrev & "/" & L.IdFormProd & "/" & L.IdTipoCarta & "/" & L.IdColoreStampa & "/" & NFogli & "/" & L.NomeInUrl

        Return ris
    End Function
End Class
