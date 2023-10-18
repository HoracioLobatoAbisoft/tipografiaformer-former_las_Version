Imports Fw = FormerDALWeb
Imports F = FormerDALSql

Public Class MgrTrack

    Private disposedValue As Boolean

    Public Shared Function GetLBfromIdRub(IdRub As Integer) As List(Of Integer)
        Dim ris As New List(Of Integer)



        Return ris
    End Function

    Public Shared Function GetLBfromIdUtOnline(IdRub As Integer) As List(Of Integer)
        Dim ris As New List(Of Integer)



        Return ris
    End Function

    Public Shared Function SaveTrackOnline(IdUtOnline As Integer, IdLB As Integer) As Integer

        Dim Ris As Integer = 0

        Using T As New Fw.TrackerW

            T.IdListinoBase = IdLB
            T.IdUt = IdUtOnline
            T.Quando = Now
            Ris = T.Save()

        End Using

        Return Ris

    End Function

End Class
