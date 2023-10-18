Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerConfig

Public Class MgrSound
    Public Shared Sub Suona(Tipo As enTipoSuono)
        Dim NomeFile As String = ""
        Try
            NomeFile = TornaWavDaSuono(Tipo)
            If File.Exists(NomeFile) Then
                My.Computer.Audio.Play(NomeFile)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Shared Function TornaWavDaSuono(tipo As enTipoSuono) As String
        Dim Ris As String = FormerPath.PathSound
        Select Case tipo
            Case enTipoSuono.Ok
                Ris &= "Ok.wav"
            Case enTipoSuono.OkGiroCompletato
                Ris &= "OkGiroCompletato.wav"
            Case enTipoSuono.ErroreCodiceABarreRelativoAUnAltroOrdine
                Ris &= "ErroreCodiceABarreRelativoAUnAltroOrdine.wav"
            Case enTipoSuono.ErroreCodiceInseritoNonValido
                Ris &= "ErroreCodiceInseritoNonValido.wav"
            Case enTipoSuono.ErroreColloGiaCaricato
                Ris &= "ErroreColloGiaCaricato.wav"
            Case enTipoSuono.ErroreNoClientiDiversi
                Ris &= "ErroreNoClientiDiversi.wav"
            Case Else
                Ris &= "error.wav"
        End Select

        Return Ris
    End Function

End Class
