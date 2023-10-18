Imports System.IO
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrModelliCommessa

    Public Shared Sub RigeneraAnteprima(IdModelloCommessa As Integer,
                                        FronteRetro As enFronteRetro)

        'PER L'ANTEPRIMA LA DEVO CREARE
        Using M As New ModelloCommessa
            M.Read(IdModelloCommessa)

            Dim PathFile As String = M.PDF
            Dim PathDest As String = String.Empty

            If FronteRetro = enFronteRetro.Fronte Then
                PathDest = FormerConfig.FormerPath.PathTemplatePreps & Path.GetFileNameWithoutExtension(PathFile) & ".F.jpg"
            Else
                PathDest = FormerConfig.FormerPath.PathTemplatePreps & Path.GetFileNameWithoutExtension(PathFile) & ".R.jpg"
            End If

            'SE ESISTE LA ELIMINO
            Try
                If IO.File.Exists(PathDest) Then IO.File.Delete(PathDest)
            Catch ex As Exception

            End Try

            Try
                If FileIO.FileSystem.FileExists(PathFile) Then
                    If FormerHelper.File.IsFileLocked(PathDest) = False Then
                        If PathFile.ToLower.EndsWith("pdf") Then
                            If FronteRetro = enFronteRetro.Fronte Then
                                FormerHelper.PDF.GetPdfThumbnail(PathFile, PathDest)
                                M.Anteprima = PathDest
                            ElseIf FronteRetro = enFronteRetro.Retro Then
                                Dim NumPag As Integer = FormerHelper.PDF.GetNumeroPagine(PathFile)
                                If NumPag = 2 Then
                                    FormerHelper.PDF.GetPdfThumbnail(PathFile, PathDest,, 2)
                                    M.AnteprimaR = PathDest
                                End If
                            End If
                        End If
                        M.Save()
                    Else
                        If FormerConfig.FConfiguration.Altro.WithUIFileOperation Then MessageBox.Show("Il file '" & PathDest & "' risulta locked, impossibile rigenerare l'anteprima")
                    End If

                End If
            Catch ex As Exception
                'qui c'è stato un errore nella creazione dell'anteprima
                'metto un file temporaneo e poi vediamo
                FormerUDP.LogMe("ERRORE Rigenerazione Anteprima MODELLO COMMESSA " & IdModelloCommessa,, ex)

            End Try
        End Using

    End Sub

End Class
