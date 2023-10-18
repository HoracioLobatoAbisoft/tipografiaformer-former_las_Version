Imports FormerLib.FormerEnum

Public Class FileTemporaneoInUso

    Public Property Path As String
    Public Property IdRif As Integer
    Public Property Descrizione As String
    Public Property TipoOggettoListino As enTipoOggettoListino

    Public ReadOnly Property TipoStr As String
        Get
            Dim ris As String = String.Empty

            ris = [Enum].GetName(GetType(enTipoOggettoListino), TipoOggettoListino)

            Return ris
        End Get
    End Property

    Public ReadOnly Property Img As Image
        Get
            Dim ris As Image = Nothing
            If Path.Length Then
                If IO.File.Exists(Path) Then
                    Try
                        ris = Image.FromFile(Path)
                    Catch ex As Exception

                    End Try
                End If
            End If
            Return ris
        End Get
    End Property

End Class
