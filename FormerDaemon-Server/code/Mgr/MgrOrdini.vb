Imports FormerDALSql
Imports FormerLib

Public Class MgrOrdini

    Public Shared Sub RigeneraAnteprima(IdOrdine As Integer)

        Threading.Thread.Sleep(1000)

        'PER L'ANTEPRIMA LA DEVO CREARE
        Using O As New Ordine
            O.Read(IdOrdine)
            Dim NomeAnteprima As String = O.FilePath

            'SE ESISTE LA ELIMINO
            Try
                If IO.File.Exists(O.FilePath) Then IO.File.Delete(O.FilePath)
            Catch ex As Exception

            End Try

            Dim F As FileSorgente = O.ListaSorgenti(0)

            Dim Creata As Boolean = False
            Dim Tentativi As Integer = 0
            While Creata = False

                Try

                    If FormerHelper.File.IsFileLocked(NomeAnteprima) = False Then
                        FormerHelper.PDF.GetPdfThumbnail(F.FilePath, NomeAnteprima)
                        Creata = True
                    End If

                Catch ex As Exception
                    'qui c'è stato un errore nella creazione dell'anteprima
                    'metto un file temporaneo e poi vediamo
                    FormerUDP.LogMe("ERRORE Rigenerazione Anteprima Ordine " & IdOrdine,, ex)
                    Threading.Thread.Sleep(1000)
                    Tentativi += 1
                End Try

                If Tentativi > 10 Then Creata = True

            End While

        End Using

    End Sub

End Class
