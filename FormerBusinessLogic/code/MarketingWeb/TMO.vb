Imports FormerDALSql
Public Class TMO
    Inherits TemplateMarketingOfferte

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty

            For Each singL As ListinoBaseSuTemplate In ListaOfferte
                ris &= singL.ListinoBase.Nome & "- "
            Next
            ris = ris.TrimEnd(" ", "-")
            Return ris
        End Get
    End Property

    Private _ListaOfferte As List(Of ListinoBaseInTemplate) = Nothing
    Public ReadOnly Property ListaOfferte(Optional ForceLoad As Boolean = False) As List(Of ListinoBaseInTemplate)
        Get
            If _ListaOfferte Is Nothing Or ForceLoad = True Then
                Using mgr As New ListinoBaseSuTemplateDAO
                    Dim l As List(Of ListinoBaseSuTemplate) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdTmLb asc"},
                                                                          New LUNA.LunaSearchParameter(LFM.ListinoBaseSuTemplate.IdTmOff, IdTmOff)) 'idtmlb
                    _ListaOfferte = New List(Of ListinoBaseInTemplate)
                    For Each singL In l
                        Dim singLEx As New ListinoBaseInTemplate
                        singLEx.IdListinoBase = singL.IdListinoBase
                        singLEx.IdTmOff = singL.IdTmOff
                        singLEx.IdTMLB = singL.IdTMLB
                        singLEx.Qta = singL.Qta
                        singLEx.Fogli = singL.Fogli
                        _ListaOfferte.Add(singLEx)
                    Next
                End Using
            End If
            Return _ListaOfferte
        End Get
    End Property

End Class
