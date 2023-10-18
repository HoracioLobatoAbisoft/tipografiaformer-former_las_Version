Imports FormerConfig
Imports FormerLib.FormerEnum

Public Class FormerPathCreator

    Public Shared Function GetAnteprima(ByRef O As Ordine) As String
        Dim ris As String = String.Empty
        If O.FilePath.IndexOf("\") = -1 Then
            If O.Stato = enStatoOrdine.Preinserito Or (O.Stato = enStatoOrdine.Registrato And O.IdCom = 0) Then
                ris = FormerPath.PathTemp & O.FilePath
            Else
                If O.IdTipoProd = enRepartoWeb.StampaOffset Then
                    ris = FormerPath.PathCommesse & O.IdCom & "\" & O.FilePath
                End If
                'If O.IdCom = 0 Then
                '    'qui e' per forza digitale

                'Else
                '    ris = FormerPath.PathCommesse & O.IdCom & "\" & O.FilePath
                'End If
            End If
        Else
            ris = O.FilePath
        End If
        Return ris
    End Function

    Public Shared Function GetAnteprima(ByRef C As Commessa) As String
        Dim ris As String = String.Empty

        If C.IdReparto = enRepartoWeb.StampaOffset Then
            If C.IdCom >= 29067 And C.IdCom < 39660 Then ' DA QUI IN POI E' CAMBIATO L'IMPOSER PER AVERE L'ANTEPRIMA DEL FRONTE
                ris = FormerPath.PathCommesse & C.IdCom & "\" & C.IdCom & ".A.jpg"
            ElseIf C.IdCom >= 39660 Then
                ris = FormerPath.PathCommesse & C.IdCom & "\" & C.IdCom & ".1A.jpg"
            Else
                ris = FormerPath.PathCommesse & C.IdCom & "\" & C.IdCom & ".jpg"
            End If
        Else
            If C.ListaOrdini.Count Then
                Using O As Ordine = C.ListaOrdini()(0) 'qui prendo sempre il primo e unico ordine 
                    ris = GetAnteprima(O)
                End Using
            End If
        End If

        Return ris
    End Function

    'Public Shared Function GetCartellaLavoroFile(ByRef O As Ordine) As String
    '    Dim ris As String = String.Empty

    '    If O.IdCom = 0 Then
    '        ris = FormerPath.PathTemp
    '    Else
    '        'qui devo vedere se e' digitale 
    '        'If O.Commessa.IdReparto = enRepartoWeb.StampaDigitale Then

    '        'ris = FormerPath.PathFileDigitale
    '        'Else
    '        ris = FormerPath.PathCommesse & O.IdCom & "\"
    '        If System.IO.Directory.Exists(ris) = False Then FormerLib.FormerHelper.File.CreateLongPath(ris)
    '        'End If
    '    End If

    '    Return ris
    'End Function

End Class